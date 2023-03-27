import { Component, OnInit } from '@angular/core';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";

@Component({
    selector: "NewFormContainerComponent",
    template: `
<h1>Taşınır Mal Giriş Yeni Formu</h1>
<div class="row">
    <comp-compose [Info]="componentInfo"></comp-compose>
</div>
`
})
export class NewFormContainerComponent implements OnInit {
    public componentInfo: DynamicComponentInfo;

    constructor() {

    }

    ngOnInit(): void {
        let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
        compInfo.ComponentName = "ChattelDocumentInputWithAccountancyNewForm";
        compInfo.ModuleName = "TasinirMalIslemModule";
        compInfo.ModulePath = "Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/TasinirMalIslemModule";
        compInfo.InputParam = null;
        compInfo.objectID = null; 
        this.componentInfo = compInfo;
    }
}