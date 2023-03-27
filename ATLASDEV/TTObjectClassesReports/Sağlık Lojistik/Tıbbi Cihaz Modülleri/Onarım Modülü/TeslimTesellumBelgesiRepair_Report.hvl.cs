
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
    /// Teslim Tesellüm Belgesi
    /// </summary>
    public partial class TeslimTesellumBelgesiRepair : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public TeslimTesellumBelgesiRepair MyParentReport
            {
                get { return (TeslimTesellumBelgesiRepair)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField NewField13111 { get {return Body().NewField13111;} }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField SENDERUNIT { get {return Body().SENDERUNIT;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField REPORTNAME1 { get {return Body().REPORTNAME1;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField RECEIVERUNIT { get {return Body().RECEIVERUNIT;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField NewField171 { get {return Body().NewField171;} }
            public TTReportField NewField181 { get {return Body().NewField181;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportField TESLIM11 { get {return Body().TESLIM11;} }
            public TTReportField TESLIM111 { get {return Body().TESLIM111;} }
            public TTReportField NewField111121 { get {return Body().NewField111121;} }
            public TTReportField NewField1121111 { get {return Body().NewField1121111;} }
            public TTReportField NewField1121121 { get {return Body().NewField1121121;} }
            public TTReportField NewField1121131 { get {return Body().NewField1121131;} }
            public TTReportField NewField1121141 { get {return Body().NewField1121141;} }
            public TTReportField DELIVERERUSER { get {return Body().DELIVERERUSER;} }
            public TTReportField DELIVEREDPERSON { get {return Body().DELIVEREDPERSON;} }
            public TTReportField NewField1111111 { get {return Body().NewField1111111;} }
            public TTReportField NewField11111111 { get {return Body().NewField11111111;} }
            public TTReportField COUNT111 { get {return Body().COUNT111;} }
            public TTReportField MATERIALNAME0 { get {return Body().MATERIALNAME0;} }
            public TTReportField AMOUNT0 { get {return Body().AMOUNT0;} }
            public TTReportField DIMENSIONS111 { get {return Body().DIMENSIONS111;} }
            public TTReportField WEIGHT111 { get {return Body().WEIGHT111;} }
            public TTReportField PRICE111 { get {return Body().PRICE111;} }
            public TTReportField DESCRIPTION111 { get {return Body().DESCRIPTION111;} }
            public TTReportField COUNT1111 { get {return Body().COUNT1111;} }
            public TTReportField MATERIALNAME1 { get {return Body().MATERIALNAME1;} }
            public TTReportField AMOUNT1 { get {return Body().AMOUNT1;} }
            public TTReportField DIMENSIONS1111 { get {return Body().DIMENSIONS1111;} }
            public TTReportField WEIGHT1111 { get {return Body().WEIGHT1111;} }
            public TTReportField PRICE1111 { get {return Body().PRICE1111;} }
            public TTReportField DESCRIPTION1111 { get {return Body().DESCRIPTION1111;} }
            public TTReportField COUNT1211 { get {return Body().COUNT1211;} }
            public TTReportField MATERIALNAME2 { get {return Body().MATERIALNAME2;} }
            public TTReportField AMOUNT2 { get {return Body().AMOUNT2;} }
            public TTReportField DIMENSIONS1211 { get {return Body().DIMENSIONS1211;} }
            public TTReportField WEIGHT1211 { get {return Body().WEIGHT1211;} }
            public TTReportField PRICE1211 { get {return Body().PRICE1211;} }
            public TTReportField DESCRIPTION1211 { get {return Body().DESCRIPTION1211;} }
            public TTReportField COUNT1311 { get {return Body().COUNT1311;} }
            public TTReportField MATERIALNAME3 { get {return Body().MATERIALNAME3;} }
            public TTReportField AMOUNT3 { get {return Body().AMOUNT3;} }
            public TTReportField DIMENSIONS1311 { get {return Body().DIMENSIONS1311;} }
            public TTReportField WEIGHT1311 { get {return Body().WEIGHT1311;} }
            public TTReportField PRICE1311 { get {return Body().PRICE1311;} }
            public TTReportField DESCRIPTION1311 { get {return Body().DESCRIPTION1311;} }
            public TTReportField COUNT1411 { get {return Body().COUNT1411;} }
            public TTReportField MATERIALNAME4 { get {return Body().MATERIALNAME4;} }
            public TTReportField AMOUNT4 { get {return Body().AMOUNT4;} }
            public TTReportField DIMENSIONS1411 { get {return Body().DIMENSIONS1411;} }
            public TTReportField WEIGHT1411 { get {return Body().WEIGHT1411;} }
            public TTReportField PRICE1411 { get {return Body().PRICE1411;} }
            public TTReportField DESCRIPTION1411 { get {return Body().DESCRIPTION1411;} }
            public TTReportField COUNT1511 { get {return Body().COUNT1511;} }
            public TTReportField MATERIALNAME5 { get {return Body().MATERIALNAME5;} }
            public TTReportField AMOUNT5 { get {return Body().AMOUNT5;} }
            public TTReportField DIMENSIONS1511 { get {return Body().DIMENSIONS1511;} }
            public TTReportField WEIGHT1511 { get {return Body().WEIGHT1511;} }
            public TTReportField PRICE1511 { get {return Body().PRICE1511;} }
            public TTReportField DESCRIPTION1511 { get {return Body().DESCRIPTION1511;} }
            public TTReportField COUNT1611 { get {return Body().COUNT1611;} }
            public TTReportField MATERIALNAME6 { get {return Body().MATERIALNAME6;} }
            public TTReportField AMOUNT6 { get {return Body().AMOUNT6;} }
            public TTReportField DIMENSIONS1611 { get {return Body().DIMENSIONS1611;} }
            public TTReportField WEIGHT1611 { get {return Body().WEIGHT1611;} }
            public TTReportField PRICE1611 { get {return Body().PRICE1611;} }
            public TTReportField DESCRIPTION1611 { get {return Body().DESCRIPTION1611;} }
            public TTReportField COUNT1711 { get {return Body().COUNT1711;} }
            public TTReportField MATERIALNAME7 { get {return Body().MATERIALNAME7;} }
            public TTReportField AMOUNT7 { get {return Body().AMOUNT7;} }
            public TTReportField DIMENSIONS1711 { get {return Body().DIMENSIONS1711;} }
            public TTReportField WEIGHT1711 { get {return Body().WEIGHT1711;} }
            public TTReportField PRICE1711 { get {return Body().PRICE1711;} }
            public TTReportField DESCRIPTION1711 { get {return Body().DESCRIPTION1711;} }
            public TTReportField COUNT1811 { get {return Body().COUNT1811;} }
            public TTReportField MATERIALNAME8 { get {return Body().MATERIALNAME8;} }
            public TTReportField AMOUNT8 { get {return Body().AMOUNT8;} }
            public TTReportField DIMENSIONS1811 { get {return Body().DIMENSIONS1811;} }
            public TTReportField WEIGHT1811 { get {return Body().WEIGHT1811;} }
            public TTReportField PRICE1811 { get {return Body().PRICE1811;} }
            public TTReportField DESCRIPTION1811 { get {return Body().DESCRIPTION1811;} }
            public TTReportField COUNT1911 { get {return Body().COUNT1911;} }
            public TTReportField MATERIALNAME9 { get {return Body().MATERIALNAME9;} }
            public TTReportField AMOUNT9 { get {return Body().AMOUNT9;} }
            public TTReportField DIMENSIONS1911 { get {return Body().DIMENSIONS1911;} }
            public TTReportField WEIGHT1911 { get {return Body().WEIGHT1911;} }
            public TTReportField PRICE1911 { get {return Body().PRICE1911;} }
            public TTReportField DESCRIPTION1911 { get {return Body().DESCRIPTION1911;} }
            public TTReportField COUNT1021 { get {return Body().COUNT1021;} }
            public TTReportField MATERIALNAME10 { get {return Body().MATERIALNAME10;} }
            public TTReportField AMOUNT10 { get {return Body().AMOUNT10;} }
            public TTReportField DIMENSIONS1021 { get {return Body().DIMENSIONS1021;} }
            public TTReportField WEIGHT1021 { get {return Body().WEIGHT1021;} }
            public TTReportField PRICE1021 { get {return Body().PRICE1021;} }
            public TTReportField DESCRIPTION1021 { get {return Body().DESCRIPTION1021;} }
            public TTReportField COUNT1121 { get {return Body().COUNT1121;} }
            public TTReportField MATERIALNAME11 { get {return Body().MATERIALNAME11;} }
            public TTReportField AMOUNT11 { get {return Body().AMOUNT11;} }
            public TTReportField DIMENSIONS1121 { get {return Body().DIMENSIONS1121;} }
            public TTReportField WEIGHT1121 { get {return Body().WEIGHT1121;} }
            public TTReportField PRICE1121 { get {return Body().PRICE1121;} }
            public TTReportField DESCRIPTION1121 { get {return Body().DESCRIPTION1121;} }
            public TTReportField COUNT1221 { get {return Body().COUNT1221;} }
            public TTReportField MATERIALNAME12 { get {return Body().MATERIALNAME12;} }
            public TTReportField AMOUNT12 { get {return Body().AMOUNT12;} }
            public TTReportField DIMENSIONS1221 { get {return Body().DIMENSIONS1221;} }
            public TTReportField WEIGHT1221 { get {return Body().WEIGHT1221;} }
            public TTReportField PRICE1221 { get {return Body().PRICE1221;} }
            public TTReportField DESCRIPTION1221 { get {return Body().DESCRIPTION1221;} }
            public TTReportField COUNT1321 { get {return Body().COUNT1321;} }
            public TTReportField MATERIALNAME13 { get {return Body().MATERIALNAME13;} }
            public TTReportField AMOUNT13 { get {return Body().AMOUNT13;} }
            public TTReportField DIMENSIONS1321 { get {return Body().DIMENSIONS1321;} }
            public TTReportField WEIGHT1321 { get {return Body().WEIGHT1321;} }
            public TTReportField PRICE1321 { get {return Body().PRICE1321;} }
            public TTReportField DESCRIPTION1321 { get {return Body().DESCRIPTION1321;} }
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
                public TeslimTesellumBelgesiRepair MyParentReport
                {
                    get { return (TeslimTesellumBelgesiRepair)ParentReport; }
                }
                
                public TTReportField ORDERNO;
                public TTReportField NewField13111;
                public TTReportField NewField1111;
                public TTReportField NewField121;
                public TTReportField SENDERUNIT;
                public TTReportField NewField11;
                public TTReportField REPORTNAME1;
                public TTReportField NewField111;
                public TTReportField NewField1121;
                public TTReportField RECEIVERUNIT;
                public TTReportShape NewLine11;
                public TTReportField NewField12;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField161;
                public TTReportField NewField171;
                public TTReportField NewField181;
                public TTReportShape NewLine12;
                public TTReportShape NewLine121;
                public TTReportField TESLIM11;
                public TTReportField TESLIM111;
                public TTReportField NewField111121;
                public TTReportField NewField1121111;
                public TTReportField NewField1121121;
                public TTReportField NewField1121131;
                public TTReportField NewField1121141;
                public TTReportField DELIVERERUSER;
                public TTReportField DELIVEREDPERSON;
                public TTReportField NewField1111111;
                public TTReportField NewField11111111;
                public TTReportField COUNT111;
                public TTReportField MATERIALNAME0;
                public TTReportField AMOUNT0;
                public TTReportField DIMENSIONS111;
                public TTReportField WEIGHT111;
                public TTReportField PRICE111;
                public TTReportField DESCRIPTION111;
                public TTReportField COUNT1111;
                public TTReportField MATERIALNAME1;
                public TTReportField AMOUNT1;
                public TTReportField DIMENSIONS1111;
                public TTReportField WEIGHT1111;
                public TTReportField PRICE1111;
                public TTReportField DESCRIPTION1111;
                public TTReportField COUNT1211;
                public TTReportField MATERIALNAME2;
                public TTReportField AMOUNT2;
                public TTReportField DIMENSIONS1211;
                public TTReportField WEIGHT1211;
                public TTReportField PRICE1211;
                public TTReportField DESCRIPTION1211;
                public TTReportField COUNT1311;
                public TTReportField MATERIALNAME3;
                public TTReportField AMOUNT3;
                public TTReportField DIMENSIONS1311;
                public TTReportField WEIGHT1311;
                public TTReportField PRICE1311;
                public TTReportField DESCRIPTION1311;
                public TTReportField COUNT1411;
                public TTReportField MATERIALNAME4;
                public TTReportField AMOUNT4;
                public TTReportField DIMENSIONS1411;
                public TTReportField WEIGHT1411;
                public TTReportField PRICE1411;
                public TTReportField DESCRIPTION1411;
                public TTReportField COUNT1511;
                public TTReportField MATERIALNAME5;
                public TTReportField AMOUNT5;
                public TTReportField DIMENSIONS1511;
                public TTReportField WEIGHT1511;
                public TTReportField PRICE1511;
                public TTReportField DESCRIPTION1511;
                public TTReportField COUNT1611;
                public TTReportField MATERIALNAME6;
                public TTReportField AMOUNT6;
                public TTReportField DIMENSIONS1611;
                public TTReportField WEIGHT1611;
                public TTReportField PRICE1611;
                public TTReportField DESCRIPTION1611;
                public TTReportField COUNT1711;
                public TTReportField MATERIALNAME7;
                public TTReportField AMOUNT7;
                public TTReportField DIMENSIONS1711;
                public TTReportField WEIGHT1711;
                public TTReportField PRICE1711;
                public TTReportField DESCRIPTION1711;
                public TTReportField COUNT1811;
                public TTReportField MATERIALNAME8;
                public TTReportField AMOUNT8;
                public TTReportField DIMENSIONS1811;
                public TTReportField WEIGHT1811;
                public TTReportField PRICE1811;
                public TTReportField DESCRIPTION1811;
                public TTReportField COUNT1911;
                public TTReportField MATERIALNAME9;
                public TTReportField AMOUNT9;
                public TTReportField DIMENSIONS1911;
                public TTReportField WEIGHT1911;
                public TTReportField PRICE1911;
                public TTReportField DESCRIPTION1911;
                public TTReportField COUNT1021;
                public TTReportField MATERIALNAME10;
                public TTReportField AMOUNT10;
                public TTReportField DIMENSIONS1021;
                public TTReportField WEIGHT1021;
                public TTReportField PRICE1021;
                public TTReportField DESCRIPTION1021;
                public TTReportField COUNT1121;
                public TTReportField MATERIALNAME11;
                public TTReportField AMOUNT11;
                public TTReportField DIMENSIONS1121;
                public TTReportField WEIGHT1121;
                public TTReportField PRICE1121;
                public TTReportField DESCRIPTION1121;
                public TTReportField COUNT1221;
                public TTReportField MATERIALNAME12;
                public TTReportField AMOUNT12;
                public TTReportField DIMENSIONS1221;
                public TTReportField WEIGHT1221;
                public TTReportField PRICE1221;
                public TTReportField DESCRIPTION1221;
                public TTReportField COUNT1321;
                public TTReportField MATERIALNAME13;
                public TTReportField AMOUNT13;
                public TTReportField DIMENSIONS1321;
                public TTReportField WEIGHT1321;
                public TTReportField PRICE1321;
                public TTReportField DESCRIPTION1321; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 210;
                    RepeatCount = 0;
                    
                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 36, 256, 41, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"";

                    NewField13111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 36, 196, 41, false);
                    NewField13111.Name = "NewField13111";
                    NewField13111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13111.TextFont.Name = "Arial";
                    NewField13111.TextFont.Bold = true;
                    NewField13111.TextFont.CharSet = 162;
                    NewField13111.Value = @"SİPARİŞ KODU  :";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 30, 196, 35, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"ÖNCELİK KODU:";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 30, 36, 35, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @":";

                    SENDERUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 30, 166, 35, false);
                    SENDERUNIT.Name = "SENDERUNIT";
                    SENDERUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENDERUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SENDERUNIT.TextFont.Name = "Arial";
                    SENDERUNIT.TextFont.CharSet = 162;
                    SENDERUNIT.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 30, 35, 35, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"GÖNDEREN BİRLİK";

                    REPORTNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 25, 257, 30, false);
                    REPORTNAME1.Name = "REPORTNAME1";
                    REPORTNAME1.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME1.TextFont.Name = "Arial";
                    REPORTNAME1.TextFont.Size = 11;
                    REPORTNAME1.TextFont.Bold = true;
                    REPORTNAME1.TextFont.CharSet = 162;
                    REPORTNAME1.Value = @"TESLİM TESELLÜM BELGESİ";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 36, 35, 41, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"ALICI BİRLİK";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 36, 36, 41, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                    RECEIVERUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 36, 166, 41, false);
                    RECEIVERUNIT.Name = "RECEIVERUNIT";
                    RECEIVERUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIVERUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RECEIVERUNIT.ObjectDefName = "ReferToUpperLevel";
                    RECEIVERUNIT.DataMember = "OWNERMILITARYUNIT.NAME";
                    RECEIVERUNIT.TextFont.Name = "Arial";
                    RECEIVERUNIT.TextFont.CharSet = 162;
                    RECEIVERUNIT.Value = @"";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 41, 257, 41, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 41, 21, 46, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"SIRA NU.";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 41, 103, 46, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"MALZEMENİN CİNSİ";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 41, 127, 46, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"MİKTARI";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 41, 155, 46, false);
                    NewField151.Name = "NewField151";
                    NewField151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"EBATLARI (CM)";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 41, 183, 46, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"AĞIRLIK (KG)";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 41, 211, 46, false);
                    NewField171.Name = "NewField171";
                    NewField171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField171.TextFont.Name = "Arial";
                    NewField171.TextFont.Bold = true;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"DEĞERİ (TL.)";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 41, 257, 46, false);
                    NewField181.Name = "NewField181";
                    NewField181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField181.TextFont.Name = "Arial";
                    NewField181.TextFont.Bold = true;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @"AÇIKLAMALAR";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 257, 30, 257, 41, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 30, 0, 41, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    TESLIM11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 139, 257, 144, false);
                    TESLIM11.Name = "TESLIM11";
                    TESLIM11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TESLIM11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TESLIM11.TextFont.Name = "Arial";
                    TESLIM11.TextFont.Bold = true;
                    TESLIM11.TextFont.CharSet = 162;
                    TESLIM11.Value = @"YUKARIDAKİ MALZEMELER TAM VE SAĞLAM OLARAK TESLİM EDİLMİŞTİR.";

                    TESLIM111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 147, 257, 156, false);
                    TESLIM111.Name = "TESLIM111";
                    TESLIM111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TESLIM111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TESLIM111.TextFont.Name = "Arial";
                    TESLIM111.TextFont.Size = 14;
                    TESLIM111.TextFont.Bold = true;
                    TESLIM111.TextFont.CharSet = 162;
                    TESLIM111.Value = @"NOT : DİKKAT KIRILACAK HASSAS TIBBİ CİHAZ/MALZEMESİDİR! DİKKATLİ TAŞIYINIZ!";

                    NewField111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 161, 29, 166, false);
                    NewField111121.Name = "NewField111121";
                    NewField111121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111121.TextFont.Name = "Arial";
                    NewField111121.TextFont.Bold = true;
                    NewField111121.TextFont.CharSet = 162;
                    NewField111121.Value = @"TESLİM EDEN";

                    NewField1121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 161, 76, 166, false);
                    NewField1121111.Name = "NewField1121111";
                    NewField1121111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121111.TextFont.Name = "Arial";
                    NewField1121111.TextFont.Bold = true;
                    NewField1121111.TextFont.CharSet = 162;
                    NewField1121111.Value = @"TESLİM EDEN";

                    NewField1121121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 161, 119, 166, false);
                    NewField1121121.Name = "NewField1121121";
                    NewField1121121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121121.TextFont.Name = "Arial";
                    NewField1121121.TextFont.Bold = true;
                    NewField1121121.TextFont.CharSet = 162;
                    NewField1121121.Value = @"ÜYE";

                    NewField1121131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 161, 199, 166, false);
                    NewField1121131.Name = "NewField1121131";
                    NewField1121131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121131.TextFont.Name = "Arial";
                    NewField1121131.TextFont.Bold = true;
                    NewField1121131.TextFont.CharSet = 162;
                    NewField1121131.Value = @"MUA. KONT. ve KLT. YNT. BL.";

                    NewField1121141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 161, 252, 166, false);
                    NewField1121141.Name = "NewField1121141";
                    NewField1121141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121141.TextFont.Name = "Arial";
                    NewField1121141.TextFont.Bold = true;
                    NewField1121141.TextFont.CharSet = 162;
                    NewField1121141.Value = @"TESLİM ALAN";

                    DELIVERERUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 166, 29, 180, false);
                    DELIVERERUSER.Name = "DELIVERERUSER";
                    DELIVERERUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DELIVERERUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DELIVERERUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DELIVERERUSER.MultiLine = EvetHayirEnum.ehEvet;
                    DELIVERERUSER.NoClip = EvetHayirEnum.ehEvet;
                    DELIVERERUSER.TextFont.Name = "Arial";
                    DELIVERERUSER.TextFont.CharSet = 162;
                    DELIVERERUSER.Value = @"";

                    DELIVEREDPERSON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 166, 252, 171, false);
                    DELIVEREDPERSON.Name = "DELIVEREDPERSON";
                    DELIVEREDPERSON.FieldType = ReportFieldTypeEnum.ftVariable;
                    DELIVEREDPERSON.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DELIVEREDPERSON.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DELIVEREDPERSON.NoClip = EvetHayirEnum.ehEvet;
                    DELIVEREDPERSON.TextFont.Name = "Arial";
                    DELIVEREDPERSON.TextFont.CharSet = 162;
                    DELIVEREDPERSON.Value = @"";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 117, 213, 122, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111111.TextFont.Name = "Arial";
                    NewField1111111.TextFont.Size = 8;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"ÖLÇÜ ALINDIĞI TARİH";

                    NewField11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 117, 256, 122, false);
                    NewField11111111.Name = "NewField11111111";
                    NewField11111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111111.TextFont.Name = "Arial";
                    NewField11111111.TextFont.Size = 8;
                    NewField11111111.TextFont.Bold = true;
                    NewField11111111.TextFont.CharSet = 162;
                    NewField11111111.Value = @"AMBALAJ YAPILDIĞI TARİH";

                    COUNT111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 46, 21, 51, false);
                    COUNT111.Name = "COUNT111";
                    COUNT111.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT111.TextFont.Name = "Arial";
                    COUNT111.TextFont.CharSet = 162;
                    COUNT111.Value = @"1";

                    MATERIALNAME0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 46, 103, 51, false);
                    MATERIALNAME0.Name = "MATERIALNAME0";
                    MATERIALNAME0.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME0.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME0.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME0.TextFont.Name = "Arial";
                    MATERIALNAME0.TextFont.CharSet = 162;
                    MATERIALNAME0.Value = @"";

                    AMOUNT0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 46, 127, 51, false);
                    AMOUNT0.Name = "AMOUNT0";
                    AMOUNT0.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT0.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT0.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT0.TextFont.Name = "Arial";
                    AMOUNT0.TextFont.CharSet = 162;
                    AMOUNT0.Value = @"";

                    DIMENSIONS111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 46, 155, 51, false);
                    DIMENSIONS111.Name = "DIMENSIONS111";
                    DIMENSIONS111.DrawStyle = DrawStyleConstants.vbSolid;
                    DIMENSIONS111.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIMENSIONS111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIMENSIONS111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIMENSIONS111.TextFont.Name = "Arial";
                    DIMENSIONS111.TextFont.CharSet = 162;
                    DIMENSIONS111.Value = @"";

                    WEIGHT111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 46, 183, 51, false);
                    WEIGHT111.Name = "WEIGHT111";
                    WEIGHT111.DrawStyle = DrawStyleConstants.vbSolid;
                    WEIGHT111.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEIGHT111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WEIGHT111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WEIGHT111.TextFont.Name = "Arial";
                    WEIGHT111.TextFont.CharSet = 162;
                    WEIGHT111.Value = @"";

                    PRICE111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 46, 211, 51, false);
                    PRICE111.Name = "PRICE111";
                    PRICE111.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE111.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRICE111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICE111.TextFont.Name = "Arial";
                    PRICE111.TextFont.CharSet = 162;
                    PRICE111.Value = @"";

                    DESCRIPTION111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 46, 257, 51, false);
                    DESCRIPTION111.Name = "DESCRIPTION111";
                    DESCRIPTION111.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION111.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION111.TextFont.Name = "Arial";
                    DESCRIPTION111.TextFont.CharSet = 162;
                    DESCRIPTION111.Value = @"";

                    COUNT1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 51, 21, 56, false);
                    COUNT1111.Name = "COUNT1111";
                    COUNT1111.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT1111.TextFont.Name = "Arial";
                    COUNT1111.TextFont.CharSet = 162;
                    COUNT1111.Value = @"2";

                    MATERIALNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 51, 103, 56, false);
                    MATERIALNAME1.Name = "MATERIALNAME1";
                    MATERIALNAME1.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME1.TextFont.Name = "Arial";
                    MATERIALNAME1.TextFont.CharSet = 162;
                    MATERIALNAME1.Value = @"";

                    AMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 51, 127, 56, false);
                    AMOUNT1.Name = "AMOUNT1";
                    AMOUNT1.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT1.TextFont.Name = "Arial";
                    AMOUNT1.TextFont.CharSet = 162;
                    AMOUNT1.Value = @"";

                    DIMENSIONS1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 51, 155, 56, false);
                    DIMENSIONS1111.Name = "DIMENSIONS1111";
                    DIMENSIONS1111.DrawStyle = DrawStyleConstants.vbSolid;
                    DIMENSIONS1111.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIMENSIONS1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIMENSIONS1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIMENSIONS1111.TextFont.Name = "Arial";
                    DIMENSIONS1111.TextFont.CharSet = 162;
                    DIMENSIONS1111.Value = @"";

                    WEIGHT1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 51, 183, 56, false);
                    WEIGHT1111.Name = "WEIGHT1111";
                    WEIGHT1111.DrawStyle = DrawStyleConstants.vbSolid;
                    WEIGHT1111.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEIGHT1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WEIGHT1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WEIGHT1111.TextFont.Name = "Arial";
                    WEIGHT1111.TextFont.CharSet = 162;
                    WEIGHT1111.Value = @"";

                    PRICE1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 51, 211, 56, false);
                    PRICE1111.Name = "PRICE1111";
                    PRICE1111.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE1111.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRICE1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICE1111.TextFont.Name = "Arial";
                    PRICE1111.TextFont.CharSet = 162;
                    PRICE1111.Value = @"";

                    DESCRIPTION1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 51, 257, 56, false);
                    DESCRIPTION1111.Name = "DESCRIPTION1111";
                    DESCRIPTION1111.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION1111.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION1111.TextFont.Name = "Arial";
                    DESCRIPTION1111.TextFont.CharSet = 162;
                    DESCRIPTION1111.Value = @"";

                    COUNT1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 56, 21, 61, false);
                    COUNT1211.Name = "COUNT1211";
                    COUNT1211.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT1211.TextFont.Name = "Arial";
                    COUNT1211.TextFont.CharSet = 162;
                    COUNT1211.Value = @"3";

                    MATERIALNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 56, 103, 61, false);
                    MATERIALNAME2.Name = "MATERIALNAME2";
                    MATERIALNAME2.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME2.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME2.TextFont.Name = "Arial";
                    MATERIALNAME2.TextFont.CharSet = 162;
                    MATERIALNAME2.Value = @"";

                    AMOUNT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 56, 127, 61, false);
                    AMOUNT2.Name = "AMOUNT2";
                    AMOUNT2.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT2.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT2.TextFont.Name = "Arial";
                    AMOUNT2.TextFont.CharSet = 162;
                    AMOUNT2.Value = @"";

                    DIMENSIONS1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 56, 155, 61, false);
                    DIMENSIONS1211.Name = "DIMENSIONS1211";
                    DIMENSIONS1211.DrawStyle = DrawStyleConstants.vbSolid;
                    DIMENSIONS1211.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIMENSIONS1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIMENSIONS1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIMENSIONS1211.TextFont.Name = "Arial";
                    DIMENSIONS1211.TextFont.CharSet = 162;
                    DIMENSIONS1211.Value = @"";

                    WEIGHT1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 56, 183, 61, false);
                    WEIGHT1211.Name = "WEIGHT1211";
                    WEIGHT1211.DrawStyle = DrawStyleConstants.vbSolid;
                    WEIGHT1211.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEIGHT1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WEIGHT1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WEIGHT1211.TextFont.Name = "Arial";
                    WEIGHT1211.TextFont.CharSet = 162;
                    WEIGHT1211.Value = @"";

                    PRICE1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 56, 211, 61, false);
                    PRICE1211.Name = "PRICE1211";
                    PRICE1211.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE1211.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRICE1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICE1211.TextFont.Name = "Arial";
                    PRICE1211.TextFont.CharSet = 162;
                    PRICE1211.Value = @"";

                    DESCRIPTION1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 56, 257, 61, false);
                    DESCRIPTION1211.Name = "DESCRIPTION1211";
                    DESCRIPTION1211.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION1211.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION1211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION1211.TextFont.Name = "Arial";
                    DESCRIPTION1211.TextFont.CharSet = 162;
                    DESCRIPTION1211.Value = @"";

                    COUNT1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 61, 21, 66, false);
                    COUNT1311.Name = "COUNT1311";
                    COUNT1311.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT1311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT1311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT1311.TextFont.Name = "Arial";
                    COUNT1311.TextFont.CharSet = 162;
                    COUNT1311.Value = @"4";

                    MATERIALNAME3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 61, 103, 66, false);
                    MATERIALNAME3.Name = "MATERIALNAME3";
                    MATERIALNAME3.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME3.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME3.TextFont.Name = "Arial";
                    MATERIALNAME3.TextFont.CharSet = 162;
                    MATERIALNAME3.Value = @"";

                    AMOUNT3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 61, 127, 66, false);
                    AMOUNT3.Name = "AMOUNT3";
                    AMOUNT3.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT3.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT3.TextFont.Name = "Arial";
                    AMOUNT3.TextFont.CharSet = 162;
                    AMOUNT3.Value = @"";

                    DIMENSIONS1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 61, 155, 66, false);
                    DIMENSIONS1311.Name = "DIMENSIONS1311";
                    DIMENSIONS1311.DrawStyle = DrawStyleConstants.vbSolid;
                    DIMENSIONS1311.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIMENSIONS1311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIMENSIONS1311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIMENSIONS1311.TextFont.Name = "Arial";
                    DIMENSIONS1311.TextFont.CharSet = 162;
                    DIMENSIONS1311.Value = @"";

                    WEIGHT1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 61, 183, 66, false);
                    WEIGHT1311.Name = "WEIGHT1311";
                    WEIGHT1311.DrawStyle = DrawStyleConstants.vbSolid;
                    WEIGHT1311.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEIGHT1311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WEIGHT1311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WEIGHT1311.TextFont.Name = "Arial";
                    WEIGHT1311.TextFont.CharSet = 162;
                    WEIGHT1311.Value = @"";

                    PRICE1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 61, 211, 66, false);
                    PRICE1311.Name = "PRICE1311";
                    PRICE1311.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE1311.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE1311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRICE1311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICE1311.TextFont.Name = "Arial";
                    PRICE1311.TextFont.CharSet = 162;
                    PRICE1311.Value = @"";

                    DESCRIPTION1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 61, 257, 66, false);
                    DESCRIPTION1311.Name = "DESCRIPTION1311";
                    DESCRIPTION1311.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION1311.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION1311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION1311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION1311.TextFont.Name = "Arial";
                    DESCRIPTION1311.TextFont.CharSet = 162;
                    DESCRIPTION1311.Value = @"";

                    COUNT1411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 66, 21, 71, false);
                    COUNT1411.Name = "COUNT1411";
                    COUNT1411.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT1411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT1411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT1411.TextFont.Name = "Arial";
                    COUNT1411.TextFont.CharSet = 162;
                    COUNT1411.Value = @"5";

                    MATERIALNAME4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 66, 103, 71, false);
                    MATERIALNAME4.Name = "MATERIALNAME4";
                    MATERIALNAME4.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME4.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME4.TextFont.Name = "Arial";
                    MATERIALNAME4.TextFont.CharSet = 162;
                    MATERIALNAME4.Value = @"";

                    AMOUNT4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 66, 127, 71, false);
                    AMOUNT4.Name = "AMOUNT4";
                    AMOUNT4.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT4.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT4.TextFont.Name = "Arial";
                    AMOUNT4.TextFont.CharSet = 162;
                    AMOUNT4.Value = @"";

                    DIMENSIONS1411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 66, 155, 71, false);
                    DIMENSIONS1411.Name = "DIMENSIONS1411";
                    DIMENSIONS1411.DrawStyle = DrawStyleConstants.vbSolid;
                    DIMENSIONS1411.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIMENSIONS1411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIMENSIONS1411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIMENSIONS1411.TextFont.Name = "Arial";
                    DIMENSIONS1411.TextFont.CharSet = 162;
                    DIMENSIONS1411.Value = @"";

                    WEIGHT1411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 66, 183, 71, false);
                    WEIGHT1411.Name = "WEIGHT1411";
                    WEIGHT1411.DrawStyle = DrawStyleConstants.vbSolid;
                    WEIGHT1411.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEIGHT1411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WEIGHT1411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WEIGHT1411.TextFont.Name = "Arial";
                    WEIGHT1411.TextFont.CharSet = 162;
                    WEIGHT1411.Value = @"";

                    PRICE1411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 66, 211, 71, false);
                    PRICE1411.Name = "PRICE1411";
                    PRICE1411.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE1411.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE1411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRICE1411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICE1411.TextFont.Name = "Arial";
                    PRICE1411.TextFont.CharSet = 162;
                    PRICE1411.Value = @"";

                    DESCRIPTION1411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 66, 257, 71, false);
                    DESCRIPTION1411.Name = "DESCRIPTION1411";
                    DESCRIPTION1411.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION1411.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION1411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION1411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION1411.TextFont.Name = "Arial";
                    DESCRIPTION1411.TextFont.CharSet = 162;
                    DESCRIPTION1411.Value = @"";

                    COUNT1511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 71, 21, 76, false);
                    COUNT1511.Name = "COUNT1511";
                    COUNT1511.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT1511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT1511.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT1511.TextFont.Name = "Arial";
                    COUNT1511.TextFont.CharSet = 162;
                    COUNT1511.Value = @"6";

                    MATERIALNAME5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 71, 103, 76, false);
                    MATERIALNAME5.Name = "MATERIALNAME5";
                    MATERIALNAME5.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME5.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME5.TextFont.Name = "Arial";
                    MATERIALNAME5.TextFont.CharSet = 162;
                    MATERIALNAME5.Value = @"";

                    AMOUNT5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 71, 127, 76, false);
                    AMOUNT5.Name = "AMOUNT5";
                    AMOUNT5.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT5.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT5.TextFont.Name = "Arial";
                    AMOUNT5.TextFont.CharSet = 162;
                    AMOUNT5.Value = @"";

                    DIMENSIONS1511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 71, 155, 76, false);
                    DIMENSIONS1511.Name = "DIMENSIONS1511";
                    DIMENSIONS1511.DrawStyle = DrawStyleConstants.vbSolid;
                    DIMENSIONS1511.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIMENSIONS1511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIMENSIONS1511.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIMENSIONS1511.TextFont.Name = "Arial";
                    DIMENSIONS1511.TextFont.CharSet = 162;
                    DIMENSIONS1511.Value = @"";

                    WEIGHT1511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 71, 183, 76, false);
                    WEIGHT1511.Name = "WEIGHT1511";
                    WEIGHT1511.DrawStyle = DrawStyleConstants.vbSolid;
                    WEIGHT1511.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEIGHT1511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WEIGHT1511.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WEIGHT1511.TextFont.Name = "Arial";
                    WEIGHT1511.TextFont.CharSet = 162;
                    WEIGHT1511.Value = @"";

                    PRICE1511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 71, 211, 76, false);
                    PRICE1511.Name = "PRICE1511";
                    PRICE1511.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE1511.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE1511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRICE1511.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICE1511.TextFont.Name = "Arial";
                    PRICE1511.TextFont.CharSet = 162;
                    PRICE1511.Value = @"";

                    DESCRIPTION1511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 71, 257, 76, false);
                    DESCRIPTION1511.Name = "DESCRIPTION1511";
                    DESCRIPTION1511.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION1511.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION1511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION1511.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION1511.TextFont.Name = "Arial";
                    DESCRIPTION1511.TextFont.CharSet = 162;
                    DESCRIPTION1511.Value = @"";

                    COUNT1611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 76, 21, 81, false);
                    COUNT1611.Name = "COUNT1611";
                    COUNT1611.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT1611.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT1611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT1611.TextFont.Name = "Arial";
                    COUNT1611.TextFont.CharSet = 162;
                    COUNT1611.Value = @"7";

                    MATERIALNAME6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 76, 103, 81, false);
                    MATERIALNAME6.Name = "MATERIALNAME6";
                    MATERIALNAME6.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME6.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME6.TextFont.Name = "Arial";
                    MATERIALNAME6.TextFont.CharSet = 162;
                    MATERIALNAME6.Value = @"";

                    AMOUNT6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 76, 127, 81, false);
                    AMOUNT6.Name = "AMOUNT6";
                    AMOUNT6.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT6.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT6.TextFont.Name = "Arial";
                    AMOUNT6.TextFont.CharSet = 162;
                    AMOUNT6.Value = @"";

                    DIMENSIONS1611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 76, 155, 81, false);
                    DIMENSIONS1611.Name = "DIMENSIONS1611";
                    DIMENSIONS1611.DrawStyle = DrawStyleConstants.vbSolid;
                    DIMENSIONS1611.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIMENSIONS1611.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIMENSIONS1611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIMENSIONS1611.TextFont.Name = "Arial";
                    DIMENSIONS1611.TextFont.CharSet = 162;
                    DIMENSIONS1611.Value = @"";

                    WEIGHT1611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 76, 183, 81, false);
                    WEIGHT1611.Name = "WEIGHT1611";
                    WEIGHT1611.DrawStyle = DrawStyleConstants.vbSolid;
                    WEIGHT1611.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEIGHT1611.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WEIGHT1611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WEIGHT1611.TextFont.Name = "Arial";
                    WEIGHT1611.TextFont.CharSet = 162;
                    WEIGHT1611.Value = @"";

                    PRICE1611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 76, 211, 81, false);
                    PRICE1611.Name = "PRICE1611";
                    PRICE1611.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE1611.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE1611.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRICE1611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICE1611.TextFont.Name = "Arial";
                    PRICE1611.TextFont.CharSet = 162;
                    PRICE1611.Value = @"";

                    DESCRIPTION1611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 76, 257, 81, false);
                    DESCRIPTION1611.Name = "DESCRIPTION1611";
                    DESCRIPTION1611.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION1611.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION1611.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION1611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION1611.TextFont.Name = "Arial";
                    DESCRIPTION1611.TextFont.CharSet = 162;
                    DESCRIPTION1611.Value = @"";

                    COUNT1711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 81, 21, 86, false);
                    COUNT1711.Name = "COUNT1711";
                    COUNT1711.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT1711.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT1711.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT1711.TextFont.Name = "Arial";
                    COUNT1711.TextFont.CharSet = 162;
                    COUNT1711.Value = @"8";

                    MATERIALNAME7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 81, 103, 86, false);
                    MATERIALNAME7.Name = "MATERIALNAME7";
                    MATERIALNAME7.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME7.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME7.TextFont.Name = "Arial";
                    MATERIALNAME7.TextFont.CharSet = 162;
                    MATERIALNAME7.Value = @"";

                    AMOUNT7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 81, 127, 86, false);
                    AMOUNT7.Name = "AMOUNT7";
                    AMOUNT7.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT7.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT7.TextFont.Name = "Arial";
                    AMOUNT7.TextFont.CharSet = 162;
                    AMOUNT7.Value = @"";

                    DIMENSIONS1711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 81, 155, 86, false);
                    DIMENSIONS1711.Name = "DIMENSIONS1711";
                    DIMENSIONS1711.DrawStyle = DrawStyleConstants.vbSolid;
                    DIMENSIONS1711.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIMENSIONS1711.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIMENSIONS1711.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIMENSIONS1711.TextFont.Name = "Arial";
                    DIMENSIONS1711.TextFont.CharSet = 162;
                    DIMENSIONS1711.Value = @"";

                    WEIGHT1711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 81, 183, 86, false);
                    WEIGHT1711.Name = "WEIGHT1711";
                    WEIGHT1711.DrawStyle = DrawStyleConstants.vbSolid;
                    WEIGHT1711.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEIGHT1711.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WEIGHT1711.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WEIGHT1711.TextFont.Name = "Arial";
                    WEIGHT1711.TextFont.CharSet = 162;
                    WEIGHT1711.Value = @"";

                    PRICE1711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 81, 211, 86, false);
                    PRICE1711.Name = "PRICE1711";
                    PRICE1711.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE1711.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE1711.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRICE1711.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICE1711.TextFont.Name = "Arial";
                    PRICE1711.TextFont.CharSet = 162;
                    PRICE1711.Value = @"";

                    DESCRIPTION1711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 81, 257, 86, false);
                    DESCRIPTION1711.Name = "DESCRIPTION1711";
                    DESCRIPTION1711.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION1711.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION1711.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION1711.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION1711.TextFont.Name = "Arial";
                    DESCRIPTION1711.TextFont.CharSet = 162;
                    DESCRIPTION1711.Value = @"";

                    COUNT1811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 86, 21, 91, false);
                    COUNT1811.Name = "COUNT1811";
                    COUNT1811.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT1811.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT1811.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT1811.TextFont.Name = "Arial";
                    COUNT1811.TextFont.CharSet = 162;
                    COUNT1811.Value = @"9";

                    MATERIALNAME8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 86, 103, 91, false);
                    MATERIALNAME8.Name = "MATERIALNAME8";
                    MATERIALNAME8.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME8.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME8.TextFont.Name = "Arial";
                    MATERIALNAME8.TextFont.CharSet = 162;
                    MATERIALNAME8.Value = @"";

                    AMOUNT8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 86, 127, 91, false);
                    AMOUNT8.Name = "AMOUNT8";
                    AMOUNT8.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT8.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT8.TextFont.Name = "Arial";
                    AMOUNT8.TextFont.CharSet = 162;
                    AMOUNT8.Value = @"";

                    DIMENSIONS1811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 86, 155, 91, false);
                    DIMENSIONS1811.Name = "DIMENSIONS1811";
                    DIMENSIONS1811.DrawStyle = DrawStyleConstants.vbSolid;
                    DIMENSIONS1811.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIMENSIONS1811.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIMENSIONS1811.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIMENSIONS1811.TextFont.Name = "Arial";
                    DIMENSIONS1811.TextFont.CharSet = 162;
                    DIMENSIONS1811.Value = @"";

                    WEIGHT1811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 86, 183, 91, false);
                    WEIGHT1811.Name = "WEIGHT1811";
                    WEIGHT1811.DrawStyle = DrawStyleConstants.vbSolid;
                    WEIGHT1811.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEIGHT1811.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WEIGHT1811.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WEIGHT1811.TextFont.Name = "Arial";
                    WEIGHT1811.TextFont.CharSet = 162;
                    WEIGHT1811.Value = @"";

                    PRICE1811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 86, 211, 91, false);
                    PRICE1811.Name = "PRICE1811";
                    PRICE1811.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE1811.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE1811.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRICE1811.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICE1811.TextFont.Name = "Arial";
                    PRICE1811.TextFont.CharSet = 162;
                    PRICE1811.Value = @"";

                    DESCRIPTION1811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 86, 257, 91, false);
                    DESCRIPTION1811.Name = "DESCRIPTION1811";
                    DESCRIPTION1811.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION1811.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION1811.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION1811.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION1811.TextFont.Name = "Arial";
                    DESCRIPTION1811.TextFont.CharSet = 162;
                    DESCRIPTION1811.Value = @"";

                    COUNT1911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 91, 21, 96, false);
                    COUNT1911.Name = "COUNT1911";
                    COUNT1911.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT1911.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT1911.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT1911.TextFont.Name = "Arial";
                    COUNT1911.TextFont.CharSet = 162;
                    COUNT1911.Value = @"10";

                    MATERIALNAME9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 91, 103, 96, false);
                    MATERIALNAME9.Name = "MATERIALNAME9";
                    MATERIALNAME9.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME9.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME9.TextFont.Name = "Arial";
                    MATERIALNAME9.TextFont.CharSet = 162;
                    MATERIALNAME9.Value = @"";

                    AMOUNT9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 91, 127, 96, false);
                    AMOUNT9.Name = "AMOUNT9";
                    AMOUNT9.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT9.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT9.TextFont.Name = "Arial";
                    AMOUNT9.TextFont.CharSet = 162;
                    AMOUNT9.Value = @"";

                    DIMENSIONS1911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 91, 155, 96, false);
                    DIMENSIONS1911.Name = "DIMENSIONS1911";
                    DIMENSIONS1911.DrawStyle = DrawStyleConstants.vbSolid;
                    DIMENSIONS1911.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIMENSIONS1911.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIMENSIONS1911.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIMENSIONS1911.TextFont.Name = "Arial";
                    DIMENSIONS1911.TextFont.CharSet = 162;
                    DIMENSIONS1911.Value = @"";

                    WEIGHT1911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 91, 183, 96, false);
                    WEIGHT1911.Name = "WEIGHT1911";
                    WEIGHT1911.DrawStyle = DrawStyleConstants.vbSolid;
                    WEIGHT1911.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEIGHT1911.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WEIGHT1911.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WEIGHT1911.TextFont.Name = "Arial";
                    WEIGHT1911.TextFont.CharSet = 162;
                    WEIGHT1911.Value = @"";

                    PRICE1911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 91, 211, 96, false);
                    PRICE1911.Name = "PRICE1911";
                    PRICE1911.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE1911.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE1911.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRICE1911.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICE1911.TextFont.Name = "Arial";
                    PRICE1911.TextFont.CharSet = 162;
                    PRICE1911.Value = @"";

                    DESCRIPTION1911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 91, 257, 96, false);
                    DESCRIPTION1911.Name = "DESCRIPTION1911";
                    DESCRIPTION1911.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION1911.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION1911.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION1911.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION1911.TextFont.Name = "Arial";
                    DESCRIPTION1911.TextFont.CharSet = 162;
                    DESCRIPTION1911.Value = @"";

                    COUNT1021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 96, 21, 101, false);
                    COUNT1021.Name = "COUNT1021";
                    COUNT1021.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT1021.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT1021.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT1021.TextFont.Name = "Arial";
                    COUNT1021.TextFont.CharSet = 162;
                    COUNT1021.Value = @"11";

                    MATERIALNAME10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 96, 103, 101, false);
                    MATERIALNAME10.Name = "MATERIALNAME10";
                    MATERIALNAME10.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME10.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME10.TextFont.Name = "Arial";
                    MATERIALNAME10.TextFont.CharSet = 162;
                    MATERIALNAME10.Value = @"";

                    AMOUNT10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 96, 127, 101, false);
                    AMOUNT10.Name = "AMOUNT10";
                    AMOUNT10.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT10.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT10.TextFont.Name = "Arial";
                    AMOUNT10.TextFont.CharSet = 162;
                    AMOUNT10.Value = @"";

                    DIMENSIONS1021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 96, 155, 101, false);
                    DIMENSIONS1021.Name = "DIMENSIONS1021";
                    DIMENSIONS1021.DrawStyle = DrawStyleConstants.vbSolid;
                    DIMENSIONS1021.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIMENSIONS1021.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIMENSIONS1021.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIMENSIONS1021.TextFont.Name = "Arial";
                    DIMENSIONS1021.TextFont.CharSet = 162;
                    DIMENSIONS1021.Value = @"";

                    WEIGHT1021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 96, 183, 101, false);
                    WEIGHT1021.Name = "WEIGHT1021";
                    WEIGHT1021.DrawStyle = DrawStyleConstants.vbSolid;
                    WEIGHT1021.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEIGHT1021.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WEIGHT1021.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WEIGHT1021.TextFont.Name = "Arial";
                    WEIGHT1021.TextFont.CharSet = 162;
                    WEIGHT1021.Value = @"";

                    PRICE1021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 96, 211, 101, false);
                    PRICE1021.Name = "PRICE1021";
                    PRICE1021.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE1021.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE1021.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRICE1021.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICE1021.TextFont.Name = "Arial";
                    PRICE1021.TextFont.CharSet = 162;
                    PRICE1021.Value = @"";

                    DESCRIPTION1021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 96, 257, 101, false);
                    DESCRIPTION1021.Name = "DESCRIPTION1021";
                    DESCRIPTION1021.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION1021.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION1021.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION1021.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION1021.TextFont.Name = "Arial";
                    DESCRIPTION1021.TextFont.CharSet = 162;
                    DESCRIPTION1021.Value = @"";

                    COUNT1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 101, 21, 106, false);
                    COUNT1121.Name = "COUNT1121";
                    COUNT1121.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT1121.TextFont.Name = "Arial";
                    COUNT1121.TextFont.CharSet = 162;
                    COUNT1121.Value = @"12";

                    MATERIALNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 101, 103, 106, false);
                    MATERIALNAME11.Name = "MATERIALNAME11";
                    MATERIALNAME11.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME11.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME11.TextFont.Name = "Arial";
                    MATERIALNAME11.TextFont.CharSet = 162;
                    MATERIALNAME11.Value = @"";

                    AMOUNT11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 101, 127, 106, false);
                    AMOUNT11.Name = "AMOUNT11";
                    AMOUNT11.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT11.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT11.TextFont.Name = "Arial";
                    AMOUNT11.TextFont.CharSet = 162;
                    AMOUNT11.Value = @"";

                    DIMENSIONS1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 101, 155, 106, false);
                    DIMENSIONS1121.Name = "DIMENSIONS1121";
                    DIMENSIONS1121.DrawStyle = DrawStyleConstants.vbSolid;
                    DIMENSIONS1121.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIMENSIONS1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIMENSIONS1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIMENSIONS1121.TextFont.Name = "Arial";
                    DIMENSIONS1121.TextFont.CharSet = 162;
                    DIMENSIONS1121.Value = @"";

                    WEIGHT1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 101, 183, 106, false);
                    WEIGHT1121.Name = "WEIGHT1121";
                    WEIGHT1121.DrawStyle = DrawStyleConstants.vbSolid;
                    WEIGHT1121.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEIGHT1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WEIGHT1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WEIGHT1121.TextFont.Name = "Arial";
                    WEIGHT1121.TextFont.CharSet = 162;
                    WEIGHT1121.Value = @"";

                    PRICE1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 101, 211, 106, false);
                    PRICE1121.Name = "PRICE1121";
                    PRICE1121.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE1121.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRICE1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICE1121.TextFont.Name = "Arial";
                    PRICE1121.TextFont.CharSet = 162;
                    PRICE1121.Value = @"";

                    DESCRIPTION1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 101, 257, 106, false);
                    DESCRIPTION1121.Name = "DESCRIPTION1121";
                    DESCRIPTION1121.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION1121.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION1121.TextFont.Name = "Arial";
                    DESCRIPTION1121.TextFont.CharSet = 162;
                    DESCRIPTION1121.Value = @"";

                    COUNT1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 106, 21, 111, false);
                    COUNT1221.Name = "COUNT1221";
                    COUNT1221.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT1221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT1221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT1221.TextFont.Name = "Arial";
                    COUNT1221.TextFont.CharSet = 162;
                    COUNT1221.Value = @"13";

                    MATERIALNAME12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 106, 103, 111, false);
                    MATERIALNAME12.Name = "MATERIALNAME12";
                    MATERIALNAME12.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME12.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME12.TextFont.Name = "Arial";
                    MATERIALNAME12.TextFont.CharSet = 162;
                    MATERIALNAME12.Value = @"";

                    AMOUNT12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 106, 127, 111, false);
                    AMOUNT12.Name = "AMOUNT12";
                    AMOUNT12.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT12.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT12.TextFont.Name = "Arial";
                    AMOUNT12.TextFont.CharSet = 162;
                    AMOUNT12.Value = @"";

                    DIMENSIONS1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 106, 155, 111, false);
                    DIMENSIONS1221.Name = "DIMENSIONS1221";
                    DIMENSIONS1221.DrawStyle = DrawStyleConstants.vbSolid;
                    DIMENSIONS1221.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIMENSIONS1221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIMENSIONS1221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIMENSIONS1221.TextFont.Name = "Arial";
                    DIMENSIONS1221.TextFont.CharSet = 162;
                    DIMENSIONS1221.Value = @"";

                    WEIGHT1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 106, 183, 111, false);
                    WEIGHT1221.Name = "WEIGHT1221";
                    WEIGHT1221.DrawStyle = DrawStyleConstants.vbSolid;
                    WEIGHT1221.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEIGHT1221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WEIGHT1221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WEIGHT1221.TextFont.Name = "Arial";
                    WEIGHT1221.TextFont.CharSet = 162;
                    WEIGHT1221.Value = @"";

                    PRICE1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 106, 211, 111, false);
                    PRICE1221.Name = "PRICE1221";
                    PRICE1221.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE1221.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE1221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRICE1221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICE1221.TextFont.Name = "Arial";
                    PRICE1221.TextFont.CharSet = 162;
                    PRICE1221.Value = @"";

                    DESCRIPTION1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 106, 257, 111, false);
                    DESCRIPTION1221.Name = "DESCRIPTION1221";
                    DESCRIPTION1221.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION1221.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION1221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION1221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION1221.TextFont.Name = "Arial";
                    DESCRIPTION1221.TextFont.CharSet = 162;
                    DESCRIPTION1221.Value = @"";

                    COUNT1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 111, 21, 116, false);
                    COUNT1321.Name = "COUNT1321";
                    COUNT1321.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT1321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNT1321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNT1321.TextFont.Name = "Arial";
                    COUNT1321.TextFont.CharSet = 162;
                    COUNT1321.Value = @"14";

                    MATERIALNAME13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 111, 103, 116, false);
                    MATERIALNAME13.Name = "MATERIALNAME13";
                    MATERIALNAME13.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME13.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME13.TextFont.Name = "Arial";
                    MATERIALNAME13.TextFont.CharSet = 162;
                    MATERIALNAME13.Value = @"";

                    AMOUNT13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 111, 127, 116, false);
                    AMOUNT13.Name = "AMOUNT13";
                    AMOUNT13.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT13.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT13.TextFont.Name = "Arial";
                    AMOUNT13.TextFont.CharSet = 162;
                    AMOUNT13.Value = @"";

                    DIMENSIONS1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 111, 155, 116, false);
                    DIMENSIONS1321.Name = "DIMENSIONS1321";
                    DIMENSIONS1321.DrawStyle = DrawStyleConstants.vbSolid;
                    DIMENSIONS1321.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIMENSIONS1321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIMENSIONS1321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DIMENSIONS1321.TextFont.Name = "Arial";
                    DIMENSIONS1321.TextFont.CharSet = 162;
                    DIMENSIONS1321.Value = @"";

                    WEIGHT1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 111, 183, 116, false);
                    WEIGHT1321.Name = "WEIGHT1321";
                    WEIGHT1321.DrawStyle = DrawStyleConstants.vbSolid;
                    WEIGHT1321.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEIGHT1321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WEIGHT1321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WEIGHT1321.TextFont.Name = "Arial";
                    WEIGHT1321.TextFont.CharSet = 162;
                    WEIGHT1321.Value = @"";

                    PRICE1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 111, 211, 116, false);
                    PRICE1321.Name = "PRICE1321";
                    PRICE1321.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE1321.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE1321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRICE1321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICE1321.TextFont.Name = "Arial";
                    PRICE1321.TextFont.CharSet = 162;
                    PRICE1321.Value = @"";

                    DESCRIPTION1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 111, 257, 116, false);
                    DESCRIPTION1321.Name = "DESCRIPTION1321";
                    DESCRIPTION1321.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION1321.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION1321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION1321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION1321.TextFont.Name = "Arial";
                    DESCRIPTION1321.TextFont.CharSet = 162;
                    DESCRIPTION1321.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ORDERNO.CalcValue = @"";
                    NewField13111.CalcValue = NewField13111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    SENDERUNIT.CalcValue = @"";
                    NewField11.CalcValue = NewField11.Value;
                    REPORTNAME1.CalcValue = REPORTNAME1.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    RECEIVERUNIT.CalcValue = @"";
                    RECEIVERUNIT.PostFieldValueCalculation();
                    NewField12.CalcValue = NewField12.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField181.CalcValue = NewField181.Value;
                    TESLIM11.CalcValue = TESLIM11.Value;
                    TESLIM111.CalcValue = TESLIM111.Value;
                    NewField111121.CalcValue = NewField111121.Value;
                    NewField1121111.CalcValue = NewField1121111.Value;
                    NewField1121121.CalcValue = NewField1121121.Value;
                    NewField1121131.CalcValue = NewField1121131.Value;
                    NewField1121141.CalcValue = NewField1121141.Value;
                    DELIVERERUSER.CalcValue = @"";
                    DELIVEREDPERSON.CalcValue = @"";
                    NewField1111111.CalcValue = NewField1111111.Value;
                    NewField11111111.CalcValue = NewField11111111.Value;
                    COUNT111.CalcValue = COUNT111.Value;
                    MATERIALNAME0.CalcValue = @"";
                    AMOUNT0.CalcValue = @"";
                    DIMENSIONS111.CalcValue = @"";
                    WEIGHT111.CalcValue = @"";
                    PRICE111.CalcValue = @"";
                    DESCRIPTION111.CalcValue = @"";
                    COUNT1111.CalcValue = COUNT1111.Value;
                    MATERIALNAME1.CalcValue = @"";
                    AMOUNT1.CalcValue = @"";
                    DIMENSIONS1111.CalcValue = @"";
                    WEIGHT1111.CalcValue = @"";
                    PRICE1111.CalcValue = @"";
                    DESCRIPTION1111.CalcValue = @"";
                    COUNT1211.CalcValue = COUNT1211.Value;
                    MATERIALNAME2.CalcValue = @"";
                    AMOUNT2.CalcValue = @"";
                    DIMENSIONS1211.CalcValue = @"";
                    WEIGHT1211.CalcValue = @"";
                    PRICE1211.CalcValue = @"";
                    DESCRIPTION1211.CalcValue = @"";
                    COUNT1311.CalcValue = COUNT1311.Value;
                    MATERIALNAME3.CalcValue = @"";
                    AMOUNT3.CalcValue = @"";
                    DIMENSIONS1311.CalcValue = @"";
                    WEIGHT1311.CalcValue = @"";
                    PRICE1311.CalcValue = @"";
                    DESCRIPTION1311.CalcValue = @"";
                    COUNT1411.CalcValue = COUNT1411.Value;
                    MATERIALNAME4.CalcValue = @"";
                    AMOUNT4.CalcValue = @"";
                    DIMENSIONS1411.CalcValue = @"";
                    WEIGHT1411.CalcValue = @"";
                    PRICE1411.CalcValue = @"";
                    DESCRIPTION1411.CalcValue = @"";
                    COUNT1511.CalcValue = COUNT1511.Value;
                    MATERIALNAME5.CalcValue = @"";
                    AMOUNT5.CalcValue = @"";
                    DIMENSIONS1511.CalcValue = @"";
                    WEIGHT1511.CalcValue = @"";
                    PRICE1511.CalcValue = @"";
                    DESCRIPTION1511.CalcValue = @"";
                    COUNT1611.CalcValue = COUNT1611.Value;
                    MATERIALNAME6.CalcValue = @"";
                    AMOUNT6.CalcValue = @"";
                    DIMENSIONS1611.CalcValue = @"";
                    WEIGHT1611.CalcValue = @"";
                    PRICE1611.CalcValue = @"";
                    DESCRIPTION1611.CalcValue = @"";
                    COUNT1711.CalcValue = COUNT1711.Value;
                    MATERIALNAME7.CalcValue = @"";
                    AMOUNT7.CalcValue = @"";
                    DIMENSIONS1711.CalcValue = @"";
                    WEIGHT1711.CalcValue = @"";
                    PRICE1711.CalcValue = @"";
                    DESCRIPTION1711.CalcValue = @"";
                    COUNT1811.CalcValue = COUNT1811.Value;
                    MATERIALNAME8.CalcValue = @"";
                    AMOUNT8.CalcValue = @"";
                    DIMENSIONS1811.CalcValue = @"";
                    WEIGHT1811.CalcValue = @"";
                    PRICE1811.CalcValue = @"";
                    DESCRIPTION1811.CalcValue = @"";
                    COUNT1911.CalcValue = COUNT1911.Value;
                    MATERIALNAME9.CalcValue = @"";
                    AMOUNT9.CalcValue = @"";
                    DIMENSIONS1911.CalcValue = @"";
                    WEIGHT1911.CalcValue = @"";
                    PRICE1911.CalcValue = @"";
                    DESCRIPTION1911.CalcValue = @"";
                    COUNT1021.CalcValue = COUNT1021.Value;
                    MATERIALNAME10.CalcValue = @"";
                    AMOUNT10.CalcValue = @"";
                    DIMENSIONS1021.CalcValue = @"";
                    WEIGHT1021.CalcValue = @"";
                    PRICE1021.CalcValue = @"";
                    DESCRIPTION1021.CalcValue = @"";
                    COUNT1121.CalcValue = COUNT1121.Value;
                    MATERIALNAME11.CalcValue = @"";
                    AMOUNT11.CalcValue = @"";
                    DIMENSIONS1121.CalcValue = @"";
                    WEIGHT1121.CalcValue = @"";
                    PRICE1121.CalcValue = @"";
                    DESCRIPTION1121.CalcValue = @"";
                    COUNT1221.CalcValue = COUNT1221.Value;
                    MATERIALNAME12.CalcValue = @"";
                    AMOUNT12.CalcValue = @"";
                    DIMENSIONS1221.CalcValue = @"";
                    WEIGHT1221.CalcValue = @"";
                    PRICE1221.CalcValue = @"";
                    DESCRIPTION1221.CalcValue = @"";
                    COUNT1321.CalcValue = COUNT1321.Value;
                    MATERIALNAME13.CalcValue = @"";
                    AMOUNT13.CalcValue = @"";
                    DIMENSIONS1321.CalcValue = @"";
                    WEIGHT1321.CalcValue = @"";
                    PRICE1321.CalcValue = @"";
                    DESCRIPTION1321.CalcValue = @"";
                    return new TTReportObject[] { ORDERNO,NewField13111,NewField1111,NewField121,SENDERUNIT,NewField11,REPORTNAME1,NewField111,NewField1121,RECEIVERUNIT,NewField12,NewField131,NewField141,NewField151,NewField161,NewField171,NewField181,TESLIM11,TESLIM111,NewField111121,NewField1121111,NewField1121121,NewField1121131,NewField1121141,DELIVERERUSER,DELIVEREDPERSON,NewField1111111,NewField11111111,COUNT111,MATERIALNAME0,AMOUNT0,DIMENSIONS111,WEIGHT111,PRICE111,DESCRIPTION111,COUNT1111,MATERIALNAME1,AMOUNT1,DIMENSIONS1111,WEIGHT1111,PRICE1111,DESCRIPTION1111,COUNT1211,MATERIALNAME2,AMOUNT2,DIMENSIONS1211,WEIGHT1211,PRICE1211,DESCRIPTION1211,COUNT1311,MATERIALNAME3,AMOUNT3,DIMENSIONS1311,WEIGHT1311,PRICE1311,DESCRIPTION1311,COUNT1411,MATERIALNAME4,AMOUNT4,DIMENSIONS1411,WEIGHT1411,PRICE1411,DESCRIPTION1411,COUNT1511,MATERIALNAME5,AMOUNT5,DIMENSIONS1511,WEIGHT1511,PRICE1511,DESCRIPTION1511,COUNT1611,MATERIALNAME6,AMOUNT6,DIMENSIONS1611,WEIGHT1611,PRICE1611,DESCRIPTION1611,COUNT1711,MATERIALNAME7,AMOUNT7,DIMENSIONS1711,WEIGHT1711,PRICE1711,DESCRIPTION1711,COUNT1811,MATERIALNAME8,AMOUNT8,DIMENSIONS1811,WEIGHT1811,PRICE1811,DESCRIPTION1811,COUNT1911,MATERIALNAME9,AMOUNT9,DIMENSIONS1911,WEIGHT1911,PRICE1911,DESCRIPTION1911,COUNT1021,MATERIALNAME10,AMOUNT10,DIMENSIONS1021,WEIGHT1021,PRICE1021,DESCRIPTION1021,COUNT1121,MATERIALNAME11,AMOUNT11,DIMENSIONS1121,WEIGHT1121,PRICE1121,DESCRIPTION1121,COUNT1221,MATERIALNAME12,AMOUNT12,DIMENSIONS1221,WEIGHT1221,PRICE1221,DESCRIPTION1221,COUNT1321,MATERIALNAME13,AMOUNT13,DIMENSIONS1321,WEIGHT1321,PRICE1321,DESCRIPTION1321};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string objectID = ((TeslimTesellumBelgesiRepair)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                    TTObjectContext ctx = new TTObjectContext(true);
                    Repair repair = (Repair)ctx.GetObject(new Guid(objectID), typeof(Repair));
                    if (repair != null)
                    {
                        SENDERUNIT.CalcValue = TTObjectClasses.SystemParameter.GetHospital().MilitaryUnit.Name;
                        RECEIVERUNIT.CalcValue = repair.OwnerMilitaryUnit.Name;
                        MATERIALNAME0.CalcValue = repair.FixedAssetMaterialDefinition.FixedAssetDefinition.Name;
                        AMOUNT0.CalcValue = repair.FixedAssetMaterialDefinition.FixedAssetDefinition.DistributionTypeName;
                        string TeslimEden = "";
                        if (repair.DelivererUser != null)
                        {
                            TeslimEden+=(repair.DelivererUser.Name!=null)?repair.DelivererUser.Name+"\n":"";
                            TeslimEden += (repair.DelivererUser.MilitaryClass != null) ? repair.DelivererUser.MilitaryClass.ShortName.ToString() : ""; 
                            TeslimEden += (repair.DelivererUser.Rank != null) ? repair.DelivererUser.Rank + "\n" : "";
                            



                        }
                        //DELIVERERUSER.CalcValue = repair.DelivererUser.Name + "\n" + repair.DelivererUser.Rank + "\n"
                        //    + TTObjectClasses.Common.GetEnumValueDefOfEnumValue(repair.DelivererUser.Title).DisplayText.ToString();
                        DELIVERERUSER.CalcValue = TeslimEden;
                        DELIVEREDPERSON.CalcValue = repair.DeliveredPerson;
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

        public TeslimTesellumBelgesiRepair()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "TESLIMTESELLUMBELGESIREPAIR";
            Caption = "Teslim Tesellüm Belgesi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 25;
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