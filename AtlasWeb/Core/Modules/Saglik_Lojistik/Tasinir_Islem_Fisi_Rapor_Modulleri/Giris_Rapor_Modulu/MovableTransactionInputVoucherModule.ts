import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { MovableTransactionInputVoucherForm } from './MovableTransactionInputVoucherForm';
import { MaterialMultiSelectModule } from 'Modules/Saglik_Lojistik/Stok_Modulleri/MaterialMultiSelect/MaterialMultiSelectModule';


@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, MaterialMultiSelectModule ],
    declarations: [MovableTransactionInputVoucherForm],
    exports: [MovableTransactionInputVoucherForm],
    entryComponents: [MovableTransactionInputVoucherForm]
})
export class MovableTransactionInputVoucherModule {
	static dynamicComponentsMap = {
		MovableTransactionInputVoucherForm
	};
 }

