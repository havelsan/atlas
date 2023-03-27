
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
    /// TaşınırİşlemFişi
    /// </summary>
    public partial class TasinirIslemFisi : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public TasinirIslemFisi MyParentReport
            {
                get { return (TasinirIslemFisi)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField REPORTHEADER111 { get {return Header().REPORTHEADER111;} }
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
                public TasinirIslemFisi MyParentReport
                {
                    get { return (TasinirIslemFisi)ParentReport; }
                }
                
                public TTReportField REPORTHEADER111; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTHEADER111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 14, 177, 21, false);
                    REPORTHEADER111.Name = "REPORTHEADER111";
                    REPORTHEADER111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTHEADER111.TextFont.Size = 12;
                    REPORTHEADER111.TextFont.Bold = true;
                    REPORTHEADER111.TextFont.CharSet = 162;
                    REPORTHEADER111.Value = @"TAŞINIR İŞLEM FİŞİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTHEADER111.CalcValue = REPORTHEADER111.Value;
                    return new TTReportObject[] { REPORTHEADER111};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public TasinirIslemFisi MyParentReport
                {
                    get { return (TasinirIslemFisi)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class HEADERGroup : TTReportGroup
        {
            public TasinirIslemFisi MyParentReport
            {
                get { return (TasinirIslemFisi)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField NewField102 { get {return Header().NewField102;} }
            public TTReportField NewField1311 { get {return Header().NewField1311;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField1171 { get {return Header().NewField1171;} }
            public TTReportField NewField1271 { get {return Header().NewField1271;} }
            public TTReportField NewField1371 { get {return Header().NewField1371;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField101 { get {return Header().NewField101;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportShape NewLine131 { get {return Header().NewLine131;} }
            public TTReportShape NewLine141 { get {return Header().NewLine141;} }
            public TTReportShape NewLine1121 { get {return Header().NewLine1121;} }
            public TTReportField NewField114111 { get {return Header().NewField114111;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField NewField11911 { get {return Header().NewField11911;} }
            public TTReportField NewField11611 { get {return Header().NewField11611;} }
            public TTReportField NewField11621 { get {return Header().NewField11621;} }
            public TTReportField NewField111611 { get {return Header().NewField111611;} }
            public TTReportField NewField111911 { get {return Header().NewField111911;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField NewField111931 { get {return Header().NewField111931;} }
            public TTReportField NewField1119111 { get {return Header().NewField1119111;} }
            public TTReportField NewField1129111 { get {return Header().NewField1129111;} }
            public TTReportShape NewLine151 { get {return Header().NewLine151;} }
            public TTReportShape NewLine161 { get {return Header().NewLine161;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportShape NewLine1131 { get {return Header().NewLine1131;} }
            public TTReportShape NewLine171 { get {return Header().NewLine171;} }
            public TTReportShape NewLine181 { get {return Header().NewLine181;} }
            public TTReportShape NewLine191 { get {return Header().NewLine191;} }
            public TTReportShape NewLine1141 { get {return Header().NewLine1141;} }
            public TTReportShape NewLine1151 { get {return Header().NewLine1151;} }
            public TTReportShape NewLine1161 { get {return Header().NewLine1161;} }
            public TTReportShape NewLine11311 { get {return Header().NewLine11311;} }
            public TTReportShape NewLine11611 { get {return Header().NewLine11611;} }
            public TTReportShape NewLine11711 { get {return Header().NewLine11711;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1411 { get {return Header().NewField1411;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField1471 { get {return Header().NewField1471;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField11811 { get {return Header().NewField11811;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField11921 { get {return Header().NewField11921;} }
            public TTReportField NewField112111 { get {return Header().NewField112111;} }
            public TTReportField NewField11511 { get {return Header().NewField11511;} }
            public TTReportField NewField11631 { get {return Header().NewField11631;} }
            public TTReportField NewField11121 { get {return Header().NewField11121;} }
            public TTReportField NewField111711 { get {return Header().NewField111711;} }
            public TTReportField NewField112711 { get {return Header().NewField112711;} }
            public TTReportField NewField113711 { get {return Header().NewField113711;} }
            public TTReportShape NewLine111711 { get {return Header().NewLine111711;} }
            public TTReportShape NewLine102 { get {return Header().NewLine102;} }
            public TTReportShape NewLine112 { get {return Header().NewLine112;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField20 { get {return Footer().NewField20;} }
            public TTReportField NewField103 { get {return Footer().NewField103;} }
            public TTReportField NewField104 { get {return Footer().NewField104;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField NewField21 { get {return Footer().NewField21;} }
            public TTReportField NewField11141 { get {return Footer().NewField11141;} }
            public TTReportField NewField11211 { get {return Footer().NewField11211;} }
            public TTReportField NewField11311 { get {return Footer().NewField11311;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField NewField22 { get {return Footer().NewField22;} }
            public TTReportField NewField23 { get {return Footer().NewField23;} }
            public TTReportField NewField114112 { get {return Footer().NewField114112;} }
            public TTReportField NewField111211 { get {return Footer().NewField111211;} }
            public TTReportField NewField111311 { get {return Footer().NewField111311;} }
            public TTReportField NewField24 { get {return Footer().NewField24;} }
            public TTReportField NewField123 { get {return Footer().NewField123;} }
            public TTReportField NewField133 { get {return Footer().NewField133;} }
            public TTReportField NewField25 { get {return Footer().NewField25;} }
            public TTReportField NewField114113 { get {return Footer().NewField114113;} }
            public TTReportField NewField111212 { get {return Footer().NewField111212;} }
            public TTReportField NewField111312 { get {return Footer().NewField111312;} }
            public TTReportField NewField26 { get {return Footer().NewField26;} }
            public TTReportField NewField124 { get {return Footer().NewField124;} }
            public TTReportField NewField134 { get {return Footer().NewField134;} }
            public TTReportField NewField27 { get {return Footer().NewField27;} }
            public TTReportField NewField114114 { get {return Footer().NewField114114;} }
            public TTReportField NewField111213 { get {return Footer().NewField111213;} }
            public TTReportField NewField111313 { get {return Footer().NewField111313;} }
            public TTReportField NewField28 { get {return Footer().NewField28;} }
            public TTReportField NewField125 { get {return Footer().NewField125;} }
            public TTReportField NewField135 { get {return Footer().NewField135;} }
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
                public TasinirIslemFisi MyParentReport
                {
                    get { return (TasinirIslemFisi)ParentReport; }
                }
                
                public TTReportShape NewLine11;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField171;
                public TTReportField NewField111;
                public TTReportField NewField181;
                public TTReportField NewField1111;
                public TTReportField NewField191;
                public TTReportField NewField1211;
                public TTReportField NewField102;
                public TTReportField NewField1311;
                public TTReportField NewField151;
                public TTReportField NewField161;
                public TTReportField NewField112;
                public TTReportField NewField1171;
                public TTReportField NewField1271;
                public TTReportField NewField1371;
                public TTReportField NewField17;
                public TTReportField NewField122;
                public TTReportField NewField18;
                public TTReportField NewField132;
                public TTReportField NewField19;
                public TTReportField NewField101;
                public TTReportShape NewLine12;
                public TTReportShape NewLine121;
                public TTReportShape NewLine111;
                public TTReportShape NewLine131;
                public TTReportShape NewLine141;
                public TTReportShape NewLine1121;
                public TTReportField NewField114111;
                public TTReportField NewField1111111;
                public TTReportField NewField1161;
                public TTReportField NewField11911;
                public TTReportField NewField11611;
                public TTReportField NewField11621;
                public TTReportField NewField111611;
                public TTReportField NewField111911;
                public TTReportField NewField142;
                public TTReportField NewField111931;
                public TTReportField NewField1119111;
                public TTReportField NewField1129111;
                public TTReportShape NewLine151;
                public TTReportShape NewLine161;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine1131;
                public TTReportShape NewLine171;
                public TTReportShape NewLine181;
                public TTReportShape NewLine191;
                public TTReportShape NewLine1141;
                public TTReportShape NewLine1151;
                public TTReportShape NewLine1161;
                public TTReportShape NewLine11311;
                public TTReportShape NewLine11611;
                public TTReportShape NewLine11711;
                public TTReportField NewField121;
                public TTReportField NewField1411;
                public TTReportField NewField1121;
                public TTReportField NewField1131;
                public TTReportField NewField1471;
                public TTReportField NewField11111;
                public TTReportField NewField11811;
                public TTReportField NewField111111;
                public TTReportField NewField11921;
                public TTReportField NewField112111;
                public TTReportField NewField11511;
                public TTReportField NewField11631;
                public TTReportField NewField11121;
                public TTReportField NewField111711;
                public TTReportField NewField112711;
                public TTReportField NewField113711;
                public TTReportShape NewLine111711;
                public TTReportShape NewLine102;
                public TTReportShape NewLine112; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 106;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 12, 9, 40, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 15, 47, 20, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"İl ve ilçenin";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 21, 47, 26, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Harcama Biriminin";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 27, 47, 32, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Taşınır Ambarın";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 33, 47, 38, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Muhasebe Biriminin";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 33, 61, 38, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"ADI";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 15, 144, 20, false);
                    NewField16.Name = "NewField16";
                    NewField16.Value = @"";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 33, 158, 38, false);
                    NewField171.Name = "NewField171";
                    NewField171.TextFont.Bold = true;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"KODU";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 15, 197, 20, false);
                    NewField111.Name = "NewField111";
                    NewField111.Value = @"";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 21, 144, 26, false);
                    NewField181.Name = "NewField181";
                    NewField181.Value = @"";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 21, 197, 26, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.Value = @"";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 27, 144, 32, false);
                    NewField191.Name = "NewField191";
                    NewField191.Value = @"";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 27, 197, 32, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.Value = @"";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 33, 144, 38, false);
                    NewField102.Name = "NewField102";
                    NewField102.Value = @"";

                    NewField1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 33, 197, 38, false);
                    NewField1311.Name = "NewField1311";
                    NewField1311.Value = @"";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 15, 61, 20, false);
                    NewField151.Name = "NewField151";
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"ADI";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 21, 61, 26, false);
                    NewField161.Name = "NewField161";
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"ADI";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 27, 61, 32, false);
                    NewField112.Name = "NewField112";
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"ADI";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 15, 158, 20, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.TextFont.Bold = true;
                    NewField1171.TextFont.CharSet = 162;
                    NewField1171.Value = @"KODU";

                    NewField1271 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 21, 158, 26, false);
                    NewField1271.Name = "NewField1271";
                    NewField1271.TextFont.Bold = true;
                    NewField1271.TextFont.CharSet = 162;
                    NewField1271.Value = @"KODU";

                    NewField1371 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 27, 158, 32, false);
                    NewField1371.Name = "NewField1371";
                    NewField1371.TextFont.Bold = true;
                    NewField1371.TextFont.CharSet = 162;
                    NewField1371.Value = @"KODU";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 4, 47, 9, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"Fiş Sıra No";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 4, 113, 9, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Bütçe Türü";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 4, 49, 9, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @":";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 4, 115, 9, false);
                    NewField132.Name = "NewField132";
                    NewField132.TextFont.Bold = true;
                    NewField132.TextFont.CharSet = 162;
                    NewField132.Value = @":";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 4, 75, 9, false);
                    NewField19.Name = "NewField19";
                    NewField19.Value = @"";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 4, 141, 9, false);
                    NewField101.Name = "NewField101";
                    NewField101.Value = @"";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 12, 199, 12, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 40, 199, 40, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 199, 12, 199, 40, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 47, 12, 47, 40, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 144, 12, 144, 40, false);
                    NewLine141.Name = "NewLine141";
                    NewLine141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 46, 201, 46, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 48, 87, 53, false);
                    NewField114111.Name = "NewField114111";
                    NewField114111.TextFont.Bold = true;
                    NewField114111.TextFont.CharSet = 162;
                    NewField114111.Value = @"Muayene ve Kabul Kom. Rap. Tarih ve Sayısı";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 54, 87, 59, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"Dayanağı Olan Belgenin Tarih ve Sayısı";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 48, 144, 53, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.Value = @"";

                    NewField11911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 61, 74, 66, false);
                    NewField11911.Name = "NewField11911";
                    NewField11911.TextFont.Bold = true;
                    NewField11911.TextFont.CharSet = 162;
                    NewField11911.Value = @"İşlem Çeşidi";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 48, 199, 53, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.Value = @"";

                    NewField11621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 54, 144, 59, false);
                    NewField11621.Name = "NewField11621";
                    NewField11621.Value = @"";

                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 54, 199, 59, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.Value = @"";

                    NewField111911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 61, 137, 66, false);
                    NewField111911.Name = "NewField111911";
                    NewField111911.TextFont.Bold = true;
                    NewField111911.TextFont.CharSet = 162;
                    NewField111911.Value = @"Nereden Geldiği";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 61, 199, 66, false);
                    NewField142.Name = "NewField142";
                    NewField142.TextFont.Bold = true;
                    NewField142.TextFont.CharSet = 162;
                    NewField142.Value = @"Nereye/Kime Verileceği";

                    NewField111931 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 67, 74, 72, false);
                    NewField111931.Name = "NewField111931";
                    NewField111931.Value = @"";

                    NewField1119111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 67, 137, 72, false);
                    NewField1119111.Name = "NewField1119111";
                    NewField1119111.Value = @"";

                    NewField1129111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 67, 199, 72, false);
                    NewField1129111.Name = "NewField1129111";
                    NewField1129111.Value = @"";

                    NewLine151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 46, 11, 73, false);
                    NewLine151.Name = "NewLine151";
                    NewLine151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 73, 201, 73, false);
                    NewLine161.Name = "NewLine161";
                    NewLine161.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 201, 46, 201, 73, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 60, 201, 60, false);
                    NewLine1131.Name = "NewLine1131";
                    NewLine1131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine171 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 74, 60, 74, 73, false);
                    NewLine171.Name = "NewLine171";
                    NewLine171.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine181 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 87, 46, 87, 60, false);
                    NewLine181.Name = "NewLine181";
                    NewLine181.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine191 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 137, 60, 137, 73, false);
                    NewLine191.Name = "NewLine191";
                    NewLine191.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 144, 46, 144, 60, false);
                    NewLine1141.Name = "NewLine1141";
                    NewLine1141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 66, 201, 66, false);
                    NewLine1151.Name = "NewLine1151";
                    NewLine1151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 76, 11, 102, false);
                    NewLine1161.Name = "NewLine1161";
                    NewLine1161.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 83, 201, 83, false);
                    NewLine11311.Name = "NewLine11311";
                    NewLine11311.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11611 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 201, 76, 201, 102, false);
                    NewLine11611.Name = "NewLine11611";
                    NewLine11611.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11711 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 76, 201, 76, false);
                    NewLine11711.Name = "NewLine11711";
                    NewLine11711.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 77, 199, 82, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Birimler ve Ambarlar Arası Taşınır Hareketlerinde";

                    NewField1411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 84, 48, 89, false);
                    NewField1411.Name = "NewField1411";
                    NewField1411.TextFont.Bold = true;
                    NewField1411.TextFont.CharSet = 162;
                    NewField1411.Value = @"Gönderilen Harcama";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 90, 48, 95, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Gönderilen Taşınır";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 96, 48, 101, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Muhasebe Birimi";

                    NewField1471 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 84, 145, 89, false);
                    NewField1471.Name = "NewField1471";
                    NewField1471.Value = @"";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 84, 199, 89, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.Value = @"";

                    NewField11811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 90, 145, 95, false);
                    NewField11811.Name = "NewField11811";
                    NewField11811.Value = @"";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 90, 199, 95, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.Value = @"";

                    NewField11921 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 96, 145, 101, false);
                    NewField11921.Name = "NewField11921";
                    NewField11921.Value = @"";

                    NewField112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 96, 199, 101, false);
                    NewField112111.Name = "NewField112111";
                    NewField112111.Value = @"";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 84, 62, 89, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.TextFont.Bold = true;
                    NewField11511.TextFont.CharSet = 162;
                    NewField11511.Value = @"ADI";

                    NewField11631 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 90, 62, 95, false);
                    NewField11631.Name = "NewField11631";
                    NewField11631.TextFont.Bold = true;
                    NewField11631.TextFont.CharSet = 162;
                    NewField11631.Value = @"ADI";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 96, 62, 101, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.TextFont.Bold = true;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @"ADI";

                    NewField111711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 84, 159, 89, false);
                    NewField111711.Name = "NewField111711";
                    NewField111711.TextFont.Bold = true;
                    NewField111711.TextFont.CharSet = 162;
                    NewField111711.Value = @"KODU";

                    NewField112711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 90, 159, 95, false);
                    NewField112711.Name = "NewField112711";
                    NewField112711.TextFont.Bold = true;
                    NewField112711.TextFont.CharSet = 162;
                    NewField112711.Value = @"KODU";

                    NewField113711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 96, 159, 101, false);
                    NewField113711.Name = "NewField113711";
                    NewField113711.TextFont.Bold = true;
                    NewField113711.TextFont.CharSet = 162;
                    NewField113711.Value = @"KODU";

                    NewLine111711 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 102, 201, 102, false);
                    NewLine111711.Name = "NewLine111711";
                    NewLine111711.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine102 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 48, 82, 48, 102, false);
                    NewLine102.Name = "NewLine102";
                    NewLine102.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 145, 83, 145, 102, false);
                    NewLine112.Name = "NewLine112";
                    NewLine112.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField181.CalcValue = NewField181.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField191.CalcValue = NewField191.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField102.CalcValue = NewField102.Value;
                    NewField1311.CalcValue = NewField1311.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField1271.CalcValue = NewField1271.Value;
                    NewField1371.CalcValue = NewField1371.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField101.CalcValue = NewField101.Value;
                    NewField114111.CalcValue = NewField114111.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField11911.CalcValue = NewField11911.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    NewField11621.CalcValue = NewField11621.Value;
                    NewField111611.CalcValue = NewField111611.Value;
                    NewField111911.CalcValue = NewField111911.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField111931.CalcValue = NewField111931.Value;
                    NewField1119111.CalcValue = NewField1119111.Value;
                    NewField1129111.CalcValue = NewField1129111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1411.CalcValue = NewField1411.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1471.CalcValue = NewField1471.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField11811.CalcValue = NewField11811.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField11921.CalcValue = NewField11921.Value;
                    NewField112111.CalcValue = NewField112111.Value;
                    NewField11511.CalcValue = NewField11511.Value;
                    NewField11631.CalcValue = NewField11631.Value;
                    NewField11121.CalcValue = NewField11121.Value;
                    NewField111711.CalcValue = NewField111711.Value;
                    NewField112711.CalcValue = NewField112711.Value;
                    NewField113711.CalcValue = NewField113711.Value;
                    return new TTReportObject[] { NewField11,NewField12,NewField13,NewField14,NewField15,NewField16,NewField171,NewField111,NewField181,NewField1111,NewField191,NewField1211,NewField102,NewField1311,NewField151,NewField161,NewField112,NewField1171,NewField1271,NewField1371,NewField17,NewField122,NewField18,NewField132,NewField19,NewField101,NewField114111,NewField1111111,NewField1161,NewField11911,NewField11611,NewField11621,NewField111611,NewField111911,NewField142,NewField111931,NewField1119111,NewField1129111,NewField121,NewField1411,NewField1121,NewField1131,NewField1471,NewField11111,NewField11811,NewField111111,NewField11921,NewField112111,NewField11511,NewField11631,NewField11121,NewField111711,NewField112711,NewField113711};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public TasinirIslemFisi MyParentReport
                {
                    get { return (TasinirIslemFisi)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField20;
                public TTReportField NewField103;
                public TTReportField NewField104;
                public TTReportField NewField2;
                public TTReportField NewField21;
                public TTReportField NewField11141;
                public TTReportField NewField11211;
                public TTReportField NewField11311;
                public TTReportField NewField3;
                public TTReportField NewField22;
                public TTReportField NewField23;
                public TTReportField NewField114112;
                public TTReportField NewField111211;
                public TTReportField NewField111311;
                public TTReportField NewField24;
                public TTReportField NewField123;
                public TTReportField NewField133;
                public TTReportField NewField25;
                public TTReportField NewField114113;
                public TTReportField NewField111212;
                public TTReportField NewField111312;
                public TTReportField NewField26;
                public TTReportField NewField124;
                public TTReportField NewField134;
                public TTReportField NewField27;
                public TTReportField NewField114114;
                public TTReportField NewField111213;
                public TTReportField NewField111313;
                public TTReportField NewField28;
                public TTReportField NewField125;
                public TTReportField NewField135; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 73;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 6, 47, 10, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"GİRİŞ KAYDI YAPILMISTIR";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 6, 158, 10, false);
                    NewField20.Name = "NewField20";
                    NewField20.TextFont.Bold = true;
                    NewField20.TextFont.CharSet = 162;
                    NewField20.Value = @"ÇIKIŞ KAYDI YAPILMISTIR";

                    NewField103 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 38, 47, 42, false);
                    NewField103.Name = "NewField103";
                    NewField103.TextFont.Bold = true;
                    NewField103.TextFont.CharSet = 162;
                    NewField103.Value = @"TESLİM EDİLMİŞTİR";

                    NewField104 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 38, 158, 42, false);
                    NewField104.Name = "NewField104";
                    NewField104.TextFont.Bold = true;
                    NewField104.TextFont.CharSet = 162;
                    NewField104.Value = @"TESLİM ALINMIŞTIR";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 11, 91, 16, false);
                    NewField2.Name = "NewField2";
                    NewField2.Value = @"Taşınır Kayıt Kontrol Yetkisinin";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 11, 201, 16, false);
                    NewField21.Name = "NewField21";
                    NewField21.Value = @"Taşınır Kayıt Kontrol Yetkisinin";

                    NewField11141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 17, 25, 22, false);
                    NewField11141.Name = "NewField11141";
                    NewField11141.TextFont.Bold = true;
                    NewField11141.TextFont.CharSet = 162;
                    NewField11141.Value = @"Adı - Soyadı";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 23, 25, 28, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Ünvanı";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 29, 25, 34, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"İmzası";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 17, 91, 22, false);
                    NewField3.Name = "NewField3";
                    NewField3.Value = @"NewField3";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 23, 91, 28, false);
                    NewField22.Name = "NewField22";
                    NewField22.Value = @"NewField3";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 29, 91, 34, false);
                    NewField23.Name = "NewField23";
                    NewField23.Value = @"NewField3";

                    NewField114112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 17, 136, 22, false);
                    NewField114112.Name = "NewField114112";
                    NewField114112.TextFont.Bold = true;
                    NewField114112.TextFont.CharSet = 162;
                    NewField114112.Value = @"Adı - Soyadı";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 23, 136, 28, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Ünvanı";

                    NewField111311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 29, 136, 34, false);
                    NewField111311.Name = "NewField111311";
                    NewField111311.TextFont.Bold = true;
                    NewField111311.TextFont.CharSet = 162;
                    NewField111311.Value = @"İmzası";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 17, 201, 22, false);
                    NewField24.Name = "NewField24";
                    NewField24.Value = @"NewField3";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 23, 201, 28, false);
                    NewField123.Name = "NewField123";
                    NewField123.Value = @"NewField3";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 29, 201, 34, false);
                    NewField133.Name = "NewField133";
                    NewField133.Value = @"NewField3";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 43, 91, 48, false);
                    NewField25.Name = "NewField25";
                    NewField25.Value = @"Teslim Eden";

                    NewField114113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 49, 25, 54, false);
                    NewField114113.Name = "NewField114113";
                    NewField114113.TextFont.Bold = true;
                    NewField114113.TextFont.CharSet = 162;
                    NewField114113.Value = @"Adı - Soyadı";

                    NewField111212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 55, 25, 60, false);
                    NewField111212.Name = "NewField111212";
                    NewField111212.TextFont.Bold = true;
                    NewField111212.TextFont.CharSet = 162;
                    NewField111212.Value = @"Ünvanı";

                    NewField111312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 61, 25, 66, false);
                    NewField111312.Name = "NewField111312";
                    NewField111312.TextFont.Bold = true;
                    NewField111312.TextFont.CharSet = 162;
                    NewField111312.Value = @"İmzası";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 49, 91, 54, false);
                    NewField26.Name = "NewField26";
                    NewField26.Value = @"NewField3";

                    NewField124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 55, 91, 60, false);
                    NewField124.Name = "NewField124";
                    NewField124.Value = @"NewField3";

                    NewField134 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 61, 91, 66, false);
                    NewField134.Name = "NewField134";
                    NewField134.Value = @"NewField3";

                    NewField27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 43, 201, 48, false);
                    NewField27.Name = "NewField27";
                    NewField27.Value = @"Teslim Alan";

                    NewField114114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 49, 136, 54, false);
                    NewField114114.Name = "NewField114114";
                    NewField114114.TextFont.Bold = true;
                    NewField114114.TextFont.CharSet = 162;
                    NewField114114.Value = @"Adı - Soyadı";

                    NewField111213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 55, 136, 60, false);
                    NewField111213.Name = "NewField111213";
                    NewField111213.TextFont.Bold = true;
                    NewField111213.TextFont.CharSet = 162;
                    NewField111213.Value = @"Ünvanı";

                    NewField111313 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 61, 136, 66, false);
                    NewField111313.Name = "NewField111313";
                    NewField111313.TextFont.Bold = true;
                    NewField111313.TextFont.CharSet = 162;
                    NewField111313.Value = @"İmzası";

                    NewField28 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 49, 201, 54, false);
                    NewField28.Name = "NewField28";
                    NewField28.Value = @"NewField3";

                    NewField125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 55, 201, 60, false);
                    NewField125.Name = "NewField125";
                    NewField125.Value = @"NewField3";

                    NewField135 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 137, 61, 201, 66, false);
                    NewField135.Name = "NewField135";
                    NewField135.Value = @"NewField3";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField20.CalcValue = NewField20.Value;
                    NewField103.CalcValue = NewField103.Value;
                    NewField104.CalcValue = NewField104.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField11141.CalcValue = NewField11141.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField22.CalcValue = NewField22.Value;
                    NewField23.CalcValue = NewField23.Value;
                    NewField114112.CalcValue = NewField114112.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField111311.CalcValue = NewField111311.Value;
                    NewField24.CalcValue = NewField24.Value;
                    NewField123.CalcValue = NewField123.Value;
                    NewField133.CalcValue = NewField133.Value;
                    NewField25.CalcValue = NewField25.Value;
                    NewField114113.CalcValue = NewField114113.Value;
                    NewField111212.CalcValue = NewField111212.Value;
                    NewField111312.CalcValue = NewField111312.Value;
                    NewField26.CalcValue = NewField26.Value;
                    NewField124.CalcValue = NewField124.Value;
                    NewField134.CalcValue = NewField134.Value;
                    NewField27.CalcValue = NewField27.Value;
                    NewField114114.CalcValue = NewField114114.Value;
                    NewField111213.CalcValue = NewField111213.Value;
                    NewField111313.CalcValue = NewField111313.Value;
                    NewField28.CalcValue = NewField28.Value;
                    NewField125.CalcValue = NewField125.Value;
                    NewField135.CalcValue = NewField135.Value;
                    return new TTReportObject[] { NewField1,NewField20,NewField103,NewField104,NewField2,NewField21,NewField11141,NewField11211,NewField11311,NewField3,NewField22,NewField23,NewField114112,NewField111211,NewField111311,NewField24,NewField123,NewField133,NewField25,NewField114113,NewField111212,NewField111312,NewField26,NewField124,NewField134,NewField27,NewField114114,NewField111213,NewField111313,NewField28,NewField125,NewField135};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public TasinirIslemFisi MyParentReport
            {
                get { return (TasinirIslemFisi)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRA { get {return Body().SIRA;} }
            public TTReportField TASKOD1 { get {return Body().TASKOD1;} }
            public TTReportField SICILNO { get {return Body().SICILNO;} }
            public TTReportField TASAD { get {return Body().TASAD;} }
            public TTReportField OLCU { get {return Body().OLCU;} }
            public TTReportField MIKTAR { get {return Body().MIKTAR;} }
            public TTReportField TUTAR { get {return Body().TUTAR;} }
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
                public TasinirIslemFisi MyParentReport
                {
                    get { return (TasinirIslemFisi)ParentReport; }
                }
                
                public TTReportField SIRA;
                public TTReportField TASKOD1;
                public TTReportField SICILNO;
                public TTReportField TASAD;
                public TTReportField OLCU;
                public TTReportField MIKTAR;
                public TTReportField TUTAR; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 14;
                    RepeatCount = 0;
                    
                    SIRA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 4, 15, 12, false);
                    SIRA.Name = "SIRA";
                    SIRA.DrawStyle = DrawStyleConstants.vbSolid;
                    SIRA.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIRA.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIRA.MultiLine = EvetHayirEnum.ehEvet;
                    SIRA.WordBreak = EvetHayirEnum.ehEvet;
                    SIRA.TextFont.Name = "Arial";
                    SIRA.TextFont.Size = 8;
                    SIRA.TextFont.Bold = true;
                    SIRA.TextFont.CharSet = 162;
                    SIRA.Value = @"Sıra";

                    TASKOD1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 4, 51, 12, false);
                    TASKOD1.Name = "TASKOD1";
                    TASKOD1.DrawStyle = DrawStyleConstants.vbSolid;
                    TASKOD1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TASKOD1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TASKOD1.MultiLine = EvetHayirEnum.ehEvet;
                    TASKOD1.WordBreak = EvetHayirEnum.ehEvet;
                    TASKOD1.TextFont.Name = "Arial";
                    TASKOD1.TextFont.Size = 8;
                    TASKOD1.TextFont.Bold = true;
                    TASKOD1.TextFont.CharSet = 162;
                    TASKOD1.Value = @"Taşınır Kodu";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 4, 76, 12, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.DrawStyle = DrawStyleConstants.vbSolid;
                    SICILNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SICILNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SICILNO.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO.TextFont.Name = "Arial";
                    SICILNO.TextFont.Size = 8;
                    SICILNO.TextFont.Bold = true;
                    SICILNO.TextFont.CharSet = 162;
                    SICILNO.Value = @"Sicil No";

                    TASAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 4, 158, 12, false);
                    TASAD.Name = "TASAD";
                    TASAD.DrawStyle = DrawStyleConstants.vbSolid;
                    TASAD.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TASAD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TASAD.MultiLine = EvetHayirEnum.ehEvet;
                    TASAD.WordBreak = EvetHayirEnum.ehEvet;
                    TASAD.TextFont.Name = "Arial";
                    TASAD.TextFont.Size = 8;
                    TASAD.TextFont.Bold = true;
                    TASAD.TextFont.CharSet = 162;
                    TASAD.Value = @"Taşınır Adı";

                    OLCU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 4, 175, 12, false);
                    OLCU.Name = "OLCU";
                    OLCU.DrawStyle = DrawStyleConstants.vbSolid;
                    OLCU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLCU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLCU.MultiLine = EvetHayirEnum.ehEvet;
                    OLCU.WordBreak = EvetHayirEnum.ehEvet;
                    OLCU.TextFont.Name = "Arial";
                    OLCU.TextFont.Size = 8;
                    OLCU.TextFont.Bold = true;
                    OLCU.TextFont.CharSet = 162;
                    OLCU.Value = @"Ölçü B.";

                    MIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 4, 187, 12, false);
                    MIKTAR.Name = "MIKTAR";
                    MIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR.MultiLine = EvetHayirEnum.ehEvet;
                    MIKTAR.WordBreak = EvetHayirEnum.ehEvet;
                    MIKTAR.TextFont.Name = "Arial";
                    MIKTAR.TextFont.Size = 8;
                    MIKTAR.TextFont.Bold = true;
                    MIKTAR.TextFont.CharSet = 162;
                    MIKTAR.Value = @"Miktar";

                    TUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 4, 199, 12, false);
                    TUTAR.Name = "TUTAR";
                    TUTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    TUTAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TUTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TUTAR.MultiLine = EvetHayirEnum.ehEvet;
                    TUTAR.WordBreak = EvetHayirEnum.ehEvet;
                    TUTAR.TextFont.Name = "Arial";
                    TUTAR.TextFont.Size = 8;
                    TUTAR.TextFont.Bold = true;
                    TUTAR.TextFont.CharSet = 162;
                    TUTAR.Value = @"Tutar";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SIRA.CalcValue = SIRA.Value;
                    TASKOD1.CalcValue = TASKOD1.Value;
                    SICILNO.CalcValue = SICILNO.Value;
                    TASAD.CalcValue = TASAD.Value;
                    OLCU.CalcValue = OLCU.Value;
                    MIKTAR.CalcValue = MIKTAR.Value;
                    TUTAR.CalcValue = TUTAR.Value;
                    return new TTReportObject[] { SIRA,TASKOD1,SICILNO,TASAD,OLCU,MIKTAR,TUTAR};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class INFORGroup : TTReportGroup
        {
            public TasinirIslemFisi MyParentReport
            {
                get { return (TasinirIslemFisi)ParentReport; }
            }

            new public INFORGroupBody Body()
            {
                return (INFORGroupBody)_body;
            }
            public TTReportField SIRA1 { get {return Body().SIRA1;} }
            public TTReportField TASKOD11 { get {return Body().TASKOD11;} }
            public TTReportField SICILNO1 { get {return Body().SICILNO1;} }
            public TTReportField TASAD1 { get {return Body().TASAD1;} }
            public TTReportField OLCU1 { get {return Body().OLCU1;} }
            public TTReportField MIKTAR1 { get {return Body().MIKTAR1;} }
            public TTReportField TUTAR1 { get {return Body().TUTAR1;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public INFORGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public INFORGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new INFORGroupBody(this);
            }

            public partial class INFORGroupBody : TTReportSection
            {
                public TasinirIslemFisi MyParentReport
                {
                    get { return (TasinirIslemFisi)ParentReport; }
                }
                
                public TTReportField SIRA1;
                public TTReportField TASKOD11;
                public TTReportField SICILNO1;
                public TTReportField TASAD1;
                public TTReportField OLCU1;
                public TTReportField MIKTAR1;
                public TTReportField TUTAR1;
                public TTReportField NewField1;
                public TTReportField NewField11; 
                public INFORGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 22;
                    RepeatCount = 0;
                    
                    SIRA1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 4, 15, 12, false);
                    SIRA1.Name = "SIRA1";
                    SIRA1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRA1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIRA1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIRA1.MultiLine = EvetHayirEnum.ehEvet;
                    SIRA1.WordBreak = EvetHayirEnum.ehEvet;
                    SIRA1.TextFont.Size = 8;
                    SIRA1.TextFont.CharSet = 162;
                    SIRA1.Value = @"";

                    TASKOD11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 4, 51, 12, false);
                    TASKOD11.Name = "TASKOD11";
                    TASKOD11.FieldType = ReportFieldTypeEnum.ftVariable;
                    TASKOD11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TASKOD11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TASKOD11.MultiLine = EvetHayirEnum.ehEvet;
                    TASKOD11.WordBreak = EvetHayirEnum.ehEvet;
                    TASKOD11.TextFont.Size = 8;
                    TASKOD11.TextFont.CharSet = 162;
                    TASKOD11.Value = @"";

                    SICILNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 4, 76, 12, false);
                    SICILNO1.Name = "SICILNO1";
                    SICILNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SICILNO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SICILNO1.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO1.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO1.TextFont.Size = 8;
                    SICILNO1.TextFont.CharSet = 162;
                    SICILNO1.Value = @"";

                    TASAD1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 4, 158, 12, false);
                    TASAD1.Name = "TASAD1";
                    TASAD1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TASAD1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TASAD1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TASAD1.MultiLine = EvetHayirEnum.ehEvet;
                    TASAD1.WordBreak = EvetHayirEnum.ehEvet;
                    TASAD1.TextFont.Size = 8;
                    TASAD1.TextFont.CharSet = 162;
                    TASAD1.Value = @"";

                    OLCU1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 4, 175, 12, false);
                    OLCU1.Name = "OLCU1";
                    OLCU1.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLCU1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLCU1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLCU1.MultiLine = EvetHayirEnum.ehEvet;
                    OLCU1.WordBreak = EvetHayirEnum.ehEvet;
                    OLCU1.TextFont.Size = 8;
                    OLCU1.TextFont.CharSet = 162;
                    OLCU1.Value = @"";

                    MIKTAR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 4, 187, 12, false);
                    MIKTAR1.Name = "MIKTAR1";
                    MIKTAR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MIKTAR1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR1.MultiLine = EvetHayirEnum.ehEvet;
                    MIKTAR1.WordBreak = EvetHayirEnum.ehEvet;
                    MIKTAR1.TextFont.Size = 8;
                    MIKTAR1.TextFont.CharSet = 162;
                    MIKTAR1.Value = @"";

                    TUTAR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 4, 199, 12, false);
                    TUTAR1.Name = "TUTAR1";
                    TUTAR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TUTAR1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TUTAR1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TUTAR1.MultiLine = EvetHayirEnum.ehEvet;
                    TUTAR1.WordBreak = EvetHayirEnum.ehEvet;
                    TUTAR1.TextFont.Size = 8;
                    TUTAR1.TextFont.CharSet = 162;
                    TUTAR1.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 14, 174, 19, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Toplam";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 14, 200, 19, false);
                    NewField11.Name = "NewField11";
                    NewField11.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SIRA1.CalcValue = @"";
                    TASKOD11.CalcValue = @"";
                    SICILNO1.CalcValue = @"";
                    TASAD1.CalcValue = @"";
                    OLCU1.CalcValue = @"";
                    MIKTAR1.CalcValue = @"";
                    TUTAR1.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    return new TTReportObject[] { SIRA1,TASKOD11,SICILNO1,TASAD1,OLCU1,MIKTAR1,TUTAR1,NewField1,NewField11};
                }
            }

        }

        public INFORGroup INFOR;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public TasinirIslemFisi()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            HEADER = new HEADERGroup(PARTA,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            INFOR = new INFORGroup(HEADER,"INFOR");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "TASINIRISLEMFISI";
            Caption = "TaşınırİşlemFişi";
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