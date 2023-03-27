import { Component, ViewChild, OnInit, ApplicationRef, NgZone } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';


import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { FormSaveInfo } from 'app/NebulaClient/Mscorlib/FormSaveInfo';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { PatientFolderContentDefFormViewModel, PatientFolderContent } from './PatientFolderContentDefViewModel';
import { patientHasDrugListDTO } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Ilac_Dagilim_Raporu/DrugDistributionReportViewModel';
@Component({
    selector: 'PatientFolderContentDefForm',
    templateUrl: './PatientFolderContentDefForm.html',
    providers: [MessageService]
})
export class PatientFolderContentDefForm extends TTVisual.TTForm implements OnInit {
    FolderContentDefFormViewModel: PatientFolderContentDefFormViewModel = new PatientFolderContentDefFormViewModel();

    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected ngZone: NgZone) {
        super();
        this.initViewModel();
    }
    public FolderName: string = "";
    public FolderCapacity: number;
    public FolderActive: boolean = true;

    public FolderGridColumns = [
        {
            caption: i18n("M19030", "Belgenin Adı"),
            dataField: 'Name',
            dataType: 'string',
            allowEditing: false,
            width: 250,
        },
        {
            caption: i18n("M17462", "Aktif"),
            dataField: 'Active',
            dataType: 'boolean',
            allowEditing: false,
            width: 250
        }
    ];


    public initViewModel(): void {
    }

    protected loadViewModel() {
    }

    async ngOnInit() {
        await this.PatientFolderContentDefForm();
    }

    public async PatientFolderContentDefForm(){
        let that = this;
        let fullApiUrl: string = "/api/PatientFolderContentDefService/LoadFolderContentDefFormViewModel";
        this.httpService.get<PatientFolderContentDefFormViewModel>(fullApiUrl)
            .then(response => {
                that.FolderContentDefFormViewModel = response as PatientFolderContentDefFormViewModel;
                that.FolderDataSource = that.FolderContentDefFormViewModel.FolderList;
            })
            .catch(error => {
                console.log(error);
            });
    }

    public selectedFolder: PatientFolderContent;
    public async onFolderGridRowClick(event) {
        this.selectedFolder = event.data;
        this.FolderName =  event.data.Name;
        this.FolderActive =  event.data.Active;
    }
    FolderDataSource: Array<PatientFolderContent> = new Array<PatientFolderContent>();
    public AddOrUpdateFolder() {

        if (this.FolderName == null) {
            ServiceLocator.MessageService.showError("Belge adı boş bırakılamaz");
            return;
        }
        let that = this;
        let requestString: string = "";
        if (this.selectedFolder == null)
            requestString = "api/PatientFolderContentDefService/SaveOrUpdateFolder?name=" + this.FolderName + "&active=" + this.FolderActive;
        else{
            requestString = "api/PatientFolderContentDefService/SaveOrUpdateFolder?name=" + this.FolderName + "&active=" + this.FolderActive + "&FolderObjectID=" + this.selectedFolder.ObjectID;
        }
        that.httpService.get<Array<PatientFolderContent>>(requestString)
            .then(response => {
                that.FolderDataSource = response;
                this.createNewRecord();
            })
            .catch(error => {
                that.messageService.showError(error);

            });
    }

    public createNewRecord() {
        this.selectedFolder = null;
        this.FolderName = "";
        this.FolderActive = true;
    }

    public deleteRecord(){
        if (this.selectedFolder == null) {
            this.messageService.showInfo('Lütfen silinecek kaydı seçiniz');
            return;
        }

        const confirmResult = confirm('Seçilen kayıt silinecek. Devam etmek istiyor musunuz?');
        if (confirmResult === false) {
            return;
        }

        let requestString = "api/PatientFolderContentDefService/DeleteDefinitionObject?ObjectID=" + this.selectedFolder.ObjectID;
        let that = this;
        that.httpService.get<Array<PatientFolderContent>>(requestString)
        .then(response => {
            that.FolderDataSource = response;
            ServiceLocator.MessageService.showSuccess("Kayıt başarı ile silindi")
            this.createNewRecord();
        })
        .catch(error => {
            that.messageService.showError(error);

        });

    }
}