
import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { AuthService } from './../../../services/auth.service';
import { Register } from "src/app/models/register.model";
// import { User } from "src/app/models/User";



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  
  email: string = '';
  userId: any;
  password: string = '';
  UserData: Register = new Register();
  registerForm!: FormGroup;
  

  constructor(private authService: AuthService, private router: Router) {}



  ngOnInit(): void {
    this.registerForm = new FormGroup({
      email: new FormControl('',),
      password: new FormControl('',),
    });
    
  }

  
  onSubmit(): void {

    if (this.registerForm.invalid) {
      return;
    }
 
    
    this.authService.registerUser(this.email, this.password).subscribe(
      (result) => {
        console.log('Registration successful:', result);
        alert('Registration successful');
        this.router.navigateByUrl('login');
      },
      error => {
        console.error('Registration failed:', error);
        alert('Registration failed');
      }
    );
  }
 
}
