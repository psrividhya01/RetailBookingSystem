export interface User {
  id?: number;
  name: string;
  email: string;
  password: string;
  role?: string;
}
export interface MenuItem {
  id: number;
  name: string;
  description?: string;
  price: number;
  rating: number;
  imageUrl: string;
  category: string;
  isVeg: boolean;

  // Optional (for future features)
  isAvailable?: boolean;
  createdAt?: Date;
}
export interface CartItem {
  id: number;
  name: string;
  price: number;
  rating: number;
  imageUrl: string;
  category: string;
  quantity: number; // ← this must be present
}
