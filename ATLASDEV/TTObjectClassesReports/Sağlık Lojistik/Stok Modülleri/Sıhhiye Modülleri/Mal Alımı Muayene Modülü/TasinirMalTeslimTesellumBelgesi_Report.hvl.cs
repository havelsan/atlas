
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
    public partial class TasinirMalTeslimTesellumBelgesi : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PART1Group : TTReportGroup
        {
            public TasinirMalTeslimTesellumBelgesi MyParentReport
            {
                get { return (TasinirMalTeslimTesellumBelgesi)ParentReport; }
            }

            new public PART1GroupHeader Header()
            {
                return (PART1GroupHeader)_header;
            }

            new public PART1GroupFooter Footer()
            {
                return (PART1GroupFooter)_footer;
            }

            public TTReportField TEXT1 { get {return Header().TEXT1;} }
            public TTReportField CONFIRMNOANDDATE { get {return Header().CONFIRMNOANDDATE;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1122 { get {return Header().NewField1122;} }
            public TTReportField NewField12211 { get {return Header().NewField12211;} }
            public TTReportField NewField12212 { get {return Header().NewField12212;} }
            public TTReportField DECISIONNOANDDATE { get {return Header().DECISIONNOANDDATE;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField PROCUREMENTTYPE { get {return Header().PROCUREMENTTYPE;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField SUPPLIER { get {return Header().SUPPLIER;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField TEMPORARYDELIVERYDATE { get {return Header().TEMPORARYDELIVERYDATE;} }
            public TTReportField NewField113 { get {return Header().NewField113;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField DESC { get {return Footer().DESC;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField NUMBERTEXT { get {return Footer().NUMBERTEXT;} }
            public TTReportField NewField151 { get {return Footer().NewField151;} }
            public TTReportField NewField152 { get {return Footer().NewField152;} }
            public TTReportField NewField1151 { get {return Footer().NewField1151;} }
            public TTReportField NewField153 { get {return Footer().NewField153;} }
            public TTReportField NewField1152 { get {return Footer().NewField1152;} }
            public TTReportField NewField1251 { get {return Footer().NewField1251;} }
            public TTReportField NewField11511 { get {return Footer().NewField11511;} }
            public TTReportField NewField14 { get {return Footer().NewField14;} }
            public TTReportField NewField141 { get {return Footer().NewField141;} }
            public TTReportField NewField1141 { get {return Footer().NewField1141;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
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
                public TasinirMalTeslimTesellumBelgesi MyParentReport
                {
                    get { return (TasinirMalTeslimTesellumBelgesi)ParentReport; }
                }
                
                public TTReportField TEXT1;
                public TTReportField CONFIRMNOANDDATE;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField NewField1121;
                public TTReportField NewField1122;
                public TTReportField NewField12211;
                public TTReportField NewField12212;
                public TTReportField DECISIONNOANDDATE;
                public TTReportField NewField11;
                public TTReportField PROCUREMENTTYPE;
                public TTReportField NewField111;
                public TTReportField SUPPLIER;
                public TTReportField NewField112;
                public TTReportField TEMPORARYDELIVERYDATE;
                public TTReportField NewField113;
                public TTReportField NewField122; 
                public PART1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 65;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    TEXT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 13, 193, 18, false);
                    TEXT1.Name = "TEXT1";
                    TEXT1.DrawStyle = DrawStyleConstants.vbSolid;
                    TEXT1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEXT1.MultiLine = EvetHayirEnum.ehEvet;
                    TEXT1.TextFont.Size = 11;
                    TEXT1.TextFont.Bold = true;
                    TEXT1.Value = @"TAŞINIR MAL GEÇİCİ TESLİM TESELLÜM BELGESİ";

                    CONFIRMNOANDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 18, 193, 24, false);
                    CONFIRMNOANDDATE.Name = "CONFIRMNOANDDATE";
                    CONFIRMNOANDDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    CONFIRMNOANDDATE.FieldType = ReportFieldTypeEnum.ftExpression;
                    CONFIRMNOANDDATE.Value = @"{#CONFIRMNO#} + ""-"" + {#CONFIRMDATE#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 18, 68, 24, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"Onay Belgesi Tarih ve Numarası";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 48, 18, 64, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"S.
Nu";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 55, 123, 64, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"Cins ve Özellikleri";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 55, 139, 64, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.Value = @"Ölçü 
Birimi";

                    NewField1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 55, 153, 64, false);
                    NewField1122.Name = "NewField1122";
                    NewField1122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1122.TextFont.Bold = true;
                    NewField1122.Value = @"Miktarı";

                    NewField12211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 55, 45, 64, false);
                    NewField12211.Name = "NewField12211";
                    NewField12211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12211.TextFont.Bold = true;
                    NewField12211.Value = @"Stok Nu.";

                    NewField12212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 48, 193, 64, false);
                    NewField12212.Name = "NewField12212";
                    NewField12212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12212.TextFont.Bold = true;
                    NewField12212.Value = @"Açıklamalar";

                    DECISIONNOANDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 24, 193, 30, false);
                    DECISIONNOANDDATE.Name = "DECISIONNOANDDATE";
                    DECISIONNOANDDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    DECISIONNOANDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DECISIONNOANDDATE.Value = @"";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 24, 68, 30, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"İhale Karar Tarihi ve Numarası";

                    PROCUREMENTTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 30, 193, 36, false);
                    PROCUREMENTTYPE.Name = "PROCUREMENTTYPE";
                    PROCUREMENTTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    PROCUREMENTTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCUREMENTTYPE.Value = @"{#PURCHASETYPEDEFINITION#}";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 30, 68, 36, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @"Alım Şekli";

                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 36, 193, 42, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.DrawStyle = DrawStyleConstants.vbSolid;
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIER.Value = @"{#SUPPLIERNAME#}";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 36, 68, 42, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.TextFont.Bold = true;
                    NewField112.Value = @"Firma Adı";

                    TEMPORARYDELIVERYDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 42, 193, 48, false);
                    TEMPORARYDELIVERYDATE.Name = "TEMPORARYDELIVERYDATE";
                    TEMPORARYDELIVERYDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    TEMPORARYDELIVERYDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEMPORARYDELIVERYDATE.TextFormat = @"dd/MM/yyyy";
                    TEMPORARYDELIVERYDATE.Value = @"{#TEMPORARYDELIVERYDATE#}";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 42, 68, 48, false);
                    NewField113.Name = "NewField113";
                    NewField113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113.TextFont.Bold = true;
                    NewField113.Value = @"Malzemenin Teslim Tarihi";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 48, 153, 55, false);
                    NewField122.Name = "NewField122";
                    NewField122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Bold = true;
                    NewField122.Value = @"Taşınır Malın";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseExamination.GetByObjcetID_Class dataset_GetObjcetID = ParentGroup.rsGroup.GetCurrentRecord<PurchaseExamination.GetByObjcetID_Class>(0);
                    TEXT1.CalcValue = TEXT1.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1122.CalcValue = NewField1122.Value;
                    NewField12211.CalcValue = NewField12211.Value;
                    NewField12212.CalcValue = NewField12212.Value;
                    DECISIONNOANDDATE.CalcValue = @"";
                    NewField11.CalcValue = NewField11.Value;
                    PROCUREMENTTYPE.CalcValue = (dataset_GetObjcetID != null ? Globals.ToStringCore(dataset_GetObjcetID.Purchasetypedefinition) : "");
                    NewField111.CalcValue = NewField111.Value;
                    SUPPLIER.CalcValue = (dataset_GetObjcetID != null ? Globals.ToStringCore(dataset_GetObjcetID.Suppliername) : "");
                    NewField112.CalcValue = NewField112.Value;
                    TEMPORARYDELIVERYDATE.CalcValue = (dataset_GetObjcetID != null ? Globals.ToStringCore(dataset_GetObjcetID.TemporaryDeliveryDate) : "");
                    NewField113.CalcValue = NewField113.Value;
                    NewField122.CalcValue = NewField122.Value;
                    CONFIRMNOANDDATE.CalcValue = (dataset_GetObjcetID != null ? Globals.ToStringCore(dataset_GetObjcetID.ConfirmNO) : "") + "-" + (dataset_GetObjcetID != null ? Globals.ToStringCore(dataset_GetObjcetID.ConfirmDate) : "");
                    return new TTReportObject[] { TEXT1,NewField1,NewField2,NewField12,NewField1121,NewField1122,NewField12211,NewField12212,DECISIONNOANDDATE,NewField11,PROCUREMENTTYPE,NewField111,SUPPLIER,NewField112,TEMPORARYDELIVERYDATE,NewField113,NewField122,CONFIRMNOANDDATE};
                }
            }
            public partial class PART1GroupFooter : TTReportSection
            {
                public TasinirMalTeslimTesellumBelgesi MyParentReport
                {
                    get { return (TasinirMalTeslimTesellumBelgesi)ParentReport; }
                }
                
                public TTReportField DESC;
                public TTReportField NewField4;
                public TTReportField NewField15;
                public TTReportField NUMBERTEXT;
                public TTReportField NewField151;
                public TTReportField NewField152;
                public TTReportField NewField1151;
                public TTReportField NewField153;
                public TTReportField NewField1152;
                public TTReportField NewField1251;
                public TTReportField NewField11511;
                public TTReportField NewField14;
                public TTReportField NewField141;
                public TTReportField NewField1141;
                public TTReportShape NewLine1; 
                public PART1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 50;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    DESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 2, 193, 7, false);
                    DESC.Name = "DESC";
                    DESC.FieldType = ReportFieldTypeEnum.ftExpression;
                    DESC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESC.Value = @"{@subgroupcount@} + "" ("" + {%NUMBERTEXT%} + "") kalem Malzeme muayenesi yapılmak üzere teslim alınmıştır.""";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 9, 107, 14, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.Underline = true;
                    NewField4.Value = @"Teslim Alan";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 21, 34, 26, false);
                    NewField15.Name = "NewField15";
                    NewField15.Value = @"İmza";

                    NUMBERTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 2, 224, 7, false);
                    NUMBERTEXT.Name = "NUMBERTEXT";
                    NUMBERTEXT.Visible = EvetHayirEnum.ehHayir;
                    NUMBERTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    NUMBERTEXT.TextFormat = @"NUMBERTEXT";
                    NUMBERTEXT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NUMBERTEXT.Value = @"{@subgroupcount@}";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 29, 34, 34, false);
                    NewField151.Name = "NewField151";
                    NewField151.Value = @"Adı ve Soyadı";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 34, 34, 39, false);
                    NewField152.Name = "NewField152";
                    NewField152.Value = @"Rütbesi";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 39, 34, 44, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.Value = @"Görevi";

                    NewField153 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 21, 37, 26, false);
                    NewField153.Name = "NewField153";
                    NewField153.Value = @":";

                    NewField1152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 29, 37, 34, false);
                    NewField1152.Name = "NewField1152";
                    NewField1152.Value = @":";

                    NewField1251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 34, 37, 39, false);
                    NewField1251.Name = "NewField1251";
                    NewField1251.Value = @":";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 39, 37, 44, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.Value = @":";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 14, 98, 19, false);
                    NewField14.Name = "NewField14";
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @"Taşınır Mal Sorumlusu";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 14, 145, 19, false);
                    NewField141.Name = "NewField141";
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.TextFont.Bold = true;
                    NewField141.Value = @"Taşınır Mal Saymanı";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 14, 193, 19, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.Value = @"Firma Yetkilisi";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 193, 0, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseExamination.GetByObjcetID_Class dataset_GetObjcetID = ParentGroup.rsGroup.GetCurrentRecord<PurchaseExamination.GetByObjcetID_Class>(0);
                    NewField4.CalcValue = NewField4.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NUMBERTEXT.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    NewField151.CalcValue = NewField151.Value;
                    NewField152.CalcValue = NewField152.Value;
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField153.CalcValue = NewField153.Value;
                    NewField1152.CalcValue = NewField1152.Value;
                    NewField1251.CalcValue = NewField1251.Value;
                    NewField11511.CalcValue = NewField11511.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    DESC.CalcValue = (ParentGroup.SubGroupCount - 1).ToString() + " (" + MyParentReport.PART1.NUMBERTEXT.FormattedValue + ") kalem Malzeme muayenesi yapılmak üzere teslim alınmıştır.";
                    return new TTReportObject[] { NewField4,NewField15,NUMBERTEXT,NewField151,NewField152,NewField1151,NewField153,NewField1152,NewField1251,NewField11511,NewField14,NewField141,NewField1141,DESC};
                }
            }

        }

        public PART1Group PART1;

        public partial class MAINGroup : TTReportGroup
        {
            public TasinirMalTeslimTesellumBelgesi MyParentReport
            {
                get { return (TasinirMalTeslimTesellumBelgesi)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField Counter { get {return Body().Counter;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField NewField121221 { get {return Body().NewField121221;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine15 { get {return Body().NewLine15;} }
            public TTReportShape NewLine16 { get {return Body().NewLine16;} }
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
                public TasinirMalTeslimTesellumBelgesi MyParentReport
                {
                    get { return (TasinirMalTeslimTesellumBelgesi)ParentReport; }
                }
                
                public TTReportField Counter;
                public TTReportField MATERIALNAME;
                public TTReportField AMOUNT;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField NATOSTOCKNO;
                public TTReportField NewField121221;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    Counter = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 18, 5, false);
                    Counter.Name = "Counter";
                    Counter.DrawStyle = DrawStyleConstants.vbSolid;
                    Counter.FieldType = ReportFieldTypeEnum.ftVariable;
                    Counter.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Counter.MultiLine = EvetHayirEnum.ehEvet;
                    Counter.TextFont.Size = 9;
                    Counter.Value = @"{@counter@}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 0, 123, 5, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.TextFont.Size = 9;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 0, 153, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.Size = 9;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 0, 139, 5, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTRIBUTIONTYPE.TextFont.Size = 9;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 0, 45, 5, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.TextFormat = @"Short Date";
                    NATOSTOCKNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NATOSTOCKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NATOSTOCKNO.TextFont.Size = 9;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    NewField121221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 0, 193, 5, false);
                    NewField121221.Name = "NewField121221";
                    NewField121221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121221.TextFont.Size = 9;
                    NewField121221.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 3, 10, 18, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 5, 18, 18, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine2.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 45, 5, 45, 18, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 123, 5, 123, 18, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 139, 5, 139, 18, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 153, 5, 153, 18, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine15.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 193, 5, 193, 18, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine16.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockAction.StockActionInDetailsReportQuery_Class dataset_StockActionInDetailsReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockAction.StockActionInDetailsReportQuery_Class>(0);
                    Counter.CalcValue = ParentGroup.Counter.ToString();
                    MATERIALNAME.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.Materialname) : "");
                    AMOUNT.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.Amount) : "");
                    DISTRIBUTIONTYPE.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.DistributionType) : "");
                    NATOSTOCKNO.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.NATOStockNO) : "");
                    NewField121221.CalcValue = NewField121221.Value;
                    return new TTReportObject[] { Counter,MATERIALNAME,AMOUNT,DISTRIBUTIONTYPE,NATOSTOCKNO,NewField121221};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public TasinirMalTeslimTesellumBelgesi()
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
            Name = "TASINIRMALTESLIMTESELLUMBELGESI";
            Caption = "Taşınır Mal Teslim Tesellüm Belgesi";
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