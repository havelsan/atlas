
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
    /// Bağlı Birliklerden Sevk Edilen Cihazlar Raporu
    /// </summary>
    public partial class CMRRegistrationHospitalReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public CMRRegistrationHospitalReport MyParentReport
            {
                get { return (CMRRegistrationHospitalReport)ParentReport; }
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
            public TTReportField REPORTHEADER { get {return Header().REPORTHEADER;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField1142 { get {return Header().NewField1142;} }
            public TTReportField NewField12411 { get {return Header().NewField12411;} }
            public TTReportField NewField111421 { get {return Header().NewField111421;} }
            public TTReportField NewField111422 { get {return Header().NewField111422;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField NewField11611 { get {return Header().NewField11611;} }
            public TTReportField NewField111611 { get {return Header().NewField111611;} }
            public TTReportField NewField111423 { get {return Header().NewField111423;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
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
                public CMRRegistrationHospitalReport MyParentReport
                {
                    get { return (CMRRegistrationHospitalReport)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField REPORTHEADER;
                public TTReportField NewField14;
                public TTReportField NewField1141;
                public TTReportField NewField1142;
                public TTReportField NewField12411;
                public TTReportField NewField111421;
                public TTReportField NewField111422;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField161;
                public TTReportField NewField1161;
                public TTReportField NewField11611;
                public TTReportField NewField111611;
                public TTReportField NewField111423;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 35;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 8, 235, 35, false);
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
                    NewField11.Value = @"


İŞİN
ÇIKIŞ
TARİHİ";

                    REPORTHEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 235, 8, false);
                    REPORTHEADER.Name = "REPORTHEADER";
                    REPORTHEADER.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTHEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTHEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTHEADER.TextFont.Name = "Arial";
                    REPORTHEADER.TextFont.Size = 11;
                    REPORTHEADER.TextFont.Bold = true;
                    REPORTHEADER.TextFont.CharSet = 162;
                    REPORTHEADER.Value = @"";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 8, 9, 35, false);
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

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 16, 279, 35, false);
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

ÜKS";

                    NewField1142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 16, 264, 35, false);
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
                    NewField1142.Value = @"

PB";

                    NewField12411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 8, 279, 16, false);
                    NewField12411.Name = "NewField12411";
                    NewField12411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12411.TextFont.Name = "Arial";
                    NewField12411.TextFont.Size = 7;
                    NewField12411.TextFont.Bold = true;
                    NewField12411.TextFont.CharSet = 162;
                    NewField12411.Value = @"İŞLEM SONUCU";

                    NewField111421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 16, 250, 35, false);
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
                    NewField111421.Value = @"

O";

                    NewField111422 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 15, 116, 35, false);
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


KLİNİĞİ";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 15, 30, 35, false);
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
STOK
NU.";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 8, 175, 35, false);
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


CİHAZI
TESLİM
EDEN";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 15, 69, 35, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Size = 7;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"ADI";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 8, 155, 35, false);
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
                    NewField1161.Value = @"


CİHAZI 
TESLİM 
ALAN";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 8, 203, 35, false);
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
                    NewField11611.Value = @"


İŞİN 
VERİLDİĞİ 
KISIM";

                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 203, 8, 221, 35, false);
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
                    NewField111611.Value = @"


İŞİN
GİRİŞ 
TARİHİ";

                    NewField111423 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 0, 279, 8, false);
                    NewField111423.Name = "NewField111423";
                    NewField111423.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111423.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111423.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111423.TextFont.Name = "Arial";
                    NewField111423.TextFont.Size = 7;
                    NewField111423.TextFont.Bold = true;
                    NewField111423.TextFont.CharSet = 162;
                    NewField111423.Value = @"MALİ YILI";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 8, 116, 15, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 7;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"CİHAZIN";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 8, 133, 35, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 7;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"


