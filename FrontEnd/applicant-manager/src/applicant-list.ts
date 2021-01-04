import {WebAPI} from './web-api';
import {inject} from 'aurelia-framework';

@inject(WebAPI)
  export class ApplicantList {
    applicants;
    selectedId = 0;
  
    constructor(private api: WebAPI) { }
  
    created() {
      this.api.getApplicantList().then(applicants => this.applicants = applicants);
    }
  
    select(applicant) {
      this.selectedId = applicant.id;
      return true;
    }
  }
  

  