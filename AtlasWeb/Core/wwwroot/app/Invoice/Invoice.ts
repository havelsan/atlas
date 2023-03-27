//$B031EBC6
import { Component, OnDestroy } from '@angular/core';
import { ITabPanel } from 'Fw/Components/HvlTabPanel';
import { GetMedulaDefinitionService } from './GetMedulaDefinitionService';
import { Subscription } from 'rxjs';
import { InvoiceTabSerivce } from './InvoiceTabSerivce';

@Component({
    selector: "invoice-tab",
    templateUrl: './Invoice.html'
})
export class Invoice implements OnDestroy {

    private tabMessageSubscription: Subscription;

    TabItems: Array<ITabPanel> = [{
        ModulePath: 'wwwroot/app/Invoice/InvoiceModule',
        ComponentPath: 'wwwroot/app/Invoice/InvoiceSEPSearchForm',
        RouteData: { IsTab: true },
        Title: i18n("M22126", "Sorgulama"),
        Active: true,
    }];

    constructor(private invoiceTabService: InvoiceTabSerivce) {
        let that = this;
        this.tabMessageSubscription = this.invoiceTabService.tabMessage.subscribe(t => {
            that.TabItems.push({
                ModulePath: 'wwwroot/app/Invoice/InvoiceModule',
                ComponentPath: 'wwwroot/app/Invoice/InvoiceSEPForm',
                RouteData: t.Params,
                Title: t.Title,
                Active: true
            });
        });
    }

    ngOnDestroy() {
        if ( this.tabMessageSubscription != null)  {
            this.tabMessageSubscription.unsubscribe();
            this.tabMessageSubscription = null;
        }
    }
}