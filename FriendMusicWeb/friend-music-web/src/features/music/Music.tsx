import React from 'react';
import { Outlet, Route, Routes } from 'react-router-dom';
import MusicDetailsView from './MusicDetailsView';
import MusicListView from './MusicListView';

type MusicProps = {};
type MusicState = {};

export class Music extends React.Component<MusicProps, MusicState> {
    constructor(props: MusicProps) {
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
                    <Route index element={<MusicListView />} />      
                    <Route path=':songId' element={<MusicDetailsView />} />      
                </Routes>
                
                <Outlet />
            </>
        );
    }
}