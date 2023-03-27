import { Component } from '@angular/core';
import { IModal, ModalStateService, ModalInfo } from 'Fw/Models/ModalInfo';
import { NeHttpService } from 'Fw/Services/NeHttpService';
import { DynamicComponentInfo } from 'app/Fw/Models/DynamicComponentInfo';
import { Guid } from 'app/NebulaClient/Mscorlib/Guid';
import * as TTVisual from 'NebulaClient/Visual/TTVisualControlInterfaces';
import { compileDirectiveFromRender2 } from '@angular/compiler/src/render3/view/compiler';
import { Convert } from "NebulaClient/Mscorlib/Convert";
import { MessageIconEnum } from 'app/NebulaClient/Utils/Enums/MessageIconEnum';
import { UploadedDocument } from 'app/NebulaClient/Model/AtlasClientModel';
import { XMLReadDocumentFile } from 'Modules/Saglik_Lojistik/Stok_Modulleri/Sihhiye_Modulleri/Tasinir_Mal_Islem_Modulu/BaseChattelDocumentWithPurchaseForm';
import { SystemParameterService } from 'app/NebulaClient/Services/ObjectService/SystemParameterService';
import { IActiveUserService } from 'app/Fw/Services/IActiveUserService';
import { SendUpdateMessageToMKYSTS_Input } from 'app/NebulaClient/Services/ObjectService/StockActionService';
@Component({
    selector: 'its-component',
    templateUrl: './ITSComponent.html',
})
export class ITSComponent implements IModal {

    public componentInfo: DynamicComponentInfo;
    constructor(private modalStateService: ModalStateService, private http: NeHttpService, protected activeUserService: IActiveUserService) {

        this.priorities = [
            "BARKOD OKUT",
            "SERBEST GİRİŞ"
        ];

        this.sendChangeItems = [
            "İŞLEM NUMARASI İLE", "XML DOSYASI İLE"
        ]

        this.updateTypeItems = [
            "Giriş İşlem No", "İlaç Seç"
        ]
        this.priority = this.priorities[0];
        this.sendChangeItem = this.sendChangeItems[0];
        this.updateTypeItem = this.updateTypeItems[0];
        this.getITSDrug();
        this.controlOfParamater();
    }

    public CollectiveSendITS: boolean = false;
    public drugsListData: Array<ITSDrugList> = new Array<ITSDrugList>();
    public updateDrugsListData: Array<ITSDrugList> = new Array<ITSDrugList>();
    public updateInDrugsListData: Array<ITSDrugList> = new Array<ITSDrugList>();
    public budgetTypeList: Array<BudgetTypeDefinitionDTO> = new Array<BudgetTypeDefinitionDTO>();

    IsDisablePTSReadQRCode: boolean = false;
    IsDisablePTSUnReadQRCode: boolean = true;
    IsITSSendButonDisable: boolean = true;

    public endDate: Date = new Date();
    public startDate: Date = this.endDate.AddMonths(-1);
    public listEndDate: Date = new Date();
    public listStartDate: Date = this.listEndDate.AddMonths(-1);
    public karekodSarfValue: string;
    public qrCodeValue: string;
    public karekodSarfIptalValue: string;
    priorities: string[];
    priority: string;
    sendChangeItems: string[];
    updateTypeItems: string[];
    sendChangeItem: string;
    updateTypeItem: string;
    seletedDrug: Guid;
    selectedUpdateDrugID: Guid;
    selectedInUpdateDrugID: Guid;
    selectedBudgetTypeID: Guid;
    selectDrugCancelItem: Guid;
    ITSDrugLotNO: string;
    ITSDrugLotNOCancel: string;
    ITSDrugSerialNo: string;
    ITSDrugSerialNoCancel: string;
    SarfIptalDVOs: Array<SarfIptalDVO_Output> = new Array<SarfIptalDVO_Output>();
    selectedRows: Array<SarfIptalDVO_Output> = new Array<SarfIptalDVO_Output>();
    ITSNotSerialNoList: Array<ITSNotSerialNo> = new Array<ITSNotSerialNo>();
    selectedITSRows: Array<ITSNotSerialNo> = new Array<ITSNotSerialNo>();
    AllItsDVOList: Array<ITSAllDrugListStatus> = new Array<ITSAllDrugListStatus>();

