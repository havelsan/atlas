
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
    /// Diş İşlemleri Listesi
    /// </summary>
    public partial class DentalProceduresReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATEPARAM = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATEPARAM = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public string PROCEDUREOBJECTPARAM = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string PROCEDUREDOCTORPARAM = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string SECTIONPARAM = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public DentalProceduresReport MyParentReport
            {
                get { return (DentalProceduresReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField DATE_CONST11 { get {return Header().DATE_CONST11;} }
            public TTReportField DATE_CONST12 { get {return Header().DATE_CONST12;} }
            public TTReportField STARTDATE1 { get {return Header().STARTDATE1;} }
            public TTReportField ENDDATE1 { get {return Header().ENDDATE1;} }
            public TTReportShape NewRect11 { get {return Header().NewRect11;} }
            public TTReportShape NewRect12 { get {return Header().NewRect12;} }
            public TTReportShape NewRect13 { get {return Header().NewRect13;} }
            public TTReportField ProcedureObject1 { get {return Header().ProcedureObject1;} }
            public TTReportField Doctor1 { get {return Header().Doctor1;} }
            public TTReportField ResSection1 { get {return Header().ResSection1;} }
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
                public DentalProceduresReport MyParentReport
                {
                    get { return (DentalProceduresReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField DATE_CONST11;
                public TTReportField DATE_CONST12;
                public TTReportField STARTDATE1;
                public TTReportField ENDDATE1;
                public TTReportShape NewRect11;
                public TTReportShape NewRect12;
                public TTReportShape NewRect13;
                public TTReportField ProcedureObject1;
                public TTReportField Doctor1;
                public TTReportField ResSection1; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 52;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 8, 153, 16, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Size = 14;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"DİŞ İŞLEMLERİ LİSTESİ";

                    DATE_CONST11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 26, 43, 31, false);
                    DATE_CONST11.Name = "DATE_CONST11";
                    DATE_CONST11.TextFont.Name = "Arial";
                    DATE_CONST11.TextFont.Bold = true;
                    DATE_CONST11.TextFont.CharSet = 162;
                    DATE_CONST11.Value = @"Bitiş Tarihi         :";

                    DATE_CONST12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 21, 43, 26, false);
                    DATE_CONST12.Name = "DATE_CONST12";
                    DATE_CONST12.TextFont.Name = "Arial";
                    DATE_CONST12.TextFont.Bold = true;
                    DATE_CONST12.TextFont.CharSet = 162;
                    DATE_CONST12.Value = @"Başlangıç Tarihi:";

                    STARTDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 21, 90, 26, false);
                    STARTDATE1.Name = "STARTDATE1";
                    STARTDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE1.TextFormat = @"dd/MM/yyyy";
                    STARTDATE1.Value = @"{@STARTDATEPARAM@}";

                    ENDDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 26, 90, 31, false);
                    ENDDATE1.Name = "ENDDATE1";
                    ENDDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE1.TextFormat = @"dd/MM/yyyy";
                    ENDDATE1.Value = @"{@ENDDATEPARAM@}";

                    NewRect11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 14, 43, 74, 49, false);
                    NewRect11.Name = "NewRect11";
                    NewRect11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 74, 43, 132, 49, false);
                    NewRect12.Name = "NewRect12";
                    NewRect12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 132, 43, 198, 49, false);
                    NewRect13.Name = "NewRect13";
                    NewRect13.DrawStyle = DrawStyleConstants.vbSolid;

                    ProcedureObject1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 44, 61, 49, false);
                    ProcedureObject1.Name = "ProcedureObject1";
                    ProcedureObject1.FillStyle = FillStyleConstants.vbFSTransparent;
                    ProcedureObject1.TextFont.Name = "Arial";
                    ProcedureObject1.TextFont.Bold = true;
                    ProcedureObject1.TextFont.CharSet = 162;
                    ProcedureObject1.Value = @"İşlem";

                    Doctor1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 44, 125, 49, false);
                    Doctor1.Name = "Doctor1";
                    Doctor1.FillStyle = FillStyleConstants.vbFSTransparent;
                    Doctor1.TextFont.Name = "Arial";
                    Doctor1.TextFont.Bold = true;
                    Doctor1.TextFont.CharSet = 162;
                    Doctor1.Value = @"İşlemi Yapan Tabip";

                    ResSection1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 44, 187, 49, false);
                    ResSection1.Name = "ResSection1";
                    ResSection1.FillStyle = FillStyleConstants.vbFSTransparent;
                    ResSection1.TextFont.Name = "Arial";
                    ResSection1.TextFont.Bold = true;
                    ResSection1.TextFont.CharSet = 162;
                    ResSection1.Value = @"İşlemin Yapıldığı Bölüm";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    DATE_CONST11.CalcValue = DATE_CONST11.Value;
                    DATE_CONST12.CalcValue = DATE_CONST12.Value;
                    STARTDATE1.CalcValue = MyParentReport.RuntimeParameters.STARTDATEPARAM.ToString();
                    ENDDATE1.CalcValue = MyParentReport.RuntimeParameters.ENDDATEPARAM.ToString();
                    ProcedureObject1.CalcValue = ProcedureObject1.Value;
                    Doctor1.CalcValue = Doctor1.Value;
                    ResSection1.CalcValue = ResSection1.Value;
                    return new TTReportObject[] { NewField11,DATE_CONST11,DATE_CONST12,STARTDATE1,ENDDATE1,ProcedureObject1,Doctor1,ResSection1};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public DentalProceduresReport MyParentReport
                {
                    get { return (DentalProceduresReport)ParentReport; }
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
            public DentalProceduresReport MyParentReport
            {
                get { return (DentalProceduresReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PROCEDUREOBJECT2 { get {return Body().PROCEDUREOBJECT2;} }
            public TTReportField DOCTOR2 { get {return Body().DOCTOR2;} }
            public TTReportField SECTION2 { get {return Body().SECTION2;} }
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
                list[0] = new TTReportNqlData<DentalProcedure.GetDentalProcedureByProcedureDoctorSection_Class>("GetDentalProcedureByProcedureDoctorSection", DentalProcedure.GetDentalProcedureByProcedureDoctorSection((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.PROCEDUREOBJECTPARAM),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.PROCEDUREDOCTORPARAM),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.SECTIONPARAM),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATEPARAM),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATEPARAM)));
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
                public DentalProceduresReport MyParentReport
                {
                    get { return (DentalProceduresReport)ParentReport; }
                }
                
                public TTReportField PROCEDUREOBJECT2;
                public TTReportField DOCTOR2;
                public TTReportField SECTION2; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    RepeatCount = 0;
                    
                    PROCEDUREOBJECT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 0, 74, 5, false);
                    PROCEDUREOBJECT2.Name = "PROCEDUREOBJECT2";
                    PROCEDUREOBJECT2.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    PROCEDUREOBJECT2.FillStyle = FillStyleConstants.vbFSTransparent;
                    PROCEDUREOBJECT2.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREOBJECT2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROCEDUREOBJECT2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROCEDUREOBJECT2.Value = @"{#PROCEDUREOBJECT#}";

                    DOCTOR2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 0, 132, 5, false);
                    DOCTOR2.Name = "DOCTOR2";
                    DOCTOR2.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    DOCTOR2.FillStyle = FillStyleConstants.vbFSTransparent;
                    DOCTOR2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTOR2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOCTOR2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOCTOR2.Value = @"{#PROCEDUREDOCTOR#}";

                    SECTION2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 0, 198, 5, false);
                    SECTION2.Name = "SECTION2";
                    SECTION2.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    SECTION2.FillStyle = FillStyleConstants.vbFSTransparent;
                    SECTION2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SECTION2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SECTION2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SECTION2.Value = @"{#RESSECTION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DentalProcedure.GetDentalProcedureByProcedureDoctorSection_Class dataset_GetDentalProcedureByProcedureDoctorSection = ParentGroup.rsGroup.GetCurrentRecord<DentalProcedure.GetDentalProcedureByProcedureDoctorSection_Class>(0);
                    PROCEDUREOBJECT2.CalcValue = (dataset_GetDentalProcedureByProcedureDoctorSection != null ? Globals.ToStringCore(dataset_GetDentalProcedureByProcedureDoctorSection.ProcedureObject) : "");
                    DOCTOR2.CalcValue = (dataset_GetDentalProcedureByProcedureDoctorSection != null ? Globals.ToStringCore(dataset_GetDentalProcedureByProcedureDoctorSection.ProcedureDoctor) : "");
                    SECTION2.CalcValue = (dataset_GetDentalProcedureByProcedureDoctorSection != null ? Globals.ToStringCore(dataset_GetDentalProcedureByProcedureDoctorSection.Ressection) : "");
                    return new TTReportObject[] { PROCEDUREOBJECT2,DOCTOR2,SECTION2};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string ProcedureObjectID= PROCEDUREOBJECT2.CalcValue;
            string DoctorID= DOCTOR2.CalcValue;
            string SectionID= SECTION2.CalcValue;
            
            TTObjectContext context = new TTObjectContext(true);
            if(!string.IsNullOrEmpty(ProcedureObjectID))
            {
                BindingList<TTObjectClasses.ProcedureDefinition> definitions = TTObjectClasses.ProcedureDefinition.GetAllProcedureDefinitions(context, "WHERE OBJECTID = '"+ ProcedureObjectID +"'");
                PROCEDUREOBJECT2.CalcValue = definitions[0].Name.ToString();
            }
            if(!string.IsNullOrEmpty(DoctorID))
            {
                 BindingList<TTObjectClasses.ResUser> users = TTObjectClasses.ResUser.GetAllUser(context, "WHERE OBJECTID = '"+ DoctorID +"'");
                 DOCTOR2.CalcValue = users[0].Name.ToString();
            }
            if(!string.IsNullOrEmpty(SectionID))
            {
                BindingList<TTObjectClasses.ResSection> sections = TTObjectClasses.ResSection.GetResSections(context, "WHERE OBJECTID = '"+ SectionID +"'");
                 SECTION2.CalcValue = sections[0].Name.ToString();
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

        public DentalProceduresReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATEPARAM", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATEPARAM", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("PROCEDUREOBJECTPARAM", "", "İşlem", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("9fa2796c-e744-4d0f-9dc3-71c5053c23fd");
            reportParameter = Parameters.Add("PROCEDUREDOCTORPARAM", "", "İşlemi Yapan Doktor", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("d6efe0cb-c3fd-430f-91fe-b4c7dae415b6");
            reportParameter = Parameters.Add("SECTIONPARAM", "", "Bölüm", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("44d92ee9-95ea-42f3-8a1a-07fce625510c");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATEPARAM"))
                _runtimeParameters.STARTDATEPARAM = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATEPARAM"]);
            if (parameters.ContainsKey("ENDDATEPARAM"))
                _runtimeParameters.ENDDATEPARAM = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATEPARAM"]);
            if (parameters.ContainsKey("PROCEDUREOBJECTPARAM"))
                _runtimeParameters.PROCEDUREOBJECTPARAM = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["PROCEDUREOBJECTPARAM"]);
            if (parameters.ContainsKey("PROCEDUREDOCTORPARAM"))
                _runtimeParameters.PROCEDUREDOCTORPARAM = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["PROCEDUREDOCTORPARAM"]);
            if (parameters.ContainsKey("SECTIONPARAM"))
                _runtimeParameters.SECTIONPARAM = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["SECTIONPARAM"]);
            Name = "DENTALPROCEDURESREPORT";
            Caption = "Diş İşlemleri Listesi";
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