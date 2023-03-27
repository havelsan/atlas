import {
    Directive, Input, ElementRef, AfterViewInit, Renderer2
} from '@angular/core';

declare var $;

@Directive({
    // tslint:disable-next-line:directive-selector
    selector: '[ngxSummernoteView]'
})
export class NgxSummernoteViewDirective implements AfterViewInit {
    @Input() set ngxSummernoteView(content: string) {
        this._element.innerHTML = content || '';
    }

    private _element: any;

    constructor(
        private renderer: Renderer2,
        element: ElementRef
    ) {
        this._element = element.nativeElement;
    }

    ngAfterViewInit() {
        this.renderer.addClass(this._element, 'ngx-summernote-view');
    }
}
