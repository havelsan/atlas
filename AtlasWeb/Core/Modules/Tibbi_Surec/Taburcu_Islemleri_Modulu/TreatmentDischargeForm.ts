//$7A896469
import { Component, OnInit, OnDestroy, Input, EventEmitter, ComponentRef, NgZone } from '@angular/core';
import { TreatmentDischargeFormViewModel, TreatmentDischargeProblemViewModel, TreatmentDischargeDefaultActionViewModel } from './TreatmentDischargeFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { DischargeTypeEnum } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { TreatmentDischarge } from 'NebulaClient/Model/AtlasClientModel';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DischargeTypeDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResClinic } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { OrdersToCancelParameterViewModel } from 'Modules/Tibbi_Surec/Yatan_Hasta_Modulu/InPatientPhysicianApplicationFormViewModel';
import { IModalService } from "Fw/Services/IModalService";
import { ModalInfo, ModalActionResult } from "Fw/Models/ModalInfo";

import { Morgue } from 'NebulaClient/Model/AtlasClientModel';

import { SystemApiService } from 'Fw/Services/SystemApiService';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { IInputParam } from 'Fw/Models/IInputParam';

import { EpisodeActionHelper } from "app/Helper/EpisodeActionHelper";
import { MorgueExDischargeFormViewModel } from 'Modules/Tibbi_Surec/Morg_Modulu/MorgueExDischargeFormViewModel';
import { DispatchToOtherHospitalFormViewModel } from 'Modules/Tibbi_Surec/XXXXXXler_Arasi_Sevk_Modulu/DispatchToOtherHospitalFormViewModel';
import { FormSaveInfo } from "NebulaClient/Mscorlib/FormSaveInfo";
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from 'app/Fw/Models/ParameterDefinitionModel';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { ISidebarMenuService } from 'app/Fw/Services/ISidebarMenuService';
import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';

@Component({
    selector: 'TreatmentDischargeForm',
    templateUrl: './TreatmentDischargeForm.html',
    providers: [MessageService, SystemApiService]
})
export class TreatmentDischargeForm extends EpisodeActionForm implements OnInit, IInputParam, OnDestroy {
    Conclusion: TTVisual.ITTRichTextBoxControl;
    DisChargeDate: TTVisual.ITTDateTimePicker;
    DischargeType: TTVisual.ITTObjectListBox;
    labelConclusion: TTVisual.ITTLabel;
    labelDischargeType: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelTransferTreatmentClinic: TTVisual.ITTLabel;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    TransferTreatmentClinic: TTVisual.ITTObjectListBox;
    ttlabelDisChargeDate: TTVisual.ITTLabel;
    public treatmentDischargeFormViewModel: TreatmentDischargeFormViewModel = new TreatmentDischargeFormViewModel();
    public get _TreatmentDischarge(): TreatmentDischarge {
        return this._TTObject as TreatmentDischarge;
    }
    private TreatmentDischargeForm_DocumentUrl: string = '/api/TreatmentDischargeService/TreatmentDischargeForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        public systemApiService: SystemApiService,
        protected modalService: IModalService,
        private sideBarMenuService: ISidebarMenuService,
        protected episodeActionHelper: EpisodeActionHelper,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.TreatmentDischargeForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    @Input() dischargeType: DischargeTypeEnum;
    private saveEventSubscription: any;

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


    //IInputParam inputları dinamiccomponentla set etmek için

    public defaultActionViewModel: TreatmentDischargeDefaultActionViewModel;
    setInputParam(value: Object) {
        if (value) {
            if (typeof value === "number") {
                this.dischargeType = <any>value;
                // this.ArrangeReadOnlyFields();
            }
            if (value.hasOwnProperty("ObjectDefName") && value.hasOwnProperty("ObjectId")) { //  if (value instanceof TreatmentDischargeDefaultActionViewModel)  çalışmadığı için bu şekilde yapıldı
                this.defaultActionViewModel = value as TreatmentDischargeDefaultActionViewModel;
                this.openDinamicComp(this.defaultActionViewModel.ObjectId, this.defaultActionViewModel.ObjectDefName, this.defaultActionViewModel.FormDefId, this.defaultActionViewModel.InputParam);
            }
        }
    }


    /*Sevk işlemleri*/
    public isDischargeTypeTransferingToOtherlHospital = false;
    public componentSevkInfo: DynamicComponentInfo;
    public onSevkComponentViewModelLoaded(dispatchToOtherHospitalFormViewModel: DispatchToOtherHospitalFormViewModel): void {
        dispatchToOtherHospitalFormViewModel.isStartedByTreatmentDischarge = true;
        this.treatmentDischargeFormViewModel._DispatchToOtherHospitalFormViewModel = dispatchToOtherHospitalFormViewModel;
    }

    public onSevkComponentCreated(componentRef: ComponentRef<any>): void {
        componentRef.instance['openedByTreatmentDischargeForm'] = true;
    }

