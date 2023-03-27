
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
    /// Üretim Belgesi
    /// </summary>
    public partial class ProductionDocumentReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ProductionDocumentReport MyParentReport
            {
                get { return (ProductionDocumentReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
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
                public ProductionDocumentReport MyParentReport
                {
                    get { return (ProductionDocumentReport)ParentReport; }
                }
                
                public TTReportField NewField111; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 24;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 15, 292, 24, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"ÜRETİM BELGESİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    return new TTReportObject[] { NewField111};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ProductionDocumentReport MyParentReport
                {
                    get { return (ProductionDocumentReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
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
            public ProductionDocumentReport MyParentReport
            {
                get { return (ProductionDocumentReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11112 { get {return Header().NewField11112;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportField NewField1111112 { get {return Header().NewField1111112;} }
            public TTReportField NewField11111111 { get {return Header().NewField11111111;} }
            public TTReportField NewField1111113 { get {return Header().NewField1111113;} }
            public TTReportField NewField11111112 { get {return Header().NewField11111112;} }
            public TTReportField NewField12111112 { get {return Header().NewField12111112;} }
            public TTReportField NewField1111111111 { get {return Header().NewField1111111111;} }
            public TTReportField NewField1161112311 { get {return Header().NewField1161112311;} }
            public TTReportField NewField1261112311 { get {return Header().NewField1261112311;} }
            public TTReportField SIPARISADIVENUMARASI { get {return Header().SIPARISADIVENUMARASI;} }
            public TTReportField TRANSACTIONDATE { get {return Header().TRANSACTIONDATE;} }
            public TTReportField NewField121111121 { get {return Header().NewField121111121;} }
            public TTReportField DESCRIPTION { get {return Footer().DESCRIPTION;} }
            public TTReportField NewField11113 { get {return Footer().NewField11113;} }
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
                public ProductionDocumentReport MyParentReport
                {
                    get { return (ProductionDocumentReport)ParentReport; }
                }
                
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportField NewField1111;
                public TTReportField NewField11112;
                public TTReportField NewField1111111;
                public TTReportField NewField1111112;
                public TTReportField NewField11111111;
                public TTReportField NewField1111113;
                public TTReportField NewField11111112;
                public TTReportField NewField12111112;
                public TTReportField NewField1111111111;
                public TTReportField NewField1161112311;
                public TTReportField NewField1261112311;
                public TTReportField SIPARISADIVENUMARASI;
                public TTReportField TRANSACTIONDATE;
                public TTReportField NewField121111121; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 31;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 8, 22, 31, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111.TextFont.Size = 11;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"
S. Nu.";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 14, 47, 31, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111111.TextFont.Size = 11;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Stok Nu.";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 8, 157, 14, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Size = 11;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Tüketilenler Malzeme";

                    NewField11112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 8, 292, 14, false);
                    NewField11112.Name = "NewField11112";
                    NewField11112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11112.TextFont.Size = 11;
                    NewField11112.TextFont.Bold = true;
                    NewField11112.TextFont.CharSet = 162;
                    NewField11112.Value = @"Üretilen Malzeme";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 14, 119, 31, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111111.TextFont.Size = 11;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"
Malın Cins ve Özellikleri";

                    NewField1111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 14, 141, 31, false);
                    NewField1111112.Name = "NewField1111112";
                    NewField1111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111112.TextFont.Size = 11;
                    NewField1111112.TextFont.Bold = true;
                    NewField1111112.TextFont.CharSet = 162;
                    NewField1111112.Value = @"Miktarı";

                    NewField11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 14, 157, 31, false);
                    NewField11111111.Name = "NewField11111111";
                    NewField11111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111111.TextFont.Size = 11;
                    NewField11111111.TextFont.Bold = true;
                    NewField11111111.TextFont.CharSet = 162;
                    NewField11111111.Value = @"
Ölçü Birimi";

                    NewField1111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 14, 182, 31, false);
                    NewField1111113.Name = "NewField1111113";
                    NewField1111113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111113.TextFont.Size = 11;
                    NewField1111113.TextFont.Bold = true;
                    NewField1111113.TextFont.CharSet = 162;
                    NewField1111113.Value = @"Stok Nu.";

                    NewField11111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 14, 249, 31, false);
                    NewField11111112.Name = "NewField11111112";
                    NewField11111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11111112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11111112.TextFont.Size = 11;
                    NewField11111112.TextFont.Bold = true;
                    NewField11111112.TextFont.CharSet = 162;
                    NewField11111112.Value = @"
Malın Cins ve Özellikleri";

                    NewField12111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 14, 263, 31, false);
                    NewField12111112.Name = "NewField12111112";
                    NewField12111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12111112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12111112.TextFont.Size = 11;
                    NewField12111112.TextFont.Bold = true;
                    NewField12111112.TextFont.CharSet = 162;
                    NewField12111112.Value = @"Miktarı";

                    NewField1111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 276, 14, 292, 31, false);
                    NewField1111111111.Name = "NewField1111111111";
                    NewField1111111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111111111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111111111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111111111.TextFont.Size = 11;
                    NewField1111111111.TextFont.Bold = true;
                    NewField1111111111.TextFont.CharSet = 162;
                    NewField1111111111.Value = @"
Birim Fiyatı";

                    NewField1161112311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 0, 260, 8, false);
                    NewField1161112311.Name = "NewField1161112311";
                    NewField1161112311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1161112311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1161112311.TextFont.Size = 11;
                    NewField1161112311.TextFont.Bold = true;
                    NewField1161112311.TextFont.CharSet = 162;
                    NewField1161112311.Value = @"İşlem Tarihi";

                    NewField1261112311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 70, 8, false);
                    NewField1261112311.Name = "NewField1261112311";
                    NewField1261112311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1261112311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1261112311.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1261112311.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1261112311.TextFont.Size = 11;
                    NewField1261112311.TextFont.Bold = true;
                    NewField1261112311.TextFont.CharSet = 162;
                    NewField1261112311.Value = @"Sipariş İşlem Numarası
";

                    SIPARISADIVENUMARASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 0, 229, 8, false);
                    SIPARISADIVENUMARASI.Name = "SIPARISADIVENUMARASI";
                    SIPARISADIVENUMARASI.DrawStyle = DrawStyleConstants.vbSolid;
                    SIPARISADIVENUMARASI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIPARISADIVENUMARASI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIPARISADIVENUMARASI.TextFont.Size = 11;
                    SIPARISADIVENUMARASI.TextFont.CharSet = 162;
                    SIPARISADIVENUMARASI.Value = @"";

                    TRANSACTIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, 0, 292, 8, false);
                    TRANSACTIONDATE.Name = "TRANSACTIONDATE";
                    TRANSACTIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    TRANSACTIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TRANSACTIONDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TRANSACTIONDATE.TextFont.Size = 11;
                    TRANSACTIONDATE.TextFont.CharSet = 162;
                    TRANSACTIONDATE.Value = @"";

                    NewField121111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 14, 276, 31, false);
                    NewField121111121.Name = "NewField121111121";
                    NewField121111121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121111121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121111121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121111121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121111121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121111121.TextFont.Size = 11;
                    NewField121111121.TextFont.Bold = true;
                    NewField121111121.TextFont.CharSet = 162;
                    NewField121111121.Value = @"Ölçü
