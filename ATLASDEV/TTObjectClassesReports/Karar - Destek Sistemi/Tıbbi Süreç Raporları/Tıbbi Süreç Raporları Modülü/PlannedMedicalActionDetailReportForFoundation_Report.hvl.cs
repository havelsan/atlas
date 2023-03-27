
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
    /// Planlı Tıbbi İşlem Detayları Raporu(Kurum)
    /// </summary>
    public partial class PlannedMedicalActionDetailReportForFoundation : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("29035332-1b23-4773-8ed6-5e2be3f51570");
        }

        public partial class MASTERGroup : TTReportGroup
        {
            public PlannedMedicalActionDetailReportForFoundation MyParentReport
            {
                get { return (PlannedMedicalActionDetailReportForFoundation)ParentReport; }
            }

            new public MASTERGroupHeader Header()
            {
                return (MASTERGroupHeader)_header;
            }

            new public MASTERGroupFooter Footer()
            {
                return (MASTERGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField DTARIH { get {return Header().DTARIH;} }
            public TTReportField RUTBE { get {return Header().RUTBE;} }
            public TTReportField KABULSEBEBI { get {return Header().KABULSEBEBI;} }
            public TTReportField DYER { get {return Header().DYER;} }
            public TTReportField PROTOKOLNO { get {return Header().PROTOKOLNO;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField167 { get {return Header().NewField167;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField HASTANO { get {return Header().HASTANO;} }
            public TTReportField NewField24 { get {return Header().NewField24;} }
            public TTReportField ACTIONID { get {return Header().ACTIONID;} }
            public TTReportField NewField26 { get {return Header().NewField26;} }
            public TTReportField TARIH { get {return Header().TARIH;} }
            public TTReportField NewField27 { get {return Header().NewField27;} }
            public TTReportField DYERTAR { get {return Header().DYERTAR;} }
            public TTReportField PLANNEDMEDICACTIONREQOBJECTID { get {return Header().PLANNEDMEDICACTIONREQOBJECTID;} }
            public TTReportField AYAKTANYATAN { get {return Header().AYAKTANYATAN;} }
            public TTReportField EPISODEID { get {return Header().EPISODEID;} }
            public TTReportField LOGO1 { get {return Header().LOGO1;} }
            public TTReportField REPORTHEADER1 { get {return Header().REPORTHEADER1;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField123 { get {return Header().NewField123;} }
            public TTReportField NewField124 { get {return Header().NewField124;} }
            public TTReportField NewField125 { get {return Header().NewField125;} }
            public TTReportField EPISODEOBJECTID { get {return Header().EPISODEOBJECTID;} }
            public TTReportField AYAKYATANCODED { get {return Header().AYAKYATANCODED;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField LBLUNIQUEREFNO { get {return Header().LBLUNIQUEREFNO;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField0 { get {return Footer().NewField0;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
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
            public MASTERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MASTERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PlannedMedicalActionOrder.PlannedMedicalActionAcceptionReportNQL_Class>("PlannedMedicalActionAcceptionReportNQL", PlannedMedicalActionOrder.PlannedMedicalActionAcceptionReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new MASTERGroupHeader(this);
                _footer = new MASTERGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MASTERGroupHeader : TTReportSection
            {
                public PlannedMedicalActionDetailReportForFoundation MyParentReport
                {
                    get { return (PlannedMedicalActionDetailReportForFoundation)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField2;
                public TTReportField NAME;
                public TTReportField DTARIH;
                public TTReportField RUTBE;
                public TTReportField KABULSEBEBI;
                public TTReportField DYER;
                public TTReportField PROTOKOLNO;
                public TTReportField NewField16;
                public TTReportField NewField167;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField22;
                public TTReportField HASTANO;
                public TTReportField NewField24;
                public TTReportField ACTIONID;
                public TTReportField NewField26;
                public TTReportField TARIH;
                public TTReportField NewField27;
                public TTReportField DYERTAR;
                public TTReportField PLANNEDMEDICACTIONREQOBJECTID;
                public TTReportField AYAKTANYATAN;
                public TTReportField EPISODEID;
                public TTReportField LOGO1;
                public TTReportField REPORTHEADER1;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportField NewField123;
                public TTReportField NewField124;
                public TTReportField NewField125;
                public TTReportField EPISODEOBJECTID;
                public TTReportField AYAKYATANCODED;
                public TTReportField UNIQUEREFNO;
                public TTReportField LBLUNIQUEREFNO;
                public TTReportField NewField13; 
                public MASTERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 79;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 10, 168, 33, false);
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

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 47, 48, 52, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Size = 9;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"Hastanın";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 57, 133, 62, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.ObjectDefName = "PlannedMedicalActionOrder";
                    NAME.DataMember = "EPISODE.PATIENT.FullName";
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.Size = 9;
                    NAME.Value = @"{@TTOBJECTID@}";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 51, 255, 56, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"Short Date";
                    DTARIH.TextFont.Name = "Arial Narrow";
                    DTARIH.TextFont.Size = 9;
                    DTARIH.Value = @"{#BIRTHDATE#}";

                    RUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 67, 133, 72, false);
                    RUTBE.Name = "RUTBE";
                    RUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBE.TextFont.Name = "Arial Narrow";
                    RUTBE.TextFont.Size = 9;
                    RUTBE.Value = @"";

                    KABULSEBEBI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 72, 133, 77, false);
                    KABULSEBEBI.Name = "KABULSEBEBI";
                    KABULSEBEBI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KABULSEBEBI.TextFont.Name = "Arial Narrow";
                    KABULSEBEBI.TextFont.Size = 9;
                    KABULSEBEBI.Value = @"{#REASONFORADM#}";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 56, 255, 61, false);
                    DYER.Name = "DYER";
                    DYER.Visible = EvetHayirEnum.ehHayir;
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.TextFont.Name = "Arial Narrow";
                    DYER.TextFont.Size = 9;
                    DYER.Value = @"{#CITYNAME#}";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 57, 206, 62, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.Name = "Arial Narrow";
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.Value = @"{#PROTOCOLNO#}";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 57, 58, 62, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Name = "Arial Narrow";
                    NewField16.TextFont.Size = 9;
                    NewField16.TextFont.Bold = true;
                    NewField16.Value = @"Adı Soyadı";

                    NewField167 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 62, 58, 67, false);
                    NewField167.Name = "NewField167";
                    NewField167.TextFont.Name = "Arial Narrow";
                    NewField167.TextFont.Size = 9;
                    NewField167.TextFont.Bold = true;
                    NewField167.Value = @"Doğum Tarihi ve Yeri";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 67, 58, 72, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Name = "Arial Narrow";
                    NewField17.TextFont.Size = 9;
                    NewField17.TextFont.Bold = true;
                    NewField17.Value = @"Rütbesi";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 72, 58, 77, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Name = "Arial Narrow";
                    NewField18.TextFont.Size = 9;
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @"Kabul Sebebi";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 57, 167, 62, false);
                    NewField22.Name = "NewField22";
                    NewField22.TextFont.Name = "Arial Narrow";
                    NewField22.TextFont.Size = 9;
                    NewField22.TextFont.Bold = true;
                    NewField22.Value = @"Protokol No";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 62, 206, 67, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.ObjectDefName = "PlannedMedicalActionOrder";
                    HASTANO.DataMember = "EPISODE.PATIENT.ID";
                    HASTANO.TextFont.Name = "Arial Narrow";
                    HASTANO.TextFont.Size = 9;
                    HASTANO.Value = @"{@TTOBJECTID@}";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 62, 167, 67, false);
                    NewField24.Name = "NewField24";
                    NewField24.TextFont.Name = "Arial Narrow";
                    NewField24.TextFont.Size = 9;
                    NewField24.TextFont.Bold = true;
                    NewField24.Value = @"Hasta No";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 67, 206, 72, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.TextFont.Name = "Arial Narrow";
                    ACTIONID.TextFont.Size = 9;
                    ACTIONID.Value = @"{#ACTIONID#}";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 67, 167, 72, false);
                    NewField26.Name = "NewField26";
                    NewField26.TextFont.Name = "Arial Narrow";
                    NewField26.TextFont.Size = 9;
                    NewField26.TextFont.Bold = true;
                    NewField26.Value = @"İşlem No";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 52, 206, 57, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"g";
                    TARIH.TextFont.Name = "Arial Narrow";
                    TARIH.TextFont.Size = 9;
                    TARIH.Value = @"{#ACTIONDATE#}";

                    NewField27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 52, 167, 57, false);
                    NewField27.Name = "NewField27";
                    NewField27.TextFont.Name = "Arial Narrow";
                    NewField27.TextFont.Size = 9;
                    NewField27.TextFont.Bold = true;
                    NewField27.Value = @"Tarih";

                    DYERTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 62, 133, 67, false);
                    DYERTAR.Name = "DYERTAR";
                    DYERTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERTAR.TextFont.Name = "Arial Narrow";
                    DYERTAR.TextFont.Size = 9;
                    DYERTAR.Value = @"{%DTARIH%} / {%DYER%}";

                    PLANNEDMEDICACTIONREQOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 46, 255, 51, false);
                    PLANNEDMEDICACTIONREQOBJECTID.Name = "PLANNEDMEDICACTIONREQOBJECTID";
                    PLANNEDMEDICACTIONREQOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    PLANNEDMEDICACTIONREQOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PLANNEDMEDICACTIONREQOBJECTID.TextFont.Name = "Arial Narrow";
                    PLANNEDMEDICACTIONREQOBJECTID.TextFont.Size = 9;
                    PLANNEDMEDICACTIONREQOBJECTID.Value = @"{#PLANNEDMEDICACTIONREQOBJECTID#}";

                    AYAKTANYATAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 43, 168, 47, false);
                    AYAKTANYATAN.Name = "AYAKTANYATAN";
                    AYAKTANYATAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    AYAKTANYATAN.CaseFormat = CaseFormatEnum.fcUpperCase;
                    AYAKTANYATAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AYAKTANYATAN.TextFont.Name = "Arial Narrow";
                    AYAKTANYATAN.TextFont.Size = 9;
                    AYAKTANYATAN.TextFont.Bold = true;
                    AYAKTANYATAN.Value = @"{%AYAKYATANCODED%} HASTA";

                    EPISODEID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 32, 266, 37, false);
                    EPISODEID.Name = "EPISODEID";
                    EPISODEID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEID.ObjectDefName = "PlannedMedicalActionOrder";
                    EPISODEID.DataMember = "EPISODE.ID";
                    EPISODEID.TextFont.Name = "Arial Narrow";
                    EPISODEID.TextFont.Size = 9;
                    EPISODEID.Value = @"{@TTOBJECTID@}";

                    LOGO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 50, 30, false);
                    LOGO1.Name = "LOGO1";
                    LOGO1.TextFont.CharSet = 1;
                    LOGO1.Value = @"Logo";

                    REPORTHEADER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 33, 168, 39, false);
                    REPORTHEADER1.Name = "REPORTHEADER1";
                    REPORTHEADER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER1.TextFont.Name = "Arial Narrow";
                    REPORTHEADER1.TextFont.Size = 15;
                    REPORTHEADER1.TextFont.Bold = true;
                    REPORTHEADER1.Value = @"PLANLI TIBBİ İŞLEM DETAYLARI RAPORU";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 57, 60, 62, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @":";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 62, 60, 67, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial Narrow";
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @":";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 67, 60, 72, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial Narrow";
                    NewField12.TextFont.Size = 9;
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @":";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 72, 60, 77, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial Narrow";
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @":";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 67, 169, 72, false);
                    NewField122.Name = "NewField122";
                    NewField122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Name = "Arial Narrow";
                    NewField122.TextFont.Size = 9;
                    NewField122.TextFont.Bold = true;
                    NewField122.Value = @":";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 62, 169, 67, false);
                    NewField123.Name = "NewField123";
                    NewField123.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField123.TextFont.Name = "Arial Narrow";
                    NewField123.TextFont.Size = 9;
                    NewField123.TextFont.Bold = true;
                    NewField123.Value = @":";

                    NewField124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 57, 169, 62, false);
                    NewField124.Name = "NewField124";
                    NewField124.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField124.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField124.TextFont.Name = "Arial Narrow";
                    NewField124.TextFont.Size = 9;
                    NewField124.TextFont.Bold = true;
                    NewField124.Value = @":";

                    NewField125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 52, 169, 57, false);
                    NewField125.Name = "NewField125";
                    NewField125.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField125.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField125.TextFont.Name = "Arial Narrow";
                    NewField125.TextFont.Size = 9;
                    NewField125.TextFont.Bold = true;
                    NewField125.Value = @":";

                    EPISODEOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 37, 266, 42, false);
                    EPISODEOBJECTID.Name = "EPISODEOBJECTID";
                    EPISODEOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEOBJECTID.TextFont.Name = "Arial Narrow";
                    EPISODEOBJECTID.TextFont.Size = 9;
                    EPISODEOBJECTID.Value = @"{#EPISODEOBJECTID#}";

                    AYAKYATANCODED = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 42, 255, 46, false);
                    AYAKYATANCODED.Name = "AYAKYATANCODED";
                    AYAKYATANCODED.Visible = EvetHayirEnum.ehHayir;
                    AYAKYATANCODED.FieldType = ReportFieldTypeEnum.ftVariable;
                    AYAKYATANCODED.ObjectDefName = "PatientStatusEnum";
                    AYAKYATANCODED.DataMember = "DISPLAYTEXT";
                    AYAKYATANCODED.TextFont.Name = "Arial Narrow";
                    AYAKYATANCODED.TextFont.Size = 9;
                    AYAKYATANCODED.Value = @"{#PATIENTSTATUS#}";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 52, 133, 57, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.Value = @"{#UNIQUEREFNO#}";

                    LBLUNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 52, 58, 57, false);
                    LBLUNIQUEREFNO.Name = "LBLUNIQUEREFNO";
                    LBLUNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    LBLUNIQUEREFNO.TextFont.Size = 9;
                    LBLUNIQUEREFNO.TextFont.Bold = true;
                    LBLUNIQUEREFNO.Value = @"T.C. Kimlik No";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 52, 60, 57, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial Narrow";
                    NewField13.TextFont.Size = 9;
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PlannedMedicalActionOrder.PlannedMedicalActionAcceptionReportNQL_Class dataset_PlannedMedicalActionAcceptionReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PlannedMedicalActionOrder.PlannedMedicalActionAcceptionReportNQL_Class>(0);
                    NewField2.CalcValue = NewField2.Value;
                    NAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NAME.PostFieldValueCalculation();
                    DTARIH.CalcValue = (dataset_PlannedMedicalActionAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PlannedMedicalActionAcceptionReportNQL.BirthDate) : "");
                    RUTBE.CalcValue = @"";
                    KABULSEBEBI.CalcValue = (dataset_PlannedMedicalActionAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PlannedMedicalActionAcceptionReportNQL.Reasonforadm) : "");
                    DYER.CalcValue = (dataset_PlannedMedicalActionAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PlannedMedicalActionAcceptionReportNQL.Cityname) : "");
                    PROTOKOLNO.CalcValue = (dataset_PlannedMedicalActionAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PlannedMedicalActionAcceptionReportNQL.ProtocolNo) : "");
                    NewField16.CalcValue = NewField16.Value;
                    NewField167.CalcValue = NewField167.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField22.CalcValue = NewField22.Value;
                    HASTANO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    HASTANO.PostFieldValueCalculation();
                    NewField24.CalcValue = NewField24.Value;
                    ACTIONID.CalcValue = (dataset_PlannedMedicalActionAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PlannedMedicalActionAcceptionReportNQL.Actionid) : "");
                    NewField26.CalcValue = NewField26.Value;
                    TARIH.CalcValue = (dataset_PlannedMedicalActionAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PlannedMedicalActionAcceptionReportNQL.ActionDate) : "");
                    NewField27.CalcValue = NewField27.Value;
                    DYERTAR.CalcValue = MyParentReport.MASTER.DTARIH.FormattedValue + @" / " + MyParentReport.MASTER.DYER.CalcValue;
                    PLANNEDMEDICACTIONREQOBJECTID.CalcValue = (dataset_PlannedMedicalActionAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PlannedMedicalActionAcceptionReportNQL.Plannedmedicactionreqobjectid) : "");
                    AYAKYATANCODED.CalcValue = (dataset_PlannedMedicalActionAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PlannedMedicalActionAcceptionReportNQL.PatientStatus) : "");
                    AYAKYATANCODED.PostFieldValueCalculation();
                    AYAKTANYATAN.CalcValue = MyParentReport.MASTER.AYAKYATANCODED.CalcValue + @" HASTA";
                    EPISODEID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    EPISODEID.PostFieldValueCalculation();
                    LOGO1.CalcValue = LOGO1.Value;
                    REPORTHEADER1.CalcValue = REPORTHEADER1.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField123.CalcValue = NewField123.Value;
                    NewField124.CalcValue = NewField124.Value;
                    NewField125.CalcValue = NewField125.Value;
                    EPISODEOBJECTID.CalcValue = (dataset_PlannedMedicalActionAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PlannedMedicalActionAcceptionReportNQL.Episodeobjectid) : "");
                    UNIQUEREFNO.CalcValue = (dataset_PlannedMedicalActionAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PlannedMedicalActionAcceptionReportNQL.UniqueRefNo) : "");
                    LBLUNIQUEREFNO.CalcValue = LBLUNIQUEREFNO.Value;
                    NewField13.CalcValue = NewField13.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField2,NAME,DTARIH,RUTBE,KABULSEBEBI,DYER,PROTOKOLNO,NewField16,NewField167,NewField17,NewField18,NewField22,HASTANO,NewField24,ACTIONID,NewField26,TARIH,NewField27,DYERTAR,PLANNEDMEDICACTIONREQOBJECTID,AYAKYATANCODED,AYAKTANYATAN,EPISODEID,LOGO1,REPORTHEADER1,NewField1,NewField11,NewField12,NewField121,NewField122,NewField123,NewField124,NewField125,EPISODEOBJECTID,UNIQUEREFNO,LBLUNIQUEREFNO,NewField13,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region MASTER HEADER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((PlannedMedicalActionDetailReportForFoundation)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PlannedMedicalActionOrder plannedMedicalActionOrder = (PlannedMedicalActionOrder)objectContext.GetObject(new Guid(objectID),"PlannedMedicalActionOrder");
            
            if (plannedMedicalActionOrder.Episode.Patient.Foreign == true)
            {
                this.UNIQUEREFNO.CalcValue = plannedMedicalActionOrder.Episode.Patient.ForeignUniqueRefNo.ToString();
                this.LBLUNIQUEREFNO.CalcValue = "Kimlik/Sigorta No (Yabancı Hasta)";
            }
            else
            {
                this.UNIQUEREFNO.CalcValue = plannedMedicalActionOrder.Episode.Patient.UniqueRefNo.ToString();
                this.LBLUNIQUEREFNO.CalcValue = "T.C. Kimlik No";
            }
#endregion MASTER HEADER_Script
                }
            }
            public partial class MASTERGroupFooter : TTReportSection
            {
                public PlannedMedicalActionDetailReportForFoundation MyParentReport
                {
                    get { return (PlannedMedicalActionDetailReportForFoundation)ParentReport; }
                }
                
                public TTReportField NewField0;
                public TTReportShape NewLine2;
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
                public MASTERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 34;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 83, 6, false);
                    NewField0.Name = "NewField0";
                    NewField0.TextFont.Name = "Arial Narrow";
                    NewField0.TextFont.Size = 9;
                    NewField0.TextFont.Bold = true;
                    NewField0.Value = @"İstek Yapan Tabip";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 206, 0, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    DIPSIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 14, 83, 18, false);
                    DIPSIC.Name = "DIPSIC";
                    DIPSIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSIC.TextFont.Name = "Arial Narrow";
                    DIPSIC.TextFont.Size = 9;
                    DIPSIC.Value = @"";

                    ADSOYADDOC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 6, 83, 10, false);
                    ADSOYADDOC.Name = "ADSOYADDOC";
                    ADSOYADDOC.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC.TextFont.Name = "Arial Narrow";
                    ADSOYADDOC.TextFont.Size = 9;
                    ADSOYADDOC.Value = @"{#PROCEDUREDOCTORNAME#}";

                    UZMANLIKDAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 270, 3, 297, 7, false);
                    UZMANLIKDAL.Name = "UZMANLIKDAL";
                    UZMANLIKDAL.Visible = EvetHayirEnum.ehHayir;
                    UZMANLIKDAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIKDAL.MultiLine = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.NoClip = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.WordBreak = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.TextFont.Name = "Arial Narrow";
                    UZMANLIKDAL.TextFont.Size = 9;
                    UZMANLIKDAL.Value = @"{#DOCSPECIALITY#}";

                    DIPSICLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 14, 32, 18, false);
                    DIPSICLABEL.Name = "DIPSICLABEL";
                    DIPSICLABEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSICLABEL.TextFont.Name = "Arial Narrow";
                    DIPSICLABEL.TextFont.Size = 9;
                    DIPSICLABEL.Value = @"DIPLOMASICIL";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 83, 14, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.TextFont.Name = "Arial Narrow";
                    SINRUT.TextFont.Size = 9;
                    SINRUT.Value = @"";

                    RUTBEONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 7, 244, 11, false);
                    RUTBEONAY.Name = "RUTBEONAY";
                    RUTBEONAY.Visible = EvetHayirEnum.ehHayir;
                    RUTBEONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBEONAY.MultiLine = EvetHayirEnum.ehEvet;
                    RUTBEONAY.TextFont.Name = "Arial Narrow";
                    RUTBEONAY.TextFont.Size = 9;
                    RUTBEONAY.Value = @"{#DOKRANK#}";

                    SINIFONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 2, 270, 7, false);
                    SINIFONAY.Name = "SINIFONAY";
                    SINIFONAY.Visible = EvetHayirEnum.ehHayir;
                    SINIFONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFONAY.TextFont.Name = "Arial Narrow";
                    SINIFONAY.TextFont.Size = 9;
                    SINIFONAY.Value = @"{#DOCMILITARYCLASS#}";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 18, 83, 22, false);
                    UZ.Name = "UZ";
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.TextFont.Name = "Arial Narrow";
                    UZ.TextFont.Size = 9;
                    UZ.Value = @"{%UZMANLIKDAL%}";

                    GOREV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 2, 244, 7, false);
                    GOREV.Name = "GOREV";
                    GOREV.Visible = EvetHayirEnum.ehHayir;
                    GOREV.FieldType = ReportFieldTypeEnum.ftVariable;
                    GOREV.TextFont.Name = "Arial Narrow";
                    GOREV.TextFont.Size = 9;
                    GOREV.Value = @"{#DOCWORK#}";

                    DIPLOMANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 271, 11, 298, 15, false);
                    DIPLOMANO.Name = "DIPLOMANO";
                    DIPLOMANO.Visible = EvetHayirEnum.ehHayir;
                    DIPLOMANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMANO.TextFont.Name = "Arial Narrow";
                    DIPLOMANO.TextFont.Size = 9;
                    DIPLOMANO.Value = @"{#DOCDIPLOMANO#}";

                    SICILKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 270, 7, 297, 11, false);
                    SICILKULLAN.Name = "SICILKULLAN";
                    SICILKULLAN.Visible = EvetHayirEnum.ehHayir;
                    SICILKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    SICILKULLAN.TextFont.Name = "Arial Narrow";
                    SICILKULLAN.TextFont.Size = 9;
                    SICILKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SICILKULLAN"", """")";

                    UNVANKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 11, 244, 15, false);
                    UNVANKULLAN.Name = "UNVANKULLAN";
                    UNVANKULLAN.Visible = EvetHayirEnum.ehHayir;
                    UNVANKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    UNVANKULLAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.TextFont.Name = "Arial Narrow";
                    UNVANKULLAN.TextFont.Size = 9;
                    UNVANKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""UNVANKULLAN"", """")";

                    UNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 7, 270, 12, false);
                    UNVAN.Name = "UNVAN";
                    UNVAN.Visible = EvetHayirEnum.ehHayir;
                    UNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNVAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVAN.ObjectDefName = "UserTitleEnum";
                    UNVAN.DataMember = "DISPLAYTEXT";
                    UNVAN.TextFont.Name = "Arial Narrow";
                    UNVAN.TextFont.Size = 9;
                    UNVAN.Value = @"{#DOCTITLE#}";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 12, 271, 16, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.Visible = EvetHayirEnum.ehHayir;
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.TextFont.Name = "Arial Narrow";
                    SICILNO.TextFont.Size = 9;
                    SICILNO.Value = @"{#DOCEMPLOYMENTRECORDID#}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 2, 206, 7, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PrintDate.TextFont.Name = "Arial Narrow";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.Value = @"{@printdate@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 24, 121, 29, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PageNumber.TextFont.Name = "Arial Narrow";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PlannedMedicalActionOrder.PlannedMedicalActionAcceptionReportNQL_Class dataset_PlannedMedicalActionAcceptionReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PlannedMedicalActionOrder.PlannedMedicalActionAcceptionReportNQL_Class>(0);
                    NewField0.CalcValue = NewField0.Value;
                    DIPSIC.CalcValue = @"";
                    ADSOYADDOC.CalcValue = (dataset_PlannedMedicalActionAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PlannedMedicalActionAcceptionReportNQL.Proceduredoctorname) : "");
                    UZMANLIKDAL.CalcValue = (dataset_PlannedMedicalActionAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PlannedMedicalActionAcceptionReportNQL.Docspeciality) : "");
                    DIPSICLABEL.CalcValue = @"DIPLOMASICIL";
                    SINRUT.CalcValue = @"";
                    RUTBEONAY.CalcValue = (dataset_PlannedMedicalActionAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PlannedMedicalActionAcceptionReportNQL.Dokrank) : "");
                    SINIFONAY.CalcValue = (dataset_PlannedMedicalActionAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PlannedMedicalActionAcceptionReportNQL.Docmilitaryclass) : "");
                    UZ.CalcValue = MyParentReport.MASTER.UZMANLIKDAL.CalcValue;
                    GOREV.CalcValue = (dataset_PlannedMedicalActionAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PlannedMedicalActionAcceptionReportNQL.Docwork) : "");
                    DIPLOMANO.CalcValue = (dataset_PlannedMedicalActionAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PlannedMedicalActionAcceptionReportNQL.Docdiplomano) : "");
                    UNVAN.CalcValue = (dataset_PlannedMedicalActionAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PlannedMedicalActionAcceptionReportNQL.Doctitle) : "");
                    UNVAN.PostFieldValueCalculation();
                    SICILNO.CalcValue = (dataset_PlannedMedicalActionAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PlannedMedicalActionAcceptionReportNQL.Docemploymentrecordid) : "");
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    SICILKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "");
                    UNVANKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "");
                    return new TTReportObject[] { NewField0,DIPSIC,ADSOYADDOC,UZMANLIKDAL,DIPSICLABEL,SINRUT,RUTBEONAY,SINIFONAY,UZ,GOREV,DIPLOMANO,UNVAN,SICILNO,PrintDate,PageNumber,SICILKULLAN,UNVANKULLAN};
                }

                public override void RunScript()
                {
#region MASTER FOOTER_Script
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
#endregion MASTER FOOTER_Script
                }
            }

        }

        public MASTERGroup MASTER;

        public partial class ARAGroup : TTReportGroup
        {
            public PlannedMedicalActionDetailReportForFoundation MyParentReport
            {
                get { return (PlannedMedicalActionDetailReportForFoundation)ParentReport; }
            }

            new public ARAGroupHeader Header()
            {
                return (ARAGroupHeader)_header;
            }

            new public ARAGroupFooter Footer()
            {
                return (ARAGroupFooter)_footer;
            }

            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField NewField111411 { get {return Header().NewField111411;} }
            public TTReportField NewField111412 { get {return Header().NewField111412;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
            public TTReportField NewField0 { get {return Footer().NewField0;} }
            public TTReportShape NewLine11121 { get {return Footer().NewLine11121;} }
            public TTReportField NewField111141111 { get {return Footer().NewField111141111;} }
            public TTReportField NewField1111141111 { get {return Footer().NewField1111141111;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public ARAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ARAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ARAGroupHeader(this);
                _footer = new ARAGroupFooter(this);

            }

            public partial class ARAGroupHeader : TTReportSection
            {
                public PlannedMedicalActionDetailReportForFoundation MyParentReport
                {
                    get { return (PlannedMedicalActionDetailReportForFoundation)ParentReport; }
                }
                
                public TTReportField NewField1141;
                public TTReportField NewField11411;
                public TTReportField NewField111411;
                public TTReportField NewField111412;
                public TTReportShape NewLine1111; 
                public ARAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 13;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 36, 6, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Name = "Arial Narrow";
                    NewField1141.TextFont.Size = 9;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.Value = @"Vaka Tanıları";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 7, 36, 12, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.TextFont.Name = "Arial Narrow";
                    NewField11411.TextFont.Size = 9;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.Value = @"Tanı Tarihi";

                    NewField111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 7, 175, 12, false);
                    NewField111411.Name = "NewField111411";
                    NewField111411.TextFont.Name = "Arial Narrow";
                    NewField111411.TextFont.Size = 9;
                    NewField111411.TextFont.Bold = true;
                    NewField111411.Value = @"Tanı";

                    NewField111412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 7, 206, 12, false);
                    NewField111412.Name = "NewField111412";
                    NewField111412.TextFont.Name = "Arial Narrow";
                    NewField111412.TextFont.Size = 9;
                    NewField111412.TextFont.Bold = true;
                    NewField111412.Value = @"Tanı Tipi
";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 12, 206, 12, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField111411.CalcValue = NewField111411.Value;
                    NewField111412.CalcValue = NewField111412.Value;
                    return new TTReportObject[] { NewField1141,NewField11411,NewField111411,NewField111412};
                }
            }
            public partial class ARAGroupFooter : TTReportSection
            {
                public PlannedMedicalActionDetailReportForFoundation MyParentReport
                {
                    get { return (PlannedMedicalActionDetailReportForFoundation)ParentReport; }
                }
                
                public TTReportShape NewLine11111;
                public TTReportField NewField0;
                public TTReportShape NewLine11121;
                public TTReportField NewField111141111;
                public TTReportField NewField1111141111;
                public TTReportField NewField1;
                public TTReportField NewField2; 
                public ARAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 11;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 2, 206, 2, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 4, 206, 9, false);
                    NewField0.Name = "NewField0";
                    NewField0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField0.TextFont.Name = "Arial Narrow";
                    NewField0.TextFont.Size = 9;
                    NewField0.TextFont.Bold = true;
                    NewField0.Value = @"Durum
";

                    NewLine11121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 10, 206, 10, false);
                    NewLine11121.Name = "NewLine11121";
                    NewLine11121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111141111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 4, 122, 9, false);
                    NewField111141111.Name = "NewField111141111";
                    NewField111141111.TextFont.Name = "Arial Narrow";
                    NewField111141111.TextFont.Size = 9;
                    NewField111141111.TextFont.Bold = true;
                    NewField111141111.Value = @"İstenen Planlı Tıbbi İşlem";

                    NewField1111141111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 4, 151, 9, false);
                    NewField1111141111.Name = "NewField1111141111";
                    NewField1111141111.TextFont.Name = "Arial Narrow";
                    NewField1111141111.TextFont.Size = 9;
                    NewField1111141111.TextFont.Bold = true;
                    NewField1111141111.Value = @"Uygulama Alanı";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 4, 187, 9, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"Personel";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 4, 36, 9, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Size = 9;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"Uygulanma Tarihi
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField0.CalcValue = NewField0.Value;
                    NewField111141111.CalcValue = NewField111141111.Value;
                    NewField1111141111.CalcValue = NewField1111141111.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    return new TTReportObject[] { NewField0,NewField111141111,NewField1111141111,NewField1,NewField2};
                }
            }

        }

        public ARAGroup ARA;

        public partial class MAINGroup : TTReportGroup
        {
            public PlannedMedicalActionDetailReportForFoundation MyParentReport
            {
                get { return (PlannedMedicalActionDetailReportForFoundation)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DIAGNOSISCODENAME { get {return Body().DIAGNOSISCODENAME;} }
            public TTReportField DIAGNOSISDATE { get {return Body().DIAGNOSISDATE;} }
            public TTReportField DIAGNOSISTYPE { get {return Body().DIAGNOSISTYPE;} }
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
                list[0] = new TTReportNqlData<DiagnosisGrid.GetDiagnosisByEpisode_Class>("GetDiagnosisByEpisode", DiagnosisGrid.GetDiagnosisByEpisode((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.MASTER.EPISODEOBJECTID.CalcValue)));
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
                public PlannedMedicalActionDetailReportForFoundation MyParentReport
                {
                    get { return (PlannedMedicalActionDetailReportForFoundation)ParentReport; }
                }
                
                public TTReportField DIAGNOSISCODENAME;
                public TTReportField DIAGNOSISDATE;
                public TTReportField DIAGNOSISTYPE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    DIAGNOSISCODENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 1, 175, 6, false);
                    DIAGNOSISCODENAME.Name = "DIAGNOSISCODENAME";
                    DIAGNOSISCODENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISCODENAME.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISCODENAME.NoClip = EvetHayirEnum.ehEvet;
                    DIAGNOSISCODENAME.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISCODENAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISCODENAME.TextFont.Name = "Arial Narrow";
                    DIAGNOSISCODENAME.TextFont.Size = 9;
                    DIAGNOSISCODENAME.Value = @"{#CODE#} {#NAME#}";

                    DIAGNOSISDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 36, 6, false);
                    DIAGNOSISDATE.Name = "DIAGNOSISDATE";
                    DIAGNOSISDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISDATE.TextFormat = @"g";
                    DIAGNOSISDATE.TextFont.Name = "Arial Narrow";
                    DIAGNOSISDATE.TextFont.Size = 9;
                    DIAGNOSISDATE.Value = @"{#DIAGNOSEDATE#}";

                    DIAGNOSISTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 1, 206, 6, false);
                    DIAGNOSISTYPE.Name = "DIAGNOSISTYPE";
                    DIAGNOSISTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISTYPE.ObjectDefName = "DiagnosisTypeEnum";
                    DIAGNOSISTYPE.DataMember = "DISPLAYTEXT";
                    DIAGNOSISTYPE.TextFont.Name = "Arial Narrow";
                    DIAGNOSISTYPE.TextFont.Size = 9;
                    DIAGNOSISTYPE.Value = @"{#DIAGNOSISTYPE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DiagnosisGrid.GetDiagnosisByEpisode_Class dataset_GetDiagnosisByEpisode = ParentGroup.rsGroup.GetCurrentRecord<DiagnosisGrid.GetDiagnosisByEpisode_Class>(0);
                    DIAGNOSISCODENAME.CalcValue = (dataset_GetDiagnosisByEpisode != null ? Globals.ToStringCore(dataset_GetDiagnosisByEpisode.Code) : "") + @" " + (dataset_GetDiagnosisByEpisode != null ? Globals.ToStringCore(dataset_GetDiagnosisByEpisode.Name) : "");
                    DIAGNOSISDATE.CalcValue = (dataset_GetDiagnosisByEpisode != null ? Globals.ToStringCore(dataset_GetDiagnosisByEpisode.Diagnosedate) : "");
                    DIAGNOSISTYPE.CalcValue = (dataset_GetDiagnosisByEpisode != null ? Globals.ToStringCore(dataset_GetDiagnosisByEpisode.DiagnosisType) : "");
                    DIAGNOSISTYPE.PostFieldValueCalculation();
                    return new TTReportObject[] { DIAGNOSISCODENAME,DIAGNOSISDATE,DIAGNOSISTYPE};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class ORDERSGroup : TTReportGroup
        {
            public PlannedMedicalActionDetailReportForFoundation MyParentReport
            {
                get { return (PlannedMedicalActionDetailReportForFoundation)ParentReport; }
            }

            new public ORDERSGroupHeader Header()
            {
                return (ORDERSGroupHeader)_header;
            }

            new public ORDERSGroupFooter Footer()
            {
                return (ORDERSGroupFooter)_footer;
            }

            public ORDERSGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ORDERSGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailsByOrderObject_Class>("GetPhysiotherapyOrderDetailsByOrderObject", PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailsByOrderObject((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ORDERSGroupHeader(this);
                _footer = new ORDERSGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class ORDERSGroupHeader : TTReportSection
            {
                public PlannedMedicalActionDetailReportForFoundation MyParentReport
                {
                    get { return (PlannedMedicalActionDetailReportForFoundation)ParentReport; }
                }
                 
                public ORDERSGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class ORDERSGroupFooter : TTReportSection
            {
                public PlannedMedicalActionDetailReportForFoundation MyParentReport
                {
                    get { return (PlannedMedicalActionDetailReportForFoundation)ParentReport; }
                }
                 
                public ORDERSGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public ORDERSGroup ORDERS;

        public partial class ORDERDETAILSGroup : TTReportGroup
        {
            public PlannedMedicalActionDetailReportForFoundation MyParentReport
            {
                get { return (PlannedMedicalActionDetailReportForFoundation)ParentReport; }
            }

            new public ORDERDETAILSGroupBody Body()
            {
                return (ORDERDETAILSGroupBody)_body;
            }
            public TTReportField STATE { get {return Body().STATE;} }
            public TTReportField PROCEDUREBYUSER { get {return Body().PROCEDUREBYUSER;} }
            public TTReportField ORDEROBJECTPROCEDUREDOCTOR { get {return Body().ORDEROBJECTPROCEDUREDOCTOR;} }
            public TTReportField ORDERDETAILPROCEDUREBYUSER { get {return Body().ORDERDETAILPROCEDUREBYUSER;} }
            public TTReportField PROCEDUREOBJECTCODENAME { get {return Body().PROCEDUREOBJECTCODENAME;} }
            public TTReportField APPLICATIONAREA { get {return Body().APPLICATIONAREA;} }
            public TTReportField ORDEROBJECTOBJECTID { get {return Body().ORDEROBJECTOBJECTID;} }
            public TTReportField ACTIONDATE { get {return Body().ACTIONDATE;} }
            public TTReportField CURRENTSTATEDEFID { get {return Body().CURRENTSTATEDEFID;} }
            public TTReportField ACTIONDATE2 { get {return Body().ACTIONDATE2;} }
            public TTReportField ORDERDETAILOBJECTID { get {return Body().ORDERDETAILOBJECTID;} }
            public ORDERDETAILSGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ORDERDETAILSGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PlannedMedicalActionOrderDetail.GetPlannedMedicalActionOrderDetailsByOrderObject_Class>("GetPlannedMedicalActionOrderDetailsByOrderObject", PlannedMedicalActionOrderDetail.GetPlannedMedicalActionOrderDetailsByOrderObject((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ORDERDETAILSGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class ORDERDETAILSGroupBody : TTReportSection
            {
                public PlannedMedicalActionDetailReportForFoundation MyParentReport
                {
                    get { return (PlannedMedicalActionDetailReportForFoundation)ParentReport; }
                }
                
                public TTReportField STATE;
                public TTReportField PROCEDUREBYUSER;
                public TTReportField ORDEROBJECTPROCEDUREDOCTOR;
                public TTReportField ORDERDETAILPROCEDUREBYUSER;
                public TTReportField PROCEDUREOBJECTCODENAME;
                public TTReportField APPLICATIONAREA;
                public TTReportField ORDEROBJECTOBJECTID;
                public TTReportField ACTIONDATE;
                public TTReportField CURRENTSTATEDEFID;
                public TTReportField ACTIONDATE2;
                public TTReportField ORDERDETAILOBJECTID; 
                public ORDERDETAILSGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    STATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 2, 206, 7, false);
                    STATE.Name = "STATE";
                    STATE.FieldType = ReportFieldTypeEnum.ftExpression;
                    STATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STATE.MultiLine = EvetHayirEnum.ehEvet;
                    STATE.NoClip = EvetHayirEnum.ehEvet;
                    STATE.WordBreak = EvetHayirEnum.ehEvet;
                    STATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    STATE.TextFont.Name = "Arial Narrow";
                    STATE.TextFont.Size = 9;
                    STATE.Value = @"TTObjectDefManager.Instance.ObjectDefs[""PhysiotherapyOrderDetail""].StateDefs[new Guid({#ORDERS.CURRENTSTATEDEFID#})].DisplayText";

                    PROCEDUREBYUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 2, 187, 7, false);
                    PROCEDUREBYUSER.Name = "PROCEDUREBYUSER";
                    PROCEDUREBYUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREBYUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROCEDUREBYUSER.MultiLine = EvetHayirEnum.ehEvet;
                    PROCEDUREBYUSER.NoClip = EvetHayirEnum.ehEvet;
                    PROCEDUREBYUSER.WordBreak = EvetHayirEnum.ehEvet;
                    PROCEDUREBYUSER.ExpandTabs = EvetHayirEnum.ehEvet;
                    PROCEDUREBYUSER.TextFont.Name = "Arial Narrow";
                    PROCEDUREBYUSER.TextFont.Size = 9;
                    PROCEDUREBYUSER.Value = @"{#ORDERS.PROCEDUREBYUSER#}";

                    ORDEROBJECTPROCEDUREDOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 0, 269, 5, false);
                    ORDEROBJECTPROCEDUREDOCTOR.Name = "ORDEROBJECTPROCEDUREDOCTOR";
                    ORDEROBJECTPROCEDUREDOCTOR.Visible = EvetHayirEnum.ehHayir;
                    ORDEROBJECTPROCEDUREDOCTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDEROBJECTPROCEDUREDOCTOR.TextFormat = @"g";
                    ORDEROBJECTPROCEDUREDOCTOR.TextFont.Name = "Arial Narrow";
                    ORDEROBJECTPROCEDUREDOCTOR.TextFont.Size = 9;
                    ORDEROBJECTPROCEDUREDOCTOR.Value = @"{#ORDERS.ORDEROBJECTPROCEDUREDOCTOR#}";

                    ORDERDETAILPROCEDUREBYUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 5, 269, 10, false);
                    ORDERDETAILPROCEDUREBYUSER.Name = "ORDERDETAILPROCEDUREBYUSER";
                    ORDERDETAILPROCEDUREBYUSER.Visible = EvetHayirEnum.ehHayir;
                    ORDERDETAILPROCEDUREBYUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERDETAILPROCEDUREBYUSER.TextFormat = @"g";
                    ORDERDETAILPROCEDUREBYUSER.TextFont.Name = "Arial Narrow";
                    ORDERDETAILPROCEDUREBYUSER.TextFont.Size = 9;
                    ORDERDETAILPROCEDUREBYUSER.Value = @"{#ORDERS.PROCEDUREBYUSER#}";

                    PROCEDUREOBJECTCODENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 2, 122, 7, false);
                    PROCEDUREOBJECTCODENAME.Name = "PROCEDUREOBJECTCODENAME";
                    PROCEDUREOBJECTCODENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREOBJECTCODENAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PROCEDUREOBJECTCODENAME.MultiLine = EvetHayirEnum.ehEvet;
                    PROCEDUREOBJECTCODENAME.NoClip = EvetHayirEnum.ehEvet;
                    PROCEDUREOBJECTCODENAME.WordBreak = EvetHayirEnum.ehEvet;
                    PROCEDUREOBJECTCODENAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PROCEDUREOBJECTCODENAME.TextFont.Name = "Arial Narrow";
                    PROCEDUREOBJECTCODENAME.TextFont.Size = 9;
                    PROCEDUREOBJECTCODENAME.Value = @" {#ORDERS.PROCEDUREOBJECTCODE#} {#ORDERS.PROCEDUREOBJECTNAME#}";

                    APPLICATIONAREA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 2, 151, 7, false);
                    APPLICATIONAREA.Name = "APPLICATIONAREA";
                    APPLICATIONAREA.FieldType = ReportFieldTypeEnum.ftVariable;
                    APPLICATIONAREA.MultiLine = EvetHayirEnum.ehEvet;
                    APPLICATIONAREA.NoClip = EvetHayirEnum.ehEvet;
                    APPLICATIONAREA.WordBreak = EvetHayirEnum.ehEvet;
                    APPLICATIONAREA.ExpandTabs = EvetHayirEnum.ehEvet;
                    APPLICATIONAREA.TextFont.Name = "Arial Narrow";
                    APPLICATIONAREA.TextFont.Size = 9;
                    APPLICATIONAREA.Value = @"{#ORDERS.ORDEROBJECTAPPLICATIONAREA#}";

                    ORDEROBJECTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 10, 269, 15, false);
                    ORDEROBJECTOBJECTID.Name = "ORDEROBJECTOBJECTID";
                    ORDEROBJECTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    ORDEROBJECTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDEROBJECTOBJECTID.MultiLine = EvetHayirEnum.ehEvet;
                    ORDEROBJECTOBJECTID.WordBreak = EvetHayirEnum.ehEvet;
                    ORDEROBJECTOBJECTID.TextFont.Name = "Arial Narrow";
                    ORDEROBJECTOBJECTID.TextFont.Size = 9;
                    ORDEROBJECTOBJECTID.Value = @"{#ORDERS.ORDEROBJECTOBJECTID#}";

                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 36, 7, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.MultiLine = EvetHayirEnum.ehEvet;
                    ACTIONDATE.NoClip = EvetHayirEnum.ehEvet;
                    ACTIONDATE.WordBreak = EvetHayirEnum.ehEvet;
                    ACTIONDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACTIONDATE.TextFont.Name = "Arial Narrow";
                    ACTIONDATE.TextFont.Size = 9;
                    ACTIONDATE.Value = @"";

                    CURRENTSTATEDEFID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 15, 269, 20, false);
                    CURRENTSTATEDEFID.Name = "CURRENTSTATEDEFID";
                    CURRENTSTATEDEFID.Visible = EvetHayirEnum.ehHayir;
                    CURRENTSTATEDEFID.FieldType = ReportFieldTypeEnum.ftVariable;
                    CURRENTSTATEDEFID.TextFont.Name = "Arial Narrow";
                    CURRENTSTATEDEFID.TextFont.Size = 9;
                    CURRENTSTATEDEFID.Value = @"{#ORDERS.CURRENTSTATEDEFID#}";

                    ACTIONDATE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 21, 269, 26, false);
                    ACTIONDATE2.Name = "ACTIONDATE2";
                    ACTIONDATE2.Visible = EvetHayirEnum.ehHayir;
                    ACTIONDATE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE2.TextFormat = @"g";
                    ACTIONDATE2.MultiLine = EvetHayirEnum.ehEvet;
                    ACTIONDATE2.NoClip = EvetHayirEnum.ehEvet;
                    ACTIONDATE2.WordBreak = EvetHayirEnum.ehEvet;
                    ACTIONDATE2.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACTIONDATE2.TextFont.Name = "Arial Narrow";
                    ACTIONDATE2.TextFont.Size = 9;
                    ACTIONDATE2.Value = @"{#ORDERS.ACTIONDATE#}";

                    ORDERDETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 26, 269, 31, false);
                    ORDERDETAILOBJECTID.Name = "ORDERDETAILOBJECTID";
                    ORDERDETAILOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    ORDERDETAILOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERDETAILOBJECTID.MultiLine = EvetHayirEnum.ehEvet;
                    ORDERDETAILOBJECTID.WordBreak = EvetHayirEnum.ehEvet;
                    ORDERDETAILOBJECTID.TextFont.Name = "Arial Narrow";
                    ORDERDETAILOBJECTID.TextFont.Size = 9;
                    ORDERDETAILOBJECTID.Value = @"{#ORDERS.OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PlannedMedicalActionOrderDetail.GetPlannedMedicalActionOrderDetailsByOrderObject_Class dataset_GetPlannedMedicalActionOrderDetailsByOrderObject = ParentGroup.rsGroup.GetCurrentRecord<PlannedMedicalActionOrderDetail.GetPlannedMedicalActionOrderDetailsByOrderObject_Class>(0);
                    PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailsByOrderObject_Class dataset_GetPhysiotherapyOrderDetailsByOrderObject = MyParentReport.ORDERS.rsGroup.GetCurrentRecord<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailsByOrderObject_Class>(0);
                    PROCEDUREBYUSER.CalcValue = (dataset_GetPhysiotherapyOrderDetailsByOrderObject != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrderDetailsByOrderObject.Procedurebyuser) : "");
                    ORDEROBJECTPROCEDUREDOCTOR.CalcValue = (dataset_GetPhysiotherapyOrderDetailsByOrderObject != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrderDetailsByOrderObject.Orderobjectproceduredoctor) : "");
                    ORDERDETAILPROCEDUREBYUSER.CalcValue = (dataset_GetPhysiotherapyOrderDetailsByOrderObject != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrderDetailsByOrderObject.Procedurebyuser) : "");
                    PROCEDUREOBJECTCODENAME.CalcValue = @" " + (dataset_GetPhysiotherapyOrderDetailsByOrderObject != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrderDetailsByOrderObject.Procedureobjectcode) : "") + @" " + (dataset_GetPhysiotherapyOrderDetailsByOrderObject != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrderDetailsByOrderObject.Procedureobjectname) : "");
                    APPLICATIONAREA.CalcValue = (dataset_GetPhysiotherapyOrderDetailsByOrderObject != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrderDetailsByOrderObject.Orderobjectapplicationarea) : "");
                    ORDEROBJECTOBJECTID.CalcValue = (dataset_GetPhysiotherapyOrderDetailsByOrderObject != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrderDetailsByOrderObject.Orderobjectobjectid) : "");
                    ACTIONDATE.CalcValue = @"";
                    CURRENTSTATEDEFID.CalcValue = (dataset_GetPhysiotherapyOrderDetailsByOrderObject != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrderDetailsByOrderObject.CurrentStateDefID) : "");
                    ACTIONDATE2.CalcValue = (dataset_GetPhysiotherapyOrderDetailsByOrderObject != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrderDetailsByOrderObject.ActionDate) : "");
                    ORDERDETAILOBJECTID.CalcValue = (dataset_GetPhysiotherapyOrderDetailsByOrderObject != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrderDetailsByOrderObject.ObjectID) : "");
                    STATE.CalcValue = TTObjectDefManager.Instance.ObjectDefs["PhysiotherapyOrderDetail"].StateDefs[new Guid((dataset_GetPhysiotherapyOrderDetailsByOrderObject != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrderDetailsByOrderObject.CurrentStateDefID) : ""))].DisplayText;
                    return new TTReportObject[] { PROCEDUREBYUSER,ORDEROBJECTPROCEDUREDOCTOR,ORDERDETAILPROCEDUREBYUSER,PROCEDUREOBJECTCODENAME,APPLICATIONAREA,ORDEROBJECTOBJECTID,ACTIONDATE,CURRENTSTATEDEFID,ACTIONDATE2,ORDERDETAILOBJECTID,STATE};
                }

                public override void RunScript()
                {
#region ORDERDETAILS BODY_Script
                    if (TTObjectDefManager.Instance.ObjectDefs["PlannedMedicalActionOrderDetail"].StateDefs[new Guid(this.CURRENTSTATEDEFID.CalcValue != null ? TTUtils.Globals.ToStringCore(this.CURRENTSTATEDEFID.CalcValue) : "")] != null)
            {
                Guid currentStateDefID = TTObjectDefManager.Instance.ObjectDefs["PlannedMedicalActionOrderDetail"].StateDefs[new Guid(this.CURRENTSTATEDEFID.CalcValue != null ? TTUtils.Globals.ToStringCore(this.CURRENTSTATEDEFID.CalcValue) : "")].StateDefID;
                if (currentStateDefID != TTObjectClasses.PlannedMedicalActionOrderDetail.States.Completed)
                    this.ACTIONDATE.CalcValue = "-";
                else
                    this.ACTIONDATE.CalcValue  = this.ACTIONDATE2.CalcValue;
            }
            else
            {
                this.ACTIONDATE.CalcValue  = this.ACTIONDATE2.CalcValue;
            }
            
            if (this.ORDERDETAILPROCEDUREBYUSER.CalcValue == "")
                this.PROCEDUREBYUSER.CalcValue = this.ORDEROBJECTPROCEDUREDOCTOR.CalcValue;
            else
                this.PROCEDUREBYUSER.CalcValue = this.ORDERDETAILPROCEDUREBYUSER.CalcValue;
#endregion ORDERDETAILS BODY_Script
                }
            }

        }

        public ORDERDETAILSGroup ORDERDETAILS;

        public partial class FTRNOTEGroup : TTReportGroup
        {
            public PlannedMedicalActionDetailReportForFoundation MyParentReport
            {
                get { return (PlannedMedicalActionDetailReportForFoundation)ParentReport; }
            }

            new public FTRNOTEGroupBody Body()
            {
                return (FTRNOTEGroupBody)_body;
            }
            public TTReportField NewField10 { get {return Body().NewField10;} }
            public TTReportRTF FTRNOTES { get {return Body().FTRNOTES;} }
            public TTReportField ORDERDETAILOBJECTID { get {return Body().ORDERDETAILOBJECTID;} }
            public TTReportField NOTE { get {return Body().NOTE;} }
            public FTRNOTEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public FTRNOTEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new FTRNOTEGroupBody(this);
            }

            public partial class FTRNOTEGroupBody : TTReportSection
            {
                public PlannedMedicalActionDetailReportForFoundation MyParentReport
                {
                    get { return (PlannedMedicalActionDetailReportForFoundation)ParentReport; }
                }
                
                public TTReportField NewField10;
                public TTReportRTF FTRNOTES;
                public TTReportField ORDERDETAILOBJECTID;
                public TTReportField NOTE; 
                public FTRNOTEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 17, 6, false);
                    NewField10.Name = "NewField10";
                    NewField10.TextFont.Name = "Arial Narrow";
                    NewField10.TextFont.Size = 9;
                    NewField10.TextFont.Bold = true;
                    NewField10.Value = @"Not :
