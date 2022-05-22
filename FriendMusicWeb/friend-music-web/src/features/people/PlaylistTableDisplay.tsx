import React from "react";
import { Table } from "react-bootstrap";
import { Link } from "react-router-dom";
import {Playlist} from '../../models';

type PlaylistTableDisplayProps = {
    playlists: Playlist[] | null;
    title: string;
}

class PlaylistTableDisplay extends React.Component<PlaylistTableDisplayProps> {
    render() {
        if (this.props.playlists === null || this.props.title === null) {
            return('');
        } else {
            return(
                <>
                    <dt className="col-sm-2">{this.props.title}</dt>
                    <dd className="col-sm-10">
                        <Table striped bordered hover>
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>Title</th>
                                    <th>Description</th>
                                    <th>Total Tracks</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                {this.props.playlists.map((plist:Playlist) => (
                                    <React.Fragment key={plist.Id}>
                                    <tr>
                                        <td>{plist.Id}</td>
                                        <td>{plist.Title}</td>
                                        <td>{plist.Description}</td>
                                        <td>{plist.TotalTracks}</td>
                                        <td><Link to={`playlist/${plist.Id}`} className="btn btn-primary">Details</Link></td>
                                    </tr>
                                </React.Fragment>
                                ))};
                            </tbody>
                        </Table>
                    </dd>
                </>
            );
        }
    }
}
export default PlaylistTableDisplay;