
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
    /// Randevu Bilgi Formu
    /// </summary>
    public partial class AppointmentInfoReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string OBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public AppointmentInfoReport MyParentReport
            {
                get { return (AppointmentInfoReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
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
                public AppointmentInfoReport MyParentReport
                {
                    get { return (AppointmentInfoReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField LOGO; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 47;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 8, 223, 22, false);
                    NewField.Name = "NewField";
                    NewField.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField.DrawWidth = 2;
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField.TextFont.Name = "Arial Narrow";
                    NewField.TextFont.Size = 14;
                    NewField.TextFont.Bold = true;
                    NewField.Value = @"Randevu Bilgi Formu";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 8, 54, 19, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField.CalcValue = NewField.Value;
                    LOGO.CalcValue = @"";
                    return new TTReportObject[] { NewField,LOGO};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public AppointmentInfoReport MyParentReport
                {
                    get { return (AppointmentInfoReport)ParentReport; }
                }
                
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
            public AppointmentInfoReport MyParentReport
            {
                get { return (AppointmentInfoReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField LBL_SAAT1 { get {return Body().LBL_SAAT1;} }
            public TTReportField LBL_CINSI1 { get {return Body().LBL_CINSI1;} }
            public TTReportField LBL_ADSOYADI1 { get {return Body().LBL_ADSOYADI1;} }
            public TTReportField LBL_TARIH1 { get {return Body().LBL_TARIH1;} }
            public TTReportField LBL_DOKTOR1 { get {return Body().LBL_DOKTOR1;} }
            public TTReportField LABELK1 { get {return Body().LABELK1;} }
            public TTReportField LBL_NOT1 { get {return Body().LBL_NOT1;} }
            public TTReportField LBL_TARIH12 { get {return Body().LBL_TARIH12;} }
            public TTReportField QUEUE { get {return Body().QUEUE;} }
            public TTReportField ADISOYADI { get {return Body().ADISOYADI;} }
            public TTReportField KAYNAK { get {return Body().KAYNAK;} }
            public TTReportField NOT { get {return Body().NOT;} }
            public TTReportField NewField18181 { get {return Body().NewField18181;} }
            public TTReportField NewField19181 { get {return Body().NewField19181;} }
            public TTReportField NewField10281 { get {return Body().NewField10281;} }
            public TTReportField NewField11281 { get {return Body().NewField11281;} }
            public TTReportField NewField128181 { get {return Body().NewField128181;} }
            public TTReportField NewField138181 { get {return Body().NewField138181;} }
            public TTReportField NewField148181 { get {return Body().NewField148181;} }
            public TTReportField NewField168181 { get {return Body().NewField168181;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField SAAT { get {return Body().SAAT;} }
            public TTReportField KATEGORI { get {return Body().KATEGORI;} }
            public TTReportField CINSI { get {return Body().CINSI;} }
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
                public AppointmentInfoReport MyParentReport
                {
                    get { return (AppointmentInfoReport)ParentReport; }
                }
                
                public TTReportField OBJECTID;
                public TTReportField LBL_SAAT1;
                public TTReportField LBL_CINSI1;
                public TTReportField LBL_ADSOYADI1;
                public TTReportField LBL_TARIH1;
                public TTReportField LBL_DOKTOR1;
                public TTReportField LABELK1;
                public TTReportField LBL_NOT1;
                public TTReportField LBL_TARIH12;
                public TTReportField QUEUE;
                public TTReportField ADISOYADI;
                public TTReportField KAYNAK;
                public TTReportField NOT;
                public TTReportField NewField18181;
                public TTReportField NewField19181;
                public TTReportField NewField10281;
                public TTReportField NewField11281;
                public TTReportField NewField128181;
                public TTReportField NewField138181;
                public TTReportField NewField148181;
                public TTReportField NewField168181;
                public TTReportField TARIH;
                public TTReportField SAAT;
                public TTReportField KATEGORI;
                public TTReportField CINSI; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    AutoSizeGap = 1;
                    RepeatCount = 0;
                    
                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 311, 1, 331, 5, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.MultiLine = EvetHayirEnum.ehEvet;
                    OBJECTID.NoClip = EvetHayirEnum.ehEvet;
                    OBJECTID.ExpandTabs = EvetHayirEnum.ehEvet;
                    OBJECTID.TextFont.Name = "Arial Narrow";
                    OBJECTID.TextFont.Size = 8;
                    OBJECTID.Value = @"{@OBJECTID@}";

                    LBL_SAAT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 20, 44, 24, false);
                    LBL_SAAT1.Name = "LBL_SAAT1";
                    LBL_SAAT1.TextFont.Name = "Arial";
                    LBL_SAAT1.TextFont.Size = 9;
                    LBL_SAAT1.TextFont.Bold = true;
                    LBL_SAAT1.Value = @"Saati";

                    LBL_CINSI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 14, 163, 18, false);
                    LBL_CINSI1.Name = "LBL_CINSI1";
                    LBL_CINSI1.TextFont.Name = "Arial";
                    LBL_CINSI1.TextFont.Size = 9;
                    LBL_CINSI1.TextFont.Bold = true;
                    LBL_CINSI1.Value = @"Cinsi";

                    LBL_ADSOYADI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 2, 44, 6, false);
                    LBL_ADSOYADI1.Name = "LBL_ADSOYADI1";
                    LBL_ADSOYADI1.TextFont.Name = "Arial";
                    LBL_ADSOYADI1.TextFont.Size = 9;
                    LBL_ADSOYADI1.TextFont.Bold = true;
                    LBL_ADSOYADI1.Value = @"Hasta Adı Soyadı";

                    LBL_TARIH1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 14, 44, 18, false);
                    LBL_TARIH1.Name = "LBL_TARIH1";
                    LBL_TARIH1.TextFont.Name = "Arial";
                    LBL_TARIH1.TextFont.Size = 9;
                    LBL_TARIH1.TextFont.Bold = true;
                    LBL_TARIH1.Value = @"Tarih";

                    LBL_DOKTOR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 2, 163, 6, false);
                    LBL_DOKTOR1.Name = "LBL_DOKTOR1";
                    LBL_DOKTOR1.TextFont.Name = "Arial";
                    LBL_DOKTOR1.TextFont.Size = 9;
                    LBL_DOKTOR1.TextFont.Bold = true;
                    LBL_DOKTOR1.Value = @"Kaynak";

                    LABELK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 8, 163, 12, false);
                    LABELK1.Name = "LABELK1";
                    LABELK1.TextFont.Name = "Arial";
                    LABELK1.TextFont.Size = 9;
                    LABELK1.TextFont.Bold = true;
                    LABELK1.Value = @"Kategori";

                    LBL_NOT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 20, 163, 24, false);
                    LBL_NOT1.Name = "LBL_NOT1";
                    LBL_NOT1.TextFont.Name = "Arial";
                    LBL_NOT1.TextFont.Size = 9;
                    LBL_NOT1.TextFont.Bold = true;
                    LBL_NOT1.Value = @"Notlar";

                    LBL_TARIH12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 8, 44, 12, false);
                    LBL_TARIH12.Name = "LBL_TARIH12";
                    LBL_TARIH12.TextFont.Name = "Arial";
                    LBL_TARIH12.TextFont.Size = 9;
                    LBL_TARIH12.TextFont.Bold = true;
                    LBL_TARIH12.Value = @"Sıra";

                    QUEUE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 8, 119, 12, false);
                    QUEUE.Name = "QUEUE";
                    QUEUE.FieldType = ReportFieldTypeEnum.ftVariable;
                    QUEUE.NoClip = EvetHayirEnum.ehEvet;
                    QUEUE.TextFont.Name = "Arial";
                    QUEUE.TextFont.Size = 9;
                    QUEUE.Value = @"";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 2, 119, 6, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.MultiLine = EvetHayirEnum.ehEvet;
                    ADISOYADI.NoClip = EvetHayirEnum.ehEvet;
                    ADISOYADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADISOYADI.TextFont.Name = "Arial";
                    ADISOYADI.TextFont.Size = 9;
                    ADISOYADI.Value = @"";

                    KAYNAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 2, 253, 6, false);
                    KAYNAK.Name = "KAYNAK";
                    KAYNAK.FieldType = ReportFieldTypeEnum.ftVariable;
                    KAYNAK.CaseFormat = CaseFormatEnum.fcTitleCase;
                    KAYNAK.MultiLine = EvetHayirEnum.ehEvet;
                    KAYNAK.NoClip = EvetHayirEnum.ehEvet;
                    KAYNAK.ExpandTabs = EvetHayirEnum.ehEvet;
                    KAYNAK.TextFont.Name = "Arial";
                    KAYNAK.TextFont.Size = 9;
                    KAYNAK.Value = @"";

                    NOT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 20, 253, 24, false);
                    NOT.Name = "NOT";
                    NOT.FieldType = ReportFieldTypeEnum.ftVariable;
                    NOT.MultiLine = EvetHayirEnum.ehEvet;
                    NOT.NoClip = EvetHayirEnum.ehEvet;
                    NOT.WordBreak = EvetHayirEnum.ehEvet;
                    NOT.ExpandTabs = EvetHayirEnum.ehEvet;
                    NOT.TextFont.Name = "Arial";
                    NOT.TextFont.Size = 9;
                    NOT.Value = @"";

                    NewField18181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 20, 46, 24, false);
                    NewField18181.Name = "NewField18181";
                    NewField18181.TextFont.Name = "Arial";
                    NewField18181.TextFont.Size = 9;
                    NewField18181.TextFont.Bold = true;
                    NewField18181.Value = @":";

                    NewField19181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 14, 46, 18, false);
                    NewField19181.Name = "NewField19181";
                    NewField19181.TextFont.Name = "Arial";
                    NewField19181.TextFont.Size = 9;
                    NewField19181.TextFont.Bold = true;
                    NewField19181.Value = @":";

                    NewField10281 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 8, 46, 12, false);
                    NewField10281.Name = "NewField10281";
                    NewField10281.TextFont.Name = "Arial";
                    NewField10281.TextFont.Size = 9;
                    NewField10281.TextFont.Bold = true;
                    NewField10281.Value = @":";

                    NewField11281 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 2, 46, 6, false);
                    NewField11281.Name = "NewField11281";
                    NewField11281.TextFont.Name = "Arial";
                    NewField11281.TextFont.Size = 9;
                    NewField11281.TextFont.Bold = true;
                    NewField11281.Value = @":";

                    NewField128181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 14, 165, 18, false);
                    NewField128181.Name = "NewField128181";
                    NewField128181.TextFont.Name = "Arial";
                    NewField128181.TextFont.Size = 9;
                    NewField128181.TextFont.Bold = true;
                    NewField128181.Value = @":";

                    NewField138181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 8, 165, 12, false);
                    NewField138181.Name = "NewField138181";
                    NewField138181.TextFont.Name = "Arial";
                    NewField138181.TextFont.Size = 9;
                    NewField138181.TextFont.Bold = true;
                    NewField138181.Value = @":";

                    NewField148181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 20, 165, 24, false);
                    NewField148181.Name = "NewField148181";
                    NewField148181.TextFont.Name = "Arial";
                    NewField148181.TextFont.Size = 9;
                    NewField148181.TextFont.Bold = true;
                    NewField148181.Value = @":";

                    NewField168181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 2, 165, 6, false);
                    NewField168181.Name = "NewField168181";
                    NewField168181.TextFont.Name = "Arial";
                    NewField168181.TextFont.Size = 9;
                    NewField168181.TextFont.Bold = true;
                    NewField168181.Value = @":";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 14, 119, 18, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.MultiLine = EvetHayirEnum.ehEvet;
                    TARIH.NoClip = EvetHayirEnum.ehEvet;
                    TARIH.ExpandTabs = EvetHayirEnum.ehEvet;
                    TARIH.TextFont.Name = "Arial";
                    TARIH.TextFont.Size = 9;
                    TARIH.Value = @"";

                    SAAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 20, 119, 24, false);
                    SAAT.Name = "SAAT";
                    SAAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAAT.MultiLine = EvetHayirEnum.ehEvet;
                    SAAT.NoClip = EvetHayirEnum.ehEvet;
                    SAAT.ExpandTabs = EvetHayirEnum.ehEvet;
                    SAAT.TextFont.Name = "Arial";
                    SAAT.TextFont.Size = 9;
                    SAAT.Value = @"";

                    KATEGORI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 8, 253, 12, false);
                    KATEGORI.Name = "KATEGORI";
                    KATEGORI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KATEGORI.NoClip = EvetHayirEnum.ehEvet;
                    KATEGORI.TextFont.Name = "Arial";
                    KATEGORI.TextFont.Size = 9;
                    KATEGORI.Value = @"";

                    CINSI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 14, 253, 18, false);
                    CINSI.Name = "CINSI";
                    CINSI.FieldType = ReportFieldTypeEnum.ftVariable;
                    CINSI.NoClip = EvetHayirEnum.ehEvet;
                    CINSI.TextFont.Name = "Arial";
                    CINSI.TextFont.Size = 9;
                    CINSI.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OBJECTID.CalcValue = MyParentReport.RuntimeParameters.OBJECTID.ToString();
                    LBL_SAAT1.CalcValue = LBL_SAAT1.Value;
                    LBL_CINSI1.CalcValue = LBL_CINSI1.Value;
                    LBL_ADSOYADI1.CalcValue = LBL_ADSOYADI1.Value;
                    LBL_TARIH1.CalcValue = LBL_TARIH1.Value;
                    LBL_DOKTOR1.CalcValue = LBL_DOKTOR1.Value;
                    LABELK1.CalcValue = LABELK1.Value;
                    LBL_NOT1.CalcValue = LBL_NOT1.Value;
                    LBL_TARIH12.CalcValue = LBL_TARIH12.Value;
                    QUEUE.CalcValue = @"";
                    ADISOYADI.CalcValue = @"";
                    KAYNAK.CalcValue = @"";
                    NOT.CalcValue = @"";
                    NewField18181.CalcValue = NewField18181.Value;
                    NewField19181.CalcValue = NewField19181.Value;
                    NewField10281.CalcValue = NewField10281.Value;
                    NewField11281.CalcValue = NewField11281.Value;
                    NewField128181.CalcValue = NewField128181.Value;
                    NewField138181.CalcValue = NewField138181.Value;
                    NewField148181.CalcValue = NewField148181.Value;
                    NewField168181.CalcValue = NewField168181.Value;
                    TARIH.CalcValue = @"";
                    SAAT.CalcValue = @"";
                    KATEGORI.CalcValue = @"";
                    CINSI.CalcValue = @"";
                    return new TTReportObject[] { OBJECTID,LBL_SAAT1,LBL_CINSI1,LBL_ADSOYADI1,LBL_TARIH1,LBL_DOKTOR1,LABELK1,LBL_NOT1,LBL_TARIH12,QUEUE,ADISOYADI,KAYNAK,NOT,NewField18181,NewField19181,NewField10281,NewField11281,NewField128181,NewField138181,NewField148181,NewField168181,TARIH,SAAT,KATEGORI,CINSI};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            this.OBJECTID.CalcValue = ((AppointmentInfoReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
            string objectID = this.OBJECTID.CalcValue;
                        
            Appointment app = (Appointment)objectContext.GetObject(new Guid(objectID),"Appointment");
            
            AdmissionAppointment addApp = (AdmissionAppointment)objectContext.GetObject(app.Action.ObjectID,typeof(AdmissionAppointment));
            
            this.TARIH.CalcValue = addApp.WorkListDate.HasValue ? addApp.WorkListDate.Value.ToShortDateString() : String.Empty;
            
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
                //this.CINSI.CalcValue = app.AppointmentType.HasValue ? app.AppointmentType : null;
            }
            this.QUEUE.CalcValue = (TTObjectClasses.Common.GetEnumValueDefOfEnumValue((Enum)app.AppointmentType)).DisplayText.ToString();
            this.NOT.CalcValue = app.Notes;
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

        public AppointmentInfoReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("OBJECTID", "", "OBJECTID", @"", true, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("OBJECTID"))
                _runtimeParameters.OBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["OBJECTID"]);
            Name = "APPOINTMENTINFOREPORT";
            Caption = "Randevu Bilgi Formu";
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