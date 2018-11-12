import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()

export class ColorsService {
  constructor(private http: HttpClient) { }


  getColor(id:number){
    return this.http
      .get('http://localhost:50296/api/colors/' + id);
  }

  getColors(){
    return this.http
      .get('http://localhost:50296/api/colors/');
  }
  
}
