//$557A4F51
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { DiagnosisGridModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridModule';
import { DiagnosisGridReadOnlyModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule';
import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DispatchToOtherHospitalForm } from './DispatchToOtherHospitalForm';

const routes: Routes = [
    {
        path: '',
        component: DispatchToOtherHospitalForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, DiagnosisGridModule, DiagnosisGridReadOnlyModule, PatientDemographicsModule,
                RouterModule.forChild(routes)],
declarations: [
/*DispatchToOtherHospResultForm,DispatchToOtherHospCompletedForm,DispatchToOtherHospital_SaglikTesisiAraForm,*/
DispatchToOtherHospitalForm
 ],
 exports: [
 /*DispatchToOtherHospResultForm,DispatchToOtherHospCompletedForm,DispatchToOtherHospital_SaglikTesisiAraForm,*/
 DispatchToOtherHospitalForm
  ],
  entryComponents: [
  /*DispatchToOtherHospResultForm,DispatchToOtherHospCompletedForm,DispatchToOtherHospital_SaglikTesisiAraForm,*/
  DispatchToOtherHospitalForm
   ]
})
export class XXXXXXlerArasiSevkModule {
	static dynamicComponentsMap = {
		/*DispatchToOtherHospResultForm, 
		DispatchToOtherHospCompletedForm, 
		DispatchToOtherHospital_SaglikTesisiAraForm, 
		*/
DispatchToOtherHospitalForm
	};
 }

