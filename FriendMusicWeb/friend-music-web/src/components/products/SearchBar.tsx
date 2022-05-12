import React, { ChangeEventHandler, PureComponent } from "react";

type SearchBarProps = {
    filterText: string;
    inStockOnly: boolean;
    onFilterTextChange: ChangeEventHandler<HTMLInputElement>;
    onInStockChange: ChangeEventHandler<HTMLInputElement>;
};

type SearchBarState = {
    filterText: string;
    inStockOnly: boolean;
};


class SearchBar extends PureComponent<SearchBarProps, SearchBarState> {
    constructor(props: SearchBarProps) {
      super(props);
      this.handleFilterTextChange = this.handleFilterTextChange.bind(this);
      this.handleInStockChange = this.handleInStockChange.bind(this);
    }
    state: SearchBarState = {
        filterText: "",
        inStockOnly: false
    };
    
    handleFilterTextChange(e: any) {
        this.setState({
            filterText: e.target.value
        });
        this.props.onFilterTextChange(e.target.value);
    }
    
    handleInStockChange(e: any) {
        this.setState({
            inStockOnly: e.target.checked
        });
      this.props.onInStockChange(e.target.checked);
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
          <p>
            <input
              type="checkbox"
              checked={this.state.inStockOnly}
              onChange={this.handleInStockChange}
            />
            {' '}
            Only show products in stock
          </p>
        </form>
      );
    }
  }

export default SearchBar;