
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
    /// İsteklilerce Teklif Edilen Fiyatlar
    /// </summary>
    public partial class IsteklilerceTeklifEdilenFiyatlar : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public IsteklilerceTeklifEdilenFiyatlar MyParentReport
            {
                get { return (IsteklilerceTeklifEdilenFiyatlar)ParentReport; }
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
            public TTReportField LOGO11111111 { get {return Header().LOGO11111111;} }
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
                public IsteklilerceTeklifEdilenFiyatlar MyParentReport
                {
                    get { return (IsteklilerceTeklifEdilenFiyatlar)ParentReport; }
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
                public TTReportField LOGO11111111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 64;
                    IsAligned = EvetHayirEnum.ehEvet;
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
                    IHALEKAYITNO.TextFont.Name = "Arial";
                    IHALEKAYITNO.Value = @"{#KIKTENDERREGISTERNO#}";

                    IDAREADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 45, 257, 50, false);
                    IDAREADI.Name = "IDAREADI";
                    IDAREADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    IDAREADI.CaseFormat = CaseFormatEnum.fcTitleCase;
                    IDAREADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    IDAREADI.WordBreak = EvetHayirEnum.ehEvet;
                    IDAREADI.TextFont.Name = "Arial";
                    IDAREADI.Value = @"{#RESPONSIBLEPROCUREMENTUNITDEF#}";

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
                    ISINADI.TextFont.Name = "Arial";
                    ISINADI.Value = @"{#ACTDEFINE#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 55, 65, 60, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @":";

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

                    LOGO11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 40, 35, false);
                    LOGO11111111.Name = "LOGO11111111";
                    LOGO11111111.Visible = EvetHayirEnum.ehHayir;
                    LOGO11111111.TextFont.CharSet = 1;
                    LOGO11111111.Value = @"LOGO";

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
                    LOGO11111111.CalcValue = LOGO11111111.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField2,NewField,NewField3,NewField4,IHALEKAYITNO,IDAREADI,NewField5,NewField6,NewField7,DATE,ISINADI,NewField1,LOGO11111111,XXXXXXBASLIK};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public IsteklilerceTeklifEdilenFiyatlar MyParentReport
                {
                    get { return (IsteklilerceTeklifEdilenFiyatlar)ParentReport; }
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
                    PROJECTNO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectGlobalReportNQL_Class dataset_PurchaseProjectGlobalReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>(0);
                    PROJECTNO.CalcValue = @"";
                    return new TTReportObject[] { PROJECTNO};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    string objectID = ((IsteklilerceTeklifEdilenFiyatlar)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            PurchaseProject pp = (PurchaseProject)ctx.GetObject(new Guid(objectID), typeof(PurchaseProject));
            if (pp != null)
                PROJECTNO.CalcValue = " Proje Nu. : " + pp.PurchaseProjectNO.ToString();
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTFGroup : TTReportGroup
        {
            public IsteklilerceTeklifEdilenFiyatlar MyParentReport
            {
                get { return (IsteklilerceTeklifEdilenFiyatlar)ParentReport; }
            }

            new public PARTFGroupHeader Header()
            {
                return (PARTFGroupHeader)_header;
            }

            new public PARTFGroupFooter Footer()
            {
                return (PARTFGroupFooter)_footer;
            }

            public TTReportField NewField9_ { get {return Header().NewField9_;} }
            public TTReportField NewField7_ { get {return Header().NewField7_;} }
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
                public IsteklilerceTeklifEdilenFiyatlar MyParentReport
                {
                    get { return (IsteklilerceTeklifEdilenFiyatlar)ParentReport; }
                }
                
                public TTReportField NewField9_;
                public TTReportField NewField7_;
                public TTReportField NewField6_;
                public TTReportField NewField8_; 
                public PARTFGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 23;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField9_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 3, 257, 9, false);
                    NewField9_.Name = "NewField9_";
                    NewField9_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField9_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField9_.TextFont.Name = "Arial";
                    NewField9_.TextFont.Size = 11;
                    NewField9_.TextFont.Bold = true;
                    NewField9_.Value = @"İSTEKLİLERCE TEKLİF EDİLEN FİYATLAR";

                    NewField7_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 14, 76, 22, false);
                    NewField7_.Name = "NewField7_";
                    NewField7_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7_.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField7_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7_.TextFont.Name = "Arial";
                    NewField7_.TextFont.Bold = true;
                    NewField7_.Value = @"İsteklinin Adı";

                    NewField6_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 14, 134, 22, false);
                    NewField6_.Name = "NewField6_";
                    NewField6_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6_.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField6_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6_.TextFont.Name = "Arial";
                    NewField6_.TextFont.Bold = true;
                    NewField6_.Value = @"Rakam İle";

                    NewField8_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 14, 257, 22, false);
                    NewField8_.Name = "NewField8_";
                    NewField8_.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField8_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField8_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8_.TextFont.Name = "Arial";
                    NewField8_.TextFont.Bold = true;
                    NewField8_.Value = @"Yazı ile";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField9_.CalcValue = NewField9_.Value;
                    NewField7_.CalcValue = NewField7_.Value;
                    NewField6_.CalcValue = NewField6_.Value;
                    NewField8_.CalcValue = NewField8_.Value;
                    return new TTReportObject[] { NewField9_,NewField7_,NewField6_,NewField8_};
                }
            }
            public partial class PARTFGroupFooter : TTReportSection
            {
                public IsteklilerceTeklifEdilenFiyatlar MyParentReport
                {
                    get { return (IsteklilerceTeklifEdilenFiyatlar)ParentReport; }
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
            public IsteklilerceTeklifEdilenFiyatlar MyParentReport
            {
                get { return (IsteklilerceTeklifEdilenFiyatlar)ParentReport; }
            }

            new public PARTEGroupBody Body()
            {
                return (PARTEGroupBody)_body;
            }
            public TTReportField SUPPLIER { get {return Body().SUPPLIER;} }
            public TTReportField TOTALPROPOSALPRICE { get {return Body().TOTALPROPOSALPRICE;} }
            public TTReportField TOTALPROPOSALPRICETEXT { get {return Body().TOTALPROPOSALPRICETEXT;} }
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
                list[0] = new TTReportNqlData<ProposalDetail.GetProposalledTotalPrices_Class>("GetProposalledTotalPrices", ProposalDetail.GetProposalledTotalPrices((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public IsteklilerceTeklifEdilenFiyatlar MyParentReport
                {
                    get { return (IsteklilerceTeklifEdilenFiyatlar)ParentReport; }
                }
                
                public TTReportField SUPPLIER;
                public TTReportField TOTALPROPOSALPRICE;
                public TTReportField TOTALPROPOSALPRICETEXT;
                public TTReportField Count; 
                public PARTEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 76, 5, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.DrawStyle = DrawStyleConstants.vbSolid;
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER.TextFont.Name = "Arial";
                    SUPPLIER.Value = @"{#SUPPLIER#}";

                    TOTALPROPOSALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 0, 134, 5, false);
                    TOTALPROPOSALPRICE.Name = "TOTALPROPOSALPRICE";
                    TOTALPROPOSALPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALPROPOSALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPROPOSALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPROPOSALPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALPROPOSALPRICE.TextFont.Name = "Arial";
                    TOTALPROPOSALPRICE.Value = @"{#TOTALPROPOSALPRICE#}";

                    TOTALPROPOSALPRICETEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 0, 257, 5, false);
                    TOTALPROPOSALPRICETEXT.Name = "TOTALPROPOSALPRICETEXT";
                    TOTALPROPOSALPRICETEXT.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALPROPOSALPRICETEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPROPOSALPRICETEXT.TextFormat = @"NUMBERTEXT";
                    TOTALPROPOSALPRICETEXT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALPROPOSALPRICETEXT.WordBreak = EvetHayirEnum.ehEvet;
                    TOTALPROPOSALPRICETEXT.TextFont.Name = "Arial";
                    TOTALPROPOSALPRICETEXT.Value = @"{%TOTALPROPOSALPRICE%}";

                    Count = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 299, 0, 324, 5, false);
                    Count.Name = "Count";
                    Count.Visible = EvetHayirEnum.ehHayir;
                    Count.FieldType = ReportFieldTypeEnum.ftVariable;
                    Count.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Count.TextFont.Name = "Arial";
                    Count.Value = @"{@counter@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ProposalDetail.GetProposalledTotalPrices_Class dataset_GetProposalledTotalPrices = ParentGroup.rsGroup.GetCurrentRecord<ProposalDetail.GetProposalledTotalPrices_Class>(0);
                    SUPPLIER.CalcValue = (dataset_GetProposalledTotalPrices != null ? Globals.ToStringCore(dataset_GetProposalledTotalPrices.Supplier) : "");
                    TOTALPROPOSALPRICE.CalcValue = (dataset_GetProposalledTotalPrices != null ? Globals.ToStringCore(dataset_GetProposalledTotalPrices.Totalproposalprice) : "");
                    TOTALPROPOSALPRICETEXT.CalcValue = MyParentReport.PARTE.TOTALPROPOSALPRICE.FormattedValue;
                    Count.CalcValue = ParentGroup.Counter.ToString();
                    return new TTReportObject[] { SUPPLIER,TOTALPROPOSALPRICE,TOTALPROPOSALPRICETEXT,Count};
                }

                public override void RunScript()
                {
#region PARTE BODY_Script
                    count = Convert.ToInt32(Count.CalcValue);
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
            public IsteklilerceTeklifEdilenFiyatlar MyParentReport
            {
                get { return (IsteklilerceTeklifEdilenFiyatlar)ParentReport; }
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
                public IsteklilerceTeklifEdilenFiyatlar MyParentReport
                {
                    get { return (IsteklilerceTeklifEdilenFiyatlar)ParentReport; }
                }
                
                public TTReportField DESC; 
                public PARTAGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    DESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 3, 257, 8, false);
                    DESC.Name = "DESC";
                    DESC.FieldType = ReportFieldTypeEnum.ftExpression;
                    DESC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESC.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESC.TextFont.Name = "Arial";
                    DESC.Value = @"""İhaleye "" + PARTEGroup.count.ToString() + "" istekli katılmış olup verdikleri fiyatlar yukarıda belirtilmiştir ve hazır bulunanlara açıklanmıştır.""";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DESC.CalcValue = "İhaleye " + PARTEGroup.count.ToString() + " istekli katılmış olup verdikleri fiyatlar yukarıda belirtilmiştir ve hazır bulunanlara açıklanmıştır.";
                    return new TTReportObject[] { DESC};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTDGroup : TTReportGroup
        {
            public IsteklilerceTeklifEdilenFiyatlar MyParentReport
            {
                get { return (IsteklilerceTeklifEdilenFiyatlar)ParentReport; }
            }

            new public PARTDGroupHeader Header()
            {
                return (PARTDGroupHeader)_header;
            }

            new public PARTDGroupFooter Footer()
            {
                return (PARTDGroupFooter)_footer;
            }

            public TTReportField PROJECTNO141 { get {return Header().PROJECTNO141;} }
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
                public IsteklilerceTeklifEdilenFiyatlar MyParentReport
                {
                    get { return (IsteklilerceTeklifEdilenFiyatlar)ParentReport; }
                }
                
                public TTReportField PROJECTNO141; 
                public PARTDGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PROJECTNO141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 3, 257, 8, false);
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
            public partial class PARTDGroupFooter : TTReportSection
            {
                public IsteklilerceTeklifEdilenFiyatlar MyParentReport
                {
                    get { return (IsteklilerceTeklifEdilenFiyatlar)ParentReport; }
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
            public IsteklilerceTeklifEdilenFiyatlar MyParentReport
            {
                get { return (IsteklilerceTeklifEdilenFiyatlar)ParentReport; }
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
                public IsteklilerceTeklifEdilenFiyatlar MyParentReport
                {
                    get { return (IsteklilerceTeklifEdilenFiyatlar)ParentReport; }
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
                    
                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 12, 53, 16, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NAMESURNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME.NoClip = EvetHayirEnum.ehEvet;
                    NAMESURNAME.TextFont.Name = "Arial";
                    NAMESURNAME.Value = @"{#NAMESURNAME#}";

                    HOSPFUNC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 17, 53, 21, false);
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

                    RANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 7, 53, 11, false);
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

        public IsteklilerceTeklifEdilenFiyatlar()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTF = new PARTFGroup(PARTB,"PARTF");
            PARTE = new PARTEGroup(PARTF,"PARTE");
            PARTA = new PARTAGroup(PARTF,"PARTA");
            PARTD = new PARTDGroup(PARTF,"PARTD");
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
            Name = "ISTEKLILERCETEKLIFEDILENFIYATLAR";
            Caption = "İsteklilerce Teklif Edilen Fiyatlar";
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