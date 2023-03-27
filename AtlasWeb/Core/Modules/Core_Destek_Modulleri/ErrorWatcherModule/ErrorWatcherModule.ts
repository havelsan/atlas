import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { ErrorWatcherForm } from './ErrorWatcherForm';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
        path: '',
        component: ErrorWatcherForm
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule, DevExtremeModule, FwModule, RouterModule.forChild(routes)],
    declarations: [
        ErrorWatcherForm
    ],
    exports: [
        ErrorWatcherForm
    ],
    entryComponents: [
        ErrorWatcherForm
    ]
})
export class ErrorWatcherModule {
	static dynamicComponentsMap = {
		ErrorWatcherForm
	};

}

