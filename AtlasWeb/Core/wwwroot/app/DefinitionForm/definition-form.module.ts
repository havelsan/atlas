import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { FwModule } from 'Fw/FwModule';
import { DevExtremeModule } from 'devextreme-angular';
import { DefinitionFormComponent } from './Views/definition-form.component';
import { ImportDefinitionComponent } from "./Views/import-definition.component";

const routesFormEditorModule: Routes = [
    {
        path: 'def',
        component: DefinitionFormComponent
    }
];

@NgModule({
    imports: [CommonModule, FormsModule, DevExtremeModule, FwModule,
        RouterModule.forChild(routesFormEditorModule)],
    declarations: [DefinitionFormComponent, ImportDefinitionComponent],
    exports: [DefinitionFormComponent, ImportDefinitionComponent, RouterModule],
    entryComponents: [DefinitionFormComponent, ImportDefinitionComponent],
    providers: [{ provide: 'ImportDefinitionComponent', useValue: ImportDefinitionComponent }]
})
export class DefinitionFormModule {
	static dynamicComponentsMap = {
		DefinitionFormComponent, 
		ImportDefinitionComponent, 
		RouterModule
	};


    static forRoot(): ModuleWithProviders<DefinitionFormModule> {
        return {
            ngModule: DefinitionFormModule,
            providers: [
                { provide: 'ImportDefinitionComponent', useValue: ImportDefinitionComponent },
            ]
        };
    }

}
