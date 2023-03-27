import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { NuclearWorkListForm } from './NuclearWorkListForm';
import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { PatientSearchModule } from '../PatientSearch/PatientSearchModule';

const routes: Routes = [
    {
        path: '',
        component: NuclearWorkListForm,
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule,
     DevExtremeModule, FwModule, PatientDemographicsModule, PatientSearchModule,
     RouterModule.forChild(routes)],
    declarations: [NuclearWorkListForm],
    entryComponents: [NuclearWorkListForm],
    exports: [NuclearWorkListForm]
})
export class NuclearWorkListModule {
	static dynamicComponentsMap = {
		NuclearWorkListForm
	};

}

