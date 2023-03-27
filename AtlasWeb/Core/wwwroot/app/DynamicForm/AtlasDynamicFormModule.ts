import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { FwModule } from 'Fw/FwModule';
import { DevExtremeModule } from 'devextreme-angular';
import { AtlasFormSelectComponent } from "./Views/AtlasFormSelectComponent";
import { AtlasFormEnumSelectComponent } from "./Views/AtlasFormEnumSelectComponent";
import { AtlasFormTextInputComponent } from "./Views/AtlasFormTextInputComponent";
import { AtlasFormCheckBoxInputComponent } from "./Views/AtlasFormCheckBoxInputComponent";
import { AtlasFormDateInputComponent } from "./Views/AtlasFormDateInputComponent";
import { AtlasFormNumericInputComponent } from "./Views/AtlasFormNumericInputComponent";
import { AtlasFormButtonComponent } from "./Views/AtlasFormButtonComponent";
import { AtlasDynamicFieldDirective } from "./Views/AtlasDynamicFieldDirective";
import { AtlasDynamicFormComponent } from "./Views/AtlasDynamicFormComponent";
import { AtlasFormListDefComponent } from "./Views/AtlasFormListDefComponent";

@NgModule({
    imports: [CommonModule, ReactiveFormsModule, FwModule, DevExtremeModule],
    declarations: [AtlasDynamicFieldDirective,
        AtlasDynamicFormComponent,
        AtlasFormButtonComponent,
        AtlasFormTextInputComponent,
        AtlasFormCheckBoxInputComponent,
        AtlasFormDateInputComponent,
        AtlasFormNumericInputComponent,
        AtlasFormSelectComponent,
        AtlasFormEnumSelectComponent,
        AtlasFormListDefComponent
    ],
    exports: [AtlasDynamicFormComponent],
    entryComponents: [
        AtlasDynamicFormComponent,
        AtlasFormButtonComponent,
        AtlasFormTextInputComponent,
        AtlasFormCheckBoxInputComponent,
        AtlasFormDateInputComponent,
        AtlasFormNumericInputComponent,
        AtlasFormSelectComponent,
        AtlasFormEnumSelectComponent,
        AtlasFormListDefComponent
    ]
})
export class AtlasDynamicFormModule {
	static dynamicComponentsMap = {
		AtlasDynamicFormComponent
	};

}