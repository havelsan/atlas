
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
    /// Teklif Vermeye Davet_KİK016/4.0/M
    /// </summary>
    public partial class TeklifVermeyeDavet : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public TeklifVermeyeDavet MyParentReport
            {
                get { return (TeklifVermeyeDavet)ParentReport; }
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
                public TeklifVermeyeDavet MyParentReport
                {
                    get { return (TeklifVermeyeDavet)ParentReport; }
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
                public TeklifVermeyeDavet MyParentReport
                {
                    get { return (TeklifVermeyeDavet)ParentReport; }
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
                    string objectID = ((TeklifVermeyeDavet)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
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
            public TeklifVermeyeDavet MyParentReport
            {
                get { return (TeklifVermeyeDavet)ParentReport; }
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
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField20 { get {return Header().NewField20;} }
            public TTReportField KIKTENDERREGISTERNO { get {return Header().KIKTENDERREGISTERNO;} }
            public TTReportField NewField21 { get {return Header().NewField21;} }
            public TTReportField NewField22 { get {return Header().NewField22;} }
            public TTReportField PROJECTNO14 { get {return Header().PROJECTNO14;} }
            public TTReportField SAYI { get {return Header().SAYI;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField LOGO1111112 { get {return Header().LOGO1111112;} }
            public TTReportField ACTDEFINE { get {return Header().ACTDEFINE;} }
            public TTReportField SUPPLIERADDRESS { get {return Header().SUPPLIERADDRESS;} }
            public TTReportField SUPPLIER { get {return Header().SUPPLIER;} }
            public TTReportField NewField17 { get {return Footer().NewField17;} }
            public TTReportField PROCUREMENTUNITDEFADDRESS { get {return Footer().PROCUREMENTUNITDEFADDRESS;} }
            public TTReportField PROCUREMENTUNITDEFTEL { get {return Footer().PROCUREMENTUNITDEFTEL;} }
            public TTReportField PROCUREMENTUNITDEFFAX { get {return Footer().PROCUREMENTUNITDEFFAX;} }
            public TTReportField NewField141 { get {return Footer().NewField141;} }
            public TTReportField NewField1141 { get {return Footer().NewField1141;} }
            public TTReportField NewField11411 { get {return Footer().NewField11411;} }
            public TTReportField PROCUREMENTUNITDEFEMAIL { get {return Footer().PROCUREMENTUNITDEFEMAIL;} }
            public TTReportField NewField171 { get {return Footer().NewField171;} }
            public TTReportField NewField1171 { get {return Footer().NewField1171;} }
            public TTReportField NewField1172 { get {return Footer().NewField1172;} }
            public TTReportField NewField1173 { get {return Footer().NewField1173;} }
            public TTReportField NewField1331 { get {return Footer().NewField1331;} }
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
                list[0] = new TTReportNqlData<ProjectFirmSufficiency.GetSufficientFirmsByProjectObjectID_Class>("GetSufficientFirmsByProjectObjectID", ProjectFirmSufficiency.GetSufficientFirmsByProjectObjectID((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public TeklifVermeyeDavet MyParentReport
                {
                    get { return (TeklifVermeyeDavet)ParentReport; }
                }
                
                public TTReportField PROJECTNO4;
                public TTReportField NewField18;
                public TTReportField NewField2;
                public TTReportField NewField19;
                public TTReportField NewField20;
                public TTReportField KIKTENDERREGISTERNO;
                public TTReportField NewField21;
                public TTReportField NewField22;
                public TTReportField PROJECTNO14;
                public TTReportField SAYI;
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO1111112;
                public TTReportField ACTDEFINE;
                public TTReportField SUPPLIERADDRESS;
                public TTReportField SUPPLIER; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 95;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PROJECTNO4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 60, 170, 70, false);
                    PROJECTNO4.Name = "PROJECTNO4";
                    PROJECTNO4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO4.MultiLine = EvetHayirEnum.ehEvet;
                    PROJECTNO4.WordBreak = EvetHayirEnum.ehEvet;
                    PROJECTNO4.TextFont.Name = "Arial";
                    PROJECTNO4.Value = @"Bu mektup ____/____/_______ tarihinde tarafınıza elden verilmiştir/iadeli taahhütlü olarak posta yolu ile gönderilmiştir.";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 40, 39, 45, false);
                    NewField18.Name = "NewField18";
                    NewField18.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField18.TextFont.Name = "Arial";
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @"İhale Kayıt Numarası";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 40, 40, 45, false);
                    NewField2.Name = "NewField2";
                    NewField2.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @":";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 45, 39, 50, false);
                    NewField19.Name = "NewField19";
                    NewField19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19.TextFont.Name = "Arial";
                    NewField19.TextFont.Bold = true;
                    NewField19.Value = @"SAYI";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 45, 40, 50, false);
                    NewField20.Name = "NewField20";
                    NewField20.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField20.TextFont.Name = "Arial";
                    NewField20.TextFont.Bold = true;
                    NewField20.Value = @":";

                    KIKTENDERREGISTERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 40, 95, 45, false);
                    KIKTENDERREGISTERNO.Name = "KIKTENDERREGISTERNO";
                    KIKTENDERREGISTERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIKTENDERREGISTERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KIKTENDERREGISTERNO.TextFont.Name = "Arial";
                    KIKTENDERREGISTERNO.Value = @"{#KIKTENDERREGISTERNO#}";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 50, 39, 55, false);
                    NewField21.Name = "NewField21";
                    NewField21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21.TextFont.Name = "Arial";
                    NewField21.TextFont.Bold = true;
                    NewField21.Value = @"KONU";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 50, 40, 55, false);
                    NewField22.Name = "NewField22";
                    NewField22.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField22.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField22.TextFont.Name = "Arial";
                    NewField22.TextFont.Bold = true;
                    NewField22.Value = @":";

                    PROJECTNO14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 50, 170, 55, false);
                    PROJECTNO14.Name = "PROJECTNO14";
                    PROJECTNO14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO14.TextFont.Name = "Arial";
                    PROJECTNO14.Value = @"Teklif Vermeye Davet";

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

                    LOGO1111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 40, 35, false);
                    LOGO1111112.Name = "LOGO1111112";
                    LOGO1111112.Visible = EvetHayirEnum.ehHayir;
                    LOGO1111112.TextFont.CharSet = 1;
                    LOGO1111112.Value = @"LOGO";

                    ACTDEFINE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 50, 200, 55, false);
                    ACTDEFINE.Name = "ACTDEFINE";
                    ACTDEFINE.Visible = EvetHayirEnum.ehHayir;
                    ACTDEFINE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTDEFINE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTDEFINE.Value = @"{#ACTDEFINE#}";

                    SUPPLIERADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 80, 170, 85, false);
                    SUPPLIERADDRESS.Name = "SUPPLIERADDRESS";
                    SUPPLIERADDRESS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIERADDRESS.CaseFormat = CaseFormatEnum.fcTitleCase;
                    SUPPLIERADDRESS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIERADDRESS.TextFont.Name = "Arial";
                    SUPPLIERADDRESS.Value = @"{#SUPPLIERADDRESS#}";

                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 85, 170, 90, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftExpression;
                    SUPPLIER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER.TextFont.Name = "Arial";
                    SUPPLIER.Value = @"""       Sayın "" + {#SUPPLIER#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ProjectFirmSufficiency.GetSufficientFirmsByProjectObjectID_Class dataset_GetSufficientFirmsByProjectObjectID = ParentGroup.rsGroup.GetCurrentRecord<ProjectFirmSufficiency.GetSufficientFirmsByProjectObjectID_Class>(0);
                    PROJECTNO4.CalcValue = PROJECTNO4.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField20.CalcValue = NewField20.Value;
                    KIKTENDERREGISTERNO.CalcValue = (dataset_GetSufficientFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetSufficientFirmsByProjectObjectID.KIKTenderRegisterNO) : "");
                    NewField21.CalcValue = NewField21.Value;
                    NewField22.CalcValue = NewField22.Value;
                    PROJECTNO14.CalcValue = PROJECTNO14.Value;
                    SAYI.CalcValue = @"";
                    LOGO1111112.CalcValue = LOGO1111112.Value;
                    ACTDEFINE.CalcValue = (dataset_GetSufficientFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetSufficientFirmsByProjectObjectID.ActDefine) : "");
                    SUPPLIERADDRESS.CalcValue = (dataset_GetSufficientFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetSufficientFirmsByProjectObjectID.Supplieraddress) : "");
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    SUPPLIER.CalcValue = "       Sayın " + (dataset_GetSufficientFirmsByProjectObjectID != null ? Globals.ToStringCore(dataset_GetSufficientFirmsByProjectObjectID.Supplier) : "");
                    return new TTReportObject[] { PROJECTNO4,NewField18,NewField2,NewField19,NewField20,KIKTENDERREGISTERNO,NewField21,NewField22,PROJECTNO14,SAYI,LOGO1111112,ACTDEFINE,SUPPLIERADDRESS,XXXXXXBASLIK,SUPPLIER};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public TeklifVermeyeDavet MyParentReport
                {
                    get { return (TeklifVermeyeDavet)ParentReport; }
                }
                
                public TTReportField NewField17;
                public TTReportField PROCUREMENTUNITDEFADDRESS;
                public TTReportField PROCUREMENTUNITDEFTEL;
                public TTReportField PROCUREMENTUNITDEFFAX;
                public TTReportField NewField141;
                public TTReportField NewField1141;
                public TTReportField NewField11411;
                public TTReportField PROCUREMENTUNITDEFEMAIL;
                public TTReportField NewField171;
                public TTReportField NewField1171;
                public TTReportField NewField1172;
                public TTReportField NewField1173;
                public TTReportField NewField1331;
                public TTReportField DELIVEREDBYNAME;
                public TTReportField DELIVEREDBYDUTY;
                public TTReportField NAME;
                public TTReportField RANK;
                public TTReportField TITLE; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 38;
                    RepeatCount = 0;
                    
                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 13, 10, false);
                    NewField17.Name = "NewField17";
                    NewField17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17.TextFont.Name = "Arial";
                    NewField17.Value = @"Adres";

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

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 13, 20, false);
                    NewField141.Name = "NewField141";
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.Value = @"Telefon";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 20, 13, 25, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.Value = @"Fax";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 25, 13, 30, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.TextFont.Name = "Arial";
                    NewField11411.Value = @"E-Mail";

                    PROCUREMENTUNITDEFEMAIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 25, 85, 30, false);
                    PROCUREMENTUNITDEFEMAIL.Name = "PROCUREMENTUNITDEFEMAIL";
                    PROCUREMENTUNITDEFEMAIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCUREMENTUNITDEFEMAIL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROCUREMENTUNITDEFEMAIL.ObjectDefName = "PurchaseProject";
                    PROCUREMENTUNITDEFEMAIL.DataMember = "RESPONSIBLEPROCUREMENTUNITDEF.EMAIL";
                    PROCUREMENTUNITDEFEMAIL.TextFont.Name = "Arial";
                    PROCUREMENTUNITDEFEMAIL.Value = @"{@TTOBJECTID@}";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 5, 15, 10, false);
                    NewField171.Name = "NewField171";
                    NewField171.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField171.TextFont.Name = "Arial";
                    NewField171.Value = @":";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 15, 15, 20, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1171.TextFont.Name = "Arial";
                    NewField1171.Value = @":";

                    NewField1172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 20, 15, 25, false);
                    NewField1172.Name = "NewField1172";
                    NewField1172.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField1172.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1172.TextFont.Name = "Arial";
                    NewField1172.Value = @":";

                    NewField1173 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 25, 15, 30, false);
                    NewField1173.Name = "NewField1173";
                    NewField1173.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField1173.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1173.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1173.TextFont.Name = "Arial";
                    NewField1173.Value = @":";

                    NewField1331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 5, 170, 10, false);
                    NewField1331.Name = "NewField1331";
                    NewField1331.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField1331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1331.TextFont.Name = "Arial";
                    NewField1331.Value = @"İdare Yetkilisi";

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
                    ProjectFirmSufficiency.GetSufficientFirmsByProjectObjectID_Class dataset_GetSufficientFirmsByProjectObjectID = ParentGroup.rsGroup.GetCurrentRecord<ProjectFirmSufficiency.GetSufficientFirmsByProjectObjectID_Class>(0);
                    NewField17.CalcValue = NewField17.Value;
                    PROCUREMENTUNITDEFADDRESS.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PROCUREMENTUNITDEFADDRESS.PostFieldValueCalculation();
                    PROCUREMENTUNITDEFTEL.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PROCUREMENTUNITDEFTEL.PostFieldValueCalculation();
                    PROCUREMENTUNITDEFFAX.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PROCUREMENTUNITDEFFAX.PostFieldValueCalculation();
                    NewField141.CalcValue = NewField141.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    PROCUREMENTUNITDEFEMAIL.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    PROCUREMENTUNITDEFEMAIL.PostFieldValueCalculation();
                    NewField171.CalcValue = NewField171.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField1172.CalcValue = NewField1172.Value;
                    NewField1173.CalcValue = NewField1173.Value;
                    NewField1331.CalcValue = NewField1331.Value;
                    TITLE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    TITLE.PostFieldValueCalculation();
                    DELIVEREDBYDUTY.CalcValue = MyParentReport.PARTB.TITLE.CalcValue;
                    DELIVEREDBYDUTY.PostFieldValueCalculation();
                    NAME.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    NAME.PostFieldValueCalculation();
                    RANK.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    RANK.PostFieldValueCalculation();
                    DELIVEREDBYNAME.CalcValue = MyParentReport.PARTB.RANK.CalcValue + " " + MyParentReport.PARTB.NAME.CalcValue;
                    return new TTReportObject[] { NewField17,PROCUREMENTUNITDEFADDRESS,PROCUREMENTUNITDEFTEL,PROCUREMENTUNITDEFFAX,NewField141,NewField1141,NewField11411,PROCUREMENTUNITDEFEMAIL,NewField171,NewField1171,NewField1172,NewField1173,NewField1331,TITLE,DELIVEREDBYDUTY,NAME,RANK,DELIVEREDBYNAME};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public TeklifVermeyeDavet MyParentReport
            {
                get { return (TeklifVermeyeDavet)ParentReport; }
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
                public TeklifVermeyeDavet MyParentReport
                {
                    get { return (TeklifVermeyeDavet)ParentReport; }
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
            string sObjectID = ((TeklifVermeyeDavet)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PurchaseProject purchaseProject = (PurchaseProject)context.GetObject(new Guid(sObjectID),"PurchaseProject");
            this.ReportRTF.Value = purchaseProject.ProposalInviteFormDesc.ToString();
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

        public TeklifVermeyeDavet()
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
            Name = "TEKLIFVERMEYEDAVET";
            Caption = "Teklif Vermeye Davet_KİK016/4.0/M";
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