//$B88AB63F
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { DrugDefinitionForm } from './DrugDefinitionForm';
import { MaterialMultiSelectModule } from 'Modules/Saglik_Lojistik/Stok_Modulleri/MaterialMultiSelect/MaterialMultiSelectModule';


@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,MaterialMultiSelectModule
                ],
declarations: [ 
    DrugDefinitionForm
 ], 
exports: [ 
    DrugDefinitionForm
 ],
 entryComponents: [ 
    DrugDefinitionForm
 ] 
 
})
export class IlacVademecumTanimlariModule {
	static dynamicComponentsMap = {
		DrugDefinitionForm
	};
 }

