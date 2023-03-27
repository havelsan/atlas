
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
    public partial class InvoiceCollectionInvoicesReport2 : TTReport
    {
#region Methods
   Currency PageTotal = 0;
        Currency TurnOverTotal = 0;
        int PageNumber = 1;
        string HPROTNO = string.Empty;
        string PatientName = string.Empty;
        bool IsLastPage = false;
        int OrderNo = 1;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public InvoiceCollectionInvoicesReport2 MyParentReport
            {
                get { return (InvoiceCollectionInvoicesReport2)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField PIDOBJECTID { get {return Header().PIDOBJECTID;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<InvoiceCollectionDetail.InvoiceCollectionListReportNQL_Class>("InvoiceCollectionListReportNQL", InvoiceCollectionDetail.InvoiceCollectionListReportNQL((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public InvoiceCollectionInvoicesReport2 MyParentReport
                {
                    get { return (InvoiceCollectionInvoicesReport2)ParentReport; }
                }
                
                public TTReportField PIDOBJECTID; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PIDOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 1, 249, 6, false);
                    PIDOBJECTID.Name = "PIDOBJECTID";
                    PIDOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    PIDOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PIDOBJECTID.TextFont.Name = "Arial Narrow";
                    PIDOBJECTID.Value = @"{#PIDOBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InvoiceCollectionDetail.InvoiceCollectionListReportNQL_Class dataset_InvoiceCollectionListReportNQL = ParentGroup.rsGroup.GetCurrentRecord<InvoiceCollectionDetail.InvoiceCollectionListReportNQL_Class>(0);
                    PIDOBJECTID.CalcValue = (dataset_InvoiceCollectionListReportNQL != null ? Globals.ToStringCore(dataset_InvoiceCollectionListReportNQL.Pidobjectid) : "");
                    return new TTReportObject[] { PIDOBJECTID};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    MyParentReport.PageNumber = 1;
            MyParentReport.PageTotal = 0;
            MyParentReport.TurnOverTotal = 0;
            MyParentReport.IsLastPage = false;
            MyParentReport.OrderNo = 1;
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public InvoiceCollectionInvoicesReport2 MyParentReport
                {
                    get { return (InvoiceCollectionInvoicesReport2)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class HEADGroup : TTReportGroup
        {
            public InvoiceCollectionInvoicesReport2 MyParentReport
            {
                get { return (InvoiceCollectionInvoicesReport2)ParentReport; }
            }

            new public HEADGroupHeader Header()
            {
                return (HEADGroupHeader)_header;
            }

            new public HEADGroupFooter Footer()
            {
                return (HEADGroupFooter)_footer;
            }

            public TTReportField SEVKTARIHI { get {return Header().SEVKTARIHI;} }
            public TTReportField PAYER { get {return Header().PAYER;} }
            public TTReportField PATIENTNAME { get {return Header().PATIENTNAME;} }
            public TTReportField HPROTNO { get {return Header().HPROTNO;} }
            public TTReportField DOCUMENTNO { get {return Header().DOCUMENTNO;} }
            public TTReportField ICD10 { get {return Header().ICD10;} }
            public TTReportField TAXINFO { get {return Header().TAXINFO;} }
            public TTReportField TAXNUMBER { get {return Header().TAXNUMBER;} }
            public TTReportField TURNOVERTOTALLABEL { get {return Header().TURNOVERTOTALLABEL;} }
            public TTReportField TURNOVERTOTAL { get {return Header().TURNOVERTOTAL;} }
            public TTReportField PAGENO { get {return Header().PAGENO;} }
            public TTReportField StaticField1 { get {return Header().StaticField1;} }
            public TTReportField ICD10CODE { get {return Header().ICD10CODE;} }
            public TTReportField CASHIERNAME { get {return Header().CASHIERNAME;} }
            public TTReportField CASHIERTITLE { get {return Header().CASHIERTITLE;} }
            public TTReportField CASHIERRECID { get {return Header().CASHIERRECID;} }
            public TTReportField INVOICELABEL { get {return Header().INVOICELABEL;} }
            public TTReportField MAPULKE { get {return Header().MAPULKE;} }
            public TTReportField SEVKNO { get {return Header().SEVKNO;} }
            public TTReportField HOSPITALNAME { get {return Header().HOSPITALNAME;} }
            public TTReportShape NewRect1 { get {return Header().NewRect1;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField BANKACCOUNT { get {return Header().BANKACCOUNT;} }
            public TTReportField IBANNo { get {return Header().IBANNo;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField HOSPITALIBANNO { get {return Header().HOSPITALIBANNO;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField1122 { get {return Header().NewField1122;} }
            public TTReportField TAXOFFICE { get {return Header().TAXOFFICE;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField DOCUMENTDATE { get {return Header().DOCUMENTDATE;} }
            public TTReportField NewField112211 { get {return Header().NewField112211;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField11221 { get {return Header().NewField11221;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField OPENINGDATE { get {return Header().OPENINGDATE;} }
            public TTReportField NewField11222 { get {return Header().NewField11222;} }
            public TTReportField NewField1112 { get {return Header().NewField1112;} }
            public TTReportField INPATIENTDATE { get {return Header().INPATIENTDATE;} }
            public TTReportField NewField11223 { get {return Header().NewField11223;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField DISCHARGEDATE { get {return Header().DISCHARGEDATE;} }
            public TTReportField NewField132211 { get {return Header().NewField132211;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportShape NewRect2 { get {return Header().NewRect2;} }
            public TTReportField NewField1112211 { get {return Header().NewField1112211;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField11122111 { get {return Header().NewField11122111;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportShape NewRect3 { get {return Header().NewRect3;} }
            public TTReportField NewField11112 { get {return Header().NewField11112;} }
            public TTReportField NewField112212 { get {return Header().NewField112212;} }
            public TTReportField NewField121111 { get {return Header().NewField121111;} }
            public TTReportField NewField1212211 { get {return Header().NewField1212211;} }
            public TTReportField SERVICENAME { get {return Header().SERVICENAME;} }
            public TTReportField DOCTORNAME { get {return Header().DOCTORNAME;} }
            public TTReportField NewField121112 { get {return Header().NewField121112;} }
            public TTReportField NewField1211121 { get {return Header().NewField1211121;} }
            public TTReportField NewField11211121 { get {return Header().NewField11211121;} }
            public TTReportField NewField1211122 { get {return Header().NewField1211122;} }
            public TTReportField NewField1211123 { get {return Header().NewField1211123;} }
            public TTReportField NewField13211121 { get {return Header().NewField13211121;} }
            public TTReportField TAXOFFICEINFO { get {return Header().TAXOFFICEINFO;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportShape NewLine1112 { get {return Header().NewLine1112;} }
            public TTReportShape NewLine1113 { get {return Header().NewLine1113;} }
            public TTReportShape NewLine1115 { get {return Header().NewLine1115;} }
            public TTReportShape NewLine1116 { get {return Header().NewLine1116;} }
            public TTReportShape NewLine1117 { get {return Header().NewLine1117;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField PAGENUMBER { get {return Header().PAGENUMBER;} }
            public TTReportField IDARIVEMALIISLERMUDURU { get {return Header().IDARIVEMALIISLERMUDURU;} }
            public TTReportField IMZA { get {return Header().IMZA;} }
            public TTReportField TOTAL { get {return Footer().TOTAL;} }
            public TTReportField SEVKTARIHIFOOTER { get {return Footer().SEVKTARIHIFOOTER;} }
            public TTReportField TOTALPRICE { get {return Footer().TOTALPRICE;} }
            public TTReportField TOTALDISCOUNTPRICE { get {return Footer().TOTALDISCOUNTPRICE;} }
            public TTReportField GENERALTOTALPRICE { get {return Footer().GENERALTOTALPRICE;} }
            public TTReportField PAGETOTALLABEL { get {return Footer().PAGETOTALLABEL;} }
            public TTReportField PAGETOTAL { get {return Footer().PAGETOTAL;} }
            public TTReportField TL1 { get {return Footer().TL1;} }
            public TTReportField TL2 { get {return Footer().TL2;} }
            public TTReportField TL3 { get {return Footer().TL3;} }
            public TTReportField TL4 { get {return Footer().TL4;} }
            public TTReportField SEVKNOFOOTER { get {return Footer().SEVKNOFOOTER;} }
            public TTReportField NewField112 { get {return Footer().NewField112;} }
            public TTReportField NewField123 { get {return Footer().NewField123;} }
            public TTReportField TEDAVITOPLAMI { get {return Footer().TEDAVITOPLAMI;} }
            public TTReportField NewField1211 { get {return Footer().NewField1211;} }
            public TTReportField NewField1321 { get {return Footer().NewField1321;} }
            public TTReportField ILACTOPLAMI { get {return Footer().ILACTOPLAMI;} }
            public TTReportField NewField1212 { get {return Footer().NewField1212;} }
            public TTReportField NewField1322 { get {return Footer().NewField1322;} }
            public TTReportField SARFTOPLAMI { get {return Footer().SARFTOPLAMI;} }
            public TTReportField NewField1213 { get {return Footer().NewField1213;} }
            public TTReportField NewField1323 { get {return Footer().NewField1323;} }
            public TTReportField NewField9 { get {return Footer().NewField9;} }
            public TTReportField NewField13231 { get {return Footer().NewField13231;} }
            public TTReportField NewField10 { get {return Footer().NewField10;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportShape NewRect4 { get {return Footer().NewRect4;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportField HOSPITALNAMEFOOTER { get {return Footer().HOSPITALNAMEFOOTER;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField NewField151 { get {return Footer().NewField151;} }
            public TTReportField NewField17 { get {return Footer().NewField17;} }
            public TTReportField NewField171 { get {return Footer().NewField171;} }
            public TTReportField PAYERFOOTER { get {return Footer().PAYERFOOTER;} }
            public TTReportField HPROTNOFOOTER { get {return Footer().HPROTNOFOOTER;} }
            public TTReportField NewField11224 { get {return Footer().NewField11224;} }
            public TTReportField NewField1113 { get {return Footer().NewField1113;} }
            public TTReportField DOCUMENTNOFOOTER { get {return Footer().DOCUMENTNOFOOTER;} }
            public TTReportField NewField11122112 { get {return Footer().NewField11122112;} }
            public TTReportField NewField1111112 { get {return Footer().NewField1111112;} }
            public TTReportField DOCUMENTDATEFOOTER { get {return Footer().DOCUMENTDATEFOOTER;} }
            public TTReportField NewField1112212 { get {return Footer().NewField1112212;} }
            public TTReportField NewField111112 { get {return Footer().NewField111112;} }
            public TTReportField PAGENOFOOTER { get {return Footer().PAGENOFOOTER;} }
            public TTReportField NewField111122111 { get {return Footer().NewField111122111;} }
            public TTReportField NewField11111111 { get {return Footer().NewField11111111;} }
            public TTReportField NewField1111221111 { get {return Footer().NewField1111221111;} }
            public TTReportField NewField111111111 { get {return Footer().NewField111111111;} }
            public TTReportField NewField18 { get {return Footer().NewField18;} }
            public TTReportField PRICEWITHLETTERS { get {return Footer().PRICEWITHLETTERS;} }
            public TTReportField HPROTNOANDPATIENTNAME { get {return Footer().HPROTNOANDPATIENTNAME;} }
            public TTReportField PRICE { get {return Footer().PRICE;} }
            public TTReportShape NewLine131 { get {return Footer().NewLine131;} }
            public HEADGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PayerInvoiceDocument.PayerInvoiceReportInfoQuery_Class>("PayerInvoiceReportInfoQuery", PayerInvoiceDocument.PayerInvoiceReportInfoQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.PARTA.PIDOBJECTID.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADGroupHeader(this);
                _footer = new HEADGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADGroupHeader : TTReportSection
            {
                public InvoiceCollectionInvoicesReport2 MyParentReport
                {
                    get { return (InvoiceCollectionInvoicesReport2)ParentReport; }
                }
                
                public TTReportField SEVKTARIHI;
                public TTReportField PAYER;
                public TTReportField PATIENTNAME;
                public TTReportField HPROTNO;
                public TTReportField DOCUMENTNO;
                public TTReportField ICD10;
                public TTReportField TAXINFO;
                public TTReportField TAXNUMBER;
                public TTReportField TURNOVERTOTALLABEL;
                public TTReportField TURNOVERTOTAL;
                public TTReportField PAGENO;
                public TTReportField StaticField1;
                public TTReportField ICD10CODE;
                public TTReportField CASHIERNAME;
                public TTReportField CASHIERTITLE;
                public TTReportField CASHIERRECID;
                public TTReportField INVOICELABEL;
                public TTReportField MAPULKE;
                public TTReportField SEVKNO;
                public TTReportField HOSPITALNAME;
                public TTReportShape NewRect1;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField UNIQUEREFNO;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField121;
                public TTReportField BANKACCOUNT;
                public TTReportField IBANNo;
                public TTReportField NewField1121;
                public TTReportField HOSPITALIBANNO;
                public TTReportField NewField16;
                public TTReportField NewField1122;
                public TTReportField TAXOFFICE;
                public TTReportField NewField122;
                public TTReportField NewField1221;
                public TTReportField NewField111;
                public TTReportField DOCUMENTDATE;
                public TTReportField NewField112211;
                public TTReportField NewField11111;
                public TTReportField NewField11221;
                public TTReportField NewField1111;
                public TTReportField NewField6;
                public TTReportField OPENINGDATE;
                public TTReportField NewField11222;
                public TTReportField NewField1112;
                public TTReportField INPATIENTDATE;
                public TTReportField NewField11223;
                public TTReportField NewField7;
                public TTReportField DISCHARGEDATE;
                public TTReportField NewField132211;
                public TTReportField NewField8;
                public TTReportShape NewRect2;
                public TTReportField NewField1112211;
                public TTReportField NewField111111;
                public TTReportField NewField11122111;
                public TTReportField NewField1111111;
                public TTReportShape NewRect3;
                public TTReportField NewField11112;
                public TTReportField NewField112212;
                public TTReportField NewField121111;
                public TTReportField NewField1212211;
                public TTReportField SERVICENAME;
                public TTReportField DOCTORNAME;
                public TTReportField NewField121112;
                public TTReportField NewField1211121;
                public TTReportField NewField11211121;
                public TTReportField NewField1211122;
                public TTReportField NewField1211123;
                public TTReportField NewField13211121;
                public TTReportField TAXOFFICEINFO;
                public TTReportShape NewLine111;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine1112;
                public TTReportShape NewLine1113;
                public TTReportShape NewLine1115;
                public TTReportShape NewLine1116;
                public TTReportShape NewLine1117;
                public TTReportShape NewLine1;
                public TTReportField PAGENUMBER;
                public TTReportField IDARIVEMALIISLERMUDURU;
                public TTReportField IMZA; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 95;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    SEVKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 36, 265, 41, false);
                    SEVKTARIHI.Name = "SEVKTARIHI";
                    SEVKTARIHI.Visible = EvetHayirEnum.ehHayir;
                    SEVKTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEVKTARIHI.TextFormat = @"dd/MM/yyyy";
                    SEVKTARIHI.TextFont.Size = 8;
                    SEVKTARIHI.TextFont.CharSet = 162;
                    SEVKTARIHI.Value = @"";

                    PAYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 56, 99, 66, false);
                    PAYER.Name = "PAYER";
                    PAYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYER.MultiLine = EvetHayirEnum.ehEvet;
                    PAYER.WordBreak = EvetHayirEnum.ehEvet;
                    PAYER.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYER.TextFont.Name = "Arial";
                    PAYER.TextFont.Size = 9;
                    PAYER.TextFont.Bold = true;
                    PAYER.TextFont.CharSet = 162;
                    PAYER.Value = @"{#PAYERCODE#} {#PAYERNAME#} {#PAYERCITYNAME#}";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 31, 99, 36, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PATIENTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTNAME.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTNAME.TextFont.Name = "Arial";
                    PATIENTNAME.TextFont.Size = 9;
                    PATIENTNAME.TextFont.Bold = true;
                    PATIENTNAME.TextFont.CharSet = 162;
                    PATIENTNAME.Value = @"";

                    HPROTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 36, 99, 41, false);
                    HPROTNO.Name = "HPROTNO";
                    HPROTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTNO.TextFont.Name = "Arial";
                    HPROTNO.TextFont.Size = 9;
                    HPROTNO.TextFont.Bold = true;
                    HPROTNO.TextFont.CharSet = 162;
                    HPROTNO.Value = @"";

                    DOCUMENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 69, 152, 74, false);
                    DOCUMENTNO.Name = "DOCUMENTNO";
                    DOCUMENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNO.TextFont.Name = "Arial";
                    DOCUMENTNO.TextFont.Size = 9;
                    DOCUMENTNO.TextFont.Bold = true;
                    DOCUMENTNO.TextFont.CharSet = 162;
                    DOCUMENTNO.Value = @"{#DOCUMENTNO#}";

                    ICD10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 77, 206, 87, false);
                    ICD10.Name = "ICD10";
                    ICD10.FieldType = ReportFieldTypeEnum.ftVariable;
                    ICD10.MultiLine = EvetHayirEnum.ehEvet;
                    ICD10.WordBreak = EvetHayirEnum.ehEvet;
                    ICD10.ExpandTabs = EvetHayirEnum.ehEvet;
                    ICD10.TextFont.Name = "Arial";
                    ICD10.TextFont.Size = 8;
                    ICD10.TextFont.Bold = true;
                    ICD10.TextFont.CharSet = 162;
                    ICD10.Value = @"";

                    TAXINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 67, 269, 79, false);
                    TAXINFO.Name = "TAXINFO";
                    TAXINFO.Visible = EvetHayirEnum.ehHayir;
                    TAXINFO.FieldType = ReportFieldTypeEnum.ftExpression;
                    TAXINFO.MultiLine = EvetHayirEnum.ehEvet;
                    TAXINFO.NoClip = EvetHayirEnum.ehEvet;
                    TAXINFO.WordBreak = EvetHayirEnum.ehEvet;
                    TAXINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TAXINFO.TextFont.Size = 8;
                    TAXINFO.TextFont.CharSet = 162;
                    TAXINFO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""TAXOFFICEINFO"", """")";

                    TAXNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 45, 262, 50, false);
                    TAXNUMBER.Name = "TAXNUMBER";
                    TAXNUMBER.Visible = EvetHayirEnum.ehHayir;
                    TAXNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    TAXNUMBER.TextFont.Name = "Arial";
                    TAXNUMBER.TextFont.Size = 8;
                    TAXNUMBER.TextFont.Bold = true;
                    TAXNUMBER.TextFont.CharSet = 162;
                    TAXNUMBER.Value = @"{#PAYERTAXNUMBER#}";

                    TURNOVERTOTALLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 85, 253, 89, false);
                    TURNOVERTOTALLABEL.Name = "TURNOVERTOTALLABEL";
                    TURNOVERTOTALLABEL.Visible = EvetHayirEnum.ehHayir;
                    TURNOVERTOTALLABEL.TextFont.Name = "Arial";
                    TURNOVERTOTALLABEL.TextFont.Size = 8;
                    TURNOVERTOTALLABEL.TextFont.Bold = true;
                    TURNOVERTOTALLABEL.TextFont.CharSet = 162;
                    TURNOVERTOTALLABEL.Value = @"Nakli Yekün :";

                    TURNOVERTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 85, 280, 89, false);
                    TURNOVERTOTAL.Name = "TURNOVERTOTAL";
                    TURNOVERTOTAL.Visible = EvetHayirEnum.ehHayir;
                    TURNOVERTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TURNOVERTOTAL.TextFormat = @"#,##0.#0";
                    TURNOVERTOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TURNOVERTOTAL.TextFont.Name = "Arial";
                    TURNOVERTOTAL.TextFont.Size = 8;
                    TURNOVERTOTAL.TextFont.Bold = true;
                    TURNOVERTOTAL.TextFont.CharSet = 162;
                    TURNOVERTOTAL.Value = @"";

                    PAGENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 69, 206, 74, false);
                    PAGENO.Name = "PAGENO";
                    PAGENO.TextFont.Name = "Arial";
                    PAGENO.TextFont.Size = 9;
                    PAGENO.TextFont.Bold = true;
                    PAGENO.TextFont.CharSet = 162;
                    PAGENO.Value = @"";

                    StaticField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 46, 208, 51, false);
                    StaticField1.Name = "StaticField1";
                    StaticField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    StaticField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    StaticField1.MultiLine = EvetHayirEnum.ehEvet;
                    StaticField1.NoClip = EvetHayirEnum.ehEvet;
                    StaticField1.WordBreak = EvetHayirEnum.ehEvet;
                    StaticField1.ExpandTabs = EvetHayirEnum.ehEvet;
                    StaticField1.TextFont.Name = "Arial Narrow";
                    StaticField1.TextFont.CharSet = 162;
                    StaticField1.Value = @"İdari ve Mali Hizmetler Müdürü";

                    ICD10CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 58, 411, 62, false);
                    ICD10CODE.Name = "ICD10CODE";
                    ICD10CODE.Visible = EvetHayirEnum.ehHayir;
                    ICD10CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ICD10CODE.MultiLine = EvetHayirEnum.ehEvet;
                    ICD10CODE.WordBreak = EvetHayirEnum.ehEvet;
                    ICD10CODE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ICD10CODE.TextFont.Size = 8;
                    ICD10CODE.TextFont.CharSet = 162;
                    ICD10CODE.Value = @"";

                    CASHIERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 316, 67, 355, 71, false);
                    CASHIERNAME.Name = "CASHIERNAME";
                    CASHIERNAME.Visible = EvetHayirEnum.ehHayir;
                    CASHIERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERNAME.TextFont.Size = 8;
                    CASHIERNAME.TextFont.CharSet = 162;
                    CASHIERNAME.Value = @"";

                    CASHIERTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 316, 71, 355, 75, false);
                    CASHIERTITLE.Name = "CASHIERTITLE";
                    CASHIERTITLE.Visible = EvetHayirEnum.ehHayir;
                    CASHIERTITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERTITLE.TextFont.Size = 8;
                    CASHIERTITLE.TextFont.CharSet = 162;
                    CASHIERTITLE.Value = @"";

                    CASHIERRECID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 316, 75, 355, 79, false);
                    CASHIERRECID.Name = "CASHIERRECID";
                    CASHIERRECID.Visible = EvetHayirEnum.ehHayir;
                    CASHIERRECID.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERRECID.TextFont.Size = 8;
                    CASHIERRECID.TextFont.CharSet = 162;
                    CASHIERRECID.Value = @"";

                    INVOICELABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 5, 261, 10, false);
                    INVOICELABEL.Name = "INVOICELABEL";
                    INVOICELABEL.Visible = EvetHayirEnum.ehHayir;
                    INVOICELABEL.TextFont.Size = 16;
                    INVOICELABEL.TextFont.CharSet = 162;
                    INVOICELABEL.Value = @"FATURADIR";

                    MAPULKE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 54, 411, 58, false);
                    MAPULKE.Name = "MAPULKE";
                    MAPULKE.Visible = EvetHayirEnum.ehHayir;
                    MAPULKE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAPULKE.TextFont.Size = 8;
                    MAPULKE.TextFont.CharSet = 162;
                    MAPULKE.Value = @"";

                    SEVKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 24, 254, 29, false);
                    SEVKNO.Name = "SEVKNO";
                    SEVKNO.Visible = EvetHayirEnum.ehHayir;
                    SEVKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEVKNO.TextFont.Size = 8;
                    SEVKNO.TextFont.CharSet = 162;
                    SEVKNO.Value = @"";

                    HOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 8, 100, 23, false);
                    HOSPITALNAME.Name = "HOSPITALNAME";
                    HOSPITALNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.NoClip = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.TextFont.Name = "Arial";
                    HOSPITALNAME.TextFont.Size = 9;
                    HOSPITALNAME.TextFont.Bold = true;
                    HOSPITALNAME.TextFont.CharSet = 162;
                    HOSPITALNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewRect1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 5, 25, 100, 67, false);
                    NewRect1.Name = "NewRect1";
                    NewRect1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect1.FillStyle = FillStyleConstants.vbFSTransparent;

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 26, 28, 31, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"T.C. Kimlik No";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 31, 28, 36, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Adı Soyadı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 26, 30, 32, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 9;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @":";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 26, 99, 31, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.TextFont.Name = "Arial";
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.TextFont.Bold = true;
                    UNIQUEREFNO.TextFont.CharSet = 162;
                    UNIQUEREFNO.Value = @"";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 6, 183, 13, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.TextFont.Name = "Arial Black";
                    NewField2.TextFont.Size = 12;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"FATURA";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 14, 208, 30, false);
                    NewField3.Name = "NewField3";
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.NoClip = EvetHayirEnum.ehEvet;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.Value = @"XXXXXXmizde tedavi olan mensubunuz için tahakkuk ettirilen fatura bedelinin aşağıda belirtilen hesabımıza faturamızın (B) kısmı ile birlikte yatırılmasını arz ve rica ederim.";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 48, 123, 62, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.TextFont.Name = "Arial Black";
                    NewField4.TextFont.Size = 28;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"A";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 30, 150, 37, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Size = 8;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Banka / Şb.";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 30, 152, 37, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 8;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @":";

                    BANKACCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 30, 208, 37, false);
                    BANKACCOUNT.Name = "BANKACCOUNT";
                    BANKACCOUNT.FieldType = ReportFieldTypeEnum.ftExpression;
                    BANKACCOUNT.TextFont.Name = "Arial";
                    BANKACCOUNT.TextFont.Size = 8;
                    BANKACCOUNT.TextFont.Bold = true;
                    BANKACCOUNT.TextFont.CharSet = 162;
                    BANKACCOUNT.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""BANKACCOUNTINFO"", """")";

                    IBANNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 37, 150, 41, false);
                    IBANNo.Name = "IBANNo";
                    IBANNo.TextFont.Name = "Arial";
                    IBANNo.TextFont.Size = 8;
                    IBANNo.TextFont.Bold = true;
                    IBANNo.TextFont.CharSet = 162;
                    IBANNo.Value = @"IBAN No";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 37, 152, 41, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                    HOSPITALIBANNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 37, 208, 41, false);
                    HOSPITALIBANNO.Name = "HOSPITALIBANNO";
                    HOSPITALIBANNO.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALIBANNO.TextFont.Name = "Arial";
                    HOSPITALIBANNO.TextFont.Size = 8;
                    HOSPITALIBANNO.TextFont.CharSet = 162;
                    HOSPITALIBANNO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALIBANNO"", """")";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 41, 150, 45, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Size = 8;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"Vergi D/ No";

                    NewField1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 41, 152, 45, false);
                    NewField1122.Name = "NewField1122";
                    NewField1122.TextFont.Name = "Arial";
                    NewField1122.TextFont.Size = 8;
                    NewField1122.TextFont.Bold = true;
                    NewField1122.TextFont.CharSet = 162;
                    NewField1122.Value = @":";

                    TAXOFFICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 46, 287, 51, false);
                    TAXOFFICE.Name = "TAXOFFICE";
                    TAXOFFICE.Visible = EvetHayirEnum.ehHayir;
                    TAXOFFICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TAXOFFICE.TextFont.Name = "Arial";
                    TAXOFFICE.TextFont.Size = 8;
                    TAXOFFICE.TextFont.Bold = true;
                    TAXOFFICE.TextFont.CharSet = 162;
                    TAXOFFICE.Value = @"{#PAYERTAXOFFICE#}";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 31, 30, 36, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Name = "Arial";
                    NewField122.TextFont.Size = 9;
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @":";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 36, 30, 41, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.Name = "Arial";
                    NewField1221.TextFont.Size = 9;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @":";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 36, 28, 41, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 9;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Protokol No";

                    DOCUMENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 69, 78, 74, false);
                    DOCUMENTDATE.Name = "DOCUMENTDATE";
                    DOCUMENTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTDATE.TextFormat = @"dd/MM/yyyy";
                    DOCUMENTDATE.TextFont.Name = "Arial";
                    DOCUMENTDATE.TextFont.Size = 9;
                    DOCUMENTDATE.TextFont.Bold = true;
                    DOCUMENTDATE.TextFont.CharSet = 162;
                    DOCUMENTDATE.Value = @"{#DOCUMENTDATE#}";

                    NewField112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 69, 28, 74, false);
                    NewField112211.Name = "NewField112211";
                    NewField112211.TextFont.Name = "Arial";
                    NewField112211.TextFont.Size = 9;
                    NewField112211.TextFont.Bold = true;
                    NewField112211.TextFont.CharSet = 162;
                    NewField112211.Value = @":";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 69, 26, 74, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Size = 9;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Fatura Tarihi";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 56, 30, 61, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.TextFont.Name = "Arial";
                    NewField11221.TextFont.Size = 9;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @":";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 56, 28, 61, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 9;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Kurumu";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 18, 187, 23, false);
                    NewField6.Name = "NewField6";
                    NewField6.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial Narrow";
                    NewField6.Value = @"_";

                    OPENINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 41, 99, 46, false);
                    OPENINGDATE.Name = "OPENINGDATE";
                    OPENINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    OPENINGDATE.TextFormat = @"dd/MM/yyyy";
                    OPENINGDATE.TextFont.Name = "Arial";
                    OPENINGDATE.TextFont.Size = 9;
                    OPENINGDATE.TextFont.Bold = true;
                    OPENINGDATE.TextFont.CharSet = 162;
                    OPENINGDATE.Value = @"";

                    NewField11222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 41, 30, 46, false);
                    NewField11222.Name = "NewField11222";
                    NewField11222.TextFont.Name = "Arial";
                    NewField11222.TextFont.Size = 9;
                    NewField11222.TextFont.Bold = true;
                    NewField11222.TextFont.CharSet = 162;
                    NewField11222.Value = @":";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 41, 28, 46, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.TextFont.Name = "Arial";
                    NewField1112.TextFont.Size = 9;
                    NewField1112.TextFont.Bold = true;
                    NewField1112.TextFont.CharSet = 162;
                    NewField1112.Value = @"Kayıt Tarihi";

                    INPATIENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 46, 99, 51, false);
                    INPATIENTDATE.Name = "INPATIENTDATE";
                    INPATIENTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    INPATIENTDATE.TextFormat = @"dd/MM/yyyy";
                    INPATIENTDATE.TextFont.Name = "Arial";
                    INPATIENTDATE.TextFont.Size = 9;
                    INPATIENTDATE.TextFont.Bold = true;
                    INPATIENTDATE.TextFont.CharSet = 162;
                    INPATIENTDATE.Value = @"";

                    NewField11223 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 46, 30, 51, false);
                    NewField11223.Name = "NewField11223";
                    NewField11223.TextFont.Name = "Arial";
                    NewField11223.TextFont.Size = 9;
                    NewField11223.TextFont.Bold = true;
                    NewField11223.TextFont.CharSet = 162;
                    NewField11223.Value = @":";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 46, 28, 51, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Size = 9;
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"Yatış Tarihi";

                    DISCHARGEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 51, 99, 56, false);
                    DISCHARGEDATE.Name = "DISCHARGEDATE";
                    DISCHARGEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISCHARGEDATE.TextFormat = @"dd/MM/yyyy";
                    DISCHARGEDATE.TextFont.Name = "Arial";
                    DISCHARGEDATE.TextFont.Size = 9;
                    DISCHARGEDATE.TextFont.Bold = true;
                    DISCHARGEDATE.TextFont.CharSet = 162;
                    DISCHARGEDATE.Value = @"";

                    NewField132211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 51, 30, 56, false);
                    NewField132211.Name = "NewField132211";
                    NewField132211.TextFont.Name = "Arial";
                    NewField132211.TextFont.Size = 9;
                    NewField132211.TextFont.Bold = true;
                    NewField132211.TextFont.CharSet = 162;
                    NewField132211.Value = @":";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 51, 28, 56, false);
                    NewField8.Name = "NewField8";
                    NewField8.TextFont.Name = "Arial";
                    NewField8.TextFont.Size = 9;
                    NewField8.TextFont.Bold = true;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @"Çıkış Tarihi";

                    NewRect2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 5, 68, 208, 75, false);
                    NewRect2.Name = "NewRect2";
                    NewRect2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect2.FillStyle = FillStyleConstants.vbFSTransparent;

                    NewField1112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 69, 102, 74, false);
                    NewField1112211.Name = "NewField1112211";
                    NewField1112211.TextFont.Name = "Arial";
                    NewField1112211.TextFont.Size = 9;
                    NewField1112211.TextFont.Bold = true;
                    NewField1112211.TextFont.CharSet = 162;
                    NewField1112211.Value = @":";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 69, 100, 74, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.TextFont.Name = "Arial";
                    NewField111111.TextFont.Size = 9;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Fatura No";

                    NewField11122111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 69, 183, 74, false);
                    NewField11122111.Name = "NewField11122111";
                    NewField11122111.TextFont.Name = "Arial";
                    NewField11122111.TextFont.Size = 9;
                    NewField11122111.TextFont.Bold = true;
                    NewField11122111.TextFont.CharSet = 162;
                    NewField11122111.Value = @":";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 69, 181, 74, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.TextFont.Name = "Arial";
                    NewField1111111.TextFont.Size = 9;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"Sayfa No";

                    NewRect3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 5, 76, 208, 88, false);
                    NewRect3.Name = "NewRect3";
                    NewRect3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect3.FillStyle = FillStyleConstants.vbFSTransparent;

                    NewField11112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 77, 23, 82, false);
                    NewField11112.Name = "NewField11112";
                    NewField11112.TextFont.Name = "Arial";
                    NewField11112.TextFont.Size = 9;
                    NewField11112.TextFont.Bold = true;
                    NewField11112.TextFont.CharSet = 162;
                    NewField11112.Value = @"Servis Adı";

                    NewField112212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 77, 25, 82, false);
                    NewField112212.Name = "NewField112212";
                    NewField112212.TextFont.Name = "Arial";
                    NewField112212.TextFont.Size = 9;
                    NewField112212.TextFont.Bold = true;
                    NewField112212.TextFont.CharSet = 162;
                    NewField112212.Value = @":";

                    NewField121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 82, 23, 87, false);
                    NewField121111.Name = "NewField121111";
                    NewField121111.TextFont.Name = "Arial";
                    NewField121111.TextFont.Size = 9;
                    NewField121111.TextFont.Bold = true;
                    NewField121111.TextFont.CharSet = 162;
                    NewField121111.Value = @"Doktor Adı";

                    NewField1212211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 82, 25, 87, false);
                    NewField1212211.Name = "NewField1212211";
                    NewField1212211.TextFont.Name = "Arial";
                    NewField1212211.TextFont.Size = 9;
                    NewField1212211.TextFont.Bold = true;
                    NewField1212211.TextFont.CharSet = 162;
                    NewField1212211.Value = @":";

                    SERVICENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 77, 78, 82, false);
                    SERVICENAME.Name = "SERVICENAME";
                    SERVICENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERVICENAME.TextFormat = @"dd/MM/yyyy";
                    SERVICENAME.TextFont.Name = "Arial";
                    SERVICENAME.TextFont.Size = 9;
                    SERVICENAME.TextFont.Bold = true;
                    SERVICENAME.TextFont.CharSet = 162;
                    SERVICENAME.Value = @"";

                    DOCTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 82, 78, 87, false);
                    DOCTORNAME.Name = "DOCTORNAME";
                    DOCTORNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTORNAME.TextFormat = @"dd/MM/yyyy";
                    DOCTORNAME.TextFont.Name = "Arial";
                    DOCTORNAME.TextFont.Size = 9;
                    DOCTORNAME.TextFont.Bold = true;
                    DOCTORNAME.TextFont.CharSet = 162;
                    DOCTORNAME.Value = @"";

                    NewField121112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 89, 18, 93, false);
                    NewField121112.Name = "NewField121112";
                    NewField121112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121112.TextFont.Name = "Arial";
                    NewField121112.TextFont.Size = 9;
                    NewField121112.TextFont.Bold = true;
                    NewField121112.TextFont.CharSet = 162;
                    NewField121112.Value = @"Sıra No";

                    NewField1211121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 89, 40, 93, false);
                    NewField1211121.Name = "NewField1211121";
                    NewField1211121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211121.TextFont.Name = "Arial";
                    NewField1211121.TextFont.Size = 9;
                    NewField1211121.TextFont.Bold = true;
                    NewField1211121.TextFont.CharSet = 162;
                    NewField1211121.Value = @"Tarih";

                    NewField11211121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 89, 147, 93, false);
                    NewField11211121.Name = "NewField11211121";
                    NewField11211121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211121.TextFont.Name = "Arial";
                    NewField11211121.TextFont.Size = 9;
                    NewField11211121.TextFont.Bold = true;
                    NewField11211121.TextFont.CharSet = 162;
                    NewField11211121.Value = @"Hizmet Adı";

                    NewField1211122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 89, 161, 93, false);
                    NewField1211122.Name = "NewField1211122";
                    NewField1211122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211122.TextFont.Name = "Arial";
                    NewField1211122.TextFont.Size = 9;
                    NewField1211122.TextFont.Bold = true;
                    NewField1211122.TextFont.CharSet = 162;
                    NewField1211122.Value = @"Adet";

                    NewField1211123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 89, 183, 93, false);
                    NewField1211123.Name = "NewField1211123";
                    NewField1211123.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211123.TextFont.Name = "Arial";
                    NewField1211123.TextFont.Size = 9;
                    NewField1211123.TextFont.Bold = true;
                    NewField1211123.TextFont.CharSet = 162;
                    NewField1211123.Value = @"Birim Fiyat";

                    NewField13211121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 89, 207, 93, false);
                    NewField13211121.Name = "NewField13211121";
                    NewField13211121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13211121.TextFont.Name = "Arial";
                    NewField13211121.TextFont.Size = 9;
                    NewField13211121.TextFont.Bold = true;
                    NewField13211121.TextFont.CharSet = 162;
                    NewField13211121.Value = @"Toplam";

                    TAXOFFICEINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 41, 208, 45, false);
                    TAXOFFICEINFO.Name = "TAXOFFICEINFO";
                    TAXOFFICEINFO.FieldType = ReportFieldTypeEnum.ftExpression;
                    TAXOFFICEINFO.TextFont.Name = "Arial";
                    TAXOFFICEINFO.TextFont.Size = 8;
                    TAXOFFICEINFO.TextFont.Bold = true;
                    TAXOFFICEINFO.TextFont.CharSet = 162;
                    TAXOFFICEINFO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""TAXOFFICEINFO"", """")";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 88, 5, 95, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 19, 88, 19, 95, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 41, 88, 41, 95, false);
                    NewLine1112.Name = "NewLine1112";
                    NewLine1112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 148, 88, 148, 95, false);
                    NewLine1113.Name = "NewLine1113";
                    NewLine1113.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1115 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 162, 88, 162, 95, false);
                    NewLine1115.Name = "NewLine1115";
                    NewLine1115.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1116 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 184, 88, 184, 95, false);
                    NewLine1116.Name = "NewLine1116";
                    NewLine1116.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1117 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 208, 88, 208, 95, false);
                    NewLine1117.Name = "NewLine1117";
                    NewLine1117.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 94, 208, 94, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 11, 261, 16, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.Visible = EvetHayirEnum.ehHayir;
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.TextFont.Name = "Arial";
                    PAGENUMBER.TextFont.Size = 9;
                    PAGENUMBER.TextFont.Bold = true;
                    PAGENUMBER.TextFont.CharSet = 162;
                    PAGENUMBER.Value = @"{@pagenumber@}";

                    IDARIVEMALIISLERMUDURU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 51, 208, 56, false);
                    IDARIVEMALIISLERMUDURU.Name = "IDARIVEMALIISLERMUDURU";
                    IDARIVEMALIISLERMUDURU.FieldType = ReportFieldTypeEnum.ftExpression;
                    IDARIVEMALIISLERMUDURU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IDARIVEMALIISLERMUDURU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IDARIVEMALIISLERMUDURU.TextFont.Name = "Arial Narrow";
                    IDARIVEMALIISLERMUDURU.TextFont.CharSet = 162;
                    IDARIVEMALIISLERMUDURU.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""IDARIVEMALIISLERMUDURU"", """")";

                    IMZA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 63, 202, 68, false);
                    IMZA.Name = "IMZA";
                    IMZA.FieldType = ReportFieldTypeEnum.ftOLE;
                    IMZA.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IMZA.ObjectDefName = "HospitalEmblemDefinition";
                    IMZA.DataMember = "EMBLEM";
                    IMZA.TextFont.Name = "Arial Narrow";
                    IMZA.TextFont.CharSet = 162;
                    IMZA.Value = @"ec0dcc99-6b32-435f-92bc-c8b2d145efe1";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PayerInvoiceDocument.PayerInvoiceReportInfoQuery_Class dataset_PayerInvoiceReportInfoQuery = ParentGroup.rsGroup.GetCurrentRecord<PayerInvoiceDocument.PayerInvoiceReportInfoQuery_Class>(0);
                    SEVKTARIHI.CalcValue = @"";
                    PAYER.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.Payercode) : "") + @" " + (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.Payername) : "") + @" " + (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.Payercityname) : "");
                    PATIENTNAME.CalcValue = @"";
                    HPROTNO.CalcValue = @"";
                    DOCUMENTNO.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.DocumentNo) : "");
                    ICD10.CalcValue = @"";
                    TAXNUMBER.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.Payertaxnumber) : "");
                    TURNOVERTOTALLABEL.CalcValue = TURNOVERTOTALLABEL.Value;
                    TURNOVERTOTAL.CalcValue = @"";
                    PAGENO.CalcValue = PAGENO.Value;
                    StaticField1.CalcValue = StaticField1.Value;
                    ICD10CODE.CalcValue = @"";
                    CASHIERNAME.CalcValue = @"";
                    CASHIERTITLE.CalcValue = @"";
                    CASHIERRECID.CalcValue = @"";
                    INVOICELABEL.CalcValue = INVOICELABEL.Value;
                    MAPULKE.CalcValue = @"";
                    SEVKNO.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    UNIQUEREFNO.CalcValue = @"";
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField121.CalcValue = NewField121.Value;
                    IBANNo.CalcValue = IBANNo.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField1122.CalcValue = NewField1122.Value;
                    TAXOFFICE.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.Payertaxoffice) : "");
                    NewField122.CalcValue = NewField122.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField111.CalcValue = NewField111.Value;
                    DOCUMENTDATE.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.DocumentDate) : "");
                    NewField112211.CalcValue = NewField112211.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField6.CalcValue = NewField6.Value;
                    OPENINGDATE.CalcValue = @"";
                    NewField11222.CalcValue = NewField11222.Value;
                    NewField1112.CalcValue = NewField1112.Value;
                    INPATIENTDATE.CalcValue = @"";
                    NewField11223.CalcValue = NewField11223.Value;
                    NewField7.CalcValue = NewField7.Value;
                    DISCHARGEDATE.CalcValue = @"";
                    NewField132211.CalcValue = NewField132211.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField1112211.CalcValue = NewField1112211.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField11122111.CalcValue = NewField11122111.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    NewField11112.CalcValue = NewField11112.Value;
                    NewField112212.CalcValue = NewField112212.Value;
                    NewField121111.CalcValue = NewField121111.Value;
                    NewField1212211.CalcValue = NewField1212211.Value;
                    SERVICENAME.CalcValue = @"";
                    DOCTORNAME.CalcValue = @"";
                    NewField121112.CalcValue = NewField121112.Value;
                    NewField1211121.CalcValue = NewField1211121.Value;
                    NewField11211121.CalcValue = NewField11211121.Value;
                    NewField1211122.CalcValue = NewField1211122.Value;
                    NewField1211123.CalcValue = NewField1211123.Value;
                    NewField13211121.CalcValue = NewField13211121.Value;
                    PAGENUMBER.CalcValue = ParentReport.CurrentPageNumber.ToString();
                    IMZA.CalcValue = @"ec0dcc99-6b32-435f-92bc-c8b2d145efe1";
                    TAXINFO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("TAXOFFICEINFO", "");
                    HOSPITALNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    BANKACCOUNT.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("BANKACCOUNTINFO", "");
                    HOSPITALIBANNO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALIBANNO", "");
                    TAXOFFICEINFO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("TAXOFFICEINFO", "");
                    IDARIVEMALIISLERMUDURU.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("IDARIVEMALIISLERMUDURU", "");
                    return new TTReportObject[] { SEVKTARIHI,PAYER,PATIENTNAME,HPROTNO,DOCUMENTNO,ICD10,TAXNUMBER,TURNOVERTOTALLABEL,TURNOVERTOTAL,PAGENO,StaticField1,ICD10CODE,CASHIERNAME,CASHIERTITLE,CASHIERRECID,INVOICELABEL,MAPULKE,SEVKNO,NewField1,NewField11,NewField12,UNIQUEREFNO,NewField2,NewField3,NewField4,NewField5,NewField121,IBANNo,NewField1121,NewField16,NewField1122,TAXOFFICE,NewField122,NewField1221,NewField111,DOCUMENTDATE,NewField112211,NewField11111,NewField11221,NewField1111,NewField6,OPENINGDATE,NewField11222,NewField1112,INPATIENTDATE,NewField11223,NewField7,DISCHARGEDATE,NewField132211,NewField8,NewField1112211,NewField111111,NewField11122111,NewField1111111,NewField11112,NewField112212,NewField121111,NewField1212211,SERVICENAME,DOCTORNAME,NewField121112,NewField1211121,NewField11211121,NewField1211122,NewField1211123,NewField13211121,PAGENUMBER,IMZA,TAXINFO,HOSPITALNAME,BANKACCOUNT,HOSPITALIBANNO,TAXOFFICEINFO,IDARIVEMALIISLERMUDURU};
                }

                public override void RunScript()
                {
#region HEAD HEADER_Script
                    PayerInvoiceDocument pid = (PayerInvoiceDocument)MyParentReport.ReportObjectContext.GetObject(new Guid(MyParentReport.PARTA.PIDOBJECTID.CalcValue), TTObjectDefManager.Instance.ObjectDefs[typeof(PayerInvoiceDocument).Name], false);
            if (pid != null)
            {
                Episode episode = null;
                foreach (InvoiceCollectionDetail icd in pid.InvoiceCollectionDetails)
                {
                    if (icd.Episode != null)
                    {
                        episode = icd.Episode;
                        break;
                    }
                }

                if (episode != null)
                {
                    this.SEVKNO.CalcValue = episode.DocumentNumber.Equals("0") ? string.Empty : episode.DocumentNumber;
                    this.SEVKTARIHI.CalcValue = episode.DocumentDate.HasValue ? episode.DocumentDate.Value.ToShortDateString() : string.Empty;
                    MyParentReport.HPROTNO = episode.ID.Value.ToString();
                    this.HPROTNO.CalcValue = MyParentReport.HPROTNO;
                    MyParentReport.PatientName = episode.Patient.FullName;
                    this.PATIENTNAME.CalcValue = MyParentReport.PatientName;
                    this.OPENINGDATE.CalcValue = episode.OpeningDate.ToString();
                    
                    
                    if (episode.Patient.UniqueRefNo.HasValue)
                        this.UNIQUEREFNO.CalcValue += episode.Patient.UniqueRefNo.Value.ToString();
                    
                    // Servis Adı ve Doktor
                    if (episode.PatientStatus == PatientStatusEnum.Outpatient)
                    {
                        if (episode.PatientAdmissions[0].AdmissionStatus.Value == AdmissionStatusEnum.SaglikKurulu)
                            this.SERVICENAME.CalcValue = episode.EpisodeActions.FirstOrDefault(x => x.GetType() == typeof(HealthCommittee)).MasterResource.Name;
                        else
                            this.SERVICENAME.CalcValue = episode.GetExaminationPoliclinic()?.Name;

                        this.DOCTORNAME.CalcValue = episode.GetPatientExaminationDoctor()?.Name;
                    }
                    else
                    {
                        InPatientTreatmentClinicApplication lastclinicTreatment = null;
                        foreach (InpatientAdmission inpadmission in episode.InpatientAdmissions.OrderByDescending(dr => dr.HospitalInPatientDate))
                        {
                            if (inpadmission.IsCancelled == false)
                            {
                                this.INPATIENTDATE.CalcValue = inpadmission.HospitalInPatientDate.ToString();
                                this.DISCHARGEDATE.CalcValue = inpadmission.HospitalDischargeDate.ToString();
                                foreach (InPatientTreatmentClinicApplication ipTCliniCApp in inpadmission.InPatientTreatmentClinicApplications)
                                {
                                    if (lastclinicTreatment == null)
                                        lastclinicTreatment = ipTCliniCApp;
                                    else if (ipTCliniCApp.RequestDate != null && ipTCliniCApp.RequestDate > lastclinicTreatment.RequestDate)
                                        lastclinicTreatment = ipTCliniCApp;
                                }
                                break;
                            }
                        }
                        if(lastclinicTreatment != null)
                        {
                            this.SERVICENAME.CalcValue = lastclinicTreatment.MasterResource.Name;
                            this.DOCTORNAME.CalcValue = lastclinicTreatment.ProcedureDoctor.Name;
                        }
                    }
                    
                    // Tanı
                    string diagnosisCodePrimer = string.Empty; // "ICD10 KODU     : ";
                    string diagnosisStrPrimer = string.Empty; // "ICD10 AÇIKLAMA : ";
                    IList primerDiagnosisList = new List<string>();

                    string diagnosisCodeSeconder = string.Empty; // "ICD10 KODU     : ";
                    string diagnosisStrSeconder = string.Empty; // "ICD10 AÇIKLAMA : ";
                    IList seconderDiagnosisList = new List<string>();
                    int seconderDiagnosisExists = 0;

                    foreach (DiagnosisGrid dg in episode.Diagnosis)
                    {
                        if (dg.DiagnosisType == DiagnosisTypeEnum.Seconder)
                        {
                            if (!seconderDiagnosisList.Contains(dg.DiagnoseCode))
                            {
                                diagnosisCodeSeconder += dg.DiagnoseCode + " , ";
                                diagnosisStrSeconder += dg.Diagnose + " , ";
                                seconderDiagnosisList.Add(dg.DiagnoseCode);
                                seconderDiagnosisExists++;
                            }
                        }
                        else if (dg.DiagnosisType == DiagnosisTypeEnum.Primer && seconderDiagnosisExists == 0)
                        {
                            if (!primerDiagnosisList.Contains(dg.DiagnoseCode))
                            {
                                diagnosisCodePrimer += dg.DiagnoseCode + " , ";
                                diagnosisStrPrimer += dg.Diagnose + " , ";
                                primerDiagnosisList.Add(dg.DiagnoseCode);
                            }
                        }
                    }

                    if (seconderDiagnosisExists > 0)
                    {
                        //if (!string.IsNullOrEmpty(diagnosisCodeSeconder))
                        //    this.ICD10CODE.CalcValue = diagnosisCodeSeconder.Substring(0, diagnosisCodeSeconder.Length - 3);
                        if (!string.IsNullOrEmpty(diagnosisStrSeconder))
                            this.ICD10.CalcValue = diagnosisStrSeconder.Substring(0, diagnosisStrSeconder.Length - 3);
                    }
                    else if (seconderDiagnosisExists == 0)
                    {
                        //if (!string.IsNullOrEmpty(diagnosisCodePrimer))
                        //    this.ICD10CODE.CalcValue = diagnosisCodePrimer.Substring(0, diagnosisCodePrimer.Length - 3);
                        if (!string.IsNullOrEmpty(diagnosisStrPrimer))
                            this.ICD10.CalcValue = diagnosisStrPrimer.Substring(0, diagnosisStrPrimer.Length - 3);
                    }
                }

                // Fatura Numarasının Seri No Kısmının yazılması istenmiyor, sadece Sıra No sunun yazılması isteniyor.
                if (!string.IsNullOrEmpty(pid.DocumentNo))
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (Char ch in pid.DocumentNo)
                        if (Char.IsDigit(ch))
                        sb.Append(ch);

                    this.DOCUMENTNO.CalcValue = sb.ToString();
                }

                // Cashier ın bilgilieri gösterilir veya gösterilmez
                if (TTObjectClasses.SystemParameter.GetParameterValue("PAYERINVOICEREPORTSHOWCASHIERINFO", "TRUE") == "TRUE")
                {
                    if (pid.ResUser != null)
                    {
                        this.CASHIERNAME.CalcValue = pid.ResUser.Name;

                        if (pid.ResUser.UserType.HasValue)
                            this.CASHIERTITLE.CalcValue = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(pid.ResUser.UserType.Value);

                        if (pid.ResUser.EmploymentRecordID != null)
                            this.CASHIERRECID.CalcValue = pid.ResUser.EmploymentRecordID;
                    }
                }

                if (MyParentReport.PageNumber == 1)
                    MyParentReport.TurnOverTotal = 0;

                MyParentReport.PageTotal = 0;
                this.TURNOVERTOTAL.CalcValue = MyParentReport.TurnOverTotal.ToString();

                if (MyParentReport.TurnOverTotal == 0)
                {
                    this.TURNOVERTOTAL.Visible = EvetHayirEnum.ehHayir;
                    this.TURNOVERTOTALLABEL.Visible = EvetHayirEnum.ehHayir;
                }
                else
                {
                    this.TURNOVERTOTAL.Visible = EvetHayirEnum.ehEvet;
                    this.TURNOVERTOTALLABEL.Visible = EvetHayirEnum.ehEvet;
                }
                this.PAGENO.CalcValue = MyParentReport.PageNumber.ToString();
                // FATURADIR ibaresi sistem parametresinin değerine göre görünür veya görünmez
                //if (TTObjectClasses.SystemParameter.GetParameterValue("SHOWINVOICELABELONPAYERINVOICEREPORT", "FALSE") == "TRUE")
                //{
                //    // Ortez-Protez Faturalarında FATURADIR ibaresi istenmiyor
                //    if (payerInv != null && payerInv.PROCEDUREGROUP != CollectedInvoiceProcedureGroupEnum.OrthesisProsthesis)
                //        this.INVOICELABEL.Visible = EvetHayirEnum.ehEvet;
                //}

                // Misafir XXXXXX Personeller için ülke bilgisi
                //this.MAPULKE.Visible = EvetHayirEnum.ehHayir;
                //ATLAS için kaldırıldı BB
                /*if(episode != null)
                        {
                            if(episode.PatientAdmission != null && episode.PatientAdmission is PA_VisitorMilitary)
                            {
                                if(((PA_VisitorMilitary)episode.PatientAdmission).Country != null)
                                {
                                    this.MAPULKE.CalcValue = "ÜLKE           : " + ((PA_VisitorMilitary)episode.PatientAdmission).Country.Name;
                                    this.MAPULKE.Visible = EvetHayirEnum.ehEvet;
                                }
                            }
                        }*/
            }
#endregion HEAD HEADER_Script
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public InvoiceCollectionInvoicesReport2 MyParentReport
                {
                    get { return (InvoiceCollectionInvoicesReport2)ParentReport; }
                }
                
                public TTReportField TOTAL;
                public TTReportField SEVKTARIHIFOOTER;
                public TTReportField TOTALPRICE;
                public TTReportField TOTALDISCOUNTPRICE;
                public TTReportField GENERALTOTALPRICE;
                public TTReportField PAGETOTALLABEL;
                public TTReportField PAGETOTAL;
                public TTReportField TL1;
                public TTReportField TL2;
                public TTReportField TL3;
                public TTReportField TL4;
                public TTReportField SEVKNOFOOTER;
                public TTReportField NewField112;
                public TTReportField NewField123;
                public TTReportField TEDAVITOPLAMI;
                public TTReportField NewField1211;
                public TTReportField NewField1321;
                public TTReportField ILACTOPLAMI;
                public TTReportField NewField1212;
                public TTReportField NewField1322;
                public TTReportField SARFTOPLAMI;
                public TTReportField NewField1213;
                public TTReportField NewField1323;
                public TTReportField NewField9;
                public TTReportField NewField13231;
                public TTReportField NewField10;
                public TTReportField NewField13;
                public TTReportShape NewRect4;
                public TTReportField NewField14;
                public TTReportField HOSPITALNAMEFOOTER;
                public TTReportField NewField15;
                public TTReportField NewField151;
                public TTReportField NewField17;
                public TTReportField NewField171;
                public TTReportField PAYERFOOTER;
                public TTReportField HPROTNOFOOTER;
                public TTReportField NewField11224;
                public TTReportField NewField1113;
                public TTReportField DOCUMENTNOFOOTER;
                public TTReportField NewField11122112;
                public TTReportField NewField1111112;
                public TTReportField DOCUMENTDATEFOOTER;
                public TTReportField NewField1112212;
                public TTReportField NewField111112;
                public TTReportField PAGENOFOOTER;
                public TTReportField NewField111122111;
                public TTReportField NewField11111111;
                public TTReportField NewField1111221111;
                public TTReportField NewField111111111;
                public TTReportField NewField18;
                public TTReportField PRICEWITHLETTERS;
                public TTReportField HPROTNOANDPATIENTNAME;
                public TTReportField PRICE;
                public TTReportShape NewLine131; 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 75;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 16, 208, 21, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL.TextFormat = @"#,##0.#0";
                    TOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTAL.TextFont.Name = "Arial";
                    TOTAL.TextFont.Size = 9;
                    TOTAL.TextFont.Bold = true;
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"";

                    SEVKTARIHIFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 272, 70, 344, 74, false);
                    SEVKTARIHIFOOTER.Name = "SEVKTARIHIFOOTER";
                    SEVKTARIHIFOOTER.Visible = EvetHayirEnum.ehHayir;
                    SEVKTARIHIFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEVKTARIHIFOOTER.TextFormat = @"dd/MM/yyyy";
                    SEVKTARIHIFOOTER.TextFont.Size = 8;
                    SEVKTARIHIFOOTER.TextFont.CharSet = 162;
                    SEVKTARIHIFOOTER.Value = @"{%HEAD.SEVKTARIHI%}";

                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 51, 204, 56, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPRICE.TextFont.Name = "Arial";
                    TOTALPRICE.TextFont.Size = 9;
                    TOTALPRICE.TextFont.Bold = true;
                    TOTALPRICE.TextFont.CharSet = 162;
                    TOTALPRICE.Value = @"{#TOTALPRICE#}";

                    TOTALDISCOUNTPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 255, 17, 284, 21, false);
                    TOTALDISCOUNTPRICE.Name = "TOTALDISCOUNTPRICE";
                    TOTALDISCOUNTPRICE.Visible = EvetHayirEnum.ehHayir;
                    TOTALDISCOUNTPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALDISCOUNTPRICE.TextFormat = @"#,##0.#0";
                    TOTALDISCOUNTPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALDISCOUNTPRICE.TextFont.Size = 8;
                    TOTALDISCOUNTPRICE.TextFont.CharSet = 162;
                    TOTALDISCOUNTPRICE.Value = @"{#TOTALDISCOUNTPRICE#}";

                    GENERALTOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 22, 284, 27, false);
                    GENERALTOTALPRICE.Name = "GENERALTOTALPRICE";
                    GENERALTOTALPRICE.Visible = EvetHayirEnum.ehHayir;
                    GENERALTOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    GENERALTOTALPRICE.TextFormat = @"#,##0.#0";
                    GENERALTOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GENERALTOTALPRICE.TextFont.Size = 8;
                    GENERALTOTALPRICE.TextFont.CharSet = 162;
                    GENERALTOTALPRICE.Value = @"{#GENERALTOTALPRICE#}";

                    PAGETOTALLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 7, 254, 11, false);
                    PAGETOTALLABEL.Name = "PAGETOTALLABEL";
                    PAGETOTALLABEL.Visible = EvetHayirEnum.ehHayir;
                    PAGETOTALLABEL.TextFont.Size = 8;
                    PAGETOTALLABEL.TextFont.CharSet = 162;
                    PAGETOTALLABEL.Value = @"Sayfa Toplamı:";

                    PAGETOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 255, 7, 284, 11, false);
                    PAGETOTAL.Name = "PAGETOTAL";
                    PAGETOTAL.Visible = EvetHayirEnum.ehHayir;
                    PAGETOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGETOTAL.TextFormat = @"#,##0.#0";
                    PAGETOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGETOTAL.TextFont.Size = 8;
                    PAGETOTAL.TextFont.CharSet = 162;
                    PAGETOTAL.Value = @"";

                    TL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 288, 7, 293, 11, false);
                    TL1.Name = "TL1";
                    TL1.Visible = EvetHayirEnum.ehHayir;
                    TL1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TL1.TextFont.Size = 8;
                    TL1.TextFont.CharSet = 162;
                    TL1.Value = @"TL";

                    TL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 288, 12, 293, 16, false);
                    TL2.Name = "TL2";
                    TL2.Visible = EvetHayirEnum.ehHayir;
                    TL2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TL2.TextFont.Size = 8;
                    TL2.TextFont.CharSet = 162;
                    TL2.Value = @"TL";

                    TL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 288, 17, 293, 21, false);
                    TL3.Name = "TL3";
                    TL3.Visible = EvetHayirEnum.ehHayir;
                    TL3.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TL3.TextFont.Size = 8;
                    TL3.TextFont.CharSet = 162;
                    TL3.Value = @"TL";

                    TL4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 288, 22, 293, 26, false);
                    TL4.Name = "TL4";
                    TL4.Visible = EvetHayirEnum.ehHayir;
                    TL4.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TL4.TextFont.Size = 8;
                    TL4.TextFont.CharSet = 162;
                    TL4.Value = @"TL";

                    SEVKNOFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 272, 66, 344, 70, false);
                    SEVKNOFOOTER.Name = "SEVKNOFOOTER";
                    SEVKNOFOOTER.Visible = EvetHayirEnum.ehHayir;
                    SEVKNOFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEVKNOFOOTER.TextFont.Size = 8;
                    SEVKNOFOOTER.TextFont.CharSet = 162;
                    SEVKNOFOOTER.Value = @"{%HEAD.SEVKNO%}";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 1, 169, 6, false);
                    NewField112.Name = "NewField112";
                    NewField112.TextFont.Name = "Arial";
                    NewField112.TextFont.Size = 9;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"Tedavi Toplamı";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 1, 171, 6, false);
                    NewField123.Name = "NewField123";
                    NewField123.TextFont.Name = "Arial";
                    NewField123.TextFont.Size = 9;
                    NewField123.TextFont.Bold = true;
                    NewField123.TextFont.CharSet = 162;
                    NewField123.Value = @":";

                    TEDAVITOPLAMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 1, 208, 6, false);
                    TEDAVITOPLAMI.Name = "TEDAVITOPLAMI";
                    TEDAVITOPLAMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEDAVITOPLAMI.TextFormat = @"#,##0.#0";
                    TEDAVITOPLAMI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TEDAVITOPLAMI.TextFont.Name = "Arial";
                    TEDAVITOPLAMI.TextFont.Size = 9;
                    TEDAVITOPLAMI.TextFont.Bold = true;
                    TEDAVITOPLAMI.TextFont.CharSet = 162;
                    TEDAVITOPLAMI.Value = @"";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 6, 169, 11, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.TextFont.Name = "Arial";
                    NewField1211.TextFont.Size = 9;
                    NewField1211.TextFont.Bold = true;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @"İlaç Toplamı";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 6, 171, 11, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.TextFont.Name = "Arial";
                    NewField1321.TextFont.Size = 9;
                    NewField1321.TextFont.Bold = true;
                    NewField1321.TextFont.CharSet = 162;
                    NewField1321.Value = @":";

                    ILACTOPLAMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 6, 208, 11, false);
                    ILACTOPLAMI.Name = "ILACTOPLAMI";
                    ILACTOPLAMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ILACTOPLAMI.TextFormat = @"#,##0.#0";
                    ILACTOPLAMI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ILACTOPLAMI.TextFont.Name = "Arial";
                    ILACTOPLAMI.TextFont.Size = 9;
                    ILACTOPLAMI.TextFont.Bold = true;
                    ILACTOPLAMI.TextFont.CharSet = 162;
                    ILACTOPLAMI.Value = @"{#DRUGTOTAL#}";

                    NewField1212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 11, 169, 16, false);
                    NewField1212.Name = "NewField1212";
                    NewField1212.TextFont.Name = "Arial";
                    NewField1212.TextFont.Size = 9;
                    NewField1212.TextFont.Bold = true;
                    NewField1212.TextFont.CharSet = 162;
                    NewField1212.Value = @"Sarf Toplamı";

                    NewField1322 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 11, 171, 16, false);
                    NewField1322.Name = "NewField1322";
                    NewField1322.TextFont.Name = "Arial";
                    NewField1322.TextFont.Size = 9;
                    NewField1322.TextFont.Bold = true;
                    NewField1322.TextFont.CharSet = 162;
                    NewField1322.Value = @":";

                    SARFTOPLAMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 11, 208, 16, false);
                    SARFTOPLAMI.Name = "SARFTOPLAMI";
                    SARFTOPLAMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SARFTOPLAMI.TextFormat = @"#,##0.#0";
                    SARFTOPLAMI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SARFTOPLAMI.TextFont.Name = "Arial";
                    SARFTOPLAMI.TextFont.Size = 9;
                    SARFTOPLAMI.TextFont.Bold = true;
                    SARFTOPLAMI.TextFont.CharSet = 162;
                    SARFTOPLAMI.Value = @"{#MATERIALTOTAL#}";

                    NewField1213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 16, 169, 21, false);
                    NewField1213.Name = "NewField1213";
                    NewField1213.TextFont.Name = "Arial";
                    NewField1213.TextFont.Size = 9;
                    NewField1213.TextFont.Bold = true;
                    NewField1213.TextFont.CharSet = 162;
                    NewField1213.Value = @"Genel Toplam";

                    NewField1323 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 16, 171, 21, false);
                    NewField1323.Name = "NewField1323";
                    NewField1323.TextFont.Name = "Arial";
                    NewField1323.TextFont.Size = 9;
                    NewField1323.TextFont.Bold = true;
                    NewField1323.TextFont.CharSet = 162;
                    NewField1323.Value = @":";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 16, 15, 21, false);
                    NewField9.Name = "NewField9";
                    NewField9.TextFont.Name = "Arial";
                    NewField9.TextFont.Size = 9;
                    NewField9.TextFont.Bold = true;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @"Yalnız";

                    NewField13231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 16, 17, 21, false);
                    NewField13231.Name = "NewField13231";
                    NewField13231.TextFont.Name = "Arial";
                    NewField13231.TextFont.Size = 9;
                    NewField13231.TextFont.Bold = true;
                    NewField13231.TextFont.CharSet = 162;
                    NewField13231.Value = @";";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 22, 208, 25, false);
                    NewField10.Name = "NewField10";
                    NewField10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField10.TextFont.Name = "Arial";
                    NewField10.TextFont.Size = 6;
                    NewField10.TextFont.CharSet = 162;
                    NewField10.Value = @"488 Sayılı Kanunun 8. Maddesine göre Döner Sermayeler Maliye Bakanlığının 25.5.1965 tarih ve 110.107-580/20720 No'lu yazısı ile Resmi Dairelerden sayıldıklarından damga vergisinden muaftır";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 25, 208, 29, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"VERGİ USUL KANUNU HÜKÜMLERİNE TABİ DEĞİLDİR.";

                    NewRect4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 5, 30, 208, 63, false);
                    NewRect4.Name = "NewRect4";
                    NewRect4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect4.FillStyle = FillStyleConstants.vbFSTransparent;

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 64, 208, 74, false);
                    NewField14.Name = "NewField14";
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.TextFont.Name = "Arial Narrow";
                    NewField14.TextFont.Size = 7;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"DİKKAT! MUHASEBENDE BORÇ KAYDINIZIN SİLİNEBİLMESİ İÇİN ÖDEMESİNİ YAPTIĞINIZ FATURANIN NUMARASINI VE TARHİNİN TARAFIMIZA BİLDİRİLMESİ GEREKMEKTEDİR.";

                    HOSPITALNAMEFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 31, 101, 46, false);
                    HOSPITALNAMEFOOTER.Name = "HOSPITALNAMEFOOTER";
                    HOSPITALNAMEFOOTER.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAMEFOOTER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAMEFOOTER.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALNAMEFOOTER.NoClip = EvetHayirEnum.ehEvet;
                    HOSPITALNAMEFOOTER.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALNAMEFOOTER.ExpandTabs = EvetHayirEnum.ehEvet;
                    HOSPITALNAMEFOOTER.TextFont.Name = "Arial";
                    HOSPITALNAMEFOOTER.TextFont.Size = 9;
                    HOSPITALNAMEFOOTER.TextFont.Bold = true;
                    HOSPITALNAMEFOOTER.TextFont.CharSet = 162;
                    HOSPITALNAMEFOOTER.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 47, 22, 52, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Size = 9;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Hasta Adı";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 52, 22, 57, false);
                    NewField151.Name = "NewField151";
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.Size = 9;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"Kurum";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 47, 24, 52, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Size = 9;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @":";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 52, 24, 57, false);
                    NewField171.Name = "NewField171";
                    NewField171.TextFont.Name = "Arial";
                    NewField171.TextFont.Size = 9;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @":";

                    PAYERFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 52, 101, 62, false);
                    PAYERFOOTER.Name = "PAYERFOOTER";
                    PAYERFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERFOOTER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYERFOOTER.MultiLine = EvetHayirEnum.ehEvet;
                    PAYERFOOTER.WordBreak = EvetHayirEnum.ehEvet;
                    PAYERFOOTER.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYERFOOTER.TextFont.Name = "Arial";
                    PAYERFOOTER.TextFont.Size = 9;
                    PAYERFOOTER.TextFont.CharSet = 162;
                    PAYERFOOTER.Value = @"{#PAYERCODE#} {#PAYERNAME#} {#PAYERCITYNAME#}";

                    HPROTNOFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 31, 204, 36, false);
                    HPROTNOFOOTER.Name = "HPROTNOFOOTER";
                    HPROTNOFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTNOFOOTER.TextFont.Name = "Arial";
                    HPROTNOFOOTER.TextFont.Size = 9;
                    HPROTNOFOOTER.TextFont.Bold = true;
                    HPROTNOFOOTER.TextFont.CharSet = 162;
                    HPROTNOFOOTER.Value = @"";

                    NewField11224 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 31, 167, 36, false);
                    NewField11224.Name = "NewField11224";
                    NewField11224.TextFont.Name = "Arial";
                    NewField11224.TextFont.Size = 9;
                    NewField11224.TextFont.Bold = true;
                    NewField11224.TextFont.CharSet = 162;
                    NewField11224.Value = @":";

                    NewField1113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 31, 165, 36, false);
                    NewField1113.Name = "NewField1113";
                    NewField1113.TextFont.Name = "Arial";
                    NewField1113.TextFont.Size = 9;
                    NewField1113.TextFont.Bold = true;
                    NewField1113.TextFont.CharSet = 162;
                    NewField1113.Value = @"Protokol No";

                    DOCUMENTNOFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 36, 204, 41, false);
                    DOCUMENTNOFOOTER.Name = "DOCUMENTNOFOOTER";
                    DOCUMENTNOFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNOFOOTER.TextFont.Name = "Arial";
                    DOCUMENTNOFOOTER.TextFont.Size = 9;
                    DOCUMENTNOFOOTER.TextFont.Bold = true;
                    DOCUMENTNOFOOTER.TextFont.CharSet = 162;
                    DOCUMENTNOFOOTER.Value = @"{#DOCUMENTNO#}";

                    NewField11122112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 36, 167, 41, false);
                    NewField11122112.Name = "NewField11122112";
                    NewField11122112.TextFont.Name = "Arial";
                    NewField11122112.TextFont.Size = 9;
                    NewField11122112.TextFont.Bold = true;
                    NewField11122112.TextFont.CharSet = 162;
                    NewField11122112.Value = @":";

                    NewField1111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 36, 165, 41, false);
                    NewField1111112.Name = "NewField1111112";
                    NewField1111112.TextFont.Name = "Arial";
                    NewField1111112.TextFont.Size = 9;
                    NewField1111112.TextFont.Bold = true;
                    NewField1111112.TextFont.CharSet = 162;
                    NewField1111112.Value = @"Fatura No";

                    DOCUMENTDATEFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 41, 204, 46, false);
                    DOCUMENTDATEFOOTER.Name = "DOCUMENTDATEFOOTER";
                    DOCUMENTDATEFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTDATEFOOTER.TextFormat = @"dd/MM/yyyy";
                    DOCUMENTDATEFOOTER.TextFont.Name = "Arial";
                    DOCUMENTDATEFOOTER.TextFont.Size = 9;
                    DOCUMENTDATEFOOTER.TextFont.Bold = true;
                    DOCUMENTDATEFOOTER.TextFont.CharSet = 162;
                    DOCUMENTDATEFOOTER.Value = @"{#DOCUMENTDATE#}";

                    NewField1112212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 41, 167, 46, false);
                    NewField1112212.Name = "NewField1112212";
                    NewField1112212.TextFont.Name = "Arial";
                    NewField1112212.TextFont.Size = 9;
                    NewField1112212.TextFont.Bold = true;
                    NewField1112212.TextFont.CharSet = 162;
                    NewField1112212.Value = @":";

                    NewField111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 41, 165, 46, false);
                    NewField111112.Name = "NewField111112";
                    NewField111112.TextFont.Name = "Arial";
                    NewField111112.TextFont.Size = 9;
                    NewField111112.TextFont.Bold = true;
                    NewField111112.TextFont.CharSet = 162;
                    NewField111112.Value = @"Fatura Tarihi";

                    PAGENOFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 46, 204, 51, false);
                    PAGENOFOOTER.Name = "PAGENOFOOTER";
                    PAGENOFOOTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENOFOOTER.TextFont.Name = "Arial";
                    PAGENOFOOTER.TextFont.Size = 9;
                    PAGENOFOOTER.TextFont.Bold = true;
                    PAGENOFOOTER.TextFont.CharSet = 162;
                    PAGENOFOOTER.Value = @"";

                    NewField111122111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 46, 167, 51, false);
                    NewField111122111.Name = "NewField111122111";
                    NewField111122111.TextFont.Name = "Arial";
                    NewField111122111.TextFont.Size = 9;
                    NewField111122111.TextFont.Bold = true;
                    NewField111122111.TextFont.CharSet = 162;
                    NewField111122111.Value = @":";

                    NewField11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 46, 165, 51, false);
                    NewField11111111.Name = "NewField11111111";
                    NewField11111111.TextFont.Name = "Arial";
                    NewField11111111.TextFont.Size = 9;
                    NewField11111111.TextFont.Bold = true;
                    NewField11111111.TextFont.CharSet = 162;
                    NewField11111111.Value = @"Sayfa No";

                    NewField1111221111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 51, 167, 56, false);
                    NewField1111221111.Name = "NewField1111221111";
                    NewField1111221111.TextFont.Name = "Arial";
                    NewField1111221111.TextFont.Size = 9;
                    NewField1111221111.TextFont.Bold = true;
                    NewField1111221111.TextFont.CharSet = 162;
                    NewField1111221111.Value = @":";

                    NewField111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 51, 165, 56, false);
                    NewField111111111.Name = "NewField111111111";
                    NewField111111111.TextFont.Name = "Arial";
                    NewField111111111.TextFont.Size = 9;
                    NewField111111111.TextFont.Bold = true;
                    NewField111111111.TextFont.CharSet = 162;
                    NewField111111111.Value = @"Fatura Toplam";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 48, 126, 62, false);
                    NewField18.Name = "NewField18";
                    NewField18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField18.TextFont.Name = "Arial Black";
                    NewField18.TextFont.Size = 28;
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @"B";

                    PRICEWITHLETTERS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 16, 139, 21, false);
                    PRICEWITHLETTERS.Name = "PRICEWITHLETTERS";
                    PRICEWITHLETTERS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICEWITHLETTERS.TextFormat = @"NUMBERTEXT(TL,KR)";
                    PRICEWITHLETTERS.TextFont.Name = "Arial";
                    PRICEWITHLETTERS.TextFont.Size = 9;
                    PRICEWITHLETTERS.TextFont.Bold = true;
                    PRICEWITHLETTERS.TextFont.CharSet = 162;
                    PRICEWITHLETTERS.Value = @"";

                    HPROTNOANDPATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 47, 101, 52, false);
                    HPROTNOANDPATIENTNAME.Name = "HPROTNOANDPATIENTNAME";
                    HPROTNOANDPATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPROTNOANDPATIENTNAME.TextFont.Name = "Arial";
                    HPROTNOANDPATIENTNAME.TextFont.Size = 9;
                    HPROTNOANDPATIENTNAME.TextFont.CharSet = 162;
                    HPROTNOANDPATIENTNAME.Value = @"";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 36, 251, 41, false);
                    PRICE.Name = "PRICE";
                    PRICE.Visible = EvetHayirEnum.ehHayir;
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"NUMBERTEXT(TL,KR)";
                    PRICE.TextFont.Name = "Arial";
                    PRICE.TextFont.Size = 8;
                    PRICE.TextFont.Bold = true;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"";

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 0, 208, 0, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PayerInvoiceDocument.PayerInvoiceReportInfoQuery_Class dataset_PayerInvoiceReportInfoQuery = ParentGroup.rsGroup.GetCurrentRecord<PayerInvoiceDocument.PayerInvoiceReportInfoQuery_Class>(0);
                    TOTAL.CalcValue = @"";
                    SEVKTARIHIFOOTER.CalcValue = MyParentReport.HEAD.SEVKTARIHI.FormattedValue;
                    TOTALPRICE.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.TotalPrice) : "");
                    TOTALDISCOUNTPRICE.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.TotalDiscountPrice) : "");
                    GENERALTOTALPRICE.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.GeneralTotalPrice) : "");
                    PAGETOTALLABEL.CalcValue = PAGETOTALLABEL.Value;
                    PAGETOTAL.CalcValue = @"";
                    TL1.CalcValue = TL1.Value;
                    TL2.CalcValue = TL2.Value;
                    TL3.CalcValue = TL3.Value;
                    TL4.CalcValue = TL4.Value;
                    SEVKNOFOOTER.CalcValue = MyParentReport.HEAD.SEVKNO.CalcValue;
                    NewField112.CalcValue = NewField112.Value;
                    NewField123.CalcValue = NewField123.Value;
                    TEDAVITOPLAMI.CalcValue = @"";
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    ILACTOPLAMI.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.Drugtotal) : "");
                    NewField1212.CalcValue = NewField1212.Value;
                    NewField1322.CalcValue = NewField1322.Value;
                    SARFTOPLAMI.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.Materialtotal) : "");
                    NewField1213.CalcValue = NewField1213.Value;
                    NewField1323.CalcValue = NewField1323.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField13231.CalcValue = NewField13231.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField171.CalcValue = NewField171.Value;
                    PAYERFOOTER.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.Payercode) : "") + @" " + (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.Payername) : "") + @" " + (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.Payercityname) : "");
                    HPROTNOFOOTER.CalcValue = @"";
                    NewField11224.CalcValue = NewField11224.Value;
                    NewField1113.CalcValue = NewField1113.Value;
                    DOCUMENTNOFOOTER.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.DocumentNo) : "");
                    NewField11122112.CalcValue = NewField11122112.Value;
                    NewField1111112.CalcValue = NewField1111112.Value;
                    DOCUMENTDATEFOOTER.CalcValue = (dataset_PayerInvoiceReportInfoQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportInfoQuery.DocumentDate) : "");
                    NewField1112212.CalcValue = NewField1112212.Value;
                    NewField111112.CalcValue = NewField111112.Value;
                    PAGENOFOOTER.CalcValue = @"";
                    NewField111122111.CalcValue = NewField111122111.Value;
                    NewField11111111.CalcValue = NewField11111111.Value;
                    NewField1111221111.CalcValue = NewField1111221111.Value;
                    NewField111111111.CalcValue = NewField111111111.Value;
                    NewField18.CalcValue = NewField18.Value;
                    PRICEWITHLETTERS.CalcValue = @"";
                    HPROTNOANDPATIENTNAME.CalcValue = @"";
                    PRICE.CalcValue = @"";
                    HOSPITALNAMEFOOTER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { TOTAL,SEVKTARIHIFOOTER,TOTALPRICE,TOTALDISCOUNTPRICE,GENERALTOTALPRICE,PAGETOTALLABEL,PAGETOTAL,TL1,TL2,TL3,TL4,SEVKNOFOOTER,NewField112,NewField123,TEDAVITOPLAMI,NewField1211,NewField1321,ILACTOPLAMI,NewField1212,NewField1322,SARFTOPLAMI,NewField1213,NewField1323,NewField9,NewField13231,NewField10,NewField13,NewField14,NewField15,NewField151,NewField17,NewField171,PAYERFOOTER,HPROTNOFOOTER,NewField11224,NewField1113,DOCUMENTNOFOOTER,NewField11122112,NewField1111112,DOCUMENTDATEFOOTER,NewField1112212,NewField111112,PAGENOFOOTER,NewField111122111,NewField11111111,NewField1111221111,NewField111111111,NewField18,PRICEWITHLETTERS,HPROTNOANDPATIENTNAME,PRICE,HOSPITALNAMEFOOTER};
                }

                public override void RunScript()
                {
#region HEAD FOOTER_Script
                    //            PayerInvoiceDocument pid = (PayerInvoiceDocument)MyParentReport.ReportObjectContext.GetObject(new Guid(MyParentReport.RuntimeParameters.TTOBJECTID), typeof(PayerInvoiceDocument));
            //            if (pid != null)
            //            {
            //                Episode episode = null;
            //                foreach (InvoiceCollectionDetail icd in pid.InvoiceCollectionDetails)
            //                {
            //                    if (icd.Episode != null)
            //                    {
            //                        episode = icd.Episode;
            //                        break;
            //                    }
            //                }

            //                if (episode != null)
            //                {
            //                    this.SEVKNOFOOTER.CalcValue = episode.DocumentNumber.Equals("0") ? string.Empty : episode.DocumentNumber;
            //                    this.SEVKTARIHIFOOTER.CalcValue = episode.DocumentDate.HasValue ? episode.DocumentDate.Value.ToShortDateString() : string.Empty;
            //                    this.HPROTNOFOOTER.CalcValue = episode.HospitalProtocolNo.Value.ToString();
            //                    this.PATIENTNAMEFOOTER.CalcValue = episode.Patient.FullName;
            //                    if (episode.Patient.UniqueRefNo.HasValue)
            //                        this.PATIENTNAMEFOOTER.CalcValue += " (" + episode.Patient.UniqueRefNo.Value.ToString() + ")";
            //                }

            //                //Fatura Numarasının Seri No Kısmının yazılması istenmiyor, sadece Sıra No sunun yazılması isteniyor.
            //                if (!string.IsNullOrEmpty(pid.DocumentNo))
            //                {
            //                    StringBuilder sb = new StringBuilder();

            //                    foreach (Char ch in pid.DocumentNo)
            //                        if (Char.IsDigit(ch))
            //                        sb.Append(ch);

            //                    this.DOCUMENTNOFOOTER.CalcValue = sb.ToString();
            //                }
            //            }

            this.HPROTNOFOOTER.CalcValue = MyParentReport.HPROTNO;
            this.HPROTNOANDPATIENTNAME.CalcValue = MyParentReport.HPROTNO + " - " + MyParentReport.PatientName;
            
            this.PAGETOTAL.CalcValue = MyParentReport.PageTotal.ToString();
            MyParentReport.TurnOverTotal += MyParentReport.PageTotal;
            this.PRICE.CalcValue = MyParentReport.TurnOverTotal.ToString();
            this.TOTAL.CalcValue = MyParentReport.TurnOverTotal.ToString();
            this.PRICEWITHLETTERS.CalcValue = MyParentReport.TurnOverTotal.ToString();

            this.PAGENOFOOTER.CalcValue = MyParentReport.PageNumber.ToString();
            //if (MyParentReport.IsLastPage)  // Bu düzgün çalışmazsa TOTAL == TOTALPRICE şeklinde kontrol edilebilir
            if(this.TOTAL.CalcValue.Equals(this.TOTALPRICE.CalcValue))
            {
                this.TEDAVITOPLAMI.CalcValue = Convert.ToString(Convert.ToDecimal(this.TOTALPRICE.CalcValue) - (Convert.ToDecimal(this.ILACTOPLAMI.CalcValue) + Convert.ToDecimal(this.SARFTOPLAMI.CalcValue)));
                this.TEDAVITOPLAMI.Visible = EvetHayirEnum.ehEvet;
                this.ILACTOPLAMI.Visible = EvetHayirEnum.ehEvet;
                this.SARFTOPLAMI.Visible = EvetHayirEnum.ehEvet;
                //this.PRICEWITHLETTERS.Visible = EvetHayirEnum.ehEvet;
                //this.TOTALPRICE.Visible = EvetHayirEnum.ehEvet;
                //this.TOTALDISCOUNTPRICE.Visible = EvetHayirEnum.ehEvet;
                //this.GENERALTOTALPRICE.Visible = EvetHayirEnum.ehEvet;
                //this.TL2.Visible = EvetHayirEnum.ehEvet;
                //this.TL3.Visible = EvetHayirEnum.ehEvet;
                //this.TL4.Visible = EvetHayirEnum.ehEvet;
            }
            else
            {
                this.TEDAVITOPLAMI.Visible = EvetHayirEnum.ehHayir;
                this.ILACTOPLAMI.Visible = EvetHayirEnum.ehHayir;
                this.SARFTOPLAMI.Visible = EvetHayirEnum.ehHayir;
                //this.PRICEWITHLETTERS.Visible = EvetHayirEnum.ehHayir;
                //this.TOTALPRICE.Visible = EvetHayirEnum.ehHayir;
                //this.TOTALDISCOUNTPRICE.Visible = EvetHayirEnum.ehHayir;
                //this.GENERALTOTALPRICE.Visible = EvetHayirEnum.ehHayir;
                //this.TL2.Visible = EvetHayirEnum.ehHayir;
                //this.TL3.Visible = EvetHayirEnum.ehHayir;
                //this.TL4.Visible = EvetHayirEnum.ehHayir;
            }
            MyParentReport.PageNumber++;
#endregion HEAD FOOTER_Script
                }
            }

        }

        public HEADGroup HEAD;

        public partial class TRXDESCGroup : TTReportGroup
        {
            public InvoiceCollectionInvoicesReport2 MyParentReport
            {
                get { return (InvoiceCollectionInvoicesReport2)ParentReport; }
            }

            new public TRXDESCGroupHeader Header()
            {
                return (TRXDESCGroupHeader)_header;
            }

            new public TRXDESCGroupFooter Footer()
            {
                return (TRXDESCGroupFooter)_footer;
            }

            public TTReportField GROUPNAME { get {return Header().GROUPNAME;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportShape NewLine112 { get {return Header().NewLine112;} }
            public TTReportShape NewLine113 { get {return Header().NewLine113;} }
            public TTReportShape NewLine114 { get {return Header().NewLine114;} }
            public TTReportShape NewLine115 { get {return Header().NewLine115;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TRXDESCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TRXDESCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PayerInvoiceDocument.PayerInvoiceReportQuery_Class>("PayerInvoiceReportQuery", PayerInvoiceDocument.PayerInvoiceReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.PARTA.PIDOBJECTID.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TRXDESCGroupHeader(this);
                _footer = new TRXDESCGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TRXDESCGroupHeader : TTReportSection
            {
                public InvoiceCollectionInvoicesReport2 MyParentReport
                {
                    get { return (InvoiceCollectionInvoicesReport2)ParentReport; }
                }
                
                public TTReportField GROUPNAME;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
                public TTReportShape NewLine112;
                public TTReportShape NewLine113;
                public TTReportShape NewLine114;
                public TTReportShape NewLine115;
                public TTReportShape NewLine1111; 
                public TRXDESCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 4;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    GROUPNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 0, 147, 4, false);
                    GROUPNAME.Name = "GROUPNAME";
                    GROUPNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    GROUPNAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    GROUPNAME.MultiLine = EvetHayirEnum.ehEvet;
                    GROUPNAME.WordBreak = EvetHayirEnum.ehEvet;
                    GROUPNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    GROUPNAME.TextFont.Name = "Arial";
                    GROUPNAME.TextFont.Size = 8;
                    GROUPNAME.TextFont.Bold = true;
                    GROUPNAME.TextFont.CharSet = 162;
                    GROUPNAME.Value = @"{#PRICINGGROUPDESCRIPTION#}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 0, 5, 4, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 19, 0, 19, 4, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 148, 0, 148, 4, false);
                    NewLine112.Name = "NewLine112";
                    NewLine112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine112.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 162, 0, 162, 4, false);
                    NewLine113.Name = "NewLine113";
                    NewLine113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine113.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine114 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 184, 0, 184, 4, false);
                    NewLine114.Name = "NewLine114";
                    NewLine114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine114.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine115 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 208, 0, 208, 4, false);
                    NewLine115.Name = "NewLine115";
                    NewLine115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine115.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 41, 0, 41, 4, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.ExtendTo = ExtendToEnum.extSectionHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PayerInvoiceDocument.PayerInvoiceReportQuery_Class dataset_PayerInvoiceReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PayerInvoiceDocument.PayerInvoiceReportQuery_Class>(0);
                    GROUPNAME.CalcValue = (dataset_PayerInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportQuery.Pricinggroupdescription) : "");
                    return new TTReportObject[] { GROUPNAME};
                }
            }
            public partial class TRXDESCGroupFooter : TTReportSection
            {
                public InvoiceCollectionInvoicesReport2 MyParentReport
                {
                    get { return (InvoiceCollectionInvoicesReport2)ParentReport; }
                }
                 
                public TRXDESCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public TRXDESCGroup TRXDESC;

        public partial class MAINGroup : TTReportGroup
        {
            public InvoiceCollectionInvoicesReport2 MyParentReport
            {
                get { return (InvoiceCollectionInvoicesReport2)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
            public TTReportField TRANSACTIONDATE { get {return Body().TRANSACTIONDATE;} }
            public TTReportField TRXNAME { get {return Body().TRXNAME;} }
            public TTReportField TRXEXTERNALCODE { get {return Body().TRXEXTERNALCODE;} }
            public TTReportField PACKAGEOUTREASON { get {return Body().PACKAGEOUTREASON;} }
            public TTReportField DAY { get {return Body().DAY;} }
            public TTReportField MONTH { get {return Body().MONTH;} }
            public TTReportField YEAR { get {return Body().YEAR;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine3 { get {return Body().NewLine3;} }
            public TTReportShape NewLine4 { get {return Body().NewLine4;} }
            public TTReportShape NewLine5 { get {return Body().NewLine5;} }
            public TTReportShape NewLine6 { get {return Body().NewLine6;} }
            public TTReportShape NewLine7 { get {return Body().NewLine7;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                PayerInvoiceDocument.PayerInvoiceReportQuery_Class dataSet_PayerInvoiceReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PayerInvoiceDocument.PayerInvoiceReportQuery_Class>(0);    
                return new object[] {(dataSet_PayerInvoiceReportQuery==null ? null : dataSet_PayerInvoiceReportQuery.Pricinggroupdescription)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public InvoiceCollectionInvoicesReport2 MyParentReport
                {
                    get { return (InvoiceCollectionInvoicesReport2)ParentReport; }
                }
                
                public TTReportField ORDERNO;
                public TTReportField DESCRIPTION;
                public TTReportField AMOUNT;
                public TTReportField UNITPRICE;
                public TTReportField PRICE;
                public TTReportField TRANSACTIONDATE;
                public TTReportField TRXNAME;
                public TTReportField TRXEXTERNALCODE;
                public TTReportField PACKAGEOUTREASON;
                public TTReportField DAY;
                public TTReportField MONTH;
                public TTReportField YEAR;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportShape NewLine5;
                public TTReportShape NewLine6;
                public TTReportShape NewLine7; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    RepeatCount = 0;
                    
                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 0, 18, 4, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO.MultiLine = EvetHayirEnum.ehEvet;
                    ORDERNO.WordBreak = EvetHayirEnum.ehEvet;
                    ORDERNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    ORDERNO.TextFont.Size = 8;
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 0, 147, 4, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Size = 8;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 0, 161, 4, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    AMOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    AMOUNT.ExpandTabs = EvetHayirEnum.ehEvet;
                    AMOUNT.TextFont.Size = 8;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#TRXDESC.AMOUNT#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 0, 183, 4, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"#,##0.#0";
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE.TextFont.Size = 8;
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#TRXDESC.UNITPRICE#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 0, 207, 4, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.MultiLine = EvetHayirEnum.ehEvet;
                    PRICE.WordBreak = EvetHayirEnum.ehEvet;
                    PRICE.ExpandTabs = EvetHayirEnum.ehEvet;
                    PRICE.TextFont.Size = 8;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"Convert.ToDouble(this.AMOUNT.CalcValue) * Convert.ToDouble(this.UNITPRICE.CalcValue)";

                    TRANSACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 40, 4, false);
                    TRANSACTIONDATE.Name = "TRANSACTIONDATE";
                    TRANSACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRANSACTIONDATE.MultiLine = EvetHayirEnum.ehEvet;
                    TRANSACTIONDATE.WordBreak = EvetHayirEnum.ehEvet;
                    TRANSACTIONDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    TRANSACTIONDATE.TextFont.Size = 8;
                    TRANSACTIONDATE.TextFont.CharSet = 162;
                    TRANSACTIONDATE.Value = @"";

                    TRXNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 0, 260, 5, false);
                    TRXNAME.Name = "TRXNAME";
                    TRXNAME.Visible = EvetHayirEnum.ehHayir;
                    TRXNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRXNAME.Value = @"{#TRXDESC.TRXNAME#}";

                    TRXEXTERNALCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 0, 297, 5, false);
                    TRXEXTERNALCODE.Name = "TRXEXTERNALCODE";
                    TRXEXTERNALCODE.Visible = EvetHayirEnum.ehHayir;
                    TRXEXTERNALCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRXEXTERNALCODE.Value = @"{#TRXDESC.TRXEXTERNALCODE#}";

                    PACKAGEOUTREASON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 0, 353, 5, false);
                    PACKAGEOUTREASON.Name = "PACKAGEOUTREASON";
                    PACKAGEOUTREASON.Visible = EvetHayirEnum.ehHayir;
                    PACKAGEOUTREASON.FieldType = ReportFieldTypeEnum.ftVariable;
                    PACKAGEOUTREASON.ObjectDefName = "PackageOutReasonEnum";
                    PACKAGEOUTREASON.DataMember = "DISPLAYTEXT";
                    PACKAGEOUTREASON.Value = @"{#TRXDESC.PACKAGEOUTREASON#}";

                    DAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 359, 0, 376, 4, false);
                    DAY.Name = "DAY";
                    DAY.Visible = EvetHayirEnum.ehHayir;
                    DAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAY.TextFont.Size = 8;
                    DAY.TextFont.CharSet = 162;
                    DAY.Value = @"{#TRXDESC.DAY#}";

                    MONTH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 378, 0, 395, 4, false);
                    MONTH.Name = "MONTH";
                    MONTH.Visible = EvetHayirEnum.ehHayir;
                    MONTH.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONTH.TextFont.Size = 8;
                    MONTH.TextFont.CharSet = 162;
                    MONTH.Value = @"{#TRXDESC.MONTH#}";

                    YEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 399, 0, 416, 4, false);
                    YEAR.Name = "YEAR";
                    YEAR.Visible = EvetHayirEnum.ehHayir;
                    YEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEAR.TextFont.Size = 8;
                    YEAR.TextFont.CharSet = 162;
                    YEAR.Value = @"{#TRXDESC.YEAR#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 0, 5, 4, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 19, 0, 19, 4, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine2.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 41, 0, 41, 4, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine3.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 148, 0, 148, 4, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine4.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 162, 0, 162, 4, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine5.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 184, 0, 184, 4, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine6.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 208, 0, 208, 4, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine7.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PayerInvoiceDocument.PayerInvoiceReportQuery_Class dataset_PayerInvoiceReportQuery = MyParentReport.TRXDESC.rsGroup.GetCurrentRecord<PayerInvoiceDocument.PayerInvoiceReportQuery_Class>(0);
                    ORDERNO.CalcValue = @"";
                    DESCRIPTION.CalcValue = @"";
                    AMOUNT.CalcValue = (dataset_PayerInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportQuery.Amount) : "");
                    UNITPRICE.CalcValue = (dataset_PayerInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportQuery.UnitPrice) : "");
                    PRICE.CalcValue = @"Convert.ToDouble(this.AMOUNT.CalcValue) * Convert.ToDouble(this.UNITPRICE.CalcValue)";
                    TRANSACTIONDATE.CalcValue = @"";
                    TRXNAME.CalcValue = (dataset_PayerInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportQuery.Trxname) : "");
                    TRXEXTERNALCODE.CalcValue = (dataset_PayerInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportQuery.Trxexternalcode) : "");
                    PACKAGEOUTREASON.CalcValue = (dataset_PayerInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportQuery.PackageOutReason) : "");
                    PACKAGEOUTREASON.PostFieldValueCalculation();
                    DAY.CalcValue = (dataset_PayerInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportQuery.Day) : "");
                    MONTH.CalcValue = (dataset_PayerInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportQuery.Month) : "");
                    YEAR.CalcValue = (dataset_PayerInvoiceReportQuery != null ? Globals.ToStringCore(dataset_PayerInvoiceReportQuery.Year) : "");
                    return new TTReportObject[] { ORDERNO,DESCRIPTION,AMOUNT,UNITPRICE,PRICE,TRANSACTIONDATE,TRXNAME,TRXEXTERNALCODE,PACKAGEOUTREASON,DAY,MONTH,YEAR};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    this.ORDERNO.CalcValue = MyParentReport.OrderNo.ToString();
            MyParentReport.OrderNo++;
            
            this.DESCRIPTION.CalcValue = this.TRXEXTERNALCODE.CalcValue + " " + this.TRXNAME.CalcValue ;
            
            if (this.PACKAGEOUTREASON.CalcValue != "")
                this.DESCRIPTION.CalcValue = this.DESCRIPTION.CalcValue + "(" + this.PACKAGEOUTREASON.CalcValue + ")" ;
            
            if(this.DAY.CalcValue.Length == 1)
                this.DAY.CalcValue = "0" + this.DAY.CalcValue;
            
            if(this.MONTH.CalcValue.Length == 1)
                this.MONTH.CalcValue = "0" + this.MONTH.CalcValue;
            
            this.TRANSACTIONDATE.CalcValue = this.DAY.CalcValue + "." + this.MONTH.CalcValue + "." + this.YEAR.CalcValue;
            this.PRICE.CalcValue = (Convert.ToDecimal(this.AMOUNT.CalcValue) * Convert.ToDecimal(this.UNITPRICE.CalcValue)).ToString();
           
            MyParentReport.PageTotal += Convert.ToDecimal(this.PRICE.CalcValue);
#endregion MAIN BODY_Script
                }
            }


            protected override bool RunScript()
            {
#region MAIN_Script
                if (this.MyParentReport.TRXDESC.IsLastData())
                MyParentReport.IsLastPage = true;
            else
                MyParentReport.IsLastPage = false;
            
            return true;
#endregion MAIN_Script
            }
        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public InvoiceCollectionInvoicesReport2()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            HEAD = new HEADGroup(PARTA,"HEAD");
            TRXDESC = new TRXDESCGroup(HEAD,"TRXDESC");
            MAIN = new MAINGroup(TRXDESC,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action guid", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "INVOICECOLLECTIONINVOICESREPORT2";
            Caption = "İcmal Faturaları (Atılış Sırası)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 256;
            p_PageWidth = 216;
            p_PageHeight = 305;
            DontUseWatermark = EvetHayirEnum.ehEvet;
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
            fd.TextFont.Name = "Courier New";
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