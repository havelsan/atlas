import { Component, NgZone, Input } from '@angular/core';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { ITTEnumComboBox } from 'NebulaClient/Visual/ControlInterfaces/ITTEnumComboBox';
import { MessageService } from 'Fw/Services/MessageService';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { vmNuclearMedicine } from "./NuclearMedicineToDoctorFormViewModel";
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { InfoBox } from "NebulaClient/Visual/InfoBox";
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ActiveIDsModel } from 'Fw/Models/ParameterDefinitionModel';

@Component({
    selector: 'NuclearMedicineResultsQueryForm',
    templateUrl: './NuclearMedicineResultsQueryForm.html',
    providers: [MessageService]
})

export class NuclearMedicineResultsQueryForm {

    private _episodeObjectID: Guid;
    @Input() set EpisodeObjectID(value: Guid) {
        if (value != undefined && value != null) {
            this._episodeObjectID = value;
            this.loadLastMonthResults();
        }
    }
    get EpisodeObjectID(): Guid {
        return this._episodeObjectID;
    }

    public PatientObjectID: Guid;

    cmbDateInterval: ITTEnumComboBox = <ITTEnumComboBox>{
        Visible: true,
        ReadOnly: false,
        DataTypeName: 'MontlyDateIntervalEnum',
        ShowClearButton: true,
    };
    MonthlyTimeInterval: string;
    public NuclearMedicineResultsColumns = [
        {
            "caption": i18n("M16694", "İstem Tarihi"),
            dataField: "RequestDate",
            width: 100,
            allowSorting: true,
            fixed: true,
            dataType: 'date',
            format: 'dd/MM/yyyy'
        },
        {
            "caption": i18n("M16722", "İsteyen Klinik"),
            dataField: "FromResourceName",
            width: 225,
            allowSorting: true
        },
        {
            "caption": i18n("M16860", "İşlem Kodu"),
            dataField: "ProcedureCode",
            width: 80,
            allowSorting: true,
            fixed: true
        },
        {
            "caption": i18n("M16821", "İşlem Adı"),
            dataField: "ProcedureName",
            width: 250,
            allowSorting: true,
            fixed: true
        },
        {
            "caption": i18n("M16837", "İşlem Durum"),
            dataField: "ActionStatus",
            width: 100,
            allowSorting: true,
            fixed: true
        },
        {
            "caption": i18n("M22078", "Sonuç"),
            dataField: "ProcedureResultLink",
            width: 60,
            allowSorting: true,
            cellTemplate: "linkCellTemplateResult",
            fixed: true
        },
        {
            "caption": "Rapor",
            dataField: "ProcedureReportLink",
            width: 60,
            allowSorting: true,
            cellTemplate: "linkCellTemplateReport",
            fixed: true
        },
        {
            "caption": i18n("M16695", "İstem Uygulayan"),
            dataField: "ProcedureResUser",
            width: 150,
            allowSorting: true
        },
        {
            "caption": i18n("M16461", "İmaj Erişim No"),
            dataField: "AccessionNo",
            allowSorting: true
        }

    ];
    PatientAllNuclearMedicineTests: Array<vmNuclearMedicine> = new Array<vmNuclearMedicine>();

    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private objectContextService: ObjectContextService,
        protected activeUserService: IActiveUserService,
        protected ngZone: NgZone,
        private reportService: AtlasReportService) {

    }

    setInputParam(value: ActiveIDsModel) {
        if (value != null) {
            this.EpisodeObjectID = value.episodeId;
            //this._episodeObjectID = value.episodeId;
            //this.loadLastMonthResults();
        }
    }

    loadLastMonthResults() {
        //Ilk acilista son 1 ayda tamamlanmis Radyoloji sonuclari yukleniyor.
        this.MonthlyTimeInterval = "1";
        this.cmdNuclearMedicineResults_Click();
    }

    public cmdNuclearMedicineResults_Click(): void {

        if (this.MonthlyTimeInterval !== undefined && this.MonthlyTimeInterval !== null) {
            this.objectContextService.getObject<Episode>(this.EpisodeObjectID, Episode.ObjectDefID).then(episode => {

                this.PatientAllNuclearMedicineTests = new Array<vmNuclearMedicine>();

                let apiUrl: string = 'api/NuclearMedicineService/GetPatientAllNuclearMedicineTests?PatientObjectId=' + episode.Patient.toString() + '&TimeInterval=' + this.MonthlyTimeInterval.toString();
                this.httpService.get<Array<vmNuclearMedicine>>(apiUrl).then(result => {
                    if (result != null) {
                        for (let nucMedTest of result) {
                            let vmNucMedTest: vmNuclearMedicine = new vmNuclearMedicine();
                            vmNucMedTest.ActionObjectId = nucMedTest.ActionObjectId;
                            vmNucMedTest.ActionStatus = nucMedTest.ActionStatus;
                            vmNucMedTest.ProcedureCode = nucMedTest.ProcedureCode;
                            vmNucMedTest.ProcedureName = nucMedTest.ProcedureName;
                            vmNucMedTest.RequestDate = nucMedTest.RequestDate;
                            vmNucMedTest.RequestedByResUser = nucMedTest.RequestedByResUser;
                            vmNucMedTest.ProcedureResUser = nucMedTest.ProcedureResUser;
                            vmNucMedTest.ProcedureReportLink = nucMedTest.ProcedureReportLink;
                            vmNucMedTest.ProcedureResultLink = nucMedTest.ProcedureResultLink;
                            vmNucMedTest.isReportShown = nucMedTest.isReportShown;
                            vmNucMedTest.isResultShown = nucMedTest.isResultShown;
                            vmNucMedTest.AccessionNo = nucMedTest.AccessionNo;
                            vmNucMedTest.FromResourceName = nucMedTest.FromResourceName;
                            this.PatientAllNuclearMedicineTests.push(vmNucMedTest);
                        }
                    }
                });

            });
        }
        else
            InfoBox.Alert(i18n("M30807", "Geçmiş tarih aralığı seçmelisiniz!"));
    }

    async selectReport(row) {
        this.openNuclearMedicineReport(row.data.ActionObjectId);
    }

    async selectResultView(row) {
        this.openInNewTab(row.displayValue);
    }

    async openNuclearMedicineReport(ActionObjectId: Guid) {
        let that = this;

        const objectIdParam = new GuidParam(ActionObjectId);
        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
        this.reportService.showReport('NuclearMedicineResultReport', reportParameters);


    }

    openInNewTab(url) {
        if (url == null) {
            InfoBox.Alert(i18n("M12080", "Bu hizmetin sonucu bulunamadı!"));
        } else {
            let win = window.open(url, '_blank');
            win.focus();
        }
    }
}