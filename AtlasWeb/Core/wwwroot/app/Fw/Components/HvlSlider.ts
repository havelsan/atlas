import {
    OnChanges, SimpleChanges, Input,
    Directive, ElementRef, AfterContentInit, Renderer2, HostListener
} from '@angular/core';

//declare var jQuery: any;

@Directive({
    selector: '[hvl-slider-panel]',
})
export class HvlSliderPanel implements AfterContentInit, OnChanges {
    IsResizing; Boolean;
    StartX: number;
    container: HTMLElement;
    Left: HTMLDivElement;
    Right: HTMLDivElement;
    @Input('hvl-slider-panel') Width: String;
    MinWidth: Number = 420;

    private handleMouseDownEvtRemoveFunc: Function;
    private handleMouseMoveEvtRemoveFunc: Function;

    constructor(private element: ElementRef, private renderer: Renderer2) {
        this.container = this.element.nativeElement;
        this.renderer.setStyle(this.container, "display", "table");
        this.renderer.setStyle(this.container, "table-layout", "fixed");
    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['Width'] && !isNaN(+this.Width) && this.Width != '') {
            this.MinWidth = +this.Width;
        }
    }

    ngAfterContentInit() {
        let that = this;
        this.Left = <HTMLDivElement>this.container.children[0];
        this.Left.style.display = "table-cell";
        this.Left.style.verticalAlign = "top";
        this.Left.style.height = "100%";
        this.Left.style.padding = "15px";

        this.Right = <HTMLDivElement>this.container.children[1];
        this.Right.style.display = "table-cell";
        this.Right.style.verticalAlign = "top";
        this.Right.style.height = "100%";
        this.Right.style.padding = "15px";

        let handle: HTMLDivElement = document.createElement("div");
        handle.classList.add('slider-panel-drag');
        handle.style.verticalAlign = "top";
        handle.style.height = "100%";
        handle.style.display = "table-cell";
        this.handleMouseDownEvtRemoveFunc = this.renderer.listen(handle, 'mousedown', (event) => {
            that.IsResizing = true;
            that.container.classList.add('slider-panel-container');
            that.StartX = event.clientX;
        });

        this.container.insertBefore(handle, this.Right);

        this.handleMouseMoveEvtRemoveFunc = this.renderer.listen(this.container, 'mousemove', (event) => {
            if (!that.IsResizing) {
                return;
            }
            let offsetRight: number = that.container.clientWidth - (event.clientX - that.container.getBoundingClientRect().left);
            let rightWidth = (offsetRight - 10);
            let leftWidth = (that.container.clientWidth - offsetRight - 10);
            let draggingToRight = this.StartX < event.clientX;

            if (
                (draggingToRight && rightWidth <= this.MinWidth) ||
                (!draggingToRight && leftWidth <= this.MinWidth)
            ) {
                that.cleanup(null);
            }
            that.Right.style.width = rightWidth.toString() + "px";
            that.Left.style.width = leftWidth.toString() + "px";

        });
    }

    ngOnDestroy() {
        if ( this.handleMouseDownEvtRemoveFunc != null ) {
            this.handleMouseDownEvtRemoveFunc();
            this.handleMouseDownEvtRemoveFunc = null;
        }
        if ( this.handleMouseMoveEvtRemoveFunc != null ) {
            this.handleMouseMoveEvtRemoveFunc();
            this.handleMouseMoveEvtRemoveFunc = null;
        }
    }

    @HostListener('document:mouseup', ['$event'])
    cleanup(event: any) {
        this.IsResizing = false;
        this.renderer.removeClass(this.container, 'slider-panel-container');
    }
}