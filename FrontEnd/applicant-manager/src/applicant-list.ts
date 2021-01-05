import {WebAPI} from './web-api';
import {inject} from 'aurelia-framework';
import {EventAggregator} from 'aurelia-event-aggregator';
import { Applicant } from 'data/applicant';
import { ApplicantViewed } from 'events/applicant-viewed';
import { ApplicantUpdated } from 'events/applicant-updated';

@inject(WebAPI, EventAggregator)
  export class ApplicantList {
    applicants;
    selectedId = 0;
  
    constructor(private api: WebAPI, ea: EventAggregator) {
      ea.subscribe(ApplicantViewed, msg => this.select(msg.applicant));
      ea.subscribe(ApplicantUpdated, msg => {
        let id = msg.applicant.id;
        let found = this.applicants.find(x => x.id == id);
        Object.assign(found, msg.applicant);
      });
     }
  
    created() {
      this.api.getApplicantList().then(applicants => this.applicants = applicants);
    }
  
    select(applicant : Applicant) {
      this.selectedId = applicant.id;
      return true;
    }
  }
  

  