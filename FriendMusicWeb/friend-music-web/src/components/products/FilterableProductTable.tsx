  import React, { Component } from "react";
  import SearchBar from "./SearchBar";
  import ProductTable from "./ProductTable";
  import { Product } from "../../models";
  
type FilterableProductTableProps = {
    products: Product[];
}

type FilterableProductTableState = {
    filterText: string;
    inStockOnly: boolean;
}

  class FilterableProductTable extends Component<FilterableProductTableProps, FilterableProductTableState> {
    constructor(props: FilterableProductTableProps) {
      super(props);
      this.state = {
        filterText: '',
        inStockOnly: false
      };
      
      this.handleFilterTextChange = this.handleFilterTextChange.bind(this);
      this.handleInStockChange = this.handleInStockChange.bind(this);
    }
  
    handleFilterTextChange(filterText: any) {
      this.setState({
        filterText: filterText
      });
    }
    
    handleInStockChange(inStockOnly: any) {
      this.setState({
        inStockOnly: inStockOnly
      })
    }
  
    render() {
      return (
        <div>
          <SearchBar
            filterText={this.state.filterText}
            inStockOnly={this.state.inStockOnly}
            onFilterTextChange={this.handleFilterTextChange}
            onInStockChange={this.handleInStockChange}
          />
          <ProductTable
            products={this.props.products}
            filterText={this.state.filterText}
            inStockOnly={this.state.inStockOnly}
          />
        </div>
      );
    }
  }


  export default FilterableProductTable;