
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
    /// Taburcu Olan Hasta Listesi (Taburcu Numarasına Göre)
    /// </summary>
    public partial class DischargedPatientByDischargeNumberReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("01.01.2012 00:00:00");
            public long? DISCHARGESTARTNO = (long?)TTObjectDefManager.Instance.DataTypes["Long"].ConvertValue("0");
            public long? DISCHARGEENDNO = (long?)TTObjectDefManager.Instance.DataTypes["Long"].ConvertValue("0");
            public string CLINIC = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public PatientGroupEnum? PATIENTGROUP = (PatientGroupEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PatientGroupEnum"].ConvertValue("");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public DischargedPatientByDischargeNumberReport MyParentReport
            {
                get { return (DischargedPatientByDischargeNumberReport)ParentReport; }
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
            public TTReportField DISCHARGESTARTNO { get {return Header().DISCHARGESTARTNO;} }
            public TTReportField DISCHARGEENDNO { get {return Header().DISCHARGEENDNO;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField RDATE { get {return Header().RDATE;} }
            public TTReportField FILTER { get {return Header().FILTER;} }
            public TTReportField LBLCLINICNAME1 { get {return Header().LBLCLINICNAME1;} }
            public TTReportField LBLCLINICNAME11 { get {return Header().LBLCLINICNAME11;} }
            public TTReportField CLINICNAME { get {return Header().CLINICNAME;} }
            public TTReportField PATIENTGROUP { get {return Header().PATIENTGROUP;} }
            public TTReportField CLINICNAME1 { get {return Header().CLINICNAME1;} }
            public TTReportField PATIENTGROUP1 { get {return Header().PATIENTGROUP1;} }
            public TTReportField LBLCLINICNAME12 { get {return Header().LBLCLINICNAME12;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField UserName { get {return Footer().UserName;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
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
                public DischargedPatientByDischargeNumberReport MyParentReport
                {
                    get { return (DischargedPatientByDischargeNumberReport)ParentReport; }
                }
                
                public TTReportField RAPORBASLIK;
                public TTReportField XXXXXXBASLIK;
                public TTReportField DISCHARGESTARTNO;
                public TTReportField DISCHARGEENDNO;
                public TTReportField NewField19;
                public TTReportField NewField181;
                public TTReportField RDATE;
                public TTReportField FILTER;
                public TTReportField LBLCLINICNAME1;
                public TTReportField LBLCLINICNAME11;
                public TTReportField CLINICNAME;
                public TTReportField PATIENTGROUP;
                public TTReportField CLINICNAME1;
                public TTReportField PATIENTGROUP1;
                public TTReportField LBLCLINICNAME12;
                public TTReportField STARTDATE; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 64;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    RAPORBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 28, 204, 44, false);
                    RAPORBASLIK.Name = "RAPORBASLIK";
                    RAPORBASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPORBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    RAPORBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORBASLIK.TextFont.Bold = true;
                    RAPORBASLIK.TextFont.CharSet = 162;
                    RAPORBASLIK.Value = @"TIBBİ KAYIT VE ARŞİV ŞUBE MÜDÜRLÜĞÜ
{%DISCHARGESTARTNO%} - {%DISCHARGEENDNO%} TABURCU NUMARALARI ARASINDA TABURCU OLAN HASTALARA AİT
İLAÇ VE YİYECEK KAĞITLARININ LİSTESİ (Tüm Taburcu Olanlar Ölüm Hariç)";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 4, 204, 27, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    DISCHARGESTARTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 17, 258, 22, false);
                    DISCHARGESTARTNO.Name = "DISCHARGESTARTNO";
                    DISCHARGESTARTNO.Visible = EvetHayirEnum.ehHayir;
                    DISCHARGESTARTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISCHARGESTARTNO.TextFont.Size = 9;
                    DISCHARGESTARTNO.TextFont.CharSet = 162;
                    DISCHARGESTARTNO.Value = @"{@DISCHARGESTARTNO@}";

                    DISCHARGEENDNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 23, 258, 28, false);
                    DISCHARGEENDNO.Name = "DISCHARGEENDNO";
                    DISCHARGEENDNO.Visible = EvetHayirEnum.ehHayir;
                    DISCHARGEENDNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISCHARGEENDNO.TextFont.Size = 9;
                    DISCHARGEENDNO.TextFont.CharSet = 162;
                    DISCHARGEENDNO.Value = @"{@DISCHARGEENDNO@}";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 45, 187, 50, false);
                    NewField19.Name = "NewField19";
                    NewField19.TextFont.Size = 9;
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"Tarih";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 45, 190, 50, false);
                    NewField181.Name = "NewField181";
                    NewField181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField181.TextFont.Bold = true;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @":";

                    RDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 45, 204, 50, false);
                    RDATE.Name = "RDATE";
                    RDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RDATE.TextFormat = @"dd/MM/yyyy";
                    RDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RDATE.TextFont.Size = 9;
                    RDATE.TextFont.CharSet = 162;
                    RDATE.Value = @"{@printdate@}";

                    FILTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 29, 243, 34, false);
                    FILTER.Name = "FILTER";
                    FILTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    FILTER.Value = @"";

                    LBLCLINICNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 52, 39, 57, false);
                    LBLCLINICNAME1.Name = "LBLCLINICNAME1";
                    LBLCLINICNAME1.TextFont.Bold = true;
                    LBLCLINICNAME1.TextFont.CharSet = 162;
                    LBLCLINICNAME1.Value = @"Klinik                      :";

                    LBLCLINICNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 58, 39, 63, false);
                    LBLCLINICNAME11.Name = "LBLCLINICNAME11";
                    LBLCLINICNAME11.TextFont.Bold = true;
                    LBLCLINICNAME11.TextFont.CharSet = 162;
                    LBLCLINICNAME11.Value = @"Hasta Grubu          :";

                    CLINICNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 36, 384, 41, false);
                    CLINICNAME.Name = "CLINICNAME";
                    CLINICNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLINICNAME.TextFont.CharSet = 162;
                    CLINICNAME.Value = @"{@CLINIC@}";

                    PATIENTGROUP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 41, 385, 46, false);
                    PATIENTGROUP.Name = "PATIENTGROUP";
                    PATIENTGROUP.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTGROUP.ObjectDefName = "PatientGroupEnum";
                    PATIENTGROUP.DataMember = "DISPLAYTEXT";
                    PATIENTGROUP.TextFont.CharSet = 162;
                    PATIENTGROUP.Value = @"{@PATIENTGROUP@}";

                    CLINICNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 52, 204, 57, false);
                    CLINICNAME1.Name = "CLINICNAME1";
                    CLINICNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLINICNAME1.TextFont.CharSet = 162;
                    CLINICNAME1.Value = @"";

                    PATIENTGROUP1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 58, 204, 63, false);
                    PATIENTGROUP1.Name = "PATIENTGROUP1";
                    PATIENTGROUP1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTGROUP1.ObjectDefName = "PatientGroupEnum";
                    PATIENTGROUP1.DataMember = "DISPLAYTEXT";
                    PATIENTGROUP1.TextFont.CharSet = 162;
                    PATIENTGROUP1.Value = @"{@PATIENTGROUP@}";

                    LBLCLINICNAME12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 46, 39, 51, false);
                    LBLCLINICNAME12.Name = "LBLCLINICNAME12";
                    LBLCLINICNAME12.TextFont.Bold = true;
                    LBLCLINICNAME12.TextFont.CharSet = 162;
                    LBLCLINICNAME12.Value = @"Başlangıç Tarihi    :";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 46, 103, 51, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.TextFont.Size = 9;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DISCHARGESTARTNO.CalcValue = MyParentReport.RuntimeParameters.DISCHARGESTARTNO.ToString();
                    DISCHARGEENDNO.CalcValue = MyParentReport.RuntimeParameters.DISCHARGEENDNO.ToString();
                    RAPORBASLIK.CalcValue = @"TIBBİ KAYIT VE ARŞİV ŞUBE MÜDÜRLÜĞÜ
