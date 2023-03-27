//$577A0478
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { DentalLaboratoryForm } from './DentalLaboratoryForm';
import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DiagnosisGridReadOnlyModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule';
import { TreatmentMaterialModule } from 'Modules/Tibbi_Surec/Sarf_Malzeme_Modulu/TreatmentMaterialModule';

const routes: Routes = [
    {
        path: '',
        component: DentalLaboratoryForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, DiagnosisGridReadOnlyModule, TreatmentMaterialModule,
        RouterModule.forChild(routes)],
    declarations: [
        DentalLaboratoryForm
    ],
    exports: [
        DentalLaboratoryForm
    ],
    entryComponents: [
        DentalLaboratoryForm
    ]
})
export class DisIslemleriModule {
	static dynamicComponentsMap = {
		DentalLaboratoryForm
	};
 }

