import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { Navbar } from '../navbar/navbar';
import { MenuService } from '../services/menu-service';
import { MenuItem } from '../models/user';

@Component({
  selector: 'app-home',
  imports: [CommonModule, RouterModule, Navbar],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home implements OnInit {
  private menuService = inject(MenuService);
  private router = inject(Router);

  // State Management
  featuredItems = signal<MenuItem[]>([]);
  currentSlide = signal(0);

  // Slideshow Data
  slides = [
    { image: 'assets/pizza-slide.jpg', title: 'Midnight Cravings?', sub: 'Flat 10% Off on all orders after 10 PM' },
    { image: 'assets/mania-slide.jpg', title: 'The Pizza Mania', sub: 'Experience the cripsiest pizza in town' },
    { image: 'assets/drinks-slide.jpg', title: 'Stay Chilled', sub: 'Buy 1 Get 1 Free on all Cold Drinks' }
  ];

  // Static Categories for the Slider
  categories = [
    { name: 'Pizza', icon: '🍕' },
    { name: 'Snacks', icon: '🍟' },
    { name: 'Cold Drinks', icon: '🥤' }
  ];

  ngOnInit(): void {
    // Fetch top-rated items from the backend for the slidable window
    this.menuService.getMenuItems().subscribe({
      next: (items) => {
        const topRated = items.filter(item => item.rating >= 4.5).slice(0, 8);
        this.featuredItems.set(topRated);
      },
      error: (err) => console.error('Failed to load menu items', err)
    });

    // Auto-play slideshow
    setInterval(() => {
      this.currentSlide.set((this.currentSlide() + 1) % this.slides.length);
    }, 5000);
  }

  navigateToCategory(catName: string): void {
    this.router.navigate(['/menu'], { queryParams: { category: catName } });
  }
}