    SendItsDVOList: Array<ITSSendList> = new Array<ITSSendList>();

    public itsUpdateInTRXOutput: GetInStockTransactionForITS_Output = new GetInStockTransactionForITS_Output();
    public outTRXDataSource: Array<StockTransactionForITS> = new Array<StockTransactionForITS>();
    public inTRXDataSource: Array<StockTransactionForITS> = new Array<StockTransactionForITS>();

    stockActionID: string;
    inStockActionID: string;
    disableUpdateSearch: boolean = false;

    SarfIptalDVOListColumn = [
        {
            caption: 'İlaç Adı',
            dataField: 'DrugName',
            width: 600,
        },
        {
            caption: 'Barcode',
            dataField: 'DrugBarcode',
            width: 200,
        },
        {
            caption: 'Gönderilme Tarihi',
            dataField: 'DrugTransactionDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            width: 200,
        },
        {
            caption: 'Lot /Batch No',
            dataField: 'DrugLotNO',
            width: 200,
        },
        {
            caption: 'Seri No',
            dataField: 'DrugSerialNo',

        }
    ];

    ITSNotSerialNoListColumn = [
        {
            caption: 'Tarih',
            dataField: 'TransactionDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            allowEditing: false,
            width: 200,
        },
        {
            caption: 'Hasta Kabul NO',
            dataField: 'ProtocolNo',
            allowEditing: false,
            width: 200,
        },
        {
            caption: 'Hasta Adı Soyadı',
            dataField: 'PatientNameAndSurname',
            allowEditing: false,
            width: 200,
        },
        {
            caption: 'İlaç',
            dataField: 'DrugName',
            allowEditing: false,
            width: 200,
        },
        {
            caption: 'Barkod',
            dataField: 'DrugNBarcode',
            allowEditing: false,
            width: 200,
        },
        {
            caption: 'Lot No',
            dataField: 'DrugLotNo',
            width: 200,
        },
        {
            caption: 'Seri No',
            dataField: 'DrugSerialNo',
            width: 200,
        }
    ];


    ITSUpdateOutTrxColumn = [
        {
            caption: 'Barkod',
            dataField: 'barcode',
            width: 100,
        },
        {
            caption: 'Taşınır Kodu',
            dataField: 'natoStockNo',
            width: 200,
        },
        {
            caption: 'İlaç',
            dataField: 'materialName',
            width: 400,
        },
        {
            caption: 'Dağıtım Şekli',
            dataField: 'distributionTypeName',
            width: 100,
        },
        {
            caption: 'Giriş Miktarı',
            dataField: 'inAmount',
            width: 100,
        },
        {
            caption: 'Miktar',
            dataField: 'restAmount',
            width: 100,
        },
        {
            caption: 'Okutulacak Miktar',
            dataField: 'readAmount',
            width: 150,
        },
        {
            caption: 'Birim Fiyat',
            dataField: 'unitPrice',
            width: 100,
        },
        {
            caption: 'S.K.T',
            dataField: 'expirationDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            width: 100,
        },
        {
            caption: 'Lot No',
            dataField: 'lotNo',
            width: 150,
        },
        {
            caption: 'Seri No',
            dataField: 'serialNo',
            width: 150,
        },
        {
            caption: 'MKYS Hareket ID',
            dataField: 'mkysHareketID',
            width: 100,
        }
    ];

