import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';
import { MenuConfig } from '../../config/menu';

@Injectable()
export class MenuConfigService {
	public configModel: MenuConfig = new MenuConfig();
	public onMenuUpdated$: BehaviorSubject<MenuConfig> = new BehaviorSubject(
		this.configModel
	);
	menuHasChanged: any = false;

	constructor(private router: Router) {

	}

	setModel(menuModel: MenuConfig) {
		this.configModel = Object.assign(this.configModel, menuModel);
		this.onMenuUpdated$.next(this.configModel);
		this.menuHasChanged = true;
	}

	resetModel() {
		this.configModel = new MenuConfig();
		this.onMenuUpdated$.next(this.configModel);
		this.menuHasChanged = false;
	}
}
