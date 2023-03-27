
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
    /// Sağlık Kurulu Periyodik Muayene Fişi (Çift Sayfa)
    /// </summary>
    public partial class HCPeriodicExaminationSlipReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue("");
        }

        public partial class arkasayfaGroup : TTReportGroup
        {
            public HCPeriodicExaminationSlipReport MyParentReport
            {
                get { return (HCPeriodicExaminationSlipReport)ParentReport; }
            }

            new public arkasayfaGroupHeader Header()
            {
                return (arkasayfaGroupHeader)_header;
            }

            new public arkasayfaGroupFooter Footer()
            {
                return (arkasayfaGroupFooter)_footer;
            }

            public TTReportField PERMUAYENE103101 { get {return Footer().PERMUAYENE103101;} }
            public TTReportField LABEL1 { get {return Footer().LABEL1;} }
            public TTReportField LABEL2 { get {return Footer().LABEL2;} }
            public TTReportField FIELD1003 { get {return Footer().FIELD1003;} }
            public TTReportField FIELD1004 { get {return Footer().FIELD1004;} }
            public TTReportField FIELD1005 { get {return Footer().FIELD1005;} }
            public TTReportField PERMUAYENE103102 { get {return Footer().PERMUAYENE103102;} }
            public TTReportField FIELD1006 { get {return Footer().FIELD1006;} }
            public TTReportField FIELD1007 { get {return Footer().FIELD1007;} }
            public TTReportField FIELD1008 { get {return Footer().FIELD1008;} }
            public TTReportField FIELD1009 { get {return Footer().FIELD1009;} }
            public TTReportField FIELD1010 { get {return Footer().FIELD1010;} }
            public TTReportField FIELD1011 { get {return Footer().FIELD1011;} }
            public TTReportField FIELD1012 { get {return Footer().FIELD1012;} }
            public TTReportField FIELD1013 { get {return Footer().FIELD1013;} }
            public TTReportField FIELD1014 { get {return Footer().FIELD1014;} }
            public TTReportField FIELD1015 { get {return Footer().FIELD1015;} }
            public TTReportField FIELD1016 { get {return Footer().FIELD1016;} }
            public TTReportField TESHIS { get {return Footer().TESHIS;} }
            public TTReportField KARAR { get {return Footer().KARAR;} }
            public TTReportField FIELD1019 { get {return Footer().FIELD1019;} }
            public TTReportField FIELD1020 { get {return Footer().FIELD1020;} }
            public TTReportField FIELD1021 { get {return Footer().FIELD1021;} }
            public TTReportField FIELD1022 { get {return Footer().FIELD1022;} }
            public TTReportField FIELD1023 { get {return Footer().FIELD1023;} }
            public TTReportField FIELD1024 { get {return Footer().FIELD1024;} }
            public TTReportField FIELD1025 { get {return Footer().FIELD1025;} }
            public TTReportField BASTABIP { get {return Footer().BASTABIP;} }
            public TTReportField FIELD1026 { get {return Footer().FIELD1026;} }
            public TTReportField FIELD1027 { get {return Footer().FIELD1027;} }
            public TTReportField FIELD1028 { get {return Footer().FIELD1028;} }
            public TTReportField FIELD1029 { get {return Footer().FIELD1029;} }
            public TTReportField FIELD1030 { get {return Footer().FIELD1030;} }
            public TTReportField FIELD1031 { get {return Footer().FIELD1031;} }
            public TTReportField FIELD1032 { get {return Footer().FIELD1032;} }
            public TTReportField FIELD1033 { get {return Footer().FIELD1033;} }
            public TTReportField FIELD1034 { get {return Footer().FIELD1034;} }
            public TTReportField FIELD1035 { get {return Footer().FIELD1035;} }
            public TTReportField NewField40 { get {return Footer().NewField40;} }
            public TTReportField NewField41 { get {return Footer().NewField41;} }
            public TTReportField NewField42 { get {return Footer().NewField42;} }
            public TTReportField NewField43 { get {return Footer().NewField43;} }
            public TTReportField ADSOYAD1 { get {return Footer().ADSOYAD1;} }
            public TTReportField SINIFRUT1 { get {return Footer().SINIFRUT1;} }
            public TTReportField TITLE1 { get {return Footer().TITLE1;} }
            public arkasayfaGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public arkasayfaGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new arkasayfaGroupHeader(this);
                _footer = new arkasayfaGroupFooter(this);

            }

            public partial class arkasayfaGroupHeader : TTReportSection
            {
                public HCPeriodicExaminationSlipReport MyParentReport
                {
                    get { return (HCPeriodicExaminationSlipReport)ParentReport; }
                }
                 
                public arkasayfaGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }
            public partial class arkasayfaGroupFooter : TTReportSection
            {
                public HCPeriodicExaminationSlipReport MyParentReport
                {
                    get { return (HCPeriodicExaminationSlipReport)ParentReport; }
                }
                
                public TTReportField PERMUAYENE103101;
                public TTReportField LABEL1;
                public TTReportField LABEL2;
                public TTReportField FIELD1003;
                public TTReportField FIELD1004;
                public TTReportField FIELD1005;
                public TTReportField PERMUAYENE103102;
                public TTReportField FIELD1006;
                public TTReportField FIELD1007;
                public TTReportField FIELD1008;
                public TTReportField FIELD1009;
                public TTReportField FIELD1010;
                public TTReportField FIELD1011;
                public TTReportField FIELD1012;
                public TTReportField FIELD1013;
                public TTReportField FIELD1014;
                public TTReportField FIELD1015;
                public TTReportField FIELD1016;
                public TTReportField TESHIS;
                public TTReportField KARAR;
                public TTReportField FIELD1019;
                public TTReportField FIELD1020;
                public TTReportField FIELD1021;
                public TTReportField FIELD1022;
                public TTReportField FIELD1023;
                public TTReportField FIELD1024;
                public TTReportField FIELD1025;
                public TTReportField BASTABIP;
                public TTReportField FIELD1026;
                public TTReportField FIELD1027;
                public TTReportField FIELD1028;
                public TTReportField FIELD1029;
                public TTReportField FIELD1030;
                public TTReportField FIELD1031;
                public TTReportField FIELD1032;
                public TTReportField FIELD1033;
                public TTReportField FIELD1034;
                public TTReportField FIELD1035;
                public TTReportField NewField40;
                public TTReportField NewField41;
                public TTReportField NewField42;
                public TTReportField NewField43;
                public TTReportField ADSOYAD1;
                public TTReportField SINIFRUT1;
                public TTReportField TITLE1; 
                public arkasayfaGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 265;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PERMUAYENE103101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 48, 108, 97, false);
                    PERMUAYENE103101.Name = "PERMUAYENE103101";
                    PERMUAYENE103101.DrawStyle = DrawStyleConstants.vbSolid;
                    PERMUAYENE103101.FillStyle = FillStyleConstants.vbFSTransparent;
                    PERMUAYENE103101.MultiLine = EvetHayirEnum.ehEvet;
                    PERMUAYENE103101.WordBreak = EvetHayirEnum.ehEvet;
                    PERMUAYENE103101.TextFont.Name = "Arial";
                    PERMUAYENE103101.Value = @"";

                    LABEL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 22, 187, 35, false);
                    LABEL1.Name = "LABEL1";
                    LABEL1.DrawStyle = DrawStyleConstants.vbSolid;
                    LABEL1.FillStyle = FillStyleConstants.vbFSTransparent;
                    LABEL1.MultiLine = EvetHayirEnum.ehEvet;
                    LABEL1.TextFont.Name = "Arial";
                    LABEL1.Value = @"PA AKCİĞER GRAFİSİ";

                    LABEL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 97, 108, 127, false);
                    LABEL2.Name = "LABEL2";
                    LABEL2.DrawStyle = DrawStyleConstants.vbSolid;
                    LABEL2.FillStyle = FillStyleConstants.vbFSTransparent;
                    LABEL2.MultiLine = EvetHayirEnum.ehEvet;
                    LABEL2.TextFont.Name = "Arial";
                    LABEL2.Value = @"EKG";

                    FIELD1003 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 6, 43, 10, false);
                    FIELD1003.Name = "FIELD1003";
                    FIELD1003.Visible = EvetHayirEnum.ehHayir;
                    FIELD1003.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1003.TextFont.Name = "Arial";
                    FIELD1003.TextFont.Bold = true;
                    FIELD1003.TextFont.Underline = true;
                    FIELD1003.Value = @"HİZMETE ÖZEL";

                    FIELD1004 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 12, 187, 16, false);
                    FIELD1004.Name = "FIELD1004";
                    FIELD1004.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1004.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FIELD1004.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1004.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1004.TextFont.Name = "Arial";
                    FIELD1004.TextFont.Bold = true;
                    FIELD1004.Value = @"LABORATUVAR TETKİK VE SONUÇLARI";

                    FIELD1005 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 35, 187, 48, false);
                    FIELD1005.Name = "FIELD1005";
                    FIELD1005.DrawStyle = DrawStyleConstants.vbSolid;
                    FIELD1005.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1005.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1005.TextFont.Name = "Arial";
                    FIELD1005.Value = @"DÜSG";

                    PERMUAYENE103102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 48, 187, 97, false);
                    PERMUAYENE103102.Name = "PERMUAYENE103102";
                    PERMUAYENE103102.DrawStyle = DrawStyleConstants.vbSolid;
                    PERMUAYENE103102.FillStyle = FillStyleConstants.vbFSTransparent;
                    PERMUAYENE103102.MultiLine = EvetHayirEnum.ehEvet;
                    PERMUAYENE103102.WordBreak = EvetHayirEnum.ehEvet;
                    PERMUAYENE103102.TextFont.Name = "Arial";
                    PERMUAYENE103102.Value = @"Sedimantasyon";

                    FIELD1006 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 49, 38, 53, false);
                    FIELD1006.Name = "FIELD1006";
                    FIELD1006.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1006.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1006.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1006.TextFont.Name = "Arial";
                    FIELD1006.Value = @"Kan Şekeri";

                    FIELD1007 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 53, 38, 57, false);
                    FIELD1007.Name = "FIELD1007";
                    FIELD1007.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1007.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1007.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1007.TextFont.Name = "Arial";
                    FIELD1007.Value = @"Üre";

                    FIELD1008 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 57, 38, 61, false);
                    FIELD1008.Name = "FIELD1008";
                    FIELD1008.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1008.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1008.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1008.TextFont.Name = "Arial";
                    FIELD1008.Value = @"Keratinin";

                    FIELD1009 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 61, 38, 65, false);
                    FIELD1009.Name = "FIELD1009";
                    FIELD1009.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1009.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1009.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1009.TextFont.Name = "Arial";
                    FIELD1009.Value = @"SGOT";

                    FIELD1010 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 65, 38, 69, false);
                    FIELD1010.Name = "FIELD1010";
                    FIELD1010.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1010.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1010.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1010.TextFont.Name = "Arial";
                    FIELD1010.Value = @"GSPT";

                    FIELD1011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 69, 38, 74, false);
                    FIELD1011.Name = "FIELD1011";
                    FIELD1011.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1011.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1011.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1011.TextFont.Name = "Arial";
                    FIELD1011.Value = @"Trigliserit";

                    FIELD1012 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 73, 66, 77, false);
                    FIELD1012.Name = "FIELD1012";
                    FIELD1012.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1012.TextFont.Name = "Arial";
                    FIELD1012.Value = @"Total, HDL ve LDL Kolesterol";

                    FIELD1013 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 77, 46, 81, false);
                    FIELD1013.Name = "FIELD1013";
                    FIELD1013.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1013.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1013.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1013.TextFont.Name = "Arial";
                    FIELD1013.Value = @"Alkalen Fosfataz";

                    FIELD1014 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 81, 38, 86, false);
                    FIELD1014.Name = "FIELD1014";
                    FIELD1014.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1014.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1014.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1014.TextFont.Name = "Arial";
                    FIELD1014.Value = @"HBsAg";

                    FIELD1015 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 60, 128, 66, false);
                    FIELD1015.Name = "FIELD1015";
                    FIELD1015.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1015.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1015.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1015.TextFont.Name = "Arial";
                    FIELD1015.Value = @"TAM KAN";

                    FIELD1016 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 145, 187, 165, false);
                    FIELD1016.Name = "FIELD1016";
                    FIELD1016.DrawStyle = DrawStyleConstants.vbSolid;
                    FIELD1016.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1016.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1016.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1016.TextFont.Name = "Arial";
                    FIELD1016.Value = @"LÜZUM GÖRÜLEN 































