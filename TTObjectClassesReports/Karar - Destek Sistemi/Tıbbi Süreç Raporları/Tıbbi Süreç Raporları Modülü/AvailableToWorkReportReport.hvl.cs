
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
    /// Hizmet Akdiyle Çalışanlar İçin Çalışabilir Kağıdı
    /// </summary>
    public partial class AvailableToWorkReportReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MASTERGroup : TTReportGroup
        {
            public AvailableToWorkReportReport MyParentReport
            {
                get { return (AvailableToWorkReportReport)ParentReport; }
            }

            new public MASTERGroupHeader Header()
            {
                return (MASTERGroupHeader)_header;
            }

            new public MASTERGroupFooter Footer()
            {
                return (MASTERGroupFooter)_footer;
            }

            public TTReportField BASLIK { get {return Header().BASLIK;} }
            public MASTERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MASTERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new MASTERGroupHeader(this);
                _footer = new MASTERGroupFooter(this);

            }

            public partial class MASTERGroupHeader : TTReportSection
            {
                public AvailableToWorkReportReport MyParentReport
                {
                    get { return (AvailableToWorkReportReport)ParentReport; }
                }
                
                public TTReportField BASLIK; 
                public MASTERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 19;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 11, 165, 16, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASLIK.TextFont.Name = "Arial";
                    BASLIK.TextFont.Bold = true;
                    BASLIK.Value = @"HİZMET AKDİYLE ÇALIŞANLAR İÇİN ÇALIŞABİLİR KAĞIDI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BASLIK.CalcValue = BASLIK.Value;
                    return new TTReportObject[] { BASLIK};
                }
            }
            public partial class MASTERGroupFooter : TTReportSection
            {
                public AvailableToWorkReportReport MyParentReport
                {
                    get { return (AvailableToWorkReportReport)ParentReport; }
                }
                 
                public MASTERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MASTERGroup MASTER;

        public partial class MAINGroup : TTReportGroup
        {
            public AvailableToWorkReportReport MyParentReport
            {
                get { return (AvailableToWorkReportReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1661 { get {return Body().NewField1661;} }
            public TTReportField NewField1561 { get {return Body().NewField1561;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField1271 { get {return Body().NewField1271;} }
            public TTReportField NewField172 { get {return Body().NewField172;} }
            public TTReportField LABEL114211 { get {return Body().LABEL114211;} }
            public TTReportField NewField11401 { get {return Body().NewField11401;} }
            public TTReportField NewField11661 { get {return Body().NewField11661;} }
            public TTReportField NewField1141 { get {return Body().NewField1141;} }
            public TTReportField NewField11721 { get {return Body().NewField11721;} }
            public TTReportField NewField110411 { get {return Body().NewField110411;} }
            public TTReportField NewField120411 { get {return Body().NewField120411;} }
            public TTReportField NewField1114021 { get {return Body().NewField1114021;} }
            public TTReportField NewField1371 { get {return Body().NewField1371;} }
            public TTReportField NewField12721 { get {return Body().NewField12721;} }
            public TTReportField NewField112721 { get {return Body().NewField112721;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportShape NewLine1121 { get {return Body().NewLine1121;} }
            public TTReportField ANALYSIS { get {return Body().ANALYSIS;} }
            public TTReportField TREATMENT { get {return Body().TREATMENT;} }
            public TTReportField DISPATCH { get {return Body().DISPATCH;} }
            public TTReportField TREATMENTTERMINATIONDATE { get {return Body().TREATMENTTERMINATIONDATE;} }
            public TTReportField PROPERWORKDATE { get {return Body().PROPERWORKDATE;} }
            public TTReportField SERIAL { get {return Body().SERIAL;} }
            public TTReportField NO { get {return Body().NO;} }
            public TTReportField PDNO { get {return Body().PDNO;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField DOCTOR { get {return Body().DOCTOR;} }
            public TTReportField HOSPITALNAME { get {return Body().HOSPITALNAME;} }
            public TTReportField VDATE { get {return Body().VDATE;} }
            public TTReportField EMPLOYEEID { get {return Body().EMPLOYEEID;} }
            public TTReportField ENAME { get {return Body().ENAME;} }
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
                list[0] = new TTReportNqlData<AvailableToWorkReport.GetAvailableToWorkReport_Class>("GetAvailableToWorkReport", AvailableToWorkReport.GetAvailableToWorkReport((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public AvailableToWorkReportReport MyParentReport
                {
                    get { return (AvailableToWorkReportReport)ParentReport; }
                }
                
                public TTReportField NewField1661;
                public TTReportField NewField1561;
                public TTReportField NewField141;
                public TTReportField NewField1271;
                public TTReportField NewField172;
                public TTReportField LABEL114211;
                public TTReportField NewField11401;
                public TTReportField NewField11661;
                public TTReportField NewField1141;
                public TTReportField NewField11721;
                public TTReportField NewField110411;
                public TTReportField NewField120411;
                public TTReportField NewField1114021;
                public TTReportField NewField1371;
                public TTReportField NewField12721;
                public TTReportField NewField112721;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
                public TTReportShape NewLine121;
                public TTReportShape NewLine1121;
                public TTReportField ANALYSIS;
                public TTReportField TREATMENT;
                public TTReportField DISPATCH;
                public TTReportField TREATMENTTERMINATIONDATE;
                public TTReportField PROPERWORKDATE;
                public TTReportField SERIAL;
                public TTReportField NO;
                public TTReportField PDNO;
                public TTReportField OBJECTID;
                public TTReportField DOCTOR;
                public TTReportField HOSPITALNAME;
                public TTReportField VDATE;
                public TTReportField EMPLOYEEID;
                public TTReportField ENAME; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 108;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1661 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 45, 30, 50, false);
                    NewField1661.Name = "NewField1661";
                    NewField1661.TextFont.Name = "Arial";
                    NewField1661.TextFont.Size = 9;
                    NewField1661.Value = @"Adı ve Soyadı  :";

                    NewField1561 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 14, 153, 19, false);
                    NewField1561.Name = "NewField1561";
                    NewField1561.TextFont.Name = "Arial";
                    NewField1561.TextFont.Size = 9;
                    NewField1561.Value = @"Poliklinik Defter Sıra No   :";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 33, 33, 38, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Size = 9;
                    NewField141.TextFont.Underline = true;
                    NewField141.Value = @"SİGORTALININ";

                    NewField1271 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 40, 30, 45, false);
                    NewField1271.Name = "NewField1271";
                    NewField1271.TextFont.Name = "Arial";
                    NewField1271.TextFont.Size = 9;
                    NewField1271.Value = @"Sicil No            :";

                    NewField172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 77, 183, 82, false);
                    NewField172.Name = "NewField172";
                    NewField172.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField172.TextFont.Name = "Arial";
                    NewField172.TextFont.Size = 9;
                    NewField172.Value = @"MÜDAVİ HEKİM";

                    LABEL114211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 14, 62, 19, false);
                    LABEL114211.Name = "LABEL114211";
                    LABEL114211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABEL114211.TextFont.Name = "Arial";
                    LABEL114211.TextFont.Size = 9;
                    LABEL114211.TextFont.Bold = true;
                    LABEL114211.Value = @"SAĞLIK KURUM / KURULUŞ ADI";

                    NewField11401 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 50, 48, 55, false);
                    NewField11401.Name = "NewField11401";
                    NewField11401.TextFont.Name = "Arial";
                    NewField11401.TextFont.Size = 9;
                    NewField11401.Value = @"Viziteye çıktığı tarih ve saat  :";

                    NewField11661 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 69, 27, 74, false);
                    NewField11661.Name = "NewField11661";
                    NewField11661.TextFont.Name = "Arial";
                    NewField11661.TextFont.Size = 9;
                    NewField11661.Value = @"Tedavi           :";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 57, 44, 62, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.TextFont.Size = 9;
                    NewField1141.TextFont.Underline = true;
                    NewField1141.Value = @"YAPILAN İŞLEMLER";

                    NewField11721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 64, 27, 69, false);
                    NewField11721.Name = "NewField11721";
                    NewField11721.TextFont.Name = "Arial";
                    NewField11721.TextFont.Size = 9;
                    NewField11721.Value = @"Tahlil             :";

                    NewField110411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 74, 27, 79, false);
                    NewField110411.Name = "NewField110411";
                    NewField110411.TextFont.Name = "Arial";
                    NewField110411.TextFont.Size = 9;
                    NewField110411.Value = @"Sevk              :";

                    NewField120411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 79, 55, 84, false);
                    NewField120411.Name = "NewField120411";
                    NewField120411.TextFont.Name = "Arial";
                    NewField120411.TextFont.Size = 9;
                    NewField120411.Value = @"Tedavisinin bittiği tarih ve saat   :";

                    NewField1114021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 84, 55, 89, false);
                    NewField1114021.Name = "NewField1114021";
                    NewField1114021.TextFont.Name = "Arial";
                    NewField1114021.TextFont.Size = 9;
                    NewField1114021.Value = @"Çalışabileceği tarih                      :";

                    NewField1371 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 82, 183, 87, false);
                    NewField1371.Name = "NewField1371";
                    NewField1371.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1371.TextFont.Name = "Arial";
                    NewField1371.TextFont.Size = 9;
                    NewField1371.Value = @"(İmza-Kaşe)";

                    NewField12721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 22, 124, 27, false);
                    NewField12721.Name = "NewField12721";
                    NewField12721.TextFont.Name = "Arial";
                    NewField12721.TextFont.Size = 9;
                    NewField12721.Value = @"Seri  :";

                    NewField112721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 22, 170, 27, false);
                    NewField112721.Name = "NewField112721";
                    NewField112721.TextFont.Name = "Arial";
                    NewField112721.TextFont.Size = 9;
                    NewField112721.Value = @"No  :";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 3, 7, 212, 7, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 3, 103, 212, 103, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 3, 7, 3, 103, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 212, 7, 212, 103, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                    ANALYSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 64, 206, 69, false);
                    ANALYSIS.Name = "ANALYSIS";
                    ANALYSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    ANALYSIS.TextFont.Name = "Arial";
                    ANALYSIS.TextFont.Size = 9;
                    ANALYSIS.Value = @"{#ANALYSIS#}";

                    TREATMENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 69, 206, 74, false);
                    TREATMENT.Name = "TREATMENT";
                    TREATMENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TREATMENT.TextFont.Name = "Arial";
                    TREATMENT.TextFont.Size = 9;
                    TREATMENT.Value = @"{#TREATMENT#}";

                    DISPATCH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 74, 134, 79, false);
                    DISPATCH.Name = "DISPATCH";
                    DISPATCH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISPATCH.TextFont.Name = "Arial";
                    DISPATCH.TextFont.Size = 9;
                    DISPATCH.Value = @"{#DISPATCH#}";

                    TREATMENTTERMINATIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 79, 112, 84, false);
                    TREATMENTTERMINATIONDATE.Name = "TREATMENTTERMINATIONDATE";
                    TREATMENTTERMINATIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TREATMENTTERMINATIONDATE.TextFormat = @"dd/MM/yyyy";
                    TREATMENTTERMINATIONDATE.TextFont.Name = "Arial";
                    TREATMENTTERMINATIONDATE.TextFont.Size = 9;
                    TREATMENTTERMINATIONDATE.Value = @"{#TREATMENTTERMINATIONDATE#}";

                    PROPERWORKDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 84, 112, 89, false);
                    PROPERWORKDATE.Name = "PROPERWORKDATE";
                    PROPERWORKDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROPERWORKDATE.TextFormat = @"dd/MM/yyyy";
                    PROPERWORKDATE.TextFont.Name = "Arial";
                    PROPERWORKDATE.TextFont.Size = 9;
                    PROPERWORKDATE.Value = @"{#PROPERWORKDATE#}";

                    SERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 22, 160, 27, false);
                    SERIAL.Name = "SERIAL";
                    SERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIAL.TextFont.Name = "Arial";
                    SERIAL.TextFont.Size = 9;
                    SERIAL.Value = @"{#SERIAL#}";

                    NO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 22, 206, 27, false);
                    NO.Name = "NO";
                    NO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NO.TextFont.Name = "Arial";
                    NO.TextFont.Size = 9;
                    NO.Value = @"{#NO#}";

                    PDNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 14, 206, 19, false);
                    PDNO.Name = "PDNO";
                    PDNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PDNO.TextFont.Name = "Arial";
                    PDNO.TextFont.Size = 9;
                    PDNO.Value = @"{%PDNO%}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 10, 240, 15, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.TextFormat = @"dd/MM/yyyy";
                    OBJECTID.Value = @"{#OBJECTID#}";

                    DOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 87, 194, 97, false);
                    DOCTOR.Name = "DOCTOR";
                    DOCTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTOR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOCTOR.MultiLine = EvetHayirEnum.ehEvet;
                    DOCTOR.TextFont.Name = "Arial";
                    DOCTOR.TextFont.Size = 9;
                    DOCTOR.Value = @"{#DOCTOR#}";

                    HOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 19, 112, 31, false);
                    HOSPITALNAME.Name = "HOSPITALNAME";
                    HOSPITALNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.NoClip = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALNAME.TextFont.Name = "Arial";
                    HOSPITALNAME.TextFont.Size = 9;
                    HOSPITALNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"",""XXXXXX"")";

                    VDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 50, 112, 55, false);
                    VDATE.Name = "VDATE";
                    VDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    VDATE.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    VDATE.TextFont.Name = "Arial";
                    VDATE.TextFont.Size = 9;
                    VDATE.Value = @"{%VDATE%}";

                    EMPLOYEEID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 40, 112, 45, false);
                    EMPLOYEEID.Name = "EMPLOYEEID";
                    EMPLOYEEID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMPLOYEEID.TextFont.Name = "Arial";
                    EMPLOYEEID.TextFont.Size = 9;
                    EMPLOYEEID.Value = @"";

                    ENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 45, 112, 50, false);
                    ENAME.Name = "ENAME";
                    ENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENAME.TextFont.Name = "Arial";
                    ENAME.TextFont.Size = 9;
                    ENAME.Value = @"{#NAME#} {#SURNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AvailableToWorkReport.GetAvailableToWorkReport_Class dataset_GetAvailableToWorkReport = ParentGroup.rsGroup.GetCurrentRecord<AvailableToWorkReport.GetAvailableToWorkReport_Class>(0);
                    NewField1661.CalcValue = NewField1661.Value;
                    NewField1561.CalcValue = NewField1561.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1271.CalcValue = NewField1271.Value;
                    NewField172.CalcValue = NewField172.Value;
                    LABEL114211.CalcValue = LABEL114211.Value;
                    NewField11401.CalcValue = NewField11401.Value;
                    NewField11661.CalcValue = NewField11661.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField11721.CalcValue = NewField11721.Value;
                    NewField110411.CalcValue = NewField110411.Value;
                    NewField120411.CalcValue = NewField120411.Value;
                    NewField1114021.CalcValue = NewField1114021.Value;
                    NewField1371.CalcValue = NewField1371.Value;
                    NewField12721.CalcValue = NewField12721.Value;
                    NewField112721.CalcValue = NewField112721.Value;
                    ANALYSIS.CalcValue = (dataset_GetAvailableToWorkReport != null ? Globals.ToStringCore(dataset_GetAvailableToWorkReport.Analysis) : "");
                    TREATMENT.CalcValue = (dataset_GetAvailableToWorkReport != null ? Globals.ToStringCore(dataset_GetAvailableToWorkReport.Treatment) : "");
                    DISPATCH.CalcValue = (dataset_GetAvailableToWorkReport != null ? Globals.ToStringCore(dataset_GetAvailableToWorkReport.Dispatch) : "");
                    TREATMENTTERMINATIONDATE.CalcValue = (dataset_GetAvailableToWorkReport != null ? Globals.ToStringCore(dataset_GetAvailableToWorkReport.TreatmentTerminationDate) : "");
                    PROPERWORKDATE.CalcValue = (dataset_GetAvailableToWorkReport != null ? Globals.ToStringCore(dataset_GetAvailableToWorkReport.ProperWorkDate) : "");
                    SERIAL.CalcValue = (dataset_GetAvailableToWorkReport != null ? Globals.ToStringCore(dataset_GetAvailableToWorkReport.Serial) : "");
                    NO.CalcValue = (dataset_GetAvailableToWorkReport != null ? Globals.ToStringCore(dataset_GetAvailableToWorkReport.No) : "");
                    PDNO.CalcValue = MyParentReport.MAIN.PDNO.CalcValue;
                    OBJECTID.CalcValue = (dataset_GetAvailableToWorkReport != null ? Globals.ToStringCore(dataset_GetAvailableToWorkReport.ObjectID) : "");
                    DOCTOR.CalcValue = (dataset_GetAvailableToWorkReport != null ? Globals.ToStringCore(dataset_GetAvailableToWorkReport.Doctor) : "");
                    VDATE.CalcValue = MyParentReport.MAIN.VDATE.FormattedValue;
                    EMPLOYEEID.CalcValue = @"";
                    ENAME.CalcValue = (dataset_GetAvailableToWorkReport != null ? Globals.ToStringCore(dataset_GetAvailableToWorkReport.Name) : "") + @" " + (dataset_GetAvailableToWorkReport != null ? Globals.ToStringCore(dataset_GetAvailableToWorkReport.Surname) : "");
                    HOSPITALNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","XXXXXX");
                    return new TTReportObject[] { NewField1661,NewField1561,NewField141,NewField1271,NewField172,LABEL114211,NewField11401,NewField11661,NewField1141,NewField11721,NewField110411,NewField120411,NewField1114021,NewField1371,NewField12721,NewField112721,ANALYSIS,TREATMENT,DISPATCH,TREATMENTTERMINATIONDATE,PROPERWORKDATE,SERIAL,NO,PDNO,OBJECTID,DOCTOR,VDATE,EMPLOYEEID,ENAME,HOSPITALNAME};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string objectID = this.OBJECTID.CalcValue;
            AvailableToWorkReport avr = (AvailableToWorkReport)context.GetObject(new Guid(objectID),"AvailableToWorkReport");            
            
            foreach(PatientExamination pe in avr.Episode.PatientExaminations)
            {
                if(pe.CurrentStateDefID != PatientExamination.States.Cancelled)
                {
                    this.PDNO.CalcValue = pe.ProtocolNo.ToString();
                    this.VDATE.CalcValue = pe.RequestDate.ToString();
                }
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

        public AvailableToWorkReportReport()
        {
            MASTER = new MASTERGroup(this,"MASTER");
            MAIN = new MAINGroup(MASTER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "AVAILABLETOWORKREPORTREPORT";
            Caption = "Hizmet Akdiyle Çalışanlar İçin Çalışabilir Kağıdı";
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