//$64E42223
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { TreatmentMaterialModule } from 'Modules/Tibbi_Surec/Sarf_Malzeme_Modulu/TreatmentMaterialModule';
import { AnesthesiaRequestAcceptionForm } from './AnesthesiaRequestAcceptionForm';
import { AnesthesiaReportForm } from './AnesthesiaReportForm';
import { ProcedureRequestModule } from '../Tetkik_Istem_Modulu/ProcedureRequestModule';
import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DiagnosisGridModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridModule';
import { DiagnosisGridReadOnlyModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule';

const routes: Routes = [
    {
        path: '',
        component: AnesthesiaRequestAcceptionForm,
    },
];

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
    RouterModule.forChild(routes), PatientDemographicsModule, DiagnosisGridModule, DiagnosisGridReadOnlyModule, TreatmentMaterialModule, ProcedureRequestModule],
    declarations: [AnesthesiaRequestAcceptionForm, AnesthesiaReportForm],
    exports: [
        AnesthesiaRequestAcceptionForm
    ],
    entryComponents: [
        AnesthesiaRequestAcceptionForm,
        AnesthesiaReportForm
    ]
})
export class AnesteziveReanimasyonModule {
	static dynamicComponentsMap = {
        AnesthesiaRequestAcceptionForm,
        AnesthesiaReportForm
	};
 }

