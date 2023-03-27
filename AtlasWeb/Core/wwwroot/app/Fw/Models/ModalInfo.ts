import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Injectable } from '@angular/core';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { Subject } from 'rxjs';
import { Observable } from 'rxjs';
import DevExpress from 'devextreme/bundles/dx.all';

export interface IModal {
    setInputParam(value: Object);
    setModalInfo(value: ModalInfo);
}
export class ModalInfo {
    public Title: string;
    public Width: number | string;
    public Height: number | string;
    public fullScreen: boolean;
    public ContainerItemID: Guid;
    public IsShowCloseButton: boolean = true;
    public DonotClosOnActionExecute: boolean = false;
    public AllowMultiple: boolean = false;
    public Position?: DevExpress.positionConfig;
    public Shading?: boolean;
    public CancelEscape: boolean = false;
}

export class ModalActionResult {
    public Result: DialogResult;
    public Param: Object;
    public ContainerItemID: Guid;
    public showPopup: boolean;
    public donotClosOnActionExecute: boolean;

    constructor(result: DialogResult, containerItemID: Guid, resultParam?: Object, showPopup: boolean = null, donotClosOnActionExecute: boolean = null) {
        this.Result = result;
        this.Param = resultParam;
        this.ContainerItemID = containerItemID;
        this.showPopup = showPopup;
        this.donotClosOnActionExecute = donotClosOnActionExecute;
    }
}

@Injectable()
export class ModalStateService {
    private actionExecuteSource: Subject<ModalActionResult> = new Subject<ModalActionResult>();
    public actionExecuted: Observable<ModalActionResult> = this.actionExecuteSource.asObservable();

    public callActionExecuted(result: DialogResult, containerItemID: Guid, param: any, showPopup: boolean = null, donotClosOnActionExecute: boolean = null) {
        let actionResult: ModalActionResult = new ModalActionResult(result, containerItemID, param, showPopup, donotClosOnActionExecute);
        this.actionExecuteSource.next(actionResult);
    }
}
