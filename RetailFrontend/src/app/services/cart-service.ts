import { Injectable, InjectionToken } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { CartItem } from '../models/user';

export const CART_SERVICE_TOKEN = new InjectionToken<CartService>('CartService');

@Injectable({
  providedIn: 'root',
})
export class CartService {
  private cartItems = new BehaviorSubject<CartItem[]>([]);

  getCart(): Observable<CartItem[]> {
    return this.cartItems.asObservable();
  }

  getCartSnapshot(): CartItem[] {
    return this.cartItems.getValue();
  }

  addItem(item: Omit<CartItem, 'quantity'>): void {
    const currentItems = this.cartItems.getValue();
    const existingItem = currentItems.find((i) => i.id === item.id);
    if (existingItem) {
      this.updateQuantity(item.id, existingItem.quantity + 1);
    } else {
      this.cartItems.next([...currentItems, { ...item, quantity: 1 }]);
    }
  }

  updateQuantity(id: number, quantity: number): void {
    if (quantity <= 0) {
      this.removeItem(id);
      return;
    }
    this.cartItems.next(
      this.cartItems.getValue().map((item) => (item.id === id ? { ...item, quantity } : item)),
    );
  }

  removeItem(id: number): void {
    this.cartItems.next(this.cartItems.getValue().filter((item) => item.id !== id));
  }

  clearCart(): void {
    this.cartItems.next([]);
  }
}
