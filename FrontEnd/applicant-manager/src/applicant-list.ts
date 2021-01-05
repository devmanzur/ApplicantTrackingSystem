import {WebAPI} from './web-api';
import {inject} from 'aurelia-framework';
import {EventAggregator} from 'aurelia-event-aggregator';

@inject(WebAPI, EventAggregator)
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
  

  