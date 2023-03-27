import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { ComposeComponent } from './ComposeComponent';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { ModalInfo, ModalActionResult, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { AsyncSubject } from 'rxjs';
import { DxPopupComponent } from 'devextreme-angular';
import { Subscription } from 'rxjs';
import { map, isEmpty } from 'rxjs/operators';
import DevExpress from 'devextreme/bundles/dx.all';

@Component({
    selector: 'modal-container-component',
    template: `
<dx-popup #popup showTitle="false" [position]="_modalInfo.Position" [title]="_modalInfo.Title" [showCloseButton]="_modalInfo.IsShowCloseButton"
[width]="_modalInfo.Width" [shading]="_modalInfo.Shading" [height]="_modalInfo.Height"  [(visible)]="_showPopup" (onHidden)="popupHidden()">
  <div *dxTemplate="let data of 'content'">
        <comp-compose #modalCompose [Info]="_componentInfo" [ModalInfo]="_modalInfo"
        (DynamicComponentLoadErrorOccurred)="dynamicComponentLoadErrorOccurred()"
        (DynamicComponentActionExecuted)="dynamicComponentActionExecuted($event)"
         (DynamicComponentClosed)="dynamicComponentClosed()"></comp-compose>
    </div>
</dx-popup>
`
})
export class ModalContainerComponent implements OnInit, OnDestroy {
    @ViewChild('modalCompose') composeCompRef: ComposeComponent;
    @ViewChild('popup') popupRef: DxPopupComponent;
    public _showPopup: boolean;
    public _componentInfo: DynamicComponentInfo;
    public _modalInfo: ModalInfo;
    public OnActionExecute: AsyncSubject<ModalActionResult> = new AsyncSubject<ModalActionResult>();
    private _itemID: Guid = Guid.newGuid();
    private actionExecutedSubscription: Subscription;

    constructor(private modalStateService: ModalStateService) {
        this._modalInfo = this.getModalInfo();

        let that = this;
        this.actionExecutedSubscription = this.modalStateService.actionExecuted.subscribe(item => {
            that.actionExecuted(item);
        });
    }

    private getModalInfo(): ModalInfo {

        let modalInfo = new ModalInfo();
        modalInfo.Title = 'Nebula Web';
        modalInfo.Width = 500;
        modalInfo.Height = 400;
        modalInfo.fullScreen = false;
        modalInfo.ContainerItemID = this._itemID;
        modalInfo.Position = { my: 'center', at: 'center', of: window };

        return modalInfo;
    }

    public Initialize(dynamicCompInfo: DynamicComponentInfo, modalInfo: ModalInfo) {
        this._componentInfo = dynamicCompInfo;
        if (modalInfo == null) {
            this._modalInfo = this.getModalInfo();
        } else {
            
            if (modalInfo.fullScreen == true) {
                delete modalInfo.fullScreen;
                let element = document.getElementsByClassName('m-content')[0];
                modalInfo.Width = element.clientWidth;
                modalInfo.Height = element.clientHeight;
                let positionConfig: DevExpress.positionConfig = {

                    my: "top",
                    at: "top",
                    offset: '0 60'
                }
                modalInfo.Position = positionConfig;
                modalInfo.Shading = false;
            }
            else {
                modalInfo.Position = { my: 'center', at: 'center', of: window };
            }
            this._modalInfo = modalInfo;
            
        }
        this._modalInfo.ContainerItemID = this._itemID;
    }

    public actionExecuted(actionInfo: ModalActionResult) {

        if (actionInfo.donotClosOnActionExecute == false) {
            this._modalInfo.DonotClosOnActionExecute = false;
        }
        if (this._modalInfo.DonotClosOnActionExecute === true) {
            return;
        }
        
        if (this._itemID.valueOf() === actionInfo.ContainerItemID.valueOf()) {
            if (actionInfo.showPopup == true) {
                this._showPopup = true;
                this.popupRef.visible = true;
            }
            if (actionInfo.showPopup == null) {
                this._showPopup = false;
                this.popupRef.visible = false;
            }
            
            this.OnActionExecute.next(actionInfo);
            if (actionInfo.showPopup == null)
                this.OnActionExecute.complete();
        }
    }

    ngOnInit() {
        this._showPopup = true;
    }

    ngAfterViewInit() {
        if(this._modalInfo.CancelEscape) {
            this.popupRef.instance.registerKeyHandler("escape", function (arg) {
                arg.stopPropagation();
            });
        }
    }

    ngOnDestroy() {
        if (this.actionExecutedSubscription != null) {
            this.actionExecutedSubscription.unsubscribe();
            this.actionExecutedSubscription = null;
        }
        if (this.composeCompRef != null) {
            this.composeCompRef.ngOnDestroy();
        }
    }

    popupHidden() {
        this.OnActionExecute.pipe(map(list => {
            if (list != null) {
                let actionInfo = new ModalActionResult(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
                this.OnActionExecute.next(actionInfo);
            }
        }));
        this.OnActionExecute.complete();
    }

    dynamicComponentClosed() {
        if (this._showPopup === true) {
            let actionInfo = new ModalActionResult(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
            this.actionExecuted(actionInfo);
        }
    }

    dynamicComponentLoadErrorOccurred() {
        let actionInfo = new ModalActionResult(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
        this.actionExecuted(actionInfo);
    }

    dynamicComponentActionExecuted(eventParam: any) {
        if (eventParam != null) {
            let dynamicComponentCancelled = false;
            if (eventParam.hasOwnProperty('Cancelled')) {
                dynamicComponentCancelled = eventParam['Cancelled'] as boolean;
                if (dynamicComponentCancelled === true) {
                    let actionInfo = new ModalActionResult(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
                    this.actionExecuted(actionInfo);
                }
            }

            if (eventParam.hasOwnProperty('IsSave')) {
                let dynamicComponentSaved = eventParam['IsSave'] as boolean;
                if (dynamicComponentSaved === true) {
                    let actionInfo = new ModalActionResult(DialogResult.OK, this._modalInfo.ContainerItemID, {});
                    this.actionExecuted(actionInfo);
                }
            }
        }
    }
}