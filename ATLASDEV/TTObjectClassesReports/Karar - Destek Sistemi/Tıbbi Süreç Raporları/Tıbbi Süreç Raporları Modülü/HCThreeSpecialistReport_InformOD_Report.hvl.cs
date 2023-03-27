
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
    /// Durum Bildirir Tek Hekim Sağlık Raporu
    /// </summary>
    public partial class HCThreeSpecialistReport_InformOD : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class TANIGroup : TTReportGroup
        {
            public HCThreeSpecialistReport_InformOD MyParentReport
            {
                get { return (HCThreeSpecialistReport_InformOD)ParentReport; }
            }

            new public TANIGroupHeader Header()
            {
                return (TANIGroupHeader)_header;
            }

            new public TANIGroupFooter Footer()
            {
                return (TANIGroupFooter)_footer;
            }

            public TTReportField RAPOR121 { get {return Header().RAPOR121;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField1114111 { get {return Header().NewField1114111;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField NewField1114151 { get {return Header().NewField1114151;} }
            public TTReportField NewField11214131 { get {return Header().NewField11214131;} }
            public TTReportField NewField11314111 { get {return Header().NewField11314111;} }
            public TTReportField NewField11414111 { get {return Header().NewField11414111;} }
            public TTReportField NewField112141211 { get {return Header().NewField112141211;} }
            public TTReportField TCKIMLIKNO { get {return Header().TCKIMLIKNO;} }
            public TTReportField BABAADI { get {return Header().BABAADI;} }
            public TTReportField DOGUMTARIH { get {return Header().DOGUMTARIH;} }
            public TTReportField ADRES { get {return Header().ADRES;} }
            public TTReportField MEDULARAPORTAKIPNO1 { get {return Header().MEDULARAPORTAKIPNO1;} }
            public TTReportField NewField11514111 { get {return Header().NewField11514111;} }
            public TTReportField NewField111141411 { get {return Header().NewField111141411;} }
            public TTReportField NewField11114141 { get {return Header().NewField11114141;} }
            public TTReportField ONLINEPROTOKOLNO { get {return Header().ONLINEPROTOKOLNO;} }
            public TTReportField KURUM { get {return Header().KURUM;} }
            public TTReportField NewField11211 { get {return Header().NewField11211;} }
            public TTReportField KARAR11 { get {return Header().KARAR11;} }
            public TTReportField SL { get {return Header().SL;} }
            public TTReportField KARAR111 { get {return Header().KARAR111;} }
            public TTReportField YT { get {return Header().YT;} }
            public TTReportField KARAR112 { get {return Header().KARAR112;} }
            public TTReportField AK { get {return Header().AK;} }
            public TTReportField KARAR113 { get {return Header().KARAR113;} }
            public TTReportField KK { get {return Header().KK;} }
            public TTReportField NewField11214111 { get {return Header().NewField11214111;} }
            public TTReportField RAPORTARIHI { get {return Header().RAPORTARIHI;} }
            public TTReportField NewField114141111 { get {return Header().NewField114141111;} }
            public TTReportField CINSIYETI { get {return Header().CINSIYETI;} }
            public TTReportField NewField1111141411 { get {return Header().NewField1111141411;} }
            public TTReportField TELEFON { get {return Header().TELEFON;} }
            public TTReportField EVTELEFONU { get {return Header().EVTELEFONU;} }
            public TTReportField CEPTELEFONU { get {return Header().CEPTELEFONU;} }
            public TTReportField UZ { get {return Footer().UZ;} }
            public TTReportField ADSOYADDOC { get {return Footer().ADSOYADDOC;} }
            public TTReportField NewField1113411 { get {return Footer().NewField1113411;} }
            public TTReportField DIPLOMATESCILNO { get {return Footer().DIPLOMATESCILNO;} }
            public TANIGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public TANIGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
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
                _body = null;
                _header = new TANIGroupHeader(this);
                _footer = new TANIGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class TANIGroupHeader : TTReportSection
            {
                public HCThreeSpecialistReport_InformOD MyParentReport
                {
                    get { return (HCThreeSpecialistReport_InformOD)ParentReport; }
                }
                
                public TTReportField RAPOR121;
                public TTReportField ADSOYAD;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField1114111;
                public TTReportField RAPORNO;
                public TTReportField NewField1114151;
                public TTReportField NewField11214131;
                public TTReportField NewField11314111;
                public TTReportField NewField11414111;
                public TTReportField NewField112141211;
                public TTReportField TCKIMLIKNO;
                public TTReportField BABAADI;
                public TTReportField DOGUMTARIH;
                public TTReportField ADRES;
                public TTReportField MEDULARAPORTAKIPNO1;
                public TTReportField NewField11514111;
                public TTReportField NewField111141411;
                public TTReportField NewField11114141;
                public TTReportField ONLINEPROTOKOLNO;
                public TTReportField KURUM;
                public TTReportField NewField11211;
                public TTReportField KARAR11;
                public TTReportField SL;
                public TTReportField KARAR111;
                public TTReportField YT;
                public TTReportField KARAR112;
                public TTReportField AK;
                public TTReportField KARAR113;
                public TTReportField KK;
                public TTReportField NewField11214111;
                public TTReportField RAPORTARIHI;
                public TTReportField NewField114141111;
                public TTReportField CINSIYETI;
                public TTReportField NewField1111141411;
                public TTReportField TELEFON;
                public TTReportField EVTELEFONU;
                public TTReportField CEPTELEFONU; 
                public TANIGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 113;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    RAPOR121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 29, 198, 34, false);
                    RAPOR121.Name = "RAPOR121";
                    RAPOR121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPOR121.VertAlign = VerticalAlignmentEnum.vaBottom;
                    RAPOR121.TextFont.Name = "Arial";
                    RAPOR121.TextFont.Bold = true;
                    RAPOR121.TextFont.CharSet = 162;
                    RAPOR121.Value = @"DURUM BİLDİRİR TEK HEKİM SAĞLIK RAPORU";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 67, 106, 73, false);
                    ADSOYAD.Name = "ADSOYAD";
                    ADSOYAD.DrawStyle = DrawStyleConstants.vbSolid;
                    ADSOYAD.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYAD.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ADSOYAD.MultiLine = EvetHayirEnum.ehEvet;
                    ADSOYAD.NoClip = EvetHayirEnum.ehEvet;
                    ADSOYAD.WordBreak = EvetHayirEnum.ehEvet;
                    ADSOYAD.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADSOYAD.ObjectDefName = "Patient";
                    ADSOYAD.DataMember = "FullName";
                    ADSOYAD.TextFont.CharSet = 162;
                    ADSOYAD.Value = @"{#PATIENTID#}";

                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 7, 198, 28, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.TextFont.CharSet = 162;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField1114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 97, 145, 103, false);
                    NewField1114111.Name = "NewField1114111";
                    NewField1114111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1114111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1114111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1114111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1114111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1114111.TextFont.CharSet = 162;
                    NewField1114111.Value = @"RAPOR NO";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 97, 198, 103, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORNO.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORNO.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORNO.TextFont.CharSet = 162;
                    RAPORNO.Value = @"{#RAPORNO#}";

                    NewField1114151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 67, 145, 73, false);
                    NewField1114151.Name = "NewField1114151";
                    NewField1114151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1114151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1114151.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1114151.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1114151.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1114151.TextFont.CharSet = 162;
                    NewField1114151.Value = @"TC KİMLİK NO";

                    NewField11214131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 67, 44, 73, false);
                    NewField11214131.Name = "NewField11214131";
                    NewField11214131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11214131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11214131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11214131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11214131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11214131.TextFont.CharSet = 162;
                    NewField11214131.Value = @"ADI SOYADI";

                    NewField11314111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 73, 44, 79, false);
                    NewField11314111.Name = "NewField11314111";
                    NewField11314111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11314111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11314111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11314111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11314111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11314111.TextFont.CharSet = 162;
                    NewField11314111.Value = @"BABA ADI";

                    NewField11414111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 79, 44, 85, false);
                    NewField11414111.Name = "NewField11414111";
                    NewField11414111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11414111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11414111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11414111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11414111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11414111.TextFont.CharSet = 162;
                    NewField11414111.Value = @"DOĞUM TARİHİ";

                    NewField112141211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 103, 44, 112, false);
                    NewField112141211.Name = "NewField112141211";
                    NewField112141211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112141211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112141211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112141211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112141211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112141211.TextFont.CharSet = 162;
                    NewField112141211.Value = @"ADRES";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 67, 198, 73, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCKIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 73, 106, 79, false);
                    BABAADI.Name = "BABAADI";
                    BABAADI.DrawStyle = DrawStyleConstants.vbSolid;
                    BABAADI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BABAADI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    BABAADI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    BABAADI.MultiLine = EvetHayirEnum.ehEvet;
                    BABAADI.WordBreak = EvetHayirEnum.ehEvet;
                    BABAADI.ExpandTabs = EvetHayirEnum.ehEvet;
                    BABAADI.TextFont.CharSet = 162;
                    BABAADI.Value = @"{#FATHERNAME#}";

                    DOGUMTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 79, 106, 85, false);
                    DOGUMTARIH.Name = "DOGUMTARIH";
                    DOGUMTARIH.DrawStyle = DrawStyleConstants.vbSolid;
                    DOGUMTARIH.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOGUMTARIH.TextFormat = @"dd/MM/yyyy";
                    DOGUMTARIH.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DOGUMTARIH.MultiLine = EvetHayirEnum.ehEvet;
                    DOGUMTARIH.WordBreak = EvetHayirEnum.ehEvet;
                    DOGUMTARIH.ExpandTabs = EvetHayirEnum.ehEvet;
                    DOGUMTARIH.TextFont.CharSet = 162;
                    DOGUMTARIH.Value = @"{#DTARIHI#}";

                    ADRES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 103, 198, 112, false);
                    ADRES.Name = "ADRES";
                    ADRES.DrawStyle = DrawStyleConstants.vbSolid;
                    ADRES.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRES.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADRES.MultiLine = EvetHayirEnum.ehEvet;
                    ADRES.WordBreak = EvetHayirEnum.ehEvet;
                    ADRES.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADRES.TextFont.CharSet = 162;
                    ADRES.Value = @"{#ADRES#}";

                    MEDULARAPORTAKIPNO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 8, 247, 12, false);
                    MEDULARAPORTAKIPNO1.Name = "MEDULARAPORTAKIPNO1";
                    MEDULARAPORTAKIPNO1.Visible = EvetHayirEnum.ehHayir;
                    MEDULARAPORTAKIPNO1.FieldType = ReportFieldTypeEnum.ftExpression;
                    MEDULARAPORTAKIPNO1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MEDULARAPORTAKIPNO1.VertAlign = VerticalAlignmentEnum.vaBottom;
                    MEDULARAPORTAKIPNO1.TextFont.CharSet = 162;
                    MEDULARAPORTAKIPNO1.Value = @"{#MEDULARAPORTAKIPNO#}";

                    NewField11514111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 62, 198, 67, false);
                    NewField11514111.Name = "NewField11514111";
                    NewField11514111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11514111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11514111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11514111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11514111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11514111.TextFont.Bold = true;
                    NewField11514111.TextFont.CharSet = 162;
                    NewField11514111.Value = @"BAŞVURU SAHİBİNİN";

                    NewField111141411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 85, 44, 103, false);
                    NewField111141411.Name = "NewField111141411";
                    NewField111141411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111141411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111141411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111141411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111141411.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111141411.TextFont.CharSet = 162;
                    NewField111141411.Value = @"KURUMU VE
