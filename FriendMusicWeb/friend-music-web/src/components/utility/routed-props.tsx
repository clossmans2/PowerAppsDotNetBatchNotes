import React, { ComponentType } from 'react';
import { useNavigate, useLocation, useParams } from 'react-router-dom';

export interface RoutedProps<T = ReturnType<typeof useParams>> {
    history: {
        back: () => void;
        goBack: () => void;
        location: ReturnType<typeof useLocation>;
        push: (url: string, state?: any) => void;
    };
    params: T;
    location: ReturnType<typeof useLocation>;
    match: {
        params: T;
    };
    navigate: ReturnType<typeof useNavigate>;
};

export const withRouter = <P extends object>(Component: ComponentType<P>) => {
    return (props: Omit<P, keyof RoutedProps>) => {
        const location = useLocation();
        const match = { params: useParams() }
        const params = useParams();
        const navigate = useNavigate();        
        const history = {
            back: () => navigate(-1),
            goBack: () => navigate(-1),
            location,
            push: (url: string, state?: any) => navigate(url, { state }),
            replace: (url: string, state?: any) => navigate(url, {
                replace: true,
                state
            })
        };
        return (
            <Component
                {...props as P}
                router={{ history, location, match, params, navigate }}
                history={history}
                location={location}
                match={match}
                params={params}
                navigate={navigate}
                
            />
        );
        
    };
};

export default withRouter;