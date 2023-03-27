
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
    /// Bakım-Onarım-Kalibrasyon Kayıt Defteri Raporu
    /// </summary>
    public partial class CMRRegistrationReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public CMRRegistrationReport MyParentReport
            {
                get { return (CMRRegistrationReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField1142 { get {return Header().NewField1142;} }
            public TTReportField NewField12411 { get {return Header().NewField12411;} }
            public TTReportField NewField111421 { get {return Header().NewField111421;} }
            public TTReportField NewField111422 { get {return Header().NewField111422;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField NewField1162 { get {return Header().NewField1162;} }
            public TTReportField NewField11611 { get {return Header().NewField11611;} }
            public TTReportField NewField111611 { get {return Header().NewField111611;} }
            public TTReportField NewField111423 { get {return Header().NewField111423;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
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
                public CMRRegistrationReport MyParentReport
                {
                    get { return (CMRRegistrationReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField141;
                public TTReportField NewField1141;
                public TTReportField NewField1142;
                public TTReportField NewField12411;
                public TTReportField NewField111421;
                public TTReportField NewField111422;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField161;
                public TTReportField NewField1161;
                public TTReportField NewField1162;
                public TTReportField NewField11611;
                public TTReportField NewField111611;
                public TTReportField NewField111423; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 35;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 17, 214, 32, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 7;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"ONARIMDA KULLANILAN MALZEMELER";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 280, 6, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 11;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"TIBBİ CİHAZ BAKIM-ONARIM-KALİBRASYON KAYIT DEFTERİ";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 12, 8, 32, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Size = 7;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"

SIRA NU.";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 12, 280, 32, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Size = 7;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"

DÜŞÜN
CELER";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 17, 268, 32, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.TextFont.Size = 7;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"
TARİH";

                    NewField1142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 17, 254, 32, false);
                    NewField1142.Name = "NewField1142";
                    NewField1142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1142.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1142.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1142.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1142.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1142.TextFont.Name = "Arial";
                    NewField1142.TextFont.Size = 7;
                    NewField1142.TextFont.Bold = true;
                    NewField1142.TextFont.CharSet = 162;
                    NewField1142.Value = @"RÜTBESİ ADI SOYADI İMZA";

                    NewField12411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 12, 268, 17, false);
                    NewField12411.Name = "NewField12411";
                    NewField12411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12411.TextFont.Name = "Arial";
                    NewField12411.TextFont.Size = 7;
                    NewField12411.TextFont.Bold = true;
                    NewField12411.TextFont.CharSet = 162;
                    NewField12411.Value = @"TESLİM ALAN";

                    NewField111421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 17, 228, 32, false);
                    NewField111421.Name = "NewField111421";
                    NewField111421.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111421.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111421.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111421.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111421.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111421.TextFont.Name = "Arial";
                    NewField111421.TextFont.Size = 7;
                    NewField111421.TextFont.Bold = true;
                    NewField111421.TextFont.CharSet = 162;
                    NewField111421.Value = @"BAKIM/
ONARIM BİTİŞ TARİHİ";

                    NewField111422 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 12, 82, 32, false);
                    NewField111422.Name = "NewField111422";
                    NewField111422.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111422.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111422.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111422.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111422.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111422.TextFont.Name = "Arial";
                    NewField111422.TextFont.Size = 7;
                    NewField111422.TextFont.Bold = true;
                    NewField111422.TextFont.CharSet = 162;
                    NewField111422.Value = @"

PLAKA
SERİ NU.
MİKTARI";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 12, 24, 32, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.MultiLine = EvetHayirEnum.ehEvet;
                    NewField15.WordBreak = EvetHayirEnum.ehEvet;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Size = 7;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"

İŞLETME KISMI SİPARİŞ NU.";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 12, 142, 32, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.MultiLine = EvetHayirEnum.ehEvet;
                    NewField16.WordBreak = EvetHayirEnum.ehEvet;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Size = 7;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"

ARIZA /
BAKIM";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 12, 66, 32, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Size = 7;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"CİNSİ";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 17, 156, 32, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1161.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1161.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1161.TextFont.Name = "Arial";
                    NewField1161.TextFont.Size = 7;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"İŞ EMRİ GELİŞ TARİHİ";

                    NewField1162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 12, 124, 32, false);
                    NewField1162.Name = "NewField1162";
                    NewField1162.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1162.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1162.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1162.TextFont.Name = "Arial";
                    NewField1162.TextFont.Size = 7;
                    NewField1162.TextFont.Bold = true;
                    NewField1162.TextFont.CharSet = 162;
                    NewField1162.Value = @"BİRLİĞİ";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 17, 170, 32, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11611.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11611.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11611.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11611.TextFont.Name = "Arial";
                    NewField11611.TextFont.Size = 7;
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @"İŞ EMRİ ÇIKIŞ
TARİHİ";

                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 17, 184, 32, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111611.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111611.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111611.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111611.TextFont.Name = "Arial";
                    NewField111611.TextFont.Size = 7;
                    NewField111611.TextFont.Bold = true;
                    NewField111611.TextFont.CharSet = 162;
                    NewField111611.Value = @"MALZEME VE İŞ EMRİ GELİŞ TARİHİ";

                    NewField111423 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 12, 228, 17, false);
                    NewField111423.Name = "NewField111423";
                    NewField111423.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111423.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111423.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111423.TextFont.Name = "Arial";
                    NewField111423.TextFont.Size = 7;
                    NewField111423.TextFont.Bold = true;
                    NewField111423.TextFont.CharSet = 162;
                    NewField111423.Value = @"ATÖLYE / D. DS. TK";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1142.CalcValue = NewField1142.Value;
                    NewField12411.CalcValue = NewField12411.Value;
                    NewField111421.CalcValue = NewField111421.Value;
                    NewField111422.CalcValue = NewField111422.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField1162.CalcValue = NewField1162.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    NewField111611.CalcValue = NewField111611.Value;
                    NewField111423.CalcValue = NewField111423.Value;
                    return new TTReportObject[] { NewField11,NewField13,NewField14,NewField141,NewField1141,NewField1142,NewField12411,NewField111421,NewField111422,NewField15,NewField16,NewField161,NewField1161,NewField1162,NewField11611,NewField111611,NewField111423};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CMRRegistrationReport MyParentReport
                {
                    get { return (CMRRegistrationReport)ParentReport; }
                }
                
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportField PrintDate;
                public TTReportShape NewLine111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 0, 155, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser.TextFont.Name = "Arial";
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 255, 0, 280, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 280, 0, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PageNumber.CalcValue = @"Sayfa Nu." + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PageNumber,PrintDate,CurrentUser};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public CMRRegistrationReport MyParentReport
            {
                get { return (CMRRegistrationReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField MARKMODELSERIALNOAMOUNT { get {return Body().MARKMODELSERIALNOAMOUNT;} }
            public TTReportField MILITARYUNIT { get {return Body().MILITARYUNIT;} }
            public TTReportField REFERTYPE { get {return Body().REFERTYPE;} }
            public TTReportField WORKORDEROUTDATE { get {return Body().WORKORDEROUTDATE;} }
            public TTReportField ARRIVALDATE { get {return Body().ARRIVALDATE;} }
            public TTReportField USEDMATERIALS { get {return Body().USEDMATERIALS;} }
            public TTReportField ENDDATE { get {return Body().ENDDATE;} }
            public TTReportField NAMESURNAME { get {return Body().NAMESURNAME;} }
            public TTReportField DATE { get {return Body().DATE;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField WORKORDERINDATE { get {return Body().WORKORDERINDATE;} }
            public TTReportField REQUESTDATE { get {return Body().REQUESTDATE;} }
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
                list[0] = new TTReportNqlData<MaintenanceOrder.GetMaintenanceAndRepairRegistryReportQuery_Class>("GetMaintenanceAndRepairRegistryReportQuery2", MaintenanceOrder.GetMaintenanceAndRepairRegistryReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public CMRRegistrationReport MyParentReport
                {
                    get { return (CMRRegistrationReport)ParentReport; }
                }
                
                public TTReportField COUNT;
                public TTReportField ORDERNO;
                public TTReportField MATERIALNAME;
                public TTReportField MARKMODELSERIALNOAMOUNT;
                public TTReportField MILITARYUNIT;
                public TTReportField REFERTYPE;
                public TTReportField WORKORDEROUTDATE;
                public TTReportField ARRIVALDATE;
                public TTReportField USEDMATERIALS;
                public TTReportField ENDDATE;
                public TTReportField NAMESURNAME;
                public TTReportField DATE;
                public TTReportField DESCRIPTION;
                public TTReportField OBJECTID;
                public TTReportField WORKORDERINDATE;
                public TTReportField REQUESTDATE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 29;
                    RepeatCount = 0;
                    
                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 8, 15, false);
                    COUNT.Name = "COUNT";
                    COUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.MultiLine = EvetHayirEnum.ehEvet;
                    COUNT.WordBreak = EvetHayirEnum.ehEvet;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.Size = 7;
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 24, 15, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.MultiLine = EvetHayirEnum.ehEvet;
                    ORDERNO.WordBreak = EvetHayirEnum.ehEvet;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.Size = 7;
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{#REQUESTNO#}
{%REQUESTDATE%}
{#ORDERNO#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 0, 66, 15, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.Size = 7;
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    MARKMODELSERIALNOAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 0, 82, 15, false);
                    MARKMODELSERIALNOAMOUNT.Name = "MARKMODELSERIALNOAMOUNT";
                    MARKMODELSERIALNOAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    MARKMODELSERIALNOAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARKMODELSERIALNOAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MARKMODELSERIALNOAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARKMODELSERIALNOAMOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    MARKMODELSERIALNOAMOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    MARKMODELSERIALNOAMOUNT.TextFont.Name = "Arial";
                    MARKMODELSERIALNOAMOUNT.TextFont.Size = 7;
                    MARKMODELSERIALNOAMOUNT.TextFont.CharSet = 162;
                    MARKMODELSERIALNOAMOUNT.Value = @"{#MARK#}
{#MODEL#}
{#SERIALNUMBER#}
{#AMOUNT#} {#DISTRIBUTIONTYPE#}";

                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 0, 124, 15, false);
                    MILITARYUNIT.Name = "MILITARYUNIT";
                    MILITARYUNIT.DrawStyle = DrawStyleConstants.vbSolid;
                    MILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNIT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MILITARYUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MILITARYUNIT.MultiLine = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.WordBreak = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.TextFont.Name = "Arial";
                    MILITARYUNIT.TextFont.Size = 7;
                    MILITARYUNIT.TextFont.CharSet = 162;
                    MILITARYUNIT.Value = @"{#OWNERMILITARYUNIT#}";

                    REFERTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 0, 142, 15, false);
                    REFERTYPE.Name = "REFERTYPE";
                    REFERTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    REFERTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REFERTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REFERTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REFERTYPE.MultiLine = EvetHayirEnum.ehEvet;
                    REFERTYPE.WordBreak = EvetHayirEnum.ehEvet;
                    REFERTYPE.ObjectDefName = "ReferTypeEnum";
                    REFERTYPE.DataMember = "DISPLAYTEXT";
                    REFERTYPE.TextFont.Name = "Arial";
                    REFERTYPE.TextFont.Size = 7;
                    REFERTYPE.TextFont.CharSet = 162;
                    REFERTYPE.Value = @"{#REFERTYPE#}";

                    WORKORDEROUTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 0, 170, 15, false);
                    WORKORDEROUTDATE.Name = "WORKORDEROUTDATE";
                    WORKORDEROUTDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKORDEROUTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKORDEROUTDATE.TextFormat = @"dd/MM/yyyy";
                    WORKORDEROUTDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WORKORDEROUTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKORDEROUTDATE.MultiLine = EvetHayirEnum.ehEvet;
                    WORKORDEROUTDATE.WordBreak = EvetHayirEnum.ehEvet;
                    WORKORDEROUTDATE.TextFont.Name = "Arial";
                    WORKORDEROUTDATE.TextFont.Size = 7;
                    WORKORDEROUTDATE.TextFont.CharSet = 162;
                    WORKORDEROUTDATE.Value = @"{#ORDERDATE#}";

                    ARRIVALDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 0, 184, 15, false);
                    ARRIVALDATE.Name = "ARRIVALDATE";
                    ARRIVALDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ARRIVALDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ARRIVALDATE.TextFormat = @"dd/MM/yyyy";
                    ARRIVALDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ARRIVALDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ARRIVALDATE.MultiLine = EvetHayirEnum.ehEvet;
                    ARRIVALDATE.WordBreak = EvetHayirEnum.ehEvet;
                    ARRIVALDATE.TextFont.Name = "Arial";
                    ARRIVALDATE.TextFont.Size = 7;
                    ARRIVALDATE.TextFont.CharSet = 162;
                    ARRIVALDATE.Value = @"{#ARRIVALDATE#}";

                    USEDMATERIALS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 0, 214, 15, false);
                    USEDMATERIALS.Name = "USEDMATERIALS";
                    USEDMATERIALS.DrawStyle = DrawStyleConstants.vbSolid;
                    USEDMATERIALS.FieldType = ReportFieldTypeEnum.ftVariable;
                    USEDMATERIALS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    USEDMATERIALS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    USEDMATERIALS.MultiLine = EvetHayirEnum.ehEvet;
                    USEDMATERIALS.WordBreak = EvetHayirEnum.ehEvet;
                    USEDMATERIALS.TextFont.Name = "Arial";
                    USEDMATERIALS.TextFont.Size = 7;
                    USEDMATERIALS.TextFont.CharSet = 162;
                    USEDMATERIALS.Value = @"";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 0, 228, 15, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.MultiLine = EvetHayirEnum.ehEvet;
                    ENDDATE.WordBreak = EvetHayirEnum.ehEvet;
                    ENDDATE.TextFont.Name = "Arial";
                    ENDDATE.TextFont.Size = 7;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{#ENDDATE#}";

                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 0, 254, 15, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAMESURNAME.MultiLine = EvetHayirEnum.ehEvet;
                    NAMESURNAME.WordBreak = EvetHayirEnum.ehEvet;
                    NAMESURNAME.TextFont.Name = "Arial";
                    NAMESURNAME.TextFont.Size = 7;
                    NAMESURNAME.TextFont.CharSet = 162;
                    NAMESURNAME.Value = @"{#PERSONNEL#}";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 0, 268, 15, false);
                    DATE.Name = "DATE";
                    DATE.DrawStyle = DrawStyleConstants.vbSolid;
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"dd/MM/yyyy";
                    DATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATE.MultiLine = EvetHayirEnum.ehEvet;
                    DATE.WordBreak = EvetHayirEnum.ehEvet;
                    DATE.TextFont.Name = "Arial";
                    DATE.TextFont.Size = 7;
                    DATE.TextFont.CharSet = 162;
                    DATE.Value = @"";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 0, 280, 15, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.Name = "Arial";
                    DESCRIPTION.TextFont.Size = 7;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 0, 325, 7, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OBJECTID.MultiLine = EvetHayirEnum.ehEvet;
                    OBJECTID.WordBreak = EvetHayirEnum.ehEvet;
                    OBJECTID.TextFont.Name = "Arial";
                    OBJECTID.TextFont.Size = 7;
                    OBJECTID.TextFont.CharSet = 162;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    WORKORDERINDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 0, 156, 15, false);
                    WORKORDERINDATE.Name = "WORKORDERINDATE";
                    WORKORDERINDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKORDERINDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKORDERINDATE.TextFormat = @"dd/MM/yyyy";
                    WORKORDERINDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WORKORDERINDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKORDERINDATE.MultiLine = EvetHayirEnum.ehEvet;
                    WORKORDERINDATE.WordBreak = EvetHayirEnum.ehEvet;
                    WORKORDERINDATE.TextFont.Name = "Arial";
                    WORKORDERINDATE.TextFont.Size = 7;
                    WORKORDERINDATE.TextFont.CharSet = 162;
                    WORKORDERINDATE.Value = @"{#REQUESTDATE#}";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 332, 2, 357, 7, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.Visible = EvetHayirEnum.ehHayir;
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"dd/MM/yyyy";
                    REQUESTDATE.Value = @"{#REQUESTDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceAndRepairRegistryReportQuery_Class dataset_GetMaintenanceAndRepairRegistryReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceAndRepairRegistryReportQuery_Class>(0);
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    REQUESTDATE.CalcValue = (dataset_GetMaintenanceAndRepairRegistryReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryReportQuery2.RequestDate) : "");
                    ORDERNO.CalcValue = (dataset_GetMaintenanceAndRepairRegistryReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryReportQuery2.RequestNo) : "") + @"
" + MyParentReport.MAIN.REQUESTDATE.FormattedValue + @"
" + (dataset_GetMaintenanceAndRepairRegistryReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryReportQuery2.OrderNO) : "");
                    MATERIALNAME.CalcValue = (dataset_GetMaintenanceAndRepairRegistryReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryReportQuery2.Materialname) : "");
                    MARKMODELSERIALNOAMOUNT.CalcValue = (dataset_GetMaintenanceAndRepairRegistryReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryReportQuery2.Mark) : "") + @"
" + (dataset_GetMaintenanceAndRepairRegistryReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryReportQuery2.Model) : "") + @"
" + (dataset_GetMaintenanceAndRepairRegistryReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryReportQuery2.SerialNumber) : "") + @"
" + (dataset_GetMaintenanceAndRepairRegistryReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryReportQuery2.Amount) : "") + @" " + (dataset_GetMaintenanceAndRepairRegistryReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryReportQuery2.DistributionType) : "");
                    MILITARYUNIT.CalcValue = (dataset_GetMaintenanceAndRepairRegistryReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryReportQuery2.Ownermilitaryunit) : "");
                    REFERTYPE.CalcValue = (dataset_GetMaintenanceAndRepairRegistryReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryReportQuery2.ReferType) : "");
                    REFERTYPE.PostFieldValueCalculation();
                    WORKORDEROUTDATE.CalcValue = (dataset_GetMaintenanceAndRepairRegistryReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryReportQuery2.OrderDate) : "");
                    ARRIVALDATE.CalcValue = (dataset_GetMaintenanceAndRepairRegistryReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryReportQuery2.ArrivalDate) : "");
                    USEDMATERIALS.CalcValue = @"";
                    ENDDATE.CalcValue = (dataset_GetMaintenanceAndRepairRegistryReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryReportQuery2.EndDate) : "");
                    NAMESURNAME.CalcValue = (dataset_GetMaintenanceAndRepairRegistryReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryReportQuery2.Personnel) : "");
                    DATE.CalcValue = @"";
                    DESCRIPTION.CalcValue = @"";
                    OBJECTID.CalcValue = (dataset_GetMaintenanceAndRepairRegistryReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryReportQuery2.ObjectID) : "");
                    WORKORDERINDATE.CalcValue = (dataset_GetMaintenanceAndRepairRegistryReportQuery2 != null ? Globals.ToStringCore(dataset_GetMaintenanceAndRepairRegistryReportQuery2.RequestDate) : "");
                    return new TTReportObject[] { COUNT,REQUESTDATE,ORDERNO,MATERIALNAME,MARKMODELSERIALNOAMOUNT,MILITARYUNIT,REFERTYPE,WORKORDEROUTDATE,ARRIVALDATE,USEDMATERIALS,ENDDATE,NAMESURNAME,DATE,DESCRIPTION,OBJECTID,WORKORDERINDATE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //            TTObjectContext ctx = new TTObjectContext(true);
            //            CMRAction action = (CMRAction)ctx.GetObject(new Guid(ObjectID.CalcValue), typeof(CMRAction));
            //            if(action is Repair)
            //            {
            //                Repair repair = (Repair)ctx.GetObject(new Guid(ObjectID.CalcValue), typeof(Repair));
            //                RequestNO.CalcValue = repair.RequestNo;
            //                if(action.CurrentStateDefID == Repair.States.Comleted)
            //                {
            //                    O.CalcValue = "X";
            //                }
            //                else if(action.CurrentStateDefID == Repair.States.Supply_Of_Materials)
            //                {
            //                    PB.CalcValue = "X";
            //                }
            //                else if(action.CurrentStateDefID == Repair.States.UpperStage)
            //                {
            //                    UKS.CalcValue = "X";
            //                }
            //            }
            //            else if(action is Maintenance)
            //            {
            //                Maintenance maintenance = (Maintenance)ctx.GetObject(new Guid(ObjectID.CalcValue), typeof(Maintenance));
            //                RequestNO.CalcValue = maintenance.RequestNo.ToString();
            //                if(action.CurrentStateDefID == Maintenance.States.Completed)
            //                {
            //                    O.CalcValue = "X";
            //                }
            //            }
            //            else if(action is Calibration)
            //            {
            //                Calibration calibration = (Calibration)ctx.GetObject(new Guid(ObjectID.CalcValue), typeof(Calibration));
            //                RequestNO.CalcValue = calibration.RequestNo.ToString();
            //                if(action.CurrentStateDefID == Calibration.States.Completed)
            //                {
            //                    O.CalcValue = "X";
            //                }
            //            }

            string objectID = OBJECTID.CalcValue;
            MaintenanceOrder mo = (MaintenanceOrder)MyParentReport.ReportObjectContext.GetObject(new Guid(objectID), typeof(MaintenanceOrder));
            if(mo.UsedConsumedMaterails.Count > 0)
            {
                foreach(UsedConsumedMaterail usedMaterial in mo.UsedConsumedMaterails)
                {
                    USEDMATERIALS.CalcValue += usedMaterial.Material.Name + "\n";
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

        public CMRRegistrationReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlama Zamanı", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Zamanı", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "CMRREGISTRATIONREPORT";
            Caption = "Bakım-Onarım-Kalibrasyon Kayıt Defteri Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 10;
            UserMarginTop = 15;
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