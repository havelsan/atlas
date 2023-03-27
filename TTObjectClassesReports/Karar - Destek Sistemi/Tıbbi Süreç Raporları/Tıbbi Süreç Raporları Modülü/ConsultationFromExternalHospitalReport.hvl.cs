
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
    /// Dış Konsültasyon Formu
    /// </summary>
    public partial class ConsultationFromExternalHospitalReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class part2Group : TTReportGroup
        {
            public ConsultationFromExternalHospitalReport MyParentReport
            {
                get { return (ConsultationFromExternalHospitalReport)ParentReport; }
            }

            new public part2GroupHeader Header()
            {
                return (part2GroupHeader)_header;
            }

            new public part2GroupFooter Footer()
            {
                return (part2GroupFooter)_footer;
            }

            public TTReportField DYERVETARIH { get {return Header().DYERVETARIH;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField LBLUNIQUEREFNO { get {return Header().LBLUNIQUEREFNO;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField LOGO1 { get {return Header().LOGO1;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField REPORTHEADER1 { get {return Header().REPORTHEADER1;} }
            public TTReportField PROTOKOLNO { get {return Header().PROTOKOLNO;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField ACTIONID { get {return Header().ACTIONID;} }
            public TTReportField NewField162 { get {return Header().NewField162;} }
            public TTReportField YATISTARIHI { get {return Header().YATISTARIHI;} }
            public TTReportField NewField172 { get {return Header().NewField172;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField1421 { get {return Header().NewField1421;} }
            public TTReportField NewField1521 { get {return Header().NewField1521;} }
            public TTReportField SEX { get {return Header().SEX;} }
            public TTReportField DTARIH { get {return Header().DTARIH;} }
            public TTReportField DYER { get {return Header().DYER;} }
            public TTReportField EPISODEID { get {return Header().EPISODEID;} }
            public TTReportField EPISODEOBJECTID { get {return Header().EPISODEOBJECTID;} }
            public TTReportField AGE { get {return Header().AGE;} }
            public TTReportField NewField1191 { get {return Header().NewField1191;} }
            public TTReportField NewField11711 { get {return Header().NewField11711;} }
            public TTReportField LBLBASLIK2 { get {return Header().LBLBASLIK2;} }
            public TTReportField LBLBASLIK12 { get {return Header().LBLBASLIK12;} }
            public TTReportField NewField11221 { get {return Header().NewField11221;} }
            public TTReportField AYAKTANTAKIPNO { get {return Header().AYAKTANTAKIPNO;} }
            public TTReportField LBLBASLIK121 { get {return Header().LBLBASLIK121;} }
            public TTReportField NewField112211 { get {return Header().NewField112211;} }
            public TTReportField YATANTAKIPNO { get {return Header().YATANTAKIPNO;} }
            public TTReportField TELEFON { get {return Header().TELEFON;} }
            public TTReportField NewField1241 { get {return Header().NewField1241;} }
            public TTReportField NewField11231 { get {return Header().NewField11231;} }
            public TTReportField ADRES { get {return Header().ADRES;} }
            public TTReportField NewField192 { get {return Header().NewField192;} }
            public TTReportField NewField1172 { get {return Header().NewField1172;} }
            public TTReportField YATTIGIBOLUM { get {return Header().YATTIGIBOLUM;} }
            public TTReportField NewField11721 { get {return Header().NewField11721;} }
            public TTReportField NewField115211 { get {return Header().NewField115211;} }
            public TTReportField CIKISTARIHI { get {return Header().CIKISTARIHI;} }
            public TTReportField NewField1272 { get {return Header().NewField1272;} }
            public TTReportField NewField11252 { get {return Header().NewField11252;} }
            public TTReportField YATISNO { get {return Header().YATISNO;} }
            public TTReportField NewField11911 { get {return Header().NewField11911;} }
            public TTReportField NewField111711 { get {return Header().NewField111711;} }
            public TTReportField KURUM { get {return Header().KURUM;} }
            public TTReportField LBLUNIQUEREFNO1 { get {return Header().LBLUNIQUEREFNO1;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField REQUESTDATE { get {return Header().REQUESTDATE;} }
            public TTReportField NewField1271 { get {return Header().NewField1271;} }
            public TTReportField NewField11251 { get {return Header().NewField11251;} }
            public TTReportField BABAADI { get {return Header().BABAADI;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField111712 { get {return Header().NewField111712;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public part2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public part2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ConsultationFromExternalHospital.GetConsultationFromExternalHospitalNQL_Class>("GetConsultationFromExternalHospitalNQL", ConsultationFromExternalHospital.GetConsultationFromExternalHospitalNQL((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new part2GroupHeader(this);
                _footer = new part2GroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class part2GroupHeader : TTReportSection
            {
                public ConsultationFromExternalHospitalReport MyParentReport
                {
                    get { return (ConsultationFromExternalHospitalReport)ParentReport; }
                }
                
                public TTReportField DYERVETARIH;
                public TTReportField NewField19;
                public TTReportField ADSOYAD;
                public TTReportField NewField121;
                public TTReportField NewField141;
                public TTReportField NewField171;
                public TTReportField UNIQUEREFNO;
                public TTReportField LBLUNIQUEREFNO;
                public TTReportField NewField1131;
                public TTReportField LOGO1;
                public TTReportField XXXXXXBASLIK;
                public TTReportField REPORTHEADER1;
                public TTReportField PROTOKOLNO;
                public TTReportField NewField122;
                public TTReportField ACTIONID;
                public TTReportField NewField162;
                public TTReportField YATISTARIHI;
                public TTReportField NewField172;
                public TTReportField NewField1221;
                public TTReportField NewField1421;
                public TTReportField NewField1521;
                public TTReportField SEX;
                public TTReportField DTARIH;
                public TTReportField DYER;
                public TTReportField EPISODEID;
                public TTReportField EPISODEOBJECTID;
                public TTReportField AGE;
                public TTReportField NewField1191;
                public TTReportField NewField11711;
                public TTReportField LBLBASLIK2;
                public TTReportField LBLBASLIK12;
                public TTReportField NewField11221;
                public TTReportField AYAKTANTAKIPNO;
                public TTReportField LBLBASLIK121;
                public TTReportField NewField112211;
                public TTReportField YATANTAKIPNO;
                public TTReportField TELEFON;
                public TTReportField NewField1241;
                public TTReportField NewField11231;
                public TTReportField ADRES;
                public TTReportField NewField192;
                public TTReportField NewField1172;
                public TTReportField YATTIGIBOLUM;
                public TTReportField NewField11721;
                public TTReportField NewField115211;
                public TTReportField CIKISTARIHI;
                public TTReportField NewField1272;
                public TTReportField NewField11252;
                public TTReportField YATISNO;
                public TTReportField NewField11911;
                public TTReportField NewField111711;
                public TTReportField KURUM;
                public TTReportField LBLUNIQUEREFNO1;
                public TTReportField NewField11311;
                public TTReportField REQUESTDATE;
                public TTReportField NewField1271;
                public TTReportField NewField11251;
                public TTReportField BABAADI;
                public TTReportField NewField1121;
                public TTReportField NewField1141;
                public TTReportField NewField111712; 
                public part2GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 112;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    DYERVETARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 90, 118, 95, false);
                    DYERVETARIH.Name = "DYERVETARIH";
                    DYERVETARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERVETARIH.TextFont.Name = "Arial Narrow";
                    DYERVETARIH.TextFont.Size = 9;
                    DYERVETARIH.Value = @"{%DYER%} / {%DTARIH%}";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 90, 39, 95, false);
                    NewField19.Name = "NewField19";
                    NewField19.TextFont.Name = "Arial Narrow";
                    NewField19.TextFont.Size = 9;
                    NewField19.TextFont.Bold = true;
                    NewField19.Value = @"Doğum Yeri ve Tarihi";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 70, 118, 75, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.Name = "Arial Narrow";
                    ADSOYAD.TextFont.Size = 9;
                    ADSOYAD.Value = @"{#NAME#} {#SURNAME#}";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 70, 39, 75, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Name = "Arial Narrow";
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @"Adı Soyadı";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 70, 41, 75, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Name = "Arial Narrow";
                    NewField141.TextFont.Size = 9;
                    NewField141.TextFont.Bold = true;
                    NewField141.Value = @":";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 90, 41, 95, false);
                    NewField171.Name = "NewField171";
                    NewField171.TextFont.Name = "Arial Narrow";
                    NewField171.TextFont.Size = 9;
                    NewField171.TextFont.Bold = true;
                    NewField171.Value = @":";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 65, 78, 70, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.Value = @"";

                    LBLUNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 65, 39, 70, false);
                    LBLUNIQUEREFNO.Name = "LBLUNIQUEREFNO";
                    LBLUNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    LBLUNIQUEREFNO.TextFont.Size = 9;
                    LBLUNIQUEREFNO.TextFont.Bold = true;
                    LBLUNIQUEREFNO.Value = @"T.C. Kimlik No";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 65, 41, 70, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Name = "Arial Narrow";
                    NewField1131.TextFont.Size = 9;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.Value = @":";

                    LOGO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 33, 30, false);
                    LOGO1.Name = "LOGO1";
                    LOGO1.TextFont.CharSet = 1;
                    LOGO1.Value = @"Logo";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 10, 206, 32, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial Narrow";
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    REPORTHEADER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 32, 206, 38, false);
                    REPORTHEADER1.Name = "REPORTHEADER1";
                    REPORTHEADER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER1.TextFont.Name = "Arial Narrow";
                    REPORTHEADER1.TextFont.Size = 15;
                    REPORTHEADER1.TextFont.Bold = true;
                    REPORTHEADER1.Value = @"DIŞ KONSÜLTASYON FORMU";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 70, 188, 75, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.Name = "Arial Narrow";
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.Value = @"{#PROTOCOLNO#}";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 70, 148, 75, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Name = "Arial Narrow";
                    NewField122.TextFont.Size = 9;
                    NewField122.TextFont.Bold = true;
                    NewField122.Value = @"Protokol No";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 50, 206, 55, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.TextFont.Name = "Arial Narrow";
                    ACTIONID.TextFont.Size = 9;
                    ACTIONID.Value = @"{#ACTIONID#}";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 50, 177, 55, false);
                    NewField162.Name = "NewField162";
                    NewField162.TextFont.Name = "Arial Narrow";
                    NewField162.TextFont.Size = 9;
                    NewField162.TextFont.Bold = true;
                    NewField162.Value = @"İşlem No";

                    YATISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 88, 178, 93, false);
                    YATISTARIHI.Name = "YATISTARIHI";
                    YATISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATISTARIHI.TextFormat = @"g";
                    YATISTARIHI.TextFont.Name = "Arial Narrow";
                    YATISTARIHI.TextFont.Size = 9;
                    YATISTARIHI.Value = @"";

                    NewField172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 88, 148, 93, false);
                    NewField172.Name = "NewField172";
                    NewField172.TextFont.Name = "Arial Narrow";
                    NewField172.TextFont.Size = 9;
                    NewField172.TextFont.Bold = true;
                    NewField172.Value = @"Yatış Tarihi";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 50, 179, 55, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1221.TextFont.Name = "Arial Narrow";
                    NewField1221.TextFont.Size = 9;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.Value = @":";

                    NewField1421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 70, 150, 75, false);
                    NewField1421.Name = "NewField1421";
                    NewField1421.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1421.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1421.TextFont.Name = "Arial Narrow";
                    NewField1421.TextFont.Size = 9;
                    NewField1421.TextFont.Bold = true;
                    NewField1421.Value = @":";

                    NewField1521 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 88, 150, 93, false);
                    NewField1521.Name = "NewField1521";
                    NewField1521.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1521.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1521.TextFont.Name = "Arial Narrow";
                    NewField1521.TextFont.Size = 9;
                    NewField1521.TextFont.Bold = true;
                    NewField1521.Value = @":";

                    SEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 80, 81, 85, false);
                    SEX.Name = "SEX";
                    SEX.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEX.TextFont.Name = "Arial Narrow";
                    SEX.TextFont.Size = 9;
                    SEX.Value = @"{#CINSIYET#}";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 56, 258, 61, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"Short Date";
                    DTARIH.TextFont.Name = "Arial Narrow";
                    DTARIH.TextFont.Size = 9;
                    DTARIH.Value = @"{#BIRTHDATE#}";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 61, 258, 66, false);
                    DYER.Name = "DYER";
                    DYER.Visible = EvetHayirEnum.ehHayir;
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.TextFont.Name = "Arial Narrow";
                    DYER.TextFont.Size = 9;
                    DYER.Value = @"{#CITYNAME#}";

                    EPISODEID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 46, 269, 51, false);
                    EPISODEID.Name = "EPISODEID";
                    EPISODEID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEID.TextFont.Name = "Arial Narrow";
                    EPISODEID.TextFont.Size = 9;
                    EPISODEID.Value = @"{#EPISODEOBJECTID#}";

                    EPISODEOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 51, 269, 56, false);
                    EPISODEOBJECTID.Name = "EPISODEOBJECTID";
                    EPISODEOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEOBJECTID.TextFont.Name = "Arial Narrow";
                    EPISODEOBJECTID.TextFont.Size = 9;
                    EPISODEOBJECTID.Value = @"{#EPISODEOBJECTID#}";

                    AGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 80, 60, 85, false);
                    AGE.Name = "AGE";
                    AGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGE.TextFont.Name = "Arial Narrow";
                    AGE.TextFont.Size = 9;
                    AGE.Value = @"";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 80, 39, 85, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.TextFont.Name = "Arial Narrow";
                    NewField1191.TextFont.Size = 9;
                    NewField1191.TextFont.Bold = true;
                    NewField1191.Value = @"Hasta Yaşı / Cinsiyeti";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 80, 41, 85, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.TextFont.Name = "Arial Narrow";
                    NewField11711.TextFont.Size = 9;
                    NewField11711.TextFont.Bold = true;
                    NewField11711.Value = @":";

                    LBLBASLIK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 50, 56, 55, false);
                    LBLBASLIK2.Name = "LBLBASLIK2";
                    LBLBASLIK2.TextFont.Name = "Arial Narrow";
                    LBLBASLIK2.TextFont.Bold = true;
                    LBLBASLIK2.Value = @"Hastanın Özlük Bilgileri";

                    LBLBASLIK12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 50, 83, 55, false);
                    LBLBASLIK12.Name = "LBLBASLIK12";
                    LBLBASLIK12.TextFont.Name = "Arial Narrow";
                    LBLBASLIK12.TextFont.Size = 9;
                    LBLBASLIK12.TextFont.Bold = true;
                    LBLBASLIK12.Value = @"Ayaktan Takip No";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 50, 85, 55, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11221.TextFont.Name = "Arial Narrow";
                    NewField11221.TextFont.Size = 9;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.Value = @":";

                    AYAKTANTAKIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 50, 104, 55, false);
                    AYAKTANTAKIPNO.Name = "AYAKTANTAKIPNO";
                    AYAKTANTAKIPNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    AYAKTANTAKIPNO.TextFont.Name = "Arial Narrow";
                    AYAKTANTAKIPNO.TextFont.Size = 9;
                    AYAKTANTAKIPNO.Value = @"";

                    LBLBASLIK121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 50, 130, 55, false);
                    LBLBASLIK121.Name = "LBLBASLIK121";
                    LBLBASLIK121.TextFont.Name = "Arial Narrow";
                    LBLBASLIK121.TextFont.Size = 9;
                    LBLBASLIK121.TextFont.Bold = true;
                    LBLBASLIK121.Value = @"Yatan Takip No";

                    NewField112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 50, 132, 55, false);
                    NewField112211.Name = "NewField112211";
                    NewField112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112211.TextFont.Name = "Arial Narrow";
                    NewField112211.TextFont.Size = 9;
                    NewField112211.TextFont.Bold = true;
                    NewField112211.Value = @":";

                    YATANTAKIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 50, 151, 55, false);
                    YATANTAKIPNO.Name = "YATANTAKIPNO";
                    YATANTAKIPNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATANTAKIPNO.TextFont.Name = "Arial Narrow";
                    YATANTAKIPNO.TextFont.Size = 9;
                    YATANTAKIPNO.Value = @"";

                    TELEFON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 85, 68, 90, false);
                    TELEFON.Name = "TELEFON";
                    TELEFON.FieldType = ReportFieldTypeEnum.ftVariable;
                    TELEFON.TextFont.Name = "Arial Narrow";
                    TELEFON.TextFont.Size = 9;
                    TELEFON.Value = @"{#MOBILEPHONE#}";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 85, 38, 90, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.TextFont.Name = "Arial Narrow";
                    NewField1241.TextFont.Size = 9;
                    NewField1241.TextFont.Bold = true;
                    NewField1241.Value = @"Telefonu";

                    NewField11231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 85, 41, 90, false);
                    NewField11231.Name = "NewField11231";
                    NewField11231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11231.TextFont.Name = "Arial Narrow";
                    NewField11231.TextFont.Size = 9;
                    NewField11231.TextFont.Bold = true;
                    NewField11231.Value = @":";

                    ADRES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 95, 118, 107, false);
                    ADRES.Name = "ADRES";
                    ADRES.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRES.MultiLine = EvetHayirEnum.ehEvet;
                    ADRES.WordBreak = EvetHayirEnum.ehEvet;
                    ADRES.TextFont.Name = "Arial Narrow";
                    ADRES.TextFont.Size = 9;
                    ADRES.Value = @"{#HOMEADDRESS#}";

                    NewField192 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 95, 39, 100, false);
                    NewField192.Name = "NewField192";
                    NewField192.TextFont.Name = "Arial Narrow";
                    NewField192.TextFont.Size = 9;
                    NewField192.TextFont.Bold = true;
                    NewField192.Value = @"Adresi";

                    NewField1172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 95, 41, 100, false);
                    NewField1172.Name = "NewField1172";
                    NewField1172.TextFont.Name = "Arial Narrow";
                    NewField1172.TextFont.Size = 9;
                    NewField1172.TextFont.Bold = true;
                    NewField1172.Value = @":";

                    YATTIGIBOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 75, 206, 88, false);
                    YATTIGIBOLUM.Name = "YATTIGIBOLUM";
                    YATTIGIBOLUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATTIGIBOLUM.TextFormat = @"g";
                    YATTIGIBOLUM.MultiLine = EvetHayirEnum.ehEvet;
                    YATTIGIBOLUM.WordBreak = EvetHayirEnum.ehEvet;
                    YATTIGIBOLUM.TextFont.Name = "Arial Narrow";
                    YATTIGIBOLUM.TextFont.Size = 9;
                    YATTIGIBOLUM.Value = @"";

                    NewField11721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 75, 148, 80, false);
                    NewField11721.Name = "NewField11721";
                    NewField11721.TextFont.Name = "Arial Narrow";
                    NewField11721.TextFont.Size = 9;
                    NewField11721.TextFont.Bold = true;
                    NewField11721.Value = @"Yattığı Bölüm";

                    NewField115211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 75, 150, 80, false);
                    NewField115211.Name = "NewField115211";
                    NewField115211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField115211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField115211.TextFont.Name = "Arial Narrow";
                    NewField115211.TextFont.Size = 9;
                    NewField115211.TextFont.Bold = true;
                    NewField115211.Value = @":";

                    CIKISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 93, 178, 98, false);
                    CIKISTARIHI.Name = "CIKISTARIHI";
                    CIKISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    CIKISTARIHI.TextFormat = @"g";
                    CIKISTARIHI.TextFont.Name = "Arial Narrow";
                    CIKISTARIHI.TextFont.Size = 9;
                    CIKISTARIHI.Value = @"";

                    NewField1272 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 93, 148, 98, false);
                    NewField1272.Name = "NewField1272";
                    NewField1272.TextFont.Name = "Arial Narrow";
                    NewField1272.TextFont.Size = 9;
                    NewField1272.TextFont.Bold = true;
                    NewField1272.Value = @"Çıkış Tarihi";

                    NewField11252 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 93, 150, 98, false);
                    NewField11252.Name = "NewField11252";
                    NewField11252.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11252.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11252.TextFont.Name = "Arial Narrow";
                    NewField11252.TextFont.Size = 9;
                    NewField11252.TextFont.Bold = true;
                    NewField11252.Value = @":";

                    YATISNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 98, 170, 103, false);
                    YATISNO.Name = "YATISNO";
                    YATISNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATISNO.TextFont.Name = "Arial Narrow";
                    YATISNO.TextFont.Size = 9;
                    YATISNO.Value = @"";

                    NewField11911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 98, 148, 103, false);
                    NewField11911.Name = "NewField11911";
                    NewField11911.TextFont.Name = "Arial Narrow";
                    NewField11911.TextFont.Size = 9;
                    NewField11911.TextFont.Bold = true;
                    NewField11911.Value = @"Yatış No";

                    NewField111711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 98, 150, 103, false);
                    NewField111711.Name = "NewField111711";
                    NewField111711.TextFont.Name = "Arial Narrow";
                    NewField111711.TextFont.Size = 9;
                    NewField111711.TextFont.Bold = true;
                    NewField111711.Value = @":";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 107, 206, 112, false);
                    KURUM.Name = "KURUM";
                    KURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUM.MultiLine = EvetHayirEnum.ehEvet;
                    KURUM.NoClip = EvetHayirEnum.ehEvet;
                    KURUM.WordBreak = EvetHayirEnum.ehEvet;
                    KURUM.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURUM.TextFont.Name = "Arial Narrow";
                    KURUM.TextFont.Size = 9;
                    KURUM.Value = @"{#PAYERNAME#}";

                    LBLUNIQUEREFNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 107, 39, 112, false);
                    LBLUNIQUEREFNO1.Name = "LBLUNIQUEREFNO1";
                    LBLUNIQUEREFNO1.TextFont.Name = "Arial Narrow";
                    LBLUNIQUEREFNO1.TextFont.Size = 9;
                    LBLUNIQUEREFNO1.TextFont.Bold = true;
                    LBLUNIQUEREFNO1.Value = @"Kurum Adı";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 107, 41, 112, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311.TextFont.Name = "Arial Narrow";
                    NewField11311.TextFont.Size = 9;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.Value = @":";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 65, 178, 70, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"g";
                    REQUESTDATE.TextFont.Name = "Arial Narrow";
                    REQUESTDATE.TextFont.Size = 9;
                    REQUESTDATE.Value = @"{#REQUESTDATE#}";

                    NewField1271 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 65, 148, 70, false);
                    NewField1271.Name = "NewField1271";
                    NewField1271.TextFont.Name = "Arial Narrow";
                    NewField1271.TextFont.Size = 9;
                    NewField1271.TextFont.Bold = true;
                    NewField1271.Value = @"Tarih";

                    NewField11251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 65, 150, 70, false);
                    NewField11251.Name = "NewField11251";
                    NewField11251.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11251.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11251.TextFont.Name = "Arial Narrow";
                    NewField11251.TextFont.Size = 9;
                    NewField11251.TextFont.Bold = true;
                    NewField11251.Value = @":";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 75, 118, 80, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.TextFont.Name = "Arial Narrow";
                    BABAADI.TextFont.Size = 9;
                    BABAADI.Value = @"";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 75, 39, 80, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Name = "Arial Narrow";
                    NewField1121.TextFont.Size = 9;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.Value = @"Baba Adı";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 75, 41, 80, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Name = "Arial Narrow";
                    NewField1141.TextFont.Size = 9;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.Value = @":";

                    NewField111712 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 80, 62, 85, false);
                    NewField111712.Name = "NewField111712";
                    NewField111712.TextFont.Name = "Arial Narrow";
                    NewField111712.TextFont.Size = 9;
                    NewField111712.TextFont.Bold = true;
                    NewField111712.Value = @"/";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ConsultationFromExternalHospital.GetConsultationFromExternalHospitalNQL_Class dataset_GetConsultationFromExternalHospitalNQL = ParentGroup.rsGroup.GetCurrentRecord<ConsultationFromExternalHospital.GetConsultationFromExternalHospitalNQL_Class>(0);
                    DYER.CalcValue = (dataset_GetConsultationFromExternalHospitalNQL != null ? Globals.ToStringCore(dataset_GetConsultationFromExternalHospitalNQL.Cityname) : "");
                    DTARIH.CalcValue = (dataset_GetConsultationFromExternalHospitalNQL != null ? Globals.ToStringCore(dataset_GetConsultationFromExternalHospitalNQL.BirthDate) : "");
                    DYERVETARIH.CalcValue = MyParentReport.part2.DYER.CalcValue + @" / " + MyParentReport.part2.DTARIH.FormattedValue;
                    NewField19.CalcValue = NewField19.Value;
                    ADSOYAD.CalcValue = (dataset_GetConsultationFromExternalHospitalNQL != null ? Globals.ToStringCore(dataset_GetConsultationFromExternalHospitalNQL.Name) : "") + @" " + (dataset_GetConsultationFromExternalHospitalNQL != null ? Globals.ToStringCore(dataset_GetConsultationFromExternalHospitalNQL.Surname) : "");
                    NewField121.CalcValue = NewField121.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField171.CalcValue = NewField171.Value;
                    UNIQUEREFNO.CalcValue = @"";
                    LBLUNIQUEREFNO.CalcValue = LBLUNIQUEREFNO.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    LOGO1.CalcValue = LOGO1.Value;
                    REPORTHEADER1.CalcValue = REPORTHEADER1.Value;
                    PROTOKOLNO.CalcValue = (dataset_GetConsultationFromExternalHospitalNQL != null ? Globals.ToStringCore(dataset_GetConsultationFromExternalHospitalNQL.ProtocolNo) : "");
                    NewField122.CalcValue = NewField122.Value;
                    ACTIONID.CalcValue = (dataset_GetConsultationFromExternalHospitalNQL != null ? Globals.ToStringCore(dataset_GetConsultationFromExternalHospitalNQL.Actionid) : "");
                    NewField162.CalcValue = NewField162.Value;
                    YATISTARIHI.CalcValue = @"";
                    NewField172.CalcValue = NewField172.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1421.CalcValue = NewField1421.Value;
                    NewField1521.CalcValue = NewField1521.Value;
                    SEX.CalcValue = (dataset_GetConsultationFromExternalHospitalNQL != null ? Globals.ToStringCore(dataset_GetConsultationFromExternalHospitalNQL.Cinsiyet) : "");
                    EPISODEID.CalcValue = (dataset_GetConsultationFromExternalHospitalNQL != null ? Globals.ToStringCore(dataset_GetConsultationFromExternalHospitalNQL.Episodeobjectid) : "");
                    EPISODEOBJECTID.CalcValue = (dataset_GetConsultationFromExternalHospitalNQL != null ? Globals.ToStringCore(dataset_GetConsultationFromExternalHospitalNQL.Episodeobjectid) : "");
                    AGE.CalcValue = @"";
                    NewField1191.CalcValue = NewField1191.Value;
                    NewField11711.CalcValue = NewField11711.Value;
                    LBLBASLIK2.CalcValue = LBLBASLIK2.Value;
                    LBLBASLIK12.CalcValue = LBLBASLIK12.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    AYAKTANTAKIPNO.CalcValue = @"";
                    LBLBASLIK121.CalcValue = LBLBASLIK121.Value;
                    NewField112211.CalcValue = NewField112211.Value;
                    YATANTAKIPNO.CalcValue = @"";
                    TELEFON.CalcValue = (dataset_GetConsultationFromExternalHospitalNQL != null ? Globals.ToStringCore(dataset_GetConsultationFromExternalHospitalNQL.MobilePhone) : "");
                    NewField1241.CalcValue = NewField1241.Value;
                    NewField11231.CalcValue = NewField11231.Value;
                    ADRES.CalcValue = (dataset_GetConsultationFromExternalHospitalNQL != null ? Globals.ToStringCore(dataset_GetConsultationFromExternalHospitalNQL.HomeAddress) : "");
                    NewField192.CalcValue = NewField192.Value;
                    NewField1172.CalcValue = NewField1172.Value;
                    YATTIGIBOLUM.CalcValue = @"";
                    NewField11721.CalcValue = NewField11721.Value;
                    NewField115211.CalcValue = NewField115211.Value;
                    CIKISTARIHI.CalcValue = @"";
                    NewField1272.CalcValue = NewField1272.Value;
                    NewField11252.CalcValue = NewField11252.Value;
                    YATISNO.CalcValue = @"";
                    NewField11911.CalcValue = NewField11911.Value;
                    NewField111711.CalcValue = NewField111711.Value;
                    KURUM.CalcValue = (dataset_GetConsultationFromExternalHospitalNQL != null ? Globals.ToStringCore(dataset_GetConsultationFromExternalHospitalNQL.Payername) : "");
                    LBLUNIQUEREFNO1.CalcValue = LBLUNIQUEREFNO1.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    REQUESTDATE.CalcValue = (dataset_GetConsultationFromExternalHospitalNQL != null ? Globals.ToStringCore(dataset_GetConsultationFromExternalHospitalNQL.RequestDate) : "");
                    NewField1271.CalcValue = NewField1271.Value;
                    NewField11251.CalcValue = NewField11251.Value;
                    BABAADI.CalcValue = @"";
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField111712.CalcValue = NewField111712.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { DYER,DTARIH,DYERVETARIH,NewField19,ADSOYAD,NewField121,NewField141,NewField171,UNIQUEREFNO,LBLUNIQUEREFNO,NewField1131,LOGO1,REPORTHEADER1,PROTOKOLNO,NewField122,ACTIONID,NewField162,YATISTARIHI,NewField172,NewField1221,NewField1421,NewField1521,SEX,EPISODEID,EPISODEOBJECTID,AGE,NewField1191,NewField11711,LBLBASLIK2,LBLBASLIK12,NewField11221,AYAKTANTAKIPNO,LBLBASLIK121,NewField112211,YATANTAKIPNO,TELEFON,NewField1241,NewField11231,ADRES,NewField192,NewField1172,YATTIGIBOLUM,NewField11721,NewField115211,CIKISTARIHI,NewField1272,NewField11252,YATISNO,NewField11911,NewField111711,KURUM,LBLUNIQUEREFNO1,NewField11311,REQUESTDATE,NewField1271,NewField11251,BABAADI,NewField1121,NewField1141,NewField111712,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region PART2 HEADER_Script
                    int cnt = 1;
            TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((ConsultationFromExternalHospitalReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            ConsultationFromExternalHospital consultationFromExternalHospital = (ConsultationFromExternalHospital)objectContext.GetObject(new Guid(objectID),"ConsultationFromExternalHospital");
            
            this.AYAKTANTAKIPNO.CalcValue = consultationFromExternalHospital.SubEpisode.SubEpisodeProtocols[0].MedulaTakipNo;
            if (consultationFromExternalHospital==null)
                throw new Exception("Rapor, Konsültasyon tabı üzerinden alınmalıdır.");
            
            Episode episode = consultationFromExternalHospital.Episode;
            
            if (consultationFromExternalHospital.Episode != null && consultationFromExternalHospital.Episode.Patient != null )
            {
                if(consultationFromExternalHospital.Episode.Patient.Foreign == true)
                {
                    this.LBLUNIQUEREFNO.CalcValue = "Yabancı Kimlik No";
                }
                else
                {
                    this.LBLUNIQUEREFNO.CalcValue = "T.C. Kimlik No";
                }
                this.UNIQUEREFNO.CalcValue = consultationFromExternalHospital.Episode.Patient.RefNo;
            }
            
            this.AGE.CalcValue = episode.Patient.Age.Value.ToString();
            
           if(episode.LastSubEpisode != null && episode.LastSubEpisode.PatientStatus == SubEpisodeStatusEnum.Inpatient)
            {
                SubEpisode lastSubEpisode = episode.LastSubEpisode;
                this.YATISNO.CalcValue = lastSubEpisode.ProtocolNo;
                        if (lastSubEpisode.InpatientAdmission != null)
                        {
                            if (lastSubEpisode.InpatientAdmission.HospitalInPatientDate.HasValue)
                                this.YATISTARIHI.CalcValue = lastSubEpisode.InpatientAdmission.HospitalInPatientDate.Value.ToShortTimeString();
                            if (lastSubEpisode.InpatientAdmission.HospitalDischargeDate.HasValue)
                                this.CIKISTARIHI.CalcValue = lastSubEpisode.InpatientAdmission.HospitalDischargeDate.Value.ToShortTimeString();
                            if (lastSubEpisode.StarterEpisodeAction is InPatientTreatmentClinicApplication)
                                this.YATTIGIBOLUM.CalcValue = lastSubEpisode.StarterEpisodeAction.MasterResource.Name;
                        }
                //ResClinic clinic = episode.GetInPatientTreatmentClinic();
                ////InPatientTreatmentClinicApplication lastInpatientTreatmentClinicApp = episode.LastSubEpisode.InPatientTreatmentClinicApplications.Select("CANCELLED = 0","ORDER BY REQUESTDATE DESC");
                //if(clinic != null)
                //    this.YATTIGIBOLUM.CalcValue = clinic.Name;
                SubEpisodeProtocol sep = episode.GetLastSGKSEP();
                if(sep != null)
                    this.YATANTAKIPNO.CalcValue = sep.MedulaTakipNo;

            }
#endregion PART2 HEADER_Script
                }
            }
            public partial class part2GroupFooter : TTReportSection
            {
                public ConsultationFromExternalHospitalReport MyParentReport
                {
                    get { return (ConsultationFromExternalHospitalReport)ParentReport; }
                }
                
                public TTReportShape NewLine12;
                public TTReportField PrintDate;
                public TTReportField PageNumber; 
                public part2GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 19;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 2, 206, 2, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 3, 206, 8, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PrintDate.TextFont.Name = "Arial Narrow";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.Value = @"{@printdate@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 3, 120, 8, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PageNumber.TextFont.Name = "Arial Narrow";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ConsultationFromExternalHospital.GetConsultationFromExternalHospitalNQL_Class dataset_GetConsultationFromExternalHospitalNQL = ParentGroup.rsGroup.GetCurrentRecord<ConsultationFromExternalHospital.GetConsultationFromExternalHospitalNQL_Class>(0);
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    return new TTReportObject[] { PrintDate,PageNumber};
                }
            }

        }

        public part2Group part2;

        public partial class MAINGroup : TTReportGroup
        {
            public ConsultationFromExternalHospitalReport MyParentReport
            {
                get { return (ConsultationFromExternalHospitalReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField REQUESTTEXT { get {return Body().REQUESTTEXT;} }
            public TTReportField EXTERNALHOSPITALNAME { get {return Body().EXTERNALHOSPITALNAME;} }
            public TTReportField EXTERNALSPECIALITYNAME { get {return Body().EXTERNALSPECIALITYNAME;} }
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
                public ConsultationFromExternalHospitalReport MyParentReport
                {
                    get { return (ConsultationFromExternalHospitalReport)ParentReport; }
                }
                
                public TTReportField REQUESTTEXT;
                public TTReportField EXTERNALHOSPITALNAME;
                public TTReportField EXTERNALSPECIALITYNAME; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 15;
                    RepeatCount = 0;
                    
                    REQUESTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 206, 13, false);
                    REQUESTTEXT.Name = "REQUESTTEXT";
                    REQUESTTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTTEXT.MultiLine = EvetHayirEnum.ehEvet;
                    REQUESTTEXT.NoClip = EvetHayirEnum.ehEvet;
                    REQUESTTEXT.WordBreak = EvetHayirEnum.ehEvet;
                    REQUESTTEXT.ExpandTabs = EvetHayirEnum.ehEvet;
                    REQUESTTEXT.TextFont.Name = "Arial Narrow";
                    REQUESTTEXT.TextFont.CharSet = 1;
                    REQUESTTEXT.Value = @"";

                    EXTERNALHOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, -1, 267, 4, false);
                    EXTERNALHOSPITALNAME.Name = "EXTERNALHOSPITALNAME";
                    EXTERNALHOSPITALNAME.Visible = EvetHayirEnum.ehHayir;
                    EXTERNALHOSPITALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXTERNALHOSPITALNAME.TextFont.Name = "Arial Narrow";
                    EXTERNALHOSPITALNAME.TextFont.Size = 9;
                    EXTERNALHOSPITALNAME.Value = @"{#part2.EXTERNALHOSPITALNAME#}";

                    EXTERNALSPECIALITYNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 4, 267, 9, false);
                    EXTERNALSPECIALITYNAME.Name = "EXTERNALSPECIALITYNAME";
                    EXTERNALSPECIALITYNAME.Visible = EvetHayirEnum.ehHayir;
                    EXTERNALSPECIALITYNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXTERNALSPECIALITYNAME.TextFont.Name = "Arial Narrow";
                    EXTERNALSPECIALITYNAME.TextFont.Size = 9;
                    EXTERNALSPECIALITYNAME.Value = @"{#part2.EXTERNALSPECIALITYNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ConsultationFromExternalHospital.GetConsultationFromExternalHospitalNQL_Class dataset_GetConsultationFromExternalHospitalNQL = MyParentReport.part2.rsGroup.GetCurrentRecord<ConsultationFromExternalHospital.GetConsultationFromExternalHospitalNQL_Class>(0);
                    REQUESTTEXT.CalcValue = @"";
                    EXTERNALHOSPITALNAME.CalcValue = (dataset_GetConsultationFromExternalHospitalNQL != null ? Globals.ToStringCore(dataset_GetConsultationFromExternalHospitalNQL.Externalhospitalname) : "");
                    EXTERNALSPECIALITYNAME.CalcValue = (dataset_GetConsultationFromExternalHospitalNQL != null ? Globals.ToStringCore(dataset_GetConsultationFromExternalHospitalNQL.Externalspecialityname) : "");
                    return new TTReportObject[] { REQUESTTEXT,EXTERNALHOSPITALNAME,EXTERNALSPECIALITYNAME};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string hospName = this.EXTERNALHOSPITALNAME.CalcValue;
            string specName = this.EXTERNALSPECIALITYNAME.CalcValue;
            this.REQUESTTEXT.CalcValue = hospName + " / " + specName + " servisine, XXXXXXmizde tedavi görmekte olan yukarıda adı soyadı yazılı hastanın aşağıdaki notlar doğrultusunda konsültasyonunun yapılmasını rica ederim";
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PATIENTFOLDERGroup : TTReportGroup
        {
            public ConsultationFromExternalHospitalReport MyParentReport
            {
                get { return (ConsultationFromExternalHospitalReport)ParentReport; }
            }

            new public PATIENTFOLDERGroupBody Body()
            {
                return (PATIENTFOLDERGroupBody)_body;
            }
            public TTReportField REQUESTDESC { get {return Body().REQUESTDESC;} }
            public TTReportField NewField1101 { get {return Body().NewField1101;} }
            public PATIENTFOLDERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PATIENTFOLDERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PATIENTFOLDERGroupBody(this);
            }

            public partial class PATIENTFOLDERGroupBody : TTReportSection
            {
                public ConsultationFromExternalHospitalReport MyParentReport
                {
                    get { return (ConsultationFromExternalHospitalReport)ParentReport; }
                }
                
                public TTReportField REQUESTDESC;
                public TTReportField NewField1101; 
                public PATIENTFOLDERGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 55;
                    RepeatCount = 0;
                    
                    REQUESTDESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 13, 206, 54, false);
                    REQUESTDESC.Name = "REQUESTDESC";
                    REQUESTDESC.MultiLine = EvetHayirEnum.ehEvet;
                    REQUESTDESC.NoClip = EvetHayirEnum.ehEvet;
                    REQUESTDESC.WordBreak = EvetHayirEnum.ehEvet;
                    REQUESTDESC.ExpandTabs = EvetHayirEnum.ehEvet;
                    REQUESTDESC.TextFont.Name = "Arial Narrow";
                    REQUESTDESC.TextFont.CharSet = 1;
                    REQUESTDESC.Value = @"";

                    NewField1101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 7, 83, 12, false);
                    NewField1101.Name = "NewField1101";
                    NewField1101.TextFont.Name = "Arial Narrow";
                    NewField1101.TextFont.Size = 9;
                    NewField1101.TextFont.Bold = true;
                    NewField1101.Value = @"Konsültasyon İstem Sebebi";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REQUESTDESC.CalcValue = REQUESTDESC.Value;
                    NewField1101.CalcValue = NewField1101.Value;
                    return new TTReportObject[] { REQUESTDESC,NewField1101};
                }
                public override void RunPreScript()
                {
#region PATIENTFOLDER BODY_PreScript
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((ConsultationFromExternalHospitalReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            ConsultationFromExternalHospital consultationFromExternalHospital = (ConsultationFromExternalHospital)objectContext.GetObject(new Guid(objectID),"ConsultationFromExternalHospital");
            if(consultationFromExternalHospital.RequestDescription !=null)
                this.REQUESTDESC.Value = TTReportTool.TTReport.HTMLtoText(consultationFromExternalHospital.RequestDescription.ToString()); //this.ParentGroup.Fields("PATIENTFOLDER").Value;
#endregion PATIENTFOLDER BODY_PreScript
                }
            }

        }

        public PATIENTFOLDERGroup PATIENTFOLDER;

        public partial class PATIENTSTORYGroup : TTReportGroup
        {
            public ConsultationFromExternalHospitalReport MyParentReport
            {
                get { return (ConsultationFromExternalHospitalReport)ParentReport; }
            }

            new public PATIENTSTORYGroupBody Body()
            {
                return (PATIENTSTORYGroupBody)_body;
            }
            public TTReportField NewField101 { get {return Body().NewField101;} }
            public TTReportField ISTEKDR { get {return Body().ISTEKDR;} }
            public PATIENTSTORYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PATIENTSTORYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PATIENTSTORYGroupBody(this);
            }

            public partial class PATIENTSTORYGroupBody : TTReportSection
            {
                public ConsultationFromExternalHospitalReport MyParentReport
                {
                    get { return (ConsultationFromExternalHospitalReport)ParentReport; }
                }
                
                public TTReportField NewField101;
                public TTReportField ISTEKDR; 
                public PATIENTSTORYGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 37;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 11, 83, 16, false);
                    NewField101.Name = "NewField101";
                    NewField101.TextFont.Name = "Arial Narrow";
                    NewField101.TextFont.Size = 9;
                    NewField101.TextFont.Bold = true;
                    NewField101.Value = @"Hekim - Kaşe - İmza";

                    ISTEKDR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 16, 83, 36, false);
                    ISTEKDR.Name = "ISTEKDR";
                    ISTEKDR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKDR.MultiLine = EvetHayirEnum.ehEvet;
                    ISTEKDR.NoClip = EvetHayirEnum.ehEvet;
                    ISTEKDR.WordBreak = EvetHayirEnum.ehEvet;
                    ISTEKDR.ExpandTabs = EvetHayirEnum.ehEvet;
                    ISTEKDR.TextFont.Name = "Arial Narrow";
                    ISTEKDR.TextFont.Size = 9;
                    ISTEKDR.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField101.CalcValue = NewField101.Value;
                    ISTEKDR.CalcValue = @"";
                    return new TTReportObject[] { NewField101,ISTEKDR};
                }

                public override void RunScript()
                {
#region PATIENTSTORY BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((ConsultationFromExternalHospitalReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            ConsultationFromExternalHospital consultationFromExternalHospital = (ConsultationFromExternalHospital)objectContext.GetObject(new Guid(objectID),"ConsultationFromExternalHospital");

            if(consultationFromExternalHospital.ProcedureDoctor!=null)
                this.ISTEKDR.CalcValue =consultationFromExternalHospital.ProcedureDoctor.ShortSignatureBlock;
#endregion PATIENTSTORY BODY_Script
                }
            }

        }

        public PATIENTSTORYGroup PATIENTSTORY;

        public partial class CONSRESULTANDOFFERSGroup : TTReportGroup
        {
            public ConsultationFromExternalHospitalReport MyParentReport
            {
                get { return (ConsultationFromExternalHospitalReport)ParentReport; }
            }

            new public CONSRESULTANDOFFERSGroupBody Body()
            {
                return (CONSRESULTANDOFFERSGroupBody)_body;
            }
            public TTReportField LBLUNIQUEREFNO11 { get {return Body().LBLUNIQUEREFNO11;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public CONSRESULTANDOFFERSGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public CONSRESULTANDOFFERSGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new CONSRESULTANDOFFERSGroupBody(this);
            }

            public partial class CONSRESULTANDOFFERSGroupBody : TTReportSection
            {
                public ConsultationFromExternalHospitalReport MyParentReport
                {
                    get { return (ConsultationFromExternalHospitalReport)ParentReport; }
                }
                
                public TTReportField LBLUNIQUEREFNO11;
                public TTReportField NewField1; 
                public CONSRESULTANDOFFERSGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 96;
                    RepeatCount = 0;
                    
                    LBLUNIQUEREFNO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 3, 206, 70, false);
                    LBLUNIQUEREFNO11.Name = "LBLUNIQUEREFNO11";
                    LBLUNIQUEREFNO11.MultiLine = EvetHayirEnum.ehEvet;
                    LBLUNIQUEREFNO11.WordBreak = EvetHayirEnum.ehEvet;
                    LBLUNIQUEREFNO11.TextFont.Name = "Arial Narrow";
                    LBLUNIQUEREFNO11.TextFont.Size = 9;
                    LBLUNIQUEREFNO11.TextFont.Bold = true;
                    LBLUNIQUEREFNO11.Value = @"Konsültasyonu Yapanın Fikri :

Tavsiyeler ve Karar :









Tarih:                                              Hekim - Kaşe - İmza";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 71, 206, 93, false);
                    NewField1.Name = "NewField1";
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.CharSet = 1;
                    NewField1.Value = @"*** ÖNEMLİ UYARI
         Tarafımızca konsültasyon amacıyla değerlendirilen hastaya konsültasyon kanaati bildirmesi yapılabilecek olan tetkikler ile ilgili XXXXXXmize bilgi verilmesi protokol gereği zorunludur.
         İstenebilecek tetkiklerin tarafımızdan tetkik istem formuna işlenerek yapılması, temin edememesi durumunda tarafınıza konsültasyon dışında bir ödeme yapılmayacağını bildiririz.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LBLUNIQUEREFNO11.CalcValue = LBLUNIQUEREFNO11.Value;
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { LBLUNIQUEREFNO11,NewField1};
                }
            }

        }

        public CONSRESULTANDOFFERSGroup CONSRESULTANDOFFERS;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ConsultationFromExternalHospitalReport()
        {
            part2 = new part2Group(this,"part2");
            MAIN = new MAINGroup(part2,"MAIN");
            PATIENTFOLDER = new PATIENTFOLDERGroup(part2,"PATIENTFOLDER");
            PATIENTSTORY = new PATIENTSTORYGroup(part2,"PATIENTSTORY");
            CONSRESULTANDOFFERS = new CONSRESULTANDOFFERSGroup(part2,"CONSRESULTANDOFFERS");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "ObjectID", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "CONSULTATIONFROMEXTERNALHOSPITALREPORT";
            Caption = "Dış Konsültasyon Formu";
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