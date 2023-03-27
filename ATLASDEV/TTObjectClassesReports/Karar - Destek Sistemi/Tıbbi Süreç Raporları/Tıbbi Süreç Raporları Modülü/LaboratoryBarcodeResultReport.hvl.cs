
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
    /// Laboratuvar Sonuç Raporu
    /// </summary>
    public partial class LaboratoryBarcodeResultReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public long? BARCODEID = (long?)TTObjectDefManager.Instance.DataTypes["Long9"].ConvertValue("");
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class TOPGroup : TTReportGroup
        {
            public LaboratoryBarcodeResultReport MyParentReport
            {
                get { return (LaboratoryBarcodeResultReport)ParentReport; }
            }

            new public TOPGroupHeader Header()
            {
                return (TOPGroupHeader)_header;
            }

            new public TOPGroupFooter Footer()
            {
                return (TOPGroupFooter)_footer;
            }

            public TTReportField OBJECTID1 { get {return Header().OBJECTID1;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportField PrintDate1 { get {return Footer().PrintDate1;} }
            public TTReportField UserName1 { get {return Footer().UserName1;} }
            public TTReportField PageNumber1 { get {return Footer().PageNumber1;} }
            public TOPGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TOPGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TOPGroupHeader(this);
                _footer = new TOPGroupFooter(this);

            }

            public partial class TOPGroupHeader : TTReportSection
            {
                public LaboratoryBarcodeResultReport MyParentReport
                {
                    get { return (LaboratoryBarcodeResultReport)ParentReport; }
                }
                
                public TTReportField OBJECTID1; 
                public TOPGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    OBJECTID1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 0, 20, 5, false);
                    OBJECTID1.Name = "OBJECTID1";
                    OBJECTID1.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID1.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID1.TextFont.Name = "Arial Narrow";
                    OBJECTID1.TextFont.Size = 9;
                    OBJECTID1.TextFont.CharSet = 162;
                    OBJECTID1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    OBJECTID1.CalcValue = @"";
                    return new TTReportObject[] { OBJECTID1};
                }

                public override void RunScript()
                {
#region TOP HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = "";
            
            sObjectID = ((LaboratoryBarcodeResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            
            if(!String.IsNullOrEmpty(sObjectID))
            {
                this.OBJECTID1.CalcValue = sObjectID;
            }
            else
            {
                
                long barcodeID = (long)((LaboratoryBarcodeResultReport)ParentReport).RuntimeParameters.BARCODEID;
                
                
                BindingList<LaboratoryRequest.GetLaboratoryRequestByBarcode_Class> barcodes = LaboratoryRequest.GetLaboratoryRequestByBarcode(context,barcodeID);
                foreach(LaboratoryRequest.GetLaboratoryRequestByBarcode_Class barcode in barcodes)
                {
                    sObjectID = barcode.ObjectID.ToString();
                    break;
                }
                
                this.OBJECTID1.CalcValue = sObjectID;
            }
#endregion TOP HEADER_Script
                }
            }
            public partial class TOPGroupFooter : TTReportSection
            {
                public LaboratoryBarcodeResultReport MyParentReport
                {
                    get { return (LaboratoryBarcodeResultReport)ParentReport; }
                }
                
                public TTReportShape NewLine1;
                public TTReportField PrintDate1;
                public TTReportField UserName1;
                public TTReportField PageNumber1; 
                public TOPGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 7;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 1, 200, 1, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 2, 31, 7, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.TextFormat = @"dd/MM/yyyy HH:mm";
                    PrintDate1.TextFont.Name = "Microsoft Sans Serif";
                    PrintDate1.TextFont.Size = 8;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdatetime@}";

                    UserName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 88, 2, 135, 7, false);
                    UserName1.Name = "UserName1";
                    UserName1.FieldType = ReportFieldTypeEnum.ftExpression;
                    UserName1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UserName1.TextFont.Name = "Microsoft Sans Serif";
                    UserName1.TextFont.Size = 8;
                    UserName1.TextFont.CharSet = 162;
                    UserName1.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    PageNumber1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 2, 200, 7, false);
                    PageNumber1.Name = "PageNumber1";
                    PageNumber1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber1.TextFont.Name = "Microsoft Sans Serif";
                    PageNumber1.TextFont.Size = 8;
                    PageNumber1.TextFont.CharSet = 162;
                    PageNumber1.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    PageNumber1.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    UserName1.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    return new TTReportObject[] { PrintDate1,PageNumber1,UserName1};
                }
            }

        }

        public TOPGroup TOP;

        public partial class HEADERGroup : TTReportGroup
        {
            public LaboratoryBarcodeResultReport MyParentReport
            {
                get { return (LaboratoryBarcodeResultReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField { get {return Header().NewField;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField OBJECTID { get {return Header().OBJECTID;} }
            public TTReportField BarcodeId { get {return Header().BarcodeId;} }
            public TTReportField lblPatientName { get {return Header().lblPatientName;} }
            public TTReportField lblPatientSex { get {return Header().lblPatientSex;} }
            public TTReportField lblPatientAge { get {return Header().lblPatientAge;} }
            public TTReportField lblPatientFatherName { get {return Header().lblPatientFatherName;} }
            public TTReportField lblRequestDoctor { get {return Header().lblRequestDoctor;} }
            public TTReportField lblFromResource { get {return Header().lblFromResource;} }
            public TTReportField lblPreDiagnosis { get {return Header().lblPreDiagnosis;} }
            public TTReportField dotsPatientName { get {return Header().dotsPatientName;} }
            public TTReportField dotsPatientSex { get {return Header().dotsPatientSex;} }
            public TTReportField dotsPatientAge { get {return Header().dotsPatientAge;} }
            public TTReportField dotsPatientFatherName { get {return Header().dotsPatientFatherName;} }
            public TTReportField dotsPreDiagnosis { get {return Header().dotsPreDiagnosis;} }
            public TTReportField dotsRequestDoctor { get {return Header().dotsRequestDoctor;} }
            public TTReportField dotsFromResource { get {return Header().dotsFromResource;} }
            public TTReportField lblPatientStatus { get {return Header().lblPatientStatus;} }
            public TTReportField dotsPatientStatus { get {return Header().dotsPatientStatus;} }
            public TTReportField PatientName { get {return Header().PatientName;} }
            public TTReportField PatientSex { get {return Header().PatientSex;} }
            public TTReportField PatientAge { get {return Header().PatientAge;} }
            public TTReportField PatientFatherName { get {return Header().PatientFatherName;} }
            public TTReportField FromResource { get {return Header().FromResource;} }
            public TTReportField PreDiagnosis { get {return Header().PreDiagnosis;} }
            public TTReportField PatientStatus { get {return Header().PatientStatus;} }
            public TTReportField RequestDoctor { get {return Header().RequestDoctor;} }
            public TTReportField lblBirthPlace { get {return Header().lblBirthPlace;} }
            public TTReportField dotsBirthPlace { get {return Header().dotsBirthPlace;} }
            public TTReportField BirthPlace { get {return Header().BirthPlace;} }
            public TTReportField lblProtocolNo { get {return Header().lblProtocolNo;} }
            public TTReportField dotsProtocolNo { get {return Header().dotsProtocolNo;} }
            public TTReportField ProtocolNo { get {return Header().ProtocolNo;} }
            public TTReportField lblBarcodeId1 { get {return Header().lblBarcodeId1;} }
            public TTReportField dotsBarcodeId1 { get {return Header().dotsBarcodeId1;} }
            public TTReportField lblDash { get {return Header().lblDash;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField ReportDateField { get {return Header().ReportDateField;} }
            public TTReportField lblProtocolNo1 { get {return Header().lblProtocolNo1;} }
            public TTReportField dotsProtocolNo1 { get {return Header().dotsProtocolNo1;} }
            public TTReportField HizmetOzel { get {return Footer().HizmetOzel;} }
            public TTReportField NewField1111 { get {return Footer().NewField1111;} }
            public TTReportField ApprovedBy { get {return Footer().ApprovedBy;} }
            public TTReportField OBJECTID1 { get {return Footer().OBJECTID1;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<LaboratoryRequest.LaboratoryReportNQL_Class>("LaboratoryReportNQL", LaboratoryRequest.LaboratoryReportNQL((string)TTObjectDefManager.Instance.DataTypes["String255"].ConvertValue(MyParentReport.TOP.OBJECTID1.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public LaboratoryBarcodeResultReport MyParentReport
                {
                    get { return (LaboratoryBarcodeResultReport)ParentReport; }
                }
                
                public TTReportField NewField;
                public TTReportField XXXXXXBASLIK;
                public TTReportField OBJECTID;
                public TTReportField BarcodeId;
                public TTReportField lblPatientName;
                public TTReportField lblPatientSex;
                public TTReportField lblPatientAge;
                public TTReportField lblPatientFatherName;
                public TTReportField lblRequestDoctor;
                public TTReportField lblFromResource;
                public TTReportField lblPreDiagnosis;
                public TTReportField dotsPatientName;
                public TTReportField dotsPatientSex;
                public TTReportField dotsPatientAge;
                public TTReportField dotsPatientFatherName;
                public TTReportField dotsPreDiagnosis;
                public TTReportField dotsRequestDoctor;
                public TTReportField dotsFromResource;
                public TTReportField lblPatientStatus;
                public TTReportField dotsPatientStatus;
                public TTReportField PatientName;
                public TTReportField PatientSex;
                public TTReportField PatientAge;
                public TTReportField PatientFatherName;
                public TTReportField FromResource;
                public TTReportField PreDiagnosis;
                public TTReportField PatientStatus;
                public TTReportField RequestDoctor;
                public TTReportField lblBirthPlace;
                public TTReportField dotsBirthPlace;
                public TTReportField BirthPlace;
                public TTReportField lblProtocolNo;
                public TTReportField dotsProtocolNo;
                public TTReportField ProtocolNo;
                public TTReportField lblBarcodeId1;
                public TTReportField dotsBarcodeId1;
                public TTReportField lblDash;
                public TTReportField LOGO;
                public TTReportField ReportDateField;
                public TTReportField lblProtocolNo1;
                public TTReportField dotsProtocolNo1; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 69;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 63, 200, 68, false);
                    NewField.Name = "NewField";
                    NewField.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField.TextFont.Name = "Arial Narrow";
                    NewField.TextFont.Size = 13;
                    NewField.TextFont.Bold = true;
                    NewField.TextFont.CharSet = 162;
                    NewField.Value = @"LABORATUVAR SONUÇ RAPORU";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 1, 157, 24, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Microsoft Sans Serif";
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 49, 231, 54, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.TextFont.Name = "Arial Narrow";
                    OBJECTID.TextFont.Size = 9;
                    OBJECTID.TextFont.CharSet = 162;
                    OBJECTID.Value = @"{%TOP.OBJECTID1%}";

                    BarcodeId = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 26, 200, 31, false);
                    BarcodeId.Name = "BarcodeId";
                    BarcodeId.FieldType = ReportFieldTypeEnum.ftVariable;
                    BarcodeId.TextFormat = @"Long Time";
                    BarcodeId.TextFont.Name = "Microsoft Sans Serif";
                    BarcodeId.TextFont.Size = 9;
                    BarcodeId.TextFont.CharSet = 162;
                    BarcodeId.Value = @"{@BARCODEID@}";

                    lblPatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 26, 28, 31, false);
                    lblPatientName.Name = "lblPatientName";
                    lblPatientName.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientName.TextFont.Size = 9;
                    lblPatientName.TextFont.CharSet = 162;
                    lblPatientName.Value = @"Adı Soyadı";

                    lblPatientSex = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 31, 28, 36, false);
                    lblPatientSex.Name = "lblPatientSex";
                    lblPatientSex.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientSex.TextFont.Size = 9;
                    lblPatientSex.TextFont.CharSet = 162;
                    lblPatientSex.Value = @"Cinsiyeti / Yaşı";

                    lblPatientAge = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 55, 251, 60, false);
                    lblPatientAge.Name = "lblPatientAge";
                    lblPatientAge.Visible = EvetHayirEnum.ehHayir;
                    lblPatientAge.TextFont.Name = "Arial Narrow";
                    lblPatientAge.TextFont.Size = 9;
                    lblPatientAge.TextFont.Bold = true;
                    lblPatientAge.TextFont.CharSet = 162;
                    lblPatientAge.Value = @"Hastanın Yaşı";

                    lblPatientFatherName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 36, 28, 41, false);
                    lblPatientFatherName.Name = "lblPatientFatherName";
                    lblPatientFatherName.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientFatherName.TextFont.Size = 9;
                    lblPatientFatherName.TextFont.CharSet = 162;
                    lblPatientFatherName.Value = @"Baba Adı";

                    lblRequestDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 36, 132, 41, false);
                    lblRequestDoctor.Name = "lblRequestDoctor";
                    lblRequestDoctor.TextFont.Name = "Microsoft Sans Serif";
                    lblRequestDoctor.TextFont.Size = 9;
                    lblRequestDoctor.TextFont.CharSet = 162;
                    lblRequestDoctor.Value = @"İstek Yapan Doktor";

                    lblFromResource = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 31, 132, 36, false);
                    lblFromResource.Name = "lblFromResource";
                    lblFromResource.TextFont.Name = "Microsoft Sans Serif";
                    lblFromResource.TextFont.Size = 9;
                    lblFromResource.TextFont.CharSet = 162;
                    lblFromResource.Value = @"İstek Yapan Birim";

                    lblPreDiagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 51, 28, 56, false);
                    lblPreDiagnosis.Name = "lblPreDiagnosis";
                    lblPreDiagnosis.TextFont.Name = "Microsoft Sans Serif";
                    lblPreDiagnosis.TextFont.Size = 9;
                    lblPreDiagnosis.TextFont.CharSet = 162;
                    lblPreDiagnosis.Value = @"Ön Tanı";

                    dotsPatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 26, 31, 31, false);
                    dotsPatientName.Name = "dotsPatientName";
                    dotsPatientName.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientName.TextFont.Size = 9;
                    dotsPatientName.TextFont.CharSet = 162;
                    dotsPatientName.Value = @":";

                    dotsPatientSex = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 31, 31, 36, false);
                    dotsPatientSex.Name = "dotsPatientSex";
                    dotsPatientSex.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientSex.TextFont.Size = 9;
                    dotsPatientSex.TextFont.CharSet = 162;
                    dotsPatientSex.Value = @":";

                    dotsPatientAge = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 251, 55, 254, 60, false);
                    dotsPatientAge.Name = "dotsPatientAge";
                    dotsPatientAge.Visible = EvetHayirEnum.ehHayir;
                    dotsPatientAge.TextFont.Name = "Arial Narrow";
                    dotsPatientAge.TextFont.Size = 9;
                    dotsPatientAge.TextFont.Bold = true;
                    dotsPatientAge.TextFont.CharSet = 162;
                    dotsPatientAge.Value = @":";

                    dotsPatientFatherName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 36, 31, 41, false);
                    dotsPatientFatherName.Name = "dotsPatientFatherName";
                    dotsPatientFatherName.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientFatherName.TextFont.Size = 9;
                    dotsPatientFatherName.TextFont.CharSet = 162;
                    dotsPatientFatherName.Value = @":";

                    dotsPreDiagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 51, 31, 56, false);
                    dotsPreDiagnosis.Name = "dotsPreDiagnosis";
                    dotsPreDiagnosis.TextFont.Name = "Microsoft Sans Serif";
                    dotsPreDiagnosis.TextFont.Size = 9;
                    dotsPreDiagnosis.TextFont.CharSet = 162;
                    dotsPreDiagnosis.Value = @":";

                    dotsRequestDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 36, 135, 41, false);
                    dotsRequestDoctor.Name = "dotsRequestDoctor";
                    dotsRequestDoctor.TextFont.Name = "Microsoft Sans Serif";
                    dotsRequestDoctor.TextFont.Size = 9;
                    dotsRequestDoctor.TextFont.CharSet = 162;
                    dotsRequestDoctor.Value = @":";

                    dotsFromResource = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 31, 135, 36, false);
                    dotsFromResource.Name = "dotsFromResource";
                    dotsFromResource.TextFont.Name = "Microsoft Sans Serif";
                    dotsFromResource.TextFont.Size = 9;
                    dotsFromResource.TextFont.CharSet = 162;
                    dotsFromResource.Value = @":";

                    lblPatientStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 41, 28, 46, false);
                    lblPatientStatus.Name = "lblPatientStatus";
                    lblPatientStatus.TextFont.Name = "Microsoft Sans Serif";
                    lblPatientStatus.TextFont.Size = 9;
                    lblPatientStatus.TextFont.CharSet = 162;
                    lblPatientStatus.Value = @"Hasta Tipi";

                    dotsPatientStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 41, 31, 46, false);
                    dotsPatientStatus.Name = "dotsPatientStatus";
                    dotsPatientStatus.TextFont.Name = "Microsoft Sans Serif";
                    dotsPatientStatus.TextFont.Size = 9;
                    dotsPatientStatus.TextFont.CharSet = 162;
                    dotsPatientStatus.Value = @":";

                    PatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 26, 93, 31, false);
                    PatientName.Name = "PatientName";
                    PatientName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientName.MultiLine = EvetHayirEnum.ehEvet;
                    PatientName.TextFont.Name = "Microsoft Sans Serif";
                    PatientName.TextFont.Size = 9;
                    PatientName.TextFont.CharSet = 162;
                    PatientName.Value = @"{#PATIENTNAME#} {#SURNAME#}";

                    PatientSex = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 31, 48, 36, false);
                    PatientSex.Name = "PatientSex";
                    PatientSex.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientSex.MultiLine = EvetHayirEnum.ehEvet;
                    PatientSex.ObjectDefName = "SexEnum";
                    PatientSex.DataMember = "DISPLAYTEXT";
                    PatientSex.TextFont.Name = "Microsoft Sans Serif";
                    PatientSex.TextFont.Size = 9;
                    PatientSex.TextFont.CharSet = 162;
                    PatientSex.Value = @"{#SEX#}";

                    PatientAge = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 31, 76, 36, false);
                    PatientAge.Name = "PatientAge";
                    PatientAge.MultiLine = EvetHayirEnum.ehEvet;
                    PatientAge.TextFont.Name = "Microsoft Sans Serif";
                    PatientAge.TextFont.Size = 9;
                    PatientAge.TextFont.CharSet = 162;
                    PatientAge.Value = @"PatientAge";

                    PatientFatherName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 36, 93, 41, false);
                    PatientFatherName.Name = "PatientFatherName";
                    PatientFatherName.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientFatherName.MultiLine = EvetHayirEnum.ehEvet;
                    PatientFatherName.TextFont.Name = "Microsoft Sans Serif";
                    PatientFatherName.TextFont.Size = 9;
                    PatientFatherName.TextFont.CharSet = 162;
                    PatientFatherName.Value = @"{#FATHERNAME#}";

                    FromResource = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 31, 200, 36, false);
                    FromResource.Name = "FromResource";
                    FromResource.FieldType = ReportFieldTypeEnum.ftVariable;
                    FromResource.MultiLine = EvetHayirEnum.ehEvet;
                    FromResource.TextFont.Name = "Microsoft Sans Serif";
                    FromResource.TextFont.Size = 9;
                    FromResource.TextFont.CharSet = 162;
                    FromResource.Value = @"{#FROMRES#}";

                    PreDiagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 51, 200, 62, false);
                    PreDiagnosis.Name = "PreDiagnosis";
                    PreDiagnosis.MultiLine = EvetHayirEnum.ehEvet;
                    PreDiagnosis.NoClip = EvetHayirEnum.ehEvet;
                    PreDiagnosis.WordBreak = EvetHayirEnum.ehEvet;
                    PreDiagnosis.ExpandTabs = EvetHayirEnum.ehEvet;
                    PreDiagnosis.TextFont.Name = "Microsoft Sans Serif";
                    PreDiagnosis.TextFont.Size = 9;
                    PreDiagnosis.TextFont.CharSet = 162;
                    PreDiagnosis.Value = @"PreDiagnosis";

                    PatientStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 41, 93, 46, false);
                    PatientStatus.Name = "PatientStatus";
                    PatientStatus.FieldType = ReportFieldTypeEnum.ftVariable;
                    PatientStatus.TextFormat = @"Long Time";
                    PatientStatus.ObjectDefName = "PatientStatusEnum";
                    PatientStatus.DataMember = "DISPLAYTEXT";
                    PatientStatus.TextFont.Name = "Microsoft Sans Serif";
                    PatientStatus.TextFont.Size = 9;
                    PatientStatus.TextFont.CharSet = 162;
                    PatientStatus.Value = @"{#PATIENTSTATUS#}";

                    RequestDoctor = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 36, 200, 41, false);
                    RequestDoctor.Name = "RequestDoctor";
                    RequestDoctor.FieldType = ReportFieldTypeEnum.ftVariable;
                    RequestDoctor.TextFormat = @"dd/mm/yyyy";
                    RequestDoctor.TextFont.Name = "Microsoft Sans Serif";
                    RequestDoctor.TextFont.Size = 9;
                    RequestDoctor.TextFont.CharSet = 162;
                    RequestDoctor.Value = @"{#REQDOCTORNAME#}";

                    lblBirthPlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 61, 252, 66, false);
                    lblBirthPlace.Name = "lblBirthPlace";
                    lblBirthPlace.Visible = EvetHayirEnum.ehHayir;
                    lblBirthPlace.TextFont.Name = "Arial Narrow";
                    lblBirthPlace.TextFont.Size = 9;
                    lblBirthPlace.TextFont.Bold = true;
                    lblBirthPlace.TextFont.CharSet = 162;
                    lblBirthPlace.Value = @"Doğum Yeri";

                    dotsBirthPlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 251, 61, 254, 66, false);
                    dotsBirthPlace.Name = "dotsBirthPlace";
                    dotsBirthPlace.Visible = EvetHayirEnum.ehHayir;
                    dotsBirthPlace.TextFont.Name = "Arial Narrow";
                    dotsBirthPlace.TextFont.Size = 9;
                    dotsBirthPlace.TextFont.Bold = true;
                    dotsBirthPlace.TextFont.CharSet = 162;
                    dotsBirthPlace.Value = @":";

                    BirthPlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 61, 270, 66, false);
                    BirthPlace.Name = "BirthPlace";
                    BirthPlace.Visible = EvetHayirEnum.ehHayir;
                    BirthPlace.FieldType = ReportFieldTypeEnum.ftVariable;
                    BirthPlace.TextFormat = @"Long Date";
                    BirthPlace.TextFont.Name = "Arial Narrow";
                    BirthPlace.TextFont.Size = 9;
                    BirthPlace.TextFont.CharSet = 162;
                    BirthPlace.Value = @"{#CITYNAME#} - {#TOWNNAME#}";

                    lblProtocolNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 41, 132, 46, false);
                    lblProtocolNo.Name = "lblProtocolNo";
                    lblProtocolNo.TextFont.Name = "Microsoft Sans Serif";
                    lblProtocolNo.TextFont.Size = 9;
                    lblProtocolNo.TextFont.CharSet = 162;
                    lblProtocolNo.Value = @"Protokol No";

                    dotsProtocolNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 41, 135, 46, false);
                    dotsProtocolNo.Name = "dotsProtocolNo";
                    dotsProtocolNo.TextFont.Name = "Microsoft Sans Serif";
                    dotsProtocolNo.TextFont.Size = 9;
                    dotsProtocolNo.TextFont.CharSet = 162;
                    dotsProtocolNo.Value = @":";

                    ProtocolNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 41, 200, 46, false);
                    ProtocolNo.Name = "ProtocolNo";
                    ProtocolNo.FieldType = ReportFieldTypeEnum.ftVariable;
                    ProtocolNo.TextFormat = @"Long Time";
                    ProtocolNo.TextFont.Name = "Microsoft Sans Serif";
                    ProtocolNo.TextFont.Size = 9;
                    ProtocolNo.TextFont.CharSet = 162;
                    ProtocolNo.Value = @"{#PROTOCOLNO#}";

                    lblBarcodeId1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 26, 132, 31, false);
                    lblBarcodeId1.Name = "lblBarcodeId1";
                    lblBarcodeId1.TextFont.Name = "Microsoft Sans Serif";
                    lblBarcodeId1.TextFont.Size = 9;
                    lblBarcodeId1.TextFont.CharSet = 162;
                    lblBarcodeId1.Value = @"Örnek Numarası";

                    dotsBarcodeId1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 26, 135, 31, false);
                    dotsBarcodeId1.Name = "dotsBarcodeId1";
                    dotsBarcodeId1.TextFont.Name = "Microsoft Sans Serif";
                    dotsBarcodeId1.TextFont.Size = 9;
                    dotsBarcodeId1.TextFont.CharSet = 162;
                    dotsBarcodeId1.Value = @":";

                    lblDash = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 31, 52, 36, false);
                    lblDash.Name = "lblDash";
                    lblDash.MultiLine = EvetHayirEnum.ehEvet;
                    lblDash.TextFont.Name = "Microsoft Sans Serif";
                    lblDash.TextFont.Size = 9;
                    lblDash.TextFont.CharSet = 162;
                    lblDash.Value = @"/";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 1, 36, 24, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.CharSet = 1;
                    LOGO.Value = @"";

                    ReportDateField = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 46, 200, 51, false);
                    ReportDateField.Name = "ReportDateField";
                    ReportDateField.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReportDateField.TextFormat = @"dd/MM/yyyy HH:mm";
                    ReportDateField.TextFont.Name = "Microsoft Sans Serif";
                    ReportDateField.TextFont.Size = 9;
                    ReportDateField.TextFont.CharSet = 162;
                    ReportDateField.Value = @"{@printdate@}";

                    lblProtocolNo1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 46, 132, 51, false);
                    lblProtocolNo1.Name = "lblProtocolNo1";
                    lblProtocolNo1.TextFont.Name = "Microsoft Sans Serif";
                    lblProtocolNo1.TextFont.Size = 9;
                    lblProtocolNo1.TextFont.CharSet = 162;
                    lblProtocolNo1.Value = @"Rapor Tarihi";

                    dotsProtocolNo1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 46, 135, 51, false);
                    dotsProtocolNo1.Name = "dotsProtocolNo1";
                    dotsProtocolNo1.TextFont.Name = "Microsoft Sans Serif";
                    dotsProtocolNo1.TextFont.Size = 9;
                    dotsProtocolNo1.TextFont.CharSet = 162;
                    dotsProtocolNo1.Value = @":";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratoryRequest.LaboratoryReportNQL_Class dataset_LaboratoryReportNQL = ParentGroup.rsGroup.GetCurrentRecord<LaboratoryRequest.LaboratoryReportNQL_Class>(0);
                    NewField.CalcValue = NewField.Value;
                    OBJECTID.CalcValue = MyParentReport.TOP.OBJECTID1.CalcValue;
                    BarcodeId.CalcValue = MyParentReport.RuntimeParameters.BARCODEID.ToString();
                    lblPatientName.CalcValue = lblPatientName.Value;
                    lblPatientSex.CalcValue = lblPatientSex.Value;
                    lblPatientAge.CalcValue = lblPatientAge.Value;
                    lblPatientFatherName.CalcValue = lblPatientFatherName.Value;
                    lblRequestDoctor.CalcValue = lblRequestDoctor.Value;
                    lblFromResource.CalcValue = lblFromResource.Value;
                    lblPreDiagnosis.CalcValue = lblPreDiagnosis.Value;
                    dotsPatientName.CalcValue = dotsPatientName.Value;
                    dotsPatientSex.CalcValue = dotsPatientSex.Value;
                    dotsPatientAge.CalcValue = dotsPatientAge.Value;
                    dotsPatientFatherName.CalcValue = dotsPatientFatherName.Value;
                    dotsPreDiagnosis.CalcValue = dotsPreDiagnosis.Value;
                    dotsRequestDoctor.CalcValue = dotsRequestDoctor.Value;
                    dotsFromResource.CalcValue = dotsFromResource.Value;
                    lblPatientStatus.CalcValue = lblPatientStatus.Value;
                    dotsPatientStatus.CalcValue = dotsPatientStatus.Value;
                    PatientName.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Patientname) : "") + @" " + (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Surname) : "");
                    PatientSex.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Sex) : "");
                    PatientSex.PostFieldValueCalculation();
                    PatientAge.CalcValue = PatientAge.Value;
                    PatientFatherName.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.FatherName) : "");
                    FromResource.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Fromres) : "");
                    PreDiagnosis.CalcValue = PreDiagnosis.Value;
                    PatientStatus.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.PatientStatus) : "");
                    PatientStatus.PostFieldValueCalculation();
                    RequestDoctor.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Reqdoctorname) : "");
                    lblBirthPlace.CalcValue = lblBirthPlace.Value;
                    dotsBirthPlace.CalcValue = dotsBirthPlace.Value;
                    BirthPlace.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Cityname) : "") + @" - " + (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.Townname) : "");
                    lblProtocolNo.CalcValue = lblProtocolNo.Value;
                    dotsProtocolNo.CalcValue = dotsProtocolNo.Value;
                    ProtocolNo.CalcValue = (dataset_LaboratoryReportNQL != null ? Globals.ToStringCore(dataset_LaboratoryReportNQL.ProtocolNo) : "");
                    lblBarcodeId1.CalcValue = lblBarcodeId1.Value;
                    dotsBarcodeId1.CalcValue = dotsBarcodeId1.Value;
                    lblDash.CalcValue = lblDash.Value;
                    LOGO.CalcValue = @"";
                    ReportDateField.CalcValue = DateTime.Now.ToShortDateString();
                    lblProtocolNo1.CalcValue = lblProtocolNo1.Value;
                    dotsProtocolNo1.CalcValue = dotsProtocolNo1.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField,OBJECTID,BarcodeId,lblPatientName,lblPatientSex,lblPatientAge,lblPatientFatherName,lblRequestDoctor,lblFromResource,lblPreDiagnosis,dotsPatientName,dotsPatientSex,dotsPatientAge,dotsPatientFatherName,dotsPreDiagnosis,dotsRequestDoctor,dotsFromResource,lblPatientStatus,dotsPatientStatus,PatientName,PatientSex,PatientAge,PatientFatherName,FromResource,PreDiagnosis,PatientStatus,RequestDoctor,lblBirthPlace,dotsBirthPlace,BirthPlace,lblProtocolNo,dotsProtocolNo,ProtocolNo,lblBarcodeId1,dotsBarcodeId1,lblDash,LOGO,ReportDateField,lblProtocolNo1,dotsProtocolNo1,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            /*long barcodeID = ((LaboratoryResultReport)ParentReport).RuntimeParameters.BARCODEID.ToString();
            string procedureObjectId = "";
            
            BindingList<LaboratoryProcedure.GetLabProcedureByBarcodeId_Class> barcodes = LaboratoryProcedure.GetLabProcedureByBarcodeId(context,barcodeID);
            foreach(LaboratoryProcedure.GetLabProcedureByBarcodeId_Class barcode in barcodes)
            {
                procedureObjectId = barcode.ObjectID.ToString();
                break;
            }
            
            LaboratoryProcedure labProcedure = (LaboratoryProcedure)context.GetObject(new Guid(procedureObjectId),"LaboratoryProcedure");
            string sObjectID = labProcedure.EpisodeAction.ObjectID.ToString();
             */
            string sObjectID = this.OBJECTID.CalcValue;
            
            LaboratoryRequest labObject = (LaboratoryRequest)context.GetObject(new Guid(sObjectID),"LaboratoryRequest");
            Patient patient = labObject.Episode.Patient;
            
            this.PatientAge.CalcValue = patient.Age.ToString();
            string preDiagnosis = null;
            
            List<DiagnosisDefinition> distinctList = new List<DiagnosisDefinition>(); //Tekrarlayan tanıların ayıklanmasında kullanılan liste
            
            foreach(DiagnosisGrid dig in labObject.Episode.Diagnosis)
            {
                if(dig.DiagnosisType == DiagnosisTypeEnum.Primer)
                {
                    if (distinctList.Contains(dig.Diagnose) == false) //Tekrarlayan tanılar burada ayıklanır...
                    {
                        preDiagnosis = preDiagnosis +dig.Diagnose.Code.Trim()+" "+ dig.Diagnose.Name.ToString() + ", " ;
                        distinctList.Add(dig.Diagnose);
                    }
                }
            }
            
            
            this.PreDiagnosis.CalcValue = preDiagnosis;
            
            distinctList = null;

            bool overridePrintRoles = TTObjectClasses.Common.OverridePrintRoles(TTObjectClasses.Common.CurrentUser);
            
            if(patient.SecurePerson == true && overridePrintRoles == false)
            {
                this.PatientName.Visible = this.dotsPatientName.Visible = this.lblPatientName.Visible = EvetHayirEnum.ehHayir;
                this.PatientSex.Visible = this.dotsPatientSex.Visible = this.lblPatientSex.Visible = EvetHayirEnum.ehHayir;
                this.BirthPlace.Visible = this.dotsBirthPlace.Visible = this.lblBirthPlace.Visible = EvetHayirEnum.ehHayir;
                this.PatientAge.Visible = this.dotsPatientAge.Visible = this.lblPatientAge.Visible = EvetHayirEnum.ehHayir;
                this.PatientFatherName.Visible = this.dotsPatientFatherName.Visible = this.lblPatientFatherName.Visible = EvetHayirEnum.ehHayir;
                this.PatientStatus.Visible = this.dotsPatientStatus.Visible = this.lblPatientStatus.Visible = EvetHayirEnum.ehHayir;
                this.FromResource.Visible = this.dotsFromResource.Visible = this.lblFromResource.Visible = EvetHayirEnum.ehHayir;
                this.RequestDoctor.Visible = this.dotsRequestDoctor.Visible = this.lblRequestDoctor.Visible = EvetHayirEnum.ehHayir;
                this.PreDiagnosis.Visible = this.dotsPreDiagnosis.Visible = this.lblPreDiagnosis.Visible = EvetHayirEnum.ehHayir;
                this.ProtocolNo.Visible = this.dotsProtocolNo.Visible = this.lblProtocolNo.Visible = EvetHayirEnum.ehHayir;
            }
            
            this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public LaboratoryBarcodeResultReport MyParentReport
                {
                    get { return (LaboratoryBarcodeResultReport)ParentReport; }
                }
                
                public TTReportField HizmetOzel;
                public TTReportField NewField1111;
                public TTReportField ApprovedBy;
                public TTReportField OBJECTID1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportShape NewLine11; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 22;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HizmetOzel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 14, 245, 20, false);
                    HizmetOzel.Name = "HizmetOzel";
                    HizmetOzel.Visible = EvetHayirEnum.ehHayir;
                    HizmetOzel.TextFont.Name = "Arial Narrow";
                    HizmetOzel.TextFont.Size = 11;
                    HizmetOzel.TextFont.Bold = true;
                    HizmetOzel.TextFont.Underline = true;
                    HizmetOzel.TextFont.CharSet = 162;
                    HizmetOzel.Value = @"HİZMETE ÖZEL";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 7, 129, 12, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.Visible = EvetHayirEnum.ehHayir;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.TextFont.Name = "Arial Narrow";
                    NewField1111.TextFont.Size = 11;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Onaylayan Uzman";

                    ApprovedBy = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 2, 200, 22, false);
                    ApprovedBy.Name = "ApprovedBy";
                    ApprovedBy.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ApprovedBy.MultiLine = EvetHayirEnum.ehEvet;
                    ApprovedBy.NoClip = EvetHayirEnum.ehEvet;
                    ApprovedBy.WordBreak = EvetHayirEnum.ehEvet;
                    ApprovedBy.ObjectDefName = "LaboratoryRequest";
                    ApprovedBy.DataMember = "APPROVEDBY.NAME";
                    ApprovedBy.TextFont.Name = "Microsoft Sans Serif";
                    ApprovedBy.TextFont.Size = 8;
                    ApprovedBy.TextFont.CharSet = 162;
                    ApprovedBy.Value = @"";

                    OBJECTID1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 0, 237, 5, false);
                    OBJECTID1.Name = "OBJECTID1";
                    OBJECTID1.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID1.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID1.TextFont.Name = "Arial Narrow";
                    OBJECTID1.TextFont.Size = 9;
                    OBJECTID1.TextFont.CharSet = 162;
                    OBJECTID1.Value = @"{%TOP.OBJECTID1%}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 14, 107, 22, false);
                    NewField11.Name = "NewField11";
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Bu rapor hasta tedavisi ve dosyası için düzenlenmiştir. İzinsiz olarak bilimsel yayın amacı ile kullanılamaz.";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 14, 20, 19, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Name = "Arial";
                    NewField12.TextFont.Size = 9;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"NOT :";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 1, 200, 1, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratoryRequest.LaboratoryReportNQL_Class dataset_LaboratoryReportNQL = ParentGroup.rsGroup.GetCurrentRecord<LaboratoryRequest.LaboratoryReportNQL_Class>(0);
                    HizmetOzel.CalcValue = HizmetOzel.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    ApprovedBy.CalcValue = ApprovedBy.Value;
                    OBJECTID1.CalcValue = MyParentReport.TOP.OBJECTID1.CalcValue;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    return new TTReportObject[] { HizmetOzel,NewField1111,ApprovedBy,OBJECTID1,NewField11,NewField12};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.OBJECTID1.CalcValue; //((LaboratoryResultReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            LaboratoryRequest labObject = (LaboratoryRequest)context.GetObject(new Guid(sObjectID),"LaboratoryRequest");
            
            ResUser approvedBy = labObject.ApprovedBy;
            
            string CrLf = "\r\n";
            string SB = "";
            string TextContext = "";
                        
            //ApprovedBy
            if(approvedBy != null)
            {
                SB = approvedBy.SignatureBlock; //approvedBy.Rank == null ? "" : approvedBy.Rank.Name;
                TextContext = SB + CrLf ;
                this.ApprovedBy.CalcValue = TextContext;
            }
            
                       
            /*
            string CrLf = "\r\n";
            string TextContext = "";
            string Title = "";
            string Sicil = "";
            string Rank = "";
                        
            //ApprovedBy
            if(approvedBy != null)
            {
                Title = !approvedBy.Title.HasValue ? "" : TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(approvedBy.Title.Value);
                Sicil = approvedBy.EmploymentRecordID;
                Rank = approvedBy.Rank == null ? "" : approvedBy.Rank.Name;
                TextContext = approvedBy.Name + CrLf + Title + " " + Rank + "(" + Sicil + ")" + CrLf ;
                this.ApprovedBy.CalcValue = TextContext;
            }
            */
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class TABORDERGroup : TTReportGroup
        {
            public LaboratoryBarcodeResultReport MyParentReport
            {
                get { return (LaboratoryBarcodeResultReport)ParentReport; }
            }

            new public TABORDERGroupHeader Header()
            {
                return (TABORDERGroupHeader)_header;
            }

            new public TABORDERGroupFooter Footer()
            {
                return (TABORDERGroupFooter)_footer;
            }

            public TTReportField REQUESTEDTAB { get {return Header().REQUESTEDTAB;} }
            public TTReportField TAB { get {return Header().TAB;} }
            public TTReportField ENVIRONMENT { get {return Header().ENVIRONMENT;} }
            public TTReportField OBJECTID { get {return Header().OBJECTID;} }
            public TTReportField Date { get {return Header().Date;} }
            public TTReportField lblOldResults1 { get {return Header().lblOldResults1;} }
            public TTReportField REQUEST1 { get {return Header().REQUEST1;} }
            public TTReportField REQUEST2 { get {return Header().REQUEST2;} }
            public TTReportField OBJECTID1 { get {return Header().OBJECTID1;} }
            public TTReportField lblTest1 { get {return Header().lblTest1;} }
            public TTReportField lblResult1 { get {return Header().lblResult1;} }
            public TTReportField lblUnit1 { get {return Header().lblUnit1;} }
            public TTReportField lblUnit2 { get {return Header().lblUnit2;} }
            public TTReportField DATE1 { get {return Header().DATE1;} }
            public TTReportField DATE2 { get {return Header().DATE2;} }
            public TTReportField DATE3 { get {return Header().DATE3;} }
            public TTReportField REQUEST3 { get {return Header().REQUEST3;} }
            public TTReportField LBLENVIRONMENT { get {return Header().LBLENVIRONMENT;} }
            public TTReportField LABPROCEDURES { get {return Header().LABPROCEDURES;} }
            public TTReportField NewField1132 { get {return Header().NewField1132;} }
            public TTReportField RequestDate { get {return Header().RequestDate;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField RequestAcceptionDate { get {return Header().RequestAcceptionDate;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField SampleAcceptionDate { get {return Header().SampleAcceptionDate;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField ResultDate { get {return Header().ResultDate;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportShape NewLine111111 { get {return Header().NewLine111111;} }
            public TTReportShape NewLine1121 { get {return Header().NewLine1121;} }
            public TTReportShape NewLine11211 { get {return Header().NewLine11211;} }
            public TTReportShape NewLine111211 { get {return Header().NewLine111211;} }
            public TTReportShape NewLine111212 { get {return Header().NewLine111212;} }
            public TTReportShape NewLine1111111 { get {return Header().NewLine1111111;} }
            public TABORDERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TABORDERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<LaboratoryRequestFormTabDefinition.GetLabTabsNQL_Class>("GetLabTabsNQL", LaboratoryRequestFormTabDefinition.GetLabTabsNQL());
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TABORDERGroupHeader(this);
                _footer = new TABORDERGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TABORDERGroupHeader : TTReportSection
            {
                public LaboratoryBarcodeResultReport MyParentReport
                {
                    get { return (LaboratoryBarcodeResultReport)ParentReport; }
                }
                
                public TTReportField REQUESTEDTAB;
                public TTReportField TAB;
                public TTReportField ENVIRONMENT;
                public TTReportField OBJECTID;
                public TTReportField Date;
                public TTReportField lblOldResults1;
                public TTReportField REQUEST1;
                public TTReportField REQUEST2;
                public TTReportField OBJECTID1;
                public TTReportField lblTest1;
                public TTReportField lblResult1;
                public TTReportField lblUnit1;
                public TTReportField lblUnit2;
                public TTReportField DATE1;
                public TTReportField DATE2;
                public TTReportField DATE3;
                public TTReportField REQUEST3;
                public TTReportField LBLENVIRONMENT;
                public TTReportField LABPROCEDURES;
                public TTReportField NewField1132;
                public TTReportField RequestDate;
                public TTReportField NewField11311;
                public TTReportField RequestAcceptionDate;
                public TTReportField NewField122;
                public TTReportField SampleAcceptionDate;
                public TTReportField NewField1121;
                public TTReportField ResultDate;
                public TTReportShape NewLine121;
                public TTReportShape NewLine111111;
                public TTReportShape NewLine1121;
                public TTReportShape NewLine11211;
                public TTReportShape NewLine111211;
                public TTReportShape NewLine111212;
                public TTReportShape NewLine1111111; 
                public TABORDERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REQUESTEDTAB = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 1, 76, 6, false);
                    REQUESTEDTAB.Name = "REQUESTEDTAB";
                    REQUESTEDTAB.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTEDTAB.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTEDTAB.TextFont.Name = "Microsoft Sans Serif";
                    REQUESTEDTAB.TextFont.Size = 11;
                    REQUESTEDTAB.TextFont.Bold = true;
                    REQUESTEDTAB.TextFont.CharSet = 162;
                    REQUESTEDTAB.Value = @"{#NAME#}";

                    TAB = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 2, 231, 7, false);
                    TAB.Name = "TAB";
                    TAB.Visible = EvetHayirEnum.ehHayir;
                    TAB.FieldType = ReportFieldTypeEnum.ftVariable;
                    TAB.TextFont.Name = "Arial Narrow";
                    TAB.TextFont.Size = 9;
                    TAB.TextFont.CharSet = 162;
                    TAB.Value = @"{#OBJECTID#}";

                    ENVIRONMENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 183, 6, 200, 11, false);
                    ENVIRONMENT.Name = "ENVIRONMENT";
                    ENVIRONMENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENVIRONMENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENVIRONMENT.ObjectDefName = "LaboratoryEnvironmentDefinition";
                    ENVIRONMENT.DataMember = "NAME";
                    ENVIRONMENT.TextFont.Name = "Microsoft Sans Serif";
                    ENVIRONMENT.TextFont.Size = 9;
                    ENVIRONMENT.TextFont.Bold = true;
                    ENVIRONMENT.TextFont.CharSet = 162;
                    ENVIRONMENT.Value = @"{#ENVIRONMENT#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 234, 2, 255, 7, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.TextFont.Name = "Arial Narrow";
                    OBJECTID.TextFont.Size = 9;
                    OBJECTID.TextFont.CharSet = 162;
                    OBJECTID.Value = @"{%TOP.OBJECTID1%}";

                    Date = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 7, 153, 12, false);
                    Date.Name = "Date";
                    Date.Visible = EvetHayirEnum.ehHayir;
                    Date.DrawStyle = DrawStyleConstants.vbSolid;
                    Date.FieldType = ReportFieldTypeEnum.ftVariable;
                    Date.TextFormat = @"Short Date";
                    Date.ObjectDefName = "LaboratoryRequest";
                    Date.DataMember = "WORKLISTDATE";
                    Date.TextFont.Name = "Arial Narrow";
                    Date.TextFont.Bold = true;
                    Date.TextFont.CharSet = 162;
                    Date.Value = @"{%HEADER.OBJECTID%}";

                    lblOldResults1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 11, 200, 16, false);
                    lblOldResults1.Name = "lblOldResults1";
                    lblOldResults1.DrawStyle = DrawStyleConstants.vbSolid;
                    lblOldResults1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    lblOldResults1.TextFont.Name = "Microsoft Sans Serif";
                    lblOldResults1.TextFont.Size = 9;
                    lblOldResults1.TextFont.CharSet = 162;
                    lblOldResults1.Value = @"ÖNCEKİ SONUÇLAR";

                    REQUEST1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 8, 232, 13, false);
                    REQUEST1.Name = "REQUEST1";
                    REQUEST1.Visible = EvetHayirEnum.ehHayir;
                    REQUEST1.TextFont.Name = "Arial Narrow";
                    REQUEST1.TextFont.Size = 9;
                    REQUEST1.TextFont.CharSet = 162;
                    REQUEST1.Value = @"REQUEST1";

                    REQUEST2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 14, 233, 19, false);
                    REQUEST2.Name = "REQUEST2";
                    REQUEST2.Visible = EvetHayirEnum.ehHayir;
                    REQUEST2.TextFont.Name = "Arial Narrow";
                    REQUEST2.TextFont.Size = 9;
                    REQUEST2.TextFont.CharSet = 162;
                    REQUEST2.Value = @"REQUEST2";

                    OBJECTID1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 8, 257, 13, false);
                    OBJECTID1.Name = "OBJECTID1";
                    OBJECTID1.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID1.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID1.TextFont.Name = "Arial Narrow";
                    OBJECTID1.TextFont.Size = 9;
                    OBJECTID1.TextFont.CharSet = 162;
                    OBJECTID1.Value = @"{%TOP.OBJECTID1%}";

                    lblTest1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 19, 66, 24, false);
                    lblTest1.Name = "lblTest1";
                    lblTest1.TextFont.Name = "Microsoft Sans Serif";
                    lblTest1.TextFont.Underline = true;
                    lblTest1.TextFont.CharSet = 162;
                    lblTest1.Value = @"TEST";

                    lblResult1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 19, 94, 24, false);
                    lblResult1.Name = "lblResult1";
                    lblResult1.TextFont.Name = "Microsoft Sans Serif";
                    lblResult1.TextFont.Underline = true;
                    lblResult1.TextFont.CharSet = 162;
                    lblResult1.Value = @"SONUÇ";

                    lblUnit1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 19, 155, 24, false);
                    lblUnit1.Name = "lblUnit1";
                    lblUnit1.TextFont.Name = "Microsoft Sans Serif";
                    lblUnit1.TextFont.Underline = true;
                    lblUnit1.TextFont.CharSet = 162;
                    lblUnit1.Value = @"REFERANS";

                    lblUnit2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 19, 122, 24, false);
                    lblUnit2.Name = "lblUnit2";
                    lblUnit2.TextFont.Name = "Microsoft Sans Serif";
                    lblUnit2.TextFont.Underline = true;
                    lblUnit2.TextFont.CharSet = 162;
                    lblUnit2.Value = @"BİRİM";

                    DATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 19, 172, 24, false);
                    DATE1.Name = "DATE1";
                    DATE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATE1.TextFont.Name = "Microsoft Sans Serif";
                    DATE1.TextFont.Size = 7;
                    DATE1.TextFont.Underline = true;
                    DATE1.TextFont.CharSet = 162;
                    DATE1.Value = @"";

                    DATE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 19, 186, 24, false);
                    DATE2.Name = "DATE2";
                    DATE2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATE2.TextFont.Name = "Microsoft Sans Serif";
                    DATE2.TextFont.Size = 7;
                    DATE2.TextFont.Underline = true;
                    DATE2.TextFont.CharSet = 162;
                    DATE2.Value = @"";

                    DATE3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 19, 200, 24, false);
                    DATE3.Name = "DATE3";
                    DATE3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DATE3.TextFont.Name = "Microsoft Sans Serif";
                    DATE3.TextFont.Size = 7;
                    DATE3.TextFont.Underline = true;
                    DATE3.TextFont.CharSet = 162;
                    DATE3.Value = @"";

                    REQUEST3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 235, 14, 251, 19, false);
                    REQUEST3.Name = "REQUEST3";
                    REQUEST3.Visible = EvetHayirEnum.ehHayir;
                    REQUEST3.TextFont.Name = "Arial Narrow";
                    REQUEST3.TextFont.Size = 9;
                    REQUEST3.TextFont.CharSet = 162;
                    REQUEST3.Value = @"REQUEST3";

                    LBLENVIRONMENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 6, 182, 11, false);
                    LBLENVIRONMENT.Name = "LBLENVIRONMENT";
                    LBLENVIRONMENT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    LBLENVIRONMENT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LBLENVIRONMENT.TextFont.Name = "Microsoft Sans Serif";
                    LBLENVIRONMENT.TextFont.Size = 9;
                    LBLENVIRONMENT.TextFont.Bold = true;
                    LBLENVIRONMENT.TextFont.CharSet = 162;
                    LBLENVIRONMENT.Value = @"Örnek Türü:";

                    LABPROCEDURES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 23, 244, 28, false);
                    LABPROCEDURES.Name = "LABPROCEDURES";
                    LABPROCEDURES.Visible = EvetHayirEnum.ehHayir;
                    LABPROCEDURES.FieldType = ReportFieldTypeEnum.ftVariable;
                    LABPROCEDURES.TextFont.Name = "Arial Narrow";
                    LABPROCEDURES.TextFont.Size = 9;
                    LABPROCEDURES.TextFont.CharSet = 162;
                    LABPROCEDURES.Value = @"";

                    NewField1132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 8, 31, 12, false);
                    NewField1132.Name = "NewField1132";
                    NewField1132.TextFont.Name = "Arial";
                    NewField1132.TextFont.Size = 7;
                    NewField1132.TextFont.Underline = true;
                    NewField1132.TextFont.CharSet = 162;
                    NewField1132.Value = @"İstek Tarihi";

                    RequestDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 12, 37, 16, false);
                    RequestDate.Name = "RequestDate";
                    RequestDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    RequestDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RequestDate.TextFont.Name = "Arial";
                    RequestDate.TextFont.Size = 7;
                    RequestDate.TextFont.CharSet = 162;
                    RequestDate.Value = @"";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 8, 62, 12, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.TextFont.Name = "Arial";
                    NewField11311.TextFont.Size = 7;
                    NewField11311.TextFont.Underline = true;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"İstek Kabul Tarihi";

                    RequestAcceptionDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 12, 68, 16, false);
                    RequestAcceptionDate.Name = "RequestAcceptionDate";
                    RequestAcceptionDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    RequestAcceptionDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RequestAcceptionDate.TextFont.Name = "Arial";
                    RequestAcceptionDate.TextFont.Size = 7;
                    RequestAcceptionDate.TextFont.CharSet = 162;
                    RequestAcceptionDate.Value = @"";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 8, 93, 12, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Name = "Arial";
                    NewField122.TextFont.Size = 7;
                    NewField122.TextFont.Underline = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Numune Kabul Tarihi";

                    SampleAcceptionDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 12, 99, 16, false);
                    SampleAcceptionDate.Name = "SampleAcceptionDate";
                    SampleAcceptionDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    SampleAcceptionDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SampleAcceptionDate.TextFont.Name = "Arial";
                    SampleAcceptionDate.TextFont.Size = 7;
                    SampleAcceptionDate.TextFont.CharSet = 162;
                    SampleAcceptionDate.Value = @"";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 8, 124, 12, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Size = 7;
                    NewField1121.TextFont.Underline = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Sonuç Onay Tarihi";

                    ResultDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 12, 130, 16, false);
                    ResultDate.Name = "ResultDate";
                    ResultDate.TextFormat = @"dd/MM/yyyy HH:mm";
                    ResultDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ResultDate.TextFont.Name = "Arial";
                    ResultDate.TextFont.Size = 7;
                    ResultDate.TextFont.CharSet = 162;
                    ResultDate.Value = @"";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 38, 7, 38, 17, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.ForeColor = System.Drawing.Color.Gray;
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 7, 131, 7, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.ForeColor = System.Drawing.Color.Gray;
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 69, 7, 69, 17, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.ForeColor = System.Drawing.Color.Gray;
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 100, 7, 100, 17, false);
                    NewLine11211.Name = "NewLine11211";
                    NewLine11211.ForeColor = System.Drawing.Color.Gray;
                    NewLine11211.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 7, 6, 17, false);
                    NewLine111211.Name = "NewLine111211";
                    NewLine111211.ForeColor = System.Drawing.Color.Gray;
                    NewLine111211.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111212 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 131, 7, 131, 17, false);
                    NewLine111212.Name = "NewLine111212";
                    NewLine111212.ForeColor = System.Drawing.Color.Gray;
                    NewLine111212.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 17, 131, 17, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.ForeColor = System.Drawing.Color.Gray;
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratoryRequestFormTabDefinition.GetLabTabsNQL_Class dataset_GetLabTabsNQL = ParentGroup.rsGroup.GetCurrentRecord<LaboratoryRequestFormTabDefinition.GetLabTabsNQL_Class>(0);
                    REQUESTEDTAB.CalcValue = (dataset_GetLabTabsNQL != null ? Globals.ToStringCore(dataset_GetLabTabsNQL.Name) : "");
                    TAB.CalcValue = (dataset_GetLabTabsNQL != null ? Globals.ToStringCore(dataset_GetLabTabsNQL.ObjectID) : "");
                    ENVIRONMENT.CalcValue = (dataset_GetLabTabsNQL != null ? Globals.ToStringCore(dataset_GetLabTabsNQL.Environment) : "");
                    ENVIRONMENT.PostFieldValueCalculation();
                    OBJECTID.CalcValue = MyParentReport.TOP.OBJECTID1.CalcValue;
                    Date.CalcValue = MyParentReport.HEADER.OBJECTID.CalcValue;
                    Date.PostFieldValueCalculation();
                    lblOldResults1.CalcValue = lblOldResults1.Value;
                    REQUEST1.CalcValue = REQUEST1.Value;
                    REQUEST2.CalcValue = REQUEST2.Value;
                    OBJECTID1.CalcValue = MyParentReport.TOP.OBJECTID1.CalcValue;
                    lblTest1.CalcValue = lblTest1.Value;
                    lblResult1.CalcValue = lblResult1.Value;
                    lblUnit1.CalcValue = lblUnit1.Value;
                    lblUnit2.CalcValue = lblUnit2.Value;
                    DATE1.CalcValue = DATE1.Value;
                    DATE2.CalcValue = DATE2.Value;
                    DATE3.CalcValue = DATE3.Value;
                    REQUEST3.CalcValue = REQUEST3.Value;
                    LBLENVIRONMENT.CalcValue = LBLENVIRONMENT.Value;
                    LABPROCEDURES.CalcValue = @"";
                    NewField1132.CalcValue = NewField1132.Value;
                    RequestDate.CalcValue = RequestDate.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    RequestAcceptionDate.CalcValue = RequestAcceptionDate.Value;
                    NewField122.CalcValue = NewField122.Value;
                    SampleAcceptionDate.CalcValue = SampleAcceptionDate.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    ResultDate.CalcValue = ResultDate.Value;
                    return new TTReportObject[] { REQUESTEDTAB,TAB,ENVIRONMENT,OBJECTID,Date,lblOldResults1,REQUEST1,REQUEST2,OBJECTID1,lblTest1,lblResult1,lblUnit1,lblUnit2,DATE1,DATE2,DATE3,REQUEST3,LBLENVIRONMENT,LABPROCEDURES,NewField1132,RequestDate,NewField11311,RequestAcceptionDate,NewField122,SampleAcceptionDate,NewField1121,ResultDate};
                }

                public override void RunScript()
                {
#region TABORDER HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.OBJECTID.CalcValue;
            
            LaboratoryRequest labObject = (LaboratoryRequest)context.GetObject(new Guid(sObjectID),"LaboratoryRequest");
            
            BindingList<TTObjectClasses.LaboratoryProcedure> procedures = LaboratoryProcedure.GetLabResults(context, " WHERE CURRENTSTATE <> '" + LaboratoryProcedure.States.Cancelled + "' AND EPISODEACTION = '" + labObject.ObjectID.ToString() + "' AND REQUESTEDTAB = '" + this.TAB.CalcValue.ToString() + "'");
            if (procedures.Count <= 0 )
            {
                ((TTReportTool.TTReportSection)(((LaboratoryBarcodeResultReport)ParentReport).Groups("TABORDER").Header)).Visible = EvetHayirEnum.ehHayir;
                this.TAB.CalcValue = "00000000-0000-0000-0000-000000000000";
            }
            else
            {
                
                if(((LaboratoryProcedure)procedures[0]).SampleAcceptionDate != null)
                {
                    this.SampleAcceptionDate.CalcValue =  ((LaboratoryProcedure)procedures[0]).SampleAcceptionDate.ToString();
                }
                else
                {
                    this.SampleAcceptionDate.CalcValue = string.Empty;
                    this.SampleAcceptionDate.Visible = EvetHayirEnum.ehHayir;
                }
                
                if(((LaboratoryProcedure)procedures[0]).ResultDate != null)
                    this.ResultDate.CalcValue =  ((LaboratoryProcedure)procedures[0]).ResultDate.ToString();
                //Sonradan eklenenler
                if(labObject.RequestDate != null)
                    this.RequestDate.CalcValue = labObject.RequestDate.ToString();
                if(labObject.LabRequestAcceptionDate != null)
                    this.RequestAcceptionDate.CalcValue = labObject.LabRequestAcceptionDate.ToString();             
                // 
                ((TTReportTool.TTReportSection)(((LaboratoryBarcodeResultReport)ParentReport).Groups("TABORDER").Header)).Visible = EvetHayirEnum.ehEvet;
                Patient patient = labObject.Episode.Patient;
                Guid tabGuid = new Guid(this.TAB.CalcValue.ToString());
                BindingList<LaboratoryProcedure.GetLabProcedureByRequestTab_Class> requests
                    = LaboratoryProcedure.GetLabProcedureByRequestTab(context, tabGuid, patient.ObjectID,(DateTime)labObject.WorkListDate);
                int i = 0;
                foreach(LaboratoryProcedure.GetLabProcedureByRequestTab_Class request in requests)
                {
                    if(i == 0)
                    {
                        this.REQUEST1.CalcValue = request.Ttobjectid.ToString();
                        this.DATE1.CalcValue = (Convert.ToDateTime(request.WorkListDate.Value)).ToString("dd/MM/yy");
                        
                    }
                    else if(i == 1)
                    {
                        this.REQUEST2.CalcValue = request.Ttobjectid.ToString();
                        this.DATE2.CalcValue = (Convert.ToDateTime(request.WorkListDate.Value)).ToString("dd/MM/yy");
                    }
                    else if(i == 2)
                    {
                        this.REQUEST3.CalcValue = request.Ttobjectid.ToString();
                        this.DATE3.CalcValue = (Convert.ToDateTime(request.WorkListDate.Value)).ToString("dd/MM/yy");
                    }
                    i++;
                }
            }
#endregion TABORDER HEADER_Script
                }
            }
            public partial class TABORDERGroupFooter : TTReportSection
            {
                public LaboratoryBarcodeResultReport MyParentReport
                {
                    get { return (LaboratoryBarcodeResultReport)ParentReport; }
                }
                 
                public TABORDERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public TABORDERGroup TABORDER;

        public partial class TABGroup : TTReportGroup
        {
            public LaboratoryBarcodeResultReport MyParentReport
            {
                get { return (LaboratoryBarcodeResultReport)ParentReport; }
            }

            new public TABGroupHeader Header()
            {
                return (TABGroupHeader)_header;
            }

            new public TABGroupFooter Footer()
            {
                return (TABGroupFooter)_footer;
            }

            public TTReportField TABID { get {return Header().TABID;} }
            public TTReportField PROCEDUREOBJECT { get {return Header().PROCEDUREOBJECT;} }
            public TABGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TABGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TABGroupHeader(this);
                _footer = new TABGroupFooter(this);

            }

            public partial class TABGroupHeader : TTReportSection
            {
                public LaboratoryBarcodeResultReport MyParentReport
                {
                    get { return (LaboratoryBarcodeResultReport)ParentReport; }
                }
                
                public TTReportField TABID;
                public TTReportField PROCEDUREOBJECT; 
                public TABGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    TABID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 2, 79, 7, false);
                    TABID.Name = "TABID";
                    TABID.Visible = EvetHayirEnum.ehHayir;
                    TABID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABID.TextFont.Name = "Microsoft Sans Serif";
                    TABID.TextFont.Underline = true;
                    TABID.TextFont.CharSet = 162;
                    TABID.Value = @"";

                    PROCEDUREOBJECT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 2, 230, 7, false);
                    PROCEDUREOBJECT.Name = "PROCEDUREOBJECT";
                    PROCEDUREOBJECT.Visible = EvetHayirEnum.ehHayir;
                    PROCEDUREOBJECT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROCEDUREOBJECT.TextFont.Name = "Arial Narrow";
                    PROCEDUREOBJECT.TextFont.Size = 9;
                    PROCEDUREOBJECT.TextFont.CharSet = 162;
                    PROCEDUREOBJECT.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TABID.CalcValue = @"";
                    PROCEDUREOBJECT.CalcValue = @"";
                    return new TTReportObject[] { TABID,PROCEDUREOBJECT};
                }
            }
            public partial class TABGroupFooter : TTReportSection
            {
                public LaboratoryBarcodeResultReport MyParentReport
                {
                    get { return (LaboratoryBarcodeResultReport)ParentReport; }
                }
                 
                public TABGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public TABGroup TAB;

        public partial class GROUPGroup : TTReportGroup
        {
            public LaboratoryBarcodeResultReport MyParentReport
            {
                get { return (LaboratoryBarcodeResultReport)ParentReport; }
            }

            new public GROUPGroupHeader Header()
            {
                return (GROUPGroupHeader)_header;
            }

            new public GROUPGroupFooter Footer()
            {
                return (GROUPGroupFooter)_footer;
            }

            public GROUPGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public GROUPGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<LaboratoryProcedure.GetLabProcedureByTabAndRequest_Class>("GetLabProcedureByTabAndRequest", LaboratoryProcedure.GetLabProcedureByTabAndRequest((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.TOP.OBJECTID1.CalcValue),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.TABORDER.TAB.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new GROUPGroupHeader(this);
                _footer = new GROUPGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class GROUPGroupHeader : TTReportSection
            {
                public LaboratoryBarcodeResultReport MyParentReport
                {
                    get { return (LaboratoryBarcodeResultReport)ParentReport; }
                }
                 
                public GROUPGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class GROUPGroupFooter : TTReportSection
            {
                public LaboratoryBarcodeResultReport MyParentReport
                {
                    get { return (LaboratoryBarcodeResultReport)ParentReport; }
                }
                 
                public GROUPGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public GROUPGroup GROUP;

        public partial class PARENTGroup : TTReportGroup
        {
            public LaboratoryBarcodeResultReport MyParentReport
            {
                get { return (LaboratoryBarcodeResultReport)ParentReport; }
            }

            new public PARENTGroupHeader Header()
            {
                return (PARENTGroupHeader)_header;
            }

            new public PARENTGroupFooter Footer()
            {
                return (PARENTGroupFooter)_footer;
            }

            public TTReportField LaboratoryProcedureTestName { get {return Header().LaboratoryProcedureTestName;} }
            public TTReportField Result { get {return Header().Result;} }
            public TTReportField Reference { get {return Header().Reference;} }
            public TTReportField Unit { get {return Header().Unit;} }
            public TTReportField OBJID { get {return Header().OBJID;} }
            public TTReportField WARNING { get {return Header().WARNING;} }
            public TTReportField Result1 { get {return Header().Result1;} }
            public TTReportField Result2 { get {return Header().Result2;} }
            public TTReportField REQ1 { get {return Header().REQ1;} }
            public TTReportField REQ2 { get {return Header().REQ2;} }
            public TTReportField TESTID { get {return Header().TESTID;} }
            public TTReportField WarningSign { get {return Header().WarningSign;} }
            public TTReportField REQ3 { get {return Header().REQ3;} }
            public TTReportField Result3 { get {return Header().Result3;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField RESULTDESCRIPTION { get {return Header().RESULTDESCRIPTION;} }
            public TTReportField CURRENTSTATE { get {return Header().CURRENTSTATE;} }
            public TTReportField SPECIALREF { get {return Header().SPECIALREF;} }
            public TTReportRTF LongReportRTF { get {return Footer().LongReportRTF;} }
            public PARENTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARENTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARENTGroupHeader(this);
                _footer = new PARENTGroupFooter(this);

            }

            public partial class PARENTGroupHeader : TTReportSection
            {
                public LaboratoryBarcodeResultReport MyParentReport
                {
                    get { return (LaboratoryBarcodeResultReport)ParentReport; }
                }
                
                public TTReportField LaboratoryProcedureTestName;
                public TTReportField Result;
                public TTReportField Reference;
                public TTReportField Unit;
                public TTReportField OBJID;
                public TTReportField WARNING;
                public TTReportField Result1;
                public TTReportField Result2;
                public TTReportField REQ1;
                public TTReportField REQ2;
                public TTReportField TESTID;
                public TTReportField WarningSign;
                public TTReportField REQ3;
                public TTReportField Result3;
                public TTReportShape NewLine11;
                public TTReportField RESULTDESCRIPTION;
                public TTReportField CURRENTSTATE;
                public TTReportField SPECIALREF; 
                public PARENTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 6;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    LaboratoryProcedureTestName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 2, 66, 6, false);
                    LaboratoryProcedureTestName.Name = "LaboratoryProcedureTestName";
                    LaboratoryProcedureTestName.FieldType = ReportFieldTypeEnum.ftVariable;
                    LaboratoryProcedureTestName.MultiLine = EvetHayirEnum.ehEvet;
                    LaboratoryProcedureTestName.NoClip = EvetHayirEnum.ehEvet;
                    LaboratoryProcedureTestName.WordBreak = EvetHayirEnum.ehEvet;
                    LaboratoryProcedureTestName.ExpandTabs = EvetHayirEnum.ehEvet;
                    LaboratoryProcedureTestName.TextFont.Name = "Microsoft Sans Serif";
                    LaboratoryProcedureTestName.TextFont.Size = 8;
                    LaboratoryProcedureTestName.TextFont.CharSet = 162;
                    LaboratoryProcedureTestName.Value = @"{#GROUP.NAME#}";

                    Result = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 2, 94, 6, false);
                    Result.Name = "Result";
                    Result.FieldType = ReportFieldTypeEnum.ftVariable;
                    Result.MultiLine = EvetHayirEnum.ehEvet;
                    Result.NoClip = EvetHayirEnum.ehEvet;
                    Result.WordBreak = EvetHayirEnum.ehEvet;
                    Result.ExpandTabs = EvetHayirEnum.ehEvet;
                    Result.TextFont.Name = "Microsoft Sans Serif";
                    Result.TextFont.Size = 8;
                    Result.TextFont.CharSet = 162;
                    Result.Value = @"{#GROUP.RESULT#}";

                    Reference = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 2, 155, 6, false);
                    Reference.Name = "Reference";
                    Reference.FieldType = ReportFieldTypeEnum.ftVariable;
                    Reference.MultiLine = EvetHayirEnum.ehEvet;
                    Reference.NoClip = EvetHayirEnum.ehEvet;
                    Reference.WordBreak = EvetHayirEnum.ehEvet;
                    Reference.ExpandTabs = EvetHayirEnum.ehEvet;
                    Reference.TextFont.Name = "Microsoft Sans Serif";
                    Reference.TextFont.Size = 8;
                    Reference.TextFont.CharSet = 162;
                    Reference.Value = @"{#GROUP.REFERENCE#}";

                    Unit = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 2, 122, 6, false);
                    Unit.Name = "Unit";
                    Unit.FieldType = ReportFieldTypeEnum.ftVariable;
                    Unit.MultiLine = EvetHayirEnum.ehEvet;
                    Unit.NoClip = EvetHayirEnum.ehEvet;
                    Unit.WordBreak = EvetHayirEnum.ehEvet;
                    Unit.ExpandTabs = EvetHayirEnum.ehEvet;
                    Unit.TextFont.Name = "Microsoft Sans Serif";
                    Unit.TextFont.Size = 8;
                    Unit.TextFont.CharSet = 162;
                    Unit.Value = @"{#GROUP.UNIT#}";

                    OBJID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 0, 243, 5, false);
                    OBJID.Name = "OBJID";
                    OBJID.Visible = EvetHayirEnum.ehHayir;
                    OBJID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJID.TextFont.Name = "Arial Narrow";
                    OBJID.TextFont.Size = 9;
                    OBJID.TextFont.CharSet = 162;
                    OBJID.Value = @"{#GROUP.OBJECTID#}";

                    WARNING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 0, 230, 5, false);
                    WARNING.Name = "WARNING";
                    WARNING.Visible = EvetHayirEnum.ehHayir;
                    WARNING.FieldType = ReportFieldTypeEnum.ftVariable;
                    WARNING.ObjectDefName = "HighLowEnum";
                    WARNING.DataMember = "DISPLAYTEXT";
                    WARNING.TextFont.Name = "Arial Narrow";
                    WARNING.TextFont.Size = 9;
                    WARNING.TextFont.CharSet = 162;
                    WARNING.Value = @"{#GROUP.WARNING#}";

                    Result1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 2, 172, 6, false);
                    Result1.Name = "Result1";
                    Result1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Result1.MultiLine = EvetHayirEnum.ehEvet;
                    Result1.NoClip = EvetHayirEnum.ehEvet;
                    Result1.WordBreak = EvetHayirEnum.ehEvet;
                    Result1.ExpandTabs = EvetHayirEnum.ehEvet;
                    Result1.TextFont.Name = "Microsoft Sans Serif";
                    Result1.TextFont.Size = 8;
                    Result1.TextFont.CharSet = 162;
                    Result1.Value = @"";

                    Result2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 2, 186, 6, false);
                    Result2.Name = "Result2";
                    Result2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Result2.MultiLine = EvetHayirEnum.ehEvet;
                    Result2.NoClip = EvetHayirEnum.ehEvet;
                    Result2.WordBreak = EvetHayirEnum.ehEvet;
                    Result2.ExpandTabs = EvetHayirEnum.ehEvet;
                    Result2.TextFont.Name = "Microsoft Sans Serif";
                    Result2.TextFont.Size = 8;
                    Result2.TextFont.CharSet = 162;
                    Result2.Value = @"";

                    REQ1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 244, 0, 252, 5, false);
                    REQ1.Name = "REQ1";
                    REQ1.Visible = EvetHayirEnum.ehHayir;
                    REQ1.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQ1.TextFont.Name = "Arial Narrow";
                    REQ1.TextFont.Size = 9;
                    REQ1.TextFont.CharSet = 162;
                    REQ1.Value = @"{%TABORDER.REQUEST1%}";

                    REQ2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 253, 0, 262, 5, false);
                    REQ2.Name = "REQ2";
                    REQ2.Visible = EvetHayirEnum.ehHayir;
                    REQ2.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQ2.TextFont.Name = "Arial Narrow";
                    REQ2.TextFont.Size = 9;
                    REQ2.TextFont.CharSet = 162;
                    REQ2.Value = @"{%TABORDER.REQUEST2%}";

                    TESTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 274, 0, 283, 5, false);
                    TESTID.Name = "TESTID";
                    TESTID.Visible = EvetHayirEnum.ehHayir;
                    TESTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESTID.TextFont.Name = "Arial Narrow";
                    TESTID.TextFont.Size = 9;
                    TESTID.TextFont.CharSet = 162;
                    TESTID.Value = @"{#GROUP.PROCEDUREOBJECT#}";

                    WarningSign = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 2, 73, 6, false);
                    WarningSign.Name = "WarningSign";
                    WarningSign.TextFont.Name = "Microsoft Sans Serif";
                    WarningSign.TextFont.Size = 8;
                    WarningSign.TextFont.CharSet = 162;
                    WarningSign.Value = @"";

                    REQ3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 0, 272, 5, false);
                    REQ3.Name = "REQ3";
                    REQ3.Visible = EvetHayirEnum.ehHayir;
                    REQ3.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQ3.TextFont.Name = "Arial Narrow";
                    REQ3.TextFont.Size = 9;
                    REQ3.TextFont.CharSet = 162;
                    REQ3.Value = @"{%TABORDER.REQUEST3%}";

                    Result3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 2, 200, 6, false);
                    Result3.Name = "Result3";
                    Result3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Result3.MultiLine = EvetHayirEnum.ehEvet;
                    Result3.NoClip = EvetHayirEnum.ehEvet;
                    Result3.WordBreak = EvetHayirEnum.ehEvet;
                    Result3.ExpandTabs = EvetHayirEnum.ehEvet;
                    Result3.TextFont.Name = "Microsoft Sans Serif";
                    Result3.TextFont.Size = 8;
                    Result3.TextFont.CharSet = 162;
                    Result3.Value = @"";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 1, 200, 1, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.ForeColor = System.Drawing.Color.FromArgb(255,221,221,221);
                    NewLine11.DrawStyle = DrawStyleConstants.vbDashDot;
                    NewLine11.FillStyle = FillStyleConstants.vbFSTransparent;

                    RESULTDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 285, 0, 298, 5, false);
                    RESULTDESCRIPTION.Name = "RESULTDESCRIPTION";
                    RESULTDESCRIPTION.Visible = EvetHayirEnum.ehHayir;
                    RESULTDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESULTDESCRIPTION.TextFont.Name = "Arial Narrow";
                    RESULTDESCRIPTION.TextFont.Size = 9;
                    RESULTDESCRIPTION.TextFont.CharSet = 162;
                    RESULTDESCRIPTION.Value = @"{#GROUP.RESULTDESCRIPTION#}";

                    CURRENTSTATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 0, 309, 5, false);
                    CURRENTSTATE.Name = "CURRENTSTATE";
                    CURRENTSTATE.Visible = EvetHayirEnum.ehHayir;
                    CURRENTSTATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CURRENTSTATE.TextFont.Name = "Arial Narrow";
                    CURRENTSTATE.TextFont.CharSet = 1;
                    CURRENTSTATE.Value = @"{#GROUP.CURRENTSTATEDEFID#}";

                    SPECIALREF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 311, 0, 327, 5, false);
                    SPECIALREF.Name = "SPECIALREF";
                    SPECIALREF.Visible = EvetHayirEnum.ehHayir;
                    SPECIALREF.FieldType = ReportFieldTypeEnum.ftVariable;
                    SPECIALREF.TextFont.Name = "Arial Narrow";
                    SPECIALREF.TextFont.CharSet = 1;
                    SPECIALREF.Value = @"{#GROUP.SPECIALREFERENCE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratoryProcedure.GetLabProcedureByTabAndRequest_Class dataset_GetLabProcedureByTabAndRequest = MyParentReport.GROUP.rsGroup.GetCurrentRecord<LaboratoryProcedure.GetLabProcedureByTabAndRequest_Class>(0);
                    LaboratoryProcedureTestName.CalcValue = (dataset_GetLabProcedureByTabAndRequest != null ? Globals.ToStringCore(dataset_GetLabProcedureByTabAndRequest.Name) : "");
                    Result.CalcValue = (dataset_GetLabProcedureByTabAndRequest != null ? Globals.ToStringCore(dataset_GetLabProcedureByTabAndRequest.Result) : "");
                    Reference.CalcValue = (dataset_GetLabProcedureByTabAndRequest != null ? Globals.ToStringCore(dataset_GetLabProcedureByTabAndRequest.Reference) : "");
                    Unit.CalcValue = (dataset_GetLabProcedureByTabAndRequest != null ? Globals.ToStringCore(dataset_GetLabProcedureByTabAndRequest.Unit) : "");
                    OBJID.CalcValue = (dataset_GetLabProcedureByTabAndRequest != null ? Globals.ToStringCore(dataset_GetLabProcedureByTabAndRequest.ObjectID) : "");
                    WARNING.CalcValue = (dataset_GetLabProcedureByTabAndRequest != null ? Globals.ToStringCore(dataset_GetLabProcedureByTabAndRequest.Warning) : "");
                    WARNING.PostFieldValueCalculation();
                    Result1.CalcValue = Result1.Value;
                    Result2.CalcValue = Result2.Value;
                    REQ1.CalcValue = MyParentReport.TABORDER.REQUEST1.CalcValue;
                    REQ2.CalcValue = MyParentReport.TABORDER.REQUEST2.CalcValue;
                    TESTID.CalcValue = (dataset_GetLabProcedureByTabAndRequest != null ? Globals.ToStringCore(dataset_GetLabProcedureByTabAndRequest.ProcedureObject) : "");
                    WarningSign.CalcValue = WarningSign.Value;
                    REQ3.CalcValue = MyParentReport.TABORDER.REQUEST3.CalcValue;
                    Result3.CalcValue = Result3.Value;
                    RESULTDESCRIPTION.CalcValue = (dataset_GetLabProcedureByTabAndRequest != null ? Globals.ToStringCore(dataset_GetLabProcedureByTabAndRequest.ResultDescription) : "");
                    CURRENTSTATE.CalcValue = (dataset_GetLabProcedureByTabAndRequest != null ? Globals.ToStringCore(dataset_GetLabProcedureByTabAndRequest.CurrentStateDefID) : "");
                    SPECIALREF.CalcValue = (dataset_GetLabProcedureByTabAndRequest != null ? Globals.ToStringCore(dataset_GetLabProcedureByTabAndRequest.SpecialReference) : "");
                    return new TTReportObject[] { LaboratoryProcedureTestName,Result,Reference,Unit,OBJID,WARNING,Result1,Result2,REQ1,REQ2,TESTID,WarningSign,REQ3,Result3,RESULTDESCRIPTION,CURRENTSTATE,SPECIALREF};
                }
