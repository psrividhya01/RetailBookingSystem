import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { MenuItem } from '../models/user';
@Injectable({ providedIn: 'root' })
export class MenuService {
  private apiUrl = 'http://localhost:5001/api';

  constructor(private http: HttpClient) {}

  getMenuItems(): Observable<MenuItem[]> {
    return this.http.get<MenuItem[]>(`${this.apiUrl}/menu`);
  }

  getMenuByCategory(category: string): Observable<MenuItem[]> {
    return this.http.get<MenuItem[]>(`${this.apiUrl}/menu?category=${category}`);
  }

  getMenuItemById(id: number): Observable<MenuItem> {
    return this.http.get<MenuItem>(`${this.apiUrl}/menu/${id}`);
  }
}
