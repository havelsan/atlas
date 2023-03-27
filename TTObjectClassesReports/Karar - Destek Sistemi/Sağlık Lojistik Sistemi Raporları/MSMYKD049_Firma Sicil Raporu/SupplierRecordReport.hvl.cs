
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
    /// Firma Sicil Raporu
    /// </summary>
    public partial class SupplierRecordReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public SupplierTypeEnum? SUPPLIERTYPE = (SupplierTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["SupplierTypeEnum"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public SupplierRecordReport MyParentReport
            {
                get { return (SupplierRecordReport)ParentReport; }
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
                public SupplierRecordReport MyParentReport
                {
                    get { return (SupplierRecordReport)ParentReport; }
                }
                
                public TTReportField LOGO;
                public TTReportField ReportName; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 23;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    LOGO.Name = "LOGO";
                    LOGO.Value = @"";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 0, 220, 20, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Name = "Arial";
                    ReportName.TextFont.Size = 12;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"FİRMA SİCİL RAPORU";

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
                public SupplierRecordReport MyParentReport
                {
                    get { return (SupplierRecordReport)ParentReport; }
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
            public SupplierRecordReport MyParentReport
            {
                get { return (SupplierRecordReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
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
                public SupplierRecordReport MyParentReport
                {
                    get { return (SupplierRecordReport)ParentReport; }
                }
                
                public TTReportField NewField2;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportField NewField1111;
                public TTReportShape NewLine1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 1, 211, 7, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Name = "Arial";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"E-Posta";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 20, 7, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Firma Kodu";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 72, 7, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Firma Adı";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 1, 148, 7, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Adres";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 1, 172, 7, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Telefon/Faks";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 1, 91, 7, false);
                    NewField122.Name = "NewField122";
                    NewField122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Name = "Arial";
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Firma Tipi";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 1, 257, 7, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Firma Yetkilisi";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 7, 257, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField2.CalcValue = NewField2.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    return new TTReportObject[] { NewField2,NewField1,NewField11,NewField12,NewField121,NewField122,NewField1111};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public SupplierRecordReport MyParentReport
                {
                    get { return (SupplierRecordReport)ParentReport; }
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
            public SupplierRecordReport MyParentReport
            {
                get { return (SupplierRecordReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SupplierCode { get {return Body().SupplierCode;} }
            public TTReportField SupplierName { get {return Body().SupplierName;} }
            public TTReportField Address { get {return Body().Address;} }
            public TTReportField PhoneAndFax { get {return Body().PhoneAndFax;} }
            public TTReportField SupplierType { get {return Body().SupplierType;} }
            public TTReportField Service { get {return Body().Service;} }
            public TTReportField Email { get {return Body().Email;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
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
                list[0] = new TTReportNqlData<Supplier.GetSupplierRecordReportQuery_Class>("GetSupplierRecordReportQuery", Supplier.GetSupplierRecordReportQuery(((SupplierTypeEnum)TTObjectDefManager.Instance.DataTypes["SupplierTypeEnum"].EnumValueDefs[MyParentReport.RuntimeParameters.SUPPLIERTYPE.ToString()].EnumValue)));
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
                public SupplierRecordReport MyParentReport
                {
                    get { return (SupplierRecordReport)ParentReport; }
                }
                
                public TTReportField SupplierCode;
                public TTReportField SupplierName;
                public TTReportField Address;
                public TTReportField PhoneAndFax;
                public TTReportField SupplierType;
                public TTReportField Service;
                public TTReportField Email;
                public TTReportShape NewLine1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 12;
                    RepeatCount = 0;
                    
                    SupplierCode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 20, 12, false);
                    SupplierCode.Name = "SupplierCode";
                    SupplierCode.DrawStyle = DrawStyleConstants.vbSolid;
                    SupplierCode.FieldType = ReportFieldTypeEnum.ftVariable;
                    SupplierCode.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SupplierCode.MultiLine = EvetHayirEnum.ehEvet;
                    SupplierCode.WordBreak = EvetHayirEnum.ehEvet;
                    SupplierCode.TextFont.Name = "Arial";
                    SupplierCode.TextFont.Size = 9;
                    SupplierCode.TextFont.CharSet = 162;
                    SupplierCode.Value = @"{#CODE#}";

                    SupplierName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 72, 12, false);
                    SupplierName.Name = "SupplierName";
                    SupplierName.DrawStyle = DrawStyleConstants.vbSolid;
                    SupplierName.FieldType = ReportFieldTypeEnum.ftVariable;
                    SupplierName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SupplierName.MultiLine = EvetHayirEnum.ehEvet;
                    SupplierName.WordBreak = EvetHayirEnum.ehEvet;
                    SupplierName.TextFont.Name = "Arial";
                    SupplierName.TextFont.Size = 9;
                    SupplierName.TextFont.CharSet = 162;
                    SupplierName.Value = @"{#NAME#}";

                    Address = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 0, 148, 12, false);
                    Address.Name = "Address";
                    Address.DrawStyle = DrawStyleConstants.vbSolid;
                    Address.FieldType = ReportFieldTypeEnum.ftVariable;
                    Address.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Address.MultiLine = EvetHayirEnum.ehEvet;
                    Address.WordBreak = EvetHayirEnum.ehEvet;
                    Address.TextFont.Name = "Arial";
                    Address.TextFont.Size = 9;
                    Address.TextFont.CharSet = 162;
                    Address.Value = @"{#ADDRESS#}";

                    PhoneAndFax = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 0, 172, 12, false);
                    PhoneAndFax.Name = "PhoneAndFax";
                    PhoneAndFax.DrawStyle = DrawStyleConstants.vbSolid;
                    PhoneAndFax.FieldType = ReportFieldTypeEnum.ftVariable;
                    PhoneAndFax.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PhoneAndFax.MultiLine = EvetHayirEnum.ehEvet;
                    PhoneAndFax.WordBreak = EvetHayirEnum.ehEvet;
                    PhoneAndFax.TextFont.Name = "Arial";
                    PhoneAndFax.TextFont.Size = 9;
                    PhoneAndFax.TextFont.CharSet = 162;
                    PhoneAndFax.Value = @"{#TELEPHONE#}
{#FAX#}";

                    SupplierType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 0, 91, 12, false);
                    SupplierType.Name = "SupplierType";
                    SupplierType.DrawStyle = DrawStyleConstants.vbSolid;
                    SupplierType.FieldType = ReportFieldTypeEnum.ftVariable;
                    SupplierType.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SupplierType.MultiLine = EvetHayirEnum.ehEvet;
                    SupplierType.WordBreak = EvetHayirEnum.ehEvet;
                    SupplierType.ObjectDefName = "SupplierTypeEnum";
                    SupplierType.DataMember = "DISPLAYTEXT";
                    SupplierType.TextFont.Name = "Arial";
                    SupplierType.TextFont.Size = 9;
                    SupplierType.TextFont.CharSet = 162;
                    SupplierType.Value = @"{#TYPE#}";

                    Service = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 0, 257, 12, false);
                    Service.Name = "Service";
                    Service.DrawStyle = DrawStyleConstants.vbSolid;
                    Service.FieldType = ReportFieldTypeEnum.ftVariable;
                    Service.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Service.MultiLine = EvetHayirEnum.ehEvet;
                    Service.WordBreak = EvetHayirEnum.ehEvet;
                    Service.TextFont.Name = "Arial";
                    Service.TextFont.Size = 9;
                    Service.TextFont.CharSet = 162;
                    Service.Value = @"{#RELATEDPERSON#}";

                    Email = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 0, 211, 12, false);
                    Email.Name = "Email";
                    Email.DrawStyle = DrawStyleConstants.vbSolid;
                    Email.FieldType = ReportFieldTypeEnum.ftVariable;
                    Email.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Email.MultiLine = EvetHayirEnum.ehEvet;
                    Email.WordBreak = EvetHayirEnum.ehEvet;
                    Email.TextFont.Name = "Arial";
                    Email.TextFont.Size = 9;
                    Email.TextFont.CharSet = 162;
                    Email.Value = @"{#EMAIL#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 12, 257, 12, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Supplier.GetSupplierRecordReportQuery_Class dataset_GetSupplierRecordReportQuery = ParentGroup.rsGroup.GetCurrentRecord<Supplier.GetSupplierRecordReportQuery_Class>(0);
                    SupplierCode.CalcValue = (dataset_GetSupplierRecordReportQuery != null ? Globals.ToStringCore(dataset_GetSupplierRecordReportQuery.Code) : "");
                    SupplierName.CalcValue = (dataset_GetSupplierRecordReportQuery != null ? Globals.ToStringCore(dataset_GetSupplierRecordReportQuery.Name) : "");
                    Address.CalcValue = (dataset_GetSupplierRecordReportQuery != null ? Globals.ToStringCore(dataset_GetSupplierRecordReportQuery.Address) : "");
                    PhoneAndFax.CalcValue = (dataset_GetSupplierRecordReportQuery != null ? Globals.ToStringCore(dataset_GetSupplierRecordReportQuery.Telephone) : "") + @"
" + (dataset_GetSupplierRecordReportQuery != null ? Globals.ToStringCore(dataset_GetSupplierRecordReportQuery.Fax) : "");
                    SupplierType.CalcValue = (dataset_GetSupplierRecordReportQuery != null ? Globals.ToStringCore(dataset_GetSupplierRecordReportQuery.Type) : "");
                    SupplierType.PostFieldValueCalculation();
                    Service.CalcValue = (dataset_GetSupplierRecordReportQuery != null ? Globals.ToStringCore(dataset_GetSupplierRecordReportQuery.RelatedPerson) : "");
                    Email.CalcValue = (dataset_GetSupplierRecordReportQuery != null ? Globals.ToStringCore(dataset_GetSupplierRecordReportQuery.Email) : "");
                    return new TTReportObject[] { SupplierCode,SupplierName,Address,PhoneAndFax,SupplierType,Service,Email};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public SupplierRecordReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("SUPPLIERTYPE", "", "Tedarikçi Tipi", @"", false, true, false, new Guid("84c2a9a5-fc30-48c7-be9d-c56f6dca2edf"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("SUPPLIERTYPE"))
                _runtimeParameters.SUPPLIERTYPE = (SupplierTypeEnum?)(int?)TTObjectDefManager.Instance.DataTypes["SupplierTypeEnum"].ConvertValue(parameters["SUPPLIERTYPE"]);
            Name = "SUPPLIERRECORDREPORT";
            Caption = "Firma Sicil Raporu";
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