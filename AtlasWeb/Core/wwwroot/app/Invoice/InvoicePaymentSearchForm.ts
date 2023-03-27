//$848D7985
import { Component, OnInit } from '@angular/core';
import { InvoicePaymentSearchFormModel, InvoicePaymentSearchResultModel, InvoicePaymentSearchModel, InvoiceCollectionSelectNewPayment, IsReadOnly } from "./InvoicePaymentSearchFormViewModel";
import { ITTListDefComboBox } from 'NebulaClient/Visual/ControlInterfaces/ITTListDefComboBox';
import { ITTObjectListBox } from 'NebulaClient/Visual/ControlInterfaces/ITTObjectListBox';
import { ITTEnumComboBox } from 'NebulaClient/Visual/ControlInterfaces/ITTEnumComboBox';
import { ITTTextBox } from 'NebulaClient/Visual/ControlInterfaces/ITTTextBox';
import { ITTMaskedTextBox } from 'NebulaClient/Visual/ControlInterfaces/ITTMaskedTextBox';
import { ITTButton } from 'NebulaClient/Visual/ControlInterfaces/ITTButton';
import { CharacterCasing } from 'NebulaClient/Utils/Enums/CharacterCasing';
import { HorizontalAlignment } from 'NebulaClient/Utils/Enums/HorizontalAlignment';
import { InputFormat } from 'NebulaClient/Utils/Enums/InputFormat';
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { InvoicePaymentDetailModel, listboxObject } from './InvoiceHelperModel';
import { InvoicePaymentFormModel } from "./InvoicePaymentFormViewModel";
import { InvoiceCollectionDetail } from 'NebulaClient/Model/AtlasClientModel';
import { ShowBox } from 'NebulaClient/Visual/ShowBox';
import { ITTValueListBox } from 'app/NebulaClient/Visual/ControlInterfaces/ITTValueListBox';

@Component({
    selector: "invoice-payment-search-form",
    templateUrl: './InvoicePaymentSearchForm.html'
})

export class InvoicePaymentSearchForm implements OnInit {

    public invoicePaymentSearchFormModel: InvoicePaymentSearchFormModel;
    public NewPaymentInvoiceCollectionList: Array<InvoiceCollectionSelectNewPayment>;
    public NewPaymentInvoiceCollectionDetailList: Array<InvoicePaymentDetailModel>;
    public ReadOnly: IsReadOnly = new IsReadOnly(false);
    public SavedReadOnly: IsReadOnly = new IsReadOnly(true);
    public selectedICDs: Array<InvoicePaymentDetailModel>;

