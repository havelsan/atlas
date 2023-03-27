
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
    /// Menkul Kıymetler Alındısı
    /// </summary>
    public partial class ChattelReceiptReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public ChattelReceiptReport MyParentReport
            {
                get { return (ChattelReceiptReport)ParentReport; }
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
            public TTReportField TESLIMETTIRENDAIRE { get {return Header().TESLIMETTIRENDAIRE;} }
            public TTReportField PAYEENAME { get {return Header().PAYEENAME;} }
            public TTReportField DOSES { get {return Header().DOSES;} }
            public TTReportField TOTALPRICE { get {return Footer().TOTALPRICE;} }
            public TTReportField RECEIPTDATE { get {return Footer().RECEIPTDATE;} }
            public TTReportField CASHIER { get {return Footer().CASHIER;} }
            public TTReportField ACCOUNTANT { get {return Footer().ACCOUNTANT;} }
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
                list[0] = new TTReportNqlData<MainCashOfficeOperation.ChattelReceiptReportQuery_Class>("ChattelReceiptReportQuery", MainCashOfficeOperation.ChattelReceiptReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public ChattelReceiptReport MyParentReport
                {
                    get { return (ChattelReceiptReport)ParentReport; }
                }
                
                public TTReportField SPECIALNO;
                public TTReportField DESCRIPTION;
                public TTReportField TESLIMETTIRENDAIRE;
                public TTReportField PAYEENAME;
                public TTReportField DOSES; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 61;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    SPECIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 33, 179, 38, false);
                    SPECIALNO.Name = "SPECIALNO";
                    SPECIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SPECIALNO.TextFont.Name = "Courier New";
                    SPECIALNO.Value = @"{#SPECIALNO#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 49, 157, 54, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.TextFont.Name = "Courier New";
                    DESCRIPTION.Value = @"{#HEADER.DESCRIPTION#}";

                    TESLIMETTIRENDAIRE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 55, 157, 60, false);
                    TESLIMETTIRENDAIRE.Name = "TESLIMETTIRENDAIRE";
                    TESLIMETTIRENDAIRE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESLIMETTIRENDAIRE.TextFont.Name = "Courier New";
                    TESLIMETTIRENDAIRE.Value = @"";

                    PAYEENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 43, 157, 48, false);
                    PAYEENAME.Name = "PAYEENAME";
                    PAYEENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYEENAME.TextFont.Name = "Courier New";
                    PAYEENAME.Value = @"{#PAYEENAME#}";

                    DOSES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 18, 32, 23, false);
                    DOSES.Name = "DOSES";
                    DOSES.TextFont.Name = "Courier New";
                    DOSES.Value = @"DOSES";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MainCashOfficeOperation.ChattelReceiptReportQuery_Class dataset_ChattelReceiptReportQuery = ParentGroup.rsGroup.GetCurrentRecord<MainCashOfficeOperation.ChattelReceiptReportQuery_Class>(0);
                    SPECIALNO.CalcValue = (dataset_ChattelReceiptReportQuery != null ? Globals.ToStringCore(dataset_ChattelReceiptReportQuery.SpecialNo) : "");
                    DESCRIPTION.CalcValue = (dataset_ChattelReceiptReportQuery != null ? Globals.ToStringCore(dataset_ChattelReceiptReportQuery.Description) : "");
                    TESLIMETTIRENDAIRE.CalcValue = @"";
                    PAYEENAME.CalcValue = (dataset_ChattelReceiptReportQuery != null ? Globals.ToStringCore(dataset_ChattelReceiptReportQuery.PayeeName) : "");
                    DOSES.CalcValue = DOSES.Value;
                    return new TTReportObject[] { SPECIALNO,DESCRIPTION,TESLIMETTIRENDAIRE,PAYEENAME,DOSES};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public ChattelReceiptReport MyParentReport
                {
                    get { return (ChattelReceiptReport)ParentReport; }
                }
                
                public TTReportField TOTALPRICE;
                public TTReportField RECEIPTDATE;
                public TTReportField CASHIER;
                public TTReportField ACCOUNTANT; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 38;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 2, 180, 7, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPRICE.TextFont.Name = "Courier New";
                    TOTALPRICE.Value = @"{#TOTALPRICE#}";

                    RECEIPTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 13, 147, 18, false);
                    RECEIPTDATE.Name = "RECEIPTDATE";
                    RECEIPTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIPTDATE.TextFormat = @"Short Date";
                    RECEIPTDATE.TextFont.Name = "Courier New";
                    RECEIPTDATE.Value = @"{#DOCUMENTDATE#}";

                    CASHIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 24, 176, 35, false);
                    CASHIER.Name = "CASHIER";
                    CASHIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIER.MultiLine = EvetHayirEnum.ehEvet;
                    CASHIER.NoClip = EvetHayirEnum.ehEvet;
                    CASHIER.WordBreak = EvetHayirEnum.ehEvet;
                    CASHIER.ExpandTabs = EvetHayirEnum.ehEvet;
                    CASHIER.TextFont.Name = "Courier New";
                    CASHIER.Value = @"{#CASHIERNAME#}";

                    ACCOUNTANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 24, 76, 35, false);
                    ACCOUNTANT.Name = "ACCOUNTANT";
                    ACCOUNTANT.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTANT.TextFont.Name = "Courier New";
                    ACCOUNTANT.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""ACCOUNTANT"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MainCashOfficeOperation.ChattelReceiptReportQuery_Class dataset_ChattelReceiptReportQuery = ParentGroup.rsGroup.GetCurrentRecord<MainCashOfficeOperation.ChattelReceiptReportQuery_Class>(0);
                    TOTALPRICE.CalcValue = (dataset_ChattelReceiptReportQuery != null ? Globals.ToStringCore(dataset_ChattelReceiptReportQuery.TotalPrice) : "");
                    RECEIPTDATE.CalcValue = (dataset_ChattelReceiptReportQuery != null ? Globals.ToStringCore(dataset_ChattelReceiptReportQuery.DocumentDate) : "");
                    CASHIER.CalcValue = (dataset_ChattelReceiptReportQuery != null ? Globals.ToStringCore(dataset_ChattelReceiptReportQuery.Cashiername) : "");
                    ACCOUNTANT.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTANT", "");
                    return new TTReportObject[] { TOTALPRICE,RECEIPTDATE,CASHIER,ACCOUNTANT};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public ChattelReceiptReport MyParentReport
            {
                get { return (ChattelReceiptReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MONEYRECEIVEDTYPENAME { get {return Body().MONEYRECEIVEDTYPENAME;} }
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
                public ChattelReceiptReport MyParentReport
                {
                    get { return (ChattelReceiptReport)ParentReport; }
                }
                
                public TTReportField MONEYRECEIVEDTYPENAME;
                public TTReportField PRICE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 23;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    MONEYRECEIVEDTYPENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 8, 141, 13, false);
                    MONEYRECEIVEDTYPENAME.Name = "MONEYRECEIVEDTYPENAME";
                    MONEYRECEIVEDTYPENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONEYRECEIVEDTYPENAME.MultiLine = EvetHayirEnum.ehEvet;
                    MONEYRECEIVEDTYPENAME.NoClip = EvetHayirEnum.ehEvet;
                    MONEYRECEIVEDTYPENAME.WordBreak = EvetHayirEnum.ehEvet;
                    MONEYRECEIVEDTYPENAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    MONEYRECEIVEDTYPENAME.TextFont.Name = "Courier New";
                    MONEYRECEIVEDTYPENAME.Value = @"{#HEADER.MONEYRECEIVEDTYPENAME#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 8, 180, 13, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.TextFont.Name = "Courier New";
                    PRICE.Value = @"{#HEADER.TOTALPRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MainCashOfficeOperation.ChattelReceiptReportQuery_Class dataset_ChattelReceiptReportQuery = MyParentReport.HEADER.rsGroup.GetCurrentRecord<MainCashOfficeOperation.ChattelReceiptReportQuery_Class>(0);
                    MONEYRECEIVEDTYPENAME.CalcValue = (dataset_ChattelReceiptReportQuery != null ? Globals.ToStringCore(dataset_ChattelReceiptReportQuery.Moneyreceivedtypename) : "");
                    PRICE.CalcValue = (dataset_ChattelReceiptReportQuery != null ? Globals.ToStringCore(dataset_ChattelReceiptReportQuery.TotalPrice) : "");
                    return new TTReportObject[] { MONEYRECEIVEDTYPENAME,PRICE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ChattelReceiptReport()
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
            Name = "CHATTELRECEIPTREPORT";
            Caption = "Menkul Kıymetler Alındısı";
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