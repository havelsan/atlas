
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
    public partial class ConsultationReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class Part1Group : TTReportGroup
        {
            public ConsultationReport MyParentReport
            {
                get { return (ConsultationReport)ParentReport; }
            }

            new public Part1GroupHeader Header()
            {
                return (Part1GroupHeader)_header;
            }

            new public Part1GroupFooter Footer()
            {
                return (Part1GroupFooter)_footer;
            }

            public TTReportField HospitalInfo { get {return Header().HospitalInfo;} }
            public TTReportField ReportName { get {return Header().ReportName;} }
            public Part1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Part1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new Part1GroupHeader(this);
                _footer = new Part1GroupFooter(this);

            }

            public partial class Part1GroupHeader : TTReportSection
            {
                public ConsultationReport MyParentReport
                {
                    get { return (ConsultationReport)ParentReport; }
                }
                
                public TTReportField HospitalInfo;
                public TTReportField ReportName; 
                public Part1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 46;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    HospitalInfo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 196, 29, false);
                    HospitalInfo.Name = "HospitalInfo";
                    HospitalInfo.FieldType = ReportFieldTypeEnum.ftExpression;
                    HospitalInfo.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HospitalInfo.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HospitalInfo.MultiLine = EvetHayirEnum.ehEvet;
                    HospitalInfo.WordBreak = EvetHayirEnum.ehEvet;
                    HospitalInfo.TextFont.Size = 14;
                    HospitalInfo.TextFont.Bold = true;
                    HospitalInfo.TextFont.CharSet = 162;
                    HospitalInfo.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 31, 196, 42, false);
                    ReportName.Name = "ReportName";
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Size = 15;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"KONSÜLTASYON RAPORU";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName.CalcValue = ReportName.Value;
                    HospitalInfo.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { ReportName,HospitalInfo};
                }
            }
            public partial class Part1GroupFooter : TTReportSection
            {
                public ConsultationReport MyParentReport
                {
                    get { return (ConsultationReport)ParentReport; }
                }
                 
                public Part1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 3;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public Part1Group Part1;

        public partial class Part2Group : TTReportGroup
        {
            public ConsultationReport MyParentReport
            {
                get { return (ConsultationReport)ParentReport; }
            }

            new public Part2GroupHeader Header()
            {
                return (Part2GroupHeader)_header;
            }

            new public Part2GroupFooter Footer()
            {
                return (Part2GroupFooter)_footer;
            }

            public TTReportField LBLUNIQUEREFNO { get {return Header().LBLUNIQUEREFNO;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField5 { get {return Header().NewField5;} }
            public TTReportField NewField6 { get {return Header().NewField6;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField19 { get {return Header().NewField19;} }
            public TTReportField UNIQUEREFNO { get {return Header().UNIQUEREFNO;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField BABAAD { get {return Header().BABAAD;} }
            public TTReportField DYERVETARIH { get {return Header().DYERVETARIH;} }
            public TTReportField SEX { get {return Header().SEX;} }
            public TTReportField dyer { get {return Header().dyer;} }
            public TTReportField dtarih { get {return Header().dtarih;} }
            public TTReportField NewField11221 { get {return Header().NewField11221;} }
            public TTReportField NewField11421 { get {return Header().NewField11421;} }
            public TTReportField NewField11621 { get {return Header().NewField11621;} }
            public TTReportField NewField11721 { get {return Header().NewField11721;} }
            public TTReportField NewField112211 { get {return Header().NewField112211;} }
            public TTReportField NewField113211 { get {return Header().NewField113211;} }
            public TTReportField NewField114211 { get {return Header().NewField114211;} }
            public TTReportField NewField115211 { get {return Header().NewField115211;} }
            public TTReportField PROTOKOLNO { get {return Header().PROTOKOLNO;} }
            public TTReportField HASTANO { get {return Header().HASTANO;} }
            public TTReportField ACTIONID { get {return Header().ACTIONID;} }
            public TTReportField TARIH { get {return Header().TARIH;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
            public TTReportField CONSULTATIONDATE { get {return Header().CONSULTATIONDATE;} }
            public TTReportField NewField153 { get {return Header().NewField153;} }
            public TTReportField CONSULTATIONREQUESTPROCEDUREDOCTOR { get {return Header().CONSULTATIONREQUESTPROCEDUREDOCTOR;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField CONSULTATIONREQUESTMASTERRESOURCE { get {return Header().CONSULTATIONREQUESTMASTERRESOURCE;} }
            public TTReportField NewField113 { get {return Header().NewField113;} }
            public TTReportField NewField123 { get {return Header().NewField123;} }
            public TTReportField MASTERRESOURCENAME { get {return Header().MASTERRESOURCENAME;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField PREDIAGNOSIS { get {return Header().PREDIAGNOSIS;} }
            public TTReportField NewField11831 { get {return Header().NewField11831;} }
            public TTReportShape NewLine1131 { get {return Header().NewLine1131;} }
            public TTReportField SECDIAGNOSIS { get {return Header().SECDIAGNOSIS;} }
            public TTReportField NewField11191 { get {return Footer().NewField11191;} }
            public TTReportField NewField11011 { get {return Footer().NewField11011;} }
            public TTReportShape NewLine111211 { get {return Footer().NewLine111211;} }
            public TTReportField DIPSIC { get {return Footer().DIPSIC;} }
            public TTReportField ADSOYADDOC { get {return Footer().ADSOYADDOC;} }
            public TTReportField UZMANLIKDAL { get {return Footer().UZMANLIKDAL;} }
            public TTReportField DIPSICLABEL { get {return Footer().DIPSICLABEL;} }
            public TTReportField UZ { get {return Footer().UZ;} }
            public TTReportField GOREV { get {return Footer().GOREV;} }
            public TTReportField DIPLOMANO { get {return Footer().DIPLOMANO;} }
            public TTReportField SICILKULLAN { get {return Footer().SICILKULLAN;} }
            public TTReportField UNVANKULLAN { get {return Footer().UNVANKULLAN;} }
            public TTReportField UNVAN { get {return Footer().UNVAN;} }
            public TTReportField SICILNO { get {return Footer().SICILNO;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public Part2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public Part2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<Consultation.GetConsultationReportNQL_Class>("GetConsultationReportNQL", Consultation.GetConsultationReportNQL((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new Part2GroupHeader(this);
                _footer = new Part2GroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class Part2GroupHeader : TTReportSection
            {
                public ConsultationReport MyParentReport
                {
                    get { return (ConsultationReport)ParentReport; }
                }
                
                public TTReportField LBLUNIQUEREFNO;
                public TTReportField NewField2;
                public TTReportField NewField3;
                public TTReportField NewField4;
                public TTReportField NewField5;
                public TTReportField NewField6;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField19;
                public TTReportField UNIQUEREFNO;
                public TTReportField ADSOYAD;
                public TTReportField BABAAD;
                public TTReportField DYERVETARIH;
                public TTReportField SEX;
                public TTReportField dyer;
                public TTReportField dtarih;
                public TTReportField NewField11221;
                public TTReportField NewField11421;
                public TTReportField NewField11621;
                public TTReportField NewField11721;
                public TTReportField NewField112211;
                public TTReportField NewField113211;
                public TTReportField NewField114211;
                public TTReportField NewField115211;
                public TTReportField PROTOKOLNO;
                public TTReportField HASTANO;
                public TTReportField ACTIONID;
                public TTReportField TARIH;
                public TTReportField NewField122;
                public TTReportField CONSULTATIONDATE;
                public TTReportField NewField153;
                public TTReportField CONSULTATIONREQUESTPROCEDUREDOCTOR;
                public TTReportField NewField141;
                public TTReportField NewField132;
                public TTReportField CONSULTATIONREQUESTMASTERRESOURCE;
                public TTReportField NewField113;
                public TTReportField NewField123;
                public TTReportField MASTERRESOURCENAME;
                public TTReportField NewField181;
                public TTReportField NewField142;
                public TTReportField PREDIAGNOSIS;
                public TTReportField NewField11831;
                public TTReportShape NewLine1131;
                public TTReportField SECDIAGNOSIS; 
                public Part2GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 85;
                    RepeatCount = 0;
                    
                    LBLUNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 2, 37, 7, false);
                    LBLUNIQUEREFNO.Name = "LBLUNIQUEREFNO";
                    LBLUNIQUEREFNO.TextFont.Size = 9;
                    LBLUNIQUEREFNO.TextFont.Bold = true;
                    LBLUNIQUEREFNO.TextFont.CharSet = 162;
                    LBLUNIQUEREFNO.Value = @"T.C. Kimlik No";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 8, 37, 13, false);
                    NewField2.Name = "NewField2";
                    NewField2.TextFont.Size = 9;
                    NewField2.TextFont.Bold = true;
                    NewField2.TextFont.CharSet = 162;
                    NewField2.Value = @"Adı Soyadı";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 14, 37, 19, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Size = 9;
                    NewField3.TextFont.Bold = true;
                    NewField3.TextFont.CharSet = 162;
                    NewField3.Value = @"Baba Adı";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 20, 37, 25, false);
                    NewField4.Name = "NewField4";
                    NewField4.TextFont.Size = 9;
                    NewField4.TextFont.Bold = true;
                    NewField4.TextFont.CharSet = 162;
                    NewField4.Value = @"Doğum Tarihi";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 26, 37, 31, false);
                    NewField5.Name = "NewField5";
                    NewField5.TextFont.Size = 9;
                    NewField5.TextFont.Bold = true;
                    NewField5.TextFont.CharSet = 162;
                    NewField5.Value = @"Cinsiyeti";

                    NewField6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 2, 39, 7, false);
                    NewField6.Name = "NewField6";
                    NewField6.TextFont.Bold = true;
                    NewField6.TextFont.CharSet = 162;
                    NewField6.Value = @":";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 8, 39, 13, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Bold = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @":";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 14, 39, 19, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Bold = true;
                    NewField17.TextFont.CharSet = 162;
                    NewField17.Value = @":";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 20, 39, 25, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Bold = true;
                    NewField18.TextFont.CharSet = 162;
                    NewField18.Value = @":";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 26, 39, 31, false);
                    NewField19.Name = "NewField19";
                    NewField19.TextFont.Bold = true;
                    NewField19.TextFont.CharSet = 162;
                    NewField19.Value = @":";

                    UNIQUEREFNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 2, 107, 7, false);
                    UNIQUEREFNO.Name = "UNIQUEREFNO";
                    UNIQUEREFNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIQUEREFNO.TextFont.Size = 9;
                    UNIQUEREFNO.TextFont.CharSet = 162;
                    UNIQUEREFNO.Value = @"";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 8, 107, 13, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.Size = 9;
                    ADSOYAD.TextFont.CharSet = 162;
                    ADSOYAD.Value = @"{#NAME#}  {#SURNAME#}";

                    BABAAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 14, 107, 19, false);
                    BABAAD.Name = "BABAAD";
                    BABAAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAAD.TextFont.Size = 9;
                    BABAAD.TextFont.CharSet = 162;
                    BABAAD.Value = @"{#FATHERNAME#}";

                    DYERVETARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 20, 107, 25, false);
                    DYERVETARIH.Name = "DYERVETARIH";
                    DYERVETARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DYERVETARIH.TextFont.Size = 9;
                    DYERVETARIH.TextFont.CharSet = 162;
                    DYERVETARIH.Value = @"{%dtarih%}";

                    SEX = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 26, 107, 31, false);
                    SEX.Name = "SEX";
                    SEX.FieldType = ReportFieldTypeEnum.ftVariable;
                    SEX.TextFont.Size = 9;
                    SEX.TextFont.CharSet = 162;
                    SEX.Value = @"{#SEX#}";

                    dyer = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 4, 243, 9, false);
                    dyer.Name = "dyer";
                    dyer.Visible = EvetHayirEnum.ehHayir;
                    dyer.FieldType = ReportFieldTypeEnum.ftVariable;
                    dyer.Value = @"{#COUNTRYOFBIRTH#}";

                    dtarih = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 12, 242, 17, false);
                    dtarih.Name = "dtarih";
                    dtarih.Visible = EvetHayirEnum.ehHayir;
                    dtarih.FieldType = ReportFieldTypeEnum.ftVariable;
                    dtarih.TextFormat = @"Short Date";
                    dtarih.Value = @"{#BIRTHDATE#}";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 8, 169, 13, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.TextFont.Size = 9;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @"Protokol No";

                    NewField11421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 14, 169, 19, false);
                    NewField11421.Name = "NewField11421";
                    NewField11421.TextFont.Size = 9;
                    NewField11421.TextFont.Bold = true;
                    NewField11421.TextFont.CharSet = 162;
                    NewField11421.Value = @"Hasta No";

                    NewField11621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 20, 169, 25, false);
                    NewField11621.Name = "NewField11621";
                    NewField11621.TextFont.Size = 9;
                    NewField11621.TextFont.Bold = true;
                    NewField11621.TextFont.CharSet = 162;
                    NewField11621.Value = @"İşlem No";

                    NewField11721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 2, 169, 7, false);
                    NewField11721.Name = "NewField11721";
                    NewField11721.TextFont.Size = 9;
                    NewField11721.TextFont.Bold = true;
                    NewField11721.TextFont.CharSet = 162;
                    NewField11721.Value = @"İstek Tarihi";

                    NewField112211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 20, 171, 25, false);
                    NewField112211.Name = "NewField112211";
                    NewField112211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112211.TextFont.Size = 9;
                    NewField112211.TextFont.Bold = true;
                    NewField112211.TextFont.CharSet = 162;
                    NewField112211.Value = @":";

                    NewField113211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 14, 171, 19, false);
                    NewField113211.Name = "NewField113211";
                    NewField113211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField113211.TextFont.Size = 9;
                    NewField113211.TextFont.Bold = true;
                    NewField113211.TextFont.CharSet = 162;
                    NewField113211.Value = @":";

                    NewField114211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 8, 171, 13, false);
                    NewField114211.Name = "NewField114211";
                    NewField114211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField114211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField114211.TextFont.Size = 9;
                    NewField114211.TextFont.Bold = true;
                    NewField114211.TextFont.CharSet = 162;
                    NewField114211.Value = @":";

                    NewField115211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 2, 171, 7, false);
                    NewField115211.Name = "NewField115211";
                    NewField115211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField115211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField115211.TextFont.Size = 9;
                    NewField115211.TextFont.Bold = true;
                    NewField115211.TextFont.CharSet = 162;
                    NewField115211.Value = @":";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 8, 202, 13, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"{#PROTOCOLNO#}";

                    HASTANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 14, 202, 19, false);
                    HASTANO.Name = "HASTANO";
                    HASTANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTANO.ObjectDefName = "Consultation";
                    HASTANO.DataMember = "EPISODE.PATIENT.ID";
                    HASTANO.TextFont.Size = 9;
                    HASTANO.TextFont.CharSet = 162;
                    HASTANO.Value = @"{@TTOBJECTID@}";

                    ACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 20, 202, 25, false);
                    ACTIONID.Name = "ACTIONID";
                    ACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTIONID.TextFont.Size = 9;
                    ACTIONID.TextFont.CharSet = 162;
                    ACTIONID.Value = @"{#ACTIONID#}";

                    TARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 2, 202, 7, false);
                    TARIH.Name = "TARIH";
                    TARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    TARIH.TextFormat = @"g";
                    TARIH.TextFont.Size = 9;
                    TARIH.TextFont.CharSet = 162;
                    TARIH.Value = @"{#EPISODEACTIONREQUESTDATE#}";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 46, 53, 51, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Size = 9;
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Konsültasyon Tarihi";

                    CONSULTATIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 46, 93, 51, false);
                    CONSULTATIONDATE.Name = "CONSULTATIONDATE";
                    CONSULTATIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSULTATIONDATE.TextFormat = @"g";
                    CONSULTATIONDATE.TextFont.Size = 9;
                    CONSULTATIONDATE.TextFont.CharSet = 162;
                    CONSULTATIONDATE.Value = @"{#CONSULTATIONDATE#}";

                    NewField153 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 46, 55, 51, false);
                    NewField153.Name = "NewField153";
                    NewField153.TextFont.Size = 9;
                    NewField153.TextFont.Bold = true;
                    NewField153.TextFont.CharSet = 162;
                    NewField153.Value = @":";

                    CONSULTATIONREQUESTPROCEDUREDOCTOR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 58, 203, 63, false);
                    CONSULTATIONREQUESTPROCEDUREDOCTOR.Name = "CONSULTATIONREQUESTPROCEDUREDOCTOR";
                    CONSULTATIONREQUESTPROCEDUREDOCTOR.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSULTATIONREQUESTPROCEDUREDOCTOR.TextFont.Size = 9;
                    CONSULTATIONREQUESTPROCEDUREDOCTOR.TextFont.CharSet = 162;
                    CONSULTATIONREQUESTPROCEDUREDOCTOR.Value = @"{#CONSREQUESTPROCEDUREDOCTOR#}";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 58, 53, 63, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Size = 9;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"İstek Yapan Doktor";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 58, 55, 63, false);
                    NewField132.Name = "NewField132";
                    NewField132.TextFont.Size = 9;
                    NewField132.TextFont.Bold = true;
                    NewField132.TextFont.CharSet = 162;
                    NewField132.Value = @":";

                    CONSULTATIONREQUESTMASTERRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 52, 203, 57, false);
                    CONSULTATIONREQUESTMASTERRESOURCE.Name = "CONSULTATIONREQUESTMASTERRESOURCE";
                    CONSULTATIONREQUESTMASTERRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSULTATIONREQUESTMASTERRESOURCE.TextFont.Size = 9;
                    CONSULTATIONREQUESTMASTERRESOURCE.TextFont.CharSet = 162;
                    CONSULTATIONREQUESTMASTERRESOURCE.Value = @"{#CONSREQUESTMASTERRESOURCE#}";

                    NewField113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 52, 53, 57, false);
                    NewField113.Name = "NewField113";
                    NewField113.TextFont.Size = 9;
                    NewField113.TextFont.Bold = true;
                    NewField113.TextFont.CharSet = 162;
                    NewField113.Value = @"İsteyen Bölüm";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 52, 55, 57, false);
                    NewField123.Name = "NewField123";
                    NewField123.TextFont.Size = 9;
                    NewField123.TextFont.Bold = true;
                    NewField123.TextFont.CharSet = 162;
                    NewField123.Value = @":";

                    MASTERRESOURCENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 64, 203, 69, false);
                    MASTERRESOURCENAME.Name = "MASTERRESOURCENAME";
                    MASTERRESOURCENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MASTERRESOURCENAME.TextFont.Size = 9;
                    MASTERRESOURCENAME.TextFont.CharSet = 162;
                    MASTERRESOURCENAME.Value = @"{#MASTERRESOURCENAME#}";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 64, 53, 69, false);
                    NewField181.Name = "NewField181";
                    NewField181.TextFont.Size = 9;
                    NewField181.TextFont.Bold = true;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @"İstenen Bölüm";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 64, 55, 69, false);
                    NewField142.Name = "NewField142";
                    NewField142.TextFont.Size = 9;
                    NewField142.TextFont.Bold = true;
                    NewField142.TextFont.CharSet = 162;
                    NewField142.Value = @":";

                    PREDIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 77, 203, 82, false);
                    PREDIAGNOSIS.Name = "PREDIAGNOSIS";
                    PREDIAGNOSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    PREDIAGNOSIS.MultiLine = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.NoClip = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.WordBreak = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.ExpandTabs = EvetHayirEnum.ehEvet;
                    PREDIAGNOSIS.TextFont.Size = 9;
                    PREDIAGNOSIS.TextFont.CharSet = 162;
                    PREDIAGNOSIS.Value = @"";

                    NewField11831 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 72, 54, 76, false);
                    NewField11831.Name = "NewField11831";
                    NewField11831.TextFont.Size = 9;
                    NewField11831.TextFont.Bold = true;
                    NewField11831.TextFont.CharSet = 162;
                    NewField11831.Value = @"Ön Tanı";

                    NewLine1131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 76, 54, 76, false);
                    NewLine1131.Name = "NewLine1131";
                    NewLine1131.DrawStyle = DrawStyleConstants.vbSolid;

                    SECDIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 31, 274, 40, false);
                    SECDIAGNOSIS.Name = "SECDIAGNOSIS";
                    SECDIAGNOSIS.Visible = EvetHayirEnum.ehHayir;
                    SECDIAGNOSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SECDIAGNOSIS.MultiLine = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.NoClip = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.WordBreak = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.ExpandTabs = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.TextFont.Size = 9;
                    SECDIAGNOSIS.TextFont.CharSet = 162;
                    SECDIAGNOSIS.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Consultation.GetConsultationReportNQL_Class dataset_GetConsultationReportNQL = ParentGroup.rsGroup.GetCurrentRecord<Consultation.GetConsultationReportNQL_Class>(0);
                    LBLUNIQUEREFNO.CalcValue = LBLUNIQUEREFNO.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField6.CalcValue = NewField6.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField19.CalcValue = NewField19.Value;
                    UNIQUEREFNO.CalcValue = @"";
                    ADSOYAD.CalcValue = (dataset_GetConsultationReportNQL != null ? Globals.ToStringCore(dataset_GetConsultationReportNQL.Name) : "") + @"  " + (dataset_GetConsultationReportNQL != null ? Globals.ToStringCore(dataset_GetConsultationReportNQL.Surname) : "");
                    BABAAD.CalcValue = (dataset_GetConsultationReportNQL != null ? Globals.ToStringCore(dataset_GetConsultationReportNQL.FatherName) : "");
                    dtarih.CalcValue = (dataset_GetConsultationReportNQL != null ? Globals.ToStringCore(dataset_GetConsultationReportNQL.BirthDate) : "");
                    DYERVETARIH.CalcValue = MyParentReport.Part2.dtarih.FormattedValue;
                    SEX.CalcValue = (dataset_GetConsultationReportNQL != null ? Globals.ToStringCore(dataset_GetConsultationReportNQL.Sex) : "");
                    dyer.CalcValue = (dataset_GetConsultationReportNQL != null ? Globals.ToStringCore(dataset_GetConsultationReportNQL.Countryofbirth) : "");
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField11421.CalcValue = NewField11421.Value;
                    NewField11621.CalcValue = NewField11621.Value;
                    NewField11721.CalcValue = NewField11721.Value;
                    NewField112211.CalcValue = NewField112211.Value;
                    NewField113211.CalcValue = NewField113211.Value;
                    NewField114211.CalcValue = NewField114211.Value;
                    NewField115211.CalcValue = NewField115211.Value;
                    PROTOKOLNO.CalcValue = (dataset_GetConsultationReportNQL != null ? Globals.ToStringCore(dataset_GetConsultationReportNQL.ProtocolNo) : "");
                    HASTANO.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    HASTANO.PostFieldValueCalculation();
                    ACTIONID.CalcValue = (dataset_GetConsultationReportNQL != null ? Globals.ToStringCore(dataset_GetConsultationReportNQL.Actionid) : "");
                    TARIH.CalcValue = (dataset_GetConsultationReportNQL != null ? Globals.ToStringCore(dataset_GetConsultationReportNQL.Episodeactionrequestdate) : "");
                    NewField122.CalcValue = NewField122.Value;
                    CONSULTATIONDATE.CalcValue = (dataset_GetConsultationReportNQL != null ? Globals.ToStringCore(dataset_GetConsultationReportNQL.Consultationdate) : "");
                    NewField153.CalcValue = NewField153.Value;
                    CONSULTATIONREQUESTPROCEDUREDOCTOR.CalcValue = (dataset_GetConsultationReportNQL != null ? Globals.ToStringCore(dataset_GetConsultationReportNQL.Consrequestproceduredoctor) : "");
                    NewField141.CalcValue = NewField141.Value;
                    NewField132.CalcValue = NewField132.Value;
                    CONSULTATIONREQUESTMASTERRESOURCE.CalcValue = (dataset_GetConsultationReportNQL != null ? Globals.ToStringCore(dataset_GetConsultationReportNQL.Consrequestmasterresource) : "");
                    NewField113.CalcValue = NewField113.Value;
                    NewField123.CalcValue = NewField123.Value;
                    MASTERRESOURCENAME.CalcValue = (dataset_GetConsultationReportNQL != null ? Globals.ToStringCore(dataset_GetConsultationReportNQL.Masterresourcename) : "");
                    NewField181.CalcValue = NewField181.Value;
                    NewField142.CalcValue = NewField142.Value;
                    PREDIAGNOSIS.CalcValue = @"";
                    NewField11831.CalcValue = NewField11831.Value;
                    SECDIAGNOSIS.CalcValue = @"";
                    return new TTReportObject[] { LBLUNIQUEREFNO,NewField2,NewField3,NewField4,NewField5,NewField6,NewField16,NewField17,NewField18,NewField19,UNIQUEREFNO,ADSOYAD,BABAAD,dtarih,DYERVETARIH,SEX,dyer,NewField11221,NewField11421,NewField11621,NewField11721,NewField112211,NewField113211,NewField114211,NewField115211,PROTOKOLNO,HASTANO,ACTIONID,TARIH,NewField122,CONSULTATIONDATE,NewField153,CONSULTATIONREQUESTPROCEDUREDOCTOR,NewField141,NewField132,CONSULTATIONREQUESTMASTERRESOURCE,NewField113,NewField123,MASTERRESOURCENAME,NewField181,NewField142,PREDIAGNOSIS,NewField11831,SECDIAGNOSIS};
                }

                public override void RunScript()
                {
#region PART2 HEADER_Script
                    int cnt = 1;
            TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
            Consultation consultation = (Consultation)objectContext.GetObject(new Guid(objectID),"Consultation");
            
           if (consultation.Episode.Patient.Foreign == true)
            {
                this.LBLUNIQUEREFNO.CalcValue = "Kimlik/Sigorta No";
            }
            else
            {
                this.LBLUNIQUEREFNO.CalcValue = "T.C. Kimlik No";
            }
            
            this.UNIQUEREFNO.CalcValue = consultation.Episode.Patient.RefNo;
            Episode episode = consultation.Episode;
            
            this.PREDIAGNOSIS.CalcValue = "";
            BindingList<DiagnosisGrid.GetPreDiagnosisByEpisodeAction_Class> preDiagnosis = null;
            preDiagnosis = DiagnosisGrid.GetPreDiagnosisByEpisodeAction(consultation.ObjectID.ToString());
            foreach(DiagnosisGrid.GetPreDiagnosisByEpisodeAction_Class preDiagnosisGrid in preDiagnosis)
            {
                this.PREDIAGNOSIS.CalcValue += cnt + ". " + preDiagnosisGrid.Code + " " + preDiagnosisGrid.Diagnosename;
                this.PREDIAGNOSIS.CalcValue += "\r\n";
                cnt++;
            }
            
            cnt = 1;
            this.SECDIAGNOSIS.CalcValue = "";
            BindingList<DiagnosisGrid.GetSecDiagnosisByEpisodeAction_Class> secDiagnosis = null;
            secDiagnosis = DiagnosisGrid.GetSecDiagnosisByEpisodeAction(consultation.ObjectID.ToString());
            foreach(DiagnosisGrid.GetSecDiagnosisByEpisodeAction_Class secDiagnosisGrid in secDiagnosis)
            {
                this.SECDIAGNOSIS.CalcValue += cnt + ". " + secDiagnosisGrid.Code + " " + secDiagnosisGrid.Diagnosename;
                this.SECDIAGNOSIS.CalcValue += "\r\n";
                cnt++;
            }
#endregion PART2 HEADER_Script
                }
            }
            public partial class Part2GroupFooter : TTReportSection
            {
                public ConsultationReport MyParentReport
                {
                    get { return (ConsultationReport)ParentReport; }
                }
                
                public TTReportField NewField11191;
                public TTReportField NewField11011;
                public TTReportShape NewLine111211;
                public TTReportField DIPSIC;
                public TTReportField ADSOYADDOC;
                public TTReportField UZMANLIKDAL;
                public TTReportField DIPSICLABEL;
                public TTReportField UZ;
                public TTReportField GOREV;
                public TTReportField DIPLOMANO;
                public TTReportField SICILKULLAN;
                public TTReportField UNVANKULLAN;
                public TTReportField UNVAN;
                public TTReportField SICILNO;
                public TTReportField PrintDate;
                public TTReportField PageNumber; 
                public Part2GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 41;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField11191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 1, 48, 6, false);
                    NewField11191.Name = "NewField11191";
                    NewField11191.TextFont.Size = 9;
                    NewField11191.TextFont.Bold = true;
                    NewField11191.TextFont.CharSet = 162;
                    NewField11191.Value = @"Muayene edildi. R.V.";

                    NewField11011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 8, 80, 13, false);
                    NewField11011.Name = "NewField11011";
                    NewField11011.TextFont.Size = 9;
                    NewField11011.TextFont.Bold = true;
                    NewField11011.TextFont.CharSet = 162;
                    NewField11011.Value = @"Konsültasyonu Yapan Tabip";

                    NewLine111211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 7, 203, 7, false);
                    NewLine111211.Name = "NewLine111211";
                    NewLine111211.DrawStyle = DrawStyleConstants.vbSolid;

                    DIPSIC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 17, 80, 21, false);
                    DIPSIC.Name = "DIPSIC";
                    DIPSIC.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSIC.TextFont.Size = 9;
                    DIPSIC.TextFont.CharSet = 162;
                    DIPSIC.Value = @"";

                    ADSOYADDOC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 13, 80, 17, false);
                    ADSOYADDOC.Name = "ADSOYADDOC";
                    ADSOYADDOC.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC.TextFont.Size = 9;
                    ADSOYADDOC.TextFont.CharSet = 162;
                    ADSOYADDOC.Value = @"{#PROCEDUREDOCTORNAME#}";

                    UZMANLIKDAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 14, 199, 18, false);
                    UZMANLIKDAL.Name = "UZMANLIKDAL";
                    UZMANLIKDAL.Visible = EvetHayirEnum.ehHayir;
                    UZMANLIKDAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZMANLIKDAL.MultiLine = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.NoClip = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.WordBreak = EvetHayirEnum.ehEvet;
                    UZMANLIKDAL.TextFont.Size = 9;
                    UZMANLIKDAL.TextFont.CharSet = 162;
                    UZMANLIKDAL.Value = @"{#DOCSPECIALITY#}";

                    DIPSICLABEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 17, 29, 21, false);
                    DIPSICLABEL.Name = "DIPSICLABEL";
                    DIPSICLABEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPSICLABEL.TextFont.Size = 9;
                    DIPSICLABEL.TextFont.CharSet = 162;
                    DIPSICLABEL.Value = @"DIPLOMASICIL";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 21, 80, 25, false);
                    UZ.Name = "UZ";
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.TextFont.Size = 9;
                    UZ.TextFont.CharSet = 162;
                    UZ.Value = @"{%UZMANLIKDAL%}";

                    GOREV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 13, 146, 18, false);
                    GOREV.Name = "GOREV";
                    GOREV.Visible = EvetHayirEnum.ehHayir;
                    GOREV.FieldType = ReportFieldTypeEnum.ftVariable;
                    GOREV.TextFont.Size = 9;
                    GOREV.TextFont.CharSet = 162;
                    GOREV.Value = @"{#DOCWORK#}";

                    DIPLOMANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 173, 22, 200, 26, false);
                    DIPLOMANO.Name = "DIPLOMANO";
                    DIPLOMANO.Visible = EvetHayirEnum.ehHayir;
                    DIPLOMANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMANO.TextFont.Size = 9;
                    DIPLOMANO.TextFont.CharSet = 162;
                    DIPLOMANO.Value = @"{#DOCDIPLOMANO#}";

                    SICILKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 18, 199, 22, false);
                    SICILKULLAN.Name = "SICILKULLAN";
                    SICILKULLAN.Visible = EvetHayirEnum.ehHayir;
                    SICILKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    SICILKULLAN.TextFont.Size = 9;
                    SICILKULLAN.TextFont.CharSet = 162;
                    SICILKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""SICILKULLAN"", """")";

                    UNVANKULLAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 22, 146, 26, false);
                    UNVANKULLAN.Name = "UNVANKULLAN";
                    UNVANKULLAN.Visible = EvetHayirEnum.ehHayir;
                    UNVANKULLAN.FieldType = ReportFieldTypeEnum.ftExpression;
                    UNVANKULLAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVANKULLAN.TextFont.Size = 9;
                    UNVANKULLAN.TextFont.CharSet = 162;
                    UNVANKULLAN.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""UNVANKULLAN"", """")";

                    UNVAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 18, 172, 23, false);
                    UNVAN.Name = "UNVAN";
                    UNVAN.Visible = EvetHayirEnum.ehHayir;
                    UNVAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNVAN.MultiLine = EvetHayirEnum.ehEvet;
                    UNVAN.NoClip = EvetHayirEnum.ehEvet;
                    UNVAN.WordBreak = EvetHayirEnum.ehEvet;
                    UNVAN.TextFont.Size = 9;
                    UNVAN.TextFont.CharSet = 162;
                    UNVAN.Value = @"{#DOCTITLE#}";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 146, 23, 173, 27, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.Visible = EvetHayirEnum.ehHayir;
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.TextFont.Size = 9;
                    SICILNO.TextFont.CharSet = 162;
                    SICILNO.Value = @"{#DOCEMPLOYMENTRECORDID#}";

                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 177, 7, 202, 12, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 92, 34, 117, 39, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"{@pagenumber@}/{@pagecount@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Consultation.GetConsultationReportNQL_Class dataset_GetConsultationReportNQL = ParentGroup.rsGroup.GetCurrentRecord<Consultation.GetConsultationReportNQL_Class>(0);
                    NewField11191.CalcValue = NewField11191.Value;
                    NewField11011.CalcValue = NewField11011.Value;
                    DIPSIC.CalcValue = @"";
                    ADSOYADDOC.CalcValue = (dataset_GetConsultationReportNQL != null ? Globals.ToStringCore(dataset_GetConsultationReportNQL.Proceduredoctorname) : "");
                    UZMANLIKDAL.CalcValue = (dataset_GetConsultationReportNQL != null ? Globals.ToStringCore(dataset_GetConsultationReportNQL.Docspeciality) : "");
                    DIPSICLABEL.CalcValue = @"DIPLOMASICIL";
                    UZ.CalcValue = MyParentReport.Part2.UZMANLIKDAL.CalcValue;
                    GOREV.CalcValue = (dataset_GetConsultationReportNQL != null ? Globals.ToStringCore(dataset_GetConsultationReportNQL.Docwork) : "");
                    DIPLOMANO.CalcValue = (dataset_GetConsultationReportNQL != null ? Globals.ToStringCore(dataset_GetConsultationReportNQL.Docdiplomano) : "");
                    UNVAN.CalcValue = (dataset_GetConsultationReportNQL != null ? Globals.ToStringCore(dataset_GetConsultationReportNQL.Doctitle) : "");
                    SICILNO.CalcValue = (dataset_GetConsultationReportNQL != null ? Globals.ToStringCore(dataset_GetConsultationReportNQL.Docemploymentrecordid) : "");
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    SICILKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "");
                    UNVANKULLAN.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("UNVANKULLAN", "");
                    return new TTReportObject[] { NewField11191,NewField11011,DIPSIC,ADSOYADDOC,UZMANLIKDAL,DIPSICLABEL,UZ,GOREV,DIPLOMANO,UNVAN,SICILNO,PrintDate,PageNumber,SICILKULLAN,UNVANKULLAN};
                }

                public override void RunScript()
                {
#region PART2 FOOTER_Script
                    if(this.SICILKULLAN.CalcValue=="TRUE")
            {
                this.DIPSICLABEL.CalcValue= "SİCİL NO :";
                this.DIPSIC.CalcValue=this.SICILNO.CalcValue;
            }
            else
            {
                this.DIPSICLABEL.CalcValue= "DİPLOMA NO :";
                this.DIPSIC.CalcValue=this.DIPLOMANO.CalcValue;
            }
#endregion PART2 FOOTER_Script
                }
            }

        }

        public Part2Group Part2;

        public partial class MAINGroup : TTReportGroup
        {
            public ConsultationReport MyParentReport
            {
                get { return (ConsultationReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField SECDIAGNOSIS { get {return Body().SECDIAGNOSIS;} }
            public TTReportField NewField113811 { get {return Body().NewField113811;} }
            public TTReportShape NewLine11311 { get {return Body().NewLine11311;} }
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
                public ConsultationReport MyParentReport
                {
                    get { return (ConsultationReport)ParentReport; }
                }
                
                public TTReportField SECDIAGNOSIS;
                public TTReportField NewField113811;
                public TTReportShape NewLine11311; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 17;
                    RepeatCount = 0;
                    
                    SECDIAGNOSIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 10, 203, 15, false);
                    SECDIAGNOSIS.Name = "SECDIAGNOSIS";
                    SECDIAGNOSIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    SECDIAGNOSIS.MultiLine = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.NoClip = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.WordBreak = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.ExpandTabs = EvetHayirEnum.ehEvet;
                    SECDIAGNOSIS.TextFont.Size = 9;
                    SECDIAGNOSIS.TextFont.CharSet = 162;
                    SECDIAGNOSIS.Value = @"{%Part2.SECDIAGNOSIS%}";

                    NewField113811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 5, 54, 9, false);
                    NewField113811.Name = "NewField113811";
                    NewField113811.TextFont.Size = 9;
                    NewField113811.TextFont.Bold = true;
                    NewField113811.TextFont.CharSet = 162;
                    NewField113811.Value = @"Tanı";

                    NewLine11311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 9, 54, 9, false);
                    NewLine11311.Name = "NewLine11311";
                    NewLine11311.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SECDIAGNOSIS.CalcValue = MyParentReport.Part2.SECDIAGNOSIS.CalcValue;
                    NewField113811.CalcValue = NewField113811.Value;
                    return new TTReportObject[] { SECDIAGNOSIS,NewField113811};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class RequestGroup : TTReportGroup
        {
            public ConsultationReport MyParentReport
            {
                get { return (ConsultationReport)ParentReport; }
            }

            new public RequestGroupBody Body()
            {
                return (RequestGroupBody)_body;
            }
            public TTReportField REQUESTDESCE { get {return Body().REQUESTDESCE;} }
            public TTReportField NewField1118311 { get {return Body().NewField1118311;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public RequestGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public RequestGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new RequestGroupBody(this);
            }

            public partial class RequestGroupBody : TTReportSection
            {
                public ConsultationReport MyParentReport
                {
                    get { return (ConsultationReport)ParentReport; }
                }
                
                public TTReportField REQUESTDESCE;
                public TTReportField NewField1118311;
                public TTReportShape NewLine1; 
                public RequestGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 15;
                    RepeatCount = 0;
                    
                    REQUESTDESCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 8, 203, 13, false);
                    REQUESTDESCE.Name = "REQUESTDESCE";
                    REQUESTDESCE.MultiLine = EvetHayirEnum.ehEvet;
                    REQUESTDESCE.NoClip = EvetHayirEnum.ehEvet;
                    REQUESTDESCE.WordBreak = EvetHayirEnum.ehEvet;
                    REQUESTDESCE.ExpandTabs = EvetHayirEnum.ehEvet;
                    REQUESTDESCE.TextFont.Size = 9;
                    REQUESTDESCE.TextFont.CharSet = 162;
                    REQUESTDESCE.Value = @"";

                    NewField1118311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 3, 54, 7, false);
                    NewField1118311.Name = "NewField1118311";
                    NewField1118311.TextFont.Size = 9;
                    NewField1118311.TextFont.Bold = true;
                    NewField1118311.TextFont.CharSet = 162;
                    NewField1118311.Value = @"İstek Açıklaması";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 7, 53, 7, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REQUESTDESCE.CalcValue = REQUESTDESCE.Value;
                    NewField1118311.CalcValue = NewField1118311.Value;
                    return new TTReportObject[] { REQUESTDESCE,NewField1118311};
                }
                public override void RunPreScript()
                {
#region REQUEST BODY_PreScript
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
            Consultation consultation = (Consultation)objectContext.GetObject(new Guid(objectID),"Consultation");
            if(consultation.RequestDescription != null)
                this.REQUESTDESCE.Value = TTReportTool.TTReport.HTMLtoText(consultation.RequestDescription.ToString());
            else
                this.REQUESTDESCE.Value = "";
#endregion REQUEST BODY_PreScript
                }
            }

        }

        public RequestGroup Request;

        public partial class ResultGroup : TTReportGroup
        {
            public ConsultationReport MyParentReport
            {
                get { return (ConsultationReport)ParentReport; }
            }

            new public ResultGroupBody Body()
            {
                return (ResultGroupBody)_body;
            }
            public TTReportField RESULTOFFERSS { get {return Body().RESULTOFFERSS;} }
            public TTReportField NewField11138111 { get {return Body().NewField11138111;} }
            public TTReportShape NewLine1113111 { get {return Body().NewLine1113111;} }
            public ResultGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public ResultGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new ResultGroupBody(this);
            }

            public partial class ResultGroupBody : TTReportSection
            {
                public ConsultationReport MyParentReport
                {
                    get { return (ConsultationReport)ParentReport; }
                }
                
                public TTReportField RESULTOFFERSS;
                public TTReportField NewField11138111;
                public TTReportShape NewLine1113111; 
                public ResultGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 14;
                    RepeatCount = 0;
                    
                    RESULTOFFERSS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 7, 203, 12, false);
                    RESULTOFFERSS.Name = "RESULTOFFERSS";
                    RESULTOFFERSS.MultiLine = EvetHayirEnum.ehEvet;
                    RESULTOFFERSS.NoClip = EvetHayirEnum.ehEvet;
                    RESULTOFFERSS.WordBreak = EvetHayirEnum.ehEvet;
                    RESULTOFFERSS.ExpandTabs = EvetHayirEnum.ehEvet;
                    RESULTOFFERSS.TextFont.Size = 9;
                    RESULTOFFERSS.TextFont.CharSet = 162;
                    RESULTOFFERSS.Value = @"";

                    NewField11138111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 7, 2, 54, 6, false);
                    NewField11138111.Name = "NewField11138111";
                    NewField11138111.TextFont.Size = 9;
                    NewField11138111.TextFont.Bold = true;
                    NewField11138111.TextFont.CharSet = 162;
                    NewField11138111.Value = @"Konsültasyon Sonucu ve Öneriler";

                    NewLine1113111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 6, 54, 6, false);
                    NewLine1113111.Name = "NewLine1113111";
                    NewLine1113111.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RESULTOFFERSS.CalcValue = RESULTOFFERSS.Value;
                    NewField11138111.CalcValue = NewField11138111.Value;
                    return new TTReportObject[] { RESULTOFFERSS,NewField11138111};
                }
                public override void RunPreScript()
                {
#region RESULT BODY_PreScript
                    TTObjectContext objectContext = new TTObjectContext(true);
            string objectID = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
            Consultation consultation = (Consultation)objectContext.GetObject(new Guid(objectID),"Consultation");
             if(consultation.ConsultationResultAndOffers != null)
                 this.RESULTOFFERSS.Value = TTReportTool.TTReport.HTMLtoText(consultation.ConsultationResultAndOffers.ToString());
             else
                 this.RESULTOFFERSS.Value = "";
#endregion RESULT BODY_PreScript
                }
            }

        }

        public ResultGroup Result;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public ConsultationReport()
        {
            Part1 = new Part1Group(this,"Part1");
            Part2 = new Part2Group(Part1,"Part2");
            MAIN = new MAINGroup(Part2,"MAIN");
            Request = new RequestGroup(Part2,"Request");
            Result = new ResultGroup(Part2,"Result");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "CONSULTATIONREPORT";
            Caption = "Konsültasyon Raporu";
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