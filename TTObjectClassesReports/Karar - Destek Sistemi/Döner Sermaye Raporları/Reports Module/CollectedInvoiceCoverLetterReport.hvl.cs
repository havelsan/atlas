
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
    /// Toplu Fatura ÖnYazısı
    /// </summary>
    public partial class CollectedInvoiceCoverLetterReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public CollectedInvoiceCoverLetterReport MyParentReport
            {
                get { return (CollectedInvoiceCoverLetterReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField DOCUMENTNO { get {return Header().DOCUMENTNO;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField SUBJECT { get {return Header().SUBJECT;} }
            public TTReportField DOCUMENTDATE { get {return Header().DOCUMENTDATE;} }
            public TTReportField NOTE { get {return Footer().NOTE;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public CollectedInvoiceCoverLetterReport MyParentReport
                {
                    get { return (CollectedInvoiceCoverLetterReport)ParentReport; }
                }
                
                public TTReportField HEADER;
                public TTReportField NewField;
                public TTReportField NewField2;
                public TTReportField DOCUMENTNO;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField SUBJECT;
                public TTReportField DOCUMENTDATE; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 36;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 3, 150, 18, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftOLE;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.Value = @"";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 24, 26, 29, false);
                    NewField.Name = "NewField";
                    NewField.TextFont.Size = 9;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"SAYI";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 24, 29, 29, false);
                    NewField2.Name = "NewField2";
                    NewField2.Value = @":";

                    DOCUMENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 24, 54, 29, false);
                    DOCUMENTNO.Name = "DOCUMENTNO";
                    DOCUMENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNO.Value = @"";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 29, 26, 34, false);
                    NewField3.Name = "NewField3";
                    NewField3.Value = @"KONU";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 29, 29, 34, false);
                    NewField4.Name = "NewField4";
                    NewField4.Value = @":";

                    SUBJECT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 29, 86, 34, false);
                    SUBJECT.Name = "SUBJECT";
                    SUBJECT.Value = @"Tedavi Giderleri Hk.";

                    DOCUMENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 24, 184, 29, false);
                    DOCUMENTDATE.Name = "DOCUMENTDATE";
                    DOCUMENTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTDATE.TextFormat = @"dd/mm/yyyy";
                    DOCUMENTDATE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HEADER.CalcValue = @"";
                    NewField.CalcValue = NewField.Value;
                    NewField2.CalcValue = NewField2.Value;
                    DOCUMENTNO.CalcValue = @"";
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    SUBJECT.CalcValue = SUBJECT.Value;
                    DOCUMENTDATE.CalcValue = @"";
                    return new TTReportObject[] { HEADER,NewField,NewField2,DOCUMENTNO,NewField3,NewField4,SUBJECT,DOCUMENTDATE};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public CollectedInvoiceCoverLetterReport MyParentReport
                {
                    get { return (CollectedInvoiceCoverLetterReport)ParentReport; }
                }
                
                public TTReportField NOTE; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                    NOTE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 164, 6, false);
                    NOTE.Name = "NOTE";
                    NOTE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NOTE.CalcValue = NOTE.Value;
                    return new TTReportObject[] { NOTE};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public CollectedInvoiceCoverLetterReport MyParentReport
            {
                get { return (CollectedInvoiceCoverLetterReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField INVOICEUNIT { get {return Body().INVOICEUNIT;} }
            public TTReportField PROVINCE { get {return Body().PROVINCE;} }
            public TTReportField NOTE { get {return Body().NOTE;} }
            public TTReportField NewField { get {return Body().NewField;} }
            public TTReportField ATTACHMENTS { get {return Body().ATTACHMENTS;} }
            public TTReportField ACCOUNTANT { get {return Body().ACCOUNTANT;} }
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
                public CollectedInvoiceCoverLetterReport MyParentReport
                {
                    get { return (CollectedInvoiceCoverLetterReport)ParentReport; }
                }
                
                public TTReportField INVOICEUNIT;
                public TTReportField PROVINCE;
                public TTReportField NOTE;
                public TTReportField NewField;
                public TTReportField ATTACHMENTS;
                public TTReportField ACCOUNTANT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 139;
                    RepeatCount = 0;
                    
                    INVOICEUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 4, 164, 9, false);
                    INVOICEUNIT.Name = "INVOICEUNIT";
                    INVOICEUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    INVOICEUNIT.Value = @"";

                    PROVINCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 10, 164, 15, false);
                    PROVINCE.Name = "PROVINCE";
                    PROVINCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROVINCE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PROVINCE.TextFont.Size = 9;
                    PROVINCE.TextFont.Underline = true;
                    PROVINCE.TextFont.CharSet = 162;
                    PROVINCE.Value = @"";

                    NOTE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 29, 164, 90, false);
                    NOTE.Name = "NOTE";
                    NOTE.MultiLine = EvetHayirEnum.ehEvet;
                    NOTE.NoClip = EvetHayirEnum.ehEvet;
                    NOTE.WordBreak = EvetHayirEnum.ehEvet;
                    NOTE.ExpandTabs = EvetHayirEnum.ehEvet;
                    NOTE.Value = @"       XXXXXX XXXXXX XXXXXXnde Tedavi edilen (   ) Adet kişiye ait masraf belgeleri ve tanzim edilen faturalar ilişiktedir.
       Toplam fatura bedeli olan          nin müdürlüğümüzün T.C. Ziraat Bankası XXXXXX Bürosu ETLİK/XXXXXX 12827340-5003 no'lu hesabına gönderilmesi arz/rica olunur.";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 98, 54, 103, false);
                    NewField.Name = "NewField";
                    NewField.TextFont.Size = 9;
                    NewField.TextFont.Underline = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"EKLER       :";

                    ATTACHMENTS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 104, 103, 137, false);
                    ATTACHMENTS.Name = "ATTACHMENTS";
                    ATTACHMENTS.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATTACHMENTS.Value = @"";

                    ACCOUNTANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 100, 162, 117, false);
                    ACCOUNTANT.Name = "ACCOUNTANT";
                    ACCOUNTANT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANT.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    INVOICEUNIT.CalcValue = @"";
                    PROVINCE.CalcValue = @"";
                    NOTE.CalcValue = NOTE.Value;
                    NewField.CalcValue = NewField.Value;
                    ATTACHMENTS.CalcValue = @"";
                    ACCOUNTANT.CalcValue = @"";
                    return new TTReportObject[] { INVOICEUNIT,PROVINCE,NOTE,NewField,ATTACHMENTS,ACCOUNTANT};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public CollectedInvoiceCoverLetterReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "COLLECTEDINVOICECOVERLETTERREPORT";
            Caption = "CollectedInvoiceCoverLetterReport";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 1;
            p_PageWidth = 216;
            p_PageHeight = 279;
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