    ITSUpdateInTrxColumn = [
        {
            caption: 'Barkod',
            dataField: 'barcode',
            allowEditing: false,
            width: 100,
        },
        {
            caption: 'Taşınır Kodu',
            dataField: 'natoStockNo',
            allowEditing: false,
            width: 200,
        },
        {
            caption: 'İlaç',
            dataField: 'materialName',
            allowEditing: false,
            width: 400,
        },
        {
            caption: 'Dağıtım Şekli',
            dataField: 'distributionTypeName',
            allowEditing: false,
            width: 100,
        },
        {
            caption: 'Miktar',
            dataField: 'inAmount',
            width: 100,
        },
        {
            caption: 'Birim Fiyat',
            dataField: 'unitPrice',
            allowEditing: false,
            width: 100,
        },
        {
            caption: 'S.K.T',
            dataField: 'expirationDate',
            dataType: 'date',
            format: 'dd/MM/yyyy',
            allowEditing: false,
            width: 100,
        },
        {
            caption: 'Lot No',
            dataField: 'lotNo',
            allowEditing: false,
            width: 150,
        },
        {
            caption: 'Seri No',
            dataField: 'serialNo',
            allowEditing: false,
            width: 150,
        },
        {
            caption: 'MKYS Hareket ID',
            dataField: 'mkysHareketID',
            allowEditing: false,
            width: 100,
        }
    ];

    async controlOfParamater() {
        let parameter: string = (await SystemParameterService.GetParameterValue("COLLECTIVEITSSEND", "FALSE"));
        if (parameter == "TRUE") {
            this.CollectiveSendITS = true;
        } else {
            this.CollectiveSendITS = false;
        }
    }

    public async setInputParam(value: Object) {

    }



    private _modalInfo: ModalInfo;
    public setModalInfo(value: ModalInfo) {
        this._modalInfo = value;
    }

    public cancelClick(): void {
    }

    public okClick(): void {
    }


    clearData() {
        this.karekodSarfValue = "";
        this.karekodSarfIptalValue = "";
        this.ITSDrugLotNO = "";
        this.ITSDrugSerialNo = "";

    }

    async onValueChangedCombo($event) {
        if ('BARKOD OKUT' === $event.value) {
            this.IsDisablePTSReadQRCode = false;
            this.IsDisablePTSUnReadQRCode = true;
            this.clearData();
        }
        else if ('SERBEST GİRİŞ' === $event.value) {
            this.IsDisablePTSReadQRCode = true;
            this.IsDisablePTSUnReadQRCode = false;
            this.clearData();
        }
    }

    xmlOpen: boolean = false;
    async onValueSendChangedCombo($event) {
        if ('İŞLEM NUMARASI İLE' === $event.value) {
            this.xmlOpen = false;

        }
        else if ('XML DOSYASI İLE' === $event.value) {
            this.xmlOpen = true;

        }
    }

    actionSelect: boolean = true;
    async onValueUpdateTypeChangedCombo($event) {
        if ('Giriş İşlem No' === $event.value) {
            this.actionSelect = true;
            this.selectedInUpdateDrugID = null;
            this.selectedBudgetTypeID = null;
        }
        else if ('İlaç Seç' === $event.value) {
            this.actionSelect = false;
            this.inStockActionID = "";
            this.getBudgetTypeList();
        }
        this.inTRXDataSource = new Array<StockTransactionForITS>();
        this.outTRXDataSource = new Array<StockTransactionForITS>();
        this.disableUpdateSearch = false;
    }

    public getITSDrug() {
        let that = this;
        try {
            let fullApiUrl: string = '/api/DrugDefinitionService/GetITSDrug';
            that.http.post(fullApiUrl, null)
                .then((result) => {
                    that.drugsListData = result as Array<ITSDrugList>;
                    that.updateDrugsListData = result as Array<ITSDrugList>;
                    that.updateInDrugsListData = result as Array<ITSDrugList>;
                })
                .catch(error => {
                });
        }
        catch (ex) {
        }
    }

    public getBudgetTypeList() {
        let that = this;
        try {
            let fullApiUrl: string = '/api/LogisticAddAndUpdate/GetBudgetTypes';
            that.http.post(fullApiUrl, null)
                .then((result) => {
                    that.budgetTypeList = result as Array<BudgetTypeDefinitionDTO>;
                })
                .catch(error => {
                });
        }
        catch (ex) {
        }
    }

    drugListDetail: Array<ITSDetail> = new Array<ITSDetail>();
    selectDrug(data: any) {
        if (data != null) {
            this.seletedDrug = data.itemData.objectID;
            this.drugListDetail = data.itemData.trxLotSerialNo;
        }
    }

    selectDrugCancel(data: any) {
        if (data != null) {
            this.selectDrugCancelItem = data.itemData.objectID;
        }
    }

