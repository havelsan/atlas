import { HostListener, Directive, ElementRef, Input, AfterViewInit, OnChanges, SimpleChanges } from '@angular/core';
@Directive({ selector: '[fill-height]' })

export class FillHeightDirective implements AfterViewInit, OnChanges {

	@Input() triggerResize: Date;
	@Input() elementOffsetTopTrim: number;

	@Input() footerElement = null;
	constructor(private el: ElementRef) {
	}

	ngAfterViewInit(): void {
		this.calculateAndSetElementHeight();
	}

	@HostListener('window:resize', ['$event'])
	onResize(event) {
		this.calculateAndSetElementHeight();
	}

	private calculateAndSetElementHeight() {
		this.el.nativeElement.style.overflow = 'auto';
		const windowHeight = window.innerHeight;
		const elementOffsetTop = this.getElementOffsetTop();
		const elementMarginBottom = this.el.nativeElement.style.marginBottom;
		const footerElementMargin = this.getfooterElementMargin();

		this.el.nativeElement.style.height = windowHeight - footerElementMargin - elementOffsetTop + 'px';
		console.log([windowHeight, elementOffsetTop, elementMarginBottom, footerElementMargin, this.el.nativeElement.style.height]);
	}

	private getElementOffsetTop() {
		return this.el.nativeElement.getBoundingClientRect().top - this.elementOffsetTopTrim;
	}

	private getfooterElementMargin() {
		if (!this.footerElement) { return 0; }
		const footerStyle = window.getComputedStyle(this.footerElement);
		return parseInt(footerStyle.height, 10);
	}

	ngOnChanges(changes: SimpleChanges) {
		if ( changes['triggerResize'] ) {
			console.log(changes['triggerResize']);
			this.calculateAndSetElementHeight();
			this.triggerResize = undefined;
		}
	}
}
