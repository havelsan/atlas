
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
    /// İş Göremezlik Belgesi
    /// </summary>
    public partial class UnavailableToWorkReportReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MASTERGroup : TTReportGroup
        {
            public UnavailableToWorkReportReport MyParentReport
            {
                get { return (UnavailableToWorkReportReport)ParentReport; }
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
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportShape NewRect1 { get {return Header().NewRect1;} }
            public TTReportShape NewRect11 { get {return Header().NewRect11;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportField NewField11651 { get {return Header().NewField11651;} }
            public TTReportField NewField115611 { get {return Header().NewField115611;} }
            public TTReportField NewField1116511 { get {return Header().NewField1116511;} }
            public TTReportField NewField11156111 { get {return Header().NewField11156111;} }
            public TTReportField NewField11156112 { get {return Header().NewField11156112;} }
            public TTReportField NewField11156113 { get {return Header().NewField11156113;} }
            public TTReportField NewField11156114 { get {return Header().NewField11156114;} }
            public TTReportField NewField11156115 { get {return Header().NewField11156115;} }
            public TTReportField NewField11156116 { get {return Header().NewField11156116;} }
            public TTReportField NewField151165111 { get {return Header().NewField151165111;} }
            public TTReportField NewField151165112 { get {return Header().NewField151165112;} }
            public TTReportField NewField1111561151 { get {return Header().NewField1111561151;} }
            public TTReportField NewField141165111 { get {return Header().NewField141165111;} }
            public TTReportField NewField1111561152 { get {return Header().NewField1111561152;} }
            public TTReportField NewField1111561141 { get {return Header().NewField1111561141;} }
            public TTReportField HOSPITALNAME1 { get {return Header().HOSPITALNAME1;} }
            public TTReportField MRESOURCE { get {return Header().MRESOURCE;} }
            public TTReportField RDATE { get {return Header().RDATE;} }
            public TTReportField PDNO { get {return Header().PDNO;} }
            public TTReportField NAME { get {return Header().NAME;} }
            public TTReportField SURNAME { get {return Header().SURNAME;} }
            public TTReportField EMPLOYEEID { get {return Header().EMPLOYEEID;} }
            public TTReportField REFNO { get {return Header().REFNO;} }
            public TTReportField ADDRESS { get {return Header().ADDRESS;} }
            public TTReportField HPHONE { get {return Header().HPHONE;} }
            public TTReportField OBJECTID { get {return Header().OBJECTID;} }
            public TTReportField NewField11156117 { get {return Footer().NewField11156117;} }
            public TTReportField BASLIK1 { get {return Footer().BASLIK1;} }
            public TTReportField BASLIK11 { get {return Footer().BASLIK11;} }
            public TTReportField BASLIK12 { get {return Footer().BASLIK12;} }
            public TTReportField BASLIK13 { get {return Footer().BASLIK13;} }
            public TTReportField BASLIK131 { get {return Footer().BASLIK131;} }
            public TTReportField ASTARTDATE { get {return Footer().ASTARTDATE;} }
            public TTReportField AENDDATE { get {return Footer().AENDDATE;} }
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
                list[0] = new TTReportNqlData<UnavailableToWorkReport.GetUnavailableToWorkReport_Class>("GetUnavailableToWorkReport", UnavailableToWorkReport.GetUnavailableToWorkReport((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public UnavailableToWorkReportReport MyParentReport
                {
                    get { return (UnavailableToWorkReportReport)ParentReport; }
                }
                
                public TTReportField BASLIK;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine2;
                public TTReportShape NewLine13;
                public TTReportShape NewRect1;
                public TTReportShape NewRect11;
                public TTReportShape NewLine12;
                public TTReportField NewField11651;
                public TTReportField NewField115611;
                public TTReportField NewField1116511;
                public TTReportField NewField11156111;
                public TTReportField NewField11156112;
                public TTReportField NewField11156113;
                public TTReportField NewField11156114;
                public TTReportField NewField11156115;
                public TTReportField NewField11156116;
                public TTReportField NewField151165111;
                public TTReportField NewField151165112;
                public TTReportField NewField1111561151;
                public TTReportField NewField141165111;
                public TTReportField NewField1111561152;
                public TTReportField NewField1111561141;
                public TTReportField HOSPITALNAME1;
                public TTReportField MRESOURCE;
                public TTReportField RDATE;
                public TTReportField PDNO;
                public TTReportField NAME;
                public TTReportField SURNAME;
                public TTReportField EMPLOYEEID;
                public TTReportField REFNO;
                public TTReportField ADDRESS;
                public TTReportField HPHONE;
                public TTReportField OBJECTID; 
                public MASTERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 70;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 6, 165, 11, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASLIK.TextFont.Name = "Calibri";
                    BASLIK.TextFont.Size = 9;
                    BASLIK.TextFont.Bold = true;
                    BASLIK.Value = @"İŞ GÖREMEZLİK BELGESİ";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 42, 206, 42, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 59, 206, 59, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 74, 14, 74, 59, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 170, 14, 170, 42, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 10, 13, 207, 70, false);
                    NewRect1.Name = "NewRect1";
                    NewRect1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect1.FillStyle = FillStyleConstants.vbFSTransparent;

                    NewRect11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 11, 14, 206, 69, false);
                    NewRect11.Name = "NewRect11";
                    NewRect11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect11.FillStyle = FillStyleConstants.vbFSTransparent;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 130, 14, 130, 59, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11651 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 16, 38, 21, false);
                    NewField11651.Name = "NewField11651";
                    NewField11651.TextFont.Name = "Calibri";
                    NewField11651.TextFont.Size = 9;
                    NewField11651.TextFont.Bold = true;
                    NewField11651.Value = @"(1)SAĞLIK TESİSİ:";

                    NewField115611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 16, 116, 21, false);
                    NewField115611.Name = "NewField115611";
                    NewField115611.TextFont.Name = "Calibri";
                    NewField115611.TextFont.Size = 9;
                    NewField115611.TextFont.Bold = true;
                    NewField115611.Value = @"(2)DÜZENLEYEN POLİKLİNİK";

                    NewField1116511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 16, 153, 21, false);
                    NewField1116511.Name = "NewField1116511";
                    NewField1116511.TextFont.Name = "Calibri";
                    NewField1116511.TextFont.Size = 9;
                    NewField1116511.TextFont.Bold = true;
                    NewField1116511.Value = @"(3)POLİKLİNİK";

                    NewField11156111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 16, 192, 21, false);
                    NewField11156111.Name = "NewField11156111";
                    NewField11156111.TextFont.Name = "Calibri";
                    NewField11156111.TextFont.Size = 9;
                    NewField11156111.TextFont.Bold = true;
                    NewField11156111.Value = @"(4)POLİKLİNİK";

                    NewField11156112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 25, 142, 30, false);
                    NewField11156112.Name = "NewField11156112";
                    NewField11156112.TextFont.Name = "Calibri";
                    NewField11156112.TextFont.Size = 9;
                    NewField11156112.TextFont.Bold = true;
                    NewField11156112.Value = @"TARİH:";

                    NewField11156113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 25, 190, 30, false);
                    NewField11156113.Name = "NewField11156113";
                    NewField11156113.TextFont.Name = "Calibri";
                    NewField11156113.TextFont.Size = 9;
                    NewField11156113.TextFont.Bold = true;
                    NewField11156113.Value = @"DEFTER SIRA";

                    NewField11156114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 32, 177, 37, false);
                    NewField11156114.Name = "NewField11156114";
                    NewField11156114.TextFont.Name = "Calibri";
                    NewField11156114.TextFont.Size = 9;
                    NewField11156114.TextFont.Bold = true;
                    NewField11156114.Value = @"NO:";

                    NewField11156115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 43, 29, 48, false);
                    NewField11156115.Name = "NewField11156115";
                    NewField11156115.TextFont.Name = "Calibri";
                    NewField11156115.TextFont.Size = 9;
                    NewField11156115.TextFont.Bold = true;
                    NewField11156115.Value = @"(5) ADI     :";

                    NewField11156116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 50, 29, 55, false);
                    NewField11156116.Name = "NewField11156116";
                    NewField11156116.TextFont.Name = "Calibri";
                    NewField11156116.TextFont.Size = 9;
                    NewField11156116.TextFont.Bold = true;
                    NewField11156116.Value = @"SOYADI:";

                    NewField151165111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 43, 96, 48, false);
                    NewField151165111.Name = "NewField151165111";
                    NewField151165111.TextFont.Name = "Calibri";
                    NewField151165111.TextFont.Size = 9;
                    NewField151165111.TextFont.Bold = true;
                    NewField151165111.Value = @"(6) SİGORTA";

                    NewField151165112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 50, 95, 55, false);
                    NewField151165112.Name = "NewField151165112";
                    NewField151165112.TextFont.Name = "Calibri";
                    NewField151165112.TextFont.Size = 9;
                    NewField151165112.TextFont.Bold = true;
                    NewField151165112.Value = @"SİCİL NO:";

                    NewField1111561151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 43, 154, 48, false);
                    NewField1111561151.Name = "NewField1111561151";
                    NewField1111561151.TextFont.Name = "Calibri";
                    NewField1111561151.TextFont.Size = 9;
                    NewField1111561151.TextFont.Bold = true;
                    NewField1111561151.Value = @"(7) TC. KİMLİK";

                    NewField141165111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 50, 143, 55, false);
                    NewField141165111.Name = "NewField141165111";
                    NewField141165111.TextFont.Name = "Calibri";
                    NewField141165111.TextFont.Size = 9;
                    NewField141165111.TextFont.Bold = true;
                    NewField141165111.Value = @"NO:";

                    NewField1111561152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 60, 35, 65, false);
                    NewField1111561152.Name = "NewField1111561152";
                    NewField1111561152.TextFont.Name = "Calibri";
                    NewField1111561152.TextFont.Size = 9;
                    NewField1111561152.TextFont.Bold = true;
                    NewField1111561152.Value = @"(8) EV ADRESİ:";

                    NewField1111561141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 60, 154, 65, false);
                    NewField1111561141.Name = "NewField1111561141";
                    NewField1111561141.TextFont.Name = "Calibri";
                    NewField1111561141.TextFont.Size = 9;
                    NewField1111561141.TextFont.Bold = true;
                    NewField1111561141.Value = @"TEL:";

                    HOSPITALNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 21, 72, 40, false);
                    HOSPITALNAME1.Name = "HOSPITALNAME1";
                    HOSPITALNAME1.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAME1.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALNAME1.NoClip = EvetHayirEnum.ehEvet;
                    HOSPITALNAME1.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALNAME1.TextFont.Name = "Calibri";
                    HOSPITALNAME1.TextFont.Size = 9;
                    HOSPITALNAME1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"",""XXXXXX"")";

                    MRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 21, 125, 40, false);
                    MRESOURCE.Name = "MRESOURCE";
                    MRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MRESOURCE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    MRESOURCE.MultiLine = EvetHayirEnum.ehEvet;
                    MRESOURCE.NoClip = EvetHayirEnum.ehEvet;
                    MRESOURCE.WordBreak = EvetHayirEnum.ehEvet;
                    MRESOURCE.TextFont.Name = "Calibri";
                    MRESOURCE.TextFont.Size = 9;
                    MRESOURCE.Value = @"{#MRESOURCE#}";

                    RDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 25, 169, 30, false);
                    RDATE.Name = "RDATE";
                    RDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RDATE.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    RDATE.TextFont.Name = "Calibri";
                    RDATE.TextFont.Size = 9;
                    RDATE.Value = @"{#RDATE#}";

                    PDNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 32, 205, 37, false);
                    PDNO.Name = "PDNO";
                    PDNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PDNO.TextFont.Name = "Calibri";
                    PDNO.TextFont.Size = 9;
                    PDNO.Value = @"";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 43, 72, 48, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.TextFont.Name = "Calibri";
                    NAME.TextFont.Size = 9;
                    NAME.Value = @"{#NAME#}";

                    SURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 50, 72, 55, false);
                    SURNAME.Name = "SURNAME";
                    SURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SURNAME.TextFont.Name = "Calibri";
                    SURNAME.TextFont.Size = 9;
                    SURNAME.Value = @"{#SURNAME#}";

                    EMPLOYEEID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 50, 129, 55, false);
                    EMPLOYEEID.Name = "EMPLOYEEID";
                    EMPLOYEEID.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMPLOYEEID.TextFont.Name = "Calibri";
                    EMPLOYEEID.TextFont.Size = 9;
                    EMPLOYEEID.Value = @"";

                    REFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 50, 195, 55, false);
                    REFNO.Name = "REFNO";
                    REFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REFNO.TextFont.Name = "Calibri";
                    REFNO.TextFont.Size = 9;
                    REFNO.Value = @"{#REFNO#}";

                    ADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 60, 143, 68, false);
                    ADDRESS.Name = "ADDRESS";
                    ADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADDRESS.MultiLine = EvetHayirEnum.ehEvet;
                    ADDRESS.NoClip = EvetHayirEnum.ehEvet;
                    ADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    ADDRESS.TextFont.Name = "Calibri";
                    ADDRESS.TextFont.Size = 9;
                    ADDRESS.Value = @"{#ADDRESS#}";

                    HPHONE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 60, 205, 65, false);
                    HPHONE.Name = "HPHONE";
                    HPHONE.FieldType = ReportFieldTypeEnum.ftVariable;
                    HPHONE.TextFont.Name = "Calibri";
                    HPHONE.TextFont.Size = 9;
                    HPHONE.Value = @"{#HPHONE#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 27, 240, 32, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.TextFormat = @"dd/MM/yyyy";
                    OBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    UnavailableToWorkReport.GetUnavailableToWorkReport_Class dataset_GetUnavailableToWorkReport = ParentGroup.rsGroup.GetCurrentRecord<UnavailableToWorkReport.GetUnavailableToWorkReport_Class>(0);
                    BASLIK.CalcValue = BASLIK.Value;
                    NewField11651.CalcValue = NewField11651.Value;
                    NewField115611.CalcValue = NewField115611.Value;
                    NewField1116511.CalcValue = NewField1116511.Value;
                    NewField11156111.CalcValue = NewField11156111.Value;
                    NewField11156112.CalcValue = NewField11156112.Value;
                    NewField11156113.CalcValue = NewField11156113.Value;
                    NewField11156114.CalcValue = NewField11156114.Value;
                    NewField11156115.CalcValue = NewField11156115.Value;
                    NewField11156116.CalcValue = NewField11156116.Value;
                    NewField151165111.CalcValue = NewField151165111.Value;
                    NewField151165112.CalcValue = NewField151165112.Value;
                    NewField1111561151.CalcValue = NewField1111561151.Value;
                    NewField141165111.CalcValue = NewField141165111.Value;
                    NewField1111561152.CalcValue = NewField1111561152.Value;
                    NewField1111561141.CalcValue = NewField1111561141.Value;
                    MRESOURCE.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.Mresource) : "");
                    RDATE.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.Rdate) : "");
                    PDNO.CalcValue = @"";
                    NAME.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.Name) : "");
                    SURNAME.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.Surname) : "");
                    EMPLOYEEID.CalcValue = @"";
                    REFNO.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.Refno) : "");
                    ADDRESS.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.Address) : "");
                    HPHONE.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.Hphone) : "");
                    OBJECTID.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.ObjectID) : "");
                    HOSPITALNAME1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","XXXXXX");
                    return new TTReportObject[] { BASLIK,NewField11651,NewField115611,NewField1116511,NewField11156111,NewField11156112,NewField11156113,NewField11156114,NewField11156115,NewField11156116,NewField151165111,NewField151165112,NewField1111561151,NewField141165111,NewField1111561152,NewField1111561141,MRESOURCE,RDATE,PDNO,NAME,SURNAME,EMPLOYEEID,REFNO,ADDRESS,HPHONE,OBJECTID,HOSPITALNAME1};
                }

                public override void RunScript()
                {
#region MASTER HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string objectID = this.OBJECTID.CalcValue;
            UnavailableToWorkReport uvr = (UnavailableToWorkReport)context.GetObject(new Guid(objectID),"UnavailableToWorkReport");            
            
            foreach(PatientExamination pe in uvr.Episode.PatientExaminations)
            {
                if(pe.CurrentStateDefID != PatientExamination.States.Cancelled)
                {
                    this.PDNO.CalcValue = pe.ProtocolNo.ToString();                    
                }
            }
#endregion MASTER HEADER_Script
                }
            }
            public partial class MASTERGroupFooter : TTReportSection
            {
                public UnavailableToWorkReportReport MyParentReport
                {
                    get { return (UnavailableToWorkReportReport)ParentReport; }
                }
                
                public TTReportField NewField11156117;
                public TTReportField BASLIK1;
                public TTReportField BASLIK11;
                public TTReportField BASLIK12;
                public TTReportField BASLIK13;
                public TTReportField BASLIK131;
                public TTReportField ASTARTDATE;
                public TTReportField AENDDATE; 
                public MASTERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 32;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11156117 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 18, 6, false);
                    NewField11156117.Name = "NewField11156117";
                    NewField11156117.TextFont.Name = "Calibri";
                    NewField11156117.TextFont.Size = 8;
                    NewField11156117.TextFont.Bold = true;
                    NewField11156117.Value = @"( IV )";

                    BASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 1, 54, 6, false);
                    BASLIK1.Name = "BASLIK1";
                    BASLIK1.TextFont.Name = "Calibri";
                    BASLIK1.TextFont.Bold = true;
                    BASLIK1.Value = @"Sigortalı ";

                    BASLIK11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 1, 83, 6, false);
                    BASLIK11.Name = "BASLIK11";
                    BASLIK11.TextFont.Name = "Calibri";
                    BASLIK11.TextFont.Bold = true;
                    BASLIK11.Value = @"-";

                    BASLIK12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 1, 184, 6, false);
                    BASLIK12.Name = "BASLIK12";
                    BASLIK12.TextFont.Name = "Calibri";
                    BASLIK12.TextFont.Bold = true;
                    BASLIK12.Value = @"tarihleri arasında iş yerinde çalışmamıştır. İşveren";

                    BASLIK13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 9, 61, 14, false);
                    BASLIK13.Name = "BASLIK13";
                    BASLIK13.TextFont.Name = "Calibri";
                    BASLIK13.TextFont.Bold = true;
                    BASLIK13.Value = @"İmza ve kaşe";

                    BASLIK131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 9, 127, 14, false);
                    BASLIK131.Name = "BASLIK131";
                    BASLIK131.TextFont.Name = "Calibri";
                    BASLIK131.TextFont.Bold = true;
                    BASLIK131.Value = @"İmza ve kaşe";

                    ASTARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 1, 80, 6, false);
                    ASTARTDATE.Name = "ASTARTDATE";
                    ASTARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ASTARTDATE.TextFormat = @"dd/MM/yy";
                    ASTARTDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ASTARTDATE.TextFont.Name = "Calibri";
                    ASTARTDATE.TextFont.Size = 9;
                    ASTARTDATE.Value = @"{#ABSENCESTARTDATE#}";

                    AENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 1, 110, 6, false);
                    AENDDATE.Name = "AENDDATE";
                    AENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    AENDDATE.TextFormat = @"dd/MM/yy";
                    AENDDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AENDDATE.TextFont.Name = "Calibri";
                    AENDDATE.TextFont.Size = 9;
                    AENDDATE.Value = @"{#ABSENCEENDDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    UnavailableToWorkReport.GetUnavailableToWorkReport_Class dataset_GetUnavailableToWorkReport = ParentGroup.rsGroup.GetCurrentRecord<UnavailableToWorkReport.GetUnavailableToWorkReport_Class>(0);
                    NewField11156117.CalcValue = NewField11156117.Value;
                    BASLIK1.CalcValue = BASLIK1.Value;
                    BASLIK11.CalcValue = BASLIK11.Value;
                    BASLIK12.CalcValue = BASLIK12.Value;
                    BASLIK13.CalcValue = BASLIK13.Value;
                    BASLIK131.CalcValue = BASLIK131.Value;
                    ASTARTDATE.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.AbsenceStartDate) : "");
                    AENDDATE.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.AbsenceEndDate) : "");
                    return new TTReportObject[] { NewField11156117,BASLIK1,BASLIK11,BASLIK12,BASLIK13,BASLIK131,ASTARTDATE,AENDDATE};
                }
            }

        }

        public MASTERGroup MASTER;

        public partial class MAINGroup : TTReportGroup
        {
            public UnavailableToWorkReportReport MyParentReport
            {
                get { return (UnavailableToWorkReportReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine15 { get {return Body().NewLine15;} }
            public TTReportShape NewLine16 { get {return Body().NewLine16;} }
            public TTReportShape NewLine161 { get {return Body().NewLine161;} }
            public TTReportShape NewLine141 { get {return Body().NewLine141;} }
            public TTReportShape NewRect112 { get {return Body().NewRect112;} }
            public TTReportShape NewRect1111 { get {return Body().NewRect1111;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportShape NewLine131 { get {return Body().NewLine131;} }
            public TTReportShape NewLine162 { get {return Body().NewLine162;} }
            public TTReportShape NewLine1261 { get {return Body().NewLine1261;} }
            public TTReportShape NewLine1141 { get {return Body().NewLine1141;} }
            public TTReportField NewField1116511 { get {return Body().NewField1116511;} }
            public TTReportField NewField11156111 { get {return Body().NewField11156111;} }
            public TTReportField NewField115611 { get {return Body().NewField115611;} }
            public TTReportField NewField1116512 { get {return Body().NewField1116512;} }
            public TTReportField NewField12156111 { get {return Body().NewField12156111;} }
            public TTReportField NewField111165121 { get {return Body().NewField111165121;} }
            public TTReportField NewField1121561111 { get {return Body().NewField1121561111;} }
            public TTReportField NewField1121561112 { get {return Body().NewField1121561112;} }
            public TTReportField NewField115612 { get {return Body().NewField115612;} }
            public TTReportField NewField1216511 { get {return Body().NewField1216511;} }
            public TTReportField NewField1216512 { get {return Body().NewField1216512;} }
            public TTReportField NewField111165111 { get {return Body().NewField111165111;} }
            public TTReportField NewField1111561111 { get {return Body().NewField1111561111;} }
            public TTReportField NewField111165112 { get {return Body().NewField111165112;} }
            public TTReportField NewField115613 { get {return Body().NewField115613;} }
            public TTReportField NewField1316511 { get {return Body().NewField1316511;} }
            public TTReportField NewField1211561111 { get {return Body().NewField1211561111;} }
            public TTReportField NewField1211561112 { get {return Body().NewField1211561112;} }
            public TTReportField NewField151165111 { get {return Body().NewField151165111;} }
            public TTReportField NewField161165111 { get {return Body().NewField161165111;} }
            public TTReportField NewField1111561161 { get {return Body().NewField1111561161;} }
            public TTReportField NewField1111561162 { get {return Body().NewField1111561162;} }
            public TTReportField NewField1111561163 { get {return Body().NewField1111561163;} }
            public TTReportField NewField111165113 { get {return Body().NewField111165113;} }
            public TTReportField NewField111165114 { get {return Body().NewField111165114;} }
            public TTReportField NewField1111561151 { get {return Body().NewField1111561151;} }
            public TTReportField NewField1111561164 { get {return Body().NewField1111561164;} }
            public TTReportField NewField1111561152 { get {return Body().NewField1111561152;} }
            public TTReportField NewField11156112 { get {return Body().NewField11156112;} }
            public TTReportField NewField111165115 { get {return Body().NewField111165115;} }
            public TTReportField NewField115614 { get {return Body().NewField115614;} }
            public TTReportField NewField1111561112 { get {return Body().NewField1111561112;} }
            public TTReportField NewField11156121 { get {return Body().NewField11156121;} }
            public TTReportField NewField1111561113 { get {return Body().NewField1111561113;} }
            public TTReportField NewField1111561114 { get {return Body().NewField1111561114;} }
            public TTReportField NewField1111561115 { get {return Body().NewField1111561115;} }
            public TTReportField NewField1316512 { get {return Body().NewField1316512;} }
            public TTReportField NewField11156131 { get {return Body().NewField11156131;} }
            public TTReportField NewField112165111 { get {return Body().NewField112165111;} }
            public TTReportField NewField1111561116 { get {return Body().NewField1111561116;} }
            public TTReportField NewField1111561117 { get {return Body().NewField1111561117;} }
            public TTReportField NewField1311561111 { get {return Body().NewField1311561111;} }
            public TTReportField NewField11156122 { get {return Body().NewField11156122;} }
            public TTReportField NewField1111561153 { get {return Body().NewField1111561153;} }
            public TTReportField NewField1111561165 { get {return Body().NewField1111561165;} }
            public TTReportField NewField1111561166 { get {return Body().NewField1111561166;} }
            public TTReportField NewField1111561167 { get {return Body().NewField1111561167;} }
            public TTReportField NewField1111561168 { get {return Body().NewField1111561168;} }
            public TTReportField NewField12156121 { get {return Body().NewField12156121;} }
            public TTReportField NewField1411561111 { get {return Body().NewField1411561111;} }
            public TTReportField NewField1111561169 { get {return Body().NewField1111561169;} }
            public TTReportField NewField1111561170 { get {return Body().NewField1111561170;} }
            public TTReportField NewField1111561171 { get {return Body().NewField1111561171;} }
            public TTReportField EXCUSE1 { get {return Body().EXCUSE1;} }
            public TTReportField DIAGNOSIS1 { get {return Body().DIAGNOSIS1;} }
            public TTReportField RESSTARTDATE1 { get {return Body().RESSTARTDATE1;} }
            public TTReportField RESENDDATE1 { get {return Body().RESENDDATE1;} }
            public TTReportField SITUATIONDATE1 { get {return Body().SITUATIONDATE1;} }
            public TTReportField ADMISSIONDATE1 { get {return Body().ADMISSIONDATE1;} }
            public TTReportField DISCHARGEDATE1 { get {return Body().DISCHARGEDATE1;} }
            public TTReportField RESSTARTDATE2 { get {return Body().RESSTARTDATE2;} }
            public TTReportField RESENDDATE2 { get {return Body().RESENDDATE2;} }
            public TTReportField SITUATIONDATE2 { get {return Body().SITUATIONDATE2;} }
            public TTReportField ADMISSIONDATE2 { get {return Body().ADMISSIONDATE2;} }
            public TTReportField DISCHARGEDATE2 { get {return Body().DISCHARGEDATE2;} }
            public TTReportField DOCTOR1 { get {return Body().DOCTOR1;} }
            public TTReportField DOCTORID1 { get {return Body().DOCTORID1;} }
            public TTReportField DNO1 { get {return Body().DNO1;} }
            public TTReportField DOCTOR2 { get {return Body().DOCTOR2;} }
            public TTReportField DOCTORID2 { get {return Body().DOCTORID2;} }
            public TTReportField DNO2 { get {return Body().DNO2;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField DIAGNOSIS2 { get {return Body().DIAGNOSIS2;} }
            public TTReportShape NewRect11 { get {return Body().NewRect11;} }
            public TTReportShape NewRect111 { get {return Body().NewRect111;} }
            public TTReportField EXCUSE2 { get {return Body().EXCUSE2;} }
            public TTReportField EXCUSE3 { get {return Body().EXCUSE3;} }
            public TTReportField EXCUSE4 { get {return Body().EXCUSE4;} }
            public TTReportField SITUATION11 { get {return Body().SITUATION11;} }
            public TTReportField SITUATION12 { get {return Body().SITUATION12;} }
            public TTReportField SITUATION21 { get {return Body().SITUATION21;} }
            public TTReportField SITUATION22 { get {return Body().SITUATION22;} }
            public TTReportField MedulaTakipNoLabel { get {return Body().MedulaTakipNoLabel;} }
            public TTReportField RaporSiraNoLabel { get {return Body().RaporSiraNoLabel;} }
            public TTReportField MEDULATAKIPNO { get {return Body().MEDULATAKIPNO;} }
            public TTReportField RAPORSIRANO { get {return Body().RAPORSIRANO;} }
            public TTReportField MedulaTakipNoLabel1 { get {return Body().MedulaTakipNoLabel1;} }
            public TTReportField RaporSiraNoLabel1 { get {return Body().RaporSiraNoLabel1;} }
            public TTReportField MEDULATAKIPNO1 { get {return Body().MEDULATAKIPNO1;} }
            public TTReportField RAPORSIRANO1 { get {return Body().RAPORSIRANO1;} }
            public TTReportField NewField1316513 { get {return Body().NewField1316513;} }
            public TTReportField SITUATION13 { get {return Body().SITUATION13;} }
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
                list[0] = new TTReportNqlData<UnavailableToWorkReport.GetUnavailableToWorkReport_Class>("GetUnavailableToWorkReport", UnavailableToWorkReport.GetUnavailableToWorkReport((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public UnavailableToWorkReportReport MyParentReport
                {
                    get { return (UnavailableToWorkReportReport)ParentReport; }
                }
                
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine1;
                public TTReportShape NewLine14;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16;
                public TTReportShape NewLine161;
                public TTReportShape NewLine141;
                public TTReportShape NewRect112;
                public TTReportShape NewRect1111;
                public TTReportShape NewLine121;
                public TTReportShape NewLine131;
                public TTReportShape NewLine162;
                public TTReportShape NewLine1261;
                public TTReportShape NewLine1141;
                public TTReportField NewField1116511;
                public TTReportField NewField11156111;
                public TTReportField NewField115611;
                public TTReportField NewField1116512;
                public TTReportField NewField12156111;
                public TTReportField NewField111165121;
                public TTReportField NewField1121561111;
                public TTReportField NewField1121561112;
                public TTReportField NewField115612;
                public TTReportField NewField1216511;
                public TTReportField NewField1216512;
                public TTReportField NewField111165111;
                public TTReportField NewField1111561111;
                public TTReportField NewField111165112;
                public TTReportField NewField115613;
                public TTReportField NewField1316511;
                public TTReportField NewField1211561111;
                public TTReportField NewField1211561112;
                public TTReportField NewField151165111;
                public TTReportField NewField161165111;
                public TTReportField NewField1111561161;
                public TTReportField NewField1111561162;
                public TTReportField NewField1111561163;
                public TTReportField NewField111165113;
                public TTReportField NewField111165114;
                public TTReportField NewField1111561151;
                public TTReportField NewField1111561164;
                public TTReportField NewField1111561152;
                public TTReportField NewField11156112;
                public TTReportField NewField111165115;
                public TTReportField NewField115614;
                public TTReportField NewField1111561112;
                public TTReportField NewField11156121;
                public TTReportField NewField1111561113;
                public TTReportField NewField1111561114;
                public TTReportField NewField1111561115;
                public TTReportField NewField1316512;
                public TTReportField NewField11156131;
                public TTReportField NewField112165111;
                public TTReportField NewField1111561116;
                public TTReportField NewField1111561117;
                public TTReportField NewField1311561111;
                public TTReportField NewField11156122;
                public TTReportField NewField1111561153;
                public TTReportField NewField1111561165;
                public TTReportField NewField1111561166;
                public TTReportField NewField1111561167;
                public TTReportField NewField1111561168;
                public TTReportField NewField12156121;
                public TTReportField NewField1411561111;
                public TTReportField NewField1111561169;
                public TTReportField NewField1111561170;
                public TTReportField NewField1111561171;
                public TTReportField EXCUSE1;
                public TTReportField DIAGNOSIS1;
                public TTReportField RESSTARTDATE1;
                public TTReportField RESENDDATE1;
                public TTReportField SITUATIONDATE1;
                public TTReportField ADMISSIONDATE1;
                public TTReportField DISCHARGEDATE1;
                public TTReportField RESSTARTDATE2;
                public TTReportField RESENDDATE2;
                public TTReportField SITUATIONDATE2;
                public TTReportField ADMISSIONDATE2;
                public TTReportField DISCHARGEDATE2;
                public TTReportField DOCTOR1;
                public TTReportField DOCTORID1;
                public TTReportField DNO1;
                public TTReportField DOCTOR2;
                public TTReportField DOCTORID2;
                public TTReportField DNO2;
                public TTReportField OBJECTID;
                public TTReportField DIAGNOSIS2;
                public TTReportShape NewRect11;
                public TTReportShape NewRect111;
                public TTReportField EXCUSE2;
                public TTReportField EXCUSE3;
                public TTReportField EXCUSE4;
                public TTReportField SITUATION11;
                public TTReportField SITUATION12;
                public TTReportField SITUATION21;
                public TTReportField SITUATION22;
                public TTReportField MedulaTakipNoLabel;
                public TTReportField RaporSiraNoLabel;
                public TTReportField MEDULATAKIPNO;
                public TTReportField RAPORSIRANO;
                public TTReportField MedulaTakipNoLabel1;
                public TTReportField RaporSiraNoLabel1;
                public TTReportField MEDULATAKIPNO1;
                public TTReportField RAPORSIRANO1;
                public TTReportField NewField1316513;
                public TTReportField SITUATION13; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 171;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 20, 206, 20, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 29, 206, 29, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 59, 206, 59, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 70, 7, 70, 20, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 124, 7, 124, 20, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 163, 7, 163, 20, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 116, 29, 116, 59, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 129, 59, 129, 89, false);
                    NewLine161.Name = "NewLine161";
                    NewLine161.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 74, 68, 74, 78, false);
                    NewLine141.Name = "NewLine141";
                    NewLine141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewRect112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 10, 95, 207, 170, false);
                    NewRect112.Name = "NewRect112";
                    NewRect112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect112.FillStyle = FillStyleConstants.vbFSTransparent;

                    NewRect1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 11, 96, 206, 169, false);
                    NewRect1111.Name = "NewRect1111";
                    NewRect1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect1111.FillStyle = FillStyleConstants.vbFSTransparent;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 110, 206, 110, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 141, 206, 141, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine162 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 116, 110, 116, 141, false);
                    NewLine162.Name = "NewLine162";
                    NewLine162.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1261 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 140, 141, 140, 169, false);
                    NewLine1261.Name = "NewLine1261";
                    NewLine1261.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 74, 151, 74, 161, false);
                    NewLine1141.Name = "NewLine1141";
                    NewLine1141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1116511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 18, 6, false);
                    NewField1116511.Name = "NewField1116511";
                    NewField1116511.TextFont.Name = "Calibri";
                    NewField1116511.TextFont.Size = 8;
                    NewField1116511.TextFont.Bold = true;
                    NewField1116511.Value = @"( II )";

                    NewField11156111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 1, 165, 6, false);
                    NewField11156111.Name = "NewField11156111";
                    NewField11156111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11156111.TextFont.Name = "Calibri";
                    NewField11156111.TextFont.Size = 8;
                    NewField11156111.TextFont.Bold = true;
                    NewField11156111.Value = @"BİRİNCİ ON GÜNE KADAR AYAKTAN İSTİRATLER İÇİN DOLDURULACAK BÖLÜM";

                    NewField115611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 11, 32, 16, false);
                    NewField115611.Name = "NewField115611";
                    NewField115611.TextFont.Name = "Calibri";
                    NewField115611.TextFont.Size = 9;
                    NewField115611.TextFont.Bold = true;
                    NewField115611.Value = @"(9) İŞ KAZASI";

                    NewField1116512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 11, 105, 16, false);
                    NewField1116512.Name = "NewField1116512";
                    NewField1116512.TextFont.Name = "Calibri";
                    NewField1116512.TextFont.Size = 9;
                    NewField1116512.TextFont.Bold = true;
                    NewField1116512.Value = @"(10) MESLEK HASTALIĞI";

                    NewField12156111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 11, 146, 16, false);
                    NewField12156111.Name = "NewField12156111";
                    NewField12156111.TextFont.Name = "Calibri";
                    NewField12156111.TextFont.Size = 9;
                    NewField12156111.TextFont.Bold = true;
                    NewField12156111.Value = @"(11) HASTALIK";

                    NewField111165121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 11, 182, 16, false);
                    NewField111165121.Name = "NewField111165121";
                    NewField111165121.TextFont.Name = "Calibri";
                    NewField111165121.TextFont.Size = 9;
                    NewField111165121.TextFont.Bold = true;
                    NewField111165121.Value = @"(12) ANALIK";

                    NewField1121561111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 21, 31, 26, false);
                    NewField1121561111.Name = "NewField1121561111";
                    NewField1121561111.TextFont.Name = "Calibri";
                    NewField1121561111.TextFont.Size = 9;
                    NewField1121561111.TextFont.Bold = true;
                    NewField1121561111.Value = @"(13) TEŞHİS:";

                    NewField1121561112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 31, 19, 36, false);
                    NewField1121561112.Name = "NewField1121561112";
                    NewField1121561112.TextFont.Name = "Calibri";
                    NewField1121561112.TextFont.Size = 9;
                    NewField1121561112.TextFont.Bold = true;
                    NewField1121561112.Value = @"(14)";

                    NewField115612 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 31, 124, 36, false);
                    NewField115612.Name = "NewField115612";
                    NewField115612.TextFont.Name = "Calibri";
                    NewField115612.TextFont.Size = 9;
                    NewField115612.TextFont.Bold = true;
                    NewField115612.Value = @"(15)";

                    NewField1216511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 61, 19, 66, false);
                    NewField1216511.Name = "NewField1216511";
                    NewField1216511.TextFont.Name = "Calibri";
                    NewField1216511.TextFont.Size = 9;
                    NewField1216511.TextFont.Bold = true;
                    NewField1216511.Value = @"(16)";

                    NewField1216512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 61, 136, 66, false);
                    NewField1216512.Name = "NewField1216512";
                    NewField1216512.TextFont.Name = "Calibri";
                    NewField1216512.TextFont.Size = 9;
                    NewField1216512.TextFont.Bold = true;
                    NewField1216512.Value = @"(17)";

                    NewField111165111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 31, 50, 36, false);
                    NewField111165111.Name = "NewField111165111";
                    NewField111165111.TextFont.Name = "Calibri";
                    NewField111165111.TextFont.Size = 9;
                    NewField111165111.TextFont.Bold = true;
                    NewField111165111.Value = @"den";

                    NewField1111561111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 31, 112, 36, false);
                    NewField1111561111.Name = "NewField1111561111";
                    NewField1111561111.TextFont.Name = "Calibri";
                    NewField1111561111.TextFont.Size = 9;
                    NewField1111561111.TextFont.Bold = true;
                    NewField1111561111.Value = @"tarihine kadar istirahatlıdır.";

                    NewField111165112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 38, 56, 43, false);
                    NewField111165112.Name = "NewField111165112";
                    NewField111165112.TextFont.Name = "Calibri";
                    NewField111165112.TextFont.Size = 9;
                    NewField111165112.TextFont.Bold = true;
                    NewField111165112.Value = @"tarihinde";

                    NewField115613 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 37, 70, 42, false);
                    NewField115613.Name = "NewField115613";
                    NewField115613.TextFont.Name = "Calibri";
                    NewField115613.TextFont.Size = 12;
                    NewField115613.TextFont.Bold = true;
                    NewField115613.Value = @"çalışır";

                    NewField1316511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 37, 94, 42, false);
                    NewField1316511.Name = "NewField1316511";
                    NewField1316511.TextFont.Name = "Calibri";
                    NewField1316511.TextFont.Size = 12;
                    NewField1316511.TextFont.Bold = true;
                    NewField1316511.Value = @"kontrol";

                    NewField1211561111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 31, 158, 36, false);
                    NewField1211561111.Name = "NewField1211561111";
                    NewField1211561111.TextFont.Name = "Calibri";
                    NewField1211561111.TextFont.Size = 9;
                    NewField1211561111.TextFont.Bold = true;
                    NewField1211561111.Value = @"XXXXXXye Yatış Tarihi   :";

                    NewField1211561112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 38, 158, 43, false);
                    NewField1211561112.Name = "NewField1211561112";
                    NewField1211561112.TextFont.Name = "Calibri";
                    NewField1211561112.TextFont.Size = 9;
                    NewField1211561112.TextFont.Bold = true;
                    NewField1211561112.Value = @"XXXXXXden Çıkış Tarihi :";

                    NewField151165111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 67, 33, 72, false);
                    NewField151165111.Name = "NewField151165111";
                    NewField151165111.TextFont.Name = "Calibri";
                    NewField151165111.TextFont.Size = 9;
                    NewField151165111.TextFont.Bold = true;
                    NewField151165111.Value = @"ADI SOYADI  :";

                    NewField161165111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 72, 32, 77, false);
                    NewField161165111.Name = "NewField161165111";
                    NewField161165111.TextFont.Name = "Calibri";
                    NewField161165111.TextFont.Size = 9;
                    NewField161165111.TextFont.Bold = true;
                    NewField161165111.Value = @"SİCİL NO       :";

                    NewField1111561161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 77, 33, 82, false);
                    NewField1111561161.Name = "NewField1111561161";
                    NewField1111561161.TextFont.Name = "Calibri";
                    NewField1111561161.TextFont.Size = 9;
                    NewField1111561161.TextFont.Bold = true;
                    NewField1111561161.Value = @"DİPLOMA";

                    NewField1111561162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 82, 32, 87, false);
                    NewField1111561162.Name = "NewField1111561162";
                    NewField1111561162.TextFont.Name = "Calibri";
                    NewField1111561162.TextFont.Size = 9;
                    NewField1111561162.TextFont.Bold = true;
                    NewField1111561162.Value = @"TESCİL NO    :";

                    NewField1111561163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 67, 110, 72, false);
                    NewField1111561163.Name = "NewField1111561163";
                    NewField1111561163.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111561163.TextFont.Name = "Calibri";
                    NewField1111561163.TextFont.Size = 9;
                    NewField1111561163.TextFont.Bold = true;
                    NewField1111561163.Value = @"İMZASI";

                    NewField111165113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 60, 104, 65, false);
                    NewField111165113.Name = "NewField111165113";
                    NewField111165113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111165113.TextFont.Name = "Calibri";
                    NewField111165113.TextFont.Size = 8;
                    NewField111165113.TextFont.Bold = true;
                    NewField111165113.Value = @"DÜZENLEYEN HEKİMİN";

                    NewField111165114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 60, 183, 65, false);
                    NewField111165114.Name = "NewField111165114";
                    NewField111165114.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111165114.TextFont.Name = "Calibri";
                    NewField111165114.TextFont.Size = 8;
                    NewField111165114.TextFont.Bold = true;
                    NewField111165114.Value = @"ONAY";

                    NewField1111561151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 67, 150, 72, false);
                    NewField1111561151.Name = "NewField1111561151";
                    NewField1111561151.TextFont.Name = "Calibri";
                    NewField1111561151.TextFont.Size = 9;
                    NewField1111561151.TextFont.Bold = true;
                    NewField1111561151.Value = @"İSİM KAŞESİ  :";

                    NewField1111561164 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 73, 150, 78, false);
                    NewField1111561164.Name = "NewField1111561164";
                    NewField1111561164.TextFont.Name = "Calibri";
                    NewField1111561164.TextFont.Size = 9;
                    NewField1111561164.TextFont.Bold = true;
                    NewField1111561164.Value = @"MÜHÜR        :";

                    NewField1111561152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 79, 150, 84, false);
                    NewField1111561152.Name = "NewField1111561152";
                    NewField1111561152.TextFont.Name = "Calibri";
                    NewField1111561152.TextFont.Size = 9;
                    NewField1111561152.TextFont.Bold = true;
                    NewField1111561152.Value = @"İMZA             :";

                    NewField11156112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 91, 18, 94, false);
                    NewField11156112.Name = "NewField11156112";
                    NewField11156112.TextFont.Name = "Calibri";
                    NewField11156112.TextFont.Size = 8;
                    NewField11156112.TextFont.Bold = true;
                    NewField11156112.Value = @"( III )";

                    NewField111165115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 91, 165, 94, false);
                    NewField111165115.Name = "NewField111165115";
                    NewField111165115.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111165115.TextFont.Name = "Calibri";
                    NewField111165115.TextFont.Size = 8;
                    NewField111165115.TextFont.Bold = true;
                    NewField111165115.Value = @"İKİNCİ ON GÜNE KADAR AYAKTAN İSTİRATLER İÇİN DOLDURULAÇAK BÖLÜM";

                    NewField115614 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 102, 31, 107, false);
                    NewField115614.Name = "NewField115614";
                    NewField115614.TextFont.Name = "Calibri";
                    NewField115614.TextFont.Size = 9;
                    NewField115614.TextFont.Bold = true;
                    NewField115614.Value = @"(18)TEŞHİS:";

                    NewField1111561112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 112, 58, 117, false);
                    NewField1111561112.Name = "NewField1111561112";
                    NewField1111561112.TextFont.Name = "Calibri";
                    NewField1111561112.TextFont.Size = 9;
                    NewField1111561112.TextFont.Bold = true;
                    NewField1111561112.Value = @"tarihinden";

                    NewField11156121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 112, 19, 117, false);
                    NewField11156121.Name = "NewField11156121";
                    NewField11156121.TextFont.Name = "Calibri";
                    NewField11156121.TextFont.Size = 9;
                    NewField11156121.TextFont.Bold = true;
                    NewField11156121.Value = @"(19)";

                    NewField1111561113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 112, 114, 117, false);
                    NewField1111561113.Name = "NewField1111561113";
                    NewField1111561113.TextFont.Name = "Calibri";
                    NewField1111561113.TextFont.Size = 9;
                    NewField1111561113.TextFont.Bold = true;
                    NewField1111561113.Value = @"tarihine kadar istirahatın";

                    NewField1111561114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 118, 35, 123, false);
                    NewField1111561114.Name = "NewField1111561114";
                    NewField1111561114.TextFont.Name = "Calibri";
                    NewField1111561114.TextFont.Size = 9;
                    NewField1111561114.TextFont.Bold = true;
                    NewField1111561114.Value = @"devamına";

                    NewField1111561115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 123, 56, 128, false);
                    NewField1111561115.Name = "NewField1111561115";
                    NewField1111561115.TextFont.Name = "Calibri";
                    NewField1111561115.TextFont.Size = 9;
                    NewField1111561115.TextFont.Bold = true;
                    NewField1111561115.Value = @"tarihinde";

                    NewField1316512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 122, 70, 127, false);
                    NewField1316512.Name = "NewField1316512";
                    NewField1316512.TextFont.Name = "Calibri";
                    NewField1316512.TextFont.Size = 12;
                    NewField1316512.TextFont.Bold = true;
                    NewField1316512.Value = @"çalışır";

                    NewField11156131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 122, 94, 127, false);
                    NewField11156131.Name = "NewField11156131";
                    NewField11156131.TextFont.Name = "Calibri";
                    NewField11156131.TextFont.Size = 12;
                    NewField11156131.TextFont.Bold = true;
                    NewField11156131.Value = @"kontrol";

                    NewField112165111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 112, 124, 117, false);
                    NewField112165111.Name = "NewField112165111";
                    NewField112165111.TextFont.Name = "Calibri";
                    NewField112165111.TextFont.Size = 9;
                    NewField112165111.TextFont.Bold = true;
                    NewField112165111.Value = @"(20)";

                    NewField1111561116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 112, 158, 117, false);
                    NewField1111561116.Name = "NewField1111561116";
                    NewField1111561116.TextFont.Name = "Calibri";
                    NewField1111561116.TextFont.Size = 9;
                    NewField1111561116.TextFont.Bold = true;
                    NewField1111561116.Value = @"XXXXXXye Yatış Tarihi  :";

                    NewField1111561117 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 119, 158, 124, false);
                    NewField1111561117.Name = "NewField1111561117";
                    NewField1111561117.TextFont.Name = "Calibri";
                    NewField1111561117.TextFont.Size = 9;
                    NewField1111561117.TextFont.Bold = true;
                    NewField1111561117.Value = @"XXXXXXden Çıkış Tarihi:";

                    NewField1311561111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 142, 104, 147, false);
                    NewField1311561111.Name = "NewField1311561111";
                    NewField1311561111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1311561111.TextFont.Name = "Calibri";
                    NewField1311561111.TextFont.Size = 8;
                    NewField1311561111.TextFont.Bold = true;
                    NewField1311561111.Value = @"DÜZENLEYEN HEKİMİN";

                    NewField11156122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 142, 19, 147, false);
                    NewField11156122.Name = "NewField11156122";
                    NewField11156122.TextFont.Name = "Calibri";
                    NewField11156122.TextFont.Size = 9;
                    NewField11156122.TextFont.Bold = true;
                    NewField11156122.Value = @"(21)";

                    NewField1111561153 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 148, 32, 153, false);
                    NewField1111561153.Name = "NewField1111561153";
                    NewField1111561153.TextFont.Name = "Calibri";
                    NewField1111561153.TextFont.Size = 9;
                    NewField1111561153.TextFont.Bold = true;
                    NewField1111561153.Value = @"ADI SOYADI  :";

                    NewField1111561165 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 153, 32, 158, false);
                    NewField1111561165.Name = "NewField1111561165";
                    NewField1111561165.TextFont.Name = "Calibri";
                    NewField1111561165.TextFont.Size = 9;
                    NewField1111561165.TextFont.Bold = true;
                    NewField1111561165.Value = @"SİCİL NO       :";

                    NewField1111561166 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 158, 33, 164, false);
                    NewField1111561166.Name = "NewField1111561166";
                    NewField1111561166.TextFont.Name = "Calibri";
                    NewField1111561166.TextFont.Size = 9;
                    NewField1111561166.TextFont.Bold = true;
                    NewField1111561166.Value = @"DİPLOMA";

                    NewField1111561167 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 163, 32, 168, false);
                    NewField1111561167.Name = "NewField1111561167";
                    NewField1111561167.TextFont.Name = "Calibri";
                    NewField1111561167.TextFont.Size = 9;
                    NewField1111561167.TextFont.Bold = true;
                    NewField1111561167.Value = @"TESCİL NO    :";

                    NewField1111561168 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 150, 118, 155, false);
                    NewField1111561168.Name = "NewField1111561168";
                    NewField1111561168.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111561168.TextFont.Name = "Calibri";
                    NewField1111561168.TextFont.Size = 9;
                    NewField1111561168.TextFont.Bold = true;
                    NewField1111561168.Value = @"İMZASI";

                    NewField12156121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 142, 149, 147, false);
                    NewField12156121.Name = "NewField12156121";
                    NewField12156121.TextFont.Name = "Calibri";
                    NewField12156121.TextFont.Size = 9;
                    NewField12156121.TextFont.Bold = true;
                    NewField12156121.Value = @"(22)";

                    NewField1411561111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 142, 196, 147, false);
                    NewField1411561111.Name = "NewField1411561111";
                    NewField1411561111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1411561111.TextFont.Name = "Calibri";
                    NewField1411561111.TextFont.Size = 8;
                    NewField1411561111.TextFont.Bold = true;
                    NewField1411561111.Value = @"ONAY";

                    NewField1111561169 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 148, 163, 153, false);
                    NewField1111561169.Name = "NewField1111561169";
                    NewField1111561169.TextFont.Name = "Calibri";
                    NewField1111561169.TextFont.Size = 9;
                    NewField1111561169.TextFont.Bold = true;
                    NewField1111561169.Value = @"İSİM KAŞESİ   :";

                    NewField1111561170 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 154, 163, 159, false);
                    NewField1111561170.Name = "NewField1111561170";
                    NewField1111561170.TextFont.Name = "Calibri";
                    NewField1111561170.TextFont.Size = 9;
                    NewField1111561170.TextFont.Bold = true;
                    NewField1111561170.Value = @"MÜHÜR         :";

                    NewField1111561171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 160, 163, 165, false);
                    NewField1111561171.Name = "NewField1111561171";
                    NewField1111561171.TextFont.Name = "Calibri";
                    NewField1111561171.TextFont.Size = 9;
                    NewField1111561171.TextFont.Bold = true;
                    NewField1111561171.Value = @"İMZA              :";

                    EXCUSE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 10, 68, 17, false);
                    EXCUSE1.Name = "EXCUSE1";
                    EXCUSE1.DrawStyle = DrawStyleConstants.vbSolid;
                    EXCUSE1.FillStyle = FillStyleConstants.vbFSTransparent;
                    EXCUSE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXCUSE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EXCUSE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXCUSE1.TextFont.Name = "Calibri";
                    EXCUSE1.TextFont.Size = 16;
                    EXCUSE1.Value = @"";

                    DIAGNOSIS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 21, 205, 28, false);
                    DIAGNOSIS1.Name = "DIAGNOSIS1";
                    DIAGNOSIS1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSIS1.TextFont.Name = "Calibri";
                    DIAGNOSIS1.TextFont.Size = 9;
                    DIAGNOSIS1.Value = @"{#DIAGNOSISCODE#}{#DIAGNOSISNAME#}";

                    RESSTARTDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 31, 44, 36, false);
                    RESSTARTDATE1.Name = "RESSTARTDATE1";
                    RESSTARTDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESSTARTDATE1.TextFormat = @"dd/MM/yy";
                    RESSTARTDATE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RESSTARTDATE1.TextFont.Name = "Calibri";
                    RESSTARTDATE1.TextFont.Size = 9;
                    RESSTARTDATE1.Value = @"{#RESTINGSTARTDATE#}";

                    RESENDDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 31, 75, 36, false);
                    RESENDDATE1.Name = "RESENDDATE1";
                    RESENDDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESENDDATE1.TextFormat = @"dd/MM/yy";
                    RESENDDATE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RESENDDATE1.TextFont.Name = "Calibri";
                    RESENDDATE1.TextFont.Size = 9;
                    RESENDDATE1.Value = @"{#RESTINGENDDATE#}";

                    SITUATIONDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 38, 44, 43, false);
                    SITUATIONDATE1.Name = "SITUATIONDATE1";
                    SITUATIONDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SITUATIONDATE1.TextFormat = @"dd/MM/yy";
                    SITUATIONDATE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SITUATIONDATE1.TextFont.Name = "Calibri";
                    SITUATIONDATE1.TextFont.Size = 9;
                    SITUATIONDATE1.Value = @"{#SITUATIONDATE#}";

                    ADMISSIONDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 31, 196, 36, false);
                    ADMISSIONDATE1.Name = "ADMISSIONDATE1";
                    ADMISSIONDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADMISSIONDATE1.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    ADMISSIONDATE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ADMISSIONDATE1.TextFont.Name = "Calibri";
                    ADMISSIONDATE1.TextFont.Size = 9;
                    ADMISSIONDATE1.Value = @"{#ADMISSIONDATE#}";

                    DISCHARGEDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 38, 196, 43, false);
                    DISCHARGEDATE1.Name = "DISCHARGEDATE1";
                    DISCHARGEDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISCHARGEDATE1.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    DISCHARGEDATE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISCHARGEDATE1.TextFont.Name = "Calibri";
                    DISCHARGEDATE1.TextFont.Size = 9;
                    DISCHARGEDATE1.Value = @"{#DISCHARGEDATE#}";

                    RESSTARTDATE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 112, 44, 117, false);
                    RESSTARTDATE2.Name = "RESSTARTDATE2";
                    RESSTARTDATE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESSTARTDATE2.TextFormat = @"dd/MM/yy";
                    RESSTARTDATE2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RESSTARTDATE2.TextFont.Name = "Calibri";
                    RESSTARTDATE2.TextFont.Size = 9;
                    RESSTARTDATE2.Value = @"{#RESTINGSTARTDATE#}";

                    RESENDDATE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 112, 81, 117, false);
                    RESENDDATE2.Name = "RESENDDATE2";
                    RESENDDATE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESENDDATE2.TextFormat = @"dd/MM/yy";
                    RESENDDATE2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RESENDDATE2.TextFont.Name = "Calibri";
                    RESENDDATE2.TextFont.Size = 9;
                    RESENDDATE2.Value = @"{#RESTINGENDDATE#}";

                    SITUATIONDATE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 123, 45, 128, false);
                    SITUATIONDATE2.Name = "SITUATIONDATE2";
                    SITUATIONDATE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SITUATIONDATE2.TextFormat = @"dd/MM/yy";
                    SITUATIONDATE2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SITUATIONDATE2.TextFont.Name = "Calibri";
                    SITUATIONDATE2.TextFont.Size = 9;
                    SITUATIONDATE2.Value = @"{#SITUATIONDATE#}";

                    ADMISSIONDATE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 112, 196, 117, false);
                    ADMISSIONDATE2.Name = "ADMISSIONDATE2";
                    ADMISSIONDATE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADMISSIONDATE2.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    ADMISSIONDATE2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ADMISSIONDATE2.TextFont.Name = "Calibri";
                    ADMISSIONDATE2.TextFont.Size = 9;
                    ADMISSIONDATE2.Value = @"{#ADMISSIONDATE#}";

                    DISCHARGEDATE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 119, 196, 124, false);
                    DISCHARGEDATE2.Name = "DISCHARGEDATE2";
                    DISCHARGEDATE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISCHARGEDATE2.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    DISCHARGEDATE2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISCHARGEDATE2.TextFont.Name = "Calibri";
                    DISCHARGEDATE2.TextFont.Size = 9;
                    DISCHARGEDATE2.Value = @"{#DISCHARGEDATE#}";

                    DOCTOR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 67, 73, 72, false);
                    DOCTOR1.Name = "DOCTOR1";
                    DOCTOR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTOR1.TextFont.Name = "Calibri";
                    DOCTOR1.TextFont.Size = 9;
                    DOCTOR1.Value = @"{#DOCTOR#}";

                    DOCTORID1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 72, 73, 77, false);
                    DOCTORID1.Name = "DOCTORID1";
                    DOCTORID1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTORID1.TextFont.Name = "Calibri";
                    DOCTORID1.TextFont.Size = 9;
                    DOCTORID1.Value = @"{#DOCTORID#}";

                    DNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 82, 73, 87, false);
                    DNO1.Name = "DNO1";
                    DNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DNO1.TextFont.Name = "Calibri";
                    DNO1.TextFont.Size = 9;
                    DNO1.Value = @"{#DNO#}";

                    DOCTOR2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 148, 73, 153, false);
                    DOCTOR2.Name = "DOCTOR2";
                    DOCTOR2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTOR2.TextFont.Name = "Calibri";
                    DOCTOR2.TextFont.Size = 9;
                    DOCTOR2.Value = @"{#DOCTOR#}";

                    DOCTORID2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 153, 73, 158, false);
                    DOCTORID2.Name = "DOCTORID2";
                    DOCTORID2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTORID2.TextFont.Name = "Calibri";
                    DOCTORID2.TextFont.Size = 9;
                    DOCTORID2.Value = @"{#DOCTORID#}";

                    DNO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 163, 73, 168, false);
                    DNO2.Name = "DNO2";
                    DNO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DNO2.TextFont.Name = "Calibri";
                    DNO2.TextFont.Size = 9;
                    DNO2.Value = @"{#DNO#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 12, 240, 17, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.TextFormat = @"dd/MM/yyyy";
                    OBJECTID.Value = @"{#OBJECTID#}";

                    DIAGNOSIS2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 102, 205, 109, false);
                    DIAGNOSIS2.Name = "DIAGNOSIS2";
                    DIAGNOSIS2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIAGNOSIS2.TextFont.Name = "Calibri";
                    DIAGNOSIS2.TextFont.Size = 9;
                    DIAGNOSIS2.Value = @"{#DIAGNOSISCODE#}{#DIAGNOSISNAME#}";

                    NewRect11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 10, 6, 207, 90, false);
                    NewRect11.Name = "NewRect11";
                    NewRect11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect11.FillStyle = FillStyleConstants.vbFSTransparent;

                    NewRect111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 11, 7, 206, 89, false);
                    NewRect111.Name = "NewRect111";
                    NewRect111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewRect111.FillStyle = FillStyleConstants.vbFSTransparent;

                    EXCUSE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 10, 122, 17, false);
                    EXCUSE2.Name = "EXCUSE2";
                    EXCUSE2.DrawStyle = DrawStyleConstants.vbSolid;
                    EXCUSE2.FillStyle = FillStyleConstants.vbFSTransparent;
                    EXCUSE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXCUSE2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EXCUSE2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXCUSE2.TextFont.Name = "Calibri";
                    EXCUSE2.TextFont.Size = 16;
                    EXCUSE2.Value = @"";

                    EXCUSE3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 10, 161, 17, false);
                    EXCUSE3.Name = "EXCUSE3";
                    EXCUSE3.DrawStyle = DrawStyleConstants.vbSolid;
                    EXCUSE3.FillStyle = FillStyleConstants.vbFSTransparent;
                    EXCUSE3.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXCUSE3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EXCUSE3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXCUSE3.TextFont.Name = "Calibri";
                    EXCUSE3.TextFont.Size = 16;
                    EXCUSE3.Value = @"";

                    EXCUSE4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 196, 9, 203, 16, false);
                    EXCUSE4.Name = "EXCUSE4";
                    EXCUSE4.DrawStyle = DrawStyleConstants.vbSolid;
                    EXCUSE4.FillStyle = FillStyleConstants.vbFSTransparent;
                    EXCUSE4.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXCUSE4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EXCUSE4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXCUSE4.TextFont.Name = "Calibri";
                    EXCUSE4.TextFont.Size = 16;
                    EXCUSE4.Value = @"";

                    SITUATION11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 36, 78, 43, false);
                    SITUATION11.Name = "SITUATION11";
                    SITUATION11.DrawStyle = DrawStyleConstants.vbSolid;
                    SITUATION11.FillStyle = FillStyleConstants.vbFSTransparent;
                    SITUATION11.FieldType = ReportFieldTypeEnum.ftVariable;
                    SITUATION11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SITUATION11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SITUATION11.TextFont.Name = "Calibri";
                    SITUATION11.TextFont.Size = 16;
                    SITUATION11.Value = @"";

                    SITUATION12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 36, 102, 43, false);
                    SITUATION12.Name = "SITUATION12";
                    SITUATION12.DrawStyle = DrawStyleConstants.vbSolid;
                    SITUATION12.FillStyle = FillStyleConstants.vbFSTransparent;
                    SITUATION12.FieldType = ReportFieldTypeEnum.ftVariable;
                    SITUATION12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SITUATION12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SITUATION12.TextFont.Name = "Calibri";
                    SITUATION12.TextFont.Size = 16;
                    SITUATION12.Value = @"";

                    SITUATION21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 121, 78, 128, false);
                    SITUATION21.Name = "SITUATION21";
                    SITUATION21.DrawStyle = DrawStyleConstants.vbSolid;
                    SITUATION21.FillStyle = FillStyleConstants.vbFSTransparent;
                    SITUATION21.FieldType = ReportFieldTypeEnum.ftVariable;
                    SITUATION21.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SITUATION21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SITUATION21.TextFont.Name = "Calibri";
                    SITUATION21.TextFont.Size = 16;
                    SITUATION21.Value = @"";

                    SITUATION22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 121, 102, 128, false);
                    SITUATION22.Name = "SITUATION22";
                    SITUATION22.DrawStyle = DrawStyleConstants.vbSolid;
                    SITUATION22.FillStyle = FillStyleConstants.vbFSTransparent;
                    SITUATION22.FieldType = ReportFieldTypeEnum.ftVariable;
                    SITUATION22.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SITUATION22.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SITUATION22.TextFont.Name = "Calibri";
                    SITUATION22.TextFont.Size = 16;
                    SITUATION22.Value = @"";

                    MedulaTakipNoLabel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 127, 158, 132, false);
                    MedulaTakipNoLabel.Name = "MedulaTakipNoLabel";
                    MedulaTakipNoLabel.TextFont.Name = "Calibri";
                    MedulaTakipNoLabel.TextFont.Size = 9;
                    MedulaTakipNoLabel.TextFont.Bold = true;
                    MedulaTakipNoLabel.Value = @"Medula Takip No : ";

                    RaporSiraNoLabel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 134, 158, 139, false);
                    RaporSiraNoLabel.Name = "RaporSiraNoLabel";
                    RaporSiraNoLabel.TextFont.Name = "Calibri";
                    RaporSiraNoLabel.TextFont.Size = 9;
                    RaporSiraNoLabel.TextFont.Bold = true;
                    RaporSiraNoLabel.Value = @"Rapor Sıra No : ";

                    MEDULATAKIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 127, 196, 132, false);
                    MEDULATAKIPNO.Name = "MEDULATAKIPNO";
                    MEDULATAKIPNO.TextFont.Name = "Arial Narrow";
                    MEDULATAKIPNO.TextFont.CharSet = 1;
                    MEDULATAKIPNO.Value = @"";

                    RAPORSIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 134, 196, 139, false);
                    RAPORSIRANO.Name = "RAPORSIRANO";
                    RAPORSIRANO.TextFont.Name = "Arial Narrow";
                    RAPORSIRANO.TextFont.CharSet = 1;
                    RAPORSIRANO.Value = @"";

                    MedulaTakipNoLabel1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 45, 158, 50, false);
                    MedulaTakipNoLabel1.Name = "MedulaTakipNoLabel1";
                    MedulaTakipNoLabel1.TextFont.Name = "Calibri";
                    MedulaTakipNoLabel1.TextFont.Size = 9;
                    MedulaTakipNoLabel1.TextFont.Bold = true;
                    MedulaTakipNoLabel1.Value = @"Medula Takip No : ";

                    RaporSiraNoLabel1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 52, 158, 57, false);
                    RaporSiraNoLabel1.Name = "RaporSiraNoLabel1";
                    RaporSiraNoLabel1.TextFont.Name = "Calibri";
                    RaporSiraNoLabel1.TextFont.Size = 9;
                    RaporSiraNoLabel1.TextFont.Bold = true;
                    RaporSiraNoLabel1.Value = @"Rapor Sıra No : ";

                    MEDULATAKIPNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 45, 196, 50, false);
                    MEDULATAKIPNO1.Name = "MEDULATAKIPNO1";
                    MEDULATAKIPNO1.TextFont.Name = "Arial Narrow";
                    MEDULATAKIPNO1.TextFont.CharSet = 1;
                    MEDULATAKIPNO1.Value = @"";

                    RAPORSIRANO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 52, 196, 57, false);
                    RAPORSIRANO1.Name = "RAPORSIRANO1";
                    RAPORSIRANO1.TextFont.Name = "Arial Narrow";
                    RAPORSIRANO1.TextFont.CharSet = 1;
                    RAPORSIRANO1.Value = @"";

                    NewField1316513 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 46, 94, 51, false);
                    NewField1316513.Name = "NewField1316513";
                    NewField1316513.TextFont.Name = "Calibri";
                    NewField1316513.TextFont.Size = 12;
                    NewField1316513.TextFont.Bold = true;
                    NewField1316513.Value = @"2. rapor verildi";

                    SITUATION13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 44, 102, 51, false);
                    SITUATION13.Name = "SITUATION13";
                    SITUATION13.DrawStyle = DrawStyleConstants.vbSolid;
                    SITUATION13.FillStyle = FillStyleConstants.vbFSTransparent;
                    SITUATION13.FieldType = ReportFieldTypeEnum.ftVariable;
                    SITUATION13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SITUATION13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SITUATION13.TextFont.Name = "Calibri";
                    SITUATION13.TextFont.Size = 16;
                    SITUATION13.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    UnavailableToWorkReport.GetUnavailableToWorkReport_Class dataset_GetUnavailableToWorkReport = ParentGroup.rsGroup.GetCurrentRecord<UnavailableToWorkReport.GetUnavailableToWorkReport_Class>(0);
                    NewField1116511.CalcValue = NewField1116511.Value;
                    NewField11156111.CalcValue = NewField11156111.Value;
                    NewField115611.CalcValue = NewField115611.Value;
                    NewField1116512.CalcValue = NewField1116512.Value;
                    NewField12156111.CalcValue = NewField12156111.Value;
                    NewField111165121.CalcValue = NewField111165121.Value;
                    NewField1121561111.CalcValue = NewField1121561111.Value;
                    NewField1121561112.CalcValue = NewField1121561112.Value;
                    NewField115612.CalcValue = NewField115612.Value;
                    NewField1216511.CalcValue = NewField1216511.Value;
                    NewField1216512.CalcValue = NewField1216512.Value;
                    NewField111165111.CalcValue = NewField111165111.Value;
                    NewField1111561111.CalcValue = NewField1111561111.Value;
                    NewField111165112.CalcValue = NewField111165112.Value;
                    NewField115613.CalcValue = NewField115613.Value;
                    NewField1316511.CalcValue = NewField1316511.Value;
                    NewField1211561111.CalcValue = NewField1211561111.Value;
                    NewField1211561112.CalcValue = NewField1211561112.Value;
                    NewField151165111.CalcValue = NewField151165111.Value;
                    NewField161165111.CalcValue = NewField161165111.Value;
                    NewField1111561161.CalcValue = NewField1111561161.Value;
                    NewField1111561162.CalcValue = NewField1111561162.Value;
                    NewField1111561163.CalcValue = NewField1111561163.Value;
                    NewField111165113.CalcValue = NewField111165113.Value;
                    NewField111165114.CalcValue = NewField111165114.Value;
                    NewField1111561151.CalcValue = NewField1111561151.Value;
                    NewField1111561164.CalcValue = NewField1111561164.Value;
                    NewField1111561152.CalcValue = NewField1111561152.Value;
                    NewField11156112.CalcValue = NewField11156112.Value;
                    NewField111165115.CalcValue = NewField111165115.Value;
                    NewField115614.CalcValue = NewField115614.Value;
                    NewField1111561112.CalcValue = NewField1111561112.Value;
                    NewField11156121.CalcValue = NewField11156121.Value;
                    NewField1111561113.CalcValue = NewField1111561113.Value;
                    NewField1111561114.CalcValue = NewField1111561114.Value;
                    NewField1111561115.CalcValue = NewField1111561115.Value;
                    NewField1316512.CalcValue = NewField1316512.Value;
                    NewField11156131.CalcValue = NewField11156131.Value;
                    NewField112165111.CalcValue = NewField112165111.Value;
                    NewField1111561116.CalcValue = NewField1111561116.Value;
                    NewField1111561117.CalcValue = NewField1111561117.Value;
                    NewField1311561111.CalcValue = NewField1311561111.Value;
                    NewField11156122.CalcValue = NewField11156122.Value;
                    NewField1111561153.CalcValue = NewField1111561153.Value;
                    NewField1111561165.CalcValue = NewField1111561165.Value;
                    NewField1111561166.CalcValue = NewField1111561166.Value;
                    NewField1111561167.CalcValue = NewField1111561167.Value;
                    NewField1111561168.CalcValue = NewField1111561168.Value;
                    NewField12156121.CalcValue = NewField12156121.Value;
                    NewField1411561111.CalcValue = NewField1411561111.Value;
                    NewField1111561169.CalcValue = NewField1111561169.Value;
                    NewField1111561170.CalcValue = NewField1111561170.Value;
                    NewField1111561171.CalcValue = NewField1111561171.Value;
                    EXCUSE1.CalcValue = @"";
                    DIAGNOSIS1.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.Diagnosiscode) : "") + (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.Diagnosisname) : "");
                    RESSTARTDATE1.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.RestingStartDate) : "");
                    RESENDDATE1.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.RestingEndDate) : "");
                    SITUATIONDATE1.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.SituationDate) : "");
                    ADMISSIONDATE1.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.Admissiondate) : "");
                    DISCHARGEDATE1.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.Dischargedate) : "");
                    RESSTARTDATE2.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.RestingStartDate) : "");
                    RESENDDATE2.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.RestingEndDate) : "");
                    SITUATIONDATE2.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.SituationDate) : "");
                    ADMISSIONDATE2.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.Admissiondate) : "");
                    DISCHARGEDATE2.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.Dischargedate) : "");
                    DOCTOR1.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.Doctor) : "");
                    DOCTORID1.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.Doctorid) : "");
                    DNO1.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.Dno) : "");
                    DOCTOR2.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.Doctor) : "");
                    DOCTORID2.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.Doctorid) : "");
                    DNO2.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.Dno) : "");
                    OBJECTID.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.ObjectID) : "");
                    DIAGNOSIS2.CalcValue = (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.Diagnosiscode) : "") + (dataset_GetUnavailableToWorkReport != null ? Globals.ToStringCore(dataset_GetUnavailableToWorkReport.Diagnosisname) : "");
                    EXCUSE2.CalcValue = @"";
                    EXCUSE3.CalcValue = @"";
                    EXCUSE4.CalcValue = @"";
                    SITUATION11.CalcValue = @"";
                    SITUATION12.CalcValue = @"";
                    SITUATION21.CalcValue = @"";
                    SITUATION22.CalcValue = @"";
                    MedulaTakipNoLabel.CalcValue = MedulaTakipNoLabel.Value;
                    RaporSiraNoLabel.CalcValue = RaporSiraNoLabel.Value;
                    MEDULATAKIPNO.CalcValue = MEDULATAKIPNO.Value;
                    RAPORSIRANO.CalcValue = RAPORSIRANO.Value;
                    MedulaTakipNoLabel1.CalcValue = MedulaTakipNoLabel1.Value;
                    RaporSiraNoLabel1.CalcValue = RaporSiraNoLabel1.Value;
                    MEDULATAKIPNO1.CalcValue = MEDULATAKIPNO1.Value;
                    RAPORSIRANO1.CalcValue = RAPORSIRANO1.Value;
                    NewField1316513.CalcValue = NewField1316513.Value;
                    SITUATION13.CalcValue = @"";
                    return new TTReportObject[] { NewField1116511,NewField11156111,NewField115611,NewField1116512,NewField12156111,NewField111165121,NewField1121561111,NewField1121561112,NewField115612,NewField1216511,NewField1216512,NewField111165111,NewField1111561111,NewField111165112,NewField115613,NewField1316511,NewField1211561111,NewField1211561112,NewField151165111,NewField161165111,NewField1111561161,NewField1111561162,NewField1111561163,NewField111165113,NewField111165114,NewField1111561151,NewField1111561164,NewField1111561152,NewField11156112,NewField111165115,NewField115614,NewField1111561112,NewField11156121,NewField1111561113,NewField1111561114,NewField1111561115,NewField1316512,NewField11156131,NewField112165111,NewField1111561116,NewField1111561117,NewField1311561111,NewField11156122,NewField1111561153,NewField1111561165,NewField1111561166,NewField1111561167,NewField1111561168,NewField12156121,NewField1411561111,NewField1111561169,NewField1111561170,NewField1111561171,EXCUSE1,DIAGNOSIS1,RESSTARTDATE1,RESENDDATE1,SITUATIONDATE1,ADMISSIONDATE1,DISCHARGEDATE1,RESSTARTDATE2,RESENDDATE2,SITUATIONDATE2,ADMISSIONDATE2,DISCHARGEDATE2,DOCTOR1,DOCTORID1,DNO1,DOCTOR2,DOCTORID2,DNO2,OBJECTID,DIAGNOSIS2,EXCUSE2,EXCUSE3,EXCUSE4,SITUATION11,SITUATION12,SITUATION21,SITUATION22,MedulaTakipNoLabel,RaporSiraNoLabel,MEDULATAKIPNO,RAPORSIRANO,MedulaTakipNoLabel1,RaporSiraNoLabel1,MEDULATAKIPNO1,RAPORSIRANO1,NewField1316513,SITUATION13};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((UnavailableToWorkReportReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            UnavailableToWorkReport uvr = (UnavailableToWorkReport)context.GetObject(new Guid(sObjectID),"UnavailableToWorkReport");
            
            string excuse = uvr.Excuse;
            switch(excuse)
            {
                case "0":
                    this.EXCUSE1.CalcValue = "X";
                    this.EXCUSE2.CalcValue = "";
                    this.EXCUSE3.CalcValue = "";
                    this.EXCUSE4.CalcValue = "";
                    break;
                case "1":
                    this.EXCUSE1.CalcValue = "";
                    this.EXCUSE2.CalcValue = "X";
                    this.EXCUSE3.CalcValue = "";
                    this.EXCUSE4.CalcValue = "";
                    break;
                case "2":
                    this.EXCUSE1.CalcValue = "";
                    this.EXCUSE2.CalcValue = "";
                    this.EXCUSE3.CalcValue = "X";
                    this.EXCUSE4.CalcValue = "";
                    break;
                case "3":
                    this.EXCUSE1.CalcValue = "";
                    this.EXCUSE2.CalcValue = "";
                    this.EXCUSE3.CalcValue = "";
                    this.EXCUSE4.CalcValue = "X";
                    break;
                default:
                    break;
            }
            
            bool ikinciOnGunKontolu = false;
            DateTime? ilkRaporBaslangicTarihi = null;
            DateTime? ilkRaporBitisTarihi = null;
            string ilkRaporSiraNo = string.Empty;
            // UnavailToWorkRprtInfo.GetUndeletedUnavailToWorkRptInfo_Class ilkRapor;
            if(uvr.FirstOrSecondTenDays == "1")
            {
                BindingList<UnavailToWorkRprtInfo.GetUndeletedUnavailToWorkRptInfo_Class> getUnavailToWorkRptInfo = UnavailToWorkRprtInfo.GetUndeletedUnavailToWorkRptInfo(Convert.ToInt64(uvr.Episode.Patient.UniqueRefNo));
                foreach (UnavailToWorkRprtInfo.GetUndeletedUnavailToWorkRptInfo_Class item in getUnavailToWorkRptInfo)
                {
                    if (uvr.Excuse == item.Excuse && uvr.MedulaChasingNo == item.MedulaChasingNo )
                    {
                        if(Convert.ToInt32(item.ReportRowNumber) + 1 == Convert.ToInt32(uvr.ReportRowNumber))
                        {
                            ilkRaporBaslangicTarihi = item.RestingStartDate;
                            ilkRaporBitisTarihi = item.RestingEndDate;
                            ilkRaporSiraNo = item.ReportRowNumber;
                            ikinciOnGunKontolu = true;
                        }
                    }
                }
            }
            
            
            if(uvr.FirstOrSecondTenDays == "0" )
            {
                this.DIAGNOSIS2.CalcValue = "";
                this.RESSTARTDATE2.CalcValue = "";
                this.RESENDDATE2.CalcValue = "";
                this.SITUATION21.CalcValue = "";
                this.SITUATION22.CalcValue = "";
                this.SITUATIONDATE2.CalcValue = "";
                this.ADMISSIONDATE2.CalcValue = "";
                this.DISCHARGEDATE2.CalcValue = "";
                this.DOCTOR2.CalcValue = "";
                this.DOCTORID2.CalcValue = "";
                this.DNO2.CalcValue = "";
                if((int)uvr.Situation == 1)
                {
                    this.SITUATION11.CalcValue = "X";
                    this.SITUATION12.CalcValue = "";
                    this.SITUATION13.CalcValue = "";
                }
                else
                {
                    this.SITUATION11.CalcValue = "";
                    this.SITUATION12.CalcValue = "X";
                    this.SITUATION13.CalcValue = "";
                }
                if (!string.IsNullOrEmpty(uvr.MedulaChasingNo))
                {
                    MEDULATAKIPNO1.CalcValue = uvr.MedulaChasingNo;
                    RAPORSIRANO1.CalcValue = uvr.ReportRowNumber;
                }
                
            }
            else
            {
                if(ikinciOnGunKontolu == true)
                {
                    this.DIAGNOSIS1.CalcValue = "";
                    this.RESSTARTDATE1.CalcValue =  ilkRaporBaslangicTarihi != null ? Convert.ToDateTime(ilkRaporBaslangicTarihi).ToShortDateString() : "";
                    this.RESENDDATE1.CalcValue = ilkRaporBitisTarihi != null ? Convert.ToDateTime(ilkRaporBitisTarihi).ToShortDateString() : "";
                    this.SITUATION11.CalcValue = "";
                    this.SITUATION12.CalcValue = "";
                    this.SITUATIONDATE1.CalcValue = ilkRaporBitisTarihi != null ? Convert.ToDateTime(ilkRaporBitisTarihi).AddDays(1).ToShortDateString() : "";
                    this.ADMISSIONDATE1.CalcValue = "";
                    this.DISCHARGEDATE1.CalcValue = "";
                    this.DOCTOR1.CalcValue ="";
                    this.DOCTORID1.CalcValue = "";
                    this.DNO1.CalcValue = "";
                    
                    this.SITUATION11.CalcValue = "";
                    this.SITUATION12.CalcValue = "";
                    this.SITUATION13.CalcValue = "X";
                    
                    if (!string.IsNullOrEmpty(uvr.MedulaChasingNo))
                    {
                        MEDULATAKIPNO1.CalcValue = uvr.MedulaChasingNo;
                        RAPORSIRANO1.CalcValue = ilkRaporSiraNo;
                    }
                }
                else
                {
                    this.DIAGNOSIS1.CalcValue = "";
                    this.RESSTARTDATE1.CalcValue = "";
                    this.RESENDDATE1.CalcValue = "";
                    this.SITUATION11.CalcValue = "";
                    this.SITUATION12.CalcValue = "";
                    this.SITUATIONDATE1.CalcValue = "";
                    this.ADMISSIONDATE1.CalcValue = "";
                    this.DISCHARGEDATE1.CalcValue = "";
                    this.DOCTOR1.CalcValue = "";
                    this.DOCTORID1.CalcValue = "";
                    this.DNO1.CalcValue = "";
                }
                if ((int)uvr.Situation == 1)
                {
                    this.SITUATION21.CalcValue = "X";
                    this.SITUATION22.CalcValue = "";
                }
                else
                {
                    this.SITUATION21.CalcValue = "";
                    this.SITUATION22.CalcValue = "X";
                }
                if (!string.IsNullOrEmpty(uvr.ReportRowNumber)) {
                    MEDULATAKIPNO.CalcValue = uvr.MedulaChasingNo;
                    RAPORSIRANO.CalcValue = uvr.ReportRowNumber;
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

        public UnavailableToWorkReportReport()
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
            Name = "UNAVAILABLETOWORKREPORTREPORT";
            Caption = "İş Göremezlik Belgesi";
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