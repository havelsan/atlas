
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
    /// Zarf Açma Ve Belge Kontrol Tutanağı_KİK010.0/M
    /// </summary>
    public partial class ZarfAcmaVeBelgeKontrolTutanagi : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ZarfAcmaVeBelgeKontrolTutanagi MyParentReport
            {
                get { return (ZarfAcmaVeBelgeKontrolTutanagi)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField3_ { get {return Header().NewField3_;} }
            public TTReportField NewField4_ { get {return Header().NewField4_;} }
            public TTReportField NewField5_ { get {return Header().NewField5_;} }
            public TTReportField NewField6_ { get {return Header().NewField6_;} }
            public TTReportField NewField7_ { get {return Header().NewField7_;} }
            public TTReportField NewField8_ { get {return Header().NewField8_;} }
            public TTReportField NewField1_ { get {return Header().NewField1_;} }
            public TTReportField NewField11_ { get {return Header().NewField11_;} }
            public TTReportField TarihSaat { get {return Header().TarihSaat;} }
            public TTReportField KIKTENDERREGISTERNO { get {return Header().KIKTENDERREGISTERNO;} }
            public TTReportField RESPONSIBLEPROCUREMENTUNITDEF { get {return Header().RESPONSIBLEPROCUREMENTUNITDEF;} }
            public TTReportField ACTDEFINE { get {return Header().ACTDEFINE;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11_1 { get {return Header().NewField11_1;} }
            public TTReportField ReportName { get {return Header().ReportName;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField LOGO111111121 { get {return Header().LOGO111111121;} }
            public TTReportField PROJECTNO { get {return Footer().PROJECTNO;} }
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
                public ZarfAcmaVeBelgeKontrolTutanagi MyParentReport
                {
                    get { return (ZarfAcmaVeBelgeKontrolTutanagi)ParentReport; }
                }
                
                public TTReportField NewField3_;
                public TTReportField NewField4_;
                public TTReportField NewField5_;
                public TTReportField NewField6_;
                public TTReportField NewField7_;
                public TTReportField NewField8_;
                public TTReportField NewField1_;
                public TTReportField NewField11_;
                public TTReportField TarihSaat;
                public TTReportField KIKTENDERREGISTERNO;
                public TTReportField RESPONSIBLEPROCUREMENTUNITDEF;
                public TTReportField ACTDEFINE;
                public TTReportField NewField1;
                public TTReportField NewField11_1;
                public TTReportField ReportName;
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO111111121; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 76;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField3_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 40, 67, 45, false);
                    NewField3_.Name = "NewField3_";
                    NewField3_.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField3_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3_.TextFont.Name = "Arial";
                    NewField3_.TextFont.Size = 9;
                    NewField3_.TextFont.Bold = true;
                    NewField3_.Value = @"İhale Kayıt Numarası";

                    NewField4_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 40, 68, 45, false);
                    NewField4_.Name = "NewField4_";
                    NewField4_.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField4_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4_.TextFont.Name = "Arial";
                    NewField4_.TextFont.Size = 9;
                    NewField4_.TextFont.Bold = true;
                    NewField4_.Value = @":";

                    NewField5_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 45, 67, 50, false);
                    NewField5_.Name = "NewField5_";
                    NewField5_.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField5_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5_.TextFont.Name = "Arial";
                    NewField5_.TextFont.Size = 9;
                    NewField5_.TextFont.Bold = true;
                    NewField5_.Value = @"İdarenin Adı";

                    NewField6_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 45, 68, 50, false);
                    NewField6_.Name = "NewField6_";
                    NewField6_.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField6_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6_.TextFont.Name = "Arial";
                    NewField6_.TextFont.Size = 9;
                    NewField6_.TextFont.Bold = true;
                    NewField6_.Value = @":";

                    NewField7_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 50, 67, 55, false);
                    NewField7_.Name = "NewField7_";
                    NewField7_.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField7_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7_.TextFont.Name = "Arial";
                    NewField7_.TextFont.Size = 9;
                    NewField7_.TextFont.Bold = true;
                    NewField7_.Value = @"İşin Adı";

                    NewField8_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 50, 68, 55, false);
                    NewField8_.Name = "NewField8_";
                    NewField8_.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField8_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField8_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8_.TextFont.Name = "Arial";
                    NewField8_.TextFont.Size = 9;
                    NewField8_.TextFont.Bold = true;
                    NewField8_.Value = @":";

                    NewField1_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 60, 67, 65, false);
                    NewField1_.Name = "NewField1_";
                    NewField1_.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField1_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1_.TextFont.Name = "Arial";
                    NewField1_.TextFont.Size = 9;
                    NewField1_.TextFont.Bold = true;
                    NewField1_.Value = @"Formun Doldurulduğu Tarih ve Saat";

                    NewField11_ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 55, 68, 60, false);
                    NewField11_.Name = "NewField11_";
                    NewField11_.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField11_.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11_.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11_.TextFont.Name = "Arial";
                    NewField11_.TextFont.Size = 9;
                    NewField11_.TextFont.Bold = true;
                    NewField11_.Value = @":";

                    TarihSaat = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 60, 130, 65, false);
                    TarihSaat.Name = "TarihSaat";
                    TarihSaat.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TarihSaat.TextFont.Name = "Arial";
                    TarihSaat.TextFont.Size = 9;
                    TarihSaat.Value = @"_ _/_ _/_ _ _ _ .............. günü, saat _ _:_ _";

                    KIKTENDERREGISTERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 40, 130, 45, false);
                    KIKTENDERREGISTERNO.Name = "KIKTENDERREGISTERNO";
                    KIKTENDERREGISTERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIKTENDERREGISTERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KIKTENDERREGISTERNO.NoClip = EvetHayirEnum.ehEvet;
                    KIKTENDERREGISTERNO.ObjectDefName = "PurchaseProject";
                    KIKTENDERREGISTERNO.DataMember = "KIKTENDERREGISTERNO";
                    KIKTENDERREGISTERNO.TextFont.Name = "Arial";
                    KIKTENDERREGISTERNO.TextFont.Size = 9;
                    KIKTENDERREGISTERNO.Value = @"{@TTOBJECTID@}";

                    RESPONSIBLEPROCUREMENTUNITDEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 45, 130, 50, false);
                    RESPONSIBLEPROCUREMENTUNITDEF.Name = "RESPONSIBLEPROCUREMENTUNITDEF";
                    RESPONSIBLEPROCUREMENTUNITDEF.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESPONSIBLEPROCUREMENTUNITDEF.CaseFormat = CaseFormatEnum.fcTitleCase;
                    RESPONSIBLEPROCUREMENTUNITDEF.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RESPONSIBLEPROCUREMENTUNITDEF.NoClip = EvetHayirEnum.ehEvet;
                    RESPONSIBLEPROCUREMENTUNITDEF.ObjectDefName = "PURCHASEPROJECT";
                    RESPONSIBLEPROCUREMENTUNITDEF.DataMember = "RESPONSIBLEPROCUREMENTUNITDEF.NAME";
                    RESPONSIBLEPROCUREMENTUNITDEF.TextFont.Name = "Arial";
                    RESPONSIBLEPROCUREMENTUNITDEF.TextFont.Size = 9;
                    RESPONSIBLEPROCUREMENTUNITDEF.Value = @"{@TTOBJECTID@}";

                    ACTDEFINE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 50, 130, 55, false);
                    ACTDEFINE.Name = "ACTDEFINE";
                    ACTDEFINE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTDEFINE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ACTDEFINE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTDEFINE.ObjectDefName = "PurchaseProject";
                    ACTDEFINE.DataMember = "ACTDEFINE";
                    ACTDEFINE.TextFont.Name = "Arial";
                    ACTDEFINE.TextFont.Size = 9;
                    ACTDEFINE.Value = @"{@TTOBJECTID@}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 55, 67, 60, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"Tutanağın Adı";

                    NewField11_1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 60, 68, 65, false);
                    NewField11_1.Name = "NewField11_1";
                    NewField11_1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField11_1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11_1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11_1.TextFont.Name = "Arial";
                    NewField11_1.TextFont.Size = 9;
                    NewField11_1.TextFont.Bold = true;
                    NewField11_1.Value = @":";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 69, 277, 74, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Name = "Arial";
                    ReportName.TextFont.Bold = true;
                    ReportName.Value = @"ZARF AÇMA VE BELGE KONTROL TUTANAĞI";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 15, 277, 38, false);
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

                    LOGO111111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 15, 50, 35, false);
                    LOGO111111121.Name = "LOGO111111121";
                    LOGO111111121.Visible = EvetHayirEnum.ehHayir;
                    LOGO111111121.TextFont.CharSet = 1;
                    LOGO111111121.Value = @"LOGO";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField3_.CalcValue = NewField3_.Value;
                    NewField4_.CalcValue = NewField4_.Value;
                    NewField5_.CalcValue = NewField5_.Value;
                    NewField6_.CalcValue = NewField6_.Value;
                    NewField7_.CalcValue = NewField7_.Value;
                    NewField8_.CalcValue = NewField8_.Value;
                    NewField1_.CalcValue = NewField1_.Value;
                    NewField11_.CalcValue = NewField11_.Value;
                    TarihSaat.CalcValue = TarihSaat.Value;
                    KIKTENDERREGISTERNO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    KIKTENDERREGISTERNO.PostFieldValueCalculation();
                    RESPONSIBLEPROCUREMENTUNITDEF.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    RESPONSIBLEPROCUREMENTUNITDEF.PostFieldValueCalculation();
                    ACTDEFINE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    ACTDEFINE.PostFieldValueCalculation();
                    NewField1.CalcValue = NewField1.Value;
                    NewField11_1.CalcValue = NewField11_1.Value;
                    ReportName.CalcValue = ReportName.Value;
                    LOGO111111121.CalcValue = LOGO111111121.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField3_,NewField4_,NewField5_,NewField6_,NewField7_,NewField8_,NewField1_,NewField11_,TarihSaat,KIKTENDERREGISTERNO,RESPONSIBLEPROCUREMENTUNITDEF,ACTDEFINE,NewField1,NewField11_1,ReportName,LOGO111111121,XXXXXXBASLIK};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ZarfAcmaVeBelgeKontrolTutanagi MyParentReport
                {
                    get { return (ZarfAcmaVeBelgeKontrolTutanagi)ParentReport; }
                }
                
                public TTReportField PROJECTNO; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PROJECTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 35, 5, false);
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
                    PROJECTNO.CalcValue = @"";
                    return new TTReportObject[] { PROJECTNO};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    string objectID = ((ZarfAcmaVeBelgeKontrolTutanagi)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            PurchaseProject pp = (PurchaseProject)ctx.GetObject(new Guid(objectID), typeof(PurchaseProject));
            if (pp != null)
                PROJECTNO.CalcValue = " Proje Nu. : " + pp.PurchaseProjectNO.ToString();
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class DOCUMENTGroup : TTReportGroup
        {
            public ZarfAcmaVeBelgeKontrolTutanagi MyParentReport
            {
                get { return (ZarfAcmaVeBelgeKontrolTutanagi)ParentReport; }
            }

            new public DOCUMENTGroupBody Body()
            {
                return (DOCUMENTGroupBody)_body;
            }
            public TTReportField DocName { get {return Body().DocName;} }
            public DOCUMENTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public DOCUMENTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PurchaseProjectProposalFirm.GetDocumentNamesForFirmsQuery_Class>("GetDocumentNamesForFirmsQuery", PurchaseProjectProposalFirm.GetDocumentNamesForFirmsQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new DOCUMENTGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class DOCUMENTGroupBody : TTReportSection
            {
                public ZarfAcmaVeBelgeKontrolTutanagi MyParentReport
                {
                    get { return (ZarfAcmaVeBelgeKontrolTutanagi)ParentReport; }
                }
                
                public TTReportField DocName; 
                public DOCUMENTGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 8;
                    RepeatWidth = 30;
                    
                    DocName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 1, 80, 10, false);
                    DocName.Name = "DocName";
                    DocName.DrawStyle = DrawStyleConstants.vbSolid;
                    DocName.FieldType = ReportFieldTypeEnum.ftVariable;
                    DocName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DocName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DocName.MultiLine = EvetHayirEnum.ehEvet;
                    DocName.WordBreak = EvetHayirEnum.ehEvet;
                    DocName.TextFont.Name = "Arial";
                    DocName.TextFont.Size = 9;
                    DocName.Value = @"{#DOCNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProjectProposalFirm.GetDocumentNamesForFirmsQuery_Class dataset_GetDocumentNamesForFirmsQuery = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProjectProposalFirm.GetDocumentNamesForFirmsQuery_Class>(0);
                    DocName.CalcValue = (dataset_GetDocumentNamesForFirmsQuery != null ? Globals.ToStringCore(dataset_GetDocumentNamesForFirmsQuery.DocName) : "");
                    return new TTReportObject[] { DocName};
                }
            }

        }

        public DOCUMENTGroup DOCUMENT;

        public partial class FIRMGroup : TTReportGroup
        {
            public ZarfAcmaVeBelgeKontrolTutanagi MyParentReport
            {
                get { return (ZarfAcmaVeBelgeKontrolTutanagi)ParentReport; }
            }

            new public FIRMGroupBody Body()
            {
                return (FIRMGroupBody)_body;
            }
            public TTReportField Supplier { get {return Body().Supplier;} }
            public TTReportField DOC1 { get {return Body().DOC1;} }
            public TTReportField DOC2 { get {return Body().DOC2;} }
            public TTReportField DOC3 { get {return Body().DOC3;} }
            public TTReportField DOC7 { get {return Body().DOC7;} }
            public TTReportField DOC6 { get {return Body().DOC6;} }
            public TTReportField DOC4 { get {return Body().DOC4;} }
            public TTReportField DOC5 { get {return Body().DOC5;} }
            public TTReportField SupplierID { get {return Body().SupplierID;} }
            public TTReportField DOC8 { get {return Body().DOC8;} }
            public FIRMGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public FIRMGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PurchaseProjectProposalFirm.GetProposalFirmsByObjectID_Class>("GetProposalFirmsByObjectID", PurchaseProjectProposalFirm.GetProposalFirmsByObjectID((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new FIRMGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class FIRMGroupBody : TTReportSection
            {
                public ZarfAcmaVeBelgeKontrolTutanagi MyParentReport
                {
                    get { return (ZarfAcmaVeBelgeKontrolTutanagi)ParentReport; }
                }
                
                public TTReportField Supplier;
                public TTReportField DOC1;
                public TTReportField DOC2;
                public TTReportField DOC3;
                public TTReportField DOC7;
                public TTReportField DOC6;
                public TTReportField DOC4;
                public TTReportField DOC5;
                public TTReportField SupplierID;
                public TTReportField DOC8; 
                public FIRMGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    Supplier = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 50, 9, false);
                    Supplier.Name = "Supplier";
                    Supplier.DrawStyle = DrawStyleConstants.vbSolid;
                    Supplier.FieldType = ReportFieldTypeEnum.ftVariable;
                    Supplier.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Supplier.MultiLine = EvetHayirEnum.ehEvet;
                    Supplier.WordBreak = EvetHayirEnum.ehEvet;
                    Supplier.TextFont.Name = "Arial";
                    Supplier.TextFont.Size = 9;
                    Supplier.Value = @"{#SUPPLIER#}";

                    DOC1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 0, 80, 9, false);
                    DOC1.Name = "DOC1";
                    DOC1.Visible = EvetHayirEnum.ehHayir;
                    DOC1.DrawStyle = DrawStyleConstants.vbSolid;
                    DOC1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOC1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOC1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOC1.TextFont.Name = "Arial";
                    DOC1.TextFont.Size = 9;
                    DOC1.Value = @"";

                    DOC2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 0, 110, 9, false);
                    DOC2.Name = "DOC2";
                    DOC2.Visible = EvetHayirEnum.ehHayir;
                    DOC2.DrawStyle = DrawStyleConstants.vbSolid;
                    DOC2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOC2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOC2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOC2.TextFont.Name = "Arial";
                    DOC2.TextFont.Size = 9;
                    DOC2.Value = @"";

                    DOC3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 0, 140, 9, false);
                    DOC3.Name = "DOC3";
                    DOC3.Visible = EvetHayirEnum.ehHayir;
                    DOC3.DrawStyle = DrawStyleConstants.vbSolid;
                    DOC3.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOC3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOC3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOC3.TextFont.Name = "Arial";
                    DOC3.TextFont.Size = 9;
                    DOC3.Value = @"";

                    DOC7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 0, 260, 9, false);
                    DOC7.Name = "DOC7";
                    DOC7.Visible = EvetHayirEnum.ehHayir;
                    DOC7.DrawStyle = DrawStyleConstants.vbSolid;
                    DOC7.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOC7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOC7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOC7.TextFont.Name = "Arial";
                    DOC7.TextFont.Size = 9;
                    DOC7.Value = @"";

                    DOC6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 0, 230, 9, false);
                    DOC6.Name = "DOC6";
                    DOC6.Visible = EvetHayirEnum.ehHayir;
                    DOC6.DrawStyle = DrawStyleConstants.vbSolid;
                    DOC6.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOC6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOC6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOC6.TextFont.Name = "Arial";
                    DOC6.TextFont.Size = 9;
                    DOC6.Value = @"";

                    DOC4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 0, 170, 9, false);
                    DOC4.Name = "DOC4";
                    DOC4.Visible = EvetHayirEnum.ehHayir;
                    DOC4.DrawStyle = DrawStyleConstants.vbSolid;
                    DOC4.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOC4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOC4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOC4.TextFont.Name = "Arial";
                    DOC4.TextFont.Size = 9;
                    DOC4.Value = @"";

                    DOC5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 0, 200, 9, false);
                    DOC5.Name = "DOC5";
                    DOC5.Visible = EvetHayirEnum.ehHayir;
                    DOC5.DrawStyle = DrawStyleConstants.vbSolid;
                    DOC5.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOC5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOC5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOC5.TextFont.Name = "Arial";
                    DOC5.TextFont.Size = 9;
                    DOC5.Value = @"";

                    SupplierID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 305, 0, 330, 5, false);
                    SupplierID.Name = "SupplierID";
                    SupplierID.Visible = EvetHayirEnum.ehHayir;
                    SupplierID.FieldType = ReportFieldTypeEnum.ftVariable;
                    SupplierID.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SupplierID.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SupplierID.TextFont.Name = "Arial";
                    SupplierID.TextFont.Size = 9;
                    SupplierID.Value = @"{#SUPPLIERID#}";

                    DOC8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, 0, 290, 9, false);
                    DOC8.Name = "DOC8";
                    DOC8.Visible = EvetHayirEnum.ehHayir;
                    DOC8.DrawStyle = DrawStyleConstants.vbSolid;
                    DOC8.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOC8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOC8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOC8.TextFont.Name = "Arial";
                    DOC8.TextFont.Size = 9;
                    DOC8.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProjectProposalFirm.GetProposalFirmsByObjectID_Class dataset_GetProposalFirmsByObjectID = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProjectProposalFirm.GetProposalFirmsByObjectID_Class>(0);
                    Supplier.CalcValue = (dataset_GetProposalFirmsByObjectID != null ? Globals.ToStringCore(dataset_GetProposalFirmsByObjectID.Supplier) : "");
                    DOC1.CalcValue = @"";
                    DOC2.CalcValue = @"";
                    DOC3.CalcValue = @"";
                    DOC7.CalcValue = @"";
                    DOC6.CalcValue = @"";
                    DOC4.CalcValue = @"";
                    DOC5.CalcValue = @"";
                    SupplierID.CalcValue = (dataset_GetProposalFirmsByObjectID != null ? Globals.ToStringCore(dataset_GetProposalFirmsByObjectID.Supplierid) : "");
                    DOC8.CalcValue = @"";
                    return new TTReportObject[] { Supplier,DOC1,DOC2,DOC3,DOC7,DOC6,DOC4,DOC5,SupplierID,DOC8};
                }

                public override void RunScript()
                {
#region FIRM BODY_Script
                    string objectID = ((ZarfAcmaVeBelgeKontrolTutanagi)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                    string supplierID = SupplierID.CalcValue;
                    TTObjectContext ctx = new TTObjectContext(true);
                    BindingList<PurchaseProjectProposalFirm.GetDocumentNamesForFirmsBySupplierIDQuery_Class> getApprovedDocuments = PurchaseProjectProposalFirm.GetDocumentNamesForFirmsBySupplierIDQuery(ctx, objectID, supplierID);
                    if (getApprovedDocuments.Count > 0)
                    {
                        if (getApprovedDocuments.Count <= 7)
                        {
                            for (int i = 1; i <= getApprovedDocuments.Count; i++)
                            {
                                TTReportField rf = FieldsByName("DOC"+i);
                                if (getApprovedDocuments[i - 1].DocName.ToString() == "Teklif Mektubu" || getApprovedDocuments[i - 1].DocName.ToString() == "Geçici Teminat Mektubu")
                                    if (Convert.ToBoolean(getApprovedDocuments[i - 1].Approved))
                                        rf.CalcValue = "UYGUN";
                                    else
                                        rf.CalcValue = "UYGUN DEĞİL";
                                else
                                    if (Convert.ToBoolean(getApprovedDocuments[i - 1].Approved))
                                        rf.CalcValue = "VAR";
                                    else
                                        rf.CalcValue = "YOK";
                                rf.Visible = EvetHayirEnum.ehEvet;
                            }
                        }
                        else
                        {
                            this.ForceNewPage = EvetHayirEnum.ehEvet;
                        }
                    }
#endregion FIRM BODY_Script
                }
            }

        }

        public FIRMGroup FIRM;

        public partial class PARTBGroup : TTReportGroup
        {
            public ZarfAcmaVeBelgeKontrolTutanagi MyParentReport
            {
                get { return (ZarfAcmaVeBelgeKontrolTutanagi)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField ReportName1 { get {return Header().ReportName1;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public ZarfAcmaVeBelgeKontrolTutanagi MyParentReport
                {
                    get { return (ZarfAcmaVeBelgeKontrolTutanagi)ParentReport; }
                }
                
                public TTReportField ReportName1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 11;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ReportName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 3, 277, 8, false);
                    ReportName1.Name = "ReportName1";
                    ReportName1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName1.TextFont.Name = "Arial";
                    ReportName1.TextFont.Bold = true;
                    ReportName1.Value = @"İHALE KOMİSYONU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName1.CalcValue = ReportName1.Value;
                    return new TTReportObject[] { ReportName1};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public ZarfAcmaVeBelgeKontrolTutanagi MyParentReport
                {
                    get { return (ZarfAcmaVeBelgeKontrolTutanagi)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class TENDERCOMMISIONGroup : TTReportGroup
        {
            public ZarfAcmaVeBelgeKontrolTutanagi MyParentReport
            {
                get { return (ZarfAcmaVeBelgeKontrolTutanagi)ParentReport; }
            }

            new public TENDERCOMMISIONGroupBody Body()
            {
                return (TENDERCOMMISIONGroupBody)_body;
            }
            public TTReportField NAMESURNAME { get {return Body().NAMESURNAME;} }
            public TTReportField HOSPFUNC { get {return Body().HOSPFUNC;} }
            public TTReportField COMFUNC { get {return Body().COMFUNC;} }
            public TTReportField RANK { get {return Body().RANK;} }
            public TENDERCOMMISIONGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TENDERCOMMISIONGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
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
                _body = new TENDERCOMMISIONGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TENDERCOMMISIONGroupBody : TTReportSection
            {
                public ZarfAcmaVeBelgeKontrolTutanagi MyParentReport
                {
                    get { return (ZarfAcmaVeBelgeKontrolTutanagi)ParentReport; }
                }
                
                public TTReportField NAMESURNAME;
                public TTReportField HOSPFUNC;
                public TTReportField COMFUNC;
                public TTReportField RANK; 
                public TENDERCOMMISIONGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 35;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 5;
                    RepeatWidth = 47;
                    
                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 11, 73, 15, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NAMESURNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME.NoClip = EvetHayirEnum.ehEvet;
                    NAMESURNAME.TextFont.Name = "Arial";
                    NAMESURNAME.Value = @"{#NAMESURNAME#}";

                    HOSPFUNC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 16, 73, 20, false);
                    HOSPFUNC.Name = "HOSPFUNC";
                    HOSPFUNC.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC.ObjectDefName = "UserTitleEnum";
                    HOSPFUNC.DataMember = "DISPLAYTEXT";
                    HOSPFUNC.TextFont.Name = "Arial";
                    HOSPFUNC.Value = @"{#HOSPFUNC#}";

                    COMFUNC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 1, 73, 5, false);
                    COMFUNC.Name = "COMFUNC";
                    COMFUNC.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC.CaseFormat = CaseFormatEnum.fcUpperCase;
                    COMFUNC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC.ObjectDefName = "CommisionMemberDutyEnum";
                    COMFUNC.DataMember = "DISPLAYTEXT";
                    COMFUNC.TextFont.Name = "Arial";
                    COMFUNC.Value = @"{#COMFUNC#}";

                    RANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 6, 73, 10, false);
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

        public TENDERCOMMISIONGroup TENDERCOMMISION;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ZarfAcmaVeBelgeKontrolTutanagi()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            DOCUMENT = new DOCUMENTGroup(PARTA,"DOCUMENT");
            FIRM = new FIRMGroup(PARTA,"FIRM");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            TENDERCOMMISION = new TENDERCOMMISIONGroup(PARTB,"TENDERCOMMISION");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Proje No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "ZARFACMAVEBELGEKONTROLTUTANAGI";
            Caption = "Zarf Açma Ve Belge Kontrol Tutanağı_KİK010.0/M";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 5;
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