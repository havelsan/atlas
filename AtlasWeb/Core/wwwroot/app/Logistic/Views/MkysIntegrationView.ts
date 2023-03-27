//$E1A513BA
import { Component } from '@angular/core';
import { BaseComponent } from 'Fw/Components/BaseComponent';
import {
    OutputMyStock, EndOfYearItem, MkysIntegrationViewModel, QueryInputDVO, DocumentRecordLogGridItem, QueryMkysDVO,
    QueryMkysCompareItem, QueryMkysActionAllCompare, StockActionMkysCompareItem, MkysCompareResultColorEnum, ReceivedDataFromMkys,
    InputFor_ChattelDocumentCreate, GetActiveAccountingTerm_Input, GetYilSonuDevir_Output, StockCensusForAtlas_Input
} from '../Models/MkysIntegrationViewModel';
import { ServiceContainer } from 'Fw/Services/ServiceContainer';
import { DynamicComponentInfo } from 'Fw/Models/DynamicComponentInfo';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { ModalActionResult, ModalInfo } from 'Fw/Models/ModalInfo';
import { IModalService } from 'Fw/Services/IModalService';
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { NeResult } from 'NebulaClient/Utils/NeResult';
import { MessageService } from 'Fw/Services/MessageService';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { IActiveUserService } from 'Fw/Services/IActiveUserService';
import { Convert } from 'NebulaClient/Mscorlib/Convert';
import { UsernamePwdBox } from 'NebulaClient/Visual/UsernamePwdBox';
import { DialogResult } from 'NebulaClient/Utils/Enums/DialogResult';

@Component({
    selector: 'hvl-logistic-mkysIntegration-view',
    inputs: ['Model'],
    templateUrl: './MkysIntegrationView.html'
})
export class MkysIntegrationView extends BaseComponent<MkysIntegrationViewModel> {

    constructor(container: ServiceContainer, private http: NeHttpService, protected messageService: MessageService,
        private modalService: IModalService, protected activeUserService: IActiveUserService) {
        super(container);

        // this.startDate = Date.Now.AddDays(-1);
        // this.endDate = Date.Now;
    }

    public DocRecordLog = new Array<DocumentRecordLogGridItem>();
    public seletectDocRecordLog = new Array<DocumentRecordLogGridItem>();
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



    onValueChanged(data: any) {
        this.stockActionIDdisable = data.previousValue;
        if (data.previousValue) {
            this.stockActionID = '';
        }
    }

    onValueChangedFailed(data: any) {
        // this.checkBoxValueFailed = data.previousValue;
        if (!data.previousValue) {
            this.dataStockActionSource = this.dataStockActionSourceFaild;
        } else {
            this.dataStockActionSource = this.dataStockActionSourceOld;
        }
    }



    clientPreScript() {
        this.doActiveAccountingTerm();
        this.getRoleControlMkysRole();
        this.valueForStore = this.activeUserService.SelectedUserStore.Name;

        this.onComponentExecute();
    }
    clientPostScript(state: String) {

    }
    private async fillData() {
        this.doSearch();
    }

    private async GetNotSentToMkys() {
        this.fillData();
    }

    private async SentToMkys() {
        this.doSentMkys();
    }

