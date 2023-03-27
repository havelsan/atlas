
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
    /// Makbuz Raporu
    /// </summary>
    public partial class DebPaymentReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public double? CALCULATEDPRICE = (double?)TTObjectDefManager.Instance.DataTypes["Double23.8"].ConvertValue("0");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public DebPaymentReport MyParentReport
            {
                get { return (DebPaymentReport)ParentReport; }
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
            public TTReportField CASHOFFICENAME { get {return Header().CASHOFFICENAME;} }
            public TTReportField PAYEENAME { get {return Header().PAYEENAME;} }
            public TTReportField DOCUMENTNO { get {return Header().DOCUMENTNO;} }
            public TTReportField ACCOUNTOFFICENAME { get {return Header().ACCOUNTOFFICENAME;} }
            public TTReportField DEBENTUREPAYMENTDOCOBJID { get {return Header().DEBENTUREPAYMENTDOCOBJID;} }
            public TTReportField TOTALPRICE { get {return Footer().TOTALPRICE;} }
            public TTReportField PRICEWITHLETTERS { get {return Footer().PRICEWITHLETTERS;} }
            public TTReportField DESC { get {return Footer().DESC;} }
            public TTReportField RECEIPTDATE { get {return Footer().RECEIPTDATE;} }
            public TTReportField CASHIERNAME { get {return Footer().CASHIERNAME;} }
            public TTReportField ACCOUNTANTTITLE11 { get {return Footer().ACCOUNTANTTITLE11;} }
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
                list[0] = new TTReportNqlData<DebenturePayment.DebPaymentReportQuery_Class>("DebPaymentReportQuery", DebenturePayment.DebPaymentReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public DebPaymentReport MyParentReport
                {
                    get { return (DebPaymentReport)ParentReport; }
                }
                
                public TTReportField RECEIPTSPECIALNO;
                public TTReportField CASHOFFICENAME;
                public TTReportField PAYEENAME;
                public TTReportField DOCUMENTNO;
                public TTReportField ACCOUNTOFFICENAME;
                public TTReportField DEBENTUREPAYMENTDOCOBJID; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 55;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    RECEIPTSPECIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 20, 186, 25, false);
                    RECEIPTSPECIALNO.Name = "RECEIPTSPECIALNO";
                    RECEIPTSPECIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIPTSPECIALNO.Value = @"{#SPECIALNO#}";

                    CASHOFFICENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 28, 164, 33, false);
                    CASHOFFICENAME.Name = "CASHOFFICENAME";
                    CASHOFFICENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICENAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CASHOFFICENAME.Value = @"{#CASHOFFICENAME#}";

                    PAYEENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 33, 164, 38, false);
                    PAYEENAME.Name = "PAYEENAME";
                    PAYEENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYEENAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYEENAME.Value = @"{#PAYEENAME#}";

                    DOCUMENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 19, 256, 24, false);
                    DOCUMENTNO.Name = "DOCUMENTNO";
                    DOCUMENTNO.Visible = EvetHayirEnum.ehHayir;
                    DOCUMENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNO.Value = @"{#DOCUMENTNO#}";

                    ACCOUNTOFFICENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 11, 86, 16, false);
                    ACCOUNTOFFICENAME.Name = "ACCOUNTOFFICENAME";
                    ACCOUNTOFFICENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTOFFICENAME.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTOFFICENAME.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTOFFICENAME.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTOFFICENAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACCOUNTOFFICENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RECEIPTREPORTACCOUNTOFFICENAME"", """")
";

                    DEBENTUREPAYMENTDOCOBJID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 48, 249, 53, false);
                    DEBENTUREPAYMENTDOCOBJID.Name = "DEBENTUREPAYMENTDOCOBJID";
                    DEBENTUREPAYMENTDOCOBJID.Visible = EvetHayirEnum.ehHayir;
                    DEBENTUREPAYMENTDOCOBJID.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEBENTUREPAYMENTDOCOBJID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DebenturePayment.DebPaymentReportQuery_Class dataset_DebPaymentReportQuery = ParentGroup.rsGroup.GetCurrentRecord<DebenturePayment.DebPaymentReportQuery_Class>(0);
                    RECEIPTSPECIALNO.CalcValue = (dataset_DebPaymentReportQuery != null ? Globals.ToStringCore(dataset_DebPaymentReportQuery.SpecialNo) : "");
                    CASHOFFICENAME.CalcValue = (dataset_DebPaymentReportQuery != null ? Globals.ToStringCore(dataset_DebPaymentReportQuery.CashOfficeName) : "");
                    PAYEENAME.CalcValue = (dataset_DebPaymentReportQuery != null ? Globals.ToStringCore(dataset_DebPaymentReportQuery.PayeeName) : "");
                    DOCUMENTNO.CalcValue = (dataset_DebPaymentReportQuery != null ? Globals.ToStringCore(dataset_DebPaymentReportQuery.DocumentNo) : "");
                    DEBENTUREPAYMENTDOCOBJID.CalcValue = (dataset_DebPaymentReportQuery != null ? Globals.ToStringCore(dataset_DebPaymentReportQuery.ObjectID) : "");
                    ACCOUNTOFFICENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RECEIPTREPORTACCOUNTOFFICENAME", "")
;
                    return new TTReportObject[] { RECEIPTSPECIALNO,CASHOFFICENAME,PAYEENAME,DOCUMENTNO,DEBENTUREPAYMENTDOCOBJID,ACCOUNTOFFICENAME};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            
            string sObjectID = this.DEBENTUREPAYMENTDOCOBJID.CalcValue.ToString();
            AccountDocument accDoc = (AccountDocument)context.GetObject(new Guid(sObjectID),"AccountDocument");
            
            ((DebPaymentReport)ParentReport).RuntimeParameters.CALCULATEDPRICE = accDoc.GetCalculatedCashPayment(Convert.ToDateTime(accDoc.DocumentDate));
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public DebPaymentReport MyParentReport
                {
                    get { return (DebPaymentReport)ParentReport; }
                }
                
                public TTReportField TOTALPRICE;
                public TTReportField PRICEWITHLETTERS;
                public TTReportField DESC;
                public TTReportField RECEIPTDATE;
                public TTReportField CASHIERNAME;
                public TTReportField ACCOUNTANTTITLE11; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 46;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 10, 176, 15, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"Currency";
                    TOTALPRICE.Value = @"";

                    PRICEWITHLETTERS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 18, 177, 23, false);
                    PRICEWITHLETTERS.Name = "PRICEWITHLETTERS";
                    PRICEWITHLETTERS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICEWITHLETTERS.TextFormat = @"NUMBERTEXT( TL , KR)";
                    PRICEWITHLETTERS.Value = @"";

                    DESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 18, 74, 23, false);
                    DESC.Name = "DESC";
                    DESC.FieldType = ReportFieldTypeEnum.ftExpression;
                    DESC.MultiLine = EvetHayirEnum.ehEvet;
                    DESC.NoClip = EvetHayirEnum.ehEvet;
                    DESC.WordBreak = EvetHayirEnum.ehEvet;
                    DESC.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESC.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RECEIPTREPORTACCOUNTOFFICENAME"", """")";

                    RECEIPTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 27, 89, 32, false);
                    RECEIPTDATE.Name = "RECEIPTDATE";
                    RECEIPTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIPTDATE.TextFormat = @"Short Date";
                    RECEIPTDATE.Value = @"{#DOCUMENTDATE#}";

                    CASHIERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 32, 188, 37, false);
                    CASHIERNAME.Name = "CASHIERNAME";
                    CASHIERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERNAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CASHIERNAME.MultiLine = EvetHayirEnum.ehEvet;
                    CASHIERNAME.NoClip = EvetHayirEnum.ehEvet;
                    CASHIERNAME.WordBreak = EvetHayirEnum.ehEvet;
                    CASHIERNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    CASHIERNAME.Value = @"{#CASHIERNAME#}";

                    ACCOUNTANTTITLE11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 37, 188, 41, false);
                    ACCOUNTANTTITLE11.Name = "ACCOUNTANTTITLE11";
                    ACCOUNTANTTITLE11.Value = @"Dön. Ser. Muh. Yet. Mut.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DebenturePayment.DebPaymentReportQuery_Class dataset_DebPaymentReportQuery = ParentGroup.rsGroup.GetCurrentRecord<DebenturePayment.DebPaymentReportQuery_Class>(0);
                    TOTALPRICE.CalcValue = @"";
                    PRICEWITHLETTERS.CalcValue = @"";
                    RECEIPTDATE.CalcValue = (dataset_DebPaymentReportQuery != null ? Globals.ToStringCore(dataset_DebPaymentReportQuery.DocumentDate) : "");
                    CASHIERNAME.CalcValue = (dataset_DebPaymentReportQuery != null ? Globals.ToStringCore(dataset_DebPaymentReportQuery.Cashiername) : "");
                    ACCOUNTANTTITLE11.CalcValue = ACCOUNTANTTITLE11.Value;
                    DESC.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RECEIPTREPORTACCOUNTOFFICENAME", "");
                    return new TTReportObject[] { TOTALPRICE,PRICEWITHLETTERS,RECEIPTDATE,CASHIERNAME,ACCOUNTANTTITLE11,DESC};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    this.TOTALPRICE.CalcValue = (((DebPaymentReport)ParentReport).RuntimeParameters.CALCULATEDPRICE).ToString();
            this.PRICEWITHLETTERS.CalcValue = (((DebPaymentReport)ParentReport).RuntimeParameters.CALCULATEDPRICE).ToString();
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public DebPaymentReport MyParentReport
            {
                get { return (DebPaymentReport)ParentReport; }
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
                public DebPaymentReport MyParentReport
                {
                    get { return (DebPaymentReport)ParentReport; }
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

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 0, 176, 5, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"Currency";
                    PRICE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DESCRIPTION.CalcValue = DESCRIPTION.Value;
                    PRICE.CalcValue = @"";
                    return new TTReportObject[] { DESCRIPTION,PRICE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    this.PRICE.CalcValue = (((DebPaymentReport)ParentReport).RuntimeParameters.CALCULATEDPRICE).ToString();
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

        public DebPaymentReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action ObjectID", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("CALCULATEDPRICE", "0", "Hesaplanan Tutar", @"", false, false, false, new Guid("53710a7d-9fdd-4078-a98e-228d2cc89909"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("CALCULATEDPRICE"))
                _runtimeParameters.CALCULATEDPRICE = (double?)TTObjectDefManager.Instance.DataTypes["Double23.8"].ConvertValue(parameters["CALCULATEDPRICE"]);
            Name = "DEBPAYMENTREPORT";
            Caption = "Muhasebe Yetkilisi Mutemedi Alındısı";
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