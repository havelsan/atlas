
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
    /// Tedarik İkmal Kayıt Raporu
    /// </summary>
    public partial class SupplyConditionRegistryReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? MASTERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? MATERIALID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? SUPPLIERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? PROJECTNO = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public SupplyConditionRegistryReport MyParentReport
            {
                get { return (SupplyConditionRegistryReport)ParentReport; }
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
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField NewField133 { get {return Header().NewField133;} }
            public TTReportField NewField134 { get {return Header().NewField134;} }
            public TTReportField NewField135 { get {return Header().NewField135;} }
            public TTReportField NewField136 { get {return Header().NewField136;} }
            public TTReportField NewField137 { get {return Header().NewField137;} }
            public TTReportField NewField138 { get {return Header().NewField138;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportShape NewLine4 { get {return Header().NewLine4;} }
            public TTReportShape NewLine5 { get {return Header().NewLine5;} }
            public TTReportShape NewLine6 { get {return Header().NewLine6;} }
            public TTReportShape NewLine7 { get {return Header().NewLine7;} }
            public TTReportShape NewLine8 { get {return Header().NewLine8;} }
            public TTReportShape NewLine9 { get {return Header().NewLine9;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
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
                public SupplyConditionRegistryReport MyParentReport
                {
                    get { return (SupplyConditionRegistryReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField REPORTNAME;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField132;
                public TTReportField NewField133;
                public TTReportField NewField134;
                public TTReportField NewField135;
                public TTReportField NewField136;
                public TTReportField NewField137;
                public TTReportField NewField138;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportShape NewLine5;
                public TTReportShape NewLine6;
                public TTReportShape NewLine7;
                public TTReportShape NewLine8;
                public TTReportShape NewLine9;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportShape NewLine1;
                public TTReportField NewField13; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 62;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 15, 55, 35, false);
                    LOGO.Name = "LOGO";
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.Value = @"";

                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 15, 282, 35, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 12;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"TEDARİK İKMAL KAYIT DEFTERİ";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 40, 44, 45, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Başlangıç Tarihi";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 45, 44, 50, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Bitiş Tarihi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 40, 46, 45, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @":";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 45, 46, 50, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @":";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 55, 32, 60, false);
                    NewField131.Name = "NewField131";
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Proje Nu.";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 55, 151, 60, false);
                    NewField132.Name = "NewField132";
                    NewField132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField132.TextFont.Name = "Arial";
                    NewField132.TextFont.Bold = true;
                    NewField132.TextFont.CharSet = 162;
                    NewField132.Value = @"Firma Adı";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 55, 198, 60, false);
                    NewField133.Name = "NewField133";
                    NewField133.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField133.TextFont.Name = "Arial";
                    NewField133.TextFont.Bold = true;
                    NewField133.TextFont.CharSet = 162;
                    NewField133.Value = @"Malzeme/Hizmet Adı";

                    NewField134 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 55, 106, 60, false);
                    NewField134.Name = "NewField134";
                    NewField134.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField134.TextFont.Name = "Arial";
                    NewField134.TextFont.Bold = true;
                    NewField134.TextFont.CharSet = 162;
                    NewField134.Value = @"Birim Adı";

                    NewField135 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 55, 219, 60, false);
                    NewField135.Name = "NewField135";
                    NewField135.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField135.TextFont.Name = "Arial";
                    NewField135.TextFont.Bold = true;
                    NewField135.TextFont.CharSet = 162;
                    NewField135.Value = @"Miktar";

                    NewField136 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 55, 240, 60, false);
                    NewField136.Name = "NewField136";
                    NewField136.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField136.TextFont.Name = "Arial";
                    NewField136.TextFont.Bold = true;
                    NewField136.TextFont.CharSet = 162;
                    NewField136.Value = @"Birimi";

                    NewField137 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 55, 261, 60, false);
                    NewField137.Name = "NewField137";
                    NewField137.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField137.TextFont.Name = "Arial";
                    NewField137.TextFont.Bold = true;
                    NewField137.TextFont.CharSet = 162;
                    NewField137.Value = @"Birim Fiyatı";

                    NewField138 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 262, 55, 282, 60, false);
                    NewField138.Name = "NewField138";
                    NewField138.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField138.TextFont.Name = "Arial";
                    NewField138.TextFont.Bold = true;
                    NewField138.TextFont.CharSet = 162;
                    NewField138.Value = @"Toplam";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 33, 60, 60, 60, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 61, 60, 106, 60, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 107, 60, 151, 60, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 152, 60, 198, 60, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 199, 60, 219, 60, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 220, 60, 240, 60, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine8 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 241, 60, 261, 60, false);
                    NewLine8.Name = "NewLine8";
                    NewLine8.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine9 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 262, 60, 282, 60, false);
                    NewLine9.Name = "NewLine9";
                    NewLine9.DrawStyle = DrawStyleConstants.vbSolid;

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 40, 82, 45, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.TextFont.Name = "Arial";
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 45, 82, 50, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.TextFont.Name = "Arial";
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 60, 32, 60, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 55, 60, 60, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Durum";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField133.CalcValue = NewField133.Value;
                    NewField134.CalcValue = NewField134.Value;
                    NewField135.CalcValue = NewField135.Value;
                    NewField136.CalcValue = NewField136.Value;
                    NewField137.CalcValue = NewField137.Value;
                    NewField138.CalcValue = NewField138.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField13.CalcValue = NewField13.Value;
                    return new TTReportObject[] { LOGO,REPORTNAME,NewField1,NewField11,NewField12,NewField121,NewField131,NewField132,NewField133,NewField134,NewField135,NewField136,NewField137,NewField138,STARTDATE,ENDDATE,NewField13};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public SupplyConditionRegistryReport MyParentReport
                {
                    get { return (SupplyConditionRegistryReport)ParentReport; }
                }
                
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportField PrintDate;
                public TTReportShape NewLine111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 15;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 0, 162, 5, false);
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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 257, 0, 282, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 40, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 0, 282, 0, false);
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

        public partial class MAINGroup : TTReportGroup
        {
            public SupplyConditionRegistryReport MyParentReport
            {
                get { return (SupplyConditionRegistryReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PROJECTNO { get {return Body().PROJECTNO;} }
            public TTReportField SUPPLIER { get {return Body().SUPPLIER;} }
            public TTReportField MATERIALSERVICENAME { get {return Body().MATERIALSERVICENAME;} }
            public TTReportField UNIT { get {return Body().UNIT;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField TOTAL { get {return Body().TOTAL;} }
            public TTReportField STATE { get {return Body().STATE;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
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
                list[0] = new TTReportNqlData<PurchaseProject.GetSupplyConditionRegistryReportQuery_Class>("GetSupplyConditionRegistryReportQuery", PurchaseProject.GetSupplyConditionRegistryReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MASTERID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MASTERID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.SUPPLIERID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.PROJECTNO)));
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
                public SupplyConditionRegistryReport MyParentReport
                {
                    get { return (SupplyConditionRegistryReport)ParentReport; }
                }
                
                public TTReportField PROJECTNO;
                public TTReportField SUPPLIER;
                public TTReportField MATERIALSERVICENAME;
                public TTReportField UNIT;
                public TTReportField AMOUNT;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField UNITPRICE;
                public TTReportField TOTAL;
                public TTReportField STATE;
                public TTReportField OBJECTID;
                public TTReportShape NewLine1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    RepeatCount = 0;
                    
                    PROJECTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 1, 32, 14, false);
                    PROJECTNO.Name = "PROJECTNO";
                    PROJECTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROJECTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROJECTNO.MultiLine = EvetHayirEnum.ehEvet;
                    PROJECTNO.WordBreak = EvetHayirEnum.ehEvet;
                    PROJECTNO.TextFont.Name = "Arial";
                    PROJECTNO.TextFont.CharSet = 162;
                    PROJECTNO.Value = @"{#PURCHASEPROJECTNO#}";

                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 1, 151, 14, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER.MultiLine = EvetHayirEnum.ehEvet;
                    SUPPLIER.WordBreak = EvetHayirEnum.ehEvet;
                    SUPPLIER.TextFont.Name = "Arial";
                    SUPPLIER.TextFont.CharSet = 162;
                    SUPPLIER.Value = @"{#SUPPLIER#}";

                    MATERIALSERVICENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 1, 198, 14, false);
                    MATERIALSERVICENAME.Name = "MATERIALSERVICENAME";
                    MATERIALSERVICENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALSERVICENAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALSERVICENAME.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALSERVICENAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALSERVICENAME.TextFont.Name = "Arial";
                    MATERIALSERVICENAME.TextFont.CharSet = 162;
                    MATERIALSERVICENAME.Value = @"{#ITEMNAME#}";

                    UNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 1, 106, 14, false);
                    UNIT.Name = "UNIT";
                    UNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNIT.MultiLine = EvetHayirEnum.ehEvet;
                    UNIT.WordBreak = EvetHayirEnum.ehEvet;
                    UNIT.TextFont.Name = "Arial";
                    UNIT.TextFont.CharSet = 162;
                    UNIT.Value = @"{#MASTERRESOURCE#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 1, 219, 14, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    AMOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 220, 1, 240, 14, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTRIBUTIONTYPE.MultiLine = EvetHayirEnum.ehEvet;
                    DISTRIBUTIONTYPE.WordBreak = EvetHayirEnum.ehEvet;
                    DISTRIBUTIONTYPE.TextFont.Name = "Arial";
                    DISTRIBUTIONTYPE.TextFont.CharSet = 162;
                    DISTRIBUTIONTYPE.Value = @"{#TYPENAME#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 241, 1, 261, 14, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICE.MultiLine = EvetHayirEnum.ehEvet;
                    UNITPRICE.WordBreak = EvetHayirEnum.ehEvet;
                    UNITPRICE.TextFont.Name = "Arial";
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#PROPOSALPRICE#}";

                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 262, 1, 282, 14, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL.MultiLine = EvetHayirEnum.ehEvet;
                    TOTAL.WordBreak = EvetHayirEnum.ehEvet;
                    TOTAL.TextFont.Name = "Arial";
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"{#TOTAL#}";

                    STATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 1, 60, 14, false);
                    STATE.Name = "STATE";
                    STATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STATE.MultiLine = EvetHayirEnum.ehEvet;
                    STATE.WordBreak = EvetHayirEnum.ehEvet;
                    STATE.TextFont.Name = "Arial";
                    STATE.TextFont.CharSet = 162;
                    STATE.Value = @"";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 308, 3, 333, 16, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 14, 282, 14, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseProject.GetSupplyConditionRegistryReportQuery_Class dataset_GetSupplyConditionRegistryReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PurchaseProject.GetSupplyConditionRegistryReportQuery_Class>(0);
                    PROJECTNO.CalcValue = (dataset_GetSupplyConditionRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetSupplyConditionRegistryReportQuery.PurchaseProjectNO) : "");
                    SUPPLIER.CalcValue = (dataset_GetSupplyConditionRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetSupplyConditionRegistryReportQuery.Supplier) : "");
                    MATERIALSERVICENAME.CalcValue = (dataset_GetSupplyConditionRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetSupplyConditionRegistryReportQuery.ItemName) : "");
                    UNIT.CalcValue = (dataset_GetSupplyConditionRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetSupplyConditionRegistryReportQuery.Masterresource) : "");
                    AMOUNT.CalcValue = (dataset_GetSupplyConditionRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetSupplyConditionRegistryReportQuery.Amount) : "");
                    DISTRIBUTIONTYPE.CalcValue = (dataset_GetSupplyConditionRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetSupplyConditionRegistryReportQuery.Typename) : "");
                    UNITPRICE.CalcValue = (dataset_GetSupplyConditionRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetSupplyConditionRegistryReportQuery.ProposalPrice) : "");
                    TOTAL.CalcValue = (dataset_GetSupplyConditionRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetSupplyConditionRegistryReportQuery.Total) : "");
                    STATE.CalcValue = @"";
                    OBJECTID.CalcValue = (dataset_GetSupplyConditionRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetSupplyConditionRegistryReportQuery.ObjectID) : "");
                    return new TTReportObject[] { PROJECTNO,SUPPLIER,MATERIALSERVICENAME,UNIT,AMOUNT,DISTRIBUTIONTYPE,UNITPRICE,TOTAL,STATE,OBJECTID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    PurchaseProject pp = (PurchaseProject)MyParentReport.ReportObjectContext.GetObject(new Guid(OBJECTID.CalcValue), typeof(PurchaseProject));
            STATE.CalcValue = pp.CurrentStateDef.DisplayText.ToString();
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

        public SupplyConditionRegistryReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("MASTERID", "00000000-0000-0000-0000-000000000000", "Alım Yapan Birimi Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("44d92ee9-95ea-42f3-8a1a-07fce625510c");
            reportParameter = Parameters.Add("MATERIALID", "00000000-0000-0000-0000-000000000000", "Malzeme Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("0e92ac5f-6125-4c67-843c-6c8a8b8a0f5c");
            reportParameter = Parameters.Add("SUPPLIERID", "00000000-0000-0000-0000-000000000000", "Firma Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("41069fdc-2950-40b8-a40e-072e0d8d670b");
            reportParameter = Parameters.Add("PROJECTNO", "00000000-0000-0000-0000-000000000000", "Proje Numarasını Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("02201e8b-b96c-4551-b31b-4a1942f8b57e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("MASTERID"))
                _runtimeParameters.MASTERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MASTERID"]);
            if (parameters.ContainsKey("MATERIALID"))
                _runtimeParameters.MATERIALID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MATERIALID"]);
            if (parameters.ContainsKey("SUPPLIERID"))
                _runtimeParameters.SUPPLIERID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["SUPPLIERID"]);
            if (parameters.ContainsKey("PROJECTNO"))
                _runtimeParameters.PROJECTNO = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["PROJECTNO"]);
            Name = "SUPPLYCONDITIONREGISTRYREPORT";
            Caption = "Tedarik İkmal Kayıt Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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