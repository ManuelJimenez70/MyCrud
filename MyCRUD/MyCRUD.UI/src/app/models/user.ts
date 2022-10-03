import { DatePipe, DATE_PIPE_DEFAULT_TIMEZONE } from "@angular/common";

export class User{
    id?: number;
    firstName = "";
    lastName = "";
    docType = '';
    docNum = "";    
    estate = '';
    startDate = new Date();
}