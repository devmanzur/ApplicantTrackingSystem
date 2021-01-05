import { Applicant } from "data/applicant";

let latency = 200;
let id = 0;

function getId() {
  return ++id;
}

// public int Age { get; private set; }
// public bool Hired { get; private set; }

let applicants = [
  {
    id: getId(),
    firstName: "Manzur",
    lastName: "Alahi",
    email: "tolkien@inklings.com",
    address: "867-5309",
    countryOfOrigin: "BD",
    age:25,
    hired:true
  },
  {
    id: getId(),
    firstName: "Clive",
    lastName: "Lewis",
    email: "lewis@inklings.com",
    address: "867-5309",
    countryOfOrigin: "BD",
    age:25,
    hired:true
  },
  {
    id: getId(),
    firstName: "Owen",
    lastName: "Barfield",
    email: "barfield@inklings.com",
    address: "867-5309",
    countryOfOrigin: "BD",
    age:25,
    hired:true
  },
  {
    id: getId(),
    firstName: "Charles",
    lastName: "Williams",
    email: "williams@inklings.com",
    address: "867-5309",
    countryOfOrigin: "BD",
    age:25,
    hired:true
  },
  {
    id: getId(),
    firstName: "Roger",
    lastName: "Green",
    email: "green@inklings.com",
    address: "867-5309",
    countryOfOrigin: "BD",
    age:25,
    hired:true
  },
];

export class WebAPI {
  isRequesting = false;

  getApplicantList() {
    this.isRequesting = true;
    return new Promise((resolve) => {
      setTimeout(() => {
        let results = applicants.map((x) => {
          return {
            id: x.id,
            firstName: x.firstName,
            lastName: x.lastName,
            email: x.email,
          };
        });
        resolve(results);
        this.isRequesting = false;
      }, latency);
    });
  }

  getApplicantDetails(id : number) {
    this.isRequesting = true;
    return new Promise((resolve) => {
      setTimeout(() => {
        let found = applicants.filter((x) => x.id == id)[0];
        resolve(JSON.parse(JSON.stringify(found)));
        this.isRequesting = false;
      }, latency);
    });
  }

  saveApplicant(applicant: Applicant) {
    this.isRequesting = true;
    return new Promise((resolve) => {
      setTimeout(() => {
        let instance = JSON.parse(JSON.stringify(applicant));
        let found = applicants.filter((x) => x.id == applicant.id)[0];

        if (found) {
          let index = applicants.indexOf(found);
          applicants[index] = instance;
        } else {
          instance.id = getId();
          applicants.push(instance);
        }

        this.isRequesting = false;
        resolve(instance);
      }, latency);
    });
  }
}
