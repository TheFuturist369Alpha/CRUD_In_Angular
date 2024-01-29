import { Injectable } from '@angular/core';
import { Models } from '../Entities/models';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { FormArray, FormGroup } from '@angular/forms';


const domain: string = "https://localhost:7277/api/v1/Account";
@Injectable({
  providedIn: 'root'
})

export class AccountServiceService {
  private dataSource: BehaviorSubject<FormGroup | null> = new BehaviorSubject<FormGroup | null>(null);
  public currentData = this.dataSource.asObservable;
  accounts: Models[] = [];
  public isSubmitted: boolean = false;
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
    return this.httpClient.put<string>(`${domain}/${model.modelId}`, model, { headers: headers });

  }

  public DeleteAccount(id:string|null): Observable<boolean> {
    let headers = new HttpHeaders();
    headers = headers.append("Authorization", "Bearer mytoken");
    return this.httpClient.delete<boolean>(`${domain}/${id}`,{ headers: headers });

  }

  public AddToTable(newForm: FormGroup) {
    this.dataSource.next(newForm);
  }

  public Push(forms: FormArray, group: FormGroup) {
    forms.push(group);
  }

}
