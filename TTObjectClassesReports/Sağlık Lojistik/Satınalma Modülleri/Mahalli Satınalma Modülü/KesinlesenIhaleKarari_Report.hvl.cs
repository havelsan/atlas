
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
    /// Kesinleşen İhale Kararı_KİK022.0/M
    /// </summary>
    public partial class KesinlesenIhaleKarari : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public KesinlesenIhaleKarari MyParentReport
            {
                get { return (KesinlesenIhaleKarari)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField PROJECTNO3 { get {return Header().PROJECTNO3;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField TENDERDATE { get {return Header().TENDERDATE;} }
            public TTReportField ORDERNO { get {return Header().ORDERNO;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField CONCLUSIONAPPROVEDATE { get {return Header().CONCLUSIONAPPROVEDATE;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField KIKTENDERREGISTERNO { get {return Header().KIKTENDERREGISTERNO;} }
            public TTReportField NewField101 { get {return Header().NewField101;} }
            public TTReportField PROJECTNO1151 { get {return Header().PROJECTNO1151;} }
            public TTReportField HOSPITAL { get {return Header().HOSPITAL;} }
            public TTReportField PROJECTNO14 { get {return Header().PROJECTNO14;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField SUPPLIERADDRESS1 { get {return Header().SUPPLIERADDRESS1;} }
            public TTReportField SUPPLIER { get {return Header().SUPPLIER;} }
            public TTReportField FIRMID { get {return Header().FIRMID;} }
            public TTReportField ILGI1 { get {return Header().ILGI1;} }
            public TTReportField ORDERNO11 { get {return Header().ORDERNO11;} }
            public TTReportField ILGI11 { get {return Header().ILGI11;} }
            public TTReportField SUPPLIERADDRESS111 { get {return Footer().SUPPLIERADDRESS111;} }
            public TTReportField ADMINAUTHORIZED { get {return Footer().ADMINAUTHORIZED;} }
            public TTReportField SUPPLIERADDRESS11 { get {return Footer().SUPPLIERADDRESS11;} }
            public TTReportField SUPPLIERADDRESS112 { get {return Footer().SUPPLIERADDRESS112;} }
            public TTReportField SUPPLIERADDRESS113 { get {return Footer().SUPPLIERADDRESS113;} }
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
                list[0] = new TTReportNqlData<PurchaseProjectProposalFirm.GetAllFirmOrderNoQuery_Class>("GetAllFirmOrderNoQuery", PurchaseProjectProposalFirm.GetAllFirmOrderNoQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public KesinlesenIhaleKarari MyParentReport
                {
                    get { return (KesinlesenIhaleKarari)ParentReport; }
                }
                
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField PROJECTNO3;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField TENDERDATE;
                public TTReportField ORDERNO;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField CONCLUSIONAPPROVEDATE;
                public TTReportField NewField12;
                public TTReportField KIKTENDERREGISTERNO;
                public TTReportField NewField101;
                public TTReportField PROJECTNO1151;
                public TTReportField HOSPITAL;
                public TTReportField PROJECTNO14;
                public TTReportField DATE;
                public TTReportField SUPPLIERADDRESS1;
                public TTReportField SUPPLIER;
                public TTReportField FIRMID;
                public TTReportField ILGI1;
                public TTReportField ORDERNO11;
                public TTReportField ILGI11; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 125;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 50, 50, 55, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Name = "Arial";
                    NewField3.Value = @"SAYI";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 50, 52, 55, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @":";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 55, 50, 60, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Name = "Arial";
                    NewField5.Value = @"KONU";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 55, 52, 60, false);
                    NewField6.Name = "NewField6";
                    NewField6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Bold = true;
                    NewField6.Value = @":";

                    PROJECTNO3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 55, 170, 60, false);
                    PROJECTNO3.Name = "PROJECTNO3";
                    PROJECTNO3.TextFont.Name = "Arial";
                    PROJECTNO3.Value = @"Kesinleşen İhale Kararı";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 60, 50, 65, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Name = "Arial";
                    NewField7.Value = @"İhale karar tarihi";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 60, 52, 65, false);
                    NewField8.Name = "NewField8";
                    NewField8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField8.TextFont.Name = "Arial";
                    NewField8.TextFont.Bold = true;
                    NewField8.Value = @":";

                    TENDERDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 60, 170, 65, false);
                    TENDERDATE.Name = "TENDERDATE";
                    TENDERDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TENDERDATE.TextFormat = @"dd/MM/yyyy";
                    TENDERDATE.TextFont.Name = "Arial";
                    TENDERDATE.TextFont.Bold = true;
                    TENDERDATE.Value = @"{#TENDERDATE#}";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 50, 170, 55, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.Bold = true;
                    ORDERNO.Value = @"";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 65, 50, 70, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Name = "Arial";
                    NewField17.Value = @"İhale kararının onaylandığı tarih";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 65, 52, 70, false);
                    NewField18.Name = "NewField18";
                    NewField18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField18.TextFont.Name = "Arial";
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @":";

                    CONCLUSIONAPPROVEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 65, 170, 70, false);
                    CONCLUSIONAPPROVEDATE.Name = "CONCLUSIONAPPROVEDATE";
                    CONCLUSIONAPPROVEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONCLUSIONAPPROVEDATE.TextFormat = @"dd/MM/yyyy";
                    CONCLUSIONAPPROVEDATE.TextFont.Name = "Arial";
                    CONCLUSIONAPPROVEDATE.TextFont.Bold = true;
                    CONCLUSIONAPPROVEDATE.Value = @"{#CONCLUSIONAPPROVEDATE#}";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 45, 50, 50, false);
                    NewField12.Name = "NewField12";
                    NewField12.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.Value = @"İhale kayıt numarası";

                    KIKTENDERREGISTERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 45, 170, 50, false);
                    KIKTENDERREGISTERNO.Name = "KIKTENDERREGISTERNO";
                    KIKTENDERREGISTERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIKTENDERREGISTERNO.TextFont.Name = "Arial";
                    KIKTENDERREGISTERNO.TextFont.Bold = true;
                    KIKTENDERREGISTERNO.Value = @"{#KIKTENDERREGISTERNO#}";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 45, 52, 50, false);
                    NewField101.Name = "NewField101";
                    NewField101.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField101.TextFont.Name = "Arial";
                    NewField101.TextFont.Bold = true;
                    NewField101.Value = @":";

                    PROJECTNO1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 114, 10, 119, false);
                    PROJECTNO1151.Name = "PROJECTNO1151";
                    PROJECTNO1151.TextFont.Name = "Arial";
                    PROJECTNO1151.Value = @"İLGİ :";

                    HOSPITAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 170, 40, false);
                    HOSPITAL.Name = "HOSPITAL";
                    HOSPITAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPITAL.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HOSPITAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPITAL.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITAL.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITAL.TextFont.Name = "Arial";
                    HOSPITAL.TextFont.Size = 12;
                    HOSPITAL.TextFont.Bold = true;
                    HOSPITAL.Value = @"";

                    PROJECTNO14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 74, 170, 83, false);
                    PROJECTNO14.Name = "PROJECTNO14";
                    PROJECTNO14.TextColor = System.Drawing.Color.Gray;
                    PROJECTNO14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO14.MultiLine = EvetHayirEnum.ehEvet;
                    PROJECTNO14.WordBreak = EvetHayirEnum.ehEvet;
                    PROJECTNO14.TextFont.Name = "Arial";
                    PROJECTNO14.TextFont.Italic = true;
                    PROJECTNO14.Value = @"                                                                [elden verilmiştir / iadeli taahhütlü posta yoluyla / elektronik posta yoluyla / faksla gönderilmiştir].";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 74, 62, 78, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFont.Name = "Arial";
                    DATE.Value = @"";

                    SUPPLIERADDRESS1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 89, 15, 94, false);
                    SUPPLIERADDRESS1.Name = "SUPPLIERADDRESS1";
                    SUPPLIERADDRESS1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUPPLIERADDRESS1.TextFont.Name = "Arial";
                    SUPPLIERADDRESS1.Value = @"Sayın";

                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 89, 170, 106, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIER.MultiLine = EvetHayirEnum.ehEvet;
                    SUPPLIER.WordBreak = EvetHayirEnum.ehEvet;
                    SUPPLIER.TextFont.Name = "Arial";
                    SUPPLIER.TextFont.Bold = true;
                    SUPPLIER.Value = @"{#SUPPLIER#}
{#SUPPLIERADDRESS#}
TEL: {#SUPPLIERTELEPHONE#}";

                    FIRMID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 77, 247, 82, false);
                    FIRMID.Name = "FIRMID";
                    FIRMID.Visible = EvetHayirEnum.ehHayir;
                    FIRMID.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRMID.TextFont.Name = "Arial Narrow";
                    FIRMID.TextFont.CharSet = 1;
                    FIRMID.Value = @"{#FIRMID#}";

                    ILGI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 114, 48, 119, false);
                    ILGI1.Name = "ILGI1";
                    ILGI1.TextFont.Name = "Arial";
                    ILGI1.Value = @"_ _/_ _/_ _ _ _ tarihinde,";

                    ORDERNO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 114, 54, 119, false);
                    ORDERNO11.Name = "ORDERNO11";
                    ORDERNO11.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO11.TextFont.Name = "Arial";
                    ORDERNO11.TextFont.Bold = true;
                    ORDERNO11.Value = @"{#ORDERNO#}";

                    ILGI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 114, 170, 119, false);
                    ILGI11.Name = "ILGI11";
                    ILGI11.TextFont.Name = "Arial";
                    ILGI11.Value = @" sıra numarası ile kayda alınan teklifiniz.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProjectProposalFirm.GetAllFirmOrderNoQuery_Class dataset_GetAllFirmOrderNoQuery = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProjectProposalFirm.GetAllFirmOrderNoQuery_Class>(0);
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    PROJECTNO3.CalcValue = PROJECTNO3.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    TENDERDATE.CalcValue = (dataset_GetAllFirmOrderNoQuery != null ? Globals.ToStringCore(dataset_GetAllFirmOrderNoQuery.TenderDate) : "");
                    ORDERNO.CalcValue = ORDERNO.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    CONCLUSIONAPPROVEDATE.CalcValue = (dataset_GetAllFirmOrderNoQuery != null ? Globals.ToStringCore(dataset_GetAllFirmOrderNoQuery.ConclusionApproveDate) : "");
                    NewField12.CalcValue = NewField12.Value;
                    KIKTENDERREGISTERNO.CalcValue = (dataset_GetAllFirmOrderNoQuery != null ? Globals.ToStringCore(dataset_GetAllFirmOrderNoQuery.KIKTenderRegisterNO) : "");
                    NewField101.CalcValue = NewField101.Value;
                    PROJECTNO1151.CalcValue = PROJECTNO1151.Value;
                    HOSPITAL.CalcValue = @"";
                    PROJECTNO14.CalcValue = PROJECTNO14.Value;
                    DATE.CalcValue = @"";
                    SUPPLIERADDRESS1.CalcValue = SUPPLIERADDRESS1.Value;
                    SUPPLIER.CalcValue = (dataset_GetAllFirmOrderNoQuery != null ? Globals.ToStringCore(dataset_GetAllFirmOrderNoQuery.Supplier) : "") + @"
