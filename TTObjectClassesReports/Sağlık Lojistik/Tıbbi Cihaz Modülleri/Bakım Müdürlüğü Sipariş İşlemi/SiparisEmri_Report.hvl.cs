
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
    /// Sipariş Emri
    /// </summary>
    public partial class SiparisEmri : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string BOLUMAMIR = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string ISHAZIRLAMA = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public SiparisEmri MyParentReport
            {
                get { return (SiparisEmri)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportRTF DESCRIPTIONRTF { get {return Body().DESCRIPTIONRTF;} }
            public TTReportField NewField { get {return Body().NewField;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportField NewField5 { get {return Body().NewField5;} }
            public TTReportField NewField6 { get {return Body().NewField6;} }
            public TTReportField NewField7 { get {return Body().NewField7;} }
            public TTReportField NewField8 { get {return Body().NewField8;} }
            public TTReportField NewField9 { get {return Body().NewField9;} }
            public TTReportField NewField10 { get {return Body().NewField10;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public TTReportField NewField18 { get {return Body().NewField18;} }
            public TTReportField NewField19 { get {return Body().NewField19;} }
            public TTReportField NewField20 { get {return Body().NewField20;} }
            public TTReportField NewField21 { get {return Body().NewField21;} }
            public TTReportField NewField22 { get {return Body().NewField22;} }
            public TTReportField NewField23 { get {return Body().NewField23;} }
            public TTReportField NewField24 { get {return Body().NewField24;} }
            public TTReportField NewField25 { get {return Body().NewField25;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField26 { get {return Body().NewField26;} }
            public TTReportField NewField27 { get {return Body().NewField27;} }
            public TTReportField NewField31 { get {return Body().NewField31;} }
            public TTReportField NewField32 { get {return Body().NewField32;} }
            public TTReportField CINSI { get {return Body().CINSI;} }
            public TTReportField NUMARASI { get {return Body().NUMARASI;} }
            public TTReportField IMUAYENETARIHI { get {return Body().IMUAYENETARIHI;} }
            public TTReportField SIPKAYITTARIHI { get {return Body().SIPKAYITTARIHI;} }
            public TTReportField GRUBU { get {return Body().GRUBU;} }
            public TTReportField ISMI { get {return Body().ISMI;} }
            public TTReportField MARKASI { get {return Body().MARKASI;} }
            public TTReportField MIKTARI { get {return Body().MIKTARI;} }
            public TTReportField KUVVETI { get {return Body().KUVVETI;} }
            public TTReportField BIRLIGI { get {return Body().BIRLIGI;} }
            public TTReportField USTYAZITARIHI { get {return Body().USTYAZITARIHI;} }
            public TTReportField USTYAZIILGISI { get {return Body().USTYAZIILGISI;} }
            public TTReportField BOLUMU { get {return Body().BOLUMU;} }
            public TTReportField KISMI { get {return Body().KISMI;} }
            public TTReportField TEKNISYENI { get {return Body().TEKNISYENI;} }
            public TTReportField ONCELIGI { get {return Body().ONCELIGI;} }
            public TTReportField STANDARTSURESI { get {return Body().STANDARTSURESI;} }
            public TTReportField BASLAMATARIHI { get {return Body().BASLAMATARIHI;} }
            public TTReportField BITISTARIHI { get {return Body().BITISTARIHI;} }
            public TTReportField GERCEKLESMESURESI { get {return Body().GERCEKLESMESURESI;} }
            public TTReportField TOPLAMISCILIKMALIYETI { get {return Body().TOPLAMISCILIKMALIYETI;} }
            public TTReportField TTOBJECTID { get {return Body().TTOBJECTID;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportField NewField113 { get {return Body().NewField113;} }
            public TTReportField NewField114 { get {return Body().NewField114;} }
            public TTReportField ISHAZIRLAMATITLE { get {return Body().ISHAZIRLAMATITLE;} }
            public TTReportField BOLUMTITLE { get {return Body().BOLUMTITLE;} }
            public TTReportField NAME1 { get {return Body().NAME1;} }
            public TTReportField RANK1 { get {return Body().RANK1;} }
            public TTReportField TITLE1 { get {return Body().TITLE1;} }
            public TTReportField NAME11 { get {return Body().NAME11;} }
            public TTReportField RANK11 { get {return Body().RANK11;} }
            public TTReportField TITLE11 { get {return Body().TITLE11;} }
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
                list[0] = new TTReportNqlData<MaintenanceOrder.GetOrderCommandReportQuery_Class>("GetOrderCommandReportQuery", MaintenanceOrder.GetOrderCommandReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public SiparisEmri MyParentReport
                {
                    get { return (SiparisEmri)ParentReport; }
                }
                
                public TTReportRTF DESCRIPTIONRTF;
                public TTReportField NewField;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField9;
                public TTReportField NewField10;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField NewField20;
                public TTReportField NewField21;
                public TTReportField NewField22;
                public TTReportField NewField23;
                public TTReportField NewField24;
                public TTReportField NewField25;
                public TTReportField NewField1;
                public TTReportField NewField26;
                public TTReportField NewField27;
                public TTReportField NewField31;
                public TTReportField NewField32;
                public TTReportField CINSI;
                public TTReportField NUMARASI;
                public TTReportField IMUAYENETARIHI;
                public TTReportField SIPKAYITTARIHI;
                public TTReportField GRUBU;
                public TTReportField ISMI;
                public TTReportField MARKASI;
                public TTReportField MIKTARI;
                public TTReportField KUVVETI;
                public TTReportField BIRLIGI;
                public TTReportField USTYAZITARIHI;
                public TTReportField USTYAZIILGISI;
                public TTReportField BOLUMU;
                public TTReportField KISMI;
                public TTReportField TEKNISYENI;
                public TTReportField ONCELIGI;
                public TTReportField STANDARTSURESI;
                public TTReportField BASLAMATARIHI;
                public TTReportField BITISTARIHI;
                public TTReportField GERCEKLESMESURESI;
                public TTReportField TOPLAMISCILIKMALIYETI;
                public TTReportField TTOBJECTID;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportField NewField113;
                public TTReportField NewField114;
                public TTReportField ISHAZIRLAMATITLE;
                public TTReportField BOLUMTITLE;
                public TTReportField NAME1;
                public TTReportField RANK1;
                public TTReportField TITLE1;
                public TTReportField NAME11;
                public TTReportField RANK11;
                public TTReportField TITLE11; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 210;
                    RepeatCount = 0;
                    
                    DESCRIPTIONRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 201, 93, 281, 126, false);
                    DESCRIPTIONRTF.Name = "DESCRIPTIONRTF";
                    DESCRIPTIONRTF.CanExpand = EvetHayirEnum.ehHayir;
                    DESCRIPTIONRTF.CanShrink = EvetHayirEnum.ehHayir;
                    DESCRIPTIONRTF.CanSplit = EvetHayirEnum.ehHayir;
                    DESCRIPTIONRTF.Value = @"";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 10, 282, 21, false);
                    NewField.Name = "NewField";
                    NewField.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField.TextFont.Size = 15;
                    NewField.TextFont.Bold = true;
                    NewField.Value = @"SİPARİŞ EMRİ";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 22, 85, 33, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"SİPARİŞİN";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 22, 200, 33, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Size = 11;
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"YAPILACAK İŞİN";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 22, 282, 33, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Size = 11;
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @"BELGENİN";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 33, 45, 44, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Size = 11;
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @"CİNSİ";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 44, 45, 55, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.MultiLine = EvetHayirEnum.ehEvet;
                    NewField6.WordBreak = EvetHayirEnum.ehEvet;
                    NewField6.TextFont.Size = 11;
                    NewField6.TextFont.Bold = true;
                    NewField6.Value = @"SİPARİŞ NUMARASI";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 55, 45, 66, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7.WordBreak = EvetHayirEnum.ehEvet;
                    NewField7.TextFont.Size = 11;
                    NewField7.TextFont.Bold = true;
                    NewField7.Value = @"İLK MUAYENE TARİHİ";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 66, 45, 77, false);
                    NewField8.Name = "NewField8";
                    NewField8.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8.MultiLine = EvetHayirEnum.ehEvet;
                    NewField8.WordBreak = EvetHayirEnum.ehEvet;
                    NewField8.TextFont.Size = 11;
                    NewField8.TextFont.Bold = true;
                    NewField8.Value = @"SİPARİŞ KAYIT TARİHİ";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 82, 85, 93, false);
                    NewField9.Name = "NewField9";
                    NewField9.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9.TextFont.Size = 11;
                    NewField9.TextFont.Bold = true;
                    NewField9.Value = @"SİPARİŞİN";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 93, 45, 104, false);
                    NewField10.Name = "NewField10";
                    NewField10.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField10.TextFont.Size = 11;
                    NewField10.TextFont.Bold = true;
                    NewField10.Value = @"BÖLÜMÜ";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 104, 45, 115, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"KISMI";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 115, 45, 126, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"TEKNİSYENİ";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 131, 45, 142, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Size = 11;
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @"ÖNCELİĞİ";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 147, 282, 183, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.TextFont.Size = 11;
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @"";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 82, 200, 93, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Size = 11;
                    NewField16.TextFont.Bold = true;
                    NewField16.Value = @"İŞLEMİN";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 82, 282, 93, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.TextFont.Size = 11;
                    NewField17.TextFont.Bold = true;
                    NewField17.Value = @"DÜŞÜNCELER VE SONUÇ";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 33, 127, 44, false);
                    NewField18.Name = "NewField18";
                    NewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18.TextFont.Size = 11;
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @"GRUBU";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 44, 127, 55, false);
                    NewField19.Name = "NewField19";
                    NewField19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField19.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.TextFont.Size = 11;
                    NewField19.TextFont.Bold = true;
                    NewField19.Value = @"İSMİ";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 55, 127, 66, false);
                    NewField20.Name = "NewField20";
                    NewField20.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField20.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField20.TextFont.Size = 11;
                    NewField20.TextFont.Bold = true;
                    NewField20.Value = @"MARKASI";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 66, 127, 77, false);
                    NewField21.Name = "NewField21";
                    NewField21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField21.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21.TextFont.Size = 11;
                    NewField21.TextFont.Bold = true;
                    NewField21.Value = @"MİKTARI";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 33, 236, 44, false);
                    NewField22.Name = "NewField22";
                    NewField22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField22.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField22.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField22.TextFont.Size = 11;
                    NewField22.TextFont.Bold = true;
                    NewField22.Value = @"KUVVETİ";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 44, 236, 55, false);
                    NewField23.Name = "NewField23";
                    NewField23.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField23.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField23.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField23.TextFont.Size = 11;
                    NewField23.TextFont.Bold = true;
                    NewField23.Value = @"BİRLİĞİ";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 55, 236, 66, false);
                    NewField24.Name = "NewField24";
                    NewField24.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField24.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField24.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField24.TextFont.Size = 11;
                    NewField24.TextFont.Bold = true;
                    NewField24.Value = @"İŞ İSTEK TARİHİ";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 66, 236, 77, false);
                    NewField25.Name = "NewField25";
                    NewField25.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField25.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField25.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField25.MultiLine = EvetHayirEnum.ehEvet;
                    NewField25.WordBreak = EvetHayirEnum.ehEvet;
                    NewField25.TextFont.Size = 11;
                    NewField25.TextFont.Bold = true;
                    NewField25.Value = @"İŞ İSTEK NUMARASI";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 93, 127, 104, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"STANDART SÜRESİ";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 104, 127, 115, false);
                    NewField26.Name = "NewField26";
                    NewField26.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField26.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField26.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField26.TextFont.Size = 11;
                    NewField26.TextFont.Bold = true;
                    NewField26.Value = @"BAŞLAMA TARİHİ";

                    NewField27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 115, 127, 126, false);
                    NewField27.Name = "NewField27";
                    NewField27.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField27.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField27.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField27.TextFont.Size = 11;
                    NewField27.TextFont.Bold = true;
                    NewField27.Value = @"BİTİŞ TARİHİ";

                    NewField31 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 131, 127, 142, false);
                    NewField31.Name = "NewField31";
                    NewField31.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField31.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField31.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField31.MultiLine = EvetHayirEnum.ehEvet;
                    NewField31.WordBreak = EvetHayirEnum.ehEvet;
                    NewField31.TextFont.Size = 11;
                    NewField31.TextFont.Bold = true;
                    NewField31.Value = @"GERÇEKLEŞME SÜRESİ";

                    NewField32 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 131, 236, 142, false);
                    NewField32.Name = "NewField32";
                    NewField32.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField32.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField32.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField32.MultiLine = EvetHayirEnum.ehEvet;
                    NewField32.WordBreak = EvetHayirEnum.ehEvet;
                    NewField32.TextFont.Size = 11;
                    NewField32.TextFont.Bold = true;
                    NewField32.Value = @"TOPLAM İŞÇİLİK MALİYETİ";

                    CINSI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 33, 85, 44, false);
                    CINSI.Name = "CINSI";
                    CINSI.DrawStyle = DrawStyleConstants.vbSolid;
                    CINSI.FieldType = ReportFieldTypeEnum.ftVariable;
                    CINSI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CINSI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CINSI.MultiLine = EvetHayirEnum.ehEvet;
                    CINSI.WordBreak = EvetHayirEnum.ehEvet;
                    CINSI.Value = @"{#TYPENAME#}";

                    NUMARASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 44, 85, 55, false);
                    NUMARASI.Name = "NUMARASI";
                    NUMARASI.DrawStyle = DrawStyleConstants.vbSolid;
                    NUMARASI.FieldType = ReportFieldTypeEnum.ftVariable;
                    NUMARASI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NUMARASI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NUMARASI.Value = @"{#REQUESTNO#}";

                    IMUAYENETARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 55, 85, 66, false);
                    IMUAYENETARIHI.Name = "IMUAYENETARIHI";
                    IMUAYENETARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    IMUAYENETARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    IMUAYENETARIHI.TextFormat = @"Short Date";
                    IMUAYENETARIHI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IMUAYENETARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IMUAYENETARIHI.Value = @"{#FIRSTCHECKDATE#}";

                    SIPKAYITTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 66, 85, 77, false);
                    SIPKAYITTARIHI.Name = "SIPKAYITTARIHI";
                    SIPKAYITTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    SIPKAYITTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIPKAYITTARIHI.TextFormat = @"Short Date";
                    SIPKAYITTARIHI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIPKAYITTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIPKAYITTARIHI.Value = @"{#ORDERDATE#}";

                    GRUBU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 33, 200, 44, false);
                    GRUBU.Name = "GRUBU";
                    GRUBU.DrawStyle = DrawStyleConstants.vbSolid;
                    GRUBU.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRUBU.CaseFormat = CaseFormatEnum.fcUpperCase;
                    GRUBU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GRUBU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GRUBU.Value = @"{#MATERIALTREE#}";

                    ISMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 44, 200, 55, false);
                    ISMI.Name = "ISMI";
                    ISMI.DrawStyle = DrawStyleConstants.vbSolid;
                    ISMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISMI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ISMI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISMI.MultiLine = EvetHayirEnum.ehEvet;
                    ISMI.WordBreak = EvetHayirEnum.ehEvet;
                    ISMI.Value = @"{#MATERIALNAME#}";

                    MARKASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 55, 200, 66, false);
                    MARKASI.Name = "MARKASI";
                    MARKASI.DrawStyle = DrawStyleConstants.vbSolid;
                    MARKASI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARKASI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MARKASI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARKASI.Value = @"{#MARK#}";

                    MIKTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 66, 200, 77, false);
                    MIKTARI.Name = "MIKTARI";
                    MIKTARI.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MIKTARI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTARI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTARI.Value = @"";

                    KUVVETI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 33, 282, 44, false);
                    KUVVETI.Name = "KUVVETI";
                    KUVVETI.DrawStyle = DrawStyleConstants.vbSolid;
                    KUVVETI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KUVVETI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    KUVVETI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KUVVETI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KUVVETI.MultiLine = EvetHayirEnum.ehEvet;
                    KUVVETI.WordBreak = EvetHayirEnum.ehEvet;
                    KUVVETI.Value = @"{#MILITARYFORCE#}";

                    BIRLIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 44, 282, 55, false);
                    BIRLIGI.Name = "BIRLIGI";
                    BIRLIGI.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRLIGI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIGI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRLIGI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRLIGI.MultiLine = EvetHayirEnum.ehEvet;
                    BIRLIGI.WordBreak = EvetHayirEnum.ehEvet;
                    BIRLIGI.Value = @"{#MILITARYUNIT#}";

                    USTYAZITARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 55, 282, 66, false);
                    USTYAZITARIHI.Name = "USTYAZITARIHI";
                    USTYAZITARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    USTYAZITARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    USTYAZITARIHI.TextFormat = @"Short Date";
                    USTYAZITARIHI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    USTYAZITARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    USTYAZITARIHI.Value = @"{#REQUESTDATE#}";

                    USTYAZIILGISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 66, 282, 77, false);
                    USTYAZIILGISI.Name = "USTYAZIILGISI";
                    USTYAZIILGISI.DrawStyle = DrawStyleConstants.vbSolid;
                    USTYAZIILGISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    USTYAZIILGISI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    USTYAZIILGISI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    USTYAZIILGISI.Value = @"{#ORDERNO#}";

                    BOLUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 93, 85, 104, false);
                    BOLUMU.Name = "BOLUMU";
                    BOLUMU.DrawStyle = DrawStyleConstants.vbSolid;
                    BOLUMU.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUMU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BOLUMU.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUMU.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUMU.Value = @"{#RESDIVISION#}";

                    KISMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 104, 85, 115, false);
                    KISMI.Name = "KISMI";
                    KISMI.DrawStyle = DrawStyleConstants.vbSolid;
                    KISMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KISMI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KISMI.MultiLine = EvetHayirEnum.ehEvet;
                    KISMI.WordBreak = EvetHayirEnum.ehEvet;
                    KISMI.Value = @"{#SECTION#}";

                    TEKNISYENI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 115, 85, 126, false);
                    TEKNISYENI.Name = "TEKNISYENI";
                    TEKNISYENI.DrawStyle = DrawStyleConstants.vbSolid;
                    TEKNISYENI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKNISYENI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKNISYENI.MultiLine = EvetHayirEnum.ehEvet;
                    TEKNISYENI.WordBreak = EvetHayirEnum.ehEvet;
                    TEKNISYENI.Value = @"{#RESPONSIBLEUSER#}";

                    ONCELIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 131, 85, 142, false);
                    ONCELIGI.Name = "ONCELIGI";
                    ONCELIGI.DrawStyle = DrawStyleConstants.vbSolid;
                    ONCELIGI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONCELIGI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONCELIGI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ONCELIGI.Value = @"";

                    STANDARTSURESI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 93, 200, 104, false);
                    STANDARTSURESI.Name = "STANDARTSURESI";
                    STANDARTSURESI.DrawStyle = DrawStyleConstants.vbSolid;
                    STANDARTSURESI.FieldType = ReportFieldTypeEnum.ftVariable;
                    STANDARTSURESI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STANDARTSURESI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STANDARTSURESI.Value = @"{#PLANNEDTIME#}";

                    BASLAMATARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 104, 200, 115, false);
                    BASLAMATARIHI.Name = "BASLAMATARIHI";
                    BASLAMATARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    BASLAMATARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASLAMATARIHI.TextFormat = @"Short Date";
                    BASLAMATARIHI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLAMATARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASLAMATARIHI.Value = @"{#STARTDATE#}";

                    BITISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 115, 200, 126, false);
                    BITISTARIHI.Name = "BITISTARIHI";
                    BITISTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    BITISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BITISTARIHI.TextFormat = @"Short Date";
                    BITISTARIHI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BITISTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BITISTARIHI.Value = @"{#ENDDATE#}";

                    GERCEKLESMESURESI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 131, 200, 142, false);
                    GERCEKLESMESURESI.Name = "GERCEKLESMESURESI";
                    GERCEKLESMESURESI.DrawStyle = DrawStyleConstants.vbSolid;
                    GERCEKLESMESURESI.FieldType = ReportFieldTypeEnum.ftVariable;
                    GERCEKLESMESURESI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GERCEKLESMESURESI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GERCEKLESMESURESI.Value = @"{#REPAIRWORKLOAD#}";

                    TOPLAMISCILIKMALIYETI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 131, 282, 142, false);
                    TOPLAMISCILIKMALIYETI.Name = "TOPLAMISCILIKMALIYETI";
                    TOPLAMISCILIKMALIYETI.DrawStyle = DrawStyleConstants.vbSolid;
                    TOPLAMISCILIKMALIYETI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMISCILIKMALIYETI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOPLAMISCILIKMALIYETI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOPLAMISCILIKMALIYETI.Value = @"{#TOTALLABORCOST#}";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 309, 28, 328, 33, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.TextFont.Name = "Arial Narrow";
                    TTOBJECTID.TextFont.Size = 10;
                    TTOBJECTID.TextFont.CharSet = 1;
                    TTOBJECTID.Value = @"{@TTOBJECTID@}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 126, 282, 126, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 282, 93, 282, 126, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 148, 113, 159, false);
                    NewField113.Name = "NewField113";
                    NewField113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113.TextFont.Size = 11;
                    NewField113.TextFont.Bold = true;
                    NewField113.Value = @"PLAN KOORDİNASYON VE İŞ HAZIRLAMA BÖLÜM AMİRİ";

                    NewField114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 207, 148, 249, 157, false);
                    NewField114.Name = "NewField114";
                    NewField114.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField114.MultiLine = EvetHayirEnum.ehEvet;
                    NewField114.WordBreak = EvetHayirEnum.ehEvet;
                    NewField114.TextFont.Size = 11;
                    NewField114.TextFont.Bold = true;
                    NewField114.Value = @"TEKNİK MÜDÜR";

                    ISHAZIRLAMATITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 192, 112, 197, false);
                    ISHAZIRLAMATITLE.Name = "ISHAZIRLAMATITLE";
                    ISHAZIRLAMATITLE.Visible = EvetHayirEnum.ehHayir;
                    ISHAZIRLAMATITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISHAZIRLAMATITLE.ObjectDefName = "ResUser";
                    ISHAZIRLAMATITLE.DataMember = "TITLE";
                    ISHAZIRLAMATITLE.TextFont.Name = "Arial Narrow";
                    ISHAZIRLAMATITLE.TextFont.Size = 10;
                    ISHAZIRLAMATITLE.TextFont.CharSet = 1;
                    ISHAZIRLAMATITLE.Value = @"{@ISHAZIRLAMA@}";

                    BOLUMTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 195, 147, 200, false);
                    BOLUMTITLE.Name = "BOLUMTITLE";
                    BOLUMTITLE.Visible = EvetHayirEnum.ehHayir;
                    BOLUMTITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUMTITLE.ObjectDefName = "ResUser";
                    BOLUMTITLE.DataMember = "TITLE";
                    BOLUMTITLE.TextFont.Name = "Arial Narrow";
                    BOLUMTITLE.TextFont.Size = 10;
                    BOLUMTITLE.TextFont.CharSet = 1;
                    BOLUMTITLE.Value = @"{@BOLUMAMIR@}";

                    NAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 166, 99, 171, false);
                    NAME1.Name = "NAME1";
                    NAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME1.CaseFormat = CaseFormatEnum.fcNameSurname;
                    NAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME1.NoClip = EvetHayirEnum.ehEvet;
                    NAME1.ObjectDefName = "ResUser";
                    NAME1.DataMember = "NAME";
                    NAME1.TextFont.Size = 10;
                    NAME1.Value = @"{@ISHAZIRLAMA@}";

                    RANK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 171, 99, 176, false);
                    RANK1.Name = "RANK1";
                    RANK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    RANK1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    RANK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RANK1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RANK1.NoClip = EvetHayirEnum.ehEvet;
                    RANK1.ObjectDefName = "RESUSER";
                    RANK1.DataMember = "RANK.NAME";
                    RANK1.TextFont.Size = 10;
                    RANK1.Value = @"{@ISHAZIRLAMA@}";

                    TITLE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 176, 99, 181, false);
                    TITLE1.Name = "TITLE1";
                    TITLE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TITLE1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    TITLE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TITLE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TITLE1.NoClip = EvetHayirEnum.ehEvet;
                    TITLE1.ObjectDefName = "UserTitleEnum";
                    TITLE1.DataMember = "DISPLAYTEXT";
                    TITLE1.TextFont.Size = 10;
                    TITLE1.Value = @"{%ISHAZIRLAMATITLE%}";

                    NAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 165, 256, 170, false);
                    NAME11.Name = "NAME11";
                    NAME11.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME11.CaseFormat = CaseFormatEnum.fcNameSurname;
                    NAME11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAME11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAME11.NoClip = EvetHayirEnum.ehEvet;
                    NAME11.ObjectDefName = "ResUser";
                    NAME11.DataMember = "NAME";
                    NAME11.TextFont.Size = 10;
                    NAME11.Value = @"{@BOLUMAMIR@}";

                    RANK11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 170, 256, 175, false);
                    RANK11.Name = "RANK11";
                    RANK11.FieldType = ReportFieldTypeEnum.ftVariable;
                    RANK11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    RANK11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RANK11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RANK11.NoClip = EvetHayirEnum.ehEvet;
                    RANK11.ObjectDefName = "RESUSER";
                    RANK11.DataMember = "RANK.NAME";
                    RANK11.TextFont.Size = 10;
                    RANK11.Value = @"{@BOLUMAMIR@}";

                    TITLE11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 175, 256, 180, false);
                    TITLE11.Name = "TITLE11";
                    TITLE11.FieldType = ReportFieldTypeEnum.ftVariable;
                    TITLE11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    TITLE11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TITLE11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TITLE11.NoClip = EvetHayirEnum.ehEvet;
                    TITLE11.ObjectDefName = "UserTitleEnum";
                    TITLE11.DataMember = "DISPLAYTEXT";
                    TITLE11.TextFont.Size = 10;
                    TITLE11.Value = @"{%BOLUMTITLE%}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetOrderCommandReportQuery_Class dataset_GetOrderCommandReportQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetOrderCommandReportQuery_Class>(0);
                    DESCRIPTIONRTF.CalcValue = DESCRIPTIONRTF.Value;
                    NewField.CalcValue = NewField.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField20.CalcValue = NewField20.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField22.CalcValue = NewField22.Value;
                    NewField23.CalcValue = NewField23.Value;
                    NewField24.CalcValue = NewField24.Value;
                    NewField25.CalcValue = NewField25.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField26.CalcValue = NewField26.Value;
                    NewField27.CalcValue = NewField27.Value;
                    NewField31.CalcValue = NewField31.Value;
                    NewField32.CalcValue = NewField32.Value;
                    CINSI.CalcValue = (dataset_GetOrderCommandReportQuery != null ? Globals.ToStringCore(dataset_GetOrderCommandReportQuery.TypeName) : "");
                    NUMARASI.CalcValue = (dataset_GetOrderCommandReportQuery != null ? Globals.ToStringCore(dataset_GetOrderCommandReportQuery.RequestNo) : "");
                    IMUAYENETARIHI.CalcValue = (dataset_GetOrderCommandReportQuery != null ? Globals.ToStringCore(dataset_GetOrderCommandReportQuery.Firstcheckdate) : "");
                    SIPKAYITTARIHI.CalcValue = (dataset_GetOrderCommandReportQuery != null ? Globals.ToStringCore(dataset_GetOrderCommandReportQuery.OrderDate) : "");
                    GRUBU.CalcValue = (dataset_GetOrderCommandReportQuery != null ? Globals.ToStringCore(dataset_GetOrderCommandReportQuery.Materialtree) : "");
                    ISMI.CalcValue = (dataset_GetOrderCommandReportQuery != null ? Globals.ToStringCore(dataset_GetOrderCommandReportQuery.Materialname) : "");
                    MARKASI.CalcValue = (dataset_GetOrderCommandReportQuery != null ? Globals.ToStringCore(dataset_GetOrderCommandReportQuery.Mark) : "");
                    MIKTARI.CalcValue = @"";
                    KUVVETI.CalcValue = (dataset_GetOrderCommandReportQuery != null ? Globals.ToStringCore(dataset_GetOrderCommandReportQuery.Militaryforce) : "");
                    BIRLIGI.CalcValue = (dataset_GetOrderCommandReportQuery != null ? Globals.ToStringCore(dataset_GetOrderCommandReportQuery.Militaryunit) : "");
                    USTYAZITARIHI.CalcValue = (dataset_GetOrderCommandReportQuery != null ? Globals.ToStringCore(dataset_GetOrderCommandReportQuery.RequestDate) : "");
                    USTYAZIILGISI.CalcValue = (dataset_GetOrderCommandReportQuery != null ? Globals.ToStringCore(dataset_GetOrderCommandReportQuery.OrderNO) : "");
                    BOLUMU.CalcValue = (dataset_GetOrderCommandReportQuery != null ? Globals.ToStringCore(dataset_GetOrderCommandReportQuery.Resdivision) : "");
                    KISMI.CalcValue = (dataset_GetOrderCommandReportQuery != null ? Globals.ToStringCore(dataset_GetOrderCommandReportQuery.Section) : "");
                    TEKNISYENI.CalcValue = (dataset_GetOrderCommandReportQuery != null ? Globals.ToStringCore(dataset_GetOrderCommandReportQuery.Responsibleuser) : "");
                    ONCELIGI.CalcValue = @"";
                    STANDARTSURESI.CalcValue = (dataset_GetOrderCommandReportQuery != null ? Globals.ToStringCore(dataset_GetOrderCommandReportQuery.PlannedTime) : "");
                    BASLAMATARIHI.CalcValue = (dataset_GetOrderCommandReportQuery != null ? Globals.ToStringCore(dataset_GetOrderCommandReportQuery.StartDate) : "");
                    BITISTARIHI.CalcValue = (dataset_GetOrderCommandReportQuery != null ? Globals.ToStringCore(dataset_GetOrderCommandReportQuery.EndDate) : "");
                    GERCEKLESMESURESI.CalcValue = (dataset_GetOrderCommandReportQuery != null ? Globals.ToStringCore(dataset_GetOrderCommandReportQuery.RepairWorkLoad) : "");
                    TOPLAMISCILIKMALIYETI.CalcValue = (dataset_GetOrderCommandReportQuery != null ? Globals.ToStringCore(dataset_GetOrderCommandReportQuery.Totallaborcost) : "");
                    TTOBJECTID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NewField113.CalcValue = NewField113.Value;
                    NewField114.CalcValue = NewField114.Value;
                    ISHAZIRLAMATITLE.CalcValue = MyParentReport.RuntimeParameters.ISHAZIRLAMA.ToString();
                    ISHAZIRLAMATITLE.PostFieldValueCalculation();
                    BOLUMTITLE.CalcValue = MyParentReport.RuntimeParameters.BOLUMAMIR.ToString();
                    BOLUMTITLE.PostFieldValueCalculation();
                    NAME1.CalcValue = MyParentReport.RuntimeParameters.ISHAZIRLAMA.ToString();
                    NAME1.PostFieldValueCalculation();
                    RANK1.CalcValue = MyParentReport.RuntimeParameters.ISHAZIRLAMA.ToString();
                    RANK1.PostFieldValueCalculation();
                    TITLE1.CalcValue = MyParentReport.MAIN.ISHAZIRLAMATITLE.CalcValue;
                    TITLE1.PostFieldValueCalculation();
                    NAME11.CalcValue = MyParentReport.RuntimeParameters.BOLUMAMIR.ToString();
                    NAME11.PostFieldValueCalculation();
                    RANK11.CalcValue = MyParentReport.RuntimeParameters.BOLUMAMIR.ToString();
                    RANK11.PostFieldValueCalculation();
                    TITLE11.CalcValue = MyParentReport.MAIN.BOLUMTITLE.CalcValue;
                    TITLE11.PostFieldValueCalculation();
                    return new TTReportObject[] { DESCRIPTIONRTF,NewField,NewField2,NewField3,NewField4,NewField5,NewField6,NewField7,NewField8,NewField9,NewField10,NewField11,NewField12,NewField13,NewField14,NewField16,NewField17,NewField18,NewField19,NewField20,NewField21,NewField22,NewField23,NewField24,NewField25,NewField1,NewField26,NewField27,NewField31,NewField32,CINSI,NUMARASI,IMUAYENETARIHI,SIPKAYITTARIHI,GRUBU,ISMI,MARKASI,MIKTARI,KUVVETI,BIRLIGI,USTYAZITARIHI,USTYAZIILGISI,BOLUMU,KISMI,TEKNISYENI,ONCELIGI,STANDARTSURESI,BASLAMATARIHI,BITISTARIHI,GERCEKLESMESURESI,TOPLAMISCILIKMALIYETI,TTOBJECTID,NewField113,NewField114,ISHAZIRLAMATITLE,BOLUMTITLE,NAME1,RANK1,TITLE1,NAME11,RANK11,TITLE11};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    TTObjectContext ctx = new TTObjectContext(true);
            string objectID = ((SiparisEmri)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            MaintenanceOrder mo = (MaintenanceOrder)ctx.GetObject(new Guid(objectID), typeof(MaintenanceOrder));
            if(mo.Description != null)
                DESCRIPTIONRTF.Value = mo.Description;
#endregion MAIN BODY_PreScript
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            string objectID = ((SiparisEmri)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            MaintenanceOrder mo = (MaintenanceOrder)ctx.GetObject(new Guid(objectID), typeof(MaintenanceOrder));
           
            if (mo.MaintenanceOrderType.TypeCode == "BS" || mo.MaintenanceOrderType.TypeCode == "FS" || mo.MaintenanceOrderType.TypeCode == "KS" || mo.MaintenanceOrderType.TypeCode == "MS")
            {
                ISMI.CalcValue = mo.OrderName;
                BIRLIGI.CalcValue = mo.SenderAccountancy.Name;
                if(mo.RelatedReferToUpperLevel != null && mo.RelatedReferToUpperLevel.Amount != null)
                {
                    MIKTARI.CalcValue = ((int)mo.RelatedReferToUpperLevel.Amount).ToString();
                }
                else
                {
                MIKTARI.CalcValue = "1";
                }
                
                
                
            }

            if (mo.MaintenanceOrderType.TypeCode == "OS")
            {
                ISMI.CalcValue = mo.OrderName;
                MIKTARI.CalcValue = mo.SpecialWorkAmount.ToString();
                BIRLIGI.CalcValue = mo.SenderAccountancy.Name;
            }
            
            if (mo.MaintenanceOrderType.TypeCode == "IS")
            {
                ISMI.CalcValue = mo.OrderName;
                MIKTARI.CalcValue = mo.ManufacturingAmount.ToString();                
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

        public SiparisEmri()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("BOLUMAMIR", "", "Teknik Müdür", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter = Parameters.Add("ISHAZIRLAMA", "", "Plan Koor.İş Hazırlama Amiri", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("BOLUMAMIR"))
                _runtimeParameters.BOLUMAMIR = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["BOLUMAMIR"]);
            if (parameters.ContainsKey("ISHAZIRLAMA"))
                _runtimeParameters.ISHAZIRLAMA = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["ISHAZIRLAMA"]);
            Name = "SIPARISEMRI";
            Caption = "Sipariş Emri";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            PaperSize = 10;
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