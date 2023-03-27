
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
    /// Muvakkat Makbuzu
    /// </summary>
    public partial class MuvakkatMakbuzu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PART1Group : TTReportGroup
        {
            public MuvakkatMakbuzu MyParentReport
            {
                get { return (MuvakkatMakbuzu)ParentReport; }
            }

            new public PART1GroupHeader Header()
            {
                return (PART1GroupHeader)_header;
            }

            new public PART1GroupFooter Footer()
            {
                return (PART1GroupFooter)_footer;
            }

            public TTReportField ACCOUNTANCYNAME { get {return Header().ACCOUNTANCYNAME;} }
            public TTReportField STORENAME { get {return Header().STORENAME;} }
            public TTReportField TEXT1 { get {return Header().TEXT1;} }
            public TTReportField STOCKACTIONID { get {return Header().STOCKACTIONID;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1122 { get {return Header().NewField1122;} }
            public TTReportField NewField12211 { get {return Header().NewField12211;} }
            public TTReportField NewField12212 { get {return Header().NewField12212;} }
            public TTReportField DESC { get {return Footer().DESC;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField NewField13 { get {return Footer().NewField13;} }
            public TTReportField NewField122 { get {return Footer().NewField122;} }
            public TTReportField NewField1123 { get {return Footer().NewField1123;} }
            public TTReportField NewField11211 { get {return Footer().NewField11211;} }
            public TTReportField NewField12213 { get {return Footer().NewField12213;} }
            public TTReportField NewField111221 { get {return Footer().NewField111221;} }
            public TTReportField NewField121221 { get {return Footer().NewField121221;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField NewField16 { get {return Footer().NewField16;} }
            public TTReportField NUMBERTEXT { get {return Footer().NUMBERTEXT;} }
            public TTReportField SUPPLIERNAME { get {return Footer().SUPPLIERNAME;} }
            public PART1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PART1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PurchaseExamination.GetByObjcetID_Class>("GetObjcetID", PurchaseExamination.GetByObjcetID((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PART1GroupHeader(this);
                _footer = new PART1GroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PART1GroupHeader : TTReportSection
            {
                public MuvakkatMakbuzu MyParentReport
                {
                    get { return (MuvakkatMakbuzu)ParentReport; }
                }
                
                public TTReportField ACCOUNTANCYNAME;
                public TTReportField STORENAME;
                public TTReportField TEXT1;
                public TTReportField STOCKACTIONID;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField1121;
                public TTReportField NewField1122;
                public TTReportField NewField12211;
                public TTReportField NewField12212; 
                public PART1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 64;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ACCOUNTANCYNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 193, 15, false);
                    ACCOUNTANCYNAME.Name = "ACCOUNTANCYNAME";
                    ACCOUNTANCYNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANCYNAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ACCOUNTANCYNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACCOUNTANCYNAME.TextFont.Size = 11;
                    ACCOUNTANCYNAME.TextFont.Bold = true;
                    ACCOUNTANCYNAME.Value = @"{#ACCOUNTANCYNAME#}";

                    STORENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 16, 193, 21, false);
                    STORENAME.Name = "STORENAME";
                    STORENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORENAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    STORENAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STORENAME.TextFont.Size = 11;
                    STORENAME.TextFont.Bold = true;
                    STORENAME.Value = @"{#STORENAME#}";

                    TEXT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 22, 193, 32, false);
                    TEXT1.Name = "TEXT1";
                    TEXT1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEXT1.MultiLine = EvetHayirEnum.ehEvet;
                    TEXT1.TextFont.Size = 11;
                    TEXT1.TextFont.Bold = true;
                    TEXT1.Value = @"MALZEME TESLİM TUTANAĞI
(MUVAKKAT MAKBUZU)";

                    STOCKACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 40, 76, 45, false);
                    STOCKACTIONID.Name = "STOCKACTIONID";
                    STOCKACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKACTIONID.Value = @"{#STOCKACTIONID#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 40, 30, 45, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"İşlem No   :";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 53, 18, 63, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"S.
No";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 53, 96, 63, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"Malzeme Adı";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 53, 112, 63, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @"Miktarı";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 53, 128, 63, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.Value = @"Ölçü 
Birimi";

                    NewField1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 53, 149, 63, false);
                    NewField1122.Name = "NewField1122";
                    NewField1122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1122.TextFont.Bold = true;
                    NewField1122.Value = @"Miadı";

                    NewField12211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 53, 168, 63, false);
                    NewField12211.Name = "NewField12211";
                    NewField12211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12211.TextFont.Bold = true;
                    NewField12211.Value = @"Ambalaj 
Türü";

                    NewField12212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 53, 193, 63, false);
                    NewField12212.Name = "NewField12212";
                    NewField12212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12212.TextFont.Bold = true;
                    NewField12212.Value = @"Depodaki
Yeri";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseExamination.GetByObjcetID_Class dataset_GetObjcetID = ParentGroup.rsGroup.GetCurrentRecord<PurchaseExamination.GetByObjcetID_Class>(0);
                    ACCOUNTANCYNAME.CalcValue = (dataset_GetObjcetID != null ? Globals.ToStringCore(dataset_GetObjcetID.Accountancyname) : "");
                    STORENAME.CalcValue = (dataset_GetObjcetID != null ? Globals.ToStringCore(dataset_GetObjcetID.Storename) : "");
                    TEXT1.CalcValue = TEXT1.Value;
                    STOCKACTIONID.CalcValue = (dataset_GetObjcetID != null ? Globals.ToStringCore(dataset_GetObjcetID.StockActionID) : "");
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1122.CalcValue = NewField1122.Value;
                    NewField12211.CalcValue = NewField12211.Value;
                    NewField12212.CalcValue = NewField12212.Value;
                    return new TTReportObject[] { ACCOUNTANCYNAME,STORENAME,TEXT1,STOCKACTIONID,NewField1,NewField2,NewField12,NewField121,NewField1121,NewField1122,NewField12211,NewField12212};
                }
            }
            public partial class PART1GroupFooter : TTReportSection
            {
                public MuvakkatMakbuzu MyParentReport
                {
                    get { return (MuvakkatMakbuzu)ParentReport; }
                }
                
                public TTReportField DESC;
                public TTReportField NewField3;
                public TTReportField NewField13;
                public TTReportField NewField122;
                public TTReportField NewField1123;
                public TTReportField NewField11211;
                public TTReportField NewField12213;
                public TTReportField NewField111221;
                public TTReportField NewField121221;
                public TTReportField NewField14;
                public TTReportField NewField4;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NUMBERTEXT;
                public TTReportField SUPPLIERNAME; 
                public PART1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 85;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    DESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 193, 7, false);
                    DESC.Name = "DESC";
                    DESC.FieldType = ReportFieldTypeEnum.ftExpression;
                    DESC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESC.Value = @"@""\\\\\\\\\\\\\\\\\\\\\ Yalnız "" + {@subgroupcount@} + ""("" + {%NUMBERTEXT%} + "") Kalemdir //////////////////////""";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 193, 15, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"MALZEME BERABERİNDE VERİLEN ÜRÜNLER / CİHAZLAR";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 15, 18, 25, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @"S.
No";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 15, 85, 25, false);
                    NewField122.Name = "NewField122";
                    NewField122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Bold = true;
                    NewField122.Value = @"Malzeme / Cihaz";

                    NewField1123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 15, 101, 25, false);
                    NewField1123.Name = "NewField1123";
                    NewField1123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1123.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1123.TextFont.Bold = true;
                    NewField1123.Value = @"Miktarı";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 15, 117, 25, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.Value = @"Ölçü 
Birimi";

                    NewField12213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 15, 145, 25, false);
                    NewField12213.Name = "NewField12213";
                    NewField12213.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12213.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12213.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12213.TextFont.Bold = true;
                    NewField12213.Value = @"Markası";

                    NewField111221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 15, 168, 25, false);
                    NewField111221.Name = "NewField111221";
                    NewField111221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111221.TextFont.Bold = true;
                    NewField111221.Value = @"Modeli";

                    NewField121221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 15, 193, 25, false);
                    NewField121221.Name = "NewField121221";
                    NewField121221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121221.TextFont.Bold = true;
                    NewField121221.Value = @"Seri No";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 25, 193, 51, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @"";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 59, 71, 64, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.Underline = true;
                    NewField4.Value = @"MAL SAYMANI";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 59, 131, 64, false);
                    NewField15.Name = "NewField15";
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.Underline = true;
                    NewField15.Value = @"MAL SORUMLUSU";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 59, 193, 64, false);
                    NewField16.Name = "NewField16";
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.Underline = true;
                    NewField16.Value = @"YÜKLENİCİ FİRMA";

                    NUMBERTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 2, 224, 7, false);
                    NUMBERTEXT.Name = "NUMBERTEXT";
                    NUMBERTEXT.Visible = EvetHayirEnum.ehHayir;
                    NUMBERTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    NUMBERTEXT.TextFormat = @"NUMBERTEXT";
                    NUMBERTEXT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NUMBERTEXT.Value = @"{@subgroupcount@}";

                    SUPPLIERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 64, 193, 74, false);
                    SUPPLIERNAME.Name = "SUPPLIERNAME";
                    SUPPLIERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIERNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUPPLIERNAME.MultiLine = EvetHayirEnum.ehEvet;
                    SUPPLIERNAME.WordBreak = EvetHayirEnum.ehEvet;
                    SUPPLIERNAME.Value = @"{#SUPPLIERNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseExamination.GetByObjcetID_Class dataset_GetObjcetID = ParentGroup.rsGroup.GetCurrentRecord<PurchaseExamination.GetByObjcetID_Class>(0);
                    NewField3.CalcValue = NewField3.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField1123.CalcValue = NewField1123.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField12213.CalcValue = NewField12213.Value;
                    NewField111221.CalcValue = NewField111221.Value;
                    NewField121221.CalcValue = NewField121221.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NUMBERTEXT.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    SUPPLIERNAME.CalcValue = (dataset_GetObjcetID != null ? Globals.ToStringCore(dataset_GetObjcetID.Suppliername) : "");
                    DESC.CalcValue = @"\\\\\\\\\\\\\\\\\\\\\ Yalnız " + (ParentGroup.SubGroupCount - 1).ToString() + "(" + MyParentReport.PART1.NUMBERTEXT.FormattedValue + ") Kalemdir //////////////////////";
                    return new TTReportObject[] { NewField3,NewField13,NewField122,NewField1123,NewField11211,NewField12213,NewField111221,NewField121221,NewField14,NewField4,NewField15,NewField16,NUMBERTEXT,SUPPLIERNAME,DESC};
                }
            }

        }

        public PART1Group PART1;

        public partial class MAINGroup : TTReportGroup
        {
            public MuvakkatMakbuzu MyParentReport
            {
                get { return (MuvakkatMakbuzu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField Counter { get {return Body().Counter;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField EXPIRATIONDATE { get {return Body().EXPIRATIONDATE;} }
            public TTReportField NewField111221 { get {return Body().NewField111221;} }
            public TTReportField NewField121221 { get {return Body().NewField121221;} }
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
                list[0] = new TTReportNqlData<StockAction.StockActionInDetailsReportQuery_Class>("StockActionInDetailsReportQuery", StockAction.StockActionInDetailsReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public MuvakkatMakbuzu MyParentReport
                {
                    get { return (MuvakkatMakbuzu)ParentReport; }
                }
                
                public TTReportField Counter;
                public TTReportField MATERIALNAME;
                public TTReportField AMOUNT;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField EXPIRATIONDATE;
                public TTReportField NewField111221;
                public TTReportField NewField121221; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    Counter = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 18, 5, false);
                    Counter.Name = "Counter";
                    Counter.DrawStyle = DrawStyleConstants.vbSolid;
                    Counter.FieldType = ReportFieldTypeEnum.ftVariable;
                    Counter.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Counter.MultiLine = EvetHayirEnum.ehEvet;
                    Counter.Value = @"{@counter@}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 0, 96, 5, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 96, 0, 112, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 0, 128, 5, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    EXPIRATIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 0, 149, 5, false);
                    EXPIRATIONDATE.Name = "EXPIRATIONDATE";
                    EXPIRATIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    EXPIRATIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXPIRATIONDATE.TextFormat = @"Short Date";
                    EXPIRATIONDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EXPIRATIONDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXPIRATIONDATE.Value = @"{#EXPIRATIONDATE#}";

                    NewField111221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 0, 168, 5, false);
                    NewField111221.Name = "NewField111221";
                    NewField111221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111221.Value = @"";

                    NewField121221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 0, 193, 5, false);
                    NewField121221.Name = "NewField121221";
                    NewField121221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121221.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockAction.StockActionInDetailsReportQuery_Class dataset_StockActionInDetailsReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockAction.StockActionInDetailsReportQuery_Class>(0);
                    Counter.CalcValue = ParentGroup.Counter.ToString();
                    MATERIALNAME.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.Materialname) : "");
                    AMOUNT.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.Amount) : "");
                    DISTRIBUTIONTYPE.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.DistributionType) : "");
                    EXPIRATIONDATE.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.ExpirationDate) : "");
                    NewField111221.CalcValue = NewField111221.Value;
                    NewField121221.CalcValue = NewField121221.Value;
                    return new TTReportObject[] { Counter,MATERIALNAME,AMOUNT,DISTRIBUTIONTYPE,EXPIRATIONDATE,NewField111221,NewField121221};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public MuvakkatMakbuzu()
        {
            PART1 = new PART1Group(this,"PART1");
            MAIN = new MAINGroup(PART1,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "İşlem No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("9b2306a7-2381-4099-8a37-63dbae04c00e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "MUVAKKATMAKBUZU";
            Caption = "Muvakkat Makbuzu";
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
            fd.TextFont.Name = "Arial";
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