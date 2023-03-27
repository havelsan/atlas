
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTReportTool;
using TTVisual;
namespace TTReportClasses
{
    public partial class InvoiceCollectionPreReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public InvoiceCollectionPreReport MyParentReport
            {
                get { return (InvoiceCollectionPreReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField CODE { get {return Body().CODE;} }
            public TTReportField SUBJECT { get {return Body().SUBJECT;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField DATE { get {return Body().DATE;} }
            public TTReportField BASLIK { get {return Body().BASLIK;} }
            public TTReportField PAYERTEXT { get {return Body().PAYERTEXT;} }
            public TTReportField BODYTEXT1 { get {return Body().BODYTEXT1;} }
            public TTReportField AMOUNTOFINVOICE { get {return Body().AMOUNTOFINVOICE;} }
            public TTReportField AMOUNTOFTRANSFERDOCUMENT { get {return Body().AMOUNTOFTRANSFERDOCUMENT;} }
            public TTReportField ACCOUNTANTNAME { get {return Body().ACCOUNTANTNAME;} }
            public TTReportField ACCOUNTANTTITLE { get {return Body().ACCOUNTANTTITLE;} }
            public TTReportField ACCOUNTANT { get {return Body().ACCOUNTANT;} }
            public TTReportField BODYTEXT2 { get {return Body().BODYTEXT2;} }
            public TTReportField BODYTEXT4 { get {return Body().BODYTEXT4;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField INVOICECOUNT { get {return Body().INVOICECOUNT;} }
            public TTReportField INVOICEPRICE { get {return Body().INVOICEPRICE;} }
            public TTReportField PAYMENTDAYLIMIT { get {return Body().PAYMENTDAYLIMIT;} }
            public TTReportField INVOICECOLLECTIONNO { get {return Body().INVOICECOLLECTIONNO;} }
            public TTReportField BANKBRANCHNAME { get {return Body().BANKBRANCHNAME;} }
            public TTReportField IBANNO { get {return Body().IBANNO;} }
            public TTReportField EMAIL { get {return Body().EMAIL;} }
            public TTReportField BODYTEXT3 { get {return Body().BODYTEXT3;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<InvoiceCollectionDetail.InvoiceCollectionPreReportNQL_Class>("InvoiceCollectionPreReportNQL", InvoiceCollectionDetail.InvoiceCollectionPreReportNQL((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public InvoiceCollectionPreReport MyParentReport
                {
                    get { return (InvoiceCollectionPreReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField CODE;
                public TTReportField SUBJECT;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField DATE;
                public TTReportField BASLIK;
                public TTReportField PAYERTEXT;
                public TTReportField BODYTEXT1;
                public TTReportField AMOUNTOFINVOICE;
                public TTReportField AMOUNTOFTRANSFERDOCUMENT;
                public TTReportField ACCOUNTANTNAME;
                public TTReportField ACCOUNTANTTITLE;
                public TTReportField ACCOUNTANT;
                public TTReportField BODYTEXT2;
                public TTReportField BODYTEXT4;
                public TTReportField NewField11;
                public TTReportField INVOICECOUNT;
                public TTReportField INVOICEPRICE;
                public TTReportField PAYMENTDAYLIMIT;
                public TTReportField INVOICECOLLECTIONNO;
                public TTReportField BANKBRANCHNAME;
                public TTReportField IBANNO;
                public TTReportField EMAIL;
                public TTReportField BODYTEXT3; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 300;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 54, 37, 59, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Sayı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 60, 37, 65, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Konu";

                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 54, 137, 59, false);
                    CODE.Name = "CODE";
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.TextFont.CharSet = 162;
                    CODE.Value = @"";

                    SUBJECT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 60, 137, 65, false);
                    SUBJECT.Name = "SUBJECT";
                    SUBJECT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBJECT.MultiLine = EvetHayirEnum.ehEvet;
                    SUBJECT.NoClip = EvetHayirEnum.ehEvet;
                    SUBJECT.WordBreak = EvetHayirEnum.ehEvet;
                    SUBJECT.ExpandTabs = EvetHayirEnum.ehEvet;
                    SUBJECT.TextFont.CharSet = 162;
                    SUBJECT.Value = @"{#INVOICECOLLECTIONNO#} İcmal Nolu Tedavi Ücretleri Hk.";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 54, 39, 59, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Size = 12;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @":";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 60, 39, 65, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Size = 12;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @":";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 53, 180, 59, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DATE.TextFont.CharSet = 162;
                    DATE.Value = @"{@printdate@}";

                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 21, 181, 41, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.DrawWidth = 2;
                    BASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    BASLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK.TextFont.Bold = true;
                    BASLIK.TextFont.CharSet = 162;
                    BASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")
";

                    PAYERTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 77, 181, 87, false);
                    PAYERTEXT.Name = "PAYERTEXT";
                    PAYERTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERTEXT.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYERTEXT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAYERTEXT.MultiLine = EvetHayirEnum.ehEvet;
                    PAYERTEXT.NoClip = EvetHayirEnum.ehEvet;
                    PAYERTEXT.WordBreak = EvetHayirEnum.ehEvet;
                    PAYERTEXT.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYERTEXT.TextFont.Bold = true;
                    PAYERTEXT.TextFont.CharSet = 162;
                    PAYERTEXT.Value = @"{#PAYERNAME#}";

                    BODYTEXT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 94, 181, 103, false);
                    BODYTEXT1.Name = "BODYTEXT1";
                    BODYTEXT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    BODYTEXT1.MultiLine = EvetHayirEnum.ehEvet;
                    BODYTEXT1.NoClip = EvetHayirEnum.ehEvet;
                    BODYTEXT1.WordBreak = EvetHayirEnum.ehEvet;
                    BODYTEXT1.ExpandTabs = EvetHayirEnum.ehEvet;
                    BODYTEXT1.TextFont.CharSet = 162;
                    BODYTEXT1.Value = @"";

                    AMOUNTOFINVOICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 205, 107, 210, false);
                    AMOUNTOFINVOICE.Name = "AMOUNTOFINVOICE";
                    AMOUNTOFINVOICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNTOFINVOICE.TextFont.CharSet = 162;
                    AMOUNTOFINVOICE.Value = @"{#INVOICECOUNT#} Adet Fatura";

                    AMOUNTOFTRANSFERDOCUMENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 211, 107, 216, false);
                    AMOUNTOFTRANSFERDOCUMENT.Name = "AMOUNTOFTRANSFERDOCUMENT";
                    AMOUNTOFTRANSFERDOCUMENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNTOFTRANSFERDOCUMENT.TextFont.CharSet = 162;
                    AMOUNTOFTRANSFERDOCUMENT.Value = @"{#INVOICECOUNT#} Adet Sevk Kağıdı";

                    ACCOUNTANTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 172, 181, 177, false);
                    ACCOUNTANTNAME.Name = "ACCOUNTANTNAME";
                    ACCOUNTANTNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACCOUNTANTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANTNAME.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANTNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANTNAME.TextFont.CharSet = 162;
                    ACCOUNTANTNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""INVOICEPOSTINGPREREPORTACCOUNTANTNAME"", """")
";

                    ACCOUNTANTTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 175, 262, 180, false);
                    ACCOUNTANTTITLE.Name = "ACCOUNTANTTITLE";
                    ACCOUNTANTTITLE.Visible = EvetHayirEnum.ehHayir;
                    ACCOUNTANTTITLE.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANTTITLE.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANTTITLE.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANTTITLE.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANTTITLE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANTTITLE.TextFont.CharSet = 162;
                    ACCOUNTANTTITLE.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""INVOICEPOSTINGPREREPORTACCOUNTANTTITLE"", """")
";

                    ACCOUNTANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 178, 181, 183, false);
                    ACCOUNTANT.Name = "ACCOUNTANT";
                    ACCOUNTANT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACCOUNTANT.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.TextFont.CharSet = 162;
                    ACCOUNTANT.Value = @"İdari ve Mali İşler Müdürü";

                    BODYTEXT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 107, 181, 138, false);
                    BODYTEXT2.Name = "BODYTEXT2";
                    BODYTEXT2.FieldType = ReportFieldTypeEnum.ftVariable;
                    BODYTEXT2.MultiLine = EvetHayirEnum.ehEvet;
                    BODYTEXT2.NoClip = EvetHayirEnum.ehEvet;
                    BODYTEXT2.WordBreak = EvetHayirEnum.ehEvet;
                    BODYTEXT2.ExpandTabs = EvetHayirEnum.ehEvet;
                    BODYTEXT2.TextFont.CharSet = 162;
                    BODYTEXT2.Value = @"";

                    BODYTEXT4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 240, 181, 251, false);
                    BODYTEXT4.Name = "BODYTEXT4";
                    BODYTEXT4.FieldType = ReportFieldTypeEnum.ftVariable;
                    BODYTEXT4.MultiLine = EvetHayirEnum.ehEvet;
                    BODYTEXT4.NoClip = EvetHayirEnum.ehEvet;
                    BODYTEXT4.WordBreak = EvetHayirEnum.ehEvet;
                    BODYTEXT4.ExpandTabs = EvetHayirEnum.ehEvet;
                    BODYTEXT4.TextFont.Bold = true;
                    BODYTEXT4.TextFont.CharSet = 162;
                    BODYTEXT4.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 205, 37, 210, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Ek   :";

                    INVOICECOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 29, 262, 34, false);
                    INVOICECOUNT.Name = "INVOICECOUNT";
                    INVOICECOUNT.Visible = EvetHayirEnum.ehHayir;
                    INVOICECOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    INVOICECOUNT.TextFont.CharSet = 162;
                    INVOICECOUNT.Value = @"{#INVOICECOUNT#}";

                    INVOICEPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 37, 262, 42, false);
                    INVOICEPRICE.Name = "INVOICEPRICE";
                    INVOICEPRICE.Visible = EvetHayirEnum.ehHayir;
                    INVOICEPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    INVOICEPRICE.TextFormat = @"#,##0.#0";
                    INVOICEPRICE.TextFont.CharSet = 162;
                    INVOICEPRICE.Value = @"{#INVOICEPRICE#}";

                    PAYMENTDAYLIMIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 21, 262, 26, false);
                    PAYMENTDAYLIMIT.Name = "PAYMENTDAYLIMIT";
                    PAYMENTDAYLIMIT.Visible = EvetHayirEnum.ehHayir;
                    PAYMENTDAYLIMIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYMENTDAYLIMIT.TextFont.CharSet = 162;
                    PAYMENTDAYLIMIT.Value = @"{#PAYMENTDAYLIMIT#}";

                    INVOICECOLLECTIONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 14, 262, 19, false);
                    INVOICECOLLECTIONNO.Name = "INVOICECOLLECTIONNO";
                    INVOICECOLLECTIONNO.Visible = EvetHayirEnum.ehHayir;
                    INVOICECOLLECTIONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    INVOICECOLLECTIONNO.TextFont.CharSet = 162;
                    INVOICECOLLECTIONNO.Value = @"{#INVOICECOLLECTIONNO#}";

