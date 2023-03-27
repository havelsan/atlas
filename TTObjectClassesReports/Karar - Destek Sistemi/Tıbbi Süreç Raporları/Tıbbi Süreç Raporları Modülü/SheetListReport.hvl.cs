
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
    /// Çarşaf Listesi
    /// </summary>
    public partial class SheetListReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("8A762375-2A52-44E8-9023-D2C11BF6B28B");
        }

        public partial class ArkasayfaGroup : TTReportGroup
        {
            public SheetListReport MyParentReport
            {
                get { return (SheetListReport)ParentReport; }
            }

            new public ArkasayfaGroupHeader Header()
            {
                return (ArkasayfaGroupHeader)_header;
            }

            new public ArkasayfaGroupFooter Footer()
            {
                return (ArkasayfaGroupFooter)_footer;
            }

            public TTReportShape NewLine { get {return Header().NewLine;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportShape NewLine4 { get {return Header().NewLine4;} }
            public TTReportShape NewLine5 { get {return Header().NewLine5;} }
            public TTReportShape NewLine6 { get {return Header().NewLine6;} }
            public TTReportShape NewLine7 { get {return Header().NewLine7;} }
            public TTReportShape NewLine8 { get {return Header().NewLine8;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField50 { get {return Header().NewField50;} }
            public TTReportShape NewLine17 { get {return Header().NewLine17;} }
            public TTReportShape NewLine18 { get {return Header().NewLine18;} }
            public TTReportShape NewLine19 { get {return Header().NewLine19;} }
            public TTReportShape NewLine20 { get {return Header().NewLine20;} }
            public TTReportShape NewLine21 { get {return Header().NewLine21;} }
            public TTReportShape NewLine22 { get {return Header().NewLine22;} }
            public TTReportShape NewLine34 { get {return Header().NewLine34;} }
            public TTReportField BIRIM11 { get {return Header().BIRIM11;} }
            public TTReportField BIRIM12 { get {return Header().BIRIM12;} }
            public TTReportField BIRIM13 { get {return Header().BIRIM13;} }
            public TTReportField BIRIM14 { get {return Header().BIRIM14;} }
            public TTReportField BIRIM15 { get {return Header().BIRIM15;} }
            public TTReportField BIRIM16 { get {return Header().BIRIM16;} }
            public TTReportShape NewLine35 { get {return Header().NewLine35;} }
            public TTReportShape NewLine44 { get {return Header().NewLine44;} }
            public TTReportShape NewLine45 { get {return Header().NewLine45;} }
            public TTReportField BIRIM17 { get {return Header().BIRIM17;} }
            public TTReportField BIRIM71 { get {return Header().BIRIM71;} }
            public TTReportField BIRIM72 { get {return Header().BIRIM72;} }
            public TTReportField BIRIM73 { get {return Header().BIRIM73;} }
            public TTReportField BIRIM74 { get {return Header().BIRIM74;} }
            public ArkasayfaGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ArkasayfaGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ArkasayfaGroupHeader(this);
                _footer = new ArkasayfaGroupFooter(this);

            }

            public partial class ArkasayfaGroupHeader : TTReportSection
            {
                public SheetListReport MyParentReport
                {
                    get { return (SheetListReport)ParentReport; }
                }
                
                public TTReportShape NewLine;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportShape NewLine5;
                public TTReportShape NewLine6;
                public TTReportShape NewLine7;
                public TTReportShape NewLine8;
                public TTReportShape NewLine11;
                public TTReportField NewField50;
                public TTReportShape NewLine17;
                public TTReportShape NewLine18;
                public TTReportShape NewLine19;
                public TTReportShape NewLine20;
                public TTReportShape NewLine21;
                public TTReportShape NewLine22;
                public TTReportShape NewLine34;
                public TTReportField BIRIM11;
                public TTReportField BIRIM12;
                public TTReportField BIRIM13;
                public TTReportField BIRIM14;
                public TTReportField BIRIM15;
                public TTReportField BIRIM16;
                public TTReportShape NewLine35;
                public TTReportShape NewLine44;
                public TTReportShape NewLine45;
                public TTReportField BIRIM17;
                public TTReportField BIRIM71;
                public TTReportField BIRIM72;
                public TTReportField BIRIM73;
                public TTReportField BIRIM74; 
                public ArkasayfaGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 154;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 1, 194, 1, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine.DrawWidth = 3;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 194, 12, 194, 125, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine2.DrawWidth = 3;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 194, 119, 194, 262, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine3.DrawWidth = 3;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 262, 194, 262, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine4.DrawWidth = 3;

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 19, 1, 135, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine5.DrawWidth = 3;

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 103, 1, 262, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine6.DrawWidth = 3;

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 52, 194, 52, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine7.DrawWidth = 3;

                    NewLine8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 35, 194, 35, false);
                    NewLine8.Name = "NewLine8";
                    NewLine8.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine8.DrawWidth = 3;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 107, 194, 107, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 3;

                    NewField50 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 108, 146, 112, false);
                    NewField50.Name = "NewField50";
                    NewField50.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField50.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField50.TextFont.Size = 8;
                    NewField50.TextFont.Bold = true;
                    NewField50.Value = @"A.B.D.: Anabilim Dalı";

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 40, 1, 40, 107, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine17.DrawWidth = 3;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 1, 1, 22, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine18.DrawWidth = 3;

                    NewLine19 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 194, 1, 194, 12, false);
                    NewLine19.Name = "NewLine19";
                    NewLine19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine19.DrawWidth = 3;

                    NewLine20 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 69, 194, 69, false);
                    NewLine20.Name = "NewLine20";
                    NewLine20.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine20.DrawWidth = 3;

                    NewLine21 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 86, 194, 86, false);
                    NewLine21.Name = "NewLine21";
                    NewLine21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine21.DrawWidth = 3;

                    NewLine22 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 18, 194, 18, false);
                    NewLine22.Name = "NewLine22";
                    NewLine22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine22.DrawWidth = 3;

                    NewLine34 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 1, 12, 107, false);
                    NewLine34.Name = "NewLine34";
                    NewLine34.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine34.DrawWidth = 3;

                    BIRIM11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 3, 40, 16, false);
                    BIRIM11.Name = "BIRIM11";
                    BIRIM11.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM11.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM11.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM11.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRIM11.TextFont.Size = 8;
                    BIRIM11.TextFont.Bold = true;
                    BIRIM11.Value = @"ALLERJİK
HASTALIKLAR A.B.D.";

                    BIRIM12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 19, 40, 34, false);
                    BIRIM12.Name = "BIRIM12";
                    BIRIM12.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM12.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM12.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM12.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRIM12.TextFont.Size = 8;
                    BIRIM12.TextFont.Bold = true;
                    BIRIM12.Value = @"ENDOKRİNOLOJİ VE METABOLİZMA
HASTALIKLARI A.B.D.";

                    BIRIM13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 36, 40, 49, false);
                    BIRIM13.Name = "BIRIM13";
                    BIRIM13.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM13.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM13.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM13.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRIM13.TextFont.Size = 8;
                    BIRIM13.TextFont.Bold = true;
                    BIRIM13.Value = @"HEMATOLOJİ