    async DrugBarcode_KeyPress(event: KeyboardEvent) {
        if (event.charCode === 13) {
            let that = this;
            that.onSarfEtQCodeClick();
        }
    }

    async QRCodeAddIn_KeyPress(event: KeyboardEvent) {
        if (event.charCode === 13) {
            let that = this;
            that.onQCodeReadClick();
        }
    }
    async DrugBarcodeCancelked_KeyPress(event: KeyboardEvent) {
        if (event.charCode === 13) {
            let that = this;
            that.onSarfEtIptalGetGridSource();
        }
    }

    public onEnterKey(e) {
        this.showLoadPanel = true;
        let that = this;
        let input: GetInStockTransactionForITS_Input = new GetInStockTransactionForITS_Input();
        input.stockActionID = that.inStockActionID;
        let fullApiUrl: string = 'api/LogisticAddAndUpdate/GetInStockTransactionForITS';
        this.http.post(fullApiUrl, input)
            .then((res) => {
                that.itsUpdateInTRXOutput = res as GetInStockTransactionForITS_Output;
                if (that.itsUpdateInTRXOutput.error == false) {
                    that.outTRXDataSource = that.itsUpdateInTRXOutput.outTRX;
                    that.disableUpdateSearch = true;
                } else {
                    TTVisual.InfoBox.Alert(that.itsUpdateInTRXOutput.errorMessage);
                }
                this.showLoadPanel = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.showLoadPanel = false;
            });
    }

    public GetOutTrx() {
        this.showLoadPanel = true;
        if (this.selectedInUpdateDrugID != null && this.selectedBudgetTypeID != null) {
            let that = this;
            let input: GetInStockTransactionForITS_Input = new GetInStockTransactionForITS_Input();
            input.materialObjectID = that.selectedInUpdateDrugID;
            input.storeObjectID = that.activeUserService.SelectedUserStore.ObjectID;
            input.budgetTypeID = that.selectedBudgetTypeID;
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/GetInStockTransactionForITS';
            this.http.post(fullApiUrl, input)
                .then((res) => {
                    that.itsUpdateInTRXOutput = res as GetInStockTransactionForITS_Output;
                    if (that.itsUpdateInTRXOutput.error == false) {
                        that.outTRXDataSource = that.itsUpdateInTRXOutput.outTRX;
                        that.disableUpdateSearch = true;
                    } else {
                        TTVisual.InfoBox.Alert(that.itsUpdateInTRXOutput.errorMessage);
                    }
                    this.showLoadPanel = false;
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    this.showLoadPanel = false;
                });
        } else {
            TTVisual.InfoBox.Alert("İlaç ve Bütçe tipi seçmeniz lazım.");
            this.showLoadPanel = false;
        }
    }

    async StockActionID_KeyPress(event: KeyboardEvent) {

        if (this.CollectiveSendITS == false) {
            TTVisual.InfoBox.Alert("Parametre Kapalı Oldugu için işlem devam edilemez.");
            return;
        }

        if (event.charCode === 13) {
            let that = this;
            that.getStockActionITSDetail();
        }
    }

    sendToITSClick() {
        if (this.CollectiveSendITS == false) {
            TTVisual.InfoBox.Alert("Parametre Kapalı Oldugu için işlem devam edilemez.");
            return;
        }

        this.showLoadPanel = true;
        let that = this;
        let input: ITSSendInputDTO = new ITSSendInputDTO();
        input.itsSendList = new Array<ITSSendList>();
        input.itsSendList = this.SendItsDVOList;
        let fullApiUrl: string = 'api/LogisticAddAndUpdate/SendToIts';
        this.http.post(fullApiUrl, input)
            .then((res) => {
                that.SendItsDVOList = res as Array<ITSSendList>;
                this.TotalNumberOfRows = that.SendItsDVOList.length;
                this.showLoadPanel = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.showLoadPanel = false;
            });
    }

