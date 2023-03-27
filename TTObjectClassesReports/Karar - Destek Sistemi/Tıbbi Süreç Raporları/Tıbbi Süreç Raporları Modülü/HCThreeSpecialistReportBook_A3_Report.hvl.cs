
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
    /// Üç Uzman Tabip İmzalı Rapor Defteri (A3)
    /// </summary>
    public partial class HCThreeSpecialistReportBook_A3 : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public HCThreeSpecialistReportBook_A3 MyParentReport
            {
                get { return (HCThreeSpecialistReportBook_A3)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField BASLIK { get {return Header().BASLIK;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField PAGENUMBER { get {return Footer().PAGENUMBER;} }
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
                public HCThreeSpecialistReportBook_A3 MyParentReport
                {
                    get { return (HCThreeSpecialistReportBook_A3)ParentReport; }
                }
                
                public TTReportField BASLIK;
                public TTReportField DATE;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 30;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 17, 392, 25, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.TextFont.Size = 14;
                    BASLIK.TextFont.Bold = true;
                    BASLIK.TextFont.CharSet = 162;
                    BASLIK.Value = @"";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 344, 25, 394, 30, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"dd/MM/yyyy";
                    DATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATE.MultiLine = EvetHayirEnum.ehEvet;
                    DATE.WordBreak = EvetHayirEnum.ehEvet;
                    DATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    DATE.TextFont.CharSet = 162;
                    DATE.Value = @"{%STARTDATE%} - {%ENDDATE%}";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 427, 10, 452, 15, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 427, 20, 452, 25, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    BASLIK.CalcValue = @"";
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    DATE.CalcValue = MyParentReport.PARTA.STARTDATE.FormattedValue + @" - " + MyParentReport.PARTA.ENDDATE.FormattedValue;
                    return new TTReportObject[] { BASLIK,STARTDATE,ENDDATE,DATE};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            ResHospital hospital = TTObjectClasses.Common.GetCurrentHospital(context);
            
            BASLIK.CalcValue = hospital.Name + " ÜÇ UZMAN TABİP İMZALI RAPOR DEFTERİ";

            ((HCThreeSpecialistReportBook_A3)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((HCThreeSpecialistReportBook_A3)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public HCThreeSpecialistReportBook_A3 MyParentReport
                {
                    get { return (HCThreeSpecialistReportBook_A3)ParentReport; }
                }
                
                public TTReportField PAGENUMBER; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 18;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 1, 394, 6, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAGENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER.TextFont.CharSet = 162;
                    PAGENUMBER.Value = @"Sayfa Nu: {@pagenumber@} / {@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PAGENUMBER.CalcValue = @"Sayfa Nu: " + ParentReport.CurrentPageNumber.ToString() + @" / " + ParentReport.ReportTotalPageCount;
                    return new TTReportObject[] { PAGENUMBER};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class CAPTIONGroup : TTReportGroup
        {
            public HCThreeSpecialistReportBook_A3 MyParentReport
            {
                get { return (HCThreeSpecialistReportBook_A3)ParentReport; }
            }

            new public CAPTIONGroupHeader Header()
            {
                return (CAPTIONGroupHeader)_header;
            }

            new public CAPTIONGroupFooter Footer()
            {
                return (CAPTIONGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField NewField133 { get {return Header().NewField133;} }
            public TTReportField NewField134 { get {return Header().NewField134;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportShape NewLine1211 { get {return Header().NewLine1211;} }
            public TTReportShape NewLine1311 { get {return Header().NewLine1311;} }
            public TTReportShape NewLine1411 { get {return Header().NewLine1411;} }
            public TTReportShape NewLine1511 { get {return Header().NewLine1511;} }
            public TTReportShape NewLine1611 { get {return Header().NewLine1611;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine11161 { get {return Header().NewLine11161;} }
            public TTReportShape NewLine1121 { get {return Header().NewLine1121;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportShape NewLine122 { get {return Header().NewLine122;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportShape NewLine112 { get {return Footer().NewLine112;} }
            public TTReportShape NewLine1112 { get {return Footer().NewLine1112;} }
            public TTReportShape NewLine1212 { get {return Footer().NewLine1212;} }
            public TTReportShape NewLine1312 { get {return Footer().NewLine1312;} }
            public TTReportShape NewLine1412 { get {return Footer().NewLine1412;} }
            public TTReportShape NewLine1512 { get {return Footer().NewLine1512;} }
            public TTReportShape NewLine1612 { get {return Footer().NewLine1612;} }
            public TTReportShape NewLine1711 { get {return Footer().NewLine1711;} }
            public CAPTIONGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public CAPTIONGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new CAPTIONGroupHeader(this);
                _footer = new CAPTIONGroupFooter(this);

            }

            public partial class CAPTIONGroupHeader : TTReportSection
            {
                public HCThreeSpecialistReportBook_A3 MyParentReport
                {
                    get { return (HCThreeSpecialistReportBook_A3)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField131;
                public TTReportField NewField132;
                public TTReportField NewField133;
                public TTReportField NewField134;
                public TTReportShape NewLine111;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine1211;
                public TTReportShape NewLine1311;
                public TTReportShape NewLine1411;
                public TTReportShape NewLine1511;
                public TTReportShape NewLine1611;
                public TTReportShape NewLine12;
                public TTReportShape NewLine11161;
                public TTReportShape NewLine1121;
                public TTReportShape NewLine121;
                public TTReportShape NewLine122; 
                public CAPTIONGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 4, 52, 13, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Rapor Nu ve Tarihi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 4, 104, 13, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Muayeneye Gönderen Makam Tarih ve Nu";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 4, 153, 13, false);
                    NewField13.Name = "NewField13";
                    NewField13.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"AÇIK KÜNYESİ";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 4, 200, 13, false);
                    NewField131.Name = "NewField131";
                    NewField131.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"GÖNDERİLEN MAKAM";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 4, 245, 13, false);
                    NewField132.Name = "NewField132";
                    NewField132.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField132.MultiLine = EvetHayirEnum.ehEvet;
                    NewField132.WordBreak = EvetHayirEnum.ehEvet;
                    NewField132.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField132.TextFont.Bold = true;
                    NewField132.TextFont.CharSet = 162;
                    NewField132.Value = @"TEŞHİS";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 4, 359, 13, false);
                    NewField133.Name = "NewField133";
                    NewField133.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField133.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField133.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField133.MultiLine = EvetHayirEnum.ehEvet;
                    NewField133.WordBreak = EvetHayirEnum.ehEvet;
                    NewField133.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField133.TextFont.Bold = true;
                    NewField133.TextFont.CharSet = 162;
                    NewField133.Value = @"KARAR";

                    NewField134 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 359, 4, 394, 13, false);
                    NewField134.Name = "NewField134";
                    NewField134.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField134.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField134.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField134.MultiLine = EvetHayirEnum.ehEvet;
                    NewField134.WordBreak = EvetHayirEnum.ehEvet;
                    NewField134.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField134.TextFont.Bold = true;
                    NewField134.TextFont.CharSet = 162;
                    NewField134.Value = @"FOTO";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 34, 4, 34, 13, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 52, 4, 52, 13, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 104, 4, 104, 13, false);
                    NewLine1211.Name = "NewLine1211";
                    NewLine1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1211.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 153, 4, 153, 13, false);
                    NewLine1311.Name = "NewLine1311";
                    NewLine1311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1311.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1411 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 4, 200, 13, false);
                    NewLine1411.Name = "NewLine1411";
                    NewLine1411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1411.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 245, 4, 245, 13, false);
                    NewLine1511.Name = "NewLine1511";
                    NewLine1511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1511.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1611 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 359, 4, 359, 13, false);
                    NewLine1611.Name = "NewLine1611";
                    NewLine1611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1611.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 117, 4, 394, 4, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 394, 4, 394, 13, false);
                    NewLine11161.Name = "NewLine11161";
                    NewLine11161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11161.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 117, 13, 394, 13, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 34, 4, 120, 4, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 34, 13, 151, 13, false);
                    NewLine122.Name = "NewLine122";
                    NewLine122.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField133.CalcValue = NewField133.Value;
                    NewField134.CalcValue = NewField134.Value;
                    return new TTReportObject[] { NewField1,NewField12,NewField13,NewField131,NewField132,NewField133,NewField134};
                }
            }
            public partial class CAPTIONGroupFooter : TTReportSection
            {
                public HCThreeSpecialistReportBook_A3 MyParentReport
                {
                    get { return (HCThreeSpecialistReportBook_A3)ParentReport; }
                }
                
                public TTReportShape NewLine11;
                public TTReportShape NewLine112;
                public TTReportShape NewLine1112;
                public TTReportShape NewLine1212;
                public TTReportShape NewLine1312;
                public TTReportShape NewLine1412;
                public TTReportShape NewLine1512;
                public TTReportShape NewLine1612;
                public TTReportShape NewLine1711; 
                public CAPTIONGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 34, 2, 394, 2, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 34, 0, 34, 2, false);
                    NewLine112.Name = "NewLine112";
                    NewLine112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine112.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 52, 0, 52, 2, false);
                    NewLine1112.Name = "NewLine1112";
                    NewLine1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1112.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1212 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 104, 0, 104, 2, false);
                    NewLine1212.Name = "NewLine1212";
                    NewLine1212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1212.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1312 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 153, 0, 153, 2, false);
                    NewLine1312.Name = "NewLine1312";
                    NewLine1312.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1312.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1412 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 0, 200, 2, false);
                    NewLine1412.Name = "NewLine1412";
                    NewLine1412.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1412.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1512 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 245, 0, 245, 2, false);
                    NewLine1512.Name = "NewLine1512";
                    NewLine1512.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1512.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1612 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 359, 0, 359, 2, false);
                    NewLine1612.Name = "NewLine1612";
                    NewLine1612.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1612.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1711 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 394, 0, 394, 2, false);
                    NewLine1711.Name = "NewLine1711";
                    NewLine1711.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1711.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public CAPTIONGroup CAPTION;

        public partial class PARTBGroup : TTReportGroup
        {
            public HCThreeSpecialistReportBook_A3 MyParentReport
            {
                get { return (HCThreeSpecialistReportBook_A3)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialistsByDate_Class>("GetHCWithThreeSpecialistsByDate2", HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialistsByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public HCThreeSpecialistReportBook_A3 MyParentReport
                {
                    get { return (HCThreeSpecialistReportBook_A3)ParentReport; }
                }
                 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public HCThreeSpecialistReportBook_A3 MyParentReport
                {
                    get { return (HCThreeSpecialistReportBook_A3)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public HCThreeSpecialistReportBook_A3 MyParentReport
            {
                get { return (HCThreeSpecialistReportBook_A3)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField REPORTNODATE { get {return Body().REPORTNODATE;} }
            public TTReportField SENDERDATENO { get {return Body().SENDERDATENO;} }
            public TTReportField INFOS { get {return Body().INFOS;} }
            public TTReportField GONDERILEN { get {return Body().GONDERILEN;} }
            public TTReportField TESHIS { get {return Body().TESHIS;} }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public TTReportField FOTO { get {return Body().FOTO;} }
            public TTReportField RTAR { get {return Body().RTAR;} }
            public TTReportField AD { get {return Body().AD;} }
            public TTReportField TCNO { get {return Body().TCNO;} }
            public TTReportField DTARIHI { get {return Body().DTARIHI;} }
            public TTReportField BABAAD { get {return Body().BABAAD;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportShape NewLine1111 { get {return Body().NewLine1111;} }
            public TTReportShape NewLine11111 { get {return Body().NewLine11111;} }
            public TTReportShape NewLine111111 { get {return Body().NewLine111111;} }
            public TTReportShape NewLine111112 { get {return Body().NewLine111112;} }
            public TTReportShape NewLine111113 { get {return Body().NewLine111113;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportField DYERI { get {return Body().DYERI;} }
            public TTReportField XXXXXXLIKSUBESI { get {return Body().XXXXXXLIKSUBESI;} }
            public TTReportField MADDE { get {return Body().MADDE;} }
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
                public HCThreeSpecialistReportBook_A3 MyParentReport
                {
                    get { return (HCThreeSpecialistReportBook_A3)ParentReport; }
                }
                
                public TTReportField REPORTNODATE;
                public TTReportField SENDERDATENO;
                public TTReportField INFOS;
                public TTReportField GONDERILEN;
                public TTReportField TESHIS;
                public TTReportField KARAR;
                public TTReportField FOTO;
                public TTReportField RTAR;
                public TTReportField AD;
                public TTReportField TCNO;
                public TTReportField DTARIHI;
                public TTReportField BABAAD;
                public TTReportField OBJECTID;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine11111;
                public TTReportShape NewLine111111;
                public TTReportShape NewLine111112;
                public TTReportShape NewLine111113;
                public TTReportShape NewLine121;
                public TTReportField DYERI;
                public TTReportField XXXXXXLIKSUBESI;
                public TTReportField MADDE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 41;
                    RepeatCount = 0;
                    
                    REPORTNODATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 0, 52, 42, false);
                    REPORTNODATE.Name = "REPORTNODATE";
                    REPORTNODATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTNODATE.MultiLine = EvetHayirEnum.ehEvet;
                    REPORTNODATE.NoClip = EvetHayirEnum.ehEvet;
                    REPORTNODATE.WordBreak = EvetHayirEnum.ehEvet;
                    REPORTNODATE.TextFont.Size = 11;
                    REPORTNODATE.TextFont.CharSet = 162;
                    REPORTNODATE.Value = @"{#PARTB.RAPORNO#}

{%RTAR%}";

                    SENDERDATENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 0, 104, 42, false);
                    SENDERDATENO.Name = "SENDERDATENO";
                    SENDERDATENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENDERDATENO.MultiLine = EvetHayirEnum.ehEvet;
                    SENDERDATENO.NoClip = EvetHayirEnum.ehEvet;
                    SENDERDATENO.WordBreak = EvetHayirEnum.ehEvet;
                    SENDERDATENO.TextFont.Size = 9;
                    SENDERDATENO.TextFont.CharSet = 162;
                    SENDERDATENO.Value = @"";

                    INFOS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 0, 153, 42, false);
                    INFOS.Name = "INFOS";
                    INFOS.FieldType = ReportFieldTypeEnum.ftVariable;
                    INFOS.MultiLine = EvetHayirEnum.ehEvet;
                    INFOS.NoClip = EvetHayirEnum.ehEvet;
                    INFOS.WordBreak = EvetHayirEnum.ehEvet;
                    INFOS.TextFont.Size = 9;
                    INFOS.TextFont.CharSet = 162;
                    INFOS.Value = @"";

                    GONDERILEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 0, 200, 42, false);
                    GONDERILEN.Name = "GONDERILEN";
                    GONDERILEN.FieldType = ReportFieldTypeEnum.ftVariable;
                    GONDERILEN.MultiLine = EvetHayirEnum.ehEvet;
                    GONDERILEN.NoClip = EvetHayirEnum.ehEvet;
                    GONDERILEN.WordBreak = EvetHayirEnum.ehEvet;
                    GONDERILEN.TextFont.Size = 9;
                    GONDERILEN.TextFont.CharSet = 162;
                    GONDERILEN.Value = @"";

                    TESHIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 201, 0, 245, 42, false);
                    TESHIS.Name = "TESHIS";
                    TESHIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESHIS.MultiLine = EvetHayirEnum.ehEvet;
                    TESHIS.NoClip = EvetHayirEnum.ehEvet;
                    TESHIS.WordBreak = EvetHayirEnum.ehEvet;
                    TESHIS.TextFont.Size = 9;
                    TESHIS.TextFont.CharSet = 162;
                    TESHIS.Value = @"";

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 0, 359, 42, false);
                    KARAR.Name = "KARAR";
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR.NoClip = EvetHayirEnum.ehEvet;
                    KARAR.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR.TextFont.Size = 9;
                    KARAR.TextFont.CharSet = 162;
                    KARAR.Value = @"";

                    FOTO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 359, 0, 394, 42, false);
                    FOTO.Name = "FOTO";
                    FOTO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FOTO.NoClip = EvetHayirEnum.ehEvet;
                    FOTO.TextFont.Size = 9;
                    FOTO.TextFont.CharSet = 162;
                    FOTO.Value = @"";

                    RTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 429, 16, 454, 21, false);
                    RTAR.Name = "RTAR";
                    RTAR.Visible = EvetHayirEnum.ehHayir;
                    RTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    RTAR.TextFormat = @"Short Date";
                    RTAR.Value = @"{#PARTB.RAPORTARIHI#}";

                    AD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 429, 2, 454, 7, false);
                    AD.Name = "AD";
                    AD.Visible = EvetHayirEnum.ehHayir;
                    AD.FieldType = ReportFieldTypeEnum.ftVariable;
                    AD.ObjectDefName = "Patient";
                    AD.DataMember = "FullName";
                    AD.Value = @"{#PARTB.PATIENTID#}";

                    TCNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 429, 9, 454, 14, false);
                    TCNO.Name = "TCNO";
                    TCNO.Visible = EvetHayirEnum.ehHayir;
                    TCNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCNO.ObjectDefName = "Patient";
                    TCNO.DataMember = "UNIQUEREFNO";
                    TCNO.Value = @"{#PARTB.PATIENTID#}";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 429, 24, 454, 29, false);
                    DTARIHI.Name = "DTARIHI";
                    DTARIHI.Visible = EvetHayirEnum.ehHayir;
                    DTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHI.TextFormat = @"Short Date";
                    DTARIHI.ObjectDefName = "Patient";
                    DTARIHI.DataMember = "BIRTHDATE";
                    DTARIHI.Value = @"{#PARTB.PATIENTID#}";

                    BABAAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 459, 16, 484, 21, false);
                    BABAAD.Name = "BABAAD";
                    BABAAD.Visible = EvetHayirEnum.ehHayir;
                    BABAAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAAD.ObjectDefName = "Patient";
                    BABAAD.DataMember = "FATHERNAME";
                    BABAAD.Value = @"{#PARTB.PATIENTID#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 459, 9, 484, 14, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#PARTB.OBJECTID#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 34, 0, 34, 42, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 52, 0, 52, 42, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 104, 0, 104, 42, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 153, 0, 153, 42, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 0, 200, 42, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 245, 0, 245, 42, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111111.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine111112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 359, 0, 359, 42, false);
                    NewLine111112.Name = "NewLine111112";
                    NewLine111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111112.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine111113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 394, 0, 394, 42, false);
                    NewLine111113.Name = "NewLine111113";
                    NewLine111113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111113.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 34, 0, 394, 0, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    DYERI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 459, 2, 484, 7, false);
                    DYERI.Name = "DYERI";
                    DYERI.Visible = EvetHayirEnum.ehHayir;
                    DYERI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERI.TextFont.Size = 8;
                    DYERI.TextFont.CharSet = 162;
                    DYERI.Value = @"{#PARTB.DYERI#}";

                    XXXXXXLIKSUBESI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 459, 24, 484, 29, false);
                    XXXXXXLIKSUBESI.Name = "XXXXXXLIKSUBESI";
                    XXXXXXLIKSUBESI.Visible = EvetHayirEnum.ehHayir;
                    XXXXXXLIKSUBESI.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXLIKSUBESI.Value = @"";

                    MADDE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 429, 31, 454, 36, false);
                    MADDE.Name = "MADDE";
                    MADDE.Visible = EvetHayirEnum.ehHayir;
                    MADDE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialistsByDate_Class dataset_GetHCWithThreeSpecialistsByDate2 = MyParentReport.PARTB.rsGroup.GetCurrentRecord<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialistsByDate_Class>(0);
                    RTAR.CalcValue = (dataset_GetHCWithThreeSpecialistsByDate2 != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialistsByDate2.Raportarihi) : "");
                    REPORTNODATE.CalcValue = (dataset_GetHCWithThreeSpecialistsByDate2 != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialistsByDate2.Raporno) : "") + @"

