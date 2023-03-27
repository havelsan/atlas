
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
    /// Dozajı Maksimum Ambalajı Geçen İlaçlar
    /// </summary>
    public partial class DrugsExceededMaxPackageAmountReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public DrugsExceededMaxPackageAmountReport MyParentReport
            {
                get { return (DrugsExceededMaxPackageAmountReport)ParentReport; }
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
                public DrugsExceededMaxPackageAmountReport MyParentReport
                {
                    get { return (DrugsExceededMaxPackageAmountReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField ReportName; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 20;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 170, 20, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Size = 15;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"DOZAJI MAKSİMUM AMBALAJI GEÇEN İLAÇLAR";

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
                public DrugsExceededMaxPackageAmountReport MyParentReport
                {
                    get { return (DrugsExceededMaxPackageAmountReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField PageNumber;
                public TTReportField CurrentUser;
                public TTReportShape NewLine11; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 35;
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
            public DrugsExceededMaxPackageAmountReport MyParentReport
            {
                get { return (DrugsExceededMaxPackageAmountReport)ParentReport; }
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
                public DrugsExceededMaxPackageAmountReport MyParentReport
                {
                    get { return (DrugsExceededMaxPackageAmountReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportShape NewLine1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 8;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 17, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"İlaç Kodu";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 110, 6, false);
                    NewField11.Name = "NewField11";
                    NewField11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"İlaç Adı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 1, 144, 6, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Gün x Dozaj x Aralık";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 1, 170, 6, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Size = 11;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Paketteki Miktar";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 6, 170, 6, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField13};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public DrugsExceededMaxPackageAmountReport MyParentReport
                {
                    get { return (DrugsExceededMaxPackageAmountReport)ParentReport; }
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
            public DrugsExceededMaxPackageAmountReport MyParentReport
            {
                get { return (DrugsExceededMaxPackageAmountReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewDrugCode { get {return Body().NewDrugCode;} }
            public TTReportField DrugName { get {return Body().DrugName;} }
            public TTReportField DayDoseFreq { get {return Body().DayDoseFreq;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField Frequency { get {return Body().Frequency;} }
            public TTReportField Day { get {return Body().Day;} }
            public TTReportField Dose { get {return Body().Dose;} }
            public TTReportField PackageAmount { get {return Body().PackageAmount;} }
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
                list[0] = new TTReportNqlData<DrugOrder.GetDrugsExceededMaxPackageAmountReportQuery_Class>("GetDrugsExceededMaxPackageAmountReportQuery", DrugOrder.GetDrugsExceededMaxPackageAmountReportQuery());
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
                public DrugsExceededMaxPackageAmountReport MyParentReport
                {
                    get { return (DrugsExceededMaxPackageAmountReport)ParentReport; }
                }
                
                public TTReportField NewDrugCode;
                public TTReportField DrugName;
                public TTReportField DayDoseFreq;
                public TTReportShape NewLine1;
                public TTReportField Frequency;
                public TTReportField Day;
                public TTReportField Dose;
                public TTReportField PackageAmount; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewDrugCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 17, 6, false);
                    NewDrugCode.Name = "NewDrugCode";
                    NewDrugCode.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewDrugCode.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewDrugCode.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewDrugCode.Value = @"{#CODE#}";

                    DrugName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 110, 6, false);
                    DrugName.Name = "DrugName";
                    DrugName.FieldType = ReportFieldTypeEnum.ftVariable;
                    DrugName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DrugName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DrugName.Value = @"{#NAME#}";

                    DayDoseFreq = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 1, 144, 6, false);
                    DayDoseFreq.Name = "DayDoseFreq";
                    DayDoseFreq.FieldType = ReportFieldTypeEnum.ftVariable;
                    DayDoseFreq.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DayDoseFreq.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DayDoseFreq.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 170, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    Frequency = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 237, 1, 252, 6, false);
                    Frequency.Name = "Frequency";
                    Frequency.Visible = EvetHayirEnum.ehHayir;
                    Frequency.FieldType = ReportFieldTypeEnum.ftVariable;
                    Frequency.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Frequency.Value = @"{#FREQUENCY#}";

                    Day = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 1, 224, 6, false);
                    Day.Name = "Day";
                    Day.Visible = EvetHayirEnum.ehHayir;
                    Day.FieldType = ReportFieldTypeEnum.ftVariable;
                    Day.Value = @"{#DAY#}";

                    Dose = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 226, 1, 236, 6, false);
                    Dose.Name = "Dose";
                    Dose.Visible = EvetHayirEnum.ehHayir;
                    Dose.FieldType = ReportFieldTypeEnum.ftVariable;
                    Dose.Value = @"{#DOSEAMOUNT#}";

                    PackageAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 1, 170, 6, false);
                    PackageAmount.Name = "PackageAmount";
                    PackageAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    PackageAmount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PackageAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PackageAmount.Value = @"{#PACKAGEAMOUNT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DrugOrder.GetDrugsExceededMaxPackageAmountReportQuery_Class dataset_GetDrugsExceededMaxPackageAmountReportQuery = ParentGroup.rsGroup.GetCurrentRecord<DrugOrder.GetDrugsExceededMaxPackageAmountReportQuery_Class>(0);
                    NewDrugCode.CalcValue = (dataset_GetDrugsExceededMaxPackageAmountReportQuery != null ? Globals.ToStringCore(dataset_GetDrugsExceededMaxPackageAmountReportQuery.Code) : "");
                    DrugName.CalcValue = (dataset_GetDrugsExceededMaxPackageAmountReportQuery != null ? Globals.ToStringCore(dataset_GetDrugsExceededMaxPackageAmountReportQuery.Name) : "");
                    DayDoseFreq.CalcValue = @"";
                    Frequency.CalcValue = (dataset_GetDrugsExceededMaxPackageAmountReportQuery != null ? Globals.ToStringCore(dataset_GetDrugsExceededMaxPackageAmountReportQuery.Frequency) : "");
                    Day.CalcValue = (dataset_GetDrugsExceededMaxPackageAmountReportQuery != null ? Globals.ToStringCore(dataset_GetDrugsExceededMaxPackageAmountReportQuery.Day) : "");
                    Dose.CalcValue = (dataset_GetDrugsExceededMaxPackageAmountReportQuery != null ? Globals.ToStringCore(dataset_GetDrugsExceededMaxPackageAmountReportQuery.DoseAmount) : "");
                    PackageAmount.CalcValue = (dataset_GetDrugsExceededMaxPackageAmountReportQuery != null ? Globals.ToStringCore(dataset_GetDrugsExceededMaxPackageAmountReportQuery.PackageAmount) : "");
                    return new TTReportObject[] { NewDrugCode,DrugName,DayDoseFreq,Frequency,Day,Dose,PackageAmount};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    this.Visible = EvetHayirEnum.ehHayir;
            int day = Convert.ToInt32(Day.CalcValue);
            int dose = Convert.ToInt32(Dose.CalcValue);
            int frequency = 0;
            int packageAmount = Convert.ToInt32(PackageAmount.CalcValue);
            switch (Frequency.CalcValue)
            {
                case "Q3H":
                    frequency = 8;
                    break;
                case "Q6H":
                    frequency = 4;
                    break;
                case "Q8H":
                    frequency = 3;
                    break;
                case "Q12H":
                    frequency = 2;
                    break;
                case "Q24H":
                    frequency = 1;
                    break;
            }

            if ((day * dose * frequency) > packageAmount)
            {
                this.Visible = EvetHayirEnum.ehEvet;
                DayDoseFreq.CalcValue = Day.CalcValue + " x " + Dose.CalcValue + " x " + frequency.ToString();
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

        public DrugsExceededMaxPackageAmountReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "DRUGSEXCEEDEDMAXPACKAGEAMOUNTREPORT";
            Caption = "Dozajı Maksimum Ambalajı Geçen İlaçlar";
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