import { HttpClient, HttpParams } from '@angular/common/http';
import { BooksService } from 'src/app/services/books.service';
import { Injectable } from '@angular/core';
import{Resolve,ActivatedRouteSnapshot,RouterStateSnapshot}from '@angular/router';
import { Observable } from 'rxjs';  
import { newbook } from '../models/newbook';

@Injectable({
  providedIn: 'root'
})
export class BookResolverService implements Resolve<any> {

  constructor(private http:HttpClient,private service:BooksService) {
   }
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return this.service.getbooks();
  }
  getbooks(page?:number,itemsPerPage?:number):Observable<Array<newbook>>{
    let params=new HttpParams();
    if(page && itemsPerPage){
      params=params.append('pageNumber',page);
      params=params.append('pageSize',itemsPerPage);  
    }
   return this.http.get<Array<newbook>>(`http://localhost:5046/paged/${page}`,{params})
  }
}
