
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
    public partial class PathologyStatisticsReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string Diagnosis = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string MatPrtNoString = (string)TTObjectDefManager.Instance.DataTypes["String15"].ConvertValue("");
            public string IdentificationCardNo = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
            public string SnomedDiagnosis = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public DateTime? StartDate = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? EndDate = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public string ResponsibleDoctor = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string SpecialDoctor = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string AssistantDoctor = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string ConsultantDoctor = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string Category = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string Localization = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public int? ASSISTANTDOCTOR_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? SPECIALDOCTOR_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? RESPONSIBLEDOCTOR_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? DIAGNOSIS_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? SNOMEDDIAGNOSIS_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? MATPRTNO_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? TEST_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? CARDNO_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public PathologyStatisticsReport MyParentReport
            {
                get { return (PathologyStatisticsReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField lblHeader { get {return Header().lblHeader;} }
            public TTReportField lblNameSurname { get {return Header().lblNameSurname;} }
            public TTReportField lblIdentificationCardNo { get {return Header().lblIdentificationCardNo;} }
            public TTReportField lblMatPrtNo { get {return Header().lblMatPrtNo;} }
            public TTReportField lblDiagnosis { get {return Header().lblDiagnosis;} }
            public TTReportField lblSnomedDiagnosis { get {return Header().lblSnomedDiagnosis;} }
            public TTReportField lblDate { get {return Header().lblDate;} }
            public TTReportField lblResponsibleDoctor { get {return Header().lblResponsibleDoctor;} }
            public TTReportField lblSpecialDoctor { get {return Header().lblSpecialDoctor;} }
            public TTReportField lblAssistantDoctor { get {return Header().lblAssistantDoctor;} }
            public TTReportField lblCatergory { get {return Header().lblCatergory;} }
            public TTReportField lblTest { get {return Header().lblTest;} }
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
                public PathologyStatisticsReport MyParentReport
                {
                    get { return (PathologyStatisticsReport)ParentReport; }
                }
                
                public TTReportField lblHeader;
                public TTReportField lblNameSurname;
                public TTReportField lblIdentificationCardNo;
                public TTReportField lblMatPrtNo;
                public TTReportField lblDiagnosis;
                public TTReportField lblSnomedDiagnosis;
                public TTReportField lblDate;
                public TTReportField lblResponsibleDoctor;
                public TTReportField lblSpecialDoctor;
                public TTReportField lblAssistantDoctor;
                public TTReportField lblCatergory;
                public TTReportField lblTest; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 39;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    lblHeader = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 8, 204, 16, false);
                    lblHeader.Name = "lblHeader";
                    lblHeader.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblHeader.TextFont.Name = "Arial";
                    lblHeader.TextFont.Size = 12;
                    lblHeader.TextFont.Bold = true;
                    lblHeader.TextFont.Underline = true;
                    lblHeader.TextFont.CharSet = 162;
                    lblHeader.Value = @"PATOLOJİ  İSTATİSTİK  RAPORU";

                    lblNameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 31, 30, 36, false);
                    lblNameSurname.Name = "lblNameSurname";
                    lblNameSurname.TextFont.Size = 9;
                    lblNameSurname.TextFont.Bold = true;
                    lblNameSurname.TextFont.CharSet = 162;
                    lblNameSurname.Value = @"Hasta Adı Soyadı";

                    lblIdentificationCardNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 31, 51, 36, false);
                    lblIdentificationCardNo.Name = "lblIdentificationCardNo";
                    lblIdentificationCardNo.TextFont.Size = 9;
                    lblIdentificationCardNo.TextFont.Bold = true;
                    lblIdentificationCardNo.TextFont.CharSet = 162;
                    lblIdentificationCardNo.Value = @"TC Kimlik No";

                    lblMatPrtNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 31, 79, 36, false);
                    lblMatPrtNo.Name = "lblMatPrtNo";
                    lblMatPrtNo.TextFont.Size = 9;
                    lblMatPrtNo.TextFont.Bold = true;
                    lblMatPrtNo.TextFont.CharSet = 162;
                    lblMatPrtNo.Value = @"Materyal Protokol No";

                    lblDiagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 31, 154, 36, false);
                    lblDiagnosis.Name = "lblDiagnosis";
                    lblDiagnosis.TextFont.Size = 9;
                    lblDiagnosis.TextFont.Bold = true;
                    lblDiagnosis.TextFont.CharSet = 162;
                    lblDiagnosis.Value = @"Vaka Tanıları";

                    lblSnomedDiagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 31, 187, 36, false);
                    lblSnomedDiagnosis.Name = "lblSnomedDiagnosis";
                    lblSnomedDiagnosis.TextFont.Size = 9;
                    lblSnomedDiagnosis.TextFont.Bold = true;
                    lblSnomedDiagnosis.TextFont.CharSet = 162;
                    lblSnomedDiagnosis.Value = @"Snomed Tanıları";

                    lblDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 31, 212, 36, false);
                    lblDate.Name = "lblDate";
                    lblDate.TextFont.Size = 9;
                    lblDate.TextFont.Bold = true;
                    lblDate.TextFont.CharSet = 162;
                    lblDate.Value = @"İşlem Tarihi";

                    lblResponsibleDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 31, 241, 36, false);
                    lblResponsibleDoctor.Name = "lblResponsibleDoctor";
                    lblResponsibleDoctor.TextFont.Size = 9;
                    lblResponsibleDoctor.TextFont.Bold = true;
                    lblResponsibleDoctor.TextFont.CharSet = 162;
                    lblResponsibleDoctor.Value = @"Sorumlu Tabip";

                    lblSpecialDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 31, 268, 36, false);
                    lblSpecialDoctor.Name = "lblSpecialDoctor";
                    lblSpecialDoctor.TextFont.Size = 9;
                    lblSpecialDoctor.TextFont.Bold = true;
                    lblSpecialDoctor.TextFont.CharSet = 162;
                    lblSpecialDoctor.Value = @"Uzman Tabip";

                    lblAssistantDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 269, 31, 295, 36, false);
                    lblAssistantDoctor.Name = "lblAssistantDoctor";
                    lblAssistantDoctor.TextFont.Size = 9;
                    lblAssistantDoctor.TextFont.Bold = true;
                    lblAssistantDoctor.TextFont.CharSet = 162;
                    lblAssistantDoctor.Value = @"Yardımcı Tabip";

                    lblCatergory = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 31, 93, 36, false);
                    lblCatergory.Name = "lblCatergory";
                    lblCatergory.TextFont.Size = 9;
                    lblCatergory.TextFont.Bold = true;
                    lblCatergory.TextFont.CharSet = 162;
                    lblCatergory.Value = @"Kategori";

                    lblTest = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 31, 121, 36, false);
                    lblTest.Name = "lblTest";
                    lblTest.TextFont.Size = 9;
                    lblTest.TextFont.Bold = true;
                    lblTest.TextFont.CharSet = 162;
                    lblTest.Value = @"İşlem";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    lblHeader.CalcValue = lblHeader.Value;
                    lblNameSurname.CalcValue = lblNameSurname.Value;
                    lblIdentificationCardNo.CalcValue = lblIdentificationCardNo.Value;
                    lblMatPrtNo.CalcValue = lblMatPrtNo.Value;
                    lblDiagnosis.CalcValue = lblDiagnosis.Value;
                    lblSnomedDiagnosis.CalcValue = lblSnomedDiagnosis.Value;
                    lblDate.CalcValue = lblDate.Value;
                    lblResponsibleDoctor.CalcValue = lblResponsibleDoctor.Value;
                    lblSpecialDoctor.CalcValue = lblSpecialDoctor.Value;
                    lblAssistantDoctor.CalcValue = lblAssistantDoctor.Value;
                    lblCatergory.CalcValue = lblCatergory.Value;
                    lblTest.CalcValue = lblTest.Value;
                    return new TTReportObject[] { lblHeader,lblNameSurname,lblIdentificationCardNo,lblMatPrtNo,lblDiagnosis,lblSnomedDiagnosis,lblDate,lblResponsibleDoctor,lblSpecialDoctor,lblAssistantDoctor,lblCatergory,lblTest};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    if (((PathologyStatisticsReport)ParentReport).RuntimeParameters.AssistantDoctor == null)
                ((PathologyStatisticsReport)ParentReport).RuntimeParameters.ASSISTANTDOCTOR_FLAG = 0;
            else
                ((PathologyStatisticsReport)ParentReport).RuntimeParameters.ASSISTANTDOCTOR_FLAG = 1;
            
            if (((PathologyStatisticsReport)ParentReport).RuntimeParameters.SpecialDoctor == null)
                ((PathologyStatisticsReport)ParentReport).RuntimeParameters.SPECIALDOCTOR_FLAG = 0;
            else
                ((PathologyStatisticsReport)ParentReport).RuntimeParameters.SPECIALDOCTOR_FLAG = 1;
            
            if (((PathologyStatisticsReport)ParentReport).RuntimeParameters.ResponsibleDoctor == null)
                ((PathologyStatisticsReport)ParentReport).RuntimeParameters.RESPONSIBLEDOCTOR_FLAG = 0;
            else
                ((PathologyStatisticsReport)ParentReport).RuntimeParameters.RESPONSIBLEDOCTOR_FLAG = 1;
            
            if (((PathologyStatisticsReport)ParentReport).RuntimeParameters.Diagnosis == null)
                ((PathologyStatisticsReport)ParentReport).RuntimeParameters.DIAGNOSIS_FLAG = 0;
            else
                ((PathologyStatisticsReport)ParentReport).RuntimeParameters.DIAGNOSIS_FLAG = 1;
            
            if (((PathologyStatisticsReport)ParentReport).RuntimeParameters.SnomedDiagnosis == null)
                ((PathologyStatisticsReport)ParentReport).RuntimeParameters.SNOMEDDIAGNOSIS_FLAG = 0;
            else
                ((PathologyStatisticsReport)ParentReport).RuntimeParameters.SNOMEDDIAGNOSIS_FLAG = 1;
            
            if (((PathologyStatisticsReport)ParentReport).RuntimeParameters.MatPrtNoString == null)
                ((PathologyStatisticsReport)ParentReport).RuntimeParameters.MATPRTNO_FLAG = 0;
            else
                ((PathologyStatisticsReport)ParentReport).RuntimeParameters.MATPRTNO_FLAG = 1;
           //TODO ASLI 
           // if (((PathologyStatisticsReport)ParentReport).RuntimeParameters.Test == null)
           //     ((PathologyStatisticsReport)ParentReport).RuntimeParameters.TEST_FLAG = 0;
           // else
           //     ((PathologyStatisticsReport)ParentReport).RuntimeParameters.TEST_FLAG = 1;
            
            if (((PathologyStatisticsReport)ParentReport).RuntimeParameters.IdentificationCardNo == null)
                ((PathologyStatisticsReport)ParentReport).RuntimeParameters.CARDNO_FLAG = 0;
            else
                ((PathologyStatisticsReport)ParentReport).RuntimeParameters.CARDNO_FLAG = 1;
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public PathologyStatisticsReport MyParentReport
                {
                    get { return (PathologyStatisticsReport)ParentReport; }
                }
                 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public PathologyStatisticsReport MyParentReport
            {
                get { return (PathologyStatisticsReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NameSurname { get {return Body().NameSurname;} }
            public TTReportField IdentificationCardNo { get {return Body().IdentificationCardNo;} }
            public TTReportField MatPrtNo { get {return Body().MatPrtNo;} }
            public TTReportField Category { get {return Body().Category;} }
            public TTReportField Test { get {return Body().Test;} }
            public TTReportField Diagnosis { get {return Body().Diagnosis;} }
            public TTReportField SnomedDiagnosis { get {return Body().SnomedDiagnosis;} }
            public TTReportField Date { get {return Body().Date;} }
            public TTReportField ResponsibleDoctor { get {return Body().ResponsibleDoctor;} }
            public TTReportField SpecialDoctor { get {return Body().SpecialDoctor;} }
            public TTReportField AssistantDoctor { get {return Body().AssistantDoctor;} }
            public TTReportField OBJID { get {return Body().OBJID;} }
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
                public PathologyStatisticsReport MyParentReport
                {
                    get { return (PathologyStatisticsReport)ParentReport; }
                }
                
                public TTReportField NameSurname;
                public TTReportField IdentificationCardNo;
                public TTReportField MatPrtNo;
                public TTReportField Category;
                public TTReportField Test;
                public TTReportField Diagnosis;
                public TTReportField SnomedDiagnosis;
                public TTReportField Date;
                public TTReportField ResponsibleDoctor;
                public TTReportField SpecialDoctor;
                public TTReportField AssistantDoctor;
                public TTReportField OBJID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 19;
                    RepeatCount = 0;
                    
                    NameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 6, 30, 11, false);
                    NameSurname.Name = "NameSurname";
                    NameSurname.TextFont.Size = 9;
                    NameSurname.TextFont.Bold = true;
                    NameSurname.TextFont.CharSet = 162;
                    NameSurname.Value = @"";

                    IdentificationCardNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 6, 51, 11, false);
                    IdentificationCardNo.Name = "IdentificationCardNo";
                    IdentificationCardNo.TextFont.Size = 9;
                    IdentificationCardNo.TextFont.Bold = true;
                    IdentificationCardNo.TextFont.CharSet = 162;
                    IdentificationCardNo.Value = @"";

                    MatPrtNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 6, 79, 11, false);
                    MatPrtNo.Name = "MatPrtNo";
                    MatPrtNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    MatPrtNo.TextFont.Size = 9;
                    MatPrtNo.TextFont.Bold = true;
                    MatPrtNo.TextFont.CharSet = 162;
                    MatPrtNo.Value = @"";

                    Category = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 6, 93, 11, false);
                    Category.Name = "Category";
                    Category.TextFont.Size = 9;
                    Category.TextFont.Bold = true;
                    Category.TextFont.CharSet = 162;
                    Category.Value = @"";

                    Test = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 6, 121, 11, false);
                    Test.Name = "Test";
                    Test.TextFont.Size = 9;
                    Test.TextFont.Bold = true;
                    Test.TextFont.CharSet = 162;
                    Test.Value = @"";

                    Diagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 6, 154, 11, false);
                    Diagnosis.Name = "Diagnosis";
                    Diagnosis.TextFont.Size = 9;
                    Diagnosis.TextFont.Bold = true;
                    Diagnosis.TextFont.CharSet = 162;
                    Diagnosis.Value = @"";

                    SnomedDiagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 6, 187, 11, false);
                    SnomedDiagnosis.Name = "SnomedDiagnosis";
                    SnomedDiagnosis.TextFont.Size = 9;
                    SnomedDiagnosis.TextFont.Bold = true;
                    SnomedDiagnosis.TextFont.CharSet = 162;
                    SnomedDiagnosis.Value = @"";

                    Date = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 6, 212, 11, false);
                    Date.Name = "Date";
                    Date.FieldType = ReportFieldTypeEnum.ftVariable;
                    Date.TextFont.Size = 9;
                    Date.TextFont.Bold = true;
                    Date.TextFont.CharSet = 162;
                    Date.Value = @"";

                    ResponsibleDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 6, 241, 11, false);
                    ResponsibleDoctor.Name = "ResponsibleDoctor";
                    ResponsibleDoctor.TextFont.Size = 9;
                    ResponsibleDoctor.TextFont.Bold = true;
                    ResponsibleDoctor.TextFont.CharSet = 162;
                    ResponsibleDoctor.Value = @"";

                    SpecialDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 6, 268, 11, false);
                    SpecialDoctor.Name = "SpecialDoctor";
                    SpecialDoctor.TextFont.Size = 9;
                    SpecialDoctor.TextFont.Bold = true;
                    SpecialDoctor.TextFont.CharSet = 162;
                    SpecialDoctor.Value = @"";

                    AssistantDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 269, 6, 295, 11, false);
                    AssistantDoctor.Name = "AssistantDoctor";
                    AssistantDoctor.TextFont.Size = 9;
                    AssistantDoctor.TextFont.Bold = true;
                    AssistantDoctor.TextFont.CharSet = 162;
                    AssistantDoctor.Value = @"";

                    OBJID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 309, 6, 335, 11, false);
                    OBJID.Name = "OBJID";
                    OBJID.Visible = EvetHayirEnum.ehHayir;
                    OBJID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJID.TextFont.Size = 9;
                    OBJID.TextFont.Bold = true;
                    OBJID.TextFont.CharSet = 162;
                    OBJID.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NameSurname.CalcValue = NameSurname.Value;
                    IdentificationCardNo.CalcValue = IdentificationCardNo.Value;
                    MatPrtNo.CalcValue = @"";
                    Category.CalcValue = Category.Value;
                    Test.CalcValue = Test.Value;
                    Diagnosis.CalcValue = Diagnosis.Value;
                    SnomedDiagnosis.CalcValue = SnomedDiagnosis.Value;
                    Date.CalcValue = @"";
                    ResponsibleDoctor.CalcValue = ResponsibleDoctor.Value;
                    SpecialDoctor.CalcValue = SpecialDoctor.Value;
                    AssistantDoctor.CalcValue = AssistantDoctor.Value;
                    OBJID.CalcValue = @"";
                    return new TTReportObject[] { NameSurname,IdentificationCardNo,MatPrtNo,Category,Test,Diagnosis,SnomedDiagnosis,Date,ResponsibleDoctor,SpecialDoctor,AssistantDoctor,OBJID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //TODO ASLI                                                                                                            
            /*TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.OBJID.CalcValue;
            Pathology pathologyTest = (Pathology)context.GetObject(new Guid(sObjectID),"Pathology");
            Patient patient = pathologyTest.PathologyRequest.Episode.Patient;
            PathologyTestDefinition testDef = (PathologyTestDefinition)pathologyTest.ProcedureObject;
            //PathologyTestCategoryDefinition category = testDef.TestCategory;
            this.NameSurname.Value = patient.Name + " " + patient.Surname;
            this.IdentificationCardNo.Value = patient.IdentificationCardNo;
            this.MatPrtNo.Value = pathologyTest.MatPrtNoString;
            this.Category.Value = ((PathologyTestCategoryDefinition)testDef.TestCategory).Name;
            this.Test.Value = testDef.Name;
            //this.Diagnosis.Value = 
            //this.SnomedDiagnosis.Value = 
            
            this.ResponsibleDoctor.Value = pathologyTest.ResponsibleDoctor != null ? pathologyTest.ResponsibleDoctor.Name : "";
            this.SpecialDoctor.Value = pathologyTest.SpecialDoctor != null ? pathologyTest.SpecialDoctor.Name : "";
            this.AssistantDoctor.Value = pathologyTest.AssistantDoctor != null ? pathologyTest.AssistantDoctor.Name : "";
             */
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

        public PathologyStatisticsReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("Diagnosis", "", "Vaka Tanıları", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("f438d7e5-bd84-472a-92ef-5b63f94cc57e");
            reportParameter = Parameters.Add("MatPrtNoString", "", "Materyal Protokol No", @"", false, true, false, new Guid("286becbe-2627-4308-8246-33610e93c094"));
            reportParameter = Parameters.Add("IdentificationCardNo", "", "Nüfus Cüzdanı No", @"", false, true, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
            reportParameter = Parameters.Add("SnomedDiagnosis", "", "Snomed Tanı", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("79f99eac-a0ba-40fc-a259-27983d49d7dc");
            reportParameter = Parameters.Add("StartDate", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("EndDate", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ResponsibleDoctor", "", "Sorumlu Tabip", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter = Parameters.Add("SpecialDoctor", "", "Uzman Tabip", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter = Parameters.Add("AssistantDoctor", "", "Yardımcı Tabip", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter = Parameters.Add("ConsultantDoctor", "", "Konsultant Doktor", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter = Parameters.Add("Category", "", "Kategori", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("66e1577b-dc04-4b24-b032-3f5f3bcbf296");
            reportParameter = Parameters.Add("Localization", "", "Lokalizasyon", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("afa772d8-94c2-4ba5-8efc-c696cc992345");
            reportParameter = Parameters.Add("ASSISTANTDOCTOR_FLAG", "", "ASSISTANTDOCTOR_FLAG", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("SPECIALDOCTOR_FLAG", "", "SPECIALDOCTOR_FLAG", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("RESPONSIBLEDOCTOR_FLAG", "", "RESPONSIBLEDOCTOR_FLAG", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("DIAGNOSIS_FLAG", "", "DIAGNOSIS_FLAG", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("SNOMEDDIAGNOSIS_FLAG", "", "SNOMEDDIAGNOSIS_FLAG", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("MATPRTNO_FLAG", "", "MATPRTNO_FLAG", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("TEST_FLAG", "", "TEST_FLAG", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("CARDNO_FLAG", "", "CARDNO_FLAG", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("Diagnosis"))
                _runtimeParameters.Diagnosis = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["Diagnosis"]);
            if (parameters.ContainsKey("MatPrtNoString"))
                _runtimeParameters.MatPrtNoString = (string)TTObjectDefManager.Instance.DataTypes["String15"].ConvertValue(parameters["MatPrtNoString"]);
            if (parameters.ContainsKey("IdentificationCardNo"))
                _runtimeParameters.IdentificationCardNo = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["IdentificationCardNo"]);
            if (parameters.ContainsKey("SnomedDiagnosis"))
                _runtimeParameters.SnomedDiagnosis = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["SnomedDiagnosis"]);
            if (parameters.ContainsKey("StartDate"))
                _runtimeParameters.StartDate = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["StartDate"]);
            if (parameters.ContainsKey("EndDate"))
                _runtimeParameters.EndDate = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["EndDate"]);
            if (parameters.ContainsKey("ResponsibleDoctor"))
                _runtimeParameters.ResponsibleDoctor = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["ResponsibleDoctor"]);
            if (parameters.ContainsKey("SpecialDoctor"))
                _runtimeParameters.SpecialDoctor = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["SpecialDoctor"]);
            if (parameters.ContainsKey("AssistantDoctor"))
                _runtimeParameters.AssistantDoctor = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["AssistantDoctor"]);
            if (parameters.ContainsKey("ConsultantDoctor"))
                _runtimeParameters.ConsultantDoctor = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["ConsultantDoctor"]);
            if (parameters.ContainsKey("Category"))
                _runtimeParameters.Category = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["Category"]);
            if (parameters.ContainsKey("Localization"))
                _runtimeParameters.Localization = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["Localization"]);
            if (parameters.ContainsKey("ASSISTANTDOCTOR_FLAG"))
                _runtimeParameters.ASSISTANTDOCTOR_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["ASSISTANTDOCTOR_FLAG"]);
            if (parameters.ContainsKey("SPECIALDOCTOR_FLAG"))
                _runtimeParameters.SPECIALDOCTOR_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["SPECIALDOCTOR_FLAG"]);
            if (parameters.ContainsKey("RESPONSIBLEDOCTOR_FLAG"))
                _runtimeParameters.RESPONSIBLEDOCTOR_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["RESPONSIBLEDOCTOR_FLAG"]);
            if (parameters.ContainsKey("DIAGNOSIS_FLAG"))
                _runtimeParameters.DIAGNOSIS_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["DIAGNOSIS_FLAG"]);
            if (parameters.ContainsKey("SNOMEDDIAGNOSIS_FLAG"))
                _runtimeParameters.SNOMEDDIAGNOSIS_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["SNOMEDDIAGNOSIS_FLAG"]);
            if (parameters.ContainsKey("MATPRTNO_FLAG"))
                _runtimeParameters.MATPRTNO_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["MATPRTNO_FLAG"]);
            if (parameters.ContainsKey("TEST_FLAG"))
                _runtimeParameters.TEST_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["TEST_FLAG"]);
            if (parameters.ContainsKey("CARDNO_FLAG"))
                _runtimeParameters.CARDNO_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["CARDNO_FLAG"]);
            Name = "PATHOLOGYSTATISTICSREPORT";
            Caption = "Patoloji İstatistik Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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