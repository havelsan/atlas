//$B88AB63F
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { DrugDefinitionBaseForm } from './DrugDefinitionBaseForm';


@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                ],
declarations: [
    DrugDefinitionBaseForm
 ],
 exports: [
     DrugDefinitionBaseForm
  ],
  entryComponents: [
      DrugDefinitionBaseForm
   ]
})
export class DrugDefinitionModule {
	static dynamicComponentsMap = {
		DrugDefinitionBaseForm
	};
 }

