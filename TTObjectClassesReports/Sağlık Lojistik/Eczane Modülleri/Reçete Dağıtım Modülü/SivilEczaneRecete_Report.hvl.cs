
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
    /// Sivil Eczanelere Reçete Dağıtım Formu
    /// </summary>
    public partial class SivilEczaneRecete : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public SivilEczaneRecete MyParentReport
            {
                get { return (SivilEczaneRecete)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField HEADER { get {return Header().HEADER;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportShape NewLine111111 { get {return Footer().NewLine111111;} }
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
                public SivilEczaneRecete MyParentReport
                {
                    get { return (SivilEczaneRecete)ParentReport; }
                }
                
                public TTReportField HEADER; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 24;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 210, 24, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Name = "Arial";
                    HEADER.TextFont.Bold = true;
                    HEADER.TextFont.CharSet = 162;
                    HEADER.Value = @"SİVİL ECZANELERE REÇETE DAĞITIM FORMATI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HEADER.CalcValue = @"SİVİL ECZANELERE REÇETE DAĞITIM FORMATI";
                    return new TTReportObject[] { HEADER};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public SivilEczaneRecete MyParentReport
                {
                    get { return (SivilEczaneRecete)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportShape NewLine111111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 15;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 40, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 0, 125, 5, false);
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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 180, 0, 205, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 0, 205, 0, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PageNumber,CurrentUser};
                }
            }

#region PARTA_Methods
            public static int prescriptionCount = 0;
        public static double balance = 0;
#endregion PARTA_Methods
        }

        public PARTAGroup PARTA;

        public partial class PHARMACYGroup : TTReportGroup
        {
            public SivilEczaneRecete MyParentReport
            {
                get { return (SivilEczaneRecete)ParentReport; }
            }

            new public PHARMACYGroupHeader Header()
            {
                return (PHARMACYGroupHeader)_header;
            }

            new public PHARMACYGroupFooter Footer()
            {
                return (PHARMACYGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField PHARMACY1 { get {return Header().PHARMACY1;} }
            public TTReportField PRESCRIPTIONCOUNT { get {return Header().PRESCRIPTIONCOUNT;} }
            public TTReportField YEAR { get {return Header().YEAR;} }
            public TTReportField MONTH { get {return Header().MONTH;} }
            public TTReportField DAY { get {return Header().DAY;} }
            public TTReportField COLON { get {return Header().COLON;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public PHARMACYGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PHARMACYGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PrescriptionDistribute.GetSivilEczaneQuery_Class>("GetSivilEczaneQuery", PrescriptionDistribute.GetSivilEczaneQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PHARMACYGroupHeader(this);
                _footer = new PHARMACYGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PHARMACYGroupHeader : TTReportSection
            {
                public SivilEczaneRecete MyParentReport
                {
                    get { return (SivilEczaneRecete)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField1121;
                public TTReportField NewField1131;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField161;
                public TTReportField NewField171;
                public TTReportField NewField181;
                public TTReportField PHARMACY1;
                public TTReportField PRESCRIPTIONCOUNT;
                public TTReportField YEAR;
                public TTReportField MONTH;
                public TTReportField DAY;
                public TTReportField COLON; 
                public PHARMACYGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 19;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 9, 12, 18, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 9;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"SN";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 1, 28, 8, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 9;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"ECZANE ADI";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 9, 26, 18, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Size = 9;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"REÇETE
MİK.";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 9, 50, 18, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Size = 9;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"REÇETE TUT.";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 9, 72, 18, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"TARİH";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 9, 94, 18, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Size = 9;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"İLACI GETİREN
ECZ.SOR.";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 9, 117, 18, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Size = 9;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"BAŞECZACILIK
İMZA";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 9, 132, 18, false);
                    NewField151.Name = "NewField151";
                    NewField151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151.MultiLine = EvetHayirEnum.ehEvet;
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.Size = 9;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"KLİNİK
ECZ.İMZA";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 9, 145, 18, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.MultiLine = EvetHayirEnum.ehEvet;
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Size = 9;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"ECZ.ŞEF
İMZA";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 9, 160, 18, false);
                    NewField171.Name = "NewField171";
                    NewField171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField171.MultiLine = EvetHayirEnum.ehEvet;
                    NewField171.TextFont.Name = "Arial";
                    NewField171.TextFont.Size = 9;
                    NewField171.TextFont.Bold = true;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"BAŞECZ.
İMZA";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 9, 190, 18, false);
                    NewField181.Name = "NewField181";
                    NewField181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField181.MultiLine = EvetHayirEnum.ehEvet;
                    NewField181.TextFont.Name = "Arial";
                    NewField181.TextFont.Size = 9;
                    NewField181.TextFont.Bold = true;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @"BAŞTABİP YRD.
İMZA";

                    PHARMACY1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 1, 80, 8, false);
                    PHARMACY1.Name = "PHARMACY1";
                    PHARMACY1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PHARMACY1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PHARMACY1.TextFont.Name = "Arial";
                    PHARMACY1.TextFont.Size = 9;
                    PHARMACY1.TextFont.CharSet = 162;
                    PHARMACY1.Value = @" {#PHARMACY#}";

                    PRESCRIPTIONCOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 5, 247, 10, false);
                    PRESCRIPTIONCOUNT.Name = "PRESCRIPTIONCOUNT";
                    PRESCRIPTIONCOUNT.Visible = EvetHayirEnum.ehHayir;
                    PRESCRIPTIONCOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRESCRIPTIONCOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRESCRIPTIONCOUNT.TextFont.Name = "Arial";
                    PRESCRIPTIONCOUNT.TextFont.CharSet = 162;
                    PRESCRIPTIONCOUNT.Value = @"{#PRESCRIPTIONCOUNT#}";

                    YEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 1, 281, 6, false);
                    YEAR.Name = "YEAR";
                    YEAR.Visible = EvetHayirEnum.ehHayir;
                    YEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    YEAR.Value = @"{#ACTIONYEAR#}";

                    MONTH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 7, 281, 12, false);
                    MONTH.Name = "MONTH";
                    MONTH.Visible = EvetHayirEnum.ehHayir;
                    MONTH.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONTH.Value = @"{#ACTIONMONTH#}";

                    DAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 256, 13, 281, 18, false);
                    DAY.Name = "DAY";
                    DAY.Visible = EvetHayirEnum.ehHayir;
                    DAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAY.Value = @"{#ACTIONDAY#}";

                    COLON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 1, 30, 8, false);
                    COLON.Name = "COLON";
                    COLON.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COLON.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    COLON.TextFont.Name = "Arial";
                    COLON.TextFont.Size = 9;
                    COLON.TextFont.Bold = true;
                    COLON.TextFont.CharSet = 162;
                    COLON.Value = @": ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrescriptionDistribute.GetSivilEczaneQuery_Class dataset_GetSivilEczaneQuery = ParentGroup.rsGroup.GetCurrentRecord<PrescriptionDistribute.GetSivilEczaneQuery_Class>(0);
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField181.CalcValue = NewField181.Value;
                    PHARMACY1.CalcValue = @" " + (dataset_GetSivilEczaneQuery != null ? Globals.ToStringCore(dataset_GetSivilEczaneQuery.Pharmacy) : "");
                    PRESCRIPTIONCOUNT.CalcValue = (dataset_GetSivilEczaneQuery != null ? Globals.ToStringCore(dataset_GetSivilEczaneQuery.Prescriptioncount) : "");
                    YEAR.CalcValue = (dataset_GetSivilEczaneQuery != null ? Globals.ToStringCore(dataset_GetSivilEczaneQuery.Actionyear) : "");
                    MONTH.CalcValue = (dataset_GetSivilEczaneQuery != null ? Globals.ToStringCore(dataset_GetSivilEczaneQuery.Actionmonth) : "");
                    DAY.CalcValue = (dataset_GetSivilEczaneQuery != null ? Globals.ToStringCore(dataset_GetSivilEczaneQuery.Actionday) : "");
                    COLON.CalcValue = COLON.Value;
                    return new TTReportObject[] { NewField111,NewField1111,NewField1121,NewField1131,NewField121,NewField131,NewField141,NewField151,NewField161,NewField171,NewField181,PHARMACY1,PRESCRIPTIONCOUNT,YEAR,MONTH,DAY,COLON};
                }
            }
            public partial class PHARMACYGroupFooter : TTReportSection
            {
                public SivilEczaneRecete MyParentReport
                {
                    get { return (SivilEczaneRecete)ParentReport; }
                }
                
                public TTReportShape NewLine1; 
                public PHARMACYGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 1, 191, 1, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.ForeColor = System.Drawing.Color.White;
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrescriptionDistribute.GetSivilEczaneQuery_Class dataset_GetSivilEczaneQuery = ParentGroup.rsGroup.GetCurrentRecord<PrescriptionDistribute.GetSivilEczaneQuery_Class>(0);
                    return new TTReportObject[] { };
                }
            }

        }

        public PHARMACYGroup PHARMACY;

        public partial class MAINGroup : TTReportGroup
        {
            public SivilEczaneRecete MyParentReport
            {
                get { return (SivilEczaneRecete)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField PRESCRIPTIONCOUNTYEXT { get {return Body().PRESCRIPTIONCOUNTYEXT;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField BALANCE { get {return Body().BALANCE;} }
            public TTReportField DD { get {return Body().DD;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportField NewField5 { get {return Body().NewField5;} }
            public TTReportField NewField6 { get {return Body().NewField6;} }
            public TTReportField MM { get {return Body().MM;} }
            public TTReportField YYYY { get {return Body().YYYY;} }
            public TTReportField POINT { get {return Body().POINT;} }
            public TTReportField POINT1 { get {return Body().POINT1;} }
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

                PrescriptionDistribute.GetSivilEczaneQuery_Class dataSet_GetSivilEczaneQuery = ParentGroup.rsGroup.GetCurrentRecord<PrescriptionDistribute.GetSivilEczaneQuery_Class>(0);    
                return new object[] {(dataSet_GetSivilEczaneQuery==null ? null : dataSet_GetSivilEczaneQuery.Pharmacy)};
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
                public SivilEczaneRecete MyParentReport
                {
                    get { return (SivilEczaneRecete)ParentReport; }
                }
                
                public TTReportField NewField15;
                public TTReportField PRESCRIPTIONCOUNTYEXT;
                public TTReportField ORDERNO;
                public TTReportField BALANCE;
                public TTReportField DD;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField MM;
                public TTReportField YYYY;
                public TTReportField POINT;
                public TTReportField POINT1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 20;
                    RepeatCount = 0;
                    
                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 0, 72, 20, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.Value = @"";

                    PRESCRIPTIONCOUNTYEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 0, 26, 20, false);
                    PRESCRIPTIONCOUNTYEXT.Name = "PRESCRIPTIONCOUNTYEXT";
                    PRESCRIPTIONCOUNTYEXT.DrawStyle = DrawStyleConstants.vbSolid;
                    PRESCRIPTIONCOUNTYEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRESCRIPTIONCOUNTYEXT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRESCRIPTIONCOUNTYEXT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRESCRIPTIONCOUNTYEXT.TextFont.Name = "Arial";
                    PRESCRIPTIONCOUNTYEXT.TextFont.Size = 9;
                    PRESCRIPTIONCOUNTYEXT.TextFont.CharSet = 162;
                    PRESCRIPTIONCOUNTYEXT.Value = @"{#PHARMACY.PRESCRIPTIONCOUNT#}";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 0, 12, 20, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.Size = 9;
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{@counter@}.";

                    BALANCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 0, 50, 20, false);
                    BALANCE.Name = "BALANCE";
                    BALANCE.DrawStyle = DrawStyleConstants.vbSolid;
                    BALANCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BALANCE.TextFormat = @"Currency";
                    BALANCE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BALANCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BALANCE.TextFont.Name = "Arial";
                    BALANCE.TextFont.Size = 9;
                    BALANCE.TextFont.CharSet = 162;
                    BALANCE.Value = @"{#PHARMACY.BALANCE#}TL";

                    DD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 4, 57, 16, false);
                    DD.Name = "DD";
                    DD.FieldType = ReportFieldTypeEnum.ftVariable;
                    DD.TextFormat = @"dd/MM/yyyy";
                    DD.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DD.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DD.TextFont.Size = 9;
                    DD.TextFont.CharSet = 162;
                    DD.Value = @"{#PHARMACY.ACTIONDAY#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 0, 94, 20, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 0, 117, 20, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField2.Value = @"";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 0, 132, 20, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField3.Value = @"";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 0, 145, 20, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.Value = @"";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 160, 20, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField5.Value = @"";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 0, 190, 20, false);
                    NewField6.Name = "NewField6";
                    NewField6.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField6.Value = @"";

                    MM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 4, 61, 16, false);
                    MM.Name = "MM";
                    MM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MM.TextFormat = @"dd/MM/yyyy";
                    MM.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MM.TextFont.Size = 9;
                    MM.TextFont.CharSet = 162;
                    MM.Value = @"{#PHARMACY.ACTIONMONTH#}";

                    YYYY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 4, 69, 16, false);
                    YYYY.Name = "YYYY";
                    YYYY.FieldType = ReportFieldTypeEnum.ftVariable;
                    YYYY.TextFormat = @"dd/MM/yyyy";
                    YYYY.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YYYY.TextFont.Size = 9;
                    YYYY.TextFont.CharSet = 162;
                    YYYY.Value = @"{#PHARMACY.ACTIONYEAR#}";

                    POINT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 7, 58, 13, false);
                    POINT.Name = "POINT";
                    POINT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    POINT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    POINT.TextFont.Name = "Arial";
                    POINT.TextFont.Size = 9;
                    POINT.TextFont.Bold = true;
                    POINT.TextFont.CharSet = 162;
                    POINT.Value = @".";

                    POINT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 7, 62, 13, false);
                    POINT1.Name = "POINT1";
                    POINT1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    POINT1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    POINT1.TextFont.Name = "Arial";
                    POINT1.TextFont.Size = 9;
                    POINT1.TextFont.Bold = true;
                    POINT1.TextFont.CharSet = 162;
                    POINT1.Value = @".";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrescriptionDistribute.GetSivilEczaneQuery_Class dataset_GetSivilEczaneQuery = MyParentReport.PHARMACY.rsGroup.GetCurrentRecord<PrescriptionDistribute.GetSivilEczaneQuery_Class>(0);
                    NewField15.CalcValue = NewField15.Value;
                    PRESCRIPTIONCOUNTYEXT.CalcValue = (dataset_GetSivilEczaneQuery != null ? Globals.ToStringCore(dataset_GetSivilEczaneQuery.Prescriptioncount) : "");
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString() + @".";
                    BALANCE.CalcValue = (dataset_GetSivilEczaneQuery != null ? Globals.ToStringCore(dataset_GetSivilEczaneQuery.Balance) : "") + @"TL";
                    DD.CalcValue = (dataset_GetSivilEczaneQuery != null ? Globals.ToStringCore(dataset_GetSivilEczaneQuery.Actionday) : "");
                    NewField1.CalcValue = @"";
                    NewField2.CalcValue = @"";
                    NewField3.CalcValue = @"";
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    MM.CalcValue = (dataset_GetSivilEczaneQuery != null ? Globals.ToStringCore(dataset_GetSivilEczaneQuery.Actionmonth) : "");
                    YYYY.CalcValue = (dataset_GetSivilEczaneQuery != null ? Globals.ToStringCore(dataset_GetSivilEczaneQuery.Actionyear) : "");
                    POINT.CalcValue = POINT.Value;
                    POINT1.CalcValue = POINT1.Value;
                    return new TTReportObject[] { NewField15,PRESCRIPTIONCOUNTYEXT,ORDERNO,BALANCE,DD,NewField1,NewField2,NewField3,NewField4,NewField5,NewField6,MM,YYYY,POINT,POINT1};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    //PARTAGroup.prescriptionCount += Convert.ToInt32(PRESCRIPTIONCOUNT.CalcValue);
                    //PARTAGroup.balance += Convert.ToDouble(BALANCE.CalcValue);

                    //TARIH.CalcValue = (TarihCekme.CalcValue);
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

        public SivilEczaneRecete()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PHARMACY = new PHARMACYGroup(PARTA,"PHARMACY");
            MAIN = new MAINGroup(PHARMACY,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Tarih Seçiniz :", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "SIVILECZANERECETE";
            Caption = "Sivil Eczanelere Reçete Dağıtım Formu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
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