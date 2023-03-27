
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
    /// Dış Eczanelerden Verilen İlaçlar Listesi
    /// </summary>
    public partial class DrugsFromExternalPharmacyReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public string PHARMACYID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public DrugsFromExternalPharmacyReport MyParentReport
            {
                get { return (DrugsFromExternalPharmacyReport)ParentReport; }
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
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField Date { get {return Header().Date;} }
            public TTReportField StartDate { get {return Header().StartDate;} }
            public TTReportField EndDate { get {return Header().EndDate;} }
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
                public DrugsFromExternalPharmacyReport MyParentReport
                {
                    get { return (DrugsFromExternalPharmacyReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField ReportName;
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField Date;
                public TTReportField StartDate;
                public TTReportField EndDate; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 28;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
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
                    ReportName.Value = @"DIŞ ECZANELERDEN VERİLEN İLAÇLAR LİSTESİ";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 23, 17, 28, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Tarih Aralığı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 23, 18, 28, false);
                    NewField12.Name = "NewField12";
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @":";

                    Date = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 23, 41, 28, false);
                    Date.Name = "Date";
                    Date.FieldType = ReportFieldTypeEnum.ftVariable;
                    Date.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Date.NoClip = EvetHayirEnum.ehEvet;
                    Date.TextFont.CharSet = 162;
                    Date.Value = @"{%StartDate%}-{%EndDate%}";

                    StartDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 11, 258, 16, false);
                    StartDate.Name = "StartDate";
                    StartDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    StartDate.TextFormat = @"dd/MM/yyyy";
                    StartDate.Value = @"{@STARTDATE@}";

                    EndDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 248, 21, 273, 26, false);
                    EndDate.Name = "EndDate";
                    EndDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    EndDate.TextFormat = @"dd/MM/yyyy";
                    EndDate.Value = @"{@ENDDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = LOGO.Value;
                    ReportName.CalcValue = ReportName.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    StartDate.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    EndDate.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    Date.CalcValue = MyParentReport.PARTA.StartDate.FormattedValue + @"-" + MyParentReport.PARTA.EndDate.FormattedValue;
                    return new TTReportObject[] { LOGO,ReportName,NewField1,NewField12,StartDate,EndDate,Date};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public DrugsFromExternalPharmacyReport MyParentReport
                {
                    get { return (DrugsFromExternalPharmacyReport)ParentReport; }
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

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 170, 0, false);
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
            public DrugsFromExternalPharmacyReport MyParentReport
            {
                get { return (DrugsFromExternalPharmacyReport)ParentReport; }
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
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField Pharmacy { get {return Header().Pharmacy;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
            public TTReportField GrandTotalAmount { get {return Footer().GrandTotalAmount;} }
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
                list[0] = new TTReportNqlData<InpatientPrescription.GetDrugsFromExternalPharmacyReportQuery_Class>("GetDrugsFromExternalPharmacyReportQuery", InpatientPrescription.GetDrugsFromExternalPharmacyReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.PHARMACYID)));
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
                public DrugsFromExternalPharmacyReport MyParentReport
                {
                    get { return (DrugsFromExternalPharmacyReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportShape NewLine1;
                public TTReportField NewField111;
                public TTReportField NewField1121;
                public TTReportField Pharmacy; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 11;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 6, 92, 11, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"İlaç Adı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 6, 118, 11, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Kutu";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 6, 144, 11, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Fiyat";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 6, 170, 11, false);
                    NewField13.Name = "NewField13";
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Size = 11;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Toplam";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 11, 170, 11, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 17, 5, false);
                    NewField111.Name = "NewField111";
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Eczane";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 0, 18, 5, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                    Pharmacy = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 0, 41, 5, false);
                    Pharmacy.Name = "Pharmacy";
                    Pharmacy.FieldType = ReportFieldTypeEnum.ftVariable;
                    Pharmacy.CaseFormat = CaseFormatEnum.fcTitleCase;
                    Pharmacy.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Pharmacy.NoClip = EvetHayirEnum.ehEvet;
                    Pharmacy.ObjectDefName = "ExternalPharmacy";
                    Pharmacy.DataMember = "NAME";
                    Pharmacy.TextFont.CharSet = 162;
                    Pharmacy.Value = @"{#EXTERNALPHARMACYID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientPrescription.GetDrugsFromExternalPharmacyReportQuery_Class dataset_GetDrugsFromExternalPharmacyReportQuery = ParentGroup.rsGroup.GetCurrentRecord<InpatientPrescription.GetDrugsFromExternalPharmacyReportQuery_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    Pharmacy.CalcValue = (dataset_GetDrugsFromExternalPharmacyReportQuery != null ? Globals.ToStringCore(dataset_GetDrugsFromExternalPharmacyReportQuery.Externalpharmacyid) : "");
                    Pharmacy.PostFieldValueCalculation();
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField13,NewField111,NewField1121,Pharmacy};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public DrugsFromExternalPharmacyReport MyParentReport
                {
                    get { return (DrugsFromExternalPharmacyReport)ParentReport; }
                }
                
                public TTReportField NewField2;
                public TTReportField GrandTotalAmount; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 6;
                    RepeatCount = 0;
                    
                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 1, 145, 6, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Genel Toplam:";

                    GrandTotalAmount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 1, 170, 6, false);
                    GrandTotalAmount.Name = "GrandTotalAmount";
                    GrandTotalAmount.FieldType = ReportFieldTypeEnum.ftVariable;
                    GrandTotalAmount.TextFormat = @"#,##0.#0";
                    GrandTotalAmount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    GrandTotalAmount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GrandTotalAmount.Value = @"{@sumof(TotalPrice)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientPrescription.GetDrugsFromExternalPharmacyReportQuery_Class dataset_GetDrugsFromExternalPharmacyReportQuery = ParentGroup.rsGroup.GetCurrentRecord<InpatientPrescription.GetDrugsFromExternalPharmacyReportQuery_Class>(0);
                    NewField2.CalcValue = NewField2.Value;
                    GrandTotalAmount.CalcValue = ParentGroup.FieldSums["TotalPrice"].Value.ToString();;
                    return new TTReportObject[] { NewField2,GrandTotalAmount};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public DrugsFromExternalPharmacyReport MyParentReport
            {
                get { return (DrugsFromExternalPharmacyReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DrugName { get {return Body().DrugName;} }
            public TTReportField Amount { get {return Body().Amount;} }
            public TTReportField UnitPrice { get {return Body().UnitPrice;} }
            public TTReportField TotalPrice { get {return Body().TotalPrice;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
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

                InpatientPrescription.GetDrugsFromExternalPharmacyReportQuery_Class dataSet_GetDrugsFromExternalPharmacyReportQuery = ParentGroup.rsGroup.GetCurrentRecord<InpatientPrescription.GetDrugsFromExternalPharmacyReportQuery_Class>(0);    
                return new object[] {(dataSet_GetDrugsFromExternalPharmacyReportQuery==null ? null : dataSet_GetDrugsFromExternalPharmacyReportQuery.Externalpharmacyid)};
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
                public DrugsFromExternalPharmacyReport MyParentReport
                {
                    get { return (DrugsFromExternalPharmacyReport)ParentReport; }
                }
                
                public TTReportField DrugName;
                public TTReportField Amount;
                public TTReportField UnitPrice;
                public TTReportField TotalPrice;
                public TTReportShape NewLine1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 8;
                    RepeatCount = 0;
                    
                    DrugName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 92, 6, false);
                    DrugName.Name = "DrugName";
                    DrugName.FieldType = ReportFieldTypeEnum.ftVariable;
                    DrugName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    DrugName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DrugName.Value = @"{#PARTB.NAME#}";

                    Amount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 1, 118, 6, false);
                    Amount.Name = "Amount";
                    Amount.FieldType = ReportFieldTypeEnum.ftVariable;
                    Amount.TextFormat = @"#,###";
                    Amount.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Amount.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Amount.Value = @"{#PARTB.AMOUNT#}";

                    UnitPrice = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 119, 1, 144, 6, false);
                    UnitPrice.Name = "UnitPrice";
                    UnitPrice.FieldType = ReportFieldTypeEnum.ftVariable;
                    UnitPrice.TextFormat = @"#,##0.#0";
                    UnitPrice.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UnitPrice.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UnitPrice.Value = @"{#PARTB.PRICE#}";

                    TotalPrice = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 1, 170, 6, false);
                    TotalPrice.Name = "TotalPrice";
                    TotalPrice.FieldType = ReportFieldTypeEnum.ftVariable;
                    TotalPrice.TextFormat = @"#,##0.#0";
                    TotalPrice.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TotalPrice.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TotalPrice.Value = @"{#PARTB.TOTALPRICE#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 170, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientPrescription.GetDrugsFromExternalPharmacyReportQuery_Class dataset_GetDrugsFromExternalPharmacyReportQuery = MyParentReport.PARTB.rsGroup.GetCurrentRecord<InpatientPrescription.GetDrugsFromExternalPharmacyReportQuery_Class>(0);
                    DrugName.CalcValue = (dataset_GetDrugsFromExternalPharmacyReportQuery != null ? Globals.ToStringCore(dataset_GetDrugsFromExternalPharmacyReportQuery.Name) : "");
                    Amount.CalcValue = (dataset_GetDrugsFromExternalPharmacyReportQuery != null ? Globals.ToStringCore(dataset_GetDrugsFromExternalPharmacyReportQuery.Amount) : "");
                    UnitPrice.CalcValue = (dataset_GetDrugsFromExternalPharmacyReportQuery != null ? Globals.ToStringCore(dataset_GetDrugsFromExternalPharmacyReportQuery.Price) : "");
                    TotalPrice.CalcValue = (dataset_GetDrugsFromExternalPharmacyReportQuery != null ? Globals.ToStringCore(dataset_GetDrugsFromExternalPharmacyReportQuery.Totalprice) : "");
                    return new TTReportObject[] { DrugName,Amount,UnitPrice,TotalPrice};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public DrugsFromExternalPharmacyReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("PHARMACYID", "", "Eczane Seçiniz", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("706b3836-b6b2-47f3-a342-4fa3411b549b");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("PHARMACYID"))
                _runtimeParameters.PHARMACYID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["PHARMACYID"]);
            Name = "DRUGSFROMEXTERNALPHARMACYREPORT";
            Caption = "Dış Eczanelerden Verilen İlaçlar Listesi";
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