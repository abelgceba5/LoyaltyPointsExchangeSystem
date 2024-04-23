import { Observable, of, throwError } from 'rxjs';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
// import { User } from '../models/User';
import { HttpClient, HttpHeaders } from "@angular/common/http";
// import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environments';
import { LogIn } from '../models/User';



const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  // private url = "http://localhost:7140/";
  
  appUrl = 'api/';
  apiUrl = environment.apiUrl + this.appUrl;

 
  constructor(
    private http: HttpClient,
    private router: Router,
   
  ) {}
  // httpOptions: { headers: HttpHeaders } = {
  //   headers: new HttpHeaders({ "Content-Type": "application/json" }),
  // };


  private isAuthenticated = false;
  private userRole: string | null = null;

  authenticateUsername(username: string, password: string): Observable<any> {
 
    return this.http.get<any>(this.apiUrl + 'Login/AuthenticateUsername/' + username + '/' + password);
  }
  
  registerUser(username: string, password: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}RegisterUser/AuthenticateUsername/${username}/${password}`, {});;
  }


 
  // async register(email: any, password: any): Promise<any> {

  //   console.log(password)
  //   console.log(email)
   
  //   try {

  //     const data = { email, password};
  //     //const response =this.http.post(`${this.appUrl}/RegisterUser`,data , this.httpOptions)
  //     return response;

  //   } 
  //   catch (error) {

  //     throw error;

  //   }
   
    
  // }
  setToken(token: string): void {
    localStorage.setItem('token', token);
  }
  setRole(role: string): void {
    localStorage.setItem('role', role)
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  isLoggedIn() {

    return this.getToken() !== null;
    
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['login']);
  }

 
  // login({ email, password }: any): Observable<any> {
  //     const loginData = { email, password };
  
  //     try {
  //         // Send a POST request to the server to authenticate the user
  //         const response = this.http.post<any>(`${this.appUrl}/login`, loginData, this.httpOptions);
  
  //         response.subscribe(() => {
            
  //         });
  
  //         return response;
  //     } catch (error) {
  //         this.isAuthenticated = false;
  //         return throwError(new Error('Failed to login'));
  //     }
  // }

  // authenticateUsername(username: string, password: string): Observable<any> {
  //   //const url = `${this.baseUrl}/AuthenticateUsername/${username}/${password}`;
  //   // return this.httpClient.get<any>(url);
 
  //   return this.http.get<any>(this.apiUrl + 'Login' + username + '/' + password);
  // }
 
  isAuthenticatedUser(): boolean {
    return this.isAuthenticated;
  }
 
  // getUserRole(email: any): any {
   

  //   const domain = email.split('@')[1]
  //   if(domain === '@tut4life.ac.za' ){
  //     const role = 'Alumni';
  //     return this.userRole = role;

  //   }
  //   else if(domain === '@tut.ac.za'){
  //     const role = 'Admin';
  //     return this.userRole = role;

  //   } 
  // }

 

}