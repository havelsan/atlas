//$81A16F18
import { Component, ViewChild, OnInit, HostListener, NgZone, OnDestroy, EventEmitter } from '@angular/core';
import { PhysiotherapyPlanningFormViewModel, OrderDetailInfo, OrderInfo, TreatmentDiagnosisUnitInfo } from './PhysiotherapyPlanningFormViewModel';
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

import { PhysiotherapyPlannedOrdersFormViewModel, PhysiotherapyOrderComponentInfoViewModel } from './PhysiotherapyPlannedOrdersFormViewModel';
import { PhysiotherapyPlannedOrdersForm } from './PhysiotherapyPlannedOrdersForm';
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
import { ActiveIDsModel, ClickFunctionParams } from 'app/Fw/Models/ParameterDefinitionModel';
import { IDestroyEvent } from 'app/Interfaces/IDestroyEvent';

@Component({
    selector: 'PhysiotherapyPlanningForm',
    templateUrl: './PhysiotherapyPlanningForm.html',
    providers: [MessageService, NqlQueryService, DatePipe]
})
export class PhysiotherapyPlanningForm extends TTVisual.TTForm implements OnInit, OnDestroy, IDestroyEvent {

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
    public physiotherapyPlanningFormViewModel: PhysiotherapyPlanningFormViewModel = new PhysiotherapyPlanningFormViewModel();
    public get _PhysiotherapyRequest(): PhysiotherapyRequest {
        return this._TTObject as PhysiotherapyRequest;
    }
    private PhysiotherapyPlanningForm_DocumentUrl: string = '/api/PhysiotherapyRequestService/PhysiotherapyPlanningForm';
    constructor(protected httpService: NeHttpService, private datePipe: DatePipe,
        protected objectContextService: ObjectContextService,
        protected messageService: MessageService,
        protected activeUserService: IActiveUserService,
        private sideBarMenuService: ISidebarMenuService,
        protected helpMenuService: HelpMenuService,
        private reportService: AtlasReportService,
        protected ngZone: NgZone) {
        super('PHYSIOTHERAPYREQUEST', 'PhysiotherapyPlanningForm');
        this._DocumentServiceUrl = this.PhysiotherapyPlanningForm_DocumentUrl;
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
    public IsPanelOpen: boolean = true;

    protected async save() {
        this.saveOrders = true;
        await super.save();
        this.saveOrders = false;
    }

    refreshDynamicComponent() {
        if (this.openDinamicCompFunc != null) {
            this.openDinamicCompFunc(this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest.ObjectID, "PHYSIOTHERAPYREQUEST", null);
        }
        else if (this._isFTRworkList == true) {
            this.httpService.episodeActionWorkListSharedService.refreshWorklist(true);
        } else {
            this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("PHYSIOTHERAPYREQUEST", this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest.ObjectID, null);
        }
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);

        //this.refreshDynamicComponent();
    }

    protected async setState(transDef: TTObjectStateTransitionDef, saveInfo?: FormSaveInfo): Promise<void> {
        await super.setState(transDef, saveInfo);
        if (transDef !== null && transDef.ToStateDefID != null) {
            if (transDef.ToStateDefID.id == PhysiotherapyRequest.PhysiotherapyRequestStates.Planned.id) {
                this.printReports();
            }
        }
    }


    public anamnesisInfoButtonClicked() {
        this.showAnamnesisInfo = true;
    }

    public onAnemnesisPopUpDisposing() {
        this.showAnamnesisInfo = false;
    }

    //Rapor Yazdırma
    public printReports() {
        this.printFTRTreatmentCardReport();
        this.printPhysicalTherapyInformationReport();
        this.printPhysicalTherapyRehabilitationReport();
    }
    public printPhysiotherapyRequestReport() {
        const objectIdParam = new GuidParam(this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest.ObjectID);
        let reportParameters: any = { 'PHYSIOTHERAPYREQUEST': objectIdParam };
        this.reportService.showReport('PhysiotherapyRequestReport', reportParameters);
    }
    public printFTRTreatmentCardReport() {
        const objectIdParam = new GuidParam(this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest.ObjectID);
        let reportParameters: any = { 'PHYSIOTHERAPYREQUEST': objectIdParam };
        this.reportService.showReport('FTRTreatmentCard', reportParameters);
    }
    public printPhysicalTherapyInformationReport() {
        const objectIdParam = new GuidParam(this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest.ObjectID);
        let reportParameters: any = { 'PHYSIOTHERAPYREQUEST': objectIdParam };
        this.reportService.showReport('PhysicalTherapyInformation', reportParameters);
    }
    public printPhysicalTherapyRehabilitationReport() {
        const objectIdParam = new GuidParam(this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest.ObjectID);
        let reportParameters: any = { 'PHYSIOTHERAPYREQUEST': objectIdParam };
        this.reportService.showReport('PhysicalTherapyRehabilitation', reportParameters);
    }
    //  .\ Rapor Yazdırma

