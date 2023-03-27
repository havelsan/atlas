
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
    /// Mal Muayene Kabul ve Kullanım Tutanağı
    /// </summary>
    public partial class MaterialInspectionAndReceivingReport : TTReport
    {
#region Methods
   public int counter = 0;
        public double toplamTutar = 0;
        public double kdv8 = 0;
        public double kdv18 = 0;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string FIRMOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public MaterialInspectionAndReceivingReport MyParentReport
            {
                get { return (MaterialInspectionAndReceivingReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField OBJECTID { get {return Header().OBJECTID;} }
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
                list[0] = new TTReportNqlData<DirectPurchaseAction.MaterielInspectionAndReceivingPatientInfoNQL_Class>("MaterielInspectionAndReceivingPatientInfoNQL", DirectPurchaseAction.MaterielInspectionAndReceivingPatientInfoNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public MaterialInspectionAndReceivingReport MyParentReport
                {
                    get { return (MaterialInspectionAndReceivingReport)ParentReport; }
                }
                
                public TTReportField OBJECTID; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 1, 236, 6, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DirectPurchaseAction.MaterielInspectionAndReceivingPatientInfoNQL_Class dataset_MaterielInspectionAndReceivingPatientInfoNQL = ParentGroup.rsGroup.GetCurrentRecord<DirectPurchaseAction.MaterielInspectionAndReceivingPatientInfoNQL_Class>(0);
                    OBJECTID.CalcValue = (dataset_MaterielInspectionAndReceivingPatientInfoNQL != null ? Globals.ToStringCore(dataset_MaterielInspectionAndReceivingPatientInfoNQL.ObjectID) : "");
                    return new TTReportObject[] { OBJECTID};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MaterialInspectionAndReceivingReport MyParentReport
                {
                    get { return (MaterialInspectionAndReceivingReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    toplamTutar = 0;
#endregion PARTA FOOTER_Script
                }
            }

#region PARTA_Methods
            public static int toplamTutar = 0;
#endregion PARTA_Methods
        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public MaterialInspectionAndReceivingReport MyParentReport
            {
                get { return (MaterialInspectionAndReceivingReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField YUKLENICIUNVANI { get {return Header().YUKLENICIUNVANI;} }
            public TTReportField FATURATARIH { get {return Header().FATURATARIH;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField11221 { get {return Header().NewField11221;} }
            public TTReportField NewField1122 { get {return Header().NewField1122;} }
            public TTReportField NewField112211 { get {return Header().NewField112211;} }
            public TTReportField FATURASAYISI { get {return Header().FATURASAYISI;} }
            public TTReportField IRSALIYENO { get {return Header().IRSALIYENO;} }
            public TTReportField IRSALIYETARIH { get {return Header().IRSALIYETARIH;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField FIRMAOBJECTID { get {return Header().FIRMAOBJECTID;} }
            public TTReportField NewField11222 { get {return Header().NewField11222;} }
            public TTReportField TEXT1 { get {return Footer().TEXT1;} }
            public TTReportField NewField20 { get {return Footer().NewField20;} }
            public TTReportField NewField10 { get {return Footer().NewField10;} }
            public TTReportField NewField101 { get {return Footer().NewField101;} }
            public TTReportField NewField102 { get {return Footer().NewField102;} }
            public TTReportField BASKAN { get {return Footer().BASKAN;} }
            public TTReportField TEXT2 { get {return Footer().TEXT2;} }
            public TTReportField UZMANLIK { get {return Footer().UZMANLIK;} }
            public TTReportField TCKIMLIKNO { get {return Footer().TCKIMLIKNO;} }
            public TTReportField HASTAISIM { get {return Footer().HASTAISIM;} }
            public TTReportField OBJECTID { get {return Footer().OBJECTID;} }
            public TTReportField UYE1 { get {return Footer().UYE1;} }
            public TTReportField UYE2 { get {return Footer().UYE2;} }
            public TTReportField NewField11031 { get {return Footer().NewField11031;} }
            public TTReportField NewField11121 { get {return Footer().NewField11121;} }
            public TTReportField NewField1231 { get {return Footer().NewField1231;} }
            public TTReportField NewField11321 { get {return Footer().NewField11321;} }
            public TTReportField TEDARIKCI { get {return Footer().TEDARIKCI;} }
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
                list[0] = new TTReportNqlData<DirectPurchaseAction.MaterielInspectionAndReceivingFirmInfoNQL_Class>("MaterielInspectionAndReceivingFirmInfoNQL", DirectPurchaseAction.MaterielInspectionAndReceivingFirmInfoNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public MaterialInspectionAndReceivingReport MyParentReport
                {
                    get { return (MaterialInspectionAndReceivingReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField11;
                public TTReportField YUKLENICIUNVANI;
                public TTReportField FATURATARIH;
                public TTReportField NewField15;
                public TTReportField NewField6;
                public TTReportField NewField16;
                public TTReportField NewField121;
                public TTReportField NewField1121;
                public TTReportField NewField11211;
                public TTReportField NewField1221;
                public TTReportField NewField11221;
                public TTReportField NewField1122;
                public TTReportField NewField112211;
                public TTReportField FATURASAYISI;
                public TTReportField IRSALIYENO;
                public TTReportField IRSALIYETARIH;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField11111;
                public TTReportField FIRMAOBJECTID;
                public TTReportField NewField11222; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 65;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 24, 60, 29, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Dosya No";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 34, 60, 39, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Size = 8;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Yüklenicinin Adı Ünvanı";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 39, 60, 44, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Size = 8;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Yükleniciye ait Fatura Tarih/Nu.sı";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 44, 60, 49, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Size = 8;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Yükleniciye ait İrsaliye Tarih/Nu.sı";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 29, 60, 34, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Size = 8;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Onay Belgesi Karar No";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 24, 203, 29, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 8;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"......../......../20....          4590 -     -  ......../........";

                    YUKLENICIUNVANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 34, 203, 39, false);
                    YUKLENICIUNVANI.Name = "YUKLENICIUNVANI";
                    YUKLENICIUNVANI.DrawStyle = DrawStyleConstants.vbSolid;
                    YUKLENICIUNVANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YUKLENICIUNVANI.ObjectDefName = "FirmDefinition";
                    YUKLENICIUNVANI.DataMember = "NAME";
                    YUKLENICIUNVANI.TextFont.Name = "Arial";
                    YUKLENICIUNVANI.TextFont.Size = 8;
                    YUKLENICIUNVANI.TextFont.CharSet = 162;
                    YUKLENICIUNVANI.Value = @"{#TEDARIKCI#}";

                    FATURATARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 39, 131, 44, false);
                    FATURATARIH.Name = "FATURATARIH";
                    FATURATARIH.DrawStyle = DrawStyleConstants.vbSolid;
                    FATURATARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATURATARIH.TextFormat = @"Short Date";
                    FATURATARIH.TextFont.Name = "Arial";
                    FATURATARIH.TextFont.Size = 8;
                    FATURATARIH.TextFont.CharSet = 162;
                    FATURATARIH.Value = @"{#FATURATARIHI#}";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 29, 203, 34, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Size = 8;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 50, 203, 55, false);
                    NewField6.Name = "NewField6";
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.Underline = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"MUAYENE VE KABUL YAPILAN MALZEME";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 56, 20, 64, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Size = 6;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"S.Nu";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 56, 124, 64, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 6;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"SUT / İşlem Kodu";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 56, 140, 64, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Size = 6;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"SUT / İşlem Fiyatı";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 56, 81, 64, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211.TextFont.Name = "Arial";
                    NewField11211.TextFont.Size = 6;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Malzemenin Adı";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 56, 151, 64, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1221.TextFont.Name = "Arial";
                    NewField1221.TextFont.Size = 6;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"Miktar";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 56, 203, 64, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11221.TextFont.Name = "Arial";
                    NewField11221.TextFont.Size = 6;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @"TUTAR";

                    NewField1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 56, 108, 64, false);
                    NewField1122.Name = "NewField1122";
                    NewField1122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1122.TextFont.Name = "Arial";
                    NewField1122.TextFont.Size = 6;
                    NewField1122.TextFont.Bold = true;
                    NewField1122.TextFont.CharSet = 162;
                    NewField1122.Value = @"UBB Kodu";

                    NewField112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 56, 187, 64, false);
                    NewField112211.Name = "NewField112211";
                    NewField112211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112211.TextFont.Name = "Arial";
                    NewField112211.TextFont.Size = 6;
                    NewField112211.TextFont.Bold = true;
                    NewField112211.TextFont.CharSet = 162;
                    NewField112211.Value = @"Birim Fiyat";

                    FATURASAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 39, 203, 44, false);
                    FATURASAYISI.Name = "FATURASAYISI";
                    FATURASAYISI.DrawStyle = DrawStyleConstants.vbSolid;
                    FATURASAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATURASAYISI.TextFont.Name = "Arial";
                    FATURASAYISI.TextFont.Size = 8;
                    FATURASAYISI.TextFont.CharSet = 162;
                    FATURASAYISI.Value = @"{#FATURASAYISI#}";

                    IRSALIYENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 44, 203, 49, false);
                    IRSALIYENO.Name = "IRSALIYENO";
                    IRSALIYENO.DrawStyle = DrawStyleConstants.vbSolid;
                    IRSALIYENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    IRSALIYENO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IRSALIYENO.TextFont.Name = "Arial";
                    IRSALIYENO.TextFont.Size = 8;
                    IRSALIYENO.TextFont.CharSet = 162;
                    IRSALIYENO.Value = @"{#IRSALIYENO#}";

                    IRSALIYETARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 44, 131, 49, false);
                    IRSALIYETARIH.Name = "IRSALIYETARIH";
                    IRSALIYETARIH.DrawStyle = DrawStyleConstants.vbSolid;
                    IRSALIYETARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    IRSALIYETARIH.TextFormat = @"Short Date";
                    IRSALIYETARIH.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IRSALIYETARIH.TextFont.Name = "Arial";
                    IRSALIYETARIH.TextFont.Size = 8;
                    IRSALIYETARIH.TextFont.CharSet = 162;
                    IRSALIYETARIH.Value = @"{#IRSALIYETARIHI#}";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 5, 203, 23, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.DrawStyle = DrawStyleConstants.vbSolid;
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Size = 8;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + "" BAŞTABİPLİĞİ\r\n"" + ""MAL MUAYENE KABUL VE KULLANIM TUTANAĞI"";";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 16, 36, 21, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Size = 8;
                    NewField11111.TextFont.Underline = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"HİZMETE ÖZEL";

                    FIRMAOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 54, 237, 59, false);
                    FIRMAOBJECTID.Name = "FIRMAOBJECTID";
                    FIRMAOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    FIRMAOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMAOBJECTID.Value = @"{#TEDARIKCI#}";

                    NewField11222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 56, 170, 64, false);
                    NewField11222.Name = "NewField11222";
                    NewField11222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11222.TextFont.Name = "Arial";
                    NewField11222.TextFont.Size = 6;
                    NewField11222.TextFont.Bold = true;
                    NewField11222.TextFont.CharSet = 162;
                    NewField11222.Value = @"Ölçü Birimi";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DirectPurchaseAction.MaterielInspectionAndReceivingFirmInfoNQL_Class dataset_MaterielInspectionAndReceivingFirmInfoNQL = ParentGroup.rsGroup.GetCurrentRecord<DirectPurchaseAction.MaterielInspectionAndReceivingFirmInfoNQL_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField11.CalcValue = NewField11.Value;
                    YUKLENICIUNVANI.CalcValue = (dataset_MaterielInspectionAndReceivingFirmInfoNQL != null ? Globals.ToStringCore(dataset_MaterielInspectionAndReceivingFirmInfoNQL.Tedarikci) : "");
                    YUKLENICIUNVANI.PostFieldValueCalculation();
                    FATURATARIH.CalcValue = (dataset_MaterielInspectionAndReceivingFirmInfoNQL != null ? Globals.ToStringCore(dataset_MaterielInspectionAndReceivingFirmInfoNQL.Faturatarihi) : "");
                    NewField15.CalcValue = NewField15.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField1122.CalcValue = NewField1122.Value;
                    NewField112211.CalcValue = NewField112211.Value;
                    FATURASAYISI.CalcValue = (dataset_MaterielInspectionAndReceivingFirmInfoNQL != null ? Globals.ToStringCore(dataset_MaterielInspectionAndReceivingFirmInfoNQL.Faturasayisi) : "");
                    IRSALIYENO.CalcValue = (dataset_MaterielInspectionAndReceivingFirmInfoNQL != null ? Globals.ToStringCore(dataset_MaterielInspectionAndReceivingFirmInfoNQL.Irsaliyeno) : "");
                    IRSALIYETARIH.CalcValue = (dataset_MaterielInspectionAndReceivingFirmInfoNQL != null ? Globals.ToStringCore(dataset_MaterielInspectionAndReceivingFirmInfoNQL.Irsaliyetarihi) : "");
                    NewField11111.CalcValue = NewField11111.Value;
                    FIRMAOBJECTID.CalcValue = (dataset_MaterielInspectionAndReceivingFirmInfoNQL != null ? Globals.ToStringCore(dataset_MaterielInspectionAndReceivingFirmInfoNQL.Tedarikci) : "");
                    NewField11222.CalcValue = NewField11222.Value;
                    XXXXXXBASLIK.CalcValue = XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + " BAŞTABİPLİĞİ\r\n" + "MAL MUAYENE KABUL VE KULLANIM TUTANAĞI";;
                    return new TTReportObject[] { NewField1,NewField2,NewField3,NewField4,NewField5,NewField11,YUKLENICIUNVANI,FATURATARIH,NewField15,NewField6,NewField16,NewField121,NewField1121,NewField11211,NewField1221,NewField11221,NewField1122,NewField112211,FATURASAYISI,IRSALIYENO,IRSALIYETARIH,NewField11111,FIRMAOBJECTID,NewField11222,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    ((MaterialInspectionAndReceivingReport)ParentReport).RuntimeParameters.FIRMOBJECTID = this.FIRMAOBJECTID.CalcValue;
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public MaterialInspectionAndReceivingReport MyParentReport
                {
                    get { return (MaterialInspectionAndReceivingReport)ParentReport; }
                }
                
                public TTReportField TEXT1;
                public TTReportField NewField20;
                public TTReportField NewField10;
                public TTReportField NewField101;
                public TTReportField NewField102;
                public TTReportField BASKAN;
                public TTReportField TEXT2;
                public TTReportField UZMANLIK;
                public TTReportField TCKIMLIKNO;
                public TTReportField HASTAISIM;
                public TTReportField OBJECTID;
                public TTReportField UYE1;
                public TTReportField UYE2;
                public TTReportField NewField11031;
                public TTReportField NewField11121;
                public TTReportField NewField1231;
                public TTReportField NewField11321;
                public TTReportField TEDARIKCI; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 116;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TEXT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 1, 203, 13, false);
                    TEXT1.Name = "TEXT1";
                    TEXT1.DrawStyle = DrawStyleConstants.vbSolid;
                    TEXT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEXT1.MultiLine = EvetHayirEnum.ehEvet;
                    TEXT1.WordBreak = EvetHayirEnum.ehEvet;
                    TEXT1.TextFont.Name = "Arial";
                    TEXT1.TextFont.Size = 8;
                    TEXT1.TextFont.CharSet = 162;
                    TEXT1.Value = @"";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 14, 203, 19, false);
                    NewField20.Name = "NewField20";
                    NewField20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField20.TextFont.Bold = true;
                    NewField20.TextFont.Underline = true;
                    NewField20.TextFont.CharSet = 162;
                    NewField20.Value = @"KABULÜ GERÇEKLEŞTİREN GÖREVLİLER";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 20, 38, 25, false);
                    NewField10.Name = "NewField10";
                    NewField10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField10.TextFont.Size = 9;
                    NewField10.TextFont.Bold = true;
                    NewField10.TextFont.Underline = true;
                    NewField10.TextFont.CharSet = 162;
                    NewField10.Value = @"BAŞKAN";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 20, 177, 25, false);
                    NewField101.Name = "NewField101";
                    NewField101.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField101.TextFont.Size = 9;
                    NewField101.TextFont.Bold = true;
                    NewField101.TextFont.Underline = true;
                    NewField101.TextFont.CharSet = 162;
                    NewField101.Value = @"ÜYE";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 20, 107, 25, false);
                    NewField102.Name = "NewField102";
                    NewField102.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField102.TextFont.Size = 9;
                    NewField102.TextFont.Bold = true;
                    NewField102.TextFont.Underline = true;
                    NewField102.TextFont.CharSet = 162;
                    NewField102.Value = @"ÜYE";

                    BASKAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 26, 64, 41, false);
                    BASKAN.Name = "BASKAN";
                    BASKAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASKAN.MultiLine = EvetHayirEnum.ehEvet;
                    BASKAN.WordBreak = EvetHayirEnum.ehEvet;
                    BASKAN.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASKAN.TextFont.Name = "Arial";
                    BASKAN.TextFont.Size = 8;
                    BASKAN.TextFont.CharSet = 162;
                    BASKAN.Value = @"";

                    TEXT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 42, 203, 50, false);
                    TEXT2.Name = "TEXT2";
                    TEXT2.DrawStyle = DrawStyleConstants.vbSolid;
                    TEXT2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEXT2.MultiLine = EvetHayirEnum.ehEvet;
                    TEXT2.WordBreak = EvetHayirEnum.ehEvet;
                    TEXT2.TextFont.Name = "Arial";
                    TEXT2.TextFont.Size = 8;
                    TEXT2.TextFont.CharSet = 162;
                    TEXT2.Value = @"";

                    UZMANLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 1, 237, 5, false);
                    UZMANLIK.Name = "UZMANLIK";
                    UZMANLIK.Visible = EvetHayirEnum.ehHayir;
                    UZMANLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UZMANLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UZMANLIK.ObjectDefName = "ResSection";
                    UZMANLIK.DataMember = "NAME";
                    UZMANLIK.TextFont.Name = "Arial";
                    UZMANLIK.TextFont.CharSet = 162;
                    UZMANLIK.Value = @"{#PARTA.UZMANLIK#}";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 6, 237, 10, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.Visible = EvetHayirEnum.ehHayir;
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TCKIMLIKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCKIMLIKNO.TextFont.Name = "Arial";
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#PARTA.TCKIMLIKNO#}";

                    HASTAISIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 11, 237, 15, false);
                    HASTAISIM.Name = "HASTAISIM";
                    HASTAISIM.Visible = EvetHayirEnum.ehHayir;
                    HASTAISIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAISIM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HASTAISIM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HASTAISIM.TextFont.Name = "Arial";
                    HASTAISIM.TextFont.CharSet = 162;
                    HASTAISIM.Value = @"{#PARTA.ISIM#} {#PARTA.SOYISIM#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 16, 237, 21, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OBJECTID.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OBJECTID.TextFont.Name = "Arial";
                    OBJECTID.TextFont.CharSet = 162;
                    OBJECTID.Value = @"{#PARTA.OBJECTID#}";

                    UYE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 26, 133, 41, false);
                    UYE1.Name = "UYE1";
                    UYE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    UYE1.MultiLine = EvetHayirEnum.ehEvet;
                    UYE1.WordBreak = EvetHayirEnum.ehEvet;
                    UYE1.ExpandTabs = EvetHayirEnum.ehEvet;
                    UYE1.TextFont.Name = "Arial";
                    UYE1.TextFont.Size = 8;
                    UYE1.TextFont.CharSet = 162;
                    UYE1.Value = @"";

                    UYE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 26, 203, 41, false);
                    UYE2.Name = "UYE2";
                    UYE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    UYE2.MultiLine = EvetHayirEnum.ehEvet;
                    UYE2.WordBreak = EvetHayirEnum.ehEvet;
                    UYE2.ExpandTabs = EvetHayirEnum.ehEvet;
                    UYE2.TextFont.Name = "Arial";
                    UYE2.TextFont.Size = 8;
                    UYE2.TextFont.CharSet = 162;
                    UYE2.Value = @"";

                    NewField11031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 51, 203, 56, false);
                    NewField11031.Name = "NewField11031";
                    NewField11031.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11031.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11031.TextFont.Bold = true;
                    NewField11031.TextFont.Underline = true;
                    NewField11031.TextFont.CharSet = 162;
                    NewField11031.Value = @"İŞLEMİ YAPAN / YAPANLAR";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 57, 203, 77, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.Value = @"";

                    NewField1231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 77, 108, 108, false);
                    NewField1231.Name = "NewField1231";
                    NewField1231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1231.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1231.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1231.TextFont.Name = "Arial";
                    NewField1231.TextFont.Size = 8;
                    NewField1231.TextFont.CharSet = 162;
                    NewField1231.Value = @"Hasta adına tedarik edilen malzemeye ait tedarik bilgilerinin KİK kayıtları yapılmıştır.

