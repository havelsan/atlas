import { Component, OnDestroy, AfterViewInit } from '@angular/core';
import { ITabPanel } from 'Fw/Components/HvlTabPanel';
import { GetMedulaDefinitionService } from './GetMedulaDefinitionService';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { Subscription } from 'rxjs';

@Component({
    selector: "invoice-collection-bound-form-tab",
    templateUrl: './InvoiceCollectionBoundFormTab.html',
    providers: [GetMedulaDefinitionService, SystemApiService]
})
export class InvoiceCollectionBoundFormTab extends BaseComponent<any> implements AfterViewInit, OnDestroy {

    InvoiceCollectionTabItems: Array<ITabPanel> = [];
    private tabMessageSubscription: Subscription;
    /*GetMedulaDefinitionService yerine başka bir servis yapılıp kullanılabilir çünkü provider'ı yani service instance ı kendi içerisinde. 
    Bu servis bu formun provider ına verildi çünkü InvoiceModule içerisinde bulunan GetMedulaDefinitionService instance'ı inject edilirse 
    İcmal ve Dönem ekranlarının aynı anda açılıp kullanılmaları sorun teşkil ediyor. */
    constructor(private medulaService: GetMedulaDefinitionService, private services: ServiceContainer, public systemApiService: SystemApiService) {
        super(services);
        let that = this;
        let tabExists = null;
        this.tabMessageSubscription = this.medulaService.tabMessage.subscribe(t => {
            if (that.RouteData !== null)
                tabExists = (<Array<ITabPanel>>that.RouteData.Tabs).find(x => x.RouteData.ObjectID === t.Params.ObjectID);
            if (tabExists === null || tabExists === undefined)
                (<Array<ITabPanel>>that.RouteData.Tabs).push({
                    ModulePath: 'wwwroot/app/Invoice/InvoiceModule',
                    ComponentPath: 'wwwroot/app/Invoice/InvoiceSEPForm',
                    RouteData: t.Params,
                    Title: t.Title,
                    Active: true
                });
        });
    }
    ngAfterViewInit(): void {
        this.systemApiService.open(this.RouteData.ObjectID, "InvoiceCollection");
    }

    clientPostScript(state: String) {

    }

    clientPreScript() {

    }

    ngOnDestory() {
        if (this.tabMessageSubscription != null) {
            this.tabMessageSubscription.unsubscribe();
            this.tabMessageSubscription = null;
        }
        super.ngOnDestroy();
    }

}