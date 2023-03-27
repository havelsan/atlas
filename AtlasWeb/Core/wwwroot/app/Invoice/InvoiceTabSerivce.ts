import { Injectable } from "@angular/core";
import { Subject } from "rxjs";

@Injectable()
export class InvoiceTabSerivce {
    tabMessage: Subject<any> = new Subject<any>();
}