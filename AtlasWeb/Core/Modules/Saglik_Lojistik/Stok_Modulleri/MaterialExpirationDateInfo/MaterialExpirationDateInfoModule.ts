import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { MaterialExpirationDateInfoForm } from './MaterialExpirationDateInfoForm';


@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule ],
    declarations: [MaterialExpirationDateInfoForm],
    exports: [MaterialExpirationDateInfoForm],
    entryComponents: [MaterialExpirationDateInfoForm]
})
export class MaterialExpirationDateInfoModule {
	static dynamicComponentsMap = {
		MaterialExpirationDateInfoForm
	};
 }

