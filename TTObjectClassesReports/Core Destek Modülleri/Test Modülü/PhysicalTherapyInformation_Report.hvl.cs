
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
    public partial class PhysicalTherapyInformation : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string PHYSIOTHERAPYREQUEST = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PART1Group : TTReportGroup
        {
            public PhysicalTherapyInformation MyParentReport
            {
                get { return (PhysicalTherapyInformation)ParentReport; }
            }

            new public PART1GroupHeader Header()
            {
                return (PART1GroupHeader)_header;
            }

            new public PART1GroupFooter Footer()
            {
                return (PART1GroupFooter)_footer;
            }

            public TTReportField HospitalInfo1 { get {return Header().HospitalInfo1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField NewField16 { get {return Footer().NewField16;} }
            public TTReportField NewField162 { get {return Footer().NewField162;} }
            public TTReportField NewField1261 { get {return Footer().NewField1261;} }
            public TTReportField NewField11621 { get {return Footer().NewField11621;} }
            public PART1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PART1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PART1GroupHeader(this);
                _footer = new PART1GroupFooter(this);

            }

            public partial class PART1GroupHeader : TTReportSection
            {
                public PhysicalTherapyInformation MyParentReport
                {
                    get { return (PhysicalTherapyInformation)ParentReport; }
                }
                
                public TTReportField HospitalInfo1;
                public TTReportField NewField11;
                public TTReportField LOGO; 
                public PART1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 43;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HospitalInfo1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 6, 181, 29, false);
                    HospitalInfo1.Name = "HospitalInfo1";
                    HospitalInfo1.FieldType = ReportFieldTypeEnum.ftExpression;
                    HospitalInfo1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HospitalInfo1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HospitalInfo1.MultiLine = EvetHayirEnum.ehEvet;
                    HospitalInfo1.WordBreak = EvetHayirEnum.ehEvet;
                    HospitalInfo1.ExpandTabs = EvetHayirEnum.ehEvet;
                    HospitalInfo1.TextFont.Size = 11;
                    HospitalInfo1.TextFont.Bold = true;
                    HospitalInfo1.TextFont.CharSet = 162;
                    HospitalInfo1.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 30, 177, 42, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"FİZİK TEDAVİ VE REHABİLİTASYON UYGULAMALARI HASTA
BİLGİLENDİRME VE RIZA BELGESİ";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 12, 34, 35, false);
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
                    NewField11.CalcValue = NewField11.Value;
                    LOGO.CalcValue = @"";
                    HospitalInfo1.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { NewField11,LOGO,HospitalInfo1};
                }

                public override void RunScript()
                {
#region PART1 HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion PART1 HEADER_Script
                }
            }
            public partial class PART1GroupFooter : TTReportSection
            {
                public PhysicalTherapyInformation MyParentReport
                {
                    get { return (PhysicalTherapyInformation)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField16;
                public TTReportField NewField162;
                public TTReportField NewField1261;
                public TTReportField NewField11621; 
                public PART1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 12;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 4, 43, 9, false);
                    NewField1.Name = "NewField1";
                    NewField1.Value = @"DOK KODU:HD.RB.15";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 4, 84, 9, false);
                    NewField16.Name = "NewField16";
                    NewField16.Value = @"YAY. TRH: 01.10.2016";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 4, 126, 9, false);
                    NewField162.Name = "NewField162";
                    NewField162.Value = @"REV. TRH: 11.02.2019";

                    NewField1261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 4, 168, 9, false);
                    NewField1261.Name = "NewField1261";
                    NewField1261.Value = @"REV. NO: 02";

                    NewField11621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 4, 207, 9, false);
                    NewField11621.Name = "NewField11621";
                    NewField11621.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField11621.Value = @"Sayfa Sayısı: {@pagenumber@} / {@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField162.CalcValue = NewField162.Value;
                    NewField1261.CalcValue = NewField1261.Value;
                    NewField11621.CalcValue = @"Sayfa Sayısı: " + ParentReport.CurrentPageNumber.ToString() + @" / " + ParentReport.ReportTotalPageCount;
                    return new TTReportObject[] { NewField1,NewField16,NewField162,NewField1261,NewField11621};
                }
            }

        }

        public PART1Group PART1;

        public partial class Main1Group : TTReportGroup
        {
            public PhysicalTherapyInformation MyParentReport
            {
                get { return (PhysicalTherapyInformation)ParentReport; }
            }

            new public Main1GroupBody Body()
            {
                return (Main1GroupBody)_body;
            }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField NewField1131 { get {return Body().NewField1131;} }
            public TTReportField NewField1141 { get {return Body().NewField1141;} }
            public TTReportField NameSurname { get {return Body().NameSurname;} }
            public TTReportField FatherNameAge { get {return Body().FatherNameAge;} }
            public TTReportField ProtocolNo { get {return Body().ProtocolNo;} }
            public TTReportField Diagnosis { get {return Body().Diagnosis;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField171 { get {return Body().NewField171;} }
            public TTReportField NewField1321 { get {return Body().NewField1321;} }
            public TTReportField NewField1151 { get {return Body().NewField1151;} }
            public TTReportField NewField11211 { get {return Body().NewField11211;} }
            public TTReportField NewField1161 { get {return Body().NewField1161;} }
            public TTReportField NewField11221 { get {return Body().NewField11221;} }
            public Main1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Main1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new Main1GroupBody(this);
            }

            public partial class Main1GroupBody : TTReportSection
            {
                public PhysicalTherapyInformation MyParentReport
                {
                    get { return (PhysicalTherapyInformation)ParentReport; }
                }
                
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField1121;
                public TTReportField NewField1131;
                public TTReportField NewField1141;
                public TTReportField NameSurname;
                public TTReportField FatherNameAge;
                public TTReportField ProtocolNo;
                public TTReportField Diagnosis;
                public TTReportField NewField13;
                public TTReportField NewField171;
                public TTReportField NewField1321;
                public TTReportField NewField1151;
                public TTReportField NewField11211;
                public TTReportField NewField1161;
                public TTReportField NewField11221; 
                public Main1GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 53;
                    RepeatCount = 0;
                    
                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 2, 48, 7, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Hastanın Adı Soyadı";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 8, 48, 13, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Baba Adı/Yaşı";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 14, 48, 19, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Protokol No";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 20, 48, 25, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"Tanı";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 2, 50, 7, false);
                    NewField151.Name = "NewField151";
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @":";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 8, 50, 13, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @":";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 14, 50, 19, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @":";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 48, 20, 50, 37, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @":";

                    NameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 2, 82, 7, false);
                    NameSurname.Name = "NameSurname";
                    NameSurname.MultiLine = EvetHayirEnum.ehEvet;
                    NameSurname.WordBreak = EvetHayirEnum.ehEvet;
                    NameSurname.ExpandTabs = EvetHayirEnum.ehEvet;
                    NameSurname.TextFont.Bold = true;
                    NameSurname.TextFont.CharSet = 162;
                    NameSurname.Value = @"";

                    FatherNameAge = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 8, 82, 13, false);
                    FatherNameAge.Name = "FatherNameAge";
                    FatherNameAge.MultiLine = EvetHayirEnum.ehEvet;
                    FatherNameAge.WordBreak = EvetHayirEnum.ehEvet;
                    FatherNameAge.ExpandTabs = EvetHayirEnum.ehEvet;
                    FatherNameAge.TextFont.Bold = true;
                    FatherNameAge.TextFont.CharSet = 162;
                    FatherNameAge.Value = @"";

                    ProtocolNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 14, 82, 19, false);
                    ProtocolNo.Name = "ProtocolNo";
                    ProtocolNo.MultiLine = EvetHayirEnum.ehEvet;
                    ProtocolNo.WordBreak = EvetHayirEnum.ehEvet;
                    ProtocolNo.ExpandTabs = EvetHayirEnum.ehEvet;
                    ProtocolNo.TextFont.Bold = true;
                    ProtocolNo.TextFont.CharSet = 162;
                    ProtocolNo.Value = @"";

                    Diagnosis = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 20, 138, 37, false);
                    Diagnosis.Name = "Diagnosis";
                    Diagnosis.MultiLine = EvetHayirEnum.ehEvet;
                    Diagnosis.WordBreak = EvetHayirEnum.ehEvet;
                    Diagnosis.ExpandTabs = EvetHayirEnum.ehEvet;
                    Diagnosis.TextFont.Bold = true;
                    Diagnosis.TextFont.CharSet = 162;
                    Diagnosis.Value = @"";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 2, 200, 17, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13.Value = @"";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 40, 73, 45, false);
                    NewField171.Name = "NewField171";
                    NewField171.TextFont.Bold = true;
                    NewField171.TextFont.CharSet = 162;
                    NewField171.Value = @"Hastaya Uygulanacak Tıbbi İşlemler";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 46, 73, 51, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.TextFont.Bold = true;
                    NewField1321.TextFont.CharSet = 162;
                    NewField1321.Value = @"Tıbbı İşlemin Uygulanacağı Yer";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 40, 75, 45, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.TextFont.Bold = true;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @":";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 46, 75, 51, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @":";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 40, 138, 45, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1161.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1161.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 76, 46, 139, 51, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11221.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @"XXXXXXmiz FTR üniteleri ve servisleri";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NameSurname.CalcValue = NameSurname.Value;
                    FatherNameAge.CalcValue = FatherNameAge.Value;
                    ProtocolNo.CalcValue = ProtocolNo.Value;
                    Diagnosis.CalcValue = Diagnosis.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    return new TTReportObject[] { NewField12,NewField121,NewField131,NewField141,NewField151,NewField1121,NewField1131,NewField1141,NameSurname,FatherNameAge,ProtocolNo,Diagnosis,NewField13,NewField171,NewField1321,NewField1151,NewField11211,NewField1161,NewField11221};
                }

                public override void RunScript()
                {
#region MAIN1 BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true); 
            PhysiotherapyRequest pr = (PhysiotherapyRequest)objectContext.GetObject(new Guid(MyParentReport.RuntimeParameters.PHYSIOTHERAPYREQUEST.ToString()), "PhysiotherapyRequest");
            this.NameSurname.CalcValue = pr.Episode.Patient.Name.ToString() + " " + pr.Episode.Patient.Surname.ToString();
            this.FatherNameAge.CalcValue = pr.Episode.Patient.FatherName.ToString();
            this.ProtocolNo.CalcValue = pr.Episode.HospitalProtocolNo.ToString();
            string temp = "";
            DiagnosisGrid[] episodeDiagnosis = pr.Episode.Diagnosis.ToArray();
            if (episodeDiagnosis.Length > 0)
            {
                foreach (DiagnosisGrid dG in episodeDiagnosis)
                {
                    temp += dG.DiagnoseCode + "-" + dG.Diagnose.Name + ", ";
                }
                temp = temp.Remove(temp.Length - 2);
            }
            this.Diagnosis.CalcValue = temp.ToString();
#endregion MAIN1 BODY_Script
                }
            }

        }

        public Main1Group Main1;

        public partial class MAINGroup : TTReportGroup
        {
            public PhysicalTherapyInformation MyParentReport
            {
                get { return (PhysicalTherapyInformation)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
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
                public PhysicalTherapyInformation MyParentReport
                {
                    get { return (PhysicalTherapyInformation)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 57;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 2, 49, 7, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 12;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Değerli Hastamız,";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 8, 203, 26, false);
                    NewField2.Name = "NewField2";
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.NoClip = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Size = 12;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @">	Bu belge bilgilendirme ve aydınlatılmış onam haklarınızdan yararlanabilmenizi amaçlamaktadır.
>	Size uygulanabilecek tanı veya tedavi amaçlı girişimler ve bu girişimlerin yararları ve muhtemel zararları konusunda anlayabileceğiniz şekilde bilgi alma hakkınız vardır.
>	Yazılı bildirmek koşulu ile bilgi almama yada sizin yerinize güvendiğiniz bir kimsenin bilgilendirilmesini talep etme hakkına sahipsiniz.
>	Sağlık durumunuz ve size uygulanabilecek tanı veya tedavi amaçlı girişimler konusunda bilgilendirildikten sonra bu tanı veya tedavi amaçlı girişimlerden birini seçerek size uygulanmasını kabul edebilirsiniz.
>	Karar  verebilmek için uygun zaman talep edebilirsiniz.
>	Size önerilen tanı veya teşhis amaçlı girişimleri kabul etmediğinizi yazılı bir belge ile bildirmeniz gerekmektedir.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    return new TTReportObject[] { NewField1,NewField2};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class Main3Group : TTReportGroup
        {
            public PhysicalTherapyInformation MyParentReport
            {
                get { return (PhysicalTherapyInformation)ParentReport; }
            }

            new public Main3GroupBody Body()
            {
                return (Main3GroupBody)_body;
            }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public Main3Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Main3Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new Main3GroupBody(this);
            }

            public partial class Main3GroupBody : TTReportSection
            {
                public PhysicalTherapyInformation MyParentReport
                {
                    get { return (PhysicalTherapyInformation)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField NewField121; 
                public Main3GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 36;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 5, 82, 10, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Size = 12;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Fiziksel Tıp ve Rehabilitasyon Servisi'nde;";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 14, 203, 32, false);
                    NewField121.Name = "NewField121";
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.NoClip = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Size = 12;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @">	Tüm kas-iskelet sistemi hastalıklarının,
>	Tüm romatizmal hastalıkların,
>	Ağrılı durumların,
>	Sinir sıkışmalarının,
>	Beyin-omurilik ve periferik sinir felçlerinin,
>	İnme ve serebral palsi,
>	Eklem sertliği ve katılığı, hareket kısıtlılığı,
>	Spastisite,
>	Kırık ve travma gibi durumlarının erken veya uzun dönem tanısı, tedavisi ve takibi yapılmaktadır.
>	Ayrıca tıbbi (medikal ilaçla) ve cerrahi (ameliyatla) tedavisi mümkün olmayan diğer bir çok hastalıkta fizik tedavi ajanları ve rehabilitasyon uygulamaları ile tedavi yaklaşımları yapılmaktadır.
>	Fiziksel Tıp ve rehabilitasyon uygulamaları tıbbi ve cerrahi tedaviler yetersiz-etkisiz-gereksiz ise, hastalığın müzminleşme ve ilerleme ihtimali varsa, günlük yaşantı olumsuz etkileniyorsa veya sakatlık gelişmişse yararlı ve gerekli olabilir.
>	Hastalığınızın durumuna göre size uygun bir fizik tedavi programı ilaç ve fizik tedavi ajanlarının uygulanması ve terapötik egzersizlerden birini veya birkaçını içerebilir.
>	Oral ve parenteral ilaç uygulamaları yapılabilir. Uygulama yerinde hematom(kan birikmesi) , ekimoz (morarma) gibi lokal komplikasyonlar ve/veya  kas güçsüzlüğü duyu kaybı gelişebilir. Her türlü ilaç uygulamasında alerjik reaksiyon (tepki) riski  vardır.
>	Oral veya parenteral ilaç uygulanmadan önce kronik bir hastalığının, alerjiniz, kullanmakta olduğunuz ilaçlar ve  (bayan hastalar için) gebelik olup olmadığı hakkında hekim ve hemşirenize bilgi vermeniz gerekmektedir.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    return new TTReportObject[] { NewField111,NewField121};
                }
            }

        }

        public Main3Group Main3;

        public partial class Main4Group : TTReportGroup
        {
            public PhysicalTherapyInformation MyParentReport
            {
                get { return (PhysicalTherapyInformation)ParentReport; }
            }

            new public Main4GroupBody Body()
            {
                return (Main4GroupBody)_body;
            }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public Main4Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Main4Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new Main4GroupBody(this);
            }

            public partial class Main4GroupBody : TTReportSection
            {
                public PhysicalTherapyInformation MyParentReport
                {
                    get { return (PhysicalTherapyInformation)ParentReport; }
                }
                
                public TTReportField NewField1111;
                public TTReportField NewField1121; 
                public Main4GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 50;
                    RepeatCount = 0;
                    
                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 4, 63, 9, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.TextFont.Size = 12;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"Size uygulanacak fizik tedavi;";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 11, 203, 29, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.NoClip = EvetHayirEnum.ehEvet;
                    NewField1121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Size = 12;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @">	Yüzeyel soğuk uygulamaları (soğuk paket),
>	Yüzeyel sıcak(infraruj,sıcak paket, parafin, girdap banyosu, fluidoterapi)uygulamaları, 
>	Derin ısı (ultrason, kısa dalga diatermi, radar)uygulamaları,
>	Elektroterapi (TENS, elektrostimülasyon, vakum,-enterferans, diadinami, galvanik-faradik akım), 
>	Hidroterapi (kontrast banyo, kaplıca tedavisi, su altı masaj, elektrogalvanik banyo, girdap banyosu, kelebek banyo)
>	Mekanoterapi (ayakta dik konumlandırma cihazı / masası, traksiyon, pnömatik kompresyon),
>	Lazer uygulaması,
>	Magnetoterapi mobilizasyon ve manipülasyon uygulamaları ,
>	Hasta sağlığı için önemli olan yaşam tarzı önerileri,
>	Tedavi edici egzersiz uygulamaları ,
>	Yardımcı cihaz (splint, breys, korse, bandaj, baston v.s. destekleri),
>	Robotik Rehabilitasyon (alt ve üst extremite ) uygulamaları,
>	Fizik tedavi yöntemlerinden biri veya bir kaçını içerebilir.
Fiziksel tıp ve rehabilitasyon uygulamaları tıbbi ve cerrahi yöntemlerle tedavi edilemeyen bir çok hastalıkta ve kronik ağrılı durumlarda, fonksiyonel kısıtlılıkta etkili bir tedaviye olanak sağlar.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    return new TTReportObject[] { NewField1111,NewField1121};
                }
            }

        }

        public Main4Group Main4;

        public partial class Main5Group : TTReportGroup
        {
            public PhysicalTherapyInformation MyParentReport
            {
                get { return (PhysicalTherapyInformation)ParentReport; }
            }

            new public Main5GroupBody Body()
            {
                return (Main5GroupBody)_body;
            }
            public TTReportField NewField11111 { get {return Body().NewField11111;} }
            public TTReportField NewField11211 { get {return Body().NewField11211;} }
            public Main5Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Main5Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new Main5GroupBody(this);
            }

            public partial class Main5GroupBody : TTReportSection
            {
                public PhysicalTherapyInformation MyParentReport
                {
                    get { return (PhysicalTherapyInformation)ParentReport; }
                }
                
                public TTReportField NewField11111;
                public TTReportField NewField11211; 
                public Main5GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 39;
                    RepeatCount = 0;
                    
                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 4, 63, 9, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.TextFont.Size = 12;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Faydaları;";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 12, 203, 30, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11211.NoClip = EvetHayirEnum.ehEvet;
                    NewField11211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11211.TextFont.Size = 12;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @">	Ucuz olması,
>	Ağrı, uyuşukluk, karıncalanma, güçsüzlüğün azalması ve geçmesi, 
>	Fonksiyonların artması,
>	Yan etkisinin nadir olması,
>	Bir çok durumda gereksiz tıbbi ve cerrahi tedavileri engellemesi,
>	Daha az ilaç kullanılmasını sağlaması,
>	İlaçla ve ameliyatla tedavisi mümkün olmayan diğer birçok hastalırta etkin teavi sağlaması,
>	Hastalıkların kronikleşmesini (müzminleşmesini) ve ilerlemesini engellemesi,
>	Hayat kalitesini arttırmasıdır.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField11211.CalcValue = NewField11211.Value;
                    return new TTReportObject[] { NewField11111,NewField11211};
                }
            }

        }

        public Main5Group Main5;

        public partial class Main6Group : TTReportGroup
        {
            public PhysicalTherapyInformation MyParentReport
            {
                get { return (PhysicalTherapyInformation)ParentReport; }
            }

            new public Main6GroupBody Body()
            {
                return (Main6GroupBody)_body;
            }
            public TTReportField NewField111111 { get {return Body().NewField111111;} }
            public TTReportField NewField1112111 { get {return Body().NewField1112111;} }
            public Main6Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Main6Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new Main6GroupBody(this);
            }

            public partial class Main6GroupBody : TTReportSection
            {
                public PhysicalTherapyInformation MyParentReport
                {
                    get { return (PhysicalTherapyInformation)ParentReport; }
                }
                
                public TTReportField NewField111111;
                public TTReportField NewField1112111; 
                public Main6GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 50;
                    RepeatCount = 0;
                    
                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 4, 63, 9, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.TextFont.Size = 12;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"Olası Riskleri ve Yan etkileri;";

                    NewField1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 11, 203, 29, false);
                    NewField1112111.Name = "NewField1112111";
                    NewField1112111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1112111.NoClip = EvetHayirEnum.ehEvet;
                    NewField1112111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1112111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1112111.TextFont.Size = 12;
                    NewField1112111.TextFont.CharSet = 162;
                    NewField1112111.Value = @">	Yan etki ve riskleri oldukça az olan tedavi yaklaşımlarıdır. Bununla birlikte, nadir de olsa cilt kızarıklıkları, hassasiyet gibi istenmeyen etkiler görülebilir. Ağrılarınız başlangıçta artabilir, ancak burum uzun sürerse lütfen doktorunuzla görüşünüz.
>	Çok daha nadir görülen önemli riskler cilt yanıkları, kalp ritm bozuklukları, ciltte aşırı duyarlılık, kan basıncı  değişiklikleri, eklem kısıtlılıklarının açılması sırasında kas-tendon hasarlanması-kopması, kemik kırılması, elektrik çarpmasıdır. Bu komplikasyonlar nedeni ile ölüm ihtimali vardır.
>	Riskler uygun teknik, yeterli tıbbi malzeme ve deneyimli tıbbi personel varlığında nadiren görülmektedir.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField1112111.CalcValue = NewField1112111.Value;
                    return new TTReportObject[] { NewField111111,NewField1112111};
                }
            }

        }

        public Main6Group Main6;

        public partial class Main6u1Group : TTReportGroup
        {
            public PhysicalTherapyInformation MyParentReport
            {
                get { return (PhysicalTherapyInformation)ParentReport; }
            }

            new public Main6u1GroupBody Body()
            {
                return (Main6u1GroupBody)_body;
            }
            public TTReportField NewField11112111 { get {return Body().NewField11112111;} }
            public Main6u1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Main6u1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new Main6u1GroupBody(this);
            }

            public partial class Main6u1GroupBody : TTReportSection
            {
                public PhysicalTherapyInformation MyParentReport
                {
                    get { return (PhysicalTherapyInformation)ParentReport; }
                }
                
                public TTReportField NewField11112111; 
                public Main6u1GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 21;
                    RepeatCount = 0;
                    
                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 1, 203, 19, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11112111.NoClip = EvetHayirEnum.ehEvet;
                    NewField11112111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11112111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11112111.TextFont.Size = 12;
                    NewField11112111.TextFont.Bold = true;
                    NewField11112111.TextFont.CharSet = 162;
                    NewField11112111.Value = @">	Bu durumların görülme sıklığını en aza indirmek için uygulama öncesi tıbbi durumunuz hakkında doktorunuza detaylı bilgi vermelisiniz.

->	Hamilelik, 
->	Kalp pili varlığı,
->	Vücutta metal cisim varlığı (protez vb.)
->	Kadınlar için menstrüasyon kanama dönemi,
->	Bilinen tümör, enfeksiyon veya allerji varlığı,
->	Bilinen ateşli veya bulaşıcı hastalıklar (hepatit, AİDS, tüberküloz gibi),
->	Diyabet, tansiyon gibi metabolik hastalıklar,
->	Hareketli diş protezi varlığı
Durumlarında lütfen doktorunuza ve/veya terapistinize mutlaka bilgi veriniz. Böyle durumlarda kendi iyiliğiniz için tedaviniz sonlandırılacak veya tekrar gözden geçirilecektir.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11112111.CalcValue = NewField11112111.Value;
                    return new TTReportObject[] { NewField11112111};
                }
            }

        }

        public Main6u1Group Main6u1;

        public partial class Main7Group : TTReportGroup
        {
            public PhysicalTherapyInformation MyParentReport
            {
                get { return (PhysicalTherapyInformation)ParentReport; }
            }

            new public Main7GroupBody Body()
            {
                return (Main7GroupBody)_body;
            }
            public TTReportField NewField1111111 { get {return Body().NewField1111111;} }
            public TTReportField NewField11112111 { get {return Body().NewField11112111;} }
            public Main7Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Main7Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new Main7GroupBody(this);
            }

            public partial class Main7GroupBody : TTReportSection
            {
                public PhysicalTherapyInformation MyParentReport
                {
                    get { return (PhysicalTherapyInformation)ParentReport; }
                }
                
                public TTReportField NewField1111111;
                public TTReportField NewField11112111; 
                public Main7GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 34;
                    RepeatCount = 0;
                    
                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 4, 63, 9, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.TextFont.Size = 12;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"Alternatif Tedavi Yaklaşımları;";

                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 11, 203, 29, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11112111.NoClip = EvetHayirEnum.ehEvet;
                    NewField11112111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11112111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11112111.TextFont.Size = 12;
                    NewField11112111.TextFont.CharSet = 162;
                    NewField11112111.Value = @">	Bu hastalığın tedavisi için çeşitli ilaç tedavilerinin ve fizik tedavi yöntemlerinin, bazı durumlarda cerrahi yaklaşımların tedaviye alternatif oluşturması söz konusudur.
>	Bu hastalıkların tamamı multidisipliner (bir çok kliniği ilgilendiren) hastalıklardır. Tanı, tedavi ve takipleri sırasında gerekli olduğunda diğer ilgili servislerden de tıbbi destek alınmaktadır. Öte yandan, tedavi sırasında aynı şikayet nedeni ile XXXXXXmiz doktorlarının bilgisi dışında alternatif yöntemlerin denenmesi (akupunktur, bel çekme, refleksoloji, biyoenerji, hacamat gibi) kesinlikle önerilmemektedir.
>	Önerilen tedavi yönteminin kabul edilmediği durumlarda uygun tedavi yapılamamasına bağlı sağlığınızdaki bozukluğun, ağrı ve fonksiyon kayıplarınızın devam etmesi veya ilerlemesi söz konusu olabilir.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1111111.CalcValue = NewField1111111.Value;
                    NewField11112111.CalcValue = NewField11112111.Value;
                    return new TTReportObject[] { NewField1111111,NewField11112111};
                }
            }

        }

        public Main7Group Main7;

        public partial class Main8Group : TTReportGroup
        {
            public PhysicalTherapyInformation MyParentReport
            {
                get { return (PhysicalTherapyInformation)ParentReport; }
            }

            new public Main8GroupBody Body()
            {
                return (Main8GroupBody)_body;
            }
            public TTReportField NewField11111111 { get {return Body().NewField11111111;} }
            public TTReportField NewField111121111 { get {return Body().NewField111121111;} }
            public Main8Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Main8Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new Main8GroupBody(this);
            }

            public partial class Main8GroupBody : TTReportSection
            {
                public PhysicalTherapyInformation MyParentReport
                {
                    get { return (PhysicalTherapyInformation)ParentReport; }
                }
                
                public TTReportField NewField11111111;
                public TTReportField NewField111121111; 
                public Main8GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 38;
                    RepeatCount = 0;
                    
                    NewField11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 3, 63, 8, false);
                    NewField11111111.Name = "NewField11111111";
                    NewField11111111.TextFont.Size = 12;
                    NewField11111111.TextFont.Bold = true;
                    NewField11111111.TextFont.CharSet = 162;
                    NewField11111111.Value = @"İdari Uyarılar;";

                    NewField111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 10, 203, 28, false);
                    NewField111121111.Name = "NewField111121111";
                    NewField111121111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111121111.NoClip = EvetHayirEnum.ehEvet;
                    NewField111121111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111121111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111121111.TextFont.Size = 12;
                    NewField111121111.TextFont.Bold = true;
                    NewField111121111.TextFont.CharSet = 162;
                    NewField111121111.Value = @"->	Size ait tüm tıbbi ve kimlik bilgileriniz gizli tutulacaktır. Etik kurullar ve resmi makamlar gerektiğinde tıbbi bilgilerinize ulaşabilir. Siz de istediğinizde kendinize ait tıbbi bilgilerinize ulaşabilirsiniz.