" + MyParentReport.MAIN.RTAR.FormattedValue;
                    SENDERDATENO.CalcValue = @"";
                    INFOS.CalcValue = @"";
                    GONDERILEN.CalcValue = @"";
                    TESHIS.CalcValue = @"";
                    KARAR.CalcValue = @"";
                    FOTO.CalcValue = @"";
                    AD.CalcValue = (dataset_GetHCWithThreeSpecialistsByDate2 != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialistsByDate2.Patientid) : "");
                    AD.PostFieldValueCalculation();
                    TCNO.CalcValue = (dataset_GetHCWithThreeSpecialistsByDate2 != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialistsByDate2.Patientid) : "");
                    TCNO.PostFieldValueCalculation();
                    DTARIHI.CalcValue = (dataset_GetHCWithThreeSpecialistsByDate2 != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialistsByDate2.Patientid) : "");
                    DTARIHI.PostFieldValueCalculation();
                    BABAAD.CalcValue = (dataset_GetHCWithThreeSpecialistsByDate2 != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialistsByDate2.Patientid) : "");
                    BABAAD.PostFieldValueCalculation();
                    OBJECTID.CalcValue = (dataset_GetHCWithThreeSpecialistsByDate2 != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialistsByDate2.ObjectID) : "");
                    DYERI.CalcValue = (dataset_GetHCWithThreeSpecialistsByDate2 != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialistsByDate2.Dyeri) : "");
                    XXXXXXLIKSUBESI.CalcValue = @"";
                    MADDE.CalcValue = @"";
                    return new TTReportObject[] { RTAR,REPORTNODATE,SENDERDATENO,INFOS,GONDERILEN,TESHIS,KARAR,FOTO,AD,TCNO,DTARIHI,BABAAD,OBJECTID,DYERI,XXXXXXLIKSUBESI,MADDE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string sObjectID = this.OBJECTID.CalcValue.ToString();
            TTObjectContext context = new TTObjectContext(true);
            HealthCommitteeWithThreeSpecialist hcp = (HealthCommitteeWithThreeSpecialist)context.GetObject(new Guid(sObjectID),"HealthCommitteeWithThreeSpecialist");
//            MilitaryClassDefinitions pMilClass = hcp.Episode.MilitaryClass;
//            RankDefinitions pRank = hcp.Episode.Rank;
//            
//            string force = hcp.Episode.ForcesCommand != null ? hcp.Episode.ForcesCommand.Qref : "";
//            string milClassAndRank = string.Empty;
            
            if(hcp == null)
                throw new Exception("Rapor Sağlık Kurulu Üç İmza işlemi üzerinden alınmalıdır.\r\nReason: HealthCommitteeWithThreeSpecialist is null");
            
            this.INFOS.CalcValue = this.AD.CalcValue + "\r\n";
            this.INFOS.CalcValue += "Doğum Tarihi: " + this.DTARIHI.FormattedValue + "\r\n";
            this.INFOS.CalcValue += "Doğum Yeri: " + this.DYERI.CalcValue + "\r\n";
            this.INFOS.CalcValue += "T.C. No: " + this.TCNO.CalcValue + "\r\n";
            this.INFOS.CalcValue += "Baba Adı: " + this.BABAAD.CalcValue + "\r\n";
            
            // sınıf ve rütbe boş ise hasta grubu gelsin istendi (erler için falan)
//            if (hcp.Episode.MilitaryClass == null && hcp.Episode.Rank == null)
//                milClassAndRank = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hcp.Episode.PatientGroup.Value);
//            else
//                milClassAndRank = (pMilClass == null ? "" : pMilClass.Name) + " " + (pRank == null ? "" : pRank.Name);
//            
//            this.INFOS.CalcValue += "Kuvvet: " + force + "\r\n";
//            this.INFOS.CalcValue += "Sınıf-Rütbe: " + milClassAndRank + "\r\n";
//            this.INFOS.CalcValue += "As. Şubesi: " + this.XXXXXXLIKSUBESI.CalcValue + "\r\n";
            
            
            //Tanı
            this.TESHIS.CalcValue = hcp.GetMyOrEpisodeDiagnosis();
            /*
            int nCount = 1;
            this.TESHIS.CalcValue = "";
            BindingList<DiagnosisGrid.GetDiagnosisByParent_Class> pDiagnosis = DiagnosisGrid.GetDiagnosisByParent(sObjectID);
            foreach(DiagnosisGrid.GetDiagnosisByParent_Class pGrid in pDiagnosis)
            {
                this.TESHIS.CalcValue += nCount.ToString() + "- " + pGrid.Tanikodu + " " + pGrid.Taniadi;
                if (pGrid.Serbesttani != null)
                    this.TESHIS.CalcValue += " (" + pGrid.Serbesttani + ")";
                this.TESHIS.CalcValue += "\r\n";
                nCount++;
            }
             */
            BindingList<HCWithThreeSpecialist_MatterSliceAnectodeGrid.GetHCWTS_MatterSliceAnectodeGridByParent_Class> theAnectodes = HCWithThreeSpecialist_MatterSliceAnectodeGrid.GetHCWTS_MatterSliceAnectodeGridByParent(sObjectID);
            if (theAnectodes.Count > 0)
            {
                this.MADDE.CalcValue = "[";
                foreach (HCWithThreeSpecialist_MatterSliceAnectodeGrid.GetHCWTS_MatterSliceAnectodeGridByParent_Class theAnectode in theAnectodes)
                {
                    this.MADDE.CalcValue += theAnectode.Matter+"/"+theAnectode.HalfSlice+"/"+theAnectode.Anectode;
                    this.MADDE.CalcValue += "  ";
                }
                this.MADDE.CalcValue = this.MADDE.CalcValue.Substring(0, this.MADDE.CalcValue.Length - 2);
                this.MADDE.CalcValue += "]";
                
                this.KARAR.CalcValue += this.MADDE.CalcValue + "\r\n";
            }
            if (hcp.Report != null)
                this.KARAR.CalcValue += TTObjectClasses.Common.GetTextOfRTFString(hcp.Report.ToString());
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

        public HCThreeSpecialistReportBook_A3()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            CAPTION = new CAPTIONGroup(PARTA,"CAPTION");
            PARTB = new PARTBGroup(CAPTION,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "HCTHREESPECIALISTREPORTBOOK_A3";
            Caption = "Üç Uzman Tabip İmzalı Rapor Defteri (A3)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            PaperSize = 8;
            p_PageWidth = 297;
            p_PageHeight = 420;
            SaveViewOnPrint = EvetHayirEnum.ehEvet;
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