import { AxiosResponse } from "axios";
import React from "react";
import { Table } from "react-bootstrap";
import { Link } from "react-router-dom";
import Playlist from "../../models/playlist";
import APIService from "../../services/apiService";
import { PlaylistOwner } from "./PlaylistOwner";

type PlaylistListViewProps = {
    
}

type PlaylistViewState = {
    playlists: Playlist[];
}

class PlaylistListView extends React.Component<PlaylistListViewProps, PlaylistViewState> {
    /**
     *
     */
    constructor(props: PlaylistListViewProps) {
        super(props);
        this.state = {
            playlists: []
        }
    }

    componentDidMount() {
        APIService.getPlaylists()
        .then((response: AxiosResponse<Playlist[]>) => {
            this.setState({
                playlists: response.data
            })
        })
        .catch((err) => {
            console.error(err);
        });
    }
    
    render(): React.ReactNode {
        return (
            <div className="App container">
                <div className="jumbotron">
                    <h2>Top Playlists</h2>
                </div>
                <Table striped bordered hover>
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Title</th>
                            <th>Description</th>
                            <th>TotalTracks</th>
                            <th>Owner</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.playlists.map( (playlist: Playlist) =>  (           
                            <React.Fragment key={playlist.Id}>
                            <tr id={"playlist-" + playlist.Id}>
                                <td>{playlist.Id}</td>
                                <td>{playlist.Title}</td>
                                <td>{playlist.Description}</td>
                                <td>{playlist.TotalTracks}</td>
                                <PlaylistOwner owner={playlist.Owner} />
                                <td>
                                    <Link to={`${playlist.Id}`} className="btn btn-info">Details</Link>
                                </td>
                            </tr>
                            </React.Fragment>
                        ))};
                    </tbody>
                </Table>
            </div>
        );
    }
}

export default PlaylistListView;