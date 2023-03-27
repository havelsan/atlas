
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
    /// Sağlık Kurulu Üç İmza Raporu
    /// </summary>
    public partial class HealthCommitteeWithThreeSpecialistReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class TANIGroup : TTReportGroup
        {
            public HealthCommitteeWithThreeSpecialistReport MyParentReport
            {
                get { return (HealthCommitteeWithThreeSpecialistReport)ParentReport; }
            }

            new public TANIGroupHeader Header()
            {
                return (TANIGroupHeader)_header;
            }

            new public TANIGroupFooter Footer()
            {
                return (TANIGroupFooter)_footer;
            }

            public TTReportField RAPOR2 { get {return Header().RAPOR2;} }
            public TTReportField ADISOYADI { get {return Header().ADISOYADI;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField ACTIONDUEDATE { get {return Header().ACTIONDUEDATE;} }
            public TTReportField RAPORNO1 { get {return Header().RAPORNO1;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField NewField143 { get {return Header().NewField143;} }
            public TTReportField NewField144 { get {return Header().NewField144;} }
            public TTReportField NewField145 { get {return Header().NewField145;} }
            public TTReportField DOGYER { get {return Header().DOGYER;} }
            public TTReportField DOGTAR { get {return Header().DOGTAR;} }
            public TTReportField DOGTARYER { get {return Header().DOGTARYER;} }
            public TTReportField ADRESMAKAM { get {return Header().ADRESMAKAM;} }
            public TTReportField EKYAZI { get {return Header().EKYAZI;} }
            public TTReportField ADRES1 { get {return Header().ADRES1;} }
            public TTReportField MAKAM { get {return Header().MAKAM;} }
            public TTReportField HGRUBU { get {return Header().HGRUBU;} }
            public TTReportField ADI { get {return Header().ADI;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField NewField11412 { get {return Header().NewField11412;} }
            public TTReportField NewField11413 { get {return Header().NewField11413;} }
            public TTReportField NewField111411 { get {return Header().NewField111411;} }
            public TTReportField NewField121411 { get {return Header().NewField121411;} }
            public TTReportField NewField11414 { get {return Header().NewField11414;} }
            public TTReportField NewField111412 { get {return Header().NewField111412;} }
            public TTReportField NewField121412 { get {return Header().NewField121412;} }
            public TTReportField MUAYENEYAPAN { get {return Header().MUAYENEYAPAN;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField RAPORTARIHI { get {return Header().RAPORTARIHI;} }
            public TTReportField KARANTINANO { get {return Header().KARANTINANO;} }
            public TTReportField XXXXXXYEGIRIS { get {return Header().XXXXXXYEGIRIS;} }
            public TTReportField XXXXXXDENCIKIS { get {return Header().XXXXXXDENCIKIS;} }
            public TTReportField GONDERENMAKAM { get {return Header().GONDERENMAKAM;} }
            public TTReportField EMIRTARIHNO { get {return Header().EMIRTARIHNO;} }
            public TTReportField MUAYENEMAKSAT { get {return Header().MUAYENEMAKSAT;} }
            public TTReportField NewField11415 { get {return Header().NewField11415;} }
            public TTReportField NewField121413 { get {return Header().NewField121413;} }
            public TTReportField NewField131411 { get {return Header().NewField131411;} }
            public TTReportField NewField141411 { get {return Header().NewField141411;} }
            public TTReportField NewField1214121 { get {return Header().NewField1214121;} }
            public TTReportField TCKIMLIKNO { get {return Header().TCKIMLIKNO;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField BABAADI { get {return Header().BABAADI;} }
            public TTReportField DOGUMYERTARIH { get {return Header().DOGUMYERTARIH;} }
            public TTReportField ADRES { get {return Header().ADRES;} }
            public TTReportField NewField11214121 { get {return Header().NewField11214121;} }
            public TTReportField KACINCIISLEM { get {return Header().KACINCIISLEM;} }
            public TTReportField EVRAKTARIHI { get {return Header().EVRAKTARIHI;} }
            public TTReportField PATIENTGROUP { get {return Header().PATIENTGROUP;} }
            public TTReportField EMEKLI { get {return Header().EMEKLI;} }
            public TTReportField MEDULARAPORTAKIPNO { get {return Header().MEDULARAPORTAKIPNO;} }
            public TTReportField EPISODEID { get {return Header().EPISODEID;} }
            public TTReportField UZ2LBL { get {return Footer().UZ2LBL;} }
            public TTReportField UZ3LBL { get {return Footer().UZ3LBL;} }
            public TTReportField UZ { get {return Footer().UZ;} }
            public TTReportField ADSOYADDOC { get {return Footer().ADSOYADDOC;} }
            public TTReportField SINRUT { get {return Footer().SINRUT;} }
            public TTReportField ADSOYADDOC2 { get {return Footer().ADSOYADDOC2;} }
            public TTReportField UZ2 { get {return Footer().UZ2;} }
            public TTReportField SINRUT2 { get {return Footer().SINRUT2;} }
            public TTReportField ADSOYADDOC3 { get {return Footer().ADSOYADDOC3;} }
            public TTReportField UZ3 { get {return Footer().UZ3;} }
            public TTReportField SINRUT3 { get {return Footer().SINRUT3;} }
            public TTReportField NewField11341 { get {return Footer().NewField11341;} }
            public TTReportField UZEK1 { get {return Footer().UZEK1;} }
            public TTReportField ADSOYADEK1 { get {return Footer().ADSOYADEK1;} }
            public TTReportField SINRUTEK1 { get {return Footer().SINRUTEK1;} }
            public TTReportField ADSOYADEK2 { get {return Footer().ADSOYADEK2;} }
            public TTReportField UZEK2 { get {return Footer().UZEK2;} }
            public TTReportField SINRUTEK2 { get {return Footer().SINRUTEK2;} }
            public TTReportField EK1LBL { get {return Footer().EK1LBL;} }
            public TTReportField EK2LBL { get {return Footer().EK2LBL;} }
            public TTReportField SICILNO { get {return Footer().SICILNO;} }
            public TTReportField SICILNO2 { get {return Footer().SICILNO2;} }
            public TTReportField SICILNO3 { get {return Footer().SICILNO3;} }
            public TTReportField SICILNOEK1 { get {return Footer().SICILNOEK1;} }
            public TTReportField SICILNOEK2 { get {return Footer().SICILNOEK2;} }
            public TTReportField DIPLOMATESCILNO { get {return Footer().DIPLOMATESCILNO;} }
            public TTReportField DIPLOMATESCILNO2 { get {return Footer().DIPLOMATESCILNO2;} }
            public TTReportField DIPLOMATESCILNO3 { get {return Footer().DIPLOMATESCILNO3;} }
            public TTReportField DIPLOMATESCILNOEK1 { get {return Footer().DIPLOMATESCILNOEK1;} }
            public TTReportField DIPLOMATESCILNOEK2 { get {return Footer().DIPLOMATESCILNOEK2;} }
            public TANIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TANIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class>("GetHCWithThreeSpecialist", HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TANIGroupHeader(this);
                _footer = new TANIGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TANIGroupHeader : TTReportSection
            {
                public HealthCommitteeWithThreeSpecialistReport MyParentReport
                {
                    get { return (HealthCommitteeWithThreeSpecialistReport)ParentReport; }
                }
                
                public TTReportField RAPOR2;
                public TTReportField ADISOYADI;
                public TTReportField NewField141;
                public TTReportField ACTIONDUEDATE;
                public TTReportField RAPORNO1;
                public TTReportField NewField142;
                public TTReportField NewField143;
                public TTReportField NewField144;
                public TTReportField NewField145;
                public TTReportField DOGYER;
                public TTReportField DOGTAR;
                public TTReportField DOGTARYER;
                public TTReportField ADRESMAKAM;
                public TTReportField EKYAZI;
                public TTReportField ADRES1;
                public TTReportField MAKAM;
                public TTReportField HGRUBU;
                public TTReportField ADI;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField1141;
                public TTReportField NewField11411;
                public TTReportField NewField11412;
                public TTReportField NewField11413;
                public TTReportField NewField111411;
                public TTReportField NewField121411;
                public TTReportField NewField11414;
                public TTReportField NewField111412;
                public TTReportField NewField121412;
                public TTReportField MUAYENEYAPAN;
                public TTReportField RAPORNO;
                public TTReportField RAPORTARIHI;
                public TTReportField KARANTINANO;
                public TTReportField XXXXXXYEGIRIS;
                public TTReportField XXXXXXDENCIKIS;
                public TTReportField GONDERENMAKAM;
                public TTReportField EMIRTARIHNO;
                public TTReportField MUAYENEMAKSAT;
                public TTReportField NewField11415;
                public TTReportField NewField121413;
                public TTReportField NewField131411;
                public TTReportField NewField141411;
                public TTReportField NewField1214121;
                public TTReportField TCKIMLIKNO;
                public TTReportField ADSOYAD;
                public TTReportField BABAADI;
                public TTReportField DOGUMYERTARIH;
                public TTReportField ADRES;
                public TTReportField NewField11214121;
                public TTReportField KACINCIISLEM;
                public TTReportField EVRAKTARIHI;
                public TTReportField PATIENTGROUP;
                public TTReportField EMEKLI;
                public TTReportField MEDULARAPORTAKIPNO;
                public TTReportField EPISODEID; 
                public TANIGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 118;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    RAPOR2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 27, 198, 32, false);
                    RAPOR2.Name = "RAPOR2";
                    RAPOR2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPOR2.VertAlign = VerticalAlignmentEnum.vaBottom;
                    RAPOR2.TextFont.Name = "Arial";
                    RAPOR2.TextFont.Size = 9;
                    RAPOR2.Value = @"ÜÇ UZMAN TABİP İMZALI SAĞLIK RAPORU";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 94, 294, 98, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.Visible = EvetHayirEnum.ehHayir;
                    ADISOYADI.DrawStyle = DrawStyleConstants.vbSolid;
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.MultiLine = EvetHayirEnum.ehEvet;
                    ADISOYADI.WordBreak = EvetHayirEnum.ehEvet;
                    ADISOYADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADISOYADI.TextFont.Name = "Arial Narrow";
                    ADISOYADI.TextFont.Size = 8;
                    ADISOYADI.Value = @"{%ADI%}   ( {%HGRUBU%} )";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 85, 233, 89, false);
                    NewField141.Name = "NewField141";
                    NewField141.Visible = EvetHayirEnum.ehHayir;
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.TextFont.Name = "Arial Narrow";
                    NewField141.TextFont.Size = 8;
                    NewField141.Value = @"RAPOR NO     :";

                    ACTIONDUEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 89, 269, 93, false);
                    ACTIONDUEDATE.Name = "ACTIONDUEDATE";
                    ACTIONDUEDATE.Visible = EvetHayirEnum.ehHayir;
                    ACTIONDUEDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ACTIONDUEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDUEDATE.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ACTIONDUEDATE.TextFormat = @"Short Date";
                    ACTIONDUEDATE.TextFont.Name = "Arial Narrow";
                    ACTIONDUEDATE.TextFont.Size = 8;
                    ACTIONDUEDATE.Value = @"{#RAPORTARIHI#}";

                    RAPORNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 85, 269, 89, false);
                    RAPORNO1.Name = "RAPORNO1";
                    RAPORNO1.Visible = EvetHayirEnum.ehHayir;
                    RAPORNO1.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO1.TextFont.Name = "Arial Narrow";
                    RAPORNO1.TextFont.Size = 8;
                    RAPORNO1.Value = @"{#RAPORNO#}";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 89, 233, 93, false);
                    NewField142.Name = "NewField142";
                    NewField142.Visible = EvetHayirEnum.ehHayir;
                    NewField142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField142.TextFont.Name = "Arial Narrow";
                    NewField142.TextFont.Size = 8;
                    NewField142.Value = @"RAPOR TARİHİ :";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 94, 248, 98, false);
                    NewField143.Name = "NewField143";
                    NewField143.Visible = EvetHayirEnum.ehHayir;
                    NewField143.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField143.TextFont.Name = "Arial Narrow";
                    NewField143.TextFont.Size = 8;
                    NewField143.Value = @"HASTANIN KİMLİĞİ";

                    NewField144 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 99, 248, 103, false);
                    NewField144.Name = "NewField144";
                    NewField144.Visible = EvetHayirEnum.ehHayir;
                    NewField144.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField144.TextFont.Name = "Arial Narrow";
                    NewField144.TextFont.Size = 8;
                    NewField144.Value = @"DOĞUM YERİ- TARİHİ";

                    NewField145 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 104, 248, 108, false);
                    NewField145.Name = "NewField145";
                    NewField145.Visible = EvetHayirEnum.ehHayir;
                    NewField145.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField145.TextFont.Name = "Arial Narrow";
                    NewField145.TextFont.Size = 8;
                    NewField145.Value = @"ADRESİ / GÖNDEREN MAKAM";

                    DOGYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 74, 238, 78, false);
                    DOGYER.Name = "DOGYER";
                    DOGYER.Visible = EvetHayirEnum.ehHayir;
                    DOGYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGYER.TextFont.Name = "Arial Narrow";
                    DOGYER.TextFont.Size = 8;
                    DOGYER.Value = @"{#DYERI#}";

                    DOGTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 78, 238, 82, false);
                    DOGTAR.Name = "DOGTAR";
                    DOGTAR.Visible = EvetHayirEnum.ehHayir;
                    DOGTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGTAR.TextFormat = @"Short Date";
                    DOGTAR.TextFont.Name = "Arial Narrow";
                    DOGTAR.TextFont.Size = 8;
                    DOGTAR.Value = @"{#DTARIHI#}";

                    DOGTARYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 99, 294, 103, false);
                    DOGTARYER.Name = "DOGTARYER";
                    DOGTARYER.Visible = EvetHayirEnum.ehHayir;
                    DOGTARYER.DrawStyle = DrawStyleConstants.vbSolid;
                    DOGTARYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGTARYER.MultiLine = EvetHayirEnum.ehEvet;
                    DOGTARYER.WordBreak = EvetHayirEnum.ehEvet;
                    DOGTARYER.ExpandTabs = EvetHayirEnum.ehEvet;
                    DOGTARYER.TextFont.Name = "Arial Narrow";
                    DOGTARYER.TextFont.Size = 8;
                    DOGTARYER.Value = @"{%DOGYER%} - {%DOGTAR%}";

                    ADRESMAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 104, 294, 108, false);
                    ADRESMAKAM.Name = "ADRESMAKAM";
                    ADRESMAKAM.Visible = EvetHayirEnum.ehHayir;
                    ADRESMAKAM.DrawStyle = DrawStyleConstants.vbSolid;
                    ADRESMAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRESMAKAM.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ADRESMAKAM.TextFont.Name = "Arial Narrow";
                    ADRESMAKAM.TextFont.Size = 8;
                    ADRESMAKAM.Value = @"{%ADRES1%} /  {%MAKAM%}";

                    EKYAZI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 62, 328, 76, false);
                    EKYAZI.Name = "EKYAZI";
                    EKYAZI.Visible = EvetHayirEnum.ehHayir;
                    EKYAZI.MultiLine = EvetHayirEnum.ehEvet;
                    EKYAZI.WordBreak = EvetHayirEnum.ehEvet;
                    EKYAZI.ExpandTabs = EvetHayirEnum.ehEvet;
                    EKYAZI.TextFont.Name = "Arial Narrow";
                    EKYAZI.TextFont.Size = 8;
                    EKYAZI.Value = @"1. BU RAPOR XXXXXX AKADEMİ KURULUNUN 24.11.1992 GÜN VE 19 SAYILI OTURUMUNDA ALINAN KARAR GEREĞİNCE HEYET RAPORU YERİNE GEÇERLİDİR.                                          