Birimi";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11112.CalcValue = NewField11112.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    NewField1111112.CalcValue = NewField1111112.Value;
                    NewField11111111.CalcValue = NewField11111111.Value;
                    NewField1111113.CalcValue = NewField1111113.Value;
                    NewField11111112.CalcValue = NewField11111112.Value;
                    NewField12111112.CalcValue = NewField12111112.Value;
                    NewField1111111111.CalcValue = NewField1111111111.Value;
                    NewField1161112311.CalcValue = NewField1161112311.Value;
                    NewField1261112311.CalcValue = NewField1261112311.Value;
                    SIPARISADIVENUMARASI.CalcValue = @"";
                    TRANSACTIONDATE.CalcValue = @"";
                    NewField121111121.CalcValue = NewField121111121.Value;
                    return new TTReportObject[] { NewField11111,NewField111111,NewField1111,NewField11112,NewField1111111,NewField1111112,NewField11111111,NewField1111113,NewField11111112,NewField12111112,NewField1111111111,NewField1161112311,NewField1261112311,SIPARISADIVENUMARASI,TRANSACTIONDATE,NewField121111121};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
            {
                GeneralProductionAction generalProductionAction = (GeneralProductionAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(GeneralProductionAction));
                SIPARISADIVENUMARASI.CalcValue = generalProductionAction.StockActionID.Value.Value.ToString();
                TRANSACTIONDATE.CalcValue = generalProductionAction.TransactionDate.ToString();
            }
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public ProductionDocumentReport MyParentReport
                {
                    get { return (ProductionDocumentReport)ParentReport; }
                }
                
                public TTReportField DESCRIPTION;
                public TTReportField NewField11113; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    RepeatCount = 0;
                    
                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 2, 292, 7, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.Value = @"";

                    NewField11113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 1, 38, 7, false);
                    NewField11113.Name = "NewField11113";
                    NewField11113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11113.TextFont.Size = 11;
                    NewField11113.TextFont.Bold = true;
                    NewField11113.TextFont.CharSet = 162;
                    NewField11113.Value = @"AÇIKLAMA : ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DESCRIPTION.CalcValue = @"";
                    NewField11113.CalcValue = NewField11113.Value;
                    return new TTReportObject[] { DESCRIPTION,NewField11113};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
            {
                GeneralProductionAction generalProductionAction = (GeneralProductionAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(GeneralProductionAction));
                if(generalProductionAction.Description != null)
                    DESCRIPTION.CalcValue = generalProductionAction.Description.ToString();
            }
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public ProductionDocumentReport MyParentReport
            {
                get { return (ProductionDocumentReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField NSN { get {return Body().NSN;} }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField CONSUMPTIONMATERIALNAME { get {return Body().CONSUMPTIONMATERIALNAME;} }
            public TTReportField CONSUMPTIONMATERIALNSN { get {return Body().CONSUMPTIONMATERIALNSN;} }
            public TTReportField CONSUMPTIONMATERIALAMOUNT { get {return Body().CONSUMPTIONMATERIALAMOUNT;} }
            public TTReportField CONMATERIALDISTRIBUTIONTYPE { get {return Body().CONMATERIALDISTRIBUTIONTYPE;} }
            public TTReportField DISTTYPE_GeneralProductionReportQuery2 { get {return Body().DISTTYPE_GeneralProductionReportQuery2;} }
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
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[2];
                list[0] = new TTReportNqlData<GeneralProductionAction.GeneralProductionReportQuery_Class>("GeneralProductionReportQuery", GeneralProductionAction.GeneralProductionReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                list[1] = new TTReportNqlData<GeneralProductionAction.GeneralProductionReportQuery2_Class>("GeneralProductionReportQuery2", GeneralProductionAction.GeneralProductionReportQuery2((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public ProductionDocumentReport MyParentReport
                {
                    get { return (ProductionDocumentReport)ParentReport; }
                }
                
                public TTReportField ORDERNO;
                public TTReportField NSN;
                public TTReportField NAME;
                public TTReportField AMOUNT;
                public TTReportField UNITPRICE;
                public TTReportField CONSUMPTIONMATERIALNAME;
                public TTReportField CONSUMPTIONMATERIALNSN;
                public TTReportField CONSUMPTIONMATERIALAMOUNT;
                public TTReportField CONMATERIALDISTRIBUTIONTYPE;
                public TTReportField DISTTYPE_GeneralProductionReportQuery2; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 22, 5, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Size = 9;
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{@counter@} ";

                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 0, 182, 5, false);
                    NSN.Name = "NSN";
                    NSN.DrawStyle = DrawStyleConstants.vbSolid;
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.Value = @"{#NSN!GeneralProductionReportQuery2#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 0, 249, 5, false);
                    NAME.Name = "NAME";
                    NAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.Value = @"{#NAME!GeneralProductionReportQuery2#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 0, 263, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.Value = @"{#AMOUNT!GeneralProductionReportQuery2#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 276, 0, 292, 5, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.Value = @"{#UNITPRICE!GeneralProductionReportQuery2#}";

                    CONSUMPTIONMATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 0, 119, 5, false);
                    CONSUMPTIONMATERIALNAME.Name = "CONSUMPTIONMATERIALNAME";
                    CONSUMPTIONMATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMPTIONMATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMPTIONMATERIALNAME.Value = @"{#CONSUMPTIONMATERIALNAME#}";

                    CONSUMPTIONMATERIALNSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 47, 5, false);
                    CONSUMPTIONMATERIALNSN.Name = "CONSUMPTIONMATERIALNSN";
                    CONSUMPTIONMATERIALNSN.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMPTIONMATERIALNSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMPTIONMATERIALNSN.Value = @"{#CONSUMPTIONMATERIALNSN#}";

                    CONSUMPTIONMATERIALAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 0, 141, 5, false);
                    CONSUMPTIONMATERIALAMOUNT.Name = "CONSUMPTIONMATERIALAMOUNT";
                    CONSUMPTIONMATERIALAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMPTIONMATERIALAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMPTIONMATERIALAMOUNT.Value = @"{#CONSUMPTIONMATERIALAMOUNT#}";

                    CONMATERIALDISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 0, 157, 5, false);
                    CONMATERIALDISTRIBUTIONTYPE.Name = "CONMATERIALDISTRIBUTIONTYPE";
                    CONMATERIALDISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    CONMATERIALDISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONMATERIALDISTRIBUTIONTYPE.ObjectDefName = "DistributionTypeDefinition";
                    CONMATERIALDISTRIBUTIONTYPE.DataMember = "DistributionType";
                    CONMATERIALDISTRIBUTIONTYPE.Value = @"{#CONMATERIALDISTRIBUTIONTYPE#}";

                    DISTTYPE_GeneralProductionReportQuery2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 0, 276, 5, false);
                    DISTTYPE_GeneralProductionReportQuery2.Name = "DISTTYPE_GeneralProductionReportQuery2";
                    DISTTYPE_GeneralProductionReportQuery2.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTTYPE_GeneralProductionReportQuery2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTTYPE_GeneralProductionReportQuery2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DISTTYPE_GeneralProductionReportQuery2.ObjectDefName = "DistributionTypeDefinition";
                    DISTTYPE_GeneralProductionReportQuery2.DataMember = "DistributionType";
                    DISTTYPE_GeneralProductionReportQuery2.Value = @"{#DISTTYPE!GeneralProductionReportQuery2#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    GeneralProductionAction.GeneralProductionReportQuery_Class dataset_GeneralProductionReportQuery = ParentGroup.rsGroup.GetCurrentRecord<GeneralProductionAction.GeneralProductionReportQuery_Class>(0);
                    GeneralProductionAction.GeneralProductionReportQuery2_Class dataset_GeneralProductionReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<GeneralProductionAction.GeneralProductionReportQuery2_Class>(1);
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString() + @" ";
                    NSN.CalcValue = (dataset_GeneralProductionReportQuery2 != null ? Globals.ToStringCore(dataset_GeneralProductionReportQuery2.Nsn) : "");
                    NAME.CalcValue = (dataset_GeneralProductionReportQuery2 != null ? Globals.ToStringCore(dataset_GeneralProductionReportQuery2.Name) : "");
                    AMOUNT.CalcValue = (dataset_GeneralProductionReportQuery2 != null ? Globals.ToStringCore(dataset_GeneralProductionReportQuery2.Amount) : "");
                    UNITPRICE.CalcValue = (dataset_GeneralProductionReportQuery2 != null ? Globals.ToStringCore(dataset_GeneralProductionReportQuery2.UnitPrice) : "");
                    CONSUMPTIONMATERIALNAME.CalcValue = (dataset_GeneralProductionReportQuery != null ? Globals.ToStringCore(dataset_GeneralProductionReportQuery.Consumptionmaterialname) : "");
                    CONSUMPTIONMATERIALNSN.CalcValue = (dataset_GeneralProductionReportQuery != null ? Globals.ToStringCore(dataset_GeneralProductionReportQuery.Consumptionmaterialnsn) : "");
                    CONSUMPTIONMATERIALAMOUNT.CalcValue = (dataset_GeneralProductionReportQuery != null ? Globals.ToStringCore(dataset_GeneralProductionReportQuery.Consumptionmaterialamount) : "");
                    CONMATERIALDISTRIBUTIONTYPE.CalcValue = (dataset_GeneralProductionReportQuery != null ? Globals.ToStringCore(dataset_GeneralProductionReportQuery.Conmaterialdistributiontype) : "");
                    CONMATERIALDISTRIBUTIONTYPE.PostFieldValueCalculation();
                    DISTTYPE_GeneralProductionReportQuery2.CalcValue = (dataset_GeneralProductionReportQuery2 != null ? Globals.ToStringCore(dataset_GeneralProductionReportQuery2.Disttype) : "");
                    DISTTYPE_GeneralProductionReportQuery2.PostFieldValueCalculation();
                    return new TTReportObject[] { ORDERNO,NSN,NAME,AMOUNT,UNITPRICE,CONSUMPTIONMATERIALNAME,CONSUMPTIONMATERIALNSN,CONSUMPTIONMATERIALAMOUNT,CONMATERIALDISTRIBUTIONTYPE,DISTTYPE_GeneralProductionReportQuery2};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //            if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
//            {
//                GeneralProductionAction generalProductionAction = (GeneralProductionAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(GeneralProductionAction));
//                NAME.CalcValue = generalProductionAction.Material.Name.ToString();
//                NSN.CalcValue = generalProductionAction.Material.NATOStockNO.ToString();
//                AMOUNT.CalcValue = generalProductionAction.Amount.ToString();
//                UNITPRICE.CalcValue = generalProductionAction.UnitPrice.ToString();
//            }
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

        public ProductionDocumentReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "İşlem Numarasını Girin", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "PRODUCTIONDOCUMENTREPORT";
            Caption = "Üretim Belgesi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            PaperSize = 256;
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