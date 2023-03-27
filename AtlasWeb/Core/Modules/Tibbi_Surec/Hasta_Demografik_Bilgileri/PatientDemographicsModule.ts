import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FwModule } from 'Fw/FwModule';
import { PatientDemographicsForm } from './PatientDemographicsForm';
import { DevExtremeModule } from 'devextreme-angular';
import { PatientDemographicsSimplyForm } from './PatientDemographicsSimplyForm';
import { PatientDemographicsNewForm } from './PatientDemographicsNewForm';

@NgModule({
	declarations: [PatientDemographicsForm, PatientDemographicsSimplyForm, PatientDemographicsNewForm],
	imports: [CommonModule, FormsModule, FwModule, DevExtremeModule],
	exports: [PatientDemographicsForm, PatientDemographicsSimplyForm, PatientDemographicsNewForm],
	entryComponents: [PatientDemographicsForm, PatientDemographicsSimplyForm, PatientDemographicsNewForm]
})
export class PatientDemographicsModule {
	static dynamicComponentsMap = {
		PatientDemographicsForm,
		PatientDemographicsSimplyForm,
		PatientDemographicsNewForm
	};

}