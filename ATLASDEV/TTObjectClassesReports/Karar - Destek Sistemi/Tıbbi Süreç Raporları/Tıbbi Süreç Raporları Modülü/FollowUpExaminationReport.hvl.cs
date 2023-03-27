
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
    /// Kontrol Muayenesi Sonuç Raporu
    /// </summary>
    public partial class FollowUpExaminationReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class part2Group : TTReportGroup
        {
            public FollowUpExaminationReport MyParentReport
            {
                get { return (FollowUpExaminationReport)ParentReport; }
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
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField BABAAD { get {return Header().BABAAD;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField FULLSINIFRUTBE { get {return Header().FULLSINIFRUTBE;} }
            public TTReportField BIRLIK { get {return Header().BIRLIK;} }
            public TTReportField NewField143 { get {return Header().NewField143;} }
            public TTReportField NewField133 { get {return Header().NewField133;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField LBLUNIQUEREFNO { get {return Header().LBLUNIQUEREFNO;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField LOGO1 { get {return Header().LOGO1;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField REPORTHEADER1 { get {return Header().REPORTHEADER1;} }
            public TTReportField PROTOKOLNO { get {return Header().PROTOKOLNO;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField HASTANO { get {return Header().HASTANO;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField ACTIONID { get {return Header().ACTIONID;} }
            public TTReportField NewField162 { get {return Header().NewField162;} }
            public TTReportField TARIH { get {return Header().TARIH;} }
            public TTReportField NewField172 { get {return Header().NewField172;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField1321 { get {return Header().NewField1321;} }
            public TTReportField NewField1421 { get {return Header().NewField1421;} }
            public TTReportField NewField1521 { get {return Header().NewField1521;} }
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
                list[0] = new TTReportNqlData<FollowUpExamination.GetFollowUpExaminationNQL_Class>("GetFollowUpExaminationNQL", FollowUpExamination.GetFollowUpExaminationNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public FollowUpExaminationReport MyParentReport
                {
                    get { return (FollowUpExaminationReport)ParentReport; }
                }
                
                public TTReportField MASTERRESOURCE;
                public TTReportField DYERVETARIH;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField BABAAD;
                public TTReportField ADSOYAD;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField171;
                public TTReportField NewField181;
                public TTReportField FULLSINIFRUTBE;
                public TTReportField BIRLIK;
                public TTReportField NewField143;
                public TTReportField NewField133;
                public TTReportField UNIQUEREFNO;
                public TTReportField LBLUNIQUEREFNO;
                public TTReportField NewField1131;
                public TTReportField LOGO1;
                public TTReportField XXXXXXBASLIK;
                public TTReportField REPORTHEADER1;
                public TTReportField PROTOKOLNO;
                public TTReportField NewField122;
                public TTReportField HASTANO;
                public TTReportField NewField142;
                public TTReportField ACTIONID;
                public TTReportField NewField162;
                public TTReportField TARIH;
                public TTReportField NewField172;
                public TTReportField NewField1221;
                public TTReportField NewField1321;
                public TTReportField NewField1421;
                public TTReportField NewField1521;
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
                public part2GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 101;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MASTERRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 41, 171, 46, false);
                    MASTERRESOURCE.Name = "MASTERRESOURCE";
                    MASTERRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MASTERRESOURCE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MASTERRESOURCE.TextFont.Name = "Arial Narrow";
                    MASTERRESOURCE.TextFont.Size = 11;
                    MASTERRESOURCE.TextFont.Bold = true;
                    MASTERRESOURCE.Value = @"{#MASTERRESOURCENAME#}";

                    DYERVETARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 73, 124, 78, false);
                    DYERVETARIH.Name = "DYERVETARIH";
                    DYERVETARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERVETARIH.TextFont.Name = "Arial Narrow";
                    DYERVETARIH.TextFont.Size = 9;
                    DYERVETARIH.Value = @"{%DYER%} / {%DTARIH%}";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 58, 56, 63, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Name = "Arial Narrow";
                    NewField18.TextFont.Size = 9;
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @"Sınıf ve Rütbesi";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 73, 56, 78, false);
                    NewField19.Name = "NewField19";
                    NewField19.TextFont.Name = "Arial Narrow";
                    NewField19.TextFont.Size = 9;
                    NewField19.TextFont.Bold = true;
                    NewField19.Value = @"Doğum Yeri ve Tarihi";

                    BABAAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 68, 124, 73, false);
                    BABAAD.Name = "BABAAD";
                    BABAAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAAD.TextFont.Name = "Arial Narrow";
                    BABAAD.TextFont.Size = 9;
                    BABAAD.Value = @"{#FATHERNAME#}";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 53, 124, 58, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.Name = "Arial Narrow";
                    ADSOYAD.TextFont.Size = 9;
                    ADSOYAD.Value = @"{#NAME#} {#SURNAME#}";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 53, 56, 58, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Name = "Arial Narrow";
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @"Adı Soyadı";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 58, 58, 63, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Name = "Arial Narrow";
                    NewField131.TextFont.Size = 9;
                    NewField131.TextFont.Bold = true;
                    NewField131.Value = @":";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 53, 58, 58, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Name = "Arial Narrow";
                    NewField141.TextFont.Size = 9;
                    NewField141.TextFont.Bold = true;
                    NewField141.Value = @":";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 68, 56, 73, false);
                    NewField151.Name = "NewField151";
                    NewField151.TextFont.Name = "Arial Narrow";
                    NewField151.TextFont.Size = 9;
                    NewField151.TextFont.Bold = true;
                    NewField151.Value = @"Baba Adı";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 73, 58, 78, false);
                    NewField171.Name = "NewField171";
                    NewField171.TextFont.Name = "Arial Narrow";
                    NewField171.TextFont.Size = 9;
                    NewField171.TextFont.Bold = true;
                    NewField171.Value = @":";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 68, 58, 73, false);
                    NewField181.Name = "NewField181";
                    NewField181.TextFont.Name = "Arial Narrow";
                    NewField181.TextFont.Size = 9;
                    NewField181.TextFont.Bold = true;
                    NewField181.Value = @":";

                    FULLSINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 58, 124, 63, false);
                    FULLSINIFRUTBE.Name = "FULLSINIFRUTBE";
                    FULLSINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLSINIFRUTBE.TextFont.Name = "Arial Narrow";
                    FULLSINIFRUTBE.TextFont.Size = 9;
                    FULLSINIFRUTBE.Value = @"";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 63, 124, 68, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.TextFont.Name = "Arial Narrow";
                    BIRLIK.TextFont.Size = 9;
                    BIRLIK.Value = @"";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 63, 56, 68, false);
                    NewField143.Name = "NewField143";
                    NewField143.TextFont.Name = "Arial Narrow";
                    NewField143.TextFont.Size = 9;
                    NewField143.TextFont.Bold = true;
                    NewField143.Value = @"Birliği";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 63, 58, 68, false);
                    NewField133.Name = "NewField133";
                    NewField133.TextFont.Name = "Arial Narrow";
                    NewField133.TextFont.Size = 9;
                    NewField133.TextFont.Bold = true;
                    NewField133.Value = @":";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 48, 124, 53, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.Value = @"";

                    LBLUNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 48, 56, 53, false);
                    LBLUNIQUEREFNO.Name = "LBLUNIQUEREFNO";
                    LBLUNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    LBLUNIQUEREFNO.TextFont.Size = 9;
                    LBLUNIQUEREFNO.TextFont.Bold = true;
                    LBLUNIQUEREFNO.Value = @"T.C. Kimlik No";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 48, 58, 53, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Name = "Arial Narrow";
                    NewField1131.TextFont.Size = 9;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.Value = @":";

                    LOGO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 50, 30, false);
                    LOGO1.Name = "LOGO1";
                    LOGO1.TextFont.CharSet = 1;
                    LOGO1.Value = @"Logo";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 10, 171, 33, false);
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

                    REPORTHEADER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 33, 171, 39, false);
                    REPORTHEADER1.Name = "REPORTHEADER1";
                    REPORTHEADER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER1.TextFont.Name = "Arial Narrow";
                    REPORTHEADER1.TextFont.Size = 15;
                    REPORTHEADER1.TextFont.Bold = true;
                    REPORTHEADER1.Value = @"KONTROL MUAYENESİ RAPORU";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 53, 206, 58, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.Name = "Arial Narrow";
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.Value = @"{#PROTOCOLNO#}";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 53, 176, 58, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Name = "Arial Narrow";
                    NewField122.TextFont.Size = 9;
                    NewField122.TextFont.Bold = true;
                    NewField122.Value = @"Protokol No";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 58, 206, 63, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.ObjectDefName = "FollowUpExamination";
                    HASTANO.DataMember = "EPISODE.PATIENT.ID";
                    HASTANO.TextFont.Name = "Arial Narrow";
                    HASTANO.TextFont.Size = 9;
                    HASTANO.Value = @"{@TTOBJECTID@}";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 58, 176, 63, false);
                    NewField142.Name = "NewField142";
                    NewField142.TextFont.Name = "Arial Narrow";
                    NewField142.TextFont.Size = 9;
                    NewField142.TextFont.Bold = true;
                    NewField142.Value = @"Hasta No";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 63, 206, 68, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.TextFont.Name = "Arial Narrow";
                    ACTIONID.TextFont.Size = 9;
                    ACTIONID.Value = @"{#ACTIONID#}";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 63, 176, 68, false);
                    NewField162.Name = "NewField162";
                    NewField162.TextFont.Name = "Arial Narrow";
                    NewField162.TextFont.Size = 9;
                    NewField162.TextFont.Bold = true;
                    NewField162.Value = @"İşlem No";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 48, 206, 53, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"g";
                    TARIH.TextFont.Name = "Arial Narrow";
                    TARIH.TextFont.Size = 9;
                    TARIH.Value = @"{#ACTIONDATE#}";

                    NewField172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 48, 176, 53, false);
                    NewField172.Name = "NewField172";
                    NewField172.TextFont.Name = "Arial Narrow";
                    NewField172.TextFont.Size = 9;
                    NewField172.TextFont.Bold = true;
                    NewField172.Value = @"Tarih";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 63, 178, 68, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1221.TextFont.Name = "Arial Narrow";
                    NewField1221.TextFont.Size = 9;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.Value = @":";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 58, 178, 63, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1321.TextFont.Name = "Arial Narrow";
                    NewField1321.TextFont.Size = 9;
                    NewField1321.TextFont.Bold = true;
                    NewField1321.Value = @":";

                    NewField1421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 53, 178, 58, false);
                    NewField1421.Name = "NewField1421";
                    NewField1421.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1421.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1421.TextFont.Name = "Arial Narrow";
                    NewField1421.TextFont.Size = 9;
                    NewField1421.TextFont.Bold = true;
                    NewField1421.Value = @":";

                    NewField1521 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 48, 178, 53, false);
                    NewField1521.Name = "NewField1521";
                    NewField1521.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1521.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1521.TextFont.Name = "Arial Narrow";
                    NewField1521.TextFont.Size = 9;
                    NewField1521.TextFont.Bold = true;
                    NewField1521.Value = @":";

                    SEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 78, 124, 83, false);
                    SEX.Name = "SEX";
                    SEX.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEX.ObjectDefName = "SexEnum";
                    SEX.DataMember = "DISPLAYTEXT";
                    SEX.TextFont.Name = "Arial Narrow";
                    SEX.TextFont.Size = 9;
                    SEX.Value = @"{#SEX#}";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 78, 56, 83, false);
                    NewField191.Name = "NewField191";
                    NewField191.TextFont.Name = "Arial Narrow";
                    NewField191.TextFont.Size = 9;
                    NewField191.TextFont.Bold = true;
                    NewField191.Value = @"Cinsiyeti";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 78, 58, 83, false);
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
                    EPISODEID.ObjectDefName = "FollowUpExamination";
                    EPISODEID.DataMember = "EPISODE.ID";
                    EPISODEID.TextFont.Name = "Arial Narrow";
                    EPISODEID.TextFont.Size = 9;
                    EPISODEID.Value = @"{@TTOBJECTID@}";

                    EPISODEOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 51, 269, 56, false);
                    EPISODEOBJECTID.Name = "EPISODEOBJECTID";
                    EPISODEOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEOBJECTID.TextFont.Name = "Arial Narrow";
                    EPISODEOBJECTID.TextFont.Size = 9;
                    EPISODEOBJECTID.Value = @"{#EPISODEOBJECTID#}";

                    PREDIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 90, 206, 99, false);
                    PREDIAGNOSIS.Name = "PREDIAGNOSIS";
                    PREDIAGNOSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PREDIAGNOSIS.MultiLine = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.NoClip = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.WordBreak = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.ExpandTabs = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.TextFont.Name = "Arial Narrow";
                    PREDIAGNOSIS.TextFont.Size = 9;
                    PREDIAGNOSIS.Value = @"";

                    NewField183 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 85, 57, 89, false);
                    NewField183.Name = "NewField183";
                    NewField183.TextFont.Name = "Arial Narrow";
                    NewField183.TextFont.Size = 9;
                    NewField183.TextFont.Bold = true;
                    NewField183.Value = @"Ön Tanı";

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 89, 57, 89, false);
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

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    FollowUpExamination.GetFollowUpExaminationNQL_Class dataset_GetFollowUpExaminationNQL = ParentGroup.rsGroup.GetCurrentRecord<FollowUpExamination.GetFollowUpExaminationNQL_Class>(0);
                    MASTERRESOURCE.CalcValue = (dataset_GetFollowUpExaminationNQL != null ? Globals.ToStringCore(dataset_GetFollowUpExaminationNQL.Masterresourcename) : "");
                    DYER.CalcValue = (dataset_GetFollowUpExaminationNQL != null ? Globals.ToStringCore(dataset_GetFollowUpExaminationNQL.Cityname) : "");
                    DTARIH.CalcValue = (dataset_GetFollowUpExaminationNQL != null ? Globals.ToStringCore(dataset_GetFollowUpExaminationNQL.BirthDate) : "");
                    DYERVETARIH.CalcValue = MyParentReport.part2.DYER.CalcValue + @" / " + MyParentReport.part2.DTARIH.FormattedValue;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    BABAAD.CalcValue = (dataset_GetFollowUpExaminationNQL != null ? Globals.ToStringCore(dataset_GetFollowUpExaminationNQL.FatherName) : "");
                    ADSOYAD.CalcValue = (dataset_GetFollowUpExaminationNQL != null ? Globals.ToStringCore(dataset_GetFollowUpExaminationNQL.Name) : "") + @" " + (dataset_GetFollowUpExaminationNQL != null ? Globals.ToStringCore(dataset_GetFollowUpExaminationNQL.Surname) : "");
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField181.CalcValue = NewField181.Value;
                    FULLSINIFRUTBE.CalcValue = @"";
                    BIRLIK.CalcValue = @"";
                    NewField143.CalcValue = NewField143.Value;
                    NewField133.CalcValue = NewField133.Value;
                    UNIQUEREFNO.CalcValue = @"";
                    LBLUNIQUEREFNO.CalcValue = LBLUNIQUEREFNO.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    LOGO1.CalcValue = LOGO1.Value;
                    REPORTHEADER1.CalcValue = REPORTHEADER1.Value;
                    PROTOKOLNO.CalcValue = (dataset_GetFollowUpExaminationNQL != null ? Globals.ToStringCore(dataset_GetFollowUpExaminationNQL.ProtocolNo) : "");
                    NewField122.CalcValue = NewField122.Value;
                    HASTANO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    HASTANO.PostFieldValueCalculation();
                    NewField142.CalcValue = NewField142.Value;
                    ACTIONID.CalcValue = (dataset_GetFollowUpExaminationNQL != null ? Globals.ToStringCore(dataset_GetFollowUpExaminationNQL.Actionid) : "");
                    NewField162.CalcValue = NewField162.Value;
                    TARIH.CalcValue = (dataset_GetFollowUpExaminationNQL != null ? Globals.ToStringCore(dataset_GetFollowUpExaminationNQL.ActionDate) : "");
                    NewField172.CalcValue = NewField172.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    NewField1421.CalcValue = NewField1421.Value;
                    NewField1521.CalcValue = NewField1521.Value;
                    SEX.CalcValue = (dataset_GetFollowUpExaminationNQL != null ? Globals.ToStringCore(dataset_GetFollowUpExaminationNQL.Sex) : "");
                    SEX.PostFieldValueCalculation();
                    NewField191.CalcValue = NewField191.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    EPISODEID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    EPISODEID.PostFieldValueCalculation();
                    EPISODEOBJECTID.CalcValue = (dataset_GetFollowUpExaminationNQL != null ? Globals.ToStringCore(dataset_GetFollowUpExaminationNQL.Episodeobjectid) : "");
                    PREDIAGNOSIS.CalcValue = @"";
                    NewField183.CalcValue = NewField183.Value;
                    SECDIAGNOSIS.CalcValue = @"";
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { MASTERRESOURCE,DYER,DTARIH,DYERVETARIH,NewField18,NewField19,BABAAD,ADSOYAD,NewField121,NewField131,NewField141,NewField151,NewField171,NewField181,FULLSINIFRUTBE,BIRLIK,NewField143,NewField133,UNIQUEREFNO,LBLUNIQUEREFNO,NewField1131,LOGO1,REPORTHEADER1,PROTOKOLNO,NewField122,HASTANO,NewField142,ACTIONID,NewField162,TARIH,NewField172,NewField1221,NewField1321,NewField1421,NewField1521,SEX,NewField191,NewField1171,EPISODEID,EPISODEOBJECTID,PREDIAGNOSIS,NewField183,SECDIAGNOSIS,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region PART2 HEADER_Script
                    int cnt = 1;
            TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((FollowUpExaminationReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            FollowUpExamination followUpExamination = (FollowUpExamination)objectContext.GetObject(new Guid(objectID),"FollowUpExamination");
            
            if (followUpExamination==null)
                throw new Exception("Rapor, Kontrol Muayenesi modülü üzerinden alınmalıdır.");
            
            Episode episode = followUpExamination.Episode;
//            this.BIRLIK.CalcValue = " " + (episode.MilitaryUnit == null ? (episode.Patient.MilitaryUnit == null ? "" : episode.Patient.MilitaryUnit.Name) : episode.MilitaryUnit.Name);
            
            this.PREDIAGNOSIS.CalcValue = "";
            BindingList<DiagnosisGrid.GetPreDiagnosisByEpisodeAction_Class> preDiagnosis = null;
            preDiagnosis = DiagnosisGrid.GetPreDiagnosisByEpisodeAction(followUpExamination.ObjectID.ToString());
            foreach(DiagnosisGrid.GetPreDiagnosisByEpisodeAction_Class preDiagnosisGrid in preDiagnosis)
            {
                this.PREDIAGNOSIS.CalcValue += cnt + ". " + preDiagnosisGrid.Code + " " + preDiagnosisGrid.Diagnosename;
                this.PREDIAGNOSIS.CalcValue += "\r\n";
                cnt++;
            }
            
            cnt = 1;
            this.SECDIAGNOSIS.CalcValue = "";
            BindingList<DiagnosisGrid.GetSecDiagnosisByEpisodeAction_Class> secDiagnosis = null;
            secDiagnosis = DiagnosisGrid.GetSecDiagnosisByEpisodeAction(followUpExamination.ObjectID.ToString());
            foreach(DiagnosisGrid.GetSecDiagnosisByEpisodeAction_Class secDiagnosisGrid in secDiagnosis)
            {
                this.SECDIAGNOSIS.CalcValue += cnt + ". " + secDiagnosisGrid.Code + " " + secDiagnosisGrid.Diagnosename;
                this.SECDIAGNOSIS.CalcValue += "\r\n";
                cnt++;
            }
            
            if (followUpExamination.Episode.Patient.Foreign == true)
            {
                this.UNIQUEREFNO.CalcValue = followUpExamination.Episode.Patient.ForeignUniqueRefNo.ToString();
                this.LBLUNIQUEREFNO.CalcValue = "Kimlik/Sigorta No (Yabancı Hasta)";
            }
            else
            {
                this.UNIQUEREFNO.CalcValue = followUpExamination.Episode.Patient.UniqueRefNo.ToString();
                this.LBLUNIQUEREFNO.CalcValue = "T.C. Kimlik No";
            }
#endregion PART2 HEADER_Script
                }
            }
            public partial class part2GroupFooter : TTReportSection
            {
                public FollowUpExaminationReport MyParentReport
                {
                    get { return (FollowUpExaminationReport)ParentReport; }
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

                    DIPSIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 16, 83, 20, false);
                    DIPSIC.Name = "DIPSIC";
                    DIPSIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSIC.TextFont.Name = "Arial Narrow";
                    DIPSIC.TextFont.Size = 9;
                    DIPSIC.Value = @"";

                    ADSOYADDOC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 83, 12, false);
                    ADSOYADDOC.Name = "ADSOYADDOC";
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

                    DIPSICLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 16, 32, 20, false);
                    DIPSICLABEL.Name = "DIPSICLABEL";
                    DIPSICLABEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSICLABEL.TextFont.Name = "Arial Narrow";
                    DIPSICLABEL.TextFont.Size = 9;
                    DIPSICLABEL.Value = @"DIPLOMASICIL";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 12, 83, 16, false);
                    SINRUT.Name = "SINRUT";
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
                    RUTBEONAY.Value = @"{#DOKRANK#}";

                    SINIFONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 8, 175, 13, false);
                    SINIFONAY.Name = "SINIFONAY";
                    SINIFONAY.Visible = EvetHayirEnum.ehHayir;
                    SINIFONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFONAY.TextFont.Name = "Arial Narrow";
                    SINIFONAY.TextFont.Size = 9;
                    SINIFONAY.Value = @"{#DOCMILITARYCLASS#}";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 20, 83, 24, false);
                    UZ.Name = "UZ";
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

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 3, 206, 8, false);
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

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    FollowUpExamination.GetFollowUpExaminationNQL_Class dataset_GetFollowUpExaminationNQL = ParentGroup.rsGroup.GetCurrentRecord<FollowUpExamination.GetFollowUpExaminationNQL_Class>(0);
                    NewField10.CalcValue = NewField10.Value;
                    DIPSIC.CalcValue = @"";
                    ADSOYADDOC.CalcValue = (dataset_GetFollowUpExaminationNQL != null ? Globals.ToStringCore(dataset_GetFollowUpExaminationNQL.Proceduredoctorname) : "");
                    UZMANLIKDAL.CalcValue = (dataset_GetFollowUpExaminationNQL != null ? Globals.ToStringCore(dataset_GetFollowUpExaminationNQL.Docspeciality) : "");
                    DIPSICLABEL.CalcValue = @"DIPLOMASICIL";
                    SINRUT.CalcValue = @"";
                    RUTBEONAY.CalcValue = (dataset_GetFollowUpExaminationNQL != null ? Globals.ToStringCore(dataset_GetFollowUpExaminationNQL.Dokrank) : "");
                    SINIFONAY.CalcValue = (dataset_GetFollowUpExaminationNQL != null ? Globals.ToStringCore(dataset_GetFollowUpExaminationNQL.Docmilitaryclass) : "");
                    UZ.CalcValue = MyParentReport.part2.UZMANLIKDAL.CalcValue;
                    GOREV.CalcValue = (dataset_GetFollowUpExaminationNQL != null ? Globals.ToStringCore(dataset_GetFollowUpExaminationNQL.Docwork) : "");
                    DIPLOMANO.CalcValue = (dataset_GetFollowUpExaminationNQL != null ? Globals.ToStringCore(dataset_GetFollowUpExaminationNQL.Docdiplomano) : "");
                    UNVAN.CalcValue = (dataset_GetFollowUpExaminationNQL != null ? Globals.ToStringCore(dataset_GetFollowUpExaminationNQL.Doctitle) : "");
                    SICILNO.CalcValue = (dataset_GetFollowUpExaminationNQL != null ? Globals.ToStringCore(dataset_GetFollowUpExaminationNQL.Docemploymentrecordid) : "");
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    SICILKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "");
                    UNVANKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "");
                    return new TTReportObject[] { NewField10,DIPSIC,ADSOYADDOC,UZMANLIKDAL,DIPSICLABEL,SINRUT,RUTBEONAY,SINIFONAY,UZ,GOREV,DIPLOMANO,UNVAN,SICILNO,PrintDate,PageNumber,SICILKULLAN,UNVANKULLAN};
                }

                public override void RunScript()
                {
#region PART2 FOOTER_Script
                    if(this.SICILKULLAN.CalcValue=="TRUE")
            {
                this.DIPSICLABEL.CalcValue= "SİCİL NO :";
                this.DIPSIC.CalcValue=this.SICILNO.CalcValue;
            }
            else
            {
                this.DIPSICLABEL.CalcValue= "DİPLOMA NO :";
                this.DIPSIC.CalcValue=this.DIPLOMANO.CalcValue;
            }
            

            if(this.UNVANKULLAN.CalcValue!="TRUE")
            {
                this.SINRUT.CalcValue=this.SINIFONAY.CalcValue + " " + this.RUTBEONAY.CalcValue;
            }
            else
            {
                if(this.UNVAN.CalcValue=="")
                {
                    this.SINRUT.Value=this.SINIFONAY.CalcValue + " " + this.RUTBEONAY.CalcValue;
                }
                else
                {
                    this.SINRUT.CalcValue=this.UNVAN.CalcValue + " " + this.RUTBEONAY.CalcValue;
                }
            }
#endregion PART2 FOOTER_Script
                }
            }

        }

        public part2Group part2;

        public partial class MAINGroup : TTReportGroup
        {
            public FollowUpExaminationReport MyParentReport
            {
                get { return (FollowUpExaminationReport)ParentReport; }
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
                public FollowUpExaminationReport MyParentReport
                {
                    get { return (FollowUpExaminationReport)ParentReport; }
                }
                
                public TTReportField SECDIAGNOSIS;
                public TTReportField NewField1381;
                public TTReportShape NewLine131; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 16;
                    ForceNewPage = EvetHayirEnum.ehEvet;
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
            public FollowUpExaminationReport MyParentReport
            {
                get { return (FollowUpExaminationReport)ParentReport; }
            }

            new public PATIENTHISTORYGroupBody Body()
            {
                return (PATIENTHISTORYGroupBody)_body;
            }
            public TTReportRTF PATIENTHISTORY1 { get {return Body().PATIENTHISTORY1;} }
            public TTReportField NewField11831 { get {return Body().NewField11831;} }
            public TTReportShape NewLine1131 { get {return Body().NewLine1131;} }
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
                public FollowUpExaminationReport MyParentReport
                {
                    get { return (FollowUpExaminationReport)ParentReport; }
                }
                
                public TTReportRTF PATIENTHISTORY1;
                public TTReportField NewField11831;
                public TTReportShape NewLine1131; 
                public PATIENTHISTORYGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    PATIENTHISTORY1 = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 10, 6, 206, 19, false);
                    PATIENTHISTORY1.Name = "PATIENTHISTORY1";
                    PATIENTHISTORY1.Value = @"";

                    NewField11831 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 57, 5, false);
                    NewField11831.Name = "NewField11831";
                    NewField11831.TextFont.Name = "Arial Narrow";
                    NewField11831.TextFont.Size = 9;
                    NewField11831.TextFont.Bold = true;
                    NewField11831.Value = @"Özgeçmiş";

                    NewLine1131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 5, 57, 5, false);
                    NewLine1131.Name = "NewLine1131";
                    NewLine1131.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PATIENTHISTORY1.CalcValue = PATIENTHISTORY1.Value;
                    NewField11831.CalcValue = NewField11831.Value;
                    return new TTReportObject[] { PATIENTHISTORY1,NewField11831};
                }
                public override void RunPreScript()
                {
#region PATIENTHISTORY BODY_PreScript
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((FollowUpExaminationReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            FollowUpExamination followUpExamination = (FollowUpExamination)objectContext.GetObject(new Guid(objectID),"FollowUpExamination");
            if (followUpExamination.PatientHistory != null){
            this.PATIENTHISTORY1.Value = followUpExamination.PatientHistory.ToString(); //this.ParentGroup.Fields("PATIENTHISTORY").Value;
            }
#endregion PATIENTHISTORY BODY_PreScript
                }
            }

        }

        public PATIENTHISTORYGroup PATIENTHISTORY;

        public partial class COMPLAINTGroup : TTReportGroup
        {
            public FollowUpExaminationReport MyParentReport
            {
                get { return (FollowUpExaminationReport)ParentReport; }
            }

            new public COMPLAINTGroupBody Body()
            {
                return (COMPLAINTGroupBody)_body;
            }
            public TTReportRTF COMPLAINT1 { get {return Body().COMPLAINT1;} }
            public TTReportField NewField113811 { get {return Body().NewField113811;} }
            public TTReportShape NewLine11311 { get {return Body().NewLine11311;} }
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
                public FollowUpExaminationReport MyParentReport
                {
                    get { return (FollowUpExaminationReport)ParentReport; }
                }
                
                public TTReportRTF COMPLAINT1;
                public TTReportField NewField113811;
                public TTReportShape NewLine11311; 
                public COMPLAINTGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    COMPLAINT1 = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 10, 6, 206, 19, false);
                    COMPLAINT1.Name = "COMPLAINT1";
                    COMPLAINT1.Value = @"";

                    NewField113811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 57, 5, false);
                    NewField113811.Name = "NewField113811";
                    NewField113811.TextFont.Name = "Arial Narrow";
                    NewField113811.TextFont.Size = 9;
                    NewField113811.TextFont.Bold = true;
                    NewField113811.Value = @"Şikayet";

                    NewLine11311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 5, 57, 5, false);
                    NewLine11311.Name = "NewLine11311";
                    NewLine11311.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    COMPLAINT1.CalcValue = COMPLAINT1.Value;
                    NewField113811.CalcValue = NewField113811.Value;
                    return new TTReportObject[] { COMPLAINT1,NewField113811};
                }
                public override void RunPreScript()
                {
#region COMPLAINT BODY_PreScript
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((FollowUpExaminationReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            FollowUpExamination followUpExamination = (FollowUpExamination)objectContext.GetObject(new Guid(objectID),"FollowUpExamination");
            if (followUpExamination.Complaint != null){
            this.COMPLAINT1.Value = followUpExamination.Complaint.ToString(); //this.ParentGroup.Fields("COMPLAINT").Value;
            }
#endregion COMPLAINT BODY_PreScript
                }
            }

        }

        public COMPLAINTGroup COMPLAINT;

        public partial class PHYSICALEXAMINATIONGroup : TTReportGroup
        {
            public FollowUpExaminationReport MyParentReport
            {
                get { return (FollowUpExaminationReport)ParentReport; }
            }

            new public PHYSICALEXAMINATIONGroupBody Body()
            {
                return (PHYSICALEXAMINATIONGroupBody)_body;
            }
            public TTReportRTF PHYSICALEXAM1 { get {return Body().PHYSICALEXAM1;} }
            public TTReportField NewField113811 { get {return Body().NewField113811;} }
            public TTReportShape NewLine11311 { get {return Body().NewLine11311;} }
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
                public FollowUpExaminationReport MyParentReport
                {
                    get { return (FollowUpExaminationReport)ParentReport; }
                }
                
                public TTReportRTF PHYSICALEXAM1;
                public TTReportField NewField113811;
                public TTReportShape NewLine11311; 
                public PHYSICALEXAMINATIONGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    PHYSICALEXAM1 = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 10, 6, 206, 19, false);
                    PHYSICALEXAM1.Name = "PHYSICALEXAM1";
                    PHYSICALEXAM1.Value = @"";

                    NewField113811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 57, 5, false);
                    NewField113811.Name = "NewField113811";
                    NewField113811.TextFont.Name = "Arial Narrow";
                    NewField113811.TextFont.Size = 9;
                    NewField113811.TextFont.Bold = true;
                    NewField113811.Value = @"Fizik Muayene";

                    NewLine11311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 5, 57, 5, false);
                    NewLine11311.Name = "NewLine11311";
                    NewLine11311.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PHYSICALEXAM1.CalcValue = PHYSICALEXAM1.Value;
                    NewField113811.CalcValue = NewField113811.Value;
                    return new TTReportObject[] { PHYSICALEXAM1,NewField113811};
                }
                public override void RunPreScript()
                {
#region PHYSICALEXAMINATION BODY_PreScript
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((FollowUpExaminationReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            FollowUpExamination followUpExamination = (FollowUpExamination)objectContext.GetObject(new Guid(objectID),"FollowUpExamination");
            if (followUpExamination.PhysicalExamination != null){
            this.PHYSICALEXAM1.Value = followUpExamination.PhysicalExamination.ToString(); //this.ParentGroup.Fields("PHYSICALEXAM").Value;
            }
#endregion PHYSICALEXAMINATION BODY_PreScript
                }
            }

        }

        public PHYSICALEXAMINATIONGroup PHYSICALEXAMINATION;

        public partial class PATIENTFOLDERGroup : TTReportGroup
        {
            public FollowUpExaminationReport MyParentReport
            {
                get { return (FollowUpExaminationReport)ParentReport; }
            }

            new public PATIENTFOLDERGroupBody Body()
            {
                return (PATIENTFOLDERGroupBody)_body;
            }
            public TTReportRTF PATIENTFOLDER1 { get {return Body().PATIENTFOLDER1;} }
            public TTReportField NewField113811 { get {return Body().NewField113811;} }
            public TTReportShape NewLine11311 { get {return Body().NewLine11311;} }
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
                public FollowUpExaminationReport MyParentReport
                {
                    get { return (FollowUpExaminationReport)ParentReport; }
                }
                
                public TTReportRTF PATIENTFOLDER1;
                public TTReportField NewField113811;
                public TTReportShape NewLine11311; 
                public PATIENTFOLDERGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    PATIENTFOLDER1 = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 10, 6, 206, 19, false);
                    PATIENTFOLDER1.Name = "PATIENTFOLDER1";
                    PATIENTFOLDER1.Value = @"";

                    NewField113811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 57, 5, false);
                    NewField113811.Name = "NewField113811";
                    NewField113811.TextFont.Name = "Arial Narrow";
                    NewField113811.TextFont.Size = 9;
                    NewField113811.TextFont.Bold = true;
                    NewField113811.Value = @"Hasta Dosyası";

                    NewLine11311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 5, 57, 5, false);
                    NewLine11311.Name = "NewLine11311";
                    NewLine11311.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PATIENTFOLDER1.CalcValue = PATIENTFOLDER1.Value;
                    NewField113811.CalcValue = NewField113811.Value;
                    return new TTReportObject[] { PATIENTFOLDER1,NewField113811};
                }
                public override void RunPreScript()
                {
#region PATIENTFOLDER BODY_PreScript
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((FollowUpExaminationReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            FollowUpExamination followUpExamination = (FollowUpExamination)objectContext.GetObject(new Guid(objectID),"FollowUpExamination");
            if (followUpExamination.PatientFolder != null){
            this.PATIENTFOLDER1.Value = followUpExamination.PatientFolder.ToString(); //this.ParentGroup.Fields("PATIENTFOLDER").Value;
            }
#endregion PATIENTFOLDER BODY_PreScript
                }
            }

        }

        public PATIENTFOLDERGroup PATIENTFOLDER;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public FollowUpExaminationReport()
        {
            part2 = new part2Group(this,"part2");
            MAIN = new MAINGroup(part2,"MAIN");
            PATIENTHISTORY = new PATIENTHISTORYGroup(part2,"PATIENTHISTORY");
            COMPLAINT = new COMPLAINTGroup(part2,"COMPLAINT");
            PHYSICALEXAMINATION = new PHYSICALEXAMINATIONGroup(part2,"PHYSICALEXAMINATION");
            PATIENTFOLDER = new PATIENTFOLDERGroup(part2,"PATIENTFOLDER");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ObjectID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "FOLLOWUPEXAMINATIONREPORT";
            Caption = "Kontrol Muayenesi Sonuç Raporu";
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