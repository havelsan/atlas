import { Directive, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[dyn-host]',
})
export class DynamicComponentHostDirective {
  constructor(public viewContainerRef: ViewContainerRef) { }
}

