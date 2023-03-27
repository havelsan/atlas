
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
    /// Teklif Vermeye Davet_KİK024.0/M
    /// </summary>
    public partial class SozlesmeyeDavet : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public SozlesmeyeDavet MyParentReport
            {
                get { return (SozlesmeyeDavet)ParentReport; }
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
            public TTReportField SUPPLIERADDRESS { get {return Header().SUPPLIERADDRESS;} }
            public TTReportField SUPPLIER { get {return Header().SUPPLIER;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField KIKTENDERREGISTERNO { get {return Header().KIKTENDERREGISTERNO;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField PROJECTNO13 { get {return Header().PROJECTNO13;} }
            public TTReportField ORDERNO { get {return Header().ORDERNO;} }
            public TTReportField HOSPITAL { get {return Header().HOSPITAL;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField CONCLUSIONAPPROVEDATE { get {return Header().CONCLUSIONAPPROVEDATE;} }
            public TTReportField PROPOSALOBJECTID { get {return Header().PROPOSALOBJECTID;} }
            public TTReportField PROJECTNO15 { get {return Header().PROJECTNO15;} }
            public TTReportField ILGI { get {return Header().ILGI;} }
            public TTReportField TTOBJECTID { get {return Header().TTOBJECTID;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField ORDERNO1 { get {return Header().ORDERNO1;} }
            public TTReportField ILGI1 { get {return Header().ILGI1;} }
            public TTReportField ADMINAUTHORIZED { get {return Footer().ADMINAUTHORIZED;} }
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
                list[0] = new TTReportNqlData<ProposalDetail.GetWinnerFirmsWithObjectID_Class>("GetWinnerFirmsWithObjectID", ProposalDetail.GetWinnerFirmsWithObjectID((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public SozlesmeyeDavet MyParentReport
                {
                    get { return (SozlesmeyeDavet)ParentReport; }
                }
                
                public TTReportField PROJECTNO4;
                public TTReportField SUPPLIERADDRESS;
                public TTReportField SUPPLIER;
                public TTReportField NewField12;
                public TTReportField NewField1;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField KIKTENDERREGISTERNO;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField PROJECTNO13;
                public TTReportField ORDERNO;
                public TTReportField HOSPITAL;
                public TTReportField NewField121;
                public TTReportField NewField11;
                public TTReportField CONCLUSIONAPPROVEDATE;
                public TTReportField PROPOSALOBJECTID;
                public TTReportField PROJECTNO15;
                public TTReportField ILGI;
                public TTReportField TTOBJECTID;
                public TTReportField DATE;
                public TTReportField ORDERNO1;
                public TTReportField ILGI1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 116;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PROJECTNO4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 69, 170, 78, false);
                    PROJECTNO4.Name = "PROJECTNO4";
                    PROJECTNO4.TextColor = System.Drawing.Color.Gray;
                    PROJECTNO4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO4.MultiLine = EvetHayirEnum.ehEvet;
                    PROJECTNO4.WordBreak = EvetHayirEnum.ehEvet;
                    PROJECTNO4.TextFont.Name = "Arial";
                    PROJECTNO4.TextFont.Italic = true;
                    PROJECTNO4.Value = @"                                                                [elden verilmiştir / iadeli taahhütlü posta yoluyla / elektronik posta yoluyla / faksla gönderilmiştir].";

                    SUPPLIERADDRESS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 83, 15, 88, false);
                    SUPPLIERADDRESS.Name = "SUPPLIERADDRESS";
                    SUPPLIERADDRESS.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SUPPLIERADDRESS.TextFont.Name = "Arial";
                    SUPPLIERADDRESS.Value = @"Sayın";

                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 83, 170, 100, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER.MultiLine = EvetHayirEnum.ehEvet;
                    SUPPLIER.WordBreak = EvetHayirEnum.ehEvet;
                    SUPPLIER.TextFont.Name = "Arial";
                    SUPPLIER.TextFont.Bold = true;
                    SUPPLIER.Value = @"";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 45, 50, 50, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Name = "Arial";
                    NewField12.Value = @"İhale kayıt numarası";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 45, 52, 50, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @":";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 50, 50, 55, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Name = "Arial";
                    NewField13.Value = @"SAYI";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 50, 52, 55, false);
                    NewField14.Name = "NewField14";
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @":";

                    KIKTENDERREGISTERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 45, 170, 50, false);
                    KIKTENDERREGISTERNO.Name = "KIKTENDERREGISTERNO";
                    KIKTENDERREGISTERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KIKTENDERREGISTERNO.TextFont.Name = "Arial";
                    KIKTENDERREGISTERNO.TextFont.Bold = true;
                    KIKTENDERREGISTERNO.Value = @"";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 55, 50, 60, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Name = "Arial";
                    NewField15.Value = @"KONU";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 55, 52, 60, false);
                    NewField16.Name = "NewField16";
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Bold = true;
                    NewField16.Value = @":";

                    PROJECTNO13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 55, 170, 60, false);
                    PROJECTNO13.Name = "PROJECTNO13";
                    PROJECTNO13.TextFont.Name = "Arial";
                    PROJECTNO13.Value = @"Sözleşmeye davet";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 50, 170, 55, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.Bold = true;
                    ORDERNO.Value = @"";

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

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 60, 50, 65, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Name = "Arial";
                    NewField121.Value = @"İhale kararının onaylandığı tarih";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 60, 52, 65, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @":";

                    CONCLUSIONAPPROVEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 60, 170, 65, false);
                    CONCLUSIONAPPROVEDATE.Name = "CONCLUSIONAPPROVEDATE";
                    CONCLUSIONAPPROVEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONCLUSIONAPPROVEDATE.TextFormat = @"dd/MM/yyyy";
                    CONCLUSIONAPPROVEDATE.TextFont.Name = "Arial";
                    CONCLUSIONAPPROVEDATE.TextFont.Bold = true;
                    CONCLUSIONAPPROVEDATE.Value = @"";

                    PROPOSALOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 76, 222, 81, false);
                    PROPOSALOBJECTID.Name = "PROPOSALOBJECTID";
                    PROPOSALOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    PROPOSALOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROPOSALOBJECTID.Value = @"{#PROPOSALOBJECTID#}";

                    PROJECTNO15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 108, 10, 113, false);
                    PROJECTNO15.Name = "PROJECTNO15";
                    PROJECTNO15.TextFont.Name = "Arial";
                    PROJECTNO15.Value = @"İLGİ:";

                    ILGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 108, 48, 113, false);
                    ILGI.Name = "ILGI";
                    ILGI.TextFont.Name = "Arial";
                    ILGI.Value = @"_ _/_ _/_ _ _ _ tarihinde,";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 197, 84, 222, 89, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.TextFont.Name = "Arial Narrow";
                    TTOBJECTID.TextFont.CharSet = 1;
                    TTOBJECTID.Value = @"{@TTOBJECTID@}";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 69, 62, 73, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFont.Name = "Arial";
                    DATE.Value = @"";

                    ORDERNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 108, 54, 113, false);
                    ORDERNO1.Name = "ORDERNO1";
                    ORDERNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO1.TextFont.Name = "Arial";
                    ORDERNO1.TextFont.Bold = true;
                    ORDERNO1.Value = @"";

                    ILGI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 108, 155, 113, false);
                    ILGI1.Name = "ILGI1";
                    ILGI1.TextFont.Name = "Arial";
                    ILGI1.Value = @" sıra numarası ile kayda alınan teklifiniz.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ProposalDetail.GetWinnerFirmsWithObjectID_Class dataset_GetWinnerFirmsWithObjectID = ParentGroup.rsGroup.GetCurrentRecord<ProposalDetail.GetWinnerFirmsWithObjectID_Class>(0);
                    PROJECTNO4.CalcValue = PROJECTNO4.Value;
                    SUPPLIERADDRESS.CalcValue = SUPPLIERADDRESS.Value;
                    SUPPLIER.CalcValue = @"";
                    NewField12.CalcValue = NewField12.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    KIKTENDERREGISTERNO.CalcValue = @"";
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    PROJECTNO13.CalcValue = PROJECTNO13.Value;
                    ORDERNO.CalcValue = @"";
                    HOSPITAL.CalcValue = @"";
                    NewField121.CalcValue = NewField121.Value;
                    NewField11.CalcValue = NewField11.Value;
                    CONCLUSIONAPPROVEDATE.CalcValue = @"";
                    PROPOSALOBJECTID.CalcValue = (dataset_GetWinnerFirmsWithObjectID != null ? Globals.ToStringCore(dataset_GetWinnerFirmsWithObjectID.Proposalobjectid) : "");
                    PROJECTNO15.CalcValue = PROJECTNO15.Value;
                    ILGI.CalcValue = ILGI.Value;
                    TTOBJECTID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    DATE.CalcValue = @"";
                    ORDERNO1.CalcValue = @"";
                    ILGI1.CalcValue = ILGI1.Value;
                    return new TTReportObject[] { PROJECTNO4,SUPPLIERADDRESS,SUPPLIER,NewField12,NewField1,NewField13,NewField14,KIKTENDERREGISTERNO,NewField15,NewField16,PROJECTNO13,ORDERNO,HOSPITAL,NewField121,NewField11,CONCLUSIONAPPROVEDATE,PROPOSALOBJECTID,PROJECTNO15,ILGI,TTOBJECTID,DATE,ORDERNO1,ILGI1};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    HOSPITAL.CalcValue = "T.C.\nXXXXXX\n"
                + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","") + "\n"
                + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY","");
            
            DATE.CalcValue = "Bu mektup          /         / " + DateTime.Now.Year.ToString() + " tarihinde ";
            
            TTObjectContext context = new TTObjectContext(true);
            string sObjectID = PROPOSALOBJECTID.CalcValue;
            Proposal prop = (Proposal)context.GetObject(new Guid(sObjectID),"Proposal");
            if(prop != null)
            {
                if(prop.Supplier != null)
                {
                    SUPPLIER.CalcValue = prop.Supplier.Name + "\n" + prop.Supplier.Address + "\nTEL: " + prop.Supplier.Telephone;
                }
                if(prop.PurchaseProject != null)
                {
                    CONCLUSIONAPPROVEDATE.CalcValue = prop.PurchaseProject.ConclusionApproveDate.ToString();
                    KIKTENDERREGISTERNO.CalcValue = prop.PurchaseProject.KIKTenderRegisterNO;
                }
            }
            BindingList<PurchaseProjectProposalFirm.GetFirmOrderNOQuery_Class> orderNO = PurchaseProjectProposalFirm.GetFirmOrderNOQuery(context, TTOBJECTID.CalcValue, sObjectID);
            ORDERNO1.CalcValue =  orderNO[0].OrderNo.ToString();
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public SozlesmeyeDavet MyParentReport
                {
                    get { return (SozlesmeyeDavet)ParentReport; }
                }
                
                public TTReportField ADMINAUTHORIZED; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 60;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    ADMINAUTHORIZED = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 0, 170, 5, false);
                    ADMINAUTHORIZED.Name = "ADMINAUTHORIZED";
                    ADMINAUTHORIZED.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADMINAUTHORIZED.MultiLine = EvetHayirEnum.ehEvet;
                    ADMINAUTHORIZED.NoClip = EvetHayirEnum.ehEvet;
                    ADMINAUTHORIZED.WordBreak = EvetHayirEnum.ehEvet;
                    ADMINAUTHORIZED.TextFont.Name = "Arial";
                    ADMINAUTHORIZED.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ProposalDetail.GetWinnerFirmsWithObjectID_Class dataset_GetWinnerFirmsWithObjectID = ParentGroup.rsGroup.GetCurrentRecord<ProposalDetail.GetWinnerFirmsWithObjectID_Class>(0);
                    ADMINAUTHORIZED.CalcValue = @"";
                    return new TTReportObject[] { ADMINAUTHORIZED};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    PurchaseProject purchaseProject = (PurchaseProject)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(PurchaseProject));
                    if (purchaseProject.AdminAuthorized != null)
                    {
                        ADMINAUTHORIZED.CalcValue = "  İdare Yetkilisi\n\n" + purchaseProject.AdminAuthorized.Name + "\n";
                        if (purchaseProject.AdminAuthorized.MilitaryClass != null)
                            ADMINAUTHORIZED.CalcValue += purchaseProject.AdminAuthorized.MilitaryClass.Name + " ";
                        if(purchaseProject.AdminAuthorized.Rank != null)
                            ADMINAUTHORIZED.CalcValue += purchaseProject.AdminAuthorized.Rank.Name + "\n";
                        ADMINAUTHORIZED.CalcValue += TTObjectClasses.Common.GetEnumValueDefOfEnumValue(purchaseProject.AdminAuthorized.Title.Value).DisplayText;
                    }
#endregion PARTB FOOTER_Script
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public SozlesmeyeDavet MyParentReport
            {
                get { return (SozlesmeyeDavet)ParentReport; }
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
                public SozlesmeyeDavet MyParentReport
                {
                    get { return (SozlesmeyeDavet)ParentReport; }
                }
                
                public TTReportRTF ReportRTF; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 13;
                    RepeatCount = 0;
                    
                    ReportRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 0, 5, 170, 10, false);
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
                    PurchaseProject purchaseProject = (PurchaseProject)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(PurchaseProject));
            ReportRTF.Value = purchaseProject.ContractInviteFormDesc.ToString();
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

        public SozlesmeyeDavet()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "Proje No", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "SOZLESMEYEDAVET";
            Caption = "Sözleşmeye Davet";
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