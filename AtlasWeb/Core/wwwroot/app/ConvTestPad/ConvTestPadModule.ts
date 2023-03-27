import { NgModule, ModuleWithProviders } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { FwModule } from 'Fw/FwModule';
import { HttpModule } from '@angular/http';
import { DevExtremeModule } from 'devextreme-angular';
import { ConvTestView } from './Views/ConvTestView';

const routes: Routes = [
    {
        path: '',
        component: ConvTestView,
    },
];

@NgModule({
    declarations: [ConvTestView],
	imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule,
		RouterModule.forChild(routes)],
    exports: [ConvTestView],
    entryComponents: [ConvTestView],
    providers: []
})
export class ConvTestPadModule {
	static dynamicComponentsMap = {
		ConvTestView
	};

    static forRoot(): ModuleWithProviders<ConvTestPadModule> {
        return {
            ngModule: ConvTestPadModule
        };
    }
}