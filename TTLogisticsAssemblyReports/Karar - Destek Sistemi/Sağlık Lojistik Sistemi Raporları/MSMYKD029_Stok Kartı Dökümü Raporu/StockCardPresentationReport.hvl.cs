
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
    /// Stok Kartı Dökümü Raporu
    /// </summary>
    public partial class StockCardPresentationReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? STOCKCARDID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? TERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public StockCardPresentationReport MyParentReport
            {
                get { return (StockCardPresentationReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NATOStockNO { get {return Header().NATOStockNO;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1132 { get {return Header().NewField1132;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField NewField111411 { get {return Header().NewField111411;} }
            public TTReportField NewField111412 { get {return Header().NewField111412;} }
            public TTReportField NewField1214111 { get {return Header().NewField1214111;} }
            public TTReportField NewField11114121 { get {return Header().NewField11114121;} }
            public TTReportField NewField11114122 { get {return Header().NewField11114122;} }
            public TTReportField NewField122141111 { get {return Header().NewField122141111;} }
            public TTReportField NewField1111141221 { get {return Header().NewField1111141221;} }
            public TTReportField NewField1241 { get {return Header().NewField1241;} }
            public TTReportField STOCKCARDNAME { get {return Header().STOCKCARDNAME;} }
            public TTReportField UnitPrice { get {return Header().UnitPrice;} }
            public TTReportField MaterialCode { get {return Header().MaterialCode;} }
            public TTReportField RelatedMaterials { get {return Header().RelatedMaterials;} }
            public TTReportField MainClassName { get {return Header().MainClassName;} }
            public TTReportField ClassName { get {return Header().ClassName;} }
            public TTReportField GuideCard { get {return Header().GuideCard;} }
            public TTReportField DistributionType { get {return Header().DistributionType;} }
            public TTReportField NewOrderNO { get {return Header().NewOrderNO;} }
            public TTReportField OldOrderNO { get {return Header().OldOrderNO;} }
            public TTReportField CardStatus { get {return Header().CardStatus;} }
            public TTReportField OBJECTID { get {return Header().OBJECTID;} }
            public TTReportField TermID { get {return Header().TermID;} }
            public TTReportField BeforeYear { get {return Header().BeforeYear;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[2];
                list[0] = new TTReportNqlData<StockCard.GetStockCardInfoQuery_Class>("GetStockCardInfoQuery", StockCard.GetStockCardInfoQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID)));
                list[1] = new TTReportNqlData<StockCard.GetOldOrderNoQuery_Class>("GetOldOrderNoQuery", StockCard.GetOldOrderNoQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TERMID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public StockCardPresentationReport MyParentReport
                {
                    get { return (StockCardPresentationReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NATOStockNO;
                public TTReportField NewField15;
                public TTReportField NewField151;
                public TTReportField NewField131;
                public TTReportField NewField1131;
                public TTReportField NewField11311;
                public TTReportField NewField111;
                public TTReportField NewField1132;
                public TTReportField NewField141;
                public TTReportField NewField1141;
                public TTReportField NewField142;
                public TTReportField NewField11411;
                public TTReportField NewField111411;
                public TTReportField NewField111412;
                public TTReportField NewField1214111;
                public TTReportField NewField11114121;
                public TTReportField NewField11114122;
                public TTReportField NewField122141111;
                public TTReportField NewField1111141221;
                public TTReportField NewField1241;
                public TTReportField STOCKCARDNAME;
                public TTReportField UnitPrice;
                public TTReportField MaterialCode;
                public TTReportField RelatedMaterials;
                public TTReportField MainClassName;
                public TTReportField ClassName;
                public TTReportField GuideCard;
                public TTReportField DistributionType;
                public TTReportField NewOrderNO;
                public TTReportField OldOrderNO;
                public TTReportField CardStatus;
                public TTReportField OBJECTID;
                public TTReportField TermID;
                public TTReportField BeforeYear; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 72;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 46, 11, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Stok Nu.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 0, 119, 11, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Malzeme Adı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 0, 144, 11, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.TextFont.Size = 8;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Birim Fiyatı";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 0, 190, 11, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.TextFont.Size = 8;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Malzeme Kodu";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 11, 89, 33, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.TextFont.Size = 8;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Bağlı Malzemeler";

                    NATOStockNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 5, 45, 10, false);
                    NATOStockNO.Name = "NATOStockNO";
                    NATOStockNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOStockNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOStockNO.TextFont.CharSet = 162;
                    NATOStockNO.Value = @"{#NATOSTOCKNO!GetStockCardInfoQuery#}";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 11, 144, 22, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.TextFont.Size = 8;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Ana Sınıfı";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 22, 144, 33, false);
                    NewField151.Name = "NewField151";
                    NewField151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151.TextFont.Size = 8;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"Sınıfı";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 11, 190, 22, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.TextFont.Size = 8;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Ölçü Birimi";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 22, 167, 33, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.TextFont.Size = 8;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Sıra Nu.";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 22, 190, 33, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11311.TextFont.Size = 8;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"Önceki Sıra Nu.";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 33, 144, 44, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.TextFont.Size = 8;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Bilgi Kartı";

                    NewField1132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 33, 190, 44, false);
                    NewField1132.Name = "NewField1132";
                    NewField1132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1132.TextFont.Size = 8;
                    NewField1132.TextFont.Bold = true;
                    NewField1132.TextFont.CharSet = 162;
                    NewField1132.Value = @"Kart Statüsü";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 44, 89, 52, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.TextFont.Size = 8;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"Giren ve Çıkan";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 44, 125, 52, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141.TextFont.Size = 8;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"Depo Mevcudu";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 44, 144, 61, false);
                    NewField142.Name = "NewField142";
                    NewField142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField142.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField142.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField142.MultiLine = EvetHayirEnum.ehEvet;
                    NewField142.TextFont.Size = 8;
                    NewField142.TextFont.Bold = true;
                    NewField142.TextFont.CharSet = 162;
                    NewField142.Value = @"Muvakkaten
Verilen";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 52, 15, 61, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.TextFont.Size = 8;
                    NewField11411.TextFont.Bold = true;
                    NewField11411.TextFont.CharSet = 162;
                    NewField11411.Value = @"Tarih";

                    NewField111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 52, 30, 61, false);
                    NewField111411.Name = "NewField111411";
                    NewField111411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111411.TextFont.Size = 8;
                    NewField111411.TextFont.Bold = true;
                    NewField111411.TextFont.CharSet = 162;
                    NewField111411.Value = @"Giren Miktar";

                    NewField111412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 52, 45, 61, false);
                    NewField111412.Name = "NewField111412";
                    NewField111412.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111412.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111412.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111412.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111412.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111412.TextFont.Size = 8;
                    NewField111412.TextFont.Bold = true;
                    NewField111412.TextFont.CharSet = 162;
                    NewField111412.Value = @"Belge Kayıt Nu.";

                    NewField1214111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 52, 59, 61, false);
                    NewField1214111.Name = "NewField1214111";
                    NewField1214111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1214111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1214111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1214111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1214111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1214111.TextFont.Size = 8;
                    NewField1214111.TextFont.Bold = true;
                    NewField1214111.TextFont.CharSet = 162;
                    NewField1214111.Value = @"İlk
Verilen";

                    NewField11114121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 52, 74, 61, false);
                    NewField11114121.Name = "NewField11114121";
                    NewField11114121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11114121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11114121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11114121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11114121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11114121.TextFont.Size = 8;
                    NewField11114121.TextFont.Bold = true;
                    NewField11114121.TextFont.CharSet = 162;
                    NewField11114121.Value = @"İkmalen Verilen";

                    NewField11114122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 52, 89, 61, false);
                    NewField11114122.Name = "NewField11114122";
                    NewField11114122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11114122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11114122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11114122.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11114122.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11114122.TextFont.Size = 8;
                    NewField11114122.TextFont.Bold = true;
                    NewField11114122.TextFont.CharSet = 162;
                    NewField11114122.Value = @"Naklen
Verilen";

                    NewField122141111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 52, 107, 61, false);
                    NewField122141111.Name = "NewField122141111";
                    NewField122141111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122141111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122141111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122141111.TextFont.Size = 8;
                    NewField122141111.TextFont.Bold = true;
                    NewField122141111.TextFont.CharSet = 162;
                    NewField122141111.Value = @"Yeni";

                    NewField1111141221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 52, 125, 61, false);
                    NewField1111141221.Name = "NewField1111141221";
                    NewField1111141221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111141221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111141221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111141221.TextFont.Size = 8;
                    NewField1111141221.TextFont.Bold = true;
                    NewField1111141221.TextFont.CharSet = 162;
                    NewField1111141221.Value = @"Kullanılmış";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 44, 190, 61, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1241.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1241.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1241.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1241.TextFont.Size = 8;
                    NewField1241.TextFont.Bold = true;
                    NewField1241.TextFont.CharSet = 162;
                    NewField1241.Value = @"Kime
Verildiği";

                    STOCKCARDNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 5, 118, 10, false);
                    STOCKCARDNAME.Name = "STOCKCARDNAME";
                    STOCKCARDNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARDNAME.WordBreak = EvetHayirEnum.ehEvet;
                    STOCKCARDNAME.TextFont.CharSet = 162;
                    STOCKCARDNAME.Value = @"{#STOCKCARDNAME#}";

                    UnitPrice = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 5, 143, 10, false);
                    UnitPrice.Name = "UnitPrice";
                    UnitPrice.FieldType = ReportFieldTypeEnum.ftVariable;
                    UnitPrice.TextFormat = @"#,##0.#0";
                    UnitPrice.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UnitPrice.TextFont.CharSet = 162;
                    UnitPrice.Value = @"";

                    MaterialCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 5, 189, 10, false);
                    MaterialCode.Name = "MaterialCode";
                    MaterialCode.FieldType = ReportFieldTypeEnum.ftVariable;
                    MaterialCode.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MaterialCode.TextFont.CharSet = 162;
                    MaterialCode.Value = @"";

                    RelatedMaterials = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 16, 88, 32, false);
                    RelatedMaterials.Name = "RelatedMaterials";
                    RelatedMaterials.FieldType = ReportFieldTypeEnum.ftVariable;
                    RelatedMaterials.MultiLine = EvetHayirEnum.ehEvet;
                    RelatedMaterials.WordBreak = EvetHayirEnum.ehEvet;
                    RelatedMaterials.ExpandTabs = EvetHayirEnum.ehEvet;
                    RelatedMaterials.Value = @"";

                    MainClassName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 16, 143, 21, false);
                    MainClassName.Name = "MainClassName";
                    MainClassName.FieldType = ReportFieldTypeEnum.ftVariable;
                    MainClassName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MainClassName.WordBreak = EvetHayirEnum.ehEvet;
                    MainClassName.Value = @"{#MAINCLASSNAME!GetStockCardInfoQuery#}";

                    ClassName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 27, 143, 32, false);
                    ClassName.Name = "ClassName";
                    ClassName.FieldType = ReportFieldTypeEnum.ftVariable;
                    ClassName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ClassName.WordBreak = EvetHayirEnum.ehEvet;
                    ClassName.Value = @"{#CLASSNAME!GetStockCardInfoQuery#}";

                    GuideCard = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 38, 124, 43, false);
                    GuideCard.Name = "GuideCard";
                    GuideCard.FieldType = ReportFieldTypeEnum.ftVariable;
                    GuideCard.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GuideCard.NoClip = EvetHayirEnum.ehEvet;
                    GuideCard.Value = @"";

                    DistributionType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 16, 189, 21, false);
                    DistributionType.Name = "DistributionType";
                    DistributionType.FieldType = ReportFieldTypeEnum.ftVariable;
                    DistributionType.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DistributionType.WordBreak = EvetHayirEnum.ehEvet;
                    DistributionType.Value = @"{#DISTRIBUTIONTYPE!GetStockCardInfoQuery#}";

                    NewOrderNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 27, 166, 32, false);
                    NewOrderNO.Name = "NewOrderNO";
                    NewOrderNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewOrderNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewOrderNO.TextFont.CharSet = 162;
                    NewOrderNO.Value = @"{#OLDORDERNO!GetStockCardInfoQuery#}";

                    OldOrderNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 27, 189, 32, false);
                    OldOrderNO.Name = "OldOrderNO";
                    OldOrderNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    OldOrderNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldOrderNO.TextFont.CharSet = 162;
                    OldOrderNO.Value = @"{#CARDORDERNO!GetOldOrderNoQuery#}";

                    CardStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 38, 189, 43, false);
                    CardStatus.Name = "CardStatus";
                    CardStatus.FieldType = ReportFieldTypeEnum.ftVariable;
                    CardStatus.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CardStatus.WordBreak = EvetHayirEnum.ehEvet;
                    CardStatus.ObjectDefName = "StockCardStatusEnum";
                    CardStatus.DataMember = "DISPLAYTEXT";
                    CardStatus.Value = @"{#STATUS!GetStockCardInfoQuery#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 4, 242, 9, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    TermID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 10, 242, 15, false);
                    TermID.Name = "TermID";
                    TermID.Visible = EvetHayirEnum.ehHayir;
                    TermID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TermID.ObjectDefName = "AccountingTerm";
                    TermID.DataMember = "STARTDATE";
                    TermID.Value = @"{@TERMID@}";

                    BeforeYear = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 16, 242, 21, false);
                    BeforeYear.Name = "BeforeYear";
                    BeforeYear.Visible = EvetHayirEnum.ehHayir;
                    BeforeYear.FieldType = ReportFieldTypeEnum.ftVariable;
                    BeforeYear.TextFormat = @"dd/MM/yyyy";
                    BeforeYear.Value = @"{%TermID%}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockCard.GetStockCardInfoQuery_Class dataset_GetStockCardInfoQuery = ParentGroup.rsGroup.GetCurrentRecord<StockCard.GetStockCardInfoQuery_Class>(0);
                    StockCard.GetOldOrderNoQuery_Class dataset_GetOldOrderNoQuery = ParentGroup.rsGroup.GetCurrentRecord<StockCard.GetOldOrderNoQuery_Class>(1);
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NATOStockNO.CalcValue = (dataset_GetStockCardInfoQuery != null ? Globals.ToStringCore(dataset_GetStockCardInfoQuery.NATOStockNO) : "");
                    NewField15.CalcValue = NewField15.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1132.CalcValue = NewField1132.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField111411.CalcValue = NewField111411.Value;
                    NewField111412.CalcValue = NewField111412.Value;
                    NewField1214111.CalcValue = NewField1214111.Value;
                    NewField11114121.CalcValue = NewField11114121.Value;
                    NewField11114122.CalcValue = NewField11114122.Value;
                    NewField122141111.CalcValue = NewField122141111.Value;
                    NewField1111141221.CalcValue = NewField1111141221.Value;
                    NewField1241.CalcValue = NewField1241.Value;
                    STOCKCARDNAME.CalcValue = (dataset_GetStockCardInfoQuery != null ? Globals.ToStringCore(dataset_GetStockCardInfoQuery.Stockcardname) : "");
                    UnitPrice.CalcValue = @"";
                    MaterialCode.CalcValue = @"";
                    RelatedMaterials.CalcValue = @"";
                    MainClassName.CalcValue = (dataset_GetStockCardInfoQuery != null ? Globals.ToStringCore(dataset_GetStockCardInfoQuery.Mainclassname) : "");
                    ClassName.CalcValue = (dataset_GetStockCardInfoQuery != null ? Globals.ToStringCore(dataset_GetStockCardInfoQuery.Classname) : "");
                    GuideCard.CalcValue = @"";
                    DistributionType.CalcValue = (dataset_GetStockCardInfoQuery != null ? Globals.ToStringCore(dataset_GetStockCardInfoQuery.DistributionType) : "");
                    NewOrderNO.CalcValue = (dataset_GetStockCardInfoQuery != null ? Globals.ToStringCore(dataset_GetStockCardInfoQuery.Oldorderno) : "");
                    OldOrderNO.CalcValue = (dataset_GetOldOrderNoQuery != null ? Globals.ToStringCore(dataset_GetOldOrderNoQuery.CardOrderNo) : "");
                    CardStatus.CalcValue = (dataset_GetStockCardInfoQuery != null ? Globals.ToStringCore(dataset_GetStockCardInfoQuery.Status) : "");
                    CardStatus.PostFieldValueCalculation();
                    OBJECTID.CalcValue = (dataset_GetStockCardInfoQuery != null ? Globals.ToStringCore(dataset_GetStockCardInfoQuery.ObjectID) : "");
                    TermID.CalcValue = MyParentReport.RuntimeParameters.TERMID.ToString();
                    TermID.PostFieldValueCalculation();
                    BeforeYear.CalcValue = MyParentReport.PARTA.TermID.CalcValue;
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField13,NewField14,NATOStockNO,NewField15,NewField151,NewField131,NewField1131,NewField11311,NewField111,NewField1132,NewField141,NewField1141,NewField142,NewField11411,NewField111411,NewField111412,NewField1214111,NewField11114121,NewField11114122,NewField122141111,NewField1111141221,NewField1241,STOCKCARDNAME,UnitPrice,MaterialCode,RelatedMaterials,MainClassName,ClassName,GuideCard,DistributionType,NewOrderNO,OldOrderNO,CardStatus,OBJECTID,TermID,BeforeYear};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            StockCard stockCard = (StockCard)ctx.GetObject(new Guid(this.MyParentReport.RuntimeParameters.STOCKCARDID.ToString()), typeof(StockCard));
            int materialCount = stockCard.Materials.Count;
            if(materialCount > 0)
            {
                this.RelatedMaterials.CalcValue = stockCard.Materials[0].Name;
                if(stockCard.Materials[0].Stocks.Count > 0)
                    if(stockCard.Materials[0].Stocks[0].StockTransactions.Count > 0)
                    UnitPrice.CalcValue = stockCard.Materials[0].Stocks[0].StockTransactions[0].UnitPrice.ToString();
                
                if(materialCount > 1)
                {
                    for(int i = 1; i < materialCount; i++)
                    {
                        this.RelatedMaterials.CalcValue = this.RelatedMaterials.CalcValue + ", " + stockCard.Materials[i].Name;
                    }
                }
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public StockCardPresentationReport MyParentReport
                {
                    get { return (StockCardPresentationReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 22;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public StockCardPresentationReport MyParentReport
            {
                get { return (StockCardPresentationReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField FirstCensusYear { get {return Header().FirstCensusYear;} }
            public TTReportField FirstTotal { get {return Header().FirstTotal;} }
            public TTReportField FirstInheld { get {return Header().FirstInheld;} }
            public TTReportField FirstUsed { get {return Header().FirstUsed;} }
            public TTReportField FirstConsigned { get {return Header().FirstConsigned;} }
            public TTReportField NewField111311111 { get {return Header().NewField111311111;} }
            public TTReportField ISFIRSTTERM { get {return Header().ISFIRSTTERM;} }
            public TTReportField CensusYear { get {return Footer().CensusYear;} }
            public TTReportField Total { get {return Footer().Total;} }
            public TTReportField OldInheld { get {return Footer().OldInheld;} }
            public TTReportField OldUsed { get {return Footer().OldUsed;} }
            public TTReportField OldConsigned { get {return Footer().OldConsigned;} }
            public TTReportField NewField11111311 { get {return Footer().NewField11111311;} }
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
                list[0] = new TTReportNqlData<StockCard.GetStockCardPreReportQuery_Class>("GetStockCardPreReportQuery", StockCard.GetStockCardPreReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TERMID)));
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
                public StockCardPresentationReport MyParentReport
                {
                    get { return (StockCardPresentationReport)ParentReport; }
                }
                
                public TTReportField FirstCensusYear;
                public TTReportField FirstTotal;
                public TTReportField FirstInheld;
                public TTReportField FirstUsed;
                public TTReportField FirstConsigned;
                public TTReportField NewField111311111;
                public TTReportField ISFIRSTTERM; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    FirstCensusYear = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 30, 10, false);
                    FirstCensusYear.Name = "FirstCensusYear";
                    FirstCensusYear.ForeColor = System.Drawing.Color.Red;
                    FirstCensusYear.DrawStyle = DrawStyleConstants.vbSolid;
                    FirstCensusYear.FieldType = ReportFieldTypeEnum.ftVariable;
                    FirstCensusYear.TextFormat = @"dd/MM/yyyy";
                    FirstCensusYear.TextColor = System.Drawing.Color.Red;
                    FirstCensusYear.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FirstCensusYear.MultiLine = EvetHayirEnum.ehEvet;
                    FirstCensusYear.TextFont.Bold = true;
                    FirstCensusYear.TextFont.CharSet = 162;
                    FirstCensusYear.Value = @"{%PARTA.BeforeYear%}
İlk Giriş";

                    FirstTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 0, 89, 10, false);
                    FirstTotal.Name = "FirstTotal";
                    FirstTotal.ForeColor = System.Drawing.Color.Red;
                    FirstTotal.DrawStyle = DrawStyleConstants.vbSolid;
                    FirstTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    FirstTotal.CaseFormat = CaseFormatEnum.fcTitleCase;
                    FirstTotal.TextFormat = @"NUMBERTEXT";
                    FirstTotal.TextColor = System.Drawing.Color.Red;
                    FirstTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FirstTotal.TextFont.Bold = true;
                    FirstTotal.TextFont.CharSet = 162;
                    FirstTotal.Value = @"";

                    FirstInheld = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 0, 107, 10, false);
                    FirstInheld.Name = "FirstInheld";
                    FirstInheld.ForeColor = System.Drawing.Color.Red;
                    FirstInheld.DrawStyle = DrawStyleConstants.vbSolid;
                    FirstInheld.FieldType = ReportFieldTypeEnum.ftExpression;
                    FirstInheld.TextColor = System.Drawing.Color.Red;
                    FirstInheld.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FirstInheld.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FirstInheld.TextFont.Bold = true;
                    FirstInheld.TextFont.CharSet = 162;
                    FirstInheld.Value = @"{#ISFIRSTTERM#} == ""True"" ? {#INHELD#} : """"";

                    FirstUsed = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 0, 125, 10, false);
                    FirstUsed.Name = "FirstUsed";
                    FirstUsed.ForeColor = System.Drawing.Color.Red;
                    FirstUsed.DrawStyle = DrawStyleConstants.vbSolid;
                    FirstUsed.FieldType = ReportFieldTypeEnum.ftExpression;
                    FirstUsed.TextColor = System.Drawing.Color.Red;
                    FirstUsed.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FirstUsed.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FirstUsed.TextFont.Bold = true;
                    FirstUsed.TextFont.CharSet = 162;
                    FirstUsed.Value = @"{#ISFIRSTTERM#} == ""True"" ? {#USED#} : """"";

                    FirstConsigned = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 0, 144, 10, false);
                    FirstConsigned.Name = "FirstConsigned";
                    FirstConsigned.ForeColor = System.Drawing.Color.Red;
                    FirstConsigned.DrawStyle = DrawStyleConstants.vbSolid;
                    FirstConsigned.FieldType = ReportFieldTypeEnum.ftExpression;
                    FirstConsigned.TextColor = System.Drawing.Color.Red;
                    FirstConsigned.HorzAlign = HorizontalAlignmentEnum.haRight;
                    FirstConsigned.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FirstConsigned.TextFont.Bold = true;
                    FirstConsigned.TextFont.CharSet = 162;
                    FirstConsigned.Value = @"{#ISFIRSTTERM#} == ""True"" ? {#CONSIGNED#} : """"";

                    NewField111311111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 0, 190, 10, false);
                    NewField111311111.Name = "NewField111311111";
                    NewField111311111.ForeColor = System.Drawing.Color.Red;
                    NewField111311111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111311111.TextColor = System.Drawing.Color.Red;
                    NewField111311111.TextFont.Bold = true;
                    NewField111311111.TextFont.CharSet = 162;
                    NewField111311111.Value = @"";

                    ISFIRSTTERM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 0, 239, 5, false);
                    ISFIRSTTERM.Name = "ISFIRSTTERM";
                    ISFIRSTTERM.Visible = EvetHayirEnum.ehHayir;
                    ISFIRSTTERM.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISFIRSTTERM.Value = @"{#ISFIRSTTERM#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockCard.GetStockCardPreReportQuery_Class dataset_GetStockCardPreReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockCard.GetStockCardPreReportQuery_Class>(0);
                    FirstCensusYear.CalcValue = MyParentReport.PARTA.BeforeYear.FormattedValue + @"
İlk Giriş";
                    FirstTotal.CalcValue = @"";
                    NewField111311111.CalcValue = NewField111311111.Value;
                    ISFIRSTTERM.CalcValue = (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.IsFirstTerm) : "");
                    FirstInheld.CalcValue = (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.IsFirstTerm) : "") == "True" ? (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.Inheld) : "") : "";
                    FirstUsed.CalcValue = (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.IsFirstTerm) : "") == "True" ? (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.Used) : "") : "";
                    FirstConsigned.CalcValue = (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.IsFirstTerm) : "") == "True" ? (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.Consigned) : "") : "";
                    return new TTReportObject[] { FirstCensusYear,FirstTotal,NewField111311111,ISFIRSTTERM,FirstInheld,FirstUsed,FirstConsigned};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    if (ISFIRSTTERM.CalcValue == "True")
                        this.Visible = EvetHayirEnum.ehEvet;
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public StockCardPresentationReport MyParentReport
                {
                    get { return (StockCardPresentationReport)ParentReport; }
                }
                
                public TTReportField CensusYear;
                public TTReportField Total;
                public TTReportField OldInheld;
                public TTReportField OldUsed;
                public TTReportField OldConsigned;
                public TTReportField NewField11111311; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    RepeatCount = 0;
                    
                    CensusYear = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 30, 5, false);
                    CensusYear.Name = "CensusYear";
                    CensusYear.ForeColor = System.Drawing.Color.Red;
                    CensusYear.DrawStyle = DrawStyleConstants.vbSolid;
                    CensusYear.FieldType = ReportFieldTypeEnum.ftVariable;
                    CensusYear.TextFormat = @"dd/MM/yyyy";
                    CensusYear.TextColor = System.Drawing.Color.Red;
                    CensusYear.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CensusYear.TextFont.Bold = true;
                    CensusYear.TextFont.CharSet = 162;
                    CensusYear.Value = @"{%PARTA.BeforeYear%} Devir";

                    Total = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 0, 89, 5, false);
                    Total.Name = "Total";
                    Total.ForeColor = System.Drawing.Color.Red;
                    Total.DrawStyle = DrawStyleConstants.vbSolid;
                    Total.FieldType = ReportFieldTypeEnum.ftVariable;
                    Total.CaseFormat = CaseFormatEnum.fcTitleCase;
                    Total.TextFormat = @"NUMBERTEXT";
                    Total.TextColor = System.Drawing.Color.Red;
                    Total.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Total.TextFont.Bold = true;
                    Total.TextFont.CharSet = 162;
                    Total.Value = @"";

                    OldInheld = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 0, 107, 5, false);
                    OldInheld.Name = "OldInheld";
                    OldInheld.ForeColor = System.Drawing.Color.Red;
                    OldInheld.DrawStyle = DrawStyleConstants.vbSolid;
                    OldInheld.FieldType = ReportFieldTypeEnum.ftExpression;
                    OldInheld.TextColor = System.Drawing.Color.Red;
                    OldInheld.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OldInheld.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldInheld.TextFont.Bold = true;
                    OldInheld.TextFont.CharSet = 162;
                    OldInheld.Value = @"{#ISFIRSTTERM#} != ""True"" ? {#INHELD#} : """"";

                    OldUsed = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 0, 125, 5, false);
                    OldUsed.Name = "OldUsed";
                    OldUsed.ForeColor = System.Drawing.Color.Red;
                    OldUsed.DrawStyle = DrawStyleConstants.vbSolid;
                    OldUsed.FieldType = ReportFieldTypeEnum.ftExpression;
                    OldUsed.TextColor = System.Drawing.Color.Red;
                    OldUsed.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OldUsed.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldUsed.TextFont.Bold = true;
                    OldUsed.TextFont.CharSet = 162;
                    OldUsed.Value = @"{#ISFIRSTTERM#} != ""True"" ? {#USED#} : """"";

                    OldConsigned = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 0, 144, 5, false);
                    OldConsigned.Name = "OldConsigned";
                    OldConsigned.ForeColor = System.Drawing.Color.Red;
                    OldConsigned.DrawStyle = DrawStyleConstants.vbSolid;
                    OldConsigned.FieldType = ReportFieldTypeEnum.ftExpression;
                    OldConsigned.TextColor = System.Drawing.Color.Red;
                    OldConsigned.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OldConsigned.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OldConsigned.TextFont.Bold = true;
                    OldConsigned.TextFont.CharSet = 162;
                    OldConsigned.Value = @"{#ISFIRSTTERM#} != ""True"" ? {#CONSIGNED#} : """"";

                    NewField11111311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 0, 190, 5, false);
                    NewField11111311.Name = "NewField11111311";
                    NewField11111311.ForeColor = System.Drawing.Color.Red;
                    NewField11111311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111311.TextColor = System.Drawing.Color.Red;
                    NewField11111311.TextFont.Bold = true;
                    NewField11111311.TextFont.CharSet = 162;
                    NewField11111311.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockCard.GetStockCardPreReportQuery_Class dataset_GetStockCardPreReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockCard.GetStockCardPreReportQuery_Class>(0);
                    CensusYear.CalcValue = MyParentReport.PARTA.BeforeYear.FormattedValue + @" Devir";
                    Total.CalcValue = @"";
                    NewField11111311.CalcValue = NewField11111311.Value;
                    OldInheld.CalcValue = (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.IsFirstTerm) : "") != "True" ? (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.Inheld) : "") : "";
                    OldUsed.CalcValue = (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.IsFirstTerm) : "") != "True" ? (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.Used) : "") : "";
                    OldConsigned.CalcValue = (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.IsFirstTerm) : "") != "True" ? (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.Consigned) : "") : "";
                    return new TTReportObject[] { CensusYear,Total,NewField11111311,OldInheld,OldUsed,OldConsigned};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    if(OldInheld.CalcValue == "")
                PARTBGroup.oldInheld = 0;
            else
                PARTBGroup.oldInheld = Convert.ToDouble(this.OldInheld.CalcValue);
            
            if(OldUsed.CalcValue == "")
                PARTBGroup.oldUsed = 0;
            else
                PARTBGroup.oldUsed = Convert.ToDouble(this.OldUsed.CalcValue);
            
            if(OldConsigned.CalcValue == "")
                PARTBGroup.oldConsigned = 0;
            else
                PARTBGroup.oldConsigned = Convert.ToDouble(this.OldConsigned.CalcValue);
            
            this.Total.CalcValue = (PARTBGroup.oldInheld + PARTBGroup.oldUsed + PARTBGroup.oldConsigned).ToString();

            if (PARTBGroup.oldInheld + PARTBGroup.oldUsed + PARTBGroup.oldConsigned == 0)
                this.Visible = EvetHayirEnum.ehHayir;

            oldInheld = 0;
            oldUsed = 0;
            oldConsigned = 0;
