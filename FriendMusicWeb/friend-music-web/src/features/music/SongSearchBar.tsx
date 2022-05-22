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
      this.handleSearchFormSubmit = this.handleSearchFormSubmit.bind(this);
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

    handleSearchFormSubmit(e: any) {
        e.preventDefault();
    }
    
    render() {
      return (
        <form onSubmit={this.handleSearchFormSubmit}>
          <div className="mb-5 row">
            <label htmlFor="songSearchInput" className="col-sm-2 form-label">Search</label>
            <br />
            <br />
            <div className="col-sm-10">
              <input 
                id="songSearchInput"
                type="text" 
                className="form-control"
                value={this.state.filterText}
                onChange={this.handleFilterTextChange}
                />
              </div>
            </div>
            <button type="submit">Search</button>
        </form>
      );
    }
  }

export default SongSearchBar;