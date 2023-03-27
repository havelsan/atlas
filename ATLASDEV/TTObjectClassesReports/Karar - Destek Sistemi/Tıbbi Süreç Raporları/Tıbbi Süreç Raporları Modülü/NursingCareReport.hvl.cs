
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
    /// Hemşirelik Bakım
    /// </summary>
    public partial class NursingCareReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
        }

        public partial class PartAGroup : TTReportGroup
        {
            public NursingCareReport MyParentReport
            {
                get { return (NursingCareReport)ParentReport; }
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
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
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
                public NursingCareReport MyParentReport
                {
                    get { return (NursingCareReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO;
                public TTReportField NewField1111; 
                public PartAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 57;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 5, 234, 46, false);
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
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

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

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 48, 234, 56, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Hemşire Bakım Planı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = @"";
                    NewField1111.CalcValue = NewField1111.Value;
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { LOGO,NewField1111,XXXXXXBASLIK};
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
                public NursingCareReport MyParentReport
                {
                    get { return (NursingCareReport)ParentReport; }
                }
                 
                public PartAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PartAGroup PartA;

        public partial class PatientGroup : TTReportGroup
        {
            public NursingCareReport MyParentReport
            {
                get { return (NursingCareReport)ParentReport; }
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
            public TTReportField DIAGNOSISFIELD { get {return Header().DIAGNOSISFIELD;} }
            public TTReportField NewField113411 { get {return Header().NewField113411;} }
            public TTReportField lblPAtientName1 { get {return Header().lblPAtientName1;} }
            public TTReportField lblBirth { get {return Header().lblBirth;} }
            public TTReportField BirthDate { get {return Header().BirthDate;} }
            public TTReportField lblNurse { get {return Header().lblNurse;} }
            public TTReportField ResponsibleNurse { get {return Header().ResponsibleNurse;} }
            public TTReportField lblDiag { get {return Header().lblDiag;} }
            public TTReportField Clinic { get {return Header().Clinic;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1a { get {return Header().NewField1a;} }
            public TTReportField NewField113 { get {return Header().NewField113;} }
            public TTReportField NewField114 { get {return Header().NewField114;} }
            public TTReportField NewField115 { get {return Header().NewField115;} }
            public TTReportField NewField116 { get {return Header().NewField116;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
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
                public NursingCareReport MyParentReport
                {
                    get { return (NursingCareReport)ParentReport; }
                }
                
                public TTReportField FULLNAME;
                public TTReportField DIAGNOSISFIELD;
                public TTReportField NewField113411;
                public TTReportField lblPAtientName1;
                public TTReportField lblBirth;
                public TTReportField BirthDate;
                public TTReportField lblNurse;
                public TTReportField ResponsibleNurse;
                public TTReportField lblDiag;
                public TTReportField Clinic;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField1a;
                public TTReportField NewField113;
                public TTReportField NewField114;
                public TTReportField NewField115;
                public TTReportField NewField116;
                public TTReportShape NewLine11; 
                public PatientGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 47;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    FULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 3, 123, 8, false);
                    FULLNAME.Name = "FULLNAME";
                    FULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME.Value = @"";

                    DIAGNOSISFIELD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 6, 237, 37, false);
                    DIAGNOSISFIELD.Name = "DIAGNOSISFIELD";
                    DIAGNOSISFIELD.MultiLine = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD.WordBreak = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD.ExpandTabs = EvetHayirEnum.ehEvet;
                    DIAGNOSISFIELD.Value = @"";

                    NewField113411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 2, 165, 7, false);
                    NewField113411.Name = "NewField113411";
                    NewField113411.TextFont.Bold = true;
                    NewField113411.TextFont.CharSet = 162;
                    NewField113411.Value = @"Tanı";

                    lblPAtientName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 3, 37, 8, false);
                    lblPAtientName1.Name = "lblPAtientName1";
                    lblPAtientName1.Value = @"Adı Soyadı :";

                    lblBirth = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 10, 37, 15, false);
                    lblBirth.Name = "lblBirth";
                    lblBirth.Value = @"Doğum Tarihi";

                    BirthDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 10, 123, 15, false);
                    BirthDate.Name = "BirthDate";
                    BirthDate.Value = @"";

                    lblNurse = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 17, 37, 22, false);
                    lblNurse.Name = "lblNurse";
                    lblNurse.Value = @"Sorumlu Hemşire";

                    ResponsibleNurse = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 17, 123, 22, false);
                    ResponsibleNurse.Name = "ResponsibleNurse";
                    ResponsibleNurse.Value = @"";

                    lblDiag = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 24, 37, 29, false);
                    lblDiag.Name = "lblDiag";
                    lblDiag.Value = @"Klinik";

                    Clinic = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 24, 123, 29, false);
                    Clinic.Name = "Clinic";
                    Clinic.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 42, 39, 47, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Tarih";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 42, 73, 47, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Tanı";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 42, 104, 47, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Neden";

                    NewField1a = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 43, 145, 48, false);
                    NewField1a.Name = "NewField1a";
                    NewField1a.TextFont.Name = "Arial";
                    NewField1a.TextFont.Bold = true;
                    NewField1a.TextFont.CharSet = 162;
                    NewField1a.Value = @"Hemşirelik Girişimi";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 42, 189, 47, false);
                    NewField113.Name = "NewField113";
                    NewField113.TextFont.Name = "Arial";
                    NewField113.TextFont.Bold = true;
                    NewField113.TextFont.CharSet = 162;
                    NewField113.Value = @"Hedef";

                    NewField114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 42, 230, 47, false);
                    NewField114.Name = "NewField114";
                    NewField114.TextFont.Name = "Arial";
                    NewField114.TextFont.Bold = true;
                    NewField114.TextFont.CharSet = 162;
                    NewField114.Value = @"Değerlendirme";

                    NewField115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 42, 260, 47, false);
                    NewField115.Name = "NewField115";
                    NewField115.TextFont.Name = "Arial";
                    NewField115.TextFont.Bold = true;
                    NewField115.TextFont.CharSet = 162;
                    NewField115.Value = @"Kayıt Eden";

                    NewField116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, 42, 282, 47, false);
                    NewField116.Name = "NewField116";
                    NewField116.TextFont.Name = "Arial";
                    NewField116.TextFont.Bold = true;
                    NewField116.TextFont.CharSet = 162;
                    NewField116.Value = @"İmza";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 12, 1, 280, 1, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    FULLNAME.CalcValue = @"";
                    DIAGNOSISFIELD.CalcValue = DIAGNOSISFIELD.Value;
                    NewField113411.CalcValue = NewField113411.Value;
                    lblPAtientName1.CalcValue = lblPAtientName1.Value;
                    lblBirth.CalcValue = lblBirth.Value;
                    BirthDate.CalcValue = BirthDate.Value;
                    lblNurse.CalcValue = lblNurse.Value;
                    ResponsibleNurse.CalcValue = ResponsibleNurse.Value;
                    lblDiag.CalcValue = lblDiag.Value;
                    Clinic.CalcValue = Clinic.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1a.CalcValue = NewField1a.Value;
                    NewField113.CalcValue = NewField113.Value;
                    NewField114.CalcValue = NewField114.Value;
                    NewField115.CalcValue = NewField115.Value;
                    NewField116.CalcValue = NewField116.Value;
                    return new TTReportObject[] { FULLNAME,DIAGNOSISFIELD,NewField113411,lblPAtientName1,lblBirth,BirthDate,lblNurse,ResponsibleNurse,lblDiag,Clinic,NewField1,NewField11,NewField111,NewField1a,NewField113,NewField114,NewField115,NewField116};
                }

                public override void RunScript()
                {
#region PATIENT HEADER_Script
                    string diagnoseStr = "";
            TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((NursingCareReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            NursingApplication p = (NursingApplication)context.GetObject(new Guid(sObjectID), "NursingApplication");
            
            DateTime? birthDate = p.Episode.Patient.BirthDate;
            ResUser nurse = p.InPatientTreatmentClinicApp.ResponsibleNurse;
            ResSection clinic = p.InPatientTreatmentClinicApp.MasterResource;
            
            this.FULLNAME.CalcValue = p.Episode.Patient.Name + " " + p.Episode.Patient.Surname;
            this.BirthDate.CalcValue = birthDate != null ? birthDate.Value.ToString("dd/MM/yyyy") : "";
            this.ResponsibleNurse.CalcValue = nurse != null ? nurse.Name : "";
            this.Clinic.CalcValue = clinic != null ? clinic.Name : "";

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
                public NursingCareReport MyParentReport
                {
                    get { return (NursingCareReport)ParentReport; }
                }
                 
                public PatientGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PatientGroup Patient;

        public partial class MAINGroup : TTReportGroup
        {
            public NursingCareReport MyParentReport
            {
                get { return (NursingCareReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField Tanı { get {return Body().Tanı;} }
            public TTReportField Neden { get {return Body().Neden;} }
            public TTReportField Girisim { get {return Body().Girisim;} }
            public TTReportField Hedef { get {return Body().Hedef;} }
            public TTReportField NewField6 { get {return Body().NewField6;} }
            public TTReportField NewField7 { get {return Body().NewField7;} }
            public TTReportField NewField8 { get {return Body().NewField8;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField ObjectID { get {return Body().ObjectID;} }
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
                list[0] = new TTReportNqlData<NursingCare.GetNursingCaresByNursingApplication_Class>("GetNursingCaresByNursingApplication", NursingCare.GetNursingCaresByNursingApplication((string)TTObjectDefManager.Instance.DataTypes["String_50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public NursingCareReport MyParentReport
                {
                    get { return (NursingCareReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField Tanı;
                public TTReportField Neden;
                public TTReportField Girisim;
                public TTReportField Hedef;
                public TTReportField NewField6;
                public TTReportField NewField7;
                public TTReportField NewField8;
                public TTReportShape NewLine1;
                public TTReportField ObjectID; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 4, 39, 9, false);
                    NewField1.Name = "NewField1";
                    NewField1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.NoClip = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Name = "Arial Unicode MS";
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"{#ENTRYDATE#}";

                    Tanı = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 4, 73, 9, false);
                    Tanı.Name = "Tanı";
                    Tanı.FieldType = ReportFieldTypeEnum.ftVariable;
                    Tanı.MultiLine = EvetHayirEnum.ehEvet;
                    Tanı.NoClip = EvetHayirEnum.ehEvet;
                    Tanı.WordBreak = EvetHayirEnum.ehEvet;
                    Tanı.ExpandTabs = EvetHayirEnum.ehEvet;
                    Tanı.TextFont.Name = "Arial Unicode MS";
                    Tanı.TextFont.CharSet = 162;
                    Tanı.Value = @"{#TANI#}";

                    Neden = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 4, 111, 9, false);
                    Neden.Name = "Neden";
                    Neden.FieldType = ReportFieldTypeEnum.ftVariable;
                    Neden.MultiLine = EvetHayirEnum.ehEvet;
                    Neden.NoClip = EvetHayirEnum.ehEvet;
                    Neden.WordBreak = EvetHayirEnum.ehEvet;
                    Neden.ExpandTabs = EvetHayirEnum.ehEvet;
                    Neden.TextFont.Name = "Arial Unicode MS";
                    Neden.TextFont.CharSet = 162;
                    Neden.Value = @"";

                    Girisim = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 112, 4, 157, 9, false);
                    Girisim.Name = "Girisim";
                    Girisim.FieldType = ReportFieldTypeEnum.ftVariable;
                    Girisim.MultiLine = EvetHayirEnum.ehEvet;
                    Girisim.NoClip = EvetHayirEnum.ehEvet;
                    Girisim.WordBreak = EvetHayirEnum.ehEvet;
                    Girisim.ExpandTabs = EvetHayirEnum.ehEvet;
                    Girisim.TextFont.Name = "Arial Unicode MS";
                    Girisim.TextFont.CharSet = 162;
                    Girisim.Value = @"";

                    Hedef = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 4, 199, 9, false);
                    Hedef.Name = "Hedef";
                    Hedef.FieldType = ReportFieldTypeEnum.ftVariable;
                    Hedef.MultiLine = EvetHayirEnum.ehEvet;
                    Hedef.NoClip = EvetHayirEnum.ehEvet;
                    Hedef.WordBreak = EvetHayirEnum.ehEvet;
                    Hedef.ExpandTabs = EvetHayirEnum.ehEvet;
                    Hedef.TextFont.Name = "Arial Unicode MS";
                    Hedef.TextFont.CharSet = 162;
                    Hedef.Value = @"";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 200, 4, 230, 9, false);
                    NewField6.Name = "NewField6";
                    NewField6.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField6.MultiLine = EvetHayirEnum.ehEvet;
                    NewField6.NoClip = EvetHayirEnum.ehEvet;
                    NewField6.WordBreak = EvetHayirEnum.ehEvet;
                    NewField6.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField6.TextFont.Name = "Arial Unicode MS";
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"{#NOTE#}";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 4, 260, 9, false);
                    NewField7.Name = "NewField7";
                    NewField7.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField7.MultiLine = EvetHayirEnum.ehEvet;
                    NewField7.NoClip = EvetHayirEnum.ehEvet;
                    NewField7.WordBreak = EvetHayirEnum.ehEvet;
                    NewField7.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField7.TextFont.Name = "Arial Unicode MS";
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"{#USER#}";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 260, 4, 282, 9, false);
                    NewField8.Name = "NewField8";
                    NewField8.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 3, 282, 3, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    ObjectID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 1, 330, 6, false);
                    ObjectID.Name = "ObjectID";
                    ObjectID.Visible = EvetHayirEnum.ehHayir;
                    ObjectID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ObjectID.MultiLine = EvetHayirEnum.ehEvet;
                    ObjectID.NoClip = EvetHayirEnum.ehEvet;
                    ObjectID.WordBreak = EvetHayirEnum.ehEvet;
                    ObjectID.ExpandTabs = EvetHayirEnum.ehEvet;
                    ObjectID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NursingCare.GetNursingCaresByNursingApplication_Class dataset_GetNursingCaresByNursingApplication = ParentGroup.rsGroup.GetCurrentRecord<NursingCare.GetNursingCaresByNursingApplication_Class>(0);
                    NewField1.CalcValue = (dataset_GetNursingCaresByNursingApplication != null ? Globals.ToStringCore(dataset_GetNursingCaresByNursingApplication.EntryDate) : "");
                    Tanı.CalcValue = (dataset_GetNursingCaresByNursingApplication != null ? Globals.ToStringCore(dataset_GetNursingCaresByNursingApplication.Tani) : "");
                    Neden.CalcValue = @"";
                    Girisim.CalcValue = @"";
                    Hedef.CalcValue = @"";
                    NewField6.CalcValue = (dataset_GetNursingCaresByNursingApplication != null ? Globals.ToStringCore(dataset_GetNursingCaresByNursingApplication.Note) : "");
                    NewField7.CalcValue = (dataset_GetNursingCaresByNursingApplication != null ? Globals.ToStringCore(dataset_GetNursingCaresByNursingApplication.User) : "");
                    NewField8.CalcValue = NewField8.Value;
                    ObjectID.CalcValue = (dataset_GetNursingCaresByNursingApplication != null ? Globals.ToStringCore(dataset_GetNursingCaresByNursingApplication.ObjectID) : "");
                    return new TTReportObject[] { NewField1,Tanı,Neden,Girisim,Hedef,NewField6,NewField7,NewField8,ObjectID};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
                    string sObjectID = this.ObjectID.CalcValue;
                    NursingCare nursingCare = (NursingCare)context.GetObject(new Guid(sObjectID), "NursingCare");
                    foreach (var nc in nursingCare.NursingReasonGrids)
                    {
                        if (!string.IsNullOrEmpty(this.Neden.CalcValue))
                            this.Neden.CalcValue += "\r\n";
                        this.Neden.CalcValue += nc.NursingReason.Name;
                    }
                    foreach ( var nc in nursingCare.NursingCareGrids)
                    {
                        if (!string.IsNullOrEmpty(this.Girisim.CalcValue))
                            this.Girisim.CalcValue += "\r\n";
                        this.Girisim.CalcValue +=  nc.NursingCare.Name;
                    
                    }
                    foreach (var nc in nursingCare.NursingTargetGrids)
                    {
                        if (!string.IsNullOrEmpty(this.Hedef.CalcValue))
                            this.Hedef.CalcValue += "\r\n";
                        this.Hedef.CalcValue += nc.NursingTarget.Name;
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

        public NursingCareReport()
        {
            PartA = new PartAGroup(this,"PartA");
            Patient = new PatientGroup(PartA,"Patient");
            MAIN = new MAINGroup(Patient,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "TTOBJECTID", @"", true, true, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "NURSINGCAREREPORT";
            Caption = "Hemşirelik Bakım";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginTop = 5;
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