import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../Service/products.service';
import { HttpClient } from '@angular/common/http';
import { Product } from '../model/product.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  products : Array<Product>=[];

  public keyword :string ="";

  handleCheckProduct(Product:Product){
    this.productService.CheckProducts(Product)
      .subscribe(
        {
          next : updatedProduct => {
              Product.checked=!Product.checked;
          }
        }
      )
    
  }

  getProducts(){
    this.productService.getAllProducts(1,2)
    .subscribe({
      next: data =>{
        this.products=data
      },
      error : err =>{
        console.log(err);
      }
    });
  }

  hendleDeleteProduct(product:Product){
    if(confirm("Etes vous sure ?"))
    this.productService.DeleteProduct(product).subscribe({
      next:value=>{
        //this.getProducts();
       this.products = this.products.filter(p=>p.id!=product.id);
      } 

    })
  }

  constructor(private productService :ProductsService  ){

  }

  ngOnInit() {
    this.getProducts()
      
  }

  searchProducts(){
    this.productService.searchProducts(this.keyword).subscribe({
      next : value =>{
        this.products=value;
      }
    })
  }

}
