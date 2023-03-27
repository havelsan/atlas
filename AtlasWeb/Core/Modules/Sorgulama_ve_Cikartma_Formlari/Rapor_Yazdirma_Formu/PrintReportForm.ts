import { Component } from '@angular/core';
import { ComboListItem } from 'NebulaClient/Visual/ComboListItem';

@Component({
    selector: 'PrintReportForm',
    templateUrl: './PrintReportForm.html',
    providers: []
})

export class PrintReportForm {

    reports: Array<ComboListItem> = new Array<ComboListItem>();
    ReportDefName: string;


    counter: number;
    constructor() {
        this.counter = 0;
        this.reports.push(new ComboListItem('MHRSAppointmentsReport', 'MHRS Randevu Listesi'));
        this.reports.push(new ComboListItem('MHRSAppointmentTimeIsPastReport', 'MHRS Randevu Saati Geçmiş Randevular Listesi'));
    }


    onReportSelectBoxValueChanged(event: any) {
        this.ReportDefName = event.value;
    }
}