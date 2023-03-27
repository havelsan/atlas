import { Component, OnInit, Input } from '@angular/core';
import { BaseComponent } from 'app/Fw/Components/BaseComponent';
import { MkysIntegrationViewModel, DocumentRecordLogGridItem, StockActionMkysCompareItem, ReceivedDataFromMkys, InputFor_ChattelDocumentCreate, MkysCompareResultColorEnum, QueryMkysActionAllCompare } from 'app/Logistic/Models/MkysIntegrationViewModel';
import { ServiceContainer } from 'app/Fw/Services/ServiceContainer';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { IActiveUserService } from 'app/Fw/Services/IActiveUserService';
import { IModalService } from 'app/Fw/Services/IModalService';
import { MessageService } from 'app/Fw/Services/MessageService';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { NeResult } from 'app/NebulaClient/Utils/NeResult';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { UsernamePwdBox } from 'app/NebulaClient/Visual/UsernamePwdBox';
import { ModalActionResult } from 'app/Fw/Models/ModalInfo';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { Convert } from 'app/NebulaClient/Mscorlib/Convert';


@Component({
    selector: 'incoming-document',
    templateUrl: './IncomingDocumentComponent.html'
})

export class IncomingDocumentComponent extends BaseComponent<MkysIntegrationViewModel> {
    @Input("isTicketCreate") isTicketCreate: boolean;
    public DocRecordLog = new Array<DocumentRecordLogGridItem>();
    public accountingTermObjId: any;
    public activeAccountingTerm: any;
    public valueForEditableTextArea: string;
    public stockActionID: string;
    public dataSource: any;
    public startDate: Date = new Date();
    public endDate: Date = new Date();
    public dataStockActionSource: Array<StockActionMkysCompareItem> = new Array<StockActionMkysCompareItem>();
    public dataStockActionSourceFaild: Array<StockActionMkysCompareItem> = new Array<StockActionMkysCompareItem>();
    public dataStockActionSourceOld: Array<StockActionMkysCompareItem> = new Array<StockActionMkysCompareItem>();
    public checkBoxValue: boolean = false;
    public stockActionIDdisable: boolean = !this.checkBoxValue;
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

    dataGridSelectionMode: string = "multiple";

    constructor(container: ServiceContainer, private http: NeHttpService, protected messageService: MessageService,
        private modalService: IModalService, protected activeUserService: IActiveUserService) {
        super(container);
    }
    
    ngOnInit() { 
        if(this.isTicketCreate) {
            this.dataGridSelectionMode = "single";
        }
    }

    clientPreScript(): void {    }
    clientPostScript(state: String): void {     }

    async selectedGridItem() {
        if (this.selectedTempItems.length > 0) {
            let inputObj: InputFor_ChattelDocumentCreate = new InputFor_ChattelDocumentCreate();
            inputObj.SelectedReceivedDataItems = new Array<ReceivedDataFromMkys>();

            for (let selectedData of this.selectedTempItems) {
                inputObj.SelectedReceivedDataItems.push(selectedData);
            }
            await this.createChattelDocumentForSelectedItem(inputObj);
            this.selectedTempItems = new Array<ReceivedDataFromMkys>();
        }
    }

    async createTicket() {
        if (this.selectedTempItems.length == 1) {
            let inputObj: InputFor_ChattelDocumentCreate = new InputFor_ChattelDocumentCreate();
            inputObj.SelectedReceivedDataItems = new Array<ReceivedDataFromMkys>();

            for (let selectedData of this.selectedTempItems) {
                inputObj.SelectedReceivedDataItems.push(selectedData);
            }
            await this.createTicketForSelectedItem(inputObj);
            this.selectedTempItems = new Array<ReceivedDataFromMkys>();
        }
    }

    async createTicketForSelectedItem(input: InputFor_ChattelDocumentCreate) {
        this.CreateButtonDisabled = true;
        input.Store = this.activeUserService.SelectedUserStore;

        this.http.post('api/EntryOperation/CreateTicket', input)
            .then((res) => {
                let result: any = res as NeResult<MkysIntegrationViewModel>;
                this.exceptionCreateMessage = result;
                this.popupVisible = true;
                this.CreateButtonDisabled = true;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                if (error == null) {
                    this.receivedDataSourceFromMkys = new Array<ReceivedDataFromMkys>();
                    this.exceptionCreateMessage = error;
                    this.CreateButtonDisabled = false;
                    this.popupVisible = true;
                }
            });
    }

    public popupVisible: boolean = false;
    public exceptionCreateMessage: string = '';
    async createChattelDocumentForSelectedItem(input: InputFor_ChattelDocumentCreate) {
        this.CreateButtonDisabled = true;
        let inputDvo = input;
        inputDvo.Store = this.activeUserService.SelectedUserStore;
        let that = this;
        let fullApiUrl: string = 'api/MkysIntegration/CreateChattelDocumentInputWithAccForSelecetedItem';

        that.http.post(fullApiUrl, inputDvo)
            .then((res) => {
                let result: any = res as NeResult<MkysIntegrationViewModel>;
                this.exceptionCreateMessage = result;
                this.popupVisible = true;
                this.CreateButtonDisabled = true;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                if (error == null) {
                    that.receivedDataSourceFromMkys = new Array<ReceivedDataFromMkys>();
                    this.exceptionCreateMessage = error;
                    this.CreateButtonDisabled = false;
                    this.popupVisible = true;
                }
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

    DataSourceSelectionChanged(data: any) {

    }
    loadingVisible = false;
    public buttonText = 'Tif Getir';
    public loadIndicatorVisible: boolean;

    async GetMkysTif(data) {
        let passwordResult = await UsernamePwdBox.Show(true);
        if ((<ModalActionResult>passwordResult).Result === DialogResult.OK) {
            let params = <any>(<ModalActionResult>passwordResult).Param;
            this.loadingVisible = true;
            this.CreateButtonDisabled = true;
            this.loadIndicatorVisible = true;
            this.buttonText = i18n("M14773", "Getiriliyor..");

            let inputDvo = new QueryMkysActionAllCompare();
            inputDvo.startDate = Convert.ToDateTime(Convert.ToDateTime(this.startDate).ToShortDateString() + " 00:00:00");
            inputDvo.endDate = Convert.ToDateTime(Convert.ToDateTime(this.endDate).ToShortDateString() + " 23:59:59");
            inputDvo.MKYSUserName = params.userName;
            inputDvo.MKYSUserPassword = params.password;
            let that = this;
            let fullApiUrl: string = 'api/MkysIntegration/GetMkysTifByParamater';
            this.http.post(fullApiUrl, inputDvo)
                .then((res) => {
                    let result = <MkysIntegrationViewModel>res;
                    that.Model = result;

                    if (that.Model && that.Model.receivedDataSource) {
                        that.receivedDataSourceFromMkys = that.Model.receivedDataSource;
                        that.CreateButtonDisabled = false;
                        this.buttonText = 'Tif Getir';
                        this.loadingVisible = false;
                    }
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    this.buttonText = 'Tif Getir';
                    this.loadingVisible = false;
                });

            this.loadIndicatorVisible = false;
        }

    }


}