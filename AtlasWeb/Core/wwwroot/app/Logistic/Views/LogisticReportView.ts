//$48C582EC
import { Component } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import { LogisticReportViewModel, Report, SubStoreModel, SubStoreItem } from '../Models/LogisticReportViewModel';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { IModalService } from 'Fw/Services/IModalService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { MessageService } from 'Fw/Services/MessageService';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { Store, PharmacyStoreDefinition, PharmacySubStoreDefinition } from 'NebulaClient/Model/AtlasClientModel';

import { KScheduleService, GetCompletedKSchedule_Input, GetCompletedKSchedule_Output, CompletedKscheduleAction, PrintBarcodeForGivenActions_Input, DrugBarcodesContainer } from 'ObjectClassService/KScheduleService';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';

import { AtlasBarcodePrintService } from 'app/Barcode/Services/AtlasBarcodePrintService';
import { IBarcodePrintService } from 'app/Barcode/Services/IBarcodePrintService';
import { IBarcodePrinterProvider } from 'app/Barcode/Services/IBarcodePrinterProvider';
import { AtlasFormFieldConfig } from 'app/DynamicForm/Models/AtlasFormFieldConfig';


@Component({
    selector: 'hvl-logistic-report-view',
    inputs: ['Model'],
    templateUrl: './LogisticReportView.html',
    styles: [` :host /deep/ .dx-context-menu .dx-menu-items-container { height: 100px; overflow-y: scroll;}`],
    providers: [MessageService,
        { provide: IBarcodePrintService, useClass: AtlasBarcodePrintService }]
})

export class LogisticReportView extends BaseComponent<LogisticReportViewModel> {

    constructor(container: ServiceContainer, private http: NeHttpService, protected messageService: MessageService, private modalService: IModalService, protected activeUserService: IActiveUserService, private barcodePrintService: IBarcodePrintService) {
        super(container);
        this.startDate = new Date();
        this.startDate = this.startDate.AddHours(-1); // default son bir saatlik arama olsun

    }
    store: Store;
    public rowVisible: boolean;
    public startDate: Date = new Date();
    public endDate: Date = new Date();
    public buttonText = i18n("M30030", "Listele");
    public buttonText2 = i18n("M30031", "Barkod Oluştur");

    completedActions: CompletedKscheduleAction[];
    selectedRows: CompletedKscheduleAction[];

    public selecttableStores: Array<SubStoreItem>;
    public selectedStore: string;

    public dataSourceReport: Array<Report>;
    public ReportDefName: string;

    async clientPreScript() {
        let subStoreModel: SubStoreModel = null;
        subStoreModel = await this.GetMySubStoreModel();
        this.selecttableStores = subStoreModel.Stores;
        await this.getLogisticReport();
        this.store = this.activeUserService.SelectedUserStore;
        if (this.store.ObjectDefID.valueOf() === PharmacyStoreDefinition.ObjectDefID.id || this.store.ObjectDefID.valueOf() === PharmacySubStoreDefinition.ObjectDefID.id ) {
            this.rowVisible = true;
        }
        else {
            this.rowVisible = false;
        }
    }

    clientPostScript() {
    }

    private async GetFulfilledKSchedules(): Promise<void> {
        let param: GetCompletedKSchedule_Input = new GetCompletedKSchedule_Input();
        if (this.selectedStore != null)
            param.StoreID = this.selectedStore.toString();
        param.EndDate = this.endDate;
        param.StartDate = this.startDate;
        let returnedActions: GetCompletedKSchedule_Output = await KScheduleService.GetCompletedKscheduleActions(param);
        this.completedActions = returnedActions.CompletedKscheduleList;
    }

    select(event) {
        this.selectedRows = event.selectedRowKeys;
    }

    private async SendActionsForBarcodePrint(): Promise<void> {
        if (this.selectedRows == null) {
            ServiceLocator.MessageService.showError('İşlem seçiniz!');
            return;
        }
        else {
            if (this.selectedRows.length == 0) {
                ServiceLocator.MessageService.showError('İşlem seçiniz!');
                return;
            }
        }

        let inputForSelectedActions: PrintBarcodeForGivenActions_Input = new PrintBarcodeForGivenActions_Input();
        inputForSelectedActions.GivenActionList = this.selectedRows;
        let returnedBarcodes: DrugBarcodesContainer = await KScheduleService.PrintBarcodeForGivenActions(inputForSelectedActions);

        for (let barcodeInfo of returnedBarcodes.DrugBarcodes) {
            this.barcodePrintService.printAllBarcode(barcodeInfo, "generateDrugBarcode", "printDrugBarcode");
        }

        console.log(returnedBarcodes);

    }


    public async GetMySubStoreModel(): Promise<SubStoreModel> {
        let url: string = '/api/LogisticReport/GetMySubStoreModel';
        let input: any;
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<SubStoreModel>(url, input);
        return result;
    }

    public async GetMyStoreObjectID(): Promise<string> {
        let url: string = '/api/LogisticReport/GetMyStoreObjectID';
        let input: any;
        let httpService: NeHttpService = ServiceLocator.NeHttpService;
        let result = await httpService.post<string>(url, input);
        return result;
    }

    itemClick(data) {
        let item = data.itemData;

        if (item.name) {
            this.ReportDefName = item.name;
        }
    }

    public async reportParameterConfigInitilaized(config: Array<AtlasFormFieldConfig>): Promise<void> {
        if (this.ReportDefName === "STOCKINHELDFORSTORE") {
            let filterExp: string = await this.GetMyStoreObjectID();

            for (const fieldConfig of config) {
                if (fieldConfig.name === 'STOREID') {
                    fieldConfig.userFilterExpression = filterExp;
                }
            }
        }
    }

    async getLogisticReport() {
        let input: any;
        let that = this;
        let fullApiUrl: string = 'api/LogisticReport/GetLogisticReport';
        this.http.post(fullApiUrl, input)
            .then((res) => {
                let result = <LogisticReportViewModel>res;
                that.Model = result;
                if (that.Model) {
                    that.dataSourceReport = that.Model.Reports;
                }
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }



}