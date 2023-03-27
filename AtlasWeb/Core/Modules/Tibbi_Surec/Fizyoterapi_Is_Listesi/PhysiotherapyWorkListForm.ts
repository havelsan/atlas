//$0D23E1A1
import { Component, ViewChild, OnInit } from '@angular/core';
import { PhysiotherapyWorkListFormViewModel, PhysiotherapyWorkListItemModel, PhysiotherapyWorkListSearchCriteria } from './PhysiotherapyWorkListFormViewModel';
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
import { HastaTemasDurumuResultModel, FilterDoctorModel } from '../Kayit_Kabul_Modulu/PatientAdmissionFormViewModel';
import { DynamicSidebarMenuItem } from '../../../wwwroot/app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';

@Component({
    selector: 'physiotherapy-workList-form',
    templateUrl: './PhysiotherapyWorkListForm.html',
    providers: [SystemApiService, MessageService]
})
export class PhysiotherapyWorkListForm extends TTUnboundForm implements OnInit {

    public physiotherapyWorkListFormViewModel: PhysiotherapyWorkListFormViewModel = new PhysiotherapyWorkListFormViewModel();
    public PatientTypeList = [];
    public PhysiotherapyStateItems: Array<EpisodeActionWorkListStateItem>;

    private physiotherapyWorkListSubscription: Subscription;

    //private PhysiotherapyWorkListForm_DocumentUrl: string = '/api/PhysiotherapyWorkListService/PhysiotherapyWorkList';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, public systemApiService: SystemApiService, private objectContextService: ObjectContextService, private sideBarMenuService: ISidebarMenuService) {
        super('PYHSIOTHERAPYWORKLIST', 'PhysiotherapyWorkListForm');
        //this._DocumentServiceUrl = this.PatientHistoryForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();

        let _episodeActionWorkListItems: Array<EpisodeActionWorkListItem> = new Array<EpisodeActionWorkListItem>();

