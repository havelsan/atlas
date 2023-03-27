
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
    /// Değerlendirmeye Esas Teklif Bedeli Cetveli
    /// </summary>
    public partial class DegerlendirmeyeEsasTeklifBedeliCetveli : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public DegerlendirmeyeEsasTeklifBedeliCetveli MyParentReport
            {
                get { return (DegerlendirmeyeEsasTeklifBedeliCetveli)ParentReport; }
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
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField ISINADI { get {return Header().ISINADI;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField9_1 { get {return Header().NewField9_1;} }
            public TTReportField NewField7_1 { get {return Header().NewField7_1;} }
            public TTReportField NewField_1 { get {return Header().NewField_1;} }
            public TTReportField NewField6_1 { get {return Header().NewField6_1;} }
            public TTReportField NewField8_1 { get {return Header().NewField8_1;} }
            public TTReportField NewField7_11 { get {return Header().NewField7_11;} }
            public TTReportField NewField7_12 { get {return Header().NewField7_12;} }
            public TTReportField NewField7_111 { get {return Header().NewField7_111;} }
            public TTReportField NewField7_121 { get {return Header().NewField7_121;} }
            public TTReportField NewField7_131 { get {return Header().NewField7_131;} }
            public TTReportField NewField7_141 { get {return Header().NewField7_141;} }
            public TTReportField NewField7_151 { get {return Header().NewField7_151;} }
            public TTReportField GROUPOBJECTID { get {return Header().GROUPOBJECTID;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField LOGO111111111 { get {return Header().LOGO111111111;} }
            public TTReportField PROJECTNO { get {return Footer().PROJECTNO;} }
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
                list[0] = new TTReportNqlData<PurchaseProjectGroup.GetProjectGroups_Class>("GetProjectGroups", PurchaseProjectGroup.GetProjectGroups((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public DegerlendirmeyeEsasTeklifBedeliCetveli MyParentReport
                {
                    get { return (DegerlendirmeyeEsasTeklifBedeliCetveli)ParentReport; }
                }
                
                public TTReportField NewField2;
                public TTReportField NewField;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField IHALEKAYITNO;
                public TTReportField IDAREADI;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField DATE;
                public TTReportField ISINADI;
                public TTReportField NewField1;
                public TTReportField NewField9_1;
                public TTReportField NewField7_1;
                public TTReportField NewField_1;
                public TTReportField NewField6_1;
                public TTReportField NewField8_1;
                public TTReportField NewField7_11;
                public TTReportField NewField7_12;
                public TTReportField NewField7_111;
                public TTReportField NewField7_121;
                public TTReportField NewField7_131;
                public TTReportField NewField7_141;
                public TTReportField NewField7_151;
                public TTReportField GROUPOBJECTID;
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO111111111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 93;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 40, 64, 45, false);
                    NewField2.Name = "NewField2";
                    NewField2.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"İhale Kayıt Numarası";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 40, 65, 45, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField.TextFont.Name = "Arial";
                    NewField.TextFont.Bold = true;
                    NewField.Value = @":";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 45, 64, 50, false);
                    NewField3.Name = "NewField3";
                    NewField3.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"İdarenin Adı";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 45, 65, 50, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @":";

                    IHALEKAYITNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 40, 171, 45, false);
                    IHALEKAYITNO.Name = "IHALEKAYITNO";
                    IHALEKAYITNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    IHALEKAYITNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IHALEKAYITNO.ObjectDefName = "PurchaseProject";
                    IHALEKAYITNO.DataMember = "KIKTENDERREGISTERNO";
                    IHALEKAYITNO.TextFont.Name = "Arial";
                    IHALEKAYITNO.Value = @"{@TTOBJECTID@}";

                    IDAREADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 45, 257, 50, false);
                    IDAREADI.Name = "IDAREADI";
                    IDAREADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    IDAREADI.CaseFormat = CaseFormatEnum.fcTitleCase;
                    IDAREADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IDAREADI.WordBreak = EvetHayirEnum.ehEvet;
                    IDAREADI.ObjectDefName = "PurchaseProject";
                    IDAREADI.DataMember = "RESPONSIBLEPROCUREMENTUNITDEF.NAME";
                    IDAREADI.TextFont.Name = "Arial";
                    IDAREADI.Value = @"{@TTOBJECTID@}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 50, 64, 55, false);
                    NewField5.Name = "NewField5";
                    NewField5.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @"İşin Adı";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 50, 65, 55, false);
                    NewField6.Name = "NewField6";
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Bold = true;
                    NewField6.Value = @":";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 55, 64, 60, false);
                    NewField7.Name = "NewField7";
                    NewField7.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Bold = true;
                    NewField7.Value = @"Tutanağın doldurulduğu tarih ve saat";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 55, 183, 60, false);
                    DATE.Name = "DATE";
                    DATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATE.TextFont.Name = "Arial";
                    DATE.Value = @"_ _ /_ _ /_ _ _ _ ............................. günü, saat _ _ : _ _";

                    ISINADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 50, 257, 55, false);
                    ISINADI.Name = "ISINADI";
                    ISINADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISINADI.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ISINADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISINADI.WordBreak = EvetHayirEnum.ehEvet;
                    ISINADI.ObjectDefName = "PurchaseProject";
                    ISINADI.DataMember = "ACTDEFINE";
                    ISINADI.TextFont.Name = "Arial";
                    ISINADI.Value = @"{@TTOBJECTID@}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 55, 65, 60, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @":";

                    NewField9_1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 66, 257, 71, false);
                    NewField9_1.Name = "NewField9_1";
                    NewField9_1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField9_1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField9_1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9_1.TextFont.Name = "Arial";
                    NewField9_1.TextFont.Size = 11;
                    NewField9_1.TextFont.Bold = true;
                    NewField9_1.Value = @"Değerlendirmeye Esas Teklif Bedeli Cetveli";

                    NewField7_1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 71, 127, 86, false);
                    NewField7_1.Name = "NewField7_1";
                    NewField7_1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7_1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField7_1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7_1.TextFont.Name = "Arial";
                    NewField7_1.TextFont.Size = 11;
                    NewField7_1.Value = @"Teklif Bedeli";

                    NewField_1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 71, 62, 86, false);
                    NewField_1.Name = "NewField_1";
                    NewField_1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField_1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField_1.TextFont.Name = "Arial";
                    NewField_1.TextFont.Size = 11;
                    NewField_1.Value = @"İsteklinin Adı";

                    NewField6_1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 71, 192, 86, false);
                    NewField6_1.Name = "NewField6_1";
                    NewField6_1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6_1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField6_1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6_1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6_1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField6_1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField6_1.TextFont.Name = "Arial";
                    NewField6_1.TextFont.Size = 11;
                    NewField6_1.Value = @"Fiyat dışı unsurları dikkate alınarak değerlendirilmiş teklif bedeli";

                    NewField8_1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 71, 257, 86, false);
                    NewField8_1.Name = "NewField8_1";
                    NewField8_1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField8_1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField8_1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField8_1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8_1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField8_1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField8_1.TextFont.Name = "Arial";
                    NewField8_1.TextFont.Size = 11;
                    NewField8_1.Value = @"Yerli malı teklif eden yerli istekliler lehine fiyat avantajı uygulanması sonucu bulunan teklif bedeli";

                    NewField7_11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 86, 82, 91, false);
                    NewField7_11.Name = "NewField7_11";
                    NewField7_11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7_11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7_11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7_11.TextFont.Name = "Arial";
                    NewField7_11.Value = @"Rakam ile";

                    NewField7_12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 86, 127, 91, false);
                    NewField7_12.Name = "NewField7_12";
                    NewField7_12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7_12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7_12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7_12.TextFont.Name = "Arial";
                    NewField7_12.Value = @"Yazı ile";

                    NewField7_111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 86, 147, 91, false);
                    NewField7_111.Name = "NewField7_111";
                    NewField7_111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7_111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7_111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7_111.TextFont.Name = "Arial";
                    NewField7_111.Value = @"Rakam ile";

                    NewField7_121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 86, 192, 91, false);
                    NewField7_121.Name = "NewField7_121";
                    NewField7_121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7_121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7_121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7_121.TextFont.Name = "Arial";
                    NewField7_121.Value = @"Yazı ile";

                    NewField7_131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 86, 212, 91, false);
                    NewField7_131.Name = "NewField7_131";
                    NewField7_131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7_131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7_131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7_131.TextFont.Name = "Arial";
                    NewField7_131.Value = @"Rakam ile";

                    NewField7_141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 86, 257, 91, false);
                    NewField7_141.Name = "NewField7_141";
                    NewField7_141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7_141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7_141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7_141.TextFont.Name = "Arial";
                    NewField7_141.Value = @"Yazı ile";

                    NewField7_151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 86, 62, 91, false);
                    NewField7_151.Name = "NewField7_151";
                    NewField7_151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7_151.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField7_151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7_151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7_151.TextFont.Name = "Arial";
                    NewField7_151.TextFont.Size = 11;
                    NewField7_151.Value = @"";

                    GROUPOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 58, 266, 63, false);
                    GROUPOBJECTID.Name = "GROUPOBJECTID";
                    GROUPOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    GROUPOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    GROUPOBJECTID.Value = @"{#OBJECTID!GetProjectGroups#}";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 15, 257, 38, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Size = 12;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    LOGO111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 40, 35, false);
                    LOGO111111111.Name = "LOGO111111111";
                    LOGO111111111.Visible = EvetHayirEnum.ehHayir;
                    LOGO111111111.TextFont.CharSet = 1;
                    LOGO111111111.Value = @"LOGO";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProjectGroup.GetProjectGroups_Class dataset_GetProjectGroups = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProjectGroup.GetProjectGroups_Class>(0);
                    NewField2.CalcValue = NewField2.Value;
                    NewField.CalcValue = NewField.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    IHALEKAYITNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    IHALEKAYITNO.PostFieldValueCalculation();
                    IDAREADI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    IDAREADI.PostFieldValueCalculation();
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    DATE.CalcValue = DATE.Value;
                    ISINADI.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    ISINADI.PostFieldValueCalculation();
                    NewField1.CalcValue = NewField1.Value;
                    NewField9_1.CalcValue = NewField9_1.Value;
                    NewField7_1.CalcValue = NewField7_1.Value;
                    NewField_1.CalcValue = NewField_1.Value;
                    NewField6_1.CalcValue = NewField6_1.Value;
                    NewField8_1.CalcValue = NewField8_1.Value;
                    NewField7_11.CalcValue = NewField7_11.Value;
                    NewField7_12.CalcValue = NewField7_12.Value;
                    NewField7_111.CalcValue = NewField7_111.Value;
                    NewField7_121.CalcValue = NewField7_121.Value;
                    NewField7_131.CalcValue = NewField7_131.Value;
                    NewField7_141.CalcValue = NewField7_141.Value;
                    NewField7_151.CalcValue = NewField7_151.Value;
                    GROUPOBJECTID.CalcValue = (dataset_GetProjectGroups != null ? Globals.ToStringCore(dataset_GetProjectGroups.ObjectID) : "");
                    LOGO111111111.CalcValue = LOGO111111111.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField2,NewField,NewField3,NewField4,IHALEKAYITNO,IDAREADI,NewField5,NewField6,NewField7,DATE,ISINADI,NewField1,NewField9_1,NewField7_1,NewField_1,NewField6_1,NewField8_1,NewField7_11,NewField7_12,NewField7_111,NewField7_121,NewField7_131,NewField7_141,NewField7_151,GROUPOBJECTID,LOGO111111111,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    //            TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((DegerlendirmeyeEsasTeklifBedeliCetveli)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            PurchaseProject pp = (PurchaseProject)context.GetObject(new Guid(sObjectID),"PurchaseProject");
