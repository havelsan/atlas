
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
    /// İstirahat Raporu
    /// </summary>
    public partial class HCThreeSpecialistReport_Rest : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class TANIGroup : TTReportGroup
        {
            public HCThreeSpecialistReport_Rest MyParentReport
            {
                get { return (HCThreeSpecialistReport_Rest)ParentReport; }
            }

            new public TANIGroupHeader Header()
            {
                return (TANIGroupHeader)_header;
            }

            new public TANIGroupFooter Footer()
            {
                return (TANIGroupFooter)_footer;
            }

            public TTReportField RAPOR12 { get {return Header().RAPOR12;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField151411 { get {return Header().NewField151411;} }
            public TTReportField NewField1314121 { get {return Header().NewField1314121;} }
            public TTReportField NewField1114131 { get {return Header().NewField1114131;} }
            public TTReportField NewField1114141 { get {return Header().NewField1114141;} }
            public TTReportField NewField11214121 { get {return Header().NewField11214121;} }
            public TTReportField TCKIMLIKNO { get {return Header().TCKIMLIKNO;} }
            public TTReportField BABAADI { get {return Header().BABAADI;} }
            public TTReportField DOGUMTARIH { get {return Header().DOGUMTARIH;} }
            public TTReportField ADRES { get {return Header().ADRES;} }
            public TTReportField MEDULARAPORTAKIPNO { get {return Header().MEDULARAPORTAKIPNO;} }
            public TTReportField NewField1114151 { get {return Header().NewField1114151;} }
            public TTReportField NewField11414111 { get {return Header().NewField11414111;} }
            public TTReportField NewField111141211 { get {return Header().NewField111141211;} }
            public TTReportField NewField1414121 { get {return Header().NewField1414121;} }
            public TTReportField NewField11214141 { get {return Header().NewField11214141;} }
            public TTReportField NewField1414111 { get {return Header().NewField1414111;} }
            public TTReportField MUAYENETARIHI { get {return Header().MUAYENETARIHI;} }
            public TTReportField POLIKLINIK { get {return Header().POLIKLINIK;} }
            public TTReportField ONLINEPROTOKOLNO { get {return Header().ONLINEPROTOKOLNO;} }
            public TTReportField TELEFON { get {return Header().TELEFON;} }
            public TTReportField KURUM { get {return Header().KURUM;} }
            public TTReportField NewField11114111 { get {return Header().NewField11114111;} }
            public TTReportField NewField11214112 { get {return Header().NewField11214112;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField RAPORTARIHI { get {return Header().RAPORTARIHI;} }
            public TTReportField EVTELEFONU { get {return Header().EVTELEFONU;} }
            public TTReportField CEPTELEFONU { get {return Header().CEPTELEFONU;} }
            public TTReportField UZ2LBL { get {return Footer().UZ2LBL;} }
            public TTReportField UZ3LBL { get {return Footer().UZ3LBL;} }
            public TTReportField UZ { get {return Footer().UZ;} }
            public TTReportField ADSOYADDOC { get {return Footer().ADSOYADDOC;} }
            public TTReportField SINRUT { get {return Footer().SINRUT;} }
            public TTReportField ADSOYADDOC2 { get {return Footer().ADSOYADDOC2;} }
            public TTReportField UZ2 { get {return Footer().UZ2;} }
            public TTReportField SINRUT2 { get {return Footer().SINRUT2;} }
            public TTReportField ADSOYADDOC3 { get {return Footer().ADSOYADDOC3;} }
            public TTReportField UZ3 { get {return Footer().UZ3;} }
            public TTReportField SINRUT3 { get {return Footer().SINRUT3;} }
            public TTReportField NewField114311 { get {return Footer().NewField114311;} }
            public TTReportField UZEK1 { get {return Footer().UZEK1;} }
            public TTReportField ADSOYADEK1 { get {return Footer().ADSOYADEK1;} }
            public TTReportField SINRUTEK1 { get {return Footer().SINRUTEK1;} }
            public TTReportField ADSOYADEK2 { get {return Footer().ADSOYADEK2;} }
            public TTReportField UZEK2 { get {return Footer().UZEK2;} }
            public TTReportField SINRUTEK2 { get {return Footer().SINRUTEK2;} }
            public TTReportField EK1LBL { get {return Footer().EK1LBL;} }
            public TTReportField EK2LBL { get {return Footer().EK2LBL;} }
            public TTReportField SICILNO { get {return Footer().SICILNO;} }
            public TTReportField SICILNO2 { get {return Footer().SICILNO2;} }
            public TTReportField SICILNO3 { get {return Footer().SICILNO3;} }
            public TTReportField SICILNOEK1 { get {return Footer().SICILNOEK1;} }
            public TTReportField SICILNOEK2 { get {return Footer().SICILNOEK2;} }
            public TTReportField DIPLOMATESCILNO { get {return Footer().DIPLOMATESCILNO;} }
            public TTReportField DIPLOMATESCILNO2 { get {return Footer().DIPLOMATESCILNO2;} }
            public TTReportField DIPLOMATESCILNO3 { get {return Footer().DIPLOMATESCILNO3;} }
            public TTReportField DIPLOMATESCILNOEK1 { get {return Footer().DIPLOMATESCILNOEK1;} }
            public TTReportField DIPLOMATESCILNOEK2 { get {return Footer().DIPLOMATESCILNOEK2;} }
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
                public HCThreeSpecialistReport_Rest MyParentReport
                {
                    get { return (HCThreeSpecialistReport_Rest)ParentReport; }
                }
                
                public TTReportField RAPOR12;
                public TTReportField ADSOYAD;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField151411;
                public TTReportField NewField1314121;
                public TTReportField NewField1114131;
                public TTReportField NewField1114141;
                public TTReportField NewField11214121;
                public TTReportField TCKIMLIKNO;
                public TTReportField BABAADI;
                public TTReportField DOGUMTARIH;
                public TTReportField ADRES;
                public TTReportField MEDULARAPORTAKIPNO;
                public TTReportField NewField1114151;
                public TTReportField NewField11414111;
                public TTReportField NewField111141211;
                public TTReportField NewField1414121;
                public TTReportField NewField11214141;
                public TTReportField NewField1414111;
                public TTReportField MUAYENETARIHI;
                public TTReportField POLIKLINIK;
                public TTReportField ONLINEPROTOKOLNO;
                public TTReportField TELEFON;
                public TTReportField KURUM;
                public TTReportField NewField11114111;
                public TTReportField NewField11214112;
                public TTReportField RAPORNO;
                public TTReportField RAPORTARIHI;
                public TTReportField EVTELEFONU;
                public TTReportField CEPTELEFONU; 
                public TANIGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 100;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    RAPOR12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 29, 198, 34, false);
                    RAPOR12.Name = "RAPOR12";
                    RAPOR12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPOR12.VertAlign = VerticalAlignmentEnum.vaBottom;
                    RAPOR12.TextFont.Name = "Arial";
                    RAPOR12.TextFont.Bold = true;
                    RAPOR12.TextFont.CharSet = 162;
                    RAPOR12.Value = @"İSTİRAHAT RAPORU";

                    ADSOYAD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 42, 106, 48, false);
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

                    NewField151411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 42, 145, 48, false);
                    NewField151411.Name = "NewField151411";
                    NewField151411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField151411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField151411.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField151411.TextFont.CharSet = 162;
                    NewField151411.Value = @"TC KİMLİK NO";

                    NewField1314121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 42, 44, 48, false);
                    NewField1314121.Name = "NewField1314121";
                    NewField1314121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1314121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1314121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1314121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1314121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1314121.TextFont.CharSet = 162;
                    NewField1314121.Value = @"ADI SOYADI";

                    NewField1114131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 48, 44, 54, false);
                    NewField1114131.Name = "NewField1114131";
                    NewField1114131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1114131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1114131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1114131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1114131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1114131.TextFont.CharSet = 162;
                    NewField1114131.Value = @"BABA ADI";

                    NewField1114141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 54, 44, 60, false);
                    NewField1114141.Name = "NewField1114141";
                    NewField1114141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1114141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1114141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1114141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1114141.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1114141.TextFont.CharSet = 162;
                    NewField1114141.Value = @"DOĞUM TARİHİ";

                    NewField11214121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 90, 44, 99, false);
                    NewField11214121.Name = "NewField11214121";
                    NewField11214121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11214121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11214121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11214121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11214121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11214121.TextFont.CharSet = 162;
                    NewField11214121.Value = @"ADRES";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 42, 198, 48, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCKIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.TextFont.CharSet = 162;
                    TCKIMLIKNO.Value = @"{#UNIQUEREFNO#}";

                    BABAADI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 48, 106, 54, false);
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

                    DOGUMTARIH = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 54, 106, 60, false);
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

                    ADRES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 90, 198, 99, false);
                    ADRES.Name = "ADRES";
                    ADRES.DrawStyle = DrawStyleConstants.vbSolid;
                    ADRES.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRES.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ADRES.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADRES.MultiLine = EvetHayirEnum.ehEvet;
                    ADRES.WordBreak = EvetHayirEnum.ehEvet;
                    ADRES.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADRES.TextFont.CharSet = 162;
                    ADRES.Value = @"{#ADRES#}";

                    MEDULARAPORTAKIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 17, 248, 21, false);
                    MEDULARAPORTAKIPNO.Name = "MEDULARAPORTAKIPNO";
                    MEDULARAPORTAKIPNO.Visible = EvetHayirEnum.ehHayir;
                    MEDULARAPORTAKIPNO.FieldType = ReportFieldTypeEnum.ftExpression;
                    MEDULARAPORTAKIPNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MEDULARAPORTAKIPNO.VertAlign = VerticalAlignmentEnum.vaBottom;
                    MEDULARAPORTAKIPNO.TextFont.CharSet = 162;
                    MEDULARAPORTAKIPNO.Value = @"{#MEDULARAPORTAKIPNO#}";

                    NewField1114151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 37, 198, 42, false);
                    NewField1114151.Name = "NewField1114151";
                    NewField1114151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1114151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1114151.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1114151.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1114151.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1114151.TextFont.Bold = true;
                    NewField1114151.TextFont.CharSet = 162;
                    NewField1114151.Value = @"BAŞVURU SAHİBİNİN";

                    NewField11414111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 60, 44, 78, false);
                    NewField11414111.Name = "NewField11414111";
                    NewField11414111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11414111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11414111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11414111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11414111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11414111.TextFont.CharSet = 162;
                    NewField11414111.Value = @"SOSYAL GÜVENCESİ / KURUMU";

                    NewField111141211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 84, 44, 90, false);
                    NewField111141211.Name = "NewField111141211";
                    NewField111141211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111141211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111141211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111141211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111141211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111141211.TextFont.CharSet = 162;
                    NewField111141211.Value = @"TELEFON";

                    NewField1414121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 48, 145, 54, false);
                    NewField1414121.Name = "NewField1414121";
                    NewField1414121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1414121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1414121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1414121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1414121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1414121.TextFont.CharSet = 162;
                    NewField1414121.Value = @"MUAYENE TARİHİ";

                    NewField11214141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 54, 145, 72, false);
                    NewField11214141.Name = "NewField11214141";
                    NewField11214141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11214141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11214141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11214141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11214141.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11214141.TextFont.CharSet = 162;
                    NewField11214141.Value = @"POLİKLİNİK / SERVİS";

                    NewField1414111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 72, 145, 78, false);
                    NewField1414111.Name = "NewField1414111";
                    NewField1414111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1414111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1414111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1414111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1414111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1414111.TextFont.CharSet = 162;
                    NewField1414111.Value = @"ONLİNE PROTOKOL NO";

                    MUAYENETARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 48, 198, 54, false);
                    MUAYENETARIHI.Name = "MUAYENETARIHI";
                    MUAYENETARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    MUAYENETARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENETARIHI.TextFormat = @"dd/MM/yyyy";
                    MUAYENETARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MUAYENETARIHI.TextFont.CharSet = 162;
                    MUAYENETARIHI.Value = @"";

                    POLIKLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 54, 198, 72, false);
                    POLIKLINIK.Name = "POLIKLINIK";
                    POLIKLINIK.DrawStyle = DrawStyleConstants.vbSolid;
                    POLIKLINIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    POLIKLINIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    POLIKLINIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    POLIKLINIK.MultiLine = EvetHayirEnum.ehEvet;
                    POLIKLINIK.NoClip = EvetHayirEnum.ehEvet;
                    POLIKLINIK.WordBreak = EvetHayirEnum.ehEvet;
                    POLIKLINIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    POLIKLINIK.TextFont.CharSet = 162;
                    POLIKLINIK.Value = @"";

                    ONLINEPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 72, 198, 78, false);
                    ONLINEPROTOKOLNO.Name = "ONLINEPROTOKOLNO";
                    ONLINEPROTOKOLNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ONLINEPROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONLINEPROTOKOLNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ONLINEPROTOKOLNO.TextFont.CharSet = 162;
                    ONLINEPROTOKOLNO.Value = @"";

                    TELEFON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 84, 106, 90, false);
                    TELEFON.Name = "TELEFON";
                    TELEFON.DrawStyle = DrawStyleConstants.vbSolid;
                    TELEFON.FieldType = ReportFieldTypeEnum.ftVariable;
                    TELEFON.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TELEFON.TextFont.CharSet = 162;
                    TELEFON.Value = @"";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 60, 106, 78, false);
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

                    NewField11114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 84, 145, 90, false);
                    NewField11114111.Name = "NewField11114111";
                    NewField11114111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11114111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11114111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11114111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11114111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11114111.TextFont.CharSet = 162;
                    NewField11114111.Value = @"RAPOR NO";

                    NewField11214112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 78, 145, 84, false);
                    NewField11214112.Name = "NewField11214112";
                    NewField11214112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11214112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11214112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11214112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11214112.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11214112.TextFont.CharSet = 162;
                    NewField11214112.Value = @"RAPOR TARİHİ";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 84, 198, 90, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORNO.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORNO.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORNO.TextFont.CharSet = 162;
                    RAPORNO.Value = @"{#RAPORNO#}";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 78, 198, 84, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"dd/MM/yyyy";
                    RAPORTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORTARIHI.TextFont.CharSet = 162;
                    RAPORTARIHI.Value = @"{#RAPORTARIHI#}";

                    EVTELEFONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 23, 236, 27, false);
                    EVTELEFONU.Name = "EVTELEFONU";
                    EVTELEFONU.Visible = EvetHayirEnum.ehHayir;
                    EVTELEFONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVTELEFONU.TextFont.CharSet = 162;
                    EVTELEFONU.Value = @"{#HOMEPHONE#}";

                    CEPTELEFONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 29, 236, 33, false);
                    CEPTELEFONU.Name = "CEPTELEFONU";
                    CEPTELEFONU.Visible = EvetHayirEnum.ehHayir;
                    CEPTELEFONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    CEPTELEFONU.TextFont.CharSet = 162;
                    CEPTELEFONU.Value = @"{#MOBILEPHONE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class dataset_GetHCWithThreeSpecialist = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class>(0);
                    RAPOR12.CalcValue = RAPOR12.Value;
                    ADSOYAD.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Patientid) : "");
                    ADSOYAD.PostFieldValueCalculation();
                    NewField151411.CalcValue = NewField151411.Value;
                    NewField1314121.CalcValue = NewField1314121.Value;
                    NewField1114131.CalcValue = NewField1114131.Value;
                    NewField1114141.CalcValue = NewField1114141.Value;
                    NewField11214121.CalcValue = NewField11214121.Value;
                    TCKIMLIKNO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.UniqueRefNo) : "");
                    BABAADI.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.FatherName) : "");
                    DOGUMTARIH.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Dtarihi) : "");
                    ADRES.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Adres) : "");
                    NewField1114151.CalcValue = NewField1114151.Value;
                    NewField11414111.CalcValue = NewField11414111.Value;
                    NewField111141211.CalcValue = NewField111141211.Value;
                    NewField1414121.CalcValue = NewField1414121.Value;
                    NewField11214141.CalcValue = NewField11214141.Value;
                    NewField1414111.CalcValue = NewField1414111.Value;
                    MUAYENETARIHI.CalcValue = @"";
                    POLIKLINIK.CalcValue = @"";
                    ONLINEPROTOKOLNO.CalcValue = @"";
                    TELEFON.CalcValue = @"";
                    KURUM.CalcValue = @"";
                    NewField11114111.CalcValue = NewField11114111.Value;
                    NewField11214112.CalcValue = NewField11214112.Value;
                    RAPORNO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Raporno) : "");
                    RAPORTARIHI.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Raportarihi) : "");
                    EVTELEFONU.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Homephone) : "");
                    CEPTELEFONU.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Mobilephone) : "");
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    MEDULARAPORTAKIPNO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.MedulaRaporTakipNo) : "");
                    return new TTReportObject[] { RAPOR12,ADSOYAD,NewField151411,NewField1314121,NewField1114131,NewField1114141,NewField11214121,TCKIMLIKNO,BABAADI,DOGUMTARIH,ADRES,NewField1114151,NewField11414111,NewField111141211,NewField1414121,NewField11214141,NewField1414111,MUAYENETARIHI,POLIKLINIK,ONLINEPROTOKOLNO,TELEFON,KURUM,NewField11114111,NewField11214112,RAPORNO,RAPORTARIHI,EVTELEFONU,CEPTELEFONU,XXXXXXBASLIK,MEDULARAPORTAKIPNO};
                }

                public override void RunScript()
                {
#region TANI HEADER_Script
                    /*  TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCThreeSpecialistReport_Rest)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
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

                if (muayeneTarihi.HasValue)
                    this.MUAYENETARIHI.CalcValue = muayeneTarihi.ToString();

                // Poliklinik / Servis
                if (hcw.Department != null && (hcw.Department is ResPoliclinic || hcw.Department is ResClinic))
                    this.POLIKLINIK.CalcValue = hcw.Department.Name;
                else
                {
                    foreach (HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid threeSpecialist in hcw.Specialists)
                    {
                        if (threeSpecialist.ResSectionOfSpecialist2 != null && (threeSpecialist.ResSectionOfSpecialist2 is ResPoliclinic || threeSpecialist.ResSectionOfSpecialist2 is ResClinic))
                        {
                            this.POLIKLINIK.CalcValue = threeSpecialist.ResSectionOfSpecialist2.Name;
                            break;
                        }
                        else if (threeSpecialist.ResSectionOfSpecialist3 != null && (threeSpecialist.ResSectionOfSpecialist3 is ResPoliclinic || threeSpecialist.ResSectionOfSpecialist3 is ResClinic))
                        {
                            this.POLIKLINIK.CalcValue = threeSpecialist.ResSectionOfSpecialist3.Name;
                            break;
                        }
                    }
                }

                // Sosyal Güvencesi / Kurumu
                EpisodeProtocol tempEP = null;
                foreach (EpisodeProtocol ep in hcw.Episode.EpisodeProtocols)
                {
                    if (tempEP == null)
                        tempEP = ep;
                    else if (tempEP.OpeningDate.HasValue && ep.OpeningDate.HasValue && tempEP.OpeningDate.Value < ep.OpeningDate.Value)
                        tempEP = ep;
                }

                if (tempEP != null && tempEP.Payer != null)
                {
                    this.KURUM.CalcValue = tempEP.Payer.Name.ToUpper();
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
            */
#endregion TANI HEADER_Script
                }
            }
            public partial class TANIGroupFooter : TTReportSection
            {
                public HCThreeSpecialistReport_Rest MyParentReport
                {
                    get { return (HCThreeSpecialistReport_Rest)ParentReport; }
                }
                
                public TTReportField UZ2LBL;
                public TTReportField UZ3LBL;
                public TTReportField UZ;
                public TTReportField ADSOYADDOC;
                public TTReportField SINRUT;
                public TTReportField ADSOYADDOC2;
                public TTReportField UZ2;
                public TTReportField SINRUT2;
                public TTReportField ADSOYADDOC3;
                public TTReportField UZ3;
                public TTReportField SINRUT3;
                public TTReportField NewField114311;
                public TTReportField UZEK1;
                public TTReportField ADSOYADEK1;
                public TTReportField SINRUTEK1;
                public TTReportField ADSOYADEK2;
                public TTReportField UZEK2;
                public TTReportField SINRUTEK2;
                public TTReportField EK1LBL;
                public TTReportField EK2LBL;
                public TTReportField SICILNO;
                public TTReportField SICILNO2;
                public TTReportField SICILNO3;
                public TTReportField SICILNOEK1;
                public TTReportField SICILNOEK2;
                public TTReportField DIPLOMATESCILNO;
                public TTReportField DIPLOMATESCILNO2;
                public TTReportField DIPLOMATESCILNO3;
                public TTReportField DIPLOMATESCILNOEK1;
                public TTReportField DIPLOMATESCILNOEK2; 
                public TANIGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 91;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    UZ2LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 4, 87, 8, false);
                    UZ2LBL.Name = "UZ2LBL";
                    UZ2LBL.Visible = EvetHayirEnum.ehHayir;
                    UZ2LBL.TextFont.Bold = true;
                    UZ2LBL.TextFont.Underline = true;
                    UZ2LBL.TextFont.CharSet = 162;
                    UZ2LBL.Value = @"İMZA";

                    UZ3LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 4, 151, 8, false);
                    UZ3LBL.Name = "UZ3LBL";
                    UZ3LBL.Visible = EvetHayirEnum.ehHayir;
                    UZ3LBL.TextFont.Bold = true;
                    UZ3LBL.TextFont.Underline = true;
                    UZ3LBL.TextFont.CharSet = 162;
                    UZ3LBL.Value = @"İMZA";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 26, 71, 30, false);
                    UZ.Name = "UZ";
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.TextFont.Size = 8;
                    UZ.TextFont.CharSet = 162;
                    UZ.Value = @"";

                    ADSOYADDOC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 10, 71, 14, false);
                    ADSOYADDOC.Name = "ADSOYADDOC";
                    ADSOYADDOC.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC.TextFont.Size = 8;
                    ADSOYADDOC.TextFont.CharSet = 162;
                    ADSOYADDOC.Value = @"";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 14, 71, 18, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.TextFont.Size = 8;
                    SINRUT.TextFont.CharSet = 162;
                    SINRUT.Value = @"";

                    ADSOYADDOC2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 10, 135, 14, false);
                    ADSOYADDOC2.Name = "ADSOYADDOC2";
                    ADSOYADDOC2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC2.TextFont.Size = 8;
                    ADSOYADDOC2.TextFont.CharSet = 162;
                    ADSOYADDOC2.Value = @"";

                    UZ2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 26, 135, 30, false);
                    UZ2.Name = "UZ2";
                    UZ2.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ2.MultiLine = EvetHayirEnum.ehEvet;
                    UZ2.NoClip = EvetHayirEnum.ehEvet;
                    UZ2.WordBreak = EvetHayirEnum.ehEvet;
                    UZ2.TextFont.Size = 8;
                    UZ2.TextFont.CharSet = 162;
                    UZ2.Value = @"";

                    SINRUT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 14, 135, 18, false);
                    SINRUT2.Name = "SINRUT2";
                    SINRUT2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT2.TextFont.Size = 8;
                    SINRUT2.TextFont.CharSet = 162;
                    SINRUT2.Value = @"";

                    ADSOYADDOC3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 10, 198, 14, false);
                    ADSOYADDOC3.Name = "ADSOYADDOC3";
                    ADSOYADDOC3.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC3.TextFont.Size = 8;
                    ADSOYADDOC3.TextFont.CharSet = 162;
                    ADSOYADDOC3.Value = @"";

                    UZ3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 26, 198, 30, false);
                    UZ3.Name = "UZ3";
                    UZ3.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ3.MultiLine = EvetHayirEnum.ehEvet;
                    UZ3.NoClip = EvetHayirEnum.ehEvet;
                    UZ3.WordBreak = EvetHayirEnum.ehEvet;
                    UZ3.TextFont.Size = 8;
                    UZ3.TextFont.CharSet = 162;
                    UZ3.Value = @"";

                    SINRUT3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 14, 198, 18, false);
                    SINRUT3.Name = "SINRUT3";
                    SINRUT3.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT3.TextFont.Size = 8;
                    SINRUT3.TextFont.CharSet = 162;
                    SINRUT3.Value = @"";

                    NewField114311 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 4, 52, 8, false);
                    NewField114311.Name = "NewField114311";
                    NewField114311.TextFont.Bold = true;
                    NewField114311.TextFont.Underline = true;
                    NewField114311.TextFont.CharSet = 162;
                    NewField114311.Value = @"DÜZENLEYEN TABİP";

                    UZEK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 57, 71, 61, false);
                    UZEK1.Name = "UZEK1";
                    UZEK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZEK1.MultiLine = EvetHayirEnum.ehEvet;
                    UZEK1.NoClip = EvetHayirEnum.ehEvet;
                    UZEK1.WordBreak = EvetHayirEnum.ehEvet;
                    UZEK1.TextFont.Size = 8;
                    UZEK1.TextFont.CharSet = 162;
                    UZEK1.Value = @"";

                    ADSOYADEK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 41, 71, 45, false);
                    ADSOYADEK1.Name = "ADSOYADEK1";
                    ADSOYADEK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADEK1.TextFont.Size = 8;
                    ADSOYADEK1.TextFont.CharSet = 162;
                    ADSOYADEK1.Value = @"";

                    SINRUTEK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 45, 71, 49, false);
                    SINRUTEK1.Name = "SINRUTEK1";
                    SINRUTEK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUTEK1.TextFont.Size = 8;
                    SINRUTEK1.TextFont.CharSet = 162;
                    SINRUTEK1.Value = @"";

                    ADSOYADEK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 41, 135, 45, false);
                    ADSOYADEK2.Name = "ADSOYADEK2";
                    ADSOYADEK2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADEK2.TextFont.Size = 8;
                    ADSOYADEK2.TextFont.CharSet = 162;
                    ADSOYADEK2.Value = @"";

                    UZEK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 57, 135, 61, false);
                    UZEK2.Name = "UZEK2";
                    UZEK2.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZEK2.MultiLine = EvetHayirEnum.ehEvet;
                    UZEK2.NoClip = EvetHayirEnum.ehEvet;
                    UZEK2.WordBreak = EvetHayirEnum.ehEvet;
                    UZEK2.TextFont.Size = 8;
                    UZEK2.TextFont.CharSet = 162;
                    UZEK2.Value = @"";

                    SINRUTEK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 45, 135, 49, false);
                    SINRUTEK2.Name = "SINRUTEK2";
                    SINRUTEK2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUTEK2.TextFont.Size = 8;
                    SINRUTEK2.TextFont.CharSet = 162;
                    SINRUTEK2.Value = @"";

                    EK1LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 35, 52, 39, false);
                    EK1LBL.Name = "EK1LBL";
                    EK1LBL.Visible = EvetHayirEnum.ehHayir;
                    EK1LBL.TextFont.Bold = true;
                    EK1LBL.TextFont.Underline = true;
                    EK1LBL.TextFont.CharSet = 162;
                    EK1LBL.Value = @"İMZA";

                    EK2LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 35, 116, 39, false);
                    EK2LBL.Name = "EK2LBL";
                    EK2LBL.Visible = EvetHayirEnum.ehHayir;
                    EK2LBL.TextFont.Bold = true;
                    EK2LBL.TextFont.Underline = true;
                    EK2LBL.TextFont.CharSet = 162;
                    EK2LBL.Value = @"İMZA";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 18, 71, 22, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO.NoClip = EvetHayirEnum.ehEvet;
                    SICILNO.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO.TextFont.Size = 8;
                    SICILNO.TextFont.CharSet = 162;
                    SICILNO.Value = @"";

                    SICILNO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 18, 135, 22, false);
                    SICILNO2.Name = "SICILNO2";
                    SICILNO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO2.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO2.NoClip = EvetHayirEnum.ehEvet;
                    SICILNO2.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO2.TextFont.Size = 8;
                    SICILNO2.TextFont.CharSet = 162;
                    SICILNO2.Value = @"";

                    SICILNO3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 18, 198, 22, false);
                    SICILNO3.Name = "SICILNO3";
                    SICILNO3.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO3.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO3.NoClip = EvetHayirEnum.ehEvet;
                    SICILNO3.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO3.TextFont.Size = 8;
                    SICILNO3.TextFont.CharSet = 162;
                    SICILNO3.Value = @"";

                    SICILNOEK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 49, 71, 53, false);
                    SICILNOEK1.Name = "SICILNOEK1";
                    SICILNOEK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNOEK1.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNOEK1.NoClip = EvetHayirEnum.ehEvet;
                    SICILNOEK1.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNOEK1.TextFont.Size = 8;
                    SICILNOEK1.TextFont.CharSet = 162;
                    SICILNOEK1.Value = @"";

                    SICILNOEK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 49, 135, 53, false);
                    SICILNOEK2.Name = "SICILNOEK2";
                    SICILNOEK2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNOEK2.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNOEK2.NoClip = EvetHayirEnum.ehEvet;
                    SICILNOEK2.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNOEK2.TextFont.Size = 8;
                    SICILNOEK2.TextFont.CharSet = 162;
                    SICILNOEK2.Value = @"";

                    DIPLOMATESCILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 22, 71, 26, false);
                    DIPLOMATESCILNO.Name = "DIPLOMATESCILNO";
                    DIPLOMATESCILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMATESCILNO.MultiLine = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO.NoClip = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO.WordBreak = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO.TextFont.Size = 8;
                    DIPLOMATESCILNO.TextFont.CharSet = 162;
                    DIPLOMATESCILNO.Value = @"";

                    DIPLOMATESCILNO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 22, 135, 26, false);
                    DIPLOMATESCILNO2.Name = "DIPLOMATESCILNO2";
                    DIPLOMATESCILNO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMATESCILNO2.MultiLine = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO2.NoClip = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO2.WordBreak = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO2.TextFont.Size = 8;
                    DIPLOMATESCILNO2.TextFont.CharSet = 162;
                    DIPLOMATESCILNO2.Value = @"";

                    DIPLOMATESCILNO3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 22, 198, 26, false);
                    DIPLOMATESCILNO3.Name = "DIPLOMATESCILNO3";
                    DIPLOMATESCILNO3.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMATESCILNO3.MultiLine = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO3.NoClip = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO3.WordBreak = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO3.TextFont.Size = 8;
                    DIPLOMATESCILNO3.TextFont.CharSet = 162;
                    DIPLOMATESCILNO3.Value = @"";

                    DIPLOMATESCILNOEK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 53, 71, 57, false);
                    DIPLOMATESCILNOEK1.Name = "DIPLOMATESCILNOEK1";
                    DIPLOMATESCILNOEK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMATESCILNOEK1.MultiLine = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNOEK1.NoClip = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNOEK1.WordBreak = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNOEK1.TextFont.Size = 8;
                    DIPLOMATESCILNOEK1.TextFont.CharSet = 162;
                    DIPLOMATESCILNOEK1.Value = @"";

                    DIPLOMATESCILNOEK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 53, 135, 57, false);
                    DIPLOMATESCILNOEK2.Name = "DIPLOMATESCILNOEK2";
                    DIPLOMATESCILNOEK2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMATESCILNOEK2.MultiLine = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNOEK2.NoClip = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNOEK2.WordBreak = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNOEK2.TextFont.Size = 8;
                    DIPLOMATESCILNOEK2.TextFont.CharSet = 162;
                    DIPLOMATESCILNOEK2.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class dataset_GetHCWithThreeSpecialist = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class>(0);
                    UZ2LBL.CalcValue = UZ2LBL.Value;
                    UZ3LBL.CalcValue = UZ3LBL.Value;
                    UZ.CalcValue = @"";
                    ADSOYADDOC.CalcValue = @"";
                    SINRUT.CalcValue = @"";
                    ADSOYADDOC2.CalcValue = @"";
                    UZ2.CalcValue = @"";
                    SINRUT2.CalcValue = @"";
                    ADSOYADDOC3.CalcValue = @"";
                    UZ3.CalcValue = @"";
                    SINRUT3.CalcValue = @"";
                    NewField114311.CalcValue = NewField114311.Value;
                    UZEK1.CalcValue = @"";
                    ADSOYADEK1.CalcValue = @"";
                    SINRUTEK1.CalcValue = @"";
                    ADSOYADEK2.CalcValue = @"";
                    UZEK2.CalcValue = @"";
                    SINRUTEK2.CalcValue = @"";
                    EK1LBL.CalcValue = EK1LBL.Value;
                    EK2LBL.CalcValue = EK2LBL.Value;
                    SICILNO.CalcValue = @"";
                    SICILNO2.CalcValue = @"";
                    SICILNO3.CalcValue = @"";
                    SICILNOEK1.CalcValue = @"";
                    SICILNOEK2.CalcValue = @"";
                    DIPLOMATESCILNO.CalcValue = @"";
                    DIPLOMATESCILNO2.CalcValue = @"";
                    DIPLOMATESCILNO3.CalcValue = @"";
                    DIPLOMATESCILNOEK1.CalcValue = @"";
                    DIPLOMATESCILNOEK2.CalcValue = @"";
                    return new TTReportObject[] { UZ2LBL,UZ3LBL,UZ,ADSOYADDOC,SINRUT,ADSOYADDOC2,UZ2,SINRUT2,ADSOYADDOC3,UZ3,SINRUT3,NewField114311,UZEK1,ADSOYADEK1,SINRUTEK1,ADSOYADEK2,UZEK2,SINRUTEK2,EK1LBL,EK2LBL,SICILNO,SICILNO2,SICILNO3,SICILNOEK1,SICILNOEK2,DIPLOMATESCILNO,DIPLOMATESCILNO2,DIPLOMATESCILNO3,DIPLOMATESCILNOEK1,DIPLOMATESCILNOEK2};
                }

                public override void RunScript()
                {
#region TANI FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCThreeSpecialistReport_Rest)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
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
                    this.ADSOYADDOC.CalcValue = hcw.Specialists[0].Specialist1.Name;
                    //string sClassRank = hcw.Specialists[0].Specialist1.MilitaryClass != null ? hcw.Specialists[0].Specialist1.MilitaryClass.ShortName : "";
                    string sForce1 = hcw.Specialists[0].Specialist1.ForcesCommand != null ? hcw.Specialists[0].Specialist1.ForcesCommand.Qref : "";
                    string sRank1 = hcw.Specialists[0].Specialist1.Rank != null ? hcw.Specialists[0].Specialist1.Rank.ShortName : "";
                    string sTitle1 = hcw.Specialists[0].Specialist1.Title.HasValue ? TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(hcw.Specialists[0].Specialist1.Title.Value) : "";
                    this.SINRUT.CalcValue = sTitle1 + sForce1 + sRank1;

                    //if(TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "")=="TRUE")
                    this.SICILNO.CalcValue = "Sicil No : " + hcw.Specialists[0].Specialist1.EmploymentRecordID;
                    //else
                    //    this.SICILNO.CalcValue = "(" + hcw.Specialists[0].Specialist1.DiplomaRegisterNo + ")";
                    this.DIPLOMATESCILNO.CalcValue = "Diploma Tescil No : " + hcw.Specialists[0].Specialist1.DiplomaRegisterNo;

                    if (hcw.Specialists[0].Specialist1.GetSpeciality() != null)
                        sMemberSpeciality = hcw.Specialists[0].Specialist1.GetSpeciality().Name + " Uzm.";
                    else
                        sMemberSpeciality = "";

                    this.UZ.CalcValue = sMemberSpeciality;
                }
                if(hcw.Specialists[0].Specialist2 != null)
                {
                    this.ADSOYADDOC2.CalcValue = hcw.Specialists[0].Specialist2.Name;
                    //string sClassRank2 = hcw.Specialists[0].Specialist2.MilitaryClass != null ? hcw.Specialists[0].Specialist2.MilitaryClass.ShortName : "";
                    string sForce2 = hcw.Specialists[0].Specialist2.ForcesCommand != null ? hcw.Specialists[0].Specialist2.ForcesCommand.Qref : "";
                    string sRank2 = hcw.Specialists[0].Specialist2.Rank != null ? hcw.Specialists[0].Specialist2.Rank.ShortName : "";
                    string sTitle2 = hcw.Specialists[0].Specialist2.Title.HasValue ? TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(hcw.Specialists[0].Specialist2.Title.Value) : "";
                    this.SINRUT2.CalcValue = sTitle2 + sForce2 + sRank2;

                    //if(TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "")=="TRUE")
                    this.SICILNO2.CalcValue = "Sicil No : " + hcw.Specialists[0].Specialist2.EmploymentRecordID;
                    //else
                    //    this.SICILNO2.CalcValue = "(" + hcw.Specialists[0].Specialist2.DiplomaRegisterNo + ")";
                    this.DIPLOMATESCILNO2.CalcValue = "Diploma Tescil No : " + hcw.Specialists[0].Specialist2.DiplomaRegisterNo;

                    if (hcw.Specialists[0].Specialist2.GetSpeciality() != null)
                        sMemberSpeciality = hcw.Specialists[0].Specialist2.GetSpeciality().Name + " Uzm.";
                    else
                        sMemberSpeciality = "";
                    this.UZ2.CalcValue = sMemberSpeciality;
                    this.UZ2LBL.Visible = EvetHayirEnum.ehEvet;
                }
                if(hcw.Specialists[0].Specialist3 != null)
                {
                    this.ADSOYADDOC3.CalcValue = hcw.Specialists[0].Specialist3.Name;
                    //string sClassRank3 = hcw.Specialists[0].Specialist3.MilitaryClass != null ? hcw.Specialists[0].Specialist3.MilitaryClass.ShortName : "";
                    string sForce3 = hcw.Specialists[0].Specialist3.ForcesCommand != null ? hcw.Specialists[0].Specialist3.ForcesCommand.Qref : "";
                    string sRank3 = hcw.Specialists[0].Specialist3.Rank != null ? hcw.Specialists[0].Specialist3.Rank.ShortName : "";
                    string sTitle3 = hcw.Specialists[0].Specialist3.Title.HasValue ? TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(hcw.Specialists[0].Specialist3.Title.Value) : "";
                    this.SINRUT3.CalcValue = sTitle3 + sForce3 + sRank3;

                    //if(TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "")=="TRUE")
                    this.SICILNO3.CalcValue = "Sicil No : " + hcw.Specialists[0].Specialist3.EmploymentRecordID;
                    //else
                    //    this.SICILNO3.CalcValue = "(" + hcw.Specialists[0].Specialist3.DiplomaRegisterNo + ")";
                    this.DIPLOMATESCILNO3.CalcValue = "Diploma Tescil No : " + hcw.Specialists[0].Specialist3.DiplomaRegisterNo;

                    if (hcw.Specialists[0].Specialist3.GetSpeciality() != null)
                        sMemberSpeciality = hcw.Specialists[0].Specialist3.GetSpeciality().Name + " Uzm.";
                    else
                        sMemberSpeciality = "";
                    this.UZ3.CalcValue = sMemberSpeciality;
                    this.UZ3LBL.Visible = EvetHayirEnum.ehEvet;
                }
            }
            if (hcw.AdditionalSpecialist1 != null)
            {
                this.ADSOYADEK1.CalcValue = hcw.AdditionalSpecialist1.Name;
                string sForce4 = hcw.AdditionalSpecialist1.ForcesCommand != null ? hcw.AdditionalSpecialist1.ForcesCommand.Qref : "";
                string sRank4 = hcw.AdditionalSpecialist1.Rank != null ? hcw.AdditionalSpecialist1.Rank.ShortName : "";
                string sTitle4 = hcw.AdditionalSpecialist1.Title.HasValue ? TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(hcw.AdditionalSpecialist1.Title.Value) : "";
                this.SINRUTEK1.CalcValue = sTitle4 + sForce4 + sRank4;

                //if(TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "")=="TRUE")
                this.SICILNOEK1.CalcValue = "Sicil No : " + hcw.AdditionalSpecialist1.EmploymentRecordID;
                //else
                //    this.SICILNOEK1.CalcValue = "(" + hcw.AdditionalSpecialist1.DiplomaRegisterNo + ")";
                this.DIPLOMATESCILNOEK1.CalcValue = "Diploma Tescil No : " + hcw.AdditionalSpecialist1.DiplomaRegisterNo;

                if (hcw.AdditionalSpecialist1.GetSpeciality() != null)
                    sMemberSpeciality = hcw.AdditionalSpecialist1.GetSpeciality().Name + " Uzm.";
                else
                    sMemberSpeciality = "";
                this.UZEK1.CalcValue = sMemberSpeciality;
                this.EK1LBL.Visible = EvetHayirEnum.ehEvet;
            }

            if (hcw.AdditionalSpecialist2 != null)
            {
                this.ADSOYADEK2.CalcValue = hcw.AdditionalSpecialist2.Name;
                string sForce5 = hcw.AdditionalSpecialist2.ForcesCommand != null ? hcw.AdditionalSpecialist2.ForcesCommand.Qref : "";
                string sRank5 = hcw.AdditionalSpecialist2.Rank != null ? hcw.AdditionalSpecialist2.Rank.ShortName : "";
                string sTitle5 = hcw.AdditionalSpecialist2.Title.HasValue ? TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(hcw.AdditionalSpecialist2.Title.Value) : "";
                this.SINRUTEK2.CalcValue = sTitle5 + sForce5 + sRank5;

                //if(TTObjectClasses.SystemParameter.GetParameterValue("SICILKULLAN", "")=="TRUE")
                this.SICILNOEK2.CalcValue = "Sicil No : " + hcw.AdditionalSpecialist2.EmploymentRecordID;
                //else
                //    this.SICILNOEK2.CalcValue = "(" + hcw.AdditionalSpecialist2.DiplomaRegisterNo + ")";
                this.DIPLOMATESCILNOEK2.CalcValue = "Diploma Tescil No : " + hcw.AdditionalSpecialist2.DiplomaRegisterNo;

                if (hcw.AdditionalSpecialist2.GetSpeciality() != null)
                    sMemberSpeciality = hcw.AdditionalSpecialist2.GetSpeciality().Name + " Uzm.";
                else
                    sMemberSpeciality = "";
                this.UZEK2.CalcValue = sMemberSpeciality;
                this.EK2LBL.Visible = EvetHayirEnum.ehEvet;
            }
