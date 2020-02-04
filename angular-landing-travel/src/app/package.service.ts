import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { PackageDTO } from './PackageDTO';
import { PackageItemDTO } from './PackageItemDTO';
import { TravelDTO } from './TravelDTO';

@Injectable({
  providedIn: 'root'
})
export class PackageService {

  getPackages(description: string): Observable<PackageDTO[]>{
    return this.http.get<PackageDTO[]>(this.packageUrl + "/" + description)
    .pipe(catchError(this.handleError<PackageDTO[]>("getPackages")));
  }

  getPackage(id: number): Observable<PackageItemDTO>{
    return this.http.get<PackageItemDTO>(this.packageUrl + "/" + id)
    .pipe(catchError(this.handleError<PackageItemDTO>("getPackage")));
  }

  postTravel(travel: TravelDTO): Observable<number>{
    return this.http.post<number>(this.packageUrl, travel, this.httpOptions)
    .pipe(catchError(this.handleError<number>("postTravel")));
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }

  private packageUrl = "https://localhost:44368/api/salesman";

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }
}
