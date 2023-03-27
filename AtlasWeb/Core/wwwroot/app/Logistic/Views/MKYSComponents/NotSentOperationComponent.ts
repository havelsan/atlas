import { Component, OnInit } from '@angular/core';
import { BaseComponent } from 'app/Fw/Components/BaseComponent';
import { ServiceContainer } from 'app/Fw/Services/ServiceContainer';
import { NeHttpService } from 'app/Fw/Services/NeHttpService';
import { IActiveUserService } from 'app/Fw/Services/IActiveUserService';
import { IModalService } from 'app/Fw/Services/IModalService';
import { MessageService } from 'app/Fw/Services/MessageService';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import {
    OutputMyStock, EndOfYearItem, MkysIntegrationViewModel, QueryInputDVO, DocumentRecordLogGridItem, QueryMkysDVO,
    QueryMkysCompareItem, QueryMkysActionAllCompare, StockActionMkysCompareItem, MkysCompareResultColorEnum, ReceivedDataFromMkys,
    InputFor_ChattelDocumentCreate, GetActiveAccountingTerm_Input, GetYilSonuDevir_Output, StockCensusForAtlas_Input
} from 'app/Logistic/Models/MkysIntegrationViewModel';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { ModalActionResult } from 'app/Fw/Models/ModalInfo';
import { DialogResult } from 'app/NebulaClient/Utils/Enums/DialogResult';
import { UsernamePwdBox } from 'app/NebulaClient/Visual/UsernamePwdBox';

@Component({
    selector: 'not-sent-operation',
    templateUrl: './NotSentOperationComponent.html'
})

export class NotSentOperationComponent extends BaseComponent<MkysIntegrationViewModel> {
    
    public isWithOutCancelled: boolean = true;
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

    public DocumentRecordLogGrid = [
        {
            caption: i18n("M14805", "Giriş ve Çıkış Nedenleri"),
            dataField: 'Subject',
            width: 300,
            groupIndex: 0
        },

        {
            caption: i18n("M11743", "Belge Kayıt Numarası"),
            dataField: 'DocumentRecordLogNumber',
            width: 150,

        },
        {
            caption: i18n("M16834", "İşlem Çeşidi"),
            dataField: 'DocumentTransactionType',
            width: 150,
            cellTemplate: 'enumCmbTemplate'

        },
        {
            caption: i18n("M11748", "Belge Tarihi"),
            dataField: 'DocumentDateTime',
            width: 150,

        },
        {
            caption: 'MKYS Ayniyat Numarası',
            dataField: 'ReceiptNumber',
            width: 150,

        },
        {
            caption: i18n("M16870", "İşlem Numarası"),
            dataField: 'StockActionID',
            width: 150,
            groupIndex: 1

        },
        {
            caption: 'MKYS Sonuç Mesajı',
            dataField: 'MKYSResultMsg',
            width: 150
        }
    ];

    ngOnInit() { }

    clientPreScript(): void {   
        this.valueForStore = this.activeUserService.SelectedUserStore.Name;
        this.doActiveAccountingTerm();
        this.getRoleControlMkysRole();
    }
    clientPostScript(state: String): void {     }

    async doSearch() {
        await this.doActiveAccountingTerm();
        let inputDvo = new QueryInputDVO();
        inputDvo.accountingTermObjID = this.accountingTermObjId;
        inputDvo.isWithOutCancelled = this.isWithOutCancelled;
        let that = this;
        let fullApiUrl: string = 'api/MkysIntegration/GetDocumentRecordLog';
        this.http.post(fullApiUrl, inputDvo)
            .then((res) => {
                let result = <MkysIntegrationViewModel>res;
                this.Model = result;
                if (that.Model && that.Model.DocumentRecordLogGridListItem) {
                    this.DocRecordLog = this.Model.DocumentRecordLogGridListItem;
                    this.sendMKYSButton = false;
                } else {
                    this.DocRecordLog = new Array<any>();
                }
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }

    async doActiveAccountingTerm() {
        let that = this;
        let inputDvo = new GetActiveAccountingTerm_Input();
        inputDvo.storeObjectId = that.activeUserService.SelectedUserStore.ObjectID;
        let fullApiUrl: string = 'api/MkysIntegration/GetActiveAccountingTerm';
        that.http.post(fullApiUrl, inputDvo)
            .then((res) => {
                let result = <MkysIntegrationViewModel>res;
                that.Model = result;
                if (that.Model && that.Model.ActiveAccountingTerm) {
                    that.accountingTermObjId = that.Model.ActiveAccountingTerm.AccountingTerm;
                    that.activeAccountingTerm = that.Model.ActiveAccountingTerm;
                    that.valueForEditableTextArea = that.Model.ActiveAccountingTerm.Desciption;
                }
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }

    async doSentMkys() {
        let result = await UsernamePwdBox.Show(true);
        if ((<ModalActionResult>result).Result == DialogResult.OK) {
            let params = <any>(<ModalActionResult>result).Param;
            let inputDvo = new QueryMkysDVO();
            inputDvo.mkysObject = this.DocRecordLog;
            inputDvo.MKYSUserPassword = params.password;
            inputDvo.MKYSUserName = params.userName;
            let that = this;
            let fullApiUrl: string = 'api/MkysIntegration/SentToMkysForUnCompleted';
            this.http.post(fullApiUrl, inputDvo)
                .then((res) => {
                    let result = <MkysIntegrationViewModel>res;
                    this.Model = result;

                    if (that.Model && that.Model.DocumentRecordLogGridListItem)
                        this.DocRecordLog = this.Model.DocumentRecordLogGridListItem;
                    else
                        this.DocRecordLog = new Array<any>();
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                });
        }
    }

    async getRoleControlMkysRole() {
        let input: any;
        let that = this;
        let fullApiUrl: string = 'api/MkysIntegration/GetRoleControlMkys';
        this.http.post(fullApiUrl, input)
            .then((res) => {
                let result = <MkysIntegrationViewModel>res;
                that.Model = result;
                if (that.Model) {
                    that.hasRoleCompareToMkys = that.Model.hasRoleCompareToMkys;
                    that.hasRoleMkysDocumentsFromInstitutions = that.Model.hasRoleMkysDocumentsFromInstitutions;
                    that.hasRoleSendToMkys = that.Model.hasRoleSendToMkys;
                    that.hasRoleMkysEndOfYearCensus = that.Model.hasRoleMkysEndOfYearCensus;
                }
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }


}