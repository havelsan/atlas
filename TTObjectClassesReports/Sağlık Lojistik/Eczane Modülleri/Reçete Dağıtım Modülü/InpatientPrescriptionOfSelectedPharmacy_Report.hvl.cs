
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
    /// Seçilen Eczaneye Ait Yatan Hasta Reçetelerinin Listesi
    /// </summary>
    public partial class InpatientPrescriptionOfSelectedPharmacy : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? PHARMACYID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public DateTime? DATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public InpatientPrescriptionOfSelectedPharmacy MyParentReport
            {
                get { return (InpatientPrescriptionOfSelectedPharmacy)ParentReport; }
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
            public TTReportField NewField1112 { get {return Header().NewField1112;} }
            public TTReportField NewField1142 { get {return Header().NewField1142;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
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
                public InpatientPrescriptionOfSelectedPharmacy MyParentReport
                {
                    get { return (InpatientPrescriptionOfSelectedPharmacy)ParentReport; }
                }
                
                public TTReportField HEADER;
                public TTReportField DATE;
                public TTReportField NewField11;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField112;
                public TTReportField NewField1111;
                public TTReportField NewField1112;
                public TTReportField NewField1142;
                public TTReportField NewField111; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 45;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 15, 290, 24, false);
                    HEADER.Name = "HEADER";
                    HEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.NoClip = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Name = "Arial";
                    HEADER.TextFont.Bold = true;
                    HEADER.TextFont.CharSet = 162;
                    HEADER.Value = @"XXXXXX XXXXXXLIĞI BAŞECZACILIĞI KLİNİK ECZANESİ ŞEFLİĞİNİN
{%DATE%} TARİHİNE AİT YATAN HASTA REÇETELERİNİN LİSTESİDİR.";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 309, 15, 334, 20, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"Short Date";
                    DATE.Value = @"{@DATE@}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 28, 19, 37, false);
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

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 28, 121, 37, false);
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

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 28, 185, 37, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Size = 9;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"KLİNİK ADI";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 28, 290, 37, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Size = 9;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"TESLİM ALANIN ADI
SOYADI VE İMZASI";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 28, 40, 37, false);
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

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 28, 82, 37, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 9;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"HASTA ADI SOYADI";

                    NewField1112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 28, 224, 37, false);
                    NewField1112.Name = "NewField1112";
                    NewField1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112.TextFont.Name = "Arial";
                    NewField1112.TextFont.Size = 9;
                    NewField1112.TextFont.Bold = true;
                    NewField1112.TextFont.CharSet = 162;
                    NewField1112.Value = @"DOKTOR ADI";

                    NewField1142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 28, 102, 37, false);
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

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 28, 254, 37, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 9;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"REÇETE BEDELİ";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    DATE.CalcValue = MyParentReport.RuntimeParameters.DATE.ToString();
                    HEADER.CalcValue = @"XXXXXX XXXXXXLIĞI BAŞECZACILIĞI KLİNİK ECZANESİ ŞEFLİĞİNİN
