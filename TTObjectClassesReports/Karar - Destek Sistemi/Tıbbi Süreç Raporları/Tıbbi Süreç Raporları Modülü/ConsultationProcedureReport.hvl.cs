
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
    /// Konsültasyon Raporu
    /// </summary>
    public partial class ConsultationProcedureReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("2c50e152-27aa-42eb-b3de-0d40a3af21aa");
        }

        public partial class TabHeaderGroup : TTReportGroup
        {
            public ConsultationProcedureReport MyParentReport
            {
                get { return (ConsultationProcedureReport)ParentReport; }
            }

            new public TabHeaderGroupHeader Header()
            {
                return (TabHeaderGroupHeader)_header;
            }

            new public TabHeaderGroupFooter Footer()
            {
                return (TabHeaderGroupFooter)_footer;
            }

            public TTReportField LOGO111 { get {return Header().LOGO111;} }
            public TTReportField XXXXXXBASLIK1 { get {return Header().XXXXXXBASLIK1;} }
            public TTReportField REPORTHEADER11 { get {return Header().REPORTHEADER11;} }
            public TabHeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TabHeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TabHeaderGroupHeader(this);
                _footer = new TabHeaderGroupFooter(this);

            }

            public partial class TabHeaderGroupHeader : TTReportSection
            {
                public ConsultationProcedureReport MyParentReport
                {
                    get { return (ConsultationProcedureReport)ParentReport; }
                }
                
                public TTReportField LOGO111;
                public TTReportField XXXXXXBASLIK1;
                public TTReportField REPORTHEADER11; 
                public TabHeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 40;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 50, 28, false);
                    LOGO111.Name = "LOGO111";
                    LOGO111.TextFont.CharSet = 1;
                    LOGO111.Value = @"Logo";

                    XXXXXXBASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 8, 171, 31, false);
                    XXXXXXBASLIK1.Name = "XXXXXXBASLIK1";
                    XXXXXXBASLIK1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK1.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.TextFont.Name = "Arial Narrow";
                    XXXXXXBASLIK1.TextFont.Size = 11;
                    XXXXXXBASLIK1.TextFont.Bold = true;
                    XXXXXXBASLIK1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    REPORTHEADER11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 32, 171, 40, false);
                    REPORTHEADER11.Name = "REPORTHEADER11";
                    REPORTHEADER11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER11.TextFont.Name = "Arial Narrow";
                    REPORTHEADER11.TextFont.Size = 15;
                    REPORTHEADER11.TextFont.Bold = true;
                    REPORTHEADER11.Value = @"KONSÜLTASYON RAPORU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO111.CalcValue = LOGO111.Value;
                    REPORTHEADER11.CalcValue = REPORTHEADER11.Value;
                    XXXXXXBASLIK1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { LOGO111,REPORTHEADER11,XXXXXXBASLIK1};
                }
            }
            public partial class TabHeaderGroupFooter : TTReportSection
            {
                public ConsultationProcedureReport MyParentReport
                {
                    get { return (ConsultationProcedureReport)ParentReport; }
                }
                 
                public TabHeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public TabHeaderGroup TabHeader;

        public partial class part2Group : TTReportGroup
        {
            public ConsultationProcedureReport MyParentReport
            {
                get { return (ConsultationProcedureReport)ParentReport; }
            }

            new public part2GroupHeader Header()
            {
                return (part2GroupHeader)_header;
            }

            new public part2GroupFooter Footer()
            {
                return (part2GroupFooter)_footer;
            }

            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField CONSULTATIONDATE { get {return Header().CONSULTATIONDATE;} }
            public TTReportField NewField35 { get {return Header().NewField35;} }
            public TTReportField CONSULTATIONREQUESTPROCEDUREDOCTOR { get {return Header().CONSULTATIONREQUESTPROCEDUREDOCTOR;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField23 { get {return Header().NewField23;} }
            public TTReportField CONSULTATIONREQUESTMASTERRESOURCE { get {return Header().CONSULTATIONREQUESTMASTERRESOURCE;} }
            public TTReportField NewField31 { get {return Header().NewField31;} }
            public TTReportField NewField32 { get {return Header().NewField32;} }
            public TTReportField MASTERRESOURCENAME { get {return Header().MASTERRESOURCENAME;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField24 { get {return Header().NewField24;} }
            public TTReportField DYERVETARIH { get {return Header().DYERVETARIH;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField BABAAD { get {return Header().BABAAD;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField1151 { get {return Header().NewField1151;} }
            public TTReportField NewField1171 { get {return Header().NewField1171;} }
            public TTReportField NewField1181 { get {return Header().NewField1181;} }
            public TTReportField FULLSINIFRUTBE { get {return Header().FULLSINIFRUTBE;} }
            public TTReportField BIRLIK { get {return Header().BIRLIK;} }
            public TTReportField NewField1341 { get {return Header().NewField1341;} }
            public TTReportField NewField1331 { get {return Header().NewField1331;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField LBLUNIQUEREFNO { get {return Header().LBLUNIQUEREFNO;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField PROTOKOLNO { get {return Header().PROTOKOLNO;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField HASTANO { get {return Header().HASTANO;} }
            public TTReportField NewField1241 { get {return Header().NewField1241;} }
            public TTReportField ACTIONID { get {return Header().ACTIONID;} }
            public TTReportField NewField1261 { get {return Header().NewField1261;} }
            public TTReportField TARIH { get {return Header().TARIH;} }
            public TTReportField NewField1271 { get {return Header().NewField1271;} }
            public TTReportField NewField11221 { get {return Header().NewField11221;} }
            public TTReportField NewField11231 { get {return Header().NewField11231;} }
            public TTReportField NewField11241 { get {return Header().NewField11241;} }
            public TTReportField NewField11251 { get {return Header().NewField11251;} }
            public TTReportField SEX { get {return Header().SEX;} }
            public TTReportField NewField1191 { get {return Header().NewField1191;} }
            public TTReportField NewField11711 { get {return Header().NewField11711;} }
            public TTReportField DTARIH { get {return Header().DTARIH;} }
            public TTReportField DYER { get {return Header().DYER;} }
            public TTReportField EPISODEID { get {return Header().EPISODEID;} }
            public TTReportField EPISODEOBJECTID { get {return Header().EPISODEOBJECTID;} }
            public TTReportField PREDIAGNOSIS { get {return Header().PREDIAGNOSIS;} }
            public TTReportField NewField1381 { get {return Header().NewField1381;} }
            public TTReportShape NewLine131 { get {return Header().NewLine131;} }
            public TTReportField SECDIAGNOSIS { get {return Header().SECDIAGNOSIS;} }
            public TTReportField NewField91 { get {return Footer().NewField91;} }
            public TTReportField NewField10 { get {return Footer().NewField10;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
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
                list[0] = new TTReportNqlData<ConsultationProcedure.GetConsultationProcedureNQL_Class>("GetConsultationProcedureNQL", ConsultationProcedure.GetConsultationProcedureNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public ConsultationProcedureReport MyParentReport
                {
                    get { return (ConsultationProcedureReport)ParentReport; }
                }
                
                public TTReportField NewField22;
                public TTReportField CONSULTATIONDATE;
                public TTReportField NewField35;
                public TTReportField CONSULTATIONREQUESTPROCEDUREDOCTOR;
                public TTReportField NewField14;
                public TTReportField NewField23;
                public TTReportField CONSULTATIONREQUESTMASTERRESOURCE;
                public TTReportField NewField31;
                public TTReportField NewField32;
                public TTReportField MASTERRESOURCENAME;
                public TTReportField NewField18;
                public TTReportField NewField24;
                public TTReportField DYERVETARIH;
                public TTReportField NewField181;
                public TTReportField NewField191;
                public TTReportField BABAAD;
                public TTReportField ADSOYAD;
                public TTReportField NewField1121;
                public TTReportField NewField1131;
                public TTReportField NewField1141;
                public TTReportField NewField1151;
                public TTReportField NewField1171;
                public TTReportField NewField1181;
                public TTReportField FULLSINIFRUTBE;
                public TTReportField BIRLIK;
                public TTReportField NewField1341;
                public TTReportField NewField1331;
                public TTReportField UNIQUEREFNO;
                public TTReportField LBLUNIQUEREFNO;
                public TTReportField NewField11311;
                public TTReportField PROTOKOLNO;
                public TTReportField NewField1221;
                public TTReportField HASTANO;
                public TTReportField NewField1241;
                public TTReportField ACTIONID;
                public TTReportField NewField1261;
                public TTReportField TARIH;
                public TTReportField NewField1271;
                public TTReportField NewField11221;
                public TTReportField NewField11231;
                public TTReportField NewField11241;
                public TTReportField NewField11251;
                public TTReportField SEX;
                public TTReportField NewField1191;
                public TTReportField NewField11711;
                public TTReportField DTARIH;
                public TTReportField DYER;
                public TTReportField EPISODEID;
                public TTReportField EPISODEOBJECTID;
                public TTReportField PREDIAGNOSIS;
                public TTReportField NewField1381;
                public TTReportShape NewLine131;
                public TTReportField SECDIAGNOSIS; 
                public part2GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 137;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 84, 60, 89, false);
                    NewField22.Name = "NewField22";
                    NewField22.TextFont.Name = "Arial Narrow";
                    NewField22.TextFont.Size = 9;
                    NewField22.TextFont.Bold = true;
                    NewField22.Value = @"Konsültasyon Tarihi";

                    CONSULTATIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 84, 100, 89, false);
                    CONSULTATIONDATE.Name = "CONSULTATIONDATE";
                    CONSULTATIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSULTATIONDATE.TextFormat = @"g";
                    CONSULTATIONDATE.TextFont.Name = "Arial Narrow";
                    CONSULTATIONDATE.TextFont.Size = 9;
                    CONSULTATIONDATE.Value = @"{#CONSULTATIONDATE#}";

                    NewField35 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 84, 62, 89, false);
                    NewField35.Name = "NewField35";
                    NewField35.TextFont.Name = "Arial Narrow";
                    NewField35.TextFont.Size = 9;
                    NewField35.TextFont.Bold = true;
                    NewField35.Value = @":";

                    CONSULTATIONREQUESTPROCEDUREDOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 94, 210, 99, false);
                    CONSULTATIONREQUESTPROCEDUREDOCTOR.Name = "CONSULTATIONREQUESTPROCEDUREDOCTOR";
                    CONSULTATIONREQUESTPROCEDUREDOCTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSULTATIONREQUESTPROCEDUREDOCTOR.TextFont.Name = "Arial Narrow";
                    CONSULTATIONREQUESTPROCEDUREDOCTOR.TextFont.Size = 9;
                    CONSULTATIONREQUESTPROCEDUREDOCTOR.Value = @"{#CONSREQUESTPROCEDUREDOCTOR#}";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 94, 60, 99, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Name = "Arial Narrow";
                    NewField14.TextFont.Size = 9;
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @"İstek Yapan Doktor";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 94, 62, 99, false);
                    NewField23.Name = "NewField23";
                    NewField23.TextFont.Name = "Arial Narrow";
                    NewField23.TextFont.Size = 9;
                    NewField23.TextFont.Bold = true;
                    NewField23.Value = @":";

                    CONSULTATIONREQUESTMASTERRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 89, 210, 94, false);
                    CONSULTATIONREQUESTMASTERRESOURCE.Name = "CONSULTATIONREQUESTMASTERRESOURCE";
                    CONSULTATIONREQUESTMASTERRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSULTATIONREQUESTMASTERRESOURCE.TextFont.Name = "Arial Narrow";
                    CONSULTATIONREQUESTMASTERRESOURCE.TextFont.Size = 9;
                    CONSULTATIONREQUESTMASTERRESOURCE.Value = @"{#CONSREQUESTMASTERRESOURCE#}";

                    NewField31 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 89, 60, 94, false);
                    NewField31.Name = "NewField31";
                    NewField31.TextFont.Name = "Arial Narrow";
                    NewField31.TextFont.Size = 9;
                    NewField31.TextFont.Bold = true;
                    NewField31.Value = @"İsteyen Bölüm";

                    NewField32 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 89, 62, 94, false);
                    NewField32.Name = "NewField32";
                    NewField32.TextFont.Name = "Arial Narrow";
                    NewField32.TextFont.Size = 9;
                    NewField32.TextFont.Bold = true;
                    NewField32.Value = @":";

                    MASTERRESOURCENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 99, 210, 104, false);
                    MASTERRESOURCENAME.Name = "MASTERRESOURCENAME";
                    MASTERRESOURCENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MASTERRESOURCENAME.TextFont.Name = "Arial Narrow";
                    MASTERRESOURCENAME.TextFont.Size = 9;
                    MASTERRESOURCENAME.Value = @"{#MASTERRESOURCENAME#}";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 99, 60, 104, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Name = "Arial Narrow";
                    NewField18.TextFont.Size = 9;
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @"İstenen Bölüm";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 99, 62, 104, false);
                    NewField24.Name = "NewField24";
                    NewField24.TextFont.Name = "Arial Narrow";
                    NewField24.TextFont.Size = 9;
                    NewField24.TextFont.Bold = true;
                    NewField24.Value = @":";

                    DYERVETARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 70, 128, 75, false);
                    DYERVETARIH.Name = "DYERVETARIH";
                    DYERVETARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERVETARIH.TextFont.Name = "Arial Narrow";
                    DYERVETARIH.TextFont.Size = 9;
                    DYERVETARIH.Value = @"{%DTARIH%}";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 55, 60, 60, false);
                    NewField181.Name = "NewField181";
                    NewField181.TextFont.Name = "Arial Narrow";
                    NewField181.TextFont.Size = 9;
                    NewField181.TextFont.Bold = true;
                    NewField181.Value = @"Sınıf ve Rütbesi";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 70, 60, 75, false);
                    NewField191.Name = "NewField191";
                    NewField191.TextFont.Name = "Arial Narrow";
                    NewField191.TextFont.Size = 9;
                    NewField191.TextFont.Bold = true;
                    NewField191.Value = @"Doğum Tarihi";

                    BABAAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 65, 128, 70, false);
                    BABAAD.Name = "BABAAD";
                    BABAAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAAD.TextFont.Name = "Arial Narrow";
                    BABAAD.TextFont.Size = 9;
                    BABAAD.Value = @"{#FATHERNAME#}";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 50, 128, 55, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.Name = "Arial Narrow";
                    ADSOYAD.TextFont.Size = 9;
                    ADSOYAD.Value = @"{#NAME#}  {#SURNAME#}";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 50, 60, 55, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Name = "Arial Narrow";
                    NewField1121.TextFont.Size = 9;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.Value = @"Adı Soyadı";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 55, 62, 60, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Name = "Arial Narrow";
                    NewField1131.TextFont.Size = 9;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.Value = @":";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 50, 62, 55, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Name = "Arial Narrow";
                    NewField1141.TextFont.Size = 9;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.Value = @":";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 65, 60, 70, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.TextFont.Name = "Arial Narrow";
                    NewField1151.TextFont.Size = 9;
                    NewField1151.TextFont.Bold = true;
                    NewField1151.Value = @"Baba Adı";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 70, 62, 75, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.TextFont.Name = "Arial Narrow";
                    NewField1171.TextFont.Size = 9;
                    NewField1171.TextFont.Bold = true;
                    NewField1171.Value = @":";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 65, 62, 70, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.TextFont.Name = "Arial Narrow";
                    NewField1181.TextFont.Size = 9;
                    NewField1181.TextFont.Bold = true;
                    NewField1181.Value = @":";

                    FULLSINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 55, 128, 60, false);
                    FULLSINIFRUTBE.Name = "FULLSINIFRUTBE";
                    FULLSINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLSINIFRUTBE.TextFont.Name = "Arial Narrow";
                    FULLSINIFRUTBE.TextFont.Size = 9;
                    FULLSINIFRUTBE.Value = @"";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 60, 128, 65, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.TextFont.Name = "Arial Narrow";
                    BIRLIK.TextFont.Size = 9;
                    BIRLIK.Value = @"";

                    NewField1341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 60, 60, 65, false);
                    NewField1341.Name = "NewField1341";
                    NewField1341.TextFont.Name = "Arial Narrow";
                    NewField1341.TextFont.Size = 9;
                    NewField1341.TextFont.Bold = true;
                    NewField1341.Value = @"Birliği";

                    NewField1331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 60, 62, 65, false);
                    NewField1331.Name = "NewField1331";
                    NewField1331.TextFont.Name = "Arial Narrow";
                    NewField1331.TextFont.Size = 9;
                    NewField1331.TextFont.Bold = true;
                    NewField1331.Value = @":";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 45, 128, 50, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.Value = @"";

                    LBLUNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 45, 61, 50, false);
                    LBLUNIQUEREFNO.Name = "LBLUNIQUEREFNO";
                    LBLUNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    LBLUNIQUEREFNO.TextFont.Size = 9;
                    LBLUNIQUEREFNO.TextFont.Bold = true;
                    LBLUNIQUEREFNO.Value = @"T.C. Kimlik No";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 45, 62, 50, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311.TextFont.Name = "Arial Narrow";
                    NewField11311.TextFont.Size = 9;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.Value = @":";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 50, 210, 55, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.Name = "Arial Narrow";
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.Value = @"{#PROTOCOLNO#}";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 50, 180, 55, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.Name = "Arial Narrow";
                    NewField1221.TextFont.Size = 9;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.Value = @"Protokol No";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 55, 210, 60, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.ObjectDefName = "ConsultationProcedure";
                    HASTANO.DataMember = "EPISODE.PATIENT.ID";
                    HASTANO.TextFont.Name = "Arial Narrow";
                    HASTANO.TextFont.Size = 9;
                    HASTANO.Value = @"{@TTOBJECTID@}";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 55, 180, 60, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.TextFont.Name = "Arial Narrow";
                    NewField1241.TextFont.Size = 9;
                    NewField1241.TextFont.Bold = true;
                    NewField1241.Value = @"Hasta No";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 60, 210, 65, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.TextFont.Name = "Arial Narrow";
                    ACTIONID.TextFont.Size = 9;
                    ACTIONID.Value = @"{#ACTIONID#}";

                    NewField1261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 60, 180, 65, false);
                    NewField1261.Name = "NewField1261";
                    NewField1261.TextFont.Name = "Arial Narrow";
                    NewField1261.TextFont.Size = 9;
                    NewField1261.TextFont.Bold = true;
                    NewField1261.Value = @"İşlem No";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 45, 210, 50, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"g";
                    TARIH.TextFont.Name = "Arial Narrow";
                    TARIH.TextFont.Size = 9;
                    TARIH.Value = @"{#EPISODEACTIONREQUESTDATE#}";

                    NewField1271 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 45, 180, 50, false);
                    NewField1271.Name = "NewField1271";
                    NewField1271.TextFont.Name = "Arial Narrow";
                    NewField1271.TextFont.Size = 9;
                    NewField1271.TextFont.Bold = true;
                    NewField1271.Value = @"İstek Tarihi";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 60, 182, 65, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11221.TextFont.Name = "Arial Narrow";
                    NewField11221.TextFont.Size = 9;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.Value = @":";

                    NewField11231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 55, 182, 60, false);
                    NewField11231.Name = "NewField11231";
                    NewField11231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11231.TextFont.Name = "Arial Narrow";
                    NewField11231.TextFont.Size = 9;
                    NewField11231.TextFont.Bold = true;
                    NewField11231.Value = @":";

                    NewField11241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 50, 182, 55, false);
                    NewField11241.Name = "NewField11241";
                    NewField11241.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11241.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11241.TextFont.Name = "Arial Narrow";
                    NewField11241.TextFont.Size = 9;
                    NewField11241.TextFont.Bold = true;
                    NewField11241.Value = @":";

                    NewField11251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 45, 182, 50, false);
                    NewField11251.Name = "NewField11251";
                    NewField11251.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11251.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11251.TextFont.Name = "Arial Narrow";
                    NewField11251.TextFont.Size = 9;
                    NewField11251.TextFont.Bold = true;
                    NewField11251.Value = @":";

                    SEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 75, 128, 80, false);
                    SEX.Name = "SEX";
                    SEX.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEX.TextFont.Name = "Arial Narrow";
                    SEX.TextFont.Size = 9;
                    SEX.Value = @"{#SEX#}";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 75, 60, 80, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.TextFont.Name = "Arial Narrow";
                    NewField1191.TextFont.Size = 9;
                    NewField1191.TextFont.Bold = true;
                    NewField1191.Value = @"Cinsiyeti";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 75, 62, 80, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.TextFont.Name = "Arial Narrow";
                    NewField11711.TextFont.Size = 9;
                    NewField11711.TextFont.Bold = true;
                    NewField11711.Value = @":";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 32, 263, 37, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"Short Date";
                    DTARIH.TextFont.Name = "Arial Narrow";
                    DTARIH.TextFont.Size = 9;
                    DTARIH.Value = @"{#BIRTHDATE#}";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 37, 263, 42, false);
                    DYER.Name = "DYER";
                    DYER.Visible = EvetHayirEnum.ehHayir;
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.TextFont.Name = "Arial Narrow";
                    DYER.TextFont.Size = 9;
                    DYER.Value = @"{#CITYOFBIRTH#}";

                    EPISODEID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 22, 274, 27, false);
                    EPISODEID.Name = "EPISODEID";
                    EPISODEID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEID.ObjectDefName = "ConsultationProcedure";
                    EPISODEID.DataMember = "EPISODE.ID";
                    EPISODEID.TextFont.Name = "Arial Narrow";
                    EPISODEID.TextFont.Size = 9;
                    EPISODEID.Value = @"{@TTOBJECTID@}";

                    EPISODEOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 27, 274, 32, false);
                    EPISODEOBJECTID.Name = "EPISODEOBJECTID";
                    EPISODEOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEOBJECTID.TextFont.Name = "Arial Narrow";
                    EPISODEOBJECTID.TextFont.Size = 9;
                    EPISODEOBJECTID.Value = @"{#EPISODEOBJECTID#}";

                    PREDIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 112, 210, 117, false);
                    PREDIAGNOSIS.Name = "PREDIAGNOSIS";
                    PREDIAGNOSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PREDIAGNOSIS.MultiLine = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.NoClip = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.WordBreak = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.ExpandTabs = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.TextFont.Name = "Arial Narrow";
                    PREDIAGNOSIS.TextFont.Size = 9;
                    PREDIAGNOSIS.Value = @"";

                    NewField1381 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 107, 61, 111, false);
                    NewField1381.Name = "NewField1381";
                    NewField1381.TextFont.Name = "Arial Narrow";
                    NewField1381.TextFont.Size = 9;
                    NewField1381.TextFont.Bold = true;
                    NewField1381.Value = @"Ön Tanı";

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 111, 61, 111, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    SECDIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 43, 275, 52, false);
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
                    ConsultationProcedure.GetConsultationProcedureNQL_Class dataset_GetConsultationProcedureNQL = ParentGroup.rsGroup.GetCurrentRecord<ConsultationProcedure.GetConsultationProcedureNQL_Class>(0);
                    NewField22.CalcValue = NewField22.Value;
                    CONSULTATIONDATE.CalcValue = (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.Consultationdate) : "");
                    NewField35.CalcValue = NewField35.Value;
                    CONSULTATIONREQUESTPROCEDUREDOCTOR.CalcValue = (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.Consrequestproceduredoctor) : "");
                    NewField14.CalcValue = NewField14.Value;
                    NewField23.CalcValue = NewField23.Value;
                    CONSULTATIONREQUESTMASTERRESOURCE.CalcValue = (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.Consrequestmasterresource) : "");
                    NewField31.CalcValue = NewField31.Value;
                    NewField32.CalcValue = NewField32.Value;
                    MASTERRESOURCENAME.CalcValue = (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.Masterresourcename) : "");
                    NewField18.CalcValue = NewField18.Value;
                    NewField24.CalcValue = NewField24.Value;
                    DTARIH.CalcValue = (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.BirthDate) : "");
                    DYERVETARIH.CalcValue = MyParentReport.part2.DTARIH.FormattedValue;
                    NewField181.CalcValue = NewField181.Value;
                    NewField191.CalcValue = NewField191.Value;
                    BABAAD.CalcValue = (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.FatherName) : "");
                    ADSOYAD.CalcValue = (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.Name) : "") + @"  " + (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.Surname) : "");
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    FULLSINIFRUTBE.CalcValue = @"";
                    BIRLIK.CalcValue = @"";
                    NewField1341.CalcValue = NewField1341.Value;
                    NewField1331.CalcValue = NewField1331.Value;
                    UNIQUEREFNO.CalcValue = @"";
                    LBLUNIQUEREFNO.CalcValue = LBLUNIQUEREFNO.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    PROTOKOLNO.CalcValue = (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.ProtocolNo) : "");
                    NewField1221.CalcValue = NewField1221.Value;
                    HASTANO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    HASTANO.PostFieldValueCalculation();
                    NewField1241.CalcValue = NewField1241.Value;
                    ACTIONID.CalcValue = (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.Actionid) : "");
                    NewField1261.CalcValue = NewField1261.Value;
                    TARIH.CalcValue = (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.Episodeactionrequestdate) : "");
                    NewField1271.CalcValue = NewField1271.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField11231.CalcValue = NewField11231.Value;
                    NewField11241.CalcValue = NewField11241.Value;
                    NewField11251.CalcValue = NewField11251.Value;
                    SEX.CalcValue = (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.Sex) : "");
                    NewField1191.CalcValue = NewField1191.Value;
                    NewField11711.CalcValue = NewField11711.Value;
                    DYER.CalcValue = (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.Cityofbirth) : "");
                    EPISODEID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    EPISODEID.PostFieldValueCalculation();
                    EPISODEOBJECTID.CalcValue = (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.Episodeobjectid) : "");
                    PREDIAGNOSIS.CalcValue = @"";
                    NewField1381.CalcValue = NewField1381.Value;
                    SECDIAGNOSIS.CalcValue = @"";
                    return new TTReportObject[] { NewField22,CONSULTATIONDATE,NewField35,CONSULTATIONREQUESTPROCEDUREDOCTOR,NewField14,NewField23,CONSULTATIONREQUESTMASTERRESOURCE,NewField31,NewField32,MASTERRESOURCENAME,NewField18,NewField24,DTARIH,DYERVETARIH,NewField181,NewField191,BABAAD,ADSOYAD,NewField1121,NewField1131,NewField1141,NewField1151,NewField1171,NewField1181,FULLSINIFRUTBE,BIRLIK,NewField1341,NewField1331,UNIQUEREFNO,LBLUNIQUEREFNO,NewField11311,PROTOKOLNO,NewField1221,HASTANO,NewField1241,ACTIONID,NewField1261,TARIH,NewField1271,NewField11221,NewField11231,NewField11241,NewField11251,SEX,NewField1191,NewField11711,DYER,EPISODEID,EPISODEOBJECTID,PREDIAGNOSIS,NewField1381,SECDIAGNOSIS};
                }

                public override void RunScript()
                {
#region PART2 HEADER_Script
                    int cnt = 1;
            TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((ConsultationProcedureReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            ConsultationProcedure consultationProcedure = (ConsultationProcedure)objectContext.GetObject(new Guid(objectID),"ConsultationProcedure");
            
            if (consultationProcedure==null)
                throw new Exception("Rapor, Konsültasyon modülü üzerinden alınmalıdır.");
            
            Episode episode = consultationProcedure.Episode;
//            this.BIRLIK.CalcValue = (episode.MilitaryUnit == null ? (episode.Patient.MilitaryUnit == null ? "" : episode.Patient.MilitaryUnit.Name) : episode.MilitaryUnit.Name);
            
            this.PREDIAGNOSIS.CalcValue = "";
            BindingList<DiagnosisGrid.GetPreDiagnosisBySubactionProcedure_Class> preDiagnosis = null;
            preDiagnosis = DiagnosisGrid.GetPreDiagnosisBySubactionProcedure(consultationProcedure.ObjectID.ToString());
            foreach(DiagnosisGrid.GetPreDiagnosisBySubactionProcedure_Class preDiagnosisGrid in preDiagnosis)
            {
                this.PREDIAGNOSIS.CalcValue += cnt + ". " + preDiagnosisGrid.Code + " " + preDiagnosisGrid.Diagnosename;
                this.PREDIAGNOSIS.CalcValue += "\r\n";
                cnt++;
            }
            
            cnt = 1;
            this.SECDIAGNOSIS.CalcValue = "";
            BindingList<DiagnosisGrid.GetSecDiagnosisBySubactionProcedure_Class> secDiagnosis = null;
            secDiagnosis = DiagnosisGrid.GetSecDiagnosisBySubactionProcedure(consultationProcedure.ObjectID.ToString());
            foreach(DiagnosisGrid.GetSecDiagnosisBySubactionProcedure_Class secDiagnosisGrid in secDiagnosis)
            {
                this.SECDIAGNOSIS.CalcValue += cnt + ". " + secDiagnosisGrid.Code + " " + secDiagnosisGrid.Diagnosename;
                this.SECDIAGNOSIS.CalcValue += "\r\n";
                cnt++;
            }
            
            if (consultationProcedure.Episode.Patient.Foreign == true)
            {
                this.UNIQUEREFNO.CalcValue = consultationProcedure.Episode.Patient.ForeignUniqueRefNo.ToString();
                this.LBLUNIQUEREFNO.CalcValue = "Kimlik/Sigorta No (Yabancı Hasta)";
            }
            else
            {
                this.UNIQUEREFNO.CalcValue = consultationProcedure.Episode.Patient.UniqueRefNo.ToString();
                this.LBLUNIQUEREFNO.CalcValue = "T.C. Kimlik No";
            }
#endregion PART2 HEADER_Script
                }
            }
            public partial class part2GroupFooter : TTReportSection
            {
                public ConsultationProcedureReport MyParentReport
                {
                    get { return (ConsultationProcedureReport)ParentReport; }
                }
                
                public TTReportField NewField91;
                public TTReportField NewField10;
                public TTReportShape NewLine121;
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

                    Height = 41;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField91 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 51, 6, false);
                    NewField91.Name = "NewField91";
                    NewField91.TextFont.Name = "Arial Narrow";
                    NewField91.TextFont.Size = 9;
                    NewField91.TextFont.Bold = true;
                    NewField91.Value = @"Muayene edildi. R.V.";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 83, 13, false);
                    NewField10.Name = "NewField10";
                    NewField10.TextFont.Name = "Arial Narrow";
                    NewField10.TextFont.Size = 9;
                    NewField10.TextFont.Bold = true;
                    NewField10.Value = @"Konsültasyonu Yapan Tabip";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 7, 206, 7, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    DIPSIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 21, 83, 25, false);
                    DIPSIC.Name = "DIPSIC";
                    DIPSIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSIC.TextFont.Name = "Arial Narrow";
                    DIPSIC.TextFont.Size = 9;
                    DIPSIC.Value = @"";

                    ADSOYADDOC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 13, 83, 17, false);
                    ADSOYADDOC.Name = "ADSOYADDOC";
                    ADSOYADDOC.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC.TextFont.Name = "Arial Narrow";
                    ADSOYADDOC.TextFont.Size = 9;
                    ADSOYADDOC.Value = @"{#PROCEDUREDOCTORNAME#}";

                    UZMANLIKDAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 14, 202, 18, false);
                    UZMANLIKDAL.Name = "UZMANLIKDAL";
                    UZMANLIKDAL.Visible = EvetHayirEnum.ehHayir;
                    UZMANLIKDAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIKDAL.MultiLine = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.NoClip = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.WordBreak = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.TextFont.Name = "Arial Narrow";
                    UZMANLIKDAL.TextFont.Size = 9;
                    UZMANLIKDAL.Value = @"{#DOCSPECIALITY#}";

                    DIPSICLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 21, 32, 25, false);
                    DIPSICLABEL.Name = "DIPSICLABEL";
                    DIPSICLABEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSICLABEL.TextFont.Name = "Arial Narrow";
                    DIPSICLABEL.TextFont.Size = 9;
                    DIPSICLABEL.Value = @"DIPLOMASICIL";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 17, 83, 21, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.TextFont.Name = "Arial Narrow";
                    SINRUT.TextFont.Size = 9;
                    SINRUT.Value = @"";

                    RUTBEONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 18, 149, 22, false);
                    RUTBEONAY.Name = "RUTBEONAY";
                    RUTBEONAY.Visible = EvetHayirEnum.ehHayir;
                    RUTBEONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBEONAY.MultiLine = EvetHayirEnum.ehEvet;
                    RUTBEONAY.TextFont.Name = "Arial Narrow";
                    RUTBEONAY.TextFont.Size = 9;
                    RUTBEONAY.Value = @"{#DOKRANK#}";

                    SINIFONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 13, 175, 18, false);
                    SINIFONAY.Name = "SINIFONAY";
                    SINIFONAY.Visible = EvetHayirEnum.ehHayir;
                    SINIFONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFONAY.TextFont.Name = "Arial Narrow";
                    SINIFONAY.TextFont.Size = 9;
                    SINIFONAY.Value = @"{#DOCMILITARYCLASS#}";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 25, 83, 29, false);
                    UZ.Name = "UZ";
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.TextFont.Name = "Arial Narrow";
                    UZ.TextFont.Size = 9;
                    UZ.Value = @"{%UZMANLIKDAL%}";

                    GOREV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 13, 149, 18, false);
                    GOREV.Name = "GOREV";
                    GOREV.Visible = EvetHayirEnum.ehHayir;
                    GOREV.FieldType = ReportFieldTypeEnum.ftVariable;
                    GOREV.TextFont.Name = "Arial Narrow";
                    GOREV.TextFont.Size = 9;
                    GOREV.Value = @"{#DOCWORK#}";

                    DIPLOMANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 22, 203, 26, false);
                    DIPLOMANO.Name = "DIPLOMANO";
                    DIPLOMANO.Visible = EvetHayirEnum.ehHayir;
                    DIPLOMANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMANO.TextFont.Name = "Arial Narrow";
                    DIPLOMANO.TextFont.Size = 9;
                    DIPLOMANO.Value = @"{#DOCDIPLOMANO#}";

                    SICILKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 18, 202, 22, false);
                    SICILKULLAN.Name = "SICILKULLAN";
                    SICILKULLAN.Visible = EvetHayirEnum.ehHayir;
                    SICILKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    SICILKULLAN.TextFont.Name = "Arial Narrow";
                    SICILKULLAN.TextFont.Size = 9;
                    SICILKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SICILKULLAN"", """")";

                    UNVANKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 22, 149, 26, false);
                    UNVANKULLAN.Name = "UNVANKULLAN";
                    UNVANKULLAN.Visible = EvetHayirEnum.ehHayir;
                    UNVANKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    UNVANKULLAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.TextFont.Name = "Arial Narrow";
                    UNVANKULLAN.TextFont.Size = 9;
                    UNVANKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""UNVANKULLAN"", """")";

                    UNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 18, 175, 23, false);
                    UNVAN.Name = "UNVAN";
                    UNVAN.Visible = EvetHayirEnum.ehHayir;
                    UNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNVAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVAN.TextFont.Name = "Arial Narrow";
                    UNVAN.TextFont.Size = 9;
                    UNVAN.Value = @"{#DOCTITLE#}";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 23, 176, 27, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.Visible = EvetHayirEnum.ehHayir;
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.TextFont.Name = "Arial Narrow";
                    SICILNO.TextFont.Size = 9;
                    SICILNO.Value = @"{#DOCEMPLOYMENTRECORDID#}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 8, 206, 13, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PrintDate.TextFont.Name = "Arial Narrow";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.Value = @"{@printdate@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 34, 120, 39, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PageNumber.TextFont.Name = "Arial Narrow";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ConsultationProcedure.GetConsultationProcedureNQL_Class dataset_GetConsultationProcedureNQL = ParentGroup.rsGroup.GetCurrentRecord<ConsultationProcedure.GetConsultationProcedureNQL_Class>(0);
                    NewField91.CalcValue = NewField91.Value;
                    NewField10.CalcValue = NewField10.Value;
                    DIPSIC.CalcValue = @"";
                    ADSOYADDOC.CalcValue = (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.Proceduredoctorname) : "");
                    UZMANLIKDAL.CalcValue = (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.Docspeciality) : "");
                    DIPSICLABEL.CalcValue = @"DIPLOMASICIL";
                    SINRUT.CalcValue = @"";
                    RUTBEONAY.CalcValue = (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.Dokrank) : "");
                    SINIFONAY.CalcValue = (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.Docmilitaryclass) : "");
                    UZ.CalcValue = MyParentReport.part2.UZMANLIKDAL.CalcValue;
                    GOREV.CalcValue = (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.Docwork) : "");
                    DIPLOMANO.CalcValue = (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.Docdiplomano) : "");
                    UNVAN.CalcValue = (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.Doctitle) : "");
                    SICILNO.CalcValue = (dataset_GetConsultationProcedureNQL != null ? Globals.ToStringCore(dataset_GetConsultationProcedureNQL.Docemploymentrecordid) : "");
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    SICILKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "");
                    UNVANKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "");
                    return new TTReportObject[] { NewField91,NewField10,DIPSIC,ADSOYADDOC,UZMANLIKDAL,DIPSICLABEL,SINRUT,RUTBEONAY,SINIFONAY,UZ,GOREV,DIPLOMANO,UNVAN,SICILNO,PrintDate,PageNumber,SICILKULLAN,UNVANKULLAN};
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
            public ConsultationProcedureReport MyParentReport
            {
                get { return (ConsultationProcedureReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SECDIAGNOSIS { get {return Body().SECDIAGNOSIS;} }
            public TTReportField NewField11831 { get {return Body().NewField11831;} }
            public TTReportShape NewLine1131 { get {return Body().NewLine1131;} }
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
                public ConsultationProcedureReport MyParentReport
                {
                    get { return (ConsultationProcedureReport)ParentReport; }
                }
                
                public TTReportField SECDIAGNOSIS;
                public TTReportField NewField11831;
                public TTReportShape NewLine1131; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    SECDIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 8, 210, 13, false);
                    SECDIAGNOSIS.Name = "SECDIAGNOSIS";
                    SECDIAGNOSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SECDIAGNOSIS.MultiLine = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.NoClip = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.WordBreak = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.ExpandTabs = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.TextFont.Name = "Arial Narrow";
                    SECDIAGNOSIS.TextFont.Size = 9;
                    SECDIAGNOSIS.Value = @"{%part2.SECDIAGNOSIS%}";

                    NewField11831 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 3, 61, 7, false);
                    NewField11831.Name = "NewField11831";
                    NewField11831.TextFont.Name = "Arial Narrow";
                    NewField11831.TextFont.Size = 9;
                    NewField11831.TextFont.Bold = true;
                    NewField11831.Value = @"Tanı";

                    NewLine1131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 7, 61, 7, false);
                    NewLine1131.Name = "NewLine1131";
                    NewLine1131.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SECDIAGNOSIS.CalcValue = MyParentReport.part2.SECDIAGNOSIS.CalcValue;
                    NewField11831.CalcValue = NewField11831.Value;
                    return new TTReportObject[] { SECDIAGNOSIS,NewField11831};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class REQUESTDESCGroup : TTReportGroup
        {
            public ConsultationProcedureReport MyParentReport
            {
                get { return (ConsultationProcedureReport)ParentReport; }
            }

            new public REQUESTDESCGroupBody Body()
            {
                return (REQUESTDESCGroupBody)_body;
            }
            public TTReportRTF REQUESTDESC { get {return Body().REQUESTDESC;} }
            public TTReportField NewField113811 { get {return Body().NewField113811;} }
            public TTReportShape NewLine11311 { get {return Body().NewLine11311;} }
            public TTReportField REQUESTDESCIPTION { get {return Body().REQUESTDESCIPTION;} }
            public REQUESTDESCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public REQUESTDESCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new REQUESTDESCGroupBody(this);
            }

            public partial class REQUESTDESCGroupBody : TTReportSection
            {
                public ConsultationProcedureReport MyParentReport
                {
                    get { return (ConsultationProcedureReport)ParentReport; }
                }
                
                public TTReportRTF REQUESTDESC;
                public TTReportField NewField113811;
                public TTReportShape NewLine11311;
                public TTReportField REQUESTDESCIPTION; 
                public REQUESTDESCGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 28;
                    RepeatCount = 0;
                    
                    REQUESTDESC = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 10, 6, 206, 12, false);
                    REQUESTDESC.Name = "REQUESTDESC";
                    REQUESTDESC.Value = @"";

                    NewField113811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 57, 5, false);
                    NewField113811.Name = "NewField113811";
                    NewField113811.TextFont.Name = "Arial Narrow";
                    NewField113811.TextFont.Size = 9;
                    NewField113811.TextFont.Bold = true;
                    NewField113811.Value = @"İstek Açıklaması";

                    NewLine11311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 5, 57, 5, false);
                    NewLine11311.Name = "NewLine11311";
                    NewLine11311.DrawStyle = DrawStyleConstants.vbSolid;

                    REQUESTDESCIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 17, 37, 22, false);
                    REQUESTDESCIPTION.Name = "REQUESTDESCIPTION";
                    REQUESTDESCIPTION.TextFont.Name = "Arial Narrow";
                    REQUESTDESCIPTION.TextFont.CharSet = 1;
                    REQUESTDESCIPTION.Value = @"NewField1";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REQUESTDESC.CalcValue = REQUESTDESC.Value;
                    NewField113811.CalcValue = NewField113811.Value;
                    REQUESTDESCIPTION.CalcValue = REQUESTDESCIPTION.Value;
                    return new TTReportObject[] { REQUESTDESC,NewField113811,REQUESTDESCIPTION};
                }

                public override void RunScript()
                {
#region REQUESTDESC BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((ConsultationProcedureReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            ConsultationProcedure consultationProcedure = (ConsultationProcedure)objectContext.GetObject(new Guid(objectID),"ConsultationProcedure");
            if(consultationProcedure.Consultation.RequestDescription != null)
                this.REQUESTDESC.Value = consultationProcedure.Consultation.RequestDescription.ToString();
#endregion REQUESTDESC BODY_Script
                }
            }

        }

        public REQUESTDESCGroup REQUESTDESC;

        public partial class RESULTANDOFFERSGroup : TTReportGroup
        {
            public ConsultationProcedureReport MyParentReport
            {
                get { return (ConsultationProcedureReport)ParentReport; }
            }

            new public RESULTANDOFFERSGroupBody Body()
            {
                return (RESULTANDOFFERSGroupBody)_body;
            }
            public TTReportRTF RESULTOFFERS { get {return Body().RESULTOFFERS;} }
            public TTReportField NewField1118311 { get {return Body().NewField1118311;} }
            public TTReportShape NewLine111311 { get {return Body().NewLine111311;} }
            public RESULTANDOFFERSGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public RESULTANDOFFERSGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new RESULTANDOFFERSGroupBody(this);
            }

            public partial class RESULTANDOFFERSGroupBody : TTReportSection
            {
                public ConsultationProcedureReport MyParentReport
                {
                    get { return (ConsultationProcedureReport)ParentReport; }
                }
                
                public TTReportRTF RESULTOFFERS;
                public TTReportField NewField1118311;
                public TTReportShape NewLine111311; 
                public RESULTANDOFFERSGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 13;
                    RepeatCount = 0;
                    
                    RESULTOFFERS = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 10, 6, 206, 12, false);
                    RESULTOFFERS.Name = "RESULTOFFERS";
                    RESULTOFFERS.Value = @"";

                    NewField1118311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 57, 5, false);
                    NewField1118311.Name = "NewField1118311";
                    NewField1118311.TextFont.Name = "Arial Narrow";
                    NewField1118311.TextFont.Size = 9;
                    NewField1118311.TextFont.Bold = true;
                    NewField1118311.Value = @"Konsültasyon Sonucu ve Öneriler";

                    NewLine111311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 5, 57, 5, false);
                    NewLine111311.Name = "NewLine111311";
                    NewLine111311.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RESULTOFFERS.CalcValue = RESULTOFFERS.Value;
                    NewField1118311.CalcValue = NewField1118311.Value;
                    return new TTReportObject[] { RESULTOFFERS,NewField1118311};
                }
                public override void RunPreScript()
                {
#region RESULTANDOFFERS BODY_PreScript
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((ConsultationProcedureReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            ConsultationProcedure consultationProcedure = (ConsultationProcedure)objectContext.GetObject(new Guid(objectID),"ConsultationProcedure");
            if(consultationProcedure.Consultation.ConsultationResultAndOffers != null)
                this.RESULTOFFERS.Value = consultationProcedure.Consultation.ConsultationResultAndOffers.ToString();
#endregion RESULTANDOFFERS BODY_PreScript
                }
            }

        }

        public RESULTANDOFFERSGroup RESULTANDOFFERS;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ConsultationProcedureReport()
        {
            TabHeader = new TabHeaderGroup(this,"TabHeader");
            part2 = new part2Group(TabHeader,"part2");
            MAIN = new MAINGroup(part2,"MAIN");
            REQUESTDESC = new REQUESTDESCGroup(part2,"REQUESTDESC");
            RESULTANDOFFERS = new RESULTANDOFFERSGroup(part2,"RESULTANDOFFERS");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "2c50e152-27aa-42eb-b3de-0d40a3af21aa", "ObjectID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "CONSULTATIONPROCEDUREREPORT";
            Caption = "Konsültasyon Raporu";
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