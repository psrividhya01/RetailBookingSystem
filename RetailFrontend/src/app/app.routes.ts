import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Login } from './login/login';
import { Register } from './register/register';
import { Dashboard } from './dashboard/dashboard';
import { AuthGuard } from './guards/auth-guard';

export const routes: Routes = [
  { path: 'login', component: Login },
  { path: 'register', component: Register },

  {
    path: 'dashboard',
    loadComponent: () => import('./dashboard/dashboard')
      .then(m => m.Dashboard),
    canActivate: [AuthGuard]
  },

  { path: '', redirectTo: 'login', pathMatch: 'full' }
];

