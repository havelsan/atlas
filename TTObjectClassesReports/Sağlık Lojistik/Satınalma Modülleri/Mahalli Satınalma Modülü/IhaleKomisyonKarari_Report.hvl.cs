
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
    /// İhale Komisyon Kararı
    /// </summary>
    public partial class IhaleKomisyonKarari : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public IhaleKomisyonKarari MyParentReport
            {
                get { return (IhaleKomisyonKarari)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField IHALEKAYITNO { get {return Header().IHALEKAYITNO;} }
            public TTReportField IDAREADI { get {return Header().IDAREADI;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField ISINADI { get {return Header().ISINADI;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField PURCHASETYPEDEFINITION { get {return Header().PURCHASETYPEDEFINITION;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField TOTALPROPOSALCOUNT { get {return Header().TOTALPROPOSALCOUNT;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField20 { get {return Header().NewField20;} }
            public TTReportField ELIGIBLEPROPOSALCOUNT { get {return Header().ELIGIBLEPROPOSALCOUNT;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField BESTSUPPLIER { get {return Header().BESTSUPPLIER;} }
            public TTReportField NewField23 { get {return Header().NewField23;} }
            public TTReportField NewField24 { get {return Header().NewField24;} }
            public TTReportField BESTPRICE { get {return Header().BESTPRICE;} }
            public TTReportField NewField25 { get {return Header().NewField25;} }
            public TTReportField DATE1 { get {return Header().DATE1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField152 { get {return Header().NewField152;} }
            public TTReportField TENDERDATE { get {return Header().TENDERDATE;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField ReportName { get {return Header().ReportName;} }
            public TTReportField NewField113 { get {return Header().NewField113;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField SECONDSUPPLIER { get {return Header().SECONDSUPPLIER;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField SECONDPRICE { get {return Header().SECONDPRICE;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField NewField9_1 { get {return Header().NewField9_1;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField TIME { get {return Header().TIME;} }
            public TTReportField CONCLUSIONNO { get {return Header().CONCLUSIONNO;} }
            public TTReportField SUPPLIER11 { get {return Footer().SUPPLIER11;} }
            public TTReportField KATITEMINATMIKTARI { get {return Footer().KATITEMINATMIKTARI;} }
            public TTReportField SUPPLIER111 { get {return Footer().SUPPLIER111;} }
            public TTReportField KARARPULUMIKTARI { get {return Footer().KARARPULUMIKTARI;} }
            public TTReportField SUPPLIER121 { get {return Footer().SUPPLIER121;} }
            public TTReportField SOZLESMEPULUMIKTARI { get {return Footer().SOZLESMEPULUMIKTARI;} }
            public TTReportField SUPPLIER131 { get {return Footer().SUPPLIER131;} }
            public TTReportField KIKBEDELI { get {return Footer().KIKBEDELI;} }
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
                list[0] = new TTReportNqlData<PurchaseProject.GetTenderCommisionDesicionQuery_Class>("GetTenderCommisionDesicionQuery", PurchaseProject.GetTenderCommisionDesicionQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public IhaleKomisyonKarari MyParentReport
                {
                    get { return (IhaleKomisyonKarari)ParentReport; }
                }
                
                public TTReportField NewField2;
                public TTReportField NewField;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField IHALEKAYITNO;
                public TTReportField IDAREADI;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField ISINADI;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField PURCHASETYPEDEFINITION;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField TOTALPROPOSALCOUNT;
                public TTReportField NewField19;
                public TTReportField NewField20;
                public TTReportField ELIGIBLEPROPOSALCOUNT;
                public TTReportField NewField21;
                public TTReportField NewField22;
                public TTReportField BESTSUPPLIER;
                public TTReportField NewField23;
                public TTReportField NewField24;
                public TTReportField BESTPRICE;
                public TTReportField NewField25;
                public TTReportField DATE1;
                public TTReportField NewField11;
                public TTReportField NewField152;
                public TTReportField TENDERDATE;
                public TTReportField NewField111;
                public TTReportField NewField112;
                public TTReportField ReportName;
                public TTReportField NewField113;
                public TTReportField NewField122;
                public TTReportField SECONDSUPPLIER;
                public TTReportField NewField132;
                public TTReportField NewField142;
                public TTReportField SECONDPRICE;
                public TTReportField NewField1211;
                public TTReportField NewField9_1;
                public TTReportField DATE;
                public TTReportField TIME;
                public TTReportField CONCLUSIONNO; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 108;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 11, 39, 16, false);
                    NewField2.Name = "NewField2";
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"İhale Kayıt Numarası";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 11, 40, 16, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField.TextFont.Name = "Arial";
                    NewField.TextFont.Bold = true;
                    NewField.Value = @":";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 16, 39, 21, false);
                    NewField3.Name = "NewField3";
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"İdarenin Adı";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 16, 40, 21, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @":";

                    IHALEKAYITNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 11, 170, 16, false);
                    IHALEKAYITNO.Name = "IHALEKAYITNO";
                    IHALEKAYITNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    IHALEKAYITNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IHALEKAYITNO.TextFont.Name = "Arial";
                    IHALEKAYITNO.Value = @"{#KIKTENDERREGISTERNO#}";

                    IDAREADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 16, 170, 21, false);
                    IDAREADI.Name = "IDAREADI";
                    IDAREADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    IDAREADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IDAREADI.TextFont.Name = "Arial";
                    IDAREADI.Value = @"{#RESPONSIBLEPROCUREMENTUNITDEF#}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 21, 39, 26, false);
                    NewField5.Name = "NewField5";
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @"İşin Adı";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 21, 40, 26, false);
                    NewField6.Name = "NewField6";
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Bold = true;
                    NewField6.Value = @":";

                    ISINADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 21, 170, 26, false);
                    ISINADI.Name = "ISINADI";
                    ISINADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISINADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISINADI.TextFont.Name = "Arial";
                    ISINADI.Value = @"{#ACTDEFINE#}";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 31, 39, 36, false);
                    NewField15.Name = "NewField15";
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @"İhale Usulü";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 31, 40, 36, false);
                    NewField16.Name = "NewField16";
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Bold = true;
                    NewField16.Value = @":";

                    PURCHASETYPEDEFINITION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 31, 170, 36, false);
                    PURCHASETYPEDEFINITION.Name = "PURCHASETYPEDEFINITION";
                    PURCHASETYPEDEFINITION.FieldType = ReportFieldTypeEnum.ftVariable;
                    PURCHASETYPEDEFINITION.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PURCHASETYPEDEFINITION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PURCHASETYPEDEFINITION.TextFont.Name = "Arial";
                    PURCHASETYPEDEFINITION.Value = @"{#PURCHASETYPENAME#}";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 36, 39, 41, false);
                    NewField17.Name = "NewField17";
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Bold = true;
                    NewField17.Value = @"Toplam Teklif Sayısı";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 36, 40, 41, false);
                    NewField18.Name = "NewField18";
                    NewField18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18.TextFont.Name = "Arial";
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @":";

                    TOTALPROPOSALCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 36, 170, 41, false);
                    TOTALPROPOSALCOUNT.Name = "TOTALPROPOSALCOUNT";
                    TOTALPROPOSALCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPROPOSALCOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALPROPOSALCOUNT.TextFont.Name = "Arial";
                    TOTALPROPOSALCOUNT.Value = @"";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 41, 39, 46, false);
                    NewField19.Name = "NewField19";
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.TextFont.Name = "Arial";
                    NewField19.TextFont.Bold = true;
                    NewField19.Value = @"Geçerli Teklif Sayısı";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 41, 40, 46, false);
                    NewField20.Name = "NewField20";
                    NewField20.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField20.TextFont.Name = "Arial";
                    NewField20.TextFont.Bold = true;
                    NewField20.Value = @":";

                    ELIGIBLEPROPOSALCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 41, 170, 46, false);
                    ELIGIBLEPROPOSALCOUNT.Name = "ELIGIBLEPROPOSALCOUNT";
                    ELIGIBLEPROPOSALCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ELIGIBLEPROPOSALCOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ELIGIBLEPROPOSALCOUNT.TextFont.Name = "Arial";
                    ELIGIBLEPROPOSALCOUNT.Value = @"";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 56, 51, 61, false);
                    NewField21.Name = "NewField21";
                    NewField21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21.TextFont.Name = "Arial";
                    NewField21.Value = @"a) Sahibinin Adı/Ticaret Ünvanı";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 56, 52, 61, false);
                    NewField22.Name = "NewField22";
                    NewField22.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField22.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField22.TextFont.Name = "Arial";
                    NewField22.Value = @":";

                    BESTSUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 56, 170, 61, false);
                    BESTSUPPLIER.Name = "BESTSUPPLIER";
                    BESTSUPPLIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    BESTSUPPLIER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BESTSUPPLIER.WordBreak = EvetHayirEnum.ehEvet;
                    BESTSUPPLIER.TextFont.Name = "Arial";
                    BESTSUPPLIER.Value = @"";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 61, 51, 66, false);
                    NewField23.Name = "NewField23";
                    NewField23.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField23.TextFont.Name = "Arial";
                    NewField23.Value = @"b) Tutarı";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 61, 52, 66, false);
                    NewField24.Name = "NewField24";
                    NewField24.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField24.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField24.TextFont.Name = "Arial";
                    NewField24.Value = @":";

                    BESTPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 61, 170, 66, false);
                    BESTPRICE.Name = "BESTPRICE";
                    BESTPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BESTPRICE.TextFormat = @"#,##0.#0";
                    BESTPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BESTPRICE.TextFont.Name = "Arial";
                    BESTPRICE.Value = @"";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 91, 61, 96, false);
                    NewField25.Name = "NewField25";
                    NewField25.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField25.TextFont.Name = "Arial";
                    NewField25.Value = @"Bu tutanağın düzenlendiği tarih ve saat";

                    DATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 91, 170, 96, false);
                    DATE1.Name = "DATE1";
                    DATE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATE1.TextFont.Name = "Arial";
                    DATE1.Value = @"_ _/_ _/_ _ _ _ ................. günü, saat _ _:_ _";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 91, 62, 96, false);
                    NewField11.Name = "NewField11";
                    NewField11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.Value = @":";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 26, 39, 31, false);
                    NewField152.Name = "NewField152";
                    NewField152.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField152.MultiLine = EvetHayirEnum.ehEvet;
                    NewField152.WordBreak = EvetHayirEnum.ehEvet;
                    NewField152.TextFont.Name = "Arial";
                    NewField152.TextFont.Bold = true;
                    NewField152.Value = @"İhale Tarih ve Saati";

                    TENDERDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 26, 170, 31, false);
                    TENDERDATE.Name = "TENDERDATE";
                    TENDERDATE.FieldType = ReportFieldTypeEnum.ftExpression;
                    TENDERDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TENDERDATE.TextFont.Name = "Arial";
                    TENDERDATE.Value = @"DATE.FormattedValue + "" günü, saat "" + TIME.FormattedValue";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 26, 40, 31, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @":";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 51, 170, 56, false);
                    NewField112.Name = "NewField112";
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.Name = "Arial";
                    NewField112.TextFont.Underline = true;
                    NewField112.Value = @"Ekonomik Açıdan En Avantajlı Teklifin";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 170, 6, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Name = "Arial";
                    ReportName.TextFont.Size = 12;
                    ReportName.TextFont.Bold = true;
                    ReportName.Value = @"İHALE KOMİSYON KARARI";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 76, 51, 81, false);
                    NewField113.Name = "NewField113";
                    NewField113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113.TextFont.Name = "Arial";
                    NewField113.Value = @"a) Sahibinin Adı/Ticaret Ünvanı";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 76, 52, 81, false);
                    NewField122.Name = "NewField122";
                    NewField122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Name = "Arial";
                    NewField122.Value = @":";

                    SECONDSUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 76, 170, 81, false);
                    SECONDSUPPLIER.Name = "SECONDSUPPLIER";
                    SECONDSUPPLIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SECONDSUPPLIER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SECONDSUPPLIER.WordBreak = EvetHayirEnum.ehEvet;
                    SECONDSUPPLIER.TextFont.Name = "Arial";
                    SECONDSUPPLIER.Value = @"";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 81, 51, 86, false);
                    NewField132.Name = "NewField132";
                    NewField132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField132.TextFont.Name = "Arial";
                    NewField132.Value = @"b) Tutarı";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 81, 52, 86, false);
                    NewField142.Name = "NewField142";
                    NewField142.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField142.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField142.TextFont.Name = "Arial";
                    NewField142.Value = @":";

                    SECONDPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 81, 170, 86, false);
                    SECONDPRICE.Name = "SECONDPRICE";
                    SECONDPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SECONDPRICE.TextFormat = @"#,##0.#0";
                    SECONDPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SECONDPRICE.TextFont.Name = "Arial";
                    SECONDPRICE.Value = @"";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 71, 170, 76, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211.TextFont.Name = "Arial";
                    NewField1211.TextFont.Underline = true;
                    NewField1211.Value = @"Ekonomik Açıdan En Avantajlı İkinci Teklifin";

                    NewField9_1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 101, 170, 106, false);
                    NewField9_1.Name = "NewField9_1";
                    NewField9_1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField9_1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9_1.TextFont.Name = "Arial";
                    NewField9_1.TextFont.Size = 11;
                    NewField9_1.TextFont.Bold = true;
                    NewField9_1.Value = @"İsteklilerin Teklif Ettiği Bedeller";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 20, 241, 25, false);
                    DATE.Name = "DATE";
                    DATE.Visible = EvetHayirEnum.ehHayir;
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"Long Date";
                    DATE.TextFont.Name = "Arial Narrow";
                    DATE.TextFont.CharSet = 1;
                    DATE.Value = @"{#TENDERDATE#}";

                    TIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 29, 241, 34, false);
                    TIME.Name = "TIME";
                    TIME.Visible = EvetHayirEnum.ehHayir;
                    TIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    TIME.TextFormat = @"Short Time";
                    TIME.TextFont.Name = "Arial Narrow";
                    TIME.TextFont.CharSet = 1;
                    TIME.Value = @"{#TENDERDATE#}";

                    CONCLUSIONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 39, 241, 44, false);
                    CONCLUSIONNO.Name = "CONCLUSIONNO";
                    CONCLUSIONNO.Visible = EvetHayirEnum.ehHayir;
                    CONCLUSIONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONCLUSIONNO.TextFont.Name = "Arial Narrow";
                    CONCLUSIONNO.TextFont.CharSet = 1;
                    CONCLUSIONNO.Value = @"{#CONCLUSIONNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.GetTenderCommisionDesicionQuery_Class dataset_GetTenderCommisionDesicionQuery = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.GetTenderCommisionDesicionQuery_Class>(0);
                    NewField2.CalcValue = NewField2.Value;
                    NewField.CalcValue = NewField.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    IHALEKAYITNO.CalcValue = (dataset_GetTenderCommisionDesicionQuery != null ? Globals.ToStringCore(dataset_GetTenderCommisionDesicionQuery.KIKTenderRegisterNO) : "");
                    IDAREADI.CalcValue = (dataset_GetTenderCommisionDesicionQuery != null ? Globals.ToStringCore(dataset_GetTenderCommisionDesicionQuery.Responsibleprocurementunitdef) : "");
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    ISINADI.CalcValue = (dataset_GetTenderCommisionDesicionQuery != null ? Globals.ToStringCore(dataset_GetTenderCommisionDesicionQuery.ActDefine) : "");
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    PURCHASETYPEDEFINITION.CalcValue = (dataset_GetTenderCommisionDesicionQuery != null ? Globals.ToStringCore(dataset_GetTenderCommisionDesicionQuery.PurchaseTypeName) : "");
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    TOTALPROPOSALCOUNT.CalcValue = @"";
                    NewField19.CalcValue = NewField19.Value;
                    NewField20.CalcValue = NewField20.Value;
                    ELIGIBLEPROPOSALCOUNT.CalcValue = @"";
                    NewField21.CalcValue = NewField21.Value;
                    NewField22.CalcValue = NewField22.Value;
                    BESTSUPPLIER.CalcValue = @"";
                    NewField23.CalcValue = NewField23.Value;
                    NewField24.CalcValue = NewField24.Value;
                    BESTPRICE.CalcValue = @"";
                    NewField25.CalcValue = NewField25.Value;
                    DATE1.CalcValue = DATE1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField152.CalcValue = NewField152.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField112.CalcValue = NewField112.Value;
                    ReportName.CalcValue = ReportName.Value;
                    NewField113.CalcValue = NewField113.Value;
                    NewField122.CalcValue = NewField122.Value;
                    SECONDSUPPLIER.CalcValue = @"";
                    NewField132.CalcValue = NewField132.Value;
                    NewField142.CalcValue = NewField142.Value;
                    SECONDPRICE.CalcValue = @"";
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField9_1.CalcValue = NewField9_1.Value;
                    DATE.CalcValue = (dataset_GetTenderCommisionDesicionQuery != null ? Globals.ToStringCore(dataset_GetTenderCommisionDesicionQuery.TenderDate) : "");
                    TIME.CalcValue = (dataset_GetTenderCommisionDesicionQuery != null ? Globals.ToStringCore(dataset_GetTenderCommisionDesicionQuery.TenderDate) : "");
                    CONCLUSIONNO.CalcValue = (dataset_GetTenderCommisionDesicionQuery != null ? Globals.ToStringCore(dataset_GetTenderCommisionDesicionQuery.ConclusionNO) : "");
                    TENDERDATE.CalcValue = DATE.FormattedValue + " günü, saat " + TIME.FormattedValue;
                    return new TTReportObject[] { NewField2,NewField,NewField3,NewField4,IHALEKAYITNO,IDAREADI,NewField5,NewField6,ISINADI,NewField15,NewField16,PURCHASETYPEDEFINITION,NewField17,NewField18,TOTALPROPOSALCOUNT,NewField19,NewField20,ELIGIBLEPROPOSALCOUNT,NewField21,NewField22,BESTSUPPLIER,NewField23,NewField24,BESTPRICE,NewField25,DATE1,NewField11,NewField152,NewField111,NewField112,ReportName,NewField113,NewField122,SECONDSUPPLIER,NewField132,NewField142,SECONDPRICE,NewField1211,NewField9_1,DATE,TIME,CONCLUSIONNO,TENDERDATE};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    string objectID = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
            PurchaseProject purchaseProject = (PurchaseProject)MyParentReport.ReportObjectContext.GetObject(new Guid(objectID), typeof(PurchaseProject));
            
//            TOTALPROPOSALCOUNT.CalcValue = Convert.ToString(purchaseProject.GetTotalProposalCount(true));
//            ELIGIBLEPROPOSALCOUNT.CalcValue = Convert.ToString(purchaseProject.GetTotalProposalCount(false));
//            
//            ArrayList arrayList = purchaseProject.GetBestAndSecondProposalsBySupplierTotalProposalPrice(CONCLUSIONNO.CalcValue);
//            BESTSUPPLIER.CalcValue = ((Supplier)arrayList[0]).Name;
//            BESTPRICE.CalcValue = arrayList[1].ToString();
//            if (arrayList[3].ToString() != "-1")
//            {
//                SECONDSUPPLIER.CalcValue = ((Supplier)arrayList[2]).Name;
//                SECONDPRICE.CalcValue = arrayList[3].ToString();
//            }
//            PARTBGroup.totalContractValue = Convert.ToDouble(arrayList[4]);
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public IhaleKomisyonKarari MyParentReport
                {
                    get { return (IhaleKomisyonKarari)ParentReport; }
                }
                
                public TTReportField SUPPLIER11;
                public TTReportField KATITEMINATMIKTARI;
                public TTReportField SUPPLIER111;
                public TTReportField KARARPULUMIKTARI;
                public TTReportField SUPPLIER121;
                public TTReportField SOZLESMEPULUMIKTARI;
                public TTReportField SUPPLIER131;
                public TTReportField KIKBEDELI; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 35;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    SUPPLIER11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 5, false);
                    SUPPLIER11.Name = "SUPPLIER11";
                    SUPPLIER11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER11.NoClip = EvetHayirEnum.ehEvet;
                    SUPPLIER11.TextFont.Name = "Arial";
                    SUPPLIER11.TextFont.Size = 9;
                    SUPPLIER11.Value = @"KATİ TEMİNAT MİKTARI";

                    KATITEMINATMIKTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 0, 98, 5, false);
                    KATITEMINATMIKTARI.Name = "KATITEMINATMIKTARI";
                    KATITEMINATMIKTARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KATITEMINATMIKTARI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KATITEMINATMIKTARI.TextFont.Name = "Arial";
                    KATITEMINATMIKTARI.TextFont.Size = 9;
                    KATITEMINATMIKTARI.Value = @"";

                    SUPPLIER111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 40, 10, false);
                    SUPPLIER111.Name = "SUPPLIER111";
                    SUPPLIER111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER111.NoClip = EvetHayirEnum.ehEvet;
                    SUPPLIER111.TextFont.Name = "Arial";
                    SUPPLIER111.TextFont.Size = 9;
                    SUPPLIER111.Value = @"KARAR PULU MİKTARI";

                    KARARPULUMIKTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 5, 98, 10, false);
                    KARARPULUMIKTARI.Name = "KARARPULUMIKTARI";
                    KARARPULUMIKTARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARARPULUMIKTARI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KARARPULUMIKTARI.MultiLine = EvetHayirEnum.ehEvet;
                    KARARPULUMIKTARI.WordBreak = EvetHayirEnum.ehEvet;
                    KARARPULUMIKTARI.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARARPULUMIKTARI.TextFont.Name = "Arial";
                    KARARPULUMIKTARI.TextFont.Size = 9;
                    KARARPULUMIKTARI.Value = @"";

                    SUPPLIER121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 10, 40, 15, false);
                    SUPPLIER121.Name = "SUPPLIER121";
                    SUPPLIER121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER121.NoClip = EvetHayirEnum.ehEvet;
                    SUPPLIER121.TextFont.Name = "Arial";
                    SUPPLIER121.TextFont.Size = 9;
                    SUPPLIER121.Value = @"SÖZLEŞME PULU MİKTARI";

                    SOZLESMEPULUMIKTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 10, 98, 15, false);
                    SOZLESMEPULUMIKTARI.Name = "SOZLESMEPULUMIKTARI";
                    SOZLESMEPULUMIKTARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOZLESMEPULUMIKTARI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SOZLESMEPULUMIKTARI.MultiLine = EvetHayirEnum.ehEvet;
                    SOZLESMEPULUMIKTARI.WordBreak = EvetHayirEnum.ehEvet;
                    SOZLESMEPULUMIKTARI.ExpandTabs = EvetHayirEnum.ehEvet;
                    SOZLESMEPULUMIKTARI.TextFont.Name = "Arial";
                    SOZLESMEPULUMIKTARI.TextFont.Size = 9;
                    SOZLESMEPULUMIKTARI.Value = @"";

                    SUPPLIER131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 40, 20, false);
                    SUPPLIER131.Name = "SUPPLIER131";
                    SUPPLIER131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER131.NoClip = EvetHayirEnum.ehEvet;
                    SUPPLIER131.TextFont.Name = "Arial";
                    SUPPLIER131.TextFont.Size = 9;
                    SUPPLIER131.Value = @"KİK BEDELİ";

                    KIKBEDELI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 15, 98, 20, false);
                    KIKBEDELI.Name = "KIKBEDELI";
                    KIKBEDELI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIKBEDELI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KIKBEDELI.MultiLine = EvetHayirEnum.ehEvet;
                    KIKBEDELI.WordBreak = EvetHayirEnum.ehEvet;
                    KIKBEDELI.ExpandTabs = EvetHayirEnum.ehEvet;
                    KIKBEDELI.TextFont.Name = "Arial";
                    KIKBEDELI.TextFont.Size = 9;
                    KIKBEDELI.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.GetTenderCommisionDesicionQuery_Class dataset_GetTenderCommisionDesicionQuery = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.GetTenderCommisionDesicionQuery_Class>(0);
                    SUPPLIER11.CalcValue = SUPPLIER11.Value;
                    KATITEMINATMIKTARI.CalcValue = @"";
                    SUPPLIER111.CalcValue = SUPPLIER111.Value;
                    KARARPULUMIKTARI.CalcValue = @"";
                    SUPPLIER121.CalcValue = SUPPLIER121.Value;
                    SOZLESMEPULUMIKTARI.CalcValue = @"";
                    SUPPLIER131.CalcValue = SUPPLIER131.Value;
                    KIKBEDELI.CalcValue = @"";
                    return new TTReportObject[] { SUPPLIER11,KATITEMINATMIKTARI,SUPPLIER111,KARARPULUMIKTARI,SUPPLIER121,SOZLESMEPULUMIKTARI,SUPPLIER131,KIKBEDELI};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    double ContractValue = PARTBGroup.totalContractValue;
            double PPKatiTeminatOrani = Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("PPKatiTeminatOrani", ""));
            double PPSozlesmePuluOrani = Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("PPSozlesmePuluOrani", ""));
            double PPKararPuluOrani = Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("PPKararPuluOrani", ""));
            KIKBEDELI.CalcValue = ContractValue.ToString();
            KATITEMINATMIKTARI.CalcValue = (ContractValue * PPKatiTeminatOrani).ToString();
            KARARPULUMIKTARI.CalcValue = (ContractValue * PPKararPuluOrani).ToString();
            SOZLESMEPULUMIKTARI.CalcValue = (ContractValue * PPSozlesmePuluOrani).ToString();
#endregion PARTB FOOTER_Script
                }
            }

#region PARTB_Methods
            public static double totalContractValue = 0;
#endregion PARTB_Methods
        }

        public PARTBGroup PARTB;

        public partial class PARTFGroup : TTReportGroup
        {
            public IhaleKomisyonKarari MyParentReport
            {
                get { return (IhaleKomisyonKarari)ParentReport; }
            }

            new public PARTFGroupHeader Header()
            {
                return (PARTFGroupHeader)_header;
            }

            new public PARTFGroupFooter Footer()
            {
                return (PARTFGroupFooter)_footer;
            }

            public TTReportField NewField7_ { get {return Header().NewField7_;} }
            public TTReportField NewField6_ { get {return Header().NewField6_;} }
            public TTReportField NewField7_1 { get {return Header().NewField7_1;} }
            public TTReportField NewField6_1 { get {return Header().NewField6_1;} }
            public PARTFGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTFGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTFGroupHeader(this);
                _footer = new PARTFGroupFooter(this);

            }

            public partial class PARTFGroupHeader : TTReportSection
            {
                public IhaleKomisyonKarari MyParentReport
                {
                    get { return (IhaleKomisyonKarari)ParentReport; }
                }
                
                public TTReportField NewField7_;
                public TTReportField NewField6_;
                public TTReportField NewField7_1;
                public TTReportField NewField6_1; 
                public PARTFGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField7_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 62, 9, false);
                    NewField7_.Name = "NewField7_";
                    NewField7_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7_.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7_.WordBreak = EvetHayirEnum.ehEvet;
                    NewField7_.TextFont.Name = "Arial";
                    NewField7_.TextFont.Bold = true;
                    NewField7_.Value = @"İsteklinin Adı";

                    NewField6_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 0, 85, 9, false);
                    NewField6_.Name = "NewField6_";
                    NewField6_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6_.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField6_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6_.MultiLine = EvetHayirEnum.ehEvet;
                    NewField6_.WordBreak = EvetHayirEnum.ehEvet;
                    NewField6_.TextFont.Name = "Arial";
                    NewField6_.TextFont.Bold = true;
                    NewField6_.Value = @"Teklif Ettiği Bedel";

                    NewField7_1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 0, 147, 9, false);
                    NewField7_1.Name = "NewField7_1";
                    NewField7_1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7_1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField7_1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7_1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7_1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7_1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField7_1.TextFont.Name = "Arial";
                    NewField7_1.TextFont.Bold = true;
                    NewField7_1.Value = @"İsteklinin Adı";

                    NewField6_1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 0, 170, 9, false);
                    NewField6_1.Name = "NewField6_1";
                    NewField6_1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6_1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField6_1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6_1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6_1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField6_1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField6_1.TextFont.Name = "Arial";
                    NewField6_1.TextFont.Bold = true;
                    NewField6_1.Value = @"Teklif Ettiği Bedel";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField7_.CalcValue = NewField7_.Value;
                    NewField6_.CalcValue = NewField6_.Value;
                    NewField7_1.CalcValue = NewField7_1.Value;
                    NewField6_1.CalcValue = NewField6_1.Value;
                    return new TTReportObject[] { NewField7_,NewField6_,NewField7_1,NewField6_1};
                }
            }
            public partial class PARTFGroupFooter : TTReportSection
            {
                public IhaleKomisyonKarari MyParentReport
                {
                    get { return (IhaleKomisyonKarari)ParentReport; }
                }
                 
                public PARTFGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTFGroup PARTF;

        public partial class PARTEGroup : TTReportGroup
        {
            public IhaleKomisyonKarari MyParentReport
            {
                get { return (IhaleKomisyonKarari)ParentReport; }
            }

            new public PARTEGroupBody Body()
            {
                return (PARTEGroupBody)_body;
            }
            public TTReportField SUPPLIER { get {return Body().SUPPLIER;} }
            public TTReportField TOTALPROPOSALPRICE { get {return Body().TOTALPROPOSALPRICE;} }
            public PARTEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ProposalDetail.GetProposalledTotalPrices_Class>("GetProposalledTotalPrices", ProposalDetail.GetProposalledTotalPrices((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTEGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTEGroupBody : TTReportSection
            {
                public IhaleKomisyonKarari MyParentReport
                {
                    get { return (IhaleKomisyonKarari)ParentReport; }
                }
                
                public TTReportField SUPPLIER;
                public TTReportField TOTALPROPOSALPRICE; 
                public PARTEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 2;
                    RepeatWidth = 85;
                    
                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 62, 5, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.DrawStyle = DrawStyleConstants.vbSolid;
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER.WordBreak = EvetHayirEnum.ehEvet;
                    SUPPLIER.TextFont.Name = "Arial";
                    SUPPLIER.Value = @"{#SUPPLIER#}";

                    TOTALPROPOSALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 0, 85, 5, false);
                    TOTALPROPOSALPRICE.Name = "TOTALPROPOSALPRICE";
                    TOTALPROPOSALPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALPROPOSALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPROPOSALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPROPOSALPRICE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALPROPOSALPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALPROPOSALPRICE.TextFont.Name = "Arial";
                    TOTALPROPOSALPRICE.Value = @"{#TOTALPROPOSALPRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ProposalDetail.GetProposalledTotalPrices_Class dataset_GetProposalledTotalPrices = ParentGroup.rsGroup.GetCurrentRecord<ProposalDetail.GetProposalledTotalPrices_Class>(0);
                    SUPPLIER.CalcValue = (dataset_GetProposalledTotalPrices != null ? Globals.ToStringCore(dataset_GetProposalledTotalPrices.Supplier) : "");
                    TOTALPROPOSALPRICE.CalcValue = (dataset_GetProposalledTotalPrices != null ? Globals.ToStringCore(dataset_GetProposalledTotalPrices.Totalproposalprice) : "");
                    return new TTReportObject[] { SUPPLIER,TOTALPROPOSALPRICE};
                }
            }

        }

        public PARTEGroup PARTE;

        public partial class PARTAGroup : TTReportGroup
        {
            public IhaleKomisyonKarari MyParentReport
            {
                get { return (IhaleKomisyonKarari)ParentReport; }
            }

            new public PARTAGroupBody Body()
            {
                return (PARTAGroupBody)_body;
            }
            public TTReportRTF ReportRTF { get {return Body().ReportRTF;} }
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
                _header = null;
                _footer = null;
                _body = new PARTAGroupBody(this);
            }

            public partial class PARTAGroupBody : TTReportSection
            {
                public IhaleKomisyonKarari MyParentReport
                {
                    get { return (IhaleKomisyonKarari)ParentReport; }
                }
                
                public TTReportRTF ReportRTF; 
                public PARTAGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 15;
                    RepeatCount = 0;
                    
                    ReportRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 0, 3, 170, 14, false);
                    ReportRTF.Name = "ReportRTF";
                    ReportRTF.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportRTF.CalcValue = ReportRTF.Value;
                    return new TTReportObject[] { ReportRTF};
                }
                public override void RunPreScript()
                {
#region PARTA BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((IhaleKomisyonKarari)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PurchaseProject purchaseProject = (PurchaseProject)context.GetObject(new Guid(sObjectID),"PurchaseProject");
            this.ReportRTF.Value = purchaseProject.DecisionDescription.ToString();
#endregion PARTA BODY_PreScript
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTCGroup : TTReportGroup
        {
            public IhaleKomisyonKarari MyParentReport
            {
                get { return (IhaleKomisyonKarari)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField PROJECTNO1141 { get {return Header().PROJECTNO1141;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public IhaleKomisyonKarari MyParentReport
                {
                    get { return (IhaleKomisyonKarari)ParentReport; }
                }
                
                public TTReportField PROJECTNO1141; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 11;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PROJECTNO1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 3, 170, 8, false);
                    PROJECTNO1141.Name = "PROJECTNO1141";
                    PROJECTNO1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROJECTNO1141.MultiLine = EvetHayirEnum.ehEvet;
                    PROJECTNO1141.WordBreak = EvetHayirEnum.ehEvet;
                    PROJECTNO1141.TextFont.Name = "Arial";
                    PROJECTNO1141.TextFont.Bold = true;
                    PROJECTNO1141.Value = @"İHALE KOMİSYONU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PROJECTNO1141.CalcValue = PROJECTNO1141.Value;
                    return new TTReportObject[] { PROJECTNO1141};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public IhaleKomisyonKarari MyParentReport
                {
                    get { return (IhaleKomisyonKarari)ParentReport; }
                }
                 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTDGroup : TTReportGroup
        {
            public IhaleKomisyonKarari MyParentReport
            {
                get { return (IhaleKomisyonKarari)ParentReport; }
            }

            new public PARTDGroupBody Body()
            {
                return (PARTDGroupBody)_body;
            }
            public TTReportField NAMESURNAME { get {return Body().NAMESURNAME;} }
            public TTReportField HOSPFUNC { get {return Body().HOSPFUNC;} }
            public TTReportField COMFUNC { get {return Body().COMFUNC;} }
            public TTReportField RANK { get {return Body().RANK;} }
            public PARTDGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTDGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PurchaseProject.GetTenderCommisionMembersQuery_Class>("GetTenderCommisionMembersQuery", PurchaseProject.GetTenderCommisionMembersQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTDGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTDGroupBody : TTReportSection
            {
                public IhaleKomisyonKarari MyParentReport
                {
                    get { return (IhaleKomisyonKarari)ParentReport; }
                }
                
                public TTReportField NAMESURNAME;
                public TTReportField HOSPFUNC;
                public TTReportField COMFUNC;
                public TTReportField RANK; 
                public PARTDGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 35;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 3;
                    RepeatWidth = 47;
                    
                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 12, 57, 16, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NAMESURNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME.NoClip = EvetHayirEnum.ehEvet;
                    NAMESURNAME.TextFont.Name = "Arial";
                    NAMESURNAME.Value = @"{#NAMESURNAME#}";

                    HOSPFUNC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 17, 57, 21, false);
                    HOSPFUNC.Name = "HOSPFUNC";
                    HOSPFUNC.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC.ObjectDefName = "UserTitleEnum";
                    HOSPFUNC.DataMember = "DISPLAYTEXT";
                    HOSPFUNC.TextFont.Name = "Arial";
                    HOSPFUNC.Value = @"{#HOSPFUNC#}";

                    COMFUNC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 2, 57, 6, false);
                    COMFUNC.Name = "COMFUNC";
                    COMFUNC.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC.CaseFormat = CaseFormatEnum.fcUpperCase;
                    COMFUNC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC.ObjectDefName = "CommisionMemberDutyEnum";
                    COMFUNC.DataMember = "DISPLAYTEXT";
                    COMFUNC.TextFont.Name = "Arial";
                    COMFUNC.Value = @"{#COMFUNC#}";

                    RANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 7, 57, 11, false);
                    RANK.Name = "RANK";
                    RANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    RANK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RANK.NoClip = EvetHayirEnum.ehEvet;
                    RANK.TextFont.Name = "Arial";
                    RANK.Value = @"{#RANK#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.GetTenderCommisionMembersQuery_Class dataset_GetTenderCommisionMembersQuery = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.GetTenderCommisionMembersQuery_Class>(0);
                    NAMESURNAME.CalcValue = (dataset_GetTenderCommisionMembersQuery != null ? Globals.ToStringCore(dataset_GetTenderCommisionMembersQuery.Namesurname) : "");
                    HOSPFUNC.CalcValue = (dataset_GetTenderCommisionMembersQuery != null ? Globals.ToStringCore(dataset_GetTenderCommisionMembersQuery.Hospfunc) : "");
                    HOSPFUNC.PostFieldValueCalculation();
                    COMFUNC.CalcValue = (dataset_GetTenderCommisionMembersQuery != null ? Globals.ToStringCore(dataset_GetTenderCommisionMembersQuery.Comfunc) : "");
                    COMFUNC.PostFieldValueCalculation();
                    RANK.CalcValue = (dataset_GetTenderCommisionMembersQuery != null ? Globals.ToStringCore(dataset_GetTenderCommisionMembersQuery.Rank) : "");
                    return new TTReportObject[] { NAMESURNAME,HOSPFUNC,COMFUNC,RANK};
                }
            }

        }

        public PARTDGroup PARTD;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public IhaleKomisyonKarari()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTF = new PARTFGroup(PARTB,"PARTF");
            PARTE = new PARTEGroup(PARTF,"PARTE");
            PARTA = new PARTAGroup(PARTF,"PARTA");
            PARTC = new PARTCGroup(PARTF,"PARTC");
            PARTD = new PARTDGroup(PARTC,"PARTD");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Proje No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "IHALEKOMISYONKARARI";
            Caption = "İhale Komisyon Kararı";
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