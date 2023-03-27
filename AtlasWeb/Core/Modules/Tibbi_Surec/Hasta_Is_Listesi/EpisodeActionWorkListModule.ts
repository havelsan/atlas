//$2E162944
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { EpisodeActionWorkListForm } from './EpisodeActionWorkListForm';
import { PatientDemographicsModule } from '../Hasta_Demografik_Bilgileri/PatientDemographicsModule';
import { PatientSearchModule } from '../PatientSearch/PatientSearchModule';
import { AtlasCanDeactivateGuard } from 'Fw/Services/AtlasCanDeactivateGuard';
import { SimpleTimer } from 'ng2-simple-timer';

const routes: Routes = [
    {
        path: '',
        component: EpisodeActionWorkListForm,
        canDeactivate: [AtlasCanDeactivateGuard]
    },
];
@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule,
     DevExtremeModule, FwModule, PatientDemographicsModule, PatientSearchModule,
     RouterModule.forChild(routes)],
    declarations: [EpisodeActionWorkListForm],
    exports: [EpisodeActionWorkListForm],
    entryComponents: [EpisodeActionWorkListForm],
    providers: [SimpleTimer]
})
export class EpisodeActionWorkListModule {
	static dynamicComponentsMap = {
		EpisodeActionWorkListForm
	};

}

