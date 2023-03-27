
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
    /// Mernis Ölüm Tutanağı
    /// </summary>
    public partial class MernisDeathReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class TarafGroup : TTReportGroup
        {
            public MernisDeathReport MyParentReport
            {
                get { return (MernisDeathReport)ParentReport; }
            }

            new public TarafGroupHeader Header()
            {
                return (TarafGroupHeader)_header;
            }

            new public TarafGroupFooter Footer()
            {
                return (TarafGroupFooter)_footer;
            }

            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField2 { get {return Header().NewField2;} }
            public TTReportField TCKIMLIKNO { get {return Header().TCKIMLIKNO;} }
            public TTReportField PATIENT { get {return Header().PATIENT;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField NewField15 { get {return Header().NewField15;} }
            public TTReportField İLÇESİ { get {return Header().İLÇESİ;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField KOYMAHHALE { get {return Header().KOYMAHHALE;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField NewField152 { get {return Header().NewField152;} }
            public TTReportField CILTNO { get {return Header().CILTNO;} }
            public TTReportField NewField1132 { get {return Header().NewField1132;} }
            public TTReportField NewField153 { get {return Header().NewField153;} }
            public TTReportField ADI { get {return Header().ADI;} }
            public TTReportField NewField1133 { get {return Header().NewField1133;} }
            public TTReportField NewField154 { get {return Header().NewField154;} }
            public TTReportField SOYADI { get {return Header().SOYADI;} }
            public TTReportField NewField1134 { get {return Header().NewField1134;} }
            public TTReportField NewField155 { get {return Header().NewField155;} }
            public TTReportField BABAADI { get {return Header().BABAADI;} }
            public TTReportField NewField1135 { get {return Header().NewField1135;} }
            public TTReportField NewField156 { get {return Header().NewField156;} }
            public TTReportField ANAADI { get {return Header().ANAADI;} }
            public TTReportField NewField1136 { get {return Header().NewField1136;} }
            public TTReportField NewField1137 { get {return Header().NewField1137;} }
            public TTReportField NewField1138 { get {return Header().NewField1138;} }
            public TTReportField NewField132 { get {return Header().NewField132;} }
            public TTReportField CINSIYET1 { get {return Header().CINSIYET1;} }
            public TTReportField NewField1139 { get {return Header().NewField1139;} }
            public TTReportField NewField11311 { get {return Header().NewField11311;} }
            public TTReportField NewField12311 { get {return Header().NewField12311;} }
            public TTReportField İLÇESİ13 { get {return Header().İLÇESİ13;} }
            public TTReportField NewField13311 { get {return Header().NewField13311;} }
            public TTReportField NewField14311 { get {return Header().NewField14311;} }
            public TTReportField İLÇESİ15 { get {return Header().İLÇESİ15;} }
            public TTReportField NewField15311 { get {return Header().NewField15311;} }
            public TTReportField NewField1651 { get {return Header().NewField1651;} }
            public TTReportField NewField16311 { get {return Header().NewField16311;} }
            public TTReportField NewField17311 { get {return Header().NewField17311;} }
            public TTReportField NewField19311 { get {return Header().NewField19311;} }
            public TTReportField NewField1252 { get {return Header().NewField1252;} }
            public TTReportField AILE_NO { get {return Header().AILE_NO;} }
            public TTReportField NewField12312 { get {return Header().NewField12312;} }
            public TTReportField NewField1253 { get {return Header().NewField1253;} }
            public TTReportField SIRANO { get {return Header().SIRANO;} }
            public TTReportField NewField12313 { get {return Header().NewField12313;} }
            public TTReportField NewField111391 { get {return Header().NewField111391;} }
            public TTReportField NewField11541 { get {return Header().NewField11541;} }
            public TTReportField İLÇESİ141 { get {return Header().İLÇESİ141;} }
            public TTReportField NewField111341 { get {return Header().NewField111341;} }
            public TTReportField İLÇESİ1141 { get {return Header().İLÇESİ1141;} }
            public TTReportField NewField1143111 { get {return Header().NewField1143111;} }
            public TTReportField İLÇESİ151 { get {return Header().İLÇESİ151;} }
            public TTReportField NewField111351 { get {return Header().NewField111351;} }
            public TTReportField NewField1153111 { get {return Header().NewField1153111;} }
            public TTReportField NewField18311 { get {return Header().NewField18311;} }
            public TTReportField TCKIMLIKNO11 { get {return Header().TCKIMLIKNO11;} }
            public TTReportField NewField1231 { get {return Header().NewField1231;} }
            public TTReportField NewField19312 { get {return Header().NewField19312;} }
            public TTReportField NewField111392 { get {return Header().NewField111392;} }
            public TTReportField CINSIYET111 { get {return Header().CINSIYET111;} }
            public TTReportField NewField1293111 { get {return Header().NewField1293111;} }
            public TTReportField NewField111311 { get {return Header().NewField111311;} }
            public TTReportField NewField111321 { get {return Header().NewField111321;} }
            public TTReportField İLÇESİ131 { get {return Header().İLÇESİ131;} }
            public TTReportField NewField111331 { get {return Header().NewField111331;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField17 { get {return Header().NewField17;} }
            public TTReportField NewField171 { get {return Header().NewField171;} }
            public TTReportField NewField172 { get {return Header().NewField172;} }
            public TTReportField NewField173 { get {return Header().NewField173;} }
            public TTReportField NewField1271 { get {return Header().NewField1271;} }
            public TTReportField NewField11721 { get {return Header().NewField11721;} }
            public TTReportField NewField18 { get {return Header().NewField18;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField NewField1181 { get {return Header().NewField1181;} }
            public TTReportField NewField11811 { get {return Header().NewField11811;} }
            public TTReportField NewField11813 { get {return Header().NewField11813;} }
            public TTReportField NewField131811 { get {return Header().NewField131811;} }
            public TTReportField NewField131812 { get {return Header().NewField131812;} }
            public TTReportField NewField1218131 { get {return Header().NewField1218131;} }
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine3 { get {return Header().NewLine3;} }
            public TTReportField NewField142 { get {return Header().NewField142;} }
            public TTReportField NewField1193111 { get {return Header().NewField1193111;} }
            public TTReportField NewField182 { get {return Footer().NewField182;} }
            public TTReportField NewField1182 { get {return Footer().NewField1182;} }
            public TTReportField NewField1281 { get {return Footer().NewField1281;} }
            public TTReportField NewField11821 { get {return Footer().NewField11821;} }
            public TTReportField NewField11822 { get {return Footer().NewField11822;} }
            public TTReportField NewField122811 { get {return Footer().NewField122811;} }
            public TTReportField NewField1282 { get {return Footer().NewField1282;} }
            public TTReportField NewField12811 { get {return Footer().NewField12811;} }
            public TTReportField NewField112811 { get {return Footer().NewField112811;} }
            public TTReportField NewField12821 { get {return Footer().NewField12821;} }
            public TTReportField NewField12822 { get {return Footer().NewField12822;} }
            public TTReportField NewField111821 { get {return Footer().NewField111821;} }
            public TTReportField NewField112821 { get {return Footer().NewField112821;} }
            public TTReportField NewField112822 { get {return Footer().NewField112822;} }
            public TarafGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TarafGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new TarafGroupHeader(this);
                _footer = new TarafGroupFooter(this);

            }

            public partial class TarafGroupHeader : TTReportSection
            {
                public MernisDeathReport MyParentReport
                {
                    get { return (MernisDeathReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField2;
                public TTReportField TCKIMLIKNO;
                public TTReportField PATIENT;
                public TTReportField NewField13;
                public TTReportField NewField14;
                public TTReportField NewField15;
                public TTReportField İLÇESİ;
                public TTReportField NewField131;
                public TTReportField NewField151;
                public TTReportField KOYMAHHALE;
                public TTReportField NewField1131;
                public TTReportField NewField152;
                public TTReportField CILTNO;
                public TTReportField NewField1132;
                public TTReportField NewField153;
                public TTReportField ADI;
                public TTReportField NewField1133;
                public TTReportField NewField154;
                public TTReportField SOYADI;
                public TTReportField NewField1134;
                public TTReportField NewField155;
                public TTReportField BABAADI;
                public TTReportField NewField1135;
                public TTReportField NewField156;
                public TTReportField ANAADI;
                public TTReportField NewField1136;
                public TTReportField NewField1137;
                public TTReportField NewField1138;
                public TTReportField NewField132;
                public TTReportField CINSIYET1;
                public TTReportField NewField1139;
                public TTReportField NewField11311;
                public TTReportField NewField12311;
                public TTReportField İLÇESİ13;
                public TTReportField NewField13311;
                public TTReportField NewField14311;
                public TTReportField İLÇESİ15;
                public TTReportField NewField15311;
                public TTReportField NewField1651;
                public TTReportField NewField16311;
                public TTReportField NewField17311;
                public TTReportField NewField19311;
                public TTReportField NewField1252;
                public TTReportField AILE_NO;
                public TTReportField NewField12312;
                public TTReportField NewField1253;
                public TTReportField SIRANO;
                public TTReportField NewField12313;
                public TTReportField NewField111391;
                public TTReportField NewField11541;
                public TTReportField İLÇESİ141;
                public TTReportField NewField111341;
                public TTReportField İLÇESİ1141;
                public TTReportField NewField1143111;
                public TTReportField İLÇESİ151;
                public TTReportField NewField111351;
                public TTReportField NewField1153111;
                public TTReportField NewField18311;
                public TTReportField TCKIMLIKNO11;
                public TTReportField NewField1231;
                public TTReportField NewField19312;
                public TTReportField NewField111392;
                public TTReportField CINSIYET111;
                public TTReportField NewField1293111;
                public TTReportField NewField111311;
                public TTReportField NewField111321;
                public TTReportField İLÇESİ131;
                public TTReportField NewField111331;
                public TTReportField NewField3;
                public TTReportField NewField17;
                public TTReportField NewField171;
                public TTReportField NewField172;
                public TTReportField NewField173;
                public TTReportField NewField1271;
                public TTReportField NewField11721;
                public TTReportField NewField18;
                public TTReportField NewField181;
                public TTReportField NewField1181;
                public TTReportField NewField11811;
                public TTReportField NewField11813;
                public TTReportField NewField131811;
                public TTReportField NewField131812;
                public TTReportField NewField1218131;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine3;
                public TTReportField NewField142;
                public TTReportField NewField1193111; 
                public TarafGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 297;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 6, 77, 23, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.NoClip = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1.Value = @"T.C
İÇİŞLERİ BAKANLIĞI
Nüf.ve Vat.İşl.Gn.Müd.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 6, 133, 23, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11.NoClip = EvetHayirEnum.ehEvet;
                    NewField11.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11.Value = @"
MERNİS
ÖLÜM TUTANAĞI";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 6, 201, 15, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.NoClip = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12.Value = @"VGF-70";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 15, 201, 23, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.NoClip = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121.Value = @"Sıra No:";

                    NewField2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 24, 77, 29, false);
                    NewField2.Name = "NewField2";
                    NewField2.Value = @"Ölenin Kimlik No:";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 29, 77, 34, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.ObjectDefName = "Person";
                    TCKIMLIKNO.DataMember = "UNIQUEREFNO";
                    TCKIMLIKNO.Value = @"{%PATIENT%}";

                    PATIENT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 7, 243, 12, false);
                    PATIENT.Name = "PATIENT";
                    PATIENT.Visible = EvetHayirEnum.ehHayir;
                    PATIENT.FieldType = ReportFieldTypeEnum.ftVariable;
                    PATIENT.Value = @"";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 29, 16, 34, false);
                    NewField13.Name = "NewField13";
                    NewField13.Value = @"1.";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 24, 133, 29, false);
                    NewField14.Name = "NewField14";
                    NewField14.Value = @"Cinsiyeti";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 34, 133, 39, false);
                    NewField15.Name = "NewField15";
                    NewField15.Value = @"İlçe Adı";

                    İLÇESİ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 39, 133, 44, false);
                    İLÇESİ.Name = "İLÇESİ";
                    İLÇESİ.FieldType = ReportFieldTypeEnum.ftVariable;
                    İLÇESİ.ObjectDefName = "Person";
                    İLÇESİ.DataMember = "TOWNOFREGISTRY.NAME";
                    İLÇESİ.Value = @"{%PATIENT%}";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 39, 16, 44, false);
                    NewField131.Name = "NewField131";
                    NewField131.Value = @"3.";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 44, 133, 49, false);
                    NewField151.Name = "NewField151";
                    NewField151.Value = @"Köy/Mahalle Adı";

                    KOYMAHHALE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 49, 133, 54, false);
                    KOYMAHHALE.Name = "KOYMAHHALE";
                    KOYMAHHALE.FieldType = ReportFieldTypeEnum.ftVariable;
                    KOYMAHHALE.ObjectDefName = "Person";
                    KOYMAHHALE.DataMember = "VILLAGEOFREGISTRY";
                    KOYMAHHALE.Value = @"{%PATIENT%}";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 49, 16, 54, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.Value = @"4.";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 54, 48, 59, false);
                    NewField152.Name = "NewField152";
                    NewField152.Value = @"Cilt No";

                    CILTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 59, 48, 64, false);
                    CILTNO.Name = "CILTNO";
                    CILTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CILTNO.ObjectDefName = "Person";
                    CILTNO.DataMember = "IDENTIFICATIONVOLUMENO";
                    CILTNO.Value = @"{%PATIENT%}";

                    NewField1132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 59, 16, 64, false);
                    NewField1132.Name = "NewField1132";
                    NewField1132.Value = @"5.";

                    NewField153 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 64, 133, 69, false);
                    NewField153.Name = "NewField153";
                    NewField153.Value = @"Adı";

                    ADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 69, 133, 74, false);
                    ADI.Name = "ADI";
                    ADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADI.ObjectDefName = "Person";
                    ADI.DataMember = "NAME";
                    ADI.Value = @"{%PATIENT%}";

                    NewField1133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 69, 16, 74, false);
                    NewField1133.Name = "NewField1133";
                    NewField1133.Value = @"8.";

                    NewField154 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 74, 133, 79, false);
                    NewField154.Name = "NewField154";
                    NewField154.Value = @"Soyadı";

                    SOYADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 79, 133, 84, false);
                    SOYADI.Name = "SOYADI";
                    SOYADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOYADI.ObjectDefName = "Person";
                    SOYADI.DataMember = "SURNAME";
                    SOYADI.Value = @"{%PATIENT%}";

                    NewField1134 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 79, 16, 84, false);
                    NewField1134.Name = "NewField1134";
                    NewField1134.Value = @"9.";

                    NewField155 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 84, 133, 89, false);
                    NewField155.Name = "NewField155";
                    NewField155.Value = @"Baba Adı";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 89, 133, 94, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.ObjectDefName = "Person";
                    BABAADI.DataMember = "FATHERNAME";
                    BABAADI.Value = @"{%PATIENT%}";

                    NewField1135 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 89, 16, 94, false);
                    NewField1135.Name = "NewField1135";
                    NewField1135.Value = @"10.";

                    NewField156 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 94, 133, 99, false);
                    NewField156.Name = "NewField156";
                    NewField156.Value = @"Ana Adı";

                    ANAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 99, 133, 104, false);
                    ANAADI.Name = "ANAADI";
                    ANAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    ANAADI.ObjectDefName = "Person";
                    ANAADI.DataMember = "MOTHERNAME";
                    ANAADI.Value = @"{%PATIENT%}";

                    NewField1136 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 99, 16, 104, false);
                    NewField1136.Name = "NewField1136";
                    NewField1136.Value = @"11.";

                    NewField1137 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 109, 16, 114, false);
                    NewField1137.Name = "NewField1137";
                    NewField1137.Value = @"12.";

                    NewField1138 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 119, 16, 124, false);
                    NewField1138.Name = "NewField1138";
                    NewField1138.Value = @"13.";

                    NewField132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 129, 16, 134, false);
                    NewField132.Name = "NewField132";
                    NewField132.Value = @"14.";

                    CINSIYET1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 83, 129, 133, 134, false);
                    CINSIYET1.Name = "CINSIYET1";
                    CINSIYET1.ObjectDefName = "PAtient";
                    CINSIYET1.Value = @"";

                    NewField1139 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 139, 16, 144, false);
                    NewField1139.Name = "NewField1139";
                    NewField1139.Value = @"16.";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 149, 16, 154, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.Value = @"18.";

                    NewField12311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 159, 16, 164, false);
                    NewField12311.Name = "NewField12311";
                    NewField12311.Value = @"19.";

                    İLÇESİ13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 169, 133, 174, false);
                    İLÇESİ13.Name = "İLÇESİ13";
                    İLÇESİ13.ObjectDefName = "PAtient";
                    İLÇESİ13.Value = @"";

                    NewField13311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 169, 16, 174, false);
                    NewField13311.Name = "NewField13311";
                    NewField13311.Value = @"20.";

                    NewField14311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 186, 16, 191, false);
                    NewField14311.Name = "NewField14311";
                    NewField14311.Value = @"21.";

                    İLÇESİ15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 196, 77, 201, false);
                    İLÇESİ15.Name = "İLÇESİ15";
                    İLÇESİ15.ObjectDefName = "PAtient";
                    İLÇESİ15.Value = @"";

                    NewField15311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 196, 16, 201, false);
                    NewField15311.Name = "NewField15311";
                    NewField15311.Value = @"24.";

                    NewField1651 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 201, 133, 206, false);
                    NewField1651.Name = "NewField1651";
                    NewField1651.Value = @"İkamete Geliş Tarihi";

                    NewField16311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 206, 16, 211, false);
                    NewField16311.Name = "NewField16311";
                    NewField16311.Value = @"26.";

                    NewField17311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 216, 16, 221, false);
                    NewField17311.Name = "NewField17311";
                    NewField17311.Value = @"27.";

                    NewField19311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 129, 83, 134, false);
                    NewField19311.Name = "NewField19311";
                    NewField19311.Value = @"15.";

                    NewField1252 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 54, 90, 59, false);
                    NewField1252.Name = "NewField1252";
                    NewField1252.Value = @"Aile Sıra No";

                    AILE_NO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 58, 59, 90, 64, false);
                    AILE_NO.Name = "AILE_NO";
                    AILE_NO.FieldType = ReportFieldTypeEnum.ftVariable;
                    AILE_NO.ObjectDefName = "Person";
                    AILE_NO.DataMember = "FAMILYNO";
                    AILE_NO.Value = @"{%PATIENT%}";

                    NewField12312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 51, 59, 58, 64, false);
                    NewField12312.Name = "NewField12312";
                    NewField12312.Value = @"6.";

                    NewField1253 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 54, 133, 59, false);
                    NewField1253.Name = "NewField1253";
                    NewField1253.Value = @"Birey Sıra No";

                    SIRANO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 59, 133, 64, false);
                    SIRANO.Name = "SIRANO";
                    SIRANO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIRANO.ObjectDefName = "Person";
                    SIRANO.DataMember = "IDENTIFICATIONSERIESNO";
                    SIRANO.Value = @"{%PATIENT%}";

                    NewField12313 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 94, 59, 101, 64, false);
                    NewField12313.Name = "NewField12313";
                    NewField12313.Value = @"5.";

                    NewField111391 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 29, 83, 34, false);
                    NewField111391.Name = "NewField111391";
                    NewField111391.Value = @"2.";

                    NewField11541 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 175, 108, 180, false);
                    NewField11541.Name = "NewField11541";
                    NewField11541.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11541.Value = @"İKAMETGAH BİLGİLERİ";

                    İLÇESİ141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 186, 102, 191, false);
                    İLÇESİ141.Name = "İLÇESİ141";
                    İLÇESİ141.ObjectDefName = "PAtient";
                    İLÇESİ141.Value = @"";

                    NewField111341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 186, 56, 191, false);
                    NewField111341.Name = "NewField111341";
                    NewField111341.Value = @"22.";

                    İLÇESİ1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 186, 133, 191, false);
                    İLÇESİ1141.Name = "İLÇESİ1141";
                    İLÇESİ1141.ObjectDefName = "PAtient";
                    İLÇESİ1141.Value = @"";

                    NewField1143111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 186, 109, 191, false);
                    NewField1143111.Name = "NewField1143111";
                    NewField1143111.Value = @"23.";

                    İLÇESİ151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 84, 196, 133, 201, false);
                    İLÇESİ151.Name = "İLÇESİ151";
                    İLÇESİ151.ObjectDefName = "PAtient";
                    İLÇESİ151.Value = @"";

                    NewField111351 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 196, 84, 201, false);
                    NewField111351.Name = "NewField111351";
                    NewField111351.Value = @"25.";

                    NewField1153111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 216, 84, 221, false);
                    NewField1153111.Name = "NewField1153111";
                    NewField1153111.Value = @"25.";

                    NewField18311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 119, 140, 124, false);
                    NewField18311.Name = "NewField18311";
                    NewField18311.Value = @"13.";

                    TCKIMLIKNO11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 129, 162, 134, false);
                    TCKIMLIKNO11.Name = "TCKIMLIKNO11";
                    TCKIMLIKNO11.ObjectDefName = "PAtient";
                    TCKIMLIKNO11.Value = @"";

                    NewField1231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 129, 140, 134, false);
                    NewField1231.Name = "NewField1231";
                    NewField1231.Value = @"14.";

                    NewField19312 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 139, 140, 144, false);
                    NewField19312.Name = "NewField19312";
                    NewField19312.Value = @"16.";

                    NewField111392 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 129, 167, 134, false);
                    NewField111392.Name = "NewField111392";
                    NewField111392.Value = @"15.";

                    CINSIYET111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 139, 201, 144, false);
                    CINSIYET111.Name = "CINSIYET111";
                    CINSIYET111.ObjectDefName = "PAtient";
                    CINSIYET111.Value = @"";

                    NewField1293111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 162, 139, 167, 144, false);
                    NewField1293111.Name = "NewField1293111";
                    NewField1293111.Value = @"17.";

                    NewField111311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 149, 140, 154, false);
                    NewField111311.Name = "NewField111311";
                    NewField111311.Value = @"18.";

                    NewField111321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 159, 140, 164, false);
                    NewField111321.Name = "NewField111321";
                    NewField111321.Value = @"19.";

                    İLÇESİ131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 169, 201, 174, false);
                    İLÇESİ131.Name = "İLÇESİ131";
                    İLÇESİ131.ObjectDefName = "PAtient";
                    İLÇESİ131.Value = @"";

                    NewField111331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 133, 169, 140, 174, false);
                    NewField111331.Name = "NewField111331";
                    NewField111331.Value = @"20.";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 222, 72, 228, false);
                    NewField3.Name = "NewField3";
                    NewField3.Value = @"Bildirimde Bulunanın";

                    NewField17 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 228, 29, 234, false);
                    NewField17.Name = "NewField17";
                    NewField17.Value = @"Adı    :";

                    NewField171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 234, 29, 240, false);
                    NewField171.Name = "NewField171";
                    NewField171.Value = @"Soyadı    :";

                    NewField172 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 240, 29, 246, false);
                    NewField172.Name = "NewField172";
                    NewField172.Value = @"Doğum Tarihi:";

                    NewField173 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 222, 94, 228, false);
                    NewField173.Name = "NewField173";
                    NewField173.Value = @"Adresi  :";

                    NewField1271 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 240, 94, 246, false);
                    NewField1271.Name = "NewField1271";
                    NewField1271.Value = @"Tarihi:";

                    NewField11721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 240, 156, 246, false);
                    NewField11721.Name = "NewField11721";
                    NewField11721.Value = @"İmza:";

                    NewField18 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 247, 73, 283, false);
                    NewField18.Name = "NewField18";
                    NewField18.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18.MultiLine = EvetHayirEnum.ehEvet;
                    NewField18.NoClip = EvetHayirEnum.ehEvet;
                    NewField18.WordBreak = EvetHayirEnum.ehEvet;
                    NewField18.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField18.Value = @"Tutanağı Düzenleyen Memurun
