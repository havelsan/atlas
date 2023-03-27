
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
    public partial class PatientOrthesisProsthesisReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string HOSPITALPROTOCOLNO = (string)TTObjectDefManager.Instance.DataTypes["String_30"].ConvertValue("");
            public string YEAR = TTObjectDefManager.ServerTime.Year.ToString();
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public PatientOrthesisProsthesisReport MyParentReport
            {
                get { return (PatientOrthesisProsthesisReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

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
                public PatientOrthesisProsthesisReport MyParentReport
                {
                    get { return (PatientOrthesisProsthesisReport)ParentReport; }
                }
                 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    (((PatientOrthesisProsthesisReport)ParentReport).RuntimeParameters).STARTDATE = Convert.ToDateTime("01.01." + (((PatientOrthesisProsthesisReport)ParentReport).RuntimeParameters).YEAR + " 00:00:00");
            (((PatientOrthesisProsthesisReport)ParentReport).RuntimeParameters).ENDDATE = Convert.ToDateTime("31.12." + (((PatientOrthesisProsthesisReport)ParentReport).RuntimeParameters).YEAR + " 23:59:59");
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public PatientOrthesisProsthesisReport MyParentReport
                {
                    get { return (PatientOrthesisProsthesisReport)ParentReport; }
                }
                 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public PatientOrthesisProsthesisReport MyParentReport
            {
                get { return (PatientOrthesisProsthesisReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField PATIENTINFO { get {return Header().PATIENTINFO;} }
            public TTReportField PROTOKOLNO { get {return Header().PROTOKOLNO;} }
            public TTReportField ACILISTARIHI { get {return Header().ACILISTARIHI;} }
            public TTReportField PageNumber { get {return Header().PageNumber;} }
            public TTReportField PrintDate { get {return Header().PrintDate;} }
            public TTReportField PAYER { get {return Header().PAYER;} }
            public TTReportField ICD10 { get {return Header().ICD10;} }
            public TTReportField ICD10CODE { get {return Header().ICD10CODE;} }
            public TTReportField TAXINFO { get {return Header().TAXINFO;} }
            public TTReportField SIGNATUREBLOCK { get {return Header().SIGNATUREBLOCK;} }
            public TTReportField BANKACCOUNT1 { get {return Header().BANKACCOUNT1;} }
            public TTReportField HOSPITALIBANNO1 { get {return Header().HOSPITALIBANNO1;} }
            public TTReportField INVOICELABEL1 { get {return Header().INVOICELABEL1;} }
            public TTReportField TOPLAMFIYAT { get {return Footer().TOPLAMFIYAT;} }
            public TTReportField PRICEWITHLETTERS { get {return Footer().PRICEWITHLETTERS;} }
            public TTReportField PAYERF { get {return Footer().PAYERF;} }
            public TTReportField ACILISTARIHIF { get {return Footer().ACILISTARIHIF;} }
            public TTReportField PATIENTINFOF { get {return Footer().PATIENTINFOF;} }
            public TTReportField PROTOKOLNOF { get {return Footer().PROTOKOLNOF;} }
            public TTReportField PageNumberF { get {return Footer().PageNumberF;} }
            public TTReportField PrintDateF { get {return Footer().PrintDateF;} }
            public TTReportField TOPLAMFIYATF { get {return Footer().TOPLAMFIYATF;} }
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
                public PatientOrthesisProsthesisReport MyParentReport
                {
                    get { return (PatientOrthesisProsthesisReport)ParentReport; }
                }
                
                public TTReportField PATIENTINFO;
                public TTReportField PROTOKOLNO;
                public TTReportField ACILISTARIHI;
                public TTReportField PageNumber;
                public TTReportField PrintDate;
                public TTReportField PAYER;
                public TTReportField ICD10;
                public TTReportField ICD10CODE;
                public TTReportField TAXINFO;
                public TTReportField SIGNATUREBLOCK;
                public TTReportField BANKACCOUNT1;
                public TTReportField HOSPITALIBANNO1;
                public TTReportField INVOICELABEL1; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 98;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PATIENTINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 38, 168, 43, false);
                    PATIENTINFO.Name = "PATIENTINFO";
                    PATIENTINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTINFO.TextFont.Name = "Courier New";
                    PATIENTINFO.TextFont.Size = 8;
                    PATIENTINFO.TextFont.CharSet = 162;
                    PATIENTINFO.Value = @"";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 71, 38, 91, 43, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.Name = "Courier New";
                    PROTOKOLNO.TextFont.Size = 8;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"";

                    ACILISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 38, 62, 43, false);
                    ACILISTARIHI.Name = "ACILISTARIHI";
                    ACILISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACILISTARIHI.TextFormat = @"Short Date";
                    ACILISTARIHI.TextFont.Size = 8;
                    ACILISTARIHI.TextFont.CharSet = 162;
                    ACILISTARIHI.Value = @"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 8, 184, 13, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.TextFont.Name = "Courier New";
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"{@pagenumber@}. SAYFA";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 25, 167, 30, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFont.Name = "Courier New";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    PAYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 47, 168, 55, false);
                    PAYER.Name = "PAYER";
                    PAYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYER.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYER.MultiLine = EvetHayirEnum.ehEvet;
                    PAYER.WordBreak = EvetHayirEnum.ehEvet;
                    PAYER.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYER.TextFont.Name = "Courier New";
                    PAYER.TextFont.Size = 8;
                    PAYER.TextFont.CharSet = 162;
                    PAYER.Value = @"";

                    ICD10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 64, 202, 68, false);
                    ICD10.Name = "ICD10";
                    ICD10.FieldType = ReportFieldTypeEnum.ftVariable;
                    ICD10.MultiLine = EvetHayirEnum.ehEvet;
                    ICD10.WordBreak = EvetHayirEnum.ehEvet;
                    ICD10.ExpandTabs = EvetHayirEnum.ehEvet;
                    ICD10.TextFont.Name = "Courier New";
                    ICD10.TextFont.Size = 8;
                    ICD10.TextFont.CharSet = 162;
                    ICD10.Value = @"";

                    ICD10CODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 60, 202, 64, false);
                    ICD10CODE.Name = "ICD10CODE";
                    ICD10CODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ICD10CODE.MultiLine = EvetHayirEnum.ehEvet;
                    ICD10CODE.WordBreak = EvetHayirEnum.ehEvet;
                    ICD10CODE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ICD10CODE.TextFont.Name = "Courier New";
                    ICD10CODE.TextFont.Size = 8;
                    ICD10CODE.TextFont.CharSet = 162;
                    ICD10CODE.Value = @"";

                    TAXINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 69, 60, 81, false);
                    TAXINFO.Name = "TAXINFO";
                    TAXINFO.FieldType = ReportFieldTypeEnum.ftExpression;
                    TAXINFO.MultiLine = EvetHayirEnum.ehEvet;
                    TAXINFO.NoClip = EvetHayirEnum.ehEvet;
                    TAXINFO.WordBreak = EvetHayirEnum.ehEvet;
                    TAXINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TAXINFO.TextFont.Name = "Courier New";
                    TAXINFO.TextFont.Size = 8;
                    TAXINFO.TextFont.CharSet = 162;
                    TAXINFO.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""TAXOFFICEINFO"", """")";

                    SIGNATUREBLOCK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 69, 202, 81, false);
                    SIGNATUREBLOCK.Name = "SIGNATUREBLOCK";
                    SIGNATUREBLOCK.FieldType = ReportFieldTypeEnum.ftExpression;
                    SIGNATUREBLOCK.MultiLine = EvetHayirEnum.ehEvet;
                    SIGNATUREBLOCK.NoClip = EvetHayirEnum.ehEvet;
                    SIGNATUREBLOCK.WordBreak = EvetHayirEnum.ehEvet;
                    SIGNATUREBLOCK.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIGNATUREBLOCK.TextFont.Name = "Courier New";
                    SIGNATUREBLOCK.TextFont.Size = 8;
                    SIGNATUREBLOCK.TextFont.CharSet = 162;
                    SIGNATUREBLOCK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""PAYERINVOICEREPORTSIGNATUREBLOCK"", """")";

                    BANKACCOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 69, 111, 77, false);
                    BANKACCOUNT1.Name = "BANKACCOUNT1";
                    BANKACCOUNT1.FieldType = ReportFieldTypeEnum.ftExpression;
                    BANKACCOUNT1.MultiLine = EvetHayirEnum.ehEvet;
                    BANKACCOUNT1.NoClip = EvetHayirEnum.ehEvet;
                    BANKACCOUNT1.WordBreak = EvetHayirEnum.ehEvet;
                    BANKACCOUNT1.ExpandTabs = EvetHayirEnum.ehEvet;
                    BANKACCOUNT1.TextFont.Name = "Courier New";
                    BANKACCOUNT1.TextFont.Size = 8;
                    BANKACCOUNT1.TextFont.CharSet = 162;
                    BANKACCOUNT1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""BANKACCOUNTINFO"", """")
";

                    HOSPITALIBANNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 77, 111, 81, false);
                    HOSPITALIBANNO1.Name = "HOSPITALIBANNO1";
                    HOSPITALIBANNO1.FieldType = ReportFieldTypeEnum.ftExpression;
                    HOSPITALIBANNO1.MultiLine = EvetHayirEnum.ehEvet;
                    HOSPITALIBANNO1.NoClip = EvetHayirEnum.ehEvet;
                    HOSPITALIBANNO1.WordBreak = EvetHayirEnum.ehEvet;
                    HOSPITALIBANNO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    HOSPITALIBANNO1.TextFont.Name = "Courier New";
                    HOSPITALIBANNO1.TextFont.Size = 8;
                    HOSPITALIBANNO1.TextFont.CharSet = 162;
                    HOSPITALIBANNO1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALIBANNO"", """")
