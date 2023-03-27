
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
    /// <summary>
    /// Vezne Alındısı
    /// </summary>
    public partial class CashOfficeReceiptDocumentReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public CashOfficeReceiptDocumentReport MyParentReport
            {
                get { return (CashOfficeReceiptDocumentReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField SPECIALNO { get {return Header().SPECIALNO;} }
            public TTReportField DESCRIPTION { get {return Header().DESCRIPTION;} }
            public TTReportField PAYEEUNIQUEREFNO { get {return Header().PAYEEUNIQUEREFNO;} }
            public TTReportField PAYEENAME { get {return Header().PAYEENAME;} }
            public TTReportField DOCUMENTNO1 { get {return Header().DOCUMENTNO1;} }
            public TTReportField DOSENAME { get {return Header().DOSENAME;} }
            public TTReportField DOCUMENTNO { get {return Header().DOCUMENTNO;} }
            public TTReportField LBL141 { get {return Header().LBL141;} }
            public TTReportField ACCOUNTOFFICENAME { get {return Header().ACCOUNTOFFICENAME;} }
            public TTReportField PAYEEADDRESS { get {return Header().PAYEEADDRESS;} }
            public TTReportField TOTALPRICE { get {return Footer().TOTALPRICE;} }
            public TTReportField TELEPHONE { get {return Footer().TELEPHONE;} }
            public TTReportField CASHIER { get {return Footer().CASHIER;} }
            public TTReportField DUZENLEYEN { get {return Footer().DUZENLEYEN;} }
            public TTReportField ACCOUNTANTTITLE { get {return Footer().ACCOUNTANTTITLE;} }
            public TTReportField TOTALPRICE1 { get {return Footer().TOTALPRICE1;} }
            public TTReportField REPORTDATE { get {return Footer().REPORTDATE;} }
            public TTReportField PRICEWITHLETTERSANDTYPE { get {return Footer().PRICEWITHLETTERSANDTYPE;} }
            public TTReportField PRICEWITHLETTERS { get {return Footer().PRICEWITHLETTERS;} }
            public TTReportField PAYMENTTYPE { get {return Footer().PAYMENTTYPE;} }
            public TTReportField ACCOUNTOFFICENAMEFOOTER { get {return Footer().ACCOUNTOFFICENAMEFOOTER;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<MainCashOfficeOperation.CashOfficeReceiptDocumentReportQuery_Class>("CashOfficeReceiptDocumentReportQuery", MainCashOfficeOperation.CashOfficeReceiptDocumentReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public CashOfficeReceiptDocumentReport MyParentReport
                {
                    get { return (CashOfficeReceiptDocumentReport)ParentReport; }
                }
                
                public TTReportField SPECIALNO;
                public TTReportField DESCRIPTION;
                public TTReportField PAYEEUNIQUEREFNO;
                public TTReportField PAYEENAME;
                public TTReportField DOCUMENTNO1;
                public TTReportField DOSENAME;
                public TTReportField DOCUMENTNO;
                public TTReportField LBL141;
                public TTReportField ACCOUNTOFFICENAME;
                public TTReportField PAYEEADDRESS; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 80;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    SPECIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 20, 245, 25, false);
                    SPECIALNO.Name = "SPECIALNO";
                    SPECIALNO.Visible = EvetHayirEnum.ehHayir;
                    SPECIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SPECIALNO.Value = @"{#SPECIALNO#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 68, 191, 72, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.CaseFormat = CaseFormatEnum.fcUpperCase;
                    DESCRIPTION.TextFont.Name = "Arial Narrow";
                    DESCRIPTION.TextFont.Bold = true;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    PAYEEUNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 58, 191, 62, false);
                    PAYEEUNIQUEREFNO.Name = "PAYEEUNIQUEREFNO";
                    PAYEEUNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYEEUNIQUEREFNO.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYEEUNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    PAYEEUNIQUEREFNO.TextFont.Bold = true;
                    PAYEEUNIQUEREFNO.TextFont.CharSet = 0;
                    PAYEEUNIQUEREFNO.Value = @"{#PAYEEUNIQUEREFNO#}";

                    PAYEENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 53, 191, 57, false);
                    PAYEENAME.Name = "PAYEENAME";
                    PAYEENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYEENAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYEENAME.TextFont.Name = "Arial Narrow";
                    PAYEENAME.TextFont.Bold = true;
                    PAYEENAME.TextFont.CharSet = 162;
                    PAYEENAME.Value = @"{#PAYEENAME#}";

                    DOCUMENTNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 42, 258, 47, false);
                    DOCUMENTNO1.Name = "DOCUMENTNO1";
                    DOCUMENTNO1.Visible = EvetHayirEnum.ehHayir;
                    DOCUMENTNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNO1.Value = @"{#DOCUMENTNO#}";

                    DOSENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 14, 81, 36, false);
                    DOSENAME.Name = "DOSENAME";
                    DOSENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    DOSENAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    DOSENAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOSENAME.TextFont.Name = "Arial Narrow";
                    DOSENAME.TextFont.CharSet = 0;
                    DOSENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")
";

                    DOCUMENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 39, 204, 44, false);
                    DOCUMENTNO.Name = "DOCUMENTNO";
                    DOCUMENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNO.TextFont.Name = "Arial Narrow";
                    DOCUMENTNO.TextFont.CharSet = 162;
                    DOCUMENTNO.Value = @"{#DOCUMENTNO#}";

                    LBL141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 39, 177, 44, false);
                    LBL141.Name = "LBL141";
                    LBL141.TextFont.Name = "Arial Narrow";
                    LBL141.TextFont.CharSet = 162;
                    LBL141.Value = @"Makbuz No :";

                    ACCOUNTOFFICENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 48, 191, 52, false);
                    ACCOUNTOFFICENAME.Name = "ACCOUNTOFFICENAME";
                    ACCOUNTOFFICENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTOFFICENAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ACCOUNTOFFICENAME.TextFont.Name = "Arial Narrow";
                    ACCOUNTOFFICENAME.TextFont.Bold = true;
                    ACCOUNTOFFICENAME.TextFont.CharSet = 162;
                    ACCOUNTOFFICENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RECEIPTREPORTACCOUNTOFFICENAME"", """")
";

                    PAYEEADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 63, 191, 67, false);
                    PAYEEADDRESS.Name = "PAYEEADDRESS";
                    PAYEEADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYEEADDRESS.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYEEADDRESS.MultiLine = EvetHayirEnum.ehEvet;
                    PAYEEADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    PAYEEADDRESS.TextFont.Name = "Arial Narrow";
                    PAYEEADDRESS.TextFont.Bold = true;
                    PAYEEADDRESS.TextFont.CharSet = 0;
                    PAYEEADDRESS.Value = @"{#HEADER.PAYEEADDRESS#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MainCashOfficeOperation.CashOfficeReceiptDocumentReportQuery_Class dataset_CashOfficeReceiptDocumentReportQuery = ParentGroup.rsGroup.GetCurrentRecord<MainCashOfficeOperation.CashOfficeReceiptDocumentReportQuery_Class>(0);
                    SPECIALNO.CalcValue = (dataset_CashOfficeReceiptDocumentReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeReceiptDocumentReportQuery.SpecialNo) : "");
                    DESCRIPTION.CalcValue = (dataset_CashOfficeReceiptDocumentReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeReceiptDocumentReportQuery.Description) : "");
                    PAYEEUNIQUEREFNO.CalcValue = (dataset_CashOfficeReceiptDocumentReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeReceiptDocumentReportQuery.PayeeUniqueRefNo) : "");
                    PAYEENAME.CalcValue = (dataset_CashOfficeReceiptDocumentReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeReceiptDocumentReportQuery.PayeeName) : "");
                    DOCUMENTNO1.CalcValue = (dataset_CashOfficeReceiptDocumentReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeReceiptDocumentReportQuery.DocumentNo) : "");
                    DOCUMENTNO.CalcValue = (dataset_CashOfficeReceiptDocumentReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeReceiptDocumentReportQuery.DocumentNo) : "");
                    LBL141.CalcValue = LBL141.Value;
                    PAYEEADDRESS.CalcValue = (dataset_CashOfficeReceiptDocumentReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeReceiptDocumentReportQuery.PayeeAddress) : "");
                    DOSENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "")
;
                    ACCOUNTOFFICENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RECEIPTREPORTACCOUNTOFFICENAME", "")
;
                    return new TTReportObject[] { SPECIALNO,DESCRIPTION,PAYEEUNIQUEREFNO,PAYEENAME,DOCUMENTNO1,DOCUMENTNO,LBL141,PAYEEADDRESS,DOSENAME,ACCOUNTOFFICENAME};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    this.DOCUMENTNO.CalcValue = AccountDocument.ReceiptDocumentNo(this.DOCUMENTNO.CalcValue);
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public CashOfficeReceiptDocumentReport MyParentReport
                {
                    get { return (CashOfficeReceiptDocumentReport)ParentReport; }
                }
                
                public TTReportField TOTALPRICE;
                public TTReportField TELEPHONE;
                public TTReportField CASHIER;
                public TTReportField DUZENLEYEN;
                public TTReportField ACCOUNTANTTITLE;
                public TTReportField TOTALPRICE1;
                public TTReportField REPORTDATE;
                public TTReportField PRICEWITHLETTERSANDTYPE;
                public TTReportField PRICEWITHLETTERS;
                public TTReportField PAYMENTTYPE;
                public TTReportField ACCOUNTOFFICENAMEFOOTER; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 38;
                    RepeatCount = 0;
                    
                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 5, 205, 10, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPRICE.TextFont.Name = "Arial Narrow";
                    TOTALPRICE.TextFont.Bold = true;
                    TOTALPRICE.TextFont.CharSet = 0;
                    TOTALPRICE.Value = @"{#TOTALPRICE#}";

                    TELEPHONE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 12, 245, 17, false);
                    TELEPHONE.Name = "TELEPHONE";
                    TELEPHONE.Visible = EvetHayirEnum.ehHayir;
                    TELEPHONE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TELEPHONE.Value = @"";

                    CASHIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 30, 211, 35, false);
                    CASHIER.Name = "CASHIER";
                    CASHIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CASHIER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CASHIER.MultiLine = EvetHayirEnum.ehEvet;
                    CASHIER.NoClip = EvetHayirEnum.ehEvet;
                    CASHIER.WordBreak = EvetHayirEnum.ehEvet;
                    CASHIER.ExpandTabs = EvetHayirEnum.ehEvet;
                    CASHIER.TextFont.Name = "Arial Narrow";
                    CASHIER.TextFont.Bold = true;
                    CASHIER.TextFont.CharSet = 162;
                    CASHIER.Value = @"{#CASHIERNAME#}";

                    DUZENLEYEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 33, 32, 37, false);
                    DUZENLEYEN.Name = "DUZENLEYEN";
                    DUZENLEYEN.Visible = EvetHayirEnum.ehHayir;
                    DUZENLEYEN.FieldType = ReportFieldTypeEnum.ftVariable;
                    DUZENLEYEN.Value = @"";

                    ACCOUNTANTTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 39, 201, 43, false);
                    ACCOUNTANTTITLE.Name = "ACCOUNTANTTITLE";
                    ACCOUNTANTTITLE.Visible = EvetHayirEnum.ehHayir;
                    ACCOUNTANTTITLE.Value = @"Döner Sermaye Veznedarı";

                    TOTALPRICE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 4, 245, 9, false);
                    TOTALPRICE1.Name = "TOTALPRICE1";
                    TOTALPRICE1.Visible = EvetHayirEnum.ehHayir;
                    TOTALPRICE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE1.Value = @"{#TOTALPRICE#}";

                    REPORTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 26, 211, 30, false);
                    REPORTDATE.Name = "REPORTDATE";
                    REPORTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTDATE.TextFormat = @"Short Date";
                    REPORTDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTDATE.TextFont.Name = "Arial Narrow";
                    REPORTDATE.TextFont.Bold = true;
                    REPORTDATE.TextFont.CharSet = 0;
                    REPORTDATE.Value = @"{#DOCUMENTDATE#}";

                    PRICEWITHLETTERSANDTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 15, 200, 20, false);
                    PRICEWITHLETTERSANDTYPE.Name = "PRICEWITHLETTERSANDTYPE";
                    PRICEWITHLETTERSANDTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICEWITHLETTERSANDTYPE.TextFont.Name = "Arial Narrow";
                    PRICEWITHLETTERSANDTYPE.TextFont.Bold = true;
                    PRICEWITHLETTERSANDTYPE.TextFont.CharSet = 0;
                    PRICEWITHLETTERSANDTYPE.Value = @"";

                    PRICEWITHLETTERS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 21, 257, 26, false);
                    PRICEWITHLETTERS.Name = "PRICEWITHLETTERS";
                    PRICEWITHLETTERS.Visible = EvetHayirEnum.ehHayir;
                    PRICEWITHLETTERS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICEWITHLETTERS.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PRICEWITHLETTERS.TextFormat = @"NUMBERTEXT( TL , KR)";
                    PRICEWITHLETTERS.Value = @"{%TOTALPRICE1%}";

                    PAYMENTTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 29, 257, 34, false);
                    PAYMENTTYPE.Name = "PAYMENTTYPE";
                    PAYMENTTYPE.Visible = EvetHayirEnum.ehHayir;
                    PAYMENTTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYMENTTYPE.ObjectDefName = "PaymentTypeEnum";
                    PAYMENTTYPE.DataMember = "DISPLAYTEXT";
                    PAYMENTTYPE.Value = @"{#PAYMENTTYPE#}";

                    ACCOUNTOFFICENAMEFOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 12, 75, 22, false);
                    ACCOUNTOFFICENAMEFOOTER.Name = "ACCOUNTOFFICENAMEFOOTER";
                    ACCOUNTOFFICENAMEFOOTER.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTOFFICENAMEFOOTER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ACCOUNTOFFICENAMEFOOTER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACCOUNTOFFICENAMEFOOTER.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTOFFICENAMEFOOTER.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTOFFICENAMEFOOTER.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTOFFICENAMEFOOTER.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTOFFICENAMEFOOTER.TextFont.Name = "Arial Narrow";
                    ACCOUNTOFFICENAMEFOOTER.TextFont.Bold = true;
                    ACCOUNTOFFICENAMEFOOTER.TextFont.CharSet = 162;
                    ACCOUNTOFFICENAMEFOOTER.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RECEIPTREPORTACCOUNTOFFICENAME"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MainCashOfficeOperation.CashOfficeReceiptDocumentReportQuery_Class dataset_CashOfficeReceiptDocumentReportQuery = ParentGroup.rsGroup.GetCurrentRecord<MainCashOfficeOperation.CashOfficeReceiptDocumentReportQuery_Class>(0);
                    TOTALPRICE.CalcValue = (dataset_CashOfficeReceiptDocumentReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeReceiptDocumentReportQuery.TotalPrice) : "");
                    TELEPHONE.CalcValue = @"";
                    CASHIER.CalcValue = (dataset_CashOfficeReceiptDocumentReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeReceiptDocumentReportQuery.Cashiername) : "");
                    DUZENLEYEN.CalcValue = @"";
                    ACCOUNTANTTITLE.CalcValue = ACCOUNTANTTITLE.Value;
                    TOTALPRICE1.CalcValue = (dataset_CashOfficeReceiptDocumentReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeReceiptDocumentReportQuery.TotalPrice) : "");
                    REPORTDATE.CalcValue = (dataset_CashOfficeReceiptDocumentReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeReceiptDocumentReportQuery.DocumentDate) : "");
                    PRICEWITHLETTERSANDTYPE.CalcValue = @"";
                    PRICEWITHLETTERS.CalcValue = MyParentReport.HEADER.TOTALPRICE1.CalcValue;
                    PAYMENTTYPE.CalcValue = (dataset_CashOfficeReceiptDocumentReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeReceiptDocumentReportQuery.PaymentType) : "");
                    PAYMENTTYPE.PostFieldValueCalculation();
                    ACCOUNTOFFICENAMEFOOTER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RECEIPTREPORTACCOUNTOFFICENAME", "");
                    return new TTReportObject[] { TOTALPRICE,TELEPHONE,CASHIER,DUZENLEYEN,ACCOUNTANTTITLE,TOTALPRICE1,REPORTDATE,PRICEWITHLETTERSANDTYPE,PRICEWITHLETTERS,PAYMENTTYPE,ACCOUNTOFFICENAMEFOOTER};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    this.PRICEWITHLETTERSANDTYPE.CalcValue = this.PRICEWITHLETTERS.FormattedValue + " - " + this.PAYMENTTYPE.CalcValue;
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public CashOfficeReceiptDocumentReport MyParentReport
            {
                get { return (CashOfficeReceiptDocumentReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public CashOfficeReceiptDocumentReport MyParentReport
                {
                    get { return (CashOfficeReceiptDocumentReport)ParentReport; }
                }
                
                public TTReportField DESCRIPTION;
                public TTReportField PRICE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 0, 183, 5, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Name = "Arial Narrow";
                    DESCRIPTION.TextFont.Bold = true;
                    DESCRIPTION.TextFont.CharSet = 0;
                    DESCRIPTION.Value = @"{#HEADER.MONEYRECEIVEDTYPENAME#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 0, 205, 5, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.TextFont.Name = "Arial Narrow";
                    PRICE.TextFont.Bold = true;
                    PRICE.TextFont.CharSet = 0;
                    PRICE.Value = @"{#HEADER.TOTALPRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MainCashOfficeOperation.CashOfficeReceiptDocumentReportQuery_Class dataset_CashOfficeReceiptDocumentReportQuery = MyParentReport.HEADER.rsGroup.GetCurrentRecord<MainCashOfficeOperation.CashOfficeReceiptDocumentReportQuery_Class>(0);
                    DESCRIPTION.CalcValue = (dataset_CashOfficeReceiptDocumentReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeReceiptDocumentReportQuery.Moneyreceivedtypename) : "");
                    PRICE.CalcValue = (dataset_CashOfficeReceiptDocumentReportQuery != null ? Globals.ToStringCore(dataset_CashOfficeReceiptDocumentReportQuery.TotalPrice) : "");
                    return new TTReportObject[] { DESCRIPTION,PRICE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public CashOfficeReceiptDocumentReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action guid", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "CASHOFFICERECEIPTDOCUMENTREPORT";
            Caption = "Vezne Alındısı";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 1;
            p_PageWidth = 216;
            p_PageHeight = 279;
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