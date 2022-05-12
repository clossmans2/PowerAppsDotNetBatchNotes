import React from "react";

type ProductCategoryRowProps = {
    category: string;
}

type ProductCategoryRowState = {

}


class ProductCategoryRow extends React.Component<ProductCategoryRowProps, ProductCategoryRowState> {
    render() {
      const category = this.props.category;
      return (
        <tr>
          <th colSpan={2}>
            {category}
          </th>
        </tr>
      );
    }
  }

export default ProductCategoryRow;