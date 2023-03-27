import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Http } from "@angular/http";

@Injectable()
export class ENabizButtonSharedService {

   private buttonVisible = new Subject<boolean>();
   public buttonVisibleObservable = this.buttonVisible.asObservable();

    constructor(protected http: Http) {

    }

    changeButtonVisible(visible: boolean) {
        this.buttonVisible.next(visible);
    }
}