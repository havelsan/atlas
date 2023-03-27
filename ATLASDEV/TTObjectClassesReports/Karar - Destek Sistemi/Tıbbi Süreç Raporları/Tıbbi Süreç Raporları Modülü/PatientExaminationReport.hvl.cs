
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
    /// Muayene Sonuç Raporu
    /// </summary>
    public partial class PatientExaminationReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? OBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class part2Group : TTReportGroup
        {
            public PatientExaminationReport MyParentReport
            {
                get { return (PatientExaminationReport)ParentReport; }
            }

            new public part2GroupHeader Header()
            {
                return (part2GroupHeader)_header;
            }

            new public part2GroupFooter Footer()
            {
                return (part2GroupFooter)_footer;
            }

            public TTReportField MASTERRESOURCE { get {return Header().MASTERRESOURCE;} }
            public TTReportField DYERVETARIH { get {return Header().DYERVETARIH;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField LBLUNIQUEREFNO { get {return Header().LBLUNIQUEREFNO;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField REPORTHEADER1 { get {return Header().REPORTHEADER1;} }
            public TTReportField PROTOKOLNO { get {return Header().PROTOKOLNO;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField ACTIONID { get {return Header().ACTIONID;} }
            public TTReportField NewField162 { get {return Header().NewField162;} }
            public TTReportField YATISTARIHI { get {return Header().YATISTARIHI;} }
            public TTReportField lblYatısTarihi { get {return Header().lblYatısTarihi;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField1421 { get {return Header().NewField1421;} }
            public TTReportField lblYatısTarihi1 { get {return Header().lblYatısTarihi1;} }
            public TTReportField SEX { get {return Header().SEX;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField NewField1171 { get {return Header().NewField1171;} }
            public TTReportField DTARIH { get {return Header().DTARIH;} }
            public TTReportField DYER { get {return Header().DYER;} }
            public TTReportField EPISODEID { get {return Header().EPISODEID;} }
            public TTReportField EPISODEOBJECTID { get {return Header().EPISODEOBJECTID;} }
            public TTReportField PREDIAGNOSIS { get {return Header().PREDIAGNOSIS;} }
            public TTReportField NewField183 { get {return Header().NewField183;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportField SECDIAGNOSIS { get {return Header().SECDIAGNOSIS;} }
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
            public TTReportField TIGISLEMNO { get {return Header().TIGISLEMNO;} }
            public TTReportField NewField11421 { get {return Header().NewField11421;} }
            public TTReportField NewField113211 { get {return Header().NewField113211;} }
            public TTReportField DOKTOR { get {return Header().DOKTOR;} }
            public TTReportField NewField1271 { get {return Header().NewField1271;} }
            public TTReportField NewField11251 { get {return Header().NewField11251;} }
            public TTReportField YATTIGIBOLUM { get {return Header().YATTIGIBOLUM;} }
            public TTReportField lblYATTIGIBOLUM { get {return Header().lblYATTIGIBOLUM;} }
            public TTReportField NewField115211 { get {return Header().NewField115211;} }
            public TTReportField CIKISTARIHI { get {return Header().CIKISTARIHI;} }
            public TTReportField lblCıkısTarihi { get {return Header().lblCıkısTarihi;} }
            public TTReportField lblCıkısTarihi1 { get {return Header().lblCıkısTarihi1;} }
            public TTReportField YATISNO { get {return Header().YATISNO;} }
            public TTReportField NewField11911 { get {return Header().NewField11911;} }
            public TTReportField NewField111711 { get {return Header().NewField111711;} }
            public TTReportField KURUM { get {return Header().KURUM;} }
            public TTReportField LBLUNIQUEREFNO1 { get {return Header().LBLUNIQUEREFNO1;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField NewField10 { get {return Footer().NewField10;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportField DIPSIC { get {return Footer().DIPSIC;} }
            public TTReportField ADSOYADDOC { get {return Footer().ADSOYADDOC;} }
            public TTReportField UZMANLIKDAL { get {return Footer().UZMANLIKDAL;} }
            public TTReportField DIPSICLABEL { get {return Footer().DIPSICLABEL;} }
            public TTReportField SINRUT { get {return Footer().SINRUT;} }
            public TTReportField RUTBEONAY { get {return Footer().RUTBEONAY;} }
            public TTReportField SINIFONAY { get {return Footer().SINIFONAY;} }
            public TTReportField UZ { get {return Footer().UZ;} }
            public TTReportField GOREV { get {return Footer().GOREV;} }
            public TTReportField DIPLOMANO { get {return Footer().DIPLOMANO;} }
            public TTReportField SICILKULLAN { get {return Footer().SICILKULLAN;} }
            public TTReportField UNVANKULLAN { get {return Footer().UNVANKULLAN;} }
            public TTReportField UNVAN { get {return Footer().UNVAN;} }
            public TTReportField SICILNO { get {return Footer().SICILNO;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField ISTEKDR { get {return Footer().ISTEKDR;} }
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
                list[0] = new TTReportNqlData<PatientExamination.GetPatientExaminationNQL_Class>("GetPatientExaminationNQL2", PatientExamination.GetPatientExaminationNQL((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.OBJECTID)));
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
                public PatientExaminationReport MyParentReport
                {
                    get { return (PatientExaminationReport)ParentReport; }
                }
                
                public TTReportField MASTERRESOURCE;
                public TTReportField DYERVETARIH;
                public TTReportField NewField19;
                public TTReportField ADSOYAD;
                public TTReportField NewField121;
                public TTReportField NewField141;
                public TTReportField NewField171;
                public TTReportField UNIQUEREFNO;
                public TTReportField LBLUNIQUEREFNO;
                public TTReportField NewField1131;
                public TTReportField XXXXXXBASLIK;
                public TTReportField REPORTHEADER1;
                public TTReportField PROTOKOLNO;
                public TTReportField NewField122;
                public TTReportField ACTIONID;
                public TTReportField NewField162;
                public TTReportField YATISTARIHI;
                public TTReportField lblYatısTarihi;
                public TTReportField NewField1221;
                public TTReportField NewField1421;
                public TTReportField lblYatısTarihi1;
                public TTReportField SEX;
                public TTReportField NewField191;
                public TTReportField NewField1171;
                public TTReportField DTARIH;
                public TTReportField DYER;
                public TTReportField EPISODEID;
                public TTReportField EPISODEOBJECTID;
                public TTReportField PREDIAGNOSIS;
                public TTReportField NewField183;
                public TTReportShape NewLine13;
                public TTReportField SECDIAGNOSIS;
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
                public TTReportField TIGISLEMNO;
                public TTReportField NewField11421;
                public TTReportField NewField113211;
                public TTReportField DOKTOR;
                public TTReportField NewField1271;
                public TTReportField NewField11251;
                public TTReportField YATTIGIBOLUM;
                public TTReportField lblYATTIGIBOLUM;
                public TTReportField NewField115211;
                public TTReportField CIKISTARIHI;
                public TTReportField lblCıkısTarihi;
                public TTReportField lblCıkısTarihi1;
                public TTReportField YATISNO;
                public TTReportField NewField11911;
                public TTReportField NewField111711;
                public TTReportField KURUM;
                public TTReportField LBLUNIQUEREFNO1;
                public TTReportField NewField11311;
                public TTReportField LOGO; 
                public part2GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 130;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MASTERRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 43, 171, 48, false);
                    MASTERRESOURCE.Name = "MASTERRESOURCE";
                    MASTERRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MASTERRESOURCE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MASTERRESOURCE.TextFont.Name = "Arial Narrow";
                    MASTERRESOURCE.TextFont.Size = 11;
                    MASTERRESOURCE.TextFont.Bold = true;
                    MASTERRESOURCE.Value = @"{#MASTERRESOURCENAME#}";

                    DYERVETARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 80, 118, 85, false);
                    DYERVETARIH.Name = "DYERVETARIH";
                    DYERVETARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERVETARIH.TextFont.Name = "Arial Narrow";
                    DYERVETARIH.TextFont.Size = 9;
                    DYERVETARIH.Value = @"{%DYER%} / {%DTARIH%}";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 80, 39, 85, false);
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

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 80, 41, 85, false);
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

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 10, 171, 36, false);
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

                    REPORTHEADER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 37, 171, 43, false);
                    REPORTHEADER1.Name = "REPORTHEADER1";
                    REPORTHEADER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER1.TextFont.Name = "Arial Narrow";
                    REPORTHEADER1.TextFont.Size = 15;
                    REPORTHEADER1.TextFont.Bold = true;
                    REPORTHEADER1.Value = @"DOKTOR MUAYENE FORMU";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 75, 78, 80, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.Name = "Arial Narrow";
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.Value = @"{#PROTOCOLNO#}";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 75, 39, 80, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Name = "Arial Narrow";
                    NewField122.TextFont.Size = 9;
                    NewField122.TextFont.Bold = true;
                    NewField122.Value = @"Protokol No";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 52, 206, 57, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.TextFont.Name = "Arial Narrow";
                    ACTIONID.TextFont.Size = 9;
                    ACTIONID.Value = @"{#ACTIONID#}";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 52, 177, 57, false);
                    NewField162.Name = "NewField162";
                    NewField162.TextFont.Name = "Arial Narrow";
                    NewField162.TextFont.Size = 9;
                    NewField162.TextFont.Bold = true;
                    NewField162.Value = @"İşlem No";

                    YATISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 98, 178, 103, false);
                    YATISTARIHI.Name = "YATISTARIHI";
                    YATISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATISTARIHI.TextFormat = @"Short Date";
                    YATISTARIHI.TextFont.Name = "Arial Narrow";
                    YATISTARIHI.TextFont.Size = 9;
                    YATISTARIHI.Value = @"";

                    lblYatısTarihi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 98, 148, 103, false);
                    lblYatısTarihi.Name = "lblYatısTarihi";
                    lblYatısTarihi.TextFont.Name = "Arial Narrow";
                    lblYatısTarihi.TextFont.Size = 9;
                    lblYatısTarihi.TextFont.Bold = true;
                    lblYatısTarihi.Value = @"Yatış Tarihi";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 52, 179, 57, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1221.TextFont.Name = "Arial Narrow";
                    NewField1221.TextFont.Size = 9;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.Value = @":";

                    NewField1421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 75, 41, 80, false);
                    NewField1421.Name = "NewField1421";
                    NewField1421.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1421.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1421.TextFont.Name = "Arial Narrow";
                    NewField1421.TextFont.Size = 9;
                    NewField1421.TextFont.Bold = true;
                    NewField1421.Value = @":";

                    lblYatısTarihi1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 98, 150, 103, false);
                    lblYatısTarihi1.Name = "lblYatısTarihi1";
                    lblYatısTarihi1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblYatısTarihi1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lblYatısTarihi1.TextFont.Name = "Arial Narrow";
                    lblYatısTarihi1.TextFont.Size = 9;
                    lblYatısTarihi1.TextFont.Bold = true;
                    lblYatısTarihi1.Value = @":";

                    SEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 70, 178, 75, false);
                    SEX.Name = "SEX";
                    SEX.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEX.TextFont.Name = "Arial Narrow";
                    SEX.TextFont.Size = 9;
                    SEX.Value = @"{#CINSIYET#}";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 70, 148, 75, false);
                    NewField191.Name = "NewField191";
                    NewField191.TextFont.Name = "Arial Narrow";
                    NewField191.TextFont.Size = 9;
                    NewField191.TextFont.Bold = true;
                    NewField191.Value = @"Cinsiyeti";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 70, 150, 75, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.TextFont.Name = "Arial Narrow";
                    NewField1171.TextFont.Size = 9;
                    NewField1171.TextFont.Bold = true;
                    NewField1171.Value = @":";

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
                    EPISODEID.ObjectDefName = "PatientExamination";
                    EPISODEID.DataMember = "EPISODE.ID";
                    EPISODEID.TextFont.Name = "Arial Narrow";
                    EPISODEID.TextFont.Size = 9;
                    EPISODEID.Value = @"{@OBJECTID@}";

                    EPISODEOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 51, 269, 56, false);
                    EPISODEOBJECTID.Name = "EPISODEOBJECTID";
                    EPISODEOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEOBJECTID.TextFont.Name = "Arial Narrow";
                    EPISODEOBJECTID.TextFont.Size = 9;
                    EPISODEOBJECTID.Value = @"{#EPISODEOBJECTID#}";

                    PREDIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 119, 206, 128, false);
                    PREDIAGNOSIS.Name = "PREDIAGNOSIS";
                    PREDIAGNOSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PREDIAGNOSIS.MultiLine = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.NoClip = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.WordBreak = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.ExpandTabs = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.TextFont.Name = "Arial Narrow";
                    PREDIAGNOSIS.TextFont.Size = 9;
                    PREDIAGNOSIS.Value = @"";

                    NewField183 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 114, 57, 118, false);
                    NewField183.Name = "NewField183";
                    NewField183.TextFont.Name = "Arial Narrow";
                    NewField183.TextFont.Size = 9;
                    NewField183.TextFont.Bold = true;
                    NewField183.Value = @"Ön Tanı";

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 118, 57, 118, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    SECDIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 66, 279, 75, false);
                    SECDIAGNOSIS.Name = "SECDIAGNOSIS";
                    SECDIAGNOSIS.Visible = EvetHayirEnum.ehHayir;
                    SECDIAGNOSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SECDIAGNOSIS.MultiLine = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.NoClip = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.WordBreak = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.ExpandTabs = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.TextFont.Name = "Arial Narrow";
                    SECDIAGNOSIS.TextFont.Size = 9;
                    SECDIAGNOSIS.Value = @"";

                    AGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 65, 118, 70, false);
                    AGE.Name = "AGE";
                    AGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGE.TextFont.Name = "Arial Narrow";
                    AGE.TextFont.Size = 9;
                    AGE.Value = @"";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 65, 97, 70, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.TextFont.Name = "Arial Narrow";
                    NewField1191.TextFont.Size = 9;
                    NewField1191.TextFont.Bold = true;
                    NewField1191.Value = @"Hasta Yaşı";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 65, 99, 70, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.TextFont.Name = "Arial Narrow";
                    NewField11711.TextFont.Size = 9;
                    NewField11711.TextFont.Bold = true;
                    NewField11711.Value = @":";

                    LBLBASLIK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 52, 56, 57, false);
                    LBLBASLIK2.Name = "LBLBASLIK2";
                    LBLBASLIK2.TextFont.Name = "Arial Narrow";
                    LBLBASLIK2.TextFont.Bold = true;
                    LBLBASLIK2.Value = @"Hastanın Özlük Bilgileri";

                    LBLBASLIK12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 52, 83, 57, false);
                    LBLBASLIK12.Name = "LBLBASLIK12";
                    LBLBASLIK12.TextFont.Name = "Arial Narrow";
                    LBLBASLIK12.TextFont.Size = 9;
                    LBLBASLIK12.TextFont.Bold = true;
                    LBLBASLIK12.Value = @"Ayaktan Takip No";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 52, 85, 57, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11221.TextFont.Name = "Arial Narrow";
                    NewField11221.TextFont.Size = 9;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.Value = @":";

                    AYAKTANTAKIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 52, 104, 57, false);
                    AYAKTANTAKIPNO.Name = "AYAKTANTAKIPNO";
                    AYAKTANTAKIPNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    AYAKTANTAKIPNO.TextFont.Name = "Arial Narrow";
                    AYAKTANTAKIPNO.TextFont.Size = 9;
                    AYAKTANTAKIPNO.Value = @"";

                    LBLBASLIK121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 52, 130, 57, false);
                    LBLBASLIK121.Name = "LBLBASLIK121";
                    LBLBASLIK121.TextFont.Name = "Arial Narrow";
                    LBLBASLIK121.TextFont.Size = 9;
                    LBLBASLIK121.TextFont.Bold = true;
                    LBLBASLIK121.Value = @"Yatan Takip No";

                    NewField112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 52, 132, 57, false);
                    NewField112211.Name = "NewField112211";
                    NewField112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112211.TextFont.Name = "Arial Narrow";
                    NewField112211.TextFont.Size = 9;
                    NewField112211.TextFont.Bold = true;
                    NewField112211.Value = @":";

                    YATANTAKIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 52, 151, 57, false);
                    YATANTAKIPNO.Name = "YATANTAKIPNO";
                    YATANTAKIPNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATANTAKIPNO.TextFont.Name = "Arial Narrow";
                    YATANTAKIPNO.TextFont.Size = 9;
                    YATANTAKIPNO.Value = @"";

                    TELEFON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 75, 178, 80, false);
                    TELEFON.Name = "TELEFON";
                    TELEFON.FieldType = ReportFieldTypeEnum.ftVariable;
                    TELEFON.TextFont.Name = "Arial Narrow";
                    TELEFON.TextFont.Size = 9;
                    TELEFON.Value = @"{#MOBILEPHONE#}";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 75, 148, 80, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.TextFont.Name = "Arial Narrow";
                    NewField1241.TextFont.Size = 9;
                    NewField1241.TextFont.Bold = true;
                    NewField1241.Value = @"Telefonu";

                    NewField11231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 75, 150, 80, false);
                    NewField11231.Name = "NewField11231";
                    NewField11231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11231.TextFont.Name = "Arial Narrow";
                    NewField11231.TextFont.Size = 9;
                    NewField11231.TextFont.Bold = true;
                    NewField11231.Value = @":";

                    ADRES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 85, 118, 97, false);
                    ADRES.Name = "ADRES";
                    ADRES.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRES.MultiLine = EvetHayirEnum.ehEvet;
                    ADRES.WordBreak = EvetHayirEnum.ehEvet;
                    ADRES.TextFont.Name = "Arial Narrow";
                    ADRES.TextFont.Size = 9;
                    ADRES.Value = @"{#HOMEADDRESS#}";

                    NewField192 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 85, 39, 90, false);
                    NewField192.Name = "NewField192";
                    NewField192.TextFont.Name = "Arial Narrow";
                    NewField192.TextFont.Size = 9;
                    NewField192.TextFont.Bold = true;
                    NewField192.Value = @"Adresi";

                    NewField1172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 85, 41, 90, false);
                    NewField1172.Name = "NewField1172";
                    NewField1172.TextFont.Name = "Arial Narrow";
                    NewField1172.TextFont.Size = 9;
                    NewField1172.TextFont.Bold = true;
                    NewField1172.Value = @":";

                    TIGISLEMNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 80, 178, 85, false);
                    TIGISLEMNO.Name = "TIGISLEMNO";
                    TIGISLEMNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TIGISLEMNO.TextFont.Name = "Arial Narrow";
                    TIGISLEMNO.TextFont.Size = 9;
                    TIGISLEMNO.Value = @"";

                    NewField11421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 80, 148, 85, false);
                    NewField11421.Name = "NewField11421";
                    NewField11421.TextFont.Name = "Arial Narrow";
                    NewField11421.TextFont.Size = 9;
                    NewField11421.TextFont.Bold = true;
                    NewField11421.Value = @"Tig İşlem No";

                    NewField113211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 80, 150, 85, false);
                    NewField113211.Name = "NewField113211";
                    NewField113211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113211.TextFont.Name = "Arial Narrow";
                    NewField113211.TextFont.Size = 9;
                    NewField113211.TextFont.Bold = true;
                    NewField113211.Value = @":";

                    DOKTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 65, 206, 70, false);
                    DOKTOR.Name = "DOKTOR";
                    DOKTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOKTOR.TextFormat = @"g";
                    DOKTOR.TextFont.Name = "Arial Narrow";
                    DOKTOR.TextFont.Size = 9;
                    DOKTOR.Value = @"{#PROCEDUREDOCTORNAME#}";

                    NewField1271 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 65, 148, 70, false);
                    NewField1271.Name = "NewField1271";
                    NewField1271.TextFont.Name = "Arial Narrow";
                    NewField1271.TextFont.Size = 9;
                    NewField1271.TextFont.Bold = true;
                    NewField1271.Value = @"Doktoru";

                    NewField11251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 65, 150, 70, false);
                    NewField11251.Name = "NewField11251";
                    NewField11251.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11251.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11251.TextFont.Name = "Arial Narrow";
                    NewField11251.TextFont.Size = 9;
                    NewField11251.TextFont.Bold = true;
                    NewField11251.Value = @":";

                    YATTIGIBOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 85, 206, 98, false);
                    YATTIGIBOLUM.Name = "YATTIGIBOLUM";
                    YATTIGIBOLUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATTIGIBOLUM.MultiLine = EvetHayirEnum.ehEvet;
                    YATTIGIBOLUM.WordBreak = EvetHayirEnum.ehEvet;
                    YATTIGIBOLUM.TextFont.Name = "Arial Narrow";
                    YATTIGIBOLUM.TextFont.Size = 9;
                    YATTIGIBOLUM.Value = @"";

                    lblYATTIGIBOLUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 85, 148, 90, false);
                    lblYATTIGIBOLUM.Name = "lblYATTIGIBOLUM";
                    lblYATTIGIBOLUM.TextFont.Name = "Arial Narrow";
                    lblYATTIGIBOLUM.TextFont.Size = 9;
                    lblYATTIGIBOLUM.TextFont.Bold = true;
                    lblYATTIGIBOLUM.Value = @"Yattığı Bölüm";

                    NewField115211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 85, 150, 90, false);
                    NewField115211.Name = "NewField115211";
                    NewField115211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField115211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField115211.TextFont.Name = "Arial Narrow";
                    NewField115211.TextFont.Size = 9;
                    NewField115211.TextFont.Bold = true;
                    NewField115211.Value = @":";

                    CIKISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 103, 178, 108, false);
                    CIKISTARIHI.Name = "CIKISTARIHI";
                    CIKISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    CIKISTARIHI.TextFormat = @"Short Date";
                    CIKISTARIHI.TextFont.Name = "Arial Narrow";
                    CIKISTARIHI.TextFont.Size = 9;
                    CIKISTARIHI.Value = @"";

                    lblCıkısTarihi = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 103, 148, 108, false);
                    lblCıkısTarihi.Name = "lblCıkısTarihi";
                    lblCıkısTarihi.TextFont.Name = "Arial Narrow";
                    lblCıkısTarihi.TextFont.Size = 9;
                    lblCıkısTarihi.TextFont.Bold = true;
                    lblCıkısTarihi.Value = @"Çıkış Tarihi";

                    lblCıkısTarihi1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 103, 150, 108, false);
                    lblCıkısTarihi1.Name = "lblCıkısTarihi1";
                    lblCıkısTarihi1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblCıkısTarihi1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    lblCıkısTarihi1.TextFont.Name = "Arial Narrow";
                    lblCıkısTarihi1.TextFont.Size = 9;
                    lblCıkısTarihi1.TextFont.Bold = true;
                    lblCıkısTarihi1.Value = @":";

                    YATISNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 75, 118, 80, false);
                    YATISNO.Name = "YATISNO";
                    YATISNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATISNO.TextFont.Name = "Arial Narrow";
                    YATISNO.TextFont.Size = 9;
                    YATISNO.Value = @"";

                    NewField11911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 75, 97, 80, false);
                    NewField11911.Name = "NewField11911";
                    NewField11911.TextFont.Name = "Arial Narrow";
                    NewField11911.TextFont.Size = 9;
                    NewField11911.TextFont.Bold = true;
                    NewField11911.Value = @"Yatış No";

                    NewField111711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 75, 99, 80, false);
                    NewField111711.Name = "NewField111711";
                    NewField111711.TextFont.Name = "Arial Narrow";
                    NewField111711.TextFont.Size = 9;
                    NewField111711.TextFont.Bold = true;
                    NewField111711.Value = @":";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 97, 118, 109, false);
                    KURUM.Name = "KURUM";
                    KURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUM.MultiLine = EvetHayirEnum.ehEvet;
                    KURUM.WordBreak = EvetHayirEnum.ehEvet;
                    KURUM.TextFont.Name = "Arial Narrow";
                    KURUM.TextFont.Size = 9;
                    KURUM.Value = @"{#PAYERNAME#}";

                    LBLUNIQUEREFNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 97, 39, 102, false);
                    LBLUNIQUEREFNO1.Name = "LBLUNIQUEREFNO1";
                    LBLUNIQUEREFNO1.TextFont.Name = "Arial Narrow";
                    LBLUNIQUEREFNO1.TextFont.Size = 9;
                    LBLUNIQUEREFNO1.TextFont.Bold = true;
                    LBLUNIQUEREFNO1.Value = @"Kurum Adı";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 97, 41, 102, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311.TextFont.Name = "Arial Narrow";
                    NewField11311.TextFont.Size = 9;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.Value = @":";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 40, 42, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.CharSet = 1;
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PatientExamination.GetPatientExaminationNQL_Class dataset_GetPatientExaminationNQL2 = ParentGroup.rsGroup.GetCurrentRecord<PatientExamination.GetPatientExaminationNQL_Class>(0);
                    MASTERRESOURCE.CalcValue = (dataset_GetPatientExaminationNQL2 != null ? Globals.ToStringCore(dataset_GetPatientExaminationNQL2.Masterresourcename) : "");
                    DYER.CalcValue = (dataset_GetPatientExaminationNQL2 != null ? Globals.ToStringCore(dataset_GetPatientExaminationNQL2.Cityname) : "");
                    DTARIH.CalcValue = (dataset_GetPatientExaminationNQL2 != null ? Globals.ToStringCore(dataset_GetPatientExaminationNQL2.BirthDate) : "");
                    DYERVETARIH.CalcValue = MyParentReport.part2.DYER.CalcValue + @" / " + MyParentReport.part2.DTARIH.FormattedValue;
                    NewField19.CalcValue = NewField19.Value;
                    ADSOYAD.CalcValue = (dataset_GetPatientExaminationNQL2 != null ? Globals.ToStringCore(dataset_GetPatientExaminationNQL2.Name) : "") + @" " + (dataset_GetPatientExaminationNQL2 != null ? Globals.ToStringCore(dataset_GetPatientExaminationNQL2.Surname) : "");
                    NewField121.CalcValue = NewField121.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField171.CalcValue = NewField171.Value;
                    UNIQUEREFNO.CalcValue = @"";
                    LBLUNIQUEREFNO.CalcValue = LBLUNIQUEREFNO.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    REPORTHEADER1.CalcValue = REPORTHEADER1.Value;
                    PROTOKOLNO.CalcValue = (dataset_GetPatientExaminationNQL2 != null ? Globals.ToStringCore(dataset_GetPatientExaminationNQL2.ProtocolNo) : "");
                    NewField122.CalcValue = NewField122.Value;
                    ACTIONID.CalcValue = (dataset_GetPatientExaminationNQL2 != null ? Globals.ToStringCore(dataset_GetPatientExaminationNQL2.Actionid) : "");
                    NewField162.CalcValue = NewField162.Value;
                    YATISTARIHI.CalcValue = @"";
                    lblYatısTarihi.CalcValue = lblYatısTarihi.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1421.CalcValue = NewField1421.Value;
                    lblYatısTarihi1.CalcValue = lblYatısTarihi1.Value;
                    SEX.CalcValue = (dataset_GetPatientExaminationNQL2 != null ? Globals.ToStringCore(dataset_GetPatientExaminationNQL2.Cinsiyet) : "");
                    NewField191.CalcValue = NewField191.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    EPISODEID.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    EPISODEID.PostFieldValueCalculation();
                    EPISODEOBJECTID.CalcValue = (dataset_GetPatientExaminationNQL2 != null ? Globals.ToStringCore(dataset_GetPatientExaminationNQL2.Episodeobjectid) : "");
                    PREDIAGNOSIS.CalcValue = @"";
                    NewField183.CalcValue = NewField183.Value;
                    SECDIAGNOSIS.CalcValue = @"";
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
                    TELEFON.CalcValue = (dataset_GetPatientExaminationNQL2 != null ? Globals.ToStringCore(dataset_GetPatientExaminationNQL2.MobilePhone) : "");
                    NewField1241.CalcValue = NewField1241.Value;
                    NewField11231.CalcValue = NewField11231.Value;
                    ADRES.CalcValue = (dataset_GetPatientExaminationNQL2 != null ? Globals.ToStringCore(dataset_GetPatientExaminationNQL2.HomeAddress) : "");
                    NewField192.CalcValue = NewField192.Value;
                    NewField1172.CalcValue = NewField1172.Value;
                    TIGISLEMNO.CalcValue = @"";
                    NewField11421.CalcValue = NewField11421.Value;
                    NewField113211.CalcValue = NewField113211.Value;
                    DOKTOR.CalcValue = (dataset_GetPatientExaminationNQL2 != null ? Globals.ToStringCore(dataset_GetPatientExaminationNQL2.Proceduredoctorname) : "");
                    NewField1271.CalcValue = NewField1271.Value;
                    NewField11251.CalcValue = NewField11251.Value;
                    YATTIGIBOLUM.CalcValue = @"";
                    lblYATTIGIBOLUM.CalcValue = lblYATTIGIBOLUM.Value;
                    NewField115211.CalcValue = NewField115211.Value;
                    CIKISTARIHI.CalcValue = @"";
                    lblCıkısTarihi.CalcValue = lblCıkısTarihi.Value;
                    lblCıkısTarihi1.CalcValue = lblCıkısTarihi1.Value;
                    YATISNO.CalcValue = @"";
                    NewField11911.CalcValue = NewField11911.Value;
                    NewField111711.CalcValue = NewField111711.Value;
                    KURUM.CalcValue = (dataset_GetPatientExaminationNQL2 != null ? Globals.ToStringCore(dataset_GetPatientExaminationNQL2.Payername) : "");
                    LBLUNIQUEREFNO1.CalcValue = LBLUNIQUEREFNO1.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    LOGO.CalcValue = @"";
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { MASTERRESOURCE,DYER,DTARIH,DYERVETARIH,NewField19,ADSOYAD,NewField121,NewField141,NewField171,UNIQUEREFNO,LBLUNIQUEREFNO,NewField1131,REPORTHEADER1,PROTOKOLNO,NewField122,ACTIONID,NewField162,YATISTARIHI,lblYatısTarihi,NewField1221,NewField1421,lblYatısTarihi1,SEX,NewField191,NewField1171,EPISODEID,EPISODEOBJECTID,PREDIAGNOSIS,NewField183,SECDIAGNOSIS,AGE,NewField1191,NewField11711,LBLBASLIK2,LBLBASLIK12,NewField11221,AYAKTANTAKIPNO,LBLBASLIK121,NewField112211,YATANTAKIPNO,TELEFON,NewField1241,NewField11231,ADRES,NewField192,NewField1172,TIGISLEMNO,NewField11421,NewField113211,DOKTOR,NewField1271,NewField11251,YATTIGIBOLUM,lblYATTIGIBOLUM,NewField115211,CIKISTARIHI,lblCıkısTarihi,lblCıkısTarihi1,YATISNO,NewField11911,NewField111711,KURUM,LBLUNIQUEREFNO1,NewField11311,LOGO,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region PART2 HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
            int cnt = 1;
            TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((PatientExaminationReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            PatientExamination patientExamination = (PatientExamination)objectContext.GetObject(new Guid(objectID),"PatientExamination");
            
            this.AYAKTANTAKIPNO.CalcValue = patientExamination.SubEpisode.SubEpisodeProtocols[0].MedulaTakipNo;
            if (patientExamination==null)
                throw new Exception("Rapor, Hasta Muayenesi modülü üzerinden alınmalıdır.");
            
            Episode episode = patientExamination.Episode;
            
            this.PREDIAGNOSIS.CalcValue = "";
            BindingList<DiagnosisGrid.GetPreDiagnosisByEpisodeAction_Class> preDiagnosis = null;
            preDiagnosis = DiagnosisGrid.GetPreDiagnosisByEpisodeAction(patientExamination.ObjectID.ToString());
            foreach(DiagnosisGrid.GetPreDiagnosisByEpisodeAction_Class preDiagnosisGrid in preDiagnosis)
            {
                this.PREDIAGNOSIS.CalcValue += cnt + ". " + preDiagnosisGrid.Code + " " + preDiagnosisGrid.Diagnosename;
                this.PREDIAGNOSIS.CalcValue += "\r\n";
                cnt++;
            }
            
            cnt = 1;
            this.SECDIAGNOSIS.CalcValue = "";
            BindingList<DiagnosisGrid.GetSecDiagnosisByEpisodeAction_Class> secDiagnosis = null;
            secDiagnosis = DiagnosisGrid.GetSecDiagnosisByEpisodeAction(patientExamination.ObjectID.ToString());
            foreach(DiagnosisGrid.GetSecDiagnosisByEpisodeAction_Class secDiagnosisGrid in secDiagnosis)
            {
                this.SECDIAGNOSIS.CalcValue += cnt + ". " + secDiagnosisGrid.Code + " " + secDiagnosisGrid.Diagnosename;
                this.SECDIAGNOSIS.CalcValue += "\r\n";
                cnt++;
            }
            
            if (patientExamination.Episode != null && patientExamination.Episode.Patient != null )
            {
                if(patientExamination.Episode.Patient.Foreign == true)
                {
                    this.LBLUNIQUEREFNO.CalcValue = "Kimlik/Sigorta No (Yabancı Hasta)";
                }
                else
                {
                    this.LBLUNIQUEREFNO.CalcValue = "T.C. Kimlik No";
                }
                this.UNIQUEREFNO.CalcValue = patientExamination.Episode.Patient.RefNo;
            }
            
            this.AGE.CalcValue = episode.Patient.Age.Value.ToString();
            
            if (episode.LastSubEpisode != null && episode.LastSubEpisode.PatientStatus == SubEpisodeStatusEnum.Inpatient)
            {
                SubEpisode lastSubEpisode = episode.LastSubEpisode;
                this.YATISNO.CalcValue = lastSubEpisode.ProtocolNo;
                if (lastSubEpisode.InpatientAdmission != null)
                {
                    if (lastSubEpisode.InpatientAdmission.HospitalInPatientDate.HasValue)
                        this.YATISTARIHI.CalcValue = lastSubEpisode.InpatientAdmission.HospitalInPatientDate.Value.ToShortDateString();
                    if (lastSubEpisode.InpatientAdmission.HospitalDischargeDate.HasValue)
                        this.CIKISTARIHI.CalcValue = lastSubEpisode.InpatientAdmission.HospitalDischargeDate.Value.ToShortDateString();
                    if (lastSubEpisode.StarterEpisodeAction is InPatientTreatmentClinicApplication)
                        this.YATTIGIBOLUM.CalcValue = lastSubEpisode.StarterEpisodeAction.MasterResource.Name;
                }
               
                SubEpisodeProtocol sep = episode.GetLastSGKSEP();
                if (sep != null)
                    this.YATANTAKIPNO.CalcValue = sep.MedulaTakipNo;
            }
             else
                {
                    this.YATISTARIHI.Visible = EvetHayirEnum.ehHayir;
                    this.CIKISTARIHI.Visible = EvetHayirEnum.ehHayir;
                    this.lblYatısTarihi.Visible = EvetHayirEnum.ehHayir;
                    this.lblCıkısTarihi.Visible = EvetHayirEnum.ehHayir;
                    this.lblYatısTarihi1.Visible = EvetHayirEnum.ehHayir;
                    this.lblCıkısTarihi1.Visible = EvetHayirEnum.ehHayir;
                    this.lblYATTIGIBOLUM.CalcValue = "Muayene Tarihi";
                     if (patientExamination.ProcessDate.HasValue)
                    this.YATTIGIBOLUM.CalcValue = patientExamination.ProcessDate.Value.ToShortDateString();
                }
#endregion PART2 HEADER_Script
                }
            }
            public partial class part2GroupFooter : TTReportSection
            {
                public PatientExaminationReport MyParentReport
                {
                    get { return (PatientExaminationReport)ParentReport; }
                }
                
                public TTReportField NewField10;
                public TTReportShape NewLine12;
                public TTReportField DIPSIC;
                public TTReportField ADSOYADDOC;
                public TTReportField UZMANLIKDAL;
                public TTReportField DIPSICLABEL;
                public TTReportField SINRUT;
                public TTReportField RUTBEONAY;
                public TTReportField SINIFONAY;
                public TTReportField UZ;
                public TTReportField GOREV;
                public TTReportField DIPLOMANO;
                public TTReportField SICILKULLAN;
                public TTReportField UNVANKULLAN;
                public TTReportField UNVAN;
                public TTReportField SICILNO;
                public TTReportField PrintDate;
                public TTReportField PageNumber;
                public TTReportField ISTEKDR; 
                public part2GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 35;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 3, 83, 8, false);
                    NewField10.Name = "NewField10";
                    NewField10.TextFont.Name = "Arial Narrow";
                    NewField10.TextFont.Size = 9;
                    NewField10.TextFont.Bold = true;
                    NewField10.Value = @"Muayeneyi Yapan Tabip";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 2, 206, 2, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    DIPSIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 24, 199, 28, false);
                    DIPSIC.Name = "DIPSIC";
                    DIPSIC.Visible = EvetHayirEnum.ehHayir;
                    DIPSIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSIC.TextFont.Name = "Arial Narrow";
                    DIPSIC.TextFont.Size = 9;
                    DIPSIC.Value = @"";

                    ADSOYADDOC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 16, 199, 20, false);
                    ADSOYADDOC.Name = "ADSOYADDOC";
                    ADSOYADDOC.Visible = EvetHayirEnum.ehHayir;
                    ADSOYADDOC.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC.TextFont.Name = "Arial Narrow";
                    ADSOYADDOC.TextFont.Size = 9;
                    ADSOYADDOC.Value = @"{#PROCEDUREDOCTORNAME#}";

                    UZMANLIKDAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 9, 202, 13, false);
                    UZMANLIKDAL.Name = "UZMANLIKDAL";
                    UZMANLIKDAL.Visible = EvetHayirEnum.ehHayir;
                    UZMANLIKDAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIKDAL.MultiLine = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.NoClip = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.WordBreak = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.TextFont.Name = "Arial Narrow";
                    UZMANLIKDAL.TextFont.Size = 9;
                    UZMANLIKDAL.Value = @"{#DOCSPECIALITY#}";

                    DIPSICLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 20, 189, 24, false);
                    DIPSICLABEL.Name = "DIPSICLABEL";
                    DIPSICLABEL.Visible = EvetHayirEnum.ehHayir;
                    DIPSICLABEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSICLABEL.TextFont.Name = "Arial Narrow";
                    DIPSICLABEL.TextFont.Size = 9;
                    DIPSICLABEL.Value = @"DIPLOMASICIL";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 20, 199, 24, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.Visible = EvetHayirEnum.ehHayir;
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.TextFont.Name = "Arial Narrow";
                    SINRUT.TextFont.Size = 9;
                    SINRUT.Value = @"";

                    RUTBEONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 13, 149, 17, false);
                    RUTBEONAY.Name = "RUTBEONAY";
                    RUTBEONAY.Visible = EvetHayirEnum.ehHayir;
                    RUTBEONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBEONAY.MultiLine = EvetHayirEnum.ehEvet;
                    RUTBEONAY.TextFont.Name = "Arial Narrow";
                    RUTBEONAY.TextFont.Size = 9;
                    RUTBEONAY.Value = @"";

                    SINIFONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 8, 175, 13, false);
                    SINIFONAY.Name = "SINIFONAY";
                    SINIFONAY.Visible = EvetHayirEnum.ehHayir;
                    SINIFONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFONAY.TextFont.Name = "Arial Narrow";
                    SINIFONAY.TextFont.Size = 9;
                    SINIFONAY.Value = @"";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 28, 199, 32, false);
                    UZ.Name = "UZ";
                    UZ.Visible = EvetHayirEnum.ehHayir;
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.TextFont.Name = "Arial Narrow";
                    UZ.TextFont.Size = 9;
                    UZ.Value = @"{%UZMANLIKDAL%}";

                    GOREV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 8, 149, 13, false);
                    GOREV.Name = "GOREV";
                    GOREV.Visible = EvetHayirEnum.ehHayir;
                    GOREV.FieldType = ReportFieldTypeEnum.ftVariable;
                    GOREV.TextFont.Name = "Arial Narrow";
                    GOREV.TextFont.Size = 9;
                    GOREV.Value = @"{#DOCWORK#}";

                    DIPLOMANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 17, 203, 21, false);
                    DIPLOMANO.Name = "DIPLOMANO";
                    DIPLOMANO.Visible = EvetHayirEnum.ehHayir;
                    DIPLOMANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMANO.TextFont.Name = "Arial Narrow";
                    DIPLOMANO.TextFont.Size = 9;
                    DIPLOMANO.Value = @"{#DOCDIPLOMANO#}";

                    SICILKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 13, 202, 17, false);
                    SICILKULLAN.Name = "SICILKULLAN";
                    SICILKULLAN.Visible = EvetHayirEnum.ehHayir;
                    SICILKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    SICILKULLAN.TextFont.Name = "Arial Narrow";
                    SICILKULLAN.TextFont.Size = 9;
                    SICILKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SICILKULLAN"", """")";

                    UNVANKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 17, 149, 21, false);
                    UNVANKULLAN.Name = "UNVANKULLAN";
                    UNVANKULLAN.Visible = EvetHayirEnum.ehHayir;
                    UNVANKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    UNVANKULLAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.TextFont.Name = "Arial Narrow";
                    UNVANKULLAN.TextFont.Size = 9;
                    UNVANKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""UNVANKULLAN"", """")";

                    UNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 13, 175, 18, false);
                    UNVAN.Name = "UNVAN";
                    UNVAN.Visible = EvetHayirEnum.ehHayir;
                    UNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNVAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVAN.TextFont.Name = "Arial Narrow";
                    UNVAN.TextFont.Size = 9;
                    UNVAN.Value = @"{#DOCTITLE#}";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 18, 176, 22, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.Visible = EvetHayirEnum.ehHayir;
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.TextFont.Name = "Arial Narrow";
                    SICILNO.TextFont.Size = 9;
                    SICILNO.Value = @"{#DOCEMPLOYMENTRECORDID#}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 2, 207, 7, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PrintDate.TextFont.Name = "Arial Narrow";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.Value = @"{@printdate@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 29, 120, 34, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PageNumber.TextFont.Name = "Arial Narrow";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                    ISTEKDR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 83, 28, false);
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
                    PatientExamination.GetPatientExaminationNQL_Class dataset_GetPatientExaminationNQL2 = ParentGroup.rsGroup.GetCurrentRecord<PatientExamination.GetPatientExaminationNQL_Class>(0);
                    NewField10.CalcValue = NewField10.Value;
                    DIPSIC.CalcValue = @"";
                    ADSOYADDOC.CalcValue = (dataset_GetPatientExaminationNQL2 != null ? Globals.ToStringCore(dataset_GetPatientExaminationNQL2.Proceduredoctorname) : "");
                    UZMANLIKDAL.CalcValue = (dataset_GetPatientExaminationNQL2 != null ? Globals.ToStringCore(dataset_GetPatientExaminationNQL2.Docspeciality) : "");
                    DIPSICLABEL.CalcValue = @"DIPLOMASICIL";
                    SINRUT.CalcValue = @"";
                    RUTBEONAY.CalcValue = @"";
                    SINIFONAY.CalcValue = @"";
                    UZ.CalcValue = MyParentReport.part2.UZMANLIKDAL.CalcValue;
                    GOREV.CalcValue = (dataset_GetPatientExaminationNQL2 != null ? Globals.ToStringCore(dataset_GetPatientExaminationNQL2.Docwork) : "");
                    DIPLOMANO.CalcValue = (dataset_GetPatientExaminationNQL2 != null ? Globals.ToStringCore(dataset_GetPatientExaminationNQL2.Docdiplomano) : "");
                    UNVAN.CalcValue = (dataset_GetPatientExaminationNQL2 != null ? Globals.ToStringCore(dataset_GetPatientExaminationNQL2.Doctitle) : "");
                    SICILNO.CalcValue = (dataset_GetPatientExaminationNQL2 != null ? Globals.ToStringCore(dataset_GetPatientExaminationNQL2.Docemploymentrecordid) : "");
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    ISTEKDR.CalcValue = @"";
                    SICILKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "");
                    UNVANKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "");
                    return new TTReportObject[] { NewField10,DIPSIC,ADSOYADDOC,UZMANLIKDAL,DIPSICLABEL,SINRUT,RUTBEONAY,SINIFONAY,UZ,GOREV,DIPLOMANO,UNVAN,SICILNO,PrintDate,PageNumber,ISTEKDR,SICILKULLAN,UNVANKULLAN};
                }

                public override void RunScript()
                {
#region PART2 FOOTER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((PatientExaminationReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            PatientExamination patientExamination = (PatientExamination)objectContext.GetObject(new Guid(objectID),"PatientExamination");

            if(patientExamination.ProcedureDoctor!=null)
                this.ISTEKDR.CalcValue =patientExamination.ProcedureDoctor.SignatureBlock;
#endregion PART2 FOOTER_Script
                }
            }

        }

        public part2Group part2;

        public partial class MAINGroup : TTReportGroup
        {
            public PatientExaminationReport MyParentReport
            {
                get { return (PatientExaminationReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SECDIAGNOSIS { get {return Body().SECDIAGNOSIS;} }
            public TTReportField NewField1381 { get {return Body().NewField1381;} }
            public TTReportShape NewLine131 { get {return Body().NewLine131;} }
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
                public PatientExaminationReport MyParentReport
                {
                    get { return (PatientExaminationReport)ParentReport; }
                }
                
                public TTReportField SECDIAGNOSIS;
                public TTReportField NewField1381;
                public TTReportShape NewLine131; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 16;
                    RepeatCount = 0;
                    
                    SECDIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 6, 206, 15, false);
                    SECDIAGNOSIS.Name = "SECDIAGNOSIS";
                    SECDIAGNOSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SECDIAGNOSIS.MultiLine = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.NoClip = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.WordBreak = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.ExpandTabs = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.TextFont.Name = "Arial Narrow";
                    SECDIAGNOSIS.TextFont.Size = 9;
                    SECDIAGNOSIS.Value = @"{%part2.SECDIAGNOSIS%}";

                    NewField1381 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 57, 5, false);
                    NewField1381.Name = "NewField1381";
                    NewField1381.TextFont.Name = "Arial Narrow";
                    NewField1381.TextFont.Size = 9;
                    NewField1381.TextFont.Bold = true;
                    NewField1381.Value = @"Tanı";

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 5, 57, 5, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SECDIAGNOSIS.CalcValue = MyParentReport.part2.SECDIAGNOSIS.CalcValue;
                    NewField1381.CalcValue = NewField1381.Value;
                    return new TTReportObject[] { SECDIAGNOSIS,NewField1381};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PATIENTHISTORYGroup : TTReportGroup
        {
            public PatientExaminationReport MyParentReport
            {
                get { return (PatientExaminationReport)ParentReport; }
            }

            new public PATIENTHISTORYGroupBody Body()
            {
                return (PATIENTHISTORYGroupBody)_body;
            }
            public TTReportField NewField11831 { get {return Body().NewField11831;} }
            public TTReportShape NewLine1131 { get {return Body().NewLine1131;} }
            public TTReportField PATIENTHISTORY { get {return Body().PATIENTHISTORY;} }
            public PATIENTHISTORYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PATIENTHISTORYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PATIENTHISTORYGroupBody(this);
            }

            public partial class PATIENTHISTORYGroupBody : TTReportSection
            {
                public PatientExaminationReport MyParentReport
                {
                    get { return (PatientExaminationReport)ParentReport; }
                }
                
                public TTReportField NewField11831;
                public TTReportShape NewLine1131;
                public TTReportField PATIENTHISTORY; 
                public PATIENTHISTORYGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 15;
                    RepeatCount = 0;
                    
                    NewField11831 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 57, 5, false);
                    NewField11831.Name = "NewField11831";
                    NewField11831.TextFont.Name = "Arial Narrow";
                    NewField11831.TextFont.Size = 9;
                    NewField11831.TextFont.Bold = true;
                    NewField11831.Value = @"Özgeçmiş";

                    NewLine1131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 5, 57, 5, false);
                    NewLine1131.Name = "NewLine1131";
                    NewLine1131.DrawStyle = DrawStyleConstants.vbSolid;

                    PATIENTHISTORY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 6, 206, 13, false);
                    PATIENTHISTORY.Name = "PATIENTHISTORY";
                    PATIENTHISTORY.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTHISTORY.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTHISTORY.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTHISTORY.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTHISTORY.TextFont.Name = "Arial Narrow";
                    PATIENTHISTORY.TextFont.CharSet = 1;
                    PATIENTHISTORY.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11831.CalcValue = NewField11831.Value;
                    PATIENTHISTORY.CalcValue = PATIENTHISTORY.Value;
                    return new TTReportObject[] { NewField11831,PATIENTHISTORY};
                }
                public override void RunPreScript()
                {
#region PATIENTHISTORY BODY_PreScript
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((PatientExaminationReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            PatientExamination patientExamination = (PatientExamination)objectContext.GetObject(new Guid(objectID),"PatientExamination");
            if(patientExamination.PatientHistory!=null)
                this.PATIENTHISTORY.Value = TTReportTool.TTReport.HTMLtoText(patientExamination.PatientHistory.ToString()); //this.ParentGroup.Fields("PATIENTHISTORY").Value;
#endregion PATIENTHISTORY BODY_PreScript
                }
            }

        }

        public PATIENTHISTORYGroup PATIENTHISTORY;

        public partial class COMPLAINTGroup : TTReportGroup
        {
            public PatientExaminationReport MyParentReport
            {
                get { return (PatientExaminationReport)ParentReport; }
            }

            new public COMPLAINTGroupBody Body()
            {
                return (COMPLAINTGroupBody)_body;
            }
            public TTReportField NewField113811 { get {return Body().NewField113811;} }
            public TTReportShape NewLine11311 { get {return Body().NewLine11311;} }
            public TTReportField COMPLAINT { get {return Body().COMPLAINT;} }
            public COMPLAINTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public COMPLAINTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new COMPLAINTGroupBody(this);
            }

            public partial class COMPLAINTGroupBody : TTReportSection
            {
                public PatientExaminationReport MyParentReport
                {
                    get { return (PatientExaminationReport)ParentReport; }
                }
                
                public TTReportField NewField113811;
                public TTReportShape NewLine11311;
                public TTReportField COMPLAINT; 
                public COMPLAINTGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 14;
                    RepeatCount = 0;
                    
                    NewField113811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 57, 5, false);
                    NewField113811.Name = "NewField113811";
                    NewField113811.TextFont.Name = "Arial Narrow";
                    NewField113811.TextFont.Size = 9;
                    NewField113811.TextFont.Bold = true;
                    NewField113811.Value = @"Yakınması / Öyküsü";

                    NewLine11311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 5, 57, 5, false);
                    NewLine11311.Name = "NewLine11311";
                    NewLine11311.DrawStyle = DrawStyleConstants.vbSolid;

                    COMPLAINT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 6, 206, 13, false);
                    COMPLAINT.Name = "COMPLAINT";
                    COMPLAINT.MultiLine = EvetHayirEnum.ehEvet;
                    COMPLAINT.NoClip = EvetHayirEnum.ehEvet;
                    COMPLAINT.WordBreak = EvetHayirEnum.ehEvet;
                    COMPLAINT.ExpandTabs = EvetHayirEnum.ehEvet;
                    COMPLAINT.TextFont.Name = "Arial Narrow";
                    COMPLAINT.TextFont.CharSet = 1;
                    COMPLAINT.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField113811.CalcValue = NewField113811.Value;
                    COMPLAINT.CalcValue = COMPLAINT.Value;
                    return new TTReportObject[] { NewField113811,COMPLAINT};
                }
                public override void RunPreScript()
                {
#region COMPLAINT BODY_PreScript
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((PatientExaminationReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            PatientExamination patientExamination = (PatientExamination)objectContext.GetObject(new Guid(objectID),"PatientExamination");
            if(patientExamination.Complaint!=null)
                this.COMPLAINT.Value = TTReportTool.TTReport.HTMLtoText(patientExamination.Complaint.ToString()); //this.ParentGroup.Fields("COMPLAINT").Value;
#endregion COMPLAINT BODY_PreScript
                }
            }

        }

        public COMPLAINTGroup COMPLAINT;

        public partial class PHYSICALEXAMINATIONGroup : TTReportGroup
        {
            public PatientExaminationReport MyParentReport
            {
                get { return (PatientExaminationReport)ParentReport; }
            }

            new public PHYSICALEXAMINATIONGroupBody Body()
            {
                return (PHYSICALEXAMINATIONGroupBody)_body;
            }
            public TTReportField NewField113811 { get {return Body().NewField113811;} }
            public TTReportShape NewLine11311 { get {return Body().NewLine11311;} }
            public TTReportField PHYSICALEXAM { get {return Body().PHYSICALEXAM;} }
            public PHYSICALEXAMINATIONGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PHYSICALEXAMINATIONGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PHYSICALEXAMINATIONGroupBody(this);
            }

            public partial class PHYSICALEXAMINATIONGroupBody : TTReportSection
            {
                public PatientExaminationReport MyParentReport
                {
                    get { return (PatientExaminationReport)ParentReport; }
                }
                
                public TTReportField NewField113811;
                public TTReportShape NewLine11311;
                public TTReportField PHYSICALEXAM; 
                public PHYSICALEXAMINATIONGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 14;
                    RepeatCount = 0;
                    
                    NewField113811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 57, 5, false);
                    NewField113811.Name = "NewField113811";
                    NewField113811.TextFont.Name = "Arial Narrow";
                    NewField113811.TextFont.Size = 9;
                    NewField113811.TextFont.Bold = true;
                    NewField113811.Value = @"Fizik Muayene";

                    NewLine11311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 5, 57, 5, false);
                    NewLine11311.Name = "NewLine11311";
                    NewLine11311.DrawStyle = DrawStyleConstants.vbSolid;

                    PHYSICALEXAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 6, 206, 13, false);
                    PHYSICALEXAM.Name = "PHYSICALEXAM";
                    PHYSICALEXAM.MultiLine = EvetHayirEnum.ehEvet;
                    PHYSICALEXAM.NoClip = EvetHayirEnum.ehEvet;
                    PHYSICALEXAM.WordBreak = EvetHayirEnum.ehEvet;
                    PHYSICALEXAM.ExpandTabs = EvetHayirEnum.ehEvet;
                    PHYSICALEXAM.TextFont.Name = "Arial Narrow";
                    PHYSICALEXAM.TextFont.CharSet = 1;
                    PHYSICALEXAM.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField113811.CalcValue = NewField113811.Value;
                    PHYSICALEXAM.CalcValue = PHYSICALEXAM.Value;
                    return new TTReportObject[] { NewField113811,PHYSICALEXAM};
                }
                public override void RunPreScript()
                {
#region PHYSICALEXAMINATION BODY_PreScript
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((PatientExaminationReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            PatientExamination patientExamination = (PatientExamination)objectContext.GetObject(new Guid(objectID),"PatientExamination");
            if(patientExamination.PhysicalExamination!=null)
                this.PHYSICALEXAM.Value = TTReportTool.TTReport.HTMLtoText(patientExamination.PhysicalExamination.ToString()); //this.ParentGroup.Fields("PHYSICALEXAM").Value;
#endregion PHYSICALEXAMINATION BODY_PreScript
                }
            }

        }

        public PHYSICALEXAMINATIONGroup PHYSICALEXAMINATION;

        public partial class PATIENTFOLDERGroup : TTReportGroup
        {
            public PatientExaminationReport MyParentReport
            {
                get { return (PatientExaminationReport)ParentReport; }
            }

            new public PATIENTFOLDERGroupBody Body()
            {
                return (PATIENTFOLDERGroupBody)_body;
            }
            public TTReportField NewField113811 { get {return Body().NewField113811;} }
            public TTReportShape NewLine11311 { get {return Body().NewLine11311;} }
            public TTReportField CONCLUSION { get {return Body().CONCLUSION;} }
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
                public PatientExaminationReport MyParentReport
                {
                    get { return (PatientExaminationReport)ParentReport; }
                }
                
                public TTReportField NewField113811;
                public TTReportShape NewLine11311;
                public TTReportField CONCLUSION; 
                public PATIENTFOLDERGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 13;
                    RepeatCount = 0;
                    
                    NewField113811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 57, 5, false);
                    NewField113811.Name = "NewField113811";
                    NewField113811.TextFont.Name = "Arial Narrow";
                    NewField113811.TextFont.Size = 9;
                    NewField113811.TextFont.Bold = true;
                    NewField113811.Value = @"Tedavi Kararı";

                    NewLine11311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 5, 57, 5, false);
                    NewLine11311.Name = "NewLine11311";
                    NewLine11311.DrawStyle = DrawStyleConstants.vbSolid;

                    CONCLUSION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 6, 206, 13, false);
                    CONCLUSION.Name = "CONCLUSION";
                    CONCLUSION.MultiLine = EvetHayirEnum.ehEvet;
                    CONCLUSION.NoClip = EvetHayirEnum.ehEvet;
                    CONCLUSION.WordBreak = EvetHayirEnum.ehEvet;
                    CONCLUSION.ExpandTabs = EvetHayirEnum.ehEvet;
                    CONCLUSION.TextFont.Name = "Arial Narrow";
                    CONCLUSION.TextFont.CharSet = 1;
                    CONCLUSION.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField113811.CalcValue = NewField113811.Value;
                    CONCLUSION.CalcValue = CONCLUSION.Value;
                    return new TTReportObject[] { NewField113811,CONCLUSION};
                }
                public override void RunPreScript()
                {
#region PATIENTFOLDER BODY_PreScript
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((PatientExaminationReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            PatientExamination patientExamination = (PatientExamination)objectContext.GetObject(new Guid(objectID),"PatientExamination");
            if(patientExamination.MTSConclusion!=null)
                this.CONCLUSION.Value = TTReportTool.TTReport.HTMLtoText(patientExamination.MTSConclusion.ToString()); //this.ParentGroup.Fields("PATIENTFOLDER").Value;
#endregion PATIENTFOLDER BODY_PreScript
                }
            }

        }

        public PATIENTFOLDERGroup PATIENTFOLDER;

        public partial class PATIENTSTORYGroup : TTReportGroup
        {
            public PatientExaminationReport MyParentReport
            {
                get { return (PatientExaminationReport)ParentReport; }
            }

            new public PATIENTSTORYGroupBody Body()
            {
                return (PATIENTSTORYGroupBody)_body;
            }
            public TTReportField NewField13211 { get {return Body().NewField13211;} }
            public TTReportField NewField111231 { get {return Body().NewField111231;} }
            public TTReportField NewField121231 { get {return Body().NewField121231;} }
            public TTReportField NewField131231 { get {return Body().NewField131231;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
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
                public PatientExaminationReport MyParentReport
                {
                    get { return (PatientExaminationReport)ParentReport; }
                }
                
                public TTReportField NewField13211;
                public TTReportField NewField111231;
                public TTReportField NewField121231;
                public TTReportField NewField131231;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField NewField131; 
                public PATIENTSTORYGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 29;
                    RepeatCount = 0;
                    
                    NewField13211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 3, 115, 8, false);
                    NewField13211.Name = "NewField13211";
                    NewField13211.TextFont.Name = "Arial Narrow";
                    NewField13211.Value = @"TETKİK İŞLEMLERİ HAKKINDA BİLGİLENDİRİLDİ";

                    NewField111231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 9, 115, 14, false);
                    NewField111231.Name = "NewField111231";
                    NewField111231.TextFont.Name = "Arial Narrow";
                    NewField111231.Value = @"HASTALIĞI,TEDAVİSİ VE YAN ETKİLERİ HAKKINDA BİLGİ VERİLDİ";

                    NewField121231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 15, 115, 20, false);
                    NewField121231.Name = "NewField121231";
                    NewField121231.TextFont.Name = "Arial Narrow";
                    NewField121231.Value = @"SOLUNUM VE DİĞER EGZERSİZLERİ HAKKINDA BİLGİ VERİLDİ";

                    NewField131231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 21, 115, 26, false);
                    NewField131231.Name = "NewField131231";
                    NewField131231.TextFont.Name = "Arial Narrow";
                    NewField131231.Value = @"AKILCI İLAÇ KULLANIMI HAKKINDA BİLGİ VERİLDİ";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 3, 14, 7, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.DrawWidth = 2;
                    NewField11.Value = @"";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 9, 14, 13, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.DrawWidth = 2;
                    NewField111.Value = @"";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 15, 14, 19, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.DrawWidth = 2;
                    NewField121.Value = @"";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 21, 14, 25, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.DrawWidth = 2;
                    NewField131.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField13211.CalcValue = NewField13211.Value;
                    NewField111231.CalcValue = NewField111231.Value;
                    NewField121231.CalcValue = NewField121231.Value;
                    NewField131231.CalcValue = NewField131231.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    return new TTReportObject[] { NewField13211,NewField111231,NewField121231,NewField131231,NewField11,NewField111,NewField121,NewField131};
                }
            }

        }

        public PATIENTSTORYGroup PATIENTSTORY;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PatientExaminationReport()
        {
            part2 = new part2Group(this,"part2");
            MAIN = new MAINGroup(part2,"MAIN");
            PATIENTHISTORY = new PATIENTHISTORYGroup(part2,"PATIENTHISTORY");
            COMPLAINT = new COMPLAINTGroup(part2,"COMPLAINT");
            PHYSICALEXAMINATION = new PHYSICALEXAMINATIONGroup(part2,"PHYSICALEXAMINATION");
            PATIENTFOLDER = new PATIENTFOLDERGroup(part2,"PATIENTFOLDER");
            PATIENTSTORY = new PATIENTSTORYGroup(part2,"PATIENTSTORY");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("OBJECTID", "00000000-0000-0000-0000-000000000000", "ObjectID", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("OBJECTID"))
                _runtimeParameters.OBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["OBJECTID"]);
            Name = "PATIENTEXAMINATIONREPORT";
            Caption = "Muayene Sonuç Raporu";
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