//$89EC1929
import { Component, ViewChild, OnInit, ApplicationRef, OnDestroy, NgZone } from '@angular/core';
import { InPatientTreatmentClinicAcceptionFormViewModel } from './InPatientTreatmentClinicAcceptionFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { HvlDatePicker } from 'Fw/Components/HvlDatePicker';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseInpatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { InputFormat } from "NebulaClient/Utils/Enums/InputFormat";
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { InPatientTreatmentClinicApplication } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ShowBoxTypeEnum } from 'NebulaClient/Utils/Enums/ShowBoxTypeEnum';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { ResBed } from 'NebulaClient/Model/AtlasClientModel';
import { ResRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResRoomGroup } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResWard } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { CompanionApplicationForm } from './CompanionApplicationForm';
import { CompanionApplicationComponentInfoViewModel } from './CompanionApplicationFormViewModel';
import { InpatientAdmissinDepositMaterialForm } from './InpatientAdmissinDepositMaterialForm';
import { DepositComponentInfoViewModel } from './InpatientAdmissinDepositMaterialFormViewModel';
//<atlas-form-editor  için
import { NqlQueryService } from 'app/QueryList/Services/nql-query.service';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { QueryParams } from 'app/QueryList/Models/QueryParams';
import { ModalInfo, IModal, ModalActionResult } from "Fw/Models/ModalInfo";
import { IModalService } from "Fw/Services/IModalService";
import { SelectedBedViewModel } from './BedSelectionFormViewModel';

import { ISidebarMenuService } from 'Fw/Services/ISidebarMenuService';
import { DynamicSidebarMenuItem } from 'app/SidebarMenu/Models/DynamicSidebarMenuItem';
import { HelpMenuService } from "Fw/Services/HelpMenuService";

import { InpatientWristBarcodeInfo } from 'app/Barcode/Models/InpatientWristBarcodeInfo';
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';


import { FormSaveInfo } from 'NebulaClient/Mscorlib/FormSaveInfo';
import { CommonService } from 'app/NebulaClient/Services/ObjectService/CommonService';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel, ClickFunctionParams } from 'app/Fw/Models/ParameterDefinitionModel';
import { InputForm, ShowBox } from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { MessageIconEnum } from 'app/NebulaClient/Utils/Enums/MessageIconEnum';
import { SystemApiService } from '../../../wwwroot/app/Fw/Services/SystemApiService';
import { ServiceLocator } from '../../../wwwroot/app/Fw/Services/ServiceLocator';
import { GivenInpatientAppointmentFormViewModel, InpatientAppointmentInfo } from '../Randevu_Modulu/GivenInpatientAppointmentFormViewModel';

@Component({
    selector: 'InPatientTreatmentClinicAcceptionForm',
    templateUrl: './InPatientTreatmentClinicAcceptionForm.html',
    providers: [MessageService, NqlQueryService]
})
export class InPatientTreatmentClinicAcceptionForm extends EpisodeActionForm implements OnInit, OnDestroy, IModal {
    @ViewChild('klinikYatis') klinikYatis: HvlDatePicker;
    Bed: TTVisual.ITTObjectListBox;
    ClinicInPatientDate: TTVisual.ITTDateTimePicker;
    EstimatedDischargeDate: TTVisual.ITTDateTimePicker;
    EstimatedInpatientDate: TTVisual.ITTDateTimePicker;
    EstimatedInpatientDateCount: TTVisual.ITTTextBox;
    HasAirborneContactIsolationBaseInpatientAdmission: TTVisual.ITTCheckBox;
    HasContactIsolationBaseInpatientAdmission: TTVisual.ITTCheckBox;
    HasDropletIsolationBaseInpatientAdmission: TTVisual.ITTCheckBox;
    HasFallingRiskBaseInpatientAdmission: TTVisual.ITTCheckBox;
    HasTightContactIsolationBaseInpatientAdmission: TTVisual.ITTCheckBox;
    HospitalInpatientDate: TTVisual.ITTDateTimePicker;
    InpatientProtocolNo: TTVisual.ITTTextBox;
    labelBed: TTVisual.ITTLabel;
    labelClinicInpatientDate: TTVisual.ITTLabel;
    LabelDateTime: TTVisual.ITTLabel;
    labelEstimatedDischargeDate: TTVisual.ITTLabel;
    labelEstimatedInpatientDate: TTVisual.ITTLabel;
    labelHospitalInpatientDate: TTVisual.ITTLabel;
    labelInpatientDepartment: TTVisual.ITTLabel;
    labelInpatientProtocolNo: TTVisual.ITTLabel;
    labelLongInpatientReason: TTVisual.ITTLabel;
    labelNumberOfEmptyBeds: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelQuarantineProtocolNo: TTVisual.ITTLabel;
    labelResponsibleDoctor: TTVisual.ITTLabel;
    labelResponsibleNurse: TTVisual.ITTLabel;
    labelShotInpatientReason: TTVisual.ITTLabel;
    LongInpatientReason: TTVisual.ITTTextBox;
    MasterResource: TTVisual.ITTObjectListBox;
    NeedCompanion: TTVisual.ITTCheckBox;
    NumberOfEmptyBeds: TTVisual.ITTTextBox;
    PhysicalStateClinic: TTVisual.ITTObjectListBox;
    QuarantineProtocolNo: TTVisual.ITTTextBox;
    RequestDate: TTVisual.ITTDateTimePicker;
    RequestDoctor: TTVisual.ITTObjectListBox;
    ResponsibleDoctor: TTVisual.ITTObjectListBox;
    ResponsibleNurse: TTVisual.ITTObjectListBox;
    Room: TTVisual.ITTObjectListBox;
    RoomGroup: TTVisual.ITTObjectListBox;
    ShotInpatientReason: TTVisual.ITTTextBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel18: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttpanel1: TTVisual.ITTPanel;
    tttextbox6: TTVisual.ITTTextBox;
    TurnReserveToUsed: TTVisual.ITTButton;
    loadingVisible: boolean = false;
    panelMessage: string = "İşlem Yapılıyor, Lütfen Bekleyiniz";
    public inPatientTreatmentClinicAcceptionFormViewModel: InPatientTreatmentClinicAcceptionFormViewModel = new InPatientTreatmentClinicAcceptionFormViewModel();
    public get _InPatientTreatmentClinicApplication(): InPatientTreatmentClinicApplication {
        return this._TTObject as InPatientTreatmentClinicApplication;
    }
    private InPatientTreatmentClinicAcceptionForm_DocumentUrl: string = '/api/InPatientTreatmentClinicApplicationService/InPatientTreatmentClinicAcceptionForm';
    constructor(private sideBarMenuService: ISidebarMenuService,
        protected httpService: NeHttpService,
        protected messageService: MessageService,
        private app: ApplicationRef,
        protected helpMenuService: HelpMenuService,
        protected ngZone: NgZone,
        private barcodePrintService: IBarcodePrintService,
        protected modalService: IModalService) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.InPatientTreatmentClinicAcceptionForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****

    //#region Yatan Hasta Randevu
    public showInpatientAppointmentPopup: boolean = false;
    public InpatientAppointmentComponentInfo: DynamicComponentInfo = new DynamicComponentInfo();
    public openAppointmentForm() {
        this.showInpatientAppointmentPopup = true;
        this.openDynamicComponent(null, this.inPatientTreatmentClinicAcceptionFormViewModel.AppointmentId, null, null);
    }

    openDynamicComponent(objectDefName?: any, objectID?: any, formDefId?: any, inputparam?: any) {

        let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
        if (objectID != null && objectID != "") {
            compInfo.objectID = objectID;
        } else {
            compInfo.objectID = null;
        }
        compInfo.ComponentName = 'InpatientAppInfoForm';
        compInfo.ModuleName = 'RandevuModule';
        compInfo.ModulePath = 'Modules/Tibbi_Surec/Randevu_Modulu/RandevuModule';
        compInfo.InputParam = new DynamicComponentInputParam(null, new ActiveIDsModel(this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.ObjectID, null, null));
        compInfo.CloseWithStateTransition = true;
        compInfo.DestroyComponentOnSave = true;
        compInfo.RefreshComponent = true;

        this.InpatientAppointmentComponentInfo = compInfo;
    }
    public dynamicComponentActionExecuted(e: any) {
        this.showInpatientAppointmentPopup = false;
    }
    public dynamicComponentClosed(e: any) {
        this.showInpatientAppointmentPopup = false;
    }
    //#endregion

    //#region Yatış Bekliyor Statüsü için
    public _isTreatmentClinicAcception = false;
    public _buttonCaption: string = "Yatış Bekliyor";
    public _customButtonType: string = "success";
    async setTreatmentClinicAcceptionWaiting() {
        if (this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.InpatientAcceptionType == null) {//yatış bekliyor durumunda ise iptal fonksiyonu çalışmalı

            let that = this;
            that.httpService.get<any>("api/InPatientTreatmentClinicApplicationService/SetTreatmentClinicAcceptionWaiting?ObjectID=" + this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.ObjectID + "&ObjectDefID=" + this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.ObjectDefID)
                .then(response => {
                    this.messageService.showSuccess("İşlem Başarılı bir şekilde 'Yatış Bekliyor' statüsüne alındı");
                    this.ngOnInit();// await this.load(InPatientTreatmentClinicAcceptionFormViewModel);
                    this.httpService.episodeActionWorkListSharedService.refreshWorklist(this.isRefreshWorkList);
                })
                .catch(error => {
                    this.messageService.showError(error);

                });
        } else {
            let that = this;
            that.httpService.get<any>("api/InPatientTreatmentClinicApplicationService/CancelTreatmentClinicAcceptionWaiting?ObjectID=" + this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.ObjectID + "&ObjectDefID=" + this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.ObjectDefID)
                .then(response => {
                    this.messageService.showSuccess("İşlem Başarılı bir şekilde 'Yatış Bekliyor' statüsünden kaldırıldı");
                    this.ngOnInit();
                    this.httpService.episodeActionWorkListSharedService.refreshWorklist(this.isRefreshWorkList);
                })
                .catch(error => {
                    this.messageService.showError(error);

                });
        }

    }
    //#endregion


