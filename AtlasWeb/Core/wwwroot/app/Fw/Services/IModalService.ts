import { Injector, ViewContainerRef, EventEmitter } from '@angular/core';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { ModalInfo } from 'Fw/Models/ModalInfo';
import { ModalActionResult } from 'Fw/Models/ModalInfo';

export abstract class IModalService {
    abstract registerViewContainerRef(vcRef: ViewContainerRef): void;
    abstract registerInjector(injector: Injector): void;
    abstract create(dynCompInfo: DynamicComponentInfo, modalInfo: ModalInfo): Promise<ModalActionResult>;
    abstract OnCloseAllPopups : EventEmitter<any>;
    abstract closeAllPopups(): void;
}
