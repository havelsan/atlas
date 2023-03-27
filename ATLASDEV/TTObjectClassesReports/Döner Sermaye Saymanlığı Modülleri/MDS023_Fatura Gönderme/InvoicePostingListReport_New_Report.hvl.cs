
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
    /// Fatura İcmal Listesi
    /// </summary>
    public partial class InvoicePostingListReport_New : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADGroup : TTReportGroup
        {
            public InvoicePostingListReport_New MyParentReport
            {
                get { return (InvoicePostingListReport_New)ParentReport; }
            }

            new public HEADGroupHeader Header()
            {
                return (HEADGroupHeader)_header;
            }

            new public HEADGroupFooter Footer()
            {
                return (HEADGroupFooter)_footer;
            }

            public HEADGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<InvoicePosting.InvoicePostingPayerQuery_Class>("InvoicePostingPayerQuery", InvoicePosting.InvoicePostingPayerQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADGroupHeader(this);
                _footer = new HEADGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADGroupHeader : TTReportSection
            {
                public InvoicePostingListReport_New MyParentReport
                {
                    get { return (InvoicePostingListReport_New)ParentReport; }
                }
                 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 3;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public InvoicePostingListReport_New MyParentReport
                {
                    get { return (InvoicePostingListReport_New)ParentReport; }
                }
                 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADGroup HEAD;

        public partial class ICMALGroup : TTReportGroup
        {
            public InvoicePostingListReport_New MyParentReport
            {
                get { return (InvoicePostingListReport_New)ParentReport; }
            }

            new public ICMALGroupHeader Header()
            {
                return (ICMALGroupHeader)_header;
            }

            new public ICMALGroupFooter Footer()
            {
                return (ICMALGroupFooter)_footer;
            }

            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField KURUMKODU { get {return Header().KURUMKODU;} }
            public TTReportField KURUMADI { get {return Header().KURUMADI;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField101 { get {return Header().NewField101;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField PAYEROBJECTID { get {return Header().PAYEROBJECTID;} }
            public TTReportField TOTAL { get {return Footer().TOTAL;} }
            public TTReportField NewField169 { get {return Footer().NewField169;} }
            public TTReportShape NewLine12 { get {return Footer().NewLine12;} }
            public TTReportField NewField1961 { get {return Footer().NewField1961;} }
            public ICMALGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ICMALGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ICMALGroupHeader(this);
                _footer = new ICMALGroupFooter(this);

            }

            public partial class ICMALGroupHeader : TTReportSection
            {
                public InvoicePostingListReport_New MyParentReport
                {
                    get { return (InvoicePostingListReport_New)ParentReport; }
                }
                
                public TTReportField NewField10;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField KURUMKODU;
                public TTReportField KURUMADI;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField NewField101;
                public TTReportShape NewLine11;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField PAYEROBJECTID; 
                public ICMALGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 36;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 7, 158, 12, false);
                    NewField10.Name = "NewField10";
                    NewField10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField10.TextFont.Name = "Arial";
                    NewField10.TextFont.Size = 9;
                    NewField10.TextFont.Bold = true;
                    NewField10.TextFont.Underline = true;
                    NewField10.Value = @"FATURA İCMAL LİSTESİ";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 17, 30, 21, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"Kurum No";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 22, 30, 26, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 9;
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"Kurum Adı";

                    KURUMKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 17, 74, 21, false);
                    KURUMKODU.Name = "KURUMKODU";
                    KURUMKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMKODU.TextFont.Name = "Arial";
                    KURUMKODU.TextFont.Size = 9;
                    KURUMKODU.Value = @"{#HEAD.PAYERCODE#}";

                    KURUMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 22, 206, 26, false);
                    KURUMADI.Name = "KURUMADI";
                    KURUMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMADI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    KURUMADI.TextFont.Name = "Arial";
                    KURUMADI.TextFont.Size = 9;
                    KURUMADI.Value = @"{#HEAD.PAYERNAME#}  {#HEAD.PAYERCITY#}";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 30, 23, 34, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Size = 9;
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @"Sıra";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 30, 56, 34, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Size = 9;
                    NewField16.TextFont.Bold = true;
                    NewField16.Value = @"Fatura No";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 30, 83, 34, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Name = "Arial";
                    NewField17.TextFont.Size = 9;
                    NewField17.TextFont.Bold = true;
                    NewField17.Value = @"Sicil No";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 30, 109, 34, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Name = "Arial";
                    NewField18.TextFont.Size = 9;
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @"Tarih";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 30, 182, 34, false);
                    NewField19.Name = "NewField19";
                    NewField19.TextFont.Name = "Arial";
                    NewField19.TextFont.Size = 9;
                    NewField19.TextFont.Bold = true;
                    NewField19.Value = @"Hasta Adı";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 30, 206, 34, false);
                    NewField101.Name = "NewField101";
                    NewField101.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField101.TextFont.Name = "Arial";
                    NewField101.TextFont.Size = 9;
                    NewField101.TextFont.Bold = true;
                    NewField101.Value = @"Toplam Tutar";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 35, 206, 35, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 17, 33, 21, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 9;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @":";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 22, 33, 26, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 9;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @":";

                    PAYEROBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 14, 256, 18, false);
                    PAYEROBJECTID.Name = "PAYEROBJECTID";
                    PAYEROBJECTID.Visible = EvetHayirEnum.ehHayir;
                    PAYEROBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYEROBJECTID.TextFont.Name = "Arial";
                    PAYEROBJECTID.TextFont.Size = 9;
                    PAYEROBJECTID.Value = @"{#HEAD.PAYEROBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InvoicePosting.InvoicePostingPayerQuery_Class dataset_InvoicePostingPayerQuery = MyParentReport.HEAD.rsGroup.GetCurrentRecord<InvoicePosting.InvoicePostingPayerQuery_Class>(0);
                    NewField10.CalcValue = NewField10.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    KURUMKODU.CalcValue = (dataset_InvoicePostingPayerQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPayerQuery.Payercode) : "");
                    KURUMADI.CalcValue = (dataset_InvoicePostingPayerQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPayerQuery.Payername) : "") + @"  " + (dataset_InvoicePostingPayerQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPayerQuery.Payercity) : "");
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField101.CalcValue = NewField101.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    PAYEROBJECTID.CalcValue = (dataset_InvoicePostingPayerQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPayerQuery.Payerobjectid) : "");
                    return new TTReportObject[] { NewField10,NewField11,NewField12,KURUMKODU,KURUMADI,NewField15,NewField16,NewField17,NewField18,NewField19,NewField101,NewField111,NewField1111,PAYEROBJECTID};
                }
            }
            public partial class ICMALGroupFooter : TTReportSection
            {
                public InvoicePostingListReport_New MyParentReport
                {
                    get { return (InvoicePostingListReport_New)ParentReport; }
                }
                
                public TTReportField TOTAL;
                public TTReportField NewField169;
                public TTReportShape NewLine12;
                public TTReportField NewField1961; 
                public ICMALGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 12;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 2, 200, 6, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    TOTAL.TextFormat = @"#,##0.#0";
                    TOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTAL.TextFont.Name = "Arial";
                    TOTAL.TextFont.Size = 9;
                    TOTAL.Value = @"{@sumof(TOTALPRICE)@}";

                    NewField169 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 2, 176, 6, false);
                    NewField169.Name = "NewField169";
                    NewField169.TextFont.Name = "Arial";
                    NewField169.TextFont.Size = 9;
                    NewField169.TextFont.Bold = true;
                    NewField169.Value = @"Genel Toplam :";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 1, 206, 1, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.DrawWidth = 2;

                    NewField1961 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 2, 206, 6, false);
                    NewField1961.Name = "NewField1961";
                    NewField1961.TextFont.Name = "Arial";
                    NewField1961.TextFont.Size = 9;
                    NewField1961.Value = @"TL";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField169.CalcValue = NewField169.Value;
                    NewField1961.CalcValue = NewField1961.Value;
                    TOTAL.CalcValue = ParentGroup.FieldSums["TOTALPRICE"].Value.ToString();;
                    return new TTReportObject[] { NewField169,NewField1961,TOTAL};
                }
            }

        }

        public ICMALGroup ICMAL;

        public partial class MAINGroup : TTReportGroup
        {
            public InvoicePostingListReport_New MyParentReport
            {
                get { return (InvoicePostingListReport_New)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SNO { get {return Body().SNO;} }
            public TTReportField INVOICENUMBER { get {return Body().INVOICENUMBER;} }
            public TTReportField INVOICEDATE { get {return Body().INVOICEDATE;} }
            public TTReportField PATIENTFULLNAME { get {return Body().PATIENTFULLNAME;} }
            public TTReportField TOTALPRICE { get {return Body().TOTALPRICE;} }
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
                list[0] = new TTReportNqlData<InvoicePosting.InvoicePostingListQuery_Class>("InvoicePostingListQuery", InvoicePosting.InvoicePostingListQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.ICMAL.PAYEROBJECTID.CalcValue)));
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
                public InvoicePostingListReport_New MyParentReport
                {
                    get { return (InvoicePostingListReport_New)ParentReport; }
                }
                
                public TTReportField SNO;
                public TTReportField INVOICENUMBER;
                public TTReportField INVOICEDATE;
                public TTReportField PATIENTFULLNAME;
                public TTReportField TOTALPRICE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    SNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 23, 4, false);
                    SNO.Name = "SNO";
                    SNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SNO.TextFont.Name = "Arial";
                    SNO.TextFont.Size = 9;
                    SNO.Value = @"{@groupcounter@}";

                    INVOICENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 0, 56, 4, false);
                    INVOICENUMBER.Name = "INVOICENUMBER";
                    INVOICENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    INVOICENUMBER.TextFont.Name = "Arial";
                    INVOICENUMBER.TextFont.Size = 9;
                    INVOICENUMBER.Value = @"{#DOCUMENTNO#}";

                    INVOICEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 0, 109, 4, false);
                    INVOICEDATE.Name = "INVOICEDATE";
                    INVOICEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    INVOICEDATE.TextFormat = @"Short Date";
                    INVOICEDATE.TextFont.Name = "Arial";
                    INVOICEDATE.TextFont.Size = 9;
                    INVOICEDATE.Value = @"{#DOCUMENTDATE#}";

                    PATIENTFULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 0, 182, 4, false);
                    PATIENTFULLNAME.Name = "PATIENTFULLNAME";
                    PATIENTFULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTFULLNAME.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTFULLNAME.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTFULLNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTFULLNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTFULLNAME.TextFont.Name = "Arial";
                    PATIENTFULLNAME.TextFont.Size = 9;
                    PATIENTFULLNAME.Value = @"{#PATIENTNAME#} {#PATIENTSURNAME#}";

                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 0, 206, 4, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPRICE.TextFont.Name = "Arial";
                    TOTALPRICE.TextFont.Size = 9;
                    TOTALPRICE.Value = @"{#GENERALTOTALPRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InvoicePosting.InvoicePostingListQuery_Class dataset_InvoicePostingListQuery = ParentGroup.rsGroup.GetCurrentRecord<InvoicePosting.InvoicePostingListQuery_Class>(0);
                    SNO.CalcValue = ParentGroup.GroupCounter.ToString();
                    INVOICENUMBER.CalcValue = (dataset_InvoicePostingListQuery != null ? Globals.ToStringCore(dataset_InvoicePostingListQuery.DocumentNo) : "");
                    INVOICEDATE.CalcValue = (dataset_InvoicePostingListQuery != null ? Globals.ToStringCore(dataset_InvoicePostingListQuery.DocumentDate) : "");
                    PATIENTFULLNAME.CalcValue = (dataset_InvoicePostingListQuery != null ? Globals.ToStringCore(dataset_InvoicePostingListQuery.Patientname) : "") + @" " + (dataset_InvoicePostingListQuery != null ? Globals.ToStringCore(dataset_InvoicePostingListQuery.Patientsurname) : "");
                    TOTALPRICE.CalcValue = (dataset_InvoicePostingListQuery != null ? Globals.ToStringCore(dataset_InvoicePostingListQuery.GeneralTotalPrice) : "");
                    return new TTReportObject[] { SNO,INVOICENUMBER,INVOICEDATE,PATIENTFULLNAME,TOTALPRICE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public InvoicePostingListReport_New()
        {
            HEAD = new HEADGroup(this,"HEAD");
            ICMAL = new ICMALGroup(HEAD,"ICMAL");
            MAIN = new MAINGroup(ICMAL,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action Object ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "INVOICEPOSTINGLISTREPORT_NEW";
            Caption = "Fatura İcmal Listesi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 1;
            p_PageWidth = 216;
            p_PageHeight = 279;
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