    // <refakatçi ve Emanet işlemleri için
    // save Methodu override ediliyor

    protected async save(): Promise<void> {
        this.savecompanionComponent = true;
        this.savedepositComponent = true;

        super.save();
    }

    protected async setState(transDef: TTObjectStateTransitionDef, saveInfo?: FormSaveInfo): Promise<void> {
        this.savecompanionComponent = true;
        this.savedepositComponent = true;
        await super.setState(transDef, saveInfo);
    }

    public setInputParam(value: Object) {

    }

    // private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        if (value) {
            value.Title = i18n("M17634", "Yatan Hasta Klinik İşlemleri");
            value.Width = 1250;
            value.Height = 768;
        }
        this._modalInfo = value;
    }

    public savedepositComponent: boolean;
    public depositComponentInfo: DynamicComponentInfo;
    public depositQueryParameters: QueryParams;

    protected getDepositInfo() {
        let depositInfoViewModel: DepositComponentInfoViewModel = InpatientAdmissinDepositMaterialForm.getDepositInfoViewModel(this.getEpisodeObjectId());
        this.depositQueryParameters = depositInfoViewModel.depositQueryParameters;
        this.depositComponentInfo = depositInfoViewModel.depositComponentInfo;

    }

    functionFirstEntry = true;
    depositQueryResultLoaded(e: any) {
        InpatientAdmissinDepositMaterialForm.queryResultLoaded(e);
        if(e != null && this.functionFirstEntry == false){
            if(this.inPatientTreatmentClinicAcceptionFormViewModel.HasDepositMaterial == false){
                this.inPatientTreatmentClinicAcceptionFormViewModel.HasDepositMaterial = true;
            }
        }
        this.functionFirstEntry = false;
    }


    public savecompanionComponent: boolean;
    public companionComponentInfo: DynamicComponentInfo;
    public companionQueryParameters: QueryParams;

    protected getComponentInfo() {
        let componentInfoViewModel: CompanionApplicationComponentInfoViewModel = CompanionApplicationForm.getComponentInfoViewModel(this._InPatientTreatmentClinicApplication.ObjectID);
        this.companionQueryParameters = componentInfoViewModel.companionQueryParameters;
        this.companionComponentInfo = componentInfoViewModel.companionComponentInfo;

    }

    componentQueryResultLoaded(e: any) {
        CompanionApplicationForm.queryResultLoaded(e);
    }


    protected getEpisodeObjectId(): Guid {

        if (this._InPatientTreatmentClinicApplication.Episode != null) {
            if (typeof this._InPatientTreatmentClinicApplication.Episode === "string") {
                return this._InPatientTreatmentClinicApplication.Episode;
            }
            else {
                return this._InPatientTreatmentClinicApplication.Episode.ObjectID;
            }
        }
        return null;
    }



    // refakatçi ve emanet işlemleri için>

    public isQuarantineInPatientDateExists: boolean;
    //QuarantineInPatientDateExists()
    //{
    //    if (this._InPatientTreatmentClinicApplication.Episode.QuarantineInPatientDate == null)
    //        return false;
    //    return true;
    //}

    //getInPatientDate(): Date {
    //if (this._InPatientTreatmentClinicApplication.Episode.QuarantineInPatientDate != null)
    //    return this._InPatientTreatmentClinicApplication.Episode.QuarantineInPatientDate;
    //return this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.EstimatedInpatientDate;
    //}


    //private async btnShowGivenMaterialsStatus_Click(): Promise<void> {
    //    let givenMsg: string = (await EpisodeService.GivenValuableMaterialsMsg(this._InPatientTreatmentClinicApplication.Episode));
    //    let takenMsg: string = (await EpisodeService.TakenValuableMaterialsMsg(this._InPatientTreatmentClinicApplication.Episode));
    //    this.GivenStatus.Text = givenMsg;
    //    this.TakenStatus.Text = takenMsg;
    //}
    private async MasterResource_SelectedObjectChanged(): Promise<void> {
        //if (this._InPatientTreatmentClinicApplication.ToTransferObject === null) {
        //    this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.TreatmentClinic = <ResClinic>this.MasterResource.SelectedObject;
        //    this._InPatientTreatmentClinicApplication.Episode.TreatmentClinic = <ResClinic>this.MasterResource.SelectedObject;
        //}
        //for (let nursingApplication of this._InPatientTreatmentClinicApplication.NursingApplications) {
        //    nursingApplication.MasterResource = <ResSection>this.MasterResource.SelectedObject;
        //}
        //for (let InpatientPhyApp of this._InPatientTreatmentClinicApplication.InPatientPhysicianApplication) {
        //    InpatientPhyApp.MasterResource = <ResSection>this.MasterResource.SelectedObject;
        //}
    }
    //private async NoCupboard_CheckedChanged(): Promise<void> {
    //    if (this.NoCupboard.Value === true) {
    //        this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Cupboard = null;
    //        this.Cupboard.ReadOnly = true;
    //    }
    //    else {
    //        this.Cupboard.ReadOnly = false;
    //    }
    //}
    //private async PhysicalStateClinic_SelectedObjectChanged(): Promise<void> {
    //    this.SetFirstEmptyBedByPhysicalStateClinic();
    //}
    //private async Room_SelectedObjectChanged(): Promise<void> {
    //    this.SetFirstEmptyBedByRoom();
    //}
    //private async RoomGroup_SelectedObjectChanged(): Promise<void> {
    //    this.SetNumberOfEmptyBedsByPhysicalStateClinic();
    //    this.SetFirstEmptyBedByRoomGroup();
    //}

    //private async TurnReserveToUsed_Click(): Promise<void> {
    //    if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission !== null) {
    //        let myResevedToUsedBedList: Array<BaseBedProcedure> = (await BaseBedProcedureService.GetByBaseInpatientAdmissionAndUseStatus(this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.ObjectID.toString(), UsedStatusEnum.ReservedToUse));
    //        let result: string = "";
    //        for (let myResevedToUsedBed of myResevedToUsedBedList) {
    //            if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed !== null) {
    //                if (myResevedToUsedBed.Bed.ObjectID !== this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed.ObjectID) {
    //                    myResevedToUsedBed.UsedStatus = UsedStatusEnum.WasReserved;
    //                    result = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Rezerveye,&Seçilene", "R,S", "Uyarı", "Hastayı Hangi Yatağa Yatırmak İstersiniz?", "Hastanın rezerve yatağı " + myResevedToUsedBed.Bed.Name + " iken . Yatak alanından " + this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed.Name + " seçilmişdir hastayı hangi yatağa yatırmak istersiniz?", 1);
    //                    if (result === "") {
    //                        TTVisual.InfoBox.Show("İşlemden vazgeçildi");
    //                        return;
    //                    }
    //                }
    //            }
    //            else {
    //                result = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Rezerveye Al,&Boşalt", "R,B", "Uyarı", "Hastayı Hangi Yatağa Yatırmak İstersiniz?", "Hastanın rezerve yatağı " + myResevedToUsedBed.Bed.Name + " iken yatak alanı boş altılmıştır", 1);
    //                if (result === "") {
    //                    TTVisual.InfoBox.Show("İşlemden vazgeçildi");
    //                    return;
    //                }
    //            }
    //            myResevedToUsedBed.UsedStatus = UsedStatusEnum.WasReserved;
    //            if (result === "R") {
    //                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.RoomGroup = myResevedToUsedBed.RoomGroup;
    //                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Room = myResevedToUsedBed.Room;
    //                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed = myResevedToUsedBed.Bed;
    //            }
    //            if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed !== null) {
    //                let baseBedProcedure: BaseBedProcedure = new BaseBedProcedure(this._InPatientTreatmentClinicApplication.ObjectContext);
    //                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.BedProcedures.push(baseBedProcedure);
    //                baseBedProcedure.Bed = this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed;
    //                baseBedProcedure.Room = this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Room;
    //                baseBedProcedure.RoomGroup = this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.RoomGroup;
    //                baseBedProcedure.UsedStatus = UsedStatusEnum.Used;
    //            }
    //            break;
    //        }
    //        if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed !== null) {
    //            TTVisual.InfoBox.Show("Hasta " + this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed.Name + " yatağına alınacaktır.Lütfen işlemi kaydetmeyi unutmayınız!");
    //        }
    //        else {
    //            TTVisual.InfoBox.Show("Hastanın rezervasyonlu yatağı boşaltılacaktır.Lütfen işlemi kaydetmeyi unutmayınız!");
    //        }
    //    }
    //}

    showPopup: boolean = false;
    openClinicProsedure_onClick() {
        this.showPopup = true;
    }

    isSaveAndCancelCommandVisible: boolean;

    protected async PostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.PostScript(transDef);

        if (this._InPatientTreatmentClinicApplication.MasterResource == null)
            throw new Exception(i18n("M15486", "Hastanın Tedavi Gördüğü Klinik' boş geçilemez"));
        if (transDef !== null) {
            if (transDef.ToStateDefID.valueOf() !== InPatientTreatmentClinicApplication.InPatientTreatmentClinicApplicationStates.Cancelled.id) {
                if (this._InPatientTreatmentClinicApplication.ProcedureDoctor === null)
                    throw new Exception(i18n("M22143", "Sorumlu Doktor' alanı boş geçilemez."));
            }
            if (transDef.ToStateDefID.valueOf() === InPatientTreatmentClinicApplication.InPatientTreatmentClinicApplicationStates.Rejected.id) {
                let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", i18n("M23735", "Uyarı"), i18n("M23735", "Uyarı"), "Hastanın yatış kabulü reddedilecektir. \nDevam etmek istediğinize emin misiniz?", 1);
                if (result === "H")
                    throw new Exception(i18n("M16907", "İşlemden vazgeçildi"));
            }

            //ön kabulden kabule geçişte randevu kontrolü
            if (transDef.FromStateDefID.valueOf() === InPatientTreatmentClinicApplication.InPatientTreatmentClinicApplicationStates.PreAcception.id && transDef.ToStateDefID.valueOf() === InPatientTreatmentClinicApplication.InPatientTreatmentClinicApplicationStates.Acception.id) {
                let result = await this.showGivenInpatientAppointmentForm();
                if (result.Param != null) {
                    this.inPatientTreatmentClinicAcceptionFormViewModel._InpatientAppointmentInfo = result.Param[0] as InpatientAppointmentInfo;
                }
            }

            //<servera alındı
            //if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission instanceof InpatientAdmission) {
            //    if (transDef.ToStateDefID === InPatientTreatmentClinicApplication.InPatientTreatmentClinicApplicationStates.Procedure) {
            //        if (this.RequiresAdvance())
            //            throw new Exception((await SystemMessageService.GetMessage(137)));
            //    }
            //}
            //servera alındı>
        }
        TTVisual.InfoBox.Alert("Uyarı", "Nutrisyonel değerlendirme formunu doldurmanız gerekmektedir.", MessageIconEnum.WarningMessage)
        // let result: string = await ShowBox.Show(1, '&Evet,&Hayır', 'OK,CANCEL', i18n("M23735", "Uyarı"), "", "asdasd", 1);
        try {

        } catch (e) {
            let fgfgh = "";
        }
    }

    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
        //throw new Exception('Teknisyen Seçimi .');
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);
        if (this.inPatientTreatmentClinicAcceptionFormViewModel.InpatientAcceptionMessage != null && this.inPatientTreatmentClinicAcceptionFormViewModel.InpatientAcceptionMessage != "") {
            TTVisual.InfoBox.Show(this.inPatientTreatmentClinicAcceptionFormViewModel.InpatientAcceptionMessage, MessageIconEnum.ErrorMessage);
        }
    }
    async setReasonOfCancel(note: string) {
        let returnReason: string = await InputForm.GetText(note + i18n("M14794", ""), "", true, true);
        if (returnReason != null && returnReason != "" && typeof returnReason === "string") {
            this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.ReasonOfCancel = i18n("M16527", "İptal - ") + returnReason;
        }
        else
            throw new Exception(i18n("M16563", "İptal sebebini girmeden işleme devam edemezsiniz."));

    }

    showLongInpatientReason: boolean = false;
    showShortInpatientReason: boolean = false;
    protected async PreScript(): Promise<void> {
        this.PhysicalStateClinic.ReadOnly = this.inPatientTreatmentClinicAcceptionFormViewModel.IsPhysicalStateClinicReadOnly;
        super.PreScript();
        if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.HospitalInPatientDate == null)// QuarantineInPatientDate Serverdan gelmiyorsa Clindeda ClinicInpatientDatedeğiştikçe değişsin diye
        {
            this.isQuarantineInPatientDateExists = false;
            this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.HospitalInPatientDate = this._InPatientTreatmentClinicApplication.ClinicInpatientDate;
        }
        else
            this.isQuarantineInPatientDateExists = true;

        this.ResponsibleDoctor.ListFilterExpression = " USERRESOURCES.RESOURCE = '" + this._InPatientTreatmentClinicApplication.MasterResource.ObjectID.toString() + "'";

        //if (this.Owner is InPatientAdmissionBaseForm)
        //    SetFormReadOnly();

        //if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.EstimatedInpatientDate != null && this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.EstimatedDischargeDate != null) {
        //    this.EstimatedInpatientDateCount.Text = DateUtil.totalDays(this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.EstimatedInpatientDate, this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.EstimatedDischargeDate).toString();
        //}


        if (this._InPatientTreatmentClinicApplication.IsDailyOperation) {
            this.saveAndCloseCommandVisible = true;
            this.isSaveAndCancelCommandVisible = true;

        }
        if (this._InPatientTreatmentClinicApplication.CurrentStateDefID == InPatientTreatmentClinicApplication.InPatientTreatmentClinicApplicationStates.Procedure) {
            //servera taşındı
            this.DropStateButton(InPatientTreatmentClinicApplication.InPatientTreatmentClinicApplicationStates.Transferred);
            this.DropStateButton(InPatientTreatmentClinicApplication.InPatientTreatmentClinicApplicationStates.Discharged);
            this.isSaveAndCancelCommandVisible = true;

            this.klinikYatis.toggleReadOnly(true, false);
            //this.ClinicInPatientDate.ReadOnly = true;
            //this.ClinicInPatientDate.Enabled = false;
        }
        else {
            this.DropStateButton(InPatientTreatmentClinicApplication.InPatientTreatmentClinicApplicationStates.Cancelled);
            this.isSaveAndCancelCommandVisible = false; // Acceptstateinde Kaydet Vazgeç butonları gözükmez
            if (this._InPatientTreatmentClinicApplication.FromInPatientTrtmentClinicApp != null) //transfer ile başlatıldı ise Klinik Yatış Tarihi değiştirilemez
                this.klinikYatis.toggleReadOnly(true, false);
            else {
                //this.ClinicInPatientDate.Max = this.inPatientTreatmentClinicAcceptionFormViewModel.RecTime;
                //this.ClinicInPatientDate.Min = this._InPatientTreatmentClinicApplication.Episode.OpeningDate;
                this.klinikYatis.SetMinMax(this.inPatientTreatmentClinicAcceptionFormViewModel.EpisodeOpeningDate, this.inPatientTreatmentClinicAcceptionFormViewModel.RecTime);
            }
        }

        if (this._InPatientTreatmentClinicApplication.CurrentStateDefID == InPatientTreatmentClinicApplication.InPatientTreatmentClinicApplicationStates.Acception || this._InPatientTreatmentClinicApplication.CurrentStateDefID == InPatientTreatmentClinicApplication.InPatientTreatmentClinicApplicationStates.PreAcception) {
            this._isTreatmentClinicAcception = true;
        }

        // this.SetNumberOfEmptyBedsByPhysicalStateClinic();

        this.TurnReserveToUsed.Visible = this.inPatientTreatmentClinicAcceptionFormViewModel.ShowTurnReserveToUsed;

        //            // Medula Takip işlemi için medula Provision nesnesi initialize ediliyor.
        //
        //            if(this._InPatientTreatmentClinicApplication.Episode.IsMedulaEpisode() == true){
        //                if(this._InPatientTreatmentClinicApplication.MedulaProvision == null){
        //                    MedulaProvision _medulaProvision= new MedulaProvision(this._InPatientTreatmentClinicApplication.ObjectContext);
        //                    this._InPatientTreatmentClinicApplication.setMedulaProvisionInitalProperties(_medulaProvision);
        //                    this._InPatientTreatmentClinicApplication.MedulaProvision= _medulaProvision;
        //                }
        //            }

        //  Bu alanlar ekrandan kaldırıldı
        //this.GivenStatusText = this.inPatientTreatmentClinicAcceptionFormViewModel.GivenMsg;
        //this.TakenStatusText = this.inPatientTreatmentClinicAcceptionFormViewModel.TakenMsg;
        //this.GivenStatus.Text = this.inPatientTreatmentClinicAcceptionFormViewModel.GivenMsg;
        //this.TakenStatus.Text = this.inPatientTreatmentClinicAcceptionFormViewModel.TakenMsg;
        //if (this.NoCupboard.Value === true)
        //    this.Cupboard.ReadOnly = true;
        //else this.Cupboard.ReadOnly = false;

        this.getComponentInfo();
        this.getDepositInfo();

        if (this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.InpatientAcceptionType != null) {//yatış bekliyor durumunda ise iptal fonksiyonu çalışmalı
            this._buttonCaption = "Yatış Bekleme İptal";
        }
        else
            this._buttonCaption = "Yatış Bekliyor";

        if (this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.LongInpatientReason != null) {
            this.showLongInpatientReason = true;
        }
        if (this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.ShotInpatientReason != null) {
            this.showShortInpatientReason = true;
        }
    }


    protected showGivenInpatientAppointmentForm(): Promise<ModalActionResult> {
        return new Promise((resolve, reject) => {
            let data: GivenInpatientAppointmentFormViewModel = new GivenInpatientAppointmentFormViewModel();

            let componentInfo = new DynamicComponentInfo();
            componentInfo.ComponentName = "GivenInpatientAppointmentForm";
            componentInfo.ModuleName = "RandevuModule";
            componentInfo.ModulePath = "/Modules/Tibbi_Surec/Randevu_Modulu/RandevuModule";
            componentInfo.InputParam = new DynamicComponentInputParam(data, new ActiveIDsModel(this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.ObjectID, null, null));

            let modalInfo: ModalInfo = new ModalInfo();
            modalInfo.Title = "Hasta Randevuları";
            modalInfo.Width = 900;
            modalInfo.Height = 350;
            modalInfo.IsShowCloseButton = false;

            let result = ServiceLocator.ModalService().create(componentInfo, modalInfo);
            result.then(inner => {
                resolve(inner);
            }).catch(err => {
                reject(err);
            });
        });
    }

    //protected async SetFirstEmptyBedByPhysicalStateClinic(): Promise<void> {
    //    let setValue: boolean = false;
    //    if (this.PhysicalStateClinic.SelectedValue !== null) {
    //        if (this.RoomGroup.SelectedValue === null) {
    //            setValue = true;
    //        }
    //        else if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.RoomGroup.Ward !== this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.PhysicalStateClinic) {
    //            setValue = true;
    //        }
    //        if (setValue) {
    //            this.RoomGroup.SelectedValue = null;
    //            this.Room.SelectedValue = null;
    //            this.Bed.SelectedObject = (await CommonService.GetFirstfEmptyBedV2(<Guid>this.PhysicalStateClinic.SelectedObjectID));
    //        }
    //    }
    //}
    //protected async SetFirstEmptyBedByRoom(): Promise<void> {
    //    let setValue: boolean = false;
    //    if (this.Room.SelectedValue !== null) {
    //        if (this.Bed.SelectedValue === null)
    //            this.Bed.SelectedObject = (await CommonService.GetFirstfEmptyBedV4(<Guid>this.PhysicalStateClinic.SelectedObjectID, <Guid>this.RoomGroup.SelectedObjectID, <Guid>this.Room.SelectedObjectID));
    //        else if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed.Room !== this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Room)
    //            this.Bed.SelectedObject = (await CommonService.GetFirstfEmptyBedV4(<Guid>this.PhysicalStateClinic.SelectedObjectID, <Guid>this.RoomGroup.SelectedObjectID, <Guid>this.Room.SelectedObjectID));
    //    }
    //}
    //protected async SetFirstEmptyBedByRoomGroup(): Promise<void> {
    //    let setValue: boolean = false;
    //    if (this.RoomGroup.SelectedValue !== null) {
    //        if (this.Room.SelectedValue === null) {
    //            setValue = true;
    //        }
    //        else if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Room.RoomGroup !== this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.RoomGroup) {
    //            setValue = true;
    //        }
    //        if (setValue) {
    //            this.Room.SelectedValue = null;
    //            this.Bed.SelectedObject = (await CommonService.GetFirstfEmptyBedV3(<Guid>this.PhysicalStateClinic.SelectedObjectID, <Guid>this.RoomGroup.SelectedObjectID));
    //        }
    //    }
    //}
    //protected async SetNumberOfEmptyBedsByPhysicalStateClinic(): Promise<void> {
    //    if (this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.PhysicalStateClinic === null) {
    //        this.NumberOfEmptyBeds.Text = '';
    //    }
    //    else {
    //        this.NumberOfEmptyBeds.Text = Convert.toString((await CommonService.GetNumberOfEmptyBeds(<Guid>this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.PhysicalStateClinic.ObjectID)));
    //    }
    //}
    setBedEmpty() {
        this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.RoomGroup = null;
        this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Room = null;
        this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed = null;
    }

    setSelectedBed(selectedBedViewModel: SelectedBedViewModel) {
        this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.PhysicalStateClinic = selectedBedViewModel.PhysicalStateClinic;
        this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.RoomGroup = selectedBedViewModel.RoomGroup;
        this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Room = selectedBedViewModel.Room;
        this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed = selectedBedViewModel.Bed;


    }


    private AddHelpMenu() {
        let patientDocumentUpload = new DynamicSidebarMenuItem();
        patientDocumentUpload.key = 'patientDocumentUpload';
        patientDocumentUpload.icon = 'ai ai-hasta-dokuman-ekle';
        patientDocumentUpload.label = i18n("M15178", "Hasta Dokümanı Ekle");
        patientDocumentUpload.componentInstance = this.helpMenuService;
        patientDocumentUpload.clickFunction = this.helpMenuService.patientDocumentUpload;
        patientDocumentUpload.parameterFunctionInstance = this;
        patientDocumentUpload.getParamsFunction = this.getClickFunctionParams;
        patientDocumentUpload.ParentInstance = this;
        this.sideBarMenuService.addMenu('YardimciMenu', patientDocumentUpload);
        

        let printInpatientTreatmentBarcode = new DynamicSidebarMenuItem();
        printInpatientTreatmentBarcode.key = 'printInpatientTreatmentBarcode';
        printInpatientTreatmentBarcode.icon = 'ai ai-barkod-bas';
        printInpatientTreatmentBarcode.label = 'Yatan Hasta Barkodu Bas';
        printInpatientTreatmentBarcode.componentInstance = this.helpMenuService;
        printInpatientTreatmentBarcode.clickFunction = this.helpMenuService.printInpatientTreatmentBarcode;
        printInpatientTreatmentBarcode.parameterFunctionInstance = this;
        printInpatientTreatmentBarcode.ParentInstance = this;
        printInpatientTreatmentBarcode.getParamsFunction = this.getClickFunctionParamsForInpatient;
        this.sideBarMenuService.addMenu('Barkod', printInpatientTreatmentBarcode);


        let printInpatientBarcode = new DynamicSidebarMenuItem();
        printInpatientBarcode.key = 'printInpatientBarcode';
        printInpatientBarcode.icon = 'ai ai-barkod-bas';
        printInpatientBarcode.label = 'Hasta Bilekliği Bas';
        printInpatientBarcode.componentInstance = this.helpMenuService;
        printInpatientBarcode.clickFunction = this.helpMenuService.printInPatientWristBarcode; //Hemşire bilekliği için yatan hasta barkodu basılıyormuş.Bileklik yapıldıktan sonra eklenecek
        printInpatientBarcode.parameterFunctionInstance = this;
        printInpatientBarcode.ParentInstance = this;
        printInpatientBarcode.getParamsFunction = this.getClickFunctionParams;
        this.sideBarMenuService.addMenu('Barkod', printInpatientBarcode);      

        if (this.inPatientTreatmentClinicAcceptionFormViewModel.HasInpatientAppShowRole == true) {
            let inpatientApp = new DynamicSidebarMenuItem();
            inpatientApp.key = 'openInpatientAppointment';
            inpatientApp.icon = 'fa fa-file-text-o';
            inpatientApp.label = 'Yatan Hasta Randevuları';
            inpatientApp.componentInstance = this.helpMenuService;
            inpatientApp.clickFunction = this.helpMenuService.openInpatientAppointment;
            inpatientApp.parameterFunctionInstance = this;
            inpatientApp.getParamsFunction = this.getClickFunctionParams;
            inpatientApp.ParentInstance = this;
            this.sideBarMenuService.addMenu('YardimciMenu', inpatientApp);
        }
    }

    public RemoveMenuFromHelpMenu(): void {

        this.sideBarMenuService.removeMenu('printInpatientTreatmentBarcode');
        this.sideBarMenuService.removeMenu('patientDocumentUpload');
        this.sideBarMenuService.removeMenu('printInpatientBarcode');
        this.sideBarMenuService.removeMenu('openInpatientAppointment');
    }

    public getClickFunctionParamsForInpatient(): ClickFunctionParams {
        let clickFunctionParams: ClickFunctionParams;
        if (typeof this._EpisodeAction.Episode === "string") {
            clickFunctionParams = new ClickFunctionParams(this, new ActiveIDsModel(this._EpisodeAction.ObjectID, this._EpisodeAction.Episode, null));
        } else {
            clickFunctionParams = new ClickFunctionParams(this, new ActiveIDsModel(this._EpisodeAction.ObjectID, this._EpisodeAction.Episode.ObjectID, this._EpisodeAction.Episode.Patient.ObjectID));
        }
        return clickFunctionParams;
    }

    public printInpatientWristBarcode() {
        let that = this;
        that.httpService.get<InpatientWristBarcodeInfo>("/api/InPatientTreatmentClinicApplicationService/GetInpatientWristBarcodeInfoByEpisodeActionId?episodeActionId=" + this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.ObjectID.toString())
            .then(response => {
                that.barcodePrintService.printAllBarcode(response, "generateInPatientWristBarcode", "printInPatientWristBarcode");
            })
            .catch(error => {
                that.messageService.showError(error);

            });
    }


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new InPatientTreatmentClinicApplication();
        this.inPatientTreatmentClinicAcceptionFormViewModel = new InPatientTreatmentClinicAcceptionFormViewModel();
        this._ViewModel = this.inPatientTreatmentClinicAcceptionFormViewModel;
        this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication = this._TTObject as InPatientTreatmentClinicApplication;
        this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.BaseInpatientAdmission = new BaseInpatientAdmission();
        this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.BaseInpatientAdmission.ProcedureDoctor = new ResUser();
        this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Room = new ResRoom();
        this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.BaseInpatientAdmission.PhysicalStateClinic = new ResWard();
        this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.BaseInpatientAdmission.RoomGroup = new ResRoomGroup();
        this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed = new ResBed();
        this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.ProcedureDoctor = new ResUser();
        this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.ResponsibleNurse = new ResUser();
        this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.MasterResource = new ResSection();
    }

    protected loadViewModel() {
        let that = this;

        that.inPatientTreatmentClinicAcceptionFormViewModel = this._ViewModel as InPatientTreatmentClinicAcceptionFormViewModel;
        that._TTObject = this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication;
        if (this.inPatientTreatmentClinicAcceptionFormViewModel == null)
            this.inPatientTreatmentClinicAcceptionFormViewModel = new InPatientTreatmentClinicAcceptionFormViewModel();
        if (this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication == null)
            this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication = new InPatientTreatmentClinicApplication();
        let baseInpatientAdmissionObjectID = that.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication["BaseInpatientAdmission"];
        if (baseInpatientAdmissionObjectID != null && (typeof baseInpatientAdmissionObjectID === 'string')) {
            let baseInpatientAdmission = that.inPatientTreatmentClinicAcceptionFormViewModel.BaseInpatientAdmissions.find(o => o.ObjectID.toString() === baseInpatientAdmissionObjectID.toString());
            if (baseInpatientAdmission) {
                that.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.BaseInpatientAdmission = baseInpatientAdmission;
            }
            if (baseInpatientAdmission != null) {
                let procedureDoctorObjectID = baseInpatientAdmission["ProcedureDoctor"];
                if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
                    let procedureDoctor = that.inPatientTreatmentClinicAcceptionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
                    if (procedureDoctor) {
                        baseInpatientAdmission.ProcedureDoctor = procedureDoctor;
                    }
                }
            }
            if (baseInpatientAdmission != null) {
                let roomObjectID = baseInpatientAdmission["Room"];
                if (roomObjectID != null && (typeof roomObjectID === 'string')) {
                    let room = that.inPatientTreatmentClinicAcceptionFormViewModel.ResRooms.find(o => o.ObjectID.toString() === roomObjectID.toString());
                    if (room) {
                        baseInpatientAdmission.Room = room;
                    }
                }
            }
            if (baseInpatientAdmission != null) {
                let physicalStateClinicObjectID = baseInpatientAdmission["PhysicalStateClinic"];
                if (physicalStateClinicObjectID != null && (typeof physicalStateClinicObjectID === 'string')) {
                    let physicalStateClinic = that.inPatientTreatmentClinicAcceptionFormViewModel.ResWards.find(o => o.ObjectID.toString() === physicalStateClinicObjectID.toString());
                    if (physicalStateClinic) {
                        baseInpatientAdmission.PhysicalStateClinic = physicalStateClinic;
                    }
                }
            }
            if (baseInpatientAdmission != null) {
                let roomGroupObjectID = baseInpatientAdmission["RoomGroup"];
                if (roomGroupObjectID != null && (typeof roomGroupObjectID === 'string')) {
                    let roomGroup = that.inPatientTreatmentClinicAcceptionFormViewModel.ResRoomGroups.find(o => o.ObjectID.toString() === roomGroupObjectID.toString());
                    if (roomGroup) {
                        baseInpatientAdmission.RoomGroup = roomGroup;
                    }
                }
            }
            if (baseInpatientAdmission != null) {
                let bedObjectID = baseInpatientAdmission["Bed"];
                if (bedObjectID != null && (typeof bedObjectID === 'string')) {
                    let bed = that.inPatientTreatmentClinicAcceptionFormViewModel.ResBeds.find(o => o.ObjectID.toString() === bedObjectID.toString());
                    if (bed) {
                        baseInpatientAdmission.Bed = bed;
                    }
                }
            }
        }
        let procedureDoctorObjectID = that.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.inPatientTreatmentClinicAcceptionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.ProcedureDoctor = procedureDoctor;
            }
        }
        let responsibleNurseObjectID = that.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication["ResponsibleNurse"];
        if (responsibleNurseObjectID != null && (typeof responsibleNurseObjectID === 'string')) {
            let responsibleNurse = that.inPatientTreatmentClinicAcceptionFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleNurseObjectID.toString());
            if (responsibleNurse) {
                that.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.ResponsibleNurse = responsibleNurse;
            }
        }
        let masterResourceObjectID = that.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication["MasterResource"];
        if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
            let masterResource = that.inPatientTreatmentClinicAcceptionFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
            if (masterResource) {
                that.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.MasterResource = masterResource;
            }
        }
        /*let episodeObjectID = that.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.inPatientTreatmentClinicAcceptionFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
             if (episode) {
                that.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.Episode = episode;
            }
        }*/
    }


    async ngOnInit() {
        let that = this;
        await this.load(InPatientTreatmentClinicAcceptionFormViewModel);

        if (this._InPatientTreatmentClinicApplication.IsDailyOperation) {
            this.EstimatedDischargeDate.ReadOnly = false;
            this.EstimatedInpatientDate.ReadOnly = false;
            this.MasterResource.ReadOnly = false;
            this.ClinicInPatientDate.ReadOnly = false;
            this.ResponsibleDoctor.ReadOnly = false;
            this.HospitalInpatientDate.ReadOnly = false;
            this.ResponsibleNurse.ReadOnly = false;
            this.inPatientTreatmentClinicAcceptionFormViewModel.ReadOnly = false;
            this.saveAndCloseCommandVisible = true;
            this.isSaveAndCancelCommandVisible = true;
            this.ttlabel1.ReadOnly = false;
            this.ttlabel2.ReadOnly = false;
            this.labelBed.ReadOnly = false;
        }

        this.AddHelpMenu();

    }

    public ngOnDestroy(): void {
        this.RemoveMenuFromHelpMenu();

    }

    public createDepositReport() {
        this.helpMenuService.printHastaEmanetRaporuReport(new Guid(this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.Episode.toString()), this.getClickFunctionParams());
    }

    public onBedChanged(event): void {
        if (event != null) {
            if (this._InPatientTreatmentClinicApplication != null &&
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission != null && this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed != event) {
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Bed = event;
            }
        }
    }

    public onClinicInpatientDateChanged(event): void {
        if (event != null) {
            if (this._InPatientTreatmentClinicApplication != null && this._InPatientTreatmentClinicApplication.ClinicInpatientDate != event) {
                this._InPatientTreatmentClinicApplication.ClinicInpatientDate = event;
                let that = this;
                setTimeout(function () {

                    if (!that.isQuarantineInPatientDateExists) // serverdan gelmedi ise ClinicInpatient date değiştikçe o da değişir
                    {
                        that._InPatientTreatmentClinicApplication.BaseInpatientAdmission.HospitalInPatientDate = that._InPatientTreatmentClinicApplication.ClinicInpatientDate;
                        if (that._InPatientTreatmentClinicApplication.BaseInpatientAdmission.HospitalInPatientDate != null && that._InPatientTreatmentClinicApplication.BaseInpatientAdmission.EstimatedInpatientDateCount != null) {
                            let estimatedInpatientDateCount: number = that._InPatientTreatmentClinicApplication.BaseInpatientAdmission.EstimatedInpatientDateCount;
                            that._InPatientTreatmentClinicApplication.BaseInpatientAdmission.EstimatedDischargeDate = that._InPatientTreatmentClinicApplication.BaseInpatientAdmission.HospitalInPatientDate.AddDays(estimatedInpatientDateCount);
                        }
                    }
                }, 500);


            }
        }
    }

    public onHospitalInpatientDateChanged(event): void {
        if (event != null) {
            if (this._InPatientTreatmentClinicApplication != null && this._InPatientTreatmentClinicApplication.BaseInpatientAdmission != null && this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.HospitalInPatientDate != event) {
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.HospitalInPatientDate = event;
            }
        }
    }
    public onEstimatedDischargeDateChanged(event): void {
        if (event != null) {
            if (this._InPatientTreatmentClinicApplication != null &&
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission != null && this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.EstimatedDischargeDate != event) {
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.EstimatedDischargeDate = event;
                let that = this;
                setTimeout(function () {
                    let inPatientDate = that._InPatientTreatmentClinicApplication.BaseInpatientAdmission.HospitalInPatientDate;
                    if (inPatientDate != null && that._InPatientTreatmentClinicApplication.BaseInpatientAdmission.EstimatedDischargeDate != null) {
                        that._InPatientTreatmentClinicApplication.BaseInpatientAdmission.EstimatedInpatientDateCount = DateUtil.totalDays(inPatientDate, that._InPatientTreatmentClinicApplication.BaseInpatientAdmission.EstimatedDischargeDate);
                    }
                }, 500);

            }
        }
    }

    public onEstimatedInpatientDateCountChanged(event): void {
        if (event != null) {
            if (this._InPatientTreatmentClinicApplication != null && this._InPatientTreatmentClinicApplication.BaseInpatientAdmission != null && this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.EstimatedInpatientDateCount != event) {
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.EstimatedInpatientDateCount = event;
                //event içinde yine veriyi değiştirdiğimiz için saçmalayabiliyor, o yüzden geçiktirdik
                let that = this;
                setTimeout(function () {
                    if (that._InPatientTreatmentClinicApplication.BaseInpatientAdmission.HospitalInPatientDate != null)
                        that._InPatientTreatmentClinicApplication.BaseInpatientAdmission.EstimatedDischargeDate = that._InPatientTreatmentClinicApplication.BaseInpatientAdmission.HospitalInPatientDate.AddDays(parseInt(event));
                }, 500);

            }
        }
    }

    public onEstimatedInpatientDateChanged(event): void {
        if (event != null) {
            if (this._InPatientTreatmentClinicApplication != null && this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.EstimatedInpatientDate != event) {
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.EstimatedInpatientDate = event;

            }
        }
    }

    public onHasAirborneContactIsolationBaseInpatientAdmissionChanged(event): void {
        if (event != null) {
            if (this._InPatientTreatmentClinicApplication != null &&
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission != null && this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.HasAirborneContactIsolation != event) {
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.HasAirborneContactIsolation = event;
            }
        }
    }

    public onHasContactIsolationBaseInpatientAdmissionChanged(event): void {
        if (event != null) {
            if (this._InPatientTreatmentClinicApplication != null &&
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission != null && this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.HasContactIsolation != event) {
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.HasContactIsolation = event;
            }
        }
    }

    public onHasDropletIsolationBaseInpatientAdmissionChanged(event): void {
        if (event != null) {
            if (this._InPatientTreatmentClinicApplication != null &&
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission != null && this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.HasDropletIsolation != event) {
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.HasDropletIsolation = event;
            }
        }
    }


    public onHasFallingRiskBaseInpatientAdmissionChanged(event): void {
        if (event != null) {
            if (this._InPatientTreatmentClinicApplication != null &&
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission != null && this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.HasFallingRisk != event) {
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.HasFallingRisk = event;
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.RiskWarningLastSeenDate = null;
            }
        }
    }

    public onHasTightContactIsolationBaseInpatientAdmissionChanged(event): void {
        if (event != null) {
            if (this._InPatientTreatmentClinicApplication != null &&
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission != null && this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.HasTightContactIsolation != event) {
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.HasTightContactIsolation = event;
            }
        }
    }



    public onInpatientProtocolNoChanged(event): void {
        if (event != null) {
            if (this._InPatientTreatmentClinicApplication != null && this._InPatientTreatmentClinicApplication.ProtocolNo != event) {
                this._InPatientTreatmentClinicApplication.ProtocolNo = event;
            }
        }
    }

    public onLongInpatientReasonChanged(event): void {
        if (this._InPatientTreatmentClinicApplication != null && this._InPatientTreatmentClinicApplication.LongInpatientReason != event) {
            this._InPatientTreatmentClinicApplication.LongInpatientReason = event;
        }
    }

    public onMasterResourceChanged(event): void {
        if (event != null) {
            if (this._InPatientTreatmentClinicApplication != null && this._InPatientTreatmentClinicApplication.MasterResource != event) {
                this._InPatientTreatmentClinicApplication.MasterResource = event;
            }
        }
        this.MasterResource_SelectedObjectChanged();
    }

    public onNeedCompanionChanged(event): void {
        if (event != null) {
            if (this._InPatientTreatmentClinicApplication != null &&
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission != null && this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.NeedCompanion != event) {
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.NeedCompanion = event;
            }
        }
    }

    //public onPhysicalStateClinicChanged(event): void {
    //    if (event != null) {
    //        if (this._InPatientTreatmentClinicApplication != null &&
    //            this._InPatientTreatmentClinicApplication.BaseInpatientAdmission != null && this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.PhysicalStateClinic != event) {
    //            this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.PhysicalStateClinic = event;
    //        }
    //    }
    //    this.PhysicalStateClinic_SelectedObjectChanged();
    //}

    public onRequestDateChanged(event): void {
        if (event != null) {
            if (this._InPatientTreatmentClinicApplication != null &&
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission != null && this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.RequestDate != event) {
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.RequestDate = event;
            }
        }
    }


    public async onResponsibleDoctorChanged(event) {
        if (event != null) {
            if (this._InPatientTreatmentClinicApplication != null && this._InPatientTreatmentClinicApplication.ProcedureDoctor != event) {
                this._InPatientTreatmentClinicApplication.ProcedureDoctor = event;
            }

            let a = await CommonService.PersonelIzinKontrol(this._InPatientTreatmentClinicApplication.ProcedureDoctor.ObjectID, this.inPatientTreatmentClinicAcceptionFormViewModel._InPatientTreatmentClinicApplication.BaseInpatientAdmission.HospitalInPatientDate);
            if (a) {
                this.messageService.showInfo(this._InPatientTreatmentClinicApplication.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                setTimeout(() => {
                    this._InPatientTreatmentClinicApplication.ProcedureDoctor = null;
                }, 500);
            }
        }
    }

    public onResponsibleNurseChanged(event): void {
        if (event != null) {
            if (this._InPatientTreatmentClinicApplication != null && this._InPatientTreatmentClinicApplication.ResponsibleNurse != event) {
                this._InPatientTreatmentClinicApplication.ResponsibleNurse = event;
            }
        }
    }

    //public onRoomChanged(event): void {
    //    if (event != null) {
    //        if (this._InPatientTreatmentClinicApplication != null &&
    //            this._InPatientTreatmentClinicApplication.BaseInpatientAdmission != null && this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Room != event) {
    //            this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.Room = event;
    //        }
    //    }
    //    this.Room_SelectedObjectChanged();
    //}

    //public onRoomGroupChanged(event): void {
    //    if (event != null) {
    //        if (this._InPatientTreatmentClinicApplication != null &&
    //            this._InPatientTreatmentClinicApplication.BaseInpatientAdmission != null && this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.RoomGroup != event) {
    //            this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.RoomGroup = event;
    //        }
    //    }
    //    this.RoomGroup_SelectedObjectChanged();
    //}

    public onRequestDoctorChanged(event): void {
        if (event != null) {
            if (this._InPatientTreatmentClinicApplication != null &&
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission != null && this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.ProcedureDoctor != event) {
                this._InPatientTreatmentClinicApplication.BaseInpatientAdmission.ProcedureDoctor = event;
            }
        }
    }

    public onShotInpatientReasonChanged(event): void {
        if (this._InPatientTreatmentClinicApplication != null && this._InPatientTreatmentClinicApplication.ShotInpatientReason != event) {
            this._InPatientTreatmentClinicApplication.ShotInpatientReason = event;
        }
    }

    public async setStateToTransition(event) {

        if (event.transDef.ToStateDefID !== null) {
            if (event.transDef.ToStateDefID.valueOf() == InPatientTreatmentClinicApplication.InPatientTreatmentClinicApplicationStates.Cancelled.id)
                await this.setReasonOfCancel(i18n("M16561", "İptal Açıklaması :"));
        }

        this.loadingVisible = true;
        await super.setStateToTransition(event);
        this.loadingVisible = false;
    }



    protected redirectProperties(): void {
        redirectProperty(this.RequestDate, "Value", this.__ttObject, "BaseInpatientAdmission.RequestDate");
        redirectProperty(this.InpatientProtocolNo, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.HospitalInpatientDate, "Value", this.__ttObject, "BaseInpatientAdmission.HospitalInPatientDate");
        redirectProperty(this.ClinicInPatientDate, "Value", this.__ttObject, "ClinicInpatientDate");
        redirectProperty(this.EstimatedInpatientDate, "Value", this.__ttObject, "BaseInpatientAdmission.EstimatedInpatientDate");
        redirectProperty(this.EstimatedDischargeDate, "Value", this.__ttObject, "BaseInpatientAdmission.EstimatedDischargeDate");
        redirectProperty(this.EstimatedInpatientDateCount, "Value", this.__ttObject, "BaseInpatientAdmission.EstimatedInpatientDateCount");
        redirectProperty(this.HasFallingRiskBaseInpatientAdmission, "Value", this.__ttObject, "BaseInpatientAdmission.HasFallingRisk");
        redirectProperty(this.HasDropletIsolationBaseInpatientAdmission, "Value", this.__ttObject, "BaseInpatientAdmission.HasDropletIsolation");
        redirectProperty(this.HasAirborneContactIsolationBaseInpatientAdmission, "Value", this.__ttObject, "BaseInpatientAdmission.HasAirborneContactIsolation");
        redirectProperty(this.HasContactIsolationBaseInpatientAdmission, "Value", this.__ttObject, "BaseInpatientAdmission.HasContactIsolation");
        redirectProperty(this.HasTightContactIsolationBaseInpatientAdmission, "Value", this.__ttObject, "BaseInpatientAdmission.HasTightContactIsolation");
        redirectProperty(this.NeedCompanion, "Value", this.__ttObject, "BaseInpatientAdmission.NeedCompanion");
        redirectProperty(this.LongInpatientReason, "Text", this.__ttObject, "LongInpatientReason");
        redirectProperty(this.ShotInpatientReason, "Text", this.__ttObject, "ShotInpatientReason");
    }

    public initFormControls(): void {
        this.ttpanel1 = new TTVisual.TTPanel();
        this.ttpanel1.AutoSize = true;
        this.ttpanel1.Name = "ttpanel1";
        this.ttpanel1.TabIndex = 11;

        this.labelShotInpatientReason = new TTVisual.TTLabel();
        this.labelShotInpatientReason.Text = "Kısa Yatış Nedeni";
        this.labelShotInpatientReason.Name = "labelShotInpatientReason";
        this.labelShotInpatientReason.TabIndex = 13;

        this.labelLongInpatientReason = new TTVisual.TTLabel();
        this.labelLongInpatientReason.Text = "Uzun Yatış Nedeni";
        this.labelLongInpatientReason.Name = "labelLongInpatientReason";
        this.labelLongInpatientReason.TabIndex = 13;

        this.ShotInpatientReason = new TTVisual.TTTextBox();
        this.ShotInpatientReason.Multiline = true;
        this.ShotInpatientReason.Name = "ShotInpatientReason";
        this.ShotInpatientReason.TabIndex = 12;

        this.LongInpatientReason = new TTVisual.TTTextBox();
        this.ShotInpatientReason.Multiline = true;
        this.LongInpatientReason.Name = "LongInpatientReason";
        this.LongInpatientReason.TabIndex = 12;

        this.HasAirborneContactIsolationBaseInpatientAdmission = new TTVisual.TTCheckBox();
        this.HasAirborneContactIsolationBaseInpatientAdmission.Value = false;
        this.HasAirborneContactIsolationBaseInpatientAdmission.Title = i18n("M22030", "Solunum İzolasyonu ");
        this.HasAirborneContactIsolationBaseInpatientAdmission.Name = "HasAirborneContactIsolationBaseInpatientAdmission";
        this.HasAirborneContactIsolationBaseInpatientAdmission.TabIndex = 17;

        this.NeedCompanion = new TTVisual.TTCheckBox();
        this.NeedCompanion.Value = false;
        this.NeedCompanion.Title = i18n("M20986", "Refakat Gerektirir");
        this.NeedCompanion.Name = "NeedCompanion";
        this.NeedCompanion.TabIndex = 17477;

        this.tttextbox6 = new TTVisual.TTTextBox();
        this.tttextbox6.Name = "tttextbox6";
        this.tttextbox6.TabIndex = 212;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = i18n("M16596", "İsteği  Yapan Tabip");
        this.labelProcedureDoctor.BackColor = "#DCDCDC";
        this.labelProcedureDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProcedureDoctor.ForeColor = "#000000";
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 36;

        this.RequestDoctor = new TTVisual.TTObjectListBox();
        this.RequestDoctor.LinkedControlName = "MasterResource";
        this.RequestDoctor.ReadOnly = true;
        this.RequestDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.RequestDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RequestDoctor.Name = "RequestDoctor";
        this.RequestDoctor.TabIndex = 6;

        this.labelEstimatedInpatientDate = new TTVisual.TTLabel();
        this.labelEstimatedInpatientDate.Text = i18n("M22605", "Tahmini Yatış Tarihi");
        this.labelEstimatedInpatientDate.Name = "labelEstimatedInpatientDate";
        this.labelEstimatedInpatientDate.TabIndex = 14;

        this.EstimatedInpatientDate = new TTVisual.TTDateTimePicker();
        this.EstimatedInpatientDate.BackColor = "#F0F0F0";
        this.EstimatedInpatientDate.Format = DateTimePickerFormat.Short;
        this.EstimatedInpatientDate.Enabled = false;
        this.EstimatedInpatientDate.Name = "EstimatedInpatientDate";
        this.EstimatedInpatientDate.TabIndex = 13;

        this.HasContactIsolationBaseInpatientAdmission = new TTVisual.TTCheckBox();
        this.HasContactIsolationBaseInpatientAdmission.Value = false;
        this.HasContactIsolationBaseInpatientAdmission.Title = i18n("M23155", "Temas İzolasyonu  ");
        this.HasContactIsolationBaseInpatientAdmission.Name = "HasContactIsolationBaseInpatientAdmission";
        this.HasContactIsolationBaseInpatientAdmission.TabIndex = 16;

        this.labelEstimatedDischargeDate = new TTVisual.TTLabel();
        this.labelEstimatedDischargeDate.Text = i18n("M22600", "Tahmini Taburcu Tarihi");
        this.labelEstimatedDischargeDate.Name = "labelEstimatedDischargeDate";
        this.labelEstimatedDischargeDate.TabIndex = 14;

        this.HasDropletIsolationBaseInpatientAdmission = new TTVisual.TTCheckBox();
        this.HasDropletIsolationBaseInpatientAdmission.Value = false;
        this.HasDropletIsolationBaseInpatientAdmission.Title = i18n("M12487", "Damlacık İzolasyonu  ");
        this.HasDropletIsolationBaseInpatientAdmission.Name = "HasDropletIsolationBaseInpatientAdmission";
        this.HasDropletIsolationBaseInpatientAdmission.TabIndex = 15;

        this.ttlabel18 = new TTVisual.TTLabel();
        this.ttlabel18.Text = i18n("M22603", "Tahmini Yatacağı Gün");
        this.ttlabel18.Name = "ttlabel18";
        this.ttlabel18.TabIndex = 14;

        this.HasFallingRiskBaseInpatientAdmission = new TTVisual.TTCheckBox();
        this.HasFallingRiskBaseInpatientAdmission.Value = false;
        this.HasFallingRiskBaseInpatientAdmission.Title = i18n("M13392", "Düşme Riskli Hasta");
        this.HasFallingRiskBaseInpatientAdmission.Name = "HasFallingRiskBaseInpatientAdmission";
        this.HasFallingRiskBaseInpatientAdmission.TabIndex = 14;

        this.HasTightContactIsolationBaseInpatientAdmission = new TTVisual.TTCheckBox();
        this.HasTightContactIsolationBaseInpatientAdmission.Value = false;
        this.HasTightContactIsolationBaseInpatientAdmission.Title = i18n("M21800", "Sıkı Temas İzolasyonu  ");
        this.HasTightContactIsolationBaseInpatientAdmission.Name = "HasTightContactIsolationBaseInpatientAdmission";
        this.HasTightContactIsolationBaseInpatientAdmission.TabIndex = 13;

        this.EstimatedDischargeDate = new TTVisual.TTDateTimePicker();
        this.EstimatedDischargeDate.Format = DateTimePickerFormat.Short;
        this.EstimatedDischargeDate.Name = "EstimatedDischargeDate";
        this.EstimatedDischargeDate.TabIndex = 13;

        this.EstimatedInpatientDate = new TTVisual.TTDateTimePicker();
        this.EstimatedInpatientDate.Format = DateTimePickerFormat.Short;
        this.EstimatedInpatientDate.Name = "EstimatedInpatientDate";
        this.EstimatedInpatientDate.TabIndex = 13;
        this.EstimatedInpatientDate.Enabled = false;

        this.EstimatedInpatientDateCount = new TTVisual.TTTextBox();
        this.EstimatedInpatientDateCount.Name = "EstimatedInpatientDateCount";
        this.EstimatedInpatientDateCount.TabIndex = 212;
        this.EstimatedInpatientDateCount.InputFormat = InputFormat.Normal; // Daha sonra Numerice çevrilmeli

        this.NumberOfEmptyBeds = new TTVisual.TTTextBox();
        this.NumberOfEmptyBeds.BackColor = "#F0F0F0";
        this.NumberOfEmptyBeds.ReadOnly = true;
        this.NumberOfEmptyBeds.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.NumberOfEmptyBeds.Name = "NumberOfEmptyBeds";
        this.NumberOfEmptyBeds.TabIndex = 14;

        this.ResponsibleDoctor = new TTVisual.TTObjectListBox();
        this.ResponsibleDoctor.LinkedControlName = "InpatientMasterResource";
        this.ResponsibleDoctor.LinkedRelationPath = "USERRESOURCES.RESOURCE";
        this.ResponsibleDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.ResponsibleDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ResponsibleDoctor.Name = "ProcedureDoctor";
        this.ResponsibleDoctor.TabIndex = 10;
        this.ResponsibleDoctor.Required = true;
        this.ResponsibleDoctor.AutoCompleteDialogWidth = "20%"

        this.Room = new TTVisual.TTObjectListBox();
        this.Room.LinkedControlName = "RoomGroup";
        this.Room.ForceLinkedParentSelection = true;
        this.Room.ListDefName = "RoomListDefinition";
        this.Room.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Room.Name = "Room";
        this.Room.TabIndex = 15;

        this.LabelDateTime = new TTVisual.TTLabel();
        this.LabelDateTime.Text = i18n("M16650", "İstek Tarihi");
        this.LabelDateTime.BackColor = "#DCDCDC";
        this.LabelDateTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.LabelDateTime.ForeColor = "#000000";
        this.LabelDateTime.Name = "LabelDateTime";
        this.LabelDateTime.TabIndex = 211;

        this.ResponsibleNurse = new TTVisual.TTObjectListBox();
        this.ResponsibleNurse.ListDefName = "ClinicNurseListDefinition";
        this.ResponsibleNurse.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ResponsibleNurse.Name = "ResponsibleNurse";
        this.ResponsibleNurse.TabIndex = 11;
        this.ResponsibleNurse.AutoCompleteDialogWidth = "20%";

        this.TurnReserveToUsed = new TTVisual.TTButton();
        this.TurnReserveToUsed.BackColor = "#DCDCDC";
        this.TurnReserveToUsed.Text = i18n("M15532", "Hastayı Rezerve Yatağına Al");
        this.TurnReserveToUsed.Name = "TurnReserveToUsed";
        this.TurnReserveToUsed.TabIndex = 6;

        this.labelResponsibleNurse = new TTVisual.TTLabel();
        this.labelResponsibleNurse.Text = i18n("M22151", "Sorumlu Hemşire");
        this.labelResponsibleNurse.BackColor = "#DCDCDC";
        this.labelResponsibleNurse.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelResponsibleNurse.ForeColor = "#000000";
        this.labelResponsibleNurse.Name = "labelResponsibleNurse";
        this.labelResponsibleNurse.TabIndex = 206;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = i18n("M24455", "Yattığı  Klinik");
        this.ttlabel4.BackColor = "#DCDCDC";
        this.ttlabel4.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.ForeColor = "#000000";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 25;

        this.labelClinicInpatientDate = new TTVisual.TTLabel();
        this.labelClinicInpatientDate.Text = i18n("M17661", "Klinik Yatış Tarihi");
        this.labelClinicInpatientDate.BackColor = "#DCDCDC";
        this.labelClinicInpatientDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelClinicInpatientDate.ForeColor = "#000000";
        this.labelClinicInpatientDate.Name = "labelClinicInpatientDate";
        this.labelClinicInpatientDate.TabIndex = 195;

        this.PhysicalStateClinic = new TTVisual.TTObjectListBox();
        this.PhysicalStateClinic.ListDefName = "WardListDefinition";
        this.PhysicalStateClinic.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PhysicalStateClinic.Name = "PhysicalStateClinic";
        this.PhysicalStateClinic.TabIndex = 12;

        this.labelInpatientProtocolNo = new TTVisual.TTLabel();
        this.labelInpatientProtocolNo.Text = i18n("M17649", "Klinik Protokol No");
        this.labelInpatientProtocolNo.BackColor = "#DCDCDC";
        this.labelInpatientProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelInpatientProtocolNo.ForeColor = "#000000";
        this.labelInpatientProtocolNo.Name = "labelInpatientProtocolNo";
        this.labelInpatientProtocolNo.TabIndex = 185;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        this.RequestDate.BackColor = "#F0F0F0";
        this.RequestDate.CustomFormat = "";
        this.RequestDate.Format = DateTimePickerFormat.Long;
        this.RequestDate.Enabled = false;
        this.RequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RequestDate.Name = "RequestDate";
        this.RequestDate.TabIndex = 3;

        this.labelQuarantineProtocolNo = new TTVisual.TTLabel();
        this.labelQuarantineProtocolNo.Text = i18n("M23395", "Tıbbi Kayıt Protokol No");
        this.labelQuarantineProtocolNo.BackColor = "#DCDCDC";
        this.labelQuarantineProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelQuarantineProtocolNo.ForeColor = "#000000";
        this.labelQuarantineProtocolNo.Name = "labelQuarantineProtocolNo";
        this.labelQuarantineProtocolNo.TabIndex = 189;

        this.ClinicInPatientDate = new TTVisual.TTDateTimePicker();
        this.ClinicInPatientDate.BackColor = "#F0F0F0";
        this.ClinicInPatientDate.CustomFormat = "";
        this.ClinicInPatientDate.Format = DateTimePickerFormat.Short;
        this.ClinicInPatientDate.Enabled = false;
        this.ClinicInPatientDate.ReadOnly = false;
        this.ClinicInPatientDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ClinicInPatientDate.Name = "ClinicInPatientDate";
        this.ClinicInPatientDate.TabIndex = 8;

        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ReadOnly = true;
        this.MasterResource.ListDefName = "ClinicListDefinition";
        this.MasterResource.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MasterResource.Name = "MasterResource";
        this.MasterResource.TabIndex = 9;

        this.InpatientProtocolNo = new TTVisual.TTTextBox();
        this.InpatientProtocolNo.BackColor = "#F0F0F0";
        this.InpatientProtocolNo.ReadOnly = true;
        this.InpatientProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.InpatientProtocolNo.Name = "InpatientProtocolNo";
        this.InpatientProtocolNo.TabIndex = 5;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M19605", "Oda Grubu");
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 202;

        this.labelInpatientDepartment = new TTVisual.TTLabel();
        this.labelInpatientDepartment.Text = i18n("M15485", "Hastanın Tedavi Gördüğü Klinik");
        this.labelInpatientDepartment.BackColor = "#DCDCDC";
        this.labelInpatientDepartment.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelInpatientDepartment.ForeColor = "#000000";
        this.labelInpatientDepartment.Name = "labelInpatientDepartment";
        this.labelInpatientDepartment.TabIndex = 208;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = i18n("M19602", "Oda");
        this.ttlabel2.BackColor = "#DCDCDC";
        this.ttlabel2.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.ForeColor = "#000000";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 200;

        this.QuarantineProtocolNo = new TTVisual.TTTextBox();
        this.QuarantineProtocolNo.BackColor = "#F0F0F0";
        this.QuarantineProtocolNo.ReadOnly = true;
        this.QuarantineProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.QuarantineProtocolNo.Name = "QuarantineProtocolNo";
        this.QuarantineProtocolNo.TabIndex = 4;

        this.RoomGroup = new TTVisual.TTObjectListBox();
        this.RoomGroup.LinkedControlName = "PhysicalStateClinic";
        this.RoomGroup.ForceLinkedParentSelection = true;
        this.RoomGroup.ListDefName = "RoomGroupListDefinition";
        this.RoomGroup.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RoomGroup.Name = "RoomGroup";
        this.RoomGroup.TabIndex = 13;

        this.labelNumberOfEmptyBeds = new TTVisual.TTLabel();
        this.labelNumberOfEmptyBeds.Text = i18n("M11983", "Boş Yatak Sayısı");
        this.labelNumberOfEmptyBeds.BackColor = "#DCDCDC";
        this.labelNumberOfEmptyBeds.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelNumberOfEmptyBeds.ForeColor = "#000000";
        this.labelNumberOfEmptyBeds.Name = "labelNumberOfEmptyBeds";
        this.labelNumberOfEmptyBeds.TabIndex = 193;

        this.HospitalInpatientDate = new TTVisual.TTDateTimePicker();
        this.HospitalInpatientDate.BackColor = "#F0F0F0";
        this.HospitalInpatientDate.CustomFormat = "";
        this.HospitalInpatientDate.Format = DateTimePickerFormat.Short;
        this.HospitalInpatientDate.Enabled = false;
        this.HospitalInpatientDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.HospitalInpatientDate.Name = "HospitalInpatientDate";
        this.HospitalInpatientDate.TabIndex = 7;

        this.labelResponsibleDoctor = new TTVisual.TTLabel();
        this.labelResponsibleDoctor.Text = i18n("M22158", "Sorumlu Tabip");
        this.labelResponsibleDoctor.BackColor = "#DCDCDC";
        this.labelResponsibleDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelResponsibleDoctor.ForeColor = "#000000";
        this.labelResponsibleDoctor.Name = "labelResponsibleDoctor";
        this.labelResponsibleDoctor.TabIndex = 204;

        this.labelBed = new TTVisual.TTLabel();
        this.labelBed.Text = i18n("M24353", "Yatak");
        this.labelBed.BackColor = "#DCDCDC";
        this.labelBed.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelBed.ForeColor = "#000000";
        this.labelBed.Name = "labelBed";
        this.labelBed.TabIndex = 198;

        this.labelHospitalInpatientDate = new TTVisual.TTLabel();
        this.labelHospitalInpatientDate.Text = i18n("M15402", "XXXXXX Yatış Tarihi");
        this.labelHospitalInpatientDate.BackColor = "#DCDCDC";
        this.labelHospitalInpatientDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelHospitalInpatientDate.ForeColor = "#000000";
        this.labelHospitalInpatientDate.Name = "labelHospitalInpatientDate";
        this.labelHospitalInpatientDate.TabIndex = 187;

        this.Bed = new TTVisual.TTObjectListBox();
        this.Bed.Required = true;
        this.Bed.LinkedControlName = "Room";
        this.Bed.ForceLinkedParentSelection = true;
        this.Bed.ListFilterExpression = "UsedByBedProcedure is Null";
        this.Bed.ListDefName = "BedListDefinition";
        this.Bed.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Bed.Name = "Bed";
        this.Bed.TabIndex = 16;

        this.ttpanel1.Controls = [this.labelShotInpatientReason, this.labelLongInpatientReason, this.ShotInpatientReason, this.LongInpatientReason, this.HasAirborneContactIsolationBaseInpatientAdmission, this.NeedCompanion, this.tttextbox6, this.labelProcedureDoctor, this.RequestDoctor, this.labelEstimatedInpatientDate, this.EstimatedInpatientDate, this.HasContactIsolationBaseInpatientAdmission, this.labelEstimatedDischargeDate, this.HasDropletIsolationBaseInpatientAdmission, this.ttlabel18, this.HasFallingRiskBaseInpatientAdmission, this.HasTightContactIsolationBaseInpatientAdmission, this.EstimatedDischargeDate, this.NumberOfEmptyBeds, this.ResponsibleDoctor, this.Room, this.LabelDateTime, this.ResponsibleNurse, this.TurnReserveToUsed, this.labelResponsibleNurse, this.ttlabel4, this.labelClinicInpatientDate, this.PhysicalStateClinic, this.labelInpatientProtocolNo, this.RequestDate, this.labelQuarantineProtocolNo, this.ClinicInPatientDate, this.MasterResource, this.InpatientProtocolNo, this.ttlabel1, this.labelInpatientDepartment, this.ttlabel2, this.QuarantineProtocolNo, this.RoomGroup, this.labelNumberOfEmptyBeds, this.HospitalInpatientDate, this.labelResponsibleDoctor, this.labelBed, this.labelHospitalInpatientDate, this.Bed];
        this.Controls = [this.ttpanel1, this.labelShotInpatientReason, this.labelLongInpatientReason, this.ShotInpatientReason, this.LongInpatientReason, this.HasAirborneContactIsolationBaseInpatientAdmission, this.NeedCompanion, this.tttextbox6, this.labelProcedureDoctor, this.RequestDoctor, this.labelEstimatedInpatientDate, this.EstimatedInpatientDate, this.HasContactIsolationBaseInpatientAdmission, this.labelEstimatedDischargeDate, this.HasDropletIsolationBaseInpatientAdmission, this.ttlabel18, this.HasFallingRiskBaseInpatientAdmission, this.HasTightContactIsolationBaseInpatientAdmission, this.EstimatedDischargeDate, this.NumberOfEmptyBeds, this.ResponsibleDoctor, this.Room, this.LabelDateTime, this.ResponsibleNurse, this.TurnReserveToUsed, this.labelResponsibleNurse, this.ttlabel4, this.labelClinicInpatientDate, this.PhysicalStateClinic, this.labelInpatientProtocolNo, this.RequestDate, this.labelQuarantineProtocolNo, this.ClinicInPatientDate, this.MasterResource, this.InpatientProtocolNo, this.ttlabel1, this.labelInpatientDepartment, this.ttlabel2, this.QuarantineProtocolNo, this.RoomGroup, this.labelNumberOfEmptyBeds, this.HospitalInpatientDate, this.labelResponsibleDoctor, this.labelBed, this.labelHospitalInpatientDate, this.Bed];

    }


}