A.B.D.";

                    BIRIM14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 54, 40, 67, false);
                    BIRIM14.Name = "BIRIM14";
                    BIRIM14.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM14.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM14.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM14.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRIM14.TextFont.Size = 8;
                    BIRIM14.TextFont.Bold = true;
                    BIRIM14.Value = @"NEFROLOJİ
A.B.D.";

                    BIRIM15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 71, 40, 84, false);
                    BIRIM15.Name = "BIRIM15";
                    BIRIM15.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM15.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM15.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM15.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRIM15.TextFont.Size = 8;
                    BIRIM15.TextFont.Bold = true;
                    BIRIM15.Value = @"RADYOLOJİ
A.B.D.";

                    BIRIM16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 90, 40, 103, false);
                    BIRIM16.Name = "BIRIM16";
                    BIRIM16.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM16.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM16.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM16.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRIM16.TextFont.Size = 8;
                    BIRIM16.TextFont.Bold = true;
                    BIRIM16.Value = @"LÜZUMLU VE DİĞER LABORATUVARLAR";

                    NewLine35 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 98, 1, 98, 107, false);
                    NewLine35.Name = "NewLine35";
                    NewLine35.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine35.DrawWidth = 3;

                    NewLine44 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 109, 1, 109, 107, false);
                    NewLine44.Name = "NewLine44";
                    NewLine44.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine44.DrawWidth = 3;

                    NewLine45 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 137, 1, 137, 107, false);
                    NewLine45.Name = "NewLine45";
                    NewLine45.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine45.DrawWidth = 3;

                    BIRIM17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 3, 137, 16, false);
                    BIRIM17.Name = "BIRIM17";
                    BIRIM17.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM17.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM17.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM17.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRIM17.TextFont.Size = 8;
                    BIRIM17.TextFont.Bold = true;
                    BIRIM17.Value = @"TIBBİ ONKOLOJİ A.B.D.";

                    BIRIM71 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 19, 136, 32, false);
                    BIRIM71.Name = "BIRIM71";
                    BIRIM71.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM71.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM71.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM71.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM71.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM71.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRIM71.TextFont.Size = 8;
                    BIRIM71.TextFont.Bold = true;
                    BIRIM71.Value = @"KARDİYOLOJİ A.B.D.";

                    BIRIM72 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 37, 137, 50, false);
                    BIRIM72.Name = "BIRIM72";
                    BIRIM72.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM72.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM72.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM72.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM72.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM72.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRIM72.TextFont.Size = 8;
                    BIRIM72.TextFont.Bold = true;
                    BIRIM72.Value = @"GASTRO ENTEROLOJİ A.B.D.";

                    BIRIM73 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 54, 137, 67, false);
                    BIRIM73.Name = "BIRIM73";
                    BIRIM73.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM73.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM73.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM73.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM73.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM73.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRIM73.TextFont.Size = 8;
                    BIRIM73.TextFont.Bold = true;
                    BIRIM73.Value = @"LÜZUMLU DİĞER KLİNİKLER";

                    BIRIM74 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 72, 137, 85, false);
                    BIRIM74.Name = "BIRIM74";
                    BIRIM74.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM74.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM74.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM74.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM74.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM74.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRIM74.TextFont.Size = 8;
                    BIRIM74.TextFont.Bold = true;
                    BIRIM74.Value = @"KLİNİK BİYOKİMYA A.B.D.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField50.CalcValue = NewField50.Value;
                    BIRIM11.CalcValue = BIRIM11.Value;
                    BIRIM12.CalcValue = BIRIM12.Value;
                    BIRIM13.CalcValue = BIRIM13.Value;
                    BIRIM14.CalcValue = BIRIM14.Value;
                    BIRIM15.CalcValue = BIRIM15.Value;
                    BIRIM16.CalcValue = BIRIM16.Value;
                    BIRIM17.CalcValue = BIRIM17.Value;
                    BIRIM71.CalcValue = BIRIM71.Value;
                    BIRIM72.CalcValue = BIRIM72.Value;
                    BIRIM73.CalcValue = BIRIM73.Value;
                    BIRIM74.CalcValue = BIRIM74.Value;
                    return new TTReportObject[] { NewField50,BIRIM11,BIRIM12,BIRIM13,BIRIM14,BIRIM15,BIRIM16,BIRIM17,BIRIM71,BIRIM72,BIRIM73,BIRIM74};
                }
            }
            public partial class ArkasayfaGroupFooter : TTReportSection
            {
                public SheetListReport MyParentReport
                {
                    get { return (SheetListReport)ParentReport; }
                }
                 
                public ArkasayfaGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public ArkasayfaGroup Arkasayfa;

        public partial class MAINGroup : TTReportGroup
        {
            public SheetListReport MyParentReport
            {
                get { return (SheetListReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField HEADER { get {return Body().HEADER;} }
            public TTReportField MUAYENEYIYAPANKURUL { get {return Body().MUAYENEYIYAPANKURUL;} }
            public TTReportField RAPORNO { get {return Body().RAPORNO;} }
            public TTReportField RAPORTARIHI { get {return Body().RAPORTARIHI;} }
            public TTReportField KARANTINANO { get {return Body().KARANTINANO;} }
            public TTReportField HCIKISTARIHI { get {return Body().HCIKISTARIHI;} }
            public TTReportField HGIRISTARIHI { get {return Body().HGIRISTARIHI;} }
            public TTReportField ISLEMSEBEBI { get {return Body().ISLEMSEBEBI;} }
            public TTReportField MAKAM { get {return Body().MAKAM;} }
            public TTReportField BIRLIKLABEL { get {return Body().BIRLIKLABEL;} }
            public TTReportField NewField25 { get {return Body().NewField25;} }
            public TTReportField NewField26 { get {return Body().NewField26;} }
            public TTReportField NewField27 { get {return Body().NewField27;} }
            public TTReportField NewField28 { get {return Body().NewField28;} }
            public TTReportField NewField29 { get {return Body().NewField29;} }
            public TTReportField NewField30 { get {return Body().NewField30;} }
            public TTReportShape NewLine { get {return Body().NewLine;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine3 { get {return Body().NewLine3;} }
            public TTReportShape NewLine4 { get {return Body().NewLine4;} }
            public TTReportShape NewLine5 { get {return Body().NewLine5;} }
            public TTReportShape NewLine7 { get {return Body().NewLine7;} }
            public TTReportShape NewLine8 { get {return Body().NewLine8;} }
            public TTReportField NewField55 { get {return Body().NewField55;} }
            public TTReportShape NewLine9 { get {return Body().NewLine9;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine17 { get {return Body().NewLine17;} }
            public TTReportShape NewLine18 { get {return Body().NewLine18;} }
            public TTReportField BIRIM2 { get {return Body().BIRIM2;} }
            public TTReportField BIRIM3 { get {return Body().BIRIM3;} }
            public TTReportField BIRIM4 { get {return Body().BIRIM4;} }
            public TTReportField BIRIM5 { get {return Body().BIRIM5;} }
            public TTReportField BIRIM6 { get {return Body().BIRIM6;} }
            public TTReportField BIRIM7 { get {return Body().BIRIM7;} }
            public TTReportField BIRIM8 { get {return Body().BIRIM8;} }
            public TTReportField BIRIM9 { get {return Body().BIRIM9;} }
            public TTReportField BIRIM10 { get {return Body().BIRIM10;} }
            public TTReportShape NewLine19 { get {return Body().NewLine19;} }
            public TTReportShape NewLine20 { get {return Body().NewLine20;} }
            public TTReportShape NewLine21 { get {return Body().NewLine21;} }
            public TTReportShape NewLine22 { get {return Body().NewLine22;} }
            public TTReportShape NewLine23 { get {return Body().NewLine23;} }
            public TTReportShape NewLine24 { get {return Body().NewLine24;} }
            public TTReportShape NewLine25 { get {return Body().NewLine25;} }
            public TTReportShape NewLine26 { get {return Body().NewLine26;} }
            public TTReportShape NewLine27 { get {return Body().NewLine27;} }
            public TTReportShape NewLine28 { get {return Body().NewLine28;} }
            public TTReportShape NewLine29 { get {return Body().NewLine29;} }
            public TTReportShape NewLine30 { get {return Body().NewLine30;} }
            public TTReportField ACIKLAMA1 { get {return Body().ACIKLAMA1;} }
            public TTReportField ACIKLAMA3 { get {return Body().ACIKLAMA3;} }
            public TTReportShape NewLine31 { get {return Body().NewLine31;} }
            public TTReportField PID { get {return Body().PID;} }
            public TTReportField HNO { get {return Body().HNO;} }
            public TTReportField AID { get {return Body().AID;} }
            public TTReportField SITENAME { get {return Body().SITENAME;} }
            public TTReportField SITECITY { get {return Body().SITECITY;} }
            public TTReportField NewField { get {return Body().NewField;} }
            public TTReportShape NewLine41 { get {return Body().NewLine41;} }
            public TTReportField NewField52 { get {return Body().NewField52;} }
            public TTReportField NewField53 { get {return Body().NewField53;} }
            public TTReportField NewField54 { get {return Body().NewField54;} }
            public TTReportField NewField56 { get {return Body().NewField56;} }
            public TTReportField NewField57 { get {return Body().NewField57;} }
            public TTReportField NewField58 { get {return Body().NewField58;} }
            public TTReportShape NewLine10 { get {return Body().NewLine10;} }
            public TTReportField NewField85 { get {return Body().NewField85;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField İslem2 { get {return Body().İslem2;} }
            public TTReportField İslem3 { get {return Body().İslem3;} }
            public TTReportShape NewLine6 { get {return Body().NewLine6;} }
            public TTReportShape NewLine15 { get {return Body().NewLine15;} }
            public TTReportField NewField59 { get {return Body().NewField59;} }
            public TTReportShape NewLine16 { get {return Body().NewLine16;} }
            public TTReportShape NewLine32 { get {return Body().NewLine32;} }
            public TTReportField BOY { get {return Body().BOY;} }
            public TTReportField KILO { get {return Body().KILO;} }
            public TTReportShape NewLine33 { get {return Body().NewLine33;} }
            public TTReportShape NewLine34 { get {return Body().NewLine34;} }
            public TTReportField BIRIM11 { get {return Body().BIRIM11;} }
            public TTReportShape NewLine43 { get {return Body().NewLine43;} }
            public TTReportShape NewLine44 { get {return Body().NewLine44;} }
            public TTReportField BIRIM12 { get {return Body().BIRIM12;} }
            public TTReportShape NewLine35 { get {return Body().NewLine35;} }
            public TTReportField BIRIM13 { get {return Body().BIRIM13;} }
            public TTReportField BIRIM14 { get {return Body().BIRIM14;} }
            public TTReportField BIRIM15 { get {return Body().BIRIM15;} }
            public TTReportField BIRIM16 { get {return Body().BIRIM16;} }
            public TTReportField BIRIM17 { get {return Body().BIRIM17;} }
            public TTReportField BIRIM18 { get {return Body().BIRIM18;} }
            public TTReportField BIRIM19 { get {return Body().BIRIM19;} }
            public TTReportField BIRIM20 { get {return Body().BIRIM20;} }
            public TTReportField BIRLIK { get {return Body().BIRLIK;} }
            public TTReportField ADSOYAD { get {return Body().ADSOYAD;} }
            public TTReportField BABAADI { get {return Body().BABAADI;} }
            public TTReportField SINIFRUTBE { get {return Body().SINIFRUTBE;} }
            public TTReportField SICILNO { get {return Body().SICILNO;} }
            public TTReportField DTARIHIYERI { get {return Body().DTARIHIYERI;} }
            public TTReportField ADRES { get {return Body().ADRES;} }
            public TTReportField DTARIHI { get {return Body().DTARIHI;} }
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
                list[0] = new TTReportNqlData<HealthCommitteeOfProfessors.GetHealthCommitteeOfProfessors_Class>("GetHealthCommitteeOfProfessors", HealthCommitteeOfProfessors.GetHealthCommitteeOfProfessors((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public SheetListReport MyParentReport
                {
                    get { return (SheetListReport)ParentReport; }
                }
                
                public TTReportField HEADER;
                public TTReportField MUAYENEYIYAPANKURUL;
                public TTReportField RAPORNO;
                public TTReportField RAPORTARIHI;
                public TTReportField KARANTINANO;
                public TTReportField HCIKISTARIHI;
                public TTReportField HGIRISTARIHI;
                public TTReportField ISLEMSEBEBI;
                public TTReportField MAKAM;
                public TTReportField BIRLIKLABEL;
                public TTReportField NewField25;
                public TTReportField NewField26;
                public TTReportField NewField27;
                public TTReportField NewField28;
                public TTReportField NewField29;
                public TTReportField NewField30;
                public TTReportShape NewLine;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportShape NewLine5;
                public TTReportShape NewLine7;
                public TTReportShape NewLine8;
                public TTReportField NewField55;
                public TTReportShape NewLine9;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine17;
                public TTReportShape NewLine18;
                public TTReportField BIRIM2;
                public TTReportField BIRIM3;
                public TTReportField BIRIM4;
                public TTReportField BIRIM5;
                public TTReportField BIRIM6;
                public TTReportField BIRIM7;
                public TTReportField BIRIM8;
                public TTReportField BIRIM9;
                public TTReportField BIRIM10;
                public TTReportShape NewLine19;
                public TTReportShape NewLine20;
                public TTReportShape NewLine21;
                public TTReportShape NewLine22;
                public TTReportShape NewLine23;
                public TTReportShape NewLine24;
                public TTReportShape NewLine25;
                public TTReportShape NewLine26;
                public TTReportShape NewLine27;
                public TTReportShape NewLine28;
                public TTReportShape NewLine29;
                public TTReportShape NewLine30;
                public TTReportField ACIKLAMA1;
                public TTReportField ACIKLAMA3;
                public TTReportShape NewLine31;
                public TTReportField PID;
                public TTReportField HNO;
                public TTReportField AID;
                public TTReportField SITENAME;
                public TTReportField SITECITY;
                public TTReportField NewField;
                public TTReportShape NewLine41;
                public TTReportField NewField52;
                public TTReportField NewField53;
                public TTReportField NewField54;
                public TTReportField NewField56;
                public TTReportField NewField57;
                public TTReportField NewField58;
                public TTReportShape NewLine10;
                public TTReportField NewField85;
                public TTReportShape NewLine1;
                public TTReportField İslem2;
                public TTReportField İslem3;
                public TTReportShape NewLine6;
                public TTReportShape NewLine15;
                public TTReportField NewField59;
                public TTReportShape NewLine16;
                public TTReportShape NewLine32;
                public TTReportField BOY;
                public TTReportField KILO;
                public TTReportShape NewLine33;
                public TTReportShape NewLine34;
                public TTReportField BIRIM11;
                public TTReportShape NewLine43;
                public TTReportShape NewLine44;
                public TTReportField BIRIM12;
                public TTReportShape NewLine35;
                public TTReportField BIRIM13;
                public TTReportField BIRIM14;
                public TTReportField BIRIM15;
                public TTReportField BIRIM16;
                public TTReportField BIRIM17;
                public TTReportField BIRIM18;
                public TTReportField BIRIM19;
                public TTReportField BIRIM20;
                public TTReportField BIRLIK;
                public TTReportField ADSOYAD;
                public TTReportField BABAADI;
                public TTReportField SINIFRUTBE;
                public TTReportField SICILNO;
                public TTReportField DTARIHIYERI;
                public TTReportField ADRES;
                public TTReportField DTARIHI; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 265;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 2, 197, 14, false);
                    HEADER.Name = "HEADER";
                    HEADER.FillStyle = FillStyleConstants.vbFSTransparent;
                    HEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.NoClip = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Size = 11;
                    HEADER.TextFont.Bold = true;
                    HEADER.Value = @"{%MAIN.SITENAME%} 
PROFESÖRLER SAĞLIK KURULU MUAYENE FİŞİ";

                    MUAYENEYIYAPANKURUL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 16, 87, 27, false);
                    MUAYENEYIYAPANKURUL.Name = "MUAYENEYIYAPANKURUL";
                    MUAYENEYIYAPANKURUL.FillStyle = FillStyleConstants.vbFSTransparent;
                    MUAYENEYIYAPANKURUL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENEYIYAPANKURUL.MultiLine = EvetHayirEnum.ehEvet;
                    MUAYENEYIYAPANKURUL.NoClip = EvetHayirEnum.ehEvet;
                    MUAYENEYIYAPANKURUL.WordBreak = EvetHayirEnum.ehEvet;
                    MUAYENEYIYAPANKURUL.TextFont.Size = 8;
                    MUAYENEYIYAPANKURUL.Value = @"";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 28, 85, 32, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.NoClip = EvetHayirEnum.ehEvet;
                    RAPORNO.TextFont.Size = 8;
                    RAPORNO.Value = @"{#RAPORNO#}";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 38, 86, 42, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.FillStyle = FillStyleConstants.vbFSTransparent;
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"Short Date";
                    RAPORTARIHI.NoClip = EvetHayirEnum.ehEvet;
                    RAPORTARIHI.TextFont.Size = 8;
                    RAPORTARIHI.Value = @"{#RAPORTARIHI#}";

                    KARANTINANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 47, 86, 53, false);
                    KARANTINANO.Name = "KARANTINANO";
                    KARANTINANO.FillStyle = FillStyleConstants.vbFSTransparent;
                    KARANTINANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARANTINANO.MultiLine = EvetHayirEnum.ehEvet;
                    KARANTINANO.NoClip = EvetHayirEnum.ehEvet;
                    KARANTINANO.WordBreak = EvetHayirEnum.ehEvet;
                    KARANTINANO.TextFont.Size = 8;
                    KARANTINANO.Value = @"{#KPROKOLNO#}";

                    HCIKISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 64, 86, 69, false);
                    HCIKISTARIHI.Name = "HCIKISTARIHI";
                    HCIKISTARIHI.FillStyle = FillStyleConstants.vbFSTransparent;
                    HCIKISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HCIKISTARIHI.TextFormat = @"Short Date";
                    HCIKISTARIHI.MultiLine = EvetHayirEnum.ehEvet;
                    HCIKISTARIHI.NoClip = EvetHayirEnum.ehEvet;
                    HCIKISTARIHI.WordBreak = EvetHayirEnum.ehEvet;
                    HCIKISTARIHI.TextFont.Size = 8;
                    HCIKISTARIHI.Value = @"{#TABURCUTARIHI#}";

                    HGIRISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 56, 86, 60, false);
                    HGIRISTARIHI.Name = "HGIRISTARIHI";
                    HGIRISTARIHI.FillStyle = FillStyleConstants.vbFSTransparent;
                    HGIRISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HGIRISTARIHI.TextFormat = @"Short Date";
                    HGIRISTARIHI.NoClip = EvetHayirEnum.ehEvet;
                    HGIRISTARIHI.TextFont.Size = 8;
                    HGIRISTARIHI.Value = @"{#HGTARIHI#}";

                    ISLEMSEBEBI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 88, 192, 97, false);
                    ISLEMSEBEBI.Name = "ISLEMSEBEBI";
                    ISLEMSEBEBI.FillStyle = FillStyleConstants.vbFSTransparent;
                    ISLEMSEBEBI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMSEBEBI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ISLEMSEBEBI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISLEMSEBEBI.TextFont.Name = "Arial Narrow";
                    ISLEMSEBEBI.TextFont.Size = 8;
                    ISLEMSEBEBI.Value = @"";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 73, 86, 93, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.FillStyle = FillStyleConstants.vbFSTransparent;
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MAKAM.MultiLine = EvetHayirEnum.ehEvet;
                    MAKAM.WordBreak = EvetHayirEnum.ehEvet;
                    MAKAM.ExpandTabs = EvetHayirEnum.ehEvet;
                    MAKAM.TextFont.Size = 8;
                    MAKAM.Value = @"{#MAKAM#}";

                    BIRLIKLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 16, 43, 27, false);
                    BIRLIKLABEL.Name = "BIRLIKLABEL";
                    BIRLIKLABEL.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRLIKLABEL.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIKLABEL.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIKLABEL.TextFont.Size = 8;
                    BIRLIKLABEL.TextFont.Bold = true;
                    BIRLIKLABEL.Value = @"MUAYENEYİ YAPAN SAĞLIK KURULU";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 28, 40, 33, false);
                    NewField25.Name = "NewField25";
                    NewField25.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField25.TextFont.Size = 8;
                    NewField25.TextFont.Bold = true;
                    NewField25.Value = @"RAPOR NUMARASI";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 39, 40, 44, false);
                    NewField26.Name = "NewField26";
                    NewField26.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField26.TextFont.Size = 8;
                    NewField26.TextFont.Bold = true;
                    NewField26.Value = @"RAPOR TARIHI";

                    NewField27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 48, 40, 53, false);
                    NewField27.Name = "NewField27";
                    NewField27.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField27.TextFont.Size = 8;
                    NewField27.TextFont.Bold = true;
                    NewField27.Value = @"KARANTİNA NO";

                    NewField28 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 55, 40, 61, false);
                    NewField28.Name = "NewField28";
                    NewField28.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField28.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField28.TextFont.Size = 8;
                    NewField28.TextFont.Bold = true;
                    NewField28.Value = @"XXXXXXYE GİRİŞ";

                    NewField29 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 64, 40, 68, false);
                    NewField29.Name = "NewField29";
                    NewField29.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField29.MultiLine = EvetHayirEnum.ehEvet;
                    NewField29.TextFont.Size = 8;
                    NewField29.TextFont.Bold = true;
                    NewField29.Value = @"XXXXXXDEN ÇIKIŞ";

                    NewField30 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 70, 39, 81, false);
                    NewField30.Name = "NewField30";
                    NewField30.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField30.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField30.MultiLine = EvetHayirEnum.ehEvet;
                    NewField30.WordBreak = EvetHayirEnum.ehEvet;
                    NewField30.TextFont.Size = 8;
                    NewField30.TextFont.Bold = true;
                    NewField30.Value = @"SEVK EDEN SERVİS VEYA MAKAM";

                    NewLine = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 15, 194, 15, false);
                    NewLine.Name = "NewLine";
                    NewLine.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine.DrawWidth = 3;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 36, 168, 36, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine2.DrawWidth = 3;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 45, 168, 45, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine3.DrawWidth = 3;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 53, 168, 53, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine4.DrawWidth = 3;

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 61, 168, 61, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine5.DrawWidth = 3;

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 40, 15, 40, 98, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine7.DrawWidth = 3;

                    NewLine8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 168, 15, 168, 98, false);
                    NewLine8.Name = "NewLine8";
                    NewLine8.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine8.DrawWidth = 3;

                    NewField55 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 80, 180, 89, false);
                    NewField55.Name = "NewField55";
                    NewField55.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField55.MultiLine = EvetHayirEnum.ehEvet;
                    NewField55.WordBreak = EvetHayirEnum.ehEvet;
                    NewField55.TextFont.Name = "Arial Narrow";
                    NewField55.TextFont.Size = 8;
                    NewField55.TextFont.Bold = true;
                    NewField55.Value = @"İŞLEM NO";

                    NewLine9 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 194, 15, 194, 98, false);
                    NewLine9.Name = "NewLine9";
                    NewLine9.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine9.DrawWidth = 3;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 69, 168, 69, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 3;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, -1, 15, -1, 98, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 98, 194, 98, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.DrawWidth = 3;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 87, 15, 87, 98, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.DrawWidth = 3;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, -1, 97, -1, 287, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 194, 97, 194, 264, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine18.DrawWidth = 3;

                    BIRIM2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 113, 13, 129, false);
                    BIRIM2.Name = "BIRIM2";
                    BIRIM2.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM2.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM2.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM2.TextFont.Size = 8;
                    BIRIM2.TextFont.Bold = true;
                    BIRIM2.Value = @"KAYIT NO.";

                    BIRIM3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 130, 40, 145, false);
                    BIRIM3.Name = "BIRIM3";
                    BIRIM3.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM3.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM3.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM3.TextFont.Size = 8;
                    BIRIM3.TextFont.Bold = true;
                    BIRIM3.Value = @"ÇOCUK
