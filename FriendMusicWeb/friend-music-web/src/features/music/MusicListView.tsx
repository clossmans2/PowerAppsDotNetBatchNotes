import { AxiosResponse } from "axios";
import React from "react";
import { Table } from "react-bootstrap";
import { Link } from "react-router-dom";
import Song from "../../models/song";
import APIService from "../../services/apiService";

type MusicListViewProps = {}
    

type MusicListViewState = {
    songs: Song[];
}


class MusicListView extends React.Component<MusicListViewProps, MusicListViewState> {
    constructor(props: MusicListViewProps) {
        super(props);
        this.state = {
            songs: []
        }
    }
    
    componentDidMount() {
        APIService.getSongs()
          .then((response: AxiosResponse<Song[]>) => {
            this.setState({
              songs: response.data
            });
          })
          .catch((err: Error) => {
            console.log(err);
          });
      }
    
    render(): React.ReactNode {
        return (
            <>
            <div className="App container">
                <div className="jumbotron">
                    <h2>Songs List</h2>
                </div>
                <Table bordered hover responsive striped>
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
                {this.state.songs.map( (song: Song) =>  (           
                    <React.Fragment key={song.Id}>
                      <tr id={"song-" + song.Id}>
                        <td>{song.AlbumTitle}</td>
                        <td>{song.Artist}</td>
                        <td>{song.Length}</td>
                        <td>{song.Title}</td>
                        <td>
                            <Link className="btn btn-primary" to={`${song.Id}`}>Details</Link>
                        </td>
                      </tr>
                    </React.Fragment>
                  ))};
                  </tbody>
                </Table>
            </div>
            </>
        );
    }
}


export default MusicListView;