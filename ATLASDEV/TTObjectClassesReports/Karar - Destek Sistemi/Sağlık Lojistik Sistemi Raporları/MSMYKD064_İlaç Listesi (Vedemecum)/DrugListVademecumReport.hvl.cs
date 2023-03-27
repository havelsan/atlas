
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
    /// İlaç Listesi(Vademecum)
    /// </summary>
    public partial class DrugListVademecumReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public DrugListVademecumReport MyParentReport
            {
                get { return (DrugListVademecumReport)ParentReport; }
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
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
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
                public DrugListVademecumReport MyParentReport
                {
                    get { return (DrugListVademecumReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField ReportName; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 21;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 257, 20, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Size = 15;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"İLAÇ LİSTESİ (VADEMECUM)";

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
                public DrugListVademecumReport MyParentReport
                {
                    get { return (DrugListVademecumReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField PageNumber;
                public TTReportField CurrentUser;
                public TTReportShape NewLine1; 
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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 0, 257, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 0, 142, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 257, 0, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

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
            public DrugListVademecumReport MyParentReport
            {
                get { return (DrugListVademecumReport)ParentReport; }
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
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
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
                public DrugListVademecumReport MyParentReport
                {
                    get { return (DrugListVademecumReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportShape NewLine11; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 19, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Kodu";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 85, 5, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"İlacın Ticari Adı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 0, 231, 5, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Formülü";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 0, 257, 5, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Size = 11;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Takdim Şekli";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 5, 257, 5, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

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
                public DrugListVademecumReport MyParentReport
                {
                    get { return (DrugListVademecumReport)ParentReport; }
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
            public DrugListVademecumReport MyParentReport
            {
                get { return (DrugListVademecumReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField Code { get {return Body().Code;} }
            public TTReportField Name { get {return Body().Name;} }
            public TTReportField Formula { get {return Body().Formula;} }
            public TTReportField PresentingType { get {return Body().PresentingType;} }
            public TTReportField ObjectID { get {return Body().ObjectID;} }
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
                list[0] = new TTReportNqlData<DrugDefinition.GetDrugListVademecumReportQuery_Class>("GetDrugListVademecumReportQuery", DrugDefinition.GetDrugListVademecumReportQuery());
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
                public DrugListVademecumReport MyParentReport
                {
                    get { return (DrugListVademecumReport)ParentReport; }
                }
                
                public TTReportField Code;
                public TTReportField Name;
                public TTReportField Formula;
                public TTReportField PresentingType;
                public TTReportField ObjectID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    Code = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 19, 6, false);
                    Code.Name = "Code";
                    Code.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Code.MultiLine = EvetHayirEnum.ehEvet;
                    Code.NoClip = EvetHayirEnum.ehEvet;
                    Code.WordBreak = EvetHayirEnum.ehEvet;
                    Code.ExpandTabs = EvetHayirEnum.ehEvet;
                    Code.Value = @"";

                    Name = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 85, 6, false);
                    Name.Name = "Name";
                    Name.CaseFormat = CaseFormatEnum.fcTitleCase;
                    Name.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Name.MultiLine = EvetHayirEnum.ehEvet;
                    Name.NoClip = EvetHayirEnum.ehEvet;
                    Name.WordBreak = EvetHayirEnum.ehEvet;
                    Name.ExpandTabs = EvetHayirEnum.ehEvet;
                    Name.Value = @"";

                    Formula = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 1, 231, 6, false);
                    Formula.Name = "Formula";
                    Formula.CaseFormat = CaseFormatEnum.fcTitleCase;
                    Formula.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Formula.MultiLine = EvetHayirEnum.ehEvet;
                    Formula.NoClip = EvetHayirEnum.ehEvet;
                    Formula.WordBreak = EvetHayirEnum.ehEvet;
                    Formula.ExpandTabs = EvetHayirEnum.ehEvet;
                    Formula.Value = @"";

                    PresentingType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 1, 257, 6, false);
                    PresentingType.Name = "PresentingType";
                    PresentingType.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PresentingType.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PresentingType.MultiLine = EvetHayirEnum.ehEvet;
                    PresentingType.NoClip = EvetHayirEnum.ehEvet;
                    PresentingType.WordBreak = EvetHayirEnum.ehEvet;
                    PresentingType.ExpandTabs = EvetHayirEnum.ehEvet;
                    PresentingType.Value = @"";

                    ObjectID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 312, 1, 337, 6, false);
                    ObjectID.Name = "ObjectID";
                    ObjectID.Visible = EvetHayirEnum.ehHayir;
                    ObjectID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ObjectID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DrugDefinition.GetDrugListVademecumReportQuery_Class dataset_GetDrugListVademecumReportQuery = ParentGroup.rsGroup.GetCurrentRecord<DrugDefinition.GetDrugListVademecumReportQuery_Class>(0);
                    Code.CalcValue = Code.Value;
                    Name.CalcValue = Name.Value;
                    Formula.CalcValue = Formula.Value;
                    PresentingType.CalcValue = PresentingType.Value;
                    ObjectID.CalcValue = (dataset_GetDrugListVademecumReportQuery != null ? Globals.ToStringCore(dataset_GetDrugListVademecumReportQuery.ObjectID) : "");
                    return new TTReportObject[] { Code,Name,Formula,PresentingType,ObjectID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string objectID = this.ObjectID.CalcValue;
            
            if(Globals.IsGuid(objectID))
            {
                TTObjectContext ctxDrug = new TTObjectContext(true);
                DrugDefinition drugDefinition = (DrugDefinition)ctxDrug.GetObject(new Guid(objectID), typeof(DrugDefinition));
                this.Code.CalcValue = drugDefinition.Code;
                this.Name.CalcValue = drugDefinition.Name;
                if(drugDefinition.StockCard != null)
                    this.PresentingType.CalcValue = drugDefinition.StockCard.DistributionType.DistributionType;
                
                if(drugDefinition.DrugActiveIngredients != null)
                {
                    int count = drugDefinition.DrugActiveIngredients.Count;
                    if(count > 1)
                    {
                        string formula = "";
                        for(int i = 1; i < count ; i++)
                        {
                            formula = formula + ", " + drugDefinition.DrugActiveIngredients[i].Value.ToString() + " " + drugDefinition.DrugActiveIngredients[i].Unit.Name + " " + drugDefinition.DrugActiveIngredients[i].ActiveIngredient.Name;                            
                        }
                        this.Formula.CalcValue = drugDefinition.DrugActiveIngredients[0].Value.ToString() + " " + drugDefinition.DrugActiveIngredients[0].Unit.Name + " " + drugDefinition.DrugActiveIngredients[0].ActiveIngredient.Name + formula;
                    }
                }
                
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

        public DrugListVademecumReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "DRUGLISTVADEMECUMREPORT";
            Caption = "İlaç Listesi(Vademecum)";
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