" + MyParentReport.PARTA.DATE.FormattedValue + @" TARİHİNE AİT YATAN HASTA REÇETELERİNİN LİSTESİDİR.";
                    NewField11.CalcValue = NewField11.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1112.CalcValue = NewField1112.Value;
                    NewField1142.CalcValue = NewField1142.Value;
                    NewField111.CalcValue = NewField111.Value;
                    return new TTReportObject[] { DATE,HEADER,NewField11,NewField121,NewField131,NewField141,NewField112,NewField1111,NewField1112,NewField1142,NewField111};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public InpatientPrescriptionOfSelectedPharmacy MyParentReport
                {
                    get { return (InpatientPrescriptionOfSelectedPharmacy)ParentReport; }
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

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 0, 160, 5, false);
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

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 0, 290, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Name = "Arial";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine1111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 290, 0, false);
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

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public InpatientPrescriptionOfSelectedPharmacy MyParentReport
            {
                get { return (InpatientPrescriptionOfSelectedPharmacy)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField ORDERNO { get {return Header().ORDERNO;} }
            public TTReportField CLINICNAME { get {return Header().CLINICNAME;} }
            public TTReportField PROTOCOLNO { get {return Header().PROTOCOLNO;} }
            public TTReportField DAILYNO { get {return Header().DAILYNO;} }
            public TTReportField PATIENTNAME { get {return Header().PATIENTNAME;} }
            public TTReportField DOCTORNAME { get {return Header().DOCTORNAME;} }
            public TTReportField QUARANTINENO { get {return Header().QUARANTINENO;} }
            public TTReportField BALANCE { get {return Header().BALANCE;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField11112 { get {return Header().NewField11112;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField PRESCRIPTIONID { get {return Header().PRESCRIPTIONID;} }
            public TTReportShape NewLine2 { get {return Footer().NewLine2;} }
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
                list[0] = new TTReportNqlData<PrescriptionDistribute.GetInpatientPrescriptionOfSelectedPharmacyQuery_Class>("GetInpatientPrescriptionOfSelectedPharmacyQuery", PrescriptionDistribute.GetInpatientPrescriptionOfSelectedPharmacyQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.PHARMACYID),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.DATE)));
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
                public InpatientPrescriptionOfSelectedPharmacy MyParentReport
                {
                    get { return (InpatientPrescriptionOfSelectedPharmacy)ParentReport; }
                }
                
                public TTReportField ORDERNO;
                public TTReportField CLINICNAME;
                public TTReportField PROTOCOLNO;
                public TTReportField DAILYNO;
                public TTReportField PATIENTNAME;
                public TTReportField DOCTORNAME;
                public TTReportField QUARANTINENO;
                public TTReportField BALANCE;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField11111;
                public TTReportField NewField11112;
                public TTReportShape NewLine1;
                public TTReportField PRESCRIPTIONID; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 15;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 19, 9, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNO.TextFont.Name = "Arial";
                    ORDERNO.TextFont.Size = 9;
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{@counter@}.";

                    CLINICNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 0, 185, 9, false);
                    CLINICNAME.Name = "CLINICNAME";
                    CLINICNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    CLINICNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLINICNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CLINICNAME.MultiLine = EvetHayirEnum.ehEvet;
                    CLINICNAME.WordBreak = EvetHayirEnum.ehEvet;
                    CLINICNAME.TextFont.Name = "Arial";
                    CLINICNAME.TextFont.Size = 9;
                    CLINICNAME.TextFont.CharSet = 162;
                    CLINICNAME.Value = @" {#CLINICNAME#}";

                    PROTOCOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 0, 121, 9, false);
                    PROTOCOLNO.Name = "PROTOCOLNO";
                    PROTOCOLNO.DrawStyle = DrawStyleConstants.vbSolid;
                    PROTOCOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOCOLNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PROTOCOLNO.TextFont.Name = "Arial";
                    PROTOCOLNO.TextFont.Size = 9;
                    PROTOCOLNO.TextFont.CharSet = 162;
                    PROTOCOLNO.Value = @" {#PATIENTPROTOCOLNO#}";

                    DAILYNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 0, 40, 9, false);
                    DAILYNO.Name = "DAILYNO";
                    DAILYNO.DrawStyle = DrawStyleConstants.vbSolid;
                    DAILYNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAILYNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DAILYNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DAILYNO.TextFont.Name = "Arial";
                    DAILYNO.TextFont.Size = 9;
                    DAILYNO.TextFont.CharSet = 162;
                    DAILYNO.Value = @"{#DAILYNO#}";

                    PATIENTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 82, 9, false);
                    PATIENTNAME.Name = "PATIENTNAME";
                    PATIENTNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    PATIENTNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PATIENTNAME.MultiLine = EvetHayirEnum.ehEvet;
                    PATIENTNAME.WordBreak = EvetHayirEnum.ehEvet;
                    PATIENTNAME.TextFont.Name = "Arial";
                    PATIENTNAME.TextFont.Size = 9;
                    PATIENTNAME.TextFont.CharSet = 162;
                    PATIENTNAME.Value = @" {#PATIENTNAME#}";

                    DOCTORNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 0, 224, 9, false);
                    DOCTORNAME.Name = "DOCTORNAME";
                    DOCTORNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    DOCTORNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTORNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOCTORNAME.MultiLine = EvetHayirEnum.ehEvet;
                    DOCTORNAME.TextFont.Name = "Arial";
                    DOCTORNAME.TextFont.Size = 9;
                    DOCTORNAME.TextFont.CharSet = 162;
                    DOCTORNAME.Value = @" {#DOCTORNAME#}";

                    QUARANTINENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 0, 102, 9, false);
                    QUARANTINENO.Name = "QUARANTINENO";
                    QUARANTINENO.DrawStyle = DrawStyleConstants.vbSolid;
                    QUARANTINENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    QUARANTINENO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    QUARANTINENO.TextFont.Name = "Arial";
                    QUARANTINENO.TextFont.Size = 9;
                    QUARANTINENO.TextFont.CharSet = 162;
                    QUARANTINENO.Value = @" {#PATIENTQUARANTINENO#}";

                    BALANCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 0, 254, 9, false);
                    BALANCE.Name = "BALANCE";
                    BALANCE.DrawStyle = DrawStyleConstants.vbSolid;
                    BALANCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BALANCE.TextFormat = @"Currency";
                    BALANCE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BALANCE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BALANCE.TextFont.Name = "Arial";
                    BALANCE.TextFont.Size = 9;
                    BALANCE.TextFont.CharSet = 162;
                    BALANCE.Value = @"{#PRICE#}";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 9, 161, 13, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 8;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"İlaç Adı";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 9, 185, 13, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.TextFont.Name = "Arial";
                    NewField1111.TextFont.Size = 8;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Miktarı";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 9, 224, 13, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.TextFont.Name = "Arial";
                    NewField11111.TextFont.Size = 8;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Fiyatı";

                    NewField11112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 9, 254, 13, false);
                    NewField11112.Name = "NewField11112";
                    NewField11112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11112.TextFont.Name = "Arial";
                    NewField11112.TextFont.Size = 8;
                    NewField11112.TextFont.Bold = true;
                    NewField11112.TextFont.CharSet = 162;
                    NewField11112.Value = @"Tutarı";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 290, 0, 290, 13, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    PRESCRIPTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 311, 4, 336, 9, false);
                    PRESCRIPTIONID.Name = "PRESCRIPTIONID";
                    PRESCRIPTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRESCRIPTIONID.Value = @"{#PRESCRIPTIONID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrescriptionDistribute.GetInpatientPrescriptionOfSelectedPharmacyQuery_Class dataset_GetInpatientPrescriptionOfSelectedPharmacyQuery = ParentGroup.rsGroup.GetCurrentRecord<PrescriptionDistribute.GetInpatientPrescriptionOfSelectedPharmacyQuery_Class>(0);
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString() + @".";
                    CLINICNAME.CalcValue = @" " + (dataset_GetInpatientPrescriptionOfSelectedPharmacyQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionOfSelectedPharmacyQuery.Clinicname) : "");
                    PROTOCOLNO.CalcValue = @" " + (dataset_GetInpatientPrescriptionOfSelectedPharmacyQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionOfSelectedPharmacyQuery.PatientProtocolNo) : "");
                    DAILYNO.CalcValue = (dataset_GetInpatientPrescriptionOfSelectedPharmacyQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionOfSelectedPharmacyQuery.Dailyno) : "");
                    PATIENTNAME.CalcValue = @" " + (dataset_GetInpatientPrescriptionOfSelectedPharmacyQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionOfSelectedPharmacyQuery.PatientName) : "");
                    DOCTORNAME.CalcValue = @" " + (dataset_GetInpatientPrescriptionOfSelectedPharmacyQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionOfSelectedPharmacyQuery.Doctorname) : "");
                    QUARANTINENO.CalcValue = @" " + (dataset_GetInpatientPrescriptionOfSelectedPharmacyQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionOfSelectedPharmacyQuery.PatientQuarantineNo) : "");
                    BALANCE.CalcValue = (dataset_GetInpatientPrescriptionOfSelectedPharmacyQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionOfSelectedPharmacyQuery.Price) : "");
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField11112.CalcValue = NewField11112.Value;
                    PRESCRIPTIONID.CalcValue = (dataset_GetInpatientPrescriptionOfSelectedPharmacyQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionOfSelectedPharmacyQuery.Prescriptionid) : "");
                    return new TTReportObject[] { ORDERNO,CLINICNAME,PROTOCOLNO,DAILYNO,PATIENTNAME,DOCTORNAME,QUARANTINENO,BALANCE,NewField111,NewField1111,NewField11111,NewField11112,PRESCRIPTIONID};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public InpatientPrescriptionOfSelectedPharmacy MyParentReport
                {
                    get { return (InpatientPrescriptionOfSelectedPharmacy)ParentReport; }
                }
                
                public TTReportShape NewLine2; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    RepeatCount = 0;
                    
                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 254, 0, 290, 0, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrescriptionDistribute.GetInpatientPrescriptionOfSelectedPharmacyQuery_Class dataset_GetInpatientPrescriptionOfSelectedPharmacyQuery = ParentGroup.rsGroup.GetCurrentRecord<PrescriptionDistribute.GetInpatientPrescriptionOfSelectedPharmacyQuery_Class>(0);
                    return new TTReportObject[] { };
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public InpatientPrescriptionOfSelectedPharmacy MyParentReport
            {
                get { return (InpatientPrescriptionOfSelectedPharmacy)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DRUGNAME { get {return Body().DRUGNAME;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField UNITPRICE { get {return Body().UNITPRICE;} }
            public TTReportField TOTALPRICE { get {return Body().TOTALPRICE;} }
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
                list[0] = new TTReportNqlData<InpatientPrescription.GetInpatientPrescriptionDrugsQuery_Class>("GetInpatientPrescriptionDrugsQuery", InpatientPrescription.GetInpatientPrescriptionDrugsQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.PARTB.PRESCRIPTIONID.CalcValue)));
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
                public InpatientPrescriptionOfSelectedPharmacy MyParentReport
                {
                    get { return (InpatientPrescriptionOfSelectedPharmacy)ParentReport; }
                }
                
                public TTReportField DRUGNAME;
                public TTReportField AMOUNT;
                public TTReportField UNITPRICE;
                public TTReportField TOTALPRICE;
                public TTReportShape NewLine11; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    DRUGNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 161, 4, false);
                    DRUGNAME.Name = "DRUGNAME";
                    DRUGNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    DRUGNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGNAME.TextFont.Name = "Arial";
                    DRUGNAME.TextFont.Size = 8;
                    DRUGNAME.TextFont.CharSet = 162;
                    DRUGNAME.Value = @"{#DRUG#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 0, 185, 4, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.TextFont.Size = 8;
                    AMOUNT.TextFont.CharSet = 162;
                    AMOUNT.Value = @"{#AMOUNT#} Adet ";

                    UNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 0, 224, 4, false);
                    UNITPRICE.Name = "UNITPRICE";
                    UNITPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE.TextFormat = @"Currency";
                    UNITPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE.TextFont.Name = "Arial";
                    UNITPRICE.TextFont.Size = 8;
                    UNITPRICE.TextFont.CharSet = 162;
                    UNITPRICE.Value = @"{#UNITPRICE#}";

                    TOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 0, 254, 4, false);
                    TOTALPRICE.Name = "TOTALPRICE";
                    TOTALPRICE.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALPRICE.TextFormat = @"Currency";
                    TOTALPRICE.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALPRICE.TextFont.Name = "Arial";
                    TOTALPRICE.TextFont.Size = 8;
                    TOTALPRICE.TextFont.CharSet = 162;
                    TOTALPRICE.Value = @"{#TOTALPRICE#}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 290, 0, 290, 4, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    InpatientPrescription.GetInpatientPrescriptionDrugsQuery_Class dataset_GetInpatientPrescriptionDrugsQuery = ParentGroup.rsGroup.GetCurrentRecord<InpatientPrescription.GetInpatientPrescriptionDrugsQuery_Class>(0);
                    DRUGNAME.CalcValue = (dataset_GetInpatientPrescriptionDrugsQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionDrugsQuery.Drug) : "");
                    AMOUNT.CalcValue = (dataset_GetInpatientPrescriptionDrugsQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionDrugsQuery.Amount) : "") + @" Adet ";
                    UNITPRICE.CalcValue = (dataset_GetInpatientPrescriptionDrugsQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionDrugsQuery.Unitprice) : "");
                    TOTALPRICE.CalcValue = (dataset_GetInpatientPrescriptionDrugsQuery != null ? Globals.ToStringCore(dataset_GetInpatientPrescriptionDrugsQuery.Totalprice) : "");
                    return new TTReportObject[] { DRUGNAME,AMOUNT,UNITPRICE,TOTALPRICE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public InpatientPrescriptionOfSelectedPharmacy()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("PHARMACYID", "00000000-0000-0000-0000-000000000000", "Eczaneyi Seçiniz :", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("706b3836-b6b2-47f3-a342-4fa3411b549b");
            reportParameter = Parameters.Add("DATE", "", "Tarih Seçiniz :", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("PHARMACYID"))
                _runtimeParameters.PHARMACYID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["PHARMACYID"]);
            if (parameters.ContainsKey("DATE"))
                _runtimeParameters.DATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["DATE"]);
            Name = "INPATIENTPRESCRIPTIONOFSELECTEDPHARMACY";
            Caption = "Seçilen Eczaneye Ait Yatan Hasta Reçetelerinin Listesi";
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