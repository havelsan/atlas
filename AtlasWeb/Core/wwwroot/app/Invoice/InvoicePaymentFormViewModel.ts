
import { InvoicePaymentDetailModel, InvoicePaymentModel } from './InvoiceHelperModel';

export class InvoicePaymentFormModel {
    public InvoicePayment: InvoicePaymentModel;
    public InvoicePaymentDetailList: Array<InvoicePaymentDetailModel>;
    constructor()
    {

        this.InvoicePayment = new InvoicePaymentModel();
        this.InvoicePaymentDetailList = new Array<InvoicePaymentDetailModel>();

        this.InvoicePayment.PaymentPrice = 0;
        this.InvoicePayment.InvoicePrice = 0;
        this.InvoicePayment.TotalPrice = 0;
        this.InvoicePayment.Deduction = 0;

    }
}

