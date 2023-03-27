
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
    /// Malzeme/İlaç Miat Çizelgesi Raporu
    /// </summary>
    public partial class MaterialExpirationSchedule : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public MaterialExpirationSchedule MyParentReport
            {
                get { return (MaterialExpirationSchedule)ParentReport; }
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
            public TTReportField PARAMETERNAME1 { get {return Header().PARAMETERNAME1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField STORENAME { get {return Header().STORENAME;} }
            public TTReportField PARAMETERNAME11 { get {return Header().PARAMETERNAME11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField PARAMETERNAME12 { get {return Header().PARAMETERNAME12;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
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
                public MaterialExpirationSchedule MyParentReport
                {
                    get { return (MaterialExpirationSchedule)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField LOGO;
                public TTReportField PARAMETERNAME1;
                public TTReportField NewField11;
                public TTReportField STORENAME;
                public TTReportField PARAMETERNAME11;
                public TTReportField NewField111;
                public TTReportField PARAMETERNAME12;
                public TTReportField NewField112;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 46;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 170, 20, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 12;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"MALZEME/İLAÇ MİAT ÇİZELGESİ RAPORU";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.Value = @"";

                    PARAMETERNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 25, 29, 30, false);
                    PARAMETERNAME1.Name = "PARAMETERNAME1";
                    PARAMETERNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME1.TextFont.Name = "Arial";
                    PARAMETERNAME1.TextFont.Bold = true;
                    PARAMETERNAME1.TextFont.CharSet = 162;
                    PARAMETERNAME1.Value = @"Depo Adı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 25, 30, 30, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @":";

                    STORENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 25, 170, 30, false);
                    STORENAME.Name = "STORENAME";
                    STORENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORENAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STORENAME.WordBreak = EvetHayirEnum.ehEvet;
                    STORENAME.ObjectDefName = "Store";
                    STORENAME.DataMember = "NAME";
                    STORENAME.TextFont.Name = "Arial";
                    STORENAME.TextFont.CharSet = 162;
                    STORENAME.Value = @"{@STOREID@}";

                    PARAMETERNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 31, 29, 36, false);
                    PARAMETERNAME11.Name = "PARAMETERNAME11";
                    PARAMETERNAME11.Visible = EvetHayirEnum.ehHayir;
                    PARAMETERNAME11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME11.TextFont.Name = "Arial";
                    PARAMETERNAME11.TextFont.Bold = true;
                    PARAMETERNAME11.TextFont.CharSet = 162;
                    PARAMETERNAME11.Value = @"Başlangıç Tarihi";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 31, 30, 36, false);
                    NewField111.Name = "NewField111";
                    NewField111.Visible = EvetHayirEnum.ehHayir;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @":";

                    PARAMETERNAME12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 37, 29, 42, false);
                    PARAMETERNAME12.Name = "PARAMETERNAME12";
                    PARAMETERNAME12.Visible = EvetHayirEnum.ehHayir;
                    PARAMETERNAME12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME12.TextFont.Name = "Arial";
                    PARAMETERNAME12.TextFont.Bold = true;
                    PARAMETERNAME12.TextFont.CharSet = 162;
                    PARAMETERNAME12.Value = @"Bitiş Tarihi";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 37, 30, 42, false);
                    NewField112.Name = "NewField112";
                    NewField112.Visible = EvetHayirEnum.ehHayir;
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.Name = "Arial";
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @":";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 31, 170, 36, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.TextFont.Name = "Arial";
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 37, 170, 42, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.TextFont.Name = "Arial";
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    LOGO.CalcValue = LOGO.Value;
                    PARAMETERNAME1.CalcValue = PARAMETERNAME1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    STORENAME.CalcValue = MyParentReport.RuntimeParameters.STOREID.ToString();
                    STORENAME.PostFieldValueCalculation();
                    PARAMETERNAME11.CalcValue = PARAMETERNAME11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    PARAMETERNAME12.CalcValue = PARAMETERNAME12.Value;
                    NewField112.CalcValue = NewField112.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { REPORTNAME,LOGO,PARAMETERNAME1,NewField11,STORENAME,PARAMETERNAME11,NewField111,PARAMETERNAME12,NewField112,STARTDATE,ENDDATE};
                }
                public override void RunPreScript()
                {
#region PARTA HEADER_PreScript
                    DateTime TimeNow = DateTime.Now;
                    DateTime TimeStart = DateTime.Now.AddMonths(-6);

                    if (((MaterialExpirationSchedule)ParentReport).RuntimeParameters.ENDDATE == null)
                    {
                        ((MaterialExpirationSchedule)ParentReport).RuntimeParameters.ENDDATE = new DateTime(TimeNow.Year, TimeNow.Month, TimeNow.Day, 23, 59, 59);
                    }
                    if (((MaterialExpirationSchedule)ParentReport).RuntimeParameters.STARTDATE == null)
                    {
                        ((MaterialExpirationSchedule)ParentReport).RuntimeParameters.STARTDATE = new DateTime(TimeStart.Year, TimeStart.Month, TimeStart.Day, 23, 59, 59);
                    }
#endregion PARTA HEADER_PreScript
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MaterialExpirationSchedule MyParentReport
                {
                    get { return (MaterialExpirationSchedule)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportShape NewLine111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 22;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 0, 95, 5, false);
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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 170, 0, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PageNumber,CurrentUser};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public MaterialExpirationSchedule MyParentReport
            {
                get { return (MaterialExpirationSchedule)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField COLUMNNAME2 { get {return Header().COLUMNNAME2;} }
            public TTReportField COLUMNNAME12 { get {return Header().COLUMNNAME12;} }
            public TTReportField COLUMNNAME13 { get {return Header().COLUMNNAME13;} }
            public TTReportField COLUMNNAME14 { get {return Header().COLUMNNAME14;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
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
                public MaterialExpirationSchedule MyParentReport
                {
                    get { return (MaterialExpirationSchedule)ParentReport; }
                }
                
                public TTReportField COLUMNNAME2;
                public TTReportField COLUMNNAME12;
                public TTReportField COLUMNNAME13;
                public TTReportField COLUMNNAME14;
                public TTReportShape NewLine1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 9;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    COLUMNNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 3, 106, 8, false);
                    COLUMNNAME2.Name = "COLUMNNAME2";
                    COLUMNNAME2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLUMNNAME2.TextFont.Name = "Arial";
                    COLUMNNAME2.TextFont.Bold = true;
                    COLUMNNAME2.TextFont.CharSet = 162;
                    COLUMNNAME2.Value = @"Malzeme / İlacın Adı";

                    COLUMNNAME12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 188, 2, 209, 7, false);
                    COLUMNNAME12.Name = "COLUMNNAME12";
                    COLUMNNAME12.Visible = EvetHayirEnum.ehHayir;
                    COLUMNNAME12.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLUMNNAME12.TextFont.Name = "Arial";
                    COLUMNNAME12.TextFont.Bold = true;
                    COLUMNNAME12.TextFont.CharSet = 162;
                    COLUMNNAME12.Value = @"Miktar";

                    COLUMNNAME13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 3, 144, 8, false);
                    COLUMNNAME13.Name = "COLUMNNAME13";
                    COLUMNNAME13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLUMNNAME13.TextFont.Name = "Arial";
                    COLUMNNAME13.TextFont.Bold = true;
                    COLUMNNAME13.TextFont.CharSet = 162;
                    COLUMNNAME13.Value = @"S.K. Tarihi";

                    COLUMNNAME14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 3, 170, 8, false);
                    COLUMNNAME14.Name = "COLUMNNAME14";
                    COLUMNNAME14.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME14.TextFont.Name = "Arial";
                    COLUMNNAME14.TextFont.Bold = true;
                    COLUMNNAME14.TextFont.CharSet = 162;
                    COLUMNNAME14.Value = @"Mevcut Miktar";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 9, 170, 9, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    COLUMNNAME2.CalcValue = COLUMNNAME2.Value;
                    COLUMNNAME12.CalcValue = COLUMNNAME12.Value;
                    COLUMNNAME13.CalcValue = COLUMNNAME13.Value;
                    COLUMNNAME14.CalcValue = COLUMNNAME14.Value;
                    return new TTReportObject[] { COLUMNNAME2,COLUMNNAME12,COLUMNNAME13,COLUMNNAME14};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public MaterialExpirationSchedule MyParentReport
                {
                    get { return (MaterialExpirationSchedule)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public MaterialExpirationSchedule MyParentReport
            {
                get { return (MaterialExpirationSchedule)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField RESTAMOUNT { get {return Body().RESTAMOUNT;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField EXPDATE { get {return Body().EXPDATE;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField NSN { get {return Body().NSN;} }
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
                list[0] = new TTReportNqlData<StockTransaction.GetMaterialExpirationScheduleReportQuery_Class>("GetMaterialExpirationScheduleReportQuery", StockTransaction.GetMaterialExpirationScheduleReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public MaterialExpirationSchedule MyParentReport
                {
                    get { return (MaterialExpirationSchedule)ParentReport; }
                }
                
                public TTReportField MATERIALNAME;
                public TTReportField RESTAMOUNT;
                public TTReportField AMOUNT;
                public TTReportField EXPDATE;
                public TTReportShape NewLine1;
                public TTReportField NSN; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 1, 106, 6, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#NAME#}";

                    RESTAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 1, 170, 6, false);
                    RESTAMOUNT.Name = "RESTAMOUNT";
                    RESTAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESTAMOUNT.TextFormat = @"#,##0.00";
                    RESTAMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RESTAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RESTAMOUNT.TextFont.Name = "Arial";
                    RESTAMOUNT.TextFont.CharSet = 162;
                    RESTAMOUNT.Value = @"{#RESTAMOUNT#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 1, 245, 6, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.Visible = EvetHayirEnum.ehHayir;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,##0.00";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    EXPDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 1, 144, 6, false);
                    EXPDATE.Name = "EXPDATE";
                    EXPDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXPDATE.TextFormat = @"dd/MM/yyyy";
                    EXPDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXPDATE.TextFont.Name = "Arial";
                    EXPDATE.TextFont.CharSet = 162;
                    EXPDATE.Value = @"{#EXPIRATIONDATE#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 170, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 1, 220, 6, false);
                    NSN.Name = "NSN";
                    NSN.Visible = EvetHayirEnum.ehHayir;
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NSN.TextFont.Name = "Arial";
                    NSN.TextFont.CharSet = 162;
                    NSN.Value = @"{#NATOSTOCKNO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockTransaction.GetMaterialExpirationScheduleReportQuery_Class dataset_GetMaterialExpirationScheduleReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.GetMaterialExpirationScheduleReportQuery_Class>(0);
                    MATERIALNAME.CalcValue = (dataset_GetMaterialExpirationScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetMaterialExpirationScheduleReportQuery.Name) : "");
                    RESTAMOUNT.CalcValue = (dataset_GetMaterialExpirationScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetMaterialExpirationScheduleReportQuery.Restamount) : "");
                    AMOUNT.CalcValue = (dataset_GetMaterialExpirationScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetMaterialExpirationScheduleReportQuery.Amount) : "");
                    EXPDATE.CalcValue = (dataset_GetMaterialExpirationScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetMaterialExpirationScheduleReportQuery.ExpirationDate) : "");
                    NSN.CalcValue = (dataset_GetMaterialExpirationScheduleReportQuery != null ? Globals.ToStringCore(dataset_GetMaterialExpirationScheduleReportQuery.NATOStockNO) : "");
                    return new TTReportObject[] { MATERIALNAME,RESTAMOUNT,AMOUNT,EXPDATE,NSN};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public MaterialExpirationSchedule()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STOREID", "00000000-0000-0000-0000-000000000000", "Depo Seçiniz :", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("d92d20fb-3679-4f07-9906-fc1a75f26d16");
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi :", @"", true, false, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi :", @"", true, false, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STOREID"]);
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "MATERIALEXPIRATIONSCHEDULE";
            Caption = "Malzeme/İlaç Miat Çizelgesi Raporu";
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