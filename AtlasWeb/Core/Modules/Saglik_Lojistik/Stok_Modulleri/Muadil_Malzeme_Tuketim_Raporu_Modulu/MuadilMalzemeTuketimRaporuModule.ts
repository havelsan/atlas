import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { FwModule } from 'Fw/FwModule';
import { EquivalentMaterialConsumptionForm } from './EquivalentMaterialConsumptionForm';
import { MaterialMultiSelectModule } from '../MaterialMultiSelect/MaterialMultiSelectModule';



@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, HttpClientModule,MaterialMultiSelectModule ],
    declarations: [EquivalentMaterialConsumptionForm],
    exports: [EquivalentMaterialConsumptionForm],
    entryComponents: [EquivalentMaterialConsumptionForm]
})
export class MuadilMalzemeTuketimRaporuModule {
	static dynamicComponentsMap = {
        EquivalentMaterialConsumptionForm
        
	};
 }

