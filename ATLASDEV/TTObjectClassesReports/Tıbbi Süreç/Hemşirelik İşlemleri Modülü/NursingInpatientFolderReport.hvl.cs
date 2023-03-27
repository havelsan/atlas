
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
    /// sil
    /// </summary>
    public partial class NursingInpatientFolderReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class REPORTGroup : TTReportGroup
        {
            public NursingInpatientFolderReport MyParentReport
            {
                get { return (NursingInpatientFolderReport)ParentReport; }
            }

            new public REPORTGroupHeader Header()
            {
                return (REPORTGroupHeader)_header;
            }

            new public REPORTGroupFooter Footer()
            {
                return (REPORTGroupFooter)_footer;
            }

            public TTReportField NewField55 { get {return Header().NewField55;} }
            public TTReportField NewField34 { get {return Header().NewField34;} }
            public TTReportField NewField24 { get {return Header().NewField24;} }
            public TTReportField HPROTOKOLNO { get {return Header().HPROTOKOLNO;} }
            public TTReportField FULLNAME { get {return Header().FULLNAME;} }
            public TTReportField DYERI { get {return Header().DYERI;} }
            public TTReportField DTARIHI { get {return Header().DTARIHI;} }
            public TTReportField FRESOURCE { get {return Header().FRESOURCE;} }
            public TTReportField KARANTINANO { get {return Header().KARANTINANO;} }
            public TTReportField FATHERNAME { get {return Header().FATHERNAME;} }
            public TTReportField BIRLIK { get {return Header().BIRLIK;} }
            public TTReportField SINIFRUTBE { get {return Header().SINIFRUTBE;} }
            public TTReportField MAKAM { get {return Header().MAKAM;} }
            public TTReportField tertibi { get {return Header().tertibi;} }
            public TTReportField kytarihi { get {return Header().kytarihi;} }
            public TTReportField karantinayatist { get {return Header().karantinayatist;} }
            public TTReportField KNO { get {return Header().KNO;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField fname { get {return Header().fname;} }
            public TTReportField labledtarihi { get {return Header().labledtarihi;} }
            public TTReportField lableil { get {return Header().lableil;} }
            public TTReportField labletertip { get {return Header().labletertip;} }
            public TTReportField lablemgmakam { get {return Header().lablemgmakam;} }
            public TTReportField lablebirligi { get {return Header().lablebirligi;} }
            public TTReportField lablesinifrutbe { get {return Header().lablesinifrutbe;} }
            public TTReportField asubesi { get {return Header().asubesi;} }
            public TTReportField XXXXXXLIKSUBE { get {return Header().XXXXXXLIKSUBE;} }
            public TTReportField lableadres { get {return Header().lableadres;} }
            public TTReportField labletelno { get {return Header().labletelno;} }
            public TTReportField hno { get {return Header().hno;} }
            public TTReportField PID { get {return Header().PID;} }
            public TTReportField NewField44 { get {return Header().NewField44;} }
            public TTReportField NewField54 { get {return Header().NewField54;} }
            public TTReportField NewField64 { get {return Header().NewField64;} }
            public TTReportField NewField74 { get {return Header().NewField74;} }
            public TTReportField NewField841 { get {return Header().NewField841;} }
            public TTReportField NewField941 { get {return Header().NewField941;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField251 { get {return Header().NewField251;} }
            public TTReportField NewField351 { get {return Header().NewField351;} }
            public TTReportField ADRES { get {return Header().ADRES;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField25 { get {return Header().NewField25;} }
            public TTReportField NewField35 { get {return Header().NewField35;} }
            public TTReportField NewField45 { get {return Header().NewField45;} }
            public TTReportField LineDay { get {return Header().LineDay;} }
            public TTReportField NewField65 { get {return Header().NewField65;} }
            public TTReportField NewField75 { get {return Header().NewField75;} }
            public TTReportField XXXXXXADI { get {return Header().XXXXXXADI;} }
            public TTReportField TELNO { get {return Header().TELNO;} }
            public TTReportField LinePlace { get {return Header().LinePlace;} }
            public TTReportField PLACE { get {return Header().PLACE;} }
            public TTReportField LablePlace { get {return Header().LablePlace;} }
            public TTReportField telno2 { get {return Header().telno2;} }
            public TTReportField NewField49 { get {return Header().NewField49;} }
            public TTReportField NewField301 { get {return Header().NewField301;} }
            public TTReportField REQUESTDATE { get {return Header().REQUESTDATE;} }
            public TTReportField LineSonu { get {return Header().LineSonu;} }
            public TTReportField LineDischargedate { get {return Header().LineDischargedate;} }
            public TTReportField telno3 { get {return Header().telno3;} }
            public TTReportField NewField101 { get {return Header().NewField101;} }
            public TTReportField DISCHARGEDATE { get {return Header().DISCHARGEDATE;} }
            public TTReportField lablesonu { get {return Header().lablesonu;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField LableDiagnosis { get {return Header().LableDiagnosis;} }
            public TTReportField LinePlace2 { get {return Header().LinePlace2;} }
            public TTReportField EPISODEOBJECTID { get {return Header().EPISODEOBJECTID;} }
            public TTReportRTF SONU { get {return Header().SONU;} }
            public TTReportField SITENAME { get {return Header().SITENAME;} }
            public TTReportField IPOBJECTID { get {return Header().IPOBJECTID;} }
            public TTReportField lableTarih { get {return Footer().lableTarih;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
            public TTReportField lableTarih2 { get {return Footer().lableTarih2;} }
            public TTReportField NewField300 { get {return Footer().NewField300;} }
            public TTReportField NewField6 { get {return Footer().NewField6;} }
            public TTReportField NewField7 { get {return Footer().NewField7;} }
            public REPORTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public REPORTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<InpatientAdmission.GetInpatientFolderInfo_Class>("GetInpatientFolderInfo", InpatientAdmission.GetInpatientFolderInfo((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.REPORT.IPOBJECTID.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new REPORTGroupHeader(this);
                _footer = new REPORTGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class REPORTGroupHeader : TTReportSection
            {
                public NursingInpatientFolderReport MyParentReport
                {
                    get { return (NursingInpatientFolderReport)ParentReport; }
                }
                
                public TTReportField NewField55;
                public TTReportField NewField34;
                public TTReportField NewField24;
                public TTReportField HPROTOKOLNO;
                public TTReportField FULLNAME;
                public TTReportField DYERI;
                public TTReportField DTARIHI;
                public TTReportField FRESOURCE;
                public TTReportField KARANTINANO;
                public TTReportField FATHERNAME;
                public TTReportField BIRLIK;
                public TTReportField SINIFRUTBE;
                public TTReportField MAKAM;
                public TTReportField tertibi;
                public TTReportField kytarihi;
                public TTReportField karantinayatist;
                public TTReportField KNO;
                public TTReportField NAME;
                public TTReportField fname;
                public TTReportField labledtarihi;
                public TTReportField lableil;
                public TTReportField labletertip;
                public TTReportField lablemgmakam;
                public TTReportField lablebirligi;
                public TTReportField lablesinifrutbe;
                public TTReportField asubesi;
                public TTReportField XXXXXXLIKSUBE;
                public TTReportField lableadres;
                public TTReportField labletelno;
                public TTReportField hno;
                public TTReportField PID;
                public TTReportField NewField44;
                public TTReportField NewField54;
                public TTReportField NewField64;
                public TTReportField NewField74;
                public TTReportField NewField841;
                public TTReportField NewField941;
                public TTReportField NewField151;
                public TTReportField NewField251;
                public TTReportField NewField351;
                public TTReportField ADRES;
                public TTReportField NewField5;
                public TTReportField NewField15;
                public TTReportField NewField25;
                public TTReportField NewField35;
                public TTReportField NewField45;
                public TTReportField LineDay;
                public TTReportField NewField65;
                public TTReportField NewField75;
                public TTReportField XXXXXXADI;
                public TTReportField TELNO;
                public TTReportField LinePlace;
                public TTReportField PLACE;
                public TTReportField LablePlace;
                public TTReportField telno2;
                public TTReportField NewField49;
                public TTReportField NewField301;
                public TTReportField REQUESTDATE;
                public TTReportField LineSonu;
                public TTReportField LineDischargedate;
                public TTReportField telno3;
                public TTReportField NewField101;
                public TTReportField DISCHARGEDATE;
                public TTReportField lablesonu;
                public TTReportField NewField1;
                public TTReportField LableDiagnosis;
                public TTReportField LinePlace2;
                public TTReportField EPISODEOBJECTID;
                public TTReportRTF SONU;
                public TTReportField SITENAME;
                public TTReportField IPOBJECTID; 
                public REPORTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 140;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField55 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 8, 146, 24, false);
                    NewField55.Name = "NewField55";
                    NewField55.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField55.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField55.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField55.MultiLine = EvetHayirEnum.ehEvet;
                    NewField55.NoClip = EvetHayirEnum.ehEvet;
                    NewField55.WordBreak = EvetHayirEnum.ehEvet;
                    NewField55.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField55.TextFont.Name = "Arial Narrow";
                    NewField55.TextFont.Size = 15;
                    NewField55.TextFont.Bold = true;
                    NewField55.Value = @"XXXXXXİ XXXXXXLERE MAHSUS İLAÇ YİYECEK KAĞIDI";

                    NewField34 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 37, 201, 108, false);
                    NewField34.Name = "NewField34";
                    NewField34.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField34.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField34.TextFont.Name = "Arial Narrow";
                    NewField34.TextFont.Size = 11;
                    NewField34.TextFont.Bold = true;
                    NewField34.Value = @"";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 37, 79, 108, false);
                    NewField24.Name = "NewField24";
                    NewField24.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField24.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField24.TextFont.Name = "Arial Narrow";
                    NewField24.TextFont.Size = 11;
                    NewField24.TextFont.Bold = true;
                    NewField24.Value = @"";

                    HPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 27, 201, 37, false);
                    HPROTOKOLNO.Name = "HPROTOKOLNO";
                    HPROTOKOLNO.DrawStyle = DrawStyleConstants.vbSolid;
                    HPROTOKOLNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    HPROTOKOLNO.TextFont.Name = "Arial Narrow";
                    HPROTOKOLNO.TextFont.Size = 11;
                    HPROTOKOLNO.TextFont.Bold = true;
                    HPROTOKOLNO.Value = @"";

                    FULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 50, 79, 55, false);
                    FULLNAME.Name = "FULLNAME";
                    FULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME.TextFont.Name = "Arial Narrow";
                    FULLNAME.TextFont.Size = 9;
                    FULLNAME.Value = @"{#PATIENTNAME#} {#PATIENTSURNAME#}";

                    DYERI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 68, 79, 73, false);
                    DYERI.Name = "DYERI";
                    DYERI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERI.TextFont.Name = "Arial Narrow";
                    DYERI.TextFont.Size = 9;
                    DYERI.Value = @"{#PATIENTTOWNOFBIRTH#}/{#PATIENTCITYOFBIRTH#}";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 62, 79, 67, false);
                    DTARIHI.Name = "DTARIHI";
                    DTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHI.TextFormat = @"Short Date";
                    DTARIHI.TextFont.Name = "Arial Narrow";
                    DTARIHI.TextFont.Size = 9;
                    DTARIHI.Value = @"{#PATIENTBIRTHDATE#}";

                    FRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 19, 202, 24, false);
                    FRESOURCE.Name = "FRESOURCE";
                    FRESOURCE.FillStyle = FillStyleConstants.vbFSTransparent;
                    FRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    FRESOURCE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    FRESOURCE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FRESOURCE.MultiLine = EvetHayirEnum.ehEvet;
                    FRESOURCE.WordBreak = EvetHayirEnum.ehEvet;
                    FRESOURCE.TextFont.Name = "Arial Narrow";
                    FRESOURCE.TextFont.Size = 11;
                    FRESOURCE.TextFont.Bold = true;
                    FRESOURCE.Value = @"{#REQUESTDEPARTMENT#}";

                    KARANTINANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 29, 108, 34, false);
                    KARANTINANO.Name = "KARANTINANO";
                    KARANTINANO.FillStyle = FillStyleConstants.vbFSTransparent;
                    KARANTINANO.DrawWidth = 2;
                    KARANTINANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARANTINANO.MultiLine = EvetHayirEnum.ehEvet;
                    KARANTINANO.WordBreak = EvetHayirEnum.ehEvet;
                    KARANTINANO.TextFont.Name = "Arial Narrow";
                    KARANTINANO.TextFont.Size = 9;
                    KARANTINANO.Value = @"{#QUARANTINEPROTOCOLNO#}";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 56, 79, 61, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.MultiLine = EvetHayirEnum.ehEvet;
                    FATHERNAME.WordBreak = EvetHayirEnum.ehEvet;
                    FATHERNAME.TextFont.Name = "Arial Narrow";
                    FATHERNAME.TextFont.Size = 9;
                    FATHERNAME.Value = @"{#FATHERNAME#}";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 64, 200, 75, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIK.TextFont.Name = "Arial Narrow";
                    BIRLIK.TextFont.Size = 9;
                    BIRLIK.Value = @"";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 43, 201, 48, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.MultiLine = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.WordBreak = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.TextFont.Name = "Arial Narrow";
                    SINIFRUTBE.TextFont.Size = 9;
                    SINIFRUTBE.Value = @"";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 80, 200, 91, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.MultiLine = EvetHayirEnum.ehEvet;
                    MAKAM.WordBreak = EvetHayirEnum.ehEvet;
                    MAKAM.TextFont.Name = "Arial Narrow";
                    MAKAM.TextFont.Size = 9;
                    MAKAM.Value = @"";

                    tertibi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 53, 200, 58, false);
                    tertibi.Name = "tertibi";
                    tertibi.FieldType = ReportFieldTypeEnum.ftVariable;
                    tertibi.MultiLine = EvetHayirEnum.ehEvet;
                    tertibi.WordBreak = EvetHayirEnum.ehEvet;
                    tertibi.TextFont.Name = "Arial Narrow";
                    tertibi.TextFont.Size = 9;
                    tertibi.Value = @"";

                    kytarihi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 38, 79, 43, false);
                    kytarihi.Name = "kytarihi";
                    kytarihi.FieldType = ReportFieldTypeEnum.ftVariable;
                    kytarihi.TextFormat = @"Medium Date";
                    kytarihi.MultiLine = EvetHayirEnum.ehEvet;
                    kytarihi.WordBreak = EvetHayirEnum.ehEvet;
                    kytarihi.TextFont.Name = "Arial Narrow";
                    kytarihi.TextFont.Size = 9;
                    kytarihi.Value = @"{#QUARANTINEINPATIENTDATE#}";

                    karantinayatist = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 38, 41, 43, false);
                    karantinayatist.Name = "karantinayatist";
                    karantinayatist.TextFont.Name = "Arial Narrow";
                    karantinayatist.TextFont.Size = 11;
                    karantinayatist.TextFont.Bold = true;
                    karantinayatist.Value = @"Yatış Tarihi";

                    KNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 29, 60, 34, false);
                    KNO.Name = "KNO";
                    KNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    KNO.TextFont.Name = "Arial Narrow";
                    KNO.TextFont.Size = 11;
                    KNO.TextFont.Bold = true;
                    KNO.Value = @"XXXXXX Karantina No : ";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 50, 41, 55, false);
                    NAME.Name = "NAME";
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.Size = 11;
                    NAME.TextFont.Bold = true;
                    NAME.Value = @"Ad Soyad";

                    fname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 56, 41, 61, false);
                    fname.Name = "fname";
                    fname.TextFont.Name = "Arial Narrow";
                    fname.TextFont.Size = 11;
                    fname.TextFont.Bold = true;
                    fname.Value = @"Baba Adı";

                    labledtarihi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 62, 41, 67, false);
                    labledtarihi.Name = "labledtarihi";
                    labledtarihi.TextFont.Name = "Arial Narrow";
                    labledtarihi.TextFont.Size = 11;
                    labledtarihi.TextFont.Bold = true;
                    labledtarihi.Value = @"Doğum Tarihi";

                    lableil = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 68, 41, 73, false);
                    lableil.Name = "lableil";
                    lableil.TextFont.Name = "Arial Narrow";
                    lableil.TextFont.Size = 11;
                    lableil.TextFont.Bold = true;
                    lableil.Value = @"Doğum Yeri";

                    labletertip = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 48, 166, 53, false);
                    labletertip.Name = "labletertip";
                    labletertip.TextFont.Name = "Arial Narrow";
                    labletertip.TextFont.Size = 11;
                    labletertip.TextFont.Bold = true;
                    labletertip.Value = @"Tertip/Sicil";

                    lablemgmakam = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 75, 166, 80, false);
                    lablemgmakam.Name = "lablemgmakam";
                    lablemgmakam.TextFont.Name = "Arial Narrow";
                    lablemgmakam.TextFont.Size = 11;
                    lablemgmakam.TextFont.Bold = true;
                    lablemgmakam.Value = @"Muay.Gön.Makam";

                    lablebirligi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 59, 166, 64, false);
                    lablebirligi.Name = "lablebirligi";
                    lablebirligi.TextFont.Name = "Arial Narrow";
                    lablebirligi.TextFont.Size = 11;
                    lablebirligi.TextFont.Bold = true;
                    lablebirligi.Value = @"Birliği";

                    lablesinifrutbe = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 38, 166, 43, false);
                    lablesinifrutbe.Name = "lablesinifrutbe";
                    lablesinifrutbe.TextFont.Name = "Arial Narrow";
                    lablesinifrutbe.TextFont.Size = 11;
                    lablesinifrutbe.TextFont.Bold = true;
                    lablesinifrutbe.Value = @"Sınıf ve Rütbe";

                    asubesi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 91, 166, 96, false);
                    asubesi.Name = "asubesi";
                    asubesi.TextFont.Name = "Arial Narrow";
                    asubesi.TextFont.Size = 11;
                    asubesi.TextFont.Bold = true;
                    asubesi.Value = @"Ask.Şubesi";

                    XXXXXXLIKSUBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 96, 200, 107, false);
                    XXXXXXLIKSUBE.Name = "XXXXXXLIKSUBE";
                    XXXXXXLIKSUBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXLIKSUBE.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXLIKSUBE.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXLIKSUBE.TextFont.Name = "Arial Narrow";
                    XXXXXXLIKSUBE.TextFont.Size = 9;
                    XXXXXXLIKSUBE.Value = @"";

                    lableadres = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 80, 41, 85, false);
                    lableadres.Name = "lableadres";
                    lableadres.TextFont.Name = "Arial Narrow";
                    lableadres.TextFont.Size = 11;
                    lableadres.TextFont.Bold = true;
                    lableadres.Value = @"Devamlı Adresi";

                    labletelno = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 74, 41, 79, false);
                    labletelno.Name = "labletelno";
                    labletelno.TextFont.Name = "Arial Narrow";
                    labletelno.TextFont.Size = 11;
                    labletelno.TextFont.Bold = true;
                    labletelno.Value = @"Tel No";

                    hno = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 44, 41, 49, false);
                    hno.Name = "hno";
                    hno.TextFont.Name = "Arial Narrow";
                    hno.TextFont.Size = 11;
                    hno.TextFont.Bold = true;
                    hno.Value = @"Hasta T.C.Kimlik No";

                    PID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 44, 79, 49, false);
                    PID.Name = "PID";
                    PID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PID.TextFont.Name = "Arial Narrow";
                    PID.TextFont.Size = 9;
                    PID.Value = @"{#UNIQUEREFNO#}";

                    NewField44 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 37, 134, 118, false);
                    NewField44.Name = "NewField44";
                    NewField44.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField44.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField44.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField44.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField44.MultiLine = EvetHayirEnum.ehEvet;
                    NewField44.WordBreak = EvetHayirEnum.ehEvet;
                    NewField44.TextFont.Name = "Arial Narrow";
                    NewField44.TextFont.Size = 11;
                    NewField44.TextFont.Bold = true;
                    NewField44.Value = @"  Sıhhi muamele veya otopsi raporu";

                    NewField54 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 44, 43, 49, false);
                    NewField54.Name = "NewField54";
                    NewField54.TextFont.Name = "Arial Narrow";
                    NewField54.TextFont.Size = 11;
                    NewField54.TextFont.Bold = true;
                    NewField54.Value = @":";

                    NewField64 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 50, 43, 55, false);
                    NewField64.Name = "NewField64";
                    NewField64.TextFont.Name = "Arial Narrow";
                    NewField64.TextFont.Size = 11;
                    NewField64.TextFont.Bold = true;
                    NewField64.Value = @":";

                    NewField74 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 56, 43, 61, false);
                    NewField74.Name = "NewField74";
                    NewField74.TextFont.Name = "Arial Narrow";
                    NewField74.TextFont.Size = 11;
                    NewField74.TextFont.Bold = true;
                    NewField74.Value = @":";

                    NewField841 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 62, 43, 67, false);
                    NewField841.Name = "NewField841";
                    NewField841.TextFont.Name = "Arial Narrow";
                    NewField841.TextFont.Size = 11;
                    NewField841.TextFont.Bold = true;
                    NewField841.Value = @":";

                    NewField941 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 68, 43, 73, false);
                    NewField941.Name = "NewField941";
                    NewField941.TextFont.Name = "Arial Narrow";
                    NewField941.TextFont.Size = 11;
                    NewField941.TextFont.Bold = true;
                    NewField941.Value = @":";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 74, 43, 79, false);
                    NewField151.Name = "NewField151";
                    NewField151.TextFont.Name = "Arial Narrow";
                    NewField151.TextFont.Size = 11;
                    NewField151.TextFont.Bold = true;
                    NewField151.Value = @":";

                    NewField251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 80, 43, 85, false);
                    NewField251.Name = "NewField251";
                    NewField251.TextFont.Name = "Arial Narrow";
                    NewField251.TextFont.Size = 11;
                    NewField251.TextFont.Bold = true;
                    NewField251.Value = @":";

                    NewField351 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 38, 43, 43, false);
                    NewField351.Name = "NewField351";
                    NewField351.TextFont.Name = "Arial Narrow";
                    NewField351.TextFont.Size = 11;
                    NewField351.TextFont.Bold = true;
                    NewField351.Value = @":";

                    ADRES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 85, 78, 107, false);
                    ADRES.Name = "ADRES";
                    ADRES.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRES.MultiLine = EvetHayirEnum.ehEvet;
                    ADRES.NoClip = EvetHayirEnum.ehEvet;
                    ADRES.WordBreak = EvetHayirEnum.ehEvet;
                    ADRES.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADRES.TextFont.Name = "Arial Narrow";
                    ADRES.TextFont.Size = 9;
                    ADRES.Value = @"{#ADDRESS#}
{#ADDRESSTOWN#}/{#ADDRESSCITY#}/{#ADDRESSCOUNTRY#}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 48, 168, 53, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Name = "Arial Narrow";
                    NewField5.TextFont.Size = 11;
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @":";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 59, 168, 64, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Name = "Arial Narrow";
                    NewField15.TextFont.Size = 11;
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @":";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 75, 168, 80, false);
                    NewField25.Name = "NewField25";
                    NewField25.TextFont.Name = "Arial Narrow";
                    NewField25.TextFont.Size = 11;
                    NewField25.TextFont.Bold = true;
                    NewField25.Value = @":";

                    NewField35 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 91, 168, 96, false);
                    NewField35.Name = "NewField35";
                    NewField35.TextFont.Name = "Arial Narrow";
                    NewField35.TextFont.Size = 11;
                    NewField35.TextFont.Bold = true;
                    NewField35.Value = @":";

                    NewField45 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 38, 168, 43, false);
                    NewField45.Name = "NewField45";
                    NewField45.TextFont.Name = "Arial Narrow";
                    NewField45.TextFont.Size = 11;
                    NewField45.TextFont.Bold = true;
                    NewField45.Value = @":";

                    LineDay = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 118, 134, 130, false);
                    LineDay.Name = "LineDay";
                    LineDay.DrawStyle = DrawStyleConstants.vbSolid;
                    LineDay.FillStyle = FillStyleConstants.vbFSTransparent;
                    LineDay.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LineDay.TextFont.Name = "Arial Narrow";
                    LineDay.TextFont.Size = 11;
                    LineDay.TextFont.Bold = true;
                    LineDay.Value = @"XXXXXXye Yattığı Gün Sayısı :";

                    NewField65 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 9, 203, 18, false);
                    NewField65.Name = "NewField65";
                    NewField65.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField65.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField65.TextFont.Name = "Arial Narrow";
                    NewField65.TextFont.Size = 11;
                    NewField65.TextFont.Bold = true;
                    NewField65.Value = @"Yatış İsteğinde Bulunan Bölüm";

                    NewField75 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 20, 63, 25, false);
                    NewField75.Name = "NewField75";
                    NewField75.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField75.WordBreak = EvetHayirEnum.ehEvet;
                    NewField75.TextFont.Name = "Arial Narrow";
                    NewField75.TextFont.Size = 11;
                    NewField75.TextFont.Bold = true;
                    NewField75.Value = @"................................................ Reviri";

                    XXXXXXADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 9, 63, 18, false);
                    XXXXXXADI.Name = "XXXXXXADI";
                    XXXXXXADI.FillStyle = FillStyleConstants.vbFSTransparent;
                    XXXXXXADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXADI.CaseFormat = CaseFormatEnum.fcTitleCase;
                    XXXXXXADI.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXADI.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXADI.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXADI.TextFont.Name = "Arial Narrow";
                    XXXXXXADI.TextFont.Bold = true;
                    XXXXXXADI.Value = @"{%SITENAME%}";

                    TELNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 74, 79, 79, false);
                    TELNO.Name = "TELNO";
                    TELNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TELNO.TextFont.Name = "Arial Narrow";
                    TELNO.TextFont.Size = 9;
                    TELNO.Value = @"{#PHONE#}";

                    LinePlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 108, 79, 119, false);
                    LinePlace.Name = "LinePlace";
                    LinePlace.DrawStyle = DrawStyleConstants.vbSolid;
                    LinePlace.FillStyle = FillStyleConstants.vbFSTransparent;
                    LinePlace.TextFont.Name = "Arial Narrow";
                    LinePlace.TextFont.Size = 11;
                    LinePlace.TextFont.Bold = true;
                    LinePlace.Value = @"";

                    PLACE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 110, 78, 115, false);
                    PLACE.Name = "PLACE";
                    PLACE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PLACE.TextFont.Name = "Arial Narrow";
                    PLACE.TextFont.Size = 9;
                    PLACE.Value = @"";

                    LablePlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 110, 41, 115, false);
                    LablePlace.Name = "LablePlace";
                    LablePlace.TextFont.Name = "Arial Narrow";
                    LablePlace.TextFont.Size = 11;
                    LablePlace.TextFont.Bold = true;
                    LablePlace.Value = @"Geldiği Yer";

                    telno2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 121, 41, 126, false);
                    telno2.Name = "telno2";
                    telno2.TextFont.Name = "Arial Narrow";
                    telno2.TextFont.Size = 11;
                    telno2.TextFont.Bold = true;
                    telno2.Value = @"Geldiği Tarih";

                    NewField49 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 110, 43, 115, false);
                    NewField49.Name = "NewField49";
                    NewField49.TextFont.Name = "Arial Narrow";
                    NewField49.TextFont.Size = 11;
                    NewField49.TextFont.Bold = true;
                    NewField49.Value = @":";

                    NewField301 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 121, 43, 126, false);
                    NewField301.Name = "NewField301";
                    NewField301.TextFont.Name = "Arial Narrow";
                    NewField301.TextFont.Size = 11;
                    NewField301.TextFont.Bold = true;
                    NewField301.Value = @":";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 121, 79, 126, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"Short Date";
                    REQUESTDATE.TextFont.Name = "Arial Narrow";
                    REQUESTDATE.TextFont.Size = 9;
                    REQUESTDATE.Value = @"{#REQUESTDATE#}";

                    LineSonu = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 108, 201, 119, false);
                    LineSonu.Name = "LineSonu";
                    LineSonu.DrawStyle = DrawStyleConstants.vbSolid;
                    LineSonu.FillStyle = FillStyleConstants.vbFSTransparent;
                    LineSonu.TextFont.Name = "Arial Narrow";
                    LineSonu.TextFont.Size = 11;
                    LineSonu.TextFont.Bold = true;
                    LineSonu.Value = @"";

                    LineDischargedate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 119, 201, 130, false);
                    LineDischargedate.Name = "LineDischargedate";
                    LineDischargedate.DrawStyle = DrawStyleConstants.vbSolid;
                    LineDischargedate.FillStyle = FillStyleConstants.vbFSTransparent;
                    LineDischargedate.TextFont.Name = "Arial Narrow";
                    LineDischargedate.TextFont.Size = 11;
                    LineDischargedate.TextFont.Bold = true;
                    LineDischargedate.Value = @"";

                    telno3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 121, 165, 126, false);
                    telno3.Name = "telno3";
                    telno3.TextFont.Name = "Arial Narrow";
                    telno3.TextFont.Size = 11;
                    telno3.TextFont.Bold = true;
                    telno3.Value = @"Çıktığı Tarih";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 121, 167, 126, false);
                    NewField101.Name = "NewField101";
                    NewField101.TextFont.Name = "Arial Narrow";
                    NewField101.TextFont.Size = 11;
                    NewField101.TextFont.Bold = true;
                    NewField101.Value = @":";

                    DISCHARGEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 121, 200, 126, false);
                    DISCHARGEDATE.Name = "DISCHARGEDATE";
                    DISCHARGEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISCHARGEDATE.TextFormat = @"Short Date";
                    DISCHARGEDATE.TextFont.Name = "Arial Narrow";
                    DISCHARGEDATE.TextFont.Size = 9;
                    DISCHARGEDATE.Value = @"{#HOSPITALDISCHARGEDATE#}";

                    lablesonu = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 110, 165, 115, false);
                    lablesonu.Name = "lablesonu";
                    lablesonu.TextFont.Name = "Arial Narrow";
                    lablesonu.TextFont.Size = 11;
                    lablesonu.TextFont.Bold = true;
                    lablesonu.Value = @"Sonu";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 110, 167, 115, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @":";

                    LableDiagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 130, 201, 140, false);
                    LableDiagnosis.Name = "LableDiagnosis";
                    LableDiagnosis.DrawStyle = DrawStyleConstants.vbSolid;
                    LableDiagnosis.FillStyle = FillStyleConstants.vbFSTransparent;
                    LableDiagnosis.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LableDiagnosis.TextFont.Name = "Arial Narrow";
                    LableDiagnosis.TextFont.Size = 11;
                    LableDiagnosis.TextFont.Bold = true;
                    LableDiagnosis.Value = @"Teşhis / Klinik Tanı";

                    LinePlace2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 119, 79, 130, false);
                    LinePlace2.Name = "LinePlace2";
                    LinePlace2.DrawStyle = DrawStyleConstants.vbSolid;
                    LinePlace2.FillStyle = FillStyleConstants.vbFSTransparent;
                    LinePlace2.TextFont.Name = "Arial Narrow";
                    LinePlace2.TextFont.Size = 11;
                    LinePlace2.TextFont.Bold = true;
                    LinePlace2.Value = @"";

                    EPISODEOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 4, 140, 9, false);
                    EPISODEOBJECTID.Name = "EPISODEOBJECTID";
                    EPISODEOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEOBJECTID.Value = @"{#EPISODE#}";

                    SONU = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 167, 109, 199, 118, false);
                    SONU.Name = "SONU";
                    SONU.CanExpand = EvetHayirEnum.ehHayir;
                    SONU.Value = @"";

                    SITENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 4, 173, 9, false);
                    SITENAME.Name = "SITENAME";
                    SITENAME.Visible = EvetHayirEnum.ehHayir;
                    SITENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", ""XXXXXX"")";

                    IPOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 34, 271, 39, false);
                    IPOBJECTID.Name = "IPOBJECTID";
                    IPOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    IPOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    IPOBJECTID.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmission.GetInpatientFolderInfo_Class dataset_GetInpatientFolderInfo = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmission.GetInpatientFolderInfo_Class>(0);
                    NewField55.CalcValue = NewField55.Value;
                    NewField34.CalcValue = NewField34.Value;
                    NewField24.CalcValue = NewField24.Value;
                    HPROTOKOLNO.CalcValue = HPROTOKOLNO.Value;
                    FULLNAME.CalcValue = (dataset_GetInpatientFolderInfo != null ? Globals.ToStringCore(dataset_GetInpatientFolderInfo.Patientname) : "") + @" " + (dataset_GetInpatientFolderInfo != null ? Globals.ToStringCore(dataset_GetInpatientFolderInfo.Patientsurname) : "");
                    DYERI.CalcValue = (dataset_GetInpatientFolderInfo != null ? Globals.ToStringCore(dataset_GetInpatientFolderInfo.Patienttownofbirth) : "") + @"/" + (dataset_GetInpatientFolderInfo != null ? Globals.ToStringCore(dataset_GetInpatientFolderInfo.Patientcityofbirth) : "");
                    DTARIHI.CalcValue = (dataset_GetInpatientFolderInfo != null ? Globals.ToStringCore(dataset_GetInpatientFolderInfo.Patientbirthdate) : "");
                    FRESOURCE.CalcValue = (dataset_GetInpatientFolderInfo != null ? Globals.ToStringCore(dataset_GetInpatientFolderInfo.Requestdepartment) : "");
                    KARANTINANO.CalcValue = (dataset_GetInpatientFolderInfo != null ? Globals.ToStringCore(dataset_GetInpatientFolderInfo.QuarantineProtocolNo) : "");
                    FATHERNAME.CalcValue = (dataset_GetInpatientFolderInfo != null ? Globals.ToStringCore(dataset_GetInpatientFolderInfo.FatherName) : "");
                    BIRLIK.CalcValue = @"";
                    SINIFRUTBE.CalcValue = @"";
                    MAKAM.CalcValue = @"";
                    tertibi.CalcValue = @"";
                    kytarihi.CalcValue = (dataset_GetInpatientFolderInfo != null ? Globals.ToStringCore(dataset_GetInpatientFolderInfo.Quarantineinpatientdate) : "");
                    karantinayatist.CalcValue = karantinayatist.Value;
                    KNO.CalcValue = KNO.Value;
                    NAME.CalcValue = NAME.Value;
                    fname.CalcValue = fname.Value;
                    labledtarihi.CalcValue = labledtarihi.Value;
                    lableil.CalcValue = lableil.Value;
                    labletertip.CalcValue = labletertip.Value;
                    lablemgmakam.CalcValue = lablemgmakam.Value;
                    lablebirligi.CalcValue = lablebirligi.Value;
                    lablesinifrutbe.CalcValue = lablesinifrutbe.Value;
                    asubesi.CalcValue = asubesi.Value;
                    XXXXXXLIKSUBE.CalcValue = @"";
                    lableadres.CalcValue = lableadres.Value;
                    labletelno.CalcValue = labletelno.Value;
                    hno.CalcValue = hno.Value;
                    PID.CalcValue = (dataset_GetInpatientFolderInfo != null ? Globals.ToStringCore(dataset_GetInpatientFolderInfo.UniqueRefNo) : "");
                    NewField44.CalcValue = NewField44.Value;
                    NewField54.CalcValue = NewField54.Value;
                    NewField64.CalcValue = NewField64.Value;
                    NewField74.CalcValue = NewField74.Value;
                    NewField841.CalcValue = NewField841.Value;
                    NewField941.CalcValue = NewField941.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField251.CalcValue = NewField251.Value;
                    NewField351.CalcValue = NewField351.Value;
                    ADRES.CalcValue = (dataset_GetInpatientFolderInfo != null ? Globals.ToStringCore(dataset_GetInpatientFolderInfo.Address) : "") + @"
