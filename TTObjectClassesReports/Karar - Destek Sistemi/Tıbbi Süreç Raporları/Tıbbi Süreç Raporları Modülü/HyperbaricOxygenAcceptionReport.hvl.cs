
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
    /// Hiperbarik Oksijen Tedavisi İstek Raporu
    /// </summary>
    public partial class HyperbaricOxygenAcceptionReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MASTERGroup : TTReportGroup
        {
            public HyperbaricOxygenAcceptionReport MyParentReport
            {
                get { return (HyperbaricOxygenAcceptionReport)ParentReport; }
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
            public TTReportField NOT { get {return Header().NOT;} }
            public TTReportField SubTypeExplanat { get {return Header().SubTypeExplanat;} }
            public TTReportField PROTOKOLNO { get {return Header().PROTOKOLNO;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField167 { get {return Header().NewField167;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField20 { get {return Header().NewField20;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField HASTANO { get {return Header().HASTANO;} }
            public TTReportField NewField24 { get {return Header().NewField24;} }
            public TTReportField ACTIONID { get {return Header().ACTIONID;} }
            public TTReportField NewField26 { get {return Header().NewField26;} }
            public TTReportField TARIH { get {return Header().TARIH;} }
            public TTReportField NewField27 { get {return Header().NewField27;} }
            public TTReportField DYERTAR { get {return Header().DYERTAR;} }
            public TTReportField HYPERBARICREQUESTOBJECTID { get {return Header().HYPERBARICREQUESTOBJECTID;} }
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
            public TTReportField NewField128 { get {return Header().NewField128;} }
            public TTReportField EPISODEOBJECTID { get {return Header().EPISODEOBJECTID;} }
            public TTReportField AYAKYATANCODED { get {return Header().AYAKYATANCODED;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField LBLUNIQUEREFNO { get {return Header().LBLUNIQUEREFNO;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField0 { get {return Footer().NewField0;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public TTReportField FOOTER { get {return Footer().FOOTER;} }
            public TTReportField NewField9 { get {return Footer().NewField9;} }
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
                list[0] = new TTReportNqlData<HyperbaricOxygenTreatmentOrder.HyperbaricAcceptionReportNQL_Class>("HyperbaricAcceptionReportNQL", HyperbaricOxygenTreatmentOrder.HyperbaricAcceptionReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public HyperbaricOxygenAcceptionReport MyParentReport
                {
                    get { return (HyperbaricOxygenAcceptionReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField2;
                public TTReportField NAME;
                public TTReportField DTARIH;
                public TTReportField RUTBE;
                public TTReportField KABULSEBEBI;
                public TTReportField DYER;
                public TTReportField NOT;
                public TTReportField SubTypeExplanat;
                public TTReportField PROTOKOLNO;
                public TTReportField NewField16;
                public TTReportField NewField167;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField20;
                public TTReportField NewField22;
                public TTReportField HASTANO;
                public TTReportField NewField24;
                public TTReportField ACTIONID;
                public TTReportField NewField26;
                public TTReportField TARIH;
                public TTReportField NewField27;
                public TTReportField DYERTAR;
                public TTReportField HYPERBARICREQUESTOBJECTID;
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
                public TTReportField NewField128;
                public TTReportField EPISODEOBJECTID;
                public TTReportField AYAKYATANCODED;
                public TTReportField UNIQUEREFNO;
                public TTReportField LBLUNIQUEREFNO;
                public TTReportField NewField13; 
                public MASTERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 102;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 10, 168, 33, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial Narrow";
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 59, 48, 64, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Size = 9;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"Hastanın";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 69, 133, 74, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.ObjectDefName = "HyperbaricOxygenTreatmentOrder";
                    NAME.DataMember = "EPISODE.PATIENT.FullName";
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.Size = 9;
                    NAME.Value = @"{@TTOBJECTID@}";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 64, 255, 69, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"Short Date";
                    DTARIH.TextFont.Name = "Arial Narrow";
                    DTARIH.TextFont.Size = 9;
                    DTARIH.Value = @"{#BIRTHDATE#}";

                    RUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 79, 133, 84, false);
                    RUTBE.Name = "RUTBE";
                    RUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBE.TextFont.Name = "Arial Narrow";
                    RUTBE.TextFont.Size = 9;
                    RUTBE.Value = @"";

                    KABULSEBEBI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 84, 133, 89, false);
                    KABULSEBEBI.Name = "KABULSEBEBI";
                    KABULSEBEBI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KABULSEBEBI.TextFont.Name = "Arial Narrow";
                    KABULSEBEBI.TextFont.Size = 9;
                    KABULSEBEBI.Value = @"{#REASONFORADM#}";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 69, 255, 74, false);
                    DYER.Name = "DYER";
                    DYER.Visible = EvetHayirEnum.ehHayir;
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.TextFont.Name = "Arial Narrow";
                    DYER.TextFont.Size = 9;
                    DYER.Value = @"{#CITYNAME#}";

                    NOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 91, 206, 102, false);
                    NOT.Name = "NOT";
                    NOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOT.MultiLine = EvetHayirEnum.ehEvet;
                    NOT.NoClip = EvetHayirEnum.ehEvet;
                    NOT.WordBreak = EvetHayirEnum.ehEvet;
                    NOT.ExpandTabs = EvetHayirEnum.ehEvet;
                    NOT.TextFont.Name = "Arial Narrow";
                    NOT.TextFont.Size = 9;
                    NOT.Value = @"{#NOTE#}";

                    SubTypeExplanat = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 42, 168, 47, false);
                    SubTypeExplanat.Name = "SubTypeExplanat";
                    SubTypeExplanat.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SubTypeExplanat.TextFont.Name = "Arial Narrow";
                    SubTypeExplanat.TextFont.Size = 9;
                    SubTypeExplanat.Value = @"Deniz ve Sualtı Hekimliği Servisi";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 69, 206, 74, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.Name = "Arial Narrow";
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.Value = @"{#PROTOCOLNO#}";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 69, 58, 74, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Name = "Arial Narrow";
                    NewField16.TextFont.Size = 9;
                    NewField16.TextFont.Bold = true;
                    NewField16.Value = @"Adı Soyadı";

                    NewField167 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 74, 58, 79, false);
                    NewField167.Name = "NewField167";
                    NewField167.TextFont.Name = "Arial Narrow";
                    NewField167.TextFont.Size = 9;
                    NewField167.TextFont.Bold = true;
                    NewField167.Value = @"Doğum Tarihi ve Yeri";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 79, 58, 84, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Name = "Arial Narrow";
                    NewField17.TextFont.Size = 9;
                    NewField17.TextFont.Bold = true;
                    NewField17.Value = @"Rütbesi";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 84, 58, 89, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Name = "Arial Narrow";
                    NewField18.TextFont.Size = 9;
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @"Kabul Sebebi";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 91, 58, 96, false);
                    NewField20.Name = "NewField20";
                    NewField20.TextFont.Name = "Arial Narrow";
                    NewField20.TextFont.Size = 9;
                    NewField20.TextFont.Bold = true;
                    NewField20.Value = @"İstek Notu";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 69, 167, 74, false);
                    NewField22.Name = "NewField22";
                    NewField22.TextFont.Name = "Arial Narrow";
                    NewField22.TextFont.Size = 9;
                    NewField22.TextFont.Bold = true;
                    NewField22.Value = @"Protokol No";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 74, 206, 79, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.ObjectDefName = "HyperbaricOxygenTreatmentOrder";
                    HASTANO.DataMember = "EPISODE.PATIENT.ID";
                    HASTANO.TextFont.Name = "Arial Narrow";
                    HASTANO.TextFont.Size = 9;
                    HASTANO.Value = @"{@TTOBJECTID@}";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 74, 167, 79, false);
                    NewField24.Name = "NewField24";
                    NewField24.TextFont.Name = "Arial Narrow";
                    NewField24.TextFont.Size = 9;
                    NewField24.TextFont.Bold = true;
                    NewField24.Value = @"Hasta No";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 79, 206, 84, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.TextFont.Name = "Arial Narrow";
                    ACTIONID.TextFont.Size = 9;
                    ACTIONID.Value = @"{#ACTIONID#}";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 79, 167, 84, false);
                    NewField26.Name = "NewField26";
                    NewField26.TextFont.Name = "Arial Narrow";
                    NewField26.TextFont.Size = 9;
                    NewField26.TextFont.Bold = true;
                    NewField26.Value = @"İşlem No";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 64, 206, 69, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"g";
                    TARIH.TextFont.Name = "Arial Narrow";
                    TARIH.TextFont.Size = 9;
                    TARIH.Value = @"{#ACTIONDATE#}";

                    NewField27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 64, 167, 69, false);
                    NewField27.Name = "NewField27";
                    NewField27.TextFont.Name = "Arial Narrow";
                    NewField27.TextFont.Size = 9;
                    NewField27.TextFont.Bold = true;
                    NewField27.Value = @"Tarih";

                    DYERTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 74, 133, 79, false);
                    DYERTAR.Name = "DYERTAR";
                    DYERTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERTAR.TextFont.Name = "Arial Narrow";
                    DYERTAR.TextFont.Size = 9;
                    DYERTAR.Value = @"{%DTARIH%} {%DYER%}";

                    HYPERBARICREQUESTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 59, 255, 64, false);
                    HYPERBARICREQUESTOBJECTID.Name = "HYPERBARICREQUESTOBJECTID";
                    HYPERBARICREQUESTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    HYPERBARICREQUESTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    HYPERBARICREQUESTOBJECTID.TextFont.Name = "Arial Narrow";
                    HYPERBARICREQUESTOBJECTID.TextFont.Size = 9;
                    HYPERBARICREQUESTOBJECTID.Value = @"{#HBARIKOXYGENTREATREQOBJECTID#}";

                    AYAKTANYATAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 47, 168, 51, false);
                    AYAKTANYATAN.Name = "AYAKTANYATAN";
                    AYAKTANYATAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    AYAKTANYATAN.CaseFormat = CaseFormatEnum.fcUpperCase;
                    AYAKTANYATAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AYAKTANYATAN.TextFont.Name = "Arial Narrow";
                    AYAKTANYATAN.TextFont.Size = 9;
                    AYAKTANYATAN.TextFont.Bold = true;
                    AYAKTANYATAN.Value = @"{%AYAKYATANCODED%} HASTA";

                    EPISODEID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 45, 266, 50, false);
                    EPISODEID.Name = "EPISODEID";
                    EPISODEID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEID.ObjectDefName = "HyperbaricOxygenTreatmentOrder";
                    EPISODEID.DataMember = "EPISODE.ID";
                    EPISODEID.TextFont.Name = "Arial Narrow";
                    EPISODEID.TextFont.Size = 9;
                    EPISODEID.Value = @"{@TTOBJECTID@}";

                    LOGO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 50, 30, false);
                    LOGO1.Name = "LOGO1";
                    LOGO1.TextFont.CharSet = 1;
                    LOGO1.Value = @"Logo";

                    REPORTHEADER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 34, 168, 42, false);
                    REPORTHEADER1.Name = "REPORTHEADER1";
                    REPORTHEADER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER1.TextFont.Name = "Arial Narrow";
                    REPORTHEADER1.TextFont.Size = 15;
                    REPORTHEADER1.TextFont.Bold = true;
                    REPORTHEADER1.Value = @"HİPERBARİK OKSİJEN TEDAVİSİ İSTEK RAPORU";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 69, 60, 74, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @":";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 74, 60, 79, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial Narrow";
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @":";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 79, 60, 84, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial Narrow";
                    NewField12.TextFont.Size = 9;
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @":";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 84, 60, 89, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial Narrow";
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @":";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 79, 169, 84, false);
                    NewField122.Name = "NewField122";
                    NewField122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Name = "Arial Narrow";
                    NewField122.TextFont.Size = 9;
                    NewField122.TextFont.Bold = true;
                    NewField122.Value = @":";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 74, 169, 79, false);
                    NewField123.Name = "NewField123";
                    NewField123.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField123.TextFont.Name = "Arial Narrow";
                    NewField123.TextFont.Size = 9;
                    NewField123.TextFont.Bold = true;
                    NewField123.Value = @":";

                    NewField124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 69, 169, 74, false);
                    NewField124.Name = "NewField124";
                    NewField124.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField124.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField124.TextFont.Name = "Arial Narrow";
                    NewField124.TextFont.Size = 9;
                    NewField124.TextFont.Bold = true;
                    NewField124.Value = @":";

                    NewField125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 64, 169, 69, false);
                    NewField125.Name = "NewField125";
                    NewField125.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField125.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField125.TextFont.Name = "Arial Narrow";
                    NewField125.TextFont.Size = 9;
                    NewField125.TextFont.Bold = true;
                    NewField125.Value = @":";

                    NewField128 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 91, 60, 96, false);
                    NewField128.Name = "NewField128";
                    NewField128.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField128.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField128.TextFont.Name = "Arial Narrow";
                    NewField128.TextFont.Size = 9;
                    NewField128.TextFont.Bold = true;
                    NewField128.Value = @":";

                    EPISODEOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 50, 266, 55, false);
                    EPISODEOBJECTID.Name = "EPISODEOBJECTID";
                    EPISODEOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEOBJECTID.TextFont.Name = "Arial Narrow";
                    EPISODEOBJECTID.TextFont.Size = 9;
                    EPISODEOBJECTID.Value = @"{#EPISODEOBJECTID#}";

                    AYAKYATANCODED = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 55, 255, 59, false);
                    AYAKYATANCODED.Name = "AYAKYATANCODED";
                    AYAKYATANCODED.Visible = EvetHayirEnum.ehHayir;
                    AYAKYATANCODED.FieldType = ReportFieldTypeEnum.ftVariable;
                    AYAKYATANCODED.ObjectDefName = "PatientStatusEnum";
                    AYAKYATANCODED.DataMember = "DISPLAYTEXT";
                    AYAKYATANCODED.TextFont.Name = "Arial Narrow";
                    AYAKYATANCODED.TextFont.Size = 9;
                    AYAKYATANCODED.Value = @"{#PATIENTSTATUS#}";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 64, 133, 69, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.Value = @"{#UNIQUEREFNO#}";

                    LBLUNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 64, 58, 69, false);
                    LBLUNIQUEREFNO.Name = "LBLUNIQUEREFNO";
                    LBLUNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    LBLUNIQUEREFNO.TextFont.Size = 9;
                    LBLUNIQUEREFNO.TextFont.Bold = true;
                    LBLUNIQUEREFNO.Value = @"T.C. Kimlik No";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 64, 60, 69, false);
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
                    HyperbaricOxygenTreatmentOrder.HyperbaricAcceptionReportNQL_Class dataset_HyperbaricAcceptionReportNQL = ParentGroup.rsGroup.GetCurrentRecord<HyperbaricOxygenTreatmentOrder.HyperbaricAcceptionReportNQL_Class>(0);
                    NewField2.CalcValue = NewField2.Value;
                    NAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NAME.PostFieldValueCalculation();
                    DTARIH.CalcValue = (dataset_HyperbaricAcceptionReportNQL != null ? Globals.ToStringCore(dataset_HyperbaricAcceptionReportNQL.BirthDate) : "");
                    RUTBE.CalcValue = @"";
                    KABULSEBEBI.CalcValue = (dataset_HyperbaricAcceptionReportNQL != null ? Globals.ToStringCore(dataset_HyperbaricAcceptionReportNQL.Reasonforadm) : "");
                    DYER.CalcValue = (dataset_HyperbaricAcceptionReportNQL != null ? Globals.ToStringCore(dataset_HyperbaricAcceptionReportNQL.Cityname) : "");
                    NOT.CalcValue = (dataset_HyperbaricAcceptionReportNQL != null ? Globals.ToStringCore(dataset_HyperbaricAcceptionReportNQL.Note) : "");
                    SubTypeExplanat.CalcValue = SubTypeExplanat.Value;
                    PROTOKOLNO.CalcValue = (dataset_HyperbaricAcceptionReportNQL != null ? Globals.ToStringCore(dataset_HyperbaricAcceptionReportNQL.ProtocolNo) : "");
                    NewField16.CalcValue = NewField16.Value;
                    NewField167.CalcValue = NewField167.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField20.CalcValue = NewField20.Value;
                    NewField22.CalcValue = NewField22.Value;
                    HASTANO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    HASTANO.PostFieldValueCalculation();
                    NewField24.CalcValue = NewField24.Value;
                    ACTIONID.CalcValue = (dataset_HyperbaricAcceptionReportNQL != null ? Globals.ToStringCore(dataset_HyperbaricAcceptionReportNQL.Actionid) : "");
                    NewField26.CalcValue = NewField26.Value;
                    TARIH.CalcValue = (dataset_HyperbaricAcceptionReportNQL != null ? Globals.ToStringCore(dataset_HyperbaricAcceptionReportNQL.ActionDate) : "");
                    NewField27.CalcValue = NewField27.Value;
                    DYERTAR.CalcValue = MyParentReport.MASTER.DTARIH.FormattedValue + @" " + MyParentReport.MASTER.DYER.CalcValue;
                    HYPERBARICREQUESTOBJECTID.CalcValue = (dataset_HyperbaricAcceptionReportNQL != null ? Globals.ToStringCore(dataset_HyperbaricAcceptionReportNQL.Hbarikoxygentreatreqobjectid) : "");
                    AYAKYATANCODED.CalcValue = (dataset_HyperbaricAcceptionReportNQL != null ? Globals.ToStringCore(dataset_HyperbaricAcceptionReportNQL.PatientStatus) : "");
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
                    NewField128.CalcValue = NewField128.Value;
                    EPISODEOBJECTID.CalcValue = (dataset_HyperbaricAcceptionReportNQL != null ? Globals.ToStringCore(dataset_HyperbaricAcceptionReportNQL.Episodeobjectid) : "");
                    UNIQUEREFNO.CalcValue = (dataset_HyperbaricAcceptionReportNQL != null ? Globals.ToStringCore(dataset_HyperbaricAcceptionReportNQL.UniqueRefNo) : "");
                    LBLUNIQUEREFNO.CalcValue = LBLUNIQUEREFNO.Value;
                    NewField13.CalcValue = NewField13.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField2,NAME,DTARIH,RUTBE,KABULSEBEBI,DYER,NOT,SubTypeExplanat,PROTOKOLNO,NewField16,NewField167,NewField17,NewField18,NewField20,NewField22,HASTANO,NewField24,ACTIONID,NewField26,TARIH,NewField27,DYERTAR,HYPERBARICREQUESTOBJECTID,AYAKYATANCODED,AYAKTANYATAN,EPISODEID,LOGO1,REPORTHEADER1,NewField1,NewField11,NewField12,NewField121,NewField122,NewField123,NewField124,NewField125,NewField128,EPISODEOBJECTID,UNIQUEREFNO,LBLUNIQUEREFNO,NewField13,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region MASTER HEADER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((HyperbaricOxygenAcceptionReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HyperbaricOxygenTreatmentOrder hyperbaricOxygenTreatmentOrder = (HyperbaricOxygenTreatmentOrder)objectContext.GetObject(new Guid(objectID),"HyperbaricOxygenTreatmentOrder");
            
            if (hyperbaricOxygenTreatmentOrder.Episode.Patient.Foreign == true)
            {
                this.UNIQUEREFNO.CalcValue = hyperbaricOxygenTreatmentOrder.Episode.Patient.ForeignUniqueRefNo.ToString();
                this.LBLUNIQUEREFNO.CalcValue = "Kimlik/Sigorta No (Yabancı Hasta)";
            }
            else
            {
                this.UNIQUEREFNO.CalcValue = hyperbaricOxygenTreatmentOrder.Episode.Patient.UniqueRefNo.ToString();
                this.LBLUNIQUEREFNO.CalcValue = "T.C. Kimlik No";
            }
#endregion MASTER HEADER_Script
                }
            }
            public partial class MASTERGroupFooter : TTReportSection
            {
                public HyperbaricOxygenAcceptionReport MyParentReport
                {
                    get { return (HyperbaricOxygenAcceptionReport)ParentReport; }
                }
                
                public TTReportField NewField0;
                public TTReportShape NewLine2;
                public TTReportField FOOTER;
                public TTReportField NewField9;
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

                    Height = 46;
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

                    FOOTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 33, 206, 38, false);
                    FOOTER.Name = "FOOTER";
                    FOOTER.FieldType = ReportFieldTypeEnum.ftExpression;
                    FOOTER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FOOTER.TextFont.Name = "Arial Narrow";
                    FOOTER.TextFont.Size = 9;
                    FOOTER.TextFont.Bold = true;
                    FOOTER.TextFont.Italic = true;
                    FOOTER.Value = @"""Randevu tarihinde gelemeyecek iseniz bizi bilgilendiriniz. Tel :"" + TTObjectClasses.SystemParameter.GetParameterValue(""HYPERBARICTELNO"", """")";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 29, 206, 33, false);
                    NewField9.Name = "NewField9";
                    NewField9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField9.TextFont.Name = "Arial Narrow";
                    NewField9.TextFont.Size = 9;
                    NewField9.TextFont.Bold = true;
                    NewField9.Value = @"Tedaviye gelirken yanınızda .... adet havlu getiriniz.";

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

                    UZMANLIKDAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 7, 202, 11, false);
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

                    RUTBEONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 11, 149, 15, false);
                    RUTBEONAY.Name = "RUTBEONAY";
                    RUTBEONAY.Visible = EvetHayirEnum.ehHayir;
                    RUTBEONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBEONAY.MultiLine = EvetHayirEnum.ehEvet;
                    RUTBEONAY.TextFont.Name = "Arial Narrow";
                    RUTBEONAY.TextFont.Size = 9;
                    RUTBEONAY.Value = @"{#DOKRANK#}";

                    SINIFONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 6, 175, 11, false);
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

                    GOREV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 6, 149, 11, false);
                    GOREV.Name = "GOREV";
                    GOREV.Visible = EvetHayirEnum.ehHayir;
                    GOREV.FieldType = ReportFieldTypeEnum.ftVariable;
                    GOREV.TextFont.Name = "Arial Narrow";
                    GOREV.TextFont.Size = 9;
                    GOREV.Value = @"{#DOCWORK#}";

                    DIPLOMANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 15, 203, 19, false);
                    DIPLOMANO.Name = "DIPLOMANO";
                    DIPLOMANO.Visible = EvetHayirEnum.ehHayir;
                    DIPLOMANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMANO.TextFont.Name = "Arial Narrow";
                    DIPLOMANO.TextFont.Size = 9;
                    DIPLOMANO.Value = @"{#DOCDIPLOMANO#}";

                    SICILKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 11, 202, 15, false);
                    SICILKULLAN.Name = "SICILKULLAN";
                    SICILKULLAN.Visible = EvetHayirEnum.ehHayir;
                    SICILKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    SICILKULLAN.TextFont.Name = "Arial Narrow";
                    SICILKULLAN.TextFont.Size = 9;
                    SICILKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SICILKULLAN"", """")";

                    UNVANKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 15, 149, 19, false);
                    UNVANKULLAN.Name = "UNVANKULLAN";
                    UNVANKULLAN.Visible = EvetHayirEnum.ehHayir;
                    UNVANKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    UNVANKULLAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.TextFont.Name = "Arial Narrow";
                    UNVANKULLAN.TextFont.Size = 9;
                    UNVANKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""UNVANKULLAN"", """")";

                    UNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 11, 175, 16, false);
                    UNVAN.Name = "UNVAN";
                    UNVAN.Visible = EvetHayirEnum.ehHayir;
                    UNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNVAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVAN.TextFont.Name = "Arial Narrow";
                    UNVAN.TextFont.Size = 9;
                    UNVAN.Value = @"{#DOCTITLE#}";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 16, 176, 20, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.Visible = EvetHayirEnum.ehHayir;
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.TextFont.Name = "Arial Narrow";
                    SICILNO.TextFont.Size = 9;
                    SICILNO.Value = @"{#DOCEMPLOYMENTRECORDID#}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 1, 206, 6, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PrintDate.TextFont.Name = "Arial Narrow";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.Value = @"{@printdate@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 39, 120, 44, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PageNumber.TextFont.Name = "Arial Narrow";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HyperbaricOxygenTreatmentOrder.HyperbaricAcceptionReportNQL_Class dataset_HyperbaricAcceptionReportNQL = ParentGroup.rsGroup.GetCurrentRecord<HyperbaricOxygenTreatmentOrder.HyperbaricAcceptionReportNQL_Class>(0);
                    NewField0.CalcValue = NewField0.Value;
                    NewField9.CalcValue = NewField9.Value;
                    DIPSIC.CalcValue = @"";
                    ADSOYADDOC.CalcValue = (dataset_HyperbaricAcceptionReportNQL != null ? Globals.ToStringCore(dataset_HyperbaricAcceptionReportNQL.Proceduredoctorname) : "");
                    UZMANLIKDAL.CalcValue = (dataset_HyperbaricAcceptionReportNQL != null ? Globals.ToStringCore(dataset_HyperbaricAcceptionReportNQL.Docspeciality) : "");
                    DIPSICLABEL.CalcValue = @"DIPLOMASICIL";
                    SINRUT.CalcValue = @"";
                    RUTBEONAY.CalcValue = (dataset_HyperbaricAcceptionReportNQL != null ? Globals.ToStringCore(dataset_HyperbaricAcceptionReportNQL.Dokrank) : "");
                    SINIFONAY.CalcValue = (dataset_HyperbaricAcceptionReportNQL != null ? Globals.ToStringCore(dataset_HyperbaricAcceptionReportNQL.Docmilitaryclass) : "");
                    UZ.CalcValue = MyParentReport.MASTER.UZMANLIKDAL.CalcValue;
                    GOREV.CalcValue = (dataset_HyperbaricAcceptionReportNQL != null ? Globals.ToStringCore(dataset_HyperbaricAcceptionReportNQL.Docwork) : "");
                    DIPLOMANO.CalcValue = (dataset_HyperbaricAcceptionReportNQL != null ? Globals.ToStringCore(dataset_HyperbaricAcceptionReportNQL.Docdiplomano) : "");
                    UNVAN.CalcValue = (dataset_HyperbaricAcceptionReportNQL != null ? Globals.ToStringCore(dataset_HyperbaricAcceptionReportNQL.Doctitle) : "");
                    SICILNO.CalcValue = (dataset_HyperbaricAcceptionReportNQL != null ? Globals.ToStringCore(dataset_HyperbaricAcceptionReportNQL.Docemploymentrecordid) : "");
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    FOOTER.CalcValue = "Randevu tarihinde gelemeyecek iseniz bizi bilgilendiriniz. Tel :" + TTObjectClasses.SystemParameter.GetParameterValue("HYPERBARICTELNO", "");
                    SICILKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "");
                    UNVANKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "");
                    return new TTReportObject[] { NewField0,NewField9,DIPSIC,ADSOYADDOC,UZMANLIKDAL,DIPSICLABEL,SINRUT,RUTBEONAY,SINIFONAY,UZ,GOREV,DIPLOMANO,UNVAN,SICILNO,PrintDate,PageNumber,FOOTER,SICILKULLAN,UNVANKULLAN};
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
            public HyperbaricOxygenAcceptionReport MyParentReport
            {
                get { return (HyperbaricOxygenAcceptionReport)ParentReport; }
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
                public HyperbaricOxygenAcceptionReport MyParentReport
                {
                    get { return (HyperbaricOxygenAcceptionReport)ParentReport; }
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
                    NewField111412.Value = @"Tanı Tipi";

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
                public HyperbaricOxygenAcceptionReport MyParentReport
                {
                    get { return (HyperbaricOxygenAcceptionReport)ParentReport; }
                }
                
                public TTReportShape NewLine11111; 
                public ARAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 2, 206, 2, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public ARAGroup ARA;

        public partial class MAINGroup : TTReportGroup
        {
            public HyperbaricOxygenAcceptionReport MyParentReport
            {
                get { return (HyperbaricOxygenAcceptionReport)ParentReport; }
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
                public HyperbaricOxygenAcceptionReport MyParentReport
                {
                    get { return (HyperbaricOxygenAcceptionReport)ParentReport; }
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
            public HyperbaricOxygenAcceptionReport MyParentReport
            {
                get { return (HyperbaricOxygenAcceptionReport)ParentReport; }
            }

            new public ORDERSGroupHeader Header()
            {
                return (ORDERSGroupHeader)_header;
            }

            new public ORDERSGroupFooter Footer()
            {
                return (ORDERSGroupFooter)_footer;
            }

            public TTReportField ORDEROBJECTOBJECTID { get {return Header().ORDEROBJECTOBJECTID;} }
            public TTReportField PROCEDUREOBJECTCODENAME { get {return Header().PROCEDUREOBJECTCODENAME;} }
            public TTReportField TREATMENTDEPTH { get {return Header().TREATMENTDEPTH;} }
            public TTReportField DURATION { get {return Header().DURATION;} }
            public TTReportField AMOUNT { get {return Header().AMOUNT;} }
            public TTReportField TREATMENTDIAGNOSISUNITNAME { get {return Header().TREATMENTDIAGNOSISUNITNAME;} }
            public TTReportField NewField1121141111 { get {return Header().NewField1121141111;} }
            public TTReportField NewField11111411211 { get {return Header().NewField11111411211;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine1211 { get {return Header().NewLine1211;} }
            public TTReportField NewField11114111 { get {return Header().NewField11114111;} }
            public TTReportField NewField111141111 { get {return Header().NewField111141111;} }
            public TTReportField NewField112141111 { get {return Header().NewField112141111;} }
            public TTReportField NewField1111141211 { get {return Header().NewField1111141211;} }
            public TTReportField NewField11121411111 { get {return Header().NewField11121411111;} }
            public TTReportField NewField1121141113 { get {return Header().NewField1121141113;} }
            public TTReportField NewField1121141114 { get {return Header().NewField1121141114;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField TREATMENTPROPERTIES { get {return Header().TREATMENTPROPERTIES;} }
            public TTReportField NewField118211 { get {return Header().NewField118211;} }
            public TTReportField NewField111141121 { get {return Header().NewField111141121;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
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
                list[0] = new TTReportNqlData<HyperbarikOxygenTreatmentOrderDetail.GetHyperbaricOrderDetails_Class>("GetHyperbaricOrderDetails", HyperbarikOxygenTreatmentOrderDetail.GetHyperbaricOrderDetails((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.MASTER.HYPERBARICREQUESTOBJECTID.CalcValue)));
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
                public HyperbaricOxygenAcceptionReport MyParentReport
                {
                    get { return (HyperbaricOxygenAcceptionReport)ParentReport; }
                }
                
                public TTReportField ORDEROBJECTOBJECTID;
                public TTReportField PROCEDUREOBJECTCODENAME;
                public TTReportField TREATMENTDEPTH;
                public TTReportField DURATION;
                public TTReportField AMOUNT;
                public TTReportField TREATMENTDIAGNOSISUNITNAME;
                public TTReportField NewField1121141111;
                public TTReportField NewField11111411211;
                public TTReportShape NewLine12;
                public TTReportShape NewLine1211;
                public TTReportField NewField11114111;
                public TTReportField NewField111141111;
                public TTReportField NewField112141111;
                public TTReportField NewField1111141211;
                public TTReportField NewField11121411111;
                public TTReportField NewField1121141113;
                public TTReportField NewField1121141114;
                public TTReportField NewField11;
                public TTReportField TREATMENTPROPERTIES;
                public TTReportField NewField118211;
                public TTReportField NewField111141121;
                public TTReportField NewField1; 
                public ORDERSGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 31;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ORDEROBJECTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 8, 213, 13, false);
                    ORDEROBJECTOBJECTID.Name = "ORDEROBJECTOBJECTID";
                    ORDEROBJECTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    ORDEROBJECTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDEROBJECTOBJECTID.MultiLine = EvetHayirEnum.ehEvet;
                    ORDEROBJECTOBJECTID.WordBreak = EvetHayirEnum.ehEvet;
                    ORDEROBJECTOBJECTID.TextFont.Name = "Arial Narrow";
                    ORDEROBJECTOBJECTID.TextFont.Size = 9;
                    ORDEROBJECTOBJECTID.Value = @"{#ORDEROBJECTOBJECTID#}";

                    PROCEDUREOBJECTCODENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 112, 13, false);
                    PROCEDUREOBJECTCODENAME.Name = "PROCEDUREOBJECTCODENAME";
                    PROCEDUREOBJECTCODENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREOBJECTCODENAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PROCEDUREOBJECTCODENAME.MultiLine = EvetHayirEnum.ehEvet;
                    PROCEDUREOBJECTCODENAME.NoClip = EvetHayirEnum.ehEvet;
                    PROCEDUREOBJECTCODENAME.WordBreak = EvetHayirEnum.ehEvet;
                    PROCEDUREOBJECTCODENAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PROCEDUREOBJECTCODENAME.TextFont.Name = "Arial Narrow";
                    PROCEDUREOBJECTCODENAME.TextFont.Size = 9;
                    PROCEDUREOBJECTCODENAME.TextFont.Bold = true;
                    PROCEDUREOBJECTCODENAME.Value = @"{#PROCEDUREOBJECTCODE#} {#PROCEDUREOBJECTNAME#}";

                    TREATMENTDEPTH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 8, 153, 13, false);
                    TREATMENTDEPTH.Name = "TREATMENTDEPTH";
                    TREATMENTDEPTH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TREATMENTDEPTH.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TREATMENTDEPTH.MultiLine = EvetHayirEnum.ehEvet;
                    TREATMENTDEPTH.WordBreak = EvetHayirEnum.ehEvet;
                    TREATMENTDEPTH.TextFont.Name = "Arial Narrow";
                    TREATMENTDEPTH.TextFont.Size = 9;
                    TREATMENTDEPTH.Value = @"{#TREATMENTDEPTH#}";

                    DURATION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 8, 124, 13, false);
                    DURATION.Name = "DURATION";
                    DURATION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DURATION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DURATION.TextFont.Name = "Arial Narrow";
                    DURATION.TextFont.Size = 9;
                    DURATION.Value = @"{#ORDEROBJECTDURATION#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 8, 162, 13, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.TextFont.Name = "Arial Narrow";
                    AMOUNT.TextFont.Size = 9;
                    AMOUNT.Value = @"{#ORDEROBJECTAMOUNT#}";

                    TREATMENTDIAGNOSISUNITNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 8, 206, 13, false);
                    TREATMENTDIAGNOSISUNITNAME.Name = "TREATMENTDIAGNOSISUNITNAME";
                    TREATMENTDIAGNOSISUNITNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TREATMENTDIAGNOSISUNITNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TREATMENTDIAGNOSISUNITNAME.MultiLine = EvetHayirEnum.ehEvet;
                    TREATMENTDIAGNOSISUNITNAME.WordBreak = EvetHayirEnum.ehEvet;
                    TREATMENTDIAGNOSISUNITNAME.TextFont.Name = "Arial Narrow";
                    TREATMENTDIAGNOSISUNITNAME.TextFont.Size = 9;
                    TREATMENTDIAGNOSISUNITNAME.Value = @"{#TREATMENTDIAGNOSISUNITNAME#}";

                    NewField1121141111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 20, 263, 25, false);
                    NewField1121141111.Name = "NewField1121141111";
                    NewField1121141111.Visible = EvetHayirEnum.ehHayir;
                    NewField1121141111.TextFont.Name = "Arial Narrow";
                    NewField1121141111.TextFont.Size = 9;
                    NewField1121141111.TextFont.Bold = true;
                    NewField1121141111.Value = @" Tedavi Cihazı";

                    NewField11111411211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 24, 206, 29, false);
                    NewField11111411211.Name = "NewField11111411211";
                    NewField11111411211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111411211.TextFont.Name = "Arial Narrow";
                    NewField11111411211.TextFont.Size = 9;
                    NewField11111411211.TextFont.Bold = true;
                    NewField11111411211.Value = @"Acil";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 30, 206, 30, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 7, 206, 7, false);
                    NewLine1211.Name = "NewLine1211";
                    NewLine1211.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 112, 6, false);
                    NewField11114111.Name = "NewField11114111";
                    NewField11114111.TextFont.Name = "Arial Narrow";
                    NewField11114111.TextFont.Size = 9;
                    NewField11114111.TextFont.Bold = true;
                    NewField11114111.Value = @"İstenen Tetkik";

                    NewField111141111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 1, 153, 6, false);
                    NewField111141111.Name = "NewField111141111";
                    NewField111141111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111141111.TextFont.Name = "Arial Narrow";
                    NewField111141111.TextFont.Size = 9;
                    NewField111141111.TextFont.Bold = true;
                    NewField111141111.Value = @"Tedavi Derinliği (m)";

                    NewField112141111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 1, 124, 6, false);
                    NewField112141111.Name = "NewField112141111";
                    NewField112141111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112141111.TextFont.Name = "Arial Narrow";
                    NewField112141111.TextFont.Size = 9;
                    NewField112141111.TextFont.Bold = true;
                    NewField112141111.Value = @"Süre/dk";

                    NewField1111141211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 1, 162, 6, false);
                    NewField1111141211.Name = "NewField1111141211";
                    NewField1111141211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111141211.TextFont.Name = "Arial Narrow";
                    NewField1111141211.TextFont.Size = 9;
                    NewField1111141211.TextFont.Bold = true;
                    NewField1111141211.Value = @"Seans";

                    NewField11121411111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 1, 206, 6, false);
                    NewField11121411111.Name = "NewField11121411111";
                    NewField11121411111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11121411111.TextFont.Name = "Arial Narrow";
                    NewField11121411111.TextFont.Size = 9;
                    NewField11121411111.TextFont.Bold = true;
                    NewField11121411111.Value = @"Tanı Tedavi Birimi";

                    NewField1121141113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 24, 32, 29, false);
                    NewField1121141113.Name = "NewField1121141113";
                    NewField1121141113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121141113.TextFont.Name = "Arial Narrow";
                    NewField1121141113.TextFont.Size = 9;
                    NewField1121141113.TextFont.Bold = true;
                    NewField1121141113.Value = @"Seans No";

                    NewField1121141114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 24, 184, 29, false);
                    NewField1121141114.Name = "NewField1121141114";
                    NewField1121141114.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121141114.TextFont.Name = "Arial Narrow";
                    NewField1121141114.TextFont.Size = 9;
                    NewField1121141114.TextFont.Bold = true;
                    NewField1121141114.Value = @"İşlemi Yapacak Operatör";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 16, 56, 21, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial Narrow";
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"Basınç Odası Operatörüne Talimatlar";

                    TREATMENTPROPERTIES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 16, 206, 21, false);
                    TREATMENTPROPERTIES.Name = "TREATMENTPROPERTIES";
                    TREATMENTPROPERTIES.FieldType = ReportFieldTypeEnum.ftVariable;
                    TREATMENTPROPERTIES.TextFormat = @"Long Date";
                    TREATMENTPROPERTIES.MultiLine = EvetHayirEnum.ehEvet;
                    TREATMENTPROPERTIES.NoClip = EvetHayirEnum.ehEvet;
                    TREATMENTPROPERTIES.WordBreak = EvetHayirEnum.ehEvet;
                    TREATMENTPROPERTIES.ExpandTabs = EvetHayirEnum.ehEvet;
                    TREATMENTPROPERTIES.TextFont.Name = "Arial Narrow";
                    TREATMENTPROPERTIES.TextFont.Size = 9;
                    TREATMENTPROPERTIES.Value = @"{#ORDEROBJECTTREATMENTPROPERTIES#}";

                    NewField118211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 16, 58, 21, false);
                    NewField118211.Name = "NewField118211";
                    NewField118211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField118211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField118211.TextFont.Name = "Arial Narrow";
                    NewField118211.TextFont.Size = 9;
                    NewField118211.TextFont.Bold = true;
                    NewField118211.Value = @":";

                    NewField111141121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 14, 255, 19, false);
                    NewField111141121.Name = "NewField111141121";
                    NewField111141121.Visible = EvetHayirEnum.ehHayir;
                    NewField111141121.TextFont.Name = "Arial Narrow";
                    NewField111141121.TextFont.Size = 9;
                    NewField111141121.TextFont.Bold = true;
                    NewField111141121.Value = @"Seans Randevu Tarihi Saati";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 24, 68, 29, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"Seans Randevu Tarihi Saati";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HyperbarikOxygenTreatmentOrderDetail.GetHyperbaricOrderDetails_Class dataset_GetHyperbaricOrderDetails = ParentGroup.rsGroup.GetCurrentRecord<HyperbarikOxygenTreatmentOrderDetail.GetHyperbaricOrderDetails_Class>(0);
                    ORDEROBJECTOBJECTID.CalcValue = (dataset_GetHyperbaricOrderDetails != null ? Globals.ToStringCore(dataset_GetHyperbaricOrderDetails.Orderobjectobjectid) : "");
                    PROCEDUREOBJECTCODENAME.CalcValue = (dataset_GetHyperbaricOrderDetails != null ? Globals.ToStringCore(dataset_GetHyperbaricOrderDetails.Procedureobjectcode) : "") + @" " + (dataset_GetHyperbaricOrderDetails != null ? Globals.ToStringCore(dataset_GetHyperbaricOrderDetails.Procedureobjectname) : "");
                    TREATMENTDEPTH.CalcValue = (dataset_GetHyperbaricOrderDetails != null ? Globals.ToStringCore(dataset_GetHyperbaricOrderDetails.TreatmentDepth) : "");
                    DURATION.CalcValue = (dataset_GetHyperbaricOrderDetails != null ? Globals.ToStringCore(dataset_GetHyperbaricOrderDetails.Orderobjectduration) : "");
                    AMOUNT.CalcValue = (dataset_GetHyperbaricOrderDetails != null ? Globals.ToStringCore(dataset_GetHyperbaricOrderDetails.Orderobjectamount) : "");
                    TREATMENTDIAGNOSISUNITNAME.CalcValue = (dataset_GetHyperbaricOrderDetails != null ? Globals.ToStringCore(dataset_GetHyperbaricOrderDetails.Treatmentdiagnosisunitname) : "");
                    NewField1121141111.CalcValue = NewField1121141111.Value;
                    NewField11111411211.CalcValue = NewField11111411211.Value;
                    NewField11114111.CalcValue = NewField11114111.Value;
                    NewField111141111.CalcValue = NewField111141111.Value;
                    NewField112141111.CalcValue = NewField112141111.Value;
                    NewField1111141211.CalcValue = NewField1111141211.Value;
                    NewField11121411111.CalcValue = NewField11121411111.Value;
                    NewField1121141113.CalcValue = NewField1121141113.Value;
                    NewField1121141114.CalcValue = NewField1121141114.Value;
                    NewField11.CalcValue = NewField11.Value;
                    TREATMENTPROPERTIES.CalcValue = (dataset_GetHyperbaricOrderDetails != null ? Globals.ToStringCore(dataset_GetHyperbaricOrderDetails.Orderobjecttreatmentproperties) : "");
                    NewField118211.CalcValue = NewField118211.Value;
                    NewField111141121.CalcValue = NewField111141121.Value;
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { ORDEROBJECTOBJECTID,PROCEDUREOBJECTCODENAME,TREATMENTDEPTH,DURATION,AMOUNT,TREATMENTDIAGNOSISUNITNAME,NewField1121141111,NewField11111411211,NewField11114111,NewField111141111,NewField112141111,NewField1111141211,NewField11121411111,NewField1121141113,NewField1121141114,NewField11,TREATMENTPROPERTIES,NewField118211,NewField111141121,NewField1};
                }
            }
            public partial class ORDERSGroupFooter : TTReportSection
            {
                public HyperbaricOxygenAcceptionReport MyParentReport
                {
                    get { return (HyperbaricOxygenAcceptionReport)ParentReport; }
                }
                 
                public ORDERSGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public ORDERSGroup ORDERS;

        public partial class ORDERDETAILSGroup : TTReportGroup
        {
            public HyperbaricOxygenAcceptionReport MyParentReport
            {
                get { return (HyperbaricOxygenAcceptionReport)ParentReport; }
            }

            new public ORDERDETAILSGroupBody Body()
            {
                return (ORDERDETAILSGroupBody)_body;
            }
            public TTReportField WORKLISTDATE { get {return Body().WORKLISTDATE;} }
            public TTReportField TREATMENTEQUIPMENTNAME { get {return Body().TREATMENTEQUIPMENTNAME;} }
            public TTReportField EMERGENCY { get {return Body().EMERGENCY;} }
            public TTReportField CURENUMBER { get {return Body().CURENUMBER;} }
            public TTReportField PROCEDUREBYUSER { get {return Body().PROCEDUREBYUSER;} }
            public TTReportField ORDEROBJECTPROCEDUREDOCTOR { get {return Body().ORDEROBJECTPROCEDUREDOCTOR;} }
            public TTReportField ORDERDETAILPROCEDUREBYUSER { get {return Body().ORDERDETAILPROCEDUREBYUSER;} }
            public ORDERDETAILSGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ORDERDETAILSGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                HyperbarikOxygenTreatmentOrderDetail.GetHyperbaricOrderDetails_Class dataSet_GetHyperbaricOrderDetails = ParentGroup.rsGroup.GetCurrentRecord<HyperbarikOxygenTreatmentOrderDetail.GetHyperbaricOrderDetails_Class>(0);    
                return new object[] {(dataSet_GetHyperbaricOrderDetails==null ? null : dataSet_GetHyperbaricOrderDetails.Orderobjectobjectid)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ORDERDETAILSGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class ORDERDETAILSGroupBody : TTReportSection
            {
                public HyperbaricOxygenAcceptionReport MyParentReport
                {
                    get { return (HyperbaricOxygenAcceptionReport)ParentReport; }
                }
                
                public TTReportField WORKLISTDATE;
                public TTReportField TREATMENTEQUIPMENTNAME;
                public TTReportField EMERGENCY;
                public TTReportField CURENUMBER;
                public TTReportField PROCEDUREBYUSER;
                public TTReportField ORDEROBJECTPROCEDUREDOCTOR;
                public TTReportField ORDERDETAILPROCEDUREBYUSER; 
                public ORDERDETAILSGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    WORKLISTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 1, 68, 6, false);
                    WORKLISTDATE.Name = "WORKLISTDATE";
                    WORKLISTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKLISTDATE.TextFormat = @"g";
                    WORKLISTDATE.TextFont.Name = "Arial Narrow";
                    WORKLISTDATE.TextFont.Size = 9;
                    WORKLISTDATE.Value = @"{#ORDERS.PRICINGDATE#}";

                    TREATMENTEQUIPMENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 292, 0, 336, 5, false);
                    TREATMENTEQUIPMENTNAME.Name = "TREATMENTEQUIPMENTNAME";
                    TREATMENTEQUIPMENTNAME.Visible = EvetHayirEnum.ehHayir;
                    TREATMENTEQUIPMENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TREATMENTEQUIPMENTNAME.TextFont.Name = "Arial Narrow";
                    TREATMENTEQUIPMENTNAME.TextFont.Size = 9;
                    TREATMENTEQUIPMENTNAME.Value = @" {#ORDERS.TREATMENTEQUIPMENTNAME#}";

                    EMERGENCY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 1, 206, 6, false);
                    EMERGENCY.Name = "EMERGENCY";
                    EMERGENCY.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMERGENCY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EMERGENCY.TextFont.Name = "Arial Narrow";
                    EMERGENCY.TextFont.Size = 9;
                    EMERGENCY.Value = @"{#ORDERS.EMERGENCY#}";

                    CURENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 32, 6, false);
                    CURENUMBER.Name = "CURENUMBER";
                    CURENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CURENUMBER.TextFormat = @"g";
                    CURENUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURENUMBER.TextFont.Name = "Arial Narrow";
                    CURENUMBER.TextFont.Size = 9;
                    CURENUMBER.Value = @"{@groupcounter@}";

                    PROCEDUREBYUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 1, 184, 6, false);
                    PROCEDUREBYUSER.Name = "PROCEDUREBYUSER";
                    PROCEDUREBYUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREBYUSER.TextFormat = @"g";
                    PROCEDUREBYUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROCEDUREBYUSER.TextFont.Name = "Arial Narrow";
                    PROCEDUREBYUSER.TextFont.Size = 9;
                    PROCEDUREBYUSER.Value = @"{#ORDERS.PROCEDUREBYUSER#}";

                    ORDEROBJECTPROCEDUREDOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 0, 291, 5, false);
                    ORDEROBJECTPROCEDUREDOCTOR.Name = "ORDEROBJECTPROCEDUREDOCTOR";
                    ORDEROBJECTPROCEDUREDOCTOR.Visible = EvetHayirEnum.ehHayir;
                    ORDEROBJECTPROCEDUREDOCTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDEROBJECTPROCEDUREDOCTOR.TextFormat = @"g";
                    ORDEROBJECTPROCEDUREDOCTOR.TextFont.Name = "Arial Narrow";
                    ORDEROBJECTPROCEDUREDOCTOR.TextFont.Size = 9;
                    ORDEROBJECTPROCEDUREDOCTOR.Value = @"{#ORDERS.ORDEROBJECTPROCEDUREDOCTOR#}";

                    ORDERDETAILPROCEDUREBYUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 5, 291, 10, false);
                    ORDERDETAILPROCEDUREBYUSER.Name = "ORDERDETAILPROCEDUREBYUSER";
                    ORDERDETAILPROCEDUREBYUSER.Visible = EvetHayirEnum.ehHayir;
                    ORDERDETAILPROCEDUREBYUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERDETAILPROCEDUREBYUSER.TextFormat = @"g";
                    ORDERDETAILPROCEDUREBYUSER.TextFont.Name = "Arial Narrow";
                    ORDERDETAILPROCEDUREBYUSER.TextFont.Size = 9;
                    ORDERDETAILPROCEDUREBYUSER.Value = @"{#ORDERS.PROCEDUREBYUSER#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HyperbarikOxygenTreatmentOrderDetail.GetHyperbaricOrderDetails_Class dataset_GetHyperbaricOrderDetails = MyParentReport.ORDERS.rsGroup.GetCurrentRecord<HyperbarikOxygenTreatmentOrderDetail.GetHyperbaricOrderDetails_Class>(0);
                    WORKLISTDATE.CalcValue = (dataset_GetHyperbaricOrderDetails != null ? Globals.ToStringCore(dataset_GetHyperbaricOrderDetails.PricingDate) : "");
                    TREATMENTEQUIPMENTNAME.CalcValue = @" " + (dataset_GetHyperbaricOrderDetails != null ? Globals.ToStringCore(dataset_GetHyperbaricOrderDetails.Treatmentequipmentname) : "");
                    EMERGENCY.CalcValue = (dataset_GetHyperbaricOrderDetails != null ? Globals.ToStringCore(dataset_GetHyperbaricOrderDetails.Emergency) : "");
                    CURENUMBER.CalcValue = ParentGroup.GroupCounter.ToString();
                    PROCEDUREBYUSER.CalcValue = (dataset_GetHyperbaricOrderDetails != null ? Globals.ToStringCore(dataset_GetHyperbaricOrderDetails.Procedurebyuser) : "");
                    ORDEROBJECTPROCEDUREDOCTOR.CalcValue = (dataset_GetHyperbaricOrderDetails != null ? Globals.ToStringCore(dataset_GetHyperbaricOrderDetails.Orderobjectproceduredoctor) : "");
                    ORDERDETAILPROCEDUREBYUSER.CalcValue = (dataset_GetHyperbaricOrderDetails != null ? Globals.ToStringCore(dataset_GetHyperbaricOrderDetails.Procedurebyuser) : "");
                    return new TTReportObject[] { WORKLISTDATE,TREATMENTEQUIPMENTNAME,EMERGENCY,CURENUMBER,PROCEDUREBYUSER,ORDEROBJECTPROCEDUREDOCTOR,ORDERDETAILPROCEDUREBYUSER};
                }

                public override void RunScript()
                {
#region ORDERDETAILS BODY_Script
                    if (this.EMERGENCY.CalcValue == "False")
                this.EMERGENCY.CalcValue = "Normal";
            else if (this.EMERGENCY.CalcValue == "True")
                this.EMERGENCY.CalcValue = "Acil";
            else
                this.EMERGENCY.CalcValue = "Normal";
                
            if (this.ORDERDETAILPROCEDUREBYUSER.CalcValue == "")
                this.PROCEDUREBYUSER.CalcValue = this.ORDEROBJECTPROCEDUREDOCTOR.CalcValue;
            else
                this.PROCEDUREBYUSER.CalcValue = this.ORDERDETAILPROCEDUREBYUSER.CalcValue;
#endregion ORDERDETAILS BODY_Script
                }
            }

        }

        public ORDERDETAILSGroup ORDERDETAILS;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HyperbaricOxygenAcceptionReport()
        {
            MASTER = new MASTERGroup(this,"MASTER");
            ARA = new ARAGroup(MASTER,"ARA");
            MAIN = new MAINGroup(ARA,"MAIN");
            ORDERS = new ORDERSGroup(MASTER,"ORDERS");
            ORDERDETAILS = new ORDERDETAILSGroup(ORDERS,"ORDERDETAILS");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Hiperbarik Oksijen Tedavisi İstek", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HYPERBARICOXYGENACCEPTIONREPORT";
            Caption = "Hiperbarik Oksijen Tedavisi İstek Raporu";
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