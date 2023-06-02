import { Component, OnInit } from '@angular/core';
import { Booking } from 'src/app/models/booking.model';
import { BookingService } from 'src/app/services/booking.service';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'app-mybookings',
  templateUrl: './mybookings.component.html',
  styleUrls: ['./mybookings.component.css'],
})
export class MybookingsComponent implements OnInit {
  bookings!: Array<Booking>;
  constructor(
    private bookingService: BookingService,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.bookingService.getMyBookings(1).subscribe({
      next: (bookings) => (this.bookings = bookings),
      error: (message) =>
        this.notificationService.errorNotification(message.error),
    });
  }
}