    cmbTerm: ITTListDefComboBox = <ITTListDefComboBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'InvoiceTermList',
        ShowClearButton: true,
    };
    cmbState: ITTEnumComboBox = <ITTEnumComboBox>{
        Visible: true,
        ReadOnly: false,
        DataTypeName: "InvoicePaymentStateEnum",
        ShowClearButton: true,
    };
    cmbPayer: ITTObjectListBox = <ITTObjectListBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'PayerListDefinition',
        ShowClearButton: true
    };
    cmbNewPaymentPayer: ITTObjectListBox = <ITTObjectListBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'PayerListDefinition',
        ShowClearButton: true
    };
    cmbUser: ITTObjectListBox = <ITTObjectListBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'UserListDefinition',
        ShowClearButton: true,
    };
    cmbBankAccount: ITTObjectListBox = <ITTObjectListBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'BankAccountListDefinition',
        ShowClearButton: true,
    };
    txtMaskedPrice: ITTMaskedTextBox = <ITTMaskedTextBox>{
        Visible: true,
        ReadOnly: false,
        Mask: "00000000",
        TextAlign: HorizontalAlignment.Left
    };
    txtText: ITTTextBox = <ITTTextBox>{
        Visible: true,
        ReadOnly: false,
        CharacterCasing: CharacterCasing.Lower,
        TextAlign: HorizontalAlignment.Left,
        InputFormat: InputFormat.AlphaOnly
    };
    btnList: ITTButton = <ITTButton>{
        Visible: true,
        ReadOnly: false,
        Text: "Listele"
    };
    cmbPayerType: ITTValueListBox = <ITTValueListBox>{
        Visible: true,
        ReadOnly: false,
        ListDefName: 'PayerTypeListDefinition',
        AutoCompleteDialogWidth: '30%'
    };


    public lastXDaysForInvoiceCollection = [
        {
            Name: "5",
            ObjectID: 5
        },
        {
            Name: "10",
            ObjectID: 10
        }, {
            Name: "15",
            ObjectID: 15
        },
        {
            Name: "30",
            ObjectID: 30
        },
        {
            Name: "45",
            ObjectID: 45
        },
        {
            Name: "60",
            ObjectID: 60
        }
    ];

    //ResultGridHeight: number;

    public newPaymentFormModel: InvoicePaymentFormModel = new InvoicePaymentFormModel();

    public savedPaymentFormModel: InvoicePaymentFormModel = new InvoicePaymentFormModel();

    public InvoicePaymentListColumns = [
        {
            caption: i18n("M18009", "Kurum"),
            dataField: "Payer"
        },
        {
            caption: "Durum",
            dataField: "StateDisplayText",
            width: 70
        },
        {
            caption: i18n("M12545", "Dekont No"),
            dataField: "DecountNo",
            width: 80
        },
        {
            caption: i18n("M12547", "Dekont Tarihi"),
            dataField: "DecountDate",
            format: "dd/MM/yyyy",
            dataType: "date",
            width: 100
        },
        {
            caption: "Tahsilat Tutarı",
            dataField: "TotalPrice",
            width: 110
        },
        {
            caption: i18n("M17512", "Kesinti Tutarı"),
            dataField: "Deduction",
            width: 110
        }
    ];

    public NewPaymentInvoiceCollectionListColumns = [
        {
            caption: "Icmal No",
            dataField: "No",
            width: 80,
            fixed: true
        },
        {
            caption: i18n("M16122", "İcmal Adı"),
            dataField: "Name",
            width: 100,
            fixed: true
        },
        {
            caption: "Tarih",
            dataField: "Date",
            format: "dd/MM/yyyy",
            dataType: "date",
            width: 85,
            fixed: true
        },
        {
            caption: "Durum",
            dataField: "StateDisplayText",
            width: 80,
            fixed: true
        },
        {
            caption: i18n("M18009", "Kurum"),
            dataField: "Payer.Name",
            width: 'auto',
            fixed: true
        },
        {
            caption: i18n("M14190", "Fatura Sayısı"),
            dataField: "InvoiceCount",
            width: 110,
            fixed: true
        },
        {
            caption: i18n("M14220", "Fatura Tutarı"),
            dataField: "InvoicePrice",
            width: 'auto',
        },
        {
            caption: "Dönem",
            dataField: "TermName",
            width: 100,
        },
        {
            caption: "Son Ödeme Tarihi",
            dataField: "LastPaymentDate",
            format: "dd/MM/yyyy",
            dataType: "date",
            width: 'auto'
        },
    ];

    public NewInvoicePaymentDetailListColumns = [
        {
            caption: i18n("M22936", "TC Kimlik No"),
            dataField: "UniqueRefNo",
        },
        {
            caption: i18n("M10517", "Adı Soyadı"),
            dataField: "PatientName",
            width: '15%'
        },
        {
            caption: i18n("M17021", "Kabul No"),
            dataField: "EpisodeID",
        },
        {
            caption: i18n("M13372", "Durumu"),
            dataField: "StatusDisplayText",
        },
        {
            caption: i18n("M14205", "Fatura Tarihi"),
            dataField: "InvoiceDate",
        },
        {
            caption: i18n("M14179", "Fatura No"),
            dataField: "InvoiceNo",
        },
        {
            caption: i18n("M14220", "Fatura Tutarı"),
            dataField: "InvoicePrice",
        },
        {
            caption: i18n("M17087", "Kalan Tutar"),
            dataField: "InvoiceRestPrice",
        },
        {
            caption: i18n("M17508", "Kesinti"),
            dataField: "Deduction",
        },
        {
            caption: i18n("M18009", "Kurum"),
            dataField: "PayerName"
        }
    ];

    public stateArray = [
        {
            Name: i18n("M19880", "Ödendi"),
            Value: "Paid"
        },
        {
            Name: i18n("M16526", "İptal"),
            Value: "Cancelled"
        }
    ];

    constructor(protected http: NeHttpService) {
        this.savedPaymentFormModel = new InvoicePaymentFormModel();
        this.newPaymentFormModel = new InvoicePaymentFormModel();

        this.invoicePaymentSearchFormModel = new InvoicePaymentSearchFormModel();
        // $(window).resize(x => {
        //     this.ResultGridHeight = parseInt($('#invoicePayment-grid-container').css('height'));
        // });
        // $(window).ready(x => {
        //     this.ResultGridHeight = parseInt($('#invoicePayment-grid-container').css('height'));
        // });
    }

    ngOnInit(): void {

    }

    async btnListClicked(triggered: boolean): Promise<void> {

        let apiUrlForInvoicePayments: string = '/api/InvoicePaymentApi/InvoicePaymentSearch';

        this.http.post<InvoicePaymentSearchResultModel[]>(apiUrlForInvoicePayments, this.invoicePaymentSearchFormModel.InvoicePaymentSearchModel).then(response => {
            if (response !== null) {
                this.invoicePaymentSearchFormModel.InvoicePaymentSearchResultModel = response;
            }
            else {
                this.invoicePaymentSearchFormModel.InvoicePaymentSearchResultModel = new Array<InvoicePaymentSearchResultModel>();
            }
        })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);
            });
    }

    public selectedPayer: any = null;
    public async onCmbTermChanged(data: any) {
        this.invoicePaymentSearchFormModel.newPaymentTerm = data;
        await this.payerSelection_ValueChanged(this.selectedPayer);
    }

    public async onNewPaymentPayerTypeChanged(data: any) {
        this.invoicePaymentSearchFormModel.newPaymentPayerType = data;
        await this.payerSelection_ValueChanged(this.selectedPayer);
    }

    public async onNewPaymentRemainingTimeChanged(event: any) {
        this.invoicePaymentSearchFormModel.newPaymentRemainingPaymentTime = event.value;
        await this.payerSelection_ValueChanged(this.selectedPayer);
    }

    public async onLastPaymentRemainingTimeChanged(event: any) {
        this.invoicePaymentSearchFormModel.lastPaymentDate = event.value;
        await this.payerSelection_ValueChanged(this.selectedPayer);
    }


    async payerSelection_ValueChanged(data: any): Promise<void> {

        //console.log(`payerSelection_ValueChanged event called: ${new Date()}`);
        this.selectedPayer = data;
        let apiUrlForInvoicePayments: string = '/api/InvoicePaymentApi/GetInvoiceCollectionFromPayer';
        if (this.selectedPayer != null || this.invoicePaymentSearchFormModel.newPaymentTerm != null || this.invoicePaymentSearchFormModel.newPaymentPayerType != null || this.invoicePaymentSearchFormModel.newPaymentRemainingPaymentTime != null || this.invoicePaymentSearchFormModel.lastPaymentDate != null) {
            let input = {
                payerObjectID: this.selectedPayer != null ? this.selectedPayer.ObjectID : null,
                termObjectID: this.invoicePaymentSearchFormModel.newPaymentTerm != null ? this.invoicePaymentSearchFormModel.newPaymentTerm : null,
                payerType: this.invoicePaymentSearchFormModel.newPaymentPayerType != null ? this.invoicePaymentSearchFormModel.newPaymentPayerType : null,
                remainingPaymentTime: this.invoicePaymentSearchFormModel.newPaymentRemainingPaymentTime != null ? this.invoicePaymentSearchFormModel.newPaymentRemainingPaymentTime : null,
                lastPaymentDate: this.invoicePaymentSearchFormModel.lastPaymentDate != null ? this.invoicePaymentSearchFormModel.lastPaymentDate : null
            };
            this.http.post<InvoiceCollectionSelectNewPayment[]>(apiUrlForInvoicePayments, input).then(response => {
                if (response !== null) {
                    this.NewPaymentInvoiceCollectionList = response;
                }
                else {
                    this.NewPaymentInvoiceCollectionList = new Array<InvoiceCollectionSelectNewPayment>();
                }
                this.NewPaymentInvoiceCollectionDetailList = new Array<InvoicePaymentDetailModel>();

                this.newPaymentFormModel = new InvoicePaymentFormModel();

                this.newPaymentFormModel.InvoicePayment.Payer = new listboxObject();
                this.newPaymentFormModel.InvoicePayment.Payer.ObjectID = this.selectedPayer != null ? this.selectedPayer.ObjectID : null;
                this.newPaymentFormModel.InvoicePayment.Payer.Name = this.selectedPayer != null ? this.selectedPayer.Name : '';
                this.newPaymentFormModel.InvoicePayment.Payer.Code = this.selectedPayer != null ? this.selectedPayer.Code : '';
            })
                .catch(error => {
                    ServiceLocator.MessageService.showError(error);
                    this.NewPaymentInvoiceCollectionList = new Array<InvoiceCollectionSelectNewPayment>();
                });
        }
        else {
            this.NewPaymentInvoiceCollectionDetailList = new Array<InvoicePaymentDetailModel>();
            this.NewPaymentInvoiceCollectionList = new Array<InvoiceCollectionSelectNewPayment>();
        }
    }

    async loadInvoiceCollectionDetail(event: any): Promise<void> {
        let component = event.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {

            // let apiUrlForLoadICD: string = '/api/InvoicePaymentApi/GetInvoiceCollectionDetailFromIC?ICObjectID=' + event.data.ObjectID;
            // this.http.get<Array<InvoicePaymentDetailModel>>(apiUrlForLoadICD).then(response => {
            //     this.NewPaymentInvoiceCollectionDetailList = response;
            // })
            //     .catch(error => {
            //         ServiceLocator.MessageService.showError(error);
            //     });
            this.selectedIC = event.data;

            this.loadICDFromIC(event.data.ObjectID);


        }

    }

    async loadInvoicePayment(event: any): Promise<void> {
        let component = event.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {

            let apiUrlForLoadICD: string = '/api/InvoicePaymentApi/GetPayerInvoicePayment?PIPObjectID=' + event.data.ObjectID;

            this.http.get<InvoicePaymentFormModel>(apiUrlForLoadICD).then(response => {
                this.savedPaymentFormModel = response;
            })
                .catch(error => {
                    ServiceLocator.MessageService.showError(error);
                });
        }
    }

    async btnUniqueIDSearchClicked(): Promise<void> {
        let apiUrlForLoadICD: string = '/api/InvoicePaymentApi/GetFromUniqueID?UniqueID=' + this.invoicePaymentSearchFormModel.newPaymentUniqueID;

        this.http.get<Array<InvoicePaymentDetailModel>>(apiUrlForLoadICD).then(response => {
            this.NewPaymentInvoiceCollectionDetailList = response;
        })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);
            });
    }

    async btnInvoiceNoSearchClicked(): Promise<void> {
        let apiUrlForLoadICD: string = '/api/InvoicePaymentApi/GetFromInvoiceNo?InvoiceNo=' + this.invoicePaymentSearchFormModel.newPaymentInvoiceNo;

        this.http.get<Array<InvoicePaymentDetailModel>>(apiUrlForLoadICD).then(response => {
            this.NewPaymentInvoiceCollectionDetailList = response;
        })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);
            });
    }

    userSearchModelLoaded(value) {
        if (value != null)
            this.invoicePaymentSearchFormModel.InvoicePaymentSearchModel = JSON.parse(value);
        else
            this.invoicePaymentSearchFormModel.InvoicePaymentSearchModel = new InvoicePaymentSearchModel();
    }

    public uniqueIDSearchKeypress(event: KeyboardEvent) {
        if (event.charCode === 13) {
            this.btnUniqueIDSearchClicked();
            return;
        }
    }
    public invoiceNoSearchKeyPress(event: KeyboardEvent) {
        if (event.charCode === 13) {
            this.btnInvoiceNoSearchClicked();
            return;
        }
    }

    public selectedIC: InvoiceCollectionSelectNewPayment;

    loadICDFromIC(ICObjectID: string) {
        let apiUrlForLoadICD: string = '/api/InvoicePaymentApi/GetInvoiceCollectionDetailFromIC?ICObjectID=' + ICObjectID;
        this.http.get<Array<InvoicePaymentDetailModel>>(apiUrlForLoadICD).then(response => {
            this.NewPaymentInvoiceCollectionDetailList = response;
        })
            .catch(error => {
                ServiceLocator.MessageService.showError(error);
            });
    }

    public actionResult: any;

    InvoicePaymentActionExecuted(event: any) {
        if (this.selectedIC != null)
            this.loadICDFromIC(this.selectedIC.ObjectID);
        this.actionResult = event;
    }

    onRowClickNewPaymentDetailList(event: any): void {
        let component = event.component,
            prevClickTime = component.lastClickTime;
        component.lastClickTime = new Date();
        if (prevClickTime && (component.lastClickTime - prevClickTime < 300)) {

            if (this.actionResult != null && this.actionResult.Paid == true) {
                this.newPaymentFormModel = new InvoicePaymentFormModel();
                this.ReadOnly = new IsReadOnly(false);
                this.SavedReadOnly = new IsReadOnly(true);
            }

            this.addDetailToNewPayment(event.data);
        }
    }
    addWithControlTotalPayment(): void {
        let added = true;

        if (this.invoicePaymentSearchFormModel.newPaymentControlTotalPayment == 0 || this.invoicePaymentSearchFormModel.newPaymentControlTotalPayment == undefined || this.invoicePaymentSearchFormModel.newPaymentControlTotalPayment == null)
            ServiceLocator.MessageService.showError(i18n("M17827", "Kontrollü ekleme yapabilmek için ilk önce Dekont Tutar Kontrolü alanı doldurulmalıdır."));
        else if (this.NewPaymentInvoiceCollectionDetailList == null || this.NewPaymentInvoiceCollectionDetailList.length == 0) {
            ServiceLocator.MessageService.showError(i18n("M17828", "Kontrollü ekleme yapabilmek için ilk önce İcmal Detay Listesi dolu olmalıdır."));
        }
        else {
            for (let item of this.NewPaymentInvoiceCollectionDetailList) {
                if (added)
                    added = this.addDetailToNewPayment(item);
            }
        }
    }

    addDetailToNewPayment(data: any): boolean {
        let found: boolean = false;
        let totalAddedPrice: number = 0.0;
        for (let item of this.newPaymentFormModel.InvoicePaymentDetailList) {
            if (item.InvoiceCollectionDetailID == data.InvoiceCollectionDetailID) {
                found = true;
            }
            totalAddedPrice += item.Payment;
        }
        if (data.IsTermOpen) {
            ServiceLocator.MessageService.showError(data.TermName + i18n("M13317", " dönemi açık olduğundan icmal detayı tahsilat eklenemez."));
            return false;
        }
        if (this.invoicePaymentSearchFormModel.newPaymentControlTotalPayment != 0 && this.invoicePaymentSearchFormModel.newPaymentControlTotalPayment != undefined
            && this.invoicePaymentSearchFormModel.newPaymentControlTotalPayment != null) {

            if (totalAddedPrice >= this.invoicePaymentSearchFormModel.newPaymentControlTotalPayment) {
                ServiceLocator.MessageService.showError(i18n("M12549", "Dekont tutar kontrolü için girilen tutar aşıldı. Tahsilata yeni icmal detay ı eklenemez."));
                return false;
            }
            else if (totalAddedPrice + parseFloat(data.InvoiceRestPrice) > this.invoicePaymentSearchFormModel.newPaymentControlTotalPayment) {
                if (!found && data.ICDCurrentStateDefID != InvoiceCollectionDetail.InvoiceCollectionDetailStates.Paid) {
                    data.Payment = Math.Round(data.InvoiceRestPrice - ((totalAddedPrice + data.InvoiceRestPrice) - this.invoicePaymentSearchFormModel.newPaymentControlTotalPayment), 2);
                    this.pushInvoicePaymentDetailList(data);
                }
                else
                    ServiceLocator.MessageService.showError(i18n("M12460", "Daha önce eklenmiş veya tamamı ödenmiş detaylar yeni tahsilat için eklenemez."));
            }
            else {
                if (!found && data.ICDCurrentStateDefID != InvoiceCollectionDetail.InvoiceCollectionDetailStates.Paid) {
                    data.Payment = data.InvoiceRestPrice;
                    this.pushInvoicePaymentDetailList(data);
                }
                else
                    ServiceLocator.MessageService.showError(i18n("M12460", "Daha önce eklenmiş veya tamamı ödenmiş detaylar yeni tahsilat için eklenemez."));
            }
        }
        else {
            if (!found && data.ICDCurrentStateDefID != InvoiceCollectionDetail.InvoiceCollectionDetailStates.Paid) {
                data.Payment = data.InvoiceRestPrice;
                this.pushInvoicePaymentDetailList(data);
            }
            else
                ServiceLocator.MessageService.showError(i18n("M12460", "Daha önce eklenmiş veya tamamı ödenmiş detaylar yeni tahsilat için eklenemez."));
        }
        return true;
    }

    pushInvoicePaymentDetailList(data: any): void {
        data.Deduction = 0;

        if (data.PayerObjectID != this.newPaymentFormModel.InvoicePayment.Payer.ObjectID && this.newPaymentFormModel.InvoicePayment.Payer.ObjectID != null
            && this.newPaymentFormModel.InvoicePayment.Payer.ObjectID != undefined)
            ServiceLocator.MessageService.showError("Tahsilat için belirlenmiş kurum ile tahsilat detayına eklenen icmal detayın bağlı olduğu icmalin kurum bilgileri tutarlı olmalıdır.");
        else {
            data.InvoiceRestPrice = data.InvoiceRestPrice;
            this.newPaymentFormModel.InvoicePaymentDetailList.push(data);

            if (this.newPaymentFormModel.InvoicePayment == null || this.newPaymentFormModel.InvoicePayment.Payer == null ||
                this.newPaymentFormModel.InvoicePayment.Payer.ObjectID == null || this.newPaymentFormModel.InvoicePayment.Payer.Name == null
                || this.newPaymentFormModel.InvoicePayment.Payer.Code == null || this.newPaymentFormModel.InvoicePayment.Payer.Name == undefined
                || this.newPaymentFormModel.InvoicePayment.Payer.Code == "") {
                this.newPaymentFormModel.InvoicePayment.Payer = new listboxObject();
                this.newPaymentFormModel.InvoicePayment.Payer.ObjectID = data.PayerObjectID;
                this.newPaymentFormModel.InvoicePayment.Payer.Name = data.PayerName;
                this.newPaymentFormModel.InvoicePayment.Payer.Code = "";
            }
        }

    }
    keypressPaymentPrice(event: KeyboardEvent) {
        if (event.charCode === 44)
            return false;
        if (isNaN(parseInt(event.key)) && event.charCode !== 46)
            return false;
    }


    clearNewInvoicePaymentClick(): void {
        let that = this;
        ShowBox.Show(1, '&Evet,&Hayır', 'OK,CANCEL', i18n("M23735", "Uyarı"), '', i18n("M13584", "Ekrandaki veriler temizlenecektir. Emin misiniz?"), 1).then(result => {
            if (result === "OK") {
                that.newPaymentFormModel = new InvoicePaymentFormModel();
                that.NewPaymentInvoiceCollectionDetailList = new Array<InvoicePaymentDetailModel>();
                that.NewPaymentInvoiceCollectionList = new Array<InvoiceCollectionSelectNewPayment>();
                that.invoicePaymentSearchFormModel.newPaymentPayer = new listboxObject();
                that.invoicePaymentSearchFormModel.newPaymentInvoiceNo = "";
                that.invoicePaymentSearchFormModel.newPaymentUniqueID = "";
                that.invoicePaymentSearchFormModel.newPaymentTerm = null;
                that.invoicePaymentSearchFormModel.newPaymentRemainingPaymentTime = null;
                that.invoicePaymentSearchFormModel.lastPaymentDate = null;
                that.invoicePaymentSearchFormModel.newPaymentPayerType = null;
                let temp: IsReadOnly = new IsReadOnly(false);
                that.ReadOnly = temp;
            }
        });

    }
    onContextMenuPreparingNewPaymentDetailList(e: any): void {
        let that = this;
        if (e.row !== undefined && e.row !== null) {

            if (e.row.rowType === 'data') {
                e.items = [{
                    text: 'Toplu Ekle',
                    onItemClick: function () {
                        let added = true;
                        for (let item of that.selectedICDs) {
                            if (added)
                                added = that.addDetailToNewPayment(item);
                        }
                    }
                }];
            }
        }
    }
}