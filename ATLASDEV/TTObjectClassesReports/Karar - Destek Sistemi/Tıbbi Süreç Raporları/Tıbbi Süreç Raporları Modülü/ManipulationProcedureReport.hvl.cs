
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
    /// Tıbbi/Cerrahi Uygulamalar Sonuç Raporu
    /// </summary>
    public partial class ManipulationProcedureReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public ManipulationProcedureReport MyParentReport
            {
                get { return (ManipulationProcedureReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField BASLIK { get {return Header().BASLIK;} }
            public TTReportField PATIENTNAME { get {return Header().PATIENTNAME;} }
            public TTReportField PATIENTSURNAME { get {return Header().PATIENTSURNAME;} }
            public TTReportField LABEL111 { get {return Header().LABEL111;} }
            public TTReportField LABEL121 { get {return Header().LABEL121;} }
            public TTReportField HASTANO { get {return Header().HASTANO;} }
            public TTReportField LABEL1121 { get {return Header().LABEL1121;} }
            public TTReportField LABEL1221 { get {return Header().LABEL1221;} }
            public TTReportField BABAADI { get {return Header().BABAADI;} }
            public TTReportField LABEL11221 { get {return Header().LABEL11221;} }
            public TTReportField PROTOKOLNO { get {return Header().PROTOKOLNO;} }
            public TTReportField LABEL12211 { get {return Header().LABEL12211;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField ADISOYADI { get {return Header().ADISOYADI;} }
            public TTReportField AYAKTANYATAN { get {return Header().AYAKTANYATAN;} }
            public TTReportField LABEL1321 { get {return Header().LABEL1321;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField TARIH { get {return Header().TARIH;} }
            public TTReportField LABEL1421 { get {return Header().LABEL1421;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField LABEL111211 { get {return Header().LABEL111211;} }
            public TTReportField LABEL1112111 { get {return Header().LABEL1112111;} }
            public TTReportField DOGUMTARIHI { get {return Header().DOGUMTARIHI;} }
            public TTReportField LABEL1112112 { get {return Header().LABEL1112112;} }
            public TTReportField AYAKTANYATAN1 { get {return Header().AYAKTANYATAN1;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField LOGO11 { get {return Header().LOGO11;} }
            public TTReportField LABEL11112111 { get {return Header().LABEL11112111;} }
            public TTReportField BIRTHPLACEDATE { get {return Header().BIRTHPLACEDATE;} }
            public TTReportField DOGUMYERI { get {return Header().DOGUMYERI;} }
            public TTReportField DRSINIF { get {return Footer().DRSINIF;} }
            public TTReportField DRRUTBE { get {return Footer().DRRUTBE;} }
            public TTReportField ISTEKDR { get {return Footer().ISTEKDR;} }
            public TTReportField ISTEKPSIKOLOG { get {return Footer().ISTEKPSIKOLOG;} }
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
                public ManipulationProcedureReport MyParentReport
                {
                    get { return (ManipulationProcedureReport)ParentReport; }
                }
                
                public TTReportField BASLIK;
                public TTReportField PATIENTNAME;
                public TTReportField PATIENTSURNAME;
                public TTReportField LABEL111;
                public TTReportField LABEL121;
                public TTReportField HASTANO;
                public TTReportField LABEL1121;
                public TTReportField LABEL1221;
                public TTReportField BABAADI;
                public TTReportField LABEL11221;
                public TTReportField PROTOKOLNO;
                public TTReportField LABEL12211;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField1121;
                public TTReportField NewField1141;
                public TTReportField ADISOYADI;
                public TTReportField AYAKTANYATAN;
                public TTReportField LABEL1321;
                public TTReportField NewField1111;
                public TTReportField TARIH;
                public TTReportField LABEL1421;
                public TTReportField NewField1211;
                public TTReportField LABEL111211;
                public TTReportField LABEL1112111;
                public TTReportField DOGUMTARIHI;
                public TTReportField LABEL1112112;
                public TTReportField AYAKTANYATAN1;
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO11;
                public TTReportField LABEL11112111;
                public TTReportField BIRTHPLACEDATE;
                public TTReportField DOGUMYERI; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 124;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 35, 169, 48, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK.TextFont.Size = 11;
                    BASLIK.TextFont.Bold = true;
                    BASLIK.TextFont.CharSet = 162;
                    BASLIK.Value = @"TIBBİ/CERRAHİ UYGULAMA SONUÇ RAPORU";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 16, 253, 21, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.Visible = EvetHayirEnum.ehHayir;
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.ObjectDefName = "Manipulation";
                    PATIENTNAME.DataMember = "EPISODE.PATIENT.NAME";
                    PATIENTNAME.TextFont.Name = "Arial";
                    PATIENTNAME.TextFont.Size = 9;
                    PATIENTNAME.TextFont.CharSet = 162;
                    PATIENTNAME.Value = @"{@TTOBJECTID@}";

                    PATIENTSURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 21, 253, 26, false);
                    PATIENTSURNAME.Name = "PATIENTSURNAME";
                    PATIENTSURNAME.Visible = EvetHayirEnum.ehHayir;
                    PATIENTSURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTSURNAME.ObjectDefName = "Manipulation";
                    PATIENTSURNAME.DataMember = "EPISODE.PATIENT.SURNAME";
                    PATIENTSURNAME.TextFont.Name = "Arial";
                    PATIENTSURNAME.TextFont.Size = 9;
                    PATIENTSURNAME.TextFont.CharSet = 162;
                    PATIENTSURNAME.Value = @"{@TTOBJECTID@}";

                    LABEL111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 62, 46, 67, false);
                    LABEL111.Name = "LABEL111";
                    LABEL111.TextFont.Size = 9;
                    LABEL111.TextFont.Bold = true;
                    LABEL111.TextFont.Underline = true;
                    LABEL111.TextFont.CharSet = 162;
                    LABEL111.Value = @"HASTANIN:";

                    LABEL121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 88, 61, 93, false);
                    LABEL121.Name = "LABEL121";
                    LABEL121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL121.TextFont.Size = 9;
                    LABEL121.TextFont.Bold = true;
                    LABEL121.TextFont.CharSet = 162;
                    LABEL121.Value = @"DOĞUM YERİ/TARİHİ";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 73, 117, 78, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTANO.ObjectDefName = "Manipulation";
                    HASTANO.DataMember = "EPISODE.PATIENT.ID";
                    HASTANO.TextFont.Size = 9;
                    HASTANO.TextFont.CharSet = 162;
                    HASTANO.Value = @"{@TTOBJECTID@}";

                    LABEL1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 73, 61, 78, false);
                    LABEL1121.Name = "LABEL1121";
                    LABEL1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL1121.TextFont.Size = 9;
                    LABEL1121.TextFont.Bold = true;
                    LABEL1121.TextFont.CharSet = 162;
                    LABEL1121.Value = @"HASTA NO";

                    LABEL1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 78, 61, 83, false);
                    LABEL1221.Name = "LABEL1221";
                    LABEL1221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL1221.TextFont.Size = 9;
                    LABEL1221.TextFont.Bold = true;
                    LABEL1221.TextFont.CharSet = 162;
                    LABEL1221.Value = @"ADI SOYADI";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 82, 117, 87, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.TextFormat = @"dd/MM/yyyy";
                    BABAADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BABAADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    BABAADI.ObjectDefName = "Manipulation";
                    BABAADI.DataMember = "EPISODE.PATIENT.FATHERNAME";
                    BABAADI.TextFont.Size = 9;
                    BABAADI.TextFont.CharSet = 162;
                    BABAADI.Value = @"{@TTOBJECTID@}";

                    LABEL11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 83, 61, 88, false);
                    LABEL11221.Name = "LABEL11221";
                    LABEL11221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL11221.TextFont.Size = 9;
                    LABEL11221.TextFont.Bold = true;
                    LABEL11221.TextFont.CharSet = 162;
                    LABEL11221.Value = @"BABA ADI";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 68, 117, 73, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"";

                    LABEL12211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 68, 61, 73, false);
                    LABEL12211.Name = "LABEL12211";
                    LABEL12211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL12211.TextFont.Size = 9;
                    LABEL12211.TextFont.Bold = true;
                    LABEL12211.TextFont.CharSet = 162;
                    LABEL12211.Value = @"PROTOKOL NO";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 87, 61, 92, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Size = 12;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @":";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 73, 61, 78, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Size = 12;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @":";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 78, 61, 83, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Size = 12;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @":";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 83, 61, 88, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Size = 12;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 68, 61, 73, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Size = 12;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @":";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 78, 170, 83, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.ObjectDefName = "Manipulation";
                    ADISOYADI.DataMember = "EPISODE.PATIENT.PatientIDandFullName";
                    ADISOYADI.TextFont.Size = 9;
                    ADISOYADI.TextFont.CharSet = 162;
                    ADISOYADI.Value = @"{@TTOBJECTID@}";

                    AYAKTANYATAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 92, 117, 97, false);
                    AYAKTANYATAN.Name = "AYAKTANYATAN";
                    AYAKTANYATAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    AYAKTANYATAN.TextFormat = @"Short Date";
                    AYAKTANYATAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AYAKTANYATAN.ObjectDefName = "PatientStatusEnum";
                    AYAKTANYATAN.DataMember = "DISPLAYTEXT";
                    AYAKTANYATAN.TextFont.Size = 9;
                    AYAKTANYATAN.TextFont.CharSet = 162;
                    AYAKTANYATAN.Value = @"{%AYAKTANYATAN1%}";

                    LABEL1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 93, 61, 98, false);
                    LABEL1321.Name = "LABEL1321";
                    LABEL1321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL1321.TextFont.Size = 9;
                    LABEL1321.TextFont.Bold = true;
                    LABEL1321.TextFont.CharSet = 162;
                    LABEL1321.Value = @"AYAKTAN/YATAN";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 93, 61, 98, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.TextFont.Size = 12;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @":";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 53, 117, 58, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"dd/MM/yyyy";
                    TARIH.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TARIH.ObjectDefName = "Manipulation";
                    TARIH.DataMember = "ACTIONDATE";
                    TARIH.TextFont.Size = 9;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"{@TTOBJECTID@}";

                    LABEL1421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 53, 55, 58, false);
                    LABEL1421.Name = "LABEL1421";
                    LABEL1421.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL1421.TextFont.Size = 9;
                    LABEL1421.TextFont.Bold = true;
                    LABEL1421.TextFont.CharSet = 162;
                    LABEL1421.Value = @"TARİH";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 53, 61, 58, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.TextFont.Size = 12;
                    NewField1211.TextFont.Bold = true;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @":";

                    LABEL111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 119, 165, 124, false);
                    LABEL111211.Name = "LABEL111211";
                    LABEL111211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL111211.TextFont.Size = 9;
                    LABEL111211.TextFont.Bold = true;
                    LABEL111211.TextFont.Underline = true;
                    LABEL111211.TextFont.CharSet = 162;
                    LABEL111211.Value = @"İSTEK YAPAN BİRİM";

                    LABEL1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 119, 116, 124, false);
                    LABEL1112111.Name = "LABEL1112111";
                    LABEL1112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL1112111.TextFont.Size = 9;
                    LABEL1112111.TextFont.Bold = true;
                    LABEL1112111.TextFont.Underline = true;
                    LABEL1112111.TextFont.CharSet = 162;
                    LABEL1112111.Value = @"UYGULANAN İŞLEM(LER)";

                    DOGUMTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 41, 253, 46, false);
                    DOGUMTARIHI.Name = "DOGUMTARIHI";
                    DOGUMTARIHI.Visible = EvetHayirEnum.ehHayir;
                    DOGUMTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMTARIHI.TextFormat = @"Short Date";
                    DOGUMTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOGUMTARIHI.ObjectDefName = "Manipulation";
                    DOGUMTARIHI.DataMember = "EPISODE.PATIENT.BIRTHDATE";
                    DOGUMTARIHI.TextFont.Name = "Arial";
                    DOGUMTARIHI.TextFont.Size = 9;
                    DOGUMTARIHI.TextFont.CharSet = 162;
                    DOGUMTARIHI.Value = @"{@TTOBJECTID@}";

                    LABEL1112112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 119, 212, 124, false);
                    LABEL1112112.Name = "LABEL1112112";
                    LABEL1112112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL1112112.TextFont.Size = 9;
                    LABEL1112112.TextFont.Bold = true;
                    LABEL1112112.TextFont.Underline = true;
                    LABEL1112112.TextFont.CharSet = 162;
                    LABEL1112112.Value = @"İSTEK YAPAN DOKTOR";

                    AYAKTANYATAN1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 46, 253, 51, false);
                    AYAKTANYATAN1.Name = "AYAKTANYATAN1";
                    AYAKTANYATAN1.Visible = EvetHayirEnum.ehHayir;
                    AYAKTANYATAN1.FieldType = ReportFieldTypeEnum.ftVariable;
                    AYAKTANYATAN1.TextFormat = @"Short Date";
                    AYAKTANYATAN1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AYAKTANYATAN1.ObjectDefName = "Manipulation";
                    AYAKTANYATAN1.DataMember = "EPISODE.PATIENTSTATUS";
                    AYAKTANYATAN1.TextFont.Name = "Arial";
                    AYAKTANYATAN1.TextFont.Size = 9;
                    AYAKTANYATAN1.TextFont.CharSet = 162;
                    AYAKTANYATAN1.Value = @"{@TTOBJECTID@}";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 11, 169, 34, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    LOGO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 11, 51, 31, false);
                    LOGO11.Name = "LOGO11";
                    LOGO11.TextFont.Name = "Courier New";
                    LOGO11.Value = @"Logo";

                    LABEL11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 119, 41, 124, false);
                    LABEL11112111.Name = "LABEL11112111";
                    LABEL11112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL11112111.TextFont.Size = 9;
                    LABEL11112111.TextFont.Bold = true;
                    LABEL11112111.TextFont.Underline = true;
                    LABEL11112111.TextFont.CharSet = 162;
                    LABEL11112111.Value = @"İŞLEM TARİHİ";

                    BIRTHPLACEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 87, 117, 92, false);
                    BIRTHPLACEDATE.Name = "BIRTHPLACEDATE";
                    BIRTHPLACEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHPLACEDATE.Value = @"{%DOGUMYERI%}/{%DOGUMTARIHI%}";

                    DOGUMYERI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 225, 69, 250, 74, false);
                    DOGUMYERI.Name = "DOGUMYERI";
                    DOGUMYERI.Visible = EvetHayirEnum.ehHayir;
                    DOGUMYERI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMYERI.ObjectDefName = "Manipulation";
                    DOGUMYERI.DataMember = "EPISODE.PATIENT.BIRTHPLACE";
                    DOGUMYERI.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BASLIK.CalcValue = @"TIBBİ/CERRAHİ UYGULAMA SONUÇ RAPORU";
                    PATIENTNAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PATIENTNAME.PostFieldValueCalculation();
                    PATIENTSURNAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PATIENTSURNAME.PostFieldValueCalculation();
                    LABEL111.CalcValue = LABEL111.Value;
                    LABEL121.CalcValue = LABEL121.Value;
                    HASTANO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    HASTANO.PostFieldValueCalculation();
                    LABEL1121.CalcValue = LABEL1121.Value;
                    LABEL1221.CalcValue = LABEL1221.Value;
                    BABAADI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    BABAADI.PostFieldValueCalculation();
                    LABEL11221.CalcValue = LABEL11221.Value;
                    PROTOKOLNO.CalcValue = PROTOKOLNO.Value;
                    LABEL12211.CalcValue = LABEL12211.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    ADISOYADI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    ADISOYADI.PostFieldValueCalculation();
                    AYAKTANYATAN1.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    AYAKTANYATAN1.PostFieldValueCalculation();
                    AYAKTANYATAN.CalcValue = MyParentReport.HEADER.AYAKTANYATAN1.FormattedValue;
                    AYAKTANYATAN.PostFieldValueCalculation();
                    LABEL1321.CalcValue = LABEL1321.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    TARIH.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TARIH.PostFieldValueCalculation();
                    LABEL1421.CalcValue = LABEL1421.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    LABEL111211.CalcValue = LABEL111211.Value;
                    LABEL1112111.CalcValue = LABEL1112111.Value;
                    DOGUMTARIHI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    DOGUMTARIHI.PostFieldValueCalculation();
                    LABEL1112112.CalcValue = LABEL1112112.Value;
                    LOGO11.CalcValue = LOGO11.Value;
                    LABEL11112111.CalcValue = LABEL11112111.Value;
                    DOGUMYERI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    DOGUMYERI.PostFieldValueCalculation();
                    BIRTHPLACEDATE.CalcValue = MyParentReport.HEADER.DOGUMYERI.CalcValue + @"/" + MyParentReport.HEADER.DOGUMTARIHI.FormattedValue;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { BASLIK,PATIENTNAME,PATIENTSURNAME,LABEL111,LABEL121,HASTANO,LABEL1121,LABEL1221,BABAADI,LABEL11221,PROTOKOLNO,LABEL12211,NewField111,NewField121,NewField131,NewField1121,NewField1141,ADISOYADI,AYAKTANYATAN1,AYAKTANYATAN,LABEL1321,NewField1111,TARIH,LABEL1421,NewField1211,LABEL111211,LABEL1112111,DOGUMTARIHI,LABEL1112112,LOGO11,LABEL11112111,DOGUMYERI,BIRTHPLACEDATE,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
             string objectID = ((ManipulationProcedureReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
             TTObjectClasses.Manipulation manipulation = (TTObjectClasses.Manipulation)objectContext.GetObject(new Guid(objectID), "Manipulation");
             if(manipulation.SubEpisode != null)
                this.PROTOKOLNO.CalcValue = manipulation.SubEpisode.ProtocolNo;
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public ManipulationProcedureReport MyParentReport
                {
                    get { return (ManipulationProcedureReport)ParentReport; }
                }
                
                public TTReportField DRSINIF;
                public TTReportField DRRUTBE;
                public TTReportField ISTEKDR;
                public TTReportField ISTEKPSIKOLOG; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 33;
                    RepeatCount = 0;
                    
                    DRSINIF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 36, 262, 41, false);
                    DRSINIF.Name = "DRSINIF";
                    DRSINIF.Visible = EvetHayirEnum.ehHayir;
                    DRSINIF.TextFont.Name = "Arial";
                    DRSINIF.TextFont.Size = 9;
                    DRSINIF.TextFont.CharSet = 162;
                    DRSINIF.Value = @"";

                    DRRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 41, 262, 47, false);
                    DRRUTBE.Name = "DRRUTBE";
                    DRRUTBE.Visible = EvetHayirEnum.ehHayir;
                    DRRUTBE.TextFont.Name = "Arial";
                    DRRUTBE.TextFont.Size = 9;
                    DRRUTBE.TextFont.CharSet = 162;
                    DRRUTBE.Value = @"";

                    ISTEKDR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 3, 208, 29, false);
                    ISTEKDR.Name = "ISTEKDR";
                    ISTEKDR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKDR.MultiLine = EvetHayirEnum.ehEvet;
                    ISTEKDR.NoClip = EvetHayirEnum.ehEvet;
                    ISTEKDR.WordBreak = EvetHayirEnum.ehEvet;
                    ISTEKDR.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISTEKDR.TextFont.Size = 9;
                    ISTEKDR.TextFont.CharSet = 162;
                    ISTEKDR.Value = @"";

                    ISTEKPSIKOLOG = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 3, 83, 29, false);
                    ISTEKPSIKOLOG.Name = "ISTEKPSIKOLOG";
                    ISTEKPSIKOLOG.Visible = EvetHayirEnum.ehHayir;
                    ISTEKPSIKOLOG.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKPSIKOLOG.MultiLine = EvetHayirEnum.ehEvet;
                    ISTEKPSIKOLOG.NoClip = EvetHayirEnum.ehEvet;
                    ISTEKPSIKOLOG.WordBreak = EvetHayirEnum.ehEvet;
                    ISTEKPSIKOLOG.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISTEKPSIKOLOG.TextFont.Size = 9;
                    ISTEKPSIKOLOG.TextFont.CharSet = 162;
                    ISTEKPSIKOLOG.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DRSINIF.CalcValue = DRSINIF.Value;
                    DRRUTBE.CalcValue = DRRUTBE.Value;
                    ISTEKDR.CalcValue = @"";
                    ISTEKPSIKOLOG.CalcValue = @"";
                    return new TTReportObject[] { DRSINIF,DRRUTBE,ISTEKDR,ISTEKPSIKOLOG};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    //                                                                                                                                                            
