import {Router, RouterConfiguration} from 'aurelia-router';
import {PLATFORM} from 'aurelia-pal';

export class App {
  router: Router;

  configureRouter(config: RouterConfiguration, router: Router){
    config.title = 'Applicants';
    config.options.pushState = true;
    config.options.root = '/';
    config.map([
      { route: '',              moduleId: PLATFORM.moduleName('no-selection'),   title: 'Select' },
      { route: 'applicants/:id',  moduleId: PLATFORM.moduleName('applicant-detail'), name:'applicants' }
    ]);

    this.router = router;
  }
}


