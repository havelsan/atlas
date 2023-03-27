
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
    /// Muayene Muhtırası
    /// </summary>
    public partial class MuayeneMuhtirasi : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PART1Group : TTReportGroup
        {
            public MuayeneMuhtirasi MyParentReport
            {
                get { return (MuayeneMuhtirasi)ParentReport; }
            }

            new public PART1GroupHeader Header()
            {
                return (PART1GroupHeader)_header;
            }

            new public PART1GroupFooter Footer()
            {
                return (PART1GroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField STOCKACTIONID { get {return Header().STOCKACTIONID;} }
            public TTReportField CONFIRMNO { get {return Header().CONFIRMNO;} }
            public TTReportField RESPONSIBLEPROCUREMENTUNITDEF { get {return Header().RESPONSIBLEPROCUREMENTUNITDEF;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField IDAREADI { get {return Header().IDAREADI;} }
            public TTReportField NewField1113 { get {return Header().NewField1113;} }
            public TTReportField NewField13111 { get {return Header().NewField13111;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField161 { get {return Header().NewField161;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField SUPPLIERNAME { get {return Header().SUPPLIERNAME;} }
            public TTReportField TEMPORARYDELIVERYDATE { get {return Header().TEMPORARYDELIVERYDATE;} }
            public TTReportField NewField152 { get {return Header().NewField152;} }
            public TTReportField INSPECTIONPLACE { get {return Header().INSPECTIONPLACE;} }
            public TTReportField DESCRIPTION { get {return Header().DESCRIPTION;} }
            public TTReportField NewField173 { get {return Header().NewField173;} }
            public TTReportField NewField1371 { get {return Header().NewField1371;} }
            public TTReportField NewField1372 { get {return Header().NewField1372;} }
            public TTReportField NewField172 { get {return Header().NewField172;} }
            public TTReportField NewField1171 { get {return Header().NewField1171;} }
            public TTReportField CONTRACTNODATE { get {return Header().CONTRACTNODATE;} }
            public TTReportField CONTRACTDATE { get {return Header().CONTRACTDATE;} }
            public TTReportField DESC { get {return Footer().DESC;} }
            public TTReportField NUMBERTEXT { get {return Footer().NUMBERTEXT;} }
            public TTReportField NewField4 { get {return Footer().NewField4;} }
            public TTReportField NewField19 { get {return Footer().NewField19;} }
            public TTReportField NewField20 { get {return Footer().NewField20;} }
            public TTReportField NewField21 { get {return Footer().NewField21;} }
            public TTReportField NewField22 { get {return Footer().NewField22;} }
            public TTReportField NewField23 { get {return Footer().NewField23;} }
            public TTReportField NewField24 { get {return Footer().NewField24;} }
            public TTReportField NewField191 { get {return Footer().NewField191;} }
            public TTReportField NewField102 { get {return Footer().NewField102;} }
            public TTReportField NewField114 { get {return Footer().NewField114;} }
            public TTReportField NewField122 { get {return Footer().NewField122;} }
            public TTReportField NewField132 { get {return Footer().NewField132;} }
            public TTReportField NewField25 { get {return Footer().NewField25;} }
            public TTReportField NewField153 { get {return Footer().NewField153;} }
            public TTReportField NewField154 { get {return Footer().NewField154;} }
            public TTReportField NewField5 { get {return Footer().NewField5;} }
            public TTReportField NewField26 { get {return Footer().NewField26;} }
            public TTReportField NewField162 { get {return Footer().NewField162;} }
            public TTReportField NewField163 { get {return Footer().NewField163;} }
            public TTReportField NewField1361 { get {return Footer().NewField1361;} }
            public TTReportField NewField1261 { get {return Footer().NewField1261;} }
            public TTReportField NewField1262 { get {return Footer().NewField1262;} }
            public TTReportField NewField12621 { get {return Footer().NewField12621;} }
            public TTReportField NewField112621 { get {return Footer().NewField112621;} }
            public TTReportField NewField112622 { get {return Footer().NewField112622;} }
            public TTReportField NewField12622 { get {return Footer().NewField12622;} }
            public TTReportField NewField12623 { get {return Footer().NewField12623;} }
            public TTReportField NewField12624 { get {return Footer().NewField12624;} }
            public TTReportField NewField12625 { get {return Footer().NewField12625;} }
            public TTReportField NewField12626 { get {return Footer().NewField12626;} }
            public TTReportField NewField12627 { get {return Footer().NewField12627;} }
            public TTReportField NewField12628 { get {return Footer().NewField12628;} }
            public TTReportField NewField112623 { get {return Footer().NewField112623;} }
            public TTReportField NewField1126211 { get {return Footer().NewField1126211;} }
            public TTReportField NewField1226211 { get {return Footer().NewField1226211;} }
            public TTReportField NewField1326211 { get {return Footer().NewField1326211;} }
            public TTReportField NewField11126211 { get {return Footer().NewField11126211;} }
            public TTReportField NewField11126221 { get {return Footer().NewField11126221;} }
            public TTReportField NewField1326212 { get {return Footer().NewField1326212;} }
            public TTReportField NewField11126212 { get {return Footer().NewField11126212;} }
            public TTReportField NewField11126222 { get {return Footer().NewField11126222;} }
            public TTReportField NewField11126231 { get {return Footer().NewField11126231;} }
            public TTReportField NewField111262111 { get {return Footer().NewField111262111;} }
            public TTReportField NewField112262111 { get {return Footer().NewField112262111;} }
            public TTReportField NewField1326213 { get {return Footer().NewField1326213;} }
            public TTReportField NewField11126213 { get {return Footer().NewField11126213;} }
            public TTReportField NewField11126223 { get {return Footer().NewField11126223;} }
            public TTReportField NewField11126232 { get {return Footer().NewField11126232;} }
            public TTReportField NewField111262112 { get {return Footer().NewField111262112;} }
            public TTReportField NewField112262112 { get {return Footer().NewField112262112;} }
            public TTReportField NewField123262111 { get {return Footer().NewField123262111;} }
            public TTReportField NewField1211262111 { get {return Footer().NewField1211262111;} }
            public TTReportField NewField1211262211 { get {return Footer().NewField1211262211;} }
            public TTReportField NewField1111262321 { get {return Footer().NewField1111262321;} }
            public TTReportField NewField1111262322 { get {return Footer().NewField1111262322;} }
            public TTReportField NewField27 { get {return Footer().NewField27;} }
            public TTReportField NewField192 { get {return Footer().NewField192;} }
            public TTReportField NewField103 { get {return Footer().NewField103;} }
            public TTReportField NewField115 { get {return Footer().NewField115;} }
            public TTReportField NewField123 { get {return Footer().NewField123;} }
            public TTReportField NewField133 { get {return Footer().NewField133;} }
            public TTReportField NewField142 { get {return Footer().NewField142;} }
            public TTReportField NewField1191 { get {return Footer().NewField1191;} }
            public TTReportField NewField1201 { get {return Footer().NewField1201;} }
            public TTReportField NewField1411 { get {return Footer().NewField1411;} }
            public TTReportField NewField1221 { get {return Footer().NewField1221;} }
            public TTReportField NewField1231 { get {return Footer().NewField1231;} }
            public TTReportField NewField155 { get {return Footer().NewField155;} }
            public TTReportField NewField1351 { get {return Footer().NewField1351;} }
            public TTReportField NewField1451 { get {return Footer().NewField1451;} }
            public TTReportField NewField11531 { get {return Footer().NewField11531;} }
            public TTReportField NewField11532 { get {return Footer().NewField11532;} }
            public TTReportField NewField11541 { get {return Footer().NewField11541;} }
            public TTReportField NewField28 { get {return Footer().NewField28;} }
            public TTReportField INSPECTIONMEMOCOLLACATIONDATE { get {return Footer().INSPECTIONMEMOCOLLACATIONDATE;} }
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
                public MuayeneMuhtirasi MyParentReport
                {
                    get { return (MuayeneMuhtirasi)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField12;
                public TTReportField NewField112;
                public TTReportField NewField1111;
                public TTReportField STOCKACTIONID;
                public TTReportField CONFIRMNO;
                public TTReportField RESPONSIBLEPROCUREMENTUNITDEF;
                public TTReportField NewField2;
                public TTReportField IDAREADI;
                public TTReportField NewField1113;
                public TTReportField NewField13111;
                public TTReportField NewField3;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField NewField16;
                public TTReportField NewField17;
                public TTReportField NewField18;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField161;
                public TTReportField NewField171;
                public TTReportField SUPPLIERNAME;
                public TTReportField TEMPORARYDELIVERYDATE;
                public TTReportField NewField152;
                public TTReportField INSPECTIONPLACE;
                public TTReportField DESCRIPTION;
                public TTReportField NewField173;
                public TTReportField NewField1371;
                public TTReportField NewField1372;
                public TTReportField NewField172;
                public TTReportField NewField1171;
                public TTReportField CONTRACTNODATE;
                public TTReportField CONTRACTDATE; 
                public PART1GroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 73;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 10, 37, 14, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Size = 6;
                    NewField1.Value = @"İŞLEM NO";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 14, 37, 18, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Size = 6;
                    NewField11.Value = @"ONAY NO";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 18, 37, 22, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Size = 6;
                    NewField111.Value = @"MUAYENE KOMİSYONU";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 10, 39, 14, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Size = 6;
                    NewField12.Value = @":";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 14, 39, 18, false);
                    NewField112.Name = "NewField112";
                    NewField112.TextFont.Size = 6;
                    NewField112.Value = @":";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 37, 18, 39, 22, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.TextFont.Size = 6;
                    NewField1111.Value = @":";

                    STOCKACTIONID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 10, 67, 14, false);
                    STOCKACTIONID.Name = "STOCKACTIONID";
                    STOCKACTIONID.FieldType = ReportFieldTypeEnum.ftVariable;
                    STOCKACTIONID.TextFont.Size = 6;
                    STOCKACTIONID.Value = @"{#STOCKACTIONID#}";

                    CONFIRMNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 14, 67, 18, false);
                    CONFIRMNO.Name = "CONFIRMNO";
                    CONFIRMNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONFIRMNO.TextFont.Size = 6;
                    CONFIRMNO.Value = @"{#CONFIRMNO#}";

                    RESPONSIBLEPROCUREMENTUNITDEF = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 39, 18, 112, 22, false);
                    RESPONSIBLEPROCUREMENTUNITDEF.Name = "RESPONSIBLEPROCUREMENTUNITDEF";
                    RESPONSIBLEPROCUREMENTUNITDEF.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESPONSIBLEPROCUREMENTUNITDEF.TextFont.Size = 6;
                    RESPONSIBLEPROCUREMENTUNITDEF.Value = @"{#RESPONSIBLEPROCUREMENTUNITDEF#}";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 9, 156, 14, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.TextFont.Size = 11;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"MUAYENE MUHTIRASI";

                    IDAREADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 46, 25, 202, 30, false);
                    IDAREADI.Name = "IDAREADI";
                    IDAREADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    IDAREADI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    IDAREADI.TextFont.Size = 11;
                    IDAREADI.TextFont.Bold = true;
                    IDAREADI.Value = @"";

                    NewField1113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 25, 44, 30, false);
                    NewField1113.Name = "NewField1113";
                    NewField1113.TextFont.Size = 8;
                    NewField1113.Value = @"Birlik veya kurum adresi";

                    NewField13111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 25, 46, 30, false);
                    NewField13111.Name = "NewField13111";
                    NewField13111.TextFont.Size = 8;
                    NewField13111.Value = @":";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 33, 79, 38, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"YÜKLENİCİ";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 43, 79, 48, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @"GETİRDİĞİ TARİH";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 48, 79, 53, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @"TESLİM ETMESİ GEREKEN SON TARİH";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 53, 79, 58, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Bold = true;
                    NewField16.Value = @"MUAYENE YERİ";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 58, 79, 63, false);
                    NewField17.Name = "NewField17";
                    NewField17.TextFont.Bold = true;
                    NewField17.Value = @"AÇIKLAMA";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 33, 81, 38, false);
                    NewField18.Name = "NewField18";
                    NewField18.TextFont.Bold = true;
                    NewField18.Value = @":";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 43, 81, 48, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Bold = true;
                    NewField141.Value = @":";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 48, 81, 53, false);
                    NewField151.Name = "NewField151";
                    NewField151.TextFont.Bold = true;
                    NewField151.Value = @":";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 53, 81, 58, false);
                    NewField161.Name = "NewField161";
                    NewField161.TextFont.Bold = true;
                    NewField161.Value = @":";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 58, 81, 63, false);
                    NewField171.Name = "NewField171";
                    NewField171.TextFont.Bold = true;
                    NewField171.Value = @":";

                    SUPPLIERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 33, 202, 38, false);
                    SUPPLIERNAME.Name = "SUPPLIERNAME";
                    SUPPLIERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLIERNAME.Value = @"{#SUPPLIERNAME#}";

                    TEMPORARYDELIVERYDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 43, 202, 48, false);
                    TEMPORARYDELIVERYDATE.Name = "TEMPORARYDELIVERYDATE";
                    TEMPORARYDELIVERYDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEMPORARYDELIVERYDATE.TextFormat = @"Short Date";
                    TEMPORARYDELIVERYDATE.Value = @"{#TEMPORARYDELIVERYDATE#}";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 48, 202, 53, false);
                    NewField152.Name = "NewField152";
                    NewField152.Value = @"";

                    INSPECTIONPLACE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 53, 202, 58, false);
                    INSPECTIONPLACE.Name = "INSPECTIONPLACE";
                    INSPECTIONPLACE.FieldType = ReportFieldTypeEnum.ftVariable;
                    INSPECTIONPLACE.Value = @"{#INSPECTIONPLACE#}";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 58, 202, 63, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    DESCRIPTION.Value = @"{#DESCRIPTION#}";

                    NewField173 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 67, 141, 72, false);
                    NewField173.Name = "NewField173";
                    NewField173.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField173.TextFont.Bold = true;
                    NewField173.Value = @"MALIN STOKNO / ADI";

                    NewField1371 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 67, 171, 72, false);
                    NewField1371.Name = "NewField1371";
                    NewField1371.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1371.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1371.TextFont.Bold = true;
                    NewField1371.Value = @"CİNSİ";

                    NewField1372 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 67, 202, 72, false);
                    NewField1372.Name = "NewField1372";
                    NewField1372.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1372.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1372.TextFont.Bold = true;
                    NewField1372.Value = @"MİKTARI";

                    NewField172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 38, 79, 43, false);
                    NewField172.Name = "NewField172";
                    NewField172.TextFont.Bold = true;
                    NewField172.Value = @"SÖZLEŞME NO / TARİH";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 79, 38, 81, 43, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.TextFont.Bold = true;
                    NewField1171.Value = @":";

                    CONTRACTNODATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 81, 38, 202, 43, false);
                    CONTRACTNODATE.Name = "CONTRACTNODATE";
                    CONTRACTNODATE.FieldType = ReportFieldTypeEnum.ftExpression;
                    CONTRACTNODATE.Value = @"{#CONTRACTNO#} + "" / "" + {%CONTRACTDATE%}";

                    CONTRACTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 207, 38, 232, 43, false);
                    CONTRACTDATE.Name = "CONTRACTDATE";
                    CONTRACTDATE.Visible = EvetHayirEnum.ehHayir;
                    CONTRACTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONTRACTDATE.TextFormat = @"Short Date";
                    CONTRACTDATE.Value = @"{#CONTRACTDATE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PurchaseExamination.GetByObjcetID_Class dataset_GetByObjcetID = ParentGroup.rsGroup.GetCurrentRecord<PurchaseExamination.GetByObjcetID_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField112.CalcValue = NewField112.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    STOCKACTIONID.CalcValue = (dataset_GetByObjcetID != null ? Globals.ToStringCore(dataset_GetByObjcetID.StockActionID) : "");
                    CONFIRMNO.CalcValue = (dataset_GetByObjcetID != null ? Globals.ToStringCore(dataset_GetByObjcetID.ConfirmNO) : "");
                    RESPONSIBLEPROCUREMENTUNITDEF.CalcValue = (dataset_GetByObjcetID != null ? Globals.ToStringCore(dataset_GetByObjcetID.Responsibleprocurementunitdef) : "");
                    NewField2.CalcValue = NewField2.Value;
                    IDAREADI.CalcValue = @"";
                    NewField1113.CalcValue = NewField1113.Value;
                    NewField13111.CalcValue = NewField13111.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField171.CalcValue = NewField171.Value;
                    SUPPLIERNAME.CalcValue = (dataset_GetByObjcetID != null ? Globals.ToStringCore(dataset_GetByObjcetID.Suppliername) : "");
                    TEMPORARYDELIVERYDATE.CalcValue = (dataset_GetByObjcetID != null ? Globals.ToStringCore(dataset_GetByObjcetID.TemporaryDeliveryDate) : "");
                    NewField152.CalcValue = NewField152.Value;
                    INSPECTIONPLACE.CalcValue = (dataset_GetByObjcetID != null ? Globals.ToStringCore(dataset_GetByObjcetID.InspectionPlace) : "");
                    DESCRIPTION.CalcValue = (dataset_GetByObjcetID != null ? Globals.ToStringCore(dataset_GetByObjcetID.Description) : "");
                    NewField173.CalcValue = NewField173.Value;
                    NewField1371.CalcValue = NewField1371.Value;
                    NewField1372.CalcValue = NewField1372.Value;
                    NewField172.CalcValue = NewField172.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    CONTRACTDATE.CalcValue = (dataset_GetByObjcetID != null ? Globals.ToStringCore(dataset_GetByObjcetID.ContractDate) : "");
                    CONTRACTNODATE.CalcValue = (dataset_GetByObjcetID != null ? Globals.ToStringCore(dataset_GetByObjcetID.ContractNo) : "") + " / " + MyParentReport.PART1.CONTRACTDATE.FormattedValue;
                    return new TTReportObject[] { NewField1,NewField11,NewField111,NewField12,NewField112,NewField1111,STOCKACTIONID,CONFIRMNO,RESPONSIBLEPROCUREMENTUNITDEF,NewField2,IDAREADI,NewField1113,NewField13111,NewField3,NewField14,NewField15,NewField16,NewField17,NewField18,NewField141,NewField151,NewField161,NewField171,SUPPLIERNAME,TEMPORARYDELIVERYDATE,NewField152,INSPECTIONPLACE,DESCRIPTION,NewField173,NewField1371,NewField1372,NewField172,NewField1171,CONTRACTDATE,CONTRACTNODATE};
                }

                public override void RunScript()
                {
#region PART1 HEADER_Script
                    IDAREADI.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "").ToString();
