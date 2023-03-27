//$81A16F18
import { Component, ViewChild, OnInit, HostListener, NgZone, OnDestroy, EventEmitter } from '@angular/core';
import { PhysiotherapyRequestPlannedFormViewModel, OrderDetailInfo, OrderInfo, TreatmentDiagnosisUnitInfo, TreatmentUnitAndRequest } from './PhysiotherapyRequestPlannedFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { plainToClass } from 'NebulaClient/ClassTransformer';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { PhysiotherapyRequest } from 'NebulaClient/Model/AtlasClientModel';
import { BaseTreatmentMaterial } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';


//<atlas-form-editor  için
import { NqlQueryService } from 'app/QueryList/Services/nql-query.service';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
//

import { PhysiotherapyOrderPlannedFormViewModel, PhysiotherapyOrderComponentInfoViewModel } from './PhysiotherapyOrderPlannedFormViewModel';
import { PhysiotherapyOrderPlannedForm } from './PhysiotherapyOrderPlannedForm';
import { PhysiotherapyOrder } from 'NebulaClient/Model/AtlasClientModel';

import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { PhysiotherapyStateEnum } from 'NebulaClient/Model/AtlasClientModel';
import { CommonService } from "ObjectClassService/CommonService";
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';

import { PackageProcedureDefinition } from "NebulaClient/Model/AtlasClientModel";
import { PhysiotherapyReports } from 'NebulaClient/Model/AtlasClientModel';
import { FTRVucutBolgesi } from 'NebulaClient/Model/AtlasClientModel';
import { Guid } from "NebulaClient/Mscorlib/Guid";

