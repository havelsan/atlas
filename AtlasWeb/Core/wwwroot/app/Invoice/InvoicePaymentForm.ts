//$59436A40
import { Component, OnInit, Input, IterableDiffers, DoCheck, Output, EventEmitter } from '@angular/core';
import { InvoicePaymentFormModel } from "./InvoicePaymentFormViewModel";
import { IsReadOnly } from "./InvoicePaymentSearchFormViewModel";
import { Guid } from "NebulaClient/Mscorlib/Guid";
import { NeHttpService } from "Fw/Services/NeHttpService";
import { ServiceLocator } from 'Fw/Services/ServiceLocator';
import { InvoicePaymentDetailModel, InvoicePaymentModel, PayerInvoicePaymentStates } from './InvoiceHelperModel';
import { ITTObjectListBox } from 'NebulaClient/Visual/ControlInterfaces/ITTObjectListBox';
import { InputForm } from 'NebulaClient/Visual/InputForm';

@Component({
    selector: "invoice-payment-form",
    templateUrl: './InvoicePaymentForm.html'
})

export class InvoicePaymentForm implements OnInit, DoCheck {

    public invoicePaymentFormModel: InvoicePaymentFormModel = new InvoicePaymentFormModel();

    detailDifferences: any;

    constructor(protected http: NeHttpService, private iterableDiffers: IterableDiffers) {
        this.invoicePaymentFormModel = new InvoicePaymentFormModel();

        this.detailDifferences = iterableDiffers.find([]).create(null);

    }

    ngDoCheck(): void {
        let columnChanges: any = this.detailDifferences.diff(this.invoicePaymentFormModel.InvoicePaymentDetailList);
        if (columnChanges) {
            this.calculatePrices();
        }
    }
    ngOnInit(): void {

    }

    calculatePrices(): void {
        let totalPayment: number = 0;
        let totalDeduction: number = 0;

        this.invoicePaymentFormModel.InvoicePaymentDetailList.forEach(element => {
            totalPayment = Math.Round(totalPayment, 2) + Math.Round(element.Payment, 2);
            totalDeduction = Math.Round(totalDeduction, 2) + Math.Round(element.Deduction.Value, 2);
        });

        this.invoicePaymentFormModel.InvoicePayment.PaymentPrice = Math.Round(totalPayment, 2);
        this.invoicePaymentFormModel.InvoicePayment.Deduction = Math.Round(totalDeduction, 2);
    }

    public _isReadonly: IsReadOnly = new IsReadOnly(false);
    @Input() set IsReadOnly(value: IsReadOnly) {
        this._isReadonly = value;
        this.cmbBankAccount.Enabled = !value.value;
    }

    get IsReadOnly(): IsReadOnly {
        return this._isReadonly;
    }

    @Output() ActionExecuted: EventEmitter<any> = new EventEmitter<any>();

    cmbBankAccount: ITTObjectListBox = <ITTObjectListBox>{
        Visible: true,

        ListDefName: 'BankAccountListDefinition',
        ShowClearButton: true
    };

    InvoicePaymentDetailListColumns = [
        {
            caption: i18n("M22936", "TC Kimlik No"),
            dataField: "UniqueRefNo",
        },
        {
            caption: i18n("M10517", "Adı Soyadı"),
            dataField: "PatientName",
            width: '15%'
        }, ,
        {
            caption: i18n("M17021", "Kabul No"),
            dataField: "EpisodeID",
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
            caption: i18n("M19885", "Ödenen"),
            dataField: "Payment",
            allowEditing: true,
            cellTemplate: "PaymentTemplate"
        },
        {
            caption: i18n("M17508", "Kesinti"),
            dataField: "Deduction",
            dataType: 'number',
            allowEditing: true,
            cellTemplate: "DeductionTemplate"
        }
    ];

