
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
    /// Günlük İlaç Çizelgesi İle Verilen İlaçlar Toplam Raporu
    /// </summary>
    public partial class KScheduleDrugPrescriptionTotalReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string STOREID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public int? STOREID_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public KScheduleDrugPrescriptionTotalReport MyParentReport
            {
                get { return (KScheduleDrugPrescriptionTotalReport)ParentReport; }
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
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField StartDate { get {return Header().StartDate;} }
            public TTReportField EndDate { get {return Header().EndDate;} }
            public TTReportField ReportName { get {return Header().ReportName;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
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
                public KScheduleDrugPrescriptionTotalReport MyParentReport
                {
                    get { return (KScheduleDrugPrescriptionTotalReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField StartDate;
                public TTReportField EndDate;
                public TTReportField ReportName; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 31;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 28, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 20, 133, 25, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Başlangıç Tarihi";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 110, 25, 133, 30, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Bitiş Tarihi";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 20, 134, 25, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @":";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 25, 134, 30, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @":";

                    StartDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 20, 178, 25, false);
                    StartDate.Name = "StartDate";
                    StartDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    StartDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    StartDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    StartDate.Value = @"{@STARTDATE@}";

                    EndDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 25, 178, 30, false);
                    EndDate.Name = "EndDate";
                    EndDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    EndDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    EndDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EndDate.Value = @"{@ENDDATE@}";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 0, 178, 20, false);
                    ReportName.Name = "ReportName";
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.MultiLine = EvetHayirEnum.ehEvet;
                    ReportName.WordBreak = EvetHayirEnum.ehEvet;
                    ReportName.TextFont.Size = 15;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"GÜNLÜK İLAÇ ÇİZELGESİ İLE VERİLEN İLAÇLAR TOPLAM RAPORU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    StartDate.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    EndDate.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    ReportName.CalcValue = ReportName.Value;
                    return new TTReportObject[] { LOGO,NewField1,NewField11,NewField2,NewField12,StartDate,EndDate,ReportName};
                }
                public override void RunPreScript()
                {
#region PARTA HEADER_PreScript
                    if (String.IsNullOrEmpty(((KScheduleDrugPrescriptionTotalReport)ParentReport).RuntimeParameters.STOREID) || ((KScheduleDrugPrescriptionTotalReport)ParentReport).RuntimeParameters.STOREID == Guid.Empty.ToString())
                ((KScheduleDrugPrescriptionTotalReport)ParentReport).RuntimeParameters.STOREID_FLAG = 0;
            else
                ((KScheduleDrugPrescriptionTotalReport)ParentReport).RuntimeParameters.STOREID_FLAG = 1;
            
//            if(((KScheduleDrugPrescriptionTotalReport)ParentReport).RuntimeParameters.ENDDATE != null)
//            {
//                ((KScheduleDrugPrescriptionTotalReport)ParentReport).RuntimeParameters.ENDDATE = new DateTime(((KScheduleDrugPrescriptionTotalReport)ParentReport).RuntimeParameters.ENDDATE.Value.Year, ((KScheduleDrugPrescriptionTotalReport)ParentReport).RuntimeParameters.ENDDATE.Value.Month, ((KScheduleDrugPrescriptionTotalReport)ParentReport).RuntimeParameters.ENDDATE.Value.Day, 23, 59, 59);
//            }
#endregion PARTA HEADER_PreScript
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    if (String.IsNullOrEmpty(((KScheduleDrugPrescriptionTotalReport)ParentReport).RuntimeParameters.STOREID) || ((KScheduleDrugPrescriptionTotalReport)ParentReport).RuntimeParameters.STOREID == Guid.Empty.ToString())
                ((KScheduleDrugPrescriptionTotalReport)ParentReport).RuntimeParameters.STOREID_FLAG = 0;
            else
                ((KScheduleDrugPrescriptionTotalReport)ParentReport).RuntimeParameters.STOREID_FLAG = 1;
            
//            if(((KScheduleDrugPrescriptionTotalReport)ParentReport).RuntimeParameters.ENDDATE != null)
//            {
//                ((KScheduleDrugPrescriptionTotalReport)ParentReport).RuntimeParameters.ENDDATE = new DateTime(((KScheduleDrugPrescriptionTotalReport)ParentReport).RuntimeParameters.ENDDATE.Value.Year, ((KScheduleDrugPrescriptionTotalReport)ParentReport).RuntimeParameters.ENDDATE.Value.Month, ((KScheduleDrugPrescriptionTotalReport)ParentReport).RuntimeParameters.ENDDATE.Value.Day, 23, 59, 59);
//            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public KScheduleDrugPrescriptionTotalReport MyParentReport
                {
                    get { return (KScheduleDrugPrescriptionTotalReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField PageNumber;
                public TTReportField CurrentUser;
                public TTReportShape NewLine11; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 0, 100, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 170, 0, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = @"Sayfa Nu." + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PageNumber,CurrentUser};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public KScheduleDrugPrescriptionTotalReport MyParentReport
            {
                get { return (KScheduleDrugPrescriptionTotalReport)ParentReport; }
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
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField STORENAME { get {return Header().STORENAME;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
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
                list[0] = new TTReportNqlData<KSchedule.GetKScheduleDrugPrescriptionTotalMainQuery_Class>("GetKScheduleDrugPrescriptionTotalMainQuery", KSchedule.GetKScheduleDrugPrescriptionTotalMainQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.STOREID_FLAG)));
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
                public KScheduleDrugPrescriptionTotalReport MyParentReport
                {
                    get { return (KScheduleDrugPrescriptionTotalReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField112;
                public TTReportShape NewLine1;
                public TTReportField STORENAME;
                public TTReportField NewField131;
                public TTReportField NewField1121; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 20;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 14, 13, 19, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Sıra Nu.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 14, 130, 19, false);
                    NewField11.Name = "NewField11";
                    NewField11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"İlaç Adı";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 14, 178, 19, false);
                    NewField111.Name = "NewField111";
                    NewField111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Toplam";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 14, 162, 19, false);
                    NewField112.Name = "NewField112";
                    NewField112.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.Size = 11;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"İlaç Kodu";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 19, 178, 19, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    STORENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 8, 178, 13, false);
                    STORENAME.Name = "STORENAME";
                    STORENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORENAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    STORENAME.TextFormat = @"dd/MM/yyyy";
                    STORENAME.MultiLine = EvetHayirEnum.ehEvet;
                    STORENAME.WordBreak = EvetHayirEnum.ehEvet;
                    STORENAME.Value = @"{#STORENAME#}";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 8, 68, 13, false);
                    NewField131.Name = "NewField131";
                    NewField131.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NewField131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"İstek Yapan Birimin Deposu";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 8, 69, 13, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    KSchedule.GetKScheduleDrugPrescriptionTotalMainQuery_Class dataset_GetKScheduleDrugPrescriptionTotalMainQuery = ParentGroup.rsGroup.GetCurrentRecord<KSchedule.GetKScheduleDrugPrescriptionTotalMainQuery_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField112.CalcValue = NewField112.Value;
                    STORENAME.CalcValue = (dataset_GetKScheduleDrugPrescriptionTotalMainQuery != null ? Globals.ToStringCore(dataset_GetKScheduleDrugPrescriptionTotalMainQuery.Storename) : "");
                    NewField131.CalcValue = NewField131.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    return new TTReportObject[] { NewField1,NewField11,NewField111,NewField112,STORENAME,NewField131,NewField1121};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public KScheduleDrugPrescriptionTotalReport MyParentReport
                {
                    get { return (KScheduleDrugPrescriptionTotalReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public KScheduleDrugPrescriptionTotalReport MyParentReport
            {
                get { return (KScheduleDrugPrescriptionTotalReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField OrderNO { get {return Body().OrderNO;} }
            public TTReportField DrugName { get {return Body().DrugName;} }
            public TTReportField Code { get {return Body().Code;} }
            public TTReportField TotalAmount { get {return Body().TotalAmount;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
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

                KSchedule.GetKScheduleDrugPrescriptionTotalMainQuery_Class dataSet_GetKScheduleDrugPrescriptionTotalMainQuery = ParentGroup.rsGroup.GetCurrentRecord<KSchedule.GetKScheduleDrugPrescriptionTotalMainQuery_Class>(0);    
                return new object[] {(dataSet_GetKScheduleDrugPrescriptionTotalMainQuery==null ? null : dataSet_GetKScheduleDrugPrescriptionTotalMainQuery.Storename)};
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
                public KScheduleDrugPrescriptionTotalReport MyParentReport
                {
                    get { return (KScheduleDrugPrescriptionTotalReport)ParentReport; }
                }
                
                public TTReportField OrderNO;
                public TTReportField DrugName;
                public TTReportField Code;
                public TTReportField TotalAmount;
                public TTReportShape NewLine1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    OrderNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 13, 6, false);
                    OrderNO.Name = "OrderNO";
                    OrderNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    OrderNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OrderNO.Value = @"{@groupcounter@}";

                    DrugName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 1, 130, 6, false);
                    DrugName.Name = "DrugName";
                    DrugName.FieldType = ReportFieldTypeEnum.ftVariable;
                    DrugName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DrugName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DrugName.Value = @"{#PARTB.NAME#}";

                    Code = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 1, 162, 6, false);
                    Code.Name = "Code";
                    Code.FieldType = ReportFieldTypeEnum.ftVariable;
                    Code.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Code.Value = @"{#PARTB.BARCODE#}";

                    TotalAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 1, 178, 6, false);
                    TotalAmount.Name = "TotalAmount";
                    TotalAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    TotalAmount.TextFormat = @"#,###";
                    TotalAmount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TotalAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TotalAmount.Value = @"{#PARTB.AMOUNT#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 178, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    KSchedule.GetKScheduleDrugPrescriptionTotalMainQuery_Class dataset_GetKScheduleDrugPrescriptionTotalMainQuery = MyParentReport.PARTB.rsGroup.GetCurrentRecord<KSchedule.GetKScheduleDrugPrescriptionTotalMainQuery_Class>(0);
                    OrderNO.CalcValue = ParentGroup.GroupCounter.ToString();
                    DrugName.CalcValue = (dataset_GetKScheduleDrugPrescriptionTotalMainQuery != null ? Globals.ToStringCore(dataset_GetKScheduleDrugPrescriptionTotalMainQuery.Name) : "");
                    Code.CalcValue = (dataset_GetKScheduleDrugPrescriptionTotalMainQuery != null ? Globals.ToStringCore(dataset_GetKScheduleDrugPrescriptionTotalMainQuery.Barcode) : "");
                    TotalAmount.CalcValue = (dataset_GetKScheduleDrugPrescriptionTotalMainQuery != null ? Globals.ToStringCore(dataset_GetKScheduleDrugPrescriptionTotalMainQuery.Amount) : "");
                    return new TTReportObject[] { OrderNO,DrugName,Code,TotalAmount};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public KScheduleDrugPrescriptionTotalReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOREID", "", "Depo Seçiniz :", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("d92d20fb-3679-4f07-9906-fc1a75f26d16");
            reportParameter = Parameters.Add("STOREID_FLAG", "", "STOREID_FLAG", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihini Giriniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihini Giriniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["STOREID"]);
            if (parameters.ContainsKey("STOREID_FLAG"))
                _runtimeParameters.STOREID_FLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["STOREID_FLAG"]);
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "KSCHEDULEDRUGPRESCRIPTIONTOTALREPORT";
            Caption = "Günlük İlaç Çizelgesi İle Verilen İlaçlar Toplam Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
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