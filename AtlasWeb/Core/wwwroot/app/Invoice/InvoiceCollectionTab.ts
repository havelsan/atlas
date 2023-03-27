//$5FF491FA
import { Component, AfterViewInit } from '@angular/core';
import { ITabPanel } from 'Fw/Components/HvlTabPanel';
import { GetMedulaDefinitionService } from './GetMedulaDefinitionService';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { Subscription } from 'rxjs';

@Component({
    selector: "invoice-collection-tab",
    templateUrl: './InvoiceCollectionTab.html',
    providers: [GetMedulaDefinitionService, SystemApiService]
})
export class InvoiceCollectionTab extends BaseComponent<any> implements AfterViewInit {

    InvoiceCollectionTabItems: Array<ITabPanel> = [];
    private tabMessageSubscription: Subscription;
    /*Bu component dönem içerisinde icmalin ve faturanın açılabilmesi için yapılmıştır. Burası kendi içerisinde yeni bir service instance ına ihtiyaç duyuyor
    çünkü InvoiceModule içerisindeki service instance'ı inject edilirse dönem ve icmal ekranlarının aynı anda açılması sorun yaratıyor.
    Örneğin dönem ekranı içerisinden icmal açılıp ardından fatura açılırsa, ve İcmal ekranı da açık ise inject edilen servisleri aynı olduğu için
    açılan faturayı İcmal ekranına da açmaya çalışıp hata alıyor. */
    constructor(private medulaService: GetMedulaDefinitionService, private services: ServiceContainer, private systemApiService: SystemApiService) {
        super(services);
        let that = this;
        this.tabMessageSubscription = this.medulaService.tabMessage.subscribe(t => {
            that.InvoiceCollectionTabItems.push({
                ModulePath: 'wwwroot/app/Invoice/InvoiceModule',
                ComponentPath: 'wwwroot/app/Invoice/InvoiceCollectionBoundFormTab',
                RouteData: t.Params,
                Title: t.Title,
                Active: true
            });
        });
    }
    ngAfterViewInit(): void {
        this.RouteData.Tabs = this.InvoiceCollectionTabItems;
        this.medulaService.tabMessage.next({ Params: this.RouteData, Title: i18n("M16121", "İcmal") });
    }

    clientPostScript(state: String) {

    }

    clientPreScript() {

    }

    ngOnDestroy() {
        if (this.tabMessageSubscription != null) {
            this.tabMessageSubscription.unsubscribe();
            this.tabMessageSubscription = null;
        }
    }

}