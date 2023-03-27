
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
    /// Yarım Doz İlaç İmha Formu
    /// </summary>
    public partial class HalfDoseReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public HalfDoseReport MyParentReport
            {
                get { return (HalfDoseReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField111123 { get {return Header().NewField111123;} }
            public TTReportField NewField1321113 { get {return Header().NewField1321113;} }
            public TTReportField NewField1321114 { get {return Header().NewField1321114;} }
            public TTReportField NewField1321116 { get {return Header().NewField1321116;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField NewField16111231 { get {return Header().NewField16111231;} }
            public TTReportField NewField113211161 { get {return Header().NewField113211161;} }
            public TTReportField NewField113211162 { get {return Header().NewField113211162;} }
            public TTReportField NewField113211163 { get {return Header().NewField113211163;} }
            public TTReportField HospitalInfo { get {return Header().HospitalInfo;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField PERSON { get {return Header().PERSON;} }
            public TTReportShape NewLine2 { get {return Header().NewLine2;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
            public TTReportShape NewLine14 { get {return Header().NewLine14;} }
            public TTReportField REV { get {return Footer().REV;} }
            public TTReportField NewField1121 { get {return Footer().NewField1121;} }
            public TTReportField NewField1131 { get {return Footer().NewField1131;} }
            public TTReportField NewField1141 { get {return Footer().NewField1141;} }
            public TTReportField NewField11411 { get {return Footer().NewField11411;} }
            public TTReportField NewField11412 { get {return Footer().NewField11412;} }
            public TTReportField NewField3 { get {return Footer().NewField3;} }
            public TTReportShape NewLine1 { get {return Footer().NewLine1;} }
            public TTReportShape NewLine11 { get {return Footer().NewLine11;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public HalfDoseReport MyParentReport
                {
                    get { return (HalfDoseReport)ParentReport; }
                }
                
                public TTReportField NewField111123;
                public TTReportField NewField1321113;
                public TTReportField NewField1321114;
                public TTReportField NewField1321116;
                public TTReportField STARTDATE;
                public TTReportField LOGO;
                public TTReportField NewField1;
                public TTReportField ENDDATE;
                public TTReportField NewField2;
                public TTReportField NewField16111231;
                public TTReportField NewField113211161;
                public TTReportField NewField113211162;
                public TTReportField NewField113211163;
                public TTReportField HospitalInfo;
                public TTReportField NewField4;
                public TTReportField PERSON;
                public TTReportShape NewLine2;
                public TTReportShape NewLine3;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 110;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 59, 61, 80, false);
                    NewField111123.Name = "NewField111123";
                    NewField111123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111123.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111123.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111123.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111123.TextFont.Size = 10;
                    NewField111123.TextFont.Bold = true;
                    NewField111123.Value = @"T.C.
SAĞLIK BAKANLIĞI
XXXXXX İL SAĞLIK MÜDÜRLÜĞÜ
GAZİLER FTR XXXXXXSİ";

                    NewField1321113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 59, 200, 80, false);
                    NewField1321113.Name = "NewField1321113";
                    NewField1321113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1321113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1321113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1321113.TextFont.Size = 10;
                    NewField1321113.TextFont.Bold = true;
                    NewField1321113.Value = @"
( Sağlık Tesisi içinde Servis Hemşiresi, Servis Sorumlu Hemşiresi ve Hekim tarafından doldurularak her hafta Eczaneye teslim edilmelidir.)";

                    NewField1321114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 80, 200, 90, false);
                    NewField1321114.Name = "NewField1321114";
                    NewField1321114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321114.TextFont.Size = 10;
                    NewField1321114.TextFont.Bold = true;
                    NewField1321114.Value = @"Tarih:";

                    NewField1321116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 90, 61, 110, false);
                    NewField1321116.Name = "NewField1321116";
                    NewField1321116.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321116.TextFont.Size = 10;
                    NewField1321116.TextFont.Bold = true;
                    NewField1321116.Value = @"İlacın Adı";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 83, 52, 88, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STARTDATE.ObjectDefName = "HalfDoseDestruction";
                    STARTDATE.DataMember = "STARTDATE";
                    STARTDATE.TextFont.Size = 10;
                    STARTDATE.Value = @"{@TTOBJECTID@}  ";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 17, 50, 43, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.TextFont.Size = 10;
                    LOGO.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 53, 200, 58, false);
                    NewField1.Name = "NewField1";
                    NewField1.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField1.TextFont.Size = 8;
                    NewField1.Value = @"EK 1: YARIM DOZ İLAÇ BİLDİRİM FORMU (Sağlık Tesis Formatı)";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 83, 96, 88, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ENDDATE.ObjectDefName = "HalfDoseDestruction";
                    ENDDATE.DataMember = "ENDDATE";
                    ENDDATE.TextFont.Size = 10;
                    ENDDATE.Value = @"{@TTOBJECTID@}  ";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 83, 61, 88, false);
                    NewField2.Name = "NewField2";
                    NewField2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField2.TextFont.Size = 10;
                    NewField2.Value = @" - ";

                    NewField16111231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 90, 97, 110, false);
                    NewField16111231.Name = "NewField16111231";
                    NewField16111231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16111231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16111231.MultiLine = EvetHayirEnum.ehEvet;
                    NewField16111231.WordBreak = EvetHayirEnum.ehEvet;
                    NewField16111231.TextFont.Size = 10;
                    NewField16111231.TextFont.Bold = true;
                    NewField16111231.Value = @"
İlaç Formu ( Ampul, Flakon )";

                    NewField113211161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 90, 124, 110, false);
                    NewField113211161.Name = "NewField113211161";
                    NewField113211161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113211161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113211161.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113211161.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113211161.TextFont.Size = 10;
                    NewField113211161.TextFont.Bold = true;
                    NewField113211161.Value = @"
İhma Edilen Doz  (Yanlızca rakam ile yazılacaktır) ";

                    NewField113211162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 90, 151, 110, false);
                    NewField113211162.Name = "NewField113211162";
                    NewField113211162.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113211162.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113211162.MultiLine = EvetHayirEnum.ehEvet;
                    NewField113211162.WordBreak = EvetHayirEnum.ehEvet;
                    NewField113211162.TextFont.Size = 10;
                    NewField113211162.TextFont.Bold = true;
                    NewField113211162.Value = @"
Doz Birimi (Yanlızca MG,ML,UI yazılır)";

                    NewField113211163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 90, 200, 110, false);
                    NewField113211163.Name = "NewField113211163";
                    NewField113211163.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField113211163.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField113211163.TextFont.Size = 10;
                    NewField113211163.TextFont.Bold = true;
                    NewField113211163.Value = @"İmha Edilen Birim";

                    HospitalInfo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 15, 200, 44, false);
                    HospitalInfo.Name = "HospitalInfo";
                    HospitalInfo.FieldType = ReportFieldTypeEnum.ftExpression;
                    HospitalInfo.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HospitalInfo.MultiLine = EvetHayirEnum.ehEvet;
                    HospitalInfo.NoClip = EvetHayirEnum.ehEvet;
                    HospitalInfo.WordBreak = EvetHayirEnum.ehEvet;
                    HospitalInfo.TextFont.Bold = true;
                    HospitalInfo.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """")";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 44, 200, 52, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField4.TextFont.Size = 10;
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @"SAĞLIK TESİSİ YARIM DOZ İMHA FORMU";

                    PERSON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 83, 197, 88, false);
                    PERSON.Name = "PERSON";
                    PERSON.FieldType = ReportFieldTypeEnum.ftVariable;
                    PERSON.TextFormat = @"dd/MM/yyyy";
                    PERSON.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    PERSON.ObjectDefName = "HalfDoseDestruction";
                    PERSON.DataMember = "PROCEDUREBYUSER.NAME";
                    PERSON.TextFont.Size = 10;
                    PERSON.Value = @"{@TTOBJECTID@}  ";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 15, 200, 15, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 15, 10, 44, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 61, 15, 61, 44, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 15, 200, 44, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111123.CalcValue = NewField111123.Value;
                    NewField1321113.CalcValue = NewField1321113.Value;
                    NewField1321114.CalcValue = NewField1321114.Value;
                    NewField1321116.CalcValue = NewField1321116.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString() + @"  ";
                    STARTDATE.PostFieldValueCalculation();
                    LOGO.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString() + @"  ";
                    ENDDATE.PostFieldValueCalculation();
                    NewField2.CalcValue = NewField2.Value;
                    NewField16111231.CalcValue = NewField16111231.Value;
                    NewField113211161.CalcValue = NewField113211161.Value;
                    NewField113211162.CalcValue = NewField113211162.Value;
                    NewField113211163.CalcValue = NewField113211163.Value;
                    NewField4.CalcValue = NewField4.Value;
                    PERSON.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString() + @"  ";
                    PERSON.PostFieldValueCalculation();
                    HospitalInfo.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "");
                    return new TTReportObject[] { NewField111123,NewField1321113,NewField1321114,NewField1321116,STARTDATE,LOGO,NewField1,ENDDATE,NewField2,NewField16111231,NewField113211161,NewField113211162,NewField113211163,NewField4,PERSON,HospitalInfo};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    /*if (MyParentReport.RuntimeParameters.TTOBJECTID.HasValue)
            {

            }*/
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public HalfDoseReport MyParentReport
                {
                    get { return (HalfDoseReport)ParentReport; }
                }
                
                public TTReportField REV;
                public TTReportField NewField1121;
                public TTReportField NewField1131;
                public TTReportField NewField1141;
                public TTReportField NewField11411;
                public TTReportField NewField11412;
                public TTReportField NewField3;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 106;
                    RepeatCount = 0;
                    
                    REV = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 88, 200, 94, false);
                    REV.Name = "REV";
                    REV.DrawStyle = DrawStyleConstants.vbSolid;
                    REV.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REV.TextFont.Size = 8;
                    REV.Value = @"DÖKÜMAN KODU: İY.FR.514 YAYIN TARİHİ: 01.08.2018 REVİZYON NO: REVİZYON TARİHİ: SAYFA NO:01  ";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 7, 53, 12, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.TextFont.Size = 10;
                    NewField1121.TextFont.CharSet = 1;
                    NewField1121.Value = @"Servis Sorumlu Hemşiresi";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 87, 6, 122, 11, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.TextFont.Size = 10;
                    NewField1131.TextFont.CharSet = 1;
                    NewField1131.Value = @"Sorumlu Hekim";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 6, 196, 11, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141.TextFont.Size = 10;
                    NewField1141.TextFont.CharSet = 1;
                    NewField1141.Value = @"Sağlık Bakım Hizmetleri Müdürü";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 41, 126, 46, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11411.TextFont.Size = 10;
                    NewField11411.TextFont.CharSet = 1;
                    NewField11411.Value = @"Evrakın Teslim Alındığına Dair";

                    NewField11412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 66, 127, 71, false);
                    NewField11412.Name = "NewField11412";
                    NewField11412.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11412.TextFont.Size = 10;
                    NewField11412.TextFont.CharSet = 1;
                    NewField11412.Value = @"Eczacı";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 72, 200, 88, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField3.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField3.MultiLine = EvetHayirEnum.ehEvet;
                    NewField3.WordBreak = EvetHayirEnum.ehEvet;
                    NewField3.TextFont.Size = 10;
                    NewField3.Value = @"Not : İlaç adı kısmına ilacın adı ve doz miktarı ile birlikte yazılması (DIKLORON 75mg/3ml IM AMPUL gibi),  ilaç formu kısmına ampul flakon gibi isimlerinin kısaltmasız büyük harflerle yazılması, imha edilen doz sütününda mg/ml/UI hesabına göre rakamlarla doldurulması ve doz birimi sütununa da MG/ML/UI birimlerinden hangisi baz alındı ise ilgili alana doldurulması gerekmektedir ";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 10, 0, 10, 76, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 0, 200, 76, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    REV.CalcValue = REV.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField11412.CalcValue = NewField11412.Value;
                    NewField3.CalcValue = NewField3.Value;
                    return new TTReportObject[] { REV,NewField1121,NewField1131,NewField1141,NewField11411,NewField11412,NewField3};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public HalfDoseReport MyParentReport
            {
                get { return (HalfDoseReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField DRUGNAME { get {return Body().DRUGNAME;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportField UNIT { get {return Body().UNIT;} }
            public TTReportField MASTERRESOURCE { get {return Body().MASTERRESOURCE;} }
            public TTReportField NFCTYPE { get {return Body().NFCTYPE;} }
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
                list[0] = new TTReportNqlData<HalfDoseDestruction.HalfDoseReportQuery_Class>("HalfDoseReportQuery", HalfDoseDestruction.HalfDoseReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public HalfDoseReport MyParentReport
                {
                    get { return (HalfDoseReport)ParentReport; }
                }
                
                public TTReportField DRUGNAME;
                public TTReportField AMOUNT;
                public TTReportField UNIT;
                public TTReportField MASTERRESOURCE;
                public TTReportField NFCTYPE; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    DRUGNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 0, 61, 5, false);
                    DRUGNAME.Name = "DRUGNAME";
                    DRUGNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    DRUGNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    DRUGNAME.VertAlign = VerticalAlignmentEnum.vaTop;
                    DRUGNAME.TextFont.Size = 10;
                    DRUGNAME.Value = @"{#DRUGNAME#}";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 97, 0, 124, 5, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.VertAlign = VerticalAlignmentEnum.vaTop;
                    AMOUNT.TextFont.Size = 10;
                    AMOUNT.Value = @"{#AMOUNT#}";

                    UNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 0, 151, 5, false);
                    UNIT.Name = "UNIT";
                    UNIT.DrawStyle = DrawStyleConstants.vbSolid;
                    UNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNIT.VertAlign = VerticalAlignmentEnum.vaTop;
                    UNIT.TextFont.Size = 10;
                    UNIT.Value = @"{#UNIT#}";

                    MASTERRESOURCE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 0, 200, 5, false);
                    MASTERRESOURCE.Name = "MASTERRESOURCE";
                    MASTERRESOURCE.DrawStyle = DrawStyleConstants.vbSolid;
                    MASTERRESOURCE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MASTERRESOURCE.VertAlign = VerticalAlignmentEnum.vaTop;
                    MASTERRESOURCE.TextFont.Size = 10;
                    MASTERRESOURCE.Value = @"{#MASTERRESOURCE#}";

                    NFCTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 0, 97, 5, false);
                    NFCTYPE.Name = "NFCTYPE";
                    NFCTYPE.DrawStyle = DrawStyleConstants.vbSolid;
                    NFCTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    NFCTYPE.VertAlign = VerticalAlignmentEnum.vaTop;
                    NFCTYPE.TextFont.Size = 10;
                    NFCTYPE.Value = @"{#NFCTYPE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HalfDoseDestruction.HalfDoseReportQuery_Class dataset_HalfDoseReportQuery = ParentGroup.rsGroup.GetCurrentRecord<HalfDoseDestruction.HalfDoseReportQuery_Class>(0);
                    DRUGNAME.CalcValue = (dataset_HalfDoseReportQuery != null ? Globals.ToStringCore(dataset_HalfDoseReportQuery.DrugName) : "");
                    AMOUNT.CalcValue = (dataset_HalfDoseReportQuery != null ? Globals.ToStringCore(dataset_HalfDoseReportQuery.Amount) : "");
                    UNIT.CalcValue = (dataset_HalfDoseReportQuery != null ? Globals.ToStringCore(dataset_HalfDoseReportQuery.Unit) : "");
                    MASTERRESOURCE.CalcValue = (dataset_HalfDoseReportQuery != null ? Globals.ToStringCore(dataset_HalfDoseReportQuery.Masterresource) : "");
                    NFCTYPE.CalcValue = (dataset_HalfDoseReportQuery != null ? Globals.ToStringCore(dataset_HalfDoseReportQuery.NFCType) : "");
                    return new TTReportObject[] { DRUGNAME,AMOUNT,UNIT,MASTERRESOURCE,NFCTYPE};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HalfDoseReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "İşlem Numarasını Giriniz", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HALFDOSEREPORT";
            Caption = "Yarım Doz İlaç İmha Formu";
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
            fd.TextFont.Name = "Arial Narrow";
            fd.TextFont.Size = 11;
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