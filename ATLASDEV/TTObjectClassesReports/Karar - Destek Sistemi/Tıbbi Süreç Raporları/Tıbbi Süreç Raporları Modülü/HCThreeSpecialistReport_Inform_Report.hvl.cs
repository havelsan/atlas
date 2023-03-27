
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
    /// Durum Bildirir Sağlık Kurulu Raporu
    /// </summary>
    public partial class HCThreeSpecialistReport_Inform : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class TANIGroup : TTReportGroup
        {
            public HCThreeSpecialistReport_Inform MyParentReport
            {
                get { return (HCThreeSpecialistReport_Inform)ParentReport; }
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
            public TTReportField NewField1114121 { get {return Header().NewField1114121;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField NewField1114151 { get {return Header().NewField1114151;} }
            public TTReportField NewField11214131 { get {return Header().NewField11214131;} }
            public TTReportField NewField11314111 { get {return Header().NewField11314111;} }
            public TTReportField NewField111141211 { get {return Header().NewField111141211;} }
            public TTReportField NewField11414111 { get {return Header().NewField11414111;} }
            public TTReportField NewField112141211 { get {return Header().NewField112141211;} }
            public TTReportField TCKIMLIKNO { get {return Header().TCKIMLIKNO;} }
            public TTReportField BABAADI { get {return Header().BABAADI;} }
            public TTReportField RAPORISTEKNEDENI { get {return Header().RAPORISTEKNEDENI;} }
            public TTReportField DOGUMTARIH { get {return Header().DOGUMTARIH;} }
            public TTReportField ADRES { get {return Header().ADRES;} }
            public TTReportField MEDULARAPORTAKIPNO { get {return Header().MEDULARAPORTAKIPNO;} }
            public TTReportField NewField11514111 { get {return Header().NewField11514111;} }
            public TTReportField NewField111141411 { get {return Header().NewField111141411;} }
            public TTReportField NewField1112141111 { get {return Header().NewField1112141111;} }
            public TTReportField NewField11214141 { get {return Header().NewField11214141;} }
            public TTReportField NewField114141211 { get {return Header().NewField114141211;} }
            public TTReportField NewField11114141 { get {return Header().NewField11114141;} }
            public TTReportField MUAYENETARIHI { get {return Header().MUAYENETARIHI;} }
            public TTReportField POLIKLINIK { get {return Header().POLIKLINIK;} }
            public TTReportField ONLINEPROTOKOLNO { get {return Header().ONLINEPROTOKOLNO;} }
            public TTReportField RAPORTARIHI { get {return Header().RAPORTARIHI;} }
            public TTReportField TELEFON { get {return Header().TELEFON;} }
            public TTReportField KURUM { get {return Header().KURUM;} }
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
            public TTReportField NewField1113411 { get {return Footer().NewField1113411;} }
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
                public HCThreeSpecialistReport_Inform MyParentReport
                {
                    get { return (HCThreeSpecialistReport_Inform)ParentReport; }
                }
                
                public TTReportField RAPOR121;
                public TTReportField ADSOYAD;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField1114111;
                public TTReportField NewField1114121;
                public TTReportField RAPORNO;
                public TTReportField NewField1114151;
                public TTReportField NewField11214131;
                public TTReportField NewField11314111;
                public TTReportField NewField111141211;
                public TTReportField NewField11414111;
                public TTReportField NewField112141211;
                public TTReportField TCKIMLIKNO;
                public TTReportField BABAADI;
                public TTReportField RAPORISTEKNEDENI;
                public TTReportField DOGUMTARIH;
                public TTReportField ADRES;
                public TTReportField MEDULARAPORTAKIPNO;
                public TTReportField NewField11514111;
                public TTReportField NewField111141411;
                public TTReportField NewField1112141111;
                public TTReportField NewField11214141;
                public TTReportField NewField114141211;
                public TTReportField NewField11114141;
                public TTReportField MUAYENETARIHI;
                public TTReportField POLIKLINIK;
                public TTReportField ONLINEPROTOKOLNO;
                public TTReportField RAPORTARIHI;
                public TTReportField TELEFON;
                public TTReportField KURUM;
                public TTReportField EVTELEFONU;
                public TTReportField CEPTELEFONU; 
                public TANIGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 108;
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
                    RAPOR121.Value = @"DURUM BİLDİRİR SAĞLIK KURULU RAPORU";

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

                    NewField1114111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 91, 145, 97, false);
                    NewField1114111.Name = "NewField1114111";
                    NewField1114111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1114111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1114111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1114111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1114111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1114111.TextFont.CharSet = 162;
                    NewField1114111.Value = @"RAPOR NO";

                    NewField1114121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 85, 145, 91, false);
                    NewField1114121.Name = "NewField1114121";
                    NewField1114121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1114121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1114121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1114121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1114121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1114121.TextFont.CharSet = 162;
                    NewField1114121.Value = @"RAPOR TARİHİ";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 91, 198, 97, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORNO.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORNO.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORNO.TextFont.CharSet = 162;
                    RAPORNO.Value = @"{#RAPORNO#}";

                    NewField1114151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 42, 145, 48, false);
                    NewField1114151.Name = "NewField1114151";
                    NewField1114151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1114151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1114151.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1114151.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1114151.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1114151.TextFont.CharSet = 162;
                    NewField1114151.Value = @"TC KİMLİK NO";

                    NewField11214131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 42, 44, 48, false);
                    NewField11214131.Name = "NewField11214131";
                    NewField11214131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11214131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11214131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11214131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11214131.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11214131.TextFont.CharSet = 162;
                    NewField11214131.Value = @"ADI SOYADI";

                    NewField11314111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 48, 44, 54, false);
                    NewField11314111.Name = "NewField11314111";
                    NewField11314111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11314111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11314111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11314111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11314111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11314111.TextFont.CharSet = 162;
                    NewField11314111.Value = @"BABA ADI";

                    NewField111141211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 78, 44, 91, false);
                    NewField111141211.Name = "NewField111141211";
                    NewField111141211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111141211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111141211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111141211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111141211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111141211.TextFont.CharSet = 162;
                    NewField111141211.Value = @"RAPOR İSTEK NEDENİ";

                    NewField11414111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 54, 44, 60, false);
                    NewField11414111.Name = "NewField11414111";
                    NewField11414111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11414111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11414111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11414111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11414111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11414111.TextFont.CharSet = 162;
                    NewField11414111.Value = @"DOĞUM TARİHİ";

                    NewField112141211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 97, 44, 106, false);
                    NewField112141211.Name = "NewField112141211";
                    NewField112141211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112141211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112141211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112141211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112141211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField112141211.TextFont.CharSet = 162;
                    NewField112141211.Value = @"ADRES";

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

                    RAPORISTEKNEDENI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 78, 106, 91, false);
                    RAPORISTEKNEDENI.Name = "RAPORISTEKNEDENI";
                    RAPORISTEKNEDENI.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORISTEKNEDENI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORISTEKNEDENI.CaseFormat = CaseFormatEnum.fcUpperCase;
                    RAPORISTEKNEDENI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORISTEKNEDENI.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORISTEKNEDENI.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORISTEKNEDENI.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORISTEKNEDENI.TextFont.CharSet = 162;
                    RAPORISTEKNEDENI.Value = @"{#MAKSAT#}";

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

                    ADRES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 97, 198, 106, false);
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

                    MEDULARAPORTAKIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 31, 247, 35, false);
                    MEDULARAPORTAKIPNO.Name = "MEDULARAPORTAKIPNO";
                    MEDULARAPORTAKIPNO.Visible = EvetHayirEnum.ehHayir;
                    MEDULARAPORTAKIPNO.FieldType = ReportFieldTypeEnum.ftExpression;
                    MEDULARAPORTAKIPNO.TextFont.CharSet = 162;
                    MEDULARAPORTAKIPNO.Value = @"{#MEDULARAPORTAKIPNO#}";

                    NewField11514111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 37, 198, 42, false);
                    NewField11514111.Name = "NewField11514111";
                    NewField11514111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11514111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11514111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11514111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11514111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11514111.TextFont.Bold = true;
                    NewField11514111.TextFont.CharSet = 162;
                    NewField11514111.Value = @"BAŞVURU SAHİBİNİN";

                    NewField111141411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 60, 44, 78, false);
                    NewField111141411.Name = "NewField111141411";
                    NewField111141411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111141411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111141411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111141411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111141411.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111141411.TextFont.CharSet = 162;
                    NewField111141411.Value = @"KURUMU VE
