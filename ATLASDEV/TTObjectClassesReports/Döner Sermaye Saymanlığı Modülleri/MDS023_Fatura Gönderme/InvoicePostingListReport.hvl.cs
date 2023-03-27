
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
    /// Fatura Gönderme Fatura İcmal Listesi Raporu
    /// </summary>
    public partial class InvoicePostingListReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADGroup : TTReportGroup
        {
            public InvoicePostingListReport MyParentReport
            {
                get { return (InvoicePostingListReport)ParentReport; }
            }

            new public HEADGroupHeader Header()
            {
                return (HEADGroupHeader)_header;
            }

            new public HEADGroupFooter Footer()
            {
                return (HEADGroupFooter)_footer;
            }

            public TTReportField NewField0 { get {return Header().NewField0;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField KURUMKODU { get {return Header().KURUMKODU;} }
            public TTReportField KURUMADI { get {return Header().KURUMADI;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField7 { get {return Header().NewField7;} }
            public TTReportField NewField8 { get {return Header().NewField8;} }
            public TTReportField NewField9 { get {return Header().NewField9;} }
            public TTReportField NewField10 { get {return Header().NewField10;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField TOTAL { get {return Footer().TOTAL;} }
            public TTReportField NewField96 { get {return Footer().NewField96;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
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
                list[0] = new TTReportNqlData<InvoicePosting.InvoicePostingListReportQuery_Class>("InvoicePostingListReportQuery", InvoicePosting.InvoicePostingListReportQuery((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public InvoicePostingListReport MyParentReport
                {
                    get { return (InvoicePostingListReport)ParentReport; }
                }
                
                public TTReportField NewField0;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField KURUMKODU;
                public TTReportField KURUMADI;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportField NewField9;
                public TTReportField NewField10;
                public TTReportShape NewLine1; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 35;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 47, 6, 159, 11, false);
                    NewField0.Name = "NewField0";
                    NewField0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField0.TextFont.Bold = true;
                    NewField0.TextFont.Underline = true;
                    NewField0.Value = @"FATURA İCMAL LİSTESİ";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 16, 27, 20, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Size = 8;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"Kurum Kodu:";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 21, 27, 25, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Size = 8;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"Kurum Adı :";

                    KURUMKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 16, 68, 20, false);
                    KURUMKODU.Name = "KURUMKODU";
                    KURUMKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMKODU.TextFont.Size = 8;
                    KURUMKODU.TextFont.Bold = true;
                    KURUMKODU.Value = @"{#PAYERCODE#}";

                    KURUMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 21, 200, 25, false);
                    KURUMADI.Name = "KURUMADI";
                    KURUMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMADI.TextFont.Size = 8;
                    KURUMADI.TextFont.Bold = true;
                    KURUMADI.Value = @"{#PAYERNAME#}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 29, 15, 33, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Size = 8;
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @"Sıra";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 29, 37, 33, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Size = 8;
                    NewField6.TextFont.Bold = true;
                    NewField6.Value = @"Fatura No";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 29, 64, 33, false);
                    NewField7.Name = "NewField7";
                    NewField7.TextFont.Size = 8;
                    NewField7.TextFont.Bold = true;
                    NewField7.Value = @"Sicil No";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 29, 90, 33, false);
                    NewField8.Name = "NewField8";
                    NewField8.TextFont.Size = 8;
                    NewField8.TextFont.Bold = true;
                    NewField8.Value = @"Tarih";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 29, 165, 33, false);
                    NewField9.Name = "NewField9";
                    NewField9.TextFont.Size = 8;
                    NewField9.TextFont.Bold = true;
                    NewField9.Value = @"Hasta Adı";

                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 29, 200, 33, false);
                    NewField10.Name = "NewField10";
                    NewField10.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField10.TextFont.Size = 8;
                    NewField10.TextFont.Bold = true;
                    NewField10.Value = @"Toplam Tutar";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 34, 200, 34, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InvoicePosting.InvoicePostingListReportQuery_Class dataset_InvoicePostingListReportQuery = ParentGroup.rsGroup.GetCurrentRecord<InvoicePosting.InvoicePostingListReportQuery_Class>(0);
                    NewField0.CalcValue = NewField0.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    KURUMKODU.CalcValue = (dataset_InvoicePostingListReportQuery != null ? Globals.ToStringCore(dataset_InvoicePostingListReportQuery.Payercode) : "");
                    KURUMADI.CalcValue = (dataset_InvoicePostingListReportQuery != null ? Globals.ToStringCore(dataset_InvoicePostingListReportQuery.Payername) : "");
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField7.CalcValue = NewField7.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField10.CalcValue = NewField10.Value;
                    return new TTReportObject[] { NewField0,NewField1,NewField2,KURUMKODU,KURUMADI,NewField5,NewField6,NewField7,NewField8,NewField9,NewField10};
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public InvoicePostingListReport MyParentReport
                {
                    get { return (InvoicePostingListReport)ParentReport; }
                }
                
                public TTReportField TOTAL;
                public TTReportField NewField96;
                public TTReportShape NewLine2; 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 12;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 4, 200, 8, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    TOTAL.TextFormat = @"Currency";
                    TOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTAL.TextFont.Size = 8;
                    TOTAL.Value = @"{@sumof(TOTALPRICE)@}";

                    NewField96 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 4, 165, 8, false);
                    NewField96.Name = "NewField96";
                    NewField96.TextFont.Size = 9;
                    NewField96.TextFont.Bold = true;
                    NewField96.Value = @"Genel Toplam :";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 1, 200, 1, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine2.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InvoicePosting.InvoicePostingListReportQuery_Class dataset_InvoicePostingListReportQuery = ParentGroup.rsGroup.GetCurrentRecord<InvoicePosting.InvoicePostingListReportQuery_Class>(0);
                    NewField96.CalcValue = NewField96.Value;
                    TOTAL.CalcValue = ParentGroup.FieldSums["TOTALPRICE"].Value.ToString();;
                    return new TTReportObject[] { NewField96,TOTAL};
                }
            }

        }

        public HEADGroup HEAD;

        public partial class MAINGroup : TTReportGroup
        {
            public InvoicePostingListReport MyParentReport
            {
                get { return (InvoicePostingListReport)ParentReport; }
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
            public TTReportField PATIENTNO { get {return Body().PATIENTNO;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                InvoicePosting.InvoicePostingListReportQuery_Class dataSet_InvoicePostingListReportQuery = ParentGroup.rsGroup.GetCurrentRecord<InvoicePosting.InvoicePostingListReportQuery_Class>(0);    
                return new object[] {(dataSet_InvoicePostingListReportQuery==null ? null : dataSet_InvoicePostingListReportQuery.Payercode)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public InvoicePostingListReport MyParentReport
                {
                    get { return (InvoicePostingListReport)ParentReport; }
                }
                
                public TTReportField SNO;
                public TTReportField INVOICENUMBER;
                public TTReportField INVOICEDATE;
                public TTReportField PATIENTFULLNAME;
                public TTReportField TOTALPRICE;
                public TTReportField PATIENTNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    RepeatCount = 0;
                    
                    SNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 0, 15, 4, false);
                    SNO.Name = "SNO";
                    SNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SNO.TextFont.Size = 8;
                    SNO.Value = @"{@groupcounter@}";

                    INVOICENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 37, 4, false);
                    INVOICENUMBER.Name = "INVOICENUMBER";
                    INVOICENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    INVOICENUMBER.TextFont.Size = 8;
                    INVOICENUMBER.Value = @"{#HEAD.DOCUMENTNO#}";

                    INVOICEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 0, 90, 4, false);
                    INVOICEDATE.Name = "INVOICEDATE";
                    INVOICEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    INVOICEDATE.TextFormat = @"Short Date";
                    INVOICEDATE.TextFont.Size = 8;
                    INVOICEDATE.Value = @"{#HEAD.DOCUMENTDATE#}";

                    PATIENTFULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 0, 165, 4, false);
                    PATIENTFULLNAME.Name = "PATIENTFULLNAME";
                    PATIENTFULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTFULLNAME.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTFULLNAME.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTFULLNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTFULLNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTFULLNAME.TextFont.Size = 8;
                    PATIENTFULLNAME.Value = @"{#HEAD.PATIENTSURNAME#}, {#HEAD.PATIENTNAME#}";

                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 0, 200, 4, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"Currency";
                    TOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPRICE.TextFont.Size = 8;
                    TOTALPRICE.Value = @"{#HEAD.GENERALTOTALPRICE#}";

                    PATIENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 0, 247, 4, false);
                    PATIENTNO.Name = "PATIENTNO";
                    PATIENTNO.Visible = EvetHayirEnum.ehHayir;
                    PATIENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNO.TextFont.Size = 8;
                    PATIENTNO.Value = @"{#HEAD.PATIENTNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InvoicePosting.InvoicePostingListReportQuery_Class dataset_InvoicePostingListReportQuery = MyParentReport.HEAD.rsGroup.GetCurrentRecord<InvoicePosting.InvoicePostingListReportQuery_Class>(0);
                    SNO.CalcValue = ParentGroup.GroupCounter.ToString();
                    INVOICENUMBER.CalcValue = (dataset_InvoicePostingListReportQuery != null ? Globals.ToStringCore(dataset_InvoicePostingListReportQuery.DocumentNo) : "");
                    INVOICEDATE.CalcValue = (dataset_InvoicePostingListReportQuery != null ? Globals.ToStringCore(dataset_InvoicePostingListReportQuery.DocumentDate) : "");
                    PATIENTFULLNAME.CalcValue = (dataset_InvoicePostingListReportQuery != null ? Globals.ToStringCore(dataset_InvoicePostingListReportQuery.Patientsurname) : "") + @", " + (dataset_InvoicePostingListReportQuery != null ? Globals.ToStringCore(dataset_InvoicePostingListReportQuery.Patientname) : "");
                    TOTALPRICE.CalcValue = (dataset_InvoicePostingListReportQuery != null ? Globals.ToStringCore(dataset_InvoicePostingListReportQuery.GeneralTotalPrice) : "");
                    PATIENTNO.CalcValue = (dataset_InvoicePostingListReportQuery != null ? Globals.ToStringCore(dataset_InvoicePostingListReportQuery.Patientno) : "");
                    return new TTReportObject[] { SNO,INVOICENUMBER,INVOICEDATE,PATIENTFULLNAME,TOTALPRICE,PATIENTNO};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public InvoicePostingListReport()
        {
            HEAD = new HEADGroup(this,"HEAD");
            MAIN = new MAINGroup(HEAD,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action Object ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "INVOICEPOSTINGLISTREPORT";
            Caption = "Fatura İcmal Listesi Raporu";
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