DİĞER LABORATUVAR TETKİKLERİ";

                    TESHIS = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 165, 187, 184, false);
                    TESHIS.Name = "TESHIS";
                    TESHIS.DrawStyle = DrawStyleConstants.vbSolid;
                    TESHIS.FillStyle = FillStyleConstants.vbFSTransparent;
                    TESHIS.MultiLine = EvetHayirEnum.ehEvet;
                    TESHIS.WordBreak = EvetHayirEnum.ehEvet;
                    TESHIS.TextFont.Name = "Arial";
                    TESHIS.TextFont.Size = 8;
                    TESHIS.TextFont.Bold = true;
                    TESHIS.Value = @"TEŞHİS";

                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 184, 187, 203, false);
                    KARAR.Name = "KARAR";
                    KARAR.DrawStyle = DrawStyleConstants.vbSolid;
                    KARAR.FillStyle = FillStyleConstants.vbFSTransparent;
                    KARAR.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR.TextFont.Name = "Arial";
                    KARAR.TextFont.Size = 8;
                    KARAR.TextFont.Bold = true;
                    KARAR.Value = @"KARAR";

                    FIELD1019 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 97, 187, 127, false);
                    FIELD1019.Name = "FIELD1019";
                    FIELD1019.DrawStyle = DrawStyleConstants.vbSolid;
                    FIELD1019.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1019.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1019.TextFont.Name = "Arial";
                    FIELD1019.Value = @"TAM İDRAR";

                    FIELD1020 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 206, 37, 211, false);
                    FIELD1020.Name = "FIELD1020";
                    FIELD1020.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1020.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1020.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1020.TextFont.Name = "Arial";
                    FIELD1020.Value = @"İMZA";

                    FIELD1021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 206, 87, 211, false);
                    FIELD1021.Name = "FIELD1021";
                    FIELD1021.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1021.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1021.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1021.TextFont.Name = "Arial";
                    FIELD1021.Value = @"İMZA";

                    FIELD1022 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 117, 206, 137, 211, false);
                    FIELD1022.Name = "FIELD1022";
                    FIELD1022.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1022.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1022.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1022.TextFont.Name = "Arial";
                    FIELD1022.Value = @"İMZA";

                    FIELD1023 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 206, 187, 211, false);
                    FIELD1023.Name = "FIELD1023";
                    FIELD1023.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1023.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1023.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1023.TextFont.Name = "Arial";
                    FIELD1023.Value = @"İMZA";

                    FIELD1024 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 260, 43, 264, false);
                    FIELD1024.Name = "FIELD1024";
                    FIELD1024.Visible = EvetHayirEnum.ehHayir;
                    FIELD1024.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1024.TextFont.Name = "Arial";
                    FIELD1024.TextFont.Bold = true;
                    FIELD1024.TextFont.Underline = true;
                    FIELD1024.Value = @"HİZMETE ÖZEL";

                    FIELD1025 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 233, 105, 242, false);
                    FIELD1025.Name = "FIELD1025";
                    FIELD1025.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1025.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1025.TextFont.Name = "Arial";
                    FIELD1025.Value = @"ONAY
