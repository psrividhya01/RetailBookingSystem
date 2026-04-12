import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { Auth } from '../services/auth';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  constructor(
    private auth: Auth,
    private router: Router,
  ) {}

  loginForm = new FormGroup({
    email: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required, Validators.email],
    }),
    password: new FormControl('', {
      nonNullable: true,
      validators: [Validators.required, Validators.minLength(6)],
    }),
  });

  showPassword = false;

  togglePassword() {
    this.showPassword = !this.showPassword;
  }

  onSubmit() {
    if (this.loginForm.valid) {
      const loginData = this.loginForm.getRawValue();

      this.auth.login(loginData).subscribe({
        next: (res) => {
          console.log('Login success', res);

          // redirect to home
          this.router.navigate(['/home']);
        },
        error: (err) => {
          console.log('Login failed', err);
          alert('Invalid email or password');
        },
      });
    } else {
      this.loginForm.markAllAsTouched();
    }
  }
}
