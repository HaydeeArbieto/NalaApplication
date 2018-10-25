import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import { map, catchError, tap } from 'rxjs/operators';

@Injectable()

export class ProductsService {
  constructor(private http: HttpClient) { }

  private extractData(res: Response) {
    let body = res;
    return body || {};
  }

  getProduct(): Observable<any> {
    return this.http.get('http://localhost:62856/api/products/1').pipe(map(this.extractData));
  }
    //  .get('http://localhost:62856/api/products/1').map(response => JSON.stringify(response));
  
  
}
