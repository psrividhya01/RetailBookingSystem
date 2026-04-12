import { Routes } from '@angular/router';
import { Login } from './login/login';
import { Register } from './register/register';
import { Home } from './home/home';

export const routes: Routes = [
  { path: 'login', component: Login },
  { path: 'register', component: Register },

  {
    path: 'home',
    loadComponent: () => import('./home/home').then((m) => Home),
  },

  {
    path: 'menu',
    loadComponent: () => import('./menu/menu').then((m) => m.Menu),
  },

  {
    path: 'cart',
    loadComponent: () => import('./cart/cart').then((m) => m.CartComponent),
  },

  {
    path: 'profile',
    loadComponent: () => import('./profile/profile').then((m) => m.Profile),
  },

  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: '**', redirectTo: 'login' },
];
