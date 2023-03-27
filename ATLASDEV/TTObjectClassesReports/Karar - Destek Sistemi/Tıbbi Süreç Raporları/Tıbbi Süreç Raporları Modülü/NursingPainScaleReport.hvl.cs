
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
    /// Hemşirelik Ağrı Değerlendirme Raporu
    /// </summary>
    public partial class NursingPainScaleReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PartAGroup : TTReportGroup
        {
            public NursingPainScaleReport MyParentReport
            {
                get { return (NursingPainScaleReport)ParentReport; }
            }

            new public PartAGroupHeader Header()
            {
                return (PartAGroupHeader)_header;
            }

            new public PartAGroupFooter Footer()
            {
                return (PartAGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField PRINTDATE { get {return Footer().PRINTDATE;} }
            public TTReportField PAGENUMBER1 { get {return Footer().PAGENUMBER1;} }
            public TTReportField USERNAME { get {return Footer().USERNAME;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
            public PartAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PartAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PartAGroupHeader(this);
                _footer = new PartAGroupFooter(this);

            }

            public partial class PartAGroupHeader : TTReportSection
            {
                public NursingPainScaleReport MyParentReport
                {
                    get { return (NursingPainScaleReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO; 
                public PartAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 44;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 5, 203, 42, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Size = 11;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")+ ""\r\n"" + ""AĞRI DEĞERLENDİRME FORMU""";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 8, 41, 31, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = @"";
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "")+ "\r\n" + "AĞRI DEĞERLENDİRME FORMU";
                    return new TTReportObject[] { LOGO,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion PARTA HEADER_Script
                }
            }
            public partial class PartAGroupFooter : TTReportSection
            {
                public NursingPainScaleReport MyParentReport
                {
                    get { return (NursingPainScaleReport)ParentReport; }
                }
                
                public TTReportField PRINTDATE;
                public TTReportField PAGENUMBER1;
                public TTReportField USERNAME;
                public TTReportShape NewLine11111; 
                public PartAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 22;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PRINTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 8, 143, 13, false);
                    PRINTDATE.Name = "PRINTDATE";
                    PRINTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRINTDATE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PRINTDATE.TextFont.Size = 8;
                    PRINTDATE.TextFont.CharSet = 162;
                    PRINTDATE.Value = @"{@printdate@} - {%USERNAME%}";

                    PAGENUMBER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 8, 203, 13, false);
                    PAGENUMBER1.Name = "PAGENUMBER1";
                    PAGENUMBER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER1.TextFont.Size = 8;
                    PAGENUMBER1.TextFont.CharSet = 162;
                    PAGENUMBER1.Value = @"{@pagenumber@} / {@pagecount@}";

                    USERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 13, 55, 18, false);
                    USERNAME.Name = "USERNAME";
                    USERNAME.Visible = EvetHayirEnum.ehHayir;
                    USERNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    USERNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    USERNAME.TextFont.Size = 8;
                    USERNAME.TextFont.CharSet = 162;
                    USERNAME.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 203, 1, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    USERNAME.CalcValue = TTObjectClasses.Common.CurrentResource.Name;;
                    PRINTDATE.CalcValue = DateTime.Now.ToShortDateString() + @" - " + MyParentReport.PartA.USERNAME.CalcValue;
                    PAGENUMBER1.CalcValue = ParentReport.CurrentPageNumber.ToString() + @" / " + ParentReport.ReportTotalPageCount;
                    return new TTReportObject[] { USERNAME,PRINTDATE,PAGENUMBER1};
                }
            }

        }

        public PartAGroup PartA;

        public partial class PatientGroup : TTReportGroup
        {
            public NursingPainScaleReport MyParentReport
            {
                get { return (NursingPainScaleReport)ParentReport; }
            }

            new public PatientGroupHeader Header()
            {
                return (PatientGroupHeader)_header;
            }

            new public PatientGroupFooter Footer()
            {
                return (PatientGroupFooter)_footer;
            }

            public TTReportField FULLNAME { get {return Header().FULLNAME;} }
            public TTReportField NewField113411 { get {return Header().NewField113411;} }
            public TTReportField lblPAtientName1 { get {return Header().lblPAtientName1;} }
            public TTReportField lblBirth { get {return Header().lblBirth;} }
            public TTReportField BirthDate { get {return Header().BirthDate;} }
            public TTReportField lblNurse { get {return Header().lblNurse;} }
            public TTReportField ResponsibleNurse { get {return Header().ResponsibleNurse;} }
            public TTReportField lblDiag { get {return Header().lblDiag;} }
            public TTReportField Clinic { get {return Header().Clinic;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportField DIAGNOSISFIELD { get {return Header().DIAGNOSISFIELD;} }
            public TTReportField lblBirth1 { get {return Header().lblBirth1;} }
            public TTReportField InpatientDate { get {return Header().InpatientDate;} }
            public TTReportField lblNurse1 { get {return Header().lblNurse1;} }
            public TTReportField ProtocolNo { get {return Header().ProtocolNo;} }
            public TTReportField lblDiag1 { get {return Header().lblDiag1;} }
            public TTReportField BedRoom { get {return Header().BedRoom;} }
            public PatientGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PatientGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PatientGroupHeader(this);
                _footer = new PatientGroupFooter(this);

            }

            public partial class PatientGroupHeader : TTReportSection
            {
                public NursingPainScaleReport MyParentReport
                {
                    get { return (NursingPainScaleReport)ParentReport; }
                }
                
                public TTReportField FULLNAME;
                public TTReportField NewField113411;
                public TTReportField lblPAtientName1;
                public TTReportField lblBirth;
                public TTReportField BirthDate;
                public TTReportField lblNurse;
                public TTReportField ResponsibleNurse;
                public TTReportField lblDiag;
                public TTReportField Clinic;
                public TTReportShape NewLine11;
                public TTReportField DIAGNOSISFIELD;
                public TTReportField lblBirth1;
                public TTReportField InpatientDate;
                public TTReportField lblNurse1;
                public TTReportField ProtocolNo;
                public TTReportField lblDiag1;
                public TTReportField BedRoom; 
                public PatientGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 42;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    FULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 3, 110, 8, false);
                    FULLNAME.Name = "FULLNAME";
                    FULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME.Value = @"";

                    NewField113411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 1, 137, 6, false);
                    NewField113411.Name = "NewField113411";
                    NewField113411.TextFont.Bold = true;
                    NewField113411.TextFont.CharSet = 162;
                    NewField113411.Value = @"Tanı";

                    lblPAtientName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 3, 37, 8, false);
                    lblPAtientName1.Name = "lblPAtientName1";
                    lblPAtientName1.TextFont.Bold = true;
                    lblPAtientName1.TextFont.CharSet = 162;
                    lblPAtientName1.Value = @"Adı Soyadı :";

                    lblBirth = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 8, 37, 13, false);
                    lblBirth.Name = "lblBirth";
                    lblBirth.TextFont.Bold = true;
                    lblBirth.TextFont.CharSet = 162;
                    lblBirth.Value = @"Doğum Tarihi";

                    BirthDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 8, 110, 13, false);
                    BirthDate.Name = "BirthDate";
                    BirthDate.Value = @"";

                    lblNurse = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 13, 37, 18, false);
                    lblNurse.Name = "lblNurse";
                    lblNurse.TextFont.Bold = true;
                    lblNurse.TextFont.CharSet = 162;
                    lblNurse.Value = @"Sorumlu Hemşire";

                    ResponsibleNurse = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 13, 110, 18, false);
                    ResponsibleNurse.Name = "ResponsibleNurse";
                    ResponsibleNurse.Value = @"";

                    lblDiag = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 18, 37, 23, false);
                    lblDiag.Name = "lblDiag";
                    lblDiag.TextFont.Bold = true;
                    lblDiag.TextFont.CharSet = 162;
                    lblDiag.Value = @"Klinik";

                    Clinic = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 18, 110, 23, false);
                    Clinic.Name = "Clinic";
                    Clinic.Value = @"";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 1, 203, 1, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    DIAGNOSISFIELD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 6, 203, 39, false);
                    DIAGNOSISFIELD.Name = "DIAGNOSISFIELD";
                    DIAGNOSISFIELD.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD.Value = @"";

                    lblBirth1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 23, 37, 28, false);
                    lblBirth1.Name = "lblBirth1";
                    lblBirth1.TextFont.Bold = true;
                    lblBirth1.TextFont.CharSet = 162;
                    lblBirth1.Value = @"Yatış Tarihi";

                    InpatientDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 23, 110, 28, false);
                    InpatientDate.Name = "InpatientDate";
                    InpatientDate.Value = @"";

                    lblNurse1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 28, 37, 33, false);
                    lblNurse1.Name = "lblNurse1";
                    lblNurse1.TextFont.Bold = true;
                    lblNurse1.TextFont.CharSet = 162;
                    lblNurse1.Value = @"Protokol No";

                    ProtocolNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 28, 110, 33, false);
                    ProtocolNo.Name = "ProtocolNo";
                    ProtocolNo.Value = @"";

                    lblDiag1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 33, 37, 38, false);
                    lblDiag1.Name = "lblDiag1";
                    lblDiag1.TextFont.Bold = true;
                    lblDiag1.TextFont.CharSet = 162;
                    lblDiag1.Value = @"Oda - Yatak No";

                    BedRoom = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 33, 110, 38, false);
                    BedRoom.Name = "BedRoom";
                    BedRoom.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    FULLNAME.CalcValue = @"";
                    NewField113411.CalcValue = NewField113411.Value;
                    lblPAtientName1.CalcValue = lblPAtientName1.Value;
                    lblBirth.CalcValue = lblBirth.Value;
                    BirthDate.CalcValue = BirthDate.Value;
                    lblNurse.CalcValue = lblNurse.Value;
                    ResponsibleNurse.CalcValue = ResponsibleNurse.Value;
                    lblDiag.CalcValue = lblDiag.Value;
                    Clinic.CalcValue = Clinic.Value;
                    DIAGNOSISFIELD.CalcValue = DIAGNOSISFIELD.Value;
                    lblBirth1.CalcValue = lblBirth1.Value;
                    InpatientDate.CalcValue = InpatientDate.Value;
                    lblNurse1.CalcValue = lblNurse1.Value;
                    ProtocolNo.CalcValue = ProtocolNo.Value;
                    lblDiag1.CalcValue = lblDiag1.Value;
                    BedRoom.CalcValue = BedRoom.Value;
                    return new TTReportObject[] { FULLNAME,NewField113411,lblPAtientName1,lblBirth,BirthDate,lblNurse,ResponsibleNurse,lblDiag,Clinic,DIAGNOSISFIELD,lblBirth1,InpatientDate,lblNurse1,ProtocolNo,lblDiag1,BedRoom};
                }

                public override void RunScript()
                {
#region PATIENT HEADER_Script
                    string diagnoseStr = "";
            TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((NursingPainScaleReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            NursingApplication p = (NursingApplication)context.GetObject(new Guid(sObjectID), "NursingApplication");
            
//            NursingPainScale painScale = (NursingPainScale)context.GetObject(new Guid(sObjectID), "NursingPainScale");
//            NursingApplication p = painScale?.NursingApplication;
            
            DateTime? birthDate = p.Episode.Patient.BirthDate;
            ResUser nurse = p.InPatientTreatmentClinicApp.ResponsibleNurse;
            ResSection clinic = p.InPatientTreatmentClinicApp.MasterResource;
            
            this.FULLNAME.CalcValue = p.Episode.Patient.Name + " " + p.Episode.Patient.Surname;
            this.BirthDate.CalcValue = birthDate != null ? birthDate.Value.ToString("dd/MM/yyyy") : "";
            this.ResponsibleNurse.CalcValue = nurse != null ? nurse.Name : "";
            this.Clinic.CalcValue = clinic != null ? clinic.Name : "";
            this.InpatientDate.CalcValue = p.InPatientTreatmentClinicApp.ClinicInpatientDate != null ?p.InPatientTreatmentClinicApp.ClinicInpatientDate.Value.ToString("dd/MM/yyyy") : "";
            this.ProtocolNo.CalcValue =p.InPatientTreatmentClinicApp.ProtocolNo.Value.ToString();
            this.BedRoom.CalcValue =p.InPatientTreatmentClinicApp.BaseInpatientAdmission.Room.Name + " - " + p.InPatientTreatmentClinicApp.BaseInpatientAdmission.Bed.Name;

            if (p.Episode.Diagnosis.Count > 0)// Buradan tanı girişi yapılmadıysa episodedaki kesin  tanılara bakar
            {
                foreach (DiagnosisGrid diagnosis in p.Episode.Diagnosis)
                {
                    diagnoseStr = diagnosis.Diagnose.Code + "-" + diagnosis.Diagnose.Name + "-" + diagnosis.FreeDiagnosis + "; " + "\n" + diagnoseStr;
                }
            }
            
            this.DIAGNOSISFIELD.CalcValue = diagnoseStr;
#endregion PATIENT HEADER_Script
                }
            }
            public partial class PatientGroupFooter : TTReportSection
            {
                public NursingPainScaleReport MyParentReport
                {
                    get { return (NursingPainScaleReport)ParentReport; }
                }
                 
                public PatientGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PatientGroup Patient;

        public partial class SummaryGroup : TTReportGroup
        {
            public NursingPainScaleReport MyParentReport
            {
                get { return (NursingPainScaleReport)ParentReport; }
            }

            new public SummaryGroupHeader Header()
            {
                return (SummaryGroupHeader)_header;
            }

            new public SummaryGroupFooter Footer()
            {
                return (SummaryGroupFooter)_footer;
            }

            public TTReportField Agri11 { get {return Header().Agri11;} }
            public TTReportField Agri111 { get {return Header().Agri111;} }
            public TTReportField Agri121 { get {return Header().Agri121;} }
            public TTReportField Agri1111 { get {return Header().Agri1111;} }
            public TTReportField Agri1121 { get {return Header().Agri1121;} }
            public TTReportField Agri11111 { get {return Header().Agri11111;} }
            public TTReportField Agri11211 { get {return Header().Agri11211;} }
            public TTReportField Agri111111 { get {return Header().Agri111111;} }
            public TTReportField Agri131 { get {return Header().Agri131;} }
            public TTReportField Agri1131 { get {return Header().Agri1131;} }
            public TTReportField Agri1211 { get {return Header().Agri1211;} }
            public TTReportField Agri11121 { get {return Header().Agri11121;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public SummaryGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public SummaryGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new SummaryGroupHeader(this);
                _footer = new SummaryGroupFooter(this);

            }

            public partial class SummaryGroupHeader : TTReportSection
            {
                public NursingPainScaleReport MyParentReport
                {
                    get { return (NursingPainScaleReport)ParentReport; }
                }
                
                public TTReportField Agri11;
                public TTReportField Agri111;
                public TTReportField Agri121;
                public TTReportField Agri1111;
                public TTReportField Agri1121;
                public TTReportField Agri11111;
                public TTReportField Agri11211;
                public TTReportField Agri111111;
                public TTReportField Agri131;
                public TTReportField Agri1131;
                public TTReportField Agri1211;
                public TTReportField Agri11121;
                public TTReportField NewField1;
                public TTReportField NewField111;
                public TTReportField NewField11; 
                public SummaryGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 98;
                    RepeatCount = 0;
                    
                    Agri11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 46, 6, false);
                    Agri11.Name = "Agri11";
                    Agri11.TextFont.Bold = true;
                    Agri11.TextFont.CharSet = 162;
                    Agri11.Value = @"Ağrının niteliği";

                    Agri111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 7, 46, 37, false);
                    Agri111.Name = "Agri111";
                    Agri111.MultiLine = EvetHayirEnum.ehEvet;
                    Agri111.NoClip = EvetHayirEnum.ehEvet;
                    Agri111.WordBreak = EvetHayirEnum.ehEvet;
                    Agri111.ExpandTabs = EvetHayirEnum.ehEvet;
                    Agri111.TextFont.CharSet = 162;
                    Agri111.Value = @"Zonklayıcı
Yanıcı
Batıcı
Sızlayıcı
Bıçak saplanır tarzda
Kasılma
Diğer
";

                    Agri121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 1, 93, 6, false);
                    Agri121.Name = "Agri121";
                    Agri121.TextFont.Bold = true;
                    Agri121.TextFont.CharSet = 162;
                    Agri121.Value = @"Ağrının sıklığı";

                    Agri1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 7, 93, 36, false);
                    Agri1111.Name = "Agri1111";
                    Agri1111.MultiLine = EvetHayirEnum.ehEvet;
                    Agri1111.NoClip = EvetHayirEnum.ehEvet;
                    Agri1111.WordBreak = EvetHayirEnum.ehEvet;
                    Agri1111.ExpandTabs = EvetHayirEnum.ehEvet;
                    Agri1111.TextFont.CharSet = 162;
                    Agri1111.Value = @"Zaman zaman
Sık sık
Sürekli
Uykudan uyandırıyor
";

                    Agri1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 1, 149, 6, false);
                    Agri1121.Name = "Agri1121";
                    Agri1121.TextFont.Bold = true;
                    Agri1121.TextFont.CharSet = 162;
                    Agri1121.Value = @"Ağrının arttığı durumlar";

                    Agri11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 7, 149, 35, false);
                    Agri11111.Name = "Agri11111";
                    Agri11111.MultiLine = EvetHayirEnum.ehEvet;
                    Agri11111.NoClip = EvetHayirEnum.ehEvet;
                    Agri11111.WordBreak = EvetHayirEnum.ehEvet;
                    Agri11111.ExpandTabs = EvetHayirEnum.ehEvet;
                    Agri11111.TextFont.CharSet = 162;
                    Agri11111.Value = @"Oturma
