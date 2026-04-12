import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { Auth } from '../services/auth';

@Component({
  standalone: true,
  selector: 'app-profile',
  imports: [CommonModule, FormsModule],
  templateUrl: './profile.html',
  styleUrl: './profile.css',
})
export class Profile {
  protected profile = {
    fullName: 'John Doe',
    email: 'john.doe@example.com',
    phone: '+1 234 567 8900',
    addressName: 'Home',
    addressLine: '123 Main Street',
    city: 'Springfield',
    state: 'IL',
    zip: '62704',
    country: 'USA',
  };

  protected wishlist = [
    { name: 'Classic Margherita Pizza', price: '$12.99' },
    { name: 'Berry Smoothie', price: '$5.49' },
  ];

  protected orderHistory = [
    {
      id: 'A1024',
      date: '2026-04-04',
      status: 'Delivered',
      total: '$34.50',
      items: '1x Veggie Burger, 1x Fries, 1x Lemonade',
    },
    {
      id: 'A1019',
      date: '2026-03-28',
      status: 'Completed',
      total: '$19.20',
      items: '1x Classic Pizza, 1x Garlic Bread',
    },
  ];

  protected savedMessage = '';

  constructor(private auth: Auth, private router: Router) {}

  protected saveProfile(): void {
    this.savedMessage = 'Profile details have been updated successfully.';
    window.setTimeout(() => {
      this.savedMessage = '';
    }, 3000);
  }

  protected logout(): void {
    this.auth.logout();
    this.router.navigate(['/login']);
  }
}
