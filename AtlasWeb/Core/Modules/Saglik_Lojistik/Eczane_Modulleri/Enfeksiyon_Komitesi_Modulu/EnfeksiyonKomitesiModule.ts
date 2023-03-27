//$55E7F722
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { InfectionCommitteeForm } from './InfectionCommitteeForm';
import { PatientDemographicsModule } from 'Modules/Tibbi_Surec/Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { DiagnosisGridReadOnlyModule } from 'Modules/Tibbi_Surec/Tani_Modulu/DiagnosisGridReadOnlyModule';
import { PatientHistoryModule } from 'Modules/Tibbi_Surec/Hasta_Gecmisi/PatientHistoryModule';
import { RadyolojiModule } from 'Modules/Tibbi_Surec/Radyoloji_Modulu/RadyolojiModule';
const routes: Routes = [
    {
        path: '',
        component: InfectionCommitteeForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientDemographicsModule, 
        DiagnosisGridReadOnlyModule, PatientHistoryModule, RadyolojiModule,
        RouterModule.forChild(routes)],
    declarations: [
        InfectionCommitteeForm
    ],
    exports: [
        InfectionCommitteeForm
    ],
    entryComponents: [
        InfectionCommitteeForm
    ]

})
export class EnfeksiyonKomitesiModule {
    static dynamicComponentsMap = {
        InfectionCommitteeForm
    };
}

