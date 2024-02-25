import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { Observable } from 'rxjs';
import { Product } from '../model/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private http :HttpClient) { }

  baseApiUrl : string = environment.baseApiUrl;

  public getAllProducts(page : number =1 ,size : number=4) :Observable<any[]> {
    return  this.http.get<Array<Product>>(this.baseApiUrl + '/api/Product/GetAllProducts? page= ${page} & limit=${size}')
  }
 
  public CheckProducts(product : Product):Observable<Product>{
    return this.http.put<Product>(this.baseApiUrl + '/api/Product/updateProduct/' + product.id,{
      name:product.name,
      price:product.price,
      checked : ! product.checked
    } );
  }

  public DeleteProduct(product : Product){
    return this.http.delete<any>(this.baseApiUrl + '/api/Product/DeleteProduct/' + product.id);
  }

  public saveProduct (product : Product): Observable<Product>{
    return this.http.post<Product>(this.baseApiUrl + '/api/Product/AddProduct' ,{
      name:product.name,
      price:product.price,
      checked :  product.checked
    } );
  }


  public searchProducts(keyword : string) :Observable<Array<Product>> {
    return  this.http.get<Array<Product>>(this.baseApiUrl + '/api/Product/GetAllByName/'+keyword)
  }

}