                    BANKBRANCHNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 45, 262, 50, false);
                    BANKBRANCHNAME.Name = "BANKBRANCHNAME";
                    BANKBRANCHNAME.Visible = EvetHayirEnum.ehHayir;
                    BANKBRANCHNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    BANKBRANCHNAME.MultiLine = EvetHayirEnum.ehEvet;
                    BANKBRANCHNAME.NoClip = EvetHayirEnum.ehEvet;
                    BANKBRANCHNAME.WordBreak = EvetHayirEnum.ehEvet;
                    BANKBRANCHNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    BANKBRANCHNAME.TextFont.CharSet = 162;
                    BANKBRANCHNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""BANKBRANCHNAME"", """")
";

                    IBANNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 52, 262, 57, false);
                    IBANNO.Name = "IBANNO";
                    IBANNO.Visible = EvetHayirEnum.ehHayir;
                    IBANNO.FieldType = ReportFieldTypeEnum.ftExpression;
                    IBANNO.MultiLine = EvetHayirEnum.ehEvet;
                    IBANNO.NoClip = EvetHayirEnum.ehEvet;
                    IBANNO.WordBreak = EvetHayirEnum.ehEvet;
                    IBANNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    IBANNO.TextFont.CharSet = 162;
                    IBANNO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALIBANNO"", """")
";

