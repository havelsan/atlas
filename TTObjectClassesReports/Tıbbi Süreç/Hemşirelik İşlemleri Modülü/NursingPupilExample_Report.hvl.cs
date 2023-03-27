
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
    /// Pupil Genişliği Örnekleri
    /// </summary>
    public partial class NursingPupilExample : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class MAINGroup : TTReportGroup
        {
            public NursingPupilExample MyParentReport
            {
                get { return (NursingPupilExample)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportShape NewCircle1 { get {return Body().NewCircle1;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportShape NewCircle11 { get {return Body().NewCircle11;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportShape NewCircle111 { get {return Body().NewCircle111;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportShape NewCircle13 { get {return Body().NewCircle13;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportShape NewCircle112 { get {return Body().NewCircle112;} }
            public TTReportField NewField112 { get {return Body().NewField112;} }
            public TTReportShape NewCircle14 { get {return Body().NewCircle14;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportShape NewCircle113 { get {return Body().NewCircle113;} }
            public TTReportField NewField113 { get {return Body().NewField113;} }
            public TTReportShape NewCircle12 { get {return Body().NewCircle12;} }
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
                public NursingPupilExample MyParentReport
                {
                    get { return (NursingPupilExample)ParentReport; }
                }
                
                public TTReportShape NewCircle1;
                public TTReportField NewField1;
                public TTReportShape NewCircle11;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportShape NewCircle111;
                public TTReportField NewField111;
                public TTReportShape NewCircle13;
                public TTReportField NewField13;
                public TTReportShape NewCircle112;
                public TTReportField NewField112;
                public TTReportShape NewCircle14;
                public TTReportField NewField14;
                public TTReportShape NewCircle113;
                public TTReportField NewField113;
                public TTReportShape NewCircle12; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 83;
                    RepeatCount = 0;
                    
                    NewCircle1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtCircle, 31, 29, 36, 34, false);
                    NewCircle1.Name = "NewCircle1";
                    NewCircle1.FillColor = System.Drawing.Color.Black;
                    NewCircle1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 5, 67, 10, false);
                    NewField1.Name = "NewField1";
                    NewField1.Value = @"2mm";

                    NewCircle11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtCircle, 31, 21, 35, 25, false);
                    NewCircle11.Name = "NewCircle11";
                    NewCircle11.FillColor = System.Drawing.Color.Black;
                    NewCircle11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 13, 67, 18, false);
                    NewField11.Name = "NewField11";
                    NewField11.Value = @"3mm";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 21, 67, 26, false);
                    NewField12.Name = "NewField12";
                    NewField12.Value = @"4mm";

                    NewCircle111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtCircle, 31, 7, 33, 9, false);
                    NewCircle111.Name = "NewCircle111";
                    NewCircle111.FillColor = System.Drawing.Color.Black;
                    NewCircle111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 29, 67, 34, false);
                    NewField111.Name = "NewField111";
                    NewField111.Value = @"5mm";

                    NewCircle13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtCircle, 31, 37, 37, 43, false);
                    NewCircle13.Name = "NewCircle13";
                    NewCircle13.FillColor = System.Drawing.Color.Black;
                    NewCircle13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 37, 67, 42, false);
                    NewField13.Name = "NewField13";
                    NewField13.Value = @"6mm";

                    NewCircle112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtCircle, 31, 45, 38, 52, false);
                    NewCircle112.Name = "NewCircle112";
                    NewCircle112.FillColor = System.Drawing.Color.Black;
                    NewCircle112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 46, 67, 51, false);
                    NewField112.Name = "NewField112";
                    NewField112.Value = @"7mm";

                    NewCircle14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtCircle, 31, 55, 39, 63, false);
                    NewCircle14.Name = "NewCircle14";
                    NewCircle14.FillColor = System.Drawing.Color.Black;
                    NewCircle14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 56, 67, 61, false);
                    NewField14.Name = "NewField14";
                    NewField14.Value = @"8mm";

                    NewCircle113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtCircle, 31, 66, 40, 75, false);
                    NewCircle113.Name = "NewCircle113";
                    NewCircle113.FillColor = System.Drawing.Color.Black;
                    NewCircle113.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 68, 67, 73, false);
                    NewField113.Name = "NewField113";
                    NewField113.Value = @"9mm";

                    NewCircle12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtCircle, 31, 14, 34, 17, false);
                    NewCircle12.Name = "NewCircle12";
                    NewCircle12.FillColor = System.Drawing.Color.Black;
                    NewCircle12.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField113.CalcValue = NewField113.Value;
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField111,NewField13,NewField112,NewField14,NewField113};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public NursingPupilExample()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "NURSINGPUPILEXAMPLE";
            Caption = "Pupil Genişliği Örnekleri";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            PaperSize = 27;
            p_PageWidth = 110;
            p_PageHeight = 220;
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