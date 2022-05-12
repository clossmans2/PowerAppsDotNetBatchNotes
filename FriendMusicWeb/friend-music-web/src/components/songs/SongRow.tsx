import React, {Component} from "react";
import Song from "../../models/song";

type SongRowProps = {
    Song: Song;
}

type SongRowState = {

}

class SongRow extends Component<SongRowProps, SongRowState> {
    render() {
      const Song = this.props.Song;
      let songId = `song${Song.Id}`;
      return (
        <tr id={songId}>
          <td>{Song.AlbumTitle}</td>
          <td>{Song.Artist}</td>
          <td>{Song.Length}</td>
          <td>{Song.Title}</td>
        </tr>
      );
    }
  }

export default SongRow;