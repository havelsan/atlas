
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
    /// Kayıt Silmeye Esas Teknik Rapor ( HEK Raporu )
    /// </summary>
    public partial class KayitSilmeyeEsasTeknikRapor : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class pagenumberGroup : TTReportGroup
        {
            public KayitSilmeyeEsasTeknikRapor MyParentReport
            {
                get { return (KayitSilmeyeEsasTeknikRapor)ParentReport; }
            }

            new public pagenumberGroupHeader Header()
            {
                return (pagenumberGroupHeader)_header;
            }

            new public pagenumberGroupFooter Footer()
            {
                return (pagenumberGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public pagenumberGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public pagenumberGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new pagenumberGroupHeader(this);
                _footer = new pagenumberGroupFooter(this);

            }

            public partial class pagenumberGroupHeader : TTReportSection
            {
                public KayitSilmeyeEsasTeknikRapor MyParentReport
                {
                    get { return (KayitSilmeyeEsasTeknikRapor)ParentReport; }
                }
                 
                public pagenumberGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class pagenumberGroupFooter : TTReportSection
            {
                public KayitSilmeyeEsasTeknikRapor MyParentReport
                {
                    get { return (KayitSilmeyeEsasTeknikRapor)ParentReport; }
                }
                
                public TTReportField NewField1; 
                public pagenumberGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 1, 123, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 10;
                    NewField1.TextFont.CharSet = 1;
                    NewField1.Value = @"{@pagenumber@} / {@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = ParentReport.CurrentPageNumber.ToString() + @" / " + ParentReport.ReportTotalPageCount;
                    return new TTReportObject[] { NewField1};
                }
            }

        }

        public pagenumberGroup pagenumber;

        public partial class FooterGroup : TTReportGroup
        {
            public KayitSilmeyeEsasTeknikRapor MyParentReport
            {
                get { return (KayitSilmeyeEsasTeknikRapor)ParentReport; }
            }

            new public FooterGroupHeader Header()
            {
                return (FooterGroupHeader)_header;
            }

            new public FooterGroupFooter Footer()
            {
                return (FooterGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField11115111 { get {return Header().NewField11115111;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField SENDERSECTION { get {return Header().SENDERSECTION;} }
            public TTReportField NewField111151111 { get {return Header().NewField111151111;} }
            public TTReportField MATERIALNAME { get {return Header().MATERIALNAME;} }
            public TTReportField SERIALNO { get {return Header().SERIALNO;} }
            public TTReportField NATOSTOCKNO { get {return Header().NATOSTOCKNO;} }
            public TTReportField AMOUNT { get {return Header().AMOUNT;} }
            public TTReportField AMOUNT11 { get {return Header().AMOUNT11;} }
            public TTReportField REQUESTNO { get {return Header().REQUESTNO;} }
            public TTReportField DISTYPE { get {return Header().DISTYPE;} }
            public TTReportField AMOUNT111 { get {return Header().AMOUNT111;} }
            public TTReportField AMOUNT1111 { get {return Header().AMOUNT1111;} }
            public TTReportField AMOUNT11111 { get {return Header().AMOUNT11111;} }
            public TTReportField AMOUNT111111 { get {return Header().AMOUNT111111;} }
            public TTReportField AMOUNT1111111 { get {return Header().AMOUNT1111111;} }
            public TTReportField AMOUNT11111111 { get {return Header().AMOUNT11111111;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportField NewField131 { get {return Footer().NewField131;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportField NewField1171 { get {return Footer().NewField1171;} }
            public TTReportField NewField1271 { get {return Footer().NewField1271;} }
            public TTReportShape NewLine12211 { get {return Footer().NewLine12211;} }
            public TTReportField NewField181 { get {return Footer().NewField181;} }
            public TTReportField TEKNIKUYE1 { get {return Footer().TEKNIKUYE1;} }
            public TTReportField TEKNIKUYE2 { get {return Footer().TEKNIKUYE2;} }
            public TTReportField BASKAN { get {return Footer().BASKAN;} }
            public TTReportField UYE { get {return Footer().UYE;} }
            public TTReportField ONAY { get {return Footer().ONAY;} }
            public TTReportShape NewLine111221 { get {return Footer().NewLine111221;} }
            public TTReportField NewField1172 { get {return Footer().NewField1172;} }
            public TTReportField NewField12711 { get {return Footer().NewField12711;} }
            public TTReportShape NewLine111222 { get {return Footer().NewLine111222;} }
            public TTReportShape NewLine1222111 { get {return Footer().NewLine1222111;} }
            public TTReportShape NewLine1122111 { get {return Footer().NewLine1122111;} }
            public FooterGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public FooterGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new FooterGroupHeader(this);
                _footer = new FooterGroupFooter(this);

            }

            public partial class FooterGroupHeader : TTReportSection
            {
                public KayitSilmeyeEsasTeknikRapor MyParentReport
                {
                    get { return (KayitSilmeyeEsasTeknikRapor)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField121;
                public TTReportField NewField11115111;
                public TTReportField NewField141;
                public TTReportField SENDERSECTION;
                public TTReportField NewField111151111;
                public TTReportField MATERIALNAME;
                public TTReportField SERIALNO;
                public TTReportField NATOSTOCKNO;
                public TTReportField AMOUNT;
                public TTReportField AMOUNT11;
                public TTReportField REQUESTNO;
                public TTReportField DISTYPE;
                public TTReportField AMOUNT111;
                public TTReportField AMOUNT1111;
                public TTReportField AMOUNT11111;
                public TTReportField AMOUNT111111;
                public TTReportField AMOUNT1111111;
                public TTReportField AMOUNT11111111;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine12; 
                public FooterGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 48;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 6, 243, 11, false);
                    NewField11.Name = "NewField11";
                    NewField11.Visible = EvetHayirEnum.ehHayir;
                    NewField11.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.TextFont.Size = 10;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"HİZMETE ÖZEL";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 6, 202, 13, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Size = 12;
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @"HASAR VE DURUM TESPİT RAPORU / TEKNİK RAPOR / HEK RAPORU";

                    NewField11115111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 14, 105, 20, false);
                    NewField11115111.Name = "NewField11115111";
                    NewField11115111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField11115111.TextFont.Size = 10;
                    NewField11115111.TextFont.Bold = true;
                    NewField11115111.Value = @"A. MALZEMENİN AİT OLDUĞU BİRLİK / BAŞKANLIK";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 14, 109, 20, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.TextFont.Size = 10;
                    NewField141.TextFont.Bold = true;
                    NewField141.Value = @":";

                    SENDERSECTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 14, 202, 24, false);
                    SENDERSECTION.Name = "SENDERSECTION";
                    SENDERSECTION.DrawStyle = DrawStyleConstants.vbInvisible;
                    SENDERSECTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENDERSECTION.MultiLine = EvetHayirEnum.ehEvet;
                    SENDERSECTION.WordBreak = EvetHayirEnum.ehEvet;
                    SENDERSECTION.Value = @"";

                    NewField111151111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 24, 105, 30, false);
                    NewField111151111.Name = "NewField111151111";
                    NewField111151111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111151111.TextFont.Size = 10;
                    NewField111151111.TextFont.Bold = true;
                    NewField111151111.Value = @"B. MALZEMENIN TANIMI :";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 38, 148, 48, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.Value = @"";

                    SERIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 38, 179, 48, false);
                    SERIALNO.Name = "SERIALNO";
                    SERIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNO.MultiLine = EvetHayirEnum.ehEvet;
                    SERIALNO.WordBreak = EvetHayirEnum.ehEvet;
                    SERIALNO.Value = @"";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 38, 73, 48, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.Value = @"";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 38, 188, 48, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbInvisible;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.Value = @"";

                    AMOUNT11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 38, 26, 48, false);
                    AMOUNT11.Name = "AMOUNT11";
                    AMOUNT11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT11.Value = @"1";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 38, 47, 48, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.Value = @"";

                    DISTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 38, 203, 48, false);
                    DISTYPE.Name = "DISTYPE";
                    DISTYPE.DrawStyle = DrawStyleConstants.vbInvisible;
                    DISTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTYPE.Value = @"";

                    AMOUNT111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 31, 26, 38, false);
                    AMOUNT111.Name = "AMOUNT111";
                    AMOUNT111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT111.VertAlign = VerticalAlignmentEnum.vaTop;
                    AMOUNT111.TextFont.Size = 10;
                    AMOUNT111.TextFont.Bold = true;
                    AMOUNT111.Value = @"S.Nu.";

                    AMOUNT1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 31, 47, 38, false);
                    AMOUNT1111.Name = "AMOUNT1111";
                    AMOUNT1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT1111.VertAlign = VerticalAlignmentEnum.vaTop;
                    AMOUNT1111.TextFont.Size = 10;
                    AMOUNT1111.TextFont.Bold = true;
                    AMOUNT1111.Value = @"Sipariş Nu.";

                    AMOUNT11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 31, 73, 38, false);
                    AMOUNT11111.Name = "AMOUNT11111";
                    AMOUNT11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT11111.VertAlign = VerticalAlignmentEnum.vaTop;
                    AMOUNT11111.TextFont.Size = 10;
                    AMOUNT11111.TextFont.Bold = true;
                    AMOUNT11111.Value = @"Stok Nu.";

                    AMOUNT111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 31, 148, 38, false);
                    AMOUNT111111.Name = "AMOUNT111111";
                    AMOUNT111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT111111.VertAlign = VerticalAlignmentEnum.vaTop;
                    AMOUNT111111.TextFont.Size = 10;
                    AMOUNT111111.TextFont.Bold = true;
                    AMOUNT111111.Value = @"Malzemenin Cinsi";

                    AMOUNT1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 31, 179, 38, false);
                    AMOUNT1111111.Name = "AMOUNT1111111";
                    AMOUNT1111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT1111111.VertAlign = VerticalAlignmentEnum.vaTop;
                    AMOUNT1111111.MultiLine = EvetHayirEnum.ehEvet;
                    AMOUNT1111111.TextFont.Size = 10;
                    AMOUNT1111111.TextFont.Bold = true;
                    AMOUNT1111111.Value = @"Mrk - Mdl - S.Nu";

                    AMOUNT11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 31, 203, 38, false);
                    AMOUNT11111111.Name = "AMOUNT11111111";
                    AMOUNT11111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT11111111.VertAlign = VerticalAlignmentEnum.vaTop;
                    AMOUNT11111111.TextFont.Size = 10;
                    AMOUNT11111111.TextFont.Bold = true;
                    AMOUNT11111111.Value = @"Miktarı";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 179, 48, 203, 48, false);
                    NewLine1.Name = "NewLine1";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 203, 38, 203, 48, false);
                    NewLine2.Name = "NewLine2";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 179, 38, 179, 48, false);
                    NewLine12.Name = "NewLine12";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField11115111.CalcValue = NewField11115111.Value;
                    NewField141.CalcValue = NewField141.Value;
                    SENDERSECTION.CalcValue = @"";
                    NewField111151111.CalcValue = NewField111151111.Value;
                    MATERIALNAME.CalcValue = @"";
                    SERIALNO.CalcValue = @"";
                    NATOSTOCKNO.CalcValue = @"";
                    AMOUNT.CalcValue = @"";
                    AMOUNT11.CalcValue = AMOUNT11.Value;
                    REQUESTNO.CalcValue = @"";
                    DISTYPE.CalcValue = @"";
                    AMOUNT111.CalcValue = AMOUNT111.Value;
                    AMOUNT1111.CalcValue = AMOUNT1111.Value;
                    AMOUNT11111.CalcValue = AMOUNT11111.Value;
                    AMOUNT111111.CalcValue = AMOUNT111111.Value;
                    AMOUNT1111111.CalcValue = AMOUNT1111111.Value;
                    AMOUNT11111111.CalcValue = AMOUNT11111111.Value;
                    return new TTReportObject[] { NewField11,NewField121,NewField11115111,NewField141,SENDERSECTION,NewField111151111,MATERIALNAME,SERIALNO,NATOSTOCKNO,AMOUNT,AMOUNT11,REQUESTNO,DISTYPE,AMOUNT111,AMOUNT1111,AMOUNT11111,AMOUNT111111,AMOUNT1111111,AMOUNT11111111};
                }

                public override void RunScript()
                {
#region FOOTER HEADER_Script
                    CMRAction cmrAction = (CMRAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(CMRAction));

            bool tecnicalMember = false;
            string chefString = string.Empty;
            string techMember1 = string.Empty;
            string techMember2 = string.Empty;
            string sMember = string.Empty;
            string approvalMember = string.Empty;

            if (cmrAction is MaterialRepair)
            {
                MaterialRepair mRepair = (MaterialRepair)cmrAction;
                MATERIALNAME.CalcValue = mRepair.FixedAssetDefinition.Name;
                NATOSTOCKNO.CalcValue = mRepair.FixedAssetDefinition.NATOStockNO;
                SENDERSECTION.CalcValue = mRepair.SenderSection.Name ;
                REQUESTNO.CalcValue = mRepair.RequestNo.ToString();
                SERIALNO.CalcValue = "-";
                AMOUNT.CalcValue = mRepair.HEKMaterialAmount.ToString();
                DISTYPE.CalcValue = mRepair.FixedAssetDefinition.StockCard.DistributionType.DistributionType.ToString();
            }
            else
            {
                Repair repair = (Repair)cmrAction;
                MATERIALNAME.CalcValue = repair.FixedAssetMaterialDefinition.FixedAssetDefinition.Name;
                NATOSTOCKNO.CalcValue = repair.FixedAssetMaterialDefinition.FixedAssetDefinition.NATOStockNO;
                SENDERSECTION.CalcValue = repair.SenderSection.Name ;
                REQUESTNO.CalcValue = repair.RequestNo.ToString();
                SERIALNO.CalcValue = repair.FixedAssetMaterialDefinition.Mark + " - " + repair.FixedAssetMaterialDefinition.Model + " - "+ repair.FixedAssetMaterialDefinition.SerialNumber;
                AMOUNT.CalcValue = "1";
                DISTYPE.CalcValue = repair.FixedAssetMaterialDefinition.FixedAssetDefinition.StockCard.DistributionType.DistributionType.ToString();
            }
#endregion FOOTER HEADER_Script
                }
            }
            public partial class FooterGroupFooter : TTReportSection
            {
                public KayitSilmeyeEsasTeknikRapor MyParentReport
                {
                    get { return (KayitSilmeyeEsasTeknikRapor)ParentReport; }
                }
                
                public TTReportField NewField131;
                public TTReportField NewField14;
                public TTReportField NewField1171;
                public TTReportField NewField1271;
                public TTReportShape NewLine12211;
                public TTReportField NewField181;
                public TTReportField TEKNIKUYE1;
                public TTReportField TEKNIKUYE2;
                public TTReportField BASKAN;
                public TTReportField UYE;
                public TTReportField ONAY;
                public TTReportShape NewLine111221;
                public TTReportField NewField1172;
                public TTReportField NewField12711;
                public TTReportShape NewLine111222;
                public TTReportShape NewLine1222111;
                public TTReportShape NewLine1122111; 
                public FooterGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 102;
                    RepeatCount = 0;
                    
                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 14, 244, 19, false);
                    NewField131.Name = "NewField131";
                    NewField131.Visible = EvetHayirEnum.ehHayir;
                    NewField131.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.TextFont.Size = 10;
                    NewField131.TextFont.Bold = true;
                    NewField131.Value = @"HİZMETE ÖZEL";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 203, 7, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.TextFont.Size = 10;
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @"RAPORU DÜZENLEYENLER";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 8, 142, 14, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1171.TextFont.Size = 10;
                    NewField1171.TextFont.Bold = true;
                    NewField1171.Value = @"TEKNİK ÜYE";

                    NewField1271 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 8, 197, 14, false);
                    NewField1271.Name = "NewField1271";
                    NewField1271.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1271.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1271.TextFont.Size = 10;
                    NewField1271.TextFont.Bold = true;
                    NewField1271.Value = @"HEYET BAŞKANI";

                    NewLine12211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 64, 15, 107, 15, false);
                    NewLine12211.Name = "NewLine12211";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 56, 118, 62, false);
                    NewField181.Name = "NewField181";
                    NewField181.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField181.TextFont.Size = 10;
                    NewField181.TextFont.Bold = true;
                    NewField181.Value = @"ONAY";

                    TEKNIKUYE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 27, 107, 53, false);
                    TEKNIKUYE1.Name = "TEKNIKUYE1";
                    TEKNIKUYE1.DrawStyle = DrawStyleConstants.vbInvisible;
                    TEKNIKUYE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKNIKUYE1.VertAlign = VerticalAlignmentEnum.vaTop;
                    TEKNIKUYE1.MultiLine = EvetHayirEnum.ehEvet;
                    TEKNIKUYE1.WordBreak = EvetHayirEnum.ehEvet;
                    TEKNIKUYE1.TextFont.Size = 10;
                    TEKNIKUYE1.Value = @"{%TEKNIKUYE1%}";

                    TEKNIKUYE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 27, 156, 53, false);
                    TEKNIKUYE2.Name = "TEKNIKUYE2";
                    TEKNIKUYE2.DrawStyle = DrawStyleConstants.vbInvisible;
                    TEKNIKUYE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKNIKUYE2.VertAlign = VerticalAlignmentEnum.vaTop;
                    TEKNIKUYE2.MultiLine = EvetHayirEnum.ehEvet;
                    TEKNIKUYE2.WordBreak = EvetHayirEnum.ehEvet;
                    TEKNIKUYE2.TextFont.Size = 10;
                    TEKNIKUYE2.Value = @"{%TEKNIKUYE2%}";

                    BASKAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 27, 203, 53, false);
                    BASKAN.Name = "BASKAN";
                    BASKAN.DrawStyle = DrawStyleConstants.vbInvisible;
                    BASKAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASKAN.VertAlign = VerticalAlignmentEnum.vaTop;
                    BASKAN.MultiLine = EvetHayirEnum.ehEvet;
                    BASKAN.WordBreak = EvetHayirEnum.ehEvet;
                    BASKAN.TextFont.Size = 10;
                    BASKAN.Value = @"{%BASKAN%}";

                    UYE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 27, 58, 53, false);
                    UYE.Name = "UYE";
                    UYE.DrawStyle = DrawStyleConstants.vbInvisible;
                    UYE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UYE.VertAlign = VerticalAlignmentEnum.vaTop;
                    UYE.MultiLine = EvetHayirEnum.ehEvet;
                    UYE.WordBreak = EvetHayirEnum.ehEvet;
                    UYE.TextFont.Size = 10;
                    UYE.Value = @"{%UYE%}";

                    ONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 75, 133, 101, false);
                    ONAY.Name = "ONAY";
                    ONAY.DrawStyle = DrawStyleConstants.vbInvisible;
                    ONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONAY.VertAlign = VerticalAlignmentEnum.vaTop;
                    ONAY.MultiLine = EvetHayirEnum.ehEvet;
                    ONAY.WordBreak = EvetHayirEnum.ehEvet;
                    ONAY.TextFont.Size = 10;
                    ONAY.Value = @"{%ONAY%}";

                    NewLine111221 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 15, 58, 15, false);
                    NewLine111221.Name = "NewLine111221";

                    NewField1172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 8, 49, 14, false);
                    NewField1172.Name = "NewField1172";
                    NewField1172.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1172.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1172.TextFont.Size = 10;
                    NewField1172.TextFont.Bold = true;
                    NewField1172.Value = @"ÜYE";

                    NewField12711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 8, 92, 14, false);
                    NewField12711.Name = "NewField12711";
                    NewField12711.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField12711.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12711.TextFont.Size = 10;
                    NewField12711.TextFont.Bold = true;
                    NewField12711.Value = @"TEKNİK ÜYE";

                    NewLine111222 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 113, 15, 156, 15, false);
                    NewLine111222.Name = "NewLine111222";

                    NewLine1222111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 160, 15, 203, 15, false);
                    NewLine1222111.Name = "NewLine1222111";

                    NewLine1122111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 90, 63, 133, 63, false);
                    NewLine1122111.Name = "NewLine1122111";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField131.CalcValue = NewField131.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField1271.CalcValue = NewField1271.Value;
                    NewField181.CalcValue = NewField181.Value;
                    TEKNIKUYE1.CalcValue = MyParentReport.Footer.TEKNIKUYE1.CalcValue;
                    TEKNIKUYE2.CalcValue = MyParentReport.Footer.TEKNIKUYE2.CalcValue;
                    BASKAN.CalcValue = MyParentReport.Footer.BASKAN.CalcValue;
                    UYE.CalcValue = MyParentReport.Footer.UYE.CalcValue;
                    ONAY.CalcValue = MyParentReport.Footer.ONAY.CalcValue;
                    NewField1172.CalcValue = NewField1172.Value;
                    NewField12711.CalcValue = NewField12711.Value;
                    return new TTReportObject[] { NewField131,NewField14,NewField1171,NewField1271,NewField181,TEKNIKUYE1,TEKNIKUYE2,BASKAN,UYE,ONAY,NewField1172,NewField12711};
                }

                public override void RunScript()
                {
#region FOOTER FOOTER_Script
                    CMRAction cmrAction = (CMRAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(CMRAction));

            bool tecnicalMember = false;
            string chefString = string.Empty;
            string techMember1 = string.Empty;
            string techMember2 = string.Empty;
            string sMember = string.Empty;
            string approvalMember = string.Empty;

            
            
            if (cmrAction is MaterialRepair)
            {
                MaterialRepair mRepair = (MaterialRepair)cmrAction;
                foreach (RepairHEKCommisionMember member in mRepair.RepairHEKCommisionMembers)
                {
                    if (member.MemberDuty == CommisionMemberDutyEnum.Chief)
                    {
                        chefString += member.ResUser.Name + "\r\n";
                        if (member.ResUser.MilitaryClass != null)
                            chefString += member.ResUser.MilitaryClass.ShortName;
                        if (member.ResUser.Rank != null)
                        {
                            if(member.ResUser.StaffOfficer.HasValue && (bool)member.ResUser.StaffOfficer)
                                chefString += "Kurmay " + member.ResUser.Rank.ShortName;
                            else
                                chefString += member.ResUser.Rank.ShortName + "\r\n";
                        }
                        chefString += "(" + member.ResUser.EmploymentRecordID + ")";
                        BASKAN.CalcValue = chefString;
                    }
                    if (member.MemberDuty == CommisionMemberDutyEnum.TechnicalMember)
                    {
                        if (tecnicalMember == false)
                        {
                            techMember1 += member.ResUser.Name + "\r\n";
                            if (member.ResUser.MilitaryClass != null)
                                techMember1 += member.ResUser.MilitaryClass.ShortName;
                            if (member.ResUser.Rank != null)
                            {
                                if(member.ResUser.StaffOfficer.HasValue && (bool)member.ResUser.StaffOfficer)
                                    techMember1 += "Kurmay " + member.ResUser.Rank.ShortName;
                                else
                                    techMember1 += member.ResUser.Rank.ShortName + "\r\n";
                            }
                            techMember1 += "(" + member.ResUser.EmploymentRecordID + ")";
                            TEKNIKUYE1.CalcValue = techMember1;
                            tecnicalMember = true;
                        }
                        else
                        {
                            techMember2 += member.ResUser.Name + "\r\n";
                            if (member.ResUser.MilitaryClass != null)
                                techMember2 += member.ResUser.MilitaryClass.ShortName;
                            if (member.ResUser.Rank != null)
                            {
                                if(member.ResUser.StaffOfficer.HasValue && (bool)member.ResUser.StaffOfficer)
                                    techMember2 += "Kurmay " + member.ResUser.Rank.ShortName;
                                else
                                    techMember2 += member.ResUser.Rank.ShortName + "\r\n";
                            }
                            techMember2 += "(" + member.ResUser.EmploymentRecordID + ")";
                            TEKNIKUYE2.CalcValue = techMember2;
                        }
                    }
                    if(member.MemberDuty == CommisionMemberDutyEnum.Member)
                    {
                        sMember += member.ResUser.Name + "\r\n";
                        if (member.ResUser.MilitaryClass != null)
                            sMember += member.ResUser.MilitaryClass.ShortName;
                        if (member.ResUser.Rank != null)
                        {
                            if(member.ResUser.StaffOfficer.HasValue && (bool)member.ResUser.StaffOfficer)
                                sMember += "Kurmay " + member.ResUser.Rank.ShortName;
                            else
                                sMember += member.ResUser.Rank.ShortName + "\r\n";
                        }
                        sMember += "(" + member.ResUser.EmploymentRecordID + ")";
                        UYE.CalcValue = sMember;
                        
                    }
                    if(member.MemberDuty == CommisionMemberDutyEnum.Approval)
                    {
                        approvalMember += member.ResUser.Name + "\r\n";
                        if(member.ResUser.Title.HasValue)
                        {
                            TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(UserTitleEnum).Name];
                            approvalMember += dataType.EnumValueDefs[(int)member.ResUser.Title.Value].DisplayText;
                        }
                        if (member.ResUser.MilitaryClass != null)
                            approvalMember += member.ResUser.MilitaryClass.ShortName;
                        if (member.ResUser.Rank != null)
                        {
                            if(member.ResUser.StaffOfficer.HasValue && (bool)member.ResUser.StaffOfficer)
                                approvalMember += "Kurmay " + member.ResUser.Rank.ShortName;
                            else
                                approvalMember += member.ResUser.Rank.ShortName + "\r\n";
                        }
                        approvalMember += "(" + member.ResUser.EmploymentRecordID + ")\r\n";
                        if(member.ResUser.Work != string.Empty)
                        {
                            approvalMember += member.ResUser.Work;
                        }
                        ONAY.CalcValue = approvalMember;
                    }
                }
            }
            else
            {
                Repair repair = (Repair)cmrAction;
                
                foreach (RepairHEKCommisionMember member in repair.RepairHEKCommisionMembers)
                {
                    if (member.MemberDuty == CommisionMemberDutyEnum.Chief)
                    {
                        chefString += member.ResUser.Name + "\r\n";
                        if (member.ResUser.MilitaryClass != null)
                            chefString += member.ResUser.MilitaryClass.ShortName;
                        if (member.ResUser.Rank != null)
                        {
                            if(member.ResUser.StaffOfficer.HasValue && (bool)member.ResUser.StaffOfficer)
                                chefString += "Kurmay " + member.ResUser.Rank.ShortName;
                            else
                                chefString += member.ResUser.Rank.ShortName + "\r\n";
                        }
                        chefString += "(" + member.ResUser.EmploymentRecordID + ")";
                        BASKAN.CalcValue = chefString;
                    }
                    if (member.MemberDuty == CommisionMemberDutyEnum.TechnicalMember)
                    {
                        if (tecnicalMember == false)
                        {
                            techMember1 += member.ResUser.Name + "\r\n";
                            if (member.ResUser.MilitaryClass != null)
                                techMember1 += member.ResUser.MilitaryClass.ShortName;
                            if (member.ResUser.Rank != null)
                            {
                                if(member.ResUser.StaffOfficer.HasValue && (bool)member.ResUser.StaffOfficer)
                                    techMember1 += "Kurmay " + member.ResUser.Rank.ShortName;
                                else
                                    techMember1 += member.ResUser.Rank.ShortName + "\r\n";
                            }
                            techMember1 += "(" + member.ResUser.EmploymentRecordID + ")";
                            TEKNIKUYE1.CalcValue = techMember1;
                            tecnicalMember = true;
                        }
                        else
                        {
                            techMember2 += member.ResUser.Name + "\r\n";
                            if (member.ResUser.MilitaryClass != null)
                                techMember2 += member.ResUser.MilitaryClass.ShortName;
                            if (member.ResUser.Rank != null)
                            {
                                if(member.ResUser.StaffOfficer.HasValue && (bool)member.ResUser.StaffOfficer)
                                    techMember2 += "Kurmay " + member.ResUser.Rank.ShortName;
                                else
                                    techMember2 += member.ResUser.Rank.ShortName + "\r\n";
                            }
                            techMember2 += "(" + member.ResUser.EmploymentRecordID + ")";
                            TEKNIKUYE2.CalcValue = techMember2;
                        }
                    }
                    if(member.MemberDuty == CommisionMemberDutyEnum.Member)
                    {
                        sMember += member.ResUser.Name + "\r\n";
                        if (member.ResUser.MilitaryClass != null)
                            sMember += member.ResUser.MilitaryClass.ShortName;
                        if (member.ResUser.Rank != null)
                        {
                            if(member.ResUser.StaffOfficer.HasValue && (bool)member.ResUser.StaffOfficer)
                                sMember += "Kurmay " + member.ResUser.Rank.ShortName;
                            else
                                sMember += member.ResUser.Rank.ShortName + "\r\n";
                        }
                        sMember += "(" + member.ResUser.EmploymentRecordID + ")";
                        UYE.CalcValue = sMember;
                    }
                    if(member.MemberDuty == CommisionMemberDutyEnum.Approval)
                    {
                        approvalMember += member.ResUser.Name + "\r\n";
                        if(member.ResUser.Title.HasValue)
                        {
                            TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(UserTitleEnum).Name];
                            approvalMember += dataType.EnumValueDefs[(int)member.ResUser.Title.Value].DisplayText;
                        }
                        if (member.ResUser.MilitaryClass != null)
                            approvalMember += member.ResUser.MilitaryClass.ShortName;
                        if (member.ResUser.Rank != null)
                        {
                            if(member.ResUser.StaffOfficer.HasValue && (bool)member.ResUser.StaffOfficer)
                                approvalMember += "Kurmay " + member.ResUser.Rank.ShortName;
                            else
                                approvalMember += member.ResUser.Rank.ShortName + "\r\n";
                        }
                        approvalMember += "(" + member.ResUser.EmploymentRecordID + ")\r\n";
                        if(member.ResUser.Work != string.Empty )
                        {
                            approvalMember += member.ResUser.Work;
                        }
                        ONAY.CalcValue = approvalMember;
                    }
                }
            }