    openSevkComponentInfo() {
        let componentInfo = new DynamicComponentInfo();
        componentInfo.ComponentName = "DispatchToOtherHospitalForm";
        componentInfo.ModuleName = "XXXXXXlerArasiSevkModule";
        componentInfo.ModulePath = "/Modules/Tibbi_Surec/XXXXXXler_Arasi_Sevk_Modulu/XXXXXXlerArasiSevkModule";
        componentInfo.objectID = this.getDispatchToOtherHospitalObejctID();
        let selectedActionID: Guid = <any>this.treatmentDischargeFormViewModel._TreatmentDischarge['MasterAction'];
        componentInfo.InputParam = new DynamicComponentInputParam(true, new ActiveIDsModel(selectedActionID, null, null));
        this.componentSevkInfo = componentInfo;
    }

    protected getDispatchToOtherHospitalObejctID(): string {
        if (this._TreatmentDischarge.DispatchToOtherHospital != null) {
            if (typeof this._TreatmentDischarge.DispatchToOtherHospital === "string") {
                return this._TreatmentDischarge.DispatchToOtherHospital;
            }
            else if (this._TreatmentDischarge.DispatchToOtherHospital.ObjectID != null)
                return this._TreatmentDischarge.DispatchToOtherHospital.ObjectID.toString();
        }

        return null;
    }

    public collapseSevk = true; // sevk Akordionu açık mı olmalı kapalı mı?


    /*Dinamik Seçili Komponent Yükleme*/
    public componentPatientInfo: DynamicComponentInfo;
    public demographicFomOpen: boolean = true;
    async select(value: any): Promise<void> {
        let problemViewModel: TreatmentDischargeProblemViewModel = value as TreatmentDischargeProblemViewModel;
        if (problemViewModel.ObjectId != null) {
            this.openDinamicComp(problemViewModel.ObjectId, problemViewModel.ObjectDefName, problemViewModel.FormDefId);
            //this.setComponentPatientInfo();
        } else {
            TTVisual.InfoBox.Alert(problemViewModel.ProblemString);
        }
    }

    async openDinamicComp(objectID: any, objectDefName: any, FormDefId?: any, InputParam?: any) {
        this.demographicFomOpen = false;

        let _inputParam = {};
        _inputParam['InputParam'] = InputParam;

        const openDinamicCompFunc = this.openDinamicComp.bind(this);
        _inputParam['openDinamicComp'] = openDinamicCompFunc;

        if (objectID != null) {
            let objID: Guid = <any>objectID;
            this.systemApiService.open(objectID, objectDefName, FormDefId, new DynamicComponentInputParam(_inputParam, new ActiveIDsModel(objID, null, null)));
        }
        else {
            this.systemApiService.new(objectDefName, null, FormDefId, new DynamicComponentInputParam(_inputParam, this.getActiveIDsModel()));
        }
        if (this.isDischargeTypeTransferingToOtherlHospital == true) {
            this.collapseSevk = false;
        }
    }




    protected getInPatientTreatmentClinicAppObjectId(): string {
        let that = this;
        let inPatientTreatmentClinicApp: any = this._TreatmentDischarge.InPatientTreatmentClinicApp;
        if (inPatientTreatmentClinicApp != null) {
            if (typeof inPatientTreatmentClinicApp === "string") {
                return inPatientTreatmentClinicApp;
            }
            else
                return inPatientTreatmentClinicApp.ObjectID;
        }
        return null;
    }

    public RefreshProblems() {
        let that = this;
        this.httpService.post("/api/TreatmentDischargeService/GetProblems", this._ViewModel)
            .then(response => {
                let result = response as TreatmentDischargeFormViewModel;
                that.treatmentDischargeFormViewModel.TreatmentDischargeProblemList = result.TreatmentDischargeProblemList;
                let isAllRequiredProblemsOk = true;
                for (let problem of that.treatmentDischargeFormViewModel.TreatmentDischargeProblemList) {
                    if (problem.IsRequired && !problem.IsOk)
                        isAllRequiredProblemsOk = false;
                }
                that.treatmentDischargeFormViewModel.IsAllRequiredProblemsOk = isAllRequiredProblemsOk;
                //that.ArrangeStateButtons();
                //that.ArrangeTitles();
            })
            .catch(error => {
                console.log(error);
            });
    }

    dynamicComponentActionExecuted(eventParam: any) {
        this.RefreshProblems();
    }


    public onComponentCreated(componentRef: ComponentRef<any>): void {
        let eventName = 'nursingDynamicComponentSavedEventEmitter';

        let funcCheck = <any>componentRef.instance[eventName];
        if (funcCheck != null) {
            if (funcCheck instanceof EventEmitter) {
                let targetEvent = funcCheck as EventEmitter<any>;
                let boundedFunc = this.RefreshProblems.bind(this);
                this.saveEventSubscription = targetEvent.subscribe(boundedFunc);
            }
        }
    }

    ngOnDestroy() {
        if (this.saveEventSubscription != null) {
            this.saveEventSubscription.unsubscribe();
        }
    }


    //  State Buton Adı ve Başlık Düzenlemek için
    public treatmentTitle: string = i18n("M22556", "Taburcu İşlemleri");
    public dischargeButtonTitle: string = i18n("M30115", "Taburcu Et");

