import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  constructor() {}

  successNotification() {
    Swal.fire('Hi!', 'Booking succesfully saved', 'success');
  }

  errorNotification(message: string) {
    Swal.fire('', message, 'error');
  }
}
