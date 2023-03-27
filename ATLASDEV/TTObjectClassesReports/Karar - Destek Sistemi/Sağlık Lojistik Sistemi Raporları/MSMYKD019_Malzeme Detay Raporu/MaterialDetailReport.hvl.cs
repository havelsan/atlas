
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
    /// Malzeme Detay Raporu
    /// </summary>
    public partial class MaterialDetailReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string MATERIALOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public MaterialDetailReport MyParentReport
            {
                get { return (MaterialDetailReport)ParentReport; }
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
                public MaterialDetailReport MyParentReport
                {
                    get { return (MaterialDetailReport)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField LOGO; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 4, 170, 16, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Size = 15;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"MALZEME DETAY RAPORU";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    LOGO.CalcValue = LOGO.Value;
                    return new TTReportObject[] { REPORTNAME,LOGO};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public MaterialDetailReport MyParentReport
                {
                    get { return (MaterialDetailReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportShape NewLine111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 35;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 25, 6, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 1, 97, 6, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcTitleCase;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 1, 170, 6, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 1, 170, 1, false);
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
            public MaterialDetailReport MyParentReport
            {
                get { return (MaterialDetailReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField PARAMETERNAME { get {return Header().PARAMETERNAME;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField MATERIALCODE { get {return Header().MATERIALCODE;} }
            public TTReportField COLUMNNAME1 { get {return Header().COLUMNNAME1;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField PARAMETERNAME1 { get {return Header().PARAMETERNAME1;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField MATERIALNAME { get {return Header().MATERIALNAME;} }
            public TTReportField ORIGINALNAME { get {return Header().ORIGINALNAME;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField CHARGABLE { get {return Header().CHARGABLE;} }
            public TTReportField NewField113 { get {return Header().NewField113;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField ALLOWTOGIVEPATIENT { get {return Header().ALLOWTOGIVEPATIENT;} }
            public TTReportField NewField11122 { get {return Header().NewField11122;} }
            public TTReportField NewField11212 { get {return Header().NewField11212;} }
            public TTReportField MATERIALTREENAME { get {return Header().MATERIALTREENAME;} }
            public TTReportField COLUMNNAME11 { get {return Header().COLUMNNAME11;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField114 { get {return Header().NewField114;} }
            public TTReportField NewField123 { get {return Header().NewField123;} }
            public TTReportField NSN { get {return Header().NSN;} }
            public TTReportField NewField1212 { get {return Header().NewField1212;} }
            public TTReportField NewField1122 { get {return Header().NewField1122;} }
            public TTReportField STOCKCARDNAME { get {return Header().STOCKCARDNAME;} }
            public TTReportField NewField1311 { get {return Header().NewField1311;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField STOCKCARDCLASSCODE { get {return Header().STOCKCARDCLASSCODE;} }
            public TTReportField NewField11121 { get {return Header().NewField11121;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField STOCKCARDCLASSNAME { get {return Header().STOCKCARDCLASSNAME;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField ISACTIVE { get {return Header().ISACTIVE;} }
            public TTReportField NewField1411 { get {return Header().NewField1411;} }
            public TTReportField NewField1321 { get {return Header().NewField1321;} }
            public TTReportField STOCKCARDORDERNO { get {return Header().STOCKCARDORDERNO;} }
            public TTReportField MATERIALIMAGE { get {return Header().MATERIALIMAGE;} }
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
                list[0] = new TTReportNqlData<Material.GetMaterialDetail_Class>("GMD", Material.GetMaterialDetail((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.MATERIALOBJECTID)));
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
                public MaterialDetailReport MyParentReport
                {
                    get { return (MaterialDetailReport)ParentReport; }
                }
                
                public TTReportField PARAMETERNAME;
                public TTReportField NewField1;
                public TTReportField MATERIALCODE;
                public TTReportField COLUMNNAME1;
                public TTReportShape NewLine1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField PARAMETERNAME1;
                public TTReportField NewField13;
                public TTReportField MATERIALNAME;
                public TTReportField ORIGINALNAME;
                public TTReportField NewField112;
                public TTReportField NewField121;
                public TTReportField CHARGABLE;
                public TTReportField NewField113;
                public TTReportField NewField122;
                public TTReportField ALLOWTOGIVEPATIENT;
                public TTReportField NewField11122;
                public TTReportField NewField11212;
                public TTReportField MATERIALTREENAME;
                public TTReportField COLUMNNAME11;
                public TTReportShape NewLine11;
                public TTReportField NewField114;
                public TTReportField NewField123;
                public TTReportField NSN;
                public TTReportField NewField1212;
                public TTReportField NewField1122;
                public TTReportField STOCKCARDNAME;
                public TTReportField NewField1311;
                public TTReportField NewField1221;
                public TTReportField STOCKCARDCLASSCODE;
                public TTReportField NewField11121;
                public TTReportField NewField11211;
                public TTReportField STOCKCARDCLASSNAME;
                public TTReportField NewField1211;
                public TTReportField NewField1121;
                public TTReportField ISACTIVE;
                public TTReportField NewField1411;
                public TTReportField NewField1321;
                public TTReportField STOCKCARDORDERNO;
                public TTReportField MATERIALIMAGE; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 96;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PARAMETERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 29, 5, false);
                    PARAMETERNAME.Name = "PARAMETERNAME";
                    PARAMETERNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME.TextFont.Bold = true;
                    PARAMETERNAME.TextFont.CharSet = 162;
                    PARAMETERNAME.Value = @"Malzeme Kodu";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 0, 33, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @":";

                    MATERIALCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 0, 170, 5, false);
                    MATERIALCODE.Name = "MATERIALCODE";
                    MATERIALCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALCODE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALCODE.TextFont.Bold = true;
                    MATERIALCODE.TextFont.CharSet = 162;
                    MATERIALCODE.Value = @"{#CODE#}";

                    COLUMNNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 19, 39, 24, false);
                    COLUMNNAME1.Name = "COLUMNNAME1";
                    COLUMNNAME1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME1.TextFont.Size = 11;
                    COLUMNNAME1.TextFont.Bold = true;
                    COLUMNNAME1.TextFont.CharSet = 162;
                    COLUMNNAME1.Value = @"Malzeme Bilgileri";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 25, 170, 25, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 27, 31, 32, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Orijinal Adı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 27, 35, 32, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @":";

                    PARAMETERNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 29, 10, false);
                    PARAMETERNAME1.Name = "PARAMETERNAME1";
                    PARAMETERNAME1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PARAMETERNAME1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PARAMETERNAME1.TextFont.Bold = true;
                    PARAMETERNAME1.TextFont.CharSet = 162;
                    PARAMETERNAME1.Value = @"Malzeme Adı";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 5, 33, 10, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @":";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 5, 170, 10, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.TextFont.Bold = true;
                    MATERIALNAME.TextFont.CharSet = 162;
                    MATERIALNAME.Value = @"{#NAME#}";

                    ORIGINALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 27, 145, 32, false);
                    ORIGINALNAME.Name = "ORIGINALNAME";
                    ORIGINALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORIGINALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORIGINALNAME.TextFont.CharSet = 162;
                    ORIGINALNAME.Value = @"{#ORIGINALNAME#}";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 32, 31, 37, false);
                    NewField112.Name = "NewField112";
                    NewField112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"Ücretlendirilir";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 32, 35, 37, false);
                    NewField121.Name = "NewField121";
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @":";

                    CHARGABLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 32, 84, 37, false);
                    CHARGABLE.Name = "CHARGABLE";
                    CHARGABLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CHARGABLE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CHARGABLE.TextFont.CharSet = 162;
                    CHARGABLE.Value = @"{#CHARGABLE#}";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 37, 31, 42, false);
                    NewField113.Name = "NewField113";
                    NewField113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113.TextFont.CharSet = 162;
                    NewField113.Value = @"Hastaya Verilir/Verilmez";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 37, 35, 42, false);
                    NewField122.Name = "NewField122";
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @":";

                    ALLOWTOGIVEPATIENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 37, 84, 42, false);
                    ALLOWTOGIVEPATIENT.Name = "ALLOWTOGIVEPATIENT";
                    ALLOWTOGIVEPATIENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ALLOWTOGIVEPATIENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ALLOWTOGIVEPATIENT.TextFont.CharSet = 162;
                    ALLOWTOGIVEPATIENT.Value = @"{#ALLOWTOGIVEPATIENT#}";

                    NewField11122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 47, 31, 52, false);
                    NewField11122.Name = "NewField11122";
                    NewField11122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11122.TextFont.CharSet = 162;
                    NewField11122.Value = @"Malzeme Grubu";

                    NewField11212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 47, 35, 52, false);
                    NewField11212.Name = "NewField11212";
                    NewField11212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11212.TextFont.CharSet = 162;
                    NewField11212.Value = @":";

                    MATERIALTREENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 47, 145, 52, false);
                    MATERIALTREENAME.Name = "MATERIALTREENAME";
                    MATERIALTREENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALTREENAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALTREENAME.TextFont.CharSet = 162;
                    MATERIALTREENAME.Value = @"{#MATERIALTREENAME#}";

                    COLUMNNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 59, 45, 64, false);
                    COLUMNNAME11.Name = "COLUMNNAME11";
                    COLUMNNAME11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME11.TextFont.Size = 11;
                    COLUMNNAME11.TextFont.Bold = true;
                    COLUMNNAME11.TextFont.CharSet = 162;
                    COLUMNNAME11.Value = @"Stok Kart ve Sınıf Bilgileri";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 64, 170, 64, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    NewField114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 71, 31, 76, false);
                    NewField114.Name = "NewField114";
                    NewField114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField114.TextFont.CharSet = 162;
                    NewField114.Value = @"Nato Stok Nu.";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 71, 35, 76, false);
                    NewField123.Name = "NewField123";
                    NewField123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField123.TextFont.CharSet = 162;
                    NewField123.Value = @":";

                    NSN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 71, 170, 76, false);
                    NSN.Name = "NSN";
                    NSN.FieldType = ReportFieldTypeEnum.ftVariable;
                    NSN.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NSN.TextFont.CharSet = 162;
                    NSN.Value = @"{#STOCKCARDNSN#}";

                    NewField1212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 66, 31, 71, false);
                    NewField1212.Name = "NewField1212";
                    NewField1212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1212.TextFont.CharSet = 162;
                    NewField1212.Value = @"Stok Kartı";

                    NewField1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 66, 35, 71, false);
                    NewField1122.Name = "NewField1122";
                    NewField1122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1122.TextFont.CharSet = 162;
                    NewField1122.Value = @":";

                    STOCKCARDNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 66, 170, 71, false);
                    STOCKCARDNAME.Name = "STOCKCARDNAME";
                    STOCKCARDNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARDNAME.TextFont.CharSet = 162;
                    STOCKCARDNAME.Value = @"{#STOCKCARDNAME#}";

                    NewField1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 81, 31, 86, false);
                    NewField1311.Name = "NewField1311";
                    NewField1311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1311.TextFont.CharSet = 162;
                    NewField1311.Value = @"Stok Kart Sınıfı Kodu";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 81, 35, 86, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @":";

                    STOCKCARDCLASSCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 81, 170, 86, false);
                    STOCKCARDCLASSCODE.Name = "STOCKCARDCLASSCODE";
                    STOCKCARDCLASSCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDCLASSCODE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARDCLASSCODE.TextFont.CharSet = 162;
                    STOCKCARDCLASSCODE.Value = @"{#STOCKCARDCLASSCODE#}";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 86, 31, 91, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11121.TextFont.CharSet = 162;
                    NewField11121.Value = @"Stok Kart Sınıfı";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 86, 35, 91, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @":";

                    STOCKCARDCLASSNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 86, 170, 91, false);
                    STOCKCARDCLASSNAME.Name = "STOCKCARDCLASSNAME";
                    STOCKCARDCLASSNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDCLASSNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARDCLASSNAME.TextFont.CharSet = 162;
                    STOCKCARDCLASSNAME.Value = @"{#STOCKCARDCLASSNAME#}";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 42, 31, 47, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @"Aktif / Pasif";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 42, 35, 47, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                    ISACTIVE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 42, 84, 47, false);
                    ISACTIVE.Name = "ISACTIVE";
                    ISACTIVE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ISACTIVE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ISACTIVE.TextFont.CharSet = 162;
                    ISACTIVE.Value = @"{#ISACTIVE#}";

                    NewField1411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 76, 31, 81, false);
                    NewField1411.Name = "NewField1411";
                    NewField1411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1411.TextFont.CharSet = 162;
                    NewField1411.Value = @"Stok Kart Sıra Nu.";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 76, 35, 81, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1321.TextFont.CharSet = 162;
                    NewField1321.Value = @":";

                    STOCKCARDORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 76, 170, 81, false);
                    STOCKCARDORDERNO.Name = "STOCKCARDORDERNO";
                    STOCKCARDORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKCARDORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STOCKCARDORDERNO.TextFont.CharSet = 162;
                    STOCKCARDORDERNO.Value = @"{#STOCKCARDORDERNO#}";

                    MATERIALIMAGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 27, 170, 52, false);
                    MATERIALIMAGE.Name = "MATERIALIMAGE";
                    MATERIALIMAGE.FieldType = ReportFieldTypeEnum.ftOLE;
                    MATERIALIMAGE.ExpandTabs = EvetHayirEnum.ehEvet;
                    MATERIALIMAGE.Value = @"{#MATERIALPICTURE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Material.GetMaterialDetail_Class dataset_GMD = ParentGroup.rsGroup.GetCurrentRecord<Material.GetMaterialDetail_Class>(0);
                    PARAMETERNAME.CalcValue = PARAMETERNAME.Value;
                    NewField1.CalcValue = NewField1.Value;
                    MATERIALCODE.CalcValue = (dataset_GMD != null ? Globals.ToStringCore(dataset_GMD.Code) : "");
                    COLUMNNAME1.CalcValue = COLUMNNAME1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    PARAMETERNAME1.CalcValue = PARAMETERNAME1.Value;
                    NewField13.CalcValue = NewField13.Value;
                    MATERIALNAME.CalcValue = (dataset_GMD != null ? Globals.ToStringCore(dataset_GMD.Name) : "");
                    ORIGINALNAME.CalcValue = (dataset_GMD != null ? Globals.ToStringCore(dataset_GMD.OriginalName) : "");
                    NewField112.CalcValue = NewField112.Value;
                    NewField121.CalcValue = NewField121.Value;
                    CHARGABLE.CalcValue = (dataset_GMD != null ? Globals.ToStringCore(dataset_GMD.Chargable) : "");
                    NewField113.CalcValue = NewField113.Value;
                    NewField122.CalcValue = NewField122.Value;
                    ALLOWTOGIVEPATIENT.CalcValue = (dataset_GMD != null ? Globals.ToStringCore(dataset_GMD.AllowToGivePatient) : "");
                    NewField11122.CalcValue = NewField11122.Value;
                    NewField11212.CalcValue = NewField11212.Value;
                    MATERIALTREENAME.CalcValue = (dataset_GMD != null ? Globals.ToStringCore(dataset_GMD.Materialtreename) : "");
                    COLUMNNAME11.CalcValue = COLUMNNAME11.Value;
                    NewField114.CalcValue = NewField114.Value;
                    NewField123.CalcValue = NewField123.Value;
                    NSN.CalcValue = (dataset_GMD != null ? Globals.ToStringCore(dataset_GMD.Stockcardnsn) : "");
                    NewField1212.CalcValue = NewField1212.Value;
                    NewField1122.CalcValue = NewField1122.Value;
                    STOCKCARDNAME.CalcValue = (dataset_GMD != null ? Globals.ToStringCore(dataset_GMD.Stockcardname) : "");
                    NewField1311.CalcValue = NewField1311.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    STOCKCARDCLASSCODE.CalcValue = (dataset_GMD != null ? Globals.ToStringCore(dataset_GMD.Stockcardclasscode) : "");
                    NewField11121.CalcValue = NewField11121.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    STOCKCARDCLASSNAME.CalcValue = (dataset_GMD != null ? Globals.ToStringCore(dataset_GMD.Stockcardclassname) : "");
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    ISACTIVE.CalcValue = (dataset_GMD != null ? Globals.ToStringCore(dataset_GMD.IsActive) : "");
                    NewField1411.CalcValue = NewField1411.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    STOCKCARDORDERNO.CalcValue = (dataset_GMD != null ? Globals.ToStringCore(dataset_GMD.Stockcardorderno) : "");
                    MATERIALIMAGE.CalcValue = (dataset_GMD != null ? Globals.ToStringCore(dataset_GMD.MaterialPicture) : "");
                    return new TTReportObject[] { PARAMETERNAME,NewField1,MATERIALCODE,COLUMNNAME1,NewField11,NewField12,PARAMETERNAME1,NewField13,MATERIALNAME,ORIGINALNAME,NewField112,NewField121,CHARGABLE,NewField113,NewField122,ALLOWTOGIVEPATIENT,NewField11122,NewField11212,MATERIALTREENAME,COLUMNNAME11,NewField114,NewField123,NSN,NewField1212,NewField1122,STOCKCARDNAME,NewField1311,NewField1221,STOCKCARDCLASSCODE,NewField11121,NewField11211,STOCKCARDCLASSNAME,NewField1211,NewField1121,ISACTIVE,NewField1411,NewField1321,STOCKCARDORDERNO,MATERIALIMAGE};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    if(this.CHARGABLE.CalcValue=="True"){
            this.CHARGABLE.CalcValue="Evet";
            }
            else if(this.CHARGABLE.CalcValue=="False"){
            this.CHARGABLE.CalcValue="Hayır";
            }
            else{this.CHARGABLE.CalcValue="";}
            
            if(this.ALLOWTOGIVEPATIENT.CalcValue=="True"){
            this.ALLOWTOGIVEPATIENT.CalcValue="Hastaya Verilir";
            }
            else if(this.ALLOWTOGIVEPATIENT.CalcValue=="False"){
            this.ALLOWTOGIVEPATIENT.CalcValue="Hastaya Verilmez";
            }
            else{this.ALLOWTOGIVEPATIENT.CalcValue="";}
            
            if(this.ISACTIVE.CalcValue=="1"){
            this.ISACTIVE.CalcValue="Aktif";
            }
            else if(this.ISACTIVE.CalcValue=="0"){
            this.ISACTIVE.CalcValue="Pasif";
            }
            else{this.ISACTIVE.CalcValue="";}
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public MaterialDetailReport MyParentReport
                {
                    get { return (MaterialDetailReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTCGroup : TTReportGroup
        {
            public MaterialDetailReport MyParentReport
            {
                get { return (MaterialDetailReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField COLUMNNAME11 { get {return Header().COLUMNNAME11;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField COLUMNNAME111 { get {return Header().COLUMNNAME111;} }
            public TTReportField COLUMNNAME112 { get {return Header().COLUMNNAME112;} }
            public TTReportField COLUMNNAME113 { get {return Header().COLUMNNAME113;} }
            public TTReportField COLUMNNAME114 { get {return Header().COLUMNNAME114;} }
            public TTReportField COLUMNNAME115 { get {return Header().COLUMNNAME115;} }
            public TTReportField COLUMNNAME116 { get {return Header().COLUMNNAME116;} }
            public TTReportField COLUMNNAME12 { get {return Header().COLUMNNAME12;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
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
                public MaterialDetailReport MyParentReport
                {
                    get { return (MaterialDetailReport)ParentReport; }
                }
                
                public TTReportField COLUMNNAME11;
                public TTReportShape NewLine11;
                public TTReportField COLUMNNAME111;
                public TTReportField COLUMNNAME112;
                public TTReportField COLUMNNAME113;
                public TTReportField COLUMNNAME114;
                public TTReportField COLUMNNAME115;
                public TTReportField COLUMNNAME116;
                public TTReportField COLUMNNAME12;
                public TTReportShape NewLine12; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    COLUMNNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 9, 6, 14, false);
                    COLUMNNAME11.Name = "COLUMNNAME11";
                    COLUMNNAME11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME11.TextFont.Size = 11;
                    COLUMNNAME11.TextFont.CharSet = 162;
                    COLUMNNAME11.Value = @"Sıra";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 15, 170, 15, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    COLUMNNAME111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 9, 41, 14, false);
                    COLUMNNAME111.Name = "COLUMNNAME111";
                    COLUMNNAME111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME111.TextFont.Size = 11;
                    COLUMNNAME111.TextFont.CharSet = 162;
                    COLUMNNAME111.Value = @"Fiyat Listesi";

                    COLUMNNAME112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 9, 84, 14, false);
                    COLUMNNAME112.Name = "COLUMNNAME112";
                    COLUMNNAME112.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME112.TextFont.Size = 11;
                    COLUMNNAME112.TextFont.CharSet = 162;
                    COLUMNNAME112.Value = @"Fiyat Listesi Grubu";

                    COLUMNNAME113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 9, 105, 14, false);
                    COLUMNNAME113.Name = "COLUMNNAME113";
                    COLUMNNAME113.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME113.TextFont.Size = 11;
                    COLUMNNAME113.TextFont.CharSet = 162;
                    COLUMNNAME113.Value = @"Döviz Cinsi";

                    COLUMNNAME114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 9, 122, 14, false);
                    COLUMNNAME114.Name = "COLUMNNAME114";
                    COLUMNNAME114.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME114.TextFormat = @"Currency";
                    COLUMNNAME114.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME114.TextFont.Size = 11;
                    COLUMNNAME114.TextFont.CharSet = 162;
                    COLUMNNAME114.Value = @"Fiyatı";

                    COLUMNNAME115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 9, 153, 14, false);
                    COLUMNNAME115.Name = "COLUMNNAME115";
                    COLUMNNAME115.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME115.TextFont.Size = 11;
                    COLUMNNAME115.TextFont.CharSet = 162;
                    COLUMNNAME115.Value = @"Başlangıç Tarihi";

                    COLUMNNAME116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 9, 170, 14, false);
                    COLUMNNAME116.Name = "COLUMNNAME116";
                    COLUMNNAME116.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME116.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COLUMNNAME116.TextFont.Size = 11;
                    COLUMNNAME116.TextFont.CharSet = 162;
                    COLUMNNAME116.Value = @"Bitiş Tarihi";

                    COLUMNNAME12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 2, 39, 7, false);
                    COLUMNNAME12.Name = "COLUMNNAME12";
                    COLUMNNAME12.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME12.TextFont.Size = 11;
                    COLUMNNAME12.TextFont.Bold = true;
                    COLUMNNAME12.TextFont.CharSet = 162;
                    COLUMNNAME12.Value = @"Fiyat Bilgileri";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 8, 170, 8, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    COLUMNNAME11.CalcValue = COLUMNNAME11.Value;
                    COLUMNNAME111.CalcValue = COLUMNNAME111.Value;
                    COLUMNNAME112.CalcValue = COLUMNNAME112.Value;
                    COLUMNNAME113.CalcValue = COLUMNNAME113.Value;
                    COLUMNNAME114.CalcValue = COLUMNNAME114.Value;
                    COLUMNNAME115.CalcValue = COLUMNNAME115.Value;
                    COLUMNNAME116.CalcValue = COLUMNNAME116.Value;
                    COLUMNNAME12.CalcValue = COLUMNNAME12.Value;
                    return new TTReportObject[] { COLUMNNAME11,COLUMNNAME111,COLUMNNAME112,COLUMNNAME113,COLUMNNAME114,COLUMNNAME115,COLUMNNAME116,COLUMNNAME12};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public MaterialDetailReport MyParentReport
                {
                    get { return (MaterialDetailReport)ParentReport; }
                }
                 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTCGroup PARTC;

        public partial class MAINGroup : TTReportGroup
        {
            public MaterialDetailReport MyParentReport
            {
                get { return (MaterialDetailReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField PIRICINGLISTGROUPNAME { get {return Body().PIRICINGLISTGROUPNAME;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField PRICINGLISTNAME { get {return Body().PRICINGLISTNAME;} }
            public TTReportField DATEEND { get {return Body().DATEEND;} }
            public TTReportField CURRENCYTYPE { get {return Body().CURRENCYTYPE;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
            public TTReportField DATESTART { get {return Body().DATESTART;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
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
                list[0] = new TTReportNqlData<Material.GetMaterialPricingDetail_Class>("GMPD1", Material.GetMaterialPricingDetail((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.MATERIALOBJECTID)));
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
                public MaterialDetailReport MyParentReport
                {
                    get { return (MaterialDetailReport)ParentReport; }
                }
                
                public TTReportField PIRICINGLISTGROUPNAME;
                public TTReportField NewField1;
                public TTReportField PRICINGLISTNAME;
                public TTReportField DATEEND;
                public TTReportField CURRENCYTYPE;
                public TTReportField PRICE;
                public TTReportField DATESTART;
                public TTReportShape NewLine111; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    PIRICINGLISTGROUPNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 1, 86, 6, false);
                    PIRICINGLISTGROUPNAME.Name = "PIRICINGLISTGROUPNAME";
                    PIRICINGLISTGROUPNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PIRICINGLISTGROUPNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PIRICINGLISTGROUPNAME.MultiLine = EvetHayirEnum.ehEvet;
                    PIRICINGLISTGROUPNAME.NoClip = EvetHayirEnum.ehEvet;
                    PIRICINGLISTGROUPNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PIRICINGLISTGROUPNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PIRICINGLISTGROUPNAME.TextFont.CharSet = 162;
                    PIRICINGLISTGROUPNAME.Value = @"{#PRICINGLISTGROUPNAME#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 6, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"{@groupcounter@}";

                    PRICINGLISTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 41, 6, false);
                    PRICINGLISTNAME.Name = "PRICINGLISTNAME";
                    PRICINGLISTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICINGLISTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICINGLISTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    PRICINGLISTNAME.NoClip = EvetHayirEnum.ehEvet;
                    PRICINGLISTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PRICINGLISTNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PRICINGLISTNAME.TextFont.CharSet = 162;
                    PRICINGLISTNAME.Value = @"{#PRICINGLISTNAME#}";

                    DATEEND = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 1, 170, 6, false);
                    DATEEND.Name = "DATEEND";
                    DATEEND.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATEEND.TextFormat = @"dd/MM/yyyy";
                    DATEEND.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DATEEND.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATEEND.TextFont.CharSet = 162;
                    DATEEND.Value = @"{#DATEEND#}";

                    CURRENCYTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 1, 104, 6, false);
                    CURRENCYTYPE.Name = "CURRENCYTYPE";
                    CURRENCYTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CURRENCYTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENCYTYPE.TextFont.CharSet = 162;
                    CURRENCYTYPE.Value = @"{#CURRENCYTYPENAME#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 1, 122, 6, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"#,##0.00";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"{#PRICE#}";

                    DATESTART = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 126, 1, 150, 6, false);
                    DATESTART.Name = "DATESTART";
                    DATESTART.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATESTART.TextFormat = @"dd/MM/yyyy";
                    DATESTART.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DATESTART.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATESTART.TextFont.CharSet = 162;
                    DATESTART.Value = @"{#DATESTART#}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 11, 170, 11, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Material.GetMaterialPricingDetail_Class dataset_GMPD1 = ParentGroup.rsGroup.GetCurrentRecord<Material.GetMaterialPricingDetail_Class>(0);
                    PIRICINGLISTGROUPNAME.CalcValue = (dataset_GMPD1 != null ? Globals.ToStringCore(dataset_GMPD1.Pricinglistgroupname) : "");
                    NewField1.CalcValue = ParentGroup.GroupCounter.ToString();
                    PRICINGLISTNAME.CalcValue = (dataset_GMPD1 != null ? Globals.ToStringCore(dataset_GMPD1.Pricinglistname) : "");
                    DATEEND.CalcValue = (dataset_GMPD1 != null ? Globals.ToStringCore(dataset_GMPD1.DateEnd) : "");
                    CURRENCYTYPE.CalcValue = (dataset_GMPD1 != null ? Globals.ToStringCore(dataset_GMPD1.Currencytypename) : "");
                    PRICE.CalcValue = (dataset_GMPD1 != null ? Globals.ToStringCore(dataset_GMPD1.Price) : "");
                    DATESTART.CalcValue = (dataset_GMPD1 != null ? Globals.ToStringCore(dataset_GMPD1.DateStart) : "");
                    return new TTReportObject[] { PIRICINGLISTGROUPNAME,NewField1,PRICINGLISTNAME,DATEEND,CURRENCYTYPE,PRICE,DATESTART};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTDGroup : TTReportGroup
        {
            public MaterialDetailReport MyParentReport
            {
                get { return (MaterialDetailReport)ParentReport; }
            }

            new public PARTDGroupHeader Header()
            {
                return (PARTDGroupHeader)_header;
            }

            new public PARTDGroupFooter Footer()
            {
                return (PARTDGroupFooter)_footer;
            }

            public TTReportField COLUMNNAME111 { get {return Header().COLUMNNAME111;} }
            public TTReportField COLUMNNAME1111 { get {return Header().COLUMNNAME1111;} }
            public TTReportField COLUMNNAME1211 { get {return Header().COLUMNNAME1211;} }
            public TTReportField COLUMNNAME1311 { get {return Header().COLUMNNAME1311;} }
            public TTReportField COLUMNNAME1411 { get {return Header().COLUMNNAME1411;} }
            public TTReportField COLUMNNAME1511 { get {return Header().COLUMNNAME1511;} }
            public TTReportField COLUMNNAME1611 { get {return Header().COLUMNNAME1611;} }
            public TTReportField COLUMNNAME121 { get {return Header().COLUMNNAME121;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
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
                public MaterialDetailReport MyParentReport
                {
                    get { return (MaterialDetailReport)ParentReport; }
                }
                
                public TTReportField COLUMNNAME111;
                public TTReportField COLUMNNAME1111;
                public TTReportField COLUMNNAME1211;
                public TTReportField COLUMNNAME1311;
                public TTReportField COLUMNNAME1411;
                public TTReportField COLUMNNAME1511;
                public TTReportField COLUMNNAME1611;
                public TTReportField COLUMNNAME121;
                public TTReportShape NewLine121;
                public TTReportShape NewLine111; 
                public PARTDGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 13;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    COLUMNNAME111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 7, 6, 12, false);
                    COLUMNNAME111.Name = "COLUMNNAME111";
                    COLUMNNAME111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME111.TextFont.Size = 11;
                    COLUMNNAME111.TextFont.CharSet = 162;
                    COLUMNNAME111.Value = @"Sıra";

                    COLUMNNAME1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 7, 48, 12, false);
                    COLUMNNAME1111.Name = "COLUMNNAME1111";
                    COLUMNNAME1111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME1111.TextFont.Size = 11;
                    COLUMNNAME1111.TextFont.CharSet = 162;
                    COLUMNNAME1111.Value = @"Üretici";

                    COLUMNNAME1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 7, 72, 12, false);
                    COLUMNNAME1211.Name = "COLUMNNAME1211";
                    COLUMNNAME1211.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME1211.TextFont.Size = 11;
                    COLUMNNAME1211.TextFont.CharSet = 162;
                    COLUMNNAME1211.Value = @"Barkod";

                    COLUMNNAME1311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 7, 95, 12, false);
                    COLUMNNAME1311.Name = "COLUMNNAME1311";
                    COLUMNNAME1311.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME1311.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME1311.TextFont.Size = 11;
                    COLUMNNAME1311.TextFont.CharSet = 162;
                    COLUMNNAME1311.Value = @"Kutu Miktarı";

                    COLUMNNAME1411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 7, 113, 12, false);
                    COLUMNNAME1411.Name = "COLUMNNAME1411";
                    COLUMNNAME1411.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME1411.TextFormat = @"Currency";
                    COLUMNNAME1411.HorzAlign = HorizontalAlignmentEnum.haRight;
                    COLUMNNAME1411.TextFont.Size = 11;
                    COLUMNNAME1411.TextFont.CharSet = 162;
                    COLUMNNAME1411.Value = @"Lisans Nu.";

                    COLUMNNAME1511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 7, 148, 12, false);
                    COLUMNNAME1511.Name = "COLUMNNAME1511";
                    COLUMNNAME1511.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME1511.TextFont.Size = 11;
                    COLUMNNAME1511.TextFont.CharSet = 162;
                    COLUMNNAME1511.Value = @"Lisans Organizasyonu";

                    COLUMNNAME1611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 7, 170, 12, false);
                    COLUMNNAME1611.Name = "COLUMNNAME1611";
                    COLUMNNAME1611.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME1611.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COLUMNNAME1611.TextFont.Size = 11;
                    COLUMNNAME1611.TextFont.CharSet = 162;
                    COLUMNNAME1611.Value = @"Lisans Tarihi";

                    COLUMNNAME121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 39, 5, false);
                    COLUMNNAME121.Name = "COLUMNNAME121";
                    COLUMNNAME121.CaseFormat = CaseFormatEnum.fcTitleCase;
                    COLUMNNAME121.TextFont.Size = 11;
                    COLUMNNAME121.TextFont.Bold = true;
                    COLUMNNAME121.TextFont.CharSet = 162;
                    COLUMNNAME121.Value = @"Üretici Bilgileri";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 6, 170, 6, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.DrawWidth = 2;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 13, 170, 13, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    COLUMNNAME111.CalcValue = COLUMNNAME111.Value;
                    COLUMNNAME1111.CalcValue = COLUMNNAME1111.Value;
                    COLUMNNAME1211.CalcValue = COLUMNNAME1211.Value;
                    COLUMNNAME1311.CalcValue = COLUMNNAME1311.Value;
                    COLUMNNAME1411.CalcValue = COLUMNNAME1411.Value;
                    COLUMNNAME1511.CalcValue = COLUMNNAME1511.Value;
                    COLUMNNAME1611.CalcValue = COLUMNNAME1611.Value;
                    COLUMNNAME121.CalcValue = COLUMNNAME121.Value;
                    return new TTReportObject[] { COLUMNNAME111,COLUMNNAME1111,COLUMNNAME1211,COLUMNNAME1311,COLUMNNAME1411,COLUMNNAME1511,COLUMNNAME1611,COLUMNNAME121};
                }
            }
            public partial class PARTDGroupFooter : TTReportSection
            {
                public MaterialDetailReport MyParentReport
                {
                    get { return (MaterialDetailReport)ParentReport; }
                }
                 
                public PARTDGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTDGroup PARTD;

        public partial class MAIN2Group : TTReportGroup
        {
            public MaterialDetailReport MyParentReport
            {
                get { return (MaterialDetailReport)ParentReport; }
            }

            new public MAIN2GroupBody Body()
            {
                return (MAIN2GroupBody)_body;
            }
            public TTReportField BARCODE { get {return Body().BARCODE;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField PRODUCERNAME { get {return Body().PRODUCERNAME;} }
            public TTReportField LICENCEDATE { get {return Body().LICENCEDATE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField LICENCENO { get {return Body().LICENCENO;} }
            public TTReportField LICENCINGORGANIZATION { get {return Body().LICENCINGORGANIZATION;} }
            public TTReportShape NewLine1111 { get {return Body().NewLine1111;} }
            public MAIN2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAIN2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Material.GetMaterialBarcodeLevelDetail_Class>("GMBLD1", Material.GetMaterialBarcodeLevelDetail((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.MATERIALOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAIN2GroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAIN2GroupBody : TTReportSection
            {
                public MaterialDetailReport MyParentReport
                {
                    get { return (MaterialDetailReport)ParentReport; }
                }
                
                public TTReportField BARCODE;
                public TTReportField NewField11;
                public TTReportField PRODUCERNAME;
                public TTReportField LICENCEDATE;
                public TTReportField AMOUNT;
                public TTReportField LICENCENO;
                public TTReportField LICENCINGORGANIZATION;
                public TTReportShape NewLine1111; 
                public MAIN2GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 11;
                    RepeatCount = 0;
                    
                    BARCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 1, 76, 6, false);
                    BARCODE.Name = "BARCODE";
                    BARCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BARCODE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BARCODE.MultiLine = EvetHayirEnum.ehEvet;
                    BARCODE.NoClip = EvetHayirEnum.ehEvet;
                    BARCODE.WordBreak = EvetHayirEnum.ehEvet;
                    BARCODE.ExpandTabs = EvetHayirEnum.ehEvet;
                    BARCODE.TextFont.CharSet = 162;
                    BARCODE.Value = @"{#BARCODE#}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 6, 6, false);
                    NewField11.Name = "NewField11";
                    NewField11.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"{@groupcounter@}";

                    PRODUCERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 1, 48, 6, false);
                    PRODUCERNAME.Name = "PRODUCERNAME";
                    PRODUCERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRODUCERNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRODUCERNAME.MultiLine = EvetHayirEnum.ehEvet;
                    PRODUCERNAME.NoClip = EvetHayirEnum.ehEvet;
                    PRODUCERNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PRODUCERNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    PRODUCERNAME.TextFont.CharSet = 162;
                    PRODUCERNAME.Value = @"{#PRODUCERNAME#}";

                    LICENCEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 1, 170, 6, false);
                    LICENCEDATE.Name = "LICENCEDATE";
                    LICENCEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    LICENCEDATE.TextFormat = @"dd/MM/yyyy";
                    LICENCEDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LICENCEDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LICENCEDATE.MultiLine = EvetHayirEnum.ehEvet;
                    LICENCEDATE.NoClip = EvetHayirEnum.ehEvet;
                    LICENCEDATE.WordBreak = EvetHayirEnum.ehEvet;
                    LICENCEDATE.ExpandTabs = EvetHayirEnum.ehEvet;
                    LICENCEDATE.TextFont.CharSet = 162;
                    LICENCEDATE.Value = @"{#LICENCEDATE#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 1, 94, 6, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,##0.00";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#PACKAGEAMOUNT#}";

                    LICENCENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 1, 113, 6, false);
                    LICENCENO.Name = "LICENCENO";
                    LICENCENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    LICENCENO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    LICENCENO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LICENCENO.MultiLine = EvetHayirEnum.ehEvet;
                    LICENCENO.NoClip = EvetHayirEnum.ehEvet;
                    LICENCENO.WordBreak = EvetHayirEnum.ehEvet;
                    LICENCENO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LICENCENO.TextFont.CharSet = 162;
                    LICENCENO.Value = @"{#LICENCENO#}";

                    LICENCINGORGANIZATION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 1, 148, 6, false);
                    LICENCINGORGANIZATION.Name = "LICENCINGORGANIZATION";
                    LICENCINGORGANIZATION.FieldType = ReportFieldTypeEnum.ftVariable;
                    LICENCINGORGANIZATION.TextFormat = @"dd/MM/yyyy";
                    LICENCINGORGANIZATION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LICENCINGORGANIZATION.ObjectDefName = "LicencingOrganizationEnum";
                    LICENCINGORGANIZATION.DataMember = "DISPLAYTEXT";
                    LICENCINGORGANIZATION.TextFont.CharSet = 162;
                    LICENCINGORGANIZATION.Value = @"{#LICENCINGORGANIZATION#}";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 11, 170, 11, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Material.GetMaterialBarcodeLevelDetail_Class dataset_GMBLD1 = ParentGroup.rsGroup.GetCurrentRecord<Material.GetMaterialBarcodeLevelDetail_Class>(0);
                    BARCODE.CalcValue = (dataset_GMBLD1 != null ? Globals.ToStringCore(dataset_GMBLD1.Barcode) : "");
                    NewField11.CalcValue = ParentGroup.GroupCounter.ToString();
                    PRODUCERNAME.CalcValue = (dataset_GMBLD1 != null ? Globals.ToStringCore(dataset_GMBLD1.Producername) : "");
                    LICENCEDATE.CalcValue = (dataset_GMBLD1 != null ? Globals.ToStringCore(dataset_GMBLD1.LicenceDate) : "");
                    AMOUNT.CalcValue = (dataset_GMBLD1 != null ? Globals.ToStringCore(dataset_GMBLD1.PackageAmount) : "");
                    LICENCENO.CalcValue = (dataset_GMBLD1 != null ? Globals.ToStringCore(dataset_GMBLD1.LicenceNO) : "");
                    LICENCINGORGANIZATION.CalcValue = (dataset_GMBLD1 != null ? Globals.ToStringCore(dataset_GMBLD1.LicencingOrganization) : "");
                    LICENCINGORGANIZATION.PostFieldValueCalculation();
                    return new TTReportObject[] { BARCODE,NewField11,PRODUCERNAME,LICENCEDATE,AMOUNT,LICENCENO,LICENCINGORGANIZATION};
                }
            }

        }

        public MAIN2Group MAIN2;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public MaterialDetailReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            PARTC = new PARTCGroup(PARTB,"PARTC");
            MAIN = new MAINGroup(PARTC,"MAIN");
            PARTD = new PARTDGroup(PARTB,"PARTD");
            MAIN2 = new MAIN2Group(PARTD,"MAIN2");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("MATERIALOBJECTID", "", "Malzeme Seçiniz :", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("0e92ac5f-6125-4c67-843c-6c8a8b8a0f5c");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("MATERIALOBJECTID"))
                _runtimeParameters.MATERIALOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["MATERIALOBJECTID"]);
            Name = "MATERIALDETAILREPORT";
            Caption = "Malzeme Detay Raporu";
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