BAŞTABİP";

                    BASTABIP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 93, 243, 142, 260, false);
                    BASTABIP.Name = "BASTABIP";
                    BASTABIP.FillStyle = FillStyleConstants.vbFSTransparent;
                    BASTABIP.FieldType = ReportFieldTypeEnum.ftVariable;
                    BASTABIP.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BASTABIP.MultiLine = EvetHayirEnum.ehEvet;
                    BASTABIP.WordBreak = EvetHayirEnum.ehEvet;
                    BASTABIP.TextFont.Name = "Arial";
                    BASTABIP.Value = @"";

                    FIELD1026 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 49, 87, 53, false);
                    FIELD1026.Name = "FIELD1026";
                    FIELD1026.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1026.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1026.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1026.TextFont.Name = "Arial";
                    FIELD1026.Value = @":";

                    FIELD1027 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 53, 87, 57, false);
                    FIELD1027.Name = "FIELD1027";
                    FIELD1027.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1027.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1027.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1027.TextFont.Name = "Arial";
                    FIELD1027.Value = @":";

                    FIELD1028 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 57, 87, 61, false);
                    FIELD1028.Name = "FIELD1028";
                    FIELD1028.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1028.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1028.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1028.TextFont.Name = "Arial";
                    FIELD1028.Value = @":";

                    FIELD1029 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 61, 87, 65, false);
                    FIELD1029.Name = "FIELD1029";
                    FIELD1029.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1029.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1029.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1029.TextFont.Name = "Arial";
                    FIELD1029.Value = @":";

                    FIELD1030 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 65, 87, 69, false);
                    FIELD1030.Name = "FIELD1030";
                    FIELD1030.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1030.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1030.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1030.TextFont.Name = "Arial";
                    FIELD1030.Value = @":";

                    FIELD1031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 69, 87, 74, false);
                    FIELD1031.Name = "FIELD1031";
                    FIELD1031.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1031.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1031.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1031.TextFont.Name = "Arial";
                    FIELD1031.Value = @":";

                    FIELD1032 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 73, 87, 77, false);
                    FIELD1032.Name = "FIELD1032";
                    FIELD1032.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1032.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1032.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1032.TextFont.Name = "Arial";
                    FIELD1032.Value = @":";

                    FIELD1033 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 77, 87, 81, false);
                    FIELD1033.Name = "FIELD1033";
                    FIELD1033.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1033.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1033.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1033.TextFont.Name = "Arial";
                    FIELD1033.Value = @":";

                    FIELD1034 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 81, 87, 86, false);
                    FIELD1034.Name = "FIELD1034";
                    FIELD1034.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1034.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1034.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1034.TextFont.Name = "Arial";
                    FIELD1034.Value = @":";

                    FIELD1035 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 49, 97, 69, 102, false);
                    FIELD1035.Name = "FIELD1035";
                    FIELD1035.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1035.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1035.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1035.TextFont.Name = "Arial";
                    FIELD1035.Value = @":";

                    NewField40 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 85, 62, 95, false);
                    NewField40.Name = "NewField40";
                    NewField40.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField40.MultiLine = EvetHayirEnum.ehEvet;
                    NewField40.WordBreak = EvetHayirEnum.ehEvet;
                    NewField40.TextFont.Name = "Arial";
                    NewField40.Value = @"Gaitada Gizli Kan (45 yaş üstü tüm personel için)";

                    NewField41 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 67, 85, 87, 91, false);
                    NewField41.Name = "NewField41";
                    NewField41.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField41.MultiLine = EvetHayirEnum.ehEvet;
                    NewField41.WordBreak = EvetHayirEnum.ehEvet;
                    NewField41.TextFont.Name = "Arial";
                    NewField41.Value = @":";

                    NewField42 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 127, 108, 145, false);
                    NewField42.Name = "NewField42";
                    NewField42.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField42.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField42.MultiLine = EvetHayirEnum.ehEvet;
                    NewField42.WordBreak = EvetHayirEnum.ehEvet;
                    NewField42.TextFont.Name = "Arial";
                    NewField42.Value = @"45 yaş üstü erkek personel için tüm batın ultrasonografisi, PSA ";

                    NewField43 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 127, 187, 145, false);
                    NewField43.Name = "NewField43";
                    NewField43.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField43.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField43.MultiLine = EvetHayirEnum.ehEvet;
                    NewField43.WordBreak = EvetHayirEnum.ehEvet;
                    NewField43.TextFont.Name = "Arial";
                    NewField43.Value = @"45 yaş üstü bayan personel için PAP smear, Mamografi (yoksa meme ultrasonografisi)";

                    ADSOYAD1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 243, 158, 247, false);
                    ADSOYAD1.Name = "ADSOYAD1";
                    ADSOYAD1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD1.TextFont.Name = "Arial Narrow";
                    ADSOYAD1.TextFont.Size = 9;
                    ADSOYAD1.Value = @"";

                    SINIFRUT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 247, 158, 251, false);
                    SINIFRUT1.Name = "SINIFRUT1";
                    SINIFRUT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINIFRUT1.TextFont.Name = "Arial Narrow";
                    SINIFRUT1.TextFont.Size = 9;
                    SINIFRUT1.Value = @"";

                    TITLE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 85, 251, 158, 255, false);
                    TITLE1.Name = "TITLE1";
                    TITLE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    TITLE1.TextFont.Name = "Arial Narrow";
                    TITLE1.TextFont.Size = 9;
                    TITLE1.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PERMUAYENE103101.CalcValue = PERMUAYENE103101.Value;
                    LABEL1.CalcValue = LABEL1.Value;
                    LABEL2.CalcValue = LABEL2.Value;
                    FIELD1003.CalcValue = FIELD1003.Value;
                    FIELD1004.CalcValue = FIELD1004.Value;
                    FIELD1005.CalcValue = FIELD1005.Value;
                    PERMUAYENE103102.CalcValue = PERMUAYENE103102.Value;
                    FIELD1006.CalcValue = FIELD1006.Value;
                    FIELD1007.CalcValue = FIELD1007.Value;
                    FIELD1008.CalcValue = FIELD1008.Value;
                    FIELD1009.CalcValue = FIELD1009.Value;
                    FIELD1010.CalcValue = FIELD1010.Value;
                    FIELD1011.CalcValue = FIELD1011.Value;
                    FIELD1012.CalcValue = FIELD1012.Value;
                    FIELD1013.CalcValue = FIELD1013.Value;
                    FIELD1014.CalcValue = FIELD1014.Value;
                    FIELD1015.CalcValue = FIELD1015.Value;
                    FIELD1016.CalcValue = FIELD1016.Value;
                    TESHIS.CalcValue = TESHIS.Value;
                    KARAR.CalcValue = KARAR.Value;
                    FIELD1019.CalcValue = FIELD1019.Value;
                    FIELD1020.CalcValue = FIELD1020.Value;
                    FIELD1021.CalcValue = FIELD1021.Value;
                    FIELD1022.CalcValue = FIELD1022.Value;
                    FIELD1023.CalcValue = FIELD1023.Value;
                    FIELD1024.CalcValue = FIELD1024.Value;
                    FIELD1025.CalcValue = FIELD1025.Value;
                    BASTABIP.CalcValue = @"";
                    FIELD1026.CalcValue = FIELD1026.Value;
                    FIELD1027.CalcValue = FIELD1027.Value;
                    FIELD1028.CalcValue = FIELD1028.Value;
                    FIELD1029.CalcValue = FIELD1029.Value;
                    FIELD1030.CalcValue = FIELD1030.Value;
                    FIELD1031.CalcValue = FIELD1031.Value;
                    FIELD1032.CalcValue = FIELD1032.Value;
                    FIELD1033.CalcValue = FIELD1033.Value;
                    FIELD1034.CalcValue = FIELD1034.Value;
                    FIELD1035.CalcValue = FIELD1035.Value;
                    NewField40.CalcValue = NewField40.Value;
                    NewField41.CalcValue = NewField41.Value;
                    NewField42.CalcValue = NewField42.Value;
                    NewField43.CalcValue = NewField43.Value;
                    ADSOYAD1.CalcValue = @"";
                    SINIFRUT1.CalcValue = @"";
                    TITLE1.CalcValue = @"";
                    return new TTReportObject[] { PERMUAYENE103101,LABEL1,LABEL2,FIELD1003,FIELD1004,FIELD1005,PERMUAYENE103102,FIELD1006,FIELD1007,FIELD1008,FIELD1009,FIELD1010,FIELD1011,FIELD1012,FIELD1013,FIELD1014,FIELD1015,FIELD1016,TESHIS,KARAR,FIELD1019,FIELD1020,FIELD1021,FIELD1022,FIELD1023,FIELD1024,FIELD1025,BASTABIP,FIELD1026,FIELD1027,FIELD1028,FIELD1029,FIELD1030,FIELD1031,FIELD1032,FIELD1033,FIELD1034,FIELD1035,NewField40,NewField41,NewField42,NewField43,ADSOYAD1,SINIFRUT1,TITLE1};
                }

                public override void RunScript()
                {
#region ARKASAYFA FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string approveUserObjectID = TTObjectClasses.SystemParameter.GetParameterValue("HCPERIODICEXAMSLIPREPORTAPPROVEUSER_OBJECTID", "");

            if (Globals.IsGuid(approveUserObjectID))
            {
                ResUser head = (ResUser)context.GetObject(new Guid(approveUserObjectID), "ResUser");

                this.ADSOYAD1.CalcValue = head.Name;
                string sRank = head.Rank != null ? head.Rank.ShortName : "";
                string sTitle = head.Title.HasValue ? TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(head.Title.Value) : "";
                this.SINIFRUT1.CalcValue = sTitle + sRank;
                this.TITLE1.CalcValue = "(" + head.EmploymentRecordID + ")";
            }
            else
            {
                this.FIELD1025.Visible = EvetHayirEnum.ehHayir;
                this.ADSOYAD1.Visible = EvetHayirEnum.ehHayir;
                this.SINIFRUT1.Visible = EvetHayirEnum.ehHayir;
                this.TITLE1.Visible = EvetHayirEnum.ehHayir;
            }
            
            /*
            string sObjectID = ((HealthCommitteeReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");

            if(hc == null)
                throw new Exception("Rapor Sağlık Kurulu işlemi üzerinden alınmalıdır.\r\nReason: HealthCommittee is null");

            this.KARAR.CalcValue = TTObjectClasses.Common.GetTextOfRTFString(hc.Decision);

            //Tanı
            int nCount = 1;
            this.TESHIS.CalcValue = "";
            BindingList<DiagnosisGrid.GetDiagnosisByParent_Class> pDiagnosis = DiagnosisGrid.GetDiagnosisByParent(sObjectID);
            foreach(DiagnosisGrid.GetDiagnosisByParent_Class pGrid in pDiagnosis)
            {
                this.TESHIS.CalcValue += nCount.ToString() + "- " + pGrid.Tanikodu + " " + pGrid.Taniadi;
                this.TESHIS.CalcValue += "\r\n";
                nCount++;
            }
             */
#endregion ARKASAYFA FOOTER_Script
                }
            }

        }

        public arkasayfaGroup arkasayfa;

        public partial class MAINGroup : TTReportGroup
        {
            public HCPeriodicExaminationSlipReport MyParentReport
            {
                get { return (HCPeriodicExaminationSlipReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NAME { get {return Body().NAME;} }
            public TTReportField EMIRTARNO { get {return Body().EMIRTARNO;} }
            public TTReportField MAKAM { get {return Body().MAKAM;} }
            public TTReportField FOTO { get {return Body().FOTO;} }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField PERMUAYENE103103 { get {return Body().PERMUAYENE103103;} }
            public TTReportField NewField300 { get {return Body().NewField300;} }
            public TTReportField FIELD1036 { get {return Body().FIELD1036;} }
            public TTReportField NAMESURNAME { get {return Body().NAMESURNAME;} }
            public TTReportField NewField302 { get {return Body().NewField302;} }
            public TTReportField NewField303 { get {return Body().NewField303;} }
            public TTReportField NewField304 { get {return Body().NewField304;} }
            public TTReportField NewField305 { get {return Body().NewField305;} }
            public TTReportShape shape1 { get {return Body().shape1;} }
            public TTReportField FIELD1037 { get {return Body().FIELD1037;} }
            public TTReportField FIELD1038 { get {return Body().FIELD1038;} }
            public TTReportField FIELD1039 { get {return Body().FIELD1039;} }
            public TTReportField FIELD1041 { get {return Body().FIELD1041;} }
            public TTReportShape shape2 { get {return Body().shape2;} }
            public TTReportField FIELD1042 { get {return Body().FIELD1042;} }
            public TTReportField FIELD1043 { get {return Body().FIELD1043;} }
            public TTReportField HEADER { get {return Body().HEADER;} }
            public TTReportField NewField21 { get {return Body().NewField21;} }
            public TTReportField FIELD1045 { get {return Body().FIELD1045;} }
            public TTReportField FIELD1046 { get {return Body().FIELD1046;} }
            public TTReportField NewField40 { get {return Body().NewField40;} }
            public TTReportField AID { get {return Body().AID;} }
            public TTReportField NewField42 { get {return Body().NewField42;} }
            public TTReportField PID { get {return Body().PID;} }
            public TTReportField NewField44 { get {return Body().NewField44;} }
            public TTReportField NewField451 { get {return Body().NewField451;} }
            public TTReportField NewField452 { get {return Body().NewField452;} }
            public TTReportField FATHERNAME { get {return Body().FATHERNAME;} }
            public TTReportField EMPLOYMENTNO { get {return Body().EMPLOYMENTNO;} }
            public TTReportField BIRTHINFO { get {return Body().BIRTHINFO;} }
            public TTReportField MILITARYUNIT { get {return Body().MILITARYUNIT;} }
            public TTReportField MILCLASSRANK { get {return Body().MILCLASSRANK;} }
            public TTReportField REPORTNUMBERDATE { get {return Body().REPORTNUMBERDATE;} }
            public TTReportField SITENAME { get {return Body().SITENAME;} }
            public TTReportField SITECITY { get {return Body().SITECITY;} }
            public TTReportField XXXXXXBASLIK { get {return Body().XXXXXXBASLIK;} }
            public TTReportField FIELD1044 { get {return Body().FIELD1044;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportField BIRTHDATE { get {return Body().BIRTHDATE;} }
            public TTReportField REPORTDATE { get {return Body().REPORTDATE;} }
            public TTReportField EVRAKTARIHI { get {return Body().EVRAKTARIHI;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportField NewField104 { get {return Body().NewField104;} }
            public TTReportField TCKIMLIKNO { get {return Body().TCKIMLIKNO;} }
            public TTReportShape NewLine3 { get {return Body().NewLine3;} }
            public TTReportShape NewLine4 { get {return Body().NewLine4;} }
            public TTReportShape NewLine14 { get {return Body().NewLine14;} }
            public TTReportShape NewLine13 { get {return Body().NewLine13;} }
            public TTReportShape NewLine5 { get {return Body().NewLine5;} }
            public TTReportShape NewLine6 { get {return Body().NewLine6;} }
            public TTReportShape NewLine7 { get {return Body().NewLine7;} }
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
                list[0] = new TTReportNqlData<HealthCommittee.GetCurrentHealthCommittee_Class>("GetCurrentHealthCommittee", HealthCommittee.GetCurrentHealthCommittee((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public HCPeriodicExaminationSlipReport MyParentReport
                {
                    get { return (HCPeriodicExaminationSlipReport)ParentReport; }
                }
                
                public TTReportField NAME;
                public TTReportField EMIRTARNO;
                public TTReportField MAKAM;
                public TTReportField FOTO;
                public TTReportField NewField1;
                public TTReportField PERMUAYENE103103;
                public TTReportField NewField300;
                public TTReportField FIELD1036;
                public TTReportField NAMESURNAME;
                public TTReportField NewField302;
                public TTReportField NewField303;
                public TTReportField NewField304;
                public TTReportField NewField305;
                public TTReportShape shape1;
                public TTReportField FIELD1037;
                public TTReportField FIELD1038;
                public TTReportField FIELD1039;
                public TTReportField FIELD1041;
                public TTReportShape shape2;
                public TTReportField FIELD1042;
                public TTReportField FIELD1043;
                public TTReportField HEADER;
                public TTReportField NewField21;
                public TTReportField FIELD1045;
                public TTReportField FIELD1046;
                public TTReportField NewField40;
                public TTReportField AID;
                public TTReportField NewField42;
                public TTReportField PID;
                public TTReportField NewField44;
                public TTReportField NewField451;
                public TTReportField NewField452;
                public TTReportField FATHERNAME;
                public TTReportField EMPLOYMENTNO;
                public TTReportField BIRTHINFO;
                public TTReportField MILITARYUNIT;
                public TTReportField MILCLASSRANK;
                public TTReportField REPORTNUMBERDATE;
                public TTReportField SITENAME;
                public TTReportField SITECITY;
                public TTReportField XXXXXXBASLIK;
                public TTReportField FIELD1044;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportField BIRTHDATE;
                public TTReportField REPORTDATE;
                public TTReportField EVRAKTARIHI;
                public TTReportShape NewLine2;
                public TTReportField NewField104;
                public TTReportField TCKIMLIKNO;
                public TTReportShape NewLine3;
                public TTReportShape NewLine4;
                public TTReportShape NewLine14;
                public TTReportShape NewLine13;
                public TTReportShape NewLine5;
                public TTReportShape NewLine6;
                public TTReportShape NewLine7; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 265;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 52, 143, 56, false);
                    NAME.Name = "NAME";
                    NAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    NAME.NoClip = EvetHayirEnum.ehEvet;
                    NAME.TextFont.Name = "Arial";
                    NAME.TextFont.Size = 8;
                    NAME.Value = @"{#PNAME#} {#PSURNAME#}";

                    EMIRTARNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 60, 265, 65, false);
                    EMIRTARNO.Name = "EMIRTARNO";
                    EMIRTARNO.Visible = EvetHayirEnum.ehHayir;
                    EMIRTARNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMIRTARNO.MultiLine = EvetHayirEnum.ehEvet;
                    EMIRTARNO.NoClip = EvetHayirEnum.ehEvet;
                    EMIRTARNO.WordBreak = EvetHayirEnum.ehEvet;
                    EMIRTARNO.TextFont.Name = "Arial";
                    EMIRTARNO.TextFont.Size = 8;
                    EMIRTARNO.Value = @"{#EVRAKSAYISI#}";

                    MAKAM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 92, 186, 100, false);
                    MAKAM.Name = "MAKAM";
                    MAKAM.FieldType = ReportFieldTypeEnum.ftVariable;
                    MAKAM.MultiLine = EvetHayirEnum.ehEvet;
                    MAKAM.NoClip = EvetHayirEnum.ehEvet;
                    MAKAM.WordBreak = EvetHayirEnum.ehEvet;
                    MAKAM.ExpandTabs = EvetHayirEnum.ehEvet;
                    MAKAM.TextFont.Name = "Arial";
                    MAKAM.TextFont.Size = 8;
                    MAKAM.Value = @"{#EVRAKSAYISI#} SAYI VE {%EVRAKTARIHI%} TARİHLİ YAZISI";

                    FOTO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 152, 46, 180, 80, false);
                    FOTO.Name = "FOTO";
                    FOTO.FillStyle = FillStyleConstants.vbFSTransparent;
                    FOTO.FieldType = ReportFieldTypeEnum.ftOLE;
                    FOTO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FOTO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FOTO.ExpandTabs = EvetHayirEnum.ehEvet;
                    FOTO.TextFont.Name = "Arial";
                    FOTO.Value = @"";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 39, 144, 45, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Name = "Arial";
                    NewField1.TextFont.Size = 9;
                    NewField1.TextFont.Bold = true;
                    NewField1.Value = @"RAPOR NU VE TARİHİ";

                    PERMUAYENE103103 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 87, 185, 92, false);
                    PERMUAYENE103103.Name = "PERMUAYENE103103";
                    PERMUAYENE103103.FillStyle = FillStyleConstants.vbFSTransparent;
                    PERMUAYENE103103.MultiLine = EvetHayirEnum.ehEvet;
                    PERMUAYENE103103.WordBreak = EvetHayirEnum.ehEvet;
                    PERMUAYENE103103.TextFont.Name = "Arial";
                    PERMUAYENE103103.TextFont.Size = 9;
                    PERMUAYENE103103.TextFont.Bold = true;
                    PERMUAYENE103103.Value = @"PERİYODİK MUAYENE SEVK EDEN MAKAM,EMİR,TARİH VE SAYISI:";

                    NewField300 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 45, 144, 51, false);
                    NewField300.Name = "NewField300";
                    NewField300.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField300.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField300.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField300.TextFont.Name = "Arial";
                    NewField300.TextFont.Size = 9;
                    NewField300.TextFont.Bold = true;
                    NewField300.Value = @"SINIF VE RÜTBESİ";

                    FIELD1036 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 100, 187, 117, false);
                    FIELD1036.Name = "FIELD1036";
                    FIELD1036.DrawStyle = DrawStyleConstants.vbSolid;
                    FIELD1036.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1036.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1036.TextFont.Name = "Arial";
                    FIELD1036.TextFont.Bold = true;
                    FIELD1036.Value = @"İÇ HASTALIKLARI";

                    NAMESURNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 51, 60, 57, false);
                    NAMESURNAME.Name = "NAMESURNAME";
                    NAMESURNAME.DrawStyle = DrawStyleConstants.vbSolid;
                    NAMESURNAME.FillStyle = FillStyleConstants.vbFSTransparent;
                    NAMESURNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NAMESURNAME.TextFont.Name = "Arial";
                    NAMESURNAME.TextFont.Size = 9;
                    NAMESURNAME.TextFont.Bold = true;
                    NAMESURNAME.Value = @"ADI SOYADI";

                    NewField302 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 57, 144, 63, false);
                    NewField302.Name = "NewField302";
                    NewField302.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField302.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField302.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField302.TextFont.Name = "Arial";
                    NewField302.TextFont.Size = 9;
                    NewField302.TextFont.Bold = true;
                    NewField302.Value = @"BABA ADI";

                    NewField303 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 63, 144, 69, false);
                    NewField303.Name = "NewField303";
                    NewField303.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField303.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField303.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField303.TextFont.Name = "Arial";
                    NewField303.TextFont.Size = 9;
                    NewField303.TextFont.Bold = true;
                    NewField303.Value = @"SİCİL NU";

                    NewField304 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 69, 144, 75, false);
                    NewField304.Name = "NewField304";
                    NewField304.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField304.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField304.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField304.TextFont.Name = "Arial";
                    NewField304.TextFont.Size = 9;
                    NewField304.TextFont.Bold = true;
                    NewField304.Value = @"DOĞUM TARİHİ";

                    NewField305 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 75, 60, 81, false);
                    NewField305.Name = "NewField305";
                    NewField305.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField305.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField305.TextFont.Name = "Arial";
                    NewField305.TextFont.Size = 9;
                    NewField305.TextFont.Bold = true;
                    NewField305.Value = @"BİRLİĞİ";

                    shape1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 60, 39, 60, 87, false);
                    shape1.Name = "shape1";
                    shape1.DrawStyle = DrawStyleConstants.vbSolid;

                    FIELD1037 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 117, 187, 134, false);
                    FIELD1037.Name = "FIELD1037";
                    FIELD1037.DrawStyle = DrawStyleConstants.vbSolid;
                    FIELD1037.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1037.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1037.TextFont.Name = "Arial";
                    FIELD1037.TextFont.Bold = true;
                    FIELD1037.Value = @"GENEL CERRAHİ";

                    FIELD1038 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 134, 187, 152, false);
                    FIELD1038.Name = "FIELD1038";
                    FIELD1038.DrawStyle = DrawStyleConstants.vbSolid;
                    FIELD1038.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1038.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1038.TextFont.Name = "Arial";
                    FIELD1038.TextFont.Bold = true;
                    FIELD1038.Value = @"GÖZ HASTALIKLARI";

                    FIELD1039 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 152, 187, 170, false);
                    FIELD1039.Name = "FIELD1039";
                    FIELD1039.DrawStyle = DrawStyleConstants.vbSolid;
                    FIELD1039.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1039.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1039.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1039.TextFont.Name = "Arial";
                    FIELD1039.TextFont.Bold = true;
                    FIELD1039.Value = @"KULAK BURUN BOĞAZ 