->	XXXXXXmiz doktorlarının tedavi programınız öncesinde veya devam ederken sizin daha etkin ve güvenliği olarak tedavinizi sağlama adına tedavi programınızda değişiklik yapma hakkı mevcuttur.
->	Sosyal Güvenlik Kurumu?nun (SGK) kuralları gereği  (beş) iş gününden fazla tedaviye ara verip, bu durumu doktorunuza bildirip tedavi iptalini gerçekleştirmediğiniz sürece tedavinizin otomatik olarak sonlandırılacağını ve sonrasında SGK tedavi bölge uygulaması kurallarında belirtilen sürelerde hak kaybınız olacağını bilgilerinize sunarız.
->	SGK kuralları gereği ayaktan fizik tedavi uygulamaları günde tek seans olarak ödenmektedir. Lütfen aynı program içinde farklı bölge uygulamaları için ısrar etmeyiniz.
->	Hastaların hakları olduğu gibi çalışan hakları da mevcuttur. Bu kapsamda hiçbir sağlık çalışanı ile sözlü veya fiziki tartışmaya girmeyiniz. Bu tür davranışlar ?BEYAZ KOD? uygulaması çerçevesinde değerlendirilip hakkınızda hukuki işlem başlatılacaktır. Herhangi şikayetinizi lütfen doktorunuza veya Hasta Hakları birimine iletiniz.
->	SGK kuralları gereği tedaviye günlük girdiğinize dair imza alınması zorunludur.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11111111.CalcValue = NewField11111111.Value;
                    NewField111121111.CalcValue = NewField111121111.Value;
                    return new TTReportObject[] { NewField11111111,NewField111121111};
                }
            }

        }

        public Main8Group Main8;

        public partial class Main9Group : TTReportGroup
        {
            public PhysicalTherapyInformation MyParentReport
            {
                get { return (PhysicalTherapyInformation)ParentReport; }
            }

            new public Main9GroupBody Body()
            {
                return (Main9GroupBody)_body;
            }
            public TTReportField NewField111111111 { get {return Body().NewField111111111;} }
            public TTReportField NewField111121111 { get {return Body().NewField111121111;} }
            public TTReportField NewField1111121111 { get {return Body().NewField1111121111;} }
            public TTReportField NewField1111121112 { get {return Body().NewField1111121112;} }
            public TTReportField NewField1111121113 { get {return Body().NewField1111121113;} }
            public TTReportField NewField111121112 { get {return Body().NewField111121112;} }
            public TTReportField NewField1211121111 { get {return Body().NewField1211121111;} }
            public TTReportField NewField1211121112 { get {return Body().NewField1211121112;} }
            public TTReportField NewField1211121113 { get {return Body().NewField1211121113;} }
            public TTReportField NewField11111111 { get {return Body().NewField11111111;} }
            public TTReportField NewField111121113 { get {return Body().NewField111121113;} }
            public Main9Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Main9Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new Main9GroupBody(this);
            }

            public partial class Main9GroupBody : TTReportSection
            {
                public PhysicalTherapyInformation MyParentReport
                {
                    get { return (PhysicalTherapyInformation)ParentReport; }
                }
                
                public TTReportField NewField111111111;
                public TTReportField NewField111121111;
                public TTReportField NewField1111121111;
                public TTReportField NewField1111121112;
                public TTReportField NewField1111121113;
                public TTReportField NewField111121112;
                public TTReportField NewField1211121111;
                public TTReportField NewField1211121112;
                public TTReportField NewField1211121113;
                public TTReportField NewField11111111;
                public TTReportField NewField111121113; 
                public Main9GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 83;
                    RepeatCount = 0;
                    
                    NewField111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 2, 100, 9, false);
                    NewField111111111.Name = "NewField111111111";
                    NewField111111111.TextFont.Size = 12;
                    NewField111111111.TextFont.Bold = true;
                    NewField111111111.TextFont.Underline = true;
                    NewField111111111.TextFont.CharSet = 162;
                    NewField111111111.Value = @"Yukarıdaki konularla ilgili bilgilendirilmeme ek olarak:";

                    NewField111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 9, 13, 15, false);
                    NewField111121111.Name = "NewField111121111";
                    NewField111121111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111121111.NoClip = EvetHayirEnum.ehEvet;
                    NewField111121111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111121111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111121111.TextFont.Size = 12;
                    NewField111121111.TextFont.CharSet = 162;
                    NewField111121111.Value = @">";

                    NewField1111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 17, 13, 23, false);
                    NewField1111121111.Name = "NewField1111121111";
                    NewField1111121111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111121111.NoClip = EvetHayirEnum.ehEvet;
                    NewField1111121111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111121111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1111121111.TextFont.Size = 12;
                    NewField1111121111.TextFont.CharSet = 162;
                    NewField1111121111.Value = @">";

                    NewField1111121112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 25, 13, 31, false);
                    NewField1111121112.Name = "NewField1111121112";
                    NewField1111121112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111121112.NoClip = EvetHayirEnum.ehEvet;
                    NewField1111121112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111121112.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1111121112.TextFont.Size = 12;
                    NewField1111121112.TextFont.CharSet = 162;
                    NewField1111121112.Value = @">";

                    NewField1111121113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 33, 13, 39, false);
                    NewField1111121113.Name = "NewField1111121113";
                    NewField1111121113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111121113.NoClip = EvetHayirEnum.ehEvet;
                    NewField1111121113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111121113.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1111121113.TextFont.Size = 12;
                    NewField1111121113.TextFont.CharSet = 162;
                    NewField1111121113.Value = @">";

                    NewField111121112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 9, 203, 15, false);
                    NewField111121112.Name = "NewField111121112";
                    NewField111121112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111121112.NoClip = EvetHayirEnum.ehEvet;
                    NewField111121112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111121112.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111121112.TextFont.Size = 12;
                    NewField111121112.TextFont.Underline = true;
                    NewField111121112.TextFont.CharSet = 162;
                    NewField111121112.Value = @"Uygulanabilecek tanı yöntemleri konusunda ek sorular sorabileceğim ve bunların da cevaplanabileceği konusunda,";

                    NewField1211121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 17, 203, 23, false);
                    NewField1211121111.Name = "NewField1211121111";
                    NewField1211121111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211121111.NoClip = EvetHayirEnum.ehEvet;
                    NewField1211121111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1211121111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1211121111.TextFont.Size = 12;
                    NewField1211121111.TextFont.Underline = true;
                    NewField1211121111.TextFont.CharSet = 162;
                    NewField1211121111.Value = @"Tanı yöntemine karar vermeden uygun bir süre düşünebileceğim konusunda,";

                    NewField1211121112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 25, 203, 31, false);
                    NewField1211121112.Name = "NewField1211121112";
                    NewField1211121112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211121112.NoClip = EvetHayirEnum.ehEvet;
                    NewField1211121112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1211121112.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1211121112.TextFont.Size = 12;
                    NewField1211121112.TextFont.Underline = true;
                    NewField1211121112.TextFont.CharSet = 162;
                    NewField1211121112.Value = @"Önerilen tanı yöntemleri arasından seçim yapabileceğim konusunda,";

                    NewField1211121113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 33, 203, 39, false);
                    NewField1211121113.Name = "NewField1211121113";
                    NewField1211121113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1211121113.NoClip = EvetHayirEnum.ehEvet;
                    NewField1211121113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1211121113.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1211121113.TextFont.Size = 12;
                    NewField1211121113.TextFont.Underline = true;
                    NewField1211121113.TextFont.CharSet = 162;
                    NewField1211121113.Value = @"Ayrıca, kabul edip imzalasam bile istediğim zaman onamımı geri çekme hakkının bende saklı olduğu konusunda ";

                    NewField11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 42, 139, 47, false);
                    NewField11111111.Name = "NewField11111111";
                    NewField11111111.TextFont.Size = 12;
                    NewField11111111.TextFont.Bold = true;
                    NewField11111111.TextFont.CharSet = 162;
                    NewField11111111.Value = @"Anlayabileceğim bir şekilde sözlü/yazılı olarak bilgilendirildim.";

                    NewField111121113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 57, 203, 75, false);
                    NewField111121113.Name = "NewField111121113";
                    NewField111121113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111121113.NoClip = EvetHayirEnum.ehEvet;
                    NewField111121113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111121113.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111121113.TextFont.Size = 12;
                    NewField111121113.TextFont.CharSet = 162;
                    NewField111121113.Value = @"Bu formu kendim okuduğumu veya yakınlarımın bana okuduğunu bildirir, bana sorularımı sormak ve kararımı vermek için yeterli süre tanındığını beyan ederim. 
