
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
    /// Muhasebe Yetkilisi Mutemedi Alındısı İade Raporu
    /// </summary>
    public partial class ReceiptBackReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public ReceiptBackReport MyParentReport
            {
                get { return (ReceiptBackReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
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
                public ReceiptBackReport MyParentReport
                {
                    get { return (ReceiptBackReport)ParentReport; }
                }
                 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public ReceiptBackReport MyParentReport
                {
                    get { return (ReceiptBackReport)ParentReport; }
                }
                
                public TTReportShape NewLine1111;
                public TTReportField CURRENTUSER;
                public TTReportField PageNumber;
                public TTReportField PrintDate; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 1, 202, 1, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 2, 140, 7, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.TextFont.CharSet = 162;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 2, 202, 7, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 2, 37, 7, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdatetime@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    CURRENTUSER.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PageNumber,PrintDate,CURRENTUSER};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class PARTAGroup : TTReportGroup
        {
            public ReceiptBackReport MyParentReport
            {
                get { return (ReceiptBackReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField CASHOFFICENAME { get {return Header().CASHOFFICENAME;} }
            public TTReportField REASONOFRETURN { get {return Header().REASONOFRETURN;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField CASHOFFICELBL { get {return Header().CASHOFFICELBL;} }
            public TTReportField CASHIERLBL { get {return Header().CASHIERLBL;} }
            public TTReportField NewField1123 { get {return Header().NewField1123;} }
            public TTReportField NewField13211 { get {return Header().NewField13211;} }
            public TTReportField NewField112211 { get {return Header().NewField112211;} }
            public TTReportField NewField112212 { get {return Header().NewField112212;} }
            public TTReportField NewField112213 { get {return Header().NewField112213;} }
            public TTReportField NewField112214 { get {return Header().NewField112214;} }
            public TTReportField CASHIER { get {return Header().CASHIER;} }
            public TTReportField RETURNDATE { get {return Header().RETURNDATE;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportField CASHOFFICE { get {return Header().CASHOFFICE;} }
            public TTReportField NewField181 { get {return Footer().NewField181;} }
            public TTReportField NewField1312211 { get {return Footer().NewField1312211;} }
            public TTReportField RETURNTOTALPRICE { get {return Footer().RETURNTOTALPRICE;} }
            public TTReportField PATIENTNAMESURNAME { get {return Footer().PATIENTNAMESURNAME;} }
            public TTReportField NewField11211 { get {return Footer().NewField11211;} }
            public TTReportField NewField1112211 { get {return Footer().NewField1112211;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ReceiptBack.ReceiptBackReportQuery_Class>("ReceiptBackReportQuery", ReceiptBack.ReceiptBackReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public ReceiptBackReport MyParentReport
                {
                    get { return (ReceiptBackReport)ParentReport; }
                }
                
                public TTReportField CASHOFFICENAME;
                public TTReportField REASONOFRETURN;
                public TTReportField NewField111;
                public TTReportField CASHOFFICELBL;
                public TTReportField CASHIERLBL;
                public TTReportField NewField1123;
                public TTReportField NewField13211;
                public TTReportField NewField112211;
                public TTReportField NewField112212;
                public TTReportField NewField112213;
                public TTReportField NewField112214;
                public TTReportField CASHIER;
                public TTReportField RETURNDATE;
                public TTReportField NewField16;
                public TTReportField NewField18;
                public TTReportField NewField17;
                public TTReportShape NewLine111;
                public TTReportField CASHOFFICE; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 64;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    CASHOFFICENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 28, 202, 33, false);
                    CASHOFFICENAME.Name = "CASHOFFICENAME";
                    CASHOFFICENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICENAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CASHOFFICENAME.TextFont.CharSet = 162;
                    CASHOFFICENAME.Value = @"{#CASHOFFICENAME#}";

                    REASONOFRETURN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 43, 202, 53, false);
                    REASONOFRETURN.Name = "REASONOFRETURN";
                    REASONOFRETURN.FieldType = ReportFieldTypeEnum.ftVariable;
                    REASONOFRETURN.TextFont.CharSet = 162;
                    REASONOFRETURN.Value = @"{#REASONOFRETURN#}";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 32, 11, 184, 19, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"MUHASEBE YETKİLİSİ MUTEMEDİ ALINDISI İADE RAPORU";

                    CASHOFFICELBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 28, 52, 33, false);
                    CASHOFFICELBL.Name = "CASHOFFICELBL";
                    CASHOFFICELBL.TextFont.Bold = true;
                    CASHOFFICELBL.TextFont.CharSet = 162;
                    CASHOFFICELBL.Value = @"Muhasebe Yetkilisi Mutemetliği";

                    CASHIERLBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 33, 52, 38, false);
                    CASHIERLBL.Name = "CASHIERLBL";
                    CASHIERLBL.TextFont.Bold = true;
                    CASHIERLBL.TextFont.CharSet = 162;
                    CASHIERLBL.Value = @"Muhasebe Yetkilisi Mutemedi Adı";

                    NewField1123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 38, 52, 43, false);
                    NewField1123.Name = "NewField1123";
                    NewField1123.TextFont.Bold = true;
                    NewField1123.TextFont.CharSet = 162;
                    NewField1123.Value = @"İade Tarihi";

                    NewField13211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 43, 52, 48, false);
                    NewField13211.Name = "NewField13211";
                    NewField13211.TextFont.Bold = true;
                    NewField13211.TextFont.CharSet = 162;
                    NewField13211.Value = @"İade Sebebi";

                    NewField112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 28, 54, 33, false);
                    NewField112211.Name = "NewField112211";
                    NewField112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112211.TextFont.Bold = true;
                    NewField112211.TextFont.CharSet = 162;
                    NewField112211.Value = @":";

                    NewField112212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 33, 54, 38, false);
                    NewField112212.Name = "NewField112212";
                    NewField112212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112212.TextFont.Bold = true;
                    NewField112212.TextFont.CharSet = 162;
                    NewField112212.Value = @":";

                    NewField112213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 38, 54, 43, false);
                    NewField112213.Name = "NewField112213";
                    NewField112213.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112213.TextFont.Bold = true;
                    NewField112213.TextFont.CharSet = 162;
                    NewField112213.Value = @":";

                    NewField112214 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 43, 54, 48, false);
                    NewField112214.Name = "NewField112214";
                    NewField112214.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112214.TextFont.Bold = true;
                    NewField112214.TextFont.CharSet = 162;
                    NewField112214.Value = @":";

                    CASHIER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 33, 202, 38, false);
                    CASHIER.Name = "CASHIER";
                    CASHIER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CASHIER.TextFont.CharSet = 162;
                    CASHIER.Value = @"{#CASHIER#}";

                    RETURNDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 38, 99, 43, false);
                    RETURNDATE.Name = "RETURNDATE";
                    RETURNDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RETURNDATE.CaseFormat = CaseFormatEnum.fcUpperCase;
                    RETURNDATE.TextFormat = @"Short Date";
                    RETURNDATE.TextFont.CharSet = 162;
                    RETURNDATE.Value = @"{#DOCUMENTDATE#}";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 58, 26, 62, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"İşlem Kodu";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 58, 202, 62, false);
                    NewField18.Name = "NewField18";
                    NewField18.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @"İade Tutarı";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 58, 178, 62, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"İşlem Açıklaması";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 63, 202, 63, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    CASHOFFICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 30, 237, 35, false);
                    CASHOFFICE.Name = "CASHOFFICE";
                    CASHOFFICE.Visible = EvetHayirEnum.ehHayir;
                    CASHOFFICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHOFFICE.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CASHOFFICE.TextFont.CharSet = 162;
                    CASHOFFICE.Value = @"{#CASHOFFICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReceiptBack.ReceiptBackReportQuery_Class dataset_ReceiptBackReportQuery = ParentGroup.rsGroup.GetCurrentRecord<ReceiptBack.ReceiptBackReportQuery_Class>(0);
                    CASHOFFICENAME.CalcValue = (dataset_ReceiptBackReportQuery != null ? Globals.ToStringCore(dataset_ReceiptBackReportQuery.CashOfficeName) : "");
                    REASONOFRETURN.CalcValue = (dataset_ReceiptBackReportQuery != null ? Globals.ToStringCore(dataset_ReceiptBackReportQuery.ReasonOfReturn) : "");
                    NewField111.CalcValue = NewField111.Value;
                    CASHOFFICELBL.CalcValue = CASHOFFICELBL.Value;
                    CASHIERLBL.CalcValue = CASHIERLBL.Value;
                    NewField1123.CalcValue = NewField1123.Value;
                    NewField13211.CalcValue = NewField13211.Value;
                    NewField112211.CalcValue = NewField112211.Value;
                    NewField112212.CalcValue = NewField112212.Value;
                    NewField112213.CalcValue = NewField112213.Value;
                    NewField112214.CalcValue = NewField112214.Value;
                    CASHIER.CalcValue = (dataset_ReceiptBackReportQuery != null ? Globals.ToStringCore(dataset_ReceiptBackReportQuery.Cashier) : "");
                    RETURNDATE.CalcValue = (dataset_ReceiptBackReportQuery != null ? Globals.ToStringCore(dataset_ReceiptBackReportQuery.DocumentDate) : "");
                    NewField16.CalcValue = NewField16.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField17.CalcValue = NewField17.Value;
                    CASHOFFICE.CalcValue = (dataset_ReceiptBackReportQuery != null ? Globals.ToStringCore(dataset_ReceiptBackReportQuery.CashOffice) : "");
                    return new TTReportObject[] { CASHOFFICENAME,REASONOFRETURN,NewField111,CASHOFFICELBL,CASHIERLBL,NewField1123,NewField13211,NewField112211,NewField112212,NewField112213,NewField112214,CASHIER,RETURNDATE,NewField16,NewField18,NewField17,CASHOFFICE};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    string cashOfficeObjectID = CASHOFFICE.CalcValue;
            
            TTObjectContext objectContext = new TTObjectContext(true);
            CashOfficeDefinition cashOffice = (CashOfficeDefinition)objectContext.GetObject(new Guid(cashOfficeObjectID),"CashOfficeDefinition");
            
            if(cashOffice.Type == CashOfficeTypeEnum.CashOffice)
            {
                CASHOFFICELBL.CalcValue = "Muhasebe Yetkilisi Mutemetliği";
                CASHIERLBL.CalcValue = "Muhasebe Yetkilisi Mutemedi Adı";
            }
            else if (cashOffice.Type == CashOfficeTypeEnum.CashOffice)
            {
                CASHOFFICELBL.CalcValue = "Vezne Adı";
                CASHIERLBL.CalcValue = "Vezne Memuru Adı";
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public ReceiptBackReport MyParentReport
                {
                    get { return (ReceiptBackReport)ParentReport; }
                }
                
                public TTReportField NewField181;
                public TTReportField NewField1312211;
                public TTReportField RETURNTOTALPRICE;
                public TTReportField PATIENTNAMESURNAME;
                public TTReportField NewField11211;
                public TTReportField NewField1112211;
                public TTReportShape NewLine1111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 31;
                    RepeatCount = 0;
                    
                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 148, 4, 175, 9, false);
                    NewField181.Name = "NewField181";
                    NewField181.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField181.TextFont.Bold = true;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @"Toplam İade Tutarı";

                    NewField1312211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 4, 178, 9, false);
                    NewField1312211.Name = "NewField1312211";
                    NewField1312211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1312211.TextFont.Bold = true;
                    NewField1312211.TextFont.CharSet = 162;
                    NewField1312211.Value = @":";

                    RETURNTOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 4, 202, 9, false);
                    RETURNTOTALPRICE.Name = "RETURNTOTALPRICE";
                    RETURNTOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RETURNTOTALPRICE.TextFormat = @"#,##0.#0";
                    RETURNTOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RETURNTOTALPRICE.TextFont.CharSet = 162;
                    RETURNTOTALPRICE.Value = @"{#RETURNTOTALPRICE#}";

                    PATIENTNAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 18, 202, 23, false);
                    PATIENTNAMESURNAME.Name = "PATIENTNAMESURNAME";
                    PATIENTNAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAMESURNAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PATIENTNAMESURNAME.TextFont.CharSet = 162;
                    PATIENTNAMESURNAME.Value = @"{#PATIENTNAME#} {#PATIENTSURNAME#}";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 18, 31, 23, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Hasta Adı Soyadı";

                    NewField1112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 18, 33, 23, false);
                    NewField1112211.Name = "NewField1112211";
                    NewField1112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112211.TextFont.Bold = true;
                    NewField1112211.TextFont.CharSet = 162;
                    NewField1112211.Value = @":";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 2, 202, 2, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReceiptBack.ReceiptBackReportQuery_Class dataset_ReceiptBackReportQuery = ParentGroup.rsGroup.GetCurrentRecord<ReceiptBack.ReceiptBackReportQuery_Class>(0);
                    NewField181.CalcValue = NewField181.Value;
                    NewField1312211.CalcValue = NewField1312211.Value;
                    RETURNTOTALPRICE.CalcValue = (dataset_ReceiptBackReportQuery != null ? Globals.ToStringCore(dataset_ReceiptBackReportQuery.ReturnTotalPrice) : "");
                    PATIENTNAMESURNAME.CalcValue = (dataset_ReceiptBackReportQuery != null ? Globals.ToStringCore(dataset_ReceiptBackReportQuery.Patientname) : "") + @" " + (dataset_ReceiptBackReportQuery != null ? Globals.ToStringCore(dataset_ReceiptBackReportQuery.Patientsurname) : "");
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField1112211.CalcValue = NewField1112211.Value;
                    return new TTReportObject[] { NewField181,NewField1312211,RETURNTOTALPRICE,PATIENTNAMESURNAME,NewField11211,NewField1112211};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public ReceiptBackReport MyParentReport
            {
                get { return (ReceiptBackReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField CODE { get {return Body().CODE;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField RETURNPRICE { get {return Body().RETURNPRICE;} }
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
                list[0] = new TTReportNqlData<ReceiptBackDetail.ReceiptBackReportDetailsQuery_Class>("ReceiptBackReportDetailsQuery", ReceiptBackDetail.ReceiptBackReportDetailsQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public ReceiptBackReport MyParentReport
                {
                    get { return (ReceiptBackReport)ParentReport; }
                }
                
                public TTReportField CODE;
                public TTReportField DESCRIPTION;
                public TTReportField RETURNPRICE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 7;
                    RepeatCount = 0;
                    
                    CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 1, 26, 6, false);
                    CODE.Name = "CODE";
                    CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODE.TextFont.CharSet = 162;
                    CODE.Value = @"{#EXTERNALCODE#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 1, 178, 6, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    DESCRIPTION.NoClip = EvetHayirEnum.ehEvet;
                    DESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    DESCRIPTION.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESCRIPTION.TextFont.CharSet = 162;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    RETURNPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 1, 202, 6, false);
                    RETURNPRICE.Name = "RETURNPRICE";
                    RETURNPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RETURNPRICE.TextFormat = @"#,##0.#0";
                    RETURNPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    RETURNPRICE.TextFont.CharSet = 162;
                    RETURNPRICE.Value = @"{#PAYMENTPRICE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReceiptBackDetail.ReceiptBackReportDetailsQuery_Class dataset_ReceiptBackReportDetailsQuery = ParentGroup.rsGroup.GetCurrentRecord<ReceiptBackDetail.ReceiptBackReportDetailsQuery_Class>(0);
                    CODE.CalcValue = (dataset_ReceiptBackReportDetailsQuery != null ? Globals.ToStringCore(dataset_ReceiptBackReportDetailsQuery.ExternalCode) : "");
                    DESCRIPTION.CalcValue = (dataset_ReceiptBackReportDetailsQuery != null ? Globals.ToStringCore(dataset_ReceiptBackReportDetailsQuery.Description) : "");
                    RETURNPRICE.CalcValue = (dataset_ReceiptBackReportDetailsQuery != null ? Globals.ToStringCore(dataset_ReceiptBackReportDetailsQuery.PaymentPrice) : "");
                    return new TTReportObject[] { CODE,DESCRIPTION,RETURNPRICE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ReceiptBackReport()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            PARTA = new PARTAGroup(PARTB,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Action ObjectID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "RECEIPTBACKREPORT";
            Caption = "Muhasebe Yetkilisi Mutemedi Alındısı İade Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
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