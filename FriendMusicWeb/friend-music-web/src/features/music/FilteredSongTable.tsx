import React, { Component } from "react";
import SongSearchBar from "./SongSearchBar";
import SongTable from "./SongTable";
import Song from "../../models/song";

type FilterableSongTableProps = {
  songs: Song[];
}

type FilterableSongTableState = {
  filterText: string;
}

class FilterableSongTable extends Component<FilterableSongTableProps, FilterableSongTableState> {
  constructor(props: FilterableSongTableProps) {
    super(props);
    this.state = {
      filterText: '',
    };
    
    this.handleFilterTextChange = this.handleFilterTextChange.bind(this);
  }

  handleFilterTextChange(filterText: any) {
    this.setState({
      filterText: filterText
    });
}
  
  render() {
    return (
      <div>
        <SongSearchBar
          filterText={this.state.filterText}
          onFilterTextChange={this.handleFilterTextChange}
        />
        <SongTable
          songs={this.props.songs}
          filterText={this.state.filterText}
        />
      </div>
    );
  }
}


export default FilterableSongTable;