
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
    public partial class OnayBelgesiEkliListe : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public OnayBelgesiEkliListe MyParentReport
            {
                get { return (OnayBelgesiEkliListe)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField ReportName11 { get {return Header().ReportName11;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField CONFIRMNO { get {return Header().CONFIRMNO;} }
            public TTReportField CONFIRMDATE { get {return Header().CONFIRMDATE;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewField111212 { get {return Header().NewField111212;} }
            public TTReportField NewField1212111 { get {return Header().NewField1212111;} }
            public TTReportField CONFIRMNO1 { get {return Footer().CONFIRMNO1;} }
            public TTReportField ATTACHMENTLISTPREPARERDUTY { get {return Footer().ATTACHMENTLISTPREPARERDUTY;} }
            public TTReportField CONFIRMNO11 { get {return Footer().CONFIRMNO11;} }
            public TTReportField ATTACHMENTLISTPREPARER { get {return Footer().ATTACHMENTLISTPREPARER;} }
            public TTReportField ATTACHMENTLISTCONFIRMERDUTY { get {return Footer().ATTACHMENTLISTCONFIRMERDUTY;} }
            public TTReportField ATTACHMENTLISTCONFIRMER { get {return Footer().ATTACHMENTLISTCONFIRMER;} }
            public TTReportField ATTACHMENTLISTCONFIRMERTITLE { get {return Footer().ATTACHMENTLISTCONFIRMERTITLE;} }
            public TTReportField ATTACHMENTLISTPREPARERTITLE { get {return Footer().ATTACHMENTLISTPREPARERTITLE;} }
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
                list[0] = new TTReportNqlData<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>("PurchaseProjectGlobalReportNQL", PurchaseProject.PurchaseProjectGlobalReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public OnayBelgesiEkliListe MyParentReport
                {
                    get { return (OnayBelgesiEkliListe)ParentReport; }
                }
                
                public TTReportField ReportName11;
                public TTReportField NewField121;
                public TTReportField NewField1121;
                public TTReportField CONFIRMNO;
                public TTReportField CONFIRMDATE;
                public TTReportField NewField11211;
                public TTReportField NewField111211;
                public TTReportField NewField111212;
                public TTReportField NewField1212111; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 36;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ReportName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 6, 199, 12, false);
                    ReportName11.Name = "ReportName11";
                    ReportName11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName11.TextFont.Name = "Arial";
                    ReportName11.TextFont.Bold = true;
                    ReportName11.TextFont.CharSet = 162;
                    ReportName11.Value = @"ONAY BELGESİ MALZEME LİSTESİ";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 15, 25, 20, false);
                    NewField121.Name = "NewField121";
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Onay No :";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 21, 25, 26, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Tarih       :";

                    CONFIRMNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 15, 73, 20, false);
                    CONFIRMNO.Name = "CONFIRMNO";
                    CONFIRMNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONFIRMNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONFIRMNO.TextFont.Name = "Arial";
                    CONFIRMNO.TextFont.CharSet = 162;
                    CONFIRMNO.Value = @"{#CONFIRMNO#}";

                    CONFIRMDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 21, 73, 26, false);
                    CONFIRMDATE.Name = "CONFIRMDATE";
                    CONFIRMDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONFIRMDATE.TextFormat = @"dd/MM/yyyy";
                    CONFIRMDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONFIRMDATE.TextFont.Name = "Arial";
                    CONFIRMDATE.TextFont.CharSet = 162;
                    CONFIRMDATE.Value = @"{#CONFIRMDATE#}";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 31, 25, 36, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11211.TextFont.Name = "Arial";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Sıra No";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 31, 150, 36, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111211.TextFont.Name = "Arial";
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Malzeme Adı";

                    NewField111212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 31, 172, 36, false);
                    NewField111212.Name = "NewField111212";
                    NewField111212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111212.TextFont.Name = "Arial";
                    NewField111212.TextFont.Bold = true;
                    NewField111212.TextFont.CharSet = 162;
                    NewField111212.Value = @"Miktarı";

                    NewField1212111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 31, 199, 36, false);
                    NewField1212111.Name = "NewField1212111";
                    NewField1212111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1212111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1212111.TextFont.Name = "Arial";
                    NewField1212111.TextFont.Bold = true;
                    NewField1212111.TextFont.CharSet = 162;
                    NewField1212111.Value = @"Ölçü Birimi";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectGlobalReportNQL_Class dataset_PurchaseProjectGlobalReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>(0);
                    ReportName11.CalcValue = ReportName11.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    CONFIRMNO.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ConfirmNO) : "");
                    CONFIRMDATE.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.ConfirmDate) : "");
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField111212.CalcValue = NewField111212.Value;
                    NewField1212111.CalcValue = NewField1212111.Value;
                    return new TTReportObject[] { ReportName11,NewField121,NewField1121,CONFIRMNO,CONFIRMDATE,NewField11211,NewField111211,NewField111212,NewField1212111};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public OnayBelgesiEkliListe MyParentReport
                {
                    get { return (OnayBelgesiEkliListe)ParentReport; }
                }
                
                public TTReportField CONFIRMNO1;
                public TTReportField ATTACHMENTLISTPREPARERDUTY;
                public TTReportField CONFIRMNO11;
                public TTReportField ATTACHMENTLISTPREPARER;
                public TTReportField ATTACHMENTLISTCONFIRMERDUTY;
                public TTReportField ATTACHMENTLISTCONFIRMER;
                public TTReportField ATTACHMENTLISTCONFIRMERTITLE;
                public TTReportField ATTACHMENTLISTPREPARERTITLE; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 45;
                    RepeatCount = 0;
                    
                    CONFIRMNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 6, 76, 11, false);
                    CONFIRMNO1.Name = "CONFIRMNO1";
                    CONFIRMNO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONFIRMNO1.TextFont.Name = "Arial";
                    CONFIRMNO1.TextFont.CharSet = 162;
                    CONFIRMNO1.Value = @"HAZIRLAYAN";

                    ATTACHMENTLISTPREPARERDUTY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 25, 76, 30, false);
                    ATTACHMENTLISTPREPARERDUTY.Name = "ATTACHMENTLISTPREPARERDUTY";
                    ATTACHMENTLISTPREPARERDUTY.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATTACHMENTLISTPREPARERDUTY.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ATTACHMENTLISTPREPARERDUTY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ATTACHMENTLISTPREPARERDUTY.TextFont.Name = "Arial";
                    ATTACHMENTLISTPREPARERDUTY.TextFont.CharSet = 162;
                    ATTACHMENTLISTPREPARERDUTY.Value = @"{#ATTACHMENTLISTPREPARERDUTY#}";

                    CONFIRMNO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 6, 171, 11, false);
                    CONFIRMNO11.Name = "CONFIRMNO11";
                    CONFIRMNO11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONFIRMNO11.TextFont.Name = "Arial";
                    CONFIRMNO11.TextFont.CharSet = 162;
                    CONFIRMNO11.Value = @"ONAYLAYAN";

                    ATTACHMENTLISTPREPARER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 13, 76, 18, false);
                    ATTACHMENTLISTPREPARER.Name = "ATTACHMENTLISTPREPARER";
                    ATTACHMENTLISTPREPARER.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATTACHMENTLISTPREPARER.CaseFormat = CaseFormatEnum.fcNameSurname;
                    ATTACHMENTLISTPREPARER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ATTACHMENTLISTPREPARER.TextFont.Name = "Arial";
                    ATTACHMENTLISTPREPARER.TextFont.CharSet = 162;
                    ATTACHMENTLISTPREPARER.Value = @"{#ATTLISTPREPARERNAME#}";

                    ATTACHMENTLISTCONFIRMERDUTY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 25, 171, 30, false);
                    ATTACHMENTLISTCONFIRMERDUTY.Name = "ATTACHMENTLISTCONFIRMERDUTY";
                    ATTACHMENTLISTCONFIRMERDUTY.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATTACHMENTLISTCONFIRMERDUTY.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ATTACHMENTLISTCONFIRMERDUTY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ATTACHMENTLISTCONFIRMERDUTY.TextFont.Name = "Arial";
                    ATTACHMENTLISTCONFIRMERDUTY.TextFont.CharSet = 162;
                    ATTACHMENTLISTCONFIRMERDUTY.Value = @"{#ATTACHMENTLISTCONFIRMERDUTY#}";

                    ATTACHMENTLISTCONFIRMER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 13, 171, 18, false);
                    ATTACHMENTLISTCONFIRMER.Name = "ATTACHMENTLISTCONFIRMER";
                    ATTACHMENTLISTCONFIRMER.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATTACHMENTLISTCONFIRMER.CaseFormat = CaseFormatEnum.fcNameSurname;
                    ATTACHMENTLISTCONFIRMER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ATTACHMENTLISTCONFIRMER.TextFont.Name = "Arial";
                    ATTACHMENTLISTCONFIRMER.TextFont.CharSet = 162;
                    ATTACHMENTLISTCONFIRMER.Value = @"{#ATTLISTCONFIRMERNAME#}";

                    ATTACHMENTLISTCONFIRMERTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 19, 171, 24, false);
                    ATTACHMENTLISTCONFIRMERTITLE.Name = "ATTACHMENTLISTCONFIRMERTITLE";
                    ATTACHMENTLISTCONFIRMERTITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATTACHMENTLISTCONFIRMERTITLE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ATTACHMENTLISTCONFIRMERTITLE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ATTACHMENTLISTCONFIRMERTITLE.TextFont.Name = "Arial";
                    ATTACHMENTLISTCONFIRMERTITLE.TextFont.CharSet = 162;
                    ATTACHMENTLISTCONFIRMERTITLE.Value = @"{#ATTLISTCONFIRMERTITLE#}";

                    ATTACHMENTLISTPREPARERTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 19, 76, 24, false);
                    ATTACHMENTLISTPREPARERTITLE.Name = "ATTACHMENTLISTPREPARERTITLE";
                    ATTACHMENTLISTPREPARERTITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ATTACHMENTLISTPREPARERTITLE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ATTACHMENTLISTPREPARERTITLE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ATTACHMENTLISTPREPARERTITLE.TextFont.Name = "Arial";
                    ATTACHMENTLISTPREPARERTITLE.TextFont.CharSet = 162;
                    ATTACHMENTLISTPREPARERTITLE.Value = @"{#ATTLISTPREPARERTITLE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.PurchaseProjectGlobalReportNQL_Class dataset_PurchaseProjectGlobalReportNQL = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>(0);
                    CONFIRMNO1.CalcValue = CONFIRMNO1.Value;
                    ATTACHMENTLISTPREPARERDUTY.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.AttachmentListPreparerDuty) : "");
                    CONFIRMNO11.CalcValue = CONFIRMNO11.Value;
                    ATTACHMENTLISTPREPARER.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Attlistpreparername) : "");
                    ATTACHMENTLISTCONFIRMERDUTY.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.AttachmentListConfirmerDuty) : "");
                    ATTACHMENTLISTCONFIRMER.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Attlistconfirmername) : "");
                    ATTACHMENTLISTCONFIRMERTITLE.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Attlistconfirmertitle) : "");
                    ATTACHMENTLISTPREPARERTITLE.CalcValue = (dataset_PurchaseProjectGlobalReportNQL != null ? Globals.ToStringCore(dataset_PurchaseProjectGlobalReportNQL.Attlistpreparertitle) : "");
                    return new TTReportObject[] { CONFIRMNO1,ATTACHMENTLISTPREPARERDUTY,CONFIRMNO11,ATTACHMENTLISTPREPARER,ATTACHMENTLISTCONFIRMERDUTY,ATTACHMENTLISTCONFIRMER,ATTACHMENTLISTCONFIRMERTITLE,ATTACHMENTLISTPREPARERTITLE};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public OnayBelgesiEkliListe MyParentReport
            {
                get { return (OnayBelgesiEkliListe)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField PURCHASEITEMDEF { get {return Body().PURCHASEITEMDEF;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField TEMPDISTRIBUTIONTYPE { get {return Body().TEMPDISTRIBUTIONTYPE;} }
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
                list[0] = new TTReportNqlData<PurchaseProjectDetail.GetProjectDetails_Class>("GetProjectDetails", PurchaseProjectDetail.GetProjectDetails((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public OnayBelgesiEkliListe MyParentReport
                {
                    get { return (OnayBelgesiEkliListe)ParentReport; }
                }
                
                public TTReportField ORDERNO;
                public TTReportField PURCHASEITEMDEF;
                public TTReportField AMOUNT;
                public TTReportField TEMPDISTRIBUTIONTYPE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 25, 5, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{@counter@}";

                    PURCHASEITEMDEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 0, 150, 5, false);
                    PURCHASEITEMDEF.Name = "PURCHASEITEMDEF";
                    PURCHASEITEMDEF.DrawStyle = DrawStyleConstants.vbSolid;
                    PURCHASEITEMDEF.FieldType = ReportFieldTypeEnum.ftVariable;
                    PURCHASEITEMDEF.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PURCHASEITEMDEF.TextFont.Name = "Arial";
                    PURCHASEITEMDEF.TextFont.CharSet = 162;
                    PURCHASEITEMDEF.Value = @"{#PURCHASEITEMNAME#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 0, 172, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    TEMPDISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 0, 199, 5, false);
                    TEMPDISTRIBUTIONTYPE.Name = "TEMPDISTRIBUTIONTYPE";
                    TEMPDISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    TEMPDISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEMPDISTRIBUTIONTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TEMPDISTRIBUTIONTYPE.TextFont.Name = "Arial";
                    TEMPDISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    TEMPDISTRIBUTIONTYPE.Value = @"{#PURCHASEITEMUNITTYPENAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProjectDetail.GetProjectDetails_Class dataset_GetProjectDetails = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProjectDetail.GetProjectDetails_Class>(0);
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString();
                    PURCHASEITEMDEF.CalcValue = (dataset_GetProjectDetails != null ? Globals.ToStringCore(dataset_GetProjectDetails.Purchaseitemname) : "");
                    AMOUNT.CalcValue = (dataset_GetProjectDetails != null ? Globals.ToStringCore(dataset_GetProjectDetails.Amount) : "");
                    TEMPDISTRIBUTIONTYPE.CalcValue = (dataset_GetProjectDetails != null ? Globals.ToStringCore(dataset_GetProjectDetails.Purchaseitemunittypename) : "");
                    return new TTReportObject[] { ORDERNO,PURCHASEITEMDEF,AMOUNT,TEMPDISTRIBUTIONTYPE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public OnayBelgesiEkliListe()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "ONAYBELGESIEKLILISTE";
            Caption = "Onay Belgesi Ekli Liste";
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
            fd.TextFont.Name = "Arial Narrow";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 1;
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