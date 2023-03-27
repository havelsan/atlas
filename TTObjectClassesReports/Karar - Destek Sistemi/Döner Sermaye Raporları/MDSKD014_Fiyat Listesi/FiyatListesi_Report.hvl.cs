
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
    /// Fiyat Listesi
    /// </summary>
    public partial class FiyatListesi : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string PRICELIST = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public FiyatListesi MyParentReport
            {
                get { return (FiyatListesi)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField PRICINGLIST { get {return Header().PRICINGLIST;} }
            public TTReportField PRICINGLISTNAME { get {return Header().PRICINGLISTNAME;} }
            public TTReportField PRICINGLISTCODE { get {return Header().PRICINGLISTCODE;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public FiyatListesi MyParentReport
                {
                    get { return (FiyatListesi)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField PRICINGLIST;
                public TTReportField PRICINGLISTNAME;
                public TTReportField PRICINGLISTCODE;
                public TTReportField LOGO; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 36;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 7, 173, 27, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 14;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"FİYAT LİSTESİ";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 30, 28, 35, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Fiyat Listesi  :";

                    PRICINGLIST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 30, 208, 35, false);
                    PRICINGLIST.Name = "PRICINGLIST";
                    PRICINGLIST.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICINGLIST.Value = @"{%PRICINGLISTCODE%}  {%PRICINGLISTNAME%}";

                    PRICINGLISTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 11, 242, 16, false);
                    PRICINGLISTNAME.Name = "PRICINGLISTNAME";
                    PRICINGLISTNAME.Visible = EvetHayirEnum.ehHayir;
                    PRICINGLISTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICINGLISTNAME.ObjectDefName = "PricingListDefinition";
                    PRICINGLISTNAME.DataMember = "NAME";
                    PRICINGLISTNAME.Value = @"{@PRICELIST@}";

                    PRICINGLISTCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 5, 242, 10, false);
                    PRICINGLISTCODE.Name = "PRICINGLISTCODE";
                    PRICINGLISTCODE.Visible = EvetHayirEnum.ehHayir;
                    PRICINGLISTCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICINGLISTCODE.ObjectDefName = "PricingListDefinition";
                    PRICINGLISTCODE.DataMember = "CODE";
                    PRICINGLISTCODE.Value = @"{@PRICELIST@}";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 7, 47, 27, false);
                    LOGO.Name = "LOGO";
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    PRICINGLISTCODE.CalcValue = MyParentReport.RuntimeParameters.PRICELIST.ToString();
                    PRICINGLISTCODE.PostFieldValueCalculation();
                    PRICINGLISTNAME.CalcValue = MyParentReport.RuntimeParameters.PRICELIST.ToString();
                    PRICINGLISTNAME.PostFieldValueCalculation();
                    PRICINGLIST.CalcValue = MyParentReport.PARTB.PRICINGLISTCODE.CalcValue + @"  " + MyParentReport.PARTB.PRICINGLISTNAME.CalcValue;
                    LOGO.CalcValue = LOGO.Value;
                    return new TTReportObject[] { NewField11,NewField12,PRICINGLISTCODE,PRICINGLISTNAME,PRICINGLIST,LOGO};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public FiyatListesi MyParentReport
                {
                    get { return (FiyatListesi)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public FiyatListesi MyParentReport
            {
                get { return (FiyatListesi)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField12221 { get {return Header().NewField12221;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1321 { get {return Header().NewField1321;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
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
                public FiyatListesi MyParentReport
                {
                    get { return (FiyatListesi)ParentReport; }
                }
                
                public TTReportField NewField1121;
                public TTReportField NewField1221;
                public TTReportField NewField12221;
                public TTReportField NewField111211;
                public TTReportShape NewLine11;
                public TTReportField NewField121;
                public TTReportField NewField1321; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 5, 138, 10, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Fiyat Açıklaması";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 5, 187, 10, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1221.NoClip = EvetHayirEnum.ehEvet;
                    NewField1221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"Başlangıç Tarihi";

                    NewField12221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 5, 208, 10, false);
                    NewField12221.Name = "NewField12221";
                    NewField12221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12221.NoClip = EvetHayirEnum.ehEvet;
                    NewField12221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12221.TextFont.Bold = true;
                    NewField12221.TextFont.CharSet = 162;
                    NewField12221.Value = @"Bitiş Tarihi";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 5, 161, 10, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Fiyat";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 11, 208, 11, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 5, 35, 10, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Fiyat Kodu";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 5, 18, 10, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.TextFont.Bold = true;
                    NewField1321.TextFont.CharSet = 162;
                    NewField1321.Value = @"Sıra No";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField12221.CalcValue = NewField12221.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    return new TTReportObject[] { NewField1121,NewField1221,NewField12221,NewField111211,NewField121,NewField1321};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public FiyatListesi MyParentReport
                {
                    get { return (FiyatListesi)ParentReport; }
                }
                
                public TTReportField CURRENTUSER;
                public TTReportField PrintDate;
                public TTReportField PageNumber; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 0, 120, 5, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 38, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 0, 208, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CURRENTUSER.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PageNumber,CURRENTUSER};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public FiyatListesi MyParentReport
            {
                get { return (FiyatListesi)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField CODE { get {return Body().CODE;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField DATESTART { get {return Body().DATESTART;} }
            public TTReportField DATEEND { get {return Body().DATEEND;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
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
                list[0] = new TTReportNqlData<PricingDetailDefinition.GetEffectivePricingDetailDefsByPriceList_Class>("GetEffectivePricingDetailDefsByPriceList", PricingDetailDefinition.GetEffectivePricingDetailDefsByPriceList((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.PRICELIST)));
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
                public FiyatListesi MyParentReport
                {
                    get { return (FiyatListesi)ParentReport; }
                }
                
                public TTReportField CODE;
                public TTReportField DESCRIPTION;
                public TTReportField DATESTART;
                public TTReportField DATEEND;
                public TTReportField PRICE;
                public TTReportField SIRANO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 0, 35, 5, false);
                    CODE.Name = "CODE";
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.TextFont.CharSet = 162;
                    CODE.Value = @"{#EXTERNALCODE#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 0, 138, 5, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    DATESTART = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 0, 187, 5, false);
                    DATESTART.Name = "DATESTART";
                    DATESTART.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATESTART.TextFormat = @"Short Date";
                    DATESTART.TextFont.CharSet = 162;
                    DATESTART.Value = @"{#DATESTART#}";

                    DATEEND = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 0, 208, 5, false);
                    DATEEND.Name = "DATEEND";
                    DATEEND.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATEEND.TextFormat = @"Short Date";
                    DATEEND.TextFont.CharSet = 162;
                    DATEEND.Value = @"{#DATEEND#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 0, 161, 5, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"{#PRICE#}";

                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 18, 5, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PricingDetailDefinition.GetEffectivePricingDetailDefsByPriceList_Class dataset_GetEffectivePricingDetailDefsByPriceList = ParentGroup.rsGroup.GetCurrentRecord<PricingDetailDefinition.GetEffectivePricingDetailDefsByPriceList_Class>(0);
                    CODE.CalcValue = (dataset_GetEffectivePricingDetailDefsByPriceList != null ? Globals.ToStringCore(dataset_GetEffectivePricingDetailDefsByPriceList.ExternalCode) : "");
                    DESCRIPTION.CalcValue = (dataset_GetEffectivePricingDetailDefsByPriceList != null ? Globals.ToStringCore(dataset_GetEffectivePricingDetailDefsByPriceList.Description) : "");
                    DATESTART.CalcValue = (dataset_GetEffectivePricingDetailDefsByPriceList != null ? Globals.ToStringCore(dataset_GetEffectivePricingDetailDefsByPriceList.DateStart) : "");
                    DATEEND.CalcValue = (dataset_GetEffectivePricingDetailDefsByPriceList != null ? Globals.ToStringCore(dataset_GetEffectivePricingDetailDefsByPriceList.DateEnd) : "");
                    PRICE.CalcValue = (dataset_GetEffectivePricingDetailDefsByPriceList != null ? Globals.ToStringCore(dataset_GetEffectivePricingDetailDefsByPriceList.Price) : "");
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    return new TTReportObject[] { CODE,DESCRIPTION,DATESTART,DATEEND,PRICE,SIRANO};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public FiyatListesi()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("PRICELIST", "", "Fiyat Listesi", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("067f641f-dd9d-4cb7-96ac-e3c58df8da79");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("PRICELIST"))
                _runtimeParameters.PRICELIST = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["PRICELIST"]);
            Name = "FIYATLISTESI";
            Caption = "Fiyat Listesi";
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