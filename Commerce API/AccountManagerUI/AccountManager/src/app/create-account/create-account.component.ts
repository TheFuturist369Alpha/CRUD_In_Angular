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
  public isFormSubmitted: boolean =false;
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

  public onInit() {
    this.postAccountForm.reset();
    this.isFormSubmitted = false;
  }

  public OnSubmit() {
    this.service.PostAccount(this.postAccountForm.value).subscribe({
      next: (response: Models) => {
        

        this.isFormSubmitted = true;

      },

      error: (error: any) => {

      },
      complete: () => {

      }


    });

  
    this.router.navigate(['/See Table']);
  }

}
