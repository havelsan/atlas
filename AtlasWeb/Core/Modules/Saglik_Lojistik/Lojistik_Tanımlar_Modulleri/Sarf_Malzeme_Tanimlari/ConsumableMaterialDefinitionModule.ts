//$B88AB63F
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { ConsumableMaterialDefinitionBaseForm } from './ConsumableMaterialDefinitionBaseForm';


@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                ],
declarations: [
    ConsumableMaterialDefinitionBaseForm
 ],
 exports: [
     ConsumableMaterialDefinitionBaseForm
  ],
entryComponents: [
      ConsumableMaterialDefinitionBaseForm
   ]
})
export class ConsumableMaterialDefinitionModule {
	static dynamicComponentsMap = {
		ConsumableMaterialDefinitionBaseForm
	};
 }