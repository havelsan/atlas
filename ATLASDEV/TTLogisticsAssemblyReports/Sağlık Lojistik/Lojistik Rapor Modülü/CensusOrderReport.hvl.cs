
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
    /// Sayım Emri Fişi
    /// </summary>
    public partial class CensusOrderReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public CensusOrderReport MyParentReport
            {
                get { return (CensusOrderReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField045 { get {return Header().NewField045;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField RegistrationNO3 { get {return Header().RegistrationNO3;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField RegistrationNO2 { get {return Header().RegistrationNO2;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField RegistrationNO1 { get {return Header().RegistrationNO1;} }
            public TTReportField Count3 { get {return Header().Count3;} }
            public TTReportField Count2 { get {return Header().Count2;} }
            public TTReportField Count1 { get {return Header().Count1;} }
            public TTReportField ORDERDETAILOBJECTID { get {return Header().ORDERDETAILOBJECTID;} }
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
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<CensusOrder.GetCensusOrderReportQuery_Class>("GetCensusOrderReportQuery", CensusOrder.GetCensusOrderReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public CensusOrderReport MyParentReport
                {
                    get { return (CensusOrderReport)ParentReport; }
                }
                
                public TTReportField NewField3;
                public TTReportField NewField045;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportShape NewLine1;
                public TTReportField RegistrationNO3;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField9;
                public TTReportField RegistrationNO2;
                public TTReportShape NewLine2;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField RegistrationNO1;
                public TTReportField Count3;
                public TTReportField Count2;
                public TTReportField Count1;
                public TTReportField ORDERDETAILOBJECTID; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 37;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 26, 74, 37, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.DrawWidth = 2;
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.TextFont.Size = 9;
                    NewField3.Value = @" Belge Kayıt No :";

                    NewField045 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 17, 62, 26, false);
                    NewField045.Name = "NewField045";
                    NewField045.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField045.DrawWidth = 2;
                    NewField045.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField045.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField045.TextFont.Name = "Arial Narrow";
                    NewField045.TextFont.Size = 12;
                    NewField045.TextFont.Bold = true;
                    NewField045.Value = @"SAYIM FİŞİ";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 17, 74, 26, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.DrawWidth = 2;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 12;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"3";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 26, 41, 37, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.DrawWidth = 2;
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Size = 9;
                    NewField2.Value = @" Sıra No :";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 78, 17, 78, 37, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbDot;

                    RegistrationNO3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 30, 74, 36, false);
                    RegistrationNO3.Name = "RegistrationNO3";
                    RegistrationNO3.FillStyle = FillStyleConstants.vbFSTransparent;
                    RegistrationNO3.FieldType = ReportFieldTypeEnum.ftVariable;
                    RegistrationNO3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RegistrationNO3.TextFont.Name = "Arial Narrow";
                    RegistrationNO3.Value = @"{#REGISTRATIONNUMBER#}";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 26, 182, 37, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.DrawWidth = 2;
                    NewField6.TextFont.Name = "Arial Narrow";
                    NewField6.TextFont.Size = 9;
                    NewField6.Value = @" Belge Kayıt No :";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 17, 170, 26, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.DrawWidth = 2;
                    NewField7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.TextFont.Name = "Arial Narrow";
                    NewField7.TextFont.Size = 12;
                    NewField7.TextFont.Bold = true;
                    NewField7.Value = @"SAYIM FİŞİ";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 17, 182, 26, false);
                    NewField8.Name = "NewField8";
                    NewField8.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField8.DrawWidth = 2;
                    NewField8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8.TextFont.Name = "Arial Narrow";
                    NewField8.TextFont.Size = 12;
                    NewField8.TextFont.Bold = true;
                    NewField8.Value = @"2";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 26, 131, 37, false);
                    NewField9.Name = "NewField9";
                    NewField9.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField9.DrawWidth = 2;
                    NewField9.TextFont.Name = "Arial Narrow";
                    NewField9.TextFont.Size = 9;
                    NewField9.Value = @" Sıra No :";

                    RegistrationNO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 30, 177, 36, false);
                    RegistrationNO2.Name = "RegistrationNO2";
                    RegistrationNO2.FillStyle = FillStyleConstants.vbFSTransparent;
                    RegistrationNO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    RegistrationNO2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RegistrationNO2.TextFont.Name = "Arial Narrow";
                    RegistrationNO2.Value = @"{#REGISTRATIONNUMBER#}";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 185, 17, 185, 38, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbDot;

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 26, 288, 37, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.DrawWidth = 2;
                    NewField12.TextFont.Name = "Arial Narrow";
                    NewField12.TextFont.Size = 9;
                    NewField12.Value = @" Belge Kayıt No :";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 17, 276, 26, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.DrawWidth = 2;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial Narrow";
                    NewField13.TextFont.Size = 12;
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @"SAYIM FİŞİ";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 276, 17, 288, 26, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.DrawWidth = 2;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial Narrow";
                    NewField14.TextFont.Size = 12;
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @"1";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 26, 237, 37, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.DrawWidth = 2;
                    NewField15.TextFont.Name = "Arial Narrow";
                    NewField15.TextFont.Size = 9;
                    NewField15.Value = @" Sıra No :";

                    RegistrationNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 259, 30, 283, 36, false);
                    RegistrationNO1.Name = "RegistrationNO1";
                    RegistrationNO1.FillStyle = FillStyleConstants.vbFSTransparent;
                    RegistrationNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    RegistrationNO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RegistrationNO1.TextFont.Name = "Arial Narrow";
                    RegistrationNO1.Value = @"{#REGISTRATIONNUMBER#}";

                    Count3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 30, 41, 36, false);
                    Count3.Name = "Count3";
                    Count3.FillStyle = FillStyleConstants.vbFSTransparent;
                    Count3.FieldType = ReportFieldTypeEnum.ftVariable;
                    Count3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Count3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Count3.TextFont.Name = "Arial Narrow";
                    Count3.TextFont.Size = 12;
                    Count3.TextFont.Bold = true;
                    Count3.Value = @"{#ORDERSEQUENCENUMBER#}";

                    Count2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 30, 131, 36, false);
                    Count2.Name = "Count2";
                    Count2.FillStyle = FillStyleConstants.vbFSTransparent;
                    Count2.FieldType = ReportFieldTypeEnum.ftVariable;
                    Count2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Count2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Count2.TextFont.Name = "Arial Narrow";
                    Count2.TextFont.Size = 12;
                    Count2.TextFont.Bold = true;
                    Count2.Value = @"{#ORDERSEQUENCENUMBER#}";

                    Count1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 30, 237, 36, false);
                    Count1.Name = "Count1";
                    Count1.FillStyle = FillStyleConstants.vbFSTransparent;
                    Count1.FieldType = ReportFieldTypeEnum.ftVariable;
                    Count1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Count1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Count1.TextFont.Name = "Arial Narrow";
                    Count1.TextFont.Size = 12;
                    Count1.TextFont.Bold = true;
                    Count1.Value = @"{#ORDERSEQUENCENUMBER#}";

                    ORDERDETAILOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 8, 103, 13, false);
                    ORDERDETAILOBJECTID.Name = "ORDERDETAILOBJECTID";
                    ORDERDETAILOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    ORDERDETAILOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERDETAILOBJECTID.TextFont.Name = "Arial Narrow";
                    ORDERDETAILOBJECTID.TextFont.CharSet = 1;
                    ORDERDETAILOBJECTID.Value = @"{#ORDERDETAILOBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CensusOrder.GetCensusOrderReportQuery_Class dataset_GetCensusOrderReportQuery = ParentGroup.rsGroup.GetCurrentRecord<CensusOrder.GetCensusOrderReportQuery_Class>(0);
                    NewField3.CalcValue = NewField3.Value;
                    NewField045.CalcValue = NewField045.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    RegistrationNO3.CalcValue = (dataset_GetCensusOrderReportQuery != null ? Globals.ToStringCore(dataset_GetCensusOrderReportQuery.RegistrationNumber) : "");
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField9.CalcValue = NewField9.Value;
                    RegistrationNO2.CalcValue = (dataset_GetCensusOrderReportQuery != null ? Globals.ToStringCore(dataset_GetCensusOrderReportQuery.RegistrationNumber) : "");
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    RegistrationNO1.CalcValue = (dataset_GetCensusOrderReportQuery != null ? Globals.ToStringCore(dataset_GetCensusOrderReportQuery.RegistrationNumber) : "");
                    Count3.CalcValue = (dataset_GetCensusOrderReportQuery != null ? Globals.ToStringCore(dataset_GetCensusOrderReportQuery.OrderSequenceNumber) : "");
                    Count2.CalcValue = (dataset_GetCensusOrderReportQuery != null ? Globals.ToStringCore(dataset_GetCensusOrderReportQuery.OrderSequenceNumber) : "");
                    Count1.CalcValue = (dataset_GetCensusOrderReportQuery != null ? Globals.ToStringCore(dataset_GetCensusOrderReportQuery.OrderSequenceNumber) : "");
                    ORDERDETAILOBJECTID.CalcValue = (dataset_GetCensusOrderReportQuery != null ? Globals.ToStringCore(dataset_GetCensusOrderReportQuery.Orderdetailobjectid) : "");
                    return new TTReportObject[] { NewField3,NewField045,NewField1,NewField2,RegistrationNO3,NewField6,NewField7,NewField8,NewField9,RegistrationNO2,NewField12,NewField13,NewField14,NewField15,RegistrationNO1,Count3,Count2,Count1,ORDERDETAILOBJECTID};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public CensusOrderReport MyParentReport
                {
                    get { return (CensusOrderReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 17;
                    IsVisible = EvetHayirEnum.ehHayir;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public CensusOrderReport MyParentReport
            {
                get { return (CensusOrderReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField0 { get {return Body().NewField0;} }
            public TTReportField NewField022 { get {return Body().NewField022;} }
            public TTReportField NATOStockNO3 { get {return Body().NATOStockNO3;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField StockCardName3 { get {return Body().StockCardName3;} }
            public TTReportField NewField5 { get {return Body().NewField5;} }
            public TTReportField NewField6 { get {return Body().NewField6;} }
            public TTReportField NewField7 { get {return Body().NewField7;} }
            public TTReportField DistributionType3 { get {return Body().DistributionType3;} }
            public TTReportField NewField9 { get {return Body().NewField9;} }
            public TTReportField NewField10 { get {return Body().NewField10;} }
            public TTReportField NewField191 { get {return Body().NewField191;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public TTReportField NATOStockNO2 { get {return Body().NATOStockNO2;} }
            public TTReportField NewField19 { get {return Body().NewField19;} }
            public TTReportField NewField20 { get {return Body().NewField20;} }
            public TTReportField StockCardName2 { get {return Body().StockCardName2;} }
            public TTReportField NewField22 { get {return Body().NewField22;} }
            public TTReportField ClassName2 { get {return Body().ClassName2;} }
            public TTReportField NewField24 { get {return Body().NewField24;} }
            public TTReportField DistributionType2 { get {return Body().DistributionType2;} }
            public TTReportField NewField26 { get {return Body().NewField26;} }
            public TTReportField NewField27 { get {return Body().NewField27;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportField NewField29 { get {return Body().NewField29;} }
            public TTReportField NewField30 { get {return Body().NewField30;} }
            public TTReportField NewField31 { get {return Body().NewField31;} }
            public TTReportField NewField32 { get {return Body().NewField32;} }
            public TTReportField NewField33 { get {return Body().NewField33;} }
            public TTReportField NewField34 { get {return Body().NewField34;} }
            public TTReportField NewField35 { get {return Body().NewField35;} }
            public TTReportField NewInheld2 { get {return Body().NewInheld2;} }
            public TTReportField NewField37 { get {return Body().NewField37;} }
            public TTReportField NewField38 { get {return Body().NewField38;} }
            public TTReportField NewField39 { get {return Body().NewField39;} }
            public TTReportField NewField40 { get {return Body().NewField40;} }
            public TTReportField NewField41 { get {return Body().NewField41;} }
            public TTReportField NewField42 { get {return Body().NewField42;} }
            public TTReportField NewField43 { get {return Body().NewField43;} }
            public TTReportField NewField44 { get {return Body().NewField44;} }
            public TTReportField NewField45 { get {return Body().NewField45;} }
            public TTReportField NewField46 { get {return Body().NewField46;} }
            public TTReportField NewField47 { get {return Body().NewField47;} }
            public TTReportField NewField50 { get {return Body().NewField50;} }
            public TTReportField NewField51 { get {return Body().NewField51;} }
            public TTReportField NewField52 { get {return Body().NewField52;} }
            public TTReportField NewField53 { get {return Body().NewField53;} }
            public TTReportField NewField54 { get {return Body().NewField54;} }
            public TTReportField NewField55 { get {return Body().NewField55;} }
            public TTReportField NewField56 { get {return Body().NewField56;} }
            public TTReportField NewField57 { get {return Body().NewField57;} }
            public TTReportField NewField58 { get {return Body().NewField58;} }
            public TTReportField NewField59 { get {return Body().NewField59;} }
            public TTReportField NewField60 { get {return Body().NewField60;} }
            public TTReportField NewField61 { get {return Body().NewField61;} }
            public TTReportField NewField62 { get {return Body().NewField62;} }
            public TTReportField NewField63 { get {return Body().NewField63;} }
            public TTReportField NewField64 { get {return Body().NewField64;} }
            public TTReportField NewField65 { get {return Body().NewField65;} }
            public TTReportField NewField66 { get {return Body().NewField66;} }
            public TTReportField NewField67 { get {return Body().NewField67;} }
            public TTReportField NewField68 { get {return Body().NewField68;} }
            public TTReportField NewField69 { get {return Body().NewField69;} }
            public TTReportField NewField70 { get {return Body().NewField70;} }
            public TTReportField NewField71 { get {return Body().NewField71;} }
            public TTReportField NewField72 { get {return Body().NewField72;} }
            public TTReportField NewField73 { get {return Body().NewField73;} }
            public TTReportField NewField74 { get {return Body().NewField74;} }
            public TTReportField NewField75 { get {return Body().NewField75;} }
            public TTReportField NewField76 { get {return Body().NewField76;} }
            public TTReportField NewField77 { get {return Body().NewField77;} }
            public TTReportField NewField78 { get {return Body().NewField78;} }
            public TTReportField NewField79 { get {return Body().NewField79;} }
            public TTReportField NATOStockNO1 { get {return Body().NATOStockNO1;} }
            public TTReportField NewField81 { get {return Body().NewField81;} }
            public TTReportField NewField82 { get {return Body().NewField82;} }
            public TTReportField StockCardName1 { get {return Body().StockCardName1;} }
            public TTReportField NewField84 { get {return Body().NewField84;} }
            public TTReportField ClassName1 { get {return Body().ClassName1;} }
            public TTReportField NewField86 { get {return Body().NewField86;} }
            public TTReportField DistributionType1 { get {return Body().DistributionType1;} }
            public TTReportField NewField88 { get {return Body().NewField88;} }
            public TTReportField NewField89 { get {return Body().NewField89;} }
            public TTReportField NewField91 { get {return Body().NewField91;} }
            public TTReportField NewField92 { get {return Body().NewField92;} }
            public TTReportField NewField93 { get {return Body().NewField93;} }
            public TTReportField NewField94 { get {return Body().NewField94;} }
            public TTReportField NewField95 { get {return Body().NewField95;} }
            public TTReportField NewField96 { get {return Body().NewField96;} }
            public TTReportField NewField97 { get {return Body().NewField97;} }
            public TTReportField NewInheld1 { get {return Body().NewInheld1;} }
            public TTReportField NewField99 { get {return Body().NewField99;} }
            public TTReportField NewField100 { get {return Body().NewField100;} }
            public TTReportField NewField101 { get {return Body().NewField101;} }
            public TTReportField NewField102 { get {return Body().NewField102;} }
            public TTReportField NewField103 { get {return Body().NewField103;} }
            public TTReportField NewField104 { get {return Body().NewField104;} }
            public TTReportField NewField105 { get {return Body().NewField105;} }
            public TTReportField NewField106 { get {return Body().NewField106;} }
            public TTReportField NewField107 { get {return Body().NewField107;} }
            public TTReportField NewField108 { get {return Body().NewField108;} }
            public TTReportField NewField109 { get {return Body().NewField109;} }
            public TTReportField UsedInheld { get {return Body().UsedInheld;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField112 { get {return Body().NewField112;} }
            public TTReportField NewField113 { get {return Body().NewField113;} }
            public TTReportField NewField114 { get {return Body().NewField114;} }
            public TTReportField NewField115 { get {return Body().NewField115;} }
            public TTReportField NewField116 { get {return Body().NewField116;} }
            public TTReportField NewField117 { get {return Body().NewField117;} }
            public TTReportField NewField118 { get {return Body().NewField118;} }
            public TTReportField NewField119 { get {return Body().NewField119;} }
            public TTReportField NewField120 { get {return Body().NewField120;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField122 { get {return Body().NewField122;} }
            public TTReportField NewField123 { get {return Body().NewField123;} }
            public TTReportField NewField124 { get {return Body().NewField124;} }
            public TTReportField NewField125 { get {return Body().NewField125;} }
            public TTReportField NewField126 { get {return Body().NewField126;} }
            public TTReportField NewField127 { get {return Body().NewField127;} }
            public TTReportField NewField128 { get {return Body().NewField128;} }
            public TTReportField NewField129 { get {return Body().NewField129;} }
            public TTReportField NewField130 { get {return Body().NewField130;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField132 { get {return Body().NewField132;} }
            public TTReportField NewField133 { get {return Body().NewField133;} }
            public TTReportField NewField134 { get {return Body().NewField134;} }
            public TTReportField NewField135 { get {return Body().NewField135;} }
            public TTReportField NewField136 { get {return Body().NewField136;} }
            public TTReportField NewField137 { get {return Body().NewField137;} }
            public TTReportField NewField138 { get {return Body().NewField138;} }
            public TTReportField NewField139 { get {return Body().NewField139;} }
            public TTReportField TransactionDate3 { get {return Body().TransactionDate3;} }
            public TTReportField TransactionDate2 { get {return Body().TransactionDate2;} }
            public TTReportField TransactionDate1 { get {return Body().TransactionDate1;} }
            public TTReportField MAINCLASSNAME2 { get {return Body().MAINCLASSNAME2;} }
            public TTReportField MAINCLASSNAME1 { get {return Body().MAINCLASSNAME1;} }
            public TTReportField UsedInheld2 { get {return Body().UsedInheld2;} }
            public TTReportField SAYAN2 { get {return Body().SAYAN2;} }
            public TTReportField SAYAN3 { get {return Body().SAYAN3;} }
            public TTReportField MAINCLASSNAME3 { get {return Body().MAINCLASSNAME3;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                CensusOrder.GetCensusOrderReportQuery_Class dataSet_GetCensusOrderReportQuery = ParentGroup.rsGroup.GetCurrentRecord<CensusOrder.GetCensusOrderReportQuery_Class>(0);    
                return new object[] {(dataSet_GetCensusOrderReportQuery==null ? null : dataSet_GetCensusOrderReportQuery.Orderdetailobjectid)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public CensusOrderReport MyParentReport
                {
                    get { return (CensusOrderReport)ParentReport; }
                }
                
                public TTReportField NewField0;
                public TTReportField NewField022;
                public TTReportField NATOStockNO3;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField StockCardName3;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField DistributionType3;
                public TTReportField NewField9;
                public TTReportField NewField10;
                public TTReportField NewField191;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField11;
                public TTReportShape NewLine1;
                public TTReportField NewField17;
                public TTReportField NATOStockNO2;
                public TTReportField NewField19;
                public TTReportField NewField20;
                public TTReportField StockCardName2;
                public TTReportField NewField22;
                public TTReportField ClassName2;
                public TTReportField NewField24;
                public TTReportField DistributionType2;
                public TTReportField NewField26;
                public TTReportField NewField27;
                public TTReportShape NewLine2;
                public TTReportField NewField29;
                public TTReportField NewField30;
                public TTReportField NewField31;
                public TTReportField NewField32;
                public TTReportField NewField33;
                public TTReportField NewField34;
                public TTReportField NewField35;
                public TTReportField NewInheld2;
                public TTReportField NewField37;
                public TTReportField NewField38;
                public TTReportField NewField39;
                public TTReportField NewField40;
                public TTReportField NewField41;
                public TTReportField NewField42;
                public TTReportField NewField43;
                public TTReportField NewField44;
                public TTReportField NewField45;
                public TTReportField NewField46;
                public TTReportField NewField47;
                public TTReportField NewField50;
                public TTReportField NewField51;
                public TTReportField NewField52;
                public TTReportField NewField53;
                public TTReportField NewField54;
                public TTReportField NewField55;
                public TTReportField NewField56;
                public TTReportField NewField57;
                public TTReportField NewField58;
                public TTReportField NewField59;
                public TTReportField NewField60;
                public TTReportField NewField61;
                public TTReportField NewField62;
                public TTReportField NewField63;
                public TTReportField NewField64;
                public TTReportField NewField65;
                public TTReportField NewField66;
                public TTReportField NewField67;
                public TTReportField NewField68;
                public TTReportField NewField69;
                public TTReportField NewField70;
                public TTReportField NewField71;
                public TTReportField NewField72;
                public TTReportField NewField73;
                public TTReportField NewField74;
                public TTReportField NewField75;
                public TTReportField NewField76;
                public TTReportField NewField77;
                public TTReportField NewField78;
                public TTReportField NewField79;
                public TTReportField NATOStockNO1;
                public TTReportField NewField81;
                public TTReportField NewField82;
                public TTReportField StockCardName1;
                public TTReportField NewField84;
                public TTReportField ClassName1;
                public TTReportField NewField86;
                public TTReportField DistributionType1;
                public TTReportField NewField88;
                public TTReportField NewField89;
                public TTReportField NewField91;
                public TTReportField NewField92;
                public TTReportField NewField93;
                public TTReportField NewField94;
                public TTReportField NewField95;
                public TTReportField NewField96;
                public TTReportField NewField97;
                public TTReportField NewInheld1;
                public TTReportField NewField99;
                public TTReportField NewField100;
                public TTReportField NewField101;
                public TTReportField NewField102;
                public TTReportField NewField103;
                public TTReportField NewField104;
                public TTReportField NewField105;
                public TTReportField NewField106;
                public TTReportField NewField107;
                public TTReportField NewField108;
                public TTReportField NewField109;
                public TTReportField UsedInheld;
                public TTReportField NewField111;
                public TTReportField NewField112;
                public TTReportField NewField113;
                public TTReportField NewField114;
                public TTReportField NewField115;
                public TTReportField NewField116;
                public TTReportField NewField117;
                public TTReportField NewField118;
                public TTReportField NewField119;
                public TTReportField NewField120;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportField NewField123;
                public TTReportField NewField124;
                public TTReportField NewField125;
                public TTReportField NewField126;
                public TTReportField NewField127;
                public TTReportField NewField128;
                public TTReportField NewField129;
                public TTReportField NewField130;
                public TTReportField NewField131;
                public TTReportField NewField132;
                public TTReportField NewField133;
                public TTReportField NewField134;
                public TTReportField NewField135;
                public TTReportField NewField136;
                public TTReportField NewField137;
                public TTReportField NewField138;
                public TTReportField NewField139;
                public TTReportField TransactionDate3;
                public TTReportField TransactionDate2;
                public TTReportField TransactionDate1;
                public TTReportField MAINCLASSNAME2;
                public TTReportField MAINCLASSNAME1;
                public TTReportField UsedInheld2;
                public TTReportField SAYAN2;
                public TTReportField SAYAN3;
                public TTReportField MAINCLASSNAME3; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 157;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 152, 74, 157, false);
                    NewField0.Name = "NewField0";
                    NewField0.MultiLine = EvetHayirEnum.ehEvet;
                    NewField0.WordBreak = EvetHayirEnum.ehEvet;
                    NewField0.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField0.TextFont.Name = "Arial Narrow";
                    NewField0.TextFont.Size = 9;
                    NewField0.Value = @"    Örnek No : L-101-12";

                    NewField022 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 0, 74, 6, false);
                    NewField022.Name = "NewField022";
                    NewField022.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField022.DrawWidth = 2;
                    NewField022.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField022.TextFont.Name = "Arial Narrow";
                    NewField022.TextFont.Size = 9;
                    NewField022.Value = @" Stok No :";

                    NATOStockNO3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 0, 74, 6, false);
                    NATOStockNO3.Name = "NATOStockNO3";
                    NATOStockNO3.FillStyle = FillStyleConstants.vbFSTransparent;
                    NATOStockNO3.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOStockNO3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOStockNO3.TextFont.Name = "Arial Narrow";
                    NATOStockNO3.Value = @"{#PARTA.NATOSTOCKNO#}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 6, 74, 12, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.DrawWidth = 2;
                    NewField2.TextFont.Name = "Arial Narrow";
                    NewField2.TextFont.Size = 9;
                    NewField2.Value = @" Parça No :";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 12, 74, 35, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.DrawWidth = 2;
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.TextFont.Size = 9;
                    NewField3.Value = @" İsmi :";

                    StockCardName3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 17, 74, 35, false);
                    StockCardName3.Name = "StockCardName3";
                    StockCardName3.FillStyle = FillStyleConstants.vbFSTransparent;
                    StockCardName3.FieldType = ReportFieldTypeEnum.ftVariable;
                    StockCardName3.MultiLine = EvetHayirEnum.ehEvet;
                    StockCardName3.WordBreak = EvetHayirEnum.ehEvet;
                    StockCardName3.ExpandTabs = EvetHayirEnum.ehEvet;
                    StockCardName3.TextFont.Name = "Arial Narrow";
                    StockCardName3.Value = @"{#PARTA.CARDNAME#}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 35, 34, 46, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.DrawWidth = 2;
                    NewField5.MultiLine = EvetHayirEnum.ehEvet;
                    NewField5.WordBreak = EvetHayirEnum.ehEvet;
                    NewField5.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField5.TextFont.Name = "Arial Narrow";
                    NewField5.TextFont.Size = 9;
                    NewField5.Value = @" Sayım Tarihi :
";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 35, 47, 46, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.DrawWidth = 2;
                    NewField6.MultiLine = EvetHayirEnum.ehEvet;
                    NewField6.WordBreak = EvetHayirEnum.ehEvet;
                    NewField6.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField6.TextFont.Name = "Arial Narrow";
                    NewField6.TextFont.Size = 9;
                    NewField6.Value = @" Sınıfı :";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 35, 74, 46, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.DrawWidth = 2;
                    NewField7.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7.WordBreak = EvetHayirEnum.ehEvet;
                    NewField7.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField7.TextFont.Name = "Arial Narrow";
                    NewField7.TextFont.Size = 9;
                    NewField7.Value = @" Ölçü Cinsi :";

                    DistributionType3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 40, 74, 46, false);
                    DistributionType3.Name = "DistributionType3";
                    DistributionType3.FillStyle = FillStyleConstants.vbFSTransparent;
                    DistributionType3.FieldType = ReportFieldTypeEnum.ftVariable;
                    DistributionType3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DistributionType3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DistributionType3.TextFont.Name = "Arial Narrow";
                    DistributionType3.Value = @"{#PARTA.DISTRIBUTIONTYPE#}";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 46, 43, 77, false);
                    NewField9.Name = "NewField9";
                    NewField9.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField9.DrawWidth = 2;
                    NewField9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField9.TextFont.Name = "Arial Narrow";
                    NewField9.TextFont.Size = 9;
                    NewField9.Value = @"Ana Yer";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 46, 74, 77, false);
                    NewField10.Name = "NewField10";
                    NewField10.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField10.DrawWidth = 2;
                    NewField10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField10.TextFont.Name = "Arial Narrow";
                    NewField10.TextFont.Size = 9;
                    NewField10.Value = @"Yedek Yer";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 77, 74, 83, false);
                    NewField191.Name = "NewField191";
                    NewField191.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField191.DrawWidth = 2;
                    NewField191.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField191.TextFont.Name = "Arial Narrow";
                    NewField191.TextFont.Size = 9;
                    NewField191.Value = @"Sayanların İmzası";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 83, 43, 123, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.DrawWidth = 2;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.TextFont.Name = "Arial Narrow";
                    NewField12.TextFont.Size = 9;
                    NewField12.Value = @"";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 83, 74, 123, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.DrawWidth = 2;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.TextFont.Name = "Arial Narrow";
                    NewField13.TextFont.Size = 9;
                    NewField13.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 123, 74, 151, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.DrawWidth = 2;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Name = "Arial Narrow";
                    NewField11.TextFont.Size = 9;
                    NewField11.Value = @" Bu parça malın bulunduğu yerde kalır. 
 (Miktar yazılmaz)";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 78, -1, 78, 157, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbDot;

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 0, 182, 6, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.DrawWidth = 2;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.TextFont.Name = "Arial Narrow";
                    NewField17.TextFont.Size = 9;
                    NewField17.Value = @" Stok No :";

                    NATOStockNO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 0, 144, 6, false);
                    NATOStockNO2.Name = "NATOStockNO2";
                    NATOStockNO2.FillStyle = FillStyleConstants.vbFSTransparent;
                    NATOStockNO2.DrawWidth = 2;
                    NATOStockNO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOStockNO2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOStockNO2.TextFont.Name = "Arial Narrow";
                    NATOStockNO2.Value = @"{#PARTA.NATOSTOCKNO#}";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 6, 182, 12, false);
                    NewField19.Name = "NewField19";
                    NewField19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField19.DrawWidth = 2;
                    NewField19.TextFont.Name = "Arial Narrow";
                    NewField19.TextFont.Size = 9;
                    NewField19.Value = @" Parça No :";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 12, 182, 35, false);
                    NewField20.Name = "NewField20";
                    NewField20.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField20.DrawWidth = 2;
                    NewField20.TextFont.Name = "Arial Narrow";
                    NewField20.TextFont.Size = 9;
                    NewField20.Value = @" İsmi :";

                    StockCardName2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 17, 182, 35, false);
                    StockCardName2.Name = "StockCardName2";
                    StockCardName2.FillStyle = FillStyleConstants.vbFSTransparent;
                    StockCardName2.DrawWidth = 2;
                    StockCardName2.FieldType = ReportFieldTypeEnum.ftVariable;
                    StockCardName2.MultiLine = EvetHayirEnum.ehEvet;
                    StockCardName2.WordBreak = EvetHayirEnum.ehEvet;
                    StockCardName2.ExpandTabs = EvetHayirEnum.ehEvet;
                    StockCardName2.TextFont.Name = "Arial Narrow";
                    StockCardName2.Value = @"{#PARTA.CARDNAME#}";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 35, 107, 46, false);
                    NewField22.Name = "NewField22";
                    NewField22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField22.DrawWidth = 2;
                    NewField22.MultiLine = EvetHayirEnum.ehEvet;
                    NewField22.WordBreak = EvetHayirEnum.ehEvet;
                    NewField22.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField22.TextFont.Name = "Arial Narrow";
                    NewField22.TextFont.Size = 9;
                    NewField22.Value = @" Sayım Tarihi :
";

                    ClassName2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 35, 156, 46, false);
                    ClassName2.Name = "ClassName2";
                    ClassName2.DrawStyle = DrawStyleConstants.vbSolid;
                    ClassName2.DrawWidth = 2;
                    ClassName2.TextFont.Name = "Arial Narrow";
                    ClassName2.TextFont.Size = 9;
                    ClassName2.Value = @" Malın Sınıfı ve Grubu :";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 35, 182, 46, false);
                    NewField24.Name = "NewField24";
                    NewField24.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField24.DrawWidth = 2;
                    NewField24.MultiLine = EvetHayirEnum.ehEvet;
                    NewField24.WordBreak = EvetHayirEnum.ehEvet;
                    NewField24.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField24.TextFont.Name = "Arial Narrow";
                    NewField24.TextFont.Size = 9;
                    NewField24.Value = @" Ölçü Cinsi :";

                    DistributionType2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 40, 182, 46, false);
                    DistributionType2.Name = "DistributionType2";
                    DistributionType2.FillStyle = FillStyleConstants.vbFSTransparent;
                    DistributionType2.DrawWidth = 2;
                    DistributionType2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DistributionType2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DistributionType2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DistributionType2.TextFont.Name = "Arial Narrow";
                    DistributionType2.Value = @"{#PARTA.DISTRIBUTIONTYPE#}";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 46, 132, 77, false);
                    NewField26.Name = "NewField26";
                    NewField26.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField26.DrawWidth = 2;
                    NewField26.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField26.TextFont.Name = "Arial Narrow";
                    NewField26.TextFont.Size = 9;
                    NewField26.Value = @"Ana Yer";

                    NewField27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 46, 182, 77, false);
                    NewField27.Name = "NewField27";
                    NewField27.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField27.DrawWidth = 2;
                    NewField27.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField27.TextFont.Name = "Arial Narrow";
                    NewField27.TextFont.Size = 9;
                    NewField27.Value = @"Yedek Yer";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 185, -1, 185, 157, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbDot;

                    NewField29 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 77, 98, 104, false);
                    NewField29.Name = "NewField29";
                    NewField29.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField29.DrawWidth = 2;
                    NewField29.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField29.MultiLine = EvetHayirEnum.ehEvet;
                    NewField29.WordBreak = EvetHayirEnum.ehEvet;
                    NewField29.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField29.TextFont.Name = "Arial Narrow";
                    NewField29.TextFont.Size = 9;
                    NewField29.Value = @"

Sayılan
Miktar";

                    NewField30 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 77, 112, 86, false);
                    NewField30.Name = "NewField30";
                    NewField30.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField30.DrawWidth = 2;
                    NewField30.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField30.MultiLine = EvetHayirEnum.ehEvet;
                    NewField30.WordBreak = EvetHayirEnum.ehEvet;
                    NewField30.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField30.TextFont.Name = "Arial Narrow";
                    NewField30.TextFont.Size = 9;
                    NewField30.Value = @"Faal
Yeni";

                    NewField31 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 77, 126, 86, false);
                    NewField31.Name = "NewField31";
                    NewField31.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField31.DrawWidth = 2;
                    NewField31.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField31.MultiLine = EvetHayirEnum.ehEvet;
                    NewField31.WordBreak = EvetHayirEnum.ehEvet;
                    NewField31.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField31.TextFont.Name = "Arial Narrow";
                    NewField31.TextFont.Size = 9;
                    NewField31.Value = @"Kulla-
