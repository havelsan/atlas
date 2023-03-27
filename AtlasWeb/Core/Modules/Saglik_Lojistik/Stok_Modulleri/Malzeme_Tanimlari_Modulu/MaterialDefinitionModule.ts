//$B88AB63F
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { MaterialDefinitionSearchForm } from './MaterialDefinitionSearchForm';


@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                ],
declarations: [
    MaterialDefinitionSearchForm
 ],
exports: [
    MaterialDefinitionSearchForm
 ],
 entryComponents: [
     MaterialDefinitionSearchForm
  ]
})
export class MaterialDefinitionModule {
	static dynamicComponentsMap = {
		MaterialDefinitionSearchForm
	};
 }

