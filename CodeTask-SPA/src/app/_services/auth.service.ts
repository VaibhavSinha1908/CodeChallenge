import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

values: any;
baseUrl = 'http://localhost:5000/api/';

constructor(private http: HttpClient) { }

getDDValues() {
  return this.http.get(this.baseUrl + 'values');
}

public calculatePremium(obj: any) {
  return this.http.post(this.baseUrl + 'Calculate', JSON.stringify(obj), {headers:
    {
     'Content-Type': 'application/json'
  }});
}


}