Tedavi
Masaj
Hareket
Diğer
";

                    Agri11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 1, 203, 6, false);
                    Agri11211.Name = "Agri11211";
                    Agri11211.TextFont.Bold = true;
                    Agri11211.TextFont.CharSet = 162;
                    Agri11211.Value = @"Ağrının azaldığı durumlar";

                    Agri111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 7, 203, 37, false);
                    Agri111111.Name = "Agri111111";
                    Agri111111.MultiLine = EvetHayirEnum.ehEvet;
                    Agri111111.NoClip = EvetHayirEnum.ehEvet;
                    Agri111111.WordBreak = EvetHayirEnum.ehEvet;
                    Agri111111.ExpandTabs = EvetHayirEnum.ehEvet;
                    Agri111111.TextFont.CharSet = 162;
                    Agri111111.Value = @"Pozisyon
Masaj
Tedavi
Hareket
Ortam değişikliği
İlaç
Diğer
";

                    Agri131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 37, 203, 42, false);
                    Agri131.Name = "Agri131";
                    Agri131.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    Agri131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Agri131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Agri131.TextFont.Bold = true;
                    Agri131.TextFont.CharSet = 162;
                    Agri131.Value = @"AĞRININ ŞİDDETİ";

                    Agri1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 64, 203, 69, false);
                    Agri1131.Name = "Agri1131";
                    Agri1131.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    Agri1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Agri1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Agri1131.TextFont.Bold = true;
                    Agri1131.TextFont.CharSet = 162;
                    Agri1131.Value = @"HEMŞİRELİK GİRİŞİMLERİ";

                    Agri1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 71, 98, 97, false);
                    Agri1211.Name = "Agri1211";
                    Agri1211.MultiLine = EvetHayirEnum.ehEvet;
                    Agri1211.NoClip = EvetHayirEnum.ehEvet;
                    Agri1211.WordBreak = EvetHayirEnum.ehEvet;
                    Agri1211.ExpandTabs = EvetHayirEnum.ehEvet;
                    Agri1211.TextFont.CharSet = 162;
                    Agri1211.Value = @"1. Pozisyon değiştirmek
