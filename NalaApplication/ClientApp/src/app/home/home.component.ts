import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  constructor(private http: HttpClient) { }
  product = {};

 

  ngOnInit() {
    //this.http.get('/api/products/1').subscribe(values => {
    //  this.product = values;
    //});
  }
}
