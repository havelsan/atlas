
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
    /// HEK Malzeme Raporu (Ek-6.1)
    /// </summary>
    public partial class HEKMalzemeRaporu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public HEKMalzemeRaporu MyParentReport
            {
                get { return (HEKMalzemeRaporu)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField31 { get {return Header().NewField31;} }
            public TTReportField MALZEMENINKULLANILDIGIBIRLIK { get {return Header().MALZEMENINKULLANILDIGIBIRLIK;} }
            public TTReportField RAPORUTANZIMEDEN { get {return Header().RAPORUTANZIMEDEN;} }
            public TTReportField RAPORTANZIMTARIHI { get {return Header().RAPORTANZIMTARIHI;} }
            public TTReportField RAPORNUMARASI { get {return Header().RAPORNUMARASI;} }
            public TTReportField REQUESTDATE { get {return Header().REQUESTDATE;} }
            public TTReportField NewField2_ { get {return Footer().NewField2_;} }
            public TTReportField NewField21_ { get {return Footer().NewField21_;} }
            public TTReportField NewField22_ { get {return Footer().NewField22_;} }
            public TTReportField NewField23_ { get {return Footer().NewField23_;} }
            public TTReportField TEKNISYEN { get {return Footer().TEKNISYEN;} }
            public TTReportField KALITEKONTROLKISMI { get {return Footer().KALITEKONTROLKISMI;} }
            public TTReportField ONAY { get {return Footer().ONAY;} }
            public TTReportField NewField21_1 { get {return Footer().NewField21_1;} }
            public TTReportField NewField21_11 { get {return Footer().NewField21_11;} }
            public TTReportField NewField21_111 { get {return Footer().NewField21_111;} }
            public TTReportField NewField21_1111 { get {return Footer().NewField21_1111;} }
            public TTReportField NewField21_1112 { get {return Footer().NewField21_1112;} }
            public TTReportField KAMIRI { get {return Footer().KAMIRI;} }
            public TTReportField TUYE1 { get {return Footer().TUYE1;} }
            public TTReportField TUYE2 { get {return Footer().TUYE2;} }
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
                list[0] = new TTReportNqlData<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>("GetMaintenanceOrderByObjectIDQuery", MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public HEKMalzemeRaporu MyParentReport
                {
                    get { return (HEKMalzemeRaporu)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField8;
                public TTReportField NewField9;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField21;
                public TTReportField NewField31;
                public TTReportField MALZEMENINKULLANILDIGIBIRLIK;
                public TTReportField RAPORUTANZIMEDEN;
                public TTReportField RAPORTANZIMTARIHI;
                public TTReportField RAPORNUMARASI;
                public TTReportField REQUESTDATE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 56;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 10, 55, 16, false);
                    NewField.Name = "NewField";
                    NewField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField.TextFont.Name = "Arial";
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.Underline = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"HİZMETE ÖZEL";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 20, 200, 26, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Size = 11;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"HEK MALZEME RAPORU";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 30, 93, 36, false);
                    NewField4.Name = "NewField4";
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Size = 11;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"MALZEMEYİ GÖNDEREN BİRLİK";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 30, 95, 36, false);
                    NewField5.Name = "NewField5";
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Size = 11;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @":";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 36, 93, 42, false);
                    NewField8.Name = "NewField8";
                    NewField8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8.TextFont.Name = "Arial";
                    NewField8.TextFont.Size = 11;
                    NewField8.TextFont.Bold = true;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @"RAPORU TANZİM EDEN";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 36, 95, 42, false);
                    NewField9.Name = "NewField9";
                    NewField9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9.TextFont.Name = "Arial";
                    NewField9.TextFont.Size = 11;
                    NewField9.TextFont.Bold = true;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @":";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 48, 93, 54, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"RAPOR TANZİM TARİHİ";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 48, 95, 54, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @":";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 42, 93, 48, false);
                    NewField21.Name = "NewField21";
                    NewField21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21.TextFont.Name = "Arial";
                    NewField21.TextFont.Size = 11;
                    NewField21.TextFont.Bold = true;
                    NewField21.TextFont.CharSet = 162;
                    NewField21.Value = @"RAPOR NUMARASI";

                    NewField31 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 42, 95, 48, false);
                    NewField31.Name = "NewField31";
                    NewField31.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField31.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField31.TextFont.Name = "Arial";
                    NewField31.TextFont.Size = 11;
                    NewField31.TextFont.Bold = true;
                    NewField31.TextFont.CharSet = 162;
                    NewField31.Value = @":";

                    MALZEMENINKULLANILDIGIBIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 30, 200, 36, false);
                    MALZEMENINKULLANILDIGIBIRLIK.Name = "MALZEMENINKULLANILDIGIBIRLIK";
                    MALZEMENINKULLANILDIGIBIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMENINKULLANILDIGIBIRLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MALZEMENINKULLANILDIGIBIRLIK.TextFont.Size = 9;
                    MALZEMENINKULLANILDIGIBIRLIK.TextFont.CharSet = 162;
                    MALZEMENINKULLANILDIGIBIRLIK.Value = @"{#OWNERMILITARYUNIT#}";

                    RAPORUTANZIMEDEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 36, 200, 42, false);
                    RAPORUTANZIMEDEN.Name = "RAPORUTANZIMEDEN";
                    RAPORUTANZIMEDEN.FieldType = ReportFieldTypeEnum.ftExpression;
                    RAPORUTANZIMEDEN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORUTANZIMEDEN.TextFont.Size = 9;
                    RAPORUTANZIMEDEN.TextFont.CharSet = 162;
                    RAPORUTANZIMEDEN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    RAPORTANZIMTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 48, 200, 54, false);
                    RAPORTANZIMTARIHI.Name = "RAPORTANZIMTARIHI";
                    RAPORTANZIMTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTANZIMTARIHI.TextFormat = @"dd/MM/yyyy";
                    RAPORTANZIMTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORTANZIMTARIHI.TextFont.Size = 9;
                    RAPORTANZIMTARIHI.TextFont.CharSet = 162;
                    RAPORTANZIMTARIHI.Value = @"{@printdate@}";

                    RAPORNUMARASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 42, 200, 48, false);
                    RAPORNUMARASI.Name = "RAPORNUMARASI";
                    RAPORNUMARASI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNUMARASI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORNUMARASI.TextFont.Size = 9;
                    RAPORNUMARASI.TextFont.CharSet = 162;
                    RAPORNUMARASI.Value = @"{#ORDERNO#}";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 25, 252, 30, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.Visible = EvetHayirEnum.ehHayir;
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"Short Date";
                    REQUESTDATE.Value = @"{#REQUESTDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    NewField.CalcValue = NewField.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField31.CalcValue = NewField31.Value;
                    MALZEMENINKULLANILDIGIBIRLIK.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Ownermilitaryunit) : "");
                    RAPORTANZIMTARIHI.CalcValue = DateTime.Now.ToShortDateString();
                    RAPORNUMARASI.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.OrderNO) : "");
                    REQUESTDATE.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.RequestDate) : "");
                    RAPORUTANZIMEDEN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { NewField,NewField3,NewField4,NewField5,NewField8,NewField9,NewField1,NewField11,NewField21,NewField31,MALZEMENINKULLANILDIGIBIRLIK,RAPORTANZIMTARIHI,RAPORNUMARASI,REQUESTDATE,RAPORUTANZIMEDEN};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public HEKMalzemeRaporu MyParentReport
                {
                    get { return (HEKMalzemeRaporu)ParentReport; }
                }
                
                public TTReportField NewField2_;
                public TTReportField NewField21_;
                public TTReportField NewField22_;
                public TTReportField NewField23_;
                public TTReportField TEKNISYEN;
                public TTReportField KALITEKONTROLKISMI;
                public TTReportField ONAY;
                public TTReportField NewField21_1;
                public TTReportField NewField21_11;
                public TTReportField NewField21_111;
                public TTReportField NewField21_1111;
                public TTReportField NewField21_1112;
                public TTReportField KAMIRI;
                public TTReportField TUYE1;
                public TTReportField TUYE2; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 104;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField2_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 96, 55, 103, false);
                    NewField2_.Name = "NewField2_";
                    NewField2_.TextFont.Name = "Arial";
                    NewField2_.TextFont.Bold = true;
                    NewField2_.TextFont.Underline = true;
                    NewField2_.TextFont.CharSet = 162;
                    NewField2_.Value = @"HİZMETE ÖZEL";

                    NewField21_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 6, 83, 12, false);
                    NewField21_.Name = "NewField21_";
                    NewField21_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21_.TextFont.Size = 11;
                    NewField21_.TextFont.Bold = true;
                    NewField21_.TextFont.Underline = true;
                    NewField21_.TextFont.CharSet = 162;
                    NewField21_.Value = @"BAKIM ONARIM KISMI";

                    NewField22_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 6, 186, 12, false);
                    NewField22_.Name = "NewField22_";
                    NewField22_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField22_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField22_.TextFont.Size = 11;
                    NewField22_.TextFont.Bold = true;
                    NewField22_.TextFont.Underline = true;
                    NewField22_.TextFont.CharSet = 162;
                    NewField22_.Value = @"MUA.KONT.VE KLT.YNT.BL.A.";

                    NewField23_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 60, 144, 66, false);
                    NewField23_.Name = "NewField23_";
                    NewField23_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField23_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField23_.TextFont.Name = "Arial";
                    NewField23_.TextFont.Size = 11;
                    NewField23_.TextFont.Bold = true;
                    NewField23_.TextFont.CharSet = 162;
                    NewField23_.Value = @"ONAY";

                    TEKNISYEN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 31, 43, 51, false);
                    TEKNISYEN.Name = "TEKNISYEN";
                    TEKNISYEN.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKNISYEN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKNISYEN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKNISYEN.MultiLine = EvetHayirEnum.ehEvet;
                    TEKNISYEN.WordBreak = EvetHayirEnum.ehEvet;
                    TEKNISYEN.TextFont.Name = "Arial";
                    TEKNISYEN.TextFont.Size = 11;
                    TEKNISYEN.TextFont.CharSet = 162;
                    TEKNISYEN.Value = @"";

                    KALITEKONTROLKISMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 31, 206, 50, false);
                    KALITEKONTROLKISMI.Name = "KALITEKONTROLKISMI";
                    KALITEKONTROLKISMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KALITEKONTROLKISMI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KALITEKONTROLKISMI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KALITEKONTROLKISMI.MultiLine = EvetHayirEnum.ehEvet;
                    KALITEKONTROLKISMI.WordBreak = EvetHayirEnum.ehEvet;
                    KALITEKONTROLKISMI.TextFont.Name = "Arial";
                    KALITEKONTROLKISMI.TextFont.Size = 11;
                    KALITEKONTROLKISMI.TextFont.CharSet = 162;
                    KALITEKONTROLKISMI.Value = @"";

                    ONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 76, 144, 93, false);
                    ONAY.Name = "ONAY";
                    ONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONAY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONAY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ONAY.MultiLine = EvetHayirEnum.ehEvet;
                    ONAY.WordBreak = EvetHayirEnum.ehEvet;
                    ONAY.TextFont.Name = "Arial";
                    ONAY.TextFont.Size = 11;
                    ONAY.TextFont.CharSet = 162;
                    ONAY.Value = @"";

                    NewField21_1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 16, 43, 22, false);
                    NewField21_1.Name = "NewField21_1";
                    NewField21_1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21_1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21_1.TextFont.Size = 11;
                    NewField21_1.TextFont.Bold = true;
                    NewField21_1.TextFont.CharSet = 162;
                    NewField21_1.Value = @"TEKNİSYEN";

                    NewField21_11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 16, 83, 22, false);
                    NewField21_11.Name = "NewField21_11";
                    NewField21_11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21_11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21_11.TextFont.Size = 11;
                    NewField21_11.TextFont.Bold = true;
                    NewField21_11.TextFont.CharSet = 162;
                    NewField21_11.Value = @"KISIM AMİRİ";

                    NewField21_111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 16, 132, 22, false);
                    NewField21_111.Name = "NewField21_111";
                    NewField21_111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21_111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21_111.TextFont.Size = 11;
                    NewField21_111.TextFont.Bold = true;
                    NewField21_111.TextFont.CharSet = 162;
                    NewField21_111.Value = @"KLT.KONT.ASTSB.";

                    NewField21_1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 16, 169, 22, false);
                    NewField21_1111.Name = "NewField21_1111";
                    NewField21_1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21_1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21_1111.TextFont.Size = 11;
                    NewField21_1111.TextFont.Bold = true;
                    NewField21_1111.TextFont.CharSet = 162;
                    NewField21_1111.Value = @"KLT.KONT.ASTSB.";

                    NewField21_1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 16, 206, 22, false);
                    NewField21_1112.Name = "NewField21_1112";
                    NewField21_1112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21_1112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21_1112.TextFont.Size = 11;
                    NewField21_1112.TextFont.Bold = true;
                    NewField21_1112.TextFont.CharSet = 162;
                    NewField21_1112.Value = @"BÖLÜM AMİRİ";

                    KAMIRI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 31, 83, 51, false);
                    KAMIRI.Name = "KAMIRI";
                    KAMIRI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KAMIRI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KAMIRI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KAMIRI.MultiLine = EvetHayirEnum.ehEvet;
                    KAMIRI.WordBreak = EvetHayirEnum.ehEvet;
                    KAMIRI.TextFont.Name = "Arial";
                    KAMIRI.TextFont.Size = 11;
                    KAMIRI.TextFont.CharSet = 162;
                    KAMIRI.Value = @"";

                    TUYE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 31, 132, 51, false);
                    TUYE1.Name = "TUYE1";
                    TUYE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TUYE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TUYE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TUYE1.MultiLine = EvetHayirEnum.ehEvet;
                    TUYE1.WordBreak = EvetHayirEnum.ehEvet;
                    TUYE1.TextFont.Name = "Arial";
                    TUYE1.TextFont.Size = 11;
                    TUYE1.TextFont.CharSet = 162;
                    TUYE1.Value = @"";

                    TUYE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 31, 169, 51, false);
                    TUYE2.Name = "TUYE2";
                    TUYE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TUYE2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TUYE2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TUYE2.MultiLine = EvetHayirEnum.ehEvet;
                    TUYE2.WordBreak = EvetHayirEnum.ehEvet;
                    TUYE2.TextFont.Name = "Arial";
                    TUYE2.TextFont.Size = 11;
                    TUYE2.TextFont.CharSet = 162;
                    TUYE2.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    NewField2_.CalcValue = NewField2_.Value;
                    NewField21_.CalcValue = NewField21_.Value;
                    NewField22_.CalcValue = NewField22_.Value;
                    NewField23_.CalcValue = NewField23_.Value;
                    TEKNISYEN.CalcValue = @"";
                    KALITEKONTROLKISMI.CalcValue = @"";
                    ONAY.CalcValue = @"";
                    NewField21_1.CalcValue = NewField21_1.Value;
                    NewField21_11.CalcValue = NewField21_11.Value;
                    NewField21_111.CalcValue = NewField21_111.Value;
                    NewField21_1111.CalcValue = NewField21_1111.Value;
                    NewField21_1112.CalcValue = NewField21_1112.Value;
                    KAMIRI.CalcValue = @"";
                    TUYE1.CalcValue = @"";
                    TUYE2.CalcValue = @"";
                    return new TTReportObject[] { NewField2_,NewField21_,NewField22_,NewField23_,TEKNISYEN,KALITEKONTROLKISMI,ONAY,NewField21_1,NewField21_11,NewField21_111,NewField21_1111,NewField21_1112,KAMIRI,TUYE1,TUYE2};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            string objectID = ((HEKMalzemeRaporu)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            MaintenanceOrder ms = (MaintenanceOrder)ctx.GetObject(new Guid(objectID), typeof(MaintenanceOrder));
            ResUser user;
            ResUser tuser;
            bool tecnicalMember = false;
            string bamir = string.Empty;
            string techMember1 = string.Empty;
            string techMember2 = string.Empty;
            string chefString = string.Empty;
            string approvalMember = string.Empty;
            string tuserstring = string.Empty;
            if(ms.GetState("DivisionSectionApproval", true) != null)
            {
                user = (ResUser)ms.GetState("DivisionSectionApproval", true).User.UserObject;
                bamir  += user.Name + "\r\n";
                if (user.MilitaryClass != null)
                    bamir += user.MilitaryClass.ShortName;
                if (user.Rank != null)
                    bamir += user.Rank.ShortName + "\r\n";
                bamir += "(" + user.EmploymentRecordID + ")";
                KAMIRI.CalcValue = bamir;
            }
            
            if(ms.ResponsibleUser != null)
            {
                tuser = ms.ResponsibleUser;
                tuserstring  += tuser.Name + "\r\n";
                if (tuser.MilitaryClass != null)
                    tuserstring += tuser.MilitaryClass.ShortName;
                if (tuser.Rank != null)
                    tuserstring += tuser.Rank.ShortName + "\r\n";
                tuserstring += "(" + tuser.EmploymentRecordID + ")";
                TEKNISYEN.CalcValue = tuserstring;
            }
            
            foreach (MaintenanceHEKCommisionMember member in ms.HEKCommisionMembers)
            {
                if (member.MemberDuty == CommisionMemberDutyEnum.Chief)
                {
                    chefString += member.ResUser.Name + "\r\n";
                    if (member.ResUser.MilitaryClass != null)
                        chefString += member.ResUser.MilitaryClass.ShortName;
                    if (member.ResUser.Rank != null)
                        chefString += member.ResUser.Rank.ShortName + "\r\n";
                    chefString += "(" + member.ResUser.EmploymentRecordID + ")";
                    KALITEKONTROLKISMI.CalcValue = chefString;
                }
                if (member.MemberDuty == CommisionMemberDutyEnum.TechnicalMember)
                {
                    if (tecnicalMember == false)
                    {
                        techMember1 += member.ResUser.Name + "\r\n";
                        if (member.ResUser.MilitaryClass != null)
                            techMember1 += member.ResUser.MilitaryClass.ShortName;
                        if (member.ResUser.Rank != null)
                            techMember1 += member.ResUser.Rank.ShortName + "\r\n";
                        techMember1 += "(" + member.ResUser.EmploymentRecordID + ")";
                        TUYE1.CalcValue = techMember1;
                        tecnicalMember = true;
                    }
                    else
                    {
                        techMember2 += member.ResUser.Name + "\r\n";
                        if (member.ResUser.MilitaryClass != null)
                            techMember2 += member.ResUser.MilitaryClass.ShortName;
                        if (member.ResUser.Rank != null)
                            techMember2 += member.ResUser.Rank.ShortName + "\r\n";
                        techMember2 += "(" + member.ResUser.EmploymentRecordID + ")";
                        TUYE2.CalcValue = techMember2;
                    }
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
                        approvalMember += member.ResUser.Rank.ShortName + "\r\n";
                    approvalMember += "(" + member.ResUser.EmploymentRecordID + ")\r\n";
                    if(member.ResUser.Work != string.Empty)
                    {
                        approvalMember += member.ResUser.Work;
                    }
                    ONAY.CalcValue = approvalMember;
                }
            }
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public HEKMalzemeRaporu MyParentReport
            {
                get { return (HEKMalzemeRaporu)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField114 { get {return Header().NewField114;} }
            public TTReportField NewField115 { get {return Header().NewField115;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField116 { get {return Header().NewField116;} }
            public TTReportField NewField117 { get {return Header().NewField117;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportField TOTALCOUNT { get {return Footer().TOTALCOUNT;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportField TOTALTEXT { get {return Footer().TOTALTEXT;} }
            public TTReportField AMOUNTTEXT { get {return Footer().AMOUNTTEXT;} }
            public TTReportRTF HEKRTF { get {return Footer().HEKRTF;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataSet_GetMaintenanceOrderByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);    
                return new object[] {(dataSet_GetMaintenanceOrderByObjectIDQuery==null ? null : dataSet_GetMaintenanceOrderByObjectIDQuery.ObjectID)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public HEKMalzemeRaporu MyParentReport
                {
                    get { return (HEKMalzemeRaporu)ParentReport; }
                }
                
                public TTReportField NewField121;
                public TTReportField NewField114;
                public TTReportField NewField115;
                public TTReportField NewField151;
                public TTReportField NewField116;
                public TTReportField NewField117;
                public TTReportField NewField171; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 16;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 5, 29, 15, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 11;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Sıra Nu.";

                    NewField114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 5, 51, 15, false);
                    NewField114.Name = "NewField114";
                    NewField114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField114.MultiLine = EvetHayirEnum.ehEvet;
                    NewField114.WordBreak = EvetHayirEnum.ehEvet;
                    NewField114.TextFont.Name = "Arial";
                    NewField114.TextFont.Size = 11;
                    NewField114.TextFont.Bold = true;
                    NewField114.TextFont.CharSet = 162;
                    NewField114.Value = @"Sipariş
Nu.";

                    NewField115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 5, 81, 15, false);
                    NewField115.Name = "NewField115";
                    NewField115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField115.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField115.TextFont.Name = "Arial";
                    NewField115.TextFont.Size = 11;
                    NewField115.TextFont.Bold = true;
                    NewField115.TextFont.CharSet = 162;
                    NewField115.Value = @"Stok Nu.";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 5, 127, 15, false);
                    NewField151.Name = "NewField151";
                    NewField151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.Size = 11;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"Malzemenin Cinsi";

                    NewField116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 5, 167, 15, false);
                    NewField116.Name = "NewField116";
                    NewField116.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField116.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField116.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField116.MultiLine = EvetHayirEnum.ehEvet;
                    NewField116.WordBreak = EvetHayirEnum.ehEvet;
                    NewField116.TextFont.Name = "Arial";
                    NewField116.TextFont.Size = 11;
                    NewField116.TextFont.Bold = true;
                    NewField116.TextFont.CharSet = 162;
                    NewField116.Value = @"Marka-Model
Seri Nu";

                    NewField117 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 5, 186, 15, false);
                    NewField117.Name = "NewField117";
                    NewField117.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117.TextFont.Name = "Arial";
                    NewField117.TextFont.Size = 11;
                    NewField117.TextFont.Bold = true;
                    NewField117.TextFont.CharSet = 162;
                    NewField117.Value = @"İmal 
Yılı";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 5, 200, 15, false);
                    NewField171.Name = "NewField171";
                    NewField171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField171.TextFont.Name = "Arial";
                    NewField171.TextFont.Size = 11;
                    NewField171.TextFont.Bold = true;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"Miktar";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    NewField121.CalcValue = NewField121.Value;
                    NewField114.CalcValue = NewField114.Value;
                    NewField115.CalcValue = NewField115.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField116.CalcValue = NewField116.Value;
                    NewField117.CalcValue = NewField117.Value;
                    NewField171.CalcValue = NewField171.Value;
                    return new TTReportObject[] { NewField121,NewField114,NewField115,NewField151,NewField116,NewField117,NewField171};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public HEKMalzemeRaporu MyParentReport
                {
                    get { return (HEKMalzemeRaporu)ParentReport; }
                }
                
                public TTReportShape NewLine1;
                public TTReportField TOTALCOUNT;
                public TTReportShape NewLine12;
                public TTReportField TOTALTEXT;
                public TTReportField AMOUNTTEXT;
                public TTReportRTF HEKRTF; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 44;
                    RepeatCount = 0;
                    
                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 5, 60, 5, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    TOTALCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 1, 159, 6, false);
                    TOTALCOUNT.Name = "TOTALCOUNT";
                    TOTALCOUNT.FieldType = ReportFieldTypeEnum.ftExpression;
                    TOTALCOUNT.CaseFormat = CaseFormatEnum.fcUpperCase;
                    TOTALCOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALCOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALCOUNT.TextFont.Name = "Arial";
                    TOTALCOUNT.TextFont.Size = 11;
                    TOTALCOUNT.TextFont.CharSet = 162;
                    TOTALCOUNT.Value = @"""Yalnız "" + TOTALTEXT.FormattedValue + "" Kalem "" + AMOUNTTEXT.FormattedValue + "" Adettir.""";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 160, 5, 200, 5, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    TOTALTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 2, 243, 7, false);
                    TOTALTEXT.Name = "TOTALTEXT";
                    TOTALTEXT.Visible = EvetHayirEnum.ehHayir;
                    TOTALTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALTEXT.TextFormat = @"NUMBERTEXT";
                    TOTALTEXT.Value = @"{@subgroupcount@}";

                    AMOUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 2, 271, 7, false);
                    AMOUNTTEXT.Name = "AMOUNTTEXT";
                    AMOUNTTEXT.Visible = EvetHayirEnum.ehHayir;
                    AMOUNTTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNTTEXT.TextFormat = @"NUMBERTEXT";
                    AMOUNTTEXT.Value = @"{#PARTA.AMOUNT#}";

                    HEKRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 20, 7, 200, 43, false);
                    HEKRTF.Name = "HEKRTF";
                    HEKRTF.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    TOTALTEXT.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    AMOUNTTEXT.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Amount) : "");
                    HEKRTF.CalcValue = HEKRTF.Value;
                    TOTALCOUNT.CalcValue = "Yalnız " + TOTALTEXT.FormattedValue + " Kalem " + AMOUNTTEXT.FormattedValue + " Adettir.";
                    return new TTReportObject[] { TOTALTEXT,AMOUNTTEXT,HEKRTF,TOTALCOUNT};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            string objectID = ((HEKMalzemeRaporu)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            MaintenanceOrder maintenanceOrder = (MaintenanceOrder)ctx.GetObject(new Guid(objectID), typeof(MaintenanceOrder));
            if(maintenanceOrder.HEKDescription != null)
                HEKRTF.CalcValue = maintenanceOrder.HEKDescription;
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public HEKMalzemeRaporu MyParentReport
            {
                get { return (HEKMalzemeRaporu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField SIPARISNO { get {return Body().SIPARISNO;} }
            public TTReportField STOKNO { get {return Body().STOKNO;} }
            public TTReportField MALZEMECINSI { get {return Body().MALZEMECINSI;} }
            public TTReportField MARKAMODELSERINO { get {return Body().MARKAMODELSERINO;} }
            public TTReportField IMALYILI { get {return Body().IMALYILI;} }
            public TTReportField MIKTAR { get {return Body().MIKTAR;} }
            public TTReportField MARK { get {return Body().MARK;} }
            public TTReportField MODEL { get {return Body().MODEL;} }
            public TTReportField SERIALNO { get {return Body().SERIALNO;} }
            public TTReportField ITEMDETAIL { get {return Body().ITEMDETAIL;} }
            public TTReportField ITEMDETAIL1 { get {return Body().ITEMDETAIL1;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataSet_GetMaintenanceOrderByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);    
                return new object[] {(dataSet_GetMaintenanceOrderByObjectIDQuery==null ? null : dataSet_GetMaintenanceOrderByObjectIDQuery.ObjectID)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public HEKMalzemeRaporu MyParentReport
                {
                    get { return (HEKMalzemeRaporu)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField SIPARISNO;
                public TTReportField STOKNO;
                public TTReportField MALZEMECINSI;
                public TTReportField MARKAMODELSERINO;
                public TTReportField IMALYILI;
                public TTReportField MIKTAR;
                public TTReportField MARK;
                public TTReportField MODEL;
                public TTReportField SERIALNO;
                public TTReportField ITEMDETAIL;
                public TTReportField ITEMDETAIL1;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine2; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 46;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 29, 17, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.DrawStyle = DrawStyleConstants.vbSolid;
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIRANO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIRANO.MultiLine = EvetHayirEnum.ehEvet;
                    SIRANO.WordBreak = EvetHayirEnum.ehEvet;
                    SIRANO.TextFont.Name = "Arial";
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@counter@}";

                    SIPARISNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 0, 51, 17, false);
                    SIPARISNO.Name = "SIPARISNO";
                    SIPARISNO.DrawStyle = DrawStyleConstants.vbSolid;
                    SIPARISNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIPARISNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIPARISNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIPARISNO.MultiLine = EvetHayirEnum.ehEvet;
                    SIPARISNO.WordBreak = EvetHayirEnum.ehEvet;
                    SIPARISNO.TextFont.Name = "Arial";
                    SIPARISNO.TextFont.CharSet = 162;
                    SIPARISNO.Value = @"{#PARTA.REQUESTNO#}
{#PARTA.ORDERNO#}
";

                    STOKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 0, 81, 17, false);
                    STOKNO.Name = "STOKNO";
                    STOKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    STOKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STOKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOKNO.MultiLine = EvetHayirEnum.ehEvet;
                    STOKNO.WordBreak = EvetHayirEnum.ehEvet;
                    STOKNO.TextFont.Name = "Arial";
                    STOKNO.TextFont.CharSet = 162;
                    STOKNO.Value = @"{#PARTA.NATOSTOCKNO#}";

                    MALZEMECINSI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 0, 127, 17, false);
                    MALZEMECINSI.Name = "MALZEMECINSI";
                    MALZEMECINSI.DrawStyle = DrawStyleConstants.vbSolid;
                    MALZEMECINSI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMECINSI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MALZEMECINSI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MALZEMECINSI.MultiLine = EvetHayirEnum.ehEvet;
                    MALZEMECINSI.WordBreak = EvetHayirEnum.ehEvet;
                    MALZEMECINSI.TextFont.Name = "Arial";
                    MALZEMECINSI.TextFont.CharSet = 162;
                    MALZEMECINSI.Value = @"{#PARTA.FIXEDASSETNAME#}";

                    MARKAMODELSERINO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 0, 167, 17, false);
                    MARKAMODELSERINO.Name = "MARKAMODELSERINO";
                    MARKAMODELSERINO.DrawStyle = DrawStyleConstants.vbSolid;
                    MARKAMODELSERINO.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARKAMODELSERINO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MARKAMODELSERINO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARKAMODELSERINO.MultiLine = EvetHayirEnum.ehEvet;
                    MARKAMODELSERINO.WordBreak = EvetHayirEnum.ehEvet;
                    MARKAMODELSERINO.TextFont.Name = "Arial";
                    MARKAMODELSERINO.TextFont.CharSet = 162;
                    MARKAMODELSERINO.Value = @"";

                    IMALYILI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 0, 186, 17, false);
                    IMALYILI.Name = "IMALYILI";
                    IMALYILI.DrawStyle = DrawStyleConstants.vbSolid;
                    IMALYILI.FieldType = ReportFieldTypeEnum.ftVariable;
                    IMALYILI.TextFormat = @"dd/MM/yyyy";
                    IMALYILI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IMALYILI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IMALYILI.MultiLine = EvetHayirEnum.ehEvet;
                    IMALYILI.WordBreak = EvetHayirEnum.ehEvet;
                    IMALYILI.TextFont.Name = "Arial";
                    IMALYILI.TextFont.CharSet = 162;
                    IMALYILI.Value = @"{#PARTA.PRODUCTIONDATE#}";

                    MIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 0, 200, 17, false);
                    MIKTAR.Name = "MIKTAR";
                    MIKTAR.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MIKTAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTAR.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTAR.MultiLine = EvetHayirEnum.ehEvet;
                    MIKTAR.WordBreak = EvetHayirEnum.ehEvet;
                    MIKTAR.TextFont.Name = "Arial";
                    MIKTAR.TextFont.CharSet = 162;
                    MIKTAR.Value = @"{#PARTA.AMOUNT#}";

                    MARK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 4, 228, 9, false);
                    MARK.Name = "MARK";
                    MARK.Visible = EvetHayirEnum.ehHayir;
                    MARK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARK.Value = @"{#PARTA.MARK#}";

                    MODEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 4, 240, 9, false);
                    MODEL.Name = "MODEL";
                    MODEL.Visible = EvetHayirEnum.ehHayir;
                    MODEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MODEL.Value = @"{#PARTA.MODEL#}";

                    SERIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 4, 256, 9, false);
                    SERIALNO.Name = "SERIALNO";
                    SERIALNO.Visible = EvetHayirEnum.ehHayir;
                    SERIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNO.Value = @"{#PARTA.SERIALNUMBER#}";

                    ITEMDETAIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 25, 200, 45, false);
                    ITEMDETAIL.Name = "ITEMDETAIL";
                    ITEMDETAIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMDETAIL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ITEMDETAIL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ITEMDETAIL.MultiLine = EvetHayirEnum.ehEvet;
                    ITEMDETAIL.WordBreak = EvetHayirEnum.ehEvet;
                    ITEMDETAIL.TextFont.Name = "Arial";
                    ITEMDETAIL.TextFont.CharSet = 162;
                    ITEMDETAIL.Value = @"";

                    ITEMDETAIL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 18, 200, 24, false);
                    ITEMDETAIL1.Name = "ITEMDETAIL1";
                    ITEMDETAIL1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ITEMDETAIL1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ITEMDETAIL1.MultiLine = EvetHayirEnum.ehEvet;
                    ITEMDETAIL1.WordBreak = EvetHayirEnum.ehEvet;
                    ITEMDETAIL1.TextFont.Size = 12;
                    ITEMDETAIL1.TextFont.Bold = true;
                    ITEMDETAIL1.TextFont.CharSet = 162;
                    ITEMDETAIL1.Value = @"MUHTEVİYAT
