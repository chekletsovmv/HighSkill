export interface Course {
  id: number;
  title: string;
  description: string;
  price: number;
  durationInHours: number;
  createdAt: string;
  updatedAt?: string;
  isActive: boolean;
}