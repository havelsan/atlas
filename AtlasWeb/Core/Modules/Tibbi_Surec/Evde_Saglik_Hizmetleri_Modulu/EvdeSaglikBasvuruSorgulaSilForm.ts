//$A6623433
import { Component, OnInit  } from '@angular/core';
import { EvdeSaglikBasvuruSorgulaSilViewModel, HomeCarePatientsModel } from './EvdeSaglikBasvuruKaydetFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { EvdeSaglikHizmetleri } from 'NebulaClient/Model/AtlasClientModel';
import { IModal, ModalInfo, ModalActionResult } from 'Fw/Models/ModalInfo';

import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { IModalService } from "Fw/Services/IModalService";
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
@Component({
    selector: 'EvdeSaglikBasvuruSorgulaSilForm',
    templateUrl: './EvdeSaglikBasvuruSorgulaSilForm.html',
    providers: [MessageService]
})
export class EvdeSaglikBasvuruSorgulaSilForm extends TTVisual.TTForm implements OnInit, IModal {

     HomeCarePatientListColumns = [
         { caption: i18n("M15316", "Hasta TC"), dataField: 'PatientTC', fixed: true, width: '30%', allowSorting: false, allowEditing: false },
        { caption: i18n("M15131", "Hasta Adı"), dataField: 'PatientName', fixed: true, width: '30%', allowSorting: false, allowEditing: false },
        { caption: i18n("M15303", "Hasta Soyadı"), dataField: 'PatientSurname', fixed: true, width: '30%', allowSorting: false, allowEditing: false },
        //{ caption: '', width: 75, allowSorting: false, cellTemplate: "buttonCellTemplate" }
        { caption: i18n("M22125", "Sorgula"), width: 75, allowSorting: false, cellTemplate: "linkCellTemplateGetApplication" },
        { caption: 'Sil', width: 75, allowSorting: false, cellTemplate: "linkCellTemplateDeleteApplication" },
        { caption: i18n("M17386", "Kaydet"), width: 75, allowSorting: false, cellTemplate: "linkCellTemplateSaveApplication" }


    ];

    public homeCarePatientsResult: HomeCarePatientsModel[] = [];

    public evdeSaglikBasvuruSorgulaSilViewModel: EvdeSaglikBasvuruSorgulaSilViewModel = new EvdeSaglikBasvuruSorgulaSilViewModel();
    public get _EvdeSaglikHizmetleri(): EvdeSaglikHizmetleri {
        return this._TTObject as EvdeSaglikHizmetleri;
    }
    private EvdeSaglikBasvuruSorgulaSilForm_DocumentUrl: string = '/api/EvdeSaglikHizmetleriService/EvdeSaglikBasvuruSorgulaSilForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalService: IModalService) {
        super('EVDESAGLIKHIZMETLERI', 'EvdeSaglikBasvuruSorgulaSilForm');
        this._DocumentServiceUrl = this.EvdeSaglikBasvuruSorgulaSilForm_DocumentUrl;
    }
    ngOnInit(): void {

    }

    public setInputParam(value: any) {
    }
    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    getHomeCarePatients(): void {
        let that = this;

        let input = new InputObject();
        input.StartDate = this.evdeSaglikBasvuruSorgulaSilViewModel.StartDate;
        input.EndDate = this.evdeSaglikBasvuruSorgulaSilViewModel.EndDate;
        let apiUrl: string = '/api/EvdeSaglikHizmetleriService/GetHomeCarePatients';
        that.httpService.post<any>(apiUrl, input)
            .then(response => {
                this.homeCarePatientsResult = response;
            })
            .catch(error => {
                this.messageService.showError(error);
            });
    }
    getApplication(value): void {
        let that = this;
        let apiUrl: string = '/api/EvdeSaglikHizmetleriService/GetApplication?BasvuruID=' + value.row.data.ApplicationID;
        that.httpService.get<any>(apiUrl)
            .then(response => {
                //Sorgulayınca dönüşünde ne yapılacak?
            })
            .catch(error => {
                this.messageService.showError(error);
            });
    }
    deleteApplication(value): void {
        //value.row.data
        let that = this;
        let apiUrl: string = '/api/EvdeSaglikHizmetleriService/DeleteApplication?BasvuruID=' + value.row.data.ApplicationID;
        that.httpService.get<any>(apiUrl)
            .then(response => {

            })
            .catch(error => {
                this.messageService.showError(error);
            });
    }


    private saveApplication(value): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "EvdeSaglikBasvuruKaydetForm";
            componentInfo.ModuleName = "EvdeSaglikHizmetleriModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Evde_Saglik_Hizmetleri_Modulu/EvdeSaglikHizmetleriModule";
            componentInfo.InputParam = new DynamicComponentInputParam(false, null);
            componentInfo.objectID = value.row.data.ObjectID;
            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M13999", "Evde Sağlık Hizmetleri Başvuru Kaydetme Formu");
            modalInfo.Width = 800;
            modalInfo.Height = 500;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    onRowPreparedPatientList(row: any): void {
        if (row.rowElement.firstItem() !== undefined && row.rowType !== 'header' && row.rowElement.firstItem().length === 1) {
            if (row.data.IsDeleted) {
                row.rowElement.firstItem().style.backgroundColor = '#ff8077';
                row.rowElement.firstItem().style.color = '#11583D';
            }
            else if (row.data.IsDeleted == false && row.data.IsNew == true) {
                row.rowElement.firstItem().style.backgroundColor = '#c1eeff';
                row.rowElement.firstItem().style.color = '#380400';
            }
        }
    }

}
export class InputObject {
    StartDate: Date;
    EndDate: Date;

}