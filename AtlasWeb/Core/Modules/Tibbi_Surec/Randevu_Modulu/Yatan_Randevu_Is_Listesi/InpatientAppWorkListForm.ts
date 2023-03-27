//$0D23E1A1
import { Component, ViewChild, OnInit } from '@angular/core';
import { InpatientAppWorkListFormViewModel, InpatientAppWorkListItemModel, InpatientAppWorkListSearchCriteria } from './InpatientAppWorkListFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";

import { MessageService } from 'Fw/Services/MessageService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { DxDataGridComponent } from "devextreme-angular";

import { PatientStatusEnum, ResTreatmentDiagnosisUnit, ResWard, ResUser } from 'NebulaClient/Model/AtlasClientModel';


import { TTUnboundForm } from 'NebulaClient/Visual/TTUnboundForm';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { EpisodeActionWorkListStateItem, StateOutputDVO, EpisodeActionWorkListItem } from "Modules/Tibbi_Surec/Hasta_Is_Listesi/EpisodeActionWorkListFormViewModel";

import { Subscription } from 'rxjs';
import { ActiveInfoDVO } from 'Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListFormViewModel';


@Component({
    selector: 'inpatientApp-workList-form',
    templateUrl: './InpatientAppWorkListForm.html',
    providers: [SystemApiService, MessageService]
})
export class InpatientAppWorkListForm extends TTUnboundForm implements OnInit {

    public inpatientAppWorkListFormViewModel: InpatientAppWorkListFormViewModel = new InpatientAppWorkListFormViewModel();
    public PatientTypeList = [];
    public PhysiotherapyStateItems: Array<EpisodeActionWorkListStateItem>;

    private inpatientAppWorkListSubscription: Subscription;

    //private InpatientAppWorkListForm_DocumentUrl: string = '/api/InpatientAppWorkListService/InpatientAppWorkList';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, public systemApiService: SystemApiService, private objectContextService: ObjectContextService) {
        super('PYHSIOTHERAPYWORKLIST', 'InpatientAppWorkListForm');
        //this._DocumentServiceUrl = this.PatientHistoryForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();

