import { UpdatebookComponent } from './library/updatebook/updatebook.component';
import { BooksComponent } from './library/books/books.component';
import { AddBooksComponent } from './library/add-books/add-books.component';
import { LibraryComponent } from './library/library/library.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { BookResolverService } from './services/book-resolver.service';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: "login", component: LoginComponent },
  { path: "about", component: AboutComponent },


  { path: "", component: HomeComponent },
  {
    path: "library", component: LibraryComponent,
    children: [
      { path: "add-books", component: AddBooksComponent },
      {
        path: "books", component: BooksComponent, resolve: {
          data: BookResolverService
        }
      },
      { path: "updatebook", component: UpdatebookComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
