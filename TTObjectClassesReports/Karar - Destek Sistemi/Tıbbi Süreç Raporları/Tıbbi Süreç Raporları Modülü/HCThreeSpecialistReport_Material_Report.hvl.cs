
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
    /// Tıbbi Malzeme Raporu
    /// </summary>
    public partial class HCThreeSpecialistReport_Material : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class TANIGroup : TTReportGroup
        {
            public HCThreeSpecialistReport_Material MyParentReport
            {
                get { return (HCThreeSpecialistReport_Material)ParentReport; }
            }

            new public TANIGroupHeader Header()
            {
                return (TANIGroupHeader)_header;
            }

            new public TANIGroupFooter Footer()
            {
                return (TANIGroupFooter)_footer;
            }

            public TTReportField RAPOR2 { get {return Header().RAPOR2;} }
            public TTReportField ADSOYAD { get {return Header().ADSOYAD;} }
            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField NewField11411 { get {return Header().NewField11411;} }
            public TTReportField NewField11412 { get {return Header().NewField11412;} }
            public TTReportField RAPORNO { get {return Header().RAPORNO;} }
            public TTReportField NewField11415 { get {return Header().NewField11415;} }
            public TTReportField NewField121413 { get {return Header().NewField121413;} }
            public TTReportField NewField131411 { get {return Header().NewField131411;} }
            public TTReportField NewField141411 { get {return Header().NewField141411;} }
            public TTReportField NewField1214121 { get {return Header().NewField1214121;} }
            public TTReportField TCKIMLIKNO { get {return Header().TCKIMLIKNO;} }
            public TTReportField BABAADI { get {return Header().BABAADI;} }
            public TTReportField DOGUMTARIH { get {return Header().DOGUMTARIH;} }
            public TTReportField ADRES { get {return Header().ADRES;} }
            public TTReportField MEDULARAPORTAKIPNO { get {return Header().MEDULARAPORTAKIPNO;} }
            public TTReportField NewField151411 { get {return Header().NewField151411;} }
            public TTReportField NewField1114141 { get {return Header().NewField1114141;} }
            public TTReportField NewField11214111 { get {return Header().NewField11214111;} }
            public TTReportField NewField121414 { get {return Header().NewField121414;} }
            public TTReportField NewField1414121 { get {return Header().NewField1414121;} }
            public TTReportField NewField111414 { get {return Header().NewField111414;} }
            public TTReportField NewField121415 { get {return Header().NewField121415;} }
            public TTReportField RAPORBITISTARIHI { get {return Header().RAPORBITISTARIHI;} }
            public TTReportField MUAYENETARIHI { get {return Header().MUAYENETARIHI;} }
            public TTReportField POLIKLINIK { get {return Header().POLIKLINIK;} }
            public TTReportField ONLINEPROTOKOLNO { get {return Header().ONLINEPROTOKOLNO;} }
            public TTReportField RAPORBASLANGICTARIHI { get {return Header().RAPORBASLANGICTARIHI;} }
            public TTReportField GSSPROVIZYONNO { get {return Header().GSSPROVIZYONNO;} }
            public TTReportField KURUM { get {return Header().KURUM;} }
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
            public TTReportField NewField11341 { get {return Footer().NewField11341;} }
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
            public TTReportField DESCRIPTION { get {return Footer().DESCRIPTION;} }
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
                public HCThreeSpecialistReport_Material MyParentReport
                {
                    get { return (HCThreeSpecialistReport_Material)ParentReport; }
                }
                
                public TTReportField RAPOR2;
                public TTReportField ADSOYAD;
                public TTReportField XXXXXXBASLIK;
                public TTReportField NewField11411;
                public TTReportField NewField11412;
                public TTReportField RAPORNO;
                public TTReportField NewField11415;
                public TTReportField NewField121413;
                public TTReportField NewField131411;
                public TTReportField NewField141411;
                public TTReportField NewField1214121;
                public TTReportField TCKIMLIKNO;
                public TTReportField BABAADI;
                public TTReportField DOGUMTARIH;
                public TTReportField ADRES;
                public TTReportField MEDULARAPORTAKIPNO;
                public TTReportField NewField151411;
                public TTReportField NewField1114141;
                public TTReportField NewField11214111;
                public TTReportField NewField121414;
                public TTReportField NewField1414121;
                public TTReportField NewField111414;
                public TTReportField NewField121415;
                public TTReportField RAPORBITISTARIHI;
                public TTReportField MUAYENETARIHI;
                public TTReportField POLIKLINIK;
                public TTReportField ONLINEPROTOKOLNO;
                public TTReportField RAPORBASLANGICTARIHI;
                public TTReportField GSSPROVIZYONNO;
                public TTReportField KURUM; 
                public TANIGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 102;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    RAPOR2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 29, 198, 34, false);
                    RAPOR2.Name = "RAPOR2";
                    RAPOR2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RAPOR2.VertAlign = VerticalAlignmentEnum.vaBottom;
                    RAPOR2.TextFont.Name = "Arial";
                    RAPOR2.TextFont.Bold = true;
                    RAPOR2.Value = @"TIBBİ MALZEME RAPORU";

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
                    ADSOYAD.TextFont.Name = "Arial Narrow";
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
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    NewField11411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 73, 145, 79, false);
                    NewField11411.Name = "NewField11411";
                    NewField11411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11411.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11411.TextFont.Name = "Arial Narrow";
                    NewField11411.Value = @"RAPOR NO";

                    NewField11412 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 79, 145, 85, false);
                    NewField11412.Name = "NewField11412";
                    NewField11412.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11412.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11412.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11412.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11412.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11412.TextFont.Name = "Arial Narrow";
                    NewField11412.Value = @"RAPOR BAŞLANGIÇ TARİHİ";

                    RAPORNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 73, 198, 79, false);
                    RAPORNO.Name = "RAPORNO";
                    RAPORNO.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORNO.MultiLine = EvetHayirEnum.ehEvet;
                    RAPORNO.WordBreak = EvetHayirEnum.ehEvet;
                    RAPORNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    RAPORNO.TextFont.Name = "Arial Narrow";
                    RAPORNO.Value = @"{#RAPORNO#}";

                    NewField11415 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 42, 145, 48, false);
                    NewField11415.Name = "NewField11415";
                    NewField11415.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11415.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11415.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11415.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11415.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11415.TextFont.Name = "Arial Narrow";
                    NewField11415.Value = @"TC KİMLİK NO";

                    NewField121413 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 42, 44, 48, false);
                    NewField121413.Name = "NewField121413";
                    NewField121413.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121413.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121413.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121413.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121413.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121413.TextFont.Name = "Arial Narrow";
                    NewField121413.Value = @"ADI SOYADI";

                    NewField131411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 48, 44, 54, false);
                    NewField131411.Name = "NewField131411";
                    NewField131411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField131411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField131411.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField131411.TextFont.Name = "Arial Narrow";
                    NewField131411.Value = @"BABA ADI";

                    NewField141411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 54, 44, 60, false);
                    NewField141411.Name = "NewField141411";
                    NewField141411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField141411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField141411.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField141411.TextFont.Name = "Arial Narrow";
                    NewField141411.Value = @"DOĞUM TARİHİ";

                    NewField1214121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 91, 44, 100, false);
                    NewField1214121.Name = "NewField1214121";
                    NewField1214121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1214121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1214121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1214121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1214121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1214121.TextFont.Name = "Arial Narrow";
                    NewField1214121.Value = @"ADRES";

                    TCKIMLIKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 42, 198, 48, false);
                    TCKIMLIKNO.Name = "TCKIMLIKNO";
                    TCKIMLIKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    TCKIMLIKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    TCKIMLIKNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TCKIMLIKNO.MultiLine = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.WordBreak = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.ExpandTabs = EvetHayirEnum.ehEvet;
                    TCKIMLIKNO.TextFont.Name = "Arial Narrow";
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
                    BABAADI.TextFont.Name = "Arial Narrow";
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
                    DOGUMTARIH.TextFont.Name = "Arial Narrow";
                    DOGUMTARIH.Value = @"{#DTARIHI#}";

                    ADRES = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 91, 198, 100, false);
                    ADRES.Name = "ADRES";
                    ADRES.DrawStyle = DrawStyleConstants.vbSolid;
                    ADRES.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADRES.CaseFormat = CaseFormatEnum.fcUpperCase;
                    ADRES.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ADRES.MultiLine = EvetHayirEnum.ehEvet;
                    ADRES.WordBreak = EvetHayirEnum.ehEvet;
                    ADRES.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADRES.TextFont.Name = "Arial Narrow";
                    ADRES.Value = @"{#ADRES#}";

                    MEDULARAPORTAKIPNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 25, 249, 29, false);
                    MEDULARAPORTAKIPNO.Name = "MEDULARAPORTAKIPNO";
                    MEDULARAPORTAKIPNO.Visible = EvetHayirEnum.ehHayir;
                    MEDULARAPORTAKIPNO.FieldType = ReportFieldTypeEnum.ftExpression;
                    MEDULARAPORTAKIPNO.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MEDULARAPORTAKIPNO.VertAlign = VerticalAlignmentEnum.vaBottom;
                    MEDULARAPORTAKIPNO.TextFont.Name = "Arial Narrow";
                    MEDULARAPORTAKIPNO.Value = @"{#MEDULARAPORTAKIPNO#}";

                    NewField151411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 37, 198, 42, false);
                    NewField151411.Name = "NewField151411";
                    NewField151411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151411.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151411.MultiLine = EvetHayirEnum.ehEvet;
                    NewField151411.WordBreak = EvetHayirEnum.ehEvet;
                    NewField151411.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField151411.TextFont.Name = "Arial Narrow";
                    NewField151411.TextFont.Bold = true;
                    NewField151411.Value = @"BAŞVURU SAHİBİNİN";

                    NewField1114141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 60, 44, 79, false);
                    NewField1114141.Name = "NewField1114141";
                    NewField1114141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1114141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1114141.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1114141.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1114141.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1114141.TextFont.Name = "Arial Narrow";
                    NewField1114141.Value = @"SOSYAL GÜVENCESİ / KURUMU";

                    NewField11214111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 85, 44, 91, false);
                    NewField11214111.Name = "NewField11214111";
                    NewField11214111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11214111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11214111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11214111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11214111.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField11214111.TextFont.Name = "Arial Narrow";
                    NewField11214111.Value = @"GSS PROVİZYON NO";

                    NewField121414 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 48, 145, 54, false);
                    NewField121414.Name = "NewField121414";
                    NewField121414.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121414.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121414.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121414.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121414.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121414.TextFont.Name = "Arial Narrow";
                    NewField121414.Value = @"MUAYENE TARİHİ";

                    NewField1414121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 54, 145, 67, false);
                    NewField1414121.Name = "NewField1414121";
                    NewField1414121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1414121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1414121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1414121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1414121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1414121.TextFont.Name = "Arial Narrow";
                    NewField1414121.Value = @"POLİKLİNİK / SERVİS";

                    NewField111414 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 67, 145, 73, false);
                    NewField111414.Name = "NewField111414";
                    NewField111414.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111414.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111414.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111414.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111414.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField111414.TextFont.Name = "Arial Narrow";
                    NewField111414.Value = @"ONLİNE PROTOKOL NO";

                    NewField121415 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 85, 145, 91, false);
                    NewField121415.Name = "NewField121415";
                    NewField121415.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121415.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121415.MultiLine = EvetHayirEnum.ehEvet;
                    NewField121415.WordBreak = EvetHayirEnum.ehEvet;
                    NewField121415.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField121415.TextFont.Name = "Arial Narrow";
                    NewField121415.Value = @"RAPOR BİTİŞ TARİHİ";

                    RAPORBITISTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 85, 198, 91, false);
                    RAPORBITISTARIHI.Name = "RAPORBITISTARIHI";
                    RAPORBITISTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORBITISTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORBITISTARIHI.TextFormat = @"dd/MM/yyyy";
                    RAPORBITISTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORBITISTARIHI.TextFont.Name = "Arial Narrow";
                    RAPORBITISTARIHI.Value = @"{#REPORTENDDATE#}";

                    MUAYENETARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 48, 198, 54, false);
                    MUAYENETARIHI.Name = "MUAYENETARIHI";
                    MUAYENETARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    MUAYENETARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    MUAYENETARIHI.TextFormat = @"dd/MM/yyyy";
                    MUAYENETARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MUAYENETARIHI.TextFont.Name = "Arial Narrow";
                    MUAYENETARIHI.Value = @"";

                    POLIKLINIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 54, 198, 67, false);
                    POLIKLINIK.Name = "POLIKLINIK";
                    POLIKLINIK.DrawStyle = DrawStyleConstants.vbSolid;
                    POLIKLINIK.FieldType = ReportFieldTypeEnum.ftVariable;
                    POLIKLINIK.CaseFormat = CaseFormatEnum.fcUpperCase;
                    POLIKLINIK.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    POLIKLINIK.MultiLine = EvetHayirEnum.ehEvet;
                    POLIKLINIK.NoClip = EvetHayirEnum.ehEvet;
                    POLIKLINIK.WordBreak = EvetHayirEnum.ehEvet;
                    POLIKLINIK.ExpandTabs = EvetHayirEnum.ehEvet;
                    POLIKLINIK.TextFont.Name = "Arial Narrow";
                    POLIKLINIK.Value = @"";

                    ONLINEPROTOKOLNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 67, 198, 73, false);
                    ONLINEPROTOKOLNO.Name = "ONLINEPROTOKOLNO";
                    ONLINEPROTOKOLNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ONLINEPROTOKOLNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONLINEPROTOKOLNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ONLINEPROTOKOLNO.TextFont.Name = "Arial Narrow";
                    ONLINEPROTOKOLNO.Value = @"";

                    RAPORBASLANGICTARIHI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 79, 198, 85, false);
                    RAPORBASLANGICTARIHI.Name = "RAPORBASLANGICTARIHI";
                    RAPORBASLANGICTARIHI.DrawStyle = DrawStyleConstants.vbSolid;
                    RAPORBASLANGICTARIHI.FieldType = ReportFieldTypeEnum.ftVariable;
                    RAPORBASLANGICTARIHI.TextFormat = @"dd/MM/yyyy";
                    RAPORBASLANGICTARIHI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RAPORBASLANGICTARIHI.TextFont.Name = "Arial Narrow";
                    RAPORBASLANGICTARIHI.Value = @"{#REPORTSTARTDATE#}";

                    GSSPROVIZYONNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 85, 106, 91, false);
                    GSSPROVIZYONNO.Name = "GSSPROVIZYONNO";
                    GSSPROVIZYONNO.DrawStyle = DrawStyleConstants.vbSolid;
                    GSSPROVIZYONNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    GSSPROVIZYONNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GSSPROVIZYONNO.TextFont.Name = "Arial Narrow";
                    GSSPROVIZYONNO.Value = @"";

                    KURUM = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 60, 106, 79, false);
                    KURUM.Name = "KURUM";
                    KURUM.DrawStyle = DrawStyleConstants.vbSolid;
                    KURUM.FieldType = ReportFieldTypeEnum.ftVariable;
                    KURUM.CaseFormat = CaseFormatEnum.fcUpperCase;
                    KURUM.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    KURUM.MultiLine = EvetHayirEnum.ehEvet;
                    KURUM.NoClip = EvetHayirEnum.ehEvet;
                    KURUM.WordBreak = EvetHayirEnum.ehEvet;
                    KURUM.ExpandTabs = EvetHayirEnum.ehEvet;
                    KURUM.TextFont.Name = "Arial Narrow";
                    KURUM.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class dataset_GetHCWithThreeSpecialist = ParentGroup.rsGroup.GetCurrentRecord<HealthCommitteeWithThreeSpecialist.GetHCWithThreeSpecialist_Class>(0);
                    RAPOR2.CalcValue = RAPOR2.Value;
                    ADSOYAD.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Patientid) : "");
                    ADSOYAD.PostFieldValueCalculation();
                    NewField11411.CalcValue = NewField11411.Value;
                    NewField11412.CalcValue = NewField11412.Value;
                    RAPORNO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Raporno) : "");
                    NewField11415.CalcValue = NewField11415.Value;
                    NewField121413.CalcValue = NewField121413.Value;
                    NewField131411.CalcValue = NewField131411.Value;
                    NewField141411.CalcValue = NewField141411.Value;
                    NewField1214121.CalcValue = NewField1214121.Value;
                    TCKIMLIKNO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.UniqueRefNo) : "");
                    BABAADI.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.FatherName) : "");
                    DOGUMTARIH.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Dtarihi) : "");
                    ADRES.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.Adres) : "");
                    NewField151411.CalcValue = NewField151411.Value;
                    NewField1114141.CalcValue = NewField1114141.Value;
                    NewField11214111.CalcValue = NewField11214111.Value;
                    NewField121414.CalcValue = NewField121414.Value;
                    NewField1414121.CalcValue = NewField1414121.Value;
                    NewField111414.CalcValue = NewField111414.Value;
                    NewField121415.CalcValue = NewField121415.Value;
                    RAPORBITISTARIHI.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.ReportEndDate) : "");
                    MUAYENETARIHI.CalcValue = @"";
                    POLIKLINIK.CalcValue = @"";
                    ONLINEPROTOKOLNO.CalcValue = @"";
                    RAPORBASLANGICTARIHI.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.ReportStartDate) : "");
                    GSSPROVIZYONNO.CalcValue = @"";
                    KURUM.CalcValue = @"";
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    MEDULARAPORTAKIPNO.CalcValue = (dataset_GetHCWithThreeSpecialist != null ? Globals.ToStringCore(dataset_GetHCWithThreeSpecialist.MedulaRaporTakipNo) : "");
                    return new TTReportObject[] { RAPOR2,ADSOYAD,NewField11411,NewField11412,RAPORNO,NewField11415,NewField121413,NewField131411,NewField141411,NewField1214121,TCKIMLIKNO,BABAADI,DOGUMTARIH,ADRES,NewField151411,NewField1114141,NewField11214111,NewField121414,NewField1414121,NewField111414,NewField121415,RAPORBITISTARIHI,MUAYENETARIHI,POLIKLINIK,ONLINEPROTOKOLNO,RAPORBASLANGICTARIHI,GSSPROVIZYONNO,KURUM,XXXXXXBASLIK,MEDULARAPORTAKIPNO};
                }

                public override void RunScript()
                {
#region TANI HEADER_Script
                    /* TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCThreeSpecialistReport_Material)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
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
                EpisodeProtocol tempEP = null;
                foreach(EpisodeProtocol ep in hcw.Episode.EpisodeProtocols)
                {
                    if(tempEP == null)
                        tempEP = ep;
                    else if(tempEP.OpeningDate.HasValue && ep.OpeningDate.HasValue && tempEP.OpeningDate.Value < ep.OpeningDate.Value)
                        tempEP = ep;
                }
                
                if(tempEP != null && tempEP.Payer != null)
                {
                    this.KURUM.CalcValue = tempEP.Payer.Name.ToUpper();
                    if(!string.IsNullOrEmpty(this.KURUM.CalcValue))
                    {
                        this.KURUM.CalcValue = this.KURUM.CalcValue.Replace(" KURUMU", "");
                        this.KURUM.CalcValue = this.KURUM.CalcValue.Replace("HASTALAR", "HASTA");
                    }
                }
                
                // GSS Provizyon No (En son alınan medula takip no)
                MedulaProvision mp = hcw.Episode.GetLastProvisionFromMyMedulaProvisions();
                if(mp != null && !string.IsNullOrEmpty(mp.ProvisionNo))
                    this.GSSPROVIZYONNO.CalcValue = mp.ProvisionNo;
            }
            */
#endregion TANI HEADER_Script
                }
            }
            public partial class TANIGroupFooter : TTReportSection
            {
                public HCThreeSpecialistReport_Material MyParentReport
                {
                    get { return (HCThreeSpecialistReport_Material)ParentReport; }
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
                public TTReportField NewField11341;
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
                public TTReportField DESCRIPTION; 
                public TANIGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 91;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    UZ2LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 17, 87, 21, false);
                    UZ2LBL.Name = "UZ2LBL";
                    UZ2LBL.Visible = EvetHayirEnum.ehHayir;
                    UZ2LBL.TextFont.Name = "Arial Narrow";
                    UZ2LBL.TextFont.Bold = true;
                    UZ2LBL.TextFont.Underline = true;
                    UZ2LBL.Value = @"İMZA";

                    UZ3LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 17, 151, 21, false);
                    UZ3LBL.Name = "UZ3LBL";
                    UZ3LBL.Visible = EvetHayirEnum.ehHayir;
                    UZ3LBL.TextFont.Name = "Arial Narrow";
                    UZ3LBL.TextFont.Bold = true;
                    UZ3LBL.TextFont.Underline = true;
                    UZ3LBL.Value = @"İMZA";

                    UZ = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 39, 71, 43, false);
                    UZ.Name = "UZ";
                    UZ.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ.MultiLine = EvetHayirEnum.ehEvet;
                    UZ.NoClip = EvetHayirEnum.ehEvet;
                    UZ.WordBreak = EvetHayirEnum.ehEvet;
                    UZ.TextFont.Name = "Arial Narrow";
                    UZ.TextFont.Size = 8;
                    UZ.Value = @"";

                    ADSOYADDOC = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 23, 71, 27, false);
                    ADSOYADDOC.Name = "ADSOYADDOC";
                    ADSOYADDOC.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC.TextFont.Name = "Arial Narrow";
                    ADSOYADDOC.TextFont.Size = 8;
                    ADSOYADDOC.Value = @"";

                    SINRUT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 27, 71, 31, false);
                    SINRUT.Name = "SINRUT";
                    SINRUT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT.TextFont.Name = "Arial Narrow";
                    SINRUT.TextFont.Size = 8;
                    SINRUT.Value = @"";

                    ADSOYADDOC2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 23, 135, 27, false);
                    ADSOYADDOC2.Name = "ADSOYADDOC2";
                    ADSOYADDOC2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC2.TextFont.Name = "Arial Narrow";
                    ADSOYADDOC2.TextFont.Size = 8;
                    ADSOYADDOC2.Value = @"";

                    UZ2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 39, 135, 43, false);
                    UZ2.Name = "UZ2";
                    UZ2.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ2.MultiLine = EvetHayirEnum.ehEvet;
                    UZ2.NoClip = EvetHayirEnum.ehEvet;
                    UZ2.WordBreak = EvetHayirEnum.ehEvet;
                    UZ2.TextFont.Name = "Arial Narrow";
                    UZ2.TextFont.Size = 8;
                    UZ2.Value = @"";

                    SINRUT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 27, 135, 31, false);
                    SINRUT2.Name = "SINRUT2";
                    SINRUT2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT2.TextFont.Name = "Arial Narrow";
                    SINRUT2.TextFont.Size = 8;
                    SINRUT2.Value = @"";

                    ADSOYADDOC3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 23, 198, 27, false);
                    ADSOYADDOC3.Name = "ADSOYADDOC3";
                    ADSOYADDOC3.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADDOC3.TextFont.Name = "Arial Narrow";
                    ADSOYADDOC3.TextFont.Size = 8;
                    ADSOYADDOC3.Value = @"";

                    UZ3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 39, 198, 43, false);
                    UZ3.Name = "UZ3";
                    UZ3.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZ3.MultiLine = EvetHayirEnum.ehEvet;
                    UZ3.NoClip = EvetHayirEnum.ehEvet;
                    UZ3.WordBreak = EvetHayirEnum.ehEvet;
                    UZ3.TextFont.Name = "Arial Narrow";
                    UZ3.TextFont.Size = 8;
                    UZ3.Value = @"";

                    SINRUT3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 27, 198, 31, false);
                    SINRUT3.Name = "SINRUT3";
                    SINRUT3.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUT3.TextFont.Name = "Arial Narrow";
                    SINRUT3.TextFont.Size = 8;
                    SINRUT3.Value = @"";

                    NewField11341 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 17, 52, 21, false);
                    NewField11341.Name = "NewField11341";
                    NewField11341.TextFont.Name = "Arial Narrow";
                    NewField11341.TextFont.Bold = true;
                    NewField11341.TextFont.Underline = true;
                    NewField11341.Value = @"DÜZENLEYEN TABİP";

                    UZEK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 70, 71, 74, false);
                    UZEK1.Name = "UZEK1";
                    UZEK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZEK1.MultiLine = EvetHayirEnum.ehEvet;
                    UZEK1.NoClip = EvetHayirEnum.ehEvet;
                    UZEK1.WordBreak = EvetHayirEnum.ehEvet;
                    UZEK1.TextFont.Name = "Arial Narrow";
                    UZEK1.TextFont.Size = 8;
                    UZEK1.Value = @"";

                    ADSOYADEK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 54, 71, 58, false);
                    ADSOYADEK1.Name = "ADSOYADEK1";
                    ADSOYADEK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADEK1.TextFont.Name = "Arial Narrow";
                    ADSOYADEK1.TextFont.Size = 8;
                    ADSOYADEK1.Value = @"";

                    SINRUTEK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 58, 71, 62, false);
                    SINRUTEK1.Name = "SINRUTEK1";
                    SINRUTEK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUTEK1.TextFont.Name = "Arial Narrow";
                    SINRUTEK1.TextFont.Size = 8;
                    SINRUTEK1.Value = @"";

                    ADSOYADEK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 54, 135, 58, false);
                    ADSOYADEK2.Name = "ADSOYADEK2";
                    ADSOYADEK2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADSOYADEK2.TextFont.Name = "Arial Narrow";
                    ADSOYADEK2.TextFont.Size = 8;
                    ADSOYADEK2.Value = @"";

                    UZEK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 70, 135, 74, false);
                    UZEK2.Name = "UZEK2";
                    UZEK2.FieldType = ReportFieldTypeEnum.ftVariable;
                    UZEK2.MultiLine = EvetHayirEnum.ehEvet;
                    UZEK2.NoClip = EvetHayirEnum.ehEvet;
                    UZEK2.WordBreak = EvetHayirEnum.ehEvet;
                    UZEK2.TextFont.Name = "Arial Narrow";
                    UZEK2.TextFont.Size = 8;
                    UZEK2.Value = @"";

                    SINRUTEK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 58, 135, 62, false);
                    SINRUTEK2.Name = "SINRUTEK2";
                    SINRUTEK2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SINRUTEK2.TextFont.Name = "Arial Narrow";
                    SINRUTEK2.TextFont.Size = 8;
                    SINRUTEK2.Value = @"";

                    EK1LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 48, 52, 52, false);
                    EK1LBL.Name = "EK1LBL";
                    EK1LBL.Visible = EvetHayirEnum.ehHayir;
                    EK1LBL.TextFont.Name = "Arial Narrow";
                    EK1LBL.TextFont.Bold = true;
                    EK1LBL.TextFont.Underline = true;
                    EK1LBL.Value = @"İMZA";

                    EK2LBL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 48, 116, 52, false);
                    EK2LBL.Name = "EK2LBL";
                    EK2LBL.Visible = EvetHayirEnum.ehHayir;
                    EK2LBL.TextFont.Name = "Arial Narrow";
                    EK2LBL.TextFont.Bold = true;
                    EK2LBL.TextFont.Underline = true;
                    EK2LBL.Value = @"İMZA";

                    SICILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 31, 71, 35, false);
                    SICILNO.Name = "SICILNO";
                    SICILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO.NoClip = EvetHayirEnum.ehEvet;
                    SICILNO.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO.TextFont.Name = "Arial Narrow";
                    SICILNO.TextFont.Size = 8;
                    SICILNO.Value = @"";

                    SICILNO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 31, 135, 35, false);
                    SICILNO2.Name = "SICILNO2";
                    SICILNO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO2.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO2.NoClip = EvetHayirEnum.ehEvet;
                    SICILNO2.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO2.TextFont.Name = "Arial Narrow";
                    SICILNO2.TextFont.Size = 8;
                    SICILNO2.Value = @"";

                    SICILNO3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 31, 198, 35, false);
                    SICILNO3.Name = "SICILNO3";
                    SICILNO3.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNO3.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNO3.NoClip = EvetHayirEnum.ehEvet;
                    SICILNO3.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNO3.TextFont.Name = "Arial Narrow";
                    SICILNO3.TextFont.Size = 8;
                    SICILNO3.Value = @"";

                    SICILNOEK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 62, 71, 66, false);
                    SICILNOEK1.Name = "SICILNOEK1";
                    SICILNOEK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNOEK1.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNOEK1.NoClip = EvetHayirEnum.ehEvet;
                    SICILNOEK1.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNOEK1.TextFont.Name = "Arial Narrow";
                    SICILNOEK1.TextFont.Size = 8;
                    SICILNOEK1.Value = @"";

                    SICILNOEK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 62, 135, 66, false);
                    SICILNOEK2.Name = "SICILNOEK2";
                    SICILNOEK2.FieldType = ReportFieldTypeEnum.ftVariable;
                    SICILNOEK2.MultiLine = EvetHayirEnum.ehEvet;
                    SICILNOEK2.NoClip = EvetHayirEnum.ehEvet;
                    SICILNOEK2.WordBreak = EvetHayirEnum.ehEvet;
                    SICILNOEK2.TextFont.Name = "Arial Narrow";
                    SICILNOEK2.TextFont.Size = 8;
                    SICILNOEK2.Value = @"";

                    DIPLOMATESCILNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 35, 71, 39, false);
                    DIPLOMATESCILNO.Name = "DIPLOMATESCILNO";
                    DIPLOMATESCILNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMATESCILNO.MultiLine = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO.NoClip = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO.WordBreak = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO.TextFont.Name = "Arial Narrow";
                    DIPLOMATESCILNO.TextFont.Size = 8;
                    DIPLOMATESCILNO.Value = @"";

                    DIPLOMATESCILNO2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 35, 135, 39, false);
                    DIPLOMATESCILNO2.Name = "DIPLOMATESCILNO2";
                    DIPLOMATESCILNO2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMATESCILNO2.MultiLine = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO2.NoClip = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO2.WordBreak = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO2.TextFont.Name = "Arial Narrow";
                    DIPLOMATESCILNO2.TextFont.Size = 8;
                    DIPLOMATESCILNO2.Value = @"";

                    DIPLOMATESCILNO3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 142, 35, 198, 39, false);
                    DIPLOMATESCILNO3.Name = "DIPLOMATESCILNO3";
                    DIPLOMATESCILNO3.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMATESCILNO3.MultiLine = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO3.NoClip = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO3.WordBreak = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNO3.TextFont.Name = "Arial Narrow";
                    DIPLOMATESCILNO3.TextFont.Size = 8;
                    DIPLOMATESCILNO3.Value = @"";

                    DIPLOMATESCILNOEK1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 66, 71, 70, false);
                    DIPLOMATESCILNOEK1.Name = "DIPLOMATESCILNOEK1";
                    DIPLOMATESCILNOEK1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMATESCILNOEK1.MultiLine = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNOEK1.NoClip = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNOEK1.WordBreak = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNOEK1.TextFont.Name = "Arial Narrow";
                    DIPLOMATESCILNOEK1.TextFont.Size = 8;
                    DIPLOMATESCILNOEK1.Value = @"";

                    DIPLOMATESCILNOEK2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 66, 135, 70, false);
                    DIPLOMATESCILNOEK2.Name = "DIPLOMATESCILNOEK2";
                    DIPLOMATESCILNOEK2.FieldType = ReportFieldTypeEnum.ftVariable;
                    DIPLOMATESCILNOEK2.MultiLine = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNOEK2.NoClip = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNOEK2.WordBreak = EvetHayirEnum.ehEvet;
                    DIPLOMATESCILNOEK2.TextFont.Name = "Arial Narrow";
                    DIPLOMATESCILNOEK2.TextFont.Size = 8;
                    DIPLOMATESCILNOEK2.Value = @"";

                    DESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 3, 198, 9, false);
                    DESCRIPTION.Name = "DESCRIPTION";
                    DESCRIPTION.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DESCRIPTION.TextFont.Name = "Arial Narrow";
                    DESCRIPTION.Value = @"";

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
                    NewField11341.CalcValue = NewField11341.Value;
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
                    DESCRIPTION.CalcValue = DESCRIPTION.Value;
                    return new TTReportObject[] { UZ2LBL,UZ3LBL,UZ,ADSOYADDOC,SINRUT,ADSOYADDOC2,UZ2,SINRUT2,ADSOYADDOC3,UZ3,SINRUT3,NewField11341,UZEK1,ADSOYADEK1,SINRUTEK1,ADSOYADEK2,UZEK2,SINRUTEK2,EK1LBL,EK2LBL,SICILNO,SICILNO2,SICILNO3,SICILNOEK1,SICILNOEK2,DIPLOMATESCILNO,DIPLOMATESCILNO2,DIPLOMATESCILNO3,DIPLOMATESCILNOEK1,DIPLOMATESCILNOEK2,DESCRIPTION};
                }

                public override void RunScript()
                {
#region TANI FOOTER_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCThreeSpecialistReport_Material)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
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
            
            // Malzeme kullanım süresi
            string time = "....................................";
            if(hcw.ReportStartDate.HasValue && hcw.ReportEndDate.HasValue)
                time = (hcw.ReportEndDate.Value.Date - hcw.ReportStartDate.Value.Date).TotalDays.ToString() + " gün";
            
            this.DESCRIPTION.CalcValue = "Hastanın yukarıda belirtilen hastalığı ile ilgili sıralanan malzemeyi " + time + " süre ile kullanması gerekmektedir.";
#endregion TANI FOOTER_Script
                }
            }

        }

        public TANIGroup TANI;

        public partial class MAINGroup : TTReportGroup
        {
            public HCThreeSpecialistReport_Material MyParentReport
            {
                get { return (HCThreeSpecialistReport_Material)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField12 { get {return Body().NewField12;} }
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
                public HCThreeSpecialistReport_Material MyParentReport
                {
                    get { return (HCThreeSpecialistReport_Material)ParentReport; }
                }
                
                public TTReportField NewField12;
                public TTReportField TANI; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 38;
                    RepeatCount = 0;
                    
                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 6, 198, 11, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField12.TextFont.Name = "Arial Narrow";
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @"ICD KODU VE TANI(LAR)";

                    TANI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 11, 198, 36, false);
                    TANI.Name = "TANI";
                    TANI.DrawStyle = DrawStyleConstants.vbSolid;
                    TANI.FieldType = ReportFieldTypeEnum.ftVariable;
                    TANI.MultiLine = EvetHayirEnum.ehEvet;
                    TANI.NoClip = EvetHayirEnum.ehEvet;
                    TANI.WordBreak = EvetHayirEnum.ehEvet;
                    TANI.ExpandTabs = EvetHayirEnum.ehEvet;
                    TANI.TextFont.Name = "Arial Narrow";
                    TANI.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField12.CalcValue = NewField12.Value;
                    TANI.CalcValue = @"";
                    return new TTReportObject[] { NewField12,TANI};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCThreeSpecialistReport_Material)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
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
            public HCThreeSpecialistReport_Material MyParentReport
            {
                get { return (HCThreeSpecialistReport_Material)ParentReport; }
            }

            new public PARTAGroupBody Body()
            {
                return (PARTAGroupBody)_body;
            }
            public TTReportField KARAR { get {return Body().KARAR;} }
            public TTReportField NewField1121 { get {return Body().NewField1121;} }
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
                public HCThreeSpecialistReport_Material MyParentReport
                {
                    get { return (HCThreeSpecialistReport_Material)ParentReport; }
                }
                
                public TTReportField KARAR;
                public TTReportField NewField1121;
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
                    KARAR.TextFont.Name = "Arial Narrow";
                    KARAR.Value = @"";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 14, 7, 198, 12, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Name = "Arial Narrow";
                    NewField1121.TextFont.Bold = true;
                    NewField1121.Value = @"KARAR";

                    MADDE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 213, 2, 229, 7, false);
                    MADDE.Name = "MADDE";
                    MADDE.Visible = EvetHayirEnum.ehHayir;
                    MADDE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MADDE.TextFont.Name = "Arial Narrow";
                    MADDE.TextFont.Size = 8;
                    MADDE.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    KARAR.CalcValue = @"";
                    NewField1121.CalcValue = NewField1121.Value;
                    MADDE.CalcValue = @"";
                    return new TTReportObject[] { KARAR,NewField1121,MADDE};
                }

                public override void RunScript()
                {
#region PARTA BODY_Script
                    TTObjectContext context = new TTObjectContext(true);
            string sObjectID = ((HCThreeSpecialistReport_Material)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
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

        public HCThreeSpecialistReport_Material()
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
            Name = "HCTHREESPECIALISTREPORT_MATERIAL";
            Caption = "Tıbbi Malzeme Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            SaveViewOnPrint = EvetHayirEnum.ehEvet;
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