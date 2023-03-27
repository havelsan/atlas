//$83698FA3
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { PatientAdmissionForm } from './PatientAdmissionForm';
import { NewPatientForm } from './NewPatientForm';
import { PatientAdmissionSearchModule } from './PatientAdmissionSearch/PatientAdmissionSearchModule';
import { PatientSearchWithDetailsModule } from './PatientSearchWithDetails/PatientSearchWithDetailsModule';
import { MergePatientModule } from './MergePatient/MergePatientModule';
import { PatientDemographicsModule } from 'Modules/Tibbi_Surec/Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { PatientCompareModule } from './PatientCompareModule';
import { DispatchExaminationPanelModule } from "Modules/Tibbi_Surec/Kayit_Kabul_Modulu/DispatchExamination/DispatchExaminationPanelModule";
import { LoginModule } from 'app/System/LoginModule';


const kayitKabulRoutes: Routes = [
    {
        path: '',
        component: PatientAdmissionForm,
    },
];

@NgModule({
    imports: [CommonModule, HttpModule, DevExtremeModule, RouterModule.forChild(kayitKabulRoutes),
        FwModule, PatientAdmissionSearchModule, PatientSearchWithDetailsModule, MergePatientModule, 
        DispatchExaminationPanelModule,
        PatientDemographicsModule,  PatientCompareModule, LoginModule],
    declarations: [PatientAdmissionForm, NewPatientForm],
    exports: [PatientAdmissionForm, NewPatientForm],
    entryComponents: [PatientAdmissionForm, NewPatientForm]
})

export class KayitKabulModule {
	static dynamicComponentsMap = {
		PatientAdmissionForm, 
		NewPatientForm
	};

}

