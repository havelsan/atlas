import { Component, ElementRef } from '@angular/core';
import { IModal, ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';
import { PrepareInteraction_Input, PrepareInteraction_Output, InteractionDTO } from 'Modules/Saglik_Lojistik/Eczane_Modulleri/Ilac_Direktifi_Giris_Modulu/DrugOrderGridComponentViewModel';
import { DrugDrugInteraction } from 'app/NebulaClient/Model/AtlasClientModel';


@Component({
    selector: 'drug-atlasintroduction-component',
    template: `
    <div class="row" style="margin:5px">
    <dx-scroll-view #scrollView style="height:700px">
        <div class="container-fluid" *ngIf="drugDrugVisible">
            <h3> İlaç İlaç Ektileşimleri</h3>
            <ul>
                <li *ngFor="let interaction of drugDrugInteractions; let i = index">
                    <div [ngStyle]="interaction.Color">
                        <h4>{{ interaction.Header }}</h4>
                        {{ interaction.Message }}
                    </div>
                </li>
            </ul>
        </div>
        <div class="container-fluid" *ngIf="drugFoodVisible">
            <h3>İlaç Besin Ektileşimleri</h3>
            <ul>
                <li *ngFor="let interaction of drugFoodInteractions; let i = index">
                    <div [ngStyle]="interaction.Color">
                        <h4>{{ interaction.Header }}</h4>
                        {{ interaction.Message }}
                    </div>
                </li>
            </ul>
        </div>
    </dx-scroll-view>
    <div style="float: left">
        <dx-button type="default" text="Devam" style="width:80px" (onClick)="okClick()"></dx-button>
    </div>
    <div style="float: right">
        <dx-button type="danger" text="Vazgeç" style="width:80px" (onClick)="cancelClick()"></dx-button>
    </div>
</div>
 `
})
export class DrugAtlasInteractionComponent implements IModal {
    private inputParam: PrepareInteraction_Output;
    private drugDrugInteractions: Array<InteractionDTO> = new Array<InteractionDTO>();
    private drugFoodInteractions: Array<InteractionDTO> = new Array<InteractionDTO>();
    private drugDrugVisible: boolean = false;
    private drugFoodVisible: boolean = false;
    private _modalInfo: ModalInfo;

    constructor(private modalStateService: ModalStateService) {
    }

    public setInputParam(value: any) {
        this.inputParam = value as PrepareInteraction_Output;
        if (this.inputParam.drugDrugInteractions.length > 0)
            this.drugDrugVisible = true;
        if (this.inputParam.drugFoodInteractions.length > 0)
            this.drugFoodVisible = true;
        this.inputParam.drugDrugInteractions.forEach(item => {
            let interactionItem: InteractionDTO = new InteractionDTO();
            interactionItem.Header = item.Header;
            interactionItem.Color = { color: item.Color };
            interactionItem.Message = item.Message;
            this.drugDrugInteractions.push(interactionItem);
        });
        this.inputParam.drugFoodInteractions.forEach(item => {
            let interactionItem: InteractionDTO = new InteractionDTO();
            interactionItem.Header = item.Header;
            interactionItem.Color = { color: item.Color };
            interactionItem.Message = item.Message;
            this.drugFoodInteractions.push(interactionItem);
        });
    }

    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public cancelClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

    public okClick(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, {});
    }
}