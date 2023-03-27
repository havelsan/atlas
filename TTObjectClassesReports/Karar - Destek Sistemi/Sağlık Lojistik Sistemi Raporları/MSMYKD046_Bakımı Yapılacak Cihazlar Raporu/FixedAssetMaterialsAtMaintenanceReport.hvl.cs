
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
    /// Bakımı Yapılan / Yapılacak Cihazlar Raporu
    /// </summary>
    public partial class FixedAssetMaterialsAtMaintenanceReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public int? DATE = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public FixedAssetMaterialsAtMaintenanceReport MyParentReport
            {
                get { return (FixedAssetMaterialsAtMaintenanceReport)ParentReport; }
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
            public TTReportField ReportName { get {return Header().ReportName;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
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
                public FixedAssetMaterialsAtMaintenanceReport MyParentReport
                {
                    get { return (FixedAssetMaterialsAtMaintenanceReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField ReportName; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 0, 224, 20, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Name = "Arial";
                    ReportName.TextFont.Size = 12;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"BAKIMI YAPILAN/YAPILACAK CİHAZLAR RAPORU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    ReportName.CalcValue = ReportName.Value;
                    return new TTReportObject[] { LOGO,ReportName};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public FixedAssetMaterialsAtMaintenanceReport MyParentReport
                {
                    get { return (FixedAssetMaterialsAtMaintenanceReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportShape NewLine11111; 
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
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

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

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 257, 0, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

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
            public FixedAssetMaterialsAtMaintenanceReport MyParentReport
            {
                get { return (FixedAssetMaterialsAtMaintenanceReport)ParentReport; }
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
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField SIRANU { get {return Header().SIRANU;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
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
                public FixedAssetMaterialsAtMaintenanceReport MyParentReport
                {
                    get { return (FixedAssetMaterialsAtMaintenanceReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportField NewField1111;
                public TTReportField SIRANU;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportShape NewLine1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 52, 13, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Nato Stok Numarası
(NSN)";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 1, 93, 7, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Cihazın Adı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 9, 321, 15, false);
                    NewField12.Name = "NewField12";
                    NewField12.Visible = EvetHayirEnum.ehHayir;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Marka";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 322, 9, 342, 15, false);
                    NewField121.Name = "NewField121";
                    NewField121.Visible = EvetHayirEnum.ehHayir;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Model";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 342, 9, 362, 15, false);
                    NewField122.Name = "NewField122";
                    NewField122.Visible = EvetHayirEnum.ehHayir;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Name = "Arial";
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Seri Nu.";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 1, 143, 7, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Bulunduğu Servis";

                    SIRANU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 9, 7, false);
                    SIRANU.Name = "SIRANU";
                    SIRANU.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SIRANU.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIRANU.TextFont.Name = "Arial";
                    SIRANU.TextFont.Bold = true;
                    SIRANU.TextFont.CharSet = 162;
                    SIRANU.Value = @"S.Nu.";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 1, 198, 13, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Cihazın Bakımını
Yapan/Yapacak Personel";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 198, 1, 228, 7, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Bakım Tarihi";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 1, 258, 13, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.MultiLine = EvetHayirEnum.ehEvet;
                    NewField4.WordBreak = EvetHayirEnum.ehEvet;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Sonraki
Bakım Tarihi";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 14, 296, 14, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    SIRANU.CalcValue = SIRANU.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField121,NewField122,NewField1111,SIRANU,NewField2,NewField3,NewField4};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public FixedAssetMaterialsAtMaintenanceReport MyParentReport
                {
                    get { return (FixedAssetMaterialsAtMaintenanceReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public FixedAssetMaterialsAtMaintenanceReport MyParentReport
            {
                get { return (FixedAssetMaterialsAtMaintenanceReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NatoStockNo { get {return Body().NatoStockNo;} }
            public TTReportField FixedAssetName { get {return Body().FixedAssetName;} }
            public TTReportField Mark { get {return Body().Mark;} }
            public TTReportField Model { get {return Body().Model;} }
            public TTReportField SerialNumber { get {return Body().SerialNumber;} }
            public TTReportField Service { get {return Body().Service;} }
            public TTReportField SIRANUCOUNTER { get {return Body().SIRANUCOUNTER;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField LASTMAINTENANCEDATE { get {return Body().LASTMAINTENANCEDATE;} }
            public TTReportField NEXTMAINTENANCEDATE { get {return Body().NEXTMAINTENANCEDATE;} }
            public TTReportField PERSONEL { get {return Body().PERSONEL;} }
            public TTReportField MAINTENANCEPERIOD { get {return Body().MAINTENANCEPERIOD;} }
            public TTReportField MO_ID { get {return Body().MO_ID;} }
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
                list[0] = new TTReportNqlData<Maintenance.MaintenanceReportQuery_Class>("MaintenanceReportQuery2", Maintenance.MaintenanceReportQuery((int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.DATE)));
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
                public FixedAssetMaterialsAtMaintenanceReport MyParentReport
                {
                    get { return (FixedAssetMaterialsAtMaintenanceReport)ParentReport; }
                }
                
                public TTReportField NatoStockNo;
                public TTReportField FixedAssetName;
                public TTReportField Mark;
                public TTReportField Model;
                public TTReportField SerialNumber;
                public TTReportField Service;
                public TTReportField SIRANUCOUNTER;
                public TTReportShape NewLine1;
                public TTReportField LASTMAINTENANCEDATE;
                public TTReportField NEXTMAINTENANCEDATE;
                public TTReportField PERSONEL;
                public TTReportField MAINTENANCEPERIOD;
                public TTReportField MO_ID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 15;
                    RepeatCount = 0;
                    
                    NatoStockNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 52, 10, false);
                    NatoStockNo.Name = "NatoStockNo";
                    NatoStockNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    NatoStockNo.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NatoStockNo.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NatoStockNo.TextFont.Name = "Arial";
                    NatoStockNo.TextFont.CharSet = 162;
                    NatoStockNo.Value = @"";

                    FixedAssetName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 1, 93, 12, false);
                    FixedAssetName.Name = "FixedAssetName";
                    FixedAssetName.FieldType = ReportFieldTypeEnum.ftVariable;
                    FixedAssetName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FixedAssetName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FixedAssetName.MultiLine = EvetHayirEnum.ehEvet;
                    FixedAssetName.WordBreak = EvetHayirEnum.ehEvet;
                    FixedAssetName.TextFont.Name = "Arial";
                    FixedAssetName.TextFont.CharSet = 162;
                    FixedAssetName.Value = @"";

                    Mark = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 7, 321, 16, false);
                    Mark.Name = "Mark";
                    Mark.Visible = EvetHayirEnum.ehHayir;
                    Mark.FieldType = ReportFieldTypeEnum.ftVariable;
                    Mark.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Mark.WordBreak = EvetHayirEnum.ehEvet;
                    Mark.TextFont.Name = "Arial";
                    Mark.TextFont.CharSet = 162;
                    Mark.Value = @"";

                    Model = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 322, 7, 342, 16, false);
                    Model.Name = "Model";
                    Model.Visible = EvetHayirEnum.ehHayir;
                    Model.FieldType = ReportFieldTypeEnum.ftVariable;
                    Model.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Model.WordBreak = EvetHayirEnum.ehEvet;
                    Model.TextFont.Name = "Arial";
                    Model.TextFont.CharSet = 162;
                    Model.Value = @"";

                    SerialNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 343, 7, 363, 16, false);
                    SerialNumber.Name = "SerialNumber";
                    SerialNumber.Visible = EvetHayirEnum.ehHayir;
                    SerialNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    SerialNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SerialNumber.TextFont.Name = "Arial";
                    SerialNumber.TextFont.CharSet = 162;
                    SerialNumber.Value = @"";

                    Service = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 1, 143, 12, false);
                    Service.Name = "Service";
                    Service.FieldType = ReportFieldTypeEnum.ftVariable;
                    Service.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Service.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Service.MultiLine = EvetHayirEnum.ehEvet;
                    Service.WordBreak = EvetHayirEnum.ehEvet;
                    Service.TextFont.Name = "Arial";
                    Service.TextFont.CharSet = 162;
                    Service.Value = @"";

                    SIRANUCOUNTER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 9, 10, false);
                    SIRANUCOUNTER.Name = "SIRANUCOUNTER";
                    SIRANUCOUNTER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANUCOUNTER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SIRANUCOUNTER.Value = @"{@counter@}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 1, 13, 297, 13, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    LASTMAINTENANCEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 198, 1, 228, 10, false);
                    LASTMAINTENANCEDATE.Name = "LASTMAINTENANCEDATE";
                    LASTMAINTENANCEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    LASTMAINTENANCEDATE.TextFormat = @"Short Date";
                    LASTMAINTENANCEDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LASTMAINTENANCEDATE.Value = @"";

                    NEXTMAINTENANCEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 1, 258, 10, false);
                    NEXTMAINTENANCEDATE.Name = "NEXTMAINTENANCEDATE";
                    NEXTMAINTENANCEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEXTMAINTENANCEDATE.TextFormat = @"Short Date";
                    NEXTMAINTENANCEDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEXTMAINTENANCEDATE.Value = @"";

                    PERSONEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 1, 198, 12, false);
                    PERSONEL.Name = "PERSONEL";
                    PERSONEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERSONEL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PERSONEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PERSONEL.TextFont.Name = "Arial";
                    PERSONEL.TextFont.CharSet = 162;
                    PERSONEL.Value = @"";

                    MAINTENANCEPERIOD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 302, 1, 353, 6, false);
                    MAINTENANCEPERIOD.Name = "MAINTENANCEPERIOD";
                    MAINTENANCEPERIOD.Visible = EvetHayirEnum.ehHayir;
                    MAINTENANCEPERIOD.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAINTENANCEPERIOD.Value = @"";

                    MO_ID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 366, 7, 386, 16, false);
                    MO_ID.Name = "MO_ID";
                    MO_ID.Visible = EvetHayirEnum.ehHayir;
                    MO_ID.FieldType = ReportFieldTypeEnum.ftVariable;
                    MO_ID.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MO_ID.WordBreak = EvetHayirEnum.ehEvet;
                    MO_ID.TextFont.Name = "Arial";
                    MO_ID.TextFont.CharSet = 162;
                    MO_ID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Maintenance.MaintenanceReportQuery_Class dataset_MaintenanceReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<Maintenance.MaintenanceReportQuery_Class>(0);
                    NatoStockNo.CalcValue = @"";
                    FixedAssetName.CalcValue = @"";
                    Mark.CalcValue = @"";
                    Model.CalcValue = @"";
                    SerialNumber.CalcValue = @"";
                    Service.CalcValue = @"";
                    SIRANUCOUNTER.CalcValue = ParentGroup.Counter.ToString();
                    LASTMAINTENANCEDATE.CalcValue = @"";
                    NEXTMAINTENANCEDATE.CalcValue = @"";
                    PERSONEL.CalcValue = @"";
                    MAINTENANCEPERIOD.CalcValue = @"";
                    MO_ID.CalcValue = (dataset_MaintenanceReportQuery2 != null ? Globals.ToStringCore(dataset_MaintenanceReportQuery2.ObjectID) : "");
                    return new TTReportObject[] { NatoStockNo,FixedAssetName,Mark,Model,SerialNumber,Service,SIRANUCOUNTER,LASTMAINTENANCEDATE,NEXTMAINTENANCEDATE,PERSONEL,MAINTENANCEPERIOD,MO_ID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //mca

            TTObjectContext ctx = new TTObjectContext(true);
            

            //IBindingList allList = MaintenanceOrder.MaintenanceQuery(ctx, (int)this.MyParentReport.RuntimeParameters.DATE);
            if (MO_ID.CalcValue.ToString() != "")
            {
                Maintenance mo1 = (Maintenance)ctx.GetObject(new Guid(this.MO_ID.CalcValue.ToString()), typeof(Maintenance));
                //foreach (MaintenanceOrder mo1 in allList)
                //{
                if (mo1 != null )
                {
                    if(mo1.FixedAssetMaterialDefinition != null)
                    {
                        if (mo1.FixedAssetMaterialDefinition.FixedAssetDefinition != null)
                        { NatoStockNo.CalcValue = mo1.FixedAssetMaterialDefinition.FixedAssetDefinition.NATOStockNO; }
                        else { NatoStockNo.CalcValue = "--"; }
                    }
                    else
                    {
                        NatoStockNo.CalcValue = "--";
                    }
                    if (mo1.Section != null) { Service.CalcValue = mo1.Section.Name; }
                    else { Service.CalcValue = "--"; }
                    if (mo1.DelivererUser != null) { PERSONEL.CalcValue = mo1.DelivererUser.Name; }
                    else { PERSONEL.CalcValue = "--"; }
                    if (mo1.FixedAssetMaterialDefinition != null)
                    { LASTMAINTENANCEDATE.CalcValue = mo1.FixedAssetMaterialDefinition.LastMaintenanceDate.Value.ToString(); }
                    else { LASTMAINTENANCEDATE.CalcValue = "--"; }


                    if (LASTMAINTENANCEDATE != null && LASTMAINTENANCEDATE.CalcValue != "" && LASTMAINTENANCEDATE.CalcValue != " " && LASTMAINTENANCEDATE.CalcValue != "--")
                    {
                        DateTime maintenanceDate = Convert.ToDateTime(LASTMAINTENANCEDATE.CalcValue);

                        int addMonth = 0;
                        // if (string.IsNullOrEmpty(MAINTENANCEPERIOD.CalcValue) == false)
                        // addMonth = Convert.ToInt32(MAINTENANCEPERIOD.CalcValue);
                        if (string.IsNullOrEmpty(LASTMAINTENANCEDATE.CalcValue) == false)
                            addMonth=Convert.ToInt32(maintenanceDate.Month);
                        if (addMonth > 0)
                            NEXTMAINTENANCEDATE.CalcValue = maintenanceDate.AddMonths(addMonth).ToString();
                    }
                    else { NEXTMAINTENANCEDATE.CalcValue = "--"; }

                }
                
            }
            //}
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

        public FixedAssetMaterialsAtMaintenanceReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("DATE", "", "Yıl", @"", true, true, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("DATE"))
                _runtimeParameters.DATE = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["DATE"]);
            Name = "FIXEDASSETMATERIALSATMAINTENANCEREPORT";
            Caption = "Bakımı Yapılan / Yapılacak Cihazlar Raporu";
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