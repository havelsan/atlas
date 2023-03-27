//$765FEB00

import * as TTVisual from "NebulaClient/Visual/TTVisualControlInterfaces";
import { Component, OnInit } from '@angular/core';
import { TTUnboundForm } from 'NebulaClient/Visual/TTUnboundForm';
import { SUTRuleViolateMessage, SUTRuleResult } from "./ProcedureRequestViewModel";
import { ModalInfo, ModalStateService } from 'Fw/Models/ModalInfo';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';




@Component({
    selector: 'sutrulecheckresultsform',
    templateUrl: './SUTRuleCheckResultsForm.html',
})
export class SUTRuleCheckResultsForm extends TTUnboundForm implements OnInit {

    SUTRuleViolateMessages: Array<SUTRuleViolateMessage>;
    BlockRequest: boolean;
    ProcedureCode: TTVisual.ITTTextBoxColumn;
    MessageDesc: TTVisual.ITTTextBoxColumn;

    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public setInputParam(value: SUTRuleResult) {
        this.SUTRuleViolateMessages = value.SUTRuleViolateMessages;
        this.BlockRequest = value.BlockRequest;
    }

    public MessageListColumns = [
        {
            "caption": i18n("M16860", "İşlem Tarihi"),
            dataField: "ProcedureDate",
            width: 80,
            allowSorting: true
        },
        {
            "caption": i18n("M16860", "İşlem Kodu"),
            dataField: "ProcedureCode",
            width: 80,
            allowSorting: true
        },
        {
            "caption": i18n("M18910", "Mesaj Açıklama"),
            dataField: "Message",
            width: 200,
            allowSorting: true
        }
    ];

    constructor(private modalStateService: ModalStateService) {
        super("", "");
    }

    ngOnInit(): void {
    }

    public btnIgnoreSUTRule_Click(): void {
        this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, {});
    }


    public btnCancel_Click(): void {
        this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, {});
    }

}