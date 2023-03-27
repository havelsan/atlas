
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
    /// Tutanaktır(İkmal Müdürlük Birimine Teslim)
    /// </summary>
    public partial class Tutanak_IkmalMudurlukTeslimi : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string DELIVERERID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string RECEIVERERID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public Tutanak_IkmalMudurlukTeslimi MyParentReport
            {
                get { return (Tutanak_IkmalMudurlukTeslimi)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField REPORTNAME { get {return Header().REPORTNAME;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField ORDERNO { get {return Header().ORDERNO;} }
            public TTReportField MATERIALNAME { get {return Header().MATERIALNAME;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField NewField1241 { get {return Header().NewField1241;} }
            public TTReportField NewField1242 { get {return Header().NewField1242;} }
            public TTReportField NewField12421 { get {return Header().NewField12421;} }
            public TTReportField NewField112421 { get {return Header().NewField112421;} }
            public TTReportField NewField112422 { get {return Header().NewField112422;} }
            public TTReportField NewField112423 { get {return Header().NewField112423;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField DATE { get {return Header().DATE;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField MILITARYUNIT1 { get {return Header().MILITARYUNIT1;} }
            public TTReportField MATERIALNAME11 { get {return Header().MATERIALNAME11;} }
            public TTReportField REQUESTNO1 { get {return Header().REQUESTNO1;} }
            public TTReportField REFERTYPENAME { get {return Header().REFERTYPENAME;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField16 { get {return Header().NewField16;} }
            public TTReportField TOTAL { get {return Footer().TOTAL;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportField TOTALITEMAMOUNT { get {return Footer().TOTALITEMAMOUNT;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField NAME { get {return Footer().NAME;} }
            public TTReportField RANK { get {return Footer().RANK;} }
            public TTReportField TITLE { get {return Footer().TITLE;} }
            public TTReportField NAME1 { get {return Footer().NAME1;} }
            public TTReportField RANK1 { get {return Footer().RANK1;} }
            public TTReportField TITLE1 { get {return Footer().TITLE1;} }
            public TTReportField DELIVERTITLE { get {return Footer().DELIVERTITLE;} }
            public TTReportField RECEIVERTITLE { get {return Footer().RECEIVERTITLE;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
            public TTReportShape NewLine131 { get {return Footer().NewLine131;} }
            public TTReportShape NewLine141 { get {return Footer().NewLine141;} }
            public TTReportShape NewLine151 { get {return Footer().NewLine151;} }
            public TTReportShape NewLine161 { get {return Footer().NewLine161;} }
            public TTReportShape NewLine171 { get {return Footer().NewLine171;} }
            public TTReportShape NewLine181 { get {return Footer().NewLine181;} }
            public TTReportShape NewLine191 { get {return Footer().NewLine191;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ReferToUpperLevel.GetReferToUpperLevelByObjectIDQuery_Class>("GetReferToUpperLevelByObjectIDQuery", ReferToUpperLevel.GetReferToUpperLevelByObjectIDQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public Tutanak_IkmalMudurlukTeslimi MyParentReport
                {
                    get { return (Tutanak_IkmalMudurlukTeslimi)ParentReport; }
                }
                
                public TTReportField REPORTNAME;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField13;
                public TTReportField NewField131;
                public TTReportField NewField132;
                public TTReportField ORDERNO;
                public TTReportField MATERIALNAME;
                public TTReportField NewField2;
                public TTReportField NewField14;
                public TTReportField NewField141;
                public TTReportField NewField142;
                public TTReportField NewField1241;
                public TTReportField NewField1242;
                public TTReportField NewField12421;
                public TTReportField NewField112421;
                public TTReportField NewField112422;
                public TTReportField NewField112423;
                public TTReportField NewField111;
                public TTReportField DATE;
                public TTReportField NewField1111;
                public TTReportField MILITARYUNIT1;
                public TTReportField MATERIALNAME11;
                public TTReportField REQUESTNO1;
                public TTReportField REFERTYPENAME;
                public TTReportField NewField4;
                public TTReportField NewField16; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 48;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    REPORTNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 190, 5, false);
                    REPORTNAME.Name = "REPORTNAME";
                    REPORTNAME.TextFont.Size = 11;
                    REPORTNAME.TextFont.Bold = true;
                    REPORTNAME.Value = @"TUTANAKTIR";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 10, 40, 15, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haleft;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"SİPARİŞ NO";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 15, 40, 20, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haleft;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"BİRLİĞİ";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 27, 40, 32, false);
                    NewField12.Name = "NewField12";
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haleft;
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"ANA MALZEMENİN ADI";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 10, 41, 15, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @":";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 15, 41, 20, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Bold = true;
                    NewField131.Value = @":";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 27, 41, 32, false);
                    NewField132.Name = "NewField132";
                    NewField132.TextFont.Bold = true;
                    NewField132.Value = @":";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 10, 150, 15, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.HorzAlign = HorizontalAlignmentEnum.haleft;
                    ORDERNO.Value = @"";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 27, 190, 32, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.HorzAlign = HorizontalAlignmentEnum.haleft;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.Value = @"{#FANAME#} ({#AMOUNT#} {#DISTRIBUTIONTYPE#})";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 38, 8, 48, false);
                    NewField2.Name = "NewField2";
                    NewField2.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField2.MultiLine = EvetHayirEnum.ehEvet;
                    NewField2.WordBreak = EvetHayirEnum.ehEvet;
                    NewField2.TextFont.Bold = true;
                    NewField2.Value = @"S. NU.";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 38, 36, 48, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @"NATO STOK NU.";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 38, 98, 48, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.TextFont.Bold = true;
                    NewField141.Value = @"MALZEMENİN ADI";

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 38, 113, 48, false);
                    NewField142.Name = "NewField142";
                    NewField142.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField142.TextFont.Bold = true;
                    NewField142.Value = @"MİKTAR";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 38, 134, 48, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1241.TextFont.Bold = true;
                    NewField1241.Value = @"BİRİMİ";

                    NewField1242 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 38, 190, 43, false);
                    NewField1242.Name = "NewField1242";
                    NewField1242.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1242.TextFont.Bold = true;
                    NewField1242.Value = @"DAĞILIMI";

                    NewField12421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 43, 149, 48, false);
                    NewField12421.Name = "NewField12421";
                    NewField12421.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12421.TextFont.Size = 9;
                    NewField12421.TextFont.Bold = true;
                    NewField12421.Value = @"NORMAL";

                    NewField112421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 43, 164, 48, false);
                    NewField112421.Name = "NewField112421";
                    NewField112421.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112421.TextFont.Size = 9;
                    NewField112421.TextFont.Bold = true;
                    NewField112421.Value = @"HASARLI";

                    NewField112422 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 43, 178, 48, false);
                    NewField112422.Name = "NewField112422";
                    NewField112422.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112422.TextFont.Size = 9;
                    NewField112422.TextFont.Bold = true;
                    NewField112422.Value = @"DEĞİŞİK";

                    NewField112423 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 43, 190, 48, false);
                    NewField112423.Name = "NewField112423";
                    NewField112423.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112423.TextFont.Size = 9;
                    NewField112423.TextFont.Bold = true;
                    NewField112423.Value = @"EKSİK";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 21, 162, 26, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haleft;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @"TARİH:";

                    DATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 21, 190, 26, false);
                    DATE.Name = "DATE";
                    DATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DATE.TextFormat = @"dd/MM/yyyy";
                    DATE.HorzAlign = HorizontalAlignmentEnum.haleft;
                    DATE.Value = @"{@printdate@}";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 10, 170, 15, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haleft;
                    NewField1111.TextFont.Name = "Arial Narrow";
                    NewField1111.TextFont.Size = 8;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @"Yazı Kayıt Nu.:";

                    MILITARYUNIT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 16, 149, 26, false);
                    MILITARYUNIT1.Name = "MILITARYUNIT1";
                    MILITARYUNIT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNIT1.HorzAlign = HorizontalAlignmentEnum.haleft;
                    MILITARYUNIT1.MultiLine = EvetHayirEnum.ehEvet;
                    MILITARYUNIT1.WordBreak = EvetHayirEnum.ehEvet;
                    MILITARYUNIT1.TextFont.Name = "Arial Narrow";
                    MILITARYUNIT1.TextFont.Size = 9;
                    MILITARYUNIT1.Value = @"{#SENDERMILITARYUNIT#}";

                    MATERIALNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 32, 190, 37, false);
                    MATERIALNAME11.Name = "MATERIALNAME11";
                    MATERIALNAME11.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME11.HorzAlign = HorizontalAlignmentEnum.haleft;
                    MATERIALNAME11.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME11.Value = @"{#MARK#} - {#MODEL#} - {#SERIALNUMBER#}";

                    REQUESTNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 10, 190, 15, false);
                    REQUESTNO1.Name = "REQUESTNO1";
                    REQUESTNO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO1.TextFormat = @"dd/MM/yyyy";
                    REQUESTNO1.HorzAlign = HorizontalAlignmentEnum.haleft;
                    REQUESTNO1.TextFont.Name = "Arial Narrow";
                    REQUESTNO1.TextFont.Size = 8;
                    REQUESTNO1.Value = @"{#REQUESTNO#}";

                    REFERTYPENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 132, 0, 157, 5, false);
                    REFERTYPENAME.Name = "REFERTYPENAME";
                    REFERTYPENAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    REFERTYPENAME.CaseFormat = CaseFormatEnum.fcUpperCase;
                    REFERTYPENAME.ObjectDefName = "ReferTypeEnum";
                    REFERTYPENAME.DataMember = "DISPLAYTEXT";
                    REFERTYPENAME.TextFont.Name = "Arial Narrow";
                    REFERTYPENAME.TextFont.Bold = true;
                    REFERTYPENAME.Value = @"{#REFERTYPE#}";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 165, 0, 167, 5, false);
                    NewField4.Name = "NewField4";
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haleft;
                    NewField4.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField4.TextFont.Name = "Arial Narrow";
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @")";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 0, 122, 5, false);
                    NewField16.Name = "NewField16";
                    NewField16.HorzAlign = HorizontalAlignmentEnum.haleft;
                    NewField16.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField16.TextFont.Name = "Arial Narrow";
                    NewField16.TextFont.Bold = true;
                    NewField16.Value = @"(";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReferToUpperLevel.GetReferToUpperLevelByObjectIDQuery_Class dataset_GetReferToUpperLevelByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<ReferToUpperLevel.GetReferToUpperLevelByObjectIDQuery_Class>(0);
                    REPORTNAME.CalcValue = REPORTNAME.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField132.CalcValue = NewField132.Value;
                    ORDERNO.CalcValue = @"";
                    MATERIALNAME.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.Faname) : "") + @" (" + (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.Amount) : "") + @" " + (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.DistributionType) : "") + @")";
                    NewField2.CalcValue = NewField2.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField1241.CalcValue = NewField1241.Value;
                    NewField1242.CalcValue = NewField1242.Value;
                    NewField12421.CalcValue = NewField12421.Value;
                    NewField112421.CalcValue = NewField112421.Value;
                    NewField112422.CalcValue = NewField112422.Value;
                    NewField112423.CalcValue = NewField112423.Value;
                    NewField111.CalcValue = NewField111.Value;
                    DATE.CalcValue = DateTime.Now.ToShortDateString();
                    NewField1111.CalcValue = NewField1111.Value;
                    MILITARYUNIT1.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.Sendermilitaryunit) : "");
                    MATERIALNAME11.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.Mark) : "") + @" - " + (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.Model) : "") + @" - " + (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.SerialNumber) : "");
                    REQUESTNO1.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.RequestNo) : "");
                    REFERTYPENAME.CalcValue = (dataset_GetReferToUpperLevelByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetReferToUpperLevelByObjectIDQuery.ReferType) : "");
                    REFERTYPENAME.PostFieldValueCalculation();
                    NewField4.CalcValue = NewField4.Value;
                    NewField16.CalcValue = NewField16.Value;
                    return new TTReportObject[] { REPORTNAME,NewField1,NewField11,NewField12,NewField13,NewField131,NewField132,ORDERNO,MATERIALNAME,NewField2,NewField14,NewField141,NewField142,NewField1241,NewField1242,NewField12421,NewField112421,NewField112422,NewField112423,NewField111,DATE,NewField1111,MILITARYUNIT1,MATERIALNAME11,REQUESTNO1,REFERTYPENAME,NewField4,NewField16};
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public Tutanak_IkmalMudurlukTeslimi MyParentReport
                {
                    get { return (Tutanak_IkmalMudurlukTeslimi)ParentReport; }
                }
                
                public TTReportField TOTAL;
                public TTReportShape NewLine1;
                public TTReportField TOTALITEMAMOUNT;
                public TTReportField NewField3;
                public TTReportField NewField15;
                public TTReportField NAME;
                public TTReportField RANK;
                public TTReportField TITLE;
                public TTReportField NAME1;
                public TTReportField RANK1;
                public TTReportField TITLE1;
                public TTReportField DELIVERTITLE;
                public TTReportField RECEIVERTITLE;
                public TTReportShape NewLine11;
                public TTReportShape NewLine111;
                public TTReportShape NewLine121;
                public TTReportShape NewLine131;
                public TTReportShape NewLine141;
                public TTReportShape NewLine151;
                public TTReportShape NewLine161;
                public TTReportShape NewLine171;
                public TTReportShape NewLine181;
                public TTReportShape NewLine191; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 52;
                    RepeatCount = 0;
                    
                    TOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 190, 5, false);
                    TOTAL.Name = "TOTAL";
                    TOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTAL.TextFont.Bold = true;
                    TOTAL.Value = @"/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/ YALNIZ ({@subgroupcount@}) KALEMDİR. /_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 5, 190, 5, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    TOTALITEMAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 8, 190, 18, false);
                    TOTALITEMAMOUNT.Name = "TOTALITEMAMOUNT";
                    TOTALITEMAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALITEMAMOUNT.HorzAlign = HorizontalAlignmentEnum.haleft;
                    TOTALITEMAMOUNT.VertAlign = VerticalAlignmentEnum.vaTop;
                    TOTALITEMAMOUNT.MultiLine = EvetHayirEnum.ehEvet;
                    TOTALITEMAMOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    TOTALITEMAMOUNT.Value = @"Yukarıda adı, miktarı ve birimi yazılı olan ({@subgroupcount@}) kalem malzeme ve ana malzeme faal/hek durumda ve tam olarak teslim alınmıştır.";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 21, 40, 26, false);
                    NewField3.Name = "NewField3";
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @"TESLİM EDEN";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 21, 180, 26, false);
                    NewField15.Name = "NewField15";
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @"TESLİM ALAN";

                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 26, 40, 31, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.CaseFormat = CaseFormatEnum.fcNameSurname;
                    NAME.NoClip = EvetHayirEnum.ehEvet;
                    NAME.ObjectDefName = "ResUser";
                    NAME.DataMember = "NAME";
                    NAME.Value = @"{@DELIVERERID@}";

                    RANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 31, 40, 36, false);
                    RANK.Name = "RANK";
                    RANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    RANK.CaseFormat = CaseFormatEnum.fcTitleCase;
                    RANK.NoClip = EvetHayirEnum.ehEvet;
                    RANK.ObjectDefName = "RESUSER";
                    RANK.DataMember = "RANK.NAME";
                    RANK.Value = @"{@DELIVERERID@}";

                    TITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 36, 40, 41, false);
                    TITLE.Name = "TITLE";
                    TITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    TITLE.CaseFormat = CaseFormatEnum.fcTitleCase;
                    TITLE.NoClip = EvetHayirEnum.ehEvet;
                    TITLE.ObjectDefName = "UserTitleEnum";
                    TITLE.DataMember = "DISPLAYTEXT";
                    TITLE.Value = @"{%DELIVERTITLE%}";

                    NAME1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 26, 180, 31, false);
                    NAME1.Name = "NAME1";
                    NAME1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME1.CaseFormat = CaseFormatEnum.fcNameSurname;
                    NAME1.NoClip = EvetHayirEnum.ehEvet;
                    NAME1.ObjectDefName = "ResUser";
                    NAME1.DataMember = "NAME";
                    NAME1.Value = @"{@RECEIVERERID@}";

                    RANK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 31, 180, 36, false);
                    RANK1.Name = "RANK1";
                    RANK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    RANK1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    RANK1.NoClip = EvetHayirEnum.ehEvet;
                    RANK1.ObjectDefName = "ResUser";
                    RANK1.DataMember = "RANK.NAME";
                    RANK1.Value = @"{@RECEIVERERID@}";

                    TITLE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 36, 180, 41, false);
                    TITLE1.Name = "TITLE1";
                    TITLE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TITLE1.CaseFormat = CaseFormatEnum.fcTitleCase;
                    TITLE1.NoClip = EvetHayirEnum.ehEvet;
                    TITLE1.ObjectDefName = "UserTitleEnum";
                    TITLE1.DataMember = "DISPLAYTEXT";
                    TITLE1.Value = @"{%RECEIVERTITLE%}";

                    DELIVERTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 53, 24, 78, 29, false);
                    DELIVERTITLE.Name = "DELIVERTITLE";
                    DELIVERTITLE.Visible = EvetHayirEnum.ehHayir;
                    DELIVERTITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DELIVERTITLE.HorzAlign = HorizontalAlignmentEnum.haleft;
                    DELIVERTITLE.VertAlign = VerticalAlignmentEnum.vaTop;
                    DELIVERTITLE.ObjectDefName = "ResUser";
                    DELIVERTITLE.DataMember = "TITLE";
                    DELIVERTITLE.TextFont.Name = "Arial Narrow";
                    DELIVERTITLE.TextFont.CharSet = 1;
                    DELIVERTITLE.Value = @"{@DELIVERERID@}";

                    RECEIVERTITLE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 29, 129, 34, false);
                    RECEIVERTITLE.Name = "RECEIVERTITLE";
                    RECEIVERTITLE.Visible = EvetHayirEnum.ehHayir;
                    RECEIVERTITLE.FieldType = ReportFieldTypeEnum.ftVariable;
                    RECEIVERTITLE.HorzAlign = HorizontalAlignmentEnum.haleft;
                    RECEIVERTITLE.VertAlign = VerticalAlignmentEnum.vaTop;
                    RECEIVERTITLE.ObjectDefName = "ResUser";
                    RECEIVERTITLE.DataMember = "TITLE";
                    RECEIVERTITLE.TextFont.Name = "Arial Narrow";
                    RECEIVERTITLE.TextFont.CharSet = 1;
                    RECEIVERTITLE.Value = @"{@RECEIVERERID@}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 0, 5, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 8, 5, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 36, 0, 36, 5, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine131 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 98, 0, 98, 5, false);
                    NewLine131.Name = "NewLine131";
                    NewLine131.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 113, 0, 113, 5, false);
                    NewLine141.Name = "NewLine141";
                    NewLine141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 134, 0, 134, 5, false);
                    NewLine151.Name = "NewLine151";
                    NewLine151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 149, 0, 149, 5, false);
                    NewLine161.Name = "NewLine161";
                    NewLine161.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine171 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 164, 0, 164, 5, false);
                    NewLine171.Name = "NewLine171";
                    NewLine171.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine181 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 178, 0, 178, 5, false);
                    NewLine181.Name = "NewLine181";
                    NewLine181.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine191 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 190, 0, 190, 5, false);
                    NewLine191.Name = "NewLine191";
                    NewLine191.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReferToUpperLevel.GetReferToUpperLevelByObjectIDQuery_Class dataset_GetReferToUpperLevelByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<ReferToUpperLevel.GetReferToUpperLevelByObjectIDQuery_Class>(0);
                    TOTAL.CalcValue = @"/_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/ YALNIZ (" + (ParentGroup.SubGroupCount - 1).ToString() + @") KALEMDİR. /_/_/_/_/_/_/_/_/_/_/_/_/_/_/_/";
                    TOTALITEMAMOUNT.CalcValue = @"Yukarıda adı, miktarı ve birimi yazılı olan (" + (ParentGroup.SubGroupCount - 1).ToString() + @") kalem malzeme ve ana malzeme faal/hek durumda ve tam olarak teslim alınmıştır.";
                    NewField3.CalcValue = NewField3.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NAME.CalcValue = MyParentReport.RuntimeParameters.DELIVERERID.ToString();
                    NAME.PostFieldValueCalculation();
                    RANK.CalcValue = MyParentReport.RuntimeParameters.DELIVERERID.ToString();
                    RANK.PostFieldValueCalculation();
                    DELIVERTITLE.CalcValue = MyParentReport.RuntimeParameters.DELIVERERID.ToString();
                    DELIVERTITLE.PostFieldValueCalculation();
                    TITLE.CalcValue = MyParentReport.PARTA.DELIVERTITLE.CalcValue;
                    TITLE.PostFieldValueCalculation();
                    NAME1.CalcValue = MyParentReport.RuntimeParameters.RECEIVERERID.ToString();
                    NAME1.PostFieldValueCalculation();
                    RANK1.CalcValue = MyParentReport.RuntimeParameters.RECEIVERERID.ToString();
                    RANK1.PostFieldValueCalculation();
                    RECEIVERTITLE.CalcValue = MyParentReport.RuntimeParameters.RECEIVERERID.ToString();
                    RECEIVERTITLE.PostFieldValueCalculation();
                    TITLE1.CalcValue = MyParentReport.PARTA.RECEIVERTITLE.CalcValue;
                    TITLE1.PostFieldValueCalculation();
                    return new TTReportObject[] { TOTAL,TOTALITEMAMOUNT,NewField3,NewField15,NAME,RANK,DELIVERTITLE,TITLE,NAME1,RANK1,RECEIVERTITLE,TITLE1};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public Tutanak_IkmalMudurlukTeslimi MyParentReport
            {
                get { return (Tutanak_IkmalMudurlukTeslimi)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField COUNT { get {return Body().COUNT;} }
            public TTReportField MISSING { get {return Body().MISSING;} }
            public TTReportField CHANGED { get {return Body().CHANGED;} }
            public TTReportField DAMAGED { get {return Body().DAMAGED;} }
            public TTReportField NORMAL { get {return Body().NORMAL;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Body().DISTRIBUTIONTYPE;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField ITEMEQUIPMENT { get {return Body().ITEMEQUIPMENT;} }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine15 { get {return Body().NewLine15;} }
            public TTReportShape NewLine16 { get {return Body().NewLine16;} }
            public TTReportShape NewLine17 { get {return Body().NewLine17;} }
            public TTReportShape NewLine18 { get {return Body().NewLine18;} }
            public TTReportShape NewLine19 { get {return Body().NewLine19;} }
            public TTReportField NORMAL1 { get {return Body().NORMAL1;} }
            public TTReportField DAMAGED1 { get {return Body().DAMAGED1;} }
            public TTReportField CHANGED1 { get {return Body().CHANGED1;} }
            public TTReportField MISSING1 { get {return Body().MISSING1;} }
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
                list[0] = new TTReportNqlData<ReferToUpperLevel.GetRULDetailsByObjectIDQuery_Class>("GetRULDetailsByObjectIDQuery", ReferToUpperLevel.GetRULDetailsByObjectIDQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public Tutanak_IkmalMudurlukTeslimi MyParentReport
                {
                    get { return (Tutanak_IkmalMudurlukTeslimi)ParentReport; }
                }
                
                public TTReportField COUNT;
                public TTReportField MISSING;
                public TTReportField CHANGED;
                public TTReportField DAMAGED;
                public TTReportField NORMAL;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportField AMOUNT;
                public TTReportField ITEMEQUIPMENT;
                public TTReportField NATOSTOCKNO;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16;
                public TTReportShape NewLine17;
                public TTReportShape NewLine18;
                public TTReportShape NewLine19;
                public TTReportField NORMAL1;
                public TTReportField DAMAGED1;
                public TTReportField CHANGED1;
                public TTReportField MISSING1; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    COUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 8, 5, false);
                    COUNT.Name = "COUNT";
                    COUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    COUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    COUNT.Value = @"{@counter@}";

                    MISSING = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 178, 0, 190, 5, false);
                    MISSING.Name = "MISSING";
                    MISSING.DrawStyle = DrawStyleConstants.vbSolid;
                    MISSING.FieldType = ReportFieldTypeEnum.ftVariable;
                    MISSING.Value = @"";

                    CHANGED = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 164, 0, 178, 5, false);
                    CHANGED.Name = "CHANGED";
                    CHANGED.DrawStyle = DrawStyleConstants.vbSolid;
                    CHANGED.FieldType = ReportFieldTypeEnum.ftVariable;
                    CHANGED.Value = @"";

                    DAMAGED = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 0, 164, 5, false);
                    DAMAGED.Name = "DAMAGED";
                    DAMAGED.DrawStyle = DrawStyleConstants.vbSolid;
                    DAMAGED.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAMAGED.Value = @"";

                    NORMAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 0, 149, 5, false);
                    NORMAL.Name = "NORMAL";
                    NORMAL.DrawStyle = DrawStyleConstants.vbSolid;
                    NORMAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    NORMAL.Value = @"";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 0, 134, 5, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 98, 0, 113, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    ITEMEQUIPMENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 0, 98, 5, false);
                    ITEMEQUIPMENT.Name = "ITEMEQUIPMENT";
                    ITEMEQUIPMENT.DrawStyle = DrawStyleConstants.vbSolid;
                    ITEMEQUIPMENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMEQUIPMENT.Value = @"{#ITEMNAME#}";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 0, 36, 5, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 0, 5, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 8, 0, 8, 5, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 36, 0, 36, 5, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 98, 0, 98, 5, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 113, 0, 113, 5, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 134, 0, 134, 5, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 149, 0, 149, 5, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 164, 0, 164, 5, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 178, 0, 178, 5, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine19 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 190, 0, 190, 5, false);
                    NewLine19.Name = "NewLine19";
                    NewLine19.DrawStyle = DrawStyleConstants.vbSolid;

                    NORMAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 1, 230, 6, false);
                    NORMAL1.Name = "NORMAL1";
                    NORMAL1.Visible = EvetHayirEnum.ehHayir;
                    NORMAL1.DrawStyle = DrawStyleConstants.vbSolid;
                    NORMAL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    NORMAL1.Value = @"{#ISNORMAL#}";

                    DAMAGED1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 231, 1, 246, 6, false);
                    DAMAGED1.Name = "DAMAGED1";
                    DAMAGED1.Visible = EvetHayirEnum.ehHayir;
                    DAMAGED1.DrawStyle = DrawStyleConstants.vbSolid;
                    DAMAGED1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DAMAGED1.Value = @"{#ISDAMAGED#}";

                    CHANGED1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 1, 261, 6, false);
                    CHANGED1.Name = "CHANGED1";
                    CHANGED1.Visible = EvetHayirEnum.ehHayir;
                    CHANGED1.DrawStyle = DrawStyleConstants.vbSolid;
                    CHANGED1.FieldType = ReportFieldTypeEnum.ftVariable;
                    CHANGED1.Value = @"{#ISCHANGED#}";

                    MISSING1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 1, 275, 6, false);
                    MISSING1.Name = "MISSING1";
                    MISSING1.Visible = EvetHayirEnum.ehHayir;
                    MISSING1.DrawStyle = DrawStyleConstants.vbSolid;
                    MISSING1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MISSING1.Value = @"{#ISMISSING#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReferToUpperLevel.GetRULDetailsByObjectIDQuery_Class dataset_GetRULDetailsByObjectIDQuery = ParentGroup.rsGroup.GetCurrentRecord<ReferToUpperLevel.GetRULDetailsByObjectIDQuery_Class>(0);
                    COUNT.CalcValue = ParentGroup.Counter.ToString();
                    MISSING.CalcValue = @"";
                    CHANGED.CalcValue = @"";
                    DAMAGED.CalcValue = @"";
                    NORMAL.CalcValue = @"";
                    DISTRIBUTIONTYPE.CalcValue = (dataset_GetRULDetailsByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetRULDetailsByObjectIDQuery.DistributionType) : "");
                    AMOUNT.CalcValue = (dataset_GetRULDetailsByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetRULDetailsByObjectIDQuery.Amount) : "");
                    ITEMEQUIPMENT.CalcValue = (dataset_GetRULDetailsByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetRULDetailsByObjectIDQuery.ItemName) : "");
                    NATOSTOCKNO.CalcValue = @"";
                    NORMAL1.CalcValue = (dataset_GetRULDetailsByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetRULDetailsByObjectIDQuery.IsNormal) : "");
                    DAMAGED1.CalcValue = (dataset_GetRULDetailsByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetRULDetailsByObjectIDQuery.IsDamaged) : "");
                    CHANGED1.CalcValue = (dataset_GetRULDetailsByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetRULDetailsByObjectIDQuery.IsChanged) : "");
                    MISSING1.CalcValue = (dataset_GetRULDetailsByObjectIDQuery != null ? Globals.ToStringCore(dataset_GetRULDetailsByObjectIDQuery.IsMissing) : "");
                    return new TTReportObject[] { COUNT,MISSING,CHANGED,DAMAGED,NORMAL,DISTRIBUTIONTYPE,AMOUNT,ITEMEQUIPMENT,NATOSTOCKNO,NORMAL1,DAMAGED1,CHANGED1,MISSING1};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    if (MISSING1.CalcValue == "True")
            {
                MISSING.CalcValue = "X";
            }
            if (CHANGED1.CalcValue == "True")
            {
                CHANGED.CalcValue = "X";
            }
            if (DAMAGED1.CalcValue == "True")
            {
                DAMAGED.CalcValue = "X";
            }
            if (NORMAL1.CalcValue == "True")
            {
                NORMAL.CalcValue = "X";
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

        public Tutanak_IkmalMudurlukTeslimi()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("DELIVERERID", "", "Teslim Eden", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
            reportParameter = Parameters.Add("RECEIVERERID", "", "Teslim Alan", @"", false, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("f8fdd898-ea3c-45a4-abcd-d6362e52064c");
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("DELIVERERID"))
                _runtimeParameters.DELIVERERID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["DELIVERERID"]);
            if (parameters.ContainsKey("RECEIVERERID"))
                _runtimeParameters.RECEIVERERID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["RECEIVERERID"]);
            Name = "TUTANAK_IKMALMUDURLUKTESLIMI";
            Caption = "Tutanaktır(İkmal Müdürlük Birimine Teslim)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            PaperSize = 11;
            UserMarginLeft = 10;
            UserMarginTop = 10;
            p_PageWidth = 148;
            p_PageHeight = 210;
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
            fd.HorzAlign = HorizontalAlignmentEnum.haCenter;
            fd.VertAlign = VerticalAlignmentEnum.vaMiddle;
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