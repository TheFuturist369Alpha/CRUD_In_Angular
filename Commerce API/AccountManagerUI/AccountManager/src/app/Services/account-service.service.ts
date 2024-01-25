import { Injectable } from '@angular/core';
import { Models } from '../Entities/models';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const domain: string = "https://localhost:7277/api/v1/Account";
@Injectable({
  providedIn: 'root'
})

export class AccountServiceService {
  accounts: Models[] = [];
  constructor(private httpClient:HttpClient) {
  
  }
  public GetAccounts(): Observable<Models[]>{
    let headers = new HttpHeaders();
    headers = headers.append("Authorization", "Bearer mytoken");
    return this.httpClient.get<Models[]>(`${domain}/Users`, {headers:headers});
  }

  public PostAccount(model: Models): Observable<Models> {
    let headers = new HttpHeaders();
    headers = headers.append("Authorization", "Bearer mytoken");
    return this.httpClient.post<Models>(`${domain}/signIn`, model, { headers: headers });
  }

  public UpdateAccount(model: Models): Observable<string>{
    let headers = new HttpHeaders();
    headers = headers.append("Authorization", "Bearer mytoken");
    return this.httpClient.put<string>(`${domain}/${model.Id}`, model, { headers: headers });

  }
}
