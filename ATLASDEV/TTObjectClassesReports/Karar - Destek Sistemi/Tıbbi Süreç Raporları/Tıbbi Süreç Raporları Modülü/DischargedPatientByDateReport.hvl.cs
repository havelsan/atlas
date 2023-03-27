
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
    /// Taburcu Olan Hasta Listesi (Tarihe göre)
    /// </summary>
    public partial class DischargedPatientByDateReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public string CLINIC = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public PatientGroupEnum? PATIENTGROUP = (PatientGroupEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PatientGroupEnum"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public DischargedPatientByDateReport MyParentReport
            {
                get { return (DischargedPatientByDateReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
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
                public DischargedPatientByDateReport MyParentReport
                {
                    get { return (DischargedPatientByDateReport)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 9;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 3, 31, 8, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.MultiLine = EvetHayirEnum.ehEvet;
                    STARTDATE.WordBreak = EvetHayirEnum.ehEvet;
                    STARTDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 3, 57, 8, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.MultiLine = EvetHayirEnum.ehEvet;
                    ENDDATE.WordBreak = EvetHayirEnum.ehEvet;
                    ENDDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { STARTDATE,ENDDATE};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    ((DischargedPatientByDateReport)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((DischargedPatientByDateReport)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public DischargedPatientByDateReport MyParentReport
                {
                    get { return (DischargedPatientByDateReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class HeaderGroup : TTReportGroup
        {
            public DischargedPatientByDateReport MyParentReport
            {
                get { return (DischargedPatientByDateReport)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField RAPORBASLIK { get {return Header().RAPORBASLIK;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField NewField91 { get {return Header().NewField91;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField RDATE { get {return Header().RDATE;} }
            public TTReportField FILTER { get {return Header().FILTER;} }
            public TTReportField LBLCLINICNAME { get {return Header().LBLCLINICNAME;} }
            public TTReportField LBLCLINICNAME1 { get {return Header().LBLCLINICNAME1;} }
            public TTReportField CLINICNAME { get {return Header().CLINICNAME;} }
            public TTReportField PATIENTGROUP { get {return Header().PATIENTGROUP;} }
            public TTReportField CLINICNAME1 { get {return Header().CLINICNAME1;} }
            public TTReportField PATIENTGROUP1 { get {return Header().PATIENTGROUP1;} }
            public HeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HeaderGroupHeader(this);
                _footer = new HeaderGroupFooter(this);

            }

            public partial class HeaderGroupHeader : TTReportSection
            {
                public DischargedPatientByDateReport MyParentReport
                {
                    get { return (DischargedPatientByDateReport)ParentReport; }
                }
                
                public TTReportField RAPORBASLIK;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField8;
                public TTReportField NewField18;
                public TTReportField NewField9;
                public TTReportField NewField91;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField NewField19;
                public TTReportField NewField181;
                public TTReportField RDATE;
                public TTReportField FILTER;
                public TTReportField LBLCLINICNAME;
                public TTReportField LBLCLINICNAME1;
                public TTReportField CLINICNAME;
                public TTReportField PATIENTGROUP;
                public TTReportField CLINICNAME1;
                public TTReportField PATIENTGROUP1; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 72;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    RAPORBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 34, 198, 54, false);
                    RAPORBASLIK.Name = "RAPORBASLIK";
                    RAPORBASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPORBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    RAPORBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORBASLIK.TextFont.Size = 12;
                    RAPORBASLIK.TextFont.Bold = true;
                    RAPORBASLIK.TextFont.CharSet = 162;
                    RAPORBASLIK.Value = @"TIBBİ KAYIT VE ARŞİV ŞUBE MÜDÜRLÜĞÜ
{%STARTDATE%} - {%ENDDATE%} TARİHLERİ ARASINDA TABURCU OLAN HASTALARA AİT
İLAÇ VE YİYECEK KAĞITLARININ LİSTESİ (Tüm Taburcu Olanlar Ölüm Hariç)";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 198, 33, false);
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

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 17, 263, 22, false);
                    NewField8.Name = "NewField8";
                    NewField8.Visible = EvetHayirEnum.ehHayir;
                    NewField8.TextFont.Size = 9;
                    NewField8.TextFont.Bold = true;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @"Başlangıç Tarihi";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 17, 266, 22, false);
                    NewField18.Name = "NewField18";
                    NewField18.Visible = EvetHayirEnum.ehHayir;
                    NewField18.TextFont.Size = 11;
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @":";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 22, 263, 27, false);
                    NewField9.Name = "NewField9";
                    NewField9.Visible = EvetHayirEnum.ehHayir;
                    NewField9.TextFont.Size = 9;
                    NewField9.TextFont.Bold = true;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @"Bitiş Tarihi";

                    NewField91 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 22, 266, 27, false);
                    NewField91.Name = "NewField91";
                    NewField91.Visible = EvetHayirEnum.ehHayir;
                    NewField91.TextFont.Size = 11;
                    NewField91.TextFont.Bold = true;
                    NewField91.TextFont.CharSet = 162;
                    NewField91.Value = @":";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 17, 306, 22, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    STARTDATE.TextFont.Size = 9;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 22, 306, 27, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    ENDDATE.TextFont.Size = 9;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 55, 179, 60, false);
                    NewField19.Name = "NewField19";
                    NewField19.TextFont.Size = 9;
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"Tarih";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 55, 182, 60, false);
                    NewField181.Name = "NewField181";
                    NewField181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField181.TextFont.Bold = true;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @":";

                    RDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 55, 198, 60, false);
                    RDATE.Name = "RDATE";
                    RDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RDATE.TextFormat = @"dd/MM/yyyy";
                    RDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RDATE.TextFont.Size = 9;
                    RDATE.TextFont.CharSet = 162;
                    RDATE.Value = @"{@printdate@}";

                    FILTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 28, 251, 33, false);
                    FILTER.Name = "FILTER";
                    FILTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    FILTER.Value = @"";

                    LBLCLINICNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 61, 31, 66, false);
                    LBLCLINICNAME.Name = "LBLCLINICNAME";
                    LBLCLINICNAME.TextFont.Bold = true;
                    LBLCLINICNAME.TextFont.CharSet = 162;
                    LBLCLINICNAME.Value = @"Klinik             :";

                    LBLCLINICNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 67, 31, 72, false);
                    LBLCLINICNAME1.Name = "LBLCLINICNAME1";
                    LBLCLINICNAME1.TextFont.Bold = true;
                    LBLCLINICNAME1.TextFont.CharSet = 162;
                    LBLCLINICNAME1.Value = @"Hasta Grubu :";

                    CLINICNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 34, 393, 39, false);
                    CLINICNAME.Name = "CLINICNAME";
                    CLINICNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLINICNAME.TextFont.CharSet = 162;
                    CLINICNAME.Value = @"{@CLINIC@}";

                    PATIENTGROUP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 40, 393, 45, false);
                    PATIENTGROUP.Name = "PATIENTGROUP";
                    PATIENTGROUP.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTGROUP.ObjectDefName = "PatientGroupEnum";
                    PATIENTGROUP.DataMember = "DISPLAYTEXT";
                    PATIENTGROUP.TextFont.CharSet = 162;
                    PATIENTGROUP.Value = @"{@PATIENTGROUP@}";

                    CLINICNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 61, 198, 66, false);
                    CLINICNAME1.Name = "CLINICNAME1";
                    CLINICNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLINICNAME1.TextFont.CharSet = 162;
                    CLINICNAME1.Value = @"";

                    PATIENTGROUP1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 67, 198, 72, false);
                    PATIENTGROUP1.Name = "PATIENTGROUP1";
                    PATIENTGROUP1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTGROUP1.ObjectDefName = "PatientGroupEnum";
                    PATIENTGROUP1.DataMember = "DISPLAYTEXT";
                    PATIENTGROUP1.TextFont.CharSet = 162;
                    PATIENTGROUP1.Value = @"{@PATIENTGROUP@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    RAPORBASLIK.CalcValue = @"TIBBİ KAYIT VE ARŞİV ŞUBE MÜDÜRLÜĞÜ
" + MyParentReport.Header.STARTDATE.FormattedValue + @" - " + MyParentReport.Header.ENDDATE.FormattedValue + @" TARİHLERİ ARASINDA TABURCU OLAN HASTALARA AİT
İLAÇ VE YİYECEK KAĞITLARININ LİSTESİ (Tüm Taburcu Olanlar Ölüm Hariç)";
                    NewField8.CalcValue = NewField8.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField91.CalcValue = NewField91.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField181.CalcValue = NewField181.Value;
                    RDATE.CalcValue = DateTime.Now.ToShortDateString();
                    FILTER.CalcValue = @"";
                    LBLCLINICNAME.CalcValue = LBLCLINICNAME.Value;
                    LBLCLINICNAME1.CalcValue = LBLCLINICNAME1.Value;
                    CLINICNAME.CalcValue = MyParentReport.RuntimeParameters.CLINIC.ToString();
                    PATIENTGROUP.CalcValue = MyParentReport.RuntimeParameters.PATIENTGROUP.ToString();
                    PATIENTGROUP.PostFieldValueCalculation();
                    CLINICNAME1.CalcValue = @"";
                    PATIENTGROUP1.CalcValue = MyParentReport.RuntimeParameters.PATIENTGROUP.ToString();
                    PATIENTGROUP1.PostFieldValueCalculation();
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { STARTDATE,ENDDATE,RAPORBASLIK,NewField8,NewField18,NewField9,NewField91,NewField19,NewField181,RDATE,FILTER,LBLCLINICNAME,LBLCLINICNAME1,CLINICNAME,PATIENTGROUP,CLINICNAME1,PATIENTGROUP1,XXXXXXBASLIK};
                }
                public override void RunPreScript()
                {
#region HEADER HEADER_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string filter = ((DischargedPatientByDateReport)ParentReport).RuntimeParameters.PATIENTGROUP.ToString();
            if(filter != "")
                filter = (TTObjectDefManager.Instance.DataTypes["PatientGroupEnum"].EnumValueDefs[((DischargedPatientByDateReport)ParentReport).RuntimeParameters.PATIENTGROUP.ToString()].Value).ToString();
            else
                filter = "-1";
            this.FILTER.CalcValue = filter;
            this.FILTER.Value = filter;
#endregion HEADER HEADER_PreScript
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string filter = ((DischargedPatientByDateReport)ParentReport).RuntimeParameters.PATIENTGROUP.ToString();
            if(filter != "")
                filter = (TTObjectDefManager.Instance.DataTypes["PatientGroupEnum"].EnumValueDefs[((DischargedPatientByDateReport)ParentReport).RuntimeParameters.PATIENTGROUP.ToString()].Value).ToString();
            else
                filter = "-1";
            this.FILTER.CalcValue = filter;
            this.FILTER.Value = filter;
            
            string clinicGuid = ((DischargedPatientByDateReport)ParentReport).RuntimeParameters.CLINIC.ToString();
            
            if(String.IsNullOrEmpty(clinicGuid))
                this.CLINICNAME1.CalcValue = "Tüm Klinikler";
            else
            {
                ResWard clinic = (ResWard)context.GetObject(new Guid(clinicGuid),"ResWard");
                this.CLINICNAME1.CalcValue = clinic.Name;
            }
            
            if(this.PATIENTGROUP.CalcValue == "")
                this.PATIENTGROUP1.CalcValue = "Tüm Hasta Grupları";
            else
                this.PATIENTGROUP1.CalcValue = (TTObjectDefManager.Instance.DataTypes["PatientGroupEnum"].EnumValueDefs[((DischargedPatientByDateReport)ParentReport).RuntimeParameters.PATIENTGROUP.ToString()].DisplayText).ToString();
#endregion HEADER HEADER_Script
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public DischargedPatientByDateReport MyParentReport
                {
                    get { return (DischargedPatientByDateReport)ParentReport; }
                }
                 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HeaderGroup Header;

        public partial class BaslikGroup : TTReportGroup
        {
            public DischargedPatientByDateReport MyParentReport
            {
                get { return (DischargedPatientByDateReport)ParentReport; }
            }

            new public BaslikGroupHeader Header()
            {
                return (BaslikGroupHeader)_header;
            }

            new public BaslikGroupFooter Footer()
            {
                return (BaslikGroupFooter)_footer;
            }

            public TTReportField LBLHASTAADISOYADI { get {return Header().LBLHASTAADISOYADI;} }
            public TTReportField LBLHASTATCNO { get {return Header().LBLHASTATCNO;} }
            public TTReportField LBLHASTAGRUBU { get {return Header().LBLHASTAGRUBU;} }
            public TTReportField LBLTABURCUTARIHI { get {return Header().LBLTABURCUTARIHI;} }
            public TTReportField LBLSIRANO { get {return Header().LBLSIRANO;} }
            public TTReportField LBLTABURCUNO { get {return Header().LBLTABURCUNO;} }
            public TTReportField YATISGUN { get {return Header().YATISGUN;} }
            public TTReportField LBLKLINIK { get {return Header().LBLKLINIK;} }
            public BaslikGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public BaslikGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new BaslikGroupHeader(this);
                _footer = new BaslikGroupFooter(this);

            }

            public partial class BaslikGroupHeader : TTReportSection
            {
                public DischargedPatientByDateReport MyParentReport
                {
                    get { return (DischargedPatientByDateReport)ParentReport; }
                }
                
                public TTReportField LBLHASTAADISOYADI;
                public TTReportField LBLHASTATCNO;
                public TTReportField LBLHASTAGRUBU;
                public TTReportField LBLTABURCUTARIHI;
                public TTReportField LBLSIRANO;
                public TTReportField LBLTABURCUNO;
                public TTReportField YATISGUN;
                public TTReportField LBLKLINIK; 
                public BaslikGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LBLHASTAADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 1, 96, 6, false);
                    LBLHASTAADISOYADI.Name = "LBLHASTAADISOYADI";
                    LBLHASTAADISOYADI.TextFont.Bold = true;
                    LBLHASTAADISOYADI.TextFont.CharSet = 162;
                    LBLHASTAADISOYADI.Value = @"Hasta Adı Soyadı";

                    LBLHASTATCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 1, 62, 6, false);
                    LBLHASTATCNO.Name = "LBLHASTATCNO";
                    LBLHASTATCNO.TextFont.Bold = true;
                    LBLHASTATCNO.TextFont.CharSet = 162;
                    LBLHASTATCNO.Value = @"TC Kimlik No ";

                    LBLHASTAGRUBU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 1, 134, 6, false);
                    LBLHASTAGRUBU.Name = "LBLHASTAGRUBU";
                    LBLHASTAGRUBU.TextFont.Bold = true;
                    LBLHASTAGRUBU.TextFont.CharSet = 162;
                    LBLHASTAGRUBU.Value = @"Hasta Grubu";

                    LBLTABURCUTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 1, 183, 6, false);
                    LBLTABURCUTARIHI.Name = "LBLTABURCUTARIHI";
                    LBLTABURCUTARIHI.TextFont.Bold = true;
                    LBLTABURCUTARIHI.TextFont.CharSet = 162;
                    LBLTABURCUTARIHI.Value = @"Taburcu Tarihi";

                    LBLSIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 20, 6, false);
                    LBLSIRANO.Name = "LBLSIRANO";
                    LBLSIRANO.TextFont.Bold = true;
                    LBLSIRANO.TextFont.CharSet = 162;
                    LBLSIRANO.Value = @"Sıra No";

                    LBLTABURCUNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 1, 37, 6, false);
                    LBLTABURCUNO.Name = "LBLTABURCUNO";
                    LBLTABURCUNO.TextFont.Bold = true;
                    LBLTABURCUNO.TextFont.CharSet = 162;
                    LBLTABURCUNO.Value = @"Taburcu No";

                    YATISGUN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 1, 198, 6, false);
                    YATISGUN.Name = "YATISGUN";
                    YATISGUN.TextFont.Bold = true;
                    YATISGUN.TextFont.CharSet = 162;
                    YATISGUN.Value = @"Yatış Gün";

                    LBLKLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 1, 160, 6, false);
                    LBLKLINIK.Name = "LBLKLINIK";
                    LBLKLINIK.TextFont.Bold = true;
                    LBLKLINIK.TextFont.CharSet = 162;
                    LBLKLINIK.Value = @"Klinik";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LBLHASTAADISOYADI.CalcValue = LBLHASTAADISOYADI.Value;
                    LBLHASTATCNO.CalcValue = LBLHASTATCNO.Value;
                    LBLHASTAGRUBU.CalcValue = LBLHASTAGRUBU.Value;
                    LBLTABURCUTARIHI.CalcValue = LBLTABURCUTARIHI.Value;
                    LBLSIRANO.CalcValue = LBLSIRANO.Value;
                    LBLTABURCUNO.CalcValue = LBLTABURCUNO.Value;
                    YATISGUN.CalcValue = YATISGUN.Value;
                    LBLKLINIK.CalcValue = LBLKLINIK.Value;
                    return new TTReportObject[] { LBLHASTAADISOYADI,LBLHASTATCNO,LBLHASTAGRUBU,LBLTABURCUTARIHI,LBLSIRANO,LBLTABURCUNO,YATISGUN,LBLKLINIK};
                }
            }
            public partial class BaslikGroupFooter : TTReportSection
            {
                public DischargedPatientByDateReport MyParentReport
                {
                    get { return (DischargedPatientByDateReport)ParentReport; }
                }
                 
                public BaslikGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public BaslikGroup Baslik;

        public partial class MAINGroup : TTReportGroup
        {
            public DischargedPatientByDateReport MyParentReport
            {
                get { return (DischargedPatientByDateReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNTER { get {return Body().COUNTER;} }
            public TTReportField HASTAADISOYADI { get {return Body().HASTAADISOYADI;} }
            public TTReportField TABURCUNO { get {return Body().TABURCUNO;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField HASTAGRUBU { get {return Body().HASTAGRUBU;} }
            public TTReportField TABURCUTARIHI { get {return Body().TABURCUTARIHI;} }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField HASTASOYADI { get {return Body().HASTASOYADI;} }
            public TTReportField YATISGUNSAY { get {return Body().YATISGUNSAY;} }
            public TTReportField GIRISTARIHI { get {return Body().GIRISTARIHI;} }
            public TTReportField KLINIK { get {return Body().KLINIK;} }
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
                list[0] = new TTReportNqlData<InpatientAdmission.GetDischargedPatientListByDate_Class>("GetDischargedPatientListByDate", InpatientAdmission.GetDischargedPatientListByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.CLINIC),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.Header.FILTER.CalcValue)));
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
                public DischargedPatientByDateReport MyParentReport
                {
                    get { return (DischargedPatientByDateReport)ParentReport; }
                }
                
                public TTReportField COUNTER;
                public TTReportField HASTAADISOYADI;
                public TTReportField TABURCUNO;
                public TTReportField TCKIMLIKNO;
                public TTReportField HASTAGRUBU;
                public TTReportField TABURCUTARIHI;
                public TTReportField HASTAADI;
                public TTReportField HASTASOYADI;
                public TTReportField YATISGUNSAY;
                public TTReportField GIRISTARIHI;
                public TTReportField KLINIK; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    COUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 20, 6, false);
                    COUNTER.Name = "COUNTER";
                    COUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNTER.TextFont.CharSet = 162;
                    COUNTER.Value = @"{@counter@}";

                    HASTAADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 1, 96, 6, false);
                    HASTAADISOYADI.Name = "HASTAADISOYADI";
                    HASTAADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADISOYADI.TextFont.CharSet = 162;
                    HASTAADISOYADI.Value = @"{%HASTAADI%} {%HASTASOYADI%}";

                    TABURCUNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 1, 37, 6, false);
                    TABURCUNO.Name = "TABURCUNO";
                    TABURCUNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCUNO.TextFont.CharSet = 162;
                    TABURCUNO.Value = @"{#DISCHARGENUMBER#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 1, 62, 6, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#TCNO#}";

                    HASTAGRUBU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 1, 134, 6, false);
                    HASTAGRUBU.Name = "HASTAGRUBU";
                    HASTAGRUBU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAGRUBU.ObjectDefName = "PatientGroupEnum";
                    HASTAGRUBU.DataMember = "DISPLAYTEXT";
                    HASTAGRUBU.TextFont.CharSet = 162;
                    HASTAGRUBU.Value = @"{#HASTAGRUBU#}";

                    TABURCUTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 1, 183, 6, false);
                    TABURCUTARIHI.Name = "TABURCUTARIHI";
                    TABURCUTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCUTARIHI.TextFormat = @"dd/MM/yyyy";
                    TABURCUTARIHI.TextFont.CharSet = 162;
                    TABURCUTARIHI.Value = @"{#TABURCUTARIHI#}";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 1, 240, 6, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.Visible = EvetHayirEnum.ehHayir;
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.Value = @"{#HASTAADI#}";

                    HASTASOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 1, 262, 6, false);
                    HASTASOYADI.Name = "HASTASOYADI";
                    HASTASOYADI.Visible = EvetHayirEnum.ehHayir;
                    HASTASOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTASOYADI.Value = @"{#HASTASOYADI#}";

                    YATISGUNSAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 1, 198, 6, false);
                    YATISGUNSAY.Name = "YATISGUNSAY";
                    YATISGUNSAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATISGUNSAY.Value = @"";

                    GIRISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 1, 290, 6, false);
                    GIRISTARIHI.Name = "GIRISTARIHI";
                    GIRISTARIHI.Visible = EvetHayirEnum.ehHayir;
                    GIRISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    GIRISTARIHI.TextFormat = @"Short Date";
                    GIRISTARIHI.Value = @"{#GIRISTARIHI#}";

                    KLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 1, 160, 6, false);
                    KLINIK.Name = "KLINIK";
                    KLINIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLINIK.MultiLine = EvetHayirEnum.ehEvet;
                    KLINIK.NoClip = EvetHayirEnum.ehEvet;
                    KLINIK.WordBreak = EvetHayirEnum.ehEvet;
                    KLINIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    KLINIK.Value = @"{#KLINIK#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmission.GetDischargedPatientListByDate_Class dataset_GetDischargedPatientListByDate = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmission.GetDischargedPatientListByDate_Class>(0);
                    COUNTER.CalcValue = ParentGroup.Counter.ToString();
                    HASTAADI.CalcValue = (dataset_GetDischargedPatientListByDate != null ? Globals.ToStringCore(dataset_GetDischargedPatientListByDate.Hastaadi) : "");
                    HASTASOYADI.CalcValue = (dataset_GetDischargedPatientListByDate != null ? Globals.ToStringCore(dataset_GetDischargedPatientListByDate.Hastasoyadi) : "");
                    HASTAADISOYADI.CalcValue = MyParentReport.MAIN.HASTAADI.CalcValue + @" " + MyParentReport.MAIN.HASTASOYADI.CalcValue;
                    TABURCUNO.CalcValue = (dataset_GetDischargedPatientListByDate != null ? Globals.ToStringCore(dataset_GetDischargedPatientListByDate.DischargeNumber) : "");
                    TCKIMLIKNO.CalcValue = (dataset_GetDischargedPatientListByDate != null ? Globals.ToStringCore(dataset_GetDischargedPatientListByDate.Tcno) : "");
                    HASTAGRUBU.CalcValue = (dataset_GetDischargedPatientListByDate != null ? Globals.ToStringCore(dataset_GetDischargedPatientListByDate.Hastagrubu) : "");
                    HASTAGRUBU.PostFieldValueCalculation();
                    TABURCUTARIHI.CalcValue = (dataset_GetDischargedPatientListByDate != null ? Globals.ToStringCore(dataset_GetDischargedPatientListByDate.Taburcutarihi) : "");
                    YATISGUNSAY.CalcValue = @"";
                    GIRISTARIHI.CalcValue = (dataset_GetDischargedPatientListByDate != null ? Globals.ToStringCore(dataset_GetDischargedPatientListByDate.Giristarihi) : "");
                    KLINIK.CalcValue = (dataset_GetDischargedPatientListByDate != null ? Globals.ToStringCore(dataset_GetDischargedPatientListByDate.Klinik) : "");
                    return new TTReportObject[] { COUNTER,HASTAADI,HASTASOYADI,HASTAADISOYADI,TABURCUNO,TCKIMLIKNO,HASTAGRUBU,TABURCUTARIHI,YATISGUNSAY,GIRISTARIHI,KLINIK};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //MCA
                    string giris = GIRISTARIHI.CalcValue;
                    string taburcu = TABURCUTARIHI.CalcValue;
                    //string munir = "08.08.2009 23:37:48";
                    //string can = "03.08.2009 00:38:48";
                    YATISGUNSAY.CalcValue = ((DateTime.Parse(taburcu).Date.Subtract(DateTime.Parse(giris).Date).TotalDays).ToString());
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

        public DischargedPatientByDateReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            Header = new HeaderGroup(PARTA,"Header");
            Baslik = new BaslikGroup(Header,"Baslik");
            MAIN = new MAINGroup(Baslik,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("CLINIC", "", "Klinik", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("20fdb56a-389f-46c9-8cd5-f604eddab75f");
            reportParameter = Parameters.Add("PATIENTGROUP", "", "Hasta Grubu", @"", false, true, false, new Guid("026151ea-400a-49cb-83ce-c12cf629e20f"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("CLINIC"))
                _runtimeParameters.CLINIC = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["CLINIC"]);
            if (parameters.ContainsKey("PATIENTGROUP"))
                _runtimeParameters.PATIENTGROUP = (PatientGroupEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PatientGroupEnum"].ConvertValue(parameters["PATIENTGROUP"]);
            Name = "DISCHARGEDPATIENTBYDATEREPORT";
            Caption = "Taburcu Olan Hasta Listesi (Tarihe göre)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 10;
            UserMarginTop = 10;
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