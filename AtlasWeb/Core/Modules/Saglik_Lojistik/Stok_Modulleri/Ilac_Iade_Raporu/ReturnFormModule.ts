import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule, DxSelectBoxModule, DxCheckBoxModule, DxListModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { MaterialMultiSelectModule } from 'Modules/Saglik_Lojistik/Stok_Modulleri/MaterialMultiSelect/MaterialMultiSelectModule';
import { ReturnForm } from './ReturnForm';


@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, MaterialMultiSelectModule, DxSelectBoxModule, DxCheckBoxModule, DxListModule],
    declarations: [ReturnForm],
    exports: [ReturnForm],
    entryComponents: [ReturnForm]
})

export class ReturnFormModule {
	static dynamicComponentsMap = {
		ReturnForm
	};
 }

