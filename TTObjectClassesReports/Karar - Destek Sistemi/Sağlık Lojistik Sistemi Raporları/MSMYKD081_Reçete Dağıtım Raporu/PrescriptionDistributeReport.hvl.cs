
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
    /// Reçete Dağıtım Raporu
    /// </summary>
    public partial class PrescriptionDistributeReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("23:59");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public PrescriptionDistributeReport MyParentReport
            {
                get { return (PrescriptionDistributeReport)ParentReport; }
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
                public PrescriptionDistributeReport MyParentReport
                {
                    get { return (PrescriptionDistributeReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField ReportName; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 22;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 0, 144, 20, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Size = 15;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"REÇETE DAĞITIM RAPORU";

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
                public PrescriptionDistributeReport MyParentReport
                {
                    get { return (PrescriptionDistributeReport)ParentReport; }
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
            public PrescriptionDistributeReport MyParentReport
            {
                get { return (PrescriptionDistributeReport)ParentReport; }
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
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField PharmacyName { get {return Header().PharmacyName;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField NewField111311 { get {return Header().NewField111311;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField TotalPrice { get {return Footer().TotalPrice;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
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
                list[0] = new TTReportNqlData<ExternalPharmacyPrescriptionTransaction.GetPrescriptionReportQuery_Class>("GetPrescriptionReportQuery", ExternalPharmacyPrescriptionTransaction.GetPrescriptionReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE)));
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
                public PrescriptionDistributeReport MyParentReport
                {
                    get { return (PrescriptionDistributeReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField PharmacyName;
                public TTReportField NewField3;
                public TTReportField NewField13;
                public TTReportField NewField131;
                public TTReportField NewField1131;
                public TTReportField NewField11311;
                public TTReportField NewField111311;
                public TTReportField NewField5;
                public TTReportShape NewLine1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 12;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 18, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Eczane İsmi";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 1, 19, 6, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @":";

                    PharmacyName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 1, 44, 6, false);
                    PharmacyName.Name = "PharmacyName";
                    PharmacyName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PharmacyName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PharmacyName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PharmacyName.NoClip = EvetHayirEnum.ehEvet;
                    PharmacyName.TextFont.CharSet = 162;
                    PharmacyName.Value = @"{#PHARMACY#}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 6, 10, 11, false);
                    NewField3.Name = "NewField3";
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Size = 11;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"S. Nu.";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 6, 33, 11, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Size = 11;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Reçete Türü";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 6, 64, 11, false);
                    NewField131.Name = "NewField131";
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Size = 11;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Günlük Reçete Nu.";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 6, 105, 11, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Size = 11;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Hasta Adı Soyadı";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 6, 126, 11, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311.TextFont.Size = 11;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"Protokol Nu.";

                    NewField111311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 6, 170, 11, false);
                    NewField111311.Name = "NewField111311";
                    NewField111311.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField111311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111311.TextFont.Size = 11;
                    NewField111311.TextFont.Bold = true;
                    NewField111311.TextFont.CharSet = 162;
                    NewField111311.Value = @"Ücret";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 6, 149, 11, false);
                    NewField5.Name = "NewField5";
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Size = 11;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Karantina Nu.";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 11, 170, 11, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ExternalPharmacyPrescriptionTransaction.GetPrescriptionReportQuery_Class dataset_GetPrescriptionReportQuery = ParentGroup.rsGroup.GetCurrentRecord<ExternalPharmacyPrescriptionTransaction.GetPrescriptionReportQuery_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    PharmacyName.CalcValue = (dataset_GetPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetPrescriptionReportQuery.Pharmacy) : "");
                    NewField3.CalcValue = NewField3.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField111311.CalcValue = NewField111311.Value;
                    NewField5.CalcValue = NewField5.Value;
                    return new TTReportObject[] { NewField1,NewField2,PharmacyName,NewField3,NewField13,NewField131,NewField1131,NewField11311,NewField111311,NewField5};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public PrescriptionDistributeReport MyParentReport
                {
                    get { return (PrescriptionDistributeReport)ParentReport; }
                }
                
                public TTReportField TotalPrice;
                public TTReportField NewField4; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    RepeatCount = 0;
                    
                    TotalPrice = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 1, 170, 6, false);
                    TotalPrice.Name = "TotalPrice";
                    TotalPrice.FieldType = ReportFieldTypeEnum.ftVariable;
                    TotalPrice.TextFormat = @"#,##0.#0";
                    TotalPrice.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TotalPrice.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TotalPrice.Value = @"{@sumof(Price)@}";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 1, 146, 6, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Toplam Ücret:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ExternalPharmacyPrescriptionTransaction.GetPrescriptionReportQuery_Class dataset_GetPrescriptionReportQuery = ParentGroup.rsGroup.GetCurrentRecord<ExternalPharmacyPrescriptionTransaction.GetPrescriptionReportQuery_Class>(0);
                    TotalPrice.CalcValue = ParentGroup.FieldSums["Price"].Value.ToString();;
                    NewField4.CalcValue = NewField4.Value;
                    return new TTReportObject[] { TotalPrice,NewField4};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public PrescriptionDistributeReport MyParentReport
            {
                get { return (PrescriptionDistributeReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField OrderNO { get {return Body().OrderNO;} }
            public TTReportField PrescriptionType { get {return Body().PrescriptionType;} }
            public TTReportField PrescriptionNO { get {return Body().PrescriptionNO;} }
            public TTReportField NameSurname { get {return Body().NameSurname;} }
            public TTReportField ProtocolNO { get {return Body().ProtocolNO;} }
            public TTReportField Price { get {return Body().Price;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField QuaratineNO { get {return Body().QuaratineNO;} }
            public TTReportField PRESCRIPTION { get {return Body().PRESCRIPTION;} }
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

                ExternalPharmacyPrescriptionTransaction.GetPrescriptionReportQuery_Class dataSet_GetPrescriptionReportQuery = ParentGroup.rsGroup.GetCurrentRecord<ExternalPharmacyPrescriptionTransaction.GetPrescriptionReportQuery_Class>(0);    
                return new object[] {(dataSet_GetPrescriptionReportQuery==null ? null : dataSet_GetPrescriptionReportQuery.Pharmacy)};
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
                public PrescriptionDistributeReport MyParentReport
                {
                    get { return (PrescriptionDistributeReport)ParentReport; }
                }
                
                public TTReportField OrderNO;
                public TTReportField PrescriptionType;
                public TTReportField PrescriptionNO;
                public TTReportField NameSurname;
                public TTReportField ProtocolNO;
                public TTReportField Price;
                public TTReportShape NewLine1;
                public TTReportField QuaratineNO;
                public TTReportField PRESCRIPTION; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    OrderNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 10, 6, false);
                    OrderNO.Name = "OrderNO";
                    OrderNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    OrderNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OrderNO.Value = @" {@groupcounter@}";

                    PrescriptionType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 33, 6, false);
                    PrescriptionType.Name = "PrescriptionType";
                    PrescriptionType.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrescriptionType.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PrescriptionType.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrescriptionType.Value = @"";

                    PrescriptionNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 34, 1, 64, 6, false);
                    PrescriptionNO.Name = "PrescriptionNO";
                    PrescriptionNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrescriptionNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PrescriptionNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrescriptionNO.Value = @"{#PARTB.PRESCRIPTIONNO#}";

                    NameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 1, 105, 6, false);
                    NameSurname.Name = "NameSurname";
                    NameSurname.FieldType = ReportFieldTypeEnum.ftVariable;
                    NameSurname.CaseFormat = CaseFormatEnum.fcNameSurname;
                    NameSurname.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NameSurname.Value = @"{#PARTB.PATIENTNAME#}";

                    ProtocolNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 1, 126, 6, false);
                    ProtocolNO.Name = "ProtocolNO";
                    ProtocolNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ProtocolNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    ProtocolNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ProtocolNO.Value = @"{#PARTB.PATIENTPROTOCOLNO#}";

                    Price = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 1, 170, 6, false);
                    Price.Name = "Price";
                    Price.FieldType = ReportFieldTypeEnum.ftVariable;
                    Price.TextFormat = @"#,##0.#0";
                    Price.HorzAlign = HorizontalAlignmentEnum.haRight;
                    Price.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Price.Value = @"{#PARTB.PRICE#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 170, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    QuaratineNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 127, 1, 149, 6, false);
                    QuaratineNO.Name = "QuaratineNO";
                    QuaratineNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    QuaratineNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    QuaratineNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    QuaratineNO.Value = @"{#PARTB.PATIENTQUARANTINENO#}";

                    PRESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 181, 2, 206, 7, false);
                    PRESCRIPTION.Name = "PRESCRIPTION";
                    PRESCRIPTION.Visible = EvetHayirEnum.ehHayir;
                    PRESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRESCRIPTION.Value = @"{#PARTB.PRESCRIPTION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ExternalPharmacyPrescriptionTransaction.GetPrescriptionReportQuery_Class dataset_GetPrescriptionReportQuery = MyParentReport.PARTB.rsGroup.GetCurrentRecord<ExternalPharmacyPrescriptionTransaction.GetPrescriptionReportQuery_Class>(0);
                    OrderNO.CalcValue = @" " + ParentGroup.GroupCounter.ToString();
                    PrescriptionType.CalcValue = @"";
                    PrescriptionNO.CalcValue = (dataset_GetPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetPrescriptionReportQuery.PrescriptionNO) : "");
                    NameSurname.CalcValue = (dataset_GetPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetPrescriptionReportQuery.PatientName) : "");
                    ProtocolNO.CalcValue = (dataset_GetPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetPrescriptionReportQuery.PatientProtocolNo) : "");
                    Price.CalcValue = (dataset_GetPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetPrescriptionReportQuery.Price) : "");
                    QuaratineNO.CalcValue = (dataset_GetPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetPrescriptionReportQuery.PatientQuarantineNo) : "");
                    PRESCRIPTION.CalcValue = (dataset_GetPrescriptionReportQuery != null ? Globals.ToStringCore(dataset_GetPrescriptionReportQuery.Prescription) : "");
                    return new TTReportObject[] { OrderNO,PrescriptionType,PrescriptionNO,NameSurname,ProtocolNO,Price,QuaratineNO,PRESCRIPTION};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string prescriptionID = PRESCRIPTION.CalcValue;
            TTObjectContext ctx = new TTObjectContext(true);
            Prescription prescription = (Prescription)ctx.GetObject(new Guid(prescriptionID), typeof(Prescription));   
            if(prescription is InpatientPrescription)
                PrescriptionType.CalcValue = "Yatan Hasta";
            else if(prescription is OutPatientPrescription)
                PrescriptionType.CalcValue = "Ayaktan Hasta";
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

        public PrescriptionDistributeReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "23:59", "Bitiş Tarihini Seçiniz", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "PRESCRIPTIONDISTRIBUTEREPORT";
            Caption = "Reçete Dağıtım Raporu";
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