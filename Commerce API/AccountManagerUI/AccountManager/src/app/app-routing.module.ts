import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountComponent } from './account/account.component'
import { CreateAccountComponent } from './create-account/create-account.component';

const routes: Routes = [
  { path: "See Table", component: AccountComponent },
  { path: "Create Account", component: CreateAccountComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
