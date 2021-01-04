let latency = 200;
let id = 0;

function getId() {
  return ++id;
}

let applicants = [
  {
    id: getId(),
    firstName: "Manzur",
    lastName: "Alahi",
    email: "tolkien@inklings.com",
    phoneNumber: "867-5309",
  },
  {
    id: getId(),
    firstName: "Clive",
    lastName: "Lewis",
    email: "lewis@inklings.com",
    phoneNumber: "867-5309",
  },
  {
    id: getId(),
    firstName: "Owen",
    lastName: "Barfield",
    email: "barfield@inklings.com",
    phoneNumber: "867-5309",
  },
  {
    id: getId(),
    firstName: "Charles",
    lastName: "Williams",
    email: "williams@inklings.com",
    phoneNumber: "867-5309",
  },
  {
    id: getId(),
    firstName: "Roger",
    lastName: "Green",
    email: "green@inklings.com",
    phoneNumber: "867-5309",
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

  getApplicantDetails(id) {
    this.isRequesting = true;
    return new Promise((resolve) => {
      setTimeout(() => {
        let found = applicants.filter((x) => x.id == id)[0];
        resolve(JSON.parse(JSON.stringify(found)));
        this.isRequesting = false;
      }, latency);
    });
  }

  saveApplicant(applicant) {
    this.isRequesting = true;
    return new Promise((resolve) => {
      setTimeout(() => {
        let instance = JSON.parse(JSON.stringify(applicant));
        let found = applicant.filter((x) => x.id == applicant.id)[0];

        if (found) {
          let index = applicant.indexOf(found);
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
