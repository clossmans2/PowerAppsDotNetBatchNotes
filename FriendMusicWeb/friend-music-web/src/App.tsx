import React from 'react';
import './App.css';
import PRODUCTS from './components/products/Products';
import FilterableProductTable from './components/products/FilterableProductTable';

function App() {
  return (
    <div className="App">
      <FilterableProductTable products={PRODUCTS} />
    </div>
  );
}

export default App;