#region PARENT HEADER_Methods
            public bool IsValidGuid(string str)
        {
            Guid value;

            try
            {
                value = new Guid(str);
                return true;
            }
            catch(FormatException)
            {
                value = Guid.Empty;
                return false;
            }
        }
#endregion PARENT HEADER_Methods

                public override void RunScript()
                {
#region PARENT HEADER_Script
                    if(this.WARNING.CalcValue == TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(HighLowEnum.High)
               || this.WARNING.CalcValue == TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(HighLowEnum.Low)
               || this.WARNING.CalcValue == TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(HighLowEnum.Panic))
            {
                this.LaboratoryProcedureTestName.TextFont.Bold = true;
                this.Result.TextFont.Bold = true;
                this.Reference.TextFont.Bold = true;
                this.Unit.TextFont.Bold = true;
                this.WarningSign.CalcValue = "*";
            }
            else
            {
                this.LaboratoryProcedureTestName.TextFont.Bold = false;
                this.Result.TextFont.Bold = false;
                this.Reference.TextFont.Bold = false;
                this.Unit.TextFont.Bold = false;
                this.WarningSign.CalcValue = "";
            }
            bool hasReqID1 = false;
            bool hasReqID2 = false;
            bool hasReqID3 = false;
            
            if(this.REQ1.CalcValue != "REQUEST1")
                hasReqID1 = true;
            
            if(this.REQ2.CalcValue != "REQUEST2")
                hasReqID2 = true;
            
            if(this.REQ3.CalcValue != "REQUEST3")
                hasReqID3 = true;
            
            string testName = this.LaboratoryProcedureTestName.CalcValue;
            
            //ResultDescription ekleme
            TTObjectContext context = new TTObjectContext(true);
            //            string objectID = ((LaboratoryBarcodeResultReport)ParentReport).PARENT.OBJID.CalcValue.ToString();
            //            if(objectID != null)
            //            {
            //                LaboratoryProcedure laboratoryProcedure = (LaboratoryProcedure)context.GetObject(new Guid(objectID),"LaboratoryProcedure");
            //                if(laboratoryProcedure.ResultDescription != null)
            //                {
            //                    testName = testName + "\r\n" + "  Sonuç Açıklaması: " + laboratoryProcedure.ResultDescription.ToString();
            //                    this.LaboratoryProcedureTestName.CalcValue = testName;
            //                }
            //            }
            //
            
            //ResultDescription ekleme performans analiz sonrası
            string procResultDescription = ((LaboratoryBarcodeResultReport)ParentReport).PARENT.RESULTDESCRIPTION.CalcValue.ToString();
            if(procResultDescription != null && procResultDescription.Trim() != string.Empty)
            {
                testName = testName + "\r\n" + "  Sonuç Açıklaması: " + procResultDescription.ToString();
                this.LaboratoryProcedureTestName.CalcValue = testName;
            }
            else
            {
                this.LaboratoryProcedureTestName.CalcValue = testName;
            }
            //
            
            //Sonuç Durumu kontrol ediliyor...
            string testResultStatus = ((LaboratoryBarcodeResultReport)ParentReport).PARENT.CURRENTSTATE.CalcValue.ToString();
            if(testResultStatus != null && testResultStatus.Trim() != "a52a30e0-6ac7-4224-aa58-a994397c22f6")
            {
                if(testResultStatus.Trim() == "71d49852-7f5d-440e-af57-7e70522fb867")
                {
                    this.Result.CalcValue = "Reddedildi";
                }
                else if(testResultStatus.Trim() == "fc30e081-5b67-4564-99fd-17f75e57a1b2")
                {
                    this.Result.CalcValue = "İptal edildi";
                }
                else
                {
                    this.Result.CalcValue = "Sonuçlanmadı!";
                }
                
            }
            
            
            Guid testID = new Guid(this.TESTID.CalcValue);
            //TTObjectContext context = new TTObjectContext(true);
            if(hasReqID1)
            {
                if (this.IsValidGuid(this.REQ1.CalcValue))
                {
                    Guid ReqID1 = new Guid(this.REQ1.CalcValue);
                    BindingList<LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class> procedures1 = LaboratoryProcedure.GetLabProcedureByTestAndRequest(context, ReqID1, testID);
                    foreach (LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class procedure in procedures1)
                    {
                        this.Result1.CalcValue = procedure.Result;
                        break;
                    }
                }
            }

            if(hasReqID2)
            {
                if (this.IsValidGuid(this.REQ2.CalcValue))
                {
                    Guid ReqID2 = new Guid(this.REQ2.CalcValue);
                    BindingList<LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class> procedures2 = LaboratoryProcedure.GetLabProcedureByTestAndRequest(context, ReqID2, testID);
                    foreach (LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class procedure in procedures2)
                    {
                        this.Result2.CalcValue = procedure.Result;
                        break;
                    }
                }
            }

            if(hasReqID3)
            {
                if (this.IsValidGuid(this.REQ3.CalcValue))
                {
                    Guid ReqID3 = new Guid(this.REQ3.CalcValue);
                    BindingList<LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class> procedures3 = LaboratoryProcedure.GetLabProcedureByTestAndRequest(context, ReqID3, testID);
                    foreach (LaboratoryProcedure.GetLabProcedureByTestAndRequest_Class procedure in procedures3)
                    {
                        this.Result3.CalcValue = procedure.Result;
                        break;
                    }
                }
            }
#endregion PARENT HEADER_Script
                }
            }
            public partial class PARENTGroupFooter : TTReportSection
            {
                public LaboratoryBarcodeResultReport MyParentReport
                {
                    get { return (LaboratoryBarcodeResultReport)ParentReport; }
                }
                
                public TTReportRTF LongReportRTF; 
                public PARENTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                    LongReportRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 10, 0, 200, 1, false);
                    LongReportRTF.Name = "LongReportRTF";
                    LongReportRTF.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LongReportRTF.CalcValue = LongReportRTF.Value;
                    return new TTReportObject[] { LongReportRTF};
                }
                public override void RunPreScript()
                {
#region PARENT FOOTER_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            this.LongReportRTF.Value = null;
            string objectID = ((LaboratoryBarcodeResultReport)ParentReport).PARENT.OBJID.CalcValue.ToString();
            if(objectID != null)
            {
                LaboratoryProcedure laboratoryProcedure = (LaboratoryProcedure)context.GetObject(new Guid(objectID),"LaboratoryProcedure");  
                if(laboratoryProcedure.LongReport != null)
                    this.LongReportRTF.Value = laboratoryProcedure.LongReport.ToString();
            }
#endregion PARENT FOOTER_PreScript
                }
            }

        }

        public PARENTGroup PARENT;

        public partial class PANELGroup : TTReportGroup
        {
            public LaboratoryBarcodeResultReport MyParentReport
            {
                get { return (LaboratoryBarcodeResultReport)ParentReport; }
            }

            new public PANELGroupHeader Header()
            {
                return (PANELGroupHeader)_header;
            }

            new public PANELGroupFooter Footer()
            {
                return (PANELGroupFooter)_footer;
            }

            public TTReportField TESTDEFID { get {return Header().TESTDEFID;} }
            public PANELGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PANELGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<LaboratoryGridPanelTestDefinition.GetLabGridPanelsNQL_Class>("GetLabGridPanelsNQL", LaboratoryGridPanelTestDefinition.GetLabGridPanelsNQL((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.PARENT.TESTID.CalcValue)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PANELGroupHeader(this);
                _footer = new PANELGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PANELGroupHeader : TTReportSection
            {
                public LaboratoryBarcodeResultReport MyParentReport
                {
                    get { return (LaboratoryBarcodeResultReport)ParentReport; }
                }
                
                public TTReportField TESTDEFID; 
                public PANELGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    TESTDEFID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 0, 240, 5, false);
                    TESTDEFID.Name = "TESTDEFID";
                    TESTDEFID.Visible = EvetHayirEnum.ehHayir;
                    TESTDEFID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESTDEFID.TextFont.Name = "Arial Narrow";
                    TESTDEFID.TextFont.Size = 9;
                    TESTDEFID.TextFont.CharSet = 162;
                    TESTDEFID.Value = @"{#LABORATORYTEST#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratoryGridPanelTestDefinition.GetLabGridPanelsNQL_Class dataset_GetLabGridPanelsNQL = ParentGroup.rsGroup.GetCurrentRecord<LaboratoryGridPanelTestDefinition.GetLabGridPanelsNQL_Class>(0);
                    TESTDEFID.CalcValue = (dataset_GetLabGridPanelsNQL != null ? Globals.ToStringCore(dataset_GetLabGridPanelsNQL.LaboratoryTest) : "");
                    return new TTReportObject[] { TESTDEFID};
                }
            }
            public partial class PANELGroupFooter : TTReportSection
            {
                public LaboratoryBarcodeResultReport MyParentReport
                {
                    get { return (LaboratoryBarcodeResultReport)ParentReport; }
                }
                 
                public PANELGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PANELGroup PANEL;

        public partial class MAINGroup : TTReportGroup
        {
            public LaboratoryBarcodeResultReport MyParentReport
            {
                get { return (LaboratoryBarcodeResultReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField LaboratorySubProcedureObjectName { get {return Body().LaboratorySubProcedureObjectName;} }
            public TTReportField SubResult { get {return Body().SubResult;} }
            public TTReportField SubReference { get {return Body().SubReference;} }
            public TTReportField SubUnit { get {return Body().SubUnit;} }
            public TTReportField WARNING1 { get {return Body().WARNING1;} }
            public TTReportField SubResult1 { get {return Body().SubResult1;} }
            public TTReportField SubResult2 { get {return Body().SubResult2;} }
            public TTReportField REQ1 { get {return Body().REQ1;} }
            public TTReportField REQ2 { get {return Body().REQ2;} }
            public TTReportField TESTID { get {return Body().TESTID;} }
            public TTReportField WarningSignSub { get {return Body().WarningSignSub;} }
            public TTReportField REQ3 { get {return Body().REQ3;} }
            public TTReportField SubResult3 { get {return Body().SubResult3;} }
            public TTReportField LongReportForSubProcedure { get {return Body().LongReportForSubProcedure;} }
            public TTReportField UzunRaporLabel1 { get {return Body().UzunRaporLabel1;} }
            public TTReportField TESTOBJECTID { get {return Body().TESTOBJECTID;} }
            public TTReportField LONGREPORT { get {return Body().LONGREPORT;} }
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
                list[0] = new TTReportNqlData<LaboratorySubProcedure.GetLabSubProcByTestDef_Class>("GetLabSubProcByTestDef", LaboratorySubProcedure.GetLabSubProcByTestDef((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.PARENT.OBJID.CalcValue),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.PANEL.TESTDEFID.CalcValue)));
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
                public LaboratoryBarcodeResultReport MyParentReport
                {
                    get { return (LaboratoryBarcodeResultReport)ParentReport; }
                }
                
                public TTReportField LaboratorySubProcedureObjectName;
                public TTReportField SubResult;
                public TTReportField SubReference;
                public TTReportField SubUnit;
                public TTReportField WARNING1;
                public TTReportField SubResult1;
                public TTReportField SubResult2;
                public TTReportField REQ1;
                public TTReportField REQ2;
                public TTReportField TESTID;
                public TTReportField WarningSignSub;
                public TTReportField REQ3;
                public TTReportField SubResult3;
                public TTReportField LongReportForSubProcedure;
                public TTReportField UzunRaporLabel1;
                public TTReportField TESTOBJECTID;
                public TTReportField LONGREPORT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    LaboratorySubProcedureObjectName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 1, 66, 5, false);
                    LaboratorySubProcedureObjectName.Name = "LaboratorySubProcedureObjectName";
                    LaboratorySubProcedureObjectName.FieldType = ReportFieldTypeEnum.ftVariable;
                    LaboratorySubProcedureObjectName.MultiLine = EvetHayirEnum.ehEvet;
                    LaboratorySubProcedureObjectName.NoClip = EvetHayirEnum.ehEvet;
                    LaboratorySubProcedureObjectName.WordBreak = EvetHayirEnum.ehEvet;
                    LaboratorySubProcedureObjectName.ExpandTabs = EvetHayirEnum.ehEvet;
                    LaboratorySubProcedureObjectName.TextFont.Name = "Microsoft Sans Serif";
                    LaboratorySubProcedureObjectName.TextFont.Size = 8;
                    LaboratorySubProcedureObjectName.TextFont.CharSet = 162;
                    LaboratorySubProcedureObjectName.Value = @"{#NAME#}";

                    SubResult = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 1, 94, 5, false);
                    SubResult.Name = "SubResult";
                    SubResult.FieldType = ReportFieldTypeEnum.ftVariable;
                    SubResult.MultiLine = EvetHayirEnum.ehEvet;
                    SubResult.NoClip = EvetHayirEnum.ehEvet;
                    SubResult.WordBreak = EvetHayirEnum.ehEvet;
                    SubResult.ExpandTabs = EvetHayirEnum.ehEvet;
                    SubResult.TextFont.Name = "Microsoft Sans Serif";
                    SubResult.TextFont.Size = 8;
                    SubResult.TextFont.CharSet = 162;
                    SubResult.Value = @"{#RESULT#}";

                    SubReference = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 1, 155, 5, false);
                    SubReference.Name = "SubReference";
                    SubReference.FieldType = ReportFieldTypeEnum.ftVariable;
                    SubReference.MultiLine = EvetHayirEnum.ehEvet;
                    SubReference.NoClip = EvetHayirEnum.ehEvet;
                    SubReference.WordBreak = EvetHayirEnum.ehEvet;
                    SubReference.ExpandTabs = EvetHayirEnum.ehEvet;
                    SubReference.TextFont.Name = "Microsoft Sans Serif";
                    SubReference.TextFont.Size = 8;
                    SubReference.TextFont.CharSet = 162;
                    SubReference.Value = @"{#REFERENCE#}";

                    SubUnit = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 1, 122, 5, false);
                    SubUnit.Name = "SubUnit";
                    SubUnit.FieldType = ReportFieldTypeEnum.ftVariable;
                    SubUnit.MultiLine = EvetHayirEnum.ehEvet;
                    SubUnit.NoClip = EvetHayirEnum.ehEvet;
                    SubUnit.WordBreak = EvetHayirEnum.ehEvet;
                    SubUnit.ExpandTabs = EvetHayirEnum.ehEvet;
                    SubUnit.TextFont.Name = "Microsoft Sans Serif";
                    SubUnit.TextFont.Size = 8;
                    SubUnit.TextFont.CharSet = 162;
                    SubUnit.Value = @"{#UNIT#}";

                    WARNING1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 0, 231, 5, false);
                    WARNING1.Name = "WARNING1";
                    WARNING1.Visible = EvetHayirEnum.ehHayir;
                    WARNING1.FieldType = ReportFieldTypeEnum.ftVariable;
                    WARNING1.ObjectDefName = "HighLowEnum";
                    WARNING1.DataMember = "DISPLAYTEXT";
                    WARNING1.TextFont.Name = "Arial Narrow";
                    WARNING1.TextFont.Size = 9;
                    WARNING1.TextFont.CharSet = 162;
                    WARNING1.Value = @"{#WARNING#}";

                    SubResult1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 1, 172, 5, false);
                    SubResult1.Name = "SubResult1";
                    SubResult1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SubResult1.MultiLine = EvetHayirEnum.ehEvet;
                    SubResult1.NoClip = EvetHayirEnum.ehEvet;
                    SubResult1.WordBreak = EvetHayirEnum.ehEvet;
                    SubResult1.ExpandTabs = EvetHayirEnum.ehEvet;
                    SubResult1.TextFont.Name = "Microsoft Sans Serif";
                    SubResult1.TextFont.Size = 8;
                    SubResult1.TextFont.CharSet = 162;
                    SubResult1.Value = @"";

                    SubResult2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 1, 186, 5, false);
                    SubResult2.Name = "SubResult2";
                    SubResult2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SubResult2.MultiLine = EvetHayirEnum.ehEvet;
                    SubResult2.NoClip = EvetHayirEnum.ehEvet;
                    SubResult2.WordBreak = EvetHayirEnum.ehEvet;
                    SubResult2.ExpandTabs = EvetHayirEnum.ehEvet;
                    SubResult2.TextFont.Name = "Microsoft Sans Serif";
                    SubResult2.TextFont.Size = 8;
                    SubResult2.TextFont.CharSet = 162;
                    SubResult2.Value = @"";

                    REQ1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 233, 0, 241, 5, false);
                    REQ1.Name = "REQ1";
                    REQ1.Visible = EvetHayirEnum.ehHayir;
                    REQ1.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQ1.TextFont.Name = "Arial Narrow";
                    REQ1.TextFont.Size = 9;
                    REQ1.TextFont.CharSet = 162;
                    REQ1.Value = @"{%TABORDER.REQUEST1%}";

                    REQ2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 243, 0, 253, 5, false);
                    REQ2.Name = "REQ2";
                    REQ2.Visible = EvetHayirEnum.ehHayir;
                    REQ2.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQ2.TextFont.Name = "Arial Narrow";
                    REQ2.TextFont.Size = 9;
                    REQ2.TextFont.CharSet = 162;
                    REQ2.Value = @"{%TABORDER.REQUEST2%}";

                    TESTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 292, 0, 301, 5, false);
                    TESTID.Name = "TESTID";
                    TESTID.Visible = EvetHayirEnum.ehHayir;
                    TESTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESTID.TextFont.Name = "Arial Narrow";
                    TESTID.TextFont.Size = 9;
                    TESTID.TextFont.CharSet = 162;
                    TESTID.Value = @"{#PROCEDUREOBJECT#}";

                    WarningSignSub = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 1, 73, 5, false);
                    WarningSignSub.Name = "WarningSignSub";
                    WarningSignSub.TextFont.Name = "Microsoft Sans Serif";
                    WarningSignSub.TextFont.Size = 8;
                    WarningSignSub.TextFont.CharSet = 162;
                    WarningSignSub.Value = @"";

                    REQ3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 0, 264, 5, false);
                    REQ3.Name = "REQ3";
                    REQ3.Visible = EvetHayirEnum.ehHayir;
                    REQ3.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQ3.TextFont.Name = "Arial Narrow";
                    REQ3.TextFont.Size = 9;
                    REQ3.TextFont.CharSet = 162;
                    REQ3.Value = @"{%TABORDER.REQUEST3%}";

                    SubResult3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 1, 200, 5, false);
                    SubResult3.Name = "SubResult3";
                    SubResult3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SubResult3.MultiLine = EvetHayirEnum.ehEvet;
                    SubResult3.NoClip = EvetHayirEnum.ehEvet;
                    SubResult3.WordBreak = EvetHayirEnum.ehEvet;
                    SubResult3.ExpandTabs = EvetHayirEnum.ehEvet;
                    SubResult3.TextFont.Name = "Microsoft Sans Serif";
                    SubResult3.TextFont.Size = 8;
                    SubResult3.TextFont.CharSet = 162;
                    SubResult3.Value = @"";

                    LongReportForSubProcedure = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 1, 159, 5, false);
                    LongReportForSubProcedure.Name = "LongReportForSubProcedure";
                    LongReportForSubProcedure.Visible = EvetHayirEnum.ehHayir;
                    LongReportForSubProcedure.FieldType = ReportFieldTypeEnum.ftVariable;
                    LongReportForSubProcedure.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LongReportForSubProcedure.MultiLine = EvetHayirEnum.ehEvet;
                    LongReportForSubProcedure.NoClip = EvetHayirEnum.ehEvet;
                    LongReportForSubProcedure.WordBreak = EvetHayirEnum.ehEvet;
                    LongReportForSubProcedure.ExpandTabs = EvetHayirEnum.ehEvet;
                    LongReportForSubProcedure.TextFont.Name = "Arial Narrow";
                    LongReportForSubProcedure.TextFont.Size = 8;
                    LongReportForSubProcedure.TextFont.CharSet = 162;
                    LongReportForSubProcedure.Value = @"";

                    UzunRaporLabel1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 1, 92, 5, false);
                    UzunRaporLabel1.Name = "UzunRaporLabel1";
                    UzunRaporLabel1.Visible = EvetHayirEnum.ehHayir;
                    UzunRaporLabel1.TextFont.Name = "Arial";
                    UzunRaporLabel1.TextFont.Size = 8;
                    UzunRaporLabel1.TextFont.Bold = true;
                    UzunRaporLabel1.TextFont.CharSet = 162;
                    UzunRaporLabel1.Value = @"Uzun Rapor:";

                    TESTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, 0, 312, 5, false);
                    TESTOBJECTID.Name = "TESTOBJECTID";
                    TESTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TESTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESTOBJECTID.TextFont.Name = "Arial Narrow";
                    TESTOBJECTID.TextFont.Size = 9;
                    TESTOBJECTID.TextFont.CharSet = 162;
                    TESTOBJECTID.Value = @"{#OBJECTID#}";

                    LONGREPORT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 269, 0, 284, 5, false);
                    LONGREPORT.Name = "LONGREPORT";
                    LONGREPORT.Visible = EvetHayirEnum.ehHayir;
                    LONGREPORT.FieldType = ReportFieldTypeEnum.ftVariable;
                    LONGREPORT.TextFont.Name = "Arial Narrow";
                    LONGREPORT.TextFont.CharSet = 1;
                    LONGREPORT.Value = @"{#LONGREPORT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LaboratorySubProcedure.GetLabSubProcByTestDef_Class dataset_GetLabSubProcByTestDef = ParentGroup.rsGroup.GetCurrentRecord<LaboratorySubProcedure.GetLabSubProcByTestDef_Class>(0);
                    LaboratorySubProcedureObjectName.CalcValue = (dataset_GetLabSubProcByTestDef != null ? Globals.ToStringCore(dataset_GetLabSubProcByTestDef.Name) : "");
                    SubResult.CalcValue = (dataset_GetLabSubProcByTestDef != null ? Globals.ToStringCore(dataset_GetLabSubProcByTestDef.Result) : "");
                    SubReference.CalcValue = (dataset_GetLabSubProcByTestDef != null ? Globals.ToStringCore(dataset_GetLabSubProcByTestDef.Reference) : "");
                    SubUnit.CalcValue = (dataset_GetLabSubProcByTestDef != null ? Globals.ToStringCore(dataset_GetLabSubProcByTestDef.Unit) : "");
                    WARNING1.CalcValue = (dataset_GetLabSubProcByTestDef != null ? Globals.ToStringCore(dataset_GetLabSubProcByTestDef.Warning) : "");
                    WARNING1.PostFieldValueCalculation();
                    SubResult1.CalcValue = SubResult1.Value;
                    SubResult2.CalcValue = SubResult2.Value;
                    REQ1.CalcValue = MyParentReport.TABORDER.REQUEST1.CalcValue;
                    REQ2.CalcValue = MyParentReport.TABORDER.REQUEST2.CalcValue;
                    TESTID.CalcValue = (dataset_GetLabSubProcByTestDef != null ? Globals.ToStringCore(dataset_GetLabSubProcByTestDef.ProcedureObject) : "");
                    WarningSignSub.CalcValue = WarningSignSub.Value;
                    REQ3.CalcValue = MyParentReport.TABORDER.REQUEST3.CalcValue;
                    SubResult3.CalcValue = SubResult3.Value;
                    LongReportForSubProcedure.CalcValue = @"";
                    UzunRaporLabel1.CalcValue = UzunRaporLabel1.Value;
                    TESTOBJECTID.CalcValue = (dataset_GetLabSubProcByTestDef != null ? Globals.ToStringCore(dataset_GetLabSubProcByTestDef.ObjectID) : "");
                    LONGREPORT.CalcValue = (dataset_GetLabSubProcByTestDef != null ? Globals.ToStringCore(dataset_GetLabSubProcByTestDef.LongReport) : "");
                    return new TTReportObject[] { LaboratorySubProcedureObjectName,SubResult,SubReference,SubUnit,WARNING1,SubResult1,SubResult2,REQ1,REQ2,TESTID,WarningSignSub,REQ3,SubResult3,LongReportForSubProcedure,UzunRaporLabel1,TESTOBJECTID,LONGREPORT};
                }