    public stateButtonList: Array<TTObjectStateTransitionDef>;
    public onStateButtonsRendered(stateList: Array<TTObjectStateTransitionDef>) {
        this.loadPanelOperation(true, 'İşlemler tamamlanıyor. Lütfen Bekleyiniz.');

        this.stateButtonList = stateList;
        if (this.stateButtonList != null && this.stateButtonList.length > 0) {
            this.ArrangeTitles();
        }

        this.loadPanelOperation(false, '');
    }
    public ArrangeTitles() {

        if (this.dischargeType == DischargeTypeEnum.TransferingToOtherlHospital) {
            this.treatmentTitle = i18n("M18044", "Kurum Dışı Sevk İşlemleri");
        }
        if (this.dischargeType == DischargeTypeEnum.TransferToOtherClinic) {
            this.treatmentTitle = i18n("M18070", "Kurum İçi Sevk İşlemleri");
        }
        if (this.dischargeType == DischargeTypeEnum.TransferingToOtherlHospital) {
            this.dischargeButtonTitle = i18n("M18043", "Kurum Dışına Sevk");
        }
        if (this.dischargeType == DischargeTypeEnum.TransferToOtherClinic) {
            this.dischargeButtonTitle = i18n("M18069", "Kurum İçine Sevk");
        }
        //if (this._TreatmentDischarge.CurrentStateDefID.toString() == TreatmentDischarge.TreatmentDischargeStates.PreDischarge.id) {
        //    if (this.stateButtonList != null && this.stateButtonList.length > 0) {
        //        let state = this.stateButtonList.find(dr => dr.ToStateDefID.toString() == TreatmentDischarge.TreatmentDischargeStates.Discharged.id); // Discharge'a giden button
        //        if (state != null) {
        //            if (this.dischargeType == DischargeTypeEnum.TransferingToOtherlHospital) {
        //                state.DisplayText = 'Kurum Dışına Sevk Et';
        //            }
        //            if (this.dischargeType == DischargeTypeEnum.TransferToOtherClinic) {
        //                state.DisplayText = 'Kurum İçine Sevk Et';
        //            }
        //        }

        //    }
        //}
    }

    public dischargeButtonVisible: boolean = false;
    public ArrangeStateButtons() {
        if (this._TreatmentDischarge.CurrentStateDefID.toString() == TreatmentDischarge.TreatmentDischargeStates.New.id) {
            this.DropStateButton(TreatmentDischarge.TreatmentDischargeStates.Cancelled);
            this.dischargeButtonVisible = true;
        }
        //if (this._TreatmentDischarge.CurrentStateDefID.toString() == TreatmentDischarge.TreatmentDischargeStates.PreDischarge.id) {
        //    // Zorunlu olup Checkted false olan varsa drop edilmeli
        //    if (this.treatmentDischargeFormViewModel.IsAllRequiredProblemsOk) {
        //        this.AddStateButton(TreatmentDischarge.TreatmentDischargeStates.Discharged);
        //    } else {
        //        this.DropStateButton(TreatmentDischarge.TreatmentDischargeStates.Discharged);
        //    }
        //}
    }

    public returnToMasterAction(transDef: TTObjectStateTransitionDef) {
        if (transDef.FromStateDefID.valueOf() == TreatmentDischarge.TreatmentDischargeStates.New.id) {
            if (this.treatmentDischargeFormViewModel.MasterActionObjectDefName != null)
                this.httpService.episodeActionWorkListSharedService.openLikeWorkListDynamicComponent(this.treatmentDischargeFormViewModel.MasterActionObjectDefName, this.getMasterActionObjectID(), null, new DynamicComponentInputParam(null, new ActiveIDsModel(null, null, null)));
        }
    }

    protected getMasterActionObjectID(): string {
        if (this._TreatmentDischarge.MasterAction != null) {
            if (typeof this._TreatmentDischarge.MasterAction === "string") {
                return this._TreatmentDischarge.MasterAction;
            }
            else if (this._TreatmentDischarge.MasterAction.ObjectID != null)
                return this._TreatmentDischarge.MasterAction.ObjectID.toString();
        }

        return null;
    }

