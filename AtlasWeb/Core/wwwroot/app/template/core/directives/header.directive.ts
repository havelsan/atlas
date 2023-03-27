import { AfterViewInit, Directive, ElementRef, OnDestroy } from '@angular/core';

@Directive({
	selector: '[mHeader]'
})
export class HeaderDirective implements AfterViewInit, OnDestroy {
	header: any;

	constructor(private el: ElementRef) {
	}

	ngAfterViewInit(): void {
		let tmp;
		const options = {
			offset: {},
			minimize: {}
		};

		if (this.el.nativeElement.getAttribute('m-minimize-mobile') === 'hide') {
			options.minimize = {
				mobile: {
					on: 'm-header--hide',
					off: 'm-header--show'
				}
			};
		} else {
			options.minimize = {mobile: false};
		}

		const attrMinimize = this.el.nativeElement.getAttribute('m-minimize');
		if (attrMinimize === 'hide') {
			options.minimize = {
				desktop: {
					on: 'm-header--hide',
					off: 'm-header--show'
				}
			};
		} else if (attrMinimize === 'minimize') {
			options.minimize = {
				desktop: {
					on: 'm-header--minimize-on',
					off: 'm-header--minimize-off'
				},
				mobile: {
					on: 'm-header--minimize-on',
					off: 'm-header--minimize-off'
				}
			};
		} else {
			options.minimize = {desktop: false};
		}

		if ((tmp = this.el.nativeElement.getAttribute('m-minimize-offset'))) {
			options.offset = {desktop: tmp};
		}

		if ((tmp = mUtil.attr(this.el.nativeElement, 'm-minimize-mobile-offset'))) {
			options.offset = {mobile: tmp};
		}

		this.header = new mHeader(this.el.nativeElement, options);
	}

	ngOnDestroy(): void {
	}
}
