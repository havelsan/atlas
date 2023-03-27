
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
    /// Randevu Listesi(Kaynak ve Hasta Bazlı)
    /// </summary>
    public partial class AppointmentListByResourceAndPatient : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? MasterResource = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? Resource = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? Patient = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public DateTime? StartDate = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? EndDate = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public AppointmentListByResourceAndPatient MyParentReport
            {
                get { return (AppointmentListByResourceAndPatient)ParentReport; }
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
            public TTReportField LABELK { get {return Header().LABELK;} }
            public TTReportField LBL_NOT { get {return Header().LBL_NOT;} }
            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
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
                public AppointmentListByResourceAndPatient MyParentReport
                {
                    get { return (AppointmentListByResourceAndPatient)ParentReport; }
                }
                
                public TTReportField LBL_SAAT;
                public TTReportField LBL_CINSI;
                public TTReportField LBL_ADSOYADI;
                public TTReportField LBL_TARIH;
                public TTReportField LBL_DOKTOR;
                public TTReportField LBL_DURUMU;
                public TTReportShape NewLine1;
                public TTReportField LABELK;
                public TTReportField LBL_NOT;
                public TTReportField NewField;
                public TTReportField LOGO;
                public TTReportField Hasta_Kimlik_No; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 39;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    LBL_SAAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 32, 45, 36, false);
                    LBL_SAAT.Name = "LBL_SAAT";
                    LBL_SAAT.TextFont.Name = "Arial Narrow";
                    LBL_SAAT.TextFont.Size = 8;
                    LBL_SAAT.TextFont.Bold = true;
                    LBL_SAAT.Value = @"Saati";

                    LBL_CINSI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 32, 92, 36, false);
                    LBL_CINSI.Name = "LBL_CINSI";
                    LBL_CINSI.TextFont.Name = "Arial Narrow";
                    LBL_CINSI.TextFont.Size = 8;
                    LBL_CINSI.TextFont.Bold = true;
                    LBL_CINSI.Value = @"Cinsi";

                    LBL_ADSOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 32, 141, 36, false);
                    LBL_ADSOYADI.Name = "LBL_ADSOYADI";
                    LBL_ADSOYADI.TextFont.Name = "Arial Narrow";
                    LBL_ADSOYADI.TextFont.Size = 8;
                    LBL_ADSOYADI.TextFont.Bold = true;
                    LBL_ADSOYADI.Value = @"Hasta Adı Soyadı";

                    LBL_TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 32, 25, 36, false);
                    LBL_TARIH.Name = "LBL_TARIH";
                    LBL_TARIH.TextFont.Name = "Arial Narrow";
                    LBL_TARIH.TextFont.Size = 8;
                    LBL_TARIH.TextFont.Bold = true;
                    LBL_TARIH.Value = @"Tarih";

                    LBL_DOKTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 32, 187, 36, false);
                    LBL_DOKTOR.Name = "LBL_DOKTOR";
                    LBL_DOKTOR.TextFont.Name = "Arial Narrow";
                    LBL_DOKTOR.TextFont.Size = 8;
                    LBL_DOKTOR.TextFont.Bold = true;
                    LBL_DOKTOR.Value = @"Kaynak";

                    LBL_DURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 32, 206, 36, false);
                    LBL_DURUMU.Name = "LBL_DURUMU";
                    LBL_DURUMU.TextFont.Name = "Arial Narrow";
                    LBL_DURUMU.TextFont.Size = 8;
                    LBL_DURUMU.TextFont.Bold = true;
                    LBL_DURUMU.Value = @"Durumu";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 38, 290, 38, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewLine1.DrawWidth = 2;

                    LABELK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 32, 76, 36, false);
                    LABELK.Name = "LABELK";
                    LABELK.TextFont.Name = "Arial Narrow";
                    LABELK.TextFont.Size = 8;
                    LABELK.TextFont.Bold = true;
                    LABELK.Value = @"Kategori";

                    LBL_NOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 32, 281, 36, false);
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

                    Hasta_Kimlik_No = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 32, 114, 36, false);
                    Hasta_Kimlik_No.Name = "Hasta_Kimlik_No";
                    Hasta_Kimlik_No.TextFont.Name = "Arial Narrow";
                    Hasta_Kimlik_No.TextFont.Size = 8;
                    Hasta_Kimlik_No.TextFont.Bold = true;
                    Hasta_Kimlik_No.Value = @"Hasta Kimlik No";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LBL_SAAT.CalcValue = LBL_SAAT.Value;
                    LBL_CINSI.CalcValue = LBL_CINSI.Value;
                    LBL_ADSOYADI.CalcValue = LBL_ADSOYADI.Value;
                    LBL_TARIH.CalcValue = LBL_TARIH.Value;
                    LBL_DOKTOR.CalcValue = LBL_DOKTOR.Value;
                    LBL_DURUMU.CalcValue = LBL_DURUMU.Value;
                    LABELK.CalcValue = LABELK.Value;
                    LBL_NOT.CalcValue = LBL_NOT.Value;
                    NewField.CalcValue = NewField.Value;
                    LOGO.CalcValue = @"";
                    Hasta_Kimlik_No.CalcValue = Hasta_Kimlik_No.Value;
                    return new TTReportObject[] { LBL_SAAT,LBL_CINSI,LBL_ADSOYADI,LBL_TARIH,LBL_DOKTOR,LBL_DURUMU,LABELK,LBL_NOT,NewField,LOGO,Hasta_Kimlik_No};
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
                public AppointmentListByResourceAndPatient MyParentReport
                {
                    get { return (AppointmentListByResourceAndPatient)ParentReport; }
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
            public AppointmentListByResourceAndPatient MyParentReport
            {
                get { return (AppointmentListByResourceAndPatient)ParentReport; }
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
                list[0] = new TTReportNqlData<Appointment.GetAppointmentByResourceAndPatient_Class>("GetAppointmentByResourceAndPatient2", Appointment.GetAppointmentByResourceAndPatient((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.StartDate),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.EndDate),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.Resource),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.Patient),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MasterResource)));
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
                public AppointmentListByResourceAndPatient MyParentReport
                {
                    get { return (AppointmentListByResourceAndPatient)ParentReport; }
                }
                
                public TTReportField SAAT;
                public TTReportField CINSI;
                public TTReportField ADISOYADI;
                public TTReportField TARIH;
                public TTReportField KAYNAK;
                public TTReportField DURUMU;
                public TTReportField NOT;
                public TTReportField OBJECTID;
                public TTReportField KATEGORI;
                public TTReportField KIMLIKNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    AutoSizeGap = 1;
                    RepeatCount = 0;
                    
                    SAAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 0, 45, 4, false);
                    SAAT.Name = "SAAT";
                    SAAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAAT.MultiLine = EvetHayirEnum.ehEvet;
                    SAAT.NoClip = EvetHayirEnum.ehEvet;
                    SAAT.ExpandTabs = EvetHayirEnum.ehEvet;
                    SAAT.TextFont.Name = "Arial Narrow";
                    SAAT.TextFont.Size = 8;
                    SAAT.Value = @"";

                    CINSI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 0, 92, 4, false);
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

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 0, 141, 4, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.MultiLine = EvetHayirEnum.ehEvet;
                    ADISOYADI.NoClip = EvetHayirEnum.ehEvet;
                    ADISOYADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADISOYADI.TextFont.Name = "Arial Narrow";
                    ADISOYADI.TextFont.Size = 8;
                    ADISOYADI.Value = @"";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 0, 25, 4, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"Short Date";
                    TARIH.MultiLine = EvetHayirEnum.ehEvet;
                    TARIH.NoClip = EvetHayirEnum.ehEvet;
                    TARIH.ExpandTabs = EvetHayirEnum.ehEvet;
                    TARIH.TextFont.Name = "Arial Narrow";
                    TARIH.TextFont.Size = 8;
                    TARIH.Value = @"{#APPDATE#}";

                    KAYNAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 0, 187, 4, false);
                    KAYNAK.Name = "KAYNAK";
                    KAYNAK.FieldType = ReportFieldTypeEnum.ftVariable;
                    KAYNAK.CaseFormat = CaseFormatEnum.fcTitleCase;
                    KAYNAK.MultiLine = EvetHayirEnum.ehEvet;
                    KAYNAK.NoClip = EvetHayirEnum.ehEvet;
                    KAYNAK.ExpandTabs = EvetHayirEnum.ehEvet;
                    KAYNAK.TextFont.Name = "Arial Narrow";
                    KAYNAK.TextFont.Size = 8;
                    KAYNAK.Value = @"";

                    DURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 0, 205, 4, false);
                    DURUMU.Name = "DURUMU";
                    DURUMU.FieldType = ReportFieldTypeEnum.ftVariable;
                    DURUMU.MultiLine = EvetHayirEnum.ehEvet;
                    DURUMU.NoClip = EvetHayirEnum.ehEvet;
                    DURUMU.ExpandTabs = EvetHayirEnum.ehEvet;
                    DURUMU.TextFont.Name = "Arial Narrow";
                    DURUMU.TextFont.Size = 8;
                    DURUMU.Value = @"";

                    NOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 0, 290, 9, false);
                    NOT.Name = "NOT";
                    NOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOT.MultiLine = EvetHayirEnum.ehEvet;
                    NOT.NoClip = EvetHayirEnum.ehEvet;
                    NOT.WordBreak = EvetHayirEnum.ehEvet;
                    NOT.ExpandTabs = EvetHayirEnum.ehEvet;
                    NOT.TextFont.Name = "Arial Narrow";
                    NOT.TextFont.Size = 8;
                    NOT.Value = @"{#NOTES#}";

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

                    KATEGORI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 0, 76, 4, false);
                    KATEGORI.Name = "KATEGORI";
                    KATEGORI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KATEGORI.NoClip = EvetHayirEnum.ehEvet;
                    KATEGORI.TextFont.Name = "Arial Narrow";
                    KATEGORI.TextFont.Size = 8;
                    KATEGORI.Value = @"";

                    KIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 0, 114, 4, false);
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
                    Appointment.GetAppointmentByResourceAndPatient_Class dataset_GetAppointmentByResourceAndPatient2 = ParentGroup.rsGroup.GetCurrentRecord<Appointment.GetAppointmentByResourceAndPatient_Class>(0);
                    SAAT.CalcValue = @"";
                    CINSI.CalcValue = (dataset_GetAppointmentByResourceAndPatient2 != null ? Globals.ToStringCore(dataset_GetAppointmentByResourceAndPatient2.AppointmentType) : "");
                    CINSI.PostFieldValueCalculation();
                    ADISOYADI.CalcValue = @"";
                    TARIH.CalcValue = (dataset_GetAppointmentByResourceAndPatient2 != null ? Globals.ToStringCore(dataset_GetAppointmentByResourceAndPatient2.AppDate) : "");
                    KAYNAK.CalcValue = @"";
                    DURUMU.CalcValue = @"";
                    NOT.CalcValue = (dataset_GetAppointmentByResourceAndPatient2 != null ? Globals.ToStringCore(dataset_GetAppointmentByResourceAndPatient2.Notes) : "");
                    OBJECTID.CalcValue = (dataset_GetAppointmentByResourceAndPatient2 != null ? Globals.ToStringCore(dataset_GetAppointmentByResourceAndPatient2.ObjectID) : "");
                    KATEGORI.CalcValue = @"";
                    KIMLIKNO.CalcValue = @"";
                    return new TTReportObject[] { SAAT,CINSI,ADISOYADI,TARIH,KAYNAK,DURUMU,NOT,OBJECTID,KATEGORI,KIMLIKNO};
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
                //                    this.KAYNAK.CalcValue = app.Resource.Name;
                //                else
                //                    this.KAYNAK.CalcValue = app.Resource.Name + " - " + app.MasterResource.Name;
            }
            
            this.DURUMU.CalcValue = app.CurrentStateDef.DisplayText;
            
            
            if(app.Patient != null && app.Patient.UniqueRefNo != null)
                this.KIMLIKNO.CalcValue = app.Patient.UniqueRefNo.ToString();
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

        public AppointmentListByResourceAndPatient()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("MasterResource", "00000000-0000-0000-0000-000000000000", "Randevunun Verildiği Ana Kaynak", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("44d92ee9-95ea-42f3-8a1a-07fce625510c");
            reportParameter = Parameters.Add("Resource", "00000000-0000-0000-0000-000000000000", "Randevunun Verildiği Kaynak", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("44d92ee9-95ea-42f3-8a1a-07fce625510c");
            reportParameter = Parameters.Add("Patient", "00000000-0000-0000-0000-000000000000", "Randevu Verilen Hasta", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("76039cb1-fc7b-447c-b07d-619b4c9605d7");
            reportParameter = Parameters.Add("StartDate", "", "Başlangış Tarih / Saati", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("EndDate", "", "Bitiş Tarih/Saati", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("MasterResource"))
                _runtimeParameters.MasterResource = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MasterResource"]);
            if (parameters.ContainsKey("Resource"))
                _runtimeParameters.Resource = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["Resource"]);
            if (parameters.ContainsKey("Patient"))
                _runtimeParameters.Patient = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["Patient"]);
            if (parameters.ContainsKey("StartDate"))
                _runtimeParameters.StartDate = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["StartDate"]);
            if (parameters.ContainsKey("EndDate"))
                _runtimeParameters.EndDate = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["EndDate"]);
            Name = "APPOINTMENTLISTBYRESOURCEANDPATIENT";
            Caption = "Randevu Listesi(Kaynak ve Hasta Bazlı)";
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