#endregion PART1 HEADER_Script
                }
            }
            public partial class PART1GroupFooter : TTReportSection
            {
                public MuayeneMuhtirasi MyParentReport
                {
                    get { return (MuayeneMuhtirasi)ParentReport; }
                }
                
                public TTReportField DESC;
                public TTReportField NUMBERTEXT;
                public TTReportField NewField4;
                public TTReportField NewField19;
                public TTReportField NewField20;
                public TTReportField NewField21;
                public TTReportField NewField22;
                public TTReportField NewField23;
                public TTReportField NewField24;
                public TTReportField NewField191;
                public TTReportField NewField102;
                public TTReportField NewField114;
                public TTReportField NewField122;
                public TTReportField NewField132;
                public TTReportField NewField25;
                public TTReportField NewField153;
                public TTReportField NewField154;
                public TTReportField NewField5;
                public TTReportField NewField26;
                public TTReportField NewField162;
                public TTReportField NewField163;
                public TTReportField NewField1361;
                public TTReportField NewField1261;
                public TTReportField NewField1262;
                public TTReportField NewField12621;
                public TTReportField NewField112621;
                public TTReportField NewField112622;
                public TTReportField NewField12622;
                public TTReportField NewField12623;
                public TTReportField NewField12624;
                public TTReportField NewField12625;
                public TTReportField NewField12626;
                public TTReportField NewField12627;
                public TTReportField NewField12628;
                public TTReportField NewField112623;
                public TTReportField NewField1126211;
                public TTReportField NewField1226211;
                public TTReportField NewField1326211;
                public TTReportField NewField11126211;
                public TTReportField NewField11126221;
                public TTReportField NewField1326212;
                public TTReportField NewField11126212;
                public TTReportField NewField11126222;
                public TTReportField NewField11126231;
                public TTReportField NewField111262111;
                public TTReportField NewField112262111;
                public TTReportField NewField1326213;
                public TTReportField NewField11126213;
                public TTReportField NewField11126223;
                public TTReportField NewField11126232;
                public TTReportField NewField111262112;
                public TTReportField NewField112262112;
                public TTReportField NewField123262111;
                public TTReportField NewField1211262111;
                public TTReportField NewField1211262211;
                public TTReportField NewField1111262321;
                public TTReportField NewField1111262322;
                public TTReportField NewField27;
                public TTReportField NewField192;
                public TTReportField NewField103;
                public TTReportField NewField115;
                public TTReportField NewField123;
                public TTReportField NewField133;
                public TTReportField NewField142;
                public TTReportField NewField1191;
                public TTReportField NewField1201;
                public TTReportField NewField1411;
                public TTReportField NewField1221;
                public TTReportField NewField1231;
                public TTReportField NewField155;
                public TTReportField NewField1351;
                public TTReportField NewField1451;
                public TTReportField NewField11531;
                public TTReportField NewField11532;
                public TTReportField NewField11541;
                public TTReportField NewField28;
                public TTReportField INSPECTIONMEMOCOLLACATIONDATE;
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

                    Height = 192;
                    RepeatCount = 0;
                    
                    DESC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 2, 202, 17, false);
                    DESC.Name = "DESC";
                    DESC.FieldType = ReportFieldTypeEnum.ftExpression;
                    DESC.MultiLine = EvetHayirEnum.ehEvet;
                    DESC.WordBreak = EvetHayirEnum.ehEvet;
                    DESC.ExpandTabs = EvetHayirEnum.ehEvet;
                    DESC.Value = @"""Yüklenici "" + {%SUPPLIERNAME%} + "" tarafından "" + {%IDAREADI%} + ""'na getirilmiş olan cins ve miktarı yukarıda yazılı "" + {@subgroupcount@} + "" ("" + {%NUMBERTEXT%} + "") kalem malzemenin "" + {%CONTRACTDATE%} + "" gün ve "" + {#CONTRACTNO#} + "" sayılı sözleşme gereğince muayenesinin yapılmasını arz ederim. "" + {%INSPECTIONMEMOCOLLACATIONDATE%}";

                    NUMBERTEXT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 1, 230, 6, false);
                    NUMBERTEXT.Name = "NUMBERTEXT";
                    NUMBERTEXT.Visible = EvetHayirEnum.ehHayir;
                    NUMBERTEXT.FieldType = ReportFieldTypeEnum.ftVariable;
                    NUMBERTEXT.TextFormat = @"NUMBERTEXT";
                    NUMBERTEXT.Value = @"{@subgroupcount@}";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 22, 38, 27, false);
                    NewField4.Name = "NewField4";
                    NewField4.Value = @"Görevi";

                    NewField19 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 31, 38, 36, false);
                    NewField19.Name = "NewField19";
                    NewField19.Value = @"İmzası";

                    NewField20 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 40, 38, 45, false);
                    NewField20.Name = "NewField20";
                    NewField20.Value = @"Rütbesi";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 46, 38, 51, false);
                    NewField21.Name = "NewField21";
                    NewField21.Value = @"Adı Soyadı";

                    NewField22 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 52, 38, 57, false);
                    NewField22.Name = "NewField22";
                    NewField22.Value = @"Sicil No";

                    NewField23 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 58, 38, 63, false);
                    NewField23.Name = "NewField23";
                    NewField23.Value = @"Birliği";

                    NewField24 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 22, 39, 27, false);
                    NewField24.Name = "NewField24";
                    NewField24.Value = @":";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 31, 39, 36, false);
                    NewField191.Name = "NewField191";
                    NewField191.Value = @":";

                    NewField102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 40, 39, 45, false);
                    NewField102.Name = "NewField102";
                    NewField102.Value = @":";

                    NewField114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 46, 39, 51, false);
                    NewField114.Name = "NewField114";
                    NewField114.Value = @":";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 52, 39, 57, false);
                    NewField122.Name = "NewField122";
                    NewField122.Value = @":";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 58, 39, 63, false);
                    NewField132.Name = "NewField132";
                    NewField132.Value = @":";

                    NewField25 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 22, 66, 27, false);
                    NewField25.Name = "NewField25";
                    NewField25.Value = @"Mal Saymanı";

                    NewField153 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 22, 129, 27, false);
                    NewField153.Name = "NewField153";
                    NewField153.Value = @"Hesap Sorumlusu";

                    NewField154 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 163, 22, 188, 27, false);
                    NewField154.Name = "NewField154";
                    NewField154.Value = @"Mal Sorumlusu";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 67, 203, 72, false);
                    NewField5.Name = "NewField5";
                    NewField5.Value = @"MUAYENE VE KABUL KOMİSYONU KARARI";

                    NewField26 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 73, 116, 78, false);
                    NewField26.Name = "NewField26";
                    NewField26.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField26.Value = @"Muayene Edildiği Tarih:";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 73, 203, 78, false);
                    NewField162.Name = "NewField162";
                    NewField162.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField162.Value = @"Kayıt Numarası:";

                    NewField163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 78, 65, 88, false);
                    NewField163.Name = "NewField163";
                    NewField163.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField163.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField163.MultiLine = EvetHayirEnum.ehEvet;
                    NewField163.Value = @"Sözleşme Makamı,
Tarih / No";

                    NewField1361 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 78, 116, 88, false);
                    NewField1361.Name = "NewField1361";
                    NewField1361.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1361.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1361.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1361.Value = @"KARAR";

                    NewField1261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 78, 203, 83, false);
                    NewField1261.Name = "NewField1261";
                    NewField1261.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1261.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1261.Value = @"Muayene Raporu, Diğer Ekler, varsa Şerh Notu";

                    NewField1262 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 83, 123, 88, false);
                    NewField1262.Name = "NewField1262";
                    NewField1262.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1262.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1262.Value = @"EK";

                    NewField12621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 83, 155, 88, false);
                    NewField12621.Name = "NewField12621";
                    NewField12621.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12621.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12621.Value = @"İSİM";

                    NewField112621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 83, 172, 88, false);
                    NewField112621.Name = "NewField112621";
                    NewField112621.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112621.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112621.Value = @"NO";

                    NewField112622 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 83, 203, 88, false);
                    NewField112622.Name = "NewField112622";
                    NewField112622.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112622.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112622.Value = @"TARİH";

                    NewField12622 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 88, 123, 93, false);
                    NewField12622.Name = "NewField12622";
                    NewField12622.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12622.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12622.Value = @"A";

                    NewField12623 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 93, 123, 98, false);
                    NewField12623.Name = "NewField12623";
                    NewField12623.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12623.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12623.Value = @"B";

                    NewField12624 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 98, 123, 103, false);
                    NewField12624.Name = "NewField12624";
                    NewField12624.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12624.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12624.Value = @"C";

                    NewField12625 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 103, 123, 108, false);
                    NewField12625.Name = "NewField12625";
                    NewField12625.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12625.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12625.Value = @"D";

                    NewField12626 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 108, 123, 113, false);
                    NewField12626.Name = "NewField12626";
                    NewField12626.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12626.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12626.Value = @"E";

                    NewField12627 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 113, 123, 118, false);
                    NewField12627.Name = "NewField12627";
                    NewField12627.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12627.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12627.Value = @"F";

                    NewField12628 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 118, 123, 123, false);
                    NewField12628.Name = "NewField12628";
                    NewField12628.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12628.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12628.Value = @"G";

                    NewField112623 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 88, 155, 93, false);
                    NewField112623.Name = "NewField112623";
                    NewField112623.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112623.Value = @"Mua.Baş.Tut.";

                    NewField1126211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 88, 172, 93, false);
                    NewField1126211.Name = "NewField1126211";
                    NewField1126211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1126211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1126211.Value = @"";

                    NewField1226211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 88, 203, 93, false);
                    NewField1226211.Name = "NewField1226211";
                    NewField1226211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1226211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1226211.Value = @"";

                    NewField1326211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 93, 155, 98, false);
                    NewField1326211.Name = "NewField1326211";
                    NewField1326211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1326211.Value = @"Mua.Kom.Rp.";

                    NewField11126211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 93, 172, 98, false);
                    NewField11126211.Name = "NewField11126211";
                    NewField11126211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11126211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11126211.Value = @"";

                    NewField11126221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 93, 203, 98, false);
                    NewField11126221.Name = "NewField11126221";
                    NewField11126221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11126221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11126221.Value = @"";

                    NewField1326212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 98, 155, 103, false);
                    NewField1326212.Name = "NewField1326212";
                    NewField1326212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1326212.Value = @"Fonk.Rp.";

                    NewField11126212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 98, 172, 103, false);
                    NewField11126212.Name = "NewField11126212";
                    NewField11126212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11126212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11126212.Value = @"";

                    NewField11126222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 98, 203, 103, false);
                    NewField11126222.Name = "NewField11126222";
                    NewField11126222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11126222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11126222.Value = @"";

                    NewField11126231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 103, 155, 108, false);
                    NewField11126231.Name = "NewField11126231";
                    NewField11126231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11126231.Value = @"";

                    NewField111262111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 103, 172, 108, false);
                    NewField111262111.Name = "NewField111262111";
                    NewField111262111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111262111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111262111.Value = @"";

                    NewField112262111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 103, 203, 108, false);
                    NewField112262111.Name = "NewField112262111";
                    NewField112262111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112262111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112262111.Value = @"";

                    NewField1326213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 108, 155, 113, false);
                    NewField1326213.Name = "NewField1326213";
                    NewField1326213.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1326213.Value = @"";

                    NewField11126213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 108, 172, 113, false);
                    NewField11126213.Name = "NewField11126213";
                    NewField11126213.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11126213.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11126213.Value = @"";

                    NewField11126223 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 108, 203, 113, false);
                    NewField11126223.Name = "NewField11126223";
                    NewField11126223.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11126223.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11126223.Value = @"";

                    NewField11126232 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 113, 155, 118, false);
                    NewField11126232.Name = "NewField11126232";
                    NewField11126232.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11126232.Value = @"";

                    NewField111262112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 113, 172, 118, false);
                    NewField111262112.Name = "NewField111262112";
                    NewField111262112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111262112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111262112.Value = @"";

                    NewField112262112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 113, 203, 118, false);
                    NewField112262112.Name = "NewField112262112";
                    NewField112262112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112262112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112262112.Value = @"";

                    NewField123262111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 123, 118, 155, 123, false);
                    NewField123262111.Name = "NewField123262111";
                    NewField123262111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField123262111.Value = @"";

                    NewField1211262111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 155, 118, 172, 123, false);
                    NewField1211262111.Name = "NewField1211262111";
                    NewField1211262111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211262111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211262111.Value = @"";

                    NewField1211262211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 118, 203, 123, false);
                    NewField1211262211.Name = "NewField1211262211";
                    NewField1211262211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211262211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211262211.Value = @"";

                    NewField1111262321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 65, 88, 116, 123, false);
                    NewField1111262321.Name = "NewField1111262321";
                    NewField1111262321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111262321.Value = @"";

                    NewField1111262322 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 88, 65, 123, false);
                    NewField1111262322.Name = "NewField1111262322";
                    NewField1111262322.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111262322.Value = @"";

                    NewField27 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 144, 38, 149, false);
                    NewField27.Name = "NewField27";
                    NewField27.Value = @"Görevi";

                    NewField192 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 153, 38, 158, false);
                    NewField192.Name = "NewField192";
                    NewField192.Value = @"İmzası";

                    NewField103 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 162, 38, 167, false);
                    NewField103.Name = "NewField103";
                    NewField103.Value = @"Rütbesi";

                    NewField115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 168, 38, 173, false);
                    NewField115.Name = "NewField115";
                    NewField115.Value = @"Adı Soyadı";

                    NewField123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 174, 38, 179, false);
                    NewField123.Name = "NewField123";
                    NewField123.Value = @"Sicil No";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 180, 38, 185, false);
                    NewField133.Name = "NewField133";
                    NewField133.Value = @"Birliği";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 144, 39, 149, false);
                    NewField142.Name = "NewField142";
                    NewField142.Value = @":";

                    NewField1191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 153, 39, 158, false);
                    NewField1191.Name = "NewField1191";
                    NewField1191.Value = @":";

                    NewField1201 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 162, 39, 167, false);
                    NewField1201.Name = "NewField1201";
                    NewField1201.Value = @":";

                    NewField1411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 168, 39, 173, false);
                    NewField1411.Name = "NewField1411";
                    NewField1411.Value = @":";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 174, 39, 179, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.Value = @":";

                    NewField1231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 180, 39, 185, false);
                    NewField1231.Name = "NewField1231";
                    NewField1231.Value = @":";

                    NewField155 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 144, 71, 149, false);
                    NewField155.Name = "NewField155";
                    NewField155.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField155.Value = @"BAŞKAN";

                    NewField1351 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 144, 104, 149, false);
                    NewField1351.Name = "NewField1351";
                    NewField1351.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1351.Value = @"ÜYE";

                    NewField1451 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 144, 137, 149, false);
                    NewField1451.Name = "NewField1451";
                    NewField1451.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1451.Value = @"ÜYE";

                    NewField11531 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 137, 203, 142, false);
                    NewField11531.Name = "NewField11531";
                    NewField11531.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11531.TextFont.Bold = true;
                    NewField11531.TextFont.Underline = true;
                    NewField11531.Value = @"MUAYENE KABUL KOMİSYONU";

                    NewField11532 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 144, 170, 149, false);
                    NewField11532.Name = "NewField11532";
                    NewField11532.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11532.Value = @"ÜYE";

                    NewField11541 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 144, 203, 149, false);
                    NewField11541.Name = "NewField11541";
                    NewField11541.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11541.Value = @"ÜYE";

                    NewField28 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 124, 203, 134, false);
                    NewField28.Name = "NewField28";
                    NewField28.MultiLine = EvetHayirEnum.ehEvet;
                    NewField28.WordBreak = EvetHayirEnum.ehEvet;
                    NewField28.Value = @"Muayenesi istenilen                                                                                                                             in komisyonu muayenesi yapılarak sonucu yukarıda yazılmıştır.";

                    INSPECTIONMEMOCOLLACATIONDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 205, 12, 230, 17, false);
                    INSPECTIONMEMOCOLLACATIONDATE.Name = "INSPECTIONMEMOCOLLACATIONDATE";
                    INSPECTIONMEMOCOLLACATIONDATE.Visible = EvetHayirEnum.ehHayir;
                    INSPECTIONMEMOCOLLACATIONDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    INSPECTIONMEMOCOLLACATIONDATE.TextFormat = @"Short Date";
                    INSPECTIONMEMOCOLLACATIONDATE.Value = @"{#INSPECTIONMEMOCOLLACATIONDATE#}";

                    NAMESURNAME5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 168, 203, 173, false);
                    NAMESURNAME5.Name = "NAMESURNAME5";
                    NAMESURNAME5.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME5.CaseFormat = CaseFormatEnum.fcNameSurname;
                    NAMESURNAME5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME5.TextFont.Size = 8;
                    NAMESURNAME5.Value = @"";

                    NAMESURNAME2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 168, 104, 173, false);
                    NAMESURNAME2.Name = "NAMESURNAME2";
                    NAMESURNAME2.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME2.CaseFormat = CaseFormatEnum.fcNameSurname;
                    NAMESURNAME2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME2.TextFont.Size = 8;
                    NAMESURNAME2.Value = @"";

                    NAMESURNAME4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 168, 170, 173, false);
                    NAMESURNAME4.Name = "NAMESURNAME4";
                    NAMESURNAME4.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME4.CaseFormat = CaseFormatEnum.fcNameSurname;
                    NAMESURNAME4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME4.TextFont.Size = 8;
                    NAMESURNAME4.Value = @"";

                    NAMESURNAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 168, 71, 173, false);
                    NAMESURNAME1.Name = "NAMESURNAME1";
                    NAMESURNAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME1.CaseFormat = CaseFormatEnum.fcNameSurname;
                    NAMESURNAME1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME1.TextFont.Size = 8;
                    NAMESURNAME1.Value = @"";

                    HOSPFUNC1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 162, 71, 167, false);
                    HOSPFUNC1.Name = "HOSPFUNC1";
                    HOSPFUNC1.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC1.TextFont.Size = 8;
                    HOSPFUNC1.Value = @"";

                    NAMESURNAME3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 168, 137, 173, false);
                    NAMESURNAME3.Name = "NAMESURNAME3";
                    NAMESURNAME3.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAMESURNAME3.CaseFormat = CaseFormatEnum.fcNameSurname;
                    NAMESURNAME3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NAMESURNAME3.TextFont.Size = 8;
                    NAMESURNAME3.Value = @"";

                    HOSPFUNC3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 162, 137, 167, false);
                    HOSPFUNC3.Name = "HOSPFUNC3";
                    HOSPFUNC3.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC3.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC3.TextFont.Size = 8;
                    HOSPFUNC3.Value = @"";

                    HOSPFUNC5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 162, 203, 167, false);
                    HOSPFUNC5.Name = "HOSPFUNC5";
                    HOSPFUNC5.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC5.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC5.TextFont.Size = 8;
                    HOSPFUNC5.Value = @"";

                    HOSPFUNC2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 162, 104, 167, false);
                    HOSPFUNC2.Name = "HOSPFUNC2";
                    HOSPFUNC2.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC2.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC2.TextFont.Size = 8;
                    HOSPFUNC2.Value = @"";

                    HOSPFUNC4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 162, 170, 167, false);
                    HOSPFUNC4.Name = "HOSPFUNC4";
                    HOSPFUNC4.FieldType = ReportFieldTypeEnum.ftVariable;
                    HOSPFUNC4.CaseFormat = CaseFormatEnum.fcTitleCase;
                    HOSPFUNC4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HOSPFUNC4.TextFont.Size = 8;
                    HOSPFUNC4.Value = @"";

                    RECORDID1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 174, 71, 179, false);
                    RECORDID1.Name = "RECORDID1";
                    RECORDID1.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECORDID1.CaseFormat = CaseFormatEnum.fcNameSurname;
                    RECORDID1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RECORDID1.TextFont.Size = 8;
                    RECORDID1.Value = @"";

                    RECORDID2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 174, 104, 179, false);
                    RECORDID2.Name = "RECORDID2";
                    RECORDID2.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECORDID2.CaseFormat = CaseFormatEnum.fcNameSurname;
                    RECORDID2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RECORDID2.TextFont.Size = 8;
                    RECORDID2.Value = @"";

                    RECORDID3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 174, 137, 179, false);
                    RECORDID3.Name = "RECORDID3";
                    RECORDID3.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECORDID3.CaseFormat = CaseFormatEnum.fcNameSurname;
                    RECORDID3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RECORDID3.TextFont.Size = 8;
                    RECORDID3.Value = @"";

                    RECORDID4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 174, 170, 179, false);
                    RECORDID4.Name = "RECORDID4";
                    RECORDID4.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECORDID4.CaseFormat = CaseFormatEnum.fcNameSurname;
                    RECORDID4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RECORDID4.TextFont.Size = 8;
                    RECORDID4.Value = @"";

                    RECORDID5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 172, 174, 203, 179, false);
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
                    NUMBERTEXT.CalcValue = (ParentGroup.SubGroupCount - 1).ToString();
                    NewField4.CalcValue = NewField4.Value;
                    NewField19.CalcValue = NewField19.Value;
                    NewField20.CalcValue = NewField20.Value;
                    NewField21.CalcValue = NewField21.Value;
                    NewField22.CalcValue = NewField22.Value;
                    NewField23.CalcValue = NewField23.Value;
                    NewField24.CalcValue = NewField24.Value;
                    NewField191.CalcValue = NewField191.Value;
                    NewField102.CalcValue = NewField102.Value;
                    NewField114.CalcValue = NewField114.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField132.CalcValue = NewField132.Value;
                    NewField25.CalcValue = NewField25.Value;
                    NewField153.CalcValue = NewField153.Value;
                    NewField154.CalcValue = NewField154.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField26.CalcValue = NewField26.Value;
                    NewField162.CalcValue = NewField162.Value;
                    NewField163.CalcValue = NewField163.Value;
                    NewField1361.CalcValue = NewField1361.Value;
                    NewField1261.CalcValue = NewField1261.Value;
                    NewField1262.CalcValue = NewField1262.Value;
                    NewField12621.CalcValue = NewField12621.Value;
                    NewField112621.CalcValue = NewField112621.Value;
                    NewField112622.CalcValue = NewField112622.Value;
                    NewField12622.CalcValue = NewField12622.Value;
                    NewField12623.CalcValue = NewField12623.Value;
                    NewField12624.CalcValue = NewField12624.Value;
                    NewField12625.CalcValue = NewField12625.Value;
                    NewField12626.CalcValue = NewField12626.Value;
                    NewField12627.CalcValue = NewField12627.Value;
                    NewField12628.CalcValue = NewField12628.Value;
                    NewField112623.CalcValue = NewField112623.Value;
                    NewField1126211.CalcValue = NewField1126211.Value;
                    NewField1226211.CalcValue = NewField1226211.Value;
                    NewField1326211.CalcValue = NewField1326211.Value;
                    NewField11126211.CalcValue = NewField11126211.Value;
                    NewField11126221.CalcValue = NewField11126221.Value;
                    NewField1326212.CalcValue = NewField1326212.Value;
                    NewField11126212.CalcValue = NewField11126212.Value;
                    NewField11126222.CalcValue = NewField11126222.Value;
                    NewField11126231.CalcValue = NewField11126231.Value;
                    NewField111262111.CalcValue = NewField111262111.Value;
                    NewField112262111.CalcValue = NewField112262111.Value;
                    NewField1326213.CalcValue = NewField1326213.Value;
                    NewField11126213.CalcValue = NewField11126213.Value;
                    NewField11126223.CalcValue = NewField11126223.Value;
                    NewField11126232.CalcValue = NewField11126232.Value;
                    NewField111262112.CalcValue = NewField111262112.Value;
                    NewField112262112.CalcValue = NewField112262112.Value;
                    NewField123262111.CalcValue = NewField123262111.Value;
                    NewField1211262111.CalcValue = NewField1211262111.Value;
                    NewField1211262211.CalcValue = NewField1211262211.Value;
                    NewField1111262321.CalcValue = NewField1111262321.Value;
                    NewField1111262322.CalcValue = NewField1111262322.Value;
                    NewField27.CalcValue = NewField27.Value;
                    NewField192.CalcValue = NewField192.Value;
                    NewField103.CalcValue = NewField103.Value;
                    NewField115.CalcValue = NewField115.Value;
                    NewField123.CalcValue = NewField123.Value;
                    NewField133.CalcValue = NewField133.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField1191.CalcValue = NewField1191.Value;
                    NewField1201.CalcValue = NewField1201.Value;
                    NewField1411.CalcValue = NewField1411.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1231.CalcValue = NewField1231.Value;
                    NewField155.CalcValue = NewField155.Value;
                    NewField1351.CalcValue = NewField1351.Value;
                    NewField1451.CalcValue = NewField1451.Value;
                    NewField11531.CalcValue = NewField11531.Value;
                    NewField11532.CalcValue = NewField11532.Value;
                    NewField11541.CalcValue = NewField11541.Value;
                    NewField28.CalcValue = NewField28.Value;
                    INSPECTIONMEMOCOLLACATIONDATE.CalcValue = (dataset_GetByObjcetID != null ? Globals.ToStringCore(dataset_GetByObjcetID.InspectionMemoCollacationDate) : "");
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
                    DESC.CalcValue = "Yüklenici " + MyParentReport.PART1.SUPPLIERNAME.CalcValue + " tarafından " + MyParentReport.PART1.IDAREADI.CalcValue + "'na getirilmiş olan cins ve miktarı yukarıda yazılı " + (ParentGroup.SubGroupCount - 1).ToString() + " (" + MyParentReport.PART1.NUMBERTEXT.FormattedValue + ") kalem malzemenin " + MyParentReport.PART1.CONTRACTDATE.FormattedValue + " gün ve " + (dataset_GetByObjcetID != null ? Globals.ToStringCore(dataset_GetByObjcetID.ContractNo) : "") + " sayılı sözleşme gereğince muayenesinin yapılmasını arz ederim. " + MyParentReport.PART1.INSPECTIONMEMOCOLLACATIONDATE.FormattedValue;
                    return new TTReportObject[] { NUMBERTEXT,NewField4,NewField19,NewField20,NewField21,NewField22,NewField23,NewField24,NewField191,NewField102,NewField114,NewField122,NewField132,NewField25,NewField153,NewField154,NewField5,NewField26,NewField162,NewField163,NewField1361,NewField1261,NewField1262,NewField12621,NewField112621,NewField112622,NewField12622,NewField12623,NewField12624,NewField12625,NewField12626,NewField12627,NewField12628,NewField112623,NewField1126211,NewField1226211,NewField1326211,NewField11126211,NewField11126221,NewField1326212,NewField11126212,NewField11126222,NewField11126231,NewField111262111,NewField112262111,NewField1326213,NewField11126213,NewField11126223,NewField11126232,NewField111262112,NewField112262112,NewField123262111,NewField1211262111,NewField1211262211,NewField1111262321,NewField1111262322,NewField27,NewField192,NewField103,NewField115,NewField123,NewField133,NewField142,NewField1191,NewField1201,NewField1411,NewField1221,NewField1231,NewField155,NewField1351,NewField1451,NewField11531,NewField11532,NewField11541,NewField28,INSPECTIONMEMOCOLLACATIONDATE,NAMESURNAME5,NAMESURNAME2,NAMESURNAME4,NAMESURNAME1,HOSPFUNC1,NAMESURNAME3,HOSPFUNC3,HOSPFUNC5,HOSPFUNC2,HOSPFUNC4,RECORDID1,RECORDID2,RECORDID3,RECORDID4,RECORDID5,DESC};
                }

                public override void RunScript()
                {
#region PART1 FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((MuayeneMuhtirasi)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
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
            public MuayeneMuhtirasi MyParentReport
            {
                get { return (MuayeneMuhtirasi)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
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
                list[0] = new TTReportNqlData<StockAction.StockActionInDetailsReportQuery_Class>("StockActionInDetailsReportQuery", StockAction.StockActionInDetailsReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public MuayeneMuhtirasi MyParentReport
                {
                    get { return (MuayeneMuhtirasi)ParentReport; }
                }
                
                public TTReportField MATERIALNAME;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField AMOUNT; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 6;
                    RepeatCount = 0;
                    
                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 141, 5, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    MATERIALNAME.Value = @"{#NATOSTOCKNO#} + "" - "" + {#MATERIALNAME#}";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 141, 0, 171, 5, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 171, 0, 202, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT.Value = @"{#AMOUNT#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockAction.StockActionInDetailsReportQuery_Class dataset_StockActionInDetailsReportQuery = ParentGroup.rsGroup.GetCurrentRecord<StockAction.StockActionInDetailsReportQuery_Class>(0);
                    DISTRIBUTIONTYPE.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.DistributionType) : "");
                    AMOUNT.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.Amount) : "");
                    MATERIALNAME.CalcValue = (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.NATOStockNO) : "") + " - " + (dataset_StockActionInDetailsReportQuery != null ? Globals.ToStringCore(dataset_StockActionInDetailsReportQuery.Materialname) : "");
                    return new TTReportObject[] { DISTRIBUTIONTYPE,AMOUNT,MATERIALNAME};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public MuayeneMuhtirasi()
        {
            PART1 = new PART1Group(this,"PART1");
            MAIN = new MAINGroup(PART1,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "İşlem No", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("9b2306a7-2381-4099-8a37-63dbae04c00e");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "MUAYENEMUHTIRASI";
            Caption = "Muayene Muhtırası";
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