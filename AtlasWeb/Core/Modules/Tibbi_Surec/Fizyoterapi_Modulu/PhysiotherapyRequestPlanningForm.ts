//$81A16F18
import { Component, ViewChild, OnInit, HostListener, NgZone, OnDestroy, EventEmitter} from '@angular/core';
import { PhysiotherapyRequestPlanningFormViewModel, OrderDetailInfo, OrderInfo, PhyOrderDetailInfo } from './PhysiotherapyRequestPlanningFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PhysiotherapyRequest, MedulaTreatmentReport, ReportTypeEnum, DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { BaseTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


//<atlas-form-editor  için
import { NqlQueryService } from 'app/QueryList/Services/nql-query.service';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
//

import { PhysiotherapyOrderPlanningFormViewModel, PhysiotherapyOrderComponentInfoViewModel } from './PhysiotherapyOrderPlanningFormViewModel';
import { PhysiotherapyOrderPlanningForm } from './PhysiotherapyOrderPlanningForm';
import { PhysiotherapyOrder } from 'NebulaClient/Model/AtlasClientModel';

import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { PhysiotherapyStateEnum } from 'NebulaClient/Model/AtlasClientModel';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';

import { ObjectContextService } from "Fw/Services/ObjectContextService";
import { PhysiotherapyOrderDetail } from 'NebulaClient/Model/AtlasClientModel';


import { DatePipe } from '@angular/common';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { EpisodeActionData } from "Modules/Tibbi_Surec/Hasta_Dosyasi/MainPatientFolderFormViewModel";
import { FormSaveInfo } from 'NebulaClient/Mscorlib/FormSaveInfo';

import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { HelpMenuService } from "Fw/Services/HelpMenuService";

import { DxDataGridComponent, DxSelectBoxComponent } from "devextreme-angular";
import { ActiveIDsModel, ClickFunctionParams } from 'app/Fw/Models/ParameterDefinitionModel';
import { IDestroyEvent } from 'app/Interfaces/IDestroyEvent';
import { EnumItem } from 'app/NebulaClient/Mscorlib/EnumItem';
import { TTTextBoxColumn, TTButtonColumn } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { PatientReportInfo } from '../Poliklinik_Modulu/PatientExaminationDoctorFormNewViewModel';
import { MessageIconEnum } from 'app/NebulaClient/Utils/Enums/MessageIconEnum';
import { UserTemplateModel } from '../Hasta_Raporlari_Modulu/ParticipationFreeDrugReportNewFormViewModel';


@Component({
    selector: 'PhysiotherapyRequestPlanningForm',
    templateUrl: './PhysiotherapyRequestPlanningForm.html',
    providers: [MessageService, NqlQueryService, DatePipe]
})
export class PhysiotherapyRequestPlanningForm extends TTVisual.TTForm implements OnInit, OnDestroy, IDestroyEvent {

    @ViewChild('scrollPanel') ScrollPanel: HTMLElement;

    OnDestroy: EventEmitter<any> = new EventEmitter<any>();
    
    private isStateCancelled: boolean = false;

    private _readOnlyByCode: boolean = false;
    private _isFTRworkList: boolean = false;

    public openDinamicCompFunc: Function;
    //public hasDinamicCompFunc: boolean = false;

    public setInputParam(value: boolean) {
        if (value != null && value['readOnlyByCode'] != null) {
            this._readOnlyByCode = value['readOnlyByCode']; //Hasta geçmişinde açıldığı zaman buttonları readonly yapabilmek için
        }

        if (value != null && value['isFTRworkList'] != null) {
            this._isFTRworkList = value['isFTRworkList']; //F.T.R. iş listesinden açıldığı zaman saydayı refresh yapabilemk için
        }

        if (value != null && value['openDinamicComp'] != null && typeof value['openDinamicComp'] === 'function') {
            //this.hasDinamicCompFunc = true;
            this.openDinamicCompFunc = value['openDinamicComp'];
        }

    }



    //PackageProcedure: TTVisual.ITTObjectListBox;
    //TreatmentTypePhysiotherapyReports: TTVisual.ITTEnumComboBox;

    Amount: TTVisual.ITTTextBoxColumn;
    Barcode: TTVisual.ITTTextBoxColumn;
    CokluOzelDurum: TTVisual.ITTButtonColumn;
    DistributionType: TTVisual.ITTTextBoxColumn;
    GridTreatmentMaterials: TTVisual.ITTGrid;
    Kdv: TTVisual.ITTTextBoxColumn;
    KodsuzMalzemeFiyatı: TTVisual.ITTTextBoxColumn;
    labelProtocolNo: TTVisual.ITTLabel;
    MalzemeBrans: TTVisual.ITTTextBoxColumn;
    MalzemeTuru: TTVisual.ITTListBoxColumn;
    Material: TTVisual.ITTListBoxColumn;
    Notes: TTVisual.ITTTextBoxColumn;
    OzelDurum: TTVisual.ITTListBoxColumn;
    ProtocolNo: TTVisual.ITTTextBox;
    SatinAlisTarihi: TTVisual.ITTDateTimePickerColumn;
    TreatmentMaterialActionDate: TTVisual.ITTDateTimePickerColumn;
    LastOrderDetailResponsiblePhysiotherapist: TTVisual.ITTObjectListBox;
    UBBCode: TTVisual.ITTTextBoxColumn;
    showAnamnesisInfo: boolean = false;
    public GridTreatmentMaterialsColumns = [];

    
    public reportTypeList: Array<EnumItem>;
    public selectedReportType: EnumItem;
    ReportParamActiveIDsModel: ActiveIDsModel;
    showMedulaTedaviRaporlariForm = false;
    public medulaTedaviRaporlariObject = new MedulaTreatmentReport;
    public currentActionReports: boolean = false;
    public GridPatientReportsColumns = [];
    cmbReportType: TTVisual.ITTEnumComboBox;
    txtReportName: TTTextBoxColumn;
    txtReportRequestReason: TTVisual.TTTextBoxColumn;
    txtReportAdmissionDate: TTVisual.TTTextBoxColumn;
    txtReportMasterResource: TTVisual.TTTextBoxColumn;


    txtStartDate: TTTextBoxColumn;
    txtEndDate: TTTextBoxColumn;
    btnEdit: TTButtonColumn;
    txtProcedureByUser: TTTextBoxColumn;

    
    public physiotherapyRequestPlanningFormViewModel: PhysiotherapyRequestPlanningFormViewModel = new PhysiotherapyRequestPlanningFormViewModel();
    public get _PhysiotherapyRequest(): PhysiotherapyRequest {
        return this._TTObject as PhysiotherapyRequest;
    }
    private PhysiotherapyRequestPlanningForm_DocumentUrl: string = '/api/PhysiotherapyRequestService/PhysiotherapyRequestPlanningForm';
    constructor(protected httpService: NeHttpService, private datePipe: DatePipe,
        protected objectContextService: ObjectContextService,
        protected messageService: MessageService,
        protected activeUserService: IActiveUserService,
        private sideBarMenuService: ISidebarMenuService,
        protected helpMenuService: HelpMenuService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone) {
        super('PHYSIOTHERAPYREQUEST', 'PhysiotherapyRequestPlanningForm');
        this._DocumentServiceUrl = this.PhysiotherapyRequestPlanningForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
     //   this.reportTypeList.push(ReportTypeEnum._TreatmentReport); //Sadece tedavi raporlari islemleri.

    }


