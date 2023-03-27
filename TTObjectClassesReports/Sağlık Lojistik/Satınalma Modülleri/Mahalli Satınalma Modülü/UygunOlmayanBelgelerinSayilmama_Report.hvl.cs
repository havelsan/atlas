
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
    /// Uygun Olmayan Belgelerin Uygun Sayılmama Nedenlerine İlişkin Tutanak
    /// </summary>
    public partial class UygunOlmayanBelgelerinSayilmama : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public UygunOlmayanBelgelerinSayilmama MyParentReport
            {
                get { return (UygunOlmayanBelgelerinSayilmama)ParentReport; }
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
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField LOGO11111111211 { get {return Header().LOGO11111111211;} }
            public TTReportField NewField9_1 { get {return Header().NewField9_1;} }
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
                list[0] = new TTReportNqlData<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>("PurchaseProjectGlobalReportNQL", PurchaseProject.PurchaseProjectGlobalReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public UygunOlmayanBelgelerinSayilmama MyParentReport
                {
                    get { return (UygunOlmayanBelgelerinSayilmama)ParentReport; }
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
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO11111111211;
                public TTReportField NewField9_1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 78;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 40, 65, 45, false);
                    NewField2.Name = "NewField2";
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"İhale Kayıt Numarası";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 40, 66, 45, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField.TextFont.Name = "Arial";
                    NewField.TextFont.Bold = true;
                    NewField.Value = @":";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 45, 65, 50, false);
                    NewField3.Name = "NewField3";
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"İdarenin Adı";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 45, 66, 50, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @":";

                    IHALEKAYITNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 40, 154, 45, false);
                    IHALEKAYITNO.Name = "IHALEKAYITNO";
                    IHALEKAYITNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    IHALEKAYITNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IHALEKAYITNO.TextFont.Name = "Arial";
                    IHALEKAYITNO.Value = @"{#KIKTENDERREGISTERNO#}";

                    IDAREADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 45, 257, 50, false);
                    IDAREADI.Name = "IDAREADI";
                    IDAREADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    IDAREADI.CaseFormat = CaseFormatEnum.fcTitleCase;
                    IDAREADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IDAREADI.TextFont.Name = "Arial";
                    IDAREADI.Value = @"{#RESPONSIBLEPROCUREMENTUNITDEF#}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 50, 65, 55, false);
                    NewField5.Name = "NewField5";
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @"İşin Adı";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 50, 66, 55, false);
                    NewField6.Name = "NewField6";
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Bold = true;
                    NewField6.Value = @":";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 55, 65, 60, false);
                    NewField7.Name = "NewField7";
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Bold = true;
                    NewField7.Value = @"Tutanağın Doldurulduğu Tarih ve Saat";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 55, 154, 60, false);
                    DATE.Name = "DATE";
                    DATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATE.TextFont.Name = "Arial";
                    DATE.Value = @"_ _ /_ _ /_ _ _ _ ............................. günü, saat _ _:_ _";

                    ISINADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 50, 257, 55, false);
                    ISINADI.Name = "ISINADI";
                    ISINADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISINADI.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ISINADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISINADI.TextFont.Name = "Arial";
                    ISINADI.Value = @"{#ACTDEFINE#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 55, 66, 60, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @":";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 15, 257, 38, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Size = 12;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    LOGO11111111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 40, 35, false);
                    LOGO11111111211.Name = "LOGO11111111211";
                    LOGO11111111211.Visible = EvetHayirEnum.ehHayir;
                    LOGO11111111211.TextFont.CharSet = 1;
                    LOGO11111111211.Value = @"LOGO";

                    NewField9_1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 70, 257, 76, false);
                    NewField9_1.Name = "NewField9_1";
                    NewField9_1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField9_1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9_1.TextFont.Name = "Arial";
                    NewField9_1.TextFont.Size = 11;
                    NewField9_1.TextFont.Bold = true;
                    NewField9_1.Value = @"UYGUN OLMAYAN BELGELERİN UYGUN SAYILMAMA GEREKÇELERİNE İLİŞKİN TUTANAK";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectGlobalReportNQL_Class dataset_PurchaseProjectGlobalReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>(0);
                    NewField2.CalcValue = NewField2.Value;
                    NewField.CalcValue = NewField.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    IHALEKAYITNO.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.KIKTenderRegisterNO) : "");
                    IDAREADI.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Responsibleprocurementunitdef) : "");
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    DATE.CalcValue = DATE.Value;
                    ISINADI.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ActDefine) : "");
                    NewField1.CalcValue = NewField1.Value;
                    LOGO11111111211.CalcValue = LOGO11111111211.Value;
                    NewField9_1.CalcValue = NewField9_1.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField2,NewField,NewField3,NewField4,IHALEKAYITNO,IDAREADI,NewField5,NewField6,NewField7,DATE,ISINADI,NewField1,LOGO11111111211,NewField9_1,XXXXXXBASLIK};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public UygunOlmayanBelgelerinSayilmama MyParentReport
                {
                    get { return (UygunOlmayanBelgelerinSayilmama)ParentReport; }
                }
                
                public TTReportField PROJECTNO; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
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
                    PROJECTNO.Value = @" Proje Nu. : {#PURCHASEPROJECTNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectGlobalReportNQL_Class dataset_PurchaseProjectGlobalReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>(0);
                    PROJECTNO.CalcValue = @" Proje Nu. : " + (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.PurchaseProjectNO) : "");
                    return new TTReportObject[] { PROJECTNO};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTFGroup : TTReportGroup
        {
            public UygunOlmayanBelgelerinSayilmama MyParentReport
            {
                get { return (UygunOlmayanBelgelerinSayilmama)ParentReport; }
            }

            new public PARTFGroupHeader Header()
            {
                return (PARTFGroupHeader)_header;
            }

            new public PARTFGroupFooter Footer()
            {
                return (PARTFGroupFooter)_footer;
            }

            public TTReportField NewField7_ { get {return Header().NewField7_;} }
            public TTReportField NewField_ { get {return Header().NewField_;} }
            public TTReportField NewField6_ { get {return Header().NewField6_;} }
            public TTReportField NewField8_ { get {return Header().NewField8_;} }
            public PARTFGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTFGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTFGroupHeader(this);
                _footer = new PARTFGroupFooter(this);

            }

            public partial class PARTFGroupHeader : TTReportSection
            {
                public UygunOlmayanBelgelerinSayilmama MyParentReport
                {
                    get { return (UygunOlmayanBelgelerinSayilmama)ParentReport; }
                }
                
                public TTReportField NewField7_;
                public TTReportField NewField_;
                public TTReportField NewField6_;
                public TTReportField NewField8_; 
                public PARTFGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 8;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField7_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 1, 87, 6, false);
                    NewField7_.Name = "NewField7_";
                    NewField7_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7_.TextFont.Name = "Arial";
                    NewField7_.TextFont.Bold = true;
                    NewField7_.Value = @"ADAY / İSTEKLİ";

                    NewField_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 15, 6, false);
                    NewField_.Name = "NewField_";
                    NewField_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField_.TextFont.Name = "Arial";
                    NewField_.TextFont.Bold = true;
                    NewField_.Value = @"SIRA NU.";

                    NewField6_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 1, 145, 6, false);
                    NewField6_.Name = "NewField6_";
                    NewField6_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6_.TextFont.Name = "Arial";
                    NewField6_.TextFont.Bold = true;
                    NewField6_.Value = @"BELGE";

                    NewField8_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 1, 257, 6, false);
                    NewField8_.Name = "NewField8_";
                    NewField8_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField8_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField8_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8_.TextFont.Name = "Arial";
                    NewField8_.TextFont.Bold = true;
                    NewField8_.Value = @"UYGUN SAYILMAMA GEREKÇESİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField7_.CalcValue = NewField7_.Value;
                    NewField_.CalcValue = NewField_.Value;
                    NewField6_.CalcValue = NewField6_.Value;
                    NewField8_.CalcValue = NewField8_.Value;
                    return new TTReportObject[] { NewField7_,NewField_,NewField6_,NewField8_};
                }
            }
            public partial class PARTFGroupFooter : TTReportSection
            {
                public UygunOlmayanBelgelerinSayilmama MyParentReport
                {
                    get { return (UygunOlmayanBelgelerinSayilmama)ParentReport; }
                }
                 
                public PARTFGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTFGroup PARTF;

        public partial class PARTEGroup : TTReportGroup
        {
            public UygunOlmayanBelgelerinSayilmama MyParentReport
            {
                get { return (UygunOlmayanBelgelerinSayilmama)ParentReport; }
            }

            new public PARTEGroupBody Body()
            {
                return (PARTEGroupBody)_body;
            }
            public TTReportField COUNTER { get {return Body().COUNTER;} }
            public TTReportField SUPPLIER { get {return Body().SUPPLIER;} }
            public TTReportField DOCNAME { get {return Body().DOCNAME;} }
            public TTReportField DENYDESC { get {return Body().DENYDESC;} }
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
                list[0] = new TTReportNqlData<PurchasingDocumentState.GetUnEligibleDocuments_Class>("GetUnEligibleDocuments", PurchasingDocumentState.GetUnEligibleDocuments((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public UygunOlmayanBelgelerinSayilmama MyParentReport
                {
                    get { return (UygunOlmayanBelgelerinSayilmama)ParentReport; }
                }
                
                public TTReportField COUNTER;
                public TTReportField SUPPLIER;
                public TTReportField DOCNAME;
                public TTReportField DENYDESC; 
                public PARTEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 15;
                    RepeatCount = 0;
                    
                    COUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 15, 14, false);
                    COUNTER.Name = "COUNTER";
                    COUNTER.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COUNTER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COUNTER.TextFont.Name = "Arial";
                    COUNTER.Value = @"{@counter@}";

                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 87, 14, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.DrawStyle = DrawStyleConstants.vbSolid;
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER.MultiLine = EvetHayirEnum.ehEvet;
                    SUPPLIER.WordBreak = EvetHayirEnum.ehEvet;
                    SUPPLIER.TextFont.Name = "Arial";
                    SUPPLIER.Value = @"{#SUPPLIER#}";

                    DOCNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 0, 145, 14, false);
                    DOCNAME.Name = "DOCNAME";
                    DOCNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    DOCNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOCNAME.MultiLine = EvetHayirEnum.ehEvet;
                    DOCNAME.WordBreak = EvetHayirEnum.ehEvet;
                    DOCNAME.TextFont.Name = "Arial";
                    DOCNAME.Value = @"{#DOCNAME#}";

                    DENYDESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 257, 14, false);
                    DENYDESC.Name = "DENYDESC";
                    DENYDESC.DrawStyle = DrawStyleConstants.vbSolid;
                    DENYDESC.FieldType = ReportFieldTypeEnum.ftVariable;
                    DENYDESC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DENYDESC.MultiLine = EvetHayirEnum.ehEvet;
                    DENYDESC.WordBreak = EvetHayirEnum.ehEvet;
                    DENYDESC.TextFont.Name = "Arial";
                    DENYDESC.Value = @"{#DENYDESC#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchasingDocumentState.GetUnEligibleDocuments_Class dataset_GetUnEligibleDocuments = ParentGroup.rsGroup.GetCurrentRecord<PurchasingDocumentState.GetUnEligibleDocuments_Class>(0);
                    COUNTER.CalcValue = ParentGroup.Counter.ToString();
                    SUPPLIER.CalcValue = (dataset_GetUnEligibleDocuments != null ? Globals.ToStringCore(dataset_GetUnEligibleDocuments.Supplier) : "");
                    DOCNAME.CalcValue = (dataset_GetUnEligibleDocuments != null ? Globals.ToStringCore(dataset_GetUnEligibleDocuments.DocName) : "");
                    DENYDESC.CalcValue = (dataset_GetUnEligibleDocuments != null ? Globals.ToStringCore(dataset_GetUnEligibleDocuments.DenyDesc) : "");
                    return new TTReportObject[] { COUNTER,SUPPLIER,DOCNAME,DENYDESC};
                }
            }

        }

        public PARTEGroup PARTE;

        public partial class PARTAGroup : TTReportGroup
        {
            public UygunOlmayanBelgelerinSayilmama MyParentReport
            {
                get { return (UygunOlmayanBelgelerinSayilmama)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField PROJECTNO141 { get {return Header().PROJECTNO141;} }
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
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public UygunOlmayanBelgelerinSayilmama MyParentReport
                {
                    get { return (UygunOlmayanBelgelerinSayilmama)ParentReport; }
                }
                
                public TTReportField PROJECTNO141; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PROJECTNO141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 257, 10, false);
                    PROJECTNO141.Name = "PROJECTNO141";
                    PROJECTNO141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROJECTNO141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO141.TextFont.Name = "Arial";
                    PROJECTNO141.TextFont.Bold = true;
                    PROJECTNO141.Value = @"İHALE KOMİSYONU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PROJECTNO141.CalcValue = PROJECTNO141.Value;
                    return new TTReportObject[] { PROJECTNO141};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public UygunOlmayanBelgelerinSayilmama MyParentReport
                {
                    get { return (UygunOlmayanBelgelerinSayilmama)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTCGroup : TTReportGroup
        {
            public UygunOlmayanBelgelerinSayilmama MyParentReport
            {
                get { return (UygunOlmayanBelgelerinSayilmama)ParentReport; }
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
                public UygunOlmayanBelgelerinSayilmama MyParentReport
                {
                    get { return (UygunOlmayanBelgelerinSayilmama)ParentReport; }
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
                    
                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 16, 53, 20, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NAMESURNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME.NoClip = EvetHayirEnum.ehEvet;
                    NAMESURNAME.TextFont.Name = "Arial";
                    NAMESURNAME.Value = @"{#NAMESURNAME#}";

                    HOSPFUNC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 21, 53, 25, false);
                    HOSPFUNC.Name = "HOSPFUNC";
                    HOSPFUNC.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC.ObjectDefName = "UserTitleEnum";
                    HOSPFUNC.DataMember = "DISPLAYTEXT";
                    HOSPFUNC.TextFont.Name = "Arial";
                    HOSPFUNC.Value = @"{#HOSPFUNC#}";

                    COMFUNC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 2, 53, 6, false);
                    COMFUNC.Name = "COMFUNC";
                    COMFUNC.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC.CaseFormat = CaseFormatEnum.fcUpperCase;
                    COMFUNC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC.ObjectDefName = "CommisionMemberDutyEnum";
                    COMFUNC.DataMember = "DISPLAYTEXT";
                    COMFUNC.TextFont.Name = "Arial";
                    COMFUNC.Value = @"{#COMFUNC#}";

                    RANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 7, 53, 15, false);
                    RANK.Name = "RANK";
                    RANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    RANK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RANK.MultiLine = EvetHayirEnum.ehEvet;
                    RANK.WordBreak = EvetHayirEnum.ehEvet;
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

        public UygunOlmayanBelgelerinSayilmama()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTF = new PARTFGroup(PARTB,"PARTF");
            PARTE = new PARTEGroup(PARTF,"PARTE");
            PARTA = new PARTAGroup(PARTF,"PARTA");
            PARTC = new PARTCGroup(PARTA,"PARTC");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Proje No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "UYGUNOLMAYANBELGELERINSAYILMAMA";
            Caption = "Uygun Olmayan Belgelerin Uygun Sayılmama Nedenlerine İlişkin Tutanak";
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