//$FB9BD282
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { NuclearMedicineToDoctorForm } from './NuclearMedicineToDoctorForm';
import { NuclearMedicineReportedForm } from './NuclearMedicineReportedForm';
import { NuclearMedicineProcedureForm } from './NuclearMedicineProcedureForm';
import { NuclearMedicineApproveForm } from './NuclearMedicineApproveForm';
import { NuclearMedicinePreparationForm } from './NuclearMedicinePreparationForm';
import { NuclearMedicineRequestAcceptionForm } from './NuclearMedicineRequestAcceptionForm';
import { NuclearMedicineAppointmentInfoForm } from './NuclearMedicineAppointmentInfoForm';
import { NuclearMedicineRejectedForm } from './NuclearMedicineRejectedForm';
import { NuclearMedicineRequestForm } from './NuclearMedicineRequestForm';
import { NuclearMedicineCokluOzelDurum } from './NuclearMedicineCokluOzelDurum';
import { NuclearMedicineRadioPharmacyForm } from './NuclearMedicineRadioPharmacyForm';
import { NuclearMedicineRequestInfoForm } from './NuclearMedicineRequestInfoForm';

import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DiagnosisGridReadOnlyModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule';
import { TreatmentMaterialModule } from 'Modules/Tibbi_Surec/Sarf_Malzeme_Modulu/TreatmentMaterialModule';

import { NuclearMedicineResultsQueryForm } from './NuclearMedicineResultsQueryForm';

const routes: Routes = [
    {
        path: '',
        component: NuclearMedicineToDoctorForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, DiagnosisGridReadOnlyModule, TreatmentMaterialModule,
                RouterModule.forChild(routes)],
declarations: [
NuclearMedicineToDoctorForm, NuclearMedicineReportedForm, NuclearMedicineProcedureForm,
NuclearMedicineApproveForm, NuclearMedicinePreparationForm, NuclearMedicineRequestAcceptionForm,
NuclearMedicineAppointmentInfoForm, NuclearMedicineRejectedForm, NuclearMedicineRequestForm,
NuclearMedicineCokluOzelDurum, NuclearMedicineRadioPharmacyForm, NuclearMedicineRequestInfoForm,
NuclearMedicineResultsQueryForm
 ],
 exports: [
 NuclearMedicineToDoctorForm, NuclearMedicineReportedForm, NuclearMedicineProcedureForm,
 NuclearMedicineApproveForm, NuclearMedicinePreparationForm, NuclearMedicineRequestAcceptionForm,
 NuclearMedicineAppointmentInfoForm, NuclearMedicineRejectedForm, NuclearMedicineRequestForm,
 NuclearMedicineCokluOzelDurum, NuclearMedicineRadioPharmacyForm, NuclearMedicineRequestInfoForm,
 NuclearMedicineResultsQueryForm
  ],
  entryComponents: [
  NuclearMedicineToDoctorForm, NuclearMedicineReportedForm, NuclearMedicineProcedureForm,
  NuclearMedicineApproveForm, NuclearMedicinePreparationForm, NuclearMedicineRequestAcceptionForm,
  NuclearMedicineAppointmentInfoForm, NuclearMedicineRejectedForm, NuclearMedicineRequestForm,
  NuclearMedicineCokluOzelDurum, NuclearMedicineRadioPharmacyForm, NuclearMedicineRequestInfoForm,
  NuclearMedicineResultsQueryForm
   ]
})
export class NukleerTipModule {
	static dynamicComponentsMap = {
		NuclearMedicineToDoctorForm, 
		NuclearMedicineReportedForm, 
		NuclearMedicineProcedureForm, 
		NuclearMedicineApproveForm, 
		NuclearMedicinePreparationForm, 
		NuclearMedicineRequestAcceptionForm, 
		NuclearMedicineAppointmentInfoForm, 
		NuclearMedicineRejectedForm, 
		NuclearMedicineRequestForm, 
		NuclearMedicineCokluOzelDurum, 
		NuclearMedicineRadioPharmacyForm, 
		NuclearMedicineRequestInfoForm, 
		NuclearMedicineResultsQueryForm
	};
 }

