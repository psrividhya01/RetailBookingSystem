import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Navbar } from '../navbar/navbar';
import { CartService } from '../services/cart-service';
import { MenuService } from '../services/menu-service';
import { MenuItem, Category } from '../models/user';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [CommonModule, Navbar],
  templateUrl: './menu.html',
  styleUrls: ['./menu.css'],
})
export class Menu implements OnInit {
  private cartService = inject(CartService);
  private menuService = inject(MenuService);

  categories: Category[] = [];
  menuItems: MenuItem[] = [];
  filteredItems: MenuItem[] = [];
  selectedCategory: string = 'All';
  dietFilter: string = 'all';
  isLoading: boolean = true;
  errorMessage: string = '';

  ngOnInit(): void {
    this.loadCategories();
    this.loadMenu();
  }

  loadCategories(): void {
    this.menuService.getCategories().subscribe({
      next: (data) => {
        // prepend All option
        this.categories = [{ id: 0, name: 'All', imageUrl: '' }, ...data];
      },
      error: (err) => {
        console.error('Categories load failed:', err);
      },
    });
  }

  loadMenu(): void {
    this.isLoading = true;
    this.errorMessage = '';

    this.menuService.getMenuItems().subscribe({
      next: (data) => {
        this.menuItems = data;
        this.applyFilters();
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Menu load failed:', err);
        this.errorMessage = 'Failed to load menu. Please try again.';
        this.isLoading = false;
      },
    });
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
