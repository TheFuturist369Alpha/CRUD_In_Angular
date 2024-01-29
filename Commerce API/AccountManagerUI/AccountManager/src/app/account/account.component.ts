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
      
    });

    this.putAccountForm = new FormGroup({
      Accounts: new FormArray([]),
    
    });
  }
  private  Onload() {
    this.service.GetAccounts().subscribe({
      next: (response: Models[]) => {
        this.service.accounts = response;
        this.accounts = this.service.accounts;
        console.log(this.accounts[0]);
        console.log(this.accounts[1].email);
        console.log((this.accounts[1]).modelId);
        console.log((this.accounts[1]).remain_SignedIn);

          this.accounts.forEach(account => {
            (this.putAccountForm.get("Accounts") as FormArray).push(new FormGroup({
              modelId: new FormControl(account.modelId, [Validators.required]),
              first_Name: new FormControl({ value: account.first_Name, disabled: true }, [Validators.required]),
              last_Name: new FormControl({ value: account.last_Name, disabled: true }, [Validators.required]),
              email: new FormControl({ value: account.email, disabled: true }, [Validators.required]),
              passwordHash: new FormControl({ value: account.passwordHash, disabled: true }, [Validators.required]),
              remain_SignedIn: new FormControl({ value: account.remain_SignedIn, disabled: true }, [Validators.required]),

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




  public onEdit(acc: Models) {
    this.accoutId = acc.modelId;
  }
  public onUpgrade(i: number) {
    this.accoutId = null;
    console.log((this.putAccountForm.get("Accounts") as FormArray).controls[i].value);
    this.service.UpdateAccount((this.putAccountForm.get("Accounts") as FormArray).controls[i].value).subscribe({
      next: (response: string) => {
         
        console.log(this.accoutId);
        (this.putAccountForm.get("Accounts") as FormArray).controls[i].reset((this.putAccountForm.get("Accounts") as FormArray).controls[i].value);
      
      },
      error: (error: any) => {
        console.log(error);
      },
      complete: () => { }

    });
    alert(`${this.accounts[i].first_Name}'s account has been upgraded'`);
   
  }

  

  public onDelete(num: number) {
    this.accoutId = null;
    this.service.DeleteAccount(((this.putAccountForm.get("Accounts") as FormArray).controls[num].value as Models).modelId).subscribe(
      {

        next: (response: boolean) => {
          if (confirm(`Are you sure you want to delete ${this.accounts[num].first_Name} from the database?`)) {
            if (response) {
              console.log("Account deleted successfuly.");
            }
            else {
              console.log("Account not deleted; Something is wrong.");
            }
            (this.putAccountForm.get("Accounts") as FormArray).removeAt(num);
            this.accounts.splice(num, 1);
          }
        },
        error: (error: any)=>{
          console.log(error);
        },
        complete: () => {}
      }
      
      
    )

  }


}
