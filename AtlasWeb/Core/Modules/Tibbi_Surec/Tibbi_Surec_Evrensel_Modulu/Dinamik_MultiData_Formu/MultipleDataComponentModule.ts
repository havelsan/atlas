//$555E95F1
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { MultipleDataComponentForm } from './MultipleDataComponentForm';


@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
    declarations: [
         MultipleDataComponentForm
    ],
    exports: [
         MultipleDataComponentForm
    ],
    entryComponents: [
         MultipleDataComponentForm
    ]
})
export class MultipleDataComponentModule {
	static dynamicComponentsMap = {
		MultipleDataComponentForm
	};
 }