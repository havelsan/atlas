//$4BC48B4F
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { InpatientPrescriptionBaseForm } from './InpatientPrescriptionBaseForm';
import { InpatientPresEReceteDetailForm } from './InpatientPresEReceteDetailForm';
import { InpatientPresciriptionDrugSupplyForm } from './InpatientPresciriptionDrugSupplyForm';
import { InpatientPrescriptionInfectionApprovalForm } from './InpatientPrescriptionInfectionApprovalForm';
import { InpatientPresciriptionForm } from './InpatientPresciriptionForm';
import { PatientDemographicsModule } from 'Modules/Tibbi_Surec/Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DiagnosisGridReadOnlyModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule';

const routes: Routes = [
    {
        path: '',
        component: InpatientPrescriptionBaseForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, DiagnosisGridReadOnlyModule,
                RouterModule.forChild(routes)],
declarations: [
InpatientPrescriptionBaseForm, InpatientPresEReceteDetailForm, InpatientPresciriptionDrugSupplyForm,
InpatientPrescriptionInfectionApprovalForm, InpatientPresciriptionForm
 ],
 exports: [
 InpatientPrescriptionBaseForm, InpatientPresEReceteDetailForm, InpatientPresciriptionDrugSupplyForm,
 InpatientPrescriptionInfectionApprovalForm, InpatientPresciriptionForm
  ],
  entryComponents: [
  InpatientPrescriptionBaseForm, InpatientPresEReceteDetailForm, InpatientPresciriptionDrugSupplyForm,
  InpatientPrescriptionInfectionApprovalForm, InpatientPresciriptionForm
   ]
})
export class YatanHastaRecetesiModule {
	static dynamicComponentsMap = {
		InpatientPrescriptionBaseForm, 
		InpatientPresEReceteDetailForm, 
		InpatientPresciriptionDrugSupplyForm, 
		InpatientPrescriptionInfectionApprovalForm, 
		InpatientPresciriptionForm
	};
 }

