import { NgFor, NgIf, NgStyle } from '@angular/common';
import { Component, input, NgModule } from '@angular/core';
import { FormsModule, NgModel } from '@angular/forms';

@Component({
  selector: 'app-book',
  standalone: true,
  imports: [NgIf, NgFor, FormsModule, NgStyle],
  templateUrl: './book.component.html',
  styleUrl: './book.component.css',
})
export class BookComponent {
  inputType = 'text';
  inp = '';
  books: string[] = [];
  show = false;
  addBook() {
    this.books.push(this.inp);
    this.inp = '';
    this.hideList();
  }
  showList() {
    this.show = true;
  }
  hideList() {
    this.show = false;
  }
}
