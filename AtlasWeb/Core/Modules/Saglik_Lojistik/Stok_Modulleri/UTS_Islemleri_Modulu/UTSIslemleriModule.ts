//$EDB69E19
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { UTSBatchNotificationForm } from './UTSBatchNotificationForm';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
    declarations: [
        UTSBatchNotificationForm
    ],
    exports: [
        UTSBatchNotificationForm
    ],
    entryComponents: [
        UTSBatchNotificationForm
    ]
})
export class UTSIslemleriModule {
	static dynamicComponentsMap = {
		UTSBatchNotificationForm
	};
 }

