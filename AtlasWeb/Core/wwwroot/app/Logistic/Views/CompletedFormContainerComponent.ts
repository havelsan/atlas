import { Component, OnInit } from '@angular/core';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";

@Component({
    selector: "CompletedFormContainerComponent",
    template: `
<h1>Taşınır Mal Giriş Tamamlandı Formu</h1>
<div class="row">
    <comp-compose [Info]="componentInfo"></comp-compose>
</div>
`
})
export class CompletedFormContainerComponent implements OnInit {
    public componentInfo: DynamicComponentInfo;

    constructor() {

    }

    ngOnInit(): void {
        let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
        compInfo.ComponentName = "ChattelDocumentInputWithAccountancyCompletedForm";
        compInfo.ModuleName = "TasinirMalIslemModule";
        compInfo.ModulePath = "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/TasinirMalIslemModule";
        compInfo.InputParam = null;
        compInfo.objectID = null; 
        this.componentInfo = compInfo;
    }
}