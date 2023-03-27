//$86CC8FB7
import { Component, OnInit  } from '@angular/core';
import { LowerExtremityFormViewModel } from './LowerExtremityFormViewModel';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { MessageService } from 'Fw/Services/MessageService';
import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { BaseHCExaminationDynamicObjectForm } from "Modules/Tibbi_Surec/Saglik_Kurulu_Modulu/BaseHCExaminationDynamicObjectForm";
import { LowerExtremity } from 'NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'LowerExtremityForm',
    templateUrl: './LowerExtremityForm.html',
    providers: [MessageService]
})
export class LowerExtremityForm extends BaseHCExaminationDynamicObjectForm implements OnInit {
    ATS_CauseOfInjury: TTVisual.ITTTextBox;
    ATS_ChairNumber: TTVisual.ITTTextBox;
    ATS_ChairType: TTVisual.ITTTextBox;
    ATS_DeliveryDate: TTVisual.ITTTextBox;
    ATS_HD_Cardiovascular: TTVisual.ITTEnumComboBox;
    ATS_HD_Cardiovascular_Desc: TTVisual.ITTTextBox;
    ATS_HD_ChairDistance: TTVisual.ITTTextBox;
    ATS_HD_ChairModel: TTVisual.ITTEnumComboBox;
    ATS_HD_ChairModel_Desc: TTVisual.ITTTextBox;
    ATS_HD_ConstantCondition: TTVisual.ITTEnumComboBox;
    ATS_HD_ConstantCondition_Desc: TTVisual.ITTTextBox;
    ATS_HD_Contracture: TTVisual.ITTEnumComboBox;
    ATS_HD_Contracture_Desc: TTVisual.ITTTextBox;
    ATS_HD_Deformity: TTVisual.ITTEnumComboBox;
    ATS_HD_Deformity_Desc: TTVisual.ITTTextBox;
    ATS_HD_INTRACOMMUNITY: TTVisual.ITTCheckBox;
    ATS_HD_NOAMBULATION: TTVisual.ITTCheckBox;
    ATS_HD_OrganFailure: TTVisual.ITTEnumComboBox;
    ATS_HD_OrganFailure_Desc: TTVisual.ITTTextBox;
    ATS_HD_Pulmonary: TTVisual.ITTEnumComboBox;
    ATS_HD_Pulmonary_Desc: TTVisual.ITTTextBox;
    ATS_HD_Therapeutic: TTVisual.ITTCheckBox;
    ATS_HD_UseHimself: TTVisual.ITTEnumComboBox;
    ATS_HD_UseHimself_Desc: TTVisual.ITTTextBox;
    ATS_HD_USELOWEREXTREMITIES: TTVisual.ITTEnumComboBox;
    ATS_HD_UseLowerExtremity_Desc: TTVisual.ITTTextBox;
    ATS_RI_Date: TTVisual.ITTEnumComboBox;
    ATS_RI_DiagnosAndICD10Code: TTVisual.ITTEnumComboBox;
    ATS_RI_MachineName: TTVisual.ITTEnumComboBox;
    ATS_RI_MedulaInsCode: TTVisual.ITTEnumComboBox;
    ATS_RI_MedulaOrProtocolNo: TTVisual.ITTEnumComboBox;
    ATS_RI_PatientNameSurname: TTVisual.ITTEnumComboBox;
    ATS_RI_WetSignature: TTVisual.ITTEnumComboBox;
    ATS_SK_ChairType: TTVisual.ITTTextBox;
    ATS_SK_FTRExpertApprove: TTVisual.ITTEnumComboBox;
    ATS_SK_HeadDoctorApprove: TTVisual.ITTEnumComboBox;
    ATS_SK_MedicalReason: TTVisual.ITTTextBox;
    ATS_SK_OrthopedicExpApprove: TTVisual.ITTEnumComboBox;
    ATS_SK_ThirdStepHealthInst: TTVisual.ITTEnumComboBox;
    labelATS_CauseOfInjury: TTVisual.ITTLabel;
    labelATS_ChairNumber: TTVisual.ITTLabel;
    labelATS_ChairType: TTVisual.ITTLabel;
    labelATS_DeliveryDate: TTVisual.ITTLabel;
    labelATS_HD_Cardiovascular: TTVisual.ITTLabel;
    labelATS_HD_Cardiovascular_Desc: TTVisual.ITTLabel;
    labelATS_HD_ChairDistance: TTVisual.ITTLabel;
    labelATS_HD_ChairModel: TTVisual.ITTLabel;
    labelATS_HD_ChairModel_Desc: TTVisual.ITTLabel;
    labelATS_HD_ConstantCondition: TTVisual.ITTLabel;
    labelATS_HD_ConstantCondition_Desc: TTVisual.ITTLabel;
    labelATS_HD_Contracture: TTVisual.ITTLabel;
    labelATS_HD_Contracture_Desc: TTVisual.ITTLabel;
    labelATS_HD_Deformity: TTVisual.ITTLabel;
    labelATS_HD_Deformity_Desc: TTVisual.ITTLabel;
    labelATS_HD_OrganFailure: TTVisual.ITTLabel;
    labelATS_HD_OrganFailure_Desc: TTVisual.ITTLabel;
    labelATS_HD_Pulmonary: TTVisual.ITTLabel;
    labelATS_HD_Pulmonary_Desc: TTVisual.ITTLabel;
    labelATS_HD_UseHimself: TTVisual.ITTLabel;
    labelATS_HD_UseHimself_Desc: TTVisual.ITTLabel;
    labelATS_HD_USELOWEREXTREMITIES: TTVisual.ITTLabel;
    labelATS_HD_UseLowerExtremity_Desc: TTVisual.ITTLabel;
    labelATS_RI_Date: TTVisual.ITTLabel;
    labelATS_RI_DiagnosAndICD10Code: TTVisual.ITTLabel;
    labelATS_RI_MachineName: TTVisual.ITTLabel;
    labelATS_RI_MedulaInsCode: TTVisual.ITTLabel;
    labelATS_RI_MedulaOrProtocolNo: TTVisual.ITTLabel;
    labelATS_RI_PatientNameSurname: TTVisual.ITTLabel;
    labelATS_RI_WetSignature: TTVisual.ITTLabel;
    labelATS_SK_ChairType: TTVisual.ITTLabel;
    labelATS_SK_FTRExpertApprove: TTVisual.ITTLabel;
    labelATS_SK_HeadDoctorApprove: TTVisual.ITTLabel;
    labelATS_SK_MedicalReason: TTVisual.ITTLabel;
    labelATS_SK_OrthopedicExpApprove: TTVisual.ITTLabel;
    labelATS_SK_ThirdStepHealthInst: TTVisual.ITTLabel;
    labelLE_AmputationDate: TTVisual.ITTLabel;
    labelLE_CauseOfInjury: TTVisual.ITTLabel;
    labelLE_ConstructionDate: TTVisual.ITTLabel;
    labelLE_DiagnosAndICD10Code: TTVisual.ITTLabel;
    labelLE_FTRExpertApprove: TTVisual.ITTLabel;
    labelLE_HD_AktivityLevel: TTVisual.ITTLabel;
    labelLE_HD_Ambulation: TTVisual.ITTLabel;
    labelLE_HD_Ambulation_Desc: TTVisual.ITTLabel;
    labelLE_HD_Cardiovascular: TTVisual.ITTLabel;
    labelLE_HD_Cardiovascular_Desc: TTVisual.ITTLabel;
    labelLE_HD_Contracture: TTVisual.ITTLabel;
    labelLE_HD_Contracture_Desc: TTVisual.ITTLabel;
    labelLE_HD_Musculoskeletal: TTVisual.ITTLabel;
    labelLE_HD_Musculoskeletal_Desc: TTVisual.ITTLabel;
    labelLE_HD_Neurological: TTVisual.ITTLabel;
    labelLE_HD_Neurological_Desc: TTVisual.ITTLabel;
    labelLE_HD_OrganFailure: TTVisual.ITTLabel;
    labelLE_HD_OrganFailure_Desc: TTVisual.ITTLabel;
    labelLE_HD_PreferencePetition: TTVisual.ITTLabel;
    labelLE_HD_PreferencePetition_Desc: TTVisual.ITTLabel;
    labelLE_HD_Pulmonary: TTVisual.ITTLabel;
    labelLE_HD_Pulmonary_Desc: TTVisual.ITTLabel;
    labelLE_HD_SingleSideAmputate: TTVisual.ITTLabel;
    labelLE_HD_SingleSideAmputate_Desc: TTVisual.ITTLabel;
    labelLE_HD_StumpZone: TTVisual.ITTLabel;
    labelLE_HD_StumpZone_Desc: TTVisual.ITTLabel;
    labelLE_HD_SystemicDisease: TTVisual.ITTLabel;
    labelLE_HD_SystemicDisease_Desc: TTVisual.ITTLabel;
    labelLE_HD_WeightTolerance: TTVisual.ITTLabel;
    labelLE_HD_WeightTolerance_desc: TTVisual.ITTLabel;
    labelLE_HeadDoctorApprove: TTVisual.ITTLabel;
    labelLE_MachineName: TTVisual.ITTLabel;
    labelLE_MachineNameIsCorrect: TTVisual.ITTLabel;
    labelLE_MedicalReason: TTVisual.ITTLabel;
    labelLE_MedulaInsCode: TTVisual.ITTLabel;
    labelLE_MedulaOrProtocolNo: TTVisual.ITTLabel;
    labelLE_OrthopedicExpertApprove: TTVisual.ITTLabel;
    labelLE_PatientNameSurname: TTVisual.ITTLabel;
    labelLE_ProsthesisNumber: TTVisual.ITTLabel;
    labelLE_ProstheticType: TTVisual.ITTLabel;
    labelLE_PsychiatricExpertApprove: TTVisual.ITTLabel;
    labelLE_SK_ProstheticType: TTVisual.ITTLabel;
    labelLE_TEM_Oscillationand_Desc: TTVisual.ITTLabel;
    labelLE_TEM_OscillationandPosture: TTVisual.ITTLabel;
    labelLE_TEM_StepClimbing: TTVisual.ITTLabel;
    labelLE_TEM_StepClimbing_Desc: TTVisual.ITTLabel;
    labelLE_TEM_StrideLength: TTVisual.ITTLabel;
    labelLE_TEM_StrideLength_Desc: TTVisual.ITTLabel;
    labelLE_TEM_WalkBackwards: TTVisual.ITTLabel;
    labelLE_TEM_WalkBackwards_Desc: TTVisual.ITTLabel;
    labelLE_TEM_WalkingSpeed: TTVisual.ITTLabel;
    labelLE_TEM_WalkingSpeed_Desc: TTVisual.ITTLabel;
    labelLE_TEM_Waterproof: TTVisual.ITTLabel;
    labelLE_TEM_Waterproof_Desc: TTVisual.ITTLabel;
    labelLE_TEM_WhichLevel: TTVisual.ITTLabel;
    labelLE_ThirdStepHealthInst: TTVisual.ITTLabel;
    labelLE_WetSignature: TTVisual.ITTLabel;
    labelUE_AmputationDate: TTVisual.ITTLabel;
    labelUE_CauseOfInjury: TTVisual.ITTLabel;
    labelUE_ConstructionDate: TTVisual.ITTLabel;
    labelUE_HD_AmputationLevel: TTVisual.ITTLabel;
    labelUE_HD_Cardiovascular: TTVisual.ITTLabel;
    labelUE_HD_Cardiovascular_Desc: TTVisual.ITTLabel;
    labelUE_HD_Contracture: TTVisual.ITTLabel;
    labelUE_HD_Contracture_Desc: TTVisual.ITTLabel;
    labelUE_HD_FunctionalMovement_Desc: TTVisual.ITTLabel;
    labelUE_HD_FunctionalMovements: TTVisual.ITTLabel;
    labelUE_HD_Musculoskeletal: TTVisual.ITTLabel;
    labelUE_HD_Musculoskeletal_Desc: TTVisual.ITTLabel;
    labelUE_HD_Myoelectric: TTVisual.ITTLabel;
    labelUE_HD_Neurological: TTVisual.ITTLabel;
    labelUE_HD_Neurological_Desc: TTVisual.ITTLabel;
    labelUE_HD_OrganFailure: TTVisual.ITTLabel;
    labelUE_HD_OrganFailure_Desc: TTVisual.ITTLabel;
    labelUE_HD_PreferencePetition: TTVisual.ITTLabel;
    labelUE_HD_Pulmonary: TTVisual.ITTLabel;
    labelUE_HD_Pulmonary_Desc: TTVisual.ITTLabel;
    labelUE_HD_SingleSideAmputate: TTVisual.ITTLabel;
    labelUE_HD_SingleSideAmputate_Desc: TTVisual.ITTLabel;
    labelUE_HD_StumpLength: TTVisual.ITTLabel;
    labelUE_HD_StumpZone: TTVisual.ITTLabel;
    labelUE_HD_StumpZone_Desc: TTVisual.ITTLabel;
    labelUE_HD_SufficientStump_Desc: TTVisual.ITTLabel;
    labelUE_HD_SufficientStumpLength: TTVisual.ITTLabel;
    labelUE_HD_SystemicDisease: TTVisual.ITTLabel;
    labelUE_HD_SystemicDisease_Desc: TTVisual.ITTLabel;
    labelUE_ProsthesisNumber: TTVisual.ITTLabel;
    labelUE_ProstheticType: TTVisual.ITTLabel;
    labelUE_RI_Date: TTVisual.ITTLabel;
    labelUE_RI_DiagnosAndICD10Code: TTVisual.ITTLabel;
    labelUE_RI_MachineName: TTVisual.ITTLabel;
    labelUE_RI_MachineNameIsCorrect: TTVisual.ITTLabel;
    labelUE_RI_MedulaInsCode: TTVisual.ITTLabel;
    labelUE_RI_MedulaOrProtocolNo: TTVisual.ITTLabel;
    labelUE_RI_PatientNameSurname: TTVisual.ITTLabel;
    labelUE_RI_WetSignature: TTVisual.ITTLabel;
    labelUE_SK_FTRExpertApprove: TTVisual.ITTLabel;
    labelUE_SK_HeadDoctorApprove: TTVisual.ITTLabel;
    labelUE_SK_MedicalReason: TTVisual.ITTLabel;
    labelUE_SK_OrthopedicExpApprove: TTVisual.ITTLabel;
    labelUE_SK_ProstheticType: TTVisual.ITTLabel;
    labelUE_SK_PsychiatricExpApprove: TTVisual.ITTLabel;
    labelUE_SK_sEMG: TTVisual.ITTLabel;
    labelUE_SK_ThirdStepHealthInst: TTVisual.ITTLabel;
    LE_AmputationDate: TTVisual.ITTTextBox;
    LE_CauseOfInjury: TTVisual.ITTTextBox;
    LE_ConstructionDate: TTVisual.ITTTextBox;
    LE_DiagnosAndICD10Code: TTVisual.ITTEnumComboBox;
    LE_FTRExpertApprove: TTVisual.ITTEnumComboBox;
    LE_HD_AktivityLevel: TTVisual.ITTTextBox;
    LE_HD_Ambulation: TTVisual.ITTEnumComboBox;
    LE_HD_Ambulation_Desc: TTVisual.ITTTextBox;
    LE_HD_Cardiovascular: TTVisual.ITTEnumComboBox;
    LE_HD_Cardiovascular_Desc: TTVisual.ITTTextBox;
    LE_HD_Contracture: TTVisual.ITTEnumComboBox;
    LE_HD_Contracture_Desc: TTVisual.ITTTextBox;
    LE_HD_Musculoskeletal: TTVisual.ITTEnumComboBox;
    LE_HD_Musculoskeletal_Desc: TTVisual.ITTTextBox;
    LE_HD_Neurological: TTVisual.ITTEnumComboBox;
    LE_HD_Neurological_Desc: TTVisual.ITTTextBox;
    LE_HD_OrganFailure: TTVisual.ITTEnumComboBox;
    LE_HD_OrganFailure_Desc: TTVisual.ITTTextBox;
    LE_HD_PreferencePetition: TTVisual.ITTEnumComboBox;
    LE_HD_PreferencePetition_Desc: TTVisual.ITTTextBox;
    LE_HD_Pulmonary: TTVisual.ITTEnumComboBox;
    LE_HD_Pulmonary_Desc: TTVisual.ITTTextBox;
    LE_HD_SingleSideAmputate: TTVisual.ITTEnumComboBox;
    LE_HD_SingleSideAmputate_Desc: TTVisual.ITTTextBox;
    LE_HD_StumpZone: TTVisual.ITTEnumComboBox;
    LE_HD_StumpZone_Desc: TTVisual.ITTTextBox;
    LE_HD_SystemicDisease: TTVisual.ITTEnumComboBox;
    LE_HD_SystemicDisease_Desc: TTVisual.ITTTextBox;
    LE_HD_WeightTolerance: TTVisual.ITTEnumComboBox;
    LE_HD_WeightTolerance_desc: TTVisual.ITTTextBox;
    LE_HeadDoctorApprove: TTVisual.ITTEnumComboBox;
    LE_MachineName: TTVisual.ITTEnumComboBox;
    LE_MachineNameIsCorrect: TTVisual.ITTEnumComboBox;
    LE_MedicalReason: TTVisual.ITTEnumComboBox;
    LE_MedulaInsCode: TTVisual.ITTEnumComboBox;
    LE_MedulaOrProtocolNo: TTVisual.ITTEnumComboBox;
    LE_OrthopedicExpertApprove: TTVisual.ITTEnumComboBox;
    LE_PatientNameSurname: TTVisual.ITTEnumComboBox;
    LE_ProsthesisNumber: TTVisual.ITTTextBox;
    LE_ProstheticType: TTVisual.ITTTextBox;
    LE_PsychiatricExpertApprove: TTVisual.ITTEnumComboBox;
    LE_SK_ProstheticType: TTVisual.ITTTextBox;
    LE_TEM_Oscillationand_Desc: TTVisual.ITTTextBox;
    LE_TEM_OscillationandPosture: TTVisual.ITTEnumComboBox;
    LE_TEM_StepClimbing: TTVisual.ITTEnumComboBox;
    LE_TEM_StepClimbing_Desc: TTVisual.ITTTextBox;
    LE_TEM_StrideLength: TTVisual.ITTEnumComboBox;
    LE_TEM_StrideLength_Desc: TTVisual.ITTTextBox;
    LE_TEM_WalkBackwards: TTVisual.ITTEnumComboBox;
    LE_TEM_WalkBackwards_Desc: TTVisual.ITTTextBox;
    LE_TEM_WalkingSpeed: TTVisual.ITTEnumComboBox;
    LE_TEM_WalkingSpeed_Desc: TTVisual.ITTTextBox;
    LE_TEM_Waterproof: TTVisual.ITTEnumComboBox;
    LE_TEM_Waterproof_Desc: TTVisual.ITTTextBox;
    LE_TEM_WhichLevel: TTVisual.ITTTextBox;
    LE_ThirdStepHealthInst: TTVisual.ITTEnumComboBox;
    LE_WetSignature: TTVisual.ITTEnumComboBox;
    ttgroupbox1: TTVisual.ITTGroupBox;
    ttgroupbox10: TTVisual.ITTGroupBox;
    ttgroupbox2: TTVisual.ITTGroupBox;
    ttgroupbox3: TTVisual.ITTGroupBox;
    ttgroupbox4: TTVisual.ITTGroupBox;
    ttgroupbox5: TTVisual.ITTGroupBox;
    ttgroupbox6: TTVisual.ITTGroupBox;
    ttgroupbox7: TTVisual.ITTGroupBox;
    ttgroupbox8: TTVisual.ITTGroupBox;
    ttgroupbox9: TTVisual.ITTGroupBox;
    ttlabel1: TTVisual.ITTLabel;
    tttabcontrol1: TTVisual.ITTTabControl;
    tttabpage1: TTVisual.ITTTabPage;
    tttabpage2: TTVisual.ITTTabPage;
    tttabpage3: TTVisual.ITTTabPage;
    UE_AmputationDate: TTVisual.ITTTextBox;
    UE_CauseOfInjury: TTVisual.ITTTextBox;
    UE_ConstructionDate: TTVisual.ITTTextBox;
    UE_HD_AmputationLevel: TTVisual.ITTTextBox;
    UE_HD_Cardiovascular: TTVisual.ITTEnumComboBox;
    UE_HD_Cardiovascular_Desc: TTVisual.ITTTextBox;
    UE_HD_Contracture: TTVisual.ITTEnumComboBox;
    UE_HD_Contracture_Desc: TTVisual.ITTTextBox;
    UE_HD_FunctionalMovement_Desc: TTVisual.ITTTextBox;
    UE_HD_FunctionalMovements: TTVisual.ITTEnumComboBox;
    UE_HD_Musculoskeletal: TTVisual.ITTEnumComboBox;
    UE_HD_Musculoskeletal_Desc: TTVisual.ITTTextBox;
    UE_HD_Myoelectric: TTVisual.ITTEnumComboBox;
    UE_HD_Neurological: TTVisual.ITTEnumComboBox;
    UE_HD_Neurological_Desc: TTVisual.ITTTextBox;
    UE_HD_OrganFailure: TTVisual.ITTEnumComboBox;
    UE_HD_OrganFailure_Desc: TTVisual.ITTTextBox;
    UE_HD_PreferencePetition: TTVisual.ITTEnumComboBox;
    UE_HD_PreferencePetition_Desc: TTVisual.ITTTextBox;
    UE_HD_Pulmonary: TTVisual.ITTEnumComboBox;
    UE_HD_Pulmonary_Desc: TTVisual.ITTTextBox;
    UE_HD_SingleSideAmputate: TTVisual.ITTEnumComboBox;
    UE_HD_SingleSideAmputate_Desc: TTVisual.ITTTextBox;
    UE_HD_StumpLength: TTVisual.ITTTextBox;
    UE_HD_StumpZone: TTVisual.ITTEnumComboBox;
    UE_HD_StumpZone_Desc: TTVisual.ITTTextBox;
    UE_HD_SufficientStump_Desc: TTVisual.ITTTextBox;
    UE_HD_SufficientStumpLength: TTVisual.ITTEnumComboBox;
    UE_HD_SystemicDisease: TTVisual.ITTEnumComboBox;
    UE_HD_SystemicDisease_Desc: TTVisual.ITTTextBox;
    UE_ProsthesisNumber: TTVisual.ITTTextBox;
    UE_ProstheticType: TTVisual.ITTTextBox;
    UE_RI_Date: TTVisual.ITTEnumComboBox;
    UE_RI_DiagnosAndICD10Code: TTVisual.ITTEnumComboBox;
    UE_RI_MachineName: TTVisual.ITTEnumComboBox;
    UE_RI_MachineNameIsCorrect: TTVisual.ITTEnumComboBox;
    UE_RI_MedulaInsCode: TTVisual.ITTEnumComboBox;
    UE_RI_MedulaOrProtocolNo: TTVisual.ITTEnumComboBox;
    UE_RI_PatientNameSurname: TTVisual.ITTEnumComboBox;
    UE_RI_WetSignature: TTVisual.ITTEnumComboBox;
    UE_SK_FTRExpertApprove: TTVisual.ITTEnumComboBox;
    UE_SK_HeadDoctorApprove: TTVisual.ITTEnumComboBox;
    UE_SK_MedicalReason: TTVisual.ITTEnumComboBox;
    UE_SK_OrthopedicExpApprove: TTVisual.ITTEnumComboBox;
    UE_SK_ProstheticType: TTVisual.ITTTextBox;
    UE_SK_PsychiatricExpApprove: TTVisual.ITTEnumComboBox;
    UE_SK_sEMG: TTVisual.ITTEnumComboBox;
    UE_SK_ThirdStepHealthInst: TTVisual.ITTEnumComboBox;
    public lowerExtremityFormViewModel: LowerExtremityFormViewModel = new LowerExtremityFormViewModel();
    public get _LowerExtremity(): LowerExtremity {
        return this._TTObject as LowerExtremity;
    }

