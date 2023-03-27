//$AFB82E6F
import { Component, ViewChild, OnInit } from '@angular/core';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { TTUnboundForm } from 'NebulaClient/Visual/TTUnboundForm';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { SystemApiService } from 'Fw/Services/SystemApiService';

import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { MainPatientFolderFormViewModel, SubEpisodeData, EpisodeActionData } from './MainPatientFolderFormViewModel';
import { Patient } from 'NebulaClient/Model/AtlasClientModel';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { DxAccordionComponent } from 'devextreme-angular';

@Component({
    selector: 'MainPatientFolderForm',
    templateUrl: './MainPatientFolderForm.html',
    providers: [MessageService, SystemApiService]
})

export class MainPatientFolderForm extends TTUnboundForm implements OnInit {
    public IsButtonActive: boolean = false;

    SubEpisodeListColumns = [
        {
            caption: i18n("M10496", "Açılış Tarihi"),
            dataField: 'OpeningDate',
            allowEditing: false,
            allowSorting: false,
            fixed: true,
            width: 100
        },
        {
            caption: i18n("M20566", "Protokol No"),
            dataField: 'ProtocolNo',
            allowEditing: false,
            allowSorting: false,
            fixed: true,
            width: 85
        },
        {
            caption: i18n("M23870", "Uzmanlık Dalı"),
            dataField: 'SpecialityName',
            allowEditing: false,
            allowSorting: false,
            fixed: true,
            width: 150
        },
        {
            caption: 'Doktor',
            dataField: 'DoctorName',
            allowEditing: false,
            allowSorting: false,
            fixed: true,
            width: 150
        },
        {
            caption: 'Durum',
            dataField: 'PatientStatus',
            allowEditing: false,
            allowSorting: false,
            fixed: true,
            width: 80
        },
        {
            caption: i18n("M20587", "Provizyon Tipi"),
            dataField: 'AdmissionType',
            allowEditing: false,
            allowSorting: false,
            fixed: true,
            width: 120
        },

        {
            caption: i18n("M17250", "Kapanış Tarihi"),
            dataField: 'ClosingDate',
            allowEditing: false,
            allowSorting: false,
            fixed: true,
            width: 100
        }
    ];

    EpisodeActionListColumns = [
        {
            caption: i18n("M16886", "İşlem Tarihi"),
            dataField: 'ActionDate',
            allowEditing: false,
            allowSorting: false,
            fixed: true,
            width: 100
        }, {
            caption: i18n("M16821", "İşlem Adı"),
            dataField: 'ObjectName',
            allowEditing: false,
            allowSorting: false,
            fixed: true,
            width: 120
        },
        {
            caption: 'Durum',
            dataField: 'State',
            allowEditing: false,
            allowSorting: false,
            fixed: true,
            width: 100
        }, {
            caption: i18n("M15559", "Havale Eden"),
            dataField: 'FromResourceName',
            allowEditing: false,
            allowSorting: false,
            fixed: true,
            width: 150
        }, {
            caption: i18n("M15564", "Havale Edilen"),
            dataField: 'MasterResourceName',
            allowEditing: false,
            allowSorting: false,
            fixed: true,
            width: 150
        },
        {
            caption: 'Doktor',
            dataField: 'DoctorName',
            allowEditing: false,
            allowSorting: false,
            fixed: true,
            width: 150
        },
        {
            caption: i18n("M10469", "Açıklama"),
            dataField: 'Description',
            allowEditing: false,
            allowSorting: false,
            fixed: true,
            width: 300
        }
    ];

    public selectedEpisodeActionData: EpisodeActionData;

    public mainPatientFolderFormViewModel: MainPatientFolderFormViewModel = new MainPatientFolderFormViewModel();
    public _protocolNo: string = "";

