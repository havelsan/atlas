
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
    public partial class PrescriptionDistributeReportNew : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string PHARMACYID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string OBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTANEWGroup : TTReportGroup
        {
            public PrescriptionDistributeReportNew MyParentReport
            {
                get { return (PrescriptionDistributeReportNew)ParentReport; }
            }

            new public PARTANEWGroupHeader Header()
            {
                return (PARTANEWGroupHeader)_header;
            }

            new public PARTANEWGroupFooter Footer()
            {
                return (PARTANEWGroupFooter)_footer;
            }

            public TTReportField ReportName { get {return Header().ReportName;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public PARTANEWGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTANEWGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTANEWGroupHeader(this);
                _footer = new PARTANEWGroupFooter(this);

            }

            public partial class PARTANEWGroupHeader : TTReportSection
            {
                public PrescriptionDistributeReportNew MyParentReport
                {
                    get { return (PrescriptionDistributeReportNew)ParentReport; }
                }
                
                public TTReportField ReportName; 
                public PARTANEWGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 22;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, -1, 190, 19, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Size = 15;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"ECZANE BAZINDA REÇETE DAĞITIM RAPORU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName.CalcValue = ReportName.Value;
                    return new TTReportObject[] { ReportName};
                }
            }
            public partial class PARTANEWGroupFooter : TTReportSection
            {
                public PrescriptionDistributeReportNew MyParentReport
                {
                    get { return (PrescriptionDistributeReportNew)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField PageNumber;
                public TTReportField CurrentUser;
                public TTReportShape NewLine11; 
                public PARTANEWGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 35;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 0, 29, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{%PrintDate%}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 0, 193, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, -1, 113, 4, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, -1, 0, 196, 0, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = MyParentReport.PARTANEW.PrintDate.CalcValue;
                    PageNumber.CalcValue = @"Sayfa Nu." + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PageNumber,CurrentUser};
                }
            }

        }

        public PARTANEWGroup PARTANEW;

        public partial class PARTBGroup : TTReportGroup
        {
            public PrescriptionDistributeReportNew MyParentReport
            {
                get { return (PrescriptionDistributeReportNew)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField NewField1113111 { get {return Header().NewField1113111;} }
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
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField ClinicName { get {return Header().ClinicName;} }
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
                list[0] = new TTReportNqlData<PrescriptionDistribute.GetPrescriptionDistributeForERecete_Class>("GetPrescriptionDistributeForERecete", PrescriptionDistribute.GetPrescriptionDistributeForERecete((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.PHARMACYID),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.OBJECTID)));
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
                public PrescriptionDistributeReportNew MyParentReport
                {
                    get { return (PrescriptionDistributeReportNew)ParentReport; }
                }
                
                public TTReportField NewField1113111;
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
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField ClinicName; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 27;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1113111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 21, 174, 26, false);
                    NewField1113111.Name = "NewField1113111";
                    NewField1113111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1113111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1113111.TextFont.Size = 11;
                    NewField1113111.TextFont.Bold = true;
                    NewField1113111.TextFont.CharSet = 162;
                    NewField1113111.Value = @"E-Reçete No";

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

                    PharmacyName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 190, 6, false);
                    PharmacyName.Name = "PharmacyName";
                    PharmacyName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PharmacyName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PharmacyName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PharmacyName.NoClip = EvetHayirEnum.ehEvet;
                    PharmacyName.ObjectDefName = "ExternalPharmacy";
                    PharmacyName.DataMember = "NAME";
                    PharmacyName.TextFont.CharSet = 162;
                    PharmacyName.Value = @"{@PHARMACYID@}";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 21, 10, 26, false);
                    NewField3.Name = "NewField3";
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Size = 11;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"S. Nu.";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 21, 34, 26, false);
                    NewField13.Name = "NewField13";
                    NewField13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13.TextFont.Size = 11;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Reçete Türü";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 21, 66, 26, false);
                    NewField131.Name = "NewField131";
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Size = 11;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"TC Kimlik No";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 21, 105, 26, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Size = 11;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Hasta Adı Soyadı";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 21, 126, 26, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11311.TextFont.Size = 11;
                    NewField11311.TextFont.Bold = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"Protokol Nu.";

                    NewField111311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 21, 194, 26, false);
                    NewField111311.Name = "NewField111311";
                    NewField111311.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111311.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111311.TextFont.Size = 11;
                    NewField111311.TextFont.Bold = true;
                    NewField111311.TextFont.CharSet = 162;
                    NewField111311.Value = @"Ücret";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 21, 150, 26, false);
                    NewField5.Name = "NewField5";
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField5.TextFont.Size = 11;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Karantina Nu.";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, -3, 27, 196, 27, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 8, 18, 13, false);
                    NewField11.Name = "NewField11";
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Klinik İsmi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 8, 19, 13, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @":";

                    ClinicName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 8, 191, 13, false);
                    ClinicName.Name = "ClinicName";
                    ClinicName.FieldType = ReportFieldTypeEnum.ftVariable;
                    ClinicName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ClinicName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ClinicName.NoClip = EvetHayirEnum.ehEvet;
                    ClinicName.TextFont.CharSet = 162;
                    ClinicName.Value = @"{#CLINICNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrescriptionDistribute.GetPrescriptionDistributeForERecete_Class dataset_GetPrescriptionDistributeForERecete = ParentGroup.rsGroup.GetCurrentRecord<PrescriptionDistribute.GetPrescriptionDistributeForERecete_Class>(0);
                    NewField1113111.CalcValue = NewField1113111.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    PharmacyName.CalcValue = MyParentReport.RuntimeParameters.PHARMACYID.ToString();
                    PharmacyName.PostFieldValueCalculation();
                    NewField3.CalcValue = NewField3.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField111311.CalcValue = NewField111311.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    ClinicName.CalcValue = (dataset_GetPrescriptionDistributeForERecete != null ? Globals.ToStringCore(dataset_GetPrescriptionDistributeForERecete.Clinicname) : "");
                    return new TTReportObject[] { NewField1113111,NewField1,NewField2,PharmacyName,NewField3,NewField13,NewField131,NewField1131,NewField11311,NewField111311,NewField5,NewField11,NewField12,ClinicName};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public PrescriptionDistributeReportNew MyParentReport
                {
                    get { return (PrescriptionDistributeReportNew)ParentReport; }
                }
                
                public TTReportField TotalPrice;
                public TTReportField NewField4; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 8;
                    RepeatCount = 0;
                    
                    TotalPrice = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 1, 194, 7, false);
                    TotalPrice.Name = "TotalPrice";
                    TotalPrice.FieldType = ReportFieldTypeEnum.ftVariable;
                    TotalPrice.TextFormat = @"#,##0.#0";
                    TotalPrice.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TotalPrice.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TotalPrice.Value = @"{@sumof(PRICE)@}";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 1, 170, 6, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Toplam Ücret:";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrescriptionDistribute.GetPrescriptionDistributeForERecete_Class dataset_GetPrescriptionDistributeForERecete = ParentGroup.rsGroup.GetCurrentRecord<PrescriptionDistribute.GetPrescriptionDistributeForERecete_Class>(0);
                    TotalPrice.CalcValue = ParentGroup.FieldSums["PRICE"].Value.ToString();;
                    NewField4.CalcValue = NewField4.Value;
                    return new TTReportObject[] { TotalPrice,NewField4};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public PrescriptionDistributeReportNew MyParentReport
            {
                get { return (PrescriptionDistributeReportNew)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField UniqueRefNo { get {return Body().UniqueRefNo;} }
            public TTReportField PrescriptionType { get {return Body().PrescriptionType;} }
            public TTReportField NameSurname { get {return Body().NameSurname;} }
            public TTReportField QuaratineNO { get {return Body().QuaratineNO;} }
            public TTReportField ProtocolNO { get {return Body().ProtocolNO;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
            public TTReportField ERECETENO { get {return Body().ERECETENO;} }
            public TTReportField OrderNO1 { get {return Body().OrderNO1;} }
            public TTReportField PRESCRIPTIONID { get {return Body().PRESCRIPTIONID;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public PrescriptionDistributeReportNew MyParentReport
                {
                    get { return (PrescriptionDistributeReportNew)ParentReport; }
                }
                
                public TTReportField UniqueRefNo;
                public TTReportField PrescriptionType;
                public TTReportField NameSurname;
                public TTReportField QuaratineNO;
                public TTReportField ProtocolNO;
                public TTReportField PRICE;
                public TTReportField ERECETENO;
                public TTReportField OrderNO1;
                public TTReportField PRESCRIPTIONID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    UniqueRefNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 1, 66, 6, false);
                    UniqueRefNo.Name = "UniqueRefNo";
                    UniqueRefNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    UniqueRefNo.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UniqueRefNo.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UniqueRefNo.Value = @"{#PARTB.UNIQUEREFNO#}";

                    PrescriptionType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 33, 6, false);
                    PrescriptionType.Name = "PrescriptionType";
                    PrescriptionType.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrescriptionType.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrescriptionType.Value = @"";

                    NameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 1, 105, 6, false);
                    NameSurname.Name = "NameSurname";
                    NameSurname.FieldType = ReportFieldTypeEnum.ftVariable;
                    NameSurname.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NameSurname.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NameSurname.Value = @"{#PARTB.PATIENTNAME#}";

                    QuaratineNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 128, 1, 150, 6, false);
                    QuaratineNO.Name = "QuaratineNO";
                    QuaratineNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    QuaratineNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    QuaratineNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    QuaratineNO.Value = @"{#PARTB.PATIENTQUARANTINENO#}";

                    ProtocolNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 1, 126, 6, false);
                    ProtocolNO.Name = "ProtocolNO";
                    ProtocolNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ProtocolNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ProtocolNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ProtocolNO.Value = @"{#PARTB.PATIENTPROTOCOLNO#}";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 1, 194, 6, false);
                    PRICE.Name = "PRICE";
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PRICE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PRICE.Value = @"{#PARTB.PRICE#}";

                    ERECETENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 1, 174, 6, false);
                    ERECETENO.Name = "ERECETENO";
                    ERECETENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ERECETENO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ERECETENO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ERECETENO.Value = @"{#PARTB.ERECETENO#}";

                    OrderNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 1, 10, 6, false);
                    OrderNO1.Name = "OrderNO1";
                    OrderNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    OrderNO1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OrderNO1.Value = @"{@groupcounter@}";

                    PRESCRIPTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 1, 239, 6, false);
                    PRESCRIPTIONID.Name = "PRESCRIPTIONID";
                    PRESCRIPTIONID.Visible = EvetHayirEnum.ehHayir;
                    PRESCRIPTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRESCRIPTIONID.Value = @"{#PARTB.PRESCRIPTIONID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrescriptionDistribute.GetPrescriptionDistributeForERecete_Class dataset_GetPrescriptionDistributeForERecete = MyParentReport.PARTB.rsGroup.GetCurrentRecord<PrescriptionDistribute.GetPrescriptionDistributeForERecete_Class>(0);
                    UniqueRefNo.CalcValue = (dataset_GetPrescriptionDistributeForERecete != null ? Globals.ToStringCore(dataset_GetPrescriptionDistributeForERecete.UniqueRefNo) : "");
                    PrescriptionType.CalcValue = @"";
                    NameSurname.CalcValue = (dataset_GetPrescriptionDistributeForERecete != null ? Globals.ToStringCore(dataset_GetPrescriptionDistributeForERecete.PatientName) : "");
                    QuaratineNO.CalcValue = (dataset_GetPrescriptionDistributeForERecete != null ? Globals.ToStringCore(dataset_GetPrescriptionDistributeForERecete.PatientQuarantineNo) : "");
                    ProtocolNO.CalcValue = (dataset_GetPrescriptionDistributeForERecete != null ? Globals.ToStringCore(dataset_GetPrescriptionDistributeForERecete.PatientProtocolNo) : "");
                    PRICE.CalcValue = (dataset_GetPrescriptionDistributeForERecete != null ? Globals.ToStringCore(dataset_GetPrescriptionDistributeForERecete.Price) : "");
                    ERECETENO.CalcValue = (dataset_GetPrescriptionDistributeForERecete != null ? Globals.ToStringCore(dataset_GetPrescriptionDistributeForERecete.EReceteNo) : "");
                    OrderNO1.CalcValue = ParentGroup.GroupCounter.ToString();
                    PRESCRIPTIONID.CalcValue = (dataset_GetPrescriptionDistributeForERecete != null ? Globals.ToStringCore(dataset_GetPrescriptionDistributeForERecete.Prescriptionid) : "");
                    return new TTReportObject[] { UniqueRefNo,PrescriptionType,NameSurname,QuaratineNO,ProtocolNO,PRICE,ERECETENO,OrderNO1,PRESCRIPTIONID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    string prescriptionID = PRESCRIPTIONID.CalcValue;
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

        public PrescriptionDistributeReportNew()
        {
            PARTANEW = new PARTANEWGroup(this,"PARTANEW");
            PARTB = new PARTBGroup(PARTANEW,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("PHARMACYID", "", "Ezcane ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("OBJECTID", "", "ObjectID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("PHARMACYID"))
                _runtimeParameters.PHARMACYID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["PHARMACYID"]);
            if (parameters.ContainsKey("OBJECTID"))
                _runtimeParameters.OBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["OBJECTID"]);
            Name = "PRESCRIPTIONDISTRIBUTEREPORTNEW";
            Caption = "Reçete Dağıtım Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 10;
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