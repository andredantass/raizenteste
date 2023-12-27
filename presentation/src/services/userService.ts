import { HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable, of, throwError } from "rxjs";
import { UserRequest } from "../model/userRequest";
import { UserResponse } from "../model/userResponse";
import { ApiClient } from "./apiClient";

@Injectable({
  providedIn: 'root'
})
export class UserService
{
  errorMsg: any;
  constructor(private apiClient: ApiClient) {

  }
  deleteUser(id:string) {
    return this.apiClient.delete(`/user/${id}`);
  }
  getAllUsers(): Observable<Array<UserResponse>> {
    return this.apiClient.getAll<Array<UserResponse>>('/user');
  }
  updateUser(request: UserRequest): Observable<any> {
    return this.apiClient.put('/user', request)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          if (error.status === 404) {
            return of(undefined);
          } else {
            return throwError(error);
          }
        })
      );
  }
  registerUser(request: UserRequest): Observable<any> {
    return this.apiClient.post('/user',request)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          if (error.status === 404) {
            return of(undefined);
          } else {
            return throwError(error);
          }
        })
      );
  }
}