    public IsFormReadOnly: boolean = false;
    private LowerExtremityForm_DocumentUrl: string = '/api/LowerExtremityService/LowerExtremityForm';
    constructor(protected httpService: NeHttpService, protected messageService: MessageService) {
        super(httpService, messageService);
        this._DocumentServiceUrl = this.LowerExtremityForm_DocumentUrl;
        this.initViewModel();
        this.initFormControls();
    }

    public setInputParam(value: any) {
        if (value != null && value != undefined) {
            this.IsFormReadOnly = value.IsReadOnly as boolean;
        }

        //if (value != null && value['readOnlyByCode'] != null) {
        //    this.IsFormReadOnly = value['readOnlyByCode'];
        //}

    }


    // ***** Method declarations start *****
    protected async PreScript() {
        this._ViewModel;
        super.PreScript();
    }

    protected async ClientSidePreScript(): Promise<void> {

        super.ClientSidePreScript();
        if (this.IsFormReadOnly) {
            this.ReadOnly = true;
            this.lowerExtremityFormViewModel.ReadOnly = true;
        }
    }

    // *****Method declarations end *****

    public initViewModel(): void {
        this._TTObject = new LowerExtremity();
        this.lowerExtremityFormViewModel = new LowerExtremityFormViewModel();
        this._ViewModel = this.lowerExtremityFormViewModel;
        this.lowerExtremityFormViewModel._LowerExtremity = this._TTObject as LowerExtremity;

        this.ReadOnly = false;
    }

    protected loadViewModel() {
        let that = this;
        that.lowerExtremityFormViewModel = this._ViewModel as LowerExtremityFormViewModel;
        that._TTObject = this.lowerExtremityFormViewModel._LowerExtremity;
        if (this.lowerExtremityFormViewModel == null)
            this.lowerExtremityFormViewModel = new LowerExtremityFormViewModel();
        if (this.lowerExtremityFormViewModel._LowerExtremity == null)
            this.lowerExtremityFormViewModel._LowerExtremity = new LowerExtremity();

    }

