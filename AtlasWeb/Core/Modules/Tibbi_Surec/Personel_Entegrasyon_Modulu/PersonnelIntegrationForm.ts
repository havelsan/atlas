//$70DB5952
import { Component, OnInit } from '@angular/core';
import { PersonnelResultModel, PersonnelIntegrationFormViewModel } from './PersonnelIntegrationFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PersonnelIntegration } from 'NebulaClient/Model/AtlasClientModel';
import { ServiceLocator } from "Fw/Services/ServiceLocator";



@Component({
    selector: 'PersonnelIntegrationForm',
    templateUrl: './PersonnelIntegrationForm.html',
    providers: [MessageService]
})

export class PersonnelIntegrationForm extends TTVisual.TTForm implements OnInit {
    public personnelIntegrationFormViewModel: PersonnelIntegrationFormViewModel = new PersonnelIntegrationFormViewModel();
    public get _PersonnelIntegration(): PersonnelIntegration {
        return this._TTObject as PersonnelIntegration;
    }
    private PersonnelIntegrationForm_DocumentUrl: string = '/api/PersonnelIntegrationService/PersonnelIntegrationForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('PERSONNELINTEGRATION', 'PersonnelIntegrationForm');
        this._DocumentServiceUrl = this.PersonnelIntegrationForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PersonnelIntegration();
        this.personnelIntegrationFormViewModel = new PersonnelIntegrationFormViewModel();
        this._ViewModel = this.personnelIntegrationFormViewModel;
        this.personnelIntegrationFormViewModel._PersonnelIntegration = this._TTObject as PersonnelIntegration;
    }

    protected loadViewModel() {
        let that = this;

        that.personnelIntegrationFormViewModel = this._ViewModel as PersonnelIntegrationFormViewModel;
        that._TTObject = this.personnelIntegrationFormViewModel._PersonnelIntegration;
        if (this.personnelIntegrationFormViewModel == null)
            this.personnelIntegrationFormViewModel = new PersonnelIntegrationFormViewModel();
        if (this.personnelIntegrationFormViewModel._PersonnelIntegration == null)
            this.personnelIntegrationFormViewModel._PersonnelIntegration = new PersonnelIntegration();

        this.loginPersonnel();

    }

    async ngOnInit() {
        //await this.load();
        await this.loginPersonnel();
    }

    public openPersonnelLink(model: any) {

        if (model.ErrorCode == 0) {
            window.open(model.URL, '_blank');
            window.focus();
        } else {
            ServiceLocator.MessageService.showError("HATA KODU : " + model.ErrorCode + " - HATA MESAJI : " + model.ErrorMsg);
        }
    }
    private personnelResultModel: PersonnelResultModel = null;

    async loginPersonnel() {

        try {

            let that = this;
            let body = "";
            let apiUrlForPASearchUrl: string = '/api/PersonnelIntegrationService/PersonnelLogin';
            let personnelResultModel = await this.httpService.post(apiUrlForPASearchUrl, body);
            this.openPersonnelLink(personnelResultModel);
        }
        catch (ex) {
            ServiceLocator.MessageService.showError("HATA KODU : " + ex.Message);
        }

    }
    protected redirectProperties(): void {

    }

    public initFormControls(): void {
        this.Controls = [];

    }

    public async btnOpenPersonnelPanel_Click() {
        await this.loginPersonnel();
    }

}
