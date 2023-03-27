
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
    /// İhaleye Davet_KİK014.0/M
    /// </summary>
    public partial class IhaleyeDavet : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public IhaleyeDavet MyParentReport
            {
                get { return (IhaleyeDavet)ParentReport; }
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
                public IhaleyeDavet MyParentReport
                {
                    get { return (IhaleyeDavet)ParentReport; }
                }
                 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public IhaleyeDavet MyParentReport
                {
                    get { return (IhaleyeDavet)ParentReport; }
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
                    string objectID = ((IhaleyeDavet)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
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
            public IhaleyeDavet MyParentReport
            {
                get { return (IhaleyeDavet)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField PROJECTNO4 { get {return Header().PROJECTNO4;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField PROJECTNO13 { get {return Header().PROJECTNO13;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField NewField102 { get {return Header().NewField102;} }
            public TTReportField KIKTENDERREGISTERNO { get {return Header().KIKTENDERREGISTERNO;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField PROJECTNO141 { get {return Header().PROJECTNO141;} }
            public TTReportField SAYI { get {return Header().SAYI;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField LOGO12111111 { get {return Header().LOGO12111111;} }
            public TTReportField SUPPLIERADDRESS { get {return Header().SUPPLIERADDRESS;} }
            public TTReportField SUPPLIER { get {return Header().SUPPLIER;} }
            public TTReportField NewField171 { get {return Footer().NewField171;} }
            public TTReportField PROCUREMENTUNITDEFADDRESS { get {return Footer().PROCUREMENTUNITDEFADDRESS;} }
            public TTReportField PROCUREMENTUNITDEFTEL { get {return Footer().PROCUREMENTUNITDEFTEL;} }
            public TTReportField PROCUREMENTUNITDEFFAX { get {return Footer().PROCUREMENTUNITDEFFAX;} }
            public TTReportField NewField1141 { get {return Footer().NewField1141;} }
            public TTReportField NewField11411 { get {return Footer().NewField11411;} }
            public TTReportField NewField111411 { get {return Footer().NewField111411;} }
            public TTReportField PROCUREMENTUNITDEFEMAIL { get {return Footer().PROCUREMENTUNITDEFEMAIL;} }
            public TTReportField NewField1171 { get {return Footer().NewField1171;} }
            public TTReportField NewField11711 { get {return Footer().NewField11711;} }
            public TTReportField NewField12711 { get {return Footer().NewField12711;} }
            public TTReportField NewField13711 { get {return Footer().NewField13711;} }
            public TTReportField NewField11331 { get {return Footer().NewField11331;} }
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
                list[0] = new TTReportNqlData<InvitedFirmForTender.GetInvitedFirmsByProjectObjectID_Class>("GetInvitedFirmsByProjectObjectID", InvitedFirmForTender.GetInvitedFirmsByProjectObjectID((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public IhaleyeDavet MyParentReport
                {
                    get { return (IhaleyeDavet)ParentReport; }
                }
                
                public TTReportField PROJECTNO4;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField PROJECTNO13;
                public TTReportField NewField181;
                public TTReportField NewField12;
                public TTReportField NewField191;
                public TTReportField NewField102;
                public TTReportField KIKTENDERREGISTERNO;
                public TTReportField NewField112;
                public TTReportField NewField122;
                public TTReportField PROJECTNO141;
                public TTReportField SAYI;
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO12111111;
                public TTReportField SUPPLIERADDRESS;
                public TTReportField SUPPLIER; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 93;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PROJECTNO4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 60, 170, 70, false);
                    PROJECTNO4.Name = "PROJECTNO4";
                    PROJECTNO4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO4.MultiLine = EvetHayirEnum.ehEvet;
                    PROJECTNO4.WordBreak = EvetHayirEnum.ehEvet;
                    PROJECTNO4.TextFont.Name = "Arial";
                    PROJECTNO4.Value = @"Bu mektup ____/____/_______ tarihinde tarafınıza [elden verilmiştir/iadeli taahhütlü olarak posta yolu ile] gönderilmiştir.";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 55, 39, 60, false);
                    NewField15.Name = "NewField15";
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @"Ön Yeterlilik Tarihi";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 55, 40, 60, false);
                    NewField16.Name = "NewField16";
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Bold = true;
                    NewField16.Value = @":";

                    PROJECTNO13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 55, 95, 60, false);
                    PROJECTNO13.Name = "PROJECTNO13";
                    PROJECTNO13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO13.TextFont.Name = "Arial";
                    PROJECTNO13.Value = @"____/____/________";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 40, 39, 45, false);
                    NewField181.Name = "NewField181";
                    NewField181.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField181.TextFont.Name = "Arial";
                    NewField181.TextFont.Bold = true;
                    NewField181.Value = @"İhale Kayıt Numarası";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 40, 40, 45, false);
                    NewField12.Name = "NewField12";
                    NewField12.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @":";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 45, 39, 50, false);
                    NewField191.Name = "NewField191";
                    NewField191.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField191.TextFont.Name = "Arial";
                    NewField191.TextFont.Bold = true;
                    NewField191.Value = @"SAYI";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 45, 40, 50, false);
                    NewField102.Name = "NewField102";
                    NewField102.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField102.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField102.TextFont.Name = "Arial";
                    NewField102.TextFont.Bold = true;
                    NewField102.Value = @":";

                    KIKTENDERREGISTERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 40, 95, 45, false);
                    KIKTENDERREGISTERNO.Name = "KIKTENDERREGISTERNO";
                    KIKTENDERREGISTERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIKTENDERREGISTERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KIKTENDERREGISTERNO.TextFont.Name = "Arial";
                    KIKTENDERREGISTERNO.Value = @"{#KIKTENDERREGISTERNO#}";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 50, 39, 55, false);
                    NewField112.Name = "NewField112";
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.Name = "Arial";
                    NewField112.TextFont.Bold = true;
                    NewField112.Value = @"KONU";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 50, 40, 55, false);
                    NewField122.Name = "NewField122";
                    NewField122.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Name = "Arial";
                    NewField122.TextFont.Bold = true;
                    NewField122.Value = @":";

                    PROJECTNO141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 50, 170, 55, false);
                    PROJECTNO141.Name = "PROJECTNO141";
                    PROJECTNO141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO141.TextFont.Name = "Arial";
                    PROJECTNO141.Value = @"İhaleye Davet";

                    SAYI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 45, 95, 50, false);
                    SAYI.Name = "SAYI";
                    SAYI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAYI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SAYI.TextFont.Name = "Arial";
                    SAYI.Value = @"";

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

                    LOGO12111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 40, 35, false);
                    LOGO12111111.Name = "LOGO12111111";
                    LOGO12111111.Visible = EvetHayirEnum.ehHayir;
                    LOGO12111111.TextFont.CharSet = 1;
                    LOGO12111111.Value = @"LOGO";

                    SUPPLIERADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 80, 170, 85, false);
                    SUPPLIERADDRESS.Name = "SUPPLIERADDRESS";
                    SUPPLIERADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIERADDRESS.CaseFormat = CaseFormatEnum.fcTitleCase;
                    SUPPLIERADDRESS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIERADDRESS.TextFont.Name = "Arial";
                    SUPPLIERADDRESS.Value = @"{#ADDRESS#}";

                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 85, 170, 90, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUPPLIER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER.TextFont.Name = "Arial";
                    SUPPLIER.Value = @"""       Sayın "" + {#SUPPLIER#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InvitedFirmForTender.GetInvitedFirmsByProjectObjectID_Class dataset_GetInvitedFirmsByProjectObjectID = ParentGroup.rsGroup.GetCurrentRecord<InvitedFirmForTender.GetInvitedFirmsByProjectObjectID_Class>(0);
                    PROJECTNO4.CalcValue = PROJECTNO4.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    PROJECTNO13.CalcValue = PROJECTNO13.Value;
                    NewField181.CalcValue = NewField181.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField191.CalcValue = NewField191.Value;
                    NewField102.CalcValue = NewField102.Value;
                    KIKTENDERREGISTERNO.CalcValue = (dataset_GetInvitedFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetInvitedFirmsByProjectObjectID.KIKTenderRegisterNO) : "");
                    NewField112.CalcValue = NewField112.Value;
                    NewField122.CalcValue = NewField122.Value;
                    PROJECTNO141.CalcValue = PROJECTNO141.Value;
                    SAYI.CalcValue = @"";
                    LOGO12111111.CalcValue = LOGO12111111.Value;
                    SUPPLIERADDRESS.CalcValue = (dataset_GetInvitedFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetInvitedFirmsByProjectObjectID.Address) : "");
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    SUPPLIER.CalcValue = "       Sayın " + (dataset_GetInvitedFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetInvitedFirmsByProjectObjectID.Supplier) : "");
                    return new TTReportObject[] { PROJECTNO4,NewField15,NewField16,PROJECTNO13,NewField181,NewField12,NewField191,NewField102,KIKTENDERREGISTERNO,NewField112,NewField122,PROJECTNO141,SAYI,LOGO12111111,SUPPLIERADDRESS,XXXXXXBASLIK,SUPPLIER};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public IhaleyeDavet MyParentReport
                {
                    get { return (IhaleyeDavet)ParentReport; }
                }
                
                public TTReportField NewField171;
                public TTReportField PROCUREMENTUNITDEFADDRESS;
                public TTReportField PROCUREMENTUNITDEFTEL;
                public TTReportField PROCUREMENTUNITDEFFAX;
                public TTReportField NewField1141;
                public TTReportField NewField11411;
                public TTReportField NewField111411;
                public TTReportField PROCUREMENTUNITDEFEMAIL;
                public TTReportField NewField1171;
                public TTReportField NewField11711;
                public TTReportField NewField12711;
                public TTReportField NewField13711;
                public TTReportField NewField11331;
                public TTReportField DELIVEREDBYNAME;
                public TTReportField DELIVEREDBYDUTY;
                public TTReportField NAME;
                public TTReportField RANK;
                public TTReportField TITLE; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 40;
                    RepeatCount = 0;
                    
                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 13, 10, false);
                    NewField171.Name = "NewField171";
                    NewField171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField171.TextFont.Name = "Arial";
                    NewField171.Value = @"Adres";

                    PROCUREMENTUNITDEFADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 5, 85, 15, false);
                    PROCUREMENTUNITDEFADDRESS.Name = "PROCUREMENTUNITDEFADDRESS";
                    PROCUREMENTUNITDEFADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCUREMENTUNITDEFADDRESS.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PROCUREMENTUNITDEFADDRESS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROCUREMENTUNITDEFADDRESS.MultiLine = EvetHayirEnum.ehEvet;
                    PROCUREMENTUNITDEFADDRESS.WordBreak = EvetHayirEnum.ehEvet;
                    PROCUREMENTUNITDEFADDRESS.ObjectDefName = "PurchaseProject";
                    PROCUREMENTUNITDEFADDRESS.DataMember = "RESPONSIBLEPROCUREMENTUNITDEF.ADDRESS";
                    PROCUREMENTUNITDEFADDRESS.TextFont.Name = "Arial";
                    PROCUREMENTUNITDEFADDRESS.Value = @"{@TTOBJECTID@}";

                    PROCUREMENTUNITDEFTEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 15, 85, 20, false);
                    PROCUREMENTUNITDEFTEL.Name = "PROCUREMENTUNITDEFTEL";
                    PROCUREMENTUNITDEFTEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCUREMENTUNITDEFTEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROCUREMENTUNITDEFTEL.ObjectDefName = "PurchaseProject";
                    PROCUREMENTUNITDEFTEL.DataMember = "RESPONSIBLEPROCUREMENTUNITDEF.TELEPHONE";
                    PROCUREMENTUNITDEFTEL.TextFont.Name = "Arial";
                    PROCUREMENTUNITDEFTEL.Value = @"{@TTOBJECTID@}";

                    PROCUREMENTUNITDEFFAX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 20, 85, 25, false);
                    PROCUREMENTUNITDEFFAX.Name = "PROCUREMENTUNITDEFFAX";
                    PROCUREMENTUNITDEFFAX.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCUREMENTUNITDEFFAX.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROCUREMENTUNITDEFFAX.ObjectDefName = "PurchaseProject";
                    PROCUREMENTUNITDEFFAX.DataMember = "RESPONSIBLEPROCUREMENTUNITDEF.FAX";
                    PROCUREMENTUNITDEFFAX.TextFont.Name = "Arial";
                    PROCUREMENTUNITDEFFAX.Value = @"{@TTOBJECTID@}";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 13, 20, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.Value = @"Telefon";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 20, 13, 25, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.TextFont.Name = "Arial";
                    NewField11411.Value = @"Fax";

                    NewField111411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 25, 13, 30, false);
                    NewField111411.Name = "NewField111411";
                    NewField111411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111411.TextFont.Name = "Arial";
                    NewField111411.Value = @"E-Mail";

                    PROCUREMENTUNITDEFEMAIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 25, 85, 30, false);
                    PROCUREMENTUNITDEFEMAIL.Name = "PROCUREMENTUNITDEFEMAIL";
                    PROCUREMENTUNITDEFEMAIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCUREMENTUNITDEFEMAIL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROCUREMENTUNITDEFEMAIL.ObjectDefName = "PurchaseProject";
                    PROCUREMENTUNITDEFEMAIL.DataMember = "RESPONSIBLEPROCUREMENTUNITDEF.EMAIL";
                    PROCUREMENTUNITDEFEMAIL.TextFont.Name = "Arial";
                    PROCUREMENTUNITDEFEMAIL.Value = @"{@TTOBJECTID@}";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 5, 15, 10, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField1171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1171.TextFont.Name = "Arial";
                    NewField1171.Value = @":";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 15, 15, 20, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11711.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11711.TextFont.Name = "Arial";
                    NewField11711.Value = @":";

                    NewField12711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 20, 15, 25, false);
                    NewField12711.Name = "NewField12711";
                    NewField12711.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField12711.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12711.TextFont.Name = "Arial";
                    NewField12711.Value = @":";

                    NewField13711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 25, 15, 30, false);
                    NewField13711.Name = "NewField13711";
                    NewField13711.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField13711.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13711.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13711.TextFont.Name = "Arial";
                    NewField13711.Value = @":";

                    NewField11331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 5, 170, 10, false);
                    NewField11331.Name = "NewField11331";
                    NewField11331.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField11331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11331.TextFont.Name = "Arial";
                    NewField11331.Value = @"İdare Yetkilisi";

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
                    InvitedFirmForTender.GetInvitedFirmsByProjectObjectID_Class dataset_GetInvitedFirmsByProjectObjectID = ParentGroup.rsGroup.GetCurrentRecord<InvitedFirmForTender.GetInvitedFirmsByProjectObjectID_Class>(0);
                    NewField171.CalcValue = NewField171.Value;
                    PROCUREMENTUNITDEFADDRESS.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PROCUREMENTUNITDEFADDRESS.PostFieldValueCalculation();
                    PROCUREMENTUNITDEFTEL.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PROCUREMENTUNITDEFTEL.PostFieldValueCalculation();
                    PROCUREMENTUNITDEFFAX.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PROCUREMENTUNITDEFFAX.PostFieldValueCalculation();
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField111411.CalcValue = NewField111411.Value;
                    PROCUREMENTUNITDEFEMAIL.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PROCUREMENTUNITDEFEMAIL.PostFieldValueCalculation();
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField11711.CalcValue = NewField11711.Value;
                    NewField12711.CalcValue = NewField12711.Value;
                    NewField13711.CalcValue = NewField13711.Value;
                    NewField11331.CalcValue = NewField11331.Value;
                    TITLE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TITLE.PostFieldValueCalculation();
                    DELIVEREDBYDUTY.CalcValue = MyParentReport.PARTB.TITLE.CalcValue;
                    DELIVEREDBYDUTY.PostFieldValueCalculation();
                    NAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NAME.PostFieldValueCalculation();
                    RANK.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    RANK.PostFieldValueCalculation();
                    DELIVEREDBYNAME.CalcValue = MyParentReport.PARTB.RANK.CalcValue + " " + MyParentReport.PARTB.NAME.CalcValue;
                    return new TTReportObject[] { NewField171,PROCUREMENTUNITDEFADDRESS,PROCUREMENTUNITDEFTEL,PROCUREMENTUNITDEFFAX,NewField1141,NewField11411,NewField111411,PROCUREMENTUNITDEFEMAIL,NewField1171,NewField11711,NewField12711,NewField13711,NewField11331,TITLE,DELIVEREDBYDUTY,NAME,RANK,DELIVEREDBYNAME};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public IhaleyeDavet MyParentReport
            {
                get { return (IhaleyeDavet)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportRTF ReportRTF { get {return Body().ReportRTF;} }
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
                public IhaleyeDavet MyParentReport
                {
                    get { return (IhaleyeDavet)ParentReport; }
                }
                
                public TTReportRTF ReportRTF; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    ReportRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 0, 5, 170, 15, false);
                    ReportRTF.Name = "ReportRTF";
                    ReportRTF.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportRTF.CalcValue = ReportRTF.Value;
                    return new TTReportObject[] { ReportRTF};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((IhaleyeDavet)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PurchaseProject purchaseProject = (PurchaseProject)context.GetObject(new Guid(sObjectID),"PurchaseProject");
            this.ReportRTF.Value = purchaseProject.IhaleyeDavetRTF.ToString();
#endregion MAIN BODY_PreScript
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public IhaleyeDavet()
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
            Name = "IHALEYEDAVET";
            Caption = "İhaleye Davet_KİK014.0/M";
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