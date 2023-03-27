
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
    /// Sarf Edilen Malzemeler Raporu
    /// </summary>
    public partial class TreatmentMaterialReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public TreatmentMaterialReport MyParentReport
            {
                get { return (TreatmentMaterialReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField LOGO1 { get {return Header().LOGO1;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField REPORTHEADER1 { get {return Header().REPORTHEADER1;} }
            public TTReportField DYERVETARIH { get {return Header().DYERVETARIH;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField BABAAD { get {return Header().BABAAD;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField1151 { get {return Header().NewField1151;} }
            public TTReportField NewField1171 { get {return Header().NewField1171;} }
            public TTReportField NewField1181 { get {return Header().NewField1181;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField LBLUNIQUEREFNO { get {return Header().LBLUNIQUEREFNO;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField HASTANO { get {return Header().HASTANO;} }
            public TTReportField NewField1241 { get {return Header().NewField1241;} }
            public TTReportField TARIH { get {return Header().TARIH;} }
            public TTReportField NewField1271 { get {return Header().NewField1271;} }
            public TTReportField NewField11231 { get {return Header().NewField11231;} }
            public TTReportField NewField11251 { get {return Header().NewField11251;} }
            public TTReportField SEX { get {return Header().SEX;} }
            public TTReportField NewField1191 { get {return Header().NewField1191;} }
            public TTReportField NewField11711 { get {return Header().NewField11711;} }
            public TTReportField DTARIH { get {return Header().DTARIH;} }
            public TTReportField DYER { get {return Header().DYER;} }
            public TTReportField EPISODEID { get {return Header().EPISODEID;} }
            public TTReportField EPISODEOBJECTID { get {return Header().EPISODEOBJECTID;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField11241 { get {return Header().NewField11241;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<EpisodeAction.GetPatientInfoByEpisodeAction_Class>("GetPatientInfoByEpisodeAction", EpisodeAction.GetPatientInfoByEpisodeAction((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public TreatmentMaterialReport MyParentReport
                {
                    get { return (TreatmentMaterialReport)ParentReport; }
                }
                
                public TTReportField LOGO1;
                public TTReportField XXXXXXBASLIK;
                public TTReportField REPORTHEADER1;
                public TTReportField DYERVETARIH;
                public TTReportField NewField191;
                public TTReportField BABAAD;
                public TTReportField ADSOYAD;
                public TTReportField NewField1121;
                public TTReportField NewField1141;
                public TTReportField NewField1151;
                public TTReportField NewField1171;
                public TTReportField NewField1181;
                public TTReportField UNIQUEREFNO;
                public TTReportField LBLUNIQUEREFNO;
                public TTReportField NewField11311;
                public TTReportField HASTANO;
                public TTReportField NewField1241;
                public TTReportField TARIH;
                public TTReportField NewField1271;
                public TTReportField NewField11231;
                public TTReportField NewField11251;
                public TTReportField SEX;
                public TTReportField NewField1191;
                public TTReportField NewField11711;
                public TTReportField DTARIH;
                public TTReportField DYER;
                public TTReportField EPISODEID;
                public TTReportField EPISODEOBJECTID;
                public TTReportField NewField1221;
                public TTReportField NewField11241; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 69;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
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
                    REPORTHEADER1.Value = @"HASTAYA VERİLMİŞ İLAÇLAR RAPORU";

                    DYERVETARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 57, 124, 62, false);
                    DYERVETARIH.Name = "DYERVETARIH";
                    DYERVETARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERVETARIH.TextFont.Name = "Arial Narrow";
                    DYERVETARIH.TextFont.Size = 9;
                    DYERVETARIH.Value = @"{%DYER%} / {%DTARIH%}";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 57, 56, 62, false);
                    NewField191.Name = "NewField191";
                    NewField191.TextFont.Name = "Arial Narrow";
                    NewField191.TextFont.Size = 9;
                    NewField191.TextFont.Bold = true;
                    NewField191.Value = @"Doğum Yeri ve Tarihi";

                    BABAAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 52, 124, 57, false);
                    BABAAD.Name = "BABAAD";
                    BABAAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAAD.TextFont.Name = "Arial Narrow";
                    BABAAD.TextFont.Size = 9;
                    BABAAD.Value = @"{#FATHERNAME#}";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 47, 124, 52, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.Name = "Arial Narrow";
                    ADSOYAD.TextFont.Size = 9;
                    ADSOYAD.Value = @"{#NAME#} {#SURNAME#}";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 47, 56, 52, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Name = "Arial Narrow";
                    NewField1121.TextFont.Size = 9;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.Value = @"Adı Soyadı";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 47, 58, 52, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Name = "Arial Narrow";
                    NewField1141.TextFont.Size = 9;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.Value = @":";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 52, 56, 57, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.TextFont.Name = "Arial Narrow";
                    NewField1151.TextFont.Size = 9;
                    NewField1151.TextFont.Bold = true;
                    NewField1151.Value = @"Baba Adı";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 57, 58, 62, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.TextFont.Name = "Arial Narrow";
                    NewField1171.TextFont.Size = 9;
                    NewField1171.TextFont.Bold = true;
                    NewField1171.Value = @":";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 52, 58, 57, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.TextFont.Name = "Arial Narrow";
                    NewField1181.TextFont.Size = 9;
                    NewField1181.TextFont.Bold = true;
                    NewField1181.Value = @":";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 42, 124, 47, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.Value = @"";

                    LBLUNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 42, 56, 47, false);
                    LBLUNIQUEREFNO.Name = "LBLUNIQUEREFNO";
                    LBLUNIQUEREFNO.TextFont.Name = "Arial Narrow";
                    LBLUNIQUEREFNO.TextFont.Size = 9;
                    LBLUNIQUEREFNO.TextFont.Bold = true;
                    LBLUNIQUEREFNO.Value = @"T.C. Kimlik No";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 42, 58, 47, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311.TextFont.Name = "Arial Narrow";
                    NewField11311.TextFont.Size = 9;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.Value = @":";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 52, 199, 57, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.ObjectDefName = "EpisodeAction";
                    HASTANO.DataMember = "EPISODE.PATIENT.ID";
                    HASTANO.TextFont.Name = "Arial Narrow";
                    HASTANO.TextFont.Size = 9;
                    HASTANO.Value = @"{@TTOBJECTID@}";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 52, 169, 57, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.TextFont.Name = "Arial Narrow";
                    NewField1241.TextFont.Size = 9;
                    NewField1241.TextFont.Bold = true;
                    NewField1241.Value = @"Hasta No";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 42, 199, 47, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"g";
                    TARIH.TextFont.Name = "Arial Narrow";
                    TARIH.TextFont.Size = 9;
                    TARIH.Value = @"{#ACTIONDATE#}";

                    NewField1271 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 42, 169, 47, false);
                    NewField1271.Name = "NewField1271";
                    NewField1271.TextFont.Name = "Arial Narrow";
                    NewField1271.TextFont.Size = 9;
                    NewField1271.TextFont.Bold = true;
                    NewField1271.Value = @"Tarih";

                    NewField11231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 52, 171, 57, false);
                    NewField11231.Name = "NewField11231";
                    NewField11231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11231.TextFont.Name = "Arial Narrow";
                    NewField11231.TextFont.Size = 9;
                    NewField11231.TextFont.Bold = true;
                    NewField11231.Value = @":";

                    NewField11251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 42, 171, 47, false);
                    NewField11251.Name = "NewField11251";
                    NewField11251.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11251.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11251.TextFont.Name = "Arial Narrow";
                    NewField11251.TextFont.Size = 9;
                    NewField11251.TextFont.Bold = true;
                    NewField11251.Value = @":";

                    SEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 62, 124, 67, false);
                    SEX.Name = "SEX";
                    SEX.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEX.ObjectDefName = "SexEnum";
                    SEX.DataMember = "DISPLAYTEXT";
                    SEX.TextFont.Name = "Arial Narrow";
                    SEX.TextFont.Size = 9;
                    SEX.Value = @"{#SEX#}";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 62, 56, 67, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.TextFont.Name = "Arial Narrow";
                    NewField1191.TextFont.Size = 9;
                    NewField1191.TextFont.Bold = true;
                    NewField1191.Value = @"Cinsiyeti";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 62, 58, 67, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.TextFont.Name = "Arial Narrow";
                    NewField11711.TextFont.Size = 9;
                    NewField11711.TextFont.Bold = true;
                    NewField11711.Value = @":";

                    DTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 53, 254, 58, false);
                    DTARIH.Name = "DTARIH";
                    DTARIH.Visible = EvetHayirEnum.ehHayir;
                    DTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIH.TextFormat = @"Short Date";
                    DTARIH.TextFont.Name = "Arial Narrow";
                    DTARIH.TextFont.Size = 9;
                    DTARIH.Value = @"{#BIRTHDATE#}";

                    DYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 58, 254, 63, false);
                    DYER.Name = "DYER";
                    DYER.Visible = EvetHayirEnum.ehHayir;
                    DYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYER.TextFont.Name = "Arial Narrow";
                    DYER.TextFont.Size = 9;
                    DYER.Value = @"{#CITYOFBIRTH#}";

                    EPISODEID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 47, 199, 52, false);
                    EPISODEID.Name = "EPISODEID";
                    EPISODEID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEID.TextFont.Name = "Arial Narrow";
                    EPISODEID.TextFont.Size = 9;
                    EPISODEID.Value = @"{#EPISODEID#}";

                    EPISODEOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 48, 265, 53, false);
                    EPISODEOBJECTID.Name = "EPISODEOBJECTID";
                    EPISODEOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEOBJECTID.TextFont.Name = "Arial Narrow";
                    EPISODEOBJECTID.TextFont.Size = 9;
                    EPISODEOBJECTID.Value = @"{#EPISODEOBJECTID#}";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 47, 169, 52, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.Name = "Arial Narrow";
                    NewField1221.TextFont.Size = 9;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.Value = @"Episode No";

                    NewField11241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 47, 171, 52, false);
                    NewField11241.Name = "NewField11241";
                    NewField11241.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11241.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11241.TextFont.Name = "Arial Narrow";
                    NewField11241.TextFont.Size = 9;
                    NewField11241.TextFont.Bold = true;
                    NewField11241.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetPatientInfoByEpisodeAction_Class dataset_GetPatientInfoByEpisodeAction = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.GetPatientInfoByEpisodeAction_Class>(0);
                    LOGO1.CalcValue = LOGO1.Value;
                    REPORTHEADER1.CalcValue = REPORTHEADER1.Value;
                    DYER.CalcValue = (dataset_GetPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetPatientInfoByEpisodeAction.Cityofbirth) : "");
                    DTARIH.CalcValue = (dataset_GetPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetPatientInfoByEpisodeAction.BirthDate) : "");
                    DYERVETARIH.CalcValue = MyParentReport.HEADER.DYER.CalcValue + @" / " + MyParentReport.HEADER.DTARIH.FormattedValue;
                    NewField191.CalcValue = NewField191.Value;
                    BABAAD.CalcValue = (dataset_GetPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetPatientInfoByEpisodeAction.FatherName) : "");
                    ADSOYAD.CalcValue = (dataset_GetPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetPatientInfoByEpisodeAction.Name) : "") + @" " + (dataset_GetPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetPatientInfoByEpisodeAction.Surname) : "");
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    UNIQUEREFNO.CalcValue = @"";
                    LBLUNIQUEREFNO.CalcValue = LBLUNIQUEREFNO.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    HASTANO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    HASTANO.PostFieldValueCalculation();
                    NewField1241.CalcValue = NewField1241.Value;
                    TARIH.CalcValue = (dataset_GetPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetPatientInfoByEpisodeAction.ActionDate) : "");
                    NewField1271.CalcValue = NewField1271.Value;
                    NewField11231.CalcValue = NewField11231.Value;
                    NewField11251.CalcValue = NewField11251.Value;
                    SEX.CalcValue = (dataset_GetPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetPatientInfoByEpisodeAction.Sex) : "");
                    SEX.PostFieldValueCalculation();
                    NewField1191.CalcValue = NewField1191.Value;
                    NewField11711.CalcValue = NewField11711.Value;
                    EPISODEID.CalcValue = (dataset_GetPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetPatientInfoByEpisodeAction.Episodeid) : "");
                    EPISODEOBJECTID.CalcValue = (dataset_GetPatientInfoByEpisodeAction != null ? Globals.ToStringCore(dataset_GetPatientInfoByEpisodeAction.Episodeobjectid) : "");
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField11241.CalcValue = NewField11241.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { LOGO1,REPORTHEADER1,DYER,DTARIH,DYERVETARIH,NewField191,BABAAD,ADSOYAD,NewField1121,NewField1141,NewField1151,NewField1171,NewField1181,UNIQUEREFNO,LBLUNIQUEREFNO,NewField11311,HASTANO,NewField1241,TARIH,NewField1271,NewField11231,NewField11251,SEX,NewField1191,NewField11711,EPISODEID,EPISODEOBJECTID,NewField1221,NewField11241,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((TreatmentMaterialReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            EpisodeAction episodeAction = (EpisodeAction)objectContext.GetObject(new Guid(objectID),"EpisodeAction");
            Episode episode = episodeAction.Episode;
            
            //this.BIRLIK.CalcValue = " " + (episode.MilitaryUnit == null ? (episode.Patient.MilitaryUnit == null ? "" : episode.Patient.MilitaryUnit.Name) : episode.MilitaryUnit.Name);
            if (episode.Patient.Foreign == true)
            {
                this.UNIQUEREFNO.CalcValue = episode.Patient.ForeignUniqueRefNo.ToString();
                this.LBLUNIQUEREFNO.CalcValue = "Kimlik/Sigorta No (Yabancı Hasta)";
            }
            else
            {
                this.UNIQUEREFNO.CalcValue = episode.Patient.UniqueRefNo.ToString();
                this.LBLUNIQUEREFNO.CalcValue = "T.C. Kimlik No";
            }
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public TreatmentMaterialReport MyParentReport
                {
                    get { return (TreatmentMaterialReport)ParentReport; }
                }
                
                public TTReportShape NewLine121;
                public TTReportField PrintDate;
                public TTReportField PageNumber; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 19;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 2, 199, 2, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 3, 199, 8, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PrintDate.TextFont.Name = "Arial Narrow";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.Value = @"{@printdate@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 13, 119, 18, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PageNumber.TextFont.Name = "Arial Narrow";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetPatientInfoByEpisodeAction_Class dataset_GetPatientInfoByEpisodeAction = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.GetPatientInfoByEpisodeAction_Class>(0);
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    return new TTReportObject[] { PrintDate,PageNumber};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class PARTAGroup : TTReportGroup
        {
            public TreatmentMaterialReport MyParentReport
            {
                get { return (TreatmentMaterialReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public TreatmentMaterialReport MyParentReport
                {
                    get { return (TreatmentMaterialReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportShape NewLine2; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 44, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"Veriliş Tarihi";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 1, 177, 6, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Size = 9;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"İlaç / Malzeme İsmi";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 1, 199, 6, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.TextFont.Size = 9;
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"Adet";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 6, 199, 6, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    return new TTReportObject[] { NewField1,NewField2,NewField3};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public TreatmentMaterialReport MyParentReport
                {
                    get { return (TreatmentMaterialReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public TreatmentMaterialReport MyParentReport
            {
                get { return (TreatmentMaterialReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField ACTIONDATE { get {return Body().ACTIONDATE;} }
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
                list[0] = new TTReportNqlData<BaseTreatmentMaterial.GetTreatmentMaterialByEpisode_Class>("GetTreatmentMaterialByEpisode", BaseTreatmentMaterial.GetTreatmentMaterialByEpisode((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.HEADER.EPISODEOBJECTID.CalcValue)));
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
                public TreatmentMaterialReport MyParentReport
                {
                    get { return (TreatmentMaterialReport)ParentReport; }
                }
                
                public TTReportField MATERIALNAME;
                public TTReportField AMOUNT;
                public TTReportField ACTIONDATE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 1, 177, 6, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALNAME.NoClip = EvetHayirEnum.ehEvet;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    MATERIALNAME.TextFont.Name = "Arial Narrow";
                    MATERIALNAME.TextFont.Size = 9;
                    MATERIALNAME.Value = @"{#CODE#} {#NAME#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 1, 199, 6, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.TextFont.Name = "Arial Narrow";
                    AMOUNT.TextFont.Size = 9;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    ACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 44, 6, false);
                    ACTIONDATE.Name = "ACTIONDATE";
                    ACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONDATE.TextFormat = @"g";
                    ACTIONDATE.TextFont.Name = "Arial Narrow";
                    ACTIONDATE.TextFont.Size = 9;
                    ACTIONDATE.Value = @"{#ACTIONDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BaseTreatmentMaterial.GetTreatmentMaterialByEpisode_Class dataset_GetTreatmentMaterialByEpisode = ParentGroup.rsGroup.GetCurrentRecord<BaseTreatmentMaterial.GetTreatmentMaterialByEpisode_Class>(0);
                    MATERIALNAME.CalcValue = (dataset_GetTreatmentMaterialByEpisode != null ? Globals.ToStringCore(dataset_GetTreatmentMaterialByEpisode.Code) : "") + @" " + (dataset_GetTreatmentMaterialByEpisode != null ? Globals.ToStringCore(dataset_GetTreatmentMaterialByEpisode.Name) : "");
                    AMOUNT.CalcValue = (dataset_GetTreatmentMaterialByEpisode != null ? Globals.ToStringCore(dataset_GetTreatmentMaterialByEpisode.Amount) : "");
                    ACTIONDATE.CalcValue = (dataset_GetTreatmentMaterialByEpisode != null ? Globals.ToStringCore(dataset_GetTreatmentMaterialByEpisode.ActionDate) : "");
                    return new TTReportObject[] { MATERIALNAME,AMOUNT,ACTIONDATE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public TreatmentMaterialReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            PARTA = new PARTAGroup(HEADER,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ObjectID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "TREATMENTMATERIALREPORT";
            Caption = "Sarf Edilen Malzemeler Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 10;
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