nılmış";

                    NewField32 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 77, 140, 86, false);
                    NewField32.Name = "NewField32";
                    NewField32.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField32.DrawWidth = 2;
                    NewField32.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField32.MultiLine = EvetHayirEnum.ehEvet;
                    NewField32.WordBreak = EvetHayirEnum.ehEvet;
                    NewField32.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField32.TextFont.Name = "Arial Narrow";
                    NewField32.TextFont.Size = 9;
                    NewField32.Value = @"Teknik
Kontrol";

                    NewField33 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 77, 154, 86, false);
                    NewField33.Name = "NewField33";
                    NewField33.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField33.DrawWidth = 2;
                    NewField33.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField33.MultiLine = EvetHayirEnum.ehEvet;
                    NewField33.WordBreak = EvetHayirEnum.ehEvet;
                    NewField33.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField33.TextFont.Name = "Arial Narrow";
                    NewField33.TextFont.Size = 9;
                    NewField33.Value = @"Kabili
Tamir";

                    NewField34 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 77, 168, 86, false);
                    NewField34.Name = "NewField34";
                    NewField34.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField34.DrawWidth = 2;
                    NewField34.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField34.MultiLine = EvetHayirEnum.ehEvet;
                    NewField34.WordBreak = EvetHayirEnum.ehEvet;
                    NewField34.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField34.TextFont.Name = "Arial Narrow";
                    NewField34.TextFont.Size = 9;
                    NewField34.Value = @"Ambalaj