" + (dataset_GetAllFirmOrderNoQuery != null ? Globals.ToStringCore(dataset_GetAllFirmOrderNoQuery.Supplieraddress) : "") + @"
TEL: " + (dataset_GetAllFirmOrderNoQuery != null ? Globals.ToStringCore(dataset_GetAllFirmOrderNoQuery.Suppliertelephone) : "");
                    FIRMID.CalcValue = (dataset_GetAllFirmOrderNoQuery != null ? Globals.ToStringCore(dataset_GetAllFirmOrderNoQuery.Firmid) : "");
                    ILGI1.CalcValue = ILGI1.Value;
                    ORDERNO11.CalcValue = (dataset_GetAllFirmOrderNoQuery != null ? Globals.ToStringCore(dataset_GetAllFirmOrderNoQuery.OrderNo) : "");
                    ILGI11.CalcValue = ILGI11.Value;
                    return new TTReportObject[] { NewField3,NewField4,NewField5,NewField6,PROJECTNO3,NewField7,NewField8,TENDERDATE,ORDERNO,NewField17,NewField18,CONCLUSIONAPPROVEDATE,NewField12,KIKTENDERREGISTERNO,NewField101,PROJECTNO1151,HOSPITAL,PROJECTNO14,DATE,SUPPLIERADDRESS1,SUPPLIER,FIRMID,ILGI1,ORDERNO11,ILGI11};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    HOSPITAL.CalcValue = "T.C.\nXXXXXX\n"
                + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","") + "\n"
                + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY","");
            
            DATE.CalcValue = "Bu mektup          /         / " + DateTime.Now.Year.ToString() + " tarihinde ";

            PARTAGroup.firmID = FIRMID.CalcValue;
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public KesinlesenIhaleKarari MyParentReport
                {
                    get { return (KesinlesenIhaleKarari)ParentReport; }
                }
                
                public TTReportField SUPPLIERADDRESS111;
                public TTReportField ADMINAUTHORIZED;
                public TTReportField SUPPLIERADDRESS11;
                public TTReportField SUPPLIERADDRESS112;
                public TTReportField SUPPLIERADDRESS113; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 100;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    SUPPLIERADDRESS111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 170, 24, false);
                    SUPPLIERADDRESS111.Name = "SUPPLIERADDRESS111";
                    SUPPLIERADDRESS111.TextColor = System.Drawing.Color.Gray;
                    SUPPLIERADDRESS111.MultiLine = EvetHayirEnum.ehEvet;
                    SUPPLIERADDRESS111.WordBreak = EvetHayirEnum.ehEvet;
                    SUPPLIERADDRESS111.TextFont.Name = "Arial";
                    SUPPLIERADDRESS111.Value = @"                              [elden tebliğ edilmesi halinde aynı gün / iadeli taahhütlü posta yoluyla gönderilmesi halinde postaya verildiği tarihi izleyen yedinci gün / (bu tarihten önce tarafınıza tebliğ edilmesi halinde fiili tebliğ tarihi esas alınır) / elektronik posta yoluyla bildirilmesi halinde bildirim tarihi / faksla bildirilmesi halinde bildirim tarihi]";

                    ADMINAUTHORIZED = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 38, 170, 43, false);
                    ADMINAUTHORIZED.Name = "ADMINAUTHORIZED";
                    ADMINAUTHORIZED.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADMINAUTHORIZED.MultiLine = EvetHayirEnum.ehEvet;
                    ADMINAUTHORIZED.NoClip = EvetHayirEnum.ehEvet;
                    ADMINAUTHORIZED.WordBreak = EvetHayirEnum.ehEvet;
                    ADMINAUTHORIZED.TextFont.Name = "Arial";
                    ADMINAUTHORIZED.Value = @"";

                    SUPPLIERADDRESS11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 29, 10, false);
                    SUPPLIERADDRESS11.Name = "SUPPLIERADDRESS11";
                    SUPPLIERADDRESS11.TextFont.Name = "Arial";
                    SUPPLIERADDRESS11.Value = @"       Bu mektubun";

                    SUPPLIERADDRESS112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 22, 170, 35, false);
                    SUPPLIERADDRESS112.Name = "SUPPLIERADDRESS112";
                    SUPPLIERADDRESS112.MultiLine = EvetHayirEnum.ehEvet;
                    SUPPLIERADDRESS112.WordBreak = EvetHayirEnum.ehEvet;
                    SUPPLIERADDRESS112.TextFont.Name = "Arial";
                    SUPPLIERADDRESS112.Value = @"       Bu kararın bildiriminden itibaren süresi içinde 4734 sayılı kanunun 55 inci maddesi uyarınca şikayet başvurusunda bulunabileceklerdir.
       Bilgi edinilmesi hususunu rica ederim.";

                    SUPPLIERADDRESS113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 17, 66, 22, false);
                    SUPPLIERADDRESS113.Name = "SUPPLIERADDRESS113";
                    SUPPLIERADDRESS113.TextFont.Name = "Arial";
                    SUPPLIERADDRESS113.Value = @"tarafından tebliğ tarihi sayılacaktır.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProjectProposalFirm.GetAllFirmOrderNoQuery_Class dataset_GetAllFirmOrderNoQuery = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProjectProposalFirm.GetAllFirmOrderNoQuery_Class>(0);
                    SUPPLIERADDRESS111.CalcValue = SUPPLIERADDRESS111.Value;
                    ADMINAUTHORIZED.CalcValue = @"";
                    SUPPLIERADDRESS11.CalcValue = SUPPLIERADDRESS11.Value;
                    SUPPLIERADDRESS112.CalcValue = SUPPLIERADDRESS112.Value;
                    SUPPLIERADDRESS113.CalcValue = SUPPLIERADDRESS113.Value;
                    return new TTReportObject[] { SUPPLIERADDRESS111,ADMINAUTHORIZED,SUPPLIERADDRESS11,SUPPLIERADDRESS112,SUPPLIERADDRESS113};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    PurchaseProject purchaseProject = (PurchaseProject)MyParentReport.ReportObjectContext.GetObject(new Guid(MyParentReport.RuntimeParameters.TTOBJECTID), typeof(PurchaseProject));
                    if (purchaseProject.AdminAuthorized != null)
                    {
                        ADMINAUTHORIZED.CalcValue = "  İdare Yetkilisi\n\n" + purchaseProject.AdminAuthorized.Name + "\n";
                        if (purchaseProject.AdminAuthorized.MilitaryClass != null)
                            ADMINAUTHORIZED.CalcValue += purchaseProject.AdminAuthorized.MilitaryClass.Name + " ";
                        if(purchaseProject.AdminAuthorized.Rank != null)
                            ADMINAUTHORIZED.CalcValue += purchaseProject.AdminAuthorized.Rank.Name + "\n";
                        ADMINAUTHORIZED.CalcValue += TTObjectClasses.Common.GetEnumValueDefOfEnumValue(purchaseProject.AdminAuthorized.Title.Value).DisplayText;
                    }
