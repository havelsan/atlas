import { Component, Input } from "@angular/core";
import { NeHttpService } from "../Services/NeHttpService";
import { ENabizButtonResponseModel } from "./HvlApp";
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { MessageService } from "../Services/MessageService";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
@Component({
    selector: "e-nabiz-button",
    template: `<img src="/Content/icons/e-Nabiz.png" class="media-object" style="height:32px;display:inline-block;margin-bottom:2px" title="Hastanın sağlık geçmişini görüntülemek için tıklayınız." (click)="showPatientENabizInfo()" id="A24043" />`,
})
export class ENabizButon {


    constructor(private httpService: NeHttpService,
        protected messageService2: MessageService,
    ) {

    }

    private _episodeActionId: Guid;
    @Input() set episodeActionId(value: Guid) {
        this._episodeActionId = value;
    }
    get episodeActionId(): Guid {
        return this._episodeActionId;
    }

    private _patientId: Guid;
    @Input() set patientId(value: Guid) {
        this._patientId = value;
    }
    get patientId(): Guid {
        return this._patientId;
    }

    private _subactionProcedureID: Guid;
    @Input() set subactionProcedureID(value: Guid) {
        this._subactionProcedureID = value;
    }
    get subactionProcedureID(): Guid {
        return this._subactionProcedureID;
    }

    public showPatientENabizInfo() {
        this.setPatientHistoryShown(this.episodeActionId);

        this.showPatientENabizInfoByParameter(this.episodeActionId, this.patientId);
    }

    private showPatientENabizInfoByParameter(episodeActionId: Guid, patientId: Guid) {
        let that = this;
        let apiUrl: string = '/api/PatientExaminationService/ShowPatientENabizInfo?episodeActionObjectID=' + this.episodeActionId + '&patientObjectID=' + this.patientId + '&subactionProcedureID=' + this.subactionProcedureID;


        that.httpService.get<ENabizButtonResponseModel>(apiUrl)
            .then(response => {
                let result: ENabizButtonResponseModel = response as ENabizButtonResponseModel;
                if (result.isResponseSuccess == true) {
                    let nabizURL = "http://xxxxxx.com/DoktorErisim/home?Token=" + result.responseLink;
                    let win = window.open(nabizURL, '_blank');
                    win.focus();
                } else {
                    TTVisual.InfoBox.Alert(result.responseMessage);
                }
            })
            .catch(error => {
                this.messageService2.showError(error);
            });
    }

    private setPatientHistoryShown(episodeActionId: Guid) {
        let that = this;
        that.httpService.get<any>("api/PatientHistoryService/SetPatientHistoryShown?episodeActionId=" + episodeActionId)
            .then(response => {
            })
            .catch(error => {
            });
    }
}