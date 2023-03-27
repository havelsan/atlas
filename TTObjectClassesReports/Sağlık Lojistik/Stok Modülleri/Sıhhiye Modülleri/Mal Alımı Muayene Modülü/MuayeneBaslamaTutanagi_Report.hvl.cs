
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
    /// Muayene Başlama Tutanağı
    /// </summary>
    public partial class MuayeneBaslamaTutanagi : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class MAINGroup : TTReportGroup
        {
            public MuayeneBaslamaTutanagi MyParentReport
            {
                get { return (MuayeneBaslamaTutanagi)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField2 { get {return Body().NewField2;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField122 { get {return Body().NewField122;} }
            public TTReportField NewField123 { get {return Body().NewField123;} }
            public TTReportField NewField124 { get {return Body().NewField124;} }
            public TTReportField NewField125 { get {return Body().NewField125;} }
            public TTReportField NewField126 { get {return Body().NewField126;} }
            public TTReportField NewField127 { get {return Body().NewField127;} }
            public TTReportField NewField128 { get {return Body().NewField128;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportField NewField129 { get {return Body().NewField129;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField NewField1221 { get {return Body().NewField1221;} }
            public TTReportField NewField1321 { get {return Body().NewField1321;} }
            public TTReportField NewField1421 { get {return Body().NewField1421;} }
            public TTReportField NewField1521 { get {return Body().NewField1521;} }
            public TTReportField NewField1621 { get {return Body().NewField1621;} }
            public TTReportField NewField1721 { get {return Body().NewField1721;} }
            public TTReportField NewField1821 { get {return Body().NewField1821;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField SUPPLIERNAME { get {return Body().SUPPLIERNAME;} }
            public TTReportField EXAMINATIONSTARTDATE { get {return Body().EXAMINATIONSTARTDATE;} }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField NewField1422 { get {return Body().NewField1422;} }
            public TTReportField INSPECTIONPLACE { get {return Body().INSPECTIONPLACE;} }
            public TTReportField CONTRACTDATE { get {return Body().CONTRACTDATE;} }
            public TTReportField CONTRACTNO { get {return Body().CONTRACTNO;} }
            public TTReportField PROJECTNO14 { get {return Body().PROJECTNO14;} }
            public TTReportField NAMESURNAME1 { get {return Body().NAMESURNAME1;} }
            public TTReportField COMFUNC1 { get {return Body().COMFUNC1;} }
            public TTReportField NAMESURNAME2 { get {return Body().NAMESURNAME2;} }
            public TTReportField NAMESURNAME3 { get {return Body().NAMESURNAME3;} }
            public TTReportField NAMESURNAME4 { get {return Body().NAMESURNAME4;} }
            public TTReportField HOSPFUNC4 { get {return Body().HOSPFUNC4;} }
            public TTReportField NAMESURNAME5 { get {return Body().NAMESURNAME5;} }
            public TTReportField HOSPFUNC5 { get {return Body().HOSPFUNC5;} }
            public TTReportField HOSPFUNC6 { get {return Body().HOSPFUNC6;} }
            public TTReportField NAMESURNAME7 { get {return Body().NAMESURNAME7;} }
            public TTReportField HOSPFUNC7 { get {return Body().HOSPFUNC7;} }
            public TTReportField NAMESURNAME8 { get {return Body().NAMESURNAME8;} }
            public TTReportField HOSPFUNC8 { get {return Body().HOSPFUNC8;} }
            public TTReportField NAMESURNAME9 { get {return Body().NAMESURNAME9;} }
            public TTReportField HOSPFUNC9 { get {return Body().HOSPFUNC9;} }
            public TTReportField HOSPFUNC1 { get {return Body().HOSPFUNC1;} }
            public TTReportField HOSPFUNC2 { get {return Body().HOSPFUNC2;} }
            public TTReportField HOSPFUNC3 { get {return Body().HOSPFUNC3;} }
            public TTReportField COMFUNC2 { get {return Body().COMFUNC2;} }
            public TTReportField COMFUNC3 { get {return Body().COMFUNC3;} }
            public TTReportField COMFUNC4 { get {return Body().COMFUNC4;} }
            public TTReportField COMFUNC5 { get {return Body().COMFUNC5;} }
            public TTReportField COMFUNC6 { get {return Body().COMFUNC6;} }
            public TTReportField COMFUNC7 { get {return Body().COMFUNC7;} }
            public TTReportField COMFUNC8 { get {return Body().COMFUNC8;} }
            public TTReportField COMFUNC9 { get {return Body().COMFUNC9;} }
            public TTReportField NAMESURNAME6 { get {return Body().NAMESURNAME6;} }
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
                list[0] = new TTReportNqlData<PurchaseExamination.GetByObjcetID_Class>("GetByObjcetID", PurchaseExamination.GetByObjcetID((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public MuayeneBaslamaTutanagi MyParentReport
                {
                    get { return (MuayeneBaslamaTutanagi)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField2;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField122;
                public TTReportField NewField123;
                public TTReportField NewField124;
                public TTReportField NewField125;
                public TTReportField NewField126;
                public TTReportField NewField127;
                public TTReportField NewField128;
                public TTReportField NewField13;
                public TTReportField NewField129;
                public TTReportField NewField1121;
                public TTReportField NewField1221;
                public TTReportField NewField1321;
                public TTReportField NewField1421;
                public TTReportField NewField1521;
                public TTReportField NewField1621;
                public TTReportField NewField1721;
                public TTReportField NewField1821;
                public TTReportField NewField14;
                public TTReportField SUPPLIERNAME;
                public TTReportField EXAMINATIONSTARTDATE;
                public TTReportField MATERIALNAME;
                public TTReportField AMOUNT;
                public TTReportField NewField1422;
                public TTReportField INSPECTIONPLACE;
                public TTReportField CONTRACTDATE;
                public TTReportField CONTRACTNO;
                public TTReportField PROJECTNO14;
                public TTReportField NAMESURNAME1;
                public TTReportField COMFUNC1;
                public TTReportField NAMESURNAME2;
                public TTReportField NAMESURNAME3;
                public TTReportField NAMESURNAME4;
                public TTReportField HOSPFUNC4;
                public TTReportField NAMESURNAME5;
                public TTReportField HOSPFUNC5;
                public TTReportField HOSPFUNC6;
                public TTReportField NAMESURNAME7;
                public TTReportField HOSPFUNC7;
                public TTReportField NAMESURNAME8;
                public TTReportField HOSPFUNC8;
                public TTReportField NAMESURNAME9;
                public TTReportField HOSPFUNC9;
                public TTReportField HOSPFUNC1;
                public TTReportField HOSPFUNC2;
                public TTReportField HOSPFUNC3;
                public TTReportField COMFUNC2;
                public TTReportField COMFUNC3;
                public TTReportField COMFUNC4;
                public TTReportField COMFUNC5;
                public TTReportField COMFUNC6;
                public TTReportField COMFUNC7;
                public TTReportField COMFUNC8;
                public TTReportField COMFUNC9;
                public TTReportField NAMESURNAME6; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 205;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 190, 15, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.TextFont.Size = 12;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"MUAYENE BAŞLAMA TUTANAĞI";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 22, 72, 27, false);
                    NewField2.Name = "NewField2";
                    NewField2.Value = @"SAYFA NO / SIRA NO";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 58, 72, 63, false);
                    NewField12.Name = "NewField12";
                    NewField12.Value = @"YÜKLENİCİNİN ADI / TİCARİ ÜNVANI";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 28, 72, 33, false);
                    NewField121.Name = "NewField121";
                    NewField121.Value = @"TARİH / MUAYENE SAATİ";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 34, 72, 39, false);
                    NewField122.Name = "NewField122";
                    NewField122.Value = @"MALIN ADI";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 40, 72, 45, false);
                    NewField123.Name = "NewField123";
                    NewField123.Value = @"MİKTARI";

                    NewField124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 46, 72, 51, false);
                    NewField124.Name = "NewField124";
                    NewField124.Value = @"AİT OLDUĞU BİRLİK";

                    NewField125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 52, 72, 57, false);
                    NewField125.Name = "NewField125";
                    NewField125.Value = @"MUAYENENİN YAPILDIĞI YER";

                    NewField126 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 64, 72, 69, false);
                    NewField126.Name = "NewField126";
                    NewField126.Value = @"SÖZLEŞME TARİH VE NO";

                    NewField127 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 70, 72, 75, false);
                    NewField127.Name = "NewField127";
                    NewField127.Value = @"YAPILACAK İŞLEMLER";

                    NewField128 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 90, 72, 95, false);
                    NewField128.Name = "NewField128";
                    NewField128.Value = @"SONUÇ";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 22, 74, 27, false);
                    NewField13.Name = "NewField13";
                    NewField13.Value = @":";

                    NewField129 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 58, 74, 63, false);
                    NewField129.Name = "NewField129";
                    NewField129.Value = @":";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 28, 74, 33, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.Value = @":";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 34, 74, 39, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.Value = @":";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 40, 74, 45, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.Value = @":";

                    NewField1421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 46, 74, 51, false);
                    NewField1421.Name = "NewField1421";
                    NewField1421.Value = @":";

                    NewField1521 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 52, 74, 57, false);
                    NewField1521.Name = "NewField1521";
                    NewField1521.Value = @":";

                    NewField1621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 64, 74, 69, false);
                    NewField1621.Name = "NewField1621";
                    NewField1621.Value = @":";

                    NewField1721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 70, 74, 75, false);
                    NewField1721.Name = "NewField1721";
                    NewField1721.Value = @":";

                    NewField1821 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 90, 74, 95, false);
                    NewField1821.Name = "NewField1821";
                    NewField1821.Value = @":";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 22, 190, 27, false);
                    NewField14.Name = "NewField14";
                    NewField14.Value = @"";

                    SUPPLIERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 58, 190, 63, false);
                    SUPPLIERNAME.Name = "SUPPLIERNAME";
                    SUPPLIERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIERNAME.Value = @"{#SUPPLIERNAME#}";

                    EXAMINATIONSTARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 28, 190, 33, false);
                    EXAMINATIONSTARTDATE.Name = "EXAMINATIONSTARTDATE";
                    EXAMINATIONSTARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    EXAMINATIONSTARTDATE.TextFormat = @"dd/MM/yyyy HH:mm";
                    EXAMINATIONSTARTDATE.Value = @"{#EXAMINATIONSTARTDATE#}";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 34, 190, 39, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.Value = @"";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 40, 190, 45, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.Value = @"";

                    NewField1422 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 46, 190, 51, false);
                    NewField1422.Name = "NewField1422";
                    NewField1422.Value = @"";

                    INSPECTIONPLACE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 52, 190, 57, false);
                    INSPECTIONPLACE.Name = "INSPECTIONPLACE";
                    INSPECTIONPLACE.FieldType = ReportFieldTypeEnum.ftVariable;
                    INSPECTIONPLACE.Value = @"{#INSPECTIONPLACE#}";

                    CONTRACTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 64, 107, 69, false);
                    CONTRACTDATE.Name = "CONTRACTDATE";
                    CONTRACTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONTRACTDATE.TextFormat = @"Short Date";
                    CONTRACTDATE.Value = @"{#CONTRACTDATE#}";

                    CONTRACTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 64, 145, 69, false);
                    CONTRACTNO.Name = "CONTRACTNO";
                    CONTRACTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONTRACTNO.Value = @"{#CONTRACTNO#}";

                    PROJECTNO14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 130, 190, 135, false);
                    PROJECTNO14.Name = "PROJECTNO14";
                    PROJECTNO14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PROJECTNO14.MultiLine = EvetHayirEnum.ehEvet;
                    PROJECTNO14.WordBreak = EvetHayirEnum.ehEvet;
                    PROJECTNO14.TextFont.Bold = true;
                    PROJECTNO14.TextFont.Underline = true;
                    PROJECTNO14.Value = @"MUAYENE VE KABUL KOMİSYONU";

                    NAMESURNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 142, 65, 146, false);
                    NAMESURNAME1.Name = "NAMESURNAME1";
                    NAMESURNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NAMESURNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME1.Value = @"";

                    COMFUNC1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 146, 65, 150, false);
                    COMFUNC1.Name = "COMFUNC1";
                    COMFUNC1.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    COMFUNC1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC1.ObjectDefName = "CommisionMemberDutyEnum";
                    COMFUNC1.DataMember = "DISPLAYTEXT";
                    COMFUNC1.Value = @"";

                    NAMESURNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 142, 127, 146, false);
                    NAMESURNAME2.Name = "NAMESURNAME2";
                    NAMESURNAME2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME2.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NAMESURNAME2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME2.Value = @"";

                    NAMESURNAME3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 142, 190, 146, false);
                    NAMESURNAME3.Name = "NAMESURNAME3";
                    NAMESURNAME3.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME3.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NAMESURNAME3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME3.Value = @"";

                    NAMESURNAME4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 160, 64, 164, false);
                    NAMESURNAME4.Name = "NAMESURNAME4";
                    NAMESURNAME4.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME4.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NAMESURNAME4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME4.Value = @"";

                    HOSPFUNC4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 156, 64, 160, false);
                    HOSPFUNC4.Name = "HOSPFUNC4";
                    HOSPFUNC4.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC4.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HOSPFUNC4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC4.Value = @"";

                    NAMESURNAME5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 160, 127, 164, false);
                    NAMESURNAME5.Name = "NAMESURNAME5";
                    NAMESURNAME5.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME5.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NAMESURNAME5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME5.Value = @"";

                    HOSPFUNC5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 156, 127, 160, false);
                    HOSPFUNC5.Name = "HOSPFUNC5";
                    HOSPFUNC5.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC5.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HOSPFUNC5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC5.Value = @"";

                    HOSPFUNC6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 156, 190, 160, false);
                    HOSPFUNC6.Name = "HOSPFUNC6";
                    HOSPFUNC6.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC6.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HOSPFUNC6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC6.Value = @"";

                    NAMESURNAME7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 177, 64, 181, false);
                    NAMESURNAME7.Name = "NAMESURNAME7";
                    NAMESURNAME7.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME7.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NAMESURNAME7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME7.Value = @"";

                    HOSPFUNC7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 173, 64, 177, false);
                    HOSPFUNC7.Name = "HOSPFUNC7";
                    HOSPFUNC7.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC7.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HOSPFUNC7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC7.Value = @"";

                    NAMESURNAME8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 177, 127, 181, false);
                    NAMESURNAME8.Name = "NAMESURNAME8";
                    NAMESURNAME8.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME8.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NAMESURNAME8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME8.Value = @"";

                    HOSPFUNC8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 173, 127, 177, false);
                    HOSPFUNC8.Name = "HOSPFUNC8";
                    HOSPFUNC8.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC8.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HOSPFUNC8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC8.Value = @"";

                    NAMESURNAME9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 177, 190, 181, false);
                    NAMESURNAME9.Name = "NAMESURNAME9";
                    NAMESURNAME9.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME9.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NAMESURNAME9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME9.Value = @"";

                    HOSPFUNC9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 173, 190, 177, false);
                    HOSPFUNC9.Name = "HOSPFUNC9";
                    HOSPFUNC9.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC9.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HOSPFUNC9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC9.Value = @"";

                    HOSPFUNC1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 138, 65, 142, false);
                    HOSPFUNC1.Name = "HOSPFUNC1";
                    HOSPFUNC1.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC1.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HOSPFUNC1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC1.Value = @"";

                    HOSPFUNC2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 138, 127, 142, false);
                    HOSPFUNC2.Name = "HOSPFUNC2";
                    HOSPFUNC2.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC2.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HOSPFUNC2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC2.Value = @"";

                    HOSPFUNC3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 138, 190, 142, false);
                    HOSPFUNC3.Name = "HOSPFUNC3";
                    HOSPFUNC3.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC3.CaseFormat = CaseFormatEnum.fcUpperCase;
                    HOSPFUNC3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC3.Value = @"";

                    COMFUNC2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 146, 127, 150, false);
                    COMFUNC2.Name = "COMFUNC2";
                    COMFUNC2.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC2.CaseFormat = CaseFormatEnum.fcUpperCase;
                    COMFUNC2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC2.ObjectDefName = "CommisionMemberDutyEnum";
                    COMFUNC2.DataMember = "DISPLAYTEXT";
                    COMFUNC2.Value = @"";

                    COMFUNC3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 146, 190, 150, false);
                    COMFUNC3.Name = "COMFUNC3";
                    COMFUNC3.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC3.CaseFormat = CaseFormatEnum.fcUpperCase;
                    COMFUNC3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC3.ObjectDefName = "CommisionMemberDutyEnum";
                    COMFUNC3.DataMember = "DISPLAYTEXT";
                    COMFUNC3.Value = @"";

                    COMFUNC4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 164, 64, 168, false);
                    COMFUNC4.Name = "COMFUNC4";
                    COMFUNC4.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC4.CaseFormat = CaseFormatEnum.fcUpperCase;
                    COMFUNC4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC4.ObjectDefName = "CommisionMemberDutyEnum";
                    COMFUNC4.DataMember = "DISPLAYTEXT";
                    COMFUNC4.Value = @"";

                    COMFUNC5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 164, 127, 168, false);
                    COMFUNC5.Name = "COMFUNC5";
                    COMFUNC5.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC5.CaseFormat = CaseFormatEnum.fcUpperCase;
                    COMFUNC5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC5.ObjectDefName = "CommisionMemberDutyEnum";
                    COMFUNC5.DataMember = "DISPLAYTEXT";
                    COMFUNC5.Value = @"";

                    COMFUNC6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 164, 190, 168, false);
                    COMFUNC6.Name = "COMFUNC6";
                    COMFUNC6.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC6.CaseFormat = CaseFormatEnum.fcUpperCase;
                    COMFUNC6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC6.ObjectDefName = "CommisionMemberDutyEnum";
                    COMFUNC6.DataMember = "DISPLAYTEXT";
                    COMFUNC6.Value = @"";

                    COMFUNC7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 181, 64, 185, false);
                    COMFUNC7.Name = "COMFUNC7";
                    COMFUNC7.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC7.CaseFormat = CaseFormatEnum.fcUpperCase;
                    COMFUNC7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC7.ObjectDefName = "CommisionMemberDutyEnum";
                    COMFUNC7.DataMember = "DISPLAYTEXT";
                    COMFUNC7.Value = @"";

                    COMFUNC8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 181, 127, 185, false);
                    COMFUNC8.Name = "COMFUNC8";
                    COMFUNC8.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC8.CaseFormat = CaseFormatEnum.fcUpperCase;
                    COMFUNC8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC8.ObjectDefName = "CommisionMemberDutyEnum";
                    COMFUNC8.DataMember = "DISPLAYTEXT";
                    COMFUNC8.Value = @"";

                    COMFUNC9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 181, 190, 185, false);
                    COMFUNC9.Name = "COMFUNC9";
                    COMFUNC9.FieldType = ReportFieldTypeEnum.ftVariable;
                    COMFUNC9.CaseFormat = CaseFormatEnum.fcUpperCase;
                    COMFUNC9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    COMFUNC9.ObjectDefName = "CommisionMemberDutyEnum";
                    COMFUNC9.DataMember = "DISPLAYTEXT";
                    COMFUNC9.Value = @"";

                    NAMESURNAME6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 160, 190, 164, false);
                    NAMESURNAME6.Name = "NAMESURNAME6";
                    NAMESURNAME6.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME6.CaseFormat = CaseFormatEnum.fcUpperCase;
                    NAMESURNAME6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME6.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseExamination.GetByObjcetID_Class dataset_GetByObjcetID = ParentGroup.rsGroup.GetCurrentRecord<PurchaseExamination.GetByObjcetID_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField2.CalcValue = NewField2.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField123.CalcValue = NewField123.Value;
                    NewField124.CalcValue = NewField124.Value;
                    NewField125.CalcValue = NewField125.Value;
                    NewField126.CalcValue = NewField126.Value;
                    NewField127.CalcValue = NewField127.Value;
                    NewField128.CalcValue = NewField128.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField129.CalcValue = NewField129.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    NewField1421.CalcValue = NewField1421.Value;
                    NewField1521.CalcValue = NewField1521.Value;
                    NewField1621.CalcValue = NewField1621.Value;
                    NewField1721.CalcValue = NewField1721.Value;
                    NewField1821.CalcValue = NewField1821.Value;
                    NewField14.CalcValue = NewField14.Value;
                    SUPPLIERNAME.CalcValue = (dataset_GetByObjcetID != null ? Globals.ToStringCore(dataset_GetByObjcetID.Suppliername) : "");
                    EXAMINATIONSTARTDATE.CalcValue = (dataset_GetByObjcetID != null ? Globals.ToStringCore(dataset_GetByObjcetID.ExaminationStartDate) : "");
                    MATERIALNAME.CalcValue = @"";
                    AMOUNT.CalcValue = @"";
                    NewField1422.CalcValue = NewField1422.Value;
                    INSPECTIONPLACE.CalcValue = (dataset_GetByObjcetID != null ? Globals.ToStringCore(dataset_GetByObjcetID.InspectionPlace) : "");
                    CONTRACTDATE.CalcValue = (dataset_GetByObjcetID != null ? Globals.ToStringCore(dataset_GetByObjcetID.ContractDate) : "");
                    CONTRACTNO.CalcValue = (dataset_GetByObjcetID != null ? Globals.ToStringCore(dataset_GetByObjcetID.ContractNo) : "");
                    PROJECTNO14.CalcValue = PROJECTNO14.Value;
                    NAMESURNAME1.CalcValue = @"";
                    COMFUNC1.CalcValue = @"";
                    COMFUNC1.PostFieldValueCalculation();
                    NAMESURNAME2.CalcValue = @"";
                    NAMESURNAME3.CalcValue = @"";
                    NAMESURNAME4.CalcValue = @"";
                    HOSPFUNC4.CalcValue = @"";
                    NAMESURNAME5.CalcValue = @"";
                    HOSPFUNC5.CalcValue = @"";
                    HOSPFUNC6.CalcValue = @"";
                    NAMESURNAME7.CalcValue = @"";
                    HOSPFUNC7.CalcValue = @"";
                    NAMESURNAME8.CalcValue = @"";
                    HOSPFUNC8.CalcValue = @"";
                    NAMESURNAME9.CalcValue = @"";
                    HOSPFUNC9.CalcValue = @"";
                    HOSPFUNC1.CalcValue = @"";
                    HOSPFUNC2.CalcValue = @"";
                    HOSPFUNC3.CalcValue = @"";
                    COMFUNC2.CalcValue = @"";
                    COMFUNC2.PostFieldValueCalculation();
                    COMFUNC3.CalcValue = @"";
                    COMFUNC3.PostFieldValueCalculation();
                    COMFUNC4.CalcValue = @"";
                    COMFUNC4.PostFieldValueCalculation();
                    COMFUNC5.CalcValue = @"";
                    COMFUNC5.PostFieldValueCalculation();
                    COMFUNC6.CalcValue = @"";
                    COMFUNC6.PostFieldValueCalculation();
                    COMFUNC7.CalcValue = @"";
                    COMFUNC7.PostFieldValueCalculation();
                    COMFUNC8.CalcValue = @"";
                    COMFUNC8.PostFieldValueCalculation();
                    COMFUNC9.CalcValue = @"";
                    COMFUNC9.PostFieldValueCalculation();
                    NAMESURNAME6.CalcValue = @"";
                    return new TTReportObject[] { NewField1,NewField2,NewField12,NewField121,NewField122,NewField123,NewField124,NewField125,NewField126,NewField127,NewField128,NewField13,NewField129,NewField1121,NewField1221,NewField1321,NewField1421,NewField1521,NewField1621,NewField1721,NewField1821,NewField14,SUPPLIERNAME,EXAMINATIONSTARTDATE,MATERIALNAME,AMOUNT,NewField1422,INSPECTIONPLACE,CONTRACTDATE,CONTRACTNO,PROJECTNO14,NAMESURNAME1,COMFUNC1,NAMESURNAME2,NAMESURNAME3,NAMESURNAME4,HOSPFUNC4,NAMESURNAME5,HOSPFUNC5,HOSPFUNC6,NAMESURNAME7,HOSPFUNC7,NAMESURNAME8,HOSPFUNC8,NAMESURNAME9,HOSPFUNC9,HOSPFUNC1,HOSPFUNC2,HOSPFUNC3,COMFUNC2,COMFUNC3,COMFUNC4,COMFUNC5,COMFUNC6,COMFUNC7,COMFUNC8,COMFUNC9,NAMESURNAME6};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((MuayeneBaslamaTutanagi)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            PurchaseExamination pp = (PurchaseExamination)context.GetObject(new Guid(sObjectID),"PurchaseExamination");
            PurchaseExaminationDetail ped = (PurchaseExaminationDetail)pp.PurchaseExaminationDetails[0];
            MATERIALNAME.CalcValue = ped.PurchaseOrderDetail.ContractDetail.Material.Name;
            AMOUNT.CalcValue = ped.Amount + " " + ped.PurchaseOrderDetail.ContractDetail.Material.DistributionTypeName + " / " + pp.PurchaseExaminationDetails.Count.ToString() + " KLM";
            
            int i = 0;
            foreach(ExaminationCommisionMember tc in pp.ExaminationCommisionMembers)
            {
                i++;
                if (i<10)
                {
                    TTReportField rf = FieldsByName("COMFUNC"+i);
                    rf.Value = ((int)tc.MemberDuty.Value).ToString();
                    rf = FieldsByName("NAMESURNAME"+i);
                    rf.CalcValue = tc.ResUser.Name;
                    rf = FieldsByName("HOSPFUNC"+i);
                    rf.CalcValue = tc.ResUser.Rank.ShortName;
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

        public MuayeneBaslamaTutanagi()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "İşlem No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("9b2306a7-2381-4099-8a37-63dbae04c00e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "MUAYENEBASLAMATUTANAGI";
            Caption = "Muayene Başlama Tutanağı";
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