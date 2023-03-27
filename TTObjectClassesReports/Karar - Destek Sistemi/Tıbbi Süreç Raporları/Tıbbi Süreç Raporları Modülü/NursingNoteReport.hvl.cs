
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
    public partial class NursingNoteReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public string MASTERRESOURCE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public List<string> PATIENTS = new List<string>();
            public int? PATIENTCONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class hedGroup : TTReportGroup
        {
            public NursingNoteReport MyParentReport
            {
                get { return (NursingNoteReport)ParentReport; }
            }

            new public hedGroupHeader Header()
            {
                return (hedGroupHeader)_header;
            }

            new public hedGroupFooter Footer()
            {
                return (hedGroupFooter)_footer;
            }

            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField ____Hasta_Adı_Soyadı { get {return Header().____Hasta_Adı_Soyadı;} }
            public TTReportField NotTarihi1 { get {return Header().NotTarihi1;} }
            public TTReportField HastaAdıSoyadı1 { get {return Header().HastaAdıSoyadı1;} }
            public TTReportField HemsirelikNotu { get {return Header().HemsirelikNotu;} }
            public TTReportField DevirTeslim { get {return Header().DevirTeslim;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public hedGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public hedGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new hedGroupHeader(this);
                _footer = new hedGroupFooter(this);

            }

            public partial class hedGroupHeader : TTReportSection
            {
                public NursingNoteReport MyParentReport
                {
                    get { return (NursingNoteReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField XXXXXXBASLIK;
                public TTReportField ____Hasta_Adı_Soyadı;
                public TTReportField NotTarihi1;
                public TTReportField HastaAdıSoyadı1;
                public TTReportField HemsirelikNotu;
                public TTReportField DevirTeslim;
                public TTReportField NewField1; 
                public hedGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 67;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 13, 49, 45, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.TextFont.CharSet = 1;
                    LOGO.Value = @"";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 10, 219, 47, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    ____Hasta_Adı_Soyadı = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 62, 47, 67, false);
                    ____Hasta_Adı_Soyadı.Name = "____Hasta_Adı_Soyadı";
                    ____Hasta_Adı_Soyadı.DrawStyle = DrawStyleConstants.vbSolid;
                    ____Hasta_Adı_Soyadı.TextFont.CharSet = 162;
                    ____Hasta_Adı_Soyadı.Value = @"       Hemşire Adı";

                    NotTarihi1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 62, 74, 67, false);
                    NotTarihi1.Name = "NotTarihi1";
                    NotTarihi1.DrawStyle = DrawStyleConstants.vbSolid;
                    NotTarihi1.TextFont.CharSet = 162;
                    NotTarihi1.Value = @"Not Tarihi";

                    HastaAdıSoyadı1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 62, 124, 67, false);
                    HastaAdıSoyadı1.Name = "HastaAdıSoyadı1";
                    HastaAdıSoyadı1.DrawStyle = DrawStyleConstants.vbSolid;
                    HastaAdıSoyadı1.TextFont.CharSet = 162;
                    HastaAdıSoyadı1.Value = @"Hasta Adı Soyadı";

                    HemsirelikNotu = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 62, 280, 67, false);
                    HemsirelikNotu.Name = "HemsirelikNotu";
                    HemsirelikNotu.DrawStyle = DrawStyleConstants.vbSolid;
                    HemsirelikNotu.TextFont.CharSet = 162;
                    HemsirelikNotu.Value = @"Hemşirelik Notu";

                    DevirTeslim = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 280, 62, 297, 67, false);
                    DevirTeslim.Name = "DevirTeslim";
                    DevirTeslim.DrawStyle = DrawStyleConstants.vbSolid;
                    DevirTeslim.TextFont.CharSet = 162;
                    DevirTeslim.Value = @"Devir Teslim";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 50, 178, 55, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 12;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Hemşire Notu Raporu";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = @"";
                    ____Hasta_Adı_Soyadı.CalcValue = ____Hasta_Adı_Soyadı.Value;
                    NotTarihi1.CalcValue = NotTarihi1.Value;
                    HastaAdıSoyadı1.CalcValue = HastaAdıSoyadı1.Value;
                    HemsirelikNotu.CalcValue = HemsirelikNotu.Value;
                    DevirTeslim.CalcValue = DevirTeslim.Value;
                    NewField1.CalcValue = NewField1.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { LOGO,____Hasta_Adı_Soyadı,NotTarihi1,HastaAdıSoyadı1,HemsirelikNotu,DevirTeslim,NewField1,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region HED HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion HED HEADER_Script
                }
            }
            public partial class hedGroupFooter : TTReportSection
            {
                public NursingNoteReport MyParentReport
                {
                    get { return (NursingNoteReport)ParentReport; }
                }
                 
                public hedGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 38;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public hedGroup hed;

        public partial class PARENTGroup : TTReportGroup
        {
            public NursingNoteReport MyParentReport
            {
                get { return (NursingNoteReport)ParentReport; }
            }

            new public PARENTGroupHeader Header()
            {
                return (PARENTGroupHeader)_header;
            }

            new public PARENTGroupFooter Footer()
            {
                return (PARENTGroupFooter)_footer;
            }

            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public PARENTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARENTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<NursingAppliProgress.GetNursingAppliProgressByPatient_Class>("GetNursingAppliProgressByPatient", NursingAppliProgress.GetNursingAppliProgressByPatient((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MASTERRESOURCE),(List<string>) MyParentReport.RuntimeParameters.PATIENTS,(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.PATIENTCONTROL)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARENTGroupHeader(this);
                _footer = new PARENTGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARENTGroupHeader : TTReportSection
            {
                public NursingNoteReport MyParentReport
                {
                    get { return (NursingNoteReport)ParentReport; }
                }
                 
                public PARENTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARENTGroupFooter : TTReportSection
            {
                public NursingNoteReport MyParentReport
                {
                    get { return (NursingNoteReport)ParentReport; }
                }
                
                public TTReportShape NewLine1; 
                public PARENTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 1, 297, 1, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NursingAppliProgress.GetNursingAppliProgressByPatient_Class dataset_GetNursingAppliProgressByPatient = ParentGroup.rsGroup.GetCurrentRecord<NursingAppliProgress.GetNursingAppliProgressByPatient_Class>(0);
                    return new TTReportObject[] { };
                }
            }

        }

        public PARENTGroup PARENT;

        public partial class MAINGroup : TTReportGroup
        {
            public NursingNoteReport MyParentReport
            {
                get { return (NursingNoteReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField HemsireAdi { get {return Body().HemsireAdi;} }
            public TTReportField FULLNAME { get {return Body().FULLNAME;} }
            public TTReportField NOTTARIHI { get {return Body().NOTTARIHI;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField SURNAME { get {return Body().SURNAME;} }
            public TTReportField satir { get {return Body().satir;} }
            public TTReportField HandoverNoteVar { get {return Body().HandoverNoteVar;} }
            public TTReportField HandoverNote { get {return Body().HandoverNote;} }
            public TTReportField Hemşirelik_Notu1 { get {return Body().Hemşirelik_Notu1;} }
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
                public NursingNoteReport MyParentReport
                {
                    get { return (NursingNoteReport)ParentReport; }
                }
                
                public TTReportField HemsireAdi;
                public TTReportField FULLNAME;
                public TTReportField NOTTARIHI;
                public TTReportField NAME;
                public TTReportField SURNAME;
                public TTReportField satir;
                public TTReportField HandoverNoteVar;
                public TTReportField HandoverNote;
                public TTReportField Hemşirelik_Notu1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    HemsireAdi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 1, 47, 10, false);
                    HemsireAdi.Name = "HemsireAdi";
                    HemsireAdi.FieldType = ReportFieldTypeEnum.ftVariable;
                    HemsireAdi.ObjectDefName = "ResUser";
                    HemsireAdi.DataMember = "NAME";
                    HemsireAdi.TextFont.CharSet = 162;
                    HemsireAdi.Value = @" 
  {#PARENT.APPLICATIONUSER#}";

                    FULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 1, 124, 10, false);
                    FULLNAME.Name = "FULLNAME";
                    FULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME.MultiLine = EvetHayirEnum.ehEvet;
                    FULLNAME.WordBreak = EvetHayirEnum.ehEvet;
                    FULLNAME.TextFont.CharSet = 162;
                    FULLNAME.Value = @" {#PARENT.NAME#} {#PARENT.SURNAME#}";

                    NOTTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 1, 74, 10, false);
                    NOTTARIHI.Name = "NOTTARIHI";
                    NOTTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOTTARIHI.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    NOTTARIHI.TextFont.Size = 9;
                    NOTTARIHI.TextFont.CharSet = 162;
                    NOTTARIHI.Value = @"
  {#PARENT.PROGRESSDATE#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 6, 325, 11, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.TextFont.Name = "Courier New";
                    NAME.TextFont.CharSet = 162;
                    NAME.Value = @"{#PARENT.NAME#}";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 12, 325, 17, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.Visible = EvetHayirEnum.ehHayir;
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.TextFont.Name = "Courier New";
                    SURNAME.TextFont.CharSet = 162;
                    SURNAME.Value = @"{#PARENT.SURNAME#}";

                    satir = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 1, 13, 6, false);
                    satir.Name = "satir";
                    satir.FieldType = ReportFieldTypeEnum.ftVariable;
                    satir.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    satir.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    satir.TextFont.Size = 9;
                    satir.TextFont.CharSet = 162;
                    satir.Value = @"{@counter@}";

                    HandoverNoteVar = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 18, 325, 23, false);
                    HandoverNoteVar.Name = "HandoverNoteVar";
                    HandoverNoteVar.Visible = EvetHayirEnum.ehHayir;
                    HandoverNoteVar.FieldType = ReportFieldTypeEnum.ftVariable;
                    HandoverNoteVar.TextFont.CharSet = 162;
                    HandoverNoteVar.Value = @"{#PARENT.HANDOVERNOTE#}";

                    HandoverNote = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 280, 1, 297, 10, false);
                    HandoverNote.Name = "HandoverNote";
                    HandoverNote.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HandoverNote.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HandoverNote.TextFont.Size = 12;
                    HandoverNote.TextFont.CharSet = 162;
                    HandoverNote.Value = @"";

                    Hemşirelik_Notu1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 1, 280, 10, false);
                    Hemşirelik_Notu1.Name = "Hemşirelik_Notu1";
                    Hemşirelik_Notu1.FieldType = ReportFieldTypeEnum.ftVariable;
                    Hemşirelik_Notu1.MultiLine = EvetHayirEnum.ehEvet;
                    Hemşirelik_Notu1.NoClip = EvetHayirEnum.ehEvet;
                    Hemşirelik_Notu1.WordBreak = EvetHayirEnum.ehEvet;
                    Hemşirelik_Notu1.ExpandTabs = EvetHayirEnum.ehEvet;
                    Hemşirelik_Notu1.TextFont.CharSet = 162;
                    Hemşirelik_Notu1.Value = @" {#PARENT.DESCRIPTION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NursingAppliProgress.GetNursingAppliProgressByPatient_Class dataset_GetNursingAppliProgressByPatient = MyParentReport.PARENT.rsGroup.GetCurrentRecord<NursingAppliProgress.GetNursingAppliProgressByPatient_Class>(0);
                    HemsireAdi.CalcValue = @" 
  " + (dataset_GetNursingAppliProgressByPatient != null ? Globals.ToStringCore(dataset_GetNursingAppliProgressByPatient.ApplicationUser) : "");
                    HemsireAdi.PostFieldValueCalculation();
                    FULLNAME.CalcValue = @" " + (dataset_GetNursingAppliProgressByPatient != null ? Globals.ToStringCore(dataset_GetNursingAppliProgressByPatient.Name) : "") + @" " + (dataset_GetNursingAppliProgressByPatient != null ? Globals.ToStringCore(dataset_GetNursingAppliProgressByPatient.Surname) : "");
                    NOTTARIHI.CalcValue = @"
  " + (dataset_GetNursingAppliProgressByPatient != null ? Globals.ToStringCore(dataset_GetNursingAppliProgressByPatient.Progressdate) : "");
                    NAME.CalcValue = (dataset_GetNursingAppliProgressByPatient != null ? Globals.ToStringCore(dataset_GetNursingAppliProgressByPatient.Name) : "");
                    SURNAME.CalcValue = (dataset_GetNursingAppliProgressByPatient != null ? Globals.ToStringCore(dataset_GetNursingAppliProgressByPatient.Surname) : "");
                    satir.CalcValue = ParentGroup.Counter.ToString();
                    HandoverNoteVar.CalcValue = (dataset_GetNursingAppliProgressByPatient != null ? Globals.ToStringCore(dataset_GetNursingAppliProgressByPatient.HandOverNote) : "");
                    HandoverNote.CalcValue = HandoverNote.Value;
                    Hemşirelik_Notu1.CalcValue = @" " + (dataset_GetNursingAppliProgressByPatient != null ? Globals.ToStringCore(dataset_GetNursingAppliProgressByPatient.Description) : "");
                    return new TTReportObject[] { HemsireAdi,FULLNAME,NOTTARIHI,NAME,SURNAME,satir,HandoverNoteVar,HandoverNote,Hemşirelik_Notu1};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (this.HandoverNoteVar.CalcValue != "" && Convert.ToBoolean(this.HandoverNoteVar.CalcValue) == true)
                    {
                        this.HandoverNote.CalcValue = "DT";
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

        public NursingNoteReport()
        {
            hed = new hedGroup(this,"hed");
            PARENT = new PARENTGroup(hed,"PARENT");
            MAIN = new MAINGroup(PARENT,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("MASTERRESOURCE", "", "Klinik", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("65cf14d4-129b-42dd-a991-b5e06fc66abc");
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("PATIENTS", "", "Hasta Listesi", @"", false, true, true, new Guid("4bf2cf68-3f04-49cf-b114-a88d422704bb"));
            reportParameter.ListDefID = new Guid("183ba55d-b669-4559-b896-982379b5de98");
            reportParameter = Parameters.Add("PATIENTCONTROL", "", "Kontorl", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("MASTERRESOURCE"))
                _runtimeParameters.MASTERRESOURCE = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["MASTERRESOURCE"]);
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("PATIENTS"))
                _runtimeParameters.PATIENTS = (List<string>)parameters["PATIENTS"];
            if (parameters.ContainsKey("PATIENTCONTROL"))
                _runtimeParameters.PATIENTCONTROL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["PATIENTCONTROL"]);
            Name = "NURSINGNOTEREPORT";
            Caption = "Hemşire Notu Raporu";
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
            fd.TextFont.CharSet = 0;
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