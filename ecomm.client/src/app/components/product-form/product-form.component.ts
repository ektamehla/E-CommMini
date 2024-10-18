import { Component } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';
@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrl: './product-form.component.css'
})
export class ProductFormComponent {

  product: Product = {
    id: 0,
    name: '',
    price: 0,
    description: '',
    category: '',
  };

  constructor(private productService: ProductService) { }

  onSubmit() {
    this.productService.createProduct(this.product).subscribe((response) => {
      console.log('Product created:', response);
    });
  }

}