HASTALIKLARI A.B.D.";

                    BIRIM4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 146, 40, 161, false);
                    BIRIM4.Name = "BIRIM4";
                    BIRIM4.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM4.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM4.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM4.TextFont.Size = 8;
                    BIRIM4.TextFont.Bold = true;
                    BIRIM4.Value = @"DERİ VE ZÜHREVİ HASTALIKLAR A.B.D.";

                    BIRIM5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 162, 40, 177, false);
                    BIRIM5.Name = "BIRIM5";
                    BIRIM5.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM5.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM5.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM5.TextFont.Size = 8;
                    BIRIM5.TextFont.Bold = true;
                    BIRIM5.Value = @"ENFEKSİYON HASTALIKLARI A.B.D.";

                    BIRIM6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 179, 40, 194, false);
                    BIRIM6.Name = "BIRIM6";
                    BIRIM6.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM6.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM6.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM6.TextFont.Size = 8;
                    BIRIM6.TextFont.Bold = true;
                    BIRIM6.Value = @"FİZİKSEL TIP VE REHABİLİTASYON A.B.D.";

                    BIRIM7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 196, 40, 211, false);
                    BIRIM7.Name = "BIRIM7";
                    BIRIM7.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM7.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM7.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM7.TextFont.Size = 8;
                    BIRIM7.TextFont.Bold = true;
                    BIRIM7.Value = @"GÖĞÜS HASTALIKLARI A.B.D.";

                    BIRIM8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 214, 39, 229, false);
                    BIRIM8.Name = "BIRIM8";
                    BIRIM8.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM8.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM8.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM8.TextFont.Size = 8;
                    BIRIM8.TextFont.Bold = true;
                    BIRIM8.Value = @"NÖROLOJİ A.B.D.";

                    BIRIM9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 231, 39, 246, false);
                    BIRIM9.Name = "BIRIM9";
                    BIRIM9.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM9.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM9.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM9.TextFont.Size = 8;
                    BIRIM9.TextFont.Bold = true;
                    BIRIM9.Value = @"RADYASYON ONKOLOJİSİ A.B.D.";

                    BIRIM10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 248, 38, 263, false);
                    BIRIM10.Name = "BIRIM10";
                    BIRIM10.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM10.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM10.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM10.TextFont.Size = 8;
                    BIRIM10.TextFont.Bold = true;
                    BIRIM10.Value = @"RUH SAĞLIĞI VE