import { ObjectContextService } from "Fw/Services/ObjectContextService";
import { TreatmentQueryReportTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { PhysiotherapyOrderDetail } from 'NebulaClient/Model/AtlasClientModel';

import { TTException } from 'NebulaClient/Utils/Exceptions/TTException';

import { DatePipe } from '@angular/common';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { EpisodeActionData } from "Modules/Tibbi_Surec/Hasta_Dosyasi/MainPatientFolderFormViewModel";
import { FormSaveInfo } from 'NebulaClient/Mscorlib/FormSaveInfo';

import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { HelpMenuService } from "Fw/Services/HelpMenuService";
import { PlannedPhyOrderDetailInfo } from './PhysiotherapyRequestPlannedFormViewModel';
import { IDestroyEvent } from 'app/Interfaces/IDestroyEvent';
import { ActiveIDsModel, ClickFunctionParams } from 'app/Fw/Models/ParameterDefinitionModel';
import DateTime from 'app/NebulaClient/System/Time/DateTime';
import { DynamicReportParameters } from '../../../wwwroot/app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInputParam } from '../../../wwwroot/app/Fw/Models/DynamicComponentInputParam';
import { ModalInfo } from '../../../wwwroot/app/Fw/Models/ModalInfo';
import { IModalService } from '../../../wwwroot/app/Fw/Services/IModalService';

@Component({
    selector: 'PhysiotherapyRequestPlannedForm',
    templateUrl: './PhysiotherapyRequestPlannedForm.html',
    providers: [MessageService, NqlQueryService, DatePipe]
})
export class PhysiotherapyRequestPlannedForm extends TTVisual.TTForm implements OnInit, OnDestroy, IDestroyEvent {

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


    sessionRecalculateByDate: TTVisual.ITTCheckBox; //seans öteleme için
    PackageProcedure: TTVisual.ITTObjectListBox;
    TreatmentTypePhysiotherapyReports: TTVisual.ITTEnumComboBox;

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
    //ttdatetimepicker1: TTVisual.ITTDateTimePicker;
    //ttdatetimepicker1: Date = new Date();
    //ttdatetimepicker2: TTVisual.ITTDateTimePicker;
    //ttdatetimepicker2: Date = new Date();
    LastOrderDetailResponsiblePhysiotherapist: TTVisual.ITTObjectListBox;
    UBBCode: TTVisual.ITTTextBoxColumn;
    showAnamnesisInfo: boolean = false;
    public GridTreatmentMaterialsColumns = [];
    public physiotherapyRequestPlannedFormViewModel: PhysiotherapyRequestPlannedFormViewModel = new PhysiotherapyRequestPlannedFormViewModel();
    public get _PhysiotherapyRequest(): PhysiotherapyRequest {
        return this._TTObject as PhysiotherapyRequest;
    }
    private PhysiotherapyRequestPlannedForm_DocumentUrl: string = '/api/PhysiotherapyRequestService/PhysiotherapyRequestPlannedForm';
    constructor(protected httpService: NeHttpService, private datePipe: DatePipe,
        protected objectContextService: ObjectContextService,
        protected messageService: MessageService,
        protected activeUserService: IActiveUserService,
        private sideBarMenuService: ISidebarMenuService,
        protected helpMenuService: HelpMenuService,
        private reportService: AtlasReportService,
        protected modalService: IModalService,
        protected ngZone: NgZone) {
        super('PHYSIOTHERAPYREQUEST', 'PhysiotherapyRequestPlannedForm');
        this._DocumentServiceUrl = this.PhysiotherapyRequestPlannedForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    //load Panel
    public showLoadPanel = false;
    public LoadPanelMessage: string = '';

    loadPanelOperation(visible: boolean, message: string): void {
        this.showLoadPanel = visible;
        if (visible)
            this.LoadPanelMessage = message;
        else
            this.LoadPanelMessage = '';
    }
    // .\load Panel

    //now: Date = new Date();

    public IsRequestAcceptionState: boolean = false;

    public saveOrders: boolean = false;
    public _transDef: TTObjectStateTransitionDef;

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

    refreshDynamicComponent(response: any) {

        this._ViewModel = response;

        this.loadViewModel();

        this.redirectProperties();
        this.PreScript();


        //if (this.openDinamicCompFunc != null) {
        //    this.openDinamicCompFunc(this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.ObjectID, "PHYSIOTHERAPYREQUEST", null);
        //}
        //else if (this._isFTRworkList == true) {
        //    this.httpService.episodeActionWorkListSharedService.refreshWorklist(true);
        //} 
        //else {
        //    this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("PHYSIOTHERAPYREQUEST", this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.ObjectID, null);
        //}
    }
    refreshDynamicComponentForEpisodeActionWorkList() {
        if (this.openDinamicCompFunc != null) {

        }
        else if (this._isFTRworkList == true) {

        }
        else {
            this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("PHYSIOTHERAPYREQUEST", this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.ObjectID, null);
        }
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);

        this.refreshDynamicComponentForEpisodeActionWorkList();
    }

    protected async setState(transDef: TTObjectStateTransitionDef, saveInfo?: FormSaveInfo): Promise<void> {
        await super.setState(transDef, saveInfo);
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
        const objectIdParam = new GuidParam(this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.ObjectID);
        let reportParameters: any = { 'PHYSIOTHERAPYREQUEST': objectIdParam };
        this.reportService.showReport('PhysiotherapyRequestReport', reportParameters);
    }
    public printFTRTreatmentCardReport() {
        const objectIdParam = new GuidParam(this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.ObjectID);
        let reportParameters: any = { 'PHYSIOTHERAPYREQUEST': objectIdParam };
        this.reportService.showReport('FTRTreatmentCard', reportParameters);
    }
    public printPhysicalTherapyInformationReport() {
        const objectIdParam = new GuidParam(this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.ObjectID);
        let reportParameters: any = { 'PHYSIOTHERAPYREQUEST': objectIdParam };
        this.reportService.showReport('PhysicalTherapyInformation', reportParameters);
    }
    public printPhysicalTherapyRehabilitationReport() {
        const objectIdParam = new GuidParam(this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.ObjectID);
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
        componentInfoViewModel = PhysiotherapyOrderPlannedForm.getComponentInfoViewModel(this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.ObjectID);
        this.physiotherapyOrderQueryParameters = componentInfoViewModel.physiotherapyOrderQueryParameters;
        this.physiotherapyOrderComponentInfo = componentInfoViewModel.physiotherapyOrderComponentInfo;
        this.physiotherapyRequestPlannedFormViewModel.sessionRecalculateByDate = true;
        this.sessionRecalculateByDate.Value = true;

    }

    public showPhysiotherapyOrderList: boolean = false;
    public openPhysiotherapyOrderList() {
        if (this.showPhysiotherapyOrderList == false) {
            let that = this;
            that.httpService.get<any>("api/PhysiotherapyRequestService/GetPhysiotherapyOrderAndData?PhysiotherapyRequestObjectID=" + this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.ObjectID + "&PhysiotherapyRequestObjectDefID=" + this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.ObjectDefID)
                .then(response => {
                    let result: PhysiotherapyRequestPlannedFormViewModel = <PhysiotherapyRequestPlannedFormViewModel>response;

                    this.physiotherapyRequestPlannedFormViewModel.PhysiotherapyOrderList = result.PhysiotherapyOrderList;

                    this.showPhysiotherapyOrderList = true;
                })
                .catch(error => {
                    this.messageService.showError(error);

                });
        }
    }

    public physiotherapyOrderComponentInfo: DynamicComponentInfo;
    public physiotherapyOrderQueryParameters: QueryParams;

    physiotherapyOrderQueryResultLoaded(e: any) {
        PhysiotherapyOrderPlannedForm.physiotherapyOrderQueryResultLoaded(e);
    }


    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
        if (transDef !== null && transDef.ToStateDefID != null) {
            if (transDef.ToStateDefID.id == PhysiotherapyRequest.PhysiotherapyRequestStates.Completed.id && this.physiotherapyRequestPlannedFormViewModel.CanComplatePhysiotherapyRequest == false) {
                let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M21498", "Seans Sonlandırma!"), i18n("M22719", "Tamamlanmamış İşlemleriniz Bulunmaktadır!\r\n Devam Etmeniz durumunda Tamamlanmamış İşlemleriniz Durdurulacaktır! \r\n\r\n Devam etmek istiyor musunuz?"));
                if (messageResult === "E") {
                } else {
                    throw new TTException(i18n("M21497", "Seans Sonlandırma işlemi gerçekleştirilmedi!"));
                }
            }
        }
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

    public selectedRowKeysResultList: Array<PlannedPhyOrderDetailInfo> = [];
    public selectedRowKeys: any = [];

    async selectionOrderDetailChange(value: any): Promise<void> {
        let i = 0;
        this.selectedRowKeysResultList = [];
        value.selectedRowKeys.sort(); //key listesini data listesi ile aynı sıraya getirmek için sıralıyoruz
        for (let selectedDetail of value.selectedRowsData) {
            if (selectedDetail.ApplicationAreaDef == "") {
                let SelectedDetailItem = this.physiotherapyRequestPlannedFormViewModel.OrderDetailInfoList.find(x => x.KeyNumber == value.selectedRowKeys[i]);
                for (let selectedOrderDetail of SelectedDetailItem.OrderDetailList) {
                    this.selectedRowKeysResultList.push(selectedOrderDetail);
                }
            } else {
                let SelectedDetailItem: PlannedPhyOrderDetailInfo = selectedDetail;
                this.selectedRowKeysResultList.push(SelectedDetailItem);
            }
            i++;
        }
        this.physiotherapyRequestPlannedFormViewModel.selectedRowKeysResultList = this.selectedRowKeysResultList;
    }

    async onRowUpdating(value: any): Promise<void> {
        if (value.oldData.OrderDetailCurrentStateDefID == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed) {
            this.messageService.showInfo(i18n("M22714", "Tamamlandı Durumunda Olan İşlemlerin Tarihini Değiştiremezsiniz!"));
            value.newData.PlannedDate = value.oldData.PlannedDate;
        } else {
            let _sessionNumber: number = value.oldData.SessionNumber;
            let approvedTransactionCount: number = 0; //Onaylanacak statusündeki işlemler

            if (_sessionNumber != null) {
                for (let i = 0; i < this.physiotherapyRequestPlannedFormViewModel.OrderDetailInfoList.length; i++) {
                    if (this.physiotherapyRequestPlannedFormViewModel.OrderDetailInfoList[i].SessionNumber == _sessionNumber.toString() && this.physiotherapyRequestPlannedFormViewModel.OrderDetailInfoList[i].OrderDetailCurrentStateDefID == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed) {
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
                    if (value.oldData.OrderDetailCurrentStateDefID == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed) {
                        this.messageService.showInfo(i18n("M22714", "Tamamlandı Durumunda Olan İşlemlerin Tarihini Değiştiremezsiniz!"));
                        value.newData.PlannedDate = value.oldData.PlannedDate;
                    } else {
                        value.oldData.PlannedDate = value.newData.PlannedDate;
                        if (_sessionNumber != null) {
                            for (let i = 0; i < this.physiotherapyRequestPlannedFormViewModel.OrderDetailInfoList.length; i++) {//Mevcut seansa ait tüm tarihler değiştiriliyor
                                if (this.physiotherapyRequestPlannedFormViewModel.OrderDetailInfoList[i].SessionNumber == _sessionNumber.toString()) {
                                    this.physiotherapyRequestPlannedFormViewModel.OrderDetailInfoList[i].PlannedDate = value.newData.PlannedDate;
                                    this.physiotherapyRequestPlannedFormViewModel.ChangedOrderDetail = this.physiotherapyRequestPlannedFormViewModel.OrderDetailInfoList[i];
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

    public loadPhysiotherapyOrderDetailRow(value: any) {

        let _data: PlannedPhyOrderDetailInfo = value.data as PlannedPhyOrderDetailInfo;
        if (_data != null && _data.IsAdditionalProcess == true) {
            value.rowElement.firstItem().style.backgroundColor = '#cfcdda';
        }

        if (_data != null && _data.PhysiotherapyState == PhysiotherapyStateEnum._Complated.description) {
            value.cells[1].cellElement.firstItem().style.backgroundColor = '#BAE8BA';
            //value.rowElement.firstItem().style.backgroundColor = '#BAE8BA';//'#8AD38A';//'#5cb85c';83c983
        }

        if (_data != null && _data.PhysiotherapyState == PhysiotherapyStateEnum._NotCome.description) {
            value.cells[1].cellElement.firstItem().style.backgroundColor = '#94C3EA';
            //value.rowElement.firstItem().style.backgroundColor = '#94C3EA';//'#65A5DA';//'#428bca';
        }

        if (_data != null && _data.PhysiotherapyState == PhysiotherapyStateEnum._Aborted.description) {
            value.cells[1].cellElement.firstItem().style.backgroundColor = '#FFE992';
            //value.rowElement.firstItem().style.backgroundColor = '#FFE992'; //'#F9D543';//'#F1C40F';
        }
    }

    //#endregion PhysiotherapyOrderDetail Grid İşlemleri


    //#region Fizyoterapi Button İşlemleri *******************************************************************

    //İstek iptal
    public async cancelPhysiotherapyRequest() {
        let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M14075", "F.T.R. İstek İptal"), i18n("M14072", "F.T.R. isteğini iptal etmeniz durumunda tekrar işlem yapılamayacaktır! \r\n\r\n Devam etmek istiyor musunuz?"));
        if (messageResult === "E") {

            let that = this;
            that.httpService.post<any>("api/PhysiotherapyRequestService/CancelPhysiotherapyRequestAndRefresh", this.physiotherapyRequestPlannedFormViewModel)
                .then(response => {
                    this.refreshDynamicComponent(response);
                    that.httpService.episodeActionWorkListSharedService.refreshWorklist(true);

                    this.messageService.showSuccess(i18n("M14071", "F.T.R. İsteği Başarılı Bir Şekilde İptal Edildi"));
                })
                .catch(error => {
                    this.messageService.showError(error);

                });
        }
    }

    //Seçili Kayıtları Tamamlama
    showCompleteRecordsPopup: boolean = false;

    public openReportSelection: boolean = false;
    public async completeRecordsStart() {
        //seçili kayıtlarda paket yoksa
        let isPackageExists = 0;

        for (let i = 0; i < this.selectedRowKeysResultList.length; i++) {

            if (this.selectedRowKeysResultList[i].PhyOrderIsPackageExists == false) {
                isPackageExists++;
            }
        }
        //for (let i = 0; i < this.selectedRowKeysResultList.length; i++) {
        //    let _ObjectID: Guid = this.selectedRowKeysResultList[i].OrderObjectID;
        //    let order: PhysiotherapyOrder = await this.objectContextService.getObjectWithDefName<PhysiotherapyOrder>(_ObjectID, 'PhysiotherapyOrder');

        //    if (order.PackageProcedure == null) {
        //        isPackageExists++;
        //    }
        //}
        if (this.selectedRowKeysResultList.length == isPackageExists) {//seçili orderlarda paketi olmayan order tüm seçili order sayısına eşitse paket seçimi zorunlu
            this.openReportSelection = true;
        }

        if (this.openReportSelection == true) {
            this.ShowTreatmentTypeModal();
        }

        this.showCompleteRecordsPopup = true;
    }

    public async SaveCompleteRecordsModal() {
        this.loadPanelOperation(true, 'İşlemler tamamlanıyor. Lütfen Bekleyiniz.');
        let response = await this.completeRecords();
        this.showCompleteRecordsPopup = !response;
    }

    public CancelCompleteRecordsModal() {
        this.showCompleteRecordsPopup = false;
    }

    public async completeRecords() {

        console.log(this.selectedRowKeysResultList);

        let _objectIDList: Array<string> = [];

        if (this.selectedRowKeysResultList.length == 0) {
            this.messageService.showReponseError(i18n("M16878", "İşlem seçilmediği için tamamlama işlemine devam edilemedi."));
            return false;
        }

        let currentDate: Date = await (CommonService.RecTime());
        currentDate = plainToClass(Date, currentDate);

        let upComingTransactionCount: number = 0; //ileri tarihli işlemler
        let approvedTransactionCount: number = 0; //Onaylanacak statusü dışındaki işlemler

        for (let i = 0; i < this.selectedRowKeysResultList.length; i++) {
            if (this.selectedRowKeysResultList[i].OrderDetailCurrentStateDefID.valueOf() !== PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Execution.id && this.selectedRowKeysResultList[i].OrderDetailCurrentStateDefID.valueOf() !== PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed.id) {
                approvedTransactionCount++;
            }
            else if (new Date(this.datePipe.transform(this.selectedRowKeysResultList[i].OrderDetailPlannedDate, 'MM.dd.yyyy')) > new Date(this.datePipe.transform(currentDate, 'MM.dd.yyyy'))) {
                upComingTransactionCount++;
            }
        }

        if (approvedTransactionCount > 0) {
            this.messageService.showInfo(i18n("M24544", "Yeni Durumunda Olmayan İşlemleri Tamamlayamazsınız!"));
            this.loadPanelOperation(false, '');
            return false;
        } else if (upComingTransactionCount > 0) {
            this.messageService.showInfo(i18n("M16406", "İleri Tarihli İşlemleri Bugünden Tamamlayamazsınız!"));
            this.loadPanelOperation(false, '');
            return false;
        } else {

            if (this.openReportSelection == true && this.physiotherapyRequestPlannedFormViewModel.PackageProcedure == null) {
                this.messageService.showReponseError(i18n("M18389", "Lütfen Paket Seçiniz."));
                this.loadPanelOperation(false, '');
                return false;
            }

            if (this.physiotherapyRequestPlannedFormViewModel.LastOrderDetailResponsiblePhysiotherapist == null || this.physiotherapyRequestPlannedFormViewModel.LastOrderDetailStartDate == null || this.physiotherapyRequestPlannedFormViewModel.LastOrderDetailFinishDate == null) {
                this.messageService.showReponseError(i18n("M18371", "Lütfen Fizyoterapist ve Saat Seçiniz!"));
                this.loadPanelOperation(false, '');
                return false;
            } else {

                for (let i = 0; i < this.selectedRowKeysResultList.length; i++) {
                    this.selectedRowKeysResultList[i].CurrentUserObjectId = this.activeUserService.ActiveUser.UserObject.ObjectID; //İşlemi yapan kişi belirleniyor

                    this.selectedRowKeysResultList[i].StartDate = this.physiotherapyRequestPlannedFormViewModel.LastOrderDetailStartDate;
                    this.selectedRowKeysResultList[i].FinishDate = this.physiotherapyRequestPlannedFormViewModel.LastOrderDetailFinishDate;
                    this.selectedRowKeysResultList[i].ResponsiblePhysiotherapist = this.physiotherapyRequestPlannedFormViewModel.LastOrderDetailResponsiblePhysiotherapist; //this.TTListBoxPhysiotherapist.SelectedObject as ResUser;

                }

                this.physiotherapyRequestPlannedFormViewModel.selectedRowKeysResultList = this.selectedRowKeysResultList;

                let that = this;
                that.httpService.post<any>("api/PhysiotherapyRequestService/CompleteSelectedProceduresByID", this.physiotherapyRequestPlannedFormViewModel)
                    .then(response => {
                        this.refreshDynamicComponent(response);
                        this.showCompleteRecordsPopup = false;

                        this.messageService.showSuccess(i18n("M21531", "Seçilen İşlemler Başarılı Bir Şekilde Tamamlandı"));
                        this.loadPanelOperation(false, '');
                        return true;
                    })
                    .catch(error => {
                        this.messageService.showError(error);
                        this.loadPanelOperation(false, '');
                        return false;
                    });

            }
        }
    }


    //Seçili Kayıtları Silme/İptal
    public deleteRecords() {

        console.log(this.selectedRowKeysResultList);

        let _objectIDList: Array<string> = [];

        if (this.selectedRowKeysResultList.length == 0) {
            this.messageService.showReponseError(i18n("M16877", "İşlem seçilmediği için silme işlemine devam edilemedi."));
            return false;
        }

        let approvedTransactionCount: number = 0; //Onaylanacak statusü dışındaki işlemler

        for (let i = 0; i < this.selectedRowKeysResultList.length; i++) {
            if (this.selectedRowKeysResultList[i].OrderDetailCurrentStateDefID.valueOf() == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed.id)//"Tamamlandı durumunda olanlar"
            {
                approvedTransactionCount++;
            }
        }
        if (approvedTransactionCount > 0) {
            this.messageService.showInfo(i18n("M22713", "Tamamlandı Durumunda Olan İşlemleri Silemezsiniz!"));
        } else {

            for (let i = 0; i < this.selectedRowKeysResultList.length; i++) {
                this.selectedRowKeysResultList[i].CurrentUserObjectId = this.activeUserService.ActiveUser.UserObject.ObjectID; //İşlemi yapan kişi belirleniyor
            }

            let that = this;
            that.httpService.post<any>("api/PhysiotherapyRequestService/DeleteSelectedProceduresByID", this.selectedRowKeysResultList)
                .then(response => {
                    this.refreshDynamicComponent(response);

                    this.messageService.showSuccess(i18n("M21530", "Seçilen İşlemler Başarılı Bir Şekilde Silindi"));
                })
                .catch(error => {
                    this.messageService.showError(error);

                });
        }
    }

    //Saat değiştirme
    showDateChangePopup: boolean = false;
    showDateRecalculatePopup: boolean = false;
    minSessionChangedDate: Date;
    async openDateRecords() {
        let isCompletedDetailExist: boolean = false;

        if (this.selectedRowKeysResultList.length == 0) {
            this.messageService.showReponseError(i18n("M16878", "İşlem seçilmediği için tarih değiştirme işlemine devam edilemedi."));
            return false;
        }

        for (let phyOrderDetail of this.selectedRowKeysResultList) {
            if (phyOrderDetail.OrderDetailCurrentStateDefID.valueOf() == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed.id) {
                isCompletedDetailExist = true;
            }
        }

        if (isCompletedDetailExist) {
            this.messageService.showInfo(i18n("M22714", "Tamamlandı Durumunda Olan İşlemlerin Tarihini Değiştiremezsiniz!"));
        } else {
            this.showDateChangePopup = true;
        }
        this.minSessionChangedDate = this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.PhysiotherapyRequestDate;
    }

    public async askSaveDateRecords() {// 'E' ise seans öteleme 'H' ise sadece seçili seansın tarih değişimi yapılacak
        let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M14075", "F.T.R. Seans Ötleme"), i18n("M14072", "Mevcut seans sonrasındaki tüm seansları ötelemek istiyor musunuz?"));
        if (messageResult === "E") {
            this.physiotherapyRequestPlannedFormViewModel.IsSessionRecalculate = true;
            this.saveDateRecords();
        } else if (messageResult === "H") {
            this.physiotherapyRequestPlannedFormViewModel.IsSessionRecalculate = false;
            this.saveDateRecords();
        }
    }

    public saveDateRecords() {
        let that = this;
        that.httpService.post<any>("api/PhysiotherapyRequestService/ChangeProcedureDates", this.physiotherapyRequestPlannedFormViewModel)
            .then(response => {
                //if (this.openDinamicCompFunc != null) {
                //    this.openDinamicCompFunc(this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.ObjectID, "PHYSIOTHERAPYREQUEST", null);
                //} else {
                //    this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("PHYSIOTHERAPYREQUEST", this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.ObjectID, null);
                //}

                this.refreshDynamicComponent(response);

                if (this.physiotherapyRequestPlannedFormViewModel.IsSessionRecalculate) {
                    this.messageService.showSuccess(i18n("M21528", "Seçilen İşlemler Başarılı Bir Şekilde Ötelendi"));
                } else {
                    this.messageService.showSuccess(i18n("M21528", "Seçilen Seansların Tarihleri Başarılı Bir Şekilde Değiştirildi"));
                }
            })
            .catch(error => {
                this.messageService.showError(error);
            });

        this.selectedRowKeys = [];
        this.physiotherapyRequestPlannedFormViewModel.selectedRowKeysResultList = this.selectedRowKeysResultList;
        this.selectedRowKeysResultList = [];

        this.showDateChangePopup = false;
        this.showDateRecalculatePopup = false;
        this.physiotherapyRequestPlannedFormViewModel.IsSessionRecalculate = false;
    }
    public CancelDateRecords() {
        this.showDateChangePopup = false;
        this.showDateRecalculatePopup = false;
        this.physiotherapyRequestPlannedFormViewModel.IsSessionRecalculate = false;
    }

    //Seçili Kayıtları Durdurma
    public abortRecords() {

        console.log(this.selectedRowKeysResultList);

        let _objectIDList: Array<string> = [];

        if (this.selectedRowKeysResultList.length == 0) {
            this.messageService.showReponseError(i18n("M16875", "İşlem seçilmediği için durdurma işlemine devam edilemedi."));
            return false;
        }

        let approvedTransactionCount: number = 0; //Onaylanacak statusü dışındaki işlemler

        for (let i = 0; i < this.selectedRowKeysResultList.length; i++) {
            if (this.selectedRowKeysResultList[i].OrderDetailCurrentStateDefID.valueOf() == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed.id)//"Tamamlandı durumunda olanlar"
            {
                approvedTransactionCount++;
            }
        }
        if (approvedTransactionCount > 0) {
            this.messageService.showInfo(i18n("M22712", "Tamamlandı Durumunda Olan İşlemleri Durduramazsınız!"));
        } else {

            for (let i = 0; i < this.selectedRowKeysResultList.length; i++) {
                this.selectedRowKeysResultList[i].CurrentUserObjectId = this.activeUserService.ActiveUser.UserObject.ObjectID; //İşlemi yapan kişi belirleniyor
            }

            let that = this;
            that.httpService.post<any>("api/PhysiotherapyRequestService/AbortSelectedProceduresByID", this.selectedRowKeysResultList)
                .then(response => {
                    this.refreshDynamicComponent(response);

                    this.messageService.showSuccess(i18n("M21526", "Seçilen İşlemler Başarılı Bir Şekilde Durduruldu"));
                })
                .catch(error => {
                    this.messageService.showError(error);

                });
        }
    }

    //Seçili Kayıtlardaki hasta gelmedi
    public async notComeRecords() {


        console.log(this.selectedRowKeysResultList);

        let _objectIDList: Array<string> = [];

        if (this.selectedRowKeysResultList.length == 0) {
            this.messageService.showReponseError(i18n("M16876", "İşlem seçilmediği için hasta gelmedi işlemine devam edilemedi."));
            return false;
        }

        let currentDate: Date = await (CommonService.RecTime());
        currentDate = plainToClass(Date, currentDate);

        let upComingTransactionCount: number = 0; //ileri tarihli işlemler
        let approvedTransactionCount: number = 0; //Onaylanacak statusü dışındaki işlemler

        for (let i = 0; i < this.selectedRowKeysResultList.length; i++) {
            if (this.selectedRowKeysResultList[i].OrderDetailCurrentStateDefID.valueOf() == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed.id || this.selectedRowKeysResultList[i].OrderDetailCurrentStateDefID.valueOf() == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Cancelled.id) {
                approvedTransactionCount++;
            }
            else if (new Date(this.datePipe.transform(this.selectedRowKeysResultList[i].OrderDetailPlannedDate, 'MM.dd.yyyy')) > new Date(this.datePipe.transform(currentDate, 'MM.dd.yyyy'))) {
                upComingTransactionCount++;
            }
        }

        if (approvedTransactionCount > 0) {
            this.messageService.showInfo(i18n("M22711", "Tamamlandı Durumunda Olan İşlemlerde Hasta Gelmedi İşlemi Yapamazsınız!"));
        } else if (upComingTransactionCount > 0) {
            this.messageService.showInfo(i18n("M16405", "İleri Tarihli İşlemlere Bugünden Hasta Gelmedi İşlemi Yapamazsınız!"));
        } else {
            for (let i = 0; i < this.selectedRowKeysResultList.length; i++) {
                this.selectedRowKeysResultList[i].CurrentUserObjectId = this.activeUserService.ActiveUser.UserObject.ObjectID; //İşlemi yapan kişi belirleniyor
            }

            let that = this;
            that.httpService.post<any>("api/PhysiotherapyRequestService/NotComeSelectedProceduresByID", this.selectedRowKeysResultList)
                .then(response => {
                    this.refreshDynamicComponent(response);

                    this.messageService.showSuccess(i18n("M21525", "Seçilen İşlemler Başarılı Bir Şekilde Değiştirildi"));
                })
                .catch(error => {
                    this.messageService.showError(error);

                });
        }

    }

    //Yapılan İşlemleri Geri Alma: İşlem new yapılıyor
    public undoRecords() {
        let that = this;
        that.httpService.post<any>("api/PhysiotherapyRequestService/UndoProcedures", this.selectedRowKeysResultList)
            .then(response => {
                this.UndoLastTransition_SelectedEpisodeAction();
                this.refreshDynamicComponent(response);

                this.messageService.showSuccess(i18n("M21527", "Seçilen İşlemler Başarılı Bir Şekilde Geri Alındı"));
            })
            .catch(error => {
                this.messageService.showError(error);

            });
    }

    //#endregion Fizyoterapi Button İşlemleri


    //#region PhysiotherapyOrder Grid İşlemleri

    public selectedOrderRowKeysResult: OrderInfo = new OrderInfo;
    public selectedOrderItemInfo: PhysiotherapyOrderPlannedFormViewModel = new PhysiotherapyOrderPlannedFormViewModel;
    public IsSelectedObjExist: boolean = false;

    async selectionOrderChange(value: any): Promise<void> {

        let component = value.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 500)) {
            //Double click code
            this.loadPanelOperation(true, i18n("M14461", "Form hazırlanıyor, lütfen bekleyiniz."));
            console.log();

            let that = this;
            if (this._readOnlyByCode != true) {

                let plannedOrdersForm_DocumentUrl: string = '/api/PhysiotherapyOrderService/GetPhysiotherapyOrderPlannedFormViewModelById?orderInfo';
                this.httpService.post<PhysiotherapyOrderPlannedFormViewModel>("api/PhysiotherapyOrderService/GetPhysiotherapyOrderPlannedFormViewModelById?orderInfo", value.data, PhysiotherapyOrderPlannedFormViewModel).then(response => {
                    let result: PhysiotherapyOrderPlannedFormViewModel = <PhysiotherapyOrderPlannedFormViewModel>response;

                    this.IsSelectedObjExist = true;
                    this.physiotherapyRequestPlannedFormViewModel.selectedPhysiotherapyOrderPlannedFormViewModel = result;
                    this.selectedOrderItemInfo = result;
                    this.selectedOrderItemInfo.ProcedureObjectDataSource = this.physiotherapyRequestPlannedFormViewModel.ProcedureObjectDataSource;

                    this.loadPanelOperation(false, '');
                    //this.IsPanelOpen = true;
                });

            }
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

    public EndSessionColumns = [
        {
            'caption': "Tedavi Ünitesi",
            dataField: 'TreatmentDiagnosisUnitName',
            allowSorting: true,
        },
        {
            'caption': "Durumu",
            dataField: 'State'
        }
    ];

    showCompleteSessionPopUp: boolean = false;
    openCompleteSessionPopup() {
        if (this.physiotherapyRequestPlannedFormViewModel.TreatmentDiagnosisUnitInfos != null) {//eğer daha önce tedavi üniteleri yüklenmiş ise tekrar yüklenmesin
            this.showCompleteSessionPopUp = true;
        } else {
            let that = this;
            that.httpService.get<any>("api/PhysiotherapyRequestService/GetTreatmentDiagnosisUnitInfos?PhysiotherapyRequestObjectID=" + this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.ObjectID)
                .then(response => {
                    this.physiotherapyRequestPlannedFormViewModel.TreatmentDiagnosisUnitInfos = response;
                    this.showCompleteSessionPopUp = true;
                })
                .catch(error => {
                    this.messageService.showError(error);

                });
        }

    }
    selectedUnits: Array<any> = new Array<TreatmentDiagnosisUnitInfo>();
    selectionUnits(data) {
        this.selectedUnits = data.selectedRowsData;
    }
    public async CompleteSessionsByUnit() {
        let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M21493", "Seans Sonlandırma"), i18n("M21503", "Seansı sonlandırmanız durumunda devam eden tedaviler durdurulacaktır. \r\n\r\n Devam etmek istiyor musunuz?"));
        if (messageResult === "E") {
            let that = this;
            for (let unit of this.selectedUnits) {
                that.httpService.get<any>("api/PhysiotherapyRequestService/CompleteSelectedSessionsByUnit?PhysiotherapyRequestObjectID=" + this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.ObjectID + "&PhysiotherapyRequestObjectDefID=" + this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.ObjectDefID + "&TreatmentDiagnosisUnitID=" + unit.TreatmentDiagnosisUnitID + "&TreatmentNote=" + unit.TreatmentNote + "&TreatmentNoteId=" + unit.TreatmentNoteId)
                    .then(response => {
                        this.refreshDynamicComponent(response);
                        this.showCompleteSessionPopUp = false;

                        this.messageService.showSuccess(i18n("M21531", "Seçilen İşlemler Başarılı Bir Şekilde Tamamlandı"));
                        this.showCompleteSessionPopUp = false;

                        return true;
                    })
                    .catch(error => {
                        this.showCompleteSessionPopUp = true;
                        this.messageService.showError(error);
                        return false;
                    });
            }

        }

    }
    public async UndoCompleteSessionsByUnit() {
        if (this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest != null && (this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.CurrentStateDefID.valueOf() == PhysiotherapyRequest.PhysiotherapyRequestStates.Completed.id || this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.CurrentStateDefID.valueOf() == PhysiotherapyRequest.PhysiotherapyRequestStates.Cancelled.id)) {
            let massage: string = "F.T.R. Tedavisi ";
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'İşlem Geri Alma',
                massage + i18n("M14750", "geri alınacaktır.Devam etmek istediğinize emin misiniz? "));
            if (result === 'V') {
                ServiceLocator.MessageService.showSuccess(i18n("M14753", "Geri Alma İşleminden Vazgeçildi"));
            }
            else {
                let that = this;
                let treatmentUnitAndRequest: TreatmentUnitAndRequest = new TreatmentUnitAndRequest;
                treatmentUnitAndRequest.PhysiotherapyRequestId = this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.ObjectID;
                treatmentUnitAndRequest.PhysiotherapyRequestDefId = this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.ObjectDefID;
                treatmentUnitAndRequest.TreatmentDiagnosisInfoList = this.selectedUnits;

                this.httpService.post<any>("api/PhysiotherapyRequestService/UndoSelectedSessionsByUnit", treatmentUnitAndRequest)
                    .then(response => {
                        this.refreshDynamicComponent(response);
                        this.showCompleteSessionPopUp = false;

                        this.messageService.showSuccess(i18n("M21531", "Seçilen İşlemler Başarılı Bir Şekilde Geri Alındı"));
                        this.showCompleteSessionPopUp = false;

                        return true;
                    })
                    .catch(error => {
                        this.showCompleteSessionPopUp = true;
                        this.messageService.showError(error);
                        return false;
                    });
            }
        } else {//request geri alınmayacaksa sormaya gerek yok
            let that = this;
            let treatmentUnitAndRequest: TreatmentUnitAndRequest = new TreatmentUnitAndRequest;
            treatmentUnitAndRequest.PhysiotherapyRequestId = this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.ObjectID;
            treatmentUnitAndRequest.PhysiotherapyRequestDefId = this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.ObjectDefID;
            treatmentUnitAndRequest.TreatmentDiagnosisInfoList = this.selectedUnits;

            this.httpService.post<any>("api/PhysiotherapyRequestService/UndoSelectedSessionsByUnit", treatmentUnitAndRequest)
                .then(response => {
                    this.refreshDynamicComponent(response);
                    this.showCompleteSessionPopUp = false;

                    this.messageService.showSuccess(i18n("M21531", "Seçilen İşlemler Başarılı Bir Şekilde Geri Alındı"));
                    this.showCompleteSessionPopUp = false;

                    return true;
                })
                .catch(error => {
                    this.showCompleteSessionPopUp = true;
                    this.messageService.showError(error);
                    return false;
                });
        }

    }

    //#endregion PhysiotherapyOrder Grid İşlemleri

    /* Yeni İşlem/Ek İşlem Prosedürleri */
    public newPhysiotherapyOrder() {
        let that = this;
        let plannedOrdersForm_DocumentUrl: string = '/api/PhysiotherapyOrderService/GetNewPhysiotherapyOrderPlannedFormViewModel?physiotherapyRequest';

        this.httpService.post<PhysiotherapyOrderPlannedFormViewModel>("api/PhysiotherapyOrderService/GetNewPhysiotherapyOrderPlannedFormViewModel?physiotherapyRequest", this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest, PhysiotherapyOrderPlannedFormViewModel).then(response => {
            let result: PhysiotherapyOrderPlannedFormViewModel = <PhysiotherapyOrderPlannedFormViewModel>response;

            this.IsSelectedObjExist = true;
            this.physiotherapyRequestPlannedFormViewModel.selectedPhysiotherapyOrderPlannedFormViewModel = result;
            this.selectedOrderItemInfo = result;
            this.selectedOrderItemInfo.ProcedureObjectDataSource = this.physiotherapyRequestPlannedFormViewModel.ProcedureObjectDataSource;
            //this.IsPanelOpen = true;
        });
    }
    public cancelNewPhysiotherapyOrder() {
        this.IsSelectedObjExist = false;
        this.physiotherapyRequestPlannedFormViewModel.selectedPhysiotherapyOrderPlannedFormViewModel = null;
        this.selectedOrderItemInfo = new PhysiotherapyOrderPlannedFormViewModel;
        this.selectedOrderItemInfo.ProcedureObjectDataSource = [];
    }

    public loadPlanningGridContainerRow(value: any) {

        let _data: OrderDetailInfo = value.data as OrderDetailInfo;
        if (_data != null && _data.PhysiotherapyState == PhysiotherapyStateEnum._Complated.description) {
            value.rowElement.firstItem().style.backgroundColor = '#BAE8BA'; //'#8AD38A';//'#5cb85c';83c983
        }

        if (_data != null && _data.PhysiotherapyState == PhysiotherapyStateEnum._NotCome.description) {
            value.rowElement.firstItem().style.backgroundColor = '#94C3EA'; //'#65A5DA';//'#428bca';
        }

        if (_data != null && _data.PhysiotherapyState == PhysiotherapyStateEnum._Aborted.description) {
            value.rowElement.firstItem().style.backgroundColor = '#FFF0B6'; //'#FFE992'; //'#F9D543';//'#F1C40F';
        }
    }

    //#region Rapor İşlemleri
    selectedReportItem: PhysiotherapyReports;
    selectedApplicarionArea: FTRVucutBolgesi;
    selectedPackageProcedureDefinition: PackageProcedureDefinition;
    async selectionReportChanged(value: any): Promise<void> {
        if (value) {
            this.physiotherapyRequestPlannedFormViewModel.Report = value.selectedRowsData[0].ReportObj as PhysiotherapyReports;
            this.physiotherapyRequestPlannedFormViewModel.PackageProcedure = value.selectedRowsData[0].PackageProcedureDefinition as PackageProcedureDefinition;
        }
    }
    rowPrepared(row: any) {
    }

    showPhysiotherapyReportPopup: boolean = false;
    showTreatmentTypePopup: boolean = false;
    ShowTreatmentTypeModal() {
        this.showTreatmentTypePopup = true;
    }
    async CancelTreatmentType() {
        if (this.physiotherapyRequestPlannedFormViewModel.Report == null) {
            let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20837", "Rapor Seçimi İptal"), i18n("M20838", "Rapor seçmeden devam etmeniz durumunda işlem ücretlendirilecektir! \r\n\r\n Devam etmek istiyor musunuz?"));
            if (messageResult === "E") {
                this.showTreatmentTypePopup = false;
                this.PackageProcedure.Required = true;
            }
        } else {
            if (this.physiotherapyRequestPlannedFormViewModel.Report.ReportNo == null) {
                let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20837", "Rapor Seçimi İptal"), i18n("M20838", "Rapor seçmeden devam etmeniz durumunda işlem ücretlendirilecektir! \r\n\r\n Devam etmek istiyor musunuz?"));
                if (messageResult === "E") {
                    this.showTreatmentTypePopup = false;
                    this.PackageProcedure.Required = true;
                }
            } else {
                this.showTreatmentTypePopup = false;
                this.PackageProcedure.Required = true;
            }
        }
    }
    SaveTreatmentType() {
        if (this.physiotherapyRequestPlannedFormViewModel.ReportItemList == null) {
            this.httpService.post<PhysiotherapyOrderPlannedFormViewModel>("api/PhysiotherapyOrderService/GetReportInfoByTreatmentType?treatmentType", this.physiotherapyRequestPlannedFormViewModel.TreatmentType, PhysiotherapyOrderPlannedFormViewModel).then(response => {
                let result: PhysiotherapyOrderPlannedFormViewModel = <PhysiotherapyOrderPlannedFormViewModel>response;

                this.physiotherapyRequestPlannedFormViewModel.ReportItemList = result.ReportItemList;
                this.physiotherapyRequestPlannedFormViewModel.Message = result.Message;

                this.showTreatmentTypePopup = false;
                this.showPhysiotherapyReportPopup = true;

                if (this.physiotherapyRequestPlannedFormViewModel.Message != null && this.physiotherapyRequestPlannedFormViewModel.Message != "") {
                    TTVisual.InfoBox.Alert(this.physiotherapyRequestPlannedFormViewModel.Message);
                }
            }).catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.showTreatmentTypePopup = false;
            });
        } else {
            this.showTreatmentTypePopup = false;
            this.showPhysiotherapyReportPopup = true;

            if (this.physiotherapyRequestPlannedFormViewModel.Message != null && this.physiotherapyRequestPlannedFormViewModel.Message != "") {
                TTVisual.InfoBox.Alert(this.physiotherapyRequestPlannedFormViewModel.Message);
            }
        }
    }
    async CancelPhysiotherapyReport() {
        if (this.physiotherapyRequestPlannedFormViewModel.Report == null) {
            let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20837", "Rapor Seçimi İptal"), i18n("M20838", "Rapor seçmeden devam etmeniz durumunda işlem ücretlendirilecektir! \r\n\r\n Devam etmek istiyor musunuz?"));
            if (messageResult === "E") {
                this.physiotherapyRequestPlannedFormViewModel.Report = null;
                this.physiotherapyRequestPlannedFormViewModel.PackageProcedure = null;

                this.PackageProcedure.Required = true;

                this.showPhysiotherapyReportPopup = false;
                this.selectedReportItem = null;
            }
        } else {
            if (this.physiotherapyRequestPlannedFormViewModel.Report.ReportNo == null) {
                let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20837", "Rapor Seçimi İptal"), i18n("M20838", "Rapor seçmeden devam etmeniz durumunda işlem ücretlendirilecektir! \r\n\r\n Devam etmek istiyor musunuz?"));
                if (messageResult === "E") {
                    this.physiotherapyRequestPlannedFormViewModel.Report = null;
                    this.physiotherapyRequestPlannedFormViewModel.PackageProcedure = null;

                    this.PackageProcedure.Required = true;

                    this.showPhysiotherapyReportPopup = false;
                    this.selectedReportItem = null;
                }
            } else {
                this.physiotherapyRequestPlannedFormViewModel.Report = null;
                this.physiotherapyRequestPlannedFormViewModel.PackageProcedure = null;

                this.PackageProcedure.Required = true;

                this.showPhysiotherapyReportPopup = false;
                this.selectedReportItem = null;
            }
        }
    }
    async SavePhysiotherapyReportModal() {
        if (this.physiotherapyRequestPlannedFormViewModel.Report != null && this.physiotherapyRequestPlannedFormViewModel.PackageProcedure != null) {
            this.PackageProcedure.ReadOnly = true;
            this.PackageProcedure.Required = true;
            this.showPhysiotherapyReportPopup = false;
            this.selectedReportItem = null;
        }
        else {

            if (this.physiotherapyRequestPlannedFormViewModel.Report == null) {
                let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20837", "Rapor Seçimi İptal"), i18n("M20838", "Rapor seçmeden devam etmeniz durumunda işlem ücretlendirilecektir! \r\n\r\n Devam etmek istiyor musunuz?"));
                if (messageResult === "E") {
                    this.PackageProcedure.ReadOnly = true;
                    this.PackageProcedure.Required = true;

                    this.showPhysiotherapyReportPopup = false;
                    this.selectedReportItem = null;
                }
            } else {
                if (this.physiotherapyRequestPlannedFormViewModel.Report.ReportNo == null) {
                    let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20837", "Rapor Seçimi İptal"), i18n("M20838", "Rapor seçmeden devam etmeniz durumunda işlem ücretlendirilecektir! \r\n\r\n Devam etmek istiyor musunuz?"));
                    if (messageResult === "E") {
                        this.PackageProcedure.ReadOnly = true;
                        this.PackageProcedure.Required = true;

                        this.showPhysiotherapyReportPopup = false;
                        this.selectedReportItem = null;
                    }
                } else {
                    this.PackageProcedure.ReadOnly = true;
                    this.PackageProcedure.Required = true;

                    this.showPhysiotherapyReportPopup = false;
                    this.selectedReportItem = null;
                }
            }
        }
    }
    //#endregion Rapor İşlemleri

    public openHastaGecmisiTab: boolean = false;
    public openHastaGecmisi() {
        this.openHastaGecmisiTab = true;
    }

    public openMalzemeSarfTab: boolean = false;
    public openMalzemeSarf() {
        this.openMalzemeSarfTab = true;
    }


    public async UndoLastTransition_SelectedEpisodeAction() {
        if (this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest != null && (this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.CurrentStateDefID.valueOf() == PhysiotherapyRequest.PhysiotherapyRequestStates.Completed.id || this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.CurrentStateDefID.valueOf() == PhysiotherapyRequest.PhysiotherapyRequestStates.Cancelled.id)) {
            let massage: string = "F.T.R. Tedavisi ";
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'İşlem Geri Alma',
                massage + i18n("M14750", "geri alınacaktır.Devam etmek istediğinize emin misiniz? "));
            if (result === 'V') {
                ServiceLocator.MessageService.showSuccess(i18n("M14753", "Geri Alma İşleminden Vazgeçildi"));
            }
            else {
                let that = this;
                let _DocumentServiceUrl: string = "/api/MainPatientFolderService/UndoLastTransitionEAorSPFlowableByObjectId?ObjectId=" + this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.ObjectID.toString();
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

    //#region Tedavi Notu
    showTreatmentNotePopup: boolean = false;
    public TreatmentNoteComponentInfo: DynamicComponentInfo = new DynamicComponentInfo();
    public newTreatmentNote() {

        this.showTreatmentNotePopup = true;
        let _inputParam = {};
        _inputParam['isNewTreatmentNote'] = true;//true->Yeni, false->eski ; Yeni tedavi notu ise not giriş inputu açılacak değilse sadece girilmiş notlar gösterilecek. 

        let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
        //compInfo.objectID = '004b104a-962d-48a5-a292-ea76cbcfa288';
        compInfo.ComponentName = 'PhysiotherapyTreatmentNoteForm';
        compInfo.ModuleName = 'FizyoterapiModule';
        compInfo.ModulePath = 'Modules/Tibbi_Surec/Fizyoterapi_Modulu/FizyoterapiModule';
        compInfo.InputParam = new DynamicComponentInputParam(_inputParam, new ActiveIDsModel(this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.ObjectID, null, null));
        compInfo.CloseWithStateTransition = true;
        compInfo.DestroyComponentOnSave = true;
        compInfo.RefreshComponent = true;

        this.TreatmentNoteComponentInfo = compInfo;
    }

    //#endregion Tedavi Notu

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PhysiotherapyRequest();
        this.physiotherapyRequestPlannedFormViewModel = new PhysiotherapyRequestPlannedFormViewModel();
        this._ViewModel = this.physiotherapyRequestPlannedFormViewModel;
        this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest = this._TTObject as PhysiotherapyRequest;
        this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.TreatmentMaterials = new Array<BaseTreatmentMaterial>();
    }

    protected loadViewModel() {
        let that = this;

        that.physiotherapyRequestPlannedFormViewModel = this._ViewModel as PhysiotherapyRequestPlannedFormViewModel;
        that._TTObject = this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest;
        if (this.physiotherapyRequestPlannedFormViewModel == null)
            this.physiotherapyRequestPlannedFormViewModel = new PhysiotherapyRequestPlannedFormViewModel();
        if (this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest == null)
            this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest = new PhysiotherapyRequest();
        that.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.TreatmentMaterials = that.physiotherapyRequestPlannedFormViewModel.GridTreatmentMaterialsGridList;
        for (let detailItem of that.physiotherapyRequestPlannedFormViewModel.GridTreatmentMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.physiotherapyRequestPlannedFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.physiotherapyRequestPlannedFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.physiotherapyRequestPlannedFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let ozelDurum = that.physiotherapyRequestPlannedFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
        }

        if (this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.CurrentStateDefID.valueOf() != PhysiotherapyRequest.PhysiotherapyRequestStates.RequestAcception.id) {
            //this.IsPanelOpen = false;
        }
        if (this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.CurrentStateDefID.valueOf() == PhysiotherapyRequest.PhysiotherapyRequestStates.RequestAcception.id) {
            this.IsRequestAcceptionState = true;
        }


        this.DropStateButton(PhysiotherapyRequest.PhysiotherapyRequestStates.Cancelled);
        this.DropStateButton(PhysiotherapyRequest.PhysiotherapyRequestStates.Completed);

        if (this.physiotherapyRequestPlannedFormViewModel.TreatmentType == null || this.physiotherapyRequestPlannedFormViewModel.TreatmentType == 0) {
            this.physiotherapyRequestPlannedFormViewModel.TreatmentType = TreatmentQueryReportTypeEnum.FTR;
        }

        if (this.physiotherapyRequestPlannedFormViewModel._PhysiotherapyRequest.CurrentStateDefID.valueOf() == PhysiotherapyRequest.PhysiotherapyRequestStates.Cancelled.id) {
            this.isStateCancelled = true;
        }

    }

    async ngOnInit() {
        let that = this;
        this.AddHelpMenu();
        await this.load(PhysiotherapyRequestPlannedFormViewModel);

    }


    async ngOnDestroy() {
        this.OnDestroy.emit();
    }

    //BURCU
    public getClickFunctionParams(): ClickFunctionParams {
        let clickFunctionParams: ClickFunctionParams = new ClickFunctionParams(this, new ActiveIDsModel(this._PhysiotherapyRequest.ObjectID, null, null));
        return clickFunctionParams;
    }

    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();

        let physioTherapyList = new DynamicSidebarMenuItem();
        physioTherapyList.key = 'physioTherapyList';
        physioTherapyList.label = 'Kayıtlı F.T.R Listesi';
        physioTherapyList.icon = 'ai ai-kayitli-ftr';
        physioTherapyList.componentInstance = this.helpMenuService;
        physioTherapyList.clickFunction = this.helpMenuService.openPhysioTherapyList;
        physioTherapyList.parameterFunctionInstance = this;
        physioTherapyList.getParamsFunction = this.getClickFunctionParams;
        physioTherapyList.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', physioTherapyList);


        let tedaviAlanHastaRaporu = new DynamicSidebarMenuItem();
        tedaviAlanHastaRaporu.key = 'tedaviAlanHastaRaporu';
        tedaviAlanHastaRaporu.label = 'Tedavi Alan Hasta Raporu';
        tedaviAlanHastaRaporu.icon = 'fa fa-file-text-o';
        tedaviAlanHastaRaporu.componentInstance = this;
        tedaviAlanHastaRaporu.clickFunction = this.openTedaviAlanHastaRaporu;
        tedaviAlanHastaRaporu.parameterFunctionInstance = this;
        tedaviAlanHastaRaporu.getParamsFunction = this.getClickFunctionParams;
        tedaviAlanHastaRaporu.ParentInstance = this;
        this.sideBarMenuService.addMenu('ReportMainItem', tedaviAlanHastaRaporu);

        let tedavisiPlanlananHastaRaporu = new DynamicSidebarMenuItem();
        tedavisiPlanlananHastaRaporu.key = 'tedavisiPlanlananHastaRaporu';
        tedavisiPlanlananHastaRaporu.label = 'Tedavisi Planlanan Hasta Raporu';
        tedavisiPlanlananHastaRaporu.icon = 'fa fa-file-text-o';
        tedavisiPlanlananHastaRaporu.componentInstance = this;
        tedavisiPlanlananHastaRaporu.clickFunction = this.openTedavisiPlanlananHastaRaporu;
        tedavisiPlanlananHastaRaporu.parameterFunctionInstance = this;
        tedavisiPlanlananHastaRaporu.getParamsFunction = this.getClickFunctionParams;
        tedavisiPlanlananHastaRaporu.ParentInstance = this;
        this.sideBarMenuService.addMenu('ReportMainItem', tedavisiPlanlananHastaRaporu);


        let tedavisiTamamlananHastaRaporu = new DynamicSidebarMenuItem();
        tedavisiTamamlananHastaRaporu.key = 'tedavisiTamamlananHastaRaporu';
        tedavisiTamamlananHastaRaporu.label = 'Tedavisi Planlanan Hasta Raporu';
        tedavisiTamamlananHastaRaporu.icon = 'fa fa-file-text-o';
        tedavisiTamamlananHastaRaporu.componentInstance = this;
        tedavisiTamamlananHastaRaporu.clickFunction = this.openTedavisiTamamlananHastaRaporu;
        tedavisiTamamlananHastaRaporu.parameterFunctionInstance = this;
        tedavisiTamamlananHastaRaporu.getParamsFunction = this.getClickFunctionParams;
        tedavisiTamamlananHastaRaporu.ParentInstance = this;
        this.sideBarMenuService.addMenu('ReportMainItem', tedavisiTamamlananHastaRaporu);

    }


    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('tedaviAlanHastaRaporu');
        this.sideBarMenuService.removeMenu('tedavisiTamamlananHastaRaporu');
        this.sideBarMenuService.removeMenu('tedavisiPlanlananHastaRaporu');
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


    public onPackageProcedureChanged(event): void {
        if (event != null) {
            if (this.PackageProcedure != event) {
                this.PackageProcedure = event;
            }
            if (this.physiotherapyRequestPlannedFormViewModel.PackageProcedure != event) {
                this.physiotherapyRequestPlannedFormViewModel.PackageProcedure = event;
            }
        }
    }


    public onLastOrderDetailResponsiblePhysiotherapistChanged(event): void {
        //if (event != null) {
        //}
        if (this.physiotherapyRequestPlannedFormViewModel.LastOrderDetailResponsiblePhysiotherapist != event) {
            this.physiotherapyRequestPlannedFormViewModel.LastOrderDetailResponsiblePhysiotherapist = event;
        }
    }//onValueChanged


    public onLastOrderDetailStartDateChanged(event): void {
        if (event != null) {
            if (this.physiotherapyRequestPlannedFormViewModel.LastOrderDetailStartDate != null && this.physiotherapyRequestPlannedFormViewModel.LastOrderDetailStartDate != event.value) {
                this.physiotherapyRequestPlannedFormViewModel.LastOrderDetailStartDate = event.value;
            }
        }
    }
    public onLastOrderDetailFinishDateChanged(event): void {
        if (event != null) {
            if (this.physiotherapyRequestPlannedFormViewModel.LastOrderDetailFinishDate != null && this.physiotherapyRequestPlannedFormViewModel.LastOrderDetailFinishDate != event.value) {
                this.physiotherapyRequestPlannedFormViewModel.LastOrderDetailFinishDate = event.value;
            }
        }
    }

    public onSessionChangedDateChanged(event): void {
        if (event != null) {
            if (this.physiotherapyRequestPlannedFormViewModel.SessionChangedDate != null && this.physiotherapyRequestPlannedFormViewModel.SessionChangedDate != event.value) {
                this.physiotherapyRequestPlannedFormViewModel.SessionChangedDate = event.value;
            }
        }
    }

    public onsessionRecalculateByDateChanged(event): void {
        if (event != null) {
            if (this.physiotherapyRequestPlannedFormViewModel.sessionRecalculateByDate != null && this.physiotherapyRequestPlannedFormViewModel.sessionRecalculateByDate != event) {
                this.physiotherapyRequestPlannedFormViewModel.sessionRecalculateByDate = event;
            }
            if (this.sessionRecalculateByDate.Value != event) {
                this.sessionRecalculateByDate.Value = event;
            }
        }
    }


    public onTreatmentTypePhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this.TreatmentTypePhysiotherapyReports != event) {
                this.TreatmentTypePhysiotherapyReports = event;
            }
            if (this.physiotherapyRequestPlannedFormViewModel.TreatmentType != event) {
                this.physiotherapyRequestPlannedFormViewModel.TreatmentType = event;
            }
        }
    }


    protected redirectProperties(): void {
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.TreatmentTypePhysiotherapyReports, "Value", this.__ttObject, "PhysiotherapyReports.TreatmentType");

    }

    public initFormControls(): void {

        this.TreatmentTypePhysiotherapyReports = new TTVisual.TTEnumComboBox();
        this.TreatmentTypePhysiotherapyReports.DataTypeName = "TreatmentQueryReportTypeEnum";
        this.TreatmentTypePhysiotherapyReports.Name = "TreatmentTypePhysiotherapyReports";
        this.TreatmentTypePhysiotherapyReports.TabIndex = 54;

        this.PackageProcedure = new TTVisual.TTObjectListBox();
        this.PackageProcedure.Required = true;
        this.PackageProcedure.ListDefName = "FTRPackageProcedureList";
        this.PackageProcedure.Name = "PackageProcedure";
        this.PackageProcedure.TabIndex = 94;


        this.sessionRecalculateByDate = new TTVisual.TTCheckBox();
        this.sessionRecalculateByDate.Value = true;
        this.sessionRecalculateByDate.Text = "Seans Tarihlerine dikkat edilsin mi?";
        this.sessionRecalculateByDate.Title = "Seans Tarihlerine dikkat edilsin mi ?";
        this.sessionRecalculateByDate.Name = 'sessionRecalculateByDate';
        this.sessionRecalculateByDate.ReadOnly = false;
        this.sessionRecalculateByDate.TabIndex = 184;


        this.LastOrderDetailResponsiblePhysiotherapist = new TTVisual.TTObjectListBox();
        this.LastOrderDetailResponsiblePhysiotherapist.Required = true;
        this.LastOrderDetailResponsiblePhysiotherapist.ListDefName = "PhysiotherapistListDefinition";
        this.LastOrderDetailResponsiblePhysiotherapist.Name = "LastOrderDetailResponsiblePhysiotherapist";
        this.LastOrderDetailResponsiblePhysiotherapist.TabIndex = 94;

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

    public openTedaviAlanHastaRaporu() {
        let reportData: DynamicReportParameters = {

            Code: 'TEDAVIALANHASTARAPORU',
            ReportParams: { ObjectID: this._PhysiotherapyRequest.ObjectID.toString() },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "TEDAVİ ALAN HASTA RAPORU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public openTedavisiPlanlananHastaRaporu() {
        let reportData: DynamicReportParameters = {

            Code: 'TEDAVISIPLANLANANHASTARAPORU',
            ReportParams: { ObjectID: this._PhysiotherapyRequest.ObjectID.toString() },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "TEDAVİSİ PLANLANAN HASTA RAPORU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    public openTedavisiTamamlananHastaRaporu() {
        let reportData: DynamicReportParameters = {

            Code: 'TEDAVISITAMAMLANANHASTARAPORU',
            ReportParams: { ObjectID: this._PhysiotherapyRequest.ObjectID.toString() },
            ViewerMode: true
        };

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'HvlDynamicReportComponent';
            componentInfo.ModuleName = 'DevexpressReportingModule';
            componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
            componentInfo.InputParam = new DynamicComponentInputParam(reportData, new ActiveIDsModel(null, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "TEDAVİSİ TAMAMLANAN HASTA RAPORU"

            modalInfo.fullScreen = true;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }
}
