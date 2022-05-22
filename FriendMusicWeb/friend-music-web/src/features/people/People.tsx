import React from 'react';
import { Outlet, Route, Routes } from 'react-router-dom';
import PersonDetailsView from './PersonDetailsView';
import PeopleListView from './PeopleListView';

type PeopleProps = {};
type PeopleState = {};

export class People extends React.Component<PeopleProps, PeopleState> {
    constructor(props: PeopleProps) {
        super(props);
        this.state = {

        };
    }
    componentDidMount(){

    }
    render(): React.ReactNode {
        return(
            <>
                <Routes>
                    <Route index element={<PeopleListView />} />      
                    <Route path=':personId' element={<PersonDetailsView />} />      
                </Routes>
                
                <Outlet />
            </>
        );
    }
}