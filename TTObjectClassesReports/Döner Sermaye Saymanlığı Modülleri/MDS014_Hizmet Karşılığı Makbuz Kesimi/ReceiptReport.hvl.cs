
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
    public partial class ReceiptReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public ReceiptReport MyParentReport
            {
                get { return (ReceiptReport)ParentReport; }
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
            public TTReportField TCKIMLIKNO { get {return Header().TCKIMLIKNO;} }
            public TTReportField PAYEEADDRESS { get {return Header().PAYEEADDRESS;} }
            public TTReportField DESCRIPTION { get {return Header().DESCRIPTION;} }
            public TTReportField TOTALPRICE { get {return Footer().TOTALPRICE;} }
            public TTReportField PRICEWITHLETTERS { get {return Footer().PRICEWITHLETTERS;} }
            public TTReportField DESC { get {return Footer().DESC;} }
            public TTReportField RECEIPTDATE { get {return Footer().RECEIPTDATE;} }
            public TTReportField CASHIERNAME { get {return Footer().CASHIERNAME;} }
            public TTReportField TOTALPRICE1 { get {return Footer().TOTALPRICE1;} }
            public TTReportField ACCOUNTANTTITLE1 { get {return Footer().ACCOUNTANTTITLE1;} }
            public TTReportField ADVANCES { get {return Footer().ADVANCES;} }
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
                list[0] = new TTReportNqlData<Receipt.ReceiptReportQuery_Class>("ReceiptReportQuery", Receipt.ReceiptReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public ReceiptReport MyParentReport
                {
                    get { return (ReceiptReport)ParentReport; }
                }
                
                public TTReportField RECEIPTSPECIALNO;
                public TTReportField CASHOFFICENAME;
                public TTReportField PAYEENAME;
                public TTReportField DOCUMENTNO;
                public TTReportField ACCOUNTOFFICENAME;
                public TTReportField TCKIMLIKNO;
                public TTReportField PAYEEADDRESS;
                public TTReportField DESCRIPTION; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 71;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    RECEIPTSPECIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 35, 186, 40, false);
                    RECEIPTSPECIALNO.Name = "RECEIPTSPECIALNO";
                    RECEIPTSPECIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIPTSPECIALNO.Value = @"{#SPECIALNO#}";

                    CASHOFFICENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 45, 164, 49, false);
                    CASHOFFICENAME.Name = "CASHOFFICENAME";
                    CASHOFFICENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICENAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CASHOFFICENAME.Value = @"{#CASHOFFICENAME#}";

                    PAYEENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 49, 164, 53, false);
                    PAYEENAME.Name = "PAYEENAME";
                    PAYEENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYEENAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYEENAME.Value = @"{#PAYEENAME#}";

                    DOCUMENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 69, 257, 74, false);
                    DOCUMENTNO.Name = "DOCUMENTNO";
                    DOCUMENTNO.Visible = EvetHayirEnum.ehHayir;
                    DOCUMENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNO.Value = @"{#DOCUMENTNO#}";

                    ACCOUNTOFFICENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 28, 101, 33, false);
                    ACCOUNTOFFICENAME.Name = "ACCOUNTOFFICENAME";
                    ACCOUNTOFFICENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTOFFICENAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ACCOUNTOFFICENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RECEIPTREPORTACCOUNTOFFICENAME"", """")
";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 53, 164, 57, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.CaseFormat = CaseFormatEnum.fcUpperCase;
                    TCKIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    PAYEEADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 57, 164, 61, false);
                    PAYEEADDRESS.Name = "PAYEEADDRESS";
                    PAYEEADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYEEADDRESS.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYEEADDRESS.Value = @"";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 61, 164, 65, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.CaseFormat = CaseFormatEnum.fcUpperCase;
                    DESCRIPTION.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Receipt.ReceiptReportQuery_Class dataset_ReceiptReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Receipt.ReceiptReportQuery_Class>(0);
                    RECEIPTSPECIALNO.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.SpecialNo) : "");
                    CASHOFFICENAME.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.CashOfficeName) : "");
                    PAYEENAME.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.PayeeName) : "");
                    DOCUMENTNO.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.DocumentNo) : "");
                    TCKIMLIKNO.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.UniqueRefNo) : "");
                    PAYEEADDRESS.CalcValue = @"";
                    DESCRIPTION.CalcValue = @"";
                    ACCOUNTOFFICENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RECEIPTREPORTACCOUNTOFFICENAME", "")
;
                    return new TTReportObject[] { RECEIPTSPECIALNO,CASHOFFICENAME,PAYEENAME,DOCUMENTNO,TCKIMLIKNO,PAYEEADDRESS,DESCRIPTION,ACCOUNTOFFICENAME};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public ReceiptReport MyParentReport
                {
                    get { return (ReceiptReport)ParentReport; }
                }
                
                public TTReportField TOTALPRICE;
                public TTReportField PRICEWITHLETTERS;
                public TTReportField DESC;
                public TTReportField RECEIPTDATE;
                public TTReportField CASHIERNAME;
                public TTReportField TOTALPRICE1;
                public TTReportField ACCOUNTANTTITLE1;
                public TTReportField ADVANCES; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 38;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 9, 176, 14, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPRICE.Value = @"{#TOTALPAYMENT#}";

                    PRICEWITHLETTERS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 20, 188, 25, false);
                    PRICEWITHLETTERS.Name = "PRICEWITHLETTERS";
                    PRICEWITHLETTERS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICEWITHLETTERS.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PRICEWITHLETTERS.TextFormat = @"NUMBERTEXT( TL , KR)";
                    PRICEWITHLETTERS.Value = @"{%TOTALPRICE1%}";

                    DESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 20, 74, 25, false);
                    DESC.Name = "DESC";
                    DESC.FieldType = ReportFieldTypeEnum.ftExpression;
                    DESC.CaseFormat = CaseFormatEnum.fcUpperCase;
                    DESC.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RECEIPTREPORTACCOUNTOFFICENAME"", """")";

                    RECEIPTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 26, 89, 31, false);
                    RECEIPTDATE.Name = "RECEIPTDATE";
                    RECEIPTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIPTDATE.TextFormat = @"Short Date";
                    RECEIPTDATE.Value = @"{#DOCUMENTDATE#}";

                    CASHIERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 27, 188, 32, false);
                    CASHIERNAME.Name = "CASHIERNAME";
                    CASHIERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIERNAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CASHIERNAME.MultiLine = EvetHayirEnum.ehEvet;
                    CASHIERNAME.NoClip = EvetHayirEnum.ehEvet;
                    CASHIERNAME.WordBreak = EvetHayirEnum.ehEvet;
                    CASHIERNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    CASHIERNAME.Value = @"{#CASHIERNAME#}";

                    TOTALPRICE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 5, 207, 10, false);
                    TOTALPRICE1.Name = "TOTALPRICE1";
                    TOTALPRICE1.Visible = EvetHayirEnum.ehHayir;
                    TOTALPRICE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE1.Value = @"{#TOTALPAYMENT#}";

                    ACCOUNTANTTITLE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 32, 188, 36, false);
                    ACCOUNTANTTITLE1.Name = "ACCOUNTANTTITLE1";
                    ACCOUNTANTTITLE1.Value = @"Dön. Ser. Muh. Yet. Mut.";

                    ADVANCES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 3, 137, 18, false);
                    ADVANCES.Name = "ADVANCES";
                    ADVANCES.FieldType = ReportFieldTypeEnum.ftExpression;
                    ADVANCES.MultiLine = EvetHayirEnum.ehEvet;
                    ADVANCES.WordBreak = EvetHayirEnum.ehEvet;
                    ADVANCES.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Receipt.ReceiptReportQuery_Class dataset_ReceiptReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Receipt.ReceiptReportQuery_Class>(0);
                    TOTALPRICE.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.TotalPayment) : "");
                    TOTALPRICE1.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.TotalPayment) : "");
                    PRICEWITHLETTERS.CalcValue = MyParentReport.HEADER.TOTALPRICE1.CalcValue;
                    RECEIPTDATE.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.DocumentDate) : "");
                    CASHIERNAME.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.Cashiername) : "");
                    ACCOUNTANTTITLE1.CalcValue = ACCOUNTANTTITLE1.Value;
                    DESC.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RECEIPTREPORTACCOUNTOFFICENAME", "");
                    ADVANCES.CalcValue = @"";
                    return new TTReportObject[] { TOTALPRICE,TOTALPRICE1,PRICEWITHLETTERS,RECEIPTDATE,CASHIERNAME,ACCOUNTANTTITLE1,DESC,ADVANCES};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    string advances = string.Empty;
            
            string rObjectID = ((ReceiptReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Receipt receipt = (Receipt)MyParentReport.ReportObjectContext.GetObject(new Guid(rObjectID), typeof(Receipt));
            
            foreach(AdvanceDocument adv in receipt.ReceiptDocument.AdvanceDocuments)
            {
                if(receipt.ReceiptDocument.ResUser != adv.ResUser) // avans alan ile makbuz kesen farklı cashierlog lar ise gösterilir
                {
                    if(advances == string.Empty)
                        advances += "AVANS: ";
                    
                    advances += adv.TotalPrice.ToString() + " ";
                    
                    if(adv.DocumentNo != null)
                        advances += adv.DocumentNo + " ";
                    
                    if(adv.CreditCardDocumentNo != null)
                        advances += adv.CreditCardDocumentNo + " ";
                    
                    advances += adv.ResUser.Name + ", ";
                }
            }
            
            if(advances != string.Empty)
            {
                advances = advances.Substring(0,(advances.Length-2));
                this.ADVANCES.CalcValue = advances;
                this.ADVANCES.Visible = EvetHayirEnum.ehEvet;
            }
            else
                this.ADVANCES.Visible = EvetHayirEnum.ehHayir;
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public ReceiptReport MyParentReport
            {
                get { return (ReceiptReport)ParentReport; }
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
                public ReceiptReport MyParentReport
                {
                    get { return (ReceiptReport)ParentReport; }
                }
                
                public TTReportField DESCRIPTION;
                public TTReportField PRICE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 110, 5, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.Value = @"Hasta Muayene/Tedavi Bedeli";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 0, 176, 5, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.Value = @"{#HEADER.TOTALPAYMENT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Receipt.ReceiptReportQuery_Class dataset_ReceiptReportQuery = MyParentReport.HEADER.rsGroup.GetCurrentRecord<Receipt.ReceiptReportQuery_Class>(0);
                    DESCRIPTION.CalcValue = DESCRIPTION.Value;
                    PRICE.CalcValue = (dataset_ReceiptReportQuery != null ? Globals.ToStringCore(dataset_ReceiptReportQuery.TotalPayment) : "");
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

        public ReceiptReport()
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
            Name = "RECEIPTREPORT";
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