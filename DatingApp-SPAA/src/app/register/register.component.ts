import { Component, OnInit, Input, Output } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import { AnonymousSubject } from 'rxjs/internal/Subject';
import { EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  // @Input() valuesFromHome: any;
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  register() {
    this.authService.register(this.model).subscribe(
      () => {
        console.log('Registeration Successful');
      }, error => {
        console.log(error);
      }
    );
  }

  cancel() {
    this.cancelRegister.emit('false');
    console.log('Cancelled');
  }

}
