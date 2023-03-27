import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LoginView } from './Views/LoginView';
import { ChangePasswordView } from './Views/ChangePasswordView';
import { DevExtremeModule } from 'devextreme-angular';

const routes: Routes = [
    {
        path: 'giris',
        component: LoginView,
    },
    { path: 'sifredegistir', component: ChangePasswordView },
];


@NgModule({
    declarations: [LoginView, ChangePasswordView],
    imports: [
        CommonModule,
        FormsModule,
        DevExtremeModule,
        //FwModule,
        RouterModule.forChild(routes)
    ],
    exports: [LoginView, ChangePasswordView],
    entryComponents: [LoginView, ChangePasswordView]
})
export class LoginModule {
	static dynamicComponentsMap = {
		LoginView, 
		ChangePasswordView
	};

}