Bu belgede yazılı olanlar ve sorularıma aldığım cevaplar ile bana, sağlığım ve yapılacak uygulamalar hakkında yeterli ve tatmin edici bilgilerin verildiğine inanıyor, hiçbir baskı altında kalmadan, kendi özgür irademle bu formu imzalamak suretiyle onay veriyorum.
İmzam, bu bilgileri okuduğumun ve anladığımın kanıtıdır.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111111111.CalcValue = NewField111111111.Value;
                    NewField111121111.CalcValue = NewField111121111.Value;
                    NewField1111121111.CalcValue = NewField1111121111.Value;
                    NewField1111121112.CalcValue = NewField1111121112.Value;
                    NewField1111121113.CalcValue = NewField1111121113.Value;
                    NewField111121112.CalcValue = NewField111121112.Value;
                    NewField1211121111.CalcValue = NewField1211121111.Value;
                    NewField1211121112.CalcValue = NewField1211121112.Value;
                    NewField1211121113.CalcValue = NewField1211121113.Value;
                    NewField11111111.CalcValue = NewField11111111.Value;
                    NewField111121113.CalcValue = NewField111121113.Value;
                    return new TTReportObject[] { NewField111111111,NewField111121111,NewField1111121111,NewField1111121112,NewField1111121113,NewField111121112,NewField1211121111,NewField1211121112,NewField1211121113,NewField11111111,NewField111121113};
                }
            }

        }

        public Main9Group Main9;

        public partial class Main2Group : TTReportGroup
        {
            public PhysicalTherapyInformation MyParentReport
            {
                get { return (PhysicalTherapyInformation)ParentReport; }
            }

            new public Main2GroupBody Body()
            {
                return (Main2GroupBody)_body;
            }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField181 { get {return Body().NewField181;} }
            public TTReportField NewField191 { get {return Body().NewField191;} }
            public TTReportField PatientName { get {return Body().PatientName;} }
            public TTReportField NewField1191 { get {return Body().NewField1191;} }
            public TTReportField NewField1201 { get {return Body().NewField1201;} }
            public TTReportField NewField1291 { get {return Body().NewField1291;} }
            public TTReportField NewField1301 { get {return Body().NewField1301;} }
            public TTReportField NewField11911 { get {return Body().NewField11911;} }
            public TTReportField NewField11021 { get {return Body().NewField11021;} }
            public TTReportField NewField11921 { get {return Body().NewField11921;} }
            public TTReportField NewField11031 { get {return Body().NewField11031;} }
            public TTReportField NewField111911 { get {return Body().NewField111911;} }
            public TTReportField NewField112011 { get {return Body().NewField112011;} }
            public TTReportField NewField112911 { get {return Body().NewField112911;} }
            public TTReportField NewField113011 { get {return Body().NewField113011;} }
            public TTReportField NewField1119111 { get {return Body().NewField1119111;} }
            public TTReportField NewField1110211 { get {return Body().NewField1110211;} }
            public Main2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Main2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new Main2GroupBody(this);
            }

            public partial class Main2GroupBody : TTReportSection
            {
                public PhysicalTherapyInformation MyParentReport
                {
                    get { return (PhysicalTherapyInformation)ParentReport; }
                }
                
                public TTReportField NewField14;
                public TTReportField NewField181;
                public TTReportField NewField191;
                public TTReportField PatientName;
                public TTReportField NewField1191;
                public TTReportField NewField1201;
                public TTReportField NewField1291;
                public TTReportField NewField1301;
                public TTReportField NewField11911;
                public TTReportField NewField11021;
                public TTReportField NewField11921;
                public TTReportField NewField11031;
                public TTReportField NewField111911;
                public TTReportField NewField112011;
                public TTReportField NewField112911;
                public TTReportField NewField113011;
                public TTReportField NewField1119111;
                public TTReportField NewField1110211; 
                public Main2GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 38;
                    RepeatCount = 0;
                    
                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 6, 51, 19, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField14.TextFont.Size = 12;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Hasta veya Hasta
Yakını/Vasisi/Velisi";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 19, 51, 32, false);
                    NewField181.Name = "NewField181";
                    NewField181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField181.MultiLine = EvetHayirEnum.ehEvet;
                    NewField181.WordBreak = EvetHayirEnum.ehEvet;
                    NewField181.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField181.TextFont.Size = 12;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @"Doktor";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 6, 108, 12, false);
                    NewField191.Name = "NewField191";
                    NewField191.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField191.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField191.MultiLine = EvetHayirEnum.ehEvet;
                    NewField191.WordBreak = EvetHayirEnum.ehEvet;
                    NewField191.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField191.TextFont.Size = 12;
                    NewField191.TextFont.Bold = true;
                    NewField191.TextFont.CharSet = 162;
                    NewField191.Value = @"Adı Soyadı";

                    PatientName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 12, 108, 19, false);
                    PatientName.Name = "PatientName";
                    PatientName.DrawStyle = DrawStyleConstants.vbSolid;
                    PatientName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PatientName.MultiLine = EvetHayirEnum.ehEvet;
                    PatientName.WordBreak = EvetHayirEnum.ehEvet;
                    PatientName.ExpandTabs = EvetHayirEnum.ehEvet;
                    PatientName.TextFont.Size = 12;
                    PatientName.TextFont.CharSet = 162;
                    PatientName.Value = @"";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 19, 108, 25, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1191.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1191.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1191.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1191.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1191.TextFont.Size = 12;
                    NewField1191.TextFont.Bold = true;
                    NewField1191.TextFont.CharSet = 162;
                    NewField1191.Value = @"Adı Soyadı";

                    NewField1201 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 25, 108, 32, false);
                    NewField1201.Name = "NewField1201";
                    NewField1201.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1201.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1201.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1201.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1201.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1201.TextFont.Size = 12;
                    NewField1201.TextFont.CharSet = 162;
                    NewField1201.Value = @"";

                    NewField1291 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 6, 145, 12, false);
                    NewField1291.Name = "NewField1291";
                    NewField1291.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1291.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1291.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1291.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1291.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1291.TextFont.Size = 12;
                    NewField1291.TextFont.Bold = true;
                    NewField1291.TextFont.CharSet = 162;
                    NewField1291.Value = @"Tarih";

                    NewField1301 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 12, 145, 19, false);
                    NewField1301.Name = "NewField1301";
                    NewField1301.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1301.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1301.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1301.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1301.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1301.TextFont.Size = 12;
                    NewField1301.TextFont.CharSet = 162;
                    NewField1301.Value = @"... / ... / 20..";

                    NewField11911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 19, 145, 25, false);
                    NewField11911.Name = "NewField11911";
                    NewField11911.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11911.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11911.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11911.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11911.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11911.TextFont.Size = 12;
                    NewField11911.TextFont.Bold = true;
                    NewField11911.TextFont.CharSet = 162;
                    NewField11911.Value = @"Tarih";

                    NewField11021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 25, 145, 32, false);
                    NewField11021.Name = "NewField11021";
                    NewField11021.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11021.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11021.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11021.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11021.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11021.TextFont.Size = 12;
                    NewField11021.TextFont.CharSet = 162;
                    NewField11021.Value = @"... / ... / 20..";

                    NewField11921 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 6, 175, 12, false);
                    NewField11921.Name = "NewField11921";
                    NewField11921.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11921.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11921.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11921.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11921.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11921.TextFont.Size = 12;
                    NewField11921.TextFont.Bold = true;
                    NewField11921.TextFont.CharSet = 162;
                    NewField11921.Value = @"Saat";

                    NewField11031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 12, 175, 19, false);
                    NewField11031.Name = "NewField11031";
                    NewField11031.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11031.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11031.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11031.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11031.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11031.TextFont.Size = 12;
                    NewField11031.TextFont.CharSet = 162;
                    NewField11031.Value = @".... : ....";

                    NewField111911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 19, 175, 25, false);
                    NewField111911.Name = "NewField111911";
                    NewField111911.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111911.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111911.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111911.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111911.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111911.TextFont.Size = 12;
                    NewField111911.TextFont.Bold = true;
                    NewField111911.TextFont.CharSet = 162;
                    NewField111911.Value = @"Saat";

                    NewField112011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 25, 175, 32, false);
                    NewField112011.Name = "NewField112011";
                    NewField112011.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112011.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112011.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112011.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112011.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112011.TextFont.Size = 12;
                    NewField112011.TextFont.CharSet = 162;
                    NewField112011.Value = @".... : ....";

                    NewField112911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 6, 205, 12, false);
                    NewField112911.Name = "NewField112911";
                    NewField112911.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112911.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112911.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112911.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112911.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112911.TextFont.Size = 12;
                    NewField112911.TextFont.Bold = true;
                    NewField112911.TextFont.CharSet = 162;
                    NewField112911.Value = @"İmza";

                    NewField113011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 12, 205, 19, false);
                    NewField113011.Name = "NewField113011";
                    NewField113011.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113011.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113011.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113011.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113011.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField113011.TextFont.Size = 12;
                    NewField113011.TextFont.CharSet = 162;
                    NewField113011.Value = @"";

                    NewField1119111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 19, 205, 25, false);
                    NewField1119111.Name = "NewField1119111";
                    NewField1119111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1119111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1119111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1119111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1119111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1119111.TextFont.Size = 12;
                    NewField1119111.TextFont.Bold = true;
                    NewField1119111.TextFont.CharSet = 162;
                    NewField1119111.Value = @"İmza";

                    NewField1110211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 25, 205, 32, false);
                    NewField1110211.Name = "NewField1110211";
                    NewField1110211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1110211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1110211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1110211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1110211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1110211.TextFont.Size = 12;
                    NewField1110211.TextFont.CharSet = 162;
                    NewField1110211.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField14.CalcValue = NewField14.Value;
                    NewField181.CalcValue = NewField181.Value;
                    NewField191.CalcValue = NewField191.Value;
                    PatientName.CalcValue = PatientName.Value;
                    NewField1191.CalcValue = NewField1191.Value;
                    NewField1201.CalcValue = NewField1201.Value;
                    NewField1291.CalcValue = NewField1291.Value;
                    NewField1301.CalcValue = NewField1301.Value;
                    NewField11911.CalcValue = NewField11911.Value;
                    NewField11021.CalcValue = NewField11021.Value;
                    NewField11921.CalcValue = NewField11921.Value;
                    NewField11031.CalcValue = NewField11031.Value;
                    NewField111911.CalcValue = NewField111911.Value;
                    NewField112011.CalcValue = NewField112011.Value;
                    NewField112911.CalcValue = NewField112911.Value;
                    NewField113011.CalcValue = NewField113011.Value;
                    NewField1119111.CalcValue = NewField1119111.Value;
                    NewField1110211.CalcValue = NewField1110211.Value;
                    return new TTReportObject[] { NewField14,NewField181,NewField191,PatientName,NewField1191,NewField1201,NewField1291,NewField1301,NewField11911,NewField11021,NewField11921,NewField11031,NewField111911,NewField112011,NewField112911,NewField113011,NewField1119111,NewField1110211};
                }

                public override void RunScript()
                {
#region MAIN2 BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true); 
            PhysiotherapyRequest pr = (PhysiotherapyRequest)objectContext.GetObject(new Guid(MyParentReport.RuntimeParameters.PHYSIOTHERAPYREQUEST.ToString()), "PhysiotherapyRequest");
            this.PatientName.CalcValue = pr.Episode.Patient.Name.ToString() + " " + pr.Episode.Patient.Surname.ToString();
#endregion MAIN2 BODY_Script
                }
            }

        }

        public Main2Group Main2;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public PhysicalTherapyInformation()
        {
            PART1 = new PART1Group(this,"PART1");
            Main1 = new Main1Group(PART1,"Main1");
            MAIN = new MAINGroup(PART1,"MAIN");
            Main3 = new Main3Group(PART1,"Main3");
            Main4 = new Main4Group(PART1,"Main4");
            Main5 = new Main5Group(PART1,"Main5");
            Main6 = new Main6Group(PART1,"Main6");
            Main6u1 = new Main6u1Group(PART1,"Main6u1");
            Main7 = new Main7Group(PART1,"Main7");
            Main8 = new Main8Group(PART1,"Main8");
            Main9 = new Main9Group(PART1,"Main9");
            Main2 = new Main2Group(PART1,"Main2");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("PHYSIOTHERAPYREQUEST", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("PHYSIOTHERAPYREQUEST"))
                _runtimeParameters.PHYSIOTHERAPYREQUEST = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["PHYSIOTHERAPYREQUEST"]);
            Name = "PHYSICALTHERAPYINFORMATION";
            Caption = "Fizik Tedavi Bilgilendirme Rıza Belgesi";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            DontUseWatermark = EvetHayirEnum.ehEvet;
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