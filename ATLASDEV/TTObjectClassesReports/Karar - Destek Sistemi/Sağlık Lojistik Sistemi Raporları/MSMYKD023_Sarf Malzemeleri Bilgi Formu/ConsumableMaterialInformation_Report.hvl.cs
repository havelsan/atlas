
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
    /// Sarf Malzemeleri Bilgi Formu
    /// </summary>
    public partial class ConsumableMaterialInformation : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string STOCKCARDCLASSID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string STOREID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("320b114b-9b56-4a42-9fc2-65d4e154c970");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ConsumableMaterialInformation MyParentReport
            {
                get { return (ConsumableMaterialInformation)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
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
                public ConsumableMaterialInformation MyParentReport
                {
                    get { return (ConsumableMaterialInformation)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField LOGO; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 4, 257, 16, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Size = 15;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"İLAÇ BİLGİ FORMU";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    LOGO.CalcValue = LOGO.Value;
                    return new TTReportObject[] { REPORTNAME,LOGO};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ConsumableMaterialInformation MyParentReport
                {
                    get { return (ConsumableMaterialInformation)ParentReport; }
                }
                
                public TTReportField PageNumber;
                public TTReportShape NewLine111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 37;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 1, 257, 6, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 1, 257, 1, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    return new TTReportObject[] { PageNumber};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTCGroup : TTReportGroup
        {
            public ConsumableMaterialInformation MyParentReport
            {
                get { return (ConsumableMaterialInformation)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField PARAMETERNAME1 { get {return Header().PARAMETERNAME1;} }
            public TTReportField PARAMETER1 { get {return Header().PARAMETER1;} }
            public TTReportField PARAMETERNAME11 { get {return Header().PARAMETERNAME11;} }
            public TTReportField PARAMETERNAME12 { get {return Header().PARAMETERNAME12;} }
            public TTReportField PARAMETERNAME13 { get {return Header().PARAMETERNAME13;} }
            public TTReportField PARAMETERNAME131 { get {return Header().PARAMETERNAME131;} }
            public TTReportField PARAMETERNAME132 { get {return Header().PARAMETERNAME132;} }
            public TTReportField PARAMETERNAME133 { get {return Header().PARAMETERNAME133;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public ConsumableMaterialInformation MyParentReport
                {
                    get { return (ConsumableMaterialInformation)ParentReport; }
                }
                
                public TTReportField PARAMETERNAME1;
                public TTReportField PARAMETER1;
                public TTReportField PARAMETERNAME11;
                public TTReportField PARAMETERNAME12;
                public TTReportField PARAMETERNAME13;
                public TTReportField PARAMETERNAME131;
                public TTReportField PARAMETERNAME132;
                public TTReportField PARAMETERNAME133;
                public TTReportField NewField1;
                public TTReportField NewField11; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 27;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PARAMETERNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 107, 17, false);
                    PARAMETERNAME1.Name = "PARAMETERNAME1";
                    PARAMETERNAME1.DrawStyle = DrawStyleConstants.vbSolid;
                    PARAMETERNAME1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME1.TextFont.Bold = true;
                    PARAMETERNAME1.TextFont.CharSet = 162;
                    PARAMETERNAME1.Value = @"Saymanlık Adı ve Nu. :";

                    PARAMETER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 0, 218, 17, false);
                    PARAMETER1.Name = "PARAMETER1";
                    PARAMETER1.DrawStyle = DrawStyleConstants.vbSolid;
                    PARAMETER1.TextFont.Bold = true;
                    PARAMETER1.TextFont.CharSet = 162;
                    PARAMETER1.Value = @"Birlik Kurum :";

                    PARAMETERNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 0, 257, 17, false);
                    PARAMETERNAME11.Name = "PARAMETERNAME11";
                    PARAMETERNAME11.DrawStyle = DrawStyleConstants.vbSolid;
                    PARAMETERNAME11.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARAMETERNAME11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME11.TextFont.Bold = true;
                    PARAMETERNAME11.TextFont.CharSet = 162;
                    PARAMETERNAME11.Value = @"Tanzim Tarihi : {@printdate@}";

                    PARAMETERNAME12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 17, 10, 27, false);
                    PARAMETERNAME12.Name = "PARAMETERNAME12";
                    PARAMETERNAME12.DrawStyle = DrawStyleConstants.vbSolid;
                    PARAMETERNAME12.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME12.MultiLine = EvetHayirEnum.ehEvet;
                    PARAMETERNAME12.TextFont.Bold = true;
                    PARAMETERNAME12.TextFont.CharSet = 162;
                    PARAMETERNAME12.Value = @"Sıra
Nu.";

                    PARAMETERNAME13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 17, 115, 22, false);
                    PARAMETERNAME13.Name = "PARAMETERNAME13";
                    PARAMETERNAME13.DrawStyle = DrawStyleConstants.vbSolid;
                    PARAMETERNAME13.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PARAMETERNAME13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME13.TextFont.Bold = true;
                    PARAMETERNAME13.TextFont.CharSet = 162;
                    PARAMETERNAME13.Value = @"Malzemenin";

                    PARAMETERNAME131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 17, 257, 27, false);
                    PARAMETERNAME131.Name = "PARAMETERNAME131";
                    PARAMETERNAME131.DrawStyle = DrawStyleConstants.vbSolid;
                    PARAMETERNAME131.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PARAMETERNAME131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME131.TextFont.Bold = true;
                    PARAMETERNAME131.TextFont.CharSet = 162;
                    PARAMETERNAME131.Value = @"Malzemeyi Kullanan Plk. / Kln. / Lab. Adı";

                    PARAMETERNAME132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 22, 115, 27, false);
                    PARAMETERNAME132.Name = "PARAMETERNAME132";
                    PARAMETERNAME132.DrawStyle = DrawStyleConstants.vbSolid;
                    PARAMETERNAME132.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PARAMETERNAME132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME132.TextFont.Bold = true;
                    PARAMETERNAME132.TextFont.CharSet = 162;
                    PARAMETERNAME132.Value = @"Adı";

                    PARAMETERNAME133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 22, 35, 27, false);
                    PARAMETERNAME133.Name = "PARAMETERNAME133";
                    PARAMETERNAME133.DrawStyle = DrawStyleConstants.vbSolid;
                    PARAMETERNAME133.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME133.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PARAMETERNAME133.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME133.TextFont.Bold = true;
                    PARAMETERNAME133.TextFont.CharSet = 162;
                    PARAMETERNAME133.Value = @"NSN/GSN";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 6, 103, 15, false);
                    NewField1.Name = "NewField1";
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.ObjectDefName = "STORE";
                    NewField1.DataMember = "NAME";
                    NewField1.Value = @"{@STOREID@}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 5, 216, 14, false);
                    NewField11.Name = "NewField11";
                    NewField11.FieldType = ReportFieldTypeEnum.ftExpression;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PARAMETERNAME1.CalcValue = PARAMETERNAME1.Value;
                    PARAMETER1.CalcValue = PARAMETER1.Value;
                    PARAMETERNAME11.CalcValue = @"Tanzim Tarihi : " + DateTime.Now.ToShortDateString();
                    PARAMETERNAME12.CalcValue = PARAMETERNAME12.Value;
                    PARAMETERNAME13.CalcValue = PARAMETERNAME13.Value;
                    PARAMETERNAME131.CalcValue = PARAMETERNAME131.Value;
                    PARAMETERNAME132.CalcValue = PARAMETERNAME132.Value;
                    PARAMETERNAME133.CalcValue = PARAMETERNAME133.Value;
                    NewField1.CalcValue = MyParentReport.RuntimeParameters.STOREID.ToString();
                    NewField1.PostFieldValueCalculation();
                    NewField11.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { PARAMETERNAME1,PARAMETER1,PARAMETERNAME11,PARAMETERNAME12,PARAMETERNAME13,PARAMETERNAME131,PARAMETERNAME132,PARAMETERNAME133,NewField1,NewField11};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public ConsumableMaterialInformation MyParentReport
                {
                    get { return (ConsumableMaterialInformation)ParentReport; }
                }
                 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTBGroup : TTReportGroup
        {
            public ConsumableMaterialInformation MyParentReport
            {
                get { return (ConsumableMaterialInformation)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField STORES { get {return Footer().STORES;} }
            public TTReportField COUNTER { get {return Footer().COUNTER;} }
            public TTReportField NSN { get {return Footer().NSN;} }
            public TTReportField NAME { get {return Footer().NAME;} }
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
                list[0] = new TTReportNqlData<ProductionConsumptionDocumentMaterialOut.ConsumableMaterialOutQuery_Class>("ConsumableMaterialOutQuery1", ProductionConsumptionDocumentMaterialOut.ConsumableMaterialOutQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOCKCARDCLASSID)));
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
                public ConsumableMaterialInformation MyParentReport
                {
                    get { return (ConsumableMaterialInformation)ParentReport; }
                }
                 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public ConsumableMaterialInformation MyParentReport
                {
                    get { return (ConsumableMaterialInformation)ParentReport; }
                }
                
                public TTReportField STORES;
                public TTReportField COUNTER;
                public TTReportField NSN;
                public TTReportField NAME; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    RepeatCount = 0;
                    
                    STORES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 0, 257, 5, false);
                    STORES.Name = "STORES";
                    STORES.DrawStyle = DrawStyleConstants.vbSolid;
                    STORES.Value = @"";

                    COUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 10, 5, false);
                    COUNTER.Name = "COUNTER";
                    COUNTER.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTER.Value = @"{@counter@}";

                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 35, 5, false);
                    NSN.Name = "NSN";
                    NSN.DrawStyle = DrawStyleConstants.vbSolid;
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.Value = @"{#NSN#}";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 0, 115, 5, false);
                    NAME.Name = "NAME";
                    NAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.Value = @"{#STOCKCARDNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ProductionConsumptionDocumentMaterialOut.ConsumableMaterialOutQuery_Class dataset_ConsumableMaterialOutQuery1 = ParentGroup.rsGroup.GetCurrentRecord<ProductionConsumptionDocumentMaterialOut.ConsumableMaterialOutQuery_Class>(0);
                    STORES.CalcValue = STORES.Value;
                    COUNTER.CalcValue = ParentGroup.Counter.ToString();
                    NSN.CalcValue = (dataset_ConsumableMaterialOutQuery1 != null ? Globals.ToStringCore(dataset_ConsumableMaterialOutQuery1.Nsn) : "");
                    NAME.CalcValue = (dataset_ConsumableMaterialOutQuery1 != null ? Globals.ToStringCore(dataset_ConsumableMaterialOutQuery1.Stockcardname) : "");
                    return new TTReportObject[] { STORES,COUNTER,NSN,NAME};
                }

                public override void RunScript()
                {
#region PARTB FOOTER_Script
                    string str="";           
            foreach (string storeName in MAINGroup.StoreNames)//PARTBGroup.StoreNames)
                    {
                          str += storeName + ",";
                    }
            
            str=str.Substring(0,str.Length-1);
            this.STORES.CalcValue=str;
#endregion PARTB FOOTER_Script
                }
            }

