
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
    /// FTR Tedavi Kartı
    /// </summary>
    public partial class PhysiotheraphyTreatmentCard : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("29035332-1b23-4773-8ed6-5e2be3f51570");
        }

        public partial class MASTERGroup : TTReportGroup
        {
            public PhysiotheraphyTreatmentCard MyParentReport
            {
                get { return (PhysiotheraphyTreatmentCard)ParentReport; }
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
            public TTReportField DTARIH { get {return Header().DTARIH;} }
            public TTReportField DYER { get {return Header().DYER;} }
            public TTReportField NOT { get {return Header().NOT;} }
            public TTReportField SubTypeExplanat { get {return Header().SubTypeExplanat;} }
            public TTReportField NewField20 { get {return Header().NewField20;} }
            public TTReportField PHYSIOTHERAPYREQUESTOBJECTID { get {return Header().PHYSIOTHERAPYREQUESTOBJECTID;} }
            public TTReportField AYAKTANYATAN { get {return Header().AYAKTANYATAN;} }
            public TTReportField EPISODEID { get {return Header().EPISODEID;} }
            public TTReportField LOGO1 { get {return Header().LOGO1;} }
            public TTReportField REPORTHEADER1 { get {return Header().REPORTHEADER1;} }
            public TTReportField NewField128 { get {return Header().NewField128;} }
            public TTReportField EPISODEOBJECTID { get {return Header().EPISODEOBJECTID;} }
            public TTReportField AYAKYATANCODED { get {return Header().AYAKYATANCODED;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField PROTOKOLNO { get {return Header().PROTOKOLNO;} }
            public TTReportField SEX { get {return Header().SEX;} }
            public TTReportField AGE { get {return Header().AGE;} }
            public TTReportField ODAYATAK { get {return Header().ODAYATAK;} }
            public TTReportField AGE11 { get {return Header().AGE11;} }
            public TTReportField AGE111 { get {return Header().AGE111;} }
            public TTReportField AGE1111 { get {return Header().AGE1111;} }
            public TTReportField ADSOYAD11 { get {return Header().ADSOYAD11;} }
            public TTReportField LBLODAYATAK { get {return Header().LBLODAYATAK;} }
            public TTReportField DUZENLENMETRH { get {return Header().DUZENLENMETRH;} }
            public TTReportField LBLDUZENLENMETRH { get {return Header().LBLDUZENLENMETRH;} }
            public TTReportField BASLANGICTRH { get {return Header().BASLANGICTRH;} }
            public TTReportField LBLBASLANGICTRH { get {return Header().LBLBASLANGICTRH;} }
            public TTReportField REQUESTMASRES { get {return Header().REQUESTMASRES;} }
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
                list[0] = new TTReportNqlData<PhysiotherapyOrder.PhysiotherapyAcceptionReportNQL_Class>("PhysiotherapyAcceptionReportNQL", PhysiotherapyOrder.PhysiotherapyAcceptionReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public PhysiotheraphyTreatmentCard MyParentReport
                {
                    get { return (PhysiotheraphyTreatmentCard)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField DTARIH;
                public TTReportField DYER;
                public TTReportField NOT;
                public TTReportField SubTypeExplanat;
                public TTReportField NewField20;
                public TTReportField PHYSIOTHERAPYREQUESTOBJECTID;
                public TTReportField AYAKTANYATAN;
                public TTReportField EPISODEID;
                public TTReportField LOGO1;
                public TTReportField REPORTHEADER1;
                public TTReportField NewField128;
                public TTReportField EPISODEOBJECTID;
                public TTReportField AYAKYATANCODED;
                public TTReportField ADSOYAD;
                public TTReportField PROTOKOLNO;
                public TTReportField SEX;
                public TTReportField AGE;
                public TTReportField ODAYATAK;
                public TTReportField AGE11;
                public TTReportField AGE111;
                public TTReportField AGE1111;
                public TTReportField ADSOYAD11;
                public TTReportField LBLODAYATAK;
                public TTReportField DUZENLENMETRH;
                public TTReportField LBLDUZENLENMETRH;
                public TTReportField BASLANGICTRH;
                public TTReportField LBLBASLANGICTRH;
                public TTReportField REQUESTMASRES; 
                public MASTERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 60;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 10, 271, 30, false);
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

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 314, 66, 350, 71, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"Short Date";
                    DTARIH.TextFont.Name = "Arial Narrow";
                    DTARIH.TextFont.Size = 9;
                    DTARIH.Value = @"{#BIRTHDATE#}";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 314, 71, 350, 76, false);
                    DYER.Name = "DYER";
                    DYER.Visible = EvetHayirEnum.ehHayir;
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.TextFont.Name = "Arial Narrow";
                    DYER.TextFont.Size = 9;
                    DYER.Value = @"{#CITYNAME#}";

                    NOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 336, 147, 481, 158, false);
                    NOT.Name = "NOT";
                    NOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOT.MultiLine = EvetHayirEnum.ehEvet;
                    NOT.NoClip = EvetHayirEnum.ehEvet;
                    NOT.WordBreak = EvetHayirEnum.ehEvet;
                    NOT.ExpandTabs = EvetHayirEnum.ehEvet;
                    NOT.TextFont.Name = "Arial Narrow";
                    NOT.TextFont.Size = 9;
                    NOT.Value = @"{#NOTETOPHYSIOTHERAPIST#}";

                    SubTypeExplanat = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 53, 102, 58, false);
                    SubTypeExplanat.Name = "SubTypeExplanat";
                    SubTypeExplanat.DrawStyle = DrawStyleConstants.vbSolid;
                    SubTypeExplanat.TextFont.Name = "Arial Narrow";
                    SubTypeExplanat.TextFont.Size = 9;
                    SubTypeExplanat.TextFont.Bold = true;
                    SubTypeExplanat.Value = @"Tedavinin Planlandığı Poliklinik";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 285, 147, 333, 152, false);
                    NewField20.Name = "NewField20";
                    NewField20.TextFont.Name = "Arial Narrow";
                    NewField20.TextFont.Size = 9;
                    NewField20.TextFont.Bold = true;
                    NewField20.Value = @"Fizyoterapiste Not";

                    PHYSIOTHERAPYREQUESTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 314, 61, 350, 66, false);
                    PHYSIOTHERAPYREQUESTOBJECTID.Name = "PHYSIOTHERAPYREQUESTOBJECTID";
                    PHYSIOTHERAPYREQUESTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    PHYSIOTHERAPYREQUESTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PHYSIOTHERAPYREQUESTOBJECTID.TextFont.Name = "Arial Narrow";
                    PHYSIOTHERAPYREQUESTOBJECTID.TextFont.Size = 9;
                    PHYSIOTHERAPYREQUESTOBJECTID.Value = @"{#PHYSIOTHERAPYREQUESTOBJECTID#}";

                    AYAKTANYATAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 346, 100, 464, 104, false);
                    AYAKTANYATAN.Name = "AYAKTANYATAN";
                    AYAKTANYATAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    AYAKTANYATAN.CaseFormat = CaseFormatEnum.fcUpperCase;
                    AYAKTANYATAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AYAKTANYATAN.TextFont.Name = "Arial Narrow";
                    AYAKTANYATAN.TextFont.Size = 9;
                    AYAKTANYATAN.TextFont.Bold = true;
                    AYAKTANYATAN.Value = @"{%AYAKYATANCODED%} HASTA";

                    EPISODEID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 314, 47, 361, 52, false);
                    EPISODEID.Name = "EPISODEID";
                    EPISODEID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEID.ObjectDefName = "PhysiotherapyOrder";
                    EPISODEID.DataMember = "EPISODE.ID";
                    EPISODEID.TextFont.Name = "Arial Narrow";
                    EPISODEID.TextFont.Size = 9;
                    EPISODEID.Value = @"{@TTOBJECTID@}";

                    LOGO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 50, 30, false);
                    LOGO1.Name = "LOGO1";
                    LOGO1.TextFont.CharSet = 1;
                    LOGO1.Value = @"Logo";

                    REPORTHEADER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 31, 271, 39, false);
                    REPORTHEADER1.Name = "REPORTHEADER1";
                    REPORTHEADER1.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTHEADER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER1.TextFont.Name = "Arial Narrow";
                    REPORTHEADER1.TextFont.Size = 15;
                    REPORTHEADER1.TextFont.Bold = true;
                    REPORTHEADER1.Value = @"FTR TEDAVİ KARTI";

                    NewField128 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 333, 147, 335, 152, false);
                    NewField128.Name = "NewField128";
                    NewField128.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField128.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField128.TextFont.Name = "Arial Narrow";
                    NewField128.TextFont.Size = 9;
                    NewField128.TextFont.Bold = true;
                    NewField128.Value = @":";

                    EPISODEOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 314, 52, 361, 57, false);
                    EPISODEOBJECTID.Name = "EPISODEOBJECTID";
                    EPISODEOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEOBJECTID.TextFont.Name = "Arial Narrow";
                    EPISODEOBJECTID.TextFont.Size = 9;
                    EPISODEOBJECTID.Value = @"{#EPISODEOBJECTID#}";

                    AYAKYATANCODED = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 314, 57, 350, 61, false);
                    AYAKYATANCODED.Name = "AYAKYATANCODED";
                    AYAKYATANCODED.Visible = EvetHayirEnum.ehHayir;
                    AYAKYATANCODED.FieldType = ReportFieldTypeEnum.ftVariable;
                    AYAKYATANCODED.ObjectDefName = "PatientStatusEnum";
                    AYAKYATANCODED.DataMember = "DISPLAYTEXT";
                    AYAKYATANCODED.TextFont.Name = "Arial Narrow";
                    AYAKYATANCODED.TextFont.Size = 9;
                    AYAKYATANCODED.Value = @"{#PATIENTSTATUS#}";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 48, 83, 53, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.DrawStyle = DrawStyleConstants.vbSolid;
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.Name = "Arial Narrow";
                    ADSOYAD.TextFont.Size = 9;
                    ADSOYAD.Value = @"{#NAME#} {#SURNAME#}";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 48, 145, 53, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.DrawStyle = DrawStyleConstants.vbSolid;
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.Name = "Arial Narrow";
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.Value = @"{#PROTOCOLNO#}";

                    SEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 48, 121, 53, false);
                    SEX.Name = "SEX";
                    SEX.DrawStyle = DrawStyleConstants.vbSolid;
                    SEX.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEX.TextFont.Name = "Arial Narrow";
                    SEX.TextFont.Size = 9;
                    SEX.Value = @"";

                    AGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 48, 102, 53, false);
                    AGE.Name = "AGE";
                    AGE.DrawStyle = DrawStyleConstants.vbSolid;
                    AGE.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGE.TextFont.Name = "Arial Narrow";
                    AGE.TextFont.Size = 9;
                    AGE.Value = @"";

                    ODAYATAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 48, 191, 53, false);
                    ODAYATAK.Name = "ODAYATAK";
                    ODAYATAK.DrawStyle = DrawStyleConstants.vbSolid;
                    ODAYATAK.FieldType = ReportFieldTypeEnum.ftVariable;
                    ODAYATAK.TextFont.Name = "Arial Narrow";
                    ODAYATAK.TextFont.Size = 9;
                    ODAYATAK.Value = @"";

                    AGE11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 43, 102, 48, false);
                    AGE11.Name = "AGE11";
                    AGE11.DrawStyle = DrawStyleConstants.vbSolid;
                    AGE11.TextFont.Name = "Arial Narrow";
                    AGE11.TextFont.Size = 9;
                    AGE11.TextFont.Bold = true;
                    AGE11.Value = @"Yaş";

                    AGE111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 43, 121, 48, false);
                    AGE111.Name = "AGE111";
                    AGE111.DrawStyle = DrawStyleConstants.vbSolid;
                    AGE111.TextFont.Name = "Arial Narrow";
                    AGE111.TextFont.Size = 9;
                    AGE111.TextFont.Bold = true;
                    AGE111.Value = @"Cinsiyet";

                    AGE1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 43, 145, 48, false);
                    AGE1111.Name = "AGE1111";
                    AGE1111.DrawStyle = DrawStyleConstants.vbSolid;
                    AGE1111.TextFont.Name = "Arial Narrow";
                    AGE1111.TextFont.Size = 9;
                    AGE1111.TextFont.Bold = true;
                    AGE1111.Value = @"Protokol";

                    ADSOYAD11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 43, 83, 48, false);
                    ADSOYAD11.Name = "ADSOYAD11";
                    ADSOYAD11.DrawStyle = DrawStyleConstants.vbSolid;
                    ADSOYAD11.TextFont.Name = "Arial Narrow";
                    ADSOYAD11.TextFont.Size = 9;
                    ADSOYAD11.TextFont.Bold = true;
                    ADSOYAD11.Value = @"Hastanın Adı Soyadı";

                    LBLODAYATAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 43, 191, 48, false);
                    LBLODAYATAK.Name = "LBLODAYATAK";
                    LBLODAYATAK.DrawStyle = DrawStyleConstants.vbSolid;
                    LBLODAYATAK.FieldType = ReportFieldTypeEnum.ftVariable;
                    LBLODAYATAK.TextFont.Name = "Arial Narrow";
                    LBLODAYATAK.TextFont.Size = 9;
                    LBLODAYATAK.TextFont.Bold = true;
                    LBLODAYATAK.Value = @"";

                    DUZENLENMETRH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 48, 232, 53, false);
                    DUZENLENMETRH.Name = "DUZENLENMETRH";
                    DUZENLENMETRH.DrawStyle = DrawStyleConstants.vbSolid;
                    DUZENLENMETRH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DUZENLENMETRH.TextFormat = @"dd/MM/yyyy HH:mm";
                    DUZENLENMETRH.TextFont.Name = "Arial Narrow";
                    DUZENLENMETRH.TextFont.Size = 9;
                    DUZENLENMETRH.Value = @"";

                    LBLDUZENLENMETRH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 43, 232, 48, false);
                    LBLDUZENLENMETRH.Name = "LBLDUZENLENMETRH";
                    LBLDUZENLENMETRH.DrawStyle = DrawStyleConstants.vbSolid;
                    LBLDUZENLENMETRH.TextFont.Name = "Arial Narrow";
                    LBLDUZENLENMETRH.TextFont.Size = 9;
                    LBLDUZENLENMETRH.TextFont.Bold = true;
                    LBLDUZENLENMETRH.Value = @"Düzenlenme";

                    BASLANGICTRH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 48, 271, 53, false);
                    BASLANGICTRH.Name = "BASLANGICTRH";
                    BASLANGICTRH.DrawStyle = DrawStyleConstants.vbSolid;
                    BASLANGICTRH.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASLANGICTRH.TextFormat = @"dd/MM/yy";
                    BASLANGICTRH.TextFont.Name = "Arial Narrow";
                    BASLANGICTRH.TextFont.Size = 9;
                    BASLANGICTRH.Value = @"";

                    LBLBASLANGICTRH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 43, 271, 48, false);
                    LBLBASLANGICTRH.Name = "LBLBASLANGICTRH";
                    LBLBASLANGICTRH.DrawStyle = DrawStyleConstants.vbSolid;
                    LBLBASLANGICTRH.TextFont.Name = "Arial Narrow";
                    LBLBASLANGICTRH.TextFont.Size = 9;
                    LBLBASLANGICTRH.TextFont.Bold = true;
                    LBLBASLANGICTRH.Value = @"Başlangıç Tarihi";

                    REQUESTMASRES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 53, 271, 58, false);
                    REQUESTMASRES.Name = "REQUESTMASRES";
                    REQUESTMASRES.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUESTMASRES.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTMASRES.TextFont.Name = "Arial Narrow";
                    REQUESTMASRES.TextFont.Size = 9;
                    REQUESTMASRES.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PhysiotherapyOrder.PhysiotherapyAcceptionReportNQL_Class dataset_PhysiotherapyAcceptionReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PhysiotherapyOrder.PhysiotherapyAcceptionReportNQL_Class>(0);
                    DTARIH.CalcValue = (dataset_PhysiotherapyAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PhysiotherapyAcceptionReportNQL.BirthDate) : "");
                    DYER.CalcValue = (dataset_PhysiotherapyAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PhysiotherapyAcceptionReportNQL.Cityname) : "");
                    NOT.CalcValue = (dataset_PhysiotherapyAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PhysiotherapyAcceptionReportNQL.NoteToPhysiotherapist) : "");
                    SubTypeExplanat.CalcValue = SubTypeExplanat.Value;
                    NewField20.CalcValue = NewField20.Value;
                    PHYSIOTHERAPYREQUESTOBJECTID.CalcValue = (dataset_PhysiotherapyAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PhysiotherapyAcceptionReportNQL.Physiotherapyrequestobjectid) : "");
                    AYAKYATANCODED.CalcValue = (dataset_PhysiotherapyAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PhysiotherapyAcceptionReportNQL.PatientStatus) : "");
                    AYAKYATANCODED.PostFieldValueCalculation();
                    AYAKTANYATAN.CalcValue = MyParentReport.MASTER.AYAKYATANCODED.CalcValue + @" HASTA";
                    EPISODEID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    EPISODEID.PostFieldValueCalculation();
                    LOGO1.CalcValue = LOGO1.Value;
                    REPORTHEADER1.CalcValue = REPORTHEADER1.Value;
                    NewField128.CalcValue = NewField128.Value;
                    EPISODEOBJECTID.CalcValue = (dataset_PhysiotherapyAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PhysiotherapyAcceptionReportNQL.Episodeobjectid) : "");
                    ADSOYAD.CalcValue = (dataset_PhysiotherapyAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PhysiotherapyAcceptionReportNQL.Name) : "") + @" " + (dataset_PhysiotherapyAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PhysiotherapyAcceptionReportNQL.Surname) : "");
                    PROTOKOLNO.CalcValue = (dataset_PhysiotherapyAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PhysiotherapyAcceptionReportNQL.ProtocolNo) : "");
                    SEX.CalcValue = @"";
                    AGE.CalcValue = @"";
                    ODAYATAK.CalcValue = @"";
                    AGE11.CalcValue = AGE11.Value;
                    AGE111.CalcValue = AGE111.Value;
                    AGE1111.CalcValue = AGE1111.Value;
                    ADSOYAD11.CalcValue = ADSOYAD11.Value;
                    LBLODAYATAK.CalcValue = @"";
                    DUZENLENMETRH.CalcValue = @"";
                    LBLDUZENLENMETRH.CalcValue = LBLDUZENLENMETRH.Value;
                    BASLANGICTRH.CalcValue = @"";
                    LBLBASLANGICTRH.CalcValue = LBLBASLANGICTRH.Value;
                    REQUESTMASRES.CalcValue = @"";
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { DTARIH,DYER,NOT,SubTypeExplanat,NewField20,PHYSIOTHERAPYREQUESTOBJECTID,AYAKYATANCODED,AYAKTANYATAN,EPISODEID,LOGO1,REPORTHEADER1,NewField128,EPISODEOBJECTID,ADSOYAD,PROTOKOLNO,SEX,AGE,ODAYATAK,AGE11,AGE111,AGE1111,ADSOYAD11,LBLODAYATAK,DUZENLENMETRH,LBLDUZENLENMETRH,BASLANGICTRH,LBLBASLANGICTRH,REQUESTMASRES,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region MASTER HEADER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((PhysiotheraphyDetailReportByAcception)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PhysiotherapyOrder physiotherapyOrder = (PhysiotherapyOrder)objectContext.GetObject(new Guid(objectID),"PhysiotherapyOrder");
            
//            if (physiotherapyOrder.Episode.Patient.Foreign == true)
//            {
//                this.UNIQUEREFNO.CalcValue = physiotherapyOrder.Episode.Patient.ForeignUniqueRefNo.ToString();
//                this.LBLUNIQUEREFNO.CalcValue = "Kimlik/Sigorta No (Yabancı Hasta)";
//            }
//            else
//            {
//                this.UNIQUEREFNO.CalcValue = physiotherapyOrder.Episode.Patient.UniqueRefNo.ToString();
//                this.LBLUNIQUEREFNO.CalcValue = "T.C. Kimlik No";
//            }
#endregion MASTER HEADER_Script
                }
            }
            public partial class MASTERGroupFooter : TTReportSection
            {
                public PhysiotheraphyTreatmentCard MyParentReport
                {
                    get { return (PhysiotheraphyTreatmentCard)ParentReport; }
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
                    FOOTER.Value = @"""Randevu tarihinde gelemeyecek iseniz bizi bilgilendiriniz. Tel :"" + TTObjectClasses.SystemParameter.GetParameterValue(""FTRTELNO"", """")";

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
                    PhysiotherapyOrder.PhysiotherapyAcceptionReportNQL_Class dataset_PhysiotherapyAcceptionReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PhysiotherapyOrder.PhysiotherapyAcceptionReportNQL_Class>(0);
                    NewField0.CalcValue = NewField0.Value;
                    NewField9.CalcValue = NewField9.Value;
                    DIPSIC.CalcValue = @"";
                    ADSOYADDOC.CalcValue = (dataset_PhysiotherapyAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PhysiotherapyAcceptionReportNQL.Proceduredoctorname) : "");
                    UZMANLIKDAL.CalcValue = (dataset_PhysiotherapyAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PhysiotherapyAcceptionReportNQL.Docspeciality) : "");
                    DIPSICLABEL.CalcValue = @"DIPLOMASICIL";
                    SINRUT.CalcValue = @"";
                    RUTBEONAY.CalcValue = (dataset_PhysiotherapyAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PhysiotherapyAcceptionReportNQL.Dokrank) : "");
                    SINIFONAY.CalcValue = (dataset_PhysiotherapyAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PhysiotherapyAcceptionReportNQL.Docmilitaryclass) : "");
                    UZ.CalcValue = MyParentReport.MASTER.UZMANLIKDAL.CalcValue;
                    GOREV.CalcValue = (dataset_PhysiotherapyAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PhysiotherapyAcceptionReportNQL.Docwork) : "");
                    DIPLOMANO.CalcValue = (dataset_PhysiotherapyAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PhysiotherapyAcceptionReportNQL.Docdiplomano) : "");
                    UNVAN.CalcValue = (dataset_PhysiotherapyAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PhysiotherapyAcceptionReportNQL.Doctitle) : "");
                    SICILNO.CalcValue = (dataset_PhysiotherapyAcceptionReportNQL != null ? Globals.ToStringCore(dataset_PhysiotherapyAcceptionReportNQL.Docemploymentrecordid) : "");
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    FOOTER.CalcValue = "Randevu tarihinde gelemeyecek iseniz bizi bilgilendiriniz. Tel :" + TTObjectClasses.SystemParameter.GetParameterValue("FTRTELNO", "");
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
            public PhysiotheraphyTreatmentCard MyParentReport
            {
                get { return (PhysiotheraphyTreatmentCard)ParentReport; }
            }

            new public ARAGroupHeader Header()
            {
                return (ARAGroupHeader)_header;
            }

            new public ARAGroupFooter Footer()
            {
                return (ARAGroupFooter)_footer;
            }

            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField NewField111411 { get {return Header().NewField111411;} }
            public TTReportField NewField111412 { get {return Header().NewField111412;} }
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
                public PhysiotheraphyTreatmentCard MyParentReport
                {
                    get { return (PhysiotheraphyTreatmentCard)ParentReport; }
                }
                
                public TTReportField NewField11411;
                public TTReportField NewField111411;
                public TTReportField NewField111412; 
                public ARAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 55, 6, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11411.TextFont.Name = "Arial Narrow";
                    NewField11411.TextFont.Size = 9;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.Value = @"Tanı Tarihi";

                    NewField111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 1, 232, 6, false);
                    NewField111411.Name = "NewField111411";
                    NewField111411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111411.TextFont.Name = "Arial Narrow";
                    NewField111411.TextFont.Size = 9;
                    NewField111411.TextFont.Bold = true;
                    NewField111411.Value = @"Tanı";

                    NewField111412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 1, 271, 6, false);
                    NewField111412.Name = "NewField111412";
                    NewField111412.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111412.TextFont.Name = "Arial Narrow";
                    NewField111412.TextFont.Size = 9;
                    NewField111412.TextFont.Bold = true;
                    NewField111412.Value = @"Tanı Tipi
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField111411.CalcValue = NewField111411.Value;
                    NewField111412.CalcValue = NewField111412.Value;
                    return new TTReportObject[] { NewField11411,NewField111411,NewField111412};
                }
            }
            public partial class ARAGroupFooter : TTReportSection
            {
                public PhysiotheraphyTreatmentCard MyParentReport
                {
                    get { return (PhysiotheraphyTreatmentCard)ParentReport; }
                }
                 
                public ARAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public ARAGroup ARA;

        public partial class MAINGroup : TTReportGroup
        {
            public PhysiotheraphyTreatmentCard MyParentReport
            {
                get { return (PhysiotheraphyTreatmentCard)ParentReport; }
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
                public PhysiotheraphyTreatmentCard MyParentReport
                {
                    get { return (PhysiotheraphyTreatmentCard)ParentReport; }
                }
                
                public TTReportField DIAGNOSISCODENAME;
                public TTReportField DIAGNOSISDATE;
                public TTReportField DIAGNOSISTYPE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    DIAGNOSISCODENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 0, 232, 5, false);
                    DIAGNOSISCODENAME.Name = "DIAGNOSISCODENAME";
                    DIAGNOSISCODENAME.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISCODENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISCODENAME.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISCODENAME.NoClip = EvetHayirEnum.ehEvet;
                    DIAGNOSISCODENAME.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISCODENAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISCODENAME.TextFont.Name = "Arial Narrow";
                    DIAGNOSISCODENAME.TextFont.Size = 9;
                    DIAGNOSISCODENAME.Value = @"{#CODE#} {#NAME#}";

                    DIAGNOSISDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 55, 5, false);
                    DIAGNOSISDATE.Name = "DIAGNOSISDATE";
                    DIAGNOSISDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    DIAGNOSISDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSISDATE.TextFormat = @"g";
                    DIAGNOSISDATE.TextFont.Name = "Arial Narrow";
                    DIAGNOSISDATE.TextFont.Size = 9;
                    DIAGNOSISDATE.Value = @"{#DIAGNOSEDATE#}";

                    DIAGNOSISTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 0, 271, 5, false);
                    DIAGNOSISTYPE.Name = "DIAGNOSISTYPE";
                    DIAGNOSISTYPE.DrawStyle = DrawStyleConstants.vbSolid;
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
            public PhysiotheraphyTreatmentCard MyParentReport
            {
                get { return (PhysiotheraphyTreatmentCard)ParentReport; }
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
            public TTReportField NewField11114111 { get {return Header().NewField11114111;} }
            public TTReportField NewField111141111 { get {return Header().NewField111141111;} }
            public TTReportField NewField112141111 { get {return Header().NewField112141111;} }
            public TTReportField NewField1111141211 { get {return Header().NewField1111141211;} }
            public TTReportField TREATMENTDIAGNOSISUNITNAME { get {return Header().TREATMENTDIAGNOSISUNITNAME;} }
            public TTReportField NewField1111141111 { get {return Header().NewField1111141111;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField20 { get {return Header().NewField20;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField NewField23 { get {return Header().NewField23;} }
            public TTReportField NewField24 { get {return Header().NewField24;} }
            public TTReportField NewField25 { get {return Header().NewField25;} }
            public TTReportField NewField26 { get {return Header().NewField26;} }
            public TTReportField NewField27 { get {return Header().NewField27;} }
            public TTReportField NewField28 { get {return Header().NewField28;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField NewField102 { get {return Header().NewField102;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField123 { get {return Header().NewField123;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField NewField152 { get {return Header().NewField152;} }
            public TTReportField NewField162 { get {return Header().NewField162;} }
            public TTReportField NewField172 { get {return Header().NewField172;} }
            public TTReportField NewField29 { get {return Header().NewField29;} }
            public TTReportField NewField113 { get {return Header().NewField113;} }
            public TTReportField NewField124 { get {return Header().NewField124;} }
            public TTReportField NewField163 { get {return Header().NewField163;} }
            public TTReportField NewField173 { get {return Header().NewField173;} }
            public TTReportField NewField182 { get {return Header().NewField182;} }
            public TTReportField NewField192 { get {return Header().NewField192;} }
            public TTReportField NewField103 { get {return Header().NewField103;} }
            public TTReportField NewField114 { get {return Header().NewField114;} }
            public TTReportField NewField125 { get {return Header().NewField125;} }
            public TTReportField NewField133 { get {return Header().NewField133;} }
            public TTReportField NewField143 { get {return Header().NewField143;} }
            public TTReportField NewField153 { get {return Header().NewField153;} }
            public TTReportField NewField164 { get {return Header().NewField164;} }
            public TTReportField NewField174 { get {return Header().NewField174;} }
            public TTReportField NewField183 { get {return Header().NewField183;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField NewField1171 { get {return Header().NewField1171;} }
            public TTReportField NewField1181 { get {return Header().NewField1181;} }
            public TTReportField NewField1191 { get {return Header().NewField1191;} }
            public TTReportField NewField1201 { get {return Header().NewField1201;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField NewField1321 { get {return Header().NewField1321;} }
            public TTReportField NewField1231 { get {return Header().NewField1231;} }
            public TTReportField NewField1241 { get {return Header().NewField1241;} }
            public TTReportField NewField1251 { get {return Header().NewField1251;} }
            public TTReportField NewField1261 { get {return Header().NewField1261;} }
            public TTReportField NewField1271 { get {return Header().NewField1271;} }
            public TTReportField HIKAYE { get {return Header().HIKAYE;} }
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
                list[0] = new TTReportNqlData<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetails_Class>("GetPhysiotherapyOrderDetails", PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetails((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.MASTER.PHYSIOTHERAPYREQUESTOBJECTID.CalcValue)));
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
                public PhysiotheraphyTreatmentCard MyParentReport
                {
                    get { return (PhysiotheraphyTreatmentCard)ParentReport; }
                }
                
                public TTReportField ORDEROBJECTOBJECTID;
                public TTReportField NewField11114111;
                public TTReportField NewField111141111;
                public TTReportField NewField112141111;
                public TTReportField NewField1111141211;
                public TTReportField TREATMENTDIAGNOSISUNITNAME;
                public TTReportField NewField1111141111;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField NewField20;
                public TTReportField NewField21;
                public TTReportField NewField22;
                public TTReportField NewField23;
                public TTReportField NewField24;
                public TTReportField NewField25;
                public TTReportField NewField26;
                public TTReportField NewField27;
                public TTReportField NewField28;
                public TTReportField NewField111;
                public TTReportField NewField122;
                public TTReportField NewField161;
                public TTReportField NewField171;
                public TTReportField NewField181;
                public TTReportField NewField191;
                public TTReportField NewField102;
                public TTReportField NewField112;
                public TTReportField NewField123;
                public TTReportField NewField132;
                public TTReportField NewField142;
                public TTReportField NewField152;
                public TTReportField NewField162;
                public TTReportField NewField172;
                public TTReportField NewField29;
                public TTReportField NewField113;
                public TTReportField NewField124;
                public TTReportField NewField163;
                public TTReportField NewField173;
                public TTReportField NewField182;
                public TTReportField NewField192;
                public TTReportField NewField103;
                public TTReportField NewField114;
                public TTReportField NewField125;
                public TTReportField NewField133;
                public TTReportField NewField143;
                public TTReportField NewField153;
                public TTReportField NewField164;
                public TTReportField NewField174;
                public TTReportField NewField183;
                public TTReportField NewField1111;
                public TTReportField NewField1221;
                public TTReportField NewField1161;
                public TTReportField NewField1171;
                public TTReportField NewField1181;
                public TTReportField NewField1191;
                public TTReportField NewField1201;
                public TTReportField NewField1211;
                public TTReportField NewField1321;
                public TTReportField NewField1231;
                public TTReportField NewField1241;
                public TTReportField NewField1251;
                public TTReportField NewField1261;
                public TTReportField NewField1271;
                public TTReportField HIKAYE; 
                public ORDERSGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 30;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ORDEROBJECTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 283, 6, 327, 11, false);
                    ORDEROBJECTOBJECTID.Name = "ORDEROBJECTOBJECTID";
                    ORDEROBJECTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    ORDEROBJECTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDEROBJECTOBJECTID.MultiLine = EvetHayirEnum.ehEvet;
                    ORDEROBJECTOBJECTID.WordBreak = EvetHayirEnum.ehEvet;
                    ORDEROBJECTOBJECTID.TextFont.Name = "Arial Narrow";
                    ORDEROBJECTOBJECTID.TextFont.Size = 9;
                    ORDEROBJECTOBJECTID.Value = @"{#ORDEROBJECTOBJECTID#}";

                    NewField11114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 25, 48, 30, false);
                    NewField11114111.Name = "NewField11114111";
                    NewField11114111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11114111.TextFont.Name = "Arial Narrow";
                    NewField11114111.TextFont.Size = 9;
                    NewField11114111.TextFont.Bold = true;
                    NewField11114111.Value = @"İstenen Tetkik";

                    NewField111141111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 25, 90, 30, false);
                    NewField111141111.Name = "NewField111141111";
                    NewField111141111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111141111.TextFont.Name = "Arial Narrow";
                    NewField111141111.TextFont.Size = 9;
                    NewField111141111.TextFont.Bold = true;
                    NewField111141111.Value = @"Uygulama Alanı";

                    NewField112141111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 25, 60, 30, false);
                    NewField112141111.Name = "NewField112141111";
                    NewField112141111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112141111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112141111.TextFont.Name = "Arial Narrow";
                    NewField112141111.TextFont.Size = 9;
                    NewField112141111.TextFont.Bold = true;
                    NewField112141111.Value = @"Süre/dk";

                    NewField1111141211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 25, 69, 30, false);
                    NewField1111141211.Name = "NewField1111141211";
                    NewField1111141211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111141211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111141211.TextFont.Name = "Arial Narrow";
                    NewField1111141211.TextFont.Size = 9;
                    NewField1111141211.TextFont.Bold = true;
                    NewField1111141211.Value = @"Kür";

                    TREATMENTDIAGNOSISUNITNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 271, 6, false);
                    TREATMENTDIAGNOSISUNITNAME.Name = "TREATMENTDIAGNOSISUNITNAME";
                    TREATMENTDIAGNOSISUNITNAME.FillColor = System.Drawing.Color.Silver;
                    TREATMENTDIAGNOSISUNITNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    TREATMENTDIAGNOSISUNITNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TREATMENTDIAGNOSISUNITNAME.MultiLine = EvetHayirEnum.ehEvet;
                    TREATMENTDIAGNOSISUNITNAME.WordBreak = EvetHayirEnum.ehEvet;
                    TREATMENTDIAGNOSISUNITNAME.TextFont.Name = "Arial Narrow";
                    TREATMENTDIAGNOSISUNITNAME.TextFont.Bold = true;
                    TREATMENTDIAGNOSISUNITNAME.Value = @"{#TREATMENTDIAGNOSISUNITNAME#}";

                    NewField1111141111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 6, 90, 25, false);
                    NewField1111141111.Name = "NewField1111141111";
                    NewField1111141111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111141111.TextFont.Name = "Arial Narrow";
                    NewField1111141111.TextFont.Size = 9;
                    NewField1111141111.TextFont.Bold = true;
                    NewField1111141111.Value = @"Tarih";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 6, 98, 25, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.CharSet = 1;
                    NewField1.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 6, 104, 25, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.TextFont.Name = "Arial Narrow";
                    NewField11.TextFont.CharSet = 1;
                    NewField11.Value = @"";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 6, 110, 25, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.TextFont.Name = "Arial Narrow";
                    NewField12.TextFont.CharSet = 1;
                    NewField12.Value = @"";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 6, 116, 25, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.TextFont.Name = "Arial Narrow";
                    NewField16.TextFont.CharSet = 1;
                    NewField16.Value = @"";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 6, 122, 25, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.TextFont.Name = "Arial Narrow";
                    NewField17.TextFont.CharSet = 1;
                    NewField17.Value = @"";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 6, 128, 25, false);
                    NewField18.Name = "NewField18";
                    NewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18.TextFont.Name = "Arial Narrow";
                    NewField18.TextFont.CharSet = 1;
                    NewField18.Value = @"";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 6, 134, 25, false);
                    NewField19.Name = "NewField19";
                    NewField19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField19.TextFont.Name = "Arial Narrow";
                    NewField19.TextFont.CharSet = 1;
                    NewField19.Value = @"";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 6, 140, 25, false);
                    NewField20.Name = "NewField20";
                    NewField20.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField20.TextFont.Name = "Arial Narrow";
                    NewField20.TextFont.CharSet = 1;
                    NewField20.Value = @"";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 6, 146, 25, false);
                    NewField21.Name = "NewField21";
                    NewField21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField21.TextFont.Name = "Arial Narrow";
                    NewField21.TextFont.CharSet = 1;
                    NewField21.Value = @"";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 6, 152, 25, false);
                    NewField22.Name = "NewField22";
                    NewField22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField22.TextFont.Name = "Arial Narrow";
                    NewField22.TextFont.CharSet = 1;
                    NewField22.Value = @"";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 6, 158, 25, false);
                    NewField23.Name = "NewField23";
                    NewField23.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField23.TextFont.Name = "Arial Narrow";
                    NewField23.TextFont.CharSet = 1;
                    NewField23.Value = @"";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 6, 164, 25, false);
                    NewField24.Name = "NewField24";
                    NewField24.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField24.TextFont.Name = "Arial Narrow";
                    NewField24.TextFont.CharSet = 1;
                    NewField24.Value = @"";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 6, 170, 25, false);
                    NewField25.Name = "NewField25";
                    NewField25.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField25.TextFont.Name = "Arial Narrow";
                    NewField25.TextFont.CharSet = 1;
                    NewField25.Value = @"";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 6, 176, 25, false);
                    NewField26.Name = "NewField26";
                    NewField26.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField26.TextFont.Name = "Arial Narrow";
                    NewField26.TextFont.CharSet = 1;
                    NewField26.Value = @"";

                    NewField27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 6, 182, 25, false);
                    NewField27.Name = "NewField27";
                    NewField27.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField27.TextFont.Name = "Arial Narrow";
                    NewField27.TextFont.CharSet = 1;
                    NewField27.Value = @"";

                    NewField28 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 6, 188, 25, false);
                    NewField28.Name = "NewField28";
                    NewField28.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField28.TextFont.Name = "Arial Narrow";
                    NewField28.TextFont.CharSet = 1;
                    NewField28.Value = @"";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 6, 194, 25, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.TextFont.Name = "Arial Narrow";
                    NewField111.TextFont.CharSet = 1;
                    NewField111.Value = @"";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 6, 200, 25, false);
                    NewField122.Name = "NewField122";
                    NewField122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122.TextFont.Name = "Arial Narrow";
                    NewField122.TextFont.CharSet = 1;
                    NewField122.Value = @"";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 198, 6, 206, 25, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.TextFont.Name = "Arial Narrow";
                    NewField161.TextFont.CharSet = 1;
                    NewField161.Value = @"";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 6, 212, 25, false);
                    NewField171.Name = "NewField171";
                    NewField171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField171.TextFont.Name = "Arial Narrow";
                    NewField171.TextFont.CharSet = 1;
                    NewField171.Value = @"";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 6, 218, 25, false);
                    NewField181.Name = "NewField181";
                    NewField181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField181.TextFont.Name = "Arial Narrow";
                    NewField181.TextFont.CharSet = 1;
                    NewField181.Value = @"";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 6, 224, 25, false);
                    NewField191.Name = "NewField191";
                    NewField191.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField191.TextFont.Name = "Arial Narrow";
                    NewField191.TextFont.CharSet = 1;
                    NewField191.Value = @"";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 6, 230, 25, false);
                    NewField102.Name = "NewField102";
                    NewField102.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField102.TextFont.Name = "Arial Narrow";
                    NewField102.TextFont.CharSet = 1;
                    NewField102.Value = @"";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 6, 236, 25, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.TextFont.Name = "Arial Narrow";
                    NewField112.TextFont.CharSet = 1;
                    NewField112.Value = @"";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 6, 242, 25, false);
                    NewField123.Name = "NewField123";
                    NewField123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField123.TextFont.Name = "Arial Narrow";
                    NewField123.TextFont.CharSet = 1;
                    NewField123.Value = @"";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 6, 248, 25, false);
                    NewField132.Name = "NewField132";
                    NewField132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField132.TextFont.Name = "Arial Narrow";
                    NewField132.TextFont.CharSet = 1;
                    NewField132.Value = @"";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 6, 254, 25, false);
                    NewField142.Name = "NewField142";
                    NewField142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField142.TextFont.Name = "Arial Narrow";
                    NewField142.TextFont.CharSet = 1;
                    NewField142.Value = @"";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 252, 6, 260, 25, false);
                    NewField152.Name = "NewField152";
                    NewField152.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField152.TextFont.Name = "Arial Narrow";
                    NewField152.TextFont.CharSet = 1;
                    NewField152.Value = @"";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 6, 266, 25, false);
                    NewField162.Name = "NewField162";
                    NewField162.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField162.TextFont.Name = "Arial Narrow";
                    NewField162.TextFont.CharSet = 1;
                    NewField162.Value = @"";

                    NewField172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 6, 271, 25, false);
                    NewField172.Name = "NewField172";
                    NewField172.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField172.TextFont.Name = "Arial Narrow";
                    NewField172.TextFont.CharSet = 1;
                    NewField172.Value = @"";

                    NewField29 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 25, 98, 30, false);
                    NewField29.Name = "NewField29";
                    NewField29.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField29.TextFont.Name = "Arial Narrow";
                    NewField29.TextFont.Bold = true;
                    NewField29.Value = @"1";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 25, 104, 30, false);
                    NewField113.Name = "NewField113";
                    NewField113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113.TextFont.Name = "Arial Narrow";
                    NewField113.TextFont.Bold = true;
                    NewField113.Value = @"2";

                    NewField124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 25, 110, 30, false);
                    NewField124.Name = "NewField124";
                    NewField124.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField124.TextFont.Name = "Arial Narrow";
                    NewField124.TextFont.Bold = true;
                    NewField124.Value = @"3";

                    NewField163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 25, 116, 30, false);
                    NewField163.Name = "NewField163";
                    NewField163.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField163.TextFont.Name = "Arial Narrow";
                    NewField163.TextFont.Bold = true;
                    NewField163.Value = @"4";

                    NewField173 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 25, 122, 30, false);
                    NewField173.Name = "NewField173";
                    NewField173.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField173.TextFont.Name = "Arial Narrow";
                    NewField173.TextFont.Bold = true;
                    NewField173.Value = @"5";

                    NewField182 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 25, 128, 30, false);
                    NewField182.Name = "NewField182";
                    NewField182.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField182.TextFont.Name = "Arial Narrow";
                    NewField182.TextFont.Bold = true;
                    NewField182.Value = @"6";

                    NewField192 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 25, 134, 30, false);
                    NewField192.Name = "NewField192";
                    NewField192.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField192.TextFont.Name = "Arial Narrow";
                    NewField192.TextFont.Bold = true;
                    NewField192.Value = @"7";

                    NewField103 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 25, 140, 30, false);
                    NewField103.Name = "NewField103";
                    NewField103.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField103.TextFont.Name = "Arial Narrow";
                    NewField103.TextFont.Bold = true;
                    NewField103.Value = @"8";

                    NewField114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 25, 146, 30, false);
                    NewField114.Name = "NewField114";
                    NewField114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114.TextFont.Name = "Arial Narrow";
                    NewField114.TextFont.Bold = true;
                    NewField114.Value = @"9";

                    NewField125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 25, 152, 30, false);
                    NewField125.Name = "NewField125";
                    NewField125.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField125.TextFont.Name = "Arial Narrow";
                    NewField125.TextFont.Bold = true;
                    NewField125.Value = @"10";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 25, 158, 30, false);
                    NewField133.Name = "NewField133";
                    NewField133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField133.TextFont.Name = "Arial Narrow";
                    NewField133.TextFont.Bold = true;
                    NewField133.Value = @"11";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 25, 164, 30, false);
                    NewField143.Name = "NewField143";
                    NewField143.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField143.TextFont.Name = "Arial Narrow";
                    NewField143.TextFont.Bold = true;
                    NewField143.Value = @"12";

                    NewField153 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 25, 170, 30, false);
                    NewField153.Name = "NewField153";
                    NewField153.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField153.TextFont.Name = "Arial Narrow";
                    NewField153.TextFont.Bold = true;
                    NewField153.Value = @"13";

                    NewField164 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 25, 176, 30, false);
                    NewField164.Name = "NewField164";
                    NewField164.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField164.TextFont.Name = "Arial Narrow";
                    NewField164.TextFont.Bold = true;
                    NewField164.Value = @"14";

                    NewField174 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 25, 182, 30, false);
                    NewField174.Name = "NewField174";
                    NewField174.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField174.TextFont.Name = "Arial Narrow";
                    NewField174.TextFont.Bold = true;
                    NewField174.Value = @"15";

                    NewField183 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 25, 188, 30, false);
                    NewField183.Name = "NewField183";
                    NewField183.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField183.TextFont.Name = "Arial Narrow";
                    NewField183.TextFont.Bold = true;
                    NewField183.Value = @"16";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 25, 194, 30, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.TextFont.Name = "Arial Narrow";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @"17";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 25, 200, 30, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1221.TextFont.Name = "Arial Narrow";
                    NewField1221.TextFont.Bold = true;
                    NewField1221.Value = @"18";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 198, 25, 206, 30, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1161.TextFont.Name = "Arial Narrow";
                    NewField1161.TextFont.Bold = true;
                    NewField1161.Value = @"19";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 25, 212, 30, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1171.TextFont.Name = "Arial Narrow";
                    NewField1171.TextFont.Bold = true;
                    NewField1171.Value = @"20";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 25, 218, 30, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1181.TextFont.Name = "Arial Narrow";
                    NewField1181.TextFont.Bold = true;
                    NewField1181.Value = @"21";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 25, 224, 30, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1191.TextFont.Name = "Arial Narrow";
                    NewField1191.TextFont.Bold = true;
                    NewField1191.Value = @"22";

                    NewField1201 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 25, 230, 30, false);
                    NewField1201.Name = "NewField1201";
                    NewField1201.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1201.TextFont.Name = "Arial Narrow";
                    NewField1201.TextFont.Bold = true;
                    NewField1201.Value = @"23";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 25, 236, 30, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211.TextFont.Name = "Arial Narrow";
                    NewField1211.TextFont.Bold = true;
                    NewField1211.Value = @"24";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 25, 242, 30, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321.TextFont.Name = "Arial Narrow";
                    NewField1321.TextFont.Bold = true;
                    NewField1321.Value = @"25";

                    NewField1231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 25, 248, 30, false);
                    NewField1231.Name = "NewField1231";
                    NewField1231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1231.TextFont.Name = "Arial Narrow";
                    NewField1231.TextFont.Bold = true;
                    NewField1231.Value = @"26";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 25, 254, 30, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1241.TextFont.Name = "Arial Narrow";
                    NewField1241.TextFont.Bold = true;
                    NewField1241.Value = @"27";

                    NewField1251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 252, 25, 260, 30, false);
                    NewField1251.Name = "NewField1251";
                    NewField1251.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1251.TextFont.Name = "Arial Narrow";
                    NewField1251.TextFont.Bold = true;
                    NewField1251.Value = @"28";

                    NewField1261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 25, 266, 30, false);
                    NewField1261.Name = "NewField1261";
                    NewField1261.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1261.TextFont.Name = "Arial Narrow";
                    NewField1261.TextFont.Bold = true;
                    NewField1261.Value = @"29";

                    NewField1271 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 25, 271, 30, false);
                    NewField1271.Name = "NewField1271";
                    NewField1271.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1271.TextFont.Name = "Arial Narrow";
                    NewField1271.TextFont.Bold = true;
                    NewField1271.Value = @"30";

                    HIKAYE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 6, 82, 25, false);
                    HIKAYE.Name = "HIKAYE";
                    HIKAYE.DrawStyle = DrawStyleConstants.vbSolid;
                    HIKAYE.FieldType = ReportFieldTypeEnum.ftVariable;
                    HIKAYE.MultiLine = EvetHayirEnum.ehEvet;
                    HIKAYE.WordBreak = EvetHayirEnum.ehEvet;
                    HIKAYE.TextFont.Name = "Arial Narrow";
                    HIKAYE.TextFont.Size = 9;
                    HIKAYE.TextFont.Bold = true;
                    HIKAYE.Value = @"Hastanın Hikayesi ve Önemli Bulgular + ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetails_Class dataset_GetPhysiotherapyOrderDetails = ParentGroup.rsGroup.GetCurrentRecord<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetails_Class>(0);
                    ORDEROBJECTOBJECTID.CalcValue = (dataset_GetPhysiotherapyOrderDetails != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrderDetails.Orderobjectobjectid) : "");
                    NewField11114111.CalcValue = NewField11114111.Value;
                    NewField111141111.CalcValue = NewField111141111.Value;
                    NewField112141111.CalcValue = NewField112141111.Value;
                    NewField1111141211.CalcValue = NewField1111141211.Value;
                    TREATMENTDIAGNOSISUNITNAME.CalcValue = (dataset_GetPhysiotherapyOrderDetails != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrderDetails.Treatmentdiagnosisunitname) : "");
                    NewField1111141111.CalcValue = NewField1111141111.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField20.CalcValue = NewField20.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField22.CalcValue = NewField22.Value;
                    NewField23.CalcValue = NewField23.Value;
                    NewField24.CalcValue = NewField24.Value;
                    NewField25.CalcValue = NewField25.Value;
                    NewField26.CalcValue = NewField26.Value;
                    NewField27.CalcValue = NewField27.Value;
                    NewField28.CalcValue = NewField28.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField181.CalcValue = NewField181.Value;
                    NewField191.CalcValue = NewField191.Value;
                    NewField102.CalcValue = NewField102.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField123.CalcValue = NewField123.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField152.CalcValue = NewField152.Value;
                    NewField162.CalcValue = NewField162.Value;
                    NewField172.CalcValue = NewField172.Value;
                    NewField29.CalcValue = NewField29.Value;
                    NewField113.CalcValue = NewField113.Value;
                    NewField124.CalcValue = NewField124.Value;
                    NewField163.CalcValue = NewField163.Value;
                    NewField173.CalcValue = NewField173.Value;
                    NewField182.CalcValue = NewField182.Value;
                    NewField192.CalcValue = NewField192.Value;
                    NewField103.CalcValue = NewField103.Value;
                    NewField114.CalcValue = NewField114.Value;
                    NewField125.CalcValue = NewField125.Value;
                    NewField133.CalcValue = NewField133.Value;
                    NewField143.CalcValue = NewField143.Value;
                    NewField153.CalcValue = NewField153.Value;
                    NewField164.CalcValue = NewField164.Value;
                    NewField174.CalcValue = NewField174.Value;
                    NewField183.CalcValue = NewField183.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    NewField1191.CalcValue = NewField1191.Value;
                    NewField1201.CalcValue = NewField1201.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    NewField1231.CalcValue = NewField1231.Value;
                    NewField1241.CalcValue = NewField1241.Value;
                    NewField1251.CalcValue = NewField1251.Value;
                    NewField1261.CalcValue = NewField1261.Value;
                    NewField1271.CalcValue = NewField1271.Value;
                    HIKAYE.CalcValue = @"Hastanın Hikayesi ve Önemli Bulgular + ";
                    return new TTReportObject[] { ORDEROBJECTOBJECTID,NewField11114111,NewField111141111,NewField112141111,NewField1111141211,TREATMENTDIAGNOSISUNITNAME,NewField1111141111,NewField1,NewField11,NewField12,NewField16,NewField17,NewField18,NewField19,NewField20,NewField21,NewField22,NewField23,NewField24,NewField25,NewField26,NewField27,NewField28,NewField111,NewField122,NewField161,NewField171,NewField181,NewField191,NewField102,NewField112,NewField123,NewField132,NewField142,NewField152,NewField162,NewField172,NewField29,NewField113,NewField124,NewField163,NewField173,NewField182,NewField192,NewField103,NewField114,NewField125,NewField133,NewField143,NewField153,NewField164,NewField174,NewField183,NewField1111,NewField1221,NewField1161,NewField1171,NewField1181,NewField1191,NewField1201,NewField1211,NewField1321,NewField1231,NewField1241,NewField1251,NewField1261,NewField1271,HIKAYE};
                }
            }
            public partial class ORDERSGroupFooter : TTReportSection
            {
                public PhysiotheraphyTreatmentCard MyParentReport
                {
                    get { return (PhysiotheraphyTreatmentCard)ParentReport; }
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
            public PhysiotheraphyTreatmentCard MyParentReport
            {
                get { return (PhysiotheraphyTreatmentCard)ParentReport; }
            }

            new public ORDERDETAILSGroupBody Body()
            {
                return (ORDERDETAILSGroupBody)_body;
            }
            public TTReportField PROCEDUREBYUSER { get {return Body().PROCEDUREBYUSER;} }
            public TTReportField ORDEROBJECTPROCEDUREDOCTOR { get {return Body().ORDEROBJECTPROCEDUREDOCTOR;} }
            public TTReportField ORDERDETAILPROCEDUREBYUSER { get {return Body().ORDERDETAILPROCEDUREBYUSER;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField NewField171 { get {return Body().NewField171;} }
            public TTReportField NewField181 { get {return Body().NewField181;} }
            public TTReportField NewField191 { get {return Body().NewField191;} }
            public TTReportField NewField102 { get {return Body().NewField102;} }
            public TTReportField NewField112 { get {return Body().NewField112;} }
            public TTReportField NewField122 { get {return Body().NewField122;} }
            public TTReportField NewField132 { get {return Body().NewField132;} }
            public TTReportField NewField142 { get {return Body().NewField142;} }
            public TTReportField NewField152 { get {return Body().NewField152;} }
            public TTReportField NewField162 { get {return Body().NewField162;} }
            public TTReportField NewField172 { get {return Body().NewField172;} }
            public TTReportField NewField182 { get {return Body().NewField182;} }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
            public TTReportField NewField1221 { get {return Body().NewField1221;} }
            public TTReportField NewField1161 { get {return Body().NewField1161;} }
            public TTReportField NewField1171 { get {return Body().NewField1171;} }
            public TTReportField NewField1181 { get {return Body().NewField1181;} }
            public TTReportField NewField1191 { get {return Body().NewField1191;} }
            public TTReportField NewField1201 { get {return Body().NewField1201;} }
            public TTReportField NewField1211 { get {return Body().NewField1211;} }
            public TTReportField NewField1321 { get {return Body().NewField1321;} }
            public TTReportField NewField1231 { get {return Body().NewField1231;} }
            public TTReportField NewField1241 { get {return Body().NewField1241;} }
            public TTReportField NewField1251 { get {return Body().NewField1251;} }
            public TTReportField NewField1261 { get {return Body().NewField1261;} }
            public TTReportField NewField1271 { get {return Body().NewField1271;} }
            public TTReportField PROCEDUREOBJECTCODENAME1 { get {return Body().PROCEDUREOBJECTCODENAME1;} }
            public TTReportField APPLICATIONAREA1 { get {return Body().APPLICATIONAREA1;} }
            public TTReportField DURATION1 { get {return Body().DURATION1;} }
            public TTReportField AMOUNT1 { get {return Body().AMOUNT1;} }
            public TTReportField NewField111141111 { get {return Body().NewField111141111;} }
            public TTReportField NewField111141112 { get {return Body().NewField111141112;} }
            public TTReportShape NewRect1 { get {return Body().NewRect1;} }
            public TTReportField DOZACIKLAMA { get {return Body().DOZACIKLAMA;} }
            public TTReportField BOLGEACIKLAMA { get {return Body().BOLGEACIKLAMA;} }
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

                PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetails_Class dataSet_GetPhysiotherapyOrderDetails = ParentGroup.rsGroup.GetCurrentRecord<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetails_Class>(0);    
                return new object[] {(dataSet_GetPhysiotherapyOrderDetails==null ? null : dataSet_GetPhysiotherapyOrderDetails.Treatmentdiagnosisunitname)};
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
                public PhysiotheraphyTreatmentCard MyParentReport
                {
                    get { return (PhysiotheraphyTreatmentCard)ParentReport; }
                }
                
                public TTReportField PROCEDUREBYUSER;
                public TTReportField ORDEROBJECTPROCEDUREDOCTOR;
                public TTReportField ORDERDETAILPROCEDUREBYUSER;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField NewField161;
                public TTReportField NewField171;
                public TTReportField NewField181;
                public TTReportField NewField191;
                public TTReportField NewField102;
                public TTReportField NewField112;
                public TTReportField NewField122;
                public TTReportField NewField132;
                public TTReportField NewField142;
                public TTReportField NewField152;
                public TTReportField NewField162;
                public TTReportField NewField172;
                public TTReportField NewField182;
                public TTReportField NewField1111;
                public TTReportField NewField1221;
                public TTReportField NewField1161;
                public TTReportField NewField1171;
                public TTReportField NewField1181;
                public TTReportField NewField1191;
                public TTReportField NewField1201;
                public TTReportField NewField1211;
                public TTReportField NewField1321;
                public TTReportField NewField1231;
                public TTReportField NewField1241;
                public TTReportField NewField1251;
                public TTReportField NewField1261;
                public TTReportField NewField1271;
                public TTReportField PROCEDUREOBJECTCODENAME1;
                public TTReportField APPLICATIONAREA1;
                public TTReportField DURATION1;
                public TTReportField AMOUNT1;
                public TTReportField NewField111141111;
                public TTReportField NewField111141112;
                public TTReportShape NewRect1;
                public TTReportField DOZACIKLAMA;
                public TTReportField BOLGEACIKLAMA; 
                public ORDERDETAILSGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 28;
                    RepeatCount = 0;
                    
                    PROCEDUREBYUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 6, 350, 11, false);
                    PROCEDUREBYUSER.Name = "PROCEDUREBYUSER";
                    PROCEDUREBYUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREBYUSER.TextFormat = @"g";
                    PROCEDUREBYUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROCEDUREBYUSER.TextFont.Name = "Arial Narrow";
                    PROCEDUREBYUSER.TextFont.Size = 9;
                    PROCEDUREBYUSER.Value = @"{#ORDERS.PROCEDUREBYUSER#}";

                    ORDEROBJECTPROCEDUREDOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 299, 13, 373, 18, false);
                    ORDEROBJECTPROCEDUREDOCTOR.Name = "ORDEROBJECTPROCEDUREDOCTOR";
                    ORDEROBJECTPROCEDUREDOCTOR.Visible = EvetHayirEnum.ehHayir;
                    ORDEROBJECTPROCEDUREDOCTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDEROBJECTPROCEDUREDOCTOR.TextFormat = @"g";
                    ORDEROBJECTPROCEDUREDOCTOR.TextFont.Name = "Arial Narrow";
                    ORDEROBJECTPROCEDUREDOCTOR.TextFont.Size = 9;
                    ORDEROBJECTPROCEDUREDOCTOR.Value = @"{#ORDERS.ORDEROBJECTPROCEDUREDOCTOR#}";

                    ORDERDETAILPROCEDUREBYUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 299, 18, 373, 23, false);
                    ORDERDETAILPROCEDUREBYUSER.Name = "ORDERDETAILPROCEDUREBYUSER";
                    ORDERDETAILPROCEDUREBYUSER.Visible = EvetHayirEnum.ehHayir;
                    ORDERDETAILPROCEDUREBYUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERDETAILPROCEDUREBYUSER.TextFormat = @"g";
                    ORDERDETAILPROCEDUREBYUSER.TextFont.Name = "Arial Narrow";
                    ORDERDETAILPROCEDUREBYUSER.TextFont.Size = 9;
                    ORDERDETAILPROCEDUREBYUSER.Value = @"{#ORDERS.PROCEDUREBYUSER#}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 0, 98, 28, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.TextFont.Name = "Arial Narrow";
                    NewField11.TextFont.CharSet = 1;
                    NewField11.Value = @"";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 0, 104, 28, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.TextFont.Name = "Arial Narrow";
                    NewField111.TextFont.CharSet = 1;
                    NewField111.Value = @"";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 0, 110, 28, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.TextFont.Name = "Arial Narrow";
                    NewField121.TextFont.CharSet = 1;
                    NewField121.Value = @"";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 0, 116, 28, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.TextFont.Name = "Arial Narrow";
                    NewField161.TextFont.CharSet = 1;
                    NewField161.Value = @"";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 0, 122, 28, false);
                    NewField171.Name = "NewField171";
                    NewField171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField171.TextFont.Name = "Arial Narrow";
                    NewField171.TextFont.CharSet = 1;
                    NewField171.Value = @"";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 0, 128, 28, false);
                    NewField181.Name = "NewField181";
                    NewField181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField181.TextFont.Name = "Arial Narrow";
                    NewField181.TextFont.CharSet = 1;
                    NewField181.Value = @"";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 0, 134, 28, false);
                    NewField191.Name = "NewField191";
                    NewField191.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField191.TextFont.Name = "Arial Narrow";
                    NewField191.TextFont.CharSet = 1;
                    NewField191.Value = @"";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 0, 140, 28, false);
                    NewField102.Name = "NewField102";
                    NewField102.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField102.TextFont.Name = "Arial Narrow";
                    NewField102.TextFont.CharSet = 1;
                    NewField102.Value = @"";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 0, 146, 28, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.TextFont.Name = "Arial Narrow";
                    NewField112.TextFont.CharSet = 1;
                    NewField112.Value = @"";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 0, 152, 28, false);
                    NewField122.Name = "NewField122";
                    NewField122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122.TextFont.Name = "Arial Narrow";
                    NewField122.TextFont.CharSet = 1;
                    NewField122.Value = @"";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 0, 158, 28, false);
                    NewField132.Name = "NewField132";
                    NewField132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField132.TextFont.Name = "Arial Narrow";
                    NewField132.TextFont.CharSet = 1;
                    NewField132.Value = @"";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 0, 164, 28, false);
                    NewField142.Name = "NewField142";
                    NewField142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField142.TextFont.Name = "Arial Narrow";
                    NewField142.TextFont.CharSet = 1;
                    NewField142.Value = @"";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 0, 170, 28, false);
                    NewField152.Name = "NewField152";
                    NewField152.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField152.TextFont.Name = "Arial Narrow";
                    NewField152.TextFont.CharSet = 1;
                    NewField152.Value = @"";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 0, 176, 28, false);
                    NewField162.Name = "NewField162";
                    NewField162.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField162.TextFont.Name = "Arial Narrow";
                    NewField162.TextFont.CharSet = 1;
                    NewField162.Value = @"";

                    NewField172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 0, 182, 28, false);
                    NewField172.Name = "NewField172";
                    NewField172.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField172.TextFont.Name = "Arial Narrow";
                    NewField172.TextFont.CharSet = 1;
                    NewField172.Value = @"";

                    NewField182 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 0, 188, 28, false);
                    NewField182.Name = "NewField182";
                    NewField182.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField182.TextFont.Name = "Arial Narrow";
                    NewField182.TextFont.CharSet = 1;
                    NewField182.Value = @"";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 0, 194, 28, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.TextFont.Name = "Arial Narrow";
                    NewField1111.TextFont.CharSet = 1;
                    NewField1111.Value = @"";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 0, 200, 28, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1221.TextFont.Name = "Arial Narrow";
                    NewField1221.TextFont.CharSet = 1;
                    NewField1221.Value = @"";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 198, 0, 206, 28, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1161.TextFont.Name = "Arial Narrow";
                    NewField1161.TextFont.CharSet = 1;
                    NewField1161.Value = @"";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 0, 212, 28, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1171.TextFont.Name = "Arial Narrow";
                    NewField1171.TextFont.CharSet = 1;
                    NewField1171.Value = @"";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 0, 218, 28, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1181.TextFont.Name = "Arial Narrow";
                    NewField1181.TextFont.CharSet = 1;
                    NewField1181.Value = @"";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 0, 224, 28, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1191.TextFont.Name = "Arial Narrow";
                    NewField1191.TextFont.CharSet = 1;
                    NewField1191.Value = @"";

                    NewField1201 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 0, 230, 28, false);
                    NewField1201.Name = "NewField1201";
                    NewField1201.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1201.TextFont.Name = "Arial Narrow";
                    NewField1201.TextFont.CharSet = 1;
                    NewField1201.Value = @"";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 0, 236, 28, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211.TextFont.Name = "Arial Narrow";
                    NewField1211.TextFont.CharSet = 1;
                    NewField1211.Value = @"";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 0, 242, 28, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321.TextFont.Name = "Arial Narrow";
                    NewField1321.TextFont.CharSet = 1;
                    NewField1321.Value = @"";

                    NewField1231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 0, 248, 28, false);
                    NewField1231.Name = "NewField1231";
                    NewField1231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1231.TextFont.Name = "Arial Narrow";
                    NewField1231.TextFont.CharSet = 1;
                    NewField1231.Value = @"";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 0, 254, 28, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1241.TextFont.Name = "Arial Narrow";
                    NewField1241.TextFont.CharSet = 1;
                    NewField1241.Value = @"";

                    NewField1251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 252, 0, 260, 28, false);
                    NewField1251.Name = "NewField1251";
                    NewField1251.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1251.TextFont.Name = "Arial Narrow";
                    NewField1251.TextFont.CharSet = 1;
                    NewField1251.Value = @"";

                    NewField1261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 0, 266, 28, false);
                    NewField1261.Name = "NewField1261";
                    NewField1261.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1261.TextFont.Name = "Arial Narrow";
                    NewField1261.TextFont.CharSet = 1;
                    NewField1261.Value = @"";

                    NewField1271 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 0, 271, 28, false);
                    NewField1271.Name = "NewField1271";
                    NewField1271.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1271.TextFont.Name = "Arial Narrow";
                    NewField1271.TextFont.CharSet = 1;
                    NewField1271.Value = @"";

                    PROCEDUREOBJECTCODENAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 48, 11, false);
                    PROCEDUREOBJECTCODENAME1.Name = "PROCEDUREOBJECTCODENAME1";
                    PROCEDUREOBJECTCODENAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREOBJECTCODENAME1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PROCEDUREOBJECTCODENAME1.MultiLine = EvetHayirEnum.ehEvet;
                    PROCEDUREOBJECTCODENAME1.NoClip = EvetHayirEnum.ehEvet;
                    PROCEDUREOBJECTCODENAME1.WordBreak = EvetHayirEnum.ehEvet;
                    PROCEDUREOBJECTCODENAME1.ExpandTabs = EvetHayirEnum.ehEvet;
                    PROCEDUREOBJECTCODENAME1.TextFont.Name = "Arial Narrow";
                    PROCEDUREOBJECTCODENAME1.TextFont.Size = 8;
                    PROCEDUREOBJECTCODENAME1.Value = @"";

                    APPLICATIONAREA1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 0, 90, 5, false);
                    APPLICATIONAREA1.Name = "APPLICATIONAREA1";
                    APPLICATIONAREA1.FieldType = ReportFieldTypeEnum.ftVariable;
                    APPLICATIONAREA1.MultiLine = EvetHayirEnum.ehEvet;
                    APPLICATIONAREA1.WordBreak = EvetHayirEnum.ehEvet;
                    APPLICATIONAREA1.TextFont.Name = "Arial Narrow";
                    APPLICATIONAREA1.TextFont.Size = 8;
                    APPLICATIONAREA1.Value = @"";

                    DURATION1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 0, 60, 5, false);
                    DURATION1.Name = "DURATION1";
                    DURATION1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DURATION1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DURATION1.TextFont.Name = "Arial Narrow";
                    DURATION1.TextFont.Size = 8;
                    DURATION1.Value = @"";

                    AMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 0, 69, 5, false);
                    AMOUNT1.Name = "AMOUNT1";
                    AMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT1.TextFont.Name = "Arial Narrow";
                    AMOUNT1.TextFont.Size = 8;
                    AMOUNT1.Value = @"";

                    NewField111141111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 11, 25, 16, false);
                    NewField111141111.Name = "NewField111141111";
                    NewField111141111.TextFont.Name = "Arial Narrow";
                    NewField111141111.TextFont.Size = 9;
                    NewField111141111.TextFont.Bold = true;
                    NewField111141111.Value = @"Doz Açk.:";

                    NewField111141112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 20, 25, 25, false);
                    NewField111141112.Name = "NewField111141112";
                    NewField111141112.TextFont.Name = "Arial Narrow";
                    NewField111141112.TextFont.Size = 9;
                    NewField111141112.TextFont.Bold = true;
                    NewField111141112.Value = @"Bölge Açk.:";

                    NewRect1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 10, 0, 90, 28, false);
                    NewRect1.Name = "NewRect1";
                    NewRect1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect1.FillStyle = FillStyleConstants.vbFSTransparent;

                    DOZACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 11, 90, 19, false);
                    DOZACIKLAMA.Name = "DOZACIKLAMA";
                    DOZACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOZACIKLAMA.CaseFormat = CaseFormatEnum.fcUpperCase;
                    DOZACIKLAMA.MultiLine = EvetHayirEnum.ehEvet;
                    DOZACIKLAMA.WordBreak = EvetHayirEnum.ehEvet;
                    DOZACIKLAMA.TextFont.Name = "Arial Narrow";
                    DOZACIKLAMA.TextFont.Size = 8;
                    DOZACIKLAMA.Value = @"";

                    BOLGEACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 20, 90, 28, false);
                    BOLGEACIKLAMA.Name = "BOLGEACIKLAMA";
                    BOLGEACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLGEACIKLAMA.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BOLGEACIKLAMA.MultiLine = EvetHayirEnum.ehEvet;
                    BOLGEACIKLAMA.WordBreak = EvetHayirEnum.ehEvet;
                    BOLGEACIKLAMA.TextFont.Name = "Arial Narrow";
                    BOLGEACIKLAMA.TextFont.Size = 8;
                    BOLGEACIKLAMA.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetails_Class dataset_GetPhysiotherapyOrderDetails = MyParentReport.ORDERS.rsGroup.GetCurrentRecord<PhysiotherapyOrderDetail.GetPhysiotherapyOrderDetails_Class>(0);
                    PROCEDUREBYUSER.CalcValue = (dataset_GetPhysiotherapyOrderDetails != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrderDetails.Procedurebyuser) : "");
                    ORDEROBJECTPROCEDUREDOCTOR.CalcValue = (dataset_GetPhysiotherapyOrderDetails != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrderDetails.Orderobjectproceduredoctor) : "");
                    ORDERDETAILPROCEDUREBYUSER.CalcValue = (dataset_GetPhysiotherapyOrderDetails != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrderDetails.Procedurebyuser) : "");
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField181.CalcValue = NewField181.Value;
                    NewField191.CalcValue = NewField191.Value;
                    NewField102.CalcValue = NewField102.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField152.CalcValue = NewField152.Value;
                    NewField162.CalcValue = NewField162.Value;
                    NewField172.CalcValue = NewField172.Value;
                    NewField182.CalcValue = NewField182.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    NewField1191.CalcValue = NewField1191.Value;
                    NewField1201.CalcValue = NewField1201.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    NewField1231.CalcValue = NewField1231.Value;
                    NewField1241.CalcValue = NewField1241.Value;
                    NewField1251.CalcValue = NewField1251.Value;
                    NewField1261.CalcValue = NewField1261.Value;
                    NewField1271.CalcValue = NewField1271.Value;
                    PROCEDUREOBJECTCODENAME1.CalcValue = @"";
                    APPLICATIONAREA1.CalcValue = @"";
                    DURATION1.CalcValue = @"";
                    AMOUNT1.CalcValue = @"";
                    NewField111141111.CalcValue = NewField111141111.Value;
                    NewField111141112.CalcValue = NewField111141112.Value;
                    DOZACIKLAMA.CalcValue = @"";
                    BOLGEACIKLAMA.CalcValue = @"";
                    return new TTReportObject[] { PROCEDUREBYUSER,ORDEROBJECTPROCEDUREDOCTOR,ORDERDETAILPROCEDUREBYUSER,NewField11,NewField111,NewField121,NewField161,NewField171,NewField181,NewField191,NewField102,NewField112,NewField122,NewField132,NewField142,NewField152,NewField162,NewField172,NewField182,NewField1111,NewField1221,NewField1161,NewField1171,NewField1181,NewField1191,NewField1201,NewField1211,NewField1321,NewField1231,NewField1241,NewField1251,NewField1261,NewField1271,PROCEDUREOBJECTCODENAME1,APPLICATIONAREA1,DURATION1,AMOUNT1,NewField111141111,NewField111141112,DOZACIKLAMA,BOLGEACIKLAMA};
                }

                public override void RunScript()
                {
#region ORDERDETAILS BODY_Script
                    //            if (this.EMERGENCY.CalcValue == "False")
//                this.EMERGENCY.CalcValue = "Normal";
//            else if (this.EMERGENCY.CalcValue == "True")
//                this.EMERGENCY.CalcValue = "Acil";
//            else
//                this.EMERGENCY.CalcValue = "Normal";
//                
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

        public PhysiotheraphyTreatmentCard()
        {
            MASTER = new MASTERGroup(this,"MASTER");
            ARA = new ARAGroup(MASTER,"ARA");
            MAIN = new MAINGroup(ARA,"MAIN");
            ORDERS = new ORDERSGroup(MASTER,"ORDERS");
            ORDERDETAILS = new ORDERDETAILSGroup(ORDERS,"ORDERDETAILS");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "29035332-1b23-4773-8ed6-5e2be3f51570", "Fizyoterapi İstek", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "PHYSIOTHERAPHYTREATMENTCARD";
            Caption = "FTR Tedavi Kartı";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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