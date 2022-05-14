import React from "react";
import { Nav } from "react-bootstrap";
import { LinkContainer } from "react-router-bootstrap";
import Playlist from "../../models/playlist";

type PlaylistListViewProps = {
    playlists: Playlist[];
}

type PlaylistViewState = {

}

class PlaylistListView extends React.Component<PlaylistListViewProps, PlaylistViewState> {
    render(): React.ReactNode {
        return (
            <div className="App container">
                <div className="jumbotron">
                    <h2>Top Playlists</h2>
                </div>
                <table className="table table-striped table-bordered table-hover table-highlight">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.props.playlists.map( (playlist: Playlist) =>  (           
                            <React.Fragment key={playlist.Id}>
                            <tr id={"song-" + playlist.Id}>
                                <td>{playlist.Id}</td>
                                <td>{playlist.Title}</td>
                                <td>{playlist.Description}</td>
                                <td>{playlist.TotalTracks}</td>
                                <td>
                                    <LinkContainer to={"/playlist/" + playlist.Id}>
                                        <Nav.Link className="btn btn-primary">
                                            Details
                                        </Nav.Link>
                                    </LinkContainer>
                                </td>
                            </tr>
                            </React.Fragment>
                        ))};
                    </tbody>
                </table>
            </div>
        );
    }
}

export default PlaylistListView;