//$2E162944
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { DevExtremeModule } from 'devextreme-angular';
import { HttpModule } from '@angular/http';
import { FwModule } from 'Fw/FwModule';
import { EpisodeActionDisplayForm } from "./EpisodeActionDisplayForm";


@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpModule,
     DevExtremeModule, FwModule],
    declarations: [EpisodeActionDisplayForm],
    exports: [EpisodeActionDisplayForm],
    entryComponents: [EpisodeActionDisplayForm]
})
export class EpisodeActionDisplayFormModule {
	static dynamicComponentsMap = {
		EpisodeActionDisplayForm
	};

}