";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 17, 200, 45, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 17, 20, 45, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 45, 200, 45, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    SIRANO.CalcValue = ParentGroup.Counter.ToString();
                    SIPARISNO.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.RequestNo) : "") + @"
" + (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.OrderNO) : "") + @"
";
                    STOKNO.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.NATOStockNO) : "");
                    MALZEMECINSI.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Fixedassetname) : "");
                    MARKAMODELSERINO.CalcValue = @"";
                    IMALYILI.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.ProductionDate) : "");
                    MIKTAR.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Amount) : "");
                    MARK.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Mark) : "");
                    MODEL.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Model) : "");
                    SERIALNO.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.SerialNumber) : "");
                    ITEMDETAIL.CalcValue = @"";
                    ITEMDETAIL1.CalcValue = ITEMDETAIL1.Value;
                    return new TTReportObject[] { SIRANO,SIPARISNO,STOKNO,MALZEMECINSI,MARKAMODELSERINO,IMALYILI,MIKTAR,MARK,MODEL,SERIALNO,ITEMDETAIL,ITEMDETAIL1};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(MARK.CalcValue == "")
                MARK.CalcValue = "---";
            
            if(MODEL.CalcValue == "")
                MODEL.CalcValue = "---";
            
            if(SERIALNO.CalcValue == "")
                SERIALNO.CalcValue = "---";
            
            MARKAMODELSERINO.CalcValue = MARK.CalcValue + " / " + MODEL.CalcValue + " / " + SERIALNO.CalcValue;
            
            TTObjectContext ctx = new TTObjectContext(true);
            string objectID = ((HEKMalzemeRaporu)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            MaintenanceOrder maintenanceOrder = (MaintenanceOrder)ctx.GetObject(new Guid(objectID), typeof(MaintenanceOrder));
            if(maintenanceOrder.ItemDetail != null)
                ITEMDETAIL.CalcValue = maintenanceOrder.ItemDetail;
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTCGroup : TTReportGroup
        {
            public HEKMalzemeRaporu MyParentReport
            {
                get { return (HEKMalzemeRaporu)ParentReport; }
            }

            new public PARTCGroupBody Body()
            {
                return (PARTCGroupBody)_body;
            }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataSet_GetMaintenanceOrderByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);    
                return new object[] {(dataSet_GetMaintenanceOrderByObjectIDQuery==null ? null : dataSet_GetMaintenanceOrderByObjectIDQuery.ObjectID)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTCGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class PARTCGroupBody : TTReportSection
            {
                public HEKMalzemeRaporu MyParentReport
                {
                    get { return (HEKMalzemeRaporu)ParentReport; }
                }
                 
                public PARTCGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTCGroup PARTC;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HEKMalzemeRaporu()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            PARTC = new PARTCGroup(PARTA,"PARTC");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HEKMALZEMERAPORU";
            Caption = "HEK Malzeme Raporu (Ek-6.1)";
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