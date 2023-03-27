
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
    /// Makbuz KK Raporu
    /// </summary>
    public partial class DebPaymentCrCardReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public DebPaymentCrCardReport MyParentReport
            {
                get { return (DebPaymentCrCardReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField RECEIPTSPECIALNO { get {return Header().RECEIPTSPECIALNO;} }
            public TTReportField CARDOWNER { get {return Header().CARDOWNER;} }
            public TTReportField PAYEENAME { get {return Header().PAYEENAME;} }
            public TTReportField DOCUMENTNO { get {return Header().DOCUMENTNO;} }
            public TTReportField ACCOUNTOFFICENAME { get {return Header().ACCOUNTOFFICENAME;} }
            public TTReportField KK1 { get {return Header().KK1;} }
            public TTReportField TOTALPRICE { get {return Footer().TOTALPRICE;} }
            public TTReportField PRICEWITHLETTERS { get {return Footer().PRICEWITHLETTERS;} }
            public TTReportField DESC { get {return Footer().DESC;} }
            public TTReportField RECEIPTDATE { get {return Footer().RECEIPTDATE;} }
            public TTReportField CASHIERNAME { get {return Footer().CASHIERNAME;} }
            public TTReportField ACCOUNTANT { get {return Footer().ACCOUNTANT;} }
            public TTReportField ACCOUNTANTTITLE111 { get {return Footer().ACCOUNTANTTITLE111;} }
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
                list[0] = new TTReportNqlData<DebenturePayment.DebPaymentCrCardReportQuery_Class>("DebPaymentCrCardReportQuery", DebenturePayment.DebPaymentCrCardReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public DebPaymentCrCardReport MyParentReport
                {
                    get { return (DebPaymentCrCardReport)ParentReport; }
                }
                
                public TTReportField RECEIPTSPECIALNO;
                public TTReportField CARDOWNER;
                public TTReportField PAYEENAME;
                public TTReportField DOCUMENTNO;
                public TTReportField ACCOUNTOFFICENAME;
                public TTReportField KK1; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 57;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    RECEIPTSPECIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 50, 194, 55, false);
                    RECEIPTSPECIALNO.Name = "RECEIPTSPECIALNO";
                    RECEIPTSPECIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIPTSPECIALNO.Value = @"{#CREDITCARDSPECIALNO#}";

                    CARDOWNER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 32, 164, 37, false);
                    CARDOWNER.Name = "CARDOWNER";
                    CARDOWNER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CARDOWNER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CARDOWNER.Value = @"{#CARDOWNER#}";

                    PAYEENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 38, 164, 43, false);
                    PAYEENAME.Name = "PAYEENAME";
                    PAYEENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYEENAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYEENAME.MultiLine = EvetHayirEnum.ehEvet;
                    PAYEENAME.NoClip = EvetHayirEnum.ehEvet;
                    PAYEENAME.WordBreak = EvetHayirEnum.ehEvet;
                    PAYEENAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYEENAME.Value = @"{#PAYEENAME#}";

                    DOCUMENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 18, 256, 23, false);
                    DOCUMENTNO.Name = "DOCUMENTNO";
                    DOCUMENTNO.Visible = EvetHayirEnum.ehHayir;
                    DOCUMENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNO.Value = @"{#CREDITCARDDOCUMENTNO#}";

                    ACCOUNTOFFICENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 11, 101, 16, false);
                    ACCOUNTOFFICENAME.Name = "ACCOUNTOFFICENAME";
                    ACCOUNTOFFICENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTOFFICENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RECEIPTREPORTACCOUNTOFFICENAME"", """")
";

                    KK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 22, 113, 27, false);
                    KK1.Name = "KK1";
                    KK1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    KK1.Value = @"KREDİ KARTI TAHSİLATI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DebenturePayment.DebPaymentCrCardReportQuery_Class dataset_DebPaymentCrCardReportQuery = ParentGroup.rsGroup.GetCurrentRecord<DebenturePayment.DebPaymentCrCardReportQuery_Class>(0);
                    RECEIPTSPECIALNO.CalcValue = (dataset_DebPaymentCrCardReportQuery != null ? Globals.ToStringCore(dataset_DebPaymentCrCardReportQuery.CreditCardSpecialNo) : "");
                    CARDOWNER.CalcValue = (dataset_DebPaymentCrCardReportQuery != null ? Globals.ToStringCore(dataset_DebPaymentCrCardReportQuery.Cardowner) : "");
                    PAYEENAME.CalcValue = (dataset_DebPaymentCrCardReportQuery != null ? Globals.ToStringCore(dataset_DebPaymentCrCardReportQuery.PayeeName) : "");
                    DOCUMENTNO.CalcValue = (dataset_DebPaymentCrCardReportQuery != null ? Globals.ToStringCore(dataset_DebPaymentCrCardReportQuery.CreditCardDocumentNo) : "");
                    KK1.CalcValue = KK1.Value;
                    ACCOUNTOFFICENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RECEIPTREPORTACCOUNTOFFICENAME", "")
;
                    return new TTReportObject[] { RECEIPTSPECIALNO,CARDOWNER,PAYEENAME,DOCUMENTNO,KK1,ACCOUNTOFFICENAME};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public DebPaymentCrCardReport MyParentReport
                {
                    get { return (DebPaymentCrCardReport)ParentReport; }
                }
                
                public TTReportField TOTALPRICE;
                public TTReportField PRICEWITHLETTERS;
                public TTReportField DESC;
                public TTReportField RECEIPTDATE;
                public TTReportField CASHIERNAME;
                public TTReportField ACCOUNTANT;
                public TTReportField ACCOUNTANTTITLE111; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 52;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 21, 173, 26, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"Currency";
                    TOTALPRICE.Value = @"{#CREDITCARDPAYMENT#}";

                    PRICEWITHLETTERS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 29, 154, 34, false);
                    PRICEWITHLETTERS.Name = "PRICEWITHLETTERS";
                    PRICEWITHLETTERS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICEWITHLETTERS.TextFormat = @"NUMBERTEXT( TL , KR)";
                    PRICEWITHLETTERS.Value = @"{%TOTALPRICE%}";

                    DESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 4, 51, 9, false);
                    DESC.Name = "DESC";
                    DESC.Visible = EvetHayirEnum.ehHayir;
                    DESC.FieldType = ReportFieldTypeEnum.ftExpression;
                    DESC.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RECEIPTREPORTACCOUNTOFFICENAME"", """")";

                    RECEIPTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 36, 95, 41, false);
                    RECEIPTDATE.Name = "RECEIPTDATE";
                    RECEIPTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIPTDATE.TextFormat = @"Short Date";
                    RECEIPTDATE.Value = @"{#DOCUMENTDATE#}";

                    CASHIERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 41, 188, 46, false);
                    CASHIERNAME.Name = "CASHIERNAME";
                    CASHIERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERNAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CASHIERNAME.MultiLine = EvetHayirEnum.ehEvet;
                    CASHIERNAME.NoClip = EvetHayirEnum.ehEvet;
                    CASHIERNAME.WordBreak = EvetHayirEnum.ehEvet;
                    CASHIERNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    CASHIERNAME.Value = @"{#CASHIERNAME#}";

                    ACCOUNTANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 36, 55, 41, false);
                    ACCOUNTANT.Name = "ACCOUNTANT";
                    ACCOUNTANT.Visible = EvetHayirEnum.ehHayir;
                    ACCOUNTANT.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANT.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ACCOUNTANT.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTANT.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""ACCOUNTANT"", """")
";

                    ACCOUNTANTTITLE111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 46, 188, 50, false);
                    ACCOUNTANTTITLE111.Name = "ACCOUNTANTTITLE111";
                    ACCOUNTANTTITLE111.Value = @"Dön. Ser. Muh. Yet. Mut.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DebenturePayment.DebPaymentCrCardReportQuery_Class dataset_DebPaymentCrCardReportQuery = ParentGroup.rsGroup.GetCurrentRecord<DebenturePayment.DebPaymentCrCardReportQuery_Class>(0);
                    TOTALPRICE.CalcValue = (dataset_DebPaymentCrCardReportQuery != null ? Globals.ToStringCore(dataset_DebPaymentCrCardReportQuery.Creditcardpayment) : "");
                    PRICEWITHLETTERS.CalcValue = MyParentReport.HEADER.TOTALPRICE.FormattedValue;
                    RECEIPTDATE.CalcValue = (dataset_DebPaymentCrCardReportQuery != null ? Globals.ToStringCore(dataset_DebPaymentCrCardReportQuery.DocumentDate) : "");
                    CASHIERNAME.CalcValue = (dataset_DebPaymentCrCardReportQuery != null ? Globals.ToStringCore(dataset_DebPaymentCrCardReportQuery.Cashiername) : "");
                    ACCOUNTANTTITLE111.CalcValue = ACCOUNTANTTITLE111.Value;
                    DESC.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RECEIPTREPORTACCOUNTOFFICENAME", "");
                    ACCOUNTANT.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTANT", "")
;
                    return new TTReportObject[] { TOTALPRICE,PRICEWITHLETTERS,RECEIPTDATE,CASHIERNAME,ACCOUNTANTTITLE111,DESC,ACCOUNTANT};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public DebPaymentCrCardReport MyParentReport
            {
                get { return (DebPaymentCrCardReport)ParentReport; }
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
                public DebPaymentCrCardReport MyParentReport
                {
                    get { return (DebPaymentCrCardReport)ParentReport; }
                }
                
                public TTReportField DESCRIPTION;
                public TTReportField PRICE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 0, 134, 5, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.Value = @"Hasta Muayene/Tedavi Bedeli";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 0, 173, 5, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"Currency";
                    PRICE.Value = @"{#HEADER.CREDITCARDPAYMENT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DebenturePayment.DebPaymentCrCardReportQuery_Class dataset_DebPaymentCrCardReportQuery = MyParentReport.HEADER.rsGroup.GetCurrentRecord<DebenturePayment.DebPaymentCrCardReportQuery_Class>(0);
                    DESCRIPTION.CalcValue = DESCRIPTION.Value;
                    PRICE.CalcValue = (dataset_DebPaymentCrCardReportQuery != null ? Globals.ToStringCore(dataset_DebPaymentCrCardReportQuery.Creditcardpayment) : "");
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

        public DebPaymentCrCardReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action ObjectID", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "DEBPAYMENTCRCARDREPORT";
            Caption = "Kredi Kartı Alındısı";
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