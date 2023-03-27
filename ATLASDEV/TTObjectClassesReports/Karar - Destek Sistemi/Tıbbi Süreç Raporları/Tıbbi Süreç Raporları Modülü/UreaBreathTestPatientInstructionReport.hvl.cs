
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
    /// Üre Nefes Testi Hasta Talimat Raporu
    /// </summary>
    public partial class UreaBreathTestPatientInstructionReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public UreaBreathTestPatientInstructionReport MyParentReport
            {
                get { return (UreaBreathTestPatientInstructionReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField Header { get {return Body().Header;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportField NewField5 { get {return Body().NewField5;} }
            public TTReportField NewField6 { get {return Body().NewField6;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField NewField162 { get {return Body().NewField162;} }
            public TTReportField NewField163 { get {return Body().NewField163;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField7 { get {return Body().NewField7;} }
            public TTReportField NewField164 { get {return Body().NewField164;} }
            public TTReportField NewField165 { get {return Body().NewField165;} }
            public TTReportField NewField166 { get {return Body().NewField166;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
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
                public UreaBreathTestPatientInstructionReport MyParentReport
                {
                    get { return (UreaBreathTestPatientInstructionReport)ParentReport; }
                }
                
                public TTReportField Header;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField16;
                public TTReportField NewField161;
                public TTReportField NewField162;
                public TTReportField NewField163;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField7;
                public TTReportField NewField164;
                public TTReportField NewField165;
                public TTReportField NewField166;
                public TTReportField NewField131; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 89;
                    RepeatCount = 0;
                    
                    Header = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 14, 177, 24, false);
                    Header.Name = "Header";
                    Header.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Header.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Header.TextFont.Size = 16;
                    Header.TextFont.Bold = true;
                    Header.TextFont.CharSet = 162;
                    Header.Value = @"C-13 ÜRE NEFES TESTİ HASTA TALİMATI";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 32, 123, 37, false);
                    NewField1.Name = "NewField1";
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Size = 12;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"- Hasta testten önce en az 8 saat aç olmalı (tercihen gece boyunca) ve ";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 39, 62, 44, false);
                    NewField2.Name = "NewField2";
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Size = 12;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"- 1 ay öncesinden kullanılan tüm ";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 39, 83, 44, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Size = 12;
                    NewField3.TextFont.Underline = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"antibiyotikler";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 39, 200, 44, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Size = 12;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"kesilmelidir.";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 46, 44, 51, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Size = 12;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"- 2 hafta öncesinden";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 46, 79, 51, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Size = 12;
                    NewField6.TextFont.Underline = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"mide asit inhibitörleri";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 81, 200, 86, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Size = 12;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"- Lütfen Tıbbi Biyokimya AD Kan Alma Salonundan randevunuzu alınız.";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 46, 158, 51, false);
                    NewField161.Name = "NewField161";
                    NewField161.TextFont.Size = 12;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"(Sukralfat,Omeprazol,Esomeprazol,Lansoprazol),";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 46, 200, 51, false);
                    NewField162.Name = "NewField162";
                    NewField162.TextFont.Size = 12;
                    NewField162.TextFont.Underline = true;
                    NewField162.TextFont.CharSet = 162;
                    NewField162.Value = @"H2 reseptör antagonistleri";

                    NewField163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 53, 71, 58, false);
                    NewField163.Name = "NewField163";
                    NewField163.TextFont.Size = 12;
                    NewField163.TextFont.CharSet = 162;
                    NewField163.Value = @"(Simetidin,Ranitidin,Famotidin) ve ";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 53, 87, 58, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Size = 12;
                    NewField13.TextFont.Underline = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"antiasitler";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 53, 200, 58, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Size = 12;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"(Talcid, Renie gibi) kesilmelidir.";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 60, 200, 65, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Size = 12;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"- Test tedavinin takibi amacıyla yapılacaksa, tedavi bitiminden 4-6 hafta sonra yapılmalıdır.";

                    NewField164 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 67, 200, 72, false);
                    NewField164.Name = "NewField164";
                    NewField164.TextFont.Size = 12;
                    NewField164.TextFont.CharSet = 162;
                    NewField164.Value = @"- Test işlemi yaklaşık 40 dakika sürer.";

                    NewField165 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 74, 200, 79, false);
                    NewField165.Name = "NewField165";
                    NewField165.TextFont.Size = 12;
                    NewField165.TextFont.CharSet = 162;
                    NewField165.Value = @"- 12 yaş altında bu test uygulanamaz.";

                    NewField166 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 32, 200, 37, false);
                    NewField166.Name = "NewField166";
                    NewField166.TextFont.Size = 12;
                    NewField166.TextFont.CharSet = 162;
                    NewField166.Value = @"dahil hiçbir şey tüketmemelidir.";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 32, 141, 37, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Size = 12;
                    NewField131.TextFont.Underline = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"su, sigara";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Header.CalcValue = Header.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField162.CalcValue = NewField162.Value;
                    NewField163.CalcValue = NewField163.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField164.CalcValue = NewField164.Value;
                    NewField165.CalcValue = NewField165.Value;
                    NewField166.CalcValue = NewField166.Value;
                    NewField131.CalcValue = NewField131.Value;
                    return new TTReportObject[] { Header,NewField1,NewField2,NewField3,NewField4,NewField5,NewField6,NewField16,NewField161,NewField162,NewField163,NewField13,NewField14,NewField7,NewField164,NewField165,NewField166,NewField131};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public UreaBreathTestPatientInstructionReport()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "EpisodeActionID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "UREABREATHTESTPATIENTINSTRUCTIONREPORT";
            Caption = "Üre Nefes Testi Hasta Talimat Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            UsePrinterMargins = EvetHayirEnum.ehEvet;
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