        let that = this;
        this.inpatientAppWorkListSubscription = this.httpService.episodeActionWorkListSharedService.RefreshEpisodeActionWorkList.subscribe(
            RefreshEpisodeActionWorkList => {
                if (RefreshEpisodeActionWorkList) {
                    setTimeout(function () {
                        that.isDynamicComponentOpened = false;
                    }, 300);
                }
            });
    }


    public showLoadPanel = false;
    public LoadPanelMessage: string = '';
    isDynamicComponentOpened: boolean = false;

    @ViewChild('inpatientAppWorkListGrid')
    inpatientAppWorkListGrid: DxDataGridComponent;

    btnListele: TTVisual.ITTButton;

    public WorkListColumns = [
        {
            caption: "Sıra",
            dataField: "QueueNumber",
            dataType: 'number',
            width: 40,
            allowSorting: true
        },
        {
            caption: i18n("M15133", "Hasta Adı Soyadı"),
            dataField: "PatientNameSurname",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M17578", "Kimlik No"),
            dataField: "PatientRefNo",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M17021", "Kabul No"),
            dataField: "AdmissionNumber",
            dataType: 'string',
            width: 80,
            allowSorting: true
        },
        {
            caption: "Birim",
            dataField: "ClinicName",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: "Doktor",
            dataField: "ProcedureDoctor",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: "Tahmini Yatacağı Süre",
            dataField: "InpatientDay",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: "Randevu Tarihi",
            dataField: "AppointmentDate",
            dataType: 'date',
            format: 'dd.MM.yyyy',
            width: "auto",
            allowSorting: true
        },
        {
            caption: "Doktor",
            dataField: "AppointmentDoctor",
            width: "auto",
            allowSorting: true
        },
        {
            caption: "Statü",
            dataField: "InpatientAppState",
            width: "auto",
            allowSorting: true
        }
    ];


    // ***** Method declarations start *****

    isAccordionOpened: boolean = true;

    async select(value: any): Promise<void> {
        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code
            this.loadPanelOperation(true, i18n("M14461", "Form hazırlanıyor, lütfen bekleyiniz."));
            console.log();
            let _data: InpatientAppWorkListItemModel = value.data as InpatientAppWorkListItemModel;

            this.openDynamicComponent(value.data.ObjectDefName, _data.ObjectID, null, null);
        }

    }

    public componentCreated(e: any) {

    }

    public dynamicComponentClosed(e: any) {
    }

    public onRowPrepared(value: any) {
        let _data: InpatientAppWorkListItemModel = value.data as InpatientAppWorkListItemModel;
    }

    public componentInfo: DynamicComponentInfo;
    openDynamicComponent(objectDefName: any, objectID?: any, formDefId?: any, inputparam?: any) {
        this.isDynamicComponentOpened = false;
        if (objectID != null) {
            this.systemApiService.open(objectID, objectDefName, formDefId, inputparam).then(resolveCompInfo => {
                this.componentInfo = resolveCompInfo;
                this.componentInfo.CloseWithStateTransition = true;
                this.componentInfo.DestroyComponentOnSave = true;
                this.componentInfo.RefreshComponent = true;
                this.loadPanelOperation(false, '');
            });
        } else {
            this.systemApiService.new(objectDefName, null, formDefId, inputparam).then(resolveCompInfo => {
                this.componentInfo = resolveCompInfo;
                this.componentInfo.CloseWithStateTransition = true;
                this.componentInfo.DestroyComponentOnSave = true;
                this.componentInfo.RefreshComponent = true;
                this.loadPanelOperation(false, '');
            });
        }
        this.isDynamicComponentOpened = true;

    }

    changeAcoordionCollapse() {
        let that = this;
        that.isAccordionOpened = !that.isAccordionOpened;
        setTimeout(function () {
            that.inpatientAppWorkListGrid.instance.repaint();
        }, 150);
    }

    public btnSearchClicked(): void {

        let that = this;
        let _SearchCriteria: InpatientAppWorkListSearchCriteria = new InpatientAppWorkListSearchCriteria();

        this.loadPanelOperation(true, 'Randevu İşlemleri listeleniyor, lütfen bekleyiniz.');

        that.httpService.post<InpatientAppWorkListItemModel[]>("api/InpatientAppWorkListService/GetInpatientAppWorkList",
            that.inpatientAppWorkListFormViewModel._inpatientAppWorkListSearchCriteria)
            .then(response => {
                that.inpatientAppWorkListFormViewModel.InpatientAppWorkList = response as InpatientAppWorkListItemModel[];

                that.isAccordionOpened = false;
                that.loadPanelOperation(false, '');
                setTimeout(function () {
                    that.inpatientAppWorkListGrid.instance.repaint();
                }, 150);
            })
            .catch(error => {
                this.loadPanelOperation(false, '');
                this.messageService.showError(error);

            });
    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    patientChanged(patient: any) {
        if (patient)
            this.inpatientAppWorkListFormViewModel._inpatientAppWorkListSearchCriteria.PatientObjectID = patient.ObjectID;
        else
            this.inpatientAppWorkListFormViewModel._inpatientAppWorkListSearchCriteria.PatientObjectID = "";
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        let that = this;
        let fullApiUrl: string = "/api/InpatientAppWorkListService/InpatientAppWorkList";
        this.httpService.get<any>(fullApiUrl)
            .then(response => {
                let result = response;
                that.inpatientAppWorkListFormViewModel = result;

                //let _tempClinic = new Array<ResWard>();
                //that.inpatientAppWorkListFormViewModel._inpatientAppWorkListSearchCriteria.PhysicalStateClinic.forEach(element => {
                //    let listItem = that.inpatientAppWorkListFormViewModel.PhysicalStateClinicList.find(o => o.ObjectID.toString() === element.ObjectID.toString());
                //    if (listItem) {
                //        _tempClinic.push(listItem);
                //    }
                //});

                //that.inpatientAppWorkListFormViewModel._inpatientAppWorkListSearchCriteria.PhysicalStateClinic = new Array<ResWard>();
                //that.inpatientAppWorkListFormViewModel._inpatientAppWorkListSearchCriteria.PhysicalStateClinic = _tempClinic;



                //let _tempDoctor = new Array<ResUser>();
                //that.inpatientAppWorkListFormViewModel._inpatientAppWorkListSearchCriteria.Doctor.forEach(element => {
                //    let listItem = that.inpatientAppWorkListFormViewModel.DoctorList.find(o => o.ObjectID.toString() === element.ObjectID.toString());
                //    if (listItem) {
                //        _tempDoctor.push(listItem);
                //    }
                //});

                //that.inpatientAppWorkListFormViewModel._inpatientAppWorkListSearchCriteria.Doctor = new Array<ResUser>();
                //that.inpatientAppWorkListFormViewModel._inpatientAppWorkListSearchCriteria.Doctor = _tempDoctor;

            })
            .catch(error => {
                console.log(error);
            });
    }

    protected loadViewModel() {
        let that = this;
        if (this.inpatientAppWorkListFormViewModel == null)
            this.inpatientAppWorkListFormViewModel = new InpatientAppWorkListFormViewModel();
    }

    async ngOnInit() {
        let that = this;
        this.loadViewModel();
    }


    public initFormControls(): void {
    }

}




