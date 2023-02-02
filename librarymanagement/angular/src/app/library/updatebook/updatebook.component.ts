import { Component, ElementRef, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { newbook } from '../../models/newbook';
import { HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'libMgmnt-updatebook',
  templateUrl: './updatebook.component.html',
  styleUrls: ['./updatebook.component.scss'],
})
export class UpdatebookComponent implements OnInit {
  public bookobj: any;
  public book: any;
  constructor(private http: HttpClient, private Ele: ElementRef, private router:Router) {
    this.bookobj = new newbook();
    this.book = new newbook();
    
  }
  ngOnInit(): void {}
  public toggle: boolean = false;
  search(id: string) {
    this.toggle = true;
    this.http.get('http://localhost:5046/books/' + id).subscribe({
      next: (response) => {
        this.book = response;
        this.bookobj = response;
      },
      error: () => console.log(Error),
      complete: () => console.log('Completed'),
    });
    this.bookobj = this.book;
  }
  public updatebook(nbook: NgForm) {
    this.bookobj.Id = nbook.value.Id;
    this.bookobj.title = nbook.value.title;
            alert('you are successfully updated');
            this.router.navigate(['path: "library/books", component: BooksComponent,']);

    try {
      this.http
        .put(
          `http://localhost:5046/books/update?id=${this.bookobj.id}`,
          this.bookobj
        )
        .subscribe();
    } catch (e) {
      console.error(e);
    }
  }
}
