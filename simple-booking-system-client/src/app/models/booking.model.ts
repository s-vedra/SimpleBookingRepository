export interface Booking {
  id: number;
  dateFrom: Date;
  dateTo: Date;
  bookedQuantity: number;
  resourceId: number;
  userId: number;
  dateRangeId: number;
  resourceName: string;
}
