import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Data } from '@angular/router';
import { Observable } from 'rxjs';
import { user } from '../Models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http:HttpClient) { }

  

  login(data:user):Observable<any>
  {
    return this.http.post("https://localhost:5001/api/Account/Login",data);
  }
  register(data):Observable<any>
  {
    return this.http.post("https://localhost:5001/api/Account/Register",data);
  }
  saveToken(token)
  {
    localStorage.setItem('token',token)
  }
  getToken()
  {
    return localStorage.getItem('token');
  }

}
