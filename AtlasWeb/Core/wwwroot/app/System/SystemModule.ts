import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FwModule } from 'Fw/FwModule';
import { MainPageView } from './Views/MainPageView';
import { DevExtremeModule } from 'devextreme-angular';
import { SettingsView } from 'app/System/Views/SettingsView';

const routes: Routes = [
    { path: '', component: MainPageView }
];


@NgModule({
    declarations: [MainPageView, SettingsView],
    imports: [CommonModule, FormsModule, DevExtremeModule, FwModule, RouterModule.forChild(routes)],
    //providers: [AuthenticationService],
    exports: [MainPageView,SettingsView],
    entryComponents: [MainPageView, SettingsView]
})
export class SystemModule {
	static dynamicComponentsMap = {
        MainPageView,
        SettingsView
	};

}