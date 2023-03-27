//$D962FAFD
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { ManipulationRequestForm } from './ManipulationRequestForm';
import { ManipulationProcedureForm } from './ManipulationProcedureForm';
import { AppointmentFormManipulation } from './AppointmentFormManipulation';
import { ManipulationRequestAcceptionForm } from './ManipulationRequestAcceptionForm';
import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DiagnosisGridModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridModule';
import { DiagnosisGridReadOnlyModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule';
import { TreatmentMaterialModule } from 'Modules/Tibbi_Surec/Sarf_Malzeme_Modulu/TreatmentMaterialModule';
import { ManipulationFormBaseObjectForm } from './ManipulationFormBaseObjectForm';
import { EkokardiografiForm } from './EkokardiografiForm';
import { AudiologyForm } from './AudiologyForm';

const routes: Routes = [
    {
        path: '',
        component: ManipulationRequestForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, DiagnosisGridModule, DiagnosisGridReadOnlyModule, TreatmentMaterialModule,
                RouterModule.forChild(routes)],
declarations: [
    ManipulationRequestForm, ManipulationProcedureForm, ManipulationRequestAcceptionForm, AppointmentFormManipulation, ManipulationFormBaseObjectForm, EkokardiografiForm, AudiologyForm
//    , ManipSelection, MinorManipulationDoctorForm, ManiplationRequestingDoctorAcception,
//AppointmentFormManipulation,ManipulationCompletedForm,ManipulationResultEntryForm,
//ManipulationCancelledForm,ManipulationDoctorForm,ManipulationTechnicianForm,ManiplationRequestingDoctorDoctorForm,

 ],
 exports: [
	 ManipulationRequestForm, ManipulationProcedureForm, ManipulationRequestAcceptionForm, AppointmentFormManipulation, ManipulationFormBaseObjectForm, EkokardiografiForm, AudiologyForm
 //    , ManipSelection, MinorManipulationDoctorForm, ManiplationRequestingDoctorAcception,
 //AppointmentFormManipulation,ManipulationCompletedForm,ManipulationResultEntryForm,
 //ManipulationCancelledForm,ManipulationDoctorForm,ManipulationTechnicianForm,ManiplationRequestingDoctorDoctorForm,
 
  ],
  entryComponents: [
	  ManipulationRequestForm, ManipulationProcedureForm, ManipulationRequestAcceptionForm, AppointmentFormManipulation, ManipulationFormBaseObjectForm, EkokardiografiForm, AudiologyForm
  //    , ManipSelection, MinorManipulationDoctorForm, ManiplationRequestingDoctorAcception,
  //AppointmentFormManipulation,ManipulationCompletedForm,ManipulationResultEntryForm,
  //ManipulationCancelledForm,ManipulationDoctorForm,ManipulationTechnicianForm,ManiplationRequestingDoctorDoctorForm,
  
   ]
})
export class ManipulasyonModule {
	static dynamicComponentsMap = {
		ManipulationRequestForm, 
		ManipulationProcedureForm, 
		ManipulationRequestAcceptionForm, 
		AppointmentFormManipulation, 
		ManipulationFormBaseObjectForm, 
		EkokardiografiForm, 
		AudiologyForm
	};
 }