" + (dataset_GetInpatientFolderInfo != null ? Globals.ToStringCore(dataset_GetInpatientFolderInfo.Addresstown) : "") + @"/" + (dataset_GetInpatientFolderInfo != null ? Globals.ToStringCore(dataset_GetInpatientFolderInfo.Addresscity) : "") + @"/" + (dataset_GetInpatientFolderInfo != null ? Globals.ToStringCore(dataset_GetInpatientFolderInfo.Addresscountry) : "");
                    NewField5.CalcValue = NewField5.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField25.CalcValue = NewField25.Value;
                    NewField35.CalcValue = NewField35.Value;
                    NewField45.CalcValue = NewField45.Value;
                    LineDay.CalcValue = LineDay.Value;
                    NewField65.CalcValue = NewField65.Value;
                    NewField75.CalcValue = NewField75.Value;
                    SITENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "XXXXXX");
                    XXXXXXADI.CalcValue = MyParentReport.REPORT.SITENAME.CalcValue;
                    TELNO.CalcValue = (dataset_GetInpatientFolderInfo != null ? Globals.ToStringCore(dataset_GetInpatientFolderInfo.Phone) : "");
                    LinePlace.CalcValue = LinePlace.Value;
                    PLACE.CalcValue = @"";
                    LablePlace.CalcValue = LablePlace.Value;
                    telno2.CalcValue = telno2.Value;
                    NewField49.CalcValue = NewField49.Value;
                    NewField301.CalcValue = NewField301.Value;
                    REQUESTDATE.CalcValue = (dataset_GetInpatientFolderInfo != null ? Globals.ToStringCore(dataset_GetInpatientFolderInfo.RequestDate) : "");
                    LineSonu.CalcValue = LineSonu.Value;
                    LineDischargedate.CalcValue = LineDischargedate.Value;
                    telno3.CalcValue = telno3.Value;
                    NewField101.CalcValue = NewField101.Value;
                    DISCHARGEDATE.CalcValue = (dataset_GetInpatientFolderInfo != null ? Globals.ToStringCore(dataset_GetInpatientFolderInfo.HospitalDischargeDate) : "");
                    lablesonu.CalcValue = lablesonu.Value;
                    NewField1.CalcValue = NewField1.Value;
                    LableDiagnosis.CalcValue = LableDiagnosis.Value;
                    LinePlace2.CalcValue = LinePlace2.Value;
                    EPISODEOBJECTID.CalcValue = (dataset_GetInpatientFolderInfo != null ? Globals.ToStringCore(dataset_GetInpatientFolderInfo.Episode) : "");
                    SONU.CalcValue = SONU.Value;
                    IPOBJECTID.CalcValue = @"";
                    return new TTReportObject[] { NewField55,NewField34,NewField24,HPROTOKOLNO,FULLNAME,DYERI,DTARIHI,FRESOURCE,KARANTINANO,FATHERNAME,BIRLIK,SINIFRUTBE,MAKAM,tertibi,kytarihi,karantinayatist,KNO,NAME,fname,labledtarihi,lableil,labletertip,lablemgmakam,lablebirligi,lablesinifrutbe,asubesi,XXXXXXLIKSUBE,lableadres,labletelno,hno,PID,NewField44,NewField54,NewField64,NewField74,NewField841,NewField941,NewField151,NewField251,NewField351,ADRES,NewField5,NewField15,NewField25,NewField35,NewField45,LineDay,NewField65,NewField75,SITENAME,XXXXXXADI,TELNO,LinePlace,PLACE,LablePlace,telno2,NewField49,NewField301,REQUESTDATE,LineSonu,LineDischargedate,telno3,NewField101,DISCHARGEDATE,lablesonu,NewField1,LableDiagnosis,LinePlace2,EPISODEOBJECTID,SONU,IPOBJECTID};
                }
                public override void RunPreScript()
                {
#region REPORT HEADER_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((InpatientFolderReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            NursingApplication nursingApplication = (NursingApplication)this.ParentReport.ReportObjectContext.GetObject(new Guid(sObjectID),"NursingApplication");
            if(nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission is InpatientAdmission)
            {
                this.IPOBJECTID.Value=((InpatientAdmission)nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission).ObjectID.ToString();
                this.SONU.Value=((InpatientAdmission)nursingApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission).GetDischargedConclusion();
            }
#endregion REPORT HEADER_PreScript
                }
            }
            public partial class REPORTGroupFooter : TTReportSection
            {
                public NursingInpatientFolderReport MyParentReport
                {
                    get { return (NursingInpatientFolderReport)ParentReport; }
                }
                
                public TTReportField lableTarih;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField lableTarih2;
                public TTReportField NewField300;
                public TTReportField NewField6;
                public TTReportField NewField7; 
                public REPORTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 94;
                    RepeatCount = 0;
                    
                    lableTarih = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 49, 5, false);
                    lableTarih.Name = "lableTarih";
                    lableTarih.DrawStyle = DrawStyleConstants.vbSolid;
                    lableTarih.DrawWidth = 2;
                    lableTarih.TextFont.Name = "Arial Narrow";
                    lableTarih.TextFont.Size = 11;
                    lableTarih.TextFont.Bold = true;
                    lableTarih.TextFont.CharSet = 0;
                    lableTarih.Value = @"Tarih";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 0, 96, 5, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.DrawWidth = 2;
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 0;
                    NewField2.Value = @"Dahili ilaçlar";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 0, 148, 5, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.DrawWidth = 2;
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.TextFont.Size = 11;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 0;
                    NewField3.Value = @"Harici ilaçlar";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 0, 201, 5, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.DrawWidth = 2;
                    NewField4.TextFont.Name = "Arial Narrow";
                    NewField4.TextFont.Size = 11;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 0;
                    NewField4.Value = @"Besi Derecesi";

                    lableTarih2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 5, 49, 90, false);
                    lableTarih2.Name = "lableTarih2";
                    lableTarih2.DrawStyle = DrawStyleConstants.vbSolid;
                    lableTarih2.DrawWidth = 2;
                    lableTarih2.TextFont.Name = "Arial Narrow";
                    lableTarih2.TextFont.Size = 11;
                    lableTarih2.TextFont.Bold = true;
                    lableTarih2.TextFont.CharSet = 0;
                    lableTarih2.Value = @"";

                    NewField300 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 5, 96, 90, false);
                    NewField300.Name = "NewField300";
                    NewField300.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField300.DrawWidth = 2;
                    NewField300.TextFont.Name = "Arial Narrow";
                    NewField300.TextFont.Size = 11;
                    NewField300.TextFont.Bold = true;
                    NewField300.TextFont.CharSet = 0;
                    NewField300.Value = @"";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 5, 148, 90, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.DrawWidth = 2;
                    NewField6.TextFont.Name = "Arial Narrow";
                    NewField6.TextFont.Size = 11;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 0;
                    NewField6.Value = @"";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 5, 200, 90, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.DrawWidth = 2;
                    NewField7.TextFont.Name = "Arial Narrow";
                    NewField7.TextFont.Size = 11;
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 0;
                    NewField7.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientAdmission.GetInpatientFolderInfo_Class dataset_GetInpatientFolderInfo = ParentGroup.rsGroup.GetCurrentRecord<InpatientAdmission.GetInpatientFolderInfo_Class>(0);
                    lableTarih.CalcValue = lableTarih.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    lableTarih2.CalcValue = lableTarih2.Value;
                    NewField300.CalcValue = NewField300.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    return new TTReportObject[] { lableTarih,NewField2,NewField3,NewField4,lableTarih2,NewField300,NewField6,NewField7};
                }
            }

        }

        public REPORTGroup REPORT;

        public partial class DIAGNOSISGroup : TTReportGroup
        {
            public NursingInpatientFolderReport MyParentReport
            {
                get { return (NursingInpatientFolderReport)ParentReport; }
            }

            new public DIAGNOSISGroupBody Body()
            {
                return (DIAGNOSISGroupBody)_body;
            }
            public TTReportField DIAGNOSISTYPE { get {return Body().DIAGNOSISTYPE;} }
            public TTReportField DIAGNOSEDATE { get {return Body().DIAGNOSEDATE;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public DIAGNOSISGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DIAGNOSISGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<DiagnosisGrid.GetDiagnosisByEpisode_Class>("GetDiagnosisByEpisode", DiagnosisGrid.GetDiagnosisByEpisode((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.REPORT.EPISODEOBJECTID.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new DIAGNOSISGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class DIAGNOSISGroupBody : TTReportSection
            {
                public NursingInpatientFolderReport MyParentReport
                {
                    get { return (NursingInpatientFolderReport)ParentReport; }
                }
                
                public TTReportField DIAGNOSISTYPE;
                public TTReportField DIAGNOSEDATE;
                public TTReportField NAME; 
                public DIAGNOSISGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    DIAGNOSISTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 0, 201, 7, false);
                    DIAGNOSISTYPE.Name = "DIAGNOSISTYPE";
                    DIAGNOSISTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISTYPE.DrawWidth = 2;
                    DIAGNOSISTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISTYPE.ObjectDefName = "DiagnosisTypeEnum";
                    DIAGNOSISTYPE.DataMember = "DISPLAYTEXT";
                    DIAGNOSISTYPE.TextFont.Name = "Arial Narrow";
                    DIAGNOSISTYPE.TextFont.Size = 9;
                    DIAGNOSISTYPE.Value = @"{#DIAGNOSISTYPE#}";

                    DIAGNOSEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 50, 7, false);
                    DIAGNOSEDATE.Name = "DIAGNOSEDATE";
                    DIAGNOSEDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSEDATE.DrawWidth = 2;
                    DIAGNOSEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSEDATE.TextFormat = @"Short Date";
                    DIAGNOSEDATE.TextFont.Name = "Arial Narrow";
                    DIAGNOSEDATE.TextFont.Size = 9;
                    DIAGNOSEDATE.Value = @"{#DIAGNOSEDATE#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 0, 148, 7, false);
                    NAME.Name = "NAME";
                    NAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAME.DrawWidth = 2;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.Size = 9;
                    NAME.Value = @"{#NAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DiagnosisGrid.GetDiagnosisByEpisode_Class dataset_GetDiagnosisByEpisode = ParentGroup.rsGroup.GetCurrentRecord<DiagnosisGrid.GetDiagnosisByEpisode_Class>(0);
                    DIAGNOSISTYPE.CalcValue = (dataset_GetDiagnosisByEpisode != null ? Globals.ToStringCore(dataset_GetDiagnosisByEpisode.DiagnosisType) : "");
                    DIAGNOSISTYPE.PostFieldValueCalculation();
                    DIAGNOSEDATE.CalcValue = (dataset_GetDiagnosisByEpisode != null ? Globals.ToStringCore(dataset_GetDiagnosisByEpisode.Diagnosedate) : "");
                    NAME.CalcValue = (dataset_GetDiagnosisByEpisode != null ? Globals.ToStringCore(dataset_GetDiagnosisByEpisode.Name) : "");
                    return new TTReportObject[] { DIAGNOSISTYPE,DIAGNOSEDATE,NAME};
                }
            }

        }

        public DIAGNOSISGroup DIAGNOSIS;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public NursingInpatientFolderReport()
        {
            REPORT = new REPORTGroup(this,"REPORT");
            DIAGNOSIS = new DIAGNOSISGroup(REPORT,"DIAGNOSIS");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Hasta Yatış", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "NURSINGINPATIENTFOLDERREPORT";
            Caption = "sil";
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