HASTALIKLARI A.B.D.";

                    NewLine19 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 113, 194, 113, false);
                    NewLine19.Name = "NewLine19";
                    NewLine19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine19.DrawWidth = 3;

                    NewLine20 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 146, 194, 146, false);
                    NewLine20.Name = "NewLine20";
                    NewLine20.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine20.DrawWidth = 3;

                    NewLine21 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 129, 194, 129, false);
                    NewLine21.Name = "NewLine21";
                    NewLine21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine21.DrawWidth = 3;

                    NewLine22 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 178, 194, 178, false);
                    NewLine22.Name = "NewLine22";
                    NewLine22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine22.DrawWidth = 3;

                    NewLine23 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 162, 194, 162, false);
                    NewLine23.Name = "NewLine23";
                    NewLine23.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine23.DrawWidth = 3;

                    NewLine24 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 195, 194, 195, false);
                    NewLine24.Name = "NewLine24";
                    NewLine24.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine24.DrawWidth = 3;

                    NewLine25 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 213, 194, 213, false);
                    NewLine25.Name = "NewLine25";
                    NewLine25.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine25.DrawWidth = 3;

                    NewLine26 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 230, 194, 230, false);
                    NewLine26.Name = "NewLine26";
                    NewLine26.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine26.DrawWidth = 3;

                    NewLine27 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 247, 194, 247, false);
                    NewLine27.Name = "NewLine27";
                    NewLine27.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine27.DrawWidth = 3;

                    NewLine28 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 264, 194, 264, false);
                    NewLine28.Name = "NewLine28";
                    NewLine28.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine28.DrawWidth = 3;

                    NewLine29 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 15, 2, 98, false);
                    NewLine29.Name = "NewLine29";
                    NewLine29.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine29.DrawWidth = 3;

                    NewLine30 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 93, 2, 264, false);
                    NewLine30.Name = "NewLine30";
                    NewLine30.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine30.DrawWidth = 3;

                    ACIKLAMA1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 103, 170, 110, false);
                    ACIKLAMA1.Name = "ACIKLAMA1";
                    ACIKLAMA1.FillStyle = FillStyleConstants.vbFSTransparent;
                    ACIKLAMA1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACIKLAMA1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA1.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA1.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA1.TextFont.Size = 12;
                    ACIKLAMA1.TextFont.Bold = true;
                    ACIKLAMA1.Value = @"KLİNİK VE LABORATUVARLAR";

                    ACIKLAMA3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 131, 194, 146, false);
                    ACIKLAMA3.Name = "ACIKLAMA3";
                    ACIKLAMA3.FillStyle = FillStyleConstants.vbFSTransparent;
                    ACIKLAMA3.VertAlign = VerticalAlignmentEnum.vaBottom;
                    ACIKLAMA3.TextFont.Size = 8;
                    ACIKLAMA3.TextFont.Bold = true;
                    ACIKLAMA3.Value = @"Not: 16 yaşından büyükler hariç";

                    NewLine31 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 27, 168, 27, false);
                    NewLine31.Name = "NewLine31";
                    NewLine31.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine31.DrawWidth = 3;

                    PID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 16, 193, 20, false);
                    PID.Name = "PID";
                    PID.FillStyle = FillStyleConstants.vbFSTransparent;
                    PID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PID.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PID.NoClip = EvetHayirEnum.ehEvet;
                    PID.TextFont.Name = "Arial Narrow";
                    PID.TextFont.Bold = true;
                    PID.Value = @"{#PID#}";

                    HNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 16, 180, 21, false);
                    HNO.Name = "HNO";
                    HNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    HNO.TextFont.Name = "Arial Narrow";
                    HNO.TextFont.Size = 9;
                    HNO.TextFont.Bold = true;
                    HNO.Value = @"Hasta No";

                    AID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 91, 180, 95, false);
                    AID.Name = "AID";
                    AID.FillStyle = FillStyleConstants.vbFSTransparent;
                    AID.FieldType = ReportFieldTypeEnum.ftVariable;
                    AID.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AID.NoClip = EvetHayirEnum.ehEvet;
                    AID.TextFont.Name = "Arial Narrow";
                    AID.TextFont.Size = 9;
                    AID.Value = @"{#ISLEMNO#}";

                    SITENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 36, 239, 41, false);
                    SITENAME.Name = "SITENAME";
                    SITENAME.Visible = EvetHayirEnum.ehHayir;
                    SITENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"",""XXXXXX"")";

                    SITECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 41, 239, 46, false);
                    SITECITY.Name = "SITECITY";
                    SITECITY.Visible = EvetHayirEnum.ehHayir;
                    SITECITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITECITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"",""XXXXXX"")";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 21, 138, 26, false);
                    NewField.Name = "NewField";
                    NewField.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField.TextFont.Size = 9;
                    NewField.TextFont.Bold = true;
                    NewField.Value = @"KÜNYE";

                    NewLine41 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 113, 27, 113, 98, false);
                    NewLine41.Name = "NewLine41";
                    NewLine41.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine41.DrawWidth = 3;

                    NewField52 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 29, 108, 34, false);
                    NewField52.Name = "NewField52";
                    NewField52.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField52.TextFont.Size = 8;
                    NewField52.TextFont.Bold = true;
                    NewField52.Value = @"BİRLİK";

                    NewField53 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 38, 108, 43, false);
                    NewField53.Name = "NewField53";
                    NewField53.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField53.TextFont.Size = 8;
                    NewField53.TextFont.Bold = true;
                    NewField53.Value = @"ADI SOYADI";

                    NewField54 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 47, 111, 52, false);
                    NewField54.Name = "NewField54";
                    NewField54.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField54.TextFont.Size = 8;
                    NewField54.TextFont.Bold = true;
                    NewField54.Value = @"BABA ADI";

                    NewField56 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 56, 111, 61, false);
                    NewField56.Name = "NewField56";
                    NewField56.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField56.TextFont.Size = 8;
                    NewField56.TextFont.Bold = true;
                    NewField56.Value = @"SINIF, RÜTBE";

                    NewField57 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 64, 105, 69, false);
                    NewField57.Name = "NewField57";
                    NewField57.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField57.TextFont.Size = 8;
                    NewField57.TextFont.Bold = true;
                    NewField57.Value = @"SİCİL NO.";

                    NewField58 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 70, 112, 77, false);
                    NewField58.Name = "NewField58";
                    NewField58.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField58.MultiLine = EvetHayirEnum.ehEvet;
                    NewField58.WordBreak = EvetHayirEnum.ehEvet;
                    NewField58.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField58.TextFont.Size = 8;
                    NewField58.TextFont.Bold = true;
                    NewField58.Value = @"D.TARİHİ VE YERİ";

                    NewLine10 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 87, 79, 168, 79, false);
                    NewLine10.Name = "NewLine10";
                    NewLine10.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine10.DrawWidth = 3;

                    NewField85 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 81, 112, 88, false);
                    NewField85.Name = "NewField85";
                    NewField85.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField85.MultiLine = EvetHayirEnum.ehEvet;
                    NewField85.WordBreak = EvetHayirEnum.ehEvet;
                    NewField85.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField85.TextFont.Size = 8;
                    NewField85.TextFont.Bold = true;
                    NewField85.Value = @"DEVAMLI ADRESİ";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 168, 61, 194, 61, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 3;

                    İslem2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 62, 177, 67, false);
                    İslem2.Name = "İslem2";
                    İslem2.FillStyle = FillStyleConstants.vbFSTransparent;
                    İslem2.TextFont.Name = "Arial Narrow";
                    İslem2.TextFont.Size = 9;
                    İslem2.TextFont.Bold = true;
                    İslem2.Value = @"BOY";

                    İslem3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 62, 193, 67, false);
                    İslem3.Name = "İslem3";
                    İslem3.FillStyle = FillStyleConstants.vbFSTransparent;
                    İslem3.TextFont.Name = "Arial Narrow";
                    İslem3.TextFont.Size = 9;
                    İslem3.TextFont.Bold = true;
                    İslem3.Value = @"AĞIRLIK";

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 168, 69, 194, 69, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine6.DrawWidth = 3;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 181, 61, 181, 98, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine15.DrawWidth = 3;

                    NewField59 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 80, 192, 89, false);
                    NewField59.Name = "NewField59";
                    NewField59.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField59.MultiLine = EvetHayirEnum.ehEvet;
                    NewField59.WordBreak = EvetHayirEnum.ehEvet;
                    NewField59.TextFont.Name = "Arial Narrow";
                    NewField59.TextFont.Size = 8;
                    NewField59.TextFont.Bold = true;
                    NewField59.Value = @"İŞLEM SEBEBİ";

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 168, 79, 194, 79, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine16.DrawWidth = 3;

                    NewLine32 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 168, 89, 194, 89, false);
                    NewLine32.Name = "NewLine32";
                    NewLine32.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine32.DrawWidth = 3;

                    BOY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 72, 180, 76, false);
                    BOY.Name = "BOY";
                    BOY.FillStyle = FillStyleConstants.vbFSTransparent;
                    BOY.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BOY.NoClip = EvetHayirEnum.ehEvet;
                    BOY.TextFont.Name = "Arial Narrow";
                    BOY.TextFont.Size = 9;
                    BOY.Value = @"{#BOY#}";

                    KILO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 72, 193, 76, false);
                    KILO.Name = "KILO";
                    KILO.FillStyle = FillStyleConstants.vbFSTransparent;
                    KILO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KILO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KILO.NoClip = EvetHayirEnum.ehEvet;
                    KILO.TextFont.Name = "Arial Narrow";
                    KILO.TextFont.Size = 9;
                    KILO.Value = @"{#KILO#}";

                    NewLine33 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 40, 113, 40, 264, false);
                    NewLine33.Name = "NewLine33";
                    NewLine33.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine33.DrawWidth = 3;

                    NewLine34 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 113, 13, 264, false);
                    NewLine34.Name = "NewLine34";
                    NewLine34.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine34.DrawWidth = 3;

                    BIRIM11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 115, 40, 128, false);
                    BIRIM11.Name = "BIRIM11";
                    BIRIM11.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM11.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM11.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM11.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRIM11.TextFont.Size = 8;
                    BIRIM11.TextFont.Bold = true;
                    BIRIM11.Value = @"İÇ
