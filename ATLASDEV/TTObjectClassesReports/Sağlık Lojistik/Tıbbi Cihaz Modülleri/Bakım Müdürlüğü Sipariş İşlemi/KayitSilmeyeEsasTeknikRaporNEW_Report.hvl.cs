
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
    public partial class KayitSilmeyeEsasTeknikRaporNEW : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class FooterGroup : TTReportGroup
        {
            public KayitSilmeyeEsasTeknikRaporNEW MyParentReport
            {
                get { return (KayitSilmeyeEsasTeknikRaporNEW)ParentReport; }
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
            public TTReportField BOLUMAMIRI { get {return Footer().BOLUMAMIRI;} }
            public TTReportField KISIMAMIRI { get {return Footer().KISIMAMIRI;} }
            public TTReportField TEKNIKMUDUR { get {return Footer().TEKNIKMUDUR;} }
            public TTReportField KLTKONT { get {return Footer().KLTKONT;} }
            public TTReportField ONAY { get {return Footer().ONAY;} }
            public TTReportShape NewLine111221 { get {return Footer().NewLine111221;} }
            public TTReportField NewField1172 { get {return Footer().NewField1172;} }
            public TTReportField NewField12711 { get {return Footer().NewField12711;} }
            public TTReportShape NewLine111222 { get {return Footer().NewLine111222;} }
            public TTReportShape NewLine111223 { get {return Footer().NewLine111223;} }
            public TTReportField NewField111721 { get {return Footer().NewField111721;} }
            public TTReportShape NewLine1222111 { get {return Footer().NewLine1222111;} }
            public TTReportField NewField1127111 { get {return Footer().NewField1127111;} }
            public TTReportShape NewLine11112221 { get {return Footer().NewLine11112221;} }
            public TTReportField TEKNISYEN { get {return Footer().TEKNISYEN;} }
            public TTReportShape NewLine1222112 { get {return Footer().NewLine1222112;} }
            public TTReportField TEKNISYEN12 { get {return Footer().TEKNISYEN12;} }
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
                public KayitSilmeyeEsasTeknikRaporNEW MyParentReport
                {
                    get { return (KayitSilmeyeEsasTeknikRaporNEW)ParentReport; }
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
                    
                    Height = 65;
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

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 6, 202, 17, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Size = 12;
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @"HASAR VE DURUM TESPİT RAPORU / TEKNİK RAPOR / HEK RAPORU";

                    NewField11115111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 21, 105, 27, false);
                    NewField11115111.Name = "NewField11115111";
                    NewField11115111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField11115111.TextFont.Size = 10;
                    NewField11115111.TextFont.Bold = true;
                    NewField11115111.Value = @"A. MALZEMENİN AİT OLDUĞU BİRLİK / BAŞKANLIK";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 21, 109, 27, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.TextFont.Size = 10;
                    NewField141.TextFont.Bold = true;
                    NewField141.Value = @":";

                    SENDERSECTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 21, 202, 27, false);
                    SENDERSECTION.Name = "SENDERSECTION";
                    SENDERSECTION.DrawStyle = DrawStyleConstants.vbInvisible;
                    SENDERSECTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENDERSECTION.MultiLine = EvetHayirEnum.ehEvet;
                    SENDERSECTION.WordBreak = EvetHayirEnum.ehEvet;
                    SENDERSECTION.TextFont.Size = 10;
                    SENDERSECTION.Value = @"";

                    NewField111151111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 29, 105, 35, false);
                    NewField111151111.Name = "NewField111151111";
                    NewField111151111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111151111.TextFont.Size = 10;
                    NewField111151111.TextFont.Bold = true;
                    NewField111151111.Value = @"B. MALZEMENIN TANIMI :";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 53, 148, 64, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.TextFont.Size = 10;
                    MATERIALNAME.Value = @"";

                    SERIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 53, 179, 64, false);
                    SERIALNO.Name = "SERIALNO";
                    SERIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNO.MultiLine = EvetHayirEnum.ehEvet;
                    SERIALNO.WordBreak = EvetHayirEnum.ehEvet;
                    SERIALNO.TextFont.Size = 10;
                    SERIALNO.Value = @"";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 53, 73, 64, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.TextFont.Size = 10;
                    NATOSTOCKNO.Value = @"";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 53, 188, 64, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbInvisible;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFont.Size = 10;
                    AMOUNT.Value = @"";

                    AMOUNT11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 53, 26, 64, false);
                    AMOUNT11.Name = "AMOUNT11";
                    AMOUNT11.TextFont.Size = 10;
                    AMOUNT11.Value = @"1";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 53, 47, 64, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.TextFont.Size = 10;
                    REQUESTNO.Value = @"";

                    DISTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 53, 203, 64, false);
                    DISTYPE.Name = "DISTYPE";
                    DISTYPE.DrawStyle = DrawStyleConstants.vbInvisible;
                    DISTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTYPE.TextFont.Size = 8;
                    DISTYPE.Value = @"";

                    AMOUNT111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 39, 26, 53, false);
                    AMOUNT111.Name = "AMOUNT111";
                    AMOUNT111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT111.TextFont.Size = 10;
                    AMOUNT111.TextFont.Bold = true;
                    AMOUNT111.Value = @"S.Nu.";

                    AMOUNT1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 39, 47, 53, false);
                    AMOUNT1111.Name = "AMOUNT1111";
                    AMOUNT1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT1111.TextFont.Size = 10;
                    AMOUNT1111.TextFont.Bold = true;
                    AMOUNT1111.Value = @"Sipariş Nu.";

                    AMOUNT11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 39, 73, 53, false);
                    AMOUNT11111.Name = "AMOUNT11111";
                    AMOUNT11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT11111.TextFont.Size = 10;
                    AMOUNT11111.TextFont.Bold = true;
                    AMOUNT11111.Value = @"Stok Nu.";

                    AMOUNT111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 39, 148, 53, false);
                    AMOUNT111111.Name = "AMOUNT111111";
                    AMOUNT111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT111111.TextFont.Size = 10;
                    AMOUNT111111.TextFont.Bold = true;
                    AMOUNT111111.Value = @"Malzemenin Cinsi";

                    AMOUNT1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 39, 179, 53, false);
                    AMOUNT1111111.Name = "AMOUNT1111111";
                    AMOUNT1111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT1111111.MultiLine = EvetHayirEnum.ehEvet;
                    AMOUNT1111111.TextFont.Size = 10;
                    AMOUNT1111111.TextFont.Bold = true;
                    AMOUNT1111111.Value = @"Marka
