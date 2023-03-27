import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from "Fw/FwModule";
import { MedicalInformationForm } from "./MedicalInformationForm";

@NgModule({
imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
declarations: [
    MedicalInformationForm
 ],
 exports: [
	 MedicalInformationForm
  ],
  entryComponents: [
	  MedicalInformationForm
   ]
})
export class OnemliTibbiBilgilerModule {
	static dynamicComponentsMap = {
		MedicalInformationForm
	};
 }

