//$83162871
import { Component, OnInit, NgZone } from '@angular/core';
import { SurgeryRequestFormViewModel, SurgeryAppointmentCarrierClass } from './SurgeryRequestFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Episode, KvcResultEnum } from 'NebulaClient/Model/AtlasClientModel';
import { EpisodeActionForm } from "Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/EpisodeActionForm";
import { Exception } from 'NebulaClient/Mscorlib/Exception';
import { Surgery } from 'NebulaClient/Model/AtlasClientModel';
import { TTException } from 'NebulaClient/Utils/Exceptions/TTException';
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { DiagnosisGrid } from 'NebulaClient/Model/AtlasClientModel';
import { MainSurgeryProcedure } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryDesk } from 'NebulaClient/Model/AtlasClientModel';
import { ResSurgeryRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { CommonService } from 'app/NebulaClient/Services/ObjectService/CommonService';
import { DynamicComponentInfo } from '../../../wwwroot/app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from '../../../wwwroot/app/Fw/Models/DynamicComponentInputParam';
import { ActiveIDsModel } from '../../../wwwroot/app/Fw/Models/ParameterDefinitionModel';
import { KvcRiskScoreFormViewModel } from './KvcRiskScoreFormViewModel';


@Component({
    selector: 'SurgeryRequestForm',
    templateUrl: './SurgeryRequestForm.html',
    providers: [MessageService, ServiceLocator]
})
export class SurgeryRequestForm extends EpisodeActionForm implements OnInit {
    CAProcedureObject: TTVisual.ITTListBoxColumn;
    ComplicationDescription: TTVisual.ITTTextBox;
    //DescriptionOfProcedureObject: TTVisual.ITTRichTextBoxControlColumn;
    DescriptionToPreOp: TTVisual.ITTRichTextBoxControl;
    Emergency: TTVisual.ITTCheckBox;
    IsNeedAnesthesia: TTVisual.ITTCheckBox;
    EntryActionType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeAddToHistory: TTVisual.ITTCheckBoxColumn;
    EpisodeDiagnose: TTVisual.ITTListBoxColumn;
    EpisodeDiagnoseDate: TTVisual.ITTDateTimePickerColumn;
    EpisodeDiagnosisType: TTVisual.ITTEnumComboBoxColumn;
    EpisodeIsMainDiagnose: TTVisual.ITTCheckBoxColumn;
    EpisodeResponsibleUser: TTVisual.ITTListBoxColumn;
    GridDiagnosis: TTVisual.ITTGrid;
    GridMainSurgeryProcedures: TTVisual.ITTGrid;
    IsComplicationSurgery: TTVisual.ITTCheckBox;
    labelComplicationDescription: TTVisual.ITTLabel;
    labelNotesToAnesthesia: TTVisual.ITTLabel;
    labelPlannedSurgeryDescription: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelProtocolNo: TTVisual.ITTLabel;
    labelRequestDate: TTVisual.ITTLabel;
    labelRoom: TTVisual.ITTLabel;
    labelSurgeryDesk: TTVisual.ITTLabel;
    MasterResource: TTVisual.ITTObjectListBox;
    NotesToAnesthesia: TTVisual.ITTTextBox;
    PlannedSurgeryDescription: TTVisual.ITTTextBox;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    ProtocolNo: TTVisual.ITTTextBox;
    RequestDate: TTVisual.ITTDateTimePicker;
    SurgeryDesk: TTVisual.ITTObjectListBox;
    SurgeryRoom: TTVisual.ITTObjectListBox;
    PlannedSurgeryDate: TTVisual.ITTDateTimePicker;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    public GridDiagnosisColumns = [];
    public GridMainSurgeryProceduresColumns = [];
    public surgeryRequestFormViewModel: SurgeryRequestFormViewModel = new SurgeryRequestFormViewModel();
    public get _Surgery(): Surgery {
        return this._TTObject as Surgery;
    }
    private SurgeryRequestForm_DocumentUrl: string = '/api/SurgeryService/SurgeryRequestForm';
    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        protected ServiceLocator: ServiceLocator,
        protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.SurgeryRequestForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    public isComplicationSurgery: boolean;
    public actionIdForDemografic(): Guid {
        if (this._Surgery.MasterAction != null) {
            if (typeof this._Surgery.MasterAction === "string") {
                return this._Surgery.MasterAction;
            }
            else {
                return this._Surgery.MasterAction.ObjectID;
            }
        }

        return this._Surgery.ObjectID;
    }

    private async Emergency_CheckedChanged(): Promise<void> {


    }


    private async IsNeedAnesthesia_CheckedChanged(): Promise<void> {


    }


    public SurgeryAppointmentColumns = [
        {
            caption: 'Planlanan Randevu Tarihi',
            dataField: 'PlannedStartDate',
            width: "auto",
            dataType: 'date',
            format: 'dd.MM.yyyy HH:mm',
            allowEditing: false
        },
        {
            caption: 'Planlayan Hekim',
            dataField: 'ProcedureDoctor',
            width: "auto",
            allowEditing: false
        },
        {
            caption: "Seç",
            name: 'RowSelect',
            width: '50',
            cellTemplate: 'selectButtonCellTemplate'
        }

    ];

    public chooseAppointment(appointmentObjectID: Guid) {
        this.ActiveIDsModel.episodeId = appointmentObjectID;
        this.load();
    }

    public continueWithoutAppointment() {
        this.surgeryRequestFormViewModel.PatientSurgeryAppointments = new Array<SurgeryAppointmentCarrierClass>();
    }

    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
        if (transDef !== null) {
            if (transDef.FromStateDefID.valueOf() == Surgery.SurgeryStates.SurgeryRequest.id) {
                if (this._Surgery.ProcedureDoctor == null)
                    throw new TTException(i18n("M22138", "Sorumlu cerrah bilgisini giriniz!"));
                if (this._Surgery.MasterResource == null)
                    throw new Exception(i18n("M10855", "Ameliyathane boş geçilemez"));

                if (this._Surgery.PlannedSurgeryDescription == null && this._Surgery.MainSurgeryProcedures.length == 0)
                    throw new Exception(i18n("M20398", "Planlanan Ameliyat(lar)' ve 'Planlanan Ameliyat Açıklaması' alanlarının ikisi birden boş geçilemez"));


            }
        }

        for (let mainSurgeryProcedure of this.surgeryRequestFormViewModel.GridMainSurgeryProceduresGridList) {
            if (this._Surgery.PlannedSurgeryDate != null) {
                if (mainSurgeryProcedure.ActionDate == null)
                    mainSurgeryProcedure.ActionDate = this._Surgery.PlannedSurgeryDate;
            }
            else {
                if (this._Surgery.PlannedSurgeryDate == null)
                    throw new Exception(i18n("M20396", "Planlanan ameliyat tarihi boş geçilemez"));
            }
            //if (mainSurgeryProcedure.EpisodeAction == null)
            //    mainSurgeryProcedure.EpisodeAction = this.surgeryRequestFormViewModel._Surgery;
            //if (mainSurgeryProcedure.Episode == null)
            //    mainSurgeryProcedure.Episode = this.surgeryRequestFormViewModel._Surgery.Episode;
        }
    }
    protected async PreScript() {
        super.PreScript();

        if (this.surgeryRequestFormViewModel.HasOtherSurgery == true) {
            // TTVisual.InfoBox.Alert("Bu hastaya başlatılmış ancak henüz tamamlanmamış ameliyat işlemi bulunmaktadır");
            ServiceLocator.MessageService.showInfo(i18n("M12079", "Bu hastaya başlatılmış ancak henüz tamamlanmamış ameliyat işlemi bulunmaktadır..."));
        }
        //if (this.surgeryRequestFormViewModel.ConsLimitIfHasAnesthesiaConsultation > 0) {//  Clienta aynı anda hem limit değerini hem de Konsültasyon olup olmadığını yollamak için Int yapıldı
        //    TTVisual.InfoBox.Show("Son " + this.surgeryRequestFormViewModel.ConsLimitIfHasAnesthesiaConsultation + "gün içerisinde  hastaya yapılmış anestezi konsültasyonu bulunmamaktadır");
        //}
        //if (this.surgeryRequestFormViewModel.ConsLimitIfHasAnesthesiaConsultation > 0) {//  Clienta aynı anda hem limit değerini hem de Konsültasyon olup olmadığını yollamak için Int yapıldı
        //    let result: string = await TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", 'Son ' + this.surgeryRequestFormViewModel.ConsLimitIfHasAnesthesiaConsultation + 'gün içerisinde  hastaya yapılmış anestezi konsültasyonu bulunmamaktadır.Ameliyat işlemi başlatmak istediğinize emin misiniz?');
        //    if (result === "H") {
        //        throw new Exception('İşlem İptal edildi');
        //    }
        //}

        this.isComplicationSurgery = this._Surgery.IsComplicationSurgery;

        this.ArrangeTriggers();
    }


    //AMELİYATHANE  MASA YATAK

    private getObjectID(ttObject): string {
        if (ttObject == null)
            return null;
        if (typeof ttObject == "string") {
            return ttObject;
        }
        else
            return ttObject.ObjectID.toString();
    }

    private triggerLoadChildComboBoxBySurgeryDepartment(surgeryDepartment): void {

        if (surgeryDepartment != null) {
            this.SurgeryRoom.ListFilterExpression = " THIS.SURGERYDEPARTMENT= '" + surgeryDepartment.ObjectID.toString() + "'";
            if (this._Surgery.SurgeryRoom != null && (this._Surgery.SurgeryRoom.SurgeryDepartment == null || this.getObjectID(this._Surgery.SurgeryRoom.SurgeryDepartment) != surgeryDepartment.ObjectID))
                this._Surgery.SurgeryRoom = null;
        }
        else {
            this.SurgeryRoom.ListFilterExpression = " ";
            this._Surgery.SurgeryRoom = null;
        }


    }

    private triggerLoadChildComboBoxBySurgeryRoom(surgeryRoom): void {
        if (surgeryRoom != null) {
            this.SurgeryDesk.ListFilterExpression = " THIS.SURGERYROOM= '" + surgeryRoom.ObjectID.toString() + "'";
            if (this._Surgery.SurgeryDesk != null && (this._Surgery.SurgeryDesk.SurgeryRoom == null || this.getObjectID(this._Surgery.SurgeryDesk.SurgeryRoom) != surgeryRoom.ObjectID))
                this._Surgery.SurgeryDesk = null;

            if (this._Surgery.MasterResource == null || this._Surgery.MasterResource.ObjectID != surgeryRoom.SurgeryDepartment)
                this._Surgery.MasterResource = surgeryRoom.SurgeryDepartment;
        }
        else {
            this.SurgeryDesk.ListFilterExpression = " ";
            this._Surgery.SurgeryDesk = null;
        }
    }


    private triggerLoadChildComboBoxBySurgeryDesk(surgeryDesk): void {
        if (surgeryDesk) {
            if (this._Surgery.SurgeryRoom == null || this._Surgery.SurgeryRoom.ObjectID != surgeryDesk.SurgeryRoom)
                this._Surgery.SurgeryRoom = surgeryDesk.SurgeryRoom;
        }
    }

    protected ArrangeTriggers() {
        if (this._Surgery.MasterResource != null)
            this.triggerLoadChildComboBoxBySurgeryDepartment(this._Surgery.MasterResource);
        if (this._Surgery.SurgeryRoom != null)
            this.triggerLoadChildComboBoxBySurgeryRoom(this._Surgery.SurgeryRoom);

    }

    public showKvcScorePopup: boolean = false;
    public KvcScoreComponentInfo: DynamicComponentInfo = new DynamicComponentInfo();
    rowInserting(data: any) {
        if (data != null && data.ProcedureObject != null && data.ProcedureObject.IsNeedKvcScore != null && data.ProcedureObject.IsNeedKvcScore == true) {
            this.OpenKvcScore();
        }
    }

    public OpenKvcScore() {
        this.showKvcScorePopup = true;
        this.openDynamicComponent(null, this.surgeryRequestFormViewModel.KvcScoreId, null, null);
    }

    openDynamicComponent(objectDefName?: any, objectID?: any, formDefId?: any, inputparam?: any) {

        let compInfo: DynamicComponentInfo = new DynamicComponentInfo();
        if (objectID != null) {
            compInfo.objectID = objectID;
        } else {
            compInfo.objectID = null;
        }
        compInfo.ComponentName = 'KvcRiskScoreForm';
        compInfo.ModuleName = 'AmeliyatModule';
        compInfo.ModulePath = 'Modules/Tibbi_Surec/Ameliyat_Modulu/AmeliyatModule';
        let _inputParam = {};
        _inputParam['Surgery'] = this.surgeryRequestFormViewModel._Surgery;
        if (this.surgeryRequestFormViewModel.KvcRiskScore != null) {
            _inputParam['KvcRiskScoreParams'] = this.surgeryRequestFormViewModel.KvcRiskScore;
        }

        if (typeof this.surgeryRequestFormViewModel._Surgery.Episode == 'string') {
            compInfo.InputParam = new DynamicComponentInputParam(_inputParam, new ActiveIDsModel(this.surgeryRequestFormViewModel._Surgery.ObjectID, this.surgeryRequestFormViewModel._Surgery.Episode, null));
        } else {
            compInfo.InputParam = new DynamicComponentInputParam(_inputParam, new ActiveIDsModel(this.surgeryRequestFormViewModel._Surgery.ObjectID, this.surgeryRequestFormViewModel._Surgery.Episode.ObjectID, null));
        }
        //compInfo.CloseWithStateTransition = true;
        //compInfo.DestroyComponentOnSave = true;
        //compInfo.RefreshComponent = true;

        this.KvcScoreComponentInfo = compInfo;
    }

    public async KvcScoreActionExecuted(value: any) {
        if (value != null && value.Cancelled != true) {
            let _data: KvcRiskScoreFormViewModel = value as KvcRiskScoreFormViewModel;
            this.surgeryRequestFormViewModel.KvcRiskScore = _data._KvcRiskScore;
            let kvcText = "";
            if (this.surgeryRequestFormViewModel.KvcRiskScore.TotalRisk == KvcResultEnum.HighRisk) {
                kvcText = "Yüksek Risk";
            } else if (this.surgeryRequestFormViewModel.KvcRiskScore.TotalRisk == KvcResultEnum.MiddleRisk) {
                kvcText = "Orta Risk";
            } else {
                kvcText = "Düşük Risk";
            }
            this.surgeryRequestFormViewModel.KvcTotalRisk = "Kvc TOPLAM Risk Puanı : " + kvcText;
            this.showKvcScorePopup = false;
        }
    }
    public async KvcScoreDynamicComponentClosed(value: any) {
        this.showKvcScorePopup = false;
    }
    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new Surgery();
        this.surgeryRequestFormViewModel = new SurgeryRequestFormViewModel();
        this._ViewModel = this.surgeryRequestFormViewModel;
        this.surgeryRequestFormViewModel._Surgery = this._TTObject as Surgery;
        this.surgeryRequestFormViewModel._Surgery.SurgeryDesk = new ResSurgeryDesk();
        this.surgeryRequestFormViewModel._Surgery.ProcedureDoctor = new ResUser();
        this.surgeryRequestFormViewModel._Surgery.SurgeryRoom = new ResSurgeryRoom();
        this.surgeryRequestFormViewModel._Surgery.MasterResource = new ResSection();
        this.surgeryRequestFormViewModel._Surgery.Episode = new Episode();
        this.surgeryRequestFormViewModel._Surgery.Episode.Diagnosis = new Array<DiagnosisGrid>();
        this.surgeryRequestFormViewModel._Surgery.MainSurgeryProcedures = new Array<MainSurgeryProcedure>();
    }

    protected loadViewModel() {
        let that = this;

        that.surgeryRequestFormViewModel = this._ViewModel as SurgeryRequestFormViewModel;
        that._TTObject = this.surgeryRequestFormViewModel._Surgery;
        if (this.surgeryRequestFormViewModel == null)
            this.surgeryRequestFormViewModel = new SurgeryRequestFormViewModel();
        if (this.surgeryRequestFormViewModel._Surgery == null)
            this.surgeryRequestFormViewModel._Surgery = new Surgery();
        let surgeryDeskObjectID = that.surgeryRequestFormViewModel._Surgery["SurgeryDesk"];
        if (surgeryDeskObjectID != null && (typeof surgeryDeskObjectID === 'string')) {
            let surgeryDesk = that.surgeryRequestFormViewModel.ResSurgeryDesks.find(o => o.ObjectID.toString() === surgeryDeskObjectID.toString());
            if (surgeryDesk) {
                that.surgeryRequestFormViewModel._Surgery.SurgeryDesk = surgeryDesk;
            }
        }
        let procedureDoctorObjectID = that.surgeryRequestFormViewModel._Surgery["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.surgeryRequestFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
            if (procedureDoctor) {
                that.surgeryRequestFormViewModel._Surgery.ProcedureDoctor = procedureDoctor;
            }
        }
        let surgeryRoomObjectID = that.surgeryRequestFormViewModel._Surgery["SurgeryRoom"];
        if (surgeryRoomObjectID != null && (typeof surgeryRoomObjectID === 'string')) {
            let surgeryRoom = that.surgeryRequestFormViewModel.ResSurgeryRooms.find(o => o.ObjectID.toString() === surgeryRoomObjectID.toString());
            if (surgeryRoom) {
                that.surgeryRequestFormViewModel._Surgery.SurgeryRoom = surgeryRoom;
            }
        }
        let masterResourceObjectID = that.surgeryRequestFormViewModel._Surgery["MasterResource"];
        if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
            let masterResource = that.surgeryRequestFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
            if (masterResource) {
                that.surgeryRequestFormViewModel._Surgery.MasterResource = masterResource;
            }
        }
        let episodeObjectID = that.surgeryRequestFormViewModel._Surgery["Episode"];
        if (episodeObjectID != null && (typeof episodeObjectID === 'string')) {
            let episode = that.surgeryRequestFormViewModel.Episodes.find(o => o.ObjectID.toString() === episodeObjectID.toString());
            if (episode) {
                that.surgeryRequestFormViewModel._Surgery.Episode = episode;
            }
            if (episode != null) {
                episode.Diagnosis = that.surgeryRequestFormViewModel.GridDiagnosisGridList;
                for (let detailItem of that.surgeryRequestFormViewModel.GridDiagnosisGridList) {
                    let diagnoseObjectID = detailItem["Diagnose"];
                    if (diagnoseObjectID != null && (typeof diagnoseObjectID === 'string')) {
                        let diagnose = that.surgeryRequestFormViewModel.DiagnosisDefinitions.find(o => o.ObjectID.toString() === diagnoseObjectID.toString());
                        if (diagnose) {
                            detailItem.Diagnose = diagnose;
                        }
                    }
                    let responsibleUserObjectID = detailItem["ResponsibleUser"];
                    if (responsibleUserObjectID != null && (typeof responsibleUserObjectID === 'string')) {
                        let responsibleUser = that.surgeryRequestFormViewModel.ResUsers.find(o => o.ObjectID.toString() === responsibleUserObjectID.toString());
                        if (responsibleUser) {
                            detailItem.ResponsibleUser = responsibleUser;
                        }
                    }
                }
            }
        }
        that.surgeryRequestFormViewModel._Surgery.MainSurgeryProcedures = that.surgeryRequestFormViewModel.GridMainSurgeryProceduresGridList;
        for (let detailItem of that.surgeryRequestFormViewModel.GridMainSurgeryProceduresGridList) {
            let procedureObjectObjectID = detailItem["ProcedureObject"];
            if (procedureObjectObjectID != null && (typeof procedureObjectObjectID === 'string')) {
                let procedureObject = that.surgeryRequestFormViewModel.ProcedureDefinitions.find(o => o.ObjectID.toString() === procedureObjectObjectID.toString());
                if (procedureObject) {
                    detailItem.ProcedureObject = procedureObject;
                }
            }
        }
    }


    async ngOnInit() {
        let that = this;
        await this.load(SurgeryRequestFormViewModel);

    }


    public onComplicationDescriptionChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.ComplicationDescription != event) {
                this._Surgery.ComplicationDescription = event;
            }
        }
    }

    public onDescriptionToPreOpChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.DescriptionToPreOp != event) {
                this._Surgery.DescriptionToPreOp = event;
            }
        }
    }

    public onEmergencyChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.Emergency != event) {
                this._Surgery.Emergency = event;
            }

        }
        this.Emergency_CheckedChanged();
    }

    public onIsNeedAnesthesiaChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.IsNeedAnesthesia != event) {
                this._Surgery.IsNeedAnesthesia = event;
            }

        }
        this.IsNeedAnesthesia_CheckedChanged();
    }


    public onIsComplicationSurgeryChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.IsComplicationSurgery != event) {
                this._Surgery.IsComplicationSurgery = event;
                this.isComplicationSurgery = event;
            }
        }
    }



    public onNotesToAnesthesiaChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.NotesToAnesthesia != event) {
                this._Surgery.NotesToAnesthesia = event;
            }
        }
    }

    public onPlannedSurgeryDescriptionChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.PlannedSurgeryDescription != event) {
                this._Surgery.PlannedSurgeryDescription = event;
            }
        }
    }

    public async onProcedureDoctorChanged(event) {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.ProcedureDoctor != event) {
                this._Surgery.ProcedureDoctor = event;

                let a = await CommonService.PersonelIzinKontrol(this._Surgery.ProcedureDoctor.ObjectID, this._Surgery.PlannedSurgeryDate);
                if (a) {
                    this.messageService.showInfo(this._Surgery.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._Surgery.ProcedureDoctor = null;
                    }, 500);

                }
            }

        }
    }

    public onProtocolNoChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.ProtocolNo != event) {
                this._Surgery.ProtocolNo = event;
            }
        }
    }

    public onRequestDateChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.RequestDate != event) {
                this._Surgery.RequestDate = event;
            }
        }
    }

    public async onPlannedSurgeryDateChanged(event) {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.PlannedSurgeryDate != event) {
                this._Surgery.PlannedSurgeryDate = event;

                if (this._Surgery.ProcedureDoctor != null) {
                    let a = await CommonService.PersonelIzinKontrol(this._Surgery.ProcedureDoctor.ObjectID, this._Surgery.PlannedSurgeryDate);
                    if (a) {
                        this.messageService.showInfo(this._Surgery.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                        setTimeout(() => {
                            this._Surgery.ProcedureDoctor = null;
                        }, 500);

                    }
                }
            }
        }
    }

    public onMasterResourceChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.MasterResource != event) {
                this._Surgery.MasterResource = event;
            }
        }
        this.triggerLoadChildComboBoxBySurgeryDepartment(event);
    }


    public onSurgeryRoomChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.SurgeryRoom != event) {
                this._Surgery.SurgeryRoom = event;
            }
        }
        this.triggerLoadChildComboBoxBySurgeryRoom(event);
    }
    public onSurgeryDeskChanged(event): void {
        if (event != null) {
            if (this._Surgery != null && this._Surgery.SurgeryDesk != event) {
                this._Surgery.SurgeryDesk = event;
            }
        }
        this.triggerLoadChildComboBoxBySurgeryDesk(event);
    }



    protected redirectProperties(): void {
        redirectProperty(this.RequestDate, "Value", this.__ttObject, "RequestDate");
        redirectProperty(this.PlannedSurgeryDate, "Value", this.__ttObject, "PlannedSurgeryDate");
        redirectProperty(this.ProtocolNo, "Text", this.__ttObject, "ProtocolNo");
        redirectProperty(this.Emergency, "Value", this.__ttObject, "Emergency");
        redirectProperty(this.IsNeedAnesthesia, "Value", this.__ttObject, "IsNeedAnesthesia");
        redirectProperty(this.IsComplicationSurgery, "Value", this.__ttObject, "IsComplicationSurgery");
        redirectProperty(this.ComplicationDescription, "Text", this.__ttObject, "ComplicationDescription");
        redirectProperty(this.PlannedSurgeryDescription, "Text", this.__ttObject, "PlannedSurgeryDescription");
        redirectProperty(this.DescriptionToPreOp, "Rtf", this.__ttObject, "DescriptionToPreOp");
        redirectProperty(this.NotesToAnesthesia, "Text", this.__ttObject, "NotesToAnesthesia");
    }

    public initFormControls(): void {
        this.labelSurgeryDesk = new TTVisual.TTLabel();
        this.labelSurgeryDesk.Text = i18n("M18680", "Masa");
        this.labelSurgeryDesk.Name = "labelSurgeryDesk";
        this.labelSurgeryDesk.TabIndex = 106;

        this.SurgeryDesk = new TTVisual.TTObjectListBox();
        this.SurgeryDesk.LinkedControlName = "SurgeryRoom";
        this.SurgeryDesk.ListDefName = "SurgeryDeskListDefinition";
        this.SurgeryDesk.Name = "SurgeryDesk";
        this.SurgeryDesk.TabIndex = 105;

        this.labelPlannedSurgeryDescription = new TTVisual.TTLabel();
        this.labelPlannedSurgeryDescription.Text = i18n("M20394", "Planlanan Ameliyat Açıklaması");
        this.labelPlannedSurgeryDescription.Name = "labelPlannedSurgeryDescription";
        this.labelPlannedSurgeryDescription.TabIndex = 104;

        this.PlannedSurgeryDescription = new TTVisual.TTTextBox();
        this.PlannedSurgeryDescription.Multiline = true;
        this.PlannedSurgeryDescription.Name = "PlannedSurgeryDescription";
        this.PlannedSurgeryDescription.TabIndex = 103;
        this.PlannedSurgeryDescription.Height = "170px";

        this.NotesToAnesthesia = new TTVisual.TTTextBox();
        this.NotesToAnesthesia.Multiline = true;
        this.NotesToAnesthesia.Name = "NotesToAnesthesia";
        this.NotesToAnesthesia.TabIndex = 11;
        this.NotesToAnesthesia.Height = "180px";

        this.ProtocolNo = new TTVisual.TTTextBox();
        this.ProtocolNo.BackColor = "#F0F0F0";
        this.ProtocolNo.ReadOnly = true;
        this.ProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProtocolNo.Name = "ProtocolNo";
        this.ProtocolNo.TabIndex = 4;
        this.ProtocolNo.Visible = false;

        this.ComplicationDescription = new TTVisual.TTTextBox();
        this.ComplicationDescription.Multiline = true;
        this.ComplicationDescription.Name = "ComplicationDescription";
        this.ComplicationDescription.TabIndex = 123;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = i18n("M22140", "Sorumlu Cerrah(1.Cerrah)");
        this.labelProcedureDoctor.BackColor = "#DCDCDC";
        this.labelProcedureDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProcedureDoctor.ForeColor = "#000000";
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 102;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.ProcedureDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 2;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        this.RequestDate.BackColor = "#F0F0F0";
        this.RequestDate.CustomFormat = "";
        this.RequestDate.Format = DateTimePickerFormat.Short;
        this.RequestDate.Enabled = false;
        this.RequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RequestDate.Name = "RequestDate";
        this.RequestDate.TabIndex = 0;

        this.labelRequestDate = new TTVisual.TTLabel();
        this.labelRequestDate.Text = i18n("M10816", "Ameliyat İstek Tarihi");
        this.labelRequestDate.BackColor = "#DCDCDC";
        this.labelRequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRequestDate.ForeColor = "#000000";
        this.labelRequestDate.Name = "labelRequestDate";
        this.labelRequestDate.TabIndex = 100;

        this.labelNotesToAnesthesia = new TTVisual.TTLabel();
        this.labelNotesToAnesthesia.Text = i18n("M10963", "Anestezi Bölümü İçin Açıklamalar");
        this.labelNotesToAnesthesia.BackColor = "#DCDCDC";
        this.labelNotesToAnesthesia.ForeColor = "#000000";
        this.labelNotesToAnesthesia.Name = "labelNotesToAnesthesia";
        this.labelNotesToAnesthesia.TabIndex = 10;


        this.DescriptionToPreOp = new TTVisual.TTRichTextBoxControl();
        this.DescriptionToPreOp.DisplayText = i18n("M19974", "Ön Hazırlık İçin Direktifler");
        this.DescriptionToPreOp.TemplateGroupName = "SURGERYDESCRIPTIONTOPREOP";
        this.DescriptionToPreOp.BackColor = "#FFFFFF";
        this.DescriptionToPreOp.Name = "DescriptionToPreOp";
        this.DescriptionToPreOp.TabIndex = 9;


        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = i18n("M20395", "Planlanan Ameliyat Tarihi");
        this.ttlabel9.BackColor = "#DCDCDC";
        this.ttlabel9.ForeColor = "#000000";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 80;

        this.PlannedSurgeryDate = new TTVisual.TTDateTimePicker();
        this.PlannedSurgeryDate.CustomFormat = "";
        this.PlannedSurgeryDate.Format = DateTimePickerFormat.Short;
        this.PlannedSurgeryDate.Name = "PlannedSurgeryDate";
        this.PlannedSurgeryDate.TabIndex = 1;

        this.labelProtocolNo = new TTVisual.TTLabel();
        this.labelProtocolNo.Text = i18n("M20566", "Protokol No");
        this.labelProtocolNo.BackColor = "#DCDCDC";
        this.labelProtocolNo.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProtocolNo.ForeColor = "#000000";
        this.labelProtocolNo.Name = "labelProtocolNo";
        this.labelProtocolNo.TabIndex = 74;
        this.labelProtocolNo.Visible = false;

        this.SurgeryRoom = new TTVisual.TTObjectListBox();
        this.SurgeryRoom.LinkedControlName = "MasterResource";
        this.SurgeryRoom.ListDefName = "SurgeryRoomListDefinition";
        this.SurgeryRoom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryRoom.Name = "SurgeryRoom";
        this.SurgeryRoom.TabIndex = 6;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M10854", "Ameliyathane");
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 78;

        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ListDefName = "SurgreyDepartmentListDefinition";
        this.MasterResource.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MasterResource.Name = "MasterResource";
        this.MasterResource.TabIndex = 5;

        this.Emergency = new TTVisual.TTCheckBox();
        this.Emergency.Value = false;
        this.Emergency.Title = i18n("M27300", "Acil");
        this.Emergency.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Emergency.Name = "Emergency";
        this.Emergency.TabIndex = 3;


        this.IsNeedAnesthesia = new TTVisual.TTCheckBox();
        this.IsNeedAnesthesia.Value = false;
        this.IsNeedAnesthesia.Title = i18n("M10977", "Anestezi Gerektirir");
        this.IsNeedAnesthesia.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.IsNeedAnesthesia.Name = "IsNeedAnesthesia";
        this.IsNeedAnesthesia.TabIndex = 3;



        this.GridDiagnosis = new TTVisual.TTGrid();
        this.GridDiagnosis.BackColor = "#DCDCDC";
        this.GridDiagnosis.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridDiagnosis.ReadOnly = true;
        this.GridDiagnosis.Text = i18n("M22736", "Tanı");
        this.GridDiagnosis.Name = "GridDiagnosis";
        this.GridDiagnosis.TabIndex = 8;

        this.EpisodeAddToHistory = new TTVisual.TTCheckBoxColumn();
        this.EpisodeAddToHistory.DataMember = "AddToHistory";
        this.EpisodeAddToHistory.DisplayIndex = 0;
        this.EpisodeAddToHistory.HeaderText = i18n("M20121", "Özgeçmişe Ekle");
        this.EpisodeAddToHistory.Name = "EpisodeAddToHistory";
        this.EpisodeAddToHistory.Width = 90;

        this.EpisodeDiagnose = new TTVisual.TTListBoxColumn();
        this.EpisodeDiagnose.ListDefName = "DiagnosisListDefinition";
        this.EpisodeDiagnose.DataMember = "Diagnose";
        this.EpisodeDiagnose.DisplayIndex = 1;
        this.EpisodeDiagnose.HeaderText = i18n("M24028", "Vaka Tanıları");
        this.EpisodeDiagnose.Name = "EpisodeDiagnose";
        this.EpisodeDiagnose.Width = 275;

        this.EpisodeDiagnosisType = new TTVisual.TTEnumComboBoxColumn();
        this.EpisodeDiagnosisType.DataTypeName = "DiagnosisTypeEnum";
        this.EpisodeDiagnosisType.DataMember = "DiagnosisType";
        this.EpisodeDiagnosisType.DisplayIndex = 2;
        this.EpisodeDiagnosisType.HeaderText = i18n("M22781", "Tanı Tipi");
        this.EpisodeDiagnosisType.Name = "EpisodeDiagnosisType";
        this.EpisodeDiagnosisType.Width = 80;

        this.EpisodeIsMainDiagnose = new TTVisual.TTCheckBoxColumn();
        this.EpisodeIsMainDiagnose.DataMember = "IsMainDiagnose";
        this.EpisodeIsMainDiagnose.DisplayIndex = 3;
        this.EpisodeIsMainDiagnose.HeaderText = i18n("M10926", "Ana Tanı");
        this.EpisodeIsMainDiagnose.Name = "EpisodeIsMainDiagnose";
        this.EpisodeIsMainDiagnose.Width = 75;

        this.EpisodeResponsibleUser = new TTVisual.TTListBoxColumn();
        this.EpisodeResponsibleUser.ListDefName = "UserListDefinition";
        this.EpisodeResponsibleUser.DataMember = "ResponsibleUser";
        this.EpisodeResponsibleUser.DisplayIndex = 4;
        this.EpisodeResponsibleUser.HeaderText = i18n("M22813", "Tanıyı Koyan");
        this.EpisodeResponsibleUser.Name = "EpisodeResponsibleUser";
        this.EpisodeResponsibleUser.Width = 115;

        this.EpisodeDiagnoseDate = new TTVisual.TTDateTimePickerColumn();
        this.EpisodeDiagnoseDate.Format = DateTimePickerFormat.Custom;
        this.EpisodeDiagnoseDate.CustomFormat = "dd/MM/yyyy HH:mm";
        this.EpisodeDiagnoseDate.DataMember = "DiagnoseDate";
        this.EpisodeDiagnoseDate.DisplayIndex = 5;
        this.EpisodeDiagnoseDate.HeaderText = i18n("M22750", "Tanı Giriş Tarihi");
        this.EpisodeDiagnoseDate.Name = "EpisodeDiagnoseDate";
        this.EpisodeDiagnoseDate.Width = 100;

        this.EntryActionType = new TTVisual.TTEnumComboBoxColumn();
        this.EntryActionType.DataTypeName = "ActionTypeEnum";
        this.EntryActionType.DataMember = "EntryActionType";
        this.EntryActionType.DisplayIndex = 6;
        this.EntryActionType.HeaderText = i18n("M14808", "Giriş Yapılan İşlem");
        this.EntryActionType.Name = "EntryActionType";
        this.EntryActionType.Width = 100;

        this.labelRoom = new TTVisual.TTLabel();
        this.labelRoom.Text = i18n("M21284", "Salon");
        this.labelRoom.BackColor = "#DCDCDC";
        this.labelRoom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelRoom.ForeColor = "#000000";
        this.labelRoom.Name = "labelRoom";
        this.labelRoom.TabIndex = 67;

        this.GridMainSurgeryProcedures = new TTVisual.TTGrid();
        this.GridMainSurgeryProcedures.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.GridMainSurgeryProcedures.Name = "GridMainSurgeryProcedures";
        this.GridMainSurgeryProcedures.TabIndex = 0;
        this.GridMainSurgeryProcedures.Height = 100;
        this.GridMainSurgeryProcedures.ShowFilterCombo = true;
        this.GridMainSurgeryProcedures.FilterColumnName = "CAProcedureObject";
        this.GridMainSurgeryProcedures.FilterLabel = i18n("M27385", "Ameliyat");
        this.GridMainSurgeryProcedures.Filter = { ListDefName: "SurgeryListDefinition" };
        this.GridMainSurgeryProcedures.AllowUserToAddRows = false;


        this.CAProcedureObject = new TTVisual.TTListBoxColumn();
        this.CAProcedureObject.ListDefName = "SurgeryListDefinition";
        this.CAProcedureObject.DataMember = "ProcedureObject";
        this.CAProcedureObject.DisplayIndex = 0;
        this.CAProcedureObject.HeaderText = "Ameliyat ";
        this.CAProcedureObject.Name = "CAProcedureObject";
        this.CAProcedureObject.Width = 500;
        this.CAProcedureObject.ReadOnly = true;

        //this.DescriptionOfProcedureObject = new TTVisual.TTRichTextBoxControlColumn();
        //this.DescriptionOfProcedureObject.DisplayText = "Detaylı Tanımlama";
        //this.DescriptionOfProcedureObject.DataMember = "DescriptionOfProcedureObject";
        //this.DescriptionOfProcedureObject.DisplayIndex = 1;
        //this.DescriptionOfProcedureObject.HeaderText = "Detaylı Tanımlama";
        //this.DescriptionOfProcedureObject.Name = "DescriptionOfProcedureObject";
        //this.DescriptionOfProcedureObject.Width = 200;

        this.labelComplicationDescription = new TTVisual.TTLabel();
        this.labelComplicationDescription.Text = i18n("M17722", "Komplikasyon Açıklaması");
        this.labelComplicationDescription.Name = "labelComplicationDescription";
        this.labelComplicationDescription.TabIndex = 124;

        this.IsComplicationSurgery = new TTVisual.TTCheckBox();
        this.IsComplicationSurgery.Value = false;
        this.IsComplicationSurgery.Title = i18n("M17723", "Komplikasyon Ameliyatı");
        this.IsComplicationSurgery.Name = "IsComplicationSurgery";
        this.IsComplicationSurgery.TabIndex = 122;

        this.GridDiagnosisColumns = [this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType];
        this.GridMainSurgeryProceduresColumns = [this.CAProcedureObject]; //, this.DescriptionOfProcedureObject
        this.Controls = [this.labelSurgeryDesk, this.SurgeryDesk, this.labelPlannedSurgeryDescription, this.PlannedSurgeryDescription, this.NotesToAnesthesia, this.ProtocolNo, this.ComplicationDescription, this.labelProcedureDoctor, this.ProcedureDoctor, this.RequestDate, this.labelRequestDate, this.labelNotesToAnesthesia, this.DescriptionToPreOp, this.ttlabel9, this.PlannedSurgeryDate, this.labelProtocolNo, this.SurgeryRoom, this.ttlabel1, this.MasterResource, this.Emergency, this.IsNeedAnesthesia, this.GridDiagnosis, this.EpisodeAddToHistory, this.EpisodeDiagnose, this.EpisodeDiagnosisType, this.EpisodeIsMainDiagnose, this.EpisodeResponsibleUser, this.EpisodeDiagnoseDate, this.EntryActionType, this.labelRoom, this.GridMainSurgeryProcedures, this.CAProcedureObject, this.labelComplicationDescription, this.IsComplicationSurgery]; //this.DescriptionOfProcedureObject,

    }


}
