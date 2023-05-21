import { Component, OnInit, Inject, Input } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Booking } from 'src/app/models/booking.model';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BookingService } from 'src/app/services/booking.service';
import { NotificationService } from 'src/app/services/notification.service';
import { MatDialog } from '@angular/material/dialog';
import { Resource } from 'src/app/models/resource.model';
import { User } from 'src/app/models/user.model';

@Component({
  selector: 'app-booking-component',
  templateUrl: './booking-component.component.html',
  styleUrls: ['./booking-component.component.css'],
})
export class BookingComponentComponent implements OnInit {
  bookingForm!: FormGroup;
  booking!: Booking;
  resource!: Resource;
  user!: User;

  constructor(
    private notificationService: NotificationService,
    @Inject(MAT_DIALOG_DATA) private data: any,
    private bookingService: BookingService,
    public dialog: MatDialog
  ) {
    this.resource = data.resource;
    this.user = data.user;
  }

  ngOnInit(): void {
    this.bookingForm = new FormGroup({
      dateFrom: new FormControl('', [Validators.required]),
      dateTo: new FormControl('', [Validators.required]),
      bookedQuantity: new FormControl('', [Validators.required]),
      resourceId: new FormControl(),
      userId: new FormControl(),
    });
  }

  closeDialog(): void {
    this.dialog.closeAll();
  }
  submitBooking() {
    this.booking = this.bookingForm.value;
    this.booking.resourceId = this.resource.id;
    this.booking.userId = this.user.id;
    this.bookingService.saveBooking(this.booking).subscribe({
      next: () => {
        this.notificationService.successNotification();
      },
      error: (message) => {
        this.notificationService.errorNotification(message.error);
      },
    });
  }
}
