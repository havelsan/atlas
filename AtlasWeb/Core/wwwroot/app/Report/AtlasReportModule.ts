import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AtlasReportComponent } from './Views/AtlasReportComponent';
import { AtlasModalReportComponent } from './Views/AtlasModalReportComponent';
import { AtlasReportPopupComponent } from './Views/AtlasReportPopupComponent';
import { AtlasReportService } from './Services/AtlasReportService';
import { DevExtremeModule } from 'devextreme-angular';
import { FwModule } from 'Fw/FwModule';
import { AtlasDynamicFormModule } from "../DynamicForm/AtlasDynamicFormModule";
import { ModalModule } from 'Fw/ModalModule';
import { AtlasReportComponentNew } from './Views/AtlasReportComponentNew';

@NgModule({
    imports: [CommonModule, HttpModule, FormsModule, DevExtremeModule, FwModule, AtlasDynamicFormModule, ModalModule],
    declarations: [AtlasReportComponent, AtlasModalReportComponent, AtlasReportPopupComponent,AtlasReportComponentNew],
    exports: [AtlasReportComponent, AtlasReportPopupComponent, AtlasModalReportComponent,AtlasReportComponentNew],
    entryComponents: [AtlasReportComponent, AtlasModalReportComponent,AtlasReportPopupComponent,AtlasReportComponentNew],
    providers: [AtlasReportService]
})
export class AtlasReportModule {
	static dynamicComponentsMap = {
		AtlasReportComponent, 
		AtlasReportPopupComponent, 
        AtlasModalReportComponent,
        AtlasReportComponentNew
	};


}