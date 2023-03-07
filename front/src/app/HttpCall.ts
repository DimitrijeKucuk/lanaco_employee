import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class HttpCall {

  readonly APIUrl="http://localhost:5142/api/";

  constructor(private http:HttpClient) { }

  get(path:string):Observable<any>{
    return this.http.get<any>(this.APIUrl + path);
  }

  post(path:string, val:any){
    return this.http.post(this.APIUrl+path,val);
  }

  put(path:string, val:any){
    return this.http.put(this.APIUrl+path,val);
  }

}