Cinsi";

                    NewField35 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 77, 182, 86, false);
                    NewField35.Name = "NewField35";
                    NewField35.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField35.DrawWidth = 2;
                    NewField35.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField35.MultiLine = EvetHayirEnum.ehEvet;
                    NewField35.WordBreak = EvetHayirEnum.ehEvet;
                    NewField35.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField35.TextFont.Name = "Arial Narrow";
                    NewField35.TextFont.Size = 9;
                    NewField35.Value = @"Ambalaj
Adedi";

                    NewInheld2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 86, 112, 92, false);
                    NewInheld2.Name = "NewInheld2";
                    NewInheld2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewInheld2.DrawWidth = 2;
                    NewInheld2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewInheld2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewInheld2.TextFont.Name = "Arial Narrow";
                    NewInheld2.TextFont.Size = 9;
                    NewInheld2.Value = @"";

                    NewField37 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 92, 112, 98, false);
                    NewField37.Name = "NewField37";
                    NewField37.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField37.DrawWidth = 2;
                    NewField37.TextFont.Name = "Arial Narrow";
                    NewField37.TextFont.Size = 9;
                    NewField37.Value = @"";

                    NewField38 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 98, 112, 104, false);
                    NewField38.Name = "NewField38";
                    NewField38.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField38.DrawWidth = 2;
                    NewField38.TextFont.Name = "Arial Narrow";
                    NewField38.TextFont.Size = 9;
                    NewField38.Value = @"";

                    NewField39 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 104, 112, 110, false);
                    NewField39.Name = "NewField39";
                    NewField39.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField39.DrawWidth = 2;
                    NewField39.TextFont.Name = "Arial Narrow";
                    NewField39.TextFont.Size = 9;
                    NewField39.Value = @"";

                    NewField40 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 110, 112, 116, false);
                    NewField40.Name = "NewField40";
                    NewField40.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField40.DrawWidth = 2;
                    NewField40.TextFont.Name = "Arial Narrow";
                    NewField40.TextFont.Size = 9;
                    NewField40.Value = @"";

                    NewField41 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 116, 112, 122, false);
                    NewField41.Name = "NewField41";
                    NewField41.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField41.DrawWidth = 2;
                    NewField41.TextFont.Name = "Arial Narrow";
                    NewField41.TextFont.Size = 9;
                    NewField41.Value = @"";

                    NewField42 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 116, 98, 122, false);
                    NewField42.Name = "NewField42";
                    NewField42.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField42.DrawWidth = 2;
                    NewField42.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField42.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField42.MultiLine = EvetHayirEnum.ehEvet;
                    NewField42.WordBreak = EvetHayirEnum.ehEvet;
                    NewField42.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField42.TextFont.Name = "Arial Narrow";
                    NewField42.TextFont.Size = 9;
                    NewField42.Value = @"Eksik";

                    NewField43 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 110, 98, 116, false);
                    NewField43.Name = "NewField43";
                    NewField43.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField43.DrawWidth = 2;
                    NewField43.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField43.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField43.TextFont.Name = "Arial Narrow";
                    NewField43.TextFont.Size = 9;
                    NewField43.Value = @"Fazla";

                    NewField44 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 104, 98, 110, false);
                    NewField44.Name = "NewField44";
                    NewField44.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField44.DrawWidth = 2;
                    NewField44.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField44.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField44.TextFont.Name = "Arial Narrow";
                    NewField44.TextFont.Size = 9;
                    NewField44.Value = @"Yekün";

                    NewField45 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 122, 132, 151, false);
                    NewField45.Name = "NewField45";
                    NewField45.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField45.DrawWidth = 2;
                    NewField45.TextFont.Name = "Arial Narrow";
                    NewField45.TextFont.Size = 9;
                    NewField45.Value = @" Stok Kayıt Me. :";

                    NewField46 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 122, 182, 151, false);
                    NewField46.Name = "NewField46";
                    NewField46.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField46.DrawWidth = 2;
                    NewField46.TextFont.Name = "Arial Narrow";
                    NewField46.TextFont.Size = 9;
                    NewField46.Value = @" Sayan :";

                    NewField47 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 152, 144, 157, false);
                    NewField47.Name = "NewField47";
                    NewField47.MultiLine = EvetHayirEnum.ehEvet;
                    NewField47.WordBreak = EvetHayirEnum.ehEvet;
                    NewField47.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField47.TextFont.Name = "Arial Narrow";
                    NewField47.TextFont.Size = 9;
                    NewField47.Value = @"    Örnek No : L-101-12";

                    NewField50 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 92, 126, 98, false);
                    NewField50.Name = "NewField50";
                    NewField50.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField50.DrawWidth = 2;
                    NewField50.TextFont.Name = "Arial Narrow";
                    NewField50.TextFont.Size = 9;
                    NewField50.Value = @"";

                    NewField51 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 98, 126, 104, false);
                    NewField51.Name = "NewField51";
                    NewField51.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField51.DrawWidth = 2;
                    NewField51.TextFont.Name = "Arial Narrow";
                    NewField51.TextFont.Size = 9;
                    NewField51.Value = @"";

                    NewField52 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 104, 126, 110, false);
                    NewField52.Name = "NewField52";
                    NewField52.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField52.DrawWidth = 2;
                    NewField52.TextFont.Name = "Arial Narrow";
                    NewField52.TextFont.Size = 9;
                    NewField52.Value = @"";

                    NewField53 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 110, 126, 116, false);
                    NewField53.Name = "NewField53";
                    NewField53.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField53.DrawWidth = 2;
                    NewField53.TextFont.Name = "Arial Narrow";
                    NewField53.TextFont.Size = 9;
                    NewField53.Value = @"";

                    NewField54 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 116, 126, 122, false);
                    NewField54.Name = "NewField54";
                    NewField54.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField54.DrawWidth = 2;
                    NewField54.TextFont.Name = "Arial Narrow";
                    NewField54.TextFont.Size = 9;
                    NewField54.Value = @"";

                    NewField55 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 86, 140, 92, false);
                    NewField55.Name = "NewField55";
                    NewField55.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField55.DrawWidth = 2;
                    NewField55.TextFont.Name = "Arial Narrow";
                    NewField55.TextFont.Size = 9;
                    NewField55.Value = @"";

                    NewField56 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 92, 140, 98, false);
                    NewField56.Name = "NewField56";
                    NewField56.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField56.DrawWidth = 2;
                    NewField56.TextFont.Name = "Arial Narrow";
                    NewField56.TextFont.Size = 9;
                    NewField56.Value = @"";

                    NewField57 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 98, 140, 104, false);
                    NewField57.Name = "NewField57";
                    NewField57.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField57.DrawWidth = 2;
                    NewField57.TextFont.Name = "Arial Narrow";
                    NewField57.TextFont.Size = 9;
                    NewField57.Value = @"";

                    NewField58 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 104, 140, 110, false);
                    NewField58.Name = "NewField58";
                    NewField58.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField58.DrawWidth = 2;
                    NewField58.TextFont.Name = "Arial Narrow";
                    NewField58.TextFont.Size = 9;
                    NewField58.Value = @"";

                    NewField59 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 110, 140, 116, false);
                    NewField59.Name = "NewField59";
                    NewField59.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField59.DrawWidth = 2;
                    NewField59.TextFont.Name = "Arial Narrow";
                    NewField59.TextFont.Size = 9;
                    NewField59.Value = @"";

                    NewField60 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 116, 140, 122, false);
                    NewField60.Name = "NewField60";
                    NewField60.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField60.DrawWidth = 2;
                    NewField60.TextFont.Name = "Arial Narrow";
                    NewField60.TextFont.Size = 9;
                    NewField60.Value = @"";

                    NewField61 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 86, 154, 92, false);
                    NewField61.Name = "NewField61";
                    NewField61.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField61.DrawWidth = 2;
                    NewField61.TextFont.Name = "Arial Narrow";
                    NewField61.TextFont.Size = 9;
                    NewField61.Value = @"";

                    NewField62 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 92, 154, 98, false);
                    NewField62.Name = "NewField62";
                    NewField62.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField62.DrawWidth = 2;
                    NewField62.TextFont.Name = "Arial Narrow";
                    NewField62.TextFont.Size = 9;
                    NewField62.Value = @"";

                    NewField63 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 98, 154, 104, false);
                    NewField63.Name = "NewField63";
                    NewField63.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField63.DrawWidth = 2;
                    NewField63.TextFont.Name = "Arial Narrow";
                    NewField63.TextFont.Size = 9;
                    NewField63.Value = @"";

                    NewField64 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 104, 154, 110, false);
                    NewField64.Name = "NewField64";
                    NewField64.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField64.DrawWidth = 2;
                    NewField64.TextFont.Name = "Arial Narrow";
                    NewField64.TextFont.Size = 9;
                    NewField64.Value = @"";

                    NewField65 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 110, 154, 116, false);
                    NewField65.Name = "NewField65";
                    NewField65.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField65.DrawWidth = 2;
                    NewField65.TextFont.Name = "Arial Narrow";
                    NewField65.TextFont.Size = 9;
                    NewField65.Value = @"";

                    NewField66 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 116, 154, 122, false);
                    NewField66.Name = "NewField66";
                    NewField66.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField66.DrawWidth = 2;
                    NewField66.TextFont.Name = "Arial Narrow";
                    NewField66.TextFont.Size = 9;
                    NewField66.Value = @"";

                    NewField67 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 86, 168, 92, false);
                    NewField67.Name = "NewField67";
                    NewField67.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField67.DrawWidth = 2;
                    NewField67.TextFont.Name = "Arial Narrow";
                    NewField67.TextFont.Size = 9;
                    NewField67.Value = @"";

                    NewField68 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 92, 168, 98, false);
                    NewField68.Name = "NewField68";
                    NewField68.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField68.DrawWidth = 2;
                    NewField68.TextFont.Name = "Arial Narrow";
                    NewField68.TextFont.Size = 9;
                    NewField68.Value = @"";

                    NewField69 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 98, 168, 104, false);
                    NewField69.Name = "NewField69";
                    NewField69.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField69.DrawWidth = 2;
                    NewField69.TextFont.Name = "Arial Narrow";
                    NewField69.TextFont.Size = 9;
                    NewField69.Value = @"";

                    NewField70 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 104, 168, 110, false);
                    NewField70.Name = "NewField70";
                    NewField70.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField70.DrawWidth = 2;
                    NewField70.TextFont.Name = "Arial Narrow";
                    NewField70.TextFont.Size = 9;
                    NewField70.Value = @"";

                    NewField71 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 110, 168, 116, false);
                    NewField71.Name = "NewField71";
                    NewField71.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField71.DrawWidth = 2;
                    NewField71.TextFont.Name = "Arial Narrow";
                    NewField71.TextFont.Size = 9;
                    NewField71.Value = @"";

                    NewField72 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 116, 168, 122, false);
                    NewField72.Name = "NewField72";
                    NewField72.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField72.DrawWidth = 2;
                    NewField72.TextFont.Name = "Arial Narrow";
                    NewField72.TextFont.Size = 9;
                    NewField72.Value = @"";

                    NewField73 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 86, 182, 92, false);
                    NewField73.Name = "NewField73";
                    NewField73.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField73.DrawWidth = 2;
                    NewField73.TextFont.Name = "Arial Narrow";
                    NewField73.TextFont.Size = 9;
                    NewField73.Value = @"";

                    NewField74 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 92, 182, 98, false);
                    NewField74.Name = "NewField74";
                    NewField74.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField74.DrawWidth = 2;
                    NewField74.TextFont.Name = "Arial Narrow";
                    NewField74.TextFont.Size = 9;
                    NewField74.Value = @"";

                    NewField75 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 98, 182, 104, false);
                    NewField75.Name = "NewField75";
                    NewField75.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField75.DrawWidth = 2;
                    NewField75.TextFont.Name = "Arial Narrow";
                    NewField75.TextFont.Size = 9;
                    NewField75.Value = @"";

                    NewField76 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 104, 182, 110, false);
                    NewField76.Name = "NewField76";
                    NewField76.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField76.DrawWidth = 2;
                    NewField76.TextFont.Name = "Arial Narrow";
                    NewField76.TextFont.Size = 9;
                    NewField76.Value = @"";

                    NewField77 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 110, 182, 116, false);
                    NewField77.Name = "NewField77";
                    NewField77.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField77.DrawWidth = 2;
                    NewField77.TextFont.Name = "Arial Narrow";
                    NewField77.TextFont.Size = 9;
                    NewField77.Value = @"";

                    NewField78 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 116, 182, 122, false);
                    NewField78.Name = "NewField78";
                    NewField78.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField78.DrawWidth = 2;
                    NewField78.TextFont.Name = "Arial Narrow";
                    NewField78.TextFont.Size = 9;
                    NewField78.Value = @"";

                    NewField79 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 0, 288, 6, false);
                    NewField79.Name = "NewField79";
                    NewField79.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField79.DrawWidth = 2;
                    NewField79.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField79.TextFont.Name = "Arial Narrow";
                    NewField79.TextFont.Size = 9;
                    NewField79.Value = @" Stok No :";

                    NATOStockNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 201, 0, 250, 6, false);
                    NATOStockNO1.Name = "NATOStockNO1";
                    NATOStockNO1.FillStyle = FillStyleConstants.vbFSTransparent;
                    NATOStockNO1.DrawWidth = 2;
                    NATOStockNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOStockNO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOStockNO1.TextFont.Name = "Arial Narrow";
                    NATOStockNO1.Value = @"{#PARTA.NATOSTOCKNO#}";

                    NewField81 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 6, 288, 12, false);
                    NewField81.Name = "NewField81";
                    NewField81.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField81.DrawWidth = 2;
                    NewField81.TextFont.Name = "Arial Narrow";
                    NewField81.TextFont.Size = 9;
                    NewField81.Value = @" Parça No :";

                    NewField82 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 12, 288, 35, false);
                    NewField82.Name = "NewField82";
                    NewField82.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField82.DrawWidth = 2;
                    NewField82.TextFont.Name = "Arial Narrow";
                    NewField82.TextFont.Size = 9;
                    NewField82.Value = @" İsmi :";

                    StockCardName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 17, 288, 35, false);
                    StockCardName1.Name = "StockCardName1";
                    StockCardName1.FillStyle = FillStyleConstants.vbFSTransparent;
                    StockCardName1.DrawWidth = 2;
                    StockCardName1.FieldType = ReportFieldTypeEnum.ftVariable;
                    StockCardName1.MultiLine = EvetHayirEnum.ehEvet;
                    StockCardName1.WordBreak = EvetHayirEnum.ehEvet;
                    StockCardName1.ExpandTabs = EvetHayirEnum.ehEvet;
                    StockCardName1.TextFont.Name = "Arial Narrow";
                    StockCardName1.Value = @"{#PARTA.CARDNAME#}";

                    NewField84 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 35, 213, 46, false);
                    NewField84.Name = "NewField84";
                    NewField84.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField84.DrawWidth = 2;
                    NewField84.MultiLine = EvetHayirEnum.ehEvet;
                    NewField84.WordBreak = EvetHayirEnum.ehEvet;
                    NewField84.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField84.TextFont.Name = "Arial Narrow";
                    NewField84.TextFont.Size = 9;
                    NewField84.Value = @" Sayım Tarihi :