Model
Seri Nu.";

                    AMOUNT11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 39, 203, 53, false);
                    AMOUNT11111111.Name = "AMOUNT11111111";
                    AMOUNT11111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT11111111.TextFont.Size = 10;
                    AMOUNT11111111.TextFont.Bold = true;
                    AMOUNT11111111.Value = @"Miktarı";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 179, 64, 203, 64, false);
                    NewLine1.Name = "NewLine1";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 203, 53, 203, 64, false);
                    NewLine2.Name = "NewLine2";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 179, 53, 179, 64, false);
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
                    MaintenanceOrder maintanenceOrder = (MaintenanceOrder)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(MaintenanceOrder));

            bool tecnicalMember = false;
            string chefString = string.Empty;
            string techMember1 = string.Empty;
            string techMember2 = string.Empty;
            string sMember = string.Empty;
            string approvalMember = string.Empty;

            
            MATERIALNAME.CalcValue = maintanenceOrder.FixedAssetMaterialDefinition.FixedAssetDefinition.Name;
            NATOSTOCKNO.CalcValue = maintanenceOrder.FixedAssetMaterialDefinition.FixedAssetDefinition.NATOStockNO;
            
            if(maintanenceOrder.SenderSection != null)
                SENDERSECTION.CalcValue = maintanenceOrder.SenderSection.Name ;
           
            REQUESTNO.CalcValue = maintanenceOrder.RequestNo.ToString();
            SERIALNO.CalcValue = maintanenceOrder.FixedAssetMaterialDefinition.Mark + " - " + maintanenceOrder.FixedAssetMaterialDefinition.Model + " - "+ maintanenceOrder.FixedAssetMaterialDefinition.SerialNumber;
            AMOUNT.CalcValue = "1";
            DISTYPE.CalcValue = maintanenceOrder.FixedAssetMaterialDefinition.FixedAssetDefinition.StockCard.DistributionType.DistributionType.ToString();
