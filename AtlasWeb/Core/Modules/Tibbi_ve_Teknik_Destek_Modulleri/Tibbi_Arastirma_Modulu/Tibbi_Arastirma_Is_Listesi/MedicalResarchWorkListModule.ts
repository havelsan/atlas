//$E7D1164B
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { SimpleTimer } from 'ng2-simple-timer';
import { MedicalResarchWorkListForm } from './MedicalResarchWorkListForm';
import { PatientSearchModule } from 'Modules/Tibbi_Surec/PatientSearch/PatientSearchModule';
import { MedicalResarchTermDefComponent } from './MedicalResarchTermDefComponent';
import { MedicalResarchComponent } from './MedicalResarchComponent';
import { MedicalResarchPatientComponent } from './MedicalResarchPatientComponent';
import { MedicalResarchPatientAd } from './MedicalResarchPatientAd';
import { PatientDemographicsModule } from 'Modules/Tibbi_Surec/Hasta_Demografik_Bilgileri/PatientDemographicsModule';





const routes: Routes = [
    {
        path: '',
        component: MedicalResarchWorkListForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientSearchModule,PatientDemographicsModule,
        RouterModule.forChild(routes) ],
    declarations: [
        MedicalResarchWorkListForm,MedicalResarchTermDefComponent,MedicalResarchPatientComponent,MedicalResarchPatientAd,MedicalResarchComponent
    ],
    exports: [
        MedicalResarchWorkListForm,MedicalResarchTermDefComponent,MedicalResarchPatientComponent,MedicalResarchPatientAd,MedicalResarchComponent
    ],
    entryComponents: [
        MedicalResarchWorkListForm,MedicalResarchTermDefComponent,MedicalResarchPatientComponent,MedicalResarchPatientAd,MedicalResarchComponent
    ],
    providers: [SimpleTimer]
})
export class MedicalResarchWorkListModule {
    static dynamicComponentsMap = {
        MedicalResarchWorkListForm,
        MedicalResarchTermDefComponent,
        MedicalResarchPatientComponent,
        MedicalResarchPatientAd,
        MedicalResarchComponent
    };
}