    EditingConfig: any = {
        allowDeleting: true,
        texts: {
            deleteRow: 'Sil',
            //editRow: 'Güncelle',
            //cancelRowChanges: 'İptal',
            //saveRowChanges: 'Kaydet',
            //confirmDeleteTitle: 'Uyarı',
            confirmDeleteMessage: 'Tahsilat detayı silinecek. Emin misiniz?'
        }
    };
    onValueChangedGridPayment(data, row) {

        if (row != null && row.data != null) {
            if (data.value != null)
                row.data.Payment = data.value;
            if (data.value == "")
                row.data.Payment = 0;
            row.data.Payment = Math.Round(row.data.Payment, 2);
            row.data.Deduction = Math.Round(row.data.Deduction, 2);

            if (parseFloat(row.data.Payment) > parseFloat(row.data.InvoiceRestPrice)) {
                row.data.Deduction = 0;
                row.data.Payment = Math.Round(row.data.InvoiceRestPrice, 2);
            }

            if (parseFloat(row.data.Payment) + parseFloat(row.data.Deduction) > parseFloat(row.data.InvoiceRestPrice)) {
                let diff: number = (Math.Round(row.data.Payment, 2) + Math.Round(row.data.Deduction, 2)) - Math.Round(row.data.InvoiceRestPrice, 2);
                row.data.Deduction = Math.Round(row.data.Deduction, 2) - Math.Round(diff, 2);
            }
            row.data.Payment = Math.Round(row.data.Payment, 2);
            row.data.Deduction = Math.Round(row.data.Deduction, 2);
            this.calculatePrices();

        }
    }

    onValueChangedGridDeduction(data, row) {
        if (row != null && row.data != null) {
            if (data.value != null)
                row.data.Deduction = data.value;
            if (data.value == "")
                row.data.Deduction = 0;
            row.data.Payment = Math.Round(row.data.Payment, 2);
            row.data.Deduction = Math.Round(row.data.Deduction, 2);
            if (parseFloat(row.data.Deduction) > parseFloat(row.data.InvoiceRestPrice)) {
                row.data.Payment = 0;
                row.data.Deduction = row.data.InvoiceRestPrice;
            }

            if (parseFloat(row.data.Payment) + parseFloat(row.data.Deduction) > parseFloat(row.data.InvoiceRestPrice)) {
                let diff: number = (Math.Round(row.data.Payment, 2) + Math.Round(row.data.Deduction, 2)) - Math.Round(row.data.InvoiceRestPrice, 2);
                row.data.Payment = Math.Round(row.data.Payment, 2) - Math.Round(diff, 2);
            }
            row.data.Payment = Math.Round(row.data.Payment, 2);
            row.data.Deduction = Math.Round(row.data.Deduction, 2);
            this.calculatePrices();
        }
    }

    @Input() set PaymentDetailGridList(value: Array<InvoicePaymentDetailModel>) {
        this.invoicePaymentFormModel.InvoicePaymentDetailList = value;

    }
    get PaymentDetailGridList(): Array<InvoicePaymentDetailModel> {
        return this.invoicePaymentFormModel.InvoicePaymentDetailList;
    }

    @Input() set Payment(value: InvoicePaymentModel) {
        this.invoicePaymentFormModel.InvoicePayment = value;

    }
    get Payment(): InvoicePaymentModel {
        return this.invoicePaymentFormModel.InvoicePayment;
    }




    async newInvoicePaymentClick(): Promise<void> {


        let apiUrlForNewInvoicePayment: string = '/api/InvoicePaymentApi/NewInvoicePayment';
        if (this.invoicePaymentFormModel.InvoicePayment.Payer.ObjectID != undefined) {
            this.http.post<Guid>(apiUrlForNewInvoicePayment, this.invoicePaymentFormModel).then(response => {
                this._isReadonly = new IsReadOnly(true);
                this.cmbBankAccount.Enabled = !this._isReadonly.value;
                this.invoicePaymentFormModel.InvoicePayment.PIPObjectId = response;
                this.invoicePaymentFormModel.InvoicePayment.CurrentStateDefID = PayerInvoicePaymentStates.Paid;
                ServiceLocator.MessageService.showSuccess("Tahsilat işlemi başarı ile tamamlandı.");
                this.ActionExecuted.emit({ Paid: true });
            })
                .catch(error => {
                    ServiceLocator.MessageService.showError(error);
                });
        }
        else
            ServiceLocator.MessageService.showError(i18n("M18036", "Kurum bilgisi bulunamadı. Kurum seçilmeden tahsilat işlemi gerçekleştirilemez."));
    }

