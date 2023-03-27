import {Injectable} from '@angular/core';
import {NavigationService} from './NavigationService';
import {NotificationService} from './NotificationService';
import {GlobalsService} from './GlobalsService';

@Injectable()
export class ServiceContainer {

    constructor(public Navigator: NavigationService, public Notifier: NotificationService, public Globals: GlobalsService) {

    }

}