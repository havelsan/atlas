import { Directive, ElementRef, Input, AfterViewInit } from '@angular/core';

@Directive({
    /*template: '<div *ngIf="Visible" class="tab-pane fade in" id="{{Name}}">\
            <ng-content></ng-content></div>',*/
    selector: '[hvlTabPage]'
})
export class HvlTabPage implements AfterViewInit
{
    @Input() hvlTabPage: string;

    constructor(private element: ElementRef) {
    }

    ngAfterViewInit(){
        let container: HTMLDivElement = <HTMLDivElement>this.element.nativeElement;
        container.setAttribute('id', this.hvlTabPage);
    }
}