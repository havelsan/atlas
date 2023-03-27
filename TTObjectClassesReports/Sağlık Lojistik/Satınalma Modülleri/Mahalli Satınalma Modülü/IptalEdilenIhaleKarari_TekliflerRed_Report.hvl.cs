
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
    /// Yetersizlik Formu_KİK013.0/M
    /// </summary>
    public partial class IptalEdilenIhaleKarari_TekliflerRed : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public IptalEdilenIhaleKarari_TekliflerRed MyParentReport
            {
                get { return (IptalEdilenIhaleKarari_TekliflerRed)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

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
                public IptalEdilenIhaleKarari_TekliflerRed MyParentReport
                {
                    get { return (IptalEdilenIhaleKarari_TekliflerRed)ParentReport; }
                }
                 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public IptalEdilenIhaleKarari_TekliflerRed MyParentReport
                {
                    get { return (IptalEdilenIhaleKarari_TekliflerRed)ParentReport; }
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
                    PROJECTNO.CalcValue = @"";
                    return new TTReportObject[] { PROJECTNO};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    string objectID = ((IptalEdilenIhaleKarari_TekliflerRed)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            TTObjectContext ctx = new TTObjectContext(true);
            PurchaseProject pp = (PurchaseProject)ctx.GetObject(new Guid(objectID), typeof(PurchaseProject));
            if (pp != null)
                PROJECTNO.CalcValue = " Proje Nu. : " + pp.PurchaseProjectNO.ToString();
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public IptalEdilenIhaleKarari_TekliflerRed MyParentReport
            {
                get { return (IptalEdilenIhaleKarari_TekliflerRed)ParentReport; }
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
            public TTReportField KIKTENDERREGISTERNO { get {return Header().KIKTENDERREGISTERNO;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField PROJECTNO3 { get {return Header().PROJECTNO3;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField TENDERDATE { get {return Header().TENDERDATE;} }
            public TTReportField PROJECTNO4 { get {return Header().PROJECTNO4;} }
            public TTReportField PROJECTNO5 { get {return Header().PROJECTNO5;} }
            public TTReportField ORDERNO { get {return Header().ORDERNO;} }
            public TTReportField PROJECTNO9 { get {return Header().PROJECTNO9;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField PROJECTCANCELDATE { get {return Header().PROJECTCANCELDATE;} }
            public TTReportField ACTDEFINE { get {return Header().ACTDEFINE;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField LOGO0 { get {return Header().LOGO0;} }
            public TTReportField SUPPLIERADDRESS { get {return Header().SUPPLIERADDRESS;} }
            public TTReportField SUPPLIER { get {return Header().SUPPLIER;} }
            public TTReportField PROPOSALOBJECTID { get {return Header().PROPOSALOBJECTID;} }
            public TTReportField TTOBJECTID { get {return Header().TTOBJECTID;} }
            public TTReportField NewField113311 { get {return Footer().NewField113311;} }
            public TTReportField DELIVEREDBYNAME { get {return Footer().DELIVEREDBYNAME;} }
            public TTReportField DELIVEREDBYDUTY { get {return Footer().DELIVEREDBYDUTY;} }
            public TTReportField NAME { get {return Footer().NAME;} }
            public TTReportField RANK { get {return Footer().RANK;} }
            public TTReportField TITLE { get {return Footer().TITLE;} }
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
                list[0] = new TTReportNqlData<Proposal.GetProposalledFirms_Class>("GetProposalledFirms", Proposal.GetProposalledFirms((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public IptalEdilenIhaleKarari_TekliflerRed MyParentReport
                {
                    get { return (IptalEdilenIhaleKarari_TekliflerRed)ParentReport; }
                }
                
                public TTReportField NewField2;
                public TTReportField NewField;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField KIKTENDERREGISTERNO;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField PROJECTNO3;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField TENDERDATE;
                public TTReportField PROJECTNO4;
                public TTReportField PROJECTNO5;
                public TTReportField ORDERNO;
                public TTReportField PROJECTNO9;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField PROJECTCANCELDATE;
                public TTReportField ACTDEFINE;
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO0;
                public TTReportField SUPPLIERADDRESS;
                public TTReportField SUPPLIER;
                public TTReportField PROPOSALOBJECTID;
                public TTReportField TTOBJECTID; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 107;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 40, 39, 45, false);
                    NewField2.Name = "NewField2";
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"İhale Kayıt Numarası";

                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 40, 40, 45, false);
                    NewField.Name = "NewField";
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField.TextFont.Name = "Arial";
                    NewField.TextFont.Bold = true;
                    NewField.Value = @":";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 45, 39, 50, false);
                    NewField3.Name = "NewField3";
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"SAYI";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 45, 40, 50, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @":";

                    KIKTENDERREGISTERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 40, 170, 45, false);
                    KIKTENDERREGISTERNO.Name = "KIKTENDERREGISTERNO";
                    KIKTENDERREGISTERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIKTENDERREGISTERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KIKTENDERREGISTERNO.TextFont.Name = "Arial";
                    KIKTENDERREGISTERNO.Value = @"{#KIKTENDERREGISTERNO#}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 50, 39, 55, false);
                    NewField5.Name = "NewField5";
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Name = "Arial";
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @"KONU";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 50, 40, 55, false);
                    NewField6.Name = "NewField6";
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Bold = true;
                    NewField6.Value = @":";

                    PROJECTNO3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 50, 170, 55, false);
                    PROJECTNO3.Name = "PROJECTNO3";
                    PROJECTNO3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO3.TextFont.Name = "Arial";
                    PROJECTNO3.Value = @"Bütün tekliflerin reddedilmesi sebebiyle ihalenin iptali";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 55, 39, 60, false);
                    NewField7.Name = "NewField7";
                    NewField7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField7.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7.WordBreak = EvetHayirEnum.ehEvet;
                    NewField7.TextFont.Name = "Arial";
                    NewField7.TextFont.Bold = true;
                    NewField7.Value = @"İhale Tarihi";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 55, 40, 60, false);
                    NewField8.Name = "NewField8";
                    NewField8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField8.TextFont.Name = "Arial";
                    NewField8.TextFont.Bold = true;
                    NewField8.Value = @":";

                    TENDERDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 55, 170, 60, false);
                    TENDERDATE.Name = "TENDERDATE";
                    TENDERDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TENDERDATE.TextFormat = @"dd/MM/yyyy";
                    TENDERDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TENDERDATE.TextFont.Name = "Arial";
                    TENDERDATE.Value = @"{#TENDERDATE#}";

                    PROJECTNO4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 70, 170, 75, false);
                    PROJECTNO4.Name = "PROJECTNO4";
                    PROJECTNO4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO4.TextFont.Name = "Arial";
                    PROJECTNO4.Value = @"Bu mektup ___/___/______ tarihinde tarafınıza iadeli taahhütlü olarak posta yoluyla gönderilmiştir.";

                    PROJECTNO5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 98, 20, 103, false);
                    PROJECTNO5.Name = "PROJECTNO5";
                    PROJECTNO5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO5.TextFont.Name = "Arial";
                    PROJECTNO5.TextFont.Bold = true;
                    PROJECTNO5.Value = @"İLGİ:";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 45, 65, 50, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.Value = @"";

                    PROJECTNO9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 98, 170, 103, false);
                    PROJECTNO9.Name = "PROJECTNO9";
                    PROJECTNO9.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROJECTNO9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO9.TextFont.Name = "Arial";
                    PROJECTNO9.Value = @"";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 60, 39, 65, false);
                    NewField17.Name = "NewField17";
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.MultiLine = EvetHayirEnum.ehEvet;
                    NewField17.WordBreak = EvetHayirEnum.ehEvet;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Bold = true;
                    NewField17.Value = @"İhale İptal Tarihi";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 60, 40, 65, false);
                    NewField18.Name = "NewField18";
                    NewField18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18.TextFont.Name = "Arial";
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @":";

                    PROJECTCANCELDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 60, 170, 65, false);
                    PROJECTCANCELDATE.Name = "PROJECTCANCELDATE";
                    PROJECTCANCELDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROJECTCANCELDATE.TextFormat = @"dd/MM/yyyy";
                    PROJECTCANCELDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTCANCELDATE.TextFont.Name = "Arial";
                    PROJECTCANCELDATE.Value = @"{#PROJECTCANCELDATE#}";

                    ACTDEFINE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 88, 239, 93, false);
                    ACTDEFINE.Name = "ACTDEFINE";
                    ACTDEFINE.Visible = EvetHayirEnum.ehHayir;
                    ACTDEFINE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTDEFINE.Value = @"{#ACTDEFINE#}";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 15, 170, 38, false);
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

                    LOGO0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 40, 35, false);
                    LOGO0.Name = "LOGO0";
                    LOGO0.Visible = EvetHayirEnum.ehHayir;
                    LOGO0.TextFont.CharSet = 1;
                    LOGO0.Value = @"LOGO";

                    SUPPLIERADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 85, 170, 90, false);
                    SUPPLIERADDRESS.Name = "SUPPLIERADDRESS";
                    SUPPLIERADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIERADDRESS.CaseFormat = CaseFormatEnum.fcTitleCase;
                    SUPPLIERADDRESS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIERADDRESS.TextFont.Name = "Arial";
                    SUPPLIERADDRESS.Value = @"{#SUPPLIERADDRESS#}";

                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 90, 170, 95, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUPPLIER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER.TextFont.Name = "Arial";
                    SUPPLIER.Value = @"""       Sayın "" + {#SUPPLIER#}";

                    PROPOSALOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 96, 239, 101, false);
                    PROPOSALOBJECTID.Name = "PROPOSALOBJECTID";
                    PROPOSALOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    PROPOSALOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROPOSALOBJECTID.TextFont.Name = "Arial Narrow";
                    PROPOSALOBJECTID.TextFont.CharSet = 1;
                    PROPOSALOBJECTID.Value = @"{#OBJECTID#}";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 80, 239, 85, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.TextFont.Name = "Arial Narrow";
                    TTOBJECTID.TextFont.CharSet = 1;
                    TTOBJECTID.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Proposal.GetProposalledFirms_Class dataset_GetProposalledFirms = ParentGroup.rsGroup.GetCurrentRecord<Proposal.GetProposalledFirms_Class>(0);
                    NewField2.CalcValue = NewField2.Value;
                    NewField.CalcValue = NewField.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    KIKTENDERREGISTERNO.CalcValue = (dataset_GetProposalledFirms != null ? Globals.ToStringCore(dataset_GetProposalledFirms.KIKTenderRegisterNO) : "");
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    PROJECTNO3.CalcValue = PROJECTNO3.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    TENDERDATE.CalcValue = (dataset_GetProposalledFirms != null ? Globals.ToStringCore(dataset_GetProposalledFirms.TenderDate) : "");
                    PROJECTNO4.CalcValue = PROJECTNO4.Value;
                    PROJECTNO5.CalcValue = PROJECTNO5.Value;
                    ORDERNO.CalcValue = ORDERNO.Value;
                    PROJECTNO9.CalcValue = @"";
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    PROJECTCANCELDATE.CalcValue = (dataset_GetProposalledFirms != null ? Globals.ToStringCore(dataset_GetProposalledFirms.ProjectCancelDate) : "");
                    ACTDEFINE.CalcValue = (dataset_GetProposalledFirms != null ? Globals.ToStringCore(dataset_GetProposalledFirms.ActDefine) : "");
                    LOGO0.CalcValue = LOGO0.Value;
                    SUPPLIERADDRESS.CalcValue = (dataset_GetProposalledFirms != null ? Globals.ToStringCore(dataset_GetProposalledFirms.Supplieraddress) : "");
                    PROPOSALOBJECTID.CalcValue = (dataset_GetProposalledFirms != null ? Globals.ToStringCore(dataset_GetProposalledFirms.ObjectID) : "");
                    TTOBJECTID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    SUPPLIER.CalcValue = "       Sayın " + (dataset_GetProposalledFirms != null ? Globals.ToStringCore(dataset_GetProposalledFirms.Supplier) : "");
                    return new TTReportObject[] { NewField2,NewField,NewField3,NewField4,KIKTENDERREGISTERNO,NewField5,NewField6,PROJECTNO3,NewField7,NewField8,TENDERDATE,PROJECTNO4,PROJECTNO5,ORDERNO,PROJECTNO9,NewField17,NewField18,PROJECTCANCELDATE,ACTDEFINE,LOGO0,SUPPLIERADDRESS,PROPOSALOBJECTID,TTOBJECTID,XXXXXXBASLIK,SUPPLIER};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    TTObjectContext ctx = new TTObjectContext(true);
                    BindingList<PurchaseProjectProposalFirm.GetFirmOrderNOQuery_Class> orderNO = PurchaseProjectProposalFirm.GetFirmOrderNOQuery(ctx, TTOBJECTID.CalcValue, PROPOSALOBJECTID.CalcValue);
                    this.PROJECTNO9.CalcValue = "___/___/______ tarihinde " + orderNO[0].OrderNo.ToString() + " sıra numarası ile kayda alınan teklifiniz.";
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public IptalEdilenIhaleKarari_TekliflerRed MyParentReport
                {
                    get { return (IptalEdilenIhaleKarari_TekliflerRed)ParentReport; }
                }
                
                public TTReportField NewField113311;
                public TTReportField DELIVEREDBYNAME;
                public TTReportField DELIVEREDBYDUTY;
                public TTReportField NAME;
                public TTReportField RANK;
                public TTReportField TITLE; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 30;
                    RepeatCount = 0;
                    
                    NewField113311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 5, 170, 10, false);
                    NewField113311.Name = "NewField113311";
                    NewField113311.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField113311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113311.TextFont.Name = "Arial";
                    NewField113311.Value = @"İdare Yetkilisi";

                    DELIVEREDBYNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 10, 170, 15, false);
                    DELIVEREDBYNAME.Name = "DELIVEREDBYNAME";
                    DELIVEREDBYNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    DELIVEREDBYNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DELIVEREDBYNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DELIVEREDBYNAME.NoClip = EvetHayirEnum.ehEvet;
                    DELIVEREDBYNAME.TextFont.Name = "Arial";
                    DELIVEREDBYNAME.Value = @"{%RANK%} + "" "" + {%NAME%}";

                    DELIVEREDBYDUTY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 15, 170, 20, false);
                    DELIVEREDBYDUTY.Name = "DELIVEREDBYDUTY";
                    DELIVEREDBYDUTY.FieldType = ReportFieldTypeEnum.ftVariable;
                    DELIVEREDBYDUTY.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DELIVEREDBYDUTY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DELIVEREDBYDUTY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DELIVEREDBYDUTY.MultiLine = EvetHayirEnum.ehEvet;
                    DELIVEREDBYDUTY.WordBreak = EvetHayirEnum.ehEvet;
                    DELIVEREDBYDUTY.ObjectDefName = "UserTitleEnum";
                    DELIVEREDBYDUTY.DataMember = "DISPLAYTEXT";
                    DELIVEREDBYDUTY.TextFont.Name = "Arial";
                    DELIVEREDBYDUTY.Value = @"{%TITLE%}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 1, 240, 6, false);
                    NAME.Name = "NAME";
                    NAME.Visible = EvetHayirEnum.ehHayir;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.CaseFormat = CaseFormatEnum.fcNameSurname;
                    NAME.ObjectDefName = "PurchaseProject";
                    NAME.DataMember = "ADMINAUTHORIZED.NAME";
                    NAME.TextFont.Name = "Arial Narrow";
                    NAME.TextFont.CharSet = 1;
                    NAME.Value = @"{@TTOBJECTID@}";

                    RANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 9, 240, 14, false);
                    RANK.Name = "RANK";
                    RANK.Visible = EvetHayirEnum.ehHayir;
                    RANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    RANK.CaseFormat = CaseFormatEnum.fcTitleCase;
                    RANK.ObjectDefName = "PurchaseProject";
                    RANK.DataMember = "ADMINAUTHORIZED.RANK.NAME";
                    RANK.TextFont.Name = "Arial Narrow";
                    RANK.TextFont.CharSet = 1;
                    RANK.Value = @"{@TTOBJECTID@}";

                    TITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 17, 240, 22, false);
                    TITLE.Name = "TITLE";
                    TITLE.Visible = EvetHayirEnum.ehHayir;
                    TITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TITLE.ObjectDefName = "PurchaseProject";
                    TITLE.DataMember = "ADMINAUTHORIZED.TITLE";
                    TITLE.TextFont.Name = "Arial Narrow";
                    TITLE.TextFont.CharSet = 1;
                    TITLE.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Proposal.GetProposalledFirms_Class dataset_GetProposalledFirms = ParentGroup.rsGroup.GetCurrentRecord<Proposal.GetProposalledFirms_Class>(0);
                    NewField113311.CalcValue = NewField113311.Value;
                    TITLE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TITLE.PostFieldValueCalculation();
                    DELIVEREDBYDUTY.CalcValue = MyParentReport.PARTB.TITLE.CalcValue;
                    DELIVEREDBYDUTY.PostFieldValueCalculation();
                    NAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NAME.PostFieldValueCalculation();
                    RANK.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    RANK.PostFieldValueCalculation();
                    DELIVEREDBYNAME.CalcValue = MyParentReport.PARTB.RANK.CalcValue + " " + MyParentReport.PARTB.NAME.CalcValue;
                    return new TTReportObject[] { NewField113311,TITLE,DELIVEREDBYDUTY,NAME,RANK,DELIVEREDBYNAME};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public IptalEdilenIhaleKarari_TekliflerRed MyParentReport
            {
                get { return (IptalEdilenIhaleKarari_TekliflerRed)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DESC { get {return Body().DESC;} }
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
                public IptalEdilenIhaleKarari_TekliflerRed MyParentReport
                {
                    get { return (IptalEdilenIhaleKarari_TekliflerRed)ParentReport; }
                }
                
                public TTReportField DESC; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 42;
                    RepeatCount = 0;
                    
                    DESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 170, 38, false);
                    DESC.Name = "DESC";
                    DESC.FieldType = ReportFieldTypeEnum.ftExpression;
                    DESC.MultiLine = EvetHayirEnum.ehEvet;
                    DESC.WordBreak = EvetHayirEnum.ehEvet;
                    DESC.TextFont.Name = "Arial";
                    DESC.Value = @"""       İhale komisyonunun kararı üzerine"" + {%PARTB.ACTDEFINE%} + "" işine ait bütün teklifler reddedilerek ihale iptal edilmiştir. Bu mektubun postaya verildiği tarihi izleyen yedinci (7) gün kararın tarafınıza tebliğ edildiği tarih sayılacaktır. Bu tarihten itibaren beş gün içinde yazılı talepte bulunmanız halinde, ihalenin iptal edilme gerekçeleri idaremizce tarafınıza bildirilecektir.\n\n        Bilgilerinize rica ederim.""";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DESC.CalcValue = "       İhale komisyonunun kararı üzerine" + MyParentReport.PARTB.ACTDEFINE.CalcValue + " işine ait bütün teklifler reddedilerek ihale iptal edilmiştir. Bu mektubun postaya verildiği tarihi izleyen yedinci (7) gün kararın tarafınıza tebliğ edildiği tarih sayılacaktır. Bu tarihten itibaren beş gün içinde yazılı talepte bulunmanız halinde, ihalenin iptal edilme gerekçeleri idaremizce tarafınıza bildirilecektir.\n\n        Bilgilerinize rica ederim.";
                    return new TTReportObject[] { DESC};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public IptalEdilenIhaleKarari_TekliflerRed()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Proje No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "IPTALEDILENIHALEKARARI_TEKLIFLERRED";
            Caption = "İhale İptal Bildirimi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
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