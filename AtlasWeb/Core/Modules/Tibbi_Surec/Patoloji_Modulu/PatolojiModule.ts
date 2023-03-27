//$2B84CDF9
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { PathologyRequestMainForm } from './PathologyRequestMainForm';
import { PathologyMaterialInfo } from './PathologyMaterialInfo';
import { PathologyMainForm } from './PathologyMainForm';
import { PathologyRequestForm } from './PathologyRequestForm';
import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DiagnosisGridModule } from '../Tani_Modulu/DiagnosisGridModule';
import { DiagnosisGridReadOnlyModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule';
import { TreatmentMaterialModule } from 'Modules/Tibbi_Surec/Sarf_Malzeme_Modulu/TreatmentMaterialModule';
import { PathologyAdditionalReportForm } from './PathologyAdditionalReportForm';
import { PanicAlertForm } from './PanicAlertForm';
import { PatientHistoryModule } from '../Hasta_Gecmisi/PatientHistoryModule';

const routes: Routes = [
    {
        path: '',
        component: PathologyMainForm,
    },
    { path: 'patoloji', component: PathologyMainForm},
    { path: 'istek', component: PathologyRequestForm}

];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientHistoryModule, PatientDemographicsModule, DiagnosisGridModule, DiagnosisGridReadOnlyModule, TreatmentMaterialModule,
                RouterModule.forChild(routes)],
declarations: [
PathologyRequestMainForm, PathologyMaterialInfo,
    PathologyMainForm, PathologyRequestForm, PathologyAdditionalReportForm, PanicAlertForm
 ],
 exports: [
 PathologyRequestMainForm, PathologyMaterialInfo,
     PathologyMainForm, PathologyRequestForm, PathologyAdditionalReportForm, PanicAlertForm
  ],
  entryComponents: [
  PathologyRequestMainForm, PathologyMaterialInfo,
      PathologyMainForm, PathologyRequestForm, PathologyAdditionalReportForm, PanicAlertForm
   ]
})
export class PatolojiModule {
	static dynamicComponentsMap = {
		PathologyRequestMainForm, 
		PathologyMaterialInfo, 
		PathologyMainForm, 
		PathologyRequestForm, 
		PathologyAdditionalReportForm, 
        PanicAlertForm
        
	};
 }