    onComponentExecute() {
        return new Promise((resolve, reject) => {
            let compInfo = new DynamicComponentInfo();
            compInfo.ComponentName = 'ITSComponent';
            compInfo.ModuleName = 'LogisticFormsModule';
            compInfo.ModulePath = 'app/Logistic/Views/LogisticFormsModule';
            compInfo.InputParam = null;
            this.componentInfo = compInfo;
        });
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



    public passwordMks: any;
    private async CompareWithMkys() {
        //this.loadingVisible = true;
        let passwordResult = await UsernamePwdBox.Show(true);
        if ((<ModalActionResult>passwordResult).Result === DialogResult.OK) {
            this.passwordMks = <any>(<ModalActionResult>passwordResult).Param;
            this.CompareWithMkysButton = true;
            this.doCompareAllActionToMkys();
        }
        this.CompareWithMkysButton = false;
        //this.loadingVisible = false;
    }

    private async selectActionCreated() {

    }

    DataSourceSelectionChanged(data: any) {

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

    public DocumentRecordLogGrid = [
        {
            caption: i18n("M16870", "İşlem Numarası"),
            dataField: 'StockActionID',
            sortOrder: 'asc',
        },
        {
            caption: i18n("M14805", "Giriş ve Çıkış Nedenleri"),
            dataField: 'Subject',
        },
        {
            caption: i18n("M11743", "Belge Kayıt Numarası"),
            dataField: 'DocumentRecordLogNumber',
        },
        {
            caption: i18n("M16834", "İşlem Çeşidi"),
            dataField: 'DocumentTransactionType',
            cellTemplate: 'enumCmbTemplate'
        },
        {
            caption: i18n("M11748", "Belge Tarihi"),
            dataField: 'DocumentDateTime',
            dataType: "date"
        },
        {
            caption: 'MKYS Ayniyat Numarası',
            dataField: 'ReceiptNumber',
        },

        {
            caption: "Bütçe Türü",
            dataField: 'BudgetTypeName',
            cellTemplate: 'enumBudgetTypeCmbTemplate'
        },
        {
            caption: "MKYS Gönderim Durumu",
            dataField: 'MKYSControlType',
            cellTemplate: 'enumMKYSCmbTemplate'
        },
        {
            caption: 'MKYS Sonuç Mesajı',
            dataField: 'MKYSResultMsg',
        }
    ];
    public buttonText = 'Tif Getir';
    public loadIndicatorVisible: boolean;
    loadingVisible = false;
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

    async doSearch() {
        this.loadingVisible = true;
        this.LoadPanelMessage = "MKYS Gönderilmeyen İşlemler Listeliniyor..";
        await this.doActiveAccountingTerm();
        let inputDvo = new QueryInputDVO();
        inputDvo.accountingTermObjID = this.accountingTermObjId;
        inputDvo.isWithOutCancelled = this.isWithOutCancelled;
        inputDvo.StoreID = this.activeUserService.SelectedUserStore.ObjectID.toString();
        let that = this;
        let fullApiUrl: string = 'api/MkysIntegration/GetDocumentRecordLog';
        this.http.post(fullApiUrl, inputDvo)
            .then((res) => {
                let result = <MkysIntegrationViewModel>res;
                this.Model = result;
                if (that.Model && that.Model.DocumentRecordLogGridListItem) {
                    this.DocRecordLog = this.Model.DocumentRecordLogGridListItem;
                    this.sendMKYSButton = false;
                    this.loadingVisible = false;
                } else {
                    this.DocRecordLog = new Array<any>();
                    this.loadingVisible = false;
                }
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
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


    async selectionChangedHandler(e) {
        if (e.currentSelectedRowKeys.length > 0) {
            if (e.currentSelectedRowKeys[0].ReceiptNumber != null) {
                this.seletectDocRecordLog = this.seletectDocRecordLog.filter(x=>x.ObjectID.toString() != e.currentSelectedRowKeys[0].ObjectID.toString());
            }
        }
    }



    async doSentMkys() {
        //-TODO İlaydax

        if(this.seletectDocRecordLog == null || this.seletectDocRecordLog.length == 0){
            ServiceLocator.MessageService.showError("En Az Bir İşlem Seçimeniz Gerekiyor..");
            return;
        }


        let result = await UsernamePwdBox.Show(true);
        if ((<ModalActionResult>result).Result == DialogResult.OK) {
            let params = <any>(<ModalActionResult>result).Param;
            let mkysdvo = new QueryMkysDVO();
            mkysdvo.mkysObject = this.seletectDocRecordLog;
            mkysdvo.MKYSUserPassword = params.password;
            mkysdvo.MKYSUserName = params.userName;
            let that = this;
            this.loadingVisible = true;
            this.LoadPanelMessage = "MKYS'ye Gönderiliyor...";
            let fullApiUrl: string = 'api/MkysIntegration/SentToMkysForUnCompleted';
            this.http.post(fullApiUrl, mkysdvo)
                .then((res) => {
                    let result = <MkysIntegrationViewModel>res;
                    this.Model = result;

                    if (that.Model && that.Model.DocumentRecordLogGridListItem) {
                        for (let item of this.Model.DocumentRecordLogGridListItem) {
                            this.DocRecordLog.find(x => x.ObjectID == item.ObjectID).MKYSResultMsg = item.MKYSResultMsg;
                            this.DocRecordLog.find(x => x.ObjectID == item.ObjectID).ReceiptNumber = item.ReceiptNumber;
                        }
                        this.Model.DocumentRecordLogGridListItem;
                    }
                    else
                        this.DocRecordLog = new Array<any>();


                    this.loadingVisible = false;
                })
                .catch(error => {
                    this.loadingVisible = false;
                    TTVisual.InfoBox.Alert(error);
                });
        }
    }

    async doCompareToMkys() {
        let inputDvo = new QueryMkysCompareItem();
        inputDvo.stockActionID = this.stockActionID;
        let that = this;
        let fullApiUrl: string = 'api/MkysIntegration/CompateToMkys';
        this.http.post(fullApiUrl, inputDvo)
            .then((res) => {
                let result = <MkysIntegrationViewModel>res;
                that.Model = result;
                if (that.Model && that.Model.StockActionDetailViews) {
                    that.dataSource = that.Model.StockActionDetailViews;
                }
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }

    LoadPanelMessage: string = "";
    async doCompareAllActionToMkys() {
        this.LoadPanelMessage = "MKYS İşlem sorgulanıyor";
        let inputDvo = new QueryMkysActionAllCompare();
        inputDvo.startDate = this.startDate;
        inputDvo.endDate = this.endDate;
        inputDvo.stockActionID = this.stockActionID;
        inputDvo.MKYSUserName = this.passwordMks.userName;
        inputDvo.MKYSUserPassword = this.passwordMks.password;
        let that = this;
        this.loadingVisible = true;
        let fullApiUrl: string = 'api/MkysIntegration/CompareAllActionToMkys';
        await this.http.post(fullApiUrl, inputDvo)
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
                this.loadingVisible = false;
                TTVisual.InfoBox.Alert(error);
            });
    }

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

    public dataSoruceEndOfYearGetMkys: Array<GetYilSonuDevir_Output>;
    async btnGetDevirClick() {
        this.loadingVisible = true;
        let inputDvo = new EndOfYearItem();
        inputDvo.store = this.activeUserService.SelectedUserStore;
        inputDvo.year = this.valueForYear;
        let that = this;
        let fullApiUrl: string = 'api/MkysIntegration/GetMkysEndOfYear';
        this.http.post(fullApiUrl, inputDvo)
            .then((res) => {
                //let result = <MkysIntegrationViewModel>res;
                that.dataSoruceEndOfYearGetMkys = <Array<GetYilSonuDevir_Output>>res;
                this.loadingVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });
    }



    async btnGetYilSonuDevirClick() {

        let result = await UsernamePwdBox.Show(true);
        if ((<ModalActionResult>result).Result == DialogResult.OK) {
            let params = <any>(<ModalActionResult>result).Param;
            if (this.valueForYear != undefined) {
                this.loadingVisible = true;
                let inputDvo = new EndOfYearItem();
                inputDvo.store = this.activeUserService.SelectedUserStore;
                inputDvo.year = this.valueForYear;
                inputDvo.MKYSUserName = params.userName;
                inputDvo.MKYSUserPassword = params.password;
                let that = this;
                let fullApiUrl: string = 'api/MkysIntegration/GetYilSonuDevir';
                await this.http.post(fullApiUrl, inputDvo)
                    .then((res) => {
                        //let result = <MkysIntegrationViewModel>res;
                        that.dataSoruceEndOfYearGetMkys = <Array<GetYilSonuDevir_Output>>res;
                        this.MKYSDevirGetirYapBtn = false;
                        this.loadingVisible = false;
                    })
                    .catch(error => {
                        TTVisual.InfoBox.Alert(error);
                        this.loadingVisible = false;
                    });
            }
            else {
                TTVisual.InfoBox.Alert("Yıl Seçimi Yapınız");

            }
        }



    }

    public dataSoruceGetMyStock: Array<OutputMyStock>;
    async btnGetStockCardClick() {
        this.loadingVisible = true;
        let inputDvo = new EndOfYearItem();
        inputDvo.store = this.activeUserService.SelectedUserStore;
        inputDvo.year = this.valueForYear;
        let that = this;
        let fullApiUrl: string = 'api/MkysIntegration/GetStockCard';
        this.http.post(fullApiUrl, inputDvo)
            .then((res) => {
                //let result = <MkysIntegrationViewModel>res;
                that.dataSoruceGetMyStock = <Array<OutputMyStock>>res;
                this.loadingVisible = false;

            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });
    }

    async btnStockCensusForAtlasClick() {
        let control: boolean = true;
        for (let source of this.dataSoruceEndOfYearGetMkys) {
            if (source.hata == "Hatalı Mevcut") {
                ServiceLocator.MessageService.showError("Hatalı Mevcut Var.");
                control = false;
            }
        }
        if (control == true) {
            await this.StockCensusForAtlasClick();
        }
    }


    async StockCensusForAtlasClick() {

        this.loadingVisible = true;
        let inputDvo = new StockCensusForAtlas_Input();
        inputDvo.store = this.activeUserService.SelectedUserStore;
        inputDvo.stokHaraketYilSonuItems = this.dataSoruceEndOfYearGetMkys;
        let that = this;
        let fullApiUrl: string = 'api/MkysIntegration/StockCensusForAtlasClick';
        await this.http.post(fullApiUrl, inputDvo)
            .then((res) => {
                TTVisual.InfoBox.Alert(res.toString());
                this.loadingVisible = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.loadingVisible = false;
            });

    }


}
