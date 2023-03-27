import { Component, OnInit } from '@angular/core';
import { BaseComponent } from 'app/Fw/Components/BaseComponent';
import { MkysIntegrationViewModel, DocumentRecordLogGridItem, StockActionMkysCompareItem, ReceivedDataFromMkys, QueryMkysActionAllCompare, MkysCompareResultColorEnum } from 'app/Logistic/Models/MkysIntegrationViewModel';
import { ServiceContainer } from 'app/Fw/Services/ServiceContainer';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { IActiveUserService } from 'app/Fw/Services/IActiveUserService';
import { IModalService } from 'app/Fw/Services/IModalService';
import { MessageService } from 'app/Fw/Services/MessageService';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';


@Component({
    selector: 'compare-operation',
    templateUrl: './CompareOperationComponent.html'
})

export class CompareOperationComponent extends BaseComponent<MkysIntegrationViewModel> {
    public startDate: Date = new Date();
    public checkBoxValue: boolean = false;
    public stockActionIDdisable: boolean = !this.checkBoxValue;
    public DocRecordLog = new Array<DocumentRecordLogGridItem>();
    public accountingTermObjId: any;
    public activeAccountingTerm: any;
    public valueForEditableTextArea: string;
    public stockActionID: string;
    public dataSource: any;
    public endDate: Date = new Date();
    public dataStockActionSource: Array<StockActionMkysCompareItem> = new Array<StockActionMkysCompareItem>();
    public dataStockActionSourceFaild: Array<StockActionMkysCompareItem> = new Array<StockActionMkysCompareItem>();
    public dataStockActionSourceOld: Array<StockActionMkysCompareItem> = new Array<StockActionMkysCompareItem>();
    public checkBoxValueFailed: boolean = false;
    public sendMKYSButton: boolean = true;
    public CompareWithMkysButton: boolean = false;
    public CreateButtonDisabled: boolean = true;
    public receivedDataSourceFromMkys: Array<ReceivedDataFromMkys> = new Array<ReceivedDataFromMkys>();
    public componentInfo: DynamicComponentInfo;
    public selectedTempItems: Array<ReceivedDataFromMkys>;
    public isWithOutCancelled: boolean = true;

    public hasRoleSendToMkys: boolean;
    public hasRoleCompareToMkys: boolean;
    public hasRoleMkysDocumentsFromInstitutions: boolean;
    public hasRoleMkysEndOfYearCensus: boolean;

    public valueForStore: string;
    public valueForYear: string;

    public MKYSDevirGetirBtn: boolean = false;
    public MKYSDevirGetirYapBtn: boolean = true;

    constructor(container: ServiceContainer, private http: NeHttpService, protected messageService: MessageService,
        private modalService: IModalService, protected activeUserService: IActiveUserService) {
        super(container);
    }
    
    ngOnInit() { }

    clientPreScript(): void {    }
    clientPostScript(state: String): void {     }

    onValueChanged(data: any) {
        this.stockActionIDdisable = data.previousValue;
        if (data.previousValue) {
            this.stockActionID = '';
        }
    }

    onValueChangedFailed(data: any) {
        if (!data.previousValue) {
            this.dataStockActionSource = this.dataStockActionSourceFaild;
        } else {
            this.dataStockActionSource = this.dataStockActionSourceOld;
        }
    }

    private async CompareWithMkys() {
        this.CompareWithMkysButton = true;
        this.doCompareAllActionToMkys();
        this.CompareWithMkysButton = false;
    }
    
    loadingVisible:boolean = false;
    LoadPanelMessage:string ="";
    async doCompareAllActionToMkys() {
        this.LoadPanelMessage="MKYS Sorgulanıyor";
        this.loadingVisible = true;
        let inputDvo = new QueryMkysActionAllCompare();
        inputDvo.startDate = this.startDate;
        inputDvo.endDate = this.endDate;
        inputDvo.stockActionID = this.stockActionID;
        let that = this;
        let fullApiUrl: string = 'api/MkysIntegration/CompareAllActionToMkys';
        this.http.post(fullApiUrl, inputDvo)
            .then((res) => {
                let result = <MkysIntegrationViewModel>res;
                that.Model = result;
                if (that.Model && that.Model.StockActionMkysCompareItems) {
                    that.dataStockActionSource = that.Model.StockActionMkysCompareItems;
                    that.dataStockActionSourceOld = that.dataStockActionSource;
                    for (let fail of that.dataStockActionSource) {
                        if (fail.IsFaild) {
                            that.dataStockActionSourceFaild.push(fail);
                        }
                    }
                }
                this.loadingVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });
    }

    onRowPrepared(e: any): void {
        if (e.rowElement.firstItem() !== undefined && e.rowElement.firstItem().length > 0 && e.rowType !== 'header' && e.rowElement.firstItem().length === 1) {

            if (e.data !== undefined) {

                if (e.data.colorEnum != null) {

                    let colorEnum: MkysCompareResultColorEnum = e.data.colorEnum;

                    if (colorEnum.Value === MkysCompareResultColorEnum.red) {
                        e.rowElement.firstItem().style.backgroundColor = '#DC143C';
                        e.rowElement.firstItem().style.color = '#F8F8FF';
                    }
                    if (colorEnum.Value === MkysCompareResultColorEnum.blue) {
                        e.rowElement.firstItem().style.backgroundColor = '#6495ED';
                        e.rowElement.firstItem().style.color = '#F8F8FF';
                    }
                }
            }
        }
    }
}