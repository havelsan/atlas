//$5424B3CD
import { Component } from '@angular/core';
import {Http } from '@angular/http';
import {BaseComponent} from 'Fw/Components/BaseComponent';
import {HcReportModel} from '../Models/HcReportModel';
import {ServiceContainer} from 'Fw/Services/ServiceContainer';

@Component({
    selector: 'hvl-com-hasta-kayit',
    inputs: ['Model'],
    template: `<h1>HcReport</h1>`,
 })
export class HcReportView extends BaseComponent<HcReportModel> {
    enable: boolean;
    demoItems: string[];
//navigator: NavigationService, notifier: NotificationServicenavigator, notifier
    constructor(container: ServiceContainer, private http: Http) {
        super(container);
        this.Model = new HcReportModel();
        this.enable = false;
        this.demoItems = [
            'item1',
            'item2',
            'item3'
        ];
    }
    clientPreScript() {
    }

    clientPostScript(state: String) {

    }
    txtchange() {
        alert(i18n("M23685", "txt değişti"));
        this.enable = false;
    }
    nbrchange() {
        alert(i18n("M19532", "number değişti"));
    }
    mskchnge() {
        alert(i18n("M18685", "Mask değişti"));
    }
    datechnge() {
        alert(i18n("M12498", "date değişti"));
    }
    chkchange() {
        alert(i18n("M12220", "chk değişti"));
    }
    switchchange() {
        alert(i18n("M22430", "switch değişti"));
    }
    richchange() {
        alert(i18n("M21044", "rich değişti"));
    }
    rdchange() {
        alert('rd değişti');
    }
    IlChange(Id: any) {
    }

}