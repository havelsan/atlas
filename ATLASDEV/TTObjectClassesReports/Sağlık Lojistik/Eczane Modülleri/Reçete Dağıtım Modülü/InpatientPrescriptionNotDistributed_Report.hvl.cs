
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
    /// Dağıtımı Yapılmamış Reçete Listesi
    /// </summary>
    public partial class InpatientPrescriptionNotDistributed : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? DATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public InpatientPrescriptionNotDistributed MyParentReport
            {
                get { return (InpatientPrescriptionNotDistributed)ParentReport; }
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
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField1142 { get {return Header().NewField1142;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportShape NewLine1111111 { get {return Footer().NewLine1111111;} }
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
                public InpatientPrescriptionNotDistributed MyParentReport
                {
                    get { return (InpatientPrescriptionNotDistributed)ParentReport; }
                }
                
                public TTReportField HEADER;
                public TTReportField DATE;
                public TTReportField NewField11;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField112;
                public TTReportField NewField1111;
                public TTReportField NewField1142; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 40;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 15, 205, 24, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.NoClip = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Name = "Arial";
                    HEADER.TextFont.Bold = true;
                    HEADER.TextFont.CharSet = 162;
                    HEADER.Value = @"XXXXXX XXXXXXLIĞI BAŞECZACILIĞI KLİNİK ECZANESİ ŞEFLİĞİNİN
{%DATE%} TARİHİNE AİT DAĞILIMI YAPILMAMIŞ REÇETE LİSTESİDİR.";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 309, 15, 334, 20, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"Short Date";
                    DATE.Value = @"{@DATE@}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 28, 18, 37, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"SIRA
NU.";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 28, 120, 37, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"PROTOKOL
NU.";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 28, 174, 37, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Size = 9;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"KLİNİK ADI";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 28, 205, 37, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Size = 9;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"REÇETE BEDELİ";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 28, 39, 37, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112.TextFont.Name = "Arial";
                    NewField112.TextFont.Size = 9;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"GÜNLÜK
REÇETE NU.";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 28, 81, 37, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 9;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"HASTA ADI SOYADI";

                    NewField1142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 28, 101, 37, false);
                    NewField1142.Name = "NewField1142";
                    NewField1142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1142.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1142.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1142.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1142.TextFont.Name = "Arial";
                    NewField1142.TextFont.Size = 9;
                    NewField1142.TextFont.Bold = true;
                    NewField1142.TextFont.CharSet = 162;
                    NewField1142.Value = @"KARANTİNA
NU.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DATE.CalcValue = MyParentReport.RuntimeParameters.DATE.ToString();
                    HEADER.CalcValue = @"XXXXXX XXXXXXLIĞI BAŞECZACILIĞI KLİNİK ECZANESİ ŞEFLİĞİNİN
" + MyParentReport.PARTA.DATE.FormattedValue + @" TARİHİNE AİT DAĞILIMI YAPILMAMIŞ REÇETE LİSTESİDİR.";
                    NewField11.CalcValue = NewField11.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1142.CalcValue = NewField1142.Value;
                    return new TTReportObject[] { DATE,HEADER,NewField11,NewField121,NewField131,NewField141,NewField112,NewField1111,NewField1142};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public InpatientPrescriptionNotDistributed MyParentReport
                {
                    get { return (InpatientPrescriptionNotDistributed)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportShape NewLine1111111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 15;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 35, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 0, 120, 5, false);
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

                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 205, 0, false);
                    NewLine1111111.Name = "NewLine1111111";
                    NewLine1111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111111.DrawWidth = 2;

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
            public static int count = 0;
        public static double totalPrice = 0;
#endregion PARTA_Methods
        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public InpatientPrescriptionNotDistributed MyParentReport
            {
                get { return (InpatientPrescriptionNotDistributed)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public TTReportField PRICE { get {return Body().PRICE;} }
            public TTReportField CLINICNAME { get {return Body().CLINICNAME;} }
            public TTReportField PROTOCOLNO { get {return Body().PROTOCOLNO;} }
            public TTReportField DAILYNO { get {return Body().DAILYNO;} }
            public TTReportField PATIENTNAME { get {return Body().PATIENTNAME;} }
            public TTReportField QUARANTINENO { get {return Body().QUARANTINENO;} }
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
                list[0] = new TTReportNqlData<PrescriptionDistribute.GetInpatientPrescriptionNotDistributedReportQuery_Class>("GetInpatientPrescriptionNotDistributedReportQuery", PrescriptionDistribute.GetInpatientPrescriptionNotDistributedReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.DATE)));
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
                public InpatientPrescriptionNotDistributed MyParentReport
                {
                    get { return (InpatientPrescriptionNotDistributed)ParentReport; }
                }
                
                public TTReportField ORDERNO;
                public TTReportField PRICE;
                public TTReportField CLINICNAME;
                public TTReportField PROTOCOLNO;
                public TTReportField DAILYNO;
                public TTReportField PATIENTNAME;
                public TTReportField QUARANTINENO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 18, 5, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.Size = 9;
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{@counter@}.";

                    PRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 0, 205, 5, false);
                    PRICE.Name = "PRICE";
                    PRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    PRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICE.TextFormat = @"Currency";
                    PRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PRICE.TextFont.Name = "Arial";
                    PRICE.TextFont.Size = 9;
                    PRICE.TextFont.CharSet = 162;
                    PRICE.Value = @"{#PRICE#}";

                    CLINICNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 0, 174, 5, false);
                    CLINICNAME.Name = "CLINICNAME";
                    CLINICNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    CLINICNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLINICNAME.WordBreak = EvetHayirEnum.ehEvet;
                    CLINICNAME.TextFont.Name = "Arial";
                    CLINICNAME.TextFont.Size = 9;
                    CLINICNAME.TextFont.CharSet = 162;
                    CLINICNAME.Value = @" {#CLINICNAME#}";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 0, 120, 5, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.DrawStyle = DrawStyleConstants.vbSolid;
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.TextFont.Name = "Arial";
                    PROTOCOLNO.TextFont.Size = 9;
                    PROTOCOLNO.TextFont.CharSet = 162;
                    PROTOCOLNO.Value = @" {#PATIENTPROTOCOLNO#}";

                    DAILYNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 0, 39, 5, false);
                    DAILYNO.Name = "DAILYNO";
                    DAILYNO.DrawStyle = DrawStyleConstants.vbSolid;
                    DAILYNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAILYNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DAILYNO.TextFont.Name = "Arial";
                    DAILYNO.TextFont.Size = 9;
                    DAILYNO.TextFont.CharSet = 162;
                    DAILYNO.Value = @"{#DAILYNO#}";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 0, 81, 5, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTNAME.TextFont.Name = "Arial";
                    PATIENTNAME.TextFont.Size = 9;
                    PATIENTNAME.TextFont.CharSet = 162;
                    PATIENTNAME.Value = @" {#PATIENTNAME#}";

                    QUARANTINENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 0, 101, 5, false);
                    QUARANTINENO.Name = "QUARANTINENO";
                    QUARANTINENO.DrawStyle = DrawStyleConstants.vbSolid;
                    QUARANTINENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    QUARANTINENO.TextFont.Name = "Arial";
                    QUARANTINENO.TextFont.Size = 9;
                    QUARANTINENO.TextFont.CharSet = 162;
                    QUARANTINENO.Value = @" {#PATIENTQUARANTINENO#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrescriptionDistribute.GetInpatientPrescriptionNotDistributedReportQuery_Class dataset_GetInpatientPrescriptionNotDistributedReportQuery = ParentGroup.rsGroup.GetCurrentRecord<PrescriptionDistribute.GetInpatientPrescriptionNotDistributedReportQuery_Class>(0);
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString() + @".";
                    PRICE.CalcValue = (dataset_GetInpatientPrescriptionNotDistributedReportQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionNotDistributedReportQuery.Price) : "");
                    CLINICNAME.CalcValue = @" " + (dataset_GetInpatientPrescriptionNotDistributedReportQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionNotDistributedReportQuery.Clinicname) : "");
                    PROTOCOLNO.CalcValue = @" " + (dataset_GetInpatientPrescriptionNotDistributedReportQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionNotDistributedReportQuery.PatientProtocolNo) : "");
                    DAILYNO.CalcValue = (dataset_GetInpatientPrescriptionNotDistributedReportQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionNotDistributedReportQuery.Dailyno) : "");
                    PATIENTNAME.CalcValue = @" " + (dataset_GetInpatientPrescriptionNotDistributedReportQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionNotDistributedReportQuery.PatientName) : "");
                    QUARANTINENO.CalcValue = @" " + (dataset_GetInpatientPrescriptionNotDistributedReportQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionNotDistributedReportQuery.PatientQuarantineNo) : "");
                    return new TTReportObject[] { ORDERNO,PRICE,CLINICNAME,PROTOCOLNO,DAILYNO,PATIENTNAME,QUARANTINENO};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    PARTAGroup.count++;
            PARTAGroup.totalPrice += Convert.ToDouble(PRICE.CalcValue);
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class MAIN2Group : TTReportGroup
        {
            public InpatientPrescriptionNotDistributed MyParentReport
            {
                get { return (InpatientPrescriptionNotDistributed)ParentReport; }
            }

            new public MAIN2GroupBody Body()
            {
                return (MAIN2GroupBody)_body;
            }
            public TTReportField TOTAL { get {return Body().TOTAL;} }
            public TTReportField COUNTTEXT { get {return Body().COUNTTEXT;} }
            public MAIN2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAIN2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAIN2GroupBody(this);
            }

            public partial class MAIN2GroupBody : TTReportSection
            {
                public InpatientPrescriptionNotDistributed MyParentReport
                {
                    get { return (InpatientPrescriptionNotDistributed)ParentReport; }
                }
                
                public TTReportField TOTAL;
                public TTReportField COUNTTEXT; 
                public MAIN2GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 3, 205, 8, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TOTAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTAL.TextFont.Name = "Arial";
                    TOTAL.TextFont.Size = 9;
                    TOTAL.TextFont.CharSet = 162;
                    TOTAL.Value = @"";

                    COUNTTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 2, 242, 7, false);
                    COUNTTEXT.Name = "COUNTTEXT";
                    COUNTTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNTTEXT.TextFormat = @"NUMBERTEXT";
                    COUNTTEXT.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOTAL.CalcValue = @"";
                    COUNTTEXT.CalcValue = @"";
                    return new TTReportObject[] { TOTAL,COUNTTEXT};
                }

                public override void RunScript()
                {
#region MAIN2 BODY_Script
                    COUNTTEXT.CalcValue = PARTAGroup.count.ToString();
            TOTAL.CalcValue = MyParentReport.RuntimeParameters.DATE.Value.ToShortDateString() + " TARİHİNE AİT TOPLAM "
                + PARTAGroup.count.ToString() + " (" + COUNTTEXT.FormattedValue + ") ADET REÇETE BEDELİ " + PARTAGroup.totalPrice.ToString() + " TL DİR.";
            PARTAGroup.count = 0;
            PARTAGroup.totalPrice = 0;
#endregion MAIN2 BODY_Script
                }
            }

        }

        public MAIN2Group MAIN2;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public InpatientPrescriptionNotDistributed()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            MAIN2 = new MAIN2Group(PARTA,"MAIN2");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("DATE", "", "Tarih Seçiniz :", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("DATE"))
                _runtimeParameters.DATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["DATE"]);
            Name = "INPATIENTPRESCRIPTIONNOTDISTRIBUTED";
            Caption = "Dağıtımı Yapılmamış Reçete Listesi";
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