
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
    /// Onay Belgesi Raporu
    /// </summary>
    public partial class OnayBelgesiRaporu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public OnayBelgesiRaporu MyParentReport
            {
                get { return (OnayBelgesiRaporu)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField PROJECTNO { get {return Footer().PROJECTNO;} }
            public TTReportField NewField1191 { get {return Footer().NewField1191;} }
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
                public OnayBelgesiRaporu MyParentReport
                {
                    get { return (OnayBelgesiRaporu)ParentReport; }
                }
                 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public OnayBelgesiRaporu MyParentReport
                {
                    get { return (OnayBelgesiRaporu)ParentReport; }
                }
                
                public TTReportField PROJECTNO;
                public TTReportField NewField1191; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 15;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PROJECTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PROJECTNO.Name = "PROJECTNO";
                    PROJECTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROJECTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO.NoClip = EvetHayirEnum.ehEvet;
                    PROJECTNO.TextFont.Name = "Arial";
                    PROJECTNO.TextFont.Size = 8;
                    PROJECTNO.Value = @"";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 8, 10, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1191.TextFont.Name = "Arial";
                    NewField1191.TextFont.Size = 8;
                    NewField1191.TextFont.Underline = true;
                    NewField1191.Value = @"GİZLİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PROJECTNO.CalcValue = @"";
                    NewField1191.CalcValue = NewField1191.Value;
                    return new TTReportObject[] { PROJECTNO,NewField1191};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    string objectID = ((OnayBelgesiRaporu)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            PurchaseProject pp = (PurchaseProject)ctx.GetObject(new Guid(objectID), typeof(PurchaseProject));
            if (pp != null)
                PROJECTNO.CalcValue = " Proje Nu. : " + pp.PurchaseProjectNO.ToString();
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public OnayBelgesiRaporu MyParentReport
            {
                get { return (OnayBelgesiRaporu)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField RESPONSIBLEPROCUREMENTUNITDEF { get {return Header().RESPONSIBLEPROCUREMENTUNITDEF;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField LABELISMIKTAR { get {return Header().LABELISMIKTAR;} }
            public TTReportField ISTANIMI { get {return Header().ISTANIMI;} }
            public TTReportField ISNITELIK { get {return Header().ISNITELIK;} }
            public TTReportField YETKILIMAKAM { get {return Header().YETKILIMAKAM;} }
            public TTReportField ISMIKTAR { get {return Header().ISMIKTAR;} }
            public TTReportField CONFIRMNO { get {return Header().CONFIRMNO;} }
            public TTReportField LABELISADI { get {return Header().LABELISADI;} }
            public TTReportField BELGETRH_HIDDEN2 { get {return Header().BELGETRH_HIDDEN2;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField ODENEKTUTARI { get {return Header().ODENEKTUTARI;} }
            public TTReportField YATIRIMPROJENO { get {return Header().YATIRIMPROJENO;} }
            public TTReportField BUTCETERTIBI { get {return Header().BUTCETERTIBI;} }
            public TTReportField AVANSSARTLARI { get {return Header().AVANSSARTLARI;} }
            public TTReportField IHALEUSUL { get {return Header().IHALEUSUL;} }
            public TTReportField ILANSEKLI { get {return Header().ILANSEKLI;} }
            public TTReportField SARTNAMESATISBEDELI { get {return Header().SARTNAMESATISBEDELI;} }
            public TTReportField DAYANAK { get {return Header().DAYANAK;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportRTF ReportRTF { get {return Header().ReportRTF;} }
            public TTReportField ADVANCED { get {return Header().ADVANCED;} }
            public TTReportField CONFIRMDATEANDNO { get {return Header().CONFIRMDATEANDNO;} }
            public TTReportField PRICEDIFFERENCE { get {return Header().PRICEDIFFERENCE;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField DESC { get {return Footer().DESC;} }
            public TTReportField NewField5_ { get {return Footer().NewField5_;} }
            public TTReportField NewField9_ { get {return Footer().NewField9_;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
            public TTReportField NewField17 { get {return Footer().NewField17;} }
            public TTReportField EXPENSERDUTY { get {return Footer().EXPENSERDUTY;} }
            public TTReportField PERFORMERDUTY { get {return Footer().PERFORMERDUTY;} }
            public TTReportField NewField18 { get {return Footer().NewField18;} }
            public TTReportField NewField171 { get {return Footer().NewField171;} }
            public TTReportField NewField1171 { get {return Footer().NewField1171;} }
            public TTReportField EXPENSERRANK { get {return Footer().EXPENSERRANK;} }
            public TTReportField PERFORMERRANK { get {return Footer().PERFORMERRANK;} }
            public TTReportField PERFORMERTITLE { get {return Footer().PERFORMERTITLE;} }
            public TTReportField EXPENSERTITLE { get {return Footer().EXPENSERTITLE;} }
            public TTReportField NewField11711 { get {return Footer().NewField11711;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField NewField131 { get {return Footer().NewField131;} }
            public TTReportField NewField132 { get {return Footer().NewField132;} }
            public TTReportField NewField133 { get {return Footer().NewField133;} }
            public TTReportField NewField134 { get {return Footer().NewField134;} }
            public TTReportField NewField1131 { get {return Footer().NewField1131;} }
            public TTReportField NewField1231 { get {return Footer().NewField1231;} }
            public TTReportField NewField1331 { get {return Footer().NewField1331;} }
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
                public OnayBelgesiRaporu MyParentReport
                {
                    get { return (OnayBelgesiRaporu)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField RESPONSIBLEPROCUREMENTUNITDEF;
                public TTReportField NewField7;
                public TTReportField NewField9;
                public TTReportField LABELISMIKTAR;
                public TTReportField ISTANIMI;
                public TTReportField ISNITELIK;
                public TTReportField YETKILIMAKAM;
                public TTReportField ISMIKTAR;
                public TTReportField CONFIRMNO;
                public TTReportField LABELISADI;
                public TTReportField BELGETRH_HIDDEN2;
                public TTReportField NewField5;
                public TTReportField NewField8;
                public TTReportField NewField1;
                public TTReportField NewField6;
                public TTReportField NewField10;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField ODENEKTUTARI;
                public TTReportField YATIRIMPROJENO;
                public TTReportField BUTCETERTIBI;
                public TTReportField AVANSSARTLARI;
                public TTReportField IHALEUSUL;
                public TTReportField ILANSEKLI;
                public TTReportField SARTNAMESATISBEDELI;
                public TTReportField DAYANAK;
                public TTReportField NewField22;
                public TTReportField NewField16;
                public TTReportRTF ReportRTF;
                public TTReportField ADVANCED;
                public TTReportField CONFIRMDATEANDNO;
                public TTReportField PRICEDIFFERENCE;
                public TTReportShape NewLine1;
                public TTReportField NewField19; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 191;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 25, 189, 36, false);
                    NewField.Name = "NewField";
                    NewField.FieldType = ReportFieldTypeEnum.ftExpression;
                    NewField.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField.TextFont.Name = "Arial";
                    NewField.TextFont.Size = 11;
                    NewField.TextFont.Bold = true;
                    NewField.Value = @"{#RESPONSIBLEPROCUREMENTUNITDEF#} + "" ONAY BELGESİ""";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 39, 62, 49, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"Doğrudan Temini Yapan İdarenin Adı";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 49, 62, 54, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"Belge Tarih ve Sayısı";

                    RESPONSIBLEPROCUREMENTUNITDEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 39, 189, 49, false);
                    RESPONSIBLEPROCUREMENTUNITDEF.Name = "RESPONSIBLEPROCUREMENTUNITDEF";
                    RESPONSIBLEPROCUREMENTUNITDEF.DrawStyle = DrawStyleConstants.vbSolid;
                    RESPONSIBLEPROCUREMENTUNITDEF.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESPONSIBLEPROCUREMENTUNITDEF.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RESPONSIBLEPROCUREMENTUNITDEF.TextFont.Name = "Arial";
                    RESPONSIBLEPROCUREMENTUNITDEF.Value = @"{#RESPONSIBLEPROCUREMENTUNITDEF#}";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 69, 62, 74, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7.WordBreak = EvetHayirEnum.ehEvet;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Bold = true;
                    NewField7.Value = @"İşin Niteliği";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 59, 189, 64, false);
                    NewField9.Name = "NewField9";
                    NewField9.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField9.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9.TextFont.Name = "Arial";
                    NewField9.TextFont.Bold = true;
                    NewField9.Value = @"DOĞRUDAN TEMİN İLE İLGİLİ BİLGİLER";

                    LABELISMIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 74, 62, 79, false);
                    LABELISMIKTAR.Name = "LABELISMIKTAR";
                    LABELISMIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    LABELISMIKTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABELISMIKTAR.MultiLine = EvetHayirEnum.ehEvet;
                    LABELISMIKTAR.WordBreak = EvetHayirEnum.ehEvet;
                    LABELISMIKTAR.TextFont.Name = "Arial";
                    LABELISMIKTAR.TextFont.Bold = true;
                    LABELISMIKTAR.Value = @"İşin Miktarı";

                    ISTANIMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 64, 189, 69, false);
                    ISTANIMI.Name = "ISTANIMI";
                    ISTANIMI.DrawStyle = DrawStyleConstants.vbSolid;
                    ISTANIMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTANIMI.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ISTANIMI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISTANIMI.TextFont.Name = "Arial";
                    ISTANIMI.Value = @"{#ACTDEFINE#}";

                    ISNITELIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 69, 189, 74, false);
                    ISNITELIK.Name = "ISNITELIK";
                    ISNITELIK.DrawStyle = DrawStyleConstants.vbSolid;
                    ISNITELIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISNITELIK.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ISNITELIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISNITELIK.TextFont.Name = "Arial";
                    ISNITELIK.Value = @"{#ACTATTRIBUTE#}";

                    YETKILIMAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 54, 189, 59, false);
                    YETKILIMAKAM.Name = "YETKILIMAKAM";
                    YETKILIMAKAM.DrawStyle = DrawStyleConstants.vbSolid;
                    YETKILIMAKAM.FieldType = ReportFieldTypeEnum.ftExpression;
                    YETKILIMAKAM.CaseFormat = CaseFormatEnum.fcUpperCase;
                    YETKILIMAKAM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YETKILIMAKAM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YETKILIMAKAM.WordBreak = EvetHayirEnum.ehEvet;
                    YETKILIMAKAM.TextFont.Name = "Arial";
                    YETKILIMAKAM.TextFont.Bold = true;
                    YETKILIMAKAM.Value = @"{#RESPONSIBLEPROCUREMENTUNITDEF#} != """" ? {#RESPONSIBLEPROCUREMENTUNITDEF#} + "" MAKAMINA"" : """"";

                    ISMIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 74, 189, 79, false);
                    ISMIKTAR.Name = "ISMIKTAR";
                    ISMIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    ISMIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISMIKTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISMIKTAR.TextFont.Name = "Arial";
                    ISMIKTAR.Value = @"{#ACTCOUNT#}";

                    CONFIRMNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 43, 242, 48, false);
                    CONFIRMNO.Name = "CONFIRMNO";
                    CONFIRMNO.Visible = EvetHayirEnum.ehHayir;
                    CONFIRMNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONFIRMNO.TextFont.Name = "Arial";
                    CONFIRMNO.Value = @"{#CONFIRMNO#}";

                    LABELISADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 64, 62, 69, false);
                    LABELISADI.Name = "LABELISADI";
                    LABELISADI.DrawStyle = DrawStyleConstants.vbSolid;
                    LABELISADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABELISADI.TextFont.Name = "Arial";
                    LABELISADI.TextFont.Bold = true;
                    LABELISADI.Value = @"İşin Adı";

                    BELGETRH_HIDDEN2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 36, 243, 41, false);
                    BELGETRH_HIDDEN2.Name = "BELGETRH_HIDDEN2";
                    BELGETRH_HIDDEN2.Visible = EvetHayirEnum.ehHayir;
                    BELGETRH_HIDDEN2.FieldType = ReportFieldTypeEnum.ftVariable;
                    BELGETRH_HIDDEN2.TextFormat = @"dd/MM/yyyy";
                    BELGETRH_HIDDEN2.TextFont.Name = "Arial";
                    BELGETRH_HIDDEN2.Value = @"{#CONFIRMDATE#}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 84, 62, 89, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @"Yaklaşık Maliyet";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 89, 62, 94, false);
                    NewField8.Name = "NewField8";
                    NewField8.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField8.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8.TextFont.Name = "Arial";
                    NewField8.TextFont.Bold = true;
                    NewField8.Value = @"Kullanılabilir Ödenek Tutarı";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 94, 62, 99, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"Yatırım Proje Numarası ";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 99, 62, 104, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Bold = true;
                    NewField6.Value = @"Bütçe Tertibi ";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 104, 62, 109, false);
                    NewField10.Name = "NewField10";
                    NewField10.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField10.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField10.MultiLine = EvetHayirEnum.ehEvet;
                    NewField10.WordBreak = EvetHayirEnum.ehEvet;
                    NewField10.TextFont.Name = "Arial";
                    NewField10.TextFont.Bold = true;
                    NewField10.Value = @"Avans Verilecekse Şartları";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 109, 62, 114, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"İhale Usulü";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 114, 62, 119, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"İlanın Şekli ve Adedi";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 119, 62, 129, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @"Doğrudan Temin Dökümanı Satış Bedeli";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 129, 62, 138, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.MultiLine = EvetHayirEnum.ehEvet;
                    NewField15.WordBreak = EvetHayirEnum.ehEvet;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @"Fiyat Farkı Ödenecekse Dayanağı Bakanlar Kurulu Kararı";

                    ODENEKTUTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 89, 189, 94, false);
                    ODENEKTUTARI.Name = "ODENEKTUTARI";
                    ODENEKTUTARI.DrawStyle = DrawStyleConstants.vbSolid;
                    ODENEKTUTARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ODENEKTUTARI.TextFormat = @"#,##0.#0";
                    ODENEKTUTARI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ODENEKTUTARI.TextFont.Name = "Arial";
                    ODENEKTUTARI.Value = @"{#USABLEBUDGETAMOUNT#}";

                    YATIRIMPROJENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 94, 189, 99, false);
                    YATIRIMPROJENO.Name = "YATIRIMPROJENO";
                    YATIRIMPROJENO.DrawStyle = DrawStyleConstants.vbSolid;
                    YATIRIMPROJENO.FieldType = ReportFieldTypeEnum.ftExpression;
                    YATIRIMPROJENO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YATIRIMPROJENO.TextFont.Name = "Arial";
                    YATIRIMPROJENO.Value = @"{#INVESTMENTPROJECTNO#} != """" ? {#INVESTMENTPROJECTNO#} : ""( - )""";

                    BUTCETERTIBI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 99, 189, 104, false);
                    BUTCETERTIBI.Name = "BUTCETERTIBI";
                    BUTCETERTIBI.DrawStyle = DrawStyleConstants.vbSolid;
                    BUTCETERTIBI.FieldType = ReportFieldTypeEnum.ftExpression;
                    BUTCETERTIBI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BUTCETERTIBI.TextFont.Name = "Arial";
                    BUTCETERTIBI.Value = @"{#BUDGETEXPENSEPEN#} != """" ? {#BUDGETEXPENSEPEN#} : ""( - )""";

                    AVANSSARTLARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 104, 189, 109, false);
                    AVANSSARTLARI.Name = "AVANSSARTLARI";
                    AVANSSARTLARI.DrawStyle = DrawStyleConstants.vbSolid;
                    AVANSSARTLARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    AVANSSARTLARI.TextFont.Name = "Arial";
                    AVANSSARTLARI.Value = @"";

                    IHALEUSUL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 109, 189, 114, false);
                    IHALEUSUL.Name = "IHALEUSUL";
                    IHALEUSUL.DrawStyle = DrawStyleConstants.vbSolid;
                    IHALEUSUL.FieldType = ReportFieldTypeEnum.ftVariable;
                    IHALEUSUL.CaseFormat = CaseFormatEnum.fcTitleCase;
                    IHALEUSUL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IHALEUSUL.TextFont.Name = "Arial";
                    IHALEUSUL.Value = @"{#PURCHASETYPEDEFINITION#}";

                    ILANSEKLI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 114, 189, 119, false);
                    ILANSEKLI.Name = "ILANSEKLI";
                    ILANSEKLI.DrawStyle = DrawStyleConstants.vbSolid;
                    ILANSEKLI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ILANSEKLI.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ILANSEKLI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ILANSEKLI.ObjectDefName = "AnnounceTypeandCountEnum";
                    ILANSEKLI.DataMember = "DISPLAYTEXT";
                    ILANSEKLI.TextFont.Name = "Arial";
                    ILANSEKLI.Value = @"{#ANNOUNCETYPEANDCOUNT#}";

                    SARTNAMESATISBEDELI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 119, 189, 129, false);
                    SARTNAMESATISBEDELI.Name = "SARTNAMESATISBEDELI";
                    SARTNAMESATISBEDELI.DrawStyle = DrawStyleConstants.vbSolid;
                    SARTNAMESATISBEDELI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SARTNAMESATISBEDELI.TextFormat = @"#,##0.#0";
                    SARTNAMESATISBEDELI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SARTNAMESATISBEDELI.MultiLine = EvetHayirEnum.ehEvet;
                    SARTNAMESATISBEDELI.TextFont.Name = "Arial";
                    SARTNAMESATISBEDELI.Value = @"{#SPECIFICATIONPRICE#}";

                    DAYANAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 129, 189, 138, false);
                    DAYANAK.Name = "DAYANAK";
                    DAYANAK.DrawStyle = DrawStyleConstants.vbSolid;
                    DAYANAK.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAYANAK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DAYANAK.MultiLine = EvetHayirEnum.ehEvet;
                    DAYANAK.TextFont.Name = "Arial";
                    DAYANAK.Value = @"";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 79, 189, 84, false);
                    NewField22.Name = "NewField22";
                    NewField22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField22.TextFont.Name = "Arial";
                    NewField22.Value = @"";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 138, 189, 143, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Bold = true;
                    NewField16.Value = @"DOĞRUDAN TEMİN İLE İLGİLİ DİĞER AÇIKLAMALAR";

                    ReportRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 5, 143, 189, 182, false);
                    ReportRTF.Name = "ReportRTF";
                    ReportRTF.DrawStyle = DrawStyleConstants.vbSolid;
                    ReportRTF.Value = @"{\rtf1\ansi\ansicpg1254\deff0\deflang1055{\fonttbl{\f0\fnil\fcharset162{\*\fname Courier New;}Courier New TUR;}}
