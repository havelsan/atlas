
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
    /// İhale Onay Belgesi
    /// </summary>
    public partial class OnayBelgesiRaporuIhale : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public OnayBelgesiRaporuIhale MyParentReport
            {
                get { return (OnayBelgesiRaporuIhale)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField Onay11 { get {return Header().Onay11;} }
            public TTReportRTF ExplanationRTF { get {return Header().ExplanationRTF;} }
            public TTReportField ReportName1 { get {return Header().ReportName1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField ResponsibleProcurement { get {return Header().ResponsibleProcurement;} }
            public TTReportField ConfirmDateAndNumber { get {return Header().ConfirmDateAndNumber;} }
            public TTReportField ToResponsibleProcurement { get {return Header().ToResponsibleProcurement;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField PreActDefineAttribute { get {return Header().PreActDefineAttribute;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField ActDefineAttribute { get {return Header().ActDefineAttribute;} }
            public TTReportField NewField1241 { get {return Header().NewField1241;} }
            public TTReportField PreActCount { get {return Header().PreActCount;} }
            public TTReportField NewField11421 { get {return Header().NewField11421;} }
            public TTReportField ActCount { get {return Header().ActCount;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField PreCommTotalApproximatePrice { get {return Header().PreCommTotalApproximatePrice;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField CommTotalApproximatePriceCondition { get {return Header().CommTotalApproximatePriceCondition;} }
            public TTReportField NewField12211 { get {return Header().NewField12211;} }
            public TTReportField PreUsableBudgetAmount { get {return Header().PreUsableBudgetAmount;} }
            public TTReportField NewField111221 { get {return Header().NewField111221;} }
            public TTReportField UsableBudgetAmount { get {return Header().UsableBudgetAmount;} }
            public TTReportField NewField121221 { get {return Header().NewField121221;} }
            public TTReportField PreInvestmentProjectNO { get {return Header().PreInvestmentProjectNO;} }
            public TTReportField NewField1122121 { get {return Header().NewField1122121;} }
            public TTReportField InvestmentProjectNOCondition { get {return Header().InvestmentProjectNOCondition;} }
            public TTReportField NewField1222121 { get {return Header().NewField1222121;} }
            public TTReportField PreBudgetExpensePen { get {return Header().PreBudgetExpensePen;} }
            public TTReportField NewField11212221 { get {return Header().NewField11212221;} }
            public TTReportField BudgetExpensePenCondition { get {return Header().BudgetExpensePenCondition;} }
            public TTReportField NewField1341 { get {return Header().NewField1341;} }
            public TTReportField WhichDate { get {return Header().WhichDate;} }
            public TTReportField NewField112221211 { get {return Header().NewField112221211;} }
            public TTReportField AdvancedCondition { get {return Header().AdvancedCondition;} }
            public TTReportField NewField122221211 { get {return Header().NewField122221211;} }
            public TTReportField PurchaseTypeDefinition { get {return Header().PurchaseTypeDefinition;} }
            public TTReportField NewField132221211 { get {return Header().NewField132221211;} }
            public TTReportField AnnounceTypeandCount { get {return Header().AnnounceTypeandCount;} }
            public TTReportField NewField142221211 { get {return Header().NewField142221211;} }
            public TTReportField SpecificationPrice { get {return Header().SpecificationPrice;} }
            public TTReportField NewField152221211 { get {return Header().NewField152221211;} }
            public TTReportField PriceDifferenceCondition { get {return Header().PriceDifferenceCondition;} }
            public TTReportField NewField1231 { get {return Header().NewField1231;} }
            public TTReportField NewField1331 { get {return Header().NewField1331;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField NewField1261 { get {return Header().NewField1261;} }
            public TTReportField NewField11621 { get {return Header().NewField11621;} }
            public TTReportField NewField12621 { get {return Header().NewField12621;} }
            public TTReportField PerformerName { get {return Header().PerformerName;} }
            public TTReportField PerformerRank { get {return Header().PerformerRank;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField NewField1361 { get {return Header().NewField1361;} }
            public TTReportField NewField11611 { get {return Header().NewField11611;} }
            public TTReportField NewField13621 { get {return Header().NewField13621;} }
            public TTReportField NewField112611 { get {return Header().NewField112611;} }
            public TTReportField NewField112621 { get {return Header().NewField112621;} }
            public TTReportField ExpenserName { get {return Header().ExpenserName;} }
            public TTReportField ExpenserRank { get {return Header().ExpenserRank;} }
            public TTReportField PerformerDuty { get {return Header().PerformerDuty;} }
            public TTReportField ExpenserDuty { get {return Header().ExpenserDuty;} }
            public TTReportField ShowApproximatePriceOnReport { get {return Header().ShowApproximatePriceOnReport;} }
            public TTReportField Advanced { get {return Header().Advanced;} }
            public TTReportField PriceDifference { get {return Header().PriceDifference;} }
            public TTReportField ConfirmDate { get {return Header().ConfirmDate;} }
            public TTReportField ConfirmNO { get {return Header().ConfirmNO;} }
            public TTReportField PerformerID { get {return Header().PerformerID;} }
            public TTReportField ExpenserID { get {return Header().ExpenserID;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField InvestmentProjectNO { get {return Header().InvestmentProjectNO;} }
            public TTReportField BudgetExpensePen { get {return Header().BudgetExpensePen;} }
            public TTReportField NewField1151 { get {return Footer().NewField1151;} }
            public TTReportField Onay111 { get {return Footer().Onay111;} }
            public TTReportField NewField11321 { get {return Footer().NewField11321;} }
            public TTReportField NewField132 { get {return Footer().NewField132;} }
            public TTReportField NewField1162 { get {return Footer().NewField1162;} }
            public TTReportField NewField11612 { get {return Footer().NewField11612;} }
            public TTReportField NewField11622 { get {return Footer().NewField11622;} }
            public TTReportField NewField112612 { get {return Footer().NewField112612;} }
            public TTReportField NewField112622 { get {return Footer().NewField112622;} }
            public TTReportField PerformerName1 { get {return Footer().PerformerName1;} }
            public TTReportField PerformerRank1 { get {return Footer().PerformerRank1;} }
            public TTReportField NewField1171 { get {return Footer().NewField1171;} }
            public TTReportField NewField11631 { get {return Footer().NewField11631;} }
            public TTReportField NewField111611 { get {return Footer().NewField111611;} }
            public TTReportField NewField112631 { get {return Footer().NewField112631;} }
            public TTReportField NewField1116211 { get {return Footer().NewField1116211;} }
            public TTReportField NewField1126211 { get {return Footer().NewField1126211;} }
            public TTReportField ExpenserName1 { get {return Footer().ExpenserName1;} }
            public TTReportField ExpenserRank1 { get {return Footer().ExpenserRank1;} }
            public TTReportField NewField1126222 { get {return Footer().NewField1126222;} }
            public TTReportField NewField11226211 { get {return Footer().NewField11226211;} }
            public TTReportField PerformerDuty1 { get {return Footer().PerformerDuty1;} }
            public TTReportField ExpenserDuty1 { get {return Footer().ExpenserDuty1;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportShape NewLine13 { get {return Footer().NewLine13;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
            public TTReportField PROJECTNO { get {return Footer().PROJECTNO;} }
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
                list[0] = new TTReportNqlData<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>("PurchaseProjectGlobalReportNQL", PurchaseProject.PurchaseProjectGlobalReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public OnayBelgesiRaporuIhale MyParentReport
                {
                    get { return (OnayBelgesiRaporuIhale)ParentReport; }
                }
                
                public TTReportField NewField151;
                public TTReportField Onay11;
                public TTReportRTF ExplanationRTF;
                public TTReportField ReportName1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField ResponsibleProcurement;
                public TTReportField ConfirmDateAndNumber;
                public TTReportField ToResponsibleProcurement;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField PreActDefineAttribute;
                public TTReportField NewField1141;
                public TTReportField NewField1131;
                public TTReportField ActDefineAttribute;
                public TTReportField NewField1241;
                public TTReportField PreActCount;
                public TTReportField NewField11421;
                public TTReportField ActCount;
                public TTReportField NewField1121;
                public TTReportField PreCommTotalApproximatePrice;
                public TTReportField NewField11211;
                public TTReportField CommTotalApproximatePriceCondition;
                public TTReportField NewField12211;
                public TTReportField PreUsableBudgetAmount;
                public TTReportField NewField111221;
                public TTReportField UsableBudgetAmount;
                public TTReportField NewField121221;
                public TTReportField PreInvestmentProjectNO;
                public TTReportField NewField1122121;
                public TTReportField InvestmentProjectNOCondition;
                public TTReportField NewField1222121;
                public TTReportField PreBudgetExpensePen;
                public TTReportField NewField11212221;
                public TTReportField BudgetExpensePenCondition;
                public TTReportField NewField1341;
                public TTReportField WhichDate;
                public TTReportField NewField112221211;
                public TTReportField AdvancedCondition;
                public TTReportField NewField122221211;
                public TTReportField PurchaseTypeDefinition;
                public TTReportField NewField132221211;
                public TTReportField AnnounceTypeandCount;
                public TTReportField NewField142221211;
                public TTReportField SpecificationPrice;
                public TTReportField NewField152221211;
                public TTReportField PriceDifferenceCondition;
                public TTReportField NewField1231;
                public TTReportField NewField1331;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
                public TTReportField NewField13;
                public TTReportField NewField161;
                public TTReportField NewField1161;
                public TTReportField NewField1261;
                public TTReportField NewField11621;
                public TTReportField NewField12621;
                public TTReportField PerformerName;
                public TTReportField PerformerRank;
                public TTReportField NewField171;
                public TTReportField NewField1361;
                public TTReportField NewField11611;
                public TTReportField NewField13621;
                public TTReportField NewField112611;
                public TTReportField NewField112621;
                public TTReportField ExpenserName;
                public TTReportField ExpenserRank;
                public TTReportField PerformerDuty;
                public TTReportField ExpenserDuty;
                public TTReportField ShowApproximatePriceOnReport;
                public TTReportField Advanced;
                public TTReportField PriceDifference;
                public TTReportField ConfirmDate;
                public TTReportField ConfirmNO;
                public TTReportField PerformerID;
                public TTReportField ExpenserID;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine11111;
                public TTReportField InvestmentProjectNO;
                public TTReportField BudgetExpensePen; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 163;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 84, 110, 160, false);
                    NewField151.Name = "NewField151";
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.MultiLine = EvetHayirEnum.ehEvet;
                    NewField151.WordBreak = EvetHayirEnum.ehEvet;
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.Size = 8;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"Uygundur.
_ _ . _ _ . _ _ _ _

İhale Yetkilisi";

                    Onay11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 84, 60, 160, false);
                    Onay11.Name = "Onay11";
                    Onay11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Onay11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Onay11.MultiLine = EvetHayirEnum.ehEvet;
                    Onay11.WordBreak = EvetHayirEnum.ehEvet;
                    Onay11.TextFont.Name = "Arial";
                    Onay11.TextFont.Size = 8;
                    Onay11.TextFont.CharSet = 162;
                    Onay11.Value = @"Yukarıda belirtilen malın alınması için ihaleye çıkılması hususunu onaylarınıza arz ederim.
_ _ . _ _ . _ _ _ _";

                    ExplanationRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 111, 100, 288, 160, false);
                    ExplanationRTF.Name = "ExplanationRTF";
                    ExplanationRTF.DrawStyle = DrawStyleConstants.vbSolid;
                    ExplanationRTF.Value = @"";

                    ReportName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 4, 287, 10, false);
                    ReportName1.Name = "ReportName1";
                    ReportName1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName1.TextFont.Name = "Arial";
                    ReportName1.TextFont.Bold = true;
                    ReportName1.TextFont.CharSet = 162;
                    ReportName1.Value = @"İHALE ONAY BELGESİ";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 5, 20, 10, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.Underline = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"GİZLİ";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 12, 60, 16, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 8;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"İHALEYİ YAPAN İDARENİN ADI";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 16, 60, 20, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 8;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Belge Tarih ve Sayısı";

                    ResponsibleProcurement = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 12, 287, 16, false);
                    ResponsibleProcurement.Name = "ResponsibleProcurement";
                    ResponsibleProcurement.DrawStyle = DrawStyleConstants.vbSolid;
                    ResponsibleProcurement.FieldType = ReportFieldTypeEnum.ftVariable;
                    ResponsibleProcurement.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ResponsibleProcurement.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ResponsibleProcurement.WordBreak = EvetHayirEnum.ehEvet;
                    ResponsibleProcurement.TextFont.Name = "Arial";
                    ResponsibleProcurement.TextFont.Size = 8;
                    ResponsibleProcurement.TextFont.CharSet = 162;
                    ResponsibleProcurement.Value = @"{#RESPONSIBLEPROCUREMENTUNITDEF#}";

                    ConfirmDateAndNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 16, 287, 20, false);
                    ConfirmDateAndNumber.Name = "ConfirmDateAndNumber";
                    ConfirmDateAndNumber.DrawStyle = DrawStyleConstants.vbSolid;
                    ConfirmDateAndNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    ConfirmDateAndNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ConfirmDateAndNumber.WordBreak = EvetHayirEnum.ehEvet;
                    ConfirmDateAndNumber.TextFont.Name = "Arial";
                    ConfirmDateAndNumber.TextFont.Size = 8;
                    ConfirmDateAndNumber.TextFont.CharSet = 162;
                    ConfirmDateAndNumber.Value = @"{%ConfirmDate%} / {%ConfirmNO%}";

                    ToResponsibleProcurement = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 20, 287, 24, false);
                    ToResponsibleProcurement.Name = "ToResponsibleProcurement";
                    ToResponsibleProcurement.DrawStyle = DrawStyleConstants.vbSolid;
                    ToResponsibleProcurement.FieldType = ReportFieldTypeEnum.ftExpression;
                    ToResponsibleProcurement.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ToResponsibleProcurement.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ToResponsibleProcurement.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ToResponsibleProcurement.WordBreak = EvetHayirEnum.ehEvet;
                    ToResponsibleProcurement.TextFont.Name = "Arial";
                    ToResponsibleProcurement.TextFont.Size = 8;
                    ToResponsibleProcurement.TextFont.Bold = true;
                    ToResponsibleProcurement.TextFont.CharSet = 162;
                    ToResponsibleProcurement.Value = @"{%ResponsibleProcurement%} != """" ? {%ResponsibleProcurement%} + "" MAKAMINA"" : """"";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 24, 110, 28, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Size = 8;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"İHALE İLE İLGİLİ BELGELER (Ön İlan Aşaması)";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 28, 60, 36, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Size = 8;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"İşin Adı, Tanımı, Niteliği";

                    PreActDefineAttribute = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 28, 110, 36, false);
                    PreActDefineAttribute.Name = "PreActDefineAttribute";
                    PreActDefineAttribute.DrawStyle = DrawStyleConstants.vbSolid;
                    PreActDefineAttribute.FieldType = ReportFieldTypeEnum.ftVariable;
                    PreActDefineAttribute.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PreActDefineAttribute.MultiLine = EvetHayirEnum.ehEvet;
                    PreActDefineAttribute.WordBreak = EvetHayirEnum.ehEvet;
                    PreActDefineAttribute.TextFont.Name = "Arial";
                    PreActDefineAttribute.TextFont.Size = 8;
                    PreActDefineAttribute.TextFont.CharSet = 162;
                    PreActDefineAttribute.Value = @"";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 28, 160, 36, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.TextFont.Size = 8;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"İşin Adı, Tanımı, Niteliği";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 24, 287, 28, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Size = 8;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"İHALE İLE İLGİLİ BELGELER (Ön İlan Aşaması)";

                    ActDefineAttribute = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 28, 287, 36, false);
                    ActDefineAttribute.Name = "ActDefineAttribute";
                    ActDefineAttribute.DrawStyle = DrawStyleConstants.vbSolid;
                    ActDefineAttribute.FieldType = ReportFieldTypeEnum.ftVariable;
                    ActDefineAttribute.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ActDefineAttribute.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ActDefineAttribute.MultiLine = EvetHayirEnum.ehEvet;
                    ActDefineAttribute.WordBreak = EvetHayirEnum.ehEvet;
                    ActDefineAttribute.TextFont.Name = "Arial";
                    ActDefineAttribute.TextFont.Size = 8;
                    ActDefineAttribute.TextFont.CharSet = 162;
                    ActDefineAttribute.Value = @"{#ACTDEFINE#}
{#ACTATTRIBUTE#}";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 36, 60, 56, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1241.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1241.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1241.TextFont.Name = "Arial";
                    NewField1241.TextFont.Size = 8;
                    NewField1241.TextFont.Bold = true;
                    NewField1241.TextFont.CharSet = 162;
                    NewField1241.Value = @"İşin Tahmini Miktarı";

                    PreActCount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 36, 110, 56, false);
                    PreActCount.Name = "PreActCount";
                    PreActCount.DrawStyle = DrawStyleConstants.vbSolid;
                    PreActCount.FieldType = ReportFieldTypeEnum.ftVariable;
                    PreActCount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PreActCount.MultiLine = EvetHayirEnum.ehEvet;
                    PreActCount.TextFont.Name = "Arial";
                    PreActCount.TextFont.Size = 8;
                    PreActCount.TextFont.CharSet = 162;
                    PreActCount.Value = @"";

                    NewField11421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 36, 160, 56, false);
                    NewField11421.Name = "NewField11421";
                    NewField11421.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11421.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11421.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11421.TextFont.Name = "Arial";
                    NewField11421.TextFont.Size = 8;
                    NewField11421.TextFont.Bold = true;
                    NewField11421.TextFont.CharSet = 162;
                    NewField11421.Value = @"İşin Miktarı";

                    ActCount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 36, 287, 56, false);
                    ActCount.Name = "ActCount";
                    ActCount.DrawStyle = DrawStyleConstants.vbSolid;
                    ActCount.FieldType = ReportFieldTypeEnum.ftVariable;
                    ActCount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ActCount.MultiLine = EvetHayirEnum.ehEvet;
                    ActCount.TextFont.Name = "Arial";
                    ActCount.TextFont.Size = 8;
                    ActCount.TextFont.CharSet = 162;
                    ActCount.Value = @"{#ACTCOUNT#}";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 56, 60, 60, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Size = 8;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Yaklaşık Maliyeti";

                    PreCommTotalApproximatePrice = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 56, 110, 60, false);
                    PreCommTotalApproximatePrice.Name = "PreCommTotalApproximatePrice";
                    PreCommTotalApproximatePrice.DrawStyle = DrawStyleConstants.vbSolid;
                    PreCommTotalApproximatePrice.FieldType = ReportFieldTypeEnum.ftVariable;
                    PreCommTotalApproximatePrice.TextFormat = @"#,##0.#0";
                    PreCommTotalApproximatePrice.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PreCommTotalApproximatePrice.TextFont.Name = "Arial";
                    PreCommTotalApproximatePrice.TextFont.Size = 8;
                    PreCommTotalApproximatePrice.TextFont.CharSet = 162;
                    PreCommTotalApproximatePrice.Value = @"";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 56, 160, 60, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11211.TextFont.Name = "Arial";
                    NewField11211.TextFont.Size = 8;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Yaklaşık Maliyeti";

                    CommTotalApproximatePriceCondition = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 56, 287, 60, false);
                    CommTotalApproximatePriceCondition.Name = "CommTotalApproximatePriceCondition";
                    CommTotalApproximatePriceCondition.DrawStyle = DrawStyleConstants.vbSolid;
                    CommTotalApproximatePriceCondition.FieldType = ReportFieldTypeEnum.ftVariable;
                    CommTotalApproximatePriceCondition.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CommTotalApproximatePriceCondition.TextFont.Name = "Arial";
                    CommTotalApproximatePriceCondition.TextFont.Size = 8;
                    CommTotalApproximatePriceCondition.TextFont.CharSet = 162;
                    CommTotalApproximatePriceCondition.Value = @"";

                    NewField12211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 60, 60, 64, false);
                    NewField12211.Name = "NewField12211";
                    NewField12211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12211.TextFont.Name = "Arial";
                    NewField12211.TextFont.Size = 8;
                    NewField12211.TextFont.Bold = true;
                    NewField12211.TextFont.CharSet = 162;
                    NewField12211.Value = @"Kullanılabilir Ödenek Tutarı";

                    PreUsableBudgetAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 60, 110, 64, false);
                    PreUsableBudgetAmount.Name = "PreUsableBudgetAmount";
                    PreUsableBudgetAmount.DrawStyle = DrawStyleConstants.vbSolid;
                    PreUsableBudgetAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    PreUsableBudgetAmount.TextFormat = @"#,##0.#0";
                    PreUsableBudgetAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PreUsableBudgetAmount.TextFont.Name = "Arial";
                    PreUsableBudgetAmount.TextFont.Size = 8;
                    PreUsableBudgetAmount.TextFont.CharSet = 162;
                    PreUsableBudgetAmount.Value = @"";

                    NewField111221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 60, 160, 64, false);
                    NewField111221.Name = "NewField111221";
                    NewField111221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111221.TextFont.Name = "Arial";
                    NewField111221.TextFont.Size = 8;
                    NewField111221.TextFont.Bold = true;
                    NewField111221.TextFont.CharSet = 162;
                    NewField111221.Value = @"Kullanılabilir Ödenek Tutarı";

                    UsableBudgetAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 60, 287, 64, false);
                    UsableBudgetAmount.Name = "UsableBudgetAmount";
                    UsableBudgetAmount.DrawStyle = DrawStyleConstants.vbSolid;
                    UsableBudgetAmount.FieldType = ReportFieldTypeEnum.ftExpression;
                    UsableBudgetAmount.TextFormat = @"#,##0.#0";
                    UsableBudgetAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UsableBudgetAmount.TextFont.Name = "Arial";
                    UsableBudgetAmount.TextFont.Size = 8;
                    UsableBudgetAmount.TextFont.CharSet = 162;
                    UsableBudgetAmount.Value = @"{#USABLEBUDGETAMOUNT#} != null ? {#USABLEBUDGETAMOUNT#} : ""( - )""
";

                    NewField121221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 64, 60, 68, false);
                    NewField121221.Name = "NewField121221";
                    NewField121221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121221.TextFont.Name = "Arial";
                    NewField121221.TextFont.Size = 8;
                    NewField121221.TextFont.Bold = true;
                    NewField121221.TextFont.CharSet = 162;
                    NewField121221.Value = @"Yatırım Proje Numarası (Varsa)";

                    PreInvestmentProjectNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 64, 110, 68, false);
                    PreInvestmentProjectNO.Name = "PreInvestmentProjectNO";
                    PreInvestmentProjectNO.DrawStyle = DrawStyleConstants.vbSolid;
                    PreInvestmentProjectNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PreInvestmentProjectNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PreInvestmentProjectNO.TextFont.Name = "Arial";
                    PreInvestmentProjectNO.TextFont.Size = 8;
                    PreInvestmentProjectNO.TextFont.CharSet = 162;
                    PreInvestmentProjectNO.Value = @"";

                    NewField1122121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 64, 160, 68, false);
                    NewField1122121.Name = "NewField1122121";
                    NewField1122121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1122121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1122121.TextFont.Name = "Arial";
                    NewField1122121.TextFont.Size = 8;
                    NewField1122121.TextFont.Bold = true;
                    NewField1122121.TextFont.CharSet = 162;
                    NewField1122121.Value = @"Yatırım Proje Numarası (Varsa)";

                    InvestmentProjectNOCondition = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 64, 287, 68, false);
                    InvestmentProjectNOCondition.Name = "InvestmentProjectNOCondition";
                    InvestmentProjectNOCondition.DrawStyle = DrawStyleConstants.vbSolid;
                    InvestmentProjectNOCondition.FieldType = ReportFieldTypeEnum.ftExpression;
                    InvestmentProjectNOCondition.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    InvestmentProjectNOCondition.TextFont.Name = "Arial";
                    InvestmentProjectNOCondition.TextFont.Size = 8;
                    InvestmentProjectNOCondition.TextFont.CharSet = 162;
                    InvestmentProjectNOCondition.Value = @"{#INVESTMENTPROJECTNO#} != """" ? {#INVESTMENTPROJECTNO#} : ""( - )""";

                    NewField1222121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 68, 60, 72, false);
                    NewField1222121.Name = "NewField1222121";
                    NewField1222121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1222121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1222121.TextFont.Name = "Arial";
                    NewField1222121.TextFont.Size = 8;
                    NewField1222121.TextFont.Bold = true;
                    NewField1222121.TextFont.CharSet = 162;
                    NewField1222121.Value = @"Bütçe Tertibi (Varsa)";

                    PreBudgetExpensePen = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 68, 110, 72, false);
                    PreBudgetExpensePen.Name = "PreBudgetExpensePen";
                    PreBudgetExpensePen.DrawStyle = DrawStyleConstants.vbSolid;
                    PreBudgetExpensePen.FieldType = ReportFieldTypeEnum.ftVariable;
                    PreBudgetExpensePen.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PreBudgetExpensePen.TextFont.Name = "Arial";
                    PreBudgetExpensePen.TextFont.Size = 8;
                    PreBudgetExpensePen.TextFont.CharSet = 162;
                    PreBudgetExpensePen.Value = @"";

                    NewField11212221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 68, 160, 72, false);
                    NewField11212221.Name = "NewField11212221";
                    NewField11212221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11212221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11212221.TextFont.Name = "Arial";
                    NewField11212221.TextFont.Size = 8;
                    NewField11212221.TextFont.Bold = true;
                    NewField11212221.TextFont.CharSet = 162;
                    NewField11212221.Value = @"Bütçe Tertibi (Varsa)";

                    BudgetExpensePenCondition = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 68, 287, 72, false);
                    BudgetExpensePenCondition.Name = "BudgetExpensePenCondition";
                    BudgetExpensePenCondition.DrawStyle = DrawStyleConstants.vbSolid;
                    BudgetExpensePenCondition.FieldType = ReportFieldTypeEnum.ftExpression;
                    BudgetExpensePenCondition.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BudgetExpensePenCondition.TextFont.Name = "Arial";
                    BudgetExpensePenCondition.TextFont.Size = 8;
                    BudgetExpensePenCondition.TextFont.CharSet = 162;
                    BudgetExpensePenCondition.Value = @"{#BUDGETEXPENSEPEN#} != """" ? {#BUDGETEXPENSEPEN#} : ""( - )""";

                    NewField1341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 72, 60, 80, false);
                    NewField1341.Name = "NewField1341";
                    NewField1341.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1341.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1341.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1341.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1341.TextFont.Name = "Arial";
                    NewField1341.TextFont.Size = 8;
                    NewField1341.TextFont.Bold = true;
                    NewField1341.TextFont.CharSet = 162;
                    NewField1341.Value = @"İhale Usulü ve İlanın Yılın Hangi Çeyreğinde Yayınlanacağı";

                    WhichDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 72, 110, 80, false);
                    WhichDate.Name = "WhichDate";
                    WhichDate.DrawStyle = DrawStyleConstants.vbSolid;
                    WhichDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    WhichDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WhichDate.MultiLine = EvetHayirEnum.ehEvet;
                    WhichDate.WordBreak = EvetHayirEnum.ehEvet;
                    WhichDate.TextFont.Name = "Arial";
                    WhichDate.TextFont.Size = 8;
                    WhichDate.TextFont.CharSet = 162;
                    WhichDate.Value = @"";

                    NewField112221211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 72, 160, 76, false);
                    NewField112221211.Name = "NewField112221211";
                    NewField112221211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112221211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112221211.TextFont.Name = "Arial";
                    NewField112221211.TextFont.Size = 8;
                    NewField112221211.TextFont.Bold = true;
                    NewField112221211.TextFont.CharSet = 162;
                    NewField112221211.Value = @"Avans Verilecekse Şartları";

                    AdvancedCondition = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 72, 287, 76, false);
                    AdvancedCondition.Name = "AdvancedCondition";
                    AdvancedCondition.DrawStyle = DrawStyleConstants.vbSolid;
                    AdvancedCondition.FieldType = ReportFieldTypeEnum.ftVariable;
                    AdvancedCondition.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AdvancedCondition.TextFont.Name = "Arial";
                    AdvancedCondition.TextFont.Size = 8;
                    AdvancedCondition.TextFont.CharSet = 162;
                    AdvancedCondition.Value = @"";

                    NewField122221211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 76, 160, 80, false);
                    NewField122221211.Name = "NewField122221211";
                    NewField122221211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122221211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122221211.TextFont.Name = "Arial";
                    NewField122221211.TextFont.Size = 8;
                    NewField122221211.TextFont.Bold = true;
                    NewField122221211.TextFont.CharSet = 162;
                    NewField122221211.Value = @"İhale Usulü";

                    PurchaseTypeDefinition = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 76, 287, 80, false);
                    PurchaseTypeDefinition.Name = "PurchaseTypeDefinition";
                    PurchaseTypeDefinition.DrawStyle = DrawStyleConstants.vbSolid;
                    PurchaseTypeDefinition.FieldType = ReportFieldTypeEnum.ftVariable;
                    PurchaseTypeDefinition.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PurchaseTypeDefinition.TextFont.Name = "Arial";
                    PurchaseTypeDefinition.TextFont.Size = 8;
                    PurchaseTypeDefinition.TextFont.CharSet = 162;
                    PurchaseTypeDefinition.Value = @"{#PURCHASETYPEDEFINITION#}";

                    NewField132221211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 80, 160, 84, false);
                    NewField132221211.Name = "NewField132221211";
                    NewField132221211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField132221211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField132221211.TextFont.Name = "Arial";
                    NewField132221211.TextFont.Size = 8;
                    NewField132221211.TextFont.Bold = true;
                    NewField132221211.TextFont.CharSet = 162;
                    NewField132221211.Value = @"İlanın Şekli ve Adedi";

                    AnnounceTypeandCount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 80, 287, 84, false);
                    AnnounceTypeandCount.Name = "AnnounceTypeandCount";
                    AnnounceTypeandCount.DrawStyle = DrawStyleConstants.vbSolid;
                    AnnounceTypeandCount.FieldType = ReportFieldTypeEnum.ftVariable;
                    AnnounceTypeandCount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AnnounceTypeandCount.ObjectDefName = "AnnounceTypeandCountEnum";
                    AnnounceTypeandCount.DataMember = "DISPLAYTEXT";
                    AnnounceTypeandCount.TextFont.Name = "Arial";
                    AnnounceTypeandCount.TextFont.Size = 8;
                    AnnounceTypeandCount.TextFont.CharSet = 162;
                    AnnounceTypeandCount.Value = @"{#ANNOUNCETYPEANDCOUNT#}";

                    NewField142221211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 84, 160, 88, false);
                    NewField142221211.Name = "NewField142221211";
                    NewField142221211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField142221211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField142221211.TextFont.Name = "Arial";
                    NewField142221211.TextFont.Size = 8;
                    NewField142221211.TextFont.Bold = true;
                    NewField142221211.TextFont.CharSet = 162;
                    NewField142221211.Value = @"İhale Dökümanı Satış Bedeli";

                    SpecificationPrice = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 84, 287, 88, false);
                    SpecificationPrice.Name = "SpecificationPrice";
                    SpecificationPrice.DrawStyle = DrawStyleConstants.vbSolid;
                    SpecificationPrice.FieldType = ReportFieldTypeEnum.ftVariable;
                    SpecificationPrice.TextFormat = @"#,##0.#0";
                    SpecificationPrice.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SpecificationPrice.TextFont.Name = "Arial";
                    SpecificationPrice.TextFont.Size = 8;
                    SpecificationPrice.TextFont.CharSet = 162;
                    SpecificationPrice.Value = @"{#SPECIFICATIONPRICE#}";

                    NewField152221211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 88, 160, 96, false);
                    NewField152221211.Name = "NewField152221211";
                    NewField152221211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField152221211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField152221211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField152221211.TextFont.Name = "Arial";
                    NewField152221211.TextFont.Size = 8;
                    NewField152221211.TextFont.Bold = true;
                    NewField152221211.TextFont.CharSet = 162;
                    NewField152221211.Value = @"Fiyat Farkı Ödenecekse Dayanağı