#region MAIN BODY_Methods
            public bool IsValidGuid(string str)
        {
            Guid value;

            try
            {
                value = new Guid(str);
                return true;
            }
            catch(FormatException)
            {
                value = Guid.Empty;
                return false;
            }
        }
#endregion MAIN BODY_Methods

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if(this.WARNING1.CalcValue == TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(HighLowEnum.High)
               || this.WARNING1.CalcValue == TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(HighLowEnum.Low)
               || this.WARNING1.CalcValue == TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(HighLowEnum.Panic))
            {
                this.LaboratorySubProcedureObjectName.TextFont.Bold = true;
                this.SubResult.TextFont.Bold = true;
                this.SubReference.TextFont.Bold = true;
                this.SubUnit.TextFont.Bold = true;
                this.WarningSignSub.CalcValue = "*";
            }
            else
            {
                this.LaboratorySubProcedureObjectName.TextFont.Bold = false;
                this.SubResult.TextFont.Bold = false;
                this.SubReference.TextFont.Bold = false;
                this.SubUnit.TextFont.Bold = false;
                this.WarningSignSub.CalcValue = "";
            }
            
            bool hasReqID1 = false;
            bool hasReqID2 = false;
            bool hasReqID3 = false;
            
            if(this.REQ1.CalcValue != "REQUEST1")
                hasReqID1 = true;
            
            if(this.REQ2.CalcValue != "REQUEST2")
                hasReqID2 = true;
            
            if(this.REQ3.CalcValue != "REQUEST2")
                hasReqID3 = true;
            
            Guid testID = new Guid(this.TESTID.CalcValue);
            TTObjectContext context = new TTObjectContext(true);
            
            string longReportSign = ((LaboratoryBarcodeResultReport)ParentReport).MAIN.LONGREPORT.CalcValue.ToString();
            
            if(longReportSign != null && longReportSign.Trim() != string.Empty)
            {
                
                //
                string objectID = ((LaboratoryBarcodeResultReport)ParentReport).MAIN.TESTOBJECTID.CalcValue.ToString();
                //string text = string.Empty;
                string text = this.LaboratorySubProcedureObjectName.CalcValue;
                
                LaboratorySubProcedure laboratorySubProcedure = (LaboratorySubProcedure)context.GetObject(new Guid(objectID),"LaboratorySubProcedure");
                
                if(laboratorySubProcedure.LongReport != null)
                {
                    string longReportForSubProcedure = TTObjectClasses.Common.GetTextOfRTFString(laboratorySubProcedure.LongReport.ToString());
                    longReportForSubProcedure = longReportForSubProcedure.Replace("  ", " ");
                    longReportForSubProcedure = longReportForSubProcedure.Replace("\r\n", "");
                    longReportForSubProcedure = longReportForSubProcedure.Replace("\r", "");
                    longReportForSubProcedure = longReportForSubProcedure.Replace("\n", "");
                    
                    if(longReportForSubProcedure.Trim() != string.Empty)
                    {
                        text = text + "\r\n     Rapor: "+longReportForSubProcedure+"  ";
                        this.LaboratorySubProcedureObjectName.CalcValue = text.ToString();
                        //text = text + longReportForSubProcedure;
                        //this.LongReportForSubProcedure.CalcValue = text.ToString();
                        //this.LongReportForSubProcedure.Visible = EvetHayirEnum.ehEvet; //***Başlangıçta gizlenmişti.Burada görüntüleniyor...
                        //this.UzunRaporLabel.Visible = EvetHayirEnum.ehEvet; //***Başlangıçta gizlenmişti.Burada görüntüleniyor...
                    }
                }
            }
            
            //
            
            
            
            if(hasReqID1)
            {
                if (this.IsValidGuid(this.REQ1.CalcValue))
                {
                    Guid ReqID1 = new Guid(this.REQ1.CalcValue);
                    BindingList<LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest_Class> procedures1 = LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest(context, ReqID1, testID);
                    foreach (LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest_Class procedure in procedures1)
                    {
                        this.SubResult1.CalcValue = procedure.Result;
                        break;
                    }
                }
            }

            if(hasReqID2)
            {
                if (this.IsValidGuid(this.REQ2.CalcValue))
                {
                    Guid ReqID2 = new Guid(this.REQ2.CalcValue);
                    BindingList<LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest_Class> procedures2 = LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest(context, ReqID2, testID);
                    foreach (LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest_Class procedure in procedures2)
                    {
                        this.SubResult2.CalcValue = procedure.Result;
                        break;
                    }
                }
            }
            
            if(hasReqID3)
            {
                if (this.IsValidGuid(this.REQ3.CalcValue))
                {
                    Guid ReqID3 = new Guid(this.REQ3.CalcValue);
                    BindingList<LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest_Class> procedures3 = LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest(context, ReqID3, testID);
                    foreach (LaboratorySubProcedure.GetLabSubProcedureByTestAndRequest_Class procedure in procedures3)
                    {
                        this.SubResult3.CalcValue = procedure.Result;
                        break;
                    }
                }
            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class REFERENCEGroup : TTReportGroup
        {
            public LaboratoryBarcodeResultReport MyParentReport
            {
                get { return (LaboratoryBarcodeResultReport)ParentReport; }
            }

            new public REFERENCEGroupBody Body()
            {
                return (REFERENCEGroupBody)_body;
            }
            public TTReportRTF SpecialRefer { get {return Body().SpecialRefer;} }
            public REFERENCEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public REFERENCEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new REFERENCEGroupBody(this);
            }

            public partial class REFERENCEGroupBody : TTReportSection
            {
                public LaboratoryBarcodeResultReport MyParentReport
                {
                    get { return (LaboratoryBarcodeResultReport)ParentReport; }
                }
                
                public TTReportRTF SpecialRefer; 
                public REFERENCEGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 1;
                    RepeatCount = 0;
                    
                    SpecialRefer = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 123, 0, 180, 1, false);
                    SpecialRefer.Name = "SpecialRefer";
                    SpecialRefer.Visible = EvetHayirEnum.ehHayir;
                    SpecialRefer.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SpecialRefer.CalcValue = SpecialRefer.Value;
                    return new TTReportObject[] { SpecialRefer};
                }
                public override void RunPreScript()
                {
#region REFERENCE BODY_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string objectID = ((LaboratoryBarcodeResultReport)ParentReport).PARENT.OBJID.CalcValue.ToString();
            string specialRef_Str = ((LaboratoryBarcodeResultReport)ParentReport).PARENT.SPECIALREF.CalcValue.ToString();
            
            if(objectID != null && specialRef_Str != null && specialRef_Str != string.Empty)
            {
                LaboratoryProcedure laboratoryProcedure = (LaboratoryProcedure)context.GetObject(new Guid(objectID),"LaboratoryProcedure");
                if(laboratoryProcedure.SpecialReference != null)
                    this.SpecialRefer.Value = laboratoryProcedure.SpecialReference.ToString();
                else
                    this.SpecialRefer.Value = null;
            }
            
            if(this.SpecialRefer.Value == null)
                this.SpecialRefer.Visible = EvetHayirEnum.ehHayir;
#endregion REFERENCE BODY_PreScript
                }
            }

        }

        public REFERENCEGroup REFERENCE;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public LaboratoryBarcodeResultReport()
        {
            TOP = new TOPGroup(this,"TOP");
            HEADER = new HEADERGroup(TOP,"HEADER");
            TABORDER = new TABORDERGroup(HEADER,"TABORDER");
            TAB = new TABGroup(TABORDER,"TAB");
            GROUP = new GROUPGroup(TAB,"GROUP");
            PARENT = new PARENTGroup(GROUP,"PARENT");
            PANEL = new PANELGroup(PARENT,"PANEL");
            MAIN = new MAINGroup(PANEL,"MAIN");
            REFERENCE = new REFERENCEGroup(PANEL,"REFERENCE");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("BARCODEID", "", "Örnek Numarası", @"", false, false, false, new Guid("c573f560-55ee-4514-8ef8-380110697129"));
            reportParameter = Parameters.Add("TTOBJECTID", "", "LaboratuvarIslemID", @"", false, false, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("BARCODEID"))
                _runtimeParameters.BARCODEID = (long?)TTObjectDefManager.Instance.DataTypes["Long9"].ConvertValue(parameters["BARCODEID"]);
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "LABORATORYBARCODERESULTREPORT";
            Caption = "Barkodlu Laboratuvar Sonuç Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            PaperSize = 10;
            UsePrinterMargins = EvetHayirEnum.ehEvet;
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
            fd.TextFont.Name = "Courier New";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 0;
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