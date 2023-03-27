import { AfterViewInit, ChangeDetectionStrategy, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { HeaderService } from '../../../core/services/layout/header.service';
import {
	Router
} from '@angular/router';
import { LayoutRefService } from '../../../core/services/layout/layout-ref.service';
//import { LoadingBarService } from '@ngx-loading-bar/core';

@Component({
	selector: 'm-header',
	templateUrl: './header.component.html',
	changeDetection: ChangeDetectionStrategy.OnPush
})
export class HeaderComponent implements OnInit, AfterViewInit {

	@ViewChild('mHeader') mHeader: ElementRef;

	constructor(
		private router: Router,
		private layoutRefService: LayoutRefService,
		public headerService: HeaderService
	) {
		 
	}

	ngOnInit(): void {
	}

	ngAfterViewInit(): void {
		// keep header element in the service
		this.layoutRefService.addElement('header', this.mHeader.nativeElement);
	}
}
