
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
    /// Teslimat Müzekkeresi
    /// </summary>
    public partial class BankDeliveryReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public BankDeliveryReport MyParentReport
            {
                get { return (BankDeliveryReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PRICE { get {return Body().PRICE;} }
            public TTReportField BANK { get {return Body().BANK;} }
            public TTReportField CASHIER { get {return Body().CASHIER;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField PRICEWITHLETTERS { get {return Body().PRICEWITHLETTERS;} }
            public TTReportField BANKACCOUNT { get {return Body().BANKACCOUNT;} }
            public TTReportField SPECIALNO { get {return Body().SPECIALNO;} }
            public TTReportField DSNAME { get {return Body().DSNAME;} }
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
                list[0] = new TTReportNqlData<MainCashOfficeBackOperation.BankDeliveryReportQuery_Class>("BankDeliveryReportQuery", MainCashOfficeBackOperation.BankDeliveryReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public BankDeliveryReport MyParentReport
                {
                    get { return (BankDeliveryReport)ParentReport; }
                }
                
                public TTReportField PRICE;
                public TTReportField BANK;
                public TTReportField CASHIER;
                public TTReportField DESCRIPTION;
                public TTReportField PRICEWITHLETTERS;
                public TTReportField BANKACCOUNT;
                public TTReportField SPECIALNO;
                public TTReportField DSNAME; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 111;
                    RepeatCount = 0;
                    
                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 32, 190, 37, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.TextFont.Name = "Courier New";
                    PRICE.Value = @"{#TOTALPRICE#}";

                    BANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 38, 190, 43, false);
                    BANK.Name = "BANK";
                    BANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BANK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BANK.TextFont.Name = "Courier New";
                    BANK.Value = @"{#BANKNAME#} {#BANKBRANCHNAME#}";

                    CASHIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 44, 190, 49, false);
                    CASHIER.Name = "CASHIER";
                    CASHIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CASHIER.TextFont.Name = "Courier New";
                    CASHIER.Value = @"DÖNER SERMAYE SAYMANLIĞI ({#CASHIERNAME#})";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 50, 190, 55, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.CaseFormat = CaseFormatEnum.fcUpperCase;
                    DESCRIPTION.TextFont.Name = "Courier New";
                    DESCRIPTION.Value = @"BANKAYA YATIRILAN TESLİMAT";

                    PRICEWITHLETTERS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 64, 145, 69, false);
                    PRICEWITHLETTERS.Name = "PRICEWITHLETTERS";
                    PRICEWITHLETTERS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICEWITHLETTERS.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PRICEWITHLETTERS.TextFormat = @"NUMBERTEXT( TL , KR)";
                    PRICEWITHLETTERS.TextFont.Name = "Courier New";
                    PRICEWITHLETTERS.Value = @"{%PRICE%}";

                    BANKACCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 71, 108, 76, false);
                    BANKACCOUNT.Name = "BANKACCOUNT";
                    BANKACCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    BANKACCOUNT.TextFont.Name = "Courier New";
                    BANKACCOUNT.Value = @"{#ACCOUNTNO#}";

                    SPECIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 22, 190, 27, false);
                    SPECIALNO.Name = "SPECIALNO";
                    SPECIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SPECIALNO.TextFont.Name = "Courier New";
                    SPECIALNO.Value = @"{#SPECIALNO#}";

                    DSNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 14, 143, 19, false);
                    DSNAME.Name = "DSNAME";
                    DSNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    DSNAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    DSNAME.TextFont.Name = "Courier New";
                    DSNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALDSNAME"", """")
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MainCashOfficeBackOperation.BankDeliveryReportQuery_Class dataset_BankDeliveryReportQuery = ParentGroup.rsGroup.GetCurrentRecord<MainCashOfficeBackOperation.BankDeliveryReportQuery_Class>(0);
                    PRICE.CalcValue = (dataset_BankDeliveryReportQuery != null ? Globals.ToStringCore(dataset_BankDeliveryReportQuery.TotalPrice) : "");
                    BANK.CalcValue = (dataset_BankDeliveryReportQuery != null ? Globals.ToStringCore(dataset_BankDeliveryReportQuery.Bankname) : "") + @" " + (dataset_BankDeliveryReportQuery != null ? Globals.ToStringCore(dataset_BankDeliveryReportQuery.Bankbranchname) : "");
                    CASHIER.CalcValue = @"DÖNER SERMAYE SAYMANLIĞI (" + (dataset_BankDeliveryReportQuery != null ? Globals.ToStringCore(dataset_BankDeliveryReportQuery.Cashiername) : "") + @")";
                    DESCRIPTION.CalcValue = @"BANKAYA YATIRILAN TESLİMAT";
                    PRICEWITHLETTERS.CalcValue = MyParentReport.MAIN.PRICE.FormattedValue;
                    BANKACCOUNT.CalcValue = (dataset_BankDeliveryReportQuery != null ? Globals.ToStringCore(dataset_BankDeliveryReportQuery.AccountNo) : "");
                    SPECIALNO.CalcValue = (dataset_BankDeliveryReportQuery != null ? Globals.ToStringCore(dataset_BankDeliveryReportQuery.SpecialNo) : "");
                    DSNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALDSNAME", "")
;
                    return new TTReportObject[] { PRICE,BANK,CASHIER,DESCRIPTION,PRICEWITHLETTERS,BANKACCOUNT,SPECIALNO,DSNAME};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public BankDeliveryReport()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action Guid", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "BANKDELIVERYREPORT";
            Caption = "Teslimat Müzekkeresi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
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