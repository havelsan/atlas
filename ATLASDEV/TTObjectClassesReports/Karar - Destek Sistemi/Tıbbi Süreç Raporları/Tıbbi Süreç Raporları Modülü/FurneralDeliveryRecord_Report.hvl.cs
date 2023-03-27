
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
    /// Cenaze Teslim Tutanağı
    /// </summary>
    public partial class FurneralDeliveryRecord : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public FurneralDeliveryRecord MyParentReport
            {
                get { return (FurneralDeliveryRecord)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField BAŞLIK { get {return Body().BAŞLIK;} }
            public TTReportField YAZI { get {return Body().YAZI;} }
            public TTReportField PATIENTNAME { get {return Body().PATIENTNAME;} }
            public TTReportField PATIENTSURNAME { get {return Body().PATIENTSURNAME;} }
            public TTReportField VEFATTARIHI { get {return Body().VEFATTARIHI;} }
            public TTReportField YAKINI { get {return Body().YAKINI;} }
            public TTReportField LABEL1 { get {return Body().LABEL1;} }
            public TTReportField TESLIMEDENADSOYAD { get {return Body().TESLIMEDENADSOYAD;} }
            public TTReportField LABEL2 { get {return Body().LABEL2;} }
            public TTReportField TESLIMALANADSOYAD { get {return Body().TESLIMALANADSOYAD;} }
            public TTReportField LABEL3 { get {return Body().LABEL3;} }
            public TTReportField LABEL4 { get {return Body().LABEL4;} }
            public TTReportField LABEL5 { get {return Body().LABEL5;} }
            public TTReportField TESLİMALANADRES { get {return Body().TESLİMALANADRES;} }
            public TTReportField TESLİMALANTCKIMLIKNO { get {return Body().TESLİMALANTCKIMLIKNO;} }
            public TTReportField TESLİMALANTELNO { get {return Body().TESLİMALANTELNO;} }
            public TTReportField LABEL6 { get {return Body().LABEL6;} }
            public TTReportField ONAYMAKAMI { get {return Body().ONAYMAKAMI;} }
            public TTReportField XXXXXXBASLIK { get {return Body().XXXXXXBASLIK;} }
            public TTReportField KLINIK { get {return Body().KLINIK;} }
            public TTReportField TESLİMALANBILGILER { get {return Body().TESLİMALANBILGILER;} }
            public TTReportField LABEL11 { get {return Body().LABEL11;} }
            public TTReportField DOGUMYERITARIHI { get {return Body().DOGUMYERITARIHI;} }
            public TTReportField LABEL12 { get {return Body().LABEL12;} }
            public TTReportField LABEL121 { get {return Body().LABEL121;} }
            public TTReportField LABEL122 { get {return Body().LABEL122;} }
            public TTReportField GELISTARIHI { get {return Body().GELISTARIHI;} }
            public TTReportField LABEL1121 { get {return Body().LABEL1121;} }
            public TTReportField MEZARLIGAGIDISTARIHI { get {return Body().MEZARLIGAGIDISTARIHI;} }
            public TTReportField LABEL1221 { get {return Body().LABEL1221;} }
            public TTReportField MEZARLIKADAPARSELNO { get {return Body().MEZARLIKADAPARSELNO;} }
            public TTReportField LABEL11211 { get {return Body().LABEL11211;} }
            public TTReportField PROTOKOLNO { get {return Body().PROTOKOLNO;} }
            public TTReportField LABEL1122 { get {return Body().LABEL1122;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField OLUMNEDENI { get {return Body().OLUMNEDENI;} }
            public TTReportField LABEL15 { get {return Body().LABEL15;} }
            public TTReportField TESLİMEDENTCKIMLIKNO { get {return Body().TESLİMEDENTCKIMLIKNO;} }
            public TTReportField NAKLEDİLDİĞİİİL { get {return Body().NAKLEDİLDİĞİİİL;} }
            public TTReportField LABEL111211 { get {return Body().LABEL111211;} }
            public TTReportField NewField1131 { get {return Body().NewField1131;} }
            public TTReportField NAKLEDİLDİĞİİİLCE { get {return Body().NAKLEDİLDİĞİİİLCE;} }
            public TTReportField LABEL1112111 { get {return Body().LABEL1112111;} }
            public TTReportField NewField11311 { get {return Body().NewField11311;} }
            public TTReportField NAKLEDİLDİĞİKÖY { get {return Body().NAKLEDİLDİĞİKÖY;} }
            public TTReportField LABEL11112111 { get {return Body().LABEL11112111;} }
            public TTReportField NewField111311 { get {return Body().NewField111311;} }
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
                public FurneralDeliveryRecord MyParentReport
                {
                    get { return (FurneralDeliveryRecord)ParentReport; }
                }
                
                public TTReportField BAŞLIK;
                public TTReportField YAZI;
                public TTReportField PATIENTNAME;
                public TTReportField PATIENTSURNAME;
                public TTReportField VEFATTARIHI;
                public TTReportField YAKINI;
                public TTReportField LABEL1;
                public TTReportField TESLIMEDENADSOYAD;
                public TTReportField LABEL2;
                public TTReportField TESLIMALANADSOYAD;
                public TTReportField LABEL3;
                public TTReportField LABEL4;
                public TTReportField LABEL5;
                public TTReportField TESLİMALANADRES;
                public TTReportField TESLİMALANTCKIMLIKNO;
                public TTReportField TESLİMALANTELNO;
                public TTReportField LABEL6;
                public TTReportField ONAYMAKAMI;
                public TTReportField XXXXXXBASLIK;
                public TTReportField KLINIK;
                public TTReportField TESLİMALANBILGILER;
                public TTReportField LABEL11;
                public TTReportField DOGUMYERITARIHI;
                public TTReportField LABEL12;
                public TTReportField LABEL121;
                public TTReportField LABEL122;
                public TTReportField GELISTARIHI;
                public TTReportField LABEL1121;
                public TTReportField MEZARLIGAGIDISTARIHI;
                public TTReportField LABEL1221;
                public TTReportField MEZARLIKADAPARSELNO;
                public TTReportField LABEL11211;
                public TTReportField PROTOKOLNO;
                public TTReportField LABEL1122;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField OLUMNEDENI;
                public TTReportField LABEL15;
                public TTReportField TESLİMEDENTCKIMLIKNO;
                public TTReportField NAKLEDİLDİĞİİİL;
                public TTReportField LABEL111211;
                public TTReportField NewField1131;
                public TTReportField NAKLEDİLDİĞİİİLCE;
                public TTReportField LABEL1112111;
                public TTReportField NewField11311;
                public TTReportField NAKLEDİLDİĞİKÖY;
                public TTReportField LABEL11112111;
                public TTReportField NewField111311; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 250;
                    RepeatCount = 0;
                    
                    BAŞLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 35, 134, 40, false);
                    BAŞLIK.Name = "BAŞLIK";
                    BAŞLIK.TextFont.Size = 11;
                    BAŞLIK.TextFont.Bold = true;
                    BAŞLIK.TextFont.CharSet = 162;
                    BAŞLIK.Value = @"CENAZE TESLİM TUTANAĞI";

                    YAZI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 53, 210, 83, false);
                    YAZI.Name = "YAZI";
                    YAZI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YAZI.MultiLine = EvetHayirEnum.ehEvet;
                    YAZI.NoClip = EvetHayirEnum.ehEvet;
                    YAZI.WordBreak = EvetHayirEnum.ehEvet;
                    YAZI.ExpandTabs = EvetHayirEnum.ehEvet;
                    YAZI.TextFont.Name = "Arial";
                    YAZI.TextFont.Size = 9;
                    YAZI.TextFont.CharSet = 162;
                    YAZI.Value = @"{%XXXXXXBASLIK%} {%KLINIK%} 'nde {%VEFATTARIHI%} tarihinde  vefat eden {%PATIENTNAME%} {%PATIENTSURNAME%}  cenazesi, yakını {%YAKINI%} teslim edilmiştir. İş bu tutanak birlikte imza altına alınmıştır. ";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 43, 257, 48, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.Visible = EvetHayirEnum.ehHayir;
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.ObjectDefName = "Morgue";
                    PATIENTNAME.DataMember = "EPISODE.PATIENT.NAME";
                    PATIENTNAME.TextFont.Name = "Arial";
                    PATIENTNAME.TextFont.Size = 9;
                    PATIENTNAME.TextFont.CharSet = 162;
                    PATIENTNAME.Value = @"{@TTOBJECTID@}";

                    PATIENTSURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 48, 257, 53, false);
                    PATIENTSURNAME.Name = "PATIENTSURNAME";
                    PATIENTSURNAME.Visible = EvetHayirEnum.ehHayir;
                    PATIENTSURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTSURNAME.ObjectDefName = "Morgue";
                    PATIENTSURNAME.DataMember = "EPISODE.PATIENT.SURNAME";
                    PATIENTSURNAME.TextFont.Name = "Arial";
                    PATIENTSURNAME.TextFont.Size = 9;
                    PATIENTSURNAME.TextFont.CharSet = 162;
                    PATIENTSURNAME.Value = @"{@TTOBJECTID@}";

                    VEFATTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 53, 257, 58, false);
                    VEFATTARIHI.Name = "VEFATTARIHI";
                    VEFATTARIHI.Visible = EvetHayirEnum.ehHayir;
                    VEFATTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    VEFATTARIHI.ObjectDefName = "Morgue";
                    VEFATTARIHI.DataMember = "DATETIMEOFDEATH";
                    VEFATTARIHI.TextFont.Name = "Arial";
                    VEFATTARIHI.TextFont.Size = 9;
                    VEFATTARIHI.TextFont.CharSet = 162;
                    VEFATTARIHI.Value = @"{@TTOBJECTID@}";

                    YAKINI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 58, 257, 63, false);
                    YAKINI.Name = "YAKINI";
                    YAKINI.Visible = EvetHayirEnum.ehHayir;
                    YAKINI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YAKINI.TextFormat = @"Short Date";
                    YAKINI.ObjectDefName = "Morgue";
                    YAKINI.DataMember = "DEATHBODYADMITTEDTO";
                    YAKINI.TextFont.Name = "Arial";
                    YAKINI.TextFont.Size = 9;
                    YAKINI.TextFont.CharSet = 162;
                    YAKINI.Value = @"{@TTOBJECTID@}";

                    LABEL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 157, 64, 162, false);
                    LABEL1.Name = "LABEL1";
                    LABEL1.TextFont.Name = "Arial";
                    LABEL1.TextFont.Size = 9;
                    LABEL1.TextFont.Bold = true;
                    LABEL1.TextFont.Underline = true;
                    LABEL1.TextFont.CharSet = 162;
                    LABEL1.Value = @"CENAZEYİ TESLİM EDEN";

                    TESLIMEDENADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 167, 72, 172, false);
                    TESLIMEDENADSOYAD.Name = "TESLIMEDENADSOYAD";
                    TESLIMEDENADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESLIMEDENADSOYAD.ObjectDefName = "MORGUE";
                    TESLIMEDENADSOYAD.DataMember = "DELIVEREDBY.NAME";
                    TESLIMEDENADSOYAD.TextFont.Name = "Arial";
                    TESLIMEDENADSOYAD.TextFont.Size = 9;
                    TESLIMEDENADSOYAD.TextFont.CharSet = 162;
                    TESLIMEDENADSOYAD.Value = @"{@TTOBJECTID@}";

                    LABEL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 162, 42, 167, false);
                    LABEL2.Name = "LABEL2";
                    LABEL2.TextFont.Name = "Arial";
                    LABEL2.TextFont.Size = 9;
                    LABEL2.TextFont.Bold = true;
                    LABEL2.TextFont.CharSet = 162;
                    LABEL2.Value = @"ADI SOYADI";

                    TESLIMALANADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 167, 193, 172, false);
                    TESLIMALANADSOYAD.Name = "TESLIMALANADSOYAD";
                    TESLIMALANADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESLIMALANADSOYAD.ObjectDefName = "MORGUE";
                    TESLIMALANADSOYAD.DataMember = "DEATHBODYADMITTEDTO";
                    TESLIMALANADSOYAD.TextFont.Name = "Arial";
                    TESLIMALANADSOYAD.TextFont.Size = 9;
                    TESLIMALANADSOYAD.TextFont.CharSet = 162;
                    TESLIMALANADSOYAD.Value = @"{@TTOBJECTID@}";

                    LABEL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 157, 185, 162, false);
                    LABEL3.Name = "LABEL3";
                    LABEL3.TextFont.Name = "Arial";
                    LABEL3.TextFont.Size = 9;
                    LABEL3.TextFont.Bold = true;
                    LABEL3.TextFont.Underline = true;
                    LABEL3.TextFont.CharSet = 162;
                    LABEL3.Value = @"CENAZEYİ TESLİM ALAN";

                    LABEL4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 162, 163, 167, false);
                    LABEL4.Name = "LABEL4";
                    LABEL4.TextFont.Name = "Arial";
                    LABEL4.TextFont.Size = 9;
                    LABEL4.TextFont.Bold = true;
                    LABEL4.TextFont.CharSet = 162;
                    LABEL4.Value = @"ADI SOYADI";

                    LABEL5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 173, 196, 178, false);
                    LABEL5.Name = "LABEL5";
                    LABEL5.TextFont.Name = "Arial";
                    LABEL5.TextFont.Size = 9;
                    LABEL5.TextFont.Bold = true;
                    LABEL5.TextFont.CharSet = 162;
                    LABEL5.Value = @"ADRES-TELEFON-T.C KİMLİK NO";

                    TESLİMALANADRES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 117, 250, 125, false);
                    TESLİMALANADRES.Name = "TESLİMALANADRES";
                    TESLİMALANADRES.Visible = EvetHayirEnum.ehHayir;
                    TESLİMALANADRES.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESLİMALANADRES.MultiLine = EvetHayirEnum.ehEvet;
                    TESLİMALANADRES.NoClip = EvetHayirEnum.ehEvet;
                    TESLİMALANADRES.WordBreak = EvetHayirEnum.ehEvet;
                    TESLİMALANADRES.ExpandTabs = EvetHayirEnum.ehEvet;
                    TESLİMALANADRES.ObjectDefName = "mORGUE";
                    TESLİMALANADRES.DataMember = "ADDRESOFADMITTED";
                    TESLİMALANADRES.TextFont.Name = "Arial";
                    TESLİMALANADRES.TextFont.Size = 8;
                    TESLİMALANADRES.TextFont.CharSet = 162;
                    TESLİMALANADRES.Value = @"{@TTOBJECTID@}";

                    TESLİMALANTCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 131, 250, 137, false);
                    TESLİMALANTCKIMLIKNO.Name = "TESLİMALANTCKIMLIKNO";
                    TESLİMALANTCKIMLIKNO.Visible = EvetHayirEnum.ehHayir;
                    TESLİMALANTCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESLİMALANTCKIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    TESLİMALANTCKIMLIKNO.NoClip = EvetHayirEnum.ehEvet;
                    TESLİMALANTCKIMLIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    TESLİMALANTCKIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TESLİMALANTCKIMLIKNO.ObjectDefName = "mORGUE";
                    TESLİMALANTCKIMLIKNO.DataMember = "CITIZENSHIPNOOFADMITTED";
                    TESLİMALANTCKIMLIKNO.TextFont.Name = "Arial";
                    TESLİMALANTCKIMLIKNO.TextFont.Size = 8;
                    TESLİMALANTCKIMLIKNO.TextFont.CharSet = 162;
                    TESLİMALANTCKIMLIKNO.Value = @"{@TTOBJECTID@}";

                    TESLİMALANTELNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 125, 250, 131, false);
                    TESLİMALANTELNO.Name = "TESLİMALANTELNO";
                    TESLİMALANTELNO.Visible = EvetHayirEnum.ehHayir;
                    TESLİMALANTELNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESLİMALANTELNO.MultiLine = EvetHayirEnum.ehEvet;
                    TESLİMALANTELNO.NoClip = EvetHayirEnum.ehEvet;
                    TESLİMALANTELNO.WordBreak = EvetHayirEnum.ehEvet;
                    TESLİMALANTELNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TESLİMALANTELNO.ObjectDefName = "mORGUE";
                    TESLİMALANTELNO.DataMember = "PHONENUMBEROFADMITTED";
                    TESLİMALANTELNO.TextFont.Name = "Arial";
                    TESLİMALANTELNO.TextFont.Size = 8;
                    TESLİMALANTELNO.TextFont.CharSet = 162;
                    TESLİMALANTELNO.Value = @"{@TTOBJECTID@}";

                    LABEL6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 222, 114, 227, false);
                    LABEL6.Name = "LABEL6";
                    LABEL6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LABEL6.TextFont.Name = "Arial";
                    LABEL6.TextFont.Size = 9;
                    LABEL6.TextFont.Bold = true;
                    LABEL6.TextFont.CharSet = 162;
                    LABEL6.Value = @"ONAY";

                    ONAYMAKAMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 229, 123, 234, false);
                    ONAYMAKAMI.Name = "ONAYMAKAMI";
                    ONAYMAKAMI.FieldType = ReportFieldTypeEnum.ftExpression;
                    ONAYMAKAMI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONAYMAKAMI.MultiLine = EvetHayirEnum.ehEvet;
                    ONAYMAKAMI.NoClip = EvetHayirEnum.ehEvet;
                    ONAYMAKAMI.WordBreak = EvetHayirEnum.ehEvet;
                    ONAYMAKAMI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ONAYMAKAMI.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""MEDICALRECORDINVESTIGATIONOFFICEMANAGER"", """") ";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 68, 257, 73, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Size = 9;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") ";

                    KLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 63, 257, 68, false);
                    KLINIK.Name = "KLINIK";
                    KLINIK.Visible = EvetHayirEnum.ehHayir;
                    KLINIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLINIK.ObjectDefName = "Morgue";
                    KLINIK.DataMember = "DIEDCLINIC.NAME";
                    KLINIK.TextFont.Name = "Arial";
                    KLINIK.TextFont.Size = 9;
                    KLINIK.TextFont.CharSet = 162;
                    KLINIK.Value = @"{@TTOBJECTID@}";

                    TESLİMALANBILGILER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 178, 215, 203, false);
                    TESLİMALANBILGILER.Name = "TESLİMALANBILGILER";
                    TESLİMALANBILGILER.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESLİMALANBILGILER.MultiLine = EvetHayirEnum.ehEvet;
                    TESLİMALANBILGILER.NoClip = EvetHayirEnum.ehEvet;
                    TESLİMALANBILGILER.WordBreak = EvetHayirEnum.ehEvet;
                    TESLİMALANBILGILER.ExpandTabs = EvetHayirEnum.ehEvet;
                    TESLİMALANBILGILER.TextFont.Name = "Arial";
                    TESLİMALANBILGILER.TextFont.Size = 8;
                    TESLİMALANBILGILER.TextFont.CharSet = 162;
                    TESLİMALANBILGILER.Value = @"Adres: {%TESLİMALANADRES%} 
Tel: {%TESLİMALANTELNO%}
T.C Kimlik No: {%TESLİMALANTCKIMLIKNO%}";

                    LABEL11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 90, 52, 95, false);
                    LABEL11.Name = "LABEL11";
                    LABEL11.TextFont.Name = "Arial";
                    LABEL11.TextFont.Size = 9;
                    LABEL11.TextFont.Bold = true;
                    LABEL11.TextFont.Underline = true;
                    LABEL11.TextFont.CharSet = 162;
                    LABEL11.Value = @"VEFAT EDENİN:";

                    DOGUMYERITARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 96, 128, 101, false);
                    DOGUMYERITARIHI.Name = "DOGUMYERITARIHI";
                    DOGUMYERITARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMYERITARIHI.TextFormat = @"Short Date";
                    DOGUMYERITARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOGUMYERITARIHI.ObjectDefName = "MORGUE";
                    DOGUMYERITARIHI.DataMember = "EPISODE.PATIENT.BIRTHDATE";
                    DOGUMYERITARIHI.TextFont.Name = "Arial";
                    DOGUMYERITARIHI.TextFont.Size = 9;
                    DOGUMYERITARIHI.TextFont.CharSet = 162;
                    DOGUMYERITARIHI.Value = @"{@TTOBJECTID@}";

                    LABEL12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 96, 61, 101, false);
                    LABEL12.Name = "LABEL12";
                    LABEL12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL12.TextFont.Name = "Arial";
                    LABEL12.TextFont.Size = 9;
                    LABEL12.TextFont.Bold = true;
                    LABEL12.TextFont.CharSet = 162;
                    LABEL12.Value = @"DOĞUM YERİ/TARİHİ";

                    LABEL121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 101, 61, 106, false);
                    LABEL121.Name = "LABEL121";
                    LABEL121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL121.TextFont.Name = "Arial";
                    LABEL121.TextFont.Size = 9;
                    LABEL121.TextFont.Bold = true;
                    LABEL121.TextFont.CharSet = 162;
                    LABEL121.Value = @"CİNSİYETİ";

                    LABEL122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 106, 61, 111, false);
                    LABEL122.Name = "LABEL122";
                    LABEL122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL122.TextFont.Name = "Arial";
                    LABEL122.TextFont.Size = 9;
                    LABEL122.TextFont.Bold = true;
                    LABEL122.TextFont.CharSet = 162;
                    LABEL122.Value = @"ÖLÜM NEDENİ";

                    GELISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 111, 128, 116, false);
                    GELISTARIHI.Name = "GELISTARIHI";
                    GELISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    GELISTARIHI.TextFormat = @"dd/MM/yyyy";
                    GELISTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GELISTARIHI.ObjectDefName = "MORGUE";
                    GELISTARIHI.DataMember = "EPISODE.OPENINGDATE";
                    GELISTARIHI.TextFont.Name = "Arial";
                    GELISTARIHI.TextFont.Size = 9;
                    GELISTARIHI.TextFont.CharSet = 162;
                    GELISTARIHI.Value = @"{@TTOBJECTID@}";

                    LABEL1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 111, 65, 116, false);
                    LABEL1121.Name = "LABEL1121";
                    LABEL1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL1121.TextFont.Name = "Arial";
                    LABEL1121.TextFont.Size = 9;
                    LABEL1121.TextFont.Bold = true;
                    LABEL1121.TextFont.CharSet = 162;
                    LABEL1121.Value = @"XXXXXXYE GELDİĞİ TARİH";

                    MEZARLIGAGIDISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 116, 128, 121, false);
                    MEZARLIGAGIDISTARIHI.Name = "MEZARLIGAGIDISTARIHI";
                    MEZARLIGAGIDISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MEZARLIGAGIDISTARIHI.TextFormat = @"dd/MM/yyyy";
                    MEZARLIGAGIDISTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MEZARLIGAGIDISTARIHI.ExpandTabs = EvetHayirEnum.ehEvet;
                    MEZARLIGAGIDISTARIHI.ObjectDefName = "MORGUE";
                    MEZARLIGAGIDISTARIHI.DataMember = "DATEOFSENTTOGRAVE";
                    MEZARLIGAGIDISTARIHI.TextFont.Name = "Arial";
                    MEZARLIGAGIDISTARIHI.TextFont.Size = 9;
                    MEZARLIGAGIDISTARIHI.TextFont.CharSet = 162;
                    MEZARLIGAGIDISTARIHI.Value = @"{@TTOBJECTID@}";

                    LABEL1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 116, 65, 121, false);
                    LABEL1221.Name = "LABEL1221";
                    LABEL1221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL1221.TextFont.Name = "Arial";
                    LABEL1221.TextFont.Size = 9;
                    LABEL1221.TextFont.Bold = true;
                    LABEL1221.TextFont.CharSet = 162;
                    LABEL1221.Value = @"MEZARLIĞA GİDİŞ TARİHİ";

                    MEZARLIKADAPARSELNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 121, 128, 126, false);
                    MEZARLIKADAPARSELNO.Name = "MEZARLIKADAPARSELNO";
                    MEZARLIKADAPARSELNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    MEZARLIKADAPARSELNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MEZARLIKADAPARSELNO.ObjectDefName = "MORGUE";
                    MEZARLIKADAPARSELNO.DataMember = "GRAVEYARDPLOTNO";
                    MEZARLIKADAPARSELNO.TextFont.Name = "Arial";
                    MEZARLIKADAPARSELNO.TextFont.Size = 9;
                    MEZARLIKADAPARSELNO.TextFont.CharSet = 162;
                    MEZARLIKADAPARSELNO.Value = @"{@TTOBJECTID@}";

                    LABEL11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 121, 65, 126, false);
                    LABEL11211.Name = "LABEL11211";
                    LABEL11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL11211.TextFont.Name = "Arial";
                    LABEL11211.TextFont.Size = 9;
                    LABEL11211.TextFont.Bold = true;
                    LABEL11211.TextFont.CharSet = 162;
                    LABEL11211.Value = @"MEZARLIK ADA PARSEL NO";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 141, 128, 146, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROTOKOLNO.ObjectDefName = "MORGUE";
                    PROTOKOLNO.DataMember = "PROTOCOLNO";
                    PROTOKOLNO.TextFont.Name = "Arial";
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"{@TTOBJECTID@}";

                    LABEL1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 141, 69, 146, false);
                    LABEL1122.Name = "LABEL1122";
                    LABEL1122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL1122.TextFont.Name = "Arial";
                    LABEL1122.TextFont.Size = 9;
                    LABEL1122.TextFont.Bold = true;
                    LABEL1122.TextFont.CharSet = 162;
                    LABEL1122.Value = @"PROTOKOL NO";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 96, 73, 101, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Size = 12;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @":";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 101, 73, 106, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Size = 12;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @":";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 106, 73, 111, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Size = 12;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @":";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 111, 73, 116, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Size = 12;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @":";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 116, 73, 121, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Size = 12;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @":";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 121, 73, 126, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Size = 12;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @":";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 141, 73, 146, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Size = 12;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @":";

                    OLUMNEDENI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 106, 128, 111, false);
                    OLUMNEDENI.Name = "OLUMNEDENI";
                    OLUMNEDENI.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLUMNEDENI.ObjectDefName = "Morgue";
                    OLUMNEDENI.DataMember = "MERNISDEATHREASONS.REASONNAME";
                    OLUMNEDENI.Value = @"{@TTOBJECTID@}";

                    LABEL15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 172, 75, 177, false);
                    LABEL15.Name = "LABEL15";
                    LABEL15.TextFont.Name = "Arial";
                    LABEL15.TextFont.Size = 9;
                    LABEL15.TextFont.Bold = true;
                    LABEL15.TextFont.CharSet = 162;
                    LABEL15.Value = @"T.C KİMLİK NO";

                    TESLİMEDENTCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 177, 75, 181, false);
                    TESLİMEDENTCKIMLIKNO.Name = "TESLİMEDENTCKIMLIKNO";
                    TESLİMEDENTCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESLİMEDENTCKIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    TESLİMEDENTCKIMLIKNO.NoClip = EvetHayirEnum.ehEvet;
                    TESLİMEDENTCKIMLIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    TESLİMEDENTCKIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TESLİMEDENTCKIMLIKNO.ObjectDefName = "mORGUE";
                    TESLİMEDENTCKIMLIKNO.DataMember = "DELIVEREDBY.PERSON.UNIQUEREFNO";
                    TESLİMEDENTCKIMLIKNO.TextFont.Name = "Arial";
                    TESLİMEDENTCKIMLIKNO.TextFont.Size = 9;
                    TESLİMEDENTCKIMLIKNO.TextFont.CharSet = 162;
                    TESLİMEDENTCKIMLIKNO.Value = @"{@TTOBJECTID@}";

                    NAKLEDİLDİĞİİİL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 126, 128, 131, false);
                    NAKLEDİLDİĞİİİL.Name = "NAKLEDİLDİĞİİİL";
                    NAKLEDİLDİĞİİİL.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAKLEDİLDİĞİİİL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAKLEDİLDİĞİİİL.ObjectDefName = "MORGUE";
                    NAKLEDİLDİĞİİİL.DataMember = "SKRSTOMBCITY.ADI";
                    NAKLEDİLDİĞİİİL.TextFont.Name = "Arial";
                    NAKLEDİLDİĞİİİL.TextFont.Size = 9;
                    NAKLEDİLDİĞİİİL.TextFont.CharSet = 162;
                    NAKLEDİLDİĞİİİL.Value = @"{@TTOBJECTID@}";

                    LABEL111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 126, 65, 131, false);
                    LABEL111211.Name = "LABEL111211";
                    LABEL111211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL111211.TextFont.Name = "Arial";
                    LABEL111211.TextFont.Size = 9;
                    LABEL111211.TextFont.Bold = true;
                    LABEL111211.TextFont.CharSet = 162;
                    LABEL111211.Value = @"CENAZENİN NAKİL EDİLİDİĞİ İL";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 126, 73, 131, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Size = 12;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @":";

                    NAKLEDİLDİĞİİİLCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 131, 128, 136, false);
                    NAKLEDİLDİĞİİİLCE.Name = "NAKLEDİLDİĞİİİLCE";
                    NAKLEDİLDİĞİİİLCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAKLEDİLDİĞİİİLCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAKLEDİLDİĞİİİLCE.ObjectDefName = "MORGUE";
                    NAKLEDİLDİĞİİİLCE.DataMember = "SKRSTOMBTOWN.ADI";
                    NAKLEDİLDİĞİİİLCE.TextFont.Name = "Arial";
                    NAKLEDİLDİĞİİİLCE.TextFont.Size = 9;
                    NAKLEDİLDİĞİİİLCE.TextFont.CharSet = 162;
                    NAKLEDİLDİĞİİİLCE.Value = @"{@TTOBJECTID@}";

                    LABEL1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 131, 69, 136, false);
                    LABEL1112111.Name = "LABEL1112111";
                    LABEL1112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL1112111.TextFont.Name = "Arial";
                    LABEL1112111.TextFont.Size = 9;
                    LABEL1112111.TextFont.Bold = true;
                    LABEL1112111.TextFont.CharSet = 162;
                    LABEL1112111.Value = @"CENAZENİN NAKİL EDİLİDİĞİ İLÇE";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 131, 73, 136, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.TextFont.Size = 12;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @":";

                    NAKLEDİLDİĞİKÖY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 136, 128, 141, false);
                    NAKLEDİLDİĞİKÖY.Name = "NAKLEDİLDİĞİKÖY";
                    NAKLEDİLDİĞİKÖY.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAKLEDİLDİĞİKÖY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAKLEDİLDİĞİKÖY.ObjectDefName = "MORGUE";
                    NAKLEDİLDİĞİKÖY.DataMember = "TOMBVILLAGE";
                    NAKLEDİLDİĞİKÖY.TextFont.Name = "Arial";
                    NAKLEDİLDİĞİKÖY.TextFont.Size = 9;
                    NAKLEDİLDİĞİKÖY.TextFont.CharSet = 162;
                    NAKLEDİLDİĞİKÖY.Value = @"{@TTOBJECTID@}";

                    LABEL11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 136, 69, 141, false);
                    LABEL11112111.Name = "LABEL11112111";
                    LABEL11112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL11112111.TextFont.Name = "Arial";
                    LABEL11112111.TextFont.Size = 9;
                    LABEL11112111.TextFont.Bold = true;
                    LABEL11112111.TextFont.CharSet = 162;
                    LABEL11112111.Value = @"CENAZENİN NAKİL EDİLİDİĞİ KÖY";

                    NewField111311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 136, 73, 141, false);
                    NewField111311.Name = "NewField111311";
                    NewField111311.TextFont.Size = 12;
                    NewField111311.TextFont.Bold = true;
                    NewField111311.TextFont.CharSet = 162;
                    NewField111311.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BAŞLIK.CalcValue = BAŞLIK.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") ;
                    KLINIK.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    KLINIK.PostFieldValueCalculation();
                    VEFATTARIHI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    VEFATTARIHI.PostFieldValueCalculation();
                    PATIENTNAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PATIENTNAME.PostFieldValueCalculation();
                    PATIENTSURNAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PATIENTSURNAME.PostFieldValueCalculation();
                    YAKINI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    YAKINI.PostFieldValueCalculation();
                    YAZI.CalcValue = MyParentReport.MAIN.XXXXXXBASLIK.CalcValue + @" " + MyParentReport.MAIN.KLINIK.CalcValue + @" 'nde " + MyParentReport.MAIN.VEFATTARIHI.CalcValue + @" tarihinde  vefat eden " + MyParentReport.MAIN.PATIENTNAME.CalcValue + @" " + MyParentReport.MAIN.PATIENTSURNAME.CalcValue + @"  cenazesi, yakını " + MyParentReport.MAIN.YAKINI.FormattedValue + @" teslim edilmiştir. İş bu tutanak birlikte imza altına alınmıştır. ";
                    LABEL1.CalcValue = LABEL1.Value;
                    TESLIMEDENADSOYAD.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TESLIMEDENADSOYAD.PostFieldValueCalculation();
                    LABEL2.CalcValue = LABEL2.Value;
                    TESLIMALANADSOYAD.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TESLIMALANADSOYAD.PostFieldValueCalculation();
                    LABEL3.CalcValue = LABEL3.Value;
                    LABEL4.CalcValue = LABEL4.Value;
                    LABEL5.CalcValue = LABEL5.Value;
                    TESLİMALANADRES.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TESLİMALANADRES.PostFieldValueCalculation();
                    TESLİMALANTCKIMLIKNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TESLİMALANTCKIMLIKNO.PostFieldValueCalculation();
                    TESLİMALANTELNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TESLİMALANTELNO.PostFieldValueCalculation();
                    LABEL6.CalcValue = LABEL6.Value;
                    TESLİMALANBILGILER.CalcValue = @"Adres: " + MyParentReport.MAIN.TESLİMALANADRES.CalcValue + @" 
Tel: " + MyParentReport.MAIN.TESLİMALANTELNO.CalcValue + @"
T.C Kimlik No: " + MyParentReport.MAIN.TESLİMALANTCKIMLIKNO.CalcValue;
                    LABEL11.CalcValue = LABEL11.Value;
                    DOGUMYERITARIHI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    DOGUMYERITARIHI.PostFieldValueCalculation();
                    LABEL12.CalcValue = LABEL12.Value;
                    LABEL121.CalcValue = LABEL121.Value;
                    LABEL122.CalcValue = LABEL122.Value;
                    GELISTARIHI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    GELISTARIHI.PostFieldValueCalculation();
                    LABEL1121.CalcValue = LABEL1121.Value;
                    MEZARLIGAGIDISTARIHI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    MEZARLIGAGIDISTARIHI.PostFieldValueCalculation();
                    LABEL1221.CalcValue = LABEL1221.Value;
                    MEZARLIKADAPARSELNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    MEZARLIKADAPARSELNO.PostFieldValueCalculation();
                    LABEL11211.CalcValue = LABEL11211.Value;
                    PROTOKOLNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PROTOKOLNO.PostFieldValueCalculation();
                    LABEL1122.CalcValue = LABEL1122.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    OLUMNEDENI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    OLUMNEDENI.PostFieldValueCalculation();
                    LABEL15.CalcValue = LABEL15.Value;
                    TESLİMEDENTCKIMLIKNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TESLİMEDENTCKIMLIKNO.PostFieldValueCalculation();
                    NAKLEDİLDİĞİİİL.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NAKLEDİLDİĞİİİL.PostFieldValueCalculation();
                    LABEL111211.CalcValue = LABEL111211.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NAKLEDİLDİĞİİİLCE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NAKLEDİLDİĞİİİLCE.PostFieldValueCalculation();
                    LABEL1112111.CalcValue = LABEL1112111.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    NAKLEDİLDİĞİKÖY.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NAKLEDİLDİĞİKÖY.PostFieldValueCalculation();
                    LABEL11112111.CalcValue = LABEL11112111.Value;
                    NewField111311.CalcValue = NewField111311.Value;
                    ONAYMAKAMI.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("MEDICALRECORDINVESTIGATIONOFFICEMANAGER", "") ;
                    return new TTReportObject[] { BAŞLIK,XXXXXXBASLIK,KLINIK,VEFATTARIHI,PATIENTNAME,PATIENTSURNAME,YAKINI,YAZI,LABEL1,TESLIMEDENADSOYAD,LABEL2,TESLIMALANADSOYAD,LABEL3,LABEL4,LABEL5,TESLİMALANADRES,TESLİMALANTCKIMLIKNO,TESLİMALANTELNO,LABEL6,TESLİMALANBILGILER,LABEL11,DOGUMYERITARIHI,LABEL12,LABEL121,LABEL122,GELISTARIHI,LABEL1121,MEZARLIGAGIDISTARIHI,LABEL1221,MEZARLIKADAPARSELNO,LABEL11211,PROTOKOLNO,LABEL1122,NewField11,NewField12,NewField13,NewField14,NewField121,NewField131,NewField141,OLUMNEDENI,LABEL15,TESLİMEDENTCKIMLIKNO,NAKLEDİLDİĞİİİL,LABEL111211,NewField1131,NAKLEDİLDİĞİİİLCE,LABEL1112111,NewField11311,NAKLEDİLDİĞİKÖY,LABEL11112111,NewField111311,ONAYMAKAMI};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((FurneralDeliveryRecord)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Morgue morgue = (Morgue)objectContext.GetObject(new Guid(objectID),"Morgue");
           // this.CINSIYET.Value = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(morgue.Episode.Patient.Sex).DisplayText;
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

        public FurneralDeliveryRecord()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Morg", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "FURNERALDELIVERYRECORD";
            Caption = "Cenaze Teslim Tutanağı";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 1;
            p_PageWidth = 216;
            p_PageHeight = 279;
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