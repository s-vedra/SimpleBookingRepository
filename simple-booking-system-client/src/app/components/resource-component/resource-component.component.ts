import { Component, OnInit } from '@angular/core';
import { Resource } from 'src/app/models/resource.model';
import { ResourceService } from 'src/app/services/resource.service';
import { MatDialog } from '@angular/material/dialog';
import { BookingComponentComponent } from '../booking-component/booking-component.component';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/models/user.model';
import { NotificationService } from 'src/app/services/notification.service';

@Component({
  selector: 'app-resource-component',
  templateUrl: './resource-component.component.html',
  styleUrls: ['./resource-component.component.css'],
})
export class ResourceComponentComponent implements OnInit {
  constructor(
    private resourceService: ResourceService,
    public dialog: MatDialog,
    private userService: UserService,
    private notificationService: NotificationService
  ) {}
  resources!: Array<Resource>;
  user!: User;
  ngOnInit(): void {
    this.resourceService.getResources().subscribe({
      next: (data) => (this.resources = data),
      error: (message) =>
        this.notificationService.errorNotification(message.error),
    });

    this.userService.getUsers(1).subscribe({
      next: (data) => (this.user = data),
      error: (message) =>
        this.notificationService.errorNotification(message.error),
    });
  }

  openDialog(resource: Resource): void {
    this.dialog.open(BookingComponentComponent, {
      height: '400px',
      width: '600px',
      data: {
        resource,
        user: this.user,
      },
    });
  }
}