\viewkind4\uc1\pard\f0\fs20 
\par }
";

                    ADVANCED = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 60, 246, 65, false);
                    ADVANCED.Name = "ADVANCED";
                    ADVANCED.Visible = EvetHayirEnum.ehHayir;
                    ADVANCED.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADVANCED.Value = @"{#ADVANCED#}";

                    CONFIRMDATEANDNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 49, 189, 54, false);
                    CONFIRMDATEANDNO.Name = "CONFIRMDATEANDNO";
                    CONFIRMDATEANDNO.DrawStyle = DrawStyleConstants.vbSolid;
                    CONFIRMDATEANDNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONFIRMDATEANDNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONFIRMDATEANDNO.TextFont.Name = "Arial";
                    CONFIRMDATEANDNO.Value = @"{%BELGETRH_HIDDEN2%} / {%CONFIRMNO%}";

                    PRICEDIFFERENCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 68, 246, 73, false);
                    PRICEDIFFERENCE.Name = "PRICEDIFFERENCE";
                    PRICEDIFFERENCE.Visible = EvetHayirEnum.ehHayir;
                    PRICEDIFFERENCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICEDIFFERENCE.TextFont.Name = "Arial Narrow";
                    PRICEDIFFERENCE.TextFont.CharSet = 1;
                    PRICEDIFFERENCE.Value = @"{#PRICEDIFFERENCE#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 189, 84, 189, 89, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 29, 13, 34, false);
                    NewField19.Name = "NewField19";
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.TextFont.Name = "Arial";
                    NewField19.TextFont.Size = 8;
                    NewField19.TextFont.Underline = true;
                    NewField19.Value = @"GİZLİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectGlobalReportNQL_Class dataset_PurchaseProjectGlobalReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>(0);
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    RESPONSIBLEPROCUREMENTUNITDEF.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Responsibleprocurementunitdef) : "");
                    NewField7.CalcValue = NewField7.Value;
                    NewField9.CalcValue = NewField9.Value;
                    LABELISMIKTAR.CalcValue = LABELISMIKTAR.Value;
                    ISTANIMI.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ActDefine) : "");
                    ISNITELIK.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ActAttribute) : "");
                    ISMIKTAR.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ActCount) : "");
                    CONFIRMNO.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ConfirmNO) : "");
                    LABELISADI.CalcValue = LABELISADI.Value;
                    BELGETRH_HIDDEN2.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ConfirmDate) : "");
                    NewField5.CalcValue = NewField5.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    ODENEKTUTARI.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.UsableBudgetAmount) : "");
                    AVANSSARTLARI.CalcValue = @"";
                    IHALEUSUL.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Purchasetypedefinition) : "");
                    ILANSEKLI.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.AnnounceTypeandCount) : "");
                    ILANSEKLI.PostFieldValueCalculation();
                    SARTNAMESATISBEDELI.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.SpecificationPrice) : "");
                    DAYANAK.CalcValue = @"";
                    NewField22.CalcValue = NewField22.Value;
                    NewField16.CalcValue = NewField16.Value;
                    ReportRTF.CalcValue = ReportRTF.Value;
                    ADVANCED.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Advanced) : "");
                    CONFIRMDATEANDNO.CalcValue = MyParentReport.PARTB.BELGETRH_HIDDEN2.FormattedValue + @" / " + MyParentReport.PARTB.CONFIRMNO.CalcValue;
                    PRICEDIFFERENCE.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.PriceDifference) : "");
                    NewField19.CalcValue = NewField19.Value;
                    NewField.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Responsibleprocurementunitdef) : "") + " ONAY BELGESİ";
                    YETKILIMAKAM.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Responsibleprocurementunitdef) : "") != "" ? (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Responsibleprocurementunitdef) : "") + " MAKAMINA" : "";
                    YATIRIMPROJENO.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.InvestmentProjectNO) : "") != "" ? (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.InvestmentProjectNO) : "") : "( - )";
                    BUTCETERTIBI.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.BudgetExpensePen) : "") != "" ? (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.BudgetExpensePen) : "") : "( - )";
                    return new TTReportObject[] { NewField2,NewField3,RESPONSIBLEPROCUREMENTUNITDEF,NewField7,NewField9,LABELISMIKTAR,ISTANIMI,ISNITELIK,ISMIKTAR,CONFIRMNO,LABELISADI,BELGETRH_HIDDEN2,NewField5,NewField8,NewField1,NewField6,NewField10,NewField11,NewField12,NewField14,NewField15,ODENEKTUTARI,AVANSSARTLARI,IHALEUSUL,ILANSEKLI,SARTNAMESATISBEDELI,DAYANAK,NewField22,NewField16,ReportRTF,ADVANCED,CONFIRMDATEANDNO,PRICEDIFFERENCE,NewField19,NewField,YETKILIMAKAM,YATIRIMPROJENO,BUTCETERTIBI};
                }
                public override void RunPreScript()
                {
#region PARTB HEADER_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((OnayBelgesiRaporu)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PurchaseProject purchaseProject = (PurchaseProject)context.GetObject(new Guid(sObjectID),"PurchaseProject");
            if(purchaseProject.ApproveFormDescription != null)
                this.ReportRTF.Value = purchaseProject.ApproveFormDescription.ToString();
#endregion PARTB HEADER_PreScript
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    if (this.ADVANCED.CalcValue == "False")
                this.AVANSSARTLARI.CalcValue = "AVANS VERİLMEYECEKTİR.";
            else
                this.AVANSSARTLARI.CalcValue = "AVANS VERİLECEKTİR.";
            
            if (PRICEDIFFERENCE.CalcValue == "False")
                DAYANAK.CalcValue = "FİYAT FARKI VERİLMEYECEKTİR.";
            else
                DAYANAK.CalcValue = "FİYAT FARKI VERİLECEKTİR.";
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public OnayBelgesiRaporu MyParentReport
                {
                    get { return (OnayBelgesiRaporu)ParentReport; }
                }
                
                public TTReportField DESC;
                public TTReportField NewField5_;
                public TTReportField NewField9_;
                public TTReportField NewField4;
                public TTReportField NewField17;
                public TTReportField EXPENSERDUTY;
                public TTReportField PERFORMERDUTY;
                public TTReportField NewField18;
                public TTReportField NewField171;
                public TTReportField NewField1171;
                public TTReportField EXPENSERRANK;
                public TTReportField PERFORMERRANK;
                public TTReportField PERFORMERTITLE;
                public TTReportField EXPENSERTITLE;
                public TTReportField NewField11711;
                public TTReportField NewField13;
                public TTReportField NewField131;
                public TTReportField NewField132;
                public TTReportField NewField133;
                public TTReportField NewField134;
                public TTReportField NewField1131;
                public TTReportField NewField1231;
                public TTReportField NewField1331; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 46;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    DESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 5, 97, 44, false);
                    DESC.Name = "DESC";
                    DESC.DrawStyle = DrawStyleConstants.vbSolid;
                    DESC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESC.MultiLine = EvetHayirEnum.ehEvet;
                    DESC.WordBreak = EvetHayirEnum.ehEvet;
                    DESC.TextFont.Name = "Arial";
                    DESC.Value = @"Yukarıda belirtilen malın alınması için ihaleye çıkılması hususunu onaylarınıza arz ederim
