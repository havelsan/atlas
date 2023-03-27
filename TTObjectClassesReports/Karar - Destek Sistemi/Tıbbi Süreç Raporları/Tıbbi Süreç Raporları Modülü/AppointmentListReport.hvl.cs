
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
    /// Randevu Listesi
    /// </summary>
    public partial class AppointmentListReport : TTReport
    {
#region Methods
   public int appointmentCount =  0;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public List<string> OBJECTIDS = new List<string>();
            public string CRITERIA = (string)TTObjectDefManager.Instance.DataTypes["String500"].ConvertValue("");
            public bool? SHOWNOTE = (bool?)TTObjectDefManager.Instance.DataTypes["Boolean"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public AppointmentListReport MyParentReport
            {
                get { return (AppointmentListReport)ParentReport; }
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
            public TTReportField LBL_DOKTOR { get {return Header().LBL_DOKTOR;} }
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
            public TTReportField Hasta_Kimlik_No { get {return Header().Hasta_Kimlik_No;} }
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
                public AppointmentListReport MyParentReport
                {
                    get { return (AppointmentListReport)ParentReport; }
                }
                
                public TTReportField LBL_SAAT;
                public TTReportField LBL_CINSI;
                public TTReportField LBL_ADSOYADI;
                public TTReportField LBL_TARIH;
                public TTReportField LBL_DOKTOR;
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
                public TTReportField Hasta_Kimlik_No; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 51;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    LBL_SAAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 44, 50, 48, false);
                    LBL_SAAT.Name = "LBL_SAAT";
                    LBL_SAAT.TextFont.Name = "Arial Narrow";
                    LBL_SAAT.TextFont.Size = 8;
                    LBL_SAAT.TextFont.Bold = true;
                    LBL_SAAT.Value = @"Saati";

                    LBL_CINSI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 44, 103, 48, false);
                    LBL_CINSI.Name = "LBL_CINSI";
                    LBL_CINSI.TextFont.Name = "Arial Narrow";
                    LBL_CINSI.TextFont.Size = 8;
                    LBL_CINSI.TextFont.Bold = true;
                    LBL_CINSI.Value = @"Cinsi";

                    LBL_ADSOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 44, 162, 48, false);
                    LBL_ADSOYADI.Name = "LBL_ADSOYADI";
                    LBL_ADSOYADI.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI.TextFont.Size = 8;
                    LBL_ADSOYADI.TextFont.Bold = true;
                    LBL_ADSOYADI.Value = @"Hasta Adı Soyadı";

                    LBL_TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 44, 30, 48, false);
                    LBL_TARIH.Name = "LBL_TARIH";
                    LBL_TARIH.TextFont.Name = "Arial Narrow";
                    LBL_TARIH.TextFont.Size = 8;
                    LBL_TARIH.TextFont.Bold = true;
                    LBL_TARIH.Value = @"Tarih";

                    LBL_DOKTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 44, 241, 48, false);
                    LBL_DOKTOR.Name = "LBL_DOKTOR";
                    LBL_DOKTOR.TextFont.Name = "Arial Narrow";
                    LBL_DOKTOR.TextFont.Size = 8;
                    LBL_DOKTOR.TextFont.Bold = true;
                    LBL_DOKTOR.Value = @"Kaynak";

                    LBL_DURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 243, 44, 256, 48, false);
                    LBL_DURUMU.Name = "LBL_DURUMU";
                    LBL_DURUMU.TextFont.Name = "Arial Narrow";
                    LBL_DURUMU.TextFont.Size = 8;
                    LBL_DURUMU.TextFont.Bold = true;
                    LBL_DURUMU.Value = @"Durumu";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 50, 290, 50, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewLine1.DrawWidth = 2;

                    KRITER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 29, 290, 42, false);
                    KRITER.Name = "KRITER";
                    KRITER.FieldType = ReportFieldTypeEnum.ftVariable;
                    KRITER.MultiLine = EvetHayirEnum.ehEvet;
                    KRITER.NoClip = EvetHayirEnum.ehEvet;
                    KRITER.WordBreak = EvetHayirEnum.ehEvet;
                    KRITER.ExpandTabs = EvetHayirEnum.ehEvet;
                    KRITER.TextFont.Name = "Arial Narrow";
                    KRITER.TextFont.Size = 8;
                    KRITER.Value = @"{@CRITERIA@}";

                    LABELK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 44, 88, 48, false);
                    LABELK.Name = "LABELK";
                    LABELK.TextFont.Name = "Arial Narrow";
                    LABELK.TextFont.Size = 8;
                    LABELK.TextFont.Bold = true;
                    LABELK.Value = @"Kategori";

                    TARIHK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 29, 30, 33, false);
                    TARIHK.Name = "TARIHK";
                    TARIHK.TextFont.Name = "Arial Narrow";
                    TARIHK.TextFont.Size = 8;
                    TARIHK.TextFont.Bold = true;
                    TARIHK.Value = @"Kriter";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 29, 35, 33, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Name = "Arial Narrow";
                    NewField18.TextFont.Size = 8;
                    NewField18.Value = @":";

                    LBL_NOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 44, 290, 48, false);
                    LBL_NOT.Name = "LBL_NOT";
                    LBL_NOT.TextFont.Name = "Arial Narrow";
                    LBL_NOT.TextFont.Size = 8;
                    LBL_NOT.TextFont.Bold = true;
                    LBL_NOT.Value = @"Notlar";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 8, 223, 22, false);
                    NewField.Name = "NewField";
                    NewField.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField.DrawWidth = 2;
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField.TextFont.Name = "Arial Narrow";
                    NewField.TextFont.Size = 14;
                    NewField.TextFont.Bold = true;
                    NewField.Value = @"Randevu Listesi";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 8, 54, 19, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.Value = @"";

                    LBL_TARIH2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 44, 16, 48, false);
                    LBL_TARIH2.Name = "LBL_TARIH2";
                    LBL_TARIH2.TextFont.Name = "Arial Narrow";
                    LBL_TARIH2.TextFont.Size = 8;
                    LBL_TARIH2.TextFont.Bold = true;
                    LBL_TARIH2.Value = @"Sıra";

                    Hasta_Kimlik_No = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 44, 123, 48, false);
                    Hasta_Kimlik_No.Name = "Hasta_Kimlik_No";
                    Hasta_Kimlik_No.TextFont.Name = "Arial Narrow";
                    Hasta_Kimlik_No.TextFont.Size = 8;
                    Hasta_Kimlik_No.TextFont.Bold = true;
                    Hasta_Kimlik_No.Value = @"Kimlik No";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LBL_SAAT.CalcValue = LBL_SAAT.Value;
                    LBL_CINSI.CalcValue = LBL_CINSI.Value;
                    LBL_ADSOYADI.CalcValue = LBL_ADSOYADI.Value;
                    LBL_TARIH.CalcValue = LBL_TARIH.Value;
                    LBL_DOKTOR.CalcValue = LBL_DOKTOR.Value;
                    LBL_DURUMU.CalcValue = LBL_DURUMU.Value;
                    KRITER.CalcValue = MyParentReport.RuntimeParameters.CRITERIA.ToString();
                    LABELK.CalcValue = LABELK.Value;
                    TARIHK.CalcValue = TARIHK.Value;
                    NewField18.CalcValue = NewField18.Value;
                    LBL_NOT.CalcValue = LBL_NOT.Value;
                    NewField.CalcValue = NewField.Value;
                    LOGO.CalcValue = @"";
                    LBL_TARIH2.CalcValue = LBL_TARIH2.Value;
                    Hasta_Kimlik_No.CalcValue = Hasta_Kimlik_No.Value;
                    return new TTReportObject[] { LBL_SAAT,LBL_CINSI,LBL_ADSOYADI,LBL_TARIH,LBL_DOKTOR,LBL_DURUMU,KRITER,LABELK,TARIHK,NewField18,LBL_NOT,NewField,LOGO,LBL_TARIH2,Hasta_Kimlik_No};
                }
                public override void RunPreScript()
                {
#region HEADER HEADER_PreScript
                    //
            //If RepS.Fields("DOKTORG").Value = "" Then
            //   RepS.Fields("LABELDOKTOR").Visible = False
            //   RepS.Fields("LBLDKTR").Visible     = False
            //   RepS.Fields("LBL_DOKTOR").Value    = "Bölüm"
            //End If
#endregion HEADER HEADER_PreScript
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    //                   #Include <RAPOR_USTBASLIK>
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public AppointmentListReport MyParentReport
                {
                    get { return (AppointmentListReport)ParentReport; }
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
            public AppointmentListReport MyParentReport
            {
                get { return (AppointmentListReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SAAT { get {return Body().SAAT;} }
            public TTReportField CINSI { get {return Body().CINSI;} }
            public TTReportField ADISOYADI { get {return Body().ADISOYADI;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField KAYNAK { get {return Body().KAYNAK;} }
            public TTReportField DURUMU { get {return Body().DURUMU;} }
            public TTReportField NOT { get {return Body().NOT;} }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField KATEGORI { get {return Body().KATEGORI;} }
            public TTReportField KIMLIKNO { get {return Body().KIMLIKNO;} }
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
                list[0] = new TTReportNqlData<Appointment.GetAppointmentListReportNQL_Class>("GetAppointmentListReportNQL", Appointment.GetAppointmentListReportNQL((List<string>) MyParentReport.RuntimeParameters.OBJECTIDS));
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
                public AppointmentListReport MyParentReport
                {
                    get { return (AppointmentListReport)ParentReport; }
                }
                
                public TTReportField SAAT;
                public TTReportField CINSI;
                public TTReportField ADISOYADI;
                public TTReportField TARIH;
                public TTReportField KAYNAK;
                public TTReportField DURUMU;
                public TTReportField NOT;
                public TTReportField COUNT;
                public TTReportField OBJECTID;
                public TTReportField KATEGORI;
                public TTReportField KIMLIKNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    AutoSizeGap = 1;
                    RepeatCount = 0;
                    
                    SAAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 0, 50, 4, false);
                    SAAT.Name = "SAAT";
                    SAAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAAT.MultiLine = EvetHayirEnum.ehEvet;
                    SAAT.NoClip = EvetHayirEnum.ehEvet;
                    SAAT.ExpandTabs = EvetHayirEnum.ehEvet;
                    SAAT.TextFont.Name = "Arial Narrow";
                    SAAT.TextFont.Size = 8;
                    SAAT.Value = @"";

                    CINSI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 0, 103, 4, false);
                    CINSI.Name = "CINSI";
                    CINSI.FieldType = ReportFieldTypeEnum.ftVariable;
                    CINSI.CaseFormat = CaseFormatEnum.fcTitleCase;
                    CINSI.MultiLine = EvetHayirEnum.ehEvet;
                    CINSI.NoClip = EvetHayirEnum.ehEvet;
                    CINSI.ExpandTabs = EvetHayirEnum.ehEvet;
                    CINSI.ObjectDefName = "AppointmentTypeEnum";
                    CINSI.DataMember = "DISPLAYTEXT";
                    CINSI.TextFont.Name = "Arial Narrow";
                    CINSI.TextFont.Size = 8;
                    CINSI.Value = @"{#APPOINTMENTTYPE#}";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 0, 162, 4, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.MultiLine = EvetHayirEnum.ehEvet;
                    ADISOYADI.NoClip = EvetHayirEnum.ehEvet;
                    ADISOYADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADISOYADI.TextFont.Name = "Arial Narrow";
                    ADISOYADI.TextFont.Size = 8;
                    ADISOYADI.Value = @"";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 30, 4, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"Short Date";
                    TARIH.MultiLine = EvetHayirEnum.ehEvet;
                    TARIH.NoClip = EvetHayirEnum.ehEvet;
                    TARIH.ExpandTabs = EvetHayirEnum.ehEvet;
                    TARIH.TextFont.Name = "Arial Narrow";
                    TARIH.TextFont.Size = 8;
                    TARIH.Value = @"{#APPDATE#}";

                    KAYNAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 0, 241, 4, false);
                    KAYNAK.Name = "KAYNAK";
                    KAYNAK.FieldType = ReportFieldTypeEnum.ftVariable;
                    KAYNAK.CaseFormat = CaseFormatEnum.fcTitleCase;
                    KAYNAK.MultiLine = EvetHayirEnum.ehEvet;
                    KAYNAK.NoClip = EvetHayirEnum.ehEvet;
                    KAYNAK.ExpandTabs = EvetHayirEnum.ehEvet;
                    KAYNAK.TextFont.Name = "Arial Narrow";
                    KAYNAK.TextFont.Size = 8;
                    KAYNAK.Value = @"";

                    DURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 243, 0, 256, 4, false);
                    DURUMU.Name = "DURUMU";
                    DURUMU.FieldType = ReportFieldTypeEnum.ftVariable;
                    DURUMU.MultiLine = EvetHayirEnum.ehEvet;
                    DURUMU.NoClip = EvetHayirEnum.ehEvet;
                    DURUMU.ExpandTabs = EvetHayirEnum.ehEvet;
                    DURUMU.TextFont.Name = "Arial Narrow";
                    DURUMU.TextFont.Size = 8;
                    DURUMU.Value = @"";

                    NOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 0, 290, 4, false);
                    NOT.Name = "NOT";
                    NOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOT.MultiLine = EvetHayirEnum.ehEvet;
                    NOT.NoClip = EvetHayirEnum.ehEvet;
                    NOT.WordBreak = EvetHayirEnum.ehEvet;
                    NOT.ExpandTabs = EvetHayirEnum.ehEvet;
                    NOT.TextFont.Name = "Arial Narrow";
                    NOT.TextFont.Size = 8;
                    NOT.Value = @"";

                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 15, 4, false);
                    COUNT.Name = "COUNT";
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.MultiLine = EvetHayirEnum.ehEvet;
                    COUNT.NoClip = EvetHayirEnum.ehEvet;
                    COUNT.ExpandTabs = EvetHayirEnum.ehEvet;
                    COUNT.TextFont.Name = "Arial Narrow";
                    COUNT.TextFont.Size = 8;
                    COUNT.Value = @"{@counter@}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 311, 1, 331, 5, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.MultiLine = EvetHayirEnum.ehEvet;
                    OBJECTID.NoClip = EvetHayirEnum.ehEvet;
                    OBJECTID.ExpandTabs = EvetHayirEnum.ehEvet;
                    OBJECTID.TextFont.Name = "Arial Narrow";
                    OBJECTID.TextFont.Size = 8;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    KATEGORI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 0, 88, 4, false);
                    KATEGORI.Name = "KATEGORI";
                    KATEGORI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KATEGORI.NoClip = EvetHayirEnum.ehEvet;
                    KATEGORI.TextFont.Name = "Arial Narrow";
                    KATEGORI.TextFont.Size = 8;
                    KATEGORI.Value = @"";

                    KIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 0, 123, 4, false);
                    KIMLIKNO.Name = "KIMLIKNO";
                    KIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    KIMLIKNO.NoClip = EvetHayirEnum.ehEvet;
                    KIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    KIMLIKNO.TextFont.Name = "Arial Narrow";
                    KIMLIKNO.TextFont.CharSet = 1;
                    KIMLIKNO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Appointment.GetAppointmentListReportNQL_Class dataset_GetAppointmentListReportNQL = ParentGroup.rsGroup.GetCurrentRecord<Appointment.GetAppointmentListReportNQL_Class>(0);
                    SAAT.CalcValue = @"";
                    CINSI.CalcValue = (dataset_GetAppointmentListReportNQL != null ? Globals.ToStringCore(dataset_GetAppointmentListReportNQL.AppointmentType) : "");
                    CINSI.PostFieldValueCalculation();
                    ADISOYADI.CalcValue = @"";
                    TARIH.CalcValue = (dataset_GetAppointmentListReportNQL != null ? Globals.ToStringCore(dataset_GetAppointmentListReportNQL.AppDate) : "");
                    KAYNAK.CalcValue = @"";
                    DURUMU.CalcValue = @"";
                    NOT.CalcValue = @"";
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    OBJECTID.CalcValue = (dataset_GetAppointmentListReportNQL != null ? Globals.ToStringCore(dataset_GetAppointmentListReportNQL.ObjectID) : "");
                    KATEGORI.CalcValue = @"";
                    KIMLIKNO.CalcValue = @"";
                    return new TTReportObject[] { SAAT,CINSI,ADISOYADI,TARIH,KAYNAK,DURUMU,NOT,COUNT,OBJECTID,KATEGORI,KIMLIKNO};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    //                        #Include <REPORT_FILLFIELDS>
