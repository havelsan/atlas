//$549542DA
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { ChemotherapyRadiotherapyForm } from './ChemotherapyRadiotherapyForm';
import { PatientDemographicsModule } from 'Modules/Tibbi_Surec/Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DiagnosisGridReadOnlyModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule';
import { TreatmentMaterialModule } from 'Modules/Tibbi_Surec/Sarf_Malzeme_Modulu/TreatmentMaterialModule';
import { ProcedureRequestPlanningForm } from './ProcedureRequestPlanningForm';
import { ProcedureRequestModule } from '../Tetkik_Istem_Modulu/ProcedureRequestModule';

const routes: Routes = [
    {
        path: '',
        component: ChemotherapyRadiotherapyForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, TreatmentMaterialModule, DevExtremeModule, PatientDemographicsModule, DiagnosisGridReadOnlyModule,ProcedureRequestModule, FwModule,
        RouterModule.forChild(routes)],
    declarations: [
        ChemotherapyRadiotherapyForm, ProcedureRequestPlanningForm
    ],
    exports: [
        ChemotherapyRadiotherapyForm, ProcedureRequestPlanningForm
    ]
})
export class KemoterapiveRadyoterapiModule {
    static dynamicComponentsMap = {
        ChemotherapyRadiotherapyForm,
        ProcedureRequestPlanningForm
	};
 }

