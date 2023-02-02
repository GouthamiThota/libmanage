import { PaginatedResult } from '../library/pagination';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of,  Observable } from 'rxjs';
import {map,take} from'rxjs/operators';
import { newbook } from '../models/newbook';

@Injectable({
  providedIn: 'root'
})
export class BooksService {
  
  paginatedResult:PaginatedResult<newbook[]>=new PaginatedResult<newbook[]>;

  constructor(private http:HttpClient) {

   }

  getbooks(page?:number,itemsPerPage?:number):Observable<Array<newbook>>{
    let params=new HttpParams();
    if(page && itemsPerPage){
      params=params.append('pageNumber',page);
      params=params.append('pageSize',itemsPerPage);  
    }
    
   return this.http.get<Array<newbook>>('http://localhost:5046/books')
   
  }

  postbook(book:any):any{
    return this.http.post('http://localhost:5046/books',book)
  }

  deletebooks(id:number):Observable<any>{
    return this.http.delete('http://localhost:5046/books/'+id);
  }
  getbypage(pageno:number):Observable<any>{
    return this.http.get('http://localhost:5046/paged/'+pageno);
  }
  searchByTitle(searchkey:string):Observable<Array<newbook>>{
    return this.http.get<Array<newbook>>( 'http://localhost:5046/books/search/'+searchkey);
  }
  searchlib(s: string): Observable<Array<newbook>> {
    return this.http.get<Array<newbook>>( 'http://localhost:5046/books/Search/'+s);
  }
}
