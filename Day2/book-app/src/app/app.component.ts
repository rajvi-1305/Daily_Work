import { NgFor, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { NgModel, FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { BookComponent } from './components/book/book.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NgIf, NgFor, FormsModule, BookComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'Library-App';
  user = 'Rajvi';
}
