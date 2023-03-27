import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { PatientHistoryForm } from './PatientHistoryForm';

import { OldConsultationsForm } from './OldConsultationsForm';
import { OldExaminationForm } from './OldExaminationForm';
import { OldInpatientPhysicianAppForm } from './OldInpatientPhysicianAppForm';
import { OldSurgeryForm } from './OldSurgeryForm';
import { OldMedicalInformationForm } from './OldMedicalInformationForm';
import { OldVaccineFollowUpForm } from './OldVaccineFollowUpForm';

import { OldWomanSpecialityForm } from './SpacialityModules/OldWomanSpecialityForm';
import { OldVisitDetailsForm } from './SpacialityModules/OldVisitDetailsForm';
import { OldEyeExaminationForm } from './SpacialityModules/OldEyeExaminationForm';
import { OldEmergencyForm } from './SpacialityModules/OldEmergencyForm';
import { OldPsychologyObjectForm } from './SpacialityModules/OldPsychologyObjectForm';
import { OldManipulationForm } from './OldManipulationForm';
import { OldPhysiotherapyRequestForm } from './OldPhysiotherapyRequestForm';

const routes: Routes = [
    {
        path: 'patientHistory',
        component: PatientHistoryForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, RouterModule.forChild(routes)],
    declarations: [PatientHistoryForm,
        OldConsultationsForm, OldExaminationForm, OldInpatientPhysicianAppForm, OldSurgeryForm, OldMedicalInformationForm, OldVaccineFollowUpForm,
        OldWomanSpecialityForm, OldVisitDetailsForm, OldEyeExaminationForm, OldEmergencyForm, OldPsychologyObjectForm, OldManipulationForm, OldPhysiotherapyRequestForm],
		exports: [PatientHistoryForm,
			OldConsultationsForm, OldExaminationForm, OldInpatientPhysicianAppForm, OldSurgeryForm, OldMedicalInformationForm, OldVaccineFollowUpForm,
			OldWomanSpecialityForm, OldVisitDetailsForm, OldEyeExaminationForm, OldEmergencyForm, OldPsychologyObjectForm, OldManipulationForm, OldPhysiotherapyRequestForm],
		entryComponents: [PatientHistoryForm,
				OldConsultationsForm, OldExaminationForm, OldInpatientPhysicianAppForm, OldSurgeryForm, OldMedicalInformationForm, OldVaccineFollowUpForm,
				OldWomanSpecialityForm, OldVisitDetailsForm, OldEyeExaminationForm, OldEmergencyForm, OldPsychologyObjectForm, OldManipulationForm, OldPhysiotherapyRequestForm]
		})
export class PatientHistoryModule {
	static dynamicComponentsMap = {
		PatientHistoryForm, 
		OldConsultationsForm, 
		OldExaminationForm, 
		OldInpatientPhysicianAppForm, 
		OldSurgeryForm, 
		OldMedicalInformationForm, 
		OldVaccineFollowUpForm, 
		OldWomanSpecialityForm, 
		OldVisitDetailsForm, 
		OldEyeExaminationForm, 
		OldEmergencyForm, 
		OldPsychologyObjectForm, 
		OldManipulationForm, 
		OldPhysiotherapyRequestForm
	};
 }

