import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { PopupTextAreaForm } from './PopupTextAreaForm';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
    declarations: [
        PopupTextAreaForm
    ],
    exports: [
        PopupTextAreaForm
    ],
    entryComponents: [
        PopupTextAreaForm
    ]
})
export class PopupTextAreaModule { 
	static dynamicComponentsMap = {
		PopupTextAreaForm
	};
}

