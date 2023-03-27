
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
    /// Geçerlilik Tarihleri Raporu
    /// </summary>
    public partial class EffectiveDatesReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTCGroup : TTReportGroup
        {
            public EffectiveDatesReport MyParentReport
            {
                get { return (EffectiveDatesReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
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
                public EffectiveDatesReport MyParentReport
                {
                    get { return (EffectiveDatesReport)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField NewField112;
                public TTReportField ENDDATE;
                public TTReportField LOGO; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 33;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 5, 153, 25, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 12;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"GEÇERLİLİK TARİHLERİ RAPORU";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 27, 38, 32, false);
                    NewField112.Name = "NewField112";
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"Geçerlilik Bitiş Tarihi :";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 27, 74, 32, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 5, 47, 25, false);
                    LOGO.Name = "LOGO";
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    NewField112.CalcValue = NewField112.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    LOGO.CalcValue = LOGO.Value;
                    return new TTReportObject[] { NewField111,NewField112,ENDDATE,LOGO};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public EffectiveDatesReport MyParentReport
                {
                    get { return (EffectiveDatesReport)ParentReport; }
                }
                
                public TTReportShape NewLine1111;
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 1, 207, 1, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 2, 139, 7, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 2, 207, 7, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 2, 38, 7, false);
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

        public PARTCGroup PARTC;

        public partial class PARTDGroup : TTReportGroup
        {
            public EffectiveDatesReport MyParentReport
            {
                get { return (EffectiveDatesReport)ParentReport; }
            }

            new public PARTDGroupHeader Header()
            {
                return (PARTDGroupHeader)_header;
            }

            new public PARTDGroupFooter Footer()
            {
                return (PARTDGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public PARTDGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTDGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTDGroupHeader(this);
                _footer = new PARTDGroupFooter(this);

            }

            public partial class PARTDGroupHeader : TTReportSection
            {
                public EffectiveDatesReport MyParentReport
                {
                    get { return (EffectiveDatesReport)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField1141;
                public TTReportShape NewLine111;
                public TTReportField NewField1121;
                public TTReportField NewField1221; 
                public PARTDGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 17;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 4, 74, 9, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.Underline = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"1. Geçerlilik Tarihi Bitecek Fiyatlar";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 11, 23, 15, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Fiyat Kodu";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 11, 121, 15, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Fiyat Açıklaması";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 11, 190, 15, false);
                    NewField141.Name = "NewField141";
                    NewField141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField141.NoClip = EvetHayirEnum.ehEvet;
                    NewField141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField141.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"Başlangıç Tarihi";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 11, 207, 15, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1141.NoClip = EvetHayirEnum.ehEvet;
                    NewField1141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1141.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"Bitiş Tarihi";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 16, 207, 16, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 11, 162, 15, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Fiyat";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 11, 145, 15, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"Fiyat Listesi";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    return new TTReportObject[] { NewField111,NewField121,NewField131,NewField141,NewField1141,NewField1121,NewField1221};
                }
            }
            public partial class PARTDGroupFooter : TTReportSection
            {
                public EffectiveDatesReport MyParentReport
                {
                    get { return (EffectiveDatesReport)ParentReport; }
                }
                 
                public PARTDGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTDGroup PARTD;

        public partial class MAINGroup : TTReportGroup
        {
            public EffectiveDatesReport MyParentReport
            {
                get { return (EffectiveDatesReport)ParentReport; }
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
            public TTReportField PRICINGLIST { get {return Body().PRICINGLIST;} }
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
                list[0] = new TTReportNqlData<PricingDetailDefinition.GetEffectivePricingDetailDefsByEndDate_Class>("GetEffectivePricingDetailDefsByEndDate", PricingDetailDefinition.GetEffectivePricingDetailDefsByEndDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public EffectiveDatesReport MyParentReport
                {
                    get { return (EffectiveDatesReport)ParentReport; }
                }
                
                public TTReportField CODE;
                public TTReportField DESCRIPTION;
                public TTReportField DATESTART;
                public TTReportField DATEEND;
                public TTReportField PRICE;
                public TTReportField PRICINGLIST; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 23, 6, false);
                    CODE.Name = "CODE";
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.MultiLine = EvetHayirEnum.ehEvet;
                    CODE.NoClip = EvetHayirEnum.ehEvet;
                    CODE.WordBreak = EvetHayirEnum.ehEvet;
                    CODE.ExpandTabs = EvetHayirEnum.ehEvet;
                    CODE.TextFont.CharSet = 162;
                    CODE.Value = @"{#EXTERNALCODE#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 1, 121, 6, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    DATESTART = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 1, 190, 6, false);
                    DATESTART.Name = "DATESTART";
                    DATESTART.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATESTART.TextFormat = @"Short Date";
                    DATESTART.TextFont.CharSet = 162;
                    DATESTART.Value = @"{#DATESTART#}";

                    DATEEND = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 1, 207, 6, false);
                    DATEEND.Name = "DATEEND";
                    DATEEND.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATEEND.TextFormat = @"Short Date";
                    DATEEND.TextFont.CharSet = 162;
                    DATEEND.Value = @"{#DATEEND#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 1, 162, 6, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.#0";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"{#PRICE#}";

                    PRICINGLIST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 1, 145, 6, false);
                    PRICINGLIST.Name = "PRICINGLIST";
                    PRICINGLIST.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICINGLIST.MultiLine = EvetHayirEnum.ehEvet;
                    PRICINGLIST.NoClip = EvetHayirEnum.ehEvet;
                    PRICINGLIST.WordBreak = EvetHayirEnum.ehEvet;
                    PRICINGLIST.ExpandTabs = EvetHayirEnum.ehEvet;
                    PRICINGLIST.TextFont.CharSet = 162;
                    PRICINGLIST.Value = @"{#PRICINGLISTNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PricingDetailDefinition.GetEffectivePricingDetailDefsByEndDate_Class dataset_GetEffectivePricingDetailDefsByEndDate = ParentGroup.rsGroup.GetCurrentRecord<PricingDetailDefinition.GetEffectivePricingDetailDefsByEndDate_Class>(0);
                    CODE.CalcValue = (dataset_GetEffectivePricingDetailDefsByEndDate != null ? Globals.ToStringCore(dataset_GetEffectivePricingDetailDefsByEndDate.ExternalCode) : "");
                    DESCRIPTION.CalcValue = (dataset_GetEffectivePricingDetailDefsByEndDate != null ? Globals.ToStringCore(dataset_GetEffectivePricingDetailDefsByEndDate.Description) : "");
                    DATESTART.CalcValue = (dataset_GetEffectivePricingDetailDefsByEndDate != null ? Globals.ToStringCore(dataset_GetEffectivePricingDetailDefsByEndDate.DateStart) : "");
                    DATEEND.CalcValue = (dataset_GetEffectivePricingDetailDefsByEndDate != null ? Globals.ToStringCore(dataset_GetEffectivePricingDetailDefsByEndDate.DateEnd) : "");
                    PRICE.CalcValue = (dataset_GetEffectivePricingDetailDefsByEndDate != null ? Globals.ToStringCore(dataset_GetEffectivePricingDetailDefsByEndDate.Price) : "");
                    PRICINGLIST.CalcValue = (dataset_GetEffectivePricingDetailDefsByEndDate != null ? Globals.ToStringCore(dataset_GetEffectivePricingDetailDefsByEndDate.Pricinglistname) : "");
                    return new TTReportObject[] { CODE,DESCRIPTION,DATESTART,DATEEND,PRICE,PRICINGLIST};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTBGroup : TTReportGroup
        {
            public EffectiveDatesReport MyParentReport
            {
                get { return (EffectiveDatesReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
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
                public EffectiveDatesReport MyParentReport
                {
                    get { return (EffectiveDatesReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField14;
                public TTReportShape NewLine1;
                public TTReportField NewField13; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 17;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 4, 97, 9, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.Underline = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"2. Geçerlilik Tarihi Bitecek Kurum Anlaşma Eşleştirmeleri";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 11, 116, 15, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Kurum Adı";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 11, 164, 15, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Anlaşma Adı";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 11, 188, 15, false);
                    NewField4.Name = "NewField4";
                    NewField4.MultiLine = EvetHayirEnum.ehEvet;
                    NewField4.NoClip = EvetHayirEnum.ehEvet;
                    NewField4.WordBreak = EvetHayirEnum.ehEvet;
                    NewField4.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Başlangıç Tarihi";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 11, 207, 15, false);
                    NewField14.Name = "NewField14";
                    NewField14.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14.NoClip = EvetHayirEnum.ehEvet;
                    NewField14.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Bitiş Tarihi";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 16, 207, 16, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 11, 27, 15, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Kurum Kodu";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField13.CalcValue = NewField13.Value;
                    return new TTReportObject[] { NewField1,NewField2,NewField3,NewField4,NewField14,NewField13};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public EffectiveDatesReport MyParentReport
                {
                    get { return (EffectiveDatesReport)ParentReport; }
                }
                
                public TTReportShape NewLine111;
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 1, 207, 1, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 2, 139, 7, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 2, 207, 7, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 2, 38, 7, false);
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

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public EffectiveDatesReport MyParentReport
            {
                get { return (EffectiveDatesReport)ParentReport; }
            }

            new public PARTAGroupBody Body()
            {
                return (PARTAGroupBody)_body;
            }
            public TTReportField PAYERNAME { get {return Body().PAYERNAME;} }
            public TTReportField PROTOCOLNAME { get {return Body().PROTOCOLNAME;} }
            public TTReportField STARTDATE { get {return Body().STARTDATE;} }
            public TTReportField ENDDATE { get {return Body().ENDDATE;} }
            public TTReportField PAYERCODE { get {return Body().PAYERCODE;} }
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
                list[0] = new TTReportNqlData<PayerProtocolDefinition.GetEffectivePayerProtocolDefsByEndDate_Class>("GetEffectivePayerProtocolDefsByEndDate", PayerProtocolDefinition.GetEffectivePayerProtocolDefsByEndDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTAGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupBody : TTReportSection
            {
                public EffectiveDatesReport MyParentReport
                {
                    get { return (EffectiveDatesReport)ParentReport; }
                }
                
                public TTReportField PAYERNAME;
                public TTReportField PROTOCOLNAME;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField PAYERCODE; 
                public PARTAGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    PAYERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 1, 116, 6, false);
                    PAYERNAME.Name = "PAYERNAME";
                    PAYERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERNAME.MultiLine = EvetHayirEnum.ehEvet;
                    PAYERNAME.NoClip = EvetHayirEnum.ehEvet;
                    PAYERNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PAYERNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYERNAME.TextFont.CharSet = 162;
                    PAYERNAME.Value = @"{#PAYERNAME#}";

                    PROTOCOLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 1, 164, 6, false);
                    PROTOCOLNAME.Name = "PROTOCOLNAME";
                    PROTOCOLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNAME.MultiLine = EvetHayirEnum.ehEvet;
                    PROTOCOLNAME.NoClip = EvetHayirEnum.ehEvet;
                    PROTOCOLNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PROTOCOLNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PROTOCOLNAME.TextFont.CharSet = 162;
                    PROTOCOLNAME.Value = @"{#PROTOCOLNAME#}";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 1, 188, 6, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{#PROTOCOLSTARTDATE#}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 1, 207, 6, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{#PROTOCOLENDDATE#}";

                    PAYERCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 27, 6, false);
                    PAYERCODE.Name = "PAYERCODE";
                    PAYERCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERCODE.TextFont.CharSet = 162;
                    PAYERCODE.Value = @"{#PAYERCODE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PayerProtocolDefinition.GetEffectivePayerProtocolDefsByEndDate_Class dataset_GetEffectivePayerProtocolDefsByEndDate = ParentGroup.rsGroup.GetCurrentRecord<PayerProtocolDefinition.GetEffectivePayerProtocolDefsByEndDate_Class>(0);
                    PAYERNAME.CalcValue = (dataset_GetEffectivePayerProtocolDefsByEndDate != null ? Globals.ToStringCore(dataset_GetEffectivePayerProtocolDefsByEndDate.Payername) : "");
                    PROTOCOLNAME.CalcValue = (dataset_GetEffectivePayerProtocolDefsByEndDate != null ? Globals.ToStringCore(dataset_GetEffectivePayerProtocolDefsByEndDate.Protocolname) : "");
                    STARTDATE.CalcValue = (dataset_GetEffectivePayerProtocolDefsByEndDate != null ? Globals.ToStringCore(dataset_GetEffectivePayerProtocolDefsByEndDate.ProtocolStartDate) : "");
                    ENDDATE.CalcValue = (dataset_GetEffectivePayerProtocolDefsByEndDate != null ? Globals.ToStringCore(dataset_GetEffectivePayerProtocolDefsByEndDate.ProtocolEndDate) : "");
                    PAYERCODE.CalcValue = (dataset_GetEffectivePayerProtocolDefsByEndDate != null ? Globals.ToStringCore(dataset_GetEffectivePayerProtocolDefsByEndDate.Payercode) : "");
                    return new TTReportObject[] { PAYERNAME,PROTOCOLNAME,STARTDATE,ENDDATE,PAYERCODE};
                }
            }

        }

        public PARTAGroup PARTA;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public EffectiveDatesReport()
        {
            PARTC = new PARTCGroup(this,"PARTC");
            PARTD = new PARTDGroup(PARTC,"PARTD");
            MAIN = new MAINGroup(PARTD,"MAIN");
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("ENDDATE", "", "Geçerlilik Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "EFFECTIVEDATESREPORT";
            Caption = "Geçerlilik Tarihleri Raporu";
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