2. KURUMLARINCA ÖDEME YAPILABİLMESİ İÇİN İLAÇ VE MALZEME KULLANILDI.";

                    ADRES1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 59, 237, 64, false);
                    ADRES1.Name = "ADRES1";
                    ADRES1.Visible = EvetHayirEnum.ehHayir;
                    ADRES1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRES1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ADRES1.TextFont.Name = "Arial Narrow";
                    ADRES1.TextFont.Size = 8;
                    ADRES1.Value = @"{#ADRES#}";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 53, 237, 58, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.Visible = EvetHayirEnum.ehHayir;
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.TextFont.Name = "Arial Narrow";
                    MAKAM.TextFont.Size = 8;
                    MAKAM.Value = @"";

                    HGRUBU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 69, 226, 73, false);
                    HGRUBU.Name = "HGRUBU";
                    HGRUBU.Visible = EvetHayirEnum.ehHayir;
                    HGRUBU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HGRUBU.MultiLine = EvetHayirEnum.ehEvet;
                    HGRUBU.NoClip = EvetHayirEnum.ehEvet;
                    HGRUBU.WordBreak = EvetHayirEnum.ehEvet;
                    HGRUBU.ExpandTabs = EvetHayirEnum.ehEvet;
                    HGRUBU.ObjectDefName = "PatientGroupEnum";
                    HGRUBU.DataMember = "DISPLAYTEXT";
                    HGRUBU.TextFont.Name = "Arial Narrow";
                    HGRUBU.TextFont.Size = 8;
                    HGRUBU.Value = @"{#HASTAGRUBU#}";

                    ADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 65, 230, 69, false);
                    ADI.Name = "ADI";
                    ADI.Visible = EvetHayirEnum.ehHayir;
                    ADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADI.MultiLine = EvetHayirEnum.ehEvet;
                    ADI.NoClip = EvetHayirEnum.ehEvet;
                    ADI.WordBreak = EvetHayirEnum.ehEvet;
                    ADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADI.ObjectDefName = "Patient";
                    ADI.DataMember = "FullName";
                    ADI.TextFont.Name = "Arial Narrow";
                    ADI.TextFont.Size = 8;
                    ADI.Value = @"{#PATIENTID#}";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 7, 198, 28, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Size = 9;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 39, 38, 53, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1141.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1141.TextFont.Name = "Arial Narrow";
                    NewField1141.TextFont.Size = 8;
                    NewField1141.Value = @"MUAYENEYİ YAPAN AD/BD";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 53, 38, 61, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11411.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11411.TextFont.Name = "Arial Narrow";
                    NewField11411.TextFont.Size = 8;
                    NewField11411.Value = @"RAPOR NUMARASI";

                    NewField11412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 61, 38, 69, false);
                    NewField11412.Name = "NewField11412";
                    NewField11412.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11412.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11412.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11412.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11412.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11412.TextFont.Name = "Arial Narrow";
                    NewField11412.TextFont.Size = 8;
                    NewField11412.Value = @"RAPOR TARİHİ";

                    NewField11413 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 69, 38, 77, false);
                    NewField11413.Name = "NewField11413";
                    NewField11413.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11413.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11413.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11413.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11413.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11413.TextFont.Name = "Arial Narrow";
                    NewField11413.TextFont.Size = 8;
                    NewField11413.Value = @"KARANTİNA NU";

                    NewField111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 77, 38, 85, false);
                    NewField111411.Name = "NewField111411";
                    NewField111411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111411.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111411.TextFont.Name = "Arial Narrow";
                    NewField111411.TextFont.Size = 8;
                    NewField111411.Value = @"XXXXXXYE GİRİŞ";

                    NewField121411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 85, 38, 93, false);
                    NewField121411.Name = "NewField121411";
                    NewField121411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121411.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121411.TextFont.Name = "Arial Narrow";
                    NewField121411.TextFont.Size = 8;
                    NewField121411.Value = @"XXXXXXDEN ÇIKIŞ";

                    NewField11414 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 93, 38, 101, false);
                    NewField11414.Name = "NewField11414";
                    NewField11414.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11414.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11414.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11414.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11414.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11414.TextFont.Name = "Arial Narrow";
                    NewField11414.TextFont.Size = 8;
                    NewField11414.Value = @"MUAYENEYE GÖNDEREN MAKAM";

                    NewField111412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 101, 38, 109, false);
                    NewField111412.Name = "NewField111412";
                    NewField111412.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111412.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111412.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111412.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111412.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111412.TextFont.Name = "Arial Narrow";
                    NewField111412.TextFont.Size = 8;
                    NewField111412.Value = @"EMİR TARİH / NU";

                    NewField121412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 109, 38, 117, false);
                    NewField121412.Name = "NewField121412";
                    NewField121412.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121412.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121412.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121412.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121412.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121412.TextFont.Name = "Arial Narrow";
                    NewField121412.TextFont.Size = 8;
                    NewField121412.Value = @"MUAYENE MAKSADI";

                    MUAYENEYAPAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 39, 107, 53, false);
                    MUAYENEYAPAN.Name = "MUAYENEYAPAN";
                    MUAYENEYAPAN.DrawStyle = DrawStyleConstants.vbSolid;
                    MUAYENEYAPAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENEYAPAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MUAYENEYAPAN.MultiLine = EvetHayirEnum.ehEvet;
                    MUAYENEYAPAN.WordBreak = EvetHayirEnum.ehEvet;
                    MUAYENEYAPAN.ExpandTabs = EvetHayirEnum.ehEvet;
                    MUAYENEYAPAN.ObjectDefName = "Resource";
                    MUAYENEYAPAN.DataMember = "NAME";
                    MUAYENEYAPAN.TextFont.Name = "Arial Narrow";
                    MUAYENEYAPAN.TextFont.Size = 8;
                    MUAYENEYAPAN.Value = @"{#ISTEKYAPANBOLUMID#}";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 53, 107, 61, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORNO.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORNO.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORNO.TextFont.Name = "Arial Narrow";
                    RAPORNO.TextFont.Size = 8;
                    RAPORNO.Value = @"{#RAPORNO#}";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 61, 107, 69, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"Short Date";
                    RAPORTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORTARIHI.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORTARIHI.TextFont.Name = "Arial Narrow";
                    RAPORTARIHI.TextFont.Size = 8;
                    RAPORTARIHI.Value = @"{#RAPORTARIHI#}";

                    KARANTINANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 69, 107, 77, false);
                    KARANTINANO.Name = "KARANTINANO";
                    KARANTINANO.DrawStyle = DrawStyleConstants.vbSolid;
                    KARANTINANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARANTINANO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KARANTINANO.MultiLine = EvetHayirEnum.ehEvet;
                    KARANTINANO.WordBreak = EvetHayirEnum.ehEvet;
                    KARANTINANO.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARANTINANO.TextFont.Name = "Arial Narrow";
                    KARANTINANO.TextFont.Size = 8;
                    KARANTINANO.Value = @"{#KARANTINANO#}";

                    XXXXXXYEGIRIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 77, 107, 85, false);
                    XXXXXXYEGIRIS.Name = "XXXXXXYEGIRIS";
                    XXXXXXYEGIRIS.DrawStyle = DrawStyleConstants.vbSolid;
                    XXXXXXYEGIRIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXYEGIRIS.TextFormat = @"Short Date";
                    XXXXXXYEGIRIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXYEGIRIS.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXYEGIRIS.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXYEGIRIS.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXYEGIRIS.TextFont.Name = "Arial Narrow";
                    XXXXXXYEGIRIS.TextFont.Size = 8;
                    XXXXXXYEGIRIS.Value = @"{#HGIRISTARIHI#}";

                    XXXXXXDENCIKIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 85, 107, 93, false);
                    XXXXXXDENCIKIS.Name = "XXXXXXDENCIKIS";
                    XXXXXXDENCIKIS.DrawStyle = DrawStyleConstants.vbSolid;
                    XXXXXXDENCIKIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXDENCIKIS.TextFormat = @"Short Date";
                    XXXXXXDENCIKIS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXDENCIKIS.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXDENCIKIS.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXDENCIKIS.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXDENCIKIS.TextFont.Name = "Arial Narrow";
                    XXXXXXDENCIKIS.TextFont.Size = 8;
                    XXXXXXDENCIKIS.Value = @"{#HCIKISTARIHI#}";

                    GONDERENMAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 93, 107, 101, false);
                    GONDERENMAKAM.Name = "GONDERENMAKAM";
                    GONDERENMAKAM.DrawStyle = DrawStyleConstants.vbSolid;
                    GONDERENMAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    GONDERENMAKAM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GONDERENMAKAM.MultiLine = EvetHayirEnum.ehEvet;
                    GONDERENMAKAM.WordBreak = EvetHayirEnum.ehEvet;
                    GONDERENMAKAM.ExpandTabs = EvetHayirEnum.ehEvet;
                    GONDERENMAKAM.TextFont.Name = "Arial Narrow";
                    GONDERENMAKAM.TextFont.Size = 8;
                    GONDERENMAKAM.Value = @"{%MAKAM%}";

                    EMIRTARIHNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 101, 107, 109, false);
                    EMIRTARIHNO.Name = "EMIRTARIHNO";
                    EMIRTARIHNO.DrawStyle = DrawStyleConstants.vbSolid;
                    EMIRTARIHNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMIRTARIHNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EMIRTARIHNO.MultiLine = EvetHayirEnum.ehEvet;
                    EMIRTARIHNO.WordBreak = EvetHayirEnum.ehEvet;
                    EMIRTARIHNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    EMIRTARIHNO.TextFont.Name = "Arial Narrow";
                    EMIRTARIHNO.TextFont.Size = 8;
                    EMIRTARIHNO.Value = @"{%EVRAKTARIHI%} / {#EVRAKNO#}";

                    MUAYENEMAKSAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 109, 107, 117, false);
                    MUAYENEMAKSAT.Name = "MUAYENEMAKSAT";
                    MUAYENEMAKSAT.DrawStyle = DrawStyleConstants.vbSolid;
                    MUAYENEMAKSAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENEMAKSAT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MUAYENEMAKSAT.MultiLine = EvetHayirEnum.ehEvet;
                    MUAYENEMAKSAT.WordBreak = EvetHayirEnum.ehEvet;
                    MUAYENEMAKSAT.ExpandTabs = EvetHayirEnum.ehEvet;
                    MUAYENEMAKSAT.TextFont.Name = "Arial Narrow";
                    MUAYENEMAKSAT.TextFont.Size = 8;
                    MUAYENEMAKSAT.Value = @"{#MAKSAT#}";

                    NewField11415 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 39, 132, 43, false);
                    NewField11415.Name = "NewField11415";
                    NewField11415.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11415.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11415.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11415.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11415.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11415.TextFont.Name = "Arial Narrow";
                    NewField11415.TextFont.Size = 8;
                    NewField11415.Value = @"TC KİMLİK NU";

                    NewField121413 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 53, 132, 61, false);
                    NewField121413.Name = "NewField121413";
                    NewField121413.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121413.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121413.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121413.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121413.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121413.TextFont.Name = "Arial Narrow";
                    NewField121413.TextFont.Size = 8;
                    NewField121413.Value = @"ADI SOYADI";

                    NewField131411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 61, 132, 69, false);
                    NewField131411.Name = "NewField131411";
                    NewField131411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField131411.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField131411.TextFont.Name = "Arial Narrow";
                    NewField131411.TextFont.Size = 8;
                    NewField131411.Value = @"BABA ADI";

                    NewField141411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 85, 132, 93, false);
                    NewField141411.Name = "NewField141411";
                    NewField141411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField141411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField141411.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField141411.TextFont.Name = "Arial Narrow";
                    NewField141411.TextFont.Size = 8;
                    NewField141411.Value = @"DOĞUM YERİ VE TARİHİ";

                    NewField1214121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 101, 132, 109, false);
                    NewField1214121.Name = "NewField1214121";
                    NewField1214121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1214121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1214121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1214121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1214121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1214121.TextFont.Name = "Arial Narrow";
                    NewField1214121.TextFont.Size = 8;
                    NewField1214121.Value = @"DEVAMLI ADRES";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 39, 198, 43, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCKIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.TextFont.Name = "Arial Narrow";
                    TCKIMLIKNO.TextFont.Size = 8;
                    TCKIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 53, 198, 61, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.DrawStyle = DrawStyleConstants.vbSolid;
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADSOYAD.MultiLine = EvetHayirEnum.ehEvet;
                    ADSOYAD.WordBreak = EvetHayirEnum.ehEvet;
                    ADSOYAD.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADSOYAD.TextFont.Name = "Arial Narrow";
                    ADSOYAD.TextFont.Size = 8;
                    ADSOYAD.Value = @"{%ADI%}";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 61, 198, 69, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.DrawStyle = DrawStyleConstants.vbSolid;
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BABAADI.MultiLine = EvetHayirEnum.ehEvet;
                    BABAADI.WordBreak = EvetHayirEnum.ehEvet;
                    BABAADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    BABAADI.TextFont.Name = "Arial Narrow";
                    BABAADI.TextFont.Size = 8;
                    BABAADI.Value = @"{#FATHERNAME#}";

                    DOGUMYERTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 85, 198, 93, false);
                    DOGUMYERTARIH.Name = "DOGUMYERTARIH";
                    DOGUMYERTARIH.DrawStyle = DrawStyleConstants.vbSolid;
                    DOGUMYERTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMYERTARIH.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOGUMYERTARIH.MultiLine = EvetHayirEnum.ehEvet;
                    DOGUMYERTARIH.WordBreak = EvetHayirEnum.ehEvet;
                    DOGUMYERTARIH.ExpandTabs = EvetHayirEnum.ehEvet;
                    DOGUMYERTARIH.TextFont.Name = "Arial Narrow";
                    DOGUMYERTARIH.TextFont.Size = 8;
                    DOGUMYERTARIH.Value = @"{%DOGYER%} / {%DOGTAR%}";

                    ADRES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 101, 198, 109, false);
                    ADRES.Name = "ADRES";
                    ADRES.DrawStyle = DrawStyleConstants.vbSolid;
                    ADRES.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRES.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADRES.MultiLine = EvetHayirEnum.ehEvet;
                    ADRES.WordBreak = EvetHayirEnum.ehEvet;
                    ADRES.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADRES.TextFont.Name = "Arial Narrow";
                    ADRES.TextFont.Size = 8;
                    ADRES.Value = @"{#ADRES#}";

                    NewField11214121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 109, 132, 117, false);
                    NewField11214121.Name = "NewField11214121";
                    NewField11214121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11214121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11214121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11214121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11214121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11214121.TextFont.Name = "Arial Narrow";
                    NewField11214121.TextFont.Size = 8;
                    NewField11214121.Value = @"KAÇINCI İŞLEM";

                    KACINCIISLEM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 109, 198, 117, false);
                    KACINCIISLEM.Name = "KACINCIISLEM";
                    KACINCIISLEM.DrawStyle = DrawStyleConstants.vbSolid;
                    KACINCIISLEM.FieldType = ReportFieldTypeEnum.ftVariable;
                    KACINCIISLEM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KACINCIISLEM.MultiLine = EvetHayirEnum.ehEvet;
                    KACINCIISLEM.WordBreak = EvetHayirEnum.ehEvet;
                    KACINCIISLEM.ExpandTabs = EvetHayirEnum.ehEvet;
                    KACINCIISLEM.TextFont.Name = "Arial Narrow";
                    KACINCIISLEM.TextFont.Size = 8;
                    KACINCIISLEM.Value = @"{#KACINCIMUAYENESI#}";

                    EVRAKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 47, 233, 51, false);
                    EVRAKTARIHI.Name = "EVRAKTARIHI";
                    EVRAKTARIHI.Visible = EvetHayirEnum.ehHayir;
                    EVRAKTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    EVRAKTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVRAKTARIHI.TextFormat = @"Short Date";
                    EVRAKTARIHI.TextFont.Name = "Arial Narrow";
                    EVRAKTARIHI.TextFont.Size = 8;
                    EVRAKTARIHI.Value = @"{#EVRAKTARIHI#}";

                    PATIENTGROUP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 40, 233, 44, false);
                    PATIENTGROUP.Name = "PATIENTGROUP";
                    PATIENTGROUP.Visible = EvetHayirEnum.ehHayir;
                    PATIENTGROUP.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTGROUP.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTGROUP.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTGROUP.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTGROUP.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTGROUP.TextFont.Name = "Arial Narrow";
                    PATIENTGROUP.TextFont.Size = 8;
                    PATIENTGROUP.Value = @"{#HASTAGRUBU#}";

                    EMEKLI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 34, 233, 38, false);
                    EMEKLI.Name = "EMEKLI";
                    EMEKLI.Visible = EvetHayirEnum.ehHayir;
                    EMEKLI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMEKLI.MultiLine = EvetHayirEnum.ehEvet;
                    EMEKLI.NoClip = EvetHayirEnum.ehEvet;
                    EMEKLI.WordBreak = EvetHayirEnum.ehEvet;
                    EMEKLI.ExpandTabs = EvetHayirEnum.ehEvet;
                    EMEKLI.TextFont.Name = "Arial Narrow";
                    EMEKLI.TextFont.Size = 8;
                    EMEKLI.Value = @"";

                    MEDULARAPORTAKIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 32, 198, 38, false);
                    MEDULARAPORTAKIPNO.Name = "MEDULARAPORTAKIPNO";
                    MEDULARAPORTAKIPNO.FieldType = ReportFieldTypeEnum.ftExpression;
                    MEDULARAPORTAKIPNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MEDULARAPORTAKIPNO.VertAlign = VerticalAlignmentEnum.vaBottom;
                    MEDULARAPORTAKIPNO.TextFont.Name = "Arial Narrow";
                    MEDULARAPORTAKIPNO.TextFont.CharSet = 1;
                    MEDULARAPORTAKIPNO.Value = @"{#MEDULARAPORTAKIPNO#}";

                    EPISODEID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 19, 238, 24, false);
                    EPISODEID.Name = "EPISODEID";
                    EPISODEID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEID.TextFont.Name = "Arial Narrow";
                    EPISODEID.TextFont.CharSet = 1;
                    EPISODEID.Value = @"{#EPISODEID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class dataset_GetHCWithThreeSpecialist = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class>(0);
                    RAPOR2.CalcValue = RAPOR2.Value;
                    ADI.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Patientid) : "");
                    ADI.PostFieldValueCalculation();
                    HGRUBU.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Hastagrubu) : "");
                    HGRUBU.PostFieldValueCalculation();
                    ADISOYADI.CalcValue = MyParentReport.TANI.ADI.CalcValue + @"   ( " + MyParentReport.TANI.HGRUBU.CalcValue + @" )";
                    NewField141.CalcValue = NewField141.Value;
                    ACTIONDUEDATE.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Raportarihi) : "");
                    RAPORNO1.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Raporno) : "");
                    NewField142.CalcValue = NewField142.Value;
                    NewField143.CalcValue = NewField143.Value;
                    NewField144.CalcValue = NewField144.Value;
                    NewField145.CalcValue = NewField145.Value;
                    DOGYER.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Dyeri) : "");
                    DOGTAR.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Dtarihi) : "");
                    DOGTARYER.CalcValue = MyParentReport.TANI.DOGYER.CalcValue + @" - " + MyParentReport.TANI.DOGTAR.FormattedValue;
                    ADRES1.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Adres) : "");
                    MAKAM.CalcValue = @"";
                    ADRESMAKAM.CalcValue = MyParentReport.TANI.ADRES1.CalcValue + @" /  " + MyParentReport.TANI.MAKAM.CalcValue;
                    EKYAZI.CalcValue = EKYAZI.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField11412.CalcValue = NewField11412.Value;
                    NewField11413.CalcValue = NewField11413.Value;
                    NewField111411.CalcValue = NewField111411.Value;
                    NewField121411.CalcValue = NewField121411.Value;
                    NewField11414.CalcValue = NewField11414.Value;
                    NewField111412.CalcValue = NewField111412.Value;
                    NewField121412.CalcValue = NewField121412.Value;
                    MUAYENEYAPAN.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Istekyapanbolumid) : "");
                    MUAYENEYAPAN.PostFieldValueCalculation();
                    RAPORNO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Raporno) : "");
                    RAPORTARIHI.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Raportarihi) : "");
                    KARANTINANO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Karantinano) : "");
                    XXXXXXYEGIRIS.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Hgiristarihi) : "");
                    XXXXXXDENCIKIS.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Hcikistarihi) : "");
                    GONDERENMAKAM.CalcValue = MyParentReport.TANI.MAKAM.CalcValue;
                    EVRAKTARIHI.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Evraktarihi) : "");
                    EMIRTARIHNO.CalcValue = MyParentReport.TANI.EVRAKTARIHI.FormattedValue + @" / " + (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Evrakno) : "");
                    MUAYENEMAKSAT.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Maksat) : "");
                    NewField11415.CalcValue = NewField11415.Value;
                    NewField121413.CalcValue = NewField121413.Value;
                    NewField131411.CalcValue = NewField131411.Value;
                    NewField141411.CalcValue = NewField141411.Value;
                    NewField1214121.CalcValue = NewField1214121.Value;
                    TCKIMLIKNO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.UniqueRefNo) : "");
                    ADSOYAD.CalcValue = MyParentReport.TANI.ADI.CalcValue;
                    BABAADI.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.FatherName) : "");
                    DOGUMYERTARIH.CalcValue = MyParentReport.TANI.DOGYER.CalcValue + @" / " + MyParentReport.TANI.DOGTAR.FormattedValue;
                    ADRES.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Adres) : "");
                    NewField11214121.CalcValue = NewField11214121.Value;
                    KACINCIISLEM.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Kacincimuayenesi) : "");
                    PATIENTGROUP.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Hastagrubu) : "");
                    EMEKLI.CalcValue = @"";
                    EPISODEID.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Episodeid) : "");
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    MEDULARAPORTAKIPNO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.MedulaRaporTakipNo) : "");
                    return new TTReportObject[] { RAPOR2,ADI,HGRUBU,ADISOYADI,NewField141,ACTIONDUEDATE,RAPORNO1,NewField142,NewField143,NewField144,NewField145,DOGYER,DOGTAR,DOGTARYER,ADRES1,MAKAM,ADRESMAKAM,EKYAZI,NewField1141,NewField11411,NewField11412,NewField11413,NewField111411,NewField121411,NewField11414,NewField111412,NewField121412,MUAYENEYAPAN,RAPORNO,RAPORTARIHI,KARANTINANO,XXXXXXYEGIRIS,XXXXXXDENCIKIS,GONDERENMAKAM,EVRAKTARIHI,EMIRTARIHNO,MUAYENEMAKSAT,NewField11415,NewField121413,NewField131411,NewField141411,NewField1214121,TCKIMLIKNO,ADSOYAD,BABAADI,DOGUMYERTARIH,ADRES,NewField11214121,KACINCIISLEM,PATIENTGROUP,EMEKLI,EPISODEID,XXXXXXBASLIK,MEDULARAPORTAKIPNO};
                }

                public override void RunScript()
                {
#region TANI HEADER_Script
                    //                                                                                                                                                                                                                                    
//            TTObjectContext context = new TTObjectContext(true);
//            if(String.IsNullOrEmpty(this.PATIENTGROUP.CalcValue) == false)
//            {
//                TTDataDictionary.EnumValueDef pge = TTObjectDefManager.Instance.DataTypes["PatientGroupEnum"].EnumValueDefs[this.PATIENTGROUP.CalcValue];
//                TTObjectClasses.PatientGroupEnum patientGroupEnumValue = (TTObjectClasses.PatientGroupEnum) Convert.ToInt32(pge.Value);
//                TTObjectClasses.PatientGroupDefinition pgd = TTObjectClasses.Common.PatientGroupDefinitionByEnum(context,patientGroupEnumValue);
//                
//                if(pgd != null)
//                {
//                    if(pgd.MainPatientGroup.MainPatientGroupEnum == MainPatientGroupEnum.Retired)
//                        this.SINIFRUTBE1.CalcValue = this.SINIFRUTBE.CalcValue + " (Emekli)";
//                    else
//                        this.SINIFRUTBE1.CalcValue = this.SINIFRUTBE.CalcValue;
//                }
//                else
//                    this.SINIFRUTBE1.CalcValue = this.SINIFRUTBE.CalcValue;
//            }
//            else
//                this.SINIFRUTBE1.CalcValue = this.SINIFRUTBE.CalcValue;
//            
//            
//             if(String.IsNullOrEmpty(this.EPISODEID.CalcValue) == false)
//            {
//                Episode episode = (Episode)context.GetObject(new Guid(this.EPISODEID.CalcValue.ToString()), "Episode");
//                if(episode != null)
//                {
//                    if(episode.IsMedulaEpisode() == true && this.MEDULARAPORTAKIPNO.CalcValue != "")
//                        this.MEDULARAPORTAKIPNO.CalcValue= "Medula Rapor Takip No: " + this.MEDULARAPORTAKIPNO.CalcValue;
//                    else
//                        this.MEDULARAPORTAKIPNO.CalcValue = "";
//                    
//                    if(this.KARANTINANO.CalcValue == "")
//                    {
//                        //TTObjectContext context = new TTObjectContext(false);
//                        IList list = InpatientAdmission.GetInpatientAdmissionByEpisode(context, episode.ObjectID.ToString());
//                        foreach (InpatientAdmission ia in list)
//                        {
//                            if (ia.CurrentStateDef.Status != StateStatusEnum.Cancelled)
//                            {
//                                this.KARANTINANO.CalcValue = ia.QuarantineProtocolNo.ToString();
//                                break;
//                            }
//                        }                       
//                    }
//                }
//                else
//                    this.MEDULARAPORTAKIPNO.CalcValue = "";
//            }
//            else
//                this.MEDULARAPORTAKIPNO.CalcValue = "";
#endregion TANI HEADER_Script
                }
            }
            public partial class TANIGroupFooter : TTReportSection
            {
                public HealthCommitteeWithThreeSpecialistReport MyParentReport
                {
                    get { return (HealthCommitteeWithThreeSpecialistReport)ParentReport; }
                }
                
                public TTReportField UZ2LBL;
                public TTReportField UZ3LBL;
                public TTReportField UZ;
                public TTReportField ADSOYADDOC;
                public TTReportField SINRUT;
                public TTReportField ADSOYADDOC2;
                public TTReportField UZ2;
                public TTReportField SINRUT2;
                public TTReportField ADSOYADDOC3;
                public TTReportField UZ3;
                public TTReportField SINRUT3;
                public TTReportField NewField11341;
                public TTReportField UZEK1;
                public TTReportField ADSOYADEK1;
                public TTReportField SINRUTEK1;
                public TTReportField ADSOYADEK2;
                public TTReportField UZEK2;
                public TTReportField SINRUTEK2;
                public TTReportField EK1LBL;
                public TTReportField EK2LBL;
                public TTReportField SICILNO;
                public TTReportField SICILNO2;
                public TTReportField SICILNO3;
                public TTReportField SICILNOEK1;
                public TTReportField SICILNOEK2;
                public TTReportField DIPLOMATESCILNO;
                public TTReportField DIPLOMATESCILNO2;
                public TTReportField DIPLOMATESCILNO3;
                public TTReportField DIPLOMATESCILNOEK1;
                public TTReportField DIPLOMATESCILNOEK2; 
                public TANIGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 91;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    UZ2LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 5, 89, 9, false);
                    UZ2LBL.Name = "UZ2LBL";
                    UZ2LBL.Visible = EvetHayirEnum.ehHayir;
                    UZ2LBL.TextFont.Name = "Arial Narrow";
                    UZ2LBL.TextFont.Bold = true;
                    UZ2LBL.TextFont.Underline = true;
                    UZ2LBL.Value = @"İMZA";

                    UZ3LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 5, 151, 9, false);
                    UZ3LBL.Name = "UZ3LBL";
                    UZ3LBL.Visible = EvetHayirEnum.ehHayir;
                    UZ3LBL.TextFont.Name = "Arial Narrow";
                    UZ3LBL.TextFont.Bold = true;
                    UZ3LBL.TextFont.Underline = true;
                    UZ3LBL.Value = @"İMZA";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 27, 75, 31, false);
                    UZ.Name = "UZ";
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.TextFont.Name = "Arial Narrow";
                    UZ.TextFont.Size = 8;
                    UZ.Value = @"";

                    ADSOYADDOC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 11, 75, 15, false);
                    ADSOYADDOC.Name = "ADSOYADDOC";
                    ADSOYADDOC.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC.TextFont.Name = "Arial Narrow";
                    ADSOYADDOC.TextFont.Size = 8;
                    ADSOYADDOC.Value = @"";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 15, 75, 19, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.TextFont.Name = "Arial Narrow";
                    SINRUT.TextFont.Size = 8;
                    SINRUT.Value = @"";

                    ADSOYADDOC2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 11, 137, 15, false);
                    ADSOYADDOC2.Name = "ADSOYADDOC2";
                    ADSOYADDOC2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC2.TextFont.Name = "Arial Narrow";
                    ADSOYADDOC2.TextFont.Size = 8;
                    ADSOYADDOC2.Value = @"";

                    UZ2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 27, 137, 31, false);
                    UZ2.Name = "UZ2";
                    UZ2.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ2.MultiLine = EvetHayirEnum.ehEvet;
                    UZ2.NoClip = EvetHayirEnum.ehEvet;
                    UZ2.WordBreak = EvetHayirEnum.ehEvet;
                    UZ2.TextFont.Name = "Arial Narrow";
                    UZ2.TextFont.Size = 8;
                    UZ2.Value = @"";

                    SINRUT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 15, 137, 19, false);
                    SINRUT2.Name = "SINRUT2";
                    SINRUT2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT2.TextFont.Name = "Arial Narrow";
                    SINRUT2.TextFont.Size = 8;
                    SINRUT2.Value = @"";

                    ADSOYADDOC3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 11, 198, 15, false);
                    ADSOYADDOC3.Name = "ADSOYADDOC3";
                    ADSOYADDOC3.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC3.TextFont.Name = "Arial Narrow";
                    ADSOYADDOC3.TextFont.Size = 8;
                    ADSOYADDOC3.Value = @"";

                    UZ3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 27, 198, 31, false);
                    UZ3.Name = "UZ3";
                    UZ3.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ3.MultiLine = EvetHayirEnum.ehEvet;
                    UZ3.NoClip = EvetHayirEnum.ehEvet;
                    UZ3.WordBreak = EvetHayirEnum.ehEvet;
                    UZ3.TextFont.Name = "Arial Narrow";
                    UZ3.TextFont.Size = 8;
                    UZ3.Value = @"";

                    SINRUT3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 15, 198, 19, false);
                    SINRUT3.Name = "SINRUT3";
                    SINRUT3.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT3.TextFont.Name = "Arial Narrow";
                    SINRUT3.TextFont.Size = 8;
                    SINRUT3.Value = @"";

                    NewField11341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 5, 56, 9, false);
                    NewField11341.Name = "NewField11341";
                    NewField11341.TextFont.Name = "Arial Narrow";
                    NewField11341.TextFont.Bold = true;
                    NewField11341.TextFont.Underline = true;
                    NewField11341.Value = @"DÜZENLEYEN TABİP";

                    UZEK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 58, 75, 62, false);
                    UZEK1.Name = "UZEK1";
                    UZEK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZEK1.MultiLine = EvetHayirEnum.ehEvet;
                    UZEK1.NoClip = EvetHayirEnum.ehEvet;
                    UZEK1.WordBreak = EvetHayirEnum.ehEvet;
                    UZEK1.TextFont.Name = "Arial Narrow";
                    UZEK1.TextFont.Size = 8;
                    UZEK1.Value = @"";

                    ADSOYADEK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 42, 75, 46, false);
                    ADSOYADEK1.Name = "ADSOYADEK1";
                    ADSOYADEK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADEK1.TextFont.Name = "Arial Narrow";
                    ADSOYADEK1.TextFont.Size = 8;
                    ADSOYADEK1.Value = @"";

                    SINRUTEK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 46, 75, 50, false);
                    SINRUTEK1.Name = "SINRUTEK1";
                    SINRUTEK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUTEK1.TextFont.Name = "Arial Narrow";
                    SINRUTEK1.TextFont.Size = 8;
                    SINRUTEK1.Value = @"";

                    ADSOYADEK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 42, 137, 46, false);
                    ADSOYADEK2.Name = "ADSOYADEK2";
                    ADSOYADEK2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADEK2.TextFont.Name = "Arial Narrow";
                    ADSOYADEK2.TextFont.Size = 8;
                    ADSOYADEK2.Value = @"";

                    UZEK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 58, 137, 62, false);
                    UZEK2.Name = "UZEK2";
                    UZEK2.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZEK2.MultiLine = EvetHayirEnum.ehEvet;
                    UZEK2.NoClip = EvetHayirEnum.ehEvet;
                    UZEK2.WordBreak = EvetHayirEnum.ehEvet;
                    UZEK2.TextFont.Name = "Arial Narrow";
                    UZEK2.TextFont.Size = 8;
                    UZEK2.Value = @"";

                    SINRUTEK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 46, 137, 50, false);
                    SINRUTEK2.Name = "SINRUTEK2";
                    SINRUTEK2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUTEK2.TextFont.Name = "Arial Narrow";
                    SINRUTEK2.TextFont.Size = 8;
                    SINRUTEK2.Value = @"";

                    EK1LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 36, 56, 40, false);
                    EK1LBL.Name = "EK1LBL";
                    EK1LBL.Visible = EvetHayirEnum.ehHayir;
                    EK1LBL.TextFont.Name = "Arial Narrow";
                    EK1LBL.TextFont.Bold = true;
                    EK1LBL.TextFont.Underline = true;
                    EK1LBL.Value = @"İMZA";

                    EK2LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 36, 117, 40, false);
                    EK2LBL.Name = "EK2LBL";
                    EK2LBL.Visible = EvetHayirEnum.ehHayir;
                    EK2LBL.TextFont.Name = "Arial Narrow";
                    EK2LBL.TextFont.Bold = true;
                    EK2LBL.TextFont.Underline = true;
                    EK2LBL.Value = @"İMZA";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 19, 75, 23, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO.NoClip = EvetHayirEnum.ehEvet;
                    SICILNO.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO.TextFont.Name = "Arial Narrow";
                    SICILNO.TextFont.Size = 8;
                    SICILNO.Value = @"";

                    SICILNO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 19, 137, 23, false);
                    SICILNO2.Name = "SICILNO2";
                    SICILNO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO2.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO2.NoClip = EvetHayirEnum.ehEvet;
                    SICILNO2.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO2.TextFont.Name = "Arial Narrow";
                    SICILNO2.TextFont.Size = 8;
                    SICILNO2.Value = @"";

                    SICILNO3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 19, 198, 23, false);
                    SICILNO3.Name = "SICILNO3";
                    SICILNO3.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO3.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO3.NoClip = EvetHayirEnum.ehEvet;
                    SICILNO3.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO3.TextFont.Name = "Arial Narrow";
                    SICILNO3.TextFont.Size = 8;
                    SICILNO3.Value = @"";

                    SICILNOEK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 50, 75, 54, false);
                    SICILNOEK1.Name = "SICILNOEK1";
                    SICILNOEK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNOEK1.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNOEK1.NoClip = EvetHayirEnum.ehEvet;
                    SICILNOEK1.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNOEK1.TextFont.Name = "Arial Narrow";
                    SICILNOEK1.TextFont.Size = 8;
                    SICILNOEK1.Value = @"";

                    SICILNOEK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 50, 137, 54, false);
                    SICILNOEK2.Name = "SICILNOEK2";
                    SICILNOEK2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNOEK2.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNOEK2.NoClip = EvetHayirEnum.ehEvet;
                    SICILNOEK2.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNOEK2.TextFont.Name = "Arial Narrow";
                    SICILNOEK2.TextFont.Size = 8;
                    SICILNOEK2.Value = @"";

                    DIPLOMATESCILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 23, 75, 27, false);
                    DIPLOMATESCILNO.Name = "DIPLOMATESCILNO";
                    DIPLOMATESCILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMATESCILNO.MultiLine = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO.NoClip = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO.WordBreak = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO.TextFont.Name = "Arial Narrow";
                    DIPLOMATESCILNO.TextFont.Size = 8;
                    DIPLOMATESCILNO.Value = @"";

                    DIPLOMATESCILNO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 23, 137, 27, false);
                    DIPLOMATESCILNO2.Name = "DIPLOMATESCILNO2";
                    DIPLOMATESCILNO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMATESCILNO2.MultiLine = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO2.NoClip = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO2.WordBreak = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO2.TextFont.Name = "Arial Narrow";
                    DIPLOMATESCILNO2.TextFont.Size = 8;
                    DIPLOMATESCILNO2.Value = @"";

                    DIPLOMATESCILNO3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 23, 198, 27, false);
                    DIPLOMATESCILNO3.Name = "DIPLOMATESCILNO3";
                    DIPLOMATESCILNO3.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMATESCILNO3.MultiLine = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO3.NoClip = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO3.WordBreak = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO3.TextFont.Name = "Arial Narrow";
                    DIPLOMATESCILNO3.TextFont.Size = 8;
                    DIPLOMATESCILNO3.Value = @"";

                    DIPLOMATESCILNOEK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 54, 75, 58, false);
                    DIPLOMATESCILNOEK1.Name = "DIPLOMATESCILNOEK1";
                    DIPLOMATESCILNOEK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMATESCILNOEK1.MultiLine = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNOEK1.NoClip = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNOEK1.WordBreak = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNOEK1.TextFont.Name = "Arial Narrow";
                    DIPLOMATESCILNOEK1.TextFont.Size = 8;
                    DIPLOMATESCILNOEK1.Value = @"";

                    DIPLOMATESCILNOEK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 54, 137, 58, false);
                    DIPLOMATESCILNOEK2.Name = "DIPLOMATESCILNOEK2";
                    DIPLOMATESCILNOEK2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMATESCILNOEK2.MultiLine = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNOEK2.NoClip = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNOEK2.WordBreak = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNOEK2.TextFont.Name = "Arial Narrow";
                    DIPLOMATESCILNOEK2.TextFont.Size = 8;
                    DIPLOMATESCILNOEK2.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class dataset_GetHCWithThreeSpecialist = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class>(0);
                    UZ2LBL.CalcValue = UZ2LBL.Value;
                    UZ3LBL.CalcValue = UZ3LBL.Value;
                    UZ.CalcValue = @"";
                    ADSOYADDOC.CalcValue = @"";
                    SINRUT.CalcValue = @"";
                    ADSOYADDOC2.CalcValue = @"";
                    UZ2.CalcValue = @"";
                    SINRUT2.CalcValue = @"";
                    ADSOYADDOC3.CalcValue = @"";
                    UZ3.CalcValue = @"";
                    SINRUT3.CalcValue = @"";
                    NewField11341.CalcValue = NewField11341.Value;
                    UZEK1.CalcValue = @"";
                    ADSOYADEK1.CalcValue = @"";
                    SINRUTEK1.CalcValue = @"";
                    ADSOYADEK2.CalcValue = @"";
                    UZEK2.CalcValue = @"";
                    SINRUTEK2.CalcValue = @"";
                    EK1LBL.CalcValue = EK1LBL.Value;
                    EK2LBL.CalcValue = EK2LBL.Value;
                    SICILNO.CalcValue = @"";
                    SICILNO2.CalcValue = @"";
                    SICILNO3.CalcValue = @"";
                    SICILNOEK1.CalcValue = @"";
                    SICILNOEK2.CalcValue = @"";
                    DIPLOMATESCILNO.CalcValue = @"";
                    DIPLOMATESCILNO2.CalcValue = @"";
                    DIPLOMATESCILNO3.CalcValue = @"";
                    DIPLOMATESCILNOEK1.CalcValue = @"";
                    DIPLOMATESCILNOEK2.CalcValue = @"";
                    return new TTReportObject[] { UZ2LBL,UZ3LBL,UZ,ADSOYADDOC,SINRUT,ADSOYADDOC2,UZ2,SINRUT2,ADSOYADDOC3,UZ3,SINRUT3,NewField11341,UZEK1,ADSOYADEK1,SINRUTEK1,ADSOYADEK2,UZEK2,SINRUTEK2,EK1LBL,EK2LBL,SICILNO,SICILNO2,SICILNO3,SICILNOEK1,SICILNOEK2,DIPLOMATESCILNO,DIPLOMATESCILNO2,DIPLOMATESCILNO3,DIPLOMATESCILNOEK1,DIPLOMATESCILNOEK2};
                }
            }

        }

        public TANIGroup TANI;

        public partial class MAINGroup : TTReportGroup
        {
            public HealthCommitteeWithThreeSpecialistReport MyParentReport
            {
                get { return (HealthCommitteeWithThreeSpecialistReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField RAPOR { get {return Body().RAPOR;} }
            public TTReportField TANI { get {return Body().TANI;} }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public TTReportField MADDE { get {return Body().MADDE;} }
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
                public HealthCommitteeWithThreeSpecialistReport MyParentReport
                {
                    get { return (HealthCommitteeWithThreeSpecialistReport)ParentReport; }
                }
                
                public TTReportField RAPOR;
                public TTReportField TANI;
                public TTReportField KARAR;
                public TTReportField MADDE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 14;
                    RepeatCount = 0;
                    
                    RAPOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 1, 198, 12, false);
                    RAPOR.Name = "RAPOR";
                    RAPOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPOR.MultiLine = EvetHayirEnum.ehEvet;
                    RAPOR.NoClip = EvetHayirEnum.ehEvet;
                    RAPOR.WordBreak = EvetHayirEnum.ehEvet;
                    RAPOR.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPOR.TextFont.Name = "Arial Narrow";
                    RAPOR.TextFont.Size = 8;
                    RAPOR.Value = @"KLİNİK, LABORATUVAR VE RÖNTGEN BULGULARI:
";

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 3, 241, 8, false);
                    TANI.Name = "TANI";
                    TANI.Visible = EvetHayirEnum.ehHayir;
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.NoClip = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.ExpandTabs = EvetHayirEnum.ehEvet;
                    TANI.TextFont.Name = "Arial Narrow";
                    TANI.TextFont.Size = 8;
                    TANI.Value = @"TANI:
";

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 3, 264, 8, false);
                    KARAR.Name = "KARAR";
                    KARAR.Visible = EvetHayirEnum.ehHayir;
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.CaseFormat = CaseFormatEnum.fcUpperCase;
                    KARAR.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR.NoClip = EvetHayirEnum.ehEvet;
                    KARAR.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR.TextFont.Name = "Arial Narrow";
                    KARAR.TextFont.Size = 8;
                    KARAR.Value = @"";

                    MADDE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 272, 3, 288, 8, false);
                    MADDE.Name = "MADDE";
                    MADDE.Visible = EvetHayirEnum.ehHayir;
                    MADDE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDE.TextFont.Name = "Arial Narrow";
                    MADDE.TextFont.Size = 8;
                    MADDE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RAPOR.CalcValue = @"KLİNİK, LABORATUVAR VE RÖNTGEN BULGULARI:
