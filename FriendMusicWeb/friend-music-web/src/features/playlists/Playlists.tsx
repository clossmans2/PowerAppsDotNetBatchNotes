import React from 'react';
import { Outlet, Route, Routes } from 'react-router-dom';
import PlaylistDetailsView from './PlaylistDetailsView';
import PlaylistListView from './PlaylistListView';

type PlaylistProps = {};
type PlaylistState = {};

export class Playlist extends React.Component<PlaylistProps, PlaylistState> {
    constructor(props: PlaylistProps) {
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
                    <Route index element={<PlaylistListView />} />      
                    <Route path=':playlistId' element={<PlaylistDetailsView />} />      
                </Routes>
                
                <Outlet />
            </>
        );
    }
}