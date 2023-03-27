
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
    /// Tekik  Sonuç Raporu
    /// </summary>
    public partial class ExaminationTestListReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public List<string> TESTOBJECTIDS = new List<string>();
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public ExaminationTestListReport MyParentReport
            {
                get { return (ExaminationTestListReport)ParentReport; }
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
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField1152 { get {return Header().NewField1152;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField11121 { get {return Header().NewField11121;} }
            public TTReportField PatientName { get {return Header().PatientName;} }
            public TTReportField NewField11921 { get {return Header().NewField11921;} }
            public TTReportField NewField113311 { get {return Header().NewField113311;} }
            public TTReportField PatientAge { get {return Header().PatientAge;} }
            public TTReportField TestDate1 { get {return Header().TestDate1;} }
            public TTReportField TestProcedure1 { get {return Header().TestProcedure1;} }
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
                public ExaminationTestListReport MyParentReport
                {
                    get { return (ExaminationTestListReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField1121;
                public TTReportField NewField1141;
                public TTReportField NewField1152;
                public TTReportField NewField1131;
                public TTReportField NewField11211;
                public TTReportField NewField11121;
                public TTReportField PatientName;
                public TTReportField NewField11921;
                public TTReportField NewField113311;
                public TTReportField PatientAge;
                public TTReportField TestDate1;
                public TTReportField TestProcedure1; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 67;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 35, 158, 41, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.TextFont.Name = "Arial Narrow";
                    NewField.TextFont.Size = 15;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"TETKİK LİSTESİ RAPORU";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 10, 158, 33, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial Narrow";
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 43, 44, 48, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Name = "Arial Narrow";
                    NewField1121.TextFont.Size = 9;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Hasta Adı";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 48, 44, 53, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Name = "Arial Narrow";
                    NewField1141.TextFont.Size = 9;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"Cinsiyet";

                    NewField1152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 43, 144, 48, false);
                    NewField1152.Name = "NewField1152";
                    NewField1152.TextFont.Name = "Arial Narrow";
                    NewField1152.TextFont.Size = 9;
                    NewField1152.TextFont.Bold = true;
                    NewField1152.TextFont.CharSet = 162;
                    NewField1152.Value = @"Hastanın Yaşı";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 43, 47, 48, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Name = "Arial Narrow";
                    NewField1131.TextFont.Size = 9;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @":";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 48, 47, 53, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Name = "Arial Narrow";
                    NewField11211.TextFont.Size = 9;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @":";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 43, 147, 48, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.TextFont.Name = "Arial Narrow";
                    NewField11121.TextFont.Size = 9;
                    NewField11121.TextFont.Bold = true;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @":";

                    PatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 43, 109, 48, false);
                    PatientName.Name = "PatientName";
                    PatientName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientName.MultiLine = EvetHayirEnum.ehEvet;
                    PatientName.ObjectDefName = "EpisodeAction";
                    PatientName.DataMember = "EPISODE.PATIENT.FullName";
                    PatientName.TextFont.Name = "Arial Narrow";
                    PatientName.TextFont.Size = 9;
                    PatientName.TextFont.CharSet = 162;
                    PatientName.Value = @"{@TTOBJECTID@}";

                    NewField11921 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 53, 44, 58, false);
                    NewField11921.Name = "NewField11921";
                    NewField11921.TextFont.Name = "Arial Narrow";
                    NewField11921.TextFont.Size = 9;
                    NewField11921.TextFont.Bold = true;
                    NewField11921.TextFont.CharSet = 162;
                    NewField11921.Value = @"Doğum Yeri";

                    NewField113311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 53, 47, 58, false);
                    NewField113311.Name = "NewField113311";
                    NewField113311.TextFont.Name = "Arial Narrow";
                    NewField113311.TextFont.Size = 9;
                    NewField113311.TextFont.Bold = true;
                    NewField113311.TextFont.CharSet = 162;
                    NewField113311.Value = @":";

                    PatientAge = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 43, 209, 48, false);
                    PatientAge.Name = "PatientAge";
                    PatientAge.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientAge.MultiLine = EvetHayirEnum.ehEvet;
                    PatientAge.ObjectDefName = "EpisodeAction";
                    PatientAge.DataMember = "EPISODE.PATIENT.Age";
                    PatientAge.TextFont.Name = "Arial Narrow";
                    PatientAge.TextFont.Size = 9;
                    PatientAge.TextFont.CharSet = 162;
                    PatientAge.Value = @"{@TTOBJECTID@}";

                    TestDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 60, 42, 65, false);
                    TestDate1.Name = "TestDate1";
                    TestDate1.TextFont.Name = "Arial Narrow";
                    TestDate1.TextFont.Size = 9;
                    TestDate1.TextFont.Bold = true;
                    TestDate1.TextFont.CharSet = 162;
                    TestDate1.Value = @"Tetkik Tarihi ";

                    TestProcedure1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 60, 198, 65, false);
                    TestProcedure1.Name = "TestProcedure1";
                    TestProcedure1.TextFont.Name = "Arial Narrow";
                    TestProcedure1.TextFont.Size = 9;
                    TestProcedure1.TextFont.Bold = true;
                    TestProcedure1.TextFont.CharSet = 162;
                    TestProcedure1.Value = @"Tetkik / Sonuç";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField.CalcValue = NewField.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1152.CalcValue = NewField1152.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11121.CalcValue = NewField11121.Value;
                    PatientName.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PatientName.PostFieldValueCalculation();
                    NewField11921.CalcValue = NewField11921.Value;
                    NewField113311.CalcValue = NewField113311.Value;
                    PatientAge.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PatientAge.PostFieldValueCalculation();
                    TestDate1.CalcValue = TestDate1.Value;
                    TestProcedure1.CalcValue = TestProcedure1.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField,NewField1121,NewField1141,NewField1152,NewField1131,NewField11211,NewField11121,PatientName,NewField11921,NewField113311,PatientAge,TestDate1,TestProcedure1,XXXXXXBASLIK};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public ExaminationTestListReport MyParentReport
                {
                    get { return (ExaminationTestListReport)ParentReport; }
                }
                
                public TTReportShape NewLine;
                public TTReportField PrintDate;
                public TTReportField UserName;
                public TTReportField PageNumber; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 13;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 3, 208, 3, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 4, 36, 9, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    PrintDate.TextFont.Name = "Arial Narrow";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    UserName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 4, 127, 9, false);
                    UserName.Name = "UserName";
                    UserName.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName.TextFont.Name = "Arial Narrow";
                    UserName.TextFont.Size = 8;
                    UserName.TextFont.CharSet = 162;
                    UserName.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 4, 209, 9, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.TextFont.Name = "Arial Narrow";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    UserName.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { PrintDate,PageNumber,UserName};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public ExaminationTestListReport MyParentReport
            {
                get { return (ExaminationTestListReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField TestDate { get {return Body().TestDate;} }
            public TTReportField TestProcedure { get {return Body().TestProcedure;} }
            public TTReportField TestResault { get {return Body().TestResault;} }
            public TTReportRTF REPORT { get {return Body().REPORT;} }
            public TTReportField PROCEDUREOBJECTID { get {return Body().PROCEDUREOBJECTID;} }
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
                list[0] = new TTReportNqlData<SubActionProcedure.GetExaminationTestListNQL_Class>("GetExaminationTestListNQL", SubActionProcedure.GetExaminationTestListNQL((List<string>) MyParentReport.RuntimeParameters.TESTOBJECTIDS));
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
                public ExaminationTestListReport MyParentReport
                {
                    get { return (ExaminationTestListReport)ParentReport; }
                }
                
                public TTReportField TestDate;
                public TTReportField TestProcedure;
                public TTReportField TestResault;
                public TTReportRTF REPORT;
                public TTReportField PROCEDUREOBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 24;
                    RepeatCount = 0;
                    
                    TestDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 42, 6, false);
                    TestDate.Name = "TestDate";
                    TestDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    TestDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    TestDate.TextFont.Name = "Arial Narrow";
                    TestDate.TextFont.Size = 9;
                    TestDate.TextFont.CharSet = 162;
                    TestDate.Value = @"{#WORKLISTDATE#}";

                    TestProcedure = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 1, 153, 6, false);
                    TestProcedure.Name = "TestProcedure";
                    TestProcedure.FieldType = ReportFieldTypeEnum.ftVariable;
                    TestProcedure.TextFont.Name = "Arial Narrow";
                    TestProcedure.TextFont.Size = 9;
                    TestProcedure.TextFont.CharSet = 162;
                    TestProcedure.Value = @"{#PROCEDURENAME#}";

                    TestResault = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 1, 198, 6, false);
                    TestResault.Name = "TestResault";
                    TestResault.FieldType = ReportFieldTypeEnum.ftVariable;
                    TestResault.TextFont.Name = "Arial Narrow";
                    TestResault.TextFont.Size = 9;
                    TestResault.TextFont.CharSet = 162;
                    TestResault.Value = @"";

                    REPORT = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 43, 7, 209, 20, false);
                    REPORT.Name = "REPORT";
                    REPORT.Value = @"";

                    PROCEDUREOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 1, 227, 6, false);
                    PROCEDUREOBJECTID.Name = "PROCEDUREOBJECTID";
                    PROCEDUREOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    PROCEDUREOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREOBJECTID.MultiLine = EvetHayirEnum.ehEvet;
                    PROCEDUREOBJECTID.TextFont.Name = "Arial Narrow";
                    PROCEDUREOBJECTID.TextFont.Size = 9;
                    PROCEDUREOBJECTID.TextFont.CharSet = 162;
                    PROCEDUREOBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SubActionProcedure.GetExaminationTestListNQL_Class dataset_GetExaminationTestListNQL = ParentGroup.rsGroup.GetCurrentRecord<SubActionProcedure.GetExaminationTestListNQL_Class>(0);
                    TestDate.CalcValue = (dataset_GetExaminationTestListNQL != null ? Globals.ToStringCore(dataset_GetExaminationTestListNQL.WorkListDate) : "");
                    TestProcedure.CalcValue = (dataset_GetExaminationTestListNQL != null ? Globals.ToStringCore(dataset_GetExaminationTestListNQL.Procedurename) : "");
                    TestResault.CalcValue = @"";
                    REPORT.CalcValue = REPORT.Value;
                    PROCEDUREOBJECTID.CalcValue = (dataset_GetExaminationTestListNQL != null ? Globals.ToStringCore(dataset_GetExaminationTestListNQL.ObjectID) : "");
                    return new TTReportObject[] { TestDate,TestProcedure,TestResault,REPORT,PROCEDUREOBJECTID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string objectID = this.PROCEDUREOBJECTID.CalcValue;
            if(!string.IsNullOrEmpty(objectID))
            {
                TTObjectContext objectContext = new TTObjectContext(true);
                SubActionProcedure testProcedure = (SubActionProcedure)objectContext.GetObject(new Guid(objectID),"SubActionProcedure");
                if (testProcedure is GeneticTest)
                {
                    if(((GeneticTest)testProcedure).Genetic.Report != null)
                        this.REPORT.Value = ((GeneticTest)testProcedure).Genetic.Report.ToString();
                }
                else if (testProcedure is NuclearMedicineTest)
                {
                    if(((NuclearMedicineTest)testProcedure).NuclearMedicine.Report != null)
                        this.REPORT.Value = ((NuclearMedicineTest)testProcedure).NuclearMedicine.Report.ToString();
                }
                else if (testProcedure is LaboratoryProcedure)
                {
                    if(((LaboratoryProcedure)testProcedure).Result != null)
                        this.TestResault.CalcValue = ((LaboratoryProcedure)testProcedure).Result.ToString();
                    
                }
                //TODO ASLI
                /*else if (testProcedure is Pathology)
                {
                    string patReports = "Makroskopi Raporu\r\n" + TTObjectClasses.Common.GetTextOfRTFString(((Pathology)testProcedure).PathologyRequest.ReportMacroscopi) + "\r\n";
                    patReports += "Mikroskopi Raporu\r\n" + TTObjectClasses.Common.GetTextOfRTFString(((Pathology)testProcedure).PathologyRequest.ReportMicroscopi) + "\r\n";
                    patReports += "Doku İşlemi\r\n" + TTObjectClasses.Common.GetTextOfRTFString(((Pathology)testProcedure).PathologyRequest.ReportTissueProcedure) + "\r\n";
                    patReports += "Ek İşlemler\r\n" + TTObjectClasses.Common.GetTextOfRTFString(((Pathology)testProcedure).PathologyRequest.ReportAdditionalOperation) + "\r\n";
                    this.REPORT.Value = TTObjectClasses.Common.GetRTFOfTextString(patReports);
                }*/
                else if (testProcedure is RadiologyTest)
                {
                    if(((RadiologyTest)testProcedure).Report != null)
                        this.REPORT.Value = ((RadiologyTest)testProcedure).Report.ToString();
                }
                
            }
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

        public ExaminationTestListReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Protokol No", @"", false, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("f1afb241-e28f-4f1a-84a3-e7fe12256626");
            reportParameter = Parameters.Add("TESTOBJECTIDS", "", "TetkikList", @"", true, true, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("TESTOBJECTIDS"))
                _runtimeParameters.TESTOBJECTIDS = (List<string>)parameters["TESTOBJECTIDS"];
            Name = "EXAMINATIONTESTLISTREPORT";
            Caption = "Tetkik Listesi";
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