" + MyParentReport.Header.DISCHARGESTARTNO.CalcValue + @" - " + MyParentReport.Header.DISCHARGEENDNO.CalcValue + @" TABURCU NUMARALARI ARASINDA TABURCU OLAN HASTALARA AİT
İLAÇ VE YİYECEK KAĞITLARININ LİSTESİ (Tüm Taburcu Olanlar Ölüm Hariç)";
                    NewField19.CalcValue = NewField19.Value;
                    NewField181.CalcValue = NewField181.Value;
                    RDATE.CalcValue = DateTime.Now.ToShortDateString();
                    FILTER.CalcValue = @"";
                    LBLCLINICNAME1.CalcValue = LBLCLINICNAME1.Value;
                    LBLCLINICNAME11.CalcValue = LBLCLINICNAME11.Value;
                    CLINICNAME.CalcValue = MyParentReport.RuntimeParameters.CLINIC.ToString();
                    PATIENTGROUP.CalcValue = MyParentReport.RuntimeParameters.PATIENTGROUP.ToString();
                    PATIENTGROUP.PostFieldValueCalculation();
                    CLINICNAME1.CalcValue = @"";
                    PATIENTGROUP1.CalcValue = MyParentReport.RuntimeParameters.PATIENTGROUP.ToString();
                    PATIENTGROUP1.PostFieldValueCalculation();
                    LBLCLINICNAME12.CalcValue = LBLCLINICNAME12.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { DISCHARGESTARTNO,DISCHARGEENDNO,RAPORBASLIK,NewField19,NewField181,RDATE,FILTER,LBLCLINICNAME1,LBLCLINICNAME11,CLINICNAME,PATIENTGROUP,CLINICNAME1,PATIENTGROUP1,LBLCLINICNAME12,STARTDATE,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string filter = ((DischargedPatientByDischargeNumberReport)ParentReport).RuntimeParameters.PATIENTGROUP.ToString();
            if(filter != "")
                filter = (TTObjectDefManager.Instance.DataTypes["PatientGroupEnum"].EnumValueDefs[((DischargedPatientByDischargeNumberReport)ParentReport).RuntimeParameters.PATIENTGROUP.ToString()].Value).ToString();
            else
                filter = "-1";
            this.FILTER.CalcValue = filter;
            this.FILTER.Value = filter;
            
            string clinicGuid = ((DischargedPatientByDischargeNumberReport)ParentReport).RuntimeParameters.CLINIC.ToString();
            
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
                this.PATIENTGROUP1.CalcValue = (TTObjectDefManager.Instance.DataTypes["PatientGroupEnum"].EnumValueDefs[((DischargedPatientByDischargeNumberReport)ParentReport).RuntimeParameters.PATIENTGROUP.ToString()].DisplayText).ToString();
#endregion HEADER HEADER_Script
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public DischargedPatientByDischargeNumberReport MyParentReport
                {
                    get { return (DischargedPatientByDischargeNumberReport)ParentReport; }
                }
                
                public TTReportShape NewLine1;
                public TTReportField PrintDate;
                public TTReportField UserName;
                public TTReportField PageNumber; 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 14;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 2, 205, 2, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 8, 205, 13, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    UserName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 3, 205, 8, false);
                    UserName.Name = "UserName";
                    UserName.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName.TextFont.Size = 8;
                    UserName.TextFont.CharSet = 162;
                    UserName.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 3, 111, 8, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    UserName.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { PrintDate,PageNumber,UserName};
                }
            }

        }

        public HeaderGroup Header;

        public partial class BaslikGroup : TTReportGroup
        {
            public DischargedPatientByDischargeNumberReport MyParentReport
            {
                get { return (DischargedPatientByDischargeNumberReport)ParentReport; }
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
            public TTReportField LBLHASTAADISOYADI1 { get {return Header().LBLHASTAADISOYADI1;} }
            public TTReportField YATISGUN { get {return Header().YATISGUN;} }
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
                public DischargedPatientByDischargeNumberReport MyParentReport
                {
                    get { return (DischargedPatientByDischargeNumberReport)ParentReport; }
                }
                
                public TTReportField LBLHASTAADISOYADI;
                public TTReportField LBLHASTATCNO;
                public TTReportField LBLHASTAGRUBU;
                public TTReportField LBLTABURCUTARIHI;
                public TTReportField LBLSIRANO;
                public TTReportField LBLTABURCUNO;
                public TTReportField LBLHASTAADISOYADI1;
                public TTReportField YATISGUN; 
                public BaslikGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LBLHASTAADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 1, 93, 6, false);
                    LBLHASTAADISOYADI.Name = "LBLHASTAADISOYADI";
                    LBLHASTAADISOYADI.TextFont.Size = 9;
                    LBLHASTAADISOYADI.TextFont.Bold = true;
                    LBLHASTAADISOYADI.TextFont.CharSet = 162;
                    LBLHASTAADISOYADI.Value = @"Hasta Adı Soyadı";

                    LBLHASTATCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 1, 54, 6, false);
                    LBLHASTATCNO.Name = "LBLHASTATCNO";
                    LBLHASTATCNO.TextFont.Size = 9;
                    LBLHASTATCNO.TextFont.Bold = true;
                    LBLHASTATCNO.TextFont.CharSet = 162;
                    LBLHASTATCNO.Value = @"TC Kimlik No ";

                    LBLHASTAGRUBU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 1, 174, 6, false);
                    LBLHASTAGRUBU.Name = "LBLHASTAGRUBU";
                    LBLHASTAGRUBU.TextFont.Size = 9;
                    LBLHASTAGRUBU.TextFont.Bold = true;
                    LBLHASTAGRUBU.TextFont.CharSet = 162;
                    LBLHASTAGRUBU.Value = @"Hasta Grubu";

                    LBLTABURCUTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 1, 195, 6, false);
                    LBLTABURCUTARIHI.Name = "LBLTABURCUTARIHI";
                    LBLTABURCUTARIHI.TextFont.Size = 9;
                    LBLTABURCUTARIHI.TextFont.Bold = true;
                    LBLTABURCUTARIHI.TextFont.CharSet = 162;
                    LBLTABURCUTARIHI.Value = @"Taburcu Tarihi";

                    LBLSIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 18, 6, false);
                    LBLSIRANO.Name = "LBLSIRANO";
                    LBLSIRANO.TextFont.Size = 9;
                    LBLSIRANO.TextFont.Bold = true;
                    LBLSIRANO.TextFont.CharSet = 162;
                    LBLSIRANO.Value = @"Sıra No";

                    LBLTABURCUNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 1, 34, 6, false);
                    LBLTABURCUNO.Name = "LBLTABURCUNO";
                    LBLTABURCUNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LBLTABURCUNO.TextFont.Size = 9;
                    LBLTABURCUNO.TextFont.Bold = true;
                    LBLTABURCUNO.TextFont.CharSet = 162;
                    LBLTABURCUNO.Value = @"Taburcu No";

                    LBLHASTAADISOYADI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 1, 143, 6, false);
                    LBLHASTAADISOYADI1.Name = "LBLHASTAADISOYADI1";
                    LBLHASTAADISOYADI1.TextFont.Size = 9;
                    LBLHASTAADISOYADI1.TextFont.Bold = true;
                    LBLHASTAADISOYADI1.TextFont.CharSet = 162;
                    LBLHASTAADISOYADI1.Value = @"Klinik";

                    YATISGUN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 195, 1, 208, 6, false);
                    YATISGUN.Name = "YATISGUN";
                    YATISGUN.TextFont.Bold = true;
                    YATISGUN.TextFont.CharSet = 162;
                    YATISGUN.Value = @"Yatış Gün";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LBLHASTAADISOYADI.CalcValue = LBLHASTAADISOYADI.Value;
                    LBLHASTATCNO.CalcValue = LBLHASTATCNO.Value;
                    LBLHASTAGRUBU.CalcValue = LBLHASTAGRUBU.Value;
                    LBLTABURCUTARIHI.CalcValue = LBLTABURCUTARIHI.Value;
                    LBLSIRANO.CalcValue = LBLSIRANO.Value;
                    LBLTABURCUNO.CalcValue = LBLTABURCUNO.Value;
                    LBLHASTAADISOYADI1.CalcValue = LBLHASTAADISOYADI1.Value;
                    YATISGUN.CalcValue = YATISGUN.Value;
                    return new TTReportObject[] { LBLHASTAADISOYADI,LBLHASTATCNO,LBLHASTAGRUBU,LBLTABURCUTARIHI,LBLSIRANO,LBLTABURCUNO,LBLHASTAADISOYADI1,YATISGUN};
                }
            }
            public partial class BaslikGroupFooter : TTReportSection
            {
                public DischargedPatientByDischargeNumberReport MyParentReport
                {
                    get { return (DischargedPatientByDischargeNumberReport)ParentReport; }
                }
                 
                public BaslikGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public BaslikGroup Baslik;

        public partial class MAINGroup : TTReportGroup
        {
            public DischargedPatientByDischargeNumberReport MyParentReport
            {
                get { return (DischargedPatientByDischargeNumberReport)ParentReport; }
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
            public TTReportField KLINIK { get {return Body().KLINIK;} }
            public TTReportField YATISGUNSAY { get {return Body().YATISGUNSAY;} }
            public TTReportField GIRISTARIHI { get {return Body().GIRISTARIHI;} }
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
                list[0] = new TTReportNqlData<InpatientAdmission.GetDischargedPatientListByDischargeNumber_Class>("GetDischargedPatientListByDischargeNumber2", InpatientAdmission.GetDischargedPatientListByDischargeNumber((long)TTObjectDefManager.Instance.DataTypes["Long"].ConvertValue(MyParentReport.RuntimeParameters.DISCHARGESTARTNO),(long)TTObjectDefManager.Instance.DataTypes["Long"].ConvertValue(MyParentReport.RuntimeParameters.DISCHARGEENDNO),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.Header.FILTER.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.CLINIC),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE)));
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
                public DischargedPatientByDischargeNumberReport MyParentReport
                {
                    get { return (DischargedPatientByDischargeNumberReport)ParentReport; }
                }
                
                public TTReportField COUNTER;
                public TTReportField HASTAADISOYADI;
                public TTReportField TABURCUNO;
                public TTReportField TCKIMLIKNO;
                public TTReportField HASTAGRUBU;
                public TTReportField TABURCUTARIHI;
                public TTReportField HASTAADI;
                public TTReportField HASTASOYADI;
                public TTReportField KLINIK;
                public TTReportField YATISGUNSAY;
                public TTReportField GIRISTARIHI; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    COUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 18, 5, false);
                    COUNTER.Name = "COUNTER";
                    COUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNTER.VertAlign = VerticalAlignmentEnum.vaBottom;
                    COUNTER.TextFont.Size = 9;
                    COUNTER.TextFont.CharSet = 162;
                    COUNTER.Value = @"{@counter@}";

                    HASTAADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 1, 93, 5, false);
                    HASTAADISOYADI.Name = "HASTAADISOYADI";
                    HASTAADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADISOYADI.VertAlign = VerticalAlignmentEnum.vaBottom;
                    HASTAADISOYADI.TextFont.Size = 9;
                    HASTAADISOYADI.TextFont.CharSet = 162;
                    HASTAADISOYADI.Value = @"{%HASTAADI%} {%HASTASOYADI%}";

                    TABURCUNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 1, 34, 5, false);
                    TABURCUNO.Name = "TABURCUNO";
                    TABURCUNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCUNO.VertAlign = VerticalAlignmentEnum.vaBottom;
                    TABURCUNO.TextFont.Size = 9;
                    TABURCUNO.TextFont.CharSet = 162;
                    TABURCUNO.Value = @"{#DISCHARGENUMBER#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 1, 54, 5, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.VertAlign = VerticalAlignmentEnum.vaBottom;
                    TCKIMLIKNO.TextFont.Size = 9;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#TCNO#}";

                    HASTAGRUBU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 1, 174, 5, false);
                    HASTAGRUBU.Name = "HASTAGRUBU";
                    HASTAGRUBU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAGRUBU.VertAlign = VerticalAlignmentEnum.vaBottom;
                    HASTAGRUBU.ObjectDefName = "PatientGroupEnum";
                    HASTAGRUBU.DataMember = "DISPLAYTEXT";
                    HASTAGRUBU.TextFont.Size = 9;
                    HASTAGRUBU.TextFont.CharSet = 162;
                    HASTAGRUBU.Value = @"{#HASTAGRUBU#}";

                    TABURCUTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 1, 195, 5, false);
                    TABURCUTARIHI.Name = "TABURCUTARIHI";
                    TABURCUTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCUTARIHI.TextFormat = @"dd/MM/yyyy";
                    TABURCUTARIHI.VertAlign = VerticalAlignmentEnum.vaBottom;
                    TABURCUTARIHI.TextFont.Size = 9;
                    TABURCUTARIHI.TextFont.CharSet = 162;
                    TABURCUTARIHI.Value = @"{#TABURCUTARIHI#}";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 1, 282, 6, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.Visible = EvetHayirEnum.ehHayir;
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.Value = @"{#HASTAADI#}";

                    HASTASOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 283, 1, 343, 6, false);
                    HASTASOYADI.Name = "HASTASOYADI";
                    HASTASOYADI.Visible = EvetHayirEnum.ehHayir;
                    HASTASOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTASOYADI.Value = @"{#HASTASOYADI#}";

                    KLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 1, 143, 5, false);
                    KLINIK.Name = "KLINIK";
                    KLINIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLINIK.VertAlign = VerticalAlignmentEnum.vaBottom;
                    KLINIK.TextFont.Size = 9;
                    KLINIK.TextFont.CharSet = 162;
                    KLINIK.Value = @"{#KLINIK#}";

                    YATISGUNSAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 196, 1, 209, 5, false);
                    YATISGUNSAY.Name = "YATISGUNSAY";
                    YATISGUNSAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATISGUNSAY.Value = @"";

                    GIRISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 345, 1, 405, 6, false);
                    GIRISTARIHI.Name = "GIRISTARIHI";
                    GIRISTARIHI.Visible = EvetHayirEnum.ehHayir;
                    GIRISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    GIRISTARIHI.Value = @"{#GIRISTARIHI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmission.GetDischargedPatientListByDischargeNumber_Class dataset_GetDischargedPatientListByDischargeNumber2 = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmission.GetDischargedPatientListByDischargeNumber_Class>(0);
                    COUNTER.CalcValue = ParentGroup.Counter.ToString();
                    HASTAADI.CalcValue = (dataset_GetDischargedPatientListByDischargeNumber2 != null ? Globals.ToStringCore(dataset_GetDischargedPatientListByDischargeNumber2.Hastaadi) : "");
                    HASTASOYADI.CalcValue = (dataset_GetDischargedPatientListByDischargeNumber2 != null ? Globals.ToStringCore(dataset_GetDischargedPatientListByDischargeNumber2.Hastasoyadi) : "");
                    HASTAADISOYADI.CalcValue = MyParentReport.MAIN.HASTAADI.CalcValue + @" " + MyParentReport.MAIN.HASTASOYADI.CalcValue;
                    TABURCUNO.CalcValue = (dataset_GetDischargedPatientListByDischargeNumber2 != null ? Globals.ToStringCore(dataset_GetDischargedPatientListByDischargeNumber2.DischargeNumber) : "");
                    TCKIMLIKNO.CalcValue = (dataset_GetDischargedPatientListByDischargeNumber2 != null ? Globals.ToStringCore(dataset_GetDischargedPatientListByDischargeNumber2.Tcno) : "");
                    HASTAGRUBU.CalcValue = (dataset_GetDischargedPatientListByDischargeNumber2 != null ? Globals.ToStringCore(dataset_GetDischargedPatientListByDischargeNumber2.Hastagrubu) : "");
                    HASTAGRUBU.PostFieldValueCalculation();
                    TABURCUTARIHI.CalcValue = (dataset_GetDischargedPatientListByDischargeNumber2 != null ? Globals.ToStringCore(dataset_GetDischargedPatientListByDischargeNumber2.Taburcutarihi) : "");
                    KLINIK.CalcValue = (dataset_GetDischargedPatientListByDischargeNumber2 != null ? Globals.ToStringCore(dataset_GetDischargedPatientListByDischargeNumber2.Klinik) : "");
                    YATISGUNSAY.CalcValue = @"";
                    GIRISTARIHI.CalcValue = (dataset_GetDischargedPatientListByDischargeNumber2 != null ? Globals.ToStringCore(dataset_GetDischargedPatientListByDischargeNumber2.Giristarihi) : "");
                    return new TTReportObject[] { COUNTER,HASTAADI,HASTASOYADI,HASTAADISOYADI,TABURCUNO,TCKIMLIKNO,HASTAGRUBU,TABURCUTARIHI,KLINIK,YATISGUNSAY,GIRISTARIHI};
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

        public DischargedPatientByDischargeNumberReport()
        {
            Header = new HeaderGroup(this,"Header");
            Baslik = new BaslikGroup(Header,"Baslik");
            MAIN = new MAINGroup(Baslik,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "01.01.2012 00:00:00", "Tarih", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("DISCHARGESTARTNO", "0", "Taburcu Başlangıç No", @"", true, true, false, new Guid("b9162297-0afb-43c9-bedc-fac5618f57cd"));
            reportParameter = Parameters.Add("DISCHARGEENDNO", "0", "Taburcu Bitiş No", @"", true, true, false, new Guid("b9162297-0afb-43c9-bedc-fac5618f57cd"));
            reportParameter = Parameters.Add("CLINIC", "", "Klinik", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("a52f989f-de3e-4f47-81ae-2adcf04cf1b3");
            reportParameter = Parameters.Add("PATIENTGROUP", "", "Hasta Grubu", @"", false, true, false, new Guid("026151ea-400a-49cb-83ce-c12cf629e20f"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("DISCHARGESTARTNO"))
                _runtimeParameters.DISCHARGESTARTNO = (long?)TTObjectDefManager.Instance.DataTypes["Long"].ConvertValue(parameters["DISCHARGESTARTNO"]);
            if (parameters.ContainsKey("DISCHARGEENDNO"))
                _runtimeParameters.DISCHARGEENDNO = (long?)TTObjectDefManager.Instance.DataTypes["Long"].ConvertValue(parameters["DISCHARGEENDNO"]);
            if (parameters.ContainsKey("CLINIC"))
                _runtimeParameters.CLINIC = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["CLINIC"]);
            if (parameters.ContainsKey("PATIENTGROUP"))
                _runtimeParameters.PATIENTGROUP = (PatientGroupEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PatientGroupEnum"].ConvertValue(parameters["PATIENTGROUP"]);
            Name = "DISCHARGEDPATIENTBYDISCHARGENUMBERREPORT";
            Caption = "Taburcu Olan Hasta Listesi (Taburcu Numarasına Göre)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
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