";

                    INVOICELABEL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 8, 125, 13, false);
                    INVOICELABEL1.Name = "INVOICELABEL1";
                    INVOICELABEL1.TextFont.Name = "Courier New";
                    INVOICELABEL1.TextFont.Size = 16;
                    INVOICELABEL1.TextFont.CharSet = 162;
                    INVOICELABEL1.Value = @"FATURADIR";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PATIENTINFO.CalcValue = @"";
                    PROTOKOLNO.CalcValue = @"";
                    ACILISTARIHI.CalcValue = @"";
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @". SAYFA";
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PAYER.CalcValue = @"";
                    ICD10.CalcValue = @"";
                    ICD10CODE.CalcValue = @"";
                    INVOICELABEL1.CalcValue = INVOICELABEL1.Value;
                    TAXINFO.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("TAXOFFICEINFO", "");
                    SIGNATUREBLOCK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("PAYERINVOICEREPORTSIGNATUREBLOCK", "");
                    BANKACCOUNT1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("BANKACCOUNTINFO", "")
;
                    HOSPITALIBANNO1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALIBANNO", "")
;
                    return new TTReportObject[] { PATIENTINFO,PROTOKOLNO,ACILISTARIHI,PageNumber,PrintDate,PAYER,ICD10,ICD10CODE,INVOICELABEL1,TAXINFO,SIGNATUREBLOCK,BANKACCOUNT1,HOSPITALIBANNO1};
                }

                public override void RunScript()
                {
#region PARTB HEADER_Script
                    BindingList<Episode> episodeList = Episode.GetByHospitalProtocolNo(this.ParentReport.ReportObjectContext, ((PatientOrthesisProsthesisReport)ParentReport).RuntimeParameters.HOSPITALPROTOCOLNO, Convert.ToDateTime(((PatientOrthesisProsthesisReport)ParentReport).RuntimeParameters.STARTDATE), Convert.ToDateTime(((PatientOrthesisProsthesisReport)ParentReport).RuntimeParameters.ENDDATE));
            if(episodeList.Count > 0)
            {
                Episode episode = episodeList[0];
                TTObjectContext context = new TTObjectContext(true);
                if (episode.Patient != null)
                {
                    this.PATIENTINFO.CalcValue = Convert.ToString(episode.Patient.Name) +" "+ Convert.ToString(episode.Patient.Surname) + "  " + "("+Convert.ToString(episode.Patient.UniqueRefNo)+")";
                    this.ACILISTARIHI.CalcValue = Convert.ToString((DateTime)episode.OpeningDate);
                    this.PROTOKOLNO.CalcValue = Convert.ToString(episode.HospitalProtocolNo);

                    if(episode.Payer != null)
                        this.PAYER.CalcValue = Convert.ToString(episode.Payer.Code) + " " + Convert.ToString(episode.Payer.Name) + " " + Convert.ToString(episode.Payer.City);
                    
                    BindingList<DiagnosisGrid.GetDiagnosisByEpisode_Class> diagnosis = DiagnosisGrid.GetDiagnosisByEpisode(Convert.ToString(episode.ObjectID));
                    string diagnosisCode = "ICD10 KODU     : ";
                    string diagnosisStr  = "ICD10 AÇIKLAMA : ";
                    
                    IList diagnosisCodeList = new List<string>();
                    
                    foreach(DiagnosisGrid.GetDiagnosisByEpisode_Class myDiagnose in diagnosis)
                    {
                        if(!diagnosisCodeList.Contains(myDiagnose.Code))
                        {
                            diagnosisCode = diagnosisCode + myDiagnose.Code + " , ";
                            diagnosisStr = diagnosisStr + myDiagnose.Name + " , ";
                            diagnosisCodeList.Add(myDiagnose.Code);
                        }
                    }
                    
                    if (diagnosisStr != "")
                    {
                        diagnosisCode = diagnosisCode.Remove(diagnosisCode.Length -3,3);
                        diagnosisStr = diagnosisStr.Remove(diagnosisStr.Length -3,3);
                    }
                    
                    this.ICD10CODE.CalcValue = diagnosisCode;
                    this.ICD10.CalcValue = diagnosisStr ;
                }
            }
#endregion PARTB HEADER_Script
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public PatientOrthesisProsthesisReport MyParentReport
                {
                    get { return (PatientOrthesisProsthesisReport)ParentReport; }
                }
                
                public TTReportField TOPLAMFIYAT;
                public TTReportField PRICEWITHLETTERS;
                public TTReportField PAYERF;
                public TTReportField ACILISTARIHIF;
                public TTReportField PATIENTINFOF;
                public TTReportField PROTOKOLNOF;
                public TTReportField PageNumberF;
                public TTReportField PrintDateF;
                public TTReportField TOPLAMFIYATF; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 109;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    TOPLAMFIYAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 5, 181, 9, false);
                    TOPLAMFIYAT.Name = "TOPLAMFIYAT";
                    TOPLAMFIYAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMFIYAT.TextFormat = @"#,##0.#0";
                    TOPLAMFIYAT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMFIYAT.TextFont.Name = "Courier New";
                    TOPLAMFIYAT.TextFont.Size = 8;
                    TOPLAMFIYAT.TextFont.CharSet = 162;
                    TOPLAMFIYAT.Value = @"{@sumof(TOPLAMFIYAT)@}";

                    PRICEWITHLETTERS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 13, 181, 17, false);
                    PRICEWITHLETTERS.Name = "PRICEWITHLETTERS";
                    PRICEWITHLETTERS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRICEWITHLETTERS.TextFormat = @"NUMBERTEXT( TL , KR)";
                    PRICEWITHLETTERS.TextFont.Name = "Courier New";
                    PRICEWITHLETTERS.TextFont.Size = 8;
                    PRICEWITHLETTERS.TextFont.CharSet = 162;
                    PRICEWITHLETTERS.Value = @"{%TOPLAMFIYAT%}";

                    PAYERF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 42, 180, 48, false);
                    PAYERF.Name = "PAYERF";
                    PAYERF.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAYERF.CaseFormat = CaseFormatEnum.fcUpperCase;
                    PAYERF.MultiLine = EvetHayirEnum.ehEvet;
                    PAYERF.WordBreak = EvetHayirEnum.ehEvet;
                    PAYERF.ExpandTabs = EvetHayirEnum.ehEvet;
                    PAYERF.TextFont.Name = "Courier New";
                    PAYERF.TextFont.Size = 8;
                    PAYERF.TextFont.CharSet = 162;
                    PAYERF.Value = @"{%PARTB.PAYER%}";

                    ACILISTARIHIF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 52, 134, 56, false);
                    ACILISTARIHIF.Name = "ACILISTARIHIF";
                    ACILISTARIHIF.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACILISTARIHIF.TextFont.Size = 8;
                    ACILISTARIHIF.TextFont.CharSet = 162;
                    ACILISTARIHIF.Value = @"{%PARTB.ACILISTARIHI%}";

                    PATIENTINFOF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 56, 134, 60, false);
                    PATIENTINFOF.Name = "PATIENTINFOF";
                    PATIENTINFOF.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENTINFOF.TextFont.Name = "Courier New";
                    PATIENTINFOF.TextFont.Size = 8;
                    PATIENTINFOF.TextFont.CharSet = 162;
                    PATIENTINFOF.Value = @"{%PARTB.PATIENTINFO%}";

                    PROTOKOLNOF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 60, 134, 64, false);
                    PROTOKOLNOF.Name = "PROTOKOLNOF";
                    PROTOKOLNOF.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNOF.TextFont.Name = "Courier New";
                    PROTOKOLNOF.TextFont.Size = 8;
                    PROTOKOLNOF.TextFont.CharSet = 162;
                    PROTOKOLNOF.Value = @"{%PARTB.PROTOKOLNO%}";

                    PageNumberF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 69, 186, 74, false);
                    PageNumberF.Name = "PageNumberF";
                    PageNumberF.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumberF.TextFont.Name = "Courier New";
                    PageNumberF.TextFont.Size = 8;
                    PageNumberF.TextFont.CharSet = 162;
                    PageNumberF.Value = @"{@pagenumber@}. SAYFA";

                    PrintDateF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 52, 167, 56, false);
                    PrintDateF.Name = "PrintDateF";
                    PrintDateF.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDateF.TextFont.Name = "Courier New";
                    PrintDateF.TextFont.Size = 8;
                    PrintDateF.TextFont.CharSet = 162;
                    PrintDateF.Value = @"{@printdate@}";

                    TOPLAMFIYATF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 60, 167, 64, false);
                    TOPLAMFIYATF.Name = "TOPLAMFIYATF";
                    TOPLAMFIYATF.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMFIYATF.TextFormat = @"#,##0.#0";
                    TOPLAMFIYATF.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMFIYATF.TextFont.Name = "Courier New";
                    TOPLAMFIYATF.TextFont.Size = 8;
                    TOPLAMFIYATF.TextFont.CharSet = 162;
                    TOPLAMFIYATF.Value = @"{@sumof(TOPLAMFIYAT)@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    TOPLAMFIYAT.CalcValue = ParentGroup.FieldSums["TOPLAMFIYAT"].Value.ToString();;
                    PRICEWITHLETTERS.CalcValue = MyParentReport.PARTB.TOPLAMFIYAT.FormattedValue;
                    PAYERF.CalcValue = MyParentReport.PARTB.PAYER.CalcValue;
                    ACILISTARIHIF.CalcValue = MyParentReport.PARTB.ACILISTARIHI.FormattedValue;
                    PATIENTINFOF.CalcValue = MyParentReport.PARTB.PATIENTINFO.CalcValue;
                    PROTOKOLNOF.CalcValue = MyParentReport.PARTB.PROTOKOLNO.CalcValue;
                    PageNumberF.CalcValue = ParentReport.CurrentPageNumber.ToString() + @". SAYFA";
                    PrintDateF.CalcValue = DateTime.Now.ToShortDateString();
                    TOPLAMFIYATF.CalcValue = ParentGroup.FieldSums["TOPLAMFIYAT"].Value.ToString();;
                    return new TTReportObject[] { TOPLAMFIYAT,PRICEWITHLETTERS,PAYERF,ACILISTARIHIF,PATIENTINFOF,PROTOKOLNOF,PageNumberF,PrintDateF,TOPLAMFIYATF};
                }
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public PatientOrthesisProsthesisReport MyParentReport
            {
                get { return (PatientOrthesisProsthesisReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SIRANO { get {return Body().SIRANO;} }
            public TTReportField TARIH { get {return Body().TARIH;} }
            public TTReportField CODEACIKLAMA { get {return Body().CODEACIKLAMA;} }
            public TTReportField MIKTAR { get {return Body().MIKTAR;} }
            public TTReportField BIRIMFIYAT { get {return Body().BIRIMFIYAT;} }
            public TTReportField TOPLAMFIYAT { get {return Body().TOPLAMFIYAT;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportField EXTERNALCODE { get {return Body().EXTERNALCODE;} }
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
                list[0] = new TTReportNqlData<AccountTransaction.GetOrthesisProsthesisByProtocolNoAndYear_Class>("GetPatienOrthesisProsthesisListByProtocolNoAndYear", AccountTransaction.GetOrthesisProsthesisByProtocolNoAndYear((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(string)TTObjectDefManager.Instance.DataTypes["String_30"].ConvertValue(MyParentReport.RuntimeParameters.HOSPITALPROTOCOLNO)));
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
                public PatientOrthesisProsthesisReport MyParentReport
                {
                    get { return (PatientOrthesisProsthesisReport)ParentReport; }
                }
                
                public TTReportField SIRANO;
                public TTReportField TARIH;
                public TTReportField CODEACIKLAMA;
                public TTReportField MIKTAR;
                public TTReportField BIRIMFIYAT;
                public TTReportField TOPLAMFIYAT;
                public TTReportField OBJECTID;
                public TTReportField DESCRIPTION;
                public TTReportField EXTERNALCODE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    RepeatCount = 0;
                    
                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 0, 20, 4, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.MultiLine = EvetHayirEnum.ehEvet;
                    SIRANO.NoClip = EvetHayirEnum.ehEvet;
                    SIRANO.WordBreak = EvetHayirEnum.ehEvet;
                    SIRANO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SIRANO.TextFont.Name = "Courier New";
                    SIRANO.TextFont.Size = 8;
                    SIRANO.TextFont.CharSet = 162;
                    SIRANO.Value = @"{@groupcounter@}";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 0, 40, 4, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"Short Date";
                    TARIH.MultiLine = EvetHayirEnum.ehEvet;
                    TARIH.NoClip = EvetHayirEnum.ehEvet;
                    TARIH.WordBreak = EvetHayirEnum.ehEvet;
                    TARIH.ExpandTabs = EvetHayirEnum.ehEvet;
                    TARIH.TextFont.Name = "Courier New";
                    TARIH.TextFont.Size = 8;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"{#TRANSACTIONDATE#}";

                    CODEACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 0, 103, 4, false);
                    CODEACIKLAMA.Name = "CODEACIKLAMA";
                    CODEACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    CODEACIKLAMA.MultiLine = EvetHayirEnum.ehEvet;
                    CODEACIKLAMA.NoClip = EvetHayirEnum.ehEvet;
                    CODEACIKLAMA.WordBreak = EvetHayirEnum.ehEvet;
                    CODEACIKLAMA.ExpandTabs = EvetHayirEnum.ehEvet;
                    CODEACIKLAMA.TextFont.Name = "Courier New";
                    CODEACIKLAMA.TextFont.Size = 8;
                    CODEACIKLAMA.TextFont.CharSet = 162;
                    CODEACIKLAMA.Value = @"";

                    MIKTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 0, 111, 4, false);
                    MIKTAR.Name = "MIKTAR";
                    MIKTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    MIKTAR.MultiLine = EvetHayirEnum.ehEvet;
                    MIKTAR.NoClip = EvetHayirEnum.ehEvet;
                    MIKTAR.WordBreak = EvetHayirEnum.ehEvet;
                    MIKTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    MIKTAR.TextFont.Name = "Courier New";
                    MIKTAR.TextFont.Size = 8;
                    MIKTAR.TextFont.CharSet = 162;
                    MIKTAR.Value = @"{#AMOUNT#}";

                    BIRIMFIYAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 0, 143, 4, false);
                    BIRIMFIYAT.Name = "BIRIMFIYAT";
                    BIRIMFIYAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRIMFIYAT.TextFormat = @"#,##0.#0";
                    BIRIMFIYAT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    BIRIMFIYAT.MultiLine = EvetHayirEnum.ehEvet;
                    BIRIMFIYAT.NoClip = EvetHayirEnum.ehEvet;
                    BIRIMFIYAT.WordBreak = EvetHayirEnum.ehEvet;
                    BIRIMFIYAT.ExpandTabs = EvetHayirEnum.ehEvet;
                    BIRIMFIYAT.TextFont.Name = "Courier New";
                    BIRIMFIYAT.TextFont.Size = 8;
                    BIRIMFIYAT.TextFont.CharSet = 162;
                    BIRIMFIYAT.Value = @"{#UNITPRICE#}";

                    TOPLAMFIYAT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 0, 181, 4, false);
                    TOPLAMFIYAT.Name = "TOPLAMFIYAT";
                    TOPLAMFIYAT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOPLAMFIYAT.TextFormat = @"#,##0.#0";
                    TOPLAMFIYAT.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOPLAMFIYAT.MultiLine = EvetHayirEnum.ehEvet;
                    TOPLAMFIYAT.NoClip = EvetHayirEnum.ehEvet;
                    TOPLAMFIYAT.WordBreak = EvetHayirEnum.ehEvet;
                    TOPLAMFIYAT.ExpandTabs = EvetHayirEnum.ehEvet;
                    TOPLAMFIYAT.TextFont.Name = "Courier New";
                    TOPLAMFIYAT.TextFont.Size = 8;
                    TOPLAMFIYAT.TextFont.CharSet = 162;
                    TOPLAMFIYAT.Value = @"{#TOTALPRICE#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 1, 236, 6, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.TextFont.Size = 8;
                    OBJECTID.TextFont.CharSet = 162;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 1, 263, 6, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.Visible = EvetHayirEnum.ehHayir;
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    EXTERNALCODE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 265, 1, 290, 6, false);
                    EXTERNALCODE.Name = "EXTERNALCODE";
                    EXTERNALCODE.Visible = EvetHayirEnum.ehHayir;
                    EXTERNALCODE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXTERNALCODE.Value = @"{#EXTERNALCODE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AccountTransaction.GetOrthesisProsthesisByProtocolNoAndYear_Class dataset_GetPatienOrthesisProsthesisListByProtocolNoAndYear = ParentGroup.rsGroup.GetCurrentRecord<AccountTransaction.GetOrthesisProsthesisByProtocolNoAndYear_Class>(0);
                    SIRANO.CalcValue = ParentGroup.GroupCounter.ToString();
                    TARIH.CalcValue = (dataset_GetPatienOrthesisProsthesisListByProtocolNoAndYear != null ? Globals.ToStringCore(dataset_GetPatienOrthesisProsthesisListByProtocolNoAndYear.TransactionDate) : "");
                    CODEACIKLAMA.CalcValue = @"";
                    MIKTAR.CalcValue = (dataset_GetPatienOrthesisProsthesisListByProtocolNoAndYear != null ? Globals.ToStringCore(dataset_GetPatienOrthesisProsthesisListByProtocolNoAndYear.Amount) : "");
                    BIRIMFIYAT.CalcValue = (dataset_GetPatienOrthesisProsthesisListByProtocolNoAndYear != null ? Globals.ToStringCore(dataset_GetPatienOrthesisProsthesisListByProtocolNoAndYear.UnitPrice) : "");
                    TOPLAMFIYAT.CalcValue = (dataset_GetPatienOrthesisProsthesisListByProtocolNoAndYear != null ? Globals.ToStringCore(dataset_GetPatienOrthesisProsthesisListByProtocolNoAndYear.Totalprice) : "");
                    OBJECTID.CalcValue = (dataset_GetPatienOrthesisProsthesisListByProtocolNoAndYear != null ? Globals.ToStringCore(dataset_GetPatienOrthesisProsthesisListByProtocolNoAndYear.ObjectID) : "");
                    DESCRIPTION.CalcValue = (dataset_GetPatienOrthesisProsthesisListByProtocolNoAndYear != null ? Globals.ToStringCore(dataset_GetPatienOrthesisProsthesisListByProtocolNoAndYear.Description) : "");
                    EXTERNALCODE.CalcValue = (dataset_GetPatienOrthesisProsthesisListByProtocolNoAndYear != null ? Globals.ToStringCore(dataset_GetPatienOrthesisProsthesisListByProtocolNoAndYear.ExternalCode) : "");
                    return new TTReportObject[] { SIRANO,TARIH,CODEACIKLAMA,MIKTAR,BIRIMFIYAT,TOPLAMFIYAT,OBJECTID,DESCRIPTION,EXTERNALCODE};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = this.OBJECTID.CalcValue;
            AccountTransaction AccTrx = (AccountTransaction)context.GetObject(new Guid(sObjectID),"AccountTransaction");

            this.CODEACIKLAMA.CalcValue = this.EXTERNALCODE.CalcValue + " " + this.DESCRIPTION.CalcValue;
            if(AccTrx != null)
            {
                //this.DURUM.CalcValue = AccTrx.CurrentStateDef.DisplayText;
                
                if (AccTrx.PackageDefinition != null)
                    this.CODEACIKLAMA.CalcValue += " (Paket İçi)";
            }
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

        public PatientOrthesisProsthesisReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("HOSPITALPROTOCOLNO", "", "H.Protocol No", @"", true, true, false, new Guid("ba576fe4-f84e-4212-84d8-ea033bceed43"));
            reportParameter = Parameters.Add("YEAR", TTObjectDefManager.ServerTime.Year.ToString(), "Yıl", @"", true, true, false, new Guid("c202916a-01df-4eeb-a809-96e7bfbd2bd2"));
            reportParameter = Parameters.Add("STARTDATE", "", "", @"", false, false, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "", @"", false, false, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("HOSPITALPROTOCOLNO"))
                _runtimeParameters.HOSPITALPROTOCOLNO = (string)TTObjectDefManager.Instance.DataTypes["String_30"].ConvertValue(parameters["HOSPITALPROTOCOLNO"]);
            if (parameters.ContainsKey("YEAR"))
                _runtimeParameters.YEAR = (string)TTObjectDefManager.Instance.DataTypes["String_4"].ConvertValue(parameters["YEAR"]);
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            Name = "PATIENTORTHESISPROSTHESISREPORT";
            Caption = "Hasta Ortez Protez Raporu";
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