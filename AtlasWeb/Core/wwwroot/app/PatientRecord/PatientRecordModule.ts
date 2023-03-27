import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FwModule } from 'Fw/FwModule';
import { PatientRecordView } from './Views/PatientRecordView';
import { DevExtremeModule } from 'devextreme-angular';

@NgModule({
    declarations: [PatientRecordView],
    imports: [CommonModule, FormsModule, FwModule, DevExtremeModule],
    exports: [PatientRecordView],
    entryComponents: [PatientRecordView]
})
export class PatientRecordModule {
	static dynamicComponentsMap = {
		PatientRecordView
	};


}