HASTALIK LARI A.B.D.";

                    NewLine43 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 98, 113, 98, 264, false);
                    NewLine43.Name = "NewLine43";
                    NewLine43.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine43.DrawWidth = 3;

                    NewLine44 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 109, 113, 109, 264, false);
                    NewLine44.Name = "NewLine44";
                    NewLine44.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine44.DrawWidth = 3;

                    BIRIM12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 114, 109, 130, false);
                    BIRIM12.Name = "BIRIM12";
                    BIRIM12.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM12.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM12.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM12.TextFont.Size = 8;
                    BIRIM12.TextFont.Bold = true;
                    BIRIM12.Value = @"KAYIT NO.";

                    NewLine35 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 137, 113, 137, 264, false);
                    NewLine35.Name = "NewLine35";
                    NewLine35.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine35.DrawWidth = 3;

                    BIRIM13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 114, 137, 129, false);
                    BIRIM13.Name = "BIRIM13";
                    BIRIM13.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM13.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM13.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM13.TextFont.Size = 8;
                    BIRIM13.TextFont.Bold = true;
                    BIRIM13.Value = @"GENEL CERRAHİ
HASTALIKLARI A.B.D.";

                    BIRIM14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 131, 137, 146, false);
                    BIRIM14.Name = "BIRIM14";
                    BIRIM14.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM14.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM14.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM14.TextFont.Size = 8;
                    BIRIM14.TextFont.Bold = true;
                    BIRIM14.Value = @"BEYİN VE SİNİR CERRAHİSİ A.B.D.";

                    BIRIM15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 147, 137, 162, false);
                    BIRIM15.Name = "BIRIM15";
                    BIRIM15.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM15.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM15.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM15.TextFont.Size = 8;
                    BIRIM15.TextFont.Bold = true;
                    BIRIM15.Value = @"GÖZ HASTALIKLARI
