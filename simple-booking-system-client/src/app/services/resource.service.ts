import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Resource } from '../models/resource.model';
import { bookingResourceUrl } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ResourceService {
  constructor(private http: HttpClient) {}

  getResources(): Observable<Array<Resource>> {
    return this.http.get<Array<Resource>>(
      bookingResourceUrl.baseUrl +
        bookingResourceUrl.resourceCont +
        'resource-list'
    );
  }
}