HASTALIKLARI";

                    FIELD1041 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 206, 187, 240, false);
                    FIELD1041.Name = "FIELD1041";
                    FIELD1041.DrawStyle = DrawStyleConstants.vbSolid;
                    FIELD1041.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1041.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1041.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1041.TextFont.Name = "Arial";
                    FIELD1041.TextFont.Bold = true;
                    FIELD1041.Value = @"LÜZUM GÖRÜLEN 
DİĞER































BRANŞLAR(*) (**)";

                    shape2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 60, 100, 60, 240, false);
                    shape2.Name = "shape2";
                    shape2.DrawStyle = DrawStyleConstants.vbSolid;

                    FIELD1042 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 206, 187, 223, false);
                    FIELD1042.Name = "FIELD1042";
                    FIELD1042.DrawStyle = DrawStyleConstants.vbSolid;
                    FIELD1042.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1042.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1042.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1042.TextFont.Name = "Arial";
                    FIELD1042.TextFont.Bold = true;
                    FIELD1042.Value = @"";

                    FIELD1043 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 60, 223, 187, 240, false);
                    FIELD1043.Name = "FIELD1043";
                    FIELD1043.DrawStyle = DrawStyleConstants.vbSolid;
                    FIELD1043.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1043.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1043.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1043.TextFont.Name = "Arial";
                    FIELD1043.TextFont.Bold = true;
                    FIELD1043.Value = @"";

                    HEADER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 28, 278, 48, false);
                    HEADER.Name = "HEADER";
                    HEADER.Visible = EvetHayirEnum.ehHayir;
                    HEADER.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEADER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    HEADER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    HEADER.MultiLine = EvetHayirEnum.ehEvet;
                    HEADER.NoClip = EvetHayirEnum.ehEvet;
                    HEADER.WordBreak = EvetHayirEnum.ehEvet;
                    HEADER.ExpandTabs = EvetHayirEnum.ehEvet;
                    HEADER.TextFont.Name = "Arial";
                    HEADER.TextFont.Size = 12;
                    HEADER.TextFont.Bold = true;
                    HEADER.Value = @"{%MAIN.SITENAME%} {%MAIN.SITECITY%}";

                    NewField21 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 33, 187, 38, false);
                    NewField21.Name = "NewField21";
                    NewField21.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField21.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField21.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField21.TextFont.Name = "Arial";
                    NewField21.TextFont.Bold = true;
                    NewField21.Value = @"PERİYODİK MUAYENE RAPORU";

                    FIELD1045 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 261, 60, 265, false);
                    FIELD1045.Name = "FIELD1045";
                    FIELD1045.Visible = EvetHayirEnum.ehHayir;
                    FIELD1045.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1045.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1045.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1045.TextFont.Name = "Arial";
                    FIELD1045.TextFont.Bold = true;
                    FIELD1045.TextFont.Underline = true;
                    FIELD1045.Value = @"HİZMETE ÖZEL";

                    FIELD1046 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 245, 187, 254, false);
                    FIELD1046.Name = "FIELD1046";
                    FIELD1046.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1046.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1046.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1046.TextFont.Name = "Arial";
                    FIELD1046.TextFont.Size = 8;
                    FIELD1046.Value = @"(*) Özel Kuvvetler ve Komando birliklerinde görevli Komando, Paraşütçü ve Arama Kurtarma İhtisaslı personelin Ortopedi muayenesi buraya yazılır.";

                    NewField40 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 40, 159, 45, false);
                    NewField40.Name = "NewField40";
                    NewField40.TextFont.Name = "Arial Narrow";
                    NewField40.TextFont.Size = 9;
                    NewField40.TextFont.Bold = true;
                    NewField40.Value = @"İşlem Nu";

                    AID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 160, 40, 186, 45, false);
                    AID.Name = "AID";
                    AID.FieldType = ReportFieldTypeEnum.ftVariable;
                    AID.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AID.TextFont.Name = "Arial Narrow";
                    AID.TextFont.Size = 9;
                    AID.Value = @"{#ISLEMNO#}";

                    NewField42 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 89, 227, 94, false);
                    NewField42.Name = "NewField42";
                    NewField42.Visible = EvetHayirEnum.ehHayir;
                    NewField42.TextFont.Name = "Arial Narrow";
                    NewField42.TextFont.Size = 9;
                    NewField42.TextFont.Bold = true;
                    NewField42.Value = @"Hasta Nu";

                    PID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 89, 253, 94, false);
                    PID.Name = "PID";
                    PID.Visible = EvetHayirEnum.ehHayir;
                    PID.FieldType = ReportFieldTypeEnum.ftVariable;
                    PID.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PID.TextFont.Name = "Arial Narrow";
                    PID.Value = @"{#PID#}";

                    NewField44 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 170, 187, 188, false);
                    NewField44.Name = "NewField44";
                    NewField44.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField44.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField44.MultiLine = EvetHayirEnum.ehEvet;
                    NewField44.WordBreak = EvetHayirEnum.ehEvet;
                    NewField44.TextFont.Name = "Arial";
                    NewField44.TextFont.Bold = true;
                    NewField44.Value = @"PSİKİYATRİ";

                    NewField451 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 188, 187, 206, false);
                    NewField451.Name = "NewField451";
                    NewField451.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField451.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField451.MultiLine = EvetHayirEnum.ehEvet;
                    NewField451.WordBreak = EvetHayirEnum.ehEvet;
                    NewField451.TextFont.Name = "Arial";
                    NewField451.TextFont.Bold = true;
                    NewField451.Value = @"DİŞ HASTALIKLARI";

                    NewField452 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 256, 188, 262, false);
                    NewField452.Name = "NewField452";
                    NewField452.FillStyle = FillStyleConstants.vbFSTransparent;
                    NewField452.TextFont.Name = "Arial";
                    NewField452.TextFont.Size = 8;
                    NewField452.Value = @"(**) Uzmanlar muayene esnasında diğer branşları ilgilendiren hastalık ve arıza görürlerse ilgili uzmanın da muayenesini isterler.";

                    FATHERNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 58, 143, 62, false);
                    FATHERNAME.Name = "FATHERNAME";
                    FATHERNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    FATHERNAME.NoClip = EvetHayirEnum.ehEvet;
                    FATHERNAME.TextFont.Name = "Arial";
                    FATHERNAME.TextFont.Size = 8;
                    FATHERNAME.Value = @"{#FATHERNAME#}";

                    EMPLOYMENTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 64, 143, 68, false);
                    EMPLOYMENTNO.Name = "EMPLOYMENTNO";
                    EMPLOYMENTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    EMPLOYMENTNO.NoClip = EvetHayirEnum.ehEvet;
                    EMPLOYMENTNO.TextFont.Name = "Arial";
                    EMPLOYMENTNO.TextFont.Size = 8;
                    EMPLOYMENTNO.Value = @"";

                    BIRTHINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 70, 143, 74, false);
                    BIRTHINFO.Name = "BIRTHINFO";
                    BIRTHINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHINFO.MultiLine = EvetHayirEnum.ehEvet;
                    BIRTHINFO.TextFont.Name = "Arial";
                    BIRTHINFO.TextFont.Size = 8;
                    BIRTHINFO.Value = @"{%BIRTHDATE%} - {#DOGUMYERIILCE#} / {#DOGUMYERI#}";

                    MILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 76, 143, 86, false);
                    MILITARYUNIT.Name = "MILITARYUNIT";
                    MILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARYUNIT.MultiLine = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.NoClip = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.WordBreak = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.ExpandTabs = EvetHayirEnum.ehEvet;
                    MILITARYUNIT.TextFont.Name = "Arial";
                    MILITARYUNIT.TextFont.Size = 8;
                    MILITARYUNIT.Value = @"";

                    MILCLASSRANK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 46, 143, 50, false);
                    MILCLASSRANK.Name = "MILCLASSRANK";
                    MILCLASSRANK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILCLASSRANK.NoClip = EvetHayirEnum.ehEvet;
                    MILCLASSRANK.TextFont.Name = "Arial";
                    MILCLASSRANK.TextFont.Size = 8;
                    MILCLASSRANK.Value = @"";

                    REPORTNUMBERDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 61, 40, 143, 44, false);
                    REPORTNUMBERDATE.Name = "REPORTNUMBERDATE";
                    REPORTNUMBERDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTNUMBERDATE.NoClip = EvetHayirEnum.ehEvet;
                    REPORTNUMBERDATE.TextFont.Name = "Arial";
                    REPORTNUMBERDATE.TextFont.Size = 8;
                    REPORTNUMBERDATE.Value = @"{#RAPORNO#} - {%REPORTDATE%}";

                    SITENAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 14, 242, 19, false);
                    SITENAME.Name = "SITENAME";
                    SITENAME.Visible = EvetHayirEnum.ehHayir;
                    SITENAME.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITENAME.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"",""XXXXXX"")";

                    SITECITY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 217, 20, 242, 25, false);
                    SITECITY.Name = "SITECITY";
                    SITECITY.Visible = EvetHayirEnum.ehHayir;
                    SITECITY.FieldType = ReportFieldTypeEnum.ftExpression;
                    SITECITY.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"",""XXXXXX"")";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 11, 187, 31, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FillStyle = FillStyleConstants.vbFSTransparent;
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    FIELD1044 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 6, 55, 10, false);
                    FIELD1044.Name = "FIELD1044";
                    FIELD1044.Visible = EvetHayirEnum.ehHayir;
                    FIELD1044.FillStyle = FillStyleConstants.vbFSTransparent;
                    FIELD1044.MultiLine = EvetHayirEnum.ehEvet;
                    FIELD1044.WordBreak = EvetHayirEnum.ehEvet;
                    FIELD1044.TextFont.Name = "Arial";
                    FIELD1044.TextFont.Bold = true;
                    FIELD1044.TextFont.Underline = true;
                    FIELD1044.Value = @"HİZMETE ÖZEL";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 73, 17, 101, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 187, 81, 187, 103, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    BIRTHDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 67, 244, 71, false);
                    BIRTHDATE.Name = "BIRTHDATE";
                    BIRTHDATE.Visible = EvetHayirEnum.ehHayir;
                    BIRTHDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    BIRTHDATE.TextFormat = @"Short Date";
                    BIRTHDATE.NoClip = EvetHayirEnum.ehEvet;
                    BIRTHDATE.TextFont.Name = "Arial";
                    BIRTHDATE.TextFont.Size = 8;
                    BIRTHDATE.Value = @"{#DTARIHI#}";

                    REPORTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 73, 244, 77, false);
                    REPORTDATE.Name = "REPORTDATE";
                    REPORTDATE.Visible = EvetHayirEnum.ehHayir;
                    REPORTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTDATE.TextFormat = @"Short Date";
                    REPORTDATE.NoClip = EvetHayirEnum.ehEvet;
                    REPORTDATE.TextFont.Name = "Arial";
                    REPORTDATE.TextFont.Size = 8;
                    REPORTDATE.Value = @"{#RAPORTARIHI#}";

                    EVRAKTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 216, 82, 244, 86, false);
                    EVRAKTARIHI.Name = "EVRAKTARIHI";
                    EVRAKTARIHI.Visible = EvetHayirEnum.ehHayir;
                    EVRAKTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVRAKTARIHI.TextFormat = @"Short Date";
                    EVRAKTARIHI.NoClip = EvetHayirEnum.ehEvet;
                    EVRAKTARIHI.TextFont.Name = "Arial";
                    EVRAKTARIHI.TextFont.Size = 8;
                    EVRAKTARIHI.Value = @"{#EVRAKTARIHI#}";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 17, 87, 144, 87, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    NewField104 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 82, 165, 87, false);
                    NewField104.Name = "NewField104";
                    NewField104.TextFont.Name = "Arial Narrow";
                    NewField104.TextFont.Size = 9;
                    NewField104.TextFont.Bold = true;
                    NewField104.Value = @"TC Kimlik Nu";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 166, 82, 186, 87, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TCKIMLIKNO.TextFont.Name = "Arial Narrow";
                    TCKIMLIKNO.TextFont.Size = 9;
                    TCKIMLIKNO.Value = @"{#TCNO#}";

                    NewLine3 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 144, 39, 187, 39, false);
                    NewLine3.Name = "NewLine3";
                    NewLine3.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine4 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 187, 39, 187, 45, false);
                    NewLine4.Name = "NewLine4";
                    NewLine4.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine14 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 144, 51, 144, 87, false);
                    NewLine14.Name = "NewLine14";
                    NewLine14.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine13 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 144, 87, 187, 87, false);
                    NewLine13.Name = "NewLine13";
                    NewLine13.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine5 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 144, 45, 187, 45, false);
                    NewLine5.Name = "NewLine5";
                    NewLine5.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine6 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 187, 45, 187, 81, false);
                    NewLine6.Name = "NewLine6";
                    NewLine6.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine7 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 144, 81, 187, 81, false);
                    NewLine7.Name = "NewLine7";
                    NewLine7.DrawStyle = DrawStyleConstants.vbSolid;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommittee.GetCurrentHealthCommittee_Class dataset_GetCurrentHealthCommittee = ParentGroup.rsGroup.GetCurrentRecord<HealthCommittee.GetCurrentHealthCommittee_Class>(0);
                    NAME.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pname) : "") + @" " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Psurname) : "");
                    EMIRTARNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Evraksayisi) : "");
                    EVRAKTARIHI.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Evraktarihi) : "");
                    MAKAM.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Evraksayisi) : "") + @" SAYI VE " + MyParentReport.MAIN.EVRAKTARIHI.FormattedValue + @" TARİHLİ YAZISI";
                    FOTO.CalcValue = @"";
                    NewField1.CalcValue = NewField1.Value;
                    PERMUAYENE103103.CalcValue = PERMUAYENE103103.Value;
                    NewField300.CalcValue = NewField300.Value;
                    FIELD1036.CalcValue = FIELD1036.Value;
                    NAMESURNAME.CalcValue = NAMESURNAME.Value;
                    NewField302.CalcValue = NewField302.Value;
                    NewField303.CalcValue = NewField303.Value;
                    NewField304.CalcValue = NewField304.Value;
                    NewField305.CalcValue = NewField305.Value;
                    FIELD1037.CalcValue = FIELD1037.Value;
                    FIELD1038.CalcValue = FIELD1038.Value;
                    FIELD1039.CalcValue = FIELD1039.Value;
                    FIELD1041.CalcValue = FIELD1041.Value;
                    FIELD1042.CalcValue = FIELD1042.Value;
                    FIELD1043.CalcValue = FIELD1043.Value;
                    HEADER.CalcValue = MyParentReport.MAIN.SITENAME.CalcValue + @" " + MyParentReport.MAIN.SITECITY.CalcValue;
                    NewField21.CalcValue = NewField21.Value;
                    FIELD1045.CalcValue = FIELD1045.Value;
                    FIELD1046.CalcValue = FIELD1046.Value;
                    NewField40.CalcValue = NewField40.Value;
                    AID.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Islemno) : "");
                    NewField42.CalcValue = NewField42.Value;
                    PID.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Pid) : "");
                    NewField44.CalcValue = NewField44.Value;
                    NewField451.CalcValue = NewField451.Value;
                    NewField452.CalcValue = NewField452.Value;
                    FATHERNAME.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.FatherName) : "");
                    EMPLOYMENTNO.CalcValue = @"";
                    BIRTHDATE.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dtarihi) : "");
                    BIRTHINFO.CalcValue = MyParentReport.MAIN.BIRTHDATE.FormattedValue + @" - " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeriilce) : "") + @" / " + (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Dogumyeri) : "");
                    MILITARYUNIT.CalcValue = @"";
                    MILCLASSRANK.CalcValue = @"";
                    REPORTDATE.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raportarihi) : "");
                    REPORTNUMBERDATE.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Raporno) : "") + @" - " + MyParentReport.MAIN.REPORTDATE.FormattedValue;
                    FIELD1044.CalcValue = FIELD1044.Value;
                    NewField104.CalcValue = NewField104.Value;
                    TCKIMLIKNO.CalcValue = (dataset_GetCurrentHealthCommittee != null ? Globals.ToStringCore(dataset_GetCurrentHealthCommittee.Tcno) : "");
                    SITENAME.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME","XXXXXX");
                    SITECITY.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY","XXXXXX");
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { NAME,EMIRTARNO,EVRAKTARIHI,MAKAM,FOTO,NewField1,PERMUAYENE103103,NewField300,FIELD1036,NAMESURNAME,NewField302,NewField303,NewField304,NewField305,FIELD1037,FIELD1038,FIELD1039,FIELD1041,FIELD1042,FIELD1043,HEADER,NewField21,FIELD1045,FIELD1046,NewField40,AID,NewField42,PID,NewField44,NewField451,NewField452,FATHERNAME,EMPLOYMENTNO,BIRTHDATE,BIRTHINFO,MILITARYUNIT,MILCLASSRANK,REPORTDATE,REPORTNUMBERDATE,FIELD1044,NewField104,TCKIMLIKNO,SITENAME,SITECITY,XXXXXXBASLIK};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCPeriodicExaminationSlipReport)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommittee hc = (HealthCommittee)context.GetObject(new Guid(sObjectID),"HealthCommittee");
            