    async ngOnInit() {
        let that = this;
        await this.load(LowerExtremityFormViewModel);
        //this.ngZone.onStable.first().subscribe(r => {
        //    that.updateModifiedState();
        //});
    }
    public onATS_CauseOfInjuryChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_CauseOfInjury != event) {
            this._LowerExtremity.ATS_CauseOfInjury = event;
        }
    }

    public onATS_ChairNumberChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_ChairNumber != event) {
            this._LowerExtremity.ATS_ChairNumber = event;
        }
    }

    public onATS_ChairTypeChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_ChairType != event) {
            this._LowerExtremity.ATS_ChairType = event;
        }
    }

    public onATS_DeliveryDateChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_DeliveryDate != event) {
            this._LowerExtremity.ATS_DeliveryDate = event;
        }
    }

    public onATS_HD_Cardiovascular_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_Cardiovascular_Desc != event) {
            this._LowerExtremity.ATS_HD_Cardiovascular_Desc = event;
        }
    }

    public onATS_HD_CardiovascularChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_Cardiovascular != event) {
            this._LowerExtremity.ATS_HD_Cardiovascular = event;
        }
    }

    public onATS_HD_ChairDistanceChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_ChairDistance != event) {
            this._LowerExtremity.ATS_HD_ChairDistance = event;
        }
    }

    public onATS_HD_ChairModel_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_ChairModel_Desc != event) {
            this._LowerExtremity.ATS_HD_ChairModel_Desc = event;
        }
    }

    public onATS_HD_ChairModelChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_ChairModel != event) {
            this._LowerExtremity.ATS_HD_ChairModel = event;
        }
    }

    public onATS_HD_ConstantCondition_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_ConstantCondition_Desc != event) {
            this._LowerExtremity.ATS_HD_ConstantCondition_Desc = event;
        }
    }

    public onATS_HD_ConstantConditionChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_ConstantCondition != event) {
            this._LowerExtremity.ATS_HD_ConstantCondition = event;
        }
    }

    public onATS_HD_Contracture_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_Contracture_Desc != event) {
            this._LowerExtremity.ATS_HD_Contracture_Desc = event;
        }
    }

    public onATS_HD_ContractureChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_Contracture != event) {
            this._LowerExtremity.ATS_HD_Contracture = event;
        }
    }

    public onATS_HD_Deformity_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_Deformity_Desc != event) {
            this._LowerExtremity.ATS_HD_Deformity_Desc = event;
        }
    }

    public onATS_HD_DeformityChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_Deformity != event) {
            this._LowerExtremity.ATS_HD_Deformity = event;
        }
    }

    public onATS_HD_INTRACOMMUNITYChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_INTRACOMMUNITY != event) {
            this._LowerExtremity.ATS_HD_INTRACOMMUNITY = event;
        }
    }

    public onATS_HD_NOAMBULATIONChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_NOAMBULATION != event) {
            this._LowerExtremity.ATS_HD_NOAMBULATION = event;
        }
    }

    public onATS_HD_OrganFailure_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_OrganFailure_Desc != event) {
            this._LowerExtremity.ATS_HD_OrganFailure_Desc = event;
        }
    }

    public onATS_HD_OrganFailureChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_OrganFailure != event) {
            this._LowerExtremity.ATS_HD_OrganFailure = event;
        }
    }

    public onATS_HD_Pulmonary_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_Pulmonary_Desc != event) {
            this._LowerExtremity.ATS_HD_Pulmonary_Desc = event;
        }
    }

    public onATS_HD_PulmonaryChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_Pulmonary != event) {
            this._LowerExtremity.ATS_HD_Pulmonary = event;
        }
    }

    public onATS_HD_TherapeuticChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_Therapeutic != event) {
            this._LowerExtremity.ATS_HD_Therapeutic = event;
        }
    }

    public onATS_HD_UseHimself_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_UseHimself_Desc != event) {
            this._LowerExtremity.ATS_HD_UseHimself_Desc = event;
        }
    }

    public onATS_HD_UseHimselfChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_UseHimself != event) {
            this._LowerExtremity.ATS_HD_UseHimself = event;
        }
    }

    public onATS_HD_USELOWEREXTREMITIESChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_USELOWEREXTREMITIES != event) {
            this._LowerExtremity.ATS_HD_USELOWEREXTREMITIES = event;
        }
    }

    public onATS_HD_UseLowerExtremity_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_HD_UseLowerExtremity_Desc != event) {
            this._LowerExtremity.ATS_HD_UseLowerExtremity_Desc = event;
        }
    }

    public onATS_RI_DateChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_RI_Date != event) {
            this._LowerExtremity.ATS_RI_Date = event;
        }
    }

    public onATS_RI_DiagnosAndICD10CodeChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_RI_DiagnosAndICD10Code != event) {
            this._LowerExtremity.ATS_RI_DiagnosAndICD10Code = event;
        }
    }

    public onATS_RI_MachineNameChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_RI_MachineName != event) {
            this._LowerExtremity.ATS_RI_MachineName = event;
        }
    }

    public onATS_RI_MedulaInsCodeChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_RI_MedulaInsCode != event) {
            this._LowerExtremity.ATS_RI_MedulaInsCode = event;
        }
    }

    public onATS_RI_MedulaOrProtocolNoChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_RI_MedulaOrProtocolNo != event) {
            this._LowerExtremity.ATS_RI_MedulaOrProtocolNo = event;
        }
    }

    public onATS_RI_PatientNameSurnameChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_RI_PatientNameSurname != event) {
            this._LowerExtremity.ATS_RI_PatientNameSurname = event;
        }
    }

    public onATS_RI_WetSignatureChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_RI_WetSignature != event) {
            this._LowerExtremity.ATS_RI_WetSignature = event;
        }
    }

    public onATS_SK_ChairTypeChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_SK_ChairType != event) {
            this._LowerExtremity.ATS_SK_ChairType = event;
        }
    }

    public onATS_SK_FTRExpertApproveChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_SK_FTRExpertApprove != event) {
            this._LowerExtremity.ATS_SK_FTRExpertApprove = event;
        }
    }

    public onATS_SK_HeadDoctorApproveChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_SK_HeadDoctorApprove != event) {
            this._LowerExtremity.ATS_SK_HeadDoctorApprove = event;
        }
    }

    public onATS_SK_MedicalReasonChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_SK_MedicalReason != event) {
            this._LowerExtremity.ATS_SK_MedicalReason = event;
        }
    }

    public onATS_SK_OrthopedicExpApproveChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_SK_OrthopedicExpApprove != event) {
            this._LowerExtremity.ATS_SK_OrthopedicExpApprove = event;
        }
    }

    public onATS_SK_ThirdStepHealthInstChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.ATS_SK_ThirdStepHealthInst != event) {
            this._LowerExtremity.ATS_SK_ThirdStepHealthInst = event;
        }
    }

    public onLE_AmputationDateChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_AmputationDate != event) {
            this._LowerExtremity.LE_AmputationDate = event;
        }
    }

    public onLE_CauseOfInjuryChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_CauseOfInjury != event) {
            this._LowerExtremity.LE_CauseOfInjury = event;
        }
    }

    public onLE_ConstructionDateChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_ConstructionDate != event) {
            this._LowerExtremity.LE_ConstructionDate = event;
        }
    }

    public onLE_DiagnosAndICD10CodeChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_DiagnosAndICD10Code != event) {
            this._LowerExtremity.LE_DiagnosAndICD10Code = event;
        }
    }

    public onLE_FTRExpertApproveChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_FTRExpertApprove != event) {
            this._LowerExtremity.LE_FTRExpertApprove = event;
        }
    }

    public onLE_HD_AktivityLevelChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_AktivityLevel != event) {
            this._LowerExtremity.LE_HD_AktivityLevel = event;
        }
    }

    public onLE_HD_Ambulation_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_Ambulation_Desc != event) {
            this._LowerExtremity.LE_HD_Ambulation_Desc = event;
        }
    }

    public onLE_HD_AmbulationChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_Ambulation != event) {
            this._LowerExtremity.LE_HD_Ambulation = event;
        }
    }

    public onLE_HD_Cardiovascular_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_Cardiovascular_Desc != event) {
            this._LowerExtremity.LE_HD_Cardiovascular_Desc = event;
        }
    }

    public onLE_HD_CardiovascularChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_Cardiovascular != event) {
            this._LowerExtremity.LE_HD_Cardiovascular = event;
        }
    }

    public onLE_HD_Contracture_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_Contracture_Desc != event) {
            this._LowerExtremity.LE_HD_Contracture_Desc = event;
        }
    }

    public onLE_HD_ContractureChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_Contracture != event) {
            this._LowerExtremity.LE_HD_Contracture = event;
        }
    }

    public onLE_HD_Musculoskeletal_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_Musculoskeletal_Desc != event) {
            this._LowerExtremity.LE_HD_Musculoskeletal_Desc = event;
        }
    }

    public onLE_HD_MusculoskeletalChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_Musculoskeletal != event) {
            this._LowerExtremity.LE_HD_Musculoskeletal = event;
        }
    }

    public onLE_HD_Neurological_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_Neurological_Desc != event) {
            this._LowerExtremity.LE_HD_Neurological_Desc = event;
        }
    }

    public onLE_HD_NeurologicalChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_Neurological != event) {
            this._LowerExtremity.LE_HD_Neurological = event;
        }
    }

    public onLE_HD_OrganFailure_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_OrganFailure_Desc != event) {
            this._LowerExtremity.LE_HD_OrganFailure_Desc = event;
        }
    }

    public onLE_HD_OrganFailureChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_OrganFailure != event) {
            this._LowerExtremity.LE_HD_OrganFailure = event;
        }
    }

    public onLE_HD_PreferencePetition_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_PreferencePetition_Desc != event) {
            this._LowerExtremity.LE_HD_PreferencePetition_Desc = event;
        }
    }

    public onLE_HD_PreferencePetitionChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_PreferencePetition != event) {
            this._LowerExtremity.LE_HD_PreferencePetition = event;
        }
    }

    public onLE_HD_Pulmonary_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_Pulmonary_Desc != event) {
            this._LowerExtremity.LE_HD_Pulmonary_Desc = event;
        }
    }

    public onLE_HD_PulmonaryChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_Pulmonary != event) {
            this._LowerExtremity.LE_HD_Pulmonary = event;
        }
    }

    public onLE_HD_SingleSideAmputate_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_SingleSideAmputate_Desc != event) {
            this._LowerExtremity.LE_HD_SingleSideAmputate_Desc = event;
        }
    }

    public onLE_HD_SingleSideAmputateChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_SingleSideAmputate != event) {
            this._LowerExtremity.LE_HD_SingleSideAmputate = event;
        }
    }

    public onLE_HD_StumpZone_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_StumpZone_Desc != event) {
            this._LowerExtremity.LE_HD_StumpZone_Desc = event;
        }
    }

    public onLE_HD_StumpZoneChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_StumpZone != event) {
            this._LowerExtremity.LE_HD_StumpZone = event;
        }
    }

    public onLE_HD_SystemicDisease_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_SystemicDisease_Desc != event) {
            this._LowerExtremity.LE_HD_SystemicDisease_Desc = event;
        }
    }

    public onLE_HD_SystemicDiseaseChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_SystemicDisease != event) {
            this._LowerExtremity.LE_HD_SystemicDisease = event;
        }
    }

    public onLE_HD_WeightTolerance_descChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_WeightTolerance_desc != event) {
            this._LowerExtremity.LE_HD_WeightTolerance_desc = event;
        }
    }

    public onLE_HD_WeightToleranceChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HD_WeightTolerance != event) {
            this._LowerExtremity.LE_HD_WeightTolerance = event;
        }
    }

    public onLE_HeadDoctorApproveChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_HeadDoctorApprove != event) {
            this._LowerExtremity.LE_HeadDoctorApprove = event;
        }
    }

    public onLE_MachineNameChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_MachineName != event) {
            this._LowerExtremity.LE_MachineName = event;
        }
    }

    public onLE_MachineNameIsCorrectChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_MachineNameIsCorrect != event) {
            this._LowerExtremity.LE_MachineNameIsCorrect = event;
        }
    }

    public onLE_MedicalReasonChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_MedicalReason != event) {
            this._LowerExtremity.LE_MedicalReason = event;
        }
    }

    public onLE_MedulaInsCodeChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_MedulaInsCode != event) {
            this._LowerExtremity.LE_MedulaInsCode = event;
        }
    }

    public onLE_MedulaOrProtocolNoChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_MedulaOrProtocolNo != event) {
            this._LowerExtremity.LE_MedulaOrProtocolNo = event;
        }
    }

    public onLE_OrthopedicExpertApproveChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_OrthopedicExpertApprove != event) {
            this._LowerExtremity.LE_OrthopedicExpertApprove = event;
        }
    }

    public onLE_PatientNameSurnameChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_PatientNameSurname != event) {
            this._LowerExtremity.LE_PatientNameSurname = event;
        }
    }

    public onLE_ProsthesisNumberChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_ProsthesisNumber != event) {
            this._LowerExtremity.LE_ProsthesisNumber = event;
        }
    }

    public onLE_ProstheticTypeChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_ProstheticType != event) {
            this._LowerExtremity.LE_ProstheticType = event;
        }
    }

    public onLE_PsychiatricExpertApproveChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_PsychiatricExpertApprove != event) {
            this._LowerExtremity.LE_PsychiatricExpertApprove = event;
        }
    }

    public onLE_SK_ProstheticTypeChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_SK_ProstheticType != event) {
            this._LowerExtremity.LE_SK_ProstheticType = event;
        }
    }

    public onLE_TEM_Oscillationand_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_TEM_Oscillationand_Desc != event) {
            this._LowerExtremity.LE_TEM_Oscillationand_Desc = event;
        }
    }

    public onLE_TEM_OscillationandPostureChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_TEM_OscillationandPosture != event) {
            this._LowerExtremity.LE_TEM_OscillationandPosture = event;
        }
    }

    public onLE_TEM_StepClimbing_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_TEM_StepClimbing_Desc != event) {
            this._LowerExtremity.LE_TEM_StepClimbing_Desc = event;
        }
    }

    public onLE_TEM_StepClimbingChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_TEM_StepClimbing != event) {
            this._LowerExtremity.LE_TEM_StepClimbing = event;
        }
    }

    public onLE_TEM_StrideLength_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_TEM_StrideLength_Desc != event) {
            this._LowerExtremity.LE_TEM_StrideLength_Desc = event;
        }
    }

    public onLE_TEM_StrideLengthChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_TEM_StrideLength != event) {
            this._LowerExtremity.LE_TEM_StrideLength = event;
        }
    }

    public onLE_TEM_WalkBackwards_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_TEM_WalkBackwards_Desc != event) {
            this._LowerExtremity.LE_TEM_WalkBackwards_Desc = event;
        }
    }

    public onLE_TEM_WalkBackwardsChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_TEM_WalkBackwards != event) {
            this._LowerExtremity.LE_TEM_WalkBackwards = event;
        }
    }

    public onLE_TEM_WalkingSpeed_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_TEM_WalkingSpeed_Desc != event) {
            this._LowerExtremity.LE_TEM_WalkingSpeed_Desc = event;
        }
    }

    public onLE_TEM_WalkingSpeedChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_TEM_WalkingSpeed != event) {
            this._LowerExtremity.LE_TEM_WalkingSpeed = event;
        }
    }

    public onLE_TEM_Waterproof_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_TEM_Waterproof_Desc != event) {
            this._LowerExtremity.LE_TEM_Waterproof_Desc = event;
        }
    }

    public onLE_TEM_WaterproofChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_TEM_Waterproof != event) {
            this._LowerExtremity.LE_TEM_Waterproof = event;
        }
    }

    public onLE_TEM_WhichLevelChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_TEM_WhichLevel != event) {
            this._LowerExtremity.LE_TEM_WhichLevel = event;
        }
    }

    public onLE_ThirdStepHealthInstChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_ThirdStepHealthInst != event) {
            this._LowerExtremity.LE_ThirdStepHealthInst = event;
        }
    }

    public onLE_WetSignatureChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.LE_WetSignature != event) {
            this._LowerExtremity.LE_WetSignature = event;
        }
    }

    public onUE_AmputationDateChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_AmputationDate != event) {
            this._LowerExtremity.UE_AmputationDate = event;
        }
    }

    public onUE_CauseOfInjuryChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_CauseOfInjury != event) {
            this._LowerExtremity.UE_CauseOfInjury = event;
        }
    }

    public onUE_ConstructionDateChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_ConstructionDate != event) {
            this._LowerExtremity.UE_ConstructionDate = event;
        }
    }

    public onUE_HD_AmputationLevelChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_AmputationLevel != event) {
            this._LowerExtremity.UE_HD_AmputationLevel = event;
        }
    }

    public onUE_HD_Cardiovascular_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_Cardiovascular_Desc != event) {
            this._LowerExtremity.UE_HD_Cardiovascular_Desc = event;
        }
    }

    public onUE_HD_CardiovascularChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_Cardiovascular != event) {
            this._LowerExtremity.UE_HD_Cardiovascular = event;
        }
    }

    public onUE_HD_Contracture_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_Contracture_Desc != event) {
            this._LowerExtremity.UE_HD_Contracture_Desc = event;
        }
    }

    public onUE_HD_ContractureChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_Contracture != event) {
            this._LowerExtremity.UE_HD_Contracture = event;
        }
    }

    public onUE_HD_FunctionalMovement_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_FunctionalMovement_Desc != event) {
            this._LowerExtremity.UE_HD_FunctionalMovement_Desc = event;
        }
    }

    public onUE_HD_FunctionalMovementsChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_FunctionalMovements != event) {
            this._LowerExtremity.UE_HD_FunctionalMovements = event;
        }
    }

    public onUE_HD_Musculoskeletal_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_Musculoskeletal_Desc != event) {
            this._LowerExtremity.UE_HD_Musculoskeletal_Desc = event;
        }
    }

    public onUE_HD_MusculoskeletalChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_Musculoskeletal != event) {
            this._LowerExtremity.UE_HD_Musculoskeletal = event;
        }
    }

    public onUE_HD_MyoelectricChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_Myoelectric != event) {
            this._LowerExtremity.UE_HD_Myoelectric = event;
        }
    }

    public onUE_HD_Neurological_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_Neurological_Desc != event) {
            this._LowerExtremity.UE_HD_Neurological_Desc = event;
        }
    }

    public onUE_HD_NeurologicalChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_Neurological != event) {
            this._LowerExtremity.UE_HD_Neurological = event;
        }
    }

    public onUE_HD_OrganFailure_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_OrganFailure_Desc != event) {
            this._LowerExtremity.UE_HD_OrganFailure_Desc = event;
        }
    }

    public onUE_HD_OrganFailureChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_OrganFailure != event) {
            this._LowerExtremity.UE_HD_OrganFailure = event;
        }
    }

    public onUE_HD_PreferencePetition_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_PreferencePetition_Desc != event) {
            this._LowerExtremity.UE_HD_PreferencePetition_Desc = event;
        }
    }

    public onUE_HD_PreferencePetitionChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_PreferencePetition != event) {
            this._LowerExtremity.UE_HD_PreferencePetition = event;
        }
    }

    public onUE_HD_Pulmonary_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_Pulmonary_Desc != event) {
            this._LowerExtremity.UE_HD_Pulmonary_Desc = event;
        }
    }

    public onUE_HD_PulmonaryChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_Pulmonary != event) {
            this._LowerExtremity.UE_HD_Pulmonary = event;
        }
    }

    public onUE_HD_SingleSideAmputate_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_SingleSideAmputate_Desc != event) {
            this._LowerExtremity.UE_HD_SingleSideAmputate_Desc = event;
        }
    }

    public onUE_HD_SingleSideAmputateChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_SingleSideAmputate != event) {
            this._LowerExtremity.UE_HD_SingleSideAmputate = event;
        }
    }

    public onUE_HD_StumpLengthChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_StumpLength != event) {
            this._LowerExtremity.UE_HD_StumpLength = event;
        }
    }

    public onUE_HD_StumpZone_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_StumpZone_Desc != event) {
            this._LowerExtremity.UE_HD_StumpZone_Desc = event;
        }
    }

    public onUE_HD_StumpZoneChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_StumpZone != event) {
            this._LowerExtremity.UE_HD_StumpZone = event;
        }
    }

    public onUE_HD_SufficientStump_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_SufficientStump_Desc != event) {
            this._LowerExtremity.UE_HD_SufficientStump_Desc = event;
        }
    }

    public onUE_HD_SufficientStumpLengthChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_SufficientStumpLength != event) {
            this._LowerExtremity.UE_HD_SufficientStumpLength = event;
        }
    }

    public onUE_HD_SystemicDisease_DescChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_SystemicDisease_Desc != event) {
            this._LowerExtremity.UE_HD_SystemicDisease_Desc = event;
        }
    }

    public onUE_HD_SystemicDiseaseChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_HD_SystemicDisease != event) {
            this._LowerExtremity.UE_HD_SystemicDisease = event;
        }
    }

    public onUE_ProsthesisNumberChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_ProsthesisNumber != event) {
            this._LowerExtremity.UE_ProsthesisNumber = event;
        }
    }

    public onUE_ProstheticTypeChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_ProstheticType != event) {
            this._LowerExtremity.UE_ProstheticType = event;
        }
    }

    public onUE_RI_DateChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_RI_Date != event) {
            this._LowerExtremity.UE_RI_Date = event;
        }
    }

    public onUE_RI_DiagnosAndICD10CodeChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_RI_DiagnosAndICD10Code != event) {
            this._LowerExtremity.UE_RI_DiagnosAndICD10Code = event;
        }
    }

    public onUE_RI_MachineNameChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_RI_MachineName != event) {
            this._LowerExtremity.UE_RI_MachineName = event;
        }
    }

    public onUE_RI_MachineNameIsCorrectChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_RI_MachineNameIsCorrect != event) {
            this._LowerExtremity.UE_RI_MachineNameIsCorrect = event;
        }
    }

    public onUE_RI_MedulaInsCodeChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_RI_MedulaInsCode != event) {
            this._LowerExtremity.UE_RI_MedulaInsCode = event;
        }
    }

    public onUE_RI_MedulaOrProtocolNoChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_RI_MedulaOrProtocolNo != event) {
            this._LowerExtremity.UE_RI_MedulaOrProtocolNo = event;
        }
    }

    public onUE_RI_PatientNameSurnameChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_RI_PatientNameSurname != event) {
            this._LowerExtremity.UE_RI_PatientNameSurname = event;
        }
    }

    public onUE_RI_WetSignatureChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_RI_WetSignature != event) {
            this._LowerExtremity.UE_RI_WetSignature = event;
        }
    }

    public onUE_SK_FTRExpertApproveChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_SK_FTRExpertApprove != event) {
            this._LowerExtremity.UE_SK_FTRExpertApprove = event;
        }
    }

    public onUE_SK_HeadDoctorApproveChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_SK_HeadDoctorApprove != event) {
            this._LowerExtremity.UE_SK_HeadDoctorApprove = event;
        }
    }

    public onUE_SK_MedicalReasonChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_SK_MedicalReason != event) {
            this._LowerExtremity.UE_SK_MedicalReason = event;
        }
    }

    public onUE_SK_OrthopedicExpApproveChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_SK_OrthopedicExpApprove != event) {
            this._LowerExtremity.UE_SK_OrthopedicExpApprove = event;
        }
    }

    public onUE_SK_ProstheticTypeChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_SK_ProstheticType != event) {
            this._LowerExtremity.UE_SK_ProstheticType = event;
        }
    }

    public onUE_SK_PsychiatricExpApproveChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_SK_PsychiatricExpApprove != event) {
            this._LowerExtremity.UE_SK_PsychiatricExpApprove = event;
        }
    }

    public onUE_SK_sEMGChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_SK_sEMG != event) {
            this._LowerExtremity.UE_SK_sEMG = event;
        }
    }

    public onUE_SK_ThirdStepHealthInstChanged(event): void {
        if (this._LowerExtremity != null && this._LowerExtremity.UE_SK_ThirdStepHealthInst != event) {
            this._LowerExtremity.UE_SK_ThirdStepHealthInst = event;
        }
    }



    protected redirectProperties(): void {
        redirectProperty(this.LE_HD_AktivityLevel, "Text", this.__ttObject, "LE_HD_AktivityLevel");
        redirectProperty(this.LE_HD_PreferencePetition, "Value", this.__ttObject, "LE_HD_PreferencePetition");
        redirectProperty(this.LE_HD_Ambulation_Desc, "Text", this.__ttObject, "LE_HD_Ambulation_Desc");
        redirectProperty(this.LE_HD_StumpZone, "Value", this.__ttObject, "LE_HD_StumpZone");
        redirectProperty(this.LE_HD_Cardiovascular_Desc, "Text", this.__ttObject, "LE_HD_Cardiovascular_Desc");
        redirectProperty(this.LE_HD_WeightTolerance, "Value", this.__ttObject, "LE_HD_WeightTolerance");
        redirectProperty(this.LE_HD_Contracture_Desc, "Text", this.__ttObject, "LE_HD_Contracture_Desc");
        redirectProperty(this.LE_HD_Contracture, "Value", this.__ttObject, "LE_HD_Contracture");
        redirectProperty(this.LE_HD_Musculoskeletal_Desc, "Text", this.__ttObject, "LE_HD_Musculoskeletal_Desc");
        redirectProperty(this.LE_HD_SingleSideAmputate, "Value", this.__ttObject, "LE_HD_SingleSideAmputate");
        redirectProperty(this.LE_HD_Neurological_Desc, "Text", this.__ttObject, "LE_HD_Neurological_Desc");
        redirectProperty(this.LE_HD_Ambulation, "Value", this.__ttObject, "LE_HD_Ambulation");
        redirectProperty(this.LE_HD_OrganFailure_Desc, "Text", this.__ttObject, "LE_HD_OrganFailure_Desc");
        redirectProperty(this.LE_HD_Musculoskeletal, "Value", this.__ttObject, "LE_HD_Musculoskeletal");
        redirectProperty(this.LE_HD_PreferencePetition_Desc, "Text", this.__ttObject, "LE_HD_PreferencePetition_Desc");
        redirectProperty(this.LE_HD_Neurological, "Value", this.__ttObject, "LE_HD_Neurological");
        redirectProperty(this.LE_HD_Pulmonary_Desc, "Text", this.__ttObject, "LE_HD_Pulmonary_Desc");
        redirectProperty(this.LE_HD_Cardiovascular, "Value", this.__ttObject, "LE_HD_Cardiovascular");
        redirectProperty(this.LE_HD_SingleSideAmputate_Desc, "Text", this.__ttObject, "LE_HD_SingleSideAmputate_Desc");
        redirectProperty(this.LE_HD_Pulmonary, "Value", this.__ttObject, "LE_HD_Pulmonary");
        redirectProperty(this.LE_HD_StumpZone_Desc, "Text", this.__ttObject, "LE_HD_StumpZone_Desc");
        redirectProperty(this.LE_HD_OrganFailure, "Value", this.__ttObject, "LE_HD_OrganFailure");
        redirectProperty(this.LE_HD_SystemicDisease_Desc, "Text", this.__ttObject, "LE_HD_SystemicDisease_Desc");
        redirectProperty(this.LE_HD_SystemicDisease, "Value", this.__ttObject, "LE_HD_SystemicDisease");
        redirectProperty(this.LE_HD_WeightTolerance_desc, "Text", this.__ttObject, "LE_HD_WeightTolerance_desc");
        redirectProperty(this.LE_FTRExpertApprove, "Value", this.__ttObject, "LE_FTRExpertApprove");
        redirectProperty(this.LE_SK_ProstheticType, "Text", this.__ttObject, "LE_SK_ProstheticType");
        redirectProperty(this.LE_HeadDoctorApprove, "Value", this.__ttObject, "LE_HeadDoctorApprove");
        redirectProperty(this.LE_MedicalReason, "Value", this.__ttObject, "LE_MedicalReason");
        redirectProperty(this.LE_OrthopedicExpertApprove, "Value", this.__ttObject, "LE_OrthopedicExpertApprove");
        redirectProperty(this.LE_PsychiatricExpertApprove, "Value", this.__ttObject, "LE_PsychiatricExpertApprove");
        redirectProperty(this.LE_ThirdStepHealthInst, "Value", this.__ttObject, "LE_ThirdStepHealthInst");
        redirectProperty(this.LE_CauseOfInjury, "Text", this.__ttObject, "LE_CauseOfInjury");
        redirectProperty(this.LE_AmputationDate, "Text", this.__ttObject, "LE_AmputationDate");
        redirectProperty(this.LE_ProsthesisNumber, "Text", this.__ttObject, "LE_ProsthesisNumber");
        redirectProperty(this.LE_ConstructionDate, "Text", this.__ttObject, "LE_ConstructionDate");
        redirectProperty(this.LE_ProstheticType, "Text", this.__ttObject, "LE_ProstheticType");
        redirectProperty(this.LE_DiagnosAndICD10Code, "Value", this.__ttObject, "LE_DiagnosAndICD10Code");
        redirectProperty(this.LE_MachineName, "Value", this.__ttObject, "LE_MachineName");
        redirectProperty(this.LE_MachineNameIsCorrect, "Value", this.__ttObject, "LE_MachineNameIsCorrect");
        redirectProperty(this.LE_MedulaInsCode, "Value", this.__ttObject, "LE_MedulaInsCode");
        redirectProperty(this.LE_MedulaOrProtocolNo, "Value", this.__ttObject, "LE_MedulaOrProtocolNo");
        redirectProperty(this.LE_PatientNameSurname, "Value", this.__ttObject, "LE_PatientNameSurname");
        redirectProperty(this.LE_WetSignature, "Value", this.__ttObject, "LE_WetSignature");
        redirectProperty(this.LE_TEM_WhichLevel, "Text", this.__ttObject, "LE_TEM_WhichLevel");
        redirectProperty(this.LE_TEM_Oscillationand_Desc, "Text", this.__ttObject, "LE_TEM_Oscillationand_Desc");
        redirectProperty(this.LE_TEM_WalkBackwards_Desc, "Text", this.__ttObject, "LE_TEM_WalkBackwards_Desc");
        redirectProperty(this.LE_TEM_StrideLength, "Value", this.__ttObject, "LE_TEM_StrideLength");
        redirectProperty(this.LE_TEM_OscillationandPosture, "Value", this.__ttObject, "LE_TEM_OscillationandPosture");
        redirectProperty(this.LE_TEM_StepClimbing_Desc, "Text", this.__ttObject, "LE_TEM_StepClimbing_Desc");
        redirectProperty(this.LE_TEM_WalkingSpeed_Desc, "Text", this.__ttObject, "LE_TEM_WalkingSpeed_Desc");
        redirectProperty(this.LE_TEM_StepClimbing, "Value", this.__ttObject, "LE_TEM_StepClimbing");
        redirectProperty(this.LE_TEM_WalkingSpeed, "Value", this.__ttObject, "LE_TEM_WalkingSpeed");
        redirectProperty(this.LE_TEM_StrideLength_Desc, "Text", this.__ttObject, "LE_TEM_StrideLength_Desc");
        redirectProperty(this.LE_TEM_Waterproof_Desc, "Text", this.__ttObject, "LE_TEM_Waterproof_Desc");
        redirectProperty(this.LE_TEM_WalkBackwards, "Value", this.__ttObject, "LE_TEM_WalkBackwards");
        redirectProperty(this.LE_TEM_Waterproof, "Value", this.__ttObject, "LE_TEM_Waterproof");
        redirectProperty(this.UE_SK_ProstheticType, "Text", this.__ttObject, "UE_SK_ProstheticType");
        redirectProperty(this.UE_SK_MedicalReason, "Value", this.__ttObject, "UE_SK_MedicalReason");
        redirectProperty(this.UE_SK_FTRExpertApprove, "Value", this.__ttObject, "UE_SK_FTRExpertApprove");
        redirectProperty(this.UE_SK_HeadDoctorApprove, "Value", this.__ttObject, "UE_SK_HeadDoctorApprove");
        redirectProperty(this.UE_SK_OrthopedicExpApprove, "Value", this.__ttObject, "UE_SK_OrthopedicExpApprove");
        redirectProperty(this.UE_SK_PsychiatricExpApprove, "Value", this.__ttObject, "UE_SK_PsychiatricExpApprove");
        redirectProperty(this.UE_SK_sEMG, "Value", this.__ttObject, "UE_SK_sEMG");
        redirectProperty(this.UE_SK_ThirdStepHealthInst, "Value", this.__ttObject, "UE_SK_ThirdStepHealthInst");
        redirectProperty(this.UE_HD_AmputationLevel, "Text", this.__ttObject, "UE_HD_AmputationLevel");
        redirectProperty(this.UE_HD_StumpLength, "Text", this.__ttObject, "UE_HD_StumpLength");
        redirectProperty(this.UE_HD_PreferencePetition, "Value", this.__ttObject, "UE_HD_PreferencePetition");
        redirectProperty(this.UE_HD_PreferencePetition_Desc, "Text", this.__ttObject, "UE_HD_PreferencePetition_Desc");
        redirectProperty(this.UE_HD_SufficientStumpLength, "Value", this.__ttObject, "UE_HD_SufficientStumpLength");
        redirectProperty(this.UE_HD_SufficientStump_Desc, "Text", this.__ttObject, "UE_HD_SufficientStump_Desc");
        redirectProperty(this.UE_HD_SingleSideAmputate, "Value", this.__ttObject, "UE_HD_SingleSideAmputate");
        redirectProperty(this.UE_HD_SingleSideAmputate_Desc, "Text", this.__ttObject, "UE_HD_SingleSideAmputate_Desc");
        redirectProperty(this.UE_HD_FunctionalMovements, "Value", this.__ttObject, "UE_HD_FunctionalMovements");
        redirectProperty(this.UE_HD_FunctionalMovement_Desc, "Text", this.__ttObject, "UE_HD_FunctionalMovement_Desc");
        redirectProperty(this.UE_HD_Cardiovascular, "Value", this.__ttObject, "UE_HD_Cardiovascular");
        redirectProperty(this.UE_HD_Cardiovascular_Desc, "Text", this.__ttObject, "UE_HD_Cardiovascular_Desc");
        redirectProperty(this.UE_HD_StumpZone, "Value", this.__ttObject, "UE_HD_StumpZone");
        redirectProperty(this.UE_HD_StumpZone_Desc, "Text", this.__ttObject, "UE_HD_StumpZone_Desc");
        redirectProperty(this.UE_HD_Contracture, "Value", this.__ttObject, "UE_HD_Contracture");
        redirectProperty(this.UE_HD_Contracture_Desc, "Text", this.__ttObject, "UE_HD_Contracture_Desc");
        redirectProperty(this.UE_HD_Musculoskeletal, "Value", this.__ttObject, "UE_HD_Musculoskeletal");
        redirectProperty(this.UE_HD_Musculoskeletal_Desc, "Text", this.__ttObject, "UE_HD_Musculoskeletal_Desc");
        redirectProperty(this.UE_HD_Neurological, "Value", this.__ttObject, "UE_HD_Neurological");
        redirectProperty(this.UE_HD_Neurological_Desc, "Text", this.__ttObject, "UE_HD_Neurological_Desc");
        redirectProperty(this.UE_HD_Pulmonary, "Value", this.__ttObject, "UE_HD_Pulmonary");
        redirectProperty(this.UE_HD_Pulmonary_Desc, "Text", this.__ttObject, "UE_HD_Pulmonary_Desc");
        redirectProperty(this.UE_HD_OrganFailure, "Value", this.__ttObject, "UE_HD_OrganFailure");
        redirectProperty(this.UE_HD_OrganFailure_Desc, "Text", this.__ttObject, "UE_HD_OrganFailure_Desc");
        redirectProperty(this.UE_HD_SystemicDisease, "Value", this.__ttObject, "UE_HD_SystemicDisease");
        redirectProperty(this.UE_HD_SystemicDisease_Desc, "Text", this.__ttObject, "UE_HD_SystemicDisease_Desc");
        redirectProperty(this.UE_HD_Myoelectric, "Value", this.__ttObject, "UE_HD_Myoelectric");
        redirectProperty(this.UE_AmputationDate, "Text", this.__ttObject, "UE_AmputationDate");
        redirectProperty(this.UE_CauseOfInjury, "Text", this.__ttObject, "UE_CauseOfInjury");
        redirectProperty(this.UE_ConstructionDate, "Text", this.__ttObject, "UE_ConstructionDate");
        redirectProperty(this.UE_ProsthesisNumber, "Text", this.__ttObject, "UE_ProsthesisNumber");
        redirectProperty(this.UE_ProstheticType, "Text", this.__ttObject, "UE_ProstheticType");
        redirectProperty(this.UE_RI_PatientNameSurname, "Value", this.__ttObject, "UE_RI_PatientNameSurname");
        redirectProperty(this.UE_RI_MedulaInsCode, "Value", this.__ttObject, "UE_RI_MedulaInsCode");
        redirectProperty(this.UE_RI_Date, "Value", this.__ttObject, "UE_RI_Date");
        redirectProperty(this.UE_RI_MedulaOrProtocolNo, "Value", this.__ttObject, "UE_RI_MedulaOrProtocolNo");
        redirectProperty(this.UE_RI_MachineName, "Value", this.__ttObject, "UE_RI_MachineName");
        redirectProperty(this.UE_RI_DiagnosAndICD10Code, "Value", this.__ttObject, "UE_RI_DiagnosAndICD10Code");
        redirectProperty(this.UE_RI_MachineNameIsCorrect, "Value", this.__ttObject, "UE_RI_MachineNameIsCorrect");
        redirectProperty(this.UE_RI_WetSignature, "Value", this.__ttObject, "UE_RI_WetSignature");
        redirectProperty(this.ATS_HD_UseHimself, "Value", this.__ttObject, "ATS_HD_UseHimself");
        redirectProperty(this.ATS_HD_Deformity, "Value", this.__ttObject, "ATS_HD_Deformity");
        redirectProperty(this.ATS_HD_Contracture, "Value", this.__ttObject, "ATS_HD_Contracture");
        redirectProperty(this.ATS_HD_ChairDistance, "Text", this.__ttObject, "ATS_HD_ChairDistance");
        redirectProperty(this.ATS_HD_Cardiovascular, "Value", this.__ttObject, "ATS_HD_Cardiovascular");
        redirectProperty(this.ATS_HD_Cardiovascular_Desc, "Text", this.__ttObject, "ATS_HD_Cardiovascular_Desc");
        redirectProperty(this.ATS_HD_Therapeutic, "Value", this.__ttObject, "ATS_HD_Therapeutic");
        redirectProperty(this.ATS_HD_INTRACOMMUNITY, "Value", this.__ttObject, "ATS_HD_INTRACOMMUNITY");
        redirectProperty(this.ATS_HD_Pulmonary, "Value", this.__ttObject, "ATS_HD_Pulmonary");
        redirectProperty(this.ATS_HD_Pulmonary_Desc, "Text", this.__ttObject, "ATS_HD_Pulmonary_Desc");
        redirectProperty(this.ATS_HD_OrganFailure, "Value", this.__ttObject, "ATS_HD_OrganFailure");
        redirectProperty(this.ATS_HD_OrganFailure_Desc, "Text", this.__ttObject, "ATS_HD_OrganFailure_Desc");
        redirectProperty(this.ATS_HD_NOAMBULATION, "Value", this.__ttObject, "ATS_HD_NOAMBULATION");
        redirectProperty(this.ATS_HD_ConstantCondition_Desc, "Text", this.__ttObject, "ATS_HD_ConstantCondition_Desc");
        redirectProperty(this.ATS_HD_USELOWEREXTREMITIES, "Value", this.__ttObject, "ATS_HD_USELOWEREXTREMITIES");
        redirectProperty(this.ATS_HD_ChairModel_Desc, "Text", this.__ttObject, "ATS_HD_ChairModel_Desc");
        redirectProperty(this.ATS_HD_UseLowerExtremity_Desc, "Text", this.__ttObject, "ATS_HD_UseLowerExtremity_Desc");
        redirectProperty(this.ATS_HD_UseHimself_Desc, "Text", this.__ttObject, "ATS_HD_UseHimself_Desc");
        redirectProperty(this.ATS_HD_ConstantCondition, "Value", this.__ttObject, "ATS_HD_ConstantCondition");
        redirectProperty(this.ATS_HD_Deformity_Desc, "Text", this.__ttObject, "ATS_HD_Deformity_Desc");
        redirectProperty(this.ATS_HD_ChairModel, "Value", this.__ttObject, "ATS_HD_ChairModel");
        redirectProperty(this.ATS_HD_Contracture_Desc, "Text", this.__ttObject, "ATS_HD_Contracture_Desc");
        redirectProperty(this.ATS_SK_ChairType, "Text", this.__ttObject, "ATS_SK_ChairType");
        redirectProperty(this.ATS_SK_MedicalReason, "Text", this.__ttObject, "ATS_SK_MedicalReason");
        redirectProperty(this.ATS_SK_ThirdStepHealthInst, "Value", this.__ttObject, "ATS_SK_ThirdStepHealthInst");
        redirectProperty(this.ATS_SK_FTRExpertApprove, "Value", this.__ttObject, "ATS_SK_FTRExpertApprove");
        redirectProperty(this.ATS_SK_OrthopedicExpApprove, "Value", this.__ttObject, "ATS_SK_OrthopedicExpApprove");
        redirectProperty(this.ATS_SK_HeadDoctorApprove, "Value", this.__ttObject, "ATS_SK_HeadDoctorApprove");
        redirectProperty(this.ATS_ChairType, "Text", this.__ttObject, "ATS_ChairType");
        redirectProperty(this.ATS_CauseOfInjury, "Text", this.__ttObject, "ATS_CauseOfInjury");
        redirectProperty(this.ATS_ChairNumber, "Text", this.__ttObject, "ATS_ChairNumber");
        redirectProperty(this.ATS_DeliveryDate, "Text", this.__ttObject, "ATS_DeliveryDate");
        redirectProperty(this.ATS_RI_Date, "Value", this.__ttObject, "ATS_RI_Date");
        redirectProperty(this.ATS_RI_DiagnosAndICD10Code, "Value", this.__ttObject, "ATS_RI_DiagnosAndICD10Code");
        redirectProperty(this.ATS_RI_MachineName, "Value", this.__ttObject, "ATS_RI_MachineName");
        redirectProperty(this.ATS_RI_MedulaInsCode, "Value", this.__ttObject, "ATS_RI_MedulaInsCode");
        redirectProperty(this.ATS_RI_MedulaOrProtocolNo, "Value", this.__ttObject, "ATS_RI_MedulaOrProtocolNo");
        redirectProperty(this.ATS_RI_PatientNameSurname, "Value", this.__ttObject, "ATS_RI_PatientNameSurname");
        redirectProperty(this.ATS_RI_WetSignature, "Value", this.__ttObject, "ATS_RI_WetSignature");
    }

    public initFormControls(): void {
        this.tttabcontrol1 = new TTVisual.TTTabControl();
        this.tttabcontrol1.Name = "tttabcontrol1";
        this.tttabcontrol1.TabIndex = 1;

        this.tttabpage1 = new TTVisual.TTTabPage();
        this.tttabpage1.DisplayIndex = 0;
        this.tttabpage1.TabIndex = 0;
        this.tttabpage1.Text = "ALT EKSTREMİTE";
        this.tttabpage1.Name = "tttabpage1";

        this.labelLE_ProstheticType = new TTVisual.TTLabel();
        this.labelLE_ProstheticType.Text = "Protez tipi";
        this.labelLE_ProstheticType.Name = "labelLE_ProstheticType";
        this.labelLE_ProstheticType.TabIndex = 13;

        this.LE_ProstheticType = new TTVisual.TTTextBox();
        this.LE_ProstheticType.Name = "LE_ProstheticType";
        this.LE_ProstheticType.TabIndex = 12;

        this.labelLE_ConstructionDate = new TTVisual.TTLabel();
        this.labelLE_ConstructionDate.Text = "Yapım tarihi";
        this.labelLE_ConstructionDate.Name = "labelLE_ConstructionDate";
        this.labelLE_ConstructionDate.TabIndex = 11;

        this.LE_ConstructionDate = new TTVisual.TTTextBox();
        this.LE_ConstructionDate.Name = "LE_ConstructionDate";
        this.LE_ConstructionDate.TabIndex = 10;

        this.labelLE_ProsthesisNumber = new TTVisual.TTLabel();
        this.labelLE_ProsthesisNumber.Text = "Kaçıncı protezi olduğu ";
        this.labelLE_ProsthesisNumber.Name = "labelLE_ProsthesisNumber";
        this.labelLE_ProsthesisNumber.TabIndex = 9;

        this.LE_ProsthesisNumber = new TTVisual.TTTextBox();
        this.LE_ProsthesisNumber.Name = "LE_ProsthesisNumber";
        this.LE_ProsthesisNumber.TabIndex = 8;

        this.labelLE_AmputationDate = new TTVisual.TTLabel();
        this.labelLE_AmputationDate.Text = "Amputasyon tarihi";
        this.labelLE_AmputationDate.Name = "labelLE_AmputationDate";
        this.labelLE_AmputationDate.TabIndex = 7;

        this.LE_AmputationDate = new TTVisual.TTTextBox();
        this.LE_AmputationDate.Name = "LE_AmputationDate";
        this.LE_AmputationDate.TabIndex = 6;

        this.labelLE_CauseOfInjury = new TTVisual.TTLabel();
        this.labelLE_CauseOfInjury.Text = "Yaralanma nedeni ve tarihi";
        this.labelLE_CauseOfInjury.Name = "labelLE_CauseOfInjury";
        this.labelLE_CauseOfInjury.TabIndex = 5;

        this.LE_CauseOfInjury = new TTVisual.TTTextBox();
        this.LE_CauseOfInjury.Name = "LE_CauseOfInjury";
        this.LE_CauseOfInjury.TabIndex = 4;

        this.ttgroupbox4 = new TTVisual.TTGroupBox();
        this.ttgroupbox4.Text = "Talep Edilen Mikroişlemci Kontrollü Diz Eklemleri İçin";
        this.ttgroupbox4.Name = "ttgroupbox4";
        this.ttgroupbox4.TabIndex = 3;

        this.labelLE_TEM_Waterproof_Desc = new TTVisual.TTLabel();
        this.labelLE_TEM_Waterproof_Desc.Text = "Suya dayanıklı mı?";
        this.labelLE_TEM_Waterproof_Desc.Name = "labelLE_TEM_Waterproof_Desc";
        this.labelLE_TEM_Waterproof_Desc.TabIndex = 25;

        this.LE_TEM_Waterproof_Desc = new TTVisual.TTTextBox();
        this.LE_TEM_Waterproof_Desc.Name = "LE_TEM_Waterproof_Desc";
        this.LE_TEM_Waterproof_Desc.TabIndex = 24;

        this.labelLE_TEM_WalkingSpeed_Desc = new TTVisual.TTLabel();
        this.labelLE_TEM_WalkingSpeed_Desc.Text = "Değişken yürüme hızlarına ";
        this.labelLE_TEM_WalkingSpeed_Desc.Name = "labelLE_TEM_WalkingSpeed_Desc";
        this.labelLE_TEM_WalkingSpeed_Desc.TabIndex = 23;

        this.LE_TEM_WalkingSpeed_Desc = new TTVisual.TTTextBox();
        this.LE_TEM_WalkingSpeed_Desc.Name = "LE_TEM_WalkingSpeed_Desc";
        this.LE_TEM_WalkingSpeed_Desc.TabIndex = 22;

        this.labelLE_TEM_WalkBackwards_Desc = new TTVisual.TTLabel();
        this.labelLE_TEM_WalkBackwards_Desc.Text = "Geri geri yürüme özelliği var mı?";
        this.labelLE_TEM_WalkBackwards_Desc.Name = "labelLE_TEM_WalkBackwards_Desc";
        this.labelLE_TEM_WalkBackwards_Desc.TabIndex = 21;

        this.LE_TEM_WalkBackwards_Desc = new TTVisual.TTTextBox();
        this.LE_TEM_WalkBackwards_Desc.Name = "LE_TEM_WalkBackwards_Desc";
        this.LE_TEM_WalkBackwards_Desc.TabIndex = 20;

        this.labelLE_TEM_StrideLength_Desc = new TTVisual.TTLabel();
        this.labelLE_TEM_StrideLength_Desc.Text = "Değişken adım uzunluğu";
        this.labelLE_TEM_StrideLength_Desc.Name = "labelLE_TEM_StrideLength_Desc";
        this.labelLE_TEM_StrideLength_Desc.TabIndex = 19;

        this.LE_TEM_StrideLength_Desc = new TTVisual.TTTextBox();
        this.LE_TEM_StrideLength_Desc.Name = "LE_TEM_StrideLength_Desc";
        this.LE_TEM_StrideLength_Desc.TabIndex = 18;

        this.labelLE_TEM_StepClimbing_Desc = new TTVisual.TTLabel();
        this.labelLE_TEM_StepClimbing_Desc.Text = "Basamak çıkma özelliği var mı?";
        this.labelLE_TEM_StepClimbing_Desc.Name = "labelLE_TEM_StepClimbing_Desc";
        this.labelLE_TEM_StepClimbing_Desc.TabIndex = 17;

        this.LE_TEM_StepClimbing_Desc = new TTVisual.TTTextBox();
        this.LE_TEM_StepClimbing_Desc.Name = "LE_TEM_StepClimbing_Desc";
        this.LE_TEM_StepClimbing_Desc.TabIndex = 16;

        this.labelLE_TEM_Oscillationand_Desc = new TTVisual.TTLabel();
        this.labelLE_TEM_Oscillationand_Desc.Text = "Yürüyüşün salınım ";
        this.labelLE_TEM_Oscillationand_Desc.Name = "labelLE_TEM_Oscillationand_Desc";
        this.labelLE_TEM_Oscillationand_Desc.TabIndex = 15;

        this.LE_TEM_Oscillationand_Desc = new TTVisual.TTTextBox();
        this.LE_TEM_Oscillationand_Desc.Name = "LE_TEM_Oscillationand_Desc";
        this.LE_TEM_Oscillationand_Desc.TabIndex = 14;

        this.labelLE_TEM_Waterproof = new TTVisual.TTLabel();
        this.labelLE_TEM_Waterproof.Text = "Suya dayanıklı mı?";
        this.labelLE_TEM_Waterproof.Name = "labelLE_TEM_Waterproof";
        this.labelLE_TEM_Waterproof.TabIndex = 13;

        this.LE_TEM_Waterproof = new TTVisual.TTEnumComboBox();
        this.LE_TEM_Waterproof.DataTypeName = "YesNoEnum";
        this.LE_TEM_Waterproof.Name = "LE_TEM_Waterproof";
        this.LE_TEM_Waterproof.TabIndex = 12;

        this.labelLE_TEM_WalkBackwards = new TTVisual.TTLabel();
        this.labelLE_TEM_WalkBackwards.Text = "Geri geri yürüme özelliği var mı?";
        this.labelLE_TEM_WalkBackwards.Name = "labelLE_TEM_WalkBackwards";
        this.labelLE_TEM_WalkBackwards.TabIndex = 11;

        this.LE_TEM_WalkBackwards = new TTVisual.TTEnumComboBox();
        this.LE_TEM_WalkBackwards.DataTypeName = "YesNoEnum";
        this.LE_TEM_WalkBackwards.Name = "LE_TEM_WalkBackwards";
        this.LE_TEM_WalkBackwards.TabIndex = 10;

        this.labelLE_TEM_StepClimbing = new TTVisual.TTLabel();
        this.labelLE_TEM_StepClimbing.Text = "Basamak çıkma özelliği var mı?";
        this.labelLE_TEM_StepClimbing.Name = "labelLE_TEM_StepClimbing";
        this.labelLE_TEM_StepClimbing.TabIndex = 9;

        this.LE_TEM_StepClimbing = new TTVisual.TTEnumComboBox();
        this.LE_TEM_StepClimbing.DataTypeName = "YesNoEnum";
        this.LE_TEM_StepClimbing.Name = "LE_TEM_StepClimbing";
        this.LE_TEM_StepClimbing.TabIndex = 8;

        this.labelLE_TEM_StrideLength = new TTVisual.TTLabel();
        this.labelLE_TEM_StrideLength.Text = "Değişken adım uzunluğu";
        this.labelLE_TEM_StrideLength.Name = "labelLE_TEM_StrideLength";
        this.labelLE_TEM_StrideLength.TabIndex = 7;

        this.LE_TEM_StrideLength = new TTVisual.TTEnumComboBox();
        this.LE_TEM_StrideLength.DataTypeName = "YesNoEnum";
        this.LE_TEM_StrideLength.Name = "LE_TEM_StrideLength";
        this.LE_TEM_StrideLength.TabIndex = 6;

        this.labelLE_TEM_WalkingSpeed = new TTVisual.TTLabel();
        this.labelLE_TEM_WalkingSpeed.Text = "Değişken yürüme hızlarına ";
        this.labelLE_TEM_WalkingSpeed.Name = "labelLE_TEM_WalkingSpeed";
        this.labelLE_TEM_WalkingSpeed.TabIndex = 5;

        this.LE_TEM_WalkingSpeed = new TTVisual.TTEnumComboBox();
        this.LE_TEM_WalkingSpeed.DataTypeName = "YesNoEnum";
        this.LE_TEM_WalkingSpeed.Name = "LE_TEM_WalkingSpeed";
        this.LE_TEM_WalkingSpeed.TabIndex = 4;

        this.labelLE_TEM_OscillationandPosture = new TTVisual.TTLabel();
        this.labelLE_TEM_OscillationandPosture.Text = "Yürüyüşün salınım ";
        this.labelLE_TEM_OscillationandPosture.Name = "labelLE_TEM_OscillationandPosture";
        this.labelLE_TEM_OscillationandPosture.TabIndex = 3;

        this.LE_TEM_OscillationandPosture = new TTVisual.TTEnumComboBox();
        this.LE_TEM_OscillationandPosture.DataTypeName = "YesNoEnum";
        this.LE_TEM_OscillationandPosture.Name = "LE_TEM_OscillationandPosture";
        this.LE_TEM_OscillationandPosture.TabIndex = 2;

        this.labelLE_TEM_WhichLevel = new TTVisual.TTLabel();
        this.labelLE_TEM_WhichLevel.Text = "Hangi aktivite ";
        this.labelLE_TEM_WhichLevel.Name = "labelLE_TEM_WhichLevel";
        this.labelLE_TEM_WhichLevel.TabIndex = 1;

        this.LE_TEM_WhichLevel = new TTVisual.TTTextBox();
        this.LE_TEM_WhichLevel.Name = "LE_TEM_WhichLevel";
        this.LE_TEM_WhichLevel.TabIndex = 0;

        this.ttgroupbox3 = new TTVisual.TTGroupBox();
        this.ttgroupbox3.Text = "Hasta Değerlendirmesi";
        this.ttgroupbox3.Name = "ttgroupbox3";
        this.ttgroupbox3.TabIndex = 2;

        this.labelLE_HD_WeightTolerance_desc = new TTVisual.TTLabel();
        this.labelLE_HD_WeightTolerance_desc.Text = "Protezin ağırlığı hasta";
        this.labelLE_HD_WeightTolerance_desc.Name = "labelLE_HD_WeightTolerance_desc";
        this.labelLE_HD_WeightTolerance_desc.TabIndex = 49;

        this.LE_HD_WeightTolerance_desc = new TTVisual.TTTextBox();
        this.LE_HD_WeightTolerance_desc.Name = "LE_HD_WeightTolerance_desc";
        this.LE_HD_WeightTolerance_desc.TabIndex = 48;

        this.labelLE_HD_SystemicDisease_Desc = new TTVisual.TTLabel();
        this.labelLE_HD_SystemicDisease_Desc.Text = "Sistemik ";
        this.labelLE_HD_SystemicDisease_Desc.Name = "labelLE_HD_SystemicDisease_Desc";
        this.labelLE_HD_SystemicDisease_Desc.TabIndex = 47;

        this.LE_HD_SystemicDisease_Desc = new TTVisual.TTTextBox();
        this.LE_HD_SystemicDisease_Desc.Name = "LE_HD_SystemicDisease_Desc";
        this.LE_HD_SystemicDisease_Desc.TabIndex = 46;

        this.labelLE_HD_StumpZone_Desc = new TTVisual.TTLabel();
        this.labelLE_HD_StumpZone_Desc.Text = "Güdük bölgesinde ";
        this.labelLE_HD_StumpZone_Desc.Name = "labelLE_HD_StumpZone_Desc";
        this.labelLE_HD_StumpZone_Desc.TabIndex = 45;

        this.LE_HD_StumpZone_Desc = new TTVisual.TTTextBox();
        this.LE_HD_StumpZone_Desc.Name = "LE_HD_StumpZone_Desc";
        this.LE_HD_StumpZone_Desc.TabIndex = 44;

        this.labelLE_HD_SingleSideAmputate_Desc = new TTVisual.TTLabel();
        this.labelLE_HD_SingleSideAmputate_Desc.Text = "Tek taraflı amputelerde ";
        this.labelLE_HD_SingleSideAmputate_Desc.Name = "labelLE_HD_SingleSideAmputate_Desc";
        this.labelLE_HD_SingleSideAmputate_Desc.TabIndex = 43;

        this.LE_HD_SingleSideAmputate_Desc = new TTVisual.TTTextBox();
        this.LE_HD_SingleSideAmputate_Desc.Name = "LE_HD_SingleSideAmputate_Desc";
        this.LE_HD_SingleSideAmputate_Desc.TabIndex = 42;

        this.labelLE_HD_Pulmonary_Desc = new TTVisual.TTLabel();
        this.labelLE_HD_Pulmonary_Desc.Text = "Pulmoner hastalık var mı?";
        this.labelLE_HD_Pulmonary_Desc.Name = "labelLE_HD_Pulmonary_Desc";
        this.labelLE_HD_Pulmonary_Desc.TabIndex = 41;

        this.LE_HD_Pulmonary_Desc = new TTVisual.TTTextBox();
        this.LE_HD_Pulmonary_Desc.Name = "LE_HD_Pulmonary_Desc";
        this.LE_HD_Pulmonary_Desc.TabIndex = 40;

        this.labelLE_HD_PreferencePetition_Desc = new TTVisual.TTLabel();
        this.labelLE_HD_PreferencePetition_Desc.Text = "Hastanın protez marka";
        this.labelLE_HD_PreferencePetition_Desc.Name = "labelLE_HD_PreferencePetition_Desc";
        this.labelLE_HD_PreferencePetition_Desc.TabIndex = 39;

        this.LE_HD_PreferencePetition_Desc = new TTVisual.TTTextBox();
        this.LE_HD_PreferencePetition_Desc.Name = "LE_HD_PreferencePetition_Desc";
        this.LE_HD_PreferencePetition_Desc.TabIndex = 38;

        this.labelLE_HD_OrganFailure_Desc = new TTVisual.TTLabel();
        this.labelLE_HD_OrganFailure_Desc.Text = "Organ yetmezliği var mı?";
        this.labelLE_HD_OrganFailure_Desc.Name = "labelLE_HD_OrganFailure_Desc";
        this.labelLE_HD_OrganFailure_Desc.TabIndex = 37;

        this.LE_HD_OrganFailure_Desc = new TTVisual.TTTextBox();
        this.LE_HD_OrganFailure_Desc.Name = "LE_HD_OrganFailure_Desc";
        this.LE_HD_OrganFailure_Desc.TabIndex = 36;

        this.labelLE_HD_Neurological_Desc = new TTVisual.TTLabel();
        this.labelLE_HD_Neurological_Desc.Text = "Nörolojik /nöromusküler hastalık var mı?";
        this.labelLE_HD_Neurological_Desc.Name = "labelLE_HD_Neurological_Desc";
        this.labelLE_HD_Neurological_Desc.TabIndex = 35;

        this.LE_HD_Neurological_Desc = new TTVisual.TTTextBox();
        this.LE_HD_Neurological_Desc.Name = "LE_HD_Neurological_Desc";
        this.LE_HD_Neurological_Desc.TabIndex = 34;

        this.labelLE_HD_Musculoskeletal_Desc = new TTVisual.TTLabel();
        this.labelLE_HD_Musculoskeletal_Desc.Text = "Kas-iskelet ";
        this.labelLE_HD_Musculoskeletal_Desc.Name = "labelLE_HD_Musculoskeletal_Desc";
        this.labelLE_HD_Musculoskeletal_Desc.TabIndex = 33;

        this.LE_HD_Musculoskeletal_Desc = new TTVisual.TTTextBox();
        this.LE_HD_Musculoskeletal_Desc.Name = "LE_HD_Musculoskeletal_Desc";
        this.LE_HD_Musculoskeletal_Desc.TabIndex = 32;

        this.labelLE_HD_Contracture_Desc = new TTVisual.TTLabel();
        this.labelLE_HD_Contracture_Desc.Text = "Ampute ekstremitede kontraktür";
        this.labelLE_HD_Contracture_Desc.Name = "labelLE_HD_Contracture_Desc";
        this.labelLE_HD_Contracture_Desc.TabIndex = 31;

        this.LE_HD_Contracture_Desc = new TTVisual.TTTextBox();
        this.LE_HD_Contracture_Desc.Name = "LE_HD_Contracture_Desc";
        this.LE_HD_Contracture_Desc.TabIndex = 30;

        this.labelLE_HD_Cardiovascular_Desc = new TTVisual.TTLabel();
        this.labelLE_HD_Cardiovascular_Desc.Text = "Kardiyovasküler hastalık var mı?";
        this.labelLE_HD_Cardiovascular_Desc.Name = "labelLE_HD_Cardiovascular_Desc";
        this.labelLE_HD_Cardiovascular_Desc.TabIndex = 29;

        this.LE_HD_Cardiovascular_Desc = new TTVisual.TTTextBox();
        this.LE_HD_Cardiovascular_Desc.Name = "LE_HD_Cardiovascular_Desc";
        this.LE_HD_Cardiovascular_Desc.TabIndex = 28;

        this.labelLE_HD_Ambulation_Desc = new TTVisual.TTLabel();
        this.labelLE_HD_Ambulation_Desc.Text = "Ambulasyonu ";
        this.labelLE_HD_Ambulation_Desc.Name = "labelLE_HD_Ambulation_Desc";
        this.labelLE_HD_Ambulation_Desc.TabIndex = 27;

        this.LE_HD_Ambulation_Desc = new TTVisual.TTTextBox();
        this.LE_HD_Ambulation_Desc.Name = "LE_HD_Ambulation_Desc";
        this.LE_HD_Ambulation_Desc.TabIndex = 26;

        this.labelLE_HD_SystemicDisease = new TTVisual.TTLabel();
        this.labelLE_HD_SystemicDisease.Text = "Sistemik ";
        this.labelLE_HD_SystemicDisease.Name = "labelLE_HD_SystemicDisease";
        this.labelLE_HD_SystemicDisease.TabIndex = 25;

        this.LE_HD_SystemicDisease = new TTVisual.TTEnumComboBox();
        this.LE_HD_SystemicDisease.DataTypeName = "YesNoEnum";
        this.LE_HD_SystemicDisease.Name = "LE_HD_SystemicDisease";
        this.LE_HD_SystemicDisease.TabIndex = 24;

        this.labelLE_HD_OrganFailure = new TTVisual.TTLabel();
        this.labelLE_HD_OrganFailure.Text = "Organ yetmezliği var mı?";
        this.labelLE_HD_OrganFailure.Name = "labelLE_HD_OrganFailure";
        this.labelLE_HD_OrganFailure.TabIndex = 23;

        this.LE_HD_OrganFailure = new TTVisual.TTEnumComboBox();
        this.LE_HD_OrganFailure.DataTypeName = "YesNoEnum";
        this.LE_HD_OrganFailure.Name = "LE_HD_OrganFailure";
        this.LE_HD_OrganFailure.TabIndex = 22;

        this.labelLE_HD_Pulmonary = new TTVisual.TTLabel();
        this.labelLE_HD_Pulmonary.Text = "Pulmoner hastalık var mı?";
        this.labelLE_HD_Pulmonary.Name = "labelLE_HD_Pulmonary";
        this.labelLE_HD_Pulmonary.TabIndex = 21;

        this.LE_HD_Pulmonary = new TTVisual.TTEnumComboBox();
        this.LE_HD_Pulmonary.DataTypeName = "YesNoEnum";
        this.LE_HD_Pulmonary.Name = "LE_HD_Pulmonary";
        this.LE_HD_Pulmonary.TabIndex = 20;

        this.labelLE_HD_Cardiovascular = new TTVisual.TTLabel();
        this.labelLE_HD_Cardiovascular.Text = "Kardiyovasküler hastalık var mı?";
        this.labelLE_HD_Cardiovascular.Name = "labelLE_HD_Cardiovascular";
        this.labelLE_HD_Cardiovascular.TabIndex = 19;

        this.LE_HD_Cardiovascular = new TTVisual.TTEnumComboBox();
        this.LE_HD_Cardiovascular.DataTypeName = "YesNoEnum";
        this.LE_HD_Cardiovascular.Name = "LE_HD_Cardiovascular";
        this.LE_HD_Cardiovascular.TabIndex = 18;

        this.labelLE_HD_Neurological = new TTVisual.TTLabel();
        this.labelLE_HD_Neurological.Text = "Nörolojik /nöromusküler hastalık var mı?";
        this.labelLE_HD_Neurological.Name = "labelLE_HD_Neurological";
        this.labelLE_HD_Neurological.TabIndex = 17;

        this.LE_HD_Neurological = new TTVisual.TTEnumComboBox();
        this.LE_HD_Neurological.DataTypeName = "YesNoEnum";
        this.LE_HD_Neurological.Name = "LE_HD_Neurological";
        this.LE_HD_Neurological.TabIndex = 16;

        this.labelLE_HD_Musculoskeletal = new TTVisual.TTLabel();
        this.labelLE_HD_Musculoskeletal.Text = "Kas-iskelet ";
        this.labelLE_HD_Musculoskeletal.Name = "labelLE_HD_Musculoskeletal";
        this.labelLE_HD_Musculoskeletal.TabIndex = 15;

        this.LE_HD_Musculoskeletal = new TTVisual.TTEnumComboBox();
        this.LE_HD_Musculoskeletal.DataTypeName = "YesNoEnum";
        this.LE_HD_Musculoskeletal.Name = "LE_HD_Musculoskeletal";
        this.LE_HD_Musculoskeletal.TabIndex = 14;

        this.labelLE_HD_Ambulation = new TTVisual.TTLabel();
        this.labelLE_HD_Ambulation.Text = "Ambulasyonu ";
        this.labelLE_HD_Ambulation.Name = "labelLE_HD_Ambulation";
        this.labelLE_HD_Ambulation.TabIndex = 13;

        this.LE_HD_Ambulation = new TTVisual.TTEnumComboBox();
        this.LE_HD_Ambulation.DataTypeName = "YesNoEnum";
        this.LE_HD_Ambulation.Name = "LE_HD_Ambulation";
        this.LE_HD_Ambulation.TabIndex = 12;

        this.labelLE_HD_SingleSideAmputate = new TTVisual.TTLabel();
        this.labelLE_HD_SingleSideAmputate.Text = "Tek taraflı amputelerde ";
        this.labelLE_HD_SingleSideAmputate.Name = "labelLE_HD_SingleSideAmputate";
        this.labelLE_HD_SingleSideAmputate.TabIndex = 11;

        this.LE_HD_SingleSideAmputate = new TTVisual.TTEnumComboBox();
        this.LE_HD_SingleSideAmputate.DataTypeName = "YesNoEnum";
        this.LE_HD_SingleSideAmputate.Name = "LE_HD_SingleSideAmputate";
        this.LE_HD_SingleSideAmputate.TabIndex = 10;

        this.labelLE_HD_Contracture = new TTVisual.TTLabel();
        this.labelLE_HD_Contracture.Text = "Ampute ekstremitede kontraktür";
        this.labelLE_HD_Contracture.Name = "labelLE_HD_Contracture";
        this.labelLE_HD_Contracture.TabIndex = 9;

        this.LE_HD_Contracture = new TTVisual.TTEnumComboBox();
        this.LE_HD_Contracture.DataTypeName = "YesNoEnum";
        this.LE_HD_Contracture.Name = "LE_HD_Contracture";
        this.LE_HD_Contracture.TabIndex = 8;

        this.labelLE_HD_WeightTolerance = new TTVisual.TTLabel();
        this.labelLE_HD_WeightTolerance.Text = "Protezin ağırlığı hasta";
        this.labelLE_HD_WeightTolerance.Name = "labelLE_HD_WeightTolerance";
        this.labelLE_HD_WeightTolerance.TabIndex = 7;

        this.LE_HD_WeightTolerance = new TTVisual.TTEnumComboBox();
        this.LE_HD_WeightTolerance.DataTypeName = "YesNoEnum";
        this.LE_HD_WeightTolerance.Name = "LE_HD_WeightTolerance";
        this.LE_HD_WeightTolerance.TabIndex = 6;

        this.labelLE_HD_StumpZone = new TTVisual.TTLabel();
        this.labelLE_HD_StumpZone.Text = "Güdük bölgesinde ";
        this.labelLE_HD_StumpZone.Name = "labelLE_HD_StumpZone";
        this.labelLE_HD_StumpZone.TabIndex = 5;

        this.LE_HD_StumpZone = new TTVisual.TTEnumComboBox();
        this.LE_HD_StumpZone.DataTypeName = "YesNoEnum";
        this.LE_HD_StumpZone.Name = "LE_HD_StumpZone";
        this.LE_HD_StumpZone.TabIndex = 4;

        this.labelLE_HD_PreferencePetition = new TTVisual.TTLabel();
        this.labelLE_HD_PreferencePetition.Text = "Hastanın protez marka";
        this.labelLE_HD_PreferencePetition.Name = "labelLE_HD_PreferencePetition";
        this.labelLE_HD_PreferencePetition.TabIndex = 3;

        this.LE_HD_PreferencePetition = new TTVisual.TTEnumComboBox();
        this.LE_HD_PreferencePetition.DataTypeName = "YesNoEnum";
        this.LE_HD_PreferencePetition.Name = "LE_HD_PreferencePetition";
        this.LE_HD_PreferencePetition.TabIndex = 2;

        this.labelLE_HD_AktivityLevel = new TTVisual.TTLabel();
        this.labelLE_HD_AktivityLevel.Text = "Aktivite düzeyi ";
        this.labelLE_HD_AktivityLevel.Name = "labelLE_HD_AktivityLevel";
        this.labelLE_HD_AktivityLevel.TabIndex = 1;

        this.LE_HD_AktivityLevel = new TTVisual.TTTextBox();
        this.LE_HD_AktivityLevel.Name = "LE_HD_AktivityLevel";
        this.LE_HD_AktivityLevel.TabIndex = 0;

        this.ttgroupbox2 = new TTVisual.TTGroupBox();
        this.ttgroupbox2.Text = "Reçete İçeriği";
        this.ttgroupbox2.Name = "ttgroupbox2";
        this.ttgroupbox2.TabIndex = 1;

        this.labelLE_WetSignature = new TTVisual.TTLabel();
        this.labelLE_WetSignature.Text = "Islak İmza Varmı?";
        this.labelLE_WetSignature.Name = "labelLE_WetSignature";
        this.labelLE_WetSignature.TabIndex = 13;

        this.LE_WetSignature = new TTVisual.TTEnumComboBox();
        this.LE_WetSignature.DataTypeName = "YesNoEnum";
        this.LE_WetSignature.Name = "LE_WetSignature";
        this.LE_WetSignature.TabIndex = 12;

        this.labelLE_PatientNameSurname = new TTVisual.TTLabel();
        this.labelLE_PatientNameSurname.Text = "Hasta Adı Soyadı ve T.C kimlik NumarasıVar mı?";
        this.labelLE_PatientNameSurname.Name = "labelLE_PatientNameSurname";
        this.labelLE_PatientNameSurname.TabIndex = 11;

        this.LE_PatientNameSurname = new TTVisual.TTEnumComboBox();
        this.LE_PatientNameSurname.DataTypeName = "YesNoEnum";
        this.LE_PatientNameSurname.Name = "LE_PatientNameSurname";
        this.LE_PatientNameSurname.TabIndex = 10;

        this.labelLE_MedulaOrProtocolNo = new TTVisual.TTLabel();
        this.labelLE_MedulaOrProtocolNo.Text = "Medula veya Protokol Numarası Var mı?";
        this.labelLE_MedulaOrProtocolNo.Name = "labelLE_MedulaOrProtocolNo";
        this.labelLE_MedulaOrProtocolNo.TabIndex = 9;

        this.LE_MedulaOrProtocolNo = new TTVisual.TTEnumComboBox();
        this.LE_MedulaOrProtocolNo.DataTypeName = "YesNoEnum";
        this.LE_MedulaOrProtocolNo.Name = "LE_MedulaOrProtocolNo";
        this.LE_MedulaOrProtocolNo.TabIndex = 8;

        this.labelLE_MedulaInsCode = new TTVisual.TTLabel();
        this.labelLE_MedulaInsCode.Text = "Reçeteyi düzenleyen sağlık hizmet sunucusu adı veya MEDULA tesis kodu var mı?";
        this.labelLE_MedulaInsCode.Name = "labelLE_MedulaInsCode";
        this.labelLE_MedulaInsCode.TabIndex = 7;

        this.LE_MedulaInsCode = new TTVisual.TTEnumComboBox();
        this.LE_MedulaInsCode.DataTypeName = "YesNoEnum";
        this.LE_MedulaInsCode.Name = "LE_MedulaInsCode";
        this.LE_MedulaInsCode.TabIndex = 6;

        this.labelLE_MachineNameIsCorrect = new TTVisual.TTLabel();
        this.labelLE_MachineNameIsCorrect.Text = "Cihazın adı/taraf/adet bilgisi doğrumu?";
        this.labelLE_MachineNameIsCorrect.Name = "labelLE_MachineNameIsCorrect";
        this.labelLE_MachineNameIsCorrect.TabIndex = 5;

        this.LE_MachineNameIsCorrect = new TTVisual.TTEnumComboBox();
        this.LE_MachineNameIsCorrect.DataTypeName = "YesNoEnum";
        this.LE_MachineNameIsCorrect.Name = "LE_MachineNameIsCorrect";
        this.LE_MachineNameIsCorrect.TabIndex = 4;

        this.labelLE_MachineName = new TTVisual.TTLabel();
        this.labelLE_MachineName.Text = "Cihazın adı/taraf/adet bilgisi var mı?";
        this.labelLE_MachineName.Name = "labelLE_MachineName";
        this.labelLE_MachineName.TabIndex = 3;

        this.LE_MachineName = new TTVisual.TTEnumComboBox();
        this.LE_MachineName.DataTypeName = "YesNoEnum";
        this.LE_MachineName.Name = "LE_MachineName";
        this.LE_MachineName.TabIndex = 2;

        this.labelLE_DiagnosAndICD10Code = new TTVisual.TTLabel();
        this.labelLE_DiagnosAndICD10Code.Text = "Tanı ve ICD-10 Kodu Varmı";
        this.labelLE_DiagnosAndICD10Code.Name = "labelLE_DiagnosAndICD10Code";
        this.labelLE_DiagnosAndICD10Code.TabIndex = 1;

        this.LE_DiagnosAndICD10Code = new TTVisual.TTEnumComboBox();
        this.LE_DiagnosAndICD10Code.DataTypeName = "YesNoEnum";
        this.LE_DiagnosAndICD10Code.Name = "LE_DiagnosAndICD10Code";
        this.LE_DiagnosAndICD10Code.TabIndex = 0;

        this.ttgroupbox1 = new TTVisual.TTGroupBox();
        this.ttgroupbox1.Text = "Sağlık Kurulu Raporu";
        this.ttgroupbox1.Name = "ttgroupbox1";
        this.ttgroupbox1.TabIndex = 0;

        this.labelLE_SK_ProstheticType = new TTVisual.TTLabel();
        this.labelLE_SK_ProstheticType.Text = "Raporda yazılan protez tipi:";
        this.labelLE_SK_ProstheticType.Name = "labelLE_SK_ProstheticType";
        this.labelLE_SK_ProstheticType.TabIndex = 13;

        this.LE_SK_ProstheticType = new TTVisual.TTTextBox();
        this.LE_SK_ProstheticType.Name = "LE_SK_ProstheticType";
        this.LE_SK_ProstheticType.TabIndex = 12;

        this.labelLE_ThirdStepHealthInst = new TTVisual.TTLabel();
        this.labelLE_ThirdStepHealthInst.Text = "3. basamak sağlık kurumu";
        this.labelLE_ThirdStepHealthInst.Name = "labelLE_ThirdStepHealthInst";
        this.labelLE_ThirdStepHealthInst.TabIndex = 11;

        this.LE_ThirdStepHealthInst = new TTVisual.TTEnumComboBox();
        this.LE_ThirdStepHealthInst.DataTypeName = "YesNoEnum";
        this.LE_ThirdStepHealthInst.Name = "LE_ThirdStepHealthInst";
        this.LE_ThirdStepHealthInst.TabIndex = 10;

        this.labelLE_PsychiatricExpertApprove = new TTVisual.TTLabel();
        this.labelLE_PsychiatricExpertApprove.Text = "Psikiyatri Uzman Onayı Var mı?";
        this.labelLE_PsychiatricExpertApprove.Name = "labelLE_PsychiatricExpertApprove";
        this.labelLE_PsychiatricExpertApprove.TabIndex = 9;

        this.LE_PsychiatricExpertApprove = new TTVisual.TTEnumComboBox();
        this.LE_PsychiatricExpertApprove.DataTypeName = "YesNoEnum";
        this.LE_PsychiatricExpertApprove.Name = "LE_PsychiatricExpertApprove";
        this.LE_PsychiatricExpertApprove.TabIndex = 8;

        this.labelLE_OrthopedicExpertApprove = new TTVisual.TTLabel();
        this.labelLE_OrthopedicExpertApprove.Text = "Ortopedi Uzman Onayı Var mı?";
        this.labelLE_OrthopedicExpertApprove.Name = "labelLE_OrthopedicExpertApprove";
        this.labelLE_OrthopedicExpertApprove.TabIndex = 7;

        this.LE_OrthopedicExpertApprove = new TTVisual.TTEnumComboBox();
        this.LE_OrthopedicExpertApprove.DataTypeName = "YesNoEnum";
        this.LE_OrthopedicExpertApprove.Name = "LE_OrthopedicExpertApprove";
        this.LE_OrthopedicExpertApprove.TabIndex = 6;

        this.labelLE_MedicalReason = new TTVisual.TTLabel();
        this.labelLE_MedicalReason.Text = "Tıbbi Gerekçe Yazılmış mı?";
        this.labelLE_MedicalReason.Name = "labelLE_MedicalReason";
        this.labelLE_MedicalReason.TabIndex = 5;

        this.LE_MedicalReason = new TTVisual.TTEnumComboBox();
        this.LE_MedicalReason.DataTypeName = "YesNoEnum";
        this.LE_MedicalReason.Name = "LE_MedicalReason";
        this.LE_MedicalReason.TabIndex = 4;

        this.labelLE_HeadDoctorApprove = new TTVisual.TTLabel();
        this.labelLE_HeadDoctorApprove.Text = "Başhekim Onayı Var mı?";
        this.labelLE_HeadDoctorApprove.Name = "labelLE_HeadDoctorApprove";
        this.labelLE_HeadDoctorApprove.TabIndex = 3;

        this.LE_HeadDoctorApprove = new TTVisual.TTEnumComboBox();
        this.LE_HeadDoctorApprove.DataTypeName = "YesNoEnum";
        this.LE_HeadDoctorApprove.Name = "LE_HeadDoctorApprove";
        this.LE_HeadDoctorApprove.TabIndex = 2;

        this.labelLE_FTRExpertApprove = new TTVisual.TTLabel();
        this.labelLE_FTRExpertApprove.Text = "FTR Uzman Onayı Var mı?";
        this.labelLE_FTRExpertApprove.Name = "labelLE_FTRExpertApprove";
        this.labelLE_FTRExpertApprove.TabIndex = 1;

        this.LE_FTRExpertApprove = new TTVisual.TTEnumComboBox();
        this.LE_FTRExpertApprove.DataTypeName = "YesNoEnum";
        this.LE_FTRExpertApprove.Name = "LE_FTRExpertApprove";
        this.LE_FTRExpertApprove.TabIndex = 0;

        this.tttabpage2 = new TTVisual.TTTabPage();
        this.tttabpage2.DisplayIndex = 1;
        this.tttabpage2.TabIndex = 1;
        this.tttabpage2.Text = "MYOELEKTRİK ÜST EKSTREMİTE ";
        this.tttabpage2.Name = "tttabpage2";

        this.labelUE_ProstheticType = new TTVisual.TTLabel();
        this.labelUE_ProstheticType.Text = "Protez tipi";
        this.labelUE_ProstheticType.Name = "labelUE_ProstheticType";
        this.labelUE_ProstheticType.TabIndex = 12;

        this.UE_ProstheticType = new TTVisual.TTTextBox();
        this.UE_ProstheticType.Name = "UE_ProstheticType";
        this.UE_ProstheticType.TabIndex = 11;

        this.labelUE_ProsthesisNumber = new TTVisual.TTLabel();
        this.labelUE_ProsthesisNumber.Text = "Kaçıncı protezi olduğu ";
        this.labelUE_ProsthesisNumber.Name = "labelUE_ProsthesisNumber";
        this.labelUE_ProsthesisNumber.TabIndex = 10;

        this.UE_ProsthesisNumber = new TTVisual.TTTextBox();
        this.UE_ProsthesisNumber.Name = "UE_ProsthesisNumber";
        this.UE_ProsthesisNumber.TabIndex = 9;

        this.labelUE_ConstructionDate = new TTVisual.TTLabel();
        this.labelUE_ConstructionDate.Text = "Yapım tarihi";
        this.labelUE_ConstructionDate.Name = "labelUE_ConstructionDate";
        this.labelUE_ConstructionDate.TabIndex = 8;

        this.UE_ConstructionDate = new TTVisual.TTTextBox();
        this.UE_ConstructionDate.Name = "UE_ConstructionDate";
        this.UE_ConstructionDate.TabIndex = 7;

        this.labelUE_CauseOfInjury = new TTVisual.TTLabel();
        this.labelUE_CauseOfInjury.Text = "Yaralanma nedeni ve tarihi";
        this.labelUE_CauseOfInjury.Name = "labelUE_CauseOfInjury";
        this.labelUE_CauseOfInjury.TabIndex = 6;

        this.UE_CauseOfInjury = new TTVisual.TTTextBox();
        this.UE_CauseOfInjury.Name = "UE_CauseOfInjury";
        this.UE_CauseOfInjury.TabIndex = 5;

        this.labelUE_AmputationDate = new TTVisual.TTLabel();
        this.labelUE_AmputationDate.Text = "Amputasyon tarihi";
        this.labelUE_AmputationDate.Name = "labelUE_AmputationDate";
        this.labelUE_AmputationDate.TabIndex = 4;

        this.UE_AmputationDate = new TTVisual.TTTextBox();
        this.UE_AmputationDate.Name = "UE_AmputationDate";
        this.UE_AmputationDate.TabIndex = 3;

        this.ttgroupbox7 = new TTVisual.TTGroupBox();
        this.ttgroupbox7.Text = "Hasta Değerlendirmesi";
        this.ttgroupbox7.Name = "ttgroupbox7";
        this.ttgroupbox7.TabIndex = 2;

        this.labelUE_HD_SufficientStump_Desc = new TTVisual.TTLabel();
        this.labelUE_HD_SufficientStump_Desc.Text = "yeterli güdük uzunluğuna sahip mi?";
        this.labelUE_HD_SufficientStump_Desc.Name = "labelUE_HD_SufficientStump_Desc";
        this.labelUE_HD_SufficientStump_Desc.TabIndex = 53;

        this.UE_HD_SufficientStump_Desc = new TTVisual.TTTextBox();
        this.UE_HD_SufficientStump_Desc.Name = "UE_HD_SufficientStump_Desc";
        this.UE_HD_SufficientStump_Desc.TabIndex = 52;

        this.labelUE_HD_PreferencePetition = new TTVisual.TTLabel();
        this.labelUE_HD_PreferencePetition.Text = "Hastanın protez marka/model";
        this.labelUE_HD_PreferencePetition.Name = "labelUE_HD_PreferencePetition";
        this.labelUE_HD_PreferencePetition.TabIndex = 51;

        this.UE_HD_PreferencePetition_Desc = new TTVisual.TTTextBox();
        this.UE_HD_PreferencePetition_Desc.Name = "UE_HD_PreferencePetition_Desc";
        this.UE_HD_PreferencePetition_Desc.TabIndex = 50;

        this.labelUE_HD_Myoelectric = new TTVisual.TTLabel();
        this.labelUE_HD_Myoelectric.Text = "Myoelektrik ";
        this.labelUE_HD_Myoelectric.Name = "labelUE_HD_Myoelectric";
        this.labelUE_HD_Myoelectric.TabIndex = 49;

        this.UE_HD_Myoelectric = new TTVisual.TTEnumComboBox();
        this.UE_HD_Myoelectric.DataTypeName = "YesNoEnum";
        this.UE_HD_Myoelectric.Name = "UE_HD_Myoelectric";
        this.UE_HD_Myoelectric.TabIndex = 48;

        this.labelUE_HD_SystemicDisease_Desc = new TTVisual.TTLabel();
        this.labelUE_HD_SystemicDisease_Desc.Text = "Sistemik ";
        this.labelUE_HD_SystemicDisease_Desc.Name = "labelUE_HD_SystemicDisease_Desc";
        this.labelUE_HD_SystemicDisease_Desc.TabIndex = 47;

        this.UE_HD_SystemicDisease_Desc = new TTVisual.TTTextBox();
        this.UE_HD_SystemicDisease_Desc.Name = "UE_HD_SystemicDisease_Desc";
        this.UE_HD_SystemicDisease_Desc.TabIndex = 46;

        this.labelUE_HD_SystemicDisease = new TTVisual.TTLabel();
        this.labelUE_HD_SystemicDisease.Text = "Sistemik ";
        this.labelUE_HD_SystemicDisease.Name = "labelUE_HD_SystemicDisease";
        this.labelUE_HD_SystemicDisease.TabIndex = 45;

        this.UE_HD_SystemicDisease = new TTVisual.TTEnumComboBox();
        this.UE_HD_SystemicDisease.DataTypeName = "YesNoEnum";
        this.UE_HD_SystemicDisease.Name = "UE_HD_SystemicDisease";
        this.UE_HD_SystemicDisease.TabIndex = 44;

        this.labelUE_HD_OrganFailure_Desc = new TTVisual.TTLabel();
        this.labelUE_HD_OrganFailure_Desc.Text = "Organ yetmezliği var mı?";
        this.labelUE_HD_OrganFailure_Desc.Name = "labelUE_HD_OrganFailure_Desc";
        this.labelUE_HD_OrganFailure_Desc.TabIndex = 43;

        this.UE_HD_OrganFailure_Desc = new TTVisual.TTTextBox();
        this.UE_HD_OrganFailure_Desc.Name = "UE_HD_OrganFailure_Desc";
        this.UE_HD_OrganFailure_Desc.TabIndex = 42;

        this.labelUE_HD_OrganFailure = new TTVisual.TTLabel();
        this.labelUE_HD_OrganFailure.Text = "Organ yetmezliği var mı?";
        this.labelUE_HD_OrganFailure.Name = "labelUE_HD_OrganFailure";
        this.labelUE_HD_OrganFailure.TabIndex = 41;

        this.UE_HD_OrganFailure = new TTVisual.TTEnumComboBox();
        this.UE_HD_OrganFailure.DataTypeName = "YesNoEnum";
        this.UE_HD_OrganFailure.Name = "UE_HD_OrganFailure";
        this.UE_HD_OrganFailure.TabIndex = 40;

        this.labelUE_HD_Pulmonary_Desc = new TTVisual.TTLabel();
        this.labelUE_HD_Pulmonary_Desc.Text = "Pulmoner hastalık var mı?";
        this.labelUE_HD_Pulmonary_Desc.Name = "labelUE_HD_Pulmonary_Desc";
        this.labelUE_HD_Pulmonary_Desc.TabIndex = 39;

        this.UE_HD_Pulmonary_Desc = new TTVisual.TTTextBox();
        this.UE_HD_Pulmonary_Desc.Name = "UE_HD_Pulmonary_Desc";
        this.UE_HD_Pulmonary_Desc.TabIndex = 38;

        this.labelUE_HD_Pulmonary = new TTVisual.TTLabel();
        this.labelUE_HD_Pulmonary.Text = "Pulmoner hastalık var mı?";
        this.labelUE_HD_Pulmonary.Name = "labelUE_HD_Pulmonary";
        this.labelUE_HD_Pulmonary.TabIndex = 37;

        this.UE_HD_Pulmonary = new TTVisual.TTEnumComboBox();
        this.UE_HD_Pulmonary.DataTypeName = "YesNoEnum";
        this.UE_HD_Pulmonary.Name = "UE_HD_Pulmonary";
        this.UE_HD_Pulmonary.TabIndex = 36;

        this.labelUE_HD_Cardiovascular_Desc = new TTVisual.TTLabel();
        this.labelUE_HD_Cardiovascular_Desc.Text = "Kardiyovasküler hastalık var mı?";
        this.labelUE_HD_Cardiovascular_Desc.Name = "labelUE_HD_Cardiovascular_Desc";
        this.labelUE_HD_Cardiovascular_Desc.TabIndex = 35;

        this.UE_HD_Cardiovascular_Desc = new TTVisual.TTTextBox();
        this.UE_HD_Cardiovascular_Desc.Name = "UE_HD_Cardiovascular_Desc";
        this.UE_HD_Cardiovascular_Desc.TabIndex = 34;

        this.labelUE_HD_Cardiovascular = new TTVisual.TTLabel();
        this.labelUE_HD_Cardiovascular.Text = "Kardiyovasküler hastalık var mı?";
        this.labelUE_HD_Cardiovascular.Name = "labelUE_HD_Cardiovascular";
        this.labelUE_HD_Cardiovascular.TabIndex = 33;

        this.UE_HD_Cardiovascular = new TTVisual.TTEnumComboBox();
        this.UE_HD_Cardiovascular.DataTypeName = "YesNoEnum";
        this.UE_HD_Cardiovascular.Name = "UE_HD_Cardiovascular";
        this.UE_HD_Cardiovascular.TabIndex = 32;

        this.labelUE_HD_Neurological_Desc = new TTVisual.TTLabel();
        this.labelUE_HD_Neurological_Desc.Text = "Nörolojik /nöromusküler hastalık var mı?";
        this.labelUE_HD_Neurological_Desc.Name = "labelUE_HD_Neurological_Desc";
        this.labelUE_HD_Neurological_Desc.TabIndex = 31;

        this.UE_HD_Neurological_Desc = new TTVisual.TTTextBox();
        this.UE_HD_Neurological_Desc.Name = "UE_HD_Neurological_Desc";
        this.UE_HD_Neurological_Desc.TabIndex = 30;

        this.labelUE_HD_Neurological = new TTVisual.TTLabel();
        this.labelUE_HD_Neurological.Text = "Nörolojik /nöromusküler hastalık var mı?";
        this.labelUE_HD_Neurological.Name = "labelUE_HD_Neurological";
        this.labelUE_HD_Neurological.TabIndex = 29;

        this.UE_HD_Neurological = new TTVisual.TTEnumComboBox();
        this.UE_HD_Neurological.DataTypeName = "YesNoEnum";
        this.UE_HD_Neurological.Name = "UE_HD_Neurological";
        this.UE_HD_Neurological.TabIndex = 28;

        this.labelUE_HD_Musculoskeletal_Desc = new TTVisual.TTLabel();
        this.labelUE_HD_Musculoskeletal_Desc.Text = "Kas-iskelet ";
        this.labelUE_HD_Musculoskeletal_Desc.Name = "labelUE_HD_Musculoskeletal_Desc";
        this.labelUE_HD_Musculoskeletal_Desc.TabIndex = 27;

        this.UE_HD_Musculoskeletal_Desc = new TTVisual.TTTextBox();
        this.UE_HD_Musculoskeletal_Desc.Name = "UE_HD_Musculoskeletal_Desc";
        this.UE_HD_Musculoskeletal_Desc.TabIndex = 26;

        this.labelUE_HD_Musculoskeletal = new TTVisual.TTLabel();
        this.labelUE_HD_Musculoskeletal.Text = "Kas-iskelet ";
        this.labelUE_HD_Musculoskeletal.Name = "labelUE_HD_Musculoskeletal";
        this.labelUE_HD_Musculoskeletal.TabIndex = 25;

        this.UE_HD_Musculoskeletal = new TTVisual.TTEnumComboBox();
        this.UE_HD_Musculoskeletal.DataTypeName = "YesNoEnum";
        this.UE_HD_Musculoskeletal.Name = "UE_HD_Musculoskeletal";
        this.UE_HD_Musculoskeletal.TabIndex = 24;

        this.labelUE_HD_Contracture_Desc = new TTVisual.TTLabel();
        this.labelUE_HD_Contracture_Desc.Text = "Ampute ekstremitede kontraktür";
        this.labelUE_HD_Contracture_Desc.Name = "labelUE_HD_Contracture_Desc";
        this.labelUE_HD_Contracture_Desc.TabIndex = 23;

        this.UE_HD_Contracture_Desc = new TTVisual.TTTextBox();
        this.UE_HD_Contracture_Desc.Name = "UE_HD_Contracture_Desc";
        this.UE_HD_Contracture_Desc.TabIndex = 22;

        this.labelUE_HD_Contracture = new TTVisual.TTLabel();
        this.labelUE_HD_Contracture.Text = "Ampute ekstremitede kontraktür";
        this.labelUE_HD_Contracture.Name = "labelUE_HD_Contracture";
        this.labelUE_HD_Contracture.TabIndex = 21;

        this.UE_HD_Contracture = new TTVisual.TTEnumComboBox();
        this.UE_HD_Contracture.DataTypeName = "YesNoEnum";
        this.UE_HD_Contracture.Name = "UE_HD_Contracture";
        this.UE_HD_Contracture.TabIndex = 20;

        this.labelUE_HD_StumpZone_Desc = new TTVisual.TTLabel();
        this.labelUE_HD_StumpZone_Desc.Text = "Güdük bölgesinde ";
        this.labelUE_HD_StumpZone_Desc.Name = "labelUE_HD_StumpZone_Desc";
        this.labelUE_HD_StumpZone_Desc.TabIndex = 19;

        this.UE_HD_StumpZone_Desc = new TTVisual.TTTextBox();
        this.UE_HD_StumpZone_Desc.Name = "UE_HD_StumpZone_Desc";
        this.UE_HD_StumpZone_Desc.TabIndex = 18;

        this.labelUE_HD_StumpZone = new TTVisual.TTLabel();
        this.labelUE_HD_StumpZone.Text = "Güdük bölgesinde ";
        this.labelUE_HD_StumpZone.Name = "labelUE_HD_StumpZone";
        this.labelUE_HD_StumpZone.TabIndex = 17;

        this.UE_HD_StumpZone = new TTVisual.TTEnumComboBox();
        this.UE_HD_StumpZone.DataTypeName = "YesNoEnum";
        this.UE_HD_StumpZone.Name = "UE_HD_StumpZone";
        this.UE_HD_StumpZone.TabIndex = 16;

        this.labelUE_HD_FunctionalMovement_Desc = new TTVisual.TTLabel();
        this.labelUE_HD_FunctionalMovement_Desc.Text = "fonksiyonel hareketler";
        this.labelUE_HD_FunctionalMovement_Desc.Name = "labelUE_HD_FunctionalMovement_Desc";
        this.labelUE_HD_FunctionalMovement_Desc.TabIndex = 15;

        this.UE_HD_FunctionalMovement_Desc = new TTVisual.TTTextBox();
        this.UE_HD_FunctionalMovement_Desc.Name = "UE_HD_FunctionalMovement_Desc";
        this.UE_HD_FunctionalMovement_Desc.TabIndex = 14;

        this.labelUE_HD_FunctionalMovements = new TTVisual.TTLabel();
        this.labelUE_HD_FunctionalMovements.Text = "fonksiyonel hareketler";
        this.labelUE_HD_FunctionalMovements.Name = "labelUE_HD_FunctionalMovements";
        this.labelUE_HD_FunctionalMovements.TabIndex = 13;

        this.UE_HD_FunctionalMovements = new TTVisual.TTEnumComboBox();
        this.UE_HD_FunctionalMovements.DataTypeName = "YesNoEnum";
        this.UE_HD_FunctionalMovements.Name = "UE_HD_FunctionalMovements";
        this.UE_HD_FunctionalMovements.TabIndex = 12;

        this.labelUE_HD_SingleSideAmputate_Desc = new TTVisual.TTLabel();
        this.labelUE_HD_SingleSideAmputate_Desc.Text = "Tek taraflı amputelerde ";
        this.labelUE_HD_SingleSideAmputate_Desc.Name = "labelUE_HD_SingleSideAmputate_Desc";
        this.labelUE_HD_SingleSideAmputate_Desc.TabIndex = 11;

        this.UE_HD_SingleSideAmputate_Desc = new TTVisual.TTTextBox();
        this.UE_HD_SingleSideAmputate_Desc.Name = "UE_HD_SingleSideAmputate_Desc";
        this.UE_HD_SingleSideAmputate_Desc.TabIndex = 10;

        this.labelUE_HD_SingleSideAmputate = new TTVisual.TTLabel();
        this.labelUE_HD_SingleSideAmputate.Text = "Tek taraflı amputelerde ";
        this.labelUE_HD_SingleSideAmputate.Name = "labelUE_HD_SingleSideAmputate";
        this.labelUE_HD_SingleSideAmputate.TabIndex = 9;

        this.UE_HD_SingleSideAmputate = new TTVisual.TTEnumComboBox();
        this.UE_HD_SingleSideAmputate.DataTypeName = "YesNoEnum";
        this.UE_HD_SingleSideAmputate.Name = "UE_HD_SingleSideAmputate";
        this.UE_HD_SingleSideAmputate.TabIndex = 8;

        this.labelUE_HD_SufficientStumpLength = new TTVisual.TTLabel();
        this.labelUE_HD_SufficientStumpLength.Text = "yeterli güdük uzunluğuna sahip mi?";
        this.labelUE_HD_SufficientStumpLength.Name = "labelUE_HD_SufficientStumpLength";
        this.labelUE_HD_SufficientStumpLength.TabIndex = 7;

        this.UE_HD_SufficientStumpLength = new TTVisual.TTEnumComboBox();
        this.UE_HD_SufficientStumpLength.DataTypeName = "YesNoEnum";
        this.UE_HD_SufficientStumpLength.Name = "UE_HD_SufficientStumpLength";
        this.UE_HD_SufficientStumpLength.TabIndex = 6;

        this.ttlabel1 = new TTVisual.TTLabel();
        this.ttlabel1.Text = "Hastanın protez marka";
        this.ttlabel1.Name = "ttlabel1";
        this.ttlabel1.TabIndex = 5;

        this.UE_HD_PreferencePetition = new TTVisual.TTEnumComboBox();
        this.UE_HD_PreferencePetition.DataTypeName = "YesNoEnum";
        this.UE_HD_PreferencePetition.Name = "UE_HD_PreferencePetition";
        this.UE_HD_PreferencePetition.TabIndex = 4;

        this.labelUE_HD_StumpLength = new TTVisual.TTLabel();
        this.labelUE_HD_StumpLength.Text = "Güdük uzunluğu (cm)";
        this.labelUE_HD_StumpLength.Name = "labelUE_HD_StumpLength";
        this.labelUE_HD_StumpLength.TabIndex = 3;

        this.UE_HD_StumpLength = new TTVisual.TTTextBox();
        this.UE_HD_StumpLength.Name = "UE_HD_StumpLength";
        this.UE_HD_StumpLength.TabIndex = 2;

        this.labelUE_HD_AmputationLevel = new TTVisual.TTLabel();
        this.labelUE_HD_AmputationLevel.Text = "Amputasyon seviyesi";
        this.labelUE_HD_AmputationLevel.Name = "labelUE_HD_AmputationLevel";
        this.labelUE_HD_AmputationLevel.TabIndex = 1;

        this.UE_HD_AmputationLevel = new TTVisual.TTTextBox();
        this.UE_HD_AmputationLevel.Name = "UE_HD_AmputationLevel";
        this.UE_HD_AmputationLevel.TabIndex = 0;

        this.ttgroupbox6 = new TTVisual.TTGroupBox();
        this.ttgroupbox6.Text = "Reçete İçeriği";
        this.ttgroupbox6.Name = "ttgroupbox6";
        this.ttgroupbox6.TabIndex = 1;

        this.labelUE_RI_WetSignature = new TTVisual.TTLabel();
        this.labelUE_RI_WetSignature.Text = "Islak İmza Varmı?";
        this.labelUE_RI_WetSignature.Name = "labelUE_RI_WetSignature";
        this.labelUE_RI_WetSignature.TabIndex = 15;

        this.UE_RI_WetSignature = new TTVisual.TTEnumComboBox();
        this.UE_RI_WetSignature.DataTypeName = "YesNoEnum";
        this.UE_RI_WetSignature.Name = "UE_RI_WetSignature";
        this.UE_RI_WetSignature.TabIndex = 14;

        this.labelUE_RI_MachineNameIsCorrect = new TTVisual.TTLabel();
        this.labelUE_RI_MachineNameIsCorrect.Text = "Cihazın adı/taraf/adet bilgisi doğrumu?";
        this.labelUE_RI_MachineNameIsCorrect.Name = "labelUE_RI_MachineNameIsCorrect";
        this.labelUE_RI_MachineNameIsCorrect.TabIndex = 13;

        this.UE_RI_MachineNameIsCorrect = new TTVisual.TTEnumComboBox();
        this.UE_RI_MachineNameIsCorrect.DataTypeName = "YesNoEnum";
        this.UE_RI_MachineNameIsCorrect.Name = "UE_RI_MachineNameIsCorrect";
        this.UE_RI_MachineNameIsCorrect.TabIndex = 12;

        this.labelUE_RI_DiagnosAndICD10Code = new TTVisual.TTLabel();
        this.labelUE_RI_DiagnosAndICD10Code.Text = "Tanı ve ICD-10 Kodu Varmı";
        this.labelUE_RI_DiagnosAndICD10Code.Name = "labelUE_RI_DiagnosAndICD10Code";
        this.labelUE_RI_DiagnosAndICD10Code.TabIndex = 11;

        this.UE_RI_DiagnosAndICD10Code = new TTVisual.TTEnumComboBox();
        this.UE_RI_DiagnosAndICD10Code.DataTypeName = "YesNoEnum";
        this.UE_RI_DiagnosAndICD10Code.Name = "UE_RI_DiagnosAndICD10Code";
        this.UE_RI_DiagnosAndICD10Code.TabIndex = 10;

        this.labelUE_RI_MachineName = new TTVisual.TTLabel();
        this.labelUE_RI_MachineName.Text = "Cihazın adı/taraf/adet bilgisi var mı?";
        this.labelUE_RI_MachineName.Name = "labelUE_RI_MachineName";
        this.labelUE_RI_MachineName.TabIndex = 9;

        this.UE_RI_MachineName = new TTVisual.TTEnumComboBox();
        this.UE_RI_MachineName.DataTypeName = "YesNoEnum";
        this.UE_RI_MachineName.Name = "UE_RI_MachineName";
        this.UE_RI_MachineName.TabIndex = 8;

        this.labelUE_RI_MedulaOrProtocolNo = new TTVisual.TTLabel();
        this.labelUE_RI_MedulaOrProtocolNo.Text = "Medula veya Protokol Numarası Var mı?";
        this.labelUE_RI_MedulaOrProtocolNo.Name = "labelUE_RI_MedulaOrProtocolNo";
        this.labelUE_RI_MedulaOrProtocolNo.TabIndex = 7;

        this.UE_RI_MedulaOrProtocolNo = new TTVisual.TTEnumComboBox();
        this.UE_RI_MedulaOrProtocolNo.DataTypeName = "YesNoEnum";
        this.UE_RI_MedulaOrProtocolNo.Name = "UE_RI_MedulaOrProtocolNo";
        this.UE_RI_MedulaOrProtocolNo.TabIndex = 6;

        this.labelUE_RI_Date = new TTVisual.TTLabel();
        this.labelUE_RI_Date.Text = "Tarih var mı?";
        this.labelUE_RI_Date.Name = "labelUE_RI_Date";
        this.labelUE_RI_Date.TabIndex = 5;

        this.UE_RI_Date = new TTVisual.TTEnumComboBox();
        this.UE_RI_Date.DataTypeName = "YesNoEnum";
        this.UE_RI_Date.Name = "UE_RI_Date";
        this.UE_RI_Date.TabIndex = 4;

        this.labelUE_RI_MedulaInsCode = new TTVisual.TTLabel();
        this.labelUE_RI_MedulaInsCode.Text = "Reçeteyi düzenleyen";
        this.labelUE_RI_MedulaInsCode.Name = "labelUE_RI_MedulaInsCode";
        this.labelUE_RI_MedulaInsCode.TabIndex = 3;

        this.UE_RI_MedulaInsCode = new TTVisual.TTEnumComboBox();
        this.UE_RI_MedulaInsCode.DataTypeName = "YesNoEnum";
        this.UE_RI_MedulaInsCode.Name = "UE_RI_MedulaInsCode";
        this.UE_RI_MedulaInsCode.TabIndex = 2;

        this.labelUE_RI_PatientNameSurname = new TTVisual.TTLabel();
        this.labelUE_RI_PatientNameSurname.Text = "Hasta Adı Soyadı";
        this.labelUE_RI_PatientNameSurname.Name = "labelUE_RI_PatientNameSurname";
        this.labelUE_RI_PatientNameSurname.TabIndex = 1;

        this.UE_RI_PatientNameSurname = new TTVisual.TTEnumComboBox();
        this.UE_RI_PatientNameSurname.DataTypeName = "YesNoEnum";
        this.UE_RI_PatientNameSurname.Name = "UE_RI_PatientNameSurname";
        this.UE_RI_PatientNameSurname.TabIndex = 0;

        this.ttgroupbox5 = new TTVisual.TTGroupBox();
        this.ttgroupbox5.Text = "Sağlık Kurulu Raporu";
        this.ttgroupbox5.Name = "ttgroupbox5";
        this.ttgroupbox5.TabIndex = 0;

        this.labelUE_SK_ProstheticType = new TTVisual.TTLabel();
        this.labelUE_SK_ProstheticType.Text = "Raporda yazılan protez tipi:";
        this.labelUE_SK_ProstheticType.Name = "labelUE_SK_ProstheticType";
        this.labelUE_SK_ProstheticType.TabIndex = 15;

        this.UE_SK_ProstheticType = new TTVisual.TTTextBox();
        this.UE_SK_ProstheticType.Name = "UE_SK_ProstheticType";
        this.UE_SK_ProstheticType.TabIndex = 14;

        this.labelUE_SK_ThirdStepHealthInst = new TTVisual.TTLabel();
        this.labelUE_SK_ThirdStepHealthInst.Text = "3. basamak sağlık kurumu";
        this.labelUE_SK_ThirdStepHealthInst.Name = "labelUE_SK_ThirdStepHealthInst";
        this.labelUE_SK_ThirdStepHealthInst.TabIndex = 13;

        this.UE_SK_ThirdStepHealthInst = new TTVisual.TTEnumComboBox();
        this.UE_SK_ThirdStepHealthInst.DataTypeName = "YesNoEnum";
        this.UE_SK_ThirdStepHealthInst.Name = "UE_SK_ThirdStepHealthInst";
        this.UE_SK_ThirdStepHealthInst.TabIndex = 12;

        this.labelUE_SK_sEMG = new TTVisual.TTLabel();
        this.labelUE_SK_sEMG.Text = "sEMG Belgelendirilmiş mi?";
        this.labelUE_SK_sEMG.Name = "labelUE_SK_sEMG";
        this.labelUE_SK_sEMG.TabIndex = 11;

        this.UE_SK_sEMG = new TTVisual.TTEnumComboBox();
        this.UE_SK_sEMG.DataTypeName = "YesNoEnum";
        this.UE_SK_sEMG.Name = "UE_SK_sEMG";
        this.UE_SK_sEMG.TabIndex = 10;

        this.labelUE_SK_PsychiatricExpApprove = new TTVisual.TTLabel();
        this.labelUE_SK_PsychiatricExpApprove.Text = "Psikiyatri Uzman Onayı";
        this.labelUE_SK_PsychiatricExpApprove.Name = "labelUE_SK_PsychiatricExpApprove";
        this.labelUE_SK_PsychiatricExpApprove.TabIndex = 9;

        this.UE_SK_PsychiatricExpApprove = new TTVisual.TTEnumComboBox();
        this.UE_SK_PsychiatricExpApprove.DataTypeName = "YesNoEnum";
        this.UE_SK_PsychiatricExpApprove.Name = "UE_SK_PsychiatricExpApprove";
        this.UE_SK_PsychiatricExpApprove.TabIndex = 8;

        this.labelUE_SK_OrthopedicExpApprove = new TTVisual.TTLabel();
        this.labelUE_SK_OrthopedicExpApprove.Text = "Ortopedi Uzman Onayı";
        this.labelUE_SK_OrthopedicExpApprove.Name = "labelUE_SK_OrthopedicExpApprove";
        this.labelUE_SK_OrthopedicExpApprove.TabIndex = 7;

        this.UE_SK_OrthopedicExpApprove = new TTVisual.TTEnumComboBox();
        this.UE_SK_OrthopedicExpApprove.DataTypeName = "YesNoEnum";
        this.UE_SK_OrthopedicExpApprove.Name = "UE_SK_OrthopedicExpApprove";
        this.UE_SK_OrthopedicExpApprove.TabIndex = 6;

        this.labelUE_SK_HeadDoctorApprove = new TTVisual.TTLabel();
        this.labelUE_SK_HeadDoctorApprove.Text = "Başhekim Onayı";
        this.labelUE_SK_HeadDoctorApprove.Name = "labelUE_SK_HeadDoctorApprove";
        this.labelUE_SK_HeadDoctorApprove.TabIndex = 5;

        this.UE_SK_HeadDoctorApprove = new TTVisual.TTEnumComboBox();
        this.UE_SK_HeadDoctorApprove.DataTypeName = "YesNoEnum";
        this.UE_SK_HeadDoctorApprove.Name = "UE_SK_HeadDoctorApprove";
        this.UE_SK_HeadDoctorApprove.TabIndex = 4;

        this.labelUE_SK_FTRExpertApprove = new TTVisual.TTLabel();
        this.labelUE_SK_FTRExpertApprove.Text = "FTR Uzman Onayı";
        this.labelUE_SK_FTRExpertApprove.Name = "labelUE_SK_FTRExpertApprove";
        this.labelUE_SK_FTRExpertApprove.TabIndex = 3;

        this.UE_SK_FTRExpertApprove = new TTVisual.TTEnumComboBox();
        this.UE_SK_FTRExpertApprove.DataTypeName = "YesNoEnum";
        this.UE_SK_FTRExpertApprove.Name = "UE_SK_FTRExpertApprove";
        this.UE_SK_FTRExpertApprove.TabIndex = 2;

        this.labelUE_SK_MedicalReason = new TTVisual.TTLabel();
        this.labelUE_SK_MedicalReason.Text = "Tıbbi Gerekçe Yazılmış mı?";
        this.labelUE_SK_MedicalReason.Name = "labelUE_SK_MedicalReason";
        this.labelUE_SK_MedicalReason.TabIndex = 1;

        this.UE_SK_MedicalReason = new TTVisual.TTEnumComboBox();
        this.UE_SK_MedicalReason.DataTypeName = "YesNoEnum";
        this.UE_SK_MedicalReason.Name = "UE_SK_MedicalReason";
        this.UE_SK_MedicalReason.TabIndex = 0;

        this.tttabpage3 = new TTVisual.TTTabPage();
        this.tttabpage3.DisplayIndex = 2;
        this.tttabpage3.TabIndex = 2;
        this.tttabpage3.Text = "AKTİF TEKERLEKLİ SANDALYE İÇİN";
        this.tttabpage3.Name = "tttabpage3";

        this.ttgroupbox9 = new TTVisual.TTGroupBox();
        this.ttgroupbox9.Text = "REÇETE İÇERİĞİ";
        this.ttgroupbox9.Name = "ttgroupbox9";
        this.ttgroupbox9.TabIndex = 9;

        this.labelATS_RI_WetSignature = new TTVisual.TTLabel();
        this.labelATS_RI_WetSignature.Text = "Islak İmza Varmı?";
        this.labelATS_RI_WetSignature.Name = "labelATS_RI_WetSignature";
        this.labelATS_RI_WetSignature.TabIndex = 13;

        this.ATS_RI_WetSignature = new TTVisual.TTEnumComboBox();
        this.ATS_RI_WetSignature.DataTypeName = "";
        this.ATS_RI_WetSignature.Name = "ATS_RI_WetSignature";
        this.ATS_RI_WetSignature.TabIndex = 12;

        this.labelATS_RI_PatientNameSurname = new TTVisual.TTLabel();
        this.labelATS_RI_PatientNameSurname.Text = "Hasta Adı Soyadı";
        this.labelATS_RI_PatientNameSurname.Name = "labelATS_RI_PatientNameSurname";
        this.labelATS_RI_PatientNameSurname.TabIndex = 11;

        this.ATS_RI_PatientNameSurname = new TTVisual.TTEnumComboBox();
        this.ATS_RI_PatientNameSurname.DataTypeName = "";
        this.ATS_RI_PatientNameSurname.Name = "ATS_RI_PatientNameSurname";
        this.ATS_RI_PatientNameSurname.TabIndex = 10;

        this.labelATS_RI_MedulaOrProtocolNo = new TTVisual.TTLabel();
        this.labelATS_RI_MedulaOrProtocolNo.Text = "Medula veya Protokol Numarası Var mı?";
        this.labelATS_RI_MedulaOrProtocolNo.Name = "labelATS_RI_MedulaOrProtocolNo";
        this.labelATS_RI_MedulaOrProtocolNo.TabIndex = 9;

        this.ATS_RI_MedulaOrProtocolNo = new TTVisual.TTEnumComboBox();
        this.ATS_RI_MedulaOrProtocolNo.DataTypeName = "";
        this.ATS_RI_MedulaOrProtocolNo.Name = "ATS_RI_MedulaOrProtocolNo";
        this.ATS_RI_MedulaOrProtocolNo.TabIndex = 8;

        this.labelATS_RI_MedulaInsCode = new TTVisual.TTLabel();
        this.labelATS_RI_MedulaInsCode.Text = "Reçeteyi düzenleyen";
        this.labelATS_RI_MedulaInsCode.Name = "labelATS_RI_MedulaInsCode";
        this.labelATS_RI_MedulaInsCode.TabIndex = 7;

        this.ATS_RI_MedulaInsCode = new TTVisual.TTEnumComboBox();
        this.ATS_RI_MedulaInsCode.DataTypeName = "";
        this.ATS_RI_MedulaInsCode.Name = "ATS_RI_MedulaInsCode";
        this.ATS_RI_MedulaInsCode.TabIndex = 6;

        this.labelATS_RI_MachineName = new TTVisual.TTLabel();
        this.labelATS_RI_MachineName.Text = "Cihazın adı/taraf/adet bilgisi var mı?";
        this.labelATS_RI_MachineName.Name = "labelATS_RI_MachineName";
        this.labelATS_RI_MachineName.TabIndex = 5;

        this.ATS_RI_MachineName = new TTVisual.TTEnumComboBox();
        this.ATS_RI_MachineName.DataTypeName = "";
        this.ATS_RI_MachineName.Name = "ATS_RI_MachineName";
        this.ATS_RI_MachineName.TabIndex = 4;

        this.labelATS_RI_DiagnosAndICD10Code = new TTVisual.TTLabel();
        this.labelATS_RI_DiagnosAndICD10Code.Text = "Tanı ve ICD-10 Kodu Varmı";
        this.labelATS_RI_DiagnosAndICD10Code.Name = "labelATS_RI_DiagnosAndICD10Code";
        this.labelATS_RI_DiagnosAndICD10Code.TabIndex = 3;

        this.ATS_RI_DiagnosAndICD10Code = new TTVisual.TTEnumComboBox();
        this.ATS_RI_DiagnosAndICD10Code.DataTypeName = "";
        this.ATS_RI_DiagnosAndICD10Code.Name = "ATS_RI_DiagnosAndICD10Code";
        this.ATS_RI_DiagnosAndICD10Code.TabIndex = 2;

        this.labelATS_RI_Date = new TTVisual.TTLabel();
        this.labelATS_RI_Date.Text = "Tarih var mı?";
        this.labelATS_RI_Date.Name = "labelATS_RI_Date";
        this.labelATS_RI_Date.TabIndex = 1;

        this.ATS_RI_Date = new TTVisual.TTEnumComboBox();
        this.ATS_RI_Date.DataTypeName = "";
        this.ATS_RI_Date.Name = "ATS_RI_Date";
        this.ATS_RI_Date.TabIndex = 0;

        this.ttgroupbox8 = new TTVisual.TTGroupBox();
        this.ttgroupbox8.Text = "SAĞLIK KURULU";
        this.ttgroupbox8.Name = "ttgroupbox8";
        this.ttgroupbox8.TabIndex = 8;

        this.ttgroupbox10 = new TTVisual.TTGroupBox();
        this.ttgroupbox10.Text = "HASTA DEĞERLENDİRMESİ";
        this.ttgroupbox10.Name = "ttgroupbox10";
        this.ttgroupbox10.TabIndex = 10;

        this.ATS_HD_Therapeutic = new TTVisual.TTCheckBox();
        this.ATS_HD_Therapeutic.Value = false;
        this.ATS_HD_Therapeutic.Title = "Terapötik ambulasyon  ";
        this.ATS_HD_Therapeutic.Name = "ATS_HD_Therapeutic";
        this.ATS_HD_Therapeutic.TabIndex = 41;

        this.labelATS_HD_OrganFailure_Desc = new TTVisual.TTLabel();
        this.labelATS_HD_OrganFailure_Desc.Text = "Organ yetmezliği var mı?";
        this.labelATS_HD_OrganFailure_Desc.Name = "labelATS_HD_OrganFailure_Desc";
        this.labelATS_HD_OrganFailure_Desc.TabIndex = 40;

        this.ATS_HD_OrganFailure_Desc = new TTVisual.TTTextBox();
        this.ATS_HD_OrganFailure_Desc.Name = "ATS_HD_OrganFailure_Desc";
        this.ATS_HD_OrganFailure_Desc.TabIndex = 39;

        this.labelATS_HD_Pulmonary_Desc = new TTVisual.TTLabel();
        this.labelATS_HD_Pulmonary_Desc.Text = "Pulmoner hastalık var mı?";
        this.labelATS_HD_Pulmonary_Desc.Name = "labelATS_HD_Pulmonary_Desc";
        this.labelATS_HD_Pulmonary_Desc.TabIndex = 38;

        this.ATS_HD_Pulmonary_Desc = new TTVisual.TTTextBox();
        this.ATS_HD_Pulmonary_Desc.Name = "ATS_HD_Pulmonary_Desc";
        this.ATS_HD_Pulmonary_Desc.TabIndex = 37;

        this.labelATS_HD_Cardiovascular_Desc = new TTVisual.TTLabel();
        this.labelATS_HD_Cardiovascular_Desc.Text = "Kardiyovasküler hastalık var mı?";
        this.labelATS_HD_Cardiovascular_Desc.Name = "labelATS_HD_Cardiovascular_Desc";
        this.labelATS_HD_Cardiovascular_Desc.TabIndex = 36;

        this.ATS_HD_Cardiovascular_Desc = new TTVisual.TTTextBox();
        this.ATS_HD_Cardiovascular_Desc.Name = "ATS_HD_Cardiovascular_Desc";
        this.ATS_HD_Cardiovascular_Desc.TabIndex = 35;

        this.labelATS_HD_Contracture_Desc = new TTVisual.TTLabel();
        this.labelATS_HD_Contracture_Desc.Text = "Eklem kontraktürü var mı?";
        this.labelATS_HD_Contracture_Desc.Name = "labelATS_HD_Contracture_Desc";
        this.labelATS_HD_Contracture_Desc.TabIndex = 34;

        this.ATS_HD_Contracture_Desc = new TTVisual.TTTextBox();
        this.ATS_HD_Contracture_Desc.Name = "ATS_HD_Contracture_Desc";
        this.ATS_HD_Contracture_Desc.TabIndex = 33;

        this.labelATS_HD_Deformity_Desc = new TTVisual.TTLabel();
        this.labelATS_HD_Deformity_Desc.Text = "deformitesi ";
        this.labelATS_HD_Deformity_Desc.Name = "labelATS_HD_Deformity_Desc";
        this.labelATS_HD_Deformity_Desc.TabIndex = 32;

        this.ATS_HD_Deformity_Desc = new TTVisual.TTTextBox();
        this.ATS_HD_Deformity_Desc.Name = "ATS_HD_Deformity_Desc";
        this.ATS_HD_Deformity_Desc.TabIndex = 31;

        this.labelATS_HD_UseHimself_Desc = new TTVisual.TTLabel();
        this.labelATS_HD_UseHimself_Desc.Text = "Kendisi Kullanabiliyor mu?  ";
        this.labelATS_HD_UseHimself_Desc.Name = "labelATS_HD_UseHimself_Desc";
        this.labelATS_HD_UseHimself_Desc.TabIndex = 30;

        this.ATS_HD_UseHimself_Desc = new TTVisual.TTTextBox();
        this.ATS_HD_UseHimself_Desc.Name = "ATS_HD_UseHimself_Desc";
        this.ATS_HD_UseHimself_Desc.TabIndex = 29;

        this.labelATS_HD_ChairModel_Desc = new TTVisual.TTLabel();
        this.labelATS_HD_ChairModel_Desc.Text = "marka/model tercih dilekçesi var mı?";
        this.labelATS_HD_ChairModel_Desc.Name = "labelATS_HD_ChairModel_Desc";
        this.labelATS_HD_ChairModel_Desc.TabIndex = 28;

        this.ATS_HD_ChairModel_Desc = new TTVisual.TTTextBox();
        this.ATS_HD_ChairModel_Desc.Name = "ATS_HD_ChairModel_Desc";
        this.ATS_HD_ChairModel_Desc.TabIndex = 27;

        this.labelATS_HD_ConstantCondition_Desc = new TTVisual.TTLabel();
        this.labelATS_HD_ConstantCondition_Desc.Text = "Hastalığı sürekli mi?";
        this.labelATS_HD_ConstantCondition_Desc.Name = "labelATS_HD_ConstantCondition_Desc";
        this.labelATS_HD_ConstantCondition_Desc.TabIndex = 26;

        this.ATS_HD_ConstantCondition_Desc = new TTVisual.TTTextBox();
        this.ATS_HD_ConstantCondition_Desc.Name = "ATS_HD_ConstantCondition_Desc";
        this.ATS_HD_ConstantCondition_Desc.TabIndex = 25;

        this.labelATS_HD_OrganFailure = new TTVisual.TTLabel();
        this.labelATS_HD_OrganFailure.Text = "Organ yetmezliği var mı?";
        this.labelATS_HD_OrganFailure.Name = "labelATS_HD_OrganFailure";
        this.labelATS_HD_OrganFailure.TabIndex = 24;

        this.ATS_HD_OrganFailure = new TTVisual.TTEnumComboBox();
        this.ATS_HD_OrganFailure.DataTypeName = "";
        this.ATS_HD_OrganFailure.Name = "ATS_HD_OrganFailure";
        this.ATS_HD_OrganFailure.TabIndex = 23;

        this.labelATS_HD_Pulmonary = new TTVisual.TTLabel();
        this.labelATS_HD_Pulmonary.Text = "Pulmoner hastalık var mı?";
        this.labelATS_HD_Pulmonary.Name = "labelATS_HD_Pulmonary";
        this.labelATS_HD_Pulmonary.TabIndex = 22;

        this.ATS_HD_Pulmonary = new TTVisual.TTEnumComboBox();
        this.ATS_HD_Pulmonary.DataTypeName = "";
        this.ATS_HD_Pulmonary.Name = "ATS_HD_Pulmonary";
        this.ATS_HD_Pulmonary.TabIndex = 21;

        this.labelATS_HD_Cardiovascular = new TTVisual.TTLabel();
        this.labelATS_HD_Cardiovascular.Text = "Kardiyovasküler hastalık var mı?";
        this.labelATS_HD_Cardiovascular.Name = "labelATS_HD_Cardiovascular";
        this.labelATS_HD_Cardiovascular.TabIndex = 20;

        this.ATS_HD_Cardiovascular = new TTVisual.TTEnumComboBox();
        this.ATS_HD_Cardiovascular.DataTypeName = "";
        this.ATS_HD_Cardiovascular.Name = "ATS_HD_Cardiovascular";
        this.ATS_HD_Cardiovascular.TabIndex = 19;

        this.labelATS_HD_Contracture = new TTVisual.TTLabel();
        this.labelATS_HD_Contracture.Text = "Eklem kontraktürü var mı?";
        this.labelATS_HD_Contracture.Name = "labelATS_HD_Contracture";
        this.labelATS_HD_Contracture.TabIndex = 18;

        this.ATS_HD_Contracture = new TTVisual.TTEnumComboBox();
        this.ATS_HD_Contracture.DataTypeName = "";
        this.ATS_HD_Contracture.Name = "ATS_HD_Contracture";
        this.ATS_HD_Contracture.TabIndex = 17;

        this.labelATS_HD_Deformity = new TTVisual.TTLabel();
        this.labelATS_HD_Deformity.Text = "deformitesi var mı";
        this.labelATS_HD_Deformity.Name = "labelATS_HD_Deformity";
        this.labelATS_HD_Deformity.TabIndex = 16;

        this.ATS_HD_Deformity = new TTVisual.TTEnumComboBox();
        this.ATS_HD_Deformity.DataTypeName = "";
        this.ATS_HD_Deformity.Name = "ATS_HD_Deformity";
        this.ATS_HD_Deformity.TabIndex = 15;

        this.labelATS_HD_UseHimself = new TTVisual.TTLabel();
        this.labelATS_HD_UseHimself.Text = "Tekerlekli Sandalyeyi Kendisi Kullanabiliyor mu?  ";
        this.labelATS_HD_UseHimself.Name = "labelATS_HD_UseHimself";
        this.labelATS_HD_UseHimself.TabIndex = 14;

        this.ATS_HD_UseHimself = new TTVisual.TTEnumComboBox();
        this.ATS_HD_UseHimself.DataTypeName = "";
        this.ATS_HD_UseHimself.Name = "ATS_HD_UseHimself";
        this.ATS_HD_UseHimself.TabIndex = 13;

        this.labelATS_HD_ChairModel = new TTVisual.TTLabel();
        this.labelATS_HD_ChairModel.Text = "Hastanın tekerlekli sandalye marka/model ";
        this.labelATS_HD_ChairModel.Name = "labelATS_HD_ChairModel";
        this.labelATS_HD_ChairModel.TabIndex = 12;

        this.ATS_HD_ChairModel = new TTVisual.TTEnumComboBox();
        this.ATS_HD_ChairModel.DataTypeName = "";
        this.ATS_HD_ChairModel.Name = "ATS_HD_ChairModel";
        this.ATS_HD_ChairModel.TabIndex = 11;

        this.labelATS_HD_ConstantCondition = new TTVisual.TTLabel();
        this.labelATS_HD_ConstantCondition.Text = "Hastalığı sürekli mi?";
        this.labelATS_HD_ConstantCondition.Name = "labelATS_HD_ConstantCondition";
        this.labelATS_HD_ConstantCondition.TabIndex = 10;

        this.ATS_HD_ConstantCondition = new TTVisual.TTEnumComboBox();
        this.ATS_HD_ConstantCondition.DataTypeName = "";
        this.ATS_HD_ConstantCondition.Name = "ATS_HD_ConstantCondition";
        this.ATS_HD_ConstantCondition.TabIndex = 9;

        this.labelATS_HD_UseLowerExtremity_Desc = new TTVisual.TTLabel();
        this.labelATS_HD_UseLowerExtremity_Desc.Text = "Güdük bölgesinde ";
        this.labelATS_HD_UseLowerExtremity_Desc.Name = "labelATS_HD_UseLowerExtremity_Desc";
        this.labelATS_HD_UseLowerExtremity_Desc.TabIndex = 8;

        this.ATS_HD_UseLowerExtremity_Desc = new TTVisual.TTTextBox();
        this.ATS_HD_UseLowerExtremity_Desc.Name = "ATS_HD_UseLowerExtremity_Desc";
        this.ATS_HD_UseLowerExtremity_Desc.TabIndex = 7;

        this.labelATS_HD_USELOWEREXTREMITIES = new TTVisual.TTLabel();
        this.labelATS_HD_USELOWEREXTREMITIES.Text = "alt ekstremitelerini kullanabiliyor mu";
        this.labelATS_HD_USELOWEREXTREMITIES.Name = "labelATS_HD_USELOWEREXTREMITIES";
        this.labelATS_HD_USELOWEREXTREMITIES.TabIndex = 6;

        this.ATS_HD_USELOWEREXTREMITIES = new TTVisual.TTEnumComboBox();
        this.ATS_HD_USELOWEREXTREMITIES.DataTypeName = "";
        this.ATS_HD_USELOWEREXTREMITIES.Name = "ATS_HD_USELOWEREXTREMITIES";
        this.ATS_HD_USELOWEREXTREMITIES.TabIndex = 5;

        this.ATS_HD_NOAMBULATION = new TTVisual.TTCheckBox();
        this.ATS_HD_NOAMBULATION.Value = false;
        this.ATS_HD_NOAMBULATION.Title = "Ambulasyonu yok ";
        this.ATS_HD_NOAMBULATION.Name = "ATS_HD_NOAMBULATION";
        this.ATS_HD_NOAMBULATION.TabIndex = 4;

        this.ATS_HD_INTRACOMMUNITY = new TTVisual.TTCheckBox();
        this.ATS_HD_INTRACOMMUNITY.Value = false;
        this.ATS_HD_INTRACOMMUNITY.Title = "Toplum içi ambulasyon ";
        this.ATS_HD_INTRACOMMUNITY.Name = "ATS_HD_INTRACOMMUNITY";
        this.ATS_HD_INTRACOMMUNITY.TabIndex = 3;

        this.labelATS_HD_ChairDistance = new TTVisual.TTLabel();
        this.labelATS_HD_ChairDistance.Text = "ne kadar mesafe sürebiliyor?";
        this.labelATS_HD_ChairDistance.Name = "labelATS_HD_ChairDistance";
        this.labelATS_HD_ChairDistance.TabIndex = 1;

        this.ATS_HD_ChairDistance = new TTVisual.TTTextBox();
        this.ATS_HD_ChairDistance.Name = "ATS_HD_ChairDistance";
        this.ATS_HD_ChairDistance.TabIndex = 0;

        this.labelATS_SK_HeadDoctorApprove = new TTVisual.TTLabel();
        this.labelATS_SK_HeadDoctorApprove.Text = "Başhekim Onayı";
        this.labelATS_SK_HeadDoctorApprove.Name = "labelATS_SK_HeadDoctorApprove";
        this.labelATS_SK_HeadDoctorApprove.TabIndex = 11;

        this.ATS_SK_HeadDoctorApprove = new TTVisual.TTEnumComboBox();
        this.ATS_SK_HeadDoctorApprove.DataTypeName = "";
        this.ATS_SK_HeadDoctorApprove.Name = "ATS_SK_HeadDoctorApprove";
        this.ATS_SK_HeadDoctorApprove.TabIndex = 10;

        this.labelATS_SK_OrthopedicExpApprove = new TTVisual.TTLabel();
        this.labelATS_SK_OrthopedicExpApprove.Text = "Ortopedi Uzman Onayı";
        this.labelATS_SK_OrthopedicExpApprove.Name = "labelATS_SK_OrthopedicExpApprove";
        this.labelATS_SK_OrthopedicExpApprove.TabIndex = 9;

        this.ATS_SK_OrthopedicExpApprove = new TTVisual.TTEnumComboBox();
        this.ATS_SK_OrthopedicExpApprove.DataTypeName = "";
        this.ATS_SK_OrthopedicExpApprove.Name = "ATS_SK_OrthopedicExpApprove";
        this.ATS_SK_OrthopedicExpApprove.TabIndex = 8;

        this.labelATS_SK_FTRExpertApprove = new TTVisual.TTLabel();
        this.labelATS_SK_FTRExpertApprove.Text = "FTR Uzman Onayı";
        this.labelATS_SK_FTRExpertApprove.Name = "labelATS_SK_FTRExpertApprove";
        this.labelATS_SK_FTRExpertApprove.TabIndex = 7;

        this.ATS_SK_FTRExpertApprove = new TTVisual.TTEnumComboBox();
        this.ATS_SK_FTRExpertApprove.DataTypeName = "";
        this.ATS_SK_FTRExpertApprove.Name = "ATS_SK_FTRExpertApprove";
        this.ATS_SK_FTRExpertApprove.TabIndex = 6;

        this.labelATS_SK_ThirdStepHealthInst = new TTVisual.TTLabel();
        this.labelATS_SK_ThirdStepHealthInst.Text = "3. basamak sağlık kurumu";
        this.labelATS_SK_ThirdStepHealthInst.Name = "labelATS_SK_ThirdStepHealthInst";
        this.labelATS_SK_ThirdStepHealthInst.TabIndex = 5;

        this.ATS_SK_ThirdStepHealthInst = new TTVisual.TTEnumComboBox();
        this.ATS_SK_ThirdStepHealthInst.DataTypeName = "";
        this.ATS_SK_ThirdStepHealthInst.Name = "ATS_SK_ThirdStepHealthInst";
        this.ATS_SK_ThirdStepHealthInst.TabIndex = 4;

        this.labelATS_SK_MedicalReason = new TTVisual.TTLabel();
        this.labelATS_SK_MedicalReason.Text = "Aktif TS yazılmasındaki";
        this.labelATS_SK_MedicalReason.Name = "labelATS_SK_MedicalReason";
        this.labelATS_SK_MedicalReason.TabIndex = 3;

        this.ATS_SK_MedicalReason = new TTVisual.TTTextBox();
        this.ATS_SK_MedicalReason.Name = "ATS_SK_MedicalReason";
        this.ATS_SK_MedicalReason.TabIndex = 2;

        this.labelATS_SK_ChairType = new TTVisual.TTLabel();
        this.labelATS_SK_ChairType.Text = "Raporda yazılan tekerlekli sandalye tipi:";
        this.labelATS_SK_ChairType.Name = "labelATS_SK_ChairType";
        this.labelATS_SK_ChairType.TabIndex = 1;

        this.ATS_SK_ChairType = new TTVisual.TTTextBox();
        this.ATS_SK_ChairType.Name = "ATS_SK_ChairType";
        this.ATS_SK_ChairType.TabIndex = 0;

        this.labelATS_ChairType = new TTVisual.TTLabel();
        this.labelATS_ChairType.Text = "Protez tipi";
        this.labelATS_ChairType.Name = "labelATS_ChairType";
        this.labelATS_ChairType.TabIndex = 7;

        this.ATS_ChairType = new TTVisual.TTTextBox();
        this.ATS_ChairType.Name = "ATS_ChairType";
        this.ATS_ChairType.TabIndex = 6;

        this.labelATS_DeliveryDate = new TTVisual.TTLabel();
        this.labelATS_DeliveryDate.Text = "Teslim alma tarihi";
        this.labelATS_DeliveryDate.Name = "labelATS_DeliveryDate";
        this.labelATS_DeliveryDate.TabIndex = 5;

        this.ATS_DeliveryDate = new TTVisual.TTTextBox();
        this.ATS_DeliveryDate.Name = "ATS_DeliveryDate";
        this.ATS_DeliveryDate.TabIndex = 4;

        this.labelATS_ChairNumber = new TTVisual.TTLabel();
        this.labelATS_ChairNumber.Text = "Kaçıncı Sandalyesi olduğu ";
        this.labelATS_ChairNumber.Name = "labelATS_ChairNumber";
        this.labelATS_ChairNumber.TabIndex = 3;

        this.ATS_ChairNumber = new TTVisual.TTTextBox();
        this.ATS_ChairNumber.Name = "ATS_ChairNumber";
        this.ATS_ChairNumber.TabIndex = 2;

        this.labelATS_CauseOfInjury = new TTVisual.TTLabel();
        this.labelATS_CauseOfInjury.Text = "Yaralanma nedeni ve tarihi";
        this.labelATS_CauseOfInjury.Name = "labelATS_CauseOfInjury";
        this.labelATS_CauseOfInjury.TabIndex = 1;

        this.ATS_CauseOfInjury = new TTVisual.TTTextBox();
        this.ATS_CauseOfInjury.Name = "ATS_CauseOfInjury";
        this.ATS_CauseOfInjury.TabIndex = 0;

        this.tttabcontrol1.Controls = [this.tttabpage1, this.tttabpage2, this.tttabpage3];
        this.tttabpage1.Controls = [this.labelLE_ProstheticType, this.LE_ProstheticType, this.labelLE_ConstructionDate, this.LE_ConstructionDate, this.labelLE_ProsthesisNumber, this.LE_ProsthesisNumber, this.labelLE_AmputationDate, this.LE_AmputationDate, this.labelLE_CauseOfInjury, this.LE_CauseOfInjury, this.ttgroupbox4, this.ttgroupbox3, this.ttgroupbox2, this.ttgroupbox1];
        this.ttgroupbox4.Controls = [this.labelLE_TEM_Waterproof_Desc, this.LE_TEM_Waterproof_Desc, this.labelLE_TEM_WalkingSpeed_Desc, this.LE_TEM_WalkingSpeed_Desc, this.labelLE_TEM_WalkBackwards_Desc, this.LE_TEM_WalkBackwards_Desc, this.labelLE_TEM_StrideLength_Desc, this.LE_TEM_StrideLength_Desc, this.labelLE_TEM_StepClimbing_Desc, this.LE_TEM_StepClimbing_Desc, this.labelLE_TEM_Oscillationand_Desc, this.LE_TEM_Oscillationand_Desc, this.labelLE_TEM_Waterproof, this.LE_TEM_Waterproof, this.labelLE_TEM_WalkBackwards, this.LE_TEM_WalkBackwards, this.labelLE_TEM_StepClimbing, this.LE_TEM_StepClimbing, this.labelLE_TEM_StrideLength, this.LE_TEM_StrideLength, this.labelLE_TEM_WalkingSpeed, this.LE_TEM_WalkingSpeed, this.labelLE_TEM_OscillationandPosture, this.LE_TEM_OscillationandPosture, this.labelLE_TEM_WhichLevel, this.LE_TEM_WhichLevel];
        this.ttgroupbox3.Controls = [this.labelLE_HD_WeightTolerance_desc, this.LE_HD_WeightTolerance_desc, this.labelLE_HD_SystemicDisease_Desc, this.LE_HD_SystemicDisease_Desc, this.labelLE_HD_StumpZone_Desc, this.LE_HD_StumpZone_Desc, this.labelLE_HD_SingleSideAmputate_Desc, this.LE_HD_SingleSideAmputate_Desc, this.labelLE_HD_Pulmonary_Desc, this.LE_HD_Pulmonary_Desc, this.labelLE_HD_PreferencePetition_Desc, this.LE_HD_PreferencePetition_Desc, this.labelLE_HD_OrganFailure_Desc, this.LE_HD_OrganFailure_Desc, this.labelLE_HD_Neurological_Desc, this.LE_HD_Neurological_Desc, this.labelLE_HD_Musculoskeletal_Desc, this.LE_HD_Musculoskeletal_Desc, this.labelLE_HD_Contracture_Desc, this.LE_HD_Contracture_Desc, this.labelLE_HD_Cardiovascular_Desc, this.LE_HD_Cardiovascular_Desc, this.labelLE_HD_Ambulation_Desc, this.LE_HD_Ambulation_Desc, this.labelLE_HD_SystemicDisease, this.LE_HD_SystemicDisease, this.labelLE_HD_OrganFailure, this.LE_HD_OrganFailure, this.labelLE_HD_Pulmonary, this.LE_HD_Pulmonary, this.labelLE_HD_Cardiovascular, this.LE_HD_Cardiovascular, this.labelLE_HD_Neurological, this.LE_HD_Neurological, this.labelLE_HD_Musculoskeletal, this.LE_HD_Musculoskeletal, this.labelLE_HD_Ambulation, this.LE_HD_Ambulation, this.labelLE_HD_SingleSideAmputate, this.LE_HD_SingleSideAmputate, this.labelLE_HD_Contracture, this.LE_HD_Contracture, this.labelLE_HD_WeightTolerance, this.LE_HD_WeightTolerance, this.labelLE_HD_StumpZone, this.LE_HD_StumpZone, this.labelLE_HD_PreferencePetition, this.LE_HD_PreferencePetition, this.labelLE_HD_AktivityLevel, this.LE_HD_AktivityLevel];
        this.ttgroupbox2.Controls = [this.labelLE_WetSignature, this.LE_WetSignature, this.labelLE_PatientNameSurname, this.LE_PatientNameSurname, this.labelLE_MedulaOrProtocolNo, this.LE_MedulaOrProtocolNo, this.labelLE_MedulaInsCode, this.LE_MedulaInsCode, this.labelLE_MachineNameIsCorrect, this.LE_MachineNameIsCorrect, this.labelLE_MachineName, this.LE_MachineName, this.labelLE_DiagnosAndICD10Code, this.LE_DiagnosAndICD10Code];
        this.ttgroupbox1.Controls = [this.labelLE_SK_ProstheticType, this.LE_SK_ProstheticType, this.labelLE_ThirdStepHealthInst, this.LE_ThirdStepHealthInst, this.labelLE_PsychiatricExpertApprove, this.LE_PsychiatricExpertApprove, this.labelLE_OrthopedicExpertApprove, this.LE_OrthopedicExpertApprove, this.labelLE_MedicalReason, this.LE_MedicalReason, this.labelLE_HeadDoctorApprove, this.LE_HeadDoctorApprove, this.labelLE_FTRExpertApprove, this.LE_FTRExpertApprove];
        this.tttabpage2.Controls = [this.labelUE_ProstheticType, this.UE_ProstheticType, this.labelUE_ProsthesisNumber, this.UE_ProsthesisNumber, this.labelUE_ConstructionDate, this.UE_ConstructionDate, this.labelUE_CauseOfInjury, this.UE_CauseOfInjury, this.labelUE_AmputationDate, this.UE_AmputationDate, this.ttgroupbox7, this.ttgroupbox6, this.ttgroupbox5];
        this.ttgroupbox7.Controls = [this.labelUE_HD_SufficientStump_Desc, this.UE_HD_SufficientStump_Desc, this.labelUE_HD_PreferencePetition, this.UE_HD_PreferencePetition_Desc, this.labelUE_HD_Myoelectric, this.UE_HD_Myoelectric, this.labelUE_HD_SystemicDisease_Desc, this.UE_HD_SystemicDisease_Desc, this.labelUE_HD_SystemicDisease, this.UE_HD_SystemicDisease, this.labelUE_HD_OrganFailure_Desc, this.UE_HD_OrganFailure_Desc, this.labelUE_HD_OrganFailure, this.UE_HD_OrganFailure, this.labelUE_HD_Pulmonary_Desc, this.UE_HD_Pulmonary_Desc, this.labelUE_HD_Pulmonary, this.UE_HD_Pulmonary, this.labelUE_HD_Cardiovascular_Desc, this.UE_HD_Cardiovascular_Desc, this.labelUE_HD_Cardiovascular, this.UE_HD_Cardiovascular, this.labelUE_HD_Neurological_Desc, this.UE_HD_Neurological_Desc, this.labelUE_HD_Neurological, this.UE_HD_Neurological, this.labelUE_HD_Musculoskeletal_Desc, this.UE_HD_Musculoskeletal_Desc, this.labelUE_HD_Musculoskeletal, this.UE_HD_Musculoskeletal, this.labelUE_HD_Contracture_Desc, this.UE_HD_Contracture_Desc, this.labelUE_HD_Contracture, this.UE_HD_Contracture, this.labelUE_HD_StumpZone_Desc, this.UE_HD_StumpZone_Desc, this.labelUE_HD_StumpZone, this.UE_HD_StumpZone, this.labelUE_HD_FunctionalMovement_Desc, this.UE_HD_FunctionalMovement_Desc, this.labelUE_HD_FunctionalMovements, this.UE_HD_FunctionalMovements, this.labelUE_HD_SingleSideAmputate_Desc, this.UE_HD_SingleSideAmputate_Desc, this.labelUE_HD_SingleSideAmputate, this.UE_HD_SingleSideAmputate, this.labelUE_HD_SufficientStumpLength, this.UE_HD_SufficientStumpLength, this.ttlabel1, this.UE_HD_PreferencePetition, this.labelUE_HD_StumpLength, this.UE_HD_StumpLength, this.labelUE_HD_AmputationLevel, this.UE_HD_AmputationLevel];
        this.ttgroupbox6.Controls = [this.labelUE_RI_WetSignature, this.UE_RI_WetSignature, this.labelUE_RI_MachineNameIsCorrect, this.UE_RI_MachineNameIsCorrect, this.labelUE_RI_DiagnosAndICD10Code, this.UE_RI_DiagnosAndICD10Code, this.labelUE_RI_MachineName, this.UE_RI_MachineName, this.labelUE_RI_MedulaOrProtocolNo, this.UE_RI_MedulaOrProtocolNo, this.labelUE_RI_Date, this.UE_RI_Date, this.labelUE_RI_MedulaInsCode, this.UE_RI_MedulaInsCode, this.labelUE_RI_PatientNameSurname, this.UE_RI_PatientNameSurname];
        this.ttgroupbox5.Controls = [this.labelUE_SK_ProstheticType, this.UE_SK_ProstheticType, this.labelUE_SK_ThirdStepHealthInst, this.UE_SK_ThirdStepHealthInst, this.labelUE_SK_sEMG, this.UE_SK_sEMG, this.labelUE_SK_PsychiatricExpApprove, this.UE_SK_PsychiatricExpApprove, this.labelUE_SK_OrthopedicExpApprove, this.UE_SK_OrthopedicExpApprove, this.labelUE_SK_HeadDoctorApprove, this.UE_SK_HeadDoctorApprove, this.labelUE_SK_FTRExpertApprove, this.UE_SK_FTRExpertApprove, this.labelUE_SK_MedicalReason, this.UE_SK_MedicalReason];
        this.tttabpage3.Controls = [this.ttgroupbox9, this.ttgroupbox8, this.labelATS_ChairType, this.ATS_ChairType, this.labelATS_DeliveryDate, this.ATS_DeliveryDate, this.labelATS_ChairNumber, this.ATS_ChairNumber, this.labelATS_CauseOfInjury, this.ATS_CauseOfInjury];
        this.ttgroupbox9.Controls = [this.labelATS_RI_WetSignature, this.ATS_RI_WetSignature, this.labelATS_RI_PatientNameSurname, this.ATS_RI_PatientNameSurname, this.labelATS_RI_MedulaOrProtocolNo, this.ATS_RI_MedulaOrProtocolNo, this.labelATS_RI_MedulaInsCode, this.ATS_RI_MedulaInsCode, this.labelATS_RI_MachineName, this.ATS_RI_MachineName, this.labelATS_RI_DiagnosAndICD10Code, this.ATS_RI_DiagnosAndICD10Code, this.labelATS_RI_Date, this.ATS_RI_Date];
        this.ttgroupbox8.Controls = [this.ttgroupbox10, this.labelATS_SK_HeadDoctorApprove, this.ATS_SK_HeadDoctorApprove, this.labelATS_SK_OrthopedicExpApprove, this.ATS_SK_OrthopedicExpApprove, this.labelATS_SK_FTRExpertApprove, this.ATS_SK_FTRExpertApprove, this.labelATS_SK_ThirdStepHealthInst, this.ATS_SK_ThirdStepHealthInst, this.labelATS_SK_MedicalReason, this.ATS_SK_MedicalReason, this.labelATS_SK_ChairType, this.ATS_SK_ChairType];
        this.ttgroupbox10.Controls = [this.ATS_HD_Therapeutic, this.labelATS_HD_OrganFailure_Desc, this.ATS_HD_OrganFailure_Desc, this.labelATS_HD_Pulmonary_Desc, this.ATS_HD_Pulmonary_Desc, this.labelATS_HD_Cardiovascular_Desc, this.ATS_HD_Cardiovascular_Desc, this.labelATS_HD_Contracture_Desc, this.ATS_HD_Contracture_Desc, this.labelATS_HD_Deformity_Desc, this.ATS_HD_Deformity_Desc, this.labelATS_HD_UseHimself_Desc, this.ATS_HD_UseHimself_Desc, this.labelATS_HD_ChairModel_Desc, this.ATS_HD_ChairModel_Desc, this.labelATS_HD_ConstantCondition_Desc, this.ATS_HD_ConstantCondition_Desc, this.labelATS_HD_OrganFailure, this.ATS_HD_OrganFailure, this.labelATS_HD_Pulmonary, this.ATS_HD_Pulmonary, this.labelATS_HD_Cardiovascular, this.ATS_HD_Cardiovascular, this.labelATS_HD_Contracture, this.ATS_HD_Contracture, this.labelATS_HD_Deformity, this.ATS_HD_Deformity, this.labelATS_HD_UseHimself, this.ATS_HD_UseHimself, this.labelATS_HD_ChairModel, this.ATS_HD_ChairModel, this.labelATS_HD_ConstantCondition, this.ATS_HD_ConstantCondition, this.labelATS_HD_UseLowerExtremity_Desc, this.ATS_HD_UseLowerExtremity_Desc, this.labelATS_HD_USELOWEREXTREMITIES, this.ATS_HD_USELOWEREXTREMITIES, this.ATS_HD_NOAMBULATION, this.ATS_HD_INTRACOMMUNITY, this.labelATS_HD_ChairDistance, this.ATS_HD_ChairDistance];

        this.Controls = [this.tttabcontrol1, this.tttabpage1, this.labelLE_ProstheticType, this.LE_ProstheticType, this.labelLE_ConstructionDate, this.LE_ConstructionDate, this.labelLE_ProsthesisNumber, this.LE_ProsthesisNumber, this.labelLE_AmputationDate, this.LE_AmputationDate, this.labelLE_CauseOfInjury, this.LE_CauseOfInjury, this.ttgroupbox4, this.labelLE_TEM_Waterproof_Desc, this.LE_TEM_Waterproof_Desc, this.labelLE_TEM_WalkingSpeed_Desc, this.LE_TEM_WalkingSpeed_Desc, this.labelLE_TEM_WalkBackwards_Desc, this.LE_TEM_WalkBackwards_Desc, this.labelLE_TEM_StrideLength_Desc, this.LE_TEM_StrideLength_Desc, this.labelLE_TEM_StepClimbing_Desc, this.LE_TEM_StepClimbing_Desc, this.labelLE_TEM_Oscillationand_Desc, this.LE_TEM_Oscillationand_Desc, this.labelLE_TEM_Waterproof, this.LE_TEM_Waterproof, this.labelLE_TEM_WalkBackwards, this.LE_TEM_WalkBackwards, this.labelLE_TEM_StepClimbing, this.LE_TEM_StepClimbing, this.labelLE_TEM_StrideLength, this.LE_TEM_StrideLength, this.labelLE_TEM_WalkingSpeed, this.LE_TEM_WalkingSpeed, this.labelLE_TEM_OscillationandPosture, this.LE_TEM_OscillationandPosture, this.labelLE_TEM_WhichLevel, this.LE_TEM_WhichLevel, this.ttgroupbox3, this.labelLE_HD_WeightTolerance_desc, this.LE_HD_WeightTolerance_desc, this.labelLE_HD_SystemicDisease_Desc, this.LE_HD_SystemicDisease_Desc, this.labelLE_HD_StumpZone_Desc, this.LE_HD_StumpZone_Desc, this.labelLE_HD_SingleSideAmputate_Desc, this.LE_HD_SingleSideAmputate_Desc, this.labelLE_HD_Pulmonary_Desc, this.LE_HD_Pulmonary_Desc, this.labelLE_HD_PreferencePetition_Desc, this.LE_HD_PreferencePetition_Desc, this.labelLE_HD_OrganFailure_Desc, this.LE_HD_OrganFailure_Desc, this.labelLE_HD_Neurological_Desc, this.LE_HD_Neurological_Desc,
            this.labelLE_HD_Musculoskeletal_Desc, this.LE_HD_Musculoskeletal_Desc, this.labelLE_HD_Contracture_Desc, this.LE_HD_Contracture_Desc, this.labelLE_HD_Cardiovascular_Desc, this.LE_HD_Cardiovascular_Desc, this.labelLE_HD_Ambulation_Desc, this.LE_HD_Ambulation_Desc, this.labelLE_HD_SystemicDisease, this.LE_HD_SystemicDisease, this.labelLE_HD_OrganFailure, this.LE_HD_OrganFailure, this.labelLE_HD_Pulmonary, this.LE_HD_Pulmonary, this.labelLE_HD_Cardiovascular, this.LE_HD_Cardiovascular, this.labelLE_HD_Neurological, this.LE_HD_Neurological, this.labelLE_HD_Musculoskeletal, this.LE_HD_Musculoskeletal, this.labelLE_HD_Ambulation, this.LE_HD_Ambulation, this.labelLE_HD_SingleSideAmputate, this.LE_HD_SingleSideAmputate, this.labelLE_HD_Contracture, this.LE_HD_Contracture, this.labelLE_HD_WeightTolerance, this.LE_HD_WeightTolerance, this.labelLE_HD_StumpZone, this.LE_HD_StumpZone, this.labelLE_HD_PreferencePetition, this.LE_HD_PreferencePetition, this.labelLE_HD_AktivityLevel, this.LE_HD_AktivityLevel, this.ttgroupbox2, this.labelLE_WetSignature, this.LE_WetSignature, this.labelLE_PatientNameSurname, this.LE_PatientNameSurname, this.labelLE_MedulaOrProtocolNo, this.LE_MedulaOrProtocolNo, this.labelLE_MedulaInsCode, this.LE_MedulaInsCode, this.labelLE_MachineNameIsCorrect, this.LE_MachineNameIsCorrect, this.labelLE_MachineName, this.LE_MachineName, this.labelLE_DiagnosAndICD10Code, this.LE_DiagnosAndICD10Code, this.ttgroupbox1, this.labelLE_SK_ProstheticType, this.LE_SK_ProstheticType, this.labelLE_ThirdStepHealthInst, this.LE_ThirdStepHealthInst, this.labelLE_PsychiatricExpertApprove, this.LE_PsychiatricExpertApprove, this.labelLE_OrthopedicExpertApprove, this.LE_OrthopedicExpertApprove,
            this.labelLE_MedicalReason, this.LE_MedicalReason, this.labelLE_HeadDoctorApprove, this.LE_HeadDoctorApprove, this.labelLE_FTRExpertApprove, this.LE_FTRExpertApprove, this.tttabpage2, this.labelUE_ProstheticType, this.UE_ProstheticType, this.labelUE_ProsthesisNumber, this.UE_ProsthesisNumber, this.labelUE_ConstructionDate, this.UE_ConstructionDate, this.labelUE_CauseOfInjury, this.UE_CauseOfInjury, this.labelUE_AmputationDate, this.UE_AmputationDate, this.ttgroupbox7, this.labelUE_HD_SufficientStump_Desc, this.UE_HD_SufficientStump_Desc, this.labelUE_HD_PreferencePetition, this.UE_HD_PreferencePetition_Desc, this.labelUE_HD_Myoelectric, this.UE_HD_Myoelectric, this.labelUE_HD_SystemicDisease_Desc, this.UE_HD_SystemicDisease_Desc, this.labelUE_HD_SystemicDisease, this.UE_HD_SystemicDisease, this.labelUE_HD_OrganFailure_Desc, this.UE_HD_OrganFailure_Desc, this.labelUE_HD_OrganFailure, this.UE_HD_OrganFailure, this.labelUE_HD_Pulmonary_Desc, this.UE_HD_Pulmonary_Desc, this.labelUE_HD_Pulmonary, this.UE_HD_Pulmonary, this.labelUE_HD_Cardiovascular_Desc, this.UE_HD_Cardiovascular_Desc, this.labelUE_HD_Cardiovascular, this.UE_HD_Cardiovascular, this.labelUE_HD_Neurological_Desc, this.UE_HD_Neurological_Desc, this.labelUE_HD_Neurological, this.UE_HD_Neurological, this.labelUE_HD_Musculoskeletal_Desc, this.UE_HD_Musculoskeletal_Desc, this.labelUE_HD_Musculoskeletal, this.UE_HD_Musculoskeletal, this.labelUE_HD_Contracture_Desc, this.UE_HD_Contracture_Desc, this.labelUE_HD_Contracture, this.UE_HD_Contracture, this.labelUE_HD_StumpZone_Desc, this.UE_HD_StumpZone_Desc, this.labelUE_HD_StumpZone, this.UE_HD_StumpZone, this.labelUE_HD_FunctionalMovement_Desc, this.UE_HD_FunctionalMovement_Desc,
            this.labelUE_HD_FunctionalMovements, this.UE_HD_FunctionalMovements, this.labelUE_HD_SingleSideAmputate_Desc, this.UE_HD_SingleSideAmputate_Desc, this.labelUE_HD_SingleSideAmputate, this.UE_HD_SingleSideAmputate, this.labelUE_HD_SufficientStumpLength, this.UE_HD_SufficientStumpLength, this.ttlabel1, this.UE_HD_PreferencePetition, this.labelUE_HD_StumpLength, this.UE_HD_StumpLength, this.labelUE_HD_AmputationLevel, this.UE_HD_AmputationLevel, this.ttgroupbox6, this.labelUE_RI_WetSignature, this.UE_RI_WetSignature, this.labelUE_RI_MachineNameIsCorrect, this.UE_RI_MachineNameIsCorrect, this.labelUE_RI_DiagnosAndICD10Code, this.UE_RI_DiagnosAndICD10Code, this.labelUE_RI_MachineName, this.UE_RI_MachineName, this.labelUE_RI_MedulaOrProtocolNo, this.UE_RI_MedulaOrProtocolNo, this.labelUE_RI_Date, this.UE_RI_Date, this.labelUE_RI_MedulaInsCode, this.UE_RI_MedulaInsCode, this.labelUE_RI_PatientNameSurname, this.UE_RI_PatientNameSurname, this.ttgroupbox5, this.labelUE_SK_ProstheticType, this.UE_SK_ProstheticType, this.labelUE_SK_ThirdStepHealthInst, this.UE_SK_ThirdStepHealthInst, this.labelUE_SK_sEMG, this.UE_SK_sEMG, this.labelUE_SK_PsychiatricExpApprove, this.UE_SK_PsychiatricExpApprove, this.labelUE_SK_OrthopedicExpApprove, this.UE_SK_OrthopedicExpApprove, this.labelUE_SK_HeadDoctorApprove, this.UE_SK_HeadDoctorApprove, this.labelUE_SK_FTRExpertApprove, this.UE_SK_FTRExpertApprove, this.labelUE_SK_MedicalReason, this.UE_SK_MedicalReason, this.tttabpage3, this.ttgroupbox9, this.labelATS_RI_WetSignature, this.ATS_RI_WetSignature, this.labelATS_RI_PatientNameSurname, this.ATS_RI_PatientNameSurname, this.labelATS_RI_MedulaOrProtocolNo, this.ATS_RI_MedulaOrProtocolNo, this.labelATS_RI_MedulaInsCode,
            this.ATS_RI_MedulaInsCode, this.labelATS_RI_MachineName, this.ATS_RI_MachineName, this.labelATS_RI_DiagnosAndICD10Code, this.ATS_RI_DiagnosAndICD10Code, this.labelATS_RI_Date, this.ATS_RI_Date, this.ttgroupbox8, this.ttgroupbox10, this.ATS_HD_Therapeutic, this.labelATS_HD_OrganFailure_Desc, this.ATS_HD_OrganFailure_Desc, this.labelATS_HD_Pulmonary_Desc, this.ATS_HD_Pulmonary_Desc, this.labelATS_HD_Cardiovascular_Desc, this.ATS_HD_Cardiovascular_Desc, this.labelATS_HD_Contracture_Desc, this.ATS_HD_Contracture_Desc, this.labelATS_HD_Deformity_Desc, this.ATS_HD_Deformity_Desc, this.labelATS_HD_UseHimself_Desc, this.ATS_HD_UseHimself_Desc, this.labelATS_HD_ChairModel_Desc, this.ATS_HD_ChairModel_Desc, this.labelATS_HD_ConstantCondition_Desc, this.ATS_HD_ConstantCondition_Desc, this.labelATS_HD_OrganFailure, this.ATS_HD_OrganFailure, this.labelATS_HD_Pulmonary, this.ATS_HD_Pulmonary, this.labelATS_HD_Cardiovascular, this.ATS_HD_Cardiovascular, this.labelATS_HD_Contracture, this.ATS_HD_Contracture, this.labelATS_HD_Deformity, this.ATS_HD_Deformity, this.labelATS_HD_UseHimself, this.ATS_HD_UseHimself, this.labelATS_HD_ChairModel, this.ATS_HD_ChairModel, this.labelATS_HD_ConstantCondition, this.ATS_HD_ConstantCondition, this.labelATS_HD_UseLowerExtremity_Desc, this.ATS_HD_UseLowerExtremity_Desc, this.labelATS_HD_USELOWEREXTREMITIES, this.ATS_HD_USELOWEREXTREMITIES, this.ATS_HD_NOAMBULATION, this.ATS_HD_INTRACOMMUNITY, this.labelATS_HD_ChairDistance, this.ATS_HD_ChairDistance, this.labelATS_SK_HeadDoctorApprove, this.ATS_SK_HeadDoctorApprove, this.labelATS_SK_OrthopedicExpApprove, this.ATS_SK_OrthopedicExpApprove, this.labelATS_SK_FTRExpertApprove, this.ATS_SK_FTRExpertApprove, this.labelATS_SK_ThirdStepHealthInst,
            this.ATS_SK_ThirdStepHealthInst, this.labelATS_SK_MedicalReason, this.ATS_SK_MedicalReason, this.labelATS_SK_ChairType, this.ATS_SK_ChairType, this.labelATS_ChairType, this.ATS_ChairType, this.labelATS_DeliveryDate, this.ATS_DeliveryDate, this.labelATS_ChairNumber, this.ATS_ChairNumber, this.labelATS_CauseOfInjury, this.ATS_CauseOfInjury];


    }


}
