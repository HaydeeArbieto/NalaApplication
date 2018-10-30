import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Product } from '../models/models';
import { Observable } from 'rxjs/Observable';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable()

export class ProductsService {
  constructor(private http: HttpClient) { }


  getProduct(id:number): Observable<Product> {
    return this.http
      .get<Product>('http://localhost:54869/api/products/' + id);
  }

  getProducts(): Observable<Product[]> {
    return this.http
      .get<Product[]>('http://localhost:54869/api/products/');
  }
  
}
