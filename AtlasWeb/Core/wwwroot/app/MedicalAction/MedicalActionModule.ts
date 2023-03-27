import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FwModule } from 'Fw/FwModule';
import { MedicalWorkListForm } from './Views/MedicalWorkListForm';
import { DevExtremeModule } from 'devextreme-angular';

@NgModule({
    declarations: [MedicalWorkListForm],
    imports: [CommonModule, FormsModule, FwModule, DevExtremeModule],
    exports: [MedicalWorkListForm],
    entryComponents: [MedicalWorkListForm]
})
export class MedicalActionModule {
	static dynamicComponentsMap = {
		MedicalWorkListForm
	};

}