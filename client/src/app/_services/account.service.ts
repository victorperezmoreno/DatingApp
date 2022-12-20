import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators'
import { BehaviorSubject } from 'rxjs';
import { User } from '../_models/user';
//Service class is injectable, is a singleton, meaning is instantiated when
//app starts and it is destroyed when user close the browser or it is shutdown
//Service class iss a good place to save any kind of state of our app
//Component however is destroyed when is no longer in use
@Injectable({
  providedIn: 'root'
})
export class AccountService { //This is like a service class in c#
  baseUrl = 'https://localhost:5001/api/';
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable(); 
  constructor(private http: HttpClient) { }
  // this is a method
  login(model: any)
  {
    return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    )
  }

  register(model: any) {
    return this.http.post<User>(this.baseUrl + 'account/register', model).pipe(
      map(user => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    )
  }

  setCurrentUser(user:User){
    this.currentUserSource.next(user);
  }

  logOut() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }

}
