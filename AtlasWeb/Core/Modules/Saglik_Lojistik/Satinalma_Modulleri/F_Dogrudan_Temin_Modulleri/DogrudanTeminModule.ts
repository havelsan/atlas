//$E3837744
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { DirectMaterialSupplyCompletedForm } from './DirectMaterialSupplyCompletedForm';
import { BaseDirectMaterialSupplyForm } from './BaseDirectMaterialSupplyForm';
import { DirectMaterialSupplyNewForm } from './DirectMaterialSupplyNewForm';
import { DirectMaterialSupplyRequestForm } from './DirectMaterialSupplyRequestForm';
import { DirectMaterialSupplyCancelledForm } from './DirectMaterialSupplyCancelledForm';
import { PatientDemographicsModule } from 'Modules/Tibbi_Surec/Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DiagnosisGridReadOnlyModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule';

const routes: Routes = [
    {
        path: '',

    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, DiagnosisGridReadOnlyModule,
                RouterModule.forChild(routes)],
declarations: [
DirectMaterialSupplyCompletedForm, BaseDirectMaterialSupplyForm, DirectMaterialSupplyNewForm,
DirectMaterialSupplyRequestForm, DirectMaterialSupplyCancelledForm
 ],
 exports: [
 DirectMaterialSupplyCompletedForm, BaseDirectMaterialSupplyForm, DirectMaterialSupplyNewForm,
 DirectMaterialSupplyRequestForm, DirectMaterialSupplyCancelledForm
  ],
entryComponents: [
  DirectMaterialSupplyCompletedForm, BaseDirectMaterialSupplyForm, DirectMaterialSupplyNewForm,
  DirectMaterialSupplyRequestForm, DirectMaterialSupplyCancelledForm
   ]
})
export class DogrudanTeminModule {
	static dynamicComponentsMap = {
		DirectMaterialSupplyCompletedForm, 
		BaseDirectMaterialSupplyForm, 
		DirectMaterialSupplyNewForm, 
		DirectMaterialSupplyRequestForm, 
		DirectMaterialSupplyCancelledForm
	};
 }

