
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
    /// Hemşirelik Hizmetleri Hasta Ön Değerlendirme Raporu
    /// </summary>
    public partial class NursingPatientPreAssessmentForm : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HEADERGroup : TTReportGroup
        {
            public NursingPatientPreAssessmentForm MyParentReport
            {
                get { return (NursingPatientPreAssessmentForm)ParentReport; }
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
            public TTReportShape NewLine1 { get {return Header().NewLine1;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public TTReportShape NewLine13 { get {return Header().NewLine13;} }
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
                public NursingPatientPreAssessmentForm MyParentReport
                {
                    get { return (NursingPatientPreAssessmentForm)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField XXXXXXBASLIK111;
                public TTReportField LOGO;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine111;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine13; 
                public HEADERGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 55;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 42, 204, 50, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Hemşirelik Hizmetleri Hasta Ön Değerlendirme Raporu";

                    XXXXXXBASLIK111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 59, 10, 204, 40, false);
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

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 18, 48, 41, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 9, 11, 51, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 9, 206, 9, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 206, 9, 206, 51, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 41, 206, 41, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 11, 51, 206, 51, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 56, 9, 56, 51, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField111.CalcValue = NewField111.Value;
                    LOGO.CalcValue = @"";
                    XXXXXXBASLIK111.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NewField111,LOGO,XXXXXXBASLIK111};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
#endregion HEADER HEADER_Script
                }
            }
            public partial class HEADERGroupFooter : TTReportSection
            {
                public NursingPatientPreAssessmentForm MyParentReport
                {
                    get { return (NursingPatientPreAssessmentForm)ParentReport; }
                }
                 
                public HEADERGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 13;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public HEADERGroup HEADER;

        public partial class MAINGroup : TTReportGroup
        {
            public NursingPatientPreAssessmentForm MyParentReport
            {
                get { return (NursingPatientPreAssessmentForm)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField NewField11221 { get {return Body().NewField11221;} }
            public TTReportShape NewLine12 { get {return Body().NewLine12;} }
            public TTReportShape NewLine141 { get {return Body().NewLine141;} }
            public TTReportShape NewLine1141 { get {return Body().NewLine1141;} }
            public TTReportShape NewLine11411 { get {return Body().NewLine11411;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportShape NewLine111411 { get {return Body().NewLine111411;} }
            public TTReportShape NewLine121411 { get {return Body().NewLine121411;} }
            public TTReportShape NewLine131411 { get {return Body().NewLine131411;} }
            public TTReportShape NewLine141411 { get {return Body().NewLine141411;} }
            public TTReportShape NewLine1114121 { get {return Body().NewLine1114121;} }
            public TTReportShape NewLine11214111 { get {return Body().NewLine11214111;} }
            public TTReportField NewField12 { get {return Body().NewField12;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportShape NewLine151 { get {return Body().NewLine151;} }
            public TTReportShape NewLine11511 { get {return Body().NewLine11511;} }
            public TTReportField YARALANMA_SEKLI { get {return Body().YARALANMA_SEKLI;} }
            public TTReportField REHAB_BILGI { get {return Body().REHAB_BILGI;} }
            public TTReportField REHAB_TARIHI { get {return Body().REHAB_TARIHI;} }
            public TTReportField REFAKATCI_GEREKSINIMI { get {return Body().REFAKATCI_GEREKSINIMI;} }
            public TTReportField REFAKATCI_ADI { get {return Body().REFAKATCI_ADI;} }
            public TTReportField REFAKATCI_TEL { get {return Body().REFAKATCI_TEL;} }
            public TTReportField GELDIGI_YER { get {return Body().GELDIGI_YER;} }
            public TTReportField GELIS_SEKLI { get {return Body().GELIS_SEKLI;} }
            public TTReportShape NewLine161 { get {return Body().NewLine161;} }
            public TTReportShape NewLine111511 { get {return Body().NewLine111511;} }
            public TTReportShape NewLine1115111 { get {return Body().NewLine1115111;} }
            public TTReportField NewField1131 { get {return Body().NewField1131;} }
            public TTReportField NewField11311 { get {return Body().NewField11311;} }
            public TTReportShape NewLine11115111 { get {return Body().NewLine11115111;} }
            public TTReportField YAKINLIK_DER { get {return Body().YAKINLIK_DER;} }
            public TTReportField REFAKATCI_ADR { get {return Body().REFAKATCI_ADR;} }
            public TTReportShape NewLine111141211 { get {return Body().NewLine111141211;} }
            public TTReportShape NewLine1112141111 { get {return Body().NewLine1112141111;} }
            public TTReportShape NewLine1112141112 { get {return Body().NewLine1112141112;} }
            public TTReportShape NewLine1112141113 { get {return Body().NewLine1112141113;} }
            public TTReportShape NewLine1112141114 { get {return Body().NewLine1112141114;} }
            public TTReportField NewField1161 { get {return Body().NewField1161;} }
            public TTReportField NewField11611 { get {return Body().NewField11611;} }
            public TTReportField NewField11612 { get {return Body().NewField11612;} }
            public TTReportField NewField11613 { get {return Body().NewField11613;} }
            public TTReportField NewField11614 { get {return Body().NewField11614;} }
            public TTReportField KRONIK_HASTALIK { get {return Body().KRONIK_HASTALIK;} }
            public TTReportField BULASICI_HASTALIK { get {return Body().BULASICI_HASTALIK;} }
            public TTReportField ALERJI_DURUMU { get {return Body().ALERJI_DURUMU;} }
            public TTReportField AILESEL_HASTALIK { get {return Body().AILESEL_HASTALIK;} }
            public TTReportField GECIRILMIS_HASTALIK { get {return Body().GECIRILMIS_HASTALIK;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField NewField141611 { get {return Body().NewField141611;} }
            public TTReportField YARDIMCI_CIHAZ { get {return Body().YARDIMCI_CIHAZ;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine15 { get {return Body().NewLine15;} }
            public TTReportShape NewLine16 { get {return Body().NewLine16;} }
            public TTReportShape NewLine17 { get {return Body().NewLine17;} }
            public TTReportShape NewLine18 { get {return Body().NewLine18;} }
            public TTReportShape NewLine19 { get {return Body().NewLine19;} }
            public TTReportField NewField1116141 { get {return Body().NewField1116141;} }
            public TTReportField NewField1116142 { get {return Body().NewField1116142;} }
            public TTReportField NewField1116143 { get {return Body().NewField1116143;} }
            public TTReportField NewField1116144 { get {return Body().NewField1116144;} }
            public TTReportField NewField1116145 { get {return Body().NewField1116145;} }
            public TTReportField NewField1116146 { get {return Body().NewField1116146;} }
            public TTReportField NewField1116147 { get {return Body().NewField1116147;} }
            public TTReportField NewField1116148 { get {return Body().NewField1116148;} }
            public TTReportField ALISKANLIKLAR { get {return Body().ALISKANLIKLAR;} }
            public TTReportShape NewLine11115112 { get {return Body().NewLine11115112;} }
            public TTReportShape NewLine191 { get {return Body().NewLine191;} }
            public TTReportField SIGARA { get {return Body().SIGARA;} }
            public TTReportField ALKOL { get {return Body().ALKOL;} }
            public TTReportField MADDE { get {return Body().MADDE;} }
            public TTReportField DIGER_ALISKANLIK { get {return Body().DIGER_ALISKANLIK;} }
            public TTReportField KANGRUBU { get {return Body().KANGRUBU;} }
            public TTReportField KAN_TRANFUZYONU { get {return Body().KAN_TRANFUZYONU;} }
            public TTReportField KAN_TRANFUZYON_REAKSIYON { get {return Body().KAN_TRANFUZYON_REAKSIYON;} }
            public TTReportField NewField18416111 { get {return Body().NewField18416111;} }
            public TTReportField ADSOYAD { get {return Body().ADSOYAD;} }
            public TTReportField NewField1122 { get {return Body().NewField1122;} }
            public TTReportField PROTOKOLNO { get {return Body().PROTOKOLNO;} }
            public TTReportField NewField11222 { get {return Body().NewField11222;} }
            public TTReportShape NewLine20 { get {return Body().NewLine20;} }
            public TTReportShape NewLine142 { get {return Body().NewLine142;} }
            public TTReportShape NewLine1142 { get {return Body().NewLine1142;} }
            public TTReportShape NewLine11412 { get {return Body().NewLine11412;} }
            public TTReportField NewField13 { get {return Body().NewField13;} }
            public TTReportShape NewLine111412 { get {return Body().NewLine111412;} }
            public TTReportShape NewLine121412 { get {return Body().NewLine121412;} }
            public TTReportShape NewLine131412 { get {return Body().NewLine131412;} }
            public TTReportShape NewLine141412 { get {return Body().NewLine141412;} }
            public TTReportShape NewLine1114122 { get {return Body().NewLine1114122;} }
            public TTReportShape NewLine11214112 { get {return Body().NewLine11214112;} }
            public TTReportField NewField14 { get {return Body().NewField14;} }
            public TTReportField NewField122 { get {return Body().NewField122;} }
            public TTReportField NewField133 { get {return Body().NewField133;} }
            public TTReportField NewField143 { get {return Body().NewField143;} }
            public TTReportField NewField153 { get {return Body().NewField153;} }
            public TTReportField NewField163 { get {return Body().NewField163;} }
            public TTReportShape NewLine21 { get {return Body().NewLine21;} }
            public TTReportShape NewLine152 { get {return Body().NewLine152;} }
            public TTReportField TCID { get {return Body().TCID;} }
            public TTReportField KLINIK { get {return Body().KLINIK;} }
            public TTReportField CINSIYET { get {return Body().CINSIYET;} }
            public TTReportField YAS { get {return Body().YAS;} }
            public TTReportField KILO { get {return Body().KILO;} }
            public TTReportField BOY { get {return Body().BOY;} }
            public TTReportField TANI { get {return Body().TANI;} }
            public TTReportShape NewLine1151 { get {return Body().NewLine1151;} }
            public TTReportField NewField11211 { get {return Body().NewField11211;} }
            public TTReportField NewField12211 { get {return Body().NewField12211;} }
            public TTReportField NewField13211 { get {return Body().NewField13211;} }
            public TTReportField NewField14211 { get {return Body().NewField14211;} }
            public TTReportField NewField15211 { get {return Body().NewField15211;} }
            public TTReportField NewField16211 { get {return Body().NewField16211;} }
            public TTReportField NewField17211 { get {return Body().NewField17211;} }
            public TTReportField NewField18211 { get {return Body().NewField18211;} }
            public TTReportField NewField19211 { get {return Body().NewField19211;} }
            public TTReportShape NewLine11512 { get {return Body().NewLine11512;} }
            public TTReportField YATIS_TARIHI { get {return Body().YATIS_TARIHI;} }
            public TTReportField YATIS_SAATI { get {return Body().YATIS_SAATI;} }
            public TTReportField CIKIS_TARIHI { get {return Body().CIKIS_TARIHI;} }
            public TTReportField LISAN { get {return Body().LISAN;} }
            public TTReportField EGITIM { get {return Body().EGITIM;} }
            public TTReportField MESLEK { get {return Body().MESLEK;} }
            public TTReportField MEDENIDURUM { get {return Body().MEDENIDURUM;} }
            public TTReportField COCUK { get {return Body().COCUK;} }
            public TTReportField ANT { get {return Body().ANT;} }
            public TTReportShape NewLine162 { get {return Body().NewLine162;} }
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
                public NursingPatientPreAssessmentForm MyParentReport
                {
                    get { return (NursingPatientPreAssessmentForm)ParentReport; }
                }
                
                public TTReportField NewField1121;
                public TTReportField NewField11221;
                public TTReportShape NewLine12;
                public TTReportShape NewLine141;
                public TTReportShape NewLine1141;
                public TTReportShape NewLine11411;
                public TTReportField NewField11;
                public TTReportShape NewLine111411;
                public TTReportShape NewLine121411;
                public TTReportShape NewLine131411;
                public TTReportShape NewLine141411;
                public TTReportShape NewLine1114121;
                public TTReportShape NewLine11214111;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField161;
                public TTReportShape NewLine151;
                public TTReportShape NewLine11511;
                public TTReportField YARALANMA_SEKLI;
                public TTReportField REHAB_BILGI;
                public TTReportField REHAB_TARIHI;
                public TTReportField REFAKATCI_GEREKSINIMI;
                public TTReportField REFAKATCI_ADI;
                public TTReportField REFAKATCI_TEL;
                public TTReportField GELDIGI_YER;
                public TTReportField GELIS_SEKLI;
                public TTReportShape NewLine161;
                public TTReportShape NewLine111511;
                public TTReportShape NewLine1115111;
                public TTReportField NewField1131;
                public TTReportField NewField11311;
                public TTReportShape NewLine11115111;
                public TTReportField YAKINLIK_DER;
                public TTReportField REFAKATCI_ADR;
                public TTReportShape NewLine111141211;
                public TTReportShape NewLine1112141111;
                public TTReportShape NewLine1112141112;
                public TTReportShape NewLine1112141113;
                public TTReportShape NewLine1112141114;
                public TTReportField NewField1161;
                public TTReportField NewField11611;
                public TTReportField NewField11612;
                public TTReportField NewField11613;
                public TTReportField NewField11614;
                public TTReportField KRONIK_HASTALIK;
                public TTReportField BULASICI_HASTALIK;
                public TTReportField ALERJI_DURUMU;
                public TTReportField AILESEL_HASTALIK;
                public TTReportField GECIRILMIS_HASTALIK;
                public TTReportShape NewLine1;
                public TTReportField NewField141611;
                public TTReportField YARDIMCI_CIHAZ;
                public TTReportShape NewLine11;
                public TTReportShape NewLine13;
                public TTReportShape NewLine14;
                public TTReportShape NewLine15;
                public TTReportShape NewLine16;
                public TTReportShape NewLine17;
                public TTReportShape NewLine18;
                public TTReportShape NewLine19;
                public TTReportField NewField1116141;
                public TTReportField NewField1116142;
                public TTReportField NewField1116143;
                public TTReportField NewField1116144;
                public TTReportField NewField1116145;
                public TTReportField NewField1116146;
                public TTReportField NewField1116147;
                public TTReportField NewField1116148;
                public TTReportField ALISKANLIKLAR;
                public TTReportShape NewLine11115112;
                public TTReportShape NewLine191;
                public TTReportField SIGARA;
                public TTReportField ALKOL;
                public TTReportField MADDE;
                public TTReportField DIGER_ALISKANLIK;
                public TTReportField KANGRUBU;
                public TTReportField KAN_TRANFUZYONU;
                public TTReportField KAN_TRANFUZYON_REAKSIYON;
                public TTReportField NewField18416111;
                public TTReportField ADSOYAD;
                public TTReportField NewField1122;
                public TTReportField PROTOKOLNO;
                public TTReportField NewField11222;
                public TTReportShape NewLine20;
                public TTReportShape NewLine142;
                public TTReportShape NewLine1142;
                public TTReportShape NewLine11412;
                public TTReportField NewField13;
                public TTReportShape NewLine111412;
                public TTReportShape NewLine121412;
                public TTReportShape NewLine131412;
                public TTReportShape NewLine141412;
                public TTReportShape NewLine1114122;
                public TTReportShape NewLine11214112;
                public TTReportField NewField14;
                public TTReportField NewField122;
                public TTReportField NewField133;
                public TTReportField NewField143;
                public TTReportField NewField153;
                public TTReportField NewField163;
                public TTReportShape NewLine21;
                public TTReportShape NewLine152;
                public TTReportField TCID;
                public TTReportField KLINIK;
                public TTReportField CINSIYET;
                public TTReportField YAS;
                public TTReportField KILO;
                public TTReportField BOY;
                public TTReportField TANI;
                public TTReportShape NewLine1151;
                public TTReportField NewField11211;
                public TTReportField NewField12211;
                public TTReportField NewField13211;
                public TTReportField NewField14211;
                public TTReportField NewField15211;
                public TTReportField NewField16211;
                public TTReportField NewField17211;
                public TTReportField NewField18211;
                public TTReportField NewField19211;
                public TTReportShape NewLine11512;
                public TTReportField YATIS_TARIHI;
                public TTReportField YATIS_SAATI;
                public TTReportField CIKIS_TARIHI;
                public TTReportField LISAN;
                public TTReportField EGITIM;
                public TTReportField MESLEK;
                public TTReportField MEDENIDURUM;
                public TTReportField COCUK;
                public TTReportField ANT;
                public TTReportShape NewLine162; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 228;
                    RepeatCount = 0;
                    
                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 75, 118, 79, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Yaralanma Şekli:";

                    NewField11221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 81, 118, 85, false);
                    NewField11221.Name = "NewField11221";
                    NewField11221.TextFont.Size = 9;
                    NewField11221.TextFont.Bold = true;
                    NewField11221.TextFont.CharSet = 162;
                    NewField11221.Value = @"Daha Önce rehabilitasyon programına alınmış mı?";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 74, 211, 74, false);
                    NewLine12.Name = "NewLine12";
                    NewLine12.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 80, 211, 80, false);
                    NewLine141.Name = "NewLine141";
                    NewLine141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1141 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 86, 211, 86, false);
                    NewLine1141.Name = "NewLine1141";
                    NewLine1141.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11411 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 92, 211, 92, false);
                    NewLine11411.Name = "NewLine11411";
                    NewLine11411.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 87, 118, 91, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Size = 9;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 0;
                    NewField11.Value = @"Alınmış ise son XXXXXXye kabul tarihi:";

                    NewLine111411 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 98, 211, 98, false);
                    NewLine111411.Name = "NewLine111411";
                    NewLine111411.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121411 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 116, 211, 116, false);
                    NewLine121411.Name = "NewLine121411";
                    NewLine121411.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine131411 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 104, 211, 104, false);
                    NewLine131411.Name = "NewLine131411";
                    NewLine131411.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine141411 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 110, 211, 110, false);
                    NewLine141411.Name = "NewLine141411";
                    NewLine141411.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1114121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 122, 211, 122, false);
                    NewLine1114121.Name = "NewLine1114121";
                    NewLine1114121.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11214111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 128, 211, 128, false);
                    NewLine11214111.Name = "NewLine11214111";
                    NewLine11214111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 93, 118, 97, false);
                    NewField12.Name = "NewField12";
                    NewField12.TextFont.Size = 9;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"Refakatçi gereksinimi";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 99, 210, 103, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Size = 9;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Gerektiğinde iletişim kurulabilecek kişinin";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 105, 40, 109, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Size = 9;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Adı - Soyadı:";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 111, 40, 115, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Size = 9;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"Telefon:";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 117, 118, 121, false);
                    NewField151.Name = "NewField151";
                    NewField151.TextFont.Size = 9;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"Geldiği Yer:";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 123, 118, 127, false);
                    NewField161.Name = "NewField161";
                    NewField161.TextFont.Size = 9;
                    NewField161.TextFont.Bold = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"Birime Geliş Şekli:";

                    NewLine151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 74, 9, 218, false);
                    NewLine151.Name = "NewLine151";
                    NewLine151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 119, 74, 119, 98, false);
                    NewLine11511.Name = "NewLine11511";
                    NewLine11511.DrawStyle = DrawStyleConstants.vbSolid;

                    YARALANMA_SEKLI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 75, 210, 79, false);
                    YARALANMA_SEKLI.Name = "YARALANMA_SEKLI";
                    YARALANMA_SEKLI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YARALANMA_SEKLI.TextFont.Size = 9;
                    YARALANMA_SEKLI.TextFont.CharSet = 162;
                    YARALANMA_SEKLI.Value = @"NewField3";

                    REHAB_BILGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 81, 210, 85, false);
                    REHAB_BILGI.Name = "REHAB_BILGI";
                    REHAB_BILGI.FieldType = ReportFieldTypeEnum.ftVariable;
                    REHAB_BILGI.TextFont.Size = 9;
                    REHAB_BILGI.TextFont.CharSet = 162;
                    REHAB_BILGI.Value = @"";

                    REHAB_TARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 87, 210, 91, false);
                    REHAB_TARIHI.Name = "REHAB_TARIHI";
                    REHAB_TARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    REHAB_TARIHI.TextFont.Size = 9;
                    REHAB_TARIHI.TextFont.CharSet = 162;
                    REHAB_TARIHI.Value = @"";

                    REFAKATCI_GEREKSINIMI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 93, 210, 97, false);
                    REFAKATCI_GEREKSINIMI.Name = "REFAKATCI_GEREKSINIMI";
                    REFAKATCI_GEREKSINIMI.FieldType = ReportFieldTypeEnum.ftVariable;
                    REFAKATCI_GEREKSINIMI.TextFont.Size = 9;
                    REFAKATCI_GEREKSINIMI.TextFont.CharSet = 162;
                    REFAKATCI_GEREKSINIMI.Value = @"";

                    REFAKATCI_ADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 105, 118, 109, false);
                    REFAKATCI_ADI.Name = "REFAKATCI_ADI";
                    REFAKATCI_ADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    REFAKATCI_ADI.TextFont.Size = 9;
                    REFAKATCI_ADI.TextFont.CharSet = 162;
                    REFAKATCI_ADI.Value = @"";

                    REFAKATCI_TEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 42, 111, 118, 115, false);
                    REFAKATCI_TEL.Name = "REFAKATCI_TEL";
                    REFAKATCI_TEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    REFAKATCI_TEL.TextFont.Size = 9;
                    REFAKATCI_TEL.TextFont.CharSet = 162;
                    REFAKATCI_TEL.Value = @"";

                    GELDIGI_YER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 117, 210, 121, false);
                    GELDIGI_YER.Name = "GELDIGI_YER";
                    GELDIGI_YER.FieldType = ReportFieldTypeEnum.ftVariable;
                    GELDIGI_YER.TextFont.Size = 9;
                    GELDIGI_YER.TextFont.CharSet = 162;
                    GELDIGI_YER.Value = @"";

                    GELIS_SEKLI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 123, 210, 127, false);
                    GELIS_SEKLI.Name = "GELIS_SEKLI";
                    GELIS_SEKLI.FieldType = ReportFieldTypeEnum.ftVariable;
                    GELIS_SEKLI.TextFont.Size = 9;
                    GELIS_SEKLI.TextFont.CharSet = 162;
                    GELIS_SEKLI.Value = @"";

                    NewLine161 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 211, 74, 211, 218, false);
                    NewLine161.Name = "NewLine161";
                    NewLine161.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine111511 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 41, 104, 41, 116, false);
                    NewLine111511.Name = "NewLine111511";
                    NewLine111511.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1115111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 119, 104, 119, 170, false);
                    NewLine1115111.Name = "NewLine1115111";
                    NewLine1115111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 105, 150, 109, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.TextFont.Size = 9;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Yakınlık Derecesi:";

                    NewField11311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 111, 150, 115, false);
                    NewField11311.Name = "NewField11311";
                    NewField11311.TextFont.Size = 9;
                    NewField11311.TextFont.CharSet = 162;
                    NewField11311.Value = @"Adres: ";

                    NewLine11115111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 151, 104, 151, 116, false);
                    NewLine11115111.Name = "NewLine11115111";
                    NewLine11115111.DrawStyle = DrawStyleConstants.vbSolid;

                    YAKINLIK_DER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 105, 210, 109, false);
                    YAKINLIK_DER.Name = "YAKINLIK_DER";
                    YAKINLIK_DER.FieldType = ReportFieldTypeEnum.ftVariable;
                    YAKINLIK_DER.TextFont.Size = 9;
                    YAKINLIK_DER.TextFont.CharSet = 162;
                    YAKINLIK_DER.Value = @"";

                    REFAKATCI_ADR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 111, 210, 115, false);
                    REFAKATCI_ADR.Name = "REFAKATCI_ADR";
                    REFAKATCI_ADR.FieldType = ReportFieldTypeEnum.ftVariable;
                    REFAKATCI_ADR.TextFont.Size = 9;
                    REFAKATCI_ADR.TextFont.CharSet = 162;
                    REFAKATCI_ADR.Value = @"";

                    NewLine111141211 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 134, 211, 134, false);
                    NewLine111141211.Name = "NewLine111141211";
                    NewLine111141211.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1112141111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 140, 211, 140, false);
                    NewLine1112141111.Name = "NewLine1112141111";
                    NewLine1112141111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1112141112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 146, 211, 146, false);
                    NewLine1112141112.Name = "NewLine1112141112";
                    NewLine1112141112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1112141113 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 152, 211, 152, false);
                    NewLine1112141113.Name = "NewLine1112141113";
                    NewLine1112141113.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1112141114 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 158, 211, 158, false);
                    NewLine1112141114.Name = "NewLine1112141114";
                    NewLine1112141114.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 129, 118, 133, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.TextFont.Size = 9;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"Kronik Hastalıklar:";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 135, 118, 139, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.TextFont.Size = 9;
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @"Bulaşıcı Hastalıklar:";

                    NewField11612 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 141, 118, 145, false);
                    NewField11612.Name = "NewField11612";
                    NewField11612.TextFont.Size = 9;
                    NewField11612.TextFont.Bold = true;
                    NewField11612.TextFont.CharSet = 162;
                    NewField11612.Value = @"Alerji Durumu:";

                    NewField11613 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 147, 118, 151, false);
                    NewField11613.Name = "NewField11613";
                    NewField11613.TextFont.Size = 9;
                    NewField11613.TextFont.Bold = true;
                    NewField11613.TextFont.CharSet = 162;
                    NewField11613.Value = @"Ailesel Hastalıklar:";

                    NewField11614 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 153, 118, 157, false);
                    NewField11614.Name = "NewField11614";
                    NewField11614.TextFont.Size = 9;
                    NewField11614.TextFont.Bold = true;
                    NewField11614.TextFont.CharSet = 162;
                    NewField11614.Value = @"Geçirilmiş Hastalıklar / Operasyonlar:";

                    KRONIK_HASTALIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 129, 210, 133, false);
                    KRONIK_HASTALIK.Name = "KRONIK_HASTALIK";
                    KRONIK_HASTALIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    KRONIK_HASTALIK.TextFont.Size = 9;
                    KRONIK_HASTALIK.TextFont.CharSet = 162;
                    KRONIK_HASTALIK.Value = @"";

                    BULASICI_HASTALIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 135, 210, 139, false);
                    BULASICI_HASTALIK.Name = "BULASICI_HASTALIK";
                    BULASICI_HASTALIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    BULASICI_HASTALIK.TextFont.Size = 9;
                    BULASICI_HASTALIK.TextFont.CharSet = 162;
                    BULASICI_HASTALIK.Value = @"";

                    ALERJI_DURUMU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 141, 210, 145, false);
                    ALERJI_DURUMU.Name = "ALERJI_DURUMU";
                    ALERJI_DURUMU.FieldType = ReportFieldTypeEnum.ftVariable;
                    ALERJI_DURUMU.TextFont.Size = 9;
                    ALERJI_DURUMU.TextFont.CharSet = 162;
                    ALERJI_DURUMU.Value = @"";

                    AILESEL_HASTALIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 147, 210, 151, false);
                    AILESEL_HASTALIK.Name = "AILESEL_HASTALIK";
                    AILESEL_HASTALIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    AILESEL_HASTALIK.TextFont.Size = 9;
                    AILESEL_HASTALIK.TextFont.CharSet = 162;
                    AILESEL_HASTALIK.Value = @"";

                    GECIRILMIS_HASTALIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 153, 210, 157, false);
                    GECIRILMIS_HASTALIK.Name = "GECIRILMIS_HASTALIK";
                    GECIRILMIS_HASTALIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    GECIRILMIS_HASTALIK.TextFont.Size = 9;
                    GECIRILMIS_HASTALIK.TextFont.CharSet = 162;
                    GECIRILMIS_HASTALIK.Value = @"";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 164, 211, 164, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField141611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 159, 118, 163, false);
                    NewField141611.Name = "NewField141611";
                    NewField141611.TextFont.Size = 9;
                    NewField141611.TextFont.Bold = true;
                    NewField141611.TextFont.CharSet = 162;
                    NewField141611.Value = @"Sürekli Kullandığı Yardımcı Cihazlar:";

                    YARDIMCI_CIHAZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 159, 210, 163, false);
                    YARDIMCI_CIHAZ.Name = "YARDIMCI_CIHAZ";
                    YARDIMCI_CIHAZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    YARDIMCI_CIHAZ.TextFont.Size = 9;
                    YARDIMCI_CIHAZ.TextFont.CharSet = 162;
                    YARDIMCI_CIHAZ.Value = @"";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 170, 211, 170, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 176, 211, 176, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 182, 211, 182, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine15 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 188, 211, 188, false);
                    NewLine15.Name = "NewLine15";
                    NewLine15.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine16 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 194, 211, 194, false);
                    NewLine16.Name = "NewLine16";
                    NewLine16.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine17 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 200, 211, 200, false);
                    NewLine17.Name = "NewLine17";
                    NewLine17.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine18 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 206, 211, 206, false);
                    NewLine18.Name = "NewLine18";
                    NewLine18.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine19 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 212, 211, 212, false);
                    NewLine19.Name = "NewLine19";
                    NewLine19.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField1116141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 165, 118, 169, false);
                    NewField1116141.Name = "NewField1116141";
                    NewField1116141.TextFont.Size = 9;
                    NewField1116141.TextFont.Bold = true;
                    NewField1116141.TextFont.CharSet = 162;
                    NewField1116141.Value = @"Alışkanlıklar:";

                    NewField1116142 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 171, 210, 175, false);
                    NewField1116142.Name = "NewField1116142";
                    NewField1116142.TextFont.Size = 9;
                    NewField1116142.TextFont.Bold = true;
                    NewField1116142.TextFont.CharSet = 162;
                    NewField1116142.Value = @"Varsa Belirtiniz";

                    NewField1116143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 177, 118, 181, false);
                    NewField1116143.Name = "NewField1116143";
                    NewField1116143.TextFont.Size = 9;
                    NewField1116143.TextFont.CharSet = 162;
                    NewField1116143.Value = @"Sigara:";

                    NewField1116144 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 183, 118, 187, false);
                    NewField1116144.Name = "NewField1116144";
                    NewField1116144.TextFont.Size = 9;
                    NewField1116144.TextFont.CharSet = 162;
                    NewField1116144.Value = @"Alkol:";

                    NewField1116145 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 189, 118, 193, false);
                    NewField1116145.Name = "NewField1116145";
                    NewField1116145.TextFont.Size = 9;
                    NewField1116145.TextFont.CharSet = 162;
                    NewField1116145.Value = @"Madde:";

                    NewField1116146 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 195, 118, 199, false);
                    NewField1116146.Name = "NewField1116146";
                    NewField1116146.TextFont.Size = 9;
                    NewField1116146.TextFont.CharSet = 162;
                    NewField1116146.Value = @"Diğer:";

                    NewField1116147 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 201, 118, 205, false);
                    NewField1116147.Name = "NewField1116147";
                    NewField1116147.TextFont.Size = 9;
                    NewField1116147.TextFont.Bold = true;
                    NewField1116147.TextFont.CharSet = 162;
                    NewField1116147.Value = @"Kan Grubu:";

                    NewField1116148 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 207, 118, 211, false);
                    NewField1116148.Name = "NewField1116148";
                    NewField1116148.TextFont.Size = 9;
                    NewField1116148.TextFont.Bold = true;
                    NewField1116148.TextFont.CharSet = 162;
                    NewField1116148.Value = @"Daha önce kan tranfüzyonu uygulandı mı?";

                    ALISKANLIKLAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 165, 210, 169, false);
                    ALISKANLIKLAR.Name = "ALISKANLIKLAR";
                    ALISKANLIKLAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    ALISKANLIKLAR.TextFont.Size = 9;
                    ALISKANLIKLAR.TextFont.CharSet = 162;
                    ALISKANLIKLAR.Value = @"";

                    NewLine11115112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 119, 176, 119, 218, false);
                    NewLine11115112.Name = "NewLine11115112";
                    NewLine11115112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine191 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 218, 211, 218, false);
                    NewLine191.Name = "NewLine191";
                    NewLine191.DrawStyle = DrawStyleConstants.vbSolid;

                    SIGARA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 177, 210, 181, false);
                    SIGARA.Name = "SIGARA";
                    SIGARA.FieldType = ReportFieldTypeEnum.ftVariable;
                    SIGARA.TextFont.Size = 9;
                    SIGARA.TextFont.CharSet = 162;
                    SIGARA.Value = @"";

                    ALKOL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 183, 210, 187, false);
                    ALKOL.Name = "ALKOL";
                    ALKOL.FieldType = ReportFieldTypeEnum.ftVariable;
                    ALKOL.TextFont.Size = 9;
                    ALKOL.TextFont.CharSet = 162;
                    ALKOL.Value = @"";

                    MADDE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 189, 210, 193, false);
                    MADDE.Name = "MADDE";
                    MADDE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDE.TextFont.Size = 9;
                    MADDE.TextFont.CharSet = 162;
                    MADDE.Value = @"";

                    DIGER_ALISKANLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 195, 210, 199, false);
                    DIGER_ALISKANLIK.Name = "DIGER_ALISKANLIK";
                    DIGER_ALISKANLIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIGER_ALISKANLIK.TextFont.Size = 9;
                    DIGER_ALISKANLIK.TextFont.CharSet = 162;
                    DIGER_ALISKANLIK.Value = @"";

                    KANGRUBU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 201, 210, 205, false);
                    KANGRUBU.Name = "KANGRUBU";
                    KANGRUBU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KANGRUBU.TextFont.Size = 9;
                    KANGRUBU.TextFont.CharSet = 162;
                    KANGRUBU.Value = @"";

                    KAN_TRANFUZYONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 207, 210, 211, false);
                    KAN_TRANFUZYONU.Name = "KAN_TRANFUZYONU";
                    KAN_TRANFUZYONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    KAN_TRANFUZYONU.TextFont.Size = 9;
                    KAN_TRANFUZYONU.TextFont.CharSet = 162;
                    KAN_TRANFUZYONU.Value = @"";

                    KAN_TRANFUZYON_REAKSIYON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 213, 210, 217, false);
                    KAN_TRANFUZYON_REAKSIYON.Name = "KAN_TRANFUZYON_REAKSIYON";
                    KAN_TRANFUZYON_REAKSIYON.FieldType = ReportFieldTypeEnum.ftVariable;
                    KAN_TRANFUZYON_REAKSIYON.TextFont.Size = 9;
                    KAN_TRANFUZYON_REAKSIYON.TextFont.CharSet = 162;
                    KAN_TRANFUZYON_REAKSIYON.Value = @"";

                    NewField18416111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 213, 118, 217, false);
                    NewField18416111.Name = "NewField18416111";
                    NewField18416111.TextFont.Size = 9;
                    NewField18416111.TextFont.Bold = true;
                    NewField18416111.TextFont.CharSet = 162;
                    NewField18416111.Value = @"Kan Tranfüzyonu yapıldıysa reaksiyon gelişti mi?";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 17, 118, 21, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.TextFont.Size = 9;
                    ADSOYAD.TextFont.CharSet = 162;
                    ADSOYAD.Value = @"";

                    NewField1122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 17, 38, 21, false);
                    NewField1122.Name = "NewField1122";
                    NewField1122.TextFont.Bold = true;
                    NewField1122.TextFont.CharSet = 162;
                    NewField1122.Value = @"Adı Soyadı:";

                    PROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 23, 118, 27, false);
                    PROTOKOLNO.Name = "PROTOKOLNO";
                    PROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROTOKOLNO.TextFont.Size = 9;
                    PROTOKOLNO.TextFont.CharSet = 162;
                    PROTOKOLNO.Value = @"";

                    NewField11222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 23, 38, 27, false);
                    NewField11222.Name = "NewField11222";
                    NewField11222.TextFont.Size = 9;
                    NewField11222.TextFont.Bold = true;
                    NewField11222.TextFont.CharSet = 162;
                    NewField11222.Value = @"Protokol No:";

                    NewLine20 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 16, 211, 16, false);
                    NewLine20.Name = "NewLine20";
                    NewLine20.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine142 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 22, 211, 22, false);
                    NewLine142.Name = "NewLine142";
                    NewLine142.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1142 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 28, 211, 28, false);
                    NewLine1142.Name = "NewLine1142";
                    NewLine1142.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11412 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 34, 211, 34, false);
                    NewLine11412.Name = "NewLine11412";
                    NewLine11412.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 29, 38, 33, false);
                    NewField13.Name = "NewField13";
                    NewField13.TextFont.Size = 9;
                    NewField13.TextFont.Bold = true;
                    NewField13.TextFont.CharSet = 0;
                    NewField13.Value = @"TC Kimlik Nu:";

                    NewLine111412 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 40, 211, 40, false);
                    NewLine111412.Name = "NewLine111412";
                    NewLine111412.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine121412 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 58, 211, 58, false);
                    NewLine121412.Name = "NewLine121412";
                    NewLine121412.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine131412 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 46, 211, 46, false);
                    NewLine131412.Name = "NewLine131412";
                    NewLine131412.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine141412 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 52, 211, 52, false);
                    NewLine141412.Name = "NewLine141412";
                    NewLine141412.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1114122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 64, 211, 64, false);
                    NewLine1114122.Name = "NewLine1114122";
                    NewLine1114122.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11214112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 70, 211, 70, false);
                    NewLine11214112.Name = "NewLine11214112";
                    NewLine11214112.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 35, 38, 39, false);
                    NewField14.Name = "NewField14";
                    NewField14.TextFont.Size = 9;
                    NewField14.TextFont.Bold = true;
                    NewField14.TextFont.CharSet = 162;
                    NewField14.Value = @"Klinik/Servis:";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 41, 38, 45, false);
                    NewField122.Name = "NewField122";
                    NewField122.TextFont.Size = 9;
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"Cinsiyeti:";

                    NewField133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 47, 38, 51, false);
                    NewField133.Name = "NewField133";
                    NewField133.TextFont.Size = 9;
                    NewField133.TextFont.Bold = true;
                    NewField133.TextFont.CharSet = 162;
                    NewField133.Value = @"Yaş:";

                    NewField143 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 53, 38, 57, false);
                    NewField143.Name = "NewField143";
                    NewField143.TextFont.Size = 9;
                    NewField143.TextFont.Bold = true;
                    NewField143.TextFont.CharSet = 162;
                    NewField143.Value = @"Kilo:";

                    NewField153 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 59, 38, 63, false);
                    NewField153.Name = "NewField153";
                    NewField153.TextFont.Size = 9;
                    NewField153.TextFont.Bold = true;
                    NewField153.TextFont.CharSet = 162;
                    NewField153.Value = @"Boy:";

                    NewField163 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 65, 38, 69, false);
                    NewField163.Name = "NewField163";
                    NewField163.TextFont.Size = 9;
                    NewField163.TextFont.Bold = true;
                    NewField163.TextFont.CharSet = 162;
                    NewField163.Value = @"Ön Tıbbi Tanı/Tanı:";

                    NewLine21 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 39, 16, 39, 70, false);
                    NewLine21.Name = "NewLine21";
                    NewLine21.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine152 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 9, 16, 9, 70, false);
                    NewLine152.Name = "NewLine152";
                    NewLine152.DrawStyle = DrawStyleConstants.vbSolid;

                    TCID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 29, 118, 33, false);
                    TCID.Name = "TCID";
                    TCID.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCID.TextFont.Size = 9;
                    TCID.TextFont.CharSet = 162;
                    TCID.Value = @"";

                    KLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 35, 118, 39, false);
                    KLINIK.Name = "KLINIK";
                    KLINIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLINIK.TextFont.Size = 9;
                    KLINIK.TextFont.CharSet = 162;
                    KLINIK.Value = @"";

                    CINSIYET = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 41, 118, 45, false);
                    CINSIYET.Name = "CINSIYET";
                    CINSIYET.FieldType = ReportFieldTypeEnum.ftVariable;
                    CINSIYET.TextFont.Size = 9;
                    CINSIYET.TextFont.CharSet = 162;
                    CINSIYET.Value = @"";

                    YAS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 47, 118, 51, false);
                    YAS.Name = "YAS";
                    YAS.FieldType = ReportFieldTypeEnum.ftVariable;
                    YAS.TextFont.Size = 9;
                    YAS.TextFont.CharSet = 162;
                    YAS.Value = @"";

                    KILO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 53, 118, 57, false);
                    KILO.Name = "KILO";
                    KILO.FieldType = ReportFieldTypeEnum.ftVariable;
                    KILO.TextFont.Size = 9;
                    KILO.TextFont.CharSet = 162;
                    KILO.Value = @"";

                    BOY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 59, 118, 63, false);
                    BOY.Name = "BOY";
                    BOY.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOY.TextFont.Size = 9;
                    BOY.TextFont.CharSet = 162;
                    BOY.Value = @"";

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 65, 118, 69, false);
                    TANI.Name = "TANI";
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.TextFont.Size = 9;
                    TANI.TextFont.CharSet = 162;
                    TANI.Value = @"";

                    NewLine1151 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 119, 16, 119, 70, false);
                    NewLine1151.Name = "NewLine1151";
                    NewLine1151.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 17, 148, 21, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"Yatış Tarihi:";

                    NewField12211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 23, 148, 27, false);
                    NewField12211.Name = "NewField12211";
                    NewField12211.TextFont.Bold = true;
                    NewField12211.TextFont.CharSet = 162;
                    NewField12211.Value = @"Yatış Saati:";

                    NewField13211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 29, 148, 33, false);
                    NewField13211.Name = "NewField13211";
                    NewField13211.TextFont.Bold = true;
                    NewField13211.TextFont.CharSet = 162;
                    NewField13211.Value = @"Çıkış Tarihi:";

                    NewField14211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 35, 148, 39, false);
                    NewField14211.Name = "NewField14211";
                    NewField14211.TextFont.Bold = true;
                    NewField14211.TextFont.CharSet = 162;
                    NewField14211.Value = @"Kullandığı Lisan:";

                    NewField15211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 41, 148, 45, false);
                    NewField15211.Name = "NewField15211";
                    NewField15211.TextFont.Bold = true;
                    NewField15211.TextFont.CharSet = 162;
                    NewField15211.Value = @"Eğitimi:";

                    NewField16211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 47, 148, 51, false);
                    NewField16211.Name = "NewField16211";
                    NewField16211.TextFont.Bold = true;
                    NewField16211.TextFont.CharSet = 162;
                    NewField16211.Value = @"Mesleği:";

                    NewField17211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 53, 148, 57, false);
                    NewField17211.Name = "NewField17211";
                    NewField17211.TextFont.Bold = true;
                    NewField17211.TextFont.CharSet = 162;
                    NewField17211.Value = @"Medeni Durumu:";

                    NewField18211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 59, 148, 63, false);
                    NewField18211.Name = "NewField18211";
                    NewField18211.TextFont.Bold = true;
                    NewField18211.TextFont.CharSet = 162;
                    NewField18211.Value = @"Çocuk Sayısı:";

                    NewField19211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 65, 148, 69, false);
                    NewField19211.Name = "NewField19211";
                    NewField19211.TextFont.Bold = true;
                    NewField19211.TextFont.CharSet = 162;
                    NewField19211.Value = @"ANT:";

                    NewLine11512 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 149, 16, 149, 70, false);
                    NewLine11512.Name = "NewLine11512";
                    NewLine11512.DrawStyle = DrawStyleConstants.vbSolid;

                    YATIS_TARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 17, 210, 21, false);
                    YATIS_TARIHI.Name = "YATIS_TARIHI";
                    YATIS_TARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATIS_TARIHI.TextFont.Size = 9;
                    YATIS_TARIHI.TextFont.CharSet = 162;
                    YATIS_TARIHI.Value = @"";

                    YATIS_SAATI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 23, 210, 27, false);
                    YATIS_SAATI.Name = "YATIS_SAATI";
                    YATIS_SAATI.FieldType = ReportFieldTypeEnum.ftVariable;
                    YATIS_SAATI.TextFont.Size = 9;
                    YATIS_SAATI.TextFont.CharSet = 162;
                    YATIS_SAATI.Value = @"";

                    CIKIS_TARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 29, 210, 33, false);
                    CIKIS_TARIHI.Name = "CIKIS_TARIHI";
                    CIKIS_TARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    CIKIS_TARIHI.TextFont.Size = 9;
                    CIKIS_TARIHI.TextFont.CharSet = 162;
                    CIKIS_TARIHI.Value = @"";

                    LISAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 35, 210, 39, false);
                    LISAN.Name = "LISAN";
                    LISAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    LISAN.TextFont.Size = 9;
                    LISAN.TextFont.CharSet = 162;
                    LISAN.Value = @"";

                    EGITIM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 41, 210, 45, false);
                    EGITIM.Name = "EGITIM";
                    EGITIM.FieldType = ReportFieldTypeEnum.ftVariable;
                    EGITIM.TextFont.Size = 9;
                    EGITIM.TextFont.CharSet = 162;
                    EGITIM.Value = @"";

                    MESLEK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 47, 210, 51, false);
                    MESLEK.Name = "MESLEK";
                    MESLEK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MESLEK.TextFont.Size = 9;
                    MESLEK.TextFont.CharSet = 162;
                    MESLEK.Value = @"";

                    MEDENIDURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 53, 210, 57, false);
                    MEDENIDURUM.Name = "MEDENIDURUM";
                    MEDENIDURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MEDENIDURUM.TextFont.Size = 9;
                    MEDENIDURUM.TextFont.CharSet = 162;
                    MEDENIDURUM.Value = @"";

                    COCUK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 59, 210, 63, false);
                    COCUK.Name = "COCUK";
                    COCUK.FieldType = ReportFieldTypeEnum.ftVariable;
                    COCUK.TextFont.Size = 9;
                    COCUK.TextFont.CharSet = 162;
                    COCUK.Value = @"";

                    ANT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 150, 65, 210, 69, false);
                    ANT.Name = "ANT";
                    ANT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ANT.TextFont.Size = 9;
                    ANT.TextFont.CharSet = 162;
                    ANT.Value = @"";

                    NewLine162 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 211, 16, 211, 70, false);
                    NewLine162.Name = "NewLine162";
                    NewLine162.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField11221.CalcValue = NewField11221.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField161.CalcValue = NewField161.Value;
                    YARALANMA_SEKLI.CalcValue = @"NewField3";
                    REHAB_BILGI.CalcValue = @"";
                    REHAB_TARIHI.CalcValue = @"";
                    REFAKATCI_GEREKSINIMI.CalcValue = @"";
                    REFAKATCI_ADI.CalcValue = @"";
                    REFAKATCI_TEL.CalcValue = @"";
                    GELDIGI_YER.CalcValue = @"";
                    GELIS_SEKLI.CalcValue = @"";
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField11311.CalcValue = NewField11311.Value;
                    YAKINLIK_DER.CalcValue = @"";
                    REFAKATCI_ADR.CalcValue = @"";
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    NewField11612.CalcValue = NewField11612.Value;
                    NewField11613.CalcValue = NewField11613.Value;
                    NewField11614.CalcValue = NewField11614.Value;
                    KRONIK_HASTALIK.CalcValue = @"";
                    BULASICI_HASTALIK.CalcValue = @"";
                    ALERJI_DURUMU.CalcValue = @"";
                    AILESEL_HASTALIK.CalcValue = @"";
                    GECIRILMIS_HASTALIK.CalcValue = @"";
                    NewField141611.CalcValue = NewField141611.Value;
                    YARDIMCI_CIHAZ.CalcValue = @"";
                    NewField1116141.CalcValue = NewField1116141.Value;
                    NewField1116142.CalcValue = NewField1116142.Value;
                    NewField1116143.CalcValue = NewField1116143.Value;
                    NewField1116144.CalcValue = NewField1116144.Value;
                    NewField1116145.CalcValue = NewField1116145.Value;
                    NewField1116146.CalcValue = NewField1116146.Value;
                    NewField1116147.CalcValue = NewField1116147.Value;
                    NewField1116148.CalcValue = NewField1116148.Value;
                    ALISKANLIKLAR.CalcValue = @"";
                    SIGARA.CalcValue = @"";
                    ALKOL.CalcValue = @"";
                    MADDE.CalcValue = @"";
                    DIGER_ALISKANLIK.CalcValue = @"";
                    KANGRUBU.CalcValue = @"";
                    KAN_TRANFUZYONU.CalcValue = @"";
                    KAN_TRANFUZYON_REAKSIYON.CalcValue = @"";
                    NewField18416111.CalcValue = NewField18416111.Value;
                    ADSOYAD.CalcValue = @"";
                    NewField1122.CalcValue = NewField1122.Value;
                    PROTOKOLNO.CalcValue = @"";
                    NewField11222.CalcValue = NewField11222.Value;
                    NewField13.CalcValue = NewField13.Value;
                    NewField14.CalcValue = NewField14.Value;
                    NewField122.CalcValue = NewField122.Value;
                    NewField133.CalcValue = NewField133.Value;
                    NewField143.CalcValue = NewField143.Value;
                    NewField153.CalcValue = NewField153.Value;
                    NewField163.CalcValue = NewField163.Value;
                    TCID.CalcValue = @"";
                    KLINIK.CalcValue = @"";
                    CINSIYET.CalcValue = @"";
                    YAS.CalcValue = @"";
                    KILO.CalcValue = @"";
                    BOY.CalcValue = @"";
                    TANI.CalcValue = @"";
                    NewField11211.CalcValue = NewField11211.Value;
                    NewField12211.CalcValue = NewField12211.Value;
                    NewField13211.CalcValue = NewField13211.Value;
                    NewField14211.CalcValue = NewField14211.Value;
                    NewField15211.CalcValue = NewField15211.Value;
                    NewField16211.CalcValue = NewField16211.Value;
                    NewField17211.CalcValue = NewField17211.Value;
                    NewField18211.CalcValue = NewField18211.Value;
                    NewField19211.CalcValue = NewField19211.Value;
                    YATIS_TARIHI.CalcValue = @"";
                    YATIS_SAATI.CalcValue = @"";
                    CIKIS_TARIHI.CalcValue = @"";
                    LISAN.CalcValue = @"";
                    EGITIM.CalcValue = @"";
                    MESLEK.CalcValue = @"";
                    MEDENIDURUM.CalcValue = @"";
                    COCUK.CalcValue = @"";
                    ANT.CalcValue = @"";
                    return new TTReportObject[] { NewField1121,NewField11221,NewField11,NewField12,NewField121,NewField131,NewField141,NewField151,NewField161,YARALANMA_SEKLI,REHAB_BILGI,REHAB_TARIHI,REFAKATCI_GEREKSINIMI,REFAKATCI_ADI,REFAKATCI_TEL,GELDIGI_YER,GELIS_SEKLI,NewField1131,NewField11311,YAKINLIK_DER,REFAKATCI_ADR,NewField1161,NewField11611,NewField11612,NewField11613,NewField11614,KRONIK_HASTALIK,BULASICI_HASTALIK,ALERJI_DURUMU,AILESEL_HASTALIK,GECIRILMIS_HASTALIK,NewField141611,YARDIMCI_CIHAZ,NewField1116141,NewField1116142,NewField1116143,NewField1116144,NewField1116145,NewField1116146,NewField1116147,NewField1116148,ALISKANLIKLAR,SIGARA,ALKOL,MADDE,DIGER_ALISKANLIK,KANGRUBU,KAN_TRANFUZYONU,KAN_TRANFUZYON_REAKSIYON,NewField18416111,ADSOYAD,NewField1122,PROTOKOLNO,NewField11222,NewField13,NewField14,NewField122,NewField133,NewField143,NewField153,NewField163,TCID,KLINIK,CINSIYET,YAS,KILO,BOY,TANI,NewField11211,NewField12211,NewField13211,NewField14211,NewField15211,NewField16211,NewField17211,NewField18211,NewField19211,YATIS_TARIHI,YATIS_SAATI,CIKIS_TARIHI,LISAN,EGITIM,MESLEK,MEDENIDURUM,COCUK,ANT};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
                    string sObjectID = ((NursingPatientPreAssessmentForm)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                    NursingPatientPreAssessment preAssessment = (NursingPatientPreAssessment)context.GetObject(new Guid(sObjectID), "NursingPatientPreAssessment");
                    Episode episode = preAssessment.NursingApplication.Episode;
                    SubEpisode subepisode = preAssessment.NursingApplication.SubEpisode;
                    Patient patient = episode.Patient;
                    
                    //NURSINGPATIENTPREASSESSMENT
                    if(preAssessment.ChildCount!=null)
                        this.COCUK.CalcValue = preAssessment.ChildCount.ToString();
                    this.LISAN.CalcValue = preAssessment.PatientLanguage;
                    
                    //HASTA BİLGİLERİ
                      foreach (var item in episode.SubEpisodes)
                    {
                        if (item.CurrentStateDefID != SubEpisode.States.Cancelled)
                        {
                            this.PROTOKOLNO.CalcValue = item.ProtocolNo;
                            //TODO
                            this.KLINIK.CalcValue = item.ResSection.GetMySKRSKlinikler().ADI;
                            break;
                        }
                    }
                    this.ADSOYAD.CalcValue = patient.Name + " " + patient.Surname;
                    this.BOY.CalcValue = preAssessment?.Height?.ToString();
                    this.KILO.CalcValue = preAssessment?.Weight?.ToString();
                    this.TCID.CalcValue = episode.Patient.UniqueRefNo.ToString();
                    this.CINSIYET.CalcValue = episode.Patient.Sex.ADI;
                    this.YAS.CalcValue = episode.Patient.Age.ToString();
                    
                    this.MESLEK.CalcValue = episode.Patient.Occupation?.ADI;
                    this.EGITIM.CalcValue = episode.Patient.EducationStatus?.ADI;
                    this.MEDENIDURUM.CalcValue = episode.Patient.SKRSMaritalStatus?.ADI;
                     if (subepisode.InpatientAdmission != null)
                    {
                        this.YATIS_TARIHI.CalcValue = subepisode.InpatientAdmission.HospitalInPatientDate?.ToShortDateString();
                        this.YATIS_SAATI.CalcValue = subepisode.InpatientAdmission.HospitalInPatientDate?.ToShortTimeString();
                        this.CIKIS_TARIHI.CalcValue = subepisode.InpatientAdmission.HospitalDischargeDate?.ToShortDateString();
                    }

                    
                    //Tıbbi Bilgiler
                    this.TANI.CalcValue = "";
                    int a = preAssessment.NursingApplication.SubEpisode.Diagnosis.Count;
                    for (int i = 0; i < a; i++)
                    {
                        this.TANI.CalcValue = this.TANI.CalcValue + preAssessment.NursingApplication.SubEpisode.Diagnosis[i].Diagnose.Name.ToString() + " ,";
                    }
                    if (preAssessment.NursingApplication.Temperatures.Count > 0)
                    {
                        this.ANT.CalcValue = "Ateş: " + preAssessment.NursingApplication.Temperatures.FirstOrDefault()?.Value.ToString() + " ";
                    }
                    if (preAssessment.NursingApplication.Pulses.Count > 0)
                    {
                        this.ANT.CalcValue = "Nabız: " + preAssessment.NursingApplication.Pulses.FirstOrDefault()?.Value.ToString() + " ";
                    }
                    if (preAssessment.NursingApplication.BloodPressures.Count > 0)
                    {
                        this.ANT.CalcValue = "Tansiyon(Diastolik): " + preAssessment.NursingApplication.BloodPressures.FirstOrDefault()?.Diastolik.ToString()
                                                + " Tansiyon(Sistolik): " + preAssessment.NursingApplication.BloodPressures.FirstOrDefault()?.Sistolik.ToString();
                    }
                          
            //NURSINGPATIENTPREASSESSMENT
                 
                    if (preAssessment.CauseOfInjury == CauseOfInjuryEnum.LongFall)
                        this.YARALANMA_SEKLI.CalcValue = "Yüksekten Düşme";
                    else if (preAssessment.CauseOfInjury == CauseOfInjuryEnum.DivingInToShallowWater)
                        this.YARALANMA_SEKLI.CalcValue = "Sığ Suya Dalma";
                    else if (preAssessment.CauseOfInjury == CauseOfInjuryEnum.VehicleCrash)
                        this.YARALANMA_SEKLI.CalcValue = "Araç İçi Trafik Kazası";
                    else if (preAssessment.CauseOfInjury == CauseOfInjuryEnum.TarfficAccidentOutSideCar)
                        this.YARALANMA_SEKLI.CalcValue = "Araç Dışı Trafik Kazası";
                    else if (preAssessment.CauseOfInjury == CauseOfInjuryEnum.ASY)
                        this.YARALANMA_SEKLI.CalcValue = "ASY";
                    else if (preAssessment.CauseOfInjury == CauseOfInjuryEnum.Other)
                        this.YARALANMA_SEKLI.CalcValue = "Diğer";

                     if (preAssessment.RehabHistory == YesNoEnum.Yes)
                        this.REHAB_BILGI.CalcValue = "Evet";
                    else 
                        this.REHAB_BILGI.CalcValue = "Hayır";

                    if (preAssessment.LastRehabDate != null)
                        this.REHAB_TARIHI.CalcValue = preAssessment.LastRehabDate.Value.ToShortDateString();

                    this.GELDIGI_YER.CalcValue = preAssessment.WhereThePatientCameFrom;

                    if (preAssessment.TheWayThePatientArrive == TheWayThePatientArriveEnum.ByWalking)
                        this.GELIS_SEKLI.CalcValue = "Yürüyerek";
                    else if (preAssessment.TheWayThePatientArrive == TheWayThePatientArriveEnum.Stretcher)
                        this.GELIS_SEKLI.CalcValue = "Sedye";
                    else if (preAssessment.TheWayThePatientArrive == TheWayThePatientArriveEnum.DisabledChair)
                        this.GELIS_SEKLI.CalcValue = "Tekerlekli sandalye";

                    if (preAssessment.HereditaryDiseases != null || preAssessment.HereditaryDiseases != "")
                        this.AILESEL_HASTALIK.CalcValue = preAssessment.HereditaryDiseases;
                    else
                        this.AILESEL_HASTALIK.CalcValue = "Yok";

                    if (preAssessment.PastIllnessesAndOperations != null || preAssessment.PastIllnessesAndOperations != "")
                        this.GECIRILMIS_HASTALIK.CalcValue = preAssessment.PastIllnessesAndOperations;
                    else
                        this.GECIRILMIS_HASTALIK.CalcValue = "Yok";

                    if (preAssessment.AssistiveDevices != null || preAssessment.AssistiveDevices != "")
                        this.YARDIMCI_CIHAZ.CalcValue = preAssessment.AssistiveDevices;
                    else
                        this.YARDIMCI_CIHAZ.CalcValue = "Yok";

                    if (preAssessment.BloodTransfusionPracticed == YesNoEnum.Yes)
                        this.KAN_TRANFUZYONU.CalcValue = "Evet";
                    else if (preAssessment.BloodTransfusionPracticed == YesNoEnum.No)
                        this.KAN_TRANFUZYONU.CalcValue = "Hayır";

                    if (preAssessment.BloodTransfusionReaction != null || preAssessment.BloodTransfusionReaction != "")
                        this.KAN_TRANFUZYON_REAKSIYON.CalcValue = preAssessment.BloodTransfusionReaction;
                    else
                        this.KAN_TRANFUZYON_REAKSIYON.CalcValue = "Hayır";

                    //HASTA BİLGİLERİ
                  
                    this.KANGRUBU.CalcValue = episode.Patient.BloodGroupType?.ADI;

                    //Refakatçi Bilgileri
                    List<InpatientAdmission> inpatientAdmissionList = new List<InpatientAdmission>();
                    inpatientAdmissionList = episode.InpatientAdmissions.OrderByDescending(t => t.RequestDate).ToList();
                    if (inpatientAdmissionList.Count > 0)
                    {
                        if (inpatientAdmissionList[0].MedulaRefakatciDurumu == true)
                            this.REFAKATCI_GEREKSINIMI.CalcValue = "VAR";
                    }


                    List<CompanionApplication> companionApplicationList = new List<CompanionApplication>();
                    companionApplicationList = episode.CompanionApplications.OrderByDescending(t => t.RequestDate).ToList();
                    if (companionApplicationList.Count > 0)
                    {
                        this.REFAKATCI_ADI.CalcValue = companionApplicationList[0].CompanionName;
                        this.REFAKATCI_TEL.CalcValue = episode.Patient.PatientAddress.RelativeMobilePhone;
                        this.REFAKATCI_ADR.CalcValue = companionApplicationList[0].CompanionAddress;
                        this.YAKINLIK_DER.CalcValue = companionApplicationList[0].Relationship.ToString();
                    }
                    
                    if (episode.Patient.MedicalInformation != null)
                    {
                        this.KRONIK_HASTALIK.CalcValue = episode.Patient.MedicalInformation.ChronicDiseases;
                        if (episode.Patient.MedicalInformation.HasAllergy == VarYokGarantiEnum.V)
                            this.ALERJI_DURUMU.CalcValue = episode.Patient.MedicalInformation.MedicalInfoAllergies.ToString();
                        else
                            this.ALERJI_DURUMU.CalcValue = "YOK";
                        if (episode.Patient.MedicalInformation.HasContagiousDisease == VarYokGarantiEnum.V)
                            this.BULASICI_HASTALIK.CalcValue = episode.Patient.MedicalInformation.ContagiousDisease;
                        else
                            this.BULASICI_HASTALIK.CalcValue = "YOK";
                        if (episode.Patient.MedicalInformation.MedicalInfoHabits.Cigarette == true)
                            this.SIGARA.CalcValue = episode.Patient.MedicalInformation.MedicalInfoHabits.CigaretteUsageFrequency.ADI;
                        else
                            this.SIGARA.CalcValue = "KULLANMIYOR";
                        if (episode.Patient.MedicalInformation.MedicalInfoHabits.Alcohol == true)
                            this.ALKOL.CalcValue = episode.Patient.MedicalInformation.MedicalInfoHabits.AlcoholUsageFrequency.ADI;
                        else
                            this.ALKOL.CalcValue = "KULLANMIYOR";
                        if (episode.Patient.MedicalInformation.MedicalInfoHabits.Drug == true)
                            this.MADDE.CalcValue = episode.Patient.MedicalInformation.MedicalInfoHabits.DrugUsageFrequency.ADI;
                        else
                            this.MADDE.CalcValue = "KULLANMIYOR";
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

        public NursingPatientPreAssessmentForm()
        {
            HEADER = new HEADERGroup(this,"HEADER");
            MAIN = new MAINGroup(HEADER,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Hemşirelik İşlemi", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "NURSINGPATIENTPREASSESSMENTFORM";
            Caption = "Hemşirelik Hizmetleri Hasta Ön Değerlendirme Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
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