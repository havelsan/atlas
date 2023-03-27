import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { LayoutConfig } from '../../config/layout';
import { Injectable } from '@angular/core';
import { UtilsService } from './utils.service';
import { of } from 'rxjs';

@Injectable()
export class LayoutConfigStorageService {
	constructor(private utils: UtilsService) {}

	saveConfig(layoutConfig: LayoutConfig): void {
		if (layoutConfig != null) {
			// config storage
			localStorage.setItem('layoutConfig', JSON.stringify(layoutConfig));
		}
	}

	getSavedConfig(): Observable<LayoutConfig> {
      let config: any = localStorage.getItem('layoutConfig');
      if (config == null) {
        config = "{}";
      }
		try {
          return of(JSON.parse(config));
		} catch (e) {}
	}

	loadConfig(): Observable<LayoutConfig> {
		return this.getSavedConfig().pipe(
			map(config => {
				return Object.assign({}, new LayoutConfig(), config);
			})
		);
	}

	resetConfig(): void {
		localStorage.removeItem('layoutConfig');
	}
}