    protected loadSpecialViewModel() {

        this.ProcedureDoctor.ListFilterExpression = this.treatmentDischargeFormViewModel.ProcedureDoctorFilterExpression;
        if (this.treatmentDischargeFormViewModel._TreatmentDischarge.DischargeType == null) {

            if (this.dischargeType == DischargeTypeEnum.TransferToOtherClinic) {
                this.treatmentDischargeFormViewModel._TreatmentDischarge.DischargeType = this.treatmentDischargeFormViewModel.TransferToOtherClinicDischargeTypeDefinition;
            }
            else if (this.dischargeType == DischargeTypeEnum.TransferingToOtherlHospital) {
                this.treatmentDischargeFormViewModel._TreatmentDischarge.DischargeType = this.treatmentDischargeFormViewModel.TransferToOtherHospitalDischargeTypeDefinition;
            }
            else {
                this.DischargeType.ListFilterExpression = this.treatmentDischargeFormViewModel.DischargeTypeFilterExpression;
            }
        }
        else {

            if (this.treatmentDischargeFormViewModel._TreatmentDischarge.DischargeType.ObjectID == this.treatmentDischargeFormViewModel.TransferToOtherClinicDischargeTypeDefinition.ObjectID) {

                this.dischargeType = DischargeTypeEnum.TransferToOtherClinic;
            }
            else if (this.treatmentDischargeFormViewModel._TreatmentDischarge.DischargeType.ObjectID == this.treatmentDischargeFormViewModel.TransferToOtherHospitalDischargeTypeDefinition.ObjectID) {
                this.dischargeType = DischargeTypeEnum.TransferingToOtherlHospital;
            }
            else {
                this.DischargeType.ListFilterExpression = this.treatmentDischargeFormViewModel.DischargeTypeFilterExpression;
            }
        }

        if (this.dischargeType == DischargeTypeEnum.TransferingToOtherlHospital) {
            this.isDischargeTypeTransferingToOtherlHospital = true;
            this.openSevkComponentInfo();
        }

    }

