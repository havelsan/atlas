import { Component, Input, OnDestroy,  OnInit } from "@angular/core";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "app/Fw/Services/NeHttpService";
import { MessageService } from "app/Fw/Services/MessageService";
import { DynamicSidebarMenuItem } from "app/SidebarMenu/Models/DynamicSidebarMenuItem";
import { ISidebarMenuService } from "app/Fw/Services/ISidebarMenuService";
@Component({
    selector: "eDurumBildirirComponent",
    template: `<div class="row">
    <label class="col-sm-3">
    Rapor Yazılma Nedeni
    </label>
    <div class="col-sm-6">
    <dx-select-box [dataSource]="GivingReasonItems" [disabled]="sended"
                        [(value)]="selectedGivingReason" displayExpr="value" style="margin-left:0px;">
                    </dx-select-box>
    </div>
    <div class="col-sm-3">
    <dx-button type="success" (onClick)="CreateReport()"
                        text="Rapor Yaz" ></dx-button>
    </div>
    </div>`,
})
export class EDurumBildirirRaporComponent {


    public GivingReasonItems;
    public selectedGivingReason;
    constructor(private httpService: NeHttpService,
        protected messageService: MessageService,
        private sideBarMenuService: ISidebarMenuService
    ) {
        this.GivingReasonItems = [
            {
                key: "0",
                value: "Genel Durum Değerlendirmesi Kararı"
            },
            {
                key: "1",
                value: "Yivsiz Av Tüfeği Kararı"
            },
            {
                key: "2",
                value: "İş Sağlığı ve Güvenliği Kararı"
            },
            {
                key: "3",
                value: "Akli Meleke Kararı"
            },

        ];
    }

   
    private _episodeActionId: Guid;
    @Input() set episodeActionId(value: Guid) {
        this._episodeActionId = value;
    }
    get episodeActionId(): Guid {
        return this._episodeActionId;
    }

    private _patientId: Guid;
    @Input() set patientId(value: Guid) {
        this._patientId = value;
    }
    get patientId(): Guid {
        return this._patientId;
    }

    public CreateReport() {
        this.createReportWithEpisodeAction(this.episodeActionId);
    }

    

    public OpenEDurumBildirirIndex() {

        let that = this;
        let apiUrl: string = '/api/EReportService/openEDurumBildirirReportIndex';

        that.httpService.get<string>(apiUrl)
            .then(response => {
                let win = window.open(response, '_blank');
                win.focus();
            })
            .catch(error => {
                this.messageService.showError(error);
            });

        
    }
    private createReportWithEpisodeAction(episodeActionId: Guid) {
        let that = this;
        let apiUrl: string = '/api/EReportService/openCreateEDurumBildirirReport?episodeActionId=' + this.episodeActionId;

        that.httpService.get<string>(apiUrl)
            .then(response => {
                let url = response;
                if(response.indexOf("patientId") !== -1){
                    if(that.selectedGivingReason != null){
                        url += "&Reason=" + that.selectedGivingReason.key;
                    }
                }
                let win = window.open(url, '_blank');
                win.focus();
            })
            .catch(error => {
                this.messageService.showError(error);
            });
    }

}