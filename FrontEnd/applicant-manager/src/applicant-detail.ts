import { ApplicantViewed } from 'events/applicant-viewed';
import { Applicant } from './data/applicant';
import {inject} from 'aurelia-framework';
import {WebAPI} from './web-api';
import {areEqual} from './utility';
import {EventAggregator} from 'aurelia-event-aggregator';
import { ApplicantUpdated } from 'events/applicant-updated';


@inject(WebAPI, EventAggregator)
export class ApplicantDetail{
  routeConfig;
  applicant: Applicant;
  originalApplicant: Applicant;

  constructor(private api: WebAPI, private ea: EventAggregator){}

  activate(params, routeConfig) {
    this.routeConfig = routeConfig;

    return this.api.getApplicantDetails(params.id).then(applicant => {
      this.applicant = <Applicant>applicant;
      this.routeConfig.navModel.setTitle(this.applicant.firstName);
      this.originalApplicant = JSON.parse(JSON.stringify(this.applicant));
      this.ea.publish(new ApplicantViewed(this.applicant));
    });
  }

  get canSave() {
    return this.applicant.firstName && this.applicant.lastName && !this.api.isRequesting;
  }

  save() {
    let result = confirm('Are you sure you want to update this applicant?');
    if(result)
    this.api.saveApplicant(this.applicant).then(applicant => {
      this.applicant = <Applicant>applicant;
      this.routeConfig.navModel.setTitle(this.applicant.firstName);
      this.originalApplicant = JSON.parse(JSON.stringify(this.applicant));
      this.ea.publish(new ApplicantUpdated(this.applicant));
    });
  }

  canDeactivate() {
    // if (!areEqual(this.originalApplicant, this.applicant)) {
    //   let result = confirm('You have unsaved changes. Are you sure you wish to leave?');

    //   if(!result) {
    //     this.ea.publish(new ApplicantViewed(this.applicant));
    //   }

    //   return result;
    // }

    return true;
  }
}
