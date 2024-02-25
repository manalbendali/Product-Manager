import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductsService } from '../Service/products.service';
import { Product } from '../model/product.model';

@Component({
  selector: 'app-new-products',
  templateUrl: './new-products.component.html',
  styleUrls: ['./new-products.component.css']
})
export class NewProductsComponent implements OnInit {

public productForm! : FormGroup;



constructor(private fb:FormBuilder , private ps : ProductsService){

}

ngOnInit(){
  this.productForm=this.fb.group({
    name : this.fb.control('' ,[Validators.required,Validators.maxLength(20)]),
    price : this.fb.control(0,[Validators.required]),
    checked : this.fb.control(false)
  }) ; 
}

saveProduct(){
  let product : Product = this.productForm.value;
  this.ps.saveProduct(product).subscribe({
    next : data=>{
      alert(JSON.stringify(data));
    },error(err) {
      console.log(err)  
    },
  });
}

}
