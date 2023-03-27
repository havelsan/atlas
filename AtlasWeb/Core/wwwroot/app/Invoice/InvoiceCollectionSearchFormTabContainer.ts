import { Component, OnDestroy } from '@angular/core';
import { ITabPanel } from 'Fw/Components/HvlTabPanel';
import { GetMedulaDefinitionService } from './GetMedulaDefinitionService';
import { Subject } from 'rxjs';
import { Subscription } from 'rxjs';

@Component({
    selector: "invoice-collection-search-form-tab-container",
    templateUrl: './InvoiceCollectionSearchFormTabContainer.html',
    //providers: [GetMedulaDefinitionService]
})
export class InvoiceCollectionSearchFormTabContainer implements OnDestroy {
     InvoiceCollectionSearchFormContainerTabs: Array<ITabPanel> = [{
        ModulePath: 'wwwroot/app/Invoice/InvoiceModule',
        ComponentPath: 'wwwroot/app/Invoice/InvoiceCollectionSearchForm',
        RouteData: { IsTab: true },
        Title: "İcmal Ekranı",
        Active: true
    }];
    private tabMessageSubscription: Subscription;

    constructor(private medulaService: GetMedulaDefinitionService) {
        let that = this;
        this.medulaService.tabMessage = new Subject<any>();
        this.tabMessageSubscription = this.medulaService.tabMessage.subscribe(t => {
            that.InvoiceCollectionSearchFormContainerTabs.push({
                ModulePath: 'wwwroot/app/Invoice/InvoiceModule',
                ComponentPath: 'wwwroot/app/Invoice/InvoiceSEPForm',
                RouteData: t.Params,
                Title: t.Title,
                Active: true
            });
        });
    }

    ngOnDestroy() {
        if ( this.tabMessageSubscription != null ) {
            this.tabMessageSubscription.unsubscribe();
            this.tabMessageSubscription = null;
        }
    }
}