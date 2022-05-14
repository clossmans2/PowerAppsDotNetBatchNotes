import React from "react";
import { Nav } from "react-bootstrap";
import { LinkContainer } from "react-router-bootstrap";
import Song from "../../models/song";

type MusicListViewProps = {
    songs: Song[];
}

type MusicListViewState = {

}

class MusicListView extends React.Component<MusicListViewProps, MusicListViewState> {
    render(): React.ReactNode {
        return (
            <div className="App container">
                <div className="jumbotron">
                    <h2>Songs List</h2>
                </div>
                <table>
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Title</th>
                            <th>Artist</th>
                            <th>Album</th>
                            <th></th>
                        </tr>
                    </thead>    
                    <tbody>
                {this.props.songs.map( (song: Song) =>  (           
                    <React.Fragment key={song.Id}>
                      <tr id={"song-" + song.Id}>
                        <td>{song.AlbumTitle}</td>
                        <td>{song.Artist}</td>
                        <td>{song.Length}</td>
                        <td>{song.Title}</td>
                        <td>
                            <LinkContainer to={"/music/" + song.Id}>
                                <Nav.Link></Nav.Link>
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


export default MusicListView;