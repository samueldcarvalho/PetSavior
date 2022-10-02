import { User } from './user.model';

export interface LoginUser {
  token: string;
  user: User;
}
