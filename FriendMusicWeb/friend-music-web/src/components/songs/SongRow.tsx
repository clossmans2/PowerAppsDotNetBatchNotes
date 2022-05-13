import React, {Component} from "react";
import Song from "../../models/song";

type SongRowProps = {
    song: Song;
}

type SongRowState = {

}

class SongRow extends Component<SongRowProps, SongRowState> {
    render() {
      const song = this.props.song;
      let songId = `song${song.Id}`;
      return (
        <React.Fragment key={song.Id}>
          <tr id={songId}>
            <td>{song.AlbumTitle}</td>
            <td>{song.Artist}</td>
            <td>{song.Length}</td>
            <td>{song.Title}</td>
          </tr>
        </React.Fragment>
      );
    }
  }

export default SongRow;