import { Injectable } from "@angular/core";
import { Subject } from "rxjs";

@Injectable()
export class InvoiceTermFormTabService
{
    tabMessage:Subject<any> = new Subject<any>();
}