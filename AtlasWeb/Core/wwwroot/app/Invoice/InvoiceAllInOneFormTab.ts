import { Component } from "@angular/core";
import { GetMedulaDefinitionService } from "./GetMedulaDefinitionService";
import { SystemApiService } from "app/Fw/Services/SystemApiService";
import { ITabPanel } from "app/Fw/Components/HvlTabPanel";
import { Subscription, Subject } from "rxjs";
import { InvoiceAllInOneTabService } from "./InvoiceAllInOneTabService";

@Component({
    selector: "invoice-all-in-form",
    templateUrl: './InvoiceAllInOneFormTab.html',
    providers: [SystemApiService],
})
export class InvoiceAllInOneFormTab {

    private tabMessageSubscription: Subscription;

    InvoiceAllInOneTabItems: Array<ITabPanel> = [{
        ModulePath: 'wwwroot/app/Invoice/InvoiceModule',
        ComponentPath: 'wwwroot/app/Invoice/InvoiceAllInOneForm',
        RouteData: { IsTab: true },
        Title: i18n("M13311", "Ana Ekran"),
        Active: true
    }];

    constructor(private medulaService: InvoiceAllInOneTabService, private systemApiService: SystemApiService) {
        let that = this;
        this.medulaService.tabMessage = new Subject<any>();
        this.tabMessageSubscription = this.medulaService.tabMessage.subscribe(t => {
            if (!that.InvoiceAllInOneTabItems.some(x => x.Key === t.Params.OpeningComponentName)) {
                that.InvoiceAllInOneTabItems.push({
                    ModulePath: 'wwwroot/app/Invoice/InvoiceModule',
                    ComponentPath: 'wwwroot/app/Invoice/' + t.Params.OpeningComponentName,
                    RouteData: t.Params,
                    Title: t.Title,
                    Active: true,
                    Key: t.Params.OpeningComponentName
                });
            }
        });
    }
}