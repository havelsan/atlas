//$5944EC89
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { FwModule } from 'Fw/FwModule';
import { HospitalTimeScheduleComponent } from './HospitalTimeScheduleComponent';


 @NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,  HttpClientModule ],
    declarations: [HospitalTimeScheduleComponent],
    exports: [HospitalTimeScheduleComponent],
    entryComponents: [HospitalTimeScheduleComponent]
})
export class HospitalTimeScheduleModule {
	static dynamicComponentsMap = {
		HospitalTimeScheduleComponent
	};
 }
