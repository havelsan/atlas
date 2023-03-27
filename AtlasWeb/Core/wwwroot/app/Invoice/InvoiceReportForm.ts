import { Component } from "@angular/core";
import { ReportDefinition } from "app/Report/Models/ReportDefinition";
import { ReportParameters } from "app/Report/Models/ReportParameters";
import { ReportParameter } from "app/Report/Models/ReportParameter";
import { Guid } from "app/NebulaClient/Mscorlib/Guid";
import { PayerTypeEnum } from "../NebulaClient/Model/AtlasClientModel";
import { AtlasReportService } from "app/Report/Services/AtlasReportService";

@Component({
    selector: 'invoice-report-form',
    templateUrl: './InvoiceReportFormView.html',
})
export class InvoiceReportForm {
    public reports: any;
    constructor(private reportService: AtlasReportService) {
        this.reports = this.GenerateInvoiceReports();
    }

    public GenerateInvoiceReports(): Array<ReportDefinition> {
        let InvoiceReports: Array<ReportDefinition> = new Array<ReportDefinition>();
        //Ekranda seçilmesi için gösterilecek raporların listesi
        InvoiceReports.push(this.InvoicedProceduresReport(), this.UninvoicedProceduresReport(), this.ForeignParticipationStatReport(), this.ReceiptPaymentStatReport());
        return InvoiceReports;
    }

    public InvoicedProceduresReport(): ReportDefinition {
        //let param2 = new ReportParameter();
        //param2.Name = 'NUMBEROFDAYS';
        //param2.DataTypeName = 'numeric';
        //param2.Caption = 'Gün Sayısı';
        //param2.Order = 2;
        //param2.Visible = true;
        //param2.Required = true;

        //let param3 = new ReportParameter();
        //param3.Name = 'SKRSILKodlariList';
        //param3.DataTypeName = 'list';
        //param3.ListDefID = new Guid('9c05164a-b5fb-4cfa-9300-f5f4d9bec858');
        //param3.Caption = 'Şehir';
        //param3.Order = 3;
        //param3.Visible = true;
        //param3.Required = true;

        //#region ReportParameters

        // DataTypeName= DateTime | _Seq | numeric | Boolean

        let StartDate = new ReportParameter();
        StartDate.Name = 'StartDate';
        StartDate.DataTypeName = 'DateTime';
        //Ekranda görünecek parametre label'ı
        StartDate.Caption = 'Başlangıç Tarihi';
        //Görüntülenme sırası
        StartDate.Order = 1;
        StartDate.Visible = true;
        StartDate.Required = true;

        let EndDate = new ReportParameter();
        EndDate.Name = 'EndDate';
        EndDate.DataTypeName = 'DateTime';
        EndDate.Caption = 'Bitiş Tarihi';
        EndDate.Order = 2;
        EndDate.Visible = true;
        EndDate.Required = true;

        let PayerType = new ReportParameter();
        PayerType.Name = 'PayerType';
        PayerType.DataTypeName = 'enum';
        PayerType.DataTypeID = new Guid('89067f68-e67f-483c-bf38-337f8bdbac91');
        PayerType.Caption = 'Kurum Türü';
        PayerType.Order = 3;
        PayerType.Visible = true;
        PayerType.Required = false;
        PayerType.IsEnum = true;
        PayerType.EnumList = this.reportService.GenerateEnumLookup(PayerTypeEnum.Items);
        //#endregion ReportParameters

        let InvoicedProceduresReport = this.reportService.GenerateClientSideReportDefinition('InvoicedProceduresReport', 'Faturalanan Hizmet Dağılımı', [StartDate, EndDate, PayerType]);

        return InvoicedProceduresReport;
    }

    public ForeignParticipationStatReport(): ReportDefinition {

        let StartDate = new ReportParameter();
        StartDate.Name = 'StartDate';
        StartDate.DataTypeName = 'DateTime';
        //Ekranda görünecek parametre label'ı
        StartDate.Caption = 'Başlangıç Tarihi';
        //Görüntülenme sırası
        StartDate.Order = 1;
        StartDate.Visible = true;
        StartDate.Required = true;

        let EndDate = new ReportParameter();
        EndDate.Name = 'EndDate';
        EndDate.DataTypeName = 'DateTime';
        EndDate.Caption = 'Bitiş Tarihi';
        EndDate.Order = 2;
        EndDate.Visible = true;
        EndDate.Required = true;

        let ForeignParticipationStatReport = this.reportService.GenerateClientSideReportDefinition('ForeignParticipationStatReport', 'Yurtdışı Sigorta Katılım Payı Listesi', [StartDate, EndDate]);

        return ForeignParticipationStatReport;
    }

    public ReceiptPaymentStatReport(): ReportDefinition {

        let StartDate = new ReportParameter();
        StartDate.Name = 'StartDate';
        StartDate.DataTypeName = 'DateTime';
        //Ekranda görünecek parametre label'ı
        StartDate.Caption = 'Başlangıç Tarihi';
        //Görüntülenme sırası
        StartDate.Order = 1;
        StartDate.Visible = true;
        StartDate.Required = true;

        let EndDate = new ReportParameter();
        EndDate.Name = 'EndDate';
        EndDate.DataTypeName = 'DateTime';
        EndDate.Caption = 'Bitiş Tarihi';
        EndDate.Order = 2;
        EndDate.Visible = true;
        EndDate.Required = true;

        let Payer = new ReportParameter();
        Payer.Name = 'Payer';
        Payer.DataTypeName = 'list';
        Payer.ListDefID = new Guid('61cb92fe-0330-48f5-9e09-674ba7a57b3d'); //PayerListDefintion
        Payer.Caption = 'Kurum';
        Payer.Order = 3;
        Payer.Visible = true;
        Payer.Required = false;
        
        let ReceiptPaymentStatReport = this.reportService.GenerateClientSideReportDefinition('ReceiptPaymentStatReport', 'Kurum Vezne Tahsilat', [StartDate, EndDate,Payer]);

        return ReceiptPaymentStatReport;
    }

    public UninvoicedProceduresReport(): ReportDefinition {
        let StartDate = new ReportParameter();
        StartDate.Name = 'StartDate';
        StartDate.DataTypeName = 'DateTime';
        StartDate.Caption = 'Başlangıç Tarihi';
        StartDate.Order = 1;
        StartDate.Visible = true;
        StartDate.Required = true;

        let EndDate = new ReportParameter();
        EndDate.Name = 'EndDate';
        EndDate.DataTypeName = 'DateTime';
        EndDate.Caption = 'Bitiş Tarihi';
        EndDate.Order = 2;
        EndDate.Visible = true;
        EndDate.Required = true;

        let PayerType = new ReportParameter();
        PayerType.Name = 'PayerType';
        PayerType.DataTypeName = 'enum';
        PayerType.DataTypeID = new Guid('89067f68-e67f-483c-bf38-337f8bdbac91');
        PayerType.Caption = 'Kurum Türü';
        PayerType.Order = 3;
        PayerType.Visible = true;
        PayerType.Required = false;
        PayerType.IsEnum = true;
        PayerType.EnumList = this.reportService.GenerateEnumLookup(PayerTypeEnum.Items);

        let UninvoicedProceduresReport = this.reportService.GenerateClientSideReportDefinition('UninvoicedProceduresReport', 'Faturalanmayan Hizmet Dağılımı', [StartDate, EndDate, PayerType]);

        return UninvoicedProceduresReport;
    }

}