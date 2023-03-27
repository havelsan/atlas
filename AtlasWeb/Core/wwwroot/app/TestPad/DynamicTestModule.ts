import { NgModule } from '@angular/core';
import { DynamicTestComponent } from './Views/DynamicTestComponent';

@NgModule({
    declarations: [DynamicTestComponent],
    entryComponents: [DynamicTestComponent]
})
export class DynamicTestModule {
	static dynamicComponentsMap = {

	};


}