//            
//            IHALEKAYITNO.CalcValue = pp.KIKTenderRegisterNO.ToString();
//            IDAREADI.CalcValue = pp.ResponsibleProcurementUnitDef.Name.ToString();
//            ISINADI.CalcValue = pp.ActDefine.ToString();
//
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public DegerlendirmeyeEsasTeklifBedeliCetveli MyParentReport
                {
                    get { return (DegerlendirmeyeEsasTeklifBedeliCetveli)ParentReport; }
                }
                
                public TTReportField PROJECTNO; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
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

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProjectGroup.GetProjectGroups_Class dataset_GetProjectGroups = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProjectGroup.GetProjectGroups_Class>(0);
                    PROJECTNO.CalcValue = @"";
                    return new TTReportObject[] { PROJECTNO};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    string objectID = ((DegerlendirmeyeEsasTeklifBedeliCetveli)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            PurchaseProject pp = (PurchaseProject)ctx.GetObject(new Guid(objectID), typeof(PurchaseProject));
            if (pp != null)
                PROJECTNO.CalcValue = " Proje Nu. : " + pp.PurchaseProjectNO.ToString();
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTEGroup : TTReportGroup
        {
            public DegerlendirmeyeEsasTeklifBedeliCetveli MyParentReport
            {
                get { return (DegerlendirmeyeEsasTeklifBedeliCetveli)ParentReport; }
            }

            new public PARTEGroupBody Body()
            {
                return (PARTEGroupBody)_body;
            }
            public TTReportField SUPPLIER { get {return Body().SUPPLIER;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
            public TTReportField PRICETXT { get {return Body().PRICETXT;} }
            public TTReportField NewField7_11 { get {return Body().NewField7_11;} }
            public TTReportField NewField7_12 { get {return Body().NewField7_12;} }
            public TTReportField NewField7_13 { get {return Body().NewField7_13;} }
            public TTReportField NewField7_14 { get {return Body().NewField7_14;} }
            public TTReportField Count { get {return Body().Count;} }
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
                list[0] = new TTReportNqlData<ProposalDetail.GetProposalledTotalPricesByGroup_Class>("GetProposalledTotalPricesByGroup", ProposalDetail.GetProposalledTotalPricesByGroup((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PARTB.GROUPOBJECTID.CalcValue)));
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
                public DegerlendirmeyeEsasTeklifBedeliCetveli MyParentReport
                {
                    get { return (DegerlendirmeyeEsasTeklifBedeliCetveli)ParentReport; }
                }
                
                public TTReportField SUPPLIER;
                public TTReportField PRICE;
                public TTReportField PRICETXT;
                public TTReportField NewField7_11;
                public TTReportField NewField7_12;
                public TTReportField NewField7_13;
                public TTReportField NewField7_14;
                public TTReportField Count; 
                public PARTEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 62, 5, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.DrawStyle = DrawStyleConstants.vbSolid;
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER.TextFont.Name = "Arial";
                    SUPPLIER.TextFont.Size = 9;
                    SUPPLIER.Value = @"{#SUPPLIER#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 0, 82, 5, false);
                    PRICE.Name = "PRICE";
                    PRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICE.TextFont.Name = "Arial";
                    PRICE.TextFont.Size = 9;
                    PRICE.Value = @"{#TOTALPROPOSALPRICE#}";

                    PRICETXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 0, 127, 5, false);
                    PRICETXT.Name = "PRICETXT";
                    PRICETXT.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICETXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICETXT.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PRICETXT.TextFormat = @"NUMBERTEXT";
                    PRICETXT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRICETXT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICETXT.WordBreak = EvetHayirEnum.ehEvet;
                    PRICETXT.TextFont.Name = "Arial";
                    PRICETXT.TextFont.Size = 9;
                    PRICETXT.Value = @"{%PRICE%}";

                    NewField7_11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 0, 147, 5, false);
                    NewField7_11.Name = "NewField7_11";
                    NewField7_11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7_11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField7_11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7_11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7_11.TextFont.Name = "Arial";
                    NewField7_11.TextFont.Size = 11;
                    NewField7_11.Value = @"";

                    NewField7_12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 0, 192, 5, false);
                    NewField7_12.Name = "NewField7_12";
                    NewField7_12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7_12.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField7_12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7_12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7_12.TextFont.Name = "Arial";
                    NewField7_12.TextFont.Size = 11;
                    NewField7_12.Value = @"";

                    NewField7_13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 0, 212, 5, false);
                    NewField7_13.Name = "NewField7_13";
                    NewField7_13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7_13.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField7_13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7_13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7_13.TextFont.Name = "Arial";
                    NewField7_13.TextFont.Size = 11;
                    NewField7_13.Value = @"";

                    NewField7_14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 0, 257, 5, false);
                    NewField7_14.Name = "NewField7_14";
                    NewField7_14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7_14.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField7_14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7_14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7_14.TextFont.Name = "Arial";
                    NewField7_14.TextFont.Size = 11;
                    NewField7_14.Value = @"";

                    Count = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 298, 0, 323, 5, false);
                    Count.Name = "Count";
                    Count.Visible = EvetHayirEnum.ehHayir;
                    Count.FieldType = ReportFieldTypeEnum.ftVariable;
                    Count.TextFont.Name = "Arial Narrow";
                    Count.TextFont.CharSet = 1;
                    Count.Value = @"{@counter@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ProposalDetail.GetProposalledTotalPricesByGroup_Class dataset_GetProposalledTotalPricesByGroup = ParentGroup.rsGroup.GetCurrentRecord<ProposalDetail.GetProposalledTotalPricesByGroup_Class>(0);
                    SUPPLIER.CalcValue = (dataset_GetProposalledTotalPricesByGroup != null ? Globals.ToStringCore(dataset_GetProposalledTotalPricesByGroup.Supplier) : "");
                    PRICE.CalcValue = (dataset_GetProposalledTotalPricesByGroup != null ? Globals.ToStringCore(dataset_GetProposalledTotalPricesByGroup.Totalproposalprice) : "");
                    PRICETXT.CalcValue = MyParentReport.PARTE.PRICE.CalcValue;
                    NewField7_11.CalcValue = NewField7_11.Value;
                    NewField7_12.CalcValue = NewField7_12.Value;
                    NewField7_13.CalcValue = NewField7_13.Value;
                    NewField7_14.CalcValue = NewField7_14.Value;
                    Count.CalcValue = ParentGroup.Counter.ToString();
                    return new TTReportObject[] { SUPPLIER,PRICE,PRICETXT,NewField7_11,NewField7_12,NewField7_13,NewField7_14,Count};
                }

                public override void RunScript()
                {
#region PARTE BODY_Script
                    count++;
#endregion PARTE BODY_Script
                }
            }