//
            //'Set Pg = RepG.ParentGroup
            //Set Pg = RepT.GROUPS("MAIN")
            //Sayi = 0
            //P = InStr(1,Pg.fields("TARIH").calcvalue,vbcrlf)
//
            //While P <> 0
            //   Sayi = Sayi + 1
            //   P = InStr(P+1,Pg.Fields("TARIH").Value,vbcrlf)
            //Wend
//
            //Pg.Fields("COUNT").Value = ""
            //For i = 1 To Sayi
            //   Pg.Fields("COUNT").Value = Pg.Fields("COUNT").Value + CStr(i) + VbCrlf
            //Next
//
            //'h.GlbScriptProperties.Add "COUNT", "1" + vbcrlf + "2" + vbcrlf + "3"

            if(((AppointmentListReport)ParentReport).RuntimeParameters.SHOWNOTE != null)
            {
                bool showNote = Convert.ToBoolean(((AppointmentListReport)ParentReport).RuntimeParameters.SHOWNOTE);
                if(!showNote)
                    NOT.Visible = TTReportTool.EvetHayirEnum.ehHayir;
            }
#endregion MAIN BODY_PreScript
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = this.OBJECTID.CalcValue;
            Appointment app = (Appointment)objectContext.GetObject(new Guid(objectID),"Appointment");
            
            if(app.BreakAppointment== true)
                this.SAAT.CalcValue = "Saatsiz randevu";
            else
                this.SAAT.CalcValue = app.StartTime.Value.ToShortTimeString() + "-" + app.EndTime.Value.ToShortTimeString();
            
            if(app.Patient != null)
                this.ADISOYADI.CalcValue = app.Patient.FullName;
            else
            {
                if(app.Action!= null && app.Action is AdmissionAppointment)
                    this.ADISOYADI.CalcValue = ((AdmissionAppointment)app.Action).PatientName + " " + ((AdmissionAppointment)app.Action).PatientSurname;
            }
            
            if(app.MasterResource == null)
                this.KAYNAK.CalcValue = (app.Resource != null ? app.Resource.Name : String.Empty);
            else
                this.KAYNAK.CalcValue = (app.Resource != null ? app.Resource.Name + " - " : String.Empty) + app.MasterResource.Name;
            
            if(app.AppointmentDefinition != null)
            {
                this.KATEGORI.CalcValue = app.AppointmentDefinition.AppointmentDefinitionNameDisplayText;
                
                //                if(app.AppointmentDefinition.GiveToMaster == true)
                //                   this.KAYNAK.CalcValue = app.Resource.Name;
                //                else
                //                    this.KAYNAK.CalcValue = app.Resource.Name + " - " + app.MasterResource.Name;
            }
            
            this.DURUMU.CalcValue = app.CurrentStateDef.DisplayText;
            
            
            if(app.Patient != null && app.Patient.UniqueRefNo != null)
                this.KIMLIKNO.CalcValue = app.Patient.UniqueRefNo.ToString();
                    
            if (app.SubActionProcedure != null && app.SubActionProcedure.ProcedureObject != null)
                this.NOT.CalcValue = "İşlem:" + app.SubActionProcedure.ProcedureObject.Name + " Not: " + app.Notes;
            else
                this.NOT.CalcValue = app.Notes;
            
            this.MyParentReport.appointmentCount = Convert.ToInt32(this.COUNT.CalcValue);
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class BREAKAPPOINTMENTGroup : TTReportGroup
        {
            public AppointmentListReport MyParentReport
            {
                get { return (AppointmentListReport)ParentReport; }
            }

            new public BREAKAPPOINTMENTGroupBody Body()
            {
                return (BREAKAPPOINTMENTGroupBody)_body;
            }
            public TTReportField SAAT1 { get {return Body().SAAT1;} }
            public TTReportField CINSI1 { get {return Body().CINSI1;} }
            public TTReportField ADISOYADI1 { get {return Body().ADISOYADI1;} }
            public TTReportField TARIH1 { get {return Body().TARIH1;} }
            public TTReportField KAYNAK1 { get {return Body().KAYNAK1;} }
            public TTReportField DURUMU1 { get {return Body().DURUMU1;} }
            public TTReportField NOT1 { get {return Body().NOT1;} }
            public TTReportField COUNT1 { get {return Body().COUNT1;} }
            public TTReportField OBJECTID1 { get {return Body().OBJECTID1;} }
            public TTReportField KATEGORI1 { get {return Body().KATEGORI1;} }
            public TTReportField KIMLIKNO1 { get {return Body().KIMLIKNO1;} }
            public BREAKAPPOINTMENTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public BREAKAPPOINTMENTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Appointment.GetBreakAppointmentListReportNQL_Class>("GetBreakAppointmentListReportNQL", Appointment.GetBreakAppointmentListReportNQL((List<string>) MyParentReport.RuntimeParameters.OBJECTIDS));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new BREAKAPPOINTMENTGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class BREAKAPPOINTMENTGroupBody : TTReportSection
            {
                public AppointmentListReport MyParentReport
                {
                    get { return (AppointmentListReport)ParentReport; }
                }
                
                public TTReportField SAAT1;
                public TTReportField CINSI1;
                public TTReportField ADISOYADI1;
                public TTReportField TARIH1;
                public TTReportField KAYNAK1;
                public TTReportField DURUMU1;
                public TTReportField NOT1;
                public TTReportField COUNT1;
                public TTReportField OBJECTID1;
                public TTReportField KATEGORI1;
                public TTReportField KIMLIKNO1; 
                public BREAKAPPOINTMENTGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    RepeatCount = 0;
                    
                    SAAT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 0, 50, 4, false);
                    SAAT1.Name = "SAAT1";
                    SAAT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAAT1.MultiLine = EvetHayirEnum.ehEvet;
                    SAAT1.NoClip = EvetHayirEnum.ehEvet;
                    SAAT1.ExpandTabs = EvetHayirEnum.ehEvet;
                    SAAT1.TextFont.Name = "Arial Narrow";
                    SAAT1.TextFont.Size = 8;
                    SAAT1.Value = @"";

                    CINSI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 0, 103, 4, false);
                    CINSI1.Name = "CINSI1";
                    CINSI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    CINSI1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    CINSI1.MultiLine = EvetHayirEnum.ehEvet;
                    CINSI1.NoClip = EvetHayirEnum.ehEvet;
                    CINSI1.ExpandTabs = EvetHayirEnum.ehEvet;
                    CINSI1.ObjectDefName = "AppointmentTypeEnum";
                    CINSI1.DataMember = "DISPLAYTEXT";
                    CINSI1.TextFont.Name = "Arial Narrow";
                    CINSI1.TextFont.Size = 8;
                    CINSI1.Value = @"{#APPOINTMENTTYPE#}";

                    ADISOYADI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 0, 162, 4, false);
                    ADISOYADI1.Name = "ADISOYADI1";
                    ADISOYADI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI1.MultiLine = EvetHayirEnum.ehEvet;
                    ADISOYADI1.NoClip = EvetHayirEnum.ehEvet;
                    ADISOYADI1.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADISOYADI1.TextFont.Name = "Arial Narrow";
                    ADISOYADI1.TextFont.Size = 8;
                    ADISOYADI1.Value = @"";

                    TARIH1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 30, 4, false);
                    TARIH1.Name = "TARIH1";
                    TARIH1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH1.TextFormat = @"Short Date";
                    TARIH1.MultiLine = EvetHayirEnum.ehEvet;
                    TARIH1.NoClip = EvetHayirEnum.ehEvet;
                    TARIH1.ExpandTabs = EvetHayirEnum.ehEvet;
                    TARIH1.TextFont.Name = "Arial Narrow";
                    TARIH1.TextFont.Size = 8;
                    TARIH1.Value = @"{#APPDATE#}";

                    KAYNAK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 0, 241, 4, false);
                    KAYNAK1.Name = "KAYNAK1";
                    KAYNAK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    KAYNAK1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    KAYNAK1.MultiLine = EvetHayirEnum.ehEvet;
                    KAYNAK1.NoClip = EvetHayirEnum.ehEvet;
                    KAYNAK1.ExpandTabs = EvetHayirEnum.ehEvet;
                    KAYNAK1.TextFont.Name = "Arial Narrow";
                    KAYNAK1.TextFont.Size = 8;
                    KAYNAK1.Value = @"";

                    DURUMU1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 243, 0, 256, 4, false);
                    DURUMU1.Name = "DURUMU1";
                    DURUMU1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DURUMU1.MultiLine = EvetHayirEnum.ehEvet;
                    DURUMU1.NoClip = EvetHayirEnum.ehEvet;
                    DURUMU1.ExpandTabs = EvetHayirEnum.ehEvet;
                    DURUMU1.TextFont.Name = "Arial Narrow";
                    DURUMU1.TextFont.Size = 8;
                    DURUMU1.Value = @"";

                    NOT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 258, 0, 290, 4, false);
                    NOT1.Name = "NOT1";
                    NOT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOT1.MultiLine = EvetHayirEnum.ehEvet;
                    NOT1.NoClip = EvetHayirEnum.ehEvet;
                    NOT1.WordBreak = EvetHayirEnum.ehEvet;
                    NOT1.ExpandTabs = EvetHayirEnum.ehEvet;
                    NOT1.TextFont.Name = "Arial Narrow";
                    NOT1.TextFont.Size = 8;
                    NOT1.Value = @"";

                    COUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 0, 15, 4, false);
                    COUNT1.Name = "COUNT1";
                    COUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT1.MultiLine = EvetHayirEnum.ehEvet;
                    COUNT1.NoClip = EvetHayirEnum.ehEvet;
                    COUNT1.ExpandTabs = EvetHayirEnum.ehEvet;
                    COUNT1.TextFont.Name = "Arial Narrow";
                    COUNT1.TextFont.Size = 8;
                    COUNT1.Value = @"";

                    OBJECTID1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 311, 1, 331, 5, false);
                    OBJECTID1.Name = "OBJECTID1";
                    OBJECTID1.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID1.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID1.MultiLine = EvetHayirEnum.ehEvet;
                    OBJECTID1.NoClip = EvetHayirEnum.ehEvet;
                    OBJECTID1.ExpandTabs = EvetHayirEnum.ehEvet;
                    OBJECTID1.TextFont.Name = "Arial Narrow";
                    OBJECTID1.TextFont.Size = 8;
                    OBJECTID1.Value = @"{#OBJECTID#}";

                    KATEGORI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 0, 88, 4, false);
                    KATEGORI1.Name = "KATEGORI1";
                    KATEGORI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    KATEGORI1.NoClip = EvetHayirEnum.ehEvet;
                    KATEGORI1.TextFont.Name = "Arial Narrow";
                    KATEGORI1.TextFont.Size = 8;
                    KATEGORI1.Value = @"";

                    KIMLIKNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 0, 123, 4, false);
                    KIMLIKNO1.Name = "KIMLIKNO1";
                    KIMLIKNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIMLIKNO1.MultiLine = EvetHayirEnum.ehEvet;
                    KIMLIKNO1.NoClip = EvetHayirEnum.ehEvet;
                    KIMLIKNO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    KIMLIKNO1.TextFont.Name = "Arial Narrow";
                    KIMLIKNO1.TextFont.CharSet = 1;
                    KIMLIKNO1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Appointment.GetBreakAppointmentListReportNQL_Class dataset_GetBreakAppointmentListReportNQL = ParentGroup.rsGroup.GetCurrentRecord<Appointment.GetBreakAppointmentListReportNQL_Class>(0);
                    SAAT1.CalcValue = @"";
                    CINSI1.CalcValue = (dataset_GetBreakAppointmentListReportNQL != null ? Globals.ToStringCore(dataset_GetBreakAppointmentListReportNQL.AppointmentType) : "");
                    CINSI1.PostFieldValueCalculation();
                    ADISOYADI1.CalcValue = @"";
                    TARIH1.CalcValue = (dataset_GetBreakAppointmentListReportNQL != null ? Globals.ToStringCore(dataset_GetBreakAppointmentListReportNQL.AppDate) : "");
                    KAYNAK1.CalcValue = @"";
                    DURUMU1.CalcValue = @"";
                    NOT1.CalcValue = @"";
                    COUNT1.CalcValue = @"";
                    OBJECTID1.CalcValue = (dataset_GetBreakAppointmentListReportNQL != null ? Globals.ToStringCore(dataset_GetBreakAppointmentListReportNQL.ObjectID) : "");
                    KATEGORI1.CalcValue = @"";
                    KIMLIKNO1.CalcValue = @"";
                    return new TTReportObject[] { SAAT1,CINSI1,ADISOYADI1,TARIH1,KAYNAK1,DURUMU1,NOT1,COUNT1,OBJECTID1,KATEGORI1,KIMLIKNO1};
                }
                public override void RunPreScript()
                {
#region BREAKAPPOINTMENT BODY_PreScript
                    if(((AppointmentListReport)ParentReport).RuntimeParameters.SHOWNOTE != null)
            {
                bool showNote = Convert.ToBoolean(((AppointmentListReport)ParentReport).RuntimeParameters.SHOWNOTE);
                if(!showNote)
                    NOT1.Visible = TTReportTool.EvetHayirEnum.ehHayir;
            }
#endregion BREAKAPPOINTMENT BODY_PreScript
                }

                public override void RunScript()
                {
#region BREAKAPPOINTMENT BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = this.OBJECTID1.CalcValue;
            Appointment app = (Appointment)objectContext.GetObject(new Guid(objectID),"Appointment");
            
            if(app.BreakAppointment== true)
                this.SAAT1.CalcValue = "Saatsiz randevu";
            else
                this.SAAT1.CalcValue = app.StartTime.Value.ToShortTimeString() + "-" + app.EndTime.Value.ToShortTimeString();
            
            if(app.Patient != null)
                this.ADISOYADI1.CalcValue = app.Patient.FullName;
            else
            {
                if(app.Action!= null && app.Action is AdmissionAppointment)
                    this.ADISOYADI1.CalcValue = ((AdmissionAppointment)app.Action).PatientName + " " + ((AdmissionAppointment)app.Action).PatientSurname;
            }
            
            if(app.MasterResource == null)
                this.KAYNAK1.CalcValue = (app.Resource != null ? app.Resource.Name : String.Empty);
            else
                this.KAYNAK1.CalcValue = (app.Resource != null ? app.Resource.Name + " - " : String.Empty) + app.MasterResource.Name;
            
            if(app.AppointmentDefinition != null)
            {
                this.KATEGORI1.CalcValue = app.AppointmentDefinition.AppointmentDefinitionNameDisplayText;
                
//                if(app.AppointmentDefinition.GiveToMaster == true)
//                    this.KAYNAK.CalcValue = app.Resource.Name;
//                else
//                    this.KAYNAK.CalcValue = app.Resource.Name + " - " + app.MasterResource.Name;
            }
            
            this.DURUMU1.CalcValue = app.CurrentStateDef.DisplayText;
            
            
              if(app.Patient != null && app.Patient.UniqueRefNo != null)
                this.KIMLIKNO1.CalcValue = app.Patient.UniqueRefNo.ToString();
              
            if (app.SubActionProcedure != null && app.SubActionProcedure.ProcedureObject != null)
                this.NOT1.CalcValue = "İşlem:" + app.SubActionProcedure.ProcedureObject.Name + " Not: " + app.Notes;
            else
                this.NOT1.CalcValue = app.Notes;
            
            this.MyParentReport.appointmentCount++;
            this.COUNT1.CalcValue = this.MyParentReport.appointmentCount.ToString();
#endregion BREAKAPPOINTMENT BODY_Script
                }
            }

        }

        public BREAKAPPOINTMENTGroup BREAKAPPOINTMENT;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public AppointmentListReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            BREAKAPPOINTMENT = new BREAKAPPOINTMENTGroup(HEADER,"BREAKAPPOINTMENT");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("OBJECTIDS", "", "OBJECTIDS", @"", true, true, true, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("CRITERIA", "", "Kriter", @"", false, true, false, new Guid("4bf2cf68-3f04-49cf-b114-a88d422704bb"));
            reportParameter = Parameters.Add("SHOWNOTE", "", "Notu Göster", @"", false, false, false, new Guid("87fa0907-eeb7-43e0-b870-8690afc73bc3"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("OBJECTIDS"))
                _runtimeParameters.OBJECTIDS = (List<string>)parameters["OBJECTIDS"];
            if (parameters.ContainsKey("CRITERIA"))
                _runtimeParameters.CRITERIA = (string)TTObjectDefManager.Instance.DataTypes["String500"].ConvertValue(parameters["CRITERIA"]);
            if (parameters.ContainsKey("SHOWNOTE"))
                _runtimeParameters.SHOWNOTE = (bool?)TTObjectDefManager.Instance.DataTypes["Boolean"].ConvertValue(parameters["SHOWNOTE"]);
            Name = "APPOINTMENTLISTREPORT";
            Caption = "Randevu Listesi";
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