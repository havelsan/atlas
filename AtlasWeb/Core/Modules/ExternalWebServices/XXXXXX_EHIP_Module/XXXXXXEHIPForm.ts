//$7EAAE866
import { Component, OnInit, NgZone } from '@angular/core';
import { XXXXXXEHIPViewModel } from './XXXXXXEHIPViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";

import { ServiceLocator } from "Fw/Services/ServiceLocator";


@Component({
    selector: 'XXXXXXEHIPForm',
    templateUrl: './XXXXXXEHIPForm.html',
    providers: [MessageService]
})
export class XXXXXXEHIPForm extends TTVisual.TTForm implements OnInit {
    public XXXXXXEHIPViewModel: XXXXXXEHIPViewModel = new XXXXXXEHIPViewModel();

    private XXXXXXEHIP_DocumentUrl: string = '/api/XXXXXXEHIPService/XXXXXXEHIP';
    constructor(protected http: NeHttpService,
        protected messageService: MessageService,
        protected ngZone: NgZone) {
        super('XXXXXXEHIP', 'XXXXXXEHIPForm');
        this._DocumentServiceUrl = this.XXXXXXEHIP_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
        this.AskXXXXXXEHIPUrl();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
    }

    protected loadViewModel() {
        let that = this;

        that.XXXXXXEHIPViewModel = this._ViewModel as XXXXXXEHIPViewModel;
        that._TTObject = this.XXXXXXEHIPViewModel._XXXXXXEHIP;
        if (this.XXXXXXEHIPViewModel == null)
            this.XXXXXXEHIPViewModel = new XXXXXXEHIPViewModel();


    }

    async ngOnInit() {
        let that = this;
        await this.load(XXXXXXEHIPViewModel);

    }

    public btnOpenEhipPanel_Click() {
        this.AskXXXXXXEHIPUrl();
    }

    public XXXXXXUrl: string;

    async AskXXXXXXEHIPUrl() {

        try {
            let that = this;

            let body = "";

            let apiUrlForPASearchUrl: string = '/api/XXXXXXEHIPService/XXXXXXEHIPUrl';

            let result = await this.http.post(apiUrlForPASearchUrl, body);

            if (result != null) {
                let MenuID: string = "l4rbRYEb0NOQaB6M6pT1lw==";
                let ProfileID: string = "bqbfoV2QtdOagacAa50rzg==";
                let Url: string = result["XXXXXXUrl"];
                let Tc: string = result["UniqueRefNo"];
                let ehipCode = result["XXXXXXResult"];
                this.XXXXXXUrl = Url + "menuId=" + MenuID + "&profilId=" + ProfileID + "&ehipKey=" + ehipCode["Mesaj"] + "&mkysBirimKayitNo=&tc=" + Tc;
                this.openXXXXXXUrl(this.XXXXXXUrl);
            }
            else {
                ServiceLocator.MessageService.showError("/api/XXXXXXEHIPService/XXXXXXEHIPUrl is broken!");
            }


        }
        catch (ex) {
            ServiceLocator.MessageService.showError("HATA KODU : " + ex.Message);
        }

    }

    public openXXXXXXUrl(url: string) {
        window.open(url, '_blank');
        window.focus();
    }

    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }


}
