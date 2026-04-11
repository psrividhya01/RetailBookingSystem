import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { Auth } from '../services/auth'; 
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule, CommonModule, RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  
  private router = inject(Router); // Modern way to inject in Angular 21

  loginForm = new FormGroup({
    email: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required, Validators.email]
    }),
    password: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required, Validators.minLength(6)]
    })
  });

  onSubmit() {
    if (this.loginForm.valid) {
      const loginData = this.loginForm.getRawValue();
      console.log('Logging in with:', loginData);
      console.log('Login success!');
      this.router.navigate(['/home']);  // Navigate to home page
    } else {
      this.loginForm.markAllAsTouched();
    }
  }
  showPassword = false;

  togglePassword() {
    this.showPassword = !this.showPassword;
  }
}
