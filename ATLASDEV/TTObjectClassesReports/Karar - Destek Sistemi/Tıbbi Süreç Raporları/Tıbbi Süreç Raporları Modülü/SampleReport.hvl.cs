
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
    /// Standartlara Uygun Rapor
    /// </summary>
    public partial class SampleReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public SampleReport MyParentReport
            {
                get { return (SampleReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField PatientName { get {return Header().PatientName;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField FatherName { get {return Header().FatherName;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField71 { get {return Header().NewField71;} }
            public TTReportField PatientTCNo { get {return Header().PatientTCNo;} }
            public TTReportField NewField81 { get {return Header().NewField81;} }
            public TTReportField XXXXXXIL { get {return Header().XXXXXXIL;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportField NewField91 { get {return Header().NewField91;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField31 { get {return Header().NewField31;} }
            public TTReportField HizmetOzel { get {return Footer().HizmetOzel;} }
            public TTReportShape NewLine { get {return Footer().NewLine;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField UserName { get {return Footer().UserName;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
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
                public SampleReport MyParentReport
                {
                    get { return (SampleReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField NewField2;
                public TTReportField PatientName;
                public TTReportField NewField4;
                public TTReportField FatherName;
                public TTReportField NewField3;
                public TTReportField NewField21;
                public TTReportField NewField71;
                public TTReportField PatientTCNo;
                public TTReportField NewField81;
                public TTReportField XXXXXXIL;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField8;
                public TTReportField LOGO;
                public TTReportField NewField9;
                public TTReportField NewField18;
                public TTReportField NewField10;
                public TTReportField NewField91;
                public TTReportField NewField11;
                public TTReportField NewField31; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 78;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 22, 161, 30, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.TextFont.Size = 15;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"NÜKLEER TIP SONUÇ RAPORU";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 67, 47, 72, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Hasta Adı";

                    PatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 67, 113, 72, false);
                    PatientName.Name = "PatientName";
                    PatientName.TextFont.Size = 9;
                    PatientName.TextFont.CharSet = 162;
                    PatientName.Value = @"PatientName(Arial Narrow 10)";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 72, 47, 77, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Size = 11;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Baba Adı";

                    FatherName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 72, 113, 77, false);
                    FatherName.Name = "FatherName";
                    FatherName.TextFont.Size = 9;
                    FatherName.TextFont.CharSet = 162;
                    FatherName.Value = @"FatherName(Arial Narrow 10)";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 67, 50, 72, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Size = 11;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @":";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 72, 50, 77, false);
                    NewField21.Name = "NewField21";
                    NewField21.TextFont.Size = 11;
                    NewField21.TextFont.Bold = true;
                    NewField21.TextFont.CharSet = 162;
                    NewField21.Value = @":";

                    NewField71 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 62, 47, 67, false);
                    NewField71.Name = "NewField71";
                    NewField71.TextFont.Size = 11;
                    NewField71.TextFont.Bold = true;
                    NewField71.TextFont.CharSet = 162;
                    NewField71.Value = @"Hasta T.C. No";

                    PatientTCNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 62, 113, 67, false);
                    PatientTCNo.Name = "PatientTCNo";
                    PatientTCNo.TextFont.Size = 9;
                    PatientTCNo.TextFont.CharSet = 162;
                    PatientTCNo.Value = @"PatientTCNo(Arial Narrow 10)";

                    NewField81 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 62, 50, 67, false);
                    NewField81.Name = "NewField81";
                    NewField81.TextFont.Size = 11;
                    NewField81.TextFont.Bold = true;
                    NewField81.TextFont.CharSet = 162;
                    NewField81.Value = @":";

                    XXXXXXIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 16, 161, 22, false);
                    XXXXXXIL.Name = "XXXXXXIL";
                    XXXXXXIL.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXIL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXIL.TextFont.Size = 11;
                    XXXXXXIL.TextFont.Bold = true;
                    XXXXXXIL.TextFont.CharSet = 162;
                    XXXXXXIL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 10, 161, 16, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 35, 39, 42, false);
                    NewField8.Name = "NewField8";
                    NewField8.TextFont.Size = 11;
                    NewField8.TextFont.Bold = true;
                    NewField8.TextFont.Underline = true;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @"HİZMETE ÖZEL";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 50, 30, false);
                    LOGO.Name = "LOGO";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"LOGO";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 44, 47, 49, false);
                    NewField9.Name = "NewField9";
                    NewField9.TextFont.Size = 9;
                    NewField9.TextFont.Bold = true;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @"Parameter 1(Arial Narrow 10)";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 44, 50, 49, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Size = 11;
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @":";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 49, 47, 54, false);
                    NewField10.Name = "NewField10";
                    NewField10.TextFont.Size = 9;
                    NewField10.TextFont.Bold = true;
                    NewField10.TextFont.CharSet = 162;
                    NewField10.Value = @"Parameter 2(Arial Narrow 10)";

                    NewField91 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 49, 50, 54, false);
                    NewField91.Name = "NewField91";
                    NewField91.TextFont.Size = 11;
                    NewField91.TextFont.Bold = true;
                    NewField91.TextFont.CharSet = 162;
                    NewField91.Value = @":";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 44, 90, 49, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Parameter Value(Arial Narrow 10)";

                    NewField31 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 49, 90, 54, false);
                    NewField31.Name = "NewField31";
                    NewField31.TextFont.Size = 9;
                    NewField31.TextFont.CharSet = 162;
                    NewField31.Value = @"Parameter Value(Arial Narrow 10)";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField.CalcValue = NewField.Value;
                    NewField2.CalcValue = NewField2.Value;
                    PatientName.CalcValue = PatientName.Value;
                    NewField4.CalcValue = NewField4.Value;
                    FatherName.CalcValue = FatherName.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField71.CalcValue = NewField71.Value;
                    PatientTCNo.CalcValue = PatientTCNo.Value;
                    NewField81.CalcValue = NewField81.Value;
                    NewField8.CalcValue = NewField8.Value;
                    LOGO.CalcValue = LOGO.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField91.CalcValue = NewField91.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField31.CalcValue = NewField31.Value;
                    XXXXXXIL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { NewField,NewField2,PatientName,NewField4,FatherName,NewField3,NewField21,NewField71,PatientTCNo,NewField81,NewField8,LOGO,NewField9,NewField18,NewField10,NewField91,NewField11,NewField31,XXXXXXIL,XXXXXXBASLIK};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public SampleReport MyParentReport
                {
                    get { return (SampleReport)ParentReport; }
                }
                
                public TTReportField HizmetOzel;
                public TTReportShape NewLine;
                public TTReportField PrintDate;
                public TTReportField UserName;
                public TTReportField PageNumber; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 17;
                    RepeatCount = 0;
                    
                    HizmetOzel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 4, 36, 10, false);
                    HizmetOzel.Name = "HizmetOzel";
                    HizmetOzel.TextFont.Size = 11;
                    HizmetOzel.TextFont.Bold = true;
                    HizmetOzel.TextFont.Underline = true;
                    HizmetOzel.TextFont.CharSet = 162;
                    HizmetOzel.Value = @"HİZMETE ÖZEL";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 3, 207, 3, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 9, 208, 14, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}}";

                    UserName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 4, 208, 9, false);
                    UserName.Name = "UserName";
                    UserName.TextFont.Size = 8;
                    UserName.TextFont.CharSet = 162;
                    UserName.Value = @"UserName";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 4, 115, 9, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HizmetOzel.CalcValue = HizmetOzel.Value;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + @"}";
                    UserName.CalcValue = UserName.Value;
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    return new TTReportObject[] { HizmetOzel,PrintDate,UserName,PageNumber};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public SampleReport MyParentReport
            {
                get { return (SampleReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField { get {return Body().NewField;} }
            public TTReportRTF NewRTF { get {return Body().NewRTF;} }
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
                public SampleReport MyParentReport
                {
                    get { return (SampleReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportRTF NewRTF; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 40;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 35, 7, false);
                    NewField.Name = "NewField";
                    NewField.TextFont.Size = 11;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"Rapor";

                    NewRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 10, 7, 207, 38, false);
                    NewRTF.Name = "NewRTF";
                    NewRTF.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20\{#REPORT#\} (Arial Narrow 10)\par
}
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField.CalcValue = NewField.Value;
                    NewRTF.CalcValue = NewRTF.Value;
                    return new TTReportObject[] { NewField,NewRTF};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public SampleReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "SAMPLEREPORT";
            Caption = "Standartlara Uygun Rapor";
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