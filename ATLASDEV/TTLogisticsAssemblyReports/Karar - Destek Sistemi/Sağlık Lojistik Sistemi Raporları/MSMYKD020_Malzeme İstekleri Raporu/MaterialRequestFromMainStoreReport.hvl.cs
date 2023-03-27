
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
    /// Malzeme İstekleri (Ana Depodan)
    /// </summary>
    public partial class MaterialRequestFromMainStoreReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string STOCKCARDID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string TERMID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public MaterialRequestFromMainStoreReport MyParentReport
            {
                get { return (MaterialRequestFromMainStoreReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField ReportName { get {return Header().ReportName;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
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
                public MaterialRequestFromMainStoreReport MyParentReport
                {
                    get { return (MaterialRequestFromMainStoreReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField ReportName;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 24;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 170, 20, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Size = 15;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"MALZEME İSTEKLERİ (ANA DEPODAN)";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 2, 242, 7, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.ObjectDefName = "AccountingTerm";
                    STARTDATE.DataMember = "STARTDATE";
                    STARTDATE.Value = @"{@TERMID@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 9, 242, 14, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.ObjectDefName = "AccountingTerm";
                    ENDDATE.DataMember = "ENDDATE";
                    ENDDATE.Value = @"{@TERMID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    ReportName.CalcValue = ReportName.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.TERMID.ToString();
                    STARTDATE.PostFieldValueCalculation();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.TERMID.ToString();
                    ENDDATE.PostFieldValueCalculation();
                    return new TTReportObject[] { LOGO,ReportName,STARTDATE,ENDDATE};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MaterialRequestFromMainStoreReport MyParentReport
                {
                    get { return (MaterialRequestFromMainStoreReport)ParentReport; }
                }
                
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportField PrintDate;
                public TTReportShape NewLine11; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 35;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 0, 95, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 170, 0, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

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

        public partial class PARTBGroup : TTReportGroup
        {
            public MaterialRequestFromMainStoreReport MyParentReport
            {
                get { return (MaterialRequestFromMainStoreReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField123 { get {return Header().NewField123;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField RequestAmountTotal { get {return Footer().RequestAmountTotal;} }
            public TTReportField AmountTotal { get {return Footer().AmountTotal;} }
            public TTReportField SpendAmountTotal { get {return Footer().SpendAmountTotal;} }
            public TTReportField ReturningAmountTotal { get {return Footer().ReturningAmountTotal;} }
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
                public MaterialRequestFromMainStoreReport MyParentReport
                {
                    get { return (MaterialRequestFromMainStoreReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportField NewField123;
                public TTReportShape NewLine1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 5;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"NATO Stok Nu.";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 0, 90, 5, false);
                    NewField2.Name = "NewField2";
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Malzeme İsmi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 0, 170, 5, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"İade Edilen";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 0, 150, 5, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Size = 11;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Sarf Edilen";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 0, 130, 5, false);
                    NewField122.Name = "NewField122";
                    NewField122.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Size = 11;
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Karşılanan";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 0, 110, 5, false);
                    NewField123.Name = "NewField123";
                    NewField123.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField123.TextFont.Size = 11;
                    NewField123.TextFont.Bold = true;
                    NewField123.TextFont.CharSet = 162;
                    NewField123.Value = @"İstenen";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 5, 170, 5, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField123.CalcValue = NewField123.Value;
                    return new TTReportObject[] { NewField1,NewField2,NewField12,NewField121,NewField122,NewField123};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public MaterialRequestFromMainStoreReport MyParentReport
                {
                    get { return (MaterialRequestFromMainStoreReport)ParentReport; }
                }
                
                public TTReportField NewField3;
                public TTReportField RequestAmountTotal;
                public TTReportField AmountTotal;
                public TTReportField SpendAmountTotal;
                public TTReportField ReturningAmountTotal; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 1, 90, 6, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Toplam:";

                    RequestAmountTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 1, 110, 6, false);
                    RequestAmountTotal.Name = "RequestAmountTotal";
                    RequestAmountTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    RequestAmountTotal.TextFormat = @"#,###";
                    RequestAmountTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RequestAmountTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RequestAmountTotal.Value = @"{@sumof(RequestAmount)@}";

                    AmountTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 1, 130, 6, false);
                    AmountTotal.Name = "AmountTotal";
                    AmountTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    AmountTotal.TextFormat = @"#,###";
                    AmountTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AmountTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AmountTotal.Value = @"{@sumof(Amount)@}";

                    SpendAmountTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 1, 150, 6, false);
                    SpendAmountTotal.Name = "SpendAmountTotal";
                    SpendAmountTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    SpendAmountTotal.TextFormat = @"#,###";
                    SpendAmountTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SpendAmountTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SpendAmountTotal.Value = @"{@sumof(SpendAmount)@}";

                    ReturningAmountTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 1, 170, 6, false);
                    ReturningAmountTotal.Name = "ReturningAmountTotal";
                    ReturningAmountTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReturningAmountTotal.TextFormat = @"#,###";
                    ReturningAmountTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ReturningAmountTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReturningAmountTotal.Value = @"{@sumof(ReturningAmount)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField3.CalcValue = NewField3.Value;
                    RequestAmountTotal.CalcValue = ParentGroup.FieldSums["RequestAmount"].Value.ToString();;
                    AmountTotal.CalcValue = ParentGroup.FieldSums["Amount"].Value.ToString();;
                    SpendAmountTotal.CalcValue = ParentGroup.FieldSums["SpendAmount"].Value.ToString();;
                    ReturningAmountTotal.CalcValue = ParentGroup.FieldSums["ReturningAmount"].Value.ToString();;
                    return new TTReportObject[] { NewField3,RequestAmountTotal,AmountTotal,SpendAmountTotal,ReturningAmountTotal};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAIN1Group : TTReportGroup
        {
            public MaterialRequestFromMainStoreReport MyParentReport
            {
                get { return (MaterialRequestFromMainStoreReport)ParentReport; }
            }

            new public MAIN1GroupBody Body()
            {
                return (MAIN1GroupBody)_body;
            }
            public TTReportField NATOStockNO { get {return Body().NATOStockNO;} }
            public TTReportField MaterialName { get {return Body().MaterialName;} }
            public TTReportField RequestAmount { get {return Body().RequestAmount;} }
            public TTReportField Amount { get {return Body().Amount;} }
            public TTReportField SpendAmount { get {return Body().SpendAmount;} }
            public TTReportField ReturningAmount { get {return Body().ReturningAmount;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportField DistributionAmount { get {return Body().DistributionAmount;} }
            public TTReportField DistributionRequest { get {return Body().DistributionRequest;} }
            public TTReportField SectionRequest { get {return Body().SectionRequest;} }
            public TTReportField SectionAmount { get {return Body().SectionAmount;} }
            public TTReportField VoucherAmount { get {return Body().VoucherAmount;} }
            public TTReportField VoucherRequest { get {return Body().VoucherRequest;} }
            public MAIN1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAIN1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[6];
                list[0] = new TTReportNqlData<StockTransaction.GetStockCardForMaterialRequestReportQuery_Class>("GetStockCardForMaterialRequestReportQuery", StockTransaction.GetStockCardForMaterialRequestReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.STARTDATE.FormattedValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.ENDDATE.FormattedValue),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID)));
                list[1] = new TTReportNqlData<StockTransaction.GetSpendAmountForMaterialRequestReportQuery_Class>("GetSpendAmountForMaterialRequestReportQuery", StockTransaction.GetSpendAmountForMaterialRequestReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.STARTDATE.FormattedValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.ENDDATE.FormattedValue),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID)));
                list[2] = new TTReportNqlData<StockActionDetailOut.GetReturningForMaterialRequestReportQuery_Class>("GetReturningForMaterialRequestReportQuery", StockActionDetailOut.GetReturningForMaterialRequestReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.STARTDATE.FormattedValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.ENDDATE.FormattedValue),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID)));
                list[3] = new TTReportNqlData<DistributionDocumentMaterial.GetDistributionForMaterialRequestReportQuery_Class>("GetDistributionForMaterialRequestReportQuery", DistributionDocumentMaterial.GetDistributionForMaterialRequestReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.STARTDATE.FormattedValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.ENDDATE.FormattedValue),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID)));
                list[4] = new TTReportNqlData<VoucherDistributingDocumentMaterial.GetVoucherDistributeForMaterialRequestReportQuery_Class>("GetVoucherDistributeForMaterialRequestReportQuery", VoucherDistributingDocumentMaterial.GetVoucherDistributeForMaterialRequestReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.ENDDATE.FormattedValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.STARTDATE.FormattedValue),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID)));
                list[5] = new TTReportNqlData<SectionRequirementMaterial.GetSectionRequirementForMaterialRequestReportQuery_Class>("GetSectionRequirementForMaterialRequestReportQuery", SectionRequirementMaterial.GetSectionRequirementForMaterialRequestReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.STARTDATE.FormattedValue),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.PARTA.ENDDATE.FormattedValue),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAIN1GroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAIN1GroupBody : TTReportSection
            {
                public MaterialRequestFromMainStoreReport MyParentReport
                {
                    get { return (MaterialRequestFromMainStoreReport)ParentReport; }
                }
                
                public TTReportField NATOStockNO;
                public TTReportField MaterialName;
                public TTReportField RequestAmount;
                public TTReportField Amount;
                public TTReportField SpendAmount;
                public TTReportField ReturningAmount;
                public TTReportShape NewLine11;
                public TTReportField DistributionAmount;
                public TTReportField DistributionRequest;
                public TTReportField SectionRequest;
                public TTReportField SectionAmount;
                public TTReportField VoucherAmount;
                public TTReportField VoucherRequest; 
                public MAIN1GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    NATOStockNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 25, 6, false);
                    NATOStockNO.Name = "NATOStockNO";
                    NATOStockNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOStockNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOStockNO.Value = @"{#NATOSTOCKNO#}";

                    MaterialName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 1, 90, 6, false);
                    MaterialName.Name = "MaterialName";
                    MaterialName.FieldType = ReportFieldTypeEnum.ftVariable;
                    MaterialName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    MaterialName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MaterialName.WordBreak = EvetHayirEnum.ehEvet;
                    MaterialName.Value = @"{#NAME#}";

                    RequestAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 1, 110, 6, false);
                    RequestAmount.Name = "RequestAmount";
                    RequestAmount.FieldType = ReportFieldTypeEnum.ftExpression;
                    RequestAmount.TextFormat = @"#,###";
                    RequestAmount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RequestAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RequestAmount.Value = @"(Convert.ToDouble(""0"" + DistributionRequest.CalcValue) + Convert.ToDouble(""0"" + SectionRequest.CalcValue) + Convert.ToDouble(""0"" + VoucherRequest.CalcValue)).ToString()";

                    Amount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 1, 130, 6, false);
                    Amount.Name = "Amount";
                    Amount.FieldType = ReportFieldTypeEnum.ftExpression;
                    Amount.TextFormat = @"#,###";
                    Amount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Amount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Amount.Value = @"(Convert.ToDouble(""0"" + DistributionAmount.CalcValue) + Convert.ToDouble(""0"" + SectionAmount.CalcValue) + Convert.ToDouble(""0"" + VoucherAmount.CalcValue)).ToString()";

                    SpendAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 1, 150, 6, false);
                    SpendAmount.Name = "SpendAmount";
                    SpendAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    SpendAmount.TextFormat = @"#,###";
                    SpendAmount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SpendAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SpendAmount.Value = @"{#SPENDAMOUNT!GetSpendAmountForMaterialRequestReportQuery#}";

                    ReturningAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 1, 170, 6, false);
                    ReturningAmount.Name = "ReturningAmount";
                    ReturningAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReturningAmount.TextFormat = @"#,###";
                    ReturningAmount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ReturningAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReturningAmount.Value = @"{#RETURNINGAMOUNT!GetReturningForMaterialRequestReportQuery#}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 170, 7, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    DistributionAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 1, 242, 6, false);
                    DistributionAmount.Name = "DistributionAmount";
                    DistributionAmount.Visible = EvetHayirEnum.ehHayir;
                    DistributionAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    DistributionAmount.Value = @"{#AMOUNT!GetDistributionForMaterialRequestReportQuery#}";

                    DistributionRequest = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 6, 242, 11, false);
                    DistributionRequest.Name = "DistributionRequest";
                    DistributionRequest.Visible = EvetHayirEnum.ehHayir;
                    DistributionRequest.FieldType = ReportFieldTypeEnum.ftVariable;
                    DistributionRequest.Value = @"{#REQUESTAMOUNT!GetDistributionForMaterialRequestReportQuery#}";

                    SectionRequest = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 6, 270, 11, false);
                    SectionRequest.Name = "SectionRequest";
                    SectionRequest.Visible = EvetHayirEnum.ehHayir;
                    SectionRequest.FieldType = ReportFieldTypeEnum.ftVariable;
                    SectionRequest.Value = @"{#REQUESTAMOUNT!GetSectionRequirementForMaterialRequestReportQuery#}";

                    SectionAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 245, 1, 270, 6, false);
                    SectionAmount.Name = "SectionAmount";
                    SectionAmount.Visible = EvetHayirEnum.ehHayir;
                    SectionAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    SectionAmount.Value = @"{#AMOUNT!GetSectionRequirementForMaterialRequestReportQuery#}";

                    VoucherAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 273, 1, 298, 6, false);
                    VoucherAmount.Name = "VoucherAmount";
                    VoucherAmount.Visible = EvetHayirEnum.ehHayir;
                    VoucherAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    VoucherAmount.Value = @"{#AMOUNT!GetVoucherDistributeForMaterialRequestReportQuery#}";

                    VoucherRequest = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 273, 6, 298, 11, false);
                    VoucherRequest.Name = "VoucherRequest";
                    VoucherRequest.Visible = EvetHayirEnum.ehHayir;
                    VoucherRequest.FieldType = ReportFieldTypeEnum.ftVariable;
                    VoucherRequest.Value = @"{#REQUESTAMOUNT!GetVoucherDistributeForMaterialRequestReportQuery#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockTransaction.GetStockCardForMaterialRequestReportQuery_Class dataset_GetStockCardForMaterialRequestReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.GetStockCardForMaterialRequestReportQuery_Class>(0);
                    StockTransaction.GetSpendAmountForMaterialRequestReportQuery_Class dataset_GetSpendAmountForMaterialRequestReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.GetSpendAmountForMaterialRequestReportQuery_Class>(1);
                    StockActionDetailOut.GetReturningForMaterialRequestReportQuery_Class dataset_GetReturningForMaterialRequestReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockActionDetailOut.GetReturningForMaterialRequestReportQuery_Class>(2);
                    DistributionDocumentMaterial.GetDistributionForMaterialRequestReportQuery_Class dataset_GetDistributionForMaterialRequestReportQuery = ParentGroup.rsGroup.GetCurrentRecord<DistributionDocumentMaterial.GetDistributionForMaterialRequestReportQuery_Class>(3);
                    VoucherDistributingDocumentMaterial.GetVoucherDistributeForMaterialRequestReportQuery_Class dataset_GetVoucherDistributeForMaterialRequestReportQuery = ParentGroup.rsGroup.GetCurrentRecord<VoucherDistributingDocumentMaterial.GetVoucherDistributeForMaterialRequestReportQuery_Class>(4);
                    SectionRequirementMaterial.GetSectionRequirementForMaterialRequestReportQuery_Class dataset_GetSectionRequirementForMaterialRequestReportQuery = ParentGroup.rsGroup.GetCurrentRecord<SectionRequirementMaterial.GetSectionRequirementForMaterialRequestReportQuery_Class>(5);
                    NATOStockNO.CalcValue = (dataset_GetStockCardForMaterialRequestReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardForMaterialRequestReportQuery.NATOStockNO) : "");
                    MaterialName.CalcValue = (dataset_GetStockCardForMaterialRequestReportQuery != null ? Globals.ToStringCore(dataset_GetStockCardForMaterialRequestReportQuery.Name) : "");
                    SpendAmount.CalcValue = (dataset_GetSpendAmountForMaterialRequestReportQuery != null ? Globals.ToStringCore(dataset_GetSpendAmountForMaterialRequestReportQuery.Spendamount) : "");
                    ReturningAmount.CalcValue = (dataset_GetReturningForMaterialRequestReportQuery != null ? Globals.ToStringCore(dataset_GetReturningForMaterialRequestReportQuery.Returningamount) : "");
                    DistributionAmount.CalcValue = (dataset_GetDistributionForMaterialRequestReportQuery != null ? Globals.ToStringCore(dataset_GetDistributionForMaterialRequestReportQuery.Amount) : "");
                    DistributionRequest.CalcValue = (dataset_GetDistributionForMaterialRequestReportQuery != null ? Globals.ToStringCore(dataset_GetDistributionForMaterialRequestReportQuery.Requestamount) : "");
                    SectionRequest.CalcValue = (dataset_GetSectionRequirementForMaterialRequestReportQuery != null ? Globals.ToStringCore(dataset_GetSectionRequirementForMaterialRequestReportQuery.Requestamount) : "");
                    SectionAmount.CalcValue = (dataset_GetSectionRequirementForMaterialRequestReportQuery != null ? Globals.ToStringCore(dataset_GetSectionRequirementForMaterialRequestReportQuery.Amount) : "");
                    VoucherAmount.CalcValue = (dataset_GetVoucherDistributeForMaterialRequestReportQuery != null ? Globals.ToStringCore(dataset_GetVoucherDistributeForMaterialRequestReportQuery.Amount) : "");
                    VoucherRequest.CalcValue = (dataset_GetVoucherDistributeForMaterialRequestReportQuery != null ? Globals.ToStringCore(dataset_GetVoucherDistributeForMaterialRequestReportQuery.Requestamount) : "");
                    RequestAmount.CalcValue = (Convert.ToDouble("0" + DistributionRequest.CalcValue) + Convert.ToDouble("0" + SectionRequest.CalcValue) + Convert.ToDouble("0" + VoucherRequest.CalcValue)).ToString();
                    Amount.CalcValue = (Convert.ToDouble("0" + DistributionAmount.CalcValue) + Convert.ToDouble("0" + SectionAmount.CalcValue) + Convert.ToDouble("0" + VoucherAmount.CalcValue)).ToString();
                    return new TTReportObject[] { NATOStockNO,MaterialName,SpendAmount,ReturningAmount,DistributionAmount,DistributionRequest,SectionRequest,SectionAmount,VoucherAmount,VoucherRequest,RequestAmount,Amount};
                }
            }

        }

        public MAIN1Group MAIN1;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public MaterialRequestFromMainStoreReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN1 = new MAIN1Group(PARTB,"MAIN1");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOCKCARDID", "", "Stok Kartını Seçiniz", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("e8c3b02e-4a08-4c98-bfd0-15d84fafb295");
            reportParameter = Parameters.Add("TERMID", "", "Hesap Dönemi Seçiniz", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOCKCARDID"))
                _runtimeParameters.STOCKCARDID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["STOCKCARDID"]);
            if (parameters.ContainsKey("TERMID"))
                _runtimeParameters.TERMID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TERMID"]);
            Name = "MATERIALREQUESTFROMMAINSTOREREPORT";
            Caption = "Malzeme İstekleri (Ana Depodan)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 25;
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