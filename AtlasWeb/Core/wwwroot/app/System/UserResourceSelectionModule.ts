import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { FwModule } from 'Fw/FwModule';
import { UserResourceSelectionView } from './Views/UserResourceSelectionView';
import { DevExtremeModule } from 'devextreme-angular';

@NgModule({
    declarations: [UserResourceSelectionView],
    imports: [CommonModule, FormsModule, DevExtremeModule, FwModule],
    exports: [UserResourceSelectionView],
    entryComponents: [UserResourceSelectionView]
})
export class UserResourceSelectionModule {
	static dynamicComponentsMap = {
		UserResourceSelectionView
	};

}