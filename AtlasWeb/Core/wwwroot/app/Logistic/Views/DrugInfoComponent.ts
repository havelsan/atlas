import { Component} from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
//<hvl-richtextbox [value]="htmlContent" Height="700px"  [config]="editorConfig" FixedUI="true"></hvl-richtextbox>
@Component({
    selector: 'drug-info-component',
    template: `

    <div style="height:700px; width:100%" [innerHTML]="htmlContent | keepHtml"></div>
        <div class="col-sm-12" style="text-align:center">
            <dx-button type="btn btn-default" text="OK" style="width:60px" (onClick)="closeClick()"></dx-button>
        </div>
 `
})
export class DrugInfoComponent implements IModal {
    private htmlContent: string;
    private _modalInfo: ModalInfo;

    public editorConfig: any = {
        height: '700px',
        removePlugins: 'toolbar,elementspath',
        resize_enabled: false,
        readOnly: true
    };

    constructor(private modalStateService: ModalStateService) {
    }

    public setInputParam(value: any) {
        this.htmlContent = value as string;
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public closeClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }
}
