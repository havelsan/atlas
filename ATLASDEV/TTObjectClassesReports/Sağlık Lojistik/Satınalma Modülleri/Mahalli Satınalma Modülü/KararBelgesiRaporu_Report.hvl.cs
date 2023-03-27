
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
    /// Karar Belgesi Raporu_KİK021.0/M
    /// </summary>
    public partial class KararBelgesiRaporu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTCGroup : TTReportGroup
        {
            public KararBelgesiRaporu MyParentReport
            {
                get { return (KararBelgesiRaporu)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField IHALEKAYITNO { get {return Header().IHALEKAYITNO;} }
            public TTReportField IDAREADI { get {return Header().IDAREADI;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField ISINADI { get {return Header().ISINADI;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField IHALEUSULU { get {return Header().IHALEUSULU;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField DOCUMENTDATE { get {return Header().DOCUMENTDATE;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField CONCLUSIONNO { get {return Header().CONCLUSIONNO;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField BASLIK { get {return Header().BASLIK;} }
            public TTReportField TOTALPROPCOUNT { get {return Header().TOTALPROPCOUNT;} }
            public TTReportField TOTALVALIDPROPCOUNT { get {return Header().TOTALVALIDPROPCOUNT;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField FILENO { get {return Header().FILENO;} }
            public TTReportField NewField20 { get {return Header().NewField20;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField CONCLUSIONDATE { get {return Header().CONCLUSIONDATE;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField CONFIRMNODATE { get {return Header().CONFIRMNODATE;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField CONTRACTNODATE { get {return Header().CONTRACTNODATE;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField23 { get {return Header().NewField23;} }
            public TTReportField MILITARYUNIT { get {return Header().MILITARYUNIT;} }
            public TTReportField NewField24 { get {return Header().NewField24;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField CONFIRMCARE { get {return Header().CONFIRMCARE;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField NewField25 { get {return Header().NewField25;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField BESTFIRM { get {return Header().BESTFIRM;} }
            public TTReportField NewField152 { get {return Header().NewField152;} }
            public TTReportField NewField1251 { get {return Header().NewField1251;} }
            public TTReportField NewField153 { get {return Header().NewField153;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField BESTPRICE { get {return Header().BESTPRICE;} }
            public TTReportField NewField154 { get {return Header().NewField154;} }
            public TTReportField NewField1162 { get {return Header().NewField1162;} }
            public TTReportField SECONDFIRM { get {return Header().SECONDFIRM;} }
            public TTReportField NewField1351 { get {return Header().NewField1351;} }
            public TTReportField NewField11611 { get {return Header().NewField11611;} }
            public TTReportField SECONDPRICE { get {return Header().SECONDPRICE;} }
            public TTReportField NewField126 { get {return Header().NewField126;} }
            public TTReportField NewField127 { get {return Header().NewField127;} }
            public TTReportField NewField173 { get {return Header().NewField173;} }
            public TTReportField NewField1721 { get {return Header().NewField1721;} }
            public TTReportField NewField1371 { get {return Header().NewField1371;} }
            public TTReportField CONFIRMDATE { get {return Header().CONFIRMDATE;} }
            public TTReportField CONTRACTDATE { get {return Header().CONTRACTDATE;} }
            public TTReportField FIRM111 { get {return Footer().FIRM111;} }
            public TTReportField KATITEMINAT { get {return Footer().KATITEMINAT;} }
            public TTReportField FIRM1111 { get {return Footer().FIRM1111;} }
            public TTReportField KARARPULU { get {return Footer().KARARPULU;} }
            public TTReportField FIRM1121 { get {return Footer().FIRM1121;} }
            public TTReportField SOZLESMEPULU { get {return Footer().SOZLESMEPULU;} }
            public TTReportField FIRM1131 { get {return Footer().FIRM1131;} }
            public TTReportField KIKBEDELI { get {return Footer().KIKBEDELI;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Contract.KararBelgesiNQL_Class>("KararBelgesiNQL", Contract.KararBelgesiNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public KararBelgesiRaporu MyParentReport
                {
                    get { return (KararBelgesiRaporu)ParentReport; }
                }
                
                public TTReportField NewField2;
                public TTReportField NewField4;
                public TTReportField IHALEKAYITNO;
                public TTReportField IDAREADI;
                public TTReportField NewField5;
                public TTReportField NewField7;
                public TTReportField DATE;
                public TTReportField ISINADI;
                public TTReportField NewField9;
                public TTReportField NewField11;
                public TTReportField NewField13;
                public TTReportField IHALEUSULU;
                public TTReportField NewField18;
                public TTReportField DOCUMENTDATE;
                public TTReportField NewField1;
                public TTReportField CONCLUSIONNO;
                public TTReportField NewField3;
                public TTReportField NewField6;
                public TTReportField NewField8;
                public TTReportField NewField10;
                public TTReportField NewField12;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField BASLIK;
                public TTReportField TOTALPROPCOUNT;
                public TTReportField TOTALVALIDPROPCOUNT;
                public TTReportField NewField19;
                public TTReportField FILENO;
                public TTReportField NewField20;
                public TTReportField NewField21;
                public TTReportField CONCLUSIONDATE;
                public TTReportField NewField22;
                public TTReportField NewField112;
                public TTReportField CONFIRMNODATE;
                public TTReportField NewField122;
                public TTReportField NewField1211;
                public TTReportField CONTRACTNODATE;
                public TTReportField NewField1221;
                public TTReportField NewField23;
                public TTReportField MILITARYUNIT;
                public TTReportField NewField24;
                public TTReportField NewField132;
                public TTReportField CONFIRMCARE;
                public TTReportField NewField142;
                public TTReportField NewField25;
                public TTReportField NewField161;
                public TTReportField BESTFIRM;
                public TTReportField NewField152;
                public TTReportField NewField1251;
                public TTReportField NewField153;
                public TTReportField NewField1161;
                public TTReportField BESTPRICE;
                public TTReportField NewField154;
                public TTReportField NewField1162;
                public TTReportField SECONDFIRM;
                public TTReportField NewField1351;
                public TTReportField NewField11611;
                public TTReportField SECONDPRICE;
                public TTReportField NewField126;
                public TTReportField NewField127;
                public TTReportField NewField173;
                public TTReportField NewField1721;
                public TTReportField NewField1371;
                public TTReportField CONFIRMDATE;
                public TTReportField CONTRACTDATE; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 143;
                    RepeatCount = 0;
                    
                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 16, 45, 21, false);
                    NewField2.Name = "NewField2";
                    NewField2.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"İhale Kayıt No";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 44, 55, 49, false);
                    NewField4.Name = "NewField4";
                    NewField4.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @"İdarenin Adı";

                    IHALEKAYITNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 16, 83, 21, false);
                    IHALEKAYITNO.Name = "IHALEKAYITNO";
                    IHALEKAYITNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    IHALEKAYITNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IHALEKAYITNO.TextFont.Name = "Arial";
                    IHALEKAYITNO.Value = @"{#KIKTENDERREGISTERNO#}";

                    IDAREADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 44, 191, 49, false);
                    IDAREADI.Name = "IDAREADI";
                    IDAREADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    IDAREADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IDAREADI.TextFont.Name = "Arial";
                    IDAREADI.Value = @"";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 49, 55, 54, false);
                    NewField5.Name = "NewField5";
                    NewField5.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @"İşin Adı";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 54, 55, 59, false);
                    NewField7.Name = "NewField7";
                    NewField7.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7.WordBreak = EvetHayirEnum.ehEvet;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Bold = true;
                    NewField7.Value = @"İhale tarih ve saati";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 54, 191, 59, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    DATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATE.TextFont.Name = "Arial";
                    DATE.Value = @"{#TENDERDATE#}";

                    ISINADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 49, 191, 54, false);
                    ISINADI.Name = "ISINADI";
                    ISINADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISINADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISINADI.TextFont.Name = "Arial";
                    ISINADI.Value = @"{#ACTDEFINE#}";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 69, 55, 74, false);
                    NewField9.Name = "NewField9";
                    NewField9.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9.MultiLine = EvetHayirEnum.ehEvet;
                    NewField9.WordBreak = EvetHayirEnum.ehEvet;
                    NewField9.TextFont.Name = "Arial";
                    NewField9.TextFont.Bold = true;
                    NewField9.Value = @"Geçerli teklif sayısı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 64, 55, 69, false);
                    NewField11.Name = "NewField11";
                    NewField11.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"Toplam teklif sayısı";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 59, 55, 64, false);
                    NewField13.Name = "NewField13";
                    NewField13.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13.WordBreak = EvetHayirEnum.ehEvet;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @"İhale usulü";

                    IHALEUSULU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 59, 191, 64, false);
                    IHALEUSULU.Name = "IHALEUSULU";
                    IHALEUSULU.FieldType = ReportFieldTypeEnum.ftVariable;
                    IHALEUSULU.TextFormat = @"dd/mm/yyyy hh:mm";
                    IHALEUSULU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IHALEUSULU.TextFont.Name = "Arial";
                    IHALEUSULU.Value = @"{#PURCHASETYPENAME#}";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 116, 81, 121, false);
                    NewField18.Name = "NewField18";
                    NewField18.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18.TextFont.Name = "Arial";
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @"Bu tutanağın düzenlendiği tarih saat";

                    DOCUMENTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 116, 191, 121, false);
                    DOCUMENTDATE.Name = "DOCUMENTDATE";
                    DOCUMENTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOCUMENTDATE.TextFont.Name = "Arial";
                    DOCUMENTDATE.Value = @"__/__/____";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 16, 110, 21, false);
                    NewField1.Name = "NewField1";
                    NewField1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"Karar No";

                    CONCLUSIONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 16, 138, 21, false);
                    CONCLUSIONNO.Name = "CONCLUSIONNO";
                    CONCLUSIONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONCLUSIONNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONCLUSIONNO.TextFont.Name = "Arial";
                    CONCLUSIONNO.Value = @"{#CONCLUSIONNO#}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 16, 112, 21, false);
                    NewField3.Name = "NewField3";
                    NewField3.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial Narrow";
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @":";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 16, 48, 21, false);
                    NewField6.Name = "NewField6";
                    NewField6.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial Narrow";
                    NewField6.TextFont.Bold = true;
                    NewField6.Value = @":";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 44, 58, 49, false);
                    NewField8.Name = "NewField8";
                    NewField8.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8.TextFont.Name = "Arial Narrow";
                    NewField8.TextFont.Bold = true;
                    NewField8.Value = @":";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 49, 58, 54, false);
                    NewField10.Name = "NewField10";
                    NewField10.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField10.TextFont.Name = "Arial Narrow";
                    NewField10.TextFont.Bold = true;
                    NewField10.Value = @":";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 54, 58, 59, false);
                    NewField12.Name = "NewField12";
                    NewField12.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial Narrow";
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @":";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 59, 58, 64, false);
                    NewField14.Name = "NewField14";
                    NewField14.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial Narrow";
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @":";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 64, 58, 69, false);
                    NewField15.Name = "NewField15";
                    NewField15.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial Narrow";
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @":";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 69, 58, 74, false);
                    NewField16.Name = "NewField16";
                    NewField16.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Name = "Arial Narrow";
                    NewField16.TextFont.Bold = true;
                    NewField16.Value = @":";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 116, 83, 121, false);
                    NewField17.Name = "NewField17";
                    NewField17.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField17.TextFont.Name = "Arial Narrow";
                    NewField17.TextFont.Bold = true;
                    NewField17.Value = @":";

                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 8, 191, 13, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK.TextFont.Name = "Arial";
                    BASLIK.TextFont.Bold = true;
                    BASLIK.Value = @"";

                    TOTALPROPCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 64, 191, 69, false);
                    TOTALPROPCOUNT.Name = "TOTALPROPCOUNT";
                    TOTALPROPCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPROPCOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALPROPCOUNT.TextFont.Name = "Arial";
                    TOTALPROPCOUNT.Value = @"";

                    TOTALVALIDPROPCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 69, 191, 74, false);
                    TOTALVALIDPROPCOUNT.Name = "TOTALVALIDPROPCOUNT";
                    TOTALVALIDPROPCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALVALIDPROPCOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALVALIDPROPCOUNT.TextFont.Name = "Arial";
                    TOTALVALIDPROPCOUNT.Value = @"";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 16, 168, 21, false);
                    NewField19.Name = "NewField19";
                    NewField19.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.TextFont.Name = "Arial";
                    NewField19.TextFont.Bold = true;
                    NewField19.Value = @"Dosya No";

                    FILENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 16, 191, 21, false);
                    FILENO.Name = "FILENO";
                    FILENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    FILENO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FILENO.TextFont.Name = "Arial";
                    FILENO.Value = @"{#TENDERCOMMISIONREGNO#}";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 16, 170, 21, false);
                    NewField20.Name = "NewField20";
                    NewField20.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField20.TextFont.Name = "Arial Narrow";
                    NewField20.TextFont.Bold = true;
                    NewField20.Value = @":";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 21, 45, 26, false);
                    NewField21.Name = "NewField21";
                    NewField21.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21.TextFont.Name = "Arial";
                    NewField21.TextFont.Bold = true;
                    NewField21.Value = @"Karar Tarihi";

                    CONCLUSIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 21, 83, 26, false);
                    CONCLUSIONDATE.Name = "CONCLUSIONDATE";
                    CONCLUSIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONCLUSIONDATE.TextFormat = @"Short Date";
                    CONCLUSIONDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONCLUSIONDATE.TextFont.Name = "Arial";
                    CONCLUSIONDATE.Value = @"{#CONCLUSIONAPPROVEDATE#}";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 21, 48, 26, false);
                    NewField22.Name = "NewField22";
                    NewField22.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField22.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField22.TextFont.Name = "Arial Narrow";
                    NewField22.TextFont.Bold = true;
                    NewField22.Value = @":";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 26, 45, 31, false);
                    NewField112.Name = "NewField112";
                    NewField112.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.Name = "Arial";
                    NewField112.TextFont.Bold = true;
                    NewField112.Value = @"Onay Tarihi / No";

                    CONFIRMNODATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 26, 86, 31, false);
                    CONFIRMNODATE.Name = "CONFIRMNODATE";
                    CONFIRMNODATE.FieldType = ReportFieldTypeEnum.ftExpression;
                    CONFIRMNODATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONFIRMNODATE.TextFont.Name = "Arial";
                    CONFIRMNODATE.Value = @"{#CONFIRMNO#} + "" / "" + {%CONFIRMDATE%}";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 26, 48, 31, false);
                    NewField122.Name = "NewField122";
                    NewField122.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Name = "Arial Narrow";
                    NewField122.TextFont.Bold = true;
                    NewField122.Value = @":";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 31, 45, 36, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211.TextFont.Name = "Arial";
                    NewField1211.TextFont.Bold = true;
                    NewField1211.Value = @"Sözleşme Tarihi / No";

                    CONTRACTNODATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 31, 87, 36, false);
                    CONTRACTNODATE.Name = "CONTRACTNODATE";
                    CONTRACTNODATE.FieldType = ReportFieldTypeEnum.ftExpression;
                    CONTRACTNODATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONTRACTNODATE.TextFont.Name = "Arial";
                    CONTRACTNODATE.Value = @"{#CONTRACTNO#} + "" / "" + {%CONTRACTDATE%}";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 31, 48, 36, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1221.TextFont.Name = "Arial Narrow";
                    NewField1221.TextFont.Bold = true;
                    NewField1221.Value = @":";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 21, 110, 26, false);
                    NewField23.Name = "NewField23";
                    NewField23.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField23.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField23.TextFont.Name = "Arial";
                    NewField23.TextFont.Bold = true;
                    NewField23.Value = @"Birliği";

                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 21, 191, 26, false);
                    MILITARYUNIT.Name = "MILITARYUNIT";
                    MILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MILITARYUNIT.TextFont.Name = "Arial";
                    MILITARYUNIT.Value = @"{#ACCOUNTANCYMILITARYUNIT#}";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 21, 112, 26, false);
                    NewField24.Name = "NewField24";
                    NewField24.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField24.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField24.TextFont.Name = "Arial Narrow";
                    NewField24.TextFont.Bold = true;
                    NewField24.Value = @":";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 26, 110, 31, false);
                    NewField132.Name = "NewField132";
                    NewField132.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField132.TextFont.Name = "Arial";
                    NewField132.TextFont.Bold = true;
                    NewField132.Value = @"Onay İlgisi";

                    CONFIRMCARE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 26, 191, 31, false);
                    CONFIRMCARE.Name = "CONFIRMCARE";
                    CONFIRMCARE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONFIRMCARE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONFIRMCARE.TextFont.Name = "Arial";
                    CONFIRMCARE.Value = @"";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 26, 112, 31, false);
                    NewField142.Name = "NewField142";
                    NewField142.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField142.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField142.TextFont.Name = "Arial Narrow";
                    NewField142.TextFont.Bold = true;
                    NewField142.Value = @":";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 84, 55, 89, false);
                    NewField25.Name = "NewField25";
                    NewField25.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField25.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField25.MultiLine = EvetHayirEnum.ehEvet;
                    NewField25.WordBreak = EvetHayirEnum.ehEvet;
                    NewField25.TextFont.Name = "Arial";
                    NewField25.TextFont.Bold = true;
                    NewField25.Value = @"A) SAHİNİNİN ADI";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 84, 58, 89, false);
                    NewField161.Name = "NewField161";
                    NewField161.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField161.TextFont.Name = "Arial Narrow";
                    NewField161.TextFont.Bold = true;
                    NewField161.Value = @":";

                    BESTFIRM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 84, 191, 89, false);
                    BESTFIRM.Name = "BESTFIRM";
                    BESTFIRM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BESTFIRM.TextFont.Name = "Arial";
                    BESTFIRM.Value = @"";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 78, 191, 83, false);
                    NewField152.Name = "NewField152";
                    NewField152.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField152.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField152.MultiLine = EvetHayirEnum.ehEvet;
                    NewField152.WordBreak = EvetHayirEnum.ehEvet;
                    NewField152.TextFont.Name = "Arial";
                    NewField152.TextFont.Bold = true;
                    NewField152.Value = @"EKONOMİK AÇIDAN EN AVANTAJLI TEKLİF :";

                    NewField1251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 97, 191, 102, false);
                    NewField1251.Name = "NewField1251";
                    NewField1251.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField1251.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1251.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1251.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1251.TextFont.Name = "Arial";
                    NewField1251.TextFont.Bold = true;
                    NewField1251.Value = @"EKONOMİK AÇIDAN EN AVANTAJLI İKİNCİ TEKLİF :";

                    NewField153 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 89, 55, 94, false);
                    NewField153.Name = "NewField153";
                    NewField153.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField153.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField153.MultiLine = EvetHayirEnum.ehEvet;
                    NewField153.WordBreak = EvetHayirEnum.ehEvet;
                    NewField153.TextFont.Name = "Arial";
                    NewField153.TextFont.Bold = true;
                    NewField153.Value = @"B) TUTARI";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 89, 58, 94, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1161.TextFont.Name = "Arial Narrow";
                    NewField1161.TextFont.Bold = true;
                    NewField1161.Value = @":";

                    BESTPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 89, 191, 94, false);
                    BESTPRICE.Name = "BESTPRICE";
                    BESTPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BESTPRICE.TextFont.Name = "Arial";
                    BESTPRICE.Value = @"";

                    NewField154 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 103, 55, 108, false);
                    NewField154.Name = "NewField154";
                    NewField154.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField154.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField154.MultiLine = EvetHayirEnum.ehEvet;
                    NewField154.WordBreak = EvetHayirEnum.ehEvet;
                    NewField154.TextFont.Name = "Arial";
                    NewField154.TextFont.Bold = true;
                    NewField154.Value = @"A) SAHİNİNİN ADI";

                    NewField1162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 103, 58, 108, false);
                    NewField1162.Name = "NewField1162";
                    NewField1162.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1162.TextFont.Name = "Arial Narrow";
                    NewField1162.TextFont.Bold = true;
                    NewField1162.Value = @":";

                    SECONDFIRM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 103, 191, 108, false);
                    SECONDFIRM.Name = "SECONDFIRM";
                    SECONDFIRM.FieldType = ReportFieldTypeEnum.ftVariable;
                    SECONDFIRM.TextFont.Name = "Arial";
                    SECONDFIRM.Value = @"";

                    NewField1351 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 108, 55, 113, false);
                    NewField1351.Name = "NewField1351";
                    NewField1351.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField1351.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1351.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1351.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1351.TextFont.Name = "Arial";
                    NewField1351.TextFont.Bold = true;
                    NewField1351.Value = @"B) TUTARI";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 108, 58, 113, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField11611.TextFont.Name = "Arial Narrow";
                    NewField11611.TextFont.Bold = true;
                    NewField11611.Value = @":";

                    SECONDPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 108, 191, 113, false);
                    SECONDPRICE.Name = "SECONDPRICE";
                    SECONDPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    SECONDPRICE.TextFont.Name = "Arial";
                    SECONDPRICE.Value = @"";

                    NewField126 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 124, 191, 129, false);
                    NewField126.Name = "NewField126";
                    NewField126.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField126.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField126.MultiLine = EvetHayirEnum.ehEvet;
                    NewField126.WordBreak = EvetHayirEnum.ehEvet;
                    NewField126.TextFont.Name = "Arial";
                    NewField126.TextFont.Bold = true;
                    NewField126.Value = @"İsteklilerin Teklif Ettiği Bedeller";

                    NewField127 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 131, 77, 141, false);
                    NewField127.Name = "NewField127";
                    NewField127.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField127.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField127.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField127.TextFont.Name = "Arial";
                    NewField127.TextFont.Bold = true;
                    NewField127.Value = @" İsteklinin Adı";

                    NewField173 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 131, 97, 141, false);
                    NewField173.Name = "NewField173";
                    NewField173.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField173.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField173.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField173.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField173.MultiLine = EvetHayirEnum.ehEvet;
                    NewField173.TextFont.Name = "Arial";
                    NewField173.TextFont.Bold = true;
                    NewField173.Value = @"Teklif 
Tutarı";

                    NewField1721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 131, 170, 141, false);
                    NewField1721.Name = "NewField1721";
                    NewField1721.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1721.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1721.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1721.TextFont.Name = "Arial";
                    NewField1721.TextFont.Bold = true;
                    NewField1721.Value = @" İsteklinin Adı";

                    NewField1371 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 131, 190, 141, false);
                    NewField1371.Name = "NewField1371";
                    NewField1371.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1371.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1371.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1371.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1371.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1371.TextFont.Name = "Arial";
                    NewField1371.TextFont.Bold = true;
                    NewField1371.Value = @"Teklif 
Tutarı";

                    CONFIRMDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 208, 19, 233, 24, false);
                    CONFIRMDATE.Name = "CONFIRMDATE";
                    CONFIRMDATE.Visible = EvetHayirEnum.ehHayir;
                    CONFIRMDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONFIRMDATE.TextFormat = @"Short Date";
                    CONFIRMDATE.TextFont.Name = "Arial";
                    CONFIRMDATE.TextFont.Size = 9;
                    CONFIRMDATE.Value = @"{#CONFIRMDATE#}";

                    CONTRACTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 208, 24, 233, 29, false);
                    CONTRACTDATE.Name = "CONTRACTDATE";
                    CONTRACTDATE.Visible = EvetHayirEnum.ehHayir;
                    CONTRACTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONTRACTDATE.TextFormat = @"Short Date";
                    CONTRACTDATE.TextFont.Name = "Arial";
                    CONTRACTDATE.TextFont.Size = 9;
                    CONTRACTDATE.Value = @"{#CONTRACTDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Contract.KararBelgesiNQL_Class dataset_KararBelgesiNQL = ParentGroup.rsGroup.GetCurrentRecord<Contract.KararBelgesiNQL_Class>(0);
                    NewField2.CalcValue = NewField2.Value;
                    NewField4.CalcValue = NewField4.Value;
                    IHALEKAYITNO.CalcValue = (dataset_KararBelgesiNQL != null ? Globals.ToStringCore(dataset_KararBelgesiNQL.KIKTenderRegisterNO) : "");
                    IDAREADI.CalcValue = @"";
                    NewField5.CalcValue = NewField5.Value;
                    NewField7.CalcValue = NewField7.Value;
                    DATE.CalcValue = (dataset_KararBelgesiNQL != null ? Globals.ToStringCore(dataset_KararBelgesiNQL.TenderDate) : "");
                    ISINADI.CalcValue = (dataset_KararBelgesiNQL != null ? Globals.ToStringCore(dataset_KararBelgesiNQL.ActDefine) : "");
                    NewField9.CalcValue = NewField9.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField13.CalcValue = NewField13.Value;
                    IHALEUSULU.CalcValue = (dataset_KararBelgesiNQL != null ? Globals.ToStringCore(dataset_KararBelgesiNQL.PurchaseTypeName) : "");
                    NewField18.CalcValue = NewField18.Value;
                    DOCUMENTDATE.CalcValue = @"__/__/____";
                    NewField1.CalcValue = NewField1.Value;
                    CONCLUSIONNO.CalcValue = (dataset_KararBelgesiNQL != null ? Globals.ToStringCore(dataset_KararBelgesiNQL.ConclusionNo) : "");
                    NewField3.CalcValue = NewField3.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    BASLIK.CalcValue = @"";
                    TOTALPROPCOUNT.CalcValue = @"";
                    TOTALVALIDPROPCOUNT.CalcValue = @"";
                    NewField19.CalcValue = NewField19.Value;
                    FILENO.CalcValue = (dataset_KararBelgesiNQL != null ? Globals.ToStringCore(dataset_KararBelgesiNQL.TenderCommisionRegNo) : "");
                    NewField20.CalcValue = NewField20.Value;
                    NewField21.CalcValue = NewField21.Value;
                    CONCLUSIONDATE.CalcValue = (dataset_KararBelgesiNQL != null ? Globals.ToStringCore(dataset_KararBelgesiNQL.ConclusionApproveDate) : "");
                    NewField22.CalcValue = NewField22.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField23.CalcValue = NewField23.Value;
                    MILITARYUNIT.CalcValue = (dataset_KararBelgesiNQL != null ? Globals.ToStringCore(dataset_KararBelgesiNQL.Accountancymilitaryunit) : "");
                    NewField24.CalcValue = NewField24.Value;
                    NewField132.CalcValue = NewField132.Value;
                    CONFIRMCARE.CalcValue = @"";
                    NewField142.CalcValue = NewField142.Value;
                    NewField25.CalcValue = NewField25.Value;
                    NewField161.CalcValue = NewField161.Value;
                    BESTFIRM.CalcValue = @"";
                    NewField152.CalcValue = NewField152.Value;
                    NewField1251.CalcValue = NewField1251.Value;
                    NewField153.CalcValue = NewField153.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    BESTPRICE.CalcValue = @"";
                    NewField154.CalcValue = NewField154.Value;
                    NewField1162.CalcValue = NewField1162.Value;
                    SECONDFIRM.CalcValue = @"";
                    NewField1351.CalcValue = NewField1351.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    SECONDPRICE.CalcValue = @"";
                    NewField126.CalcValue = NewField126.Value;
                    NewField127.CalcValue = NewField127.Value;
                    NewField173.CalcValue = NewField173.Value;
                    NewField1721.CalcValue = NewField1721.Value;
                    NewField1371.CalcValue = NewField1371.Value;
                    CONFIRMDATE.CalcValue = (dataset_KararBelgesiNQL != null ? Globals.ToStringCore(dataset_KararBelgesiNQL.ConfirmDate) : "");
                    CONTRACTDATE.CalcValue = (dataset_KararBelgesiNQL != null ? Globals.ToStringCore(dataset_KararBelgesiNQL.ContractDate) : "");
                    CONFIRMNODATE.CalcValue = (dataset_KararBelgesiNQL != null ? Globals.ToStringCore(dataset_KararBelgesiNQL.ConfirmNO) : "") + " / " + MyParentReport.PARTC.CONFIRMDATE.FormattedValue;
                    CONTRACTNODATE.CalcValue = (dataset_KararBelgesiNQL != null ? Globals.ToStringCore(dataset_KararBelgesiNQL.ContractNo) : "") + " / " + MyParentReport.PARTC.CONTRACTDATE.FormattedValue;
                    return new TTReportObject[] { NewField2,NewField4,IHALEKAYITNO,IDAREADI,NewField5,NewField7,DATE,ISINADI,NewField9,NewField11,NewField13,IHALEUSULU,NewField18,DOCUMENTDATE,NewField1,CONCLUSIONNO,NewField3,NewField6,NewField8,NewField10,NewField12,NewField14,NewField15,NewField16,NewField17,BASLIK,TOTALPROPCOUNT,TOTALVALIDPROPCOUNT,NewField19,FILENO,NewField20,NewField21,CONCLUSIONDATE,NewField22,NewField112,NewField122,NewField1211,NewField1221,NewField23,MILITARYUNIT,NewField24,NewField132,CONFIRMCARE,NewField142,NewField25,NewField161,BESTFIRM,NewField152,NewField1251,NewField153,NewField1161,BESTPRICE,NewField154,NewField1162,SECONDFIRM,NewField1351,NewField11611,SECONDPRICE,NewField126,NewField127,NewField173,NewField1721,NewField1371,CONFIRMDATE,CONTRACTDATE,CONFIRMNODATE,CONTRACTNODATE};
                }

                public override void RunScript()
                {
#region PARTC HEADER_Script
                    string objectID = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
            PurchaseProject purchaseProject = (PurchaseProject)MyParentReport.ReportObjectContext.GetObject(new Guid(objectID), typeof(PurchaseProject));
            
            TOTALPROPCOUNT.CalcValue = Convert.ToString(purchaseProject.GetTotalProposalCount(true));
            TOTALVALIDPROPCOUNT.CalcValue = Convert.ToString(purchaseProject.GetTotalProposalCount(false));

//            ArrayList arrayList = purchaseProject.GetBestAndSecondProposalsBySupplierTotalProposalPrice(CONCLUSIONNO.CalcValue);
//            BESTFIRM.CalcValue = ((Supplier)arrayList[0]).Name;
//            BESTPRICE.CalcValue = arrayList[1].ToString();
//            if (arrayList[3].ToString() != "-1")
//            {
//                SECONDFIRM.CalcValue = ((Supplier)arrayList[2]).Name;
//                SECONDPRICE.CalcValue = arrayList[3].ToString();
//            }
            
            IDAREADI.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "").ToString();
            BASLIK.CalcValue = purchaseProject.ResponsibleProcurementUnitDef.Name + " KARARI";
#endregion PARTC HEADER_Script
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public KararBelgesiRaporu MyParentReport
                {
                    get { return (KararBelgesiRaporu)ParentReport; }
                }
                
                public TTReportField FIRM111;
                public TTReportField KATITEMINAT;
                public TTReportField FIRM1111;
                public TTReportField KARARPULU;
                public TTReportField FIRM1121;
                public TTReportField SOZLESMEPULU;
                public TTReportField FIRM1131;
                public TTReportField KIKBEDELI; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 29;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    FIRM111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 5, 56, 10, false);
                    FIRM111.Name = "FIRM111";
                    FIRM111.CaseFormat = CaseFormatEnum.fcUpperCase;
                    FIRM111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRM111.TextFont.Name = "Arial";
                    FIRM111.TextFont.Size = 9;
                    FIRM111.Value = @"KATİ TEMİNAT MİKTARI";

                    KATITEMINAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 5, 77, 10, false);
                    KATITEMINAT.Name = "KATITEMINAT";
                    KATITEMINAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    KATITEMINAT.TextFormat = @"#,##0.#0";
                    KATITEMINAT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KATITEMINAT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KATITEMINAT.TextFont.Name = "Arial";
                    KATITEMINAT.TextFont.Size = 9;
                    KATITEMINAT.Value = @"";

                    FIRM1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 10, 56, 15, false);
                    FIRM1111.Name = "FIRM1111";
                    FIRM1111.CaseFormat = CaseFormatEnum.fcUpperCase;
                    FIRM1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRM1111.TextFont.Name = "Arial";
                    FIRM1111.TextFont.Size = 9;
                    FIRM1111.Value = @"KARAR PULU MİKTARI";

                    KARARPULU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 10, 77, 15, false);
                    KARARPULU.Name = "KARARPULU";
                    KARARPULU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARARPULU.TextFormat = @"#,##0.#0";
                    KARARPULU.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KARARPULU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KARARPULU.TextFont.Name = "Arial";
                    KARARPULU.TextFont.Size = 9;
                    KARARPULU.Value = @"";

                    FIRM1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 15, 56, 20, false);
                    FIRM1121.Name = "FIRM1121";
                    FIRM1121.CaseFormat = CaseFormatEnum.fcUpperCase;
                    FIRM1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRM1121.TextFont.Name = "Arial";
                    FIRM1121.TextFont.Size = 9;
                    FIRM1121.Value = @"SÖZLEŞME PULU MİKTARI";

                    SOZLESMEPULU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 15, 77, 20, false);
                    SOZLESMEPULU.Name = "SOZLESMEPULU";
                    SOZLESMEPULU.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOZLESMEPULU.TextFormat = @"#,##0.#0";
                    SOZLESMEPULU.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SOZLESMEPULU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SOZLESMEPULU.TextFont.Name = "Arial";
                    SOZLESMEPULU.TextFont.Size = 9;
                    SOZLESMEPULU.Value = @"";

                    FIRM1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 20, 56, 25, false);
                    FIRM1131.Name = "FIRM1131";
                    FIRM1131.CaseFormat = CaseFormatEnum.fcUpperCase;
                    FIRM1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRM1131.TextFont.Name = "Arial";
                    FIRM1131.TextFont.Size = 9;
                    FIRM1131.Value = @"KİK BEDELİ";

                    KIKBEDELI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 20, 77, 25, false);
                    KIKBEDELI.Name = "KIKBEDELI";
                    KIKBEDELI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIKBEDELI.TextFormat = @"#,##0.#0";
                    KIKBEDELI.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KIKBEDELI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KIKBEDELI.TextFont.Name = "Arial";
                    KIKBEDELI.TextFont.Size = 9;
                    KIKBEDELI.Value = @"{#TOTALCONTRACTVALUE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Contract.KararBelgesiNQL_Class dataset_KararBelgesiNQL = ParentGroup.rsGroup.GetCurrentRecord<Contract.KararBelgesiNQL_Class>(0);
                    FIRM111.CalcValue = FIRM111.Value;
                    KATITEMINAT.CalcValue = @"";
                    FIRM1111.CalcValue = FIRM1111.Value;
                    KARARPULU.CalcValue = @"";
                    FIRM1121.CalcValue = FIRM1121.Value;
                    SOZLESMEPULU.CalcValue = @"";
                    FIRM1131.CalcValue = FIRM1131.Value;
                    KIKBEDELI.CalcValue = (dataset_KararBelgesiNQL != null ? Globals.ToStringCore(dataset_KararBelgesiNQL.TotalContractValue) : "");
                    return new TTReportObject[] { FIRM111,KATITEMINAT,FIRM1111,KARARPULU,FIRM1121,SOZLESMEPULU,FIRM1131,KIKBEDELI};
                }

                public override void RunScript()
                {
#region PARTC FOOTER_Script
                    double ContractValue = Convert.ToDouble(KIKBEDELI.CalcValue);
            double PPKatiTeminatOrani = Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("PPKatiTeminatOrani", ""));
            double PPSozlesmePuluOrani = Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("PPSozlesmePuluOrani", ""));
            double PPKararPuluOrani = Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("PPKararPuluOrani", ""));
            KATITEMINAT.CalcValue = (ContractValue * PPKatiTeminatOrani).ToString();
            KARARPULU.CalcValue = (ContractValue * PPKararPuluOrani).ToString();
            SOZLESMEPULU.CalcValue = (ContractValue * PPSozlesmePuluOrani).ToString();
#endregion PARTC FOOTER_Script
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class LISTFULLGroup : TTReportGroup
        {
            public KararBelgesiRaporu MyParentReport
            {
                get { return (KararBelgesiRaporu)ParentReport; }
            }

            new public LISTFULLGroupBody Body()
            {
                return (LISTFULLGroupBody)_body;
            }
            public TTReportField FIRM { get {return Body().FIRM;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
            public LISTFULLGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public LISTFULLGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
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
                _body = new LISTFULLGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class LISTFULLGroupBody : TTReportSection
            {
                public KararBelgesiRaporu MyParentReport
                {
                    get { return (KararBelgesiRaporu)ParentReport; }
                }
                
                public TTReportField FIRM;
                public TTReportField PRICE; 
                public LISTFULLGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 2;
                    RepeatWidth = 93;
                    
                    FIRM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 0, 77, 5, false);
                    FIRM.Name = "FIRM";
                    FIRM.DrawStyle = DrawStyleConstants.vbSolid;
                    FIRM.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRM.CaseFormat = CaseFormatEnum.fcUpperCase;
                    FIRM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FIRM.TextFont.Name = "Arial";
                    FIRM.TextFont.Size = 9;
                    FIRM.Value = @"{#SUPPLIER#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 0, 97, 5, false);
                    PRICE.Name = "PRICE";
                    PRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICE.MultiLine = EvetHayirEnum.ehEvet;
                    PRICE.WordBreak = EvetHayirEnum.ehEvet;
                    PRICE.TextFont.Name = "Arial";
                    PRICE.TextFont.Size = 9;
                    PRICE.Value = @"{#TOTALPROPOSALPRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ProposalDetail.GetProposalledTotalPrices_Class dataset_GetProposalledTotalPrices = ParentGroup.rsGroup.GetCurrentRecord<ProposalDetail.GetProposalledTotalPrices_Class>(0);
                    FIRM.CalcValue = (dataset_GetProposalledTotalPrices != null ? Globals.ToStringCore(dataset_GetProposalledTotalPrices.Supplier) : "");
                    PRICE.CalcValue = (dataset_GetProposalledTotalPrices != null ? Globals.ToStringCore(dataset_GetProposalledTotalPrices.Totalproposalprice) : "");
                    return new TTReportObject[] { FIRM,PRICE};
                }
            }

        }

        public LISTFULLGroup LISTFULL;

        public partial class PARTAGroup : TTReportGroup
        {
            public KararBelgesiRaporu MyParentReport
            {
                get { return (KararBelgesiRaporu)ParentReport; }
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
                public KararBelgesiRaporu MyParentReport
                {
                    get { return (KararBelgesiRaporu)ParentReport; }
                }
                
                public TTReportRTF ReportRTF; 
                public PARTAGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 40;
                    RepeatCount = 0;
                    
                    ReportRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 4, 3, 191, 38, false);
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
            string sObjectID = ((KararBelgesiRaporu)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PurchaseProject purchaseProject = (PurchaseProject)context.GetObject(new Guid(sObjectID),"PurchaseProject");
            if(purchaseProject.DecisionDescription != null)
                this.ReportRTF.Value = purchaseProject.DecisionDescription.ToString();
#endregion PARTA BODY_PreScript
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public KararBelgesiRaporu MyParentReport
            {
                get { return (KararBelgesiRaporu)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField PROJECTNO1114111 { get {return Header().PROJECTNO1114111;} }
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
                public KararBelgesiRaporu MyParentReport
                {
                    get { return (KararBelgesiRaporu)ParentReport; }
                }
                
                public TTReportField PROJECTNO1114111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 9;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PROJECTNO1114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 2, 191, 7, false);
                    PROJECTNO1114111.Name = "PROJECTNO1114111";
                    PROJECTNO1114111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROJECTNO1114111.MultiLine = EvetHayirEnum.ehEvet;
                    PROJECTNO1114111.WordBreak = EvetHayirEnum.ehEvet;
                    PROJECTNO1114111.TextFont.Name = "Arial";
                    PROJECTNO1114111.TextFont.Bold = true;
                    PROJECTNO1114111.TextFont.Underline = true;
                    PROJECTNO1114111.Value = @"İHALE KOMİSYONU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PROJECTNO1114111.CalcValue = PROJECTNO1114111.Value;
                    return new TTReportObject[] { PROJECTNO1114111};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public KararBelgesiRaporu MyParentReport
                {
                    get { return (KararBelgesiRaporu)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTEGroup : TTReportGroup
        {
            public KararBelgesiRaporu MyParentReport
            {
                get { return (KararBelgesiRaporu)ParentReport; }
            }

            new public PARTEGroupBody Body()
            {
                return (PARTEGroupBody)_body;
            }
            public TTReportField NAMESURNAME { get {return Body().NAMESURNAME;} }
            public TTReportField HOSPFUNC { get {return Body().HOSPFUNC;} }
            public TTReportField COMFUNC { get {return Body().COMFUNC;} }
            public TTReportField RANK { get {return Body().RANK;} }
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
                list[0] = new TTReportNqlData<PurchaseProject.GetTenderCommisionMembersQuery_Class>("GetTenderCommisionMembersQuery", PurchaseProject.GetTenderCommisionMembersQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public KararBelgesiRaporu MyParentReport
                {
                    get { return (KararBelgesiRaporu)ParentReport; }
                }
                
                public TTReportField NAMESURNAME;
                public TTReportField HOSPFUNC;
                public TTReportField COMFUNC;
                public TTReportField RANK; 
                public PARTEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 35;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 3;
                    RepeatWidth = 52;
                    
                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 12, 64, 16, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NAMESURNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME.NoClip = EvetHayirEnum.ehEvet;
                    NAMESURNAME.TextFont.Name = "Arial";
                    NAMESURNAME.Value = @"{#NAMESURNAME#}";

                    HOSPFUNC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 17, 64, 21, false);
                    HOSPFUNC.Name = "HOSPFUNC";
                    HOSPFUNC.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC.ObjectDefName = "UserTitleEnum";
                    HOSPFUNC.DataMember = "DISPLAYTEXT";
                    HOSPFUNC.TextFont.Name = "Arial";
                    HOSPFUNC.Value = @"{#HOSPFUNC#}";

                    COMFUNC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 2, 64, 6, false);
                    COMFUNC.Name = "COMFUNC";
                    COMFUNC.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC.CaseFormat = CaseFormatEnum.fcUpperCase;
                    COMFUNC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC.ObjectDefName = "CommisionMemberDutyEnum";
                    COMFUNC.DataMember = "DISPLAYTEXT";
                    COMFUNC.TextFont.Name = "Arial";
                    COMFUNC.Value = @"{#COMFUNC#}";

                    RANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 7, 64, 11, false);
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

        public PARTEGroup PARTE;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public KararBelgesiRaporu()
        {
            PARTC = new PARTCGroup(this,"PARTC");
            LISTFULL = new LISTFULLGroup(PARTC,"LISTFULL");
            PARTA = new PARTAGroup(PARTC,"PARTA");
            PARTB = new PARTBGroup(PARTC,"PARTB");
            PARTE = new PARTEGroup(PARTB,"PARTE");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Proje No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "KARARBELGESIRAPORU";
            Caption = "Karar Belgesi Raporu_KİK021.0/M";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 10;
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