Adı     :
Soyadı  :
Ünvanı  :
İmzası  :
";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 247, 136, 283, false);
                    NewField181.Name = "NewField181";
                    NewField181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField181.MultiLine = EvetHayirEnum.ehEvet;
                    NewField181.NoClip = EvetHayirEnum.ehEvet;
                    NewField181.WordBreak = EvetHayirEnum.ehEvet;
                    NewField181.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField181.Value = @"Onaylayan Yetkilinin
Adı     :
Soyadı  :
Ünvanı  :   
İmzası  :                     Mühür:
";

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 247, 201, 259, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1181.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1181.NoClip = EvetHayirEnum.ehEvet;
                    NewField1181.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1181.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1181.Value = @"Tutanağın Düzenlendiği Yer";

                    NewField11811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 259, 201, 271, false);
                    NewField11811.Name = "NewField11811";
                    NewField11811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11811.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11811.NoClip = EvetHayirEnum.ehEvet;
                    NewField11811.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11811.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11811.Value = @"Kayıt Tarihi";

                    NewField11813 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 283, 73, 293, false);
                    NewField11813.Name = "NewField11813";
                    NewField11813.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11813.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11813.NoClip = EvetHayirEnum.ehEvet;
                    NewField11813.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11813.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11813.Value = @"İşleme Koyan Nüfus İdaresi";

                    NewField131811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 283, 136, 293, false);
                    NewField131811.Name = "NewField131811";
                    NewField131811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131811.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131811.NoClip = EvetHayirEnum.ehEvet;
                    NewField131811.WordBreak = EvetHayirEnum.ehEvet;
                    NewField131811.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField131811.Value = @"Kayıt Tarihi:";

                    NewField131812 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 283, 201, 293, false);
                    NewField131812.Name = "NewField131812";
                    NewField131812.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131812.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131812.NoClip = EvetHayirEnum.ehEvet;
                    NewField131812.WordBreak = EvetHayirEnum.ehEvet;
                    NewField131812.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField131812.Value = @"Kayıt No:";

                    NewField1218131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 271, 201, 283, false);
                    NewField1218131.Name = "NewField1218131";
                    NewField1218131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1218131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1218131.NoClip = EvetHayirEnum.ehEvet;
                    NewField1218131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1218131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1218131.Value = @"Kayıt No:";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 23, 9, 247, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 133, 23, 133, 221, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 201, 23, 201, 247, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 73, 221, 73, 247, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 139, 24, 189, 29, false);
                    NewField142.Name = "NewField142";
                    NewField142.Value = @"Cinsiyeti";

                    NewField1193111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 29, 139, 34, false);
                    NewField1193111.Name = "NewField1193111";
                    NewField1193111.Value = @"2.";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField2.CalcValue = NewField2.Value;
                    PATIENT.CalcValue = @"";
                    TCKIMLIKNO.CalcValue = MyParentReport.Taraf.PATIENT.CalcValue;
                    TCKIMLIKNO.PostFieldValueCalculation();
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField15.CalcValue = NewField15.Value;
                    İLÇESİ.CalcValue = MyParentReport.Taraf.PATIENT.CalcValue;
                    İLÇESİ.PostFieldValueCalculation();
                    NewField131.CalcValue = NewField131.Value;
                    NewField151.CalcValue = NewField151.Value;
                    KOYMAHHALE.CalcValue = MyParentReport.Taraf.PATIENT.CalcValue;
                    KOYMAHHALE.PostFieldValueCalculation();
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField152.CalcValue = NewField152.Value;
                    CILTNO.CalcValue = MyParentReport.Taraf.PATIENT.CalcValue;
                    CILTNO.PostFieldValueCalculation();
                    NewField1132.CalcValue = NewField1132.Value;
                    NewField153.CalcValue = NewField153.Value;
                    ADI.CalcValue = MyParentReport.Taraf.PATIENT.CalcValue;
                    ADI.PostFieldValueCalculation();
                    NewField1133.CalcValue = NewField1133.Value;
                    NewField154.CalcValue = NewField154.Value;
                    SOYADI.CalcValue = MyParentReport.Taraf.PATIENT.CalcValue;
                    SOYADI.PostFieldValueCalculation();
                    NewField1134.CalcValue = NewField1134.Value;
                    NewField155.CalcValue = NewField155.Value;
                    BABAADI.CalcValue = MyParentReport.Taraf.PATIENT.CalcValue;
                    BABAADI.PostFieldValueCalculation();
                    NewField1135.CalcValue = NewField1135.Value;
                    NewField156.CalcValue = NewField156.Value;
                    ANAADI.CalcValue = MyParentReport.Taraf.PATIENT.CalcValue;
                    ANAADI.PostFieldValueCalculation();
                    NewField1136.CalcValue = NewField1136.Value;
                    NewField1137.CalcValue = NewField1137.Value;
                    NewField1138.CalcValue = NewField1138.Value;
                    NewField132.CalcValue = NewField132.Value;
                    CINSIYET1.CalcValue = CINSIYET1.Value;
                    NewField1139.CalcValue = NewField1139.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    NewField12311.CalcValue = NewField12311.Value;
                    İLÇESİ13.CalcValue = İLÇESİ13.Value;
                    NewField13311.CalcValue = NewField13311.Value;
                    NewField14311.CalcValue = NewField14311.Value;
                    İLÇESİ15.CalcValue = İLÇESİ15.Value;
                    NewField15311.CalcValue = NewField15311.Value;
                    NewField1651.CalcValue = NewField1651.Value;
                    NewField16311.CalcValue = NewField16311.Value;
                    NewField17311.CalcValue = NewField17311.Value;
                    NewField19311.CalcValue = NewField19311.Value;
                    NewField1252.CalcValue = NewField1252.Value;
                    AILE_NO.CalcValue = MyParentReport.Taraf.PATIENT.CalcValue;
                    AILE_NO.PostFieldValueCalculation();
                    NewField12312.CalcValue = NewField12312.Value;
                    NewField1253.CalcValue = NewField1253.Value;
                    SIRANO.CalcValue = MyParentReport.Taraf.PATIENT.CalcValue;
                    SIRANO.PostFieldValueCalculation();
                    NewField12313.CalcValue = NewField12313.Value;
                    NewField111391.CalcValue = NewField111391.Value;
                    NewField11541.CalcValue = NewField11541.Value;
                    İLÇESİ141.CalcValue = İLÇESİ141.Value;
                    NewField111341.CalcValue = NewField111341.Value;
                    İLÇESİ1141.CalcValue = İLÇESİ1141.Value;
                    NewField1143111.CalcValue = NewField1143111.Value;
                    İLÇESİ151.CalcValue = İLÇESİ151.Value;
                    NewField111351.CalcValue = NewField111351.Value;
                    NewField1153111.CalcValue = NewField1153111.Value;
                    NewField18311.CalcValue = NewField18311.Value;
                    TCKIMLIKNO11.CalcValue = TCKIMLIKNO11.Value;
                    NewField1231.CalcValue = NewField1231.Value;
                    NewField19312.CalcValue = NewField19312.Value;
                    NewField111392.CalcValue = NewField111392.Value;
                    CINSIYET111.CalcValue = CINSIYET111.Value;
                    NewField1293111.CalcValue = NewField1293111.Value;
                    NewField111311.CalcValue = NewField111311.Value;
                    NewField111321.CalcValue = NewField111321.Value;
                    İLÇESİ131.CalcValue = İLÇESİ131.Value;
                    NewField111331.CalcValue = NewField111331.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField17.CalcValue = NewField17.Value;
                    NewField171.CalcValue = NewField171.Value;
                    NewField172.CalcValue = NewField172.Value;
                    NewField173.CalcValue = NewField173.Value;
                    NewField1271.CalcValue = NewField1271.Value;
                    NewField11721.CalcValue = NewField11721.Value;
                    NewField18.CalcValue = NewField18.Value;
                    NewField181.CalcValue = NewField181.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    NewField11811.CalcValue = NewField11811.Value;
                    NewField11813.CalcValue = NewField11813.Value;
                    NewField131811.CalcValue = NewField131811.Value;
                    NewField131812.CalcValue = NewField131812.Value;
                    NewField1218131.CalcValue = NewField1218131.Value;
                    NewField142.CalcValue = NewField142.Value;
                    NewField1193111.CalcValue = NewField1193111.Value;
                    return new TTReportObject[] { NewField1,NewField11,NewField12,NewField121,NewField2,PATIENT,TCKIMLIKNO,NewField13,NewField14,NewField15,İLÇESİ,NewField131,NewField151,KOYMAHHALE,NewField1131,NewField152,CILTNO,NewField1132,NewField153,ADI,NewField1133,NewField154,SOYADI,NewField1134,NewField155,BABAADI,NewField1135,NewField156,ANAADI,NewField1136,NewField1137,NewField1138,NewField132,CINSIYET1,NewField1139,NewField11311,NewField12311,İLÇESİ13,NewField13311,NewField14311,İLÇESİ15,NewField15311,NewField1651,NewField16311,NewField17311,NewField19311,NewField1252,AILE_NO,NewField12312,NewField1253,SIRANO,NewField12313,NewField111391,NewField11541,İLÇESİ141,NewField111341,İLÇESİ1141,NewField1143111,İLÇESİ151,NewField111351,NewField1153111,NewField18311,TCKIMLIKNO11,NewField1231,NewField19312,NewField111392,CINSIYET111,NewField1293111,NewField111311,NewField111321,İLÇESİ131,NewField111331,NewField3,NewField17,NewField171,NewField172,NewField173,NewField1271,NewField11721,NewField18,NewField181,NewField1181,NewField11811,NewField11813,NewField131811,NewField131812,NewField1218131,NewField142,NewField1193111};
                }
                public override void RunPreScript()
                {
#region TARAF HEADER_PreScript
                    //                                                                        TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((MernisDeathReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            Morgue morgue = (Morgue)context.GetObject(new Guid(sObjectID),"Morgue");
//            if(morgue.StatisticalDeathReason == StatisticalDeathReason.DeadBirth)
//            {
//                if(morgue.MasterAction != null && morgue.MasterAction is BirthReport)
//                {
//                    if(((BirthReport)morgue.MasterAction).Baby!=null)
//                    {
//                        this.PATIENT.Value=((BirthReport)morgue.MasterAction).Baby.ObjectID.ToString();
//                    }
//                }
//            }
//            else
//                this.PATIENT.Value=morgue.Episode.Patient.ObjectID.ToString();
#endregion TARAF HEADER_PreScript
                }

                public override void RunScript()
                {
#region TARAF HEADER_Script
                    //                                                TTObjectContext context = new TTObjectContext(true);
//            string sObjectID = ((MernisDeathReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
//            Morgue morgue = (Morgue)context.GetObject(new Guid(sObjectID),"Morgue");
//            if(morgue.StatisticalDeathReason==StatisticalDeathReason.DeadBirth)
//            {
//                if(morgue.MasterAction!=null && morgue.MasterAction is BirthReport)
//                {
//                    if(((BirthReport)morgue.MasterAction).Baby==null)
//                    {
//                        this.ANAADI.CalcValue=morgue.Episode.Patient.Name;
//                        if(((BirthReport)morgue.MasterAction).PartnerName != null)
//                            this.BABAADI.CalcValue=((BirthReport)morgue.MasterAction).PartnerName.ToString();
//                        this.CINSIYET.CalcValue=((BirthReport)morgue.MasterAction).Sex==SexEnum.Female ? "Kadın" : (((BirthReport)morgue.MasterAction).Sex==SexEnum.Male ? "Erkek" : "") ;
//                        this.CINSIYETKODU.CalcValue=((BirthReport)morgue.MasterAction).Sex==SexEnum.Female ? "K" : (((BirthReport)morgue.MasterAction).Sex==SexEnum.Male ? "E" : "") ;
//                    }
//                }
//            }
//            else
//            {
//                this.CINSIYETKODU.CalcValue=morgue.Episode.Patient.Sex==SexEnum.Female ? "K" : (morgue.Episode.Patient.Sex==SexEnum.Male ? "E" : "") ;
//            }
//
//            if(morgue.IsOutRequest==true)
//            {
//                if(morgue.OutDeathOrderNo != null)
//                    this.OLUMSIRANO.CalcValue=morgue.OutDeathOrderNo.ToString();
//                if(morgue.DeathBodyAdmittedFrom != null)
//                    this.BILDIRIMADI.CalcValue=morgue.DeathBodyAdmittedFrom.ToString();
//                if(morgue.AddressOfAdmittedFrom != null)
//                    this.BILDIRIMADRES.CalcValue=morgue.AddressOfAdmittedFrom.ToString();
//            }
//            else
//            {
//                if(morgue.DeathOrderNo != null)
//                    this.OLUMSIRANO.CalcValue=morgue.DeathOrderNo.ToString();
//                if(morgue.DoctorFixed!=null)
//                {
//                    if(morgue.DoctorFixed != null)
//                    {
//                        if(morgue.DoctorFixed.Person != null)
//                        {
//                            this.BILDIRIMADI.CalcValue=morgue.DoctorFixed.Person.Name;
//                            this.BILDIRIMSOYADI.CalcValue=morgue.DoctorFixed.Person.Surname;
//                        }
//                    }
//                }
//            }
#endregion TARAF HEADER_Script
                }
            }
            public partial class TarafGroupFooter : TTReportSection
            {
                public MernisDeathReport MyParentReport
                {
                    get { return (MernisDeathReport)ParentReport; }
                }
                
                public TTReportField NewField182;
                public TTReportField NewField1182;
                public TTReportField NewField1281;
                public TTReportField NewField11821;
                public TTReportField NewField11822;
                public TTReportField NewField122811;
                public TTReportField NewField1282;
                public TTReportField NewField12811;
                public TTReportField NewField112811;
                public TTReportField NewField12821;
                public TTReportField NewField12822;
                public TTReportField NewField111821;
                public TTReportField NewField112821;
                public TTReportField NewField112822; 
                public TarafGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 297;
                    RepeatCount = 0;
                    
                    NewField182 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 5, 136, 41, false);
                    NewField182.Name = "NewField182";
                    NewField182.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField182.MultiLine = EvetHayirEnum.ehEvet;
                    NewField182.NoClip = EvetHayirEnum.ehEvet;
                    NewField182.WordBreak = EvetHayirEnum.ehEvet;
                    NewField182.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField182.Value = @"İmha eden memurun:

