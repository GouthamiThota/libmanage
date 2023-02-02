import { newbook } from '../../models/newbook';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { BooksService } from 'src/app/services/books.service';

@Component({
  selector: 'libMgmnt-add-books',
  templateUrl: './add-books.component.html',
  styleUrls: ['./add-books.component.scss'],
})
export class AddBooksComponent implements OnInit {
  book = new newbook();
  constructor(private http: HttpClient, private bookService: BooksService) {}
  ngOnInit(): void {}
  public addbook(nbook: NgForm) {
    this.book.id = nbook.value.id;
    this.book.title = nbook.value.title;
    this.book.author = nbook.value.author;
    alert('you are successfully added');

    try {
      this.bookService.postbook(this.book).subscribe();
    } catch (e) {
      console.error(e);
    }
    nbook.reset();
  }
}
