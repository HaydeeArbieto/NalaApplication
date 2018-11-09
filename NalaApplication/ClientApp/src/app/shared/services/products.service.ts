import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Product } from '../models/models';
import { Observable } from 'rxjs/Observable';

@Injectable()

export class ProductsService {
  constructor(private http: HttpClient) { }



 httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json; charset=utf-8',
 
   }),
};
getProduct(id: number){
    return this.http
      .get('http://localhost:50296/api/products/' + id);
  }

  getProducts(){
    return this.http
      .get('http://localhost:50296/api/products/');
  }
  
  postProduct(product) {
 
    return this.http.post('http://localhost:50296/api/products/', JSON.stringify(product), this.httpOptions);
      
  }
    
  
}
