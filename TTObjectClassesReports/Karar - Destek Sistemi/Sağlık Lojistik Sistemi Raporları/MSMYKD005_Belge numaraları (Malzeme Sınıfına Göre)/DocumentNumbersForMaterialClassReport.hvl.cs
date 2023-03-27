
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
    /// Belge Numaraları (Malzeme Sınıfına Göre)
    /// </summary>
    public partial class DocumentNumbersForMaterialClassReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? MAINCLASSID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? ACCOUNTINGTERM = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public ReferenceLetterEnum? REFERENCELETTER = (ReferenceLetterEnum?)(int?)TTObjectDefManager.Instance.DataTypes["ReferenceLetterEnum"].ConvertValue("0");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public DocumentNumbersForMaterialClassReport MyParentReport
            {
                get { return (DocumentNumbersForMaterialClassReport)ParentReport; }
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
            public TTReportField ReferenceLetter { get {return Header().ReferenceLetter;} }
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
                public DocumentNumbersForMaterialClassReport MyParentReport
                {
                    get { return (DocumentNumbersForMaterialClassReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField ReportName;
                public TTReportField ReferenceLetter; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 20;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.Value = @"";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 170, 20, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.MultiLine = EvetHayirEnum.ehEvet;
                    ReportName.TextFont.Name = "Arial";
                    ReportName.TextFont.Size = 12;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"
BELGE NUMARALARI
(MALZEME SINIFLARINA GÖRE) RAPORU";

                    ReferenceLetter = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 5, 241, 10, false);
                    ReferenceLetter.Name = "ReferenceLetter";
                    ReferenceLetter.Visible = EvetHayirEnum.ehHayir;
                    ReferenceLetter.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReferenceLetter.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    ReportName.CalcValue = ReportName.Value;
                    ReferenceLetter.CalcValue = @"";
                    return new TTReportObject[] { LOGO,ReportName,ReferenceLetter};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    ReferenceLetter.CalcValue = TTObjectClasses.Common.GetEnumValueDefOfEnumValue(MyParentReport.RuntimeParameters.REFERENCELETTER.Value).DisplayText.ToString() + "-%";
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public DocumentNumbersForMaterialClassReport MyParentReport
                {
                    get { return (DocumentNumbersForMaterialClassReport)ParentReport; }
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
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

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
            public DocumentNumbersForMaterialClassReport MyParentReport
            {
                get { return (DocumentNumbersForMaterialClassReport)ParentReport; }
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
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField MAINCLASS { get {return Header().MAINCLASS;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField152 { get {return Header().NewField152;} }
            public TTReportField NewField153 { get {return Header().NewField153;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField MILITARYUNIT { get {return Header().MILITARYUNIT;} }
            public TTReportField ACCOUNTANCYNO { get {return Header().ACCOUNTANCYNO;} }
            public TTReportField ACCOUNTINGTERM { get {return Header().ACCOUNTINGTERM;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField1251 { get {return Header().NewField1251;} }
            public TTReportField STORE { get {return Header().STORE;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField TOTAL { get {return Footer().TOTAL;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField NewField16 { get {return Footer().NewField16;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
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
                public DocumentNumbersForMaterialClassReport MyParentReport
                {
                    get { return (DocumentNumbersForMaterialClassReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField MAINCLASS;
                public TTReportField NewField15;
                public TTReportField NewField152;
                public TTReportField NewField153;
                public TTReportShape NewLine1;
                public TTReportField MILITARYUNIT;
                public TTReportField ACCOUNTANCYNO;
                public TTReportField ACCOUNTINGTERM;
                public TTReportField NewField121;
                public TTReportField NewField1251;
                public TTReportField STORE;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 30;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 6, 27, 11, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Birliği";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 11, 27, 16, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Saymanlık Nu.";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 16, 27, 21, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Hesap Dönemi";

                    MAINCLASS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 23, 100, 29, false);
                    MAINCLASS.Name = "MAINCLASS";
                    MAINCLASS.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAINCLASS.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MAINCLASS.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MAINCLASS.NoClip = EvetHayirEnum.ehEvet;
                    MAINCLASS.ObjectDefName = "StockCardClass";
                    MAINCLASS.DataMember = "NAME";
                    MAINCLASS.TextFont.Name = "Arial";
                    MAINCLASS.TextFont.Size = 11;
                    MAINCLASS.TextFont.Bold = true;
                    MAINCLASS.TextFont.CharSet = 162;
                    MAINCLASS.Value = @"{@MAINCLASSID@}";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 6, 29, 11, false);
                    NewField15.Name = "NewField15";
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @":";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 11, 29, 16, false);
                    NewField152.Name = "NewField152";
                    NewField152.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField152.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField152.TextFont.Name = "Arial";
                    NewField152.TextFont.Bold = true;
                    NewField152.TextFont.CharSet = 162;
                    NewField152.Value = @":";

                    NewField153 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 16, 29, 21, false);
                    NewField153.Name = "NewField153";
                    NewField153.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField153.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField153.TextFont.Name = "Arial";
                    NewField153.TextFont.Bold = true;
                    NewField153.TextFont.CharSet = 162;
                    NewField153.Value = @":";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 29, 170, 29, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 6, 170, 11, false);
                    MILITARYUNIT.Name = "MILITARYUNIT";
                    MILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MILITARYUNIT.WordBreak = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.ObjectDefName = "MainStoreDefinition";
                    MILITARYUNIT.DataMember = "ACCOUNTANCY.ACCOUNTANCYMILITARYUNIT.NAME";
                    MILITARYUNIT.TextFont.Name = "Arial";
                    MILITARYUNIT.TextFont.CharSet = 162;
                    MILITARYUNIT.Value = @"{@STOREID@}";

                    ACCOUNTANCYNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 11, 170, 16, false);
                    ACCOUNTANCYNO.Name = "ACCOUNTANCYNO";
                    ACCOUNTANCYNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACCOUNTANCYNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACCOUNTANCYNO.ObjectDefName = "MainStoreDefinition";
                    ACCOUNTANCYNO.DataMember = "ACCOUNTANCY.ACCOUNTANCYCODE";
                    ACCOUNTANCYNO.TextFont.Name = "Arial";
                    ACCOUNTANCYNO.TextFont.CharSet = 162;
                    ACCOUNTANCYNO.Value = @"{@STOREID@}";

                    ACCOUNTINGTERM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 16, 170, 21, false);
                    ACCOUNTINGTERM.Name = "ACCOUNTINGTERM";
                    ACCOUNTINGTERM.FieldType = ReportFieldTypeEnum.ftExpression;
                    ACCOUNTINGTERM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACCOUNTINGTERM.TextFont.Name = "Arial";
                    ACCOUNTINGTERM.TextFont.CharSet = 162;
                    ACCOUNTINGTERM.Value = @"STARTDATE.FormattedValue + "" - "" + ENDDATE.FormattedValue";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 27, 6, false);
                    NewField121.Name = "NewField121";
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Depo İsmi";

                    NewField1251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 1, 29, 6, false);
                    NewField1251.Name = "NewField1251";
                    NewField1251.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1251.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1251.TextFont.Name = "Arial";
                    NewField1251.TextFont.Bold = true;
                    NewField1251.TextFont.CharSet = 162;
                    NewField1251.Value = @":";

                    STORE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 1, 170, 6, false);
                    STORE.Name = "STORE";
                    STORE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STORE.WordBreak = EvetHayirEnum.ehEvet;
                    STORE.ObjectDefName = "MainStoreDefinition";
                    STORE.DataMember = "NAME";
                    STORE.TextFont.Name = "Arial";
                    STORE.TextFont.CharSet = 162;
                    STORE.Value = @"{@STOREID@}";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 4, 237, 9, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.Visible = EvetHayirEnum.ehHayir;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.ObjectDefName = "AccountingTerm";
                    STARTDATE.DataMember = "STARTDATE";
                    STARTDATE.Value = @"{@ACCOUNTINGTERM@}";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 12, 237, 17, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.Visible = EvetHayirEnum.ehHayir;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.ObjectDefName = "AccountingTerm";
                    ENDDATE.DataMember = "ENDDATE";
                    ENDDATE.Value = @"{@ACCOUNTINGTERM@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    MAINCLASS.CalcValue = MyParentReport.RuntimeParameters.MAINCLASSID.ToString();
                    MAINCLASS.PostFieldValueCalculation();
                    NewField15.CalcValue = NewField15.Value;
                    NewField152.CalcValue = NewField152.Value;
                    NewField153.CalcValue = NewField153.Value;
                    MILITARYUNIT.CalcValue = MyParentReport.RuntimeParameters.STOREID.ToString();
                    MILITARYUNIT.PostFieldValueCalculation();
                    ACCOUNTANCYNO.CalcValue = MyParentReport.RuntimeParameters.STOREID.ToString();
                    ACCOUNTANCYNO.PostFieldValueCalculation();
                    NewField121.CalcValue = NewField121.Value;
                    NewField1251.CalcValue = NewField1251.Value;
                    STORE.CalcValue = MyParentReport.RuntimeParameters.STOREID.ToString();
                    STORE.PostFieldValueCalculation();
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.ACCOUNTINGTERM.ToString();
                    STARTDATE.PostFieldValueCalculation();
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ACCOUNTINGTERM.ToString();
                    ENDDATE.PostFieldValueCalculation();
                    ACCOUNTINGTERM.CalcValue = STARTDATE.FormattedValue + " - " + ENDDATE.FormattedValue;
                    return new TTReportObject[] { NewField1,NewField12,NewField13,MAINCLASS,NewField15,NewField152,NewField153,MILITARYUNIT,ACCOUNTANCYNO,NewField121,NewField1251,STORE,STARTDATE,ENDDATE,ACCOUNTINGTERM};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    AccountingTerm term = (AccountingTerm)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.ACCOUNTINGTERM.Value, typeof(AccountingTerm));
            if (term != null)
            {
                STARTDATE.CalcValue = term.StartDate.ToString();
                ENDDATE.CalcValue = term.EndDate.ToString();
            }
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public DocumentNumbersForMaterialClassReport MyParentReport
                {
                    get { return (DocumentNumbersForMaterialClassReport)ParentReport; }
                }
                
                public TTReportField TOTAL;
                public TTReportShape NewLine11;
                public TTReportField NewField3;
                public TTReportField NewField16;
                public TTReportField NewField4; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 67;
                    RepeatCount = 0;
                    
                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 170, 6, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL.TextFont.Name = "Arial";
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"Toplam {@subgroupcount@} adet belge düzenlenmiştir.";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 170, 0, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 25, 45, 30, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Name = "Arial";
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Teslim Eden";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 25, 145, 30, false);
                    NewField16.Name = "NewField16";
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"Teslim Alan";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 44, 95, 49, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Name = "Arial";
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Onay";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOTAL.CalcValue = @"Toplam " + (ParentGroup.SubGroupCount - 1).ToString() + @" adet belge düzenlenmiştir.";
                    NewField3.CalcValue = NewField3.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField4.CalcValue = NewField4.Value;
                    return new TTReportObject[] { TOTAL,NewField3,NewField16,NewField4};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public DocumentNumbersForMaterialClassReport MyParentReport
            {
                get { return (DocumentNumbersForMaterialClassReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ORDER { get {return Body().ORDER;} }
            public TTReportField REGISTRATIONNO { get {return Body().REGISTRATIONNO;} }
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
                list[0] = new TTReportNqlData<StockAction.GetDocumentNumbersForMaterialClassReportQuery_Class>("GetDocumentNumbersForMaterialClassReportQuery", StockAction.GetDocumentNumbersForMaterialClassReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STOREID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.ACCOUNTINGTERM),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MAINCLASSID),(string)TTObjectDefManager.Instance.DataTypes["String30"].ConvertValue(MyParentReport.PARTA.ReferenceLetter.CalcValue)));
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
                public DocumentNumbersForMaterialClassReport MyParentReport
                {
                    get { return (DocumentNumbersForMaterialClassReport)ParentReport; }
                }
                
                public TTReportField ORDER;
                public TTReportField REGISTRATIONNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    AutoSizeGap = 1;
                    RepeatCount = 5;
                    RepeatWidth = 34;
                    
                    ORDER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 8, 6, false);
                    ORDER.Name = "ORDER";
                    ORDER.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ORDER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDER.TextFont.Name = "Arial";
                    ORDER.TextFont.CharSet = 162;
                    ORDER.Value = @"{@counter@}";

                    REGISTRATIONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 29, 6, false);
                    REGISTRATIONNO.Name = "REGISTRATIONNO";
                    REGISTRATIONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REGISTRATIONNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REGISTRATIONNO.TextFont.Name = "Arial";
                    REGISTRATIONNO.TextFont.CharSet = 162;
                    REGISTRATIONNO.Value = @"{#REGISTRATIONNUMBER#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockAction.GetDocumentNumbersForMaterialClassReportQuery_Class dataset_GetDocumentNumbersForMaterialClassReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockAction.GetDocumentNumbersForMaterialClassReportQuery_Class>(0);
                    ORDER.CalcValue = ParentGroup.Counter.ToString();
                    REGISTRATIONNO.CalcValue = (dataset_GetDocumentNumbersForMaterialClassReportQuery != null ? Globals.ToStringCore(dataset_GetDocumentNumbersForMaterialClassReportQuery.RegistrationNumber) : "");
                    return new TTReportObject[] { ORDER,REGISTRATIONNO};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DocumentNumbersForMaterialClassReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("MAINCLASSID", "00000000-0000-0000-0000-000000000000", "Kart Sınıfını Seçiniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("868b54df-fc49-488a-8810-4dee66438aa3");
            reportParameter = Parameters.Add("STOREID", "00000000-0000-0000-0000-000000000000", "Depoyu Seçiniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("cd051a98-4361-4c40-8ad6-6f7b69696f8e");
            reportParameter = Parameters.Add("ACCOUNTINGTERM", "00000000-0000-0000-0000-000000000000", "Hesap Dönemi Seçiniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("429e41e5-620c-4652-9e24-aa488e0aaaaf");
            reportParameter = Parameters.Add("REFERENCELETTER", "0", "Belge Referans Harfini Seçiniz", @"", true, true, false, new Guid("9ceaa917-e48a-45e2-96f1-ffeed511d7c1"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("MAINCLASSID"))
                _runtimeParameters.MAINCLASSID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MAINCLASSID"]);
            if (parameters.ContainsKey("STOREID"))
                _runtimeParameters.STOREID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STOREID"]);
            if (parameters.ContainsKey("ACCOUNTINGTERM"))
                _runtimeParameters.ACCOUNTINGTERM = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["ACCOUNTINGTERM"]);
            if (parameters.ContainsKey("REFERENCELETTER"))
                _runtimeParameters.REFERENCELETTER = (ReferenceLetterEnum?)(int?)TTObjectDefManager.Instance.DataTypes["ReferenceLetterEnum"].ConvertValue(parameters["REFERENCELETTER"]);
            Name = "DOCUMENTNUMBERSFORMATERIALCLASSREPORT";
            Caption = "Belge Numaraları (Malzeme Sınıfına Göre)";
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