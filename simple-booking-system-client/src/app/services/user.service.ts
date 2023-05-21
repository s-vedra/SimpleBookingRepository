import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/user.model';
import { Observable } from 'rxjs';
import { bookingResourceUrl } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}

  getUsers(userId: number): Observable<User> {
    return this.http.get<User>(
      bookingResourceUrl.baseUrl +
        bookingResourceUrl.userCont +
        'user/' +
        userId
    );
  }
}
