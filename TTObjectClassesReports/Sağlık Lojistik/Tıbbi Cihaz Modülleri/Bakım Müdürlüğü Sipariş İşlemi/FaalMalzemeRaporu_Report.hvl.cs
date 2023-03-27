
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
    /// Faal Malzeme Raporu (Ek-8.9)
    /// </summary>
    public partial class FaalMalzemeRaporu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string REPORTNO = (string)TTObjectDefManager.Instance.DataTypes["String_15"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public FaalMalzemeRaporu MyParentReport
            {
                get { return (FaalMalzemeRaporu)ParentReport; }
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
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField TANZIMEDENBIRLIK { get {return Header().TANZIMEDENBIRLIK;} }
            public TTReportField TANZIMEDILENBIRLIK { get {return Header().TANZIMEDILENBIRLIK;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField TANZIMTARIHI { get {return Header().TANZIMTARIHI;} }
            public TTReportField NewField2_ { get {return Footer().NewField2_;} }
            public TTReportField NewField21_ { get {return Footer().NewField21_;} }
            public TTReportField NewField23_ { get {return Footer().NewField23_;} }
            public TTReportField MUKONT_SIGN { get {return Footer().MUKONT_SIGN;} }
            public TTReportField NewField21_1 { get {return Footer().NewField21_1;} }
            public TTReportField NewField21_2 { get {return Footer().NewField21_2;} }
            public TTReportField NewField21_12 { get {return Footer().NewField21_12;} }
            public TTReportField NewField21_121 { get {return Footer().NewField21_121;} }
            public TTReportField ONAY_SIGN { get {return Footer().ONAY_SIGN;} }
            public TTReportField TEKNISYEN_SIGN { get {return Footer().TEKNISYEN_SIGN;} }
            public TTReportField YRDATL_SIGN { get {return Footer().YRDATL_SIGN;} }
            public TTReportField NewField21_13 { get {return Footer().NewField21_13;} }
            public TTReportField NewField21_14 { get {return Footer().NewField21_14;} }
            public TTReportField TEKNISYEN_SIGN1 { get {return Footer().TEKNISYEN_SIGN1;} }
            public TTReportField TEKNISYEN_SIGN2 { get {return Footer().TEKNISYEN_SIGN2;} }
            public TTReportField NewField21_122 { get {return Footer().NewField21_122;} }
            public TTReportField YRDATL_SIGN1 { get {return Footer().YRDATL_SIGN1;} }
            public TTReportField NewField23_1 { get {return Footer().NewField23_1;} }
            public TTReportField ONAY_SIGN1 { get {return Footer().ONAY_SIGN1;} }
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
                public FaalMalzemeRaporu MyParentReport
                {
                    get { return (FaalMalzemeRaporu)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField9;
                public TTReportField NewField10;
                public TTReportField NewField11;
                public TTReportField TANZIMEDENBIRLIK;
                public TTReportField TANZIMEDILENBIRLIK;
                public TTReportField RAPORNO;
                public TTReportField TANZIMTARIHI; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 62;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 9, 45, 14, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.TextFont.Name = "Arial";
                    NewField.TextFont.Size = 11;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"HİZMETE ÖZEL";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 22, 194, 28, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Size = 12;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"FAAL MALZEME RAPORU";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 31, 78, 37, false);
                    NewField4.Name = "NewField4";
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Size = 11;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"RAPOR TANZİM EDEN BİRLİK";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 31, 81, 37, false);
                    NewField5.Name = "NewField5";
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Size = 11;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @":";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 44, 78, 50, false);
                    NewField6.Name = "NewField6";
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Size = 11;
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"RAPOR TANZİM EDİLEN BİRLİK";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 44, 81, 50, false);
                    NewField7.Name = "NewField7";
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Size = 11;
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @":";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 50, 78, 56, false);
                    NewField8.Name = "NewField8";
                    NewField8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8.TextFont.Name = "Arial";
                    NewField8.TextFont.Size = 11;
                    NewField8.TextFont.Bold = true;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @"RAPOR NUMARASI";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 50, 81, 56, false);
                    NewField9.Name = "NewField9";
                    NewField9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9.TextFont.Name = "Arial";
                    NewField9.TextFont.Size = 11;
                    NewField9.TextFont.Bold = true;
                    NewField9.TextFont.CharSet = 162;
                    NewField9.Value = @":";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 56, 78, 62, false);
                    NewField10.Name = "NewField10";
                    NewField10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField10.TextFont.Name = "Arial";
                    NewField10.TextFont.Size = 11;
                    NewField10.TextFont.Bold = true;
                    NewField10.TextFont.CharSet = 162;
                    NewField10.Value = @"RAPOR TANZİM TARIHI";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 56, 81, 62, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @":";

                    TANZIMEDENBIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 31, 202, 44, false);
                    TANZIMEDENBIRLIK.Name = "TANZIMEDENBIRLIK";
                    TANZIMEDENBIRLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    TANZIMEDENBIRLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TANZIMEDENBIRLIK.MultiLine = EvetHayirEnum.ehEvet;
                    TANZIMEDENBIRLIK.WordBreak = EvetHayirEnum.ehEvet;
                    TANZIMEDENBIRLIK.TextFont.Name = "Arial";
                    TANZIMEDENBIRLIK.TextFont.Size = 11;
                    TANZIMEDENBIRLIK.TextFont.CharSet = 162;
                    TANZIMEDENBIRLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    TANZIMEDILENBIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 44, 202, 50, false);
                    TANZIMEDILENBIRLIK.Name = "TANZIMEDILENBIRLIK";
                    TANZIMEDILENBIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANZIMEDILENBIRLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TANZIMEDILENBIRLIK.TextFont.Name = "Arial";
                    TANZIMEDILENBIRLIK.TextFont.Size = 11;
                    TANZIMEDILENBIRLIK.TextFont.CharSet = 162;
                    TANZIMEDILENBIRLIK.Value = @"{#ACCOUNTANCYMILITARYUNIT#}";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 50, 202, 56, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORNO.TextFont.Name = "Arial";
                    RAPORNO.TextFont.Size = 11;
                    RAPORNO.TextFont.CharSet = 162;
                    RAPORNO.Value = @"{#REPORTNO#}";

                    TANZIMTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 56, 202, 62, false);
                    TANZIMTARIHI.Name = "TANZIMTARIHI";
                    TANZIMTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANZIMTARIHI.TextFormat = @"dd/MM/yyyy";
                    TANZIMTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TANZIMTARIHI.TextFont.Name = "Arial";
                    TANZIMTARIHI.TextFont.Size = 11;
                    TANZIMTARIHI.TextFont.CharSet = 162;
                    TANZIMTARIHI.Value = @"{@printdate@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    NewField.CalcValue = NewField.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField10.CalcValue = NewField10.Value;
                    NewField11.CalcValue = NewField11.Value;
                    TANZIMEDILENBIRLIK.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Accountancymilitaryunit) : "");
                    RAPORNO.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.ReportNo) : "");
                    TANZIMTARIHI.CalcValue = DateTime.Now.ToShortDateString();
                    TANZIMEDENBIRLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { NewField,NewField3,NewField4,NewField5,NewField6,NewField7,NewField8,NewField9,NewField10,NewField11,TANZIMEDILENBIRLIK,RAPORNO,TANZIMTARIHI,TANZIMEDENBIRLIK};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public FaalMalzemeRaporu MyParentReport
                {
                    get { return (FaalMalzemeRaporu)ParentReport; }
                }
                
                public TTReportField NewField2_;
                public TTReportField NewField21_;
                public TTReportField NewField23_;
                public TTReportField MUKONT_SIGN;
                public TTReportField NewField21_1;
                public TTReportField NewField21_2;
                public TTReportField NewField21_12;
                public TTReportField NewField21_121;
                public TTReportField ONAY_SIGN;
                public TTReportField TEKNISYEN_SIGN;
                public TTReportField YRDATL_SIGN;
                public TTReportField NewField21_13;
                public TTReportField NewField21_14;
                public TTReportField TEKNISYEN_SIGN1;
                public TTReportField TEKNISYEN_SIGN2;
                public TTReportField NewField21_122;
                public TTReportField YRDATL_SIGN1;
                public TTReportField NewField23_1;
                public TTReportField ONAY_SIGN1; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 123;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField2_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 116, 38, 122, false);
                    NewField2_.Name = "NewField2_";
                    NewField2_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2_.TextFont.Name = "Arial";
                    NewField2_.TextFont.Size = 11;
                    NewField2_.TextFont.Bold = true;
                    NewField2_.TextFont.Underline = true;
                    NewField2_.TextFont.CharSet = 162;
                    NewField2_.Value = @"HİZMETE ÖZEL";

                    NewField21_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 1, 100, 7, false);
                    NewField21_.Name = "NewField21_";
                    NewField21_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21_.TextFont.Name = "Arial";
                    NewField21_.TextFont.Size = 11;
                    NewField21_.TextFont.Bold = true;
                    NewField21_.TextFont.Underline = true;
                    NewField21_.TextFont.CharSet = 162;
                    NewField21_.Value = @"BAKIM ONARIM KISMI";

                    NewField23_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 97, 112, 103, false);
                    NewField23_.Name = "NewField23_";
                    NewField23_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField23_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField23_.TextFont.Name = "Arial";
                    NewField23_.TextFont.Size = 11;
                    NewField23_.TextFont.Bold = true;
                    NewField23_.TextFont.Italic = true;
                    NewField23_.TextFont.CharSet = 162;
                    NewField23_.Value = @"ONAY";

                    MUKONT_SIGN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 14, 191, 34, false);
                    MUKONT_SIGN.Name = "MUKONT_SIGN";
                    MUKONT_SIGN.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUKONT_SIGN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MUKONT_SIGN.MultiLine = EvetHayirEnum.ehEvet;
                    MUKONT_SIGN.WordBreak = EvetHayirEnum.ehEvet;
                    MUKONT_SIGN.TextFont.Name = "Arial";
                    MUKONT_SIGN.TextFont.Size = 11;
                    MUKONT_SIGN.TextFont.CharSet = 162;
                    MUKONT_SIGN.Value = @"";

                    NewField21_1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 1, 194, 7, false);
                    NewField21_1.Name = "NewField21_1";
                    NewField21_1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21_1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21_1.TextFont.Name = "Arial";
                    NewField21_1.TextFont.Size = 11;
                    NewField21_1.TextFont.Bold = true;
                    NewField21_1.TextFont.Underline = true;
                    NewField21_1.TextFont.CharSet = 162;
                    NewField21_1.Value = @"MUA.KONT. VE KLT.YNT.BL.A.";

                    NewField21_2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 7, 53, 13, false);
                    NewField21_2.Name = "NewField21_2";
                    NewField21_2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21_2.TextFont.Name = "Arial";
                    NewField21_2.TextFont.Size = 11;
                    NewField21_2.TextFont.Bold = true;
                    NewField21_2.TextFont.CharSet = 162;
                    NewField21_2.Value = @"TEKNİSYEN";

                    NewField21_12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 7, 106, 13, false);
                    NewField21_12.Name = "NewField21_12";
                    NewField21_12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21_12.TextFont.Name = "Arial";
                    NewField21_12.TextFont.Size = 11;
                    NewField21_12.TextFont.Bold = true;
                    NewField21_12.TextFont.CharSet = 162;
                    NewField21_12.Value = @"KISIM AMİRİ";

                    NewField21_121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 8, 176, 14, false);
                    NewField21_121.Name = "NewField21_121";
                    NewField21_121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21_121.TextFont.Name = "Arial";
                    NewField21_121.TextFont.Size = 11;
                    NewField21_121.TextFont.Bold = true;
                    NewField21_121.TextFont.CharSet = 162;
                    NewField21_121.Value = @"KLT.KONT.ASTSB.";

                    ONAY_SIGN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 103, 107, 123, false);
                    ONAY_SIGN.Name = "ONAY_SIGN";
                    ONAY_SIGN.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONAY_SIGN.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONAY_SIGN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ONAY_SIGN.MultiLine = EvetHayirEnum.ehEvet;
                    ONAY_SIGN.WordBreak = EvetHayirEnum.ehEvet;
                    ONAY_SIGN.ObjectDefName = "ResUser";
                    ONAY_SIGN.DataMember = "NAME";
                    ONAY_SIGN.TextFont.Name = "Arial";
                    ONAY_SIGN.TextFont.Size = 11;
                    ONAY_SIGN.TextFont.CharSet = 162;
                    ONAY_SIGN.Value = @"";

                    TEKNISYEN_SIGN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 13, 62, 33, false);
                    TEKNISYEN_SIGN.Name = "TEKNISYEN_SIGN";
                    TEKNISYEN_SIGN.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKNISYEN_SIGN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKNISYEN_SIGN.MultiLine = EvetHayirEnum.ehEvet;
                    TEKNISYEN_SIGN.WordBreak = EvetHayirEnum.ehEvet;
                    TEKNISYEN_SIGN.ObjectDefName = "ResUser";
                    TEKNISYEN_SIGN.DataMember = "NAME";
                    TEKNISYEN_SIGN.TextFont.Name = "Arial";
                    TEKNISYEN_SIGN.TextFont.Size = 11;
                    TEKNISYEN_SIGN.TextFont.CharSet = 162;
                    TEKNISYEN_SIGN.Value = @"";

                    YRDATL_SIGN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 13, 111, 33, false);
                    YRDATL_SIGN.Name = "YRDATL_SIGN";
                    YRDATL_SIGN.FieldType = ReportFieldTypeEnum.ftVariable;
                    YRDATL_SIGN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YRDATL_SIGN.MultiLine = EvetHayirEnum.ehEvet;
                    YRDATL_SIGN.WordBreak = EvetHayirEnum.ehEvet;
                    YRDATL_SIGN.TextFont.Name = "Arial";
                    YRDATL_SIGN.TextFont.Size = 11;
                    YRDATL_SIGN.TextFont.CharSet = 162;
                    YRDATL_SIGN.Value = @"";

                    NewField21_13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 36, 53, 42, false);
                    NewField21_13.Name = "NewField21_13";
                    NewField21_13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21_13.TextFont.Name = "Arial";
                    NewField21_13.TextFont.Size = 11;
                    NewField21_13.TextFont.Bold = true;
                    NewField21_13.TextFont.CharSet = 162;
                    NewField21_13.Value = @"TEKNİSYEN";

                    NewField21_14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 65, 53, 71, false);
                    NewField21_14.Name = "NewField21_14";
                    NewField21_14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21_14.TextFont.Name = "Arial";
                    NewField21_14.TextFont.Size = 11;
                    NewField21_14.TextFont.Bold = true;
                    NewField21_14.TextFont.CharSet = 162;
                    NewField21_14.Value = @"TEKNİSYEN";

                    TEKNISYEN_SIGN1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 42, 62, 62, false);
                    TEKNISYEN_SIGN1.Name = "TEKNISYEN_SIGN1";
                    TEKNISYEN_SIGN1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKNISYEN_SIGN1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKNISYEN_SIGN1.MultiLine = EvetHayirEnum.ehEvet;
                    TEKNISYEN_SIGN1.WordBreak = EvetHayirEnum.ehEvet;
                    TEKNISYEN_SIGN1.ObjectDefName = "ResUser";
                    TEKNISYEN_SIGN1.DataMember = "NAME";
                    TEKNISYEN_SIGN1.TextFont.Name = "Arial";
                    TEKNISYEN_SIGN1.TextFont.Size = 11;
                    TEKNISYEN_SIGN1.TextFont.CharSet = 162;
                    TEKNISYEN_SIGN1.Value = @"";

                    TEKNISYEN_SIGN2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 70, 62, 90, false);
                    TEKNISYEN_SIGN2.Name = "TEKNISYEN_SIGN2";
                    TEKNISYEN_SIGN2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKNISYEN_SIGN2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEKNISYEN_SIGN2.MultiLine = EvetHayirEnum.ehEvet;
                    TEKNISYEN_SIGN2.WordBreak = EvetHayirEnum.ehEvet;
                    TEKNISYEN_SIGN2.ObjectDefName = "ResUser";
                    TEKNISYEN_SIGN2.DataMember = "NAME";
                    TEKNISYEN_SIGN2.TextFont.Name = "Arial";
                    TEKNISYEN_SIGN2.TextFont.Size = 11;
                    TEKNISYEN_SIGN2.TextFont.CharSet = 162;
                    TEKNISYEN_SIGN2.Value = @"";

                    NewField21_122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 36, 106, 42, false);
                    NewField21_122.Name = "NewField21_122";
                    NewField21_122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21_122.TextFont.Name = "Arial";
                    NewField21_122.TextFont.Size = 11;
                    NewField21_122.TextFont.Bold = true;
                    NewField21_122.TextFont.CharSet = 162;
                    NewField21_122.Value = @"KISIM AMİRİ";

                    YRDATL_SIGN1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 42, 111, 62, false);
                    YRDATL_SIGN1.Name = "YRDATL_SIGN1";
                    YRDATL_SIGN1.FieldType = ReportFieldTypeEnum.ftVariable;
                    YRDATL_SIGN1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YRDATL_SIGN1.MultiLine = EvetHayirEnum.ehEvet;
                    YRDATL_SIGN1.WordBreak = EvetHayirEnum.ehEvet;
                    YRDATL_SIGN1.TextFont.Name = "Arial";
                    YRDATL_SIGN1.TextFont.Size = 11;
                    YRDATL_SIGN1.TextFont.CharSet = 162;
                    YRDATL_SIGN1.Value = @"";

                    NewField23_1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 97, 192, 103, false);
                    NewField23_1.Name = "NewField23_1";
                    NewField23_1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField23_1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField23_1.TextFont.Name = "Arial";
                    NewField23_1.TextFont.Size = 11;
                    NewField23_1.TextFont.Bold = true;
                    NewField23_1.TextFont.Italic = true;
                    NewField23_1.TextFont.CharSet = 162;
                    NewField23_1.Value = @"ONAY";

                    ONAY_SIGN1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 103, 187, 123, false);
                    ONAY_SIGN1.Name = "ONAY_SIGN1";
                    ONAY_SIGN1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONAY_SIGN1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONAY_SIGN1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ONAY_SIGN1.MultiLine = EvetHayirEnum.ehEvet;
                    ONAY_SIGN1.WordBreak = EvetHayirEnum.ehEvet;
                    ONAY_SIGN1.ObjectDefName = "ResUser";
                    ONAY_SIGN1.DataMember = "NAME";
                    ONAY_SIGN1.TextFont.Name = "Arial";
                    ONAY_SIGN1.TextFont.Size = 11;
                    ONAY_SIGN1.TextFont.CharSet = 162;
                    ONAY_SIGN1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    NewField2_.CalcValue = NewField2_.Value;
                    NewField21_.CalcValue = NewField21_.Value;
                    NewField23_.CalcValue = NewField23_.Value;
                    MUKONT_SIGN.CalcValue = @"";
                    NewField21_1.CalcValue = NewField21_1.Value;
                    NewField21_2.CalcValue = NewField21_2.Value;
                    NewField21_12.CalcValue = NewField21_12.Value;
                    NewField21_121.CalcValue = NewField21_121.Value;
                    ONAY_SIGN.CalcValue = @"";
                    ONAY_SIGN.PostFieldValueCalculation();
                    TEKNISYEN_SIGN.CalcValue = @"";
                    TEKNISYEN_SIGN.PostFieldValueCalculation();
                    YRDATL_SIGN.CalcValue = @"";
                    NewField21_13.CalcValue = NewField21_13.Value;
                    NewField21_14.CalcValue = NewField21_14.Value;
                    TEKNISYEN_SIGN1.CalcValue = @"";
                    TEKNISYEN_SIGN1.PostFieldValueCalculation();
                    TEKNISYEN_SIGN2.CalcValue = @"";
                    TEKNISYEN_SIGN2.PostFieldValueCalculation();
                    NewField21_122.CalcValue = NewField21_122.Value;
                    YRDATL_SIGN1.CalcValue = @"";
                    NewField23_1.CalcValue = NewField23_1.Value;
                    ONAY_SIGN1.CalcValue = @"";
                    ONAY_SIGN1.PostFieldValueCalculation();
                    return new TTReportObject[] { NewField2_,NewField21_,NewField23_,MUKONT_SIGN,NewField21_1,NewField21_2,NewField21_12,NewField21_121,ONAY_SIGN,TEKNISYEN_SIGN,YRDATL_SIGN,NewField21_13,NewField21_14,TEKNISYEN_SIGN1,TEKNISYEN_SIGN2,NewField21_122,YRDATL_SIGN1,NewField23_1,ONAY_SIGN1};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    TTObjectContext tto = new TTObjectContext(true);
            MaintenanceOrder mo = (MaintenanceOrder)tto.GetObject(new Guid(this.MyParentReport.RuntimeParameters.TTOBJECTID.ToString()), typeof(MaintenanceOrder));
            
            
            int countTeknisyen = 0;
            int countOnay= 0;
            int countAmir = 0;
            string imzalar ="";
            foreach (CMRActionSignDetail cmr in mo.FaalMalzemeImza)
            {
                if (cmr.SignUserType == SignUserTypeEnum.Teknisyen && countTeknisyen == 0)
                {
                    ResUser teknisyen = (ResUser)this.ParentReport.ReportObjectContext.GetObject(cmr.SignUser.ObjectID, typeof(ResUser));
                    imzalar += (teknisyen.MilitaryClass.ShortName != null) ? teknisyen.MilitaryClass.ShortName : "";
                    imzalar += (teknisyen.Rank.ShortName != null) ? teknisyen.Rank.ShortName : "";
                    imzalar += (teknisyen.Name != null) ? "\r\n" + teknisyen.Name : "";
                    imzalar += (teknisyen.EmploymentRecordID != null) ? "\r\n(" + teknisyen.EmploymentRecordID.ToString() + ")" : "";
                    TEKNISYEN_SIGN.CalcValue = imzalar;
                    countTeknisyen++;
                    imzalar="";
                }
                else if (cmr.SignUserType == SignUserTypeEnum.Teknisyen && countTeknisyen == 1)
                {
                    ResUser teknisyen = (ResUser)this.ParentReport.ReportObjectContext.GetObject(cmr.SignUser.ObjectID, typeof(ResUser));
                    imzalar += (teknisyen.MilitaryClass.ShortName != null) ? teknisyen.MilitaryClass.ShortName : "";
                    imzalar += (teknisyen.Rank.ShortName != null) ? teknisyen.Rank.ShortName : "";
                    imzalar += (teknisyen.Name != null) ? "\r\n" + teknisyen.Name : "";
                    imzalar += (teknisyen.EmploymentRecordID != null) ? "\r\n(" + teknisyen.EmploymentRecordID.ToString() + ")" : "";
                    TEKNISYEN_SIGN1.CalcValue = imzalar;
                    countTeknisyen++;
                    imzalar="";
                }
                else if (cmr.SignUserType == SignUserTypeEnum.Teknisyen && countTeknisyen == 2)
                {
                    ResUser teknisyen = (ResUser)this.ParentReport.ReportObjectContext.GetObject(cmr.SignUser.ObjectID, typeof(ResUser));
                    imzalar += (teknisyen.MilitaryClass.ShortName != null) ? teknisyen.MilitaryClass.ShortName : "";
                    imzalar += (teknisyen.Rank.ShortName != null) ? teknisyen.Rank.ShortName : "";
                    imzalar += (teknisyen.Name != null) ? "\r\n" + teknisyen.Name : "";
                    imzalar += (teknisyen.EmploymentRecordID != null) ? "\r\n(" + teknisyen.EmploymentRecordID.ToString() + ")" : "";
                    TEKNISYEN_SIGN2.CalcValue = imzalar;
                    countTeknisyen++;
                    imzalar="";
                }
                if (cmr.SignUserType == SignUserTypeEnum.Onay && countOnay == 0)
                {
                    ResUser onayUser = (ResUser)this.ParentReport.ReportObjectContext.GetObject(cmr.SignUser.ObjectID, typeof(ResUser));
                    imzalar = onayUser.Name + "\r\n";
                    imzalar += (onayUser.MilitaryClass != null) ? onayUser.MilitaryClass.ShortName + "\r\n" : "";
                    imzalar += (onayUser.Rank != null) ? onayUser.Rank.ShortName + "\r\n" : "";
                    imzalar += (onayUser.EmploymentRecordID != null) ? "(" + onayUser.EmploymentRecordID.ToString() + ")\r\n" : "";
                    this.ONAY_SIGN.CalcValue = imzalar;
                    countOnay++;
                    imzalar="";
                }
                else if (cmr.SignUserType == SignUserTypeEnum.Onay && countOnay == 1)
                {
                    ResUser onayUser = (ResUser)this.ParentReport.ReportObjectContext.GetObject(cmr.SignUser.ObjectID, typeof(ResUser));
                    imzalar = onayUser.Name + "\r\n";
                    imzalar += (onayUser.MilitaryClass != null) ? onayUser.MilitaryClass.ShortName + "\r\n" : "";
                    imzalar += (onayUser.Rank != null) ? onayUser.Rank.ShortName + "\r\n" : "";
                    imzalar += (onayUser.EmploymentRecordID != null) ? "(" + onayUser.EmploymentRecordID.ToString() + ")\r\n" : "";
                    this.ONAY_SIGN1.CalcValue = imzalar;
                    countOnay++;
                    imzalar="";
                }
                if (cmr.SignUserType == SignUserTypeEnum.MuaKontKltYntBlA)
                {
                    ResUser muakontUser = (ResUser)this.ParentReport.ReportObjectContext.GetObject(cmr.SignUser.ObjectID, typeof(ResUser));
                    imzalar = muakontUser.Name + "\r\n";
                    imzalar += (muakontUser.MilitaryClass != null) ? muakontUser.MilitaryClass.ShortName + "\r\n" : "";
                    imzalar += (muakontUser.Rank != null) ? muakontUser.Rank.ShortName + "\r\n" : "";
                    imzalar += (muakontUser.EmploymentRecordID != null) ? "(" + muakontUser.EmploymentRecordID.ToString() + ")\r\n" : "";
                    this.MUKONT_SIGN.CalcValue = imzalar;
                    imzalar="";
                }
                if(cmr.SignUserType == SignUserTypeEnum.KısımAmiri && countAmir== 0 )
                {
                    ResUser yrdAtlUser = (ResUser)this.ParentReport.ReportObjectContext.GetObject(cmr.SignUser.ObjectID, typeof(ResUser));
                    imzalar = yrdAtlUser.Name + "\r\n";
                    imzalar += (yrdAtlUser.MilitaryClass != null) ? yrdAtlUser.MilitaryClass.ShortName + "\r\n" : "";
                    imzalar += (yrdAtlUser.Rank != null) ? yrdAtlUser.Rank.ShortName + "\r\n" : "";
                    imzalar += (yrdAtlUser.EmploymentRecordID != null) ? "(" + yrdAtlUser.EmploymentRecordID.ToString() + ")\r\n" : "";
                    this.YRDATL_SIGN.CalcValue = imzalar;
                    countAmir++;
                    imzalar="";
                }
                else if(cmr.SignUserType == SignUserTypeEnum.KısımAmiri && countAmir== 1 )
                {
                    ResUser yrdAtlUser = (ResUser)this.ParentReport.ReportObjectContext.GetObject(cmr.SignUser.ObjectID, typeof(ResUser));
                    imzalar = yrdAtlUser.Name + "\r\n";
                    imzalar += (yrdAtlUser.MilitaryClass != null) ? yrdAtlUser.MilitaryClass.ShortName + "\r\n" : "";
                    imzalar += (yrdAtlUser.Rank != null) ? yrdAtlUser.Rank.ShortName + "\r\n" : "";
                    imzalar += (yrdAtlUser.EmploymentRecordID != null) ? "(" + yrdAtlUser.EmploymentRecordID.ToString() + ")\r\n" : "";
                    this.YRDATL_SIGN1.CalcValue= imzalar;
                    countAmir++;
                    imzalar="";
                }
                
            }
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public FaalMalzemeRaporu MyParentReport
            {
                get { return (FaalMalzemeRaporu)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportField TOTALCOUNT { get {return Footer().TOTALCOUNT;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportField COUNTTEXT { get {return Footer().COUNTTEXT;} }
            public TTReportField ACIKLAMA { get {return Footer().ACIKLAMA;} }
            public TTReportField NewField41_1 { get {return Footer().NewField41_1;} }
            public TTReportField AMOUNTTEXT { get {return Footer().AMOUNTTEXT;} }
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
                public FaalMalzemeRaporu MyParentReport
                {
                    get { return (FaalMalzemeRaporu)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField161;
                public TTReportField NewField1121; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 16;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 0, 22, 16, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"S.N.";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 45, 16, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 11;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"
Sipariş
Nu.";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 0, 130, 16, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Size = 11;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Malzemenin Cinsi";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 0, 152, 16, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Size = 11;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"Marka 
- 
Model";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 0, 180, 16, false);
                    NewField151.Name = "NewField151";
                    NewField151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.Size = 11;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"Seri Nu.";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 0, 202, 16, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Size = 11;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"Miktarı";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 0, 78, 16, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Size = 11;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"STOK NO";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    NewField11.CalcValue = NewField11.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    return new TTReportObject[] { NewField11,NewField121,NewField131,NewField141,NewField151,NewField161,NewField1121};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public FaalMalzemeRaporu MyParentReport
                {
                    get { return (FaalMalzemeRaporu)ParentReport; }
                }
                
                public TTReportShape NewLine1;
                public TTReportField TOTALCOUNT;
                public TTReportShape NewLine12;
                public TTReportField COUNTTEXT;
                public TTReportField ACIKLAMA;
                public TTReportField NewField41_1;
                public TTReportField AMOUNTTEXT; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 27;
                    RepeatCount = 0;
                    
                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 4, 55, 4, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    TOTALCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 1, 152, 6, false);
                    TOTALCOUNT.Name = "TOTALCOUNT";
                    TOTALCOUNT.FieldType = ReportFieldTypeEnum.ftExpression;
                    TOTALCOUNT.CaseFormat = CaseFormatEnum.fcUpperCase;
                    TOTALCOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTALCOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALCOUNT.TextFont.Name = "Arial";
                    TOTALCOUNT.TextFont.Size = 11;
                    TOTALCOUNT.TextFont.CharSet = 162;
                    TOTALCOUNT.Value = @"""Yalnız "" + COUNTTEXT.FormattedValue + "" Kalem "" + AMOUNTTEXT.FormattedValue + "" Adettir.""";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 154, 4, 201, 4, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    COUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 3, 244, 8, false);
                    COUNTTEXT.Name = "COUNTTEXT";
                    COUNTTEXT.Visible = EvetHayirEnum.ehHayir;
                    COUNTTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTTEXT.TextFormat = @"NUMBERTEXT";
                    COUNTTEXT.Value = @"{@subgroupcount@}";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 10, 202, 29, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACIKLAMA.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA.TextFont.Name = "Arial";
                    ACIKLAMA.TextFont.Size = 11;
                    ACIKLAMA.TextFont.CharSet = 162;
                    ACIKLAMA.Value = @"Yukarıdaki cins ve miktarı yazılı cihazın/malzemenin gerekli bakım ve onarımı yapılarak faal 
duruma getirilmiş olup Faal Malzeme Raporu tarafımızdan tanzim ve imza edilmiştir.";

                    NewField41_1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 10, 34, 15, false);
                    NewField41_1.Name = "NewField41_1";
                    NewField41_1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField41_1.TextFont.Name = "Arial";
                    NewField41_1.TextFont.Size = 11;
                    NewField41_1.TextFont.Underline = true;
                    NewField41_1.TextFont.CharSet = 162;
                    NewField41_1.Value = @"Açıklama :";

                    AMOUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 3, 272, 8, false);
                    AMOUNTTEXT.Name = "AMOUNTTEXT";
                    AMOUNTTEXT.Visible = EvetHayirEnum.ehHayir;
                    AMOUNTTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNTTEXT.TextFormat = @"NUMBERTEXT";
                    AMOUNTTEXT.Value = @"{#PARTA.AMOUNT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    COUNTTEXT.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    ACIKLAMA.CalcValue = ACIKLAMA.Value;
                    NewField41_1.CalcValue = NewField41_1.Value;
                    AMOUNTTEXT.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Amount) : "");
                    TOTALCOUNT.CalcValue = "Yalnız " + COUNTTEXT.FormattedValue + " Kalem " + AMOUNTTEXT.FormattedValue + " Adettir.";
                    return new TTReportObject[] { COUNTTEXT,ACIKLAMA,NewField41_1,AMOUNTTEXT,TOTALCOUNT};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public FaalMalzemeRaporu MyParentReport
            {
                get { return (FaalMalzemeRaporu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField SIPARISNO { get {return Body().SIPARISNO;} }
            public TTReportField MALZEMECINSI { get {return Body().MALZEMECINSI;} }
            public TTReportField MARKAMODEL { get {return Body().MARKAMODEL;} }
            public TTReportField SERINO { get {return Body().SERINO;} }
            public TTReportField MIKTARI { get {return Body().MIKTARI;} }
            public TTReportField MARK { get {return Body().MARK;} }
            public TTReportField MODEL { get {return Body().MODEL;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
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
                public FaalMalzemeRaporu MyParentReport
                {
                    get { return (FaalMalzemeRaporu)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField SIPARISNO;
                public TTReportField MALZEMECINSI;
                public TTReportField MARKAMODEL;
                public TTReportField SERINO;
                public TTReportField MIKTARI;
                public TTReportField MARK;
                public TTReportField MODEL;
                public TTReportField NATOSTOCKNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 16;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 0, 22, 16, false);
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

                    SIPARISNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 45, 16, false);
                    SIPARISNO.Name = "SIPARISNO";
                    SIPARISNO.DrawStyle = DrawStyleConstants.vbSolid;
                    SIPARISNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIPARISNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIPARISNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIPARISNO.MultiLine = EvetHayirEnum.ehEvet;
                    SIPARISNO.WordBreak = EvetHayirEnum.ehEvet;
                    SIPARISNO.TextFont.Name = "Arial";
                    SIPARISNO.TextFont.CharSet = 162;
                    SIPARISNO.Value = @"{#PARTA.ORDERNO#}";

                    MALZEMECINSI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 0, 130, 16, false);
                    MALZEMECINSI.Name = "MALZEMECINSI";
                    MALZEMECINSI.DrawStyle = DrawStyleConstants.vbSolid;
                    MALZEMECINSI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMECINSI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    MALZEMECINSI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MALZEMECINSI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MALZEMECINSI.MultiLine = EvetHayirEnum.ehEvet;
                    MALZEMECINSI.WordBreak = EvetHayirEnum.ehEvet;
                    MALZEMECINSI.TextFont.Name = "Arial";
                    MALZEMECINSI.TextFont.CharSet = 162;
                    MALZEMECINSI.Value = @"{#PARTA.FIXEDASSETNAME#}";

                    MARKAMODEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 0, 152, 16, false);
                    MARKAMODEL.Name = "MARKAMODEL";
                    MARKAMODEL.DrawStyle = DrawStyleConstants.vbSolid;
                    MARKAMODEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARKAMODEL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MARKAMODEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARKAMODEL.MultiLine = EvetHayirEnum.ehEvet;
                    MARKAMODEL.WordBreak = EvetHayirEnum.ehEvet;
                    MARKAMODEL.TextFont.Name = "Arial";
                    MARKAMODEL.TextFont.CharSet = 162;
                    MARKAMODEL.Value = @"{#PARTA.MARK#}
{#PARTA.MODEL#}";

                    SERINO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 0, 180, 16, false);
                    SERINO.Name = "SERINO";
                    SERINO.DrawStyle = DrawStyleConstants.vbSolid;
                    SERINO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERINO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SERINO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SERINO.MultiLine = EvetHayirEnum.ehEvet;
                    SERINO.WordBreak = EvetHayirEnum.ehEvet;
                    SERINO.TextFont.Name = "Arial";
                    SERINO.TextFont.CharSet = 162;
                    SERINO.Value = @"{#PARTA.SERIALNUMBER#}";

                    MIKTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 0, 202, 16, false);
                    MIKTARI.Name = "MIKTARI";
                    MIKTARI.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MIKTARI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTARI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTARI.MultiLine = EvetHayirEnum.ehEvet;
                    MIKTARI.WordBreak = EvetHayirEnum.ehEvet;
                    MIKTARI.TextFont.Name = "Arial";
                    MIKTARI.TextFont.CharSet = 162;
                    MIKTARI.Value = @"{#PARTA.AMOUNT#}";

                    MARK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 4, 231, 9, false);
                    MARK.Name = "MARK";
                    MARK.Visible = EvetHayirEnum.ehHayir;
                    MARK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARK.Value = @"{#PARTA.MARK#}";

                    MODEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 4, 244, 9, false);
                    MODEL.Name = "MODEL";
                    MODEL.Visible = EvetHayirEnum.ehHayir;
                    MODEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MODEL.Value = @"{#PARTA.MODEL#}";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 0, 78, 16, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NATOSTOCKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOSTOCKNO.MultiLine = EvetHayirEnum.ehEvet;
                    NATOSTOCKNO.WordBreak = EvetHayirEnum.ehEvet;
                    NATOSTOCKNO.TextFont.Name = "Arial";
                    NATOSTOCKNO.TextFont.CharSet = 162;
                    NATOSTOCKNO.Value = @"{#PARTA.NATOSTOCKNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    SIRANO.CalcValue = ParentGroup.Counter.ToString();
                    SIPARISNO.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.OrderNO) : "");
                    MALZEMECINSI.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Fixedassetname) : "");
                    MARKAMODEL.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Mark) : "") + @"
