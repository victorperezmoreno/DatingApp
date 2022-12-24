import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'The Dating App';
  // To get data from API we need httpclient
  constructor(private accountService: AccountService) {}
  
  ngOnInit() { 
   this.setCurrentUser(); 
  }

  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user'))
    //If we get any error, we can use the below code, as it is the same as
    //the above
    // const userstring = localStorage.getItem('user');
    // if (!userstring) return;
    // const userTemp : User = JSON.parse(userstring);
    this.accountService.setCurrentUser(user);

  }
}


