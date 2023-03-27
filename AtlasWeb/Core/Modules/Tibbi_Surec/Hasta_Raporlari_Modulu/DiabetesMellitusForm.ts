import { Component, Input } from "@angular/core";
import { MessageService } from "app/Fw/Services/MessageService";
import { ParticipationFreeDrugReportNewFormViewModel } from "./ParticipationFreeDrugReportNewFormViewModel";
import { ModalInfo, ModalStateService } from "app/Fw/Models/ModalInfo";
import { DrugReportReasonEnum } from "app/NebulaClient/Model/AtlasClientModel";
import { DialogResult } from "app/NebulaClient/Utils/Enums/DialogResult";
import { ServiceLocator } from "app/Fw/Services/ServiceLocator";

@Component({
    selector: 'diabetesMellitusForm',
    templateUrl: './DiabetesMellitusForm.html',
    providers: [MessageService]
})
export class DiabetesMellitusForm {


    private _modalInfo: ModalInfo;

    public _drugReportViewModel: ParticipationFreeDrugReportNewFormViewModel;
    public DrugReportReasonDataSource;

    public diabetTeshisArray = [
        '246',
        '247',
        '50',
        '51',
        '52',
        '53',
        '54',
        '244',
        '271',
        '226',
        '206'
    ];

    public diabetTeshis07_02_1_Array = [
        '246',
        '247',
        '50',
        '51',
        '52',
        '53',
        '54',
        '244',
        '271',
    ];


    constructor(private modalStateService: ModalStateService) {
        this.DrugReportReasonDataSource = DrugReportReasonEnum.Items;
    }

    public setInputParam(value: ParticipationFreeDrugReportNewFormViewModel) {
        this._drugReportViewModel = value;
    }
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public SaveClick() {

        let diabetTeshisList_07_02_1 = this._drugReportViewModel.TeshisList.filter(x => this.diabetTeshis07_02_1_Array.includes(x.teshisKodu))

        if (diabetTeshisList_07_02_1.length > 0) {
            if (this._drugReportViewModel._ParticipatnFreeDrugReport.Kilo == null || this._drugReportViewModel._ParticipatnFreeDrugReport.HemoglobinA1c == null || this._drugReportViewModel._ParticipatnFreeDrugReport.AclikKanSekeri == null) {
                ServiceLocator.MessageService.showError('07.02.1 - Diabetes Mellitus(E10-E14)" teşhisi ile rapor kaydında ilave değer olarak, Kilo, Hemoglobin A1c ve Açlık Kan Şekeri (mg/dl) alanlarının girilmesi zorunludur.');
                return;
            }
        }
        if (this._drugReportViewModel.TeshisList.find(x => x.teshisKodu == "206") || this._drugReportViewModel.TeshisList.find(x => x.teshisKodu == "226")) {
            if (this._drugReportViewModel.ReportReasonList == null || this._drugReportViewModel.ReportReasonList.length == 0) {
                ServiceLocator.MessageService.showError('20.01 ya da 21.01 teşhisi ile rapor kaydında ilave değer olarak Rapor Düzenleme Nedenlerinden en az birisi seçilmelidir.');
                return;
            }
            else
                this._drugReportViewModel._ParticipatnFreeDrugReport.DrugReportReason = this._drugReportViewModel.ReportReasonList.join(',');
        }

        if (this._modalInfo != null)
            this.modalStateService.callActionExecuted(DialogResult.OK, this._modalInfo.ContainerItemID, this._drugReportViewModel);
    }

    public CancelClick() {
        if (this._modalInfo != null)
            this.modalStateService.callActionExecuted(DialogResult.Cancel, this._modalInfo.ContainerItemID, this._drugReportViewModel);
    }

}