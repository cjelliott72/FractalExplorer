import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class FractalService {

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }

  getFractalImage(height: number, width: number, xMin: number, xMax: number, yMin: number, yMax: number, maxIterations: number, colorType: number, fractalName: string): Observable<Blob> {
    return this.http.get<Blob>(this.baseUrl + 'api/fractal/' +
      `?height=${height}&width=${width}&realStart=${xMin}&realEnd=${xMax}&imagStart=${yMin}&imagEnd=${yMax}&maxIterations=${maxIterations}&colorType=${colorType}&fractalName=${fractalName}`)
      .pipe(
        catchError(this.handleError<Blob>('getFractalImage'))
      );
  }

  /*
* Handle Http operation that failed.
* Let the app continue.
* @param operation - name of the operation that failed
* @param result - optional value to return as the observable result
*/
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      console.warn(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