HASTALIKLARI A.B.D.";

                    BIRIM16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 163, 137, 178, false);
                    BIRIM16.Name = "BIRIM16";
                    BIRIM16.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM16.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM16.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM16.TextFont.Size = 8;
                    BIRIM16.TextFont.Bold = true;
                    BIRIM16.Value = @"KADIN VE DOĞUM
HASTALIKLARI A.B.D.";

                    BIRIM17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 179, 137, 194, false);
                    BIRIM17.Name = "BIRIM17";
                    BIRIM17.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM17.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM17.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM17.TextFont.Size = 8;
                    BIRIM17.TextFont.Bold = true;
                    BIRIM17.Value = @"GÖĞÜS,KALP VE DAMAR
CERRAHİSİ A.B.D.";

                    BIRIM18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 196, 137, 211, false);
                    BIRIM18.Name = "BIRIM18";
                    BIRIM18.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM18.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM18.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM18.TextFont.Size = 8;
                    BIRIM18.TextFont.Bold = true;
                    BIRIM18.Value = @"K.B.B.
A.B.D.";

                    BIRIM19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 214, 137, 229, false);
                    BIRIM19.Name = "BIRIM19";
                    BIRIM19.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM19.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM19.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM19.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM19.TextFont.Size = 8;
                    BIRIM19.TextFont.Bold = true;
                    BIRIM19.Value = @"ORTOPEDİ