Adı     :
Soyadı  :
Ünvanı  :
Tarihi  :
İmzası  :
";

                    NewField1182 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 5, 201, 41, false);
                    NewField1182.Name = "NewField1182";
                    NewField1182.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1182.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1182.NoClip = EvetHayirEnum.ehEvet;
                    NewField1182.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1182.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1182.Value = @"Onaylayan Yetkilinin

Adı     :
Soyadı  :
Ünvanı  : 
Tarihi  :  
İmzası  :                     Mühür:
";

                    NewField1281 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 5, 73, 41, false);
                    NewField1281.Name = "NewField1281";
                    NewField1281.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1281.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1281.NoClip = EvetHayirEnum.ehEvet;
                    NewField1281.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1281.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1281.Value = @"Geri alınan nüfus cüzdanının

Tarihi         :

Seri No        :

Kayıt Tarihi no:";

                    NewField11821 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 41, 201, 50, false);
                    NewField11821.Name = "NewField11821";
                    NewField11821.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11821.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11821.NoClip = EvetHayirEnum.ehEvet;
                    NewField11821.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11821.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11821.Value = @"Aile fütüğüne tescil için gönderilen nüfus idaresi:";

                    NewField11822 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 50, 103, 60, false);
                    NewField11822.Name = "NewField11822";
                    NewField11822.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11822.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11822.NoClip = EvetHayirEnum.ehEvet;
                    NewField11822.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11822.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11822.Value = @"Kayıt tarihi:";

                    NewField122811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 103, 50, 201, 60, false);
                    NewField122811.Name = "NewField122811";
                    NewField122811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField122811.MultiLine = EvetHayirEnum.ehEvet;
                    NewField122811.NoClip = EvetHayirEnum.ehEvet;
                    NewField122811.WordBreak = EvetHayirEnum.ehEvet;
                    NewField122811.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField122811.Value = @"Kayıt No:";

                    NewField1282 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 60, 136, 96, false);
                    NewField1282.Name = "NewField1282";
                    NewField1282.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1282.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1282.NoClip = EvetHayirEnum.ehEvet;
                    NewField1282.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1282.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1282.Value = @"Kontrol eden şefin

