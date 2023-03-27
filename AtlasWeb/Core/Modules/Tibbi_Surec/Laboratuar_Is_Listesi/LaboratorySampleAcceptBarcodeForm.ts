
import { Component, OnInit, Input, EventEmitter, OnDestroy } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { MessageService } from 'app/Fw/Services/MessageService';
import { AtlasHttpService } from 'app/Fw/Services/AtlasHttpService';
import { Guid } from 'NebulaClient/Mscorlib/Guid';
import { ActiveIDsModel } from 'Fw/Models/ParameterDefinitionModel';
import { DynamicReportParameters } from 'app/Fw/Components/Reporting/HvlDynamicReportComponent';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { DynamicComponentInputParam } from 'app/Fw/Models/DynamicComponentInputParam';
import { ModalInfo } from 'app/Fw/Models/ModalInfo';
import { IModalService } from 'app/Fw/Services/IModalService';
import { ObjectContextService } from 'app/Fw/Services/ObjectContextService';
import { AtlasReportService } from 'app/Report/Services/AtlasReportService';
import { SubActionProcedure } from 'app/NebulaClient/Model/AtlasClientModel';
import { GuidParam } from 'app/NebulaClient/Mscorlib/GuidParam';
import { SampleAcceptBarcodeModel } from './LaboratorySampleAcceptBarcodeFormViewModel';

@Component({
    selector: "LaboratorySampleAcceptBarcodeForm",
    templateUrl: './LaboratorySampleAcceptBarcodeForm.html',
    providers: [MessageService]

})
export class LaboratorySampleAcceptBarcodeForm implements OnInit, OnDestroy {


    public lastReadedBarcodeAction: string = null;
    public showLoadPanel: boolean = false;
    public BarcodeValue = "";
    public LaboratoryProcedureList : any;
    public LastReadedBarcode: string;
    public IsTransitionMade: boolean;
    constructor(protected httpService: NeHttpService, protected messageService: MessageService, protected modalService: IModalService, private reportService: AtlasReportService, private objectContextService: ObjectContextService) {

    }
    public ProcedureListColumns = [
        {
            "caption": i18n("M30802", "Kategori Adı"),
            dataField: "ProcedureRequestFormCategoryName",
            width: 80,
            allowSorting: true,
            groupIndex: "0"
        },
        {
            "caption": i18n("M16860", "İşlem Kodu"),
            dataField: "TestCode",
            width: 80,
            allowSorting: true,
            cellTemplate: "ExternalRequestCellTemplate"
        },
        {
            "caption": i18n("M16821", "İşlem Adı"),
            dataField: "LaboratoryTestName",
            width: 300,
            allowSorting: true,
            cellTemplate: "TestPriorityCellTemplate"
        },
        {
            "caption": i18n("M16694", "İstem Tarihi"),
            dataField: "RequestDate",
            width: 120,
            allowSorting: true
        },
        {
            "caption": i18n("M30803", "İşlem Durumu"),
            dataField: "StateName",
            width: 120,
            allowSorting: true
        },
        {
            "caption": i18n("M27321", "Barkod"),
            dataField: "BarcodeID",
            width: 110,
            allowSorting: true,
            cellTemplate: "BarcodeCellTemplate"
        },
        {
            "caption": i18n("M19543", "Numune No"),
            dataField: "SpecimenID",
            width: 110,
            allowSorting: true
        },
        {
            "caption": i18n("M16721", "Numune Alan"),
            dataField: "SampleUser",
            width: 150,
            allowSorting: true
        },
        {
            "caption": i18n("M16697", "Numune Alım Tarihi"),
            dataField: "SampleDate",
            width: 200,
            allowSorting: true
        }
    ];
    async ngOnInit() {

    }

    async btnPrintTestInstructions_Click(data, row) {
        if (row.data.ProcedureInstructionReportName != "" && row.data.ProcedureInstructionReportName != null) {
            let reportName: string = row.data.ProcedureInstructionReportName;
            let reportNameArray: Array<string>;
            reportNameArray = reportName.split("|");

            let subActionProcObjectId: Guid = <any>row.data.ObjectID;
            let subactionProcedure: SubActionProcedure = await this.objectContextService.getObject<SubActionProcedure>(subActionProcObjectId, SubActionProcedure.ObjectDefID);
            for (let repName of reportNameArray) {
                if (repName != null && repName != "") {

                    if (repName == "LaboratoryTestPatientInstructionReport") {
                        let testObjectID: string = <any>subactionProcedure['ProcedureObject'];
                        const objectIdParam = new GuidParam(testObjectID);
                        let reportParameters: any = { 'TESTOBJECTID': objectIdParam };
                        this.reportService.showReport(repName, reportParameters);

                    }
                    else {
                        let episodeActionObjectID: string = <any>subactionProcedure['EpisodeAction'];
                        const objectIdParam = new GuidParam(episodeActionObjectID);
                        let reportParameters: any = { 'TTOBJECTID': objectIdParam };
                        this.reportService.showReport(repName, reportParameters);
                    }
                }
            }
        }
    }
    onBarcodeChanged(event) {
        if (!String.isNullOrEmpty(event)) {
            let that = this;
            if (event.charCode === 13) {
                let fullApiUrl: string = "/api/LaboratoryWorkListService/GetSampleAcceptBarcodeFormViewModel?BarcodeId="+this.BarcodeValue;
                this.httpService.get<SampleAcceptBarcodeModel>(fullApiUrl)
                    .then(response => {
                        this.lastReadedBarcodeAction = response.LabRequestObjectID;
                        this.LaboratoryProcedureList = response.LaboratoryProcedureList;
                        this.LastReadedBarcode = response.LastReadedBarcode;
                        this.IsTransitionMade = response.IsTransitionMade;
                    });
                this.BarcodeValue = "";
            }
        }
    }

    clientPostScript(state: String) {

    }

    clientPreScript() {

    }
    public ngOnDestroy(): void {
    }

}