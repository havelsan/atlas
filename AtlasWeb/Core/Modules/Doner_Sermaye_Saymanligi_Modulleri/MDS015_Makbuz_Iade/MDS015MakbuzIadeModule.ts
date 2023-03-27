//$3E42C2F0
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { ReceiptBackForm } from './ReceiptBackForm';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
    declarations: [
        ReceiptBackForm
    ],
    exports: [
        ReceiptBackForm
    ],
    entryComponents: [
        ReceiptBackForm
    ]

})
export class MDS015MakbuzIadeModule {
	static dynamicComponentsMap = {
		ReceiptBackForm
	};
 }