";

                    ClassName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 35, 261, 46, false);
                    ClassName1.Name = "ClassName1";
                    ClassName1.DrawStyle = DrawStyleConstants.vbSolid;
                    ClassName1.DrawWidth = 2;
                    ClassName1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ClassName1.TextFont.Name = "Arial Narrow";
                    ClassName1.TextFont.Size = 9;
                    ClassName1.Value = @" Malın Sınıfı ve Grubu :";

                    NewField86 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 261, 35, 288, 46, false);
                    NewField86.Name = "NewField86";
                    NewField86.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField86.DrawWidth = 2;
                    NewField86.MultiLine = EvetHayirEnum.ehEvet;
                    NewField86.WordBreak = EvetHayirEnum.ehEvet;
                    NewField86.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField86.TextFont.Name = "Arial Narrow";
                    NewField86.TextFont.Size = 9;
                    NewField86.Value = @" Ölçü Cinsi :";

                    DistributionType1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 261, 40, 288, 46, false);
                    DistributionType1.Name = "DistributionType1";
                    DistributionType1.FillStyle = FillStyleConstants.vbFSTransparent;
                    DistributionType1.DrawWidth = 2;
                    DistributionType1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DistributionType1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DistributionType1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DistributionType1.TextFont.Name = "Arial Narrow";
                    DistributionType1.Value = @"{#PARTA.DISTRIBUTIONTYPE#}";

                    NewField88 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 46, 238, 77, false);
                    NewField88.Name = "NewField88";
                    NewField88.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField88.DrawWidth = 2;
                    NewField88.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField88.TextFont.Name = "Arial Narrow";
                    NewField88.TextFont.Size = 9;
                    NewField88.Value = @"Ana Yer";

                    NewField89 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 46, 288, 77, false);
                    NewField89.Name = "NewField89";
                    NewField89.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField89.DrawWidth = 2;
                    NewField89.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField89.TextFont.Name = "Arial Narrow";
                    NewField89.TextFont.Size = 9;
                    NewField89.Value = @"Yedek Yer";

                    NewField91 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 77, 204, 104, false);
                    NewField91.Name = "NewField91";
                    NewField91.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField91.DrawWidth = 2;
                    NewField91.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField91.MultiLine = EvetHayirEnum.ehEvet;
                    NewField91.WordBreak = EvetHayirEnum.ehEvet;
                    NewField91.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField91.TextFont.Name = "Arial Narrow";
                    NewField91.TextFont.Size = 9;
                    NewField91.Value = @"

