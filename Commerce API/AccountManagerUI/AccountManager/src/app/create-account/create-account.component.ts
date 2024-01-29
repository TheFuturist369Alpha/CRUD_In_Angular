import { Component } from '@angular/core';
import { AccountServiceService } from '../Services/account-service.service';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { Models } from '../Entities/models';
import { Router } from '@angular/router';


@Component({
  selector: 'app-create-account',
  templateUrl: './create-account.component.html',
  styleUrls: ['./create-account.component.css']
})
export class CreateAccountComponent {
  public postAccountForm: FormGroup;
  public isFormSubmitted: boolean = this.service.isSubmitted;
  public constructor(private service: AccountServiceService, private router: Router) {
    this.postAccountForm = new FormGroup({
      first_Name: new FormControl(null, [Validators.required]),
      last_Name: new FormControl(null, [Validators.required]),
      email: new FormControl(null, [Validators.required, Validators.email]),
      passwordHash: new FormControl(null, [Validators.required, Validators.minLength(8)])
    });
  }

  get postAccountControl(): any {
    return [this.postAccountForm.controls['first_Name'], this.postAccountForm.controls['last_Name'],
    this.postAccountForm.controls['email'], this.postAccountForm.controls['passwordHash']];
  }

  public OnSubmit() {
    this.service.PostAccount(this.postAccountForm.value).subscribe({
      next: (response: Models) => {
        this.service.accounts.push(response);
        this.service.AddToTable(new FormGroup({
          first_Name: new FormControl(response.first_Name, [Validators.required]),
          last_Name: new FormControl(response.last_Name, [Validators.required]),
          email: new FormControl(response.email, [Validators.required, Validators.email]),
          passwordHash: new FormControl(response.passwordHash, [Validators.required, Validators.minLength(8)])

        }));
        this.postAccountForm.reset();
        this.service.isSubmitted = true;

      },

      error: (error: any) => {

      },
      complete: () => {

      }


    });
    this.router.navigate(['/See Table']);
  }

}