" + (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Model) : "");
                    SERINO.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.SerialNumber) : "");
                    MIKTARI.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Amount) : "");
                    MARK.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Mark) : "");
                    MODEL.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Model) : "");
                    NATOSTOCKNO.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.NATOStockNO) : "");
                    return new TTReportObject[] { SIRANO,SIPARISNO,MALZEMECINSI,MARKAMODEL,SERINO,MIKTARI,MARK,MODEL,NATOSTOCKNO};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(MARK.CalcValue == "")
                MARK.CalcValue = "---";
            
            if(MODEL.CalcValue == "")
                MODEL.CalcValue = "---";
            
            if(SERINO.CalcValue == "")
                SERINO.CalcValue = "---";
            
            MARKAMODEL.CalcValue = MARK.CalcValue + "/" + MODEL.CalcValue;
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTCGroup : TTReportGroup
        {
            public FaalMalzemeRaporu MyParentReport
            {
                get { return (FaalMalzemeRaporu)ParentReport; }
            }

            new public PARTCGroupBody Body()
            {
                return (PARTCGroupBody)_body;
            }
            public TTReportField SS { get {return Body().SS;} }
            public TTReportField SS2 { get {return Body().SS2;} }
            public TTReportField MALZEMECINSIMUH { get {return Body().MALZEMECINSIMUH;} }
            public TTReportField MARKAMODEL1 { get {return Body().MARKAMODEL1;} }
            public TTReportField MIKTARIMUH { get {return Body().MIKTARIMUH;} }
            public TTReportField SS12 { get {return Body().SS12;} }
            public TTReportField RULOBJECTID { get {return Body().RULOBJECTID;} }
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
                return new object[] {(dataSet_GetMaintenanceOrderByObjectIDQuery==null ? null : dataSet_GetMaintenanceOrderByObjectIDQuery.Rulobjectid)};
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
                public FaalMalzemeRaporu MyParentReport
                {
                    get { return (FaalMalzemeRaporu)ParentReport; }
                }
                
                public TTReportField SS;
                public TTReportField SS2;
                public TTReportField MALZEMECINSIMUH;
                public TTReportField MARKAMODEL1;
                public TTReportField MIKTARIMUH;
                public TTReportField SS12;
                public TTReportField RULOBJECTID; 
                public PARTCGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    SS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 0, 22, 10, false);
                    SS.Name = "SS";
                    SS.DrawStyle = DrawStyleConstants.vbSolid;
                    SS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SS.MultiLine = EvetHayirEnum.ehEvet;
                    SS.WordBreak = EvetHayirEnum.ehEvet;
                    SS.TextFont.Name = "Arial";
                    SS.TextFont.CharSet = 162;
                    SS.Value = @"";

                    SS2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 22, 0, 45, 10, false);
                    SS2.Name = "SS2";
                    SS2.DrawStyle = DrawStyleConstants.vbSolid;
                    SS2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SS2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SS2.MultiLine = EvetHayirEnum.ehEvet;
                    SS2.WordBreak = EvetHayirEnum.ehEvet;
                    SS2.TextFont.Name = "Arial";
                    SS2.TextFont.CharSet = 162;
                    SS2.Value = @"";

                    MALZEMECINSIMUH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 0, 130, 10, false);
                    MALZEMECINSIMUH.Name = "MALZEMECINSIMUH";
                    MALZEMECINSIMUH.DrawStyle = DrawStyleConstants.vbSolid;
                    MALZEMECINSIMUH.FieldType = ReportFieldTypeEnum.ftVariable;
                    MALZEMECINSIMUH.CaseFormat = CaseFormatEnum.fcUpperCase;
                    MALZEMECINSIMUH.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MALZEMECINSIMUH.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MALZEMECINSIMUH.MultiLine = EvetHayirEnum.ehEvet;
                    MALZEMECINSIMUH.WordBreak = EvetHayirEnum.ehEvet;
                    MALZEMECINSIMUH.TextFont.Name = "Arial";
                    MALZEMECINSIMUH.TextFont.CharSet = 162;
                    MALZEMECINSIMUH.Value = @"";

                    MARKAMODEL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 0, 180, 10, false);
                    MARKAMODEL1.Name = "MARKAMODEL1";
                    MARKAMODEL1.DrawStyle = DrawStyleConstants.vbSolid;
                    MARKAMODEL1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MARKAMODEL1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MARKAMODEL1.MultiLine = EvetHayirEnum.ehEvet;
                    MARKAMODEL1.WordBreak = EvetHayirEnum.ehEvet;
                    MARKAMODEL1.TextFont.Name = "Arial";
                    MARKAMODEL1.TextFont.CharSet = 162;
                    MARKAMODEL1.Value = @"MUHTEVİYAT";

                    MIKTARIMUH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 0, 202, 10, false);
                    MIKTARIMUH.Name = "MIKTARIMUH";
                    MIKTARIMUH.DrawStyle = DrawStyleConstants.vbSolid;
                    MIKTARIMUH.FieldType = ReportFieldTypeEnum.ftVariable;
                    MIKTARIMUH.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MIKTARIMUH.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MIKTARIMUH.MultiLine = EvetHayirEnum.ehEvet;
                    MIKTARIMUH.WordBreak = EvetHayirEnum.ehEvet;
                    MIKTARIMUH.TextFont.Name = "Arial";
                    MIKTARIMUH.TextFont.CharSet = 162;
                    MIKTARIMUH.Value = @"";

                    SS12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 0, 78, 10, false);
                    SS12.Name = "SS12";
                    SS12.DrawStyle = DrawStyleConstants.vbSolid;
                    SS12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SS12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SS12.MultiLine = EvetHayirEnum.ehEvet;
                    SS12.WordBreak = EvetHayirEnum.ehEvet;
                    SS12.TextFont.Name = "Arial";
                    SS12.TextFont.CharSet = 162;
                    SS12.Value = @"";

                    RULOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 2, 247, 7, false);
                    RULOBJECTID.Name = "RULOBJECTID";
                    RULOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    RULOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    RULOBJECTID.Value = @"{#PARTA.RULOBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class dataset_GetMaintenanceOrderByObjectIDQuery = MyParentReport.PARTA.rsGroup.GetCurrentRecord<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(0);
                    SS.CalcValue = SS.Value;
                    SS2.CalcValue = SS2.Value;
                    MALZEMECINSIMUH.CalcValue = @"";
                    MARKAMODEL1.CalcValue = MARKAMODEL1.Value;
                    MIKTARIMUH.CalcValue = @"";
                    SS12.CalcValue = SS12.Value;
                    RULOBJECTID.CalcValue = (dataset_GetMaintenanceOrderByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetMaintenanceOrderByObjectIDQuery.Rulobjectid) : "");
                    return new TTReportObject[] { SS,SS2,MALZEMECINSIMUH,MARKAMODEL1,MIKTARIMUH,SS12,RULOBJECTID};
                }

                public override void RunScript()
                {
#region PARTC BODY_Script
                    if(!string.IsNullOrEmpty(this.RULOBJECTID.CalcValue))
            {
                BindingList<ReferToUpperLevel.GetRULDetailsByRequestNoQuery_Class> list = ReferToUpperLevel.GetRULDetailsByRequestNoQuery(new Guid(this.RULOBJECTID.CalcValue));
                if (list.Count > 0)
                {
                    foreach (ReferToUpperLevel.GetRULDetailsByRequestNoQuery_Class faalMal in list)
                    {
                        this.MALZEMECINSIMUH.CalcValue = faalMal.ItemName;
                        this.MIKTARIMUH.CalcValue = faalMal.Amount + " - " + faalMal.DistributionType;
                    }

                }
                else
                {
                    this.MARKAMODEL1.Visible = EvetHayirEnum.ehHayir;
                    this.SS.Visible = EvetHayirEnum.ehHayir;
                    this.SS12.Visible = EvetHayirEnum.ehHayir;
                    this.SS2.Visible = EvetHayirEnum.ehHayir;
                    this.MALZEMECINSIMUH.Visible = EvetHayirEnum.ehHayir;
                    this.MIKTARIMUH.Visible = EvetHayirEnum.ehHayir;
                }
            }
            else
            {
                this.MARKAMODEL1.Visible = EvetHayirEnum.ehHayir;
                this.SS.Visible = EvetHayirEnum.ehHayir;
                this.SS12.Visible = EvetHayirEnum.ehHayir;
                this.SS2.Visible = EvetHayirEnum.ehHayir;
                this.MALZEMECINSIMUH.Visible = EvetHayirEnum.ehHayir;
                this.MIKTARIMUH.Visible = EvetHayirEnum.ehHayir;
            }
#endregion PARTC BODY_Script
                }
            }

        }

        public PARTCGroup PARTC;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public FaalMalzemeRaporu()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            PARTC = new PARTCGroup(PARTB,"PARTC");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("REPORTNO", "", "", @"", true, false, false, new Guid("d3f7227f-34dd-423e-9041-fdfffd14f4a3"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("REPORTNO"))
                _runtimeParameters.REPORTNO = (string)TTObjectDefManager.Instance.DataTypes["String_15"].ConvertValue(parameters["REPORTNO"]);
            Name = "FAALMALZEMERAPORU";
            Caption = "Faal Malzeme Raporu (Ek-8.9)";
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