Sayılan
Miktar";

                    NewField92 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 77, 218, 86, false);
                    NewField92.Name = "NewField92";
                    NewField92.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField92.DrawWidth = 2;
                    NewField92.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField92.MultiLine = EvetHayirEnum.ehEvet;
                    NewField92.WordBreak = EvetHayirEnum.ehEvet;
                    NewField92.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField92.TextFont.Name = "Arial Narrow";
                    NewField92.TextFont.Size = 9;
                    NewField92.Value = @"Faal
Yeni";

                    NewField93 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 77, 232, 86, false);
                    NewField93.Name = "NewField93";
                    NewField93.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField93.DrawWidth = 2;
                    NewField93.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField93.MultiLine = EvetHayirEnum.ehEvet;
                    NewField93.WordBreak = EvetHayirEnum.ehEvet;
                    NewField93.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField93.TextFont.Name = "Arial Narrow";
                    NewField93.TextFont.Size = 9;
                    NewField93.Value = @"Kulla-
nılmış";

                    NewField94 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 77, 246, 86, false);
                    NewField94.Name = "NewField94";
                    NewField94.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField94.DrawWidth = 2;
                    NewField94.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField94.MultiLine = EvetHayirEnum.ehEvet;
                    NewField94.WordBreak = EvetHayirEnum.ehEvet;
                    NewField94.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField94.TextFont.Name = "Arial Narrow";
                    NewField94.TextFont.Size = 9;
                    NewField94.Value = @"Teknik
