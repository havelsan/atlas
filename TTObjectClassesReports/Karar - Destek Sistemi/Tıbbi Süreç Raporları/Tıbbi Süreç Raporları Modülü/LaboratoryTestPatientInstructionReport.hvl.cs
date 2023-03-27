
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
    /// Laboratuvar Tetkiki Hasta Talimat Raporu
    /// </summary>
    public partial class LaboratoryTestPatientInstructionReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TESTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public LaboratoryTestPatientInstructionReport MyParentReport
            {
                get { return (LaboratoryTestPatientInstructionReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField Header { get {return Body().Header;} }
            public TTReportField DESC { get {return Body().DESC;} }
            public TTReportField TestName { get {return Body().TestName;} }
            public TTReportField TESTNAME { get {return Body().TESTNAME;} }
            public TTReportField TestName1 { get {return Body().TestName1;} }
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
                list[0] = new TTReportNqlData<LaboratoryTestDefinition.GetLabTestInstructionsNQL_Class>("GetLabTestInstructionsNQL", LaboratoryTestDefinition.GetLabTestInstructionsNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TESTOBJECTID)));
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
                public LaboratoryTestPatientInstructionReport MyParentReport
                {
                    get { return (LaboratoryTestPatientInstructionReport)ParentReport; }
                }
                
                public TTReportField Header;
                public TTReportField DESC;
                public TTReportField TestName;
                public TTReportField TESTNAME;
                public TTReportField TestName1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 168;
                    RepeatCount = 0;
                    
                    Header = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 14, 177, 24, false);
                    Header.Name = "Header";
                    Header.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Header.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Header.TextFont.Size = 16;
                    Header.TextFont.Bold = true;
                    Header.TextFont.CharSet = 162;
                    Header.Value = @"LABORATUVAR TETKİKİ HASTA TALİMATI";

                    DESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 60, 201, 149, false);
                    DESC.Name = "DESC";
                    DESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESC.MultiLine = EvetHayirEnum.ehEvet;
                    DESC.NoClip = EvetHayirEnum.ehEvet;
                    DESC.WordBreak = EvetHayirEnum.ehEvet;
                    DESC.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESC.TextFont.Size = 12;
                    DESC.TextFont.CharSet = 162;
                    DESC.Value = @"{#TESTDESCRIPTION#}";

                    TestName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 39, 35, 44, false);
                    TestName.Name = "TestName";
                    TestName.TextFont.Name = "Microsoft Sans Serif";
                    TestName.TextFont.Size = 9;
                    TestName.TextFont.Bold = true;
                    TestName.TextFont.CharSet = 162;
                    TestName.Value = @"TETKİK ADI :";

                    TESTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 39, 200, 44, false);
                    TESTNAME.Name = "TESTNAME";
                    TESTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESTNAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    TESTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    TESTNAME.TextFont.Name = "Microsoft Sans Serif";
                    TESTNAME.TextFont.Size = 9;
                    TESTNAME.TextFont.Bold = true;
                    TESTNAME.TextFont.CharSet = 162;
                    TESTNAME.Value = @"{#CODE#} {#NAME#}";

                    TestName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 54, 105, 59, false);
                    TestName1.Name = "TestName1";
                    TestName1.TextFont.Name = "Microsoft Sans Serif";
                    TestName1.TextFont.Size = 9;
                    TestName1.TextFont.Bold = true;
                    TestName1.TextFont.CharSet = 162;
                    TestName1.Value = @"TETKİK TALİMATLARI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratoryTestDefinition.GetLabTestInstructionsNQL_Class dataset_GetLabTestInstructionsNQL = ParentGroup.rsGroup.GetCurrentRecord<LaboratoryTestDefinition.GetLabTestInstructionsNQL_Class>(0);
                    Header.CalcValue = Header.Value;
                    DESC.CalcValue = (dataset_GetLabTestInstructionsNQL != null ? Globals.ToStringCore(dataset_GetLabTestInstructionsNQL.TestDescription) : "");
                    TestName.CalcValue = TestName.Value;
                    TESTNAME.CalcValue = (dataset_GetLabTestInstructionsNQL != null ? Globals.ToStringCore(dataset_GetLabTestInstructionsNQL.Code) : "") + @" " + (dataset_GetLabTestInstructionsNQL != null ? Globals.ToStringCore(dataset_GetLabTestInstructionsNQL.Name) : "");
                    TestName1.CalcValue = TestName1.Value;
                    return new TTReportObject[] { Header,DESC,TestName,TESTNAME,TestName1};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public LaboratoryTestPatientInstructionReport()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TESTOBJECTID", "", "LaboratoryTestObjectID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TESTOBJECTID"))
                _runtimeParameters.TESTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TESTOBJECTID"]);
            Name = "LABORATORYTESTPATIENTINSTRUCTIONREPORT";
            Caption = "Laboratuvar Tetkiki Hasta Talimat Raporu";
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