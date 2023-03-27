//$2685F2B0
import { Component, ViewChild, OnInit, ApplicationRef } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { SafeSurgeryCheckListFormViewModel } from './SafeSurgeryCheckListFormViewModel';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import { Util } from 'Fw/Components/Util';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { SafeSurgeryCheckList } from 'NebulaClient/Model/AtlasClientModel';
import { ResUser } from 'NebulaClient/Model/AtlasClientModel';

import { ServiceLocator } from 'app/Fw/Services/ServiceLocator';

export enum ChecklistTabs {
    BeforeLeavingClinicTab = 1,
    BeforeAnesthesiaTab,
    BeforeSurgicalIncisionTab,
    BeforeLeavingSurgeryTab,
}

@Component({
    selector: 'SafeSurgeryCheckListForm',
    templateUrl: './SafeSurgeryCheckListForm.html',
    providers: [MessageService]
})
export class SafeSurgeryCheckListForm extends TTVisual.TTForm implements OnInit {
    AnesthesiaChecklistCompleted: TTVisual.ITTCheckBox;
    Anesthesiologist: TTVisual.ITTObjectListBox;
    AnesthetistSuggestions: TTVisual.ITTTextBox;
    AppliedProphylacticAntibiotic: TTVisual.ITTCheckBox;
    BeforeAnesthesia: TTVisual.ITTTabPage;
    BeforeLeavingClinic: TTVisual.ITTTabPage;
    BeforeLeavingSurgery: TTVisual.ITTTabPage;
    BeforeSurgicalIncision: TTVisual.ITTTabPage;
    CatheterizationRequired: TTVisual.ITTCheckBox;
    ClinicalNurse: TTVisual.ITTObjectListBox;
    ConfirmedAfterSurgeryClinic: TTVisual.ITTCheckBox;
    ConfirmedPatientVerbally: TTVisual.ITTCheckBox;
    ConfirmedSurgeryAreaVerbally: TTVisual.ITTCheckBox;
    ConfirmedSurgeryVerbally: TTVisual.ITTCheckBox;
    ConsentVerifiedByPatient: TTVisual.ITTCheckBox;
    HasAnticoagulantUsage: TTVisual.ITTCheckBox;
    HasBloodLossRisk: TTVisual.ITTCheckBox;
    HasImagingDevice: TTVisual.ITTCheckBox;
    HasSignInSurgeryArea: TTVisual.ITTCheckBox;
    IsPatientClothesReady: TTVisual.ITTCheckBox;
    IsPatientHungry: TTVisual.ITTCheckBox;
    LabAndRadioTestsAvailable: TTVisual.ITTCheckBox;
    labelAnesthesiologist: TTVisual.ITTLabel;
    labelAnesthetistSuggestions: TTVisual.ITTLabel;
    labelClinicalNurse: TTVisual.ITTLabel;
    labelMakeupProstValItemDescription: TTVisual.ITTLabel;
    labelOperatingRoomNurse: TTVisual.ITTLabel;
    labelOtherSpecialActionDescription: TTVisual.ITTLabel;
    labelPatientAllergyDescription: TTVisual.ITTLabel;
    labelPatientClothesDescription: TTVisual.ITTLabel;
    labelPatientHungerDescription: TTVisual.ITTLabel;
    labelSurgeonSuggestions: TTVisual.ITTLabel;
    labelSurgeryAreaShavedDescription: TTVisual.ITTLabel;
    labelSurgeryDoctor: TTVisual.ITTLabel;
    LavmanRequired: TTVisual.ITTCheckBox;
    MakeupProsthesisValuableItem: TTVisual.ITTCheckBox;
    MakeupProstValItemDescription: TTVisual.ITTTextBox;
    MaterialPreparationChecked: TTVisual.ITTCheckBox;
    NecessaryBloodSugarControl: TTVisual.ITTCheckBox;
    NecessaryDeepVeinThrombosis: TTVisual.ITTCheckBox;
    OperatingRoomNurse: TTVisual.ITTObjectListBox;
    OtherSpecialActionDescription: TTVisual.ITTTextBox;
    OtherSpecialActionRequired: TTVisual.ITTCheckBox;
    PatientAllergyDescription: TTVisual.ITTTextBox;
    PatientClothesDescription: TTVisual.ITTTextBox;
    PatientConsentChecked: TTVisual.ITTCheckBox;
    PatientHasAnAllergy: TTVisual.ITTCheckBox;
    PatientHungerDescription: TTVisual.ITTTextBox;
    PatientIDInfoVerified: TTVisual.ITTCheckBox;
    PatientIDVerifiedByPatient: TTVisual.ITTCheckBox;
    PatientNameOnSampleLabel: TTVisual.ITTCheckBox;
    PatientSurgeryAreaVerified: TTVisual.ITTCheckBox;
    PatientSurgeryVerified: TTVisual.ITTCheckBox;
    PulseOximeterWorksOut: TTVisual.ITTCheckBox;
    ReadyUsedMaterials: TTVisual.ITTCheckBox;
    ReviewedEstimatedSurgeryTime: TTVisual.ITTCheckBox;
    ReviewedExpectedBloodLoss: TTVisual.ITTCheckBox;
    ReviewedPatientPosition: TTVisual.ITTCheckBox;
    ReviewedPossibAnesthesiaRisk: TTVisual.ITTCheckBox;
    ReviewedUnexpectedEvents: TTVisual.ITTCheckBox;
    SampleRegionOnSampleLabel: TTVisual.ITTCheckBox;
    SugeryAreaVerifiedByPatient: TTVisual.ITTCheckBox;
    SuitableMaterialSterilization: TTVisual.ITTCheckBox;
    SurgeonSuggestions: TTVisual.ITTTextBox;
    SurgeryAreaShaved: TTVisual.ITTCheckBox;
    SurgeryAreaShavedDescription: TTVisual.ITTTextBox;
    SurgeryDoctor: TTVisual.ITTObjectListBox;
    SurgeryVerifiedByPatient: TTVisual.ITTCheckBox;
    TeamMemberInformedVerbally: TTVisual.ITTCheckBox;
    TeamMembersIntroThemselves: TTVisual.ITTCheckBox;
    ToolSpongeNeedleCountsDone: TTVisual.ITTCheckBox;
    TreatmentProtocolRequired: TTVisual.ITTCheckBox;
    ttlabel1: TTVisual.ITTLabel;
    ttlabel10: TTVisual.ITTLabel;
    ttlabel11: TTVisual.ITTLabel;
    ttlabel12: TTVisual.ITTLabel;
    ttlabel13: TTVisual.ITTLabel;
    ttlabel14: TTVisual.ITTLabel;
    ttlabel15: TTVisual.ITTLabel;
    ttlabel16: TTVisual.ITTLabel;
    ttlabel17: TTVisual.ITTLabel;
    ttlabel18: TTVisual.ITTLabel;
    ttlabel19: TTVisual.ITTLabel;
    ttlabel2: TTVisual.ITTLabel;
    ttlabel20: TTVisual.ITTLabel;
    ttlabel21: TTVisual.ITTLabel;
    ttlabel22: TTVisual.ITTLabel;
    ttlabel23: TTVisual.ITTLabel;
    ttlabel24: TTVisual.ITTLabel;
    ttlabel25: TTVisual.ITTLabel;
    ttlabel26: TTVisual.ITTLabel;
    ttlabel3: TTVisual.ITTLabel;
    ttlabel30: TTVisual.ITTLabel;
    ttlabel31: TTVisual.ITTLabel;
    ttlabel32: TTVisual.ITTLabel;
    ttlabel33: TTVisual.ITTLabel;
    ttlabel34: TTVisual.ITTLabel;
    ttlabel4: TTVisual.ITTLabel;
    ttlabel5: TTVisual.ITTLabel;
    ttlabel6: TTVisual.ITTLabel;
    ttlabel7: TTVisual.ITTLabel;
    ttlabel8: TTVisual.ITTLabel;
    ttlabel9: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    VaricoseBandageRequired: TTVisual.ITTCheckBox;

    sampleRegion: number;

    radioGroupItems = [
        { text: "Evet", value: true },
        { text: "Hayır", value: false }

    ];

    radioItemsForSurgerySign = [
        { text: "Evet", value: true },
        { text: "İşaretleme Uygulanamaz", value: false }

    ];

    radioItems = [
        { text: "Var", value: true },
        { text: "Yok", value: false }

    ];

    radioItemsForBloodRisk = [
        { text: "Yok", value: false },
        { text: "Var; uygun damar yolu erişimi ve sıvı planlandı.", value: true }

    ];

    radioForProphylacticAntibiotic = [
        { text: "Kesiden önceki son 60 dakika içerisinde uygulandı", value: true },
        { text: "Kullanılamaz", value: false }

    ];

    radioForSampleLabel = [
        { text: "Hastanın adı doğru yazılı", value: 1 },
        { text: "Numunenin alındığı bölge yazılı", value: 2 }

    ];

    radioForTool = [
        { text: "Evet / Tam", value: true },
        { text: "Hayır", value: false }

    ];
    selectedTab: ChecklistTabs = ChecklistTabs.BeforeLeavingClinicTab;


