import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { RadiologyWorkListForm } from './RadiologyWorkListForm';
import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { PatientSearchModule } from '../PatientSearch/PatientSearchModule';
import { AtlasCanDeactivateGuard } from 'Fw/Services/AtlasCanDeactivateGuard';

const routes: Routes = [
    {
        path: '',
        component: RadiologyWorkListForm,
        canDeactivate: [AtlasCanDeactivateGuard]
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule,
     DevExtremeModule, FwModule, PatientDemographicsModule, PatientSearchModule,
     RouterModule.forChild(routes)],
    declarations: [RadiologyWorkListForm],
    exports: [RadiologyWorkListForm],
    entryComponents: [RadiologyWorkListForm]
})
export class RadiologyWorkListModule {
	static dynamicComponentsMap = {
		RadiologyWorkListForm
	};

}

