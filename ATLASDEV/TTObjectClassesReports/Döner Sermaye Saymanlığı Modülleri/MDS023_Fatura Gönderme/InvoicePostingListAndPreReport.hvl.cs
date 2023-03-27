
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
    /// Fatura İcmal Listesi ve Önyazı Raporu
    /// </summary>
    public partial class InvoicePostingListAndPreReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADGroup : TTReportGroup
        {
            public InvoicePostingListAndPreReport MyParentReport
            {
                get { return (InvoicePostingListAndPreReport)ParentReport; }
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
                public InvoicePostingListAndPreReport MyParentReport
                {
                    get { return (InvoicePostingListAndPreReport)ParentReport; }
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
                public InvoicePostingListAndPreReport MyParentReport
                {
                    get { return (InvoicePostingListAndPreReport)ParentReport; }
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
            public InvoicePostingListAndPreReport MyParentReport
            {
                get { return (InvoicePostingListAndPreReport)ParentReport; }
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
                public InvoicePostingListAndPreReport MyParentReport
                {
                    get { return (InvoicePostingListAndPreReport)ParentReport; }
                }
                
                public TTReportField NewField10;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField KURUMKODU;
                public TTReportField KURUMADI;
                public TTReportField NewField15;
                public TTReportField NewField16;
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
                    
                    Height = 38;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 7, 158, 12, false);
                    NewField10.Name = "NewField10";
                    NewField10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField10.TextFont.Name = "Arial";
                    NewField10.TextFont.Size = 11;
                    NewField10.TextFont.Underline = true;
                    NewField10.Value = @"FATURA İCMAL LİSTESİ";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 14, 32, 19, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 11;
                    NewField11.Value = @"Kurum No";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 20, 32, 25, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 11;
                    NewField12.Value = @"Kurum Adı";

                    KURUMKODU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 14, 76, 19, false);
                    KURUMKODU.Name = "KURUMKODU";
                    KURUMKODU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMKODU.TextFont.Name = "Arial";
                    KURUMKODU.TextFont.Size = 11;
                    KURUMKODU.Value = @"{#HEAD.PAYERCODE#}";

                    KURUMADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 20, 206, 30, false);
                    KURUMADI.Name = "KURUMADI";
                    KURUMADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUMADI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    KURUMADI.MultiLine = EvetHayirEnum.ehEvet;
                    KURUMADI.NoClip = EvetHayirEnum.ehEvet;
                    KURUMADI.WordBreak = EvetHayirEnum.ehEvet;
                    KURUMADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURUMADI.TextFont.Name = "Arial";
                    KURUMADI.TextFont.Size = 11;
                    KURUMADI.Value = @"{#HEAD.PAYERNAME#}  {#HEAD.PAYERCITY#}";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 31, 23, 36, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Size = 11;
                    NewField15.Value = @"Sıra";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 31, 72, 36, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Size = 11;
                    NewField16.Value = @"Fatura No";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 31, 122, 36, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Name = "Arial";
                    NewField18.TextFont.Size = 11;
                    NewField18.Value = @"Tarih";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 31, 182, 36, false);
                    NewField19.Name = "NewField19";
                    NewField19.TextFont.Name = "Arial";
                    NewField19.TextFont.Size = 11;
                    NewField19.Value = @"Hasta Adı";

                    NewField101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 31, 206, 36, false);
                    NewField101.Name = "NewField101";
                    NewField101.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField101.TextFont.Name = "Arial";
                    NewField101.TextFont.Size = 11;
                    NewField101.Value = @"Toplam Tutar";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 37, 206, 37, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 14, 35, 19, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 11;
                    NewField111.Value = @":";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 20, 35, 25, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 11;
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
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField101.CalcValue = NewField101.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    PAYEROBJECTID.CalcValue = (dataset_InvoicePostingPayerQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPayerQuery.Payerobjectid) : "");
                    return new TTReportObject[] { NewField10,NewField11,NewField12,KURUMKODU,KURUMADI,NewField15,NewField16,NewField18,NewField19,NewField101,NewField111,NewField1111,PAYEROBJECTID};
                }
            }
            public partial class ICMALGroupFooter : TTReportSection
            {
                public InvoicePostingListAndPreReport MyParentReport
                {
                    get { return (InvoicePostingListAndPreReport)ParentReport; }
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
                    
                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 2, 200, 7, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.FieldType = ReportFieldTypeEnum.ftExpression;
                    TOTAL.TextFormat = @"#,##0.#0";
                    TOTAL.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTAL.TextFont.Name = "Arial";
                    TOTAL.TextFont.Size = 11;
                    TOTAL.Value = @"{@sumof(TOTALPRICE)@}";

                    NewField169 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 2, 169, 7, false);
                    NewField169.Name = "NewField169";
                    NewField169.TextFont.Name = "Arial";
                    NewField169.TextFont.Size = 11;
                    NewField169.Value = @"Genel Toplam :";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 1, 206, 1, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1961 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 202, 2, 206, 7, false);
                    NewField1961.Name = "NewField1961";
                    NewField1961.TextFont.Name = "Arial";
                    NewField1961.TextFont.Size = 11;
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
            public InvoicePostingListAndPreReport MyParentReport
            {
                get { return (InvoicePostingListAndPreReport)ParentReport; }
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
                public InvoicePostingListAndPreReport MyParentReport
                {
                    get { return (InvoicePostingListAndPreReport)ParentReport; }
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
                    
                    SNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 23, 5, false);
                    SNO.Name = "SNO";
                    SNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SNO.TextFont.Name = "Arial";
                    SNO.TextFont.Size = 11;
                    SNO.Value = @"{@groupcounter@}";

                    INVOICENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 0, 72, 5, false);
                    INVOICENUMBER.Name = "INVOICENUMBER";
                    INVOICENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    INVOICENUMBER.TextFont.Name = "Arial";
                    INVOICENUMBER.TextFont.Size = 11;
                    INVOICENUMBER.Value = @"{#DOCUMENTNO#}";

                    INVOICEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 0, 122, 5, false);
                    INVOICEDATE.Name = "INVOICEDATE";
                    INVOICEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    INVOICEDATE.TextFormat = @"dd/MM/yyyy";
                    INVOICEDATE.TextFont.Name = "Arial";
                    INVOICEDATE.TextFont.Size = 11;
                    INVOICEDATE.Value = @"{#DOCUMENTDATE#}";

                    PATIENTFULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 0, 182, 5, false);
                    PATIENTFULLNAME.Name = "PATIENTFULLNAME";
                    PATIENTFULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTFULLNAME.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTFULLNAME.NoClip = EvetHayirEnum.ehEvet;
                    PATIENTFULLNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTFULLNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PATIENTFULLNAME.TextFont.Name = "Arial";
                    PATIENTFULLNAME.TextFont.Size = 11;
                    PATIENTFULLNAME.Value = @"{#PATIENTNAME#} {#PATIENTSURNAME#}";

                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 0, 206, 5, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"#,##0.#0";
                    TOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPRICE.TextFont.Name = "Arial";
                    TOTALPRICE.TextFont.Size = 11;
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

        public partial class ONYAZIPARENTGroup : TTReportGroup
        {
            public InvoicePostingListAndPreReport MyParentReport
            {
                get { return (InvoicePostingListAndPreReport)ParentReport; }
            }

            new public ONYAZIPARENTGroupHeader Header()
            {
                return (ONYAZIPARENTGroupHeader)_header;
            }

            new public ONYAZIPARENTGroupFooter Footer()
            {
                return (ONYAZIPARENTGroupFooter)_footer;
            }

            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField1152 { get {return Footer().NewField1152;} }
            public ONYAZIPARENTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ONYAZIPARENTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ONYAZIPARENTGroupHeader(this);
                _footer = new ONYAZIPARENTGroupFooter(this);

            }

            public partial class ONYAZIPARENTGroupHeader : TTReportSection
            {
                public InvoicePostingListAndPreReport MyParentReport
                {
                    get { return (InvoicePostingListAndPreReport)ParentReport; }
                }
                
                public TTReportField NewField151; 
                public ONYAZIPARENTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 17, 42, 22, false);
                    NewField151.Name = "NewField151";
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.Size = 11;
                    NewField151.TextFont.Underline = true;
                    NewField151.Value = @"HİZMETE ÖZEL";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField151.CalcValue = NewField151.Value;
                    return new TTReportObject[] { NewField151};
                }
            }
            public partial class ONYAZIPARENTGroupFooter : TTReportSection
            {
                public InvoicePostingListAndPreReport MyParentReport
                {
                    get { return (InvoicePostingListAndPreReport)ParentReport; }
                }
                
                public TTReportField NewField1152; 
                public ONYAZIPARENTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 19;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 3, 42, 8, false);
                    NewField1152.Name = "NewField1152";
                    NewField1152.TextFont.Name = "Arial";
                    NewField1152.TextFont.Size = 11;
                    NewField1152.TextFont.Underline = true;
                    NewField1152.Value = @"HİZMETE ÖZEL";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1152.CalcValue = NewField1152.Value;
                    return new TTReportObject[] { NewField1152};
                }
            }

        }

        public ONYAZIPARENTGroup ONYAZIPARENT;

        public partial class ONYAZIGroup : TTReportGroup
        {
            public InvoicePostingListAndPreReport MyParentReport
            {
                get { return (InvoicePostingListAndPreReport)ParentReport; }
            }

            new public ONYAZIGroupBody Body()
            {
                return (ONYAZIGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField SUBJECT { get {return Body().SUBJECT;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField BASLIK { get {return Body().BASLIK;} }
            public TTReportField PAYERTEXT { get {return Body().PAYERTEXT;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField BODYTEXT { get {return Body().BODYTEXT;} }
            public TTReportField AMOUNTOFINVOICE { get {return Body().AMOUNTOFINVOICE;} }
            public TTReportField AMOUNTOFTRANSFERDOCUMENT { get {return Body().AMOUNTOFTRANSFERDOCUMENT;} }
            public TTReportField AMOUNTOFINVOICEPOSTINGLIST { get {return Body().AMOUNTOFINVOICEPOSTINGLIST;} }
            public TTReportField SIGNATUREBLOCK { get {return Body().SIGNATUREBLOCK;} }
            public TTReportField HOSPITALNAME { get {return Body().HOSPITALNAME;} }
            public TTReportField INVOICEAMOUNT { get {return Body().INVOICEAMOUNT;} }
            public TTReportField TOTALINVOICEPRICE { get {return Body().TOTALINVOICEPRICE;} }
            public TTReportField BANKIBANINFO { get {return Body().BANKIBANINFO;} }
            public TTReportField DOSENO { get {return Body().DOSENO;} }
            public TTReportField XXXXXXADI { get {return Body().XXXXXXADI;} }
            public TTReportField EKLER1 { get {return Body().EKLER1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportField DATE { get {return Body().DATE;} }
            public TTReportField EMAIL { get {return Body().EMAIL;} }
            public ONYAZIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ONYAZIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ONYAZIGroupBody(this);
            }

            public partial class ONYAZIGroupBody : TTReportSection
            {
                public InvoicePostingListAndPreReport MyParentReport
                {
                    get { return (InvoicePostingListAndPreReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField SUBJECT;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField TARIH;
                public TTReportField BASLIK;
                public TTReportField PAYERTEXT;
                public TTReportField NewField11;
                public TTReportField BODYTEXT;
                public TTReportField AMOUNTOFINVOICE;
                public TTReportField AMOUNTOFTRANSFERDOCUMENT;
                public TTReportField AMOUNTOFINVOICEPOSTINGLIST;
                public TTReportField SIGNATUREBLOCK;
                public TTReportField HOSPITALNAME;
                public TTReportField INVOICEAMOUNT;
                public TTReportField TOTALINVOICEPRICE;
                public TTReportField BANKIBANINFO;
                public TTReportField DOSENO;
                public TTReportField XXXXXXADI;
                public TTReportField EKLER1;
                public TTReportShape NewLine11;
                public TTReportField DATE;
                public TTReportField EMAIL; 
                public ONYAZIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 208;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 33, 38, 38, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 11;
                    NewField1.Value = @"DÖSE İŞL.";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 39, 38, 44, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 11;
                    NewField12.Value = @"KONU";

                    SUBJECT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 39, 99, 44, false);
                    SUBJECT.Name = "SUBJECT";
                    SUBJECT.TextFont.Name = "Arial";
                    SUBJECT.TextFont.Size = 11;
                    SUBJECT.Value = @"Tedavi Giderleri Hk.";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 33, 41, 38, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 11;
                    NewField13.Value = @":";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 39, 41, 44, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Size = 11;
                    NewField14.Value = @":";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 33, 199, 38, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TARIH.TextFont.Name = "Arial";
                    TARIH.TextFont.Size = 11;
                    TARIH.Value = @"";

                    BASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 228, 16, 293, 29, false);
                    BASLIK.Name = "BASLIK";
                    BASLIK.Visible = EvetHayirEnum.ehHayir;
                    BASLIK.DrawWidth = 2;
                    BASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    BASLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    BASLIK.NoClip = EvetHayirEnum.ehEvet;
                    BASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    BASLIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    BASLIK.TextFont.Name = "Arial";
                    BASLIK.TextFont.Size = 9;
                    BASLIK.TextFont.Bold = true;
                    BASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALDSNAME"", """")
";

                    PAYERTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 74, 199, 84, false);
                    PAYERTEXT.Name = "PAYERTEXT";
                    PAYERTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERTEXT.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYERTEXT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PAYERTEXT.MultiLine = EvetHayirEnum.ehEvet;
                    PAYERTEXT.NoClip = EvetHayirEnum.ehEvet;
                    PAYERTEXT.WordBreak = EvetHayirEnum.ehEvet;
                    PAYERTEXT.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYERTEXT.TextFont.Name = "Arial";
                    PAYERTEXT.TextFont.Size = 11;
                    PAYERTEXT.Value = @"{#HEAD.PAYERNAME#}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 11, 264, 16, false);
                    NewField11.Name = "NewField11";
                    NewField11.Visible = EvetHayirEnum.ehHayir;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"T.C.";

                    BODYTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 109, 199, 139, false);
                    BODYTEXT.Name = "BODYTEXT";
                    BODYTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    BODYTEXT.MultiLine = EvetHayirEnum.ehEvet;
                    BODYTEXT.NoClip = EvetHayirEnum.ehEvet;
                    BODYTEXT.WordBreak = EvetHayirEnum.ehEvet;
                    BODYTEXT.ExpandTabs = EvetHayirEnum.ehEvet;
                    BODYTEXT.TextFont.Name = "Arial";
                    BODYTEXT.TextFont.Size = 11;
                    BODYTEXT.Value = @"";

                    AMOUNTOFINVOICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 188, 86, 193, false);
                    AMOUNTOFINVOICE.Name = "AMOUNTOFINVOICE";
                    AMOUNTOFINVOICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNTOFINVOICE.TextFont.Name = "Arial";
                    AMOUNTOFINVOICE.TextFont.Size = 11;
                    AMOUNTOFINVOICE.Value = @"EK-A ({#HEAD.INVOICEAMOUNT#} Adet Fatura)";

                    AMOUNTOFTRANSFERDOCUMENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 193, 86, 198, false);
                    AMOUNTOFTRANSFERDOCUMENT.Name = "AMOUNTOFTRANSFERDOCUMENT";
                    AMOUNTOFTRANSFERDOCUMENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNTOFTRANSFERDOCUMENT.TextFont.Name = "Arial";
                    AMOUNTOFTRANSFERDOCUMENT.TextFont.Size = 11;
                    AMOUNTOFTRANSFERDOCUMENT.Value = @"EK-B ({#HEAD.INVOICEAMOUNT#} Adet Sevk Kağıdı)";

                    AMOUNTOFINVOICEPOSTINGLIST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 198, 86, 203, false);
                    AMOUNTOFINVOICEPOSTINGLIST.Name = "AMOUNTOFINVOICEPOSTINGLIST";
                    AMOUNTOFINVOICEPOSTINGLIST.TextFont.Name = "Arial";
                    AMOUNTOFINVOICEPOSTINGLIST.TextFont.Size = 11;
                    AMOUNTOFINVOICEPOSTINGLIST.Value = @"EK-C (1 Adet İcmal Listesi)";

                    SIGNATUREBLOCK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 180, 199, 203, false);
                    SIGNATUREBLOCK.Name = "SIGNATUREBLOCK";
                    SIGNATUREBLOCK.FieldType = ReportFieldTypeEnum.ftExpression;
                    SIGNATUREBLOCK.MultiLine = EvetHayirEnum.ehEvet;
                    SIGNATUREBLOCK.NoClip = EvetHayirEnum.ehEvet;
                    SIGNATUREBLOCK.WordBreak = EvetHayirEnum.ehEvet;
                    SIGNATUREBLOCK.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIGNATUREBLOCK.TextFont.Name = "Arial";
                    SIGNATUREBLOCK.TextFont.Size = 11;
                    SIGNATUREBLOCK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""INVOICEPOSTINGREPORTSIGNATUREBLOCK"", """")";

                    HOSPITALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 42, 258, 47, false);
                    HOSPITALNAME.Name = "HOSPITALNAME";
                    HOSPITALNAME.Visible = EvetHayirEnum.ehHayir;
                    HOSPITALNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALNAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    INVOICEAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 49, 258, 54, false);
                    INVOICEAMOUNT.Name = "INVOICEAMOUNT";
                    INVOICEAMOUNT.Visible = EvetHayirEnum.ehHayir;
                    INVOICEAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    INVOICEAMOUNT.Value = @"{#HEAD.INVOICEAMOUNT#}";

                    TOTALINVOICEPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 56, 258, 61, false);
                    TOTALINVOICEPRICE.Name = "TOTALINVOICEPRICE";
                    TOTALINVOICEPRICE.Visible = EvetHayirEnum.ehHayir;
                    TOTALINVOICEPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALINVOICEPRICE.TextFormat = @"#,##0.#0";
                    TOTALINVOICEPRICE.Value = @"{#HEAD.TOTALINVOICEPRICE#}";

                    BANKIBANINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 63, 258, 68, false);
                    BANKIBANINFO.Name = "BANKIBANINFO";
                    BANKIBANINFO.Visible = EvetHayirEnum.ehHayir;
                    BANKIBANINFO.FieldType = ReportFieldTypeEnum.ftExpression;
                    BANKIBANINFO.MultiLine = EvetHayirEnum.ehEvet;
                    BANKIBANINFO.NoClip = EvetHayirEnum.ehEvet;
                    BANKIBANINFO.WordBreak = EvetHayirEnum.ehEvet;
                    BANKIBANINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    BANKIBANINFO.TextFont.CharSet = 1;
                    BANKIBANINFO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""BANKIBANINFO"", """")
";

                    DOSENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 33, 161, 38, false);
                    DOSENO.Name = "DOSENO";
                    DOSENO.FieldType = ReportFieldTypeEnum.ftExpression;
                    DOSENO.TextFont.Name = "Arial";
                    DOSENO.TextFont.Size = 11;
                    DOSENO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""INVOICEPOSTINGREPORTDOSENO"", """")";

                    XXXXXXADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 6, 199, 31, false);
                    XXXXXXADI.Name = "XXXXXXADI";
                    XXXXXXADI.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXADI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    XXXXXXADI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXADI.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXADI.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXADI.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXADI.TextFont.Name = "Arial";
                    XXXXXXADI.TextFont.Size = 11;
                    XXXXXXADI.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    EKLER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 180, 69, 185, false);
                    EKLER1.Name = "EKLER1";
                    EKLER1.TextFont.Name = "Arial";
                    EKLER1.TextFont.Size = 11;
                    EKLER1.Value = @"EKLER";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 18, 186, 69, 186, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 34, 260, 39, false);
                    DATE.Name = "DATE";
                    DATE.Visible = EvetHayirEnum.ehHayir;
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"dd/MM/yyyy";
                    DATE.TextFont.Name = "Arial";
                    DATE.TextFont.Size = 11;
                    DATE.Value = @"{#HEAD.ACTIONDATE#}";

                    EMAIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 71, 258, 76, false);
                    EMAIL.Name = "EMAIL";
                    EMAIL.Visible = EvetHayirEnum.ehHayir;
                    EMAIL.FieldType = ReportFieldTypeEnum.ftExpression;
                    EMAIL.MultiLine = EvetHayirEnum.ehEvet;
                    EMAIL.NoClip = EvetHayirEnum.ehEvet;
                    EMAIL.WordBreak = EvetHayirEnum.ehEvet;
                    EMAIL.ExpandTabs = EvetHayirEnum.ehEvet;
                    EMAIL.TextFont.CharSet = 1;
                    EMAIL.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""INVOICEPOSTINGREPORTEMAIL"", """")
";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InvoicePosting.InvoicePostingPayerQuery_Class dataset_InvoicePostingPayerQuery = MyParentReport.HEAD.rsGroup.GetCurrentRecord<InvoicePosting.InvoicePostingPayerQuery_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    SUBJECT.CalcValue = SUBJECT.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    TARIH.CalcValue = @"";
                    PAYERTEXT.CalcValue = (dataset_InvoicePostingPayerQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPayerQuery.Payername) : "");
                    NewField11.CalcValue = NewField11.Value;
                    BODYTEXT.CalcValue = @"";
                    AMOUNTOFINVOICE.CalcValue = @"EK-A (" + (dataset_InvoicePostingPayerQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPayerQuery.Invoiceamount) : "") + @" Adet Fatura)";
                    AMOUNTOFTRANSFERDOCUMENT.CalcValue = @"EK-B (" + (dataset_InvoicePostingPayerQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPayerQuery.Invoiceamount) : "") + @" Adet Sevk Kağıdı)";
                    AMOUNTOFINVOICEPOSTINGLIST.CalcValue = AMOUNTOFINVOICEPOSTINGLIST.Value;
                    INVOICEAMOUNT.CalcValue = (dataset_InvoicePostingPayerQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPayerQuery.Invoiceamount) : "");
                    TOTALINVOICEPRICE.CalcValue = (dataset_InvoicePostingPayerQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPayerQuery.Totalinvoiceprice) : "");
                    EKLER1.CalcValue = EKLER1.Value;
                    DATE.CalcValue = (dataset_InvoicePostingPayerQuery != null ? Globals.ToStringCore(dataset_InvoicePostingPayerQuery.ActionDate) : "");
                    BASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALDSNAME", "")
;
                    SIGNATUREBLOCK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("INVOICEPOSTINGREPORTSIGNATUREBLOCK", "");
                    HOSPITALNAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    BANKIBANINFO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("BANKIBANINFO", "")
;
                    DOSENO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("INVOICEPOSTINGREPORTDOSENO", "");
                    XXXXXXADI.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    EMAIL.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("INVOICEPOSTINGREPORTEMAIL", "")
;
                    return new TTReportObject[] { NewField1,NewField12,SUBJECT,NewField13,NewField14,TARIH,PAYERTEXT,NewField11,BODYTEXT,AMOUNTOFINVOICE,AMOUNTOFTRANSFERDOCUMENT,AMOUNTOFINVOICEPOSTINGLIST,INVOICEAMOUNT,TOTALINVOICEPRICE,EKLER1,DATE,BASLIK,SIGNATUREBLOCK,HOSPITALNAME,BANKIBANINFO,DOSENO,XXXXXXADI,EMAIL};
                }

                public override void RunScript()
                {
#region ONYAZI BODY_Script
                    Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            if(siteIDGuid == Sites.SiteXXXXXX06XXXXXX)
            {
                this.BODYTEXT.CalcValue = "1- XXXXXX Eğitim XXXXXX'nde tedavi edilen (" + this.INVOICEAMOUNT.CalcValue + ") adet kişiye ait hasta sevki, icmal listesi, teşhis/tedavi belgeleri ve tanzim edilen faturalar ilişiktedir.\r\n \r\n";
                this.BODYTEXT.CalcValue += "2- Toplu Fatura bedeli olan " + this.TOTALINVOICEPRICE.FormattedValue + " TL 'nın XXXXXX Döner Sermaye İşletmesi Saymanlık T.C. Ziraat Bankası XXXXXX Bürosu ETLİK/XXXXXX " + this.BANKIBANINFO.CalcValue + " IBAN numaralı hesabına ödemesinin yapılarak, fatura numaraları, ödeme miktarı ve ödeme tarihlerinin belirtildiği listenin dijital ortamda kullanılmak üzere ";
                this.BODYTEXT.CalcValue += "kurumsal e-posta yoluyla " + this.EMAIL.CalcValue + " adresine ve posta/kargo yoluyla XXXXXX Döner Sermaye İşletme Müdürlüğü'ne gönderilmesi arz/rica olunur.";
            }
            else
                this.BODYTEXT.CalcValue = this.HOSPITALNAME.CalcValue.Replace("\r","").Replace("\n","") + " XXXXXXnde tedavi edilen ("  + this.INVOICEAMOUNT.CalcValue +  ") adet kişiye ait masraf belgeleri ve tanzim edilen faturalar ilişiktedir. \r\n \r\nToplam fatura bedeli olan " + this.TOTALINVOICEPRICE.FormattedValue + " TL 'nın Müdürlüğümüzün " + this.BANKIBANINFO.CalcValue + " nolu IBAN numarasına ödemesinin yapılarak, fatura numaralarının yer aldığı ödeme dekontlarının  ve fatura alt koçanlarının gönderilmesi arz/rica olunur." ;
            
            string date = this.DATE.FormattedValue;
            string day = date.Substring(0,2);
            string month = date.Substring(3,2);
            string year = date.Substring(6,4);
            string monthtext = string.Empty;
            
            switch (month)
            {
                case "01":
                    monthtext = "Ocak";
                    break;
                case "02":
                    monthtext = "Şubat";
                    break;
                case "03":
                    monthtext = "Mart";
                    break;
                case "04":
                    monthtext = "Nisan";
                    break;
                case "05":
                    monthtext = "Mayıs";
                    break;
                case "06":
                    monthtext = "Haziran";
                    break;
                case "07":
                    monthtext = "Temmuz";
                    break;
                case "08":
                    monthtext = "Ağustos";
                    break;
                case "09":
                    monthtext = "Eylül";
                    break;
                case "10":
                    monthtext = "Ekim";
                    break;
                case "11":
                    monthtext = "Kasım";
                    break;
                case "12":
                    monthtext = "Aralık";
                    break;
                default:
                    break;
            }
            
            this.TARIH.CalcValue = day + " " + monthtext + " " + year;
#endregion ONYAZI BODY_Script
                }
            }

        }

        public ONYAZIGroup ONYAZI;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public InvoicePostingListAndPreReport()
        {
            HEAD = new HEADGroup(this,"HEAD");
            ICMAL = new ICMALGroup(HEAD,"ICMAL");
            MAIN = new MAINGroup(ICMAL,"MAIN");
            ONYAZIPARENT = new ONYAZIPARENTGroup(HEAD,"ONYAZIPARENT");
            ONYAZI = new ONYAZIGroup(ONYAZIPARENT,"ONYAZI");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action Object ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "INVOICEPOSTINGLISTANDPREREPORT";
            Caption = "Fatura İcmal Listesi ve Önyazı Raporu";
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