    private MainPatientFolderForm_DocumentUrl: string = '/api/MainPatientFolderService/MainPatientFolderForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, public systemApiService: SystemApiService) {
        super('MAINPATIENTFOLDER', 'MainPatientFolderForm');
        this.initViewModel();

    }

    public initViewModel(): void {
        this.mainPatientFolderFormViewModel = new MainPatientFolderFormViewModel();
        this._protocolNo = "";
    }
    async ngOnInit() {


    }


    GetSubEpisodes(patientID: Guid) {

        let fullApiUrl: string = "api/MainPatientFolderService/GetSubEpisodes?PatientID=" + patientID;

        let that = this;
        this.httpService.get<Array<SubEpisodeData>>(fullApiUrl)
            .then(response => {
                let result = response;
                this.mainPatientFolderFormViewModel.SubEpisodeList = result as Array<SubEpisodeData>;

            })
            .catch(error => {
                console.log(error);
            });


    }

    onSelectionChangedSubEpisodeList(event: any): void {
        this.IsButtonActive = false;
        //episodeactionlar dolduralacak
        if (event != null && event.selectedRowsData.length != 0) {
            this.GetEpisodeActions(event.selectedRowsData[0].ObjectID);
        } else {
            this.mainPatientFolderFormViewModel.EpisodeActionList = null;
            this.selectedEpisodeActionData = null;
        }
        this.showEpisodeAction = false;
    }

    onSelectionChangedEpisodeActionList(event: any) {
        this.IsButtonActive = false;
        //işlem sayfası açılacak
        if (event != null && event.selectedRowsData.length != 0) {
            this.loadPanelOperation(true, 'İşlem Açılıyor, lütfen bekleyiniz.');
            this.showEpisodeAction = true;

            this.selectedEpisodeActionData = event.selectedRowsData[0];
            if (this.selectedEpisodeActionData.IsOldAction != true) {
                this.IsButtonActive = true;
            }
            this.httpService.episodeActionDisplayFormSharedService.openEpisodeActionDynamicComponent(event.selectedRowsData[0].ObjectDefName, event.selectedRowsData[0].ObjectID, null, null);
            this.close_searchAndListAccordion();
            this.loadPanelOperation(false, '');
        } else {
            this.showEpisodeAction = false;
        }
    }

    GetEpisodeActions(subEpisodeID: Guid) {

        this.loadPanelOperation(true, 'İşlem Açılıyor, lütfen bekleyiniz.');
        let fullApiUrl: string = "api/MainPatientFolderService/GetEpisodeActionsandSubActionFlowables?SubEpisodeID=" + subEpisodeID;

        let that = this;
        this.httpService.get<Array<EpisodeActionData>>(fullApiUrl)
            .then(response => {
                let result = response;
                this.mainPatientFolderFormViewModel.EpisodeActionList = result as Array<EpisodeActionData>;

                this.loadPanelOperation(false, '');
            })
            .catch(error => {
                this.loadPanelOperation(false, '');
                console.log(error);
            });


    }

    patientChanged(patient: Patient) {

        let that = this;
        this.GetSubEpisodes(patient.ObjectID);
        this.IsButtonActive = false;
    }

    patientAdmissionChanged(patientAdmission: any) {
        alert(1);
        this.IsButtonActive = false;
    }

    private detailSearchIconClassCollapse = 0;
    public detailSearchIconClassProperties(): string {
        if (this.detailSearchIconClassCollapse == 0)
            return "fa fa-2x fa-angle-down";
        else
            return "fa fa-2x fa-angle-up";
    }

    public detailSearchCollapse_Click(): void {

        if (this.detailSearchIconClassCollapse == 0)
            this.detailSearchIconClassCollapse = 1;
        else
            this.detailSearchIconClassCollapse = 0;
    }

    public async Cancel_SelectedEpisodeAction() {
        if (this.selectedEpisodeActionData != null) {
            let massage: string = this.selectedEpisodeActionData.ActionDate.toString() + i18n("M22853", " tarihli ") + this.selectedEpisodeActionData.ObjectName + i18n("M16911", " işlemi ");
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), i18n("M16855", "İşlem İptali"),
                massage + i18n("M16538", "İPTAL edilecektir.Devam etmek istediğinize emin misiniz? "));
            if (result === 'V') {
                ServiceLocator.MessageService.showSuccess(i18n("M16556", "İptal İşleminden Vazgeçildi"));
            }
            else {
                let that = this;
                let _DocumentServiceUrl: string = "/api/MainPatientFolderService/CancelEpisodeActionOrSPFlowableByObjectId?ObjectId=" + this.selectedEpisodeActionData.ObjectID.toString();
                this.httpService.get<Array<EpisodeActionData>>(_DocumentServiceUrl)
                    .then(result => {
                        that.mainPatientFolderFormViewModel.EpisodeActionList = result as Array<EpisodeActionData>;
                        ServiceLocator.MessageService.showSuccess(massage + i18n("M16551", "iptal edilmiştir"));
                        that.httpService.episodeActionDisplayFormSharedService.openEpisodeActionDynamicComponent(this.selectedEpisodeActionData.ObjectDefName, this.selectedEpisodeActionData.ObjectID, null, null);
                    }).catch(err => {
                        ServiceLocator.MessageService.showError(massage + i18n("M16539", "iptal edilememiştir.") + err);
                    });


            }
        }
    }
    public async UndoLastTransition_SelectedEpisodeAction() {
        if (this.selectedEpisodeActionData != null) {
            let massage: string = this.selectedEpisodeActionData.ActionDate.toString() + i18n("M22853", " tarihli ") + this.selectedEpisodeActionData.ObjectName + i18n("M16911", " işlemi ");
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'İşlem Geri Alma',
                massage + i18n("M14750", "geri alınacaktır.Devam etmek istediğinize emin misiniz? "));
            if (result === 'V') {
                ServiceLocator.MessageService.showSuccess(i18n("M14753", "Geri Alma İşleminden Vazgeçildi"));
            }
            else {
                let that = this;
                let _DocumentServiceUrl: string = "/api/MainPatientFolderService/UndoLastTransitionEAorSPFlowableByObjectId?ObjectId=" + this.selectedEpisodeActionData.ObjectID.toString();
                this.httpService.get<Array<EpisodeActionData>>(_DocumentServiceUrl)
                    .then(result => {
                        that.mainPatientFolderFormViewModel.EpisodeActionList = result as Array<EpisodeActionData>;
                        ServiceLocator.MessageService.showSuccess(massage + i18n("M14752", "geri alınmıştır"));
                        that.httpService.episodeActionDisplayFormSharedService.openEpisodeActionDynamicComponent(this.selectedEpisodeActionData.ObjectDefName, this.selectedEpisodeActionData.ObjectID, null, null);
                    }).catch(err => {
                        ServiceLocator.MessageService.showError(massage + i18n("M14751", "geri alınamamıştır.") + err);
                    });
            }
        }
    }

    public showEpisodeAction = false;
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    @ViewChild('searchAccordion') searchAndListAccordion: DxAccordionComponent;
    open_searchAndListAccordion() {
        if (this.searchAndListAccordion)
            this.searchAndListAccordion.selectedIndex = 0;
    }
    close_searchAndListAccordion() {
        if (this.searchAndListAccordion)
            this.searchAndListAccordion.selectedIndex = -1;
    }


    onProtocolNoEnterKeyDown(e) {
        let fullApiUrl: string = "api/MainPatientFolderService/GetSubEpisodeByProtocolNo?ProtocolNo=" + this._protocolNo;

        let that = this;
        this.httpService.get<Array<SubEpisodeData>>(fullApiUrl)
            .then(response => {
                let result = response;

                if (result.length == 0)
                    ServiceLocator.MessageService.showError("Kabul Bulunamadı.");
                else
                    this.mainPatientFolderFormViewModel.SubEpisodeList = result as Array<SubEpisodeData>;

            })
            .catch(error => {
                console.log(error);
            });
    }
}