İmzası		:


Adı Soyadı	:
Ünvanı		: 
";

                    NewField11321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 77, 203, 108, false);
                    NewField11321.Name = "NewField11321";
                    NewField11321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11321.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11321.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11321.TextFont.Name = "Arial";
                    NewField11321.TextFont.Size = 8;
                    NewField11321.TextFont.CharSet = 162;
                    NewField11321.Value = @"Hasta adına tedarik edilen malzeme fatura edilmiştir.


İmzası		:


Adı Soyadı	:
Ünvanı		: Büt. Ml / Dö-Se. Ş.Md.";

                    TEDARIKCI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 22, 237, 27, false);
                    TEDARIKCI.Name = "TEDARIKCI";
                    TEDARIKCI.Visible = EvetHayirEnum.ehHayir;
                    TEDARIKCI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEDARIKCI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEDARIKCI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEDARIKCI.ObjectDefName = "FirmDefinition";
                    TEDARIKCI.DataMember = "NAME";
                    TEDARIKCI.TextFont.Name = "Arial";
                    TEDARIKCI.TextFont.CharSet = 162;
                    TEDARIKCI.Value = @"{#TEDARIKCI#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DirectPurchaseAction.MaterielInspectionAndReceivingFirmInfoNQL_Class dataset_MaterielInspectionAndReceivingFirmInfoNQL = ParentGroup.rsGroup.GetCurrentRecord<DirectPurchaseAction.MaterielInspectionAndReceivingFirmInfoNQL_Class>(0);
                    DirectPurchaseAction.MaterielInspectionAndReceivingPatientInfoNQL_Class dataset_MaterielInspectionAndReceivingPatientInfoNQL = MyParentReport.PARTA.rsGroup.GetCurrentRecord<DirectPurchaseAction.MaterielInspectionAndReceivingPatientInfoNQL_Class>(0);
                    TEXT1.CalcValue = @"";
                    NewField20.CalcValue = NewField20.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField101.CalcValue = NewField101.Value;
                    NewField102.CalcValue = NewField102.Value;
                    BASKAN.CalcValue = @"";
                    TEXT2.CalcValue = @"";
                    UZMANLIK.CalcValue = (dataset_MaterielInspectionAndReceivingPatientInfoNQL != null ? Globals.ToStringCore(dataset_MaterielInspectionAndReceivingPatientInfoNQL.Uzmanlik) : "");
                    UZMANLIK.PostFieldValueCalculation();
                    TCKIMLIKNO.CalcValue = (dataset_MaterielInspectionAndReceivingPatientInfoNQL != null ? Globals.ToStringCore(dataset_MaterielInspectionAndReceivingPatientInfoNQL.Tckimlikno) : "");
                    HASTAISIM.CalcValue = (dataset_MaterielInspectionAndReceivingPatientInfoNQL != null ? Globals.ToStringCore(dataset_MaterielInspectionAndReceivingPatientInfoNQL.Isim) : "") + @" " + (dataset_MaterielInspectionAndReceivingPatientInfoNQL != null ? Globals.ToStringCore(dataset_MaterielInspectionAndReceivingPatientInfoNQL.Soyisim) : "");
                    OBJECTID.CalcValue = (dataset_MaterielInspectionAndReceivingPatientInfoNQL != null ? Globals.ToStringCore(dataset_MaterielInspectionAndReceivingPatientInfoNQL.ObjectID) : "");
                    UYE1.CalcValue = @"";
                    UYE2.CalcValue = @"";
                    NewField11031.CalcValue = NewField11031.Value;
                    NewField11121.CalcValue = NewField11121.Value;
                    NewField1231.CalcValue = NewField1231.Value;
                    NewField11321.CalcValue = NewField11321.Value;
                    TEDARIKCI.CalcValue = (dataset_MaterielInspectionAndReceivingFirmInfoNQL != null ? Globals.ToStringCore(dataset_MaterielInspectionAndReceivingFirmInfoNQL.Tedarikci) : "");
                    TEDARIKCI.PostFieldValueCalculation();
                    return new TTReportObject[] { TEXT1,NewField20,NewField10,NewField101,NewField102,BASKAN,TEXT2,UZMANLIK,TCKIMLIKNO,HASTAISIM,OBJECTID,UYE1,UYE2,NewField11031,NewField11121,NewField1231,NewField11321,TEDARIKCI};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    string a = "XXXXXXmiz " + this.UZMANLIK.CalcValue + " A.D.Bşk.lığı/servisinde (" + this.TCKIMLIKNO.CalcValue + ") " + this.HASTAISIM.CalcValue + " adlı hastanın işlemi için temin edilen yukarıda belirtilen " + ((MaterialInspectionAndReceivingReport)ParentReport).counter + " kalem tıbbi mlz. " + this.TEDARIKCI.CalcValue + " 'nden temin edilmiş ve malzemelerin niteliklere uygun olduğu tarafımızca muayene edilerek oybirliği ile kabul edilmiştir.";
            ((MaterialInspectionAndReceivingReport)ParentReport).counter = 0;
            this.TEXT1.CalcValue = a;
            
            string b = "Yukarıda belirtilen tıbbi malzemeler ........ Protokol numaralı işlem ile ......../......../........ tarihinde " + this.TCKIMLIKNO.CalcValue + " " + this.HASTAISIM.CalcValue + " adlı hastada kullanılarak sarf edilmiştir.";
            this.TEXT2.CalcValue = b;
            
            string objectID = this.OBJECTID.CalcValue;
            DirectPurchaseAction dpa = (DirectPurchaseAction)MyParentReport.ReportObjectContext.GetObject(new Guid(objectID), typeof(DirectPurchaseAction));
            string baskan = string.Empty;
            string uye1 = string.Empty;
            string uye2 = string.Empty;
            
            List<CommisionMember> commisionSelectedMember = new List<CommisionMember>();
            //List<CommisionMember> commisionBackupMember = new List<CommisionMember>();

            foreach (DirectPurchaseCommisionMember member in dpa.CommissionMembers)
            {
                if (member.MemberDuty.ToString() == DPACommisionMemberDutyEnum.Chief.ToString())
                {
                    if (member.PrintOnMatInspection == true)
                    {
                        if (member.ResUser.Title.HasValue)
                        {
                            TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(UserTitleEnum).Name];
                            baskan += dataType.EnumValueDefs[(int)member.ResUser.Title.Value].DisplayText + " ";
                            baskan += member.ResUser.Name + "\r\n";
                        }
                        else
                        {
                            baskan += member.ResUser.Name + "\r\n";
                        }
                        if (member.ResUser.MilitaryClass != null)
                        {
                            baskan += member.ResUser.MilitaryClass.ShortName;
                        }
                        if (member.ResUser.Rank != null)
                        {
                            baskan += member.ResUser.Rank.ShortName + "\r\n";
                            //baskan += "(" + member.ResUser.EmploymentRecordID + ")";
                            BASKAN.CalcValue = baskan;
                        }
                    }
                }

                if (member.MemberDuty.ToString() == DPACommisionMemberDutyEnum.Member.ToString())
                {
                    if (member.PrintOnMatInspection == true)
                    {
                        commisionSelectedMember.Add(member);
                    }
                }
            }

            if (commisionSelectedMember[0].ResUser.Title.HasValue)
            {
                TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(UserTitleEnum).Name];
                uye1 += dataType.EnumValueDefs[(int)commisionSelectedMember[0].ResUser.Title.Value].DisplayText + " ";
                uye1 += commisionSelectedMember[0].ResUser.Name + "\r\n";
            }
            else
            {
                uye1 += commisionSelectedMember[0].ResUser.Name + "\r\n";
            }
            if (commisionSelectedMember[0].ResUser.MilitaryClass != null)
            {
                uye1 += commisionSelectedMember[0].ResUser.MilitaryClass.ShortName;
            }
            if (commisionSelectedMember[0].ResUser.Rank != null)
            {
                uye1 += commisionSelectedMember[0].ResUser.Rank.ShortName + "\r\n";
                //uye1 += "(" + commisionSelectedMember[0].ResUser.EmploymentRecordID + ")";
                UYE1.CalcValue = uye1;
            }

            if (commisionSelectedMember[1].ResUser.Title.HasValue)
            {
                TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(UserTitleEnum).Name];
                uye2 += dataType.EnumValueDefs[(int)commisionSelectedMember[1].ResUser.Title.Value].DisplayText + " ";
                uye2 += commisionSelectedMember[1].ResUser.Name + "\r\n";
            }
            else
            {
                uye2 += commisionSelectedMember[1].ResUser.Name + "\r\n";
            }
            if (commisionSelectedMember[1].ResUser.MilitaryClass != null)
            {
                uye2 += commisionSelectedMember[1].ResUser.MilitaryClass.ShortName;
            }
            if (commisionSelectedMember[1].ResUser.Rank != null)
            {
                uye2 += commisionSelectedMember[1].ResUser.Rank.ShortName + "\r\n";
                //uye2 += "(" + commisionSelectedMember[1].ResUser.EmploymentRecordID + ")";
                UYE2.CalcValue = uye2;
            }
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public MaterialInspectionAndReceivingReport MyParentReport
            {
                get { return (MaterialInspectionAndReceivingReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField SUTKODU { get {return Body().SUTKODU;} }
            public TTReportField SUTFIYAT { get {return Body().SUTFIYAT;} }
            public TTReportField MALZEMENINADI { get {return Body().MALZEMENINADI;} }
            public TTReportField MIKTAR { get {return Body().MIKTAR;} }
            public TTReportField TUTAR { get {return Body().TUTAR;} }
            public TTReportField UBBKODU { get {return Body().UBBKODU;} }
            public TTReportField BIRIMFIYAT { get {return Body().BIRIMFIYAT;} }
            public TTReportField KDV { get {return Body().KDV;} }
            public TTReportField OLCUBIRIMI { get {return Body().OLCUBIRIMI;} }
            public TTReportField UBBMALZEMEADI { get {return Body().UBBMALZEMEADI;} }
            public TTReportField RPCMALZEMEADI { get {return Body().RPCMALZEMEADI;} }
            public TTReportField UBBKOD { get {return Body().UBBKOD;} }
            public TTReportField ISLEMKODU { get {return Body().ISLEMKODU;} }
            public TTReportField SUTKOD { get {return Body().SUTKOD;} }
            public TTReportField CODELESSMATNAME { get {return Body().CODELESSMATNAME;} }
            public TTReportField MATCHEDSUTCODE { get {return Body().MATCHEDSUTCODE;} }
            public TTReportField MATCHEDSUTPRICE { get {return Body().MATCHEDSUTPRICE;} }
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
                list[0] = new TTReportNqlData<DPADetailFirmPriceOffer.MaterialInspectionAndReceivingReportInfoNQL_Class>("MaterialInspectionAndReceivingReportInfoNQL", DPADetailFirmPriceOffer.MaterialInspectionAndReceivingReportInfoNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.FIRMOBJECTID)));
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
                public MaterialInspectionAndReceivingReport MyParentReport
                {
                    get { return (MaterialInspectionAndReceivingReport)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField SUTKODU;
                public TTReportField SUTFIYAT;
                public TTReportField MALZEMENINADI;
                public TTReportField MIKTAR;
                public TTReportField TUTAR;
                public TTReportField UBBKODU;
                public TTReportField BIRIMFIYAT;
                public TTReportField KDV;
                public TTReportField OLCUBIRIMI;
                public TTReportField UBBMALZEMEADI;
                public TTReportField RPCMALZEMEADI;
                public TTReportField UBBKOD;
                public TTReportField ISLEMKODU;
                public TTReportField SUTKOD;
                public TTReportField CODELESSMATNAME;
                public TTReportField MATCHEDSUTCODE;
                public TTReportField MATCHEDSUTPRICE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 20, 8, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.DrawStyle = DrawStyleConstants.vbSolid;
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIRANO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIRANO.MultiLine = EvetHayirEnum.ehEvet;
                    SIRANO.WordBreak = EvetHayirEnum.ehEvet;
                    SIRANO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIRANO.TextFont.Name = "Arial";
                    SIRANO.TextFont.Size = 8;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    SUTKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 0, 124, 8, false);
                    SUTKODU.Name = "SUTKODU";
                    SUTKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUTKODU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUTKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTKODU.MultiLine = EvetHayirEnum.ehEvet;
                    SUTKODU.WordBreak = EvetHayirEnum.ehEvet;
                    SUTKODU.ExpandTabs = EvetHayirEnum.ehEvet;
                    SUTKODU.TextFont.Name = "Arial";
                    SUTKODU.TextFont.Size = 8;
                    SUTKODU.TextFont.CharSet = 162;
                    SUTKODU.Value = @"";

                    SUTFIYAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 0, 140, 8, false);
                    SUTFIYAT.Name = "SUTFIYAT";
                    SUTFIYAT.DrawStyle = DrawStyleConstants.vbSolid;
                    SUTFIYAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUTFIYAT.TextFormat = @"#,##0.#0";
                    SUTFIYAT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUTFIYAT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTFIYAT.MultiLine = EvetHayirEnum.ehEvet;
                    SUTFIYAT.WordBreak = EvetHayirEnum.ehEvet;
                    SUTFIYAT.ExpandTabs = EvetHayirEnum.ehEvet;
                    SUTFIYAT.TextFont.Name = "Arial";
                    SUTFIYAT.TextFont.Size = 8;
                    SUTFIYAT.TextFont.CharSet = 162;
                    SUTFIYAT.Value = @"{#SUTFIYAT#}";

                    MALZEMENINADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 81, 8, false);
                    MALZEMENINADI.Name = "MALZEMENINADI";
                    MALZEMENINADI.DrawStyle = DrawStyleConstants.vbSolid;
                    MALZEMENINADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMENINADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MALZEMENINADI.MultiLine = EvetHayirEnum.ehEvet;
                    MALZEMENINADI.WordBreak = EvetHayirEnum.ehEvet;
                    MALZEMENINADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    MALZEMENINADI.TextFont.Name = "Arial";
                    MALZEMENINADI.TextFont.Size = 8;
                    MALZEMENINADI.TextFont.CharSet = 162;
                    MALZEMENINADI.Value = @"";

                    MIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 0, 151, 8, false);
                    MIKTAR.Name = "MIKTAR";
                    MIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MIKTAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR.MultiLine = EvetHayirEnum.ehEvet;
                    MIKTAR.WordBreak = EvetHayirEnum.ehEvet;
                    MIKTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    MIKTAR.TextFont.Name = "Arial";
                    MIKTAR.TextFont.Size = 8;
                    MIKTAR.TextFont.CharSet = 162;
                    MIKTAR.Value = @"{#KESINLESENMIKTAR#}";

                    TUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 0, 203, 8, false);
                    TUTAR.Name = "TUTAR";
                    TUTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    TUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TUTAR.TextFormat = @"#,##0.#0";
                    TUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TUTAR.MultiLine = EvetHayirEnum.ehEvet;
                    TUTAR.WordBreak = EvetHayirEnum.ehEvet;
                    TUTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    TUTAR.TextFont.Name = "Arial";
                    TUTAR.TextFont.Size = 8;
                    TUTAR.TextFont.CharSet = 162;
                    TUTAR.Value = @"";

                    UBBKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 0, 108, 8, false);
                    UBBKODU.Name = "UBBKODU";
                    UBBKODU.DrawStyle = DrawStyleConstants.vbSolid;
                    UBBKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    UBBKODU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBBKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBBKODU.MultiLine = EvetHayirEnum.ehEvet;
                    UBBKODU.WordBreak = EvetHayirEnum.ehEvet;
                    UBBKODU.ExpandTabs = EvetHayirEnum.ehEvet;
                    UBBKODU.TextFont.Name = "Arial";
                    UBBKODU.TextFont.Size = 8;
                    UBBKODU.TextFont.CharSet = 162;
                    UBBKODU.Value = @"";

                    BIRIMFIYAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 0, 187, 8, false);
                    BIRIMFIYAT.Name = "BIRIMFIYAT";
                    BIRIMFIYAT.DrawStyle = DrawStyleConstants.vbSolid;
                    BIRIMFIYAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMFIYAT.TextFormat = @"#,##0.#0";
                    BIRIMFIYAT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BIRIMFIYAT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BIRIMFIYAT.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIMFIYAT.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIMFIYAT.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRIMFIYAT.TextFont.Name = "Arial";
                    BIRIMFIYAT.TextFont.Size = 8;
                    BIRIMFIYAT.TextFont.CharSet = 162;
                    BIRIMFIYAT.Value = @"{#BIRIMFIYAT#}";

                    KDV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 1, 222, 6, false);
                    KDV.Name = "KDV";
                    KDV.Visible = EvetHayirEnum.ehHayir;
                    KDV.FieldType = ReportFieldTypeEnum.ftVariable;
                    KDV.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KDV.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KDV.TextFont.Name = "Arial";
                    KDV.TextFont.Size = 8;
                    KDV.TextFont.CharSet = 162;
                    KDV.Value = @"{#KDV#}";

                    OLCUBIRIMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 0, 170, 8, false);
                    OLCUBIRIMI.Name = "OLCUBIRIMI";
                    OLCUBIRIMI.DrawStyle = DrawStyleConstants.vbSolid;
                    OLCUBIRIMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLCUBIRIMI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OLCUBIRIMI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLCUBIRIMI.MultiLine = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI.WordBreak = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI.ExpandTabs = EvetHayirEnum.ehEvet;
                    OLCUBIRIMI.ObjectDefName = "DistributionTypeDefinition";
                    OLCUBIRIMI.DataMember = "DISTRIBUTIONTYPE";
                    OLCUBIRIMI.TextFont.Name = "Arial";
                    OLCUBIRIMI.TextFont.Size = 8;
                    OLCUBIRIMI.TextFont.CharSet = 162;
                    OLCUBIRIMI.Value = @"{#OLCUBIRIMI#}";

                    UBBMALZEMEADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 1, 243, 6, false);
                    UBBMALZEMEADI.Name = "UBBMALZEMEADI";
                    UBBMALZEMEADI.Visible = EvetHayirEnum.ehHayir;
                    UBBMALZEMEADI.DrawStyle = DrawStyleConstants.vbSolid;
                    UBBMALZEMEADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    UBBMALZEMEADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBBMALZEMEADI.MultiLine = EvetHayirEnum.ehEvet;
                    UBBMALZEMEADI.WordBreak = EvetHayirEnum.ehEvet;
                    UBBMALZEMEADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    UBBMALZEMEADI.TextFont.Name = "Arial";
                    UBBMALZEMEADI.TextFont.Size = 8;
                    UBBMALZEMEADI.TextFont.CharSet = 162;
                    UBBMALZEMEADI.Value = @"{#TALEPCINSI#}";

                    RPCMALZEMEADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 1, 267, 6, false);
                    RPCMALZEMEADI.Name = "RPCMALZEMEADI";
                    RPCMALZEMEADI.Visible = EvetHayirEnum.ehHayir;
                    RPCMALZEMEADI.DrawStyle = DrawStyleConstants.vbSolid;
                    RPCMALZEMEADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RPCMALZEMEADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RPCMALZEMEADI.MultiLine = EvetHayirEnum.ehEvet;
                    RPCMALZEMEADI.WordBreak = EvetHayirEnum.ehEvet;
                    RPCMALZEMEADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    RPCMALZEMEADI.TextFont.Name = "Arial";
                    RPCMALZEMEADI.TextFont.Size = 8;
                    RPCMALZEMEADI.TextFont.CharSet = 162;
                    RPCMALZEMEADI.Value = @"{#RPCMATERIALNAME#}";

                    UBBKOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 268, 1, 281, 6, false);
                    UBBKOD.Name = "UBBKOD";
                    UBBKOD.Visible = EvetHayirEnum.ehHayir;
                    UBBKOD.DrawStyle = DrawStyleConstants.vbSolid;
                    UBBKOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    UBBKOD.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UBBKOD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UBBKOD.MultiLine = EvetHayirEnum.ehEvet;
                    UBBKOD.WordBreak = EvetHayirEnum.ehEvet;
                    UBBKOD.ExpandTabs = EvetHayirEnum.ehEvet;
                    UBBKOD.ObjectDefName = "ProductDefinition";
                    UBBKOD.DataMember = "PRODUCTNUMBER";
                    UBBKOD.TextFont.Name = "Arial";
                    UBBKOD.TextFont.Size = 8;
                    UBBKOD.TextFont.CharSet = 162;
                    UBBKOD.Value = @"{#UBBKODU#}";

                    ISLEMKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 282, 1, 297, 6, false);
                    ISLEMKODU.Name = "ISLEMKODU";
                    ISLEMKODU.Visible = EvetHayirEnum.ehHayir;
                    ISLEMKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISLEMKODU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ISLEMKODU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISLEMKODU.TextFont.Name = "Arial";
                    ISLEMKODU.TextFont.Size = 8;
                    ISLEMKODU.TextFont.CharSet = 162;
                    ISLEMKODU.Value = @"{#ISLEMKODU#}";

                    SUTKOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 1, 311, 6, false);
                    SUTKOD.Name = "SUTKOD";
                    SUTKOD.Visible = EvetHayirEnum.ehHayir;
                    SUTKOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUTKOD.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUTKOD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUTKOD.ObjectDefName = "ProductSUTMatchDefinition";
                    SUTKOD.DataMember = "SUTCODE";
                    SUTKOD.TextFont.Name = "Arial";
                    SUTKOD.TextFont.Size = 8;
                    SUTKOD.TextFont.CharSet = 162;
                    SUTKOD.Value = @"{#SUTKODU#}";

                    CODELESSMATNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 312, 1, 337, 6, false);
                    CODELESSMATNAME.Name = "CODELESSMATNAME";
                    CODELESSMATNAME.Visible = EvetHayirEnum.ehHayir;
                    CODELESSMATNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODELESSMATNAME.Value = @"{#CODELESSMATERIALNAME#}";

                    MATCHEDSUTCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 293, 7, 315, 12, false);
                    MATCHEDSUTCODE.Name = "MATCHEDSUTCODE";
                    MATCHEDSUTCODE.Visible = EvetHayirEnum.ehHayir;
                    MATCHEDSUTCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATCHEDSUTCODE.Value = @"{#MATCHEDSUTCODE#}";

                    MATCHEDSUTPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 277, 7, 292, 12, false);
                    MATCHEDSUTPRICE.Name = "MATCHEDSUTPRICE";
                    MATCHEDSUTPRICE.Visible = EvetHayirEnum.ehHayir;
                    MATCHEDSUTPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATCHEDSUTPRICE.Value = @"{#MATCHEDSUTPRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DPADetailFirmPriceOffer.MaterialInspectionAndReceivingReportInfoNQL_Class dataset_MaterialInspectionAndReceivingReportInfoNQL = ParentGroup.rsGroup.GetCurrentRecord<DPADetailFirmPriceOffer.MaterialInspectionAndReceivingReportInfoNQL_Class>(0);
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    SUTKODU.CalcValue = @"";
                    SUTFIYAT.CalcValue = (dataset_MaterialInspectionAndReceivingReportInfoNQL != null ? Globals.ToStringCore(dataset_MaterialInspectionAndReceivingReportInfoNQL.Sutfiyat) : "");
                    MALZEMENINADI.CalcValue = @"";
                    MIKTAR.CalcValue = (dataset_MaterialInspectionAndReceivingReportInfoNQL != null ? Globals.ToStringCore(dataset_MaterialInspectionAndReceivingReportInfoNQL.Kesinlesenmiktar) : "");
                    TUTAR.CalcValue = @"";
                    UBBKODU.CalcValue = @"";
                    BIRIMFIYAT.CalcValue = (dataset_MaterialInspectionAndReceivingReportInfoNQL != null ? Globals.ToStringCore(dataset_MaterialInspectionAndReceivingReportInfoNQL.Birimfiyat) : "");
                    KDV.CalcValue = (dataset_MaterialInspectionAndReceivingReportInfoNQL != null ? Globals.ToStringCore(dataset_MaterialInspectionAndReceivingReportInfoNQL.KDV) : "");
                    OLCUBIRIMI.CalcValue = (dataset_MaterialInspectionAndReceivingReportInfoNQL != null ? Globals.ToStringCore(dataset_MaterialInspectionAndReceivingReportInfoNQL.Olcubirimi) : "");
                    OLCUBIRIMI.PostFieldValueCalculation();
                    UBBMALZEMEADI.CalcValue = (dataset_MaterialInspectionAndReceivingReportInfoNQL != null ? Globals.ToStringCore(dataset_MaterialInspectionAndReceivingReportInfoNQL.Talepcinsi) : "");
                    RPCMALZEMEADI.CalcValue = (dataset_MaterialInspectionAndReceivingReportInfoNQL != null ? Globals.ToStringCore(dataset_MaterialInspectionAndReceivingReportInfoNQL.Rpcmaterialname) : "");
                    UBBKOD.CalcValue = (dataset_MaterialInspectionAndReceivingReportInfoNQL != null ? Globals.ToStringCore(dataset_MaterialInspectionAndReceivingReportInfoNQL.Ubbkodu) : "");
                    UBBKOD.PostFieldValueCalculation();
                    ISLEMKODU.CalcValue = (dataset_MaterialInspectionAndReceivingReportInfoNQL != null ? Globals.ToStringCore(dataset_MaterialInspectionAndReceivingReportInfoNQL.Islemkodu) : "");
                    SUTKOD.CalcValue = (dataset_MaterialInspectionAndReceivingReportInfoNQL != null ? Globals.ToStringCore(dataset_MaterialInspectionAndReceivingReportInfoNQL.Sutkodu) : "");
                    SUTKOD.PostFieldValueCalculation();
                    CODELESSMATNAME.CalcValue = (dataset_MaterialInspectionAndReceivingReportInfoNQL != null ? Globals.ToStringCore(dataset_MaterialInspectionAndReceivingReportInfoNQL.Codelessmaterialname) : "");
                    MATCHEDSUTCODE.CalcValue = (dataset_MaterialInspectionAndReceivingReportInfoNQL != null ? Globals.ToStringCore(dataset_MaterialInspectionAndReceivingReportInfoNQL.MatchedSUTCode) : "");
                    MATCHEDSUTPRICE.CalcValue = (dataset_MaterialInspectionAndReceivingReportInfoNQL != null ? Globals.ToStringCore(dataset_MaterialInspectionAndReceivingReportInfoNQL.MatchedSUTPrice) : "");
                    return new TTReportObject[] { SIRANO,SUTKODU,SUTFIYAT,MALZEMENINADI,MIKTAR,TUTAR,UBBKODU,BIRIMFIYAT,KDV,OLCUBIRIMI,UBBMALZEMEADI,RPCMALZEMEADI,UBBKOD,ISLEMKODU,SUTKOD,CODELESSMATNAME,MATCHEDSUTCODE,MATCHEDSUTPRICE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    ((MaterialInspectionAndReceivingReport)ParentReport).counter++;
            
            this.TUTAR.CalcValue = (Convert.ToDouble(this.MIKTAR.CalcValue)*Convert.ToDouble(BIRIMFIYAT.CalcValue)).ToString();
            
            ((MaterialInspectionAndReceivingReport)ParentReport).toplamTutar += Convert.ToDouble(this.TUTAR.CalcValue);
            
            if(this.KDV.CalcValue == "Eight")
            {
                ((MaterialInspectionAndReceivingReport)ParentReport).kdv8 += Convert.ToDouble(this.TUTAR.CalcValue) * 8 / 100;
            }
            else if (this.KDV.CalcValue == "Eighteen")
            {
                ((MaterialInspectionAndReceivingReport)ParentReport).kdv18 += Convert.ToDouble(this.TUTAR.CalcValue) * 18 / 100;
            }
            
            TTObjectContext ctx = new TTObjectContext(true);
            string objectID = ((MaterialInspectionAndReceivingReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            DirectPurchaseAction dpa = (DirectPurchaseAction)ctx.GetObject(new Guid(objectID), typeof(DirectPurchaseAction));

            if (dpa.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.RadioPharmaceutical)
            {
                this.MALZEMENINADI.CalcValue = this.RPCMALZEMEADI.CalcValue;
                string UBB = "UBB Kapsam Dışı";
                this.UBBKODU.CalcValue = UBB;
                this.SUTKODU.CalcValue = this.ISLEMKODU.CalcValue;
            }
            else if (dpa.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Titubb)
            {
                this.MALZEMENINADI.CalcValue = this.UBBMALZEMEADI.CalcValue;
                this.UBBKODU.CalcValue = this.UBBKOD.CalcValue;
                this.SUTKODU.CalcValue = this.SUTKOD.CalcValue;
            }
            else if (dpa.DirectPurchaseActionType == DirectPurchaseActionTypeEnum.Codeless)
            {
                this.MALZEMENINADI.CalcValue = this.CODELESSMATNAME.CalcValue;
                string UBB = "UBB Kapsam Dışı";
                this.UBBKODU.CalcValue = UBB;
                this.SUTKODU.CalcValue = this.MATCHEDSUTCODE.CalcValue;
                this.SUTFIYAT.CalcValue = this.MATCHEDSUTPRICE.CalcValue;
            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class KDVGroup : TTReportGroup
        {
            public MaterialInspectionAndReceivingReport MyParentReport
            {
                get { return (MaterialInspectionAndReceivingReport)ParentReport; }
            }

            new public KDVGroupBody Body()
            {
                return (KDVGroupBody)_body;
            }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public TTReportField NewField171 { get {return Body().NewField171;} }
            public TTReportField NewField181 { get {return Body().NewField181;} }
            public TTReportField NewField1171 { get {return Body().NewField1171;} }
            public TTReportField TOPLAM { get {return Body().TOPLAM;} }
            public TTReportField KDV8 { get {return Body().KDV8;} }
            public TTReportField KDV18 { get {return Body().KDV18;} }
            public TTReportField GENELTOPLAM { get {return Body().GENELTOPLAM;} }
            public TTReportField NewField18 { get {return Body().NewField18;} }
            public TTReportField NewField1181 { get {return Body().NewField1181;} }
            public TTReportField KDV0 { get {return Body().KDV0;} }
            public KDVGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public KDVGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new KDVGroupBody(this);
            }

            public partial class KDVGroupBody : TTReportSection
            {
                public MaterialInspectionAndReceivingReport MyParentReport
                {
                    get { return (MaterialInspectionAndReceivingReport)ParentReport; }
                }
                
                public TTReportField NewField17;
                public TTReportField NewField171;
                public TTReportField NewField181;
                public TTReportField NewField1171;
                public TTReportField TOPLAM;
                public TTReportField KDV8;
                public TTReportField KDV18;
                public TTReportField GENELTOPLAM;
                public TTReportField NewField18;
                public TTReportField NewField1181;
                public TTReportField KDV0; 
                public KDVGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 29;
                    RepeatCount = 0;
                    
                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 0, 187, 5, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Size = 8;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"TOPLAM";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 10, 187, 15, false);
                    NewField171.Name = "NewField171";
                    NewField171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField171.TextFont.Name = "Arial";
                    NewField171.TextFont.Size = 8;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"KDV %8";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 15, 187, 20, false);
                    NewField181.Name = "NewField181";
                    NewField181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField181.TextFont.Name = "Arial";
                    NewField181.TextFont.Size = 8;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @"KDV %18";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 20, 187, 28, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1171.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1171.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1171.TextFont.Name = "Arial";
                    NewField1171.TextFont.Size = 8;
                    NewField1171.TextFont.CharSet = 162;
                    NewField1171.Value = @"GENEL TOPLAM";

                    TOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 0, 203, 5, false);
                    TOPLAM.Name = "TOPLAM";
                    TOPLAM.DrawStyle = DrawStyleConstants.vbSolid;
                    TOPLAM.TextFormat = @"#,##0.#0";
                    TOPLAM.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOPLAM.TextFont.Name = "Arial";
                    TOPLAM.TextFont.Size = 8;
                    TOPLAM.TextFont.CharSet = 162;
                    TOPLAM.Value = @"";

                    KDV8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 10, 203, 15, false);
                    KDV8.Name = "KDV8";
                    KDV8.DrawStyle = DrawStyleConstants.vbSolid;
                    KDV8.TextFormat = @"#,##0.#0";
                    KDV8.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KDV8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KDV8.TextFont.Name = "Arial";
                    KDV8.TextFont.Size = 8;
                    KDV8.TextFont.CharSet = 162;
                    KDV8.Value = @"";

                    KDV18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 15, 203, 20, false);
                    KDV18.Name = "KDV18";
                    KDV18.DrawStyle = DrawStyleConstants.vbSolid;
                    KDV18.TextFormat = @"#,##0.#0";
                    KDV18.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KDV18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KDV18.TextFont.Name = "Arial";
                    KDV18.TextFont.Size = 8;
                    KDV18.TextFont.CharSet = 162;
                    KDV18.Value = @"";

                    GENELTOPLAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 20, 203, 28, false);
                    GENELTOPLAM.Name = "GENELTOPLAM";
                    GENELTOPLAM.DrawStyle = DrawStyleConstants.vbSolid;
                    GENELTOPLAM.TextFormat = @"#,##0.#0";
                    GENELTOPLAM.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GENELTOPLAM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GENELTOPLAM.MultiLine = EvetHayirEnum.ehEvet;
                    GENELTOPLAM.WordBreak = EvetHayirEnum.ehEvet;
                    GENELTOPLAM.TextFont.Name = "Arial";
                    GENELTOPLAM.TextFont.Size = 8;
                    GENELTOPLAM.TextFont.CharSet = 162;
                    GENELTOPLAM.Value = @"";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 1, 169, 28, false);
                    NewField18.Name = "NewField18";
                    NewField18.Value = @"";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 5, 187, 10, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1181.TextFont.Name = "Arial";
                    NewField1181.TextFont.Size = 8;
                    NewField1181.TextFont.CharSet = 162;
                    NewField1181.Value = @"KDV %0";

                    KDV0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 5, 203, 10, false);
                    KDV0.Name = "KDV0";
                    KDV0.DrawStyle = DrawStyleConstants.vbSolid;
                    KDV0.TextFormat = @"#,##0.#0";
                    KDV0.HorzAlign = HorizontalAlignmentEnum.haRight;
                    KDV0.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KDV0.TextFont.Name = "Arial";
                    KDV0.TextFont.Size = 8;
                    KDV0.TextFont.CharSet = 162;
                    KDV0.Value = @"0";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField17.CalcValue = NewField17.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField181.CalcValue = NewField181.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    TOPLAM.CalcValue = TOPLAM.Value;
                    KDV8.CalcValue = KDV8.Value;
                    KDV18.CalcValue = KDV18.Value;
                    GENELTOPLAM.CalcValue = GENELTOPLAM.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    KDV0.CalcValue = KDV0.Value;
                    return new TTReportObject[] { NewField17,NewField171,NewField181,NewField1171,TOPLAM,KDV8,KDV18,GENELTOPLAM,NewField18,NewField1181,KDV0};
                }

                public override void RunScript()
                {
#region KDV BODY_Script
                    this.KDV8.CalcValue = (((MaterialInspectionAndReceivingReport)ParentReport).kdv8).ToString();
            this.TOPLAM.CalcValue = (((MaterialInspectionAndReceivingReport)ParentReport).toplamTutar).ToString();
            this.KDV18.CalcValue = (((MaterialInspectionAndReceivingReport)ParentReport).kdv18).ToString();
            this.GENELTOPLAM.CalcValue = (Convert.ToDouble(this.KDV8.CalcValue) + Convert.ToDouble(this.KDV18.CalcValue) + Convert.ToDouble(this.TOPLAM.CalcValue)).ToString();
            
            ((MaterialInspectionAndReceivingReport)ParentReport).kdv8 = 0;
            ((MaterialInspectionAndReceivingReport)ParentReport).kdv18 = 0;
            ((MaterialInspectionAndReceivingReport)ParentReport).toplamTutar = 0;
#endregion KDV BODY_Script
                }
            }

        }

        public KDVGroup KDV;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public MaterialInspectionAndReceivingReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            KDV = new KDVGroup(PARTB,"KDV");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ObjectID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("FIRMOBJECTID", "", "", @"", false, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("FIRMOBJECTID"))
                _runtimeParameters.FIRMOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["FIRMOBJECTID"]);
            Name = "MATERIALINSPECTIONANDRECEIVINGREPORT";
            Caption = "Mal Muayene Kabul ve Kullanım Tutanağı";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
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