// @Component({
//   selector: 'app-login',
//   standalone: true,
//   imports: [],
//   templateUrl: './login.component.html',
//   styleUrl: './login.component.css',
// })
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  emailAddress = '';
  password = '';

  constructor(private authService: AuthService, private router: Router) {}

  login() {
    this.authService
      .login({ emailAddress: this.emailAddress, password: this.password })
      .subscribe(
        (res) => {
          if (res.userType === 'Admin') {
            this.router.navigate(['/dashboard']);
          } else if (res.userType === 'User') {
            this.router.navigate(['/home']);
          }
        },
        (err) => {
          alert('Login failed');
        }
      );
  }
}
