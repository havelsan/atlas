import { NgModule, ModuleWithProviders } from '@angular/core';
import { NgxSummernoteDirective } from './ngx-summernote.directive';
import { NgxSummernoteViewDirective } from './ngx-summernote-view.directive';

@NgModule({
  declarations: [
    NgxSummernoteDirective,
    NgxSummernoteViewDirective
  ],
  exports: [
    NgxSummernoteDirective,
    NgxSummernoteViewDirective
  ],
  entryComponents: [
    ]
})
export class NgxSummernoteModule {

	static dynamicComponentsMap = {
		NgxSummernoteDirective, 
		NgxSummernoteViewDirective
	};
  public static forRoot(): ModuleWithProviders<NgxSummernoteModule> {
    return {ngModule: NgxSummernoteModule,  providers: []};
  }
}
