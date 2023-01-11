import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model : any = {};
  //currentUser$: Observable<User | null> = of (null);
  constructor(public accountService: AccountService, private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    //this.currentUser$ = this.accountService.currentUser$;
  }

  login() {
   this.accountService.login(this.model).subscribe({
    next: _ => this.router.navigateByUrl('/members'), //Instead of _ we can also use (), means no arguments
   })
  }

  logout() {
    this.accountService.logOut();
    this.router.navigateByUrl('/');
  }

}
