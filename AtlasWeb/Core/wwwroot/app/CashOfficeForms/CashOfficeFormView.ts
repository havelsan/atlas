//$7171AB3B

import { Component, ViewChild, HostListener, OnInit } from '@angular/core';
import { CashOfficeWorkListForm } from '../CashOfficeWorkList/CashOfficeWorkListForm';
import { ComboListItem } from 'NebulaClient/Visual/ComboListItem';
import { IHelpService } from 'Fw/Services/IHelpService';
import { helpFormModuleMap } from 'app/help-data';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { NeHttpService } from 'app/Fw/Services/NeHttpService';

@Component({
    selector: 'cash-office-form',
    templateUrl: './CashOfficeFormView.html',
    providers: []
})

export class CashOfficeFormView implements OnInit {

    //public CurrencyTypes:Array<any>;
    ngOnInit(): void {
        // this.http.get<any>('api/CashOfficeFormViewApi/InitCashOfficeForm').then(res=> 
        //     {
        //         this.CurrencyTypes = res.CurrencyTypes;
        //     });
    }

    reports: Array<ComboListItem> = new Array<ComboListItem>();
    ReportDefName: string;

    @ViewChild('cashOfficeWorkList') WorkList: CashOfficeWorkListForm;
    counter: number;
    constructor(protected http: NeHttpService) {
        this.counter = 0;
        this.reports.push(new ComboListItem('CashOfficeReport', i18n("M24149", "Vezne Raporu")));
        this.reports.push(new ComboListItem('CashOfficeRevenueReport', i18n("M19320", "Mutemetlikler Tahsilat ve Ödeme Defteri")));
        this.reports.push(new ComboListItem('CashOfficeAccountReport', i18n("M19279", "Muhasebe İşlem Fişi")));
    }

    @HostListener('window:keydown.f1', ['$event'])
    onKeyDown(event: KeyboardEvent) {
        const formName = this.constructor.name;
        if (formName && helpFormModuleMap.has(formName) === true) {
            const helpFileName = helpFormModuleMap.get(formName);
            const helpService: IHelpService = ServiceLocator.Injector.get(IHelpService);
            helpService.showHelp(helpFileName);
            return false;
        }
    }
    click(data: any) {
        if (data.addedItems[0].title === i18n("M24144", "Vezne İş Listesi") && this.counter == 0) {
            this.WorkList.Repaint();
            this.counter = 1;
        }
    }

    onReportSelectBoxValueChanged(event: any) {
        this.ReportDefName = event.value;
    }
}