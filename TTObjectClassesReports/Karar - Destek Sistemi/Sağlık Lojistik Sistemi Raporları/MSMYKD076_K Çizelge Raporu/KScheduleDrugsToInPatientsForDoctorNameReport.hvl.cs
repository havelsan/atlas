
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
    /// Yatan Hastalara Yazılmış ve Eczanede Olan İlaçlar Raporu (K Çizelgesi)(Doktor Seçmeli)
    /// </summary>
    public partial class KScheduleDrugsToInPatientsForDoctorNameReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public string DOCTORID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public KScheduleDrugsToInPatientsForDoctorNameReport MyParentReport
            {
                get { return (KScheduleDrugsToInPatientsForDoctorNameReport)ParentReport; }
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
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField StartDate { get {return Header().StartDate;} }
            public TTReportField EndDate { get {return Header().EndDate;} }
            public TTReportField DoctorName { get {return Header().DoctorName;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
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
                public KScheduleDrugsToInPatientsForDoctorNameReport MyParentReport
                {
                    get { return (KScheduleDrugsToInPatientsForDoctorNameReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField ReportName;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField131;
                public TTReportField NewField132;
                public TTReportField StartDate;
                public TTReportField EndDate;
                public TTReportField DoctorName; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 40;
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
                    ReportName.MultiLine = EvetHayirEnum.ehEvet;
                    ReportName.WordBreak = EvetHayirEnum.ehEvet;
                    ReportName.TextFont.Size = 15;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"YATAN HASTALARA YAZILMIŞ VE DIŞARIDAN KARŞILANAN İLAÇLAR RAPORU
(K ÇİZELGESİ)(DOKTOR SEÇMELİ)";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 24, 23, 29, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Başlangıç Tarihi";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 29, 23, 34, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Bitiş Tarihi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 34, 23, 39, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Doktor Adı";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 24, 24, 29, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @":";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 29, 24, 34, false);
                    NewField131.Name = "NewField131";
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @":";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 34, 24, 39, false);
                    NewField132.Name = "NewField132";
                    NewField132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField132.TextFont.Bold = true;
                    NewField132.TextFont.CharSet = 162;
                    NewField132.Value = @":";

                    StartDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 24, 49, 29, false);
                    StartDate.Name = "StartDate";
                    StartDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    StartDate.TextFormat = @"dd/MM/yyyy";
                    StartDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    StartDate.Value = @"{@STARTDATE@}";

                    EndDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 29, 49, 34, false);
                    EndDate.Name = "EndDate";
                    EndDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    EndDate.TextFormat = @"dd/MM/yyyy";
                    EndDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EndDate.Value = @"{@ENDDATE@}";

                    DoctorName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 34, 49, 39, false);
                    DoctorName.Name = "DoctorName";
                    DoctorName.FieldType = ReportFieldTypeEnum.ftVariable;
                    DoctorName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DoctorName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DoctorName.NoClip = EvetHayirEnum.ehEvet;
                    DoctorName.ObjectDefName = "ResUser";
                    DoctorName.DataMember = "NAME";
                    DoctorName.Value = @"{@DOCTORID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    ReportName.CalcValue = ReportName.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField132.CalcValue = NewField132.Value;
                    StartDate.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    EndDate.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    DoctorName.CalcValue = MyParentReport.RuntimeParameters.DOCTORID.ToString();
                    DoctorName.PostFieldValueCalculation();
                    return new TTReportObject[] { LOGO,ReportName,NewField1,NewField11,NewField12,NewField13,NewField131,NewField132,StartDate,EndDate,DoctorName};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public KScheduleDrugsToInPatientsForDoctorNameReport MyParentReport
                {
                    get { return (KScheduleDrugsToInPatientsForDoctorNameReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField PageNumber;
                public TTReportField CurrentUser;
                public TTReportShape NewLine111; 
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
                    CurrentUser.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 257, 0, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

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
            public KScheduleDrugsToInPatientsForDoctorNameReport MyParentReport
            {
                get { return (KScheduleDrugsToInPatientsForDoctorNameReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField GrandTotal { get {return Footer().GrandTotal;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
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
                public KScheduleDrugsToInPatientsForDoctorNameReport MyParentReport
                {
                    get { return (KScheduleDrugsToInPatientsForDoctorNameReport)ParentReport; }
                }
                 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 2;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public KScheduleDrugsToInPatientsForDoctorNameReport MyParentReport
                {
                    get { return (KScheduleDrugsToInPatientsForDoctorNameReport)ParentReport; }
                }
                
                public TTReportField GrandTotal;
                public TTReportField NewField1;
                public TTReportShape NewLine1; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    GrandTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 0, 257, 5, false);
                    GrandTotal.Name = "GrandTotal";
                    GrandTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    GrandTotal.TextFormat = @"#,##0.#0";
                    GrandTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GrandTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GrandTotal.Value = @"{@sumof(SubTotal)@}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 0, 229, 5, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Genel Toplam:";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 257, 0, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    GrandTotal.CalcValue = ParentGroup.FieldSums["SubTotal"].Value.ToString();;
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { GrandTotal,NewField1};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTCGroup : TTReportGroup
        {
            public KScheduleDrugsToInPatientsForDoctorNameReport MyParentReport
            {
                get { return (KScheduleDrugsToInPatientsForDoctorNameReport)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField PatientNO { get {return Header().PatientNO;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField PatientName { get {return Header().PatientName;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField SubTotal { get {return Footer().SubTotal;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<InpatientDrugOrder.GetKScheduleDrugsForDoctorNameReportQuery_Class>("GetKScheduleDrugsToInPatientsForDoctorNameReportQuery", InpatientDrugOrder.GetKScheduleDrugsForDoctorNameReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.DOCTORID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public KScheduleDrugsToInPatientsForDoctorNameReport MyParentReport
                {
                    get { return (KScheduleDrugsToInPatientsForDoctorNameReport)ParentReport; }
                }
                
                public TTReportField PatientNO;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportField NewField13;
                public TTReportField NewField131;
                public TTReportField NewField132;
                public TTReportShape NewLine1;
                public TTReportField NewField14;
                public TTReportField NewField111;
                public TTReportField PatientName;
                public TTReportShape NewLine111;
                public TTReportShape NewLine11; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 16;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PatientNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 5, 18, 10, false);
                    PatientNO.Name = "PatientNO";
                    PatientNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PatientNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PatientNO.TextFont.CharSet = 162;
                    PatientNO.Value = @"{#ID#}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 10, 18, 15, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Kodu";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 10, 159, 15, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"İlaç Adı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 10, 166, 15, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Doz";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 10, 185, 15, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Size = 11;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Adet";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 10, 193, 15, false);
                    NewField122.Name = "NewField122";
                    NewField122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Size = 11;
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Gün";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 10, 215, 15, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Size = 11;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Toplam Adet";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 10, 234, 15, false);
                    NewField131.Name = "NewField131";
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Size = 11;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Birim Fiyat";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 10, 257, 15, false);
                    NewField132.Name = "NewField132";
                    NewField132.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField132.TextFont.Size = 11;
                    NewField132.TextFont.Bold = true;
                    NewField132.TextFont.CharSet = 162;
                    NewField132.Value = @"Toplam Fiyat";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 15, 257, 15, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 18, 5, false);
                    NewField14.Name = "NewField14";
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Size = 11;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Hasta Nu.";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 0, 67, 5, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Hasta Adı Soyadı";

                    PatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 5, 67, 10, false);
                    PatientName.Name = "PatientName";
                    PatientName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PatientName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PatientName.TextFont.CharSet = 162;
                    PatientName.Value = @"{#PATIENTNAME#} {#PATIENTSURNAME#}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 5, 257, 5, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 10, 257, 10, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientDrugOrder.GetKScheduleDrugsForDoctorNameReportQuery_Class dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery = ParentGroup.rsGroup.GetCurrentRecord<InpatientDrugOrder.GetKScheduleDrugsForDoctorNameReportQuery_Class>(0);
                    PatientNO.CalcValue = (dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery.ID) : "");
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField111.CalcValue = NewField111.Value;
                    PatientName.CalcValue = (dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery.Patientname) : "") + @" " + (dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery.Patientsurname) : "");
                    return new TTReportObject[] { PatientNO,NewField1,NewField11,NewField12,NewField121,NewField122,NewField13,NewField131,NewField132,NewField14,NewField111,PatientName};
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public KScheduleDrugsToInPatientsForDoctorNameReport MyParentReport
                {
                    get { return (KScheduleDrugsToInPatientsForDoctorNameReport)ParentReport; }
                }
                
                public TTReportField NewField2;
                public TTReportField SubTotal;
                public TTReportShape NewLine2; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 5;
                    RepeatCount = 0;
                    
                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 0, 229, 5, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Ara Toplam:";

                    SubTotal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 229, 0, 257, 5, false);
                    SubTotal.Name = "SubTotal";
                    SubTotal.FieldType = ReportFieldTypeEnum.ftVariable;
                    SubTotal.TextFormat = @"#,##0.#0";
                    SubTotal.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SubTotal.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SubTotal.Value = @"{@sumof(TotalPrice)@}";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 5, 0, 257, 0, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientDrugOrder.GetKScheduleDrugsForDoctorNameReportQuery_Class dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery = ParentGroup.rsGroup.GetCurrentRecord<InpatientDrugOrder.GetKScheduleDrugsForDoctorNameReportQuery_Class>(0);
                    NewField2.CalcValue = NewField2.Value;
                    SubTotal.CalcValue = ParentGroup.FieldSums["TotalPrice"].Value.ToString();;
                    return new TTReportObject[] { NewField2,SubTotal};
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class MAINGroup : TTReportGroup
        {
            public KScheduleDrugsToInPatientsForDoctorNameReport MyParentReport
            {
                get { return (KScheduleDrugsToInPatientsForDoctorNameReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField Code { get {return Body().Code;} }
            public TTReportField DrugName { get {return Body().DrugName;} }
            public TTReportField Dose { get {return Body().Dose;} }
            public TTReportField NewFrequency { get {return Body().NewFrequency;} }
            public TTReportField Day { get {return Body().Day;} }
            public TTReportField Amount { get {return Body().Amount;} }
            public TTReportField UnitPrice { get {return Body().UnitPrice;} }
            public TTReportField TotalPrice { get {return Body().TotalPrice;} }
            public TTReportField Frequency { get {return Body().Frequency;} }
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

                InpatientDrugOrder.GetKScheduleDrugsForDoctorNameReportQuery_Class dataSet_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery = ParentGroup.rsGroup.GetCurrentRecord<InpatientDrugOrder.GetKScheduleDrugsForDoctorNameReportQuery_Class>(0);    
                return new object[] {(dataSet_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery==null ? null : dataSet_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery.ID)};
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
                public KScheduleDrugsToInPatientsForDoctorNameReport MyParentReport
                {
                    get { return (KScheduleDrugsToInPatientsForDoctorNameReport)ParentReport; }
                }
                
                public TTReportField Code;
                public TTReportField DrugName;
                public TTReportField Dose;
                public TTReportField NewFrequency;
                public TTReportField Day;
                public TTReportField Amount;
                public TTReportField UnitPrice;
                public TTReportField TotalPrice;
                public TTReportField Frequency; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    Code = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 1, 18, 6, false);
                    Code.Name = "Code";
                    Code.FieldType = ReportFieldTypeEnum.ftVariable;
                    Code.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Code.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Code.ObjectDefName = "Material";
                    Code.DataMember = "CODE";
                    Code.Value = @"{#PARTC.MATERIAL#}";

                    DrugName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 1, 159, 6, false);
                    DrugName.Name = "DrugName";
                    DrugName.FieldType = ReportFieldTypeEnum.ftVariable;
                    DrugName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DrugName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DrugName.ObjectDefName = "Material";
                    DrugName.DataMember = "NAME";
                    DrugName.Value = @"{#PARTC.MATERIAL#}";

                    Dose = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 1, 166, 6, false);
                    Dose.Name = "Dose";
                    Dose.FieldType = ReportFieldTypeEnum.ftVariable;
                    Dose.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Dose.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Dose.Value = @"{#PARTC.DOSEAMOUNT#}";

                    NewFrequency = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 1, 185, 6, false);
                    NewFrequency.Name = "NewFrequency";
                    NewFrequency.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewFrequency.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewFrequency.Value = @"";

                    Day = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 1, 193, 6, false);
                    Day.Name = "Day";
                    Day.FieldType = ReportFieldTypeEnum.ftVariable;
                    Day.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Day.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Day.Value = @"{#PARTC.DAY#}";

                    Amount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 1, 215, 6, false);
                    Amount.Name = "Amount";
                    Amount.FieldType = ReportFieldTypeEnum.ftVariable;
                    Amount.TextFormat = @"#,###";
                    Amount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Amount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Amount.Value = @"{#PARTC.AMOUNT#}";

                    UnitPrice = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 1, 234, 6, false);
                    UnitPrice.Name = "UnitPrice";
                    UnitPrice.FieldType = ReportFieldTypeEnum.ftVariable;
                    UnitPrice.TextFormat = @"#,##0.#0";
                    UnitPrice.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UnitPrice.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UnitPrice.Value = @"{#PARTC.PRICE#}";

                    TotalPrice = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 1, 257, 6, false);
                    TotalPrice.Name = "TotalPrice";
                    TotalPrice.FieldType = ReportFieldTypeEnum.ftVariable;
                    TotalPrice.TextFormat = @"#,##0.#0";
                    TotalPrice.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TotalPrice.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TotalPrice.Value = @"{#PARTC.TOTALPRICE#}";

                    Frequency = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 311, 1, 325, 6, false);
                    Frequency.Name = "Frequency";
                    Frequency.Visible = EvetHayirEnum.ehHayir;
                    Frequency.FieldType = ReportFieldTypeEnum.ftVariable;
                    Frequency.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Frequency.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Frequency.ObjectDefName = "FrequencyEnum";
                    Frequency.DataMember = "DISPLAYTEXT";
                    Frequency.Value = @"{#PARTC.FREQUENCY#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientDrugOrder.GetKScheduleDrugsForDoctorNameReportQuery_Class dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery = MyParentReport.PARTC.rsGroup.GetCurrentRecord<InpatientDrugOrder.GetKScheduleDrugsForDoctorNameReportQuery_Class>(0);
                    Code.CalcValue = (dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery.Material) : "");
                    Code.PostFieldValueCalculation();
                    DrugName.CalcValue = (dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery.Material) : "");
                    DrugName.PostFieldValueCalculation();
                    Dose.CalcValue = (dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery.DoseAmount) : "");
                    NewFrequency.CalcValue = NewFrequency.Value;
                    Day.CalcValue = (dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery.Day) : "");
                    Amount.CalcValue = (dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery.Amount) : "");
                    UnitPrice.CalcValue = (dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery.Price) : "");
                    TotalPrice.CalcValue = (dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery.Totalprice) : "");
                    Frequency.CalcValue = (dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery != null ? Globals.ToStringCore(dataset_GetKScheduleDrugsToInPatientsForDoctorNameReportQuery.Frequency) : "");
                    Frequency.PostFieldValueCalculation();
                    return new TTReportObject[] { Code,DrugName,Dose,NewFrequency,Day,Amount,UnitPrice,TotalPrice,Frequency};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    this.NewFrequency.CalcValue = this.Frequency.CalcValue + "te Bir";
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

        public KScheduleDrugsToInPatientsForDoctorNameReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            PARTC = new PARTCGroup(PARTB,"PARTC");
            MAIN = new MAINGroup(PARTC,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("DOCTORID", "", "Doktor Seçiniz", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("d6efe0cb-c3fd-430f-91fe-b4c7dae415b6");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("DOCTORID"))
                _runtimeParameters.DOCTORID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["DOCTORID"]);
            Name = "KSCHEDULEDRUGSTOINPATIENTSFORDOCTORNAMEREPORT";
            Caption = "Yatan Hastalara Yazılmış ve Eczanede Olan İlaçlar Raporu (K Çizelgesi)(Doktor Seçmeli)";
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