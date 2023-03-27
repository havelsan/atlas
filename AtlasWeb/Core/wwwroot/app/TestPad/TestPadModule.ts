import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { FwModule } from 'Fw/FwModule';
import { DevExtremeModule } from 'devextreme-angular';
import { ESignatureModule } from '../ESignature/esignature.module';
import { DeveloperTestPadComponent } from './Views/developer-testpad-component';
import { ExternalWebMethodComponent } from './Views/external-web-method.component';
import { SerializeTestComponent } from './Views/serialize-test.component';
import { ActivePatientServiceTestComponent } from './Views/active-patient-service-test.component';
import { ActiveUserServiceTestComponent } from './Views/active-user-service-test.component';
import { DynamicComponentTestComponent } from './Views/dynamic-component-test.component';
import { TemplateEditorTestComponent } from './Views/template-editor-test.component';
import { StatePanelTestComponent } from './Views/state-panel-test.component';
import { ShowMessageTestComponent } from './Views/show-message-test.component';
import { JsonTestComponent } from './Views/json-test.component';
import { TreatmentMaterialTestComponent } from './Views/treatment-material-test.component';
import { QueryListTestComponent } from './Views/query-list-test.component';
import { QueryListParamTestComponent } from './Views/query-list-param-test.component';
import { FormEditorModule } from '../FormEditor/form-editor.module';
import { QueryListModule } from '../QueryList/query-list.module';
import { FormEditorTestComponent } from './Views/form-editor-test.component';
import { ReadOnlyFormTestComponent } from './Views/read-only-form-test.component';
import { ESignatureTestComponent } from './Views/esignature-test.component';
import { ReportTestPadComponent } from './Views/report-test-pad.component';
import { ControlTestComponent } from './Views/control-test.component';
import { AtlasReportModule } from '../Report/AtlasReportModule';
import { MemoryLeakTestComponent } from './Views/memory-leak-test.component';
import { AtlasAutoCompleteGridTestComponent } from './Views/atlas-autocompletegrid-test.component';
import { AtlasMessageTestComponent } from './Views/atlas-message-test.component';
import { DefinitionTestComponent } from "./Views/definition-test.component";
import { HizmetTestComponent } from 'app/TestPad/Views/hizmet-test.component';
import { PatientBannerComponent } from 'app/TestPad/Views/patient-banner.component';

import { DefinitionFormModule } from 'app/DefinitionForm/definition-form.module';
import { PagingTestComponent } from './Views/paging-test.component';

import { DynamicFormTestComponent } from './Views/dynamic-form-test.component';
import { AtlasDynamicFormModule } from 'app/DynamicForm/AtlasDynamicFormModule';
import { DynamicFormModule } from 'app/DynamicFormDesigner/DynamicFormModule';

const developerModuleRoutes: Routes = [
    {
        path: '',
        component: DeveloperTestPadComponent,
        children: [
            { path: 'externalweb', component: ExternalWebMethodComponent },
            { path: 'serialize', component: SerializeTestComponent },
            { path: 'activepatientservice', component: ActivePatientServiceTestComponent },
            { path: 'activeuserservice', component: ActiveUserServiceTestComponent },
            { path: 'dynamiccomp', component: DynamicComponentTestComponent },
            { path: 'templateeditor', component: TemplateEditorTestComponent },
            { path: 'statepanel', component: StatePanelTestComponent },
            { path: 'showmessage', component: ShowMessageTestComponent },
            { path: 'jsonresult', component: JsonTestComponent },
            { path: 'formeditor', component: FormEditorTestComponent },
            { path: 'querylist', component: QueryListTestComponent },
            { path: 'querylistparam', component: QueryListParamTestComponent },
            { path: 'treatmentmaterial', component: TreatmentMaterialTestComponent },
            { path: 'readonlyform', component: ReadOnlyFormTestComponent },
            { path: 'esign', component: ESignatureTestComponent },
            { path: 'reporttest', component: ReportTestPadComponent },
            { path: 'controltest', component: ControlTestComponent },
            { path: 'memleaktest', component: MemoryLeakTestComponent },
            { path: 'dropdowntest', component: AtlasAutoCompleteGridTestComponent },
            { path: 'messagetest', component: AtlasMessageTestComponent },
            { path: 'definitiontest', component: DefinitionTestComponent },
            { path: 'definitionform', loadChildren: 'AppModules/DefinitionForm/definition-form.module#DefinitionFormModule' },
            { path: 'hizmettest', component: HizmetTestComponent },
            
            { path: 'pagingtest', component: PagingTestComponent },
            { path: 'dynamicform', component: DynamicFormTestComponent },

        ]
    },
];

@NgModule({
    declarations: [
        DeveloperTestPadComponent, ExternalWebMethodComponent
        , SerializeTestComponent, ActivePatientServiceTestComponent
        , ActiveUserServiceTestComponent, DynamicComponentTestComponent
        , TemplateEditorTestComponent, StatePanelTestComponent
        , ShowMessageTestComponent, JsonTestComponent, TreatmentMaterialTestComponent
        , QueryListTestComponent, QueryListParamTestComponent
        , FormEditorTestComponent, ReadOnlyFormTestComponent, ESignatureTestComponent
        , ReportTestPadComponent, ControlTestComponent
        , MemoryLeakTestComponent, AtlasAutoCompleteGridTestComponent
        , AtlasMessageTestComponent, DynamicFormTestComponent
        , DefinitionTestComponent, HizmetTestComponent, PatientBannerComponent, 
        PagingTestComponent
    ],
    imports: [CommonModule, HttpClientModule, FormsModule, ReactiveFormsModule, DevExtremeModule, FwModule, ESignatureModule
        , QueryListModule, FormEditorModule, AtlasReportModule, AtlasDynamicFormModule, DefinitionFormModule
        , DynamicFormModule
        , RouterModule.forChild(developerModuleRoutes)
    ],
    exports: [RouterModule],
    providers: []
})
export class TestPadModule {
	static dynamicComponentsMap = {
		RouterModule
	};

}
