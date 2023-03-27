
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
    /// Satın Alma İstek İzleme Raporu
    /// </summary>
    public partial class SatinalmaIstekIzleme : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? ACCOUNTANCYID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? PURCHASEPROJECTNO = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public string CONFIRMNO = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("0");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public SatinalmaIstekIzleme MyParentReport
            {
                get { return (SatinalmaIstekIzleme)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
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
                public SatinalmaIstekIzleme MyParentReport
                {
                    get { return (SatinalmaIstekIzleme)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField REPORTNAME; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 257, 20, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 15;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"SATIN ALMA İSTEK İZLEME RAPORU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    return new TTReportObject[] { LOGO,REPORTNAME};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public SatinalmaIstekIzleme MyParentReport
                {
                    get { return (SatinalmaIstekIzleme)ParentReport; }
                }
                
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportField PrintDate;
                public TTReportShape NewLine111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 0, 137, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser.TextFont.Name = "Arial";
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 0, 257, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 257, 0, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PageNumber,PrintDate,CurrentUser};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public SatinalmaIstekIzleme MyParentReport
            {
                get { return (SatinalmaIstekIzleme)ParentReport; }
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
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField NewField133 { get {return Header().NewField133;} }
            public TTReportField NewField134 { get {return Header().NewField134;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField ACCOUNTANCY { get {return Header().ACCOUNTANCY;} }
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
                list[0] = new TTReportNqlData<PurchaseProject.SatinAlmaIstekIzlemeQuery_Class>("SatinAlmaIstekIzlemeQuery", PurchaseProject.SatinAlmaIstekIzlemeQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.ACCOUNTANCYID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.PURCHASEPROJECTNO),(string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.CONFIRMNO)));
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
                public SatinalmaIstekIzleme MyParentReport
                {
                    get { return (SatinalmaIstekIzleme)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField131;
                public TTReportField NewField132;
                public TTReportField NewField133;
                public TTReportField NewField134;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportShape NewLine1;
                public TTReportField NewField161;
                public TTReportField ACCOUNTANCY; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 28;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 16, 21, 26, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Proje Nu.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 16, 61, 26, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"İş Tanımı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 16, 90, 26, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Durumu";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 16, 115, 26, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Size = 11;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Onay Nu.";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 16, 140, 26, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Size = 11;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Onay Tarihi";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 16, 190, 21, false);
                    NewField132.Name = "NewField132";
                    NewField132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField132.TextFont.Name = "Arial";
                    NewField132.TextFont.Size = 11;
                    NewField132.TextFont.Bold = true;
                    NewField132.TextFont.CharSet = 162;
                    NewField132.Value = @"Miktar";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 21, 165, 26, false);
                    NewField133.Name = "NewField133";
                    NewField133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField133.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField133.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField133.TextFont.Name = "Arial";
                    NewField133.TextFont.Size = 11;
                    NewField133.TextFont.Bold = true;
                    NewField133.TextFont.CharSet = 162;
                    NewField133.Value = @"İstenen";

                    NewField134 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 21, 190, 26, false);
                    NewField134.Name = "NewField134";
                    NewField134.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField134.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField134.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField134.TextFont.Name = "Arial";
                    NewField134.TextFont.Size = 11;
                    NewField134.TextFont.Bold = true;
                    NewField134.TextFont.CharSet = 162;
                    NewField134.Value = @"Onaylanan";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 16, 257, 26, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Size = 11;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Açıklama";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 20, 10, false);
                    NewField15.Name = "NewField15";
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Saymanlık";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 13, 257, 13, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 5, 21, 10, false);
                    NewField161.Name = "NewField161";
                    NewField161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @":";

                    ACCOUNTANCY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 5, 48, 10, false);
                    ACCOUNTANCY.Name = "ACCOUNTANCY";
                    ACCOUNTANCY.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANCY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACCOUNTANCY.NoClip = EvetHayirEnum.ehEvet;
                    ACCOUNTANCY.TextFont.Name = "Arial";
                    ACCOUNTANCY.TextFont.CharSet = 162;
                    ACCOUNTANCY.Value = @"{#NAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.SatinAlmaIstekIzlemeQuery_Class dataset_SatinAlmaIstekIzlemeQuery = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.SatinAlmaIstekIzlemeQuery_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField133.CalcValue = NewField133.Value;
                    NewField134.CalcValue = NewField134.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField161.CalcValue = NewField161.Value;
                    ACCOUNTANCY.CalcValue = (dataset_SatinAlmaIstekIzlemeQuery != null ? Globals.ToStringCore(dataset_SatinAlmaIstekIzlemeQuery.Name) : "");
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField13,NewField131,NewField132,NewField133,NewField134,NewField14,NewField15,NewField161,ACCOUNTANCY};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public SatinalmaIstekIzleme MyParentReport
                {
                    get { return (SatinalmaIstekIzleme)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public SatinalmaIstekIzleme MyParentReport
            {
                get { return (SatinalmaIstekIzleme)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PURCHASEPROJECTNO { get {return Body().PURCHASEPROJECTNO;} }
            public TTReportField PURCHASEPROJECTSTATE { get {return Body().PURCHASEPROJECTSTATE;} }
            public TTReportField CONFIRMNO { get {return Body().CONFIRMNO;} }
            public TTReportField CONFIRMDATE { get {return Body().CONFIRMDATE;} }
            public TTReportField REQUESTEDAMOUNT { get {return Body().REQUESTEDAMOUNT;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField ACTDEFINE { get {return Body().ACTDEFINE;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
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

                PurchaseProject.SatinAlmaIstekIzlemeQuery_Class dataSet_SatinAlmaIstekIzlemeQuery = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.SatinAlmaIstekIzlemeQuery_Class>(0);    
                return new object[] {(dataSet_SatinAlmaIstekIzlemeQuery==null ? null : dataSet_SatinAlmaIstekIzlemeQuery.Name)};
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
                public SatinalmaIstekIzleme MyParentReport
                {
                    get { return (SatinalmaIstekIzleme)ParentReport; }
                }
                
                public TTReportField PURCHASEPROJECTNO;
                public TTReportField PURCHASEPROJECTSTATE;
                public TTReportField CONFIRMNO;
                public TTReportField CONFIRMDATE;
                public TTReportField REQUESTEDAMOUNT;
                public TTReportField AMOUNT;
                public TTReportField DESCRIPTION;
                public TTReportField ACTDEFINE;
                public TTReportField OBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 12;
                    RepeatCount = 0;
                    
                    PURCHASEPROJECTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 21, 9, false);
                    PURCHASEPROJECTNO.Name = "PURCHASEPROJECTNO";
                    PURCHASEPROJECTNO.DrawStyle = DrawStyleConstants.vbSolid;
                    PURCHASEPROJECTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PURCHASEPROJECTNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PURCHASEPROJECTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PURCHASEPROJECTNO.TextFont.Name = "Arial";
                    PURCHASEPROJECTNO.TextFont.CharSet = 162;
                    PURCHASEPROJECTNO.Value = @"{#PARTB.PURCHASEPROJECTNO#}";

                    PURCHASEPROJECTSTATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 0, 90, 9, false);
                    PURCHASEPROJECTSTATE.Name = "PURCHASEPROJECTSTATE";
                    PURCHASEPROJECTSTATE.DrawStyle = DrawStyleConstants.vbSolid;
                    PURCHASEPROJECTSTATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PURCHASEPROJECTSTATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PURCHASEPROJECTSTATE.MultiLine = EvetHayirEnum.ehEvet;
                    PURCHASEPROJECTSTATE.WordBreak = EvetHayirEnum.ehEvet;
                    PURCHASEPROJECTSTATE.TextFont.Name = "Arial";
                    PURCHASEPROJECTSTATE.TextFont.CharSet = 162;
                    PURCHASEPROJECTSTATE.Value = @"";

                    CONFIRMNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 0, 115, 9, false);
                    CONFIRMNO.Name = "CONFIRMNO";
                    CONFIRMNO.DrawStyle = DrawStyleConstants.vbSolid;
                    CONFIRMNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONFIRMNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CONFIRMNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONFIRMNO.TextFont.Name = "Arial";
                    CONFIRMNO.TextFont.CharSet = 162;
                    CONFIRMNO.Value = @"{#PARTB.CONFIRMNO#}";

                    CONFIRMDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 0, 140, 9, false);
                    CONFIRMDATE.Name = "CONFIRMDATE";
                    CONFIRMDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    CONFIRMDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONFIRMDATE.TextFormat = @"dd/MM/yyyy";
                    CONFIRMDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CONFIRMDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONFIRMDATE.TextFont.Name = "Arial";
                    CONFIRMDATE.TextFont.CharSet = 162;
                    CONFIRMDATE.Value = @"{#PARTB.CONFIRMDATE#}";

                    REQUESTEDAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 0, 165, 9, false);
                    REQUESTEDAMOUNT.Name = "REQUESTEDAMOUNT";
                    REQUESTEDAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUESTEDAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTEDAMOUNT.TextFormat = @"#,###";
                    REQUESTEDAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTEDAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTEDAMOUNT.TextFont.Name = "Arial";
                    REQUESTEDAMOUNT.TextFont.CharSet = 162;
                    REQUESTEDAMOUNT.Value = @"{#PARTB.REQUESTEDAMOUNT#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 0, 190, 9, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,###";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#PARTB.AMOUNT#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 0, 257, 9, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.DrawStyle = DrawStyleConstants.vbSolid;
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DESCRIPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION.TextFont.Name = "Arial";
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"";

                    ACTDEFINE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 0, 61, 9, false);
                    ACTDEFINE.Name = "ACTDEFINE";
                    ACTDEFINE.DrawStyle = DrawStyleConstants.vbSolid;
                    ACTDEFINE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTDEFINE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTDEFINE.MultiLine = EvetHayirEnum.ehEvet;
                    ACTDEFINE.WordBreak = EvetHayirEnum.ehEvet;
                    ACTDEFINE.TextFont.Name = "Arial";
                    ACTDEFINE.TextFont.CharSet = 162;
                    ACTDEFINE.Value = @" {#PARTB.ACTDEFINE#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 0, 328, 9, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#PARTB.OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.SatinAlmaIstekIzlemeQuery_Class dataset_SatinAlmaIstekIzlemeQuery = MyParentReport.PARTB.rsGroup.GetCurrentRecord<PurchaseProject.SatinAlmaIstekIzlemeQuery_Class>(0);
                    PURCHASEPROJECTNO.CalcValue = (dataset_SatinAlmaIstekIzlemeQuery != null ? Globals.ToStringCore(dataset_SatinAlmaIstekIzlemeQuery.PurchaseProjectNO) : "");
                    PURCHASEPROJECTSTATE.CalcValue = @"";
                    CONFIRMNO.CalcValue = (dataset_SatinAlmaIstekIzlemeQuery != null ? Globals.ToStringCore(dataset_SatinAlmaIstekIzlemeQuery.ConfirmNO) : "");
                    CONFIRMDATE.CalcValue = (dataset_SatinAlmaIstekIzlemeQuery != null ? Globals.ToStringCore(dataset_SatinAlmaIstekIzlemeQuery.ConfirmDate) : "");
                    REQUESTEDAMOUNT.CalcValue = (dataset_SatinAlmaIstekIzlemeQuery != null ? Globals.ToStringCore(dataset_SatinAlmaIstekIzlemeQuery.RequestedAmount) : "");
                    AMOUNT.CalcValue = (dataset_SatinAlmaIstekIzlemeQuery != null ? Globals.ToStringCore(dataset_SatinAlmaIstekIzlemeQuery.Amount) : "");
                    DESCRIPTION.CalcValue = @"";
                    ACTDEFINE.CalcValue = @" " + (dataset_SatinAlmaIstekIzlemeQuery != null ? Globals.ToStringCore(dataset_SatinAlmaIstekIzlemeQuery.ActDefine) : "");
                    OBJECTID.CalcValue = (dataset_SatinAlmaIstekIzlemeQuery != null ? Globals.ToStringCore(dataset_SatinAlmaIstekIzlemeQuery.ObjectID) : "");
                    return new TTReportObject[] { PURCHASEPROJECTNO,PURCHASEPROJECTSTATE,CONFIRMNO,CONFIRMDATE,REQUESTEDAMOUNT,AMOUNT,DESCRIPTION,ACTDEFINE,OBJECTID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    PurchaseProject pp = (PurchaseProject)MyParentReport.ReportObjectContext.GetObject(new Guid(OBJECTID.CalcValue), typeof(PurchaseProject));
            if(pp.CurrentStateDef != null)
                PURCHASEPROJECTSTATE.CalcValue = " " + pp.CurrentStateDef.DisplayText;
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public SatinalmaIstekIzleme()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("ACCOUNTANCYID", "00000000-0000-0000-0000-000000000000", "Saymanlık Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("fd3f96fc-fe7a-4a40-b07c-5ce13c17ae18");
            reportParameter = Parameters.Add("PURCHASEPROJECTNO", "00000000-0000-0000-0000-000000000000", "Proje Numarasını Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
            reportParameter = Parameters.Add("CONFIRMNO", "0", "Onay Numarasını Giriniz", @"", true, true, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("ACCOUNTANCYID"))
                _runtimeParameters.ACCOUNTANCYID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["ACCOUNTANCYID"]);
            if (parameters.ContainsKey("PURCHASEPROJECTNO"))
                _runtimeParameters.PURCHASEPROJECTNO = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["PURCHASEPROJECTNO"]);
            if (parameters.ContainsKey("CONFIRMNO"))
                _runtimeParameters.CONFIRMNO = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["CONFIRMNO"]);
            Name = "SATINALMAISTEKIZLEME";
            Caption = "Satın Alma İstek İzleme Raporu";
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