    public isformopen: boolean = false;
    public formOpenedOrClosed(value: any) {
        this.isformopen = value;
    }

    protected async PreScript() {
        this.resize(undefined);
        super.PreScript();

        let componentInfoViewModel: PhysiotherapyOrderComponentInfoViewModel;
        componentInfoViewModel = PhysiotherapyPlannedOrdersForm.getComponentInfoViewModel(this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest.ObjectID);
        this.physiotherapyOrderQueryParameters = componentInfoViewModel.physiotherapyOrderQueryParameters;
        this.physiotherapyOrderComponentInfo = componentInfoViewModel.physiotherapyOrderComponentInfo;
    }

    public physiotherapyOrderComponentInfo: DynamicComponentInfo;
    public physiotherapyOrderQueryParameters: QueryParams;

    physiotherapyOrderQueryResultLoaded(e: any) {
        PhysiotherapyPlannedOrdersForm.physiotherapyOrderQueryResultLoaded(e);
    }


    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
        if (transDef !== null) {
            if (transDef.ToStateDefID.id == PhysiotherapyRequest.PhysiotherapyRequestStates.Completed.id && this.physiotherapyPlanningFormViewModel.CanComplatePhysiotherapyRequest == false) {
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


    /* PhysiotherapyOrderDetail Grid İşlemleri */

    public selectedRowKeysResultList: Array<OrderDetailInfo> = [];

    async onRowUpdating(value: any): Promise<void> {
        if (value.oldData.OrderDetailItem.CurrentStateDefID == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed) {
            this.messageService.showInfo(i18n("M22714", "Tamamlandı Durumunda Olan İşlemlerin Tarihini Değiştiremezsiniz!"));
            value.newData.PlannedDate = value.oldData.PlannedDate;
        } else {
            let _sessionNumber: number = value.oldData.SessionNumber;
            let approvedTransactionCount: number = 0; //Onaylanacak statusündeki işlemler

            if (value.oldData.IsAdditionalTreatment == true) { //Ek tedavi ise değişiklik yapma


                if (_sessionNumber != null) {
                    for (let i = 0; i < this.physiotherapyPlanningFormViewModel.AdditionalOrderDetailInfoList.length; i++) {
                        if (this.physiotherapyPlanningFormViewModel.AdditionalOrderDetailInfoList[i].SessionNumber == _sessionNumber.toString() && this.physiotherapyPlanningFormViewModel.AdditionalOrderDetailInfoList[i].OrderDetailItem.CurrentStateDefID == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed) {
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
                        if (value.oldData.OrderDetailItem.CurrentStateDefID == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed) {
                            this.messageService.showInfo(i18n("M22714", "Tamamlandı Durumunda Olan İşlemlerin Tarihini Değiştiremezsiniz!"));
                            value.newData.PlannedDate = value.oldData.PlannedDate;
                        } else {
                            value.oldData.PlannedDate = value.newData.PlannedDate;
                            if (_sessionNumber != null) {
                                for (let i = 0; i < this.physiotherapyPlanningFormViewModel.AdditionalOrderDetailInfoList.length; i++) {//Mevcut seansa ait tüm tarihler değiştiriliyor
                                    if (this.physiotherapyPlanningFormViewModel.AdditionalOrderDetailInfoList[i].SessionNumber == _sessionNumber.toString()) {
                                        this.physiotherapyPlanningFormViewModel.AdditionalOrderDetailInfoList[i].PlannedDate = value.newData.PlannedDate;
                                        this.physiotherapyPlanningFormViewModel.ChangedOrderDetail = this.physiotherapyPlanningFormViewModel.AdditionalOrderDetailInfoList[i];
                                    }
                                }
                            }
                        }
                    } else {
                        value.newData.PlannedDate = value.oldData.PlannedDate;
                    }
                }


            } else { //Ek tedavi DEĞİL ise değişiklik yapma


                if (_sessionNumber != null) {
                    for (let i = 0; i < this.physiotherapyPlanningFormViewModel.OrderDetailInfoList.length; i++) {
                        if (this.physiotherapyPlanningFormViewModel.OrderDetailInfoList[i].SessionNumber == _sessionNumber.toString() && this.physiotherapyPlanningFormViewModel.OrderDetailInfoList[i].OrderDetailItem.CurrentStateDefID == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed) {
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
                        if (value.oldData.OrderDetailItem.CurrentStateDefID == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed) {
                            this.messageService.showInfo(i18n("M22714", "Tamamlandı Durumunda Olan İşlemlerin Tarihini Değiştiremezsiniz!"));
                            value.newData.PlannedDate = value.oldData.PlannedDate;
                        } else {
                            value.oldData.PlannedDate = value.newData.PlannedDate;
                            if (_sessionNumber != null) {
                                for (let i = 0; i < this.physiotherapyPlanningFormViewModel.OrderDetailInfoList.length; i++) {//Mevcut seansa ait tüm tarihler değiştiriliyor
                                    if (this.physiotherapyPlanningFormViewModel.OrderDetailInfoList[i].SessionNumber == _sessionNumber.toString()) {
                                        this.physiotherapyPlanningFormViewModel.OrderDetailInfoList[i].PlannedDate = value.newData.PlannedDate;
                                        this.physiotherapyPlanningFormViewModel.ChangedOrderDetail = this.physiotherapyPlanningFormViewModel.OrderDetailInfoList[i];
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

    /* PhysiotherapyOrderDetail Grid İşlemleri bitti */


    /* Fizyoterapi Button İşlemleri *******************************************************************/

    //İstek iptal
    public async cancelPhysiotherapyRequest() {
        let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M14075", "F.T.R. İstek İptal"), i18n("M14072", "F.T.R. isteğini iptal etmeniz durumunda tekrar işlem yapılamayacaktır! \r\n\r\n Devam etmek istiyor musunuz?"));
        if (messageResult === "E") {

            let that = this;
            that.httpService.post<any>("api/PhysiotherapyRequestService/CancelPhysiotherapyRequest", this.physiotherapyPlanningFormViewModel)
                .then(response => {
                    this.refreshDynamicComponent();

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
        //#region TODO Merve -> değişiklik yapmamak için geçici olarak kapatıldı.
        //for (let i = 0; i < this.selectedRowKeysResultList.length; i++) {
        //    let _ObjectID: Guid;
        //    if (typeof this.selectedRowKeysResultList[i].OrderDetailItem.OrderObject == "string") {
        //        let obj: string = this.selectedRowKeysResultList[i].OrderDetailItem["OrderObject"].toString();
        //        _ObjectID = new Guid(obj);
        //    } else {
        //        _ObjectID = new Guid(this.selectedRowKeysResultList[i].OrderDetailItem.OrderObject.ObjectID);
        //    }
        //    let order: PhysiotherapyOrder = await this.objectContextService.getObjectWithDefName<PhysiotherapyOrder>(_ObjectID, 'PhysiotherapyOrder');

        //    if (order.PackageProcedure == null) {
        //        isPackageExists++;
        //    }
        //}
        //#endregion 
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
            if (this.selectedRowKeysResultList[i].OrderDetailItem.CurrentStateDefID != PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Execution) {
                approvedTransactionCount++;
            }
            else if (new Date(this.datePipe.transform(this.selectedRowKeysResultList[i].OrderDetailItem.PlannedDate, 'MM.dd.yyyy')) > new Date(this.datePipe.transform(currentDate, 'MM.dd.yyyy'))) {
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

            if (this.openReportSelection == true && this.physiotherapyPlanningFormViewModel.PackageProcedure == null) {
                this.messageService.showReponseError(i18n("M18389", "Lütfen Paket Seçiniz."));
                this.loadPanelOperation(false, '');
                return false;
            }

            if (this.physiotherapyPlanningFormViewModel.LastOrderDetailResponsiblePhysiotherapist == null || this.physiotherapyPlanningFormViewModel.LastOrderDetailStartDate == null || this.physiotherapyPlanningFormViewModel.LastOrderDetailFinishDate == null) {
                this.messageService.showReponseError(i18n("M18371", "Lütfen Fizyoterapist ve Saat Seçiniz!"));
                this.loadPanelOperation(false, '');
                return false;
            } else {

                for (let i = 0; i < this.selectedRowKeysResultList.length; i++) {
                    this.selectedRowKeysResultList[i].CurrentUserObjectId = this.activeUserService.ActiveUser.UserObject.ObjectID; //İşlemi yapan kişi belirleniyor

                    this.selectedRowKeysResultList[i].StartDate = this.physiotherapyPlanningFormViewModel.LastOrderDetailStartDate;
                    this.selectedRowKeysResultList[i].FinishDate = this.physiotherapyPlanningFormViewModel.LastOrderDetailFinishDate;
                    this.selectedRowKeysResultList[i].ResponsiblePhysiotherapist = this.physiotherapyPlanningFormViewModel.LastOrderDetailResponsiblePhysiotherapist; //this.TTListBoxPhysiotherapist.SelectedObject as ResUser;

                }

                this.physiotherapyPlanningFormViewModel.selectedRowKeysResultList = this.selectedRowKeysResultList;

                let that = this;
                that.httpService.post<any>("api/PhysiotherapyRequestService/CompleteSelectedRecordsByID", this.physiotherapyPlanningFormViewModel)
                    .then(response => {
                        this.refreshDynamicComponent();

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

    //Seansları Tekrar Hesaplama
    public changeSessionsRecords() {
        let that = this;
        that.httpService.post<any>("api/PhysiotherapyRequestService/ChangeSessionsRecords", this.physiotherapyPlanningFormViewModel.OrderDetailInfoList)
            .then(response => {
                this.messageService.showSuccess(i18n("M21530", "Seçilen İşlemler Başarılı Bir Şekilde Silindi"));
            })
            .catch(error => {
                this.messageService.showError(error);

            });

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
            if (this.selectedRowKeysResultList[i].OrderDetailItem.CurrentStateDefID == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed)//"Tamamlandı durumunda olanlar"
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
            that.httpService.post<any>("api/PhysiotherapyRequestService/DeleteSelectedRecordsByID", this.selectedRowKeysResultList)
                .then(response => {
                    this.refreshDynamicComponent();

                    this.messageService.showSuccess(i18n("M21530", "Seçilen İşlemler Başarılı Bir Şekilde Silindi"));
                })
                .catch(error => {
                    this.messageService.showError(error);

                });
        }
    }

    //Saat değiştirme
    public saveDateRecords() {
        let that = this;
        that.httpService.post<any>("api/PhysiotherapyRequestService/SaveDateRecords", this.physiotherapyPlanningFormViewModel.OrderDetailInfoList)
            .then(response => {
                if (this.openDinamicCompFunc != null) {
                    this.openDinamicCompFunc(this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest.ObjectID, "PHYSIOTHERAPYREQUEST", null);
                } else {
                    this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent("PHYSIOTHERAPYREQUEST", this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest.ObjectID, null);
                }
                this.messageService.showSuccess(i18n("M21528", "Seçilen İşlemler Başarılı Bir Şekilde Kaydedildi"));
            })
            .catch(error => {
                this.messageService.showError(error);

            });
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
            if (this.selectedRowKeysResultList[i].OrderDetailItem.CurrentStateDefID == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed)//"Tamamlandı durumunda olanlar"
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
            that.httpService.post<any>("api/PhysiotherapyRequestService/AbortSelectedRecordsByID", this.selectedRowKeysResultList)
                .then(response => {
                    this.refreshDynamicComponent();

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
            if (this.selectedRowKeysResultList[i].OrderDetailItem.CurrentStateDefID == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Completed || this.selectedRowKeysResultList[i].OrderDetailItem.CurrentStateDefID == PhysiotherapyOrderDetail.PhysiotherapyOrderDetailStates.Cancelled) {
                approvedTransactionCount++;
            }
            else if (new Date(this.datePipe.transform(this.selectedRowKeysResultList[i].OrderDetailItem.PlannedDate, 'MM.dd.yyyy')) > new Date(this.datePipe.transform(currentDate, 'MM.dd.yyyy'))) {
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
            that.httpService.post<any>("api/PhysiotherapyRequestService/NotComeSelectedRecordsByID", this.selectedRowKeysResultList)
                .then(response => {
                    this.refreshDynamicComponent();

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
        that.httpService.post<any>("api/PhysiotherapyRequestService/UndoRecords", this.selectedRowKeysResultList)
            .then(response => {
                this.UndoLastTransition_SelectedEpisodeAction();
                this.refreshDynamicComponent();

                this.messageService.showSuccess(i18n("M21527", "Seçilen İşlemler Başarılı Bir Şekilde Geri Alındı"));
            })
            .catch(error => {
                this.messageService.showError(error);

            });
    }

    /* Fizyoterapi Button İşlemleri bitti */


    /* PhysiotherapyOrder Grid İşlemleri */

    public selectedOrderRowKeysResult: OrderInfo = new OrderInfo;
    public selectedOrderItemInfo: PhysiotherapyPlannedOrdersFormViewModel = new PhysiotherapyPlannedOrdersFormViewModel;
    public IsSelectedObjExist: boolean = false;

    async selectionOrderChange(value: any): Promise<void> {
        let that = this;
        if (this._readOnlyByCode != true) {

            let plannedOrdersForm_DocumentUrl: string = '/api/PhysiotherapyOrderService/GetPhysiotherapyPlannedOrdersFormViewModelById?orderInfo';
            this.httpService.post<PhysiotherapyPlannedOrdersFormViewModel>("api/PhysiotherapyOrderService/GetPhysiotherapyPlannedOrdersFormViewModelById?orderInfo", value.currentSelectedRowKeys[0], PhysiotherapyPlannedOrdersFormViewModel).then(response => {
                let result: PhysiotherapyPlannedOrdersFormViewModel = <PhysiotherapyPlannedOrdersFormViewModel>response;

                this.IsSelectedObjExist = true;
                this.physiotherapyPlanningFormViewModel.selectedPhysiotherapyPlannedOrdersFormViewModel = result;
                this.selectedOrderItemInfo = result;
                this.selectedOrderItemInfo.ProcedureObjectDataSource = this.physiotherapyPlanningFormViewModel.ProcedureObjectDataSource;

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
        this.showCompleteSessionPopUp = true;
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
                that.httpService.get<any>("api/PhysiotherapyRequestService/CompleteSessionsByUnit?PhysiotherapyRequestObjectID=" + this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest.ObjectID + "&PhysiotherapyRequestObjectDefID=" + this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest.ObjectDefID + "&TreatmentDiagnosisUnitID=" + unit.TreatmentDiagnosisUnitID)
                    .then(response => {
                        this.refreshDynamicComponent();

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

        let that = this;
        for (let unit of this.selectedUnits) {
            that.httpService.get<any>("api/PhysiotherapyRequestService/UndoCompleteSessionsByUnit?PhysiotherapyRequestObjectID=" + this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest.ObjectID + "&TreatmentDiagnosisUnitID=" + unit.TreatmentDiagnosisUnitID)
                .then(response => {
                    this.UndoLastTransition_SelectedEpisodeAction();
                    this.refreshDynamicComponent();

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

    /* PhysiotherapyOrder Grid İşlemleri bitti */

    /* Yeni İşlem/Ek İşlem Prosedürleri */
    public newPhysiotherapyOrder() {
        let that = this;
        let plannedOrdersForm_DocumentUrl: string = '/api/PhysiotherapyOrderService/GetNewPhysiotherapyPlannedOrdersFormViewModel?physiotherapyRequest';

        this.httpService.post<PhysiotherapyPlannedOrdersFormViewModel>("api/PhysiotherapyOrderService/GetNewPhysiotherapyPlannedOrdersFormViewModel?physiotherapyRequest", this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest, PhysiotherapyPlannedOrdersFormViewModel).then(response => {
            let result: PhysiotherapyPlannedOrdersFormViewModel = <PhysiotherapyPlannedOrdersFormViewModel>response;

            this.IsSelectedObjExist = true;
            this.physiotherapyPlanningFormViewModel.selectedPhysiotherapyPlannedOrdersFormViewModel = result;
            this.selectedOrderItemInfo = result;
            this.selectedOrderItemInfo.ProcedureObjectDataSource = this.physiotherapyPlanningFormViewModel.ProcedureObjectDataSource;
            this.IsPanelOpen = true;
        });
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
            value.rowElement.firstItem().style.backgroundColor = '#FFE992'; //'#F9D543';//'#F1C40F';
        }
    }



    //Rapor İşlemleri
    selectedReportItem: PhysiotherapyReports;
    selectedApplicarionArea: FTRVucutBolgesi;
    selectedPackageProcedureDefinition: PackageProcedureDefinition;
    async selectionReportChanged(value: any): Promise<void> {
        if (value) {
            this.physiotherapyPlanningFormViewModel.Report = value.selectedRowsData[0].ReportObj as PhysiotherapyReports;
            this.physiotherapyPlanningFormViewModel.PackageProcedure = value.selectedRowsData[0].PackageProcedureDefinition as PackageProcedureDefinition;
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
        if (this.physiotherapyPlanningFormViewModel.Report == null) {
            let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20837", "Rapor Seçimi İptal"), i18n("M20838", "Rapor seçmeden devam etmeniz durumunda işlem ücretlendirilecektir! \r\n\r\n Devam etmek istiyor musunuz?"));
            if (messageResult === "E") {
                this.showTreatmentTypePopup = false;
                this.PackageProcedure.Required = true;
            }
        } else {
            if (this.physiotherapyPlanningFormViewModel.Report.ReportNo == null) {
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
        if (this.physiotherapyPlanningFormViewModel.ReportItemList == null) {
            this.httpService.post<PhysiotherapyPlannedOrdersFormViewModel>("api/PhysiotherapyOrderService/GetReportInfoByTreatmentType?treatmentType", this.physiotherapyPlanningFormViewModel.TreatmentType, PhysiotherapyPlannedOrdersFormViewModel).then(response => {
                let result: PhysiotherapyPlannedOrdersFormViewModel = <PhysiotherapyPlannedOrdersFormViewModel>response;

                this.physiotherapyPlanningFormViewModel.ReportItemList = result.ReportItemList;
                this.physiotherapyPlanningFormViewModel.Message = result.Message;

                this.showTreatmentTypePopup = false;
                this.showPhysiotherapyReportPopup = true;

                if (this.physiotherapyPlanningFormViewModel.Message != null && this.physiotherapyPlanningFormViewModel.Message != "") {
                    TTVisual.InfoBox.Alert(this.physiotherapyPlanningFormViewModel.Message);
                }
            }).catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.showTreatmentTypePopup = false;
            });
        } else {
            this.showTreatmentTypePopup = false;
            this.showPhysiotherapyReportPopup = true;

            if (this.physiotherapyPlanningFormViewModel.Message != null && this.physiotherapyPlanningFormViewModel.Message != "") {
                TTVisual.InfoBox.Alert(this.physiotherapyPlanningFormViewModel.Message);
            }
        }
    }
    async CancelPhysiotherapyReport() {
        if (this.physiotherapyPlanningFormViewModel.Report == null) {
            let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20837", "Rapor Seçimi İptal"), i18n("M20838", "Rapor seçmeden devam etmeniz durumunda işlem ücretlendirilecektir! \r\n\r\n Devam etmek istiyor musunuz?"));
            if (messageResult === "E") {
                this.physiotherapyPlanningFormViewModel.Report = null;
                this.physiotherapyPlanningFormViewModel.PackageProcedure = null;

                this.PackageProcedure.Required = true;

                this.showPhysiotherapyReportPopup = false;
                this.selectedReportItem = null;
            }
        } else {
            if (this.physiotherapyPlanningFormViewModel.Report.ReportNo == null) {
                let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20837", "Rapor Seçimi İptal"), i18n("M20838", "Rapor seçmeden devam etmeniz durumunda işlem ücretlendirilecektir! \r\n\r\n Devam etmek istiyor musunuz?"));
                if (messageResult === "E") {
                    this.physiotherapyPlanningFormViewModel.Report = null;
                    this.physiotherapyPlanningFormViewModel.PackageProcedure = null;

                    this.PackageProcedure.Required = true;

                    this.showPhysiotherapyReportPopup = false;
                    this.selectedReportItem = null;
                }
            } else {
                this.physiotherapyPlanningFormViewModel.Report = null;
                this.physiotherapyPlanningFormViewModel.PackageProcedure = null;

                this.PackageProcedure.Required = true;

                this.showPhysiotherapyReportPopup = false;
                this.selectedReportItem = null;
            }
        }
    }
    async SavePhysiotherapyReportModal() {
        if (this.physiotherapyPlanningFormViewModel.Report != null && this.physiotherapyPlanningFormViewModel.PackageProcedure != null) {
            this.PackageProcedure.ReadOnly = true;
            this.PackageProcedure.Required = true;
            this.showPhysiotherapyReportPopup = false;
            this.selectedReportItem = null;
        }
        else {

            if (this.physiotherapyPlanningFormViewModel.Report == null) {
                let messageResult: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M20837", "Rapor Seçimi İptal"), i18n("M20838", "Rapor seçmeden devam etmeniz durumunda işlem ücretlendirilecektir! \r\n\r\n Devam etmek istiyor musunuz?"));
                if (messageResult === "E") {
                    this.PackageProcedure.ReadOnly = true;
                    this.PackageProcedure.Required = true;

                    this.showPhysiotherapyReportPopup = false;
                    this.selectedReportItem = null;
                }
            } else {
                if (this.physiotherapyPlanningFormViewModel.Report.ReportNo == null) {
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

    public openHastaGecmisiTab: boolean = false;
    public openHastaGecmisi() {
        this.openHastaGecmisiTab = true;
    }

    public openMalzemeSarfTab: boolean = false;
    public openMalzemeSarf() {
        this.openMalzemeSarfTab = true;
    }


    public async UndoLastTransition_SelectedEpisodeAction() {
        if (this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest != null && (this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest.CurrentStateDefID == PhysiotherapyRequest.PhysiotherapyRequestStates.Completed || this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest.CurrentStateDefID == PhysiotherapyRequest.PhysiotherapyRequestStates.Cancelled)) {
            let massage: string = "F.T.R. Tedavisi ";
            let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'İşlem Geri Alma',
                massage + i18n("M14750", "geri alınacaktır.Devam etmek istediğinize emin misiniz? "));
            if (result === 'V') {
                ServiceLocator.MessageService.showSuccess(i18n("M14753", "Geri Alma İşleminden Vazgeçildi"));
            }
            else {
                let that = this;
                let _DocumentServiceUrl: string = "/api/MainPatientFolderService/UndoLastTransitionEAorSPFlowableByObjectId?ObjectId=" + this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest.ObjectID.toString();
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



    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new PhysiotherapyRequest();
        this.physiotherapyPlanningFormViewModel = new PhysiotherapyPlanningFormViewModel();
        this._ViewModel = this.physiotherapyPlanningFormViewModel;
        this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest = this._TTObject as PhysiotherapyRequest;
        this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest.TreatmentMaterials = new Array<BaseTreatmentMaterial>();
    }

    protected loadViewModel() {
        let that = this;

        that.physiotherapyPlanningFormViewModel = this._ViewModel as PhysiotherapyPlanningFormViewModel;
        that._TTObject = this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest;
        if (this.physiotherapyPlanningFormViewModel == null)
            this.physiotherapyPlanningFormViewModel = new PhysiotherapyPlanningFormViewModel();
        if (this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest == null)
            this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest = new PhysiotherapyRequest();
        that.physiotherapyPlanningFormViewModel._PhysiotherapyRequest.TreatmentMaterials = that.physiotherapyPlanningFormViewModel.GridTreatmentMaterialsGridList;
        for (let detailItem of that.physiotherapyPlanningFormViewModel.GridTreatmentMaterialsGridList) {
            let materialObjectID = detailItem["Material"];
            if (materialObjectID != null && (typeof materialObjectID === "string")) {
                let material = that.physiotherapyPlanningFormViewModel.Materials.find(o => o.ObjectID.toString() === materialObjectID.toString());
                if (material) {
                    detailItem.Material = material;
                }
                if (material != null) {
                    let stockCardObjectID = material["StockCard"];
                    if (stockCardObjectID != null && (typeof stockCardObjectID === "string")) {
                        let stockCard = that.physiotherapyPlanningFormViewModel.StockCards.find(o => o.ObjectID.toString() === stockCardObjectID.toString());
                        if (stockCard) {
                            material.StockCard = stockCard;
                        }
                        if (stockCard != null) {
                            let distributionTypeObjectID = stockCard["DistributionType"];
                            if (distributionTypeObjectID != null && (typeof distributionTypeObjectID === "string")) {
                                let distributionType = that.physiotherapyPlanningFormViewModel.DistributionTypeDefinitions.find(o => o.ObjectID.toString() === distributionTypeObjectID.toString());
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
                let ozelDurum = that.physiotherapyPlanningFormViewModel.OzelDurums.find(o => o.ObjectID.toString() === ozelDurumObjectID.toString());
                if (ozelDurum) {
                    detailItem.OzelDurum = ozelDurum;
                }
            }
        }

        if (this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest.CurrentStateDefID != PhysiotherapyRequest.PhysiotherapyRequestStates.RequestAcception) {
            this.IsPanelOpen = false;
        }
        if (this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest.CurrentStateDefID == PhysiotherapyRequest.PhysiotherapyRequestStates.RequestAcception) {
            this.IsRequestAcceptionState = true;
        }


        this.DropStateButton(PhysiotherapyRequest.PhysiotherapyRequestStates.Cancelled);
        this.DropStateButton(PhysiotherapyRequest.PhysiotherapyRequestStates.Completed);

        if (this.physiotherapyPlanningFormViewModel.TreatmentType == null || this.physiotherapyPlanningFormViewModel.TreatmentType == 0) {
            this.physiotherapyPlanningFormViewModel.TreatmentType = TreatmentQueryReportTypeEnum.FTR;
        }

        if (this.physiotherapyPlanningFormViewModel._PhysiotherapyRequest.CurrentStateDefID == PhysiotherapyRequest.PhysiotherapyRequestStates.Cancelled) {
            this.isStateCancelled = true;
        }

    }

    async ngOnInit() {
        let that = this;
        this.AddHelpMenu();
        await this.load(PhysiotherapyPlanningFormViewModel);

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


    public onPackageProcedureChanged(event): void {
        if (event != null) {
            if (this.PackageProcedure != event) {
                this.PackageProcedure = event;
            }
            if (this.physiotherapyPlanningFormViewModel.PackageProcedure != event) {
                this.physiotherapyPlanningFormViewModel.PackageProcedure = event;
            }
        }
    }


    public onLastOrderDetailResponsiblePhysiotherapistChanged(event): void {
        //if (event != null) {
        //}
        if (this.physiotherapyPlanningFormViewModel.LastOrderDetailResponsiblePhysiotherapist != event) {
            this.physiotherapyPlanningFormViewModel.LastOrderDetailResponsiblePhysiotherapist = event;
        }
    }//onValueChanged


    public onLastOrderDetailStartDateChanged(event): void {
        if (event != null) {
            if (this.physiotherapyPlanningFormViewModel.LastOrderDetailStartDate != null && this.physiotherapyPlanningFormViewModel.LastOrderDetailStartDate != event.value) {
                this.physiotherapyPlanningFormViewModel.LastOrderDetailStartDate = event.value;
            }
        }
    }
    public onLastOrderDetailFinishDateChanged(event): void {
        if (event != null) {
            if (this.physiotherapyPlanningFormViewModel.LastOrderDetailFinishDate != null && this.physiotherapyPlanningFormViewModel.LastOrderDetailFinishDate != event.value) {
                this.physiotherapyPlanningFormViewModel.LastOrderDetailFinishDate = event.value;
            }
        }
    }

    public onTreatmentTypePhysiotherapyReportsChanged(event): void {
        if (event != null) {
            if (this.TreatmentTypePhysiotherapyReports != event) {
                this.TreatmentTypePhysiotherapyReports = event;
            }
            if (this.physiotherapyPlanningFormViewModel.TreatmentType != event) {
                this.physiotherapyPlanningFormViewModel.TreatmentType = event;
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



        this.LastOrderDetailResponsiblePhysiotherapist = new TTVisual.TTObjectListBox();
        this.LastOrderDetailResponsiblePhysiotherapist.Required = true;
        this.LastOrderDetailResponsiblePhysiotherapist.ListDefName = "PhysiotherapistListDefinition";
        this.LastOrderDetailResponsiblePhysiotherapist.Name = "LastOrderDetailResponsiblePhysiotherapist";
        this.LastOrderDetailResponsiblePhysiotherapist.TabIndex = 94;


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