Kontrol";

                    NewField95 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 77, 260, 86, false);
                    NewField95.Name = "NewField95";
                    NewField95.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField95.DrawWidth = 2;
                    NewField95.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField95.MultiLine = EvetHayirEnum.ehEvet;
                    NewField95.WordBreak = EvetHayirEnum.ehEvet;
                    NewField95.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField95.TextFont.Name = "Arial Narrow";
                    NewField95.TextFont.Size = 9;
                    NewField95.Value = @"Kabili
Tamir";

                    NewField96 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, 77, 274, 86, false);
                    NewField96.Name = "NewField96";
                    NewField96.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField96.DrawWidth = 2;
                    NewField96.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField96.MultiLine = EvetHayirEnum.ehEvet;
                    NewField96.WordBreak = EvetHayirEnum.ehEvet;
                    NewField96.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField96.TextFont.Name = "Arial Narrow";
                    NewField96.TextFont.Size = 9;
                    NewField96.Value = @"Ambalaj
Cinsi";

                    NewField97 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 274, 77, 288, 86, false);
                    NewField97.Name = "NewField97";
                    NewField97.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField97.DrawWidth = 2;
                    NewField97.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField97.MultiLine = EvetHayirEnum.ehEvet;
                    NewField97.WordBreak = EvetHayirEnum.ehEvet;
                    NewField97.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField97.TextFont.Name = "Arial Narrow";
                    NewField97.TextFont.Size = 9;
                    NewField97.Value = @"Ambalaj