GÖREVİ";

                    NewField11114141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 85, 145, 91, false);
                    NewField11114141.Name = "NewField11114141";
                    NewField11114141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11114141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11114141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11114141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11114141.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11114141.TextFont.CharSet = 162;
                    NewField11114141.Value = @"ONLİNE PROTOKOL NO";

                    ONLINEPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 85, 198, 91, false);
                    ONLINEPROTOKOLNO.Name = "ONLINEPROTOKOLNO";
                    ONLINEPROTOKOLNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ONLINEPROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONLINEPROTOKOLNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ONLINEPROTOKOLNO.TextFont.CharSet = 162;
                    ONLINEPROTOKOLNO.Value = @"";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 85, 106, 103, false);
                    KURUM.Name = "KURUM";
                    KURUM.DrawStyle = DrawStyleConstants.vbSolid;
                    KURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUM.CaseFormat = CaseFormatEnum.fcUpperCase;
                    KURUM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KURUM.MultiLine = EvetHayirEnum.ehEvet;
                    KURUM.NoClip = EvetHayirEnum.ehEvet;
                    KURUM.WordBreak = EvetHayirEnum.ehEvet;
                    KURUM.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURUM.TextFont.CharSet = 162;
                    KURUM.Value = @"";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 40, 44, 45, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"VERİLME NEDENİ :";

                    KARAR11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 47, 35, 52, false);
                    KARAR11.Name = "KARAR11";
                    KARAR11.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR11.NoClip = EvetHayirEnum.ehEvet;
                    KARAR11.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR11.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR11.TextFont.CharSet = 162;
                    KARAR11.Value = @"SPOR LİSANSI";

                    SL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 47, 43, 52, false);
                    SL.Name = "SL";
                    SL.DrawStyle = DrawStyleConstants.vbSolid;
                    SL.FieldType = ReportFieldTypeEnum.ftVariable;
                    SL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SL.MultiLine = EvetHayirEnum.ehEvet;
                    SL.NoClip = EvetHayirEnum.ehEvet;
                    SL.WordBreak = EvetHayirEnum.ehEvet;
                    SL.ExpandTabs = EvetHayirEnum.ehEvet;
                    SL.TextFont.CharSet = 162;
                    SL.Value = @"";

                    KARAR111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 72, 47, 98, 52, false);
                    KARAR111.Name = "KARAR111";
                    KARAR111.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR111.NoClip = EvetHayirEnum.ehEvet;
                    KARAR111.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR111.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR111.TextFont.CharSet = 162;
                    KARAR111.Value = @"YİVSİZ AV TÜFEĞİ";

                    YT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 47, 106, 52, false);
                    YT.Name = "YT";
                    YT.DrawStyle = DrawStyleConstants.vbSolid;
                    YT.FieldType = ReportFieldTypeEnum.ftVariable;
                    YT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    YT.MultiLine = EvetHayirEnum.ehEvet;
                    YT.NoClip = EvetHayirEnum.ehEvet;
                    YT.WordBreak = EvetHayirEnum.ehEvet;
                    YT.ExpandTabs = EvetHayirEnum.ehEvet;
                    YT.TextFont.CharSet = 162;
                    YT.Value = @"";

                    KARAR112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 47, 150, 52, false);
                    KARAR112.Name = "KARAR112";
                    KARAR112.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR112.NoClip = EvetHayirEnum.ehEvet;
                    KARAR112.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR112.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR112.TextFont.CharSet = 162;
                    KARAR112.Value = @"AKLİ MELEKE";

                    AK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 47, 158, 52, false);
                    AK.Name = "AK";
                    AK.DrawStyle = DrawStyleConstants.vbSolid;
                    AK.FieldType = ReportFieldTypeEnum.ftVariable;
                    AK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AK.MultiLine = EvetHayirEnum.ehEvet;
                    AK.NoClip = EvetHayirEnum.ehEvet;
                    AK.WordBreak = EvetHayirEnum.ehEvet;
                    AK.ExpandTabs = EvetHayirEnum.ehEvet;
                    AK.TextFont.CharSet = 162;
                    AK.Value = @"";

                    KARAR113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 54, 98, 59, false);
                    KARAR113.Name = "KARAR113";
                    KARAR113.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR113.NoClip = EvetHayirEnum.ehEvet;
                    KARAR113.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR113.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR113.TextFont.CharSet = 162;
                    KARAR113.Value = @"KURUM VE KURULUŞLARA (Okul, Yurt vb.) VERİLMEK ÜZERE";

                    KK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 101, 54, 106, 59, false);
                    KK.Name = "KK";
                    KK.DrawStyle = DrawStyleConstants.vbSolid;
                    KK.FieldType = ReportFieldTypeEnum.ftVariable;
                    KK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KK.MultiLine = EvetHayirEnum.ehEvet;
                    KK.NoClip = EvetHayirEnum.ehEvet;
                    KK.WordBreak = EvetHayirEnum.ehEvet;
                    KK.ExpandTabs = EvetHayirEnum.ehEvet;
                    KK.TextFont.CharSet = 162;
                    KK.Value = @"";

                    NewField11214111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 91, 145, 97, false);
                    NewField11214111.Name = "NewField11214111";
                    NewField11214111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11214111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11214111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11214111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11214111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11214111.TextFont.CharSet = 162;
                    NewField11214111.Value = @"RAPOR TARİHİ";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 91, 198, 97, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"dd/MM/yyyy";
                    RAPORTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORTARIHI.TextFont.CharSet = 162;
                    RAPORTARIHI.Value = @"{#RAPORTARIHI#}";

                    NewField114141111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 73, 145, 79, false);
                    NewField114141111.Name = "NewField114141111";
                    NewField114141111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114141111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField114141111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField114141111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField114141111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField114141111.TextFont.CharSet = 162;
                    NewField114141111.Value = @"CİNSİYETİ";

                    CINSIYETI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 73, 198, 79, false);
                    CINSIYETI.Name = "CINSIYETI";
                    CINSIYETI.DrawStyle = DrawStyleConstants.vbSolid;
                    CINSIYETI.FieldType = ReportFieldTypeEnum.ftVariable;
                    CINSIYETI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    CINSIYETI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CINSIYETI.MultiLine = EvetHayirEnum.ehEvet;
                    CINSIYETI.WordBreak = EvetHayirEnum.ehEvet;
                    CINSIYETI.ExpandTabs = EvetHayirEnum.ehEvet;
                    CINSIYETI.ObjectDefName = "SexEnum";
                    CINSIYETI.DataMember = "DISPLAYTEXT";
                    CINSIYETI.TextFont.CharSet = 162;
                    CINSIYETI.Value = @"{#SEX#}";

                    NewField1111141411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 79, 145, 85, false);
                    NewField1111141411.Name = "NewField1111141411";
                    NewField1111141411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111141411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111141411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1111141411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1111141411.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1111141411.TextFont.CharSet = 162;
                    NewField1111141411.Value = @"TELEFON";

                    TELEFON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 79, 198, 85, false);
                    TELEFON.Name = "TELEFON";
                    TELEFON.DrawStyle = DrawStyleConstants.vbSolid;
                    TELEFON.FieldType = ReportFieldTypeEnum.ftVariable;
                    TELEFON.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TELEFON.MultiLine = EvetHayirEnum.ehEvet;
                    TELEFON.WordBreak = EvetHayirEnum.ehEvet;
                    TELEFON.ExpandTabs = EvetHayirEnum.ehEvet;
                    TELEFON.TextFont.CharSet = 162;
                    TELEFON.Value = @"";

                    EVTELEFONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 16, 235, 20, false);
                    EVTELEFONU.Name = "EVTELEFONU";
                    EVTELEFONU.Visible = EvetHayirEnum.ehHayir;
                    EVTELEFONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVTELEFONU.TextFont.CharSet = 162;
                    EVTELEFONU.Value = @"{#HOMEPHONE#}";

                    CEPTELEFONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 22, 235, 26, false);
                    CEPTELEFONU.Name = "CEPTELEFONU";
                    CEPTELEFONU.Visible = EvetHayirEnum.ehHayir;
                    CEPTELEFONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    CEPTELEFONU.TextFont.CharSet = 162;
                    CEPTELEFONU.Value = @"{#MOBILEPHONE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class dataset_GetHCWithThreeSpecialist = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class>(0);
                    RAPOR121.CalcValue = RAPOR121.Value;
                    ADSOYAD.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Patientid) : "");
                    ADSOYAD.PostFieldValueCalculation();
                    NewField1114111.CalcValue = NewField1114111.Value;
                    RAPORNO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Raporno) : "");
                    NewField1114151.CalcValue = NewField1114151.Value;
                    NewField11214131.CalcValue = NewField11214131.Value;
                    NewField11314111.CalcValue = NewField11314111.Value;
                    NewField11414111.CalcValue = NewField11414111.Value;
                    NewField112141211.CalcValue = NewField112141211.Value;
                    TCKIMLIKNO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.UniqueRefNo) : "");
                    BABAADI.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.FatherName) : "");
                    DOGUMTARIH.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Dtarihi) : "");
                    ADRES.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Adres) : "");
                    NewField11514111.CalcValue = NewField11514111.Value;
                    NewField111141411.CalcValue = NewField111141411.Value;
                    NewField11114141.CalcValue = NewField11114141.Value;
                    ONLINEPROTOKOLNO.CalcValue = @"";
                    KURUM.CalcValue = @"";
                    NewField11211.CalcValue = NewField11211.Value;
                    KARAR11.CalcValue = KARAR11.Value;
                    SL.CalcValue = @"";
                    KARAR111.CalcValue = KARAR111.Value;
                    YT.CalcValue = @"";
                    KARAR112.CalcValue = KARAR112.Value;
                    AK.CalcValue = @"";
                    KARAR113.CalcValue = KARAR113.Value;
                    KK.CalcValue = @"";
                    NewField11214111.CalcValue = NewField11214111.Value;
                    RAPORTARIHI.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Raportarihi) : "");
                    NewField114141111.CalcValue = NewField114141111.Value;
                    CINSIYETI.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Sex) : "");
                    CINSIYETI.PostFieldValueCalculation();
                    NewField1111141411.CalcValue = NewField1111141411.Value;
                    TELEFON.CalcValue = @"";
                    EVTELEFONU.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Homephone) : "");
                    CEPTELEFONU.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Mobilephone) : "");
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    MEDULARAPORTAKIPNO1.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.MedulaRaporTakipNo) : "");
                    return new TTReportObject[] { RAPOR121,ADSOYAD,NewField1114111,RAPORNO,NewField1114151,NewField11214131,NewField11314111,NewField11414111,NewField112141211,TCKIMLIKNO,BABAADI,DOGUMTARIH,ADRES,NewField11514111,NewField111141411,NewField11114141,ONLINEPROTOKOLNO,KURUM,NewField11211,KARAR11,SL,KARAR111,YT,KARAR112,AK,KARAR113,KK,NewField11214111,RAPORTARIHI,NewField114141111,CINSIYETI,NewField1111141411,TELEFON,EVTELEFONU,CEPTELEFONU,XXXXXXBASLIK,MEDULARAPORTAKIPNO1};
                }

                public override void RunScript()
                {
#region TANI HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCThreeSpecialistReport_InformOD)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommitteeWithThreeSpecialist hcw = (HealthCommitteeWithThreeSpecialist)context.GetObject(new Guid(sObjectID), typeof(HealthCommitteeWithThreeSpecialist));

            if (hcw != null)
            {
                // Verilme Nedeni
                if (hcw.SituationInformODReportType.HasValue)
                {
                    if (hcw.SituationInformODReportType.Value == HCTSituationInformODTypeEnum.SportLicence)
                        this.SL.CalcValue = "X";
                    else if (hcw.SituationInformODReportType.Value == HCTSituationInformODTypeEnum.Rifle)
                        this.YT.CalcValue = "X";
                    else if (hcw.SituationInformODReportType.Value == HCTSituationInformODTypeEnum.Mental)
                        this.AK.CalcValue = "X";
                    else if (hcw.SituationInformODReportType.Value == HCTSituationInformODTypeEnum.Foundation)
                        this.KK.CalcValue = "X";
                }

                // Kurumu ve Görevi
                SubEpisodeProtocol tempSEP = null;
                foreach (SubEpisodeProtocol sep in hcw.SubEpisode.SubEpisodeProtocols)
                {
                    if (tempSEP == null)
                        tempSEP = sep;
                    else if (tempSEP.CreationDate.HasValue && sep.CreationDate.HasValue && tempSEP.CreationDate.Value < sep.CreationDate.Value)
                        tempSEP = sep;
                }

                if (tempSEP != null && tempSEP.Payer != null)
                {
                    this.KURUM.CalcValue = tempSEP.Payer.Name.ToUpper();
                    if (!string.IsNullOrEmpty(this.KURUM.CalcValue))
                    {
                        this.KURUM.CalcValue = this.KURUM.CalcValue.Replace(" KURUMU", "");
                        this.KURUM.CalcValue = this.KURUM.CalcValue.Replace("HASTALAR", "HASTA");
                    }
                }
            }

            if (!string.IsNullOrEmpty(this.EVTELEFONU.CalcValue))
                this.TELEFON.CalcValue = this.EVTELEFONU.CalcValue;
            else if (!string.IsNullOrEmpty(this.CEPTELEFONU.CalcValue))
                this.TELEFON.CalcValue = this.CEPTELEFONU.CalcValue;
#endregion TANI HEADER_Script
                }
            }
            public partial class TANIGroupFooter : TTReportSection
            {
                public HCThreeSpecialistReport_InformOD MyParentReport
                {
                    get { return (HCThreeSpecialistReport_InformOD)ParentReport; }
                }
                
                public TTReportField UZ;
                public TTReportField ADSOYADDOC;
                public TTReportField NewField1113411;
                public TTReportField DIPLOMATESCILNO; 
                public TANIGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 43;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 28, 191, 32, false);
                    UZ.Name = "UZ";
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.TextFont.Size = 8;
                    UZ.TextFont.CharSet = 162;
                    UZ.Value = @"";

                    ADSOYADDOC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 12, 191, 16, false);
                    ADSOYADDOC.Name = "ADSOYADDOC";
                    ADSOYADDOC.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC.TextFont.Size = 8;
                    ADSOYADDOC.TextFont.CharSet = 162;
                    ADSOYADDOC.Value = @"";

                    NewField1113411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 6, 172, 10, false);
                    NewField1113411.Name = "NewField1113411";
                    NewField1113411.TextFont.Bold = true;
                    NewField1113411.TextFont.Underline = true;
                    NewField1113411.TextFont.CharSet = 162;
                    NewField1113411.Value = @"DÜZENLEYEN TABİP";

                    DIPLOMATESCILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 24, 191, 28, false);
                    DIPLOMATESCILNO.Name = "DIPLOMATESCILNO";
                    DIPLOMATESCILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMATESCILNO.MultiLine = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO.NoClip = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO.WordBreak = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO.TextFont.Size = 8;
                    DIPLOMATESCILNO.TextFont.CharSet = 162;
                    DIPLOMATESCILNO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class dataset_GetHCWithThreeSpecialist = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class>(0);
                    UZ.CalcValue = @"";
                    ADSOYADDOC.CalcValue = @"";
                    NewField1113411.CalcValue = NewField1113411.Value;
                    DIPLOMATESCILNO.CalcValue = @"";
                    return new TTReportObject[] { UZ,ADSOYADDOC,NewField1113411,DIPLOMATESCILNO};
                }

                public override void RunScript()
                {
#region TANI FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCThreeSpecialistReport_InformOD)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommitteeWithThreeSpecialist hcw = (HealthCommitteeWithThreeSpecialist)context.GetObject(new Guid(sObjectID), "HealthCommitteeWithThreeSpecialist");

            //Baştabip
            string sDoctor = TTObjectClasses.SystemParameter.GetParameterValue("REPORTAPPROVALPOSITION", "HEADDOCTOR");
            string sHeadID = "";
            if (sDoctor == "IITABIP")
                sHeadID = TTObjectClasses.SystemParameter.GetParameterValue("IITABIP_OBJECTID", "");
            else
                sHeadID = TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR_OBJECTID", "");

            ResUser head = (ResUser)context.GetObject(new Guid(sHeadID), "ResUser");

            /*if (TTObjectClasses.SystemParameter.GetParameterValue("ShowHeadDoctorApproveBlockInReport","TRUE") != "FALSE")
                    {
                        this.ADSOYAD1.CalcValue = head.Name;
                        //string sClassRank0 = head.MilitaryClass != null ? head.MilitaryClass.ShortName : "";
                        string sForce = head.ForcesCommand != null ? head.ForcesCommand.Qref : "";
                        string sRank = head.Rank != null ? head.Rank.ShortName : "";
                        string sTitle = head.Title.HasValue ? TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(head.Title.Value) : "";
                        this.SINIFRUT1.CalcValue = sTitle + sForce + sRank;
                        this.TITLE1.CalcValue = "Sicil No : " + head.EmploymentRecordID;
                        this.LBLAPPROVE.Visible = EvetHayirEnum.ehEvet;
                    }
                    else
                    {
                        this.LBLAPPROVE.Visible = EvetHayirEnum.ehHayir;
                    }*/

            string sMemberSpeciality = "";
            //Uzmanlar
            if(hcw.Specialists != null && hcw.Specialists.Count > 0)
            {
                if(hcw.Specialists[0].Specialist1 != null)
                {
//                    this.ADSOYADDOC.CalcValue = hcw.Specialists[0].Specialist1.Name;
//                    //string sClassRank = hcw.Specialists[0].Specialist1.MilitaryClass != null ? hcw.Specialists[0].Specialist1.MilitaryClass.ShortName : "";
//                    string sForce1 = hcw.Specialists[0].Specialist1.ForcesCommand != null ? hcw.Specialists[0].Specialist1.ForcesCommand.Qref : "";
//                    string sRank1 = hcw.Specialists[0].Specialist1.Rank != null ? hcw.Specialists[0].Specialist1.Rank.ShortName : "";
//                    string sTitle1 = hcw.Specialists[0].Specialist1.Title.HasValue ? TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(hcw.Specialists[0].Specialist1.Title.Value) : "";
//                   // this.SINRUT.CalcValue = sTitle1 + sForce1 + sRank1;
//
//                    //if(TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "")=="TRUE")
//                   // this.SICILNO.CalcValue = "Sicil No : " + hcw.Specialists[0].Specialist1.EmploymentRecordID;
//                    //else
//                    //    this.SICILNO.CalcValue = "(" + hcw.Specialists[0].Specialist1.DiplomaRegisterNo + ")";
//                    this.DIPLOMATESCILNO.CalcValue = "Diploma Tescil No : " + hcw.Specialists[0].Specialist1.DiplomaRegisterNo;
//
//                    if (hcw.Specialists[0].Specialist1.GetSpeciality() != null)
//                        sMemberSpeciality = hcw.Specialists[0].Specialist1.GetSpeciality().Name + " Uzm.";
//                    else
//                        sMemberSpeciality = "";
//
//                    this.UZ.CalcValue = sMemberSpeciality;
                }
            }
#endregion TANI FOOTER_Script
                }
            }

        }

        public TANIGroup TANI;

        public partial class MAINGroup : TTReportGroup
        {
            public HCThreeSpecialistReport_InformOD MyParentReport
            {
                get { return (HCThreeSpecialistReport_InformOD)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField TANI { get {return Body().TANI;} }
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
                public HCThreeSpecialistReport_InformOD MyParentReport
                {
                    get { return (HCThreeSpecialistReport_InformOD)ParentReport; }
                }
                
                public TTReportField NewField1121;
                public TTReportField TANI; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 34;
                    RepeatCount = 0;
                    
                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 3, 198, 8, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"ICD KODU VE TANI(LAR)";

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 8, 198, 33, false);
                    TANI.Name = "TANI";
                    TANI.DrawStyle = DrawStyleConstants.vbSolid;
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.NoClip = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.ExpandTabs = EvetHayirEnum.ehEvet;
                    TANI.TextFont.CharSet = 162;
                    TANI.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1121.CalcValue = NewField1121.Value;
                    TANI.CalcValue = @"";
                    return new TTReportObject[] { NewField1121,TANI};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
                    string sObjectID = ((HCThreeSpecialistReport_InformOD)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                    HealthCommitteeWithThreeSpecialist hcw = (HealthCommitteeWithThreeSpecialist)context.GetObject(new Guid(sObjectID), typeof(HealthCommitteeWithThreeSpecialist));

                    if (hcw != null)
                    {
                        string diagnose = hcw.GetMyOrEpisodeDiagnosis();
                        if (!string.IsNullOrEmpty(diagnose))
                            this.TANI.CalcValue = diagnose.Substring(8, diagnose.Length - 8);
                    }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTAGroup : TTReportGroup
        {
            public HCThreeSpecialistReport_InformOD MyParentReport
            {
                get { return (HCThreeSpecialistReport_InformOD)ParentReport; }
            }

            new public PARTAGroupBody Body()
            {
                return (PARTAGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField TESTSONUCU { get {return Body().TESTSONUCU;} }
            public TTReportField MADDE { get {return Body().MADDE;} }
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
                _header = null;
                _footer = null;
                _body = new PARTAGroupBody(this);
            }

            public partial class PARTAGroupBody : TTReportSection
            {
                public HCThreeSpecialistReport_InformOD MyParentReport
                {
                    get { return (HCThreeSpecialistReport_InformOD)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField TESTSONUCU;
                public TTReportField MADDE; 
                public PARTAGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 32;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 1, 198, 6, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"AKLİ MELEKE RAPORU İÇİN MİNİ MENTAL TEST SONUCU";

                    TESTSONUCU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 6, 198, 31, false);
                    TESTSONUCU.Name = "TESTSONUCU";
                    TESTSONUCU.DrawStyle = DrawStyleConstants.vbSolid;
                    TESTSONUCU.FieldType = ReportFieldTypeEnum.ftVariable;
                    TESTSONUCU.MultiLine = EvetHayirEnum.ehEvet;
                    TESTSONUCU.NoClip = EvetHayirEnum.ehEvet;
                    TESTSONUCU.WordBreak = EvetHayirEnum.ehEvet;
                    TESTSONUCU.ExpandTabs = EvetHayirEnum.ehEvet;
                    TESTSONUCU.TextFont.CharSet = 162;
                    TESTSONUCU.Value = @"";

                    MADDE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 215, 3, 231, 8, false);
                    MADDE.Name = "MADDE";
                    MADDE.Visible = EvetHayirEnum.ehHayir;
                    MADDE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDE.TextFont.Size = 8;
                    MADDE.TextFont.CharSet = 162;
                    MADDE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1.CalcValue = NewField1.Value;
                    TESTSONUCU.CalcValue = @"";
                    MADDE.CalcValue = @"";
                    return new TTReportObject[] { NewField1,TESTSONUCU,MADDE};
                }

                public override void RunScript()
                {
#region PARTA BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
                    string sObjectID = ((HCThreeSpecialistReport_InformOD)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                    HealthCommitteeWithThreeSpecialist hcw = (HealthCommitteeWithThreeSpecialist)context.GetObject(new Guid(sObjectID), typeof(HealthCommitteeWithThreeSpecialist));

                    if (hcw != null)
                    {
                        // Karar
                        if (hcw.Report != null)
                            this.TESTSONUCU.CalcValue = TTObjectClasses.Common.GetTextOfRTFString(hcw.Report.ToString());

                        //Madde-Dilim-Fıkra
                        BindingList<HCWithThreeSpecialist_MatterSliceAnectodeGrid.GetHCWTS_MatterSliceAnectodeGridByParent_Class> theAnectodes = HCWithThreeSpecialist_MatterSliceAnectodeGrid.GetHCWTS_MatterSliceAnectodeGridByParent(sObjectID);
                        if (theAnectodes.Count > 0)
                        {
                            this.MADDE.CalcValue = "[";
                            foreach (HCWithThreeSpecialist_MatterSliceAnectodeGrid.GetHCWTS_MatterSliceAnectodeGridByParent_Class theAnectode in theAnectodes)
                            {
                                this.MADDE.CalcValue += theAnectode.Matter + "/" + theAnectode.HalfSlice + "/" + theAnectode.Anectode;
                                this.MADDE.CalcValue += "  ";
                            }
                            this.MADDE.CalcValue = this.MADDE.CalcValue.Substring(0, this.MADDE.CalcValue.Length - 2);
                            this.MADDE.CalcValue += "]\r\n";
                        }

                        this.TESTSONUCU.CalcValue = this.MADDE.CalcValue + this.TESTSONUCU.CalcValue;
                    }

                    if (!string.IsNullOrEmpty(this.TESTSONUCU.CalcValue))
                        this.TESTSONUCU.CalcValue = this.TESTSONUCU.CalcValue + "\r\n";
#endregion PARTA BODY_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public HCThreeSpecialistReport_InformOD MyParentReport
            {
                get { return (HCThreeSpecialistReport_InformOD)ParentReport; }
            }

            new public PARTBGroupBody Body()
            {
                return (PARTBGroupBody)_body;
            }
            public TTReportField NewField121211 { get {return Body().NewField121211;} }
            public TTReportField KARAR1 { get {return Body().KARAR1;} }
            public TTReportShape NewLine111 { get {return Body().NewLine111;} }
            public TTReportShape NewLine1111 { get {return Body().NewLine1111;} }
            public TTReportField KARAR2 { get {return Body().KARAR2;} }
            public TTReportShape NewLine121 { get {return Body().NewLine121;} }
            public TTReportField K1 { get {return Body().K1;} }
            public TTReportField K2 { get {return Body().K2;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PARTBGroupBody(this);
            }

            public partial class PARTBGroupBody : TTReportSection
            {
                public HCThreeSpecialistReport_InformOD MyParentReport
                {
                    get { return (HCThreeSpecialistReport_InformOD)ParentReport; }
                }
                
                public TTReportField NewField121211;
                public TTReportField KARAR1;
                public TTReportShape NewLine111;
                public TTReportShape NewLine1111;
                public TTReportField KARAR2;
                public TTReportShape NewLine121;
                public TTReportField K1;
                public TTReportField K2; 
                public PARTBGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 38;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    NewField121211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 2, 198, 7, false);
                    NewField121211.Name = "NewField121211";
                    NewField121211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121211.TextFont.Bold = true;
                    NewField121211.TextFont.CharSet = 162;
                    NewField121211.Value = @"KARAR";

                    KARAR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 10, 196, 20, false);
                    KARAR1.Name = "KARAR1";
                    KARAR1.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR1.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR1.NoClip = EvetHayirEnum.ehEvet;
                    KARAR1.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR1.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR1.TextFont.CharSet = 162;
                    KARAR1.Value = @"Yukarıda bilgileri bulunan şahsın düzenlemiş olduğu bilgi formu ve __________________ tarihinde yapılan fizik muayenesi sonucunda  .....................................................................................................  engel bir durumu olmadığını bildirir hekim kanaat raporudur.";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 7, 14, 36, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 198, 7, 198, 36, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;

                    KARAR2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 24, 196, 34, false);
                    KARAR2.Name = "KARAR2";
                    KARAR2.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR2.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR2.NoClip = EvetHayirEnum.ehEvet;
                    KARAR2.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR2.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR2.TextFont.CharSet = 162;
                    KARAR2.Value = @"Yukarıda bilgileri bulunan şahsın düzenlemiş olduğu bilgi formu ve __________________ tarihinde yapılan fizik muayenesi sonucunda ileri tetkik için üst basamak bir sağlık kuruluşunda değerlendirilmesi uygundur.";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 36, 198, 36, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;

                    K1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 10, 21, 15, false);
                    K1.Name = "K1";
                    K1.DrawStyle = DrawStyleConstants.vbSolid;
                    K1.FieldType = ReportFieldTypeEnum.ftVariable;
                    K1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    K1.MultiLine = EvetHayirEnum.ehEvet;
                    K1.NoClip = EvetHayirEnum.ehEvet;
                    K1.WordBreak = EvetHayirEnum.ehEvet;
                    K1.ExpandTabs = EvetHayirEnum.ehEvet;
                    K1.TextFont.CharSet = 162;
                    K1.Value = @"";

                    K2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 24, 21, 29, false);
                    K2.Name = "K2";
                    K2.DrawStyle = DrawStyleConstants.vbSolid;
                    K2.FieldType = ReportFieldTypeEnum.ftVariable;
                    K2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    K2.MultiLine = EvetHayirEnum.ehEvet;
                    K2.NoClip = EvetHayirEnum.ehEvet;
                    K2.WordBreak = EvetHayirEnum.ehEvet;
                    K2.ExpandTabs = EvetHayirEnum.ehEvet;
                    K2.TextFont.CharSet = 162;
                    K2.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField121211.CalcValue = NewField121211.Value;
                    KARAR1.CalcValue = @"Yukarıda bilgileri bulunan şahsın düzenlemiş olduğu bilgi formu ve __________________ tarihinde yapılan fizik muayenesi sonucunda  .....................................................................................................  engel bir durumu olmadığını bildirir hekim kanaat raporudur.";
                    KARAR2.CalcValue = @"Yukarıda bilgileri bulunan şahsın düzenlemiş olduğu bilgi formu ve __________________ tarihinde yapılan fizik muayenesi sonucunda ileri tetkik için üst basamak bir sağlık kuruluşunda değerlendirilmesi uygundur.";
                    K1.CalcValue = @"";
                    K2.CalcValue = @"";
                    return new TTReportObject[] { NewField121211,KARAR1,KARAR2,K1,K2};
                }

                public override void RunScript()
                {
#region PARTB BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCThreeSpecialistReport_InformOD)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommitteeWithThreeSpecialist hcw = (HealthCommitteeWithThreeSpecialist)context.GetObject(new Guid(sObjectID), typeof(HealthCommitteeWithThreeSpecialist));

            if (hcw != null)
            {
                // Muayene Tarihi
                DateTime? muayeneTarihi = null;
                foreach (TTObjectState objectState in hcw.GetStateHistory())
                {
                    if (objectState.StateDefID == HealthCommitteeWithThreeSpecialist.States.New)
                    {
                        if (!muayeneTarihi.HasValue)
                            muayeneTarihi = objectState.BranchDate;
                        else if (objectState.BranchDate < muayeneTarihi.Value)
                            muayeneTarihi = objectState.BranchDate;
                    }
                }

                if (hcw.SituationInformODDecision.HasValue)
                {
                    string karar = "Yukarıda bilgileri bulunan şahsın düzenlemiş olduğu bilgi formu ve ";
                    if (muayeneTarihi.HasValue)
                        karar += muayeneTarihi.Value.ToShortDateString();
                    karar += " tarihinde yapılan fizik muayenesi sonucunda ";

                    if (hcw.SituationInformODDecision.Value == HCTSituationInformODDecisionEnum.NoObstacle)
                    {
                        if (!string.IsNullOrEmpty(hcw.NoObstacleDescription))
                            karar += hcw.NoObstacleDescription;
                        else
                            karar += "..........................................................................................................";

                        karar += " engel bir durumu olmadığını bildirir hekim kanaat raporudur.";

                        this.K1.CalcValue = "X";
                        this.KARAR1.CalcValue = karar;
                    }
                    else if (hcw.SituationInformODDecision.Value == HCTSituationInformODDecisionEnum.HigherHealthFoundation)
                    {
                        karar += "ileri tetkik için üst basamak bir sağlık kuruluşunda değerlendirilmesi uygundur.";
                        this.K2.CalcValue = "X";
                        this.KARAR2.CalcValue = karar;
                    }
                }
            }
#endregion PARTB BODY_Script
                }
            }

        }

        public PARTBGroup PARTB;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HCThreeSpecialistReport_InformOD()
        {
            TANI = new TANIGroup(this,"TANI");
            MAIN = new MAINGroup(TANI,"MAIN");
            PARTA = new PARTAGroup(TANI,"PARTA");
            PARTB = new PARTBGroup(TANI,"PARTB");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HCTHREESPECIALISTREPORT_INFORMOD";
            Caption = "Durum Bildirir Tek Hekim Sağlık Raporu";
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