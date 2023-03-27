
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
    /// Anestezi Konsültasyon Raporu
    /// </summary>
    public partial class AnesthesiaConsultationReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public AnesthesiaConsultationReport MyParentReport
            {
                get { return (AnesthesiaConsultationReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField NewField117 { get {return Header().NewField117;} }
            public TTReportField NewField118 { get {return Header().NewField118;} }
            public TTReportField XXXXXXBASLIK1 { get {return Header().XXXXXXBASLIK1;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField NAMESURNAME { get {return Header().NAMESURNAME;} }
            public TTReportField FATHERNAME { get {return Header().FATHERNAME;} }
            public TTReportField CITYNAMEDATE { get {return Header().CITYNAMEDATE;} }
            public TTReportField BIRTHDATE { get {return Header().BIRTHDATE;} }
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
                list[0] = new TTReportNqlData<AnesthesiaConsultation.AnesthesiaConsultationReportNQL_Class>("AnesthesiaConsultationReportNQL", AnesthesiaConsultation.AnesthesiaConsultationReportNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public AnesthesiaConsultationReport MyParentReport
                {
                    get { return (AnesthesiaConsultationReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField12;
                public TTReportField NewField14;
                public TTReportField NewField17;
                public TTReportField NewField13;
                public TTReportField NewField112;
                public TTReportField NewField122;
                public TTReportField NewField117;
                public TTReportField NewField118;
                public TTReportField XXXXXXBASLIK1;
                public TTReportField NewField18;
                public TTReportField UNIQUEREFNO;
                public TTReportField NAMESURNAME;
                public TTReportField FATHERNAME;
                public TTReportField CITYNAMEDATE;
                public TTReportField BIRTHDATE; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 72;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 30, 195, 36, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Size = 15;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"ANESTEZİ KONSÜLTASYON RAPORU";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 48, 46, 53, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Size = 11;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Hasta Adı Soyadı";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 53, 46, 58, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Size = 11;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Baba Adı";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 58, 46, 63, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Size = 11;
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"Doğum Tarihi / Yeri";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 48, 49, 53, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Size = 11;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @":";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 53, 49, 58, false);
                    NewField112.Name = "NewField112";
                    NewField112.TextFont.Size = 11;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @":";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 58, 49, 63, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Size = 11;
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @":";

                    NewField117 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 43, 46, 48, false);
                    NewField117.Name = "NewField117";
                    NewField117.TextFont.Size = 11;
                    NewField117.TextFont.Bold = true;
                    NewField117.TextFont.CharSet = 162;
                    NewField117.Value = @"Hasta T.C. No";

                    NewField118 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 43, 49, 48, false);
                    NewField118.Name = "NewField118";
                    NewField118.TextFont.Size = 11;
                    NewField118.TextFont.Bold = true;
                    NewField118.TextFont.CharSet = 162;
                    NewField118.Value = @":";

                    XXXXXXBASLIK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 43, 7, 195, 30, false);
                    XXXXXXBASLIK1.Name = "XXXXXXBASLIK1";
                    XXXXXXBASLIK1.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK1.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK1.TextFont.Size = 11;
                    XXXXXXBASLIK1.TextFont.Bold = true;
                    XXXXXXBASLIK1.TextFont.CharSet = 162;
                    XXXXXXBASLIK1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 31, 42, 37, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Size = 11;
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.Underline = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @"HİZMETE ÖZEL";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 43, 119, 48, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.Value = @"{#UNIQUEREFNO#}";

                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 48, 119, 53, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME.Value = @"{#NAME#} {#SURNAME#}";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 53, 119, 58, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.Value = @"{#FATHERNAME#}";

                    CITYNAMEDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 66, 58, 119, 63, false);
                    CITYNAMEDATE.Name = "CITYNAMEDATE";
                    CITYNAMEDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CITYNAMEDATE.Value = @"{#CITYNAME#} - {#TOWNNAME#}";

                    BIRTHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 58, 66, 63, false);
                    BIRTHDATE.Name = "BIRTHDATE";
                    BIRTHDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHDATE.TextFormat = @"Short Date";
                    BIRTHDATE.Value = @"{#BIRTHDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AnesthesiaConsultation.AnesthesiaConsultationReportNQL_Class dataset_AnesthesiaConsultationReportNQL = ParentGroup.rsGroup.GetCurrentRecord<AnesthesiaConsultation.AnesthesiaConsultationReportNQL_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField117.CalcValue = NewField117.Value;
                    NewField118.CalcValue = NewField118.Value;
                    NewField18.CalcValue = NewField18.Value;
                    UNIQUEREFNO.CalcValue = (dataset_AnesthesiaConsultationReportNQL != null ? Globals.ToStringCore(dataset_AnesthesiaConsultationReportNQL.UniqueRefNo) : "");
                    NAMESURNAME.CalcValue = (dataset_AnesthesiaConsultationReportNQL != null ? Globals.ToStringCore(dataset_AnesthesiaConsultationReportNQL.Name) : "") + @" " + (dataset_AnesthesiaConsultationReportNQL != null ? Globals.ToStringCore(dataset_AnesthesiaConsultationReportNQL.Surname) : "");
                    FATHERNAME.CalcValue = (dataset_AnesthesiaConsultationReportNQL != null ? Globals.ToStringCore(dataset_AnesthesiaConsultationReportNQL.FatherName) : "");
                    CITYNAMEDATE.CalcValue = (dataset_AnesthesiaConsultationReportNQL != null ? Globals.ToStringCore(dataset_AnesthesiaConsultationReportNQL.Cityname) : "") + @" - " + (dataset_AnesthesiaConsultationReportNQL != null ? Globals.ToStringCore(dataset_AnesthesiaConsultationReportNQL.Townname) : "");
                    BIRTHDATE.CalcValue = (dataset_AnesthesiaConsultationReportNQL != null ? Globals.ToStringCore(dataset_AnesthesiaConsultationReportNQL.BirthDate) : "");
                    XXXXXXBASLIK1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField1,NewField12,NewField14,NewField17,NewField13,NewField112,NewField122,NewField117,NewField118,NewField18,UNIQUEREFNO,NAMESURNAME,FATHERNAME,CITYNAMEDATE,BIRTHDATE,XXXXXXBASLIK1};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public AnesthesiaConsultationReport MyParentReport
                {
                    get { return (AnesthesiaConsultationReport)ParentReport; }
                }
                 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERGroup HEADER;

        public partial class PARTAGroup : TTReportGroup
        {
            public AnesthesiaConsultationReport MyParentReport
            {
                get { return (AnesthesiaConsultationReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField ADSOYAD { get {return Footer().ADSOYAD;} }
            public TTReportField SINRUT { get {return Footer().SINRUT;} }
            public TTReportField UZMANLIK { get {return Footer().UZMANLIK;} }
            public TTReportField DIPSICNO { get {return Footer().DIPSICNO;} }
            public TTReportField SICIL { get {return Footer().SICIL;} }
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
                public AnesthesiaConsultationReport MyParentReport
                {
                    get { return (AnesthesiaConsultationReport)ParentReport; }
                }
                 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 2;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public AnesthesiaConsultationReport MyParentReport
                {
                    get { return (AnesthesiaConsultationReport)ParentReport; }
                }
                
                public TTReportField ADSOYAD;
                public TTReportField SINRUT;
                public TTReportField UZMANLIK;
                public TTReportField DIPSICNO;
                public TTReportField SICIL; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 26;
                    IsAligned = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 3, 207, 8, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.Value = @"{#HEADER.PROCEDUREDOCTORNAME#}";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 8, 207, 13, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.Value = @"{#HEADER.MILITARYCLASS#} {#HEADER.RANK#}";

                    UZMANLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 18, 207, 23, false);
                    UZMANLIK.Name = "UZMANLIK";
                    UZMANLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIK.Value = @"{#HEADER.SPECIALITY#}";

                    DIPSICNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 13, 207, 18, false);
                    DIPSICNO.Name = "DIPSICNO";
                    DIPSICNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSICNO.Value = @"{#HEADER.DIPLOMANO#} {#HEADER.EMPLOYMENTRECORDID#}";

                    SICIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 13, 159, 18, false);
                    SICIL.Name = "SICIL";
                    SICIL.Value = @"SİCİL NO :";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AnesthesiaConsultation.AnesthesiaConsultationReportNQL_Class dataset_AnesthesiaConsultationReportNQL = MyParentReport.HEADER.rsGroup.GetCurrentRecord<AnesthesiaConsultation.AnesthesiaConsultationReportNQL_Class>(0);
                    ADSOYAD.CalcValue = (dataset_AnesthesiaConsultationReportNQL != null ? Globals.ToStringCore(dataset_AnesthesiaConsultationReportNQL.Proceduredoctorname) : "");
                    SINRUT.CalcValue = (dataset_AnesthesiaConsultationReportNQL != null ? Globals.ToStringCore(dataset_AnesthesiaConsultationReportNQL.Militaryclass) : "") + @" " + (dataset_AnesthesiaConsultationReportNQL != null ? Globals.ToStringCore(dataset_AnesthesiaConsultationReportNQL.Rank) : "");
                    UZMANLIK.CalcValue = (dataset_AnesthesiaConsultationReportNQL != null ? Globals.ToStringCore(dataset_AnesthesiaConsultationReportNQL.Speciality) : "");
                    DIPSICNO.CalcValue = (dataset_AnesthesiaConsultationReportNQL != null ? Globals.ToStringCore(dataset_AnesthesiaConsultationReportNQL.DiplomaNo) : "") + @" " + (dataset_AnesthesiaConsultationReportNQL != null ? Globals.ToStringCore(dataset_AnesthesiaConsultationReportNQL.EmploymentRecordID) : "");
                    SICIL.CalcValue = SICIL.Value;
                    return new TTReportObject[] { ADSOYAD,SINRUT,UZMANLIK,DIPSICNO,SICIL};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public AnesthesiaConsultationReport MyParentReport
            {
                get { return (AnesthesiaConsultationReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField LBL11 { get {return Body().LBL11;} }
            public TTReportField LBL13 { get {return Body().LBL13;} }
            public TTReportRTF Report { get {return Body().Report;} }
            public TTReportField NewField1221 { get {return Body().NewField1221;} }
            public TTReportField NewField1321 { get {return Body().NewField1321;} }
            public TTReportField CONSULTATIONDATE { get {return Body().CONSULTATIONDATE;} }
            public TTReportField TTOBJECTID { get {return Body().TTOBJECTID;} }
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
                public AnesthesiaConsultationReport MyParentReport
                {
                    get { return (AnesthesiaConsultationReport)ParentReport; }
                }
                
                public TTReportField LBL11;
                public TTReportField LBL13;
                public TTReportRTF Report;
                public TTReportField NewField1221;
                public TTReportField NewField1321;
                public TTReportField CONSULTATIONDATE;
                public TTReportField TTOBJECTID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 50;
                    RepeatCount = 0;
                    
                    LBL11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 1, 43, 6, false);
                    LBL11.Name = "LBL11";
                    LBL11.TextFont.Size = 11;
                    LBL11.TextFont.Bold = true;
                    LBL11.TextFont.CharSet = 162;
                    LBL11.Value = @"Konsultasyon Tarih          ";

                    LBL13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 13, 46, 18, false);
                    LBL13.Name = "LBL13";
                    LBL13.TextFont.Size = 11;
                    LBL13.TextFont.Bold = true;
                    LBL13.TextFont.CharSet = 162;
                    LBL13.Value = @"Konsültasyon Sonucu          ";

                    Report = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 9, 19, 201, 48, false);
                    Report.Name = "Report";
                    Report.Value = @"";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 13, 49, 18, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.Size = 11;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @":";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 1, 49, 6, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.TextFont.Size = 11;
                    NewField1321.TextFont.Bold = true;
                    NewField1321.TextFont.CharSet = 162;
                    NewField1321.Value = @":";

                    CONSULTATIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 1, 75, 6, false);
                    CONSULTATIONDATE.Name = "CONSULTATIONDATE";
                    CONSULTATIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSULTATIONDATE.TextFormat = @"Short Date";
                    CONSULTATIONDATE.Value = @"{#HEADER.CONSULTATIONDATE#}";

                    TTOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 219, 4, 244, 9, false);
                    TTOBJECTID.Name = "TTOBJECTID";
                    TTOBJECTID.Visible = EvetHayirEnum.ehHayir;
                    TTOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TTOBJECTID.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    AnesthesiaConsultation.AnesthesiaConsultationReportNQL_Class dataset_AnesthesiaConsultationReportNQL = MyParentReport.HEADER.rsGroup.GetCurrentRecord<AnesthesiaConsultation.AnesthesiaConsultationReportNQL_Class>(0);
                    LBL11.CalcValue = LBL11.Value;
                    LBL13.CalcValue = LBL13.Value;
                    Report.CalcValue = Report.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    CONSULTATIONDATE.CalcValue = (dataset_AnesthesiaConsultationReportNQL != null ? Globals.ToStringCore(dataset_AnesthesiaConsultationReportNQL.Consultationdate) : "");
                    TTOBJECTID.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    return new TTReportObject[] { LBL11,LBL13,Report,NewField1221,NewField1321,CONSULTATIONDATE,TTOBJECTID};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    //             TTObjectContext context = new TTObjectContext(true);
//            string objectID = ((AnesthesiaConsultationReport)ParentReport).MAIN.OBJID.CalcValue.ToString();
//           
//            if(objectID != null)
//            {
//                AnesthesiaConsultation anesthesiaConsultation = (AnesthesiaConsultation)context.GetObject(new Guid(objectID),"AnesthesiaConsultation");
//                  try
//                        {
//                            this.RAPOR.Value = TTObjectClasses.Common.GetRTFOfTextString(anesthesiaConsultation.ConsultationResult.ToString());
//                        }
//                        catch(Exception exception)
//                        {
//                            
//                        }
//            }
#endregion MAIN BODY_PreScript
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((AnesthesiaConsultationReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            AnesthesiaConsultation anesthesiaConsultation = (AnesthesiaConsultation)context.GetObject(new Guid(sObjectID),"AnesthesiaConsultation");
            
            if(anesthesiaConsultation.ConsultationResult != null)
                this.Report.CalcValue=anesthesiaConsultation.ConsultationResult.ToString();
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

        public AnesthesiaConsultationReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            PARTA = new PARTAGroup(HEADER,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "AmeliyatKonsultasyon", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "ANESTHESIACONSULTATIONREPORT";
            Caption = "Anestezi Konsültasyon Raporu";
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