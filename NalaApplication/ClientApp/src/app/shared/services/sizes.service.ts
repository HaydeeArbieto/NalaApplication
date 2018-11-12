import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()

export class SizesService {
  constructor(private http: HttpClient) { }


  getSize(id:number){
    return this.http
      .get('http://localhost:50296/api/sizes/' + id);
  }

  getSizes(){
    return this.http
      .get('http://localhost:50296/api/sizes/');
  }
  
}