                    EMAIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 60, 262, 65, false);
                    EMAIL.Name = "EMAIL";
                    EMAIL.Visible = EvetHayirEnum.ehHayir;
                    EMAIL.FieldType = ReportFieldTypeEnum.ftExpression;
                    EMAIL.MultiLine = EvetHayirEnum.ehEvet;
                    EMAIL.NoClip = EvetHayirEnum.ehEvet;
                    EMAIL.WordBreak = EvetHayirEnum.ehEvet;
                    EMAIL.ExpandTabs = EvetHayirEnum.ehEvet;
                    EMAIL.TextFont.CharSet = 162;
                    EMAIL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""INVOICEPOSTINGREPORTEMAIL"", """")
";

                    BODYTEXT3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 142, 181, 147, false);
                    BODYTEXT3.Name = "BODYTEXT3";
                    BODYTEXT3.FieldType = ReportFieldTypeEnum.ftVariable;
                    BODYTEXT3.MultiLine = EvetHayirEnum.ehEvet;
                    BODYTEXT3.NoClip = EvetHayirEnum.ehEvet;
                    BODYTEXT3.WordBreak = EvetHayirEnum.ehEvet;
                    BODYTEXT3.ExpandTabs = EvetHayirEnum.ehEvet;
                    BODYTEXT3.TextFont.CharSet = 162;
                    BODYTEXT3.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InvoiceCollectionDetail.InvoiceCollectionPreReportNQL_Class dataset_InvoiceCollectionPreReportNQL = ParentGroup.rsGroup.GetCurrentRecord<InvoiceCollectionDetail.InvoiceCollectionPreReportNQL_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    CODE.CalcValue = @"";
                    SUBJECT.CalcValue = (dataset_InvoiceCollectionPreReportNQL != null ? Globals.ToStringCore(dataset_InvoiceCollectionPreReportNQL.Invoicecollectionno) : "") + @" İcmal Nolu Tedavi Ücretleri Hk.";
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    DATE.CalcValue = DateTime.Now.ToShortDateString();
                    PAYERTEXT.CalcValue = (dataset_InvoiceCollectionPreReportNQL != null ? Globals.ToStringCore(dataset_InvoiceCollectionPreReportNQL.Payername) : "");
                    BODYTEXT1.CalcValue = @"";
                    AMOUNTOFINVOICE.CalcValue = (dataset_InvoiceCollectionPreReportNQL != null ? Globals.ToStringCore(dataset_InvoiceCollectionPreReportNQL.Invoicecount) : "") + @" Adet Fatura";
                    AMOUNTOFTRANSFERDOCUMENT.CalcValue = (dataset_InvoiceCollectionPreReportNQL != null ? Globals.ToStringCore(dataset_InvoiceCollectionPreReportNQL.Invoicecount) : "") + @" Adet Sevk Kağıdı";
                    ACCOUNTANT.CalcValue = ACCOUNTANT.Value;
                    BODYTEXT2.CalcValue = @"";
                    BODYTEXT4.CalcValue = @"";
                    NewField11.CalcValue = NewField11.Value;
                    INVOICECOUNT.CalcValue = (dataset_InvoiceCollectionPreReportNQL != null ? Globals.ToStringCore(dataset_InvoiceCollectionPreReportNQL.Invoicecount) : "");
                    INVOICEPRICE.CalcValue = (dataset_InvoiceCollectionPreReportNQL != null ? Globals.ToStringCore(dataset_InvoiceCollectionPreReportNQL.Invoiceprice) : "");
                    PAYMENTDAYLIMIT.CalcValue = (dataset_InvoiceCollectionPreReportNQL != null ? Globals.ToStringCore(dataset_InvoiceCollectionPreReportNQL.PaymentDayLimit) : "");
                    INVOICECOLLECTIONNO.CalcValue = (dataset_InvoiceCollectionPreReportNQL != null ? Globals.ToStringCore(dataset_InvoiceCollectionPreReportNQL.Invoicecollectionno) : "");
                    BODYTEXT3.CalcValue = @"";
                    BASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "")
;
                    ACCOUNTANTNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("INVOICEPOSTINGPREREPORTACCOUNTANTNAME", "")
;
                    ACCOUNTANTTITLE.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("INVOICEPOSTINGPREREPORTACCOUNTANTTITLE", "")
;
                    BANKBRANCHNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("BANKBRANCHNAME", "")
;
                    IBANNO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALIBANNO", "")
;
                    EMAIL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("INVOICEPOSTINGREPORTEMAIL", "")
;
                    return new TTReportObject[] { NewField1,NewField12,CODE,SUBJECT,NewField13,NewField14,DATE,PAYERTEXT,BODYTEXT1,AMOUNTOFINVOICE,AMOUNTOFTRANSFERDOCUMENT,ACCOUNTANT,BODYTEXT2,BODYTEXT4,NewField11,INVOICECOUNT,INVOICEPRICE,PAYMENTDAYLIMIT,INVOICECOLLECTIONNO,BODYTEXT3,BASLIK,ACCOUNTANTNAME,ACCOUNTANTTITLE,BANKBRANCHNAME,IBANNO,EMAIL};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    this.BODYTEXT1.CalcValue = "       Kurumunuz sigortalısı olup XXXXXXmizde tahlil,tetkik,tedavileri yapılan "  + this.INVOICECOUNT.CalcValue + " kişiye ait tedavi faturası ve icmal listesi yazımız ekinde gönderilmiştir.";
            this.BODYTEXT2.CalcValue = "       Ekli listede kurumunuz mensubu hastalara ait tedavi giderlerinin bulunduğu faturaların kurumunuza tesliminden itibaren T.C. Sağlık Bakanlığı Türkiye Kamu XXXXXXleri Kurumu ile yapılmış protokol gereği "  + this.PAYMENTDAYLIMIT.CalcValue + " gün içerisinde ödenmesi; aksi halde ödenmeyen faturalar ile ilgili olarak borçlar kanunu doğrultusunda yasal faiz uygulaması yapılacağından faturaların toplam tutarı olan " + this.INVOICEPRICE.CalcValue + " TL'nin " + this.BANKBRANCHNAME.CalcValue + " " + this.IBANNO.CalcValue + " IBAN nolu hesabımıza " + this.INVOICECOLLECTIONNO.FormattedValue + " İcmal Nosu belirtilerek yatırılması ve ödemeye ait bilgi dekontunun XXXXXXmiz faturalandırma birimine gönderilmesi hususunda;";
            this.BODYTEXT3.CalcValue = "       Gereğini bilgilerinize arz ederim..";
            this.BODYTEXT4.CalcValue = "Kurumumuza yapılacak ödemelerde kişinin T.C., Fatura Numarası ve Fatura Tarihini içerecek şekilde " + this.EMAIL.CalcValue + " e-posta adresine gönderilmesini rica ederiz.";
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public InvoiceCollectionPreReport()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "Object Id", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "INVOICECOLLECTIONPREREPORT";
            Caption = "İcmal Ön Yazı";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaTop;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Arial Narrow";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 1;
            return fd;
        }

        protected TTReportRTF SetRTFDefaultProperties()
        {
            TTReportRTF fd = new TTReportRTF();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportHTML SetHTMLDefaultProperties()
        {
            TTReportHTML fd = new TTReportHTML();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportShape SetShapeDefaultProperties()
        {
            TTReportShape fd = new TTReportShape();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;
            return fd;
        }

    }
}