";

                    FTRNOTES = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 223, 1, 393, 6, false);
                    FTRNOTES.Name = "FTRNOTES";
                    FTRNOTES.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20\par
}
";

                    ORDERDETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 1, 269, 6, false);
                    ORDERDETAILOBJECTID.Name = "ORDERDETAILOBJECTID";
                    ORDERDETAILOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    ORDERDETAILOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERDETAILOBJECTID.MultiLine = EvetHayirEnum.ehEvet;
                    ORDERDETAILOBJECTID.WordBreak = EvetHayirEnum.ehEvet;
                    ORDERDETAILOBJECTID.TextFont.Name = "Arial Narrow";
                    ORDERDETAILOBJECTID.TextFont.Size = 9;
                    ORDERDETAILOBJECTID.Value = @"{#ORDERS.OBJECTID#}";

                    NOTE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 1, 206, 6, false);
                    NOTE.Name = "NOTE";
                    NOTE.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOTE.TextFormat = @"g";
                    NOTE.MultiLine = EvetHayirEnum.ehEvet;
                    NOTE.NoClip = EvetHayirEnum.ehEvet;
                    NOTE.WordBreak = EvetHayirEnum.ehEvet;
                    NOTE.ExpandTabs = EvetHayirEnum.ehEvet;
                    NOTE.TextFont.Name = "Arial Narrow";
                    NOTE.TextFont.Size = 9;
                    NOTE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailsByOrderObject_Class dataset_GetPhysiotherapyOrderDetailsByOrderObject = MyParentReport.ORDERS.rsGroup.GetCurrentRecord<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetailsByOrderObject_Class>(0);
                    NewField10.CalcValue = NewField10.Value;
                    FTRNOTES.CalcValue = FTRNOTES.Value;
                    ORDERDETAILOBJECTID.CalcValue = (dataset_GetPhysiotherapyOrderDetailsByOrderObject != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrderDetailsByOrderObject.ObjectID) : "");
                    NOTE.CalcValue = @"";
                    return new TTReportObject[] { NewField10,FTRNOTES,ORDERDETAILOBJECTID,NOTE};
                }

                public override void RunScript()
                {
#region FTRNOTE BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            PlannedMedicalActionOrderDetail plannedMedicalActionOrderDetail = (PlannedMedicalActionOrderDetail)objectContext.GetObject(new Guid(this.ORDERDETAILOBJECTID.CalcValue),"PlannedMedicalActionOrderDetail");
            if (plannedMedicalActionOrderDetail != null)
            {
                if(plannedMedicalActionOrderDetail.Note != null)
                    this.NOTE.CalcValue = TTObjectClasses.Common.GetTextOfRTFString(plannedMedicalActionOrderDetail.Note.ToString());
            }
#endregion FTRNOTE BODY_Script
                }
            }

        }

        public FTRNOTEGroup FTRNOTE;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PlannedMedicalActionDetailReportForFoundation()
        {
            MASTER = new MASTERGroup(this,"MASTER");
            ARA = new ARAGroup(MASTER,"ARA");
            MAIN = new MAINGroup(ARA,"MAIN");
            ORDERS = new ORDERSGroup(MASTER,"ORDERS");
            ORDERDETAILS = new ORDERDETAILSGroup(ORDERS,"ORDERDETAILS");
            FTRNOTE = new FTRNOTEGroup(ORDERS,"FTRNOTE");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "29035332-1b23-4773-8ed6-5e2be3f51570", "Fizyoterapi İstek", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "PLANNEDMEDICALACTIONDETAILREPORTFORFOUNDATION";
            Caption = "Planlı Tıbbi İşlem Detayları Raporu(Kurum)";
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