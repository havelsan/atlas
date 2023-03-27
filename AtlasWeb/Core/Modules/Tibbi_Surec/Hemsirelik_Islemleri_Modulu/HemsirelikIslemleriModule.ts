//$ABC96F4C
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { NursingApplicationMainForm } from './NursingApplicationMainForm';
import { TreatmentMaterialModule } from 'Modules/Tibbi_Surec/Sarf_Malzeme_Modulu/TreatmentMaterialModule';
import { NursingPupilSymptomsForm } from './NursingPupilSymptomsForm';
import { NursingOrderDetailForm } from './NursingOrderDetailForm';
import { NursingFunctionalDailyLifeActivityNewForm } from './NursingFunctionalDailyLifeActivityNewForm';
import { NursingCareMainForm } from './NursingCareMainForm';
import { NursingGlaskowComaScaleForm } from './NursingGlaskowComaScaleForm';
import { NursingWoundAssessmentScaleForm } from './NursingWoundAssessmentScaleForm';
import { NursingLegMeasurementForm } from './NursingLegMeasurementForm';
import { NursingNutritionalRiskAssessmentForm } from './NursingNutritionalRiskAssessmentForm';
import { NursingBodilyFluidIntakeOutputForm } from './NursingBodilyFluidIntakeOutputForm';
import { NursingBodilyFluidAnalysisForm } from './NursingBodilyFluidAnalysisForm';
import { NursingPatientPreAssessmentForm } from './NursingPatientPreAssessmentForm';
import { BaseNursingDataEntryForm } from './BaseNursingDataEntryForm';
import { NursingAppliProgressForm } from './NursingAppliProgressForm';
import { NursingDynamicComponentForm } from './Dinamik_Hemsirelik_Formu/NursingDynamicComponentForm';
import { PatientDemographicsModule } from "../Hasta_Demografik_Bilgileri/PatientDemographicsModule";
import { DiagnosisGridReadOnlyModule } from "Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule";
import { NursingPainScaleForm } from './NursingPainScaleForm';
import { NursingSpiritualEvaluationForm } from './NursingSpiritualEvaluationForm';
import { NursingNutritionAssessmentForm } from './NursingNutritionAssessmentForm';
import { BaseNursingPatientAndFamilyInstructionForm } from './BaseNursingPatientAndFamilyInstructionForm';
import { BaseNursingSystemInterrogationForm } from './BaseNursingSystemInterrogationForm';
import { BaseNursingDischargingInstructionPlanForm } from './BaseNursingDischargingInstructionPlanForm';
import { BaseNursingFallingDownRiskForm } from './BaseNursingFallingDownRiskForm';
import { ProcedureRequestModule } from '../Tetkik_Istem_Modulu/ProcedureRequestModule';
import { PatientHistoryModule } from '../Hasta_Gecmisi/PatientHistoryModule';
import { NursingAplicationDoctorForm } from './NursingAplicationDoctorForm';
import { AtlasReportModule } from 'app/Report/AtlasReportModule';
import { ConsultationRequestModule } from 'Modules/Tibbi_Surec/Konsultasyon_Istem_Modulu/ConsultationRequestModule';
import { NursingWoundedAssesmentForm } from './NursingWoundedAssesmentForm';
import { NursingOrderScheduleComponent } from './NursingOrderScheduleComponent';
import { ArchiveDeliveryForm } from './ArchiveDeliveryForm';
import { TeleOrderGridComponent } from 'Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/TeleOrderGridComponent';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, DiagnosisGridReadOnlyModule, TreatmentMaterialModule, ProcedureRequestModule, PatientHistoryModule, AtlasReportModule, ConsultationRequestModule],
declarations: [
    NursingDynamicComponentForm, NursingAppliProgressForm, NursingNutritionalRiskAssessmentForm, NursingWoundAssessmentScaleForm, NursingLegMeasurementForm, BaseNursingDataEntryForm, NursingApplicationMainForm, NursingGlaskowComaScaleForm, NursingPupilSymptomsForm, NursingPainScaleForm,
    NursingSpiritualEvaluationForm, NursingNutritionAssessmentForm, NursingFunctionalDailyLifeActivityNewForm, BaseNursingPatientAndFamilyInstructionForm, NursingOrderDetailForm, NursingBodilyFluidAnalysisForm, NursingBodilyFluidIntakeOutputForm,
    NursingCareMainForm, BaseNursingSystemInterrogationForm, BaseNursingDischargingInstructionPlanForm, BaseNursingFallingDownRiskForm, NursingAplicationDoctorForm, NursingPatientPreAssessmentForm, NursingWoundedAssesmentForm, NursingOrderScheduleComponent, ArchiveDeliveryForm, TeleOrderGridComponent
 ],
 exports: [
	 NursingDynamicComponentForm, NursingAppliProgressForm, NursingNutritionalRiskAssessmentForm, NursingWoundAssessmentScaleForm, NursingLegMeasurementForm, BaseNursingDataEntryForm, NursingApplicationMainForm, NursingGlaskowComaScaleForm, NursingPupilSymptomsForm, NursingPainScaleForm,
	 NursingSpiritualEvaluationForm, NursingNutritionAssessmentForm, NursingFunctionalDailyLifeActivityNewForm, BaseNursingPatientAndFamilyInstructionForm, NursingOrderDetailForm, NursingBodilyFluidAnalysisForm, NursingBodilyFluidIntakeOutputForm,
     NursingCareMainForm, BaseNursingSystemInterrogationForm, BaseNursingDischargingInstructionPlanForm, BaseNursingFallingDownRiskForm, NursingAplicationDoctorForm, NursingPatientPreAssessmentForm, NursingWoundedAssesmentForm, NursingOrderScheduleComponent, ArchiveDeliveryForm, TeleOrderGridComponent
  ],
  entryComponents: [
	  NursingDynamicComponentForm, NursingAppliProgressForm, NursingNutritionalRiskAssessmentForm, NursingWoundAssessmentScaleForm, NursingLegMeasurementForm, BaseNursingDataEntryForm, NursingApplicationMainForm, NursingGlaskowComaScaleForm, NursingPupilSymptomsForm, NursingPainScaleForm,
	  NursingSpiritualEvaluationForm, NursingNutritionAssessmentForm, NursingFunctionalDailyLifeActivityNewForm, BaseNursingPatientAndFamilyInstructionForm, NursingOrderDetailForm, NursingBodilyFluidAnalysisForm, NursingBodilyFluidIntakeOutputForm,
      NursingCareMainForm, BaseNursingSystemInterrogationForm, BaseNursingDischargingInstructionPlanForm, BaseNursingFallingDownRiskForm, NursingAplicationDoctorForm, NursingPatientPreAssessmentForm, NursingWoundedAssesmentForm, NursingOrderScheduleComponent, ArchiveDeliveryForm, TeleOrderGridComponent
   ]
})
export class HemsirelikIslemleriModule {
	static dynamicComponentsMap = {
		NursingDynamicComponentForm, 
		NursingAppliProgressForm, 
		NursingNutritionalRiskAssessmentForm, 
		NursingWoundAssessmentScaleForm, 
		NursingLegMeasurementForm, 
		BaseNursingDataEntryForm, 
		NursingApplicationMainForm, 
		NursingGlaskowComaScaleForm, 
		NursingPupilSymptomsForm, 
		NursingPainScaleForm, 
		NursingSpiritualEvaluationForm, 
		NursingNutritionAssessmentForm, 
		NursingFunctionalDailyLifeActivityNewForm, 
		BaseNursingPatientAndFamilyInstructionForm, 
		NursingOrderDetailForm, 
		NursingBodilyFluidAnalysisForm, 
		NursingBodilyFluidIntakeOutputForm, 
		NursingCareMainForm, 
		BaseNursingSystemInterrogationForm, 
		BaseNursingDischargingInstructionPlanForm, 
		BaseNursingFallingDownRiskForm, 
		NursingAplicationDoctorForm, 
		NursingPatientPreAssessmentForm,
		NursingWoundedAssesmentForm,
        NursingOrderScheduleComponent,
		ArchiveDeliveryForm,
		TeleOrderGridComponent
	};
 }

