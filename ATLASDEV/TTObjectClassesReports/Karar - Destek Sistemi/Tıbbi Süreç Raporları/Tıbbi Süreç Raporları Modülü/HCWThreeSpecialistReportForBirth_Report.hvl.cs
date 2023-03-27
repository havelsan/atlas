
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
    /// Yardımcı Üreme Teknikleri Uygulaması Üç Uzman Tabip İmzalı Rapor
    /// </summary>
    public partial class HCWThreeSpecialistReportForBirth : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PART1Group : TTReportGroup
        {
            public HCWThreeSpecialistReportForBirth MyParentReport
            {
                get { return (HCWThreeSpecialistReportForBirth)ParentReport; }
            }

            new public PART1GroupHeader Header()
            {
                return (PART1GroupHeader)_header;
            }

            new public PART1GroupFooter Footer()
            {
                return (PART1GroupFooter)_footer;
            }

            public TTReportField RAPOR12 { get {return Header().RAPOR12;} }
            public TTReportField XXXXXXBASLIK11 { get {return Header().XXXXXXBASLIK11;} }
            public TTReportField NewField102 { get {return Footer().NewField102;} }
            public TTReportField UZ { get {return Footer().UZ;} }
            public TTReportField ADSOYADDOC { get {return Footer().ADSOYADDOC;} }
            public TTReportField SINRUT { get {return Footer().SINRUT;} }
            public TTReportField ADSOYADDOC2 { get {return Footer().ADSOYADDOC2;} }
            public TTReportField UZ2 { get {return Footer().UZ2;} }
            public TTReportField SINRUT2 { get {return Footer().SINRUT2;} }
            public TTReportField ADSOYADDOC3 { get {return Footer().ADSOYADDOC3;} }
            public TTReportField UZ3 { get {return Footer().UZ3;} }
            public TTReportField SINRUT3 { get {return Footer().SINRUT3;} }
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
                public HCWThreeSpecialistReportForBirth MyParentReport
                {
                    get { return (HCWThreeSpecialistReportForBirth)ParentReport; }
                }
                
                public TTReportField RAPOR12;
                public TTReportField XXXXXXBASLIK11; 
                public PART1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 40;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    RAPOR12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 4, 33, 207, 40, false);
                    RAPOR12.Name = "RAPOR12";
                    RAPOR12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPOR12.VertAlign = VerticalAlignmentEnum.vaBottom;
                    RAPOR12.TextFont.Size = 14;
                    RAPOR12.TextFont.Bold = true;
                    RAPOR12.TextFont.CharSet = 162;
                    RAPOR12.Value = @"YARDIMCI ÜREME TEKNİKLERİ UYGULAMASI ÜÇ UZMAN TABİP İMZALI RAPORU";

                    XXXXXXBASLIK11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 10, 194, 33, false);
                    XXXXXXBASLIK11.Name = "XXXXXXBASLIK11";
                    XXXXXXBASLIK11.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK11.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK11.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK11.TextFont.Size = 11;
                    XXXXXXBASLIK11.TextFont.Bold = true;
                    XXXXXXBASLIK11.TextFont.CharSet = 162;
                    XXXXXXBASLIK11.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    RAPOR12.CalcValue = RAPOR12.Value;
                    XXXXXXBASLIK11.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { RAPOR12,XXXXXXBASLIK11};
                }
            }
            public partial class PART1GroupFooter : TTReportSection
            {
                public HCWThreeSpecialistReportForBirth MyParentReport
                {
                    get { return (HCWThreeSpecialistReportForBirth)ParentReport; }
                }
                
                public TTReportField NewField102;
                public TTReportField UZ;
                public TTReportField ADSOYADDOC;
                public TTReportField SINRUT;
                public TTReportField ADSOYADDOC2;
                public TTReportField UZ2;
                public TTReportField SINRUT2;
                public TTReportField ADSOYADDOC3;
                public TTReportField UZ3;
                public TTReportField SINRUT3; 
                public PART1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 42;
                    RepeatCount = 0;
                    
                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 4, 44, 9, false);
                    NewField102.Name = "NewField102";
                    NewField102.TextFont.Bold = true;
                    NewField102.TextFont.Underline = true;
                    NewField102.TextFont.CharSet = 162;
                    NewField102.Value = @"KURUL ÜYELERİ";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 20, 65, 24, false);
                    UZ.Name = "UZ";
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.TextFont.Size = 8;
                    UZ.TextFont.CharSet = 162;
                    UZ.Value = @"";

                    ADSOYADDOC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 12, 65, 16, false);
                    ADSOYADDOC.Name = "ADSOYADDOC";
                    ADSOYADDOC.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC.TextFont.Size = 8;
                    ADSOYADDOC.TextFont.CharSet = 162;
                    ADSOYADDOC.Value = @"";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 16, 65, 20, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.TextFont.Size = 8;
                    SINRUT.TextFont.CharSet = 162;
                    SINRUT.Value = @"";

                    ADSOYADDOC2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 12, 127, 16, false);
                    ADSOYADDOC2.Name = "ADSOYADDOC2";
                    ADSOYADDOC2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC2.TextFont.Size = 8;
                    ADSOYADDOC2.TextFont.CharSet = 162;
                    ADSOYADDOC2.Value = @"";

                    UZ2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 20, 127, 24, false);
                    UZ2.Name = "UZ2";
                    UZ2.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ2.MultiLine = EvetHayirEnum.ehEvet;
                    UZ2.NoClip = EvetHayirEnum.ehEvet;
                    UZ2.WordBreak = EvetHayirEnum.ehEvet;
                    UZ2.TextFont.Size = 8;
                    UZ2.TextFont.CharSet = 162;
                    UZ2.Value = @"";

                    SINRUT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 16, 127, 20, false);
                    SINRUT2.Name = "SINRUT2";
                    SINRUT2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT2.TextFont.Size = 8;
                    SINRUT2.TextFont.CharSet = 162;
                    SINRUT2.Value = @"";

                    ADSOYADDOC3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 12, 189, 16, false);
                    ADSOYADDOC3.Name = "ADSOYADDOC3";
                    ADSOYADDOC3.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC3.TextFont.Size = 8;
                    ADSOYADDOC3.TextFont.CharSet = 162;
                    ADSOYADDOC3.Value = @"";

                    UZ3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 20, 189, 24, false);
                    UZ3.Name = "UZ3";
                    UZ3.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ3.MultiLine = EvetHayirEnum.ehEvet;
                    UZ3.NoClip = EvetHayirEnum.ehEvet;
                    UZ3.WordBreak = EvetHayirEnum.ehEvet;
                    UZ3.TextFont.Size = 8;
                    UZ3.TextFont.CharSet = 162;
                    UZ3.Value = @"";

                    SINRUT3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 16, 189, 20, false);
                    SINRUT3.Name = "SINRUT3";
                    SINRUT3.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT3.TextFont.Size = 8;
                    SINRUT3.TextFont.CharSet = 162;
                    SINRUT3.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField102.CalcValue = NewField102.Value;
                    UZ.CalcValue = @"";
                    ADSOYADDOC.CalcValue = @"";
                    SINRUT.CalcValue = @"";
                    ADSOYADDOC2.CalcValue = @"";
                    UZ2.CalcValue = @"";
                    SINRUT2.CalcValue = @"";
                    ADSOYADDOC3.CalcValue = @"";
                    UZ3.CalcValue = @"";
                    SINRUT3.CalcValue = @"";
                    return new TTReportObject[] { NewField102,UZ,ADSOYADDOC,SINRUT,ADSOYADDOC2,UZ2,SINRUT2,ADSOYADDOC3,UZ3,SINRUT3};
                }

                public override void RunScript()
                {
#region PART1 FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HealthCommitteeWithThreeSpecialistReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommitteeWithThreeSpecialist hcw = (HealthCommitteeWithThreeSpecialist)context.GetObject(new Guid(sObjectID),"HealthCommitteeWithThreeSpecialist");
            
            if(hcw == null)
                throw new Exception("Rapor Sağlık Kurulu Üç İmza işlemi üzerinden alınmalıdır.\r\nReason: HealthCommitteeWithThreeSpecialist is null");
            
            //Uzmanlar
            this.ADSOYADDOC.CalcValue = hcw.Specialists[0].Specialist1.Name;
            string sClassRank = hcw.Specialists[0].Specialist1.MilitaryClass != null ? hcw.Specialists[0].Specialist1.MilitaryClass.Name : "";
            sClassRank += hcw.Specialists[0].Specialist1.Rank != null ? hcw.Specialists[0].Specialist1.Rank.Name : "";
            this.SINRUT.CalcValue = sClassRank;
            this.UZ.CalcValue = hcw.Specialists[0].Specialist1.Title.HasValue ? TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hcw.Specialists[0].Specialist1.Title.Value) : "";
            
            this.ADSOYADDOC2.CalcValue = hcw.Specialists[0].Specialist2.Name;
            string sClassRank2 = hcw.Specialists[0].Specialist2.MilitaryClass != null ? hcw.Specialists[0].Specialist2.MilitaryClass.Name : "";
            sClassRank2 += hcw.Specialists[0].Specialist2.Rank != null ? hcw.Specialists[0].Specialist2.Rank.Name : "";
            this.SINRUT2.CalcValue = sClassRank2;
            this.UZ2.CalcValue = hcw.Specialists[0].Specialist2.Title.HasValue ? TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hcw.Specialists[0].Specialist2.Title.Value) : "";
            
            this.ADSOYADDOC3.CalcValue = hcw.Specialists[0].Specialist3.Name;
            string sClassRank3 = hcw.Specialists[0].Specialist3.MilitaryClass != null ? hcw.Specialists[0].Specialist3.MilitaryClass.Name : "";
            sClassRank3 += hcw.Specialists[0].Specialist3.Rank != null ? hcw.Specialists[0].Specialist3.Rank.Name : "";
            this.SINRUT3.CalcValue = sClassRank3;
            this.UZ3.CalcValue = hcw.Specialists[0].Specialist3.Title.HasValue ? TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hcw.Specialists[0].Specialist3.Title.Value) : "";
