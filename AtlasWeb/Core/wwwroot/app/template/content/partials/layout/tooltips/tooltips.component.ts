import { Component, OnInit, HostBinding, ChangeDetectionStrategy, HostListener, ElementRef, EventEmitter, Directive } from '@angular/core';
import { IFavoriteService } from 'app/Favorites/IFavoriteService';
import { FavoriteItem } from 'app/Favorites/FavoriteItem';
import { Observable } from 'rxjs';
import { ClickFunctionParams } from 'app/Fw/Models/ParameterDefinitionModel';

@Component({
	selector: 'm-tooltips',
	templateUrl: './tooltips.component.html',

})
export class TooltipsComponent implements OnInit {

	@HostBinding('class') classes = '';
	@HostBinding('style.margin-top') marginTop = '30px';

	constructor(public favoriteService: IFavoriteService
	) {

		this.setStyles();
		this.favoriteService.onUpdateEvent.subscribe(x => {
			this.setStyles();
		});
	}

	setStyles() {

		if (this.favoriteService.items.length > 0) {
			this.classes = 'm-nav-sticky';
		} else {
			this.classes = '';
		}
	}

	click(item: FavoriteItem) {

		if (item.sidebarMenuItem) {
			if (item.sidebarMenuItem.getParamsFunction && item.sidebarMenuItem.parameterFunctionInstance) {
				let boundedParamFunction = item.sidebarMenuItem.getParamsFunction.bind(item.sidebarMenuItem.parameterFunctionInstance);
				let params: ClickFunctionParams = { Params: boundedParamFunction(item.sidebarMenuItem.getParamsFunction).Params, ParentInstance: item.sidebarMenuItem.ParentInstance };

				let boundedFunction =  item.sidebarMenuItem.clickFunction.bind(item.sidebarMenuItem.componentInstance);
				boundedFunction(params);
			} else {

				let boundedFunction = item.sidebarMenuItem.clickFunction.bind(item.sidebarMenuItem.componentInstance);
				boundedFunction();
			}
		}
	}

	ngOnInit(): void { }
}
