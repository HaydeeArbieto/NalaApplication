import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()

export class CategoriesService {
  constructor(private http: HttpClient) { }


  getCategory(id:number){
    return this.http
      .get('http://localhost:50296/api/categories/' + id);
  }

  getCategories(){
    return this.http
      .get('http://localhost:50296/api/categories/');
  }
  
}