#endregion FOOTER FOOTER_Script
                }
            }

        }

        public FooterGroup Footer;

        public partial class PARTAGroup : TTReportGroup
        {
            public KayitSilmeyeEsasTeknikRapor MyParentReport
            {
                get { return (KayitSilmeyeEsasTeknikRapor)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1111151111 { get {return Header().NewField1111151111;} }
            public TTReportField NewField11511 { get {return Header().NewField11511;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField111511 { get {return Header().NewField111511;} }
            public TTReportField FAULTDESCRIPTION { get {return Header().FAULTDESCRIPTION;} }
            public TTReportField PRECONTROLNOTES { get {return Header().PRECONTROLNOTES;} }
            public TTReportField REQUESTDATE { get {return Header().REQUESTDATE;} }
            public TTReportField NewField1115111 { get {return Header().NewField1115111;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField111512 { get {return Header().NewField111512;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField MATERIALPRICE { get {return Header().MATERIALPRICE;} }
            public TTReportField NewField1215111 { get {return Header().NewField1215111;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportField REPAIRNOTES { get {return Header().REPAIRNOTES;} }
            public TTReportField REPORTDATE { get {return Footer().REPORTDATE;} }
            public TTReportField NewField11512 { get {return Footer().NewField11512;} }
            public TTReportField NewField1115112 { get {return Footer().NewField1115112;} }
            public TTReportField NewField5 { get {return Footer().NewField5;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportField NewField1161 { get {return Footer().NewField1161;} }
            public TTReportField NewField121511 { get {return Footer().NewField121511;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField NewField1115121 { get {return Footer().NewField1115121;} }
            public TTReportField NewField152 { get {return Footer().NewField152;} }
            public TTReportField NewField121512 { get {return Footer().NewField121512;} }
            public TTReportField NewField121513 { get {return Footer().NewField121513;} }
            public TTReportField NewField1251 { get {return Footer().NewField1251;} }
            public TTReportField NewField1315121 { get {return Footer().NewField1315121;} }
            public TTReportField NewField11521 { get {return Footer().NewField11521;} }
            public TTReportField NewField12115111 { get {return Footer().NewField12115111;} }
            public TTReportField NewField121 { get {return Footer().NewField121;} }
            public TTReportField REQUESTDATE1 { get {return Footer().REQUESTDATE1;} }
            public TTReportField LABORTOTALCOST { get {return Footer().LABORTOTALCOST;} }
            public TTReportField REPAIRTOTALCOST { get {return Footer().REPAIRTOTALCOST;} }
            public TTReportField SECTION { get {return Footer().SECTION;} }
            public TTReportField HEKREPORTNO { get {return Footer().HEKREPORTNO;} }
            public TTReportField REQUESTNO { get {return Footer().REQUESTNO;} }
            public TTReportRTF DESCRIPTIONRTF { get {return Footer().DESCRIPTIONRTF;} }
            public TTReportField HEKREPORTREPAIRDETAIL { get {return Footer().HEKREPORTREPAIRDETAIL;} }
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
                list[0] = new TTReportNqlData<Repair.RepairHEKReportQuery_Class>("RepairHEKReportQuery", Repair.RepairHEKReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public KayitSilmeyeEsasTeknikRapor MyParentReport
                {
                    get { return (KayitSilmeyeEsasTeknikRapor)ParentReport; }
                }
                
                public TTReportField NewField1111151111;
                public TTReportField NewField11511;
                public TTReportField NewField3;
                public TTReportField NewField111511;
                public TTReportField FAULTDESCRIPTION;
                public TTReportField PRECONTROLNOTES;
                public TTReportField REQUESTDATE;
                public TTReportField NewField1115111;
                public TTReportField NewField131;
                public TTReportField NewField4;
                public TTReportField NewField111512;
                public TTReportField NewField14;
                public TTReportField MATERIALPRICE;
                public TTReportField NewField1215111;
                public TTReportField NewField141;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportField NewField1111111;
                public TTReportField REPAIRNOTES; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 112;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111151111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 1, 105, 7, false);
                    NewField1111151111.Name = "NewField1111151111";
                    NewField1111151111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1111151111.TextFont.Size = 10;
                    NewField1111151111.TextFont.Bold = true;
                    NewField1111151111.Value = @"C. HASAR / ARIZA BİLGİLERİ :";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 8, 105, 14, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField11511.TextFont.Size = 10;
                    NewField11511.TextFont.Bold = true;
                    NewField11511.Value = @"1. HASARIN / ARIZANIN TANIMI";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 8, 109, 14, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.TextFont.Size = 10;
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @":";

                    NewField111511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 40, 105, 46, false);
                    NewField111511.Name = "NewField111511";
                    NewField111511.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111511.TextFont.Size = 10;
                    NewField111511.TextFont.Bold = true;
                    NewField111511.Value = @"2. HASARIN / ARIZANIN NEDENLERİ";

                    FAULTDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 15, 206, 39, false);
                    FAULTDESCRIPTION.Name = "FAULTDESCRIPTION";
                    FAULTDESCRIPTION.DrawStyle = DrawStyleConstants.vbInvisible;
                    FAULTDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    FAULTDESCRIPTION.VertAlign = VerticalAlignmentEnum.vaTop;
                    FAULTDESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    FAULTDESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    FAULTDESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    FAULTDESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    FAULTDESCRIPTION.TextFont.Name = "Arial Narrow";
                    FAULTDESCRIPTION.TextFont.Size = 8;
                    FAULTDESCRIPTION.Value = @"{#FAULTDESCRIPTION#}";

                    PRECONTROLNOTES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 4, 311, 16, false);
                    PRECONTROLNOTES.Name = "PRECONTROLNOTES";
                    PRECONTROLNOTES.Visible = EvetHayirEnum.ehHayir;
                    PRECONTROLNOTES.DrawStyle = DrawStyleConstants.vbInvisible;
                    PRECONTROLNOTES.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRECONTROLNOTES.VertAlign = VerticalAlignmentEnum.vaTop;
                    PRECONTROLNOTES.TextFont.Name = "Arial Narrow";
                    PRECONTROLNOTES.TextFont.Size = 10;
                    PRECONTROLNOTES.TextFont.CharSet = 1;
                    PRECONTROLNOTES.Value = @"{#PRECONTROLNOTES#}";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 78, 135, 84, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.DrawStyle = DrawStyleConstants.vbInvisible;
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"dd/MM/yyyy";
                    REQUESTDATE.TextFont.Name = "Arial Narrow";
                    REQUESTDATE.TextFont.Size = 10;
                    REQUESTDATE.TextFont.CharSet = 1;
                    REQUESTDATE.Value = @"{#REQUESTDATE#}";

                    NewField1115111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 78, 105, 84, false);
                    NewField1115111.Name = "NewField1115111";
                    NewField1115111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1115111.TextFont.Size = 10;
                    NewField1115111.TextFont.Bold = true;
                    NewField1115111.Value = @"3. HASARIN / ARIZANIN TARİHİ";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 40, 109, 46, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.TextFont.Size = 10;
                    NewField131.TextFont.Bold = true;
                    NewField131.Value = @":";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 85, 105, 91, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField4.TextFont.Size = 10;
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @"Ç. ONARIMA ESAS BİLGİLER :";

                    NewField111512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 92, 105, 98, false);
                    NewField111512.Name = "NewField111512";
                    NewField111512.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111512.TextFont.Size = 10;
                    NewField111512.TextFont.Bold = true;
                    NewField111512.Value = @"1. MALZEMENİN RAPOR TARİHİNDEKİ DEĞERİ";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 78, 109, 84, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.TextFont.Size = 10;
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @":";

                    MATERIALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 92, 135, 98, false);
                    MATERIALPRICE.Name = "MATERIALPRICE";
                    MATERIALPRICE.DrawStyle = DrawStyleConstants.vbInvisible;
                    MATERIALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALPRICE.TextFont.Name = "Arial Narrow";
                    MATERIALPRICE.TextFont.Size = 10;
                    MATERIALPRICE.TextFont.CharSet = 1;
                    MATERIALPRICE.Value = @"{#MATERIALPRICE#} TL";

                    NewField1215111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 99, 127, 105, false);
                    NewField1215111.Name = "NewField1215111";
                    NewField1215111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1215111.TextFont.Size = 10;
                    NewField1215111.TextFont.Bold = true;
                    NewField1215111.Value = @"2. ONARIM İÇİN İHTİYAÇ DUYULAN MALZEMELER VE DEĞERİ";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 92, 109, 98, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.TextFont.Size = 10;
                    NewField141.TextFont.Bold = true;
                    NewField141.Value = @":";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 107, 31, 112, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.TextFont.Name = "Arial Narrow";
                    NewField11.TextFont.Size = 10;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"S.Nu.";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 107, 129, 112, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.TextFont.Name = "Arial Narrow";
                    NewField111.TextFont.Size = 10;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @"Malzemenin Cinsi";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 107, 154, 112, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.TextFont.Name = "Arial Narrow";
                    NewField1111.TextFont.Size = 10;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @"Parça Nu.";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 107, 172, 112, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.TextFont.Name = "Arial Narrow";
                    NewField11111.TextFont.Size = 10;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.Value = @"Miktarı";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 107, 190, 112, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.TextFont.Name = "Arial Narrow";
                    NewField111111.TextFont.Size = 10;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.Value = @"B. Fiyatı";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 107, 208, 112, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111111.TextFont.Name = "Arial Narrow";
                    NewField1111111.TextFont.Size = 10;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.Value = @"Tutarı";

                    REPAIRNOTES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 47, 206, 77, false);
                    REPAIRNOTES.Name = "REPAIRNOTES";
                    REPAIRNOTES.DrawStyle = DrawStyleConstants.vbInvisible;
                    REPAIRNOTES.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPAIRNOTES.VertAlign = VerticalAlignmentEnum.vaTop;
                    REPAIRNOTES.MultiLine = EvetHayirEnum.ehEvet;
                    REPAIRNOTES.NoClip = EvetHayirEnum.ehEvet;
                    REPAIRNOTES.WordBreak = EvetHayirEnum.ehEvet;
                    REPAIRNOTES.ExpandTabs = EvetHayirEnum.ehEvet;
                    REPAIRNOTES.TextFont.Name = "Arial Narrow";
                    REPAIRNOTES.TextFont.Size = 8;
                    REPAIRNOTES.Value = @"{#REPAIRNOTES#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Repair.RepairHEKReportQuery_Class dataset_RepairHEKReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Repair.RepairHEKReportQuery_Class>(0);
                    NewField1111151111.CalcValue = NewField1111151111.Value;
                    NewField11511.CalcValue = NewField11511.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField111511.CalcValue = NewField111511.Value;
                    FAULTDESCRIPTION.CalcValue = (dataset_RepairHEKReportQuery != null ? Globals.ToStringCore(dataset_RepairHEKReportQuery.FaultDescription) : "");
                    PRECONTROLNOTES.CalcValue = (dataset_RepairHEKReportQuery != null ? Globals.ToStringCore(dataset_RepairHEKReportQuery.PreControlNotes) : "");
                    REQUESTDATE.CalcValue = (dataset_RepairHEKReportQuery != null ? Globals.ToStringCore(dataset_RepairHEKReportQuery.RequestDate) : "");
                    NewField1115111.CalcValue = NewField1115111.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField111512.CalcValue = NewField111512.Value;
                    NewField14.CalcValue = NewField14.Value;
                    MATERIALPRICE.CalcValue = (dataset_RepairHEKReportQuery != null ? Globals.ToStringCore(dataset_RepairHEKReportQuery.MaterialPrice) : "") + @" TL";
                    NewField1215111.CalcValue = NewField1215111.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    REPAIRNOTES.CalcValue = (dataset_RepairHEKReportQuery != null ? Globals.ToStringCore(dataset_RepairHEKReportQuery.RepairNotes) : "");
                    return new TTReportObject[] { NewField1111151111,NewField11511,NewField3,NewField111511,FAULTDESCRIPTION,PRECONTROLNOTES,REQUESTDATE,NewField1115111,NewField131,NewField4,NewField111512,NewField14,MATERIALPRICE,NewField1215111,NewField141,NewField11,NewField111,NewField1111,NewField11111,NewField111111,NewField1111111,REPAIRNOTES};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    //   string faultDesc = "Cihazın yapılan incelemesinde; "+ HEKDESCRIPTION.CalcValue +" tespit edilmiştir. Cihazın mevcut durumu nedeniyle onarılmasının mümkün olmayacağı değerlendirilmiştir.";
          //  REPAIRNOTESRTF.CalcValue = TTObjectClasses.Common.GetRTFOfTextString (faultDesc);
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public KayitSilmeyeEsasTeknikRapor MyParentReport
                {
                    get { return (KayitSilmeyeEsasTeknikRapor)ParentReport; }
                }
                
                public TTReportField REPORTDATE;
                public TTReportField NewField11512;
                public TTReportField NewField1115112;
                public TTReportField NewField5;
                public TTReportField NewField12;
                public TTReportField NewField1161;
                public TTReportField NewField121511;
                public TTReportField NewField15;
                public TTReportField NewField1115121;
                public TTReportField NewField152;
                public TTReportField NewField121512;
                public TTReportField NewField121513;
                public TTReportField NewField1251;
                public TTReportField NewField1315121;
                public TTReportField NewField11521;
                public TTReportField NewField12115111;
                public TTReportField NewField121;
                public TTReportField REQUESTDATE1;
                public TTReportField LABORTOTALCOST;
                public TTReportField REPAIRTOTALCOST;
                public TTReportField SECTION;
                public TTReportField HEKREPORTNO;
                public TTReportField REQUESTNO;
                public TTReportRTF DESCRIPTIONRTF;
                public TTReportField HEKREPORTREPAIRDETAIL; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 105;
                    RepeatCount = 0;
                    
                    REPORTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 91, 134, 97, false);
                    REPORTDATE.Name = "REPORTDATE";
                    REPORTDATE.DrawStyle = DrawStyleConstants.vbInvisible;
                    REPORTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTDATE.TextFormat = @"dd/MM/yyyy";
                    REPORTDATE.TextFont.Size = 10;
                    REPORTDATE.Value = @"{@printdate@}";

                    NewField11512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 105, 7, false);
                    NewField11512.Name = "NewField11512";
                    NewField11512.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField11512.TextFont.Size = 10;
                    NewField11512.TextFont.Bold = true;
                    NewField11512.Value = @"3. İŞCİLİK MALİYETİ";

                    NewField1115112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 91, 105, 97, false);
                    NewField1115112.Name = "NewField1115112";
                    NewField1115112.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1115112.TextFont.Size = 10;
                    NewField1115112.TextFont.Bold = true;
                    NewField1115112.Value = @"3. RAPORUN VERİLDİĞİ TARİH";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 1, 109, 7, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField5.TextFont.Size = 10;
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @":";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 91, 109, 97, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.TextFont.Size = 10;
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @":";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 98, 138, 104, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1161.TextFont.Size = 10;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.Value = @"/";

                    NewField121511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 8, 105, 14, false);
                    NewField121511.Name = "NewField121511";
                    NewField121511.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField121511.TextFont.Size = 10;
                    NewField121511.TextFont.Bold = true;
                    NewField121511.Value = @"4. ONARIM TOPLAM MALİYETİ";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 8, 109, 14, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.TextFont.Size = 10;
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @":";

                    NewField1115121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 15, 105, 21, false);
                    NewField1115121.Name = "NewField1115121";
                    NewField1115121.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1115121.TextFont.Size = 10;
                    NewField1115121.TextFont.Bold = true;
                    NewField1115121.Value = @"5. ONARIMIN YAPILIP YAPILAMAYACAĞI";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 15, 109, 21, false);
                    NewField152.Name = "NewField152";
                    NewField152.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField152.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField152.TextFont.Size = 10;
                    NewField152.TextFont.Bold = true;
                    NewField152.Value = @":";

                    NewField121512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 70, 100, 76, false);
                    NewField121512.Name = "NewField121512";
                    NewField121512.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField121512.TextFont.Size = 10;
                    NewField121512.TextFont.Bold = true;
                    NewField121512.Value = @"D. RAPORA AİT BİLGİLER :";

                    NewField121513 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 77, 105, 83, false);
                    NewField121513.Name = "NewField121513";
                    NewField121513.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField121513.TextFont.Size = 10;
                    NewField121513.TextFont.Bold = true;
                    NewField121513.Value = @"1. RAPORUN TANZİM EDİLDİĞİ BİRLİK";

                    NewField1251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 77, 109, 83, false);
                    NewField1251.Name = "NewField1251";
                    NewField1251.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1251.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1251.TextFont.Size = 10;
                    NewField1251.TextFont.Bold = true;
                    NewField1251.Value = @":";

                    NewField1315121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 84, 105, 90, false);
                    NewField1315121.Name = "NewField1315121";
                    NewField1315121.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1315121.TextFont.Size = 10;
                    NewField1315121.TextFont.Bold = true;
                    NewField1315121.Value = @"2. RAPOR NUMARASI";

                    NewField11521 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 84, 109, 90, false);
                    NewField11521.Name = "NewField11521";
                    NewField11521.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField11521.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11521.TextFont.Size = 10;
                    NewField11521.TextFont.Bold = true;
                    NewField11521.Value = @":";

                    NewField12115111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 98, 105, 104, false);
                    NewField12115111.Name = "NewField12115111";
                    NewField12115111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField12115111.TextFont.Size = 10;
                    NewField12115111.TextFont.Bold = true;
                    NewField12115111.Value = @"4. BAKIM KADEMESİ KAYIT VE TARİHİ";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 98, 109, 104, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.TextFont.Size = 10;
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @":";

                    REQUESTDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 98, 163, 104, false);
                    REQUESTDATE1.Name = "REQUESTDATE1";
                    REQUESTDATE1.DrawStyle = DrawStyleConstants.vbInvisible;
                    REQUESTDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE1.TextFormat = @"dd/MM/yyyy";
                    REQUESTDATE1.TextFont.Name = "Arial Narrow";
                    REQUESTDATE1.TextFont.Size = 10;
                    REQUESTDATE1.TextFont.CharSet = 1;
                    REQUESTDATE1.Value = @"{#REQUESTDATE#}";

                    LABORTOTALCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 1, 134, 7, false);
                    LABORTOTALCOST.Name = "LABORTOTALCOST";
                    LABORTOTALCOST.DrawStyle = DrawStyleConstants.vbInvisible;
                    LABORTOTALCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    LABORTOTALCOST.TextFont.Name = "Arial Narrow";
                    LABORTOTALCOST.TextFont.Size = 10;
                    LABORTOTALCOST.TextFont.CharSet = 1;
                    LABORTOTALCOST.Value = @"{#LABORTOTALCOST#} TL";

                    REPAIRTOTALCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 8, 134, 14, false);
                    REPAIRTOTALCOST.Name = "REPAIRTOTALCOST";
                    REPAIRTOTALCOST.DrawStyle = DrawStyleConstants.vbInvisible;
                    REPAIRTOTALCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPAIRTOTALCOST.VertAlign = VerticalAlignmentEnum.vaTop;
                    REPAIRTOTALCOST.TextFont.Name = "Arial Narrow";
                    REPAIRTOTALCOST.TextFont.Size = 10;
                    REPAIRTOTALCOST.TextFont.CharSet = 1;
                    REPAIRTOTALCOST.Value = @"{#REPAIRTOTALCOST#} TL";

                    SECTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 77, 203, 83, false);
                    SECTION.Name = "SECTION";
                    SECTION.DrawStyle = DrawStyleConstants.vbInvisible;
                    SECTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    SECTION.TextFont.Name = "Arial Narrow";
                    SECTION.TextFont.Size = 10;
                    SECTION.TextFont.CharSet = 1;
                    SECTION.Value = @"{#SECTION#}";

                    HEKREPORTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 84, 134, 90, false);
                    HEKREPORTNO.Name = "HEKREPORTNO";
                    HEKREPORTNO.DrawStyle = DrawStyleConstants.vbInvisible;
                    HEKREPORTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEKREPORTNO.TextFont.Name = "Arial Narrow";
                    HEKREPORTNO.TextFont.Size = 10;
                    HEKREPORTNO.TextFont.CharSet = 1;
                    HEKREPORTNO.Value = @"{#HEKREPORTNO#}";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 98, 134, 104, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.DrawStyle = DrawStyleConstants.vbInvisible;
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.TextFont.Name = "Arial Narrow";
                    REQUESTNO.TextFont.Size = 10;
                    REQUESTNO.TextFont.CharSet = 1;
                    REQUESTNO.Value = @"{#REQUESTNO#}";

                    DESCRIPTIONRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 213, 22, 399, 67, false);
                    DESCRIPTIONRTF.Name = "DESCRIPTIONRTF";
                    DESCRIPTIONRTF.Visible = EvetHayirEnum.ehHayir;
                    DESCRIPTIONRTF.DrawStyle = DrawStyleConstants.vbInvisible;
                    DESCRIPTIONRTF.Value = @"";

                    HEKREPORTREPAIRDETAIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 22, 203, 69, false);
                    HEKREPORTREPAIRDETAIL.Name = "HEKREPORTREPAIRDETAIL";
                    HEKREPORTREPAIRDETAIL.DrawStyle = DrawStyleConstants.vbInvisible;
                    HEKREPORTREPAIRDETAIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEKREPORTREPAIRDETAIL.VertAlign = VerticalAlignmentEnum.vaTop;
                    HEKREPORTREPAIRDETAIL.MultiLine = EvetHayirEnum.ehEvet;
                    HEKREPORTREPAIRDETAIL.NoClip = EvetHayirEnum.ehEvet;
                    HEKREPORTREPAIRDETAIL.WordBreak = EvetHayirEnum.ehEvet;
                    HEKREPORTREPAIRDETAIL.ExpandTabs = EvetHayirEnum.ehEvet;
                    HEKREPORTREPAIRDETAIL.TextFont.Name = "Arial Narrow";
                    HEKREPORTREPAIRDETAIL.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Repair.RepairHEKReportQuery_Class dataset_RepairHEKReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Repair.RepairHEKReportQuery_Class>(0);
                    REPORTDATE.CalcValue = DateTime.Now.ToShortDateString();
                    NewField11512.CalcValue = NewField11512.Value;
                    NewField1115112.CalcValue = NewField1115112.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField121511.CalcValue = NewField121511.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField1115121.CalcValue = NewField1115121.Value;
                    NewField152.CalcValue = NewField152.Value;
                    NewField121512.CalcValue = NewField121512.Value;
                    NewField121513.CalcValue = NewField121513.Value;
                    NewField1251.CalcValue = NewField1251.Value;
                    NewField1315121.CalcValue = NewField1315121.Value;
                    NewField11521.CalcValue = NewField11521.Value;
                    NewField12115111.CalcValue = NewField12115111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    REQUESTDATE1.CalcValue = (dataset_RepairHEKReportQuery != null ? Globals.ToStringCore(dataset_RepairHEKReportQuery.RequestDate) : "");
                    LABORTOTALCOST.CalcValue = (dataset_RepairHEKReportQuery != null ? Globals.ToStringCore(dataset_RepairHEKReportQuery.LaborTotalCost) : "") + @" TL";
                    REPAIRTOTALCOST.CalcValue = (dataset_RepairHEKReportQuery != null ? Globals.ToStringCore(dataset_RepairHEKReportQuery.RepairTotalCost) : "") + @" TL";
                    SECTION.CalcValue = (dataset_RepairHEKReportQuery != null ? Globals.ToStringCore(dataset_RepairHEKReportQuery.Section) : "");
                    HEKREPORTNO.CalcValue = (dataset_RepairHEKReportQuery != null ? Globals.ToStringCore(dataset_RepairHEKReportQuery.HEKReportNo) : "");
                    REQUESTNO.CalcValue = (dataset_RepairHEKReportQuery != null ? Globals.ToStringCore(dataset_RepairHEKReportQuery.RequestNo) : "");
                    DESCRIPTIONRTF.CalcValue = DESCRIPTIONRTF.Value;
                    HEKREPORTREPAIRDETAIL.CalcValue = @"";
                    return new TTReportObject[] { REPORTDATE,NewField11512,NewField1115112,NewField5,NewField12,NewField1161,NewField121511,NewField15,NewField1115121,NewField152,NewField121512,NewField121513,NewField1251,NewField1315121,NewField11521,NewField12115111,NewField121,REQUESTDATE1,LABORTOTALCOST,REPAIRTOTALCOST,SECTION,HEKREPORTNO,REQUESTNO,DESCRIPTIONRTF,HEKREPORTREPAIRDETAIL};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    CMRAction cmrAction = (CMRAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(CMRAction));
            if (cmrAction is MaterialRepair)
            {
                MaterialRepair materialRepair = (MaterialRepair)cmrAction;
                if(materialRepair.HEKReportRepairDetail != null)
                    HEKREPORTREPAIRDETAIL.CalcValue = TTObjectClasses.Common.GetTextOfRTFString(materialRepair.HEKReportRepairDetail);
            }
            else
            {
                Repair repair = (Repair)cmrAction;
                if(repair.HEKReportRepairDetail != null)
                   HEKREPORTREPAIRDETAIL.CalcValue = TTObjectClasses.Common.GetTextOfRTFString(repair.HEKReportRepairDetail);
            }
           
        /*   CMRAction cmrAction = (CMRAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(CMRAction));
            if (cmrAction is MaterialRepair)
            {
                MaterialRepair materialRepair = (MaterialRepair)cmrAction;
                string description;
                string hekNedeni="";
                string aciklama= "    Yukarıda marka modeli belirtilen cihaz, uzun süreli kullanımdan dolayı kullanıcı hatası olmaksızın normal aşınma ve yıpranma sonucu nitelik ve özelliklerini kaybetmiştir.\n Cihazın yapılan incelemesinde; ";
                string aciklama2= " tespit edilmiştir. Cihazın mevcut durumu nedeniyle onarılmasının mümkün olmayacağı değerlendirilmiştir.\n   Cihazın eski model ve eski teknoloji ürünü olması nedeniyle yenileştirilmesi mümkün değildir.";
                string aciklama3="\n    Yukarıda belirtilen nedenlerden dolayı; MSY 59-2(A) XXXXXX Taşınır Mal Yönergesinin 5.ncü bölüm 1.inci maddesi I-";
                foreach (RULHEKReason mrepHEKReason in materialRepair.RULHEKReasons)
                {
                    if (mrepHEKReason.Check == true)
                    {
                        hekNedeni = mrepHEKReason.CousesOfTheHekDefinition.Counter + " fıkrasında belirtildiği üzere " + mrepHEKReason.CousesOfTheHekDefinition.Description;
                        break;
                    }
                }
                string aciklama4= " -dan dolayı kayıt silme işlemine tabi tutulmasının uygun olacağı değerlendirilmiştir.";
                description= aciklama + TTObjectClasses.Common.GetTextOfRTFString(materialRepair.HEKReportDescription) + aciklama2 + aciklama3  + hekNedeni + aciklama4;
                DESCRIPTIONRTF.CalcValue = TTObjectClasses.Common.GetRTFOfTextString(description);
            }
            else
            {
                Repair repair = (Repair)cmrAction;
                string description;
                string hekNedeni="";
                string aciklama= "    Yukarıda marka modeli belirtilen cihaz, uzun süreli kullanımdan dolayı kullanıcı hatası olmaksızın normal aşınma ve yıpranma sonucu nitelik ve özelliklerini kaybetmiştir.\n Cihazın yapılan incelemesinde; ";
                string aciklama2= " tespit edilmiştir. Cihazın mevcut durumu nedeniyle onarılmasının mümkün olmayacağı değerlendirilmiştir.\n   Cihazın eski model ve eski teknoloji ürünü olması nedeniyle yenileştirilmesi mümkün değildir.";
                string aciklama3="\n    Yukarıda belirtilen nedenlerden dolayı; MSY 59-2(A) XXXXXX Taşınır Mal Yönergesinin 5.ncü bölüm 1.inci maddesi I-";
                foreach (RULHEKReason repHEKReason in repair.RULHEKReasons)
                {
                    if (repHEKReason.Check == true)
                    {
                        hekNedeni = repHEKReason.CousesOfTheHekDefinition.Counter + " fıkrasında belirtildiği üzere " + repHEKReason.CousesOfTheHekDefinition.Description;
                        break;
                    }
                }
                string aciklama4= " -dan dolayı kayıt silme işlemine tabi tutulmasının uygun olacağı değerlendirilmiştir.";
                description= aciklama + TTObjectClasses.Common.GetTextOfRTFString(repair.HEKReportDescription) + aciklama2 + aciklama3  + hekNedeni + aciklama4;
                DESCRIPTIONRTF.CalcValue = TTObjectClasses.Common.GetRTFOfTextString(description);
            } */
            //            CMRAction cmrAction = (CMRAction)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(CMRAction));
            //            DESCRIPTIONRTF.CalcValue = ((Repair)cmrAction).HEKReportDescription ;
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public KayitSilmeyeEsasTeknikRapor MyParentReport
            {
                get { return (KayitSilmeyeEsasTeknikRapor)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField PARTNUMBER { get {return Body().PARTNUMBER;} }
            public TTReportField MATERIALAMOUNT { get {return Body().MATERIALAMOUNT;} }
            public TTReportField MATERIALUNITPRICE { get {return Body().MATERIALUNITPRICE;} }
            public TTReportField MATERIALTOTALPRICE { get {return Body().MATERIALTOTALPRICE;} }
            public TTReportField SNU { get {return Body().SNU;} }
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
                list[0] = new TTReportNqlData<NeededMaterials.RepairNeededMaterialQuery_Class>("RepairNeededMaterialQuery", NeededMaterials.RepairNeededMaterialQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public KayitSilmeyeEsasTeknikRapor MyParentReport
                {
                    get { return (KayitSilmeyeEsasTeknikRapor)ParentReport; }
                }
                
                public TTReportField MATERIALNAME;
                public TTReportField PARTNUMBER;
                public TTReportField MATERIALAMOUNT;
                public TTReportField MATERIALUNITPRICE;
                public TTReportField MATERIALTOTALPRICE;
                public TTReportField SNU; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    RepeatCount = 0;
                    
                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 0, 129, 5, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaTop;
                    MATERIALNAME.TextFont.Name = "Arial Narrow";
                    MATERIALNAME.TextFont.Size = 10;
                    MATERIALNAME.TextFont.CharSet = 1;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    PARTNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 0, 154, 5, false);
                    PARTNUMBER.Name = "PARTNUMBER";
                    PARTNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARTNUMBER.VertAlign = VerticalAlignmentEnum.vaTop;
                    PARTNUMBER.TextFont.Name = "Arial Narrow";
                    PARTNUMBER.TextFont.Size = 10;
                    PARTNUMBER.TextFont.CharSet = 1;
                    PARTNUMBER.Value = @"{#PARTNUMBER#}";

                    MATERIALAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 0, 172, 5, false);
                    MATERIALAMOUNT.Name = "MATERIALAMOUNT";
                    MATERIALAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALAMOUNT.VertAlign = VerticalAlignmentEnum.vaTop;
                    MATERIALAMOUNT.TextFont.Name = "Arial Narrow";
                    MATERIALAMOUNT.TextFont.Size = 10;
                    MATERIALAMOUNT.TextFont.CharSet = 1;
                    MATERIALAMOUNT.Value = @"{#MATERIALAMOUNT#}";

                    MATERIALUNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 0, 190, 5, false);
                    MATERIALUNITPRICE.Name = "MATERIALUNITPRICE";
                    MATERIALUNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALUNITPRICE.VertAlign = VerticalAlignmentEnum.vaTop;
                    MATERIALUNITPRICE.TextFont.Name = "Arial Narrow";
                    MATERIALUNITPRICE.TextFont.Size = 10;
                    MATERIALUNITPRICE.TextFont.CharSet = 1;
                    MATERIALUNITPRICE.Value = @"{#MATERIALUNITPRICE#}";

                    MATERIALTOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 0, 208, 5, false);
                    MATERIALTOTALPRICE.Name = "MATERIALTOTALPRICE";
                    MATERIALTOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALTOTALPRICE.VertAlign = VerticalAlignmentEnum.vaTop;
                    MATERIALTOTALPRICE.TextFont.Name = "Arial Narrow";
                    MATERIALTOTALPRICE.TextFont.Size = 10;
                    MATERIALTOTALPRICE.TextFont.CharSet = 1;
                    MATERIALTOTALPRICE.Value = @"{#MATERIALTOTALPRICE#}";

                    SNU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 31, 5, false);
                    SNU.Name = "SNU";
                    SNU.FieldType = ReportFieldTypeEnum.ftVariable;
                    SNU.VertAlign = VerticalAlignmentEnum.vaTop;
                    SNU.TextFont.Name = "Arial Narrow";
                    SNU.TextFont.Size = 10;
                    SNU.TextFont.CharSet = 1;
                    SNU.Value = @"{@counter@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NeededMaterials.RepairNeededMaterialQuery_Class dataset_RepairNeededMaterialQuery = ParentGroup.rsGroup.GetCurrentRecord<NeededMaterials.RepairNeededMaterialQuery_Class>(0);
                    MATERIALNAME.CalcValue = (dataset_RepairNeededMaterialQuery != null ? Globals.ToStringCore(dataset_RepairNeededMaterialQuery.MaterialName) : "");
                    PARTNUMBER.CalcValue = (dataset_RepairNeededMaterialQuery != null ? Globals.ToStringCore(dataset_RepairNeededMaterialQuery.PartNumber) : "");
                    MATERIALAMOUNT.CalcValue = (dataset_RepairNeededMaterialQuery != null ? Globals.ToStringCore(dataset_RepairNeededMaterialQuery.MaterialAmount) : "");
                    MATERIALUNITPRICE.CalcValue = (dataset_RepairNeededMaterialQuery != null ? Globals.ToStringCore(dataset_RepairNeededMaterialQuery.MaterialUnitPrice) : "");
                    MATERIALTOTALPRICE.CalcValue = (dataset_RepairNeededMaterialQuery != null ? Globals.ToStringCore(dataset_RepairNeededMaterialQuery.MaterialTotalPrice) : "");
                    SNU.CalcValue = ParentGroup.Counter.ToString();
                    return new TTReportObject[] { MATERIALNAME,PARTNUMBER,MATERIALAMOUNT,MATERIALUNITPRICE,MATERIALTOTALPRICE,SNU};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public KayitSilmeyeEsasTeknikRapor()
        {
            pagenumber = new pagenumberGroup(this,"pagenumber");
            Footer = new FooterGroup(pagenumber,"Footer");
            PARTA = new PARTAGroup(Footer,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "Onarım", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "KAYITSILMEYEESASTEKNIKRAPOR";
            Caption = "Kayıt Silmeye Esas Teknik Rapor ( HEK Raporu )";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaMiddle;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Arial";
            fd.TextFont.Size = 9;
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