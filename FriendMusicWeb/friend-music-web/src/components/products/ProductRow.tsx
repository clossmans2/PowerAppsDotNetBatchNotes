import React, {Component} from "react";
import { Product } from "../../models";

type ProductRowProps = {
    product: Product;
}

type ProductRowState = {

}

class ProductRow extends Component<ProductRowProps, ProductRowState> {
    render() {
      const product = this.props.product;
      const name = product.stocked ?
        product.name :
        <span style={{color: 'red'}}>
          {product.name}
        </span>;
  
      return (
        <tr>
          <td>{name}</td>
          <td>{product.price}</td>
        </tr>
      );
    }
  }

export default ProductRow;