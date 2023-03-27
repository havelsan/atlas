
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
    public partial class EvrakRapor : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public EvrakRapor MyParentReport
            {
                get { return (EvrakRapor)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NAME1 { get {return Header().NAME1;} }
            public TTReportField NOTE1 { get {return Header().NOTE1;} }
            public TTReportField NAME11 { get {return Header().NAME11;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportRTF NewRTF1 { get {return Header().NewRTF1;} }
            public TTReportField sayfa_ { get {return Footer().sayfa_;} }
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
                public EvrakRapor MyParentReport
                {
                    get { return (EvrakRapor)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NAME1;
                public TTReportField NOTE1;
                public TTReportField NAME11;
                public TTReportShape NewLine1;
                public TTReportRTF NewRTF1; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 31;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 6, 189, 16, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Size = 20;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Evrak Raporu";

                    NAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 20, 83, 25, false);
                    NAME1.Name = "NAME1";
                    NAME1.Value = @"ADI";

                    NOTE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 20, 109, 25, false);
                    NOTE1.Name = "NOTE1";
                    NOTE1.Value = @"NOT
";

                    NAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 20, 135, 25, false);
                    NAME11.Name = "NAME11";
                    NAME11.Value = @"ADI";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 33, 26, 177, 26, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRTF1 = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 180, 10, 205, 15, false);
                    NewRTF1.Name = "NewRTF1";
                    NewRTF1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NAME1.CalcValue = NAME1.Value;
                    NOTE1.CalcValue = NOTE1.Value;
                    NAME11.CalcValue = NAME11.Value;
                    NewRTF1.CalcValue = NewRTF1.Value;
                    return new TTReportObject[] { NewField1,NAME1,NOTE1,NAME11,NewRTF1};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public EvrakRapor MyParentReport
                {
                    get { return (EvrakRapor)ParentReport; }
                }
                
                public TTReportField sayfa_; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    sayfa_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 14, 210, 19, false);
                    sayfa_.Name = "sayfa_";
                    sayfa_.FieldType = ReportFieldTypeEnum.ftVariable;
                    sayfa_.Value = @"{@pagenumber@}/{@printdate@} / {@printdatetime@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    sayfa_.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + DateTime.Now.ToShortDateString() + @" / " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    return new TTReportObject[] { sayfa_};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class hhhhGroup : TTReportGroup
        {
            public EvrakRapor MyParentReport
            {
                get { return (EvrakRapor)ParentReport; }
            }

            new public hhhhGroupHeader Header()
            {
                return (hhhhGroupHeader)_header;
            }

            new public hhhhGroupFooter Footer()
            {
                return (hhhhGroupFooter)_footer;
            }

            public hhhhGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public hhhhGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new hhhhGroupHeader(this);
                _footer = new hhhhGroupFooter(this);

            }

            public partial class hhhhGroupHeader : TTReportSection
            {
                public EvrakRapor MyParentReport
                {
                    get { return (EvrakRapor)ParentReport; }
                }
                 
                public hhhhGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class hhhhGroupFooter : TTReportSection
            {
                public EvrakRapor MyParentReport
                {
                    get { return (EvrakRapor)ParentReport; }
                }
                 
                public hhhhGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public hhhhGroup hhhh;

        public partial class MAINGroup : TTReportGroup
        {
            public EvrakRapor MyParentReport
            {
                get { return (EvrakRapor)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField NOTE { get {return Body().NOTE;} }
            public TTReportField NAME1 { get {return Body().NAME1;} }
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
                list[0] = new TTReportNqlData<DenemeClass.EvrakQ_Class>("EvrakQ", DenemeClass.EvrakQ());
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
                public EvrakRapor MyParentReport
                {
                    get { return (EvrakRapor)ParentReport; }
                }
                
                public TTReportField NAME;
                public TTReportField NOTE;
                public TTReportField NAME1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 40;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 13, 103, 18, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.Value = @"{#NAME#}";

                    NOTE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 13, 129, 18, false);
                    NOTE.Name = "NOTE";
                    NOTE.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOTE.Value = @"{#NOTE#}";

                    NAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 13, 155, 18, false);
                    NAME1.Name = "NAME1";
                    NAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME1.Value = @"{#NAME1#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DenemeClass.EvrakQ_Class dataset_EvrakQ = ParentGroup.rsGroup.GetCurrentRecord<DenemeClass.EvrakQ_Class>(0);
                    NAME.CalcValue = (dataset_EvrakQ != null ? Globals.ToStringCore(dataset_EvrakQ.Name) : "");
                    NOTE.CalcValue = (dataset_EvrakQ != null ? Globals.ToStringCore(dataset_EvrakQ.Note) : "");
                    NAME1.CalcValue = (dataset_EvrakQ != null ? Globals.ToStringCore(dataset_EvrakQ.Name1) : "");
                    return new TTReportObject[] { NAME,NOTE,NAME1};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public EvrakRapor()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            hhhh = new hhhhGroup(HEADER,"hhhh");
            MAIN = new MAINGroup(hhhh,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "EVRAKRAPOR";
            Caption = "Evrak Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
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