//$29D9341F
import { Component, OnInit, NgZone } from '@angular/core';
import { InpatientAdmissionRequestFormViewModel } from './InpatientAdmissionRequestFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { InpatientAdmission } from 'NebulaClient/Model/AtlasClientModel';
import { InPatientAdmissionBaseForm } from "Modules/Tibbi_Surec/Yatan_Hasta_Modulu/InPatientAdmissionBaseForm";
import { ResClinic } from 'NebulaClient/Model/AtlasClientModel';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { TTObjectStateTransitionDef } from 'NebulaClient/StorageManager/DefinitionManagement/TTObjectStateTransitionDef';
import { InpatientReasonDefinition } from 'NebulaClient/Model/AtlasClientModel';
import { ResBed } from 'NebulaClient/Model/AtlasClientModel';
import { ResRoom } from 'NebulaClient/Model/AtlasClientModel';
import { ResRoomGroup } from 'NebulaClient/Model/AtlasClientModel';
import { ResSection } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';
import { ResWard } from 'NebulaClient/Model/AtlasClientModel';
import { DateTimePickerFormat } from 'NebulaClient/Utils/Enums/DateTimePickerFormat';
import { InputFormat } from "NebulaClient/Utils/Enums/InputFormat";
import { DialogResult } from "NebulaClient/Utils/Enums/DialogResult";
import { ModalStateService } from 'Fw/Models/ModalInfo';
import { ServiceLocator } from "Fw/Services/ServiceLocator";
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { CommonService } from 'app/NebulaClient/Services/ObjectService/CommonService';



@Component({
    selector: 'InpatientAdmissionRequestForm',
    templateUrl: './InpatientAdmissionRequestForm.html',
    providers: [MessageService]
})
export class InpatientAdmissionRequestForm extends InPatientAdmissionBaseForm implements OnInit {
    //Bed: TTVisual.ITTObjectListBox;
    //btnEmptyBedsInClinic: TTVisual.ITTButton;
    Building: TTVisual.ITTObjectListBox;

    Emergency: TTVisual.ITTCheckBox;
    EstimatedDischargeDate: TTVisual.ITTDateTimePicker;
    EstimatedInpatientDate: TTVisual.ITTDateTimePicker;
    EstimatedInpatientDateCount: TTVisual.ITTTextBox;

    HasAirborneContactIsolation: TTVisual.ITTCheckBox;
    HasContactIsolation: TTVisual.ITTCheckBox;
    HasDropletIsolation: TTVisual.ITTCheckBox;
    HasFallingRisk: TTVisual.ITTCheckBox;
    HasTightContactIsolation: TTVisual.ITTCheckBox;
    inpatientReason: TTVisual.ITTObjectListBox;
   // labelBed: TTVisual.ITTLabel;
    LabelDateTime: TTVisual.ITTLabel;
    labelEstimatedDischargeDate: TTVisual.ITTLabel;
    labelEstimatedInpatientDate: TTVisual.ITTLabel;
    //labelNumberOfEmptyBeds: TTVisual.ITTLabel;
    //labelPhysicalStateClinic: TTVisual.ITTLabel;
    labelProcedureDoctor: TTVisual.ITTLabel;
    labelReasonForInpatientAdmission: TTVisual.ITTLabel;
    labelReturnToRequestReason: TTVisual.ITTLabel;
   // labelRoom: TTVisual.ITTLabel;
   // labelRoomGroup: TTVisual.ITTLabel;
    labelTreatmentClinic: TTVisual.ITTLabel;
    lblb: TTVisual.ITTLabel;
    MasterResource: TTVisual.ITTObjectListBox;
    NeedCompanion: TTVisual.ITTCheckBox;
    //PhysicalStateClinic: TTVisual.ITTObjectListBox;
    ProcedureDoctor: TTVisual.ITTObjectListBox;
    ReasonForInpatientAdmission: TTVisual.ITTTextBox;
    RequestDate: TTVisual.ITTDateTimePicker;
    ReturnToRequestReason: TTVisual.ITTRichTextBoxControl;
    //Room: TTVisual.ITTObjectListBox;
    //RoomGroup: TTVisual.ITTObjectListBox;
    TreatmentClinic: TTVisual.ITTObjectListBox;
    ttlabel1: TTVisual.ITTLabel;
    public inpatientAdmissionRequestFormViewModel: InpatientAdmissionRequestFormViewModel = new InpatientAdmissionRequestFormViewModel();
    public get _InpatientAdmission(): InpatientAdmission {
        return this._TTObject as InpatientAdmission;
    }
    private InpatientAdmissionRequestForm_DocumentUrl: string = '/api/InpatientAdmissionService/InpatientAdmissionRequestForm';
    constructor(protected httpService: NeHttpService,
                protected messageService: MessageService,
                private modalStateService: ModalStateService,
                private reportService: AtlasReportService,
                protected ngZone: NgZone) {
        super(httpService, messageService, ngZone);
        this._DocumentServiceUrl = this.InpatientAdmissionRequestForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****
    // private inpatientAdmission: InpatientAdmission;// = new InpatientAdmission();
    public setInputParam(value: Object) {
        if (value != null) {
            this._TTObject = value as InpatientAdmission;
            this.inpatientAdmissionRequestFormViewModel = new InpatientAdmissionRequestFormViewModel();
            this._ViewModel = this.inpatientAdmissionRequestFormViewModel;
            this.inpatientAdmissionRequestFormViewModel._InpatientAdmission = value as InpatientAdmission;
            //  this.inpatientAdmission = value as InpatientAdmission;
        }
    }
    /*private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }*/

    private async PhysicalStateClinic_SelectedObjectChanged(): Promise<void> {

    }
    private async Room_SelectedObjectChanged(): Promise<void> {

    }
    private async RoomGroup_SelectedObjectChanged(): Promise<void> {

    }
    protected async ClientSidePostScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.ClientSidePostScript(transDef);
    }



