import { User } from './../models/users/DTOs/user.model';
export class LocalStorageUtils {
  private _userTokenName: string = 'petsavior.user';
  private _tokenName: string = 'petsavior.token';

  public saveLocalStorageUserToken(user: User, token: string){
    this.saveToken(token);
    this.saveUser(user);
  }

  public clearLocalStorageUserToken(){
    localStorage.removeItem(this._tokenName);
    localStorage.removeItem(this._userTokenName);
  }

  public saveToken(token: string) {
    localStorage.setItem(this._tokenName, token);
  }

  public saveUser(user: User) {
    localStorage.setItem(this._userTokenName, JSON.stringify(user));
  }

  public getUser(): User {
    return JSON.parse(localStorage.getItem(this._userTokenName)!) as User;
  }

  public getToken(): string {
    return localStorage.getItem(this._tokenName)!;
  }
}
