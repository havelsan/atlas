
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
    /// Kurum Etiketleri
    /// </summary>
    public partial class InvoicePostingPayerStickerReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public InvoicePostingPayerStickerReport MyParentReport
            {
                get { return (InvoicePostingPayerStickerReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DOSE { get {return Body().DOSE;} }
            public TTReportField PAYERCODE { get {return Body().PAYERCODE;} }
            public TTReportField PAYERNAME { get {return Body().PAYERNAME;} }
            public TTReportField PAYEROBJECTID { get {return Body().PAYEROBJECTID;} }
            public TTReportField PAYERADDRESS { get {return Body().PAYERADDRESS;} }
            public TTReportField PAYERCITY { get {return Body().PAYERCITY;} }
            public TTReportField P_NUMBER { get {return Body().P_NUMBER;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine3 { get {return Body().NewLine3;} }
            public TTReportShape NewLine4 { get {return Body().NewLine4;} }
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
                list[0] = new TTReportNqlData<InvoicePosting.InvoicePostingPayerQuery_Class>("InvoicePostingPayerQuery", InvoicePosting.InvoicePostingPayerQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public InvoicePostingPayerStickerReport MyParentReport
                {
                    get { return (InvoicePostingPayerStickerReport)ParentReport; }
                }
                
                public TTReportField DOSE;
                public TTReportField PAYERCODE;
                public TTReportField PAYERNAME;
                public TTReportField PAYEROBJECTID;
                public TTReportField PAYERADDRESS;
                public TTReportField PAYERCITY;
                public TTReportField P_NUMBER;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 42;
                    AutoSizeGap = 10;
                    RepeatCount = 2;
                    RepeatWidth = 100;
                    
                    DOSE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 7, 17, 11, false);
                    DOSE.Name = "DOSE";
                    DOSE.TextFont.Name = "Arial Narrow";
                    DOSE.TextFont.Size = 9;
                    DOSE.Value = @"DÖSE:";

                    PAYERCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 11, 94, 15, false);
                    PAYERCODE.Name = "PAYERCODE";
                    PAYERCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERCODE.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYERCODE.TextFont.Name = "Arial Narrow";
                    PAYERCODE.TextFont.Size = 9;
                    PAYERCODE.Value = @"{#PAYERCODE#}";

                    PAYERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 15, 94, 23, false);
                    PAYERNAME.Name = "PAYERNAME";
                    PAYERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERNAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYERNAME.MultiLine = EvetHayirEnum.ehEvet;
                    PAYERNAME.NoClip = EvetHayirEnum.ehEvet;
                    PAYERNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PAYERNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYERNAME.TextFont.Name = "Arial Narrow";
                    PAYERNAME.TextFont.Size = 9;
                    PAYERNAME.Value = @"{#PAYERNAME#}";

                    PAYEROBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 1, 68, 6, false);
                    PAYEROBJECTID.Name = "PAYEROBJECTID";
                    PAYEROBJECTID.Visible = EvetHayirEnum.ehHayir;
                    PAYEROBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYEROBJECTID.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYEROBJECTID.TextFont.Name = "Arial Narrow";
                    PAYEROBJECTID.TextFont.Size = 9;
                    PAYEROBJECTID.Value = @"{#PAYEROBJECTID#}";

                    PAYERADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 23, 94, 31, false);
                    PAYERADDRESS.Name = "PAYERADDRESS";
                    PAYERADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERADDRESS.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYERADDRESS.MultiLine = EvetHayirEnum.ehEvet;
                    PAYERADDRESS.NoClip = EvetHayirEnum.ehEvet;
                    PAYERADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    PAYERADDRESS.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYERADDRESS.TextFont.Name = "Arial Narrow";
                    PAYERADDRESS.TextFont.Size = 9;
                    PAYERADDRESS.Value = @"";

                    PAYERCITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 31, 94, 35, false);
                    PAYERCITY.Name = "PAYERCITY";
                    PAYERCITY.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERCITY.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYERCITY.TextFont.Name = "Arial Narrow";
                    PAYERCITY.TextFont.Size = 9;
                    PAYERCITY.Value = @"{#PAYERCITY#}";

                    P_NUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 7, 94, 11, false);
                    P_NUMBER.Name = "P_NUMBER";
                    P_NUMBER.FieldType = ReportFieldTypeEnum.ftExpression;
                    P_NUMBER.TextFont.Name = "Arial Narrow";
                    P_NUMBER.TextFont.Size = 9;
                    P_NUMBER.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""INVOICEPOSTINGNUMBER"", """") + "" "" + {#POSTINGNUMBER#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 97, 1, 97, 1, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 99, 3, 99, 3, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 98, 1, 98, 38, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbDashDotDot;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 38, 97, 38, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbDashDotDot;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InvoicePosting.InvoicePostingPayerQuery_Class dataset_InvoicePostingPayerQuery = ParentGroup.rsGroup.GetCurrentRecord<InvoicePosting.InvoicePostingPayerQuery_Class>(0);
                    DOSE.CalcValue = DOSE.Value;
                    PAYERCODE.CalcValue = (dataset_InvoicePostingPayerQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPayerQuery.Payercode) : "");
                    PAYERNAME.CalcValue = (dataset_InvoicePostingPayerQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPayerQuery.Payername) : "");
                    PAYEROBJECTID.CalcValue = (dataset_InvoicePostingPayerQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPayerQuery.Payerobjectid) : "");
                    PAYERADDRESS.CalcValue = @"";
                    PAYERCITY.CalcValue = (dataset_InvoicePostingPayerQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPayerQuery.Payercity) : "");
                    P_NUMBER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("INVOICEPOSTINGNUMBER", "") + " " + (dataset_InvoicePostingPayerQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPayerQuery.PostingNumber) : "");
                    return new TTReportObject[] { DOSE,PAYERCODE,PAYERNAME,PAYEROBJECTID,PAYERADDRESS,PAYERCITY,P_NUMBER};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string pObjectID = PAYEROBJECTID.CalcValue;
            PayerDefinition payer = (PayerDefinition)context.GetObject(new Guid(pObjectID),"PayerDefinition");
            PAYERADDRESS.CalcValue = payer.Address;
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

        public InvoicePostingPayerStickerReport()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action GuidID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "INVOICEPOSTINGPAYERSTICKERREPORT";
            Caption = "Kurum Etiketleri Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 999;
            p_PageWidth = 0;
            p_PageHeight = 0;
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
            fd.TextFont.CharSet = 162;
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