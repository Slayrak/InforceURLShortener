import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { URLModel } from '../models/urlmodel'

@Injectable()
export class URLService {

    headers: HttpHeaders;
  
    constructor(private http: HttpClient) {
      this.headers = new HttpHeaders({
        'Content-Type': 'application/json; charset=utf-8',
        'authorization': `Bearer ${localStorage['token']}`,
      });
    }
  
    getAllBooks() {
      return this.http.get<URLModel[]>(`http://localhost:5056/TableAndInfo/GetAllURLS`, { headers: this.headers });
    }

  }
