//$EAB1DAD9
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { SEPForm } from './SEPForm';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
    declarations: [SEPForm],
    exports: [SEPForm],
    entryComponents: [SEPForm]
})
export class AccountBaseClassesModuleModule {
	static dynamicComponentsMap = {
		SEPForm
	};
 }