    public safeSurgeryCheckListFormViewModel: SafeSurgeryCheckListFormViewModel = new SafeSurgeryCheckListFormViewModel();
    public get _SafeSurgeryCheckList(): SafeSurgeryCheckList {
        return this._TTObject as SafeSurgeryCheckList;
    }
    private SafeSurgeryCheckListForm_DocumentUrl: string = '/api/SafeSurgeryCheckListService/SafeSurgeryCheckListForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super('SAFESURGERYCHECKLIST', 'SafeSurgeryCheckListForm');
        this._DocumentServiceUrl = this.SafeSurgeryCheckListForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }


    // ***** Method declarations start *****


    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new SafeSurgeryCheckList();
        this.safeSurgeryCheckListFormViewModel = new SafeSurgeryCheckListFormViewModel();
        this._ViewModel = this.safeSurgeryCheckListFormViewModel;
        this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList = this._TTObject as SafeSurgeryCheckList;
        this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.ClinicalNurse = new ResUser();
        this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.Anesthesiologist = new ResUser();
        this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.SurgeryDoctor = new ResUser();
        this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.OperatingRoomNurse = new ResUser();

    }

    protected loadViewModel() {
        let that = this;
        that.safeSurgeryCheckListFormViewModel = this._ViewModel as SafeSurgeryCheckListFormViewModel;
        that._TTObject = this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList;
        if (this.safeSurgeryCheckListFormViewModel == null)
            this.safeSurgeryCheckListFormViewModel = new SafeSurgeryCheckListFormViewModel();
        if (this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList == null)
            this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList = new SafeSurgeryCheckList();
        let clinicalNurseObjectID = that.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList["ClinicalNurse"];
        if (clinicalNurseObjectID != null && (typeof clinicalNurseObjectID === "string")) {
            let clinicalNurse = that.safeSurgeryCheckListFormViewModel.ResUsers.find(o => o.ObjectID.toString() === clinicalNurseObjectID.toString());
            if (clinicalNurse) {
                that.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.ClinicalNurse = clinicalNurse;
            }
        }


        let anesthesiologistObjectID = that.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList["Anesthesiologist"];
        if (anesthesiologistObjectID != null && (typeof anesthesiologistObjectID === "string")) {
            let anesthesiologist = that.safeSurgeryCheckListFormViewModel.ResUsers.find(o => o.ObjectID.toString() === anesthesiologistObjectID.toString());
            if (anesthesiologist) {
                that.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.Anesthesiologist = anesthesiologist;
            }
        }


        let surgeryDoctorObjectID = that.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList["SurgeryDoctor"];
        if (surgeryDoctorObjectID != null && (typeof surgeryDoctorObjectID === "string")) {
            let surgeryDoctor = that.safeSurgeryCheckListFormViewModel.ResUsers.find(o => o.ObjectID.toString() === surgeryDoctorObjectID.toString());
            if (surgeryDoctor) {
                that.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.SurgeryDoctor = surgeryDoctor;
            }
        }


        let operatingRoomNurseObjectID = that.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList["OperatingRoomNurse"];
        if (operatingRoomNurseObjectID != null && (typeof operatingRoomNurseObjectID === "string")) {
            let operatingRoomNurse = that.safeSurgeryCheckListFormViewModel.ResUsers.find(o => o.ObjectID.toString() === operatingRoomNurseObjectID.toString());
            if (operatingRoomNurse) {
                that.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.OperatingRoomNurse = operatingRoomNurse;
            }
        }

       

        if (this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.CurrentStateDefID == SafeSurgeryCheckList.SafeSurgeryCheckListStates.BeforeLeavingClinic) {
            this.controlAnesthesia = false;
            this.controlIncision = false;
            this.controlLeaveSurgery = false;
        }
        else if (this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.CurrentStateDefID == SafeSurgeryCheckList.SafeSurgeryCheckListStates.BeforeAnesthesia) {
                this.controlAnesthesia = true;
        }
        else if (this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.CurrentStateDefID == SafeSurgeryCheckList.SafeSurgeryCheckListStates.BeforeSurgicalIncision) {
                this.controlIncision = true;
                this.controlAnesthesia = true;
        }
        else if (this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.CurrentStateDefID == SafeSurgeryCheckList.SafeSurgeryCheckListStates.BeforeLeavingSurgery) {
            this.controlLeaveSurgery = true;
            this.controlIncision = true;
            this.controlAnesthesia = true;
        }
        else if(this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.CurrentStateDefID == SafeSurgeryCheckList.SafeSurgeryCheckListStates.Completed){
            this.controlLeaveSurgery = true;
            this.controlIncision = true;
            this.controlAnesthesia = true; 
        }

    }

    async ngOnInit() {
        await this.load();
    }

    public onAnesthesiaChecklistCompletedChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.AnesthesiaChecklistCompleted != event) {
            this._SafeSurgeryCheckList.AnesthesiaChecklistCompleted = event;
        }
    }

    public onAnesthesiologistChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.Anesthesiologist != event) {
            this._SafeSurgeryCheckList.Anesthesiologist = event;
        }
    }

    public onAnesthetistSuggestionsChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.AnesthetistSuggestions != event) {
            this._SafeSurgeryCheckList.AnesthetistSuggestions = event;
        }
    }

    public onAppliedProphylacticAntibioticChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.AppliedProphylacticAntibiotic != event) {
            this._SafeSurgeryCheckList.AppliedProphylacticAntibiotic = event;
        }
    }

    public onCatheterizationRequiredChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.CatheterizationRequired != event) {
            this._SafeSurgeryCheckList.CatheterizationRequired = event;
        }
    }

    public onClinicalNurseChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.ClinicalNurse != event) {
            this._SafeSurgeryCheckList.ClinicalNurse = event;
        }
    }

    public onConfirmedAfterSurgeryClinicChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.ConfirmedAfterSurgeryClinic != event) {
            this._SafeSurgeryCheckList.ConfirmedAfterSurgeryClinic = event;
        }
    }

    public onConfirmedPatientVerballyChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.ConfirmedPatientVerbally != event) {
            this._SafeSurgeryCheckList.ConfirmedPatientVerbally = event;
        }
    }

    public onConfirmedSurgeryAreaVerballyChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.ConfirmedSurgeryAreaVerbally != event) {
            this._SafeSurgeryCheckList.ConfirmedSurgeryAreaVerbally = event;
        }
    }

    public onConfirmedSurgeryVerballyChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.ConfirmedSurgeryVerbally != event) {
            this._SafeSurgeryCheckList.ConfirmedSurgeryVerbally = event;
        }
    }

    public onConsentVerifiedByPatientChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.ConsentVerifiedByPatient != event) {
            this._SafeSurgeryCheckList.ConsentVerifiedByPatient = event;
        }
    }

    public onHasAnticoagulantUsageChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.HasAnticoagulantUsage != event) {
            this._SafeSurgeryCheckList.HasAnticoagulantUsage = event;
        }
    }

    public onHasBloodLossRiskChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.HasBloodLossRisk != event) {
            this._SafeSurgeryCheckList.HasBloodLossRisk = event;
        }
    }

    public onHasImagingDeviceChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.HasImagingDevice != event) {
            this._SafeSurgeryCheckList.HasImagingDevice = event;
        }
    }

    public onHasSignInSurgeryAreaChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.HasSignInSurgeryArea != event) {
            this._SafeSurgeryCheckList.HasSignInSurgeryArea = event;
        }
    }

    public onIsPatientClothesReadyChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.IsPatientClothesReady != event) {
            this._SafeSurgeryCheckList.IsPatientClothesReady = event;
        }
    }

    public onIsPatientHungryChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.IsPatientHungry != event) {
            this._SafeSurgeryCheckList.IsPatientHungry = event;
        }
    }

    public onLabAndRadioTestsAvailableChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.LabAndRadioTestsAvailable != event) {
            this._SafeSurgeryCheckList.LabAndRadioTestsAvailable = event;
        }
    }

    public onLavmanRequiredChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.LavmanRequired != event) {
            this._SafeSurgeryCheckList.LavmanRequired = event;
        }
    }

    public onMakeupProsthesisValuableItemChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.MakeupProsthesisValuableItem != event) {
            this._SafeSurgeryCheckList.MakeupProsthesisValuableItem = event;
        }
    }

    public onMakeupProstValItemDescriptionChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.MakeupProstValItemDescription != event) {
            this._SafeSurgeryCheckList.MakeupProstValItemDescription = event;
        }
    }

    public onMaterialPreparationCheckedChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.MaterialPreparationChecked != event) {
            this._SafeSurgeryCheckList.MaterialPreparationChecked = event;
        }
    }

    public onNecessaryBloodSugarControlChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.NecessaryBloodSugarControl != event) {
            this._SafeSurgeryCheckList.NecessaryBloodSugarControl = event;
        }
    }

    public onNecessaryDeepVeinThrombosisChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.NecessaryDeepVeinThrombosis != event) {
            this._SafeSurgeryCheckList.NecessaryDeepVeinThrombosis = event;
        }
    }

    public onOperatingRoomNurseChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.OperatingRoomNurse != event) {
            this._SafeSurgeryCheckList.OperatingRoomNurse = event;
        }
    }

    public onOtherSpecialActionDescriptionChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.OtherSpecialActionDescription != event) {
            this._SafeSurgeryCheckList.OtherSpecialActionDescription = event;
        }
    }

    public onOtherSpecialActionRequiredChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.OtherSpecialActionRequired != event) {
            this._SafeSurgeryCheckList.OtherSpecialActionRequired = event;
        }
    }

    public onPatientAllergyDescriptionChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.PatientAllergyDescription != event) {
            this._SafeSurgeryCheckList.PatientAllergyDescription = event;
        }
    }

    public onPatientClothesDescriptionChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.PatientClothesDescription != event) {
            this._SafeSurgeryCheckList.PatientClothesDescription = event;
        }
    }

    public onPatientConsentCheckedChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.PatientConsentChecked != event) {
            this._SafeSurgeryCheckList.PatientConsentChecked = event;
        }
    }

    public onPatientHasAnAllergyChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.PatientHasAnAllergy != event) {
            this._SafeSurgeryCheckList.PatientHasAnAllergy = event;
        }
    }

    public onPatientHungerDescriptionChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.PatientHungerDescription != event) {
            this._SafeSurgeryCheckList.PatientHungerDescription = event;
        }
    }

    public onPatientIDInfoVerifiedChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.PatientIDInfoVerified != event) {
            this._SafeSurgeryCheckList.PatientIDInfoVerified = event;
        }
    }

    public onPatientIDVerifiedByPatientChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.PatientIDVerifiedByPatient != event) {
            this._SafeSurgeryCheckList.PatientIDVerifiedByPatient = event;
        }
    }

    public onPatientNameOnSampleLabelChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.PatientNameOnSampleLabel != event) {
            this._SafeSurgeryCheckList.PatientNameOnSampleLabel = event;
        }
    }

    public onPatientSurgeryAreaVerifiedChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.PatientSurgeryAreaVerified != event) {
            this._SafeSurgeryCheckList.PatientSurgeryAreaVerified = event;
        }
    }

    public onPatientSurgeryVerifiedChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.PatientSurgeryVerified != event) {
            this._SafeSurgeryCheckList.PatientSurgeryVerified = event;
        }
    }

    public onPulseOximeterWorksOutChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.PulseOximeterWorksOut != event) {
            this._SafeSurgeryCheckList.PulseOximeterWorksOut = event;
        }
    }

    public onReadyUsedMaterialsChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.ReadyUsedMaterials != event) {
            this._SafeSurgeryCheckList.ReadyUsedMaterials = event;
        }
    }

    public onReviewedEstimatedSurgeryTimeChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.ReviewedEstimatedSurgeryTime != event) {
            this._SafeSurgeryCheckList.ReviewedEstimatedSurgeryTime = event;
        }
    }

    public onReviewedExpectedBloodLossChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.ReviewedExpectedBloodLoss != event) {
            this._SafeSurgeryCheckList.ReviewedExpectedBloodLoss = event;
        }
    }

    public onReviewedPatientPositionChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.ReviewedPatientPosition != event) {
            this._SafeSurgeryCheckList.ReviewedPatientPosition = event;
        }
    }

    public onReviewedPossibAnesthesiaRiskChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.ReviewedPossibAnesthesiaRisk != event) {
            this._SafeSurgeryCheckList.ReviewedPossibAnesthesiaRisk = event;
        }
    }

    public onReviewedUnexpectedEventsChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.ReviewedUnexpectedEvents != event) {
            this._SafeSurgeryCheckList.ReviewedUnexpectedEvents = event;
        }
    }

    public onSampleRegionOnSampleLabelChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.SampleRegionOnSampleLabel != event) {
            this._SafeSurgeryCheckList.SampleRegionOnSampleLabel = event;
        }
    }

    public onSugeryAreaVerifiedByPatientChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.SugeryAreaVerifiedByPatient != event) {
            this._SafeSurgeryCheckList.SugeryAreaVerifiedByPatient = event;
        }
    }

    public onSuitableMaterialSterilizationChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.SuitableMaterialSterilization != event) {
            this._SafeSurgeryCheckList.SuitableMaterialSterilization = event;
        }
    }

    public onSurgeonSuggestionsChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.SurgeonSuggestions != event) {
            this._SafeSurgeryCheckList.SurgeonSuggestions = event;
        }
    }

    public onSurgeryAreaShavedChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.SurgeryAreaShaved != event) {
            this._SafeSurgeryCheckList.SurgeryAreaShaved = event;
        }
    }

    public onSurgeryAreaShavedDescriptionChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.SurgeryAreaShavedDescription != event) {
            this._SafeSurgeryCheckList.SurgeryAreaShavedDescription = event;
        }
    }

    public onSurgeryDoctorChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.SurgeryDoctor != event) {
            this._SafeSurgeryCheckList.SurgeryDoctor = event;
        }
    }

    public onSurgeryVerifiedByPatientChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.SurgeryVerifiedByPatient != event) {
            this._SafeSurgeryCheckList.SurgeryVerifiedByPatient = event;
        }
    }

    public onTeamMemberInformedVerballyChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.TeamMemberInformedVerbally != event) {
            this._SafeSurgeryCheckList.TeamMemberInformedVerbally = event;
        }
    }

    public onTeamMembersIntroThemselvesChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.TeamMembersIntroThemselves != event) {
            this._SafeSurgeryCheckList.TeamMembersIntroThemselves = event;
        }
    }

    public onToolSpongeNeedleCountsDoneChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.ToolSpongeNeedleCountsDone != event) {
            this._SafeSurgeryCheckList.ToolSpongeNeedleCountsDone = event;
        }
    }

    public onTreatmentProtocolRequiredChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.TreatmentProtocolRequired != event) {
            this._SafeSurgeryCheckList.TreatmentProtocolRequired = event;
        }
    }

    public onVaricoseBandageRequiredChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList.VaricoseBandageRequired != event) {
            this._SafeSurgeryCheckList.VaricoseBandageRequired = event;
        }
    }

    public ClinicToAnesthesia(event): void {
        if (this._SafeSurgeryCheckList != null && this._SafeSurgeryCheckList != event) {
            this._SafeSurgeryCheckList.VaricoseBandageRequired = event;
        }
    }

    public onSampleLabelChanged(event): void {
        if (this._SafeSurgeryCheckList != null && this.sampleRegion != event) {
            this.sampleRegion = event;

            if (this.sampleRegion == 1) {
                this._SafeSurgeryCheckList.PatientNameOnSampleLabel = true;
                this._SafeSurgeryCheckList.SampleRegionOnSampleLabel = false;
            }

            else if (this.sampleRegion == 2) {
                this._SafeSurgeryCheckList.SampleRegionOnSampleLabel = true;
                this._SafeSurgeryCheckList.PatientNameOnSampleLabel = false;

            }
        }
    }

 
    public async selectedTabChanged(event): Promise<void> {

        let selectedItem: string = event.addedItems[0].title;
        if (selectedItem == i18n("M30011", "Klinikten Ayrılmadan Önce")) {
            this.selectedTab = ChecklistTabs.BeforeLeavingClinicTab;
        } 
        else if (selectedItem == i18n("M30011", "Anestezi Verilmeden Önce")) {
            this.selectedTab = ChecklistTabs.BeforeAnesthesiaTab;
        }
        else if (selectedItem == i18n("M30011", "Ameliyat Kesisinden Önce")) {
            this.selectedTab = ChecklistTabs.BeforeSurgicalIncisionTab;
        }
        else if (selectedItem == i18n("M30011", "Ameliyattan Çıkmadan Önce")) {
            this.selectedTab = ChecklistTabs.BeforeLeavingSurgeryTab;
        }
    }

    controlAnesthesia: boolean = false;
    controlIncision: boolean = false;
    controlLeaveSurgery: boolean = false;

    public async save() {
        if (this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.CurrentStateDefID != SafeSurgeryCheckList.SafeSurgeryCheckListStates.Completed
            || this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.CurrentStateDefID != SafeSurgeryCheckList.SafeSurgeryCheckListStates.Cancelled) {

            if (this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.CurrentStateDefID == SafeSurgeryCheckList.SafeSurgeryCheckListStates.BeforeLeavingClinic
                && this.selectedTab == ChecklistTabs.BeforeLeavingClinicTab) {
                this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.CurrentStateDefID = SafeSurgeryCheckList.SafeSurgeryCheckListStates.BeforeAnesthesia;
                this.controlAnesthesia = true;
            }
            else if (this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.CurrentStateDefID == SafeSurgeryCheckList.SafeSurgeryCheckListStates.BeforeAnesthesia
                && this.selectedTab == ChecklistTabs.BeforeAnesthesiaTab) {
                this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.CurrentStateDefID = SafeSurgeryCheckList.SafeSurgeryCheckListStates.BeforeSurgicalIncision;
                this.controlIncision = true;
            }
            else if (this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.CurrentStateDefID == SafeSurgeryCheckList.SafeSurgeryCheckListStates.BeforeSurgicalIncision
                && this.selectedTab == ChecklistTabs.BeforeSurgicalIncisionTab) {
                this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.CurrentStateDefID = SafeSurgeryCheckList.SafeSurgeryCheckListStates.BeforeLeavingSurgery;
                this.controlLeaveSurgery = true;
            }
            else if (this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.CurrentStateDefID == SafeSurgeryCheckList.SafeSurgeryCheckListStates.BeforeLeavingSurgery
                && this.selectedTab == ChecklistTabs.BeforeLeavingSurgeryTab) {
                this.safeSurgeryCheckListFormViewModel._SafeSurgeryCheckList.CurrentStateDefID = SafeSurgeryCheckList.SafeSurgeryCheckListStates.Completed;
            }
            await super.save();

        }
    }


    protected redirectProperties(): void {
        redirectProperty(this.PatientIDInfoVerified, "Value", this.__ttObject, "PatientIDInfoVerified");
        redirectProperty(this.PatientSurgeryVerified, "Value", this.__ttObject, "PatientSurgeryVerified");
        redirectProperty(this.PatientSurgeryAreaVerified, "Value", this.__ttObject, "PatientSurgeryAreaVerified");
        redirectProperty(this.MakeupProsthesisValuableItem, "Value", this.__ttObject, "MakeupProsthesisValuableItem");
        redirectProperty(this.VaricoseBandageRequired, "Value", this.__ttObject, "VaricoseBandageRequired");
        redirectProperty(this.OtherSpecialActionRequired, "Value", this.__ttObject, "OtherSpecialActionRequired");
        redirectProperty(this.MaterialPreparationChecked, "Value", this.__ttObject, "MaterialPreparationChecked");
        redirectProperty(this.MakeupProstValItemDescription, "Text", this.__ttObject, "MakeupProstValItemDescription");
        redirectProperty(this.LabAndRadioTestsAvailable, "Value", this.__ttObject, "LabAndRadioTestsAvailable");
        redirectProperty(this.PatientConsentChecked, "Value", this.__ttObject, "PatientConsentChecked");
        redirectProperty(this.IsPatientClothesReady, "Value", this.__ttObject, "IsPatientClothesReady");
        redirectProperty(this.IsPatientHungry, "Value", this.__ttObject, "IsPatientHungry");
        redirectProperty(this.PatientClothesDescription, "Text", this.__ttObject, "PatientClothesDescription");
        redirectProperty(this.PatientHungerDescription, "Text", this.__ttObject, "PatientHungerDescription");
        redirectProperty(this.LavmanRequired, "Value", this.__ttObject, "LavmanRequired");
        redirectProperty(this.CatheterizationRequired, "Value", this.__ttObject, "CatheterizationRequired");
        redirectProperty(this.TreatmentProtocolRequired, "Value", this.__ttObject, "TreatmentProtocolRequired");
        redirectProperty(this.SurgeryAreaShaved, "Value", this.__ttObject, "SurgeryAreaShaved");
        redirectProperty(this.OtherSpecialActionDescription, "Text", this.__ttObject, "OtherSpecialActionDescription");
        redirectProperty(this.SurgeryAreaShavedDescription, "Text", this.__ttObject, "SurgeryAreaShavedDescription");
        redirectProperty(this.PatientIDVerifiedByPatient, "Value", this.__ttObject, "PatientIDVerifiedByPatient");
        redirectProperty(this.SurgeryVerifiedByPatient, "Value", this.__ttObject, "SurgeryVerifiedByPatient");
        redirectProperty(this.SugeryAreaVerifiedByPatient, "Value", this.__ttObject, "SugeryAreaVerifiedByPatient");
        redirectProperty(this.ConsentVerifiedByPatient, "Value", this.__ttObject, "ConsentVerifiedByPatient");
        redirectProperty(this.PatientHasAnAllergy, "Value", this.__ttObject, "PatientHasAnAllergy");
        redirectProperty(this.PatientAllergyDescription, "Text", this.__ttObject, "PatientAllergyDescription");
        redirectProperty(this.HasSignInSurgeryArea, "Value", this.__ttObject, "HasSignInSurgeryArea");
        redirectProperty(this.HasImagingDevice, "Value", this.__ttObject, "HasImagingDevice");
        redirectProperty(this.AnesthesiaChecklistCompleted, "Value", this.__ttObject, "AnesthesiaChecklistCompleted");
        redirectProperty(this.HasBloodLossRisk, "Value", this.__ttObject, "HasBloodLossRisk");
        redirectProperty(this.PulseOximeterWorksOut, "Value", this.__ttObject, "PulseOximeterWorksOut");
        redirectProperty(this.TeamMembersIntroThemselves, "Value", this.__ttObject, "TeamMembersIntroThemselves");
        redirectProperty(this.ReviewedExpectedBloodLoss, "Value", this.__ttObject, "ReviewedExpectedBloodLoss");
        redirectProperty(this.ReviewedPossibAnesthesiaRisk, "Value", this.__ttObject, "ReviewedPossibAnesthesiaRisk");
        redirectProperty(this.ReviewedPatientPosition, "Value", this.__ttObject, "ReviewedPatientPosition");
        redirectProperty(this.ReviewedUnexpectedEvents, "Value", this.__ttObject, "ReviewedUnexpectedEvents");
        redirectProperty(this.SuitableMaterialSterilization, "Value", this.__ttObject, "SuitableMaterialSterilization");
        redirectProperty(this.TeamMemberInformedVerbally, "Value", this.__ttObject, "TeamMemberInformedVerbally");
        redirectProperty(this.NecessaryBloodSugarControl, "Value", this.__ttObject, "NecessaryBloodSugarControl");
        redirectProperty(this.ReviewedEstimatedSurgeryTime, "Value", this.__ttObject, "ReviewedEstimatedSurgeryTime");
        redirectProperty(this.HasAnticoagulantUsage, "Value", this.__ttObject, "HasAnticoagulantUsage");
        redirectProperty(this.NecessaryDeepVeinThrombosis, "Value", this.__ttObject, "NecessaryDeepVeinThrombosis");
        redirectProperty(this.AppliedProphylacticAntibiotic, "Value", this.__ttObject, "AppliedProphylacticAntibiotic");
        redirectProperty(this.ReadyUsedMaterials, "Value", this.__ttObject, "ReadyUsedMaterials");
        redirectProperty(this.ConfirmedPatientVerbally, "Value", this.__ttObject, "ConfirmedPatientVerbally");
        redirectProperty(this.ConfirmedSurgeryVerbally, "Value", this.__ttObject, "ConfirmedSurgeryVerbally");
        redirectProperty(this.ConfirmedSurgeryAreaVerbally, "Value", this.__ttObject, "ConfirmedSurgeryAreaVerbally");
        redirectProperty(this.SampleRegionOnSampleLabel, "Value", this.__ttObject, "SampleRegionOnSampleLabel");
        redirectProperty(this.AnesthetistSuggestions, "Text", this.__ttObject, "AnesthetistSuggestions");
        redirectProperty(this.SurgeonSuggestions, "Text", this.__ttObject, "SurgeonSuggestions");
        redirectProperty(this.ToolSpongeNeedleCountsDone, "Value", this.__ttObject, "ToolSpongeNeedleCountsDone");
        redirectProperty(this.ConfirmedAfterSurgeryClinic, "Value", this.__ttObject, "ConfirmedAfterSurgeryClinic");
        redirectProperty(this.PatientNameOnSampleLabel, "Value", this.__ttObject, "PatientNameOnSampleLabel");
    }

    public initFormControls(): void {
        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 0;

        this.BeforeLeavingClinic = new TTVisual.TTTabPage();
        this.BeforeLeavingClinic.DisplayIndex = 0;
        this.BeforeLeavingClinic.TabIndex = 3;
        this.BeforeLeavingClinic.Text = "Klinikten Ayrılmadan Önce";
        this.BeforeLeavingClinic.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.BeforeLeavingClinic.Name = "BeforeLeavingClinic";

        this.ttlabel15 = new TTVisual.TTLabel();
        this.ttlabel15.Text = "9 - Hastanın gerekli laboratuvar ve radyoloji tetkikleri mevcut mu?";
        this.ttlabel15.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel15.Name = "ttlabel15";
        this.ttlabel15.TabIndex = 35;

        this.ttlabel14 = new TTVisual.TTLabel();
        this.ttlabel14.Text = "8 - Ameliyat için gerekli olacak özel malzeme, implant, kan veya kan ürünleri hazırlığı teyit edildi mi?";
        this.ttlabel14.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel14.Name = "ttlabel14";
        this.ttlabel14.TabIndex = 34;

        this.ttlabel13 = new TTVisual.TTLabel();
        this.ttlabel13.Text = "7 - Ameliyat öncesi gerekli özel işlem var mı?";
        this.ttlabel13.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel13.Name = "ttlabel13";
        this.ttlabel13.TabIndex = 33;

        this.ttlabel12 = new TTVisual.TTLabel();
        this.ttlabel12.Text = "6 - Hastanın kıyafetleri tümüyle çıkarılıp ameliyat ameliyat önlüğü ve bonesi giydirildi mi?";
        this.ttlabel12.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel12.Name = "ttlabel12";
        this.ttlabel12.TabIndex = 32;

        this.ttlabel11 = new TTVisual.TTLabel();
        this.ttlabel11.Text = "5 - Hastada makyaj / oje, protez, değerli eşya var mı?";
        this.ttlabel11.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel11.Name = "ttlabel11";
        this.ttlabel11.TabIndex = 31;

        this.ttlabel10 = new TTVisual.TTLabel();
        this.ttlabel10.Text = "4 - Ameliyat bölgesi tıraşı yapıldı mı?";
        this.ttlabel10.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel10.Name = "ttlabel10";
        this.ttlabel10.TabIndex = 30;

        this.ttlabel9 = new TTVisual.TTLabel();
        this.ttlabel9.Text = "3 - Hasta aç mı?";
        this.ttlabel9.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel9.Name = "ttlabel9";
        this.ttlabel9.TabIndex = 29;

        this.ttlabel8 = new TTVisual.TTLabel();
        this.ttlabel8.Text = "2 - Hastanın rızası kontrol edildi mi?";
        this.ttlabel8.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel8.Name = "ttlabel8";
        this.ttlabel8.TabIndex = 28;

        this.ttlabel7 = new TTVisual.TTLabel();
        this.ttlabel7.Text = "1 - Hastanın";
        this.ttlabel7.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel7.Name = "ttlabel7";
        this.ttlabel7.TabIndex = 27;

        this.labelClinicalNurse = new TTVisual.TTLabel();
        this.labelClinicalNurse.Text = "Klinik Hemşiresi";
        this.labelClinicalNurse.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelClinicalNurse.Name = "labelClinicalNurse";
        this.labelClinicalNurse.TabIndex = 26;

        this.ClinicalNurse = new TTVisual.TTObjectListBox();
        this.ClinicalNurse.ListDefName = "ClinicNurseListDefinition";
        this.ClinicalNurse.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ClinicalNurse.Name = "ClinicalNurse";
        this.ClinicalNurse.TabIndex = 25;

        this.labelPatientClothesDescription = new TTVisual.TTLabel();
        this.labelPatientClothesDescription.Text = "Hastanın kıyafetleri hazır değilse açıklama";
        this.labelPatientClothesDescription.Name = "labelPatientClothesDescription";
        this.labelPatientClothesDescription.TabIndex = 24;

        this.PatientClothesDescription = new TTVisual.TTTextBox();
        this.PatientClothesDescription.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PatientClothesDescription.Name = "PatientClothesDescription";
        this.PatientClothesDescription.TabIndex = 23;
        this.PatientClothesDescription.Height = "90px";
        this.PatientClothesDescription.IsNonNumeric = true;
        this.PatientClothesDescription.Multiline = true;

        this.LabAndRadioTestsAvailable = new TTVisual.TTCheckBox();
        this.LabAndRadioTestsAvailable.Value = false;
        this.LabAndRadioTestsAvailable.Text = "Evet";
        this.LabAndRadioTestsAvailable.Name = "LabAndRadioTestsAvailable";
        this.LabAndRadioTestsAvailable.TabIndex = 22;
        this.LabAndRadioTestsAvailable.Title = "Evet";


        this.MaterialPreparationChecked = new TTVisual.TTCheckBox();
        this.MaterialPreparationChecked.Value = false;
        this.MaterialPreparationChecked.Text = "Evet";
        this.MaterialPreparationChecked.Name = "MaterialPreparationChecked";
        this.MaterialPreparationChecked.TabIndex = 21;
        this.MaterialPreparationChecked.Title = "Evet";


        this.labelOtherSpecialActionDescription = new TTVisual.TTLabel();
        this.labelOtherSpecialActionDescription.Text = "Diğer özel işlem açıklaması";
        this.labelOtherSpecialActionDescription.Name = "labelOtherSpecialActionDescription";
        this.labelOtherSpecialActionDescription.TabIndex = 20;


        this.OtherSpecialActionDescription = new TTVisual.TTTextBox();
        this.OtherSpecialActionDescription.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.OtherSpecialActionDescription.Name = "OtherSpecialActionDescription";
        this.OtherSpecialActionDescription.TabIndex = 19;
        this.OtherSpecialActionDescription.Height = "90px";
        this.OtherSpecialActionDescription.Multiline = true;

        this.OtherSpecialActionRequired = new TTVisual.TTCheckBox();
        this.OtherSpecialActionRequired.Value = false;
        this.OtherSpecialActionRequired.Text = "Diğer";
        this.OtherSpecialActionRequired.Name = "OtherSpecialActionRequired";
        this.OtherSpecialActionRequired.TabIndex = 18;
        this.OtherSpecialActionRequired.Title = "Diğer";


        this.TreatmentProtocolRequired = new TTVisual.TTCheckBox();
        this.TreatmentProtocolRequired.Value = false;
        this.TreatmentProtocolRequired.Text = "Özel Tedavi Protokolü";
        this.TreatmentProtocolRequired.Name = "TreatmentProtocolRequired";
        this.TreatmentProtocolRequired.TabIndex = 17;
        this.TreatmentProtocolRequired.Title = "Özel Tedavi Protokolü";


        this.CatheterizationRequired = new TTVisual.TTCheckBox();
        this.CatheterizationRequired.Value = false;
        this.CatheterizationRequired.Text = "Mesane Kateterizasyonu";
        this.CatheterizationRequired.Name = "CatheterizationRequired";
        this.CatheterizationRequired.TabIndex = 16;
        this.CatheterizationRequired.Title = "Mesane Kateterizasyonu";


        this.VaricoseBandageRequired = new TTVisual.TTCheckBox();
        this.VaricoseBandageRequired.Value = false;
        this.VaricoseBandageRequired.Text = "Varis Çorabı";
        this.VaricoseBandageRequired.Name = "VaricoseBandageRequired";
        this.VaricoseBandageRequired.TabIndex = 15;
        this.VaricoseBandageRequired.Title = "Varis Çorabı";


        this.LavmanRequired = new TTVisual.TTCheckBox();
        this.LavmanRequired.Value = false;
        this.LavmanRequired.Text = "Lavman";
        this.LavmanRequired.Name = "LavmanRequired";
        this.LavmanRequired.TabIndex = 14;
        this.LavmanRequired.Title = "Lavman";


        this.IsPatientClothesReady = new TTVisual.TTCheckBox();
        this.IsPatientClothesReady.Value = false;
        this.IsPatientClothesReady.Text = "Evet";
        this.IsPatientClothesReady.Name = "IsPatientClothesReady";
        this.IsPatientClothesReady.TabIndex = 13;
        this.IsPatientClothesReady.Title = "Evet";


        this.labelMakeupProstValItemDescription = new TTVisual.TTLabel();
        this.labelMakeupProstValItemDescription.Text = "Hayır ise Açıklaması";
        this.labelMakeupProstValItemDescription.Name = "labelMakeupProstValItemDescription";
        this.labelMakeupProstValItemDescription.TabIndex = 12;

        this.MakeupProstValItemDescription = new TTVisual.TTTextBox();
        this.MakeupProstValItemDescription.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.MakeupProstValItemDescription.Name = "MakeupProstValItemDescription";
        this.MakeupProstValItemDescription.TabIndex = 11;
        this.MakeupProstValItemDescription.Height = "90px";
        this.MakeupProstValItemDescription.Multiline = true;

        this.MakeupProsthesisValuableItem = new TTVisual.TTCheckBox();
        this.MakeupProsthesisValuableItem.Value = false;
        this.MakeupProsthesisValuableItem.Text = "Evet";
        this.MakeupProsthesisValuableItem.Name = "MakeupProsthesisValuableItem";
        this.MakeupProsthesisValuableItem.TabIndex = 10;
        this.MakeupProsthesisValuableItem.Title = "Evet";


        this.labelSurgeryAreaShavedDescription = new TTVisual.TTLabel();
        this.labelSurgeryAreaShavedDescription.Text = "Ameliyat Bölgesi Tıraşı Yapılmadıysa Açıklama";
        this.labelSurgeryAreaShavedDescription.Name = "labelSurgeryAreaShavedDescription";
        this.labelSurgeryAreaShavedDescription.TabIndex = 9;

        this.SurgeryAreaShavedDescription = new TTVisual.TTTextBox();
        this.SurgeryAreaShavedDescription.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.SurgeryAreaShavedDescription.Name = "SurgeryAreaShavedDescription";
        this.SurgeryAreaShavedDescription.TabIndex = 8;
        this.SurgeryAreaShavedDescription.Height = "90px";
        this.SurgeryAreaShavedDescription.Multiline = true;

        this.SurgeryAreaShaved = new TTVisual.TTCheckBox();
        this.SurgeryAreaShaved.Value = false;
        this.SurgeryAreaShaved.Text = "Evet";
        this.SurgeryAreaShaved.Name = "SurgeryAreaShaved";
        this.SurgeryAreaShaved.TabIndex = 7;
        this.SurgeryAreaShaved.Title = "Evet";


        this.labelPatientHungerDescription = new TTVisual.TTLabel();
        this.labelPatientHungerDescription.Text = "Hasta Aç Değilse Açıklaması";
        this.labelPatientHungerDescription.Name = "labelPatientHungerDescription";
        this.labelPatientHungerDescription.TabIndex = 6;

        this.PatientHungerDescription = new TTVisual.TTTextBox();
        this.PatientHungerDescription.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.PatientHungerDescription.Name = "PatientHungerDescription";
        this.PatientHungerDescription.TabIndex = 5;
        this.PatientHungerDescription.Height = "90px";
        this.PatientHungerDescription.Multiline = true;

        this.IsPatientHungry = new TTVisual.TTCheckBox();
        this.IsPatientHungry.Value = false;
        this.IsPatientHungry.Text = "Evet";
        this.IsPatientHungry.Name = "IsPatientHungry";
        this.IsPatientHungry.TabIndex = 4;
        this.IsPatientHungry.Title = "Evet";


        this.PatientConsentChecked = new TTVisual.TTCheckBox();
        this.PatientConsentChecked.Value = false;
        this.PatientConsentChecked.Text = "Evet";
        this.PatientConsentChecked.Name = "PatientConsentChecked";
        this.PatientConsentChecked.TabIndex = 3;
        this.PatientConsentChecked.Title = "Evet";


        this.PatientSurgeryAreaVerified = new TTVisual.TTCheckBox();
        this.PatientSurgeryAreaVerified.Value = false;
        this.PatientSurgeryAreaVerified.Text = "Ameliyat Bölgesi Doğrulandı";
        this.PatientSurgeryAreaVerified.Name = "PatientSurgeryAreaVerified";
        this.PatientSurgeryAreaVerified.TabIndex = 2;
        this.PatientSurgeryAreaVerified.Title = "Ameliyat Bölgesi Doğrulandı";


        this.PatientSurgeryVerified = new TTVisual.TTCheckBox();
        this.PatientSurgeryVerified.Value = false;
        this.PatientSurgeryVerified.Text = "Ameliyatı,";
        this.PatientSurgeryVerified.Name = "PatientSurgeryVerified";
        this.PatientSurgeryVerified.TabIndex = 1;
        this.PatientSurgeryVerified.Title = "Ameliyatı,";


        this.PatientIDInfoVerified = new TTVisual.TTCheckBox();
        this.PatientIDInfoVerified.Value = false;
        this.PatientIDInfoVerified.Text = "Kimlik Bilgileri,";
        this.PatientIDInfoVerified.Name = "PatientIDInfoVerified";
        this.PatientIDInfoVerified.TabIndex = 0;
        this.PatientIDInfoVerified.Title = "Kimlik Bilgileri,";


        this.BeforeAnesthesia = new TTVisual.TTTabPage();
        this.BeforeAnesthesia.DisplayIndex = 1;
        this.BeforeAnesthesia.TabIndex = 1;
        this.BeforeAnesthesia.Text = "Anestezi Verilmeden Önce";
        this.BeforeAnesthesia.Name = "BeforeAnesthesia";

        this.labelAnesthesiologist = new TTVisual.TTLabel();
        this.labelAnesthesiologist.Text = "Anestezi Doktoru";
        this.labelAnesthesiologist.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelAnesthesiologist.Name = "labelAnesthesiologist";
        this.labelAnesthesiologist.TabIndex = 21;

        this.Anesthesiologist = new TTVisual.TTObjectListBox();
        this.Anesthesiologist.ListDefName = "DoctorListDefinition";
        this.Anesthesiologist.Name = "Anesthesiologist";
        this.Anesthesiologist.TabIndex = 20;

        this.ttlabel18 = new TTVisual.TTLabel();
        this.ttlabel18.Text = "16 - Hastada 500 ml ya da daha fazla kan kaybı riski var mı?";
        this.ttlabel18.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel18.Name = "ttlabel18";
        this.ttlabel18.TabIndex = 19;

        this.ttlabel17 = new TTVisual.TTLabel();
        this.ttlabel17.Text = "15 - Gerekli görüntüleme cihazları var mı?";
        this.ttlabel17.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel17.Name = "ttlabel17";
        this.ttlabel17.TabIndex = 18;

        this.ttlabel16 = new TTVisual.TTLabel();
        this.ttlabel16.Text = "14 - Hastanın bilinen alerjisi var mı?";
        this.ttlabel16.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel16.Name = "ttlabel16";
        this.ttlabel16.TabIndex = 17;

        this.ttlabel6 = new TTVisual.TTLabel();
        this.ttlabel6.Text = "Hastanın Risk Değerlendirmesi:";
        this.ttlabel6.Font = "Name=Tahoma, Size=12, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel6.Name = "ttlabel6";
        this.ttlabel6.TabIndex = 16;

        this.ttlabel5 = new TTVisual.TTLabel();
        this.ttlabel5.Text = "13 - Pulse oksimetre hasta üzerinde ve çalışıyor mu?";
        this.ttlabel5.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel5.Name = "ttlabel5";
        this.ttlabel5.TabIndex = 15;

        this.ttlabel4 = new TTVisual.TTLabel();
        this.ttlabel4.Text = "12 - Anestezi Güvenlik Kontrol Listesi tamamlandı mı?";
        this.ttlabel4.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel4.Name = "ttlabel4";
        this.ttlabel4.TabIndex = 14;

        this.ttlabel3 = new TTVisual.TTLabel();
        this.ttlabel3.Text = "11 - Ameliyat bölgesinde işaretleme var mı?";
        this.ttlabel3.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel3.Name = "ttlabel3";
        this.ttlabel3.TabIndex = 13;

        this.labelPatientAllergyDescription = new TTVisual.TTLabel();
        this.labelPatientAllergyDescription.Text = "Hastanın alerjisi var ise açıklaması";
        this.labelPatientAllergyDescription.Name = "labelPatientAllergyDescription";
        this.labelPatientAllergyDescription.TabIndex = 12;

        this.PatientAllergyDescription = new TTVisual.TTTextBox();
        this.PatientAllergyDescription.Name = "PatientAllergyDescription";
        this.PatientAllergyDescription.TabIndex = 11;
        this.PatientAllergyDescription.Height = "90px";
        this.PatientAllergyDescription.Multiline = true;

        this.HasBloodLossRisk = new TTVisual.TTCheckBox();
        this.HasBloodLossRisk.Value = false;
        this.HasBloodLossRisk.Text = "Evet";
        this.HasBloodLossRisk.Name = "HasBloodLossRisk";
        this.HasBloodLossRisk.TabIndex = 10;
        this.HasBloodLossRisk.Title = "Evet";


        this.HasImagingDevice = new TTVisual.TTCheckBox();
        this.HasImagingDevice.Value = false;
        this.HasImagingDevice.Text = "Evet";
        this.HasImagingDevice.Name = "HasImagingDevice";
        this.HasImagingDevice.TabIndex = 9;
        this.HasImagingDevice.Title = "Evet";


        this.PatientHasAnAllergy = new TTVisual.TTCheckBox();
        this.PatientHasAnAllergy.Value = false;
        this.PatientHasAnAllergy.Text = "Evet";
        this.PatientHasAnAllergy.Name = "PatientHasAnAllergy";
        this.PatientHasAnAllergy.TabIndex = 8;
        this.PatientHasAnAllergy.Title = "Evet";


        this.PulseOximeterWorksOut = new TTVisual.TTCheckBox();
        this.PulseOximeterWorksOut.Value = false;
        this.PulseOximeterWorksOut.Text = "Evet";
        this.PulseOximeterWorksOut.Name = "PulseOximeterWorksOut";
        this.PulseOximeterWorksOut.TabIndex = 7;
        this.PulseOximeterWorksOut.Title = "Evet";


        this.AnesthesiaChecklistCompleted = new TTVisual.TTCheckBox();
        this.AnesthesiaChecklistCompleted.Value = false;
        this.AnesthesiaChecklistCompleted.Text = "Evet";
        this.AnesthesiaChecklistCompleted.Name = "AnesthesiaChecklistCompleted";
        this.AnesthesiaChecklistCompleted.TabIndex = 6;
        this.AnesthesiaChecklistCompleted.Title = "Evet";


        this.HasSignInSurgeryArea = new TTVisual.TTCheckBox();
        this.HasSignInSurgeryArea.Value = false;
        this.HasSignInSurgeryArea.Text = "Evet";
        this.HasSignInSurgeryArea.Name = "HasSignInSurgeryArea";
        this.HasSignInSurgeryArea.TabIndex = 5;
        this.HasSignInSurgeryArea.Title = "Evet";


        this.ConsentVerifiedByPatient = new TTVisual.TTCheckBox();
        this.ConsentVerifiedByPatient.Value = false;
        this.ConsentVerifiedByPatient.Text = "Hastanın ameliyatı ile ilgili rızası doğrulandı.";
        this.ConsentVerifiedByPatient.Name = "ConsentVerifiedByPatient";
        this.ConsentVerifiedByPatient.TabIndex = 4;
        this.ConsentVerifiedByPatient.Title = "Hastanın ameliyatı ile ilgili rızası doğrulandı.";


        this.SugeryAreaVerifiedByPatient = new TTVisual.TTCheckBox();
        this.SugeryAreaVerifiedByPatient.Value = false;
        this.SugeryAreaVerifiedByPatient.Text = "Ameliyat bölgesi,";
        this.SugeryAreaVerifiedByPatient.Name = "SugeryAreaVerifiedByPatient";
        this.SugeryAreaVerifiedByPatient.TabIndex = 3;
        this.SugeryAreaVerifiedByPatient.Title = "Ameliyat bölgesi,";


        this.SurgeryVerifiedByPatient = new TTVisual.TTCheckBox();
        this.SurgeryVerifiedByPatient.Value = false;
        this.SurgeryVerifiedByPatient.Text = "Ameliyatı,";
        this.SurgeryVerifiedByPatient.Name = "SurgeryVerifiedByPatient";
        this.SurgeryVerifiedByPatient.TabIndex = 2;
        this.SurgeryVerifiedByPatient.Title = "Ameliyatı,";


        this.PatientIDVerifiedByPatient = new TTVisual.TTCheckBox();
        this.PatientIDVerifiedByPatient.Value = false;
        this.PatientIDVerifiedByPatient.Text = "Kimlik bilgileri,";
        this.PatientIDVerifiedByPatient.Name = "PatientIDVerifiedByPatient";
        this.PatientIDVerifiedByPatient.TabIndex = 1;
        this.PatientIDVerifiedByPatient.Title = "Kimlik bilgileri,";


        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "10 - Hastanın kendisinden";
        this.ttlabel1.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 0;

        this.BeforeSurgicalIncision = new TTVisual.TTTabPage();
        this.BeforeSurgicalIncision.DisplayIndex = 2;
        this.BeforeSurgicalIncision.TabIndex = 2;
        this.BeforeSurgicalIncision.Text = "Ameliyat Kesisinden Önce";
        this.BeforeSurgicalIncision.Name = "BeforeSurgicalIncision";

        this.ttlabel26 = new TTVisual.TTLabel();
        this.ttlabel26.Text = "25 - Derin Ven Trombozu profilaksisi gerekli mi?";
        this.ttlabel26.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel26.Name = "ttlabel26";
        this.ttlabel26.TabIndex = 23;

        this.ttlabel25 = new TTVisual.TTLabel();
        this.ttlabel25.Text = "24 - Antikoagülan kullanımı var mı?";
        this.ttlabel25.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel25.Name = "ttlabel25";
        this.ttlabel25.TabIndex = 22;

        this.ttlabel24 = new TTVisual.TTLabel();
        this.ttlabel24.Text = "23 - Kan şekeri kontrolü gerekli mi?";
        this.ttlabel24.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel24.Name = "ttlabel24";
        this.ttlabel24.TabIndex = 21;

        this.ttlabel23 = new TTVisual.TTLabel();
        this.ttlabel23.Text = "22 - Malzemelerin sterilizasyonu uygun mu?";
        this.ttlabel23.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel23.Name = "ttlabel23";
        this.ttlabel23.TabIndex = 20;

        this.ttlabel22 = new TTVisual.TTLabel();
        this.ttlabel22.Text = "21  - Kullanılacak malzemeler hazır mı?";
        this.ttlabel22.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel22.Name = "ttlabel22";
        this.ttlabel22.TabIndex = 19;

        this.ttlabel2 = new TTVisual.TTLabel();
        this.ttlabel2.Text = "20 - Profilaktik antibiyotik sorgulandı mı";
        this.ttlabel2.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel2.Name = "ttlabel2";
        this.ttlabel2.TabIndex = 18;

        this.ttlabel21 = new TTVisual.TTLabel();
        this.ttlabel21.Text = "19 - Kritik olaylar gözden geçirildi mi?";
        this.ttlabel21.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel21.Name = "ttlabel21";
        this.ttlabel21.TabIndex = 17;

        this.ttlabel20 = new TTVisual.TTLabel();
        this.ttlabel20.Text = "17 - Ekipteki kişiler kendilerini ad, soyad ve görevleri ile tanıttı mı?";
        this.ttlabel20.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel20.Name = "ttlabel20";
        this.ttlabel20.TabIndex = 16;

        this.ttlabel19 = new TTVisual.TTLabel();
        this.ttlabel19.Text = "18 - Ekipten bir kişi sesli olarak hastanın kimliğini, yapılan ameliyatı, ameliyat bölgesini teyit etti mi?";
        this.ttlabel19.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel19.Name = "ttlabel19";
        this.ttlabel19.TabIndex = 15;

        this.labelSurgeryDoctor = new TTVisual.TTLabel();
        this.labelSurgeryDoctor.Text = "Ameliyatı Yapan Doktor";
        this.labelSurgeryDoctor.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelSurgeryDoctor.Name = "labelSurgeryDoctor";
        this.labelSurgeryDoctor.TabIndex = 14;

        this.SurgeryDoctor = new TTVisual.TTObjectListBox();
        this.SurgeryDoctor.ListDefName = "ClinicDoctorListDefinition";
        this.SurgeryDoctor.Name = "SurgeryDoctor";
        this.SurgeryDoctor.TabIndex = 13;

        this.TeamMemberInformedVerbally = new TTVisual.TTCheckBox();
        this.TeamMemberInformedVerbally.Value = false;
        this.TeamMemberInformedVerbally.Text = "Evet";
        this.TeamMemberInformedVerbally.Name = "TeamMemberInformedVerbally";
        this.TeamMemberInformedVerbally.TabIndex = 12;
        this.TeamMemberInformedVerbally.Title = "Evet";


        this.NecessaryDeepVeinThrombosis = new TTVisual.TTCheckBox();
        this.NecessaryDeepVeinThrombosis.Value = false;
        this.NecessaryDeepVeinThrombosis.Text = "Evet";
        this.NecessaryDeepVeinThrombosis.Name = "NecessaryDeepVeinThrombosis";
        this.NecessaryDeepVeinThrombosis.TabIndex = 11;
        this.NecessaryDeepVeinThrombosis.Title = "Evet";


        this.HasAnticoagulantUsage = new TTVisual.TTCheckBox();
        this.HasAnticoagulantUsage.Value = false;
        this.HasAnticoagulantUsage.Text = "Evet";
        this.HasAnticoagulantUsage.Name = "HasAnticoagulantUsage";
        this.HasAnticoagulantUsage.TabIndex = 10;
        this.HasAnticoagulantUsage.Title = "Evet";


        this.NecessaryBloodSugarControl = new TTVisual.TTCheckBox();
        this.NecessaryBloodSugarControl.Value = false;
        this.NecessaryBloodSugarControl.Text = "Evet";
        this.NecessaryBloodSugarControl.Name = "NecessaryBloodSugarControl";
        this.NecessaryBloodSugarControl.TabIndex = 9;
        this.NecessaryBloodSugarControl.Title = "Evet";


        this.SuitableMaterialSterilization = new TTVisual.TTCheckBox();
        this.SuitableMaterialSterilization.Value = false;
        this.SuitableMaterialSterilization.Text = "Evet";
        this.SuitableMaterialSterilization.Name = "SuitableMaterialSterilization";
        this.SuitableMaterialSterilization.TabIndex = 8;
        this.SuitableMaterialSterilization.Title = "Evet";


        this.ReadyUsedMaterials = new TTVisual.TTCheckBox();
        this.ReadyUsedMaterials.Value = false;
        this.ReadyUsedMaterials.Text = "Evet";
        this.ReadyUsedMaterials.Name = "ReadyUsedMaterials";
        this.ReadyUsedMaterials.TabIndex = 7;
        this.ReadyUsedMaterials.Title = "Evet";


        this.AppliedProphylacticAntibiotic = new TTVisual.TTCheckBox();
        this.AppliedProphylacticAntibiotic.Value = false;
        this.AppliedProphylacticAntibiotic.Text = "Kesiden önceki son 60 dakika içerisinde uygulandı";
        this.AppliedProphylacticAntibiotic.Name = "AppliedProphylacticAntibiotic";
        this.AppliedProphylacticAntibiotic.TabIndex = 6;
        this.AppliedProphylacticAntibiotic.Title = "Kesiden önceki son 60 dakika içerisinde uygulandı";


        this.ReviewedPatientPosition = new TTVisual.TTCheckBox();
        this.ReviewedPatientPosition.Value = false;
        this.ReviewedPatientPosition.Text = "Hastanın pozisyonu";
        this.ReviewedPatientPosition.Name = "ReviewedPatientPosition";
        this.ReviewedPatientPosition.TabIndex = 5;
        this.ReviewedPatientPosition.Title = "Hastanın pozisyonu";


        this.ReviewedPossibAnesthesiaRisk = new TTVisual.TTCheckBox();
        this.ReviewedPossibAnesthesiaRisk.Value = false;
        this.ReviewedPossibAnesthesiaRisk.Text = "Olası anestezi riskleri";
        this.ReviewedPossibAnesthesiaRisk.Name = "ReviewedPossibAnesthesiaRisk";
        this.ReviewedPossibAnesthesiaRisk.TabIndex = 4;
        this.ReviewedPossibAnesthesiaRisk.Title = "Olası anestezi riskleri";


        this.ReviewedUnexpectedEvents = new TTVisual.TTCheckBox();
        this.ReviewedUnexpectedEvents.Value = false;
        this.ReviewedUnexpectedEvents.Text = "Ameliyat sırasında gerçekleşebilecek beklenmedik olaylar";
        this.ReviewedUnexpectedEvents.Name = "ReviewedUnexpectedEvents";
        this.ReviewedUnexpectedEvents.TabIndex = 3;
        this.ReviewedUnexpectedEvents.Title = "Ameliyat sırasında gerçekleşebilecek beklenmedik olaylar";


        this.ReviewedExpectedBloodLoss = new TTVisual.TTCheckBox();
        this.ReviewedExpectedBloodLoss.Value = false;
        this.ReviewedExpectedBloodLoss.Text = "Beklenen kan kaybı";
        this.ReviewedExpectedBloodLoss.Name = "ReviewedExpectedBloodLoss";
        this.ReviewedExpectedBloodLoss.TabIndex = 2;
        this.ReviewedExpectedBloodLoss.Title = "Beklenen kan kaybı";


        this.ReviewedEstimatedSurgeryTime = new TTVisual.TTCheckBox();
        this.ReviewedEstimatedSurgeryTime.Value = false;
        this.ReviewedEstimatedSurgeryTime.Text = "Tahmini ameliyat süresi";
        this.ReviewedEstimatedSurgeryTime.Name = "ReviewedEstimatedSurgeryTime";
        this.ReviewedEstimatedSurgeryTime.TabIndex = 1;
        this.ReviewedEstimatedSurgeryTime.Title = "Tahmini ameliyat süresi";


        this.TeamMembersIntroThemselves = new TTVisual.TTCheckBox();
        this.TeamMembersIntroThemselves.Value = false;
        this.TeamMembersIntroThemselves.Text = "Evet";
        this.TeamMembersIntroThemselves.Name = "TeamMembersIntroThemselves";
        this.TeamMembersIntroThemselves.TabIndex = 0;
        this.TeamMembersIntroThemselves.Title = "Evet";


        this.BeforeLeavingSurgery = new TTVisual.TTTabPage();
        this.BeforeLeavingSurgery.DisplayIndex = 3;
        this.BeforeLeavingSurgery.TabIndex = 0;
        this.BeforeLeavingSurgery.Text = "Ameliyattan Çıkmadan Önce";
        this.BeforeLeavingSurgery.Name = "BeforeLeavingSurgery";

        this.ttlabel34 = new TTVisual.TTLabel();
        this.ttlabel34.Text = "30 - Hastanın ameliyat sonrası gideceği bölüm teyit edildi mi?";
        this.ttlabel34.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel34.Name = "ttlabel34";
        this.ttlabel34.TabIndex = 17;

        this.ttlabel33 = new TTVisual.TTLabel();
        this.ttlabel33.Text = "29 - Ameliyat sonrası kritik gereksinimler gözden geçirildi mi?";
        this.ttlabel33.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel33.Name = "ttlabel33";
        this.ttlabel33.TabIndex = 16;

        this.ttlabel32 = new TTVisual.TTLabel();
        this.ttlabel32.Text = "28 - Hastadan alınan numune etiketinde";
        this.ttlabel32.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel32.Name = "ttlabel32";
        this.ttlabel32.TabIndex = 15;

        this.ttlabel31 = new TTVisual.TTLabel();
        this.ttlabel31.Text = "27 - Alet, spanç/kompres, iğne sayımları yapıldı mı?";
        this.ttlabel31.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel31.Name = "ttlabel31";
        this.ttlabel31.TabIndex = 14;

        this.ttlabel30 = new TTVisual.TTLabel();
        this.ttlabel30.Text = "26 - Gerçekleştirilen ameliyat için sözlü olarak";
        this.ttlabel30.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.ttlabel30.Name = "ttlabel30";
        this.ttlabel30.TabIndex = 13;

        this.labelOperatingRoomNurse = new TTVisual.TTLabel();
        this.labelOperatingRoomNurse.Text = "Ameliyathane Hemşiresi";
        this.labelOperatingRoomNurse.Font = "Name=Tahoma, Size=8,25, Units=3, GdiCharSet=1, GdiVerticalFont=False";
        this.labelOperatingRoomNurse.Name = "labelOperatingRoomNurse";
        this.labelOperatingRoomNurse.TabIndex = 12;

        this.OperatingRoomNurse = new TTVisual.TTObjectListBox();
        this.OperatingRoomNurse.ListDefName = "NurseListDefinition";
        this.OperatingRoomNurse.Name = "OperatingRoomNurse";
        this.OperatingRoomNurse.TabIndex = 11;

        this.ConfirmedAfterSurgeryClinic = new TTVisual.TTCheckBox();
        this.ConfirmedAfterSurgeryClinic.Value = false;
        this.ConfirmedAfterSurgeryClinic.Text = "Evet";
        this.ConfirmedAfterSurgeryClinic.Name = "ConfirmedAfterSurgeryClinic";
        this.ConfirmedAfterSurgeryClinic.TabIndex = 10;
        this.ConfirmedAfterSurgeryClinic.Title = "Evet";


        this.labelSurgeonSuggestions = new TTVisual.TTLabel();
        this.labelSurgeonSuggestions.Text = "Cerrahın Önerileri :";
        this.labelSurgeonSuggestions.Name = "labelSurgeonSuggestions";
        this.labelSurgeonSuggestions.TabIndex = 9;

        this.SurgeonSuggestions = new TTVisual.TTTextBox();
        this.SurgeonSuggestions.Name = "SurgeonSuggestions";
        this.SurgeonSuggestions.TabIndex = 8;
        this.SurgeonSuggestions.Multiline = true;
        this.SurgeonSuggestions.Height = "90px";

        this.labelAnesthetistSuggestions = new TTVisual.TTLabel();
        this.labelAnesthetistSuggestions.Text = "Anestezistin Önerileri :";
        this.labelAnesthetistSuggestions.Name = "labelAnesthetistSuggestions";
        this.labelAnesthetistSuggestions.TabIndex = 7;

        this.AnesthetistSuggestions = new TTVisual.TTTextBox();
        this.AnesthetistSuggestions.Name = "AnesthetistSuggestions";
        this.AnesthetistSuggestions.TabIndex = 6;
        this.AnesthetistSuggestions.Multiline = true;
        this.AnesthetistSuggestions.Height = "90px";

        this.SampleRegionOnSampleLabel = new TTVisual.TTCheckBox();
        this.SampleRegionOnSampleLabel.Value = false;
        this.SampleRegionOnSampleLabel.Text = "Numunenin alındığı bölge yazılı";
        this.SampleRegionOnSampleLabel.Name = "SampleRegionOnSampleLabel";
        this.SampleRegionOnSampleLabel.TabIndex = 5;

        this.PatientNameOnSampleLabel = new TTVisual.TTCheckBox();
        this.PatientNameOnSampleLabel.Value = false;
        this.PatientNameOnSampleLabel.Text = "Hastanın adı doğru yazılı";
        this.PatientNameOnSampleLabel.Name = "PatientNameOnSampleLabel";
        this.PatientNameOnSampleLabel.TabIndex = 4;
        this.PatientNameOnSampleLabel.Title = "Hastanın adı doğru yazılı";


        this.ToolSpongeNeedleCountsDone = new TTVisual.TTCheckBox();
        this.ToolSpongeNeedleCountsDone.Value = false;
        this.ToolSpongeNeedleCountsDone.Text = "Evet";
        this.ToolSpongeNeedleCountsDone.Name = "ToolSpongeNeedleCountsDone";
        this.ToolSpongeNeedleCountsDone.TabIndex = 3;
        this.ToolSpongeNeedleCountsDone.Title = "Evet";


        this.ConfirmedSurgeryAreaVerbally = new TTVisual.TTCheckBox();
        this.ConfirmedSurgeryAreaVerbally.Value = false;
        this.ConfirmedSurgeryAreaVerbally.Text = "Ameliyat Bölgesi teyit edildi";
        this.ConfirmedSurgeryAreaVerbally.Name = "ConfirmedSurgeryAreaVerbally";
        this.ConfirmedSurgeryAreaVerbally.TabIndex = 2;
        this.ConfirmedSurgeryAreaVerbally.Title = "Ameliyat Bölgesi teyit edildi";


        this.ConfirmedSurgeryVerbally = new TTVisual.TTCheckBox();
        this.ConfirmedSurgeryVerbally.Value = false;
        this.ConfirmedSurgeryVerbally.Text = "Yapılan ameliyat";
        this.ConfirmedSurgeryVerbally.Name = "ConfirmedSurgeryVerbally";
        this.ConfirmedSurgeryVerbally.TabIndex = 1;
        this.ConfirmedSurgeryVerbally.Title = "Yapılan ameliyat";


        this.ConfirmedPatientVerbally = new TTVisual.TTCheckBox();
        this.ConfirmedPatientVerbally.Value = false;
        this.ConfirmedPatientVerbally.Text = "Hasta";
        this.ConfirmedPatientVerbally.Name = "ConfirmedPatientVerbally";
        this.ConfirmedPatientVerbally.TabIndex = 0;
        this.ConfirmedPatientVerbally.Title = "Hasta";


        this.tttabcontrol1.Controls = [this.BeforeLeavingClinic, this.BeforeAnesthesia, this.BeforeSurgicalIncision, this.BeforeLeavingSurgery];
        this.BeforeLeavingClinic.Controls = [this.ttlabel15, this.ttlabel14, this.ttlabel13, this.ttlabel12, this.ttlabel11, this.ttlabel10, this.ttlabel9, this.ttlabel8, this.ttlabel7, this.labelClinicalNurse, this.ClinicalNurse, this.labelPatientClothesDescription, this.PatientClothesDescription, this.LabAndRadioTestsAvailable, this.MaterialPreparationChecked, this.labelOtherSpecialActionDescription, this.OtherSpecialActionDescription, this.OtherSpecialActionRequired, this.TreatmentProtocolRequired, this.CatheterizationRequired, this.VaricoseBandageRequired, this.LavmanRequired, this.IsPatientClothesReady, this.labelMakeupProstValItemDescription, this.MakeupProstValItemDescription, this.MakeupProsthesisValuableItem, this.labelSurgeryAreaShavedDescription, this.SurgeryAreaShavedDescription, this.SurgeryAreaShaved, this.labelPatientHungerDescription, this.PatientHungerDescription, this.IsPatientHungry, this.PatientConsentChecked, this.PatientSurgeryAreaVerified, this.PatientSurgeryVerified, this.PatientIDInfoVerified];
        this.BeforeAnesthesia.Controls = [this.labelAnesthesiologist, this.Anesthesiologist, this.ttlabel18, this.ttlabel17, this.ttlabel16, this.ttlabel6, this.ttlabel5, this.ttlabel4, this.ttlabel3, this.labelPatientAllergyDescription, this.PatientAllergyDescription, this.HasBloodLossRisk, this.HasImagingDevice, this.PatientHasAnAllergy, this.PulseOximeterWorksOut, this.AnesthesiaChecklistCompleted, this.HasSignInSurgeryArea, this.ConsentVerifiedByPatient, this.SugeryAreaVerifiedByPatient, this.SurgeryVerifiedByPatient, this.PatientIDVerifiedByPatient, this.ttlabel1];
        this.BeforeSurgicalIncision.Controls = [this.ttlabel26, this.ttlabel25, this.ttlabel24, this.ttlabel23, this.ttlabel22, this.ttlabel2, this.ttlabel21, this.ttlabel20, this.ttlabel19, this.labelSurgeryDoctor, this.SurgeryDoctor, this.TeamMemberInformedVerbally, this.NecessaryDeepVeinThrombosis, this.HasAnticoagulantUsage, this.NecessaryBloodSugarControl, this.SuitableMaterialSterilization, this.ReadyUsedMaterials, this.AppliedProphylacticAntibiotic, this.ReviewedPatientPosition, this.ReviewedPossibAnesthesiaRisk, this.ReviewedUnexpectedEvents, this.ReviewedExpectedBloodLoss, this.ReviewedEstimatedSurgeryTime, this.TeamMembersIntroThemselves];
        this.BeforeLeavingSurgery.Controls = [this.ttlabel34, this.ttlabel33, this.ttlabel32, this.ttlabel31, this.ttlabel30, this.labelOperatingRoomNurse, this.OperatingRoomNurse, this.ConfirmedAfterSurgeryClinic, this.labelSurgeonSuggestions, this.SurgeonSuggestions, this.labelAnesthetistSuggestions, this.AnesthetistSuggestions, this.SampleRegionOnSampleLabel, this.PatientNameOnSampleLabel, this.ToolSpongeNeedleCountsDone, this.ConfirmedSurgeryAreaVerbally, this.ConfirmedSurgeryVerbally, this.ConfirmedPatientVerbally];
        this.Controls = [this.tttabcontrol1, this.BeforeLeavingClinic, this.ttlabel15, this.ttlabel14, this.ttlabel13, this.ttlabel12, this.ttlabel11, this.ttlabel10, this.ttlabel9, this.ttlabel8, this.ttlabel7, this.labelClinicalNurse, this.ClinicalNurse, this.labelPatientClothesDescription, this.PatientClothesDescription, this.LabAndRadioTestsAvailable, this.MaterialPreparationChecked, this.labelOtherSpecialActionDescription, this.OtherSpecialActionDescription, this.OtherSpecialActionRequired, this.TreatmentProtocolRequired, this.CatheterizationRequired, this.VaricoseBandageRequired, this.LavmanRequired, this.IsPatientClothesReady, this.labelMakeupProstValItemDescription, this.MakeupProstValItemDescription, this.MakeupProsthesisValuableItem, this.labelSurgeryAreaShavedDescription, this.SurgeryAreaShavedDescription, this.SurgeryAreaShaved, this.labelPatientHungerDescription, this.PatientHungerDescription, this.IsPatientHungry, this.PatientConsentChecked, this.PatientSurgeryAreaVerified, this.PatientSurgeryVerified, this.PatientIDInfoVerified, this.BeforeAnesthesia, this.labelAnesthesiologist, this.Anesthesiologist, this.ttlabel18, this.ttlabel17, this.ttlabel16, this.ttlabel6, this.ttlabel5, this.ttlabel4, this.ttlabel3, this.labelPatientAllergyDescription, this.PatientAllergyDescription, this.HasBloodLossRisk, this.HasImagingDevice, this.PatientHasAnAllergy, this.PulseOximeterWorksOut, this.AnesthesiaChecklistCompleted, this.HasSignInSurgeryArea, this.ConsentVerifiedByPatient, this.SugeryAreaVerifiedByPatient, this.SurgeryVerifiedByPatient, this.PatientIDVerifiedByPatient, this.ttlabel1, this.BeforeSurgicalIncision, this.ttlabel26, this.ttlabel25, this.ttlabel24, this.ttlabel23, this.ttlabel22, this.ttlabel2, this.ttlabel21, this.ttlabel20, this.ttlabel19, this.labelSurgeryDoctor, this.SurgeryDoctor, this.TeamMemberInformedVerbally, this.NecessaryDeepVeinThrombosis, this.HasAnticoagulantUsage, this.NecessaryBloodSugarControl, this.SuitableMaterialSterilization, this.ReadyUsedMaterials, this.AppliedProphylacticAntibiotic, this.ReviewedPatientPosition, this.ReviewedPossibAnesthesiaRisk, this.ReviewedUnexpectedEvents, this.ReviewedExpectedBloodLoss, this.ReviewedEstimatedSurgeryTime, this.TeamMembersIntroThemselves, this.BeforeLeavingSurgery, this.ttlabel34, this.ttlabel33, this.ttlabel32, this.ttlabel31, this.ttlabel30, this.labelOperatingRoomNurse, this.OperatingRoomNurse, this.ConfirmedAfterSurgeryClinic, this.labelSurgeonSuggestions, this.SurgeonSuggestions, this.labelAnesthetistSuggestions, this.AnesthetistSuggestions, this.SampleRegionOnSampleLabel, this.PatientNameOnSampleLabel, this.ToolSpongeNeedleCountsDone, this.ConfirmedSurgeryAreaVerbally, this.ConfirmedSurgeryVerbally, this.ConfirmedPatientVerbally];

    }


}
