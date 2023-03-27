
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
    /// Acil Yaralanma Tespit Formu
    /// </summary>
    public partial class EmergencyInterventionInjuryLocationReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public EmergencyInterventionInjuryLocationReport MyParentReport
            {
                get { return (EmergencyInterventionInjuryLocationReport)ParentReport; }
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
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField2 { get {return Footer().NewField2;} }
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
                list[0] = new TTReportNqlData<EmergencyInterventionInjuryLocation.GetEmergencyInterventionInjuryLocation_Class>("GetEmergencyInterventionInjuryLocation", EmergencyInterventionInjuryLocation.GetEmergencyInterventionInjuryLocation((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public EmergencyInterventionInjuryLocationReport MyParentReport
                {
                    get { return (EmergencyInterventionInjuryLocationReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField3; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 28;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 13, 293, 22, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Size = 18;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"YARALANMA TESPİT FORMU";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 22, 293, 27, false);
                    NewField3.Name = "NewField3";
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField3.TextFont.Size = 14;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"(Bu form müdahalenin yapıldığı ilk XXXXXXde doldurulacaktır.)";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EmergencyInterventionInjuryLocation.GetEmergencyInterventionInjuryLocation_Class dataset_GetEmergencyInterventionInjuryLocation = ParentGroup.rsGroup.GetCurrentRecord<EmergencyInterventionInjuryLocation.GetEmergencyInterventionInjuryLocation_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField3.CalcValue = NewField3.Value;
                    return new TTReportObject[] { NewField1,NewField3};
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public EmergencyInterventionInjuryLocationReport MyParentReport
                {
                    get { return (EmergencyInterventionInjuryLocationReport)ParentReport; }
                }
                
                public TTReportField NewField2; 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 12;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 4, 295, 9, false);
                    NewField2.Name = "NewField2";
                    NewField2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"{@pagenumber@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EmergencyInterventionInjuryLocation.GetEmergencyInterventionInjuryLocation_Class dataset_GetEmergencyInterventionInjuryLocation = ParentGroup.rsGroup.GetCurrentRecord<EmergencyInterventionInjuryLocation.GetEmergencyInterventionInjuryLocation_Class>(0);
                    NewField2.CalcValue = ParentReport.CurrentPageNumber.ToString();
                    return new TTReportObject[] { NewField2};
                }
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public EmergencyInterventionInjuryLocationReport MyParentReport
            {
                get { return (EmergencyInterventionInjuryLocationReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField RUTBE { get {return Body().RUTBE;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField3 { get {return Body().NewField3;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField15 { get {return Body().NewField15;} }
            public TTReportField NewField4 { get {return Body().NewField4;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField NewField17 { get {return Body().NewField17;} }
            public TTReportField NewField18 { get {return Body().NewField18;} }
            public TTReportField AD { get {return Body().AD;} }
            public TTReportField SOYAD { get {return Body().SOYAD;} }
            public TTReportField DTARIHI { get {return Body().DTARIHI;} }
            public TTReportField ADSOYADDTARIHI { get {return Body().ADSOYADDTARIHI;} }
            public TTReportField TC { get {return Body().TC;} }
            public TTReportField BIRLIKKURUM { get {return Body().BIRLIKKURUM;} }
            public TTReportField KACYIL { get {return Body().KACYIL;} }
            public TTReportField KACGUN { get {return Body().KACGUN;} }
            public TTReportField ILILCE { get {return Body().ILILCE;} }
            public TTReportField ASY { get {return Body().ASY;} }
            public TTReportField EYP { get {return Body().EYP;} }
            public TTReportField DIGER { get {return Body().DIGER;} }
            public TTReportField HOWWASINJURY { get {return Body().HOWWASINJURY;} }
            public TTReportField PROTECTIVECLOTING { get {return Body().PROTECTIVECLOTING;} }
            public TTReportField GOGGLES { get {return Body().GOGGLES;} }
            public TTReportField PROTECTIVEHEADGEAR { get {return Body().PROTECTIVEHEADGEAR;} }
            public TTReportField NewField5 { get {return Body().NewField5;} }
            public TTReportField ilk { get {return Body().ilk;} }
            public TTReportField INJURYDATE { get {return Body().INJURYDATE;} }
            public TTReportField NewField19 { get {return Body().NewField19;} }
            public TTReportField NewField20 { get {return Body().NewField20;} }
            public TTReportField NewField21 { get {return Body().NewField21;} }
            public TTReportField NewField22 { get {return Body().NewField22;} }
            public TTReportField NewField23 { get {return Body().NewField23;} }
            public TTReportField NewField24 { get {return Body().NewField24;} }
            public TTReportField NewField25 { get {return Body().NewField25;} }
            public TTReportField NewField26 { get {return Body().NewField26;} }
            public TTReportField NewField162 { get {return Body().NewField162;} }
            public TTReportField NewField163 { get {return Body().NewField163;} }
            public TTReportField NewField164 { get {return Body().NewField164;} }
            public TTReportField NewField1461 { get {return Body().NewField1461;} }
            public TTReportField NewField1462 { get {return Body().NewField1462;} }
            public TTReportField NewField165 { get {return Body().NewField165;} }
            public TTReportField NewField1561 { get {return Body().NewField1561;} }
            public TTReportField NewField11651 { get {return Body().NewField11651;} }
            public TTReportField NewField11652 { get {return Body().NewField11652;} }
            public TTReportField HIMSELF { get {return Body().HIMSELF;} }
            public TTReportField FIRSTAIDDATE { get {return Body().FIRSTAIDDATE;} }
            public TTReportField FRIEND { get {return Body().FRIEND;} }
            public TTReportField PARAMEDIC { get {return Body().PARAMEDIC;} }
            public TTReportField DOCTOR { get {return Body().DOCTOR;} }
            public TTReportField EVACUATIONTIME { get {return Body().EVACUATIONTIME;} }
            public TTReportField NewField1562 { get {return Body().NewField1562;} }
            public TTReportField NewField12651 { get {return Body().NewField12651;} }
            public TTReportField NewField12652 { get {return Body().NewField12652;} }
            public TTReportField TURNIKEKOL { get {return Body().TURNIKEKOL;} }
            public TTReportField TURNIKEBACAK { get {return Body().TURNIKEBACAK;} }
            public TTReportField TURNIKEYOK { get {return Body().TURNIKEYOK;} }
            public TTReportField GLASKOWKOMASKORU { get {return Body().GLASKOWKOMASKORU;} }
            public TTReportField KANREPLASMANIMIKTARI { get {return Body().KANREPLASMANIMIKTARI;} }
            public TTReportField NewField1563 { get {return Body().NewField1563;} }
            public TTReportField NewField125621 { get {return Body().NewField125621;} }
            public TTReportField KANREPLASMANIYOK { get {return Body().KANREPLASMANIYOK;} }
            public TTReportField NewField12653 { get {return Body().NewField12653;} }
            public TTReportField NewField135621 { get {return Body().NewField135621;} }
            public TTReportField YARALI { get {return Body().YARALI;} }
            public TTReportField SEHIT { get {return Body().SEHIT;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine15 { get {return Body().NewLine15;} }
            public TTReportShape NewLine16 { get {return Body().NewLine16;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportShape NewLine1121 { get {return Body().NewLine1121;} }
            public TTReportShape NewLine11211 { get {return Body().NewLine11211;} }
            public TTReportShape NewLine111211 { get {return Body().NewLine111211;} }
            public TTReportShape NewLine1112111 { get {return Body().NewLine1112111;} }
            public TTReportShape NewLine1112112 { get {return Body().NewLine1112112;} }
            public TTReportShape NewLine12112111 { get {return Body().NewLine12112111;} }
            public TTReportShape NewLine111121121 { get {return Body().NewLine111121121;} }
            public TTReportField KURUM { get {return Body().KURUM;} }
            public TTReportField BIRLIK { get {return Body().BIRLIK;} }
            public TTReportRTF SURGICALINTERVE { get {return Body().SURGICALINTERVE;} }
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
                public EmergencyInterventionInjuryLocationReport MyParentReport
                {
                    get { return (EmergencyInterventionInjuryLocationReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField RUTBE;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField4;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField AD;
                public TTReportField SOYAD;
                public TTReportField DTARIHI;
                public TTReportField ADSOYADDTARIHI;
                public TTReportField TC;
                public TTReportField BIRLIKKURUM;
                public TTReportField KACYIL;
                public TTReportField KACGUN;
                public TTReportField ILILCE;
                public TTReportField ASY;
                public TTReportField EYP;
                public TTReportField DIGER;
                public TTReportField HOWWASINJURY;
                public TTReportField PROTECTIVECLOTING;
                public TTReportField GOGGLES;
                public TTReportField PROTECTIVEHEADGEAR;
                public TTReportField NewField5;
                public TTReportField ilk;
                public TTReportField INJURYDATE;
                public TTReportField NewField19;
                public TTReportField NewField20;
                public TTReportField NewField21;
                public TTReportField NewField22;
                public TTReportField NewField23;
                public TTReportField NewField24;
                public TTReportField NewField25;
                public TTReportField NewField26;
                public TTReportField NewField162;
                public TTReportField NewField163;
                public TTReportField NewField164;
                public TTReportField NewField1461;
                public TTReportField NewField1462;
                public TTReportField NewField165;
                public TTReportField NewField1561;
                public TTReportField NewField11651;
                public TTReportField NewField11652;
                public TTReportField HIMSELF;
                public TTReportField FIRSTAIDDATE;
                public TTReportField FRIEND;
                public TTReportField PARAMEDIC;
                public TTReportField DOCTOR;
                public TTReportField EVACUATIONTIME;
                public TTReportField NewField1562;
                public TTReportField NewField12651;
                public TTReportField NewField12652;
                public TTReportField TURNIKEKOL;
                public TTReportField TURNIKEBACAK;
                public TTReportField TURNIKEYOK;
                public TTReportField GLASKOWKOMASKORU;
                public TTReportField KANREPLASMANIMIKTARI;
                public TTReportField NewField1563;
                public TTReportField NewField125621;
                public TTReportField KANREPLASMANIYOK;
                public TTReportField NewField12653;
                public TTReportField NewField135621;
                public TTReportField YARALI;
                public TTReportField SEHIT;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine2;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16;
                public TTReportShape NewLine121;
                public TTReportShape NewLine1121;
                public TTReportShape NewLine11211;
                public TTReportShape NewLine111211;
                public TTReportShape NewLine1112111;
                public TTReportShape NewLine1112112;
                public TTReportShape NewLine12112111;
                public TTReportShape NewLine111121121;
                public TTReportField KURUM;
                public TTReportField BIRLIK;
                public TTReportRTF SURGICALINTERVE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 126;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 10, 57, 15, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Rütbesi";

                    RUTBE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 10, 129, 15, false);
                    RUTBE.Name = "RUTBE";
                    RUTBE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RUTBE.Value = @"";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 18, 57, 23, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Adı Soyadı / Doğum Tarihi";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 29, 57, 34, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"T.C. No";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 41, 57, 46, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Birliği / Kurumu";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 48, 57, 58, false);
                    NewField14.Name = "NewField14";
                    NewField14.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14.WordBreak = EvetHayirEnum.ehEvet;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Kaç Yıllık XXXXXX/Polis/Korucu";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 60, 57, 65, false);
                    NewField15.Name = "NewField15";
                    NewField15.MultiLine = EvetHayirEnum.ehEvet;
                    NewField15.WordBreak = EvetHayirEnum.ehEvet;
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Kaç Gündür Operasyonda";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 69, 57, 74, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Yaralandığı Yer (İl/İlçe)";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 78, 57, 89, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"Yaralanma Şekli";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 91, 57, 101, false);
                    NewField17.Name = "NewField17";
                    NewField17.MultiLine = EvetHayirEnum.ehEvet;
                    NewField17.WordBreak = EvetHayirEnum.ehEvet;
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @"Olayın Oluş Şekli (Çatışma, Kaza, İntihar)";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 102, 57, 116, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @"Koruyucu Kıyafet";

                    AD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 16, 326, 21, false);
                    AD.Name = "AD";
                    AD.Visible = EvetHayirEnum.ehHayir;
                    AD.FieldType = ReportFieldTypeEnum.ftVariable;
                    AD.Value = @"{#HEADER.NAME#}";

                    SOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 24, 326, 29, false);
                    SOYAD.Name = "SOYAD";
                    SOYAD.Visible = EvetHayirEnum.ehHayir;
                    SOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOYAD.Value = @"{#HEADER.SURNAME#}";

                    DTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 304, 52, 329, 57, false);
                    DTARIHI.Name = "DTARIHI";
                    DTARIHI.Visible = EvetHayirEnum.ehHayir;
                    DTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    DTARIHI.TextFormat = @"dd/MM/yyyy";
                    DTARIHI.Value = @"{#HEADER.BIRTHDATE#}";

                    ADSOYADDTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 18, 129, 23, false);
                    ADSOYADDTARIHI.Name = "ADSOYADDTARIHI";
                    ADSOYADDTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDTARIHI.Value = @"{%AD%} {%SOYAD%} / {%DTARIHI%}";

                    TC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 29, 102, 34, false);
                    TC.Name = "TC";
                    TC.FieldType = ReportFieldTypeEnum.ftVariable;
                    TC.Value = @"{#HEADER.UNIQUEREFNO#}";

                    BIRLIKKURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 41, 128, 46, false);
                    BIRLIKKURUM.Name = "BIRLIKKURUM";
                    BIRLIKKURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIKKURUM.Value = @"{%BIRLIK%} / {%KURUM%}";

                    KACYIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 48, 102, 58, false);
                    KACYIL.Name = "KACYIL";
                    KACYIL.FieldType = ReportFieldTypeEnum.ftVariable;
                    KACYIL.Value = @"{#HEADER.HOWOLDSOLDIER#}";

                    KACGUN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 60, 102, 65, false);
                    KACGUN.Name = "KACGUN";
                    KACGUN.FieldType = ReportFieldTypeEnum.ftVariable;
                    KACGUN.Value = @"{#HEADER.HOWMANYDAYSINOPERATION#}";

                    ILILCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 69, 128, 74, false);
                    ILILCE.Name = "ILILCE";
                    ILILCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ILILCE.Value = @"{#HEADER.CITYOFINJURED#}";

                    ASY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 84, 70, 89, false);
                    ASY.Name = "ASY";
                    ASY.DrawStyle = DrawStyleConstants.vbSolid;
                    ASY.FieldType = ReportFieldTypeEnum.ftVariable;
                    ASY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ASY.Value = @"";

                    EYP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 84, 88, 89, false);
                    EYP.Name = "EYP";
                    EYP.DrawStyle = DrawStyleConstants.vbSolid;
                    EYP.FieldType = ReportFieldTypeEnum.ftVariable;
                    EYP.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EYP.Value = @"{#HEADER.EYP#}";

                    DIGER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 84, 109, 89, false);
                    DIGER.Name = "DIGER";
                    DIGER.DrawStyle = DrawStyleConstants.vbSolid;
                    DIGER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIGER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DIGER.Value = @"{#HEADER.DIGER#}";

                    HOWWASINJURY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 93, 128, 98, false);
                    HOWWASINJURY.Name = "HOWWASINJURY";
                    HOWWASINJURY.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOWWASINJURY.Value = @"{#HEADER.HOWWASINJURY#}";

                    PROTECTIVECLOTING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 111, 71, 116, false);
                    PROTECTIVECLOTING.Name = "PROTECTIVECLOTING";
                    PROTECTIVECLOTING.DrawStyle = DrawStyleConstants.vbSolid;
                    PROTECTIVECLOTING.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTECTIVECLOTING.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROTECTIVECLOTING.Value = @"{#HEADER.WEARINGPROTECTIVECLOTING#}";

                    GOGGLES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 111, 107, 116, false);
                    GOGGLES.Name = "GOGGLES";
                    GOGGLES.DrawStyle = DrawStyleConstants.vbSolid;
                    GOGGLES.FieldType = ReportFieldTypeEnum.ftVariable;
                    GOGGLES.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GOGGLES.Value = @"{#HEADER.WEARINGGOGGLES#}";

                    PROTECTIVEHEADGEAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 111, 90, 116, false);
                    PROTECTIVEHEADGEAR.Name = "PROTECTIVEHEADGEAR";
                    PROTECTIVEHEADGEAR.DrawStyle = DrawStyleConstants.vbSolid;
                    PROTECTIVEHEADGEAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTECTIVEHEADGEAR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROTECTIVEHEADGEAR.Value = @"{#HEADER.WEARINGPROTECTIVEHEADGEAR#}";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 10, 184, 15, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Yaralanma Tarih ve Saati";

                    ilk = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 16, 184, 25, false);
                    ilk.Name = "ilk";
                    ilk.MultiLine = EvetHayirEnum.ehEvet;
                    ilk.WordBreak = EvetHayirEnum.ehEvet;
                    ilk.TextFont.Bold = true;
                    ilk.TextFont.CharSet = 162;
                    ilk.Value = @"İlk Müdahale Tarih ve Saati";

                    INJURYDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 10, 238, 15, false);
                    INJURYDATE.Name = "INJURYDATE";
                    INJURYDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    INJURYDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    INJURYDATE.Value = @"{#HEADER.INJURYDATE#}";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 26, 184, 40, false);
                    NewField19.Name = "NewField19";
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @"İlk Müdahaleyi Yapan";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 41, 184, 46, false);
                    NewField20.Name = "NewField20";
                    NewField20.TextFont.Bold = true;
                    NewField20.TextFont.CharSet = 162;
                    NewField20.Value = @"Tahliye Süresi";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 48, 184, 59, false);
                    NewField21.Name = "NewField21";
                    NewField21.TextFont.Bold = true;
                    NewField21.TextFont.CharSet = 162;
                    NewField21.Value = @"Turnike Kullanımı";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 60, 184, 65, false);
                    NewField22.Name = "NewField22";
                    NewField22.TextFont.Bold = true;
                    NewField22.TextFont.CharSet = 162;
                    NewField22.Value = @"Glaskow Koma Skoru";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 66, 184, 77, false);
                    NewField23.Name = "NewField23";
                    NewField23.TextFont.Bold = true;
                    NewField23.TextFont.CharSet = 162;
                    NewField23.Value = @"Kan Replasmanı";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 78, 184, 100, false);
                    NewField24.Name = "NewField24";
                    NewField24.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField24.MultiLine = EvetHayirEnum.ehEvet;
                    NewField24.WordBreak = EvetHayirEnum.ehEvet;
                    NewField24.TextFont.Bold = true;
                    NewField24.TextFont.CharSet = 162;
                    NewField24.Value = @"Yapılan Cerrahi Müdahale (Kısa Adı)";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 102, 184, 113, false);
                    NewField25.Name = "NewField25";
                    NewField25.TextFont.Bold = true;
                    NewField25.TextFont.CharSet = 162;
                    NewField25.Value = @"Yaralının Durumu";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 78, 71, 83, false);
                    NewField26.Name = "NewField26";
                    NewField26.TextFont.Bold = true;
                    NewField26.TextFont.CharSet = 162;
                    NewField26.Value = @"ASY";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 78, 89, 83, false);
                    NewField162.Name = "NewField162";
                    NewField162.TextFont.Bold = true;
                    NewField162.TextFont.CharSet = 162;
                    NewField162.Value = @"EYP";

                    NewField163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 78, 111, 83, false);
                    NewField163.Name = "NewField163";
                    NewField163.TextFont.Bold = true;
                    NewField163.TextFont.CharSet = 162;
                    NewField163.Value = @"DİĞER";

                    NewField164 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 64, 102, 76, 111, false);
                    NewField164.Name = "NewField164";
                    NewField164.MultiLine = EvetHayirEnum.ehEvet;
                    NewField164.WordBreak = EvetHayirEnum.ehEvet;
                    NewField164.TextFont.Size = 8;
                    NewField164.TextFont.Bold = true;
                    NewField164.TextFont.CharSet = 162;
                    NewField164.Value = @"Koruyucu Elbise";

                    NewField1461 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 82, 102, 94, 111, false);
                    NewField1461.Name = "NewField1461";
                    NewField1461.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1461.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1461.TextFont.Size = 8;
                    NewField1461.TextFont.Bold = true;
                    NewField1461.TextFont.CharSet = 162;
                    NewField1461.Value = @"Koruyucu Başlık";

                    NewField1462 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 102, 112, 111, false);
                    NewField1462.Name = "NewField1462";
                    NewField1462.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1462.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1462.TextFont.Size = 8;
                    NewField1462.TextFont.Bold = true;
                    NewField1462.TextFont.CharSet = 162;
                    NewField1462.Value = @"Koruyucu Gözlük";

                    NewField165 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 29, 200, 34, false);
                    NewField165.Name = "NewField165";
                    NewField165.TextFont.Size = 8;
                    NewField165.TextFont.Bold = true;
                    NewField165.TextFont.CharSet = 162;
                    NewField165.Value = @"Kendisi";

                    NewField1561 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 26, 217, 34, false);
                    NewField1561.Name = "NewField1561";
                    NewField1561.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1561.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1561.TextFont.Size = 8;
                    NewField1561.TextFont.Bold = true;
                    NewField1561.TextFont.CharSet = 162;
                    NewField1561.Value = @"Tim Arkadaşı";

                    NewField11651 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 29, 235, 34, false);
                    NewField11651.Name = "NewField11651";
                    NewField11651.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11651.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11651.TextFont.Size = 8;
                    NewField11651.TextFont.Bold = true;
                    NewField11651.TextFont.CharSet = 162;
                    NewField11651.Value = @"Paramedik";

                    NewField11652 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 29, 251, 34, false);
                    NewField11652.Name = "NewField11652";
                    NewField11652.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11652.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11652.TextFont.Size = 8;
                    NewField11652.TextFont.Bold = true;
                    NewField11652.TextFont.CharSet = 162;
                    NewField11652.Value = @"Tabip";

                    HIMSELF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 34, 197, 39, false);
                    HIMSELF.Name = "HIMSELF";
                    HIMSELF.DrawStyle = DrawStyleConstants.vbSolid;
                    HIMSELF.FieldType = ReportFieldTypeEnum.ftVariable;
                    HIMSELF.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HIMSELF.Value = @"{#HEADER.FIRSTRESPONDERSWHOHIMSELF#}";

                    FIRSTAIDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 191, 17, 238, 25, false);
                    FIRSTAIDDATE.Name = "FIRSTAIDDATE";
                    FIRSTAIDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    FIRSTAIDDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    FIRSTAIDDATE.Value = @"{#HEADER.FIRSTAIDDATE#}";

                    FRIEND = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 34, 214, 39, false);
                    FRIEND.Name = "FRIEND";
                    FRIEND.DrawStyle = DrawStyleConstants.vbSolid;
                    FRIEND.FieldType = ReportFieldTypeEnum.ftVariable;
                    FRIEND.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FRIEND.Value = @"{#HEADER.FIRSTRESPONDERSWHOFRIEND#}";

                    PARAMEDIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 34, 230, 39, false);
                    PARAMEDIC.Name = "PARAMEDIC";
                    PARAMEDIC.DrawStyle = DrawStyleConstants.vbSolid;
                    PARAMEDIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARAMEDIC.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PARAMEDIC.Value = @"{#HEADER.FIRSTRESPONDERSWHOPARAMEDIC#}";

                    DOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 240, 34, 247, 39, false);
                    DOCTOR.Name = "DOCTOR";
                    DOCTOR.DrawStyle = DrawStyleConstants.vbSolid;
                    DOCTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOCTOR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DOCTOR.Value = @"{#HEADER.FIRSTRESPONDERSWHODOCTOR#}";

                    EVACUATIONTIME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 41, 238, 46, false);
                    EVACUATIONTIME.Name = "EVACUATIONTIME";
                    EVACUATIONTIME.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVACUATIONTIME.Value = @"{#HEADER.EVACUATIONTIME#}";

                    NewField1562 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 48, 200, 53, false);
                    NewField1562.Name = "NewField1562";
                    NewField1562.TextFont.Size = 8;
                    NewField1562.TextFont.Bold = true;
                    NewField1562.TextFont.CharSet = 162;
                    NewField1562.Value = @"Kol";

                    NewField12651 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 48, 216, 53, false);
                    NewField12651.Name = "NewField12651";
                    NewField12651.TextFont.Size = 8;
                    NewField12651.TextFont.Bold = true;
                    NewField12651.TextFont.CharSet = 162;
                    NewField12651.Value = @"Bacak";

                    NewField12652 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 48, 246, 53, false);
                    NewField12652.Name = "NewField12652";
                    NewField12652.TextFont.Size = 8;
                    NewField12652.TextFont.Bold = true;
                    NewField12652.TextFont.CharSet = 162;
                    NewField12652.Value = @"Yok";

                    TURNIKEKOL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 53, 197, 58, false);
                    TURNIKEKOL.Name = "TURNIKEKOL";
                    TURNIKEKOL.DrawStyle = DrawStyleConstants.vbSolid;
                    TURNIKEKOL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TURNIKEKOL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TURNIKEKOL.Value = @"";

                    TURNIKEBACAK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 206, 53, 213, 58, false);
                    TURNIKEBACAK.Name = "TURNIKEBACAK";
                    TURNIKEBACAK.DrawStyle = DrawStyleConstants.vbSolid;
                    TURNIKEBACAK.FieldType = ReportFieldTypeEnum.ftVariable;
                    TURNIKEBACAK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TURNIKEBACAK.Value = @"";

                    TURNIKEYOK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 53, 242, 58, false);
                    TURNIKEYOK.Name = "TURNIKEYOK";
                    TURNIKEYOK.DrawStyle = DrawStyleConstants.vbSolid;
                    TURNIKEYOK.FieldType = ReportFieldTypeEnum.ftVariable;
                    TURNIKEYOK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TURNIKEYOK.Value = @"";

                    GLASKOWKOMASKORU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 60, 253, 65, false);
                    GLASKOWKOMASKORU.Name = "GLASKOWKOMASKORU";
                    GLASKOWKOMASKORU.FieldType = ReportFieldTypeEnum.ftVariable;
                    GLASKOWKOMASKORU.Value = @"{#HEADER.GLASKOWKOMASKORU#}";

                    KANREPLASMANIMIKTARI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 71, 209, 76, false);
                    KANREPLASMANIMIKTARI.Name = "KANREPLASMANIMIKTARI";
                    KANREPLASMANIMIKTARI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KANREPLASMANIMIKTARI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KANREPLASMANIMIKTARI.Value = @"{#HEADER.KANREPLASMANIMIKTARI#}";

                    NewField1563 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 66, 213, 71, false);
                    NewField1563.Name = "NewField1563";
                    NewField1563.TextFont.Bold = true;
                    NewField1563.TextFont.CharSet = 162;
                    NewField1563.Value = @"Miktarı(Unite)";

                    NewField125621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 66, 246, 71, false);
                    NewField125621.Name = "NewField125621";
                    NewField125621.TextFont.Size = 8;
                    NewField125621.TextFont.Bold = true;
                    NewField125621.TextFont.CharSet = 162;
                    NewField125621.Value = @"Yok";

                    KANREPLASMANIYOK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 71, 243, 76, false);
                    KANREPLASMANIYOK.Name = "KANREPLASMANIYOK";
                    KANREPLASMANIYOK.DrawStyle = DrawStyleConstants.vbSolid;
                    KANREPLASMANIYOK.FieldType = ReportFieldTypeEnum.ftVariable;
                    KANREPLASMANIYOK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KANREPLASMANIYOK.Value = @"";

                    NewField12653 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 102, 200, 107, false);
                    NewField12653.Name = "NewField12653";
                    NewField12653.TextFont.Size = 8;
                    NewField12653.TextFont.Bold = true;
                    NewField12653.TextFont.CharSet = 162;
                    NewField12653.Value = @"Yaralı";

                    NewField135621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 209, 102, 219, 107, false);
                    NewField135621.Name = "NewField135621";
                    NewField135621.TextFont.Size = 8;
                    NewField135621.TextFont.Bold = true;
                    NewField135621.TextFont.CharSet = 162;
                    NewField135621.Value = @"Şehit";

                    YARALI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 190, 108, 196, 113, false);
                    YARALI.Name = "YARALI";
                    YARALI.DrawStyle = DrawStyleConstants.vbSolid;
                    YARALI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YARALI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YARALI.Value = @"";

                    SEHIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 209, 108, 215, 113, false);
                    SEHIT.Name = "SEHIT";
                    SEHIT.DrawStyle = DrawStyleConstants.vbSolid;
                    SEHIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEHIT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SEHIT.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 8, 277, 8, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 117, 277, 117, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 15, 277, 15, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 8, 14, 117, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 277, 8, 277, 117, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 59, 8, 59, 117, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 142, 8, 142, 117, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 184, 8, 184, 117, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 25, 277, 25, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 40, 277, 40, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 47, 277, 47, false);
                    NewLine11211.Name = "NewLine11211";
                    NewLine11211.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 59, 277, 59, false);
                    NewLine111211.Name = "NewLine111211";
                    NewLine111211.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1112111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 65, 277, 65, false);
                    NewLine1112111.Name = "NewLine1112111";
                    NewLine1112111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1112112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 77, 277, 77, false);
                    NewLine1112112.Name = "NewLine1112112";
                    NewLine1112112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12112111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 90, 142, 90, false);
                    NewLine12112111.Name = "NewLine12112111";
                    NewLine12112111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111121121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 101, 277, 101, false);
                    NewLine111121121.Name = "NewLine111121121";
                    NewLine111121121.DrawStyle = DrawStyleConstants.vbSolid;

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 35, 326, 40, false);
                    KURUM.Name = "KURUM";
                    KURUM.Visible = EvetHayirEnum.ehHayir;
                    KURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUM.ObjectDefName = "PayerDefinition";
                    KURUM.DataMember = "NAME";
                    KURUM.Value = @"{#HEADER.KURUM#}";

                    BIRLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 305, 43, 330, 48, false);
                    BIRLIK.Name = "BIRLIK";
                    BIRLIK.Visible = EvetHayirEnum.ehHayir;
                    BIRLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRLIK.Value = @"";

                    SURGICALINTERVE = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 190, 78, 253, 100, false);
                    SURGICALINTERVE.Name = "SURGICALINTERVE";
                    SURGICALINTERVE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EmergencyInterventionInjuryLocation.GetEmergencyInterventionInjuryLocation_Class dataset_GetEmergencyInterventionInjuryLocation = MyParentReport.HEADER.rsGroup.GetCurrentRecord<EmergencyInterventionInjuryLocation.GetEmergencyInterventionInjuryLocation_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    RUTBE.CalcValue = @"";
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    AD.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.Name) : "");
                    SOYAD.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.Surname) : "");
                    DTARIHI.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.BirthDate) : "");
                    ADSOYADDTARIHI.CalcValue = MyParentReport.MAIN.AD.CalcValue + @" " + MyParentReport.MAIN.SOYAD.CalcValue + @" / " + MyParentReport.MAIN.DTARIHI.FormattedValue;
                    TC.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.UniqueRefNo) : "");
                    BIRLIK.CalcValue = @"";
                    KURUM.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.Kurum) : "");
                    KURUM.PostFieldValueCalculation();
                    BIRLIKKURUM.CalcValue = MyParentReport.MAIN.BIRLIK.CalcValue + @" / " + MyParentReport.MAIN.KURUM.CalcValue;
                    KACYIL.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.HowOldSoldier) : "");
                    KACGUN.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.HowManyDaysInOperation) : "");
                    ILILCE.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.CityOfInjured) : "");
                    ASY.CalcValue = @"";
                    EYP.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.Eyp) : "");
                    DIGER.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.Diger) : "");
                    HOWWASINJURY.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.HowWasInjury) : "");
                    PROTECTIVECLOTING.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.WearingProtectiveCloting) : "");
                    GOGGLES.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.WearingGoggles) : "");
                    PROTECTIVEHEADGEAR.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.WearingProtectiveHeadgear) : "");
                    NewField5.CalcValue = NewField5.Value;
                    ilk.CalcValue = ilk.Value;
                    INJURYDATE.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.InjuryDate) : "");
                    NewField19.CalcValue = NewField19.Value;
                    NewField20.CalcValue = NewField20.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField22.CalcValue = NewField22.Value;
                    NewField23.CalcValue = NewField23.Value;
                    NewField24.CalcValue = NewField24.Value;
                    NewField25.CalcValue = NewField25.Value;
                    NewField26.CalcValue = NewField26.Value;
                    NewField162.CalcValue = NewField162.Value;
                    NewField163.CalcValue = NewField163.Value;
                    NewField164.CalcValue = NewField164.Value;
                    NewField1461.CalcValue = NewField1461.Value;
                    NewField1462.CalcValue = NewField1462.Value;
                    NewField165.CalcValue = NewField165.Value;
                    NewField1561.CalcValue = NewField1561.Value;
                    NewField11651.CalcValue = NewField11651.Value;
                    NewField11652.CalcValue = NewField11652.Value;
                    HIMSELF.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.FirstRespondersWhoHimself) : "");
                    FIRSTAIDDATE.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.FirstAidDate) : "");
                    FRIEND.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.FirstRespondersWhoFriend) : "");
                    PARAMEDIC.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.FirstRespondersWhoParamedic) : "");
                    DOCTOR.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.FirstRespondersWhoDoctor) : "");
                    EVACUATIONTIME.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.EvacuationTime) : "");
                    NewField1562.CalcValue = NewField1562.Value;
                    NewField12651.CalcValue = NewField12651.Value;
                    NewField12652.CalcValue = NewField12652.Value;
                    TURNIKEKOL.CalcValue = @"";
                    TURNIKEBACAK.CalcValue = @"";
                    TURNIKEYOK.CalcValue = @"";
                    GLASKOWKOMASKORU.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.GlaskowKomaSkoru) : "");
                    KANREPLASMANIMIKTARI.CalcValue = (dataset_GetEmergencyInterventionInjuryLocation != null ? Globals.ToStringCore(dataset_GetEmergencyInterventionInjuryLocation.Kanreplasmanimiktari) : "");
                    NewField1563.CalcValue = NewField1563.Value;
                    NewField125621.CalcValue = NewField125621.Value;
                    KANREPLASMANIYOK.CalcValue = @"";
                    NewField12653.CalcValue = NewField12653.Value;
                    NewField135621.CalcValue = NewField135621.Value;
                    YARALI.CalcValue = @"";
                    SEHIT.CalcValue = @"";
                    SURGICALINTERVE.CalcValue = SURGICALINTERVE.Value;
                    return new TTReportObject[] { NewField1,RUTBE,NewField2,NewField3,NewField13,NewField14,NewField15,NewField4,NewField16,NewField17,NewField18,AD,SOYAD,DTARIHI,ADSOYADDTARIHI,TC,BIRLIK,KURUM,BIRLIKKURUM,KACYIL,KACGUN,ILILCE,ASY,EYP,DIGER,HOWWASINJURY,PROTECTIVECLOTING,GOGGLES,PROTECTIVEHEADGEAR,NewField5,ilk,INJURYDATE,NewField19,NewField20,NewField21,NewField22,NewField23,NewField24,NewField25,NewField26,NewField162,NewField163,NewField164,NewField1461,NewField1462,NewField165,NewField1561,NewField11651,NewField11652,HIMSELF,FIRSTAIDDATE,FRIEND,PARAMEDIC,DOCTOR,EVACUATIONTIME,NewField1562,NewField12651,NewField12652,TURNIKEKOL,TURNIKEBACAK,TURNIKEYOK,GLASKOWKOMASKORU,KANREPLASMANIMIKTARI,NewField1563,NewField125621,KANREPLASMANIYOK,NewField12653,NewField135621,YARALI,SEHIT,SURGICALINTERVE};
                }
                public override void RunPreScript()
                {
#region MAIN BODY_PreScript
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((EmergencyInterventionInjuryLocationReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            EmergencyInterventionInjuryLocation emergencyInterventionInjuryLocation = (EmergencyInterventionInjuryLocation)objectContext.GetObject(new Guid(objectID),"EmergencyInterventionInjuryLocation");
            
              if(emergencyInterventionInjuryLocation.SurgicalInterventions !=null)
                this.SURGICALINTERVE.Value = emergencyInterventionInjuryLocation.SurgicalInterventions.ToString();
#endregion MAIN BODY_PreScript
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = ((EmergencyInterventionInjuryLocationReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            EmergencyInterventionInjuryLocation emergencyInterventionInjuryLocation = (EmergencyInterventionInjuryLocation)objectContext.GetObject(new Guid(objectID),"EmergencyInterventionInjuryLocation");
            
            this.ASY.CalcValue = emergencyInterventionInjuryLocation.TypeOfInjuryASY == true? "X" : null;
            this.EYP.CalcValue = emergencyInterventionInjuryLocation.TypeOfInjuryEYP == true ? "X" : null;
            this.DIGER.CalcValue = emergencyInterventionInjuryLocation.TypeOfInjuryOTHER == true ? "X" : null;
            this.PROTECTIVECLOTING.CalcValue = emergencyInterventionInjuryLocation.WearingProtectiveCloting == true ? "X" : null;
            this.PROTECTIVEHEADGEAR.CalcValue = emergencyInterventionInjuryLocation.WearingProtectiveHeadgear == true ? "X" : null;
            this.GOGGLES.CalcValue = emergencyInterventionInjuryLocation.WearingGoggles == true ? "X" : null;
            this.HIMSELF.CalcValue = emergencyInterventionInjuryLocation.FirstRespondersWhoHimself == true ? "X" : null;
            this.FRIEND.CalcValue = emergencyInterventionInjuryLocation.FirstRespondersWhoFriend == true ? "X" : null;
            this.PARAMEDIC.CalcValue = emergencyInterventionInjuryLocation.FirstRespondersWhoParamedic == true ? "X" : null;
            this.DOCTOR.CalcValue = emergencyInterventionInjuryLocation.FirstRespondersWhoDoctor == true ? "X" : null;
            this.TURNIKEKOL.CalcValue = emergencyInterventionInjuryLocation.TourniqueUsedArm == true ? "X" : null;
            this.TURNIKEBACAK.CalcValue = emergencyInterventionInjuryLocation.TourniqueUsedLeg == true ? "X" : null;
            this.TURNIKEYOK.CalcValue = emergencyInterventionInjuryLocation.IsUsedTourniquet == YesNoEnum.No ? "X" : null;
            this.KANREPLASMANIYOK.CalcValue = emergencyInterventionInjuryLocation.IsThereBloodReplacement == YesNoEnum.No ? "X" : null;            
            this.YARALI.CalcValue = emergencyInterventionInjuryLocation.ConditionOfInjured == ConditionOfInjured.Injured ? "X" : null;
            this.SEHIT.CalcValue = emergencyInterventionInjuryLocation.ConditionOfInjured == ConditionOfInjured.Martyr ? "X" : null;
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class YARALANMABOLGESIGroup : TTReportGroup
        {
            public EmergencyInterventionInjuryLocationReport MyParentReport
            {
                get { return (EmergencyInterventionInjuryLocationReport)ParentReport; }
            }

            new public YARALANMABOLGESIGroupBody Body()
            {
                return (YARALANMABOLGESIGroupBody)_body;
            }
            public TTReportField IMAGE { get {return Body().IMAGE;} }
            public YARALANMABOLGESIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public YARALANMABOLGESIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new YARALANMABOLGESIGroupBody(this);
            }

            public partial class YARALANMABOLGESIGroupBody : TTReportSection
            {
                public EmergencyInterventionInjuryLocationReport MyParentReport
                {
                    get { return (EmergencyInterventionInjuryLocationReport)ParentReport; }
                }
                
                public TTReportField IMAGE; 
                public YARALANMABOLGESIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 147;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    IMAGE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 6, 286, 142, false);
                    IMAGE.Name = "IMAGE";
                    IMAGE.FieldType = ReportFieldTypeEnum.ftOLE;
                    IMAGE.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMAGE.ObjectDefName = "EmergencyInterventionInjuryLocation";
                    IMAGE.DataMember = "INJURYLOCATIONIMAGE";
                    IMAGE.Value = @"{@TTOBJECTID@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    IMAGE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    return new TTReportObject[] { IMAGE};
                }
            }

        }

        public YARALANMABOLGESIGroup YARALANMABOLGESI;

        public partial class HEADERSGroup : TTReportGroup
        {
            public EmergencyInterventionInjuryLocationReport MyParentReport
            {
                get { return (EmergencyInterventionInjuryLocationReport)ParentReport; }
            }

            new public HEADERSGroupHeader Header()
            {
                return (HEADERSGroupHeader)_header;
            }

            new public HEADERSGroupFooter Footer()
            {
                return (HEADERSGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportShape NewLine14 { get {return Header().NewLine14;} }
            public TTReportShape NewLine15 { get {return Header().NewLine15;} }
            public TTReportShape NewLine16 { get {return Header().NewLine16;} }
            public TTReportShape NewLine17 { get {return Header().NewLine17;} }
            public TTReportField OBJECTID2 { get {return Header().OBJECTID2;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
            public TTReportShape NewLine18 { get {return Footer().NewLine18;} }
            public TTReportShape NewLine19 { get {return Footer().NewLine19;} }
            public TTReportShape NewLine20 { get {return Footer().NewLine20;} }
            public TTReportShape NewLine21 { get {return Footer().NewLine21;} }
            public TTReportShape NewLine22 { get {return Footer().NewLine22;} }
            public TTReportShape NewLine23 { get {return Footer().NewLine23;} }
            public TTReportShape NewLine24 { get {return Footer().NewLine24;} }
            public HEADERSGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERSGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERSGroupHeader(this);
                _footer = new HEADERSGroupFooter(this);

            }

            public partial class HEADERSGroupHeader : TTReportSection
            {
                public EmergencyInterventionInjuryLocationReport MyParentReport
                {
                    get { return (EmergencyInterventionInjuryLocationReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportShape NewLine1;
                public TTReportShape NewLine2;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16;
                public TTReportShape NewLine17;
                public TTReportField OBJECTID2; 
                public HEADERSGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 5;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 1, 55, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"Yaralanma Bölgesi Yönü";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 1, 98, 6, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Yaralanma Bölgesi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 1, 149, 6, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Yaralanma Şekli (ASY,EYP,Diğer)";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 1, 174, 6, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 162;
                    NewField13.Value = @"Giriş Sayısı";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 1, 199, 6, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Çıkış Sayısı";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 201, 1, 277, 6, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Bold = true;
                    NewField15.TextFont.CharSet = 162;
                    NewField15.Value = @"Açıklama";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 1, 277, 1, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 1, 13, 9, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 56, 1, 56, 9, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 99, 1, 99, 9, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 151, 1, 151, 9, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 175, 1, 175, 9, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 1, 200, 9, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 277, 1, 277, 9, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;

                    OBJECTID2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 303, -2, 328, 3, false);
                    OBJECTID2.Name = "OBJECTID2";
                    OBJECTID2.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID2.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID2.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    OBJECTID2.CalcValue = @"";
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField13,NewField14,NewField15,OBJECTID2};
                }
            }
            public partial class HEADERSGroupFooter : TTReportSection
            {
                public EmergencyInterventionInjuryLocationReport MyParentReport
                {
                    get { return (EmergencyInterventionInjuryLocationReport)ParentReport; }
                }
                
                public TTReportShape NewLine121;
                public TTReportShape NewLine18;
                public TTReportShape NewLine19;
                public TTReportShape NewLine20;
                public TTReportShape NewLine21;
                public TTReportShape NewLine22;
                public TTReportShape NewLine23;
                public TTReportShape NewLine24; 
                public HEADERSGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, 1, 277, 1, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, -7, 13, 1, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine19 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 56, -7, 56, 1, false);
                    NewLine19.Name = "NewLine19";
                    NewLine19.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine20 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 99, -7, 99, 1, false);
                    NewLine20.Name = "NewLine20";
                    NewLine20.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine21 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 151, -7, 151, 1, false);
                    NewLine21.Name = "NewLine21";
                    NewLine21.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine22 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 175, -7, 175, 1, false);
                    NewLine22.Name = "NewLine22";
                    NewLine22.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine23 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, -7, 200, 1, false);
                    NewLine23.Name = "NewLine23";
                    NewLine23.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine24 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 277, -7, 277, 1, false);
                    NewLine24.Name = "NewLine24";
                    NewLine24.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    return new TTReportObject[] { };
                }
            }

        }

        public HEADERSGroup HEADERS;

        public partial class YARALANMABOLGESIBILGLERIGroup : TTReportGroup
        {
            public EmergencyInterventionInjuryLocationReport MyParentReport
            {
                get { return (EmergencyInterventionInjuryLocationReport)ParentReport; }
            }

            new public YARALANMABOLGESIBILGLERIGroupBody Body()
            {
                return (YARALANMABOLGESIBILGLERIGroupBody)_body;
            }
            public TTReportField YARALANMABOLGESIYONU { get {return Body().YARALANMABOLGESIYONU;} }
            public TTReportField YARALANMABOLGESI { get {return Body().YARALANMABOLGESI;} }
            public TTReportField TYPEOFINJURY { get {return Body().TYPEOFINJURY;} }
            public TTReportField IN { get {return Body().IN;} }
            public TTReportField OUT { get {return Body().OUT;} }
            public TTReportField DESCRIPTION { get {return Body().DESCRIPTION;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportShape NewLine131 { get {return Body().NewLine131;} }
            public TTReportShape NewLine132 { get {return Body().NewLine132;} }
            public TTReportShape NewLine133 { get {return Body().NewLine133;} }
            public TTReportShape NewLine134 { get {return Body().NewLine134;} }
            public TTReportShape NewLine135 { get {return Body().NewLine135;} }
            public TTReportShape NewLine136 { get {return Body().NewLine136;} }
            public YARALANMABOLGESIBILGLERIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public YARALANMABOLGESIBILGLERIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<EmergencyInterventionInjuryLocationGrid.GetEmerInterInjuryLocationGrid_Class>("GetEmerInterInjuryLocationGrid", EmergencyInterventionInjuryLocationGrid.GetEmerInterInjuryLocationGrid((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new YARALANMABOLGESIBILGLERIGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class YARALANMABOLGESIBILGLERIGroupBody : TTReportSection
            {
                public EmergencyInterventionInjuryLocationReport MyParentReport
                {
                    get { return (EmergencyInterventionInjuryLocationReport)ParentReport; }
                }
                
                public TTReportField YARALANMABOLGESIYONU;
                public TTReportField YARALANMABOLGESI;
                public TTReportField TYPEOFINJURY;
                public TTReportField IN;
                public TTReportField OUT;
                public TTReportField DESCRIPTION;
                public TTReportShape NewLine11;
                public TTReportShape NewLine13;
                public TTReportField OBJECTID;
                public TTReportShape NewLine131;
                public TTReportShape NewLine132;
                public TTReportShape NewLine133;
                public TTReportShape NewLine134;
                public TTReportShape NewLine135;
                public TTReportShape NewLine136; 
                public YARALANMABOLGESIBILGLERIGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    RepeatCount = 0;
                    
                    YARALANMABOLGESIYONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 0, 55, 5, false);
                    YARALANMABOLGESIYONU.Name = "YARALANMABOLGESIYONU";
                    YARALANMABOLGESIYONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    YARALANMABOLGESIYONU.Value = @"{#INJURYDIRECTIONOFLOCATION#}";

                    YARALANMABOLGESI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 0, 98, 5, false);
                    YARALANMABOLGESI.Name = "YARALANMABOLGESI";
                    YARALANMABOLGESI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YARALANMABOLGESI.Value = @"{#INJURYLOCATION#}";

                    TYPEOFINJURY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 0, 149, 5, false);
                    TYPEOFINJURY.Name = "TYPEOFINJURY";
                    TYPEOFINJURY.FieldType = ReportFieldTypeEnum.ftVariable;
                    TYPEOFINJURY.Value = @"{#TYPEOFINJURY#}";

                    IN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 0, 174, 5, false);
                    IN.Name = "IN";
                    IN.FieldType = ReportFieldTypeEnum.ftVariable;
                    IN.Value = @"{#IN#}";

                    OUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 0, 200, 5, false);
                    OUT.Name = "OUT";
                    OUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    OUT.Value = @"{#OUT#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 201, 0, 277, 5, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.Value = @"";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, -1, 277, -1, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 13, -4, 13, 6, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 304, 0, 329, 5, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#OBJECTID#}";

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 56, -4, 56, 6, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine132 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 99, -4, 99, 6, false);
                    NewLine132.Name = "NewLine132";
                    NewLine132.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine133 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 151, -4, 151, 6, false);
                    NewLine133.Name = "NewLine133";
                    NewLine133.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine134 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 175, -4, 175, 6, false);
                    NewLine134.Name = "NewLine134";
                    NewLine134.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine135 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, -4, 200, 6, false);
                    NewLine135.Name = "NewLine135";
                    NewLine135.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine136 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 277, -3, 277, 6, false);
                    NewLine136.Name = "NewLine136";
                    NewLine136.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    EmergencyInterventionInjuryLocationGrid.GetEmerInterInjuryLocationGrid_Class dataset_GetEmerInterInjuryLocationGrid = ParentGroup.rsGroup.GetCurrentRecord<EmergencyInterventionInjuryLocationGrid.GetEmerInterInjuryLocationGrid_Class>(0);
                    YARALANMABOLGESIYONU.CalcValue = (dataset_GetEmerInterInjuryLocationGrid != null ? Globals.ToStringCore(dataset_GetEmerInterInjuryLocationGrid.InjuryDirectionOfLocation) : "");
                    YARALANMABOLGESI.CalcValue = (dataset_GetEmerInterInjuryLocationGrid != null ? Globals.ToStringCore(dataset_GetEmerInterInjuryLocationGrid.InjuryLocation) : "");
                    TYPEOFINJURY.CalcValue = (dataset_GetEmerInterInjuryLocationGrid != null ? Globals.ToStringCore(dataset_GetEmerInterInjuryLocationGrid.TypeOfInjury) : "");
                    IN.CalcValue = (dataset_GetEmerInterInjuryLocationGrid != null ? Globals.ToStringCore(dataset_GetEmerInterInjuryLocationGrid.In) : "");
                    OUT.CalcValue = (dataset_GetEmerInterInjuryLocationGrid != null ? Globals.ToStringCore(dataset_GetEmerInterInjuryLocationGrid.Out) : "");
                    DESCRIPTION.CalcValue = @"";
                    OBJECTID.CalcValue = (dataset_GetEmerInterInjuryLocationGrid != null ? Globals.ToStringCore(dataset_GetEmerInterInjuryLocationGrid.ObjectID) : "");
                    return new TTReportObject[] { YARALANMABOLGESIYONU,YARALANMABOLGESI,TYPEOFINJURY,IN,OUT,DESCRIPTION,OBJECTID};
                }

                public override void RunScript()
                {
#region YARALANMABOLGESIBILGLERI BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
            //  string objectID = ((EmergencyInterventionInjuryLocationReport)ParentReport).Groups("YARALANMABOLGESIBILGLERI").Header.FieldsByName("OBJECTID").CalcValue;
            string objectID = this.OBJECTID.CalcValue;
            EmergencyInterventionInjuryLocationGrid emergencyInterventionInjuryLocationGrid = (EmergencyInterventionInjuryLocationGrid)objectContext.GetObject(new Guid(objectID), "EmergencyInterventionInjuryLocationGrid");
            if(emergencyInterventionInjuryLocationGrid.Description != null)
                this.DESCRIPTION.CalcValue = TTObjectClasses.Common.GetTextOfRTFString(emergencyInterventionInjuryLocationGrid.Description.ToString());
#endregion YARALANMABOLGESIBILGLERI BODY_Script
                }
            }

        }

        public YARALANMABOLGESIBILGLERIGroup YARALANMABOLGESIBILGLERI;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public EmergencyInterventionInjuryLocationReport()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            YARALANMABOLGESI = new YARALANMABOLGESIGroup(HEADER,"YARALANMABOLGESI");
            HEADERS = new HEADERSGroup(HEADER,"HEADERS");
            YARALANMABOLGESIBILGLERI = new YARALANMABOLGESIBILGLERIGroup(HEADERS,"YARALANMABOLGESIBILGLERI");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ObjectID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "EMERGENCYINTERVENTIONINJURYLOCATIONREPORT";
            Caption = "Acil Yaralanma Tespit Formu";
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