//            TTObjectContext objectContext = new TTObjectContext(true);
//            string objectID = ((ManipulationProcedureReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            Manipulation manipulation = (Manipulation)objectContext.GetObject(new Guid(objectID),"Manipulation");
//            
//            if(manipulation.ProcedureDoctor !=null)
//                this.ISTEKDR.CalcValue =manipulation.ProcedureDoctor.SignatureBlock;
//            
//            if(manipulation.ResponsiblePersonnel !=null)
//            {
//                this.ISTEKPSIKOLOG.Visible = EvetHayirEnum.ehEvet;
//                this.ISTEKPSIKOLOG.CalcValue =manipulation.ResponsiblePersonnel.SignatureBlock;
//            }
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public ManipulationProcedureReport MyParentReport
            {
                get { return (ManipulationProcedureReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField UYGULAMALAR { get {return Body().UYGULAMALAR;} }
            public TTReportField ISTEKYAPANDR { get {return Body().ISTEKYAPANDR;} }
            public TTReportField ISTEKYAPANBIRIM { get {return Body().ISTEKYAPANBIRIM;} }
            public TTReportField İSLEMTARİHİ { get {return Body().İSLEMTARİHİ;} }
            public TTReportField CODE { get {return Body().CODE;} }
            public TTReportField TIRE { get {return Body().TIRE;} }
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
                list[0] = new TTReportNqlData<ManipulationProcedure.GetManipulationReportNQL_Class>("GetManipulationReportNQL", ManipulationProcedure.GetManipulationReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public ManipulationProcedureReport MyParentReport
                {
                    get { return (ManipulationProcedureReport)ParentReport; }
                }
                
                public TTReportField UYGULAMALAR;
                public TTReportField ISTEKYAPANDR;
                public TTReportField ISTEKYAPANBIRIM;
                public TTReportField İSLEMTARİHİ;
                public TTReportField CODE;
                public TTReportField TIRE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    UYGULAMALAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 1, 116, 6, false);
                    UYGULAMALAR.Name = "UYGULAMALAR";
                    UYGULAMALAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    UYGULAMALAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UYGULAMALAR.MultiLine = EvetHayirEnum.ehEvet;
                    UYGULAMALAR.NoClip = EvetHayirEnum.ehEvet;
                    UYGULAMALAR.WordBreak = EvetHayirEnum.ehEvet;
                    UYGULAMALAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    UYGULAMALAR.ObjectDefName = "ManipulationProcedure";
                    UYGULAMALAR.DataMember = "PROCEDUREOBJECT.NAME";
                    UYGULAMALAR.TextFont.Size = 9;
                    UYGULAMALAR.TextFont.CharSet = 162;
                    UYGULAMALAR.Value = @"{#OBJECTID#}";

                    ISTEKYAPANDR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 1, 212, 6, false);
                    ISTEKYAPANDR.Name = "ISTEKYAPANDR";
                    ISTEKYAPANDR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKYAPANDR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISTEKYAPANDR.TextFont.Size = 9;
                    ISTEKYAPANDR.TextFont.CharSet = 162;
                    ISTEKYAPANDR.Value = @"";

                    ISTEKYAPANBIRIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 1, 176, 6, false);
                    ISTEKYAPANBIRIM.Name = "ISTEKYAPANBIRIM";
                    ISTEKYAPANBIRIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKYAPANBIRIM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISTEKYAPANBIRIM.ObjectDefName = "ManipulationProcedure";
                    ISTEKYAPANBIRIM.DataMember = "MANIPULATIONREQUEST.FROMRESOURCE.NAME";
                    ISTEKYAPANBIRIM.TextFont.Size = 9;
                    ISTEKYAPANBIRIM.TextFont.CharSet = 162;
                    ISTEKYAPANBIRIM.Value = @"{#OBJECTID#}";

                    İSLEMTARİHİ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 41, 6, false);
                    İSLEMTARİHİ.Name = "İSLEMTARİHİ";
                    İSLEMTARİHİ.FieldType = ReportFieldTypeEnum.ftVariable;
                    İSLEMTARİHİ.TextFormat = @"dd/MM/yyyy";
                    İSLEMTARİHİ.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    İSLEMTARİHİ.MultiLine = EvetHayirEnum.ehEvet;
                    İSLEMTARİHİ.NoClip = EvetHayirEnum.ehEvet;
                    İSLEMTARİHİ.WordBreak = EvetHayirEnum.ehEvet;
                    İSLEMTARİHİ.ExpandTabs = EvetHayirEnum.ehEvet;
                    İSLEMTARİHİ.TextFont.Size = 9;
                    İSLEMTARİHİ.TextFont.CharSet = 162;
                    İSLEMTARİHİ.Value = @"";

                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 1, 56, 6, false);
                    CODE.Name = "CODE";
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CODE.MultiLine = EvetHayirEnum.ehEvet;
                    CODE.NoClip = EvetHayirEnum.ehEvet;
                    CODE.WordBreak = EvetHayirEnum.ehEvet;
                    CODE.ExpandTabs = EvetHayirEnum.ehEvet;
                    CODE.ObjectDefName = "ManipulationProcedure";
                    CODE.DataMember = "PROCEDUREOBJECT.CODE";
                    CODE.TextFont.Size = 9;
                    CODE.TextFont.CharSet = 162;
                    CODE.Value = @"{#OBJECTID#}";

                    TIRE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 1, 58, 6, false);
                    TIRE.Name = "TIRE";
                    TIRE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TIRE.MultiLine = EvetHayirEnum.ehEvet;
                    TIRE.NoClip = EvetHayirEnum.ehEvet;
                    TIRE.WordBreak = EvetHayirEnum.ehEvet;
                    TIRE.ExpandTabs = EvetHayirEnum.ehEvet;
                    TIRE.TextFont.Size = 9;
                    TIRE.TextFont.CharSet = 162;
                    TIRE.Value = @"-";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ManipulationProcedure.GetManipulationReportNQL_Class dataset_GetManipulationReportNQL = ParentGroup.rsGroup.GetCurrentRecord<ManipulationProcedure.GetManipulationReportNQL_Class>(0);
                    UYGULAMALAR.CalcValue = (dataset_GetManipulationReportNQL != null ? Globals.ToStringCore(dataset_GetManipulationReportNQL.ObjectID) : "");
                    UYGULAMALAR.PostFieldValueCalculation();
                    ISTEKYAPANDR.CalcValue = @"";
                    ISTEKYAPANBIRIM.CalcValue = (dataset_GetManipulationReportNQL != null ? Globals.ToStringCore(dataset_GetManipulationReportNQL.ObjectID) : "");
                    ISTEKYAPANBIRIM.PostFieldValueCalculation();
                    İSLEMTARİHİ.CalcValue = @"";
                    CODE.CalcValue = (dataset_GetManipulationReportNQL != null ? Globals.ToStringCore(dataset_GetManipulationReportNQL.ObjectID) : "");
                    CODE.PostFieldValueCalculation();
                    TIRE.CalcValue = TIRE.Value;
                    return new TTReportObject[] { UYGULAMALAR,ISTEKYAPANDR,ISTEKYAPANBIRIM,İSLEMTARİHİ,CODE,TIRE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((ManipulationProcedureReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectClasses.Manipulation manipulation = (TTObjectClasses.Manipulation)objectContext.GetObject(new Guid(objectID), "Manipulation");
            
            if(manipulation.ManipulationRequest != null)
            {
                if(manipulation.ManipulationRequest.ProcedureDoctor != null)
                    this.ISTEKYAPANDR.CalcValue= manipulation.ManipulationRequest.ProcedureDoctor.Name;
                else
                {
                    foreach(TTObjectState state in manipulation.ManipulationRequest.GetStateHistory())
                    {
                        if(state.StateDefID == ManipulationRequest.States.Request)
                        {
                            this.ISTEKYAPANDR.CalcValue=state.User.FullName;
                        }
                    }
                }
            }
            foreach( TTObjectState state in  manipulation.GetStateHistory())
            {
                if(state.StateDefID == Manipulation.States.DoctorProcedure || state.StateDefID == Manipulation.States.TechnicianProcedure)
                    this.İSLEMTARİHİ.CalcValue = state.BranchDate.ToString();
            }
            
            //((ManipulationProcedureReport)ParentReport).HEADER.Fields("BASLIK").CalcValue = this.UYGULAMALAR.CalcValue + " UYGULAMA RAPORU";
            //((AllManipulationProceduresReport)ParentReport).Groups("ALLPARENT").Header.FieldsByName("OBJECTID").CalcValue
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class RAPORGroup : TTReportGroup
        {
            public ManipulationProcedureReport MyParentReport
            {
                get { return (ManipulationProcedureReport)ParentReport; }
            }

            new public RAPORGroupBody Body()
            {
                return (RAPORGroupBody)_body;
            }
            public TTReportField LABEL111 { get {return Body().LABEL111;} }
            public TTReportField REPORT { get {return Body().REPORT;} }
            public RAPORGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public RAPORGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new RAPORGroupBody(this);
            }

            public partial class RAPORGroupBody : TTReportSection
            {
                public ManipulationProcedureReport MyParentReport
                {
                    get { return (ManipulationProcedureReport)ParentReport; }
                }
                
                public TTReportField LABEL111;
                public TTReportField REPORT; 
                public RAPORGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 24;
                    RepeatCount = 0;
                    
                    LABEL111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 57, 6, false);
                    LABEL111.Name = "LABEL111";
                    LABEL111.TextFont.Size = 9;
                    LABEL111.TextFont.Bold = true;
                    LABEL111.TextFont.Underline = true;
                    LABEL111.TextFont.CharSet = 162;
                    LABEL111.Value = @"RAPOR";

                    REPORT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 7, 211, 20, false);
                    REPORT.Name = "REPORT";
                    REPORT.MultiLine = EvetHayirEnum.ehEvet;
                    REPORT.NoClip = EvetHayirEnum.ehEvet;
                    REPORT.WordBreak = EvetHayirEnum.ehEvet;
                    REPORT.ExpandTabs = EvetHayirEnum.ehEvet;
                    REPORT.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LABEL111.CalcValue = LABEL111.Value;
                    REPORT.CalcValue = REPORT.Value;
                    return new TTReportObject[] { LABEL111,REPORT};
                }
                public override void RunPreScript()
                {
#region RAPOR BODY_PreScript
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((ManipulationProcedureReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            Manipulation manipulation = (Manipulation)objectContext.GetObject(new Guid(objectID),"Manipulation");
            if(manipulation.Report!=null)
                this.REPORT.Value = TTReportTool.TTReport.HTMLtoText(manipulation.Report.ToString()) + "\r\n";
#endregion RAPOR BODY_PreScript
                }
            }

        }

        public RAPORGroup RAPOR;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ManipulationProcedureReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            RAPOR = new RAPORGroup(HEADER,"RAPOR");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Manipulation", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "MANIPULATIONPROCEDUREREPORT";
            Caption = "Tıbbi/Cerrahi Uygulama Sonuç Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 1;
            UserMarginTop = 10;
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