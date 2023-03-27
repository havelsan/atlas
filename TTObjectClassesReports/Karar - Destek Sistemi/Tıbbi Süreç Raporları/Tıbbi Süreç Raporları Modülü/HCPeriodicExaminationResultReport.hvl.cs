
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
    /// Periyodic Muayene Sonuç Raporu
    /// </summary>
    public partial class HCPeriodicExaminationResultReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public HCPeriodicExaminationResultReport MyParentReport
            {
                get { return (HCPeriodicExaminationResultReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField1151 { get {return Header().NewField1151;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField YIL { get {return Header().YIL;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine111111 { get {return Header().NewLine111111;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportShape NewLine131 { get {return Header().NewLine131;} }
            public TTReportShape NewLine141 { get {return Header().NewLine141;} }
            public TTReportShape NewLine151 { get {return Header().NewLine151;} }
            public TTReportShape NewLine161 { get {return Header().NewLine161;} }
            public TTReportShape NewLine171 { get {return Header().NewLine171;} }
            public TTReportShape NewLine181 { get {return Header().NewLine181;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public TTReportField CURRENTUSER1 { get {return Footer().CURRENTUSER1;} }
            public TTReportField PrintDate1 { get {return Footer().PrintDate1;} }
            public TTReportField PageNumber1 { get {return Footer().PageNumber1;} }
            public TTReportField NewField161 { get {return Footer().NewField161;} }
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
                public HCPeriodicExaminationResultReport MyParentReport
                {
                    get { return (HCPeriodicExaminationResultReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField1151;
                public TTReportField NewField12;
                public TTReportField YIL;
                public TTReportField NewField13;
                public TTReportShape NewLine12;
                public TTReportShape NewLine111111;
                public TTReportShape NewLine121;
                public TTReportShape NewLine131;
                public TTReportShape NewLine141;
                public TTReportShape NewLine151;
                public TTReportShape NewLine161;
                public TTReportShape NewLine171;
                public TTReportShape NewLine181;
                public TTReportShape NewLine1; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 51;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 14, 232, 37, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FillStyle = FillStyleConstants.vbFSTransparent;
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + "" BAŞTABİPLİĞİ\r\n"" + ""PERİYODİK MUAYENE SONUÇ RAPORU"" ";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 45, 60, 50, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"SINIFI RÜTBESİ";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 45, 24, 50, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"SIRA NO";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 45, 104, 50, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"ADI SOYADI";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 45, 146, 50, false);
                    NewField131.Name = "NewField131";
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"BİRLİĞİ/ KURUMU";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 45, 183, 50, false);
                    NewField141.Name = "NewField141";
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"RAPOR TARİHİ/NO";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 45, 234, 50, false);
                    NewField151.Name = "NewField151";
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151.MultiLine = EvetHayirEnum.ehEvet;
                    NewField151.WordBreak = EvetHayirEnum.ehEvet;
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"RAPOR TANISI";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 45, 293, 50, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1151.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1151.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1151.TextFont.Name = "Arial";
                    NewField1151.TextFont.Bold = true;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"RAPOR KARARI";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 39, 255, 44, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"YILI:";

                    YIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 39, 293, 44, false);
                    YIL.Name = "YIL";
                    YIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    YIL.TextFont.Name = "Arial";
                    YIL.TextFont.Bold = true;
                    YIL.TextFont.CharSet = 162;
                    YIL.Value = @"";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 7, 161, 12, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"HİZMETE ÖZEL";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 24, 44, 24, 51, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 44, 293, 44, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 44, 7, 51, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 60, 44, 60, 51, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 104, 44, 104, 51, false);
                    NewLine141.Name = "NewLine141";
                    NewLine141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 146, 44, 146, 51, false);
                    NewLine151.Name = "NewLine151";
                    NewLine151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 183, 44, 183, 51, false);
                    NewLine161.Name = "NewLine161";
                    NewLine161.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine171 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 234, 44, 234, 51, false);
                    NewLine171.Name = "NewLine171";
                    NewLine171.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine181 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 293, 44, 293, 51, false);
                    NewLine181.Name = "NewLine181";
                    NewLine181.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 51, 293, 51, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField12.CalcValue = NewField12.Value;
                    YIL.CalcValue = @"";
                    NewField13.CalcValue = NewField13.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + " BAŞTABİPLİĞİ\r\n" + "PERİYODİK MUAYENE SONUÇ RAPORU" ;
                    return new TTReportObject[] { NewField11,NewField111,NewField121,NewField131,NewField141,NewField151,NewField1151,NewField12,YIL,NewField13,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    this.YIL.CalcValue = DateTime.Now.Year.ToString();
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public HCPeriodicExaminationResultReport MyParentReport
                {
                    get { return (HCPeriodicExaminationResultReport)ParentReport; }
                }
                
                public TTReportShape NewLine111;
                public TTReportField CURRENTUSER1;
                public TTReportField PrintDate1;
                public TTReportField PageNumber1;
                public TTReportField NewField161; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 16;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 8, 293, 8, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    CURRENTUSER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 10, 157, 15, false);
                    CURRENTUSER1.Name = "CURRENTUSER1";
                    CURRENTUSER1.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER1.TextFont.Name = "Arial";
                    CURRENTUSER1.TextFont.Size = 8;
                    CURRENTUSER1.TextFont.CharSet = 162;
                    CURRENTUSER1.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 10, 39, 15, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFormat = @"Short Date";
                    PrintDate1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate1.TextFont.Name = "Arial";
                    PrintDate1.TextFont.Size = 8;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdatetime@}";

                    PageNumber1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 10, 293, 15, false);
                    PageNumber1.Name = "PageNumber1";
                    PageNumber1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber1.TextFont.Name = "Arial";
                    PageNumber1.TextFont.Size = 8;
                    PageNumber1.TextFont.CharSet = 162;
                    PageNumber1.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 1, 161, 6, false);
                    NewField161.Name = "NewField161";
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"HİZMETE ÖZEL";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    PageNumber1.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    NewField161.CalcValue = NewField161.Value;
                    CURRENTUSER1.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate1,PageNumber1,NewField161,CURRENTUSER1};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTDGroup : TTReportGroup
        {
            public HCPeriodicExaminationResultReport MyParentReport
            {
                get { return (HCPeriodicExaminationResultReport)ParentReport; }
            }

            new public PARTDGroupHeader Header()
            {
                return (PARTDGroupHeader)_header;
            }

            new public PARTDGroupFooter Footer()
            {
                return (PARTDGroupFooter)_footer;
            }

            public TTReportShape NewLine1111111 { get {return Footer().NewLine1111111;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportShape NewLine13 { get {return Footer().NewLine13;} }
            public TTReportShape NewLine14 { get {return Footer().NewLine14;} }
            public TTReportShape NewLine15 { get {return Footer().NewLine15;} }
            public TTReportShape NewLine16 { get {return Footer().NewLine16;} }
            public TTReportShape NewLine17 { get {return Footer().NewLine17;} }
            public PARTDGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTDGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTDGroupHeader(this);
                _footer = new PARTDGroupFooter(this);

            }

            public partial class PARTDGroupHeader : TTReportSection
            {
                public HCPeriodicExaminationResultReport MyParentReport
                {
                    get { return (HCPeriodicExaminationResultReport)ParentReport; }
                }
                 
                public PARTDGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTDGroupFooter : TTReportSection
            {
                public HCPeriodicExaminationResultReport MyParentReport
                {
                    get { return (HCPeriodicExaminationResultReport)ParentReport; }
                }
                
                public TTReportShape NewLine1111111;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16;
                public TTReportShape NewLine17; 
                public PARTDGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 2, 293, 2, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 0, 7, 2, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 24, 0, 24, 2, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 60, 0, 60, 2, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 104, 0, 104, 2, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 146, 0, 146, 2, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 183, 0, 183, 2, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine15.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 234, 0, 234, 2, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine16.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 293, 0, 293, 2, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine17.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public PARTDGroup PARTD;

        public partial class PARTBGroup : TTReportGroup
        {
            public HCPeriodicExaminationResultReport MyParentReport
            {
                get { return (HCPeriodicExaminationResultReport)ParentReport; }
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

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public HCPeriodicExaminationResultReport MyParentReport
                {
                    get { return (HCPeriodicExaminationResultReport)ParentReport; }
                }
                 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public HCPeriodicExaminationResultReport MyParentReport
                {
                    get { return (HCPeriodicExaminationResultReport)ParentReport; }
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
            public HCPeriodicExaminationResultReport MyParentReport
            {
                get { return (HCPeriodicExaminationResultReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportShape NewLine1127 { get {return Body().NewLine1127;} }
            public TTReportShape NewLine1126 { get {return Body().NewLine1126;} }
            public TTReportShape NewLine1124 { get {return Body().NewLine1124;} }
            public TTReportField BIRLIKKURUM { get {return Body().BIRLIKKURUM;} }
            public TTReportShape NewLine1122 { get {return Body().NewLine1122;} }
            public TTReportShape NewLine1121 { get {return Body().NewLine1121;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField SINIFRUTBE { get {return Body().SINIFRUTBE;} }
            public TTReportField ADISOYADI { get {return Body().ADISOYADI;} }
            public TTReportField RAPORTARIHNO { get {return Body().RAPORTARIHNO;} }
            public TTReportField TANI { get {return Body().TANI;} }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public TTReportField TTOBJECTID { get {return Body().TTOBJECTID;} }
            public TTReportField RAPORTARIH { get {return Body().RAPORTARIH;} }
            public TTReportShape NewLine1123 { get {return Body().NewLine1123;} }
            public TTReportShape NewLine11111 { get {return Body().NewLine11111;} }
            public TTReportShape NewLine14211 { get {return Body().NewLine14211;} }
            public TTReportField MADDE { get {return Body().MADDE;} }
            public TTReportField DECISIONTIME { get {return Body().DECISIONTIME;} }
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
                list[0] = new TTReportNqlData<HealthCommittee.GetHCsForPeriodicExaminationResultReport_Class>("GetHCsForPeriodicExaminationResultReport", HealthCommittee.GetHCsForPeriodicExaminationResultReport((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public HCPeriodicExaminationResultReport MyParentReport
                {
                    get { return (HCPeriodicExaminationResultReport)ParentReport; }
                }
                
                public TTReportShape NewLine1127;
                public TTReportShape NewLine1126;
                public TTReportShape NewLine1124;
                public TTReportField BIRLIKKURUM;
                public TTReportShape NewLine1122;
                public TTReportShape NewLine1121;
                public TTReportShape NewLine121;
                public TTReportField SIRANO;
                public TTReportField SINIFRUTBE;
                public TTReportField ADISOYADI;
                public TTReportField RAPORTARIHNO;
                public TTReportField TANI;
                public TTReportField KARAR;
                public TTReportField TTOBJECTID;
                public TTReportField RAPORTARIH;
                public TTReportShape NewLine1123;
                public TTReportShape NewLine11111;
                public TTReportShape NewLine14211;
                public TTReportField MADDE;
                public TTReportField DECISIONTIME; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    NewLine1127 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 293, 0, 293, 7, false);
                    NewLine1127.Name = "NewLine1127";
                    NewLine1127.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1127.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1126 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 234, 0, 234, 7, false);
                    NewLine1126.Name = "NewLine1126";
                    NewLine1126.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1126.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1124 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 146, 0, 146, 7, false);
                    NewLine1124.Name = "NewLine1124";
                    NewLine1124.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1124.ExtendTo = ExtendToEnum.extPageHeight;

                    BIRLIKKURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 1, 146, 6, false);
                    BIRLIKKURUM.Name = "BIRLIKKURUM";
                    BIRLIKKURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIKKURUM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRLIKKURUM.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIKKURUM.NoClip = EvetHayirEnum.ehEvet;
                    BIRLIKKURUM.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIKKURUM.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRLIKKURUM.Value = @"";

                    NewLine1122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 60, 0, 60, 7, false);
                    NewLine1122.Name = "NewLine1122";
                    NewLine1122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1122.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 24, 0, 24, 7, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1121.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 0, 7, 7, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.ExtendTo = ExtendToEnum.extPageHeight;

                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 24, 6, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIRANO.MultiLine = EvetHayirEnum.ehEvet;
                    SIRANO.NoClip = EvetHayirEnum.ehEvet;
                    SIRANO.WordBreak = EvetHayirEnum.ehEvet;
                    SIRANO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIRANO.Value = @"{@groupcounter@}";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 1, 60, 6, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SINIFRUTBE.MultiLine = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.NoClip = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.WordBreak = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.ExpandTabs = EvetHayirEnum.ehEvet;
                    SINIFRUTBE.Value = @"";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 1, 104, 6, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ADISOYADI.MultiLine = EvetHayirEnum.ehEvet;
                    ADISOYADI.NoClip = EvetHayirEnum.ehEvet;
                    ADISOYADI.WordBreak = EvetHayirEnum.ehEvet;
                    ADISOYADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADISOYADI.Value = @"{#ADI#} {#SOYADI#}";

                    RAPORTARIHNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 1, 183, 6, false);
                    RAPORTARIHNO.Name = "RAPORTARIHNO";
                    RAPORTARIHNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPORTARIHNO.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORTARIHNO.NoClip = EvetHayirEnum.ehEvet;
                    RAPORTARIHNO.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORTARIHNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORTARIHNO.Value = @"{%RAPORTARIH%} / {#RAPORNO#}";

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 1, 234, 6, false);
                    TANI.Name = "TANI";
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.NoClip = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.ExpandTabs = EvetHayirEnum.ehEvet;
                    TANI.Value = @"";

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 1, 293, 6, false);
                    KARAR.Name = "KARAR";
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KARAR.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR.NoClip = EvetHayirEnum.ehEvet;
                    KARAR.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR.Value = @"";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 8, 323, 13, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.Value = @"{#TTOBJECTID#}";

                    RAPORTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 326, 1, 351, 6, false);
                    RAPORTARIH.Name = "RAPORTARIH";
                    RAPORTARIH.Visible = EvetHayirEnum.ehHayir;
                    RAPORTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIH.TextFormat = @"Short Date";
                    RAPORTARIH.Value = @"{#RAPORTARIH#}";

                    NewLine1123 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 104, 0, 104, 7, false);
                    NewLine1123.Name = "NewLine1123";
                    NewLine1123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1123.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 0, 293, 0, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 183, 0, 183, 7, false);
                    NewLine14211.Name = "NewLine14211";
                    NewLine14211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14211.ExtendTo = ExtendToEnum.extPageHeight;

                    MADDE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 353, 1, 378, 6, false);
                    MADDE.Name = "MADDE";
                    MADDE.Visible = EvetHayirEnum.ehHayir;
                    MADDE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDE.Value = @"";

                    DECISIONTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 299, 1, 324, 6, false);
                    DECISIONTIME.Name = "DECISIONTIME";
                    DECISIONTIME.Visible = EvetHayirEnum.ehHayir;
                    DECISIONTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DECISIONTIME.TextFormat = @"NUMBERTEXT";
                    DECISIONTIME.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetHCsForPeriodicExaminationResultReport_Class dataset_GetHCsForPeriodicExaminationResultReport = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetHCsForPeriodicExaminationResultReport_Class>(0);
                    BIRLIKKURUM.CalcValue = @"";
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    SINIFRUTBE.CalcValue = @"";
                    ADISOYADI.CalcValue = (dataset_GetHCsForPeriodicExaminationResultReport != null ? Globals.ToStringCore(dataset_GetHCsForPeriodicExaminationResultReport.Adi) : "") + @" " + (dataset_GetHCsForPeriodicExaminationResultReport != null ? Globals.ToStringCore(dataset_GetHCsForPeriodicExaminationResultReport.Soyadi) : "");
                    RAPORTARIH.CalcValue = (dataset_GetHCsForPeriodicExaminationResultReport != null ? Globals.ToStringCore(dataset_GetHCsForPeriodicExaminationResultReport.Raportarih) : "");
                    RAPORTARIHNO.CalcValue = MyParentReport.MAIN.RAPORTARIH.FormattedValue + @" / " + (dataset_GetHCsForPeriodicExaminationResultReport != null ? Globals.ToStringCore(dataset_GetHCsForPeriodicExaminationResultReport.Raporno) : "");
                    TANI.CalcValue = @"";
                    KARAR.CalcValue = @"";
                    TTOBJECTID.CalcValue = (dataset_GetHCsForPeriodicExaminationResultReport != null ? Globals.ToStringCore(dataset_GetHCsForPeriodicExaminationResultReport.Ttobjectid) : "");
                    MADDE.CalcValue = @"";
                    DECISIONTIME.CalcValue = @"";
                    return new TTReportObject[] { BIRLIKKURUM,SIRANO,SINIFRUTBE,ADISOYADI,RAPORTARIH,RAPORTARIHNO,TANI,KARAR,TTOBJECTID,MADDE,DECISIONTIME};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.TTOBJECTID.CalcValue;
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            
            if(hc == null)
                throw new Exception("Reason: HealtCommittee is null");
            
            //            //Sınıf Rutbe
            //            MilitaryClassDefinitions pMilClass = hc.Episode.MilitaryClass;
            //            RankDefinitions pRank = hc.Episode.Rank;
            //            string force = hc.Episode.ForcesCommand != null ? hc.Episode.ForcesCommand.Qref : "";
            //            string age = hc.Episode.Patient.Age != null ? hc.Episode.Patient.Age.ToString() : "";
//
            //            if (hc.Episode.MilitaryClass == null && hc.Episode.Rank == null)
            //                this.SINIFRUTBE.CalcValue = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.Episode.PatientGroup.Value);
            //            else
            //                this.SINIFRUTBE.CalcValue = (pMilClass == null ? "" : pMilClass.Name) + " " + (pRank == null ? "" : pRank.Name);
//
            //            if (hc.Episode.MyRelationship() != null)
            //            {
            //                if (hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "" && hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "kendisi")
            //                    this.SINIFRUTBE.CalcValue += " (" + hc.Episode.MyRelationship().Relationship + ")";
            //            }
            //            this.SINIFRUTBE.CalcValue += "\r\nKuvvet :" + force + "\r\nYaş :" + age;
            
            //Madde-Dilim-Fıkra
            BindingList<HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class> theAnectodes = HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID(sObjectID);
            if (theAnectodes.Count > 0)
            {
                this.MADDE.CalcValue = "[";
                foreach(HealthCommittee_MatterSliceAnectodeGrid.GetMatterSliceAnectodeByParentObjectID_Class theAnectode in theAnectodes)
                {
                    this.MADDE.CalcValue += theAnectode.Madde+"/"+theAnectode.Dilim+"/"+theAnectode.Fikra;
                    this.MADDE.CalcValue += "  ";
                }
                this.MADDE.CalcValue = this.MADDE.CalcValue.Substring(0, this.MADDE.CalcValue.Length - 2);
                this.MADDE.CalcValue += "]";
            }
            
            // Karar
            if(hc.HealthCommitteeDecision != null )
            {
                if(hc.HCDecisionTime != null)
                {
                    this.DECISIONTIME.CalcValue = hc.HCDecisionTime.ToString();
                    this.KARAR.CalcValue += this.DECISIONTIME.CalcValue + "("+ this.DECISIONTIME.FormattedValue +") ";
                }
                
                if(hc.HCDecisionUnitOfTime != null)
                    this.KARAR.CalcValue += TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.HCDecisionUnitOfTime.Value) + " ";
                
                this.KARAR.CalcValue += TTObjectClasses.Common.GetTextOfRTFString(hc.HealthCommitteeDecision.ToString()) + "\n";
            }
            
            this.KARAR.CalcValue += this.MADDE.CalcValue;
            
            // Tanı
            int nCount = 1;
            IList diagnosisCodeList = new List<string>();
            this.TANI.CalcValue = "";
            
            foreach(DiagnosisGrid pGrid in hc.Diagnosis)
            {
                if (pGrid.DiagnosisType == DiagnosisTypeEnum.Seconder)
                {
                    if(!diagnosisCodeList.Contains(pGrid.Diagnose.Code)) // Aynı tanı varsa tekrarlamasın
                    {
                        this.TANI.CalcValue += nCount.ToString() + "- " + pGrid.Diagnose.Code + " " + pGrid.Diagnose.Name;
                        if (pGrid.FreeDiagnosis != null)
                            this.TANI.CalcValue += " (" + pGrid.FreeDiagnosis + ")";
                        this.TANI.CalcValue += "\r\n";
                        diagnosisCodeList.Add(pGrid.Diagnose.Code);
                        nCount++;
                    }
                }
            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTCGroup : TTReportGroup
        {
            public HCPeriodicExaminationResultReport MyParentReport
            {
                get { return (HCPeriodicExaminationResultReport)ParentReport; }
            }

            new public PARTCGroupBody Body()
            {
                return (PARTCGroupBody)_body;
            }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTCGroupBody(this);
            }

            public partial class PARTCGroupBody : TTReportSection
            {
                public HCPeriodicExaminationResultReport MyParentReport
                {
                    get { return (HCPeriodicExaminationResultReport)ParentReport; }
                }
                
                public TTReportField NewField14;
                public TTReportShape NewLine11;
                public TTReportField NewField161;
                public TTReportShape NewLine111; 
                public PARTCGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 58;
                    RepeatCount = 0;
                    
                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 2, 46, 7, false);
                    NewField14.Name = "NewField14";
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"HAZIRLAYAN";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 9, 46, 9, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 2, 293, 7, false);
                    NewField161.Name = "NewField161";
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"ONAY";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 254, 9, 293, 9, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField14.CalcValue = NewField14.Value;
                    NewField161.CalcValue = NewField161.Value;
                    return new TTReportObject[] { NewField14,NewField161};
                }
            }

        }

        public PARTCGroup PARTC;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HCPeriodicExaminationResultReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTD = new PARTDGroup(PARTA,"PARTD");
            PARTB = new PARTBGroup(PARTD,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            PARTC = new PARTCGroup(PARTA,"PARTC");
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
            Name = "HCPERIODICEXAMINATIONRESULTREPORT";
            Caption = "Periyodic Muayene Sonuç Raporu";
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