TRAVMATOLOJİ A.B.D.";

                    BIRIM20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 231, 137, 246, false);
                    BIRIM20.Name = "BIRIM20";
                    BIRIM20.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRIM20.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIM20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIM20.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIM20.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIM20.TextFont.Size = 8;
                    BIRIM20.TextFont.Bold = true;
                    BIRIM20.Value = @"PLASTİK VE REKONSTRÜKTİF CERRAHİ
A.B.D.";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 29, 167, 35, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FillStyle = FillStyleConstants.vbFSTransparent;
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRLIK.TextFont.Size = 8;
                    BIRLIK.Value = @"";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 38, 160, 42, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FillStyle = FillStyleConstants.vbFSTransparent;
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.Size = 8;
                    ADSOYAD.Value = @"{#PNAME#} {#PSURNAME#}";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 47, 160, 51, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.FillStyle = FillStyleConstants.vbFSTransparent;
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.TextFont.Size = 8;
                    BABAADI.Value = @"{#FATHERNAME#}";

                    SINIFRUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 56, 160, 60, false);
                    SINIFRUTBE.Name = "SINIFRUTBE";
                    SINIFRUTBE.FillStyle = FillStyleConstants.vbFSTransparent;
                    SINIFRUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUTBE.TextFont.Size = 8;
                    SINIFRUTBE.Value = @"";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 63, 160, 67, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.FillStyle = FillStyleConstants.vbFSTransparent;
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.TextFont.Size = 8;
                    SICILNO.Value = @"";

                    DTARIHIYERI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 71, 160, 75, false);
                    DTARIHIYERI.Name = "DTARIHIYERI";
                    DTARIHIYERI.FillStyle = FillStyleConstants.vbFSTransparent;
                    DTARIHIYERI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHIYERI.TextFont.Size = 8;
                    DTARIHIYERI.Value = @"{%DTARIHI%} - {#DOGUMYERI#}";

                    ADRES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 81, 166, 96, false);
                    ADRES.Name = "ADRES";
                    ADRES.FillStyle = FillStyleConstants.vbFSTransparent;
                    ADRES.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRES.MultiLine = EvetHayirEnum.ehEvet;
                    ADRES.WordBreak = EvetHayirEnum.ehEvet;
                    ADRES.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADRES.TextFont.Size = 8;
                    ADRES.Value = @"{#ADRES#}";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 46, 239, 51, false);
                    DTARIHI.Name = "DTARIHI";
                    DTARIHI.Visible = EvetHayirEnum.ehHayir;
                    DTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHI.TextFormat = @"Short Date";
                    DTARIHI.Value = @"{#DTARIHI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeOfProfessors.GetHealthCommitteeOfProfessors_Class dataset_GetHealthCommitteeOfProfessors = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeOfProfessors.GetHealthCommitteeOfProfessors_Class>(0);
                    HEADER.CalcValue = MyParentReport.MAIN.SITENAME.CalcValue + @" 