GÖREVİ";

                    NewField1112141111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 91, 44, 97, false);
                    NewField1112141111.Name = "NewField1112141111";
                    NewField1112141111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1112141111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1112141111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1112141111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1112141111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1112141111.TextFont.CharSet = 162;
                    NewField1112141111.Value = @"TELEFON";

                    NewField11214141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 48, 145, 54, false);
                    NewField11214141.Name = "NewField11214141";
                    NewField11214141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11214141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11214141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11214141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11214141.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11214141.TextFont.CharSet = 162;
                    NewField11214141.Value = @"MUAYENE TARİHİ";

                    NewField114141211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 54, 145, 78, false);
                    NewField114141211.Name = "NewField114141211";
                    NewField114141211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114141211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField114141211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField114141211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField114141211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField114141211.TextFont.CharSet = 162;
                    NewField114141211.Value = @"POLİKLİNİK / SERVİS";

                    NewField11114141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 78, 145, 85, false);
                    NewField11114141.Name = "NewField11114141";
                    NewField11114141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11114141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11114141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11114141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11114141.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11114141.TextFont.CharSet = 162;
                    NewField11114141.Value = @"ONLİNE PROTOKOL NO";

                    MUAYENETARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 48, 198, 54, false);
                    MUAYENETARIHI.Name = "MUAYENETARIHI";
                    MUAYENETARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    MUAYENETARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENETARIHI.TextFormat = @"dd/MM/yyyy";
                    MUAYENETARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MUAYENETARIHI.TextFont.CharSet = 162;
                    MUAYENETARIHI.Value = @"";

                    POLIKLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 54, 198, 78, false);
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

                    ONLINEPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 78, 198, 85, false);
                    ONLINEPROTOKOLNO.Name = "ONLINEPROTOKOLNO";
                    ONLINEPROTOKOLNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ONLINEPROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONLINEPROTOKOLNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ONLINEPROTOKOLNO.TextFont.CharSet = 162;
                    ONLINEPROTOKOLNO.Value = @"";

                    RAPORTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 85, 198, 91, false);
                    RAPORTARIHI.Name = "RAPORTARIHI";
                    RAPORTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORTARIHI.TextFormat = @"dd/MM/yyyy";
                    RAPORTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORTARIHI.TextFont.CharSet = 162;
                    RAPORTARIHI.Value = @"{#RAPORTARIHI#}";

                    TELEFON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 91, 106, 97, false);
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

                    EVTELEFONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 37, 235, 41, false);
                    EVTELEFONU.Name = "EVTELEFONU";
                    EVTELEFONU.Visible = EvetHayirEnum.ehHayir;
                    EVTELEFONU.FieldType = ReportFieldTypeEnum.ftVariable;
                    EVTELEFONU.TextFont.CharSet = 162;
                    EVTELEFONU.Value = @"{#HOMEPHONE#}";

                    CEPTELEFONU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 43, 235, 47, false);
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
                    NewField1114121.CalcValue = NewField1114121.Value;
                    RAPORNO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Raporno) : "");
                    NewField1114151.CalcValue = NewField1114151.Value;
                    NewField11214131.CalcValue = NewField11214131.Value;
                    NewField11314111.CalcValue = NewField11314111.Value;
                    NewField111141211.CalcValue = NewField111141211.Value;
                    NewField11414111.CalcValue = NewField11414111.Value;
                    NewField112141211.CalcValue = NewField112141211.Value;
                    TCKIMLIKNO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.UniqueRefNo) : "");
                    BABAADI.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.FatherName) : "");
                    RAPORISTEKNEDENI.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Maksat) : "");
                    DOGUMTARIH.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Dtarihi) : "");
                    ADRES.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Adres) : "");
                    NewField11514111.CalcValue = NewField11514111.Value;
                    NewField111141411.CalcValue = NewField111141411.Value;
                    NewField1112141111.CalcValue = NewField1112141111.Value;
                    NewField11214141.CalcValue = NewField11214141.Value;
                    NewField114141211.CalcValue = NewField114141211.Value;
                    NewField11114141.CalcValue = NewField11114141.Value;
                    MUAYENETARIHI.CalcValue = @"";
                    POLIKLINIK.CalcValue = @"";
                    ONLINEPROTOKOLNO.CalcValue = @"";
                    RAPORTARIHI.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Raportarihi) : "");
                    TELEFON.CalcValue = @"";
                    KURUM.CalcValue = @"";
                    EVTELEFONU.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Homephone) : "");
                    CEPTELEFONU.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Mobilephone) : "");
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    MEDULARAPORTAKIPNO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.MedulaRaporTakipNo) : "");
                    return new TTReportObject[] { RAPOR121,ADSOYAD,NewField1114111,NewField1114121,RAPORNO,NewField1114151,NewField11214131,NewField11314111,NewField111141211,NewField11414111,NewField112141211,TCKIMLIKNO,BABAADI,RAPORISTEKNEDENI,DOGUMTARIH,ADRES,NewField11514111,NewField111141411,NewField1112141111,NewField11214141,NewField114141211,NewField11114141,MUAYENETARIHI,POLIKLINIK,ONLINEPROTOKOLNO,RAPORTARIHI,TELEFON,KURUM,EVTELEFONU,CEPTELEFONU,XXXXXXBASLIK,MEDULARAPORTAKIPNO};
                }

                public override void RunScript()
                {
#region TANI HEADER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCThreeSpecialistReport_Inform)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommitteeWithThreeSpecialist hcw = (HealthCommitteeWithThreeSpecialist)context.GetObject(new Guid(sObjectID), typeof(HealthCommitteeWithThreeSpecialist));
            
            if(hcw != null)
            {
                // Muayene Tarihi
                DateTime? muayeneTarihi = null;
                foreach(TTObjectState objectState in hcw.GetStateHistory())
                {
                    if(objectState.StateDefID == HealthCommitteeWithThreeSpecialist.States.New)
                    {
                        if(!muayeneTarihi.HasValue)
                            muayeneTarihi = objectState.BranchDate;
                        else if(objectState.BranchDate < muayeneTarihi.Value)
                            muayeneTarihi = objectState.BranchDate;
                    }
                }
                
                if(muayeneTarihi.HasValue)
                    this.MUAYENETARIHI.CalcValue = muayeneTarihi.ToString();
                
                // Poliklinik / Servis
                if(hcw.Department != null && (hcw.Department is ResPoliclinic || hcw.Department is ResClinic))
                    this.POLIKLINIK.CalcValue = hcw.Department.Name;
                else
                {
                    foreach(HealthCommitteeWithThreeSpecialist_ThreeSpecialistGrid threeSpecialist in hcw.Specialists)
                    {
                        if(threeSpecialist.ResSectionOfSpecialist2 != null && (threeSpecialist.ResSectionOfSpecialist2 is ResPoliclinic || threeSpecialist.ResSectionOfSpecialist2 is ResClinic))
                        {
                            this.POLIKLINIK.CalcValue = threeSpecialist.ResSectionOfSpecialist2.Name;
                            break;
                        }
                        else if(threeSpecialist.ResSectionOfSpecialist3 != null && (threeSpecialist.ResSectionOfSpecialist3 is ResPoliclinic || threeSpecialist.ResSectionOfSpecialist3 is ResClinic))
                        {
                            this.POLIKLINIK.CalcValue = threeSpecialist.ResSectionOfSpecialist3.Name;
                            break;
                        }
                    }
                }
                
                // Sosyal Güvencesi / Kurumu
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
            
            if(!string.IsNullOrEmpty(this.EVTELEFONU.CalcValue))
                this.TELEFON.CalcValue = this.EVTELEFONU.CalcValue;
            else if(!string.IsNullOrEmpty(this.CEPTELEFONU.CalcValue))
                this.TELEFON.CalcValue = this.CEPTELEFONU.CalcValue;
#endregion TANI HEADER_Script
                }
            }
            public partial class TANIGroupFooter : TTReportSection
            {
                public HCThreeSpecialistReport_Inform MyParentReport
                {
                    get { return (HCThreeSpecialistReport_Inform)ParentReport; }
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
                public TTReportField NewField1113411;
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
                    
                    UZ2LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 3, 87, 7, false);
                    UZ2LBL.Name = "UZ2LBL";
                    UZ2LBL.Visible = EvetHayirEnum.ehHayir;
                    UZ2LBL.TextFont.Bold = true;
                    UZ2LBL.TextFont.Underline = true;
                    UZ2LBL.TextFont.CharSet = 162;
                    UZ2LBL.Value = @"İMZA";

                    UZ3LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 3, 151, 7, false);
                    UZ3LBL.Name = "UZ3LBL";
                    UZ3LBL.Visible = EvetHayirEnum.ehHayir;
                    UZ3LBL.TextFont.Bold = true;
                    UZ3LBL.TextFont.Underline = true;
                    UZ3LBL.TextFont.CharSet = 162;
                    UZ3LBL.Value = @"İMZA";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 25, 71, 29, false);
                    UZ.Name = "UZ";
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.TextFont.Size = 8;
                    UZ.TextFont.CharSet = 162;
                    UZ.Value = @"";

                    ADSOYADDOC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 9, 71, 13, false);
                    ADSOYADDOC.Name = "ADSOYADDOC";
                    ADSOYADDOC.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC.TextFont.Size = 8;
                    ADSOYADDOC.TextFont.CharSet = 162;
                    ADSOYADDOC.Value = @"";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 13, 71, 17, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.TextFont.Size = 8;
                    SINRUT.TextFont.CharSet = 162;
                    SINRUT.Value = @"";

                    ADSOYADDOC2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 9, 135, 13, false);
                    ADSOYADDOC2.Name = "ADSOYADDOC2";
                    ADSOYADDOC2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC2.TextFont.Size = 8;
                    ADSOYADDOC2.TextFont.CharSet = 162;
                    ADSOYADDOC2.Value = @"";

                    UZ2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 25, 135, 29, false);
                    UZ2.Name = "UZ2";
                    UZ2.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ2.MultiLine = EvetHayirEnum.ehEvet;
                    UZ2.NoClip = EvetHayirEnum.ehEvet;
                    UZ2.WordBreak = EvetHayirEnum.ehEvet;
                    UZ2.TextFont.Size = 8;
                    UZ2.TextFont.CharSet = 162;
                    UZ2.Value = @"";

                    SINRUT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 13, 135, 17, false);
                    SINRUT2.Name = "SINRUT2";
                    SINRUT2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT2.TextFont.Size = 8;
                    SINRUT2.TextFont.CharSet = 162;
                    SINRUT2.Value = @"";

                    ADSOYADDOC3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 9, 198, 13, false);
                    ADSOYADDOC3.Name = "ADSOYADDOC3";
                    ADSOYADDOC3.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC3.TextFont.Size = 8;
                    ADSOYADDOC3.TextFont.CharSet = 162;
                    ADSOYADDOC3.Value = @"";

                    UZ3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 25, 198, 29, false);
                    UZ3.Name = "UZ3";
                    UZ3.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ3.MultiLine = EvetHayirEnum.ehEvet;
                    UZ3.NoClip = EvetHayirEnum.ehEvet;
                    UZ3.WordBreak = EvetHayirEnum.ehEvet;
                    UZ3.TextFont.Size = 8;
                    UZ3.TextFont.CharSet = 162;
                    UZ3.Value = @"";

                    SINRUT3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 13, 198, 17, false);
                    SINRUT3.Name = "SINRUT3";
                    SINRUT3.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT3.TextFont.Size = 8;
                    SINRUT3.TextFont.CharSet = 162;
                    SINRUT3.Value = @"";

                    NewField1113411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 3, 52, 7, false);
                    NewField1113411.Name = "NewField1113411";
                    NewField1113411.TextFont.Bold = true;
                    NewField1113411.TextFont.Underline = true;
                    NewField1113411.TextFont.CharSet = 162;
                    NewField1113411.Value = @"DÜZENLEYEN TABİP";

                    UZEK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 56, 71, 60, false);
                    UZEK1.Name = "UZEK1";
                    UZEK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZEK1.MultiLine = EvetHayirEnum.ehEvet;
                    UZEK1.NoClip = EvetHayirEnum.ehEvet;
                    UZEK1.WordBreak = EvetHayirEnum.ehEvet;
                    UZEK1.TextFont.Size = 8;
                    UZEK1.TextFont.CharSet = 162;
                    UZEK1.Value = @"";

                    ADSOYADEK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 40, 71, 44, false);
                    ADSOYADEK1.Name = "ADSOYADEK1";
                    ADSOYADEK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADEK1.TextFont.Size = 8;
                    ADSOYADEK1.TextFont.CharSet = 162;
                    ADSOYADEK1.Value = @"";

                    SINRUTEK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 44, 71, 48, false);
                    SINRUTEK1.Name = "SINRUTEK1";
                    SINRUTEK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUTEK1.TextFont.Size = 8;
                    SINRUTEK1.TextFont.CharSet = 162;
                    SINRUTEK1.Value = @"";

                    ADSOYADEK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 40, 135, 44, false);
                    ADSOYADEK2.Name = "ADSOYADEK2";
                    ADSOYADEK2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADEK2.TextFont.Size = 8;
                    ADSOYADEK2.TextFont.CharSet = 162;
                    ADSOYADEK2.Value = @"";

                    UZEK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 56, 135, 60, false);
                    UZEK2.Name = "UZEK2";
                    UZEK2.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZEK2.MultiLine = EvetHayirEnum.ehEvet;
                    UZEK2.NoClip = EvetHayirEnum.ehEvet;
                    UZEK2.WordBreak = EvetHayirEnum.ehEvet;
                    UZEK2.TextFont.Size = 8;
                    UZEK2.TextFont.CharSet = 162;
                    UZEK2.Value = @"";

                    SINRUTEK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 44, 135, 48, false);
                    SINRUTEK2.Name = "SINRUTEK2";
                    SINRUTEK2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUTEK2.TextFont.Size = 8;
                    SINRUTEK2.TextFont.CharSet = 162;
                    SINRUTEK2.Value = @"";

                    EK1LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 34, 52, 38, false);
                    EK1LBL.Name = "EK1LBL";
                    EK1LBL.Visible = EvetHayirEnum.ehHayir;
                    EK1LBL.TextFont.Bold = true;
                    EK1LBL.TextFont.Underline = true;
                    EK1LBL.TextFont.CharSet = 162;
                    EK1LBL.Value = @"İMZA";

                    EK2LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 34, 116, 38, false);
                    EK2LBL.Name = "EK2LBL";
                    EK2LBL.Visible = EvetHayirEnum.ehHayir;
                    EK2LBL.TextFont.Bold = true;
                    EK2LBL.TextFont.Underline = true;
                    EK2LBL.TextFont.CharSet = 162;
                    EK2LBL.Value = @"İMZA";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 17, 71, 21, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO.NoClip = EvetHayirEnum.ehEvet;
                    SICILNO.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO.TextFont.Size = 8;
                    SICILNO.TextFont.CharSet = 162;
                    SICILNO.Value = @"";

                    SICILNO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 17, 135, 21, false);
                    SICILNO2.Name = "SICILNO2";
                    SICILNO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO2.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO2.NoClip = EvetHayirEnum.ehEvet;
                    SICILNO2.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO2.TextFont.Size = 8;
                    SICILNO2.TextFont.CharSet = 162;
                    SICILNO2.Value = @"";

                    SICILNO3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 17, 198, 21, false);
                    SICILNO3.Name = "SICILNO3";
                    SICILNO3.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO3.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO3.NoClip = EvetHayirEnum.ehEvet;
                    SICILNO3.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO3.TextFont.Size = 8;
                    SICILNO3.TextFont.CharSet = 162;
                    SICILNO3.Value = @"";

                    SICILNOEK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 48, 71, 52, false);
                    SICILNOEK1.Name = "SICILNOEK1";
                    SICILNOEK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNOEK1.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNOEK1.NoClip = EvetHayirEnum.ehEvet;
                    SICILNOEK1.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNOEK1.TextFont.Size = 8;
                    SICILNOEK1.TextFont.CharSet = 162;
                    SICILNOEK1.Value = @"";

                    SICILNOEK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 48, 135, 52, false);
                    SICILNOEK2.Name = "SICILNOEK2";
                    SICILNOEK2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNOEK2.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNOEK2.NoClip = EvetHayirEnum.ehEvet;
                    SICILNOEK2.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNOEK2.TextFont.Size = 8;
                    SICILNOEK2.TextFont.CharSet = 162;
                    SICILNOEK2.Value = @"";

                    DIPLOMATESCILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 21, 71, 25, false);
                    DIPLOMATESCILNO.Name = "DIPLOMATESCILNO";
                    DIPLOMATESCILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMATESCILNO.MultiLine = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO.NoClip = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO.WordBreak = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO.TextFont.Size = 8;
                    DIPLOMATESCILNO.TextFont.CharSet = 162;
                    DIPLOMATESCILNO.Value = @"";

                    DIPLOMATESCILNO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 21, 135, 25, false);
                    DIPLOMATESCILNO2.Name = "DIPLOMATESCILNO2";
                    DIPLOMATESCILNO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMATESCILNO2.MultiLine = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO2.NoClip = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO2.WordBreak = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO2.TextFont.Size = 8;
                    DIPLOMATESCILNO2.TextFont.CharSet = 162;
                    DIPLOMATESCILNO2.Value = @"";

                    DIPLOMATESCILNO3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 21, 198, 25, false);
                    DIPLOMATESCILNO3.Name = "DIPLOMATESCILNO3";
                    DIPLOMATESCILNO3.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMATESCILNO3.MultiLine = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO3.NoClip = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO3.WordBreak = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO3.TextFont.Size = 8;
                    DIPLOMATESCILNO3.TextFont.CharSet = 162;
                    DIPLOMATESCILNO3.Value = @"";

                    DIPLOMATESCILNOEK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 52, 71, 56, false);
                    DIPLOMATESCILNOEK1.Name = "DIPLOMATESCILNOEK1";
                    DIPLOMATESCILNOEK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMATESCILNOEK1.MultiLine = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNOEK1.NoClip = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNOEK1.WordBreak = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNOEK1.TextFont.Size = 8;
                    DIPLOMATESCILNOEK1.TextFont.CharSet = 162;
                    DIPLOMATESCILNOEK1.Value = @"";

                    DIPLOMATESCILNOEK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 52, 135, 56, false);
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
                    NewField1113411.CalcValue = NewField1113411.Value;
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
                    return new TTReportObject[] { UZ2LBL,UZ3LBL,UZ,ADSOYADDOC,SINRUT,ADSOYADDOC2,UZ2,SINRUT2,ADSOYADDOC3,UZ3,SINRUT3,NewField1113411,UZEK1,ADSOYADEK1,SINRUTEK1,ADSOYADEK2,UZEK2,SINRUTEK2,EK1LBL,EK2LBL,SICILNO,SICILNO2,SICILNO3,SICILNOEK1,SICILNOEK2,DIPLOMATESCILNO,DIPLOMATESCILNO2,DIPLOMATESCILNO3,DIPLOMATESCILNOEK1,DIPLOMATESCILNOEK2};
                }

                public override void RunScript()
                {
#region TANI FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCThreeSpecialistReport_Inform)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommitteeWithThreeSpecialist hcw = (HealthCommitteeWithThreeSpecialist)context.GetObject(new Guid(sObjectID),"HealthCommitteeWithThreeSpecialist");

            //Baştabip
            string sDoctor =  TTObjectClasses.SystemParameter.GetParameterValue("REPORTAPPROVALPOSITION","HEADDOCTOR");
            string sHeadID = "";
            if(sDoctor == "IITABIP")
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
                    string sForce1 = hcw.Specialists[0].Specialist1.ForcesCommand != null? hcw.Specialists[0].Specialist1.ForcesCommand.Qref : "";
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
            public HCThreeSpecialistReport_Inform MyParentReport
            {
                get { return (HCThreeSpecialistReport_Inform)ParentReport; }
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
                public HCThreeSpecialistReport_Inform MyParentReport
                {
                    get { return (HCThreeSpecialistReport_Inform)ParentReport; }
                }
                
                public TTReportField NewField1121;
                public TTReportField TANI; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 38;
                    RepeatCount = 0;
                    
                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 6, 198, 11, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"ICD KODU VE TANI(LAR)";

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 11, 198, 36, false);
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
            string sObjectID = ((HCThreeSpecialistReport_Inform)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommitteeWithThreeSpecialist hcw = (HealthCommitteeWithThreeSpecialist)context.GetObject(new Guid(sObjectID), typeof(HealthCommitteeWithThreeSpecialist));
            
            if(hcw != null)
            {
                string diagnose = hcw.GetMyOrEpisodeDiagnosis();
                if(!string.IsNullOrEmpty(diagnose))
                    this.TANI.CalcValue = diagnose.Substring(8, diagnose.Length - 8);
            }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        public partial class PARTAGroup : TTReportGroup
        {
            public HCThreeSpecialistReport_Inform MyParentReport
            {
                get { return (HCThreeSpecialistReport_Inform)ParentReport; }
            }

            new public PARTAGroupBody Body()
            {
                return (PARTAGroupBody)_body;
            }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public TTReportField NewField111211 { get {return Body().NewField111211;} }
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
                public HCThreeSpecialistReport_Inform MyParentReport
                {
                    get { return (HCThreeSpecialistReport_Inform)ParentReport; }
                }
                
                public TTReportField KARAR;
                public TTReportField NewField111211;
                public TTReportField MADDE; 
                public PARTAGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 38;
                    RepeatCount = 0;
                    
                    KARAR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 12, 198, 37, false);
                    KARAR.Name = "KARAR";
                    KARAR.DrawStyle = DrawStyleConstants.vbSolid;
                    KARAR.FieldType = ReportFieldTypeEnum.ftVariable;
                    KARAR.MultiLine = EvetHayirEnum.ehEvet;
                    KARAR.NoClip = EvetHayirEnum.ehEvet;
                    KARAR.WordBreak = EvetHayirEnum.ehEvet;
                    KARAR.ExpandTabs = EvetHayirEnum.ehEvet;
                    KARAR.TextFont.CharSet = 162;
                    KARAR.Value = @"";

                    NewField111211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 7, 198, 12, false);
                    NewField111211.Name = "NewField111211";
                    NewField111211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111211.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111211.TextFont.Bold = true;
                    NewField111211.TextFont.CharSet = 162;
                    NewField111211.Value = @"KARAR";

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
                    KARAR.CalcValue = @"";
                    NewField111211.CalcValue = NewField111211.Value;
                    MADDE.CalcValue = @"";
                    return new TTReportObject[] { KARAR,NewField111211,MADDE};
                }

                public override void RunScript()
                {
#region PARTA BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCThreeSpecialistReport_Inform)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            HealthCommitteeWithThreeSpecialist hcw = (HealthCommitteeWithThreeSpecialist)context.GetObject(new Guid(sObjectID), typeof(HealthCommitteeWithThreeSpecialist));
            
            if(hcw != null)
            {
                // Karar
                if(hcw.Report != null)
                    this.KARAR.CalcValue = TTObjectClasses.Common.GetTextOfRTFString(hcw.Report.ToString());
                
                //Madde-Dilim-Fıkra
                BindingList<HCWithThreeSpecialist_MatterSliceAnectodeGrid.GetHCWTS_MatterSliceAnectodeGridByParent_Class> theAnectodes = HCWithThreeSpecialist_MatterSliceAnectodeGrid.GetHCWTS_MatterSliceAnectodeGridByParent(sObjectID);
                if (theAnectodes.Count > 0)
                {
                    this.MADDE.CalcValue = "[";
                    foreach(HCWithThreeSpecialist_MatterSliceAnectodeGrid.GetHCWTS_MatterSliceAnectodeGridByParent_Class theAnectode in theAnectodes)
                    {
                        this.MADDE.CalcValue += theAnectode.Matter + "/" + theAnectode.HalfSlice + "/" + theAnectode.Anectode;
                        this.MADDE.CalcValue += "  ";
                    }
                    this.MADDE.CalcValue = this.MADDE.CalcValue.Substring(0, this.MADDE.CalcValue.Length - 2);
                    this.MADDE.CalcValue += "]\r\n";
                }
                
                this.KARAR.CalcValue = this.MADDE.CalcValue + this.KARAR.CalcValue;
            }
            
            if(!string.IsNullOrEmpty(this.KARAR.CalcValue))
                this.KARAR.CalcValue = this.KARAR.CalcValue + "\r\n";
#endregion PARTA BODY_Script
                }
            }

        }

        public PARTAGroup PARTA;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HCThreeSpecialistReport_Inform()
        {
            TANI = new TANIGroup(this,"TANI");
            MAIN = new MAINGroup(TANI,"MAIN");
            PARTA = new PARTAGroup(TANI,"PARTA");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "HCTHREESPECIALISTREPORT_INFORM";
            Caption = "Durum Bildirir Sağlık Kurulu Raporu";
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