    protected async PostScript(transDef: TTObjectStateTransitionDef) {
        super.PostScript(transDef);
        //            if(transDef!=null)
        //            {
        //                if(transDef.ToStateDefID!=InpatientAdmission.States.Cancelled)
        //                {
        //                    this._InpatientAdmission.IsPatientApprovalFormGiven=GetIfPatientApprovalFormIsGiven(this._InpatientAdmission.IsPatientApprovalFormGiven);
        //                }
        //            }
    }
    protected async PreScript() {
             //  super.PreScript();
        // Yatış başlatılırken yapılan Kontroller serverda Preye Taşındı
        if (String.isNullOrEmpty(this.ReturnToRequestReason.Text)) {
            this.ReturnToRequestReason.Visible = false;
            this.labelReturnToRequestReason.Visible = false;
        }
        // this.SetTreatmentClinicListFilter();
        if (this.inpatientAdmissionRequestFormViewModel.DefaultBulding != null) {
            this.Building.SelectedObject = this.inpatientAdmissionRequestFormViewModel.DefaultBulding;
        }

        (<TTVisual.ITTObjectListBox>this.TreatmentClinic).ListFilterExpression = this.inpatientAdmissionRequestFormViewModel.TreatmentClinicFilter;
    }

    protected ConfirmSave(): boolean{ // Popuplarda Post Scriptlerde hata verilse bile popup kağpanıyor o yüzden pre kontroller burda yapıldı

        if (this._InpatientAdmission.ProcedureDoctor == null) {
            this.messageService.showError(i18n("M16604", "İsteği Yapan Tabip alanı boş geçilemez.. "));
            return false;
        }

        if (this._InpatientAdmission.TreatmentClinic == null) {
            this.messageService.showError(i18n("M16604", "Tedavi Göreceği  Klinik/ Servis alanı boş geçilemez.. "));
            return false;
        }

        //if (this._InpatientAdmission.PhysicalStateClinic == null) {
        //    this.messageService.showError("Hastanın Yattığı Klinin alanı boş geçilemez.. ");
        //    return false;
        //}

        if (this._InpatientAdmission.EstimatedInpatientDateCount != null && this._InpatientAdmission.EstimatedInpatientDateCount < 0 ) {
            this.messageService.showError(i18n("M22601", "Tahmini Taburcu Tarihi ,Tahmini Yatış tarihinden küçük olamaz "));
            return false;
        }

        let inPatientForBirthGuid: Guid = new Guid("8695c125-cc84-4391-9d2b-db2d84afe8cf");
        if (this._InpatientAdmission.InpatientReason != null && this._InpatientAdmission.InpatientReason.ObjectID === inPatientForBirthGuid && this._InpatientAdmission.Episode.Patient.Sex.ADI === "ERKEK") {
            //throw new TTException("Erkek hastaları doğum sebebi ile yatıramazsınız");
            this.messageService.showError(i18n("M13839", "Erkek hastaları doğum sebebi ile yatıramazsınız"));
            return false;
        }
        return true;
    }
    public btnInPatientAdmissionSave_Click() {
        try {
            if (this.ConfirmSave() == true) {
                this.save();
                this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._InpatientAdmission);
            }
        }
        catch (err) {
            ServiceLocator.MessageService.showError(err);
        }

    }

    protected async SetTreatmentClinicListFilter(): Promise<void> {
        if (((await SystemParameterService.GetParameterValue("TREATMENTCLINICFILTER", "FALSE")) === "TRUE")) {
            let filterString: string = "OBJECTID IN (''";
            let isEmergency: boolean = false;
            let hasResourceSpeciality: boolean = false;
            if (this._EpisodeAction.FromResource !== null) {
                for (let spg of this._EpisodeAction.FromResource.ResourceSpecialities) {
                    hasResourceSpeciality = true;
                    if (spg.Speciality !== null) {
                        if (spg.Speciality.Code === (await SystemParameterService.GetParameterValue("EMERGENCYSPECIALITYDEFINITIONCODE", "4400")).toString())
                            isEmergency = true;
                        for (let rsg of spg.Speciality.ResourceSpecialities) {
                            if (rsg.Resource instanceof ResClinic)
                                filterString += " ,'" + rsg.Resource.ObjectID.toString() + "'";
                        }
                    }
                    filterString += ")";
                }
            }
            if (!isEmergency && hasResourceSpeciality) {
                //filterString = "DEPARTMENT = '" + this._EpisodeAction.FromResource.ObjectID + "'";
                (<TTVisual.ITTObjectListBox>this.TreatmentClinic).ListFilterExpression = filterString;
            }
        }
    }

    sendSelectedPhysicalStateClinic(physicalStateClinic: ResWard) {
        this.inpatientAdmissionRequestFormViewModel._InpatientAdmission.PhysicalStateClinic = physicalStateClinic;
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new InpatientAdmission();
        this.inpatientAdmissionRequestFormViewModel = new InpatientAdmissionRequestFormViewModel();
        this._ViewModel = this.inpatientAdmissionRequestFormViewModel;
        this.inpatientAdmissionRequestFormViewModel._InpatientAdmission = this._TTObject as InpatientAdmission;
        this.inpatientAdmissionRequestFormViewModel._InpatientAdmission.MasterResource = new ResSection();
        this.inpatientAdmissionRequestFormViewModel._InpatientAdmission.TreatmentClinic = new ResClinic();
        this.inpatientAdmissionRequestFormViewModel._InpatientAdmission.Bed = new ResBed();
        this.inpatientAdmissionRequestFormViewModel._InpatientAdmission.RoomGroup = new ResRoomGroup();
        this.inpatientAdmissionRequestFormViewModel._InpatientAdmission.Room = new ResRoom();
        this.inpatientAdmissionRequestFormViewModel._InpatientAdmission.PhysicalStateClinic = new ResWard();
        this.inpatientAdmissionRequestFormViewModel._InpatientAdmission.ProcedureDoctor = new ResUser();
        this.inpatientAdmissionRequestFormViewModel._InpatientAdmission.InpatientReason = new InpatientReasonDefinition();
    }

    protected loadViewModel() {
        let that = this;

        that.inpatientAdmissionRequestFormViewModel = this._ViewModel as InpatientAdmissionRequestFormViewModel;
        that._TTObject = this.inpatientAdmissionRequestFormViewModel._InpatientAdmission;
        if (this.inpatientAdmissionRequestFormViewModel == null)
            this.inpatientAdmissionRequestFormViewModel = new InpatientAdmissionRequestFormViewModel();
        if (this.inpatientAdmissionRequestFormViewModel._InpatientAdmission == null)
            this.inpatientAdmissionRequestFormViewModel._InpatientAdmission = new InpatientAdmission();
        let masterResourceObjectID = that.inpatientAdmissionRequestFormViewModel._InpatientAdmission["MasterResource"];
        if (masterResourceObjectID != null && (typeof masterResourceObjectID === 'string')) {
            let masterResource = that.inpatientAdmissionRequestFormViewModel.ResSections.find(o => o.ObjectID.toString() === masterResourceObjectID.toString());
             if (masterResource) {
                that.inpatientAdmissionRequestFormViewModel._InpatientAdmission.MasterResource = masterResource;
            }
        }
        let treatmentClinicObjectID = that.inpatientAdmissionRequestFormViewModel._InpatientAdmission["TreatmentClinic"];
        if (treatmentClinicObjectID != null && (typeof treatmentClinicObjectID === 'string')) {
            let treatmentClinic = that.inpatientAdmissionRequestFormViewModel.ResClinics.find(o => o.ObjectID.toString() === treatmentClinicObjectID.toString());
             if (treatmentClinic) {
                that.inpatientAdmissionRequestFormViewModel._InpatientAdmission.TreatmentClinic = treatmentClinic;
            }
        }
        //let bedObjectID = that.inpatientAdmissionRequestFormViewModel._InpatientAdmission["Bed"];
        //if (bedObjectID != null && (typeof bedObjectID === 'string')) {
        //    let bed = that.inpatientAdmissionRequestFormViewModel.ResBeds.find(o => o.ObjectID.toString() === bedObjectID.toString());
        //    that.inpatientAdmissionRequestFormViewModel._InpatientAdmission.Bed = bed;
        //}
        //let roomGroupObjectID = that.inpatientAdmissionRequestFormViewModel._InpatientAdmission["RoomGroup"];
        //if (roomGroupObjectID != null && (typeof roomGroupObjectID === 'string')) {
        //    let roomGroup = that.inpatientAdmissionRequestFormViewModel.ResRoomGroups.find(o => o.ObjectID.toString() === roomGroupObjectID.toString());
        //    that.inpatientAdmissionRequestFormViewModel._InpatientAdmission.RoomGroup = roomGroup;
        //}
        //let roomObjectID = that.inpatientAdmissionRequestFormViewModel._InpatientAdmission["Room"];
        //if (roomObjectID != null && (typeof roomObjectID === 'string')) {
        //    let room = that.inpatientAdmissionRequestFormViewModel.ResRooms.find(o => o.ObjectID.toString() === roomObjectID.toString());
        //    that.inpatientAdmissionRequestFormViewModel._InpatientAdmission.Room = room;
        //}
        let physicalStateClinicObjectID = that.inpatientAdmissionRequestFormViewModel._InpatientAdmission["PhysicalStateClinic"];
        if (physicalStateClinicObjectID != null && (typeof physicalStateClinicObjectID === 'string')) {
            let physicalStateClinic = that.inpatientAdmissionRequestFormViewModel.ResWards.find(o => o.ObjectID.toString() === physicalStateClinicObjectID.toString());
             if (physicalStateClinic) {
                that.inpatientAdmissionRequestFormViewModel._InpatientAdmission.PhysicalStateClinic = physicalStateClinic;
            }
        }
        let procedureDoctorObjectID = that.inpatientAdmissionRequestFormViewModel._InpatientAdmission["ProcedureDoctor"];
        if (procedureDoctorObjectID != null && (typeof procedureDoctorObjectID === 'string')) {
            let procedureDoctor = that.inpatientAdmissionRequestFormViewModel.ResUsers.find(o => o.ObjectID.toString() === procedureDoctorObjectID.toString());
             if (procedureDoctor) {
                that.inpatientAdmissionRequestFormViewModel._InpatientAdmission.ProcedureDoctor = procedureDoctor;
            }
        }
        let inpatientReasonObjectID = that.inpatientAdmissionRequestFormViewModel._InpatientAdmission["InpatientReason"];
        if (inpatientReasonObjectID != null && (typeof inpatientReasonObjectID === 'string')) {
            let inpatientReason = that.inpatientAdmissionRequestFormViewModel.InpatientReasonDefinitions.find(o => o.ObjectID.toString() === inpatientReasonObjectID.toString());
             if (inpatientReason) {
                that.inpatientAdmissionRequestFormViewModel._InpatientAdmission.InpatientReason = inpatientReason;
            }
        }
    }


    async ngOnInit()  {
        let that = this;
        await this.load(InpatientAdmissionRequestFormViewModel);
  
    }


    public onBedChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.Bed != event) {
                this._InpatientAdmission.Bed = event;
            }
        }
    }

    public onEmergencyChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.Emergency != event) {
                this._InpatientAdmission.Emergency = event;
            }
        }
    }

    public onEstimatedDischargeDateChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.EstimatedDischargeDate != event) {
                this._InpatientAdmission.EstimatedDischargeDate = event;
                if (this._InpatientAdmission.EstimatedInpatientDate != null && this._InpatientAdmission.EstimatedDischargeDate != null) {
                    this._InpatientAdmission.EstimatedInpatientDateCount = DateUtil.totalDays(this._InpatientAdmission.EstimatedInpatientDate, this._InpatientAdmission.EstimatedDischargeDate);
                }
            }
        }
    }

    public async onEstimatedInpatientDateChanged(event) {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.EstimatedInpatientDate != event) {
                this._InpatientAdmission.EstimatedInpatientDate = event;
                if (this._InpatientAdmission.EstimatedInpatientDate != null && this._InpatientAdmission.EstimatedDischargeDate != null) {
                    this._InpatientAdmission.EstimatedInpatientDateCount = DateUtil.totalDays(this._InpatientAdmission.EstimatedInpatientDate, this._InpatientAdmission.EstimatedDischargeDate);
                }

                if (this._InpatientAdmission.ProcedureDoctor != null) {
                    let a = await CommonService.PersonelIzinKontrol(this._InpatientAdmission.ProcedureDoctor.ObjectID, this._InpatientAdmission.EstimatedInpatientDate);
                    if (a) {
                        this.messageService.showInfo(this._InpatientAdmission.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                        setTimeout(() => {
                            this._InpatientAdmission.ProcedureDoctor = null;
                        }, 500);
    
                    }
                }
            }
        }
    }

    public onEstimatedInpatientDateCountChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.EstimatedInpatientDateCount != event) {
                this._InpatientAdmission.EstimatedInpatientDateCount = event;
                if (this._InpatientAdmission.EstimatedInpatientDate != null)
                    this._InpatientAdmission.EstimatedDischargeDate = this._InpatientAdmission.EstimatedInpatientDate.AddDays(parseInt(event));
            }
        }
    }
    public onHasAirborneContactIsolationChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.HasAirborneContactIsolation != event) {
                this._InpatientAdmission.HasAirborneContactIsolation = event;
            }
        }
    }

    public onHasContactIsolationChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.HasContactIsolation != event) {
                this._InpatientAdmission.HasContactIsolation = event;
            }
        }
    }

    public onHasDropletIsolationChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.HasDropletIsolation != event) {
                this._InpatientAdmission.HasDropletIsolation = event;
            }
        }
    }

    public onHasFallingRiskChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.HasFallingRisk != event) {
                this._InpatientAdmission.HasFallingRisk = event;
            }
        }
    }

    public onHasTightContactIsolationChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.HasTightContactIsolation != event) {
                this._InpatientAdmission.HasTightContactIsolation = event;
            }
        }
    }

    public oninpatientReasonChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.InpatientReason != event) {
                this._InpatientAdmission.InpatientReason = event;
            }
        }
    }

    public onMasterResourceChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.MasterResource != event) {
                this._InpatientAdmission.MasterResource = event;
            }
        }
    }

    public onNeedCompanionChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.NeedCompanion != event) {
                this._InpatientAdmission.NeedCompanion = event;
            }
        }
    }

    public onPhysicalStateClinicChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.PhysicalStateClinic != event) {
                this._InpatientAdmission.PhysicalStateClinic = event;
            }
        }
        this.PhysicalStateClinic_SelectedObjectChanged();
    }

    public async onProcedureDoctorChanged(event) {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.ProcedureDoctor != event) {
                this._InpatientAdmission.ProcedureDoctor = event;

                let a = await CommonService.PersonelIzinKontrol(this._InpatientAdmission.ProcedureDoctor.ObjectID, this._InpatientAdmission.EstimatedInpatientDate);
                if (a) {
                    this.messageService.showInfo(this._InpatientAdmission.ProcedureDoctor.Name + " isimli doktor izinli olduğu için seçim yapamazsınız.");
                    setTimeout(() => {
                        this._InpatientAdmission.ProcedureDoctor  = null;
                    }, 500);
    
                }
            }
        } 
    }

    public onReasonForInpatientAdmissionChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.ReasonForInpatientAdmission != event) {
                this._InpatientAdmission.ReasonForInpatientAdmission = event;
            }
        }
    }

    public onRequestDateChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.RequestDate != event) {
                this._InpatientAdmission.RequestDate = event;
            }
        }
    }

    public onReturnToRequestReasonChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.ReturnToRequestReason != event) {
                this._InpatientAdmission.ReturnToRequestReason = event;
            }
        }
    }

    public onRoomChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.Room != event) {
                this._InpatientAdmission.Room = event;
            }
        }
        this.Room_SelectedObjectChanged();
    }

    public onRoomGroupChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.RoomGroup != event) {
                this._InpatientAdmission.RoomGroup = event;
            }
        }
        this.RoomGroup_SelectedObjectChanged();
    }

    public onTreatmentClinicChanged(event): void {
        if (event != null) {
            if (this._InpatientAdmission != null && this._InpatientAdmission.TreatmentClinic != event) {
                this._InpatientAdmission.TreatmentClinic = event;
            }
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.HasFallingRisk, "Value", this.__ttObject, "HasFallingRisk");
        redirectProperty(this.HasDropletIsolation, "Value", this.__ttObject, "HasDropletIsolation");
        redirectProperty(this.HasAirborneContactIsolation, "Value", this.__ttObject, "HasAirborneContactIsolation");
        redirectProperty(this.HasContactIsolation, "Value", this.__ttObject, "HasContactIsolation");
        redirectProperty(this.HasTightContactIsolation, "Value", this.__ttObject, "HasTightContactIsolation");
        redirectProperty(this.ReasonForInpatientAdmission, "Text", this.__ttObject, "ReasonForInpatientAdmission");
        redirectProperty(this.ReturnToRequestReason, "Rtf", this.__ttObject, "ReturnToRequestReason");
        redirectProperty(this.RequestDate, "Value", this.__ttObject, "RequestDate");
        redirectProperty(this.EstimatedInpatientDate, "Value", this.__ttObject, "EstimatedInpatientDate");
        redirectProperty(this.EstimatedDischargeDate, "Value", this.__ttObject, "EstimatedDischargeDate");
        redirectProperty(this.EstimatedInpatientDateCount, "Value", this.__ttObject, "EstimatedInpatientDateCount");
        redirectProperty(this.Emergency, "Value", this.__ttObject, "Emergency");
        redirectProperty(this.NeedCompanion, "Value", this.__ttObject, "NeedCompanion");
    }

    public initFormControls(): void {
        this.ReasonForInpatientAdmission = new TTVisual.TTTextBox();
        this.ReasonForInpatientAdmission.Multiline = true;
        this.ReasonForInpatientAdmission.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ReasonForInpatientAdmission.Name = "ReasonForInpatientAdmission";
        this.ReasonForInpatientAdmission.TabIndex = 15;

        //this.BaseNumberOfEmptyBeds = new TTVisual.TTTextBox();
        //this.BaseNumberOfEmptyBeds.BackColor = "#F0F0F0";
        //this.BaseNumberOfEmptyBeds.ReadOnly = true;
        //this.BaseNumberOfEmptyBeds.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        //this.BaseNumberOfEmptyBeds.Name = "BaseNumberOfEmptyBeds";
        //this.BaseNumberOfEmptyBeds.TabIndex = 2;

        this.EstimatedInpatientDateCount = new TTVisual.TTTextBox();
        this.EstimatedInpatientDateCount.Name = "EstimatedInpatientDateCount";
        this.EstimatedInpatientDateCount.TabIndex = 212;
        this.EstimatedInpatientDateCount.InputFormat = InputFormat.Normal; // Daha sonra Numerice çevrilmeli

        this.NeedCompanion = new TTVisual.TTCheckBox();
        this.NeedCompanion.Value = false;
        this.NeedCompanion.Title = i18n("M20986", "Refakat Gerektirir");
        this.NeedCompanion.Name = "NeedCompanion";
        this.NeedCompanion.TabIndex = 17477;

        this.HasAirborneContactIsolation = new TTVisual.TTCheckBox();
        this.HasAirborneContactIsolation.Value = false;
        this.HasAirborneContactIsolation.Title = i18n("M22030", "Solunum İzolasyonu ");
        this.HasAirborneContactIsolation.Name = "HasAirborneContactIsolation";
        this.HasAirborneContactIsolation.TabIndex = 17476;

        this.HasContactIsolation = new TTVisual.TTCheckBox();
        this.HasContactIsolation.Value = false;
        this.HasContactIsolation.Title = i18n("M23155", "Temas İzolasyonu  ");
        this.HasContactIsolation.Name = "HasContactIsolation";
        this.HasContactIsolation.TabIndex = 17475;

        this.HasDropletIsolation = new TTVisual.TTCheckBox();
        this.HasDropletIsolation.Value = false;
        this.HasDropletIsolation.Title = i18n("M12487", "Damlacık İzolasyonu  ");
        this.HasDropletIsolation.Name = "HasDropletIsolation";
        this.HasDropletIsolation.TabIndex = 17474;

        this.HasFallingRisk = new TTVisual.TTCheckBox();
        this.HasFallingRisk.Value = false;
        this.HasFallingRisk.Title = i18n("M13392", "Düşme Riskli Hasta");
        this.HasFallingRisk.Name = "HasFallingRisk";
        this.HasFallingRisk.TabIndex = 17473;

        this.HasTightContactIsolation = new TTVisual.TTCheckBox();
        this.HasTightContactIsolation.Value = false;
        this.HasTightContactIsolation.Title = i18n("M21800", "Sıkı Temas İzolasyonu  ");
        this.HasTightContactIsolation.Name = "HasTightContactIsolation";
        this.HasTightContactIsolation.TabIndex = 17472;

        this.labelEstimatedInpatientDate = new TTVisual.TTLabel();
        this.labelEstimatedInpatientDate.Text = i18n("M22605", "Tahmini Yatış Tarihi");
        this.labelEstimatedInpatientDate.Name = "labelEstimatedInpatientDate";
        this.labelEstimatedInpatientDate.TabIndex = 17471;

        this.EstimatedInpatientDate = new TTVisual.TTDateTimePicker();
        this.EstimatedInpatientDate.Format = DateTimePickerFormat.Long;
        this.EstimatedInpatientDate.Name = "EstimatedInpatientDate";
        this.EstimatedInpatientDate.TabIndex = 17470;
        this.EstimatedInpatientDate.Format = DateTimePickerFormat.Short;

        this.MasterResource = new TTVisual.TTObjectListBox();
        this.MasterResource.ListDefName = "ResourceListDefinition";
        this.MasterResource.Name = "MasterResource";
        this.MasterResource.TabIndex = 17468;
        this.MasterResource.Visible = false;

        //this.btnEmptyBedsInClinic = new TTVisual.TTButton();
        //this.btnEmptyBedsInClinic.Text = "Klinikteki Boş Yatak Listesi";
        //this.btnEmptyBedsInClinic.Name = "btnEmptyBedsInClinic";
        //this.btnEmptyBedsInClinic.TabIndex = 9;

        this.Emergency = new TTVisual.TTCheckBox();
        this.Emergency.Value = false;
        this.Emergency.Title = "Acil";
        this.Emergency.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Emergency.Name = "Emergency";
        this.Emergency.TabIndex = 3;

        this.LabelDateTime = new TTVisual.TTLabel();
        this.LabelDateTime.Text = i18n("M16650", "İstek Tarihi");
        this.LabelDateTime.BackColor = "#DCDCDC";
        this.LabelDateTime.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.LabelDateTime.ForeColor = "#000000";
        this.LabelDateTime.Name = "LabelDateTime";
        this.LabelDateTime.TabIndex = 26;

        this.RequestDate = new TTVisual.TTDateTimePicker();
        this.RequestDate.BackColor = "#F0F0F0";
        this.RequestDate.CustomFormat = "";
        this.RequestDate.Format = DateTimePickerFormat.Short;
        this.RequestDate.Enabled = false;
        this.RequestDate.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.RequestDate.Name = "RequestDate";
        this.RequestDate.TabIndex = 5;


        this.TreatmentClinic = new TTVisual.TTObjectListBox();
        this.TreatmentClinic.Required = true;
        this.TreatmentClinic.ListDefName = "ClinicExceptIntensiveCareListDefinition";
        this.TreatmentClinic.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.TreatmentClinic.Name = "TreatmentClinic";
        this.TreatmentClinic.TabIndex = 7;

        //this.labelBed = new TTVisual.TTLabel();
        //this.labelBed.Text = "Yatak";
        //this.labelBed.BackColor = "#DCDCDC";
        //this.labelBed.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        //this.labelBed.ForeColor = "#000000";
        //this.labelBed.Name = "labelBed";
        //this.labelBed.TabIndex = 17;

        //this.labelRoomGroup = new TTVisual.TTLabel();
        //this.labelRoomGroup.Text = "Oda Grubu";
        //this.labelRoomGroup.BackColor = "#DCDCDC";
        //this.labelRoomGroup.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        //this.labelRoomGroup.ForeColor = "#000000";
        //this.labelRoomGroup.Name = "labelRoomGroup";
        //this.labelRoomGroup.TabIndex = 21;

        //this.Bed = new TTVisual.TTObjectListBox();
        //this.Bed.Required = true;
        //this.Bed.LinkedControlName = "Room";
        //this.Bed.ForceLinkedParentSelection = true;
        //this.Bed.ListFilterExpression = "UsedByBedProcedure is null";
        //this.Bed.ListDefName = "BedListDefinition";
        //this.Bed.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        //this.Bed.Name = "Bed";
        //this.Bed.TabIndex = 12;

        this.labelTreatmentClinic = new TTVisual.TTLabel();
        this.labelTreatmentClinic.Text = i18n("M22991", "Tedavi Göreceği  Klinik/ Servis");
        this.labelTreatmentClinic.BackColor = "#DCDCDC";
        this.labelTreatmentClinic.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelTreatmentClinic.ForeColor = "#000000";
        this.labelTreatmentClinic.Name = "labelTreatmentClinic";
        this.labelTreatmentClinic.TabIndex = 25;

        //this.labelRoom = new TTVisual.TTLabel();
        //this.labelRoom.Text = "Oda";
        //this.labelRoom.BackColor = "#DCDCDC";
        //this.labelRoom.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        //this.labelRoom.ForeColor = "#000000";
        //this.labelRoom.Name = "labelRoom";
        //this.labelRoom.TabIndex = 19;

        //this.RoomGroup = new TTVisual.TTObjectListBox();
        //this.RoomGroup.LinkedControlName = "PhysicalStateClinic";
        //this.RoomGroup.ForceLinkedParentSelection = true;
        //this.RoomGroup.ListDefName = "RoomGroupListDefinition";
        //this.RoomGroup.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        //this.RoomGroup.Name = "RoomGroup";
        //this.RoomGroup.TabIndex = 10;

        this.labelReasonForInpatientAdmission = new TTVisual.TTLabel();
        this.labelReasonForInpatientAdmission.Text = i18n("M24439", "Yatış Sebebi");
        this.labelReasonForInpatientAdmission.BackColor = "#DCDCDC";
        this.labelReasonForInpatientAdmission.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelReasonForInpatientAdmission.ForeColor = "#000000";
        this.labelReasonForInpatientAdmission.Name = "labelReasonForInpatientAdmission";
        this.labelReasonForInpatientAdmission.TabIndex = 9;

        //this.labelNumberOfEmptyBeds = new TTVisual.TTLabel();
        //this.labelNumberOfEmptyBeds.Text = "Boş Yatak Sayısı";
        //this.labelNumberOfEmptyBeds.BackColor = "#DCDCDC";
        //this.labelNumberOfEmptyBeds.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        //this.labelNumberOfEmptyBeds.ForeColor = "#000000";
        //this.labelNumberOfEmptyBeds.Name = "labelNumberOfEmptyBeds";
        //this.labelNumberOfEmptyBeds.TabIndex = 3;

        //this.Room = new TTVisual.TTObjectListBox();
        //this.Room.LinkedControlName = "RoomGroup";
        //this.Room.ForceLinkedParentSelection = true;
        //this.Room.ListDefName = "RoomListDefinition";
        //this.Room.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        //this.Room.Name = "Room";
        //this.Room.TabIndex = 13;

        this.ReturnToRequestReason = new TTVisual.TTRichTextBoxControl();
        this.ReturnToRequestReason.Iconized = true;
        this.ReturnToRequestReason.BackColor = "#DCDCDC";
        this.ReturnToRequestReason.Name = "ReturnToRequestReason";
        this.ReturnToRequestReason.TabIndex = 4;

        this.labelReturnToRequestReason = new TTVisual.TTLabel();
        this.labelReturnToRequestReason.Text = i18n("M15625", "Hekime İade Sebebi");
        this.labelReturnToRequestReason.BackColor = "#000000";
        this.labelReturnToRequestReason.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelReturnToRequestReason.ForeColor = "#000000";
        this.labelReturnToRequestReason.Name = "labelReturnToRequestReason";
        this.labelReturnToRequestReason.TabIndex = 6;

        //this.PhysicalStateClinic = new TTVisual.TTObjectListBox();
        //this.PhysicalStateClinic.Required = true;
        //this.PhysicalStateClinic.ListDefName = "WardExceptIntensiveCareListDefinition";
        //this.PhysicalStateClinic.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        //this.PhysicalStateClinic.Name = "PhysicalStateClinic";
        //this.PhysicalStateClinic.TabIndex = 8;

        //this.labelPhysicalStateClinic = new TTVisual.TTLabel();
        //this.labelPhysicalStateClinic.Text = "Yattığı  Klinik/ Servis";
        //this.labelPhysicalStateClinic.BackColor = "#DCDCDC";
        //this.labelPhysicalStateClinic.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        //this.labelPhysicalStateClinic.ForeColor = "#000000";
        //this.labelPhysicalStateClinic.Name = "labelPhysicalStateClinic";
        //this.labelPhysicalStateClinic.TabIndex = 25;

        this.labelProcedureDoctor = new TTVisual.TTLabel();
        this.labelProcedureDoctor.Text = i18n("M16596", "İsteği  Yapan Tabip");
        this.labelProcedureDoctor.BackColor = "#DCDCDC";
        this.labelProcedureDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelProcedureDoctor.ForeColor = "#000000";
        this.labelProcedureDoctor.Name = "labelProcedureDoctor";
        this.labelProcedureDoctor.TabIndex = 36;

        this.ProcedureDoctor = new TTVisual.TTObjectListBox();
        this.ProcedureDoctor.Required = true;
        this.ProcedureDoctor.LinkedControlName = "MasterResource";
        this.ProcedureDoctor.LinkedRelationPath = "USERRESOURCES.RESOURCE";
        this.ProcedureDoctor.ListDefName = "SpecialistDoctorListDefinition";
        this.ProcedureDoctor.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ProcedureDoctor.Name = "ProcedureDoctor";
        this.ProcedureDoctor.TabIndex = 6;

        this.inpatientReason = new TTVisual.TTObjectListBox();
        this.inpatientReason.ListDefName = "InpatientReasonListDefinition";
        this.inpatientReason.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.inpatientReason.Name = "inpatientReason";
        this.inpatientReason.ReadOnly = false;
        this.inpatientReason.TabIndex = 14;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = i18n("M24443", "Yatış Sebebi(Metin)");
        this.ttlabel1.BackColor = "#DCDCDC";
        this.ttlabel1.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.ForeColor = "#000000";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 9;

        this.lblb = new TTVisual.TTLabel();
        this.lblb.Text = "Bina";
        this.lblb.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.lblb.Name = "lblb";
        this.lblb.TabIndex = 149;

        this.Building = new TTVisual.TTObjectListBox();
        this.Building.ReadOnly = true;
        this.Building.ListDefName = "BuildinglistDefinition";
        this.Building.Font = "Name=Microsoft Sans Serif, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.Building.Name = "Building";
        this.Building.TabIndex = 152;

        this.labelEstimatedDischargeDate = new TTVisual.TTLabel();
        this.labelEstimatedDischargeDate.Text = i18n("M22600", "Tahmini Taburcu Tarihi");
        this.labelEstimatedDischargeDate.Name = "labelEstimatedDischargeDate";
        this.labelEstimatedDischargeDate.TabIndex = 14;

        this.EstimatedDischargeDate = new TTVisual.TTDateTimePicker();
        this.EstimatedDischargeDate.Format = DateTimePickerFormat.Short;
        this.EstimatedDischargeDate.Name = "EstimatedDischargeDate";
        this.EstimatedDischargeDate.TabIndex = 13;


        this.Controls = [this.ReasonForInpatientAdmission, this.BaseNumberOfEmptyBeds, this.EstimatedInpatientDateCount,
            this.NeedCompanion, this.HasAirborneContactIsolation, this.HasContactIsolation, this.HasDropletIsolation,
            this.HasFallingRisk, this.HasTightContactIsolation, this.labelEstimatedInpatientDate,
            this.EstimatedInpatientDate, this.MasterResource, this.Emergency,
            this.LabelDateTime, this.RequestDate, this.TreatmentClinic,
             this.labelTreatmentClinic,
            this.labelReasonForInpatientAdmission,
            this.ReturnToRequestReason, this.labelReturnToRequestReason,
             this.labelProcedureDoctor, this.ProcedureDoctor, this.inpatientReason,
            this.ttlabel1, this.lblb, this.Building, this.labelEstimatedDischargeDate,
            this.EstimatedDischargeDate, this.EstimatedInpatientDateCount];
        // this.btnEmptyBedsInClinic,this.Bed, this.labelRoom,this.RoomGroup,this.labelBed, this.labelRoomGroup,this.labelNumberOfEmptyBeds, this.Room,this.PhysicalStateClinic,this.labelPhysicalStateClinic,

    }

    printReport() {
        const objectIdParam = new GuidParam(this.inpatientAdmissionRequestFormViewModel._InpatientAdmission.ObjectID);
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReport('InpatientAdmissionInfoByTreatmentClinic', reportParameters);
    }

    protected async AfterContextSavedScript(transDef: TTObjectStateTransitionDef): Promise<void> {
        super.AfterContextSavedScript(transDef);
        this.printReport();
    }
}
