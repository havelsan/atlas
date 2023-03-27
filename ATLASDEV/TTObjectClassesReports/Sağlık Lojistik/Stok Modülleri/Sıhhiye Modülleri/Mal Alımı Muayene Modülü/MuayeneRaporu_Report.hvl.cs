
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
    /// Fonksiyon Muayenesi
    /// </summary>
    public partial class MuayeneRaporu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PART1Group : TTReportGroup
        {
            public MuayeneRaporu MyParentReport
            {
                get { return (MuayeneRaporu)ParentReport; }
            }

            new public PART1GroupHeader Header()
            {
                return (PART1GroupHeader)_header;
            }

            new public PART1GroupFooter Footer()
            {
                return (PART1GroupFooter)_footer;
            }

            public TTReportField XXXXXXIL { get {return Header().XXXXXXIL;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportRTF ReportRTF { get {return Header().ReportRTF;} }
            public TTReportField NewField11 { get {return Footer().NewField11;} }
            public TTReportField NewField172 { get {return Footer().NewField172;} }
            public TTReportField NewField1291 { get {return Footer().NewField1291;} }
            public TTReportField NewField1301 { get {return Footer().NewField1301;} }
            public TTReportField NewField1511 { get {return Footer().NewField1511;} }
            public TTReportField NewField1321 { get {return Footer().NewField1321;} }
            public TTReportField NewField1331 { get {return Footer().NewField1331;} }
            public TTReportField NewField1241 { get {return Footer().NewField1241;} }
            public TTReportField NewField11911 { get {return Footer().NewField11911;} }
            public TTReportField NewField11021 { get {return Footer().NewField11021;} }
            public TTReportField NewField11141 { get {return Footer().NewField11141;} }
            public TTReportField NewField11221 { get {return Footer().NewField11221;} }
            public TTReportField NewField11321 { get {return Footer().NewField11321;} }
            public TTReportField NewField1551 { get {return Footer().NewField1551;} }
            public TTReportField NewField11531 { get {return Footer().NewField11531;} }
            public TTReportField NewField11541 { get {return Footer().NewField11541;} }
            public TTReportField NewField113511 { get {return Footer().NewField113511;} }
            public TTReportField NewField123511 { get {return Footer().NewField123511;} }
            public TTReportField NewField114511 { get {return Footer().NewField114511;} }
            public TTReportField NAMESURNAME5 { get {return Footer().NAMESURNAME5;} }
            public TTReportField NAMESURNAME2 { get {return Footer().NAMESURNAME2;} }
            public TTReportField NAMESURNAME4 { get {return Footer().NAMESURNAME4;} }
            public TTReportField NAMESURNAME1 { get {return Footer().NAMESURNAME1;} }
            public TTReportField HOSPFUNC1 { get {return Footer().HOSPFUNC1;} }
            public TTReportField NAMESURNAME3 { get {return Footer().NAMESURNAME3;} }
            public TTReportField HOSPFUNC3 { get {return Footer().HOSPFUNC3;} }
            public TTReportField HOSPFUNC5 { get {return Footer().HOSPFUNC5;} }
            public TTReportField HOSPFUNC2 { get {return Footer().HOSPFUNC2;} }
            public TTReportField HOSPFUNC4 { get {return Footer().HOSPFUNC4;} }
            public TTReportField RECORDID1 { get {return Footer().RECORDID1;} }
            public TTReportField RECORDID2 { get {return Footer().RECORDID2;} }
            public TTReportField RECORDID3 { get {return Footer().RECORDID3;} }
            public TTReportField RECORDID4 { get {return Footer().RECORDID4;} }
            public TTReportField RECORDID5 { get {return Footer().RECORDID5;} }
            public PART1Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PART1Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<PurchaseExamination.GetByObjcetID_Class>("GetByObjcetID", PurchaseExamination.GetByObjcetID((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PART1GroupHeader(this);
                _footer = new PART1GroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PART1GroupHeader : TTReportSection
            {
                public MuayeneRaporu MyParentReport
                {
                    get { return (MuayeneRaporu)ParentReport; }
                }
                
                public TTReportField XXXXXXIL;
                public TTReportField NewField1;
                public TTReportRTF ReportRTF; 
                public PART1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 121;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXIL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 18, 190, 24, false);
                    XXXXXXIL.Name = "XXXXXXIL";
                    XXXXXXIL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXIL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXIL.TextFont.Size = 11;
                    XXXXXXIL.TextFont.Bold = true;
                    XXXXXXIL.Value = @"MUAYENE VE KABUL KOMİSYONU MUAYENE RAPORU";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 11, 41, 16, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.Underline = true;
                    NewField1.Value = @"TASNİF DIŞI";

                    ReportRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 10, 31, 190, 116, false);
                    ReportRTF.Name = "ReportRTF";
                    ReportRTF.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseExamination.GetByObjcetID_Class dataset_GetByObjcetID = ParentGroup.rsGroup.GetCurrentRecord<PurchaseExamination.GetByObjcetID_Class>(0);
                    XXXXXXIL.CalcValue = XXXXXXIL.Value;
                    NewField1.CalcValue = NewField1.Value;
                    ReportRTF.CalcValue = ReportRTF.Value;
                    return new TTReportObject[] { XXXXXXIL,NewField1,ReportRTF};
                }
                public override void RunPreScript()
                {
#region PART1 HEADER_PreScript
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((MuayeneRaporu)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PurchaseExamination purchaseExamination = (PurchaseExamination)context.GetObject(new Guid(sObjectID),"PurchaseExamination");
            this.ReportRTF.Value = purchaseExamination.GeneralInspectionFinalReport;
#endregion PART1 HEADER_PreScript
                }
            }
            public partial class PART1GroupFooter : TTReportSection
            {
                public MuayeneRaporu MyParentReport
                {
                    get { return (MuayeneRaporu)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField172;
                public TTReportField NewField1291;
                public TTReportField NewField1301;
                public TTReportField NewField1511;
                public TTReportField NewField1321;
                public TTReportField NewField1331;
                public TTReportField NewField1241;
                public TTReportField NewField11911;
                public TTReportField NewField11021;
                public TTReportField NewField11141;
                public TTReportField NewField11221;
                public TTReportField NewField11321;
                public TTReportField NewField1551;
                public TTReportField NewField11531;
                public TTReportField NewField11541;
                public TTReportField NewField113511;
                public TTReportField NewField123511;
                public TTReportField NewField114511;
                public TTReportField NAMESURNAME5;
                public TTReportField NAMESURNAME2;
                public TTReportField NAMESURNAME4;
                public TTReportField NAMESURNAME1;
                public TTReportField HOSPFUNC1;
                public TTReportField NAMESURNAME3;
                public TTReportField HOSPFUNC3;
                public TTReportField HOSPFUNC5;
                public TTReportField HOSPFUNC2;
                public TTReportField HOSPFUNC4;
                public TTReportField RECORDID1;
                public TTReportField RECORDID2;
                public TTReportField RECORDID3;
                public TTReportField RECORDID4;
                public TTReportField RECORDID5; 
                public PART1GroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 66;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 58, 41, 63, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.Underline = true;
                    NewField11.Value = @"TASNİF DIŞI";

                    NewField172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 35, 15, false);
                    NewField172.Name = "NewField172";
                    NewField172.Value = @"Görevi";

                    NewField1291 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 19, 35, 24, false);
                    NewField1291.Name = "NewField1291";
                    NewField1291.Value = @"İmzası";

                    NewField1301 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 28, 35, 33, false);
                    NewField1301.Name = "NewField1301";
                    NewField1301.Value = @"Rütbesi";

                    NewField1511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 34, 35, 39, false);
                    NewField1511.Name = "NewField1511";
                    NewField1511.Value = @"Adı Soyadı";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 40, 35, 45, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.Value = @"Sicil No";

                    NewField1331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 46, 35, 51, false);
                    NewField1331.Name = "NewField1331";
                    NewField1331.Value = @"Birliği";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 10, 36, 15, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.Value = @":";

                    NewField11911 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 19, 36, 24, false);
                    NewField11911.Name = "NewField11911";
                    NewField11911.Value = @":";

                    NewField11021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 28, 36, 33, false);
                    NewField11021.Name = "NewField11021";
                    NewField11021.Value = @":";

                    NewField11141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 34, 36, 39, false);
                    NewField11141.Name = "NewField11141";
                    NewField11141.Value = @":";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 40, 36, 45, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.Value = @":";

                    NewField11321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 46, 36, 51, false);
                    NewField11321.Name = "NewField11321";
                    NewField11321.Value = @":";

                    NewField1551 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 10, 68, 15, false);
                    NewField1551.Name = "NewField1551";
                    NewField1551.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1551.Value = @"BAŞKAN";

                    NewField11531 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 10, 101, 15, false);
                    NewField11531.Name = "NewField11531";
                    NewField11531.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11531.Value = @"ÜYE";

                    NewField11541 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 10, 134, 15, false);
                    NewField11541.Name = "NewField11541";
                    NewField11541.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11541.Value = @"ÜYE";

                    NewField113511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 3, 200, 8, false);
                    NewField113511.Name = "NewField113511";
                    NewField113511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113511.TextFont.Bold = true;
                    NewField113511.TextFont.Underline = true;
                    NewField113511.Value = @"MUAYENE KABUL KOMİSYONU";

                    NewField123511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 10, 167, 15, false);
                    NewField123511.Name = "NewField123511";
                    NewField123511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField123511.Value = @"ÜYE";

                    NewField114511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 10, 200, 15, false);
                    NewField114511.Name = "NewField114511";
                    NewField114511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField114511.Value = @"ÜYE";

                    NAMESURNAME5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 34, 200, 39, false);
                    NAMESURNAME5.Name = "NAMESURNAME5";
                    NAMESURNAME5.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME5.CaseFormat = CaseFormatEnum.fcNameSurname;
                    NAMESURNAME5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME5.TextFont.Size = 8;
                    NAMESURNAME5.Value = @"";

                    NAMESURNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 34, 101, 39, false);
                    NAMESURNAME2.Name = "NAMESURNAME2";
                    NAMESURNAME2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME2.CaseFormat = CaseFormatEnum.fcNameSurname;
                    NAMESURNAME2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME2.TextFont.Size = 8;
                    NAMESURNAME2.Value = @"";

                    NAMESURNAME4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 34, 167, 39, false);
                    NAMESURNAME4.Name = "NAMESURNAME4";
                    NAMESURNAME4.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME4.CaseFormat = CaseFormatEnum.fcNameSurname;
                    NAMESURNAME4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME4.TextFont.Size = 8;
                    NAMESURNAME4.Value = @"";

                    NAMESURNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 34, 68, 39, false);
                    NAMESURNAME1.Name = "NAMESURNAME1";
                    NAMESURNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME1.CaseFormat = CaseFormatEnum.fcNameSurname;
                    NAMESURNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME1.TextFont.Size = 8;
                    NAMESURNAME1.Value = @"";

                    HOSPFUNC1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 28, 68, 33, false);
                    HOSPFUNC1.Name = "HOSPFUNC1";
                    HOSPFUNC1.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC1.TextFont.Size = 8;
                    HOSPFUNC1.Value = @"";

                    NAMESURNAME3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 34, 134, 39, false);
                    NAMESURNAME3.Name = "NAMESURNAME3";
                    NAMESURNAME3.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME3.CaseFormat = CaseFormatEnum.fcNameSurname;
                    NAMESURNAME3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME3.TextFont.Size = 8;
                    NAMESURNAME3.Value = @"";

                    HOSPFUNC3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 28, 134, 33, false);
                    HOSPFUNC3.Name = "HOSPFUNC3";
                    HOSPFUNC3.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC3.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC3.TextFont.Size = 8;
                    HOSPFUNC3.Value = @"";

                    HOSPFUNC5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 28, 200, 33, false);
                    HOSPFUNC5.Name = "HOSPFUNC5";
                    HOSPFUNC5.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC5.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC5.TextFont.Size = 8;
                    HOSPFUNC5.Value = @"";

                    HOSPFUNC2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 28, 101, 33, false);
                    HOSPFUNC2.Name = "HOSPFUNC2";
                    HOSPFUNC2.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC2.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC2.TextFont.Size = 8;
                    HOSPFUNC2.Value = @"";

                    HOSPFUNC4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 28, 167, 33, false);
                    HOSPFUNC4.Name = "HOSPFUNC4";
                    HOSPFUNC4.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC4.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC4.TextFont.Size = 8;
                    HOSPFUNC4.Value = @"";

                    RECORDID1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 40, 68, 45, false);
                    RECORDID1.Name = "RECORDID1";
                    RECORDID1.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECORDID1.CaseFormat = CaseFormatEnum.fcNameSurname;
                    RECORDID1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RECORDID1.TextFont.Size = 8;
                    RECORDID1.Value = @"";

                    RECORDID2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 40, 101, 45, false);
                    RECORDID2.Name = "RECORDID2";
                    RECORDID2.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECORDID2.CaseFormat = CaseFormatEnum.fcNameSurname;
                    RECORDID2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RECORDID2.TextFont.Size = 8;
                    RECORDID2.Value = @"";

                    RECORDID3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 40, 134, 45, false);
                    RECORDID3.Name = "RECORDID3";
                    RECORDID3.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECORDID3.CaseFormat = CaseFormatEnum.fcNameSurname;
                    RECORDID3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RECORDID3.TextFont.Size = 8;
                    RECORDID3.Value = @"";

                    RECORDID4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 40, 167, 45, false);
                    RECORDID4.Name = "RECORDID4";
                    RECORDID4.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECORDID4.CaseFormat = CaseFormatEnum.fcNameSurname;
                    RECORDID4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RECORDID4.TextFont.Size = 8;
                    RECORDID4.Value = @"";

                    RECORDID5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 169, 40, 200, 45, false);
                    RECORDID5.Name = "RECORDID5";
                    RECORDID5.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECORDID5.CaseFormat = CaseFormatEnum.fcNameSurname;
                    RECORDID5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RECORDID5.TextFont.Size = 8;
                    RECORDID5.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseExamination.GetByObjcetID_Class dataset_GetByObjcetID = ParentGroup.rsGroup.GetCurrentRecord<PurchaseExamination.GetByObjcetID_Class>(0);
                    NewField11.CalcValue = NewField11.Value;
                    NewField172.CalcValue = NewField172.Value;
                    NewField1291.CalcValue = NewField1291.Value;
                    NewField1301.CalcValue = NewField1301.Value;
                    NewField1511.CalcValue = NewField1511.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    NewField1331.CalcValue = NewField1331.Value;
                    NewField1241.CalcValue = NewField1241.Value;
                    NewField11911.CalcValue = NewField11911.Value;
                    NewField11021.CalcValue = NewField11021.Value;
                    NewField11141.CalcValue = NewField11141.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField11321.CalcValue = NewField11321.Value;
                    NewField1551.CalcValue = NewField1551.Value;
                    NewField11531.CalcValue = NewField11531.Value;
                    NewField11541.CalcValue = NewField11541.Value;
                    NewField113511.CalcValue = NewField113511.Value;
                    NewField123511.CalcValue = NewField123511.Value;
                    NewField114511.CalcValue = NewField114511.Value;
                    NAMESURNAME5.CalcValue = @"";
                    NAMESURNAME2.CalcValue = @"";
                    NAMESURNAME4.CalcValue = @"";
                    NAMESURNAME1.CalcValue = @"";
                    HOSPFUNC1.CalcValue = @"";
                    NAMESURNAME3.CalcValue = @"";
                    HOSPFUNC3.CalcValue = @"";
                    HOSPFUNC5.CalcValue = @"";
                    HOSPFUNC2.CalcValue = @"";
                    HOSPFUNC4.CalcValue = @"";
                    RECORDID1.CalcValue = @"";
                    RECORDID2.CalcValue = @"";
                    RECORDID3.CalcValue = @"";
                    RECORDID4.CalcValue = @"";
                    RECORDID5.CalcValue = @"";
                    return new TTReportObject[] { NewField11,NewField172,NewField1291,NewField1301,NewField1511,NewField1321,NewField1331,NewField1241,NewField11911,NewField11021,NewField11141,NewField11221,NewField11321,NewField1551,NewField11531,NewField11541,NewField113511,NewField123511,NewField114511,NAMESURNAME5,NAMESURNAME2,NAMESURNAME4,NAMESURNAME1,HOSPFUNC1,NAMESURNAME3,HOSPFUNC3,HOSPFUNC5,HOSPFUNC2,HOSPFUNC4,RECORDID1,RECORDID2,RECORDID3,RECORDID4,RECORDID5};
                }

                public override void RunScript()
                {
#region PART1 FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((MuayeneRaporu)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PurchaseExamination pp = (PurchaseExamination)context.GetObject(new Guid(sObjectID),"PurchaseExamination");
            
            int i = 0;
            TTReportField rf = null;
            foreach(ExaminationCommisionMember tc in pp.ExaminationCommisionMembers)
            {
                i++;
                if (i<10)
                {
                    rf = FieldsByName("HOSPFUNC"+i);
                    rf.CalcValue = tc.ResUser.Rank.ShortName;
                    rf = FieldsByName("NAMESURNAME"+i);
                    rf.CalcValue = tc.ResUser.Name;
                    rf = FieldsByName("RECORDID"+i);
                    rf.CalcValue = tc.ResUser.EmploymentRecordID;
                }
            }
#endregion PART1 FOOTER_Script
                }
            }

        }

        public PART1Group PART1;

        public partial class MAINGroup : TTReportGroup
        {
            public MuayeneRaporu MyParentReport
            {
                get { return (MuayeneRaporu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField CNT { get {return Body().CNT;} }
            public TTReportField MATERIALNAME1 { get {return Body().MATERIALNAME1;} }
            public TTReportField MATERIALNAME2 { get {return Body().MATERIALNAME2;} }
            public TTReportField MATERIALNAME3 { get {return Body().MATERIALNAME3;} }
            public TTReportField MATERIALNAME4 { get {return Body().MATERIALNAME4;} }
            public TTReportField MATERIALNAME5 { get {return Body().MATERIALNAME5;} }
            public TTReportField MATERIALNAME11 { get {return Body().MATERIALNAME11;} }
            public TTReportField MATERIALNAME12 { get {return Body().MATERIALNAME12;} }
            public TTReportField MATERIALNAME13 { get {return Body().MATERIALNAME13;} }
            public TTReportField MATERIALNAME6 { get {return Body().MATERIALNAME6;} }
            public TTReportField MATERIALNAME14 { get {return Body().MATERIALNAME14;} }
            public TTReportField MATERIALNAME15 { get {return Body().MATERIALNAME15;} }
            public TTReportField MATERIALNAME16 { get {return Body().MATERIALNAME16;} }
            public TTReportField MATERIALNAME7 { get {return Body().MATERIALNAME7;} }
            public TTReportField MATERIALNAME17 { get {return Body().MATERIALNAME17;} }
            public TTReportField MATERIALNAME18 { get {return Body().MATERIALNAME18;} }
            public TTReportField MATERIALNAME19 { get {return Body().MATERIALNAME19;} }
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
                public MuayeneRaporu MyParentReport
                {
                    get { return (MuayeneRaporu)ParentReport; }
                }
                
                public TTReportField MATERIALNAME;
                public TTReportField CNT;
                public TTReportField MATERIALNAME1;
                public TTReportField MATERIALNAME2;
                public TTReportField MATERIALNAME3;
                public TTReportField MATERIALNAME4;
                public TTReportField MATERIALNAME5;
                public TTReportField MATERIALNAME11;
                public TTReportField MATERIALNAME12;
                public TTReportField MATERIALNAME13;
                public TTReportField MATERIALNAME6;
                public TTReportField MATERIALNAME14;
                public TTReportField MATERIALNAME15;
                public TTReportField MATERIALNAME16;
                public TTReportField MATERIALNAME7;
                public TTReportField MATERIALNAME17;
                public TTReportField MATERIALNAME18;
                public TTReportField MATERIALNAME19; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 28;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 9, 30, 14, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME.Value = @"Numune";

                    CNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 4, 190, 9, false);
                    CNT.Name = "CNT";
                    CNT.DrawStyle = DrawStyleConstants.vbSolid;
                    CNT.Value = @"Mal numune .......... Tkx Her takımda ......... Çf.Ad..........Çf.Ad..........";

                    MATERIALNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 14, 30, 19, false);
                    MATERIALNAME1.Name = "MATERIALNAME1";
                    MATERIALNAME1.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME1.Value = @"Dağıtım";

                    MATERIALNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 9, 50, 14, false);
                    MATERIALNAME2.Name = "MATERIALNAME2";
                    MATERIALNAME2.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME2.Value = @"";

                    MATERIALNAME3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 30, 14, 50, 19, false);
                    MATERIALNAME3.Name = "MATERIALNAME3";
                    MATERIALNAME3.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME3.Value = @"";

                    MATERIALNAME4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 19, 190, 24, false);
                    MATERIALNAME4.Name = "MATERIALNAME4";
                    MATERIALNAME4.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME4.Value = @"Açıklama : Bu kısım sadece mal numunesi tutulması gereken durumlarda kullanılacaktır.";

                    MATERIALNAME5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 9, 70, 14, false);
                    MATERIALNAME5.Name = "MATERIALNAME5";
                    MATERIALNAME5.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME5.Value = @"Mua.Kom.";

                    MATERIALNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 50, 14, 70, 19, false);
                    MATERIALNAME11.Name = "MATERIALNAME11";
                    MATERIALNAME11.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME11.Value = @"";

                    MATERIALNAME12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 9, 99, 14, false);
                    MATERIALNAME12.Name = "MATERIALNAME12";
                    MATERIALNAME12.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME12.Value = @"Laboratuvar Md.";

                    MATERIALNAME13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 14, 99, 19, false);
                    MATERIALNAME13.Name = "MATERIALNAME13";
                    MATERIALNAME13.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME13.Value = @"";

                    MATERIALNAME6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 9, 125, 14, false);
                    MATERIALNAME6.Name = "MATERIALNAME6";
                    MATERIALNAME6.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME6.Value = @"Mal Sor.";

                    MATERIALNAME14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 99, 14, 125, 19, false);
                    MATERIALNAME14.Name = "MATERIALNAME14";
                    MATERIALNAME14.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME14.Value = @"";

                    MATERIALNAME15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 9, 149, 14, false);
                    MATERIALNAME15.Name = "MATERIALNAME15";
                    MATERIALNAME15.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME15.Value = @"Üniversite";

                    MATERIALNAME16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 125, 14, 149, 19, false);
                    MATERIALNAME16.Name = "MATERIALNAME16";
                    MATERIALNAME16.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME16.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME16.Value = @"";

                    MATERIALNAME7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 9, 174, 14, false);
                    MATERIALNAME7.Name = "MATERIALNAME7";
                    MATERIALNAME7.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME7.Value = @"Fonksiyon";

                    MATERIALNAME17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 14, 174, 19, false);
                    MATERIALNAME17.Name = "MATERIALNAME17";
                    MATERIALNAME17.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME17.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME17.Value = @"";

                    MATERIALNAME18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 9, 190, 14, false);
                    MATERIALNAME18.Name = "MATERIALNAME18";
                    MATERIALNAME18.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME18.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME18.Value = @"";

                    MATERIALNAME19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 174, 14, 190, 19, false);
                    MATERIALNAME19.Name = "MATERIALNAME19";
                    MATERIALNAME19.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME19.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME19.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MATERIALNAME.CalcValue = MATERIALNAME.Value;
                    CNT.CalcValue = CNT.Value;
                    MATERIALNAME1.CalcValue = MATERIALNAME1.Value;
                    MATERIALNAME2.CalcValue = MATERIALNAME2.Value;
                    MATERIALNAME3.CalcValue = MATERIALNAME3.Value;
                    MATERIALNAME4.CalcValue = MATERIALNAME4.Value;
                    MATERIALNAME5.CalcValue = MATERIALNAME5.Value;
                    MATERIALNAME11.CalcValue = MATERIALNAME11.Value;
                    MATERIALNAME12.CalcValue = MATERIALNAME12.Value;
                    MATERIALNAME13.CalcValue = MATERIALNAME13.Value;
                    MATERIALNAME6.CalcValue = MATERIALNAME6.Value;
                    MATERIALNAME14.CalcValue = MATERIALNAME14.Value;
                    MATERIALNAME15.CalcValue = MATERIALNAME15.Value;
                    MATERIALNAME16.CalcValue = MATERIALNAME16.Value;
                    MATERIALNAME7.CalcValue = MATERIALNAME7.Value;
                    MATERIALNAME17.CalcValue = MATERIALNAME17.Value;
                    MATERIALNAME18.CalcValue = MATERIALNAME18.Value;
                    MATERIALNAME19.CalcValue = MATERIALNAME19.Value;
                    return new TTReportObject[] { MATERIALNAME,CNT,MATERIALNAME1,MATERIALNAME2,MATERIALNAME3,MATERIALNAME4,MATERIALNAME5,MATERIALNAME11,MATERIALNAME12,MATERIALNAME13,MATERIALNAME6,MATERIALNAME14,MATERIALNAME15,MATERIALNAME16,MATERIALNAME7,MATERIALNAME17,MATERIALNAME18,MATERIALNAME19};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class FUNCTIONTESTGroup : TTReportGroup
        {
            public MuayeneRaporu MyParentReport
            {
                get { return (MuayeneRaporu)ParentReport; }
            }

            new public FUNCTIONTESTGroupHeader Header()
            {
                return (FUNCTIONTESTGroupHeader)_header;
            }

            new public FUNCTIONTESTGroupFooter Footer()
            {
                return (FUNCTIONTESTGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField CLAUSENO1 { get {return Header().CLAUSENO1;} }
            public TTReportField EXAMINATIONVALUE1 { get {return Header().EXAMINATIONVALUE1;} }
            public TTReportField UYGUNMU1 { get {return Header().UYGUNMU1;} }
            public TTReportField CLAUSE1 { get {return Header().CLAUSE1;} }
            public TTReportField CLAUSENO11 { get {return Header().CLAUSENO11;} }
            public TTReportField NewField112 { get {return Footer().NewField112;} }
            public FUNCTIONTESTGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public FUNCTIONTESTGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new FUNCTIONTESTGroupHeader(this);
                _footer = new FUNCTIONTESTGroupFooter(this);

            }

            public partial class FUNCTIONTESTGroupHeader : TTReportSection
            {
                public MuayeneRaporu MyParentReport
                {
                    get { return (MuayeneRaporu)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField CLAUSENO1;
                public TTReportField EXAMINATIONVALUE1;
                public TTReportField UYGUNMU1;
                public TTReportField CLAUSE1;
                public TTReportField CLAUSENO11; 
                public FUNCTIONTESTGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 33;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 6, 41, 11, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.Underline = true;
                    NewField111.Value = @"TASNİF DIŞI";

                    CLAUSENO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 17, 45, 32, false);
                    CLAUSENO1.Name = "CLAUSENO1";
                    CLAUSENO1.DrawStyle = DrawStyleConstants.vbSolid;
                    CLAUSENO1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CLAUSENO1.MultiLine = EvetHayirEnum.ehEvet;
                    CLAUSENO1.WordBreak = EvetHayirEnum.ehEvet;
                    CLAUSENO1.Value = @"TEKNİK 
ŞARTNAME
MADDE NO";

                    EXAMINATIONVALUE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 17, 175, 32, false);
                    EXAMINATIONVALUE1.Name = "EXAMINATIONVALUE1";
                    EXAMINATIONVALUE1.DrawStyle = DrawStyleConstants.vbSolid;
                    EXAMINATIONVALUE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    EXAMINATIONVALUE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    EXAMINATIONVALUE1.MultiLine = EvetHayirEnum.ehEvet;
                    EXAMINATIONVALUE1.WordBreak = EvetHayirEnum.ehEvet;
                    EXAMINATIONVALUE1.Value = @"BULUNAN
DEĞERLER";

                    UYGUNMU1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 17, 200, 32, false);
                    UYGUNMU1.Name = "UYGUNMU1";
                    UYGUNMU1.DrawStyle = DrawStyleConstants.vbSolid;
                    UYGUNMU1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    UYGUNMU1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UYGUNMU1.Value = @"SONUÇ";

                    CLAUSE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 17, 139, 32, false);
                    CLAUSE1.Name = "CLAUSE1";
                    CLAUSE1.DrawStyle = DrawStyleConstants.vbSolid;
                    CLAUSE1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CLAUSE1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CLAUSE1.MultiLine = EvetHayirEnum.ehEvet;
                    CLAUSE1.WordBreak = EvetHayirEnum.ehEvet;
                    CLAUSE1.Value = @"SÖZLEŞME/İDARİ ŞART./TEKNİK ŞART.
İSTENİLEN ÖZELLİK ve/veya ŞARTNAME DEĞERİ";

                    CLAUSENO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 17, 20, 32, false);
                    CLAUSENO11.Name = "CLAUSENO11";
                    CLAUSENO11.DrawStyle = DrawStyleConstants.vbSolid;
                    CLAUSENO11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CLAUSENO11.MultiLine = EvetHayirEnum.ehEvet;
                    CLAUSENO11.WordBreak = EvetHayirEnum.ehEvet;
                    CLAUSENO11.Value = @"SIRA