#endregion FOOTER HEADER_Script
                }
            }
            public partial class FooterGroupFooter : TTReportSection
            {
                public KayitSilmeyeEsasTeknikRaporNEW MyParentReport
                {
                    get { return (KayitSilmeyeEsasTeknikRaporNEW)ParentReport; }
                }
                
                public TTReportField NewField131;
                public TTReportField NewField14;
                public TTReportField NewField1171;
                public TTReportField NewField1271;
                public TTReportShape NewLine12211;
                public TTReportField NewField181;
                public TTReportField BOLUMAMIRI;
                public TTReportField KISIMAMIRI;
                public TTReportField TEKNIKMUDUR;
                public TTReportField KLTKONT;
                public TTReportField ONAY;
                public TTReportShape NewLine111221;
                public TTReportField NewField1172;
                public TTReportField NewField12711;
                public TTReportShape NewLine111222;
                public TTReportShape NewLine111223;
                public TTReportField NewField111721;
                public TTReportShape NewLine1222111;
                public TTReportField NewField1127111;
                public TTReportShape NewLine11112221;
                public TTReportField TEKNISYEN;
                public TTReportShape NewLine1222112;
                public TTReportField TEKNISYEN12; 
                public FooterGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 127;
                    RepeatCount = 0;
                    
                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 32, 244, 37, false);
                    NewField131.Name = "NewField131";
                    NewField131.Visible = EvetHayirEnum.ehHayir;
                    NewField131.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.TextFont.Size = 10;
                    NewField131.TextFont.Bold = true;
                    NewField131.Value = @"HİZMETE ÖZEL";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 7, 203, 13, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.TextFont.Size = 10;
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @"RAPORU DÜZENLEYENLER";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 27, 158, 33, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1171.TextFont.Size = 10;
                    NewField1171.TextFont.Bold = true;
                    NewField1171.Value = @"KISIM AMİRİ";

                    NewField1271 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 27, 203, 33, false);
                    NewField1271.Name = "NewField1271";
                    NewField1271.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1271.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1271.TextFont.Size = 10;
                    NewField1271.TextFont.Bold = true;
                    NewField1271.Value = @"TEKNİK MÜDÜR";

                    NewLine12211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 55, 33, 88, 33, false);
                    NewLine12211.Name = "NewLine12211";
                    NewLine12211.Visible = EvetHayirEnum.ehHayir;

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 81, 203, 87, false);
                    NewField181.Name = "NewField181";
                    NewField181.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField181.TextFont.Size = 10;
                    NewField181.TextFont.Bold = true;
                    NewField181.Value = @"ONAY";

                    BOLUMAMIRI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 45, 88, 77, false);
                    BOLUMAMIRI.Name = "BOLUMAMIRI";
                    BOLUMAMIRI.DrawStyle = DrawStyleConstants.vbInvisible;
                    BOLUMAMIRI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUMAMIRI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BOLUMAMIRI.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUMAMIRI.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUMAMIRI.TextFont.Size = 10;
                    BOLUMAMIRI.Value = @"";

                    KISIMAMIRI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 45, 163, 77, false);
                    KISIMAMIRI.Name = "KISIMAMIRI";
                    KISIMAMIRI.DrawStyle = DrawStyleConstants.vbInvisible;
                    KISIMAMIRI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KISIMAMIRI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KISIMAMIRI.MultiLine = EvetHayirEnum.ehEvet;
                    KISIMAMIRI.WordBreak = EvetHayirEnum.ehEvet;
                    KISIMAMIRI.TextFont.Size = 10;
                    KISIMAMIRI.Value = @"";

                    TEKNIKMUDUR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 45, 203, 77, false);
                    TEKNIKMUDUR.Name = "TEKNIKMUDUR";
                    TEKNIKMUDUR.DrawStyle = DrawStyleConstants.vbInvisible;
                    TEKNIKMUDUR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKNIKMUDUR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKNIKMUDUR.MultiLine = EvetHayirEnum.ehEvet;
                    TEKNIKMUDUR.WordBreak = EvetHayirEnum.ehEvet;
                    TEKNIKMUDUR.TextFont.Size = 10;
                    TEKNIKMUDUR.Value = @"";

                    KLTKONT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 45, 48, 77, false);
                    KLTKONT.Name = "KLTKONT";
                    KLTKONT.DrawStyle = DrawStyleConstants.vbInvisible;
                    KLTKONT.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLTKONT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KLTKONT.MultiLine = EvetHayirEnum.ehEvet;
                    KLTKONT.WordBreak = EvetHayirEnum.ehEvet;
                    KLTKONT.TextFont.Size = 10;
                    KLTKONT.Value = @"";

                    ONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 97, 142, 118, false);
                    ONAY.Name = "ONAY";
                    ONAY.DrawStyle = DrawStyleConstants.vbInvisible;
                    ONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONAY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONAY.MultiLine = EvetHayirEnum.ehEvet;
                    ONAY.WordBreak = EvetHayirEnum.ehEvet;
                    ONAY.TextFont.Size = 10;
                    ONAY.Value = @"";

                    NewLine111221 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 33, 50, 33, false);
                    NewLine111221.Name = "NewLine111221";
                    NewLine111221.Visible = EvetHayirEnum.ehHayir;

                    NewField1172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 27, 48, 33, false);
                    NewField1172.Name = "NewField1172";
                    NewField1172.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1172.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1172.TextFont.Size = 10;
                    NewField1172.TextFont.Bold = true;
                    NewField1172.Value = @"KLT.KONT.ASTSB.";

                    NewField12711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 27, 86, 33, false);
                    NewField12711.Name = "NewField12711";
                    NewField12711.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField12711.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12711.TextFont.Size = 10;
                    NewField12711.TextFont.Bold = true;
                    NewField12711.Value = @"BÖLÜM AMİRİ";

                    NewLine111222 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 132, 33, 160, 33, false);
                    NewLine111222.Name = "NewLine111222";
                    NewLine111222.Visible = EvetHayirEnum.ehHayir;

                    NewLine111223 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 170, 33, 203, 33, false);
                    NewLine111223.Name = "NewLine111223";
                    NewLine111223.Visible = EvetHayirEnum.ehHayir;

                    NewField111721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 15, 81, 21, false);
                    NewField111721.Name = "NewField111721";
                    NewField111721.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111721.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111721.TextFont.Size = 10;
                    NewField111721.TextFont.Bold = true;
                    NewField111721.Value = @"MUA.KONT.VE KLT.YNT.BL.A.";

                    NewLine1222111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 22, 88, 22, false);
                    NewLine1222111.Name = "NewLine1222111";
                    NewLine1222111.Visible = EvetHayirEnum.ehHayir;

                    NewField1127111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 15, 178, 21, false);
                    NewField1127111.Name = "NewField1127111";
                    NewField1127111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1127111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1127111.TextFont.Size = 10;
                    NewField1127111.TextFont.Bold = true;
                    NewField1127111.Value = @"TEKNİK MÜDÜRLÜK";

                    NewLine11112221 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 95, 22, 203, 22, false);
                    NewLine11112221.Name = "NewLine11112221";
                    NewLine11112221.Visible = EvetHayirEnum.ehHayir;

                    TEKNISYEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 26, 123, 32, false);
                    TEKNISYEN.Name = "TEKNISYEN";
                    TEKNISYEN.DrawStyle = DrawStyleConstants.vbInvisible;
                    TEKNISYEN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKNISYEN.TextFont.Size = 10;
                    TEKNISYEN.TextFont.Bold = true;
                    TEKNISYEN.Value = @"TEKNİSYEN";

                    NewLine1222112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 97, 33, 125, 33, false);
                    NewLine1222112.Name = "NewLine1222112";
                    NewLine1222112.Visible = EvetHayirEnum.ehHayir;

                    TEKNISYEN12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 45, 127, 77, false);
                    TEKNISYEN12.Name = "TEKNISYEN12";
                    TEKNISYEN12.DrawStyle = DrawStyleConstants.vbInvisible;
                    TEKNISYEN12.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKNISYEN12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKNISYEN12.MultiLine = EvetHayirEnum.ehEvet;
                    TEKNISYEN12.WordBreak = EvetHayirEnum.ehEvet;
                    TEKNISYEN12.TextFont.Size = 10;
                    TEKNISYEN12.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField131.CalcValue = NewField131.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField1271.CalcValue = NewField1271.Value;
                    NewField181.CalcValue = NewField181.Value;
                    BOLUMAMIRI.CalcValue = @"";
                    KISIMAMIRI.CalcValue = @"";
                    TEKNIKMUDUR.CalcValue = @"";
                    KLTKONT.CalcValue = @"";
                    ONAY.CalcValue = @"";
                    NewField1172.CalcValue = NewField1172.Value;
                    NewField12711.CalcValue = NewField12711.Value;
                    NewField111721.CalcValue = NewField111721.Value;
                    NewField1127111.CalcValue = NewField1127111.Value;
                    TEKNISYEN.CalcValue = TEKNISYEN.Value;
                    TEKNISYEN12.CalcValue = @"";
                    return new TTReportObject[] { NewField131,NewField14,NewField1171,NewField1271,NewField181,BOLUMAMIRI,KISIMAMIRI,TEKNIKMUDUR,KLTKONT,ONAY,NewField1172,NewField12711,NewField111721,NewField1127111,TEKNISYEN,TEKNISYEN12};
                }

                public override void RunScript()
                {
#region FOOTER FOOTER_Script
                    MaintenanceOrder maintenanceOrder = (MaintenanceOrder)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(MaintenanceOrder));
            
            bool tecnicalMember = false;
            string chefString = string.Empty;
            string techMember1 = string.Empty;
            string techMember2 = string.Empty;
            string sMember = string.Empty;
            string sMember2 = string.Empty;
            string sMember3 = string.Empty;
            string approvalMember = string.Empty;
            
            if(maintenanceOrder.HEKCommisionMembers.Count > 0)
            {
                foreach(MaintenanceHEKCommisionMember hekCommision in   maintenanceOrder.HEKCommisionMembers)
                {
                    if(hekCommision.MemberDuty == CommisionMemberDutyEnum.TechnicalMember)
                    {
                        chefString += hekCommision.ResUser.Name +"\r\n";
                        if (hekCommision.ResUser.MilitaryClass != null)
                            chefString += hekCommision.ResUser.MilitaryClass.ShortName;
                        if (hekCommision.ResUser.Rank != null)
                            chefString += hekCommision.ResUser.Rank.ShortName + "\r\n";
                        chefString += "(" + hekCommision.ResUser.EmploymentRecordID + ")";
                        this.TEKNISYEN12.CalcValue = chefString;
                        
                    }
                    if (hekCommision.MemberDuty == CommisionMemberDutyEnum.TechnicalHead)
                    {
                        if (tecnicalMember == false)
                        {
                            techMember1 += hekCommision.ResUser.Name + "\r\n";
                            if (hekCommision.ResUser.MilitaryClass != null)
                                techMember1 += hekCommision.ResUser.MilitaryClass.ShortName;
                            if (hekCommision.ResUser.Rank != null)
                                techMember1 += hekCommision.ResUser.Rank.ShortName + "\r\n";
                            techMember1 += "(" + hekCommision.ResUser.EmploymentRecordID + ")";
                            this.TEKNIKMUDUR.CalcValue = techMember1;
                            tecnicalMember = true;
                        }
                        else
                        {
                            techMember2 += hekCommision.ResUser.Name + "\r\n";
                            if (hekCommision.ResUser.MilitaryClass != null)
                                techMember2 += hekCommision.ResUser.MilitaryClass.ShortName;
                            if (hekCommision.ResUser.Rank != null)
                                techMember2 += hekCommision.ResUser.Rank.ShortName + "\r\n";
                            techMember2 += "(" + hekCommision.ResUser.EmploymentRecordID + ")";
                            this.TEKNIKMUDUR.CalcValue = techMember2;
                        }
                    }
                    if(hekCommision.MemberDuty == CommisionMemberDutyEnum.SectionHead)
                    {
                        sMember += hekCommision.ResUser.Name + "\r\n";
                        if (hekCommision.ResUser.MilitaryClass != null)
                            sMember += hekCommision.ResUser.MilitaryClass.ShortName;
                        if (hekCommision.ResUser.Rank != null)
                            sMember += hekCommision.ResUser.Rank.ShortName + "\r\n";
                        sMember += "(" + hekCommision.ResUser.EmploymentRecordID + ")";
                        this.BOLUMAMIRI.CalcValue = sMember;
                        
                    }

                    if (hekCommision.MemberDuty == CommisionMemberDutyEnum.SectionChief)
                    {
                        sMember2 += hekCommision.ResUser.Name + "\r\n";
                        if (hekCommision.ResUser.MilitaryClass != null)
                            sMember2 += hekCommision.ResUser.MilitaryClass.ShortName;
                        if (hekCommision.ResUser.Rank != null)
                            sMember2 += hekCommision.ResUser.Rank.ShortName + "\r\n";
                        sMember2 += "(" + hekCommision.ResUser.EmploymentRecordID + ")";
                        this.KISIMAMIRI.CalcValue = sMember2;

                    }
                    if (hekCommision.MemberDuty == CommisionMemberDutyEnum.Assay)
                    {
                        sMember3 += hekCommision.ResUser.Name + "\r\n";
                        if (hekCommision.ResUser.MilitaryClass != null)
                            sMember3 += hekCommision.ResUser.MilitaryClass.ShortName;
                        if (hekCommision.ResUser.Rank != null)
                            sMember3 += hekCommision.ResUser.Rank.ShortName + "\r\n";
                        sMember3 += "(" + hekCommision.ResUser.EmploymentRecordID + ")";
                        this.KLTKONT.CalcValue = sMember3;

                    }

                    if(hekCommision.MemberDuty == CommisionMemberDutyEnum.Approval)
                    {
                        approvalMember += hekCommision.ResUser.Name + "\r\n";
                        if(hekCommision.ResUser.Title.HasValue)
                        {
                            TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(UserTitleEnum).Name];
                            approvalMember += dataType.EnumValueDefs[(int)hekCommision.ResUser.Title.Value].DisplayText;
                        }
                        if (hekCommision.ResUser.MilitaryClass != null)
                            approvalMember += hekCommision.ResUser.MilitaryClass.ShortName;
                        if (hekCommision.ResUser.Rank != null)
                            approvalMember += hekCommision.ResUser.Rank.ShortName + "\r\n";
                        approvalMember += "(" + hekCommision.ResUser.EmploymentRecordID + ")\r\n";
                        if (hekCommision.ResUser.Work != string.Empty)
                        {
                            approvalMember += hekCommision.ResUser.Work;
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
            public KayitSilmeyeEsasTeknikRaporNEW MyParentReport
            {
                get { return (KayitSilmeyeEsasTeknikRaporNEW)ParentReport; }
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
            public TTReportField REQUESTDATE { get {return Header().REQUESTDATE;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
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
            public TTReportRTF REPAIRNOTESRTF { get {return Header().REPAIRNOTESRTF;} }
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
            public TTReportField UNITECOST { get {return Footer().UNITECOST;} }
            public TTReportField WORKLOAD { get {return Footer().WORKLOAD;} }
            public TTReportField TOTALMATERIALPRICE { get {return Footer().TOTALMATERIALPRICE;} }
            public TTReportField TOTALNEED { get {return Footer().TOTALNEED;} }
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
                list[0] = new TTReportNqlData<MaintenanceOrder.GetHekReportMaintanenceOrder_Class>("GetHekReportMaintanenceOrder", MaintenanceOrder.GetHekReportMaintanenceOrder((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public KayitSilmeyeEsasTeknikRaporNEW MyParentReport
                {
                    get { return (KayitSilmeyeEsasTeknikRaporNEW)ParentReport; }
                }
                
                public TTReportField NewField1111151111;
                public TTReportField NewField11511;
                public TTReportField NewField3;
                public TTReportField NewField111511;
                public TTReportField FAULTDESCRIPTION;
                public TTReportField REQUESTDATE;
                public TTReportField NewField13;
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
                public TTReportRTF REPAIRNOTESRTF; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 91;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111151111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 102, 7, false);
                    NewField1111151111.Name = "NewField1111151111";
                    NewField1111151111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1111151111.TextFont.Size = 10;
                    NewField1111151111.TextFont.Bold = true;
                    NewField1111151111.Value = @"C. HASAR / ARIZA BİLGİLERİ :";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 8, 102, 14, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField11511.TextFont.Size = 10;
                    NewField11511.TextFont.Bold = true;
                    NewField11511.Value = @"1. HASARIN / ARIZANIN TANIMI";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 8, 106, 14, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.TextFont.Size = 10;
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @":";

                    NewField111511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 30, 102, 36, false);
                    NewField111511.Name = "NewField111511";
                    NewField111511.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111511.TextFont.Size = 10;
                    NewField111511.TextFont.Bold = true;
                    NewField111511.Value = @"2. HASARIN / ARIZANIN NEDENLERİ";

                    FAULTDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 8, 203, 29, false);
                    FAULTDESCRIPTION.Name = "FAULTDESCRIPTION";
                    FAULTDESCRIPTION.DrawStyle = DrawStyleConstants.vbInvisible;
                    FAULTDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    FAULTDESCRIPTION.VertAlign = VerticalAlignmentEnum.vaTop;
                    FAULTDESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    FAULTDESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    FAULTDESCRIPTION.TextFont.Name = "Arial Narrow";
                    FAULTDESCRIPTION.TextFont.Size = 10;
                    FAULTDESCRIPTION.TextFont.CharSet = 1;
                    FAULTDESCRIPTION.Value = @"{#FAULTDESCRIPTION#}";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 54, 132, 60, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.DrawStyle = DrawStyleConstants.vbInvisible;
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"dd/MM/yyyy";
                    REQUESTDATE.TextFont.Name = "Arial Narrow";
                    REQUESTDATE.TextFont.Size = 10;
                    REQUESTDATE.TextFont.CharSet = 1;
                    REQUESTDATE.Value = @"{#REQUESTDATE#}";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 30, 106, 36, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.TextFont.Size = 10;
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @":";

                    NewField1115111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 54, 102, 60, false);
                    NewField1115111.Name = "NewField1115111";
                    NewField1115111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1115111.TextFont.Size = 10;
                    NewField1115111.TextFont.Bold = true;
                    NewField1115111.Value = @"3. HASARIN / ARIZANIN TARİHİ";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 54, 106, 60, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.TextFont.Size = 10;
                    NewField131.TextFont.Bold = true;
                    NewField131.Value = @":";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 61, 102, 67, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField4.TextFont.Size = 10;
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @"Ç. ONARIMA ESAS BİLGİLER :";

                    NewField111512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 69, 102, 75, false);
                    NewField111512.Name = "NewField111512";
                    NewField111512.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111512.TextFont.Size = 10;
                    NewField111512.TextFont.Bold = true;
                    NewField111512.Value = @"1. MALZEMENİN RAPOR TARİHİNDEKİ DEĞERİ";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 69, 106, 75, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.TextFont.Size = 10;
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @":";

                    MATERIALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 69, 131, 75, false);
                    MATERIALPRICE.Name = "MATERIALPRICE";
                    MATERIALPRICE.DrawStyle = DrawStyleConstants.vbInvisible;
                    MATERIALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALPRICE.TextFont.Name = "Arial Narrow";
                    MATERIALPRICE.TextFont.Size = 10;
                    MATERIALPRICE.TextFont.CharSet = 1;
                    MATERIALPRICE.Value = @"";

                    NewField1215111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 78, 124, 84, false);
                    NewField1215111.Name = "NewField1215111";
                    NewField1215111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1215111.TextFont.Size = 10;
                    NewField1215111.TextFont.Bold = true;
                    NewField1215111.Value = @"2. ONARIM İÇİN İHTİYAÇ DUYULAN MALZEMELER VE DEĞERİ";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 78, 128, 84, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.TextFont.Size = 10;
                    NewField141.TextFont.Bold = true;
                    NewField141.Value = @":";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 86, 26, 91, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.TextFont.Name = "Arial Narrow";
                    NewField11.TextFont.Size = 10;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"S.Nu.";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 86, 124, 91, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.TextFont.Name = "Arial Narrow";
                    NewField111.TextFont.Size = 10;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @"Malzemenin Cinsi";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 86, 149, 91, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.TextFont.Name = "Arial Narrow";
                    NewField1111.TextFont.Size = 10;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @"Parça Nu.";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 86, 167, 91, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.TextFont.Name = "Arial Narrow";
                    NewField11111.TextFont.Size = 10;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.Value = @"Miktarı";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 86, 185, 91, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.TextFont.Name = "Arial Narrow";
                    NewField111111.TextFont.Size = 10;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.Value = @"B. Fiyatı";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 86, 203, 91, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111111.TextFont.Name = "Arial Narrow";
                    NewField1111111.TextFont.Size = 10;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.Value = @"Tutarı";

                    REPAIRNOTES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 7, 311, 30, false);
                    REPAIRNOTES.Name = "REPAIRNOTES";
                    REPAIRNOTES.Visible = EvetHayirEnum.ehHayir;
                    REPAIRNOTES.DrawStyle = DrawStyleConstants.vbInvisible;
                    REPAIRNOTES.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPAIRNOTES.VertAlign = VerticalAlignmentEnum.vaTop;
                    REPAIRNOTES.MultiLine = EvetHayirEnum.ehEvet;
                    REPAIRNOTES.WordBreak = EvetHayirEnum.ehEvet;
                    REPAIRNOTES.TextFont.Name = "Arial Narrow";
                    REPAIRNOTES.TextFont.Size = 10;
                    REPAIRNOTES.TextFont.CharSet = 1;
                    REPAIRNOTES.Value = @"{#REPAIRNOTES#}";

                    REPAIRNOTESRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 107, 30, 203, 53, false);
                    REPAIRNOTESRTF.Name = "REPAIRNOTESRTF";
                    REPAIRNOTESRTF.DrawStyle = DrawStyleConstants.vbInvisible;
                    REPAIRNOTESRTF.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetHekReportMaintanenceOrder_Class dataset_GetHekReportMaintanenceOrder = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetHekReportMaintanenceOrder_Class>(0);
                    NewField1111151111.CalcValue = NewField1111151111.Value;
                    NewField11511.CalcValue = NewField11511.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField111511.CalcValue = NewField111511.Value;
                    FAULTDESCRIPTION.CalcValue = (dataset_GetHekReportMaintanenceOrder != null ? Globals.ToStringCore(dataset_GetHekReportMaintanenceOrder.Faultdescription) : "");
                    REQUESTDATE.CalcValue = (dataset_GetHekReportMaintanenceOrder != null ? Globals.ToStringCore(dataset_GetHekReportMaintanenceOrder.RequestDate) : "");
                    NewField13.CalcValue = NewField13.Value;
                    NewField1115111.CalcValue = NewField1115111.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField111512.CalcValue = NewField111512.Value;
                    NewField14.CalcValue = NewField14.Value;
                    MATERIALPRICE.CalcValue = @"";
                    NewField1215111.CalcValue = NewField1215111.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    REPAIRNOTES.CalcValue = (dataset_GetHekReportMaintanenceOrder != null ? Globals.ToStringCore(dataset_GetHekReportMaintanenceOrder.Repairnotes) : "");
                    REPAIRNOTESRTF.CalcValue = REPAIRNOTESRTF.Value;
                    return new TTReportObject[] { NewField1111151111,NewField11511,NewField3,NewField111511,FAULTDESCRIPTION,REQUESTDATE,NewField13,NewField1115111,NewField131,NewField4,NewField111512,NewField14,MATERIALPRICE,NewField1215111,NewField141,NewField11,NewField111,NewField1111,NewField11111,NewField111111,NewField1111111,REPAIRNOTES,REPAIRNOTESRTF};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    REPAIRNOTESRTF.CalcValue = REPAIRNOTES.CalcValue;
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public KayitSilmeyeEsasTeknikRaporNEW MyParentReport
                {
                    get { return (KayitSilmeyeEsasTeknikRaporNEW)ParentReport; }
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
                public TTReportField UNITECOST;
                public TTReportField WORKLOAD;
                public TTReportField TOTALMATERIALPRICE;
                public TTReportField TOTALNEED; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 105;
                    RepeatCount = 0;
                    
                    REPORTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 90, 134, 96, false);
                    REPORTDATE.Name = "REPORTDATE";
                    REPORTDATE.DrawStyle = DrawStyleConstants.vbInvisible;
                    REPORTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTDATE.TextFormat = @"dd/MM/yyyy";
                    REPORTDATE.TextFont.Size = 10;
                    REPORTDATE.Value = @"{@printdate@}";

                    NewField11512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 2, 105, 8, false);
                    NewField11512.Name = "NewField11512";
                    NewField11512.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField11512.TextFont.Size = 10;
                    NewField11512.TextFont.Bold = true;
                    NewField11512.Value = @"3. İŞCİLİK MALİYETİ";

                    NewField1115112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 90, 105, 96, false);
                    NewField1115112.Name = "NewField1115112";
                    NewField1115112.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1115112.TextFont.Size = 10;
                    NewField1115112.TextFont.Bold = true;
                    NewField1115112.Value = @"3. RAPORUN VERİLDİĞİ TARİH";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 2, 109, 8, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField5.TextFont.Size = 10;
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @":";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 90, 109, 96, false);
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

                    NewField121511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 10, 105, 16, false);
                    NewField121511.Name = "NewField121511";
                    NewField121511.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField121511.TextFont.Size = 10;
                    NewField121511.TextFont.Bold = true;
                    NewField121511.Value = @"4. ONARIM TOPLAM MALİYETİ";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 10, 109, 16, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.TextFont.Size = 10;
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @":";

                    NewField1115121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 18, 105, 24, false);
                    NewField1115121.Name = "NewField1115121";
                    NewField1115121.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1115121.TextFont.Size = 10;
                    NewField1115121.TextFont.Bold = true;
                    NewField1115121.Value = @"5. ONARIMIN YAPILIP YAPILAMAYACAĞI";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 18, 109, 24, false);
                    NewField152.Name = "NewField152";
                    NewField152.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField152.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField152.TextFont.Size = 10;
                    NewField152.TextFont.Bold = true;
                    NewField152.Value = @":";

                    NewField121512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 66, 100, 72, false);
                    NewField121512.Name = "NewField121512";
                    NewField121512.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField121512.TextFont.Size = 10;
                    NewField121512.TextFont.Bold = true;
                    NewField121512.Value = @"D. RAPORA AİT BİLGİLER :";

                    NewField121513 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 74, 105, 80, false);
                    NewField121513.Name = "NewField121513";
                    NewField121513.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField121513.TextFont.Size = 10;
                    NewField121513.TextFont.Bold = true;
                    NewField121513.Value = @"1. RAPORUN TANZİM EDİLDİĞİ BİRLİK";

                    NewField1251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 74, 109, 80, false);
                    NewField1251.Name = "NewField1251";
                    NewField1251.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1251.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1251.TextFont.Size = 10;
                    NewField1251.TextFont.Bold = true;
                    NewField1251.Value = @":";

                    NewField1315121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 82, 105, 88, false);
                    NewField1315121.Name = "NewField1315121";
                    NewField1315121.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1315121.TextFont.Size = 10;
                    NewField1315121.TextFont.Bold = true;
                    NewField1315121.Value = @"2. RAPOR NUMARASI";

                    NewField11521 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 82, 109, 88, false);
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

                    LABORTOTALCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 2, 134, 8, false);
                    LABORTOTALCOST.Name = "LABORTOTALCOST";
                    LABORTOTALCOST.DrawStyle = DrawStyleConstants.vbInvisible;
                    LABORTOTALCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    LABORTOTALCOST.TextFont.Name = "Arial Narrow";
                    LABORTOTALCOST.TextFont.Size = 10;
                    LABORTOTALCOST.TextFont.CharSet = 1;
                    LABORTOTALCOST.Value = @"";

                    REPAIRTOTALCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 10, 134, 16, false);
                    REPAIRTOTALCOST.Name = "REPAIRTOTALCOST";
                    REPAIRTOTALCOST.DrawStyle = DrawStyleConstants.vbInvisible;
                    REPAIRTOTALCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPAIRTOTALCOST.VertAlign = VerticalAlignmentEnum.vaTop;
                    REPAIRTOTALCOST.TextFont.Name = "Arial Narrow";
                    REPAIRTOTALCOST.TextFont.Size = 10;
                    REPAIRTOTALCOST.TextFont.CharSet = 1;
                    REPAIRTOTALCOST.Value = @"";

                    SECTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 74, 203, 80, false);
                    SECTION.Name = "SECTION";
                    SECTION.DrawStyle = DrawStyleConstants.vbInvisible;
                    SECTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    SECTION.TextFont.Name = "Arial Narrow";
                    SECTION.TextFont.Size = 10;
                    SECTION.TextFont.CharSet = 1;
                    SECTION.Value = @"{#SECTION#}";

                    HEKREPORTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 82, 134, 88, false);
                    HEKREPORTNO.Name = "HEKREPORTNO";
                    HEKREPORTNO.DrawStyle = DrawStyleConstants.vbInvisible;
                    HEKREPORTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEKREPORTNO.VertAlign = VerticalAlignmentEnum.vaTop;
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

                    DESCRIPTIONRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 20, 26, 203, 64, false);
                    DESCRIPTIONRTF.Name = "DESCRIPTIONRTF";
                    DESCRIPTIONRTF.DrawStyle = DrawStyleConstants.vbInvisible;
                    DESCRIPTIONRTF.Value = @"";

                    UNITECOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 3, 240, 8, false);
                    UNITECOST.Name = "UNITECOST";
                    UNITECOST.Visible = EvetHayirEnum.ehHayir;
                    UNITECOST.DrawStyle = DrawStyleConstants.vbInvisible;
                    UNITECOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITECOST.VertAlign = VerticalAlignmentEnum.vaTop;
                    UNITECOST.TextFont.Name = "Arial Narrow";
                    UNITECOST.TextFont.Size = 10;
                    UNITECOST.TextFont.CharSet = 1;
                    UNITECOST.Value = @"{#UNITECOST#}";

                    WORKLOAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 243, 3, 268, 8, false);
                    WORKLOAD.Name = "WORKLOAD";
                    WORKLOAD.Visible = EvetHayirEnum.ehHayir;
                    WORKLOAD.DrawStyle = DrawStyleConstants.vbInvisible;
                    WORKLOAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKLOAD.VertAlign = VerticalAlignmentEnum.vaTop;
                    WORKLOAD.TextFont.Name = "Arial Narrow";
                    WORKLOAD.TextFont.Size = 10;
                    WORKLOAD.TextFont.CharSet = 1;
                    WORKLOAD.Value = @"{#WORKLOAD#}";

                    TOTALMATERIALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 273, 3, 298, 8, false);
                    TOTALMATERIALPRICE.Name = "TOTALMATERIALPRICE";
                    TOTALMATERIALPRICE.Visible = EvetHayirEnum.ehHayir;
                    TOTALMATERIALPRICE.DrawStyle = DrawStyleConstants.vbInvisible;
                    TOTALMATERIALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALMATERIALPRICE.VertAlign = VerticalAlignmentEnum.vaTop;
                    TOTALMATERIALPRICE.TextFont.Name = "Arial Narrow";
                    TOTALMATERIALPRICE.TextFont.Size = 10;
                    TOTALMATERIALPRICE.TextFont.CharSet = 1;
                    TOTALMATERIALPRICE.Value = @"{#TOTALMATERIALPRICE#}";

                    TOTALNEED = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 11, 242, 16, false);
                    TOTALNEED.Name = "TOTALNEED";
                    TOTALNEED.Visible = EvetHayirEnum.ehHayir;
                    TOTALNEED.DrawStyle = DrawStyleConstants.vbInvisible;
                    TOTALNEED.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALNEED.VertAlign = VerticalAlignmentEnum.vaTop;
                    TOTALNEED.TextFont.Name = "Arial Narrow";
                    TOTALNEED.TextFont.Size = 10;
                    TOTALNEED.TextFont.CharSet = 1;
                    TOTALNEED.Value = @"{@sumof(MATERIALTOTALPRICE)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetHekReportMaintanenceOrder_Class dataset_GetHekReportMaintanenceOrder = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetHekReportMaintanenceOrder_Class>(0);
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
                    REQUESTDATE1.CalcValue = (dataset_GetHekReportMaintanenceOrder != null ? Globals.ToStringCore(dataset_GetHekReportMaintanenceOrder.RequestDate) : "");
                    LABORTOTALCOST.CalcValue = @"";
                    REPAIRTOTALCOST.CalcValue = @"";
                    SECTION.CalcValue = (dataset_GetHekReportMaintanenceOrder != null ? Globals.ToStringCore(dataset_GetHekReportMaintanenceOrder.Section) : "");
                    HEKREPORTNO.CalcValue = (dataset_GetHekReportMaintanenceOrder != null ? Globals.ToStringCore(dataset_GetHekReportMaintanenceOrder.Hekreportno) : "");
                    REQUESTNO.CalcValue = (dataset_GetHekReportMaintanenceOrder != null ? Globals.ToStringCore(dataset_GetHekReportMaintanenceOrder.RequestNo) : "");
                    DESCRIPTIONRTF.CalcValue = DESCRIPTIONRTF.Value;
                    UNITECOST.CalcValue = (dataset_GetHekReportMaintanenceOrder != null ? Globals.ToStringCore(dataset_GetHekReportMaintanenceOrder.Unitecost) : "");
                    WORKLOAD.CalcValue = (dataset_GetHekReportMaintanenceOrder != null ? Globals.ToStringCore(dataset_GetHekReportMaintanenceOrder.Workload) : "");
                    TOTALMATERIALPRICE.CalcValue = (dataset_GetHekReportMaintanenceOrder != null ? Globals.ToStringCore(dataset_GetHekReportMaintanenceOrder.TotalMaterialPrice) : "");
                    TOTALNEED.CalcValue = ParentGroup.FieldSums["MATERIALTOTALPRICE"].Value.ToString();;
                    return new TTReportObject[] { REPORTDATE,NewField11512,NewField1115112,NewField5,NewField12,NewField1161,NewField121511,NewField15,NewField1115121,NewField152,NewField121512,NewField121513,NewField1251,NewField1315121,NewField11521,NewField12115111,NewField121,REQUESTDATE1,LABORTOTALCOST,REPAIRTOTALCOST,SECTION,HEKREPORTNO,REQUESTNO,DESCRIPTIONRTF,UNITECOST,WORKLOAD,TOTALMATERIALPRICE,TOTALNEED};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    MaintenanceOrder maintenanceOrder = (MaintenanceOrder)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(MaintenanceOrder));
            
            string description;
            string hekNedeni="";
            string aciklama= "    Yukarıda marka modeli belirtilen cihaz, uzun süreli kullanımdan dolayı kullanıcı hatası olmaksızın normal aşınma ve yıpranma sonucu nitelik ve özelliklerini kaybetmiştir.\n Cihazın yapılan incelemesinde; ";
            string aciklama2= " tespit edilmiştir. Cihazın mevcut durumu nedeniyle onarılmasının mümkün olmayacağı değerlendirilmiştir.\n   Cihazın eski model ve eski teknoloji ürünü olması nedeniyle yenileştirilmesi mümkün değildir.";
            string aciklama3="\n    Yukarıda belirtilen nedenlerden dolayı; MSY 59-2(A) XXXXXX Taşınır Mal Yönergesinin 5.ncü bölüm 1.inci maddesi I-";
          
              foreach(MaintanenceOrderHEKReasons mo in maintenanceOrder.MaintanenceOrderHEKReasons)
              {
                  if (mo.Check == true) 
                  {
                      hekNedeni = mo.CousesOfTheHekDefinition.Counter + " fıkrasında belirtildiği üzere " + mo.CousesOfTheHekDefinition.Description;
                  }
              }      
            
            string aciklama4= " -dan dolayı kayıt silme işlemine tabi tutulmasının uygun olacağı değerlendirilmiştir.";

            description= aciklama + TTObjectClasses.Common.GetTextOfRTFString(maintenanceOrder.HEKDescription) + aciklama2 + aciklama3  + hekNedeni + aciklama4;
            
            DESCRIPTIONRTF.CalcValue = TTObjectClasses.Common.GetRTFOfTextString(description);
            
            if(UNITECOST.CalcValue =="" ) UNITECOST.CalcValue = "0";
            if(WORKLOAD.CalcValue  == "") WORKLOAD.CalcValue  ="0";
            if(TOTALNEED.CalcValue == "") TOTALNEED.CalcValue = "0";
            if(TOTALMATERIALPRICE.CalcValue == "") TOTALMATERIALPRICE.CalcValue = "0";
            
            LABORTOTALCOST.CalcValue = (Convert.ToDouble(UNITECOST.CalcValue) * Convert.ToDouble(WORKLOAD.CalcValue)).ToString();
            REPAIRTOTALCOST.CalcValue = (Convert.ToDouble(LABORTOTALCOST.CalcValue) + Convert.ToDouble(TOTALMATERIALPRICE.CalcValue) + Convert.ToDouble(TOTALNEED.CalcValue)).ToString();
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public KayitSilmeyeEsasTeknikRaporNEW MyParentReport
            {
                get { return (KayitSilmeyeEsasTeknikRaporNEW)ParentReport; }
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
                list[0] = new TTReportNqlData<NeededMaterials.MaintenanceOrderNeededMaterialQuery_Class>("MaintenanceOrderNeededMaterialQuery", NeededMaterials.MaintenanceOrderNeededMaterialQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public KayitSilmeyeEsasTeknikRaporNEW MyParentReport
                {
                    get { return (KayitSilmeyeEsasTeknikRaporNEW)ParentReport; }
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
                    
                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 0, 124, 5, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaTop;
                    MATERIALNAME.TextFont.Name = "Arial Narrow";
                    MATERIALNAME.TextFont.Size = 10;
                    MATERIALNAME.TextFont.CharSet = 1;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    PARTNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 0, 149, 5, false);
                    PARTNUMBER.Name = "PARTNUMBER";
                    PARTNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARTNUMBER.VertAlign = VerticalAlignmentEnum.vaTop;
                    PARTNUMBER.TextFont.Name = "Arial Narrow";
                    PARTNUMBER.TextFont.Size = 10;
                    PARTNUMBER.TextFont.CharSet = 1;
                    PARTNUMBER.Value = @"{#PARTNUMBER#}";

                    MATERIALAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 0, 167, 5, false);
                    MATERIALAMOUNT.Name = "MATERIALAMOUNT";
                    MATERIALAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALAMOUNT.VertAlign = VerticalAlignmentEnum.vaTop;
                    MATERIALAMOUNT.TextFont.Name = "Arial Narrow";
                    MATERIALAMOUNT.TextFont.Size = 10;
                    MATERIALAMOUNT.TextFont.CharSet = 1;
                    MATERIALAMOUNT.Value = @"{#MATERIALAMOUNT#}";

                    MATERIALUNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 0, 185, 5, false);
                    MATERIALUNITPRICE.Name = "MATERIALUNITPRICE";
                    MATERIALUNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALUNITPRICE.VertAlign = VerticalAlignmentEnum.vaTop;
                    MATERIALUNITPRICE.TextFont.Name = "Arial Narrow";
                    MATERIALUNITPRICE.TextFont.Size = 10;
                    MATERIALUNITPRICE.TextFont.CharSet = 1;
                    MATERIALUNITPRICE.Value = @"{#MATERIALUNITPRICE#}";

                    MATERIALTOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 0, 203, 5, false);
                    MATERIALTOTALPRICE.Name = "MATERIALTOTALPRICE";
                    MATERIALTOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALTOTALPRICE.VertAlign = VerticalAlignmentEnum.vaTop;
                    MATERIALTOTALPRICE.TextFont.Name = "Arial Narrow";
                    MATERIALTOTALPRICE.TextFont.Size = 10;
                    MATERIALTOTALPRICE.TextFont.CharSet = 1;
                    MATERIALTOTALPRICE.Value = @"{#MATERIALTOTALPRICE#}";

                    SNU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 26, 5, false);
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
                    NeededMaterials.MaintenanceOrderNeededMaterialQuery_Class dataset_MaintenanceOrderNeededMaterialQuery = ParentGroup.rsGroup.GetCurrentRecord<NeededMaterials.MaintenanceOrderNeededMaterialQuery_Class>(0);
                    MATERIALNAME.CalcValue = (dataset_MaintenanceOrderNeededMaterialQuery != null ? Globals.ToStringCore(dataset_MaintenanceOrderNeededMaterialQuery.MaterialName) : "");
                    PARTNUMBER.CalcValue = (dataset_MaintenanceOrderNeededMaterialQuery != null ? Globals.ToStringCore(dataset_MaintenanceOrderNeededMaterialQuery.PartNumber) : "");
                    MATERIALAMOUNT.CalcValue = (dataset_MaintenanceOrderNeededMaterialQuery != null ? Globals.ToStringCore(dataset_MaintenanceOrderNeededMaterialQuery.MaterialAmount) : "");
                    MATERIALUNITPRICE.CalcValue = (dataset_MaintenanceOrderNeededMaterialQuery != null ? Globals.ToStringCore(dataset_MaintenanceOrderNeededMaterialQuery.MaterialUnitPrice) : "");
                    MATERIALTOTALPRICE.CalcValue = (dataset_MaintenanceOrderNeededMaterialQuery != null ? Globals.ToStringCore(dataset_MaintenanceOrderNeededMaterialQuery.MaterialTotalPrice) : "");
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

        public KayitSilmeyeEsasTeknikRaporNEW()
        {
            Footer = new FooterGroup(this,"Footer");
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
            Name = "KAYITSILMEYEESASTEKNIKRAPORNEW";
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