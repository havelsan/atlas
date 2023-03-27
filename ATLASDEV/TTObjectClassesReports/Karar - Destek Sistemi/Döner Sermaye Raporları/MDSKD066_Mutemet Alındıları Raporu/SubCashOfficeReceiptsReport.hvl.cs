
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
    /// Mutemet Alındıları Raporu
    /// </summary>
    public partial class SubCashOfficeReceiptsReport : TTReport
    {
#region Methods
   double toplamTutar = 0;
        int belgeSayisi = 0;
   
#endregion Methods

        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTCGroup : TTReportGroup
        {
            public SubCashOfficeReceiptsReport MyParentReport
            {
                get { return (SubCashOfficeReceiptsReport)ParentReport; }
            }

            new public PARTCGroupBody Body()
            {
                return (PARTCGroupBody)_body;
            }
            public TTReportField STARTDATE { get {return Body().STARTDATE;} }
            public TTReportField ENDDATE { get {return Body().ENDDATE;} }
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
                _header = null;
                _footer = null;
                _body = new PARTCGroupBody(this);
            }

            public partial class PARTCGroupBody : TTReportSection
            {
                public SubCashOfficeReceiptsReport MyParentReport
                {
                    get { return (SubCashOfficeReceiptsReport)ParentReport; }
                }
                
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTCGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 3, 29, 8, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.MultiLine = EvetHayirEnum.ehEvet;
                    STARTDATE.WordBreak = EvetHayirEnum.ehEvet;
                    STARTDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 3, 57, 8, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.MultiLine = EvetHayirEnum.ehEvet;
                    ENDDATE.WordBreak = EvetHayirEnum.ehEvet;
                    ENDDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { STARTDATE,ENDDATE};
                }

                public override void RunScript()
                {
#region PARTC BODY_Script
                    ((SubCashOfficeReceiptsReport)ParentReport).RuntimeParameters.STARTDATE = Convert.ToDateTime(STARTDATE.FormattedValue + " 00:00:00");
            ((SubCashOfficeReceiptsReport)ParentReport).RuntimeParameters.ENDDATE = Convert.ToDateTime(ENDDATE.FormattedValue + " 23:59:59");
            
            ((SubCashOfficeReceiptsReport)ParentReport).toplamTutar = 0;
            ((SubCashOfficeReceiptsReport)ParentReport).belgeSayisi = 0;
#endregion PARTC BODY_Script
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class PARTBGroup : TTReportGroup
        {
            public SubCashOfficeReceiptsReport MyParentReport
            {
                get { return (SubCashOfficeReceiptsReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField11411211 { get {return Header().NewField11411211;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportField NewField11211211 { get {return Header().NewField11211211;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportShape NewLine111121 { get {return Footer().NewLine111121;} }
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
                public SubCashOfficeReceiptsReport MyParentReport
                {
                    get { return (SubCashOfficeReceiptsReport)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField NewField121;
                public TTReportField STARTDATE;
                public TTReportField NewField11411211;
                public TTReportField NewField1111111;
                public TTReportField NewField11211211;
                public TTReportField ENDDATE; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 33;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 11, 284, 20, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 12;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"MUTEMET ALINDILARI RAPORU";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 22, 32, 27, false);
                    NewField121.Name = "NewField121";
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.NoClip = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Başlangıç Tarihi";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 22, 70, 27, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.TextFont.Name = "Arial";
                    STARTDATE.TextFont.Size = 9;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField11411211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 22, 35, 27, false);
                    NewField11411211.Name = "NewField11411211";
                    NewField11411211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11411211.TextFont.Bold = true;
                    NewField11411211.TextFont.CharSet = 162;
                    NewField11411211.Value = @":";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 27, 32, 32, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.TextFont.Name = "Arial";
                    NewField1111111.TextFont.Size = 9;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"Bitiş Tarihi";

                    NewField11211211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 27, 35, 32, false);
                    NewField11211211.Name = "NewField11211211";
                    NewField11211211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11211211.TextFont.Bold = true;
                    NewField11211211.TextFont.CharSet = 162;
                    NewField11211211.Value = @":";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 27, 70, 32, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.TextFont.Name = "Arial";
                    ENDDATE.TextFont.Size = 9;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField11411211.CalcValue = NewField11411211.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    NewField11211211.CalcValue = NewField11211211.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    return new TTReportObject[] { NewField111,NewField121,STARTDATE,NewField11411211,NewField1111111,NewField11211211,ENDDATE};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public SubCashOfficeReceiptsReport MyParentReport
                {
                    get { return (SubCashOfficeReceiptsReport)ParentReport; }
                }
                
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate;
                public TTReportShape NewLine111121; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 2, 257, 7, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 259, 2, 284, 7, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 2, 42, 7, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                    NewLine111121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 1, 284, 1, false);
                    NewLine111121.Name = "NewLine111121";
                    NewLine111121.DrawStyle = DrawStyleConstants.vbSolid;

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
            public SubCashOfficeReceiptsReport MyParentReport
            {
                get { return (SubCashOfficeReceiptsReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField CASHIER { get {return Header().CASHIER;} }
            public TTReportField NewField111121 { get {return Header().NewField111121;} }
            public TTReportField NewField11511 { get {return Header().NewField11511;} }
            public TTReportField NewField11711 { get {return Header().NewField11711;} }
            public TTReportShape NewLine11111 { get {return Header().NewLine11111;} }
            public TTReportField NewField111711 { get {return Header().NewField111711;} }
            public TTReportField NewField121711 { get {return Header().NewField121711;} }
            public TTReportField NewField1117121 { get {return Header().NewField1117121;} }
            public TTReportField NewField1117122 { get {return Header().NewField1117122;} }
            public TTReportField NewField1117123 { get {return Header().NewField1117123;} }
            public TTReportField NewField1117124 { get {return Header().NewField1117124;} }
            public TTReportField NewField121111 { get {return Footer().NewField121111;} }
            public TTReportShape NewLine12111 { get {return Footer().NewLine12111;} }
            public TTReportField TOPLAMTUTAR { get {return Footer().TOPLAMTUTAR;} }
            public TTReportField NewField1111121 { get {return Footer().NewField1111121;} }
            public TTReportField BELGESAYISI { get {return Footer().BELGESAYISI;} }
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
                list[0] = new TTReportNqlData<AccountDocument.GetSubCashOfficeAccDocsByDate_Class>("GetSubCashOfficeAccDocsByDate", AccountDocument.GetSubCashOfficeAccDocsByDate((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public SubCashOfficeReceiptsReport MyParentReport
                {
                    get { return (SubCashOfficeReceiptsReport)ParentReport; }
                }
                
                public TTReportField NewField11111;
                public TTReportField CASHIER;
                public TTReportField NewField111121;
                public TTReportField NewField11511;
                public TTReportField NewField11711;
                public TTReportShape NewLine11111;
                public TTReportField NewField111711;
                public TTReportField NewField121711;
                public TTReportField NewField1117121;
                public TTReportField NewField1117122;
                public TTReportField NewField1117123;
                public TTReportField NewField1117124; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 13;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 21, 6, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Size = 9;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Mutemet";

                    CASHIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 1, 284, 6, false);
                    CASHIER.Name = "CASHIER";
                    CASHIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CASHIER.TextFont.Name = "Arial";
                    CASHIER.TextFont.Size = 9;
                    CASHIER.TextFont.CharSet = 162;
                    CASHIER.Value = @"{#CASHIER#}  ({#TUR#})";

                    NewField111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 1, 23, 6, false);
                    NewField111121.Name = "NewField111121";
                    NewField111121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111121.TextFont.Bold = true;
                    NewField111121.TextFont.CharSet = 162;
                    NewField111121.Value = @":";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 7, 26, 11, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.TextFont.Name = "Arial";
                    NewField11511.TextFont.Size = 9;
                    NewField11511.TextFont.Bold = true;
                    NewField11511.TextFont.CharSet = 162;
                    NewField11511.Value = @"Sıra";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 7, 50, 11, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.TextFont.Name = "Arial";
                    NewField11711.TextFont.Size = 9;
                    NewField11711.TextFont.Bold = true;
                    NewField11711.TextFont.CharSet = 162;
                    NewField11711.Value = @"TC Kimlik No";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 12, 284, 12, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField111711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 7, 284, 11, false);
                    NewField111711.Name = "NewField111711";
                    NewField111711.TextFont.Name = "Arial";
                    NewField111711.TextFont.Size = 9;
                    NewField111711.TextFont.Bold = true;
                    NewField111711.TextFont.CharSet = 162;
                    NewField111711.Value = @"Açıklama";

                    NewField121711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 7, 146, 11, false);
                    NewField121711.Name = "NewField121711";
                    NewField121711.TextFont.Name = "Arial";
                    NewField121711.TextFont.Size = 9;
                    NewField121711.TextFont.Bold = true;
                    NewField121711.TextFont.CharSet = 162;
                    NewField121711.Value = @"Belge Tarihi";

                    NewField1117121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 7, 98, 11, false);
                    NewField1117121.Name = "NewField1117121";
                    NewField1117121.TextFont.Name = "Arial";
                    NewField1117121.TextFont.Size = 9;
                    NewField1117121.TextFont.Bold = true;
                    NewField1117121.TextFont.CharSet = 162;
                    NewField1117121.Value = @"Adı Soyadı";

                    NewField1117122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 7, 122, 11, false);
                    NewField1117122.Name = "NewField1117122";
                    NewField1117122.TextFont.Name = "Arial";
                    NewField1117122.TextFont.Size = 9;
                    NewField1117122.TextFont.Bold = true;
                    NewField1117122.TextFont.CharSet = 162;
                    NewField1117122.Value = @"Belge No";

                    NewField1117123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 7, 212, 11, false);
                    NewField1117123.Name = "NewField1117123";
                    NewField1117123.TextFont.Name = "Arial";
                    NewField1117123.TextFont.Size = 9;
                    NewField1117123.TextFont.Bold = true;
                    NewField1117123.TextFont.CharSet = 162;
                    NewField1117123.Value = @"Gelir Türü";

                    NewField1117124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 7, 237, 11, false);
                    NewField1117124.Name = "NewField1117124";
                    NewField1117124.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1117124.TextFont.Name = "Arial";
                    NewField1117124.TextFont.Size = 9;
                    NewField1117124.TextFont.Bold = true;
                    NewField1117124.TextFont.CharSet = 162;
                    NewField1117124.Value = @"Tutar ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountDocument.GetSubCashOfficeAccDocsByDate_Class dataset_GetSubCashOfficeAccDocsByDate = ParentGroup.rsGroup.GetCurrentRecord<AccountDocument.GetSubCashOfficeAccDocsByDate_Class>(0);
                    NewField11111.CalcValue = NewField11111.Value;
                    CASHIER.CalcValue = (dataset_GetSubCashOfficeAccDocsByDate != null ? Globals.ToStringCore(dataset_GetSubCashOfficeAccDocsByDate.Cashier) : "") + @"  (" + (dataset_GetSubCashOfficeAccDocsByDate != null ? Globals.ToStringCore(dataset_GetSubCashOfficeAccDocsByDate.Tur) : "") + @")";
                    NewField111121.CalcValue = NewField111121.Value;
                    NewField11511.CalcValue = NewField11511.Value;
                    NewField11711.CalcValue = NewField11711.Value;
                    NewField111711.CalcValue = NewField111711.Value;
                    NewField121711.CalcValue = NewField121711.Value;
                    NewField1117121.CalcValue = NewField1117121.Value;
                    NewField1117122.CalcValue = NewField1117122.Value;
                    NewField1117123.CalcValue = NewField1117123.Value;
                    NewField1117124.CalcValue = NewField1117124.Value;
                    return new TTReportObject[] { NewField11111,CASHIER,NewField111121,NewField11511,NewField11711,NewField111711,NewField121711,NewField1117121,NewField1117122,NewField1117123,NewField1117124};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public SubCashOfficeReceiptsReport MyParentReport
                {
                    get { return (SubCashOfficeReceiptsReport)ParentReport; }
                }
                
                public TTReportField NewField121111;
                public TTReportShape NewLine12111;
                public TTReportField TOPLAMTUTAR;
                public TTReportField NewField1111121;
                public TTReportField BELGESAYISI; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 2, 208, 7, false);
                    NewField121111.Name = "NewField121111";
                    NewField121111.TextFont.Name = "Arial";
                    NewField121111.TextFont.Size = 9;
                    NewField121111.TextFont.Bold = true;
                    NewField121111.TextFont.CharSet = 162;
                    NewField121111.Value = @"Toplam Tutar :";

                    NewLine12111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 1, 284, 1, false);
                    NewLine12111.Name = "NewLine12111";
                    NewLine12111.DrawStyle = DrawStyleConstants.vbSolid;

                    TOPLAMTUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 209, 2, 237, 7, false);
                    TOPLAMTUTAR.Name = "TOPLAMTUTAR";
                    TOPLAMTUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMTUTAR.TextFormat = @"#,##0.#0";
                    TOPLAMTUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMTUTAR.TextFont.Name = "Arial";
                    TOPLAMTUTAR.TextFont.Size = 9;
                    TOPLAMTUTAR.TextFont.CharSet = 162;
                    TOPLAMTUTAR.Value = @"";

                    NewField1111121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 2, 160, 7, false);
                    NewField1111121.Name = "NewField1111121";
                    NewField1111121.TextFont.Name = "Arial";
                    NewField1111121.TextFont.Size = 9;
                    NewField1111121.TextFont.Bold = true;
                    NewField1111121.TextFont.CharSet = 162;
                    NewField1111121.Value = @"Belge Sayısı :";

                    BELGESAYISI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 2, 182, 7, false);
                    BELGESAYISI.Name = "BELGESAYISI";
                    BELGESAYISI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BELGESAYISI.TextFont.Name = "Arial";
                    BELGESAYISI.TextFont.Size = 9;
                    BELGESAYISI.TextFont.CharSet = 162;
                    BELGESAYISI.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountDocument.GetSubCashOfficeAccDocsByDate_Class dataset_GetSubCashOfficeAccDocsByDate = ParentGroup.rsGroup.GetCurrentRecord<AccountDocument.GetSubCashOfficeAccDocsByDate_Class>(0);
                    NewField121111.CalcValue = NewField121111.Value;
                    TOPLAMTUTAR.CalcValue = @"";
                    NewField1111121.CalcValue = NewField1111121.Value;
                    BELGESAYISI.CalcValue = @"";
                    return new TTReportObject[] { NewField121111,TOPLAMTUTAR,NewField1111121,BELGESAYISI};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    this.TOPLAMTUTAR.CalcValue = ((SubCashOfficeReceiptsReport)ParentReport).toplamTutar.ToString();
            this.BELGESAYISI.CalcValue = ((SubCashOfficeReceiptsReport)ParentReport).belgeSayisi.ToString();
            
            ((SubCashOfficeReceiptsReport)ParentReport).toplamTutar = 0;
            ((SubCashOfficeReceiptsReport)ParentReport).belgeSayisi = 0;
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public SubCashOfficeReceiptsReport MyParentReport
            {
                get { return (SubCashOfficeReceiptsReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField TUTAR { get {return Body().TUTAR;} }
            public TTReportField SNO { get {return Body().SNO;} }
            public TTReportField ADISOYADI { get {return Body().ADISOYADI;} }
            public TTReportField ACIKLAMA { get {return Body().ACIKLAMA;} }
            public TTReportField GELIRTURU { get {return Body().GELIRTURU;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportField BELGENO { get {return Body().BELGENO;} }
            public TTReportField BELGETARIHI { get {return Body().BELGETARIHI;} }
            public TTReportField ACCDOCOBJID { get {return Body().ACCDOCOBJID;} }
            public TTReportField TAHSILATTURU { get {return Body().TAHSILATTURU;} }
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

                AccountDocument.GetSubCashOfficeAccDocsByDate_Class dataSet_GetSubCashOfficeAccDocsByDate = ParentGroup.rsGroup.GetCurrentRecord<AccountDocument.GetSubCashOfficeAccDocsByDate_Class>(0);    
                return new object[] {(dataSet_GetSubCashOfficeAccDocsByDate==null ? null : dataSet_GetSubCashOfficeAccDocsByDate.Cashier), (dataSet_GetSubCashOfficeAccDocsByDate==null ? null : dataSet_GetSubCashOfficeAccDocsByDate.Tur)};
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
                public SubCashOfficeReceiptsReport MyParentReport
                {
                    get { return (SubCashOfficeReceiptsReport)ParentReport; }
                }
                
                public TTReportField TUTAR;
                public TTReportField SNO;
                public TTReportField ADISOYADI;
                public TTReportField ACIKLAMA;
                public TTReportField GELIRTURU;
                public TTReportField TCKIMLIKNO;
                public TTReportField BELGENO;
                public TTReportField BELGETARIHI;
                public TTReportField ACCDOCOBJID;
                public TTReportField TAHSILATTURU; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    TUTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 1, 237, 6, false);
                    TUTAR.Name = "TUTAR";
                    TUTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TUTAR.TextFormat = @"#,##0.#0";
                    TUTAR.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TUTAR.TextFont.Name = "Arial";
                    TUTAR.TextFont.Size = 9;
                    TUTAR.TextFont.CharSet = 162;
                    TUTAR.Value = @"{#PARTA.PRICE#}";

                    SNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 26, 6, false);
                    SNO.Name = "SNO";
                    SNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SNO.TextFont.Name = "Arial";
                    SNO.TextFont.Size = 9;
                    SNO.TextFont.CharSet = 162;
                    SNO.Value = @"";

                    ADISOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 1, 98, 6, false);
                    ADISOYADI.Name = "ADISOYADI";
                    ADISOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADISOYADI.MultiLine = EvetHayirEnum.ehEvet;
                    ADISOYADI.NoClip = EvetHayirEnum.ehEvet;
                    ADISOYADI.WordBreak = EvetHayirEnum.ehEvet;
                    ADISOYADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADISOYADI.TextFont.Name = "Arial";
                    ADISOYADI.TextFont.Size = 9;
                    ADISOYADI.TextFont.CharSet = 162;
                    ADISOYADI.Value = @"{#PARTA.NAME#}";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 1, 284, 6, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA.NoClip = EvetHayirEnum.ehEvet;
                    ACIKLAMA.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACIKLAMA.TextFont.Name = "Arial";
                    ACIKLAMA.TextFont.Size = 9;
                    ACIKLAMA.TextFont.CharSet = 162;
                    ACIKLAMA.Value = @"{#PARTA.DESCRIPTION#}";

                    GELIRTURU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 147, 1, 212, 6, false);
                    GELIRTURU.Name = "GELIRTURU";
                    GELIRTURU.FieldType = ReportFieldTypeEnum.ftVariable;
                    GELIRTURU.MultiLine = EvetHayirEnum.ehEvet;
                    GELIRTURU.NoClip = EvetHayirEnum.ehEvet;
                    GELIRTURU.WordBreak = EvetHayirEnum.ehEvet;
                    GELIRTURU.ExpandTabs = EvetHayirEnum.ehEvet;
                    GELIRTURU.TextFont.Name = "Arial";
                    GELIRTURU.TextFont.Size = 9;
                    GELIRTURU.TextFont.CharSet = 162;
                    GELIRTURU.Value = @"";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 1, 50, 6, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.TextFont.Name = "Arial";
                    TCKIMLIKNO.TextFont.Size = 9;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#PARTA.UNIQUEREFNO#}";

                    BELGENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 1, 122, 6, false);
                    BELGENO.Name = "BELGENO";
                    BELGENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    BELGENO.TextFont.Name = "Arial";
                    BELGENO.TextFont.Size = 9;
                    BELGENO.TextFont.CharSet = 162;
                    BELGENO.Value = @"{#PARTA.DOCUMENTNO#}";

                    BELGETARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 1, 146, 6, false);
                    BELGETARIHI.Name = "BELGETARIHI";
                    BELGETARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BELGETARIHI.TextFormat = @"dd/MM/yyyy";
                    BELGETARIHI.TextFont.Name = "Arial";
                    BELGETARIHI.TextFont.Size = 9;
                    BELGETARIHI.TextFont.CharSet = 162;
                    BELGETARIHI.Value = @"{#PARTA.DOCUMENTDATE#}";

                    ACCDOCOBJID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 305, 1, 330, 6, false);
                    ACCDOCOBJID.Name = "ACCDOCOBJID";
                    ACCDOCOBJID.Visible = EvetHayirEnum.ehHayir;
                    ACCDOCOBJID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCDOCOBJID.Value = @"{#PARTA.OBJECTID#}";

                    TAHSILATTURU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 335, 1, 361, 6, false);
                    TAHSILATTURU.Name = "TAHSILATTURU";
                    TAHSILATTURU.Visible = EvetHayirEnum.ehHayir;
                    TAHSILATTURU.FieldType = ReportFieldTypeEnum.ftVariable;
                    TAHSILATTURU.CaseFormat = CaseFormatEnum.fcUpperCase;
                    TAHSILATTURU.TextFont.Name = "Arial";
                    TAHSILATTURU.TextFont.Size = 9;
                    TAHSILATTURU.TextFont.CharSet = 162;
                    TAHSILATTURU.Value = @"{#PARTA.TUR#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountDocument.GetSubCashOfficeAccDocsByDate_Class dataset_GetSubCashOfficeAccDocsByDate = MyParentReport.PARTA.rsGroup.GetCurrentRecord<AccountDocument.GetSubCashOfficeAccDocsByDate_Class>(0);
                    TUTAR.CalcValue = (dataset_GetSubCashOfficeAccDocsByDate != null ? Globals.ToStringCore(dataset_GetSubCashOfficeAccDocsByDate.Price) : "");
                    SNO.CalcValue = @"";
                    ADISOYADI.CalcValue = (dataset_GetSubCashOfficeAccDocsByDate != null ? Globals.ToStringCore(dataset_GetSubCashOfficeAccDocsByDate.Name) : "");
                    ACIKLAMA.CalcValue = (dataset_GetSubCashOfficeAccDocsByDate != null ? Globals.ToStringCore(dataset_GetSubCashOfficeAccDocsByDate.Description) : "");
                    GELIRTURU.CalcValue = @"";
                    TCKIMLIKNO.CalcValue = (dataset_GetSubCashOfficeAccDocsByDate != null ? Globals.ToStringCore(dataset_GetSubCashOfficeAccDocsByDate.UniqueRefNo) : "");
                    BELGENO.CalcValue = (dataset_GetSubCashOfficeAccDocsByDate != null ? Globals.ToStringCore(dataset_GetSubCashOfficeAccDocsByDate.DocumentNo) : "");
                    BELGETARIHI.CalcValue = (dataset_GetSubCashOfficeAccDocsByDate != null ? Globals.ToStringCore(dataset_GetSubCashOfficeAccDocsByDate.DocumentDate) : "");
                    ACCDOCOBJID.CalcValue = (dataset_GetSubCashOfficeAccDocsByDate != null ? Globals.ToStringCore(dataset_GetSubCashOfficeAccDocsByDate.ObjectID) : "");
                    TAHSILATTURU.CalcValue = (dataset_GetSubCashOfficeAccDocsByDate != null ? Globals.ToStringCore(dataset_GetSubCashOfficeAccDocsByDate.Tur) : "");
                    return new TTReportObject[] { TUTAR,SNO,ADISOYADI,ACIKLAMA,GELIRTURU,TCKIMLIKNO,BELGENO,BELGETARIHI,ACCDOCOBJID,TAHSILATTURU};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.ACCDOCOBJID.CalcValue.ToString();
            AccountDocument accDoc = (AccountDocument)context.GetObject(new Guid(sObjectID), typeof(AccountDocument));
            
            if (accDoc != null)
            {
                bool isCashPayment = (this.TAHSILATTURU.CalcValue == "NAKİT") ? true : false;
                
                if (accDoc is ReceiptDocument)
                {
                    ReceiptDocument receiptDocument = (ReceiptDocument)accDoc;
                    if(isCashPayment)
                    {
                        if(receiptDocument.SpecialNo.Value.HasValue)
                            this.SNO.CalcValue = receiptDocument.SpecialNo.ToString();
                    }
                    else
                    {
                        if(receiptDocument.CreditCardSpecialNo.Value.HasValue)
                            this.SNO.CalcValue = "POS-" + receiptDocument.CreditCardSpecialNo.ToString();
                        
                        if (!string.IsNullOrEmpty(receiptDocument.CreditCardDocumentNo))
                            this.BELGENO.CalcValue = receiptDocument.CreditCardDocumentNo.ToString();
                    }
                    
                    if(receiptDocument.CurrentStateDefID == ReceiptDocument.States.Cancelled)
                    {
                        this.TUTAR.CalcValue = "0";
                        this.ACIKLAMA.CalcValue = "İPTAL EDİLMİŞTİR";
                    }

                    // Gelir Türü set edilir
                    string revenueType = string.Empty;
                    foreach(ReceiptProcedure ReceiptProc in ((Receipt)receiptDocument.EpisodeAccountAction).ReceiptProcedures)
                    {
                        if (ReceiptProc.Paid == true && ReceiptProc.RevenueType != null && ReceiptProc.RevenueType != "")
                        {
                            if (revenueType.Contains(ReceiptProc.RevenueType) == false)
                                revenueType = revenueType + ReceiptProc.RevenueType + ", ";
                        }
                    }
                    
                    if (revenueType != string.Empty)
                        revenueType = revenueType.Substring(0, (revenueType.Length - 2));
                    
                    this.GELIRTURU.CalcValue = revenueType;
                }
                else if (accDoc is AdvanceDocument)
                {
                    AdvanceDocument advanceDocument = (AdvanceDocument)accDoc;
                    if(isCashPayment)
                    {
                        if(advanceDocument.SpecialNo.Value.HasValue)
                            this.SNO.CalcValue =  advanceDocument.SpecialNo.ToString();
                    }
                    else
                    {
                        if(advanceDocument.CreditCardSpecialNo.Value.HasValue)
                            this.SNO.CalcValue = "POS-" + advanceDocument.CreditCardSpecialNo.ToString();
                        
                        if (advanceDocument.CreditCardDocumentNo != null)
                            this.BELGENO.CalcValue = advanceDocument.CreditCardDocumentNo.ToString();
                    }
                    
                    if(advanceDocument.CurrentStateDefID == AdvanceDocument.States.Cancelled)
                    {
                        this.TUTAR.CalcValue = "0";
                        this.ACIKLAMA.CalcValue = "İPTAL EDİLMİŞTİR";
                    }
                }
                else if (accDoc is DebenturePaymentDocument)
                {
                    DebenturePaymentDocument debenturePaymentDocument = (DebenturePaymentDocument)accDoc;
                    if(isCashPayment)
                    {
                        if(debenturePaymentDocument.SpecialNo.Value.HasValue)
                            this.SNO.CalcValue =  debenturePaymentDocument.SpecialNo.ToString();
                    }
                    else
                    {
                        if(debenturePaymentDocument.CreditCardSpecialNo.Value.HasValue)
                            this.SNO.CalcValue = "POS-" + debenturePaymentDocument.CreditCardSpecialNo.ToString();
                        
                        if (debenturePaymentDocument.CreditCardDocumentNo != null)
                            this.BELGENO.CalcValue = debenturePaymentDocument.CreditCardDocumentNo.ToString();
                    }
                    
                    if(debenturePaymentDocument.CurrentStateDefID == DebenturePaymentDocument.States.Cancelled)
                    {
                        this.TUTAR.CalcValue = "0";
                        this.ACIKLAMA.CalcValue = "İPTAL EDİLMİŞTİR";
                    }
                }
                else if(accDoc is SubCashOfficeReceiptDoc)
                {
                    SubCashOfficeReceiptDoc subCashOfficeReceiptDoc = (SubCashOfficeReceiptDoc)accDoc;
                    if(isCashPayment)
                    {
                        if(subCashOfficeReceiptDoc.SpecialNo.Value.HasValue)
                            this.SNO.CalcValue = subCashOfficeReceiptDoc.SpecialNo.Value.ToString();
                    }
                    else
                    {
                        if(subCashOfficeReceiptDoc.CreditCardSpecialNo.Value.HasValue)
                            this.SNO.CalcValue = "POS-" + subCashOfficeReceiptDoc.CreditCardSpecialNo.Value.ToString();
                        
                        if (subCashOfficeReceiptDoc.CreditCardDocumentNo != null)
                            this.BELGENO.CalcValue = subCashOfficeReceiptDoc.CreditCardDocumentNo.ToString();
                    }
                    
                    if(this.ADISOYADI.CalcValue == string.Empty)
                    {
                        this.ADISOYADI.CalcValue = subCashOfficeReceiptDoc.PayeeName;
                        this.ACIKLAMA.CalcValue = subCashOfficeReceiptDoc.MoneyReceivedType.Name;
                    }
                    
                    if(subCashOfficeReceiptDoc.CurrentStateDefID == SubCashOfficeReceiptDoc.States.Cancelled)
                    {
                        this.TUTAR.CalcValue = "0";
                        this.ACIKLAMA.CalcValue = "İPTAL EDİLMİŞTİR";
                    }
                }
                else if(accDoc is GeneralReceiptDocument)
                {
                    GeneralReceiptDocument generalReceiptDocument  = (GeneralReceiptDocument)accDoc;
                    if(isCashPayment)
                    {
                        if(generalReceiptDocument.SpecialNo.Value.HasValue)
                            this.SNO.CalcValue = generalReceiptDocument.SpecialNo.Value.ToString();
                    }
                    else
                    {
                        if(generalReceiptDocument.CreditCardSpecialNo.Value.HasValue)
                            this.SNO.CalcValue = "POS-" + generalReceiptDocument.CreditCardSpecialNo.Value.ToString();
                        
                        if (generalReceiptDocument.CreditCardDocumentNo != null)
                            this.BELGENO.CalcValue = generalReceiptDocument.CreditCardDocumentNo.ToString();
                    }
                    
                    if(this.ADISOYADI.CalcValue == string.Empty)
                    {
                        this.ADISOYADI.CalcValue = generalReceiptDocument.PayeeName;
                        this.ACIKLAMA.CalcValue = generalReceiptDocument.GeneralReceipt[0].Description;
                    }
                    
                    if(generalReceiptDocument.CurrentStateDefID == GeneralReceiptDocument.States.Cancelled)
                    {
                        this.TUTAR.CalcValue = "0";
                        this.ACIKLAMA.CalcValue = "İPTAL EDİLMİŞTİR";
                    }
                }
                
                ((SubCashOfficeReceiptsReport)ParentReport).toplamTutar += Convert.ToDouble(this.TUTAR.CalcValue);
                ((SubCashOfficeReceiptsReport)ParentReport).belgeSayisi ++;
            }
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

        public SubCashOfficeReceiptsReport()
        {
            PARTC = new PARTCGroup(this,"PARTC");
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "SUBCASHOFFICERECEIPTSREPORT";
            Caption = "Mutemet Alındıları Raporu";
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