import { inject } from "aurelia-framework";
import { EventAggregator } from "aurelia-event-aggregator";
import { WebAPI } from "./web-api";
import { ApplicantUpdated, ApplicantViewed } from "./events";
import { areEqual } from "./utility";

interface Applicant {
  firstName: string;
  lastName: string;
  email: string;
}

@inject(WebAPI, EventAggregator)
export class ApplicantDetail {
  routeConfig;
  applicant: Applicant;
  originalApplicant: Applicant;

  constructor(private api: WebAPI, private ea: EventAggregator) {}

  activate(params, routeConfig) {
    this.routeConfig = routeConfig;

    return this.api.getApplicantDetails(params.id).then((applicant) => {
      this.applicant = <Applicant>applicant;
      this.routeConfig.navModel.setTitle(this.applicant.firstName);
      this.originalApplicant = JSON.parse(JSON.stringify(this.applicant));
      this.ea.publish(new ApplicantViewed(this.applicant));
    });
  }

  get canSave() {
    return (
      this.applicant.firstName &&
      this.applicant.lastName &&
      !this.api.isRequesting
    );
  }

  save() {
    this.api.saveApplicant(this.applicant).then((applicant) => {
      this.applicant = <Applicant>applicant;
      this.routeConfig.navModel.setTitle(this.applicant.firstName);
      this.originalApplicant = JSON.parse(JSON.stringify(this.applicant));
      this.ea.publish(new ApplicantUpdated(this.applicant));
    });
  }

  canDeactivate() {
    if (!areEqual(this.originalApplicant, this.applicant)) {
      let result = confirm(
        "You have unsaved changes. Are you sure you wish to leave?"
      );

      if (!result) {
        this.ea.publish(new ApplicantViewed(this.applicant));
      }

      return result;
    }
    return true;
  }
}
