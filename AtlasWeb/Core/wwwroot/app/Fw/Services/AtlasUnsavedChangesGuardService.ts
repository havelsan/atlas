//$D65370DC
// Atlas auth-guard.service.ts
import { Injectable } from '@angular/core';
import { Router, CanDeactivate  } from '@angular/router';
import { TTBoundFormBase } from 'NebulaClient/Visual/TTBoundFormBase';

@Injectable()
export class AtlasUnsavedChangesGuardService implements CanDeactivate<any> {

    constructor(private router: Router) { }

    canDeactivate(component: any) {

        const isBoundForm = TTBoundFormBase.prototype.isPrototypeOf(component);

        if (isBoundForm) {
            const boundForm = component as TTBoundFormBase;
            if ( boundForm.isModified() == true) {
                return confirm(i18n("M17381", "Kaydedilmemiş değişiklikler var. Değişiklikleri kaydetMEden devam etmek istiyor musunuz?"));
            }
        }

        return true;
    }

}