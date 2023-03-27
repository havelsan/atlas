import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { FwModule } from 'Fw/FwModule';
import { DevExtremeModule } from 'devextreme-angular';
import { QueryListComponent } from './Views/query-list.component';
import { NqlQueryService } from './Services/nql-query.service';

const routesQueryListModule: Routes = [
    {
        path: 'q',
        component: QueryListComponent
    },
];

@NgModule({
    imports: [CommonModule, FormsModule, DevExtremeModule, FwModule,
        RouterModule.forChild(routesQueryListModule)],
    declarations: [QueryListComponent],
    exports: [QueryListComponent],
    entryComponents: [QueryListComponent],
    providers: [NqlQueryService]
})
export class QueryListModule { 
	static dynamicComponentsMap = {
		QueryListComponent
	};
}