    async cancelInvoicePaymentClick(): Promise<void> {
        if (this.invoicePaymentFormModel.InvoicePayment.PIPObjectId != undefined) {

            let a: string = await InputForm.GetText('İptal Açıklaması Giriniz.', i18n("M16529", "İptal Açıklaması Girilmemiştir."), false, true);
            if (!String.isNullOrEmpty(a)) {
                let apiUrlForCancelInvoicePayment: string = '/api/InvoicePaymentApi/CancelInvoicePayment';
                let tempObj: any = {};
                tempObj.PIPObjectId = this.invoicePaymentFormModel.InvoicePayment.PIPObjectId;
                tempObj.CancelDesc = a;

                let response = await this.http.post(apiUrlForCancelInvoicePayment, tempObj).then(response => {
                    this.invoicePaymentFormModel.InvoicePayment.CurrentStateDefID = PayerInvoicePaymentStates.Cancelled;
                    this.invoicePaymentFormModel.InvoicePayment.CancelDescription = a;
                    ServiceLocator.MessageService.showSuccess("Tahsilat iptal işlemi başarı ile tamamlandı.");
                    this.IsReadOnly = new IsReadOnly(false);
                    this.ActionExecuted.emit({ Cancelled: true });
                })
                    .catch(error => {
                        ServiceLocator.MessageService.showError(error);
                    });
            }
            else {
                ServiceLocator.MessageService.showError(i18n("M16530", "İptal açıklaması girilmesi zorunludur."));
            }
        }
        else
            ServiceLocator.MessageService.showError(i18n("M16537", "İptal edilecek tahsilat bilgisi bulunamadı."));
    }
    public cancelLabelText: string = "";
    public getCancelDescriptionVisible(): boolean {
        if (this.invoicePaymentFormModel.InvoicePayment.CurrentStateDefID == PayerInvoicePaymentStates.Cancelled)
            this.cancelLabelText = i18n("M16528", "İptal Açıklaması");
        else
            this.cancelLabelText = "";

        return this.invoicePaymentFormModel.InvoicePayment.CurrentStateDefID == PayerInvoicePaymentStates.Cancelled;
    }

    public getCancelButtonVisible(): boolean {
        return this._isReadonly.value && this.invoicePaymentFormModel.InvoicePayment.PIPObjectId != undefined && this.invoicePaymentFormModel.InvoicePayment.CurrentStateDefID == PayerInvoicePaymentStates.Paid;
    }

    // keypressPaymentPrice(event: KeyboardEvent) {
    //     if (event.charCode === 44)
    //         return false;
    //     if (isNaN(parseInt(event.key)) && event.charCode !== 46)
    //         return false;
    // }

    onValueChangedPaymentPrice(event: any): void {
        //if (this.invoicePaymentFormModel.InvoicePayment.PaymentPrice == "" || this.invoicePaymentFormModel.InvoicePayment.PaymentPrice == "," || this.invoicePaymentFormModel.InvoicePayment.PaymentPrice == null || this.invoicePaymentFormModel.InvoicePayment.PaymentPrice == undefined)
        //    this.invoicePaymentFormModel.InvoicePayment.PaymentPrice = "0";
        //if (this.invoicePaymentFormModel.InvoicePayment.Deduction == "" || this.invoicePaymentFormModel.InvoicePayment.Deduction == "," || this.invoicePaymentFormModel.InvoicePayment.Deduction == null || this.invoicePaymentFormModel.InvoicePayment.Deduction == undefined)
        //    this.invoicePaymentFormModel.InvoicePayment.Deduction = "0";

        //this.invoicePaymentFormModel.InvoicePayment.TotalPrice = (parseFloat(this.invoicePaymentFormModel.InvoicePayment.PaymentPrice) + parseFloat(this.invoicePaymentFormModel.InvoicePayment.Deduction)).toString();

        if (this.invoicePaymentFormModel.InvoicePayment.PaymentPrice == null || this.invoicePaymentFormModel.InvoicePayment.PaymentPrice == undefined)
            this.invoicePaymentFormModel.InvoicePayment.PaymentPrice = 0;
        if (this.invoicePaymentFormModel.InvoicePayment.Deduction == null || this.invoicePaymentFormModel.InvoicePayment.Deduction == undefined)
            this.invoicePaymentFormModel.InvoicePayment.Deduction = 0;

        this.invoicePaymentFormModel.InvoicePayment.TotalPrice = Math.Round(this.invoicePaymentFormModel.InvoicePayment.PaymentPrice + this.invoicePaymentFormModel.InvoicePayment.Deduction, 2);
    }

    //onRowInsertedDetailList(event: any): void {
    //    console.log(event);
    //}
    //onRowRemovedDetailList(event: any): void {
    //    console.log(event);
    //}

    //onRowPraparedDetailList(event: any): void {
    //    console.log(event);
    //}

    //onInitNewRowDetailList(event: any): void {
    //    console.log(event);
    //}

    //onInitializedDetailList(event: any): void {
    //    console.log(event);
    //}
}