....../...../..........";

                    NewField5_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 5, 189, 44, false);
                    NewField5_.Name = "NewField5_";
                    NewField5_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5_.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField5_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField5_.MultiLine = EvetHayirEnum.ehEvet;
                    NewField5_.WordBreak = EvetHayirEnum.ehEvet;
                    NewField5_.TextFont.Name = "Arial";
                    NewField5_.Value = @"Uygundur
...../...../...........
Harcama Yetkilisi";

                    NewField9_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 0, 189, 5, false);
                    NewField9_.Name = "NewField9_";
                    NewField9_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField9_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField9_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9_.TextFont.Name = "Arial";
                    NewField9_.Value = @"O  N  A  Y";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 27, 27, 32, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @"Adı SOYADI";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 32, 27, 37, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Bold = true;
                    NewField17.Value = @"Ünvanı";

                    EXPENSERDUTY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 37, 187, 42, false);
                    EXPENSERDUTY.Name = "EXPENSERDUTY";
                    EXPENSERDUTY.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXPENSERDUTY.CaseFormat = CaseFormatEnum.fcTitleCase;
                    EXPENSERDUTY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXPENSERDUTY.TextFont.Name = "Arial";
                    EXPENSERDUTY.Value = @"{#EXPENSERDUTY#}";

                    PERFORMERDUTY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 37, 96, 42, false);
                    PERFORMERDUTY.Name = "PERFORMERDUTY";
                    PERFORMERDUTY.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERFORMERDUTY.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PERFORMERDUTY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PERFORMERDUTY.TextFont.Name = "Arial";
                    PERFORMERDUTY.Value = @"{#PERFORMERDUTY#}";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 27, 119, 32, false);
                    NewField18.Name = "NewField18";
                    NewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18.TextFont.Name = "Arial";
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @"Adı SOYADI";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 32, 119, 37, false);
                    NewField171.Name = "NewField171";
                    NewField171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField171.TextFont.Name = "Arial";
                    NewField171.TextFont.Bold = true;
                    NewField171.Value = @"Ünvanı";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 21, 119, 26, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1171.TextFont.Name = "Arial";
                    NewField1171.TextFont.Bold = true;
                    NewField1171.Value = @"İmzası";

                    EXPENSERRANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 32, 187, 37, false);
                    EXPENSERRANK.Name = "EXPENSERRANK";
                    EXPENSERRANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXPENSERRANK.CaseFormat = CaseFormatEnum.fcTitleCase;
                    EXPENSERRANK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXPENSERRANK.ObjectDefName = "ResUser";
                    EXPENSERRANK.DataMember = "RANK.NAME";
                    EXPENSERRANK.TextFont.Name = "Arial";
                    EXPENSERRANK.Value = @"{#EXPENSERID#}";

                    PERFORMERRANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 32, 96, 37, false);
                    PERFORMERRANK.Name = "PERFORMERRANK";
                    PERFORMERRANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERFORMERRANK.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PERFORMERRANK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PERFORMERRANK.ObjectDefName = "ResUser";
                    PERFORMERRANK.DataMember = "RANK.NAME";
                    PERFORMERRANK.TextFont.Name = "Arial";
                    PERFORMERRANK.Value = @"{#PERFORMERID#}";

                    PERFORMERTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 27, 96, 32, false);
                    PERFORMERTITLE.Name = "PERFORMERTITLE";
                    PERFORMERTITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERFORMERTITLE.CaseFormat = CaseFormatEnum.fcNameSurname;
                    PERFORMERTITLE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PERFORMERTITLE.TextFont.Name = "Arial";
                    PERFORMERTITLE.Value = @"{#PERFORMER#}";

                    EXPENSERTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 27, 187, 32, false);
                    EXPENSERTITLE.Name = "EXPENSERTITLE";
                    EXPENSERTITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXPENSERTITLE.CaseFormat = CaseFormatEnum.fcNameSurname;
                    EXPENSERTITLE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXPENSERTITLE.TextFont.Name = "Arial";
                    EXPENSERTITLE.Value = @"{#EXPENSER#}";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 21, 27, 26, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11711.TextFont.Name = "Arial";
                    NewField11711.TextFont.Bold = true;
                    NewField11711.Value = @"İmzası";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 27, 28, 32, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @":";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 21, 28, 26, false);
                    NewField131.Name = "NewField131";
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Bold = true;
                    NewField131.Value = @":";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 32, 28, 37, false);
                    NewField132.Name = "NewField132";
                    NewField132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField132.TextFont.Name = "Arial";
                    NewField132.TextFont.Bold = true;
                    NewField132.Value = @":";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 37, 28, 42, false);
                    NewField133.Name = "NewField133";
                    NewField133.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField133.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField133.TextFont.Name = "Arial";
                    NewField133.TextFont.Bold = true;
                    NewField133.Value = @":";

                    NewField134 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 27, 120, 32, false);
                    NewField134.Name = "NewField134";
                    NewField134.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField134.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField134.TextFont.Name = "Arial";
                    NewField134.TextFont.Bold = true;
                    NewField134.Value = @":";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 21, 120, 26, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Bold = true;
                    NewField1131.Value = @":";

                    NewField1231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 32, 120, 37, false);
                    NewField1231.Name = "NewField1231";
                    NewField1231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1231.TextFont.Name = "Arial";
                    NewField1231.TextFont.Bold = true;
                    NewField1231.Value = @":";

                    NewField1331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 37, 120, 42, false);
                    NewField1331.Name = "NewField1331";
                    NewField1331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1331.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1331.TextFont.Name = "Arial";
                    NewField1331.TextFont.Bold = true;
                    NewField1331.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectGlobalReportNQL_Class dataset_PurchaseProjectGlobalReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>(0);
                    DESC.CalcValue = DESC.Value;
                    NewField5_.CalcValue = NewField5_.Value;
                    NewField9_.CalcValue = NewField9_.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField17.CalcValue = NewField17.Value;
                    EXPENSERDUTY.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ExpenserDuty) : "");
                    PERFORMERDUTY.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.PerformerDuty) : "");
                    NewField18.CalcValue = NewField18.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    EXPENSERRANK.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Expenserid) : "");
                    EXPENSERRANK.PostFieldValueCalculation();
                    PERFORMERRANK.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Performerid) : "");
                    PERFORMERRANK.PostFieldValueCalculation();
                    PERFORMERTITLE.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Performer) : "");
                    EXPENSERTITLE.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Expenser) : "");
                    NewField11711.CalcValue = NewField11711.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField133.CalcValue = NewField133.Value;
                    NewField134.CalcValue = NewField134.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1231.CalcValue = NewField1231.Value;
                    NewField1331.CalcValue = NewField1331.Value;
                    return new TTReportObject[] { DESC,NewField5_,NewField9_,NewField4,NewField17,EXPENSERDUTY,PERFORMERDUTY,NewField18,NewField171,NewField1171,EXPENSERRANK,PERFORMERRANK,PERFORMERTITLE,EXPENSERTITLE,NewField11711,NewField13,NewField131,NewField132,NewField133,NewField134,NewField1131,NewField1231,NewField1331};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public OnayBelgesiRaporu MyParentReport
            {
                get { return (OnayBelgesiRaporu)ParentReport; }
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
                public OnayBelgesiRaporu MyParentReport
                {
                    get { return (OnayBelgesiRaporu)ParentReport; }
                }
                 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 1;
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

        public OnayBelgesiRaporu()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
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
            Name = "ONAYBELGESIRAPORU";
            Caption = "Onay Belgesi Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 15;
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