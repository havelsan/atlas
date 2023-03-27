import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { PatientBasedMaterialSelectForm } from './PatientBasedMaterialSelectForm';
import { PatientSearchModule } from 'Modules/Tibbi_Surec/PatientSearch/PatientSearchModule';


@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, PatientSearchModule ],
    declarations: [PatientBasedMaterialSelectForm],
    exports: [PatientBasedMaterialSelectForm],
    entryComponents: [PatientBasedMaterialSelectForm]
})
export class PatientMaterialMultiSelectModule {
	static dynamicComponentsMap = {
		PatientBasedMaterialSelectForm
	};
 }