#region PARTB_Methods
            //public static List<string> StoreNames;
#endregion PARTB_Methods
            protected override bool RunPreScript()
            {
#region PARTB_PreScript
                // StoreNames = new List<string>();
                return true;
#endregion PARTB_PreScript
            }
        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public ConsumableMaterialInformation MyParentReport
            {
                get { return (ConsumableMaterialInformation)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField STORE { get {return Body().STORE;} }
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

                ProductionConsumptionDocumentMaterialOut.ConsumableMaterialOutQuery_Class dataSet_ConsumableMaterialOutQuery1 = ParentGroup.rsGroup.GetCurrentRecord<ProductionConsumptionDocumentMaterialOut.ConsumableMaterialOutQuery_Class>(0);    
                return new object[] {(dataSet_ConsumableMaterialOutQuery1==null ? null : dataSet_ConsumableMaterialOutQuery1.Stockacardid), (dataSet_ConsumableMaterialOutQuery1==null ? null : dataSet_ConsumableMaterialOutQuery1.Nsn), (dataSet_ConsumableMaterialOutQuery1==null ? null : dataSet_ConsumableMaterialOutQuery1.Stockcardname)};
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
                public ConsumableMaterialInformation MyParentReport
                {
                    get { return (ConsumableMaterialInformation)ParentReport; }
                }
                
                public TTReportField STORE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 3;
                    IsVisible = EvetHayirEnum.ehHayir;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    STORE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 0, 83, 5, false);
                    STORE.Name = "STORE";
                    STORE.Visible = EvetHayirEnum.ehHayir;
                    STORE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STORE.TextFont.CharSet = 162;
                    STORE.Value = @"{#PARTB.STOREQREF#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ProductionConsumptionDocumentMaterialOut.ConsumableMaterialOutQuery_Class dataset_ConsumableMaterialOutQuery1 = MyParentReport.PARTB.rsGroup.GetCurrentRecord<ProductionConsumptionDocumentMaterialOut.ConsumableMaterialOutQuery_Class>(0);
                    STORE.CalcValue = (dataset_ConsumableMaterialOutQuery1 != null ? Globals.ToStringCore(dataset_ConsumableMaterialOutQuery1.Storeqref) : "");
                    return new TTReportObject[] { STORE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //  PARTBGroup.StoreNames.Add(STORE.CalcValue);
                  StoreNames.Add(STORE.CalcValue);
#endregion MAIN BODY_Script
                }
            }

#region MAIN_Methods
            public static List<string> StoreNames;
#endregion MAIN_Methods
            protected override bool RunPreScript()
            {
#region MAIN_PreScript
                StoreNames = new List<string>();
                return true;
#endregion MAIN_PreScript
            }
        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ConsumableMaterialInformation()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTC = new PARTCGroup(PARTA,"PARTC");
            PARTB = new PARTBGroup(PARTC,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOCKCARDCLASSID", "", "Stok Kart Sınıfını Seçiniz :", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("b264545a-a5a3-4615-9e64-f45a354ec864");
            reportParameter.ListFilterExpression = "PARENTSTOCKCARDCLASS IS NOT NULL";
            reportParameter = Parameters.Add("STOREID", "320b114b-9b56-4a42-9fc2-65d4e154c970", "", @"", true, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOCKCARDCLASSID"))
                _runtimeParameters.STOCKCARDCLASSID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["STOCKCARDCLASSID"]);
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["STOREID"]);
            Name = "CONSUMABLEMATERIALINFORMATION";
            Caption = "Sarf Malzemeleri Bilgi Formu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 25;
            UserMarginTop = 15;
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