#endregion PARTA FOOTER_Script
                }
            }

#region PARTA_Methods
            public static string firmID = string.Empty;
#endregion PARTA_Methods
        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public KesinlesenIhaleKarari MyParentReport
            {
                get { return (KesinlesenIhaleKarari)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportRTF DESCRIPTIONRTF { get {return Body().DESCRIPTIONRTF;} }
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
                public KesinlesenIhaleKarari MyParentReport
                {
                    get { return (KesinlesenIhaleKarari)ParentReport; }
                }
                
                public TTReportRTF DESCRIPTIONRTF; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 28;
                    RepeatCount = 0;
                    
                    DESCRIPTIONRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 0, 5, 170, 10, false);
                    DESCRIPTIONRTF.Name = "DESCRIPTIONRTF";
                    DESCRIPTIONRTF.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DESCRIPTIONRTF.CalcValue = DESCRIPTIONRTF.Value;
                    return new TTReportObject[] { DESCRIPTIONRTF};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    PurchaseProjectProposalFirm firm = (PurchaseProjectProposalFirm)MyParentReport.ReportObjectContext.GetObject(new Guid(PARTAGroup.firmID), typeof(PurchaseProjectProposalFirm));
                    DESCRIPTIONRTF.Value = firm.FinalAnnounceDescription;
                    PARTAGroup.firmID = string.Empty;
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

        public KesinlesenIhaleKarari()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Proje No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "KESINLESENIHALEKARARI";
            Caption = "Kesinleşen İhale Kararı";
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