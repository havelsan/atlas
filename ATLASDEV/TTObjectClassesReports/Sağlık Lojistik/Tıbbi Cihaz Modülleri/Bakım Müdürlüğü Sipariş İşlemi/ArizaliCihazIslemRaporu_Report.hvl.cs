
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
    /// Arızalı Cihaz İşlem Raporu
    /// </summary>
    public partial class ArizaliCihazIslemRaporu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ArizaliCihazIslemRaporu MyParentReport
            {
                get { return (ArizaliCihazIslemRaporu)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField NewField11312 { get {return Header().NewField11312;} }
            public TTReportField NewField11313 { get {return Header().NewField11313;} }
            public TTReportField NewField11314 { get {return Header().NewField11314;} }
            public TTReportField NewField11315 { get {return Header().NewField11315;} }
            public TTReportField NewField151311 { get {return Header().NewField151311;} }
            public TTReportField NewField151312 { get {return Header().NewField151312;} }
            public TTReportField NewField151313 { get {return Header().NewField151313;} }
            public TTReportField NewField1313151 { get {return Header().NewField1313151;} }
            public TTReportField NewField1313152 { get {return Header().NewField1313152;} }
            public TTReportField NewField1313153 { get {return Header().NewField1313153;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField111311 { get {return Header().NewField111311;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
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
                public ArizaliCihazIslemRaporu MyParentReport
                {
                    get { return (ArizaliCihazIslemRaporu)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField1131;
                public TTReportField NewField11311;
                public TTReportField NewField11312;
                public TTReportField NewField11313;
                public TTReportField NewField11314;
                public TTReportField NewField11315;
                public TTReportField NewField151311;
                public TTReportField NewField151312;
                public TTReportField NewField151313;
                public TTReportField NewField1313151;
                public TTReportField NewField1313152;
                public TTReportField NewField1313153;
                public TTReportField NewField111;
                public TTReportField NewField111311; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 28;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 277, 10, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"ARIZALI CİHAZ İŞLEM RAPORU";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 7, 28, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 7;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"SIRA NU.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 15, 21, 28, false);
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
                    NewField11.Value = @"SİPARİŞ NU.";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 15, 67, 28, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 7;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"CİHAZI GÖNDEREN BİRLİK";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 15, 98, 28, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Size = 7;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"CİHAZIN
ADI";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 15, 123, 28, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11311.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11311.TextFont.Name = "Arial";
                    NewField11311.TextFont.Size = 7;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"İŞ-İSTEK BELGESİ GELİŞ TARİHİ";

                    NewField11312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 15, 137, 28, false);
                    NewField11312.Name = "NewField11312";
                    NewField11312.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11312.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11312.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11312.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11312.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11312.TextFont.Name = "Arial";
                    NewField11312.TextFont.Size = 7;
                    NewField11312.TextFont.Bold = true;
                    NewField11312.TextFont.CharSet = 162;
                    NewField11312.Value = @"CİHAZIN GELİŞ TARİHİ";

                    NewField11313 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 15, 156, 28, false);
                    NewField11313.Name = "NewField11313";
                    NewField11313.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11313.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11313.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11313.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11313.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11313.TextFont.Name = "Arial";
                    NewField11313.TextFont.Size = 7;
                    NewField11313.TextFont.Bold = true;
                    NewField11313.TextFont.CharSet = 162;
                    NewField11313.Value = @"CİHAZIN GÖNDERİLME AMACI";

                    NewField11314 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 15, 168, 28, false);
                    NewField11314.Name = "NewField11314";
                    NewField11314.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11314.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11314.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11314.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11314.TextFont.Name = "Arial";
                    NewField11314.TextFont.Size = 7;
                    NewField11314.TextFont.Bold = true;
                    NewField11314.TextFont.CharSet = 162;
                    NewField11314.Value = @"CİHAZIN
GELİŞ
ŞEKLİ";

                    NewField11315 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 15, 182, 28, false);
                    NewField11315.Name = "NewField11315";
                    NewField11315.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11315.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11315.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11315.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11315.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11315.TextFont.Name = "Arial";
                    NewField11315.TextFont.Size = 7;
                    NewField11315.TextFont.Bold = true;
                    NewField11315.TextFont.CharSet = 162;
                    NewField11315.Value = @"İLK MUAYENE TARİHİ";

                    NewField151311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 15, 198, 28, false);
                    NewField151311.Name = "NewField151311";
                    NewField151311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField151311.WordBreak = EvetHayirEnum.ehEvet;
                    NewField151311.TextFont.Name = "Arial";
                    NewField151311.TextFont.Size = 7;
                    NewField151311.TextFont.Bold = true;
                    NewField151311.TextFont.CharSet = 162;
                    NewField151311.Value = @"İLK MUAYENE KARARI";

                    NewField151312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 198, 15, 212, 28, false);
                    NewField151312.Name = "NewField151312";
                    NewField151312.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151312.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151312.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151312.MultiLine = EvetHayirEnum.ehEvet;
                    NewField151312.WordBreak = EvetHayirEnum.ehEvet;
                    NewField151312.TextFont.Name = "Arial";
                    NewField151312.TextFont.Size = 7;
                    NewField151312.TextFont.Bold = true;
                    NewField151312.TextFont.CharSet = 162;
                    NewField151312.Value = @"SON MUAYENE TARİHİ";

                    NewField151313 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 15, 229, 28, false);
                    NewField151313.Name = "NewField151313";
                    NewField151313.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151313.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151313.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151313.MultiLine = EvetHayirEnum.ehEvet;
                    NewField151313.TextFont.Name = "Arial";
                    NewField151313.TextFont.Size = 7;
                    NewField151313.TextFont.Bold = true;
                    NewField151313.TextFont.CharSet = 162;
                    NewField151313.Value = @"AMBALAJLAMA
GÖNDERME
TARİHİ";

                    NewField1313151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 15, 247, 28, false);
                    NewField1313151.Name = "NewField1313151";
                    NewField1313151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1313151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1313151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1313151.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1313151.TextFont.Name = "Arial";
                    NewField1313151.TextFont.Size = 7;
                    NewField1313151.TextFont.Bold = true;
                    NewField1313151.TextFont.CharSet = 162;
                    NewField1313151.Value = @"AMBALAJLAMA
