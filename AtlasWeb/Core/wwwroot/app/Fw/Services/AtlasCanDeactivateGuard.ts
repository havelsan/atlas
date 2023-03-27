import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { Observable } from 'rxjs';

export interface CanComponentDeactivate {
    canDeactivate: () => Observable<boolean> | Promise<boolean> | boolean;
}


@Injectable()
export class AtlasCanDeactivateGuard implements CanDeactivate<CanComponentDeactivate> {
    canDeactivate(component: CanComponentDeactivate) {
        if (!component)
            return true;
        if (component.canDeactivate) {
            return component.canDeactivate();
        }
        return true;
    }
}