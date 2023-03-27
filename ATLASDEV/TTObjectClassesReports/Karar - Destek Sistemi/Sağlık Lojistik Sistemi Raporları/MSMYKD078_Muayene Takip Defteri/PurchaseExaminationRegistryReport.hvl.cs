
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
    /// Muayene Takip Defteri
    /// </summary>
    public partial class PurchaseExaminationRegistryReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public PurchaseExaminationRegistryReport MyParentReport
            {
                get { return (PurchaseExaminationRegistryReport)ParentReport; }
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
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
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
                public PurchaseExaminationRegistryReport MyParentReport
                {
                    get { return (PurchaseExaminationRegistryReport)ParentReport; }
                }
                
                public TTReportField REPORTNAME; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 26;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 15, 287, 25, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPORTNAME.TextFont.Name = "Arial";
                    REPORTNAME.TextFont.Size = 12;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.TextFont.CharSet = 162;
                    REPORTNAME.Value = @"MUAYENE TAKİP DEFTERİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    return new TTReportObject[] { REPORTNAME};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public PurchaseExaminationRegistryReport MyParentReport
                {
                    get { return (PurchaseExaminationRegistryReport)ParentReport; }
                }
                
                public TTReportField PageNumber;
                public TTReportField PrintDate;
                public TTReportField CurrentUser;
                public TTReportShape NewLine1; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 10;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 262, 0, 287, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 40, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 0, 156, 5, false);
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

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 0, 287, 0, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PageNumber,PrintDate,CurrentUser};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public PurchaseExaminationRegistryReport MyParentReport
            {
                get { return (PurchaseExaminationRegistryReport)ParentReport; }
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
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
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
                public PurchaseExaminationRegistryReport MyParentReport
                {
                    get { return (PurchaseExaminationRegistryReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField111;
                public TTReportField NewField1111; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 1, 32, 11, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Karar
Nu.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 1, 54, 11, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Karar Tarihi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 1, 111, 11, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Yüklenici Firma";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 1, 169, 11, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13.TextFont.Name = "Arial";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Malı Teslim Alan
Muvakkat Depo";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 1, 227, 11, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14.TextFont.Name = "Arial";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Malzeme Adı";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 1, 247, 11, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15.TextFont.Name = "Arial";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Miktar";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 1, 267, 11, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Birim Fiyat";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 267, 1, 287, 11, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"S. K. Tarihi";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField13,NewField14,NewField15,NewField111,NewField1111};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public PurchaseExaminationRegistryReport MyParentReport
                {
                    get { return (PurchaseExaminationRegistryReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public PurchaseExaminationRegistryReport MyParentReport
            {
                get { return (PurchaseExaminationRegistryReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField CONCLUSIONNO { get {return Body().CONCLUSIONNO;} }
            public TTReportField CONCLUSIONDATE { get {return Body().CONCLUSIONDATE;} }
            public TTReportField SUPPLIER { get {return Body().SUPPLIER;} }
            public TTReportField STORE { get {return Body().STORE;} }
            public TTReportField MATERIAL { get {return Body().MATERIAL;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField EXPIRATIONDATE { get {return Body().EXPIRATIONDATE;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
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
                list[0] = new TTReportNqlData<PurchaseExamination.GetPurchaseExaminationRegistryReportQuery_Class>("GetPurchaseExaminationRegistryReportQuery", PurchaseExamination.GetPurchaseExaminationRegistryReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public PurchaseExaminationRegistryReport MyParentReport
                {
                    get { return (PurchaseExaminationRegistryReport)ParentReport; }
                }
                
                public TTReportField CONCLUSIONNO;
                public TTReportField CONCLUSIONDATE;
                public TTReportField SUPPLIER;
                public TTReportField STORE;
                public TTReportField MATERIAL;
                public TTReportField AMOUNT;
                public TTReportField UNITPRICE;
                public TTReportField EXPIRATIONDATE;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    CONCLUSIONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 32, 5, false);
                    CONCLUSIONNO.Name = "CONCLUSIONNO";
                    CONCLUSIONNO.DrawStyle = DrawStyleConstants.vbSolid;
                    CONCLUSIONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONCLUSIONNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CONCLUSIONNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONCLUSIONNO.TextFont.Name = "Arial";
                    CONCLUSIONNO.TextFont.CharSet = 162;
                    CONCLUSIONNO.Value = @"{#CONCLUSIONNO#}";

                    CONCLUSIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 0, 54, 5, false);
                    CONCLUSIONDATE.Name = "CONCLUSIONDATE";
                    CONCLUSIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    CONCLUSIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONCLUSIONDATE.TextFormat = @"dd/MM/yyyy";
                    CONCLUSIONDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CONCLUSIONDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONCLUSIONDATE.TextFont.Name = "Arial";
                    CONCLUSIONDATE.TextFont.CharSet = 162;
                    CONCLUSIONDATE.Value = @"{#CONCLUSIONAPPROVEDATE#}";

                    SUPPLIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 54, 0, 112, 5, false);
                    SUPPLIER.Name = "SUPPLIER";
                    SUPPLIER.DrawStyle = DrawStyleConstants.vbSolid;
                    SUPPLIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SUPPLIER.TextFont.Name = "Arial";
                    SUPPLIER.TextFont.CharSet = 162;
                    SUPPLIER.Value = @" {#SUPPLIER#}";

                    STORE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 111, 0, 169, 5, false);
                    STORE.Name = "STORE";
                    STORE.DrawStyle = DrawStyleConstants.vbSolid;
                    STORE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STORE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STORE.TextFont.Name = "Arial";
                    STORE.TextFont.CharSet = 162;
                    STORE.Value = @" {#STORE#}";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 0, 227, 5, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIAL.TextFont.Name = "Arial";
                    MATERIAL.TextFont.CharSet = 162;
                    MATERIAL.Value = @" {#MATERIAL#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 0, 247, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFormat = @"#,###";
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 0, 267, 5, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"#,##0.#0";
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UNITPRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICE.TextFont.Name = "Arial";
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#UNITPRICE#}";

                    EXPIRATIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 267, 0, 287, 5, false);
                    EXPIRATIONDATE.Name = "EXPIRATIONDATE";
                    EXPIRATIONDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    EXPIRATIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXPIRATIONDATE.TextFormat = @"dd/MM/yyyy";
                    EXPIRATIONDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EXPIRATIONDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXPIRATIONDATE.TextFont.Name = "Arial";
                    EXPIRATIONDATE.TextFont.CharSet = 162;
                    EXPIRATIONDATE.Value = @"{#EXPIRATIONDATE#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 0, 15, 5, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extPageHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 287, 0, 287, 5, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extPageHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseExamination.GetPurchaseExaminationRegistryReportQuery_Class dataset_GetPurchaseExaminationRegistryReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PurchaseExamination.GetPurchaseExaminationRegistryReportQuery_Class>(0);
                    CONCLUSIONNO.CalcValue = (dataset_GetPurchaseExaminationRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseExaminationRegistryReportQuery.ConclusionNo) : "");
                    CONCLUSIONDATE.CalcValue = (dataset_GetPurchaseExaminationRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseExaminationRegistryReportQuery.ConclusionApproveDate) : "");
                    SUPPLIER.CalcValue = @" " + (dataset_GetPurchaseExaminationRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseExaminationRegistryReportQuery.Supplier) : "");
                    STORE.CalcValue = @" " + (dataset_GetPurchaseExaminationRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseExaminationRegistryReportQuery.Store) : "");
                    MATERIAL.CalcValue = @" " + (dataset_GetPurchaseExaminationRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseExaminationRegistryReportQuery.Material) : "");
                    AMOUNT.CalcValue = (dataset_GetPurchaseExaminationRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseExaminationRegistryReportQuery.Amount) : "");
                    UNITPRICE.CalcValue = (dataset_GetPurchaseExaminationRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseExaminationRegistryReportQuery.UnitPrice) : "");
                    EXPIRATIONDATE.CalcValue = (dataset_GetPurchaseExaminationRegistryReportQuery != null ? Globals.ToStringCore(dataset_GetPurchaseExaminationRegistryReportQuery.ExpirationDate) : "");
                    return new TTReportObject[] { CONCLUSIONNO,CONCLUSIONDATE,SUPPLIER,STORE,MATERIAL,AMOUNT,UNITPRICE,EXPIRATIONDATE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PurchaseExaminationRegistryReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "PURCHASEEXAMINATIONREGISTRYREPORT";
            Caption = "Muayene Takip Defteri";
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