GELİŞ
TARİHİ";

                    NewField1313152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 15, 261, 28, false);
                    NewField1313152.Name = "NewField1313152";
                    NewField1313152.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1313152.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1313152.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1313152.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1313152.TextFont.Name = "Arial";
                    NewField1313152.TextFont.Size = 7;
                    NewField1313152.TextFont.Bold = true;
                    NewField1313152.TextFont.CharSet = 162;
                    NewField1313152.Value = @"CİHAZIN
GİDİŞ
TARİHİ";

                    NewField1313153 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 261, 15, 277, 28, false);
                    NewField1313153.Name = "NewField1313153";
                    NewField1313153.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1313153.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1313153.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1313153.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1313153.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1313153.TextFont.Name = "Arial";
                    NewField1313153.TextFont.Size = 7;
                    NewField1313153.TextFont.Bold = true;
                    NewField1313153.TextFont.CharSet = 162;
                    NewField1313153.Value = @"CİHAZI GÖNDERME ŞEKLİ";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 15, 35, 28, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 7;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"FABRİKA SİPARİŞ NU.";

                    NewField111311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 15, 109, 28, false);
                    NewField111311.Name = "NewField111311";
                    NewField111311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111311.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111311.TextFont.Name = "Arial";
                    NewField111311.TextFont.Size = 7;
                    NewField111311.TextFont.Bold = true;
                    NewField111311.TextFont.CharSet = 162;
                    NewField111311.Value = @"MARKA MODEL SERİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField11312.CalcValue = NewField11312.Value;
                    NewField11313.CalcValue = NewField11313.Value;
                    NewField11314.CalcValue = NewField11314.Value;
                    NewField11315.CalcValue = NewField11315.Value;
                    NewField151311.CalcValue = NewField151311.Value;
                    NewField151312.CalcValue = NewField151312.Value;
                    NewField151313.CalcValue = NewField151313.Value;
                    NewField1313151.CalcValue = NewField1313151.Value;
                    NewField1313152.CalcValue = NewField1313152.Value;
                    NewField1313153.CalcValue = NewField1313153.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField111311.CalcValue = NewField111311.Value;
                    return new TTReportObject[] { REPORTNAME,NewField1,NewField11,NewField12,NewField1131,NewField11311,NewField11312,NewField11313,NewField11314,NewField11315,NewField151311,NewField151312,NewField151313,NewField1313151,NewField1313152,NewField1313153,NewField111,NewField111311};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ArizaliCihazIslemRaporu MyParentReport
                {
                    get { return (ArizaliCihazIslemRaporu)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportShape NewLine1111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 20;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 0, 152, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 252, 0, 277, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 277, 0, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PageNumber,CurrentUser};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public ArizaliCihazIslemRaporu MyParentReport
            {
                get { return (ArizaliCihazIslemRaporu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField MILITARYUNIT { get {return Body().MILITARYUNIT;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField REQUESTDATE { get {return Body().REQUESTDATE;} }
            public TTReportField ARRIVALDATE { get {return Body().ARRIVALDATE;} }
            public TTReportField FIRSTCHECKDATE { get {return Body().FIRSTCHECKDATE;} }
            public TTReportField LASTCHECKDATE { get {return Body().LASTCHECKDATE;} }
            public TTReportField PACKAGESENDINGDATE { get {return Body().PACKAGESENDINGDATE;} }
            public TTReportField PACKAGECOMINGDATE { get {return Body().PACKAGECOMINGDATE;} }
            public TTReportField SENDINGDATE { get {return Body().SENDINGDATE;} }
            public TTReportField REFERTYPE { get {return Body().REFERTYPE;} }
            public TTReportField ARRIVALTYPE { get {return Body().ARRIVALTYPE;} }
            public TTReportField FIRSTCHECKDECISION { get {return Body().FIRSTCHECKDECISION;} }
            public TTReportField SENDINGTYPE { get {return Body().SENDINGTYPE;} }
            public TTReportField REQUESTNO { get {return Body().REQUESTNO;} }
            public TTReportField MARKMODELSERIAL { get {return Body().MARKMODELSERIAL;} }
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
                list[0] = new TTReportNqlData<MaintenanceOrder.GetBrokenDownMaterialChaseReportQuery_Class>("GetBrokenDownMaterialChaseReportQuery", MaintenanceOrder.GetBrokenDownMaterialChaseReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public ArizaliCihazIslemRaporu MyParentReport
                {
                    get { return (ArizaliCihazIslemRaporu)ParentReport; }
                }
                
                public TTReportField COUNT;
                public TTReportField ORDERNO;
                public TTReportField MILITARYUNIT;
                public TTReportField MATERIALNAME;
                public TTReportField REQUESTDATE;
                public TTReportField ARRIVALDATE;
                public TTReportField FIRSTCHECKDATE;
                public TTReportField LASTCHECKDATE;
                public TTReportField PACKAGESENDINGDATE;
                public TTReportField PACKAGECOMINGDATE;
                public TTReportField SENDINGDATE;
                public TTReportField REFERTYPE;
                public TTReportField ARRIVALTYPE;
                public TTReportField FIRSTCHECKDECISION;
                public TTReportField SENDINGTYPE;
                public TTReportField REQUESTNO;
                public TTReportField MARKMODELSERIAL; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 7, 11, false);
                    COUNT.Name = "COUNT";
                    COUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT.MultiLine = EvetHayirEnum.ehEvet;
                    COUNT.WordBreak = EvetHayirEnum.ehEvet;
                    COUNT.TextFont.Name = "Arial";
                    COUNT.TextFont.Size = 7;
                    COUNT.TextFont.CharSet = 162;
                    COUNT.Value = @"{@counter@}";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 21, 11, false);
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
                    ORDERNO.Value = @"{#ORDERNO#}";

                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 0, 67, 11, false);
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
                    MILITARYUNIT.Value = @"{#MILITARYUNIT#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 0, 98, 11, false);
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

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 0, 123, 11, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"dd/MM/yyyy";
                    REQUESTDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTDATE.MultiLine = EvetHayirEnum.ehEvet;
                    REQUESTDATE.WordBreak = EvetHayirEnum.ehEvet;
                    REQUESTDATE.TextFont.Name = "Arial";
                    REQUESTDATE.TextFont.Size = 7;
                    REQUESTDATE.TextFont.CharSet = 162;
                    REQUESTDATE.Value = @"{#REQUESTDATE#}";

                    ARRIVALDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 0, 137, 11, false);
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

                    FIRSTCHECKDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 0, 182, 11, false);
                    FIRSTCHECKDATE.Name = "FIRSTCHECKDATE";
                    FIRSTCHECKDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRSTCHECKDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRSTCHECKDATE.TextFormat = @"dd/MM/yyyy";
                    FIRSTCHECKDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRSTCHECKDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRSTCHECKDATE.MultiLine = EvetHayirEnum.ehEvet;
                    FIRSTCHECKDATE.WordBreak = EvetHayirEnum.ehEvet;
                    FIRSTCHECKDATE.TextFont.Name = "Arial";
                    FIRSTCHECKDATE.TextFont.Size = 7;
                    FIRSTCHECKDATE.TextFont.CharSet = 162;
                    FIRSTCHECKDATE.Value = @"{#FIRSTCHECKDATE#}";

                    LASTCHECKDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 198, 0, 212, 11, false);
                    LASTCHECKDATE.Name = "LASTCHECKDATE";
                    LASTCHECKDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    LASTCHECKDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    LASTCHECKDATE.TextFormat = @"dd/MM/yyyy";
                    LASTCHECKDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LASTCHECKDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LASTCHECKDATE.MultiLine = EvetHayirEnum.ehEvet;
                    LASTCHECKDATE.WordBreak = EvetHayirEnum.ehEvet;
                    LASTCHECKDATE.TextFont.Name = "Arial";
                    LASTCHECKDATE.TextFont.Size = 7;
                    LASTCHECKDATE.TextFont.CharSet = 162;
                    LASTCHECKDATE.Value = @"{#LASTCHECKDATE#}";

                    PACKAGESENDINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 0, 229, 11, false);
                    PACKAGESENDINGDATE.Name = "PACKAGESENDINGDATE";
                    PACKAGESENDINGDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    PACKAGESENDINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PACKAGESENDINGDATE.TextFormat = @"dd/MM/yyyy";
                    PACKAGESENDINGDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PACKAGESENDINGDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PACKAGESENDINGDATE.MultiLine = EvetHayirEnum.ehEvet;
                    PACKAGESENDINGDATE.WordBreak = EvetHayirEnum.ehEvet;
                    PACKAGESENDINGDATE.TextFont.Name = "Arial";
                    PACKAGESENDINGDATE.TextFont.Size = 7;
                    PACKAGESENDINGDATE.TextFont.CharSet = 162;
                    PACKAGESENDINGDATE.Value = @"{#PACKAGINGDEPSENDINGDATE#}";

                    PACKAGECOMINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 0, 247, 11, false);
                    PACKAGECOMINGDATE.Name = "PACKAGECOMINGDATE";
                    PACKAGECOMINGDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    PACKAGECOMINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PACKAGECOMINGDATE.TextFormat = @"dd/MM/yyyy";
                    PACKAGECOMINGDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PACKAGECOMINGDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PACKAGECOMINGDATE.MultiLine = EvetHayirEnum.ehEvet;
                    PACKAGECOMINGDATE.WordBreak = EvetHayirEnum.ehEvet;
                    PACKAGECOMINGDATE.TextFont.Name = "Arial";
                    PACKAGECOMINGDATE.TextFont.Size = 7;
                    PACKAGECOMINGDATE.TextFont.CharSet = 162;
                    PACKAGECOMINGDATE.Value = @"{#PACKAGINGDEPRETURNDATE#}";

                    SENDINGDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 0, 261, 11, false);
                    SENDINGDATE.Name = "SENDINGDATE";
                    SENDINGDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    SENDINGDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENDINGDATE.TextFormat = @"dd/MM/yyyy";
                    SENDINGDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SENDINGDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SENDINGDATE.MultiLine = EvetHayirEnum.ehEvet;
                    SENDINGDATE.WordBreak = EvetHayirEnum.ehEvet;
                    SENDINGDATE.TextFont.Name = "Arial";
                    SENDINGDATE.TextFont.Size = 7;
                    SENDINGDATE.TextFont.CharSet = 162;
                    SENDINGDATE.Value = @"{#DEVICESENDINGDATE#}";

                    REFERTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 0, 156, 11, false);
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

                    ARRIVALTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 0, 168, 11, false);
                    ARRIVALTYPE.Name = "ARRIVALTYPE";
                    ARRIVALTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    ARRIVALTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ARRIVALTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ARRIVALTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ARRIVALTYPE.MultiLine = EvetHayirEnum.ehEvet;
                    ARRIVALTYPE.WordBreak = EvetHayirEnum.ehEvet;
                    ARRIVALTYPE.ObjectDefName = "ArrivalTypeEnum";
                    ARRIVALTYPE.DataMember = "DISPLAYTEXT";
                    ARRIVALTYPE.TextFont.Name = "Arial";
                    ARRIVALTYPE.TextFont.Size = 7;
                    ARRIVALTYPE.TextFont.CharSet = 162;
                    ARRIVALTYPE.Value = @"{#ARRIVALTYPE#}";

                    FIRSTCHECKDECISION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 0, 198, 11, false);
                    FIRSTCHECKDECISION.Name = "FIRSTCHECKDECISION";
                    FIRSTCHECKDECISION.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRSTCHECKDECISION.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRSTCHECKDECISION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIRSTCHECKDECISION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRSTCHECKDECISION.MultiLine = EvetHayirEnum.ehEvet;
                    FIRSTCHECKDECISION.WordBreak = EvetHayirEnum.ehEvet;
                    FIRSTCHECKDECISION.ObjectDefName = "FirstExamResultEnum";
                    FIRSTCHECKDECISION.DataMember = "DISPLAYTEXT";
                    FIRSTCHECKDECISION.TextFont.Name = "Arial";
                    FIRSTCHECKDECISION.TextFont.Size = 7;
                    FIRSTCHECKDECISION.TextFont.CharSet = 162;
                    FIRSTCHECKDECISION.Value = @"{#FIRSTEXAMSTATUS#}";

                    SENDINGTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 261, 0, 277, 11, false);
                    SENDINGTYPE.Name = "SENDINGTYPE";
                    SENDINGTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    SENDINGTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENDINGTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SENDINGTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SENDINGTYPE.MultiLine = EvetHayirEnum.ehEvet;
                    SENDINGTYPE.WordBreak = EvetHayirEnum.ehEvet;
                    SENDINGTYPE.ObjectDefName = "ArrivalTypeEnum";
                    SENDINGTYPE.DataMember = "DISPLAYTEXT";
                    SENDINGTYPE.TextFont.Name = "Arial";
                    SENDINGTYPE.TextFont.Size = 7;
                    SENDINGTYPE.TextFont.CharSet = 162;
                    SENDINGTYPE.Value = @"{#SENDINGTYPE#}";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 0, 35, 11, false);
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

                    MARKMODELSERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 0, 109, 11, false);
                    MARKMODELSERIAL.Name = "MARKMODELSERIAL";
                    MARKMODELSERIAL.DrawStyle = DrawStyleConstants.vbSolid;
                    MARKMODELSERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARKMODELSERIAL.TextFormat = @"dd/MM/yyyy";
                    MARKMODELSERIAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MARKMODELSERIAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARKMODELSERIAL.MultiLine = EvetHayirEnum.ehEvet;
                    MARKMODELSERIAL.WordBreak = EvetHayirEnum.ehEvet;
                    MARKMODELSERIAL.TextFont.Name = "Arial";
                    MARKMODELSERIAL.TextFont.Size = 7;
                    MARKMODELSERIAL.TextFont.CharSet = 162;
                    MARKMODELSERIAL.Value = @"{#MARK#}
{#MODEL#}
{#SERIALNUMBER#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetBrokenDownMaterialChaseReportQuery_Class dataset_GetBrokenDownMaterialChaseReportQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetBrokenDownMaterialChaseReportQuery_Class>(0);
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    ORDERNO.CalcValue = (dataset_GetBrokenDownMaterialChaseReportQuery != null ? Globals.ToStringCore(dataset_GetBrokenDownMaterialChaseReportQuery.OrderNO) : "");
                    MILITARYUNIT.CalcValue = (dataset_GetBrokenDownMaterialChaseReportQuery != null ? Globals.ToStringCore(dataset_GetBrokenDownMaterialChaseReportQuery.Militaryunit) : "");
                    MATERIALNAME.CalcValue = (dataset_GetBrokenDownMaterialChaseReportQuery != null ? Globals.ToStringCore(dataset_GetBrokenDownMaterialChaseReportQuery.Materialname) : "");
                    REQUESTDATE.CalcValue = (dataset_GetBrokenDownMaterialChaseReportQuery != null ? Globals.ToStringCore(dataset_GetBrokenDownMaterialChaseReportQuery.RequestDate) : "");
                    ARRIVALDATE.CalcValue = (dataset_GetBrokenDownMaterialChaseReportQuery != null ? Globals.ToStringCore(dataset_GetBrokenDownMaterialChaseReportQuery.ArrivalDate) : "");
                    FIRSTCHECKDATE.CalcValue = (dataset_GetBrokenDownMaterialChaseReportQuery != null ? Globals.ToStringCore(dataset_GetBrokenDownMaterialChaseReportQuery.Firstcheckdate) : "");
                    LASTCHECKDATE.CalcValue = (dataset_GetBrokenDownMaterialChaseReportQuery != null ? Globals.ToStringCore(dataset_GetBrokenDownMaterialChaseReportQuery.Lastcheckdate) : "");
                    PACKAGESENDINGDATE.CalcValue = (dataset_GetBrokenDownMaterialChaseReportQuery != null ? Globals.ToStringCore(dataset_GetBrokenDownMaterialChaseReportQuery.PackagingDepSendingDate) : "");
                    PACKAGECOMINGDATE.CalcValue = (dataset_GetBrokenDownMaterialChaseReportQuery != null ? Globals.ToStringCore(dataset_GetBrokenDownMaterialChaseReportQuery.PackagingDepReturnDate) : "");
                    SENDINGDATE.CalcValue = (dataset_GetBrokenDownMaterialChaseReportQuery != null ? Globals.ToStringCore(dataset_GetBrokenDownMaterialChaseReportQuery.DeviceSendingDate) : "");
                    REFERTYPE.CalcValue = (dataset_GetBrokenDownMaterialChaseReportQuery != null ? Globals.ToStringCore(dataset_GetBrokenDownMaterialChaseReportQuery.ReferType) : "");
                    REFERTYPE.PostFieldValueCalculation();
                    ARRIVALTYPE.CalcValue = (dataset_GetBrokenDownMaterialChaseReportQuery != null ? Globals.ToStringCore(dataset_GetBrokenDownMaterialChaseReportQuery.ArrivalType) : "");
                    ARRIVALTYPE.PostFieldValueCalculation();
                    FIRSTCHECKDECISION.CalcValue = (dataset_GetBrokenDownMaterialChaseReportQuery != null ? Globals.ToStringCore(dataset_GetBrokenDownMaterialChaseReportQuery.FirstExamStatus) : "");
                    FIRSTCHECKDECISION.PostFieldValueCalculation();
                    SENDINGTYPE.CalcValue = (dataset_GetBrokenDownMaterialChaseReportQuery != null ? Globals.ToStringCore(dataset_GetBrokenDownMaterialChaseReportQuery.Sendingtype) : "");
                    SENDINGTYPE.PostFieldValueCalculation();
                    REQUESTNO.CalcValue = (dataset_GetBrokenDownMaterialChaseReportQuery != null ? Globals.ToStringCore(dataset_GetBrokenDownMaterialChaseReportQuery.RequestNo) : "");
                    MARKMODELSERIAL.CalcValue = (dataset_GetBrokenDownMaterialChaseReportQuery != null ? Globals.ToStringCore(dataset_GetBrokenDownMaterialChaseReportQuery.Mark) : "") + @"
" + (dataset_GetBrokenDownMaterialChaseReportQuery != null ? Globals.ToStringCore(dataset_GetBrokenDownMaterialChaseReportQuery.Model) : "") + @"
" + (dataset_GetBrokenDownMaterialChaseReportQuery != null ? Globals.ToStringCore(dataset_GetBrokenDownMaterialChaseReportQuery.SerialNumber) : "");
                    return new TTReportObject[] { COUNT,ORDERNO,MILITARYUNIT,MATERIALNAME,REQUESTDATE,ARRIVALDATE,FIRSTCHECKDATE,LASTCHECKDATE,PACKAGESENDINGDATE,PACKAGECOMINGDATE,SENDINGDATE,REFERTYPE,ARRIVALTYPE,FIRSTCHECKDECISION,SENDINGTYPE,REQUESTNO,MARKMODELSERIAL};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ArizaliCihazIslemRaporu()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihini Giriniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "ARIZALICIHAZISLEMRAPORU";
            Caption = "Arızalı Cihaz İşlem Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 10;
            UserMarginTop = 10;
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