        let _episodeActionWorkListItem: EpisodeActionWorkListItem = new EpisodeActionWorkListItem();
        _episodeActionWorkListItem.ObjectDefName = "PHYSIOTHERAPYREQUEST";
        _episodeActionWorkListItem.ObjectDefID = "43225fba-1931-42a1-b745-23599ea82b65";
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
        this.physiotherapyWorkListSubscription = this.httpService.episodeActionWorkListSharedService.RefreshEpisodeActionWorkList.subscribe(
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

    @ViewChild('physiotherapyWorkListGrid')
    physiotherapyWorkListGrid: DxDataGridComponent;

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
            dataField: "PhysiotherapyState",
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
    getPhysiotherapyList() {

        let that = this;
        let _SearchCriteria: PhysiotherapyWorkListSearchCriteria = new PhysiotherapyWorkListSearchCriteria();

        this.loadPanelOperation(true, 'F.T.R. İşlemleri listeleniyor, lütfen bekleyiniz.');

        that.httpService.post<PhysiotherapyWorkListItemModel[]>("api/PhysiotherapyWorkListService/GetPhysiotherapyActionWorkList",
            that.physiotherapyWorkListFormViewModel._physiotherapyWorkListSearchCriteria)
            .then(response => {
                that.physiotherapyWorkListFormViewModel.PhysiotherapyActionList =   response as PhysiotherapyWorkListItemModel[] ;

                that.isAccordionOpened = false;
                that.loadPanelOperation(false, '');
                setTimeout(function () {
                    that.physiotherapyWorkListGrid.instance.repaint();
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
            let _data: PhysiotherapyWorkListItemModel = value.data as PhysiotherapyWorkListItemModel;

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
        let _data: PhysiotherapyWorkListItemModel = value.data as PhysiotherapyWorkListItemModel;
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
            that.physiotherapyWorkListGrid.instance.repaint();
        }, 150);
    }

    public btnSearchClicked(): void {

        let a = this.getPhysiotherapyList();
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

        this.PhysiotherapyStateItems = output.WorkListSearchStateItem;
    }

    patientChanged(patient: any) {
        if (patient)
            this.physiotherapyWorkListFormViewModel._physiotherapyWorkListSearchCriteria.PatientObjectID = patient.ObjectID;
        else
            this.physiotherapyWorkListFormViewModel._physiotherapyWorkListSearchCriteria.PatientObjectID = "";
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        let that = this;
        let fullApiUrl: string = "/api/PhysiotherapyWorkListService/PhysiotherapyWorkList";
        this.httpService.get<any>(fullApiUrl)
            .then(response => {
                let result = response;
                that.physiotherapyWorkListFormViewModel = result;


                let _tempSection = new Array<ResTreatmentDiagnosisUnit>();
                that.physiotherapyWorkListFormViewModel._physiotherapyWorkListSearchCriteria.TreatmentDiagnosisUnit.forEach(element => {
                    let listItem = that.physiotherapyWorkListFormViewModel.TreatmentDiagnosisUnitList.find(o => o.ObjectID.toString() === element.ObjectID.toString());
                    if (listItem) {
                        _tempSection.push(listItem);
                    }
                });

                that.physiotherapyWorkListFormViewModel._physiotherapyWorkListSearchCriteria.TreatmentDiagnosisUnit = new Array<ResTreatmentDiagnosisUnit>();
                that.physiotherapyWorkListFormViewModel._physiotherapyWorkListSearchCriteria.TreatmentDiagnosisUnit = _tempSection;
            })
            .catch(error => {
                console.log(error);
            });
    }

    protected loadViewModel() {
        let that = this;
        if (this.physiotherapyWorkListFormViewModel == null)
            this.physiotherapyWorkListFormViewModel = new PhysiotherapyWorkListFormViewModel();
    }

    async ngOnInit() {
        let that = this;
        this.loadViewModel();
        this.AddHelpMenu();
    }


    public initFormControls(): void {
        //this.Controls = [];

    }


    onPatientTypeChanged(e: any): void {
        this.physiotherapyWorkListFormViewModel._physiotherapyWorkListSearchCriteria.Patienttype = e.value;
    }


    onPhysiotherapyStateItems(e: any): void {
        this.physiotherapyWorkListFormViewModel._physiotherapyWorkListSearchCriteria.PhysiotherapyState = e.value;
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

    onContextMenuPreparingPhysiotherapyActionList(e: any) {
        let that = this;
        if (e.row !== undefined && e.row !== null) {
            if (e.row.rowType === 'data') {
                e.items = [{
                    text: "Hasta Temas Durumu Sorgulama",
                    onItemClick: function () {

                        that.CheckPatientContactStatus(e.row.data);
                    }
                }]
            }
        }
    }

    async CheckPatientContactStatus(data: PhysiotherapyWorkListItemModel) {


        let that = this;

        try {

            let fullApiUrl = '/api/PhysiotherapyWorkListService/CheckPatientContactStatus/?PhysiotherapyRequestID=' + data.ObjectID;
                let res = await this.httpService.get<HastaTemasDurumuResultModel>(fullApiUrl, HastaTemasDurumuResultModel);
                if (res != null) {
                    if (res.responseMessage != "")
                        TTVisual.InfoBox.Alert(res.responseMessage);
                    else
                        TTVisual.InfoBox.Alert("Hastanın Temas Riski Bulunmamaktadır.");


                }
           
        }
        catch (error) {
            TTVisual.InfoBox.Alert("Temas Durmu Sorgulanırken bir hata ile karşılaşıldı " + error);
        }


       

    }
    private AddHelpMenu() {

        this.RemoveMenuFromHelpMenu();

        let hastaTemasDurumu = new DynamicSidebarMenuItem();
        hastaTemasDurumu.key = 'hastaTemasDurumu';
        hastaTemasDurumu.icon = 'ai ai-virus';
        hastaTemasDurumu.label = "Hasta Temas Durumu";
        hastaTemasDurumu.componentInstance = this;
        hastaTemasDurumu.clickFunction = this.CheckPatientContactStatusFromSideMenu;
        this.sideBarMenuService.addMenu('YardimciMenu', hastaTemasDurumu);
    }


    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('hastaTemasDurumu');
    }

    private showPatientContactStatus: boolean = false;
    private PatientContactStatusDoctorList: Array<FilterDoctorModel> = new Array<FilterDoctorModel>();
    private selectedDoctorForPatientContactStatus: Guid = Guid.Empty;
    private uniqueRefNo: string = "";

    async CheckPatientContactStatusFromSideMenu() {

        let that = this;

        this.httpService.get<Array<FilterDoctorModel>>("api/PatientAdmissionService/GetDoctorListForPatientContactStatus")
            .then(result => {
                this.PatientContactStatusDoctorList = result as Array<FilterDoctorModel>;
                this.showPatientContactStatus = true;

            })
            .catch(error => {
                that.messageService.showError(error);
            });




    }

    async ShowPatientContactStatus() {

        try {
            if (this.uniqueRefNo != null && this.uniqueRefNo != "" ) {
                let _temp = null;
                let fullApiUrl = '/api/PhysiotherapyWorkListService/CheckPatientContactStatusFromSideMenu/?doctorObjectID=' + this.selectedDoctorForPatientContactStatus + '&UniqueRefNo=' + this.uniqueRefNo;
                let res = await this.httpService.get<HastaTemasDurumuResultModel>(fullApiUrl, HastaTemasDurumuResultModel);
                if (res != null) {
                    if (res.responseMessage != "")
                        TTVisual.InfoBox.Alert(res.responseMessage);
                    else
                        TTVisual.InfoBox.Alert("Hastanın Temas Riski Bulunmamaktadır.");


                }
            } else
                TTVisual.InfoBox.Alert("TC Kimlik Numarası Giriniz.");
        }
        catch (error) {
            TTVisual.InfoBox.Alert("Temas Durmu Sorgulanırken bir hata ile karşılaşıldı " + error);
        }



    }


}




