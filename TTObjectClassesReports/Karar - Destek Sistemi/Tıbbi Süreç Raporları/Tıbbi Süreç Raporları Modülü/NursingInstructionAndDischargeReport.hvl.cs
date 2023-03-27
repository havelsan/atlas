
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
    /// Hemşirelik Hasta Eğitimi ve Taburculuk Raporu
    /// </summary>
    public partial class NursingInstructionAndDischargeReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? OBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PartAGroup : TTReportGroup
        {
            public NursingInstructionAndDischargeReport MyParentReport
            {
                get { return (NursingInstructionAndDischargeReport)ParentReport; }
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
                public NursingInstructionAndDischargeReport MyParentReport
                {
                    get { return (NursingInstructionAndDischargeReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField LOGO; 
                public PartAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 49;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
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

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = @"";
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
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
                public NursingInstructionAndDischargeReport MyParentReport
                {
                    get { return (NursingInstructionAndDischargeReport)ParentReport; }
                }
                
                public TTReportField PRINTDATE;
                public TTReportField PAGENUMBER1;
                public TTReportField USERNAME;
                public TTReportShape NewLine11111; 
                public PartAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 15;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PRINTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 4, 143, 9, false);
                    PRINTDATE.Name = "PRINTDATE";
                    PRINTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    PRINTDATE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    PRINTDATE.TextFont.Size = 8;
                    PRINTDATE.TextFont.CharSet = 162;
                    PRINTDATE.Value = @"{@printdate@} - {%USERNAME%}";

                    PAGENUMBER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 4, 288, 9, false);
                    PAGENUMBER1.Name = "PAGENUMBER1";
                    PAGENUMBER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER1.TextFont.Size = 8;
                    PAGENUMBER1.TextFont.CharSet = 162;
                    PAGENUMBER1.Value = @"{@pagenumber@} / {@pagecount@}";

                    USERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 9, 55, 14, false);
                    USERNAME.Name = "USERNAME";
                    USERNAME.Visible = EvetHayirEnum.ehHayir;
                    USERNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    USERNAME.CaseFormat = CaseFormatEnum.fcTitleCase;
                    USERNAME.TextFont.Size = 8;
                    USERNAME.TextFont.CharSet = 162;
                    USERNAME.Value = @"TTObjectClasses.Common.CurrentResource.Name;";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 1, 292, 1, false);
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
            public NursingInstructionAndDischargeReport MyParentReport
            {
                get { return (NursingInstructionAndDischargeReport)ParentReport; }
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
            public TTReportField lblPAtientName1 { get {return Header().lblPAtientName1;} }
            public TTReportField lblBirth { get {return Header().lblBirth;} }
            public TTReportField BirthDate { get {return Header().BirthDate;} }
            public TTReportField lblNurse { get {return Header().lblNurse;} }
            public TTReportField ResponsibleNurse { get {return Header().ResponsibleNurse;} }
            public TTReportField lblDiag { get {return Header().lblDiag;} }
            public TTReportField Clinic { get {return Header().Clinic;} }
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
                public NursingInstructionAndDischargeReport MyParentReport
                {
                    get { return (NursingInstructionAndDischargeReport)ParentReport; }
                }
                
                public TTReportField FULLNAME;
                public TTReportField lblPAtientName1;
                public TTReportField lblBirth;
                public TTReportField BirthDate;
                public TTReportField lblNurse;
                public TTReportField ResponsibleNurse;
                public TTReportField lblDiag;
                public TTReportField Clinic;
                public TTReportShape NewLine11; 
                public PatientGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 17;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    FULLNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 3, 123, 8, false);
                    FULLNAME.Name = "FULLNAME";
                    FULLNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FULLNAME.Value = @"";

                    lblPAtientName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 3, 37, 8, false);
                    lblPAtientName1.Name = "lblPAtientName1";
                    lblPAtientName1.Value = @"Adı Soyadı :";

                    lblBirth = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 10, 37, 15, false);
                    lblBirth.Name = "lblBirth";
                    lblBirth.Value = @"Doğum Tarihi:";

                    BirthDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 10, 123, 15, false);
                    BirthDate.Name = "BirthDate";
                    BirthDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    BirthDate.Value = @"";

                    lblNurse = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 3, 159, 8, false);
                    lblNurse.Name = "lblNurse";
                    lblNurse.Value = @"Sorumlu Hemşire:";

                    ResponsibleNurse = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 3, 245, 8, false);
                    ResponsibleNurse.Name = "ResponsibleNurse";
                    ResponsibleNurse.FieldType = ReportFieldTypeEnum.ftVariable;
                    ResponsibleNurse.Value = @"";

                    lblDiag = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 10, 159, 15, false);
                    lblDiag.Name = "lblDiag";
                    lblDiag.Value = @"Klinik:";

                    Clinic = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 10, 245, 15, false);
                    Clinic.Name = "Clinic";
                    Clinic.FieldType = ReportFieldTypeEnum.ftVariable;
                    Clinic.Value = @"";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 1, 292, 1, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    FULLNAME.CalcValue = @"";
                    lblPAtientName1.CalcValue = lblPAtientName1.Value;
                    lblBirth.CalcValue = lblBirth.Value;
                    BirthDate.CalcValue = @"";
                    lblNurse.CalcValue = lblNurse.Value;
                    ResponsibleNurse.CalcValue = @"";
                    lblDiag.CalcValue = lblDiag.Value;
                    Clinic.CalcValue = @"";
                    return new TTReportObject[] { FULLNAME,lblPAtientName1,lblBirth,BirthDate,lblNurse,ResponsibleNurse,lblDiag,Clinic};
                }

                public override void RunScript()
                {
#region PATIENT HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
                    string sObjectID = ((NursingInstructionAndDischargeReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                    NursingApplication nursingApp = (NursingApplication)context.GetObject(new Guid(sObjectID), "NursingApplication");
                    
                    DateTime? birthDate = nursingApp.Episode.Patient.BirthDate;
                    ResUser nurse = nursingApp.InPatientTreatmentClinicApp.ResponsibleNurse;
                    ResSection clinic = nursingApp.InPatientTreatmentClinicApp.MasterResource;

                    this.FULLNAME.CalcValue = nursingApp.Episode.Patient.Name + " " + nursingApp.Episode.Patient.Surname;
                    this.BirthDate.CalcValue = birthDate != null ? birthDate.Value.ToString("dd/MM/yyyy") : "";
                    this.ResponsibleNurse.CalcValue = nurse != null ? nurse.Name : "";
                    this.Clinic.CalcValue = clinic != null ? clinic.Name : "";
#endregion PATIENT HEADER_Script
                }
            }
            public partial class PatientGroupFooter : TTReportSection
            {
                public NursingInstructionAndDischargeReport MyParentReport
                {
                    get { return (NursingInstructionAndDischargeReport)ParentReport; }
                }
                 
                public PatientGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PatientGroup Patient;

        public partial class MAINGroup : TTReportGroup
        {
            public NursingInstructionAndDischargeReport MyParentReport
            {
                get { return (NursingInstructionAndDischargeReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField EGITIM_ADI { get {return Body().EGITIM_ADI;} }
            public TTReportField EGITIM_ADI1 { get {return Body().EGITIM_ADI1;} }
            public TTReportField EGITIM_ADI2 { get {return Body().EGITIM_ADI2;} }
            public TTReportField EGITIM_ADI3 { get {return Body().EGITIM_ADI3;} }
            public TTReportField EGITIM_ADI4 { get {return Body().EGITIM_ADI4;} }
            public TTReportField EGITIM_ADI5 { get {return Body().EGITIM_ADI5;} }
            public TTReportField EGITIM_ADI12 { get {return Body().EGITIM_ADI12;} }
            public TTReportField EGITIM_DEGER12 { get {return Body().EGITIM_DEGER12;} }
            public TTReportField EGITIM_ADI13 { get {return Body().EGITIM_ADI13;} }
            public TTReportField EGITIM_DEGER13 { get {return Body().EGITIM_DEGER13;} }
            public TTReportField EGITIM_ADI14 { get {return Body().EGITIM_ADI14;} }
            public TTReportField EGITIM_DEGER14 { get {return Body().EGITIM_DEGER14;} }
            public TTReportField EGITIM_ADI15 { get {return Body().EGITIM_ADI15;} }
            public TTReportField EGITIM_DEGER15 { get {return Body().EGITIM_DEGER15;} }
            public TTReportField EGITIM_ADI16 { get {return Body().EGITIM_ADI16;} }
            public TTReportField EGITIM_DEGER16 { get {return Body().EGITIM_DEGER16;} }
            public TTReportField EGITIM_ADI17 { get {return Body().EGITIM_ADI17;} }
            public TTReportField EGITIM_DEGER17 { get {return Body().EGITIM_DEGER17;} }
            public TTReportField EGITIM_ADI18 { get {return Body().EGITIM_ADI18;} }
            public TTReportField EGITIM_ADI19 { get {return Body().EGITIM_ADI19;} }
            public TTReportField EGITIM_ADI20 { get {return Body().EGITIM_ADI20;} }
            public TTReportField EGITIM_ADI21 { get {return Body().EGITIM_ADI21;} }
            public TTReportField EGITIM_ADI22 { get {return Body().EGITIM_ADI22;} }
            public TTReportField EGITIM_ADI23 { get {return Body().EGITIM_ADI23;} }
            public TTReportField EGITIM_ADI24 { get {return Body().EGITIM_ADI24;} }
            public TTReportShape NewLine11111 { get {return Body().NewLine11111;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine111111 { get {return Body().NewLine111111;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField TABURCU_ADI { get {return Body().TABURCU_ADI;} }
            public TTReportField TABURCU_DEGER { get {return Body().TABURCU_DEGER;} }
            public TTReportField TABURCU_ADI1 { get {return Body().TABURCU_ADI1;} }
            public TTReportField TABURCU_DEGER1 { get {return Body().TABURCU_DEGER1;} }
            public TTReportField TABURCU_ADI2 { get {return Body().TABURCU_ADI2;} }
            public TTReportField TABURCU_DEGER2 { get {return Body().TABURCU_DEGER2;} }
            public TTReportField TABURCU_ADI3 { get {return Body().TABURCU_ADI3;} }
            public TTReportField TABURCU_DEGER3 { get {return Body().TABURCU_DEGER3;} }
            public TTReportField TABURCU_ADI4 { get {return Body().TABURCU_ADI4;} }
            public TTReportField TABURCU_DEGER4 { get {return Body().TABURCU_DEGER4;} }
            public TTReportField TABURCU_ADI5 { get {return Body().TABURCU_ADI5;} }
            public TTReportField TABURCU_DEGER5 { get {return Body().TABURCU_DEGER5;} }
            public TTReportField TABURCU_ADI6 { get {return Body().TABURCU_ADI6;} }
            public TTReportField TABURCU_DEGER6 { get {return Body().TABURCU_DEGER6;} }
            public TTReportField TABURCU_ADI7 { get {return Body().TABURCU_ADI7;} }
            public TTReportField TABURCU_DEGER7 { get {return Body().TABURCU_DEGER7;} }
            public TTReportField TABURCU_ADI8 { get {return Body().TABURCU_ADI8;} }
            public TTReportField TABURCU_DEGER8 { get {return Body().TABURCU_DEGER8;} }
            public TTReportField TABURCU_ADI9 { get {return Body().TABURCU_ADI9;} }
            public TTReportField TABURCU_DEGER9 { get {return Body().TABURCU_DEGER9;} }
            public TTReportField TABURCU_ADI10 { get {return Body().TABURCU_ADI10;} }
            public TTReportField TABURCU_DEGER10 { get {return Body().TABURCU_DEGER10;} }
            public TTReportField TABURCU_ADI11 { get {return Body().TABURCU_ADI11;} }
            public TTReportField TABURCU_DEGER11 { get {return Body().TABURCU_DEGER11;} }
            public TTReportField TABURCU_ADI12 { get {return Body().TABURCU_ADI12;} }
            public TTReportField TABURCU_DEGER12 { get {return Body().TABURCU_DEGER12;} }
            public TTReportField TABURCU_ADI13 { get {return Body().TABURCU_ADI13;} }
            public TTReportField TABURCU_DEGER13 { get {return Body().TABURCU_DEGER13;} }
            public TTReportField TABURCU_ADI14 { get {return Body().TABURCU_ADI14;} }
            public TTReportField TABURCU_DEGER14 { get {return Body().TABURCU_DEGER14;} }
            public TTReportField TABURCU_ADI15 { get {return Body().TABURCU_ADI15;} }
            public TTReportField TABURCU_DEGER15 { get {return Body().TABURCU_DEGER15;} }
            public TTReportField EGITIM_DEGER { get {return Body().EGITIM_DEGER;} }
            public TTReportField EGITIM_DEGER1 { get {return Body().EGITIM_DEGER1;} }
            public TTReportField EGITIM_DEGER2 { get {return Body().EGITIM_DEGER2;} }
            public TTReportField EGITIM_DEGER3 { get {return Body().EGITIM_DEGER3;} }
            public TTReportField EGITIM_DEGER4 { get {return Body().EGITIM_DEGER4;} }
            public TTReportField EGITIM_DEGER5 { get {return Body().EGITIM_DEGER5;} }
            public TTReportField EGITIM_DEGER24 { get {return Body().EGITIM_DEGER24;} }
            public TTReportField EGITIM_DEGER18 { get {return Body().EGITIM_DEGER18;} }
            public TTReportField EGITIM_DEGER19 { get {return Body().EGITIM_DEGER19;} }
            public TTReportField EGITIM_DEGER20 { get {return Body().EGITIM_DEGER20;} }
            public TTReportField EGITIM_DEGER21 { get {return Body().EGITIM_DEGER21;} }
            public TTReportField EGITIM_DEGER22 { get {return Body().EGITIM_DEGER22;} }
            public TTReportField EGITIM_DEGER23 { get {return Body().EGITIM_DEGER23;} }
            public TTReportField EGITIM_AILE { get {return Body().EGITIM_AILE;} }
            public TTReportField EGITIM_AILE1 { get {return Body().EGITIM_AILE1;} }
            public TTReportField EGITIM_AILE2 { get {return Body().EGITIM_AILE2;} }
            public TTReportField EGITIM_AILE3 { get {return Body().EGITIM_AILE3;} }
            public TTReportField EGITIM_AILE4 { get {return Body().EGITIM_AILE4;} }
            public TTReportField EGITIM_AILE5 { get {return Body().EGITIM_AILE5;} }
            public TTReportField EGITIM_AILE24 { get {return Body().EGITIM_AILE24;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportField NewField5 { get {return Body().NewField5;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField EGITIM_DEGER6 { get {return Body().EGITIM_DEGER6;} }
            public TTReportField EGITIM_DEGER7 { get {return Body().EGITIM_DEGER7;} }
            public TTReportField EGITIM_DEGER8 { get {return Body().EGITIM_DEGER8;} }
            public TTReportField EGITIM_DEGER9 { get {return Body().EGITIM_DEGER9;} }
            public TTReportField EGITIM_DEGER10 { get {return Body().EGITIM_DEGER10;} }
            public TTReportField EGITIM_DEGER11 { get {return Body().EGITIM_DEGER11;} }
            public TTReportField EGITIM_ADI6 { get {return Body().EGITIM_ADI6;} }
            public TTReportField EGITIM_ADI7 { get {return Body().EGITIM_ADI7;} }
            public TTReportField EGITIM_ADI8 { get {return Body().EGITIM_ADI8;} }
            public TTReportField EGITIM_ADI9 { get {return Body().EGITIM_ADI9;} }
            public TTReportField EGITIM_ADI10 { get {return Body().EGITIM_ADI10;} }
            public TTReportField EGITIM_ADI11 { get {return Body().EGITIM_ADI11;} }
            public TTReportField EGITIM_AILE6 { get {return Body().EGITIM_AILE6;} }
            public TTReportField EGITIM_AILE7 { get {return Body().EGITIM_AILE7;} }
            public TTReportField EGITIM_AILE8 { get {return Body().EGITIM_AILE8;} }
            public TTReportField EGITIM_AILE9 { get {return Body().EGITIM_AILE9;} }
            public TTReportField EGITIM_AILE10 { get {return Body().EGITIM_AILE10;} }
            public TTReportField EGITIM_AILE11 { get {return Body().EGITIM_AILE11;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField NewField132 { get {return Body().NewField132;} }
            public TTReportField NewField142 { get {return Body().NewField142;} }
            public TTReportField NewField152 { get {return Body().NewField152;} }
            public TTReportField EGITIM_AILE12 { get {return Body().EGITIM_AILE12;} }
            public TTReportField EGITIM_AILE13 { get {return Body().EGITIM_AILE13;} }
            public TTReportField EGITIM_AILE14 { get {return Body().EGITIM_AILE14;} }
            public TTReportField EGITIM_AILE15 { get {return Body().EGITIM_AILE15;} }
            public TTReportField EGITIM_AILE16 { get {return Body().EGITIM_AILE16;} }
            public TTReportField EGITIM_AILE17 { get {return Body().EGITIM_AILE17;} }
            public TTReportField EGITIM_AILE18 { get {return Body().EGITIM_AILE18;} }
            public TTReportField EGITIM_AILE19 { get {return Body().EGITIM_AILE19;} }
            public TTReportField EGITIM_AILE20 { get {return Body().EGITIM_AILE20;} }
            public TTReportField EGITIM_AILE21 { get {return Body().EGITIM_AILE21;} }
            public TTReportField EGITIM_AILE22 { get {return Body().EGITIM_AILE22;} }
            public TTReportField EGITIM_AILE23 { get {return Body().EGITIM_AILE23;} }
            public TTReportField NewField6 { get {return Body().NewField6;} }
            public TTReportField InstructionNote { get {return Body().InstructionNote;} }
            public TTReportField EGITIM_ADI25 { get {return Body().EGITIM_ADI25;} }
            public TTReportField EGITIM_DEGER25 { get {return Body().EGITIM_DEGER25;} }
            public TTReportField EGITIM_AILE25 { get {return Body().EGITIM_AILE25;} }
            public TTReportField EGITIM_ADI26 { get {return Body().EGITIM_ADI26;} }
            public TTReportField EGITIM_DEGER26 { get {return Body().EGITIM_DEGER26;} }
            public TTReportField EGITIM_AILE26 { get {return Body().EGITIM_AILE26;} }
            public TTReportField EGITIM_ADI27 { get {return Body().EGITIM_ADI27;} }
            public TTReportField EGITIM_DEGER27 { get {return Body().EGITIM_DEGER27;} }
            public TTReportField EGITIM_AILE27 { get {return Body().EGITIM_AILE27;} }
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
                public NursingInstructionAndDischargeReport MyParentReport
                {
                    get { return (NursingInstructionAndDischargeReport)ParentReport; }
                }
                
                public TTReportField EGITIM_ADI;
                public TTReportField EGITIM_ADI1;
                public TTReportField EGITIM_ADI2;
                public TTReportField EGITIM_ADI3;
                public TTReportField EGITIM_ADI4;
                public TTReportField EGITIM_ADI5;
                public TTReportField EGITIM_ADI12;
                public TTReportField EGITIM_DEGER12;
                public TTReportField EGITIM_ADI13;
                public TTReportField EGITIM_DEGER13;
                public TTReportField EGITIM_ADI14;
                public TTReportField EGITIM_DEGER14;
                public TTReportField EGITIM_ADI15;
                public TTReportField EGITIM_DEGER15;
                public TTReportField EGITIM_ADI16;
                public TTReportField EGITIM_DEGER16;
                public TTReportField EGITIM_ADI17;
                public TTReportField EGITIM_DEGER17;
                public TTReportField EGITIM_ADI18;
                public TTReportField EGITIM_ADI19;
                public TTReportField EGITIM_ADI20;
                public TTReportField EGITIM_ADI21;
                public TTReportField EGITIM_ADI22;
                public TTReportField EGITIM_ADI23;
                public TTReportField EGITIM_ADI24;
                public TTReportShape NewLine11111;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine12;
                public TTReportShape NewLine111111;
                public TTReportField NewField11;
                public TTReportShape NewLine11;
                public TTReportShape NewLine13;
                public TTReportShape NewLine121;
                public TTReportField NewField2;
                public TTReportField TABURCU_ADI;
                public TTReportField TABURCU_DEGER;
                public TTReportField TABURCU_ADI1;
                public TTReportField TABURCU_DEGER1;
                public TTReportField TABURCU_ADI2;
                public TTReportField TABURCU_DEGER2;
                public TTReportField TABURCU_ADI3;
                public TTReportField TABURCU_DEGER3;
                public TTReportField TABURCU_ADI4;
                public TTReportField TABURCU_DEGER4;
                public TTReportField TABURCU_ADI5;
                public TTReportField TABURCU_DEGER5;
                public TTReportField TABURCU_ADI6;
                public TTReportField TABURCU_DEGER6;
                public TTReportField TABURCU_ADI7;
                public TTReportField TABURCU_DEGER7;
                public TTReportField TABURCU_ADI8;
                public TTReportField TABURCU_DEGER8;
                public TTReportField TABURCU_ADI9;
                public TTReportField TABURCU_DEGER9;
                public TTReportField TABURCU_ADI10;
                public TTReportField TABURCU_DEGER10;
                public TTReportField TABURCU_ADI11;
                public TTReportField TABURCU_DEGER11;
                public TTReportField TABURCU_ADI12;
                public TTReportField TABURCU_DEGER12;
                public TTReportField TABURCU_ADI13;
                public TTReportField TABURCU_DEGER13;
                public TTReportField TABURCU_ADI14;
                public TTReportField TABURCU_DEGER14;
                public TTReportField TABURCU_ADI15;
                public TTReportField TABURCU_DEGER15;
                public TTReportField EGITIM_DEGER;
                public TTReportField EGITIM_DEGER1;
                public TTReportField EGITIM_DEGER2;
                public TTReportField EGITIM_DEGER3;
                public TTReportField EGITIM_DEGER4;
                public TTReportField EGITIM_DEGER5;
                public TTReportField EGITIM_DEGER24;
                public TTReportField EGITIM_DEGER18;
                public TTReportField EGITIM_DEGER19;
                public TTReportField EGITIM_DEGER20;
                public TTReportField EGITIM_DEGER21;
                public TTReportField EGITIM_DEGER22;
                public TTReportField EGITIM_DEGER23;
                public TTReportField EGITIM_AILE;
                public TTReportField EGITIM_AILE1;
                public TTReportField EGITIM_AILE2;
                public TTReportField EGITIM_AILE3;
                public TTReportField EGITIM_AILE4;
                public TTReportField EGITIM_AILE5;
                public TTReportField EGITIM_AILE24;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField1;
                public TTReportField EGITIM_DEGER6;
                public TTReportField EGITIM_DEGER7;
                public TTReportField EGITIM_DEGER8;
                public TTReportField EGITIM_DEGER9;
                public TTReportField EGITIM_DEGER10;
                public TTReportField EGITIM_DEGER11;
                public TTReportField EGITIM_ADI6;
                public TTReportField EGITIM_ADI7;
                public TTReportField EGITIM_ADI8;
                public TTReportField EGITIM_ADI9;
                public TTReportField EGITIM_ADI10;
                public TTReportField EGITIM_ADI11;
                public TTReportField EGITIM_AILE6;
                public TTReportField EGITIM_AILE7;
                public TTReportField EGITIM_AILE8;
                public TTReportField EGITIM_AILE9;
                public TTReportField EGITIM_AILE10;
                public TTReportField EGITIM_AILE11;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField132;
                public TTReportField NewField142;
                public TTReportField NewField152;
                public TTReportField EGITIM_AILE12;
                public TTReportField EGITIM_AILE13;
                public TTReportField EGITIM_AILE14;
                public TTReportField EGITIM_AILE15;
                public TTReportField EGITIM_AILE16;
                public TTReportField EGITIM_AILE17;
                public TTReportField EGITIM_AILE18;
                public TTReportField EGITIM_AILE19;
                public TTReportField EGITIM_AILE20;
                public TTReportField EGITIM_AILE21;
                public TTReportField EGITIM_AILE22;
                public TTReportField EGITIM_AILE23;
                public TTReportField NewField6;
                public TTReportField InstructionNote;
                public TTReportField EGITIM_ADI25;
                public TTReportField EGITIM_DEGER25;
                public TTReportField EGITIM_AILE25;
                public TTReportField EGITIM_ADI26;
                public TTReportField EGITIM_DEGER26;
                public TTReportField EGITIM_AILE26;
                public TTReportField EGITIM_ADI27;
                public TTReportField EGITIM_DEGER27;
                public TTReportField EGITIM_AILE27; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 150;
                    RepeatCount = 0;
                    
                    EGITIM_ADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 14, 77, 19, false);
                    EGITIM_ADI.Name = "EGITIM_ADI";
                    EGITIM_ADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI.Value = @"";

                    EGITIM_ADI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 21, 77, 26, false);
                    EGITIM_ADI1.Name = "EGITIM_ADI1";
                    EGITIM_ADI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI1.Value = @"";

                    EGITIM_ADI2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 28, 77, 33, false);
                    EGITIM_ADI2.Name = "EGITIM_ADI2";
                    EGITIM_ADI2.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI2.Value = @"";

                    EGITIM_ADI3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 35, 77, 40, false);
                    EGITIM_ADI3.Name = "EGITIM_ADI3";
                    EGITIM_ADI3.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI3.Value = @"";

                    EGITIM_ADI4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 42, 77, 47, false);
                    EGITIM_ADI4.Name = "EGITIM_ADI4";
                    EGITIM_ADI4.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI4.Value = @"";

                    EGITIM_ADI5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 49, 77, 54, false);
                    EGITIM_ADI5.Name = "EGITIM_ADI5";
                    EGITIM_ADI5.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI5.Value = @"";

                    EGITIM_ADI12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 14, 218, 19, false);
                    EGITIM_ADI12.Name = "EGITIM_ADI12";
                    EGITIM_ADI12.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI12.Value = @"";

                    EGITIM_DEGER12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 14, 156, 19, false);
                    EGITIM_DEGER12.Name = "EGITIM_DEGER12";
                    EGITIM_DEGER12.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER12.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER12.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER12.Value = @"";

                    EGITIM_ADI13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 21, 218, 26, false);
                    EGITIM_ADI13.Name = "EGITIM_ADI13";
                    EGITIM_ADI13.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI13.Value = @"";

                    EGITIM_DEGER13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 21, 156, 26, false);
                    EGITIM_DEGER13.Name = "EGITIM_DEGER13";
                    EGITIM_DEGER13.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER13.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER13.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER13.Value = @"";

                    EGITIM_ADI14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 28, 218, 33, false);
                    EGITIM_ADI14.Name = "EGITIM_ADI14";
                    EGITIM_ADI14.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI14.Value = @"";

                    EGITIM_DEGER14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 28, 156, 33, false);
                    EGITIM_DEGER14.Name = "EGITIM_DEGER14";
                    EGITIM_DEGER14.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER14.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER14.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER14.Value = @"";

                    EGITIM_ADI15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 35, 218, 40, false);
                    EGITIM_ADI15.Name = "EGITIM_ADI15";
                    EGITIM_ADI15.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI15.Value = @"";

                    EGITIM_DEGER15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 35, 156, 40, false);
                    EGITIM_DEGER15.Name = "EGITIM_DEGER15";
                    EGITIM_DEGER15.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER15.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER15.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER15.Value = @"";

                    EGITIM_ADI16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 42, 218, 47, false);
                    EGITIM_ADI16.Name = "EGITIM_ADI16";
                    EGITIM_ADI16.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI16.Value = @"";

                    EGITIM_DEGER16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 42, 156, 47, false);
                    EGITIM_DEGER16.Name = "EGITIM_DEGER16";
                    EGITIM_DEGER16.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER16.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER16.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER16.Value = @"";

                    EGITIM_ADI17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 49, 218, 54, false);
                    EGITIM_ADI17.Name = "EGITIM_ADI17";
                    EGITIM_ADI17.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI17.Value = @"";

                    EGITIM_DEGER17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 49, 156, 54, false);
                    EGITIM_DEGER17.Name = "EGITIM_DEGER17";
                    EGITIM_DEGER17.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER17.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER17.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER17.Value = @"";

                    EGITIM_ADI18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 14, 289, 19, false);
                    EGITIM_ADI18.Name = "EGITIM_ADI18";
                    EGITIM_ADI18.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI18.Value = @"";

                    EGITIM_ADI19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 21, 289, 26, false);
                    EGITIM_ADI19.Name = "EGITIM_ADI19";
                    EGITIM_ADI19.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI19.Value = @"";

                    EGITIM_ADI20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 28, 289, 33, false);
                    EGITIM_ADI20.Name = "EGITIM_ADI20";
                    EGITIM_ADI20.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI20.Value = @"";

                    EGITIM_ADI21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 35, 289, 40, false);
                    EGITIM_ADI21.Name = "EGITIM_ADI21";
                    EGITIM_ADI21.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI21.Value = @"";

                    EGITIM_ADI22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 42, 289, 47, false);
                    EGITIM_ADI22.Name = "EGITIM_ADI22";
                    EGITIM_ADI22.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI22.Value = @"";

                    EGITIM_ADI23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 49, 289, 54, false);
                    EGITIM_ADI23.Name = "EGITIM_ADI23";
                    EGITIM_ADI23.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI23.Value = @"";

                    EGITIM_ADI24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 56, 77, 61, false);
                    EGITIM_ADI24.Name = "EGITIM_ADI24";
                    EGITIM_ADI24.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI24.Value = @"";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 3, 292, 3, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 86, 292, 86, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 3, 8, 86, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 292, 3, 292, 86, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 92, 292, 92, false);
                    NewLine111111.Name = "NewLine111111";
                    NewLine111111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 95, 292, 105, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Size = 14;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"TABURCULUK";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 146, 292, 146, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 92, 8, 146, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 292, 92, 292, 146, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 105, 292, 115, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField2.TextFont.Size = 12;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"AKTİVİTE UYGULAMA BECERİLERİ VE DÜZEY BELİRLEME KODLARI";

                    TABURCU_ADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 118, 80, 123, false);
                    TABURCU_ADI.Name = "TABURCU_ADI";
                    TABURCU_ADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_ADI.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_ADI.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_ADI.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_ADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_ADI.TextFont.Size = 9;
                    TABURCU_ADI.TextFont.CharSet = 162;
                    TABURCU_ADI.Value = @"";

                    TABURCU_DEGER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 118, 19, 123, false);
                    TABURCU_DEGER.Name = "TABURCU_DEGER";
                    TABURCU_DEGER.Visible = EvetHayirEnum.ehHayir;
                    TABURCU_DEGER.DrawStyle = DrawStyleConstants.vbSolid;
                    TABURCU_DEGER.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_DEGER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TABURCU_DEGER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TABURCU_DEGER.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER.TextFont.CharSet = 162;
                    TABURCU_DEGER.Value = @"";

                    TABURCU_ADI1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 125, 80, 130, false);
                    TABURCU_ADI1.Name = "TABURCU_ADI1";
                    TABURCU_ADI1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_ADI1.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_ADI1.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_ADI1.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_ADI1.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_ADI1.TextFont.Size = 9;
                    TABURCU_ADI1.TextFont.CharSet = 162;
                    TABURCU_ADI1.Value = @"";

                    TABURCU_DEGER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 125, 19, 130, false);
                    TABURCU_DEGER1.Name = "TABURCU_DEGER1";
                    TABURCU_DEGER1.Visible = EvetHayirEnum.ehHayir;
                    TABURCU_DEGER1.DrawStyle = DrawStyleConstants.vbSolid;
                    TABURCU_DEGER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_DEGER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TABURCU_DEGER1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TABURCU_DEGER1.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER1.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER1.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER1.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER1.TextFont.CharSet = 162;
                    TABURCU_DEGER1.Value = @"";

                    TABURCU_ADI2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 132, 80, 137, false);
                    TABURCU_ADI2.Name = "TABURCU_ADI2";
                    TABURCU_ADI2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_ADI2.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_ADI2.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_ADI2.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_ADI2.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_ADI2.TextFont.Size = 9;
                    TABURCU_ADI2.TextFont.CharSet = 162;
                    TABURCU_ADI2.Value = @"";

                    TABURCU_DEGER2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 132, 19, 137, false);
                    TABURCU_DEGER2.Name = "TABURCU_DEGER2";
                    TABURCU_DEGER2.Visible = EvetHayirEnum.ehHayir;
                    TABURCU_DEGER2.DrawStyle = DrawStyleConstants.vbSolid;
                    TABURCU_DEGER2.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_DEGER2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TABURCU_DEGER2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TABURCU_DEGER2.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER2.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER2.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER2.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER2.TextFont.CharSet = 162;
                    TABURCU_DEGER2.Value = @"";

                    TABURCU_ADI3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 139, 80, 144, false);
                    TABURCU_ADI3.Name = "TABURCU_ADI3";
                    TABURCU_ADI3.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_ADI3.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_ADI3.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_ADI3.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_ADI3.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_ADI3.TextFont.Size = 9;
                    TABURCU_ADI3.TextFont.CharSet = 162;
                    TABURCU_ADI3.Value = @"";

                    TABURCU_DEGER3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 139, 19, 144, false);
                    TABURCU_DEGER3.Name = "TABURCU_DEGER3";
                    TABURCU_DEGER3.Visible = EvetHayirEnum.ehHayir;
                    TABURCU_DEGER3.DrawStyle = DrawStyleConstants.vbSolid;
                    TABURCU_DEGER3.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_DEGER3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TABURCU_DEGER3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TABURCU_DEGER3.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER3.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER3.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER3.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER3.TextFont.CharSet = 162;
                    TABURCU_DEGER3.Value = @"";

                    TABURCU_ADI4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 118, 152, 123, false);
                    TABURCU_ADI4.Name = "TABURCU_ADI4";
                    TABURCU_ADI4.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_ADI4.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_ADI4.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_ADI4.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_ADI4.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_ADI4.TextFont.Size = 9;
                    TABURCU_ADI4.TextFont.CharSet = 162;
                    TABURCU_ADI4.Value = @"";

                    TABURCU_DEGER4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 118, 87, 123, false);
                    TABURCU_DEGER4.Name = "TABURCU_DEGER4";
                    TABURCU_DEGER4.Visible = EvetHayirEnum.ehHayir;
                    TABURCU_DEGER4.DrawStyle = DrawStyleConstants.vbSolid;
                    TABURCU_DEGER4.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_DEGER4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TABURCU_DEGER4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TABURCU_DEGER4.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER4.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER4.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER4.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER4.TextFont.CharSet = 162;
                    TABURCU_DEGER4.Value = @"";

                    TABURCU_ADI5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 125, 152, 130, false);
                    TABURCU_ADI5.Name = "TABURCU_ADI5";
                    TABURCU_ADI5.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_ADI5.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_ADI5.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_ADI5.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_ADI5.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_ADI5.TextFont.Size = 9;
                    TABURCU_ADI5.TextFont.CharSet = 162;
                    TABURCU_ADI5.Value = @"";

                    TABURCU_DEGER5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 125, 87, 130, false);
                    TABURCU_DEGER5.Name = "TABURCU_DEGER5";
                    TABURCU_DEGER5.Visible = EvetHayirEnum.ehHayir;
                    TABURCU_DEGER5.DrawStyle = DrawStyleConstants.vbSolid;
                    TABURCU_DEGER5.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_DEGER5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TABURCU_DEGER5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TABURCU_DEGER5.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER5.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER5.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER5.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER5.TextFont.CharSet = 162;
                    TABURCU_DEGER5.Value = @"";

                    TABURCU_ADI6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 132, 152, 137, false);
                    TABURCU_ADI6.Name = "TABURCU_ADI6";
                    TABURCU_ADI6.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_ADI6.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_ADI6.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_ADI6.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_ADI6.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_ADI6.TextFont.Size = 9;
                    TABURCU_ADI6.TextFont.CharSet = 162;
                    TABURCU_ADI6.Value = @"";

                    TABURCU_DEGER6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 132, 87, 137, false);
                    TABURCU_DEGER6.Name = "TABURCU_DEGER6";
                    TABURCU_DEGER6.Visible = EvetHayirEnum.ehHayir;
                    TABURCU_DEGER6.DrawStyle = DrawStyleConstants.vbSolid;
                    TABURCU_DEGER6.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_DEGER6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TABURCU_DEGER6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TABURCU_DEGER6.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER6.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER6.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER6.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER6.TextFont.CharSet = 162;
                    TABURCU_DEGER6.Value = @"";

                    TABURCU_ADI7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 89, 139, 152, 144, false);
                    TABURCU_ADI7.Name = "TABURCU_ADI7";
                    TABURCU_ADI7.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_ADI7.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_ADI7.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_ADI7.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_ADI7.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_ADI7.TextFont.Size = 9;
                    TABURCU_ADI7.TextFont.CharSet = 162;
                    TABURCU_ADI7.Value = @"";

                    TABURCU_DEGER7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 139, 87, 144, false);
                    TABURCU_DEGER7.Name = "TABURCU_DEGER7";
                    TABURCU_DEGER7.Visible = EvetHayirEnum.ehHayir;
                    TABURCU_DEGER7.DrawStyle = DrawStyleConstants.vbSolid;
                    TABURCU_DEGER7.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_DEGER7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TABURCU_DEGER7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TABURCU_DEGER7.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER7.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER7.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER7.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER7.TextFont.CharSet = 162;
                    TABURCU_DEGER7.Value = @"";

                    TABURCU_ADI8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 118, 221, 123, false);
                    TABURCU_ADI8.Name = "TABURCU_ADI8";
                    TABURCU_ADI8.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_ADI8.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_ADI8.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_ADI8.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_ADI8.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_ADI8.TextFont.Size = 9;
                    TABURCU_ADI8.TextFont.CharSet = 162;
                    TABURCU_ADI8.Value = @"";

                    TABURCU_DEGER8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 118, 159, 123, false);
                    TABURCU_DEGER8.Name = "TABURCU_DEGER8";
                    TABURCU_DEGER8.Visible = EvetHayirEnum.ehHayir;
                    TABURCU_DEGER8.DrawStyle = DrawStyleConstants.vbSolid;
                    TABURCU_DEGER8.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_DEGER8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TABURCU_DEGER8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TABURCU_DEGER8.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER8.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER8.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER8.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER8.TextFont.CharSet = 162;
                    TABURCU_DEGER8.Value = @"";

                    TABURCU_ADI9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 125, 221, 130, false);
                    TABURCU_ADI9.Name = "TABURCU_ADI9";
                    TABURCU_ADI9.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_ADI9.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_ADI9.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_ADI9.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_ADI9.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_ADI9.TextFont.Size = 9;
                    TABURCU_ADI9.TextFont.CharSet = 162;
                    TABURCU_ADI9.Value = @"";

                    TABURCU_DEGER9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 125, 159, 130, false);
                    TABURCU_DEGER9.Name = "TABURCU_DEGER9";
                    TABURCU_DEGER9.Visible = EvetHayirEnum.ehHayir;
                    TABURCU_DEGER9.DrawStyle = DrawStyleConstants.vbSolid;
                    TABURCU_DEGER9.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_DEGER9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TABURCU_DEGER9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TABURCU_DEGER9.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER9.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER9.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER9.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER9.TextFont.CharSet = 162;
                    TABURCU_DEGER9.Value = @"";

                    TABURCU_ADI10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 132, 221, 137, false);
                    TABURCU_ADI10.Name = "TABURCU_ADI10";
                    TABURCU_ADI10.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_ADI10.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_ADI10.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_ADI10.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_ADI10.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_ADI10.TextFont.Size = 9;
                    TABURCU_ADI10.TextFont.CharSet = 162;
                    TABURCU_ADI10.Value = @"";

                    TABURCU_DEGER10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 132, 159, 137, false);
                    TABURCU_DEGER10.Name = "TABURCU_DEGER10";
                    TABURCU_DEGER10.Visible = EvetHayirEnum.ehHayir;
                    TABURCU_DEGER10.DrawStyle = DrawStyleConstants.vbSolid;
                    TABURCU_DEGER10.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_DEGER10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TABURCU_DEGER10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TABURCU_DEGER10.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER10.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER10.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER10.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER10.TextFont.CharSet = 162;
                    TABURCU_DEGER10.Value = @"";

                    TABURCU_ADI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 161, 139, 221, 144, false);
                    TABURCU_ADI11.Name = "TABURCU_ADI11";
                    TABURCU_ADI11.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_ADI11.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_ADI11.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_ADI11.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_ADI11.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_ADI11.TextFont.Size = 9;
                    TABURCU_ADI11.TextFont.CharSet = 162;
                    TABURCU_ADI11.Value = @"";

                    TABURCU_DEGER11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 154, 139, 159, 144, false);
                    TABURCU_DEGER11.Name = "TABURCU_DEGER11";
                    TABURCU_DEGER11.Visible = EvetHayirEnum.ehHayir;
                    TABURCU_DEGER11.DrawStyle = DrawStyleConstants.vbSolid;
                    TABURCU_DEGER11.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_DEGER11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TABURCU_DEGER11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TABURCU_DEGER11.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER11.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER11.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER11.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER11.TextFont.CharSet = 162;
                    TABURCU_DEGER11.Value = @"";

                    TABURCU_ADI12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 118, 291, 123, false);
                    TABURCU_ADI12.Name = "TABURCU_ADI12";
                    TABURCU_ADI12.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_ADI12.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_ADI12.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_ADI12.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_ADI12.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_ADI12.TextFont.Size = 9;
                    TABURCU_ADI12.TextFont.CharSet = 162;
                    TABURCU_ADI12.Value = @"";

                    TABURCU_DEGER12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 118, 229, 123, false);
                    TABURCU_DEGER12.Name = "TABURCU_DEGER12";
                    TABURCU_DEGER12.Visible = EvetHayirEnum.ehHayir;
                    TABURCU_DEGER12.DrawStyle = DrawStyleConstants.vbSolid;
                    TABURCU_DEGER12.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_DEGER12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TABURCU_DEGER12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TABURCU_DEGER12.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER12.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER12.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER12.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER12.TextFont.CharSet = 162;
                    TABURCU_DEGER12.Value = @"";

                    TABURCU_ADI13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 125, 291, 130, false);
                    TABURCU_ADI13.Name = "TABURCU_ADI13";
                    TABURCU_ADI13.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_ADI13.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_ADI13.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_ADI13.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_ADI13.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_ADI13.TextFont.Size = 9;
                    TABURCU_ADI13.TextFont.CharSet = 162;
                    TABURCU_ADI13.Value = @"";

                    TABURCU_DEGER13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 125, 229, 130, false);
                    TABURCU_DEGER13.Name = "TABURCU_DEGER13";
                    TABURCU_DEGER13.Visible = EvetHayirEnum.ehHayir;
                    TABURCU_DEGER13.DrawStyle = DrawStyleConstants.vbSolid;
                    TABURCU_DEGER13.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_DEGER13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TABURCU_DEGER13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TABURCU_DEGER13.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER13.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER13.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER13.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER13.TextFont.CharSet = 162;
                    TABURCU_DEGER13.Value = @"";

                    TABURCU_ADI14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 132, 291, 137, false);
                    TABURCU_ADI14.Name = "TABURCU_ADI14";
                    TABURCU_ADI14.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_ADI14.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_ADI14.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_ADI14.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_ADI14.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_ADI14.TextFont.Size = 9;
                    TABURCU_ADI14.TextFont.CharSet = 162;
                    TABURCU_ADI14.Value = @"";

                    TABURCU_DEGER14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 132, 229, 137, false);
                    TABURCU_DEGER14.Name = "TABURCU_DEGER14";
                    TABURCU_DEGER14.Visible = EvetHayirEnum.ehHayir;
                    TABURCU_DEGER14.DrawStyle = DrawStyleConstants.vbSolid;
                    TABURCU_DEGER14.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_DEGER14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TABURCU_DEGER14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TABURCU_DEGER14.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER14.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER14.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER14.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER14.TextFont.CharSet = 162;
                    TABURCU_DEGER14.Value = @"";

                    TABURCU_ADI15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 139, 291, 144, false);
                    TABURCU_ADI15.Name = "TABURCU_ADI15";
                    TABURCU_ADI15.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_ADI15.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_ADI15.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_ADI15.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_ADI15.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_ADI15.TextFont.Size = 9;
                    TABURCU_ADI15.TextFont.CharSet = 162;
                    TABURCU_ADI15.Value = @"";

                    TABURCU_DEGER15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 224, 139, 229, 144, false);
                    TABURCU_DEGER15.Name = "TABURCU_DEGER15";
                    TABURCU_DEGER15.Visible = EvetHayirEnum.ehHayir;
                    TABURCU_DEGER15.DrawStyle = DrawStyleConstants.vbSolid;
                    TABURCU_DEGER15.FieldType = ReportFieldTypeEnum.ftVariable;
                    TABURCU_DEGER15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TABURCU_DEGER15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TABURCU_DEGER15.MultiLine = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER15.NoClip = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER15.WordBreak = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER15.ExpandTabs = EvetHayirEnum.ehEvet;
                    TABURCU_DEGER15.TextFont.CharSet = 162;
                    TABURCU_DEGER15.Value = @"";

                    EGITIM_DEGER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 14, 15, 19, false);
                    EGITIM_DEGER.Name = "EGITIM_DEGER";
                    EGITIM_DEGER.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER.Value = @"";

                    EGITIM_DEGER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 21, 15, 26, false);
                    EGITIM_DEGER1.Name = "EGITIM_DEGER1";
                    EGITIM_DEGER1.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER1.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER1.Value = @"";

                    EGITIM_DEGER2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 28, 15, 33, false);
                    EGITIM_DEGER2.Name = "EGITIM_DEGER2";
                    EGITIM_DEGER2.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER2.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER2.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER2.Value = @"";

                    EGITIM_DEGER3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 35, 15, 40, false);
                    EGITIM_DEGER3.Name = "EGITIM_DEGER3";
                    EGITIM_DEGER3.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER3.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER3.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER3.Value = @"";

                    EGITIM_DEGER4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 42, 15, 47, false);
                    EGITIM_DEGER4.Name = "EGITIM_DEGER4";
                    EGITIM_DEGER4.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER4.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER4.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER4.Value = @"";

                    EGITIM_DEGER5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 49, 15, 54, false);
                    EGITIM_DEGER5.Name = "EGITIM_DEGER5";
                    EGITIM_DEGER5.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER5.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER5.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER5.Value = @"";

                    EGITIM_DEGER24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 56, 15, 61, false);
                    EGITIM_DEGER24.Name = "EGITIM_DEGER24";
                    EGITIM_DEGER24.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER24.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER24.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER24.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER24.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER24.Value = @"";

                    EGITIM_DEGER18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 14, 227, 19, false);
                    EGITIM_DEGER18.Name = "EGITIM_DEGER18";
                    EGITIM_DEGER18.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER18.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER18.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER18.Value = @"";

                    EGITIM_DEGER19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 21, 227, 26, false);
                    EGITIM_DEGER19.Name = "EGITIM_DEGER19";
                    EGITIM_DEGER19.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER19.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER19.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER19.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER19.Value = @"";

                    EGITIM_DEGER20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 28, 227, 33, false);
                    EGITIM_DEGER20.Name = "EGITIM_DEGER20";
                    EGITIM_DEGER20.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER20.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER20.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER20.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER20.Value = @"";

                    EGITIM_DEGER21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 35, 227, 40, false);
                    EGITIM_DEGER21.Name = "EGITIM_DEGER21";
                    EGITIM_DEGER21.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER21.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER21.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER21.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER21.Value = @"";

                    EGITIM_DEGER22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 42, 227, 47, false);
                    EGITIM_DEGER22.Name = "EGITIM_DEGER22";
                    EGITIM_DEGER22.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER22.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER22.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER22.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER22.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER22.Value = @"";

                    EGITIM_DEGER23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 49, 227, 54, false);
                    EGITIM_DEGER23.Name = "EGITIM_DEGER23";
                    EGITIM_DEGER23.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER23.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER23.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER23.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER23.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER23.Value = @"";

                    EGITIM_AILE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 14, 24, 19, false);
                    EGITIM_AILE.Name = "EGITIM_AILE";
                    EGITIM_AILE.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE.Value = @"";

                    EGITIM_AILE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 21, 24, 26, false);
                    EGITIM_AILE1.Name = "EGITIM_AILE1";
                    EGITIM_AILE1.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE1.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE1.Value = @"";

                    EGITIM_AILE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 28, 24, 33, false);
                    EGITIM_AILE2.Name = "EGITIM_AILE2";
                    EGITIM_AILE2.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE2.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE2.Value = @"";

                    EGITIM_AILE3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 35, 24, 40, false);
                    EGITIM_AILE3.Name = "EGITIM_AILE3";
                    EGITIM_AILE3.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE3.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE3.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE3.Value = @"";

                    EGITIM_AILE4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 42, 24, 47, false);
                    EGITIM_AILE4.Name = "EGITIM_AILE4";
                    EGITIM_AILE4.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE4.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE4.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE4.Value = @"";

                    EGITIM_AILE5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 49, 24, 54, false);
                    EGITIM_AILE5.Name = "EGITIM_AILE5";
                    EGITIM_AILE5.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE5.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE5.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE5.Value = @"";

                    EGITIM_AILE24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 56, 24, 61, false);
                    EGITIM_AILE24.Name = "EGITIM_AILE24";
                    EGITIM_AILE24.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE24.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE24.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE24.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE24.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE24.Value = @"";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 9, 18, 13, false);
                    NewField3.Name = "NewField3";
                    NewField3.Value = @"Kendisi";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 9, 28, 13, false);
                    NewField4.Name = "NewField4";
                    NewField4.Value = @"Yakını";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 28, 9, 52, 13, false);
                    NewField5.Name = "NewField5";
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField5.Value = @"Eğitim adı";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 80, 9, 90, 13, false);
                    NewField13.Name = "NewField13";
                    NewField13.Value = @"Kendisi";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 9, 99, 13, false);
                    NewField14.Name = "NewField14";
                    NewField14.Value = @"Yakını";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 9, 123, 13, false);
                    NewField15.Name = "NewField15";
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.Value = @"Eğitim adı";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 3, 292, 8, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 12;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"HASTA VE AİLE EĞİTİMİ";

                    EGITIM_DEGER6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 14, 86, 19, false);
                    EGITIM_DEGER6.Name = "EGITIM_DEGER6";
                    EGITIM_DEGER6.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER6.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER6.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER6.Value = @"";

                    EGITIM_DEGER7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 21, 86, 26, false);
                    EGITIM_DEGER7.Name = "EGITIM_DEGER7";
                    EGITIM_DEGER7.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER7.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER7.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER7.Value = @"";

                    EGITIM_DEGER8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 28, 86, 33, false);
                    EGITIM_DEGER8.Name = "EGITIM_DEGER8";
                    EGITIM_DEGER8.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER8.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER8.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER8.Value = @"";

                    EGITIM_DEGER9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 35, 86, 40, false);
                    EGITIM_DEGER9.Name = "EGITIM_DEGER9";
                    EGITIM_DEGER9.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER9.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER9.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER9.Value = @"";

                    EGITIM_DEGER10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 42, 86, 47, false);
                    EGITIM_DEGER10.Name = "EGITIM_DEGER10";
                    EGITIM_DEGER10.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER10.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER10.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER10.Value = @"";

                    EGITIM_DEGER11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 49, 86, 54, false);
                    EGITIM_DEGER11.Name = "EGITIM_DEGER11";
                    EGITIM_DEGER11.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER11.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER11.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER11.Value = @"";

                    EGITIM_ADI6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 14, 148, 19, false);
                    EGITIM_ADI6.Name = "EGITIM_ADI6";
                    EGITIM_ADI6.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI6.Value = @"";

                    EGITIM_ADI7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 21, 148, 26, false);
                    EGITIM_ADI7.Name = "EGITIM_ADI7";
                    EGITIM_ADI7.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI7.Value = @"";

                    EGITIM_ADI8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 28, 148, 33, false);
                    EGITIM_ADI8.Name = "EGITIM_ADI8";
                    EGITIM_ADI8.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI8.Value = @"";

                    EGITIM_ADI9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 35, 148, 40, false);
                    EGITIM_ADI9.Name = "EGITIM_ADI9";
                    EGITIM_ADI9.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI9.Value = @"";

                    EGITIM_ADI10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 42, 148, 47, false);
                    EGITIM_ADI10.Name = "EGITIM_ADI10";
                    EGITIM_ADI10.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI10.Value = @"";

                    EGITIM_ADI11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 49, 148, 54, false);
                    EGITIM_ADI11.Name = "EGITIM_ADI11";
                    EGITIM_ADI11.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI11.Value = @"";

                    EGITIM_AILE6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 14, 95, 19, false);
                    EGITIM_AILE6.Name = "EGITIM_AILE6";
                    EGITIM_AILE6.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE6.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE6.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE6.Value = @"";

                    EGITIM_AILE7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 21, 95, 26, false);
                    EGITIM_AILE7.Name = "EGITIM_AILE7";
                    EGITIM_AILE7.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE7.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE7.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE7.Value = @"";

                    EGITIM_AILE8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 28, 95, 33, false);
                    EGITIM_AILE8.Name = "EGITIM_AILE8";
                    EGITIM_AILE8.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE8.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE8.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE8.Value = @"";

                    EGITIM_AILE9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 35, 95, 40, false);
                    EGITIM_AILE9.Name = "EGITIM_AILE9";
                    EGITIM_AILE9.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE9.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE9.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE9.Value = @"";

                    EGITIM_AILE10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 42, 95, 47, false);
                    EGITIM_AILE10.Name = "EGITIM_AILE10";
                    EGITIM_AILE10.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE10.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE10.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE10.Value = @"";

                    EGITIM_AILE11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 49, 95, 54, false);
                    EGITIM_AILE11.Name = "EGITIM_AILE11";
                    EGITIM_AILE11.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE11.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE11.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE11.Value = @"";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 9, 160, 13, false);
                    NewField131.Name = "NewField131";
                    NewField131.Value = @"Kendisi";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 9, 169, 13, false);
                    NewField141.Name = "NewField141";
                    NewField141.Value = @"Yakını";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 9, 193, 13, false);
                    NewField151.Name = "NewField151";
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151.Value = @"Eğitim adı";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 221, 9, 231, 13, false);
                    NewField132.Name = "NewField132";
                    NewField132.Value = @"Kendisi";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 9, 240, 13, false);
                    NewField142.Name = "NewField142";
                    NewField142.Value = @"Yakını";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 9, 264, 13, false);
                    NewField152.Name = "NewField152";
                    NewField152.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField152.Value = @"Eğitim adı";

                    EGITIM_AILE12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 14, 165, 19, false);
                    EGITIM_AILE12.Name = "EGITIM_AILE12";
                    EGITIM_AILE12.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE12.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE12.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE12.Value = @"";

                    EGITIM_AILE13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 21, 165, 26, false);
                    EGITIM_AILE13.Name = "EGITIM_AILE13";
                    EGITIM_AILE13.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE13.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE13.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE13.Value = @"";

                    EGITIM_AILE14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 28, 165, 33, false);
                    EGITIM_AILE14.Name = "EGITIM_AILE14";
                    EGITIM_AILE14.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE14.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE14.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE14.Value = @"";

                    EGITIM_AILE15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 35, 165, 40, false);
                    EGITIM_AILE15.Name = "EGITIM_AILE15";
                    EGITIM_AILE15.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE15.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE15.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE15.Value = @"";

                    EGITIM_AILE16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 42, 165, 47, false);
                    EGITIM_AILE16.Name = "EGITIM_AILE16";
                    EGITIM_AILE16.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE16.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE16.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE16.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE16.Value = @"";

                    EGITIM_AILE17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 49, 165, 54, false);
                    EGITIM_AILE17.Name = "EGITIM_AILE17";
                    EGITIM_AILE17.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE17.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE17.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE17.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE17.Value = @"";

                    EGITIM_AILE18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 14, 236, 19, false);
                    EGITIM_AILE18.Name = "EGITIM_AILE18";
                    EGITIM_AILE18.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE18.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE18.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE18.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE18.Value = @"";

                    EGITIM_AILE19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 21, 236, 26, false);
                    EGITIM_AILE19.Name = "EGITIM_AILE19";
                    EGITIM_AILE19.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE19.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE19.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE19.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE19.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE19.Value = @"";

                    EGITIM_AILE20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 28, 236, 33, false);
                    EGITIM_AILE20.Name = "EGITIM_AILE20";
                    EGITIM_AILE20.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE20.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE20.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE20.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE20.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE20.Value = @"";

                    EGITIM_AILE21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 35, 236, 40, false);
                    EGITIM_AILE21.Name = "EGITIM_AILE21";
                    EGITIM_AILE21.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE21.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE21.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE21.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE21.Value = @"";

                    EGITIM_AILE22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 42, 236, 47, false);
                    EGITIM_AILE22.Name = "EGITIM_AILE22";
                    EGITIM_AILE22.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE22.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE22.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE22.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE22.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE22.Value = @"";

                    EGITIM_AILE23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 49, 236, 54, false);
                    EGITIM_AILE23.Name = "EGITIM_AILE23";
                    EGITIM_AILE23.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE23.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE23.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE23.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE23.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE23.Value = @"";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 63, 35, 68, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Name = "Arial";
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @"Eğitim Notları";

                    InstructionNote = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 69, 289, 84, false);
                    InstructionNote.Name = "InstructionNote";
                    InstructionNote.DrawStyle = DrawStyleConstants.vbSolid;
                    InstructionNote.MultiLine = EvetHayirEnum.ehEvet;
                    InstructionNote.WordBreak = EvetHayirEnum.ehEvet;
                    InstructionNote.TextFont.Name = "Arial Unicode MS";
                    InstructionNote.TextFont.CharSet = 162;
                    InstructionNote.Value = @"";

                    EGITIM_ADI25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 56, 148, 61, false);
                    EGITIM_ADI25.Name = "EGITIM_ADI25";
                    EGITIM_ADI25.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI25.Value = @"";

                    EGITIM_DEGER25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 56, 86, 61, false);
                    EGITIM_DEGER25.Name = "EGITIM_DEGER25";
                    EGITIM_DEGER25.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER25.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER25.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER25.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER25.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER25.Value = @"";

                    EGITIM_AILE25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 90, 56, 95, 61, false);
                    EGITIM_AILE25.Name = "EGITIM_AILE25";
                    EGITIM_AILE25.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE25.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE25.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE25.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE25.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE25.Value = @"";

                    EGITIM_ADI26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 56, 218, 61, false);
                    EGITIM_ADI26.Name = "EGITIM_ADI26";
                    EGITIM_ADI26.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI26.Value = @"";

                    EGITIM_DEGER26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 56, 156, 61, false);
                    EGITIM_DEGER26.Name = "EGITIM_DEGER26";
                    EGITIM_DEGER26.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER26.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER26.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER26.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER26.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER26.Value = @"";

                    EGITIM_AILE26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 56, 165, 61, false);
                    EGITIM_AILE26.Name = "EGITIM_AILE26";
                    EGITIM_AILE26.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE26.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE26.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE26.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE26.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE26.Value = @"";

                    EGITIM_ADI27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 239, 57, 289, 62, false);
                    EGITIM_ADI27.Name = "EGITIM_ADI27";
                    EGITIM_ADI27.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_ADI27.Value = @"";

                    EGITIM_DEGER27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 56, 227, 61, false);
                    EGITIM_DEGER27.Name = "EGITIM_DEGER27";
                    EGITIM_DEGER27.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_DEGER27.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_DEGER27.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_DEGER27.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_DEGER27.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_DEGER27.Value = @"";

                    EGITIM_AILE27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 56, 236, 61, false);
                    EGITIM_AILE27.Name = "EGITIM_AILE27";
                    EGITIM_AILE27.Visible = EvetHayirEnum.ehHayir;
                    EGITIM_AILE27.DrawStyle = DrawStyleConstants.vbSolid;
                    EGITIM_AILE27.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM_AILE27.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EGITIM_AILE27.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EGITIM_AILE27.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EGITIM_ADI.CalcValue = @"";
                    EGITIM_ADI1.CalcValue = @"";
                    EGITIM_ADI2.CalcValue = @"";
                    EGITIM_ADI3.CalcValue = @"";
                    EGITIM_ADI4.CalcValue = @"";
                    EGITIM_ADI5.CalcValue = @"";
                    EGITIM_ADI12.CalcValue = @"";
                    EGITIM_DEGER12.CalcValue = @"";
                    EGITIM_ADI13.CalcValue = @"";
                    EGITIM_DEGER13.CalcValue = @"";
                    EGITIM_ADI14.CalcValue = @"";
                    EGITIM_DEGER14.CalcValue = @"";
                    EGITIM_ADI15.CalcValue = @"";
                    EGITIM_DEGER15.CalcValue = @"";
                    EGITIM_ADI16.CalcValue = @"";
                    EGITIM_DEGER16.CalcValue = @"";
                    EGITIM_ADI17.CalcValue = @"";
                    EGITIM_DEGER17.CalcValue = @"";
                    EGITIM_ADI18.CalcValue = @"";
                    EGITIM_ADI19.CalcValue = @"";
                    EGITIM_ADI20.CalcValue = @"";
                    EGITIM_ADI21.CalcValue = @"";
                    EGITIM_ADI22.CalcValue = @"";
                    EGITIM_ADI23.CalcValue = @"";
                    EGITIM_ADI24.CalcValue = @"";
                    NewField11.CalcValue = NewField11.Value;
                    NewField2.CalcValue = NewField2.Value;
                    TABURCU_ADI.CalcValue = @"";
                    TABURCU_DEGER.CalcValue = @"";
                    TABURCU_ADI1.CalcValue = @"";
                    TABURCU_DEGER1.CalcValue = @"";
                    TABURCU_ADI2.CalcValue = @"";
                    TABURCU_DEGER2.CalcValue = @"";
                    TABURCU_ADI3.CalcValue = @"";
                    TABURCU_DEGER3.CalcValue = @"";
                    TABURCU_ADI4.CalcValue = @"";
                    TABURCU_DEGER4.CalcValue = @"";
                    TABURCU_ADI5.CalcValue = @"";
                    TABURCU_DEGER5.CalcValue = @"";
                    TABURCU_ADI6.CalcValue = @"";
                    TABURCU_DEGER6.CalcValue = @"";
                    TABURCU_ADI7.CalcValue = @"";
                    TABURCU_DEGER7.CalcValue = @"";
                    TABURCU_ADI8.CalcValue = @"";
                    TABURCU_DEGER8.CalcValue = @"";
                    TABURCU_ADI9.CalcValue = @"";
                    TABURCU_DEGER9.CalcValue = @"";
                    TABURCU_ADI10.CalcValue = @"";
                    TABURCU_DEGER10.CalcValue = @"";
                    TABURCU_ADI11.CalcValue = @"";
                    TABURCU_DEGER11.CalcValue = @"";
                    TABURCU_ADI12.CalcValue = @"";
                    TABURCU_DEGER12.CalcValue = @"";
                    TABURCU_ADI13.CalcValue = @"";
                    TABURCU_DEGER13.CalcValue = @"";
                    TABURCU_ADI14.CalcValue = @"";
                    TABURCU_DEGER14.CalcValue = @"";
                    TABURCU_ADI15.CalcValue = @"";
                    TABURCU_DEGER15.CalcValue = @"";
                    EGITIM_DEGER.CalcValue = @"";
                    EGITIM_DEGER1.CalcValue = @"";
                    EGITIM_DEGER2.CalcValue = @"";
                    EGITIM_DEGER3.CalcValue = @"";
                    EGITIM_DEGER4.CalcValue = @"";
                    EGITIM_DEGER5.CalcValue = @"";
                    EGITIM_DEGER24.CalcValue = @"";
                    EGITIM_DEGER18.CalcValue = @"";
                    EGITIM_DEGER19.CalcValue = @"";
                    EGITIM_DEGER20.CalcValue = @"";
                    EGITIM_DEGER21.CalcValue = @"";
                    EGITIM_DEGER22.CalcValue = @"";
                    EGITIM_DEGER23.CalcValue = @"";
                    EGITIM_AILE.CalcValue = @"";
                    EGITIM_AILE1.CalcValue = @"";
                    EGITIM_AILE2.CalcValue = @"";
                    EGITIM_AILE3.CalcValue = @"";
                    EGITIM_AILE4.CalcValue = @"";
                    EGITIM_AILE5.CalcValue = @"";
                    EGITIM_AILE24.CalcValue = @"";
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField1.CalcValue = NewField1.Value;
                    EGITIM_DEGER6.CalcValue = @"";
                    EGITIM_DEGER7.CalcValue = @"";
                    EGITIM_DEGER8.CalcValue = @"";
                    EGITIM_DEGER9.CalcValue = @"";
                    EGITIM_DEGER10.CalcValue = @"";
                    EGITIM_DEGER11.CalcValue = @"";
                    EGITIM_ADI6.CalcValue = @"";
                    EGITIM_ADI7.CalcValue = @"";
                    EGITIM_ADI8.CalcValue = @"";
                    EGITIM_ADI9.CalcValue = @"";
                    EGITIM_ADI10.CalcValue = @"";
                    EGITIM_ADI11.CalcValue = @"";
                    EGITIM_AILE6.CalcValue = @"";
                    EGITIM_AILE7.CalcValue = @"";
                    EGITIM_AILE8.CalcValue = @"";
                    EGITIM_AILE9.CalcValue = @"";
                    EGITIM_AILE10.CalcValue = @"";
                    EGITIM_AILE11.CalcValue = @"";
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField152.CalcValue = NewField152.Value;
                    EGITIM_AILE12.CalcValue = @"";
                    EGITIM_AILE13.CalcValue = @"";
                    EGITIM_AILE14.CalcValue = @"";
                    EGITIM_AILE15.CalcValue = @"";
                    EGITIM_AILE16.CalcValue = @"";
                    EGITIM_AILE17.CalcValue = @"";
                    EGITIM_AILE18.CalcValue = @"";
                    EGITIM_AILE19.CalcValue = @"";
                    EGITIM_AILE20.CalcValue = @"";
                    EGITIM_AILE21.CalcValue = @"";
                    EGITIM_AILE22.CalcValue = @"";
                    EGITIM_AILE23.CalcValue = @"";
                    NewField6.CalcValue = NewField6.Value;
                    InstructionNote.CalcValue = InstructionNote.Value;
                    EGITIM_ADI25.CalcValue = @"";
                    EGITIM_DEGER25.CalcValue = @"";
                    EGITIM_AILE25.CalcValue = @"";
                    EGITIM_ADI26.CalcValue = @"";
                    EGITIM_DEGER26.CalcValue = @"";
                    EGITIM_AILE26.CalcValue = @"";
                    EGITIM_ADI27.CalcValue = @"";
                    EGITIM_DEGER27.CalcValue = @"";
                    EGITIM_AILE27.CalcValue = @"";
                    return new TTReportObject[] { EGITIM_ADI,EGITIM_ADI1,EGITIM_ADI2,EGITIM_ADI3,EGITIM_ADI4,EGITIM_ADI5,EGITIM_ADI12,EGITIM_DEGER12,EGITIM_ADI13,EGITIM_DEGER13,EGITIM_ADI14,EGITIM_DEGER14,EGITIM_ADI15,EGITIM_DEGER15,EGITIM_ADI16,EGITIM_DEGER16,EGITIM_ADI17,EGITIM_DEGER17,EGITIM_ADI18,EGITIM_ADI19,EGITIM_ADI20,EGITIM_ADI21,EGITIM_ADI22,EGITIM_ADI23,EGITIM_ADI24,NewField11,NewField2,TABURCU_ADI,TABURCU_DEGER,TABURCU_ADI1,TABURCU_DEGER1,TABURCU_ADI2,TABURCU_DEGER2,TABURCU_ADI3,TABURCU_DEGER3,TABURCU_ADI4,TABURCU_DEGER4,TABURCU_ADI5,TABURCU_DEGER5,TABURCU_ADI6,TABURCU_DEGER6,TABURCU_ADI7,TABURCU_DEGER7,TABURCU_ADI8,TABURCU_DEGER8,TABURCU_ADI9,TABURCU_DEGER9,TABURCU_ADI10,TABURCU_DEGER10,TABURCU_ADI11,TABURCU_DEGER11,TABURCU_ADI12,TABURCU_DEGER12,TABURCU_ADI13,TABURCU_DEGER13,TABURCU_ADI14,TABURCU_DEGER14,TABURCU_ADI15,TABURCU_DEGER15,EGITIM_DEGER,EGITIM_DEGER1,EGITIM_DEGER2,EGITIM_DEGER3,EGITIM_DEGER4,EGITIM_DEGER5,EGITIM_DEGER24,EGITIM_DEGER18,EGITIM_DEGER19,EGITIM_DEGER20,EGITIM_DEGER21,EGITIM_DEGER22,EGITIM_DEGER23,EGITIM_AILE,EGITIM_AILE1,EGITIM_AILE2,EGITIM_AILE3,EGITIM_AILE4,EGITIM_AILE5,EGITIM_AILE24,NewField3,NewField4,NewField5,NewField13,NewField14,NewField15,NewField1,EGITIM_DEGER6,EGITIM_DEGER7,EGITIM_DEGER8,EGITIM_DEGER9,EGITIM_DEGER10,EGITIM_DEGER11,EGITIM_ADI6,EGITIM_ADI7,EGITIM_ADI8,EGITIM_ADI9,EGITIM_ADI10,EGITIM_ADI11,EGITIM_AILE6,EGITIM_AILE7,EGITIM_AILE8,EGITIM_AILE9,EGITIM_AILE10,EGITIM_AILE11,NewField131,NewField141,NewField151,NewField132,NewField142,NewField152,EGITIM_AILE12,EGITIM_AILE13,EGITIM_AILE14,EGITIM_AILE15,EGITIM_AILE16,EGITIM_AILE17,EGITIM_AILE18,EGITIM_AILE19,EGITIM_AILE20,EGITIM_AILE21,EGITIM_AILE22,EGITIM_AILE23,NewField6,InstructionNote,EGITIM_ADI25,EGITIM_DEGER25,EGITIM_AILE25,EGITIM_ADI26,EGITIM_DEGER26,EGITIM_AILE26,EGITIM_ADI27,EGITIM_DEGER27,EGITIM_AILE27};
                }
