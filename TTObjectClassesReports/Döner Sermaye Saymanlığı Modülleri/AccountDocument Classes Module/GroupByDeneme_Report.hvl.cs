
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
    /// GroupByDeneme
    /// </summary>
    public partial class GroupByDeneme : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class TOPGroup : TTReportGroup
        {
            public GroupByDeneme MyParentReport
            {
                get { return (GroupByDeneme)ParentReport; }
            }

            new public TOPGroupHeader Header()
            {
                return (TOPGroupHeader)_header;
            }

            new public TOPGroupFooter Footer()
            {
                return (TOPGroupFooter)_footer;
            }

            public TOPGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TOPGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<AccountDocument.Deneme2GroupBy_Class>("Deneme2GroupBy", AccountDocument.Deneme2GroupBy());
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TOPGroupHeader(this);
                _footer = new TOPGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TOPGroupHeader : TTReportSection
            {
                public GroupByDeneme MyParentReport
                {
                    get { return (GroupByDeneme)ParentReport; }
                }
                 
                public TOPGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class TOPGroupFooter : TTReportSection
            {
                public GroupByDeneme MyParentReport
                {
                    get { return (GroupByDeneme)ParentReport; }
                }
                 
                public TOPGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public TOPGroup TOP;

        public partial class UPGroup : TTReportGroup
        {
            public GroupByDeneme MyParentReport
            {
                get { return (GroupByDeneme)ParentReport; }
            }

            new public UPGroupHeader Header()
            {
                return (UPGroupHeader)_header;
            }

            new public UPGroupFooter Footer()
            {
                return (UPGroupFooter)_footer;
            }

            public TTReportField PAYERCODE { get {return Header().PAYERCODE;} }
            public TTReportField PAYERNAME { get {return Header().PAYERNAME;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public UPGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public UPGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                AccountDocument.Deneme2GroupBy_Class dataSet_Deneme2GroupBy = ParentGroup.rsGroup.GetCurrentRecord<AccountDocument.Deneme2GroupBy_Class>(0);    
                return new object[] {(dataSet_Deneme2GroupBy==null ? null : dataSet_Deneme2GroupBy.Payercode)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new UPGroupHeader(this);
                _footer = new UPGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class UPGroupHeader : TTReportSection
            {
                public GroupByDeneme MyParentReport
                {
                    get { return (GroupByDeneme)ParentReport; }
                }
                
                public TTReportField PAYERCODE;
                public TTReportField PAYERNAME;
                public TTReportField NewField1;
                public TTReportShape NewLine1; 
                public UPGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PAYERCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 15, 61, 20, false);
                    PAYERCODE.Name = "PAYERCODE";
                    PAYERCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERCODE.Value = @"{#TOP.PAYERCODE#}";

                    PAYERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 15, 91, 20, false);
                    PAYERNAME.Name = "PAYERNAME";
                    PAYERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERNAME.Value = @"{#TOP.PAYERNAME#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 15, 31, 20, false);
                    NewField1.Name = "NewField1";
                    NewField1.Value = @"KURUM:";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 22, 92, 22, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountDocument.Deneme2GroupBy_Class dataset_Deneme2GroupBy = MyParentReport.TOP.rsGroup.GetCurrentRecord<AccountDocument.Deneme2GroupBy_Class>(0);
                    PAYERCODE.CalcValue = (dataset_Deneme2GroupBy != null ? Globals.ToStringCore(dataset_Deneme2GroupBy.Payercode) : "");
                    PAYERNAME.CalcValue = (dataset_Deneme2GroupBy != null ? Globals.ToStringCore(dataset_Deneme2GroupBy.Payername) : "");
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { PAYERCODE,PAYERNAME,NewField1};
                }
            }
            public partial class UPGroupFooter : TTReportSection
            {
                public GroupByDeneme MyParentReport
                {
                    get { return (GroupByDeneme)ParentReport; }
                }
                 
                public UPGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 23;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public UPGroup UP;

        public partial class HEADGroup : TTReportGroup
        {
            public GroupByDeneme MyParentReport
            {
                get { return (GroupByDeneme)ParentReport; }
            }

            new public HEADGroupHeader Header()
            {
                return (HEADGroupHeader)_header;
            }

            new public HEADGroupFooter Footer()
            {
                return (HEADGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField TYPE { get {return Header().TYPE;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public HEADGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                AccountDocument.Deneme2GroupBy_Class dataSet_Deneme2GroupBy = ParentGroup.rsGroup.GetCurrentRecord<AccountDocument.Deneme2GroupBy_Class>(0);    
                return new object[] {(dataSet_Deneme2GroupBy==null ? null : dataSet_Deneme2GroupBy.Type), (dataSet_Deneme2GroupBy==null ? null : dataSet_Deneme2GroupBy.Payercode)};
            }
            private void onConstruct()
            {
                _body = null;
                _header = new HEADGroupHeader(this);
                _footer = new HEADGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class HEADGroupHeader : TTReportSection
            {
                public GroupByDeneme MyParentReport
                {
                    get { return (GroupByDeneme)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField TYPE;
                public TTReportShape NewLine1; 
                public HEADGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 11;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 37, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.Value = @"HİZMET TİPİ:";

                    TYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 1, 68, 6, false);
                    TYPE.Name = "TYPE";
                    TYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TYPE.ObjectDefName = "InvoicePostingInvoiceTypeEnum";
                    TYPE.DataMember = "DISPLAYTEXT";
                    TYPE.Value = @"{#TOP.TYPE#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 8, 68, 8, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountDocument.Deneme2GroupBy_Class dataset_Deneme2GroupBy = MyParentReport.TOP.rsGroup.GetCurrentRecord<AccountDocument.Deneme2GroupBy_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    TYPE.CalcValue = (dataset_Deneme2GroupBy != null ? Globals.ToStringCore(dataset_Deneme2GroupBy.Type) : "");
                    TYPE.PostFieldValueCalculation();
                    return new TTReportObject[] { NewField1,TYPE};
                }
            }
            public partial class HEADGroupFooter : TTReportSection
            {
                public GroupByDeneme MyParentReport
                {
                    get { return (GroupByDeneme)ParentReport; }
                }
                 
                public HEADGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 9;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADGroup HEAD;

        public partial class MAINGroup : TTReportGroup
        {
            public GroupByDeneme MyParentReport
            {
                get { return (GroupByDeneme)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DOCUMENTNO { get {return Body().DOCUMENTNO;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
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

                AccountDocument.Deneme2GroupBy_Class dataSet_Deneme2GroupBy = ParentGroup.rsGroup.GetCurrentRecord<AccountDocument.Deneme2GroupBy_Class>(0);    
                return new object[] {(dataSet_Deneme2GroupBy==null ? null : dataSet_Deneme2GroupBy.Type), (dataSet_Deneme2GroupBy==null ? null : dataSet_Deneme2GroupBy.Payercode)};
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
                public GroupByDeneme MyParentReport
                {
                    get { return (GroupByDeneme)ParentReport; }
                }
                
                public TTReportField DOCUMENTNO;
                public TTReportField PRICE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    DOCUMENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 1, 42, 6, false);
                    DOCUMENTNO.Name = "DOCUMENTNO";
                    DOCUMENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCUMENTNO.Value = @"{#TOP.DOCUMENTNO#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 1, 77, 6, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.Value = @"{#TOP.GENERALTOTALPRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountDocument.Deneme2GroupBy_Class dataset_Deneme2GroupBy = MyParentReport.TOP.rsGroup.GetCurrentRecord<AccountDocument.Deneme2GroupBy_Class>(0);
                    DOCUMENTNO.CalcValue = (dataset_Deneme2GroupBy != null ? Globals.ToStringCore(dataset_Deneme2GroupBy.DocumentNo) : "");
                    PRICE.CalcValue = (dataset_Deneme2GroupBy != null ? Globals.ToStringCore(dataset_Deneme2GroupBy.GeneralTotalPrice) : "");
                    return new TTReportObject[] { DOCUMENTNO,PRICE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public GroupByDeneme()
        {
            TOP = new TOPGroup(this,"TOP");
            UP = new UPGroup(TOP,"UP");
            HEAD = new HEADGroup(UP,"HEAD");
            MAIN = new MAINGroup(HEAD,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "GROUPBYDENEME";
            Caption = "GroupByDeneme";
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