Adedi";

                    NewInheld1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 86, 218, 92, false);
                    NewInheld1.Name = "NewInheld1";
                    NewInheld1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewInheld1.DrawWidth = 2;
                    NewInheld1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewInheld1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewInheld1.TextFont.Name = "Arial Narrow";
                    NewInheld1.TextFont.Size = 9;
                    NewInheld1.Value = @"";

                    NewField99 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 92, 218, 98, false);
                    NewField99.Name = "NewField99";
                    NewField99.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField99.DrawWidth = 2;
                    NewField99.TextFont.Name = "Arial Narrow";
                    NewField99.TextFont.Size = 9;
                    NewField99.Value = @"";

                    NewField100 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 98, 218, 104, false);
                    NewField100.Name = "NewField100";
                    NewField100.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField100.DrawWidth = 2;
                    NewField100.TextFont.Name = "Arial Narrow";
                    NewField100.TextFont.Size = 9;
                    NewField100.Value = @"";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 104, 218, 110, false);
                    NewField101.Name = "NewField101";
                    NewField101.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField101.DrawWidth = 2;
                    NewField101.TextFont.Name = "Arial Narrow";
                    NewField101.TextFont.Size = 9;
                    NewField101.Value = @"";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 110, 218, 116, false);
                    NewField102.Name = "NewField102";
                    NewField102.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField102.DrawWidth = 2;
                    NewField102.TextFont.Name = "Arial Narrow";
                    NewField102.TextFont.Size = 9;
                    NewField102.Value = @"";

                    NewField103 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 116, 218, 122, false);
                    NewField103.Name = "NewField103";
                    NewField103.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField103.DrawWidth = 2;
                    NewField103.TextFont.Name = "Arial Narrow";
                    NewField103.TextFont.Size = 9;
                    NewField103.Value = @"";

                    NewField104 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 116, 204, 122, false);
                    NewField104.Name = "NewField104";
                    NewField104.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField104.DrawWidth = 2;
                    NewField104.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField104.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField104.MultiLine = EvetHayirEnum.ehEvet;
                    NewField104.WordBreak = EvetHayirEnum.ehEvet;
                    NewField104.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField104.TextFont.Name = "Arial Narrow";
                    NewField104.TextFont.Size = 9;
                    NewField104.Value = @"Eksik";

                    NewField105 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 110, 204, 116, false);
                    NewField105.Name = "NewField105";
                    NewField105.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField105.DrawWidth = 2;
                    NewField105.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField105.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField105.TextFont.Name = "Arial Narrow";
                    NewField105.TextFont.Size = 9;
                    NewField105.Value = @"Fazla";

                    NewField106 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 104, 204, 110, false);
                    NewField106.Name = "NewField106";
                    NewField106.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField106.DrawWidth = 2;
                    NewField106.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField106.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField106.TextFont.Name = "Arial Narrow";
                    NewField106.TextFont.Size = 9;
                    NewField106.Value = @"Yekün";

                    NewField107 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 122, 238, 151, false);
                    NewField107.Name = "NewField107";
                    NewField107.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField107.DrawWidth = 2;
                    NewField107.TextFont.Name = "Arial Narrow";
                    NewField107.TextFont.Size = 9;
                    NewField107.Value = @" Stok Kayıt Me. :";

                    NewField108 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 122, 288, 151, false);
                    NewField108.Name = "NewField108";
                    NewField108.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField108.DrawWidth = 2;
                    NewField108.TextFont.Name = "Arial Narrow";
                    NewField108.TextFont.Size = 9;
                    NewField108.Value = @" Sayan :";

                    NewField109 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 152, 250, 157, false);
                    NewField109.Name = "NewField109";
                    NewField109.DrawWidth = 2;
                    NewField109.MultiLine = EvetHayirEnum.ehEvet;
                    NewField109.WordBreak = EvetHayirEnum.ehEvet;
                    NewField109.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField109.TextFont.Name = "Arial Narrow";
                    NewField109.TextFont.Size = 9;
                    NewField109.Value = @"    Örnek No : L-101-12";

                    UsedInheld = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 86, 232, 92, false);
                    UsedInheld.Name = "UsedInheld";
                    UsedInheld.DrawStyle = DrawStyleConstants.vbSolid;
                    UsedInheld.DrawWidth = 2;
                    UsedInheld.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UsedInheld.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UsedInheld.TextFont.Name = "Arial Narrow";
                    UsedInheld.TextFont.Size = 9;
                    UsedInheld.Value = @"";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 92, 232, 98, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.DrawWidth = 2;
                    NewField111.TextFont.Name = "Arial Narrow";
                    NewField111.TextFont.Size = 9;
                    NewField111.Value = @"";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 98, 232, 104, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.DrawWidth = 2;
                    NewField112.TextFont.Name = "Arial Narrow";
                    NewField112.TextFont.Size = 9;
                    NewField112.Value = @"";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 104, 232, 110, false);
                    NewField113.Name = "NewField113";
                    NewField113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113.DrawWidth = 2;
                    NewField113.TextFont.Name = "Arial Narrow";
                    NewField113.TextFont.Size = 9;
                    NewField113.Value = @"";

                    NewField114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 110, 232, 116, false);
                    NewField114.Name = "NewField114";
                    NewField114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114.DrawWidth = 2;
                    NewField114.TextFont.Name = "Arial Narrow";
                    NewField114.TextFont.Size = 9;
                    NewField114.Value = @"";

                    NewField115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 116, 232, 122, false);
                    NewField115.Name = "NewField115";
                    NewField115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115.DrawWidth = 2;
                    NewField115.TextFont.Name = "Arial Narrow";
                    NewField115.TextFont.Size = 9;
                    NewField115.Value = @"";

                    NewField116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 86, 246, 92, false);
                    NewField116.Name = "NewField116";
                    NewField116.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField116.DrawWidth = 2;
                    NewField116.TextFont.Name = "Arial Narrow";
                    NewField116.TextFont.Size = 9;
                    NewField116.Value = @"";

                    NewField117 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 92, 246, 98, false);
                    NewField117.Name = "NewField117";
                    NewField117.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117.DrawWidth = 2;
                    NewField117.TextFont.Name = "Arial Narrow";
                    NewField117.TextFont.Size = 9;
                    NewField117.Value = @"";

                    NewField118 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 98, 246, 104, false);
                    NewField118.Name = "NewField118";
                    NewField118.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField118.DrawWidth = 2;
                    NewField118.TextFont.Name = "Arial Narrow";
                    NewField118.TextFont.Size = 9;
                    NewField118.Value = @"";

                    NewField119 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 104, 246, 110, false);
                    NewField119.Name = "NewField119";
                    NewField119.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField119.DrawWidth = 2;
                    NewField119.TextFont.Name = "Arial Narrow";
                    NewField119.TextFont.Size = 9;
                    NewField119.Value = @"";

                    NewField120 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 110, 246, 116, false);
                    NewField120.Name = "NewField120";
                    NewField120.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField120.DrawWidth = 2;
                    NewField120.TextFont.Name = "Arial Narrow";
                    NewField120.TextFont.Size = 9;
                    NewField120.Value = @"";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 116, 246, 122, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.DrawWidth = 2;
                    NewField121.TextFont.Name = "Arial Narrow";
                    NewField121.TextFont.Size = 9;
                    NewField121.Value = @"";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 86, 260, 92, false);
                    NewField122.Name = "NewField122";
                    NewField122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122.DrawWidth = 2;
                    NewField122.TextFont.Name = "Arial Narrow";
                    NewField122.TextFont.Size = 9;
                    NewField122.Value = @"";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 92, 260, 98, false);
                    NewField123.Name = "NewField123";
                    NewField123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField123.DrawWidth = 2;
                    NewField123.TextFont.Name = "Arial Narrow";
                    NewField123.TextFont.Size = 9;
                    NewField123.Value = @"";

                    NewField124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 98, 260, 104, false);
                    NewField124.Name = "NewField124";
                    NewField124.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField124.DrawWidth = 2;
                    NewField124.TextFont.Name = "Arial Narrow";
                    NewField124.TextFont.Size = 9;
                    NewField124.Value = @"";

                    NewField125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 104, 260, 110, false);
                    NewField125.Name = "NewField125";
                    NewField125.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField125.DrawWidth = 2;
                    NewField125.TextFont.Name = "Arial Narrow";
                    NewField125.TextFont.Size = 9;
                    NewField125.Value = @"";

                    NewField126 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 110, 260, 116, false);
                    NewField126.Name = "NewField126";
                    NewField126.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField126.DrawWidth = 2;
                    NewField126.TextFont.Name = "Arial Narrow";
                    NewField126.TextFont.Size = 9;
                    NewField126.Value = @"";

                    NewField127 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 116, 260, 122, false);
                    NewField127.Name = "NewField127";
                    NewField127.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField127.DrawWidth = 2;
                    NewField127.TextFont.Name = "Arial Narrow";
                    NewField127.TextFont.Size = 9;
                    NewField127.Value = @"";

                    NewField128 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, 86, 274, 92, false);
                    NewField128.Name = "NewField128";
                    NewField128.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField128.DrawWidth = 2;
                    NewField128.TextFont.Name = "Arial Narrow";
                    NewField128.TextFont.Size = 9;
                    NewField128.Value = @"";

                    NewField129 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, 92, 274, 98, false);
                    NewField129.Name = "NewField129";
                    NewField129.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField129.DrawWidth = 2;
                    NewField129.TextFont.Name = "Arial Narrow";
                    NewField129.TextFont.Size = 9;
                    NewField129.Value = @"";

                    NewField130 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, 98, 274, 104, false);
                    NewField130.Name = "NewField130";
                    NewField130.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField130.DrawWidth = 2;
                    NewField130.TextFont.Name = "Arial Narrow";
                    NewField130.TextFont.Size = 9;
                    NewField130.Value = @"";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, 104, 274, 110, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.DrawWidth = 2;
                    NewField131.TextFont.Name = "Arial Narrow";
                    NewField131.TextFont.Size = 9;
                    NewField131.Value = @"";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, 110, 274, 116, false);
                    NewField132.Name = "NewField132";
                    NewField132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField132.DrawWidth = 2;
                    NewField132.TextFont.Name = "Arial Narrow";
                    NewField132.TextFont.Size = 9;
                    NewField132.Value = @"";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, 116, 274, 122, false);
                    NewField133.Name = "NewField133";
                    NewField133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField133.DrawWidth = 2;
                    NewField133.TextFont.Name = "Arial Narrow";
                    NewField133.TextFont.Size = 9;
                    NewField133.Value = @"";

                    NewField134 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 274, 86, 288, 92, false);
                    NewField134.Name = "NewField134";
                    NewField134.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField134.DrawWidth = 2;
                    NewField134.TextFont.Name = "Arial Narrow";
                    NewField134.TextFont.Size = 9;
                    NewField134.Value = @"";

                    NewField135 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 274, 92, 288, 98, false);
                    NewField135.Name = "NewField135";
                    NewField135.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField135.DrawWidth = 2;
                    NewField135.TextFont.Name = "Arial Narrow";
                    NewField135.TextFont.Size = 9;
                    NewField135.Value = @"";

                    NewField136 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 274, 98, 288, 104, false);
                    NewField136.Name = "NewField136";
                    NewField136.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField136.DrawWidth = 2;
                    NewField136.TextFont.Name = "Arial Narrow";
                    NewField136.TextFont.Size = 9;
                    NewField136.Value = @"";

                    NewField137 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 274, 104, 288, 110, false);
                    NewField137.Name = "NewField137";
                    NewField137.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField137.DrawWidth = 2;
                    NewField137.TextFont.Name = "Arial Narrow";
                    NewField137.TextFont.Size = 9;
                    NewField137.Value = @"";

                    NewField138 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 274, 110, 288, 116, false);
                    NewField138.Name = "NewField138";
                    NewField138.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField138.DrawWidth = 2;
                    NewField138.TextFont.Name = "Arial Narrow";
                    NewField138.TextFont.Size = 9;
                    NewField138.Value = @"";

                    NewField139 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 274, 116, 288, 122, false);
                    NewField139.Name = "NewField139";
                    NewField139.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField139.DrawWidth = 2;
                    NewField139.TextFont.Name = "Arial Narrow";
                    NewField139.TextFont.Size = 9;
                    NewField139.Value = @"";

                    TransactionDate3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 40, 34, 46, false);
                    TransactionDate3.Name = "TransactionDate3";
                    TransactionDate3.FillStyle = FillStyleConstants.vbFSTransparent;
                    TransactionDate3.FieldType = ReportFieldTypeEnum.ftVariable;
                    TransactionDate3.TextFormat = @"dd/MM/yyyy";
                    TransactionDate3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TransactionDate3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TransactionDate3.TextFont.Name = "Arial Narrow";
                    TransactionDate3.Value = @"{#PARTA.TRANSACTIONDATE#}";

                    TransactionDate2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 40, 107, 46, false);
                    TransactionDate2.Name = "TransactionDate2";
                    TransactionDate2.FillStyle = FillStyleConstants.vbFSTransparent;
                    TransactionDate2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TransactionDate2.TextFormat = @"dd/MM/yyyy";
                    TransactionDate2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TransactionDate2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TransactionDate2.TextFont.Name = "Arial Narrow";
                    TransactionDate2.Value = @"{#PARTA.TRANSACTIONDATE#}";

                    TransactionDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 40, 213, 46, false);
                    TransactionDate1.Name = "TransactionDate1";
                    TransactionDate1.FillStyle = FillStyleConstants.vbFSTransparent;
                    TransactionDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TransactionDate1.TextFormat = @"dd/MM/yyyy";
                    TransactionDate1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TransactionDate1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TransactionDate1.TextFont.Name = "Arial Narrow";
                    TransactionDate1.Value = @"{#PARTA.TRANSACTIONDATE#}";

                    MAINCLASSNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 40, 155, 46, false);
                    MAINCLASSNAME2.Name = "MAINCLASSNAME2";
                    MAINCLASSNAME2.FillStyle = FillStyleConstants.vbFSTransparent;
                    MAINCLASSNAME2.MultiLine = EvetHayirEnum.ehEvet;
                    MAINCLASSNAME2.WordBreak = EvetHayirEnum.ehEvet;
                    MAINCLASSNAME2.ExpandTabs = EvetHayirEnum.ehEvet;
                    MAINCLASSNAME2.TextFont.Name = "Arial Narrow";
                    MAINCLASSNAME2.Value = @"";

                    MAINCLASSNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 40, 261, 46, false);
                    MAINCLASSNAME1.Name = "MAINCLASSNAME1";
                    MAINCLASSNAME1.FillStyle = FillStyleConstants.vbFSTransparent;
                    MAINCLASSNAME1.MultiLine = EvetHayirEnum.ehEvet;
                    MAINCLASSNAME1.WordBreak = EvetHayirEnum.ehEvet;
                    MAINCLASSNAME1.ExpandTabs = EvetHayirEnum.ehEvet;
                    MAINCLASSNAME1.TextFont.Name = "Arial Narrow";
                    MAINCLASSNAME1.Value = @"";

                    UsedInheld2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 86, 126, 92, false);
                    UsedInheld2.Name = "UsedInheld2";
                    UsedInheld2.DrawStyle = DrawStyleConstants.vbSolid;
                    UsedInheld2.DrawWidth = 2;
                    UsedInheld2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UsedInheld2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UsedInheld2.TextFont.Name = "Arial Narrow";
                    UsedInheld2.TextFont.Size = 9;
                    UsedInheld2.Value = @"";

                    SAYAN2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 127, 181, 150, false);
                    SAYAN2.Name = "SAYAN2";
                    SAYAN2.MultiLine = EvetHayirEnum.ehEvet;
                    SAYAN2.WordBreak = EvetHayirEnum.ehEvet;
                    SAYAN2.ExpandTabs = EvetHayirEnum.ehEvet;
                    SAYAN2.TextFont.Name = "Arial Narrow";
                    SAYAN2.TextFont.Size = 8;
                    SAYAN2.Value = @"";

                    SAYAN3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 127, 287, 150, false);
                    SAYAN3.Name = "SAYAN3";
                    SAYAN3.MultiLine = EvetHayirEnum.ehEvet;
                    SAYAN3.WordBreak = EvetHayirEnum.ehEvet;
                    SAYAN3.ExpandTabs = EvetHayirEnum.ehEvet;
                    SAYAN3.TextFont.Name = "Arial Narrow";
                    SAYAN3.TextFont.Size = 8;
                    SAYAN3.Value = @"";

                    MAINCLASSNAME3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 40, 46, 46, false);
                    MAINCLASSNAME3.Name = "MAINCLASSNAME3";
                    MAINCLASSNAME3.FillStyle = FillStyleConstants.vbFSTransparent;
                    MAINCLASSNAME3.MultiLine = EvetHayirEnum.ehEvet;
                    MAINCLASSNAME3.WordBreak = EvetHayirEnum.ehEvet;
                    MAINCLASSNAME3.ExpandTabs = EvetHayirEnum.ehEvet;
                    MAINCLASSNAME3.TextFont.Name = "Arial Narrow";
                    MAINCLASSNAME3.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CensusOrder.GetCensusOrderReportQuery_Class dataset_GetCensusOrderReportQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<CensusOrder.GetCensusOrderReportQuery_Class>(0);
                    NewField0.CalcValue = NewField0.Value;
                    NewField022.CalcValue = NewField022.Value;
                    NATOStockNO3.CalcValue = (dataset_GetCensusOrderReportQuery != null ? Globals.ToStringCore(dataset_GetCensusOrderReportQuery.NATOStockNO) : "");
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    StockCardName3.CalcValue = (dataset_GetCensusOrderReportQuery != null ? Globals.ToStringCore(dataset_GetCensusOrderReportQuery.Cardname) : "");
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    DistributionType3.CalcValue = (dataset_GetCensusOrderReportQuery != null ? Globals.ToStringCore(dataset_GetCensusOrderReportQuery.DistributionType) : "");
                    NewField9.CalcValue = NewField9.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField191.CalcValue = NewField191.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NATOStockNO2.CalcValue = (dataset_GetCensusOrderReportQuery != null ? Globals.ToStringCore(dataset_GetCensusOrderReportQuery.NATOStockNO) : "");
                    NewField19.CalcValue = NewField19.Value;
                    NewField20.CalcValue = NewField20.Value;
                    StockCardName2.CalcValue = (dataset_GetCensusOrderReportQuery != null ? Globals.ToStringCore(dataset_GetCensusOrderReportQuery.Cardname) : "");
                    NewField22.CalcValue = NewField22.Value;
                    ClassName2.CalcValue = ClassName2.Value;
                    NewField24.CalcValue = NewField24.Value;
                    DistributionType2.CalcValue = (dataset_GetCensusOrderReportQuery != null ? Globals.ToStringCore(dataset_GetCensusOrderReportQuery.DistributionType) : "");
                    NewField26.CalcValue = NewField26.Value;
                    NewField27.CalcValue = NewField27.Value;
                    NewField29.CalcValue = NewField29.Value;
                    NewField30.CalcValue = NewField30.Value;
                    NewField31.CalcValue = NewField31.Value;
                    NewField32.CalcValue = NewField32.Value;
                    NewField33.CalcValue = NewField33.Value;
                    NewField34.CalcValue = NewField34.Value;
                    NewField35.CalcValue = NewField35.Value;
                    NewInheld2.CalcValue = NewInheld2.Value;
                    NewField37.CalcValue = NewField37.Value;
                    NewField38.CalcValue = NewField38.Value;
                    NewField39.CalcValue = NewField39.Value;
                    NewField40.CalcValue = NewField40.Value;
                    NewField41.CalcValue = NewField41.Value;
                    NewField42.CalcValue = NewField42.Value;
                    NewField43.CalcValue = NewField43.Value;
                    NewField44.CalcValue = NewField44.Value;
                    NewField45.CalcValue = NewField45.Value;
                    NewField46.CalcValue = NewField46.Value;
                    NewField47.CalcValue = NewField47.Value;
                    NewField50.CalcValue = NewField50.Value;
                    NewField51.CalcValue = NewField51.Value;
                    NewField52.CalcValue = NewField52.Value;
                    NewField53.CalcValue = NewField53.Value;
                    NewField54.CalcValue = NewField54.Value;
                    NewField55.CalcValue = NewField55.Value;
                    NewField56.CalcValue = NewField56.Value;
                    NewField57.CalcValue = NewField57.Value;
                    NewField58.CalcValue = NewField58.Value;
                    NewField59.CalcValue = NewField59.Value;
                    NewField60.CalcValue = NewField60.Value;
                    NewField61.CalcValue = NewField61.Value;
                    NewField62.CalcValue = NewField62.Value;
                    NewField63.CalcValue = NewField63.Value;
                    NewField64.CalcValue = NewField64.Value;
                    NewField65.CalcValue = NewField65.Value;
                    NewField66.CalcValue = NewField66.Value;
                    NewField67.CalcValue = NewField67.Value;
                    NewField68.CalcValue = NewField68.Value;
                    NewField69.CalcValue = NewField69.Value;
                    NewField70.CalcValue = NewField70.Value;
                    NewField71.CalcValue = NewField71.Value;
                    NewField72.CalcValue = NewField72.Value;
                    NewField73.CalcValue = NewField73.Value;
                    NewField74.CalcValue = NewField74.Value;
                    NewField75.CalcValue = NewField75.Value;
                    NewField76.CalcValue = NewField76.Value;
                    NewField77.CalcValue = NewField77.Value;
                    NewField78.CalcValue = NewField78.Value;
                    NewField79.CalcValue = NewField79.Value;
                    NATOStockNO1.CalcValue = (dataset_GetCensusOrderReportQuery != null ? Globals.ToStringCore(dataset_GetCensusOrderReportQuery.NATOStockNO) : "");
                    NewField81.CalcValue = NewField81.Value;
                    NewField82.CalcValue = NewField82.Value;
                    StockCardName1.CalcValue = (dataset_GetCensusOrderReportQuery != null ? Globals.ToStringCore(dataset_GetCensusOrderReportQuery.Cardname) : "");
                    NewField84.CalcValue = NewField84.Value;
                    ClassName1.CalcValue = @" Malın Sınıfı ve Grubu :";
                    NewField86.CalcValue = NewField86.Value;
                    DistributionType1.CalcValue = (dataset_GetCensusOrderReportQuery != null ? Globals.ToStringCore(dataset_GetCensusOrderReportQuery.DistributionType) : "");
                    NewField88.CalcValue = NewField88.Value;
                    NewField89.CalcValue = NewField89.Value;
                    NewField91.CalcValue = NewField91.Value;
                    NewField92.CalcValue = NewField92.Value;
                    NewField93.CalcValue = NewField93.Value;
                    NewField94.CalcValue = NewField94.Value;
                    NewField95.CalcValue = NewField95.Value;
                    NewField96.CalcValue = NewField96.Value;
                    NewField97.CalcValue = NewField97.Value;
                    NewInheld1.CalcValue = NewInheld1.Value;
                    NewField99.CalcValue = NewField99.Value;
                    NewField100.CalcValue = NewField100.Value;
                    NewField101.CalcValue = NewField101.Value;
                    NewField102.CalcValue = NewField102.Value;
                    NewField103.CalcValue = NewField103.Value;
                    NewField104.CalcValue = NewField104.Value;
                    NewField105.CalcValue = NewField105.Value;
                    NewField106.CalcValue = NewField106.Value;
                    NewField107.CalcValue = NewField107.Value;
                    NewField108.CalcValue = NewField108.Value;
                    NewField109.CalcValue = NewField109.Value;
                    UsedInheld.CalcValue = UsedInheld.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField113.CalcValue = NewField113.Value;
                    NewField114.CalcValue = NewField114.Value;
                    NewField115.CalcValue = NewField115.Value;
                    NewField116.CalcValue = NewField116.Value;
                    NewField117.CalcValue = NewField117.Value;
                    NewField118.CalcValue = NewField118.Value;
                    NewField119.CalcValue = NewField119.Value;
                    NewField120.CalcValue = NewField120.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField123.CalcValue = NewField123.Value;
                    NewField124.CalcValue = NewField124.Value;
                    NewField125.CalcValue = NewField125.Value;
                    NewField126.CalcValue = NewField126.Value;
                    NewField127.CalcValue = NewField127.Value;
                    NewField128.CalcValue = NewField128.Value;
                    NewField129.CalcValue = NewField129.Value;
                    NewField130.CalcValue = NewField130.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField133.CalcValue = NewField133.Value;
                    NewField134.CalcValue = NewField134.Value;
                    NewField135.CalcValue = NewField135.Value;
                    NewField136.CalcValue = NewField136.Value;
                    NewField137.CalcValue = NewField137.Value;
                    NewField138.CalcValue = NewField138.Value;
                    NewField139.CalcValue = NewField139.Value;
                    TransactionDate3.CalcValue = (dataset_GetCensusOrderReportQuery != null ? Globals.ToStringCore(dataset_GetCensusOrderReportQuery.TransactionDate) : "");
                    TransactionDate2.CalcValue = (dataset_GetCensusOrderReportQuery != null ? Globals.ToStringCore(dataset_GetCensusOrderReportQuery.TransactionDate) : "");
                    TransactionDate1.CalcValue = (dataset_GetCensusOrderReportQuery != null ? Globals.ToStringCore(dataset_GetCensusOrderReportQuery.TransactionDate) : "");
                    MAINCLASSNAME2.CalcValue = MAINCLASSNAME2.Value;
                    MAINCLASSNAME1.CalcValue = MAINCLASSNAME1.Value;
                    UsedInheld2.CalcValue = UsedInheld2.Value;
                    SAYAN2.CalcValue = SAYAN2.Value;
                    SAYAN3.CalcValue = SAYAN3.Value;
                    MAINCLASSNAME3.CalcValue = MAINCLASSNAME3.Value;
                    return new TTReportObject[] { NewField0,NewField022,NATOStockNO3,NewField2,NewField3,StockCardName3,NewField5,NewField6,NewField7,DistributionType3,NewField9,NewField10,NewField191,NewField12,NewField13,NewField11,NewField17,NATOStockNO2,NewField19,NewField20,StockCardName2,NewField22,ClassName2,NewField24,DistributionType2,NewField26,NewField27,NewField29,NewField30,NewField31,NewField32,NewField33,NewField34,NewField35,NewInheld2,NewField37,NewField38,NewField39,NewField40,NewField41,NewField42,NewField43,NewField44,NewField45,NewField46,NewField47,NewField50,NewField51,NewField52,NewField53,NewField54,NewField55,NewField56,NewField57,NewField58,NewField59,NewField60,NewField61,NewField62,NewField63,NewField64,NewField65,NewField66,NewField67,NewField68,NewField69,NewField70,NewField71,NewField72,NewField73,NewField74,NewField75,NewField76,NewField77,NewField78,NewField79,NATOStockNO1,NewField81,NewField82,StockCardName1,NewField84,ClassName1,NewField86,DistributionType1,NewField88,NewField89,NewField91,NewField92,NewField93,NewField94,NewField95,NewField96,NewField97,NewInheld1,NewField99,NewField100,NewField101,NewField102,NewField103,NewField104,NewField105,NewField106,NewField107,NewField108,NewField109,UsedInheld,NewField111,NewField112,NewField113,NewField114,NewField115,NewField116,NewField117,NewField118,NewField119,NewField120,NewField121,NewField122,NewField123,NewField124,NewField125,NewField126,NewField127,NewField128,NewField129,NewField130,NewField131,NewField132,NewField133,NewField134,NewField135,NewField136,NewField137,NewField138,NewField139,TransactionDate3,TransactionDate2,TransactionDate1,MAINCLASSNAME2,MAINCLASSNAME1,UsedInheld2,SAYAN2,SAYAN3,MAINCLASSNAME3};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    if (TTUtils.Globals.IsGuid(MyParentReport.PARTA.ORDERDETAILOBJECTID.CalcValue))
            {
                CensusOrderDetail censusOrderDetail = (CensusOrderDetail)MyParentReport.ReportObjectContext.GetObject(new Guid(MyParentReport.PARTA.ORDERDETAILOBJECTID.CalcValue), typeof(CensusOrderDetail));
                MAINCLASSNAME1.Value = censusOrderDetail.Material.StockCard.StockCardClass.RootStockCardClass.Name;
                MAINCLASSNAME2.Value = censusOrderDetail.Material.StockCard.StockCardClass.RootStockCardClass.Name;
                MAINCLASSNAME3.Value = censusOrderDetail.Material.StockCard.StockCardClass.RootStockCardClass.QREF;
            }

            if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
            {
                CensusOrder censusOrder = (CensusOrder)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(CensusOrder));

                int i = 1;
                string signDesc = string.Empty;
                foreach (StockActionSignDetail stockActionSignDetail in censusOrder.StockActionSignDetails)
                {
                    if(stockActionSignDetail.SignUser.MilitaryClass != null)
                        signDesc += stockActionSignDetail.SignUser.MilitaryClass.ShortName;
                    if(stockActionSignDetail.SignUser.Rank != null)
                        signDesc += stockActionSignDetail.SignUser.Rank.ShortName;
                    signDesc += "(" + stockActionSignDetail.SignUser.EmploymentRecordID + ")\r\n";
                    signDesc += stockActionSignDetail.SignUser.Name;
                    if(i != censusOrder.StockActionSignDetails.Count)
                        signDesc += "\r\n\r\n";
                    i++;
                }
                if(string.IsNullOrEmpty(signDesc) == false)
                {
                    this.SAYAN2.Value = signDesc;
                    this.SAYAN3.Value = signDesc;
                }
            }
#endregion MAIN BODY_PreScript
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public CensusOrderReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "İşlem Numarasını Giriniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "CENSUSORDERREPORT";
            Caption = "Sayım Emri Fişi";
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