BAKIM
ONARIM
KALİB.İSTEK
FORMMU NU.";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 317, 20, 342, 25, false);
                    NewField3.Name = "NewField3";
                    NewField3.Visible = EvetHayirEnum.ehHayir;
                    NewField3.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField3.Value = @"{@ENDDATE@}";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 314, 13, 339, 18, false);
                    NewField4.Name = "NewField4";
                    NewField4.Visible = EvetHayirEnum.ehHayir;
                    NewField4.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField4.Value = @"{@STARTDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    REPORTHEADER.CalcValue = @"";
                    NewField14.CalcValue = NewField14.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1142.CalcValue = NewField1142.Value;
                    NewField12411.CalcValue = NewField12411.Value;
                    NewField111421.CalcValue = NewField111421.Value;
                    NewField111422.CalcValue = NewField111422.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    NewField111611.CalcValue = NewField111611.Value;
                    NewField111423.CalcValue = NewField111423.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField4.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    return new TTReportObject[] { NewField11,REPORTHEADER,NewField14,NewField1141,NewField1142,NewField12411,NewField111421,NewField111422,NewField15,NewField16,NewField161,NewField1161,NewField11611,NewField111611,NewField111423,NewField1,NewField2,NewField3,NewField4};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
                    if (Sites.SiteXXXXXX06XXXXXX == siteIDGuid || Sites.SiteXXXXXX04 == siteIDGuid)
                        REPORTHEADER.CalcValue = "XXXXXX BİYOMEDİKAL MÜHENDİSLİK MERKEZİ BAĞLI BİRLİKLERDEN SEVK EDİLEN CİHAZLAR RAPORU";
                    else
                        REPORTHEADER.CalcValue = "TIBBİ CİHAZ BAKIM-ONARIM-KALİBRASYON KAYIT DEFTERİ";
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CMRRegistrationHospitalReport MyParentReport
                {
                    get { return (CMRRegistrationHospitalReport)ParentReport; }
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
                    
                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 1, 155, 6, false);
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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 1, 279, 6, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 25, 6, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, -1, 1, 279, 1, false);
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
            public CMRRegistrationHospitalReport MyParentReport
            {
                get { return (CMRRegistrationHospitalReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField STOCKNO { get {return Body().STOCKNO;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField CLINIC { get {return Body().CLINIC;} }
            public TTReportField REQUESTNO { get {return Body().REQUESTNO;} }
            public TTReportField DELIVERERUSER { get {return Body().DELIVERERUSER;} }
            public TTReportField WORKSHOP { get {return Body().WORKSHOP;} }
            public TTReportField STARTDATE { get {return Body().STARTDATE;} }
            public TTReportField ENDDATE { get {return Body().ENDDATE;} }
            public TTReportField O { get {return Body().O;} }
            public TTReportField PB { get {return Body().PB;} }
            public TTReportField UKS { get {return Body().UKS;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField DELIVEREDPERSON { get {return Body().DELIVEREDPERSON;} }
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
                list[0] = new TTReportNqlData<CMRActionRequest.CMRActionHospitalReportQuery_Class>("CMRActionHospitalReportQuery", CMRActionRequest.CMRActionHospitalReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public CMRRegistrationHospitalReport MyParentReport
                {
                    get { return (CMRRegistrationHospitalReport)ParentReport; }
                }
                
                public TTReportField COUNT;
                public TTReportField STOCKNO;
                public TTReportField MATERIALNAME;
                public TTReportField CLINIC;
                public TTReportField REQUESTNO;
                public TTReportField DELIVERERUSER;
                public TTReportField WORKSHOP;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField O;
                public TTReportField PB;
                public TTReportField UKS;
                public TTReportField OBJECTID;
                public TTReportField DELIVEREDPERSON;
                public TTReportField REQUESTDATE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 16;
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

                    STOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 30, 15, false);
                    STOCKNO.Name = "STOCKNO";
                    STOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    STOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STOCKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKNO.MultiLine = EvetHayirEnum.ehEvet;
                    STOCKNO.WordBreak = EvetHayirEnum.ehEvet;
                    STOCKNO.TextFont.Name = "Arial";
                    STOCKNO.TextFont.Size = 7;
                    STOCKNO.TextFont.CharSet = 162;
                    STOCKNO.Value = @"{#STOCKNO#}
";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 0, 69, 15, false);
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

                    CLINIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 0, 116, 15, false);
                    CLINIC.Name = "CLINIC";
                    CLINIC.DrawStyle = DrawStyleConstants.vbSolid;
                    CLINIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLINIC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CLINIC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CLINIC.MultiLine = EvetHayirEnum.ehEvet;
                    CLINIC.WordBreak = EvetHayirEnum.ehEvet;
                    CLINIC.TextFont.Name = "Arial";
                    CLINIC.TextFont.Size = 7;
                    CLINIC.TextFont.CharSet = 162;
                    CLINIC.Value = @"{#SENDERSECTION#}";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 0, 133, 15, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTNO.MultiLine = EvetHayirEnum.ehEvet;
                    REQUESTNO.WordBreak = EvetHayirEnum.ehEvet;
                    REQUESTNO.TextFont.Name = "Arial";
                    REQUESTNO.TextFont.Size = 7;
                    REQUESTNO.TextFont.CharSet = 162;
                    REQUESTNO.Value = @"{#REQUESTNO#}";

                    DELIVERERUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 0, 155, 15, false);
                    DELIVERERUSER.Name = "DELIVERERUSER";
                    DELIVERERUSER.DrawStyle = DrawStyleConstants.vbSolid;
                    DELIVERERUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DELIVERERUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DELIVERERUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DELIVERERUSER.MultiLine = EvetHayirEnum.ehEvet;
                    DELIVERERUSER.WordBreak = EvetHayirEnum.ehEvet;
                    DELIVERERUSER.TextFont.Name = "Arial";
                    DELIVERERUSER.TextFont.Size = 7;
                    DELIVERERUSER.TextFont.CharSet = 162;
                    DELIVERERUSER.Value = @"";

                    WORKSHOP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 0, 203, 15, false);
                    WORKSHOP.Name = "WORKSHOP";
                    WORKSHOP.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKSHOP.TextFormat = @"dd/MM/yyyy";
                    WORKSHOP.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WORKSHOP.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP.MultiLine = EvetHayirEnum.ehEvet;
                    WORKSHOP.WordBreak = EvetHayirEnum.ehEvet;
                    WORKSHOP.TextFont.Name = "Arial";
                    WORKSHOP.TextFont.Size = 7;
                    WORKSHOP.TextFont.CharSet = 162;
                    WORKSHOP.Value = @"{#WORKSHOPNAME#}";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 203, 0, 221, 15, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.MultiLine = EvetHayirEnum.ehEvet;
                    STARTDATE.WordBreak = EvetHayirEnum.ehEvet;
                    STARTDATE.TextFont.Name = "Arial";
                    STARTDATE.TextFont.Size = 7;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{#REQUESTDATE#}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 0, 235, 15, false);
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
                    ENDDATE.Value = @"";

                    O = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 0, 250, 15, false);
                    O.Name = "O";
                    O.DrawStyle = DrawStyleConstants.vbSolid;
                    O.FieldType = ReportFieldTypeEnum.ftVariable;
                    O.TextFormat = @"dd/MM/yyyy";
                    O.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    O.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    O.MultiLine = EvetHayirEnum.ehEvet;
                    O.WordBreak = EvetHayirEnum.ehEvet;
                    O.TextFont.Name = "Arial";
                    O.TextFont.Size = 7;
                    O.TextFont.CharSet = 162;
                    O.Value = @"";

                    PB = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 250, 0, 264, 15, false);
                    PB.Name = "PB";
                    PB.DrawStyle = DrawStyleConstants.vbSolid;
                    PB.FieldType = ReportFieldTypeEnum.ftVariable;
                    PB.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PB.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PB.MultiLine = EvetHayirEnum.ehEvet;
                    PB.WordBreak = EvetHayirEnum.ehEvet;
                    PB.TextFont.Name = "Arial";
                    PB.TextFont.Size = 7;
                    PB.TextFont.CharSet = 162;
                    PB.Value = @"";

                    UKS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 0, 279, 15, false);
                    UKS.Name = "UKS";
                    UKS.DrawStyle = DrawStyleConstants.vbSolid;
                    UKS.FieldType = ReportFieldTypeEnum.ftVariable;
                    UKS.TextFormat = @"dd/MM/yyyy";
                    UKS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UKS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UKS.MultiLine = EvetHayirEnum.ehEvet;
                    UKS.WordBreak = EvetHayirEnum.ehEvet;
                    UKS.TextFont.Name = "Arial";
                    UKS.TextFont.Size = 7;
                    UKS.TextFont.CharSet = 162;
                    UKS.Value = @"";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 313, 17, 338, 24, false);
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

                    DELIVEREDPERSON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 0, 175, 15, false);
                    DELIVEREDPERSON.Name = "DELIVEREDPERSON";
                    DELIVEREDPERSON.DrawStyle = DrawStyleConstants.vbSolid;
                    DELIVEREDPERSON.FieldType = ReportFieldTypeEnum.ftVariable;
                    DELIVEREDPERSON.TextFormat = @"dd/MM/yyyy";
                    DELIVEREDPERSON.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DELIVEREDPERSON.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DELIVEREDPERSON.MultiLine = EvetHayirEnum.ehEvet;
                    DELIVEREDPERSON.WordBreak = EvetHayirEnum.ehEvet;
                    DELIVEREDPERSON.TextFont.Name = "Arial";
                    DELIVEREDPERSON.TextFont.Size = 7;
                    DELIVEREDPERSON.TextFont.CharSet = 162;
                    DELIVEREDPERSON.Value = @"";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 332, 2, 357, 7, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.Visible = EvetHayirEnum.ehHayir;
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"dd/MM/yyyy";
                    REQUESTDATE.Value = @"{#REQUESTDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRActionRequest.CMRActionHospitalReportQuery_Class dataset_CMRActionHospitalReportQuery = ParentGroup.rsGroup.GetCurrentRecord<CMRActionRequest.CMRActionHospitalReportQuery_Class>(0);
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    STOCKNO.CalcValue = (dataset_CMRActionHospitalReportQuery != null ? Globals.ToStringCore(dataset_CMRActionHospitalReportQuery.Stockno) : "") + @"
";
                    MATERIALNAME.CalcValue = (dataset_CMRActionHospitalReportQuery != null ? Globals.ToStringCore(dataset_CMRActionHospitalReportQuery.Materialname) : "");
                    CLINIC.CalcValue = (dataset_CMRActionHospitalReportQuery != null ? Globals.ToStringCore(dataset_CMRActionHospitalReportQuery.Sendersection) : "");
                    REQUESTNO.CalcValue = (dataset_CMRActionHospitalReportQuery != null ? Globals.ToStringCore(dataset_CMRActionHospitalReportQuery.RequestNo) : "");
                    DELIVERERUSER.CalcValue = @"";
                    WORKSHOP.CalcValue = (dataset_CMRActionHospitalReportQuery != null ? Globals.ToStringCore(dataset_CMRActionHospitalReportQuery.Workshopname) : "");
                    STARTDATE.CalcValue = (dataset_CMRActionHospitalReportQuery != null ? Globals.ToStringCore(dataset_CMRActionHospitalReportQuery.RequestDate) : "");
                    ENDDATE.CalcValue = @"";
                    O.CalcValue = @"";
                    PB.CalcValue = @"";
                    UKS.CalcValue = @"";
                    OBJECTID.CalcValue = (dataset_CMRActionHospitalReportQuery != null ? Globals.ToStringCore(dataset_CMRActionHospitalReportQuery.ObjectID) : "");
                    DELIVEREDPERSON.CalcValue = @"";
                    REQUESTDATE.CalcValue = (dataset_CMRActionHospitalReportQuery != null ? Globals.ToStringCore(dataset_CMRActionHospitalReportQuery.RequestDate) : "");
                    return new TTReportObject[] { COUNT,STOCKNO,MATERIALNAME,CLINIC,REQUESTNO,DELIVERERUSER,WORKSHOP,STARTDATE,ENDDATE,O,PB,UKS,OBJECTID,DELIVEREDPERSON,REQUESTDATE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext cont = new TTObjectContext(true);
            string requestno = this.REQUESTNO.CalcValue;
            BindingList<Repair.GetActualDeliveryDate_Class> list = Repair.GetActualDeliveryDate(cont, requestno);
            foreach (Repair.GetActualDeliveryDate_Class lst in list)
            {
                if(lst.RequestNo == requestno)
                    this.ENDDATE.CalcValue = lst.ActualDeliveryDate.ToString();
            }
          
            
                    if (TTUtils.Globals.IsGuid(OBJECTID.CalcValue))
            {
                Guid objectID = new Guid(OBJECTID.CalcValue);
                TTObjectContext ctx = new TTObjectContext(true);
                CMRAction baction = (CMRAction)ctx.GetObject(objectID, typeof(CMRAction));
                CMRAction action = null;
                if(MATERIALNAME.CalcValue == string.Empty)
                {
                    if (baction != null) //mca
                    {
                        if ((CMRActionRequest)baction != null)
                            if (((CMRActionRequest)baction).FixedAssetDefinition != null)
                                if (((CMRActionRequest)baction).FixedAssetDefinition.Name != string.Empty)
                                    MATERIALNAME.CalcValue = ((CMRActionRequest)baction).FixedAssetDefinition.Name;
                    }
                }


                if (baction != null)
                {
                    if (baction.ForkCMRAction.Count > 0)
                        action = ((CMRAction)baction.ForkCMRAction[0]);
                }

                if(action != null)
                {
                    if (action is Repair)
                    {
                        Repair repair = (Repair)action ;
                        if (action.CurrentStateDefID == Repair.States.Comleted)
                        {
                            O.CalcValue = "X";
                            
                            DELIVEREDPERSON.CalcValue = repair.DeliveredPerson;
                            if (repair.DelivererUser != null)
                                DELIVERERUSER.CalcValue = repair.DelivererUser.Name;
                        }
                        else if (action.CurrentStateDefID == Repair.States.Supply_Of_Materials)
                        {
                            PB.CalcValue = "X";

                            DELIVEREDPERSON.CalcValue = repair.DeliveredPerson; // mca
                            if (repair.DelivererUser != null)
                                DELIVERERUSER.CalcValue = repair.DelivererUser.Name;
                        }
                        else if (action.CurrentStateDefID == Repair.States.UpperStage)
                        {
                            UKS.CalcValue = "X";

                            DELIVEREDPERSON.CalcValue = repair.DeliveredPerson;  // mca
                            if (repair.DelivererUser != null)
                                DELIVERERUSER.CalcValue = repair.DelivererUser.Name;
                            
                        }
                    }
                    else if (action is Maintenance)
                    {
                        Maintenance maintenance = (Maintenance)action;
                        if (action.CurrentStateDefID == Maintenance.States.Completed)
                        {
                            O.CalcValue = "X";
                            if (maintenance.DelivererUser != null)
                                DELIVERERUSER.CalcValue = maintenance.DelivererUser.Name;
                            
                        }
                    }
                    else if (action is Calibration)
                    {
                        Calibration calibration = (Calibration)action;
                        if (action.CurrentStateDefID == Calibration.States.Completed)
                        {
                            O.CalcValue = "X";
                            if (calibration.DelivererUser != null)
                                DELIVERERUSER.CalcValue = calibration.DelivererUser.Name;
                        }
                    }
                    else if (action is MaterialMaintenance)
                    {
                        MaterialMaintenance materialMaintenance = (MaterialMaintenance)action;
                        if (action.CurrentStateDefID == MaterialMaintenance.States.Completed)
                        {
                            O.CalcValue = "X";
                            if (materialMaintenance.DelivererUser != null)
                                DELIVERERUSER.CalcValue = materialMaintenance.DelivererUser.Name;
                        }
                        
                    }
                    else if (action is MaterialRepair)
                    {
                        MaterialRepair materialRepair = (MaterialRepair)action;
                        if (action.CurrentStateDefID == MaterialRepair.States.Comleted)
                        {
                            O.CalcValue = "X";
                            DELIVEREDPERSON.CalcValue = materialRepair.DeliveredPerson;
                            if (materialRepair.DelivererUser != null)
                                DELIVERERUSER.CalcValue = materialRepair.DelivererUser.Name;
                        }
                        else if (action.CurrentStateDefID == MaterialRepair.States.Supply_Of_Materials)
                        {
                            PB.CalcValue = "X";

                            DELIVEREDPERSON.CalcValue = materialRepair.DeliveredPerson;
                            if (materialRepair.DelivererUser != null)
                                DELIVERERUSER.CalcValue = materialRepair.DelivererUser.Name;
                        }
                        else if (action.CurrentStateDefID == MaterialRepair.States.UpperStage)
                        {
                            UKS.CalcValue = "X";

                            DELIVEREDPERSON.CalcValue = materialRepair.DeliveredPerson;
                            if (materialRepair.DelivererUser != null)
                                DELIVERERUSER.CalcValue = materialRepair.DelivererUser.Name;
                        }
                    }
                    
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

        public CMRRegistrationHospitalReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "CMRREGISTRATIONHOSPITALREPORT";
            Caption = "Bağlı Birliklerden Sevk Edilen Cihazlar Raporu(XXXXXX)";
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