//$244FDF8F
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { HCNewForm } from './HCNewForm';
import { HCExaminationForm } from "./HCExaminationForm";
import { HCExaminationComponentForm } from "./HCExaminationComponentForm";
import { PatientDemographicsModule } from 'Modules/Tibbi_Surec/Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DiagnosisGridReadOnlyModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule';
import { LowerExtremityForm } from './LowerExtremityForm';
import { UpperExtremityForm } from './UpperExtremityForm';
import { AnamnezModule } from 'Modules/Tibbi_Surec/Tibbi_Surec_Evrensel_Modulu/AnamnezModule';
import { BaseHCExaminationDynamicObjectForm } from './BaseHCExaminationDynamicObjectForm';
import { MemberOfHealthCommitteeDefinitionForm } from 'Modules/Merkezi_Yonetim_Sistemi/Tibbi_Surec_Tanim/Saglik_Kurulu_Heyet_Teskili_Tanimlama_Modulu/MemberOfHealthCommitteeDefinitionForm';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, DiagnosisGridReadOnlyModule, AnamnezModule],
declarations: [
//HCPApprovalForm,HCPApprovalRequestForm,HCProfsRequestApprovalForm,HCProfsCancelledForm,
//HCProfsRequestForm,HCProfsCommitteeExaminationForm,HCProfsSecretaryForm,HCPCommitteeAcceptance,
//HCPReportApproval,HospitalsUnitsDefinitionGridForm,ExaminationApprovalExaminationForm,
//ExaminationApprovalNewForm,HCODNewFrom,HCOHCancelledForm,HCOHExtHospDecisionRegistrationForm,
//HCOHDecisionRegistrationForm,HCOHTransferDocumentConstitutionForm,HCTSRequestForm,
//HCTSCancelForm,HCTSReportForm,HCTSNewForm,HCTSApprovalForm,AppointmentFormHCExamination,
//HCENewForm,HCEExaminationCancelForm,HCEExaminationForm,MCCommitteeForm,MCCancelledForm,
//AppointmentFormMedical,MCRequestForm,MCAcceptForm,CEHHCRSelectionofControllerForm,
//CEHHCRRequestForm,CEHHCRCancelledForm,HCAppointmentForm,HCReportedForm,ReportOutputForm,
    //    HCCancelledForm,
    HCNewForm,
    HCExaminationForm,
    //HealthCommitteeSpecialityObjectForm,
    HCExaminationComponentForm, LowerExtremityForm, UpperExtremityForm, BaseHCExaminationDynamicObjectForm,
    MemberOfHealthCommitteeDefinitionForm
 //   , HCEODApprovalForm, HCEOCancelledForm, HCEODNewForm
 ],
 exports: [
 //HCPApprovalForm,HCPApprovalRequestForm,HCProfsRequestApprovalForm,HCProfsCancelledForm,
 //HCProfsRequestForm,HCProfsCommitteeExaminationForm,HCProfsSecretaryForm,HCPCommitteeAcceptance,
 //HCPReportApproval,HospitalsUnitsDefinitionGridForm,ExaminationApprovalExaminationForm,
 //ExaminationApprovalNewForm,HCODNewFrom,HCOHCancelledForm,HCOHExtHospDecisionRegistrationForm,
 //HCOHDecisionRegistrationForm,HCOHTransferDocumentConstitutionForm,HCTSRequestForm,
 //HCTSCancelForm,HCTSReportForm,HCTSNewForm,HCTSApprovalForm,AppointmentFormHCExamination,
 //HCENewForm,HCEExaminationCancelForm,HCEExaminationForm,MCCommitteeForm,MCCancelledForm,
 //AppointmentFormMedical,MCRequestForm,MCAcceptForm,CEHHCRSelectionofControllerForm,
 //CEHHCRRequestForm,CEHHCRCancelledForm,HCAppointmentForm,HCReportedForm,ReportOutputForm,
     //    HCCancelledForm,
     HCNewForm,
     HCExaminationForm,
     //HealthCommitteeSpecialityObjectForm,
     HCExaminationComponentForm, LowerExtremityForm, UpperExtremityForm, BaseHCExaminationDynamicObjectForm,
     MemberOfHealthCommitteeDefinitionForm
 //    , HCEODApprovalForm, HCEOCancelledForm, HCEODNewForm
  ],
  entryComponents: [
  //HCPApprovalForm,HCPApprovalRequestForm,HCProfsRequestApprovalForm,HCProfsCancelledForm,
  //HCProfsRequestForm,HCProfsCommitteeExaminationForm,HCProfsSecretaryForm,HCPCommitteeAcceptance,
  //HCPReportApproval,HospitalsUnitsDefinitionGridForm,ExaminationApprovalExaminationForm,
  //ExaminationApprovalNewForm,HCODNewFrom,HCOHCancelledForm,HCOHExtHospDecisionRegistrationForm,
  //HCOHDecisionRegistrationForm,HCOHTransferDocumentConstitutionForm,HCTSRequestForm,
  //HCTSCancelForm,HCTSReportForm,HCTSNewForm,HCTSApprovalForm,AppointmentFormHCExamination,
  //HCENewForm,HCEExaminationCancelForm,HCEExaminationForm,MCCommitteeForm,MCCancelledForm,
  //AppointmentFormMedical,MCRequestForm,MCAcceptForm,CEHHCRSelectionofControllerForm,
  //CEHHCRRequestForm,CEHHCRCancelledForm,HCAppointmentForm,HCReportedForm,ReportOutputForm,
      //    HCCancelledForm,
      HCNewForm,
      HCExaminationForm,
      //HealthCommitteeSpecialityObjectForm,
      HCExaminationComponentForm, LowerExtremityForm, UpperExtremityForm, BaseHCExaminationDynamicObjectForm,
      MemberOfHealthCommitteeDefinitionForm
  //    , HCEODApprovalForm, HCEOCancelledForm, HCEODNewForm
   ]
})
export class SaglikKuruluModule {
	static dynamicComponentsMap = {
		HCNewForm, 
		HCExaminationForm, 
		HCExaminationComponentForm, 
		LowerExtremityForm, 
        UpperExtremityForm,
        BaseHCExaminationDynamicObjectForm,
        MemberOfHealthCommitteeDefinitionForm

	};
 }

