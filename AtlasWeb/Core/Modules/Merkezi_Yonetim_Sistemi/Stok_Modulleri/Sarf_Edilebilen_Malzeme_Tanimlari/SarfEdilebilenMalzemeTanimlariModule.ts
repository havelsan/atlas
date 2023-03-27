//$B88AB63F
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { ConsumableMaterialDefinitionForm } from './ConsumableMaterialDefinitionForm';


@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
                ],
declarations: [ 
    ConsumableMaterialDefinitionForm
 ], 
exports: [ 
    ConsumableMaterialDefinitionForm
 ] ,
 entryComponents: [ 
    ConsumableMaterialDefinitionForm
 ] 

})
export class SarfEdilebilenMalzemeTanimlariModule {
	static dynamicComponentsMap = {
		ConsumableMaterialDefinitionForm
	};
 }

