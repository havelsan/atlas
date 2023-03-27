//$2E162944
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { ConsultationRequestForm } from './ConsultationRequestForm';
import { ProcedureRequestSharedService } from '../Tetkik_Istem_Modulu/ProcedureRequestSharedService';

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
declarations: [
     ConsultationRequestForm
 ],
 exports: [
    ConsultationRequestForm
],
entryComponents: [
    ConsultationRequestForm
],
providers: [ProcedureRequestSharedService]
})
export class ConsultationRequestModule {
	static dynamicComponentsMap = {
		ConsultationRequestForm
	};
 }