#region MAIN BODY_Methods
            //List<TTReportObjects> GetEgitimAdiAlanList()
                //{
                //    List<TTReportObjects> egitimAdiAlanList = new List<TTReportObjects>();
                //    for(int i = 0; i < this.ReportObjects.Count; i++)
                //    {
                //        if()
                //    }
                //    foreach (TTReportObject alan in )
                //    {
                //        if (((TTReportObject)alan).Name.Contains("EGITIM_ADI"))
                //        {
                //            egitimAdiAlanList.Add();
                //        }

                //    }
                //    return egitimAdiAlanList;
                //}

                //List<TTReportObjects> GetEgitimDegerAlanList()
                //{
                //    List<TTReportObjects> egitimDegerAlanList = new List<TTReportObjects>();
                //    foreach (TTReportObjects alan in this.ReportObjects)
                //    {
                //        //if (alan.CalcCrossValues .Name.Contains("EGITIM_DEGER"))
                //        //{
                //        //    egitimDegerAlanList.Add(alan);
                //        //}
                //        alan.CalcCrossValues("a");

                //    }
                //    return egitimDegerAlanList;
                //}
#endregion MAIN BODY_Methods

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
                    
                    string sObjectID = ((NursingInstructionAndDischargeReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                    NursingApplication nursingApp = (NursingApplication)context.GetObject(new Guid(sObjectID), "NursingApplication");

                    if(((NursingInstructionAndDischargeReport)ParentReport).RuntimeParameters.OBJECTID != null && ((NursingInstructionAndDischargeReport)ParentReport).RuntimeParameters.OBJECTID != Guid.Empty)
                    {
                        string objID = ((NursingInstructionAndDischargeReport)ParentReport).RuntimeParameters.OBJECTID.ToString();
                        BaseNursingPatientAndFamilyInstruction nursingPatientAndFamilyInstruction = (BaseNursingPatientAndFamilyInstruction)context.GetObject(new Guid(objID), "BaseNursingPatientAndFamilyInstruction");
                        if (nursingPatientAndFamilyInstruction != null)
                        {

                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 0)
                            {
                                this.EGITIM_ADI.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[0].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[0].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[0].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[0].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE.CalcValue = "X";
                                }
                                this.EGITIM_DEGER.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE.Visible = EvetHayirEnum.ehEvet;
                            }

                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 1)
                            {
                                this.EGITIM_ADI1.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[1].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[1].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[1].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER1.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[1].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE1.CalcValue = "X";
                                }
                                this.EGITIM_DEGER1.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE1.Visible = EvetHayirEnum.ehEvet;
                            }

                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 2)
                            {
                                this.EGITIM_ADI2.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[2].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[2].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[2].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER2.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[2].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE2.CalcValue = "X";
                                }
                                this.EGITIM_DEGER2.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE2.Visible = EvetHayirEnum.ehEvet;
                            }

                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 3)
                            {
                                this.EGITIM_ADI3.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[3].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[3].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[3].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER3.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[3].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE3.CalcValue = "X";
                                }
                                this.EGITIM_DEGER3.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE3.Visible = EvetHayirEnum.ehEvet;
                            }

                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 4)
                            {
                                this.EGITIM_ADI4.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[4].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[4].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[4].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER4.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[4].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE4.CalcValue = "X";
                                }
                                this.EGITIM_DEGER4.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE4.Visible = EvetHayirEnum.ehEvet;
                            }

                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 5)
                            {
                                this.EGITIM_ADI5.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[5].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[5].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[5].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER5.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[5].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE5.CalcValue = "X";
                                }
                                this.EGITIM_DEGER5.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE5.Visible = EvetHayirEnum.ehEvet;
                            }
                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 6)
                            {
                                this.EGITIM_ADI6.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[6].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[6].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[6].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER6.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[6].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE6.CalcValue = "X";
                                }
                                this.EGITIM_DEGER6.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE6.Visible = EvetHayirEnum.ehEvet;
                            }
                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 7)
                            {
                                this.EGITIM_ADI7.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[7].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[7].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[7].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER7.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[7].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE7.CalcValue = "X";
                                }
                                this.EGITIM_DEGER7.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE7.Visible = EvetHayirEnum.ehEvet;
                            }
                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 8)
                            {
                                this.EGITIM_ADI8.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[8].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[8].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[8].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER8.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[8].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE8.CalcValue = "X";
                                }
                                this.EGITIM_DEGER8.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE8.Visible = EvetHayirEnum.ehEvet;
                            }
                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 9)
                            {
                                this.EGITIM_ADI9.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[9].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[9].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[9].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER9.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[9].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE9.CalcValue = "X";
                                }
                                this.EGITIM_DEGER9.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE9.Visible = EvetHayirEnum.ehEvet;
                            }
                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 10)
                            {
                                this.EGITIM_ADI10.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[10].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[10].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[10].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER10.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[10].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE10.CalcValue = "X";
                                }
                                this.EGITIM_DEGER10.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE10.Visible = EvetHayirEnum.ehEvet;
                            }
                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 11)
                            {
                                this.EGITIM_ADI11.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[11].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[11].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[11].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER11.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[11].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE11.CalcValue = "X";
                                }
                                this.EGITIM_DEGER11.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE11.Visible = EvetHayirEnum.ehEvet;
                            }
                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 12)
                            {
                                this.EGITIM_ADI12.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[12].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[12].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[12].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER12.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[12].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE12.CalcValue = "X";
                                }
                                this.EGITIM_DEGER12.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE12.Visible = EvetHayirEnum.ehEvet;
                            }
                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 13)
                            {
                                this.EGITIM_ADI13.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[13].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[13].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[13].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER13.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[13].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE13.CalcValue = "X";
                                }
                                this.EGITIM_DEGER13.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE13.Visible = EvetHayirEnum.ehEvet;
                            }
                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 14)
                            {
                                this.EGITIM_ADI14.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[14].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[14].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[14].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER14.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[14].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE14.CalcValue = "X";
                                }
                                this.EGITIM_DEGER14.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE14.Visible = EvetHayirEnum.ehEvet;
                            }
                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 15)
                            {
                                this.EGITIM_ADI15.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[15].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[15].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[15].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER15.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[15].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE15.CalcValue = "X";
                                }
                                this.EGITIM_DEGER15.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE15.Visible = EvetHayirEnum.ehEvet;
                            }
                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 16)
                            {
                                this.EGITIM_ADI16.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[16].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[16].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[16].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER16.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[16].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE16.CalcValue = "X";
                                }
                                this.EGITIM_DEGER16.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE16.Visible = EvetHayirEnum.ehEvet;
                            }
                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 17)
                            {
                                this.EGITIM_ADI17.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[17].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[17].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[17].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER17.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[17].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE17.CalcValue = "X";
                                }
                                this.EGITIM_DEGER17.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE17.Visible = EvetHayirEnum.ehEvet;
                            }
                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 18)
                            {
                                this.EGITIM_ADI18.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[18].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[18].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[18].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER18.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[18].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE18.CalcValue = "X";
                                }
                                this.EGITIM_DEGER18.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE18.Visible = EvetHayirEnum.ehEvet;
                            }
                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 19)
                            {
                                this.EGITIM_ADI19.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[19].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[19].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[19].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER19.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[19].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE19.CalcValue = "X";
                                }
                                this.EGITIM_DEGER19.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE19.Visible = EvetHayirEnum.ehEvet;
                            }
                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 20)
                            {
                                this.EGITIM_ADI20.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[20].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[20].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[20].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER20.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[20].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE20.CalcValue = "X";
                                }
                                this.EGITIM_DEGER20.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE20.Visible = EvetHayirEnum.ehEvet;
                            }
                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 21)
                            {
                                this.EGITIM_ADI21.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[21].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[21].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[21].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER21.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[21].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE21.CalcValue = "X";
                                }
                                this.EGITIM_DEGER21.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE21.Visible = EvetHayirEnum.ehEvet;
                            }
                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 22)
                            {
                                this.EGITIM_ADI22.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[22].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[22].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[22].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER22.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[22].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE22.CalcValue = "X";
                                }
                                this.EGITIM_DEGER22.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE22.Visible = EvetHayirEnum.ehEvet;
                            }
                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 23)
                            {
                                this.EGITIM_ADI23.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[23].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[23].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[23].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER23.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[23].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE23.CalcValue = "X";
                                }
                                this.EGITIM_DEGER23.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE23.Visible = EvetHayirEnum.ehEvet;
                            }
                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 24)
                            {
                                this.EGITIM_ADI24.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[24].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[24].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[24].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER24.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[24].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE24.CalcValue = "X";
                                }
                                this.EGITIM_DEGER24.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE24.Visible = EvetHayirEnum.ehEvet;
                            }
                            
                            if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 25)
                            {
                                this.EGITIM_ADI25.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[25].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[25].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[25].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER25.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[25].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE25.CalcValue = "X";
                                }
                                this.EGITIM_DEGER25.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE25.Visible = EvetHayirEnum.ehEvet;
                            }
                            
                               if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 26)
                            {
                                this.EGITIM_ADI26.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[26].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[26].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[26].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER26.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[26].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE26.CalcValue = "X";
                                }
                                this.EGITIM_DEGER26.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE26.Visible = EvetHayirEnum.ehEvet;
                            }
                               
                              if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions.Count > 27)
                            {
                                this.EGITIM_ADI27.CalcValue = nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[27].PatientAndFamilyInstruction.Name;
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[27].PatientGetInstruction != null && nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[27].PatientGetInstruction.Value)
                                {
                                    this.EGITIM_DEGER27.CalcValue = "X";
                                }
                                if (nursingPatientAndFamilyInstruction.NursingPatientAndFamilyInstructions[27].CompanionGetInstruction == true)
                                {
                                    this.EGITIM_AILE27.CalcValue = "X";
                                }
                                this.EGITIM_DEGER27.Visible = EvetHayirEnum.ehEvet;
                                this.EGITIM_AILE27.Visible = EvetHayirEnum.ehEvet;
                            }

                            this.InstructionNote.CalcValue = nursingPatientAndFamilyInstruction.InstructionNote;
                        }
                    }

                    System.ComponentModel.BindingList<PatientAndFamilyInstructionDefinition> AllPatientFamilyInstDefList = PatientAndFamilyInstructionDefinition.GetAllPatientFamilyInstDefList(context);
                    var nursingPatientAndFamilyInstructions = nursingApp.BaseNursingPatientAndFamilyInstructions.Where(x => x.CurrentStateDefID != BaseNursingDataEntry.States.Cancelled).ToList();
                    var nursingDischargingInstructionPlans = nursingApp.BaseNursingDischargingInstructionPlans.Where(x => x.CurrentStateDefID != BaseNursingDataEntry.States.Cancelled).ToList();
             
                    if (nursingDischargingInstructionPlans.Count > 0)
                    {                       
                        
                        if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans.Count > 0)
                        {
                            this.TABURCU_ADI.CalcValue = nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[0].DischargingInstructionPlan.Name;
                            if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[0].PatientGetInstruction == true)
                            {
                                this.TABURCU_DEGER.CalcValue = "X";
                            }
                            this.TABURCU_DEGER.Visible = EvetHayirEnum.ehEvet;
                        }
                        if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans.Count > 1)
                        {
                            this.TABURCU_ADI1.CalcValue = nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[1].DischargingInstructionPlan.Name;
                            if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[1].PatientGetInstruction == true)
                            {
                                this.TABURCU_DEGER1.CalcValue = "X";
                            }
                            this.TABURCU_DEGER1.Visible = EvetHayirEnum.ehEvet;
                        }
                        if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans.Count > 2)
                        {
                            this.TABURCU_ADI2.CalcValue = nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[2].DischargingInstructionPlan.Name;
                            if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[2].PatientGetInstruction == true)
                            {
                                this.TABURCU_DEGER2.CalcValue = "X";
                            }
                            this.TABURCU_DEGER2.Visible = EvetHayirEnum.ehEvet;
                        }
                        if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans.Count > 3)
                        {
                            this.TABURCU_ADI3.CalcValue = nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[3].DischargingInstructionPlan.Name;
                            if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[3].PatientGetInstruction == true)
                            {
                                this.TABURCU_DEGER3.CalcValue = "X";
                            }
                            this.TABURCU_DEGER3.Visible = EvetHayirEnum.ehEvet;
                        }
                        if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans.Count > 4)
                        {
                            this.TABURCU_ADI4.CalcValue = nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[4].DischargingInstructionPlan.Name;
                            if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[4].PatientGetInstruction == true)
                            {
                                this.TABURCU_DEGER4.CalcValue = "X";
                            }
                            this.TABURCU_DEGER4.Visible = EvetHayirEnum.ehEvet;
                        }
                        if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans.Count > 5)
                        {
                            this.TABURCU_ADI5.CalcValue = nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[5].DischargingInstructionPlan.Name;
                            if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[5].PatientGetInstruction == true)
                            {
                                this.TABURCU_DEGER5.CalcValue = "X";
                            }
                            this.TABURCU_DEGER5.Visible = EvetHayirEnum.ehEvet;
                        }
                        if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans.Count > 6)
                        {
                            this.TABURCU_ADI6.CalcValue = nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[6].DischargingInstructionPlan.Name;
                            if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[6].PatientGetInstruction == true)
                            {
                                this.TABURCU_DEGER6.CalcValue = "X";
                            }
                            this.TABURCU_DEGER6.Visible = EvetHayirEnum.ehEvet;
                        }
                        if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans.Count > 7)
                        {
                            this.TABURCU_ADI7.CalcValue = nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[7].DischargingInstructionPlan.Name;
                            if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[7].PatientGetInstruction == true)
                            {
                                this.TABURCU_DEGER7.CalcValue = "X";
                            }
                            this.TABURCU_DEGER7.Visible = EvetHayirEnum.ehEvet;
                        }
                        if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans.Count > 8)
                        {
                            this.TABURCU_ADI8.CalcValue = nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[8].DischargingInstructionPlan.Name;
                            if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[8].PatientGetInstruction == true)
                            {
                                this.TABURCU_DEGER8.CalcValue = "X";
                            }
                            this.TABURCU_DEGER8.Visible = EvetHayirEnum.ehEvet;
                        }
                        if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans.Count > 9)
                        {
                            this.TABURCU_ADI9.CalcValue = nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[9].DischargingInstructionPlan.Name;
                            if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[9].PatientGetInstruction == true)
                            {
                                this.TABURCU_DEGER9.CalcValue = "X";
                            }
                            this.TABURCU_DEGER9.Visible = EvetHayirEnum.ehEvet;
                        }
                        if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans.Count > 10)
                        {
                            this.TABURCU_ADI10.CalcValue = nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[10].DischargingInstructionPlan.Name;
                            if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[10].PatientGetInstruction == true)
                            {
                                this.TABURCU_DEGER10.CalcValue = "X";
                            }
                            this.TABURCU_DEGER10.Visible = EvetHayirEnum.ehEvet;
                        }
                        if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans.Count > 11)
                        {
                            this.TABURCU_ADI11.CalcValue = nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[11].DischargingInstructionPlan.Name;
                            if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[11].PatientGetInstruction == true)
                            {
                                this.TABURCU_DEGER11.CalcValue = "X";
                            }
                            this.TABURCU_DEGER11.Visible = EvetHayirEnum.ehEvet;
                        }
                        if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans.Count > 12)
                        {
                            this.TABURCU_ADI12.CalcValue = nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[12].DischargingInstructionPlan.Name;
                            if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[12].PatientGetInstruction == true)
                            {
                                this.TABURCU_DEGER12.CalcValue = "X";
                            }
                            this.TABURCU_DEGER12.Visible = EvetHayirEnum.ehEvet;
                        }
                        if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans.Count > 13)
                        {
                            this.TABURCU_ADI13.CalcValue = nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[13].DischargingInstructionPlan.Name;
                            if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[13].PatientGetInstruction == true)
                            {
                                this.TABURCU_DEGER13.CalcValue = "X";
                            }
                            this.TABURCU_DEGER13.Visible = EvetHayirEnum.ehEvet;
                        }
                        if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans.Count > 14)
                        {
                            this.TABURCU_ADI14.CalcValue = nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[14].DischargingInstructionPlan.Name;
                            if (nursingDischargingInstructionPlans[0].NursingDischargingInstructionPlans[14].PatientGetInstruction == true)
                            {
                                this.TABURCU_DEGER14.CalcValue = "X";
                            }
                            this.TABURCU_DEGER14.Visible = EvetHayirEnum.ehEvet;
                        }
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

        public NursingInstructionAndDischargeReport()
        {
            PartA = new PartAGroup(this,"PartA");
            Patient = new PatientGroup(PartA,"Patient");
            MAIN = new MAINGroup(Patient,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "TTOBJECTID", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter = Parameters.Add("OBJECTID", "00000000-0000-0000-0000-000000000000", "OBJECTID", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("OBJECTID"))
                _runtimeParameters.OBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["OBJECTID"]);
            Name = "NURSINGINSTRUCTIONANDDISCHARGEREPORT";
            Caption = "Hemşirelik Hasta Eğitimi ve Taburculuk Raporu";
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