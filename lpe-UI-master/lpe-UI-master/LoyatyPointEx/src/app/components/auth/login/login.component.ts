import { Router } from '@angular/router';
import { AuthService } from './../../../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { LogIn } from 'src/app/models/User';
import { HttpHeaders } from '@angular/common/http';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  
email: string = '';
userId: any;
password: string = '';
UserData: LogIn = new LogIn();
loginForm!: FormGroup;

  



//this.router.navigateByUrl('dashboard');
  constructor(private auth: AuthService, private formBuilder: FormBuilder, private router: Router) {}


  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(6)]),
    });
    
    
  }


  // onSubmit(): void {
  //   if (!this.loginForm.valid) {
  //     return;
  //   }
    
  //   this.UserData.UserName = this.email;
  //   this.UserData.Password = this.password;
  //   this.UserData.UserId = this.userId;
  //     this.auth.authenticateUsername(this.UserData.UserName, this.UserData.Password).subscribe(
  //       (result) => {
  //        // this.UserData.UserId = result.userId;
  //        sessionStorage.setItem('userId ', result.userId);
  //         console.log('User ID:', this.UserData.UserId );
  //         console.log('Login successful');
  //         alert('Login successful');
          
  //         this.router.navigateByUrl('user/purchase');

  //       },
  //       error => {
         
  //         console.error('Login failed:', error);
  //         alert('Login failed');
  //       }
  //     ); 
  // }
  onSubmit(): void {
    if (!this.loginForm.valid) {
      return;
    }
    
    this.UserData.UserName = this.email;
    this.UserData.Password = this.password;
  
    // Retrieve userId from sessionStorage
    this.userId = sessionStorage.getItem('userId');
    console.log('Retrieved userId from sessionStorage:', this.userId); // Add this line
  
    this.auth.authenticateUsername(this.UserData.UserName, this.UserData.Password).subscribe(
      (result) => {
        console.log('API response:', result); // Add this line
        sessionStorage.setItem('userId', result.userId);
        this.userId = result.userId;
        console.log('Updated userId:', this.userId);
        console.log('Login successful');
        alert('Login successful');
        
        this.router.navigateByUrl('user/purchase');
      },
      error => {
        console.error('Login failed:', error);
        alert('Login failed');
      }
    ); 
  }
  
 

  
}