Adı     :
Soyadı  :

Tarihi  :
İmzası  :
";

                    NewField12811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 60, 201, 96, false);
                    NewField12811.Name = "NewField12811";
                    NewField12811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12811.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12811.NoClip = EvetHayirEnum.ehEvet;
                    NewField12811.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12811.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12811.Value = @"Onaylayan Yetkilinin

Adı     :
Soyadı  :
Ünvanı  : 
Tarihi  :  
İmzası  :                     Mühür:
";

                    NewField112811 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 96, 201, 105, false);
                    NewField112811.Name = "NewField112811";
                    NewField112811.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112811.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112811.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112811.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112811.NoClip = EvetHayirEnum.ehEvet;
                    NewField112811.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112811.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112811.Value = @"Nüf.ve Vat.İşl.Gn.Md.lüğünde(Bilgi İşlen Daire Başkanlığına)";

                    NewField12821 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 60, 73, 96, false);
                    NewField12821.Name = "NewField12821";
                    NewField12821.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12821.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12821.NoClip = EvetHayirEnum.ehEvet;
                    NewField12821.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12821.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12821.Value = @"Kütüğe işleyen memurun:

Adı     :
Soyadı  :
Ünvanı  :
Tarihi  :
İmzası  :
";

                    NewField12822 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 106, 136, 142, false);
                    NewField12822.Name = "NewField12822";
                    NewField12822.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12822.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12822.NoClip = EvetHayirEnum.ehEvet;
                    NewField12822.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12822.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12822.Value = @"Formun veri girişini yapanın:

