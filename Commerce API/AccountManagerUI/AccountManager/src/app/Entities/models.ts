export class Models {

  Id: string | null;
  first_Name: string | null;
  last_Name: string | null;
  email: string | null;
  passwordHash: string | null; 
  remain_SignedIn: boolean;

  constructor(Id: string | null = null, firstName: string | null = null, passwordHash:string|null=null,
    lastName: string | null = null, Email: string|null, remain_signed_in:boolean=false) {

    this.Id = Id; this.first_Name = firstName; this.last_Name = lastName, this.email = Email;
    this.remain_SignedIn = remain_signed_in; this.passwordHash = passwordHash;

  }
  

}
