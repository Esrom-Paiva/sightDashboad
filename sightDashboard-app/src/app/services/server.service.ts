import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpHeaderResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs-compat/operators/catchError';
import { Server } from '../shared/server';
import { ServerMessage } from '../shared/server-message';

@Injectable({
  providedIn: 'root'
})
export class ServerService {

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({
      'Content-Type' : 'application/json',
      'Accept' : 'q=0.8;application/json;q=0.9'
    });
    this.options = new HttpHeaderResponse({ headers: this.headers });

  }
  options: HttpHeaderResponse;
  headers: HttpHeaders;
  url = 'http://localhost:50882/api/server';

  getServer(): Observable<Server[]>{
    return this.http.get<Server[]>(this.url).pipe(catchError(this.handleError));
  }
  handleError(error: any){
    const errMsg = (error.message) ? error.message :
      error.status ? `${error.status} - ${error.statusText}` : 'Server error';

    return throwError(new Error(errMsg));
  }

  handleServerMessage(msg: ServerMessage): Observable<any> {
    return this.http.put(`${this.url}/${msg.id}`, msg, this.options);
  }
}