Bakanlar Kurulu Kararı";

                    PriceDifferenceCondition = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 88, 287, 96, false);
                    PriceDifferenceCondition.Name = "PriceDifferenceCondition";
                    PriceDifferenceCondition.DrawStyle = DrawStyleConstants.vbSolid;
                    PriceDifferenceCondition.FieldType = ReportFieldTypeEnum.ftVariable;
                    PriceDifferenceCondition.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PriceDifferenceCondition.MultiLine = EvetHayirEnum.ehEvet;
                    PriceDifferenceCondition.WordBreak = EvetHayirEnum.ehEvet;
                    PriceDifferenceCondition.TextFont.Name = "Arial";
                    PriceDifferenceCondition.TextFont.Size = 8;
                    PriceDifferenceCondition.TextFont.CharSet = 162;
                    PriceDifferenceCondition.Value = @"";

                    NewField1231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 80, 110, 84, false);
                    NewField1231.Name = "NewField1231";
                    NewField1231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1231.TextFont.Name = "Arial";
                    NewField1231.TextFont.Size = 8;
                    NewField1231.TextFont.Bold = true;
                    NewField1231.TextFont.CharSet = 162;
                    NewField1231.Value = @"O   N   A   Y";

                    NewField1331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 96, 287, 100, false);
                    NewField1331.Name = "NewField1331";
                    NewField1331.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1331.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1331.TextFont.Name = "Arial";
                    NewField1331.TextFont.Size = 8;
                    NewField1331.TextFont.Bold = true;
                    NewField1331.TextFont.CharSet = 162;
                    NewField1331.Value = @"İHALE İLE İLGİLİ DİĞER AÇIKLAMALAR";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 84, 10, 160, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 60, 84, 60, 160, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 104, 22, 108, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 8;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"İmzası";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 113, 27, 117, false);
                    NewField161.Name = "NewField161";
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Size = 8;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"Adı SOYADI";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 117, 27, 122, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1161.TextFont.Name = "Arial";
                    NewField1161.TextFont.Size = 9;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"Ünvanı";

                    NewField1261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 113, 29, 117, false);
                    NewField1261.Name = "NewField1261";
                    NewField1261.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1261.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1261.TextFont.Name = "Arial";
                    NewField1261.TextFont.Size = 8;
                    NewField1261.TextFont.Bold = true;
                    NewField1261.TextFont.CharSet = 162;
                    NewField1261.Value = @":";

                    NewField11621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 104, 29, 108, false);
                    NewField11621.Name = "NewField11621";
                    NewField11621.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11621.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11621.TextFont.Name = "Arial";
                    NewField11621.TextFont.Size = 8;
                    NewField11621.TextFont.Bold = true;
                    NewField11621.TextFont.CharSet = 162;
                    NewField11621.Value = @":";

                    NewField12621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 117, 29, 121, false);
                    NewField12621.Name = "NewField12621";
                    NewField12621.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12621.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12621.TextFont.Name = "Arial";
                    NewField12621.TextFont.Size = 8;
                    NewField12621.TextFont.Bold = true;
                    NewField12621.TextFont.CharSet = 162;
                    NewField12621.Value = @":";

                    PerformerName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 113, 59, 117, false);
                    PerformerName.Name = "PerformerName";
                    PerformerName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PerformerName.CaseFormat = CaseFormatEnum.fcNameSurname;
                    PerformerName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PerformerName.WordBreak = EvetHayirEnum.ehEvet;
                    PerformerName.TextFont.Name = "Arial";
                    PerformerName.TextFont.Size = 8;
                    PerformerName.TextFont.CharSet = 162;
                    PerformerName.Value = @"{#PERFORMER#}";

                    PerformerRank = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 135, 58, 139, false);
                    PerformerRank.Name = "PerformerRank";
                    PerformerRank.Visible = EvetHayirEnum.ehHayir;
                    PerformerRank.FieldType = ReportFieldTypeEnum.ftVariable;
                    PerformerRank.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PerformerRank.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PerformerRank.WordBreak = EvetHayirEnum.ehEvet;
                    PerformerRank.ObjectDefName = "ResUser";
                    PerformerRank.DataMember = "RANK.NAME";
                    PerformerRank.TextFont.Name = "Arial";
                    PerformerRank.TextFont.Size = 8;
                    PerformerRank.TextFont.CharSet = 162;
                    PerformerRank.Value = @"{#PERFORMERID#}";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 104, 72, 108, false);
                    NewField171.Name = "NewField171";
                    NewField171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField171.TextFont.Name = "Arial";
                    NewField171.TextFont.Size = 8;
                    NewField171.TextFont.Bold = true;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"İmzası";

                    NewField1361 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 113, 77, 117, false);
                    NewField1361.Name = "NewField1361";
                    NewField1361.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1361.TextFont.Name = "Arial";
                    NewField1361.TextFont.Size = 8;
                    NewField1361.TextFont.Bold = true;
                    NewField1361.TextFont.CharSet = 162;
                    NewField1361.Value = @"Adı SOYADI";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 117, 77, 121, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11611.TextFont.Name = "Arial";
                    NewField11611.TextFont.Size = 8;
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @"Ünvanı";

                    NewField13621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 113, 79, 117, false);
                    NewField13621.Name = "NewField13621";
                    NewField13621.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13621.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13621.TextFont.Name = "Arial";
                    NewField13621.TextFont.Size = 8;
                    NewField13621.TextFont.Bold = true;
                    NewField13621.TextFont.CharSet = 162;
                    NewField13621.Value = @":";

                    NewField112611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 104, 79, 108, false);
                    NewField112611.Name = "NewField112611";
                    NewField112611.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112611.TextFont.Name = "Arial";
                    NewField112611.TextFont.Size = 8;
                    NewField112611.TextFont.Bold = true;
                    NewField112611.TextFont.CharSet = 162;
                    NewField112611.Value = @":";

                    NewField112621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 117, 79, 121, false);
                    NewField112621.Name = "NewField112621";
                    NewField112621.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112621.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112621.TextFont.Name = "Arial";
                    NewField112621.TextFont.Size = 8;
                    NewField112621.TextFont.Bold = true;
                    NewField112621.TextFont.CharSet = 162;
                    NewField112621.Value = @":";

                    ExpenserName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 113, 109, 117, false);
                    ExpenserName.Name = "ExpenserName";
                    ExpenserName.FieldType = ReportFieldTypeEnum.ftVariable;
                    ExpenserName.CaseFormat = CaseFormatEnum.fcNameSurname;
                    ExpenserName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ExpenserName.WordBreak = EvetHayirEnum.ehEvet;
                    ExpenserName.TextFont.Name = "Arial";
                    ExpenserName.TextFont.Size = 8;
                    ExpenserName.TextFont.CharSet = 162;
                    ExpenserName.Value = @"{#EXPENSER#}";

                    ExpenserRank = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 135, 106, 139, false);
                    ExpenserRank.Name = "ExpenserRank";
                    ExpenserRank.Visible = EvetHayirEnum.ehHayir;
                    ExpenserRank.FieldType = ReportFieldTypeEnum.ftVariable;
                    ExpenserRank.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ExpenserRank.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ExpenserRank.WordBreak = EvetHayirEnum.ehEvet;
                    ExpenserRank.ObjectDefName = "ResUser";
                    ExpenserRank.DataMember = "RANK.NAME";
                    ExpenserRank.TextFont.Name = "Arial";
                    ExpenserRank.TextFont.Size = 8;
                    ExpenserRank.TextFont.CharSet = 162;
                    ExpenserRank.Value = @"{#EXPENSERID#}";

                    PerformerDuty = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 118, 59, 134, false);
                    PerformerDuty.Name = "PerformerDuty";
                    PerformerDuty.FieldType = ReportFieldTypeEnum.ftVariable;
                    PerformerDuty.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PerformerDuty.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PerformerDuty.MultiLine = EvetHayirEnum.ehEvet;
                    PerformerDuty.WordBreak = EvetHayirEnum.ehEvet;
                    PerformerDuty.TextFont.Name = "Arial";
                    PerformerDuty.TextFont.Size = 8;
                    PerformerDuty.TextFont.CharSet = 162;
                    PerformerDuty.Value = @"{%PerformerRank%}
{#PERFORMERDUTY#}";

                    ExpenserDuty = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 118, 109, 134, false);
                    ExpenserDuty.Name = "ExpenserDuty";
                    ExpenserDuty.FieldType = ReportFieldTypeEnum.ftVariable;
                    ExpenserDuty.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ExpenserDuty.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ExpenserDuty.MultiLine = EvetHayirEnum.ehEvet;
                    ExpenserDuty.WordBreak = EvetHayirEnum.ehEvet;
                    ExpenserDuty.TextFont.Name = "Arial";
                    ExpenserDuty.TextFont.Size = 8;
                    ExpenserDuty.TextFont.CharSet = 162;
                    ExpenserDuty.Value = @"{%ExpenserRank%}
{#EXPENSERDUTY#}";

                    ShowApproximatePriceOnReport = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 36, 351, 41, false);
                    ShowApproximatePriceOnReport.Name = "ShowApproximatePriceOnReport";
                    ShowApproximatePriceOnReport.Visible = EvetHayirEnum.ehHayir;
                    ShowApproximatePriceOnReport.FieldType = ReportFieldTypeEnum.ftVariable;
                    ShowApproximatePriceOnReport.Value = @"{#SHOWAPPROXIMATEPRICEONREPORT#}";

                    Advanced = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 42, 351, 47, false);
                    Advanced.Name = "Advanced";
                    Advanced.Visible = EvetHayirEnum.ehHayir;
                    Advanced.FieldType = ReportFieldTypeEnum.ftVariable;
                    Advanced.Value = @"{#ADVANCED#}";

                    PriceDifference = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 48, 351, 53, false);
                    PriceDifference.Name = "PriceDifference";
                    PriceDifference.Visible = EvetHayirEnum.ehHayir;
                    PriceDifference.FieldType = ReportFieldTypeEnum.ftVariable;
                    PriceDifference.Value = @"{#PRICEDIFFERENCE#}";

                    ConfirmDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 18, 333, 23, false);
                    ConfirmDate.Name = "ConfirmDate";
                    ConfirmDate.Visible = EvetHayirEnum.ehHayir;
                    ConfirmDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    ConfirmDate.TextFormat = @"dd/MM/yyyy";
                    ConfirmDate.Value = @"{#CONFIRMDATE#}";

                    ConfirmNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 24, 333, 29, false);
                    ConfirmNO.Name = "ConfirmNO";
                    ConfirmNO.Visible = EvetHayirEnum.ehHayir;
                    ConfirmNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ConfirmNO.Value = @"{#CONFIRMNO#}";

                    PerformerID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 310, 101, 335, 106, false);
                    PerformerID.Name = "PerformerID";
                    PerformerID.Visible = EvetHayirEnum.ehHayir;
                    PerformerID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PerformerID.ObjectDefName = "ResUser";
                    PerformerID.DataMember = "TITLE";
                    PerformerID.Value = @"{#PERFORMERID#}";

                    ExpenserID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 310, 107, 335, 112, false);
                    ExpenserID.Name = "ExpenserID";
                    ExpenserID.Visible = EvetHayirEnum.ehHayir;
                    ExpenserID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ExpenserID.ObjectDefName = "ResUser";
                    ExpenserID.DataMember = "TITLE";
                    ExpenserID.Value = @"{#EXPENSERID#}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 110, 100, 110, 160, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 287, 100, 287, 160, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.ExtendTo = ExtendToEnum.extSectionHeight;

                    InvestmentProjectNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 54, 351, 59, false);
                    InvestmentProjectNO.Name = "InvestmentProjectNO";
                    InvestmentProjectNO.Visible = EvetHayirEnum.ehHayir;
                    InvestmentProjectNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    InvestmentProjectNO.Value = @"{#INVESTMENTPROJECTNO#}";

                    BudgetExpensePen = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 60, 351, 65, false);
                    BudgetExpensePen.Name = "BudgetExpensePen";
                    BudgetExpensePen.Visible = EvetHayirEnum.ehHayir;
                    BudgetExpensePen.FieldType = ReportFieldTypeEnum.ftVariable;
                    BudgetExpensePen.Value = @"{#BUDGETEXPENSEPEN#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectGlobalReportNQL_Class dataset_PurchaseProjectGlobalReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>(0);
                    NewField151.CalcValue = NewField151.Value;
                    Onay11.CalcValue = Onay11.Value;
                    ExplanationRTF.CalcValue = ExplanationRTF.Value;
                    ReportName1.CalcValue = ReportName1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    ResponsibleProcurement.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Responsibleprocurementunitdef) : "");
                    ConfirmDate.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ConfirmDate) : "");
                    ConfirmNO.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ConfirmNO) : "");
                    ConfirmDateAndNumber.CalcValue = MyParentReport.PARTB.ConfirmDate.FormattedValue + @" / " + MyParentReport.PARTB.ConfirmNO.CalcValue;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    PreActDefineAttribute.CalcValue = @"";
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    ActDefineAttribute.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ActDefine) : "") + @"
" + (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ActAttribute) : "");
                    NewField1241.CalcValue = NewField1241.Value;
                    PreActCount.CalcValue = @"";
                    NewField11421.CalcValue = NewField11421.Value;
                    ActCount.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ActCount) : "");
                    NewField1121.CalcValue = NewField1121.Value;
                    PreCommTotalApproximatePrice.CalcValue = @"";
                    NewField11211.CalcValue = NewField11211.Value;
                    CommTotalApproximatePriceCondition.CalcValue = @"";
                    NewField12211.CalcValue = NewField12211.Value;
                    PreUsableBudgetAmount.CalcValue = @"";
                    NewField111221.CalcValue = NewField111221.Value;
                    NewField121221.CalcValue = NewField121221.Value;
                    PreInvestmentProjectNO.CalcValue = @"";
                    NewField1122121.CalcValue = NewField1122121.Value;
                    NewField1222121.CalcValue = NewField1222121.Value;
                    PreBudgetExpensePen.CalcValue = @"";
                    NewField11212221.CalcValue = NewField11212221.Value;
                    NewField1341.CalcValue = NewField1341.Value;
                    WhichDate.CalcValue = @"";
                    NewField112221211.CalcValue = NewField112221211.Value;
                    AdvancedCondition.CalcValue = @"";
                    NewField122221211.CalcValue = NewField122221211.Value;
                    PurchaseTypeDefinition.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Purchasetypedefinition) : "");
                    NewField132221211.CalcValue = NewField132221211.Value;
                    AnnounceTypeandCount.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.AnnounceTypeandCount) : "");
                    AnnounceTypeandCount.PostFieldValueCalculation();
                    NewField142221211.CalcValue = NewField142221211.Value;
                    SpecificationPrice.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.SpecificationPrice) : "");
                    NewField152221211.CalcValue = NewField152221211.Value;
                    PriceDifferenceCondition.CalcValue = @"";
                    NewField1231.CalcValue = NewField1231.Value;
                    NewField1331.CalcValue = NewField1331.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField1261.CalcValue = NewField1261.Value;
                    NewField11621.CalcValue = NewField11621.Value;
                    NewField12621.CalcValue = NewField12621.Value;
                    PerformerName.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Performer) : "");
                    PerformerRank.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Performerid) : "");
                    PerformerRank.PostFieldValueCalculation();
                    NewField171.CalcValue = NewField171.Value;
                    NewField1361.CalcValue = NewField1361.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    NewField13621.CalcValue = NewField13621.Value;
                    NewField112611.CalcValue = NewField112611.Value;
                    NewField112621.CalcValue = NewField112621.Value;
                    ExpenserName.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Expenser) : "");
                    ExpenserRank.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Expenserid) : "");
                    ExpenserRank.PostFieldValueCalculation();
                    PerformerDuty.CalcValue = MyParentReport.PARTB.PerformerRank.CalcValue + @"
