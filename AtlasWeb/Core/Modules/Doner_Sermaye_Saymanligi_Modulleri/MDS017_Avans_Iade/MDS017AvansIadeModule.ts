//$0DE4BBF7
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { AdvanceBackForm } from './AdvanceBackForm';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
    declarations: [AdvanceBackForm],
    exports: [AdvanceBackForm],
    entryComponents: [AdvanceBackForm]
})
export class MDS017AvansIadeModule {
	static dynamicComponentsMap = {
		AdvanceBackForm
	};
 }

