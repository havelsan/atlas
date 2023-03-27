import { Component, NgZone, Input } from '@angular/core';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { ITTEnumComboBox } from 'NebulaClient/Visual/ControlInterfaces/ITTEnumComboBox';
import { MessageService } from 'Fw/Services/MessageService';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { vmPatientRadiologyTest } from "./RadiologyTestResultEntryFormViewModel";
import { ObjectContextService } from 'Fw/Services/ObjectContextService';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { InfoBox } from "NebulaClient/Visual/InfoBox";
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { Episode } from 'NebulaClient/Model/AtlasClientModel';
import { ActiveIDsModel } from 'Fw/Models/ParameterDefinitionModel';
import { DynamicReportParameters } from 'Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import { ModalInfo } from 'Fw/Models/ModalInfo';
import { SystemParameterService } from "ObjectClassService/SystemParameterService";
import { IModalService } from 'app/Fw/Services/IModalService';

@Component({
    selector: 'PatientAllRadiologyTestResultsForm',
    templateUrl: './PatientAllRadiologyTestResultsForm.html',
    providers: [MessageService]
})

export class PatientAllRadiologyTestResultsForm   {

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

    setInputParam(value: ActiveIDsModel) {
        if (value != null) {
            this.EpisodeObjectID = value.episodeId;
            //this._episodeObjectID = value.episodeId;
            //this.loadLastMonthResults();
        }
    }

    public MonthDt = [
        {
            Name: "3 ay",
            Value: 3
        },
        {
            Name: '6 ay',
            Value: 6
        },
        {
            Name: '1 yıl',
            Value: 12
        },
        {
            Name: '2 yıl',
            Value: 24
        },
        {
            Name: 'Tümü',
            Value: 0
        },
    ];

    MonthlyTimeInterval: number = 6;
    public PatientAllRadiologyTestsColumns = [
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
    PatientAllRadiologyTests: Array<vmPatientRadiologyTest> = new Array<vmPatientRadiologyTest>();

    constructor(protected httpService: NeHttpService,
        protected messageService: MessageService,
        private objectContextService: ObjectContextService,
        protected activeUserService: IActiveUserService,
        protected ngZone: NgZone,
        protected modalService: IModalService,
        private reportService: AtlasReportService) {

    }


    loadLastMonthResults() {
        //Ilk acilista son 1 ayda tamamlanmis Radyoloji sonuclari yukleniyor.
        this.MonthlyTimeInterval = 6;
        this.cmdGetPatientAllRadiologyTests_Click();
    }

    public cmdGetPatientAllRadiologyTests_Click(): void {

        if (this.MonthlyTimeInterval !== undefined && this.MonthlyTimeInterval !== null)
        {
            this.objectContextService.getObject<Episode>(this.EpisodeObjectID, Episode.ObjectDefID).then(episode => {

                this.PatientAllRadiologyTests = new Array<vmPatientRadiologyTest>();

                let apiUrl: string = 'api/RadiologyTestService/GetPatientAllRadiologyTests?PatientObjectId=' + episode.Patient.toString() + '&TimeInterval=' + this.MonthlyTimeInterval.toString();
                this.httpService.get<Array<vmPatientRadiologyTest>>(apiUrl).then(result => {
                    if (result != null) {
                        for (let radTest of result) {
                            let vmRadiologyTest: vmPatientRadiologyTest = new vmPatientRadiologyTest();
                            vmRadiologyTest.SubActionProcedureObjectId = radTest.SubActionProcedureObjectId;
                            vmRadiologyTest.ActionStatus = radTest.ActionStatus;
                            vmRadiologyTest.ProcedureCode = radTest.ProcedureCode;
                            vmRadiologyTest.ProcedureName = radTest.ProcedureName;
                            vmRadiologyTest.RequestDate = radTest.RequestDate;
                            vmRadiologyTest.RequestedByResUser = radTest.RequestedByResUser;
                            vmRadiologyTest.ProcedureResUser = radTest.ProcedureResUser;
                            vmRadiologyTest.ProcedureReportLink = radTest.ProcedureReportLink;
                            vmRadiologyTest.ProcedureResultLink = radTest.ProcedureResultLink;
                            vmRadiologyTest.isReportShown = radTest.isReportShown;
                            vmRadiologyTest.isResultShown = radTest.isResultShown;
                            vmRadiologyTest.AccessionNo = radTest.AccessionNo;
                            vmRadiologyTest.FromResourceName = radTest.FromResourceName;
                            this.PatientAllRadiologyTests.push(vmRadiologyTest);
                        }
                    }
                });

            });
        }
        else
            InfoBox.Alert(i18n("M30807", "Geçmiş tarih aralığı seçmelisiniz!"));
    }

    async selectReport(row) {
        this.openRadiologyReport(row.data.SubActionProcedureObjectId);
    }

    async selectResultView(row) {
        this.openInNewTab(row.displayValue);
    }

    async openRadiologyReport(SubActionProcedureObjectId: Guid) {

let paramNewRadiologyReport: string;
        paramNewRadiologyReport = await SystemParameterService.GetParameterValue('NEWRADIOLOGYREPORT', 'FALSE');
        if (paramNewRadiologyReport == "TRUE") {

            let reportData: DynamicReportParameters = {

                Code: 'RADYOLOJISONUCRAPOR',
                ReportParams: { ObjectID: SubActionProcedureObjectId },
                ViewerMode: true

            };

            return new Promise((resolve, reject) => {

                let componentInfo = new DynamicComponentInfo();
                componentInfo.ComponentName = 'HvlDynamicReportComponent';
                componentInfo.ModuleName = 'DevexpressReportingModule';
                componentInfo.ModulePath = '/app/DevexpressReporting/DevexpressReportingModule';
                componentInfo.InputParam = reportData;

                let modalInfo: ModalInfo = new ModalInfo();
                modalInfo.Title = "RADYOLOJI SONUÇ RAPORU"

                modalInfo.fullScreen = true;

                let result = this.modalService.create(componentInfo, modalInfo);
                result.then(inner => {

                    resolve(inner);
                }).catch(err => {
                    reject(err);
                });
            });
        } else {


            let that = this;
            const objectIdParam = new GuidParam(SubActionProcedureObjectId);
            let reportParameters: any = { 'TTOBJECTID': objectIdParam };
            this.reportService.showReport('RadiologyTestResultReport', reportParameters);
        }




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