    // ***** Method declarations start *****
    //#region load Panel
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }
    //#endregion load Panel

    public saveOrders: boolean = false;
    public _transDef: TTObjectStateTransitionDef;
    public IsPanelOpen: boolean = true;

    protected async save() {
        this.loadPanelOperation(true, 'Lütfen Bekleyiniz.');
        this.saveOrders = true;
        try {
            await super.save();
        } catch (e) {
            this.loadPanelOperation(false, '');
        }
        this.saveOrders = false;
    }

    refreshDynamicComponent() {
        if (this.openDinamicCompFunc != null) {
            this.openDinamicCompFunc(this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.ObjectID, "PHYSIOTHERAPYREQUEST", null);
        }
        else if (this._isFTRworkList == true) {
            this.httpService.episodeActionWorkListSharedService.refreshWorklist(true);
        } else {
            this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("PHYSIOTHERAPYREQUEST", this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.ObjectID, null);
        }
    }
    refreshDynamicComponentForEpisodeActionWorkList() {
        if (this.openDinamicCompFunc != null) {
        }
        else if (this._isFTRworkList == true) {
        }
        else {
            this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("PHYSIOTHERAPYREQUEST", this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.ObjectID, null);
        }
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        this.loadPanelOperation(true, 'Lütfen Bekleyiniz.');
        super.AfterContextSavedScript(transDef);
        if (transDef !== null && transDef.ToStateDefID != null) {
            if (transDef.ToStateDefID.id == PhysiotherapyRequest.PhysiotherapyRequestStates.Planned.id) {
                this.printReports();
            }
        }
        this.loadPanelOperation(false, '');
        this.refreshDynamicComponentForEpisodeActionWorkList();
    }

    protected async setState(transDef: TTObjectStateTransitionDef, saveInfo?: FormSaveInfo): Promise<void> {
        await super.setState(transDef, saveInfo);
        this.loadPanelOperation(false, '');
    }


    public anamnesisInfoButtonClicked() {
        this.showAnamnesisInfo = true;
    }

    public onAnemnesisPopUpDisposing() {
        this.showAnamnesisInfo = false;
    }

    //#region Rapor Yazdırma
    public printReports() {
        this.printFTRTreatmentCardReport();
        this.printPhysicalTherapyInformationReport();
        this.printPhysicalTherapyRehabilitationReport();
    }
    public printPhysiotherapyRequestReport() {
        const objectIdParam = new GuidParam(this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.ObjectID);
        let reportParameters: any = { 'PHYSIOTHERAPYREQUEST': objectIdParam };
        this.reportService.showReport('PhysiotherapyRequestReport', reportParameters);
    }
    public printFTRTreatmentCardReport() {
        const objectIdParam = new GuidParam(this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.ObjectID);
        let reportParameters: any = { 'PHYSIOTHERAPYREQUEST': objectIdParam };
        this.reportService.showReport('FTRTreatmentCard', reportParameters);
    }
    public printPhysicalTherapyInformationReport() {
        const objectIdParam = new GuidParam(this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.ObjectID);
        let reportParameters: any = { 'PHYSIOTHERAPYREQUEST': objectIdParam };
        this.reportService.showReport('PhysicalTherapyInformation', reportParameters);
    }
    public printPhysicalTherapyRehabilitationReport() {
        const objectIdParam = new GuidParam(this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.ObjectID);
        let reportParameters: any = { 'PHYSIOTHERAPYREQUEST': objectIdParam };
        this.reportService.showReport('PhysicalTherapyRehabilitation', reportParameters);
    }
    //#endregion Rapor Yazdırma
    public isformopen: boolean = false;
    public formOpenedOrClosed(value: any) {
        this.isformopen = value;
    }

    protected async PreScript() {
        this.resize(undefined);
        super.PreScript();

        let componentInfoViewModel: PhysiotherapyOrderComponentInfoViewModel;
        componentInfoViewModel = PhysiotherapyOrderPlanningForm.getComponentInfoViewModel(this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.ObjectID);
        this.physiotherapyOrderQueryParameters = componentInfoViewModel.physiotherapyOrderQueryParameters;
        this.physiotherapyOrderComponentInfo = componentInfoViewModel.physiotherapyOrderComponentInfo;
        this.loadPanelOperation(false, '');
    }

    public physiotherapyOrderComponentInfo: DynamicComponentInfo;
    public physiotherapyOrderQueryParameters: QueryParams;

    physiotherapyOrderQueryResultLoaded(e: any) {
        PhysiotherapyOrderPlanningForm.physiotherapyOrderQueryResultLoaded(e);
    }

    @HostListener('window:resize', ['$event'])
    resize(event: Event) {
        if (this.ScrollPanel) {
            let rect: ClientRect = this.ScrollPanel['nativeElement'].getBoundingClientRect();
            let top = rect.top;

            let viewPortHeight: number = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);
            this.ScrollPanel['nativeElement'].style.height = (viewPortHeight - (top + 17)).toString() + "px";
        }
    }


    //#region PhysiotherapyOrderDetail Grid İşlemleri
    public selectedRowKeysResultList: any = [];
    public selectedRowsData: Array<PhyOrderDetailInfo> = [];

    async onRowUpdating(value: any): Promise<void> {
        if (value.oldData.OrderDetailItem.CurrentStateDefID.valueOf() == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed.id) {
            this.messageService.showInfo(i18n("M22714", "Tamamlandı Durumunda Olan İşlemlerin Tarihini Değiştiremezsiniz!"));
            value.newData.PlannedDate = value.oldData.PlannedDate;
        } else {
            let _sessionNumber: number = value.oldData.SessionNumber;
            let approvedTransactionCount: number = 0; //Onaylanacak statusündeki işlemler

            if (value.oldData.IsAdditionalTreatment == true) { //Ek tedavi ise değişiklik yapma


                //if (_sessionNumber != null) {
                //    for (var i = 0; i < this.physiotherapyRequestPlanningFormViewModel.AdditionalOrderDetailInfoList.length; i++) {
                //        if (this.physiotherapyRequestPlanningFormViewModel.AdditionalOrderDetailInfoList[i].SessionNumber == _sessionNumber.toString() && this.physiotherapyRequestPlanningFormViewModel.AdditionalOrderDetailInfoList[i].OrderDetailItem.CurrentStateDefID == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed) {
                //            approvedTransactionCount++;
                //        }
                //    }
                //}

                if (approvedTransactionCount > 0) {
                    this.messageService.showInfo(i18n("M21483", "Seans içinde Tamamlandı Durumunda İşlem Olan İşlemlerin Tarihini Değiştiremezsiniz!"));
                    value.newData.PlannedDate = value.oldData.PlannedDate;
                } else {
                    let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M22834", "Tarih Değişimi"), i18n("M22835", "Tarih değiştirmeniz durumunda mevcut seanstaki tüm tarihler değiştirilecektir! \r\n\r\n Devam etmek istiyor musunuz?"));
                    if (messageResult === "E") {
                        if (value.oldData.OrderDetailItem.CurrentStateDefID.valueOf() == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed.id) {
                            this.messageService.showInfo(i18n("M22714", "Tamamlandı Durumunda Olan İşlemlerin Tarihini Değiştiremezsiniz!"));
                            value.newData.PlannedDate = value.oldData.PlannedDate;
                        } else {
                            value.oldData.PlannedDate = value.newData.PlannedDate;
                            //if (_sessionNumber != null) {
                            //    for (var i = 0; i < this.physiotherapyRequestPlanningFormViewModel.AdditionalOrderDetailInfoList.length; i++) {//Mevcut seansa ait tüm tarihler değiştiriliyor
                            //        if (this.physiotherapyRequestPlanningFormViewModel.AdditionalOrderDetailInfoList[i].SessionNumber == _sessionNumber.toString()) {
                            //            this.physiotherapyRequestPlanningFormViewModel.AdditionalOrderDetailInfoList[i].PlannedDate = value.newData.PlannedDate;
                            //            this.physiotherapyRequestPlanningFormViewModel.ChangedOrderDetail = this.physiotherapyRequestPlanningFormViewModel.AdditionalOrderDetailInfoList[i];
                            //        }
                            //    }
                            //}
                        }
                    } else {
                        value.newData.PlannedDate = value.oldData.PlannedDate;
                    }
                }


            } else { //Ek tedavi DEĞİL ise değişiklik yapma


                if (_sessionNumber != null) {
                    for (let i = 0; i < this.physiotherapyRequestPlanningFormViewModel.OrderDetailInfoList.length; i++) {
                        if (this.physiotherapyRequestPlanningFormViewModel.OrderDetailInfoList[i].SessionNumber == _sessionNumber.toString() && this.physiotherapyRequestPlanningFormViewModel.OrderDetailInfoList[i].OrderDetailItem.CurrentStateDefID.valueOf() == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed.id) {
                            approvedTransactionCount++;
                        }
                    }
                }

                if (approvedTransactionCount > 0) {
                    this.messageService.showInfo(i18n("M21483", "Seans içinde Tamamlandı Durumunda İşlem Olan İşlemlerin Tarihini Değiştiremezsiniz!"));
                    value.newData.PlannedDate = value.oldData.PlannedDate;
                } else {
                    let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M22834", "Tarih Değişimi"), i18n("M22835", "Tarih değiştirmeniz durumunda mevcut seanstaki tüm tarihler değiştirilecektir! \r\n\r\n Devam etmek istiyor musunuz?"));
                    if (messageResult === "E") {
                        if (value.oldData.OrderDetailItem.CurrentStateDefID.valueOf() == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed.id) {
                            this.messageService.showInfo(i18n("M22714", "Tamamlandı Durumunda Olan İşlemlerin Tarihini Değiştiremezsiniz!"));
                            value.newData.PlannedDate = value.oldData.PlannedDate;
                        } else {
                            value.oldData.PlannedDate = value.newData.PlannedDate;
                            if (_sessionNumber != null) {
                                for (let i = 0; i < this.physiotherapyRequestPlanningFormViewModel.OrderDetailInfoList.length; i++) {//Mevcut seansa ait tüm tarihler değiştiriliyor
                                    if (this.physiotherapyRequestPlanningFormViewModel.OrderDetailInfoList[i].SessionNumber == _sessionNumber.toString()) {
                                        this.physiotherapyRequestPlanningFormViewModel.OrderDetailInfoList[i].PlannedDate = value.newData.PlannedDate;
                                        //this.physiotherapyRequestPlanningFormViewModel.ChangedOrderDetail = this.physiotherapyRequestPlanningFormViewModel.OrderDetailInfoList[i];
                                    }
                                }
                            }
                        }
                    } else {
                        value.newData.PlannedDate = value.oldData.PlannedDate;
                    }


                }


            }
        }
    }

    async selectionOrderDetailChange(value: any): Promise<void> {
        let i = 0;
        this.selectedRowsData = [];
        value.selectedRowKeys.sort(); //key listesini data listesi ile aynı sıraya getirmek için sıralıyoruz
        for (let selectedDetail of value.selectedRowsData) {
            if (selectedDetail.ApplicationAreaDef == "") {
                let SelectedDetailItem = this.physiotherapyRequestPlanningFormViewModel.OrderDetailInfoList.find(x => x.KeyNumber == value.selectedRowKeys[i]);
                for (let selectedOrderDetail of SelectedDetailItem.OrderDetailList) {
                    this.selectedRowsData.push(selectedOrderDetail);
                }
            } else {
                let SelectedDetailItem = selectedDetail as PhyOrderDetailInfo;
                this.selectedRowsData.push(SelectedDetailItem);
            }
            i++;
        }
    }
    //#endregion PhysiotherapyOrderDetail Grid İşlemleri

    //#region Fizyoterapi Button İşlemleri

    //İstek iptal
    public async cancelPhysiotherapyRequest() {
        let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M14075", "F.T.R. İstek İptal"), i18n("M14072", "F.T.R. isteğini iptal etmeniz durumunda tekrar işlem yapılamayacaktır! \r\n\r\n Devam etmek istiyor musunuz?"));
        if (messageResult === "E") {

            let that = this;
            that.httpService.post<any>("api/PhysiotherapyRequestService/CancelPhysiotherapyPlanningRequest", this.physiotherapyRequestPlanningFormViewModel)
                .then(response => {
                    this.refreshDynamicComponent();

                    this.messageService.showSuccess(i18n("M14071", "F.T.R. İsteği Başarılı Bir Şekilde İptal Edildi"));
                })
                .catch(error => {
                    this.messageService.showError(error);

                });
        }
    }

    //İstek iptal Geri Alma
    public async UndoLastTransition_SelectedEpisodeAction() {
        if (this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest != null && (this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.CurrentStateDefID.valueOf() == PhysiotherapyRequest.PhysiotherapyRequestStates.Completed.id || this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.CurrentStateDefID.valueOf() == PhysiotherapyRequest.PhysiotherapyRequestStates.Cancelled.id)) {
            let massage: string = "F.T.R. Tedavisi ";
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'İşlem Geri Alma',
                massage + i18n("M14750", "geri alınacaktır.Devam etmek istediğinize emin misiniz? "));
            if (result === 'V') {
                ServiceLocator.MessageService.showSuccess(i18n("M14753", "Geri Alma İşleminden Vazgeçildi"));
            }
            else {
                let that = this;
                let _DocumentServiceUrl: string = "/api/MainPatientFolderService/UndoLastTransitionEAorSPFlowableByObjectId?ObjectId=" + this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.ObjectID.toString();
                this.httpService.get<Array<EpisodeActionData>>(_DocumentServiceUrl)
                    .then(result => {
                        ServiceLocator.MessageService.showSuccess(massage + i18n("M14752", "geri alınmıştır"));
                        that.httpService.episodeActionWorkListSharedService.refreshWorklist(true);
                    }).catch(err => {
                        ServiceLocator.MessageService.showError(massage + i18n("M14751", "geri alınamamıştır.") + err);
                    });


            }


        }
    }

    //Seçili Kayıtları Silme/İptal
    public deleteRecords() {

        console.log(this.selectedRowsData);


        if (this.selectedRowsData.length == 0) {
            this.messageService.showReponseError(i18n("M16877", "İşlem seçilmediği için silme işlemine devam edilemedi."));
            return false;
        }

        let approvedTransactionCount: number = 0; //Onaylanacak statusü dışındaki işlemler

        for (let i = 0; i < this.selectedRowsData.length; i++) {
            if (this.selectedRowsData[i].OrderDetailItem.CurrentStateDefID.valueOf() == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed.id)//"Tamamlandı durumunda olanlar"
            {
                approvedTransactionCount++;
            }
        }
        if (approvedTransactionCount > 0) {
            this.messageService.showInfo(i18n("M22713", "Tamamlandı Durumunda Olan İşlemleri Silemezsiniz!"));
        } else {

            for (let i = 0; i < this.selectedRowsData.length; i++) {
                this.selectedRowsData[i].CurrentUserObjectId = this.activeUserService.ActiveUser.UserObject.ObjectID; //İşlemi yapan kişi belirleniyor
            }

            let that = this;
            that.httpService.post<any>("api/PhysiotherapyRequestService/DeleteSelectedPhyOrderDetailsByID", this.selectedRowsData)
                .then(response => {
                    this.refreshDynamicComponent();

                    this.messageService.showSuccess(i18n("M21530", "Seçilen İşlemler Başarılı Bir Şekilde Silindi"));
                })
                .catch(error => {
                    this.messageService.showError(error);

                });
        }
    }

    //#endregion Fizyoterapi Button İşlemleri

    //#region PhysiotherapyOrder Grid İşlemleri
    public selectedOrderRowKeysResult: any;
    @ViewChild('physiotherapyOrderListGrid')
    physiotherapyOrderListGrid: DxDataGridComponent;
    public selectedOrderItemInfo: PhysiotherapyOrderPlanningFormViewModel = new PhysiotherapyOrderPlanningFormViewModel;
    //public IsSelectedObjExist: boolean = false;

    refreshPhysiotherapyOrderPlanningForm: boolean = true;
    async selectionOrderChange(value: any): Promise<void> {
        //let that = this;
        if (this._readOnlyByCode != true && value.currentSelectedRowKeys[0] != null) {
            this.refreshPhysiotherapyOrderPlanningForm = false;

            let plannedOrdersForm_DocumentUrl: string = '/api/PhysiotherapyOrderService/GetPhysiotherapyOrderPlanningFormViewModelById?orderInfo';
            this.httpService.post<PhysiotherapyOrderPlanningFormViewModel>("api/PhysiotherapyOrderService/GetPhysiotherapyOrderPlanningFormViewModelById?orderInfo", value.currentSelectedRowKeys[0], PhysiotherapyOrderPlanningFormViewModel).then(response => {
                let result: PhysiotherapyOrderPlanningFormViewModel = <PhysiotherapyOrderPlanningFormViewModel>response;
                this.refreshPhysiotherapyOrderPlanningForm = true;

                this.physiotherapyRequestPlanningFormViewModel.selectedPhysiotherapyPlannedOrdersFormViewModel = result;
                this.selectedOrderItemInfo = result;
                this.selectedOrderItemInfo.ProcedureObjectDataSource = this.physiotherapyRequestPlanningFormViewModel.ProcedureObjectDataSource;
                this.IsPanelOpen = true;
            });
        }
    }

    public loadPhysiotherapyOrderRow(value: any) {

        let _data: OrderInfo = value.data as OrderInfo;
        if (_data != null && _data.IsPlannedBefore == true) {
            value.rowElement.firstItem().style.backgroundColor = '#a6a1bb';
        }

        if (_data != null && _data.CurrentStateDefID.id == PhysiotherapyOrder.PhysiotherapyOrderStates.Completed.id) {
            value.rowElement.firstItem().style.backgroundColor = '#8AD38A';
        }
    }
    //#endregion PhysiotherapyOrder Grid İşlemleri

    //#region Yeni İşlem/Temizle Prosedürleri
    public newPhysiotherapyOrder(showTreatmentTypePopup: boolean) {
        let that = this;
        let plannedOrdersForm_DocumentUrl: string = '/api/PhysiotherapyOrderService/GetNewPhysiotherapyOrderPlanningFormViewModel?physiotherapyRequest';

        that.refreshPhysiotherapyOrderPlanningForm = false;

        that.httpService.post<PhysiotherapyOrderPlanningFormViewModel>("api/PhysiotherapyOrderService/GetNewPhysiotherapyOrderPlanningFormViewModel?physiotherapyRequest", this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest, PhysiotherapyOrderPlanningFormViewModel).then(response => {
            let result: PhysiotherapyOrderPlanningFormViewModel = <PhysiotherapyOrderPlanningFormViewModel>response;
            that.refreshPhysiotherapyOrderPlanningForm = true;

            this.physiotherapyRequestPlanningFormViewModel.selectedPhysiotherapyPlannedOrdersFormViewModel = result;
            that.selectedOrderItemInfo = result;
            that.selectedOrderItemInfo.ProcedureObjectDataSource = that.physiotherapyRequestPlanningFormViewModel.ProcedureObjectDataSource;
            if (showTreatmentTypePopup != null && showTreatmentTypePopup == false) {//ilk form açılırken rapor sormaması için
                that.selectedOrderItemInfo.showTreatmentTypePopupForNew = showTreatmentTypePopup;
            }

            that.physiotherapyOrderListGrid.instance.deselectAll();
            that.IsPanelOpen = true;
        });
    }
    //#endregion Yeni İşlem/Temizle Prosedürleri

    public loadPlanningGridContainerRow(value: any) {

        let _data: OrderDetailInfo = value.data as OrderDetailInfo;
        if (_data != null && _data.PhysiotherapyState == PhysiotherapyStateEnum._Complated.description) {
            value.rowElement.firstItem().style.backgroundColor = '#BAE8BA'; //'#8AD38A';//'#5cb85c';83c983
        }

        if (_data != null && _data.PhysiotherapyState == PhysiotherapyStateEnum._NotCome.description) {
            value.rowElement.firstItem().style.backgroundColor = '#94C3EA'; //'#65A5DA';//'#428bca';
        }

        if (_data != null && _data.PhysiotherapyState == PhysiotherapyStateEnum._Aborted.description) {
            value.rowElement.firstItem().style.backgroundColor = '#FFE992'; //'#F9D543';//'#F1C40F';
        }
    }
    public selectedUserTemplate;
    public userTemplateName;
    async SelectUserTemplate(event: any): Promise<void> {
        if (event.itemData != null) {

            if (this.physiotherapyRequestPlanningFormViewModel.selectedUserTemplate == null || (this.physiotherapyRequestPlanningFormViewModel.selectedUserTemplate.ObjectID != event.itemData.ObjectID)) {
                this.physiotherapyRequestPlanningFormViewModel.selectedUserTemplate = event.itemData;
                const that = this;
                that.loadReportByTemplate();
            }
        }

    }

    protected async loadReportByTemplate() {
        try {


            let fullApiUrl: string = "";


            fullApiUrl = "/api/PhysiotherapyOrderService/PhysiotherapyOrderFormTemplate?TAObjectID=" +this.physiotherapyRequestPlanningFormViewModel.selectedUserTemplate.TAObjectID+"&ActiveEpisodeActionID="+this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.ObjectID;

            let httpService: NeHttpService = ServiceLocator.NeHttpService;
            this.refreshPhysiotherapyOrderPlanningForm = false;

            let response = await httpService.post<PhysiotherapyOrderPlanningFormViewModel>(fullApiUrl, this.physiotherapyRequestPlanningFormViewModel.selectedUserTemplate, PhysiotherapyOrderPlanningFormViewModel);

            let result: PhysiotherapyOrderPlanningFormViewModel = <PhysiotherapyOrderPlanningFormViewModel>response;
            this.refreshPhysiotherapyOrderPlanningForm = true;

            this.physiotherapyRequestPlanningFormViewModel.selectedPhysiotherapyPlannedOrdersFormViewModel = result;
            this.selectedOrderItemInfo = result;
            this.selectedOrderItemInfo.ProcedureObjectDataSource = this.physiotherapyRequestPlanningFormViewModel.ProcedureObjectDataSource;
            this.IsPanelOpen = true;

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }
    
    async btnDeleteSelectedUserTemplate_Click(): Promise<void> {
        try {
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), i18n("M21560", "Seçili Şablon Sistemden Silinecektir. Devam Etmek İstiyor Musunuz ? "), 1);
            if (result === "H")
                return;
            let savedUserTemplate: UserTemplateModel = new UserTemplateModel();

            savedUserTemplate.ObjectID = this.physiotherapyRequestPlanningFormViewModel.selectedUserTemplate.ObjectID;
            savedUserTemplate.TAObjectDefID = this.physiotherapyRequestPlanningFormViewModel.PhysiotherapyOrderList[0].OrderObjectDefId;
            let apiUrl: string = 'api/PhysiotherapyOrderService/SavePhysiotherapyOrderPlanningUserTemplate';
            this.loadPanelOperation(true, 'Şablon Siliniyor, Lütfen Bekleyiniz');
            await this.httpService.post<Array<UserTemplateModel>>(apiUrl, savedUserTemplate).then(result => {
                this.physiotherapyRequestPlanningFormViewModel.userTemplateList = result;
                this.physiotherapyRequestPlanningFormViewModel.selectedUserTemplate = null;
                this.userTemplateName = "";
                ServiceLocator.MessageService.showSuccess("Şablon Başarıyla Silindi");
            });
            this.loadPanelOperation(false, '');

        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
            TTVisual.InfoBox.Alert("Uyarı", err, MessageIconEnum.ErrorMessage);
        }
    }
    @ViewChild('TemplateCombo') TemplateCombo: DxSelectBoxComponent;

    async btnClearUserTemplate_Click(): Promise<void> {
        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), i18n("M21560", "Şablon Temizlenerek Boş bir Form Açılacaktır. Devam Etmek İstiyor Musunuz? "), 1);
        if (result === "H")
            return;
        this.loadPanelOperation(true, 'Form Açılıyor, Lütfen Bekleyiniz');

        this.newPhysiotherapyOrder(true); 
        this.loadPanelOperation(false, '');

        this.TemplateCombo.value = null;
        this.selectedUserTemplate = null;
        this.physiotherapyRequestPlanningFormViewModel.selectedUserTemplate = null;
    }

    rowPrepared(row: any) {
    }

    public openHastaGecmisiTab: boolean = false;
    public openHastaGecmisi() {
        this.openHastaGecmisiTab = true;
    }

    public openMalzemeSarfTab: boolean = false;
    public openMalzemeSarf() {
        this.openMalzemeSarfTab = true;
    }

    public openReportsTab: boolean = false;
    public openReports() {
        this.openReportsTab = true;
    }

 


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PhysiotherapyRequest();
        this.physiotherapyRequestPlanningFormViewModel = new PhysiotherapyRequestPlanningFormViewModel();
        this._ViewModel = this.physiotherapyRequestPlanningFormViewModel;
        this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest = this._TTObject as PhysiotherapyRequest;
        this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.TreatmentMaterials = new Array<BaseTreatmentMaterial>();

        this.loadPanelOperation(true, 'Lütfen Bekleyiniz.');
    }

    protected loadViewModel() {
        let that = this;

        this.loadPanelOperation(true, 'Lütfen Bekleyiniz.');

        that.physiotherapyRequestPlanningFormViewModel = this._ViewModel as PhysiotherapyRequestPlanningFormViewModel;
        that._TTObject = this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest;
        if (this.physiotherapyRequestPlanningFormViewModel == null)
            this.physiotherapyRequestPlanningFormViewModel = new PhysiotherapyRequestPlanningFormViewModel();
        if (this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest == null)
            this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest = new PhysiotherapyRequest();
        that.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.TreatmentMaterials = that.physiotherapyRequestPlanningFormViewModel.GridTreatmentMaterialsGridList;
        for (let detailItem of that.physiotherapyRequestPlanningFormViewModel.GridTreatmentMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.physiotherapyRequestPlanningFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.physiotherapyRequestPlanningFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.physiotherapyRequestPlanningFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
                                if (distributionType) {
                                    stockCard.DistributionType = distributionType;
                                }
                            }
                        }
                    }
                }
            }
            let ozelDurumObjectID = detailItem["OzelDurum"];
            if (ozelDurumObjectID != null && (typeof ozelDurumObjectID === "string")) {
                let ozelDurum = that.physiotherapyRequestPlanningFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
        }

        if (this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.CurrentStateDefID.valueOf() != PhysiotherapyRequest.PhysiotherapyRequestStates.RequestAcception.id) {
            this.IsPanelOpen = false;
        }


        this.DropStateButton(PhysiotherapyRequest.PhysiotherapyRequestStates.Cancelled);
        this.DropStateButton(PhysiotherapyRequest.PhysiotherapyRequestStates.Completed);

        //if (this.physiotherapyRequestPlanningFormViewModel.TreatmentType == null || this.physiotherapyRequestPlanningFormViewModel.TreatmentType == 0) {
        //    this.physiotherapyRequestPlanningFormViewModel.TreatmentType = TreatmentQueryReportTypeEnum.FTR;
        //}

        if (this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.CurrentStateDefID.valueOf() == PhysiotherapyRequest.PhysiotherapyRequestStates.Cancelled.id) {
            this.isStateCancelled = true;
        }

        this.newPhysiotherapyOrder(false);
    }

    async ngOnInit() {
        let that = this;
        this.AddHelpMenu();
        await this.load(PhysiotherapyRequestPlanningFormViewModel);

    }

    async ngOnDestroy()  {
        this.OnDestroy.emit();
    }

    //BURCU
    public getClickFunctionParams() : ClickFunctionParams{
        let clickFunctionParams : ClickFunctionParams = new ClickFunctionParams(this, new ActiveIDsModel(this._PhysiotherapyRequest.ObjectID,null,null));
        return clickFunctionParams;
    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let physioTherapyList = new DynamicSidebarMenuItem();
        physioTherapyList.key = 'physioTherapyList';
        physioTherapyList.icon = 'ai ai-kayitli-ftr';
        physioTherapyList.label = 'Kayıtlı F.T.R Listesi';
        physioTherapyList.componentInstance = this.helpMenuService;
        physioTherapyList.clickFunction = this.helpMenuService.openPhysioTherapyList;
        physioTherapyList.parameterFunctionInstance = this;
        physioTherapyList.getParamsFunction = this.getClickFunctionParams;
        physioTherapyList.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', physioTherapyList);
    }


    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('colorPrescription');
        this.sideBarMenuService.removeMenu('manipulation');
        this.sideBarMenuService.removeMenu('patientDocumentUpload');
        this.sideBarMenuService.removeMenu('surgery');
        this.sideBarMenuService.removeMenu('nabizMessage');
        /* this.sideBarMenuService.removeMenu('showENabizInfo');*/
        this.sideBarMenuService.removeMenu('ssk');
        this.sideBarMenuService.removeMenu('openPhysiotherapyRequest');
        this.sideBarMenuService.removeMenu('greenList');
        this.sideBarMenuService.removeMenu('greenListSearch');
        this.sideBarMenuService.removeMenu('printInpatientAdmissionInfoByTreatmentClinicReport');
        this.sideBarMenuService.removeMenu('printOrthesisProsthesisReceptionReport');
        this.sideBarMenuService.removeMenu('eNabizDataSets');
        this.sideBarMenuService.removeMenu('vaccineFollowup');
        this.sideBarMenuService.removeMenu('consultation');
        this.sideBarMenuService.removeMenu('onTakeInpatientObservation');
        this.sideBarMenuService.removeMenu('pathologyRequest');
        this.sideBarMenuService.removeMenu('cancerscreening');
        this.sideBarMenuService.removeMenu('orthesisList');
        this.sideBarMenuService.removeMenu('physioTherapyList');
        this.sideBarMenuService.removeMenu('patientNoShown');
        this.sideBarMenuService.removeMenu('influenzaResult');

    }

    public onProtocolNoChanged(event): void {
        if (event != null) {
            if (this._PhysiotherapyRequest != null && this._PhysiotherapyRequest.ProtocolNo != event) {
                this._PhysiotherapyRequest.ProtocolNo = event;
            }
        }
    }


    //public onPackageProcedureChanged(event): void {
    //    if (event != null) {
    //        if (this.PackageProcedure != event) {
    //            this.PackageProcedure = event;
    //        }
    //        if (this.physiotherapyRequestPlanningFormViewModel.PackageProcedure != event) {
    //            this.physiotherapyRequestPlanningFormViewModel.PackageProcedure = event;
    //        }
    //    }
    //}


    //public onLastOrderDetailResponsiblePhysiotherapistChanged(event): void {
    //    //if (event != null) {
    //    //}
    //    if (this.physiotherapyRequestPlanningFormViewModel.LastOrderDetailResponsiblePhysiotherapist != event) {
    //        this.physiotherapyRequestPlanningFormViewModel.LastOrderDetailResponsiblePhysiotherapist = event;
    //    }
    //}//onValueChanged


    //public onLastOrderDetailStartDateChanged(event): void {
    //    if (event != null) {
    //        if (this.physiotherapyRequestPlanningFormViewModel.LastOrderDetailStartDate != null && this.physiotherapyRequestPlanningFormViewModel.LastOrderDetailStartDate != event.value) {
    //            this.physiotherapyRequestPlanningFormViewModel.LastOrderDetailStartDate = event.value;
    //        }
    //    }
    //}
    //public onLastOrderDetailFinishDateChanged(event): void {
    //    if (event != null) {
    //        if (this.physiotherapyRequestPlanningFormViewModel.LastOrderDetailFinishDate != null && this.physiotherapyRequestPlanningFormViewModel.LastOrderDetailFinishDate != event.value) {
    //            this.physiotherapyRequestPlanningFormViewModel.LastOrderDetailFinishDate = event.value;
    //        }
    //    }
    //}

    //public onTreatmentTypePhysiotherapyReportsChanged(event): void {
    //    if (event != null) {
    //        if (this.TreatmentTypePhysiotherapyReports != event) {
    //            this.TreatmentTypePhysiotherapyReports = event;
    //        }
    //        if (this.physiotherapyRequestPlanningFormViewModel.TreatmentType != event) {
    //            this.physiotherapyRequestPlanningFormViewModel.TreatmentType = event;
    //        }
    //    }
    //}

  /*  async GridPatientReports_CellContentClicked(data: any) {
        let that = this;
        this.ReportParamActiveIDsModel = new ActiveIDsModel(this._PhysiotherapyRequest.ObjectID, this._PhysiotherapyRequest.Episode.ObjectID, this._PhysiotherapyRequest.Episode.Patient.ObjectID);

        if (data.Column.Name == "btnEdit") {
            if (data.Row != null) {
                if (data.Row.TTObject != null) {
                    let patientReportGrid = data.Row.TTObject;
                    if (patientReportGrid.ObjectID != null && patientReportGrid.ObjectDefName != null) {  
                        if (patientReportGrid.ObjectDefName == "MEDULATREATMENTREPORT")
                            this.onMedulaTreatmentReportOpen(patientReportGrid.ObjectID);

                    }
                }
            }
        }
    }

    
    public CheckIsDiagnosisExistsForReports(DiagnosisGridList: DiagnosisGrid[]): boolean {
        if (DiagnosisGridList) {
            if (DiagnosisGridList.filter(dr => dr.IsNew != true).length > 0) {
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }
    
    async onSelectedReportOpen(data: any) {
        if (this.CheckIsDiagnosisExistsForReports(this.physiotherapyRequestPlanningFormViewModel.GridEpisodeDiagnosisGridList) == false) {
            this.messageService.showError("Hasta üzerinde kayıtlı bir tanı olmadan Rapor yazamazsınız.!");
            return;
        }
        this.ReportParamActiveIDsModel = new ActiveIDsModel(this._PhysiotherapyRequest.ObjectID, this._PhysiotherapyRequest.Episode.ObjectID, this._PhysiotherapyRequest.Episode.Patient.ObjectID);
        if (data.code === ReportTypeEnum.TreatmentReport) {
            this.onMedulaTreatmentReportOpen(null);
        }
   
    }

    private showMedulaTreatmentReport(data: MedulaTreatmentReport) {
        this.showMedulaTedaviRaporlariForm = true;

        this.medulaTedaviRaporlariObject = data as MedulaTreatmentReport;
    }

    onMedulaTreatmentReportOpen(episodeAction: any) {
        let temp;

        if (episodeAction == null) {
            this.showMedulaTreatmentReport(null);
        }
        else {
            this.objectContextService.getObject<MedulaTreatmentReport>(episodeAction, MedulaTreatmentReport.ObjectDefID, MedulaTreatmentReport).then(result => {
                let temp: MedulaTreatmentReport = result;
                temp = result;
                this.showMedulaTreatmentReport(temp);
            });
        }
    }

    async OnMedulaTedaviRaporlariFormClosing(e) {
        if (e == true)
            this.showMedulaTedaviRaporlariForm = false;

        //refreshReportTab
        let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.SubEpisode + '&includedCancelledReports=false&currentActionReports=true';
        let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);
        this.physiotherapyRequestPlanningFormViewModel.PatientReportInfoList = res;
    }

    async reloadReportList() {
        let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.SubEpisode + '&includedCancelledReports=false&currentActionReports=' + this.currentActionReports;
        let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);
        this.physiotherapyRequestPlanningFormViewModel.PatientReportInfoList = res;
    }

    async onMedulaTedaviRaporlariForm(event: any) {
        this.showMedulaTedaviRaporlariForm = false;
        //refreshReportTab
        this.reloadReportList();

    }

    public async onShowCancelledReports(val: any): Promise<void> {
        if (val.value != null) {

            let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.SubEpisode + '&includedCancelledReports=' + val.value + '&currentActionReports=' + this.currentActionReports;
            let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);


            this.physiotherapyRequestPlanningFormViewModel.PatientReportInfoList = res;
        }
    }
    public async onShowAllReports(val: any): Promise<void> {
        if (val.value != null) {
            this.currentActionReports = !(val.value);
            let fullApiUrl = '/api/PatientExaminationService/GetPatientReport/?patientObjectID=' + this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.Episode.Patient.ObjectID + '&subepisodeObjectID=' + this.physiotherapyRequestPlanningFormViewModel._PhysiotherapyRequest.SubEpisode + '&includedCancelledReports=false&currentActionReports=' + this.currentActionReports;
            let res = await this.httpService.get<any>(fullApiUrl, PatientReportInfo);


            this.physiotherapyRequestPlanningFormViewModel.PatientReportInfoList = res;
        }
    }

    onRowPreparedPatientReportInfoList(e: any): void {
        if (e.rowElement.firstItem() != undefined && e.rowType != 'header' && e.rowType != 'filter' && e.rowType != 'totalFooter' && e.rowElement.firstItem().length == 1) {
            if (e.data.CancelledReport == true) {
                e.rowElement.firstItem().Color = '#C78F8A';
                e.rowElement.firstItem().backgroundColor = '#380400';
            }
            else {
                e.rowElement.firstItem().style.backgroundColor = '#FFFFFF';
                e.rowElement.firstItem().style.color = '#000000';
            }
        }
    }*/


    protected redirectProperties(): void {
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "ProtocolNo");
        //redirectProperty(this.TreatmentTypePhysiotherapyReports, "Value", this.__ttObject, "PhysiotherapyReports.TreatmentType");

    }

    public initFormControls(): void {

        //this.TreatmentTypePhysiotherapyReports = new TTVisual.TTEnumComboBox();
        //this.TreatmentTypePhysiotherapyReports.DataTypeName = "TreatmentQueryReportTypeEnum";
        //this.TreatmentTypePhysiotherapyReports.Name = "TreatmentTypePhysiotherapyReports";
        //this.TreatmentTypePhysiotherapyReports.TabIndex = 54;

        //this.PackageProcedure = new TTVisual.TTObjectListBox();
        //this.PackageProcedure.Required = true;
        //this.PackageProcedure.ListDefName = "FTRPackageProcedureList";
        //this.PackageProcedure.Name = "PackageProcedure";
        //this.PackageProcedure.TabIndex = 94;



        //this.LastOrderDetailResponsiblePhysiotherapist = new TTVisual.TTObjectListBox();
        //this.LastOrderDetailResponsiblePhysiotherapist.Required = true;
        //this.LastOrderDetailResponsiblePhysiotherapist.ListDefName = "PhysiotherapistListDefinition";
        //this.LastOrderDetailResponsiblePhysiotherapist.Name = "LastOrderDetailResponsiblePhysiotherapist";
        //this.LastOrderDetailResponsiblePhysiotherapist.TabIndex = 94;


        //this.ttdatetimepicker1 = new TTVisual.TTDateTimePicker();
        //this.ttdatetimepicker1.Format = DateTimePickerFormat.Long;
        //this.ttdatetimepicker1.Name = "ttdatetimepicker1";
        //this.ttdatetimepicker1.TabIndex = 89;
        //this.ttdatetimepicker1.Required = true;

        //this.ttdatetimepicker2 = new TTVisual.TTDateTimePicker();
        //this.ttdatetimepicker2.Format = DateTimePickerFormat.Long;
        //this.ttdatetimepicker2.Name = "ttdatetimepicker2";
        //this.ttdatetimepicker2.TabIndex = 89;
        //this.ttdatetimepicker2.Required = true;

        //this.TTListBoxPhysiotherapist = new TTVisual.TTObjectListBox();
        //this.TTListBoxPhysiotherapist.ListDefName = "PhysiotherapistListDefinition";
        //this.TTListBoxPhysiotherapist.Name = "TTListBoxPhysiotherapist";
        //this.TTListBoxPhysiotherapist.TabIndex = 10;
        //this.TTListBoxPhysiotherapist.Required = true;


        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.Name = "ProtocolNo";
        this.ProtocolNo.TabIndex = 8;

        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = i18n("M20566", "Protokol No");
        this.labelProtocolNo.Name = "labelProtocolNo";
        this.labelProtocolNo.TabIndex = 9;

        this.GridTreatmentMaterials = new TTVisual.TTGrid();
        this.GridTreatmentMaterials.Name = "GridTreatmentMaterials";
        this.GridTreatmentMaterials.TabIndex = 0;

        this.TreatmentMaterialActionDate = new TTVisual.TTDateTimePickerColumn();
        this.TreatmentMaterialActionDate.Format = DateTimePickerFormat.Custom;
        this.TreatmentMaterialActionDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.TreatmentMaterialActionDate.DataMember = "ActionDate";
        this.TreatmentMaterialActionDate.DisplayIndex = 0;
        this.TreatmentMaterialActionDate.HeaderText = "Tarih/Saat";
        this.TreatmentMaterialActionDate.Name = "TreatmentMaterialActionDate";
        this.TreatmentMaterialActionDate.ReadOnly = true;
        this.TreatmentMaterialActionDate.Width = 180;

        this.Material = new TTVisual.TTListBoxColumn();
        this.Material.ListDefName = "ConsumableMaterialAndDrugList";
        this.Material.DataMember = "Material";
        this.Material.DisplayIndex = 1;
        this.Material.HeaderText = i18n("M21326", "Sarf Malzeme");
        this.Material.Name = "Material";
        this.Material.Width = 325;

        this.Barcode = new TTVisual.TTTextBoxColumn();
        this.Barcode.DataMember = "Barcode";
        this.Barcode.DisplayIndex = 2;
        this.Barcode.HeaderText = "Barkodu";
        this.Barcode.Name = "Barcode";
        this.Barcode.ReadOnly = true;
        this.Barcode.Width = 100;

        this.UBBCode = new TTVisual.TTTextBoxColumn();
        this.UBBCode.DataMember = "UBBCode";
        this.UBBCode.DisplayIndex = 3;
        this.UBBCode.HeaderText = i18n("M23689", "UBB Kodu");
        this.UBBCode.Name = "UBBCode";
        this.UBBCode.Width = 100;

        this.DistributionType = new TTVisual.TTTextBoxColumn();
        this.DistributionType.DataMember = "DistributionType";
        this.DistributionType.DisplayIndex = 4;
        this.DistributionType.HeaderText = i18n("M19908", "Ölçü Birimi");
        this.DistributionType.Name = "DistributionType";
        this.DistributionType.ReadOnly = true;
        this.DistributionType.Width = 100;

        this.Amount = new TTVisual.TTTextBoxColumn();
        this.Amount.DataMember = "Amount";
        this.Amount.DisplayIndex = 5;
        this.Amount.HeaderText = i18n("M19030", "Miktar");
        this.Amount.Name = "Amount";
        this.Amount.Width = 100;

        this.OzelDurum = new TTVisual.TTListBoxColumn();
        this.OzelDurum.ListDefName = "OzelDurumListDefinition";
        this.OzelDurum.DataMember = "OzelDurum";
        this.OzelDurum.DisplayIndex = 6;
        this.OzelDurum.HeaderText = i18n("M20080", "Özel Durum");
        this.OzelDurum.Name = "OzelDurum";
        this.OzelDurum.Width = 100;

        this.Notes = new TTVisual.TTTextBoxColumn();
        this.Notes.DataMember = "Note";
        this.Notes.DisplayIndex = 7;
        this.Notes.HeaderText = i18n("M19485", "Notlar");
        this.Notes.Name = "Notes";
        this.Notes.Width = 100;

        this.CokluOzelDurum = new TTVisual.TTButtonColumn();
        this.CokluOzelDurum.DisplayIndex = 8;
        this.CokluOzelDurum.HeaderText = i18n("M12418", "Çoklu Özel Durum");
        this.CokluOzelDurum.Name = "CokluOzelDurum";
        this.CokluOzelDurum.Width = 100;

        this.KodsuzMalzemeFiyatı = new TTVisual.TTTextBoxColumn();
        this.KodsuzMalzemeFiyatı.DisplayIndex = 9;
        this.KodsuzMalzemeFiyatı.HeaderText = i18n("M17688", "Kodsuz Malzeme Fiyatı");
        this.KodsuzMalzemeFiyatı.Name = "KodsuzMalzemeFiyatı";
        this.KodsuzMalzemeFiyatı.Visible = false;
        this.KodsuzMalzemeFiyatı.Width = 100;

        this.MalzemeTuru = new TTVisual.TTListBoxColumn();
        this.MalzemeTuru.ListDefName = "MalzemeTuruDefinitionList";
        this.MalzemeTuru.DisplayIndex = 10;
        this.MalzemeTuru.HeaderText = i18n("M18650", "Malzemenin Türü");
        this.MalzemeTuru.Name = "MalzemeTuru";
        this.MalzemeTuru.Visible = false;
        this.MalzemeTuru.Width = 100;

        this.Kdv = new TTVisual.TTTextBoxColumn();
        this.Kdv.DisplayIndex = 11;
        this.Kdv.HeaderText = "Kdv";
        this.Kdv.Name = "Kdv";
        this.Kdv.Visible = false;
        this.Kdv.Width = 100;

        this.MalzemeBrans = new TTVisual.TTTextBoxColumn();
        this.MalzemeBrans.DisplayIndex = 12;
        this.MalzemeBrans.HeaderText = i18n("M18636", "Malzemenin Branşı");
        this.MalzemeBrans.Name = "MalzemeBrans";
        this.MalzemeBrans.Visible = false;
        this.MalzemeBrans.Width = 100;

        this.SatinAlisTarihi = new TTVisual.TTDateTimePickerColumn();
        this.SatinAlisTarihi.DisplayIndex = 13;
        this.SatinAlisTarihi.HeaderText = i18n("M21333", "Satın Alış Tarihi");
        this.SatinAlisTarihi.Name = "SatinAlisTarihi";
        this.SatinAlisTarihi.Visible = false;
        this.SatinAlisTarihi.Width = 100;

        this.GridTreatmentMaterialsColumns = [this.TreatmentMaterialActionDate, this.Material, this.Barcode, this.UBBCode, this.DistributionType, this.Amount, this.OzelDurum, this.Notes, this.CokluOzelDurum, this.KodsuzMalzemeFiyatı, this.MalzemeTuru, this.Kdv, this.MalzemeBrans, this.SatinAlisTarihi];
        this.Controls = [this.LastOrderDetailResponsiblePhysiotherapist, this.ProtocolNo, this.labelProtocolNo, this.GridTreatmentMaterials, this.TreatmentMaterialActionDate, this.Material, this.Barcode, this.UBBCode, this.DistributionType, this.Amount, this.OzelDurum, this.Notes, this.CokluOzelDurum, this.KodsuzMalzemeFiyatı, this.MalzemeTuru, this.Kdv, this.MalzemeBrans, this.SatinAlisTarihi];

    }


}
