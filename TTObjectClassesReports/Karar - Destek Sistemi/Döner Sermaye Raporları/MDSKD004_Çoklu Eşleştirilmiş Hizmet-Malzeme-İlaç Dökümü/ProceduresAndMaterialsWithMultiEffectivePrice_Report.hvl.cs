
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
    /// Çoklu Eşleştirilmiş Hizmet/Malzeme/İlaç Dökümü
    /// </summary>
    public partial class ProceduresAndMaterialsWithMultiEffectivePrice : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string PRICELIST = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public ProceduresAndMaterialsWithMultiEffectivePrice MyParentReport
            {
                get { return (ProceduresAndMaterialsWithMultiEffectivePrice)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField PRICINGLIST { get {return Header().PRICINGLIST;} }
            public TTReportField PRICINGLISTNAME { get {return Header().PRICINGLISTNAME;} }
            public TTReportField PRICINGLISTCODE { get {return Header().PRICINGLISTCODE;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
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
                public ProceduresAndMaterialsWithMultiEffectivePrice MyParentReport
                {
                    get { return (ProceduresAndMaterialsWithMultiEffectivePrice)ParentReport; }
                }
                
                public TTReportField NewField12;
                public TTReportField NewField11;
                public TTReportField NewField121;
                public TTReportField PRICINGLIST;
                public TTReportField PRICINGLISTNAME;
                public TTReportField PRICINGLISTCODE;
                public TTReportField LOGO; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 38;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 32, 28, 37, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.Underline = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"HİZMETLER";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 3, 163, 23, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 12;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"ÇOKLU EŞLEŞTİRİLMİŞ HİZMET / MALZEME / İLAÇ DÖKÜMÜ";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 25, 27, 30, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Fiyat Listesi  :";

                    PRICINGLIST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 25, 208, 30, false);
                    PRICINGLIST.Name = "PRICINGLIST";
                    PRICINGLIST.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICINGLIST.Value = @"{%PRICINGLISTCODE%}  {%PRICINGLISTNAME%}";

                    PRICINGLISTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 8, 243, 13, false);
                    PRICINGLISTNAME.Name = "PRICINGLISTNAME";
                    PRICINGLISTNAME.Visible = EvetHayirEnum.ehHayir;
                    PRICINGLISTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICINGLISTNAME.ObjectDefName = "PricingListDefinition";
                    PRICINGLISTNAME.DataMember = "NAME";
                    PRICINGLISTNAME.Value = @"{@PRICELIST@}";

                    PRICINGLISTCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 2, 243, 7, false);
                    PRICINGLISTCODE.Name = "PRICINGLISTCODE";
                    PRICINGLISTCODE.Visible = EvetHayirEnum.ehHayir;
                    PRICINGLISTCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICINGLISTCODE.ObjectDefName = "PricingListDefinition";
                    PRICINGLISTCODE.DataMember = "CODE";
                    PRICINGLISTCODE.Value = @"{@PRICELIST@}";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 3, 47, 23, false);
                    LOGO.Name = "LOGO";
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField12.CalcValue = NewField12.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField121.CalcValue = NewField121.Value;
                    PRICINGLISTCODE.CalcValue = MyParentReport.RuntimeParameters.PRICELIST.ToString();
                    PRICINGLISTCODE.PostFieldValueCalculation();
                    PRICINGLISTNAME.CalcValue = MyParentReport.RuntimeParameters.PRICELIST.ToString();
                    PRICINGLISTNAME.PostFieldValueCalculation();
                    PRICINGLIST.CalcValue = MyParentReport.PARTA.PRICINGLISTCODE.CalcValue + @"  " + MyParentReport.PARTA.PRICINGLISTNAME.CalcValue;
                    LOGO.CalcValue = LOGO.Value;
                    return new TTReportObject[] { NewField12,NewField11,NewField121,PRICINGLISTCODE,PRICINGLISTNAME,PRICINGLIST,LOGO};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ProceduresAndMaterialsWithMultiEffectivePrice MyParentReport
                {
                    get { return (ProceduresAndMaterialsWithMultiEffectivePrice)ParentReport; }
                }
                
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 0, 119, 5, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 0, 208, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 38, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    CURRENTUSER.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PageNumber,PrintDate,CURRENTUSER};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PROCPGroup : TTReportGroup
        {
            public ProceduresAndMaterialsWithMultiEffectivePrice MyParentReport
            {
                get { return (ProceduresAndMaterialsWithMultiEffectivePrice)ParentReport; }
            }

            new public PROCPGroupHeader Header()
            {
                return (PROCPGroupHeader)_header;
            }

            new public PROCPGroupFooter Footer()
            {
                return (PROCPGroupFooter)_footer;
            }

            public TTReportField NewField11111 { get {return Footer().NewField11111;} }
            public TTReportField PROCEDURECOUNT { get {return Footer().PROCEDURECOUNT;} }
            public PROCPGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PROCPGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PROCPGroupHeader(this);
                _footer = new PROCPGroupFooter(this);

            }

            public partial class PROCPGroupHeader : TTReportSection
            {
                public ProceduresAndMaterialsWithMultiEffectivePrice MyParentReport
                {
                    get { return (ProceduresAndMaterialsWithMultiEffectivePrice)ParentReport; }
                }
                 
                public PROCPGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PROCPGroupFooter : TTReportSection
            {
                public ProceduresAndMaterialsWithMultiEffectivePrice MyParentReport
                {
                    get { return (ProceduresAndMaterialsWithMultiEffectivePrice)ParentReport; }
                }
                
                public TTReportField NewField11111;
                public TTReportField PROCEDURECOUNT; 
                public PROCPGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 9;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 3, 39, 8, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Toplam Hizmet Sayısı :";

                    PROCEDURECOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 3, 77, 8, false);
                    PROCEDURECOUNT.Name = "PROCEDURECOUNT";
                    PROCEDURECOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDURECOUNT.TextFont.CharSet = 162;
                    PROCEDURECOUNT.Value = @"{@subgroupcount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11111.CalcValue = NewField11111.Value;
                    PROCEDURECOUNT.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    return new TTReportObject[] { NewField11111,PROCEDURECOUNT};
                }

                public override void RunScript()
                {
#region PROCP FOOTER_Script
                    if (this.PROCEDURECOUNT.CalcValue == "-1")
                this.PROCEDURECOUNT.CalcValue = "0";
#endregion PROCP FOOTER_Script
                }
            }

        }

        public PROCPGroup PROCP;

        public partial class PROCPARENTGroup : TTReportGroup
        {
            public ProceduresAndMaterialsWithMultiEffectivePrice MyParentReport
            {
                get { return (ProceduresAndMaterialsWithMultiEffectivePrice)ParentReport; }
            }

            new public PROCPARENTGroupHeader Header()
            {
                return (PROCPARENTGroupHeader)_header;
            }

            new public PROCPARENTGroupFooter Footer()
            {
                return (PROCPARENTGroupFooter)_footer;
            }

            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField PROCEDURE { get {return Header().PROCEDURE;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField11221 { get {return Header().NewField11221;} }
            public TTReportField NewField112221 { get {return Header().NewField112221;} }
            public TTReportField NewField1112111 { get {return Header().NewField1112111;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField PROCEDUREOBJECTID { get {return Header().PROCEDUREOBJECTID;} }
            public PROCPARENTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PROCPARENTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ProcedureDefinition.GetProcedureWithMultiEffectivePriceByPriceList_Class>("GetProcedureWithMultiEffectivePriceByPriceList", ProcedureDefinition.GetProcedureWithMultiEffectivePriceByPriceList((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.PRICELIST)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PROCPARENTGroupHeader(this);
                _footer = new PROCPARENTGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PROCPARENTGroupHeader : TTReportSection
            {
                public ProceduresAndMaterialsWithMultiEffectivePrice MyParentReport
                {
                    get { return (ProceduresAndMaterialsWithMultiEffectivePrice)ParentReport; }
                }
                
                public TTReportShape NewLine1111;
                public TTReportField NewField111;
                public TTReportField PROCEDURE;
                public TTReportField NewField11211;
                public TTReportField NewField11221;
                public TTReportField NewField112221;
                public TTReportField NewField1112111;
                public TTReportField NewField1121;
                public TTReportField PROCEDUREOBJECTID; 
                public PROCPARENTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 14, 208, 14, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 2, 19, 7, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Hizmet :";

                    PROCEDURE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 2, 208, 7, false);
                    PROCEDURE.Name = "PROCEDURE";
                    PROCEDURE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDURE.Value = @"{#CODE#} {#NAME#}";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 8, 141, 13, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Fiyat Açıklaması";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 8, 190, 13, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11221.NoClip = EvetHayirEnum.ehEvet;
                    NewField11221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @"Başlangıç Tarihi";

                    NewField112221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 8, 208, 13, false);
                    NewField112221.Name = "NewField112221";
                    NewField112221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112221.NoClip = EvetHayirEnum.ehEvet;
                    NewField112221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112221.TextFont.Bold = true;
                    NewField112221.TextFont.CharSet = 162;
                    NewField112221.Value = @"Bitiş Tarihi";

                    NewField1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 8, 164, 13, false);
                    NewField1112111.Name = "NewField1112111";
                    NewField1112111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1112111.TextFont.Bold = true;
                    NewField1112111.TextFont.CharSet = 162;
                    NewField1112111.Value = @"Fiyat";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 8, 23, 13, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Fiyat Kodu";

                    PROCEDUREOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 6, 249, 11, false);
                    PROCEDUREOBJECTID.Name = "PROCEDUREOBJECTID";
                    PROCEDUREOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    PROCEDUREOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREOBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ProcedureDefinition.GetProcedureWithMultiEffectivePriceByPriceList_Class dataset_GetProcedureWithMultiEffectivePriceByPriceList = ParentGroup.rsGroup.GetCurrentRecord<ProcedureDefinition.GetProcedureWithMultiEffectivePriceByPriceList_Class>(0);
                    NewField111.CalcValue = NewField111.Value;
                    PROCEDURE.CalcValue = (dataset_GetProcedureWithMultiEffectivePriceByPriceList != null ? Globals.ToStringCore(dataset_GetProcedureWithMultiEffectivePriceByPriceList.Code) : "") + @" " + (dataset_GetProcedureWithMultiEffectivePriceByPriceList != null ? Globals.ToStringCore(dataset_GetProcedureWithMultiEffectivePriceByPriceList.Name) : "");
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField112221.CalcValue = NewField112221.Value;
                    NewField1112111.CalcValue = NewField1112111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    PROCEDUREOBJECTID.CalcValue = (dataset_GetProcedureWithMultiEffectivePriceByPriceList != null ? Globals.ToStringCore(dataset_GetProcedureWithMultiEffectivePriceByPriceList.ObjectID) : "");
                    return new TTReportObject[] { NewField111,PROCEDURE,NewField11211,NewField11221,NewField112221,NewField1112111,NewField1121,PROCEDUREOBJECTID};
                }
            }
            public partial class PROCPARENTGroupFooter : TTReportSection
            {
                public ProceduresAndMaterialsWithMultiEffectivePrice MyParentReport
                {
                    get { return (ProceduresAndMaterialsWithMultiEffectivePrice)ParentReport; }
                }
                 
                public PROCPARENTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PROCPARENTGroup PROCPARENT;

        public partial class MAINGroup : TTReportGroup
        {
            public ProceduresAndMaterialsWithMultiEffectivePrice MyParentReport
            {
                get { return (ProceduresAndMaterialsWithMultiEffectivePrice)ParentReport; }
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
                list[0] = new TTReportNqlData<ProcedurePriceDefinition.ProcedurePriceListByProcedureAndPriceList_Class>("ProcedurePriceListByProcedureAndPriceList", ProcedurePriceDefinition.ProcedurePriceListByProcedureAndPriceList((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.PROCPARENT.PROCEDUREOBJECTID.CalcValue),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.PRICELIST)));
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
                public ProceduresAndMaterialsWithMultiEffectivePrice MyParentReport
                {
                    get { return (ProceduresAndMaterialsWithMultiEffectivePrice)ParentReport; }
                }
                
                public TTReportField CODE;
                public TTReportField DESCRIPTION;
                public TTReportField DATESTART;
                public TTReportField DATEEND;
                public TTReportField PRICE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 23, 5, false);
                    CODE.Name = "CODE";
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.TextFont.CharSet = 162;
                    CODE.Value = @"{#EXTERNALCODE#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 0, 141, 5, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    DATESTART = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 0, 190, 5, false);
                    DATESTART.Name = "DATESTART";
                    DATESTART.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATESTART.TextFormat = @"Short Date";
                    DATESTART.TextFont.CharSet = 162;
                    DATESTART.Value = @"{#DATESTART#}";

                    DATEEND = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 0, 208, 5, false);
                    DATEEND.Name = "DATEEND";
                    DATEEND.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATEEND.TextFormat = @"Short Date";
                    DATEEND.TextFont.CharSet = 162;
                    DATEEND.Value = @"{#DATEEND#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 0, 164, 5, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"{#PRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ProcedurePriceDefinition.ProcedurePriceListByProcedureAndPriceList_Class dataset_ProcedurePriceListByProcedureAndPriceList = ParentGroup.rsGroup.GetCurrentRecord<ProcedurePriceDefinition.ProcedurePriceListByProcedureAndPriceList_Class>(0);
                    CODE.CalcValue = (dataset_ProcedurePriceListByProcedureAndPriceList != null ? Globals.ToStringCore(dataset_ProcedurePriceListByProcedureAndPriceList.ExternalCode) : "");
                    DESCRIPTION.CalcValue = (dataset_ProcedurePriceListByProcedureAndPriceList != null ? Globals.ToStringCore(dataset_ProcedurePriceListByProcedureAndPriceList.Description) : "");
                    DATESTART.CalcValue = (dataset_ProcedurePriceListByProcedureAndPriceList != null ? Globals.ToStringCore(dataset_ProcedurePriceListByProcedureAndPriceList.DateStart) : "");
                    DATEEND.CalcValue = (dataset_ProcedurePriceListByProcedureAndPriceList != null ? Globals.ToStringCore(dataset_ProcedurePriceListByProcedureAndPriceList.DateEnd) : "");
                    PRICE.CalcValue = (dataset_ProcedurePriceListByProcedureAndPriceList != null ? Globals.ToStringCore(dataset_ProcedurePriceListByProcedureAndPriceList.Price) : "");
                    return new TTReportObject[] { CODE,DESCRIPTION,DATESTART,DATEEND,PRICE};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class MATPGroup : TTReportGroup
        {
            public ProceduresAndMaterialsWithMultiEffectivePrice MyParentReport
            {
                get { return (ProceduresAndMaterialsWithMultiEffectivePrice)ParentReport; }
            }

            new public MATPGroupHeader Header()
            {
                return (MATPGroupHeader)_header;
            }

            new public MATPGroupFooter Footer()
            {
                return (MATPGroupFooter)_footer;
            }

            public TTReportField NewField12211 { get {return Header().NewField12211;} }
            public TTReportShape NewLine1111111 { get {return Header().NewLine1111111;} }
            public TTReportField NewField111111 { get {return Footer().NewField111111;} }
            public TTReportField MATERIALCOUNT { get {return Footer().MATERIALCOUNT;} }
            public MATPGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MATPGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new MATPGroupHeader(this);
                _footer = new MATPGroupFooter(this);

            }

            public partial class MATPGroupHeader : TTReportSection
            {
                public ProceduresAndMaterialsWithMultiEffectivePrice MyParentReport
                {
                    get { return (ProceduresAndMaterialsWithMultiEffectivePrice)ParentReport; }
                }
                
                public TTReportField NewField12211;
                public TTReportShape NewLine1111111; 
                public MATPGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 13;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField12211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 6, 58, 12, false);
                    NewField12211.Name = "NewField12211";
                    NewField12211.TextFont.Size = 11;
                    NewField12211.TextFont.Bold = true;
                    NewField12211.TextFont.Underline = true;
                    NewField12211.TextFont.CharSet = 162;
                    NewField12211.Value = @"MALZEMELER VE İLAÇLAR";

                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 3, 208, 3, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField12211.CalcValue = NewField12211.Value;
                    return new TTReportObject[] { NewField12211};
                }
            }
            public partial class MATPGroupFooter : TTReportSection
            {
                public ProceduresAndMaterialsWithMultiEffectivePrice MyParentReport
                {
                    get { return (ProceduresAndMaterialsWithMultiEffectivePrice)ParentReport; }
                }
                
                public TTReportField NewField111111;
                public TTReportField MATERIALCOUNT; 
                public MATPGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 2, 42, 7, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Toplam Malzeme Sayısı :";

                    MATERIALCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 2, 80, 7, false);
                    MATERIALCOUNT.Name = "MATERIALCOUNT";
                    MATERIALCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALCOUNT.TextFont.CharSet = 162;
                    MATERIALCOUNT.Value = @"{@subgroupcount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111111.CalcValue = NewField111111.Value;
                    MATERIALCOUNT.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    return new TTReportObject[] { NewField111111,MATERIALCOUNT};
                }

                public override void RunScript()
                {
#region MATP FOOTER_Script
                    if (this.MATERIALCOUNT.CalcValue == "-1")
                this.MATERIALCOUNT.CalcValue = "0";
#endregion MATP FOOTER_Script
                }
            }

        }

        public MATPGroup MATP;

        public partial class MATPARENTGroup : TTReportGroup
        {
            public ProceduresAndMaterialsWithMultiEffectivePrice MyParentReport
            {
                get { return (ProceduresAndMaterialsWithMultiEffectivePrice)ParentReport; }
            }

            new public MATPARENTGroupHeader Header()
            {
                return (MATPARENTGroupHeader)_header;
            }

            new public MATPARENTGroupFooter Footer()
            {
                return (MATPARENTGroupFooter)_footer;
            }

            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField MATERIAL { get {return Header().MATERIAL;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewField112211 { get {return Header().NewField112211;} }
            public TTReportField NewField1122211 { get {return Header().NewField1122211;} }
            public TTReportField NewField11112111 { get {return Header().NewField11112111;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField MATERIALOBJECTID { get {return Header().MATERIALOBJECTID;} }
            public MATPARENTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MATPARENTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Material.GetMaterialWithMultiEffectivePriceByPriceList_Class>("GetMaterialWithMultiEffectivePriceByPriceList", Material.GetMaterialWithMultiEffectivePriceByPriceList((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.PRICELIST)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new MATPARENTGroupHeader(this);
                _footer = new MATPARENTGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MATPARENTGroupHeader : TTReportSection
            {
                public ProceduresAndMaterialsWithMultiEffectivePrice MyParentReport
                {
                    get { return (ProceduresAndMaterialsWithMultiEffectivePrice)ParentReport; }
                }
                
                public TTReportShape NewLine11111;
                public TTReportField NewField1111;
                public TTReportField MATERIAL;
                public TTReportField NewField111211;
                public TTReportField NewField112211;
                public TTReportField NewField1122211;
                public TTReportField NewField11112111;
                public TTReportField NewField11211;
                public TTReportField MATERIALOBJECTID; 
                public MATPARENTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 14;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 13, 208, 13, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 29, 6, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Malzeme / İlaç :";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 1, 208, 6, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.Value = @"{#CODE#} {#NAME#}";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 7, 141, 12, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Fiyat Açıklaması";

                    NewField112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 7, 190, 12, false);
                    NewField112211.Name = "NewField112211";
                    NewField112211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112211.NoClip = EvetHayirEnum.ehEvet;
                    NewField112211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112211.TextFont.Bold = true;
                    NewField112211.TextFont.CharSet = 162;
                    NewField112211.Value = @"Başlangıç Tarihi";

                    NewField1122211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 7, 208, 12, false);
                    NewField1122211.Name = "NewField1122211";
                    NewField1122211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1122211.NoClip = EvetHayirEnum.ehEvet;
                    NewField1122211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1122211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1122211.TextFont.Bold = true;
                    NewField1122211.TextFont.CharSet = 162;
                    NewField1122211.Value = @"Bitiş Tarihi";

                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 7, 164, 12, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11112111.TextFont.Bold = true;
                    NewField11112111.TextFont.CharSet = 162;
                    NewField11112111.Value = @"Fiyat";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 7, 23, 12, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Fiyat Kodu";

                    MATERIALOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 3, 249, 8, false);
                    MATERIALOBJECTID.Name = "MATERIALOBJECTID";
                    MATERIALOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    MATERIALOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALOBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Material.GetMaterialWithMultiEffectivePriceByPriceList_Class dataset_GetMaterialWithMultiEffectivePriceByPriceList = ParentGroup.rsGroup.GetCurrentRecord<Material.GetMaterialWithMultiEffectivePriceByPriceList_Class>(0);
                    NewField1111.CalcValue = NewField1111.Value;
                    MATERIAL.CalcValue = (dataset_GetMaterialWithMultiEffectivePriceByPriceList != null ? Globals.ToStringCore(dataset_GetMaterialWithMultiEffectivePriceByPriceList.Code) : "") + @" " + (dataset_GetMaterialWithMultiEffectivePriceByPriceList != null ? Globals.ToStringCore(dataset_GetMaterialWithMultiEffectivePriceByPriceList.Name) : "");
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField112211.CalcValue = NewField112211.Value;
                    NewField1122211.CalcValue = NewField1122211.Value;
                    NewField11112111.CalcValue = NewField11112111.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    MATERIALOBJECTID.CalcValue = (dataset_GetMaterialWithMultiEffectivePriceByPriceList != null ? Globals.ToStringCore(dataset_GetMaterialWithMultiEffectivePriceByPriceList.ObjectID) : "");
                    return new TTReportObject[] { NewField1111,MATERIAL,NewField111211,NewField112211,NewField1122211,NewField11112111,NewField11211,MATERIALOBJECTID};
                }
            }
            public partial class MATPARENTGroupFooter : TTReportSection
            {
                public ProceduresAndMaterialsWithMultiEffectivePrice MyParentReport
                {
                    get { return (ProceduresAndMaterialsWithMultiEffectivePrice)ParentReport; }
                }
                 
                public MATPARENTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MATPARENTGroup MATPARENT;

        public partial class MATGroup : TTReportGroup
        {
            public ProceduresAndMaterialsWithMultiEffectivePrice MyParentReport
            {
                get { return (ProceduresAndMaterialsWithMultiEffectivePrice)ParentReport; }
            }

            new public MATGroupBody Body()
            {
                return (MATGroupBody)_body;
            }
            public TTReportField CODE { get {return Body().CODE;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField DATESTART { get {return Body().DATESTART;} }
            public TTReportField DATEEND { get {return Body().DATEEND;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
            public MATGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MATGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<MaterialPrice.MaterialPriceByMaterialAndPriceList_Class>("MaterialPriceByMaterialAndPriceList", MaterialPrice.MaterialPriceByMaterialAndPriceList((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.PRICELIST),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.MATPARENT.MATERIALOBJECTID.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MATGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MATGroupBody : TTReportSection
            {
                public ProceduresAndMaterialsWithMultiEffectivePrice MyParentReport
                {
                    get { return (ProceduresAndMaterialsWithMultiEffectivePrice)ParentReport; }
                }
                
                public TTReportField CODE;
                public TTReportField DESCRIPTION;
                public TTReportField DATESTART;
                public TTReportField DATEEND;
                public TTReportField PRICE; 
                public MATGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 0, 23, 5, false);
                    CODE.Name = "CODE";
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.TextFont.CharSet = 162;
                    CODE.Value = @"{#EXTERNALCODE#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 0, 141, 5, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    DATESTART = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 0, 190, 5, false);
                    DATESTART.Name = "DATESTART";
                    DATESTART.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATESTART.TextFormat = @"Short Date";
                    DATESTART.TextFont.CharSet = 162;
                    DATESTART.Value = @"{#DATESTART#}";

                    DATEEND = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 192, 0, 208, 5, false);
                    DATEEND.Name = "DATEEND";
                    DATEEND.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATEEND.TextFormat = @"Short Date";
                    DATEEND.TextFont.CharSet = 162;
                    DATEEND.Value = @"{#DATEEND#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 0, 164, 5, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"{#PRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MaterialPrice.MaterialPriceByMaterialAndPriceList_Class dataset_MaterialPriceByMaterialAndPriceList = ParentGroup.rsGroup.GetCurrentRecord<MaterialPrice.MaterialPriceByMaterialAndPriceList_Class>(0);
                    CODE.CalcValue = (dataset_MaterialPriceByMaterialAndPriceList != null ? Globals.ToStringCore(dataset_MaterialPriceByMaterialAndPriceList.ExternalCode) : "");
                    DESCRIPTION.CalcValue = (dataset_MaterialPriceByMaterialAndPriceList != null ? Globals.ToStringCore(dataset_MaterialPriceByMaterialAndPriceList.Description) : "");
                    DATESTART.CalcValue = (dataset_MaterialPriceByMaterialAndPriceList != null ? Globals.ToStringCore(dataset_MaterialPriceByMaterialAndPriceList.DateStart) : "");
                    DATEEND.CalcValue = (dataset_MaterialPriceByMaterialAndPriceList != null ? Globals.ToStringCore(dataset_MaterialPriceByMaterialAndPriceList.DateEnd) : "");
                    PRICE.CalcValue = (dataset_MaterialPriceByMaterialAndPriceList != null ? Globals.ToStringCore(dataset_MaterialPriceByMaterialAndPriceList.Price) : "");
                    return new TTReportObject[] { CODE,DESCRIPTION,DATESTART,DATEEND,PRICE};
                }
            }

        }

        public MATGroup MAT;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ProceduresAndMaterialsWithMultiEffectivePrice()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PROCP = new PROCPGroup(PARTA,"PROCP");
            PROCPARENT = new PROCPARENTGroup(PROCP,"PROCPARENT");
            MAIN = new MAINGroup(PROCPARENT,"MAIN");
            MATP = new MATPGroup(PARTA,"MATP");
            MATPARENT = new MATPARENTGroup(MATP,"MATPARENT");
            MAT = new MATGroup(MATPARENT,"MAT");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("PRICELIST", "", "Fiyat Listesi", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("067f641f-dd9d-4cb7-96ac-e3c58df8da79");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("PRICELIST"))
                _runtimeParameters.PRICELIST = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["PRICELIST"]);
            Name = "PROCEDURESANDMATERIALSWITHMULTIEFFECTIVEPRICE";
            Caption = "Çoklu Eşleştirilmiş Hizmet/Malzeme/İlaç Dökümü";
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