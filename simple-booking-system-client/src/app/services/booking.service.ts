import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Booking } from '../models/booking.model';
import { Observable } from 'rxjs';
import { bookingResourceUrl } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class BookingService {
  constructor(private http: HttpClient) {}

  saveBooking(booking: Booking): Observable<any> {
    return this.http.post(
      bookingResourceUrl.baseUrl +
        bookingResourceUrl.bookingCont +
        'book-resource',
      booking
    );
  }
}
