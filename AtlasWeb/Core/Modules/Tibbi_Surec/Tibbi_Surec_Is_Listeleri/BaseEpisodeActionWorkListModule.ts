
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { BaseEpisodeActionWorkListForm } from './BaseEpisodeActionWorkListForm';
import { SimpleTimer } from 'ng2-simple-timer';

const routes: Routes = [
    {
        path: '',
        component: BaseEpisodeActionWorkListForm,
    },
];
@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule,
     DevExtremeModule, FwModule,
     RouterModule.forChild(routes)],
    declarations: [BaseEpisodeActionWorkListForm],
    exports: [BaseEpisodeActionWorkListForm],
    entryComponents: [BaseEpisodeActionWorkListForm],
    providers: [SimpleTimer]
})
export class BaseEpisodeActionWorkListModule {
	static dynamicComponentsMap = {
		BaseEpisodeActionWorkListForm
	};

}

