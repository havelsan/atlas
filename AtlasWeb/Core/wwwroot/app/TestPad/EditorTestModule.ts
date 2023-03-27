import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FwModule } from 'Fw/FwModule';
import { DevExtremeModule } from 'devextreme-angular';
import { EditorTestComponent } from './Views/editor-test.component';
import { AtlasEditorTemplateModule } from '../EditorTemplate/AtlasEditorTemplateModule';

@NgModule({
    imports: [CommonModule, FormsModule, DevExtremeModule, FwModule, AtlasEditorTemplateModule],
    declarations: [EditorTestComponent],
    exports: [EditorTestComponent],
    entryComponents: [EditorTestComponent]
})
export class EditorTestModule { 
	static dynamicComponentsMap = {
		EditorTestComponent
	};
}