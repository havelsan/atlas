//$0D23E1A1
import { Component, ViewChild, OnInit } from '@angular/core';
import { ChemoRadiotherapyWorkListFormViewModel, ChemoRadiotherapyWorkListItemModel, ChemoRadiotherapyWorkListSearchCriteria } from './ChemoRadiotherapyWorkListFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";

import { MessageService } from 'Fw/Services/MessageService';
import { SystemApiService } from 'Fw/Services/SystemApiService';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { DxDataGridComponent } from "devextreme-angular";

import { PatientStatusEnum, ResTreatmentDiagnosisUnit } from 'NebulaClient/Model/AtlasClientModel';


import { TTUnboundForm } from 'NebulaClient/Visual/TTUnboundForm';
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { EpisodeActionWorkListStateItem, StateOutputDVO, EpisodeActionWorkListItem } from "Modules/Tibbi_Surec/Hasta_Is_Listesi/EpisodeActionWorkListFormViewModel";

import { Subscription } from 'rxjs';
import { ActiveInfoDVO } from 'Modules/Tibbi_Surec/Tibbi_Surec_Is_Listeleri/BaseEpisodeActionWorkListFormViewModel';


@Component({
    selector: 'ChemoRadiotherapyWorkListForm',
    templateUrl: './ChemoRadiotherapyWorkListForm.html',
    providers: [SystemApiService, MessageService]
})
export class ChemoRadiotherapyWorkListForm extends TTUnboundForm implements OnInit {

    public chemoRadiotherapyWorkListFormViewModel: ChemoRadiotherapyWorkListFormViewModel = new ChemoRadiotherapyWorkListFormViewModel();
    public PatientTypeList = [];
    public ChemoRadiotherapyStateItems: Array<EpisodeActionWorkListStateItem>;

    private chemoRadioTherpayWorkListSubscription: Subscription;

    //private PhysiotherapyWorkListForm_DocumentUrl: string = '/api/PhysiotherapyWorkListService/PhysiotherapyWorkList';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, public systemApiService: SystemApiService, private objectContextService: ObjectContextService) {
        super('CHEMORADIOWORKLIST', 'ChemoRadiotherapyWorkListForm');
        //this._DocumentServiceUrl = this.PatientHistoryForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();

        let _episodeActionWorkListItems: Array<EpisodeActionWorkListItem> = new Array<EpisodeActionWorkListItem>();

        let _episodeActionWorkListItem: EpisodeActionWorkListItem = new EpisodeActionWorkListItem();
        _episodeActionWorkListItem.ObjectDefName = "ChemotherapyRadiotherapy";
        _episodeActionWorkListItem.ObjectDefID = "826e6f52-25ef-414d-84e9-38e7a38f3394";
        _episodeActionWorkListItems.push(_episodeActionWorkListItem);

        this.getStateList(_episodeActionWorkListItems);


        this.PatientTypeList = [
            {
                TypeName: 'Tümü',
                TypeID: -1
            }, {
                TypeName: 'Ayaktan',
                TypeID: 0
            }, {
                TypeName: 'Yatan',
                TypeID: 1
            }
        ];