//            //MilitaryClassDefinitions pMilClass = hc.Episode.MyMilitaryClass();
//            //RankDefinitions pRank = hc.Episode.MyRank();
//            
//            MilitaryClassDefinitions pMilClass = hc.Episode.MilitaryClass;
//            RankDefinitions pRank = hc.Episode.Rank;
//            
//            // sınıf ve rütbe boş ise hasta grubu gelsin istendi (erler için falan)
//            if (hc.Episode.MilitaryClass == null && hc.Episode.Rank == null)
//                this.MILCLASSRANK.CalcValue = TTObjectClasses.Common.GetDisplayTextOfDataTypeEnum(hc.Episode.PatientGroup.Value);
//            else
//                this.MILCLASSRANK.CalcValue = (pMilClass == null ? "" : pMilClass.Name) + " " + (pRank == null ? "" : pRank.Name);
//            
//            if(hc.AutomaticallyCreated != true)
//            {
//                if (hc.Episode.MyRelationship() != null)
//                {
//                    if (hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "" && hc.Episode.MyRelationship().Relationship.Trim().ToLower() != "kendisi")
//                        this.MILCLASSRANK.CalcValue += " (" + hc.Episode.MyRelationship().Relationship + ")";
//                }
//            }
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

        public HCPeriodicExaminationSlipReport()
        {
            arkasayfa = new arkasayfaGroup(this,"arkasayfa");
            MAIN = new MAINGroup(arkasayfa,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, false, false, new Guid("53c9e989-dad5-4f3f-b973-d0bda68f0942"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["String50"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HCPERIODICEXAMINATIONSLIPREPORT";
            Caption = "Sağlık Kurulu Periyodik Muayene Fişi";
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
            fd.TextFont.Name = "Courier New";
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