
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
    /// Serbest Bırakma Raporu
    /// </summary>
    public partial class SerbestBirakmaRaporu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public SerbestBirakmaRaporu MyParentReport
            {
                get { return (SerbestBirakmaRaporu)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField XXXXXXLOGO { get {return Header().XXXXXXLOGO;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField FORMBASLIGI { get {return Header().FORMBASLIGI;} }
            public TTReportField PRODUCEDMATERIALNAME { get {return Header().PRODUCEDMATERIALNAME;} }
            public TTReportField FORMBASLIGI1 { get {return Header().FORMBASLIGI1;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField SAMPLETAKENDATE { get {return Header().SAMPLETAKENDATE;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField SERIALNO { get {return Header().SERIALNO;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField ANALYSENO { get {return Header().ANALYSENO;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField ACTIVEINGREDIENTNAME { get {return Header().ACTIVEINGREDIENTNAME;} }
            public TTReportField NewField1171 { get {return Header().NewField1171;} }
            public TTReportField REPORTDATE { get {return Header().REPORTDATE;} }
            public TTReportField NewField1181 { get {return Header().NewField1181;} }
            public TTReportField PRODUCEDMATERIALAMOUNT { get {return Header().PRODUCEDMATERIALAMOUNT;} }
            public TTReportField NewField11711 { get {return Header().NewField11711;} }
            public TTReportField SAMPLETAKENPERSONNEL { get {return Header().SAMPLETAKENPERSONNEL;} }
            public TTReportField NewField11811 { get {return Header().NewField11811;} }
            public TTReportField SAMPLEAMOUNT { get {return Header().SAMPLEAMOUNT;} }
            public TTReportField NewField111711 { get {return Header().NewField111711;} }
            public TTReportField NSN { get {return Header().NSN;} }
            public TTReportField NewField11812 { get {return Header().NewField11812;} }
            public TTReportField NewField121811 { get {return Header().NewField121811;} }
            public TTReportField NewField1118121 { get {return Header().NewField1118121;} }
            public TTReportField REQUESTUSERDETAIL { get {return Footer().REQUESTUSERDETAIL;} }
            public TTReportField APPROVEDUSERDETAIL { get {return Footer().APPROVEDUSERDETAIL;} }
            public TTReportField NewField111811 { get {return Footer().NewField111811;} }
            public TTReportField NewField1117111 { get {return Footer().NewField1117111;} }
            public TTReportShape NewRect1 { get {return Footer().NewRect1;} }
            public TTReportField NewField11117111 { get {return Footer().NewField11117111;} }
            public TTReportShape NewRect11 { get {return Footer().NewRect11;} }
            public TTReportField NewField121812 { get {return Footer().NewField121812;} }
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
                public SerbestBirakmaRaporu MyParentReport
                {
                    get { return (SerbestBirakmaRaporu)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField XXXXXXLOGO;
                public TTReportField NewField7;
                public TTReportField FORMBASLIGI;
                public TTReportField PRODUCEDMATERIALNAME;
                public TTReportField FORMBASLIGI1;
                public TTReportField NewField17;
                public TTReportField SAMPLETAKENDATE;
                public TTReportField NewField18;
                public TTReportField SERIALNO;
                public TTReportField NewField171;
                public TTReportField ANALYSENO;
                public TTReportField NewField181;
                public TTReportField ACTIVEINGREDIENTNAME;
                public TTReportField NewField1171;
                public TTReportField REPORTDATE;
                public TTReportField NewField1181;
                public TTReportField PRODUCEDMATERIALAMOUNT;
                public TTReportField NewField11711;
                public TTReportField SAMPLETAKENPERSONNEL;
                public TTReportField NewField11811;
                public TTReportField SAMPLEAMOUNT;
                public TTReportField NewField111711;
                public TTReportField NSN;
                public TTReportField NewField11812;
                public TTReportField NewField121811;
                public TTReportField NewField1118121; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 111;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 10, 200, 33, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Size = 12;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    XXXXXXLOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 56, 30, false);
                    XXXXXXLOGO.Name = "XXXXXXLOGO";
                    XXXXXXLOGO.TextFont.CharSet = 1;
                    XXXXXXLOGO.Value = @"";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 61, 46, 69, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Size = 8;
                    NewField7.TextFont.Bold = true;
                    NewField7.Value = @"Mamül Madde Adı";

                    FORMBASLIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 34, 200, 45, false);
                    FORMBASLIGI.Name = "FORMBASLIGI";
                    FORMBASLIGI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FORMBASLIGI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FORMBASLIGI.MultiLine = EvetHayirEnum.ehEvet;
                    FORMBASLIGI.WordBreak = EvetHayirEnum.ehEvet;
                    FORMBASLIGI.TextFont.Name = "Arial";
                    FORMBASLIGI.TextFont.Size = 12;
                    FORMBASLIGI.TextFont.Bold = true;
                    FORMBASLIGI.Value = @"SERBEST BIRAKMA RAPORU
(MAMÜL MADDE ANALİZ RAPORU)";

                    PRODUCEDMATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 61, 121, 69, false);
                    PRODUCEDMATERIALNAME.Name = "PRODUCEDMATERIALNAME";
                    PRODUCEDMATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    PRODUCEDMATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRODUCEDMATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRODUCEDMATERIALNAME.TextFont.Name = "Arial";
                    PRODUCEDMATERIALNAME.TextFont.Size = 11;
                    PRODUCEDMATERIALNAME.TextFont.Bold = true;
                    PRODUCEDMATERIALNAME.Value = @"";

                    FORMBASLIGI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 49, 200, 54, false);
                    FORMBASLIGI1.Name = "FORMBASLIGI1";
                    FORMBASLIGI1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FORMBASLIGI1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FORMBASLIGI1.MultiLine = EvetHayirEnum.ehEvet;
                    FORMBASLIGI1.WordBreak = EvetHayirEnum.ehEvet;
                    FORMBASLIGI1.TextFont.Name = "Arial";
                    FORMBASLIGI1.TextFont.Size = 12;
                    FORMBASLIGI1.TextFont.Bold = true;
                    FORMBASLIGI1.Value = @"KALİTE KONTROL VE AR-GE LABORATUVARI";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 61, 157, 69, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Size = 8;
                    NewField17.TextFont.Bold = true;
                    NewField17.Value = @"Numune Alma Tarihi";

                    SAMPLETAKENDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 61, 200, 69, false);
                    SAMPLETAKENDATE.Name = "SAMPLETAKENDATE";
                    SAMPLETAKENDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    SAMPLETAKENDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAMPLETAKENDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    SAMPLETAKENDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SAMPLETAKENDATE.TextFont.Name = "Arial";
                    SAMPLETAKENDATE.TextFont.Size = 11;
                    SAMPLETAKENDATE.TextFont.Bold = true;
                    SAMPLETAKENDATE.Value = @"";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 69, 46, 77, false);
                    NewField18.Name = "NewField18";
                    NewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18.TextFont.Name = "Arial";
                    NewField18.TextFont.Size = 8;
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @"Seri Nu.";

                    SERIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 69, 121, 77, false);
                    SERIALNO.Name = "SERIALNO";
                    SERIALNO.DrawStyle = DrawStyleConstants.vbSolid;
                    SERIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SERIALNO.TextFont.Name = "Arial";
                    SERIALNO.TextFont.Size = 11;
                    SERIALNO.TextFont.Bold = true;
                    SERIALNO.Value = @"";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 69, 157, 77, false);
                    NewField171.Name = "NewField171";
                    NewField171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField171.TextFont.Name = "Arial";
                    NewField171.TextFont.Size = 8;
                    NewField171.TextFont.Bold = true;
                    NewField171.Value = @"Analiz Nu.";

                    ANALYSENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 69, 200, 77, false);
                    ANALYSENO.Name = "ANALYSENO";
                    ANALYSENO.DrawStyle = DrawStyleConstants.vbSolid;
                    ANALYSENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ANALYSENO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ANALYSENO.TextFont.Name = "Arial";
                    ANALYSENO.TextFont.Size = 11;
                    ANALYSENO.TextFont.Bold = true;
                    ANALYSENO.Value = @"";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 77, 46, 85, false);
                    NewField181.Name = "NewField181";
                    NewField181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField181.TextFont.Name = "Arial";
                    NewField181.TextFont.Size = 8;
                    NewField181.TextFont.Bold = true;
                    NewField181.Value = @"Etkin Madde Adı";

                    ACTIVEINGREDIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 77, 121, 85, false);
                    ACTIVEINGREDIENTNAME.Name = "ACTIVEINGREDIENTNAME";
                    ACTIVEINGREDIENTNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    ACTIVEINGREDIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIVEINGREDIENTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTIVEINGREDIENTNAME.TextFont.Name = "Arial";
                    ACTIVEINGREDIENTNAME.TextFont.Size = 11;
                    ACTIVEINGREDIENTNAME.TextFont.Bold = true;
                    ACTIVEINGREDIENTNAME.Value = @"";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 77, 157, 85, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1171.TextFont.Name = "Arial";
                    NewField1171.TextFont.Size = 8;
                    NewField1171.TextFont.Bold = true;
                    NewField1171.Value = @"Rapor Tarihi";

                    REPORTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 77, 200, 85, false);
                    REPORTDATE.Name = "REPORTDATE";
                    REPORTDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    REPORTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTDATE.TextFormat = @"dd/MM/yyyy";
                    REPORTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTDATE.TextFont.Name = "Arial";
                    REPORTDATE.TextFont.Size = 11;
                    REPORTDATE.TextFont.Bold = true;
                    REPORTDATE.Value = @"{@printdate@}";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 85, 46, 93, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1181.TextFont.Name = "Arial";
                    NewField1181.TextFont.Size = 8;
                    NewField1181.TextFont.Bold = true;
                    NewField1181.Value = @"Üretim Miktarı";

                    PRODUCEDMATERIALAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 85, 121, 93, false);
                    PRODUCEDMATERIALAMOUNT.Name = "PRODUCEDMATERIALAMOUNT";
                    PRODUCEDMATERIALAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    PRODUCEDMATERIALAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRODUCEDMATERIALAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRODUCEDMATERIALAMOUNT.TextFont.Name = "Arial";
                    PRODUCEDMATERIALAMOUNT.TextFont.Size = 11;
                    PRODUCEDMATERIALAMOUNT.TextFont.Bold = true;
                    PRODUCEDMATERIALAMOUNT.Value = @"";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 85, 157, 93, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11711.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11711.TextFont.Name = "Arial";
                    NewField11711.TextFont.Size = 8;
                    NewField11711.TextFont.Bold = true;
                    NewField11711.Value = @"Numuneyi Alan";

                    SAMPLETAKENPERSONNEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 85, 200, 93, false);
                    SAMPLETAKENPERSONNEL.Name = "SAMPLETAKENPERSONNEL";
                    SAMPLETAKENPERSONNEL.DrawStyle = DrawStyleConstants.vbSolid;
                    SAMPLETAKENPERSONNEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAMPLETAKENPERSONNEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SAMPLETAKENPERSONNEL.TextFont.Name = "Arial";
                    SAMPLETAKENPERSONNEL.TextFont.Size = 11;
                    SAMPLETAKENPERSONNEL.TextFont.Bold = true;
                    SAMPLETAKENPERSONNEL.Value = @"";

                    NewField11811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 93, 66, 101, false);
                    NewField11811.Name = "NewField11811";
                    NewField11811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11811.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11811.TextFont.Name = "Arial";
                    NewField11811.TextFont.Size = 8;
                    NewField11811.TextFont.Bold = true;
                    NewField11811.Value = @"Rasgele Seçilen Numune Sayısı";

                    SAMPLEAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 93, 121, 101, false);
                    SAMPLEAMOUNT.Name = "SAMPLEAMOUNT";
                    SAMPLEAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    SAMPLEAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAMPLEAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SAMPLEAMOUNT.TextFont.Name = "Arial";
                    SAMPLEAMOUNT.TextFont.Size = 11;
                    SAMPLEAMOUNT.TextFont.Bold = true;
                    SAMPLEAMOUNT.Value = @"";

                    NewField111711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 93, 157, 101, false);
                    NewField111711.Name = "NewField111711";
                    NewField111711.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111711.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111711.TextFont.Name = "Arial";
                    NewField111711.TextFont.Size = 8;
                    NewField111711.TextFont.Bold = true;
                    NewField111711.Value = @"NSN";

                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 93, 200, 101, false);
                    NSN.Name = "NSN";
                    NSN.DrawStyle = DrawStyleConstants.vbSolid;
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NSN.TextFont.Name = "Arial";
                    NSN.TextFont.Size = 11;
                    NSN.TextFont.Bold = true;
                    NSN.Value = @"";

                    NewField11812 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 105, 84, 111, false);
                    NewField11812.Name = "NewField11812";
                    NewField11812.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11812.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11812.TextFont.Name = "Arial";
                    NewField11812.TextFont.Size = 11;
                    NewField11812.TextFont.Bold = true;
                    NewField11812.Value = @"TESTLER";

                    NewField121811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 105, 142, 111, false);
                    NewField121811.Name = "NewField121811";
                    NewField121811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121811.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121811.TextFont.Name = "Arial";
                    NewField121811.TextFont.Size = 11;
                    NewField121811.TextFont.Bold = true;
                    NewField121811.Value = @"SONUÇLAR";

                    NewField1118121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 105, 200, 111, false);
                    NewField1118121.Name = "NewField1118121";
                    NewField1118121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1118121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1118121.TextFont.Name = "Arial";
                    NewField1118121.TextFont.Size = 11;
                    NewField1118121.TextFont.Bold = true;
                    NewField1118121.Value = @"TESTi YAPAN";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    XXXXXXLOGO.CalcValue = XXXXXXLOGO.Value;
                    NewField7.CalcValue = NewField7.Value;
                    FORMBASLIGI.CalcValue = FORMBASLIGI.Value;
                    PRODUCEDMATERIALNAME.CalcValue = @"";
                    FORMBASLIGI1.CalcValue = FORMBASLIGI1.Value;
                    NewField17.CalcValue = NewField17.Value;
                    SAMPLETAKENDATE.CalcValue = @"";
                    NewField18.CalcValue = NewField18.Value;
                    SERIALNO.CalcValue = @"";
                    NewField171.CalcValue = NewField171.Value;
                    ANALYSENO.CalcValue = @"";
                    NewField181.CalcValue = NewField181.Value;
                    ACTIVEINGREDIENTNAME.CalcValue = @"";
                    NewField1171.CalcValue = NewField1171.Value;
                    REPORTDATE.CalcValue = DateTime.Now.ToShortDateString();
                    NewField1181.CalcValue = NewField1181.Value;
                    PRODUCEDMATERIALAMOUNT.CalcValue = @"";
                    NewField11711.CalcValue = NewField11711.Value;
                    SAMPLETAKENPERSONNEL.CalcValue = @"";
                    NewField11811.CalcValue = NewField11811.Value;
                    SAMPLEAMOUNT.CalcValue = @"";
                    NewField111711.CalcValue = NewField111711.Value;
                    NSN.CalcValue = @"";
                    NewField11812.CalcValue = NewField11812.Value;
                    NewField121811.CalcValue = NewField121811.Value;
                    NewField1118121.CalcValue = NewField1118121.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { XXXXXXLOGO,NewField7,FORMBASLIGI,PRODUCEDMATERIALNAME,FORMBASLIGI1,NewField17,SAMPLETAKENDATE,NewField18,SERIALNO,NewField171,ANALYSENO,NewField181,ACTIVEINGREDIENTNAME,NewField1171,REPORTDATE,NewField1181,PRODUCEDMATERIALAMOUNT,NewField11711,SAMPLETAKENPERSONNEL,NewField11811,SAMPLEAMOUNT,NewField111711,NSN,NewField11812,NewField121811,NewField1118121,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    StockAction stockAction = (StockAction)MyParentReport.ReportObjectContext.GetObject(new Guid(MyParentReport.RuntimeParameters.TTOBJECTID), typeof(StockAction));
            if (stockAction is MilitaryDrugProductionProcedure)
            {
                MilitaryDrugProductionProcedure drugProduction = (MilitaryDrugProductionProcedure)stockAction;
                PRODUCEDMATERIALNAME.CalcValue = drugProduction.ProducedMaterial.Material.Name;
                SERIALNO.CalcValue = drugProduction.SerialNO;
                PRODUCEDMATERIALAMOUNT.CalcValue = drugProduction.ProducedMaterialAmount.ToString();
                NSN.CalcValue = drugProduction.ProducedMaterial.Material.StockCard.NATOStockNO;
            }
            else if (stockAction is DrugProductionTest)
            {
                DrugProductionTest drugTest = (DrugProductionTest)stockAction;
                PRODUCEDMATERIALNAME.CalcValue = drugTest.DrugProductionProcedure.ProducedMaterial.Material.Name;
                SERIALNO.CalcValue = drugTest.DrugProductionProcedure.SerialNO;
                PRODUCEDMATERIALAMOUNT.CalcValue = drugTest.DrugProductionProcedure.ProducedMaterialAmount.ToString();
                SAMPLEAMOUNT.CalcValue = drugTest.SampleAmount;
                if(drugTest.SampleTakeDate.HasValue)
                    SAMPLETAKENDATE.CalcValue = drugTest.SampleTakeDate.Value.ToShortDateString();
                ANALYSENO.CalcValue = drugTest.AnalyseNo.ToString();
                if(drugTest.SampleTaker != null)
                    SAMPLETAKENPERSONNEL.CalcValue = drugTest.SampleTaker.Name;
                NSN.CalcValue = drugTest.DrugProductionProcedure.ProducedMaterial.Material.StockCard.NATOStockNO;
            }
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public SerbestBirakmaRaporu MyParentReport
                {
                    get { return (SerbestBirakmaRaporu)ParentReport; }
                }
                
                public TTReportField REQUESTUSERDETAIL;
                public TTReportField APPROVEDUSERDETAIL;
                public TTReportField NewField111811;
                public TTReportField NewField1117111;
                public TTReportShape NewRect1;
                public TTReportField NewField11117111;
                public TTReportShape NewRect11;
                public TTReportField NewField121812; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 49;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    REQUESTUSERDETAIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 21, 60, 43, false);
                    REQUESTUSERDETAIL.Name = "REQUESTUSERDETAIL";
                    REQUESTUSERDETAIL.TextFont.Name = "Arial";
                    REQUESTUSERDETAIL.TextFont.Size = 11;
                    REQUESTUSERDETAIL.Value = @"";

                    APPROVEDUSERDETAIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 21, 200, 43, false);
                    APPROVEDUSERDETAIL.Name = "APPROVEDUSERDETAIL";
                    APPROVEDUSERDETAIL.TextFont.Name = "Arial";
                    APPROVEDUSERDETAIL.TextFont.Size = 11;
                    APPROVEDUSERDETAIL.Value = @"";

                    NewField111811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 60, 11, false);
                    NewField111811.Name = "NewField111811";
                    NewField111811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111811.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111811.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111811.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111811.TextFont.Name = "Arial";
                    NewField111811.TextFont.Size = 8;
                    NewField111811.TextFont.Bold = true;
                    NewField111811.Value = @"Yukarıda Belirtilen Spefikasyonlara Göre";

                    NewField1117111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 1, 117, 11, false);
                    NewField1117111.Name = "NewField1117111";
                    NewField1117111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1117111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1117111.TextFont.Name = "Arial";
                    NewField1117111.TextFont.Size = 8;
                    NewField1117111.TextFont.Bold = true;
                    NewField1117111.Value = @"  UYGUNDUR";

                    NewRect1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 107, 4, 112, 9, false);
                    NewRect1.Name = "NewRect1";
                    NewRect1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11117111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 1, 200, 11, false);
                    NewField11117111.Name = "NewField11117111";
                    NewField11117111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11117111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11117111.TextFont.Name = "Arial";
                    NewField11117111.TextFont.Size = 8;
                    NewField11117111.TextFont.Bold = true;
                    NewField11117111.Value = @"  UYGUN DEĞİLDİR";

                    NewRect11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtRectangle, 190, 4, 195, 9, false);
                    NewRect11.Name = "NewRect11";
                    NewRect11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField121812 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 14, 200, 20, false);
                    NewField121812.Name = "NewField121812";
                    NewField121812.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121812.TextFont.Name = "Arial";
                    NewField121812.TextFont.Size = 11;
                    NewField121812.TextFont.Bold = true;
                    NewField121812.Value = @"O N A Y";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REQUESTUSERDETAIL.CalcValue = REQUESTUSERDETAIL.Value;
                    APPROVEDUSERDETAIL.CalcValue = APPROVEDUSERDETAIL.Value;
                    NewField111811.CalcValue = NewField111811.Value;
                    NewField1117111.CalcValue = NewField1117111.Value;
                    NewField11117111.CalcValue = NewField11117111.Value;
                    NewField121812.CalcValue = NewField121812.Value;
                    return new TTReportObject[] { REQUESTUSERDETAIL,APPROVEDUSERDETAIL,NewField111811,NewField1117111,NewField11117111,NewField121812};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public SerbestBirakmaRaporu MyParentReport
            {
                get { return (SerbestBirakmaRaporu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField TESTNAME { get {return Body().TESTNAME;} }
            public TTReportField TESTRESULT { get {return Body().TESTRESULT;} }
            public TTReportField TESTPERSONNEL { get {return Body().TESTPERSONNEL;} }
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
                list[0] = new TTReportNqlData<DrugProductionTestDetail.DrugTestDetailReportNQL_Class>("DrugTestDetailReportNQL", DrugProductionTestDetail.DrugTestDetailReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public SerbestBirakmaRaporu MyParentReport
                {
                    get { return (SerbestBirakmaRaporu)ParentReport; }
                }
                
                public TTReportField TESTNAME;
                public TTReportField TESTRESULT;
                public TTReportField TESTPERSONNEL; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    TESTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 84, 6, false);
                    TESTNAME.Name = "TESTNAME";
                    TESTNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    TESTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TESTNAME.TextFont.Name = "Arial";
                    TESTNAME.TextFont.Bold = true;
                    TESTNAME.Value = @"{#PRODUCTANALYSESTESTDEFINITION#}";

                    TESTRESULT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 0, 142, 6, false);
                    TESTRESULT.Name = "TESTRESULT";
                    TESTRESULT.DrawStyle = DrawStyleConstants.vbSolid;
                    TESTRESULT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESTRESULT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TESTRESULT.TextFont.Name = "Arial";
                    TESTRESULT.TextFont.Bold = true;
                    TESTRESULT.Value = @"{#RESULT#}";

                    TESTPERSONNEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 0, 200, 6, false);
                    TESTPERSONNEL.Name = "TESTPERSONNEL";
                    TESTPERSONNEL.DrawStyle = DrawStyleConstants.vbSolid;
                    TESTPERSONNEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESTPERSONNEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TESTPERSONNEL.TextFont.Name = "Arial";
                    TESTPERSONNEL.TextFont.Bold = true;
                    TESTPERSONNEL.Value = @"{#ANALYSER#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DrugProductionTestDetail.DrugTestDetailReportNQL_Class dataset_DrugTestDetailReportNQL = ParentGroup.rsGroup.GetCurrentRecord<DrugProductionTestDetail.DrugTestDetailReportNQL_Class>(0);
                    TESTNAME.CalcValue = (dataset_DrugTestDetailReportNQL != null ? Globals.ToStringCore(dataset_DrugTestDetailReportNQL.Productanalysestestdefinition) : "");
                    TESTRESULT.CalcValue = (dataset_DrugTestDetailReportNQL != null ? Globals.ToStringCore(dataset_DrugTestDetailReportNQL.Result) : "");
                    TESTPERSONNEL.CalcValue = (dataset_DrugTestDetailReportNQL != null ? Globals.ToStringCore(dataset_DrugTestDetailReportNQL.Analyser) : "");
                    return new TTReportObject[] { TESTNAME,TESTRESULT,TESTPERSONNEL};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public SerbestBirakmaRaporu()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Object ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "SERBESTBIRAKMARAPORU";
            Caption = "Serbest Bırakma Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 5;
            UserMarginTop = 5;
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