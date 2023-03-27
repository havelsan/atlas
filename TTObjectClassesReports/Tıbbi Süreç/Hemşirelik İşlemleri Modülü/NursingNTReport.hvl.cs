
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
    /// Nutrisyonel Risk Skoru Değerlendirme Formu
    /// </summary>
    public partial class NursingNTReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public List<string> Objects = new List<string>();
        }

        public partial class ParentGroup : TTReportGroup
        {
            public NursingNTReport MyParentReport
            {
                get { return (NursingNTReport)ParentReport; }
            }

            new public ParentGroupHeader Header()
            {
                return (ParentGroupHeader)_header;
            }

            new public ParentGroupFooter Footer()
            {
                return (ParentGroupFooter)_footer;
            }

            public TTReportField OBJECTID { get {return Header().OBJECTID;} }
            public ParentGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ParentGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<NursingNutritionalRiskAssessment.GetRiskAssesment_Class>("GetRiskAssesment", NursingNutritionalRiskAssessment.GetRiskAssesment((List<string>) MyParentReport.RuntimeParameters.Objects));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new ParentGroupHeader(this);
                _footer = new ParentGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class ParentGroupHeader : TTReportSection
            {
                public NursingNTReport MyParentReport
                {
                    get { return (NursingNTReport)ParentReport; }
                }
                
                public TTReportField OBJECTID; 
                public ParentGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 4, 50, 9, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.TextFont.CharSet = 162;
                    OBJECTID.Value = @"{#OBJECTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NursingNutritionalRiskAssessment.GetRiskAssesment_Class dataset_GetRiskAssesment = ParentGroup.rsGroup.GetCurrentRecord<NursingNutritionalRiskAssessment.GetRiskAssesment_Class>(0);
                    OBJECTID.CalcValue = (dataset_GetRiskAssesment != null ? Globals.ToStringCore(dataset_GetRiskAssesment.ObjectID) : "");
                    return new TTReportObject[] { OBJECTID};
                }
            }
            public partial class ParentGroupFooter : TTReportSection
            {
                public NursingNTReport MyParentReport
                {
                    get { return (NursingNTReport)ParentReport; }
                }
                 
                public ParentGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public ParentGroup Parent;

        public partial class HEADERGroup : TTReportGroup
        {
            public NursingNTReport MyParentReport
            {
                get { return (NursingNTReport)ParentReport; }
            }

            new public HEADERGroupHeader Header()
            {
                return (HEADERGroupHeader)_header;
            }

            new public HEADERGroupFooter Footer()
            {
                return (HEADERGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField XXXXXXBASLIK111 { get {return Header().XXXXXXBASLIK111;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField PROTOKOLNO { get {return Header().PROTOKOLNO;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField SERVIS { get {return Header().SERVIS;} }
            public TTReportField NewField112711 { get {return Header().NewField112711;} }
            public TTReportField NewField1114111 { get {return Header().NewField1114111;} }
            public TTReportField CINSIYET { get {return Header().CINSIYET;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1142 { get {return Header().NewField1142;} }
            public TTReportField YAS { get {return Header().YAS;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField NewField12411 { get {return Header().NewField12411;} }
            public TTReportField YATISTARIH { get {return Header().YATISTARIH;} }
            public TTReportField NewField112712 { get {return Header().NewField112712;} }
            public TTReportField NewField1114112 { get {return Header().NewField1114112;} }
            public TTReportField BOY { get {return Header().BOY;} }
            public TTReportField NewField111211 { get {return Header().NewField111211;} }
            public TTReportField NewField111421 { get {return Header().NewField111421;} }
            public TTReportField KILO { get {return Header().KILO;} }
            public TTReportField NewField1112111 { get {return Header().NewField1112111;} }
            public TTReportField NewField1124111 { get {return Header().NewField1124111;} }
            public TTReportField createDate { get {return Header().createDate;} }
            public TTReportField NewField111411234 { get {return Header().NewField111411234;} }
            public TTReportField OLUSTURULMATARIH { get {return Header().OLUSTURULMATARIH;} }
            public HEADERGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HEADERGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HEADERGroupHeader(this);
                _footer = new HEADERGroupFooter(this);

            }

            public partial class HEADERGroupHeader : TTReportSection
            {
                public NursingNTReport MyParentReport
                {
                    get { return (NursingNTReport)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField XXXXXXBASLIK111;
                public TTReportField LOGO;
                public TTReportField ADSOYAD;
                public TTReportField NewField121;
                public TTReportField NewField141;
                public TTReportField PROTOKOLNO;
                public TTReportField NewField1221;
                public TTReportField NewField1141;
                public TTReportField SERVIS;
                public TTReportField NewField112711;
                public TTReportField NewField1114111;
                public TTReportField CINSIYET;
                public TTReportField NewField1121;
                public TTReportField NewField1142;
                public TTReportField YAS;
                public TTReportField NewField11211;
                public TTReportField NewField12411;
                public TTReportField YATISTARIH;
                public TTReportField NewField112712;
                public TTReportField NewField1114112;
                public TTReportField BOY;
                public TTReportField NewField111211;
                public TTReportField NewField111421;
                public TTReportField KILO;
                public TTReportField NewField1112111;
                public TTReportField NewField1124111;
                public TTReportField createDate;
                public TTReportField NewField111411234;
                public TTReportField OLUSTURULMATARIH; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 69;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 31, 243, 39, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Nutrisyonel Risk Skoru Değerlendirme Formu";

                    XXXXXXBASLIK111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 5, 243, 30, false);
                    XXXXXXBASLIK111.Name = "XXXXXXBASLIK111";
                    XXXXXXBASLIK111.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK111.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK111.TextFont.Size = 11;
                    XXXXXXBASLIK111.TextFont.Bold = true;
                    XXXXXXBASLIK111.TextFont.CharSet = 162;
                    XXXXXXBASLIK111.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 13, 90, 36, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 43, 132, 48, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.ObjectDefName = "NursingApplication";
                    ADSOYAD.DataMember = "EPISODE.PATIENT.FullName";
                    ADSOYAD.TextFont.Size = 9;
                    ADSOYAD.TextFont.CharSet = 162;
                    ADSOYAD.Value = @"";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 43, 69, 48, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Adı Soyadı";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 44, 72, 48, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Name = "Courier New";
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @":";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 43, 207, 47, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.ObjectDefName = "NursingApplication";
                    PROTOKOLNO.DataMember = "SUBEPISODE.INPATIENTADMISSION.QUARANTINEPROTOCOLNO";
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 43, 166, 47, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.TextFont.Size = 9;
                    NewField1221.TextFont.Bold = true;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"Protokol No";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 43, 169, 47, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.TextFont.Name = "Courier New";
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @":";

                    SERVIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 48, 255, 52, false);
                    SERVIS.Name = "SERVIS";
                    SERVIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERVIS.TextFont.Size = 9;
                    SERVIS.TextFont.CharSet = 162;
                    SERVIS.Value = @"";

                    NewField112711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 48, 166, 52, false);
                    NewField112711.Name = "NewField112711";
                    NewField112711.TextFont.Size = 9;
                    NewField112711.TextFont.Bold = true;
                    NewField112711.TextFont.CharSet = 162;
                    NewField112711.Value = @"Servis/Oda Grubu";

                    NewField1114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 48, 169, 52, false);
                    NewField1114111.Name = "NewField1114111";
                    NewField1114111.TextFont.Name = "Courier New";
                    NewField1114111.TextFont.CharSet = 162;
                    NewField1114111.Value = @":";

                    CINSIYET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 49, 132, 54, false);
                    CINSIYET.Name = "CINSIYET";
                    CINSIYET.FieldType = ReportFieldTypeEnum.ftVariable;
                    CINSIYET.ObjectDefName = "NursingApplication";
                    CINSIYET.DataMember = "EPISODE.PATIENT.FullName";
                    CINSIYET.TextFont.Size = 9;
                    CINSIYET.TextFont.CharSet = 162;
                    CINSIYET.Value = @"";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 49, 69, 54, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Cinsiyet";

                    NewField1142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 50, 72, 54, false);
                    NewField1142.Name = "NewField1142";
                    NewField1142.TextFont.Name = "Courier New";
                    NewField1142.TextFont.CharSet = 162;
                    NewField1142.Value = @":";

                    YAS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 55, 132, 60, false);
                    YAS.Name = "YAS";
                    YAS.FieldType = ReportFieldTypeEnum.ftVariable;
                    YAS.ObjectDefName = "NursingApplication";
                    YAS.DataMember = "EPISODE.PATIENT.FullName";
                    YAS.TextFont.Size = 9;
                    YAS.TextFont.CharSet = 162;
                    YAS.Value = @"";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 55, 69, 60, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Yaş";

                    NewField12411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 56, 72, 60, false);
                    NewField12411.Name = "NewField12411";
                    NewField12411.TextFont.Name = "Courier New";
                    NewField12411.TextFont.CharSet = 162;
                    NewField12411.Value = @":";

                    YATISTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 53, 255, 57, false);
                    YATISTARIH.Name = "YATISTARIH";
                    YATISTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATISTARIH.TextFont.Size = 9;
                    YATISTARIH.TextFont.CharSet = 162;
                    YATISTARIH.Value = @"";

                    NewField112712 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 53, 166, 57, false);
                    NewField112712.Name = "NewField112712";
                    NewField112712.TextFont.Size = 9;
                    NewField112712.TextFont.Bold = true;
                    NewField112712.TextFont.CharSet = 162;
                    NewField112712.Value = @"Yatış Tarihi";

                    NewField1114112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 53, 169, 57, false);
                    NewField1114112.Name = "NewField1114112";
                    NewField1114112.TextFont.Name = "Courier New";
                    NewField1114112.TextFont.CharSet = 162;
                    NewField1114112.Value = @":";

                    BOY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 62, 73, 67, false);
                    BOY.Name = "BOY";
                    BOY.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOY.ObjectDefName = "NursingApplication";
                    BOY.DataMember = "EPISODE.PATIENT.FullName";
                    BOY.TextFont.Size = 9;
                    BOY.TextFont.CharSet = 162;
                    BOY.Value = @"";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 62, 56, 67, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Boy";

                    NewField111421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 57, 63, 59, 67, false);
                    NewField111421.Name = "NewField111421";
                    NewField111421.TextFont.Name = "Courier New";
                    NewField111421.TextFont.CharSet = 162;
                    NewField111421.Value = @":";

                    KILO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 62, 107, 67, false);
                    KILO.Name = "KILO";
                    KILO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KILO.ObjectDefName = "NursingApplication";
                    KILO.DataMember = "EPISODE.PATIENT.FullName";
                    KILO.TextFont.Size = 9;
                    KILO.TextFont.CharSet = 162;
                    KILO.Value = @"";

                    NewField1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 62, 90, 67, false);
                    NewField1112111.Name = "NewField1112111";
                    NewField1112111.TextFont.Bold = true;
                    NewField1112111.TextFont.CharSet = 162;
                    NewField1112111.Value = @"Kilo";

                    NewField1124111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 63, 93, 67, false);
                    NewField1124111.Name = "NewField1124111";
                    NewField1124111.TextFont.Name = "Courier New";
                    NewField1124111.TextFont.CharSet = 162;
                    NewField1124111.Value = @":";

                    createDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 58, 166, 63, false);
                    createDate.Name = "createDate";
                    createDate.TextFont.Size = 9;
                    createDate.TextFont.Bold = true;
                    createDate.TextFont.CharSet = 162;
                    createDate.Value = @"Oluşturulma Tarihi";

                    NewField111411234 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 59, 169, 63, false);
                    NewField111411234.Name = "NewField111411234";
                    NewField111411234.TextFont.Name = "Courier New";
                    NewField111411234.TextFont.Bold = true;
                    NewField111411234.TextFont.CharSet = 162;
                    NewField111411234.Value = @":";

                    OLUSTURULMATARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 58, 254, 63, false);
                    OLUSTURULMATARIH.Name = "OLUSTURULMATARIH";
                    OLUSTURULMATARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLUSTURULMATARIH.TextFont.Size = 9;
                    OLUSTURULMATARIH.TextFont.CharSet = 162;
                    OLUSTURULMATARIH.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    LOGO.CalcValue = @"";
                    ADSOYAD.CalcValue = @"";
                    ADSOYAD.PostFieldValueCalculation();
                    NewField121.CalcValue = NewField121.Value;
                    NewField141.CalcValue = NewField141.Value;
                    PROTOKOLNO.CalcValue = @"";
                    PROTOKOLNO.PostFieldValueCalculation();
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    SERVIS.CalcValue = @"";
                    NewField112711.CalcValue = NewField112711.Value;
                    NewField1114111.CalcValue = NewField1114111.Value;
                    CINSIYET.CalcValue = @"";
                    CINSIYET.PostFieldValueCalculation();
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1142.CalcValue = NewField1142.Value;
                    YAS.CalcValue = @"";
                    YAS.PostFieldValueCalculation();
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField12411.CalcValue = NewField12411.Value;
                    YATISTARIH.CalcValue = @"";
                    NewField112712.CalcValue = NewField112712.Value;
                    NewField1114112.CalcValue = NewField1114112.Value;
                    BOY.CalcValue = @"";
                    BOY.PostFieldValueCalculation();
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField111421.CalcValue = NewField111421.Value;
                    KILO.CalcValue = @"";
                    KILO.PostFieldValueCalculation();
                    NewField1112111.CalcValue = NewField1112111.Value;
                    NewField1124111.CalcValue = NewField1124111.Value;
                    createDate.CalcValue = createDate.Value;
                    NewField111411234.CalcValue = NewField111411234.Value;
                    OLUSTURULMATARIH.CalcValue = @"";
                    XXXXXXBASLIK111.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField111,LOGO,ADSOYAD,NewField121,NewField141,PROTOKOLNO,NewField1221,NewField1141,SERVIS,NewField112711,NewField1114111,CINSIYET,NewField1121,NewField1142,YAS,NewField11211,NewField12411,YATISTARIH,NewField112712,NewField1114112,BOY,NewField111211,NewField111421,KILO,NewField1112111,NewField1124111,createDate,NewField111411234,OLUSTURULMATARIH,XXXXXXBASLIK111};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);                           
            string sObjectID = ((NursingNTReport)ParentReport).Parent.OBJECTID.CalcValue;    
            NursingNutritionalRiskAssessment ntRisk = (NursingNutritionalRiskAssessment)context.GetObject(new Guid(sObjectID), "NursingNutritionalRiskAssessment");
            this.ADSOYAD.CalcValue = ntRisk.NursingApplication.Episode.Patient.FullName;
            this.YAS.CalcValue = ntRisk.NursingApplication.Episode.Patient.Age.ToString();
            this.CINSIYET.CalcValue = ntRisk.NursingApplication.Episode.Patient.Sex.ADI;
            this.OLUSTURULMATARIH.CalcValue  = ntRisk.ApplicationDate?.ToShortDateString();

            if(ntRisk.NursingApplication.SubEpisode.InpatientAdmission!=null)
                this.YATISTARIH.CalcValue = ntRisk.NursingApplication.SubEpisode.InpatientAdmission.HospitalInPatientDate?.ToShortDateString();
            List<InpatientAdmission> inpatientAdmissionList = new List<InpatientAdmission>();
            inpatientAdmissionList = ntRisk.NursingApplication.Episode.InpatientAdmissions.OrderByDescending(t => t.RequestDate).ToList();
            
            this.KILO.CalcValue = ntRisk?.Weight?.ToString();
            this.BOY.CalcValue = ntRisk?.Height?.ToString();
            foreach (var item in ntRisk.NursingApplication.Episode.SubEpisodes)
            {
                if (item.CurrentStateDefID != SubEpisode.States.Cancelled)
                {
                    this.PROTOKOLNO.CalcValue = item.ProtocolNo;
                    this.SERVIS.CalcValue = item.ResSection.GetMySKRSKlinikler().ADI;
                    break;
                }
            }
            this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public NursingNTReport MyParentReport
                {
                    get { return (NursingNTReport)ParentReport; }
                }
                 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 12;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public NursingNTReport MyParentReport
            {
                get { return (NursingNTReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField11211 { get {return Body().NewField11211;} }
            public TTReportField NewField111211 { get {return Body().NewField111211;} }
            public TTReportField NewField1112111 { get {return Body().NewField1112111;} }
            public TTReportField NewField11112111 { get {return Body().NewField11112111;} }
            public TTReportField NewField111212 { get {return Body().NewField111212;} }
            public TTReportField NewField1212111 { get {return Body().NewField1212111;} }
            public TTReportField NewField11112121 { get {return Body().NewField11112121;} }
            public TTReportField NewField112121111 { get {return Body().NewField112121111;} }
            public TTReportField NewField111121111 { get {return Body().NewField111121111;} }
            public TTReportField NewField1111121111 { get {return Body().NewField1111121111;} }
            public TTReportField NewField1111121112 { get {return Body().NewField1111121112;} }
            public TTReportField NewField1111121113 { get {return Body().NewField1111121113;} }
            public TTReportField NewField1111121114 { get {return Body().NewField1111121114;} }
            public TTReportField NewField1111121115 { get {return Body().NewField1111121115;} }
            public TTReportField NewField1111121116 { get {return Body().NewField1111121116;} }
            public TTReportField NewField1111121117 { get {return Body().NewField1111121117;} }
            public TTReportField BMIYES { get {return Body().BMIYES;} }
            public TTReportField SEVEREDISEASEINFOYES { get {return Body().SEVEREDISEASEINFOYES;} }
            public TTReportField THREEMONTHWEIGHTLOSSYES { get {return Body().THREEMONTHWEIGHTLOSSYES;} }
            public TTReportField WEEKLYINTAKEDECREASEYES { get {return Body().WEEKLYINTAKEDECREASEYES;} }
            public TTReportField NewField111213 { get {return Body().NewField111213;} }
            public TTReportField NewField1312111 { get {return Body().NewField1312111;} }
            public TTReportField NewField1312112 { get {return Body().NewField1312112;} }
            public TTReportField NewField12112131 { get {return Body().NewField12112131;} }
            public TTReportField NewField113121121 { get {return Body().NewField113121121;} }
            public TTReportField NewField11112131 { get {return Body().NewField11112131;} }
            public TTReportField NewField113121111 { get {return Body().NewField113121111;} }
            public TTReportField NewField1111121311 { get {return Body().NewField1111121311;} }
            public TTReportField BMINO { get {return Body().BMINO;} }
            public TTReportField SEVEREDISEASEINFO1 { get {return Body().SEVEREDISEASEINFO1;} }
            public TTReportField THREEMONTHWEIGHTLOSSNO { get {return Body().THREEMONTHWEIGHTLOSSNO;} }
            public TTReportField WEEKLYINTAKEDECREASE1 { get {return Body().WEEKLYINTAKEDECREASE1;} }
            public TTReportField NUTRITIONINTAKE0 { get {return Body().NUTRITIONINTAKE0;} }
            public TTReportField NUTRITIONINTAKE1 { get {return Body().NUTRITIONINTAKE1;} }
            public TTReportField NUTRITIONINTAKE2 { get {return Body().NUTRITIONINTAKE2;} }
            public TTReportField NUTRITIONINTAKE3 { get {return Body().NUTRITIONINTAKE3;} }
            public TTReportField DISEASELEVELHIGH { get {return Body().DISEASELEVELHIGH;} }
            public TTReportField DISEASELEVELLOW { get {return Body().DISEASELEVELLOW;} }
            public TTReportField DISEASELEVELMEDIUM { get {return Body().DISEASELEVELMEDIUM;} }
            public TTReportField DISEASELEVELNORMAL { get {return Body().DISEASELEVELNORMAL;} }
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
                list[0] = new TTReportNqlData<NursingNutritionalRiskAssessment.GetNursingNutritionalRiskAssessment_Class>("GetNursingNutritionalRiskAssessment", NursingNutritionalRiskAssessment.GetNursingNutritionalRiskAssessment((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.Parent.OBJECTID.CalcValue)));
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
                public NursingNTReport MyParentReport
                {
                    get { return (NursingNTReport)ParentReport; }
                }
                
                public TTReportField NewField11211;
                public TTReportField NewField111211;
                public TTReportField NewField1112111;
                public TTReportField NewField11112111;
                public TTReportField NewField111212;
                public TTReportField NewField1212111;
                public TTReportField NewField11112121;
                public TTReportField NewField112121111;
                public TTReportField NewField111121111;
                public TTReportField NewField1111121111;
                public TTReportField NewField1111121112;
                public TTReportField NewField1111121113;
                public TTReportField NewField1111121114;
                public TTReportField NewField1111121115;
                public TTReportField NewField1111121116;
                public TTReportField NewField1111121117;
                public TTReportField BMIYES;
                public TTReportField SEVEREDISEASEINFOYES;
                public TTReportField THREEMONTHWEIGHTLOSSYES;
                public TTReportField WEEKLYINTAKEDECREASEYES;
                public TTReportField NewField111213;
                public TTReportField NewField1312111;
                public TTReportField NewField1312112;
                public TTReportField NewField12112131;
                public TTReportField NewField113121121;
                public TTReportField NewField11112131;
                public TTReportField NewField113121111;
                public TTReportField NewField1111121311;
                public TTReportField BMINO;
                public TTReportField SEVEREDISEASEINFO1;
                public TTReportField THREEMONTHWEIGHTLOSSNO;
                public TTReportField WEEKLYINTAKEDECREASE1;
                public TTReportField NUTRITIONINTAKE0;
                public TTReportField NUTRITIONINTAKE1;
                public TTReportField NUTRITIONINTAKE2;
                public TTReportField NUTRITIONINTAKE3;
                public TTReportField DISEASELEVELHIGH;
                public TTReportField DISEASELEVELLOW;
                public TTReportField DISEASELEVELMEDIUM;
                public TTReportField DISEASELEVELNORMAL; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 124;
                    RepeatCount = 0;
                    
                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 8, 96, 13, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Vücut Kitle İndeksi (VKİ) < 20,5 kg/m2 mi?>";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 14, 96, 19, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"Hasta son 3 ayda kilo kaybetti mi?";

                    NewField1112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 20, 96, 25, false);
                    NewField1112111.Name = "NewField1112111";
                    NewField1112111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1112111.TextFont.Bold = true;
                    NewField1112111.TextFont.CharSet = 162;
                    NewField1112111.Value = @"Geçen Hafta Gıda Alımında Azalma Oldu Mu?";

                    NewField11112111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 26, 96, 31, false);
                    NewField11112111.Name = "NewField11112111";
                    NewField11112111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112111.TextFont.Bold = true;
                    NewField11112111.TextFont.CharSet = 162;
                    NewField11112111.Value = @"Hasta ileri derecede hasta mı? (Örneğin yoğun bakımda mı?)";

                    NewField111212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 1, 284, 6, false);
                    NewField111212.Name = "NewField111212";
                    NewField111212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111212.TextFont.Name = "Arial";
                    NewField111212.TextFont.Bold = true;
                    NewField111212.TextFont.CharSet = 162;
                    NewField111212.Value = @"Ön Değerlendirme";

                    NewField1212111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 32, 284, 37, false);
                    NewField1212111.Name = "NewField1212111";
                    NewField1212111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1212111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1212111.TextFont.Name = "Arial";
                    NewField1212111.TextFont.Bold = true;
                    NewField1212111.TextFont.CharSet = 162;
                    NewField1212111.Value = @"Esas Değerlendirme";

                    NewField11112121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 38, 142, 43, false);
                    NewField11112121.Name = "NewField11112121";
                    NewField11112121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11112121.TextFont.Name = "Arial";
                    NewField11112121.TextFont.Bold = true;
                    NewField11112121.TextFont.CharSet = 162;
                    NewField11112121.Value = @"Beslenme Durumunda Bozulma";

                    NewField112121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 38, 284, 43, false);
                    NewField112121111.Name = "NewField112121111";
                    NewField112121111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112121111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112121111.TextFont.Name = "Arial";
                    NewField112121111.TextFont.Bold = true;
                    NewField112121111.TextFont.CharSet = 162;
                    NewField112121111.Value = @"Hastalık Şiddeti";

                    NewField111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 45, 133, 50, false);
                    NewField111121111.Name = "NewField111121111";
                    NewField111121111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111121111.TextFont.Bold = true;
                    NewField111121111.TextFont.CharSet = 162;
                    NewField111121111.Value = @"Normal Beslenme Durumu";

                    NewField1111121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 51, 133, 56, false);
                    NewField1111121111.Name = "NewField1111121111";
                    NewField1111121111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111121111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111121111.NoClip = EvetHayirEnum.ehEvet;
                    NewField1111121111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111121111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1111121111.TextFont.Bold = true;
                    NewField1111121111.TextFont.CharSet = 162;
                    NewField1111121111.Value = @"3 ayda > %5 kilo kaybı veya geçen haftaki besin alımı normal gereksinimlerin %50-75\'inin altında";

                    NewField1111121112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 61, 133, 66, false);
                    NewField1111121112.Name = "NewField1111121112";
                    NewField1111121112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111121112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111121112.NoClip = EvetHayirEnum.ehEvet;
                    NewField1111121112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111121112.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1111121112.TextFont.Bold = true;
                    NewField1111121112.TextFont.CharSet = 162;
                    NewField1111121112.Value = @"2 ay içinde kilo kaybı > %5 kilo kaybı veya VKİ 18,5-20,5 + genel durum bozukluğu veya geçen haftaki besin alımı normal gereksinimlerin %25-50\'si";

                    NewField1111121113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 70, 133, 75, false);
                    NewField1111121113.Name = "NewField1111121113";
                    NewField1111121113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111121113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111121113.NoClip = EvetHayirEnum.ehEvet;
                    NewField1111121113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111121113.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1111121113.TextFont.Bold = true;
                    NewField1111121113.TextFont.CharSet = 162;
                    NewField1111121113.Value = @"1 ay içinde kilo kaybı > %5 (3 ayda > %15) veya VKİ 18,5 + genel durum bozukluğu veya geçen haftaki besin alımı normal ihtiyacının %0-25\'i";

                    NewField1111121114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 45, 263, 50, false);
                    NewField1111121114.Name = "NewField1111121114";
                    NewField1111121114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111121114.TextFont.Bold = true;
                    NewField1111121114.TextFont.CharSet = 162;
                    NewField1111121114.Value = @"Normal besin gereksinimi";

                    NewField1111121115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 51, 263, 56, false);
                    NewField1111121115.Name = "NewField1111121115";
                    NewField1111121115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111121115.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111121115.NoClip = EvetHayirEnum.ehEvet;
                    NewField1111121115.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111121115.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1111121115.TextFont.Bold = true;
                    NewField1111121115.TextFont.CharSet = 162;
                    NewField1111121115.Value = @"Kalça fraktürü, Özellikle akut komplikasyonları olan kronik hastalar: Siroz, KOAH, Kronik Hemodiyaliz, Diyabet, Onkoloji";

                    NewField1111121116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 61, 263, 66, false);
                    NewField1111121116.Name = "NewField1111121116";
                    NewField1111121116.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111121116.TextFont.Bold = true;
                    NewField1111121116.TextFont.CharSet = 162;
                    NewField1111121116.Value = @"Majör abdominal cerrahi, İnme, Şiddetli Pnömoni, Hematolojik Malignite";

                    NewField1111121117 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 67, 263, 72, false);
                    NewField1111121117.Name = "NewField1111121117";
                    NewField1111121117.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111121117.TextFont.Bold = true;
                    NewField1111121117.TextFont.CharSet = 162;
                    NewField1111121117.Value = @"Kafa travması, kemik iliği transplantasyonu, Yoğun Bakım hastaları (APACHE > 10)";

                    BMIYES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 8, 137, 13, false);
                    BMIYES.Name = "BMIYES";
                    BMIYES.DrawStyle = DrawStyleConstants.vbSolid;
                    BMIYES.FieldType = ReportFieldTypeEnum.ftVariable;
                    BMIYES.Value = @"";

                    SEVEREDISEASEINFOYES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 26, 137, 31, false);
                    SEVEREDISEASEINFOYES.Name = "SEVEREDISEASEINFOYES";
                    SEVEREDISEASEINFOYES.DrawStyle = DrawStyleConstants.vbSolid;
                    SEVEREDISEASEINFOYES.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEVEREDISEASEINFOYES.Value = @"";

                    THREEMONTHWEIGHTLOSSYES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 14, 137, 19, false);
                    THREEMONTHWEIGHTLOSSYES.Name = "THREEMONTHWEIGHTLOSSYES";
                    THREEMONTHWEIGHTLOSSYES.DrawStyle = DrawStyleConstants.vbSolid;
                    THREEMONTHWEIGHTLOSSYES.FieldType = ReportFieldTypeEnum.ftVariable;
                    THREEMONTHWEIGHTLOSSYES.Value = @"";

                    WEEKLYINTAKEDECREASEYES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 130, 20, 137, 25, false);
                    WEEKLYINTAKEDECREASEYES.Name = "WEEKLYINTAKEDECREASEYES";
                    WEEKLYINTAKEDECREASEYES.DrawStyle = DrawStyleConstants.vbSolid;
                    WEEKLYINTAKEDECREASEYES.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEEKLYINTAKEDECREASEYES.Value = @"";

                    NewField111213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 8, 127, 13, false);
                    NewField111213.Name = "NewField111213";
                    NewField111213.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111213.TextFont.Bold = true;
                    NewField111213.TextFont.CharSet = 162;
                    NewField111213.Value = @"EVET";

                    NewField1312111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 8, 168, 13, false);
                    NewField1312111.Name = "NewField1312111";
                    NewField1312111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1312111.TextFont.Bold = true;
                    NewField1312111.TextFont.CharSet = 162;
                    NewField1312111.Value = @"HAYIR";

                    NewField1312112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 14, 127, 19, false);
                    NewField1312112.Name = "NewField1312112";
                    NewField1312112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1312112.TextFont.Bold = true;
                    NewField1312112.TextFont.CharSet = 162;
                    NewField1312112.Value = @"EVET";

                    NewField12112131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 20, 127, 25, false);
                    NewField12112131.Name = "NewField12112131";
                    NewField12112131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12112131.TextFont.Bold = true;
                    NewField12112131.TextFont.CharSet = 162;
                    NewField12112131.Value = @"EVET";

                    NewField113121121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 26, 127, 31, false);
                    NewField113121121.Name = "NewField113121121";
                    NewField113121121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113121121.TextFont.Bold = true;
                    NewField113121121.TextFont.CharSet = 162;
                    NewField113121121.Value = @"EVET";

                    NewField11112131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 14, 168, 19, false);
                    NewField11112131.Name = "NewField11112131";
                    NewField11112131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11112131.TextFont.Bold = true;
                    NewField11112131.TextFont.CharSet = 162;
                    NewField11112131.Value = @"HAYIR";

                    NewField113121111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 20, 168, 25, false);
                    NewField113121111.Name = "NewField113121111";
                    NewField113121111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113121111.TextFont.Bold = true;
                    NewField113121111.TextFont.CharSet = 162;
                    NewField113121111.Value = @"HAYIR";

                    NewField1111121311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 26, 168, 31, false);
                    NewField1111121311.Name = "NewField1111121311";
                    NewField1111121311.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111121311.TextFont.Bold = true;
                    NewField1111121311.TextFont.CharSet = 162;
                    NewField1111121311.Value = @"HAYIR";

                    BMINO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 8, 178, 13, false);
                    BMINO.Name = "BMINO";
                    BMINO.DrawStyle = DrawStyleConstants.vbSolid;
                    BMINO.FieldType = ReportFieldTypeEnum.ftVariable;
                    BMINO.Value = @"";

                    SEVEREDISEASEINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 26, 178, 31, false);
                    SEVEREDISEASEINFO1.Name = "SEVEREDISEASEINFO1";
                    SEVEREDISEASEINFO1.DrawStyle = DrawStyleConstants.vbSolid;
                    SEVEREDISEASEINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEVEREDISEASEINFO1.Value = @"";

                    THREEMONTHWEIGHTLOSSNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 14, 178, 19, false);
                    THREEMONTHWEIGHTLOSSNO.Name = "THREEMONTHWEIGHTLOSSNO";
                    THREEMONTHWEIGHTLOSSNO.DrawStyle = DrawStyleConstants.vbSolid;
                    THREEMONTHWEIGHTLOSSNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    THREEMONTHWEIGHTLOSSNO.Value = @"";

                    WEEKLYINTAKEDECREASE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 20, 178, 25, false);
                    WEEKLYINTAKEDECREASE1.Name = "WEEKLYINTAKEDECREASE1";
                    WEEKLYINTAKEDECREASE1.DrawStyle = DrawStyleConstants.vbSolid;
                    WEEKLYINTAKEDECREASE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEEKLYINTAKEDECREASE1.Value = @"";

                    NUTRITIONINTAKE0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 45, 141, 50, false);
                    NUTRITIONINTAKE0.Name = "NUTRITIONINTAKE0";
                    NUTRITIONINTAKE0.DrawStyle = DrawStyleConstants.vbSolid;
                    NUTRITIONINTAKE0.FieldType = ReportFieldTypeEnum.ftVariable;
                    NUTRITIONINTAKE0.Value = @"";

                    NUTRITIONINTAKE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 51, 141, 56, false);
                    NUTRITIONINTAKE1.Name = "NUTRITIONINTAKE1";
                    NUTRITIONINTAKE1.DrawStyle = DrawStyleConstants.vbSolid;
                    NUTRITIONINTAKE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NUTRITIONINTAKE1.Value = @"";

                    NUTRITIONINTAKE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 61, 141, 66, false);
                    NUTRITIONINTAKE2.Name = "NUTRITIONINTAKE2";
                    NUTRITIONINTAKE2.DrawStyle = DrawStyleConstants.vbSolid;
                    NUTRITIONINTAKE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NUTRITIONINTAKE2.Value = @"";

                    NUTRITIONINTAKE3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 71, 141, 76, false);
                    NUTRITIONINTAKE3.Name = "NUTRITIONINTAKE3";
                    NUTRITIONINTAKE3.DrawStyle = DrawStyleConstants.vbSolid;
                    NUTRITIONINTAKE3.FieldType = ReportFieldTypeEnum.ftVariable;
                    NUTRITIONINTAKE3.Value = @"";

                    DISEASELEVELHIGH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 68, 273, 73, false);
                    DISEASELEVELHIGH.Name = "DISEASELEVELHIGH";
                    DISEASELEVELHIGH.DrawStyle = DrawStyleConstants.vbSolid;
                    DISEASELEVELHIGH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISEASELEVELHIGH.Value = @"";

                    DISEASELEVELLOW = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 51, 273, 56, false);
                    DISEASELEVELLOW.Name = "DISEASELEVELLOW";
                    DISEASELEVELLOW.DrawStyle = DrawStyleConstants.vbSolid;
                    DISEASELEVELLOW.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISEASELEVELLOW.Value = @"";

                    DISEASELEVELMEDIUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 61, 273, 66, false);
                    DISEASELEVELMEDIUM.Name = "DISEASELEVELMEDIUM";
                    DISEASELEVELMEDIUM.DrawStyle = DrawStyleConstants.vbSolid;
                    DISEASELEVELMEDIUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISEASELEVELMEDIUM.Value = @"";

                    DISEASELEVELNORMAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 266, 45, 273, 50, false);
                    DISEASELEVELNORMAL.Name = "DISEASELEVELNORMAL";
                    DISEASELEVELNORMAL.DrawStyle = DrawStyleConstants.vbSolid;
                    DISEASELEVELNORMAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISEASELEVELNORMAL.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NursingNutritionalRiskAssessment.GetNursingNutritionalRiskAssessment_Class dataset_GetNursingNutritionalRiskAssessment = ParentGroup.rsGroup.GetCurrentRecord<NursingNutritionalRiskAssessment.GetNursingNutritionalRiskAssessment_Class>(0);
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField111211.CalcValue = NewField111211.Value;
                    NewField1112111.CalcValue = NewField1112111.Value;
                    NewField11112111.CalcValue = NewField11112111.Value;
                    NewField111212.CalcValue = NewField111212.Value;
                    NewField1212111.CalcValue = NewField1212111.Value;
                    NewField11112121.CalcValue = NewField11112121.Value;
                    NewField112121111.CalcValue = NewField112121111.Value;
                    NewField111121111.CalcValue = NewField111121111.Value;
                    NewField1111121111.CalcValue = NewField1111121111.Value;
                    NewField1111121112.CalcValue = NewField1111121112.Value;
                    NewField1111121113.CalcValue = NewField1111121113.Value;
                    NewField1111121114.CalcValue = NewField1111121114.Value;
                    NewField1111121115.CalcValue = NewField1111121115.Value;
                    NewField1111121116.CalcValue = NewField1111121116.Value;
                    NewField1111121117.CalcValue = NewField1111121117.Value;
                    BMIYES.CalcValue = @"";
                    SEVEREDISEASEINFOYES.CalcValue = @"";
                    THREEMONTHWEIGHTLOSSYES.CalcValue = @"";
                    WEEKLYINTAKEDECREASEYES.CalcValue = @"";
                    NewField111213.CalcValue = NewField111213.Value;
                    NewField1312111.CalcValue = NewField1312111.Value;
                    NewField1312112.CalcValue = NewField1312112.Value;
                    NewField12112131.CalcValue = NewField12112131.Value;
                    NewField113121121.CalcValue = NewField113121121.Value;
                    NewField11112131.CalcValue = NewField11112131.Value;
                    NewField113121111.CalcValue = NewField113121111.Value;
                    NewField1111121311.CalcValue = NewField1111121311.Value;
                    BMINO.CalcValue = @"";
                    SEVEREDISEASEINFO1.CalcValue = @"";
                    THREEMONTHWEIGHTLOSSNO.CalcValue = @"";
                    WEEKLYINTAKEDECREASE1.CalcValue = @"";
                    NUTRITIONINTAKE0.CalcValue = @"";
                    NUTRITIONINTAKE1.CalcValue = @"";
                    NUTRITIONINTAKE2.CalcValue = @"";
                    NUTRITIONINTAKE3.CalcValue = @"";
                    DISEASELEVELHIGH.CalcValue = @"";
                    DISEASELEVELLOW.CalcValue = @"";
                    DISEASELEVELMEDIUM.CalcValue = @"";
                    DISEASELEVELNORMAL.CalcValue = @"";
                    return new TTReportObject[] { NewField11211,NewField111211,NewField1112111,NewField11112111,NewField111212,NewField1212111,NewField11112121,NewField112121111,NewField111121111,NewField1111121111,NewField1111121112,NewField1111121113,NewField1111121114,NewField1111121115,NewField1111121116,NewField1111121117,BMIYES,SEVEREDISEASEINFOYES,THREEMONTHWEIGHTLOSSYES,WEEKLYINTAKEDECREASEYES,NewField111213,NewField1312111,NewField1312112,NewField12112131,NewField113121121,NewField11112131,NewField113121111,NewField1111121311,BMINO,SEVEREDISEASEINFO1,THREEMONTHWEIGHTLOSSNO,WEEKLYINTAKEDECREASE1,NUTRITIONINTAKE0,NUTRITIONINTAKE1,NUTRITIONINTAKE2,NUTRITIONINTAKE3,DISEASELEVELHIGH,DISEASELEVELLOW,DISEASELEVELMEDIUM,DISEASELEVELNORMAL};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((NursingNTReport)ParentReport).Parent.OBJECTID.CalcValue;     
             NursingNutritionalRiskAssessment ntRisk = (NursingNutritionalRiskAssessment)context.GetObject(new Guid(sObjectID), "NursingNutritionalRiskAssessment");
                    if (ntRisk.BMI == true)
                        this.BMIYES.CalcValue = "X";
                    else if (ntRisk.BMI == false)
                        this.BMINO.CalcValue = "X";

                    if (ntRisk.ThreeMonthWeightLoss == true)
                        this.THREEMONTHWEIGHTLOSSYES.CalcValue = "X";
                    else if (ntRisk.ThreeMonthWeightLoss == false)
                        this.THREEMONTHWEIGHTLOSSNO.CalcValue = "X";

                    if (ntRisk.WeeklyIntakeDecrease == true)
                        this.WEEKLYINTAKEDECREASEYES.CalcValue = "X";
                    else if(ntRisk.WeeklyIntakeDecrease == false)
                        this.WEEKLYINTAKEDECREASE1.CalcValue = "X";

                    if (ntRisk.SevereDiseaseInfo == true)
                        this.SEVEREDISEASEINFOYES.CalcValue = "X";
                    if (ntRisk.SevereDiseaseInfo == false)
                        this.SEVEREDISEASEINFO1.CalcValue = "X";
                    if (ntRisk.NutritionIntake != null)
                    {
                        if (ntRisk.NutritionIntake.Value == NutritionIntakeAssessmentEnum.Normal)
                            this.NUTRITIONINTAKE0.CalcValue = "X";
                        else if (ntRisk.NutritionIntake.Value == NutritionIntakeAssessmentEnum.OneMonth)
                            this.NUTRITIONINTAKE3.CalcValue = "X";
                        else if (ntRisk.NutritionIntake.Value == NutritionIntakeAssessmentEnum.ThreeMonths)
                            this.NUTRITIONINTAKE1.CalcValue = "X";
                        else if (ntRisk.NutritionIntake.Value == NutritionIntakeAssessmentEnum.TwoMonths)
                            this.NUTRITIONINTAKE2.CalcValue = "X";
                    }
                    if (ntRisk.DiseaseLevelHigh == true)
                        this.DISEASELEVELHIGH.CalcValue = "X";

                    if (ntRisk.DiseaseLevelLow == true)
                        this.DISEASELEVELLOW.CalcValue = "X";

                    if (ntRisk.DiseaseLevelMedium == true)
                        this.DISEASELEVELMEDIUM.CalcValue = "X";

                    if (ntRisk.DiseaseLevelNormal == true)
                        this.DISEASELEVELNORMAL.CalcValue = "X";
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

        public NursingNTReport()
        {
            Parent = new ParentGroup(this,"Parent");
            HEADER = new HEADERGroup(Parent,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("Objects", "", "Nesne Listesi", @"", false, true, true, new Guid("4bf2cf68-3f04-49cf-b114-a88d422704bb"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("Objects"))
                _runtimeParameters.Objects = (List<string>)parameters["Objects"];
            Name = "NURSINGNTREPORT";
            Caption = "Nutrisyonel Risk Skoru Değerlendirme Formu";
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