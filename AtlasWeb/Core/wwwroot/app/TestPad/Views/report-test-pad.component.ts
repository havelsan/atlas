import { Component, OnInit } from '@angular/core';
import { ResponseContentType } from '@angular/http';
import { AtlasReportService } from '../../Report/Services/AtlasReportService';
import { ReportDefinition } from '../../Report/Models/ReportDefinition';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { AtlasFormFieldConfig } from '../../DynamicForm/Models/AtlasFormFieldConfig';
import { AtlasHttpService } from 'Fw/Services/AtlasHttpService';
import { GuidParam } from 'NebulaClient/Mscorlib/GuidParam';
import { DynamicComponentInfo } from "Fw/Models/DynamicComponentInfo";
import { AtlasListDefComponent } from "Fw/Components/AtlasListDefComponent";
import { ModalInfo, ModalActionResult } from "Fw/Models/ModalInfo";
import { IModalService } from "Fw/Services/IModalService";
import { ArrayParam } from 'NebulaClient/Mscorlib/ArrayParam';
import { map } from 'rxjs/operators';

@Component({
    selector: 'report-test-pad',
    template: `<h1>Report Test Pad</h1>

    <dx-button (click)="testUserFilterExpr()" text="Test User Filter Expression"></dx-button>
    <dx-button (click)="showModal()" [text]="'Print Report With Modal Dialog'"></dx-button>

    <dx-button (click)="printReport()" [text]="'Print Report'"></dx-button>

 <dx-lookup #lookup
            [dataSource]="reportDefinitionList"
            [grouped]="false"
            [closeOnOutsideClick]="true"
            [showPopupTitle]="false"
            (onSelectionChanged)="selectionChanged($event)"
            displayExpr="Name">
        </dx-lookup>
        <hr/>
{{selectedItem | json}}
        <hr/>

    <atlas-report-component [ReportDefName]='selectedItem?.Name'></atlas-report-component>

    `,
    providers: [AtlasReportService]
})
export class ReportTestPadComponent implements OnInit {
    public reportDefinitionList: Array<ReportDefinition>;
    public selectedItem: ReportDefinition;

    config: AtlasFormFieldConfig[] = [
    ];

    constructor(private reportService: AtlasReportService
        , private http2: AtlasHttpService
        , private http: NeHttpService
        , private modalService: IModalService) {
    }

    public ngOnInit(): void {
        let that = this;
        this.reportService.getAllReportDefinitions().then(r => {
            that.reportDefinitionList = r;
        }).catch(err => {
            console.log(err);
        });
    }

    public selectionChanged(e: any) {
        if (e != null) {
            let selectedItem: ReportDefinition = e.selectedItem;
            if (selectedItem != null) {
                this.selectedItem = selectedItem;
            }
        }
    }

    private downloadPDF(): any {
        let apiUrl = '/api/Report/RenderReportToPdfWithReportName';
        let input = { ReportName: "ACTIVEINGREDIENTLISTREPORT" };

        return this.http2.post(apiUrl, input, { responseType: ResponseContentType.Blob }).pipe(map(
            (res) => {
                return new Blob([res.blob()], { type: 'application/pdf' });
            }));
    }

    public showSampleReport(): void {

        this.downloadPDF().toPromise().then(
            (res) => {
                let fileURL = URL.createObjectURL(res);
                window.open(fileURL);
            }
        );
    }

    public printReport() {
        const objectId1Param = new GuidParam('cc16826e-80c2-434c-85f9-b25c69fac004');
        const objectId2Param = new GuidParam('cc16826e-80c2-434c-85f9-b25c69fac004');
        const arrayParam = new ArrayParam([objectId1Param, objectId2Param]);
        let reportParameters: any = { 'TTOBJECTID': arrayParam };
        this.reportService.showReport('ChattelDocumentInDetailReport', reportParameters);
    }

    public showModal() {
        if (this.selectedItem && this.selectedItem.Name) {
            this.reportService.showReportModal(this.selectedItem.Name, null);
        }
    }

    testUserFilterExpr(): void {
        let that = this;
        let dynamicComponentInfo = new DynamicComponentInfo();
        dynamicComponentInfo.ComponentType = AtlasListDefComponent;
        dynamicComponentInfo.InputParam = { ListDefID: "65405b70-5e35-4486-b140-c95af3d8bf5d", UserFilterExpression: "NAME LIKE 'B%'" };
        let modalInfo = new ModalInfo();
        modalInfo.Width = 600;
        modalInfo.Height = 500;
        modalInfo.Title = i18n("M18394", "Lütfen seçim yapınız (") + "Depo" + ')';
        this.modalService.create(dynamicComponentInfo, modalInfo).then(res => {
            let result: ModalActionResult = res;
            if (result) {
                console.log(result);
            }
        });
    }

}