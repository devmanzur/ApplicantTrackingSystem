export class Applicant {


  constructor() {
    
  }

  // sameAs(other: Applicant) : boolean{
  //   return this.id == other.id
  //   && this.firstName == other.firstName
  //   && this.lastName == other.lastName
  //   && this.email == other.email
  //   && this.address == other.address
  //   && this.countryOfOrigin == other.countryOfOrigin
  //   && this.age == other.age
  //   && this.hired == other.hired;
  // }

  id: number;
  firstName: string;
  lastName: string;
  email: string;
  address: string;
  countryOfOrigin: string;
  age: number;
  hired: boolean;
}
