import React, { Component } from "react";
import Song from "../../models/song";
//import SongRow from "./SongRow";
import SongTableColumns from "./SongTableColumns";

type SongTableProps = {
    filterText: string;
    songs: Song[];
}

type SongTableState = {

}

class SongTable extends Component<SongTableProps, SongTableState> {
    render() {
        return (
              <table className="table table-bordered table-striped table-hover table-highlight">
                <thead>
                  <SongTableColumns />
                </thead>
                <tbody> 
                  {this.props.songs.map( (song: Song) =>  (           
                    // <SongRow song={song} key={song.Id} />
                    <React.Fragment key={song.Id}>
                      <tr id={"song-" + song.Id}>
                        <td>{song.AlbumTitle}</td>
                        <td>{song.Artist}</td>
                        <td>{song.Length}</td>
                        <td>{song.Title}</td>
                      </tr>
                    </React.Fragment>
                  ))};
                </tbody>
              </table>
        );
    };
}

export default SongTable;