" + (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.PerformerDuty) : "");
                    ExpenserDuty.CalcValue = MyParentReport.PARTB.ExpenserRank.CalcValue + @"
" + (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ExpenserDuty) : "");
                    ShowApproximatePriceOnReport.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ShowApproximatePriceOnReport) : "");
                    Advanced.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Advanced) : "");
                    PriceDifference.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.PriceDifference) : "");
                    PerformerID.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Performerid) : "");
                    PerformerID.PostFieldValueCalculation();
                    ExpenserID.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Expenserid) : "");
                    ExpenserID.PostFieldValueCalculation();
                    InvestmentProjectNO.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.InvestmentProjectNO) : "");
                    BudgetExpensePen.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.BudgetExpensePen) : "");
                    ToResponsibleProcurement.CalcValue = MyParentReport.PARTB.ResponsibleProcurement.CalcValue != "" ? MyParentReport.PARTB.ResponsibleProcurement.CalcValue + " MAKAMINA" : "";
                    UsableBudgetAmount.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.UsableBudgetAmount) : "") != null ? (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.UsableBudgetAmount) : "") : "( - )"
;
                    InvestmentProjectNOCondition.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.InvestmentProjectNO) : "") != "" ? (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.InvestmentProjectNO) : "") : "( - )";
                    BudgetExpensePenCondition.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.BudgetExpensePen) : "") != "" ? (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.BudgetExpensePen) : "") : "( - )";
                    return new TTReportObject[] { NewField151,Onay11,ExplanationRTF,ReportName1,NewField11,NewField12,NewField121,ResponsibleProcurement,ConfirmDate,ConfirmNO,ConfirmDateAndNumber,NewField131,NewField141,PreActDefineAttribute,NewField1141,NewField1131,ActDefineAttribute,NewField1241,PreActCount,NewField11421,ActCount,NewField1121,PreCommTotalApproximatePrice,NewField11211,CommTotalApproximatePriceCondition,NewField12211,PreUsableBudgetAmount,NewField111221,NewField121221,PreInvestmentProjectNO,NewField1122121,NewField1222121,PreBudgetExpensePen,NewField11212221,NewField1341,WhichDate,NewField112221211,AdvancedCondition,NewField122221211,PurchaseTypeDefinition,NewField132221211,AnnounceTypeandCount,NewField142221211,SpecificationPrice,NewField152221211,PriceDifferenceCondition,NewField1231,NewField1331,NewField13,NewField161,NewField1161,NewField1261,NewField11621,NewField12621,PerformerName,PerformerRank,NewField171,NewField1361,NewField11611,NewField13621,NewField112611,NewField112621,ExpenserName,ExpenserRank,PerformerDuty,ExpenserDuty,ShowApproximatePriceOnReport,Advanced,PriceDifference,PerformerID,ExpenserID,InvestmentProjectNO,BudgetExpensePen,ToResponsibleProcurement,UsableBudgetAmount,InvestmentProjectNOCondition,BudgetExpensePenCondition};
                }
                public override void RunPreScript()
                {
#region PARTB HEADER_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string objectID = ((OnayBelgesiRaporuIhale)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PurchaseProject purchaseProject = (PurchaseProject)context.GetObject(new Guid(objectID), typeof(PurchaseProject));
            if(purchaseProject.ApproveFormDescription != null)
                this.ExplanationRTF.Value = purchaseProject.ApproveFormDescription.ToString();
#endregion PARTB HEADER_PreScript
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    if (Advanced.CalcValue == "False")
                AdvancedCondition.CalcValue = "AVANS VERİLMEYECEKTİR.";

            if (PriceDifference.CalcValue == "False")
                PriceDifferenceCondition.CalcValue = "FİYAT FARKI VERİLMEYECEKTİR.";
            else
                PriceDifferenceCondition.CalcValue = "FİYAT FARKI VERİLECEKTİR.";
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public OnayBelgesiRaporuIhale MyParentReport
                {
                    get { return (OnayBelgesiRaporuIhale)ParentReport; }
                }
                
                public TTReportField NewField1151;
                public TTReportField Onay111;
                public TTReportField NewField11321;
                public TTReportField NewField132;
                public TTReportField NewField1162;
                public TTReportField NewField11612;
                public TTReportField NewField11622;
                public TTReportField NewField112612;
                public TTReportField NewField112622;
                public TTReportField PerformerName1;
                public TTReportField PerformerRank1;
                public TTReportField NewField1171;
                public TTReportField NewField11631;
                public TTReportField NewField111611;
                public TTReportField NewField112631;
                public TTReportField NewField1116211;
                public TTReportField NewField1126211;
                public TTReportField ExpenserName1;
                public TTReportField ExpenserRank1;
                public TTReportField NewField1126222;
                public TTReportField NewField11226211;
                public TTReportField PerformerDuty1;
                public TTReportField ExpenserDuty1;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine121;
                public TTReportField PROJECTNO; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 48;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 4, 287, 41, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1151.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1151.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1151.TextFont.Name = "Arial";
                    NewField1151.TextFont.Size = 8;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"Uygundur.
_ _ . _ _ . _ _ _ _

İhale Yetkilisi";

                    Onay111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 4, 199, 41, false);
                    Onay111.Name = "Onay111";
                    Onay111.DrawStyle = DrawStyleConstants.vbSolid;
                    Onay111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Onay111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Onay111.MultiLine = EvetHayirEnum.ehEvet;
                    Onay111.WordBreak = EvetHayirEnum.ehEvet;
                    Onay111.TextFont.Name = "Arial";
                    Onay111.TextFont.Size = 8;
                    Onay111.TextFont.CharSet = 162;
                    Onay111.Value = @"Yukarıda belirtilen malın alınması için ihaleye çıkılması hususunu onaylarınıza arz ederim.
