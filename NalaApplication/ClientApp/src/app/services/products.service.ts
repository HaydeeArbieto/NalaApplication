import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()

export class ProductsService {
  constructor(private http: HttpClient) { }


  getProduct(id:number){
    return this.http
      .get('http://localhost:54869/api/products/' + id);
  }

  getProducts(){
    return this.http
      .get('http://localhost:54869/api/products/');
  }
  
}
