import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { TreatmentMaterialForm } from "./TreatmentMaterialForm";
import { FwModule } from "Fw/FwModule";

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule],
    declarations: [TreatmentMaterialForm],
    exports: [TreatmentMaterialForm],
    entryComponents: [TreatmentMaterialForm]
})
export class TreatmentMaterialModule {
	static dynamicComponentsMap = {
		TreatmentMaterialForm
	};
 }