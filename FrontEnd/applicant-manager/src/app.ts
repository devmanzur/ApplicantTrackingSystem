import { Router, RouterConfiguration } from "aurelia-router";
import {inject, PLATFORM} from 'aurelia-framework';
import { WebAPI } from "web-api";

@inject(WebAPI)
export class App {
  router: Router;

  constructor(public api: WebAPI) {}

  configureRouter(config: RouterConfiguration, router: Router) {
    config.title = "Applicants";
    // config.options.pushState = true;
    // config.options.root = "/";
    config.map([
      {
        route: "",
        moduleId: PLATFORM.moduleName("no-selection"),
        title: "select",
      },
      {
        route: "applicants/:id",
        moduleId: PLATFORM.moduleName("applicant-detail"),
        name: "applicants",
      },
    ]);

    this.router = router;
  }
}
