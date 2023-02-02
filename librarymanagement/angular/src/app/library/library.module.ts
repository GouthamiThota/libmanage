import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LibraryComponent } from './library/library.component';
import { BooksComponent } from './books/books.component';
import { AddBooksComponent } from './add-books/add-books.component';
import { AppRoutingModule } from '../app-routing.module';
import { FormsModule } from '@angular/forms';
import { UpdatebookComponent } from './updatebook/updatebook.component';
import { NgxPaginationModule } from 'ngx-pagination';

@NgModule({
  declarations: [
    LibraryComponent,
    BooksComponent,
    AddBooksComponent,
    UpdatebookComponent,
  ],
  imports: [CommonModule, AppRoutingModule, FormsModule, NgxPaginationModule],
})
export class LibraryModule {}
