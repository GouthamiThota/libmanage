import { newbook } from './../../models/newbook';
import { BooksService } from 'src/app/services/books.service';
import { BookResolverService } from 'src/app/services/book-resolver.service';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgFor } from '@angular/common';

import { Observable } from 'rxjs';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'libMgmnt-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.scss'],
})
export class BooksComponent implements OnInit {
  public books$: any = [];
  TotalItems: number = 0;
  TotalPages: number = 0;
  page: number = 1;
  size: number = 5;
  title = '';
  constructor(private service: BooksService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.books$ = this.route.snapshot.data['data'];
  }

  delete(id: number) {
    console.log('id=', id);
    if (confirm('Do You Want to Delete?')) {
      this.service.deletebooks(id).subscribe((data: any) => {
        console.log('Deleted');
        alert('Book with id= ' + id + ' is deleted');
        this.getByPage(this.page);
      });
    }
  }

  getAllBooks() {
    this.books$ = this.service.getbooks(this.page, 5).subscribe();
    console.log(this.books$);
  }

  onPageChange(event: any) {
    this.page = event;
    this.getByPage(this.page);
  }

  onPageSizeChange(event: any) {
    this.page = event;
    this.getByPage(this.page);
  }

  getByPage(pageNo: any) {
    this.service.getbypage(pageNo).subscribe((res) => {
      this.books$ = res.books;
      this.TotalItems = res.totalItems;
      this.TotalPages = res.totalPages;
    });
  }

  searchTitle() {
    if (this.title.length > 0) {
      this.service.searchByTitle(this.title).subscribe(
        (res) => {
          this.books$ = res;
          console.log(res);
          console.log('working');
        },
        (error) => {
          alert('Not Found any data with this value');
        }
      );
    } else {
      this.getByPage(this.page);
    }
  }
}