#endregion PART1 FOOTER_Script
                }
            }

        }

        public PART1Group PART1;

        public partial class MAINGroup : TTReportGroup
        {
            public HCWThreeSpecialistReportForBirth MyParentReport
            {
                get { return (HCWThreeSpecialistReportForBirth)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField ABDBD { get {return Body().ABDBD;} }
            public TTReportField NewField1341 { get {return Body().NewField1341;} }
            public TTReportField NewField1441 { get {return Body().NewField1441;} }
            public TTReportField NewField1541 { get {return Body().NewField1541;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine15 { get {return Body().NewLine15;} }
            public TTReportField RAPORNOTARIH { get {return Body().RAPORNOTARIH;} }
            public TTReportField SKRAPNO { get {return Body().SKRAPNO;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportField NewField11431 { get {return Body().NewField11431;} }
            public TTReportField NewField11441 { get {return Body().NewField11441;} }
            public TTReportField NewField11451 { get {return Body().NewField11451;} }
            public TTReportShape NewLine1142 { get {return Body().NewLine1142;} }
            public TTReportField DOGTARYER { get {return Body().DOGTARYER;} }
            public TTReportField MAKAM { get {return Body().MAKAM;} }
            public TTReportField NewField11432 { get {return Body().NewField11432;} }
            public TTReportField NewField11442 { get {return Body().NewField11442;} }
            public TTReportField NewField11452 { get {return Body().NewField11452;} }
            public TTReportField HASTGIRISTAR { get {return Body().HASTGIRISTAR;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportShape NewLine131 { get {return Body().NewLine131;} }
            public TTReportField KARANTINANO { get {return Body().KARANTINANO;} }
            public TTReportField HASTAGRUBU { get {return Body().HASTAGRUBU;} }
            public TTReportShape NewLine1143 { get {return Body().NewLine1143;} }
            public TTReportField NewField113411 { get {return Body().NewField113411;} }
            public TTReportField NewField114411 { get {return Body().NewField114411;} }
            public TTReportField NewField115411 { get {return Body().NewField115411;} }
            public TTReportField XXXXXXDENCIKIS { get {return Body().XXXXXXDENCIKIS;} }
            public TTReportField ADRES { get {return Body().ADRES;} }
            public TTReportField ERADSOYAD { get {return Body().ERADSOYAD;} }
            public TTReportField NewField124411 { get {return Body().NewField124411;} }
            public TTReportField NewField125411 { get {return Body().NewField125411;} }
            public TTReportShape NewLine1121 { get {return Body().NewLine1121;} }
            public TTReportShape NewLine1131 { get {return Body().NewLine1131;} }
            public TTReportField INFERTILITE { get {return Body().INFERTILITE;} }
            public TTReportField OBSTETRIK { get {return Body().OBSTETRIK;} }
            public TTReportField NewField1114411 { get {return Body().NewField1114411;} }
            public TTReportShape NewLine111411 { get {return Body().NewLine111411;} }
            public TTReportField ERDOGTAR { get {return Body().ERDOGTAR;} }
            public TTReportShape NewLine11311 { get {return Body().NewLine11311;} }
            public TTReportField NewField11443 { get {return Body().NewField11443;} }
            public TTReportField NewField11444 { get {return Body().NewField11444;} }
            public TTReportField NewField11445 { get {return Body().NewField11445;} }
            public TTReportField NewField144411 { get {return Body().NewField144411;} }
            public TTReportField NewField154411 { get {return Body().NewField154411;} }
            public TTReportField NewField144412 { get {return Body().NewField144412;} }
            public TTReportField NewField154412 { get {return Body().NewField154412;} }
            public TTReportField NewField144413 { get {return Body().NewField144413;} }
            public TTReportField NewField154413 { get {return Body().NewField154413;} }
            public TTReportField NewField144414 { get {return Body().NewField144414;} }
            public TTReportField NewField154414 { get {return Body().NewField154414;} }
            public TTReportField SFIELD1 { get {return Body().SFIELD1;} }
            public TTReportField SFIELD11 { get {return Body().SFIELD11;} }
            public TTReportField SFIELD111 { get {return Body().SFIELD111;} }
            public TTReportField SFIELD12 { get {return Body().SFIELD12;} }
            public TTReportField SFIELD112 { get {return Body().SFIELD112;} }
            public TTReportField NewField1414441 { get {return Body().NewField1414441;} }
            public TTReportField NewField1414451 { get {return Body().NewField1414451;} }
            public TTReportField NewField11444141 { get {return Body().NewField11444141;} }
            public TTReportField NewField11544141 { get {return Body().NewField11544141;} }
            public TTReportField NewField11444142 { get {return Body().NewField11444142;} }
            public TTReportField NewField11544142 { get {return Body().NewField11544142;} }
            public TTReportField NewField11444143 { get {return Body().NewField11444143;} }
            public TTReportField NewField11544143 { get {return Body().NewField11544143;} }
            public TTReportField NewField11444144 { get {return Body().NewField11444144;} }
            public TTReportField NewField11544144 { get {return Body().NewField11544144;} }
            public TTReportField NewField144144411 { get {return Body().NewField144144411;} }
            public TTReportField NewField144144511 { get {return Body().NewField144144511;} }
            public TTReportField NewField144144412 { get {return Body().NewField144144412;} }
            public TTReportField NewField144144512 { get {return Body().NewField144144512;} }
            public TTReportField NewField1314441 { get {return Body().NewField1314441;} }
            public TTReportField NewField1314451 { get {return Body().NewField1314451;} }
            public TTReportField TANI { get {return Body().TANI;} }
            public TTReportField NewField11444131 { get {return Body().NewField11444131;} }
            public TTReportField NewField11544131 { get {return Body().NewField11544131;} }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public TTReportField RAPTAR { get {return Body().RAPTAR;} }
            public TTReportField ADSOYAD { get {return Body().ADSOYAD;} }
            public TTReportField DOGTAR { get {return Body().DOGTAR;} }
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
                list[0] = new TTReportNqlData<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class>("GetHCWithThreeSpecialist", HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist((string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public HCWThreeSpecialistReportForBirth MyParentReport
                {
                    get { return (HCWThreeSpecialistReportForBirth)ParentReport; }
                }
                
                public TTReportField ABDBD;
                public TTReportField NewField1341;
                public TTReportField NewField1441;
                public TTReportField NewField1541;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine15;
                public TTReportField RAPORNOTARIH;
                public TTReportField SKRAPNO;
                public TTReportShape NewLine1;
                public TTReportShape NewLine14;
                public TTReportField NewField11431;
                public TTReportField NewField11441;
                public TTReportField NewField11451;
                public TTReportShape NewLine1142;
                public TTReportField DOGTARYER;
                public TTReportField MAKAM;
                public TTReportField NewField11432;
                public TTReportField NewField11442;
                public TTReportField NewField11452;
                public TTReportField HASTGIRISTAR;
                public TTReportShape NewLine111;
                public TTReportShape NewLine121;
                public TTReportShape NewLine131;
                public TTReportField KARANTINANO;
                public TTReportField HASTAGRUBU;
                public TTReportShape NewLine1143;
                public TTReportField NewField113411;
                public TTReportField NewField114411;
                public TTReportField NewField115411;
                public TTReportField XXXXXXDENCIKIS;
                public TTReportField ADRES;
                public TTReportField ERADSOYAD;
                public TTReportField NewField124411;
                public TTReportField NewField125411;
                public TTReportShape NewLine1121;
                public TTReportShape NewLine1131;
                public TTReportField INFERTILITE;
                public TTReportField OBSTETRIK;
                public TTReportField NewField1114411;
                public TTReportShape NewLine111411;
                public TTReportField ERDOGTAR;
                public TTReportShape NewLine11311;
                public TTReportField NewField11443;
                public TTReportField NewField11444;
                public TTReportField NewField11445;
                public TTReportField NewField144411;
                public TTReportField NewField154411;
                public TTReportField NewField144412;
                public TTReportField NewField154412;
                public TTReportField NewField144413;
                public TTReportField NewField154413;
                public TTReportField NewField144414;
                public TTReportField NewField154414;
                public TTReportField SFIELD1;
                public TTReportField SFIELD11;
                public TTReportField SFIELD111;
                public TTReportField SFIELD12;
                public TTReportField SFIELD112;
                public TTReportField NewField1414441;
                public TTReportField NewField1414451;
                public TTReportField NewField11444141;
                public TTReportField NewField11544141;
                public TTReportField NewField11444142;
                public TTReportField NewField11544142;
                public TTReportField NewField11444143;
                public TTReportField NewField11544143;
                public TTReportField NewField11444144;
                public TTReportField NewField11544144;
                public TTReportField NewField144144411;
                public TTReportField NewField144144511;
                public TTReportField NewField144144412;
                public TTReportField NewField144144512;
                public TTReportField NewField1314441;
                public TTReportField NewField1314451;
                public TTReportField TANI;
                public TTReportField NewField11444131;
                public TTReportField NewField11544131;
                public TTReportField KARAR;
                public TTReportField RAPTAR;
                public TTReportField ADSOYAD;
                public TTReportField DOGTAR; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 152;
                    RepeatCount = 0;
                    
                    ABDBD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 15, 104, 24, false);
                    ABDBD.Name = "ABDBD";
                    ABDBD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ABDBD.MultiLine = EvetHayirEnum.ehEvet;
                    ABDBD.WordBreak = EvetHayirEnum.ehEvet;
                    ABDBD.ExpandTabs = EvetHayirEnum.ehEvet;
                    ABDBD.ObjectDefName = "ResSection";
                    ABDBD.DataMember = "NAME";
                    ABDBD.TextFont.Size = 8;
                    ABDBD.TextFont.CharSet = 162;
                    ABDBD.Value = @"{#BOLUMID#}";

                    NewField1341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 15, 43, 24, false);
                    NewField1341.Name = "NewField1341";
                    NewField1341.TextFont.Size = 8;
                    NewField1341.TextFont.CharSet = 162;
                    NewField1341.Value = @"ABD / DB";

                    NewField1441 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 27, 43, 31, false);
                    NewField1441.Name = "NewField1441";
                    NewField1441.TextFont.Size = 8;
                    NewField1441.TextFont.CharSet = 162;
                    NewField1441.Value = @"RAPOR NU VE TARİHİ";

                    NewField1541 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 33, 43, 37, false);
                    NewField1541.Name = "NewField1541";
                    NewField1541.TextFont.Size = 8;
                    NewField1541.TextFont.CharSet = 162;
                    NewField1541.Value = @"SAĞLIK KRL. RAP. NU";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 26, 205, 26, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 32, 205, 32, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 38, 205, 38, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 14, 205, 14, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;

                    RAPORNOTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 27, 104, 31, false);
                    RAPORNOTARIH.Name = "RAPORNOTARIH";
                    RAPORNOTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNOTARIH.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORNOTARIH.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORNOTARIH.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORNOTARIH.TextFont.Size = 8;
                    RAPORNOTARIH.TextFont.CharSet = 162;
                    RAPORNOTARIH.Value = @"{#RAPORNO#} / {%RAPTAR%}";

                    SKRAPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 33, 104, 37, false);
                    SKRAPNO.Name = "SKRAPNO";
                    SKRAPNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SKRAPNO.CaseFormat = CaseFormatEnum.fcTitleCase;
                    SKRAPNO.TextFont.Size = 8;
                    SKRAPNO.TextFont.CharSet = 162;
                    SKRAPNO.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 14, 7, 150, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 44, 14, 44, 68, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11431 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 15, 140, 24, false);
                    NewField11431.Name = "NewField11431";
                    NewField11431.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11431.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11431.TextFont.Size = 8;
                    NewField11431.TextFont.CharSet = 162;
                    NewField11431.Value = @"ADI SOYADI
TC KİMLİK NO";

                    NewField11441 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 27, 140, 31, false);
                    NewField11441.Name = "NewField11441";
                    NewField11441.TextFont.Size = 8;
                    NewField11441.TextFont.CharSet = 162;
                    NewField11441.Value = @"DOĞUM YERİ- TARİHİ";

                    NewField11451 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 33, 140, 37, false);
                    NewField11451.Name = "NewField11451";
                    NewField11451.TextFont.Size = 8;
                    NewField11451.TextFont.CharSet = 162;
                    NewField11451.Value = @"GÖNDEREN MAKAM";

                    NewLine1142 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 205, 14, 205, 150, false);
                    NewLine1142.Name = "NewLine1142";
                    NewLine1142.DrawStyle = DrawStyleConstants.vbSolid;

                    DOGTARYER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 27, 204, 31, false);
                    DOGTARYER.Name = "DOGTARYER";
                    DOGTARYER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGTARYER.MultiLine = EvetHayirEnum.ehEvet;
                    DOGTARYER.WordBreak = EvetHayirEnum.ehEvet;
                    DOGTARYER.ExpandTabs = EvetHayirEnum.ehEvet;
                    DOGTARYER.TextFont.Size = 8;
                    DOGTARYER.TextFont.CharSet = 162;
                    DOGTARYER.Value = @"{#DYERI#} / {%DOGTAR%}";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 33, 204, 37, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.CaseFormat = CaseFormatEnum.fcTitleCase;
                    MAKAM.TextFont.Size = 8;
                    MAKAM.TextFont.CharSet = 162;
                    MAKAM.Value = @"";

                    NewField11432 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 39, 43, 43, false);
                    NewField11432.Name = "NewField11432";
                    NewField11432.TextFont.Size = 8;
                    NewField11432.TextFont.CharSet = 162;
                    NewField11432.Value = @"XXXXXXYE GİRİŞ TARİHİ";

                    NewField11442 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 45, 43, 49, false);
                    NewField11442.Name = "NewField11442";
                    NewField11442.TextFont.Size = 8;
                    NewField11442.TextFont.CharSet = 162;
                    NewField11442.Value = @"KARANTİNA NU";

                    NewField11452 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 51, 43, 55, false);
                    NewField11452.Name = "NewField11452";
                    NewField11452.TextFont.Size = 8;
                    NewField11452.TextFont.CharSet = 162;
                    NewField11452.Value = @"HASTA GRUBU";

                    HASTGIRISTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 39, 104, 43, false);
                    HASTGIRISTAR.Name = "HASTGIRISTAR";
                    HASTGIRISTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTGIRISTAR.TextFormat = @"Short Date";
                    HASTGIRISTAR.MultiLine = EvetHayirEnum.ehEvet;
                    HASTGIRISTAR.NoClip = EvetHayirEnum.ehEvet;
                    HASTGIRISTAR.WordBreak = EvetHayirEnum.ehEvet;
                    HASTGIRISTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    HASTGIRISTAR.TextFont.Size = 8;
                    HASTGIRISTAR.TextFont.CharSet = 162;
                    HASTGIRISTAR.Value = @"{#HGIRISTARIHI#}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 44, 205, 44, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 50, 205, 50, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 56, 205, 56, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    KARANTINANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 45, 104, 49, false);
                    KARANTINANO.Name = "KARANTINANO";
                    KARANTINANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARANTINANO.MultiLine = EvetHayirEnum.ehEvet;
                    KARANTINANO.WordBreak = EvetHayirEnum.ehEvet;
                    KARANTINANO.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARANTINANO.TextFont.Size = 8;
                    KARANTINANO.TextFont.CharSet = 162;
                    KARANTINANO.Value = @"{#KARANTINANO#}";

                    HASTAGRUBU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 51, 104, 55, false);
                    HASTAGRUBU.Name = "HASTAGRUBU";
                    HASTAGRUBU.FieldType = ReportFieldTypeEnum.ftVariable;
                    HASTAGRUBU.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HASTAGRUBU.ObjectDefName = "PatientGroupEnum";
                    HASTAGRUBU.DataMember = "DISPLAYTEXT";
                    HASTAGRUBU.TextFont.Size = 8;
                    HASTAGRUBU.TextFont.CharSet = 162;
                    HASTAGRUBU.Value = @"{#HASTAGRUBU#}";

                    NewLine1143 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 104, 14, 104, 62, false);
                    NewLine1143.Name = "NewLine1143";
                    NewLine1143.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField113411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 39, 140, 43, false);
                    NewField113411.Name = "NewField113411";
                    NewField113411.TextFont.Size = 8;
                    NewField113411.TextFont.CharSet = 162;
                    NewField113411.Value = @"XXXXXXDEN ÇIKIŞ";

                    NewField114411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 45, 140, 49, false);
                    NewField114411.Name = "NewField114411";
                    NewField114411.TextFont.Size = 8;
                    NewField114411.TextFont.CharSet = 162;
                    NewField114411.Value = @"ADRESİ";

                    NewField115411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 51, 140, 55, false);
                    NewField115411.Name = "NewField115411";
                    NewField115411.TextFont.Size = 8;
                    NewField115411.TextFont.CharSet = 162;
                    NewField115411.Value = @"ERKEK AD SOYAD";

                    XXXXXXDENCIKIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 39, 204, 43, false);
                    XXXXXXDENCIKIS.Name = "XXXXXXDENCIKIS";
                    XXXXXXDENCIKIS.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXDENCIKIS.TextFormat = @"Short Date";
                    XXXXXXDENCIKIS.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXDENCIKIS.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXDENCIKIS.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXDENCIKIS.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXDENCIKIS.TextFont.Size = 8;
                    XXXXXXDENCIKIS.TextFont.CharSet = 162;
                    XXXXXXDENCIKIS.Value = @"{#HCIKISTARIHI#}";

                    ADRES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 45, 204, 49, false);
                    ADRES.Name = "ADRES";
                    ADRES.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRES.MultiLine = EvetHayirEnum.ehEvet;
                    ADRES.WordBreak = EvetHayirEnum.ehEvet;
                    ADRES.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADRES.TextFont.Size = 7;
                    ADRES.TextFont.CharSet = 162;
                    ADRES.Value = @"{#ADRES#}";

                    ERADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 51, 204, 55, false);
                    ERADSOYAD.Name = "ERADSOYAD";
                    ERADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ERADSOYAD.CaseFormat = CaseFormatEnum.fcTitleCase;
                    ERADSOYAD.TextFont.Size = 8;
                    ERADSOYAD.TextFont.CharSet = 162;
                    ERADSOYAD.Value = @"";

                    NewField124411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 57, 43, 61, false);
                    NewField124411.Name = "NewField124411";
                    NewField124411.TextFont.Size = 8;
                    NewField124411.TextFont.CharSet = 162;
                    NewField124411.Value = @"İNFERTİLİTE RAPORU";

                    NewField125411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 63, 43, 67, false);
                    NewField125411.Name = "NewField125411";
                    NewField125411.TextFont.Size = 8;
                    NewField125411.TextFont.CharSet = 162;
                    NewField125411.Value = @"OBSTETRİK ÖYKÜ";

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 62, 205, 62, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 68, 205, 68, false);
                    NewLine1131.Name = "NewLine1131";
                    NewLine1131.DrawStyle = DrawStyleConstants.vbSolid;

                    INFERTILITE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 57, 104, 61, false);
                    INFERTILITE.Name = "INFERTILITE";
                    INFERTILITE.FieldType = ReportFieldTypeEnum.ftVariable;
                    INFERTILITE.MultiLine = EvetHayirEnum.ehEvet;
                    INFERTILITE.WordBreak = EvetHayirEnum.ehEvet;
                    INFERTILITE.ExpandTabs = EvetHayirEnum.ehEvet;
                    INFERTILITE.TextFont.Size = 8;
                    INFERTILITE.TextFont.CharSet = 162;
                    INFERTILITE.Value = @"";

                    OBSTETRIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 63, 204, 67, false);
                    OBSTETRIK.Name = "OBSTETRIK";
                    OBSTETRIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBSTETRIK.CaseFormat = CaseFormatEnum.fcTitleCase;
                    OBSTETRIK.TextFont.Size = 8;
                    OBSTETRIK.TextFont.CharSet = 162;
                    OBSTETRIK.Value = @"";

                    NewField1114411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 57, 140, 61, false);
                    NewField1114411.Name = "NewField1114411";
                    NewField1114411.TextFont.Size = 8;
                    NewField1114411.TextFont.CharSet = 162;
                    NewField1114411.Value = @"ERKEK DOĞUM YERİ/TARİHİ";

                    NewLine111411 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 141, 14, 141, 62, false);
                    NewLine111411.Name = "NewLine111411";
                    NewLine111411.DrawStyle = DrawStyleConstants.vbSolid;

                    ERDOGTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 57, 204, 61, false);
                    ERDOGTAR.Name = "ERDOGTAR";
                    ERDOGTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ERDOGTAR.MultiLine = EvetHayirEnum.ehEvet;
                    ERDOGTAR.WordBreak = EvetHayirEnum.ehEvet;
                    ERDOGTAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    ERDOGTAR.TextFont.Size = 8;
                    ERDOGTAR.TextFont.CharSet = 162;
                    ERDOGTAR.Value = @"";

                    NewLine11311 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 7, 150, 205, 150, false);
                    NewLine11311.Name = "NewLine11311";
                    NewLine11311.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11443 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 69, 204, 73, false);
                    NewField11443.Name = "NewField11443";
                    NewField11443.TextFont.Size = 8;
                    NewField11443.TextFont.CharSet = 162;
                    NewField11443.Value = @"İNFERTİLİTE TESTLERİ";

                    NewField11444 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 75, 67, 79, false);
                    NewField11444.Name = "NewField11444";
                    NewField11444.TextFont.Size = 8;
                    NewField11444.TextFont.CharSet = 162;
                    NewField11444.Value = @"Total motil sperm sayısı";

                    NewField11445 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 75, 69, 79, false);
                    NewField11445.Name = "NewField11445";
                    NewField11445.TextFont.Size = 8;
                    NewField11445.TextFont.CharSet = 162;
                    NewField11445.Value = @":";

                    NewField144411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 80, 67, 84, false);
                    NewField144411.Name = "NewField144411";
                    NewField144411.TextFont.Size = 8;
                    NewField144411.TextFont.CharSet = 162;
                    NewField144411.Value = @"Midluteal progesteron (ng/mL)";

                    NewField154411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 80, 69, 84, false);
                    NewField154411.Name = "NewField154411";
                    NewField154411.TextFont.Size = 8;
                    NewField154411.TextFont.CharSet = 162;
                    NewField154411.Value = @":";

                    NewField144412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 85, 67, 89, false);
                    NewField144412.Name = "NewField144412";
                    NewField144412.TextFont.Size = 8;
                    NewField144412.TextFont.CharSet = 162;
                    NewField144412.Value = @"Erken folliküler 3.gün FSH";

                    NewField154412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 85, 69, 89, false);
                    NewField154412.Name = "NewField154412";
                    NewField154412.TextFont.Size = 8;
                    NewField154412.TextFont.CharSet = 162;
                    NewField154412.Value = @":";

                    NewField144413 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 90, 67, 94, false);
                    NewField144413.Name = "NewField144413";
                    NewField144413.TextFont.Size = 8;
                    NewField144413.TextFont.CharSet = 162;
                    NewField144413.Value = @"HSG (Kavite / tubal patents)";

                    NewField154413 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 90, 69, 94, false);
                    NewField154413.Name = "NewField154413";
                    NewField154413.TextFont.Size = 8;
                    NewField154413.TextFont.CharSet = 162;
                    NewField154413.Value = @":";

                    NewField144414 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 95, 67, 99, false);
                    NewField144414.Name = "NewField144414";
                    NewField144414.TextFont.Size = 8;
                    NewField144414.TextFont.CharSet = 162;
                    NewField144414.Value = @"ÖNCEKİ YÜT UYGULAMALARI";

                    NewField154414 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 95, 69, 99, false);
                    NewField154414.Name = "NewField154414";
                    NewField154414.TextFont.Size = 8;
                    NewField154414.TextFont.CharSet = 162;
                    NewField154414.Value = @":";

                    SFIELD1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 75, 204, 79, false);
                    SFIELD1.Name = "SFIELD1";
                    SFIELD1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SFIELD1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    SFIELD1.TextFont.Size = 8;
                    SFIELD1.TextFont.CharSet = 162;
                    SFIELD1.Value = @"";

                    SFIELD11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 80, 204, 84, false);
                    SFIELD11.Name = "SFIELD11";
                    SFIELD11.FieldType = ReportFieldTypeEnum.ftVariable;
                    SFIELD11.CaseFormat = CaseFormatEnum.fcTitleCase;
                    SFIELD11.TextFont.Size = 8;
                    SFIELD11.TextFont.CharSet = 162;
                    SFIELD11.Value = @"";

                    SFIELD111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 85, 204, 89, false);
                    SFIELD111.Name = "SFIELD111";
                    SFIELD111.FieldType = ReportFieldTypeEnum.ftVariable;
                    SFIELD111.CaseFormat = CaseFormatEnum.fcTitleCase;
                    SFIELD111.TextFont.Size = 8;
                    SFIELD111.TextFont.CharSet = 162;
                    SFIELD111.Value = @"";

                    SFIELD12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 90, 204, 94, false);
                    SFIELD12.Name = "SFIELD12";
                    SFIELD12.FieldType = ReportFieldTypeEnum.ftVariable;
                    SFIELD12.CaseFormat = CaseFormatEnum.fcTitleCase;
                    SFIELD12.TextFont.Size = 8;
                    SFIELD12.TextFont.CharSet = 162;
                    SFIELD12.Value = @"";

                    SFIELD112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 95, 204, 105, false);
                    SFIELD112.Name = "SFIELD112";
                    SFIELD112.FieldType = ReportFieldTypeEnum.ftVariable;
                    SFIELD112.CaseFormat = CaseFormatEnum.fcTitleCase;
                    SFIELD112.TextFont.Size = 8;
                    SFIELD112.TextFont.CharSet = 162;
                    SFIELD112.Value = @"";

                    NewField1414441 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 107, 37, 111, false);
                    NewField1414441.Name = "NewField1414441";
                    NewField1414441.TextFont.Size = 8;
                    NewField1414441.TextFont.CharSet = 162;
                    NewField1414441.Value = @"IUI";

                    NewField1414451 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 107, 39, 111, false);
                    NewField1414451.Name = "NewField1414451";
                    NewField1414451.TextFont.Size = 8;
                    NewField1414451.TextFont.CharSet = 162;
                    NewField1414451.Value = @":";

                    NewField11444141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 112, 37, 116, false);
                    NewField11444141.Name = "NewField11444141";
                    NewField11444141.TextFont.Size = 8;
                    NewField11444141.TextFont.CharSet = 162;
                    NewField11444141.Value = @"IVF";

                    NewField11544141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 112, 39, 116, false);
                    NewField11544141.Name = "NewField11544141";
                    NewField11544141.TextFont.Size = 8;
                    NewField11544141.TextFont.CharSet = 162;
                    NewField11544141.Value = @":";

                    NewField11444142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 107, 94, 111, false);
                    NewField11444142.Name = "NewField11444142";
                    NewField11444142.TextFont.Size = 8;
                    NewField11444142.TextFont.CharSet = 162;
                    NewField11444142.Value = @"Oosit";

                    NewField11544142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 107, 96, 111, false);
                    NewField11544142.Name = "NewField11544142";
                    NewField11544142.TextFont.Size = 8;
                    NewField11544142.TextFont.CharSet = 162;
                    NewField11544142.Value = @":";

                    NewField11444143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 112, 94, 116, false);
                    NewField11444143.Name = "NewField11444143";
                    NewField11444143.TextFont.Size = 8;
                    NewField11444143.TextFont.CharSet = 162;
                    NewField11444143.Value = @"Et";

                    NewField11544143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 112, 96, 116, false);
                    NewField11544143.Name = "NewField11544143";
                    NewField11544143.TextFont.Size = 8;
                    NewField11544143.TextFont.CharSet = 162;
                    NewField11544143.Value = @":";

                    NewField11444144 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 107, 143, 111, false);
                    NewField11444144.Name = "NewField11444144";
                    NewField11444144.TextFont.Size = 8;
                    NewField11444144.TextFont.CharSet = 162;
                    NewField11444144.Value = @"Gebelik";

                    NewField11544144 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 107, 145, 111, false);
                    NewField11544144.Name = "NewField11544144";
                    NewField11544144.TextFont.Size = 8;
                    NewField11544144.TextFont.CharSet = 162;
                    NewField11544144.Value = @":";

                    NewField144144411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 112, 143, 116, false);
                    NewField144144411.Name = "NewField144144411";
                    NewField144144411.TextFont.Size = 8;
                    NewField144144411.TextFont.CharSet = 162;
                    NewField144144411.Value = @"Yıl / Merkez";

                    NewField144144511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 143, 112, 145, 116, false);
                    NewField144144511.Name = "NewField144144511";
                    NewField144144511.TextFont.Size = 8;
                    NewField144144511.TextFont.CharSet = 162;
                    NewField144144511.Value = @":";

                    NewField144144412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 107, 186, 111, false);
                    NewField144144412.Name = "NewField144144412";
                    NewField144144412.TextFont.Size = 8;
                    NewField144144412.TextFont.CharSet = 162;
                    NewField144144412.Value = @"SUT";

                    NewField144144512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 186, 107, 188, 111, false);
                    NewField144144512.Name = "NewField144144512";
                    NewField144144512.TextFont.Size = 8;
                    NewField144144512.TextFont.CharSet = 162;
                    NewField144144512.Value = @":";

                    NewField1314441 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 127, 67, 131, false);
                    NewField1314441.Name = "NewField1314441";
                    NewField1314441.TextFont.Size = 8;
                    NewField1314441.TextFont.CharSet = 162;
                    NewField1314441.Value = @"TANI";

                    NewField1314451 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 127, 69, 131, false);
                    NewField1314451.Name = "NewField1314451";
                    NewField1314451.TextFont.Size = 8;
                    NewField1314451.TextFont.CharSet = 162;
                    NewField1314451.Value = @":";

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 127, 204, 136, false);
                    TANI.Name = "TANI";
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.CaseFormat = CaseFormatEnum.fcTitleCase;
                    TANI.TextFont.Size = 7;
                    TANI.TextFont.CharSet = 162;
                    TANI.Value = @"";

                    NewField11444131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 137, 67, 141, false);
                    NewField11444131.Name = "NewField11444131";
                    NewField11444131.TextFont.Size = 8;
                    NewField11444131.TextFont.CharSet = 162;
                    NewField11444131.Value = @"KARAR";

                    NewField11544131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 137, 69, 141, false);
                    NewField11544131.Name = "NewField11544131";
                    NewField11544131.TextFont.Size = 8;
                    NewField11544131.TextFont.CharSet = 162;
                    NewField11544131.Value = @":";

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 137, 204, 148, false);
                    KARAR.Name = "KARAR";
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.CaseFormat = CaseFormatEnum.fcTitleCase;
                    KARAR.TextFont.Size = 7;
                    KARAR.TextFont.CharSet = 162;
                    KARAR.Value = @"";

                    RAPTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 34, 247, 39, false);
                    RAPTAR.Name = "RAPTAR";
                    RAPTAR.Visible = EvetHayirEnum.ehHayir;
                    RAPTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPTAR.TextFormat = @"Short Date";
                    RAPTAR.Value = @"{#RAPORTARIHI#}";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 15, 204, 24, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.ObjectDefName = "Patient";
                    ADSOYAD.DataMember = "FullName";
                    ADSOYAD.Value = @"{#PATIENTID#}";

                    DOGTAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 222, 42, 247, 47, false);
                    DOGTAR.Name = "DOGTAR";
                    DOGTAR.Visible = EvetHayirEnum.ehHayir;
                    DOGTAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGTAR.TextFormat = @"Short Date";
                    DOGTAR.ObjectDefName = "Patient";
                    DOGTAR.DataMember = "BIRTHDATE";
                    DOGTAR.Value = @"{#PATIENTID#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class dataset_GetHCWithThreeSpecialist = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class>(0);
                    ABDBD.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Bolumid) : "");
                    ABDBD.PostFieldValueCalculation();
                    NewField1341.CalcValue = NewField1341.Value;
                    NewField1441.CalcValue = NewField1441.Value;
                    NewField1541.CalcValue = NewField1541.Value;
                    RAPTAR.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Raportarihi) : "");
                    RAPORNOTARIH.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Raporno) : "") + @" / " + MyParentReport.MAIN.RAPTAR.FormattedValue;
                    SKRAPNO.CalcValue = @"";
                    NewField11431.CalcValue = NewField11431.Value;
                    NewField11441.CalcValue = NewField11441.Value;
                    NewField11451.CalcValue = NewField11451.Value;
                    DOGTAR.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Patientid) : "");
                    DOGTAR.PostFieldValueCalculation();
                    DOGTARYER.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Dyeri) : "") + @" / " + MyParentReport.MAIN.DOGTAR.FormattedValue;
                    MAKAM.CalcValue = @"";
                    NewField11432.CalcValue = NewField11432.Value;
                    NewField11442.CalcValue = NewField11442.Value;
                    NewField11452.CalcValue = NewField11452.Value;
                    HASTGIRISTAR.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Hgiristarihi) : "");
                    KARANTINANO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Karantinano) : "");
                    HASTAGRUBU.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Hastagrubu) : "");
                    HASTAGRUBU.PostFieldValueCalculation();
                    NewField113411.CalcValue = NewField113411.Value;
                    NewField114411.CalcValue = NewField114411.Value;
                    NewField115411.CalcValue = NewField115411.Value;
                    XXXXXXDENCIKIS.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Hcikistarihi) : "");
                    ADRES.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Adres) : "");
                    ERADSOYAD.CalcValue = @"";
                    NewField124411.CalcValue = NewField124411.Value;
                    NewField125411.CalcValue = NewField125411.Value;
                    INFERTILITE.CalcValue = @"";
                    OBSTETRIK.CalcValue = @"";
                    NewField1114411.CalcValue = NewField1114411.Value;
                    ERDOGTAR.CalcValue = @"";
                    NewField11443.CalcValue = NewField11443.Value;
                    NewField11444.CalcValue = NewField11444.Value;
                    NewField11445.CalcValue = NewField11445.Value;
                    NewField144411.CalcValue = NewField144411.Value;
                    NewField154411.CalcValue = NewField154411.Value;
                    NewField144412.CalcValue = NewField144412.Value;
                    NewField154412.CalcValue = NewField154412.Value;
                    NewField144413.CalcValue = NewField144413.Value;
                    NewField154413.CalcValue = NewField154413.Value;
                    NewField144414.CalcValue = NewField144414.Value;
                    NewField154414.CalcValue = NewField154414.Value;
                    SFIELD1.CalcValue = @"";
                    SFIELD11.CalcValue = @"";
                    SFIELD111.CalcValue = @"";
                    SFIELD12.CalcValue = @"";
                    SFIELD112.CalcValue = @"";
                    NewField1414441.CalcValue = NewField1414441.Value;
                    NewField1414451.CalcValue = NewField1414451.Value;
                    NewField11444141.CalcValue = NewField11444141.Value;
                    NewField11544141.CalcValue = NewField11544141.Value;
                    NewField11444142.CalcValue = NewField11444142.Value;
                    NewField11544142.CalcValue = NewField11544142.Value;
                    NewField11444143.CalcValue = NewField11444143.Value;
                    NewField11544143.CalcValue = NewField11544143.Value;
                    NewField11444144.CalcValue = NewField11444144.Value;
                    NewField11544144.CalcValue = NewField11544144.Value;
                    NewField144144411.CalcValue = NewField144144411.Value;
                    NewField144144511.CalcValue = NewField144144511.Value;
                    NewField144144412.CalcValue = NewField144144412.Value;
                    NewField144144512.CalcValue = NewField144144512.Value;
                    NewField1314441.CalcValue = NewField1314441.Value;
                    NewField1314451.CalcValue = NewField1314451.Value;
                    TANI.CalcValue = @"";
                    NewField11444131.CalcValue = NewField11444131.Value;
                    NewField11544131.CalcValue = NewField11544131.Value;
                    KARAR.CalcValue = @"";
                    ADSOYAD.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Patientid) : "");
                    ADSOYAD.PostFieldValueCalculation();
                    return new TTReportObject[] { ABDBD,NewField1341,NewField1441,NewField1541,RAPTAR,RAPORNOTARIH,SKRAPNO,NewField11431,NewField11441,NewField11451,DOGTAR,DOGTARYER,MAKAM,NewField11432,NewField11442,NewField11452,HASTGIRISTAR,KARANTINANO,HASTAGRUBU,NewField113411,NewField114411,NewField115411,XXXXXXDENCIKIS,ADRES,ERADSOYAD,NewField124411,NewField125411,INFERTILITE,OBSTETRIK,NewField1114411,ERDOGTAR,NewField11443,NewField11444,NewField11445,NewField144411,NewField154411,NewField144412,NewField154412,NewField144413,NewField154413,NewField144414,NewField154414,SFIELD1,SFIELD11,SFIELD111,SFIELD12,SFIELD112,NewField1414441,NewField1414451,NewField11444141,NewField11544141,NewField11444142,NewField11544142,NewField11444143,NewField11544143,NewField11444144,NewField11544144,NewField144144411,NewField144144511,NewField144144412,NewField144144512,NewField1314441,NewField1314451,TANI,NewField11444131,NewField11544131,KARAR,ADSOYAD};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCWThreeSpecialistReportForBirth)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommitteeWithThreeSpecialist hcw = (HealthCommitteeWithThreeSpecialist)context.GetObject(new Guid(sObjectID),"HealthCommitteeWithThreeSpecialist");
            
            if(hcw == null)
                throw new Exception("Rapor Sağlık Kurulu Üç İmza işlemi üzerinden alınmalıdır.\r\nReason: HealthCommitteeWithThreeSpecialist is null");
            
            this.KARAR.CalcValue = TTObjectClasses.Common.GetTextOfRTFString(hcw.OfferofDecision);
            
            //Tanı
            int nCount = 1;
            this.TANI.CalcValue = "";
            BindingList<DiagnosisGrid.GetDiagnosisByParent_Class> pDiagnosis = DiagnosisGrid.GetDiagnosisByParent(sObjectID);
            foreach(DiagnosisGrid.GetDiagnosisByParent_Class pGrid in pDiagnosis)
            {
                this.TANI.CalcValue += nCount.ToString() + "- " + pGrid.Tanikodu + " " + pGrid.Taniadi;
                this.TANI.CalcValue += "\r\n";
                nCount++;
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

        public HCWThreeSpecialistReportForBirth()
        {
            PART1 = new PART1Group(this,"PART1");
            MAIN = new MAINGroup(PART1,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HCWTHREESPECIALISTREPORTFORBIRTH";
            Caption = "Yardımcı Üreme Teknikleri Uygulaması Üç Uzman Tabip İmzalı Rapor";
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