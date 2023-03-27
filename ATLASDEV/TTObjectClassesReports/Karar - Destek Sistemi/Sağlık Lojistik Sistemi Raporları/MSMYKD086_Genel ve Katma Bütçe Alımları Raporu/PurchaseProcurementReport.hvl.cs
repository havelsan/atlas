
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
    /// Genel ve Katma Bütçe Alımları Raporu 
    /// </summary>
    public partial class PurchaseProcurementReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? ACCOUNTANCYID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? MASTERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? SUPPLIERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public ProcurementEnum? PROCUREMENTTYPE = (ProcurementEnum?)(int?)TTObjectDefManager.Instance.DataTypes["ProcurementEnum"].ConvertValue("");
            public PurchaseMainTypeEnum? PURCHASEMAINTYPE = (PurchaseMainTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PurchaseMainTypeEnum"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public PurchaseProcurementReport MyParentReport
            {
                get { return (PurchaseProcurementReport)ParentReport; }
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
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField133 { get {return Header().NewField133;} }
            public TTReportField NewField1431 { get {return Header().NewField1431;} }
            public TTReportField NewField1432 { get {return Header().NewField1432;} }
            public TTReportField NewField1331 { get {return Header().NewField1331;} }
            public TTReportField NewField134 { get {return Header().NewField134;} }
            public TTReportField NewField12341 { get {return Header().NewField12341;} }
            public TTReportField NewField12342 { get {return Header().NewField12342;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
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
                public PurchaseProcurementReport MyParentReport
                {
                    get { return (PurchaseProcurementReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField REPORTNAME;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField NewField13;
                public TTReportField NewField133;
                public TTReportField NewField1431;
                public TTReportField NewField1432;
                public TTReportField NewField1331;
                public TTReportField NewField134;
                public TTReportField NewField12341;
                public TTReportField NewField12342; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 56;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
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
                    REPORTNAME.TextFont.Size = 12;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"GENEL VE KATMA BÜTÇE ALIMLARI RAPORU";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 25, 30, 30, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Başlangıç Tarihi";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 30, 30, 35, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Bitiş Tarihi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 25, 31, 30, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @":";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 30, 31, 35, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @":";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 25, 56, 30, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.TextFont.Name = "Arial";
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 30, 56, 35, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.TextFont.Name = "Arial";
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 42, 19, 47, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Proje Nu.";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 42, 45, 47, false);
                    NewField133.Name = "NewField133";
                    NewField133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField133.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField133.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField133.TextFont.Name = "Arial";
                    NewField133.TextFont.Bold = true;
                    NewField133.TextFont.CharSet = 162;
                    NewField133.Value = @"Alım Kaynağı";

                    NewField1431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 42, 135, 47, false);
                    NewField1431.Name = "NewField1431";
                    NewField1431.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1431.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1431.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1431.TextFont.Name = "Arial";
                    NewField1431.TextFont.Bold = true;
                    NewField1431.TextFont.CharSet = 162;
                    NewField1431.Value = @"Birim";

                    NewField1432 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 42, 199, 47, false);
                    NewField1432.Name = "NewField1432";
                    NewField1432.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1432.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1432.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1432.TextFont.Name = "Arial";
                    NewField1432.TextFont.Bold = true;
                    NewField1432.TextFont.CharSet = 162;
                    NewField1432.Value = @"Firma";

                    NewField1331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 42, 159, 47, false);
                    NewField1331.Name = "NewField1331";
                    NewField1331.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1331.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1331.TextFont.Name = "Arial";
                    NewField1331.TextFont.Bold = true;
                    NewField1331.TextFont.CharSet = 162;
                    NewField1331.Value = @"İhale Usulü";

                    NewField134 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 42, 85, 47, false);
                    NewField134.Name = "NewField134";
                    NewField134.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField134.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField134.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField134.TextFont.Name = "Arial";
                    NewField134.TextFont.Bold = true;
                    NewField134.TextFont.CharSet = 162;
                    NewField134.Value = @"Saymanlık";

                    NewField12341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 42, 240, 47, false);
                    NewField12341.Name = "NewField12341";
                    NewField12341.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12341.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12341.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12341.TextFont.Name = "Arial";
                    NewField12341.TextFont.Bold = true;
                    NewField12341.TextFont.CharSet = 162;
                    NewField12341.Value = @"Malzeme/Hizmet Adı";

                    NewField12342 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 42, 257, 47, false);
                    NewField12342.Name = "NewField12342";
                    NewField12342.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12342.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12342.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12342.TextFont.Name = "Arial";
                    NewField12342.TextFont.Bold = true;
                    NewField12342.TextFont.CharSet = 162;
                    NewField12342.Value = @"Miktar";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField13.CalcValue = NewField13.Value;
                    NewField133.CalcValue = NewField133.Value;
                    NewField1431.CalcValue = NewField1431.Value;
                    NewField1432.CalcValue = NewField1432.Value;
                    NewField1331.CalcValue = NewField1331.Value;
                    NewField134.CalcValue = NewField134.Value;
                    NewField12341.CalcValue = NewField12341.Value;
                    NewField12342.CalcValue = NewField12342.Value;
                    return new TTReportObject[] { LOGO,REPORTNAME,NewField1,NewField11,NewField12,NewField121,STARTDATE,ENDDATE,NewField13,NewField133,NewField1431,NewField1432,NewField1331,NewField134,NewField12341,NewField12342};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public PurchaseProcurementReport MyParentReport
                {
                    get { return (PurchaseProcurementReport)ParentReport; }
                }
                
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportField PrintDate;
                public TTReportShape NewLine1111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 0, 142, 5, false);
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

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 257, 0, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

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

        public partial class MAINGroup : TTReportGroup
        {
            public PurchaseProcurementReport MyParentReport
            {
                get { return (PurchaseProcurementReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PROJECTNO { get {return Body().PROJECTNO;} }
            public TTReportField PROCUREMENTTYPE { get {return Body().PROCUREMENTTYPE;} }
            public TTReportField MASTERRESOURCE { get {return Body().MASTERRESOURCE;} }
            public TTReportField SUPPLIER { get {return Body().SUPPLIER;} }
            public TTReportField PURCHASEMAINTYPE { get {return Body().PURCHASEMAINTYPE;} }
            public TTReportField ACCOUNTANCY { get {return Body().ACCOUNTANCY;} }
            public TTReportField PURCHASEITEMDEF { get {return Body().PURCHASEITEMDEF;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
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
                list[0] = new TTReportNqlData<PurchaseProject.GetPurchaseProcurementReportQuery_Class>("GetPurchaseProcurementReportQuery", PurchaseProject.GetPurchaseProcurementReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.ACCOUNTANCYID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MASTERID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.SUPPLIERID),((ProcurementEnum)TTObjectDefManager.Instance.DataTypes["ProcurementEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.PROCUREMENTTYPE.ToString()].EnumValue),((PurchaseMainTypeEnum)TTObjectDefManager.Instance.DataTypes["PurchaseMainTypeEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.PURCHASEMAINTYPE.ToString()].EnumValue)));
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
                public PurchaseProcurementReport MyParentReport
                {
                    get { return (PurchaseProcurementReport)ParentReport; }
                }
                
                public TTReportField PROJECTNO;
                public TTReportField PROCUREMENTTYPE;
                public TTReportField MASTERRESOURCE;
                public TTReportField SUPPLIER;
                public TTReportField PURCHASEMAINTYPE;
                public TTReportField ACCOUNTANCY;
                public TTReportField PURCHASEITEMDEF;
                public TTReportField AMOUNT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    RepeatCount = 0;
                    
                    PROJECTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 19, 10, false);
                    PROJECTNO.Name = "PROJECTNO";
                    PROJECTNO.DrawStyle = DrawStyleConstants.vbSolid;
                    PROJECTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROJECTNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROJECTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO.MultiLine = EvetHayirEnum.ehEvet;
                    PROJECTNO.WordBreak = EvetHayirEnum.ehEvet;
                    PROJECTNO.TextFont.Name = "Arial";
                    PROJECTNO.TextFont.CharSet = 162;
                    PROJECTNO.Value = @"{#PURCHASEPROJECTNO#}";

                    PROCUREMENTTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 0, 45, 10, false);
                    PROCUREMENTTYPE.Name = "PROCUREMENTTYPE";
                    PROCUREMENTTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    PROCUREMENTTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCUREMENTTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROCUREMENTTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROCUREMENTTYPE.MultiLine = EvetHayirEnum.ehEvet;
                    PROCUREMENTTYPE.WordBreak = EvetHayirEnum.ehEvet;
                    PROCUREMENTTYPE.ObjectDefName = "ProcurementEnum";
                    PROCUREMENTTYPE.DataMember = "DISPLAYTEXT";
                    PROCUREMENTTYPE.TextFont.Name = "Arial";
                    PROCUREMENTTYPE.TextFont.CharSet = 162;
                    PROCUREMENTTYPE.Value = @"{#PROCUREMENTSOURCE#}";

                    MASTERRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 0, 135, 10, false);
                    MASTERRESOURCE.Name = "MASTERRESOURCE";
                    MASTERRESOURCE.DrawStyle = DrawStyleConstants.vbSolid;
                    MASTERRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MASTERRESOURCE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MASTERRESOURCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MASTERRESOURCE.MultiLine = EvetHayirEnum.ehEvet;
                    MASTERRESOURCE.WordBreak = EvetHayirEnum.ehEvet;
                    MASTERRESOURCE.TextFont.Name = "Arial";
                    MASTERRESOURCE.TextFont.CharSet = 162;
                    MASTERRESOURCE.Value = @"{#MASTERRESOURCE#}";

                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 0, 199, 10, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.DrawStyle = DrawStyleConstants.vbSolid;
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SUPPLIER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER.MultiLine = EvetHayirEnum.ehEvet;
                    SUPPLIER.WordBreak = EvetHayirEnum.ehEvet;
                    SUPPLIER.TextFont.Name = "Arial";
                    SUPPLIER.TextFont.CharSet = 162;
                    SUPPLIER.Value = @"{#SUPPLIER#}";

                    PURCHASEMAINTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 0, 159, 10, false);
                    PURCHASEMAINTYPE.Name = "PURCHASEMAINTYPE";
                    PURCHASEMAINTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    PURCHASEMAINTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PURCHASEMAINTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PURCHASEMAINTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PURCHASEMAINTYPE.MultiLine = EvetHayirEnum.ehEvet;
                    PURCHASEMAINTYPE.WordBreak = EvetHayirEnum.ehEvet;
                    PURCHASEMAINTYPE.ObjectDefName = "PurchaseMainTypeEnum";
                    PURCHASEMAINTYPE.DataMember = "DISPLAYTEXT";
                    PURCHASEMAINTYPE.TextFont.Name = "Arial";
                    PURCHASEMAINTYPE.TextFont.CharSet = 162;
                    PURCHASEMAINTYPE.Value = @"{#PURCHASEMAINTYPE#}";

                    ACCOUNTANCY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 0, 85, 10, false);
                    ACCOUNTANCY.Name = "ACCOUNTANCY";
                    ACCOUNTANCY.DrawStyle = DrawStyleConstants.vbSolid;
                    ACCOUNTANCY.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANCY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACCOUNTANCY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACCOUNTANCY.MultiLine = EvetHayirEnum.ehEvet;
                    ACCOUNTANCY.WordBreak = EvetHayirEnum.ehEvet;
                    ACCOUNTANCY.TextFont.Name = "Arial";
                    ACCOUNTANCY.TextFont.CharSet = 162;
                    ACCOUNTANCY.Value = @"{#ACCOUNTANCY#}";

                    PURCHASEITEMDEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 0, 240, 10, false);
                    PURCHASEITEMDEF.Name = "PURCHASEITEMDEF";
                    PURCHASEITEMDEF.DrawStyle = DrawStyleConstants.vbSolid;
                    PURCHASEITEMDEF.FieldType = ReportFieldTypeEnum.ftVariable;
                    PURCHASEITEMDEF.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PURCHASEITEMDEF.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PURCHASEITEMDEF.MultiLine = EvetHayirEnum.ehEvet;
                    PURCHASEITEMDEF.WordBreak = EvetHayirEnum.ehEvet;
                    PURCHASEITEMDEF.TextFont.Name = "Arial";
                    PURCHASEITEMDEF.TextFont.CharSet = 162;
                    PURCHASEITEMDEF.Value = @"{#ITEMNAME#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 0, 257, 10, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,###";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    AMOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.GetPurchaseProcurementReportQuery_Class dataset_GetPurchaseProcurementReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.GetPurchaseProcurementReportQuery_Class>(0);
                    PROJECTNO.CalcValue = (dataset_GetPurchaseProcurementReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseProcurementReportQuery.PurchaseProjectNO) : "");
                    PROCUREMENTTYPE.CalcValue = (dataset_GetPurchaseProcurementReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseProcurementReportQuery.ProcurementSource) : "");
                    PROCUREMENTTYPE.PostFieldValueCalculation();
                    MASTERRESOURCE.CalcValue = (dataset_GetPurchaseProcurementReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseProcurementReportQuery.Masterresource) : "");
                    SUPPLIER.CalcValue = (dataset_GetPurchaseProcurementReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseProcurementReportQuery.Supplier) : "");
                    PURCHASEMAINTYPE.CalcValue = (dataset_GetPurchaseProcurementReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseProcurementReportQuery.PurchaseMainType) : "");
                    PURCHASEMAINTYPE.PostFieldValueCalculation();
                    ACCOUNTANCY.CalcValue = (dataset_GetPurchaseProcurementReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseProcurementReportQuery.Accountancy) : "");
                    PURCHASEITEMDEF.CalcValue = (dataset_GetPurchaseProcurementReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseProcurementReportQuery.ItemName) : "");
                    AMOUNT.CalcValue = (dataset_GetPurchaseProcurementReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseProcurementReportQuery.Amount) : "");
                    return new TTReportObject[] { PROJECTNO,PROCUREMENTTYPE,MASTERRESOURCE,SUPPLIER,PURCHASEMAINTYPE,ACCOUNTANCY,PURCHASEITEMDEF,AMOUNT};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PurchaseProcurementReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ACCOUNTANCYID", "00000000-0000-0000-0000-000000000000", "Saymanlığı Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("fd3f96fc-fe7a-4a40-b07c-5ce13c17ae18");
            reportParameter = Parameters.Add("MASTERID", "00000000-0000-0000-0000-000000000000", "İlgili Bölümü Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("44d92ee9-95ea-42f3-8a1a-07fce625510c");
            reportParameter = Parameters.Add("SUPPLIERID", "00000000-0000-0000-0000-000000000000", "Firma Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("41069fdc-2950-40b8-a40e-072e0d8d670b");
            reportParameter = Parameters.Add("PROCUREMENTTYPE", "", "Alım Kaynağını Seçiniz", @"", true, true, false, new Guid("6bcfd7de-9d75-4ac6-bfd4-7503298a7e57"));
            reportParameter = Parameters.Add("PURCHASEMAINTYPE", "", "İhale Türünü Seçiniz", @"", true, true, false, new Guid("afd27c7f-3c79-4d7e-890f-7c7e65086bfc"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("ACCOUNTANCYID"))
                _runtimeParameters.ACCOUNTANCYID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["ACCOUNTANCYID"]);
            if (parameters.ContainsKey("MASTERID"))
                _runtimeParameters.MASTERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MASTERID"]);
            if (parameters.ContainsKey("SUPPLIERID"))
                _runtimeParameters.SUPPLIERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["SUPPLIERID"]);
            if (parameters.ContainsKey("PROCUREMENTTYPE"))
                _runtimeParameters.PROCUREMENTTYPE = (ProcurementEnum?)(int?)TTObjectDefManager.Instance.DataTypes["ProcurementEnum"].ConvertValue(parameters["PROCUREMENTTYPE"]);
            if (parameters.ContainsKey("PURCHASEMAINTYPE"))
                _runtimeParameters.PURCHASEMAINTYPE = (PurchaseMainTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["PurchaseMainTypeEnum"].ConvertValue(parameters["PURCHASEMAINTYPE"]);
            Name = "PURCHASEPROCUREMENTREPORT";
            Caption = "Genel ve Katma Bütçe Alımları Raporu ";
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