    ArrangeReadOnlyFields() {
        if (this.dischargeType == DischargeTypeEnum.TransferToOtherClinic || this.dischargeType == DischargeTypeEnum.TransferingToOtherlHospital) {
            this.DischargeType.ReadOnly = true;
            this.DischargeType.Enabled = false;
            if (this.dischargeType == DischargeTypeEnum.TransferToOtherClinic) {
                this.DisChargeDate.ReadOnly = true;
                this.DisChargeDate.Enabled = false;
            }
        }


        if (this._TreatmentDischarge.CurrentStateDefID.toString() != TreatmentDischarge.TreatmentDischargeStates.New.id) {
            this.DisChargeDate.ReadOnly = true;
            this.DisChargeDate.Enabled = false;
        }
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);
        this.returnToMasterAction(transDef);
    }

    // NeStatePanelComponent taklidi


    onDischargeButtonClicked() {
        if (!this.treatmentDischargeFormViewModel.IsAllRequiredProblemsOk) {
            this.messageService.showError(i18n("M30116", "Taburcu Kontrol Listesi tamamlanmadan işlem gerçekleştirilemez"));
            return;
            // throw new Exception(i18n("M30116", "Taburcu Kontrol Listesi tamamlanmadan işlem gerçekleştirilemez"));
        }

        this.loadPanelOperation(true, 'İşlemler tamamlanıyor. Lütfen Bekleyiniz.');

        this.treatmentDischargeFormViewModel.advanceToDischarge = true;
        this.clickedByDischargeButton = true;
        if (this.stateButtonList != null && this.stateButtonList.length > 0) {
            let state = this.stateButtonList.find(dr => dr.ToStateDefID.toString() == TreatmentDischarge.TreatmentDischargeStates.PreDischarge.id); // "f2ace28c-8f92-4f8e-9ba5-e56edcec6328");  PreDischarge'a giden button
            if (state != null) {
                let formSaveInfo; new FormSaveInfo(this.treatmentDischargeFormViewModel._TreatmentDischarge.ObjectDefID.toString(), this.saveAndCloseCommandVisible);
                this.setState(state, formSaveInfo);
            }
        }

        this.loadPanelOperation(false, '');
    }

    //

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
        // yatan medula hastaları için MTS de taburcu tipi 'Tedaviden Vazgeçme' seçildiğinde uyarı verilmesi istendi
        //if ((this.treatmentDischargeFormViewModel.isSGKSubEpisode && this._TreatmentDischarge.InPatientTreatmentClinicApp !== null && Convert.ToDateTime(this._TreatmentDischarge.InPatientTreatmentClinicApp.ClinicInpatientDate) !== null && this._TreatmentDischarge.GetMyDischargeTypeEnum() === DischargeTypeEnum.RejectTreatment) {
        //    if (transDef.FromStateDefID.valueOf() === TreatmentDischarge.TreatmentDischargeStates.New.id && (transDef.ToStateDefID.valueOf() === TreatmentDischarge.TreatmentDischargeStates.Complete.id)) {
        //        let result: string = TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Emin misiniz?", "Taburcu Tipi 'TIBBİ ÖNERİLERİ/TEDAVİLERİ REDDEREDEK ÇIKIŞ' seçildiği takdirde Medula hizmet fiyatlarında %10 kesinti yapacaktır.Devam etmek istediğinize emin misiniz?", 1);
        //        if (result === "H") {
        //            throw new Exception((await SystemMessageService.GetMessage(678)));
        //        }
        //    }
        //}
    }
    public clickedByDischargeButton: boolean = false;
    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        let that = this;
        super.PostScript(transDef);
        if (transDef != null && transDef.ToStateDefID.toString() == TreatmentDischarge.TreatmentDischargeStates.Discharged.id) {
            if (!this.treatmentDischargeFormViewModel.IsAllRequiredProblemsOk) {
                // this.messageService.showError(i18n("M30116", "Taburcu Kontrol Listesi tamamlanmadan işlem gerçekleştirilemez"));
                throw new Exception(i18n("M30116", "Taburcu Kontrol Listesi tamamlanmadan işlem gerçekleştirilemez"));
            }
        }


        this.loadPanelOperation(true, 'İşlemler tamamlanıyor. Lütfen Bekleyiniz.');
        if (this.clickedByDischargeButton == false)
            this.treatmentDischargeFormViewModel.advanceToDischarge = false;
        this.clickedByDischargeButton = false; // herhangi bir butona basılınca bu değer hep false'a çekilir ki önce taburcuya basılıp hata alınırsa sonra ön taburcuya basılırsa sıkıntı çıkmasın
        await this.CheckOrdersToCancel();
        this.loadPanelOperation(false, '');

        if (transDef != null && transDef.ToStateDefID.toString() == TreatmentDischarge.TreatmentDischargeStates.Discharged.id || transDef != null && transDef.ToStateDefID.toString() == TreatmentDischarge.TreatmentDischargeStates.PreDischarge.id) {
            if (that.treatmentDischargeFormViewModel._TreatmentDischarge.DischargeType == null) {
                throw new Exception("Taburcu Tipi Boş Geçilemez!");
                this.loadPanelOperation(false, '');
            }
            let skrsCikisSekliID = that.treatmentDischargeFormViewModel._TreatmentDischarge.DischargeType["SKRSCikisSekli"];
            if (skrsCikisSekliID != null && (typeof skrsCikisSekliID === 'string')) {
                let skrsCikisSekli = that.treatmentDischargeFormViewModel.SKRSCikisSeklis.find(o => o.ObjectID.toString() === skrsCikisSekliID.toString());
                if (skrsCikisSekli.KODU == DischargeTypeEnum.Death.Value.toString()) {//Enumların değeri skrskodu olarak verildiği için bu şekilde karşılaştırıldı
                    //let obsURL = "http://xxxxxx.com/Account/Login";
                    //let win = window.open(obsURL, '_blank');
                    this.openOBS();
                }

            }
        }


    }
    protected async openOBS() {
        let that = this;
        this.loadPanelOperation(true, 'Ölüm Bildirim Ekranı Açılıyor, Lütfen Bekleyiniz.');
        let fullApiUrl: string = 'api/TreatmentDischargeService/OpenOBS?SubepisodeID=' + this.treatmentDischargeFormViewModel.SubepisodeID + '&ProcedureDoctorObjectIDForOBS=' + this.treatmentDischargeFormViewModel.ProcedureDoctorObjectIDForOBS;
        this.httpService.get(fullApiUrl).then((res: string) => {
            let win = window.open(res, '_blank');
            win.focus();
            this.loadPanelOperation(false, '');
        }).catch(error => {
            TTVisual.InfoBox.Alert(error);
            this.loadPanelOperation(false, '');
        });
    }

    protected async CheckOrdersToCancel() {
        if (this._TreatmentDischarge.InPatientTreatmentClinicApp != null) {
            let that = this;
            let checkOrdersToCancel_DocumentUrl: string = '/api/InPatientPhysicianApplicationService/GetOrdersToCancel';
            let _ordersToCancelParameterViewModel: OrdersToCancelParameterViewModel = new OrdersToCancelParameterViewModel();
            if (this._TreatmentDischarge.CurrentStateDefID.toString() == TreatmentDischarge.TreatmentDischargeStates.New.id) {
                _ordersToCancelParameterViewModel.IsPreDischarge = true;
                _ordersToCancelParameterViewModel.DischargeDate = this._TreatmentDischarge.DischargeDate;
            }
            else {
                _ordersToCancelParameterViewModel.IsPreDischarge = false;
            }

            if (typeof this._TreatmentDischarge.InPatientTreatmentClinicApp == "string")
                _ordersToCancelParameterViewModel.InPatientTreatmentClinicAppObjectID = this._TreatmentDischarge.InPatientTreatmentClinicApp;
            else
                _ordersToCancelParameterViewModel.InPatientTreatmentClinicAppObjectID = this._TreatmentDischarge.InPatientTreatmentClinicApp.ObjectID.toString();

            let getOrdersToCancelMsg: string = <string>await this.httpService.post<string>(checkOrdersToCancel_DocumentUrl, _ordersToCancelParameterViewModel);

            if (getOrdersToCancelMsg != null && getOrdersToCancelMsg != "") {

                let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), '', 'Order iptali ' +getOrdersToCancelMsg);
               // let result: string = await TTVisual.ShowBox.CustomShow(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), 'Order iptali', getOrdersToCancelMsg, 1);
                //let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Tamam,&Vazgeç', 'T,V', i18n("M23735", "Uyarı"), i18n("M19737", "Order iptali"),getOrdersToCancelMsg);
                if (result === 'V') {
                    this.loadPanelOperation(false, '');
                    throw new Exception(i18n("M22555", "Taburcu İşleminden Vazgeçildi"));
                }
            }
        }



    }




    protected async PreScript() {
        super.PreScript();


        this.DisChargeDate.Max = this._TreatmentDischarge.DischargeDate;
        this.DisChargeDate.Min = this.treatmentDischargeFormViewModel.ClinicInpatientDate;
        this.ArrangeStateButtons();
        this.loadSpecialViewModel();
        this.ArrangeTitles();
        this.ArrangeReadOnlyFields();
    }
    public async StartOutPatientPrescription(transDef: TTObjectStateTransitionDef): Promise<void> {
        //TODO:ShowEdit!
        //if (this._TreatmentDischarge.Episode.PatientStatus == PatientStatusEnum.Outpatient)
        //{
        //    if(transDef != null && transDef.ToStateDef.Status == StateStatusEnum.CompletedSuccessfully)
        //    {
        //        string result = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","Muayene Tedavi Sonuç","Hastaya 'Ayaktan Hasta Reçetesi' başlatmak ister misiniz?");
        //        if(result == "E")
        //        {
        //            OutPatientPrescription outPatientPrescription;
        //            TTObjectContext objectContext = new TTObjectContext(false);
        //            Guid savePointGuid = objectContext.BeginSavePoint();
        //            try
        //            {
        //                outPatientPrescription = new OutPatientPrescription(objectContext, this._EpisodeAction);
        //                TTForm frm = TTForm.GetEditForm(outPatientPrescription);
        //                this.PrapareFormToShow(frm);
        //                if(frm.ShowEdit(this.FindForm(), outPatientPrescription) == DialogResult.OK)
        //                    objectContext.Save();
        //            }
        //            catch (Exception ex)
        //            {
        //                objectContext.RollbackSavePoint(savePointGuid);
        //                InfoBox.Alert(ex);

        //            }
        //            finally
        //            {
        //                objectContext.Dispose();
        //            }
        //        }
        //    }
        //}
    }



    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new TreatmentDischarge();
        this.treatmentDischargeFormViewModel = new TreatmentDischargeFormViewModel();
        this._ViewModel = this.treatmentDischargeFormViewModel;
        this.treatmentDischargeFormViewModel._TreatmentDischarge = this._TTObject as TreatmentDischarge;
        this.treatmentDischargeFormViewModel._TreatmentDischarge.TransferTreatmentClinic = new ResClinic();
        this.treatmentDischargeFormViewModel._TreatmentDischarge.DischargeType = new DischargeTypeDefinition();
        this.treatmentDischargeFormViewModel._TreatmentDischarge.ProcedureDoctor = new ResUser();
    }

    protected loadViewModel() {
        let that = this;

        that.treatmentDischargeFormViewModel = this._ViewModel as TreatmentDischargeFormViewModel;
        that._TTObject = this.treatmentDischargeFormViewModel._TreatmentDischarge;
        if (this.treatmentDischargeFormViewModel == null)
            this.treatmentDischargeFormViewModel = new TreatmentDischargeFormViewModel();
        if (this.treatmentDischargeFormViewModel._TreatmentDischarge == null)
            this.treatmentDischargeFormViewModel._TreatmentDischarge = new TreatmentDischarge();
        let transferTreatmentClinicObjectID = that.treatmentDischargeFormViewModel._TreatmentDischarge["TransferTreatmentClinic"];
        if (transferTreatmentClinicObjectID != null && (typeof transferTreatmentClinicObjectID === 'string')) {
            let transferTreatmentClinic = that.treatmentDischargeFormViewModel.ResClinics.find(o => o.ObjectID.toString() === transferTreatmentClinicObjectID.toString());
            if (transferTreatmentClinic) {
                that.treatmentDischargeFormViewModel._TreatmentDischarge.TransferTreatmentClinic = transferTreatmentClinic;
            }
        }
        let dischargeTypeObjectID = that.treatmentDischargeFormViewModel._TreatmentDischarge["DischargeType"];
        if (dischargeTypeObjectID != null && (typeof dischargeTypeObjectID === 'string')) {
            let dischargeType = that.treatmentDischargeFormViewModel.DischargeTypeDefinitions.find(o => o.ObjectID.toString() === dischargeTypeObjectID.toString());
            if (dischargeType) {
                that.treatmentDischargeFormViewModel._TreatmentDischarge.DischargeType = dischargeType;
            }
        }
        let procedureDoctorObjectID = that.treatmentDischargeFormViewModel._TreatmentDischarge["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.treatmentDischargeFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.treatmentDischargeFormViewModel._TreatmentDischarge.ProcedureDoctor = procedureDoctor;
            }
        }


        //this.ArrangeStateButtons();
        //this.loadSpecialViewModel();
    }


    async ngOnInit() {
        let that = this;
        await this.load(TreatmentDischargeFormViewModel);
        this.AddHelpMenu();
        if (this.dischargeType == DischargeTypeEnum.TransferToOtherClinic) {
            let transferableDrugOrder: TreatmentDischargeProblemViewModel = this.treatmentDischargeFormViewModel.TreatmentDischargeProblemList.find(x => x.problemDrugOrders.length > 0)
            if (transferableDrugOrder != null) {
                this.openTransferableDrugOrderComponent(transferableDrugOrder).then(res => {
                    let modalActionResult = res as ModalActionResult;
                    if (modalActionResult.Result === DialogResult.OK) {
                        this.RefreshProblems();
                    }
                });
            }
        }
    }
    private AddHelpMenu() {
        this.RemoveMenuFromHelpMenu();
        let openOBSWeb = new DynamicSidebarMenuItem();
        openOBSWeb.key = 'openOBS';
        openOBSWeb.icon = 'ai ai-obs';
        openOBSWeb.label = 'Ölüm Bildirim Sistemi'
        openOBSWeb.componentInstance = this;
        openOBSWeb.clickFunction = this.openOBS;
        openOBSWeb.parameterFunctionInstance = this;

        openOBSWeb.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', openOBSWeb);
    }

    public RemoveMenuFromHelpMenu(): void {
        this.sideBarMenuService.removeMenu('openOBSWeb');

    }
    public onConclusionChanged(event): void {
        if (event != null) {
            if (this._TreatmentDischarge != null && this._TreatmentDischarge.Conclusion != event) {
                this._TreatmentDischarge.Conclusion = event;
            }
        }
    }

    public onDisChargeDateChanged(event): void {
        if (event != null) {
            if (this._TreatmentDischarge != null && this._TreatmentDischarge.DischargeDate != event) {
                this._TreatmentDischarge.DischargeDate = event;
            }
        }
    }

    public async onDischargeTypeChanged(event) {
        if (event != null) {
            if (this._TreatmentDischarge != null && this._TreatmentDischarge.DischargeType != event) {
                this._TreatmentDischarge.DischargeType = event;
            }
            //Taburcu şekli ölüm seçildiğinde hastaya başlatılmış morg işlemi yoksa morg süreci başlatılıyor.
            let that = this;
            let skrsCikisSekliID = that.treatmentDischargeFormViewModel._TreatmentDischarge.DischargeType["SKRSCikisSekli"];
            if (skrsCikisSekliID != null && (typeof skrsCikisSekliID === 'string')) {
                let skrsCikisSekli = that.treatmentDischargeFormViewModel.SKRSCikisSeklis.find(o => o.ObjectID.toString() === skrsCikisSekliID.toString());

                if (!this.treatmentDischargeFormViewModel.HasMorgue) {

                    if (skrsCikisSekli.KODU == DischargeTypeEnum.Death.Value.toString())//Enumların değeri skrskodu olarak verildiği için bu şekilde karşılaştırıldı
                        this.getMorgueEpisodeAction();
                    else
                        this.treatmentDischargeFormViewModel._MorgueViewModel = null; //Taburcu tipi ölüm seçildikten sonra değiştirilirse morg başlatmamak için eklendi

                } else {
                    if (skrsCikisSekli.KODU != DischargeTypeEnum.Death.Value.toString()) { //Daha önce morg işlemi başlatılmış bir hastanın taburcu tipi değiştirildiyse
                        let morgueCancelMsg: string = i18n("M15512", "Hastaya başlatılmış morg işlemi bulunmaktadır.Taburcu tipini değiştirirseniz morg işlemi iptal edilecektir. Devam etmek istiyor musunuz?");

                        let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, '&Evet,&Hayır', 'E,H', i18n("M23735", "Uyarı"), '', morgueCancelMsg);
                        if (result === 'H')
                            this.treatmentDischargeFormViewModel._TreatmentDischarge.DischargeType = this.treatmentDischargeFormViewModel.DeathDefinition;

                    }
                }
            }

        }
    }

    public onProcedureDoctorChanged(event): void {
        if (event != null) {
            if (this._TreatmentDischarge != null && this._TreatmentDischarge.ProcedureDoctor != event) {
                this._TreatmentDischarge.ProcedureDoctor = event;
            }
        }
    }

    public onTransferTreatmentClinicChanged(event): void {
        if (event != null) {
            if (this._TreatmentDischarge != null && this._TreatmentDischarge.TransferTreatmentClinic != event) {
                this._TreatmentDischarge.TransferTreatmentClinic = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.DisChargeDate, "Value", this.__ttObject, "DischargeDate");
        redirectProperty(this.Conclusion, "Rtf", this.__ttObject, "Conclusion");
    }

    public initFormControls(): void {
        this.labelTransferTreatmentClinic = new TTVisual.TTLabel();
        this.labelTransferTreatmentClinic.Text = i18n("M21707", "Sevk Edileceği Klinik");
        this.labelTransferTreatmentClinic.Name = "labelTransferTreatmentClinic";
        this.labelTransferTreatmentClinic.TabIndex = 86;

        this.TransferTreatmentClinic = new TTVisual.TTObjectListBox();
        this.TransferTreatmentClinic.ListDefName = "ClinicListDefinition";
        this.TransferTreatmentClinic.Name = "TransferTreatmentClinic";
        this.TransferTreatmentClinic.TabIndex = 85;

        this.labelDischargeType = new TTVisual.TTLabel();
        this.labelDischargeType.Text = i18n("M22573", "Taburcu Tipi");
        this.labelDischargeType.Name = "labelDischargeType";
        this.labelDischargeType.TabIndex = 84;

        this.DischargeType = new TTVisual.TTObjectListBox();
        this.DischargeType.ListDefName = "DischargeTypeListDefinition";
        this.DischargeType.Name = "DischargeType";
        this.DischargeType.Required = true;
        this.DischargeType.TabIndex = 83;

        this.labelConclusion = new TTVisual.TTLabel();
        this.labelConclusion.Text = i18n("M10469", "Açıklama");
        this.labelConclusion.Name = "labelConclusion";
        this.labelConclusion.TabIndex = 82;

        this.Conclusion = new TTVisual.TTRichTextBoxControl();
        this.Conclusion.Name = "Conclusion";
        this.Conclusion.TabIndex = 81;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = "Taburcu Kararı Veren Tabip";
        this.labelProcedureDoctor.BackColor = "#DCDCDC";
        this.labelProcedureDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProcedureDoctor.ForeColor = "#000000";
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 68;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.Required = true;
        this.ProcedureDoctor.ListDefName = "DoctorListDefinition";
        this.ProcedureDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.Required = true;
        this.ProcedureDoctor.TabIndex = 6;

        this.DisChargeDate = new TTVisual.TTDateTimePicker();
        this.DisChargeDate.Required = true;
        this.DisChargeDate.BackColor = "#FFE3C6";
        this.DisChargeDate.CustomFormat = "";
        this.DisChargeDate.Format = DateTimePickerFormat.Short;
        this.DisChargeDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.DisChargeDate.Name = "DisChargeDate";
        this.DisChargeDate.TabIndex = 8;

        this.ttlabelDisChargeDate = new TTVisual.TTLabel();
        this.ttlabelDisChargeDate.Text = i18n("M22570", " Taburcu Tarihi");
        this.ttlabelDisChargeDate.BackColor = "#DCDCDC";
        this.ttlabelDisChargeDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabelDisChargeDate.ForeColor = "#000000";
        this.ttlabelDisChargeDate.Name = "ttlabelDisChargeDate";
        this.ttlabelDisChargeDate.TabIndex = 60;

        this.Controls = [this.labelTransferTreatmentClinic, this.TransferTreatmentClinic, this.labelDischargeType, this.DischargeType, this.labelConclusion, this.Conclusion, this.labelProcedureDoctor, this.ProcedureDoctor, this.DisChargeDate, this.ttlabelDisChargeDate];

    }


    getMorgueEpisodeAction() {

        let episodeID: Guid = <any>this.treatmentDischargeFormViewModel._TreatmentDischarge['Episode'];
        this.episodeActionHelper.getNewEpisodeAction(Morgue.ObjectDefID, episodeID, Morgue.MorgueStates.Request).then(result => {
            let morgue: Morgue = result as Morgue;
            this.openMorgueExDischargeForm(morgue).then(result => {
                let modalActionResult = result as ModalActionResult;

            });
        }).catch(err => {
            this.messageService.showError(err);
        });
    }

    openMorgueExDischargeForm(morgue: Morgue): Promise<ModalActionResult> {
        let that = this;
        return new Promise((resolve, reject) => {
            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "MorgueExDischargeForm";
            componentInfo.ModuleName = "MorgModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Morg_Modulu/MorgModule";
            componentInfo.objectID = "";

            let selectedActionID: Guid = <any>this.treatmentDischargeFormViewModel._TreatmentDischarge['MasterAction'];
            componentInfo.InputParam = new DynamicComponentInputParam(true, new ActiveIDsModel(selectedActionID, null, null));


            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = i18n("M19128", "Morg İşlemleri");
            modalInfo.Width = 1000;
            modalInfo.Height = 760;

            let result = this.modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
                let morgueVM: MorgueExDischargeFormViewModel = inner.Param as MorgueExDischargeFormViewModel;
                if (morgueVM === undefined)
                    this.treatmentDischargeFormViewModel._TreatmentDischarge.DischargeType = null;
                else {
                    this.treatmentDischargeFormViewModel._MorgueViewModel = morgueVM;
                }
                //formu doldurmazsa taburcu şeklini resetle
            }).catch(err => {
                reject(err);
            });
        });
    }

    public openTransferableDrugOrderComponent(transferableDrugOrder: TreatmentDischargeProblemViewModel): Promise<ModalActionResult> {

        return new Promise((resolve, reject) => {

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = 'TransferableDrugOrderComponent';
            componentInfo.ModuleName = 'LogisticFormsModule';
            componentInfo.ModulePath = '/app/Logistic/LogisticFormsModule';
            componentInfo.InputParam = transferableDrugOrder.problemDrugOrders;

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Tedavisi Devam Eden İlaçlar";
            modalInfo.Width = 650;
            modalInfo.Height = 400;
            modalInfo.IsShowCloseButton = false;

            let modalService: IModalService = ServiceLocator.Injector.get(IModalService, [ServiceLocator.Compiler]);
            let result = modalService.create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }



}
