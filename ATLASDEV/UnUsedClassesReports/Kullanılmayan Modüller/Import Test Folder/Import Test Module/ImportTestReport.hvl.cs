
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
    /// ImportTestReport
    /// </summary>
    public partial class ImportTestReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ImportTestReport MyParentReport
            {
                get { return (ImportTestReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NEWSTATELOGONNAME1 { get {return Header().NEWSTATELOGONNAME1;} }
            public TTReportField APPROVEDSTATELOGONNAME1 { get {return Header().APPROVEDSTATELOGONNAME1;} }
            public TTReportField COMPLETEDSTATELOGONNAME1 { get {return Header().COMPLETEDSTATELOGONNAME1;} }
            public TTReportField FIRSTSTATELOGONNAME1 { get {return Header().FIRSTSTATELOGONNAME1;} }
            public TTReportField LASTSTATELOGONNAME1 { get {return Header().LASTSTATELOGONNAME1;} }
            public TTReportField PREVSTATELOGONNAME1 { get {return Header().PREVSTATELOGONNAME1;} }
            public TTReportField FIRSTSTATEBRANCHDATE1 { get {return Header().FIRSTSTATEBRANCHDATE1;} }
            public TTReportField NEWSTATEBRANCHDATE1 { get {return Header().NEWSTATEBRANCHDATE1;} }
            public TTReportField NEWSTATEBRANCHDATETIME1 { get {return Header().NEWSTATEBRANCHDATETIME1;} }
            public TTReportField FIRSTSTATEBRANCHDATETIME1 { get {return Header().FIRSTSTATEBRANCHDATETIME1;} }
            public TTReportField NEWSTATENAME1 { get {return Header().NEWSTATENAME1;} }
            public TTReportField FIRSTSTATENAME1 { get {return Header().FIRSTSTATENAME1;} }
            public TTReportField NEWSTATENAME111 { get {return Header().NEWSTATENAME111;} }
            public TTReportField NEWSTATENAME1111 { get {return Header().NEWSTATENAME1111;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public ImportTestReport MyParentReport
                {
                    get { return (ImportTestReport)ParentReport; }
                }
                
                public TTReportField NEWSTATELOGONNAME1;
                public TTReportField APPROVEDSTATELOGONNAME1;
                public TTReportField COMPLETEDSTATELOGONNAME1;
                public TTReportField FIRSTSTATELOGONNAME1;
                public TTReportField LASTSTATELOGONNAME1;
                public TTReportField PREVSTATELOGONNAME1;
                public TTReportField FIRSTSTATEBRANCHDATE1;
                public TTReportField NEWSTATEBRANCHDATE1;
                public TTReportField NEWSTATEBRANCHDATETIME1;
                public TTReportField FIRSTSTATEBRANCHDATETIME1;
                public TTReportField NEWSTATENAME1;
                public TTReportField FIRSTSTATENAME1;
                public TTReportField NEWSTATENAME111;
                public TTReportField NEWSTATENAME1111; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 108;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NEWSTATELOGONNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 5, 68, 10, false);
                    NEWSTATELOGONNAME1.Name = "NEWSTATELOGONNAME1";
                    NEWSTATELOGONNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWSTATELOGONNAME1.ObjectDefName = "DistributionDocument";
                    NEWSTATELOGONNAME1.DataMember = "STATES.NEW.USER.LOGONNAME";
                    NEWSTATELOGONNAME1.Value = @"{@TTOBJECTID@}";

                    APPROVEDSTATELOGONNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 10, 68, 15, false);
                    APPROVEDSTATELOGONNAME1.Name = "APPROVEDSTATELOGONNAME1";
                    APPROVEDSTATELOGONNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    APPROVEDSTATELOGONNAME1.ObjectDefName = "DistributionDocument";
                    APPROVEDSTATELOGONNAME1.DataMember = "STATES.APPROVAL.USER.LOGONNAME";
                    APPROVEDSTATELOGONNAME1.Value = @"{@TTOBJECTID@}";

                    COMPLETEDSTATELOGONNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 15, 68, 20, false);
                    COMPLETEDSTATELOGONNAME1.Name = "COMPLETEDSTATELOGONNAME1";
                    COMPLETEDSTATELOGONNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMPLETEDSTATELOGONNAME1.ObjectDefName = "DistributionDocument";
                    COMPLETEDSTATELOGONNAME1.DataMember = "STATES.COMPLETED.USER.LOGONNAME";
                    COMPLETEDSTATELOGONNAME1.Value = @"{@TTOBJECTID@}";

                    FIRSTSTATELOGONNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 29, 69, 34, false);
                    FIRSTSTATELOGONNAME1.Name = "FIRSTSTATELOGONNAME1";
                    FIRSTSTATELOGONNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRSTSTATELOGONNAME1.ObjectDefName = "DistributionDocument";
                    FIRSTSTATELOGONNAME1.DataMember = "STATES.FIRST.USER.LOGONNAME";
                    FIRSTSTATELOGONNAME1.Value = @"{@TTOBJECTID@}";

                    LASTSTATELOGONNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 34, 69, 39, false);
                    LASTSTATELOGONNAME1.Name = "LASTSTATELOGONNAME1";
                    LASTSTATELOGONNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    LASTSTATELOGONNAME1.ObjectDefName = "DistributionDocument";
                    LASTSTATELOGONNAME1.DataMember = "STATES.LAST.USER.LOGONNAME";
                    LASTSTATELOGONNAME1.Value = @"{@TTOBJECTID@}";

                    PREVSTATELOGONNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 40, 69, 45, false);
                    PREVSTATELOGONNAME1.Name = "PREVSTATELOGONNAME1";
                    PREVSTATELOGONNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PREVSTATELOGONNAME1.ObjectDefName = "DistributionDocument";
                    PREVSTATELOGONNAME1.DataMember = "STATES.PREV.USER.LOGONNAME";
                    PREVSTATELOGONNAME1.Value = @"{@TTOBJECTID@}";

                    FIRSTSTATEBRANCHDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 29, 134, 34, false);
                    FIRSTSTATEBRANCHDATE1.Name = "FIRSTSTATEBRANCHDATE1";
                    FIRSTSTATEBRANCHDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRSTSTATEBRANCHDATE1.ObjectDefName = "DistributionDocument";
                    FIRSTSTATEBRANCHDATE1.DataMember = "STATES.FIRST.BRANCHDATE";
                    FIRSTSTATEBRANCHDATE1.Value = @"{@TTOBJECTID@}";

                    NEWSTATEBRANCHDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 5, 133, 10, false);
                    NEWSTATEBRANCHDATE1.Name = "NEWSTATEBRANCHDATE1";
                    NEWSTATEBRANCHDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWSTATEBRANCHDATE1.ObjectDefName = "DistributionDocument";
                    NEWSTATEBRANCHDATE1.DataMember = "STATES.NEW.BRANCHDATE";
                    NEWSTATEBRANCHDATE1.Value = @"{@TTOBJECTID@}";

                    NEWSTATEBRANCHDATETIME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 5, 198, 10, false);
                    NEWSTATEBRANCHDATETIME1.Name = "NEWSTATEBRANCHDATETIME1";
                    NEWSTATEBRANCHDATETIME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWSTATEBRANCHDATETIME1.ObjectDefName = "DistributionDocument";
                    NEWSTATEBRANCHDATETIME1.DataMember = "STATES.NEW.BRANCHDATETIME";
                    NEWSTATEBRANCHDATETIME1.Value = @"{@TTOBJECTID@}";

                    FIRSTSTATEBRANCHDATETIME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 29, 198, 34, false);
                    FIRSTSTATEBRANCHDATETIME1.Name = "FIRSTSTATEBRANCHDATETIME1";
                    FIRSTSTATEBRANCHDATETIME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRSTSTATEBRANCHDATETIME1.ObjectDefName = "DistributionDocument";
                    FIRSTSTATEBRANCHDATETIME1.DataMember = "STATES.FIRST.BRANCHDATETIME";
                    FIRSTSTATEBRANCHDATETIME1.Value = @"{@TTOBJECTID@}";

                    NEWSTATENAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 54, 69, 59, false);
                    NEWSTATENAME1.Name = "NEWSTATENAME1";
                    NEWSTATENAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWSTATENAME1.ObjectDefName = "DistributionDocument";
                    NEWSTATENAME1.DataMember = "STATES.NEW.USER.NAME";
                    NEWSTATENAME1.Value = @"{@TTOBJECTID@}";

                    FIRSTSTATENAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 78, 70, 83, false);
                    FIRSTSTATENAME1.Name = "FIRSTSTATENAME1";
                    FIRSTSTATENAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRSTSTATENAME1.ObjectDefName = "DistributionDocument";
                    FIRSTSTATENAME1.DataMember = "STATES.FIRST.USER.NAME";
                    FIRSTSTATENAME1.Value = @"{@TTOBJECTID@}";

                    NEWSTATENAME111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 61, 175, 66, false);
                    NEWSTATENAME111.Name = "NEWSTATENAME111";
                    NEWSTATENAME111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWSTATENAME111.ObjectDefName = "DistributionDocument";
                    NEWSTATENAME111.DataMember = "STATES.NEW.USER.MILITARYCLASS.NAME";
                    NEWSTATENAME111.Value = @"{@TTOBJECTID@}";

                    NEWSTATENAME1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 71, 181, 76, false);
                    NEWSTATENAME1111.Name = "NEWSTATENAME1111";
                    NEWSTATENAME1111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWSTATENAME1111.ObjectDefName = "DistributionDocument";
                    NEWSTATENAME1111.DataMember = "STATES.NEW.USER.RANK.NAME";
                    NEWSTATENAME1111.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NEWSTATELOGONNAME1.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NEWSTATELOGONNAME1.PostFieldValueCalculation();
                    APPROVEDSTATELOGONNAME1.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    APPROVEDSTATELOGONNAME1.PostFieldValueCalculation();
                    COMPLETEDSTATELOGONNAME1.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    COMPLETEDSTATELOGONNAME1.PostFieldValueCalculation();
                    FIRSTSTATELOGONNAME1.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    FIRSTSTATELOGONNAME1.PostFieldValueCalculation();
                    LASTSTATELOGONNAME1.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    LASTSTATELOGONNAME1.PostFieldValueCalculation();
                    PREVSTATELOGONNAME1.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PREVSTATELOGONNAME1.PostFieldValueCalculation();
                    FIRSTSTATEBRANCHDATE1.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    FIRSTSTATEBRANCHDATE1.PostFieldValueCalculation();
                    NEWSTATEBRANCHDATE1.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NEWSTATEBRANCHDATE1.PostFieldValueCalculation();
                    NEWSTATEBRANCHDATETIME1.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NEWSTATEBRANCHDATETIME1.PostFieldValueCalculation();
                    FIRSTSTATEBRANCHDATETIME1.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    FIRSTSTATEBRANCHDATETIME1.PostFieldValueCalculation();
                    NEWSTATENAME1.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NEWSTATENAME1.PostFieldValueCalculation();
                    FIRSTSTATENAME1.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    FIRSTSTATENAME1.PostFieldValueCalculation();
                    NEWSTATENAME111.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NEWSTATENAME111.PostFieldValueCalculation();
                    NEWSTATENAME1111.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NEWSTATENAME1111.PostFieldValueCalculation();
                    return new TTReportObject[] { NEWSTATELOGONNAME1,APPROVEDSTATELOGONNAME1,COMPLETEDSTATELOGONNAME1,FIRSTSTATELOGONNAME1,LASTSTATELOGONNAME1,PREVSTATELOGONNAME1,FIRSTSTATEBRANCHDATE1,NEWSTATEBRANCHDATE1,NEWSTATEBRANCHDATETIME1,FIRSTSTATEBRANCHDATETIME1,NEWSTATENAME1,FIRSTSTATENAME1,NEWSTATENAME111,NEWSTATENAME1111};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ImportTestReport MyParentReport
                {
                    get { return (ImportTestReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public ImportTestReport MyParentReport
            {
                get { return (ImportTestReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
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
                public ImportTestReport MyParentReport
                {
                    get { return (ImportTestReport)ParentReport; }
                }
                 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ImportTestReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "İşlem Nu. :", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "IMPORTTESTREPORT";
            Caption = "ImportTestReport";
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