#region PARTE_Methods
            public static int count = 0;
#endregion PARTE_Methods
        }

        public PARTEGroup PARTE;

        public partial class PARTAGroup : TTReportGroup
        {
            public DegerlendirmeyeEsasTeklifBedeliCetveli MyParentReport
            {
                get { return (DegerlendirmeyeEsasTeklifBedeliCetveli)ParentReport; }
            }

            new public PARTAGroupBody Body()
            {
                return (PARTAGroupBody)_body;
            }
            public TTReportField DESC { get {return Body().DESC;} }
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
                public DegerlendirmeyeEsasTeklifBedeliCetveli MyParentReport
                {
                    get { return (DegerlendirmeyeEsasTeklifBedeliCetveli)ParentReport; }
                }
                
                public TTReportField DESC; 
                public PARTAGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 15;
                    RepeatCount = 0;
                    
                    DESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 3, 257, 13, false);
                    DESC.Name = "DESC";
                    DESC.FieldType = ReportFieldTypeEnum.ftExpression;
                    DESC.MultiLine = EvetHayirEnum.ehEvet;
                    DESC.WordBreak = EvetHayirEnum.ehEvet;
                    DESC.TextFont.Name = "Arial";
                    DESC.Value = @"""     "" + PARTEGroup.count.ToString()+ "" adet isteklinin teklifi değerlendirmeye alınmış olup, ekonomik açıdan en avantajlı teklifin belirlenmesinde kullanılacak değerlendirilmiş teklif bedeli yukarıda belirtilmiştir.""";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DESC.CalcValue = "     " + PARTEGroup.count.ToString()+ " adet isteklinin teklifi değerlendirmeye alınmış olup, ekonomik açıdan en avantajlı teklifin belirlenmesinde kullanılacak değerlendirilmiş teklif bedeli yukarıda belirtilmiştir.";
                    return new TTReportObject[] { DESC};
                }

                public override void RunScript()
                {
#region PARTA BODY_Script
                    PARTEGroup.count = 0;
#endregion PARTA BODY_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTDGroup : TTReportGroup
        {
            public DegerlendirmeyeEsasTeklifBedeliCetveli MyParentReport
            {
                get { return (DegerlendirmeyeEsasTeklifBedeliCetveli)ParentReport; }
            }

            new public PARTDGroupHeader Header()
            {
                return (PARTDGroupHeader)_header;
            }

            new public PARTDGroupFooter Footer()
            {
                return (PARTDGroupFooter)_footer;
            }

            public TTReportField PROJECTNO11411 { get {return Header().PROJECTNO11411;} }
            public PARTDGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTDGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTDGroupHeader(this);
                _footer = new PARTDGroupFooter(this);

            }

            public partial class PARTDGroupHeader : TTReportSection
            {
                public DegerlendirmeyeEsasTeklifBedeliCetveli MyParentReport
                {
                    get { return (DegerlendirmeyeEsasTeklifBedeliCetveli)ParentReport; }
                }
                
                public TTReportField PROJECTNO11411; 
                public PARTDGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PROJECTNO11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 3, 257, 8, false);
                    PROJECTNO11411.Name = "PROJECTNO11411";
                    PROJECTNO11411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROJECTNO11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO11411.TextFont.Name = "Arial";
                    PROJECTNO11411.TextFont.Bold = true;
                    PROJECTNO11411.Value = @"İHALE KOMİSYONU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PROJECTNO11411.CalcValue = PROJECTNO11411.Value;
                    return new TTReportObject[] { PROJECTNO11411};
                }
            }
            public partial class PARTDGroupFooter : TTReportSection
            {
                public DegerlendirmeyeEsasTeklifBedeliCetveli MyParentReport
                {
                    get { return (DegerlendirmeyeEsasTeklifBedeliCetveli)ParentReport; }
                }
                 
                public PARTDGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTDGroup PARTD;

        public partial class PARTCGroup : TTReportGroup
        {
            public DegerlendirmeyeEsasTeklifBedeliCetveli MyParentReport
            {
                get { return (DegerlendirmeyeEsasTeklifBedeliCetveli)ParentReport; }
            }

            new public PARTCGroupBody Body()
            {
                return (PARTCGroupBody)_body;
            }
            public TTReportField NAMESURNAME { get {return Body().NAMESURNAME;} }
            public TTReportField HOSPFUNC { get {return Body().HOSPFUNC;} }
            public TTReportField COMFUNC { get {return Body().COMFUNC;} }
            public TTReportField RANK { get {return Body().RANK;} }
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
                list[0] = new TTReportNqlData<PurchaseProject.GetTenderCommisionMembersQuery_Class>("GetTenderCommisionMembersQuery", PurchaseProject.GetTenderCommisionMembersQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTCGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTCGroupBody : TTReportSection
            {
                public DegerlendirmeyeEsasTeklifBedeliCetveli MyParentReport
                {
                    get { return (DegerlendirmeyeEsasTeklifBedeliCetveli)ParentReport; }
                }
                
                public TTReportField NAMESURNAME;
                public TTReportField HOSPFUNC;
                public TTReportField COMFUNC;
                public TTReportField RANK; 
                public PARTCGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 35;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 5;
                    RepeatWidth = 47;
                    
                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 11, 53, 15, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NAMESURNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME.NoClip = EvetHayirEnum.ehEvet;
                    NAMESURNAME.TextFont.Name = "Arial";
                    NAMESURNAME.Value = @"{#NAMESURNAME#}";

                    HOSPFUNC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 16, 53, 20, false);
                    HOSPFUNC.Name = "HOSPFUNC";
                    HOSPFUNC.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC.ObjectDefName = "UserTitleEnum";
                    HOSPFUNC.DataMember = "DISPLAYTEXT";
                    HOSPFUNC.TextFont.Name = "Arial";
                    HOSPFUNC.Value = @"{#HOSPFUNC#}";

                    COMFUNC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 1, 53, 5, false);
                    COMFUNC.Name = "COMFUNC";
                    COMFUNC.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC.CaseFormat = CaseFormatEnum.fcUpperCase;
                    COMFUNC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC.ObjectDefName = "CommisionMemberDutyEnum";
                    COMFUNC.DataMember = "DISPLAYTEXT";
                    COMFUNC.TextFont.Name = "Arial";
                    COMFUNC.Value = @"{#COMFUNC#}";

                    RANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 6, 53, 10, false);
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

        public PARTCGroup PARTC;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DegerlendirmeyeEsasTeklifBedeliCetveli()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTE = new PARTEGroup(PARTB,"PARTE");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            PARTD = new PARTDGroup(PARTB,"PARTD");
            PARTC = new PARTCGroup(PARTD,"PARTC");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Proje No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "DEGERLENDIRMEYEESASTEKLIFBEDELICETVELI";
            Caption = "Değerlendirmeye Esas Teklif Bedeli Cetveli";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 25;
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