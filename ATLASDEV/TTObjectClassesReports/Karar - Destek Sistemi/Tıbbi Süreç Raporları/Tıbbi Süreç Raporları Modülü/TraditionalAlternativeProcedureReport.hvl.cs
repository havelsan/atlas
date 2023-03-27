
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
    /// Geleneksel Alternatif Uygulama Sonuç Raporu
    /// </summary>
    public partial class TraditionalAlternativeProcedureReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public TraditionalAlternativeProcedureReport MyParentReport
            {
                get { return (TraditionalAlternativeProcedureReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField BASLIK { get {return Header().BASLIK;} }
            public TTReportField LABEL1111 { get {return Header().LABEL1111;} }
            public TTReportField LABEL1121 { get {return Header().LABEL1121;} }
            public TTReportField HASTANO { get {return Header().HASTANO;} }
            public TTReportField LABEL11211 { get {return Header().LABEL11211;} }
            public TTReportField LABEL11221 { get {return Header().LABEL11221;} }
            public TTReportField LABEL111211 { get {return Header().LABEL111211;} }
            public TTReportField BABAADI { get {return Header().BABAADI;} }
            public TTReportField LABEL112211 { get {return Header().LABEL112211;} }
            public TTReportField PROTOKOLNO { get {return Header().PROTOKOLNO;} }
            public TTReportField LABEL111221 { get {return Header().LABEL111221;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField ADISOYADI { get {return Header().ADISOYADI;} }
            public TTReportField AYAKTANYATAN { get {return Header().AYAKTANYATAN;} }
            public TTReportField LABEL11231 { get {return Header().LABEL11231;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField TARIH { get {return Header().TARIH;} }
            public TTReportField LABEL11241 { get {return Header().LABEL11241;} }
            public TTReportField NewField11121 { get {return Header().NewField11121;} }
            public TTReportField LABEL1112111 { get {return Header().LABEL1112111;} }
            public TTReportField LABEL11112111 { get {return Header().LABEL11112111;} }
            public TTReportField LABEL12112111 { get {return Header().LABEL12112111;} }
            public TTReportField LABEL111121111 { get {return Header().LABEL111121111;} }
            public TTReportField PATIENTNAME { get {return Header().PATIENTNAME;} }
            public TTReportField PATIENTSURNAME { get {return Header().PATIENTSURNAME;} }
            public TTReportField DOGUMTARIHI { get {return Header().DOGUMTARIHI;} }
            public TTReportField AYAKTANYATAN1 { get {return Header().AYAKTANYATAN1;} }
            public TTReportField DRSINIF { get {return Footer().DRSINIF;} }
            public TTReportField DRRUTBE { get {return Footer().DRRUTBE;} }
            public TTReportField ISTEKDR { get {return Footer().ISTEKDR;} }
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
                public TraditionalAlternativeProcedureReport MyParentReport
                {
                    get { return (TraditionalAlternativeProcedureReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField BASLIK;
                public TTReportField LABEL1111;
                public TTReportField LABEL1121;
                public TTReportField HASTANO;
                public TTReportField LABEL11211;
                public TTReportField LABEL11221;
                public TTReportField LABEL111211;
                public TTReportField BABAADI;
                public TTReportField LABEL112211;
                public TTReportField PROTOKOLNO;
                public TTReportField LABEL111221;
                public TTReportField NewField1111;
                public TTReportField NewField1121;
                public TTReportField NewField1131;
                public TTReportField NewField1141;
                public TTReportField NewField11211;
                public TTReportField NewField11411;
                public TTReportField ADISOYADI;
                public TTReportField AYAKTANYATAN;
                public TTReportField LABEL11231;
                public TTReportField NewField11111;
                public TTReportField TARIH;
                public TTReportField LABEL11241;
                public TTReportField NewField11121;
                public TTReportField LABEL1112111;
                public TTReportField LABEL11112111;
                public TTReportField LABEL12112111;
                public TTReportField LABEL111121111;
                public TTReportField PATIENTNAME;
                public TTReportField PATIENTSURNAME;
                public TTReportField DOGUMTARIHI;
                public TTReportField AYAKTANYATAN1; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 122;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 5, 172, 28, false);
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

                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 30, 172, 43, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK.TextFont.Size = 11;
                    BASLIK.TextFont.Bold = true;
                    BASLIK.TextFont.CharSet = 162;
                    BASLIK.Value = @"GELENEKSEL ALTERNATİF TAMAMLAYICI UYGULAMA SONUÇ RAPORU";

                    LABEL1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 60, 44, 65, false);
                    LABEL1111.Name = "LABEL1111";
                    LABEL1111.TextFont.Size = 9;
                    LABEL1111.TextFont.Bold = true;
                    LABEL1111.TextFont.Underline = true;
                    LABEL1111.TextFont.CharSet = 162;
                    LABEL1111.Value = @"HASTANIN:";

                    LABEL1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 91, 59, 96, false);
                    LABEL1121.Name = "LABEL1121";
                    LABEL1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL1121.TextFont.Size = 9;
                    LABEL1121.TextFont.Bold = true;
                    LABEL1121.TextFont.CharSet = 162;
                    LABEL1121.Value = @"DOĞUM YERİ/TARİHİ";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 71, 115, 76, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTANO.ObjectDefName = "TraditionalAlternative";
                    HASTANO.DataMember = "EPISODE.PATIENT.ID";
                    HASTANO.TextFont.Size = 9;
                    HASTANO.TextFont.CharSet = 162;
                    HASTANO.Value = @"{@TTOBJECTID@}";

                    LABEL11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 71, 59, 76, false);
                    LABEL11211.Name = "LABEL11211";
                    LABEL11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL11211.TextFont.Size = 9;
                    LABEL11211.TextFont.Bold = true;
                    LABEL11211.TextFont.CharSet = 162;
                    LABEL11211.Value = @"HASTA NO";

                    LABEL11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 76, 59, 81, false);
                    LABEL11221.Name = "LABEL11221";
                    LABEL11221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL11221.TextFont.Size = 9;
                    LABEL11221.TextFont.Bold = true;
                    LABEL11221.TextFont.CharSet = 162;
                    LABEL11221.Value = @"ADI SOYADI";

                    LABEL111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 103, 56, 108, false);
                    LABEL111211.Name = "LABEL111211";
                    LABEL111211.Visible = EvetHayirEnum.ehHayir;
                    LABEL111211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL111211.TextFont.Size = 9;
                    LABEL111211.TextFont.Bold = true;
                    LABEL111211.TextFont.CharSet = 162;
                    LABEL111211.Value = @"SINIFI RÜTBESİ";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 86, 115, 91, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.TextFormat = @"dd/MM/yyyy";
                    BABAADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BABAADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    BABAADI.ObjectDefName = "TraditionalAlternative";
                    BABAADI.DataMember = "EPISODE.PATIENT.FATHERNAME";
                    BABAADI.TextFont.Size = 9;
                    BABAADI.TextFont.CharSet = 162;
                    BABAADI.Value = @"{@TTOBJECTID@}";

                    LABEL112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 86, 59, 91, false);
                    LABEL112211.Name = "LABEL112211";
                    LABEL112211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL112211.TextFont.Size = 9;
                    LABEL112211.TextFont.Bold = true;
                    LABEL112211.TextFont.CharSet = 162;
                    LABEL112211.Value = @"BABA ADI";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 66, 115, 71, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROTOKOLNO.ObjectDefName = "TraditionalAlternative";
                    PROTOKOLNO.DataMember = "PROTOCOLNO";
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"{@TTOBJECTID@}";

                    LABEL111221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 66, 59, 71, false);
                    LABEL111221.Name = "LABEL111221";
                    LABEL111221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL111221.TextFont.Size = 9;
                    LABEL111221.TextFont.Bold = true;
                    LABEL111221.TextFont.CharSet = 162;
                    LABEL111221.Value = @"PROTOKOL NO";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 91, 59, 96, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.TextFont.Size = 12;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @":";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 71, 59, 76, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Size = 12;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 76, 59, 81, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Size = 12;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @":";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 81, 59, 86, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Size = 12;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @":";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 86, 59, 91, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Size = 12;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @":";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 66, 59, 71, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.TextFont.Size = 12;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @":";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 76, 168, 81, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.ObjectDefName = "TraditionalAlternative";
                    ADISOYADI.DataMember = "EPISODE.PATIENT.PatientIDandFullName";
                    ADISOYADI.TextFont.Size = 9;
                    ADISOYADI.TextFont.CharSet = 162;
                    ADISOYADI.Value = @"{@TTOBJECTID@}";

                    AYAKTANYATAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 96, 115, 101, false);
                    AYAKTANYATAN.Name = "AYAKTANYATAN";
                    AYAKTANYATAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    AYAKTANYATAN.TextFormat = @"Short Date";
                    AYAKTANYATAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AYAKTANYATAN.ObjectDefName = "PatientStatusEnum";
                    AYAKTANYATAN.DataMember = "DISPLAYTEXT";
                    AYAKTANYATAN.TextFont.Size = 9;
                    AYAKTANYATAN.TextFont.CharSet = 162;
                    AYAKTANYATAN.Value = @"{%AYAKTANYATAN1%}";

                    LABEL11231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 96, 59, 101, false);
                    LABEL11231.Name = "LABEL11231";
                    LABEL11231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL11231.TextFont.Size = 9;
                    LABEL11231.TextFont.Bold = true;
                    LABEL11231.TextFont.CharSet = 162;
                    LABEL11231.Value = @"AYAKTAN/YATAN";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 96, 59, 101, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.TextFont.Size = 12;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @":";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 51, 115, 56, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"dd/MM/yyyy";
                    TARIH.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TARIH.ObjectDefName = "TraditionalAlternative";
                    TARIH.DataMember = "ACTIONDATE";
                    TARIH.TextFont.Size = 9;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"{@TTOBJECTID@}";

                    LABEL11241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 51, 53, 56, false);
                    LABEL11241.Name = "LABEL11241";
                    LABEL11241.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL11241.TextFont.Size = 9;
                    LABEL11241.TextFont.Bold = true;
                    LABEL11241.TextFont.CharSet = 162;
                    LABEL11241.Value = @"TARİH";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 51, 59, 56, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.TextFont.Size = 12;
                    NewField11121.TextFont.Bold = true;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @":";

                    LABEL1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 117, 163, 122, false);
                    LABEL1112111.Name = "LABEL1112111";
                    LABEL1112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL1112111.TextFont.Size = 9;
                    LABEL1112111.TextFont.Bold = true;
                    LABEL1112111.TextFont.Underline = true;
                    LABEL1112111.TextFont.CharSet = 162;
                    LABEL1112111.Value = @"İSTEK YAPAN BİRİM";

                    LABEL11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 117, 114, 122, false);
                    LABEL11112111.Name = "LABEL11112111";
                    LABEL11112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL11112111.TextFont.Size = 9;
                    LABEL11112111.TextFont.Bold = true;
                    LABEL11112111.TextFont.Underline = true;
                    LABEL11112111.TextFont.CharSet = 162;
                    LABEL11112111.Value = @"UYGULANAN İŞLEM(LER)";

                    LABEL12112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 117, 207, 122, false);
                    LABEL12112111.Name = "LABEL12112111";
                    LABEL12112111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL12112111.TextFont.Size = 9;
                    LABEL12112111.TextFont.Bold = true;
                    LABEL12112111.TextFont.Underline = true;
                    LABEL12112111.TextFont.CharSet = 162;
                    LABEL12112111.Value = @"İSTEK YAPAN DOKTOR";

                    LABEL111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 117, 39, 122, false);
                    LABEL111121111.Name = "LABEL111121111";
                    LABEL111121111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL111121111.TextFont.Size = 9;
                    LABEL111121111.TextFont.Bold = true;
                    LABEL111121111.TextFont.Underline = true;
                    LABEL111121111.TextFont.CharSet = 162;
                    LABEL111121111.Value = @"İŞLEM TARİHİ";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 36, 260, 41, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.Visible = EvetHayirEnum.ehHayir;
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.ObjectDefName = "TraditionalAlternative";
                    PATIENTNAME.DataMember = "EPISODE.PATIENT.NAME";
                    PATIENTNAME.TextFont.Name = "Arial";
                    PATIENTNAME.TextFont.Size = 9;
                    PATIENTNAME.TextFont.CharSet = 162;
                    PATIENTNAME.Value = @"{@TTOBJECTID@}";

                    PATIENTSURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 41, 260, 46, false);
                    PATIENTSURNAME.Name = "PATIENTSURNAME";
                    PATIENTSURNAME.Visible = EvetHayirEnum.ehHayir;
                    PATIENTSURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTSURNAME.ObjectDefName = "TraditionalAlternative";
                    PATIENTSURNAME.DataMember = "EPISODE.PATIENT.SURNAME";
                    PATIENTSURNAME.TextFont.Name = "Arial";
                    PATIENTSURNAME.TextFont.Size = 9;
                    PATIENTSURNAME.TextFont.CharSet = 162;
                    PATIENTSURNAME.Value = @"{@TTOBJECTID@}";

                    DOGUMTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 61, 260, 66, false);
                    DOGUMTARIHI.Name = "DOGUMTARIHI";
                    DOGUMTARIHI.Visible = EvetHayirEnum.ehHayir;
                    DOGUMTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMTARIHI.TextFormat = @"Short Date";
                    DOGUMTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOGUMTARIHI.ObjectDefName = "TraditionalAlternative";
                    DOGUMTARIHI.DataMember = "EPISODE.PATIENT.BIRTHDATE";
                    DOGUMTARIHI.TextFont.Name = "Arial";
                    DOGUMTARIHI.TextFont.Size = 9;
                    DOGUMTARIHI.TextFont.CharSet = 162;
                    DOGUMTARIHI.Value = @"{@TTOBJECTID@}";

                    AYAKTANYATAN1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 66, 260, 71, false);
                    AYAKTANYATAN1.Name = "AYAKTANYATAN1";
                    AYAKTANYATAN1.Visible = EvetHayirEnum.ehHayir;
                    AYAKTANYATAN1.FieldType = ReportFieldTypeEnum.ftVariable;
                    AYAKTANYATAN1.TextFormat = @"Short Date";
                    AYAKTANYATAN1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AYAKTANYATAN1.ObjectDefName = "TraditionalAlternative";
                    AYAKTANYATAN1.DataMember = "EPISODE.PATIENTSTATUS";
                    AYAKTANYATAN1.TextFont.Name = "Arial";
                    AYAKTANYATAN1.TextFont.Size = 9;
                    AYAKTANYATAN1.TextFont.CharSet = 162;
                    AYAKTANYATAN1.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BASLIK.CalcValue = @"GELENEKSEL ALTERNATİF TAMAMLAYICI UYGULAMA SONUÇ RAPORU";
                    LABEL1111.CalcValue = LABEL1111.Value;
                    LABEL1121.CalcValue = LABEL1121.Value;
                    HASTANO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    HASTANO.PostFieldValueCalculation();
                    LABEL11211.CalcValue = LABEL11211.Value;
                    LABEL11221.CalcValue = LABEL11221.Value;
                    LABEL111211.CalcValue = LABEL111211.Value;
                    BABAADI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    BABAADI.PostFieldValueCalculation();
                    LABEL112211.CalcValue = LABEL112211.Value;
                    PROTOKOLNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PROTOKOLNO.PostFieldValueCalculation();
                    LABEL111221.CalcValue = LABEL111221.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    ADISOYADI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    ADISOYADI.PostFieldValueCalculation();
                    AYAKTANYATAN1.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    AYAKTANYATAN1.PostFieldValueCalculation();
                    AYAKTANYATAN.CalcValue = MyParentReport.HEADER.AYAKTANYATAN1.FormattedValue;
                    AYAKTANYATAN.PostFieldValueCalculation();
                    LABEL11231.CalcValue = LABEL11231.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    TARIH.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TARIH.PostFieldValueCalculation();
                    LABEL11241.CalcValue = LABEL11241.Value;
                    NewField11121.CalcValue = NewField11121.Value;
                    LABEL1112111.CalcValue = LABEL1112111.Value;
                    LABEL11112111.CalcValue = LABEL11112111.Value;
                    LABEL12112111.CalcValue = LABEL12112111.Value;
                    LABEL111121111.CalcValue = LABEL111121111.Value;
                    PATIENTNAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PATIENTNAME.PostFieldValueCalculation();
                    PATIENTSURNAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PATIENTSURNAME.PostFieldValueCalculation();
                    DOGUMTARIHI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    DOGUMTARIHI.PostFieldValueCalculation();
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { BASLIK,LABEL1111,LABEL1121,HASTANO,LABEL11211,LABEL11221,LABEL111211,BABAADI,LABEL112211,PROTOKOLNO,LABEL111221,NewField1111,NewField1121,NewField1131,NewField1141,NewField11211,NewField11411,ADISOYADI,AYAKTANYATAN1,AYAKTANYATAN,LABEL11231,NewField11111,TARIH,LABEL11241,NewField11121,LABEL1112111,LABEL11112111,LABEL12112111,LABEL111121111,PATIENTNAME,PATIENTSURNAME,DOGUMTARIHI,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((TraditionalAlternativeProcedureReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectClasses.TraditionalAlternative traditionalAlternative = (TTObjectClasses.TraditionalAlternative)objectContext.GetObject(new Guid(objectID), "TraditionalAlternative");
            if(traditionalAlternative.TraditionalAlternativeProcedures != null && traditionalAlternative.TraditionalAlternativeProcedures.Count>0)
            {
                this.BASLIK.CalcValue = traditionalAlternative.TraditionalAlternativeProcedures[0].ProcedureObject.Name + " UYGULAMA RAPORU";
                //((AllManipulationProceduresReport)ParentReport).Groups("ALLPARENT").Header.FieldsByName("OBJECTID").CalcValue
            }
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public TraditionalAlternativeProcedureReport MyParentReport
                {
                    get { return (TraditionalAlternativeProcedureReport)ParentReport; }
                }
                
                public TTReportField DRSINIF;
                public TTReportField DRRUTBE;
                public TTReportField ISTEKDR; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 29;
                    RepeatCount = 0;
                    
                    DRSINIF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 34, 262, 39, false);
                    DRSINIF.Name = "DRSINIF";
                    DRSINIF.Visible = EvetHayirEnum.ehHayir;
                    DRSINIF.TextFont.Name = "Arial";
                    DRSINIF.TextFont.Size = 9;
                    DRSINIF.TextFont.CharSet = 162;
                    DRSINIF.Value = @"";

                    DRRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 39, 262, 45, false);
                    DRRUTBE.Name = "DRRUTBE";
                    DRRUTBE.Visible = EvetHayirEnum.ehHayir;
                    DRRUTBE.TextFont.Name = "Arial";
                    DRRUTBE.TextFont.Size = 9;
                    DRRUTBE.TextFont.CharSet = 162;
                    DRRUTBE.Value = @"";

                    ISTEKDR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 2, 207, 28, false);
                    ISTEKDR.Name = "ISTEKDR";
                    ISTEKDR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKDR.MultiLine = EvetHayirEnum.ehEvet;
                    ISTEKDR.NoClip = EvetHayirEnum.ehEvet;
                    ISTEKDR.WordBreak = EvetHayirEnum.ehEvet;
                    ISTEKDR.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISTEKDR.TextFont.Size = 9;
                    ISTEKDR.TextFont.CharSet = 162;
                    ISTEKDR.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DRSINIF.CalcValue = DRSINIF.Value;
                    DRRUTBE.CalcValue = DRRUTBE.Value;
                    ISTEKDR.CalcValue = @"";
                    return new TTReportObject[] { DRSINIF,DRRUTBE,ISTEKDR};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((TraditionalAlternativeProcedureReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TraditionalAlternative traditionalAlternative = (TraditionalAlternative)objectContext.GetObject(new Guid(objectID),"TraditionalAlternative");
            
            if(traditionalAlternative.ProcedureDoctor!=null)
                this.ISTEKDR.CalcValue =traditionalAlternative.ProcedureDoctor.SignatureBlock;
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public TraditionalAlternativeProcedureReport MyParentReport
            {
                get { return (TraditionalAlternativeProcedureReport)ParentReport; }
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
            public TTReportField TIRE1 { get {return Body().TIRE1;} }
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
                list[0] = new TTReportNqlData<TraditionalAlternativeProcedure.GetTraditionalAlternativeReportNQL_Class>("GetTraditionalAlternativeReportNQL", TraditionalAlternativeProcedure.GetTraditionalAlternativeReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public TraditionalAlternativeProcedureReport MyParentReport
                {
                    get { return (TraditionalAlternativeProcedureReport)ParentReport; }
                }
                
                public TTReportField UYGULAMALAR;
                public TTReportField ISTEKYAPANDR;
                public TTReportField ISTEKYAPANBIRIM;
                public TTReportField İSLEMTARİHİ;
                public TTReportField CODE;
                public TTReportField TIRE1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    UYGULAMALAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 1, 114, 6, false);
                    UYGULAMALAR.Name = "UYGULAMALAR";
                    UYGULAMALAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    UYGULAMALAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UYGULAMALAR.MultiLine = EvetHayirEnum.ehEvet;
                    UYGULAMALAR.NoClip = EvetHayirEnum.ehEvet;
                    UYGULAMALAR.WordBreak = EvetHayirEnum.ehEvet;
                    UYGULAMALAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    UYGULAMALAR.ObjectDefName = "TraditionalAlternativeProcedure";
                    UYGULAMALAR.DataMember = "PROCEDUREOBJECT.NAME";
                    UYGULAMALAR.TextFont.Size = 9;
                    UYGULAMALAR.TextFont.CharSet = 162;
                    UYGULAMALAR.Value = @"{#OBJECTID#}";

                    ISTEKYAPANDR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 1, 207, 6, false);
                    ISTEKYAPANDR.Name = "ISTEKYAPANDR";
                    ISTEKYAPANDR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKYAPANDR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISTEKYAPANDR.TextFont.Size = 9;
                    ISTEKYAPANDR.TextFont.CharSet = 162;
                    ISTEKYAPANDR.Value = @"";

                    ISTEKYAPANBIRIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 1, 171, 6, false);
                    ISTEKYAPANBIRIM.Name = "ISTEKYAPANBIRIM";
                    ISTEKYAPANBIRIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKYAPANBIRIM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISTEKYAPANBIRIM.ObjectDefName = "TraditionalAlternativeProcedure";
                    ISTEKYAPANBIRIM.DataMember = "TRADITIONALALTERNATIVE.FROMRESOURCE.NAME";
                    ISTEKYAPANBIRIM.TextFont.Size = 9;
                    ISTEKYAPANBIRIM.TextFont.CharSet = 162;
                    ISTEKYAPANBIRIM.Value = @"{#OBJECTID#}";

                    İSLEMTARİHİ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 39, 6, false);
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

                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 1, 54, 6, false);
                    CODE.Name = "CODE";
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CODE.MultiLine = EvetHayirEnum.ehEvet;
                    CODE.NoClip = EvetHayirEnum.ehEvet;
                    CODE.WordBreak = EvetHayirEnum.ehEvet;
                    CODE.ExpandTabs = EvetHayirEnum.ehEvet;
                    CODE.ObjectDefName = "TraditionalAlternativeProcedure";
                    CODE.DataMember = "PROCEDUREOBJECT.CODE";
                    CODE.TextFont.Size = 9;
                    CODE.TextFont.CharSet = 162;
                    CODE.Value = @"{#OBJECTID#}";

                    TIRE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 1, 56, 6, false);
                    TIRE1.Name = "TIRE1";
                    TIRE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TIRE1.MultiLine = EvetHayirEnum.ehEvet;
                    TIRE1.NoClip = EvetHayirEnum.ehEvet;
                    TIRE1.WordBreak = EvetHayirEnum.ehEvet;
                    TIRE1.ExpandTabs = EvetHayirEnum.ehEvet;
                    TIRE1.TextFont.Size = 9;
                    TIRE1.TextFont.CharSet = 162;
                    TIRE1.Value = @"-";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TraditionalAlternativeProcedure.GetTraditionalAlternativeReportNQL_Class dataset_GetTraditionalAlternativeReportNQL = ParentGroup.rsGroup.GetCurrentRecord<TraditionalAlternativeProcedure.GetTraditionalAlternativeReportNQL_Class>(0);
                    UYGULAMALAR.CalcValue = (dataset_GetTraditionalAlternativeReportNQL != null ? Globals.ToStringCore(dataset_GetTraditionalAlternativeReportNQL.ObjectID) : "");
                    UYGULAMALAR.PostFieldValueCalculation();
                    ISTEKYAPANDR.CalcValue = @"";
                    ISTEKYAPANBIRIM.CalcValue = (dataset_GetTraditionalAlternativeReportNQL != null ? Globals.ToStringCore(dataset_GetTraditionalAlternativeReportNQL.ObjectID) : "");
                    ISTEKYAPANBIRIM.PostFieldValueCalculation();
                    İSLEMTARİHİ.CalcValue = @"";
                    CODE.CalcValue = (dataset_GetTraditionalAlternativeReportNQL != null ? Globals.ToStringCore(dataset_GetTraditionalAlternativeReportNQL.ObjectID) : "");
                    CODE.PostFieldValueCalculation();
                    TIRE1.CalcValue = TIRE1.Value;
                    return new TTReportObject[] { UYGULAMALAR,ISTEKYAPANDR,ISTEKYAPANBIRIM,İSLEMTARİHİ,CODE,TIRE1};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((TraditionalAlternativeProcedureReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectClasses.TraditionalAlternative traditionalAlternative = (TTObjectClasses.TraditionalAlternative)objectContext.GetObject(new Guid(objectID), "TraditionalAlternative");
            
            if(traditionalAlternative.ProcedureDoctor != null)
                this.ISTEKYAPANDR.CalcValue= traditionalAlternative.ProcedureDoctor.Name;
            
//            foreach( TTObjectState state in  manipulation.ManipulationRequest.GetStateHistory())
//            {
//                if(state.StateDefID == ManipulationRequest.States.Request)
//                {
//                    this.ISTEKYAPANDR.CalcValue=state.User.FullName;
//                }
//            }
            foreach( TTObjectState state in  traditionalAlternative.GetStateHistory())
            {
                if(state.StateDefID == TraditionalAlternative.States.Procedure)
                    this.İSLEMTARİHİ.CalcValue = state.BranchDate.ToString();
            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class RAPORGroup : TTReportGroup
        {
            public TraditionalAlternativeProcedureReport MyParentReport
            {
                get { return (TraditionalAlternativeProcedureReport)ParentReport; }
            }

            new public RAPORGroupBody Body()
            {
                return (RAPORGroupBody)_body;
            }
            public TTReportField LABEL1111 { get {return Body().LABEL1111;} }
            public TTReportRTF REPORT { get {return Body().REPORT;} }
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
                public TraditionalAlternativeProcedureReport MyParentReport
                {
                    get { return (TraditionalAlternativeProcedureReport)ParentReport; }
                }
                
                public TTReportField LABEL1111;
                public TTReportRTF REPORT; 
                public RAPORGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    RepeatCount = 0;
                    
                    LABEL1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 55, 6, false);
                    LABEL1111.Name = "LABEL1111";
                    LABEL1111.TextFont.Size = 9;
                    LABEL1111.TextFont.Bold = true;
                    LABEL1111.TextFont.Underline = true;
                    LABEL1111.TextFont.CharSet = 162;
                    LABEL1111.Value = @"RAPOR";

                    REPORT = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 8, 7, 207, 21, false);
                    REPORT.Name = "REPORT";
                    REPORT.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LABEL1111.CalcValue = LABEL1111.Value;
                    REPORT.CalcValue = REPORT.Value;
                    return new TTReportObject[] { LABEL1111,REPORT};
                }
                public override void RunPreScript()
                {
#region RAPOR BODY_PreScript
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((TraditionalAlternativeProcedureReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TraditionalAlternative traditionalAlternative = (TraditionalAlternative)objectContext.GetObject(new Guid(objectID),"TraditionalAlternative");
            
            if(traditionalAlternative.Report!=null)
                this.REPORT.Value = traditionalAlternative.Report.ToString();
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

        public TraditionalAlternativeProcedureReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            RAPOR = new RAPORGroup(HEADER,"RAPOR");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "TraditionalAlternateive", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "TRADITIONALALTERNATIVEPROCEDUREREPORT";
            Caption = "Geleneksel Alternatif Uygulama Sonuç Raporu";
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