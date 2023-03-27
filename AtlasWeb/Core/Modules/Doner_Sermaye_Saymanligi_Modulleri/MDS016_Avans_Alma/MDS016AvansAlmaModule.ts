//$1412246F
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { AdvanceForm } from './AdvanceForm';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
    declarations: [AdvanceForm],
    exports: [AdvanceForm],
    entryComponents: [AdvanceForm]
})
export class MDS016AvansAlmaModule {
	static dynamicComponentsMap = {
		AdvanceForm
	};

}