        let that = this;
        this.chemoRadioTherpayWorkListSubscription = this.httpService.episodeActionWorkListSharedService.RefreshEpisodeActionWorkList.subscribe(
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

    @ViewChild('chemoRadiotherapyWorkListGrid')
    chemoRadiotherapyWorkListGrid: DxDataGridComponent;

    btnListele: TTVisual.ITTButton;

    public WorkListColumns = [
        {
            caption: i18n("M17021", "Kabul No"),
            dataField: "AdmissionNumber",
            dataType: 'string',
            width: 80,
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
            caption: i18n("M15133", "Hasta Adı Soyadı"),
            dataField: "PatientNameSurname",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M15187", "Hasta Durumu"),
            dataField: "PatientStatus",
            dataType: 'string',
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M11637", "Başlangıç Tarihi"),
            dataField: "StartDate",
            dataType: 'date',
            format: 'dd.MM.yyyy',
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M11939", "Bitiş Tarihi"),
            dataField: "FinishDate",
            dataType: 'date',
            format: 'dd.MM.yyyy',
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M16822", "İşlem Adımı"),
            dataField: "ChemoRadioTherapyState",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M16822", "Rapor"),
            dataField: "IsReportRequired",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M16822", "İstek Yapan Birim"),
            dataField: "FromResource",
            width: "auto",
            allowSorting: true
        },
        {
            caption: i18n("M16822", "İstek Yapan Doktor"),
            dataField: "ProcedureDoctor",
            width: "auto",
            allowSorting: true
        }
    ];


    // ***** Method declarations start *****

    isAccordionOpened: boolean = true;
    getChemoRadiotherapyList() {

        let that = this;
        let _SearchCriteria: ChemoRadiotherapyWorkListSearchCriteria = new ChemoRadiotherapyWorkListSearchCriteria();

        this.loadPanelOperation(true, 'Kemoterapi Radyoterapi İşlemleri listeleniyor, lütfen bekleyiniz.');

        that.httpService.post<ChemoRadiotherapyWorkListItemModel[]>("api/ChemoRadiotherapyWorkListService/GetChemoRadiotherapyActionWorkList",
            that.chemoRadiotherapyWorkListFormViewModel._ChemoRadiotherapyWorkListSearchCriteria)
            .then(response => {
                that.chemoRadiotherapyWorkListFormViewModel.ChemoRadiotherapyActionList =   response as ChemoRadiotherapyWorkListItemModel[] ;

                that.isAccordionOpened = false;
                that.loadPanelOperation(false, '');
                setTimeout(function () {
                    that.chemoRadiotherapyWorkListGrid.instance.repaint();
                }, 150);
            })
            .catch(error => {
                this.loadPanelOperation(false, '');
                this.messageService.showError(error);

            });

    }

    async select(value: any): Promise<void> {
        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {
            //Double click code
            this.loadPanelOperation(true, i18n("M14461", "Form hazırlanıyor, lütfen bekleyiniz."));
            console.log();
            let _data: ChemoRadiotherapyWorkListItemModel = value.data as ChemoRadiotherapyWorkListItemModel;

            let _inputParam = {};
            _inputParam['isFTRworkList'] = true;

            this.openDynamicComponent(value.data.ObjectDefName, _data.ObjectID, null, _inputParam);
        }

    }

    public componentCreated(e: any) {

    }

    public dynamicComponentClosed(e: any) {
    }

    public onRowPrepared(value: any) {//Taburcu durumundaki hastalar renkli gösterilecek
        let _data: ChemoRadiotherapyWorkListItemModel = value.data as ChemoRadiotherapyWorkListItemModel;
        if (_data != null && _data.IsPatientDischarged == PatientStatusEnum.PreDischarge) {
            value.rowElement.firstItem().style.backgroundColor = '#FFE8B9';
        }
        else if (_data != null && _data.IsPatientDischarged == PatientStatusEnum.Discharge) {
            value.rowElement.firstItem().style.backgroundColor = '#BAE8BA';
        }
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
            that.chemoRadiotherapyWorkListGrid.instance.repaint();
        }, 150);
    }

    public btnSearchClicked(): void {

        let a = this.getChemoRadiotherapyList();
    }

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }

    //fizyoterapi state listesi
    async getStateList(value: any) {
        let that = this;

        let res = await this.httpService.post("api/EpisodeActionWorkListService/GetEpisodeActionStateDefinition", value);
        let output = <StateOutputDVO>res;

        this.ChemoRadiotherapyStateItems = output.WorkListSearchStateItem;
    }

    patientChanged(patient: any) {
        if (patient)
            this.chemoRadiotherapyWorkListFormViewModel._ChemoRadiotherapyWorkListSearchCriteria.PatientObjectID = patient.ObjectID;
        else
            this.chemoRadiotherapyWorkListFormViewModel._ChemoRadiotherapyWorkListSearchCriteria.PatientObjectID = "";
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        let that = this;
        let fullApiUrl: string = "/api/ChemoRadiotherapyWorkListService/ChemoRadiotherapyWorkList";
        this.httpService.get<any>(fullApiUrl)
            .then(response => {
                let result = response;
                that.chemoRadiotherapyWorkListFormViewModel = result;


                let _tempSection = new Array<ResTreatmentDiagnosisUnit>();
                that.chemoRadiotherapyWorkListFormViewModel._ChemoRadiotherapyWorkListSearchCriteria.TreatmentDiagnosisUnit.forEach(element => {
                    let listItem = that.chemoRadiotherapyWorkListFormViewModel.TreatmentDiagnosisUnitList.find(o => o.ObjectID.toString() === element.ObjectID.toString());
                    if (listItem) {
                        _tempSection.push(listItem);
                    }
                });

                that.chemoRadiotherapyWorkListFormViewModel._ChemoRadiotherapyWorkListSearchCriteria.TreatmentDiagnosisUnit = new Array<ResTreatmentDiagnosisUnit>();
                that.chemoRadiotherapyWorkListFormViewModel._ChemoRadiotherapyWorkListSearchCriteria.TreatmentDiagnosisUnit = _tempSection;
            })
            .catch(error => {
                console.log(error);
            });
    }

    protected loadViewModel() {
        let that = this;
        if (this.chemoRadiotherapyWorkListFormViewModel == null)
            this.chemoRadiotherapyWorkListFormViewModel = new ChemoRadiotherapyWorkListFormViewModel();
    }

    async ngOnInit() {
        let that = this;
        this.loadViewModel();
    }


    public initFormControls(): void {
        //this.Controls = [];

    }


    onPatientTypeChanged(e: any): void {
        this.chemoRadiotherapyWorkListFormViewModel._ChemoRadiotherapyWorkListSearchCriteria.Patienttype = e.value;
    }


    onChemoRadiotherapyStateItems(e: any): void {
        this.chemoRadiotherapyWorkListFormViewModel._ChemoRadiotherapyWorkListSearchCriteria.ChemoRadioTherapyState = e.value;
    }

    async treatmentDiagnosisUnitChanged() {
        //this.Model.SelectedStateTypesEM = new Array<string>();
        //for (let stateType of this.Model.SelectedStateTypes) {
        //    if (stateType === "SUCCESSFUL")
        //        this.Model.SelectedStateTypesEM.push("COMPLETEDSUCCESSFULLY");
        //    else if (stateType === "UNSUCCESSFUL")
        //        this.Model.SelectedStateTypesEM.push("COMPLETEDUNSUCCESSFULLY");
        //    else
        //        this.Model.SelectedStateTypesEM.push(stateType);
        //}
    }

}




