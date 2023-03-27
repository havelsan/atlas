
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
    /// Hasta İş Listesi Raporu
    /// </summary>
    public partial class EpisodeActionWLReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public List<string> OBJECTIDS = new List<string>();
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public EpisodeActionWLReport MyParentReport
            {
                get { return (EpisodeActionWLReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField LBL_SAAT { get {return Header().LBL_SAAT;} }
            public TTReportField LBL_CINSI { get {return Header().LBL_CINSI;} }
            public TTReportField LBL_ADSOYADI { get {return Header().LBL_ADSOYADI;} }
            public TTReportField LBL_TARIH { get {return Header().LBL_TARIH;} }
            public TTReportField LBL_DURUMU { get {return Header().LBL_DURUMU;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField KRITER { get {return Header().KRITER;} }
            public TTReportField LABELK { get {return Header().LABELK;} }
            public TTReportField TARIHK { get {return Header().TARIHK;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField LBL_NOT { get {return Header().LBL_NOT;} }
            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField LBL_TARIH2 { get {return Header().LBL_TARIH2;} }
            public TTReportField LBL_ADSOYADI3 { get {return Header().LBL_ADSOYADI3;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public TTReportField PRINTDATE { get {return Footer().PRINTDATE;} }
            public TTReportField PAGENUMBER { get {return Footer().PAGENUMBER;} }
            public TTReportField USERNAME { get {return Footer().USERNAME;} }
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
                public EpisodeActionWLReport MyParentReport
                {
                    get { return (EpisodeActionWLReport)ParentReport; }
                }
                
                public TTReportField LBL_SAAT;
                public TTReportField LBL_CINSI;
                public TTReportField LBL_ADSOYADI;
                public TTReportField LBL_TARIH;
                public TTReportField LBL_DURUMU;
                public TTReportShape NewLine1;
                public TTReportField KRITER;
                public TTReportField LABELK;
                public TTReportField TARIHK;
                public TTReportField NewField18;
                public TTReportField LBL_NOT;
                public TTReportField NewField;
                public TTReportField LOGO;
                public TTReportField LBL_TARIH2;
                public TTReportField LBL_ADSOYADI3; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 38;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    LBL_SAAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 32, 55, 36, false);
                    LBL_SAAT.Name = "LBL_SAAT";
                    LBL_SAAT.TextFont.Name = "Arial Narrow";
                    LBL_SAAT.TextFont.Size = 8;
                    LBL_SAAT.TextFont.Bold = true;
                    LBL_SAAT.Value = @"Hasta Adı";

                    LBL_CINSI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 32, 182, 36, false);
                    LBL_CINSI.Name = "LBL_CINSI";
                    LBL_CINSI.TextFont.Name = "Arial Narrow";
                    LBL_CINSI.TextFont.Size = 8;
                    LBL_CINSI.TextFont.Bold = true;
                    LBL_CINSI.Value = @"Birim";

                    LBL_ADSOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 32, 220, 36, false);
                    LBL_ADSOYADI.Name = "LBL_ADSOYADI";
                    LBL_ADSOYADI.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI.TextFont.Size = 8;
                    LBL_ADSOYADI.TextFont.Bold = true;
                    LBL_ADSOYADI.Value = @"İşlem Durumu";

                    LBL_TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 32, 30, 36, false);
                    LBL_TARIH.Name = "LBL_TARIH";
                    LBL_TARIH.TextFont.Name = "Arial Narrow";
                    LBL_TARIH.TextFont.Size = 8;
                    LBL_TARIH.TextFont.Bold = true;
                    LBL_TARIH.Value = @"Kimlik No";

                    LBL_DURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 32, 234, 36, false);
                    LBL_DURUMU.Name = "LBL_DURUMU";
                    LBL_DURUMU.TextFont.Name = "Arial Narrow";
                    LBL_DURUMU.TextFont.Size = 8;
                    LBL_DURUMU.TextFont.Bold = true;
                    LBL_DURUMU.Value = @"Tarih";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 37, 290, 37, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewLine1.DrawWidth = 2;

                    KRITER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 328, 5, 583, 18, false);
                    KRITER.Name = "KRITER";
                    KRITER.Visible = EvetHayirEnum.ehHayir;
                    KRITER.FieldType = ReportFieldTypeEnum.ftVariable;
                    KRITER.MultiLine = EvetHayirEnum.ehEvet;
                    KRITER.NoClip = EvetHayirEnum.ehEvet;
                    KRITER.WordBreak = EvetHayirEnum.ehEvet;
                    KRITER.ExpandTabs = EvetHayirEnum.ehEvet;
                    KRITER.TextFont.Name = "Arial Narrow";
                    KRITER.TextFont.Size = 8;
                    KRITER.Value = @"";

                    LABELK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 32, 125, 36, false);
                    LABELK.Name = "LABELK";
                    LABELK.TextFont.Name = "Arial Narrow";
                    LABELK.TextFont.Size = 8;
                    LABELK.TextFont.Bold = true;
                    LABELK.Value = @"İşlem";

                    TARIHK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 302, 5, 323, 9, false);
                    TARIHK.Name = "TARIHK";
                    TARIHK.Visible = EvetHayirEnum.ehHayir;
                    TARIHK.TextFont.Name = "Arial Narrow";
                    TARIHK.TextFont.Size = 8;
                    TARIHK.TextFont.Bold = true;
                    TARIHK.Value = @"Kriter";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 325, 5, 328, 9, false);
                    NewField18.Name = "NewField18";
                    NewField18.Visible = EvetHayirEnum.ehHayir;
                    NewField18.TextFont.Name = "Arial Narrow";
                    NewField18.TextFont.Size = 8;
                    NewField18.Value = @":";

                    LBL_NOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 32, 248, 36, false);
                    LBL_NOT.Name = "LBL_NOT";
                    LBL_NOT.TextFont.Name = "Arial Narrow";
                    LBL_NOT.TextFont.Size = 8;
                    LBL_NOT.TextFont.Bold = true;
                    LBL_NOT.Value = @"İşlem No";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 7, 223, 21, false);
                    NewField.Name = "NewField";
                    NewField.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField.DrawWidth = 2;
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField.TextFont.Name = "Arial Narrow";
                    NewField.TextFont.Size = 14;
                    NewField.TextFont.Bold = true;
                    NewField.Value = @"Hasta İş Listesi Raporu";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 7, 54, 18, false);
                    LOGO.Name = "LOGO";
                    LOGO.Visible = EvetHayirEnum.ehHayir;
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.Value = @"";

                    LBL_TARIH2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 32, 16, 36, false);
                    LBL_TARIH2.Name = "LBL_TARIH2";
                    LBL_TARIH2.TextFont.Name = "Arial Narrow";
                    LBL_TARIH2.TextFont.Size = 8;
                    LBL_TARIH2.TextFont.Bold = true;
                    LBL_TARIH2.Value = @"Sıra";

                    LBL_ADSOYADI3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 32, 290, 36, false);
                    LBL_ADSOYADI3.Name = "LBL_ADSOYADI3";
                    LBL_ADSOYADI3.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI3.TextFont.Size = 8;
                    LBL_ADSOYADI3.TextFont.Bold = true;
                    LBL_ADSOYADI3.Value = @"Havale Eden";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LBL_SAAT.CalcValue = LBL_SAAT.Value;
                    LBL_CINSI.CalcValue = LBL_CINSI.Value;
                    LBL_ADSOYADI.CalcValue = LBL_ADSOYADI.Value;
                    LBL_TARIH.CalcValue = LBL_TARIH.Value;
                    LBL_DURUMU.CalcValue = LBL_DURUMU.Value;
                    KRITER.CalcValue = @"";
                    LABELK.CalcValue = LABELK.Value;
                    TARIHK.CalcValue = TARIHK.Value;
                    NewField18.CalcValue = NewField18.Value;
                    LBL_NOT.CalcValue = LBL_NOT.Value;
                    NewField.CalcValue = NewField.Value;
                    LOGO.CalcValue = @"";
                    LBL_TARIH2.CalcValue = LBL_TARIH2.Value;
                    LBL_ADSOYADI3.CalcValue = LBL_ADSOYADI3.Value;
                    return new TTReportObject[] { LBL_SAAT,LBL_CINSI,LBL_ADSOYADI,LBL_TARIH,LBL_DURUMU,KRITER,LABELK,TARIHK,NewField18,LBL_NOT,NewField,LOGO,LBL_TARIH2,LBL_ADSOYADI3};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public EpisodeActionWLReport MyParentReport
                {
                    get { return (EpisodeActionWLReport)ParentReport; }
                }
                
                public TTReportShape NewLine2;
                public TTReportField PRINTDATE;
                public TTReportField PAGENUMBER;
                public TTReportField USERNAME; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 13;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 1, 291, 1, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewLine2.DrawWidth = 2;

                    PRINTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 145, 7, false);
                    PRINTDATE.Name = "PRINTDATE";
                    PRINTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRINTDATE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PRINTDATE.TextFont.Name = "Arial Narrow";
                    PRINTDATE.TextFont.Size = 8;
                    PRINTDATE.Value = @"{@printdate@} - {%USERNAME%}";

                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 242, 2, 290, 7, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER.TextFont.Name = "Arial Narrow";
                    PAGENUMBER.TextFont.Size = 8;
                    PAGENUMBER.Value = @"{@pagenumber@} / {@pagecount@}";

                    USERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 7, 57, 12, false);
                    USERNAME.Name = "USERNAME";
                    USERNAME.Visible = EvetHayirEnum.ehHayir;
                    USERNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    USERNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    USERNAME.TextFont.Name = "Arial Narrow";
                    USERNAME.TextFont.Size = 8;
                    USERNAME.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    USERNAME.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    PRINTDATE.CalcValue = DateTime.Now.ToShortDateString() + @" - " + MyParentReport.HEADER.USERNAME.CalcValue;
                    PAGENUMBER.CalcValue = ParentReport.CurrentPageNumber.ToString() + @" / " + ParentReport.ReportTotalPageCount;
                    return new TTReportObject[] { USERNAME,PRINTDATE,PAGENUMBER};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public EpisodeActionWLReport MyParentReport
            {
                get { return (EpisodeActionWLReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PATIENTNAME { get {return Body().PATIENTNAME;} }
            public TTReportField WORKLISTDATE { get {return Body().WORKLISTDATE;} }
            public TTReportField STATE { get {return Body().STATE;} }
            public TTReportField PATIENTREFNO { get {return Body().PATIENTREFNO;} }
            public TTReportField MASTERRESOURCE { get {return Body().MASTERRESOURCE;} }
            public TTReportField ACTIONID { get {return Body().ACTIONID;} }
            public TTReportField FROMRESOURCE { get {return Body().FROMRESOURCE;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField EPISODEACTIONOBJECTID { get {return Body().EPISODEACTIONOBJECTID;} }
            public TTReportField OBJECTNAME { get {return Body().OBJECTNAME;} }
            public TTReportField LBL_DOKTOR1 { get {return Body().LBL_DOKTOR1;} }
            public TTReportField LBL_ADSOYADI14 { get {return Body().LBL_ADSOYADI14;} }
            public TTReportField LBL_ADSOYADI12 { get {return Body().LBL_ADSOYADI12;} }
            public TTReportField PATIENTSTATUS { get {return Body().PATIENTSTATUS;} }
            public TTReportField PROCEDUREDOCTORNAME { get {return Body().PROCEDUREDOCTORNAME;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField SUBACTIONPROCEDUREOBJECTID { get {return Body().SUBACTIONPROCEDUREOBJECTID;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
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
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[2];
                list[0] = new TTReportNqlData<EpisodeAction.GetEpisodeActionsByObjectIDs_Class>("EpisodeActionsNQL", EpisodeAction.GetEpisodeActionsByObjectIDs((List<string>) MyParentReport.RuntimeParameters.OBJECTIDS));
                list[1] = new TTReportNqlData<SubactionProcedureFlowable.GetSubactionProceduresByObjectIDs_Class>("SubactionProceduresNQL", SubactionProcedureFlowable.GetSubactionProceduresByObjectIDs((List<string>) MyParentReport.RuntimeParameters.OBJECTIDS));
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
                public EpisodeActionWLReport MyParentReport
                {
                    get { return (EpisodeActionWLReport)ParentReport; }
                }
                
                public TTReportField PATIENTNAME;
                public TTReportField WORKLISTDATE;
                public TTReportField STATE;
                public TTReportField PATIENTREFNO;
                public TTReportField MASTERRESOURCE;
                public TTReportField ACTIONID;
                public TTReportField FROMRESOURCE;
                public TTReportField COUNT;
                public TTReportField EPISODEACTIONOBJECTID;
                public TTReportField OBJECTNAME;
                public TTReportField LBL_DOKTOR1;
                public TTReportField LBL_ADSOYADI14;
                public TTReportField LBL_ADSOYADI12;
                public TTReportField PATIENTSTATUS;
                public TTReportField PROCEDUREDOCTORNAME;
                public TTReportField DESCRIPTION;
                public TTReportField SUBACTIONPROCEDUREOBJECTID;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine12; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 13;
                    AutoSizeGap = 1;
                    RepeatCount = 0;
                    
                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 1, 79, 5, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.TextFont.Name = "Arial Narrow";
                    PATIENTNAME.TextFont.Size = 8;
                    PATIENTNAME.Value = @"";

                    WORKLISTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 1, 234, 5, false);
                    WORKLISTDATE.Name = "WORKLISTDATE";
                    WORKLISTDATE.FieldType = ReportFieldTypeEnum.ftExpression;
                    WORKLISTDATE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    WORKLISTDATE.TextFormat = @"Short Date";
                    WORKLISTDATE.MultiLine = EvetHayirEnum.ehEvet;
                    WORKLISTDATE.NoClip = EvetHayirEnum.ehEvet;
                    WORKLISTDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    WORKLISTDATE.TextFont.Name = "Arial Narrow";
                    WORKLISTDATE.TextFont.Size = 8;
                    WORKLISTDATE.Value = @"(Convert.ToString({#WORKLISTDATE#}) != """" ? Convert.ToString({#WORKLISTDATE#}) : Convert.ToString({#WORKLISTDATE!SubactionProceduresNQL#}))";

                    STATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 1, 220, 5, false);
                    STATE.Name = "STATE";
                    STATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STATE.MultiLine = EvetHayirEnum.ehEvet;
                    STATE.NoClip = EvetHayirEnum.ehEvet;
                    STATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    STATE.TextFont.Name = "Arial Narrow";
                    STATE.TextFont.Size = 8;
                    STATE.Value = @"";

                    PATIENTREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 1, 34, 5, false);
                    PATIENTREFNO.Name = "PATIENTREFNO";
                    PATIENTREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTREFNO.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTREFNO.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTREFNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTREFNO.TextFont.Name = "Arial Narrow";
                    PATIENTREFNO.TextFont.Size = 8;
                    PATIENTREFNO.Value = @"";

                    MASTERRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 1, 182, 5, false);
                    MASTERRESOURCE.Name = "MASTERRESOURCE";
                    MASTERRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MASTERRESOURCE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    MASTERRESOURCE.MultiLine = EvetHayirEnum.ehEvet;
                    MASTERRESOURCE.NoClip = EvetHayirEnum.ehEvet;
                    MASTERRESOURCE.ExpandTabs = EvetHayirEnum.ehEvet;
                    MASTERRESOURCE.TextFont.Name = "Arial Narrow";
                    MASTERRESOURCE.TextFont.Size = 8;
                    MASTERRESOURCE.Value = @"";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 1, 248, 5, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.MultiLine = EvetHayirEnum.ehEvet;
                    ACTIONID.NoClip = EvetHayirEnum.ehEvet;
                    ACTIONID.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACTIONID.TextFont.Name = "Arial Narrow";
                    ACTIONID.TextFont.Size = 8;
                    ACTIONID.Value = @"";

                    FROMRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 1, 290, 5, false);
                    FROMRESOURCE.Name = "FROMRESOURCE";
                    FROMRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    FROMRESOURCE.TextFont.Name = "Arial Narrow";
                    FROMRESOURCE.TextFont.Size = 8;
                    FROMRESOURCE.Value = @"";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 15, 5, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.MultiLine = EvetHayirEnum.ehEvet;
                    COUNT.NoClip = EvetHayirEnum.ehEvet;
                    COUNT.ExpandTabs = EvetHayirEnum.ehEvet;
                    COUNT.TextFont.Name = "Arial Narrow";
                    COUNT.TextFont.Size = 8;
                    COUNT.Value = @"{@counter@}";

                    EPISODEACTIONOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 311, 2, 343, 6, false);
                    EPISODEACTIONOBJECTID.Name = "EPISODEACTIONOBJECTID";
                    EPISODEACTIONOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    EPISODEACTIONOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EPISODEACTIONOBJECTID.MultiLine = EvetHayirEnum.ehEvet;
                    EPISODEACTIONOBJECTID.NoClip = EvetHayirEnum.ehEvet;
                    EPISODEACTIONOBJECTID.ExpandTabs = EvetHayirEnum.ehEvet;
                    EPISODEACTIONOBJECTID.TextFont.Name = "Arial Narrow";
                    EPISODEACTIONOBJECTID.TextFont.Size = 8;
                    EPISODEACTIONOBJECTID.Value = @"{#OBJECTID#}";

                    OBJECTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 1, 125, 5, false);
                    OBJECTNAME.Name = "OBJECTNAME";
                    OBJECTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTNAME.NoClip = EvetHayirEnum.ehEvet;
                    OBJECTNAME.TextFont.Name = "Arial Narrow";
                    OBJECTNAME.TextFont.Size = 8;
                    OBJECTNAME.Value = @"";

                    LBL_DOKTOR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 6, 196, 10, false);
                    LBL_DOKTOR1.Name = "LBL_DOKTOR1";
                    LBL_DOKTOR1.TextFont.Name = "Arial Narrow";
                    LBL_DOKTOR1.TextFont.Size = 8;
                    LBL_DOKTOR1.TextFont.Bold = true;
                    LBL_DOKTOR1.Value = @"Açıklama :";

                    LBL_ADSOYADI14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 6, 147, 10, false);
                    LBL_ADSOYADI14.Name = "LBL_ADSOYADI14";
                    LBL_ADSOYADI14.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI14.TextFont.Size = 8;
                    LBL_ADSOYADI14.TextFont.Bold = true;
                    LBL_ADSOYADI14.Value = @"Sorumlu Doktor :";

                    LBL_ADSOYADI12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 6, 100, 10, false);
                    LBL_ADSOYADI12.Name = "LBL_ADSOYADI12";
                    LBL_ADSOYADI12.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI12.TextFont.Size = 8;
                    LBL_ADSOYADI12.TextFont.Bold = true;
                    LBL_ADSOYADI12.Value = @"Hasta Durumu :";

                    PATIENTSTATUS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 6, 125, 10, false);
                    PATIENTSTATUS.Name = "PATIENTSTATUS";
                    PATIENTSTATUS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTSTATUS.ObjectDefName = "PatientStatusEnum";
                    PATIENTSTATUS.DataMember = "DISPLAYTEXT";
                    PATIENTSTATUS.TextFont.Name = "Arial Narrow";
                    PATIENTSTATUS.TextFont.Size = 8;
                    PATIENTSTATUS.Value = @"";

                    PROCEDUREDOCTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 6, 182, 10, false);
                    PROCEDUREDOCTORNAME.Name = "PROCEDUREDOCTORNAME";
                    PROCEDUREDOCTORNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREDOCTORNAME.TextFont.Name = "Arial Narrow";
                    PROCEDUREDOCTORNAME.TextFont.Size = 8;
                    PROCEDUREDOCTORNAME.Value = @"";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 6, 290, 10, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.TextFont.Name = "Arial Narrow";
                    DESCRIPTION.TextFont.Size = 8;
                    DESCRIPTION.Value = @"";

                    SUBACTIONPROCEDUREOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 346, 2, 389, 6, false);
                    SUBACTIONPROCEDUREOBJECTID.Name = "SUBACTIONPROCEDUREOBJECTID";
                    SUBACTIONPROCEDUREOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    SUBACTIONPROCEDUREOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUBACTIONPROCEDUREOBJECTID.MultiLine = EvetHayirEnum.ehEvet;
                    SUBACTIONPROCEDUREOBJECTID.NoClip = EvetHayirEnum.ehEvet;
                    SUBACTIONPROCEDUREOBJECTID.ExpandTabs = EvetHayirEnum.ehEvet;
                    SUBACTIONPROCEDUREOBJECTID.TextFont.Name = "Arial Narrow";
                    SUBACTIONPROCEDUREOBJECTID.TextFont.Size = 8;
                    SUBACTIONPROCEDUREOBJECTID.Value = @"{#OBJECTID!SubactionProceduresNQL#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 11, 290, 11, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, -1, 8, 11, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 290, -1, 290, 11, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EpisodeAction.GetEpisodeActionsByObjectIDs_Class dataset_EpisodeActionsNQL = ParentGroup.rsGroup.GetCurrentRecord<EpisodeAction.GetEpisodeActionsByObjectIDs_Class>(0);
                    SubactionProcedureFlowable.GetSubactionProceduresByObjectIDs_Class dataset_SubactionProceduresNQL = ParentGroup.rsGroup.GetCurrentRecord<SubactionProcedureFlowable.GetSubactionProceduresByObjectIDs_Class>(1);
                    PATIENTNAME.CalcValue = @"";
                    STATE.CalcValue = @"";
                    PATIENTREFNO.CalcValue = @"";
                    MASTERRESOURCE.CalcValue = @"";
                    ACTIONID.CalcValue = @"";
                    FROMRESOURCE.CalcValue = @"";
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    EPISODEACTIONOBJECTID.CalcValue = (dataset_EpisodeActionsNQL != null ? Globals.ToStringCore(dataset_EpisodeActionsNQL.ObjectID) : "");
                    OBJECTNAME.CalcValue = @"";
                    LBL_DOKTOR1.CalcValue = LBL_DOKTOR1.Value;
                    LBL_ADSOYADI14.CalcValue = LBL_ADSOYADI14.Value;
                    LBL_ADSOYADI12.CalcValue = LBL_ADSOYADI12.Value;
                    PATIENTSTATUS.CalcValue = @"";
                    PATIENTSTATUS.PostFieldValueCalculation();
                    PROCEDUREDOCTORNAME.CalcValue = @"";
                    DESCRIPTION.CalcValue = @"";
                    SUBACTIONPROCEDUREOBJECTID.CalcValue = (dataset_SubactionProceduresNQL != null ? Globals.ToStringCore(dataset_SubactionProceduresNQL.ObjectID) : "");
                    WORKLISTDATE.CalcValue = (Convert.ToString((dataset_EpisodeActionsNQL != null ? Globals.ToStringCore(dataset_EpisodeActionsNQL.WorkListDate) : "")) != "" ? Convert.ToString((dataset_EpisodeActionsNQL != null ? Globals.ToStringCore(dataset_EpisodeActionsNQL.WorkListDate) : "")) : Convert.ToString((dataset_SubactionProceduresNQL != null ? Globals.ToStringCore(dataset_SubactionProceduresNQL.WorkListDate) : "")));
                    return new TTReportObject[] { PATIENTNAME,STATE,PATIENTREFNO,MASTERRESOURCE,ACTIONID,FROMRESOURCE,COUNT,EPISODEACTIONOBJECTID,OBJECTNAME,LBL_DOKTOR1,LBL_ADSOYADI14,LBL_ADSOYADI12,PATIENTSTATUS,PROCEDUREDOCTORNAME,DESCRIPTION,SUBACTIONPROCEDUREOBJECTID,WORKLISTDATE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //                                                                                                                                                                                                
//            TTObjectContext objectContext = new TTObjectContext(true);
//            string episodeActionObjectID = this.EPISODEACTIONOBJECTID.CalcValue;
//            string subActionObjectID = this.SUBACTIONPROCEDUREOBJECTID.CalcValue;
//            
//            EpisodeAction ea = null;
//            SubactionProcedureFlowable spf = null;
//            Episode e = null;
//            string objectName = "";
//            string masterResourceName = "";
//            string stateName = "";
//            string workListDate = "";
//            string actionID = "";
//            string fromResourceName = "";
//            string procedureDoctorName = "";
//            string descForWorkList = "";
//            if(String.IsNullOrEmpty(episodeActionObjectID) == false)
//            {
//                ea = (EpisodeAction)objectContext.GetObject(new Guid(episodeActionObjectID),"EpisodeAction");
//                e = ea.Episode;    
//                objectName = (ea.ObjectDef.ApplicationName != null ? ea.ObjectDef.ApplicationName : ea.ObjectDef.DisplayText);
//                masterResourceName = (ea.MasterResource != null ? ea.MasterResource.Name : "");
//                stateName = ea.CurrentStateDef.DisplayText;
//                workListDate = (ea.WorkListDate != null ? (ea.WorkListDate.Equals(new DateTime(1800,1,1)) == true ? ea.ActionDate.ToString() : ea.WorkListDate.ToString()) : "");
//                actionID = (ea.ID != null ? ea.ID.ToString() : "");
//                fromResourceName = (ea.FromResource != null ? ea.FromResource.Name : "");
//                procedureDoctorName = (ea.ProcedureDoctor != null ? ea.ProcedureDoctor.Name : "");
//                descForWorkList = ea.DescriptionForWorkList;
//            }
//            else if (String.IsNullOrEmpty(subActionObjectID) == false)
//            {
//                spf = (SubactionProcedureFlowable)objectContext.GetObject(new Guid(subActionObjectID),"SubactionProcedureFlowable");
//                e = spf.Episode;
//                objectName = (spf.ObjectDef.ApplicationName != null ? spf.ObjectDef.ApplicationName : spf.ObjectDef.DisplayText);
//                masterResourceName = (spf.MasterResource != null ? spf.MasterResource.Name : "");
//                stateName = spf.CurrentStateDef.DisplayText;
//                workListDate = (spf.WorkListDate != null ? (spf.WorkListDate.Equals(new DateTime(1800,1,1)) == true ? spf.ActionDate.ToString() : spf.WorkListDate.ToString()) : "");
//                actionID = (spf.ID != null ? spf.ID.ToString() : "");
//                fromResourceName = (spf.FromResource != null ? spf.FromResource.Name : "");
//                procedureDoctorName = (spf.ProcedureDoctor != null ? spf.ProcedureDoctor.Name : "");
//                descForWorkList = spf.DescriptionForWorkList;
//            }
//            this.OBJECTNAME.CalcValue = objectName;
//            this.MASTERRESOURCE.CalcValue = masterResourceName;
//            this.STATE.CalcValue = stateName;
//            this.WORKLISTDATE.CalcValue = workListDate;
//            this.ACTIONID.CalcValue = actionID;
//            this.FROMRESOURCE.CalcValue = fromResourceName;
//            this.PROCEDUREDOCTORNAME.CalcValue = procedureDoctorName;
//            this.DESCRIPTION.CalcValue = descForWorkList;
//            this.PATIENTREFNO.CalcValue = (e.Patient.UniqueRefNo != null ? e.Patient.UniqueRefNo.ToString() : (e.Patient.ForeignUniqueRefNo != null ? "(*)" + e.Patient.ForeignUniqueRefNo.ToString() : ""));
//            this.PATIENTNAME.CalcValue = e.Patient.Name + " " + e.Patient.Surname;
//            this.PATIENTGROUP.CalcValue = (e.PatientGroup != null ? TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum("PatientGroupEnum",e.PatientGroup.GetHashCode()) : "") ;
//            this.PATIENTSTATUS.CalcValue = (e.PatientStatus != null ? TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum("PatientStatusEnum",e.PatientStatus.GetHashCode()) : "") ;
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public EpisodeActionWLReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("OBJECTIDS", "", "OBJECTIDS", @"", true, true, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("OBJECTIDS"))
                _runtimeParameters.OBJECTIDS = (List<string>)parameters["OBJECTIDS"];
            Name = "EPISODEACTIONWLREPORT";
            Caption = "Hasta İş Listesi Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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