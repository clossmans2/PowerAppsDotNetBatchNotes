import React, { Component, ReactElement } from "react";
import ProductCategoryRow from "./ProductCategoryRow";
import ProductRow from "./ProductRow";
import { Product } from "../../models";

type ProductTableProps = {
    filterText: string;
    inStockOnly: boolean;
    products: Product[];
}

type ProductTableState = {

}

class ProductTable extends Component<ProductTableProps, ProductTableState> {
    render() {
      const filterText = this.props.filterText;
      const inStockOnly = this.props.inStockOnly;
  
      const rows: Array<ReactElement<any, any>> = [];
      let lastCategory: any = null;
  
      this.props.products.forEach((product: any) => {
        if (product.name.indexOf(filterText) === -1) {
          return;
        }
        if (inStockOnly && !product.stocked) {
          return;
        }
        if (product.category !== lastCategory) {
          rows.push(
            <ProductCategoryRow
              category={product.category}
              key={product.category} />
          );
        }
        rows.push(
          <ProductRow
            product={product}
            key={product.name}
          />
        );
        lastCategory = product.category;
      });
  
      return (
        <table>
          <thead>
            <tr>
              <th>Name</th>
              <th>Price</th>
            </tr>
          </thead>
          <tbody>{rows}</tbody>
        </table>
      );
    }
  }

export default ProductTable;