";
                    TANI.CalcValue = @"TANI:
";
                    KARAR.CalcValue = @"";
                    MADDE.CalcValue = @"";
                    return new TTReportObject[] { RAPOR,TANI,KARAR,MADDE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HealthCommitteeWithThreeSpecialistReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommitteeWithThreeSpecialist hcw = (HealthCommitteeWithThreeSpecialist)context.GetObject(new Guid(sObjectID),"HealthCommitteeWithThreeSpecialist");
            
            if(hcw == null)
                throw new Exception("Rapor Sağlık Kurulu Üç İmza işlemi üzerinden alınmalıdır.\r\nReason: HealthCommitteeWithThreeSpecialist is null");
            
            if(hcw.HCThreeSpecialistDescription!=null)
                this.RAPOR.CalcValue = this.RAPOR.CalcValue + TTObjectClasses.Common.GetTextOfRTFString(hcw.HCThreeSpecialistDescription.ToString());
            
            if(hcw.Report!=null)
                this.KARAR.CalcValue = this.KARAR.CalcValue + TTObjectClasses.Common.GetTextOfRTFString(hcw.Report.ToString());
            
            //Tanı
            this.TANI.CalcValue = hcw.GetMyOrEpisodeDiagnosis();
            //            int nCount = 1;
            //            if(hcw.Diagnosis.Count >0)

            //            IList diagnosisCodeList = new List<string>();
            //            //this.TANI.CalcValue = "";
            //            BindingList<DiagnosisGrid.GetDiagnosisByEpisode_Class> pDiagnosis = DiagnosisGrid.GetDiagnosisByEpisode(hcw.Episode.ObjectID.ToString());
            //            foreach(DiagnosisGrid.GetDiagnosisByEpisode_Class pGrid in pDiagnosis)
            //            {
            //                if(diagnosisCodeList.Contains(pGrid.Code) == false)
            //                {
            //                    diagnosisCodeList.Add(pGrid.Code);
            //                    this.TANI.CalcValue += nCount.ToString() + "- " + pGrid.Code + " " + pGrid.Name;
            //                    if (pGrid.FreeDiagnosis != null)
            //                        this.TANI.CalcValue += " (" + pGrid.FreeDiagnosis + ")";
            //                    this.TANI.CalcValue += "\r\n";
            //                    nCount++;
            //                }
            //            }
            
            //Madde-Dilim-Fıkra
            BindingList<HCWithThreeSpecialist_MatterSliceAnectodeGrid.GetHCWTS_MatterSliceAnectodeGridByParent_Class> theAnectodes = HCWithThreeSpecialist_MatterSliceAnectodeGrid.GetHCWTS_MatterSliceAnectodeGridByParent(sObjectID);
            if (theAnectodes.Count > 0)
            {
                this.MADDE.CalcValue = "[";
                foreach(HCWithThreeSpecialist_MatterSliceAnectodeGrid.GetHCWTS_MatterSliceAnectodeGridByParent_Class theAnectode in theAnectodes)
                {
                    this.MADDE.CalcValue += theAnectode.Matter + "/" + theAnectode.HalfSlice + "/" + theAnectode.Anectode;
                    this.MADDE.CalcValue += "  ";
                }
                this.MADDE.CalcValue = this.MADDE.CalcValue.Substring(0, this.MADDE.CalcValue.Length - 2);
                this.MADDE.CalcValue += "]\r\n";
            }
            
            this.RAPOR.CalcValue = this.RAPOR.CalcValue + "\r\n\r\n" + this.TANI.CalcValue + "\r\nKARAR:\r\n" + this.MADDE.CalcValue + this.KARAR.CalcValue;
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

        public HealthCommitteeWithThreeSpecialistReport()
        {
            TANI = new TANIGroup(this,"TANI");
            MAIN = new MAINGroup(TANI,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HEALTHCOMMITTEEWITHTHREESPECIALISTREPORT";
            Caption = "Sağlık Kurulu Üç İmza Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            SaveViewOnPrint = EvetHayirEnum.ehEvet;
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