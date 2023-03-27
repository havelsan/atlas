
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
    /// Morg İstekleri Raporu
    /// </summary>
    public partial class MorgueRequestsReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? FIRSTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? LASTNAME = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public MorgueRequestsReport MyParentReport
            {
                get { return (MorgueRequestsReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField TCKimlikNo1 { get {return Header().TCKimlikNo1;} }
            public TTReportField AdiSoyadi { get {return Header().AdiSoyadi;} }
            public TTReportField Klinik { get {return Header().Klinik;} }
            public TTReportField SorumluDoktor { get {return Header().SorumluDoktor;} }
            public TTReportField TarihAraligi { get {return Header().TarihAraligi;} }
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
                public MorgueRequestsReport MyParentReport
                {
                    get { return (MorgueRequestsReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField TCKimlikNo1;
                public TTReportField AdiSoyadi;
                public TTReportField Klinik;
                public TTReportField SorumluDoktor;
                public TTReportField TarihAraligi; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 46;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 5, 148, 24, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    TCKimlikNo1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 41, 41, 46, false);
                    TCKimlikNo1.Name = "TCKimlikNo1";
                    TCKimlikNo1.DrawStyle = DrawStyleConstants.vbSolid;
                    TCKimlikNo1.TextFont.Bold = true;
                    TCKimlikNo1.TextFont.CharSet = 162;
                    TCKimlikNo1.Value = @"TC Kimlik Numarası";

                    AdiSoyadi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 41, 83, 46, false);
                    AdiSoyadi.Name = "AdiSoyadi";
                    AdiSoyadi.DrawStyle = DrawStyleConstants.vbSolid;
                    AdiSoyadi.TextFont.Bold = true;
                    AdiSoyadi.TextFont.CharSet = 162;
                    AdiSoyadi.Value = @"Adı Soyadı";

                    Klinik = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 41, 159, 46, false);
                    Klinik.Name = "Klinik";
                    Klinik.DrawStyle = DrawStyleConstants.vbSolid;
                    Klinik.TextFont.Bold = true;
                    Klinik.TextFont.CharSet = 162;
                    Klinik.Value = @"Yattığı Klinik";

                    SorumluDoktor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 41, 201, 46, false);
                    SorumluDoktor.Name = "SorumluDoktor";
                    SorumluDoktor.DrawStyle = DrawStyleConstants.vbSolid;
                    SorumluDoktor.TextFont.Bold = true;
                    SorumluDoktor.TextFont.CharSet = 162;
                    SorumluDoktor.Value = @"Sorumlu Doktor";

                    TarihAraligi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 31, 201, 36, false);
                    TarihAraligi.Name = "TarihAraligi";
                    TarihAraligi.FieldType = ReportFieldTypeEnum.ftVariable;
                    TarihAraligi.Value = @"{@FIRSTDATE@} - {@LASTNAME@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TCKimlikNo1.CalcValue = TCKimlikNo1.Value;
                    AdiSoyadi.CalcValue = AdiSoyadi.Value;
                    Klinik.CalcValue = Klinik.Value;
                    SorumluDoktor.CalcValue = SorumluDoktor.Value;
                    TarihAraligi.CalcValue = MyParentReport.RuntimeParameters.FIRSTDATE.ToString() + @" - " + MyParentReport.RuntimeParameters.LASTNAME.ToString();
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { TCKimlikNo1,AdiSoyadi,Klinik,SorumluDoktor,TarihAraligi,XXXXXXBASLIK};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MorgueRequestsReport MyParentReport
                {
                    get { return (MorgueRequestsReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 9;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public MorgueRequestsReport MyParentReport
            {
                get { return (MorgueRequestsReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField UNIQUEREFNO { get {return Body().UNIQUEREFNO;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField CLINICNAME { get {return Body().CLINICNAME;} }
            public TTReportField DOKTORNAMESURNAME { get {return Body().DOKTORNAMESURNAME;} }
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
                list[0] = new TTReportNqlData<Morgue.GetMorgueRequests_Class>("GetMorgueRequests", Morgue.GetMorgueRequests((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.FIRSTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.LASTNAME)));
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
                public MorgueRequestsReport MyParentReport
                {
                    get { return (MorgueRequestsReport)ParentReport; }
                }
                
                public TTReportField UNIQUEREFNO;
                public TTReportField NAME;
                public TTReportField CLINICNAME;
                public TTReportField DOKTORNAMESURNAME; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 17;
                    RepeatCount = 0;
                    
                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 0, 41, 5, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.DrawStyle = DrawStyleConstants.vbSolid;
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.Value = @"{#UNIQUEREFNO#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 0, 83, 5, false);
                    NAME.Name = "NAME";
                    NAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.Value = @"{#PATIENTNAME#} {#PATIENTSURNAME#}";

                    CLINICNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 0, 159, 5, false);
                    CLINICNAME.Name = "CLINICNAME";
                    CLINICNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    CLINICNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLINICNAME.Value = @"{#CLINICNAME#}";

                    DOKTORNAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 0, 201, 5, false);
                    DOKTORNAMESURNAME.Name = "DOKTORNAMESURNAME";
                    DOKTORNAMESURNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    DOKTORNAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOKTORNAMESURNAME.Value = @"{#DOKTORNAMESURNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Morgue.GetMorgueRequests_Class dataset_GetMorgueRequests = ParentGroup.rsGroup.GetCurrentRecord<Morgue.GetMorgueRequests_Class>(0);
                    UNIQUEREFNO.CalcValue = (dataset_GetMorgueRequests != null ? Globals.ToStringCore(dataset_GetMorgueRequests.UniqueRefNo) : "");
                    NAME.CalcValue = (dataset_GetMorgueRequests != null ? Globals.ToStringCore(dataset_GetMorgueRequests.Patientname) : "") + @" " + (dataset_GetMorgueRequests != null ? Globals.ToStringCore(dataset_GetMorgueRequests.Patientsurname) : "");
                    CLINICNAME.CalcValue = (dataset_GetMorgueRequests != null ? Globals.ToStringCore(dataset_GetMorgueRequests.Clinicname) : "");
                    DOKTORNAMESURNAME.CalcValue = (dataset_GetMorgueRequests != null ? Globals.ToStringCore(dataset_GetMorgueRequests.Doktornamesurname) : "");
                    return new TTReportObject[] { UNIQUEREFNO,NAME,CLINICNAME,DOKTORNAMESURNAME};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public MorgueRequestsReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("FIRSTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("LASTNAME", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("FIRSTDATE"))
                _runtimeParameters.FIRSTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["FIRSTDATE"]);
            if (parameters.ContainsKey("LASTNAME"))
                _runtimeParameters.LASTNAME = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["LASTNAME"]);
            Name = "MORGUEREQUESTSREPORT";
            Caption = "Morg İstekleri Raporu";
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