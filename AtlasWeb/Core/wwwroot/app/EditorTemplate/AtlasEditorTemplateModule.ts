import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { AtlasEditorTemplate } from './Views/AtlasEditorTemplate';
import { AtlasEditorTemplateList } from './Views/AtlasEditorTemplateList';
import { IEditorTemplateService } from './Services/IEditorTemplateService';
import { AtlasEditorTemplateService } from './Services/AtlasEditorTemplateService';
import { AtlasDynamicFormModule } from '../DynamicForm/AtlasDynamicFormModule';
import { ModalModule } from 'Fw/ModalModule';

@NgModule({
    imports: [CommonModule, FormsModule, DevExtremeModule, ModalModule, AtlasDynamicFormModule],
    declarations: [AtlasEditorTemplate, AtlasEditorTemplateList],
    exports: [AtlasEditorTemplate, AtlasEditorTemplateList],
    entryComponents: [AtlasEditorTemplate, AtlasEditorTemplateList],
    providers: [{ provide: IEditorTemplateService, useClass: AtlasEditorTemplateService }]
})
export class AtlasEditorTemplateModule {
	static dynamicComponentsMap = {
		AtlasEditorTemplate, 
		AtlasEditorTemplateList
	};

}