Adı     :
Soyadı  :
Tarihi  :

İmzası  :
";

                    NewField111821 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 136, 106, 201, 142, false);
                    NewField111821.Name = "NewField111821";
                    NewField111821.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111821.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111821.NoClip = EvetHayirEnum.ehEvet;
                    NewField111821.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111821.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111821.Value = @"Çıkış kontrolü yapanın

Adı     :
Soyadı  :
Tarihi  :  

İmzası  :                    
";

                    NewField112821 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 106, 73, 142, false);
                    NewField112821.Name = "NewField112821";
                    NewField112821.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112821.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112821.NoClip = EvetHayirEnum.ehEvet;
                    NewField112821.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112821.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112821.Value = @"Fornu kontrol ednin:

Adı     :
Soyadı  :
Tarihi  :

İmzası  :
";

                    NewField112822 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 142, 201, 295, false);
                    NewField112822.Name = "NewField112822";
                    NewField112822.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112822.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112822.NoClip = EvetHayirEnum.ehEvet;
                    NewField112822.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112822.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112822.TextFont.CharSet = 162;
                    NewField112822.Value = @"  AÇIKLAMALAR

1-Ölüm yerinin ilçe/ülke kodu(no:16) hanesine ölüm yerinin bağlı olduğu ilçe,ölüm yabancı ülkede olmuşsa ülke kodu yazılacaktır.
2-Ölüm nedeni kodları (no:19) aşağıdaki gibidir.
  Ölüm Nedeni                                                                                   Kodu
  Hastalık(ölüm nedeni alanına hastalığın adı ile yazılacaktır).................01

  Doğal felaket .....................................................................................02

  İş kazası ............................................................................................03

  Trafik kazası ......................................................................................04

  Diğer kazalar .....................................................................................05

  Savaş(sivil halk için) ...........................................................................06
  
  Şehit....................................................................................................07

  Suikast Sonucu Ölüm ..........................................................................08

  Cinayet ...............................................................................................09

  Katliam sonucu ...................................................................................10

  İntahar ................................................................................................11

  Asayis kuvetleri ile çatışma sonucu ölüm..............................................12

  Nedeni bilinmeyen ölüm ......................................................................13

  Ölü kabul edilme hali ...........................................................................14

