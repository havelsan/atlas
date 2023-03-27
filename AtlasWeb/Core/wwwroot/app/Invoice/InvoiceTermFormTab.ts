//$23CB8513
import { Component, OnDestroy } from '@angular/core';
import { ITabPanel } from 'Fw/Components/HvlTabPanel';
import { GetMedulaDefinitionService } from './GetMedulaDefinitionService';
import { Subject, Subscription } from 'rxjs';
import { InvoiceTermFormTabService } from './InvoiceTermFormTabService';

@Component({
    selector: "invoice-term-form-tab",
    templateUrl: './InvoiceTermFormTab.html',
    providers: []
})
export class InvoiceTermFormTab implements OnDestroy {
    TermTabItems: Array<ITabPanel> = [{
        ModulePath: 'wwwroot/app/Invoice/InvoiceModule',
        ComponentPath: 'wwwroot/app/Invoice/InvoiceAccountancyForm',
        RouteData: { IsTab: true },
        Title: i18n("M13311", "Saymanlık Ekranı"),
        Active: true
    }, {
        ModulePath: 'wwwroot/app/Invoice/InvoiceModule',
        ComponentPath: 'wwwroot/app/Invoice/InvoiceTermForm',
        RouteData: { IsTab: true },
        Title: i18n("M13311", "Dönem Ekranı"),
        Active: true
    }];
    private tabMessageSubscription: Subscription;

    constructor(private medulaService: InvoiceTermFormTabService) {
        let that = this;
        this.medulaService.tabMessage = new Subject<any>();
        this.tabMessageSubscription = this.medulaService.tabMessage.subscribe(t => {
            that.TermTabItems.push({
                ModulePath: 'wwwroot/app/Invoice/InvoiceModule',
                ComponentPath: 'wwwroot/app/Invoice/InvoiceCollectionTab',
                RouteData: t.Params,
                Title: t.Title,
                Active: true
            });
        });
    }

    ngOnDestroy() {
        if (this.tabMessageSubscription != null) {
            this.tabMessageSubscription.unsubscribe();
            this.tabMessageSubscription = null;
        }
    }

}