#endregion TANI FOOTER_Script
                }
            }

        }

        public TANIGroup TANI;

        public partial class MAINGroup : TTReportGroup
        {
            public HCThreeSpecialistReport_Rest MyParentReport
            {
                get { return (HCThreeSpecialistReport_Rest)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField121 { get {return Body().NewField121;} }
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
                public HCThreeSpecialistReport_Rest MyParentReport
                {
                    get { return (HCThreeSpecialistReport_Rest)ParentReport; }
                }
                
                public TTReportField NewField121;
                public TTReportField TANI; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 34;
                    RepeatCount = 0;
                    
                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 2, 198, 7, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"ICD KODU VE TANI(LAR)";

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 7, 198, 32, false);
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
                    NewField121.CalcValue = NewField121.Value;
                    TANI.CalcValue = @"";
                    return new TTReportObject[] { NewField121,TANI};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
                    string sObjectID = ((HCThreeSpecialistReport_Rest)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
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
            public HCThreeSpecialistReport_Rest MyParentReport
            {
                get { return (HCThreeSpecialistReport_Rest)ParentReport; }
            }

            new public PARTAGroupBody Body()
            {
                return (PARTAGroupBody)_body;
            }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public TTReportField NewField11211 { get {return Body().NewField11211;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportField KARAR1 { get {return Body().KARAR1;} }
            public TTReportField KARAR11 { get {return Body().KARAR11;} }
            public TTReportShape NewLine2 { get {return Body().NewLine2;} }
            public TTReportField K1 { get {return Body().K1;} }
            public TTReportField K2 { get {return Body().K2;} }
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
                public HCThreeSpecialistReport_Rest MyParentReport
                {
                    get { return (HCThreeSpecialistReport_Rest)ParentReport; }
                }
                
                public TTReportField KARAR;
                public TTReportField NewField11211;
                public TTReportShape NewLine1;
                public TTReportShape NewLine11;
                public TTReportField KARAR1;
                public TTReportField KARAR11;
                public TTReportShape NewLine2;
                public TTReportField K1;
                public TTReportField K2; 
                public PARTAGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 30;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 9, 193, 14, false);
                    KARAR.Name = "KARAR";
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR.NoClip = EvetHayirEnum.ehEvet;
                    KARAR.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR.TextFont.CharSet = 162;
                    KARAR.Value = @"........./........./.........  den  ........./........./......... tarihine kadar istirahatlidir.      ........../........./......... tarihinde;";

                    NewField11211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 2, 198, 7, false);
                    NewField11211.Name = "NewField11211";
                    NewField11211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11211.TextFont.Bold = true;
                    NewField11211.TextFont.CharSet = 162;
                    NewField11211.Value = @"KARAR";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 7, 14, 28, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 198, 7, 198, 28, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;

                    KARAR1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 15, 51, 20, false);
                    KARAR1.Name = "KARAR1";
                    KARAR1.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR1.NoClip = EvetHayirEnum.ehEvet;
                    KARAR1.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR1.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR1.TextFont.CharSet = 162;
                    KARAR1.Value = @"çalışır.";

                    KARAR11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 21, 51, 26, false);
                    KARAR11.Name = "KARAR11";
                    KARAR11.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR11.NoClip = EvetHayirEnum.ehEvet;
                    KARAR11.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR11.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR11.TextFont.CharSet = 162;
                    KARAR11.Value = @"kontrol önerilir.";

                    NewLine2 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 28, 198, 28, false);
                    NewLine2.Name = "NewLine2";
                    NewLine2.DrawStyle = DrawStyleConstants.vbSolid;

                    K1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 15, 23, 20, false);
                    K1.Name = "K1";
                    K1.DrawStyle = DrawStyleConstants.vbSolid;
                    K1.FieldType = ReportFieldTypeEnum.ftVariable;
                    K1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    K1.MultiLine = EvetHayirEnum.ehEvet;
                    K1.NoClip = EvetHayirEnum.ehEvet;
                    K1.WordBreak = EvetHayirEnum.ehEvet;
                    K1.ExpandTabs = EvetHayirEnum.ehEvet;
                    K1.TextFont.Name = "Arial";
                    K1.TextFont.CharSet = 162;
                    K1.Value = @"";

                    K2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 18, 21, 23, 26, false);
                    K2.Name = "K2";
                    K2.DrawStyle = DrawStyleConstants.vbSolid;
                    K2.FieldType = ReportFieldTypeEnum.ftVariable;
                    K2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    K2.MultiLine = EvetHayirEnum.ehEvet;
                    K2.NoClip = EvetHayirEnum.ehEvet;
                    K2.WordBreak = EvetHayirEnum.ehEvet;
                    K2.ExpandTabs = EvetHayirEnum.ehEvet;
                    K2.TextFont.Name = "Arial";
                    K2.TextFont.CharSet = 162;
                    K2.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    KARAR.CalcValue = @"........./........./.........  den  ........./........./......... tarihine kadar istirahatlidir.      ........../........./......... tarihinde;";
                    NewField11211.CalcValue = NewField11211.Value;
                    KARAR1.CalcValue = KARAR1.Value;
                    KARAR11.CalcValue = KARAR11.Value;
                    K1.CalcValue = @"";
                    K2.CalcValue = @"";
                    return new TTReportObject[] { KARAR,NewField11211,KARAR1,KARAR11,K1,K2};
                }

                public override void RunScript()
                {
#region PARTA BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCThreeSpecialistReport_Rest)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommitteeWithThreeSpecialist hcw = (HealthCommitteeWithThreeSpecialist)context.GetObject(new Guid(sObjectID), typeof(HealthCommitteeWithThreeSpecialist));

            if (hcw != null)
            {
                string karar = string.Empty;
                if (hcw.ReportStartDate.HasValue)
                    karar += hcw.ReportStartDate.Value.ToShortDateString();

                karar += " den ";

                if (hcw.ReportEndDate.HasValue)
                    karar += hcw.ReportEndDate.Value.ToShortDateString();

                karar += " tarihine kadar istirahatlidir.  ";

                if (hcw.DecisionDate.HasValue)
                    karar += hcw.DecisionDate.Value.ToShortDateString();

                karar += " tarihinde ;";
                this.KARAR.CalcValue = karar;

                if (hcw.RestReportDecision.HasValue)
                {
                    if (hcw.RestReportDecision.Value == HCTRestReportDecisionTypeEnum.Works)
                        this.K1.CalcValue = "X";
                    else if (hcw.RestReportDecision.Value == HCTRestReportDecisionTypeEnum.ControlSuggested)
                        this.K2.CalcValue = "X";
                }
            }
#endregion PARTA BODY_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public HCThreeSpecialistReport_Rest MyParentReport
            {
                get { return (HCThreeSpecialistReport_Rest)ParentReport; }
            }

            new public PARTBGroupBody Body()
            {
                return (PARTBGroupBody)_body;
            }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
            public TTReportField ACIKLAMA { get {return Body().ACIKLAMA;} }
            public TTReportField MADDE { get {return Body().MADDE;} }
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
                public HCThreeSpecialistReport_Rest MyParentReport
                {
                    get { return (HCThreeSpecialistReport_Rest)ParentReport; }
                }
                
                public TTReportField NewField1121;
                public TTReportField ACIKLAMA;
                public TTReportField MADDE; 
                public PARTBGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 34;
                    RepeatCount = 0;
                    
                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 2, 198, 7, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"AÇIKLAMA";

                    ACIKLAMA = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 7, 198, 32, false);
                    ACIKLAMA.Name = "ACIKLAMA";
                    ACIKLAMA.DrawStyle = DrawStyleConstants.vbSolid;
                    ACIKLAMA.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACIKLAMA.MultiLine = EvetHayirEnum.ehEvet;
                    ACIKLAMA.NoClip = EvetHayirEnum.ehEvet;
                    ACIKLAMA.WordBreak = EvetHayirEnum.ehEvet;
                    ACIKLAMA.ExpandTabs = EvetHayirEnum.ehEvet;
                    ACIKLAMA.TextFont.CharSet = 162;
                    ACIKLAMA.Value = @"";

                    MADDE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 2, 229, 7, false);
                    MADDE.Name = "MADDE";
                    MADDE.Visible = EvetHayirEnum.ehHayir;
                    MADDE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDE.TextFont.Size = 8;
                    MADDE.TextFont.CharSet = 162;
                    MADDE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField1121.CalcValue = NewField1121.Value;
                    ACIKLAMA.CalcValue = @"";
                    MADDE.CalcValue = @"";
                    return new TTReportObject[] { NewField1121,ACIKLAMA,MADDE};
                }

                public override void RunScript()
                {
#region PARTB BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
                    string sObjectID = ((HCThreeSpecialistReport_Rest)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
                    HealthCommitteeWithThreeSpecialist hcw = (HealthCommitteeWithThreeSpecialist)context.GetObject(new Guid(sObjectID), typeof(HealthCommitteeWithThreeSpecialist));

                    if (hcw != null)
                    {
                        // Karar
                        if (hcw.Report != null)
                            this.ACIKLAMA.CalcValue = TTObjectClasses.Common.GetTextOfRTFString(hcw.Report.ToString());

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

                        this.ACIKLAMA.CalcValue = this.MADDE.CalcValue + this.ACIKLAMA.CalcValue;
                    }

                    if (!string.IsNullOrEmpty(this.ACIKLAMA.CalcValue))
                        this.ACIKLAMA.CalcValue = this.ACIKLAMA.CalcValue + "\r\n";
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

        public HCThreeSpecialistReport_Rest()
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
            Name = "HCTHREESPECIALISTREPORT_REST";
            Caption = "İstirahat Raporu";
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