2. Masaj, sıcak-soğuk uygulama
3. Dikkati başka yöne çekmek (radyo, tv, müzik vb.)
4. Ağrı nedenlerini azaltma yötemleri konusunda eğitim, iletişim
5. Çevrenin sakin, sessiz ve loş ışıklı  olmasını sağlamak
6. Gevşeme tekniklerini öğretmek
";

                    Agri11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 71, 203, 97, false);
                    Agri11121.Name = "Agri11121";
                    Agri11121.MultiLine = EvetHayirEnum.ehEvet;
                    Agri11121.NoClip = EvetHayirEnum.ehEvet;
                    Agri11121.WordBreak = EvetHayirEnum.ehEvet;
                    Agri11121.ExpandTabs = EvetHayirEnum.ehEvet;
                    Agri11121.TextFont.CharSet = 162;
                    Agri11121.Value = @" 7. Ağız bakımı 
 8. Havalı yatak kullanmak
 9. Arzu ettiği kişilerle görüşmesini sağlamak
10. Ilık banyo
11. Farmakolojik girişim
12. Diğer
";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 57, 152, 63, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Yok                                    Orta                                    Şiddetli";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 44, 137, 51, false);
                    NewField111.Name = "NewField111";
                    NewField111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111.NoClip = EvetHayirEnum.ehEvet;
                    NewField111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"ı       ı       ı       ı       ı       ı        ı       ı        ı       ı       ı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 51, 134, 57, false);
                    NewField11.Name = "NewField11";
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.NoClip = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"0      1      2      3      4      5       6      7       8      9      10";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Agri11.CalcValue = Agri11.Value;
                    Agri111.CalcValue = Agri111.Value;
                    Agri121.CalcValue = Agri121.Value;
                    Agri1111.CalcValue = Agri1111.Value;
                    Agri1121.CalcValue = Agri1121.Value;
                    Agri11111.CalcValue = Agri11111.Value;
                    Agri11211.CalcValue = Agri11211.Value;
                    Agri111111.CalcValue = Agri111111.Value;
                    Agri131.CalcValue = Agri131.Value;
                    Agri1131.CalcValue = Agri1131.Value;
                    Agri1211.CalcValue = Agri1211.Value;
                    Agri11121.CalcValue = Agri11121.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField11.CalcValue = NewField11.Value;
                    return new TTReportObject[] { Agri11,Agri111,Agri121,Agri1111,Agri1121,Agri11111,Agri11211,Agri111111,Agri131,Agri1131,Agri1211,Agri11121,NewField1,NewField111,NewField11};
                }
            }
            public partial class SummaryGroupFooter : TTReportSection
            {
                public NursingPainScaleReport MyParentReport
                {
                    get { return (NursingPainScaleReport)ParentReport; }
                }
                 
                public SummaryGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public SummaryGroup Summary;

        public partial class MAINGroup : TTReportGroup
        {
            public NursingPainScaleReport MyParentReport
            {
                get { return (NursingPainScaleReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField UYGULAMA_ZAMANI { get {return Body().UYGULAMA_ZAMANI;} }
            public TTReportField AGRIYAN_TARAF { get {return Body().AGRIYAN_TARAF;} }
            public TTReportField AGRI_DETAY { get {return Body().AGRI_DETAY;} }
            public TTReportField AGRI_YERI { get {return Body().AGRI_YERI;} }
            public TTReportField AGRI_ZAMAN { get {return Body().AGRI_ZAMAN;} }
            public TTReportField AGRI_SURESI { get {return Body().AGRI_SURESI;} }
            public TTReportField AGRI_NITELIK { get {return Body().AGRI_NITELIK;} }
            public TTReportField NITELIK_ACIKLAMA { get {return Body().NITELIK_ACIKLAMA;} }
            public TTReportField AGRI_SIKLIK { get {return Body().AGRI_SIKLIK;} }
            public TTReportField ARTTIGI_DURUM { get {return Body().ARTTIGI_DURUM;} }
            public TTReportField AZALDIGI_DURUM { get {return Body().AZALDIGI_DURUM;} }
            public TTReportField HEMSIRELIK_GIRISIMI { get {return Body().HEMSIRELIK_GIRISIMI;} }
            public TTReportField GIRISIM_SONRASI { get {return Body().GIRISIM_SONRASI;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
            public TTReportField NewField112 { get {return Body().NewField112;} }
            public TTReportField NewField1211 { get {return Body().NewField1211;} }
            public TTReportField NewField1212 { get {return Body().NewField1212;} }
            public TTReportField NewField12121 { get {return Body().NewField12121;} }
            public TTReportField NewField112121 { get {return Body().NewField112121;} }
            public TTReportField NewField12122 { get {return Body().NewField12122;} }
            public TTReportField NewField122121 { get {return Body().NewField122121;} }
            public TTReportField NewField1121221 { get {return Body().NewField1121221;} }
            public TTReportField AGRI_SIDDETI { get {return Body().AGRI_SIDDETI;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField NewField1121222 { get {return Body().NewField1121222;} }
            public TTReportField imza { get {return Body().imza;} }
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
                list[0] = new TTReportNqlData<NursingPainScale.GetPainScale_Class>("GetPainScale", NursingPainScale.GetPainScale((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public NursingPainScaleReport MyParentReport
                {
                    get { return (NursingPainScaleReport)ParentReport; }
                }
                
                public TTReportField UYGULAMA_ZAMANI;
                public TTReportField AGRIYAN_TARAF;
                public TTReportField AGRI_DETAY;
                public TTReportField AGRI_YERI;
                public TTReportField AGRI_ZAMAN;
                public TTReportField AGRI_SURESI;
                public TTReportField AGRI_NITELIK;
                public TTReportField NITELIK_ACIKLAMA;
                public TTReportField AGRI_SIKLIK;
                public TTReportField ARTTIGI_DURUM;
                public TTReportField AZALDIGI_DURUM;
                public TTReportField HEMSIRELIK_GIRISIMI;
                public TTReportField GIRISIM_SONRASI;
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField112;
                public TTReportField NewField1211;
                public TTReportField NewField1212;
                public TTReportField NewField12121;
                public TTReportField NewField112121;
                public TTReportField NewField12122;
                public TTReportField NewField122121;
                public TTReportField NewField1121221;
                public TTReportField AGRI_SIDDETI;
                public TTReportShape NewLine111;
                public TTReportField OBJECTID;
                public TTReportField NewField1121222;
                public TTReportField imza; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 80;
                    RepeatCount = 0;
                    
                    UYGULAMA_ZAMANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 5, 81, 10, false);
                    UYGULAMA_ZAMANI.Name = "UYGULAMA_ZAMANI";
                    UYGULAMA_ZAMANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    UYGULAMA_ZAMANI.Value = @"{#UYGULAMA_ZAMANI#}";

                    AGRIYAN_TARAF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 17, 113, 22, false);
                    AGRIYAN_TARAF.Name = "AGRIYAN_TARAF";
                    AGRIYAN_TARAF.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGRIYAN_TARAF.Value = @"{#AGRIYAN_TARAF#}";

                    AGRI_DETAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 23, 113, 28, false);
                    AGRI_DETAY.Name = "AGRI_DETAY";
                    AGRI_DETAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGRI_DETAY.Value = @"{#AGRI_DETAY#}";

                    AGRI_YERI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 11, 113, 16, false);
                    AGRI_YERI.Name = "AGRI_YERI";
                    AGRI_YERI.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGRI_YERI.Value = @"{#AGRI_YERI#}";

                    AGRI_ZAMAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 41, 113, 46, false);
                    AGRI_ZAMAN.Name = "AGRI_ZAMAN";
                    AGRI_ZAMAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGRI_ZAMAN.Value = @"{#AGRI_ZAMAN#}";

                    AGRI_SURESI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 47, 113, 52, false);
                    AGRI_SURESI.Name = "AGRI_SURESI";
                    AGRI_SURESI.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGRI_SURESI.Value = @"{#AGRI_SURESI#}";

                    AGRI_NITELIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 53, 113, 58, false);
                    AGRI_NITELIK.Name = "AGRI_NITELIK";
                    AGRI_NITELIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGRI_NITELIK.Value = @"{#AGRI_NITELIK#}";

                    NITELIK_ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 59, 203, 64, false);
                    NITELIK_ACIKLAMA.Name = "NITELIK_ACIKLAMA";
                    NITELIK_ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    NITELIK_ACIKLAMA.Value = @"{#NITELIK_ACIKLAMA#}";

                    AGRI_SIKLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 29, 113, 34, false);
                    AGRI_SIKLIK.Name = "AGRI_SIKLIK";
                    AGRI_SIKLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGRI_SIKLIK.Value = @"{#AGRI_SIKLIK#}";

                    ARTTIGI_DURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 17, 203, 22, false);
                    ARTTIGI_DURUM.Name = "ARTTIGI_DURUM";
                    ARTTIGI_DURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    ARTTIGI_DURUM.MultiLine = EvetHayirEnum.ehEvet;
                    ARTTIGI_DURUM.NoClip = EvetHayirEnum.ehEvet;
                    ARTTIGI_DURUM.WordBreak = EvetHayirEnum.ehEvet;
                    ARTTIGI_DURUM.ExpandTabs = EvetHayirEnum.ehEvet;
                    ARTTIGI_DURUM.Value = @"";

                    AZALDIGI_DURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 29, 203, 34, false);
                    AZALDIGI_DURUM.Name = "AZALDIGI_DURUM";
                    AZALDIGI_DURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    AZALDIGI_DURUM.Value = @"";

                    HEMSIRELIK_GIRISIMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 41, 203, 46, false);
                    HEMSIRELIK_GIRISIMI.Name = "HEMSIRELIK_GIRISIMI";
                    HEMSIRELIK_GIRISIMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEMSIRELIK_GIRISIMI.Value = @"";

                    GIRISIM_SONRASI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 53, 203, 58, false);
                    GIRISIM_SONRASI.Name = "GIRISIM_SONRASI";
                    GIRISIM_SONRASI.FieldType = ReportFieldTypeEnum.ftVariable;
                    GIRISIM_SONRASI.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 5, 37, 10, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Uygulama Zamanı";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 17, 37, 22, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Ağrıyan Taraf";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 23, 37, 28, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Ağrı Detay";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 11, 37, 16, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Ağrının Yeri";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 41, 37, 46, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Ne Zamandır Var";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 47, 37, 52, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Ağrı Süresi";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 53, 37, 58, false);
                    NewField112.Name = "NewField112";
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"Ağrının Niteliği";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 59, 37, 64, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.TextFont.Bold = true;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @"Nitelik Açıklama";

                    NewField1212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 29, 37, 34, false);
                    NewField1212.Name = "NewField1212";
                    NewField1212.TextFont.Bold = true;
                    NewField1212.TextFont.CharSet = 162;
                    NewField1212.Value = @"Ağrının Sıklığı";

                    NewField12121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 11, 203, 16, false);
                    NewField12121.Name = "NewField12121";
                    NewField12121.TextFont.Bold = true;
                    NewField12121.TextFont.CharSet = 162;
                    NewField12121.Value = @"Ağrının Arttığı Durumlar";

                    NewField112121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 23, 203, 28, false);
                    NewField112121.Name = "NewField112121";
                    NewField112121.TextFont.Bold = true;
                    NewField112121.TextFont.CharSet = 162;
                    NewField112121.Value = @"Ağrının Arttığı Durumlar";

                    NewField12122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 35, 37, 40, false);
                    NewField12122.Name = "NewField12122";
                    NewField12122.TextFont.Bold = true;
                    NewField12122.TextFont.CharSet = 162;
                    NewField12122.Value = @"Ağrının Şiddeti";

                    NewField122121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 35, 203, 40, false);
                    NewField122121.Name = "NewField122121";
                    NewField122121.TextFont.Bold = true;
                    NewField122121.TextFont.CharSet = 162;
                    NewField122121.Value = @"Hemşirelik Girişimleri";

                    NewField1121221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 47, 203, 52, false);
                    NewField1121221.Name = "NewField1121221";
                    NewField1121221.TextFont.Bold = true;
                    NewField1121221.TextFont.CharSet = 162;
                    NewField1121221.Value = @"Hemşirelik Girişimleri";

                    AGRI_SIDDETI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 35, 113, 40, false);
                    AGRI_SIDDETI.Name = "AGRI_SIDDETI";
                    AGRI_SIDDETI.FieldType = ReportFieldTypeEnum.ftVariable;
                    AGRI_SIDDETI.Value = @"";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 3, 203, 3, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 3, 238, 8, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    NewField1121222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 65, 203, 70, false);
                    NewField1121222.Name = "NewField1121222";
                    NewField1121222.TextFont.Bold = true;
                    NewField1121222.TextFont.CharSet = 162;
                    NewField1121222.Value = @"İmza:";

                    imza = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 72, 203, 78, false);
                    imza.Name = "imza";
                    imza.TextFont.CharSet = 162;
                    imza.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NursingPainScale.GetPainScale_Class dataset_GetPainScale = ParentGroup.rsGroup.GetCurrentRecord<NursingPainScale.GetPainScale_Class>(0);
                    UYGULAMA_ZAMANI.CalcValue = (dataset_GetPainScale != null ? Globals.ToStringCore(dataset_GetPainScale.Uygulama_zamani) : "");
                    AGRIYAN_TARAF.CalcValue = (dataset_GetPainScale != null ? Globals.ToStringCore(dataset_GetPainScale.Agriyan_taraf) : "");
                    AGRI_DETAY.CalcValue = (dataset_GetPainScale != null ? Globals.ToStringCore(dataset_GetPainScale.Agri_detay) : "");
                    AGRI_YERI.CalcValue = (dataset_GetPainScale != null ? Globals.ToStringCore(dataset_GetPainScale.Agri_yeri) : "");
                    AGRI_ZAMAN.CalcValue = (dataset_GetPainScale != null ? Globals.ToStringCore(dataset_GetPainScale.Agri_zaman) : "");
                    AGRI_SURESI.CalcValue = (dataset_GetPainScale != null ? Globals.ToStringCore(dataset_GetPainScale.Agri_suresi) : "");
                    AGRI_NITELIK.CalcValue = (dataset_GetPainScale != null ? Globals.ToStringCore(dataset_GetPainScale.Agri_nitelik) : "");
                    NITELIK_ACIKLAMA.CalcValue = (dataset_GetPainScale != null ? Globals.ToStringCore(dataset_GetPainScale.Nitelik_aciklama) : "");
                    AGRI_SIKLIK.CalcValue = (dataset_GetPainScale != null ? Globals.ToStringCore(dataset_GetPainScale.Agri_siklik) : "");
                    ARTTIGI_DURUM.CalcValue = @"";
                    AZALDIGI_DURUM.CalcValue = @"";
                    HEMSIRELIK_GIRISIMI.CalcValue = @"";
                    GIRISIM_SONRASI.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField1212.CalcValue = NewField1212.Value;
                    NewField12121.CalcValue = NewField12121.Value;
                    NewField112121.CalcValue = NewField112121.Value;
                    NewField12122.CalcValue = NewField12122.Value;
                    NewField122121.CalcValue = NewField122121.Value;
                    NewField1121221.CalcValue = NewField1121221.Value;
                    AGRI_SIDDETI.CalcValue = @"";
                    OBJECTID.CalcValue = (dataset_GetPainScale != null ? Globals.ToStringCore(dataset_GetPainScale.ObjectID) : "");
                    NewField1121222.CalcValue = NewField1121222.Value;
                    imza.CalcValue = imza.Value;
                    return new TTReportObject[] { UYGULAMA_ZAMANI,AGRIYAN_TARAF,AGRI_DETAY,AGRI_YERI,AGRI_ZAMAN,AGRI_SURESI,AGRI_NITELIK,NITELIK_ACIKLAMA,AGRI_SIKLIK,ARTTIGI_DURUM,AZALDIGI_DURUM,HEMSIRELIK_GIRISIMI,GIRISIM_SONRASI,NewField1,NewField2,NewField12,NewField11,NewField111,NewField1111,NewField112,NewField1211,NewField1212,NewField12121,NewField112121,NewField12122,NewField122121,NewField1121221,AGRI_SIDDETI,OBJECTID,NewField1121222,imza};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
                    NursingPainScale painScale = (NursingPainScale)context.GetObject(new Guid(this.OBJECTID.CalcValue), "NursingPainScale");
                    this.imza.CalcValue = painScale.ApplicationUser.Name;
                    
                    foreach (var data in painScale.PainScaleIncreaseGrids)
                    {
                        this.ARTTIGI_DURUM.CalcValue += data.PainChangingSituation.Description + " - ";
                    }
                    foreach (var data in painScale.PainScaleDecreaseGrid)
                    {
                        this.AZALDIGI_DURUM.CalcValue += data.PainChangingSituation.Description + " - ";
                    }
                    foreach (var data in painScale.NursingInitiatives)
                    {
                        this.HEMSIRELIK_GIRISIMI.CalcValue += data.NursingInitiatives.Initiative + " - ";
                    }

                    if(painScale.PostNursingInitiative == PostNursingInitiativesEnum.NoChange)
                    {
                        this.GIRISIM_SONRASI.CalcValue = "Değişiklik yok";
                    }
                    else if (painScale.PostNursingInitiative == PostNursingInitiativesEnum.Increase)
                    {
                        this.GIRISIM_SONRASI.CalcValue = "Ağrıda artma var";
                    }
                    else if (painScale.PostNursingInitiative == PostNursingInitiativesEnum.Decrease)
                    {
                        this.GIRISIM_SONRASI.CalcValue = "Ağrıda azalma var";
                    }
                    
                    if(painScale.PainFaceScale == PainFaceScaleEnum.None)
                    {
                        this.AGRI_SIDDETI.CalcValue = "Ağrım Yok";
                    }
                    else if (painScale.PainFaceScale == PainFaceScaleEnum.FleaBite)
                    {
                        this.AGRI_SIDDETI.CalcValue = "Hafif Ağrım Var";
                    }
                    else if (painScale.PainFaceScale == PainFaceScaleEnum.MediumPain)
                    {
                        this.AGRI_SIDDETI.CalcValue = "Orta Şiddette Ağrım Var";
                    }
                    else if (painScale.PainFaceScale == PainFaceScaleEnum.LotofPain)
                    {
                        this.AGRI_SIDDETI.CalcValue = "Çok Ağrım Var";
                    }
                    else if (painScale.PainFaceScale == PainFaceScaleEnum.AcutePain)
                    {
                        this.AGRI_SIDDETI.CalcValue = "Şiddetli Ağrım Var";
                    }
                    else if (painScale.PainFaceScale == PainFaceScaleEnum.VerySeverePain)
                    {
                        this.AGRI_SIDDETI.CalcValue = "Çok Şiddetli Ağrım Var";
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

        public NursingPainScaleReport()
        {
            PartA = new PartAGroup(this,"PartA");
            Patient = new PatientGroup(PartA,"Patient");
            Summary = new SummaryGroup(Patient,"Summary");
            MAIN = new MAINGroup(Summary,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "TTOBJECTID", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "NURSINGPAINSCALEREPORT";
            Caption = "Hemşirelik Ağrı Değerlendirme Raporu";
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