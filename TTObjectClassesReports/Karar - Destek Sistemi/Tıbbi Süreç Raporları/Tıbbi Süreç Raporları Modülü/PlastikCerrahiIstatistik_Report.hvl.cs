
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
    /// Plastik Cerrahi İstatistik
    /// </summary>
    public partial class PlastikCerrahiIstatistik : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public string CLINIC = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public PlastikCerrahiIstatistik MyParentReport
            {
                get { return (PlastikCerrahiIstatistik)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField LBLHASTAADISOYADI1 { get {return Header().LBLHASTAADISOYADI1;} }
            public TTReportField LBLHASTATCNO1 { get {return Header().LBLHASTATCNO1;} }
            public TTReportField LBLTABURCUTARIHI1 { get {return Header().LBLTABURCUTARIHI1;} }
            public TTReportField LBLSIRANO1 { get {return Header().LBLSIRANO1;} }
            public TTReportField LBLTABURCUTARIHI11 { get {return Header().LBLTABURCUTARIHI11;} }
            public TTReportField LBLICDCODE1 { get {return Header().LBLICDCODE1;} }
            public TTReportField LBLICDCODE111 { get {return Header().LBLICDCODE111;} }
            public TTReportField LBLICDCODE121 { get {return Header().LBLICDCODE121;} }
            public TTReportField LBLICDCODE131 { get {return Header().LBLICDCODE131;} }
            public TTReportField LBLHASTAYASCINSIYET { get {return Header().LBLHASTAYASCINSIYET;} }
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
                public PlastikCerrahiIstatistik MyParentReport
                {
                    get { return (PlastikCerrahiIstatistik)ParentReport; }
                }
                
                public TTReportField NewField8;
                public TTReportField NewField9;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField LBLHASTAADISOYADI1;
                public TTReportField LBLHASTATCNO1;
                public TTReportField LBLTABURCUTARIHI1;
                public TTReportField LBLSIRANO1;
                public TTReportField LBLTABURCUTARIHI11;
                public TTReportField LBLICDCODE1;
                public TTReportField LBLICDCODE111;
                public TTReportField LBLICDCODE121;
                public TTReportField LBLICDCODE131;
                public TTReportField LBLHASTAYASCINSIYET; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 36, 6, false);
                    NewField8.Name = "NewField8";
                    NewField8.TextFont.Size = 8;
                    NewField8.TextFont.Bold = true;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @"Başlangıç Tarihi:";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 1, 95, 6, false);
                    NewField9.Name = "NewField9";
                    NewField9.TextFont.Size = 8;
                    NewField9.TextFont.Bold = true;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @"Bitiş Tarihi:";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 1, 76, 6, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    STARTDATE.TextFont.Size = 8;
                    STARTDATE.TextFont.Bold = true;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 1, 135, 6, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    ENDDATE.TextFont.Size = 8;
                    ENDDATE.TextFont.Bold = true;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    LBLHASTAADISOYADI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 7, 71, 12, false);
                    LBLHASTAADISOYADI1.Name = "LBLHASTAADISOYADI1";
                    LBLHASTAADISOYADI1.TextFont.Size = 8;
                    LBLHASTAADISOYADI1.TextFont.Bold = true;
                    LBLHASTAADISOYADI1.TextFont.CharSet = 162;
                    LBLHASTAADISOYADI1.Value = @"Hasta Adı Soyadı";

                    LBLHASTATCNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 7, 97, 12, false);
                    LBLHASTATCNO1.Name = "LBLHASTATCNO1";
                    LBLHASTATCNO1.TextFont.Size = 8;
                    LBLHASTATCNO1.TextFont.Bold = true;
                    LBLHASTATCNO1.TextFont.CharSet = 162;
                    LBLHASTATCNO1.Value = @"TC Kimlik No ";

                    LBLTABURCUTARIHI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 7, 161, 12, false);
                    LBLTABURCUTARIHI1.Name = "LBLTABURCUTARIHI1";
                    LBLTABURCUTARIHI1.TextFont.Size = 8;
                    LBLTABURCUTARIHI1.TextFont.Bold = true;
                    LBLTABURCUTARIHI1.TextFont.CharSet = 162;
                    LBLTABURCUTARIHI1.Value = @"Taburcu Tarihi";

                    LBLSIRANO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 7, 19, 12, false);
                    LBLSIRANO1.Name = "LBLSIRANO1";
                    LBLSIRANO1.TextFont.Size = 8;
                    LBLSIRANO1.TextFont.Bold = true;
                    LBLSIRANO1.TextFont.CharSet = 162;
                    LBLSIRANO1.Value = @"Sıra No";

                    LBLTABURCUTARIHI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 7, 139, 12, false);
                    LBLTABURCUTARIHI11.Name = "LBLTABURCUTARIHI11";
                    LBLTABURCUTARIHI11.TextFont.Size = 8;
                    LBLTABURCUTARIHI11.TextFont.Bold = true;
                    LBLTABURCUTARIHI11.TextFont.CharSet = 162;
                    LBLTABURCUTARIHI11.Value = @"Yatış Tarihi";

                    LBLICDCODE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 7, 211, 12, false);
                    LBLICDCODE1.Name = "LBLICDCODE1";
                    LBLICDCODE1.TextFont.Size = 8;
                    LBLICDCODE1.TextFont.Bold = true;
                    LBLICDCODE1.TextFont.CharSet = 162;
                    LBLICDCODE1.Value = @"ICD Kodu";

                    LBLICDCODE111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 7, 233, 12, false);
                    LBLICDCODE111.Name = "LBLICDCODE111";
                    LBLICDCODE111.TextFont.Size = 8;
                    LBLICDCODE111.TextFont.Bold = true;
                    LBLICDCODE111.TextFont.CharSet = 162;
                    LBLICDCODE111.Value = @"Ameliyat Tarihi";

                    LBLICDCODE121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 7, 255, 12, false);
                    LBLICDCODE121.Name = "LBLICDCODE121";
                    LBLICDCODE121.TextFont.Size = 8;
                    LBLICDCODE121.TextFont.Bold = true;
                    LBLICDCODE121.TextFont.CharSet = 162;
                    LBLICDCODE121.Value = @"Muayene Tarihi";

                    LBLICDCODE131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 7, 288, 12, false);
                    LBLICDCODE131.Name = "LBLICDCODE131";
                    LBLICDCODE131.TextFont.Size = 8;
                    LBLICDCODE131.TextFont.Bold = true;
                    LBLICDCODE131.TextFont.CharSet = 162;
                    LBLICDCODE131.Value = @"İşlemi Yapan Doktor";

                    LBLHASTAYASCINSIYET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 7, 120, 12, false);
                    LBLHASTAYASCINSIYET.Name = "LBLHASTAYASCINSIYET";
                    LBLHASTAYASCINSIYET.TextFont.Size = 8;
                    LBLHASTAYASCINSIYET.TextFont.Bold = true;
                    LBLHASTAYASCINSIYET.TextFont.CharSet = 162;
                    LBLHASTAYASCINSIYET.Value = @"Yaşı / Cinsiyeti";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField8.CalcValue = NewField8.Value;
                    NewField9.CalcValue = NewField9.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    LBLHASTAADISOYADI1.CalcValue = LBLHASTAADISOYADI1.Value;
                    LBLHASTATCNO1.CalcValue = LBLHASTATCNO1.Value;
                    LBLTABURCUTARIHI1.CalcValue = LBLTABURCUTARIHI1.Value;
                    LBLSIRANO1.CalcValue = LBLSIRANO1.Value;
                    LBLTABURCUTARIHI11.CalcValue = LBLTABURCUTARIHI11.Value;
                    LBLICDCODE1.CalcValue = LBLICDCODE1.Value;
                    LBLICDCODE111.CalcValue = LBLICDCODE111.Value;
                    LBLICDCODE121.CalcValue = LBLICDCODE121.Value;
                    LBLICDCODE131.CalcValue = LBLICDCODE131.Value;
                    LBLHASTAYASCINSIYET.CalcValue = LBLHASTAYASCINSIYET.Value;
                    return new TTReportObject[] { NewField8,NewField9,STARTDATE,ENDDATE,LBLHASTAADISOYADI1,LBLHASTATCNO1,LBLTABURCUTARIHI1,LBLSIRANO1,LBLTABURCUTARIHI11,LBLICDCODE1,LBLICDCODE111,LBLICDCODE121,LBLICDCODE131,LBLHASTAYASCINSIYET};
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public PlastikCerrahiIstatistik MyParentReport
                {
                    get { return (PlastikCerrahiIstatistik)ParentReport; }
                }
                 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HeaderGroup Header;

        public partial class MAINGroup : TTReportGroup
        {
            public PlastikCerrahiIstatistik MyParentReport
            {
                get { return (PlastikCerrahiIstatistik)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNTER { get {return Body().COUNTER;} }
            public TTReportField HASTAADISOYADI { get {return Body().HASTAADISOYADI;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField TABURCUTARIHI { get {return Body().TABURCUTARIHI;} }
            public TTReportField HASTAADI { get {return Body().HASTAADI;} }
            public TTReportField HASTASOYADI { get {return Body().HASTASOYADI;} }
            public TTReportField GIRISTARIHI { get {return Body().GIRISTARIHI;} }
            public TTReportField YATISTARIHI { get {return Body().YATISTARIHI;} }
            public TTReportField ICDCODE { get {return Body().ICDCODE;} }
            public TTReportField SURGERYDATE { get {return Body().SURGERYDATE;} }
            public TTReportField EXAMINATIONDATE { get {return Body().EXAMINATIONDATE;} }
            public TTReportField PROCEDUREDOCTOR { get {return Body().PROCEDUREDOCTOR;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField YASCINSIYET { get {return Body().YASCINSIYET;} }
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
                list[0] = new TTReportNqlData<InpatientAdmission.PlastikCerrahiIstatistik_Class>("PlastikCerrahiIstatistik", InpatientAdmission.PlastikCerrahiIstatistik((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.CLINIC)));
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
                public PlastikCerrahiIstatistik MyParentReport
                {
                    get { return (PlastikCerrahiIstatistik)ParentReport; }
                }
                
                public TTReportField COUNTER;
                public TTReportField HASTAADISOYADI;
                public TTReportField TCKIMLIKNO;
                public TTReportField TABURCUTARIHI;
                public TTReportField HASTAADI;
                public TTReportField HASTASOYADI;
                public TTReportField GIRISTARIHI;
                public TTReportField YATISTARIHI;
                public TTReportField ICDCODE;
                public TTReportField SURGERYDATE;
                public TTReportField EXAMINATIONDATE;
                public TTReportField PROCEDUREDOCTOR;
                public TTReportField OBJECTID;
                public TTReportField YASCINSIYET; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    COUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 19, 6, false);
                    COUNTER.Name = "COUNTER";
                    COUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNTER.TextFont.Size = 8;
                    COUNTER.TextFont.CharSet = 162;
                    COUNTER.Value = @"{@counter@}";

                    HASTAADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 71, 6, false);
                    HASTAADISOYADI.Name = "HASTAADISOYADI";
                    HASTAADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADISOYADI.TextFont.Size = 8;
                    HASTAADISOYADI.TextFont.CharSet = 162;
                    HASTAADISOYADI.Value = @"{%HASTAADI%} {%HASTASOYADI%}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 1, 97, 6, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#TCNO#}";

                    TABURCUTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 1, 161, 6, false);
                    TABURCUTARIHI.Name = "TABURCUTARIHI";
                    TABURCUTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCUTARIHI.TextFormat = @"dd/MM/yyyy";
                    TABURCUTARIHI.TextFont.Size = 8;
                    TABURCUTARIHI.TextFont.CharSet = 162;
                    TABURCUTARIHI.Value = @"{#TABURCUTARIHI#}";

                    HASTAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 299, 1, 310, 6, false);
                    HASTAADI.Name = "HASTAADI";
                    HASTAADI.Visible = EvetHayirEnum.ehHayir;
                    HASTAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAADI.TextFont.Size = 8;
                    HASTAADI.TextFont.CharSet = 162;
                    HASTAADI.Value = @"{#HASTAADI#}";

                    HASTASOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 311, 1, 322, 6, false);
                    HASTASOYADI.Name = "HASTASOYADI";
                    HASTASOYADI.Visible = EvetHayirEnum.ehHayir;
                    HASTASOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTASOYADI.TextFont.Size = 8;
                    HASTASOYADI.TextFont.CharSet = 162;
                    HASTASOYADI.Value = @"{#HASTASOYADI#}";

                    GIRISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 345, 1, 370, 6, false);
                    GIRISTARIHI.Name = "GIRISTARIHI";
                    GIRISTARIHI.Visible = EvetHayirEnum.ehHayir;
                    GIRISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    GIRISTARIHI.TextFormat = @"Short Date";
                    GIRISTARIHI.TextFont.Size = 8;
                    GIRISTARIHI.TextFont.CharSet = 162;
                    GIRISTARIHI.Value = @"{#GIRISTARIHI#}";

                    YATISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 1, 139, 6, false);
                    YATISTARIHI.Name = "YATISTARIHI";
                    YATISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATISTARIHI.TextFormat = @"dd/MM/yyyy";
                    YATISTARIHI.TextFont.Size = 8;
                    YATISTARIHI.TextFont.CharSet = 162;
                    YATISTARIHI.Value = @"{#GIRISTARIHI#}";

                    ICDCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 1, 211, 6, false);
                    ICDCODE.Name = "ICDCODE";
                    ICDCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ICDCODE.TextFont.Size = 8;
                    ICDCODE.TextFont.CharSet = 162;
                    ICDCODE.Value = @"";

                    SURGERYDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 1, 233, 6, false);
                    SURGERYDATE.Name = "SURGERYDATE";
                    SURGERYDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURGERYDATE.TextFormat = @"dd/MM/yyyy";
                    SURGERYDATE.TextFont.Size = 8;
                    SURGERYDATE.TextFont.CharSet = 162;
                    SURGERYDATE.Value = @"";

                    EXAMINATIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 1, 255, 6, false);
                    EXAMINATIONDATE.Name = "EXAMINATIONDATE";
                    EXAMINATIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXAMINATIONDATE.TextFormat = @"dd/MM/yyyy";
                    EXAMINATIONDATE.TextFont.Size = 8;
                    EXAMINATIONDATE.TextFont.CharSet = 162;
                    EXAMINATIONDATE.Value = @"";

                    PROCEDUREDOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 1, 288, 6, false);
                    PROCEDUREDOCTOR.Name = "PROCEDUREDOCTOR";
                    PROCEDUREDOCTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREDOCTOR.TextFormat = @"dd/MM/yyyy";
                    PROCEDUREDOCTOR.TextFont.Size = 8;
                    PROCEDUREDOCTOR.TextFont.CharSet = 162;
                    PROCEDUREDOCTOR.Value = @"{#PROCEDUREDOCTORNAME#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 372, 1, 397, 6, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.TextFont.Size = 8;
                    OBJECTID.TextFont.CharSet = 162;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    YASCINSIYET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 1, 120, 6, false);
                    YASCINSIYET.Name = "YASCINSIYET";
                    YASCINSIYET.FieldType = ReportFieldTypeEnum.ftExpression;
                    YASCINSIYET.TextFont.Size = 8;
                    YASCINSIYET.TextFont.CharSet = 162;
                    YASCINSIYET.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmission.PlastikCerrahiIstatistik_Class dataset_PlastikCerrahiIstatistik = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmission.PlastikCerrahiIstatistik_Class>(0);
                    COUNTER.CalcValue = ParentGroup.Counter.ToString();
                    HASTAADI.CalcValue = (dataset_PlastikCerrahiIstatistik != null ? Globals.ToStringCore(dataset_PlastikCerrahiIstatistik.Hastaadi) : "");
                    HASTASOYADI.CalcValue = (dataset_PlastikCerrahiIstatistik != null ? Globals.ToStringCore(dataset_PlastikCerrahiIstatistik.Hastasoyadi) : "");
                    HASTAADISOYADI.CalcValue = MyParentReport.MAIN.HASTAADI.CalcValue + @" " + MyParentReport.MAIN.HASTASOYADI.CalcValue;
                    TCKIMLIKNO.CalcValue = (dataset_PlastikCerrahiIstatistik != null ? Globals.ToStringCore(dataset_PlastikCerrahiIstatistik.Tcno) : "");
                    TABURCUTARIHI.CalcValue = (dataset_PlastikCerrahiIstatistik != null ? Globals.ToStringCore(dataset_PlastikCerrahiIstatistik.Taburcutarihi) : "");
                    GIRISTARIHI.CalcValue = (dataset_PlastikCerrahiIstatistik != null ? Globals.ToStringCore(dataset_PlastikCerrahiIstatistik.Giristarihi) : "");
                    YATISTARIHI.CalcValue = (dataset_PlastikCerrahiIstatistik != null ? Globals.ToStringCore(dataset_PlastikCerrahiIstatistik.Giristarihi) : "");
                    ICDCODE.CalcValue = @"";
                    SURGERYDATE.CalcValue = @"";
                    EXAMINATIONDATE.CalcValue = @"";
                    PROCEDUREDOCTOR.CalcValue = (dataset_PlastikCerrahiIstatistik != null ? Globals.ToStringCore(dataset_PlastikCerrahiIstatistik.Proceduredoctorname) : "");
                    OBJECTID.CalcValue = (dataset_PlastikCerrahiIstatistik != null ? Globals.ToStringCore(dataset_PlastikCerrahiIstatistik.ObjectID) : "");
                    YASCINSIYET.CalcValue = @"";
                    return new TTReportObject[] { COUNTER,HASTAADI,HASTASOYADI,HASTAADISOYADI,TCKIMLIKNO,TABURCUTARIHI,GIRISTARIHI,YATISTARIHI,ICDCODE,SURGERYDATE,EXAMINATIONDATE,PROCEDUREDOCTOR,OBJECTID,YASCINSIYET};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.OBJECTID.CalcValue.ToString();
            InpatientAdmission pObject = (InpatientAdmission)context.GetObject(new Guid(sObjectID),"INPATIENTADMISSION");

            DiagnosisDefinition diagnosisDefinition = null;
            if (pObject.Episode.Diagnosis.Count == 0)
                return;
            else
                diagnosisDefinition = pObject.Episode.Diagnosis[0].Diagnose;

            foreach (DiagnosisGrid dg in pObject.Episode.Diagnosis)
            {
                if (dg.IsMainDiagnose != null)
                {
                    if ((bool)dg.IsMainDiagnose)
                        diagnosisDefinition = dg.Diagnose;
                }
            }
            this.ICDCODE.CalcValue = diagnosisDefinition.Code + " - " + diagnosisDefinition.Name;
            Surgery surgery = null;
            if(pObject.Episode.Surgeries.Count > 0)
            {
                surgery = (Surgery)pObject.Episode.Surgeries[0];
                if(surgery.SurgeryStartTime != null)
                    this.SURGERYDATE.CalcValue =  surgery.SurgeryStartTime.ToString();
            }
            
            PatientExamination patientExamination = null;
            if(pObject.Episode.PatientExaminations.Count > 0)
            {
                patientExamination = (PatientExamination)pObject.Episode.PatientExaminations[0];
                if (patientExamination.ProcessDate != null)
                    this.EXAMINATIONDATE.CalcValue = patientExamination.ProcessDate.ToString();
            }
            
         // this.YASCINSIYET.CalcValue = pObject.Episode.Patient.Age.ToString() + " / " + (pObject.Episode.Patient.Sex == SexEnum.Female ? "Kadın" :  pObject.Episode.Patient.Sex == SexEnum.Male ? "Erkek" : "Belirlenmemiş");
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

        public PlastikCerrahiIstatistik()
        {
            Header = new HeaderGroup(this,"Header");
            MAIN = new MAINGroup(Header,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("CLINIC", "", "Klinik", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("20fdb56a-389f-46c9-8cd5-f604eddab75f");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("CLINIC"))
                _runtimeParameters.CLINIC = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["CLINIC"]);
            Name = "PLASTIKCERRAHIISTATISTIK";
            Caption = "Plastik Cerrahi İstatistik";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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