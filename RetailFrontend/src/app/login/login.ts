import { Component } from '@angular/core';
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
      // Perform your API logic here
    } else {
      this.loginForm.markAllAsTouched();
    }
  }

  showPassword = false;

  togglePassword() {
    this.showPassword = !this.showPassword;
  }
}