#endregion PARTB FOOTER_Script
                }
            }

#region PARTB_Methods
            public static double oldInheld = 0, oldUsed = 0, oldConsigned = 0;
#endregion PARTB_Methods
        }

        public PARTBGroup PARTB;

        public partial class MAINSECONDGroup : TTReportGroup
        {
            public StockCardPresentationReport MyParentReport
            {
                get { return (StockCardPresentationReport)ParentReport; }
            }

            new public MAINSECONDGroupBody Body()
            {
                return (MAINSECONDGroupBody)_body;
            }
            public TTReportField TransactionDate { get {return Body().TransactionDate;} }
            public TTReportField AmountIn { get {return Body().AmountIn;} }
            public TTReportField RegistrationNO { get {return Body().RegistrationNO;} }
            public TTReportField ShortDescription { get {return Body().ShortDescription;} }
            public TTReportField AmountOut1 { get {return Body().AmountOut1;} }
            public TTReportField AmountOut2 { get {return Body().AmountOut2;} }
            public TTReportField New { get {return Body().New;} }
            public TTReportField Used { get {return Body().Used;} }
            public TTReportField Consigned { get {return Body().Consigned;} }
            public TTReportField ReplaceStore { get {return Body().ReplaceStore;} }
            public TTReportField InOut { get {return Body().InOut;} }
            public TTReportField Amount { get {return Body().Amount;} }
            public TTReportField MaintainLevelCode { get {return Body().MaintainLevelCode;} }
            public TTReportField StockLevelType { get {return Body().StockLevelType;} }
            public TTReportField MainStore { get {return Body().MainStore;} }
            public TTReportField STOCKACTIONID { get {return Body().STOCKACTIONID;} }
            public MAINSECONDGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINSECONDGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                StockCard.GetStockCardPreReportQuery_Class dataSet_GetStockCardPreReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockCard.GetStockCardPreReportQuery_Class>(0);    
                return new object[] {(dataSet_GetStockCardPreReportQuery==null ? null : dataSet_GetStockCardPreReportQuery.AccountingTerm)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINSECONDGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAINSECONDGroupBody : TTReportSection
            {
                public StockCardPresentationReport MyParentReport
                {
                    get { return (StockCardPresentationReport)ParentReport; }
                }
                
                public TTReportField TransactionDate;
                public TTReportField AmountIn;
                public TTReportField RegistrationNO;
                public TTReportField ShortDescription;
                public TTReportField AmountOut1;
                public TTReportField AmountOut2;
                public TTReportField New;
                public TTReportField Used;
                public TTReportField Consigned;
                public TTReportField ReplaceStore;
                public TTReportField InOut;
                public TTReportField Amount;
                public TTReportField MaintainLevelCode;
                public TTReportField StockLevelType;
                public TTReportField MainStore;
                public TTReportField STOCKACTIONID; 
                public MAINSECONDGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    TransactionDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 15, 5, false);
                    TransactionDate.Name = "TransactionDate";
                    TransactionDate.DrawStyle = DrawStyleConstants.vbSolid;
                    TransactionDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    TransactionDate.TextFormat = @"dd/MM/yyyy";
                    TransactionDate.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TransactionDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TransactionDate.TextFont.Size = 8;
                    TransactionDate.TextFont.CharSet = 162;
                    TransactionDate.Value = @"{#PARTB.TRANSACTIONDATE#}";

                    AmountIn = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 30, 5, false);
                    AmountIn.Name = "AmountIn";
                    AmountIn.DrawStyle = DrawStyleConstants.vbSolid;
                    AmountIn.FieldType = ReportFieldTypeEnum.ftVariable;
                    AmountIn.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AmountIn.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AmountIn.TextFont.Size = 8;
                    AmountIn.TextFont.CharSet = 162;
                    AmountIn.Value = @"";

                    RegistrationNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 0, 45, 5, false);
                    RegistrationNO.Name = "RegistrationNO";
                    RegistrationNO.DrawStyle = DrawStyleConstants.vbSolid;
                    RegistrationNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RegistrationNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RegistrationNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RegistrationNO.TextFont.Size = 8;
                    RegistrationNO.TextFont.CharSet = 162;
                    RegistrationNO.Value = @"{#PARTB.REGISTRATIONNUMBER#}";

                    ShortDescription = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 0, 59, 5, false);
                    ShortDescription.Name = "ShortDescription";
                    ShortDescription.DrawStyle = DrawStyleConstants.vbSolid;
                    ShortDescription.FieldType = ReportFieldTypeEnum.ftVariable;
                    ShortDescription.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ShortDescription.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ShortDescription.TextFont.Size = 8;
                    ShortDescription.TextFont.CharSet = 162;
                    ShortDescription.Value = @"{#PARTB.SHORTDESCRIPTION#}";

                    AmountOut1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 0, 74, 5, false);
                    AmountOut1.Name = "AmountOut1";
                    AmountOut1.DrawStyle = DrawStyleConstants.vbSolid;
                    AmountOut1.FieldType = ReportFieldTypeEnum.ftVariable;
                    AmountOut1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AmountOut1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AmountOut1.TextFont.Size = 8;
                    AmountOut1.TextFont.CharSet = 162;
                    AmountOut1.Value = @"";

                    AmountOut2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 0, 89, 5, false);
                    AmountOut2.Name = "AmountOut2";
                    AmountOut2.DrawStyle = DrawStyleConstants.vbSolid;
                    AmountOut2.FieldType = ReportFieldTypeEnum.ftVariable;
                    AmountOut2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AmountOut2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AmountOut2.TextFont.Size = 8;
                    AmountOut2.TextFont.CharSet = 162;
                    AmountOut2.Value = @"";

                    New = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 0, 107, 5, false);
                    New.Name = "New";
                    New.DrawStyle = DrawStyleConstants.vbSolid;
                    New.FieldType = ReportFieldTypeEnum.ftVariable;
                    New.HorzAlign = HorizontalAlignmentEnum.haRight;
                    New.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    New.TextFont.Size = 8;
                    New.TextFont.CharSet = 162;
                    New.Value = @"";

                    Used = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 0, 125, 5, false);
                    Used.Name = "Used";
                    Used.DrawStyle = DrawStyleConstants.vbSolid;
                    Used.FieldType = ReportFieldTypeEnum.ftVariable;
                    Used.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Used.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Used.TextFont.Size = 8;
                    Used.TextFont.CharSet = 162;
                    Used.Value = @"";

                    Consigned = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 0, 144, 5, false);
                    Consigned.Name = "Consigned";
                    Consigned.DrawStyle = DrawStyleConstants.vbSolid;
                    Consigned.FieldType = ReportFieldTypeEnum.ftVariable;
                    Consigned.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Consigned.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Consigned.TextFont.Size = 8;
                    Consigned.TextFont.CharSet = 162;
                    Consigned.Value = @"";

                    ReplaceStore = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 0, 190, 5, false);
                    ReplaceStore.Name = "ReplaceStore";
                    ReplaceStore.DrawStyle = DrawStyleConstants.vbSolid;
                    ReplaceStore.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReplaceStore.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReplaceStore.WordBreak = EvetHayirEnum.ehEvet;
                    ReplaceStore.TextFont.Size = 8;
                    ReplaceStore.TextFont.CharSet = 162;
                    ReplaceStore.Value = @"";

                    InOut = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 1, 222, 6, false);
                    InOut.Name = "InOut";
                    InOut.Visible = EvetHayirEnum.ehHayir;
                    InOut.FieldType = ReportFieldTypeEnum.ftVariable;
                    InOut.Value = @"{#PARTB.INOUT#}";

                    Amount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 1, 234, 6, false);
                    Amount.Name = "Amount";
                    Amount.Visible = EvetHayirEnum.ehHayir;
                    Amount.FieldType = ReportFieldTypeEnum.ftVariable;
                    Amount.Value = @"{#PARTB.AMOUNT#}";

                    MaintainLevelCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 1, 260, 6, false);
                    MaintainLevelCode.Name = "MaintainLevelCode";
                    MaintainLevelCode.Visible = EvetHayirEnum.ehHayir;
                    MaintainLevelCode.FieldType = ReportFieldTypeEnum.ftVariable;
                    MaintainLevelCode.Value = @"{#PARTB.MAINTAINLEVELCODE#}";

                    StockLevelType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 261, 1, 286, 6, false);
                    StockLevelType.Name = "StockLevelType";
                    StockLevelType.Visible = EvetHayirEnum.ehHayir;
                    StockLevelType.FieldType = ReportFieldTypeEnum.ftVariable;
                    StockLevelType.Value = @"{#PARTB.STOCKLEVELTYPESTATUS#}";

                    MainStore = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 319, 1, 344, 6, false);
                    MainStore.Name = "MainStore";
                    MainStore.Visible = EvetHayirEnum.ehHayir;
                    MainStore.FieldType = ReportFieldTypeEnum.ftVariable;
                    MainStore.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MainStore.Value = @"{#PARTB.STORE#}";

                    STOCKACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 288, 1, 313, 6, false);
                    STOCKACTIONID.Name = "STOCKACTIONID";
                    STOCKACTIONID.Visible = EvetHayirEnum.ehHayir;
                    STOCKACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKACTIONID.Value = @"{#PARTB.STOCKACTION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockCard.GetStockCardPreReportQuery_Class dataset_GetStockCardPreReportQuery = MyParentReport.PARTB.rsGroup.GetCurrentRecord<StockCard.GetStockCardPreReportQuery_Class>(0);
                    TransactionDate.CalcValue = (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.TransactionDate) : "");
                    AmountIn.CalcValue = @"";
                    RegistrationNO.CalcValue = (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.RegistrationNumber) : "");
                    ShortDescription.CalcValue = (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.ShortDescription) : "");
                    AmountOut1.CalcValue = @"";
                    AmountOut2.CalcValue = @"";
                    New.CalcValue = @"";
                    Used.CalcValue = @"";
                    Consigned.CalcValue = @"";
                    ReplaceStore.CalcValue = @"";
                    InOut.CalcValue = (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.InOut) : "");
                    Amount.CalcValue = (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.Amount) : "");
                    MaintainLevelCode.CalcValue = (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.MaintainLevelCode) : "");
                    StockLevelType.CalcValue = (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.StockLevelTypeStatus) : "");
                    MainStore.CalcValue = (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.Store) : "");
                    STOCKACTIONID.CalcValue = (dataset_GetStockCardPreReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardPreReportQuery.Stockaction) : "");
                    return new TTReportObject[] { TransactionDate,AmountIn,RegistrationNO,ShortDescription,AmountOut1,AmountOut2,New,Used,Consigned,ReplaceStore,InOut,Amount,MaintainLevelCode,StockLevelType,MainStore,STOCKACTIONID};
                }

                public override void RunScript()
                {
#region MAINSECOND BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            StockAction stockAction = (StockAction)ctx.GetObject(new Guid(STOCKACTIONID.CalcValue), typeof(StockAction));
            
            switch(ShortDescription.CalcValue)
            {
                case "GGB":
//                    if(stockAction is InputSendingDocument)
//                    {
//                        InputSendingDocument isd = (InputSendingDocument)stockAction;
//                        if(isd.Accountancy != null)
//                            ReplaceStore.CalcValue = isd.Accountancy.Name;
//                    }
                    if(stockAction is StockFirstIn)
                    {
                        StockFirstIn sfi = (StockFirstIn)stockAction;
                        if(sfi.DestinationStore != null)
                        {
                            if ((sfi.DestinationStore.Name == this.MainStore.CalcValue) || sfi.DestinationStore.Name == "" || sfi.DestinationStore.Name == null)
                                this.ReplaceStore.CalcValue = sfi.Store.Name;
                            else
                                this.ReplaceStore.CalcValue = sfi.DestinationStore.Name;
                        }
                    }
                    break;
                    
//                case "ÇGB":
//                    OutputSendingDocument osd = (OutputSendingDocument)stockAction;
//                    if(osd.Accountancy != null)
//                        ReplaceStore.CalcValue = osd.Accountancy.Name;
//                    break;
                    
//                case "KB":
//                    ChequeDocument cd = (ChequeDocument)stockAction;
//                    ReplaceStore.CalcValue = cd.Supplier.Name;
//                    break;
//                    
                case "SE":
                    CensusOrder co = (CensusOrder)stockAction;
                    ReplaceStore.CalcValue = co.Store.Name;
                    break;
                    
//                case "KAKB":
//                    ForcesBetweenChequeDocument fbcd = (ForcesBetweenChequeDocument)stockAction;
//                    ReplaceStore.CalcValue = fbcd.TakerSender.Name;
//                    break;
                    
//                case "KAGKB":
//                    ForcesBetweenInputChequeDocument fbicd = (ForcesBetweenInputChequeDocument)stockAction;
//                    if(fbicd.SenderAccountancy != null)
//                        ReplaceStore.CalcValue = fbicd.SenderAccountancy.Name;
//                    break;
                    
                default:
                    if(stockAction.DestinationStore != null)
                    {
                        if ((stockAction.DestinationStore.Name.ToString() == this.MainStore.CalcValue) || stockAction.DestinationStore.Name.ToString() == "" || stockAction.DestinationStore.Name.ToString() == null)
                            this.ReplaceStore.CalcValue = stockAction.Store.Name;
                        else
                            this.ReplaceStore.CalcValue = stockAction.DestinationStore.Name;
                    }
                    break;
            }
            
            if (this.InOut.CalcValue == "In")
            {
                this.AmountIn.CalcValue = this.Amount.CalcValue;
            }
            else if (this.InOut.CalcValue == "Out")
            {
                if (this.ShortDescription.CalcValue == "DB")
                    this.AmountOut1.CalcValue = this.Amount.CalcValue;
                else
                    this.AmountOut2.CalcValue = this.Amount.CalcValue;
            }

            if (this.Amount.CalcValue == "")
                this.Amount.CalcValue = "0";

            double amount = Convert.ToDouble(this.Amount.CalcValue);

            switch (this.MaintainLevelCode.CalcValue)
            {
                case "IncreaseInheld":
                    if (this.StockLevelType.CalcValue == "New")
                    {
                        PARTBGroup.oldInheld = PARTBGroup.oldInheld + amount;
                        this.New.CalcValue = PARTBGroup.oldInheld.ToString();
                    }
                    else if (this.StockLevelType.CalcValue == "Used")
                    {
                        PARTBGroup.oldUsed = PARTBGroup.oldUsed + amount;
                        this.Used.CalcValue = PARTBGroup.oldUsed.ToString();
                    }
                    break;

                case "DecreaseInheld":
                    if (this.StockLevelType.CalcValue == "New")
                    {
                        PARTBGroup.oldInheld = PARTBGroup.oldInheld - amount;
                        this.New.CalcValue = PARTBGroup.oldInheld.ToString();
                    }
                    else if (this.StockLevelType.CalcValue == "Used")
                    {
                        PARTBGroup.oldUsed = PARTBGroup.oldUsed - amount;
                        this.Used.CalcValue = PARTBGroup.oldUsed.ToString();
                    }
                    break;

                case "IncreaseConsigned":
                    PARTBGroup.oldConsigned = PARTBGroup.oldConsigned + amount;
                    this.Consigned.CalcValue = PARTBGroup.oldConsigned.ToString();
                    break;

                case "DecreaseConsigned":
                    PARTBGroup.oldConsigned = PARTBGroup.oldConsigned - amount;
                    this.Consigned.CalcValue = PARTBGroup.oldConsigned.ToString();
                    break;

                case "DecreaseInheld__IncreaseConsigned":
                    if (this.StockLevelType.CalcValue == "New")
                    {
                        PARTBGroup.oldInheld = PARTBGroup.oldInheld - amount;
                        this.New.CalcValue = PARTBGroup.oldInheld.ToString();
                    }
                    else if (this.StockLevelType.CalcValue == "Used")
                    {
                        PARTBGroup.oldUsed = PARTBGroup.oldUsed - amount;
                        this.Used.CalcValue = PARTBGroup.oldUsed.ToString();
                    }
                    PARTBGroup.oldConsigned = PARTBGroup.oldConsigned + amount;
                    this.Consigned.CalcValue = PARTBGroup.oldConsigned.ToString();
                    break;

                case "IncreaseInheld__DecreaseConsigned":
                    if (this.StockLevelType.CalcValue == "New")
                    {
                        PARTBGroup.oldInheld = PARTBGroup.oldInheld + amount;
                        this.New.CalcValue = PARTBGroup.oldInheld.ToString();
                    }
                    else if (this.StockLevelType.CalcValue == "Used")
                    {
                        PARTBGroup.oldUsed = PARTBGroup.oldUsed + amount;
                        this.Used.CalcValue = PARTBGroup.oldUsed.ToString();
                    }
                    PARTBGroup.oldConsigned = PARTBGroup.oldConsigned - amount;
                    this.Consigned.CalcValue = PARTBGroup.oldConsigned.ToString();
                    break;
            }
            this.New.CalcValue = PARTBGroup.oldInheld.ToString();
            this.Used.CalcValue = PARTBGroup.oldUsed.ToString();
            this.Consigned.CalcValue = PARTBGroup.oldConsigned.ToString();
#endregion MAINSECOND BODY_Script
                }
            }

        }

        public MAINSECONDGroup MAINSECOND;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public StockCardPresentationReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAINSECOND = new MAINSECONDGroup(PARTB,"MAINSECOND");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOCKCARDID", "00000000-0000-0000-0000-000000000000", "Stok Kartını Seçiniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("e8c3b02e-4a08-4c98-bfd0-15d84fafb295");
            reportParameter = Parameters.Add("STOREID", "00000000-0000-0000-0000-000000000000", "Depo Seçiniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("cd051a98-4361-4c40-8ad6-6f7b69696f8e");
            reportParameter = Parameters.Add("TERMID", "00000000-0000-0000-0000-000000000000", "Hesap Dönemi Seçiniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOCKCARDID"))
                _runtimeParameters.STOCKCARDID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STOCKCARDID"]);
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STOREID"]);
            if (parameters.ContainsKey("TERMID"))
                _runtimeParameters.TERMID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TERMID"]);
            Name = "STOCKCARDPRESENTATIONREPORT";
            Caption = "Stok Kartı Dökümü Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
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