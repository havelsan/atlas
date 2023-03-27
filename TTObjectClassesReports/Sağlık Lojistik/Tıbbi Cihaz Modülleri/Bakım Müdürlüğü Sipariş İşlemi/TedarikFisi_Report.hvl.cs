
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
    /// Tedarik Fişi (Ek-9.9)
    /// </summary>
    public partial class TedarikFisi : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class Part1Group : TTReportGroup
        {
            public TedarikFisi MyParentReport
            {
                get { return (TedarikFisi)ParentReport; }
            }

            new public Part1GroupHeader Header()
            {
                return (Part1GroupHeader)_header;
            }

            new public Part1GroupFooter Footer()
            {
                return (Part1GroupFooter)_footer;
            }

            public TTReportField ISTEKTARIHI { get {return Header().ISTEKTARIHI;} }
            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField SIPARISNO { get {return Header().SIPARISNO;} }
            public TTReportField ONARIMDANSORUMLUKISIM { get {return Header().ONARIMDANSORUMLUKISIM;} }
            public TTReportField SAYMANLIKKAYITNO { get {return Header().SAYMANLIKKAYITNO;} }
            public TTReportField AITOLDUGUANAMALZEME { get {return Header().AITOLDUGUANAMALZEME;} }
            public TTReportField ANAMLZSERINO { get {return Header().ANAMLZSERINO;} }
            public TTReportField MARKAMODELI { get {return Header().MARKAMODELI;} }
            public TTReportField BIRLIGI { get {return Header().BIRLIGI;} }
            public TTReportField NewField61 { get {return Header().NewField61;} }
            public TTReportField NewField71 { get {return Header().NewField71;} }
            public TTReportField IKMALVERILISTARIHI { get {return Header().IKMALVERILISTARIHI;} }
            public TTReportField TEDARIKIKMALKAYITNO { get {return Header().TEDARIKIKMALKAYITNO;} }
            public TTReportField NewField81 { get {return Header().NewField81;} }
            public TTReportField NewField72 { get {return Header().NewField72;} }
            public TTReportField NewField73 { get {return Header().NewField73;} }
            public TTReportField NewField74 { get {return Header().NewField74;} }
            public TTReportField KULLANICI_ { get {return Footer().KULLANICI_;} }
            public TTReportField KULLANICI { get {return Footer().KULLANICI;} }
            public TTReportField KULLANICI_2 { get {return Footer().KULLANICI_2;} }
            public TTReportField KISIMAMIRI { get {return Footer().KISIMAMIRI;} }
            public TTReportField KULLANICI_3 { get {return Footer().KULLANICI_3;} }
            public TTReportField ONARIMBOLUMAMIRI { get {return Footer().ONARIMBOLUMAMIRI;} }
            public TTReportField KULLANICI_4 { get {return Footer().KULLANICI_4;} }
            public TTReportField BAKIMMUDURU { get {return Footer().BAKIMMUDURU;} }
            public TTReportField KULLANICI_5 { get {return Footer().KULLANICI_5;} }
            public TTReportField MALSORUMLUSU { get {return Footer().MALSORUMLUSU;} }
            public TTReportField KULLANICI_6 { get {return Footer().KULLANICI_6;} }
            public TTReportField SAYMAN { get {return Footer().SAYMAN;} }
            public TTReportField KULLANICI_7 { get {return Footer().KULLANICI_7;} }
            public TTReportField TEDARIKKISIMSUBAYI { get {return Footer().TEDARIKKISIMSUBAYI;} }
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
                list[0] = new TTReportNqlData<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>("GetMaintenanceOrderByObjectIDQuery", MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public TedarikFisi MyParentReport
                {
                    get { return (TedarikFisi)ParentReport; }
                }
                
                public TTReportField ISTEKTARIHI;
                public TTReportField NewField;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField9;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField NewField1;
                public TTReportField NewField21;
                public TTReportField SIPARISNO;
                public TTReportField ONARIMDANSORUMLUKISIM;
                public TTReportField SAYMANLIKKAYITNO;
                public TTReportField AITOLDUGUANAMALZEME;
                public TTReportField ANAMLZSERINO;
                public TTReportField MARKAMODELI;
                public TTReportField BIRLIGI;
                public TTReportField NewField61;
                public TTReportField NewField71;
                public TTReportField IKMALVERILISTARIHI;
                public TTReportField TEDARIKIKMALKAYITNO;
                public TTReportField NewField81;
                public TTReportField NewField72;
                public TTReportField NewField73;
                public TTReportField NewField74; 
                public Part1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 121;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ISTEKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 40, 129, 50, false);
                    ISTEKTARIHI.Name = "ISTEKTARIHI";
                    ISTEKTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISTEKTARIHI.TextFormat = @"Short Date";
                    ISTEKTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISTEKTARIHI.TextFont.Name = "Arial";
                    ISTEKTARIHI.TextFont.CharSet = 162;
                    ISTEKTARIHI.Value = @" {#REQUESTDATE#}";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 19, 272, 30, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField.TextFont.Name = "Arial";
                    NewField.TextFont.Size = 12;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"TEDARİK FİŞİ";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 30, 69, 40, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @" SİPARİŞ NO";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 40, 69, 50, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @" İSTEK TARİHİ";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 50, 69, 60, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @" ONARIMDAN SORUMLU KISIM";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 60, 69, 70, false);
                    NewField8.Name = "NewField8";
                    NewField8.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8.TextFont.Name = "Arial";
                    NewField8.TextFont.Bold = true;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @" SAYMANLIK KAYIT NO";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 90, 69, 108, false);
                    NewField9.Name = "NewField9";
                    NewField9.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9.TextFont.Name = "Arial";
                    NewField9.TextFont.Bold = true;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @"STOK NO";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 90, 164, 108, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"MALZEMENİN ADI";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 90, 189, 108, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.MultiLine = EvetHayirEnum.ehEvet;
                    NewField17.WordBreak = EvetHayirEnum.ehEvet;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"ATÖLYE
