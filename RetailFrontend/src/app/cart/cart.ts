import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';

import { CartService } from '../services/cart-service';
import { CartItem } from '../models/user';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './cart.html',
  styleUrls: ['./cart.css'],
})
export class CartComponent implements OnInit {
  private cartService = inject(CartService);
  private router = inject(Router);

  cartItems: CartItem[] = [];
  deliveryFee: number = 40;
  taxRate: number = 0.05;
  discountCode: string = '';
  appliedDiscount: number = 0;
  discountError: string = '';
  discountSuccess: string = '';

  private validCoupons: Record<string, number> = {
    SAVE50: 50,
    FIRST100: 100,
    SAVR20: 20,
  };

  ngOnInit(): void {
    this.cartService.getCart().subscribe((items) => {
      this.cartItems = items;
    });
  }

  increase(item: CartItem): void {
    this.cartService.updateQuantity(item.id, item.quantity + 1);
  }

  decrease(item: CartItem): void {
    this.cartService.updateQuantity(item.id, item.quantity - 1);
  }

  remove(item: CartItem): void {
    this.cartService.removeItem(item.id);
    if (this.cartItems.length === 0) this.resetDiscount();
  }

  get subtotal(): number {
    return this.cartItems.reduce((sum, item) => sum + item.price * item.quantity, 0);
  }

  get tax(): number {
    return Math.round(this.subtotal * this.taxRate);
  }

  get total(): number {
    return Math.max(0, this.subtotal + this.deliveryFee + this.tax - this.appliedDiscount);
  }

  get totalItems(): number {
    return this.cartItems.reduce((sum, item) => sum + item.quantity, 0);
  }

  applyDiscount(): void {
    this.discountError = '';
    this.discountSuccess = '';
    const code = this.discountCode.trim().toUpperCase();
    if (!code) {
      this.discountError = 'Please enter a coupon code.';
      return;
    }
    if (this.validCoupons[code]) {
      this.appliedDiscount = this.validCoupons[code];
      this.discountSuccess = `Coupon applied! You save ₹${this.appliedDiscount}`;
    } else {
      this.appliedDiscount = 0;
      this.discountError = 'Invalid coupon code. Try SAVE50 or FIRST100.';
    }
  }

  resetDiscount(): void {
    this.discountCode = '';
    this.appliedDiscount = 0;
    this.discountError = '';
    this.discountSuccess = '';
  }

  placeOrder(): void {
    if (this.cartItems.length === 0) return;
    console.log('Order payload:', {
      items: this.cartItems,
      subtotal: this.subtotal,
      deliveryFee: this.deliveryFee,
      tax: this.tax,
      discount: this.appliedDiscount,
      total: this.total,
      couponCode: this.discountCode.toUpperCase() || null,
    });
    this.cartService.clearCart();
    this.router.navigate(['/home']);
  }
}