PROFESÖRLER SAĞLIK KURULU MUAYENE FİŞİ";
                    MUAYENEYIYAPANKURUL.CalcValue = @"";
                    RAPORNO.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Raporno) : "");
                    RAPORTARIHI.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Raportarihi) : "");
                    KARANTINANO.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Kprokolno) : "");
                    HCIKISTARIHI.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Taburcutarihi) : "");
                    HGIRISTARIHI.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Hgtarihi) : "");
                    ISLEMSEBEBI.CalcValue = @"";
                    MAKAM.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Makam) : "");
                    BIRLIKLABEL.CalcValue = BIRLIKLABEL.Value;
                    NewField25.CalcValue = NewField25.Value;
                    NewField26.CalcValue = NewField26.Value;
                    NewField27.CalcValue = NewField27.Value;
                    NewField28.CalcValue = NewField28.Value;
                    NewField29.CalcValue = NewField29.Value;
                    NewField30.CalcValue = NewField30.Value;
                    NewField55.CalcValue = NewField55.Value;
                    BIRIM2.CalcValue = BIRIM2.Value;
                    BIRIM3.CalcValue = BIRIM3.Value;
                    BIRIM4.CalcValue = BIRIM4.Value;
                    BIRIM5.CalcValue = BIRIM5.Value;
                    BIRIM6.CalcValue = BIRIM6.Value;
                    BIRIM7.CalcValue = BIRIM7.Value;
                    BIRIM8.CalcValue = BIRIM8.Value;
                    BIRIM9.CalcValue = BIRIM9.Value;
                    BIRIM10.CalcValue = BIRIM10.Value;
                    ACIKLAMA1.CalcValue = ACIKLAMA1.Value;
                    ACIKLAMA3.CalcValue = ACIKLAMA3.Value;
                    PID.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Pid) : "");
                    HNO.CalcValue = HNO.Value;
                    AID.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Islemno) : "");
                    NewField.CalcValue = NewField.Value;
                    NewField52.CalcValue = NewField52.Value;
                    NewField53.CalcValue = NewField53.Value;
                    NewField54.CalcValue = NewField54.Value;
                    NewField56.CalcValue = NewField56.Value;
                    NewField57.CalcValue = NewField57.Value;
                    NewField58.CalcValue = NewField58.Value;
                    NewField85.CalcValue = NewField85.Value;
                    İslem2.CalcValue = İslem2.Value;
                    İslem3.CalcValue = İslem3.Value;
                    NewField59.CalcValue = NewField59.Value;
                    BOY.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Boy) : "");
                    KILO.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Kilo) : "");
                    BIRIM11.CalcValue = BIRIM11.Value;
                    BIRIM12.CalcValue = BIRIM12.Value;
                    BIRIM13.CalcValue = BIRIM13.Value;
                    BIRIM14.CalcValue = BIRIM14.Value;
                    BIRIM15.CalcValue = BIRIM15.Value;
                    BIRIM16.CalcValue = BIRIM16.Value;
                    BIRIM17.CalcValue = BIRIM17.Value;
                    BIRIM18.CalcValue = BIRIM18.Value;
                    BIRIM19.CalcValue = BIRIM19.Value;
                    BIRIM20.CalcValue = BIRIM20.Value;
                    BIRLIK.CalcValue = @"";
                    ADSOYAD.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Pname) : "") + @" " + (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Psurname) : "");
                    BABAADI.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.FatherName) : "");
                    SINIFRUTBE.CalcValue = @"";
                    SICILNO.CalcValue = @"";
                    DTARIHI.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Dtarihi) : "");
                    DTARIHIYERI.CalcValue = MyParentReport.MAIN.DTARIHI.FormattedValue + @" - " + (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Dogumyeri) : "");
                    ADRES.CalcValue = (dataset_GetHealthCommitteeOfProfessors != null ? Globals.ToStringCore(dataset_GetHealthCommitteeOfProfessors.Adres) : "");
                    SITENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","XXXXXX");
                    SITECITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY","XXXXXX");
                    return new TTReportObject[] { HEADER,MUAYENEYIYAPANKURUL,RAPORNO,RAPORTARIHI,KARANTINANO,HCIKISTARIHI,HGIRISTARIHI,ISLEMSEBEBI,MAKAM,BIRLIKLABEL,NewField25,NewField26,NewField27,NewField28,NewField29,NewField30,NewField55,BIRIM2,BIRIM3,BIRIM4,BIRIM5,BIRIM6,BIRIM7,BIRIM8,BIRIM9,BIRIM10,ACIKLAMA1,ACIKLAMA3,PID,HNO,AID,NewField,NewField52,NewField53,NewField54,NewField56,NewField57,NewField58,NewField85,İslem2,İslem3,NewField59,BOY,KILO,BIRIM11,BIRIM12,BIRIM13,BIRIM14,BIRIM15,BIRIM16,BIRIM17,BIRIM18,BIRIM19,BIRIM20,BIRLIK,ADSOYAD,BABAADI,SINIFRUTBE,SICILNO,DTARIHI,DTARIHIYERI,ADRES,SITENAME,SITECITY};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((SheetListReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommitteeOfProfessors hcp = (HealthCommitteeOfProfessors)context.GetObject(new Guid(sObjectID),"HealthCommitteeOfProfessors");
            
            if(hcp == null)
                throw new Exception("Rapor Profesörler Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealthCommitteeOfProfessors is null");
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

        public SheetListReport()
        {
            Arkasayfa = new ArkasayfaGroup(this,"Arkasayfa");
            MAIN = new MAINGroup(Arkasayfa,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "8A762375-2A52-44E8-9023-D2C11BF6B28B", "No", @"", true, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "SHEETLISTREPORT";
            Caption = "Çarşaf Listesi";
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