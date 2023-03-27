
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
    /// İlk Muayene Formu (EK-8.1)
    /// </summary>
    public partial class IlkMuayeneFormu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class Part1Group : TTReportGroup
        {
            public IlkMuayeneFormu MyParentReport
            {
                get { return (IlkMuayeneFormu)ParentReport; }
            }

            new public Part1GroupHeader Header()
            {
                return (Part1GroupHeader)_header;
            }

            new public Part1GroupFooter Footer()
            {
                return (Part1GroupFooter)_footer;
            }

            public TTReportField REQUESTDATEANDNO { get {return Header().REQUESTDATEANDNO;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField CIHAZADI { get {return Header().CIHAZADI;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField STOKNUMARASI { get {return Header().STOKNUMARASI;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField MARKAMODEL { get {return Header().MARKAMODEL;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField SERINO { get {return Header().SERINO;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField MIKTAR { get {return Header().MIKTAR;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField BIRLIK { get {return Header().BIRLIK;} }
            public TTReportField NewField31 { get {return Header().NewField31;} }
            public TTReportField NewField32 { get {return Header().NewField32;} }
            public TTReportField TESELLUMTARIHI { get {return Header().TESELLUMTARIHI;} }
            public TTReportField NewField33 { get {return Header().NewField33;} }
            public TTReportField MUAYENETARIHI { get {return Header().MUAYENETARIHI;} }
            public TTReportField NewField34 { get {return Header().NewField34;} }
            public TTReportField SIPARISNO { get {return Header().SIPARISNO;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField61 { get {return Header().NewField61;} }
            public TTReportField NewField62 { get {return Header().NewField62;} }
            public TTReportField NewField63 { get {return Header().NewField63;} }
            public TTReportField NewField36 { get {return Header().NewField36;} }
            public TTReportField NewField64 { get {return Header().NewField64;} }
            public TTReportField NewField65 { get {return Header().NewField65;} }
            public TTReportField NewField66 { get {return Header().NewField66;} }
            public TTReportField NewField26 { get {return Header().NewField26;} }
            public TTReportField REQUESTDATE { get {return Header().REQUESTDATE;} }
            public TTReportField mrk { get {return Header().mrk;} }
            public TTReportField mdl { get {return Header().mdl;} }
            public TTReportField NewField61_ { get {return Footer().NewField61_;} }
            public TTReportField NewField16_ { get {return Footer().NewField16_;} }
            public TTReportField NewField62_ { get {return Footer().NewField62_;} }
            public TTReportField REPAIR { get {return Footer().REPAIR;} }
            public TTReportField HEK { get {return Footer().HEK;} }
            public TTReportField CALIBRATION { get {return Footer().CALIBRATION;} }
            public TTReportField BASKAN { get {return Footer().BASKAN;} }
            public TTReportField UYE { get {return Footer().UYE;} }
            public TTReportField UYE1 { get {return Footer().UYE1;} }
            public TTReportField TEKNIKUYE { get {return Footer().TEKNIKUYE;} }
            public TTReportField HBASKAN { get {return Footer().HBASKAN;} }
            public TTReportField HUYE { get {return Footer().HUYE;} }
            public TTReportField HUYE1 { get {return Footer().HUYE1;} }
            public TTReportField HTEKNIKUYE { get {return Footer().HTEKNIKUYE;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
            public TTReportShape NewLine122 { get {return Footer().NewLine122;} }
            public TTReportShape NewLine123 { get {return Footer().NewLine123;} }
            public TTReportShape NewLine124 { get {return Footer().NewLine124;} }
            public Part1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Part1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ReferToUpperLevel.GetReferToUpperLevelByObjectIDQuery_Class>("GetReferToUpperLevelByObjectIDQuery", ReferToUpperLevel.GetReferToUpperLevelByObjectIDQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new Part1GroupHeader(this);
                _footer = new Part1GroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class Part1GroupHeader : TTReportSection
            {
                public IlkMuayeneFormu MyParentReport
                {
                    get { return (IlkMuayeneFormu)ParentReport; }
                }
                
                public TTReportField REQUESTDATEANDNO;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField CIHAZADI;
                public TTReportField NewField4;
                public TTReportField STOKNUMARASI;
                public TTReportField NewField5;
                public TTReportField MARKAMODEL;
                public TTReportField NewField6;
                public TTReportField SERINO;
                public TTReportField NewField7;
                public TTReportField MIKTAR;
                public TTReportField NewField13;
                public TTReportField BIRLIK;
                public TTReportField NewField31;
                public TTReportField NewField32;
                public TTReportField TESELLUMTARIHI;
                public TTReportField NewField33;
                public TTReportField MUAYENETARIHI;
                public TTReportField NewField34;
                public TTReportField SIPARISNO;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField61;
                public TTReportField NewField62;
                public TTReportField NewField63;
                public TTReportField NewField36;
                public TTReportField NewField64;
                public TTReportField NewField65;
                public TTReportField NewField66;
                public TTReportField NewField26;
                public TTReportField REQUESTDATE;
                public TTReportField mrk;
                public TTReportField mdl; 
                public Part1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 92;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REQUESTDATEANDNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 42, 262, 50, false);
                    REQUESTDATEANDNO.Name = "REQUESTDATEANDNO";
                    REQUESTDATEANDNO.FieldType = ReportFieldTypeEnum.ftExpression;
                    REQUESTDATEANDNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTDATEANDNO.Value = @"REQUESTDATE.FormattedValue + "" / "" + {#REQUESTNO#}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 20, 262, 34, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Size = 12;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"İLK MUAYENE FORMU";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 34, 56, 42, false);
                    NewField3.Name = "NewField3";
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"CİHAZIN ADI";

                    CIHAZADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 34, 133, 42, false);
                    CIHAZADI.Name = "CIHAZADI";
                    CIHAZADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    CIHAZADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CIHAZADI.WordBreak = EvetHayirEnum.ehEvet;
                    CIHAZADI.TextFont.CharSet = 162;
                    CIHAZADI.Value = @"{#FANAME#}";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 42, 56, 50, false);
                    NewField4.Name = "NewField4";
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"STOK NUMARASI";

                    STOKNUMARASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 42, 133, 50, false);
                    STOKNUMARASI.Name = "STOKNUMARASI";
                    STOKNUMARASI.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOKNUMARASI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOKNUMARASI.Value = @"{#NATOSTOCKNO#}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 50, 56, 58, false);
                    NewField5.Name = "NewField5";
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"MARKA VE MODEL";

                    MARKAMODEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 50, 133, 58, false);
                    MARKAMODEL.Name = "MARKAMODEL";
                    MARKAMODEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARKAMODEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARKAMODEL.Value = @"{#MARK#} {#MODEL#}";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 58, 56, 66, false);
                    NewField6.Name = "NewField6";
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"SERİ NUMARASI";

                    SERINO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 58, 133, 66, false);
                    SERINO.Name = "SERINO";
                    SERINO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERINO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SERINO.TextFont.CharSet = 162;
                    SERINO.Value = @"{#SERIALNUMBER#}";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 66, 56, 74, false);
                    NewField7.Name = "NewField7";
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"MİKTAR";

                    MIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 66, 133, 74, false);
                    MIKTAR.Name = "MIKTAR";
                    MIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MIKTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR.Value = @"{#AMOUNT#}";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 34, 182, 42, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"BİRLİĞİ";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 34, 262, 42, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIK.TextFont.Size = 7;
                    BIRLIK.TextFont.CharSet = 162;
                    BIRLIK.Value = @"{#SENDERMILITARYUNIT#}";

                    NewField31 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 42, 182, 50, false);
                    NewField31.Name = "NewField31";
                    NewField31.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField31.TextFont.CharSet = 162;
                    NewField31.Value = @"İSTEK VE İŞ EMRİ TARİH VE NU.";

                    NewField32 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 50, 182, 58, false);
                    NewField32.Name = "NewField32";
                    NewField32.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField32.TextFont.CharSet = 162;
                    NewField32.Value = @"TESELLÜM TARİHİ";

                    TESELLUMTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 50, 262, 58, false);
                    TESELLUMTARIHI.Name = "TESELLUMTARIHI";
                    TESELLUMTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESELLUMTARIHI.TextFormat = @"dd/MM/yyyy";
                    TESELLUMTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TESELLUMTARIHI.Value = @"{#ARRIVALDATE#}";

                    NewField33 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 58, 182, 66, false);
                    NewField33.Name = "NewField33";
                    NewField33.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField33.TextFont.CharSet = 162;
                    NewField33.Value = @"MUAYENE TARİHİ";

                    MUAYENETARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 58, 262, 66, false);
                    MUAYENETARIHI.Name = "MUAYENETARIHI";
                    MUAYENETARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENETARIHI.TextFormat = @"dd/MM/yyyy";
                    MUAYENETARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MUAYENETARIHI.Value = @"{#CHECKDATE#}";

                    NewField34 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 66, 182, 74, false);
                    NewField34.Name = "NewField34";
                    NewField34.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField34.TextFont.CharSet = 162;
                    NewField34.Value = @"SİPARİŞ NUMARASI";

                    SIPARISNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 66, 262, 74, false);
                    SIPARISNO.Name = "SIPARISNO";
                    SIPARISNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIPARISNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIPARISNO.Value = @"";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 74, 262, 82, false);
                    NewField15.Name = "NewField15";
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Size = 12;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"TAHLİYESİ GEREKEN MALZEMELER";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 82, 56, 92, false);
                    NewField16.Name = "NewField16";
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"STOK NUMARASI";

                    NewField61 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 82, 108, 92, false);
                    NewField61.Name = "NewField61";
                    NewField61.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField61.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField61.TextFont.CharSet = 162;
                    NewField61.Value = @"CİNSİ";

                    NewField62 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 82, 133, 92, false);
                    NewField62.Name = "NewField62";
                    NewField62.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField62.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField62.TextFont.CharSet = 162;
                    NewField62.Value = @"MİKTAR";

                    NewField63 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 82, 217, 87, false);
                    NewField63.Name = "NewField63";
                    NewField63.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField63.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField63.TextFont.CharSet = 162;
                    NewField63.Value = @"DURUMU";

                    NewField36 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 87, 154, 92, false);
                    NewField36.Name = "NewField36";
                    NewField36.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField36.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField36.TextFont.CharSet = 162;
                    NewField36.Value = @"NORMAL";

                    NewField64 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 87, 175, 92, false);
                    NewField64.Name = "NewField64";
                    NewField64.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField64.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField64.TextFont.CharSet = 162;
                    NewField64.Value = @"HASARLI";

                    NewField65 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 87, 196, 92, false);
                    NewField65.Name = "NewField65";
                    NewField65.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField65.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField65.TextFont.CharSet = 162;
                    NewField65.Value = @"DEĞİŞİK";

                    NewField66 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 196, 87, 217, 92, false);
                    NewField66.Name = "NewField66";
                    NewField66.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField66.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField66.TextFont.CharSet = 162;
                    NewField66.Value = @"EKSİK";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 82, 262, 92, false);
                    NewField26.Name = "NewField26";
                    NewField26.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField26.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField26.TextFont.CharSet = 162;
                    NewField26.Value = @"DÜŞÜNCELER";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 292, 40, 317, 45, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.Visible = EvetHayirEnum.ehHayir;
                    REQUESTDATE.DrawStyle = DrawStyleConstants.vbInvisible;
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"dd/MM/yyyy";
                    REQUESTDATE.TextFont.Name = "Arial Narrow";
                    REQUESTDATE.TextFont.Size = 10;
                    REQUESTDATE.TextFont.CharSet = 1;
                    REQUESTDATE.Value = @"{#REQUESTDATE#}";

                    mrk = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 296, 62, 321, 67, false);
                    mrk.Name = "mrk";
                    mrk.Visible = EvetHayirEnum.ehHayir;
                    mrk.DrawStyle = DrawStyleConstants.vbInvisible;
                    mrk.FieldType = ReportFieldTypeEnum.ftVariable;
                    mrk.TextFont.Name = "Arial Narrow";
                    mrk.TextFont.Size = 10;
                    mrk.TextFont.CharSet = 1;
                    mrk.Value = @"{#MARK#}";

                    mdl = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 295, 74, 320, 79, false);
                    mdl.Name = "mdl";
                    mdl.DrawStyle = DrawStyleConstants.vbInvisible;
                    mdl.FieldType = ReportFieldTypeEnum.ftVariable;
                    mdl.TextFont.Name = "Arial Narrow";
                    mdl.TextFont.Size = 10;
                    mdl.TextFont.CharSet = 1;
                    mdl.Value = @"{#MODEL#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReferToUpperLevel.GetReferToUpperLevelByObjectIDQuery_Class dataset_GetReferToUpperLevelByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<ReferToUpperLevel.GetReferToUpperLevelByObjectIDQuery_Class>(0);
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    CIHAZADI.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.Faname) : "");
                    NewField4.CalcValue = NewField4.Value;
                    STOKNUMARASI.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.NATOStockNO) : "");
                    NewField5.CalcValue = NewField5.Value;
                    MARKAMODEL.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.Mark) : "") + @" " + (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.Model) : "");
                    NewField6.CalcValue = NewField6.Value;
                    SERINO.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.SerialNumber) : "");
                    NewField7.CalcValue = NewField7.Value;
                    MIKTAR.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.Amount) : "");
                    NewField13.CalcValue = NewField13.Value;
                    BIRLIK.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.Sendermilitaryunit) : "");
                    NewField31.CalcValue = NewField31.Value;
                    NewField32.CalcValue = NewField32.Value;
                    TESELLUMTARIHI.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.ArrivalDate) : "");
                    NewField33.CalcValue = NewField33.Value;
                    MUAYENETARIHI.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.CheckDate) : "");
                    NewField34.CalcValue = NewField34.Value;
                    SIPARISNO.CalcValue = @"";
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField61.CalcValue = NewField61.Value;
                    NewField62.CalcValue = NewField62.Value;
                    NewField63.CalcValue = NewField63.Value;
                    NewField36.CalcValue = NewField36.Value;
                    NewField64.CalcValue = NewField64.Value;
                    NewField65.CalcValue = NewField65.Value;
                    NewField66.CalcValue = NewField66.Value;
                    NewField26.CalcValue = NewField26.Value;
                    REQUESTDATE.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.RequestDate) : "");
                    mrk.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.Mark) : "");
                    mdl.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.Model) : "");
                    REQUESTDATEANDNO.CalcValue = REQUESTDATE.FormattedValue + " / " + (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.RequestNo) : "");
                    return new TTReportObject[] { NewField2,NewField3,CIHAZADI,NewField4,STOKNUMARASI,NewField5,MARKAMODEL,NewField6,SERINO,NewField7,MIKTAR,NewField13,BIRLIK,NewField31,NewField32,TESELLUMTARIHI,NewField33,MUAYENETARIHI,NewField34,SIPARISNO,NewField15,NewField16,NewField61,NewField62,NewField63,NewField36,NewField64,NewField65,NewField66,NewField26,REQUESTDATE,mrk,mdl,REQUESTDATEANDNO};
                }

                public override void RunScript()
                {
#region PART1 HEADER_Script
                    // MARKAMODEL.CalcValue = mrk.Name + " " + mdl.Name;
#endregion PART1 HEADER_Script
                }
            }
            public partial class Part1GroupFooter : TTReportSection
            {
                public IlkMuayeneFormu MyParentReport
                {
                    get { return (IlkMuayeneFormu)ParentReport; }
                }
                
                public TTReportField NewField61_;
                public TTReportField NewField16_;
                public TTReportField NewField62_;
                public TTReportField REPAIR;
                public TTReportField HEK;
                public TTReportField CALIBRATION;
                public TTReportField BASKAN;
                public TTReportField UYE;
                public TTReportField UYE1;
                public TTReportField TEKNIKUYE;
                public TTReportField HBASKAN;
                public TTReportField HUYE;
                public TTReportField HUYE1;
                public TTReportField HTEKNIKUYE;
                public TTReportShape NewLine121;
                public TTReportShape NewLine122;
                public TTReportShape NewLine123;
                public TTReportShape NewLine124; 
                public Part1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 60;
                    RepeatCount = 0;
                    
                    NewField61_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 56, 46, false);
                    NewField61_.Name = "NewField61_";
                    NewField61_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField61_.MultiLine = EvetHayirEnum.ehEvet;
                    NewField61_.TextFont.CharSet = 162;
                    NewField61_.Value = @"

