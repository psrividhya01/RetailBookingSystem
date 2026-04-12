import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CartService } from '../services/cart-service';
import { MenuItem } from '../models/user';
import { Category } from '../models/user';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './menu.html',
  styleUrls: ['./menu.css'],
})
export class Menu implements OnInit {
  private cartService = inject(CartService);

  categories: Category[] = [
    { name: 'All', imageUrl: 'https://images.unsplash.com/photo-1565299624946-b28f40a0ae38?w=100' },
    {
      name: 'Pizza',
      imageUrl: 'https://images.unsplash.com/photo-1604068549290-dea0e4a305ca?w=100',
    },
    {
      name: 'Burgers',
      imageUrl: 'https://images.unsplash.com/photo-1568901346375-23c9450c58cd?w=100',
    },
    {
      name: 'Cold Drinks',
      imageUrl: 'https://images.unsplash.com/photo-1554866585-cd94860890b7?w=100',
    },
    {
      name: 'Snacks',
      imageUrl: 'https://images.unsplash.com/photo-1573080496219-bb080dd4f877?w=100',
    },
  ];

  menuItems: MenuItem[] = [];
  filteredItems: MenuItem[] = [];
  selectedCategory: string = 'All';
  dietFilter: string = 'all';

  ngOnInit(): void {
    this.menuItems = [
      {
        id: 1,
        name: 'Margherita Pizza',
        price: 249,
        rating: 4.5,
        imageUrl: 'https://images.unsplash.com/photo-1604068549290-dea0e4a305ca?w=400',
        category: 'Pizza',
        isVeg: true,
        description: 'Classic tomato sauce with fresh mozzarella',
      },
      {
        id: 2,
        name: 'Pepperoni Pizza',
        price: 329,
        rating: 4.7,
        imageUrl: 'https://images.unsplash.com/photo-1628840042765-356cda07504e?w=400',
        category: 'Pizza',
        isVeg: false,
        description: 'Loaded with spicy pepperoni slices',
      },
      {
        id: 3,
        name: 'BBQ Chicken Pizza',
        price: 359,
        rating: 4.6,
        imageUrl: 'https://images.unsplash.com/photo-1513104890138-7c749659a591?w=400',
        category: 'Pizza',
        isVeg: false,
        description: 'Smoky BBQ sauce with grilled chicken',
      },
      {
        id: 4,
        name: 'Veggie Delight',
        price: 279,
        rating: 4.3,
        imageUrl: 'https://images.unsplash.com/photo-1574071318508-1cdbab80d002?w=400',
        category: 'Pizza',
        isVeg: true,
        description: 'Fresh garden veggies on herbed base',
      },
      {
        id: 5,
        name: 'Veg Burger',
        price: 149,
        rating: 4.2,
        imageUrl: 'https://images.unsplash.com/photo-1550317138-10000687a72b?w=400',
        category: 'Burgers',
        isVeg: true,
        description: 'Crispy veggie patty with lettuce and sauce',
      },
      {
        id: 6,
        name: 'Chicken Burger',
        price: 199,
        rating: 4.6,
        imageUrl: 'https://images.unsplash.com/photo-1568901346375-23c9450c58cd?w=400',
        category: 'Burgers',
        isVeg: false,
        description: 'Juicy grilled chicken with special mayo',
      },
      {
        id: 7,
        name: 'Zinger Burger',
        price: 229,
        rating: 4.8,
        imageUrl: 'https://images.unsplash.com/photo-1561758033-d89a9ad46330?w=400',
        category: 'Burgers',
        isVeg: false,
        description: 'Spicy crispy chicken fillet burger',
      },
      {
        id: 8,
        name: 'Coca-Cola',
        price: 59,
        rating: 4.4,
        imageUrl: 'https://images.unsplash.com/photo-1554866585-cd94860890b7?w=400',
        category: 'Cold Drinks',
        isVeg: true,
        description: 'Chilled refreshing classic cola',
      },
      {
        id: 9,
        name: 'Mango Juice',
        price: 79,
        rating: 4.6,
        imageUrl: 'https://images.unsplash.com/photo-1546173159-315724a31696?w=400',
        category: 'Cold Drinks',
        isVeg: true,
        description: 'Fresh squeezed Alphonso mango juice',
      },
      {
        id: 10,
        name: 'French Fries',
        price: 99,
        rating: 4.5,
        imageUrl: 'https://images.unsplash.com/photo-1573080496219-bb080dd4f877?w=400',
        category: 'Snacks',
        isVeg: true,
        description: 'Golden crispy salted fries',
      },
      {
        id: 11,
        name: 'Onion Rings',
        price: 89,
        rating: 4.2,
        imageUrl: 'https://images.unsplash.com/photo-1639024471283-03518883512d?w=400',
        category: 'Snacks',
        isVeg: true,
        description: 'Crispy battered onion rings',
      },
      {
        id: 12,
        name: 'Garlic Bread',
        price: 79,
        rating: 4.4,
        imageUrl: 'https://images.unsplash.com/photo-1619531040576-f9416740661e?w=400',
        category: 'Snacks',
        isVeg: true,
        description: 'Toasted bread with herb garlic butter',
      },
    ];
    this.applyFilters();
  }

  filterByCategory(category: string): void {
    this.selectedCategory = category;
    this.applyFilters();
  }

  applyFilters(): void {
    let items = this.menuItems;

    if (this.selectedCategory !== 'All') {
      items = items.filter(
        (item) => item.category.toLowerCase() === this.selectedCategory.toLowerCase(),
      );
    }

    if (this.dietFilter === 'veg') {
      items = items.filter((item) => item.isVeg === true);
    } else if (this.dietFilter === 'nonveg') {
      items = items.filter((item) => item.isVeg === false);
    }

    this.filteredItems = items;
  }

  addToCart(item: MenuItem): void {
    this.cartService.addItem(item);
  }
}
