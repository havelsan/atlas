
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
    public partial class FTRTreatmentCard : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string PHYSIOTHERAPYREQUEST = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class part2Group : TTReportGroup
        {
            public FTRTreatmentCard MyParentReport
            {
                get { return (FTRTreatmentCard)ParentReport; }
            }

            new public part2GroupHeader Header()
            {
                return (part2GroupHeader)_header;
            }

            new public part2GroupFooter Footer()
            {
                return (part2GroupFooter)_footer;
            }

            public TTReportField HospitalInfo1 { get {return Header().HospitalInfo1;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public part2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public part2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new part2GroupHeader(this);
                _footer = new part2GroupFooter(this);

            }

            public partial class part2GroupHeader : TTReportSection
            {
                public FTRTreatmentCard MyParentReport
                {
                    get { return (FTRTreatmentCard)ParentReport; }
                }
                
                public TTReportField HospitalInfo1;
                public TTReportField LOGO; 
                public part2GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 34;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HospitalInfo1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 6, 241, 32, false);
                    HospitalInfo1.Name = "HospitalInfo1";
                    HospitalInfo1.FieldType = ReportFieldTypeEnum.ftExpression;
                    HospitalInfo1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HospitalInfo1.MultiLine = EvetHayirEnum.ehEvet;
                    HospitalInfo1.NoClip = EvetHayirEnum.ehEvet;
                    HospitalInfo1.WordBreak = EvetHayirEnum.ehEvet;
                    HospitalInfo1.ExpandTabs = EvetHayirEnum.ehEvet;
                    HospitalInfo1.TextFont.Size = 14;
                    HospitalInfo1.TextFont.Bold = true;
                    HospitalInfo1.TextFont.CharSet = 162;
                    HospitalInfo1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 9, 36, 32, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.TextFont.CharSet = 162;
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    LOGO.CalcValue = @"";
                    HospitalInfo1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { LOGO,HospitalInfo1};
                }

                public override void RunScript()
                {
#region PART2 HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion PART2 HEADER_Script
                }
            }
            public partial class part2GroupFooter : TTReportSection
            {
                public FTRTreatmentCard MyParentReport
                {
                    get { return (FTRTreatmentCard)ParentReport; }
                }
                 
                public part2GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    RepeatCount = 0;
                    
                }
                
            }

        }

        public part2Group part2;

        public partial class part1Group : TTReportGroup
        {
            public FTRTreatmentCard MyParentReport
            {
                get { return (FTRTreatmentCard)ParentReport; }
            }

            new public part1GroupHeader Header()
            {
                return (part1GroupHeader)_header;
            }

            new public part1GroupFooter Footer()
            {
                return (part1GroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NameSurname { get {return Header().NameSurname;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField Age { get {return Header().Age;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField Sex { get {return Header().Sex;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField NewField143 { get {return Header().NewField143;} }
            public TTReportField Protocol { get {return Header().Protocol;} }
            public TTReportField RoomBed { get {return Header().RoomBed;} }
            public TTReportField NewField1242 { get {return Header().NewField1242;} }
            public TTReportField NewField1243 { get {return Header().NewField1243;} }
            public TTReportField StartDate2 { get {return Header().StartDate2;} }
            public TTReportField StartDate { get {return Header().StartDate;} }
            public TTReportField NewField13422 { get {return Header().NewField13422;} }
            public TTReportField F1 { get {return Header().F1;} }
            public TTReportField Clinic { get {return Header().Clinic;} }
            public TTReportField Diagnosis { get {return Header().Diagnosis;} }
            public TTReportField NewField122431 { get {return Header().NewField122431;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportShape NewLine4 { get {return Header().NewLine4;} }
            public TTReportField Episode { get {return Header().Episode;} }
            public TTReportField NewField5 { get {return Footer().NewField5;} }
            public TTReportField Malignancy { get {return Footer().Malignancy;} }
            public TTReportField NewField7 { get {return Footer().NewField7;} }
            public TTReportField VascularDisorder { get {return Footer().VascularDisorder;} }
            public TTReportField NewField17 { get {return Footer().NewField17;} }
            public TTReportField HeartFailure { get {return Footer().HeartFailure;} }
            public TTReportField NewField19 { get {return Footer().NewField19;} }
            public TTReportField Infection { get {return Footer().Infection;} }
            public TTReportField NewField171 { get {return Footer().NewField171;} }
            public TTReportField MetalImplant { get {return Footer().MetalImplant;} }
            public TTReportField NewField21 { get {return Footer().NewField21;} }
            public TTReportField Stent { get {return Footer().Stent;} }
            public TTReportField NewField172 { get {return Footer().NewField172;} }
            public TTReportField Broken { get {return Footer().Broken;} }
            public TTReportField NewField191 { get {return Footer().NewField191;} }
            public TTReportField Diabetes { get {return Footer().Diabetes;} }
            public TTReportField NewField1171 { get {return Footer().NewField1171;} }
            public TTReportField Pregnancy { get {return Footer().Pregnancy;} }
            public TTReportField NewField1191 { get {return Footer().NewField1191;} }
            public TTReportField Other { get {return Footer().Other;} }
            public TTReportField NewField11711 { get {return Footer().NewField11711;} }
            public TTReportField NewField8 { get {return Footer().NewField8;} }
            public TTReportField NewField22 { get {return Footer().NewField22;} }
            public TTReportField NewField23 { get {return Footer().NewField23;} }
            public TTReportField NewField132 { get {return Footer().NewField132;} }
            public TTReportField NewField9 { get {return Footer().NewField9;} }
            public TTReportField NewField24 { get {return Footer().NewField24;} }
            public TTReportField NewField25 { get {return Footer().NewField25;} }
            public TTReportField NewField144 { get {return Footer().NewField144;} }
            public TTReportField NewField26 { get {return Footer().NewField26;} }
            public TTReportField NewField145 { get {return Footer().NewField145;} }
            public TTReportField NewField27 { get {return Footer().NewField27;} }
            public TTReportField NewField146 { get {return Footer().NewField146;} }
            public TTReportShape NewLine5 { get {return Footer().NewLine5;} }
            public TTReportShape NewLine16 { get {return Footer().NewLine16;} }
            public TTReportShape NewLine6 { get {return Footer().NewLine6;} }
            public TTReportShape NewLine17 { get {return Footer().NewLine17;} }
            public part1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public part1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PhysiotherapyRequest.GetPatientInfoByTreatmentRequest_Class>("GetPatientInfoByTreatmentRequest", PhysiotherapyRequest.GetPatientInfoByTreatmentRequest((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.PHYSIOTHERAPYREQUEST)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new part1GroupHeader(this);
                _footer = new part1GroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class part1GroupHeader : TTReportSection
            {
                public FTRTreatmentCard MyParentReport
                {
                    get { return (FTRTreatmentCard)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NameSurname;
                public TTReportField NewField3;
                public TTReportField Age;
                public TTReportField NewField14;
                public TTReportField Sex;
                public TTReportField NewField142;
                public TTReportField NewField143;
                public TTReportField Protocol;
                public TTReportField RoomBed;
                public TTReportField NewField1242;
                public TTReportField NewField1243;
                public TTReportField StartDate2;
                public TTReportField StartDate;
                public TTReportField NewField13422;
                public TTReportField F1;
                public TTReportField Clinic;
                public TTReportField Diagnosis;
                public TTReportField NewField122431;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportField Episode; 
                public part1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 42;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 6, 294, 11, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"FTR TEDAVİ KARTI";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 15, 73, 20, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.Underline = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Adı Soyadı:";

                    NameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 20, 73, 25, false);
                    NameSurname.Name = "NameSurname";
                    NameSurname.TextFont.Bold = true;
                    NameSurname.TextFont.CharSet = 162;
                    NameSurname.Value = @"";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 15, 91, 20, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Yaş";

                    Age = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 20, 91, 25, false);
                    Age.Name = "Age";
                    Age.DrawStyle = DrawStyleConstants.vbSolid;
                    Age.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Age.TextFont.Bold = true;
                    Age.TextFont.CharSet = 162;
                    Age.Value = @"";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 15, 115, 20, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Cinsiyeti";

                    Sex = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 20, 115, 25, false);
                    Sex.Name = "Sex";
                    Sex.DrawStyle = DrawStyleConstants.vbSolid;
                    Sex.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Sex.TextFont.Bold = true;
                    Sex.TextFont.CharSet = 162;
                    Sex.Value = @"";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 15, 143, 20, false);
                    NewField142.Name = "NewField142";
                    NewField142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField142.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField142.TextFont.Bold = true;
                    NewField142.TextFont.CharSet = 162;
                    NewField142.Value = @"Protokol";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 15, 171, 20, false);
                    NewField143.Name = "NewField143";
                    NewField143.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField143.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField143.TextFont.Bold = true;
                    NewField143.TextFont.CharSet = 162;
                    NewField143.Value = @"Oda-Yatak";

                    Protocol = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 20, 143, 25, false);
                    Protocol.Name = "Protocol";
                    Protocol.DrawStyle = DrawStyleConstants.vbSolid;
                    Protocol.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Protocol.TextFont.Bold = true;
                    Protocol.TextFont.CharSet = 162;
                    Protocol.Value = @"";

                    RoomBed = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 20, 171, 25, false);
                    RoomBed.Name = "RoomBed";
                    RoomBed.DrawStyle = DrawStyleConstants.vbSolid;
                    RoomBed.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RoomBed.TextFont.Bold = true;
                    RoomBed.TextFont.CharSet = 162;
                    RoomBed.Value = @"";

                    NewField1242 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 15, 208, 20, false);
                    NewField1242.Name = "NewField1242";
                    NewField1242.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1242.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1242.TextFont.Bold = true;
                    NewField1242.TextFont.CharSet = 162;
                    NewField1242.Value = @"Düzenleme Tarihi";

                    NewField1243 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 208, 15, 246, 20, false);
                    NewField1243.Name = "NewField1243";
                    NewField1243.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1243.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1243.TextFont.Bold = true;
                    NewField1243.TextFont.CharSet = 162;
                    NewField1243.Value = @"Başlangıç Tarihi";

                    StartDate2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 20, 208, 25, false);
                    StartDate2.Name = "StartDate2";
                    StartDate2.DrawStyle = DrawStyleConstants.vbSolid;
                    StartDate2.FieldType = ReportFieldTypeEnum.ftVariable;
                    StartDate2.TextFormat = @"dd/MM/yyyy HH:mm:ss";
                    StartDate2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    StartDate2.TextFont.Bold = true;
                    StartDate2.TextFont.CharSet = 162;
                    StartDate2.Value = @"{#PHYSIOTHERAPYSTARTDATE#}";

                    StartDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 208, 20, 246, 25, false);
                    StartDate.Name = "StartDate";
                    StartDate.DrawStyle = DrawStyleConstants.vbSolid;
                    StartDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    StartDate.TextFormat = @"dd/MM/yyyy";
                    StartDate.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    StartDate.TextFont.Bold = true;
                    StartDate.TextFont.CharSet = 162;
                    StartDate.Value = @"{#PHYSIOTHERAPYSTARTDATE#}";

                    NewField13422 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 15, 294, 25, false);
                    NewField13422.Name = "NewField13422";
                    NewField13422.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13422.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13422.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13422.TextFont.Bold = true;
                    NewField13422.TextFont.CharSet = 162;
                    NewField13422.Value = @"||||||||
İşlem No";

                    F1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 25, 91, 30, false);
                    F1.Name = "F1";
                    F1.DrawStyle = DrawStyleConstants.vbSolid;
                    F1.TextFont.Bold = true;
                    F1.TextFont.Underline = true;
                    F1.TextFont.CharSet = 162;
                    F1.Value = @"Tedavinin Planladığı Polikilink/Klinik:";

                    Clinic = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 30, 91, 38, false);
                    Clinic.Name = "Clinic";
                    Clinic.TextFont.Bold = true;
                    Clinic.TextFont.CharSet = 162;
                    Clinic.Value = @"";

                    Diagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 25, 246, 38, false);
                    Diagnosis.Name = "Diagnosis";
                    Diagnosis.DrawStyle = DrawStyleConstants.vbSolid;
                    Diagnosis.Value = @"";

                    NewField122431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 25, 294, 38, false);
                    NewField122431.Name = "NewField122431";
                    NewField122431.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122431.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField122431.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122431.NoClip = EvetHayirEnum.ehEvet;
                    NewField122431.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField122431.TextFont.Bold = true;
                    NewField122431.TextFont.CharSet = 162;
                    NewField122431.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 25, 73, 25, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 20, 6, 25, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 38, 91, 38, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 29, 6, 38, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    Episode = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 317, 14, 342, 19, false);
                    Episode.Name = "Episode";
                    Episode.Visible = EvetHayirEnum.ehHayir;
                    Episode.FieldType = ReportFieldTypeEnum.ftVariable;
                    Episode.Value = @"{#EPISODE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PhysiotherapyRequest.GetPatientInfoByTreatmentRequest_Class dataset_GetPatientInfoByTreatmentRequest = ParentGroup.rsGroup.GetCurrentRecord<PhysiotherapyRequest.GetPatientInfoByTreatmentRequest_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NameSurname.CalcValue = NameSurname.Value;
                    NewField3.CalcValue = NewField3.Value;
                    Age.CalcValue = Age.Value;
                    NewField14.CalcValue = NewField14.Value;
                    Sex.CalcValue = Sex.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField143.CalcValue = NewField143.Value;
                    Protocol.CalcValue = Protocol.Value;
                    RoomBed.CalcValue = RoomBed.Value;
                    NewField1242.CalcValue = NewField1242.Value;
                    NewField1243.CalcValue = NewField1243.Value;
                    StartDate2.CalcValue = (dataset_GetPatientInfoByTreatmentRequest != null ? Globals.ToStringCore(dataset_GetPatientInfoByTreatmentRequest.PhysiotherapyStartDate) : "");
                    StartDate.CalcValue = (dataset_GetPatientInfoByTreatmentRequest != null ? Globals.ToStringCore(dataset_GetPatientInfoByTreatmentRequest.PhysiotherapyStartDate) : "");
                    NewField13422.CalcValue = NewField13422.Value;
                    F1.CalcValue = F1.Value;
                    Clinic.CalcValue = Clinic.Value;
                    Diagnosis.CalcValue = Diagnosis.Value;
                    NewField122431.CalcValue = NewField122431.Value;
                    Episode.CalcValue = (dataset_GetPatientInfoByTreatmentRequest != null ? Globals.ToStringCore(dataset_GetPatientInfoByTreatmentRequest.Episode) : "");
                    return new TTReportObject[] { NewField1,NewField2,NameSurname,NewField3,Age,NewField14,Sex,NewField142,NewField143,Protocol,RoomBed,NewField1242,NewField1243,StartDate2,StartDate,NewField13422,F1,Clinic,Diagnosis,NewField122431,Episode};
                }

                public override void RunScript()
                {
#region PART1 HEADER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            Episode episode = (Episode)objectContext.GetObject(new Guid(this.Episode.CalcValue.ToString()),"Episode");
            PhysiotherapyRequest pr = (PhysiotherapyRequest)objectContext.GetObject(new Guid(MyParentReport.RuntimeParameters.PHYSIOTHERAPYREQUEST.ToString()), "PhysiotherapyRequest");
            this.NameSurname.CalcValue = episode.Patient.Name.ToString() + " " + episode.Patient.Surname.ToString();
            this.Age.CalcValue = episode.Patient.Age.ToString();
            this.Sex.CalcValue = episode.Patient.Sex.ADI;
            this.Protocol.CalcValue = episode.HospitalProtocolNo.ToString();
            if(pr.SubEpisode.InpatientAdmission!= null && pr.SubEpisode.InpatientAdmission.Bed != null)
                this.RoomBed.CalcValue =  pr.SubEpisode.InpatientAdmission.Bed.Room.ToString() + "-" + pr.SubEpisode.InpatientAdmission.Bed.Name.ToString();
            this.Clinic.CalcValue = pr.FromResource.Name.ToString();
            string temp = "";
            DiagnosisGrid[] episodeDiagnosis = episode.Diagnosis.ToArray();
            if (episodeDiagnosis.Length > 0)
            {
                foreach (DiagnosisGrid dG in episodeDiagnosis)
                {
                    temp += dG.DiagnoseCode + "-" + dG.Diagnose.Name + ", ";
                }
                temp = temp.Remove(temp.Length - 2);
            }
            this.Diagnosis.CalcValue = temp.ToString();
#endregion PART1 HEADER_Script
                }
            }
            public partial class part1GroupFooter : TTReportSection
            {
                public FTRTreatmentCard MyParentReport
                {
                    get { return (FTRTreatmentCard)ParentReport; }
                }
                
                public TTReportField NewField5;
                public TTReportField Malignancy;
                public TTReportField NewField7;
                public TTReportField VascularDisorder;
                public TTReportField NewField17;
                public TTReportField HeartFailure;
                public TTReportField NewField19;
                public TTReportField Infection;
                public TTReportField NewField171;
                public TTReportField MetalImplant;
                public TTReportField NewField21;
                public TTReportField Stent;
                public TTReportField NewField172;
                public TTReportField Broken;
                public TTReportField NewField191;
                public TTReportField Diabetes;
                public TTReportField NewField1171;
                public TTReportField Pregnancy;
                public TTReportField NewField1191;
                public TTReportField Other;
                public TTReportField NewField11711;
                public TTReportField NewField8;
                public TTReportField NewField22;
                public TTReportField NewField23;
                public TTReportField NewField132;
                public TTReportField NewField9;
                public TTReportField NewField24;
                public TTReportField NewField25;
                public TTReportField NewField144;
                public TTReportField NewField26;
                public TTReportField NewField145;
                public TTReportField NewField27;
                public TTReportField NewField146;
                public TTReportShape NewLine5;
                public TTReportShape NewLine16;
                public TTReportShape NewLine6;
                public TTReportShape NewLine17; 
                public part1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 52;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 6, 32, 11, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Hasta Açıklama  :";

                    Malignancy = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 15, 12, 20, false);
                    Malignancy.Name = "Malignancy";
                    Malignancy.DrawStyle = DrawStyleConstants.vbSolid;
                    Malignancy.TextFont.Bold = true;
                    Malignancy.TextFont.CharSet = 162;
                    Malignancy.Value = @"";

                    NewField7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 15, 44, 20, false);
                    NewField7.Name = "NewField7";
                    NewField7.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField7.TextFont.Bold = true;
                    NewField7.TextFont.CharSet = 162;
                    NewField7.Value = @"Maliginite";

                    VascularDisorder = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 23, 12, 28, false);
                    VascularDisorder.Name = "VascularDisorder";
                    VascularDisorder.DrawStyle = DrawStyleConstants.vbSolid;
                    VascularDisorder.TextFont.Bold = true;
                    VascularDisorder.TextFont.CharSet = 162;
                    VascularDisorder.Value = @"";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 23, 44, 28, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"Dolaşım Bozukluğu";

                    HeartFailure = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 16, 73, 21, false);
                    HeartFailure.Name = "HeartFailure";
                    HeartFailure.DrawStyle = DrawStyleConstants.vbSolid;
                    HeartFailure.TextFont.Bold = true;
                    HeartFailure.TextFont.CharSet = 162;
                    HeartFailure.Value = @"";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 16, 105, 21, false);
                    NewField19.Name = "NewField19";
                    NewField19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField19.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"Kalp Yetmezliği";

                    Infection = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 68, 24, 73, 29, false);
                    Infection.Name = "Infection";
                    Infection.DrawStyle = DrawStyleConstants.vbSolid;
                    Infection.TextFont.Bold = true;
                    Infection.TextFont.CharSet = 162;
                    Infection.Value = @"";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 24, 105, 29, false);
                    NewField171.Name = "NewField171";
                    NewField171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField171.TextFont.Bold = true;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"Enfeksiyon";

                    MetalImplant = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 16, 139, 21, false);
                    MetalImplant.Name = "MetalImplant";
                    MetalImplant.DrawStyle = DrawStyleConstants.vbSolid;
                    MetalImplant.TextFont.Bold = true;
                    MetalImplant.TextFont.CharSet = 162;
                    MetalImplant.Value = @"";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 16, 171, 21, false);
                    NewField21.Name = "NewField21";
                    NewField21.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField21.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21.TextFont.Bold = true;
                    NewField21.TextFont.CharSet = 162;
                    NewField21.Value = @"Metal Implant";

                    Stent = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 24, 139, 29, false);
                    Stent.Name = "Stent";
                    Stent.DrawStyle = DrawStyleConstants.vbSolid;
                    Stent.TextFont.Bold = true;
                    Stent.TextFont.CharSet = 162;
                    Stent.Value = @"";

                    NewField172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 24, 171, 29, false);
                    NewField172.Name = "NewField172";
                    NewField172.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField172.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField172.TextFont.Bold = true;
                    NewField172.TextFont.CharSet = 162;
                    NewField172.Value = @"Stent";

                    Broken = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 16, 199, 21, false);
                    Broken.Name = "Broken";
                    Broken.DrawStyle = DrawStyleConstants.vbSolid;
                    Broken.TextFont.Bold = true;
                    Broken.TextFont.CharSet = 162;
                    Broken.Value = @"";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 16, 231, 21, false);
                    NewField191.Name = "NewField191";
                    NewField191.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField191.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField191.TextFont.Bold = true;
                    NewField191.TextFont.CharSet = 162;
                    NewField191.Value = @"Kırık";

                    Diabetes = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 194, 24, 199, 29, false);
                    Diabetes.Name = "Diabetes";
                    Diabetes.DrawStyle = DrawStyleConstants.vbSolid;
                    Diabetes.TextFont.Bold = true;
                    Diabetes.TextFont.CharSet = 162;
                    Diabetes.Value = @"";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 199, 24, 231, 29, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1171.TextFont.Bold = true;
                    NewField1171.TextFont.CharSet = 162;
                    NewField1171.Value = @"Diyabet";

                    Pregnancy = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 16, 254, 21, false);
                    Pregnancy.Name = "Pregnancy";
                    Pregnancy.DrawStyle = DrawStyleConstants.vbSolid;
                    Pregnancy.TextFont.Bold = true;
                    Pregnancy.TextFont.CharSet = 162;
                    Pregnancy.Value = @"";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 16, 286, 21, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1191.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1191.TextFont.Bold = true;
                    NewField1191.TextFont.CharSet = 162;
                    NewField1191.Value = @"Gebelik";

                    Other = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 249, 24, 254, 29, false);
                    Other.Name = "Other";
                    Other.DrawStyle = DrawStyleConstants.vbSolid;
                    Other.TextFont.Bold = true;
                    Other.TextFont.CharSet = 162;
                    Other.Value = @"";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 24, 286, 29, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11711.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11711.TextFont.Bold = true;
                    NewField11711.TextFont.CharSet = 162;
                    NewField11711.Value = @"Diğer";

                    NewField8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 31, 44, 36, false);
                    NewField8.Name = "NewField8";
                    NewField8.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField8.TextFont.Bold = true;
                    NewField8.TextFont.CharSet = 162;
                    NewField8.Value = @"Hekim      :";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 31, 164, 36, false);
                    NewField22.Name = "NewField22";
                    NewField22.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField22.Value = @"";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 31, 204, 36, false);
                    NewField23.Name = "NewField23";
                    NewField23.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField23.TextFont.Bold = true;
                    NewField23.TextFont.CharSet = 162;
                    NewField23.Value = @"Fizyoterapist/FT Teknikleri:";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 204, 31, 286, 36, false);
                    NewField132.Name = "NewField132";
                    NewField132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField132.Value = @"";

                    NewField9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 40, 24, 45, false);
                    NewField9.Name = "NewField9";
                    NewField9.Value = @"DOK.KODU:";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 40, 41, 45, false);
                    NewField24.Name = "NewField24";
                    NewField24.Value = @"";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 40, 62, 45, false);
                    NewField25.Name = "NewField25";
                    NewField25.Value = @"YAY.TRH:";

                    NewField144 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 62, 40, 79, 45, false);
                    NewField144.Name = "NewField144";
                    NewField144.Value = @"";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 40, 140, 45, false);
                    NewField26.Name = "NewField26";
                    NewField26.Value = @"REV.TRH";

                    NewField145 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 40, 157, 45, false);
                    NewField145.Name = "NewField145";
                    NewField145.Value = @"";

                    NewField27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 40, 187, 45, false);
                    NewField27.Name = "NewField27";
                    NewField27.Value = @"REV.NO";

                    NewField146 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 187, 40, 204, 45, false);
                    NewField146.Name = "NewField146";
                    NewField146.Value = @"";

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 49, 288, 49, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 4, 288, 4, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 288, 4, 288, 49, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 4, 6, 49, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PhysiotherapyRequest.GetPatientInfoByTreatmentRequest_Class dataset_GetPatientInfoByTreatmentRequest = ParentGroup.rsGroup.GetCurrentRecord<PhysiotherapyRequest.GetPatientInfoByTreatmentRequest_Class>(0);
                    NewField5.CalcValue = NewField5.Value;
                    Malignancy.CalcValue = Malignancy.Value;
                    NewField7.CalcValue = NewField7.Value;
                    VascularDisorder.CalcValue = VascularDisorder.Value;
                    NewField17.CalcValue = NewField17.Value;
                    HeartFailure.CalcValue = HeartFailure.Value;
                    NewField19.CalcValue = NewField19.Value;
                    Infection.CalcValue = Infection.Value;
                    NewField171.CalcValue = NewField171.Value;
                    MetalImplant.CalcValue = MetalImplant.Value;
                    NewField21.CalcValue = NewField21.Value;
                    Stent.CalcValue = Stent.Value;
                    NewField172.CalcValue = NewField172.Value;
                    Broken.CalcValue = Broken.Value;
                    NewField191.CalcValue = NewField191.Value;
                    Diabetes.CalcValue = Diabetes.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    Pregnancy.CalcValue = Pregnancy.Value;
                    NewField1191.CalcValue = NewField1191.Value;
                    Other.CalcValue = Other.Value;
                    NewField11711.CalcValue = NewField11711.Value;
                    NewField8.CalcValue = NewField8.Value;
                    NewField22.CalcValue = NewField22.Value;
                    NewField23.CalcValue = NewField23.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField9.CalcValue = NewField9.Value;
                    NewField24.CalcValue = NewField24.Value;
                    NewField25.CalcValue = NewField25.Value;
                    NewField144.CalcValue = NewField144.Value;
                    NewField26.CalcValue = NewField26.Value;
                    NewField145.CalcValue = NewField145.Value;
                    NewField27.CalcValue = NewField27.Value;
                    NewField146.CalcValue = NewField146.Value;
                    return new TTReportObject[] { NewField5,Malignancy,NewField7,VascularDisorder,NewField17,HeartFailure,NewField19,Infection,NewField171,MetalImplant,NewField21,Stent,NewField172,Broken,NewField191,Diabetes,NewField1171,Pregnancy,NewField1191,Other,NewField11711,NewField8,NewField22,NewField23,NewField132,NewField9,NewField24,NewField25,NewField144,NewField26,NewField145,NewField27,NewField146};
                }

                public override void RunScript()
                {
#region PART1 FOOTER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
                    Episode episode = (Episode)objectContext.GetObject(new Guid(MyParentReport.part1.Episode.CalcValue.ToString()), "Episode");
                  if(episode.Patient.MedicalInformation != null)
                    {
                      if(episode.Patient.MedicalInformation.Malignancy != null)
                    this.Malignancy.CalcValue = ((bool)episode.Patient.MedicalInformation.Malignancy) == true ? "  X" : "";
                      if(episode.Patient.MedicalInformation.Pregnancy != null)
                    this.Pregnancy.CalcValue = ((bool)episode.Patient.MedicalInformation.Pregnancy) == true ? "  X" : "";
                      if(episode.Patient.MedicalInformation.Other != null)
                    this.Other.CalcValue = ((bool)episode.Patient.MedicalInformation.Other) == true ? "  X" : "";
                      if(episode.Patient.MedicalInformation.Diabetes != null)
                    this.Diabetes.CalcValue = ((bool)episode.Patient.MedicalInformation.Diabetes) == true ? "  X" : "";
                      if(episode.Patient.MedicalInformation.Broken != null)
                    this.Broken.CalcValue = ((bool)episode.Patient.MedicalInformation.Broken) == true ? "  X" : "";
                      if(episode.Patient.MedicalInformation.MetalImplant != null)
                    this.MetalImplant.CalcValue = ((bool)episode.Patient.MedicalInformation.MetalImplant) == true ? "  X" : "";
                      if(episode.Patient.MedicalInformation.Stent != null)
                    this.Stent.CalcValue = ((bool)episode.Patient.MedicalInformation.Stent) == true ? "  X" : "";
                      if(episode.Patient.MedicalInformation.HeartFailure != null)
                    this.HeartFailure.CalcValue = ((bool)episode.Patient.MedicalInformation.HeartFailure) == true ? "  X" : "";
                      if(episode.Patient.MedicalInformation.Infection != null)
                    this.Infection.CalcValue = ((bool)episode.Patient.MedicalInformation.Infection) == true ? "  X" : "";
                      if(episode.Patient.MedicalInformation.VascularDisorder != null)
                    this.VascularDisorder.CalcValue = ((bool)episode.Patient.MedicalInformation.VascularDisorder) == true ? "  X" : "";
                    }
#endregion PART1 FOOTER_Script
                }
            }

        }

        public part1Group part1;

        public partial class part3Group : TTReportGroup
        {
            public FTRTreatmentCard MyParentReport
            {
                get { return (FTRTreatmentCard)ParentReport; }
            }

            new public part3GroupHeader Header()
            {
                return (part3GroupHeader)_header;
            }

            new public part3GroupFooter Footer()
            {
                return (part3GroupFooter)_footer;
            }

            public TTReportField UnitName { get {return Header().UnitName;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField NewField1261 { get {return Header().NewField1261;} }
            public TTReportField NewField1181 { get {return Header().NewField1181;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField102 { get {return Header().NewField102;} }
            public TTReportField NewField1361 { get {return Header().NewField1361;} }
            public TTReportField NewField1281 { get {return Header().NewField1281;} }
            public TTReportField NewField12611 { get {return Header().NewField12611;} }
            public TTReportField NewField1191 { get {return Header().NewField1191;} }
            public TTReportField NewField11621 { get {return Header().NewField11621;} }
            public TTReportField NewField11811 { get {return Header().NewField11811;} }
            public TTReportField NewField111611 { get {return Header().NewField111611;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField1461 { get {return Header().NewField1461;} }
            public TTReportField NewField1381 { get {return Header().NewField1381;} }
            public TTReportField NewField13611 { get {return Header().NewField13611;} }
            public TTReportField NewField1291 { get {return Header().NewField1291;} }
            public TTReportField NewField12621 { get {return Header().NewField12621;} }
            public TTReportField NewField12811 { get {return Header().NewField12811;} }
            public TTReportField NewField121611 { get {return Header().NewField121611;} }
            public TTReportField NewField1201 { get {return Header().NewField1201;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField11821 { get {return Header().NewField11821;} }
            public TTReportField NewField111621 { get {return Header().NewField111621;} }
            public TTReportField NewField11911 { get {return Header().NewField11911;} }
            public TTReportField NewField112611 { get {return Header().NewField112611;} }
            public TTReportField NewField111811 { get {return Header().NewField111811;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField1481 { get {return Header().NewField1481;} }
            public TTReportField NewField14611 { get {return Header().NewField14611;} }
            public TTReportField NewField1391 { get {return Header().NewField1391;} }
            public TTReportField NewField13621 { get {return Header().NewField13621;} }
            public TTReportField NewField13811 { get {return Header().NewField13811;} }
            public TTReportField NewField131611 { get {return Header().NewField131611;} }
            public TTReportField NewField1301 { get {return Header().NewField1301;} }
            public TTReportField NewField12631 { get {return Header().NewField12631;} }
            public TTReportField NewField12821 { get {return Header().NewField12821;} }
            public TTReportField NewField121621 { get {return Header().NewField121621;} }
            public TTReportField NewField12911 { get {return Header().NewField12911;} }
            public TTReportField NewField122611 { get {return Header().NewField122611;} }
            public TTReportField NewField121811 { get {return Header().NewField121811;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField NewField11641 { get {return Header().NewField11641;} }
            public TTReportField NewField1118111 { get {return Header().NewField1118111;} }
            public TTReportField NewField182 { get {return Header().NewField182;} }
            public TTReportField NewField11841 { get {return Header().NewField11841;} }
            public TTReportField NewField111641 { get {return Header().NewField111641;} }
            public TTReportField NewField11931 { get {return Header().NewField11931;} }
            public TTReportField NewField112631 { get {return Header().NewField112631;} }
            public TTReportField NewField111831 { get {return Header().NewField111831;} }
            public TTReportField NewField1116131 { get {return Header().NewField1116131;} }
            public TTReportField NewField11031 { get {return Header().NewField11031;} }
            public TTReportField NewField113621 { get {return Header().NewField113621;} }
            public TTReportField NewField112821 { get {return Header().NewField112821;} }
            public TTReportField NewField1126121 { get {return Header().NewField1126121;} }
            public TTReportField NewField152 { get {return Header().NewField152;} }
            public TTReportField DiagnosisUnit { get {return Header().DiagnosisUnit;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public part3Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public part3Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PhysiotherapyOrder.GetExistingPhysiotherapyUnits_Class>("GetExistingPhysiotherapyUnits", PhysiotherapyOrder.GetExistingPhysiotherapyUnits((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.PHYSIOTHERAPYREQUEST)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new part3GroupHeader(this);
                _footer = new part3GroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class part3GroupHeader : TTReportSection
            {
                public FTRTreatmentCard MyParentReport
                {
                    get { return (FTRTreatmentCard)ParentReport; }
                }
                
                public TTReportField UnitName;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField15;
                public TTReportField NewField161;
                public TTReportField NewField181;
                public TTReportField NewField1161;
                public TTReportField NewField191;
                public TTReportField NewField1261;
                public TTReportField NewField1181;
                public TTReportField NewField16;
                public TTReportField NewField102;
                public TTReportField NewField1361;
                public TTReportField NewField1281;
                public TTReportField NewField12611;
                public TTReportField NewField1191;
                public TTReportField NewField11621;
                public TTReportField NewField11811;
                public TTReportField NewField111611;
                public TTReportField NewField112;
                public TTReportField NewField1461;
                public TTReportField NewField1381;
                public TTReportField NewField13611;
                public TTReportField NewField1291;
                public TTReportField NewField12621;
                public TTReportField NewField12811;
                public TTReportField NewField121611;
                public TTReportField NewField1201;
                public TTReportField NewField17;
                public TTReportField NewField11821;
                public TTReportField NewField111621;
                public TTReportField NewField11911;
                public TTReportField NewField112611;
                public TTReportField NewField111811;
                public TTReportField NewField18;
                public TTReportField NewField1481;
                public TTReportField NewField14611;
                public TTReportField NewField1391;
                public TTReportField NewField13621;
                public TTReportField NewField13811;
                public TTReportField NewField131611;
                public TTReportField NewField1301;
                public TTReportField NewField12631;
                public TTReportField NewField12821;
                public TTReportField NewField121621;
                public TTReportField NewField12911;
                public TTReportField NewField122611;
                public TTReportField NewField121811;
                public TTReportField NewField19;
                public TTReportField NewField1211;
                public TTReportField NewField11641;
                public TTReportField NewField1118111;
                public TTReportField NewField182;
                public TTReportField NewField11841;
                public TTReportField NewField111641;
                public TTReportField NewField11931;
                public TTReportField NewField112631;
                public TTReportField NewField111831;
                public TTReportField NewField1116131;
                public TTReportField NewField11031;
                public TTReportField NewField113621;
                public TTReportField NewField112821;
                public TTReportField NewField1126121;
                public TTReportField NewField152;
                public TTReportField DiagnosisUnit;
                public TTReportShape NewLine1; 
                public part3GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 33;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    UnitName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 2, 70, 7, false);
                    UnitName.Name = "UnitName";
                    UnitName.FillColor = System.Drawing.Color.Silver;
                    UnitName.DrawStyle = DrawStyleConstants.vbSolid;
                    UnitName.FieldType = ReportFieldTypeEnum.ftVariable;
                    UnitName.TextFont.Bold = true;
                    UnitName.TextFont.CharSet = 162;
                    UnitName.Value = @"{#NAME#}";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 9, 65, 24, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Hastanın Hikayesi ve Önemli Bulgular:";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 24, 31, 29, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"TEDAVİLER";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 24, 41, 29, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"SÜRE";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 24, 50, 29, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"DOZ";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 24, 65, 29, false);
                    NewField151.Name = "NewField151";
                    NewField151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"BÖLGE";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 9, 72, 24, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15.Value = @"";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 24, 72, 29, false);
                    NewField161.Name = "NewField161";
                    NewField161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField161.Value = @"1";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 9, 79, 24, false);
                    NewField181.Name = "NewField181";
                    NewField181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField181.Value = @"";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 24, 79, 29, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1161.Value = @"2";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 9, 86, 24, false);
                    NewField191.Name = "NewField191";
                    NewField191.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField191.Value = @"";

                    NewField1261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 24, 86, 29, false);
                    NewField1261.Name = "NewField1261";
                    NewField1261.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1261.Value = @"3";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 9, 94, 24, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1181.Value = @"";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 24, 94, 29, false);
                    NewField16.Name = "NewField16";
                    NewField16.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16.Value = @"4";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 9, 101, 24, false);
                    NewField102.Name = "NewField102";
                    NewField102.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField102.Value = @"";

                    NewField1361 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 24, 101, 29, false);
                    NewField1361.Name = "NewField1361";
                    NewField1361.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1361.Value = @"5";

                    NewField1281 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 9, 108, 24, false);
                    NewField1281.Name = "NewField1281";
                    NewField1281.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1281.Value = @"";

                    NewField12611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 24, 108, 29, false);
                    NewField12611.Name = "NewField12611";
                    NewField12611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12611.Value = @"6";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 9, 115, 24, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1191.Value = @"";

                    NewField11621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 24, 115, 29, false);
                    NewField11621.Name = "NewField11621";
                    NewField11621.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11621.Value = @"7";

                    NewField11811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 9, 122, 24, false);
                    NewField11811.Name = "NewField11811";
                    NewField11811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11811.Value = @"";

                    NewField111611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 24, 122, 29, false);
                    NewField111611.Name = "NewField111611";
                    NewField111611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111611.Value = @"8";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 9, 129, 24, false);
                    NewField112.Name = "NewField112";
                    NewField112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112.Value = @"";

                    NewField1461 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 24, 129, 29, false);
                    NewField1461.Name = "NewField1461";
                    NewField1461.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1461.Value = @"9";

                    NewField1381 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 9, 136, 24, false);
                    NewField1381.Name = "NewField1381";
                    NewField1381.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1381.Value = @"";

                    NewField13611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 24, 136, 29, false);
                    NewField13611.Name = "NewField13611";
                    NewField13611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13611.Value = @"10";

                    NewField1291 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 9, 143, 24, false);
                    NewField1291.Name = "NewField1291";
                    NewField1291.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1291.Value = @"";

                    NewField12621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 24, 143, 29, false);
                    NewField12621.Name = "NewField12621";
                    NewField12621.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12621.Value = @"11";

                    NewField12811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 9, 150, 24, false);
                    NewField12811.Name = "NewField12811";
                    NewField12811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12811.Value = @"";

                    NewField121611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 24, 150, 29, false);
                    NewField121611.Name = "NewField121611";
                    NewField121611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121611.Value = @"12";

                    NewField1201 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 9, 158, 24, false);
                    NewField1201.Name = "NewField1201";
                    NewField1201.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1201.Value = @"";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 24, 158, 29, false);
                    NewField17.Name = "NewField17";
                    NewField17.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17.Value = @"13";

                    NewField11821 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 9, 166, 24, false);
                    NewField11821.Name = "NewField11821";
                    NewField11821.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11821.Value = @"";

                    NewField111621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 24, 166, 29, false);
                    NewField111621.Name = "NewField111621";
                    NewField111621.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111621.Value = @"14";

                    NewField11911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 9, 174, 24, false);
                    NewField11911.Name = "NewField11911";
                    NewField11911.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11911.Value = @"";

                    NewField112611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 24, 174, 29, false);
                    NewField112611.Name = "NewField112611";
                    NewField112611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112611.Value = @"15";

                    NewField111811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 9, 182, 24, false);
                    NewField111811.Name = "NewField111811";
                    NewField111811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111811.Value = @"";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 24, 182, 29, false);
                    NewField18.Name = "NewField18";
                    NewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18.Value = @"16";

                    NewField1481 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 9, 190, 24, false);
                    NewField1481.Name = "NewField1481";
                    NewField1481.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1481.Value = @"";

                    NewField14611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 24, 190, 29, false);
                    NewField14611.Name = "NewField14611";
                    NewField14611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14611.Value = @"17";

                    NewField1391 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 9, 198, 24, false);
                    NewField1391.Name = "NewField1391";
                    NewField1391.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1391.Value = @"";

                    NewField13621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 24, 198, 29, false);
                    NewField13621.Name = "NewField13621";
                    NewField13621.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13621.Value = @"18";

                    NewField13811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 198, 9, 206, 24, false);
                    NewField13811.Name = "NewField13811";
                    NewField13811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13811.Value = @"";

                    NewField131611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 198, 24, 206, 29, false);
                    NewField131611.Name = "NewField131611";
                    NewField131611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131611.Value = @"19";

                    NewField1301 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 9, 214, 24, false);
                    NewField1301.Name = "NewField1301";
                    NewField1301.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1301.Value = @"";

                    NewField12631 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 24, 214, 29, false);
                    NewField12631.Name = "NewField12631";
                    NewField12631.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12631.Value = @"20";

                    NewField12821 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 9, 222, 24, false);
                    NewField12821.Name = "NewField12821";
                    NewField12821.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12821.Value = @"";

                    NewField121621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 24, 222, 29, false);
                    NewField121621.Name = "NewField121621";
                    NewField121621.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121621.Value = @"21";

                    NewField12911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 9, 230, 24, false);
                    NewField12911.Name = "NewField12911";
                    NewField12911.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12911.Value = @"";

                    NewField122611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 24, 230, 29, false);
                    NewField122611.Name = "NewField122611";
                    NewField122611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122611.Value = @"22";

                    NewField121811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 9, 238, 24, false);
                    NewField121811.Name = "NewField121811";
                    NewField121811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121811.Value = @"";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 24, 238, 29, false);
                    NewField19.Name = "NewField19";
                    NewField19.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField19.Value = @"23";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 9, 246, 24, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211.Value = @"";

                    NewField11641 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 24, 246, 29, false);
                    NewField11641.Name = "NewField11641";
                    NewField11641.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11641.Value = @"24";

                    NewField1118111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 9, 254, 24, false);
                    NewField1118111.Name = "NewField1118111";
                    NewField1118111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1118111.Value = @"";

                    NewField182 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 24, 254, 29, false);
                    NewField182.Name = "NewField182";
                    NewField182.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField182.Value = @"25";

                    NewField11841 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 9, 262, 24, false);
                    NewField11841.Name = "NewField11841";
                    NewField11841.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11841.Value = @"";

                    NewField111641 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 24, 262, 29, false);
                    NewField111641.Name = "NewField111641";
                    NewField111641.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111641.Value = @"26";

                    NewField11931 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 262, 9, 270, 24, false);
                    NewField11931.Name = "NewField11931";
                    NewField11931.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11931.Value = @"";

                    NewField112631 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 262, 24, 270, 29, false);
                    NewField112631.Name = "NewField112631";
                    NewField112631.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112631.Value = @"27";

                    NewField111831 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 270, 9, 278, 24, false);
                    NewField111831.Name = "NewField111831";
                    NewField111831.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111831.Value = @"";

                    NewField1116131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 270, 24, 278, 29, false);
                    NewField1116131.Name = "NewField1116131";
                    NewField1116131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1116131.Value = @"28";

                    NewField11031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 278, 9, 286, 24, false);
                    NewField11031.Name = "NewField11031";
                    NewField11031.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11031.Value = @"";

                    NewField113621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 278, 24, 286, 29, false);
                    NewField113621.Name = "NewField113621";
                    NewField113621.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113621.Value = @"29";

                    NewField112821 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 286, 9, 294, 24, false);
                    NewField112821.Name = "NewField112821";
                    NewField112821.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112821.Value = @"";

                    NewField1126121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 286, 24, 294, 29, false);
                    NewField1126121.Name = "NewField1126121";
                    NewField1126121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1126121.Value = @"30";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 10, 65, 24, false);
                    NewField152.Name = "NewField152";
                    NewField152.FontAngle = 900;
                    NewField152.VertAlign = VerticalAlignmentEnum.vaBottom;
                    NewField152.TextFont.Bold = true;
                    NewField152.TextFont.CharSet = 162;
                    NewField152.Value = @"TARİH";

                    DiagnosisUnit = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 305, 12, 330, 17, false);
                    DiagnosisUnit.Name = "DiagnosisUnit";
                    DiagnosisUnit.Visible = EvetHayirEnum.ehHayir;
                    DiagnosisUnit.FieldType = ReportFieldTypeEnum.ftVariable;
                    DiagnosisUnit.Value = @"{#TREATMENTDIAGNOSISUNIT#}";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 60, 9, 60, 24, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PhysiotherapyOrder.GetExistingPhysiotherapyUnits_Class dataset_GetExistingPhysiotherapyUnits = ParentGroup.rsGroup.GetCurrentRecord<PhysiotherapyOrder.GetExistingPhysiotherapyUnits_Class>(0);
                    UnitName.CalcValue = (dataset_GetExistingPhysiotherapyUnits != null ? Globals.ToStringCore(dataset_GetExistingPhysiotherapyUnits.Name) : "");
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField181.CalcValue = NewField181.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField191.CalcValue = NewField191.Value;
                    NewField1261.CalcValue = NewField1261.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField102.CalcValue = NewField102.Value;
                    NewField1361.CalcValue = NewField1361.Value;
                    NewField1281.CalcValue = NewField1281.Value;
                    NewField12611.CalcValue = NewField12611.Value;
                    NewField1191.CalcValue = NewField1191.Value;
                    NewField11621.CalcValue = NewField11621.Value;
                    NewField11811.CalcValue = NewField11811.Value;
                    NewField111611.CalcValue = NewField111611.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField1461.CalcValue = NewField1461.Value;
                    NewField1381.CalcValue = NewField1381.Value;
                    NewField13611.CalcValue = NewField13611.Value;
                    NewField1291.CalcValue = NewField1291.Value;
                    NewField12621.CalcValue = NewField12621.Value;
                    NewField12811.CalcValue = NewField12811.Value;
                    NewField121611.CalcValue = NewField121611.Value;
                    NewField1201.CalcValue = NewField1201.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField11821.CalcValue = NewField11821.Value;
                    NewField111621.CalcValue = NewField111621.Value;
                    NewField11911.CalcValue = NewField11911.Value;
                    NewField112611.CalcValue = NewField112611.Value;
                    NewField111811.CalcValue = NewField111811.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField1481.CalcValue = NewField1481.Value;
                    NewField14611.CalcValue = NewField14611.Value;
                    NewField1391.CalcValue = NewField1391.Value;
                    NewField13621.CalcValue = NewField13621.Value;
                    NewField13811.CalcValue = NewField13811.Value;
                    NewField131611.CalcValue = NewField131611.Value;
                    NewField1301.CalcValue = NewField1301.Value;
                    NewField12631.CalcValue = NewField12631.Value;
                    NewField12821.CalcValue = NewField12821.Value;
                    NewField121621.CalcValue = NewField121621.Value;
                    NewField12911.CalcValue = NewField12911.Value;
                    NewField122611.CalcValue = NewField122611.Value;
                    NewField121811.CalcValue = NewField121811.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField1211.CalcValue = NewField1211.Value;
                    NewField11641.CalcValue = NewField11641.Value;
                    NewField1118111.CalcValue = NewField1118111.Value;
                    NewField182.CalcValue = NewField182.Value;
                    NewField11841.CalcValue = NewField11841.Value;
                    NewField111641.CalcValue = NewField111641.Value;
                    NewField11931.CalcValue = NewField11931.Value;
                    NewField112631.CalcValue = NewField112631.Value;
                    NewField111831.CalcValue = NewField111831.Value;
                    NewField1116131.CalcValue = NewField1116131.Value;
                    NewField11031.CalcValue = NewField11031.Value;
                    NewField113621.CalcValue = NewField113621.Value;
                    NewField112821.CalcValue = NewField112821.Value;
                    NewField1126121.CalcValue = NewField1126121.Value;
                    NewField152.CalcValue = NewField152.Value;
                    DiagnosisUnit.CalcValue = (dataset_GetExistingPhysiotherapyUnits != null ? Globals.ToStringCore(dataset_GetExistingPhysiotherapyUnits.TreatmentDiagnosisUnit) : "");
                    return new TTReportObject[] { UnitName,NewField12,NewField13,NewField131,NewField141,NewField151,NewField15,NewField161,NewField181,NewField1161,NewField191,NewField1261,NewField1181,NewField16,NewField102,NewField1361,NewField1281,NewField12611,NewField1191,NewField11621,NewField11811,NewField111611,NewField112,NewField1461,NewField1381,NewField13611,NewField1291,NewField12621,NewField12811,NewField121611,NewField1201,NewField17,NewField11821,NewField111621,NewField11911,NewField112611,NewField111811,NewField18,NewField1481,NewField14611,NewField1391,NewField13621,NewField13811,NewField131611,NewField1301,NewField12631,NewField12821,NewField121621,NewField12911,NewField122611,NewField121811,NewField19,NewField1211,NewField11641,NewField1118111,NewField182,NewField11841,NewField111641,NewField11931,NewField112631,NewField111831,NewField1116131,NewField11031,NewField113621,NewField112821,NewField1126121,NewField152,DiagnosisUnit};
                }
            }
            public partial class part3GroupFooter : TTReportSection
            {
                public FTRTreatmentCard MyParentReport
                {
                    get { return (FTRTreatmentCard)ParentReport; }
                }
                
                public TTReportField NewField1; 
                public part3GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 4;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 2, 39, 3, false);
                    NewField1.Name = "NewField1";
                    NewField1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PhysiotherapyOrder.GetExistingPhysiotherapyUnits_Class dataset_GetExistingPhysiotherapyUnits = ParentGroup.rsGroup.GetCurrentRecord<PhysiotherapyOrder.GetExistingPhysiotherapyUnits_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { NewField1};
                }
            }

        }

        public part3Group part3;

        public partial class MAINGroup : TTReportGroup
        {
            public FTRTreatmentCard MyParentReport
            {
                get { return (FTRTreatmentCard)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ProcedureObject { get {return Body().ProcedureObject;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportField NewField1151 { get {return Body().NewField1151;} }
            public TTReportField NewField11811 { get {return Body().NewField11811;} }
            public TTReportField NewField11911 { get {return Body().NewField11911;} }
            public TTReportField NewField111811 { get {return Body().NewField111811;} }
            public TTReportField NewField11021 { get {return Body().NewField11021;} }
            public TTReportField NewField112811 { get {return Body().NewField112811;} }
            public TTReportField NewField111911 { get {return Body().NewField111911;} }
            public TTReportField NewField1118111 { get {return Body().NewField1118111;} }
            public TTReportField NewField11121 { get {return Body().NewField11121;} }
            public TTReportField NewField113811 { get {return Body().NewField113811;} }
            public TTReportField NewField112911 { get {return Body().NewField112911;} }
            public TTReportField NewField1128111 { get {return Body().NewField1128111;} }
            public TTReportField NewField112011 { get {return Body().NewField112011;} }
            public TTReportField NewField1118211 { get {return Body().NewField1118211;} }
            public TTReportField NewField1119111 { get {return Body().NewField1119111;} }
            public TTReportField NewField11118111 { get {return Body().NewField11118111;} }
            public TTReportField NewField114811 { get {return Body().NewField114811;} }
            public TTReportField NewField113911 { get {return Body().NewField113911;} }
            public TTReportField NewField1138111 { get {return Body().NewField1138111;} }
            public TTReportField NewField113011 { get {return Body().NewField113011;} }
            public TTReportField NewField1128211 { get {return Body().NewField1128211;} }
            public TTReportField NewField1129111 { get {return Body().NewField1129111;} }
            public TTReportField NewField11218111 { get {return Body().NewField11218111;} }
            public TTReportField NewField112111 { get {return Body().NewField112111;} }
            public TTReportField NewField111181111 { get {return Body().NewField111181111;} }
            public TTReportField NewField1118411 { get {return Body().NewField1118411;} }
            public TTReportField NewField1119311 { get {return Body().NewField1119311;} }
            public TTReportField NewField11118311 { get {return Body().NewField11118311;} }
            public TTReportField NewField1110311 { get {return Body().NewField1110311;} }
            public TTReportField NewField11128211 { get {return Body().NewField11128211;} }
            public TTReportField PhysiotherapyOrderName1 { get {return Body().PhysiotherapyOrderName1;} }
            public TTReportField Duration1 { get {return Body().Duration1;} }
            public TTReportField Dose1 { get {return Body().Dose1;} }
            public TTReportField ApplicationArea1 { get {return Body().ApplicationArea1;} }
            public TTReportField DoseInfo1 { get {return Body().DoseInfo1;} }
            public TTReportField AppliedAreaInfo1 { get {return Body().AppliedAreaInfo1;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
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
                list[0] = new TTReportNqlData<PhysiotherapyOrder.GetPhysiotherapyOrdersByUnitAndRequest_Class>("GetPhysiotherapyOrdersByUnitAndRequest", PhysiotherapyOrder.GetPhysiotherapyOrdersByUnitAndRequest((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.PHYSIOTHERAPYREQUEST),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.part3.DiagnosisUnit.CalcValue)));
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
                public FTRTreatmentCard MyParentReport
                {
                    get { return (FTRTreatmentCard)ParentReport; }
                }
                
                public TTReportField ProcedureObject;
                public TTReportShape NewLine11;
                public TTReportField NewField1151;
                public TTReportField NewField11811;
                public TTReportField NewField11911;
                public TTReportField NewField111811;
                public TTReportField NewField11021;
                public TTReportField NewField112811;
                public TTReportField NewField111911;
                public TTReportField NewField1118111;
                public TTReportField NewField11121;
                public TTReportField NewField113811;
                public TTReportField NewField112911;
                public TTReportField NewField1128111;
                public TTReportField NewField112011;
                public TTReportField NewField1118211;
                public TTReportField NewField1119111;
                public TTReportField NewField11118111;
                public TTReportField NewField114811;
                public TTReportField NewField113911;
                public TTReportField NewField1138111;
                public TTReportField NewField113011;
                public TTReportField NewField1128211;
                public TTReportField NewField1129111;
                public TTReportField NewField11218111;
                public TTReportField NewField112111;
                public TTReportField NewField111181111;
                public TTReportField NewField1118411;
                public TTReportField NewField1119311;
                public TTReportField NewField11118311;
                public TTReportField NewField1110311;
                public TTReportField NewField11128211;
                public TTReportField PhysiotherapyOrderName1;
                public TTReportField Duration1;
                public TTReportField Dose1;
                public TTReportField ApplicationArea1;
                public TTReportField DoseInfo1;
                public TTReportField AppliedAreaInfo1;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 14;
                    RepeatCount = 0;
                    
                    ProcedureObject = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 314, 7, 339, 12, false);
                    ProcedureObject.Name = "ProcedureObject";
                    ProcedureObject.Visible = EvetHayirEnum.ehHayir;
                    ProcedureObject.FieldType = ReportFieldTypeEnum.ftVariable;
                    ProcedureObject.Value = @"{#OBJECTID#}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 0, 65, 0, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 0, 72, 14, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1151.Value = @"";

                    NewField11811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 0, 79, 14, false);
                    NewField11811.Name = "NewField11811";
                    NewField11811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11811.Value = @"";

                    NewField11911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 0, 86, 14, false);
                    NewField11911.Name = "NewField11911";
                    NewField11911.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11911.Value = @"";

                    NewField111811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 0, 94, 14, false);
                    NewField111811.Name = "NewField111811";
                    NewField111811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111811.Value = @"";

                    NewField11021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 0, 101, 14, false);
                    NewField11021.Name = "NewField11021";
                    NewField11021.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11021.Value = @"";

                    NewField112811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 0, 108, 14, false);
                    NewField112811.Name = "NewField112811";
                    NewField112811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112811.Value = @"";

                    NewField111911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 0, 115, 14, false);
                    NewField111911.Name = "NewField111911";
                    NewField111911.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111911.Value = @"";

                    NewField1118111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 115, 0, 122, 14, false);
                    NewField1118111.Name = "NewField1118111";
                    NewField1118111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1118111.Value = @"";

                    NewField11121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 122, 0, 129, 14, false);
                    NewField11121.Name = "NewField11121";
                    NewField11121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11121.Value = @"";

                    NewField113811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 0, 136, 14, false);
                    NewField113811.Name = "NewField113811";
                    NewField113811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113811.Value = @"";

                    NewField112911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 0, 143, 14, false);
                    NewField112911.Name = "NewField112911";
                    NewField112911.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112911.Value = @"";

                    NewField1128111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 0, 150, 14, false);
                    NewField1128111.Name = "NewField1128111";
                    NewField1128111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1128111.Value = @"";

                    NewField112011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 0, 158, 14, false);
                    NewField112011.Name = "NewField112011";
                    NewField112011.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112011.Value = @"";

                    NewField1118211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 158, 0, 166, 14, false);
                    NewField1118211.Name = "NewField1118211";
                    NewField1118211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1118211.Value = @"";

                    NewField1119111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 0, 174, 14, false);
                    NewField1119111.Name = "NewField1119111";
                    NewField1119111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1119111.Value = @"";

                    NewField11118111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 0, 182, 14, false);
                    NewField11118111.Name = "NewField11118111";
                    NewField11118111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11118111.Value = @"";

                    NewField114811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 0, 190, 14, false);
                    NewField114811.Name = "NewField114811";
                    NewField114811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114811.Value = @"";

                    NewField113911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 0, 198, 14, false);
                    NewField113911.Name = "NewField113911";
                    NewField113911.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113911.Value = @"";

                    NewField1138111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 198, 0, 206, 14, false);
                    NewField1138111.Name = "NewField1138111";
                    NewField1138111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1138111.Value = @"";

                    NewField113011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 0, 214, 14, false);
                    NewField113011.Name = "NewField113011";
                    NewField113011.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113011.Value = @"";

                    NewField1128211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 0, 222, 14, false);
                    NewField1128211.Name = "NewField1128211";
                    NewField1128211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1128211.Value = @"";

                    NewField1129111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 0, 230, 14, false);
                    NewField1129111.Name = "NewField1129111";
                    NewField1129111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1129111.Value = @"";

                    NewField11218111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 230, 0, 238, 14, false);
                    NewField11218111.Name = "NewField11218111";
                    NewField11218111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11218111.Value = @"";

                    NewField112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 0, 246, 14, false);
                    NewField112111.Name = "NewField112111";
                    NewField112111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112111.Value = @"";

                    NewField111181111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 246, 0, 254, 14, false);
                    NewField111181111.Name = "NewField111181111";
                    NewField111181111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111181111.Value = @"";

                    NewField1118411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 254, 0, 262, 14, false);
                    NewField1118411.Name = "NewField1118411";
                    NewField1118411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1118411.Value = @"";

                    NewField1119311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 262, 0, 270, 14, false);
                    NewField1119311.Name = "NewField1119311";
                    NewField1119311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1119311.Value = @"";

                    NewField11118311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 270, 0, 278, 14, false);
                    NewField11118311.Name = "NewField11118311";
                    NewField11118311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11118311.Value = @"";

                    NewField1110311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 278, 0, 286, 14, false);
                    NewField1110311.Name = "NewField1110311";
                    NewField1110311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1110311.Value = @"";

                    NewField11128211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 286, 0, 294, 14, false);
                    NewField11128211.Name = "NewField11128211";
                    NewField11128211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11128211.Value = @"";

                    PhysiotherapyOrderName1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 31, 5, false);
                    PhysiotherapyOrderName1.Name = "PhysiotherapyOrderName1";
                    PhysiotherapyOrderName1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PhysiotherapyOrderName1.TextFont.Size = 5;
                    PhysiotherapyOrderName1.TextFont.CharSet = 162;
                    PhysiotherapyOrderName1.Value = @"{#CODE#}  {#NAME#}";

                    Duration1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 31, 1, 41, 5, false);
                    Duration1.Name = "Duration1";
                    Duration1.FieldType = ReportFieldTypeEnum.ftVariable;
                    Duration1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Duration1.TextFont.Name = "Arial";
                    Duration1.TextFont.Size = 6;
                    Duration1.TextFont.CharSet = 162;
                    Duration1.Value = @"{#DURATION#} DK";

                    Dose1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 1, 50, 5, false);
                    Dose1.Name = "Dose1";
                    Dose1.FieldType = ReportFieldTypeEnum.ftVariable;
                    Dose1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Dose1.TextFont.Name = "Arial";
                    Dose1.TextFont.Size = 6;
                    Dose1.TextFont.CharSet = 162;
                    Dose1.Value = @"{#DOSE#}";

                    ApplicationArea1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 1, 64, 5, false);
                    ApplicationArea1.Name = "ApplicationArea1";
                    ApplicationArea1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ApplicationArea1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ApplicationArea1.TextFont.Name = "Arial";
                    ApplicationArea1.TextFont.Size = 6;
                    ApplicationArea1.TextFont.CharSet = 162;
                    ApplicationArea1.Value = @"{#UYGULANANBOLGE#}";

                    DoseInfo1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 5, 64, 10, false);
                    DoseInfo1.Name = "DoseInfo1";
                    DoseInfo1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DoseInfo1.MultiLine = EvetHayirEnum.ehEvet;
                    DoseInfo1.NoClip = EvetHayirEnum.ehEvet;
                    DoseInfo1.WordBreak = EvetHayirEnum.ehEvet;
                    DoseInfo1.ExpandTabs = EvetHayirEnum.ehEvet;
                    DoseInfo1.TextFont.Size = 5;
                    DoseInfo1.TextFont.Bold = true;
                    DoseInfo1.TextFont.CharSet = 162;
                    DoseInfo1.Value = @"Doz Açk.: {#DOSEDURATIONINFO#}";

                    AppliedAreaInfo1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 10, 64, 13, false);
                    AppliedAreaInfo1.Name = "AppliedAreaInfo1";
                    AppliedAreaInfo1.FieldType = ReportFieldTypeEnum.ftVariable;
                    AppliedAreaInfo1.TextFont.Size = 5;
                    AppliedAreaInfo1.TextFont.Bold = true;
                    AppliedAreaInfo1.TextFont.CharSet = 162;
                    AppliedAreaInfo1.Value = @"Bölg. Açk.:  {#APPLICATIONAREA#}";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 0, 6, 14, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 6, 14, 65, 14, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PhysiotherapyOrder.GetPhysiotherapyOrdersByUnitAndRequest_Class dataset_GetPhysiotherapyOrdersByUnitAndRequest = ParentGroup.rsGroup.GetCurrentRecord<PhysiotherapyOrder.GetPhysiotherapyOrdersByUnitAndRequest_Class>(0);
                    ProcedureObject.CalcValue = (dataset_GetPhysiotherapyOrdersByUnitAndRequest != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrdersByUnitAndRequest.ObjectID) : "");
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField11811.CalcValue = NewField11811.Value;
                    NewField11911.CalcValue = NewField11911.Value;
                    NewField111811.CalcValue = NewField111811.Value;
                    NewField11021.CalcValue = NewField11021.Value;
                    NewField112811.CalcValue = NewField112811.Value;
                    NewField111911.CalcValue = NewField111911.Value;
                    NewField1118111.CalcValue = NewField1118111.Value;
                    NewField11121.CalcValue = NewField11121.Value;
                    NewField113811.CalcValue = NewField113811.Value;
                    NewField112911.CalcValue = NewField112911.Value;
                    NewField1128111.CalcValue = NewField1128111.Value;
                    NewField112011.CalcValue = NewField112011.Value;
                    NewField1118211.CalcValue = NewField1118211.Value;
                    NewField1119111.CalcValue = NewField1119111.Value;
                    NewField11118111.CalcValue = NewField11118111.Value;
                    NewField114811.CalcValue = NewField114811.Value;
                    NewField113911.CalcValue = NewField113911.Value;
                    NewField1138111.CalcValue = NewField1138111.Value;
                    NewField113011.CalcValue = NewField113011.Value;
                    NewField1128211.CalcValue = NewField1128211.Value;
                    NewField1129111.CalcValue = NewField1129111.Value;
                    NewField11218111.CalcValue = NewField11218111.Value;
                    NewField112111.CalcValue = NewField112111.Value;
                    NewField111181111.CalcValue = NewField111181111.Value;
                    NewField1118411.CalcValue = NewField1118411.Value;
                    NewField1119311.CalcValue = NewField1119311.Value;
                    NewField11118311.CalcValue = NewField11118311.Value;
                    NewField1110311.CalcValue = NewField1110311.Value;
                    NewField11128211.CalcValue = NewField11128211.Value;
                    PhysiotherapyOrderName1.CalcValue = (dataset_GetPhysiotherapyOrdersByUnitAndRequest != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrdersByUnitAndRequest.Code) : "") + @"  " + (dataset_GetPhysiotherapyOrdersByUnitAndRequest != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrdersByUnitAndRequest.Name) : "");
                    Duration1.CalcValue = (dataset_GetPhysiotherapyOrdersByUnitAndRequest != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrdersByUnitAndRequest.Duration) : "") + @" DK";
                    Dose1.CalcValue = (dataset_GetPhysiotherapyOrdersByUnitAndRequest != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrdersByUnitAndRequest.Dose) : "");
                    ApplicationArea1.CalcValue = (dataset_GetPhysiotherapyOrdersByUnitAndRequest != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrdersByUnitAndRequest.Uygulananbolge) : "");
                    DoseInfo1.CalcValue = @"Doz Açk.: " + (dataset_GetPhysiotherapyOrdersByUnitAndRequest != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrdersByUnitAndRequest.DoseDurationInfo) : "");
                    AppliedAreaInfo1.CalcValue = @"Bölg. Açk.:  " + (dataset_GetPhysiotherapyOrdersByUnitAndRequest != null ? Globals.ToStringCore(dataset_GetPhysiotherapyOrdersByUnitAndRequest.ApplicationArea) : "");
                    return new TTReportObject[] { ProcedureObject,NewField1151,NewField11811,NewField11911,NewField111811,NewField11021,NewField112811,NewField111911,NewField1118111,NewField11121,NewField113811,NewField112911,NewField1128111,NewField112011,NewField1118211,NewField1119111,NewField11118111,NewField114811,NewField113911,NewField1138111,NewField113011,NewField1128211,NewField1129111,NewField11218111,NewField112111,NewField111181111,NewField1118411,NewField1119311,NewField11118311,NewField1110311,NewField11128211,PhysiotherapyOrderName1,Duration1,Dose1,ApplicationArea1,DoseInfo1,AppliedAreaInfo1};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public FTRTreatmentCard()
        {
            part2 = new part2Group(this,"part2");
            part1 = new part1Group(part2,"part1");
            part3 = new part3Group(part1,"part3");
            MAIN = new MAINGroup(part3,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("PHYSIOTHERAPYREQUEST", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("PHYSIOTHERAPYREQUEST"))
                _runtimeParameters.PHYSIOTHERAPYREQUEST = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["PHYSIOTHERAPYREQUEST"]);
            Name = "FTRTREATMENTCARD";
            Caption = "FTR Tedavi Kartı";
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