3-Ölüm yeri türü alanı (no:17) ölüm kırsal bölgede olmuşsa (1), kentsel bölgede olmuşsa (2) , yurt dışında olmuşsa(3) kodlanır.
4- Ölüm nedenini tespit eden kurum kodları (no:20)  XXXXXX (1),  Sağlık Ocağı(2),  Belediye Tabibi (3), Diğer (9)";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField182.CalcValue = NewField182.Value;
                    NewField1182.CalcValue = NewField1182.Value;
                    NewField1281.CalcValue = NewField1281.Value;
                    NewField11821.CalcValue = NewField11821.Value;
                    NewField11822.CalcValue = NewField11822.Value;
                    NewField122811.CalcValue = NewField122811.Value;
                    NewField1282.CalcValue = NewField1282.Value;
                    NewField12811.CalcValue = NewField12811.Value;
                    NewField112811.CalcValue = NewField112811.Value;
                    NewField12821.CalcValue = NewField12821.Value;
                    NewField12822.CalcValue = NewField12822.Value;
                    NewField111821.CalcValue = NewField111821.Value;
                    NewField112821.CalcValue = NewField112821.Value;
                    NewField112822.CalcValue = NewField112822.Value;
                    return new TTReportObject[] { NewField182,NewField1182,NewField1281,NewField11821,NewField11822,NewField122811,NewField1282,NewField12811,NewField112811,NewField12821,NewField12822,NewField111821,NewField112821,NewField112822};
                }
            }

        }

        public TarafGroup Taraf;

        public partial class MAINGroup : TTReportGroup
        {
            public MernisDeathReport MyParentReport
            {
                get { return (MernisDeathReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
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
                public MernisDeathReport MyParentReport
                {
                    get { return (MernisDeathReport)ParentReport; }
                }
                 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 1;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public MernisDeathReport()
        {
            Taraf = new TarafGroup(this,"Taraf");
            MAIN = new MAINGroup(Taraf,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "TTObject", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "MERNISDEATHREPORT";
            Caption = "Mernis Ölüm Tutanağı";
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