NO";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    CLAUSENO1.CalcValue = CLAUSENO1.Value;
                    EXAMINATIONVALUE1.CalcValue = EXAMINATIONVALUE1.Value;
                    UYGUNMU1.CalcValue = UYGUNMU1.Value;
                    CLAUSE1.CalcValue = CLAUSE1.Value;
                    CLAUSENO11.CalcValue = CLAUSENO11.Value;
                    return new TTReportObject[] { NewField111,CLAUSENO1,EXAMINATIONVALUE1,UYGUNMU1,CLAUSE1,CLAUSENO11};
                }
            }
            public partial class FUNCTIONTESTGroupFooter : TTReportSection
            {
                public MuayeneRaporu MyParentReport
                {
                    get { return (MuayeneRaporu)ParentReport; }
                }
                
                public TTReportField NewField112; 
                public FUNCTIONTESTGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 13;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 4, 42, 9, false);
                    NewField112.Name = "NewField112";
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.Underline = true;
                    NewField112.Value = @"TASNİF DIŞI";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField112.CalcValue = NewField112.Value;
                    return new TTReportObject[] { NewField112};
                }
            }

        }

        public FUNCTIONTESTGroup FUNCTIONTEST;

        public partial class LINEGroup : TTReportGroup
        {
            public MuayeneRaporu MyParentReport
            {
                get { return (MuayeneRaporu)ParentReport; }
            }

            new public LINEGroupHeader Header()
            {
                return (LINEGroupHeader)_header;
            }

            new public LINEGroupFooter Footer()
            {
                return (LINEGroupFooter)_footer;
            }

            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportField CLAUSENO1 { get {return Header().CLAUSENO1;} }
            public TTReportField EXAMINATIONVALUE1 { get {return Header().EXAMINATIONVALUE1;} }
            public TTReportField ELIGABLE1 { get {return Header().ELIGABLE1;} }
            public TTReportField CNT1 { get {return Header().CNT1;} }
            public TTReportField ITEMNAME { get {return Header().ITEMNAME;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public LINEGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public LINEGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ExaminationDetail.MuayeneRaporuSartnameMaddeleriNQL_Class>("MuayeneRaporuSartnameMaddeleriNQL", ExaminationDetail.MuayeneRaporuSartnameMaddeleriNQL((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new LINEGroupHeader(this);
                _footer = new LINEGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class LINEGroupHeader : TTReportSection
            {
                public MuayeneRaporu MyParentReport
                {
                    get { return (MuayeneRaporu)ParentReport; }
                }
                
                public TTReportShape NewLine2;
                public TTReportField CLAUSENO1;
                public TTReportField EXAMINATIONVALUE1;
                public TTReportField ELIGABLE1;
                public TTReportField CNT1;
                public TTReportField ITEMNAME; 
                public LINEGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 5;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 190, 0, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    CLAUSENO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 0, 45, 5, false);
                    CLAUSENO1.Name = "CLAUSENO1";
                    CLAUSENO1.DrawStyle = DrawStyleConstants.vbSolid;
                    CLAUSENO1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CLAUSENO1.MultiLine = EvetHayirEnum.ehEvet;
                    CLAUSENO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    CLAUSENO1.Value = @"";

                    EXAMINATIONVALUE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 0, 175, 5, false);
                    EXAMINATIONVALUE1.Name = "EXAMINATIONVALUE1";
                    EXAMINATIONVALUE1.DrawStyle = DrawStyleConstants.vbSolid;
                    EXAMINATIONVALUE1.MultiLine = EvetHayirEnum.ehEvet;
                    EXAMINATIONVALUE1.WordBreak = EvetHayirEnum.ehEvet;
                    EXAMINATIONVALUE1.ExpandTabs = EvetHayirEnum.ehEvet;
                    EXAMINATIONVALUE1.Value = @"";

                    ELIGABLE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 0, 200, 5, false);
                    ELIGABLE1.Name = "ELIGABLE1";
                    ELIGABLE1.DrawStyle = DrawStyleConstants.vbSolid;
                    ELIGABLE1.NoClip = EvetHayirEnum.ehEvet;
                    ELIGABLE1.ExpandTabs = EvetHayirEnum.ehEvet;
                    ELIGABLE1.Value = @"";

                    CNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 20, 5, false);
                    CNT1.Name = "CNT1";
                    CNT1.DrawStyle = DrawStyleConstants.vbSolid;
                    CNT1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CNT1.MultiLine = EvetHayirEnum.ehEvet;
                    CNT1.ExpandTabs = EvetHayirEnum.ehEvet;
                    CNT1.Value = @"";

                    ITEMNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 45, 0, 139, 5, false);
                    ITEMNAME.Name = "ITEMNAME";
                    ITEMNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    ITEMNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMNAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ITEMNAME.NoClip = EvetHayirEnum.ehEvet;
                    ITEMNAME.ExpandTabs = EvetHayirEnum.ehEvet;
                    ITEMNAME.TextFont.Bold = true;
                    ITEMNAME.Value = @"{#ITEMNAME#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ExaminationDetail.MuayeneRaporuSartnameMaddeleriNQL_Class dataset_MuayeneRaporuSartnameMaddeleriNQL = ParentGroup.rsGroup.GetCurrentRecord<ExaminationDetail.MuayeneRaporuSartnameMaddeleriNQL_Class>(0);
                    CLAUSENO1.CalcValue = CLAUSENO1.Value;
                    EXAMINATIONVALUE1.CalcValue = EXAMINATIONVALUE1.Value;
                    ELIGABLE1.CalcValue = ELIGABLE1.Value;
                    CNT1.CalcValue = CNT1.Value;
                    ITEMNAME.CalcValue = (dataset_MuayeneRaporuSartnameMaddeleriNQL != null ? Globals.ToStringCore(dataset_MuayeneRaporuSartnameMaddeleriNQL.ItemName) : "");
                    return new TTReportObject[] { CLAUSENO1,EXAMINATIONVALUE1,ELIGABLE1,CNT1,ITEMNAME};
                }
            }
            public partial class LINEGroupFooter : TTReportSection
            {
                public MuayeneRaporu MyParentReport
                {
                    get { return (MuayeneRaporu)ParentReport; }
                }
                
                public TTReportShape NewLine11; 
                public LINEGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 2;
                    RepeatCount = 0;
                    
                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 190, 0, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ExaminationDetail.MuayeneRaporuSartnameMaddeleriNQL_Class dataset_MuayeneRaporuSartnameMaddeleriNQL = ParentGroup.rsGroup.GetCurrentRecord<ExaminationDetail.MuayeneRaporuSartnameMaddeleriNQL_Class>(0);
                    return new TTReportObject[] { };
                }
            }

        }

        public LINEGroup LINE;

        public partial class MAINBGroup : TTReportGroup
        {
            public MuayeneRaporu MyParentReport
            {
                get { return (MuayeneRaporu)ParentReport; }
            }

            new public MAINBGroupBody Body()
            {
                return (MAINBGroupBody)_body;
            }
            public TTReportField CLAUSENO { get {return Body().CLAUSENO;} }
            public TTReportField CONFIRMED { get {return Body().CONFIRMED;} }
            public TTReportField EXAMINATIONVALUE { get {return Body().EXAMINATIONVALUE;} }
            public TTReportField OBJECTID { get {return Body().OBJECTID;} }
            public TTReportField ELIGABLE { get {return Body().ELIGABLE;} }
            public TTReportRTF CLAUSERTF { get {return Body().CLAUSERTF;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportField CNT { get {return Body().CNT;} }
            public TTReportShape NewLine15 { get {return Body().NewLine15;} }
            public MAINBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override object[] GetGroupByValues()
            {

                ExaminationDetail.MuayeneRaporuSartnameMaddeleriNQL_Class dataSet_MuayeneRaporuSartnameMaddeleriNQL = ParentGroup.rsGroup.GetCurrentRecord<ExaminationDetail.MuayeneRaporuSartnameMaddeleriNQL_Class>(0);    
                return new object[] {(dataSet_MuayeneRaporuSartnameMaddeleriNQL==null ? null : dataSet_MuayeneRaporuSartnameMaddeleriNQL.ItemName)};
            }
            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINBGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstParentRS;
            }

            public partial class MAINBGroupBody : TTReportSection
            {
                public MuayeneRaporu MyParentReport
                {
                    get { return (MuayeneRaporu)ParentReport; }
                }
                
                public TTReportField CLAUSENO;
                public TTReportField CONFIRMED;
                public TTReportField EXAMINATIONVALUE;
                public TTReportField OBJECTID;
                public TTReportField ELIGABLE;
                public TTReportRTF CLAUSERTF;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportField CNT;
                public TTReportShape NewLine15; 
                public MAINBGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    CLAUSENO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 1, 45, 6, false);
                    CLAUSENO.Name = "CLAUSENO";
                    CLAUSENO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CLAUSENO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CLAUSENO.MultiLine = EvetHayirEnum.ehEvet;
                    CLAUSENO.ExpandTabs = EvetHayirEnum.ehEvet;
                    CLAUSENO.Value = @"{#LINE.CLAUSENO#}";

                    CONFIRMED = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 236, 1, 261, 6, false);
                    CONFIRMED.Name = "CONFIRMED";
                    CONFIRMED.Visible = EvetHayirEnum.ehHayir;
                    CONFIRMED.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONFIRMED.Value = @"{#LINE.CONFIRMED#}";

                    EXAMINATIONVALUE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 1, 175, 6, false);
                    EXAMINATIONVALUE.Name = "EXAMINATIONVALUE";
                    EXAMINATIONVALUE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXAMINATIONVALUE.MultiLine = EvetHayirEnum.ehEvet;
                    EXAMINATIONVALUE.WordBreak = EvetHayirEnum.ehEvet;
                    EXAMINATIONVALUE.ExpandTabs = EvetHayirEnum.ehEvet;
                    EXAMINATIONVALUE.Value = @"{#LINE.EXAMINATIONVALUE#}";

                    OBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 211, 1, 236, 6, false);
                    OBJECTID.Name = "OBJECTID";
                    OBJECTID.Visible = EvetHayirEnum.ehHayir;
                    OBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    OBJECTID.Value = @"{#LINE.OBJECTID#}";

                    ELIGABLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 1, 200, 6, false);
                    ELIGABLE.Name = "ELIGABLE";
                    ELIGABLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ELIGABLE.NoClip = EvetHayirEnum.ehEvet;
                    ELIGABLE.ExpandTabs = EvetHayirEnum.ehEvet;
                    ELIGABLE.Value = @"";

                    CLAUSERTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 46, 1, 138, 6, false);
                    CLAUSERTF.Name = "CLAUSERTF";
                    CLAUSERTF.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 20, 1, 20, 6, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 45, 1, 45, 6, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 139, 1, 139, 6, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine12.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 175, 1, 175, 6, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine13.ExtendTo = ExtendToEnum.extSectionHeight;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 1, 200, 6, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine14.ExtendTo = ExtendToEnum.extSectionHeight;

                    CNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 1, 19, 6, false);
                    CNT.Name = "CNT";
                    CNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    CNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CNT.MultiLine = EvetHayirEnum.ehEvet;
                    CNT.ExpandTabs = EvetHayirEnum.ehEvet;
                    CNT.Value = @"{@counter@}";

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 1, 10, 6, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine15.ExtendTo = ExtendToEnum.extSectionHeight;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ExaminationDetail.MuayeneRaporuSartnameMaddeleriNQL_Class dataset_MuayeneRaporuSartnameMaddeleriNQL = MyParentReport.LINE.rsGroup.GetCurrentRecord<ExaminationDetail.MuayeneRaporuSartnameMaddeleriNQL_Class>(0);
                    CLAUSENO.CalcValue = (dataset_MuayeneRaporuSartnameMaddeleriNQL != null ? Globals.ToStringCore(dataset_MuayeneRaporuSartnameMaddeleriNQL.ClauseNo) : "");
                    CONFIRMED.CalcValue = (dataset_MuayeneRaporuSartnameMaddeleriNQL != null ? Globals.ToStringCore(dataset_MuayeneRaporuSartnameMaddeleriNQL.Confirmed) : "");
                    EXAMINATIONVALUE.CalcValue = (dataset_MuayeneRaporuSartnameMaddeleriNQL != null ? Globals.ToStringCore(dataset_MuayeneRaporuSartnameMaddeleriNQL.ExaminationValue) : "");
                    OBJECTID.CalcValue = (dataset_MuayeneRaporuSartnameMaddeleriNQL != null ? Globals.ToStringCore(dataset_MuayeneRaporuSartnameMaddeleriNQL.ObjectID) : "");
                    ELIGABLE.CalcValue = @"";
                    CLAUSERTF.CalcValue = CLAUSERTF.Value;
                    CNT.CalcValue = ParentGroup.Counter.ToString();
                    return new TTReportObject[] { CLAUSENO,CONFIRMED,EXAMINATIONVALUE,OBJECTID,ELIGABLE,CLAUSERTF,CNT};
                }

                public override void RunScript()
                {
#region MAINB BODY_Script
                    if(CONFIRMED.CalcValue == "True")
                ELIGABLE.CalcValue = "UYGUNDUR";
            
            TTObjectContext context = new TTObjectContext(true);
            string sObjectID = OBJECTID.CalcValue.ToString();
            ExaminationDetail examinationDetail = (ExaminationDetail)context.GetObject(new Guid(sObjectID),"ExaminationDetail");
            CLAUSERTF.Value = examinationDetail.Clause;
#endregion MAINB BODY_Script
                }
            }

        }

        public MAINBGroup MAINB;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public MuayeneRaporu()
        {
            PART1 = new PART1Group(this,"PART1");
            MAIN = new MAINGroup(PART1,"MAIN");
            FUNCTIONTEST = new FUNCTIONTESTGroup(this,"FUNCTIONTEST");
            LINE = new LINEGroup(FUNCTIONTEST,"LINE");
            MAINB = new MAINBGroup(LINE,"MAINB");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "İşlem No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("9b2306a7-2381-4099-8a37-63dbae04c00e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "MUAYENERAPORU";
            Caption = "Muayene Raporu";
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
            fd.TextFont.Name = "Arial";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 162;
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