_ _ . _ _ . _ _ _ _";

                    NewField11321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 0, 287, 4, false);
                    NewField11321.Name = "NewField11321";
                    NewField11321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11321.TextFont.Name = "Arial";
                    NewField11321.TextFont.Size = 8;
                    NewField11321.TextFont.Bold = true;
                    NewField11321.TextFont.CharSet = 162;
                    NewField11321.Value = @"O   N   A   Y";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 18, 122, 22, false);
                    NewField132.Name = "NewField132";
                    NewField132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField132.TextFont.Name = "Arial";
                    NewField132.TextFont.Size = 8;
                    NewField132.TextFont.Bold = true;
                    NewField132.TextFont.CharSet = 162;
                    NewField132.Value = @"İmzası";

                    NewField1162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 27, 127, 31, false);
                    NewField1162.Name = "NewField1162";
                    NewField1162.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1162.TextFont.Name = "Arial";
                    NewField1162.TextFont.Size = 8;
                    NewField1162.TextFont.Bold = true;
                    NewField1162.TextFont.CharSet = 162;
                    NewField1162.Value = @"Adı SOYADI";

                    NewField11612 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 31, 127, 35, false);
                    NewField11612.Name = "NewField11612";
                    NewField11612.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11612.TextFont.Name = "Arial";
                    NewField11612.TextFont.Size = 8;
                    NewField11612.TextFont.Bold = true;
                    NewField11612.TextFont.CharSet = 162;
                    NewField11612.Value = @"Ünvanı";

                    NewField11622 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 27, 129, 31, false);
                    NewField11622.Name = "NewField11622";
                    NewField11622.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11622.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11622.TextFont.Name = "Arial";
                    NewField11622.TextFont.Size = 8;
                    NewField11622.TextFont.Bold = true;
                    NewField11622.TextFont.CharSet = 162;
                    NewField11622.Value = @":";

                    NewField112612 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 18, 129, 22, false);
                    NewField112612.Name = "NewField112612";
                    NewField112612.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112612.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112612.TextFont.Name = "Arial";
                    NewField112612.TextFont.Size = 8;
                    NewField112612.TextFont.Bold = true;
                    NewField112612.TextFont.CharSet = 162;
                    NewField112612.Value = @":";

                    NewField112622 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 31, 129, 35, false);
                    NewField112622.Name = "NewField112622";
                    NewField112622.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112622.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112622.TextFont.Name = "Arial";
                    NewField112622.TextFont.Size = 8;
                    NewField112622.TextFont.Bold = true;
                    NewField112622.TextFont.CharSet = 162;
                    NewField112622.Value = @":";

                    PerformerName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 27, 159, 31, false);
                    PerformerName1.Name = "PerformerName1";
                    PerformerName1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PerformerName1.CaseFormat = CaseFormatEnum.fcNameSurname;
                    PerformerName1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PerformerName1.WordBreak = EvetHayirEnum.ehEvet;
                    PerformerName1.TextFont.Name = "Arial";
                    PerformerName1.TextFont.Size = 8;
                    PerformerName1.TextFont.CharSet = 162;
                    PerformerName1.Value = @"{#PERFORMER#}";

                    PerformerRank1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 31, 159, 35, false);
                    PerformerRank1.Name = "PerformerRank1";
                    PerformerRank1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PerformerRank1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PerformerRank1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PerformerRank1.NoClip = EvetHayirEnum.ehEvet;
                    PerformerRank1.ObjectDefName = "ResUser";
                    PerformerRank1.DataMember = "RANK.NAME";
                    PerformerRank1.TextFont.Name = "Arial";
                    PerformerRank1.TextFont.Size = 8;
                    PerformerRank1.TextFont.CharSet = 162;
                    PerformerRank1.Value = @"{#PERFORMERID#}";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 19, 211, 23, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1171.TextFont.Name = "Arial";
                    NewField1171.TextFont.Size = 8;
                    NewField1171.TextFont.Bold = true;
                    NewField1171.TextFont.CharSet = 162;
                    NewField1171.Value = @"İmzası";

                    NewField11631 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 27, 216, 31, false);
                    NewField11631.Name = "NewField11631";
                    NewField11631.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11631.TextFont.Name = "Arial";
                    NewField11631.TextFont.Size = 8;
                    NewField11631.TextFont.Bold = true;
                    NewField11631.TextFont.CharSet = 162;
                    NewField11631.Value = @"Adı SOYADI";

                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 31, 216, 35, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111611.TextFont.Name = "Arial";
                    NewField111611.TextFont.Size = 8;
                    NewField111611.TextFont.Bold = true;
                    NewField111611.TextFont.CharSet = 162;
                    NewField111611.Value = @"Ünvanı";

                    NewField112631 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 27, 218, 31, false);
                    NewField112631.Name = "NewField112631";
                    NewField112631.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112631.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112631.TextFont.Name = "Arial";
                    NewField112631.TextFont.Size = 8;
                    NewField112631.TextFont.Bold = true;
                    NewField112631.TextFont.CharSet = 162;
                    NewField112631.Value = @":";

                    NewField1116211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 19, 218, 23, false);
                    NewField1116211.Name = "NewField1116211";
                    NewField1116211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1116211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1116211.TextFont.Name = "Arial";
                    NewField1116211.TextFont.Size = 8;
                    NewField1116211.TextFont.Bold = true;
                    NewField1116211.TextFont.CharSet = 162;
                    NewField1116211.Value = @":";

                    NewField1126211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 31, 218, 35, false);
                    NewField1126211.Name = "NewField1126211";
                    NewField1126211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1126211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1126211.TextFont.Name = "Arial";
                    NewField1126211.TextFont.Size = 8;
                    NewField1126211.TextFont.Bold = true;
                    NewField1126211.TextFont.CharSet = 162;
                    NewField1126211.Value = @":";

                    ExpenserName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 27, 248, 31, false);
                    ExpenserName1.Name = "ExpenserName1";
                    ExpenserName1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ExpenserName1.CaseFormat = CaseFormatEnum.fcNameSurname;
                    ExpenserName1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ExpenserName1.WordBreak = EvetHayirEnum.ehEvet;
                    ExpenserName1.TextFont.Name = "Arial";
                    ExpenserName1.TextFont.Size = 8;
                    ExpenserName1.TextFont.CharSet = 162;
                    ExpenserName1.Value = @"{#EXPENSER#}";

                    ExpenserRank1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 31, 248, 35, false);
                    ExpenserRank1.Name = "ExpenserRank1";
                    ExpenserRank1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ExpenserRank1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ExpenserRank1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ExpenserRank1.NoClip = EvetHayirEnum.ehEvet;
                    ExpenserRank1.ObjectDefName = "ResUser";
                    ExpenserRank1.DataMember = "RANK.NAME";
                    ExpenserRank1.TextFont.Name = "Arial";
                    ExpenserRank1.TextFont.Size = 8;
                    ExpenserRank1.TextFont.CharSet = 162;
                    ExpenserRank1.Value = @"{#EXPENSERID#}";

                    NewField1126222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 35, 129, 39, false);
                    NewField1126222.Name = "NewField1126222";
                    NewField1126222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1126222.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1126222.TextFont.Name = "Arial";
                    NewField1126222.TextFont.Size = 8;
                    NewField1126222.TextFont.Bold = true;
                    NewField1126222.TextFont.CharSet = 162;
                    NewField1126222.Value = @":";

                    NewField11226211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 35, 218, 39, false);
                    NewField11226211.Name = "NewField11226211";
                    NewField11226211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11226211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11226211.TextFont.Name = "Arial";
                    NewField11226211.TextFont.Size = 8;
                    NewField11226211.TextFont.Bold = true;
                    NewField11226211.TextFont.CharSet = 162;
                    NewField11226211.Value = @":";

                    PerformerDuty1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 35, 159, 39, false);
                    PerformerDuty1.Name = "PerformerDuty1";
                    PerformerDuty1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PerformerDuty1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PerformerDuty1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PerformerDuty1.NoClip = EvetHayirEnum.ehEvet;
                    PerformerDuty1.TextFont.Name = "Arial";
                    PerformerDuty1.TextFont.Size = 8;
                    PerformerDuty1.TextFont.CharSet = 162;
                    PerformerDuty1.Value = @"{#PERFORMERDUTY#}";

                    ExpenserDuty1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 35, 248, 39, false);
                    ExpenserDuty1.Name = "ExpenserDuty1";
                    ExpenserDuty1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ExpenserDuty1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ExpenserDuty1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ExpenserDuty1.MultiLine = EvetHayirEnum.ehEvet;
                    ExpenserDuty1.WordBreak = EvetHayirEnum.ehEvet;
                    ExpenserDuty1.TextFont.Name = "Arial";
                    ExpenserDuty1.TextFont.Size = 8;
                    ExpenserDuty1.TextFont.CharSet = 162;
                    ExpenserDuty1.Value = @"{#EXPENSERDUTY#}";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 41, 110, 41, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 41, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 60, 0, 60, 41, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    PROJECTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 42, 20, 47, false);
                    PROJECTNO.Name = "PROJECTNO";
                    PROJECTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROJECTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO.NoClip = EvetHayirEnum.ehEvet;
                    PROJECTNO.TextFont.Name = "Arial";
                    PROJECTNO.TextFont.Size = 8;
                    PROJECTNO.TextFont.CharSet = 162;
                    PROJECTNO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectGlobalReportNQL_Class dataset_PurchaseProjectGlobalReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>(0);
                    NewField1151.CalcValue = NewField1151.Value;
                    Onay111.CalcValue = Onay111.Value;
                    NewField11321.CalcValue = NewField11321.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField1162.CalcValue = NewField1162.Value;
                    NewField11612.CalcValue = NewField11612.Value;
                    NewField11622.CalcValue = NewField11622.Value;
                    NewField112612.CalcValue = NewField112612.Value;
                    NewField112622.CalcValue = NewField112622.Value;
                    PerformerName1.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Performer) : "");
                    PerformerRank1.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Performerid) : "");
                    PerformerRank1.PostFieldValueCalculation();
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField11631.CalcValue = NewField11631.Value;
                    NewField111611.CalcValue = NewField111611.Value;
                    NewField112631.CalcValue = NewField112631.Value;
                    NewField1116211.CalcValue = NewField1116211.Value;
                    NewField1126211.CalcValue = NewField1126211.Value;
                    ExpenserName1.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Expenser) : "");
                    ExpenserRank1.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Expenserid) : "");
                    ExpenserRank1.PostFieldValueCalculation();
                    NewField1126222.CalcValue = NewField1126222.Value;
                    NewField11226211.CalcValue = NewField11226211.Value;
                    PerformerDuty1.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.PerformerDuty) : "");
                    ExpenserDuty1.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ExpenserDuty) : "");
                    PROJECTNO.CalcValue = @"";
                    return new TTReportObject[] { NewField1151,Onay111,NewField11321,NewField132,NewField1162,NewField11612,NewField11622,NewField112612,NewField112622,PerformerName1,PerformerRank1,NewField1171,NewField11631,NewField111611,NewField112631,NewField1116211,NewField1126211,ExpenserName1,ExpenserRank1,NewField1126222,NewField11226211,PerformerDuty1,ExpenserDuty1,PROJECTNO};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    string objectID = ((OnayBelgesiRaporuIhale)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            PurchaseProject pp = (PurchaseProject)ctx.GetObject(new Guid(objectID), typeof(PurchaseProject));
            if (pp != null)
                PROJECTNO.CalcValue = " Proje Nu. : " + pp.PurchaseProjectNO.ToString();
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public OnayBelgesiRaporuIhale MyParentReport
            {
                get { return (OnayBelgesiRaporuIhale)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
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
                public OnayBelgesiRaporuIhale MyParentReport
                {
                    get { return (OnayBelgesiRaporuIhale)ParentReport; }
                }
                 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public OnayBelgesiRaporuIhale()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Proje No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "ONAYBELGESIRAPORUIHALE";
            Caption = "İhale Onay Belgesi";
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