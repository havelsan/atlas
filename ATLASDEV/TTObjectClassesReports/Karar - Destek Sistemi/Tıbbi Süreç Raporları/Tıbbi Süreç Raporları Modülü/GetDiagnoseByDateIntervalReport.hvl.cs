
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
    /// Tanıya Göre Hasta Listesi
    /// </summary>
    public partial class GetDiagnoseByDateIntervalReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? DIAGNOSE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? DOCTOR = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? MASTERRESOURCE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public GetDiagnoseByDateIntervalReport MyParentReport
            {
                get { return (GetDiagnoseByDateIntervalReport)ParentReport; }
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
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
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
                public GetDiagnoseByDateIntervalReport MyParentReport
                {
                    get { return (GetDiagnoseByDateIntervalReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField4;
                public TTReportField NewField14;
                public TTReportField NewField141; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 44;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 10, 150, 18, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Size = 14;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"TANIYA GÖRE HASTA LİSTESİ";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 39, 43, 44, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"TC KİMLİK NO";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 39, 82, 44, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"İSİM / SOYİSİM";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 39, 181, 44, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"TANI";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 39, 206, 44, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"TANI TARİHİ";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 39, 20, 44, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"SIRA NO";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 39, 92, 44, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"YAŞ";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 39, 109, 44, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"CİNSİYET";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField141.CalcValue = NewField141.Value;
                    return new TTReportObject[] { NewField1,NewField2,NewField3,NewField5,NewField6,NewField4,NewField14,NewField141};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public GetDiagnoseByDateIntervalReport MyParentReport
                {
                    get { return (GetDiagnoseByDateIntervalReport)ParentReport; }
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
            public GetDiagnoseByDateIntervalReport MyParentReport
            {
                get { return (GetDiagnoseByDateIntervalReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DIAGNOSECODE { get {return Body().DIAGNOSECODE;} }
            public TTReportField DIAGNOSEDATE { get {return Body().DIAGNOSEDATE;} }
            public TTReportField PATIENTNAME { get {return Body().PATIENTNAME;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField AGE { get {return Body().AGE;} }
            public TTReportField GENDER { get {return Body().GENDER;} }
            public TTReportField RESOURCE { get {return Body().RESOURCE;} }
            public TTReportField GENDERENUM { get {return Body().GENDERENUM;} }
            public TTReportField BIRTHDATE { get {return Body().BIRTHDATE;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
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
                list[0] = new TTReportNqlData<DiagnosisGrid.GetDiagnosisByDateInterval_Class>("GetDiagnosisByDateInterval", DiagnosisGrid.GetDiagnosisByDateInterval((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.DIAGNOSE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.DOCTOR),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MASTERRESOURCE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE)));
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
                public GetDiagnoseByDateIntervalReport MyParentReport
                {
                    get { return (GetDiagnoseByDateIntervalReport)ParentReport; }
                }
                
                public TTReportField DIAGNOSECODE;
                public TTReportField DIAGNOSEDATE;
                public TTReportField PATIENTNAME;
                public TTReportField TCKIMLIKNO;
                public TTReportField SIRANO;
                public TTReportField AGE;
                public TTReportField GENDER;
                public TTReportField RESOURCE;
                public TTReportField GENDERENUM;
                public TTReportField BIRTHDATE;
                public TTReportShape NewLine1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 13;
                    RepeatCount = 0;
                    
                    DIAGNOSECODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 1, 181, 12, false);
                    DIAGNOSECODE.Name = "DIAGNOSECODE";
                    DIAGNOSECODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSECODE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIAGNOSECODE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIAGNOSECODE.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSECODE.NoClip = EvetHayirEnum.ehEvet;
                    DIAGNOSECODE.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSECODE.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSECODE.TextFont.CharSet = 162;
                    DIAGNOSECODE.Value = @"{#DIAGNOSECODE#} / {#DIAGNOSENAME#}";

                    DIAGNOSEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 1, 206, 12, false);
                    DIAGNOSEDATE.Name = "DIAGNOSEDATE";
                    DIAGNOSEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSEDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIAGNOSEDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIAGNOSEDATE.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSEDATE.NoClip = EvetHayirEnum.ehEvet;
                    DIAGNOSEDATE.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSEDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSEDATE.TextFont.CharSet = 162;
                    DIAGNOSEDATE.Value = @"{#DIAGNOSEDATE#}";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 1, 82, 7, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PATIENTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PATIENTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTNAME.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTNAME.TextFont.CharSet = 162;
                    PATIENTNAME.Value = @"{#PATIENTNAME#} {#PATIENTSURNAME#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 43, 7, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TCKIMLIKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCKIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.NoClip = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#TCKIMLIKNO#}";

                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 20, 7, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@counter@}";

                    AGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 1, 92, 7, false);
                    AGE.Name = "AGE";
                    AGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AGE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AGE.MultiLine = EvetHayirEnum.ehEvet;
                    AGE.NoClip = EvetHayirEnum.ehEvet;
                    AGE.WordBreak = EvetHayirEnum.ehEvet;
                    AGE.ExpandTabs = EvetHayirEnum.ehEvet;
                    AGE.TextFont.CharSet = 162;
                    AGE.Value = @"";

                    GENDER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 1, 109, 7, false);
                    GENDER.Name = "GENDER";
                    GENDER.FieldType = ReportFieldTypeEnum.ftVariable;
                    GENDER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GENDER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GENDER.MultiLine = EvetHayirEnum.ehEvet;
                    GENDER.NoClip = EvetHayirEnum.ehEvet;
                    GENDER.WordBreak = EvetHayirEnum.ehEvet;
                    GENDER.ExpandTabs = EvetHayirEnum.ehEvet;
                    GENDER.TextFont.CharSet = 162;
                    GENDER.Value = @"";

                    RESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 7, 109, 12, false);
                    RESOURCE.Name = "RESOURCE";
                    RESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESOURCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RESOURCE.MultiLine = EvetHayirEnum.ehEvet;
                    RESOURCE.NoClip = EvetHayirEnum.ehEvet;
                    RESOURCE.WordBreak = EvetHayirEnum.ehEvet;
                    RESOURCE.ExpandTabs = EvetHayirEnum.ehEvet;
                    RESOURCE.TextFont.CharSet = 162;
                    RESOURCE.Value = @"{#NAME#}";

                    GENDERENUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 7, 251, 12, false);
                    GENDERENUM.Name = "GENDERENUM";
                    GENDERENUM.Visible = EvetHayirEnum.ehHayir;
                    GENDERENUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    GENDERENUM.Value = @"{#SEX#}";

                    BIRTHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 14, 251, 19, false);
                    BIRTHDATE.Name = "BIRTHDATE";
                    BIRTHDATE.Visible = EvetHayirEnum.ehHayir;
                    BIRTHDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHDATE.Value = @"{#BIRTHDATE#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 12, 206, 12, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DiagnosisGrid.GetDiagnosisByDateInterval_Class dataset_GetDiagnosisByDateInterval = ParentGroup.rsGroup.GetCurrentRecord<DiagnosisGrid.GetDiagnosisByDateInterval_Class>(0);
                    DIAGNOSECODE.CalcValue = (dataset_GetDiagnosisByDateInterval != null ? Globals.ToStringCore(dataset_GetDiagnosisByDateInterval.Diagnosecode) : "") + @" / " + (dataset_GetDiagnosisByDateInterval != null ? Globals.ToStringCore(dataset_GetDiagnosisByDateInterval.Diagnosename) : "");
                    DIAGNOSEDATE.CalcValue = (dataset_GetDiagnosisByDateInterval != null ? Globals.ToStringCore(dataset_GetDiagnosisByDateInterval.DiagnoseDate) : "");
                    PATIENTNAME.CalcValue = (dataset_GetDiagnosisByDateInterval != null ? Globals.ToStringCore(dataset_GetDiagnosisByDateInterval.Patientname) : "") + @" " + (dataset_GetDiagnosisByDateInterval != null ? Globals.ToStringCore(dataset_GetDiagnosisByDateInterval.Patientsurname) : "");
                    TCKIMLIKNO.CalcValue = (dataset_GetDiagnosisByDateInterval != null ? Globals.ToStringCore(dataset_GetDiagnosisByDateInterval.Tckimlikno) : "");
                    SIRANO.CalcValue = ParentGroup.Counter.ToString();
                    AGE.CalcValue = @"";
                    GENDER.CalcValue = @"";
                    RESOURCE.CalcValue = (dataset_GetDiagnosisByDateInterval != null ? Globals.ToStringCore(dataset_GetDiagnosisByDateInterval.Name) : "");
                    GENDERENUM.CalcValue = (dataset_GetDiagnosisByDateInterval != null ? Globals.ToStringCore(dataset_GetDiagnosisByDateInterval.Sex) : "");
                    BIRTHDATE.CalcValue = (dataset_GetDiagnosisByDateInterval != null ? Globals.ToStringCore(dataset_GetDiagnosisByDateInterval.BirthDate) : "");
                    return new TTReportObject[] { DIAGNOSECODE,DIAGNOSEDATE,PATIENTNAME,TCKIMLIKNO,SIRANO,AGE,GENDER,RESOURCE,GENDERENUM,BIRTHDATE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(GENDERENUM.CalcValue == "Male")
                GENDER.CalcValue = "Erkek";
            else if(GENDERENUM.CalcValue == "Female")
                GENDER.CalcValue = "Kadın";
            else
                GENDER.CalcValue = "Belirlenmemiş";
            
            if(!string.IsNullOrEmpty(BIRTHDATE.CalcValue))
            {
                DateTime birthDate = Convert.ToDateTime(BIRTHDATE.CalcValue);
                AGE.CalcValue = (TTObjectClasses.Common.RecTime().Year - birthDate.Year).ToString();
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

        public GetDiagnoseByDateIntervalReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi :", @"", false, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi :", @"", false, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("DIAGNOSE", "00000000-0000-0000-0000-000000000000", "Tanı / Tanı Kodu :", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("f438d7e5-bd84-472a-92ef-5b63f94cc57e");
            reportParameter = Parameters.Add("DOCTOR", "00000000-0000-0000-0000-000000000000", "Doktor :", @"", false, false, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter = Parameters.Add("MASTERRESOURCE", "00000000-0000-0000-0000-000000000000", "Havale Eden :", @"", false, false, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("DIAGNOSE"))
                _runtimeParameters.DIAGNOSE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["DIAGNOSE"]);
            if (parameters.ContainsKey("DOCTOR"))
                _runtimeParameters.DOCTOR = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["DOCTOR"]);
            if (parameters.ContainsKey("MASTERRESOURCE"))
                _runtimeParameters.MASTERRESOURCE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MASTERRESOURCE"]);
            Name = "GETDIAGNOSEBYDATEINTERVALREPORT";
            Caption = "Tanıya Göre Hasta Listesi";
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