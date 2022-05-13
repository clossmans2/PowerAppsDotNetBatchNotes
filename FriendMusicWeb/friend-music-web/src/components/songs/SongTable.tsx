import React, { Component, ReactElement } from "react";
import SongRow from "./SongRow";
import Song from "../../models/song";

type SongTableProps = {
    filterText: string;
    Songs: Song[];
}

type SongTableState = {

}

class SongTable extends Component<SongTableProps, SongTableState> {
    render() {
      const filterText = this.props.filterText;
  
      const rows: Array<ReactElement<SongRow>> = [];
  
      this.props.Songs.forEach((Song: Song) => {
        if (Song.Title.indexOf(filterText) === -1) {
          return;
        }
        rows.push(
          <SongRow
            Song={Song}
            key={Song.Title}
          />
        );
        });
  
      return (
        <table>
          <thead>
            <tr>
              <th>Album Title</th>
              <th>Artist</th>
              <th>Length</th>
              <th>Title</th>
            </tr>
          </thead>
          <tbody>{rows}</tbody>
        </table>
      );
    }
  }

export default SongTable;