    public showLoadPanel: boolean = false;
    public LoadPanelMessage = "İşleminiz Yapılıyor Bekleyiniz...";
    TotalNumberOfRows: number;
    async getStockActionITSDetail() {

        if (String.isNullOrEmpty(this.stockActionID) == true) {
            TTVisual.InfoBox.Alert("Lütfen İşlem Numarasını Giriniz.");
            return;
        }

        this.showLoadPanel = true;
        let that = this;
        let fullApiUrl: string = 'api/LogisticAddAndUpdate/GetStockActionITSDetailrugList?stockActionID=' + this.stockActionID;
        this.http.post(fullApiUrl, null)
            .then((res) => {
                that.SendItsDVOList = res as Array<ITSSendList>;
                this.TotalNumberOfRows = that.SendItsDVOList.length;
                if (this.TotalNumberOfRows > 0)
                    this.IsITSSendButonDisable = false;
                else {
                    TTVisual.InfoBox.Alert("Listelenecek Malzeme Bulunamadı. Lütfen İşlem Numarasını Kontrol Ediniz.");
                    this.IsITSSendButonDisable = true;
                }
                this.showLoadPanel = false;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
                this.showLoadPanel = false;
            });
    }


    document: UploadedDocument = new UploadedDocument();
    async readDocumentItSForPackageClick($event) {

        if (this.CollectiveSendITS == false) {
            TTVisual.InfoBox.Alert("Parametre Kapalı Oldugu için işlem devam edilemez.");
            return;
        }


        this.SendItsDVOList = new Array<ITSSendList>();
        this.showLoadPanel = true;
        let that = this;
        const file: File = $event.target.files[0];
        const fileReader: FileReader = new FileReader();
        if (file.size > 10000000) {
            TTVisual.InfoBox.Alert(i18n("M23736", "Uyarı !"), i18n("M13544", "Eklediğiniz dosyaların boyutu 10 Mb'dan fazla olamaz!"), MessageIconEnum.WarningMessage);
            return;
        }
        fileReader.onloadend = (e) => {
            that.document.FileName = file.name,
                that.document.File = fileReader.result;

            if (that.document.File !== undefined) {
                let inputDVO: XMLReadDocumentFileITS = new XMLReadDocumentFileITS();
                inputDVO.xmlFile = that.document.File.toString();
                inputDVO.xmlFileName = that.document.FileName;
                let apiUrlForInvoiceTerms: string = '/api/LogisticAddAndUpdate/GetItsReceiptNotificationFileRead';
                this.http.post<any>(apiUrlForInvoiceTerms, inputDVO).then((res) => {
                    that.SendItsDVOList = res as Array<ITSSendList>;
                    this.TotalNumberOfRows = that.SendItsDVOList.length;
                    this.showLoadPanel = false;
                }).catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    this.showLoadPanel = false;
                });
            }
        };
        fileReader.readAsText(file);
    }


    async onSarfEtIptalGetGridSource() {
        if (String.isNullOrEmpty(this.karekodSarfIptalValue) == false) {
            let that = this;
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/ITSQCodeReadSarfIptal?qrCode=' + this.karekodSarfIptalValue;
            this.http.post(fullApiUrl, null)
                .then((res) => {
                    that.SarfIptalDVOs = res as Array<SarfIptalDVO_Output>;
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                });
        }
        else {
            TTVisual.InfoBox.Alert("Barkod okutulmadı girilmeden işleme devam edilemez.");
        }
    }

    async onSarfEtQCodeClick() {
        if (String.isNullOrEmpty(this.karekodSarfValue) == false) {
            let that = this;
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/ITSQCodeRead?qrCode=' + this.karekodSarfValue;
            this.http.post(fullApiUrl, null)
                .then((res) => {
                    let result = res as ITSDrugQRCode;
                    that.ITSDrugSerialNo = result.seriNO;
                    that.ITSDrugLotNO = result.lotNo;
                    that.seletedDrug = result.drugObjectID;
                    TTVisual.InfoBox.Alert(result.sonucMesaj);
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                });
        }
        else {
            TTVisual.InfoBox.Alert("Barkod okutulmadı girilmeden işleme devam edilemez.");
        }
    }

    async onQCodeReadClick() {
        if (String.isNullOrEmpty(this.qrCodeValue) == false) {
            let that = this;
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/QRCodeRead?qrCode=' + this.qrCodeValue;
            this.http.post(fullApiUrl, null)
                .then((res) => {
                    let result: StockTransactionForITS = res as StockTransactionForITS;
                    let findOutTrx: StockTransactionForITS = this.outTRXDataSource.find(x => x.materialObjectID === result.materialObjectID && x.expirationDate == result.expirationDate);
                    let findInTrx: StockTransactionForITS = this.inTRXDataSource.find(x => x.materialObjectID === result.materialObjectID &&
                        x.lotNo === result.lotNo && x.serialNo == result.serialNo && x.expirationDate == result.expirationDate);
                    if (findInTrx != null) {
                        TTVisual.InfoBox.Alert("Bu kare kod daha önce okutulmuştur.");
                        this.qrCodeValue = "";
                    } else {
                        if (findOutTrx != null) {
                            if (findOutTrx.readAmount > 0) {
                                result.mkysHareketID = findOutTrx.mkysHareketID;
                                result.unitPrice = findOutTrx.unitPrice;
                                if (findOutTrx.readAmount < result.inAmount)
                                    result.inAmount = findOutTrx.readAmount;
                                findOutTrx.readAmount = findOutTrx.readAmount - result.inAmount;
                                result.stockTransactionObjectID = findOutTrx.stockTransactionObjectID;
                                that.inTRXDataSource.push(result);
                                this.qrCodeValue = "";
                            } else if (findOutTrx.readAmount === 0) {
                                TTVisual.InfoBox.Alert(result.materialName + " okutulması gereken kare kod kalmadı.");
                                this.qrCodeValue = "";
                            }
                        } else {
                            TTVisual.InfoBox.Alert("Okutulan İlaç: " + result.materialName + " güncellenecek listede bulunamadı.");
                            this.qrCodeValue = "";
                        }
                    }
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                    this.qrCodeValue = "";
                });
        }
        else {
            TTVisual.InfoBox.Alert("Barkod okutulmadı girilmeden işleme devam edilemez.");
        }
    }


    public async inTRXGridUpdating(event: any) {
        if (event.newData.inAmount != null) {
            if (event.newData.inAmount > event.oldData.restAmount) {
                event.newData.inAmount = event.oldData.inAmount;
                TTVisual.InfoBox.Alert("Kutuda " + event.oldData.restAmount.toString() + " ilaç bulunmaktadır. Bundan fazla yazamazsınız.");
            } else {
                let updateOutTrx: StockTransactionForITS = this.outTRXDataSource.find(x => x.stockTransactionObjectID === event.oldData.stockTransactionObjectID);
                if (event.oldData.inAmount > event.newData.inAmount)
                    updateOutTrx.readAmount = updateOutTrx.readAmount + (event.oldData.inAmount - event.newData.inAmount);
                if (event.oldData.inAmount < event.newData.inAmount)
                    updateOutTrx.readAmount = updateOutTrx.readAmount - (event.newData.inAmount - event.oldData.inAmount);
            }
        }
    }

    public updateToTransaction() {
        let update: boolean = true;
        this.outTRXDataSource.forEach(outElement => {
            if (outElement.readAmount > 0) {
                TTVisual.InfoBox.Alert(outElement.materialName + " ilacın bütün karekodları okutulmamış.");
                update = false;
            }
            let inAmount: number = 0;
            for (let intrx of this.inTRXDataSource.filter(x => x.stockTransactionObjectID === outElement.stockTransactionObjectID)) {
                inAmount = inAmount + intrx.inAmount;
            }
            if (outElement.restAmount != inAmount) {
                TTVisual.InfoBox.Alert(outElement.materialName + " ilacın okutulan karekodlarının miktarı yanlış lütfen kontrol ediniz.");
                update = false;
            }
        });
        if (update)
            this.toUpdate();
    }


    async toUpdate() {
        let that = this;
        let input: CreateITSFixedAction_Input = new CreateITSFixedAction_Input();
        input.StoreObjectID = that.activeUserService.SelectedUserStore.ObjectID;
        input.inTrxs = that.inTRXDataSource;
        input.outTrxs = that.outTRXDataSource;
        let fullApiUrl: string = 'api/LogisticAddAndUpdate/CreateITSFixedAction';
        this.http.post(fullApiUrl, input)
            .then((res) => {
                let result: CreateITSFixedAction_Output = res as CreateITSFixedAction_Output;
                TTVisual.InfoBox.Alert(result.resultMessage);
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }

    async onSarfEtButonClick() {
        if (String.isNullOrEmpty(this.ITSDrugLotNO) == false && String.isNullOrEmpty(this.ITSDrugSerialNo) == false) {
            let detailLot = this.drugListDetail.find(x => x.lotNO == this.ITSDrugLotNO && x.serialNo == this.ITSDrugSerialNo);
            if (detailLot == null) {
                TTVisual.InfoBox.Alert("Seçili ilaç için LOT ve SERİ NUMARASI uyuşmamaktadır.");
            }
            else {
                let that = this;
                let inputDvo = new SarfBildirimi_Input();
                inputDvo.StockTransaction = detailLot.trxObjectid;
                let fullApiUrl: string = 'api/LogisticAddAndUpdate/ITSSarfBildir';
                this.http.post(fullApiUrl, inputDvo)
                    .then((res) => {
                        let result = res;
                    })
                    .catch(error => {
                        TTVisual.InfoBox.Alert(error);
                    });
            }
        }
        else {
            TTVisual.InfoBox.Alert("LOT ve SERİ NUMARASI girilmeden işleme devam edilemez.");
        }
    }

    async onSarfIptalButonClick() {
        let that = this;
        if (that.selectedRows != null) {
            if (that.selectedRows.length > 0) {
                let inputDVO: Array<SarfIptalDVO_Output> = new Array<SarfIptalDVO_Output>();
                inputDVO = that.selectedRows;
                let fullApiUrl: string = 'api/LogisticAddAndUpdate/SarfIptalSelectedMaterials';
                this.http.post(fullApiUrl, inputDVO)
                    .then((res) => {
                        TTVisual.InfoBox.Alert(res.toString());
                    })
                    .catch(error => {
                        TTVisual.InfoBox.Alert(error);
                    });
            }
        } else {
            TTVisual.InfoBox.Alert("Seçim yapılmadan devam edilemez.");
        }
    }

    async getAllITSTransactionDrugList() {
        let that = this;
        try {
            let fullApiUrl: string = '/api/DrugDefinitionService/GetAllITSDrugStatus';
            that.http.post(fullApiUrl, null)
                .then((result) => {
                    that.AllItsDVOList = result as Array<ITSAllDrugListStatus>;
                })
                .catch(error => {
                });
        }
        catch (ex) {
        }
    }

    async getDrugList() {
        let that = this;
        let inputDVO: SarfIptalDVO_Input = new SarfIptalDVO_Input();
        inputDVO.drugObjectID = that.selectDrugCancelItem;
        inputDVO.trxStartDate = Convert.ToDateTime(that.startDate.ToShortDateString() + " 00:00:00");
        inputDVO.trxEndDate = Convert.ToDateTime(that.endDate.ToShortDateString() + " 23:59:59");
        inputDVO.seriNo = that.ITSDrugSerialNoCancel;
        inputDVO.lotNo = that.ITSDrugLotNOCancel;
        let fullApiUrl: string = 'api/LogisticAddAndUpdate/GetITSDrugList';
        this.http.post(fullApiUrl, inputDVO)
            .then((res) => {
                that.SarfIptalDVOs = res as Array<SarfIptalDVO_Output>;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }

    onITSSerialNo() {
        let input: ITSNotSerialNoList_Input = new ITSNotSerialNoList_Input();
        input.startDate = this.listStartDate;
        input.endDate = this.listEndDate;
        input.selectedDrugID = this.selectedUpdateDrugID;
        let that = this;
        let fullApiUrl: string = 'api/LogisticAddAndUpdate/ITSNotSerialNoList';
        this.http.post(fullApiUrl, input)
            .then((res) => {
                that.ITSNotSerialNoList = res as Array<ITSNotSerialNo>;
            })
            .catch(error => {
                TTVisual.InfoBox.Alert(error);
            });
    }
    saveITSSerialNo() {
        let that = this;
        if (this.selectedITSRows.length > 0) {
            let inputDVO: Array<ITSNotSerialNo> = new Array<ITSNotSerialNo>();
            inputDVO = this.selectedITSRows;
            let fullApiUrl: string = 'api/LogisticAddAndUpdate/UpdateSerialNO';
            this.http.post(fullApiUrl, inputDVO)
                .then((res) => {
                    let returnMessage = res as string;
                    TTVisual.InfoBox.Alert(returnMessage);
                    this.onITSSerialNo();
                })
                .catch(error => {
                    TTVisual.InfoBox.Alert(error);
                });
        }
    }
}

export class XMLReadDocumentFileITS {
    xmlFileName: string;
    xmlFile: string;

}


export class SarfBildirimi_Input {
    StockTransaction: Guid;
}

export class SarfIptalDVO_Input {
    drugObjectID: Guid;
    trxStartDate: Date;
    trxEndDate: Date;
    lotNo: string;
    seriNo: string;
}

export class SarfIptalDVO_Output {
    DrugName: string;
    DrugBarcode: string;
    DrugLotNO: string;
    DrugSerialNo: string;
    DrugTransactionDate: Date;
    StockTransaction: Guid;
}

export class ITSDrugQRCode {
    drugObjectID: Guid;
    lotNo: string;
    seriNO: string;
    sonucMesaj: string;
}

export class ITSDrug {
    DrugName: string;
    DrugBarcode: string;
    DrugLotNO: string;
    DrugSerialNo: string;
    DrugStartDate: Date;
    DrugEndDate: Date;
}
export class ITSDrugList {
    objectID: Guid;
    drugNameBarcode: string;
    trxLotSerialNo: Array<ITSDetail> = new Array<ITSDetail>();
}

export class ITSDetail {
    trxObjectid: Guid;
    lotNO: string;
    serialNo: string;
}

export class ITSNotSerialNo {
    DrugName: string;
    DrugBarcode: string;
    DrugLotNO: string;
    DrugSerialNo: string;
    TransactionDate: Date;
    PatientNameAndSurname: string;
    ProtocolNo: string;
    StockTransactionObjID: Guid;
}

export class ITSAllDrugListStatus {
    public objectID: Guid
    public drugName: string;
    public drugBarcode: string;
    public detail: Array<ITSAllDrugListStatusDetail> = new Array<ITSAllDrugListStatusDetail>();
}
export class ITSAllDrugListStatusDetail {
    public lotNO: string;
    public serialNo: string;
    public status: string;
}

export class ITSSendList {
    public StockTransactionObjectID: Guid
    public drugName: string;
    public drugBarcode: string;
    public lotNO: string;
    public serialNo: string;
    public status: string;
}

export class ITSSendInputDTO {
    public itsSendList: Array<ITSSendList>;
}

export class ITSNotSerialNoList_Input {
    public startDate: Date;
    public endDate: Date;
    public selectedDrugID: Guid;
}

export class GetInStockTransactionForITS_Input {
    public stockActionID: string;
    public materialObjectID: Guid;
    public storeObjectID: Guid;
    public budgetTypeID: Guid;
}

export class GetInStockTransactionForITS_Output {
    public error: boolean;
    public errorMessage: string;
    public outTRX: Array<StockTransactionForITS> = new Array<StockTransactionForITS>();
}

export class StockTransactionForITS {
    public stockTransactionObjectID: Guid;
    public natoStockNo: string;
    public barcode: string;
    public materialObjectID: Guid;
    public materialName: string;
    public distributionTypeName: string;
    public inAmount: number;
    public restAmount: number;
    public readAmount: number;
    public unitPrice: number;
    public expirationDate: Date;
    public lotNo: string;
    public serialNo: string;
    public mkysHareketID: number;
}

export class CreateITSFixedAction_Input {
    public StoreObjectID: Guid;
    public outTrxs: Array<StockTransactionForITS> = new Array<StockTransactionForITS>();
    public inTrxs: Array<StockTransactionForITS> = new Array<StockTransactionForITS>();
}

export class CreateITSFixedAction_Output {
    public result: boolean;
    public resultMessage: string;
}

export class BudgetTypeDefinitionDTO {
    public ObjectID: Guid;
    public Name: Guid;
}