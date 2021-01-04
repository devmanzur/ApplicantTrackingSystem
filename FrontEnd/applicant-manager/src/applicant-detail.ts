import {inject} from 'aurelia-framework';
  import {WebAPI} from './web-api';
  import {areEqual} from './utility';
  
interface Applicant {
    firstName: string;
    lastName: string;
    email: string;
}