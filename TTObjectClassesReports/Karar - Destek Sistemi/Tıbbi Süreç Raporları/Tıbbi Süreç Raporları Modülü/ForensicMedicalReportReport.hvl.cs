
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
    /// Adli Tıp Raporu
    /// </summary>
    public partial class ForensicMedicalReportReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public ForensicMedicalReportReport MyParentReport
            {
                get { return (ForensicMedicalReportReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField HIZMETEOZEL { get {return Footer().HIZMETEOZEL;} }
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
                public ForensicMedicalReportReport MyParentReport
                {
                    get { return (ForensicMedicalReportReport)ParentReport; }
                }
                 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public ForensicMedicalReportReport MyParentReport
                {
                    get { return (ForensicMedicalReportReport)ParentReport; }
                }
                
                public TTReportField HIZMETEOZEL; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 22;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    HIZMETEOZEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 12, 36, 18, false);
                    HIZMETEOZEL.Name = "HIZMETEOZEL";
                    HIZMETEOZEL.TextFont.Underline = true;
                    HIZMETEOZEL.Value = @"HİZMETE ÖZEL";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HIZMETEOZEL.CalcValue = HIZMETEOZEL.Value;
                    return new TTReportObject[] { HIZMETEOZEL};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class NOTGroup : TTReportGroup
        {
            public ForensicMedicalReportReport MyParentReport
            {
                get { return (ForensicMedicalReportReport)ParentReport; }
            }

            new public NOTGroupHeader Header()
            {
                return (NOTGroupHeader)_header;
            }

            new public NOTGroupFooter Footer()
            {
                return (NOTGroupFooter)_footer;
            }

            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField SAG { get {return Header().SAG;} }
            public TTReportField KONU { get {return Header().KONU;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField BABAAD { get {return Header().BABAAD;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField RAPORTARIH { get {return Header().RAPORTARIH;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField NewField23 { get {return Header().NewField23;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField NewField35 { get {return Header().NewField35;} }
            public TTReportField NewField36 { get {return Header().NewField36;} }
            public TTReportField NewField37 { get {return Header().NewField37;} }
            public TTReportField NewField38 { get {return Header().NewField38;} }
            public TTReportShape NewLine { get {return Header().NewLine;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportField NewField0 { get {return Header().NewField0;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportField PNAME { get {return Header().PNAME;} }
            public TTReportField SURNAME { get {return Header().SURNAME;} }
            public TTReportField MAKAM { get {return Header().MAKAM;} }
            public TTReportField EVRAKSAYISI { get {return Header().EVRAKSAYISI;} }
            public TTReportField EVRAKTARIHI { get {return Header().EVRAKTARIHI;} }
            public TTReportField SITENAME { get {return Header().SITENAME;} }
            public TTReportField SITECITY { get {return Header().SITECITY;} }
            public TTReportField ACTIONDATE { get {return Header().ACTIONDATE;} }
            public TTReportField BIRIMPROTOKOL { get {return Header().BIRIMPROTOKOL;} }
            public TTReportField ACTIONID { get {return Header().ACTIONID;} }
            public TTReportField BIRIMADI { get {return Header().BIRIMADI;} }
            public TTReportField RAPORTIPI { get {return Header().RAPORTIPI;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField PROTOKOLNO { get {return Header().PROTOKOLNO;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField KURUM { get {return Header().KURUM;} }
            public TTReportField FIELDONAY { get {return Footer().FIELDONAY;} }
            public TTReportField USERNAME { get {return Footer().USERNAME;} }
            public TTReportShape NewLineFooter { get {return Footer().NewLineFooter;} }
            public TTReportField BASHEKIM { get {return Footer().BASHEKIM;} }
            public TTReportField UZ { get {return Footer().UZ;} }
            public TTReportField HEADDOCTOR { get {return Footer().HEADDOCTOR;} }
            public TTReportField HEADDOCTORTITAL { get {return Footer().HEADDOCTORTITAL;} }
            public NOTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public NOTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ForensicMedicalReport.GetForensicMedicalReport_Class>("GetForensicMedicalReport", ForensicMedicalReport.GetForensicMedicalReport((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new NOTGroupHeader(this);
                _footer = new NOTGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class NOTGroupHeader : TTReportSection
            {
                public ForensicMedicalReportReport MyParentReport
                {
                    get { return (ForensicMedicalReportReport)ParentReport; }
                }
                
                public TTReportField HEADER;
                public TTReportField DATE;
                public TTReportField SAG;
                public TTReportField KONU;
                public TTReportField NewField8;
                public TTReportField NewField9;
                public TTReportField BABAAD;
                public TTReportField ADSOYAD;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField RAPORTARIH;
                public TTReportField NewField21;
                public TTReportField NewField22;
                public TTReportField NewField23;
                public TTReportField RAPORNO;
                public TTReportField NewField35;
                public TTReportField NewField36;
                public TTReportField NewField37;
                public TTReportField NewField38;
                public TTReportShape NewLine;
                public TTReportShape NewLine2;
                public TTReportField NewField0;
                public TTReportShape NewLine3;
                public TTReportField PNAME;
                public TTReportField SURNAME;
                public TTReportField MAKAM;
                public TTReportField EVRAKSAYISI;
                public TTReportField EVRAKTARIHI;
                public TTReportField SITENAME;
                public TTReportField SITECITY;
                public TTReportField ACTIONDATE;
                public TTReportField BIRIMPROTOKOL;
                public TTReportField ACTIONID;
                public TTReportField BIRIMADI;
                public TTReportField RAPORTIPI;
                public TTReportField NewField16;
                public TTReportField PROTOKOLNO;
                public TTReportField NewField171;
                public TTReportField KURUM; 
                public NOTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 94;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 5, 167, 27, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftExpression;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.WordBreak = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Bold = true;
                    HEADER.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 29, 204, 33, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"dd/MM/yyyy";
                    DATE.Value = @"{@printdate@}";

                    SAG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 30, 155, 34, false);
                    SAG.Name = "SAG";
                    SAG.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAG.Value = @"SAĞ:9067-{%BIRIMPROTOKOL%}-{%ACTIONDATE%}/{%BIRIMADI%}-{%ACTIONID%}";

                    KONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 34, 156, 38, false);
                    KONU.Name = "KONU";
                    KONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KONU.Value = @"KONU:Adli Rapor";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 66, 60, 70, false);
                    NewField8.Name = "NewField8";
                    NewField8.Value = @"Sınıf ve Rütbesi";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 76, 60, 80, false);
                    NewField9.Name = "NewField9";
                    NewField9.Value = @"Doğum Yeri ve Tarihi";

                    BABAAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 71, 166, 75, false);
                    BABAAD.Name = "BABAAD";
                    BABAAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAAD.ObjectDefName = "Patient";
                    BABAAD.DataMember = "FATHERNAME";
                    BABAAD.Value = @"{#PATIENTID#}";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 61, 166, 65, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.Value = @"{%PNAME%} {%SURNAME%}";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 61, 60, 65, false);
                    NewField12.Name = "NewField12";
                    NewField12.Value = @"Adı Soyadı";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 66, 62, 70, false);
                    NewField13.Name = "NewField13";
                    NewField13.Value = @":";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 61, 62, 65, false);
                    NewField14.Name = "NewField14";
                    NewField14.Value = @":";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 71, 60, 75, false);
                    NewField15.Name = "NewField15";
                    NewField15.Value = @"Baba Adı";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 76, 62, 80, false);
                    NewField17.Name = "NewField17";
                    NewField17.Value = @":";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 71, 62, 75, false);
                    NewField18.Name = "NewField18";
                    NewField18.Value = @":";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 46, 60, 50, false);
                    NewField19.Name = "NewField19";
                    NewField19.Value = @"Rapor Tarihi";

                    RAPORTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 46, 101, 50, false);
                    RAPORTARIH.Name = "RAPORTARIH";
                    RAPORTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIH.TextFormat = @"dd/MM/yyyy";
                    RAPORTARIH.Value = @"{#ACTIONDATE#}";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 46, 62, 50, false);
                    NewField21.Name = "NewField21";
                    NewField21.Value = @":";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 51, 62, 55, false);
                    NewField22.Name = "NewField22";
                    NewField22.Value = @":";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 51, 60, 55, false);
                    NewField23.Name = "NewField23";
                    NewField23.Value = @"Rapor No";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 51, 101, 55, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.Value = @"{#REPORTNO#}";

                    NewField35 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 81, 60, 85, false);
                    NewField35.Name = "NewField35";
                    NewField35.Value = @"Muayeneye Gönderen Makam";

                    NewField36 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 81, 62, 85, false);
                    NewField36.Name = "NewField36";
                    NewField36.Value = @":";

                    NewField37 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 81, 189, 85, false);
                    NewField37.Name = "NewField37";
                    NewField37.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField37.Value = @"{%MAKAM%}'nın";

                    NewField38 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 86, 204, 94, false);
                    NewField38.Name = "NewField38";
                    NewField38.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField38.MultiLine = EvetHayirEnum.ehEvet;
                    NewField38.NoClip = EvetHayirEnum.ehEvet;
                    NewField38.WordBreak = EvetHayirEnum.ehEvet;
                    NewField38.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField38.Value = @"{%EVRAKTARIHI%} gün ve {%EVRAKSAYISI%} sayılı yazısı.";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 44, 204, 44, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 94, 204, 94, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 10, 34, 14, false);
                    NewField0.Name = "NewField0";
                    NewField0.Value = @"HİZMETE ÖZEL";

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 14, 34, 14, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    PNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 35, 203, 40, false);
                    PNAME.Name = "PNAME";
                    PNAME.Visible = EvetHayirEnum.ehHayir;
                    PNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PNAME.ObjectDefName = "Patient";
                    PNAME.DataMember = "NAME";
                    PNAME.Value = @"{#PATIENTID#}";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 39, 203, 44, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.Visible = EvetHayirEnum.ehHayir;
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.ObjectDefName = "Patient";
                    SURNAME.DataMember = "SURNAME";
                    SURNAME.Value = @"{#PATIENTID#}";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 61, 202, 66, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.Visible = EvetHayirEnum.ehHayir;
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.Value = @"{#MAKAM#}";

                    EVRAKSAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 67, 202, 72, false);
                    EVRAKSAYISI.Name = "EVRAKSAYISI";
                    EVRAKSAYISI.Visible = EvetHayirEnum.ehHayir;
                    EVRAKSAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVRAKSAYISI.Value = @"{#DOCUMENTNUMBER#}";

                    EVRAKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 18, 200, 23, false);
                    EVRAKTARIHI.Name = "EVRAKTARIHI";
                    EVRAKTARIHI.Visible = EvetHayirEnum.ehHayir;
                    EVRAKTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVRAKTARIHI.Value = @"{#DOCUMENTDATE#}";

                    SITENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 4, 199, 9, false);
                    SITENAME.Name = "SITENAME";
                    SITENAME.Visible = EvetHayirEnum.ehHayir;
                    SITENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", ""XXXXXX"")";

                    SITECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 10, 200, 15, false);
                    SITECITY.Name = "SITECITY";
                    SITECITY.Visible = EvetHayirEnum.ehHayir;
                    SITECITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITECITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", ""XXXXXX"")";

                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 59, 236, 64, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.Visible = EvetHayirEnum.ehHayir;
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.Value = @"{#ACTIONDATE#}";

                    BIRIMPROTOKOL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 66, 238, 71, false);
                    BIRIMPROTOKOL.Name = "BIRIMPROTOKOL";
                    BIRIMPROTOKOL.Visible = EvetHayirEnum.ehHayir;
                    BIRIMPROTOKOL.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMPROTOKOL.Value = @"{#PROTOCOLNO#}";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 74, 237, 79, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.Visible = EvetHayirEnum.ehHayir;
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.Value = @"{#ACTIONID#}";

                    BIRIMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 80, 237, 85, false);
                    BIRIMADI.Name = "BIRIMADI";
                    BIRIMADI.Visible = EvetHayirEnum.ehHayir;
                    BIRIMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMADI.Value = @"{#BIRIMADI#}";

                    RAPORTIPI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 39, 126, 43, false);
                    RAPORTIPI.Name = "RAPORTIPI";
                    RAPORTIPI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPORTIPI.TextFont.Bold = true;
                    RAPORTIPI.Value = @"Adli Muayene Raporu";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 56, 62, 60, false);
                    NewField16.Name = "NewField16";
                    NewField16.Value = @"Protokol No";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 56, 101, 60, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.Value = @"{#PROTOCOLNO#}";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 56, 62, 60, false);
                    NewField171.Name = "NewField171";
                    NewField171.Value = @":";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 18, 36, 23, false);
                    KURUM.Name = "KURUM";
                    KURUM.Visible = EvetHayirEnum.ehHayir;
                    KURUM.FieldType = ReportFieldTypeEnum.ftExpression;
                    KURUM.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""RAPORKURUMU"", ""T.C. XXXXXX"")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ForensicMedicalReport.GetForensicMedicalReport_Class dataset_GetForensicMedicalReport = ParentGroup.rsGroup.GetCurrentRecord<ForensicMedicalReport.GetForensicMedicalReport_Class>(0);
                    DATE.CalcValue = DateTime.Now.ToShortDateString();
                    BIRIMPROTOKOL.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.ProtocolNo) : "");
                    ACTIONDATE.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.ActionDate) : "");
                    BIRIMADI.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Birimadi) : "");
                    ACTIONID.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Actionid) : "");
                    SAG.CalcValue = @"SAĞ:9067-" + MyParentReport.NOT.BIRIMPROTOKOL.CalcValue + @"-" + MyParentReport.NOT.ACTIONDATE.CalcValue + @"/" + MyParentReport.NOT.BIRIMADI.CalcValue + @"-" + MyParentReport.NOT.ACTIONID.CalcValue;
                    KONU.CalcValue = @"KONU:Adli Rapor";
                    NewField8.CalcValue = NewField8.Value;
                    NewField9.CalcValue = NewField9.Value;
                    BABAAD.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Patientid) : "");
                    BABAAD.PostFieldValueCalculation();
                    PNAME.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Patientid) : "");
                    PNAME.PostFieldValueCalculation();
                    SURNAME.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Patientid) : "");
                    SURNAME.PostFieldValueCalculation();
                    ADSOYAD.CalcValue = MyParentReport.NOT.PNAME.CalcValue + @" " + MyParentReport.NOT.SURNAME.CalcValue;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    RAPORTARIH.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.ActionDate) : "");
                    NewField21.CalcValue = NewField21.Value;
                    NewField22.CalcValue = NewField22.Value;
                    NewField23.CalcValue = NewField23.Value;
                    RAPORNO.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.ReportNo) : "");
                    NewField35.CalcValue = NewField35.Value;
                    NewField36.CalcValue = NewField36.Value;
                    MAKAM.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.Makam) : "");
                    NewField37.CalcValue = MyParentReport.NOT.MAKAM.CalcValue + @"'nın";
                    EVRAKTARIHI.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.DocumentDate) : "");
                    EVRAKSAYISI.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.DocumentNumber) : "");
                    NewField38.CalcValue = MyParentReport.NOT.EVRAKTARIHI.CalcValue + @" gün ve " + MyParentReport.NOT.EVRAKSAYISI.CalcValue + @" sayılı yazısı.";
                    NewField0.CalcValue = NewField0.Value;
                    RAPORTIPI.CalcValue = RAPORTIPI.Value;
                    NewField16.CalcValue = NewField16.Value;
                    PROTOKOLNO.CalcValue = (dataset_GetForensicMedicalReport != null ? Globals.ToStringCore(dataset_GetForensicMedicalReport.ProtocolNo) : "");
                    NewField171.CalcValue = NewField171.Value;
                    HEADER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    SITENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "XXXXXX");
                    SITECITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "XXXXXX");
                    KURUM.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("RAPORKURUMU", "T.C. XXXXXX");
                    return new TTReportObject[] { DATE,BIRIMPROTOKOL,ACTIONDATE,BIRIMADI,ACTIONID,SAG,KONU,NewField8,NewField9,BABAAD,PNAME,SURNAME,ADSOYAD,NewField12,NewField13,NewField14,NewField15,NewField17,NewField18,NewField19,RAPORTARIH,NewField21,NewField22,NewField23,RAPORNO,NewField35,NewField36,MAKAM,NewField37,EVRAKTARIHI,EVRAKSAYISI,NewField38,NewField0,RAPORTIPI,NewField16,PROTOKOLNO,NewField171,HEADER,SITENAME,SITECITY,KURUM};
                }
            }
            public partial class NOTGroupFooter : TTReportSection
            {
                public ForensicMedicalReportReport MyParentReport
                {
                    get { return (ForensicMedicalReportReport)ParentReport; }
                }
                
                public TTReportField FIELDONAY;
                public TTReportField USERNAME;
                public TTReportShape NewLineFooter;
                public TTReportField BASHEKIM;
                public TTReportField UZ;
                public TTReportField HEADDOCTOR;
                public TTReportField HEADDOCTORTITAL; 
                public NOTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 61;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    FIELDONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 28, 196, 35, false);
                    FIELDONAY.Name = "FIELDONAY";
                    FIELDONAY.MultiLine = EvetHayirEnum.ehEvet;
                    FIELDONAY.WordBreak = EvetHayirEnum.ehEvet;
                    FIELDONAY.Value = @"ONAY
";

                    USERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 11, 133, 15, false);
                    USERNAME.Name = "USERNAME";
                    USERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    USERNAME.Value = @"";

                    NewLineFooter = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 204, 1, false);
                    NewLineFooter.Name = "NewLineFooter";
                    NewLineFooter.DrawStyle = DrawStyleConstants.vbSolid;

                    BASHEKIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 35, 196, 54, false);
                    BASHEKIM.Name = "BASHEKIM";
                    BASHEKIM.MultiLine = EvetHayirEnum.ehEvet;
                    BASHEKIM.WordBreak = EvetHayirEnum.ehEvet;
                    BASHEKIM.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASHEKIM.Value = @"";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 23, 133, 27, false);
                    UZ.Name = "UZ";
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.Value = @"";

                    HEADDOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 18, 173, 23, false);
                    HEADDOCTOR.Name = "HEADDOCTOR";
                    HEADDOCTOR.Visible = EvetHayirEnum.ehHayir;
                    HEADDOCTOR.FieldType = ReportFieldTypeEnum.ftExpression;
                    HEADDOCTOR.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HEADDOCTOR"", """")";

                    HEADDOCTORTITAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 12, 187, 17, false);
                    HEADDOCTORTITAL.Name = "HEADDOCTORTITAL";
                    HEADDOCTORTITAL.Visible = EvetHayirEnum.ehHayir;
                    HEADDOCTORTITAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    HEADDOCTORTITAL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HEADDOCTORTITAL"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ForensicMedicalReport.GetForensicMedicalReport_Class dataset_GetForensicMedicalReport = ParentGroup.rsGroup.GetCurrentRecord<ForensicMedicalReport.GetForensicMedicalReport_Class>(0);
                    FIELDONAY.CalcValue = FIELDONAY.Value;
                    USERNAME.CalcValue = @"";
                    BASHEKIM.CalcValue = BASHEKIM.Value;
                    UZ.CalcValue = @"";
                    HEADDOCTOR.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR", "");
                    HEADDOCTORTITAL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTORTITAL", "");
                    return new TTReportObject[] { FIELDONAY,USERNAME,BASHEKIM,UZ,HEADDOCTOR,HEADDOCTORTITAL};
                }

                public override void RunScript()
                {
#region NOT FOOTER_Script
                    //            string sObjectID = ((TTReportClasses.ForensicMedicalReportReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            
//            TTObjectContext context = new TTObjectContext(true);//yeni context oluşturduk
//            BindingList<TTObjectClasses.ForensicMedicalReport> actions = TTObjectClasses.ForensicMedicalReport.GetForensicMedicalReportByID(context, sObjectID);
//            if(actions.Count > 0)
//            {
//                TTObjectClasses.ForensicMedicalReport theObj = actions[0];
//                if (theObj.ProcedureDoctor!=null)
//                {
//                    //                    this.USERNAME.CalcValue = theObj.ProcedureDoctor.Person.Name + " "  + theObj.ProcedureDoctor.Person.Surname;
//                    //                    if(theObj.ProcedureDoctor.MilitaryClass != null)
//                    //                        this.SINIFONAYRUTBEONAY.CalcValue = theObj.ProcedureDoctor.MilitaryClass.Name;
//                    //                    if(theObj.ProcedureDoctor.Rank != null)
//                    //                        this.SINIFONAYRUTBEONAY.CalcValue += " " + theObj.ProcedureDoctor.Rank.Name;
//                    //                    this.UZ.CalcValue = theObj.ProcedureDoctor.Title.ToString();
//                    this.USERNAME.CalcValue = theObj.ProcedureDoctor.Name;
//                    if(this.SICILKULLAN.CalcValue=="TRUE")
//                    {
//                        this.DIPSICLABEL.CalcValue= "SİCİL NO :";
//                        this.DIPSIC.CalcValue= theObj.ProcedureDoctor.EmploymentRecordID;
//                    }
//                    else
//                    {
//                        this.DIPSICLABEL.CalcValue= "DİPLOMA NO :";
//                        this.DIPSIC.CalcValue=theObj.ProcedureDoctor.DiplomaNo;
//                    }
//                    
//
//                    if(this.UNVANKULLAN.CalcValue!="TRUE")
//                    {
//                        if(theObj.ProcedureDoctor.MilitaryClass != null)
//                            this.SINRUT.CalcValue = theObj.ProcedureDoctor.MilitaryClass.Name;
//                        if(theObj.ProcedureDoctor.Rank != null)
//                            this.SINRUT.CalcValue = this.SINRUT.CalcValue + " " + theObj.ProcedureDoctor.Rank.Name;
//                    }
//                    else
//                    {
//                        if(this.UNVAN.CalcValue=="")
//                        {
//                            if(theObj.ProcedureDoctor.MilitaryClass != null)
//                                this.SINRUT.CalcValue = theObj.ProcedureDoctor.MilitaryClass.Name;
//                            if(theObj.ProcedureDoctor.Rank != null)
//                                this.SINRUT.CalcValue = this.SINRUT.CalcValue + " " + theObj.ProcedureDoctor.Rank.Name;
//                        }
//                        else
//                        {
//                            this.SINRUT.CalcValue=theObj.ProcedureDoctor.Title.ToString();
//                            if(theObj.ProcedureDoctor.Rank != null)
//                                this.SINRUT.CalcValue = this.SINRUT.CalcValue + " " + theObj.ProcedureDoctor.Rank.Name;
//                        }
//                        
//                    }
//                    if (theObj.ProcedureDoctor.ResourceSpecialities  != null)
//                    {
//                        foreach(ResourceSpecialityGrid resSepeciality in theObj.ProcedureDoctor.ResourceSpecialities)
//                        {
//                            if(resSepeciality.Speciality != null && (resSepeciality.MainSpeciality==true ||  (resSepeciality.ObjectID  == null)))
//                            {
//                                this.UZ.CalcValue = resSepeciality.Speciality.Name;
//                            }
//                        }
//                    }
//                }
//            }
//            
//            this.BASHEKIM.CalcValue = TTObjectClasses.ResHospital.ApprovalSignatureBlock;
#endregion NOT FOOTER_Script
                }
            }

        }

        public NOTGroup NOT;

        public partial class MAINGroup : TTReportGroup
        {
            public ForensicMedicalReportReport MyParentReport
            {
                get { return (ForensicMedicalReportReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportRTF Report { get {return Body().Report;} }
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
                public ForensicMedicalReportReport MyParentReport
                {
                    get { return (ForensicMedicalReportReport)ParentReport; }
                }
                
                public TTReportRTF Report; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 15;
                    RepeatCount = 0;
                    
                    Report = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 8, 3, 204, 13, false);
                    Report.Name = "Report";
                    Report.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Report.CalcValue = Report.Value;
                    return new TTReportObject[] { Report};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((ForensicMedicalReportReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            ForensicMedicalReport forensicMedicalReport = (ForensicMedicalReport)context.GetObject(new Guid(sObjectID),"ForensicMedicalReport");
            if(forensicMedicalReport.Report!=null)
                this.Report.Value = forensicMedicalReport.Report.ToString();
#endregion MAIN BODY_PreScript
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ForensicMedicalReportReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            NOT = new NOTGroup(HEADER,"NOT");
            MAIN = new MAINGroup(NOT,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "ID", @"", true, false, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "FORENSICMEDICALREPORTREPORT";
            Caption = "Adli Tıp Raporu";
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
            fd.TextFont.Name = "Courier New";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 162;
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