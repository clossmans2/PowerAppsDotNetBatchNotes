import React, { ChangeEventHandler, PureComponent } from "react";

type SongSearchBarProps = {
    filterText: string;
    onFilterTextChange: ChangeEventHandler<HTMLInputElement>;
};

type SongSearchBarState = {
    filterText: string;
};


class SongSearchBar extends PureComponent<SongSearchBarProps, SongSearchBarState> {
    constructor(props: SongSearchBarProps) {
      super(props);
      this.handleFilterTextChange = this.handleFilterTextChange.bind(this);
    }
    state: SongSearchBarState = {
        filterText: "",
    };
    
    handleFilterTextChange(e: any) {
        this.setState({
            filterText: e.target.value
        });
        this.props.onFilterTextChange(e.target.value);
    }
    
    render() {
      return (
        <form>
          <input
            type="text"
            placeholder="Search..."
            value={this.state.filterText}
            onChange={this.handleFilterTextChange}
          />
        </form>
      );
    }
  }

export default SongSearchBar;