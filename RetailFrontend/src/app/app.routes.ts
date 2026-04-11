import { Routes } from '@angular/router';
import { Login } from './login/login';
import { Register } from './register/register';
import { AuthGuard } from './guards/auth-guard';

export const routes: Routes = [
  { path: 'login', component: Login },
  { path: 'register', component: Register },

  {
    path: 'home',
    loadComponent: () => import('./dashboard/dashboard').then((m) => m.Dashboard),
    canActivate: [AuthGuard],
  },
  {
    path: 'menu',
    loadComponent: () => import('./menu/menu').then((m) => m.Menu),
    canActivate: [AuthGuard],
  },
  {
    path: 'cart',
    loadComponent: () => import('./cart/cart').then((m) => m.CartComponent),
    canActivate: [AuthGuard],
  },

  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: '**', redirectTo: 'login' },
];