İHTİYACI
İSTENEN
MİKTAR";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 30, 164, 40, false);
                    NewField18.Name = "NewField18";
                    NewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18.MultiLine = EvetHayirEnum.ehEvet;
                    NewField18.WordBreak = EvetHayirEnum.ehEvet;
                    NewField18.TextFont.Name = "Arial";
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @" AİT OLDUĞU 
 ANA MALZEME";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 40, 164, 50, false);
                    NewField19.Name = "NewField19";
                    NewField19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.MultiLine = EvetHayirEnum.ehEvet;
                    NewField19.WordBreak = EvetHayirEnum.ehEvet;
                    NewField19.TextFont.Name = "Arial";
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @" ANA MLZ.SERİ 
 NU. (VARSA)";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 50, 164, 70, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @" MARKA VE MODELİ";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 70, 164, 90, false);
                    NewField21.Name = "NewField21";
                    NewField21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21.TextFont.Name = "Arial";
                    NewField21.TextFont.Bold = true;
                    NewField21.TextFont.CharSet = 162;
                    NewField21.Value = @" BİRLİĞİ";

                    SIPARISNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 30, 129, 40, false);
                    SIPARISNO.Name = "SIPARISNO";
                    SIPARISNO.DrawStyle = DrawStyleConstants.vbSolid;
                    SIPARISNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIPARISNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIPARISNO.TextFont.Name = "Arial";
                    SIPARISNO.TextFont.CharSet = 162;
                    SIPARISNO.Value = @" {#ORDERNO#}";

                    ONARIMDANSORUMLUKISIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 50, 129, 60, false);
                    ONARIMDANSORUMLUKISIM.Name = "ONARIMDANSORUMLUKISIM";
                    ONARIMDANSORUMLUKISIM.DrawStyle = DrawStyleConstants.vbSolid;
                    ONARIMDANSORUMLUKISIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONARIMDANSORUMLUKISIM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ONARIMDANSORUMLUKISIM.TextFont.Name = "Arial";
                    ONARIMDANSORUMLUKISIM.TextFont.CharSet = 162;
                    ONARIMDANSORUMLUKISIM.Value = @" {#WORKSHOP#}";

                    SAYMANLIKKAYITNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 60, 129, 70, false);
                    SAYMANLIKKAYITNO.Name = "SAYMANLIKKAYITNO";
                    SAYMANLIKKAYITNO.DrawStyle = DrawStyleConstants.vbSolid;
                    SAYMANLIKKAYITNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAYMANLIKKAYITNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SAYMANLIKKAYITNO.TextFont.Name = "Arial";
                    SAYMANLIKKAYITNO.TextFont.CharSet = 162;
                    SAYMANLIKKAYITNO.Value = @"";

                    AITOLDUGUANAMALZEME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 30, 272, 40, false);
                    AITOLDUGUANAMALZEME.Name = "AITOLDUGUANAMALZEME";
                    AITOLDUGUANAMALZEME.DrawStyle = DrawStyleConstants.vbSolid;
                    AITOLDUGUANAMALZEME.FieldType = ReportFieldTypeEnum.ftVariable;
                    AITOLDUGUANAMALZEME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AITOLDUGUANAMALZEME.TextFont.Name = "Arial";
                    AITOLDUGUANAMALZEME.TextFont.CharSet = 162;
                    AITOLDUGUANAMALZEME.Value = @" {#FIXEDASSETNAME#}";

                    ANAMLZSERINO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 40, 272, 50, false);
                    ANAMLZSERINO.Name = "ANAMLZSERINO";
                    ANAMLZSERINO.DrawStyle = DrawStyleConstants.vbSolid;
                    ANAMLZSERINO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ANAMLZSERINO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ANAMLZSERINO.TextFont.Name = "Arial";
                    ANAMLZSERINO.TextFont.CharSet = 162;
                    ANAMLZSERINO.Value = @" {#SERIALNUMBER#}";

                    MARKAMODELI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 50, 272, 70, false);
                    MARKAMODELI.Name = "MARKAMODELI";
                    MARKAMODELI.DrawStyle = DrawStyleConstants.vbSolid;
                    MARKAMODELI.FieldType = ReportFieldTypeEnum.ftExpression;
                    MARKAMODELI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARKAMODELI.TextFont.Name = "Arial";
                    MARKAMODELI.TextFont.CharSet = 162;
                    MARKAMODELI.Value = @""" "" + {#MARK#} + "" - "" + {#MODEL#}";

                    BIRLIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 70, 272, 90, false);
                    BIRLIGI.Name = "BIRLIGI";
                    BIRLIGI.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRLIGI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIGI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRLIGI.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIGI.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIGI.TextFont.Name = "Arial";
                    BIRLIGI.TextFont.CharSet = 162;
                    BIRLIGI.Value = @"
{#OWNERMILITARYUNIT#}";

                    NewField61 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 70, 69, 80, false);
                    NewField61.Name = "NewField61";
                    NewField61.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField61.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField61.MultiLine = EvetHayirEnum.ehEvet;
                    NewField61.WordBreak = EvetHayirEnum.ehEvet;
                    NewField61.TextFont.Name = "Arial";
                    NewField61.TextFont.Bold = true;
                    NewField61.TextFont.CharSet = 162;
                    NewField61.Value = @" İKMAL MÜDÜRLÜĞÜ/TEDARİK 
 KISMINA VERİLİŞ TARİHİ";

                    NewField71 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 80, 69, 90, false);
                    NewField71.Name = "NewField71";
                    NewField71.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField71.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField71.MultiLine = EvetHayirEnum.ehEvet;
                    NewField71.WordBreak = EvetHayirEnum.ehEvet;
                    NewField71.TextFont.Name = "Arial";
                    NewField71.TextFont.Bold = true;
                    NewField71.TextFont.CharSet = 162;
                    NewField71.Value = @" TEDARİK İKMAL KAYIT 
 KÜTÜK NO";

                    IKMALVERILISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 70, 129, 80, false);
                    IKMALVERILISTARIHI.Name = "IKMALVERILISTARIHI";
                    IKMALVERILISTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    IKMALVERILISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    IKMALVERILISTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IKMALVERILISTARIHI.TextFont.Name = "Arial";
                    IKMALVERILISTARIHI.TextFont.CharSet = 162;
                    IKMALVERILISTARIHI.Value = @"";

                    TEDARIKIKMALKAYITNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 80, 129, 90, false);
                    TEDARIKIKMALKAYITNO.Name = "TEDARIKIKMALKAYITNO";
                    TEDARIKIKMALKAYITNO.DrawStyle = DrawStyleConstants.vbSolid;
                    TEDARIKIKMALKAYITNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEDARIKIKMALKAYITNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEDARIKIKMALKAYITNO.TextFont.Name = "Arial";
                    TEDARIKIKMALKAYITNO.TextFont.CharSet = 162;
                    TEDARIKIKMALKAYITNO.Value = @"";

                    NewField81 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 90, 25, 108, false);
                    NewField81.Name = "NewField81";
                    NewField81.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField81.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField81.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField81.TextFont.Name = "Arial";
                    NewField81.TextFont.Bold = true;
                    NewField81.TextFont.CharSet = 162;
                    NewField81.Value = @"S.NU.";

                    NewField72 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 90, 214, 108, false);
                    NewField72.Name = "NewField72";
                    NewField72.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField72.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField72.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField72.MultiLine = EvetHayirEnum.ehEvet;
                    NewField72.WordBreak = EvetHayirEnum.ehEvet;
                    NewField72.TextFont.Name = "Arial";
                    NewField72.TextFont.Bold = true;
                    NewField72.TextFont.CharSet = 162;
                    NewField72.Value = @"SATIN
ALINACAK
MİKTAR";

                    NewField73 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 90, 238, 108, false);
                    NewField73.Name = "NewField73";
                    NewField73.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField73.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField73.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField73.TextFont.Name = "Arial";
                    NewField73.TextFont.Bold = true;
                    NewField73.TextFont.CharSet = 162;
                    NewField73.Value = @"ÖLÇÜ CİNSİ";

                    NewField74 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 90, 272, 108, false);
                    NewField74.Name = "NewField74";
                    NewField74.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField74.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField74.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField74.TextFont.Name = "Arial";
                    NewField74.TextFont.Bold = true;
                    NewField74.TextFont.CharSet = 162;
                    NewField74.Value = @"AÇIKLAMALAR";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    ISTEKTARIHI.CalcValue = @" " + (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.RequestDate) : "");
                    NewField.CalcValue = NewField.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField21.CalcValue = NewField21.Value;
                    SIPARISNO.CalcValue = @" " + (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.OrderNO) : "");
                    ONARIMDANSORUMLUKISIM.CalcValue = @" " + (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Workshop) : "");
                    SAYMANLIKKAYITNO.CalcValue = @"";
                    AITOLDUGUANAMALZEME.CalcValue = @" " + (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Fixedassetname) : "");
                    ANAMLZSERINO.CalcValue = @" " + (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.SerialNumber) : "");
                    BIRLIGI.CalcValue = @"
" + (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Ownermilitaryunit) : "");
                    NewField61.CalcValue = NewField61.Value;
                    NewField71.CalcValue = NewField71.Value;
                    IKMALVERILISTARIHI.CalcValue = @"";
                    TEDARIKIKMALKAYITNO.CalcValue = @"";
                    NewField81.CalcValue = NewField81.Value;
                    NewField72.CalcValue = NewField72.Value;
                    NewField73.CalcValue = NewField73.Value;
                    NewField74.CalcValue = NewField74.Value;
                    MARKAMODELI.CalcValue = " " + (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Mark) : "") + " - " + (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Model) : "");
                    return new TTReportObject[] { ISTEKTARIHI,NewField,NewField5,NewField6,NewField7,NewField8,NewField9,NewField16,NewField17,NewField18,NewField19,NewField1,NewField21,SIPARISNO,ONARIMDANSORUMLUKISIM,SAYMANLIKKAYITNO,AITOLDUGUANAMALZEME,ANAMLZSERINO,BIRLIGI,NewField61,NewField71,IKMALVERILISTARIHI,TEDARIKIKMALKAYITNO,NewField81,NewField72,NewField73,NewField74,MARKAMODELI};
                }
            }
            public partial class Part1GroupFooter : TTReportSection
            {
                public TedarikFisi MyParentReport
                {
                    get { return (TedarikFisi)ParentReport; }
                }
                
                public TTReportField KULLANICI_;
                public TTReportField KULLANICI;
                public TTReportField KULLANICI_2;
                public TTReportField KISIMAMIRI;
                public TTReportField KULLANICI_3;
                public TTReportField ONARIMBOLUMAMIRI;
                public TTReportField KULLANICI_4;
                public TTReportField BAKIMMUDURU;
                public TTReportField KULLANICI_5;
                public TTReportField MALSORUMLUSU;
                public TTReportField KULLANICI_6;
                public TTReportField SAYMAN;
                public TTReportField KULLANICI_7;
                public TTReportField TEDARIKKISIMSUBAYI; 
                public Part1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 50;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    KULLANICI_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 0, 44, 10, false);
                    KULLANICI_.Name = "KULLANICI_";
                    KULLANICI_.DrawStyle = DrawStyleConstants.vbSolid;
                    KULLANICI_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KULLANICI_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KULLANICI_.TextFont.Name = "Arial";
                    KULLANICI_.TextFont.Bold = true;
                    KULLANICI_.TextFont.CharSet = 162;
                    KULLANICI_.Value = @"KULLANICI";

                    KULLANICI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 10, 44, 25, false);
                    KULLANICI.Name = "KULLANICI";
                    KULLANICI.DrawStyle = DrawStyleConstants.vbSolid;
                    KULLANICI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KULLANICI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KULLANICI.TextFont.Name = "Arial";
                    KULLANICI.TextFont.Size = 11;
                    KULLANICI.TextFont.CharSet = 162;
                    KULLANICI.Value = @"";

                    KULLANICI_2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 0, 69, 10, false);
                    KULLANICI_2.Name = "KULLANICI_2";
                    KULLANICI_2.DrawStyle = DrawStyleConstants.vbSolid;
                    KULLANICI_2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KULLANICI_2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KULLANICI_2.TextFont.Name = "Arial";
                    KULLANICI_2.TextFont.Bold = true;
                    KULLANICI_2.TextFont.CharSet = 162;
                    KULLANICI_2.Value = @"KISIM AMİRİ";

                    KISIMAMIRI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 10, 69, 25, false);
                    KISIMAMIRI.Name = "KISIMAMIRI";
                    KISIMAMIRI.DrawStyle = DrawStyleConstants.vbSolid;
                    KISIMAMIRI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KISIMAMIRI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KISIMAMIRI.TextFont.Name = "Arial";
                    KISIMAMIRI.TextFont.Size = 11;
                    KISIMAMIRI.TextFont.CharSet = 162;
                    KISIMAMIRI.Value = @"";

                    KULLANICI_3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 0, 129, 10, false);
                    KULLANICI_3.Name = "KULLANICI_3";
                    KULLANICI_3.DrawStyle = DrawStyleConstants.vbSolid;
                    KULLANICI_3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KULLANICI_3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KULLANICI_3.MultiLine = EvetHayirEnum.ehEvet;
                    KULLANICI_3.WordBreak = EvetHayirEnum.ehEvet;
                    KULLANICI_3.TextFont.Name = "Arial";
                    KULLANICI_3.TextFont.Bold = true;
                    KULLANICI_3.TextFont.CharSet = 162;
                    KULLANICI_3.Value = @"ONARIM BÖLÜM
AMİRİ";

                    ONARIMBOLUMAMIRI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 10, 129, 25, false);
                    ONARIMBOLUMAMIRI.Name = "ONARIMBOLUMAMIRI";
                    ONARIMBOLUMAMIRI.DrawStyle = DrawStyleConstants.vbSolid;
                    ONARIMBOLUMAMIRI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONARIMBOLUMAMIRI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ONARIMBOLUMAMIRI.TextFont.Name = "Arial";
                    ONARIMBOLUMAMIRI.TextFont.Size = 11;
                    ONARIMBOLUMAMIRI.TextFont.CharSet = 162;
                    ONARIMBOLUMAMIRI.Value = @"";

                    KULLANICI_4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 0, 164, 10, false);
                    KULLANICI_4.Name = "KULLANICI_4";
                    KULLANICI_4.DrawStyle = DrawStyleConstants.vbSolid;
                    KULLANICI_4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KULLANICI_4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KULLANICI_4.TextFont.Name = "Arial";
                    KULLANICI_4.TextFont.Bold = true;
                    KULLANICI_4.TextFont.CharSet = 162;
                    KULLANICI_4.Value = @"BAKIM MÜDÜRÜ";

                    BAKIMMUDURU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 10, 164, 25, false);
                    BAKIMMUDURU.Name = "BAKIMMUDURU";
                    BAKIMMUDURU.DrawStyle = DrawStyleConstants.vbSolid;
                    BAKIMMUDURU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BAKIMMUDURU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BAKIMMUDURU.TextFont.Name = "Arial";
                    BAKIMMUDURU.TextFont.Size = 11;
                    BAKIMMUDURU.TextFont.CharSet = 162;
                    BAKIMMUDURU.Value = @"";

                    KULLANICI_5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 0, 189, 10, false);
                    KULLANICI_5.Name = "KULLANICI_5";
                    KULLANICI_5.DrawStyle = DrawStyleConstants.vbSolid;
                    KULLANICI_5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KULLANICI_5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KULLANICI_5.MultiLine = EvetHayirEnum.ehEvet;
                    KULLANICI_5.WordBreak = EvetHayirEnum.ehEvet;
                    KULLANICI_5.TextFont.Name = "Arial";
                    KULLANICI_5.TextFont.Bold = true;
                    KULLANICI_5.TextFont.CharSet = 162;
                    KULLANICI_5.Value = @"MAL SORUMLUSU";

                    MALSORUMLUSU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 10, 189, 25, false);
                    MALSORUMLUSU.Name = "MALSORUMLUSU";
                    MALSORUMLUSU.DrawStyle = DrawStyleConstants.vbSolid;
                    MALSORUMLUSU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MALSORUMLUSU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MALSORUMLUSU.TextFont.Name = "Arial";
                    MALSORUMLUSU.TextFont.Size = 11;
                    MALSORUMLUSU.TextFont.CharSet = 162;
                    MALSORUMLUSU.Value = @"";

                    KULLANICI_6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 0, 238, 10, false);
                    KULLANICI_6.Name = "KULLANICI_6";
                    KULLANICI_6.DrawStyle = DrawStyleConstants.vbSolid;
                    KULLANICI_6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KULLANICI_6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KULLANICI_6.TextFont.Name = "Arial";
                    KULLANICI_6.TextFont.Bold = true;
                    KULLANICI_6.TextFont.CharSet = 162;
                    KULLANICI_6.Value = @"SAYMAN";

                    SAYMAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 10, 238, 25, false);
                    SAYMAN.Name = "SAYMAN";
                    SAYMAN.DrawStyle = DrawStyleConstants.vbSolid;
                    SAYMAN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SAYMAN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SAYMAN.TextFont.Name = "Arial";
                    SAYMAN.TextFont.Size = 11;
                    SAYMAN.TextFont.CharSet = 162;
                    SAYMAN.Value = @"";

                    KULLANICI_7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 0, 272, 10, false);
                    KULLANICI_7.Name = "KULLANICI_7";
                    KULLANICI_7.DrawStyle = DrawStyleConstants.vbSolid;
                    KULLANICI_7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KULLANICI_7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KULLANICI_7.MultiLine = EvetHayirEnum.ehEvet;
                    KULLANICI_7.WordBreak = EvetHayirEnum.ehEvet;
                    KULLANICI_7.TextFont.Name = "Arial";
                    KULLANICI_7.TextFont.Bold = true;
                    KULLANICI_7.TextFont.CharSet = 162;
                    KULLANICI_7.Value = @"TEDARİK KISIM
SUBAYI";

                    TEDARIKKISIMSUBAYI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 10, 272, 25, false);
                    TEDARIKKISIMSUBAYI.Name = "TEDARIKKISIMSUBAYI";
                    TEDARIKKISIMSUBAYI.DrawStyle = DrawStyleConstants.vbSolid;
                    TEDARIKKISIMSUBAYI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEDARIKKISIMSUBAYI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEDARIKKISIMSUBAYI.TextFont.Name = "Arial";
                    TEDARIKKISIMSUBAYI.TextFont.Size = 11;
                    TEDARIKKISIMSUBAYI.TextFont.CharSet = 162;
                    TEDARIKKISIMSUBAYI.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    KULLANICI_.CalcValue = KULLANICI_.Value;
                    KULLANICI.CalcValue = KULLANICI.Value;
                    KULLANICI_2.CalcValue = KULLANICI_2.Value;
                    KISIMAMIRI.CalcValue = KISIMAMIRI.Value;
                    KULLANICI_3.CalcValue = KULLANICI_3.Value;
                    ONARIMBOLUMAMIRI.CalcValue = ONARIMBOLUMAMIRI.Value;
                    KULLANICI_4.CalcValue = KULLANICI_4.Value;
                    BAKIMMUDURU.CalcValue = BAKIMMUDURU.Value;
                    KULLANICI_5.CalcValue = KULLANICI_5.Value;
                    MALSORUMLUSU.CalcValue = MALSORUMLUSU.Value;
                    KULLANICI_6.CalcValue = KULLANICI_6.Value;
                    SAYMAN.CalcValue = SAYMAN.Value;
                    KULLANICI_7.CalcValue = KULLANICI_7.Value;
                    TEDARIKKISIMSUBAYI.CalcValue = TEDARIKKISIMSUBAYI.Value;
                    return new TTReportObject[] { KULLANICI_,KULLANICI,KULLANICI_2,KISIMAMIRI,KULLANICI_3,ONARIMBOLUMAMIRI,KULLANICI_4,BAKIMMUDURU,KULLANICI_5,MALSORUMLUSU,KULLANICI_6,SAYMAN,KULLANICI_7,TEDARIKKISIMSUBAYI};
                }
            }

        }

        public Part1Group Part1;

        public partial class MAINGroup : TTReportGroup
        {
            public TedarikFisi MyParentReport
            {
                get { return (TedarikFisi)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SNO { get {return Body().SNO;} }
            public TTReportField STOKNO { get {return Body().STOKNO;} }
            public TTReportField MALZEMENINADI { get {return Body().MALZEMENINADI;} }
            public TTReportField ATOLYEIHTIYACIMIKTAR { get {return Body().ATOLYEIHTIYACIMIKTAR;} }
            public TTReportField SATINALINACAKMIKTAR { get {return Body().SATINALINACAKMIKTAR;} }
            public TTReportField OLCUCINSI { get {return Body().OLCUCINSI;} }
            public TTReportField ACIKLAMALAR { get {return Body().ACIKLAMALAR;} }
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
                list[0] = new TTReportNqlData<MaintenanceOrder.GetConsumedMaterialsQuery_Class>("GetConsumedMaterialsQuery", MaintenanceOrder.GetConsumedMaterialsQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public TedarikFisi MyParentReport
                {
                    get { return (TedarikFisi)ParentReport; }
                }
                
                public TTReportField SNO;
                public TTReportField STOKNO;
                public TTReportField MALZEMENINADI;
                public TTReportField ATOLYEIHTIYACIMIKTAR;
                public TTReportField SATINALINACAKMIKTAR;
                public TTReportField OLCUCINSI;
                public TTReportField ACIKLAMALAR; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    RepeatCount = 0;
                    
                    SNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 0, 25, 13, false);
                    SNO.Name = "SNO";
                    SNO.DrawStyle = DrawStyleConstants.vbSolid;
                    SNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SNO.TextFont.Name = "Arial";
                    SNO.TextFont.CharSet = 162;
                    SNO.Value = @"{@counter@}";

                    STOKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 0, 69, 13, false);
                    STOKNO.Name = "STOKNO";
                    STOKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    STOKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STOKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOKNO.TextFont.Name = "Arial";
                    STOKNO.TextFont.CharSet = 162;
                    STOKNO.Value = @"{#NATOSTOCKNO#}";

                    MALZEMENINADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 69, 0, 164, 13, false);
                    MALZEMENINADI.Name = "MALZEMENINADI";
                    MALZEMENINADI.DrawStyle = DrawStyleConstants.vbSolid;
                    MALZEMENINADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMENINADI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MALZEMENINADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MALZEMENINADI.MultiLine = EvetHayirEnum.ehEvet;
                    MALZEMENINADI.WordBreak = EvetHayirEnum.ehEvet;
                    MALZEMENINADI.TextFont.Name = "Arial";
                    MALZEMENINADI.TextFont.CharSet = 162;
                    MALZEMENINADI.Value = @" {#MATERIALNAME#}";

                    ATOLYEIHTIYACIMIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 0, 189, 13, false);
                    ATOLYEIHTIYACIMIKTAR.Name = "ATOLYEIHTIYACIMIKTAR";
                    ATOLYEIHTIYACIMIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    ATOLYEIHTIYACIMIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATOLYEIHTIYACIMIKTAR.TextFormat = @"#,###";
                    ATOLYEIHTIYACIMIKTAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ATOLYEIHTIYACIMIKTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ATOLYEIHTIYACIMIKTAR.TextFont.Name = "Arial";
                    ATOLYEIHTIYACIMIKTAR.TextFont.CharSet = 162;
                    ATOLYEIHTIYACIMIKTAR.Value = @"{#REQUESTAMOUNT#}";

                    SATINALINACAKMIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 0, 214, 13, false);
                    SATINALINACAKMIKTAR.Name = "SATINALINACAKMIKTAR";
                    SATINALINACAKMIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    SATINALINACAKMIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    SATINALINACAKMIKTAR.TextFormat = @"#,###";
                    SATINALINACAKMIKTAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SATINALINACAKMIKTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SATINALINACAKMIKTAR.TextFont.Name = "Arial";
                    SATINALINACAKMIKTAR.TextFont.CharSet = 162;
                    SATINALINACAKMIKTAR.Value = @"{#SUPPLIEDAMOUNT#}";

                    OLCUCINSI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 0, 238, 13, false);
                    OLCUCINSI.Name = "OLCUCINSI";
                    OLCUCINSI.DrawStyle = DrawStyleConstants.vbSolid;
                    OLCUCINSI.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLCUCINSI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLCUCINSI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLCUCINSI.TextFont.Name = "Arial";
                    OLCUCINSI.TextFont.CharSet = 162;
                    OLCUCINSI.Value = @"{#DISTRIBUTIONTYPE#}";

                    ACIKLAMALAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 0, 272, 13, false);
                    ACIKLAMALAR.Name = "ACIKLAMALAR";
                    ACIKLAMALAR.DrawStyle = DrawStyleConstants.vbSolid;
                    ACIKLAMALAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMALAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMALAR.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMALAR.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMALAR.TextFont.Name = "Arial";
                    ACIKLAMALAR.TextFont.CharSet = 162;
                    ACIKLAMALAR.Value = @" {#SPAREPARTMATERIALDESCRIPTION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetConsumedMaterialsQuery_Class dataset_GetConsumedMaterialsQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetConsumedMaterialsQuery_Class>(0);
                    SNO.CalcValue = ParentGroup.Counter.ToString();
                    STOKNO.CalcValue = (dataset_GetConsumedMaterialsQuery != null ? Globals.ToStringCore(dataset_GetConsumedMaterialsQuery.NATOStockNO) : "");
                    MALZEMENINADI.CalcValue = @" " + (dataset_GetConsumedMaterialsQuery != null ? Globals.ToStringCore(dataset_GetConsumedMaterialsQuery.Materialname) : "");
                    ATOLYEIHTIYACIMIKTAR.CalcValue = (dataset_GetConsumedMaterialsQuery != null ? Globals.ToStringCore(dataset_GetConsumedMaterialsQuery.RequestAmount) : "");
                    SATINALINACAKMIKTAR.CalcValue = (dataset_GetConsumedMaterialsQuery != null ? Globals.ToStringCore(dataset_GetConsumedMaterialsQuery.SuppliedAmount) : "");
                    OLCUCINSI.CalcValue = (dataset_GetConsumedMaterialsQuery != null ? Globals.ToStringCore(dataset_GetConsumedMaterialsQuery.DistributionType) : "");
                    ACIKLAMALAR.CalcValue = @" " + (dataset_GetConsumedMaterialsQuery != null ? Globals.ToStringCore(dataset_GetConsumedMaterialsQuery.SparePartMaterialDescription) : "");
                    return new TTReportObject[] { SNO,STOKNO,MALZEMENINADI,ATOLYEIHTIYACIMIKTAR,SATINALINACAKMIKTAR,OLCUCINSI,ACIKLAMALAR};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public TedarikFisi()
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
            Name = "TEDARIKFISI";
            Caption = "Tedarik Fişi (Ek-9.9)";
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