ONARIM

HEK

KALİBRASYON";

                    NewField16_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 0, 262, 6, false);
                    NewField16_.Name = "NewField16_";
                    NewField16_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16_.TextFont.Name = "Arial Narrow";
                    NewField16_.TextFont.Bold = true;
                    NewField16_.TextFont.CharSet = 162;
                    NewField16_.Value = @"İLGİLİ ONAYLAR";

                    NewField62_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 6, 262, 46, false);
                    NewField62_.Name = "NewField62_";
                    NewField62_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField62_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField62_.TextFont.CharSet = 162;
                    NewField62_.Value = @"";

                    REPAIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 8, 52, 12, false);
                    REPAIR.Name = "REPAIR";
                    REPAIR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPAIR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPAIR.TextFont.Size = 10;
                    REPAIR.TextFont.CharSet = 162;
                    REPAIR.Value = @"";

                    HEK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 16, 52, 20, false);
                    HEK.Name = "HEK";
                    HEK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEK.TextFont.Size = 10;
                    HEK.TextFont.CharSet = 162;
                    HEK.Value = @"";

                    CALIBRATION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 23, 52, 27, false);
                    CALIBRATION.Name = "CALIBRATION";
                    CALIBRATION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CALIBRATION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CALIBRATION.TextFont.Size = 10;
                    CALIBRATION.TextFont.CharSet = 162;
                    CALIBRATION.Value = @"";

                    BASKAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 8, 96, 13, false);
                    BASKAN.Name = "BASKAN";
                    BASKAN.DrawStyle = DrawStyleConstants.vbInvisible;
                    BASKAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASKAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASKAN.WordBreak = EvetHayirEnum.ehEvet;
                    BASKAN.TextFont.Name = "Arial Narrow";
                    BASKAN.TextFont.Size = 10;
                    BASKAN.TextFont.Bold = true;
                    BASKAN.TextFont.CharSet = 162;
                    BASKAN.Value = @"BAŞKAN";

                    UYE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 8, 140, 13, false);
                    UYE.Name = "UYE";
                    UYE.DrawStyle = DrawStyleConstants.vbInvisible;
                    UYE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UYE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UYE.WordBreak = EvetHayirEnum.ehEvet;
                    UYE.TextFont.Name = "Arial Narrow";
                    UYE.TextFont.Size = 10;
                    UYE.TextFont.Bold = true;
                    UYE.TextFont.CharSet = 162;
                    UYE.Value = @"ÜYE";

                    UYE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 8, 187, 13, false);
                    UYE1.Name = "UYE1";
                    UYE1.DrawStyle = DrawStyleConstants.vbInvisible;
                    UYE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UYE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UYE1.WordBreak = EvetHayirEnum.ehEvet;
                    UYE1.TextFont.Name = "Arial Narrow";
                    UYE1.TextFont.Size = 10;
                    UYE1.TextFont.Bold = true;
                    UYE1.TextFont.CharSet = 162;
                    UYE1.Value = @"ÜYE";

                    TEKNIKUYE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 8, 244, 13, false);
                    TEKNIKUYE.Name = "TEKNIKUYE";
                    TEKNIKUYE.DrawStyle = DrawStyleConstants.vbInvisible;
                    TEKNIKUYE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKNIKUYE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKNIKUYE.WordBreak = EvetHayirEnum.ehEvet;
                    TEKNIKUYE.TextFont.Name = "Arial Narrow";
                    TEKNIKUYE.TextFont.Size = 10;
                    TEKNIKUYE.TextFont.Bold = true;
                    TEKNIKUYE.TextFont.CharSet = 162;
                    TEKNIKUYE.Value = @"TEKNİK ÜYE";

                    HBASKAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 27, 96, 44, false);
                    HBASKAN.Name = "HBASKAN";
                    HBASKAN.DrawStyle = DrawStyleConstants.vbInvisible;
                    HBASKAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    HBASKAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HBASKAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HBASKAN.MultiLine = EvetHayirEnum.ehEvet;
                    HBASKAN.WordBreak = EvetHayirEnum.ehEvet;
                    HBASKAN.TextFont.Name = "Arial Narrow";
                    HBASKAN.TextFont.Size = 10;
                    HBASKAN.TextFont.CharSet = 162;
                    HBASKAN.Value = @"";

                    HUYE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 27, 140, 45, false);
                    HUYE.Name = "HUYE";
                    HUYE.DrawStyle = DrawStyleConstants.vbInvisible;
                    HUYE.FieldType = ReportFieldTypeEnum.ftVariable;
                    HUYE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HUYE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HUYE.MultiLine = EvetHayirEnum.ehEvet;
                    HUYE.WordBreak = EvetHayirEnum.ehEvet;
                    HUYE.TextFont.Name = "Arial Narrow";
                    HUYE.TextFont.Size = 10;
                    HUYE.TextFont.CharSet = 162;
                    HUYE.Value = @"";

                    HUYE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 27, 188, 45, false);
                    HUYE1.Name = "HUYE1";
                    HUYE1.DrawStyle = DrawStyleConstants.vbInvisible;
                    HUYE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    HUYE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HUYE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HUYE1.MultiLine = EvetHayirEnum.ehEvet;
                    HUYE1.WordBreak = EvetHayirEnum.ehEvet;
                    HUYE1.TextFont.Name = "Arial Narrow";
                    HUYE1.TextFont.Size = 10;
                    HUYE1.TextFont.CharSet = 162;
                    HUYE1.Value = @"";

                    HTEKNIKUYE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 28, 244, 45, false);
                    HTEKNIKUYE.Name = "HTEKNIKUYE";
                    HTEKNIKUYE.DrawStyle = DrawStyleConstants.vbInvisible;
                    HTEKNIKUYE.FieldType = ReportFieldTypeEnum.ftVariable;
                    HTEKNIKUYE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HTEKNIKUYE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HTEKNIKUYE.MultiLine = EvetHayirEnum.ehEvet;
                    HTEKNIKUYE.WordBreak = EvetHayirEnum.ehEvet;
                    HTEKNIKUYE.TextFont.Name = "Arial Narrow";
                    HTEKNIKUYE.TextFont.Size = 10;
                    HTEKNIKUYE.TextFont.CharSet = 162;
                    HTEKNIKUYE.Value = @"";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 68, 13, 91, 13, false);
                    NewLine121.Name = "NewLine121";

                    NewLine122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 113, 13, 136, 13, false);
                    NewLine122.Name = "NewLine122";

                    NewLine123 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 160, 13, 183, 13, false);
                    NewLine123.Name = "NewLine123";

                    NewLine124 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 217, 13, 240, 13, false);
                    NewLine124.Name = "NewLine124";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReferToUpperLevel.GetReferToUpperLevelByObjectIDQuery_Class dataset_GetReferToUpperLevelByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<ReferToUpperLevel.GetReferToUpperLevelByObjectIDQuery_Class>(0);
                    NewField61_.CalcValue = NewField61_.Value;
                    NewField16_.CalcValue = NewField16_.Value;
                    NewField62_.CalcValue = NewField62_.Value;
                    REPAIR.CalcValue = REPAIR.Value;
                    HEK.CalcValue = HEK.Value;
                    CALIBRATION.CalcValue = CALIBRATION.Value;
                    BASKAN.CalcValue = BASKAN.Value;
                    UYE.CalcValue = UYE.Value;
                    UYE1.CalcValue = UYE1.Value;
                    TEKNIKUYE.CalcValue = TEKNIKUYE.Value;
                    HBASKAN.CalcValue = @"";
                    HUYE.CalcValue = @"";
                    HUYE1.CalcValue = @"";
                    HTEKNIKUYE.CalcValue = @"";
                    return new TTReportObject[] { NewField61_,NewField16_,NewField62_,REPAIR,HEK,CALIBRATION,BASKAN,UYE,UYE1,TEKNIKUYE,HBASKAN,HUYE,HUYE1,HTEKNIKUYE};
                }

                public override void RunScript()
                {
#region PART1 FOOTER_Script
                    string objectID = ((IlkMuayeneFormu)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            ReferToUpperLevel rtul = (ReferToUpperLevel)ctx.GetObject(new Guid(objectID), typeof(ReferToUpperLevel));
            bool tecnicalMember = false;
            string chefString = string.Empty;
            string smember1 = string.Empty;
            string smember2 = string.Empty;
            string tMember = string.Empty;
            switch(TTObjectClasses.Common.GetEnumValueDefOfEnumValue(rtul.FirstExamStatus).Name.ToString())
            {
                case "Repair":
                    REPAIR.CalcValue = " X";
                    break;
                case "HEK":
                    HEK.CalcValue = " X";
                    break;
                case "Calibration":
                    CALIBRATION.CalcValue = " X";
                    break;
            }
            

            foreach (CommisionMember member in rtul.CommisionMembers)
            {
                if (member.MemberDuty == CommisionMemberDutyEnum.Chief)
                {
                    chefString += member.ResUser.Name + "\r\n";
                    if (member.ResUser.MilitaryClass != null)
                        chefString += member.ResUser.MilitaryClass.ShortName;
                    if (member.ResUser.Rank != null)
                        chefString += member.ResUser.Rank.ShortName + "\r\n";
                    chefString += "(" + member.ResUser.EmploymentRecordID + ")";
                    HBASKAN.CalcValue = chefString;
                }
                if (member.MemberDuty == CommisionMemberDutyEnum.TechnicalMember)
                {
                    
                    tMember += member.ResUser.Name + "\r\n";
                    if (member.ResUser.MilitaryClass != null)
                        tMember += member.ResUser.MilitaryClass.ShortName;
                    if (member.ResUser.Rank != null)
                        tMember += member.ResUser.Rank.ShortName + "\r\n";
                    tMember += "(" + member.ResUser.EmploymentRecordID + ")";
                    HTEKNIKUYE.CalcValue = tMember;
                    
                }
                if (member.MemberDuty == CommisionMemberDutyEnum.Member)
                {
                    if (tecnicalMember == false)
                    {
                        smember1 += member.ResUser.Name + "\r\n";
                        if (member.ResUser.MilitaryClass != null)
                            smember1 += member.ResUser.MilitaryClass.ShortName;
                        if (member.ResUser.Rank != null)
                            smember1 += member.ResUser.Rank.ShortName + "\r\n";
                        smember1 += "(" + member.ResUser.EmploymentRecordID + ")";
                        HUYE.CalcValue = smember1;
                        tecnicalMember = true;
                    }
                    else
                    {
                        smember2 += member.ResUser.Name + "\r\n";
                        if (member.ResUser.MilitaryClass != null)
                            smember2 += member.ResUser.MilitaryClass.ShortName;
                        if (member.ResUser.Rank != null)
                            smember2 += member.ResUser.Rank.ShortName + "\r\n";
                        smember2 += "(" + member.ResUser.EmploymentRecordID + ")";
                        HUYE1.CalcValue = smember2;
                    }
                }
            }
#endregion PART1 FOOTER_Script
                }
            }

        }

        public Part1Group Part1;

        public partial class MAINGroup : TTReportGroup
        {
            public IlkMuayeneFormu MyParentReport
            {
                get { return (IlkMuayeneFormu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField STOKNO { get {return Body().STOKNO;} }
            public TTReportField CINSI { get {return Body().CINSI;} }
            public TTReportField MIKTAR { get {return Body().MIKTAR;} }
            public TTReportField ISNORMAL { get {return Body().ISNORMAL;} }
            public TTReportField ISDAMAGED { get {return Body().ISDAMAGED;} }
            public TTReportField ISDIFFERENT { get {return Body().ISDIFFERENT;} }
            public TTReportField ISMISSING { get {return Body().ISMISSING;} }
            public TTReportField COMMENTS { get {return Body().COMMENTS;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine15 { get {return Body().NewLine15;} }
            public TTReportShape NewLine16 { get {return Body().NewLine16;} }
            public TTReportShape NewLine17 { get {return Body().NewLine17;} }
            public TTReportShape NewLine18 { get {return Body().NewLine18;} }
            public TTReportField NORMAL1 { get {return Body().NORMAL1;} }
            public TTReportField DAMAGED1 { get {return Body().DAMAGED1;} }
            public TTReportField CHANGED1 { get {return Body().CHANGED1;} }
            public TTReportField MISSING1 { get {return Body().MISSING1;} }
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
                list[0] = new TTReportNqlData<ReferToUpperLevel.GetRULDetailsByObjectIDQuery_Class>("GetRULDetailsByObjectIDQuery", ReferToUpperLevel.GetRULDetailsByObjectIDQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public IlkMuayeneFormu MyParentReport
                {
                    get { return (IlkMuayeneFormu)ParentReport; }
                }
                
                public TTReportField STOKNO;
                public TTReportField CINSI;
                public TTReportField MIKTAR;
                public TTReportField ISNORMAL;
                public TTReportField ISDAMAGED;
                public TTReportField ISDIFFERENT;
                public TTReportField ISMISSING;
                public TTReportField COMMENTS;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16;
                public TTReportShape NewLine17;
                public TTReportShape NewLine18;
                public TTReportField NORMAL1;
                public TTReportField DAMAGED1;
                public TTReportField CHANGED1;
                public TTReportField MISSING1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    STOKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 56, 10, false);
                    STOKNO.Name = "STOKNO";
                    STOKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STOKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOKNO.TextFont.CharSet = 162;
                    STOKNO.Value = @"";

                    CINSI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 0, 108, 10, false);
                    CINSI.Name = "CINSI";
                    CINSI.FieldType = ReportFieldTypeEnum.ftVariable;
                    CINSI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CINSI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CINSI.TextFont.CharSet = 162;
                    CINSI.Value = @"{#ITEMNAME#}";

                    MIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 0, 133, 10, false);
                    MIKTAR.Name = "MIKTAR";
                    MIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MIKTAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR.TextFont.CharSet = 162;
                    MIKTAR.Value = @"{#AMOUNT#}";

                    ISNORMAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 0, 154, 10, false);
                    ISNORMAL.Name = "ISNORMAL";
                    ISNORMAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISNORMAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ISNORMAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISNORMAL.TextFont.CharSet = 162;
                    ISNORMAL.Value = @"";

                    ISDAMAGED = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 0, 175, 10, false);
                    ISDAMAGED.Name = "ISDAMAGED";
                    ISDAMAGED.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISDAMAGED.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ISDAMAGED.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISDAMAGED.TextFont.CharSet = 162;
                    ISDAMAGED.Value = @"";

                    ISDIFFERENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 0, 196, 10, false);
                    ISDIFFERENT.Name = "ISDIFFERENT";
                    ISDIFFERENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISDIFFERENT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ISDIFFERENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISDIFFERENT.TextFont.CharSet = 162;
                    ISDIFFERENT.Value = @"";

                    ISMISSING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 196, 0, 217, 10, false);
                    ISMISSING.Name = "ISMISSING";
                    ISMISSING.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISMISSING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ISMISSING.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISMISSING.TextFont.CharSet = 162;
                    ISMISSING.Value = @"";

                    COMMENTS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 0, 262, 10, false);
                    COMMENTS.Name = "COMMENTS";
                    COMMENTS.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMMENTS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMMENTS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COMMENTS.TextFont.CharSet = 162;
                    COMMENTS.Value = @"{#COMMENTS#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 0, 20, 10, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 56, 0, 56, 10, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 108, 0, 108, 10, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 133, 0, 133, 10, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 154, 0, 154, 10, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 175, 0, 175, 10, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 196, 0, 196, 10, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 217, 0, 217, 10, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 262, 0, 262, 10, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.ExtendTo = ExtendToEnum.extSectionHeight;

                    NORMAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 294, 5, 309, 10, false);
                    NORMAL1.Name = "NORMAL1";
                    NORMAL1.Visible = EvetHayirEnum.ehHayir;
                    NORMAL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NORMAL1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NORMAL1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NORMAL1.TextFont.Size = 10;
                    NORMAL1.TextFont.CharSet = 162;
                    NORMAL1.Value = @"{#ISNORMAL#}";

                    DAMAGED1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 310, 5, 325, 10, false);
                    DAMAGED1.Name = "DAMAGED1";
                    DAMAGED1.Visible = EvetHayirEnum.ehHayir;
                    DAMAGED1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAMAGED1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DAMAGED1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DAMAGED1.TextFont.Size = 10;
                    DAMAGED1.TextFont.CharSet = 162;
                    DAMAGED1.Value = @"{#ISDAMAGED#}";

                    CHANGED1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 326, 5, 340, 10, false);
                    CHANGED1.Name = "CHANGED1";
                    CHANGED1.Visible = EvetHayirEnum.ehHayir;
                    CHANGED1.FieldType = ReportFieldTypeEnum.ftVariable;
                    CHANGED1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CHANGED1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CHANGED1.TextFont.Size = 10;
                    CHANGED1.TextFont.CharSet = 162;
                    CHANGED1.Value = @"{#ISCHANGED#}";

                    MISSING1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 342, 5, 354, 10, false);
                    MISSING1.Name = "MISSING1";
                    MISSING1.Visible = EvetHayirEnum.ehHayir;
                    MISSING1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MISSING1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MISSING1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MISSING1.TextFont.Size = 10;
                    MISSING1.TextFont.CharSet = 162;
                    MISSING1.Value = @"{#ISMISSING#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReferToUpperLevel.GetRULDetailsByObjectIDQuery_Class dataset_GetRULDetailsByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<ReferToUpperLevel.GetRULDetailsByObjectIDQuery_Class>(0);
                    STOKNO.CalcValue = @"";
                    CINSI.CalcValue = (dataset_GetRULDetailsByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetRULDetailsByObjectIDQuery.ItemName) : "");
                    MIKTAR.CalcValue = (dataset_GetRULDetailsByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetRULDetailsByObjectIDQuery.Amount) : "");
                    ISNORMAL.CalcValue = @"";
                    ISDAMAGED.CalcValue = @"";
                    ISDIFFERENT.CalcValue = @"";
                    ISMISSING.CalcValue = @"";
                    COMMENTS.CalcValue = (dataset_GetRULDetailsByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetRULDetailsByObjectIDQuery.Comments) : "");
                    NORMAL1.CalcValue = (dataset_GetRULDetailsByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetRULDetailsByObjectIDQuery.IsNormal) : "");
                    DAMAGED1.CalcValue = (dataset_GetRULDetailsByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetRULDetailsByObjectIDQuery.IsDamaged) : "");
                    CHANGED1.CalcValue = (dataset_GetRULDetailsByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetRULDetailsByObjectIDQuery.IsChanged) : "");
                    MISSING1.CalcValue = (dataset_GetRULDetailsByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetRULDetailsByObjectIDQuery.IsMissing) : "");
                    return new TTReportObject[] { STOKNO,CINSI,MIKTAR,ISNORMAL,ISDAMAGED,ISDIFFERENT,ISMISSING,COMMENTS,NORMAL1,DAMAGED1,CHANGED1,MISSING1};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (MISSING1.CalcValue == "True")
            {
                ISMISSING.CalcValue = "X";
            }
            if (CHANGED1.CalcValue == "True")
            {
                ISDIFFERENT.CalcValue = "X";
            }
            if (DAMAGED1.CalcValue == "True")
            {
                ISDAMAGED.CalcValue = "X";
            }
            if (NORMAL1.CalcValue == "True")
            {
                ISNORMAL.CalcValue = "X";
            }
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

        public IlkMuayeneFormu()
        {
            Part1 = new Part1Group(this,"Part1");
            MAIN = new MAINGroup(Part1,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "ILKMUAYENEFORMU";
            Caption = "İlk Muayene Formu (EK-8.1)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            PaperSize = 1;
            p_PageWidth = 216;
            p_PageHeight = 279;
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
            fd.TextFont.Name = "Arial";
            fd.TextFont.Size = 9;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 0;
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