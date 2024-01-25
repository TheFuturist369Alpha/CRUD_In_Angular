import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { Models } from '../Entities/models';
import { AccountServiceService } from '../Services/account-service.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent {

  public accounts: Models[] = [];
  public postAccountForm: FormGroup;
 public putAccountForm: FormGroup;
  public accoutId: string | null=null;
 public  isFormSubmitted: boolean = false;

  constructor(private service: AccountServiceService) {
    this.postAccountForm = new FormGroup({
      first_Name: new FormControl(null, [Validators.required]),
      last_Name: new FormControl(null, [Validators.required]),
      email: new FormControl(null, [Validators.required, Validators.email]),
      passwordHash: new FormControl(null, [Validators.required, Validators.minLength(8)])
    });

    this.putAccountForm = new FormGroup({
      Accounts: new FormArray([]),
    
    });
  }
  private  Onload() {
    this.service.GetAccounts().subscribe({
      next: (response: Models[]) => {
        this.accounts = response;
        console.log(this.accounts[0].ModelId+", "+ this.accounts[0].first_Name);
        this.accounts.forEach(account => {
          (this.putAccountForm.get("Accounts") as FormArray).push(new FormGroup({
            ModelId: new FormControl(account.ModelId, [Validators.required]),
            first_Name: new FormControl(account.first_Name, [Validators.required]),
            last_Name: new FormControl(account.last_Name, [Validators.required]),
            email: new FormControl(account.email, [Validators.required]),
            passwordHash: new FormControl(account.passwordHash, [Validators.required])

          }));
        });
        
        
       
      },
      error: (error: any) => {
        console.log(error);
      },
      complete: () => { }
    }
    );
  }

  ngOnInit() {
    this.Onload();
  }

  get postAccountControl(): any {
    return [ this.postAccountForm.controls['first_Name'],  this.postAccountForm.controls['last_Name'],
       this.postAccountForm.controls['email'],  this.postAccountForm.controls['passwordHash']];
  }


  public onEdit(acc: Models) {
    this.accoutId = acc.ModelId;
  }
  public onUpgrade(acc: Models, i: number) {

  }

  public OnSubmit() {
    this.isFormSubmitted = true;
    console.log(this.postAccountForm.value+" from sunscribe");
    this.service.PostAccount(this.postAccountForm.value).subscribe({
      next: (response: Models) => {
        console.log(response);
        this.accounts.push(new Models(response.ModelId,response.first_Name, response.passwordHash, response.last_Name, response.email, response.remain_SignedIn))
        this.postAccountForm.reset();
        this.isFormSubmitted = false;
      },

      error: (errors: any) => {
        console.log(errors);
      },

      complete: () => { }
    });

    
  }


}
