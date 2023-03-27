
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
    /// K-Çizelgesi
    /// </summary>
    public partial class KScheduleReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public KScheduleReport MyParentReport
            {
                get { return (KScheduleReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField HOSPITALNAMEHEADER { get {return Header().HOSPITALNAMEHEADER;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField DESTINATIONSTORE { get {return Header().DESTINATIONSTORE;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField STARTDATE1 { get {return Header().STARTDATE1;} }
            public TTReportField lblPatientName1 { get {return Header().lblPatientName1;} }
            public TTReportField lblPatientFatherName1 { get {return Header().lblPatientFatherName1;} }
            public TTReportField dotsPatientName1 { get {return Header().dotsPatientName1;} }
            public TTReportField dotsPatientStatus1 { get {return Header().dotsPatientStatus1;} }
            public TTReportField PatientName1 { get {return Header().PatientName1;} }
            public TTReportField lblPatientName11 { get {return Header().lblPatientName11;} }
            public TTReportField dotsPatientName11 { get {return Header().dotsPatientName11;} }
            public TTReportField Uniquerefno1 { get {return Header().Uniquerefno1;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField PAGENUMBER { get {return Footer().PAGENUMBER;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<KSchedule.GetKScheduleReportQuery_Class>("GetKScheduleReportQuery", KSchedule.GetKScheduleReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public KScheduleReport MyParentReport
                {
                    get { return (KScheduleReport)ParentReport; }
                }
                
                public TTReportField HOSPITALNAMEHEADER;
                public TTReportField NewField131;
                public TTReportField DESTINATIONSTORE;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField STARTDATE1;
                public TTReportField lblPatientName1;
                public TTReportField lblPatientFatherName1;
                public TTReportField dotsPatientName1;
                public TTReportField dotsPatientStatus1;
                public TTReportField PatientName1;
                public TTReportField lblPatientName11;
                public TTReportField dotsPatientName11;
                public TTReportField Uniquerefno1;
                public TTReportField LOGO; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 84;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HOSPITALNAMEHEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 4, 190, 48, false);
                    HOSPITALNAMEHEADER.Name = "HOSPITALNAMEHEADER";
                    HOSPITALNAMEHEADER.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAMEHEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITALNAMEHEADER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HOSPITALNAMEHEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALNAMEHEADER.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALNAMEHEADER.TextFont.Name = "Arial";
                    HOSPITALNAMEHEADER.TextFont.Size = 12;
                    HOSPITALNAMEHEADER.TextFont.Bold = true;
                    HOSPITALNAMEHEADER.TextFont.CharSet = 162;
                    HOSPITALNAMEHEADER.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 51, 200, 57, false);
                    NewField131.Name = "NewField131";
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Size = 11;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"GÜNLÜK İLAÇ ÇİZELGESİ";

                    DESTINATIONSTORE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 75, 200, 80, false);
                    DESTINATIONSTORE.Name = "DESTINATIONSTORE";
                    DESTINATIONSTORE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESTINATIONSTORE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESTINATIONSTORE.TextFont.Name = "Arial";
                    DESTINATIONSTORE.TextFont.CharSet = 162;
                    DESTINATIONSTORE.Value = @"{#DESTINATIONSTORE#}";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 58, 109, 63, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.TextFont.Name = "Arial";
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{#STARTDATE#}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 58, 200, 63, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.TextFont.Name = "Arial";
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{#ENDDATE#}";

                    STARTDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 58, 111, 63, false);
                    STARTDATE1.Name = "STARTDATE1";
                    STARTDATE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STARTDATE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE1.TextFont.Name = "Arial";
                    STARTDATE1.TextFont.CharSet = 162;
                    STARTDATE1.Value = @"-";

                    lblPatientName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 65, 51, 70, false);
                    lblPatientName1.Name = "lblPatientName1";
                    lblPatientName1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    lblPatientName1.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName1.TextFont.Size = 9;
                    lblPatientName1.TextFont.CharSet = 162;
                    lblPatientName1.Value = @"Adı Soyadı";

                    lblPatientFatherName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 75, 51, 84, false);
                    lblPatientFatherName1.Name = "lblPatientFatherName1";
                    lblPatientFatherName1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    lblPatientFatherName1.MultiLine = EvetHayirEnum.ehEvet;
                    lblPatientFatherName1.WordBreak = EvetHayirEnum.ehEvet;
                    lblPatientFatherName1.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientFatherName1.TextFont.Size = 9;
                    lblPatientFatherName1.TextFont.CharSet = 162;
                    lblPatientFatherName1.Value = @"İstek Yapan Servisin Deposu";

                    dotsPatientName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 65, 54, 70, false);
                    dotsPatientName1.Name = "dotsPatientName1";
                    dotsPatientName1.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName1.TextFont.Size = 9;
                    dotsPatientName1.TextFont.CharSet = 162;
                    dotsPatientName1.Value = @":";

                    dotsPatientStatus1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 75, 54, 80, false);
                    dotsPatientStatus1.Name = "dotsPatientStatus1";
                    dotsPatientStatus1.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientStatus1.TextFont.Size = 9;
                    dotsPatientStatus1.TextFont.CharSet = 162;
                    dotsPatientStatus1.Value = @":";

                    PatientName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 65, 200, 70, false);
                    PatientName1.Name = "PatientName1";
                    PatientName1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientName1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PatientName1.MultiLine = EvetHayirEnum.ehEvet;
                    PatientName1.TextFont.Name = "Microsoft Sans Serif";
                    PatientName1.TextFont.Size = 9;
                    PatientName1.TextFont.CharSet = 162;
                    PatientName1.Value = @"{#PATIENTNAME#} {#SURNAME#}";

                    lblPatientName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 70, 51, 75, false);
                    lblPatientName11.Name = "lblPatientName11";
                    lblPatientName11.CaseFormat = CaseFormatEnum.fcUpperCase;
                    lblPatientName11.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName11.TextFont.Size = 9;
                    lblPatientName11.TextFont.CharSet = 162;
                    lblPatientName11.Value = @"TC Kimlik Nu.";

                    dotsPatientName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 70, 54, 75, false);
                    dotsPatientName11.Name = "dotsPatientName11";
                    dotsPatientName11.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName11.TextFont.Size = 9;
                    dotsPatientName11.TextFont.CharSet = 162;
                    dotsPatientName11.Value = @":";

                    Uniquerefno1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 70, 200, 75, false);
                    Uniquerefno1.Name = "Uniquerefno1";
                    Uniquerefno1.FieldType = ReportFieldTypeEnum.ftVariable;
                    Uniquerefno1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    Uniquerefno1.MultiLine = EvetHayirEnum.ehEvet;
                    Uniquerefno1.TextFont.Name = "Microsoft Sans Serif";
                    Uniquerefno1.TextFont.Size = 9;
                    Uniquerefno1.TextFont.CharSet = 162;
                    Uniquerefno1.Value = @"{#UNIQUEREFNO#}";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 7, 44, 30, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    KSchedule.GetKScheduleReportQuery_Class dataset_GetKScheduleReportQuery = ParentGroup.rsGroup.GetCurrentRecord<KSchedule.GetKScheduleReportQuery_Class>(0);
                    NewField131.CalcValue = NewField131.Value;
                    DESTINATIONSTORE.CalcValue = (dataset_GetKScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleReportQuery.Destinationstore) : "");
                    STARTDATE.CalcValue = (dataset_GetKScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleReportQuery.StartDate) : "");
                    ENDDATE.CalcValue = (dataset_GetKScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleReportQuery.EndDate) : "");
                    STARTDATE1.CalcValue = STARTDATE1.Value;
                    lblPatientName1.CalcValue = lblPatientName1.Value;
                    lblPatientFatherName1.CalcValue = lblPatientFatherName1.Value;
                    dotsPatientName1.CalcValue = dotsPatientName1.Value;
                    dotsPatientStatus1.CalcValue = dotsPatientStatus1.Value;
                    PatientName1.CalcValue = (dataset_GetKScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleReportQuery.Patientname) : "") + @" " + (dataset_GetKScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleReportQuery.Surname) : "");
                    lblPatientName11.CalcValue = lblPatientName11.Value;
                    dotsPatientName11.CalcValue = dotsPatientName11.Value;
                    Uniquerefno1.CalcValue = (dataset_GetKScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleReportQuery.UniqueRefNo) : "");
                    LOGO.CalcValue = @"";
                    HOSPITALNAMEHEADER.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField131,DESTINATIONSTORE,STARTDATE,ENDDATE,STARTDATE1,lblPatientName1,lblPatientFatherName1,dotsPatientName1,dotsPatientStatus1,PatientName1,lblPatientName11,dotsPatientName11,Uniquerefno1,LOGO,HOSPITALNAMEHEADER};
                }
                public override void RunPreScript()
                {
#region PARTA HEADER_PreScript
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion PARTA HEADER_PreScript
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public KScheduleReport MyParentReport
                {
                    get { return (KScheduleReport)ParentReport; }
                }
                
                public TTReportField PAGENUMBER; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 15;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 0, 200, 5, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER.TextFont.Name = "Arial";
                    PAGENUMBER.TextFont.Size = 9;
                    PAGENUMBER.TextFont.CharSet = 162;
                    PAGENUMBER.Value = @"Sayfa : {@pagenumber@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    KSchedule.GetKScheduleReportQuery_Class dataset_GetKScheduleReportQuery = ParentGroup.rsGroup.GetCurrentRecord<KSchedule.GetKScheduleReportQuery_Class>(0);
                    PAGENUMBER.CalcValue = @"Sayfa : " + ParentReport.CurrentPageNumber.ToString();
                    return new TTReportObject[] { PAGENUMBER};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public KScheduleReport MyParentReport
            {
                get { return (KScheduleReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportField NewField141 { get {return Footer().NewField141;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportField NewField131 { get {return Footer().NewField131;} }
            public TTReportField NewField1131 { get {return Footer().NewField1131;} }
            public TTReportField NewField1132 { get {return Footer().NewField1132;} }
            public TTReportField NewField1133 { get {return Footer().NewField1133;} }
            public TTReportField NewField13311 { get {return Footer().NewField13311;} }
            public TTReportField NewField13312 { get {return Footer().NewField13312;} }
            public TTReportField REQUEST { get {return Footer().REQUEST;} }
            public TTReportField REQUESTDATE { get {return Footer().REQUESTDATE;} }
            public TTReportField REQUESTNO { get {return Footer().REQUESTNO;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                KSchedule.GetKScheduleReportQuery_Class dataSet_GetKScheduleReportQuery = ParentGroup.rsGroup.GetCurrentRecord<KSchedule.GetKScheduleReportQuery_Class>(0);    
                return new object[] {(dataSet_GetKScheduleReportQuery==null ? null : dataSet_GetKScheduleReportQuery.ObjectID)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public KScheduleReport MyParentReport
                {
                    get { return (KScheduleReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField121;
                public TTReportShape NewLine1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 31, 5, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"S. Nu.";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 0, 79, 5, false);
                    NewField111.Name = "NewField111";
                    NewField111.Visible = EvetHayirEnum.ehHayir;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Karantina Nu.";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 0, 183, 5, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Malzeme";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 0, 200, 5, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Adedi ";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 5, 200, 5, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    KSchedule.GetKScheduleReportQuery_Class dataset_GetKScheduleReportQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<KSchedule.GetKScheduleReportQuery_Class>(0);
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    return new TTReportObject[] { NewField11,NewField111,NewField1111,NewField121};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public KScheduleReport MyParentReport
                {
                    get { return (KScheduleReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField141;
                public TTReportShape NewLine2;
                public TTReportShape NewLine12;
                public TTReportField NewField131;
                public TTReportField NewField1131;
                public TTReportField NewField1132;
                public TTReportField NewField1133;
                public TTReportField NewField13311;
                public TTReportField NewField13312;
                public TTReportField REQUEST;
                public TTReportField REQUESTDATE;
                public TTReportField REQUESTNO; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 25, 200, 55, false);
                    NewField1.Name = "NewField1";
                    NewField1.Visible = EvetHayirEnum.ehHayir;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"  1. Bu çizelge kopyalı iki nüsha olarak tanzim edilir.
  2. Tabibin hasta tabelalarına, yazdığı ilaçlar karantina numaralarına göre bu çizelgeye servis hemşiresi tarafından servis şefi nezaretinde yazılır ve eczaneye gönderilir.
  3. Eczanede toplu olarak hazırlanan bu çizelge muhteviyatları servis hemşireleri tarafından imza mukabili tam ve sağlam olarak alınır.
  4. K-Çizelgesi hazırlanmadan eczaneden hiç bir suretle ilaç verilmez.
  5. K-Çizelgesi ile birlikte hasta tabelaları da eczaneye getirilecektir.                  ";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 20, 49, 25, false);
                    NewField2.Name = "NewField2";
                    NewField2.Visible = EvetHayirEnum.ehHayir;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"AÇIKLAMALAR :";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 60, 9, false);
                    NewField3.Name = "NewField3";
                    NewField3.Visible = EvetHayirEnum.ehHayir;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Servis Sorumlu
Hemşire";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 0, 200, 5, false);
                    NewField13.Name = "NewField13";
                    NewField13.Visible = EvetHayirEnum.ehHayir;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Servis Şefi";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 3, 60, 12, false);
                    NewField14.Name = "NewField14";
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"TESLİM ALAN
Sorumlu Hemşire";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 3, 200, 12, false);
                    NewField141.Name = "NewField141";
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"TESLİM EDEN
Eczane Şefi";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 7, 60, 7, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 160, 7, 200, 7, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 3, 93, 8, false);
                    NewField131.Name = "NewField131";
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"İstek Yapan";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 8, 93, 13, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"İstek Tarihi";

                    NewField1132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 13, 93, 18, false);
                    NewField1132.Name = "NewField1132";
                    NewField1132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1132.TextFont.Name = "Arial";
                    NewField1132.TextFont.CharSet = 162;
                    NewField1132.Value = @"İstek Nu.";

                    NewField1133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 3, 94, 8, false);
                    NewField1133.Name = "NewField1133";
                    NewField1133.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1133.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1133.TextFont.Name = "Arial";
                    NewField1133.TextFont.CharSet = 162;
                    NewField1133.Value = @":";

                    NewField13311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 8, 94, 13, false);
                    NewField13311.Name = "NewField13311";
                    NewField13311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13311.TextFont.Name = "Arial";
                    NewField13311.TextFont.CharSet = 162;
                    NewField13311.Value = @":";

                    NewField13312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 13, 94, 18, false);
                    NewField13312.Name = "NewField13312";
                    NewField13312.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13312.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13312.TextFont.Name = "Arial";
                    NewField13312.TextFont.CharSet = 162;
                    NewField13312.Value = @":";

                    REQUEST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 3, 146, 8, false);
                    REQUEST.Name = "REQUEST";
                    REQUEST.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUEST.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUEST.TextFont.Name = "Arial";
                    REQUEST.TextFont.CharSet = 162;
                    REQUEST.Value = @"";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 8, 146, 13, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"dd/MM/yyyy";
                    REQUESTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTDATE.TextFont.Name = "Arial";
                    REQUESTDATE.TextFont.CharSet = 162;
                    REQUESTDATE.Value = @"{#PARTA.TRANSACTIONDATE#}";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 13, 146, 18, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTNO.TextFont.Name = "Arial";
                    REQUESTNO.TextFont.CharSet = 162;
                    REQUESTNO.Value = @"{#PARTA.STOCKACTIONID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    KSchedule.GetKScheduleReportQuery_Class dataset_GetKScheduleReportQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<KSchedule.GetKScheduleReportQuery_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1132.CalcValue = NewField1132.Value;
                    NewField1133.CalcValue = NewField1133.Value;
                    NewField13311.CalcValue = NewField13311.Value;
                    NewField13312.CalcValue = NewField13312.Value;
                    REQUEST.CalcValue = @"";
                    REQUESTDATE.CalcValue = (dataset_GetKScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleReportQuery.Transactiondate) : "");
                    REQUESTNO.CalcValue = (dataset_GetKScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleReportQuery.StockActionID) : "");
                    return new TTReportObject[] { NewField1,NewField2,NewField3,NewField13,NewField14,NewField141,NewField131,NewField1131,NewField1132,NewField1133,NewField13311,NewField13312,REQUEST,REQUESTDATE,REQUESTNO};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    string objectID = ((KScheduleReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                    TTObjectContext ctx = new TTObjectContext(true);
                    KSchedule kSchedule = (KSchedule)ctx.GetObject(new Guid(objectID), typeof(KSchedule));
                    ResUser user;
                    if (kSchedule != null)
                    {
                        user = (ResUser)kSchedule.GetState("New", true).User.UserObject;
                        if (user != null)
                            REQUEST.CalcValue = user.Name.ToString();
                    }
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public KScheduleReport MyParentReport
            {
                get { return (KScheduleReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField QUARANTINENO { get {return Body().QUARANTINENO;} }
            public TTReportField MATERIALID { get {return Body().MATERIALID;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                KSchedule.GetKScheduleReportQuery_Class dataSet_GetKScheduleReportQuery = ParentGroup.rsGroup.GetCurrentRecord<KSchedule.GetKScheduleReportQuery_Class>(0);    
                return new object[] {(dataSet_GetKScheduleReportQuery==null ? null : dataSet_GetKScheduleReportQuery.ObjectID)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public KScheduleReport MyParentReport
                {
                    get { return (KScheduleReport)ParentReport; }
                }
                
                public TTReportField ORDERNO;
                public TTReportField MATERIALNAME;
                public TTReportField AMOUNT;
                public TTReportField QUARANTINENO;
                public TTReportField MATERIALID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 31, 6, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{@counter@}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 1, 183, 6, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @" {#PARTA.MATERIAL#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 1, 200, 6, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#PARTA.AMOUNT#} ";

                    QUARANTINENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 1, 79, 6, false);
                    QUARANTINENO.Name = "QUARANTINENO";
                    QUARANTINENO.Visible = EvetHayirEnum.ehHayir;
                    QUARANTINENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    QUARANTINENO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    QUARANTINENO.MultiLine = EvetHayirEnum.ehEvet;
                    QUARANTINENO.NoClip = EvetHayirEnum.ehEvet;
                    QUARANTINENO.WordBreak = EvetHayirEnum.ehEvet;
                    QUARANTINENO.ExpandTabs = EvetHayirEnum.ehEvet;
                    QUARANTINENO.TextFont.Name = "Arial";
                    QUARANTINENO.TextFont.CharSet = 162;
                    QUARANTINENO.Value = @"";

                    MATERIALID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 1, 240, 6, false);
                    MATERIALID.Name = "MATERIALID";
                    MATERIALID.Visible = EvetHayirEnum.ehHayir;
                    MATERIALID.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALID.Value = @"{#PARTA.MATERIALID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    KSchedule.GetKScheduleReportQuery_Class dataset_GetKScheduleReportQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<KSchedule.GetKScheduleReportQuery_Class>(0);
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString();
                    MATERIALNAME.CalcValue = @" " + (dataset_GetKScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleReportQuery.Material) : "");
                    AMOUNT.CalcValue = (dataset_GetKScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleReportQuery.Amount) : "") + @" ";
                    QUARANTINENO.CalcValue = @"";
                    MATERIALID.CalcValue = (dataset_GetKScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleReportQuery.Materialid) : "");
                    return new TTReportObject[] { ORDERNO,MATERIALNAME,AMOUNT,QUARANTINENO,MATERIALID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string objectID = ((KScheduleReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                    BindingList<KSchedule.GetQuarantineNOForKScheduleQuery_Class> quarantineNoList = KSchedule.GetQuarantineNOForKScheduleQuery(new Guid(objectID), new Guid(MATERIALID.CalcValue));
                    for (int i = 0; i < quarantineNoList.Count; i++)
                    { 
                        QUARANTINENO.CalcValue += quarantineNoList[i].QuarantinaNO;
                        if (i != quarantineNoList.Count - 1)
                            QUARANTINENO.CalcValue += ", ";
                    }
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

        public KScheduleReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "K- Çizelgesi", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "KSCHEDULEREPORT";
            Caption = "K-Çizelgesi";
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
            fd.TextFont.Name = "Arial Narrow";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 1;
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