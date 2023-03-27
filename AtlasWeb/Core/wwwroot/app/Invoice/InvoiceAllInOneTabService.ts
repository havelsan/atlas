import { Injectable } from "@angular/core";
import { Subject } from "rxjs";

@Injectable()
export class InvoiceAllInOneTabService {
    tabMessage: